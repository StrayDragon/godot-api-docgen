namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Performs a lookup operation on the texture provided as a uniform for the shader.</para>
/// </summary>
public partial class VisualShaderNodeTextureParameter : VisualShaderNodeParameter
{
    public enum TextureTypeEnum : long
    {
        /// <summary>
        /// <para>No hints are added to the uniform declaration.</para>
        /// </summary>
        Data = 0,
        /// <summary>
        /// <para>Adds <c>source_color</c> as hint to the uniform declaration for proper conversion from nonlinear sRGB encoding to linear encoding.</para>
        /// </summary>
        Color = 1,
        /// <summary>
        /// <para>Adds <c>hint_normal</c> as hint to the uniform declaration, which internally converts the texture for proper usage as normal map.</para>
        /// </summary>
        NormalMap = 2,
        /// <summary>
        /// <para>Adds <c>hint_anisotropy</c> as hint to the uniform declaration to use for a flowmap.</para>
        /// </summary>
        Anisotropy = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeTextureParameter.TextureTypeEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum ColorDefaultEnum : long
    {
        /// <summary>
        /// <para>Defaults to fully opaque white color.</para>
        /// </summary>
        White = 0,
        /// <summary>
        /// <para>Defaults to fully opaque black color.</para>
        /// </summary>
        Black = 1,
        /// <summary>
        /// <para>Defaults to fully transparent black color.</para>
        /// </summary>
        Transparent = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeTextureParameter.ColorDefaultEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum TextureFilterEnum : long
    {
        /// <summary>
        /// <para>Sample the texture using the filter determined by the node this shader is attached to.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>The texture filter reads from the nearest pixel only. This makes the texture look pixelated from up close, and grainy from a distance (due to mipmaps not being sampled).</para>
        /// </summary>
        Nearest = 1,
        /// <summary>
        /// <para>The texture filter blends between the nearest 4 pixels. This makes the texture look smooth from up close, and grainy from a distance (due to mipmaps not being sampled).</para>
        /// </summary>
        Linear = 2,
        /// <summary>
        /// <para>The texture filter reads from the nearest pixel and blends between the nearest 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>). This makes the texture look pixelated from up close, and smooth from a distance.</para>
        /// <para>Use this for non-pixel art textures that may be viewed at a low scale (e.g. due to <see cref="Godot.Camera2D"/> zoom or sprite scaling), as mipmaps are important to smooth out pixels that are smaller than on-screen pixels.</para>
        /// </summary>
        NearestMipmap = 3,
        /// <summary>
        /// <para>The texture filter blends between the nearest 4 pixels and between the nearest 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>). This makes the texture look smooth from up close, and smooth from a distance.</para>
        /// <para>Use this for non-pixel art textures that may be viewed at a low scale (e.g. due to <see cref="Godot.Camera2D"/> zoom or sprite scaling), as mipmaps are important to smooth out pixels that are smaller than on-screen pixels.</para>
        /// </summary>
        LinearMipmap = 4,
        /// <summary>
        /// <para>The texture filter reads from the nearest pixel and blends between 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>) based on the angle between the surface and the camera view. This makes the texture look pixelated from up close, and smooth from a distance. Anisotropic filtering improves texture quality on surfaces that are almost in line with the camera, but is slightly slower. The anisotropic filtering level can be changed by adjusting <c>ProjectSettings.rendering/textures/default_filters/anisotropic_filtering_level</c>.</para>
        /// <para><b>Note:</b> This texture filter is rarely useful in 2D projects. <see cref="Godot.VisualShaderNodeTextureParameter.TextureFilterEnum.NearestMipmap"/> is usually more appropriate in this case.</para>
        /// </summary>
        NearestMipmapAnisotropic = 5,
        /// <summary>
        /// <para>The texture filter blends between the nearest 4 pixels and blends between 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>) based on the angle between the surface and the camera view. This makes the texture look smooth from up close, and smooth from a distance. Anisotropic filtering improves texture quality on surfaces that are almost in line with the camera, but is slightly slower. The anisotropic filtering level can be changed by adjusting <c>ProjectSettings.rendering/textures/default_filters/anisotropic_filtering_level</c>.</para>
        /// <para><b>Note:</b> This texture filter is rarely useful in 2D projects. <see cref="Godot.VisualShaderNodeTextureParameter.TextureFilterEnum.LinearMipmap"/> is usually more appropriate in this case.</para>
        /// </summary>
        LinearMipmapAnisotropic = 6,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeTextureParameter.TextureFilterEnum"/> enum.</para>
        /// </summary>
        Max = 7
    }

    public enum TextureRepeatEnum : long
    {
        /// <summary>
        /// <para>Sample the texture using the repeat mode determined by the node this shader is attached to.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>Texture will repeat normally.</para>
        /// </summary>
        Enabled = 1,
        /// <summary>
        /// <para>Texture will not repeat.</para>
        /// </summary>
        Disabled = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeTextureParameter.TextureRepeatEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum TextureSourceEnum : long
    {
        /// <summary>
        /// <para>The texture source is not specified in the shader.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>The texture source is the screen texture which captures all opaque objects drawn this frame.</para>
        /// </summary>
        Screen = 1,
        /// <summary>
        /// <para>The texture source is the depth texture from the depth prepass.</para>
        /// </summary>
        Depth = 2,
        /// <summary>
        /// <para>The texture source is the normal-roughness buffer from the depth prepass.</para>
        /// </summary>
        NormalRoughness = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeTextureParameter.TextureSourceEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    /// <summary>
    /// <para>Defines the type of data provided by the source texture.</para>
    /// </summary>
    public VisualShaderNodeTextureParameter.TextureTypeEnum TextureType
    {
        get
        {
            return GetTextureType();
        }
        set
        {
            SetTextureType(value);
        }
    }

    /// <summary>
    /// <para>Sets the default color if no texture is assigned to the uniform.</para>
    /// </summary>
    public VisualShaderNodeTextureParameter.ColorDefaultEnum ColorDefault
    {
        get
        {
            return GetColorDefault();
        }
        set
        {
            SetColorDefault(value);
        }
    }

    /// <summary>
    /// <para>Sets the texture filtering mode.</para>
    /// </summary>
    public VisualShaderNodeTextureParameter.TextureFilterEnum TextureFilter
    {
        get
        {
            return GetTextureFilter();
        }
        set
        {
            SetTextureFilter(value);
        }
    }

    /// <summary>
    /// <para>Sets the texture repeating mode.</para>
    /// </summary>
    public VisualShaderNodeTextureParameter.TextureRepeatEnum TextureRepeat
    {
        get
        {
            return GetTextureRepeat();
        }
        set
        {
            SetTextureRepeat(value);
        }
    }

    /// <summary>
    /// <para>Sets the texture source mode. Used for reading from the screen, depth, or normal_roughness texture.</para>
    /// </summary>
    public VisualShaderNodeTextureParameter.TextureSourceEnum TextureSource
    {
        get
        {
            return GetTextureSource();
        }
        set
        {
            SetTextureSource(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeTextureParameter);

    private static readonly StringName NativeName = "VisualShaderNodeTextureParameter";

    internal VisualShaderNodeTextureParameter() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeTextureParameter(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeTextureParameter(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureType, 2227296876ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureType(VisualShaderNodeTextureParameter.TextureTypeEnum type)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureType, 367922070ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeTextureParameter.TextureTypeEnum GetTextureType()
    {
        return (VisualShaderNodeTextureParameter.TextureTypeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColorDefault, 4217624432ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorDefault(VisualShaderNodeTextureParameter.ColorDefaultEnum color)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorDefault, 3837060134ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeTextureParameter.ColorDefaultEnum GetColorDefault()
    {
        return (VisualShaderNodeTextureParameter.ColorDefaultEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureFilter, 2147684752ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureFilter(VisualShaderNodeTextureParameter.TextureFilterEnum filter)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureFilter, 4184490817ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeTextureParameter.TextureFilterEnum GetTextureFilter()
    {
        return (VisualShaderNodeTextureParameter.TextureFilterEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureRepeat, 2036143070ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureRepeat(VisualShaderNodeTextureParameter.TextureRepeatEnum repeat)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)repeat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureRepeat, 1690132794ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeTextureParameter.TextureRepeatEnum GetTextureRepeat()
    {
        return (VisualShaderNodeTextureParameter.TextureRepeatEnum)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureSource, 1212687372ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureSource(VisualShaderNodeTextureParameter.TextureSourceEnum source)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)source);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureSource, 2039092262ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeTextureParameter.TextureSourceEnum GetTextureSource()
    {
        return (VisualShaderNodeTextureParameter.TextureSourceEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNodeParameter.PropertyName
    {
        /// <summary>
        /// Cached name for the 'texture_type' property.
        /// </summary>
        public static readonly StringName TextureType = "texture_type";
        /// <summary>
        /// Cached name for the 'color_default' property.
        /// </summary>
        public static readonly StringName ColorDefault = "color_default";
        /// <summary>
        /// Cached name for the 'texture_filter' property.
        /// </summary>
        public static readonly StringName TextureFilter = "texture_filter";
        /// <summary>
        /// Cached name for the 'texture_repeat' property.
        /// </summary>
        public static readonly StringName TextureRepeat = "texture_repeat";
        /// <summary>
        /// Cached name for the 'texture_source' property.
        /// </summary>
        public static readonly StringName TextureSource = "texture_source";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeParameter.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_texture_type' method.
        /// </summary>
        public static readonly StringName SetTextureType = "set_texture_type";
        /// <summary>
        /// Cached name for the 'get_texture_type' method.
        /// </summary>
        public static readonly StringName GetTextureType = "get_texture_type";
        /// <summary>
        /// Cached name for the 'set_color_default' method.
        /// </summary>
        public static readonly StringName SetColorDefault = "set_color_default";
        /// <summary>
        /// Cached name for the 'get_color_default' method.
        /// </summary>
        public static readonly StringName GetColorDefault = "get_color_default";
        /// <summary>
        /// Cached name for the 'set_texture_filter' method.
        /// </summary>
        public static readonly StringName SetTextureFilter = "set_texture_filter";
        /// <summary>
        /// Cached name for the 'get_texture_filter' method.
        /// </summary>
        public static readonly StringName GetTextureFilter = "get_texture_filter";
        /// <summary>
        /// Cached name for the 'set_texture_repeat' method.
        /// </summary>
        public static readonly StringName SetTextureRepeat = "set_texture_repeat";
        /// <summary>
        /// Cached name for the 'get_texture_repeat' method.
        /// </summary>
        public static readonly StringName GetTextureRepeat = "get_texture_repeat";
        /// <summary>
        /// Cached name for the 'set_texture_source' method.
        /// </summary>
        public static readonly StringName SetTextureSource = "set_texture_source";
        /// <summary>
        /// Cached name for the 'get_texture_source' method.
        /// </summary>
        public static readonly StringName GetTextureSource = "get_texture_source";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNodeParameter.SignalName
    {
    }
}
