namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A custom shader program implemented in the Godot shading language, saved with the <c>.gdshader</c> extension.</para>
/// <para>This class is used by a <see cref="Godot.ShaderMaterial"/> and allows you to write your own custom behavior for rendering visual items or updating particle information. For a detailed explanation and usage, please see the tutorials linked below.</para>
/// </summary>
public partial class Shader : Resource
{
    public enum Mode : long
    {
        /// <summary>
        /// <para>Mode used to draw all 3D objects.</para>
        /// </summary>
        Spatial = 0,
        /// <summary>
        /// <para>Mode used to draw all 2D objects.</para>
        /// </summary>
        CanvasItem = 1,
        /// <summary>
        /// <para>Mode used to calculate particle information on a per-particle basis. Not used for drawing.</para>
        /// </summary>
        Particles = 2,
        /// <summary>
        /// <para>Mode used for drawing skies. Only works with shaders attached to <see cref="Godot.Sky"/> objects.</para>
        /// </summary>
        Sky = 3,
        /// <summary>
        /// <para>Mode used for setting the color and density of volumetric fog effect.</para>
        /// </summary>
        Fog = 4
    }

    /// <summary>
    /// <para>Returns the shader's code as the user has written it, not the full generated code used internally.</para>
    /// </summary>
    public string Code
    {
        get
        {
            return GetCode();
        }
        set
        {
            SetCode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Shader);

    private static readonly StringName NativeName = "Shader";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Shader() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Shader(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Shader(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMode, 3392948163ul);

    /// <summary>
    /// <para>Returns the shader mode for the shader.</para>
    /// </summary>
    public Shader.Mode GetMode()
    {
        return (Shader.Mode)NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCode, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCode(string code)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), code);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCode, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetCode()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultTextureParameter, 3850209648ul);

    /// <summary>
    /// <para>Sets the default texture to be used with a texture uniform. The default is used if a texture is not set in the <see cref="Godot.ShaderMaterial"/>.</para>
    /// <para><b>Note:</b> <paramref name="name"/> must match the name of the uniform in the code exactly.</para>
    /// <para><b>Note:</b> If the sampler array is used use <paramref name="index"/> to access the specified texture.</para>
    /// </summary>
    public void SetDefaultTextureParameter(StringName name, Texture texture, int index = 0)
    {
        NativeCalls.godot_icall_3_1262(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(texture), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultTextureParameter, 4213877425ul);

    /// <summary>
    /// <para>Returns the texture that is set as default for the specified parameter.</para>
    /// <para><b>Note:</b> <paramref name="name"/> must match the name of the uniform in the code exactly.</para>
    /// <para><b>Note:</b> If the sampler array is used use <paramref name="index"/> to access the specified texture.</para>
    /// </summary>
    public Texture GetDefaultTextureParameter(StringName name, int index = 0)
    {
        return (Texture)NativeCalls.godot_icall_2_1263(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShaderUniformList, 1230511656ul);

    /// <summary>
    /// <para>Returns the list of shader uniforms that can be assigned to a <see cref="Godot.ShaderMaterial"/>, for use with <see cref="Godot.ShaderMaterial.SetShaderParameter(StringName, Variant)"/> and <see cref="Godot.ShaderMaterial.GetShaderParameter(StringName)"/>. The parameters returned are contained in dictionaries in a similar format to the ones returned by <see cref="Godot.GodotObject.GetPropertyList()"/>.</para>
    /// <para>If argument <paramref name="getGroups"/> is <see langword="true"/>, parameter grouping hints are also included in the list.</para>
    /// </summary>
    public Godot.Collections.Array GetShaderUniformList(bool getGroups = false)
    {
        return NativeCalls.godot_icall_1_546(MethodBind5, GodotObject.GetPtr(this), getGroups.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InspectNativeShaderCode, 3218959716ul);

    /// <summary>
    /// <para>Only available when running in the editor. Opens a popup that visualizes the generated shader code, including all variants and internal shader code. See also <see cref="Godot.Material.InspectNativeShaderCode()"/>.</para>
    /// </summary>
    public void InspectNativeShaderCode()
    {
        NativeCalls.godot_icall_0_3(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultTextureParameter, 2750740428ul);

    /// <summary>
    /// <para>Sets the default texture to be used with a texture uniform. The default is used if a texture is not set in the <see cref="Godot.ShaderMaterial"/>.</para>
    /// <para><b>Note:</b> <paramref name="name"/> must match the name of the uniform in the code exactly.</para>
    /// <para><b>Note:</b> If the sampler array is used use <paramref name="index"/> to access the specified texture.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultTextureParameter(StringName name, Texture2D texture, int index)
    {
        NativeCalls.godot_icall_3_1262(MethodBind7, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(texture), index);
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'code' property.
        /// </summary>
        public static readonly StringName Code = "code";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_mode' method.
        /// </summary>
        public static readonly StringName GetMode = "get_mode";
        /// <summary>
        /// Cached name for the 'set_code' method.
        /// </summary>
        public static readonly StringName SetCode = "set_code";
        /// <summary>
        /// Cached name for the 'get_code' method.
        /// </summary>
        public static readonly StringName GetCode = "get_code";
        /// <summary>
        /// Cached name for the 'set_default_texture_parameter' method.
        /// </summary>
        public static readonly StringName SetDefaultTextureParameter = "set_default_texture_parameter";
        /// <summary>
        /// Cached name for the 'get_default_texture_parameter' method.
        /// </summary>
        public static readonly StringName GetDefaultTextureParameter = "get_default_texture_parameter";
        /// <summary>
        /// Cached name for the 'get_shader_uniform_list' method.
        /// </summary>
        public static readonly StringName GetShaderUniformList = "get_shader_uniform_list";
        /// <summary>
        /// Cached name for the 'inspect_native_shader_code' method.
        /// </summary>
        public static readonly StringName InspectNativeShaderCode = "inspect_native_shader_code";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
