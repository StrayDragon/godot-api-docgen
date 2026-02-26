namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 1D texture where pixel brightness corresponds to points on a unit <see cref="Godot.Curve"/> resource, either in grayscale or in red. This visual representation simplifies the task of saving curves as image files.</para>
/// <para>If you need to store up to 3 curves within a single texture, use <see cref="Godot.CurveXyzTexture"/> instead. See also <see cref="Godot.GradientTexture1D"/> and <see cref="Godot.GradientTexture2D"/>.</para>
/// </summary>
public partial class CurveTexture : Texture2D
{
    public enum TextureModeEnum : long
    {
        /// <summary>
        /// <para>Store the curve equally across the red, green and blue channels. This uses more video memory, but is more compatible with shaders that only read the green and blue values.</para>
        /// </summary>
        Rgb = 0,
        /// <summary>
        /// <para>Store the curve only in the red channel. This saves video memory, but some custom shaders may not be able to work with this.</para>
        /// </summary>
        Red = 1
    }

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
    /// <para>The format the texture should be generated with. When passing a CurveTexture as an input to a <see cref="Godot.Shader"/>, this may need to be adjusted.</para>
    /// </summary>
    public CurveTexture.TextureModeEnum TextureMode
    {
        get
        {
            return GetTextureMode();
        }
        set
        {
            SetTextureMode(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Curve"/> that is rendered onto the texture. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve Curve
    {
        get
        {
            return GetCurve();
        }
        set
        {
            SetCurve(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CurveTexture);

    private static readonly StringName NativeName = "CurveTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CurveTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CurveTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CurveTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWidth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWidth(int width)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurve, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurve(Curve curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurve, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetCurve()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureMode, 1321955367ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureMode(CurveTexture.TextureModeEnum textureMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), (int)textureMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureMode, 715756376ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CurveTexture.TextureModeEnum GetTextureMode()
    {
        return (CurveTexture.TextureModeEnum)NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
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
        /// Cached name for the 'texture_mode' property.
        /// </summary>
        public static readonly StringName TextureMode = "texture_mode";
        /// <summary>
        /// Cached name for the 'curve' property.
        /// </summary>
        public static readonly StringName Curve = "curve";
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
        /// Cached name for the 'set_curve' method.
        /// </summary>
        public static readonly StringName SetCurve = "set_curve";
        /// <summary>
        /// Cached name for the 'get_curve' method.
        /// </summary>
        public static readonly StringName GetCurve = "get_curve";
        /// <summary>
        /// Cached name for the 'set_texture_mode' method.
        /// </summary>
        public static readonly StringName SetTextureMode = "set_texture_mode";
        /// <summary>
        /// Cached name for the 'get_texture_mode' method.
        /// </summary>
        public static readonly StringName GetTextureMode = "get_texture_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}
