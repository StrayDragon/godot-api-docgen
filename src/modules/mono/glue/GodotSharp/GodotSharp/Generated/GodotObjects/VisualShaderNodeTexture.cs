namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Performs a lookup operation on the provided texture, with support for multiple texture sources to choose from.</para>
/// </summary>
public partial class VisualShaderNodeTexture : VisualShaderNode
{
    public enum SourceEnum : long
    {
        /// <summary>
        /// <para>Use the texture given as an argument for this function.</para>
        /// </summary>
        Texture = 0,
        /// <summary>
        /// <para>Use the current viewport's texture as the source.</para>
        /// </summary>
        Screen = 1,
        /// <summary>
        /// <para>Use the texture from this shader's texture built-in (e.g. a texture of a <see cref="Godot.Sprite2D"/>).</para>
        /// </summary>
        Source2DTexture = 2,
        /// <summary>
        /// <para>Use the texture from this shader's normal map built-in.</para>
        /// </summary>
        Source2DNormal = 3,
        /// <summary>
        /// <para>Use the depth texture captured during the depth prepass. Only available when the depth prepass is used (i.e. in spatial shaders and in the forward_plus or gl_compatibility renderers).</para>
        /// </summary>
        Depth = 4,
        /// <summary>
        /// <para>Use the texture provided in the input port for this function.</para>
        /// </summary>
        Port = 5,
        /// <summary>
        /// <para>Use the normal buffer captured during the depth prepass. Only available when the normal-roughness buffer is available (i.e. in spatial shaders and in the forward_plus renderer).</para>
        /// </summary>
        Source3DNormal = 6,
        /// <summary>
        /// <para>Use the roughness buffer captured during the depth prepass. Only available when the normal-roughness buffer is available (i.e. in spatial shaders and in the forward_plus renderer).</para>
        /// </summary>
        Roughness = 7,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeTexture.SourceEnum"/> enum.</para>
        /// </summary>
        Max = 8
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
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeTexture.TextureTypeEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>Determines the source for the lookup.</para>
    /// </summary>
    public VisualShaderNodeTexture.SourceEnum Source
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
    /// <para>The source texture, if needed for the selected <see cref="Godot.VisualShaderNodeTexture.Source"/>.</para>
    /// </summary>
    public Texture2D Texture
    {
        get
        {
            return GetTexture();
        }
        set
        {
            SetTexture(value);
        }
    }

    /// <summary>
    /// <para>Specifies the type of the texture if <see cref="Godot.VisualShaderNodeTexture.Source"/> is set to <see cref="Godot.VisualShaderNodeTexture.SourceEnum.Texture"/>.</para>
    /// </summary>
    public VisualShaderNodeTexture.TextureTypeEnum TextureType
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeTexture);

    private static readonly StringName NativeName = "VisualShaderNodeTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSource, 905262939ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSource(VisualShaderNodeTexture.SourceEnum value)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSource, 2896297444ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeTexture.SourceEnum GetSource()
    {
        return (VisualShaderNodeTexture.SourceEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexture(Texture2D value)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(value));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureType, 986314081ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureType(VisualShaderNodeTexture.TextureTypeEnum value)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureType, 3290430153ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeTexture.TextureTypeEnum GetTextureType()
    {
        return (VisualShaderNodeTexture.TextureTypeEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'texture' property.
        /// </summary>
        public static readonly StringName Texture = "texture";
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
        /// Cached name for the 'set_texture' method.
        /// </summary>
        public static readonly StringName SetTexture = "set_texture";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
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
