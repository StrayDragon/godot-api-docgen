namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Translated to <c>texture(cubemap, vec3)</c> in the shader language. Returns a color vector and alpha channel as scalar.</para>
/// </summary>
public partial class VisualShaderNodeCubemap : VisualShaderNode
{
    public enum SourceEnum : long
    {
        /// <summary>
        /// <para>Use the <see cref="Godot.Cubemap"/> set via <see cref="Godot.VisualShaderNodeCubemap.CubeMap"/>. If this is set to <see cref="Godot.VisualShaderNodeCubemap.Source"/>, the <c>samplerCube</c> port is ignored.</para>
        /// </summary>
        Texture = 0,
        /// <summary>
        /// <para>Use the <see cref="Godot.Cubemap"/> sampler reference passed via the <c>samplerCube</c> port. If this is set to <see cref="Godot.VisualShaderNodeCubemap.Source"/>, the <see cref="Godot.VisualShaderNodeCubemap.CubeMap"/> texture is ignored.</para>
        /// </summary>
        Port = 1,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeCubemap.SourceEnum"/> enum.</para>
        /// </summary>
        Max = 2
    }

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
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeCubemap.TextureTypeEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>Defines which source should be used for the sampling.</para>
    /// </summary>
    public VisualShaderNodeCubemap.SourceEnum Source
    {
        get
        {
            return GetSource();
        }
        set
        {
            SetSource(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Cubemap"/> texture to sample when using <see cref="Godot.VisualShaderNodeCubemap.SourceEnum.Texture"/> as <see cref="Godot.VisualShaderNodeCubemap.Source"/>.</para>
    /// </summary>
    public TextureLayered CubeMap
    {
        get
        {
            return GetCubeMap();
        }
        set
        {
            SetCubeMap(value);
        }
    }

    /// <summary>
    /// <para>Defines the type of data provided by the source texture.</para>
    /// </summary>
    public VisualShaderNodeCubemap.TextureTypeEnum TextureType
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeCubemap);

    private static readonly StringName NativeName = "VisualShaderNodeCubemap";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeCubemap() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeCubemap(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeCubemap(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSource, 1625400621ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSource(VisualShaderNodeCubemap.SourceEnum value)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSource, 2222048781ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeCubemap.SourceEnum GetSource()
    {
        return (VisualShaderNodeCubemap.SourceEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCubeMap, 1278366092ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCubeMap(TextureLayered value)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(value));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCubeMap, 3984243839ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextureLayered GetCubeMap()
    {
        return (TextureLayered)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureType, 1899718876ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureType(VisualShaderNodeCubemap.TextureTypeEnum value)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureType, 3356498888ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeCubemap.TextureTypeEnum GetTextureType()
    {
        return (VisualShaderNodeCubemap.TextureTypeEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCubeMap, 2219800736ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCubeMap(Cubemap value)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(value));
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
    public new class PropertyName : VisualShaderNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'source' property.
        /// </summary>
        public static readonly StringName Source = "source";
        /// <summary>
        /// Cached name for the 'cube_map' property.
        /// </summary>
        public static readonly StringName CubeMap = "cube_map";
        /// <summary>
        /// Cached name for the 'texture_type' property.
        /// </summary>
        public static readonly StringName TextureType = "texture_type";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_source' method.
        /// </summary>
        public static readonly StringName SetSource = "set_source";
        /// <summary>
        /// Cached name for the 'get_source' method.
        /// </summary>
        public static readonly StringName GetSource = "get_source";
        /// <summary>
        /// Cached name for the 'set_cube_map' method.
        /// </summary>
        public static readonly StringName SetCubeMap = "set_cube_map";
        /// <summary>
        /// Cached name for the 'get_cube_map' method.
        /// </summary>
        public static readonly StringName GetCubeMap = "get_cube_map";
        /// <summary>
        /// Cached name for the 'set_texture_type' method.
        /// </summary>
        public static readonly StringName SetTextureType = "set_texture_type";
        /// <summary>
        /// Cached name for the 'get_texture_type' method.
        /// </summary>
        public static readonly StringName GetTextureType = "get_texture_type";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}
