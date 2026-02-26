namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A cubemap is made of 6 textures organized in layers. They are typically used for faking reflections in 3D rendering (see <see cref="Godot.ReflectionProbe"/>). It can be used to make an object look as if it's reflecting its surroundings. This usually delivers much better performance than other reflection methods.</para>
/// <para>This resource is typically used as a uniform in custom shaders. Few core Godot methods make use of <see cref="Godot.Cubemap"/> resources.</para>
/// <para>To create such a texture file yourself, reimport your image files using the Godot Editor import presets. To create a Cubemap from code, use <see cref="Godot.ImageTextureLayered.CreateFromImages(Godot.Collections.Array{Image})"/> on an instance of the Cubemap class.</para>
/// <para>The expected image order is X+, X-, Y+, Y-, Z+, Z- (in Godot's coordinate system, so Y+ is "up" and Z- is "forward"). You can use one of the following templates as a base:</para>
/// <para>- <a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/tutorials/assets_pipeline/img/cubemap_template_2x3.webp">2×3 cubemap template (default layout option)</a></para>
/// <para>- <a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/tutorials/assets_pipeline/img/cubemap_template_3x2.webp">3×2 cubemap template</a></para>
/// <para>- <a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/tutorials/assets_pipeline/img/cubemap_template_1x6.webp">1×6 cubemap template</a></para>
/// <para>- <a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/tutorials/assets_pipeline/img/cubemap_template_6x1.webp">6×1 cubemap template</a></para>
/// <para><b>Note:</b> Godot doesn't support using cubemaps in a <see cref="Godot.PanoramaSkyMaterial"/>. To use a cubemap as a skybox, convert the default <see cref="Godot.PanoramaSkyMaterial"/> to a <see cref="Godot.ShaderMaterial"/> using the <b>Convert to ShaderMaterial</b> resource dropdown option, then replace its code with the following:</para>
/// <para><code>
/// shader_type sky;
/// 
/// uniform samplerCube source_panorama : filter_linear, source_color, hint_default_black;
/// uniform float exposure : hint_range(0, 128) = 1.0;
/// 
/// void sky() {
/// 	// If importing a cubemap from another engine, you may need to flip one of the `EYEDIR` components below
/// 	// by replacing it with `-EYEDIR`.
/// 	vec3 eyedir = vec3(EYEDIR.x, EYEDIR.y, EYEDIR.z);
/// 	COLOR = texture(source_panorama, eyedir).rgb * exposure;
/// }
/// </code></para>
/// <para>After replacing the shader code and saving, specify the imported Cubemap resource in the Shader Parameters section of the ShaderMaterial in the inspector.</para>
/// <para>Alternatively, you can use <a href="https://danilw.github.io/GLSL-howto/cubemap_to_panorama_js/cubemap_to_panorama.html">this tool</a> to convert a cubemap to an equirectangular sky map and use <see cref="Godot.PanoramaSkyMaterial"/> as usual.</para>
/// </summary>
public partial class Cubemap : ImageTextureLayered
{
    private static readonly System.Type CachedType = typeof(Cubemap);

    private static readonly StringName NativeName = "Cubemap";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Cubemap() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Cubemap(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Cubemap(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreatePlaceholder, 121922552ul);

    /// <summary>
    /// <para>Creates a placeholder version of this resource (<see cref="Godot.PlaceholderCubemap"/>).</para>
    /// </summary>
    public Resource CreatePlaceholder()
    {
        return (Resource)NativeCalls.godot_icall_0_63(MethodBind0, GodotObject.GetPtr(this));
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
    public new class PropertyName : ImageTextureLayered.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ImageTextureLayered.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_placeholder' method.
        /// </summary>
        public static readonly StringName CreatePlaceholder = "create_placeholder";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ImageTextureLayered.SignalName
    {
    }
}
