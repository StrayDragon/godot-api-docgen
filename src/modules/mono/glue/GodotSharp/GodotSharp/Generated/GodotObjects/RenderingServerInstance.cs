namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The rendering server is the API backend for everything visible. The whole scene system mounts on it to display. The rendering server is completely opaque: the internals are entirely implementation-specific and cannot be accessed.</para>
/// <para>The rendering server can be used to bypass the scene/<see cref="Godot.Node"/> system entirely. This can improve performance in cases where the scene system is the bottleneck, but won't improve performance otherwise (for instance, if the GPU is already fully utilized).</para>
/// <para>Resources are created using the <c>*_create</c> functions. These functions return <see cref="Godot.Rid"/>s which are not references to the objects themselves, but opaque <i>pointers</i> towards these objects.</para>
/// <para>All objects are drawn to a viewport. You can use the <see cref="Godot.Viewport"/> attached to the <see cref="Godot.SceneTree"/> or you can create one yourself with <see cref="Godot.RenderingServerInstance.ViewportCreate()"/>. When using a custom scenario or canvas, the scenario or canvas needs to be attached to the viewport using <see cref="Godot.RenderingServerInstance.ViewportSetScenario(Rid, Rid)"/> or <see cref="Godot.RenderingServerInstance.ViewportAttachCanvas(Rid, Rid)"/>.</para>
/// <para><b>Scenarios:</b> In 3D, all visual objects must be associated with a scenario. The scenario is a visual representation of the world. If accessing the rendering server from a running game, the scenario can be accessed from the scene tree from any <see cref="Godot.Node3D"/> node with <see cref="Godot.Node3D.GetWorld3D()"/>. Otherwise, a scenario can be created with <see cref="Godot.RenderingServerInstance.ScenarioCreate()"/>.</para>
/// <para>Similarly, in 2D, a canvas is needed to draw all canvas items.</para>
/// <para><b>3D:</b> In 3D, all visible objects are comprised of a resource and an instance. A resource can be a mesh, a particle system, a light, or any other 3D object. In order to be visible resources must be attached to an instance using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/>. The instance must also be attached to the scenario using <see cref="Godot.RenderingServerInstance.InstanceSetScenario(Rid, Rid)"/> in order to be visible. RenderingServer methods that don't have a prefix are usually 3D-specific (but not always).</para>
/// <para><b>2D:</b> In 2D, all visible objects are some form of canvas item. In order to be visible, a canvas item needs to be the child of a canvas attached to a viewport, or it needs to be the child of another canvas item that is eventually attached to the canvas. 2D-specific RenderingServer methods generally start with <c>canvas_*</c>.</para>
/// <para><b>Headless mode:</b> Starting the engine with the <c>--headless</c> <a href="$DOCS_URL/tutorials/editor/command_line_tutorial.html">command line argument</a> disables all rendering and window management functions. Most functions from <see cref="Godot.RenderingServer"/> will return dummy values in this case.</para>
/// </summary>
[GodotClassName("RenderingServer")]
public partial class RenderingServerInstance : GodotObject
{
    /// <summary>
    /// <para>If <see langword="false"/>, disables rendering completely, but the engine logic is still being processed. You can call <see cref="Godot.RenderingServerInstance.ForceDraw(bool, double)"/> to draw a frame even with rendering disabled.</para>
    /// </summary>
    public bool RenderLoopEnabled
    {
        get
        {
            return IsRenderLoopEnabled();
        }
        set
        {
            SetRenderLoopEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RenderingServerInstance);

    private static readonly StringName NativeName = "RenderingServer";

    internal RenderingServerInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RenderingServerInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RenderingServerInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DCreate, 2010018390ul);

    /// <summary>
    /// <para>Creates a 2-dimensional texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>texture_2d_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Texture2D"/>.</para>
    /// <para><b>Note:</b> Not to be confused with <see cref="Godot.RenderingDevice.TextureCreate(RDTextureFormat, RDTextureView, Godot.Collections.Array{byte[]})"/>, which creates the graphics API's own texture type as opposed to the Godot-specific <see cref="Godot.Texture2D"/> resource.</para>
    /// </summary>
    public Rid Texture2DCreate(Image image)
    {
        return NativeCalls.godot_icall_1_1067(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(image));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DLayeredCreate, 913689023ul);

    /// <summary>
    /// <para>Creates a 2-dimensional layered texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>texture_2d_layered_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.TextureLayered"/>.</para>
    /// </summary>
    public Rid Texture2DLayeredCreate(Godot.Collections.Array<Image> layers, RenderingServer.TextureLayeredType layeredType)
    {
        return NativeCalls.godot_icall_2_1118(MethodBind1, GodotObject.GetPtr(this), (godot_array)(layers ?? new()).NativeValue, (int)layeredType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture3DCreate, 4036838706ul);

    /// <summary>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Texture3D"/>.</para>
    /// </summary>
    public Rid Texture3DCreate(Image.Format format, int width, int height, int depth, bool mipmaps, Godot.Collections.Array<Image> data)
    {
        return NativeCalls.godot_icall_6_1119(MethodBind2, GodotObject.GetPtr(this), (int)format, width, height, depth, mipmaps.ToGodotBool(), (godot_array)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureProxyCreate, 41030802ul);

    /// <summary>
    /// <para>This method does nothing and always returns an invalid <see cref="Godot.Rid"/>.</para>
    /// </summary>
    [Obsolete("ProxyTexture was removed in Godot 4.")]
    public Rid TextureProxyCreate(Rid @base)
    {
        return NativeCalls.godot_icall_1_855(MethodBind3, GodotObject.GetPtr(this), @base);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureCreateFromNativeHandle, 1682977582ul);

    /// <summary>
    /// <para>Creates a texture based on a native handle that was created outside of Godot's renderer.</para>
    /// <para><b>Note:</b> If using only the rendering device renderer, it's recommend to use <see cref="Godot.RenderingDevice.TextureCreateFromExtension(RenderingDevice.TextureType, RenderingDevice.DataFormat, RenderingDevice.TextureSamples, RenderingDevice.TextureUsageBits, ulong, ulong, ulong, ulong, ulong, ulong)"/> together with <see cref="Godot.RenderingServer.TextureRdCreate(Rid, RenderingServer.TextureLayeredType)"/>, rather than this method. This way, the texture's format and usage can be controlled more effectively.</para>
    /// </summary>
    public Rid TextureCreateFromNativeHandle(RenderingServer.TextureType type, Image.Format format, ulong nativeHandle, int width, int height, int depth, int layers = 1, RenderingServer.TextureLayeredType layeredType = (RenderingServer.TextureLayeredType)(0))
    {
        return NativeCalls.godot_icall_8_1120(MethodBind4, GodotObject.GetPtr(this), (int)type, (int)format, nativeHandle, width, height, depth, layers, (int)layeredType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DUpdate, 999539803ul);

    /// <summary>
    /// <para>Updates the texture specified by the <paramref name="texture"/> <see cref="Godot.Rid"/> with the data in <paramref name="image"/>. A <paramref name="layer"/> must also be specified, which should be <c>0</c> when updating a single-layer texture (<see cref="Godot.Texture2D"/>).</para>
    /// <para><b>Note:</b> The <paramref name="image"/> must have the same width, height and format as the current <paramref name="texture"/> data. Otherwise, an error will be printed and the original texture won't be modified. If you need to use different width, height or format, use <see cref="Godot.RenderingServerInstance.TextureReplace(Rid, Rid)"/> instead.</para>
    /// </summary>
    public void Texture2DUpdate(Rid texture, Image image, int layer)
    {
        NativeCalls.godot_icall_3_1121(MethodBind5, GodotObject.GetPtr(this), texture, GodotObject.GetPtr(image), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture3DUpdate, 684822712ul);

    /// <summary>
    /// <para>Updates the texture specified by the <paramref name="texture"/> <see cref="Godot.Rid"/>'s data with the data in <paramref name="data"/>. All the texture's layers must be replaced at once.</para>
    /// <para><b>Note:</b> The <paramref name="texture"/> must have the same width, height, depth and format as the current texture data. Otherwise, an error will be printed and the original texture won't be modified. If you need to use different width, height, depth or format, use <see cref="Godot.RenderingServerInstance.TextureReplace(Rid, Rid)"/> instead.</para>
    /// </summary>
    public void Texture3DUpdate(Rid texture, Godot.Collections.Array<Image> data)
    {
        NativeCalls.godot_icall_2_1122(MethodBind6, GodotObject.GetPtr(this), texture, (godot_array)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureProxyUpdate, 395945892ul);

    /// <summary>
    /// <para>This method does nothing.</para>
    /// </summary>
    [Obsolete("ProxyTexture was removed in Godot 4.")]
    public void TextureProxyUpdate(Rid texture, Rid proxyTo)
    {
        NativeCalls.godot_icall_2_430(MethodBind7, GodotObject.GetPtr(this), texture, proxyTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DPlaceholderCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a placeholder for a 2-dimensional layered texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>texture_2d_layered_*</c> RenderingServer functions, although it does nothing when used. See also <see cref="Godot.RenderingServerInstance.Texture2DLayeredPlaceholderCreate(RenderingServer.TextureLayeredType)"/>.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.PlaceholderTexture2D"/>.</para>
    /// </summary>
    public Rid Texture2DPlaceholderCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DLayeredPlaceholderCreate, 1394585590ul);

    /// <summary>
    /// <para>Creates a placeholder for a 2-dimensional layered texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>texture_2d_layered_*</c> RenderingServer functions, although it does nothing when used. See also <see cref="Godot.RenderingServerInstance.Texture2DPlaceholderCreate()"/>.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.PlaceholderTextureLayered"/>.</para>
    /// </summary>
    public Rid Texture2DLayeredPlaceholderCreate(RenderingServer.TextureLayeredType layeredType)
    {
        return NativeCalls.godot_icall_1_425(MethodBind9, GodotObject.GetPtr(this), (int)layeredType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture3DPlaceholderCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a placeholder for a 3-dimensional texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>texture_3d_*</c> RenderingServer functions, although it does nothing when used.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.PlaceholderTexture3D"/>.</para>
    /// </summary>
    public Rid Texture3DPlaceholderCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DGet, 4206205781ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Image"/> instance from the given <paramref name="texture"/> <see cref="Godot.Rid"/>.</para>
    /// <para><b>Example:</b> Get the test texture from <see cref="Godot.RenderingServerInstance.GetTestTexture()"/> and apply it to a <see cref="Godot.Sprite2D"/> node:</para>
    /// <para><code>
    /// var texture_rid = RenderingServer.get_test_texture()
    /// var texture = ImageTexture.create_from_image(RenderingServer.texture_2d_get(texture_rid))
    /// $Sprite2D.texture = texture
    /// </code></para>
    /// </summary>
    public Image Texture2DGet(Rid texture)
    {
        return (Image)NativeCalls.godot_icall_1_1059(MethodBind11, GodotObject.GetPtr(this), texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DLayerGet, 2705440895ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Image"/> instance from the given <paramref name="texture"/> <see cref="Godot.Rid"/> and <paramref name="layer"/>.</para>
    /// </summary>
    public Image Texture2DLayerGet(Rid texture, int layer)
    {
        return (Image)NativeCalls.godot_icall_2_831(MethodBind12, GodotObject.GetPtr(this), texture, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture3DGet, 2684255073ul);

    /// <summary>
    /// <para>Returns 3D texture data as an array of <see cref="Godot.Image"/>s for the specified texture <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Image> Texture3DGet(Rid texture)
    {
        return new Godot.Collections.Array<Image>(NativeCalls.godot_icall_1_849(MethodBind13, GodotObject.GetPtr(this), texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureReplace, 395945892ul);

    /// <summary>
    /// <para>Replaces <paramref name="texture"/>'s texture data by the texture specified by the <paramref name="byTexture"/> RID, without changing <paramref name="texture"/>'s RID.</para>
    /// </summary>
    public void TextureReplace(Rid texture, Rid byTexture)
    {
        NativeCalls.godot_icall_2_430(MethodBind14, GodotObject.GetPtr(this), texture, byTexture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureSetSizeOverride, 4288446313ul);

    public void TextureSetSizeOverride(Rid texture, int width, int height)
    {
        NativeCalls.godot_icall_3_433(MethodBind15, GodotObject.GetPtr(this), texture, width, height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureSetPath, 2726140452ul);

    public void TextureSetPath(Rid texture, string path)
    {
        NativeCalls.godot_icall_2_427(MethodBind16, GodotObject.GetPtr(this), texture, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureGetPath, 642473191ul);

    public string TextureGetPath(Rid texture)
    {
        return NativeCalls.godot_icall_1_940(MethodBind17, GodotObject.GetPtr(this), texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureGetFormat, 1932918979ul);

    /// <summary>
    /// <para>Returns the format for the texture.</para>
    /// </summary>
    public Image.Format TextureGetFormat(Rid texture)
    {
        return (Image.Format)NativeCalls.godot_icall_1_835(MethodBind18, GodotObject.GetPtr(this), texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureSetForceRedrawIfVisible, 1265174801ul);

    public void TextureSetForceRedrawIfVisible(Rid texture, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind19, GodotObject.GetPtr(this), texture, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureRdCreate, 1434128712ul);

    /// <summary>
    /// <para>Creates a new texture object based on a texture created directly on the <see cref="Godot.RenderingDevice"/>. If the texture contains layers, <paramref name="layerType"/> is used to define the layer type.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> won't free the underlying <paramref name="rdTexture"/>, you will want to free the <paramref name="rdTexture"/> using <see cref="Godot.RenderingDevice.FreeRid(Rid)"/>.</para>
    /// </summary>
    public Rid TextureRdCreate(Rid rdTexture, RenderingServer.TextureLayeredType layerType = (RenderingServer.TextureLayeredType)(0))
    {
        return NativeCalls.godot_icall_2_830(MethodBind20, GodotObject.GetPtr(this), rdTexture, (int)layerType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureGetRdTexture, 2790148051ul);

    /// <summary>
    /// <para>Returns a texture <see cref="Godot.Rid"/> that can be used with <see cref="Godot.RenderingDevice"/>.</para>
    /// <para><paramref name="srgb"/> should be <see langword="true"/> when the texture uses nonlinear sRGB encoding and <see langword="false"/> when the texture uses linear encoding.</para>
    /// </summary>
    public Rid TextureGetRdTexture(Rid texture, bool srgb = false)
    {
        return NativeCalls.godot_icall_2_1123(MethodBind21, GodotObject.GetPtr(this), texture, srgb.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureGetNativeHandle, 1834114100ul);

    /// <summary>
    /// <para>Returns the internal graphics handle for this texture object. For use when communicating with third-party APIs mostly with GDExtension.</para>
    /// <para><paramref name="srgb"/> should be <see langword="true"/> when the texture uses nonlinear sRGB encoding and <see langword="false"/> when the texture uses linear encoding.</para>
    /// <para><b>Note:</b> This function returns a <c>uint64_t</c> which internally maps to a <c>GLuint</c> (OpenGL) or <c>VkImage</c> (Vulkan).</para>
    /// </summary>
    public ulong TextureGetNativeHandle(Rid texture, bool srgb = false)
    {
        return NativeCalls.godot_icall_2_1124(MethodBind22, GodotObject.GetPtr(this), texture, srgb.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an empty shader and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>shader_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Shader"/>.</para>
    /// </summary>
    public Rid ShaderCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderSetCode, 2726140452ul);

    /// <summary>
    /// <para>Sets the shader's source code (which triggers recompilation after being changed).</para>
    /// </summary>
    public void ShaderSetCode(Rid shader, string code)
    {
        NativeCalls.godot_icall_2_427(MethodBind24, GodotObject.GetPtr(this), shader, code);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderSetPathHint, 2726140452ul);

    /// <summary>
    /// <para>Sets the path hint for the specified shader. This should generally match the <see cref="Godot.Shader"/> resource's <see cref="Godot.Resource.ResourcePath"/>.</para>
    /// </summary>
    public void ShaderSetPathHint(Rid shader, string path)
    {
        NativeCalls.godot_icall_2_427(MethodBind25, GodotObject.GetPtr(this), shader, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderGetCode, 642473191ul);

    /// <summary>
    /// <para>Returns a shader's source code as a string.</para>
    /// </summary>
    public string ShaderGetCode(Rid shader)
    {
        return NativeCalls.godot_icall_1_940(MethodBind26, GodotObject.GetPtr(this), shader);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShaderParameterList, 2684255073ul);

    /// <summary>
    /// <para>Returns the parameters of a shader.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetShaderParameterList(Rid shader)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_849(MethodBind27, GodotObject.GetPtr(this), shader));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderGetParameterDefault, 2621281810ul);

    /// <summary>
    /// <para>Returns the default value for the specified shader uniform. This is usually the value written in the shader source code.</para>
    /// </summary>
    public Variant ShaderGetParameterDefault(Rid shader, StringName name)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind28, GodotObject.GetPtr(this), shader, (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderSetDefaultTextureParameter, 4094001817ul);

    /// <summary>
    /// <para>Sets a shader's default texture. Overwrites the texture given by name.</para>
    /// <para><b>Note:</b> If the sampler array is used use <paramref name="index"/> to access the specified texture.</para>
    /// </summary>
    public void ShaderSetDefaultTextureParameter(Rid shader, StringName name, Rid texture, int index = 0)
    {
        NativeCalls.godot_icall_4_1126(MethodBind29, GodotObject.GetPtr(this), shader, (godot_string_name)(name?.NativeValue ?? default), texture, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderGetDefaultTextureParameter, 1464608890ul);

    /// <summary>
    /// <para>Returns a default texture from a shader searched by name.</para>
    /// <para><b>Note:</b> If the sampler array is used use <paramref name="index"/> to access the specified texture.</para>
    /// </summary>
    public Rid ShaderGetDefaultTextureParameter(Rid shader, StringName name, int index = 0)
    {
        return NativeCalls.godot_icall_3_1127(MethodBind30, GodotObject.GetPtr(this), shader, (godot_string_name)(name?.NativeValue ?? default), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an empty material and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>material_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Material"/>.</para>
    /// </summary>
    public Rid MaterialCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialSetShader, 395945892ul);

    /// <summary>
    /// <para>Sets a shader material's shader.</para>
    /// </summary>
    public void MaterialSetShader(Rid shaderMaterial, Rid shader)
    {
        NativeCalls.godot_icall_2_430(MethodBind32, GodotObject.GetPtr(this), shaderMaterial, shader);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialSetParam, 3477296213ul);

    /// <summary>
    /// <para>Sets a material's parameter.</para>
    /// </summary>
    public void MaterialSetParam(Rid material, StringName parameter, Variant value)
    {
        NativeCalls.godot_icall_3_1128(MethodBind33, GodotObject.GetPtr(this), material, (godot_string_name)(parameter?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialGetParam, 2621281810ul);

    /// <summary>
    /// <para>Returns the value of a certain material's parameter.</para>
    /// </summary>
    public Variant MaterialGetParam(Rid material, StringName parameter)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind34, GodotObject.GetPtr(this), material, (godot_string_name)(parameter?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialSetRenderPriority, 3411492887ul);

    /// <summary>
    /// <para>Sets a material's render priority.</para>
    /// </summary>
    public void MaterialSetRenderPriority(Rid material, int priority)
    {
        NativeCalls.godot_icall_2_426(MethodBind35, GodotObject.GetPtr(this), material, priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialSetNextPass, 395945892ul);

    /// <summary>
    /// <para>Sets an object's next material.</para>
    /// </summary>
    public void MaterialSetNextPass(Rid material, Rid nextMaterial)
    {
        NativeCalls.godot_icall_2_430(MethodBind36, GodotObject.GetPtr(this), material, nextMaterial);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialSetUseDebanding, 2586408642ul);

    /// <summary>
    /// <para>When using the Mobile renderer, <see cref="Godot.RenderingServerInstance.MaterialSetUseDebanding(bool)"/> can be used to enable or disable the debanding feature of 3D materials (<see cref="Godot.BaseMaterial3D"/> and <see cref="Godot.ShaderMaterial"/>).</para>
    /// <para><see cref="Godot.RenderingServerInstance.MaterialSetUseDebanding(bool)"/> has no effect when using the Compatibility or Forward+ renderer. In Forward+, <see cref="Godot.Viewport"/> debanding can be used instead.</para>
    /// <para>See also <c>ProjectSettings.rendering/anti_aliasing/quality/use_debanding</c> and <see cref="Godot.RenderingServer.ViewportSetUseDebanding(Rid, bool)"/>.</para>
    /// </summary>
    public void MaterialSetUseDebanding(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind37, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshCreateFromSurfaces, 4291747531ul);

    public Rid MeshCreateFromSurfaces(Godot.Collections.Array<Godot.Collections.Dictionary> surfaces, int blendShapeCount = 0)
    {
        return NativeCalls.godot_icall_2_1118(MethodBind38, GodotObject.GetPtr(this), (godot_array)(surfaces ?? new()).NativeValue, blendShapeCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new mesh and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>mesh_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this mesh to an instance using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public Rid MeshCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatOffset, 2981368685ul);

    /// <summary>
    /// <para>Returns the offset of a given attribute by <paramref name="arrayIndex"/> in the start of its respective buffer.</para>
    /// </summary>
    public uint MeshSurfaceGetFormatOffset(RenderingServer.ArrayFormat format, int vertexCount, int arrayIndex)
    {
        return NativeCalls.godot_icall_3_1129(MethodBind40, GodotObject.GetPtr(this), (int)format, vertexCount, arrayIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatVertexStride, 3188363337ul);

    /// <summary>
    /// <para>Returns the stride of the vertex positions for a mesh with given <paramref name="format"/>. Note importantly that vertex positions are stored consecutively and are not interleaved with the other attributes in the vertex buffer (normals and tangents).</para>
    /// </summary>
    public uint MeshSurfaceGetFormatVertexStride(RenderingServer.ArrayFormat format, int vertexCount)
    {
        return NativeCalls.godot_icall_2_1130(MethodBind41, GodotObject.GetPtr(this), (int)format, vertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatNormalTangentStride, 3188363337ul);

    /// <summary>
    /// <para>Returns the stride of the combined normals and tangents for a mesh with given <paramref name="format"/>. Note importantly that, while normals and tangents are in the vertex buffer with vertices, they are only interleaved with each other and so have a different stride than vertex positions.</para>
    /// </summary>
    public uint MeshSurfaceGetFormatNormalTangentStride(RenderingServer.ArrayFormat format, int vertexCount)
    {
        return NativeCalls.godot_icall_2_1130(MethodBind42, GodotObject.GetPtr(this), (int)format, vertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatAttributeStride, 3188363337ul);

    /// <summary>
    /// <para>Returns the stride of the attribute buffer for a mesh with given <paramref name="format"/>.</para>
    /// </summary>
    public uint MeshSurfaceGetFormatAttributeStride(RenderingServer.ArrayFormat format, int vertexCount)
    {
        return NativeCalls.godot_icall_2_1130(MethodBind43, GodotObject.GetPtr(this), (int)format, vertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatSkinStride, 3188363337ul);

    /// <summary>
    /// <para>Returns the stride of the skin buffer for a mesh with given <paramref name="format"/>.</para>
    /// </summary>
    public uint MeshSurfaceGetFormatSkinStride(RenderingServer.ArrayFormat format, int vertexCount)
    {
        return NativeCalls.godot_icall_2_1130(MethodBind44, GodotObject.GetPtr(this), (int)format, vertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatIndexStride, 3188363337ul);

    /// <summary>
    /// <para>Returns the stride of the index buffer for a mesh with the given <paramref name="format"/>.</para>
    /// </summary>
    public uint MeshSurfaceGetFormatIndexStride(RenderingServer.ArrayFormat format, int vertexCount)
    {
        return NativeCalls.godot_icall_2_1130(MethodBind45, GodotObject.GetPtr(this), (int)format, vertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshAddSurface, 1217542888ul);

    public void MeshAddSurface(Rid mesh, Godot.Collections.Dictionary surface)
    {
        NativeCalls.godot_icall_2_1131(MethodBind46, GodotObject.GetPtr(this), mesh, (godot_dictionary)(surface ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshAddSurfaceFromArrays, 2342446560ul);

    public void MeshAddSurfaceFromArrays(Rid mesh, RenderingServer.PrimitiveType primitive, Godot.Collections.Array arrays, Godot.Collections.Array blendShapes = null, Godot.Collections.Dictionary lods = null, RenderingServer.ArrayFormat compressFormat = (RenderingServer.ArrayFormat)(0))
    {
        NativeCalls.godot_icall_6_1132(MethodBind47, GodotObject.GetPtr(this), mesh, (int)primitive, (godot_array)(arrays ?? new()).NativeValue, (godot_array)(blendShapes ?? new()).NativeValue, (godot_dictionary)(lods ?? new()).NativeValue, (int)compressFormat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshGetBlendShapeCount, 2198884583ul);

    /// <summary>
    /// <para>Returns a mesh's blend shape count.</para>
    /// </summary>
    public int MeshGetBlendShapeCount(Rid mesh)
    {
        return NativeCalls.godot_icall_1_835(MethodBind48, GodotObject.GetPtr(this), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSetBlendShapeMode, 1294662092ul);

    /// <summary>
    /// <para>Sets a mesh's blend shape mode.</para>
    /// </summary>
    public void MeshSetBlendShapeMode(Rid mesh, RenderingServer.BlendShapeMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind49, GodotObject.GetPtr(this), mesh, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshGetBlendShapeMode, 4282291819ul);

    /// <summary>
    /// <para>Returns a mesh's blend shape mode.</para>
    /// </summary>
    public RenderingServer.BlendShapeMode MeshGetBlendShapeMode(Rid mesh)
    {
        return (RenderingServer.BlendShapeMode)NativeCalls.godot_icall_1_835(MethodBind50, GodotObject.GetPtr(this), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceSetMaterial, 2310537182ul);

    /// <summary>
    /// <para>Sets a mesh's surface's material.</para>
    /// </summary>
    public void MeshSurfaceSetMaterial(Rid mesh, int surface, Rid material)
    {
        NativeCalls.godot_icall_3_833(MethodBind51, GodotObject.GetPtr(this), mesh, surface, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetMaterial, 1066463050ul);

    /// <summary>
    /// <para>Returns a mesh's surface's material.</para>
    /// </summary>
    public Rid MeshSurfaceGetMaterial(Rid mesh, int surface)
    {
        return NativeCalls.godot_icall_2_830(MethodBind52, GodotObject.GetPtr(this), mesh, surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshGetSurface, 186674697ul);

    public Godot.Collections.Dictionary MeshGetSurface(Rid mesh, int surface)
    {
        return NativeCalls.godot_icall_2_1133(MethodBind53, GodotObject.GetPtr(this), mesh, surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetArrays, 1778388067ul);

    /// <summary>
    /// <para>Returns a mesh's surface's buffer arrays.</para>
    /// </summary>
    public Godot.Collections.Array MeshSurfaceGetArrays(Rid mesh, int surface)
    {
        return NativeCalls.godot_icall_2_1134(MethodBind54, GodotObject.GetPtr(this), mesh, surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetBlendShapeArrays, 1778388067ul);

    /// <summary>
    /// <para>Returns a mesh's surface's arrays for blend shapes.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Array> MeshSurfaceGetBlendShapeArrays(Rid mesh, int surface)
    {
        return new Godot.Collections.Array<Godot.Collections.Array>(NativeCalls.godot_icall_2_1134(MethodBind55, GodotObject.GetPtr(this), mesh, surface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshGetSurfaceCount, 2198884583ul);

    /// <summary>
    /// <para>Returns a mesh's number of surfaces.</para>
    /// </summary>
    public int MeshGetSurfaceCount(Rid mesh)
    {
        return NativeCalls.godot_icall_1_835(MethodBind56, GodotObject.GetPtr(this), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSetCustomAabb, 3696536120ul);

    /// <summary>
    /// <para>Sets a mesh's custom aabb.</para>
    /// </summary>
    public unsafe void MeshSetCustomAabb(Rid mesh, Aabb aabb)
    {
        NativeCalls.godot_icall_2_1135(MethodBind57, GodotObject.GetPtr(this), mesh, &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshGetCustomAabb, 974181306ul);

    /// <summary>
    /// <para>Returns a mesh's custom aabb.</para>
    /// </summary>
    public Aabb MeshGetCustomAabb(Rid mesh)
    {
        return NativeCalls.godot_icall_1_876(MethodBind58, GodotObject.GetPtr(this), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceRemove, 3411492887ul);

    /// <summary>
    /// <para>Removes the surface at the given index from the Mesh, shifting surfaces with higher index down by one.</para>
    /// </summary>
    public void MeshSurfaceRemove(Rid mesh, int surface)
    {
        NativeCalls.godot_icall_2_426(MethodBind59, GodotObject.GetPtr(this), mesh, surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshClear, 2722037293ul);

    /// <summary>
    /// <para>Removes all surfaces from a mesh.</para>
    /// </summary>
    public void MeshClear(Rid mesh)
    {
        NativeCalls.godot_icall_1_286(MethodBind60, GodotObject.GetPtr(this), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceUpdateVertexRegion, 2900195149ul);

    public void MeshSurfaceUpdateVertexRegion(Rid mesh, int surface, int offset, byte[] data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind61, GodotObject.GetPtr(this), mesh, surface, offset, data);
    }

    public void MeshSurfaceUpdateVertexRegion(Rid mesh, int surface, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind61, GodotObject.GetPtr(this), mesh, surface, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceUpdateAttributeRegion, 2900195149ul);

    public void MeshSurfaceUpdateAttributeRegion(Rid mesh, int surface, int offset, byte[] data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind62, GodotObject.GetPtr(this), mesh, surface, offset, data);
    }

    public void MeshSurfaceUpdateAttributeRegion(Rid mesh, int surface, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind62, GodotObject.GetPtr(this), mesh, surface, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceUpdateSkinRegion, 2900195149ul);

    public void MeshSurfaceUpdateSkinRegion(Rid mesh, int surface, int offset, byte[] data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind63, GodotObject.GetPtr(this), mesh, surface, offset, data);
    }

    public void MeshSurfaceUpdateSkinRegion(Rid mesh, int surface, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind63, GodotObject.GetPtr(this), mesh, surface, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceUpdateIndexRegion, 2900195149ul);

    /// <summary>
    /// <para>Updates the index buffer of the mesh surface with the given <paramref name="data"/>. The expected data are 16 or 32-bit unsigned integers, which can be determined with <see cref="Godot.RenderingServerInstance.MeshSurfaceGetFormatIndexStride(RenderingServer.ArrayFormat, int)"/>.</para>
    /// </summary>
    public void MeshSurfaceUpdateIndexRegion(Rid mesh, int surface, int offset, byte[] data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind64, GodotObject.GetPtr(this), mesh, surface, offset, data);
    }

    /// <summary>
    /// <para>Updates the index buffer of the mesh surface with the given <paramref name="data"/>. The expected data are 16 or 32-bit unsigned integers, which can be determined with <see cref="Godot.RenderingServerInstance.MeshSurfaceGetFormatIndexStride(RenderingServer.ArrayFormat, int)"/>.</para>
    /// </summary>
    public void MeshSurfaceUpdateIndexRegion(Rid mesh, int surface, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind64, GodotObject.GetPtr(this), mesh, surface, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSetShadowMesh, 395945892ul);

    public void MeshSetShadowMesh(Rid mesh, Rid shadowMesh)
    {
        NativeCalls.godot_icall_2_430(MethodBind65, GodotObject.GetPtr(this), mesh, shadowMesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new multimesh on the RenderingServer and returns an <see cref="Godot.Rid"/> handle. This RID will be used in all <c>multimesh_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this multimesh to an instance using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.MultiMesh"/>.</para>
    /// </summary>
    public Rid MultimeshCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind66, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshAllocateData, 557240154ul);

    public void MultimeshAllocateData(Rid multimesh, int instances, RenderingServer.MultimeshTransformFormat transformFormat, bool colorFormat = false, bool customDataFormat = false, bool useIndirect = false)
    {
        NativeCalls.godot_icall_6_1137(MethodBind67, GodotObject.GetPtr(this), multimesh, instances, (int)transformFormat, colorFormat.ToGodotBool(), customDataFormat.ToGodotBool(), useIndirect.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetInstanceCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of instances allocated for this multimesh.</para>
    /// </summary>
    public int MultimeshGetInstanceCount(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_835(MethodBind68, GodotObject.GetPtr(this), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetMesh, 395945892ul);

    /// <summary>
    /// <para>Sets the mesh to be drawn by the multimesh. Equivalent to <see cref="Godot.MultiMesh.Mesh"/>.</para>
    /// </summary>
    public void MultimeshSetMesh(Rid multimesh, Rid mesh)
    {
        NativeCalls.godot_icall_2_430(MethodBind69, GodotObject.GetPtr(this), multimesh, mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceSetTransform, 675327471ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform3D"/> for this instance. Equivalent to <see cref="Godot.MultiMesh.SetInstanceTransform(int, Transform3D)"/>.</para>
    /// </summary>
    public unsafe void MultimeshInstanceSetTransform(Rid multimesh, int index, Transform3D transform)
    {
        NativeCalls.godot_icall_3_1001(MethodBind70, GodotObject.GetPtr(this), multimesh, index, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceSetTransform2D, 736082694ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform2D"/> for this instance. For use when multimesh is used in 2D. Equivalent to <see cref="Godot.MultiMesh.SetInstanceTransform2D(int, Transform2D)"/>.</para>
    /// </summary>
    public unsafe void MultimeshInstanceSetTransform2D(Rid multimesh, int index, Transform2D transform)
    {
        NativeCalls.godot_icall_3_991(MethodBind71, GodotObject.GetPtr(this), multimesh, index, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceSetColor, 176975443ul);

    /// <summary>
    /// <para>Sets the color by which this instance will be modulated. Equivalent to <see cref="Godot.MultiMesh.SetInstanceColor(int, Color)"/>.</para>
    /// </summary>
    public unsafe void MultimeshInstanceSetColor(Rid multimesh, int index, Color color)
    {
        NativeCalls.godot_icall_3_1138(MethodBind72, GodotObject.GetPtr(this), multimesh, index, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceSetCustomData, 176975443ul);

    /// <summary>
    /// <para>Sets the custom data for this instance. Custom data is passed as a <see cref="Godot.Color"/>, but is interpreted as a <c>vec4</c> in the shader. Equivalent to <see cref="Godot.MultiMesh.SetInstanceCustomData(int, Color)"/>.</para>
    /// </summary>
    public unsafe void MultimeshInstanceSetCustomData(Rid multimesh, int index, Color customData)
    {
        NativeCalls.godot_icall_3_1138(MethodBind73, GodotObject.GetPtr(this), multimesh, index, &customData);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetMesh, 3814569979ul);

    /// <summary>
    /// <para>Returns the RID of the mesh that will be used in drawing this multimesh.</para>
    /// </summary>
    public Rid MultimeshGetMesh(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_855(MethodBind74, GodotObject.GetPtr(this), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetAabb, 974181306ul);

    /// <summary>
    /// <para>Calculates and returns the axis-aligned bounding box that encloses all instances within the multimesh.</para>
    /// </summary>
    public Aabb MultimeshGetAabb(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_876(MethodBind75, GodotObject.GetPtr(this), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetCustomAabb, 3696536120ul);

    /// <summary>
    /// <para>Sets the custom AABB for this MultiMesh resource.</para>
    /// </summary>
    public unsafe void MultimeshSetCustomAabb(Rid multimesh, Aabb aabb)
    {
        NativeCalls.godot_icall_2_1135(MethodBind76, GodotObject.GetPtr(this), multimesh, &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetCustomAabb, 974181306ul);

    /// <summary>
    /// <para>Returns the custom AABB defined for this MultiMesh resource.</para>
    /// </summary>
    public Aabb MultimeshGetCustomAabb(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_876(MethodBind77, GodotObject.GetPtr(this), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceGetTransform, 1050775521ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform3D"/> of the specified instance.</para>
    /// </summary>
    public Transform3D MultimeshInstanceGetTransform(Rid multimesh, int index)
    {
        return NativeCalls.godot_icall_2_1002(MethodBind78, GodotObject.GetPtr(this), multimesh, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceGetTransform2D, 1324854622ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform2D"/> of the specified instance. For use when the multimesh is set to use 2D transforms.</para>
    /// </summary>
    public Transform2D MultimeshInstanceGetTransform2D(Rid multimesh, int index)
    {
        return NativeCalls.godot_icall_2_992(MethodBind79, GodotObject.GetPtr(this), multimesh, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceGetColor, 2946315076ul);

    /// <summary>
    /// <para>Returns the color by which the specified instance will be modulated.</para>
    /// </summary>
    public Color MultimeshInstanceGetColor(Rid multimesh, int index)
    {
        return NativeCalls.godot_icall_2_1139(MethodBind80, GodotObject.GetPtr(this), multimesh, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceGetCustomData, 2946315076ul);

    /// <summary>
    /// <para>Returns the custom data associated with the specified instance.</para>
    /// </summary>
    public Color MultimeshInstanceGetCustomData(Rid multimesh, int index)
    {
        return NativeCalls.godot_icall_2_1139(MethodBind81, GodotObject.GetPtr(this), multimesh, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetVisibleInstances, 3411492887ul);

    /// <summary>
    /// <para>Sets the number of instances visible at a given time. If -1, all instances that have been allocated are drawn. Equivalent to <see cref="Godot.MultiMesh.VisibleInstanceCount"/>.</para>
    /// </summary>
    public void MultimeshSetVisibleInstances(Rid multimesh, int visible)
    {
        NativeCalls.godot_icall_2_426(MethodBind82, GodotObject.GetPtr(this), multimesh, visible);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetVisibleInstances, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of visible instances for this multimesh.</para>
    /// </summary>
    public int MultimeshGetVisibleInstances(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_835(MethodBind83, GodotObject.GetPtr(this), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetBuffer, 2960552364ul);

    /// <summary>
    /// <para>Set the entire data to use for drawing the <paramref name="multimesh"/> at once to <paramref name="buffer"/> (such as instance transforms and colors). <paramref name="buffer"/>'s size must match the number of instances multiplied by the per-instance data size (which depends on the enabled MultiMesh fields). Otherwise, an error message is printed and nothing is rendered. See also <see cref="Godot.RenderingServerInstance.MultimeshGetBuffer(Rid)"/>.</para>
    /// <para>The per-instance data size and expected data order is:</para>
    /// <para><code>
    /// 2D:
    ///   - Position: 8 floats (8 floats for Transform2D)
    ///   - Position + Vertex color: 12 floats (8 floats for Transform2D, 4 floats for Color)
    ///   - Position + Custom data: 12 floats (8 floats for Transform2D, 4 floats of custom data)
    ///   - Position + Vertex color + Custom data: 16 floats (8 floats for Transform2D, 4 floats for Color, 4 floats of custom data)
    /// 3D:
    ///   - Position: 12 floats (12 floats for Transform3D)
    ///   - Position + Vertex color: 16 floats (12 floats for Transform3D, 4 floats for Color)
    ///   - Position + Custom data: 16 floats (12 floats for Transform3D, 4 floats of custom data)
    ///   - Position + Vertex color + Custom data: 20 floats (12 floats for Transform3D, 4 floats for Color, 4 floats of custom data)
    /// </code></para>
    /// <para>Instance transforms are in row-major order. Specifically:</para>
    /// <para>- For <see cref="Godot.Transform2D"/> the float-order is: <c>(x.x, y.x, padding_float, origin.x, x.y, y.y, padding_float, origin.y)</c>.</para>
    /// <para>- For <see cref="Godot.Transform3D"/> the float-order is: <c>(basis.x.x, basis.y.x, basis.z.x, origin.x, basis.x.y, basis.y.y, basis.z.y, origin.y, basis.x.z, basis.y.z, basis.z.z, origin.z)</c>.</para>
    /// </summary>
    public void MultimeshSetBuffer(Rid multimesh, float[] buffer)
    {
        NativeCalls.godot_icall_2_1140(MethodBind84, GodotObject.GetPtr(this), multimesh, buffer);
    }

    /// <summary>
    /// <para>Set the entire data to use for drawing the <paramref name="multimesh"/> at once to <paramref name="buffer"/> (such as instance transforms and colors). <paramref name="buffer"/>'s size must match the number of instances multiplied by the per-instance data size (which depends on the enabled MultiMesh fields). Otherwise, an error message is printed and nothing is rendered. See also <see cref="Godot.RenderingServerInstance.MultimeshGetBuffer(Rid)"/>.</para>
    /// <para>The per-instance data size and expected data order is:</para>
    /// <para><code>
    /// 2D:
    ///   - Position: 8 floats (8 floats for Transform2D)
    ///   - Position + Vertex color: 12 floats (8 floats for Transform2D, 4 floats for Color)
    ///   - Position + Custom data: 12 floats (8 floats for Transform2D, 4 floats of custom data)
    ///   - Position + Vertex color + Custom data: 16 floats (8 floats for Transform2D, 4 floats for Color, 4 floats of custom data)
    /// 3D:
    ///   - Position: 12 floats (12 floats for Transform3D)
    ///   - Position + Vertex color: 16 floats (12 floats for Transform3D, 4 floats for Color)
    ///   - Position + Custom data: 16 floats (12 floats for Transform3D, 4 floats of custom data)
    ///   - Position + Vertex color + Custom data: 20 floats (12 floats for Transform3D, 4 floats for Color, 4 floats of custom data)
    /// </code></para>
    /// <para>Instance transforms are in row-major order. Specifically:</para>
    /// <para>- For <see cref="Godot.Transform2D"/> the float-order is: <c>(x.x, y.x, padding_float, origin.x, x.y, y.y, padding_float, origin.y)</c>.</para>
    /// <para>- For <see cref="Godot.Transform3D"/> the float-order is: <c>(basis.x.x, basis.y.x, basis.z.x, origin.x, basis.x.y, basis.y.y, basis.z.y, origin.y, basis.x.z, basis.y.z, basis.z.z, origin.z)</c>.</para>
    /// </summary>
    public void MultimeshSetBuffer(Rid multimesh, ReadOnlySpan<float> buffer)
    {
        NativeCalls.godot_icall_2_1140(MethodBind84, GodotObject.GetPtr(this), multimesh, buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetCommandBufferRdRid, 3814569979ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.RenderingDevice"/> <see cref="Godot.Rid"/> handle of the <see cref="Godot.MultiMesh"/> command buffer. This <see cref="Godot.Rid"/> is only valid if <c>use_indirect</c> is set to <see langword="true"/> when allocating data through <see cref="Godot.RenderingServerInstance.MultimeshAllocateData(Rid, int, RenderingServer.MultimeshTransformFormat, bool, bool, bool)"/>. It can be used to directly modify the instance count via buffer.</para>
    /// <para>The data structure is dependent on both how many surfaces the mesh contains and whether it is indexed or not, the buffer has 5 integers in it, with the last unused if the mesh is not indexed.</para>
    /// <para>Each of the values in the buffer correspond to these options:</para>
    /// <para><code>
    /// Indexed:
    ///   0 - indexCount;
    ///   1 - instanceCount;
    ///   2 - firstIndex;
    ///   3 - vertexOffset;
    ///   4 - firstInstance;
    /// Non Indexed:
    ///   0 - vertexCount;
    ///   1 - instanceCount;
    ///   2 - firstVertex;
    ///   3 - firstInstance;
    ///   4 - unused;
    /// </code></para>
    /// </summary>
    public Rid MultimeshGetCommandBufferRdRid(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_855(MethodBind85, GodotObject.GetPtr(this), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetBufferRdRid, 3814569979ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.RenderingDevice"/> <see cref="Godot.Rid"/> handle of the <see cref="Godot.MultiMesh"/>, which can be used as any other buffer on the Rendering Device.</para>
    /// </summary>
    public Rid MultimeshGetBufferRdRid(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_855(MethodBind86, GodotObject.GetPtr(this), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetBuffer, 3964669176ul);

    /// <summary>
    /// <para>Returns the MultiMesh data (such as instance transforms, colors, etc.). See <see cref="Godot.RenderingServerInstance.MultimeshSetBuffer(Rid, float[])"/> for details on the returned data.</para>
    /// <para><b>Note:</b> If the buffer is in the engine's internal cache, it will have to be fetched from GPU memory and possibly decompressed. This means <see cref="Godot.RenderingServerInstance.MultimeshGetBuffer(Rid)"/> is potentially a slow operation and should be avoided whenever possible.</para>
    /// </summary>
    public float[] MultimeshGetBuffer(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_1141(MethodBind87, GodotObject.GetPtr(this), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetBufferInterpolated, 659844711ul);

    /// <summary>
    /// <para>Alternative version of <see cref="Godot.RenderingServerInstance.MultimeshSetBuffer(Rid, float[])"/> for use with physics interpolation.</para>
    /// <para>Takes both an array of current data and an array of data for the previous physics tick.</para>
    /// </summary>
    public void MultimeshSetBufferInterpolated(Rid multimesh, float[] buffer, float[] bufferPrevious)
    {
        NativeCalls.godot_icall_3_1142(MethodBind88, GodotObject.GetPtr(this), multimesh, buffer, bufferPrevious);
    }

    /// <summary>
    /// <para>Alternative version of <see cref="Godot.RenderingServerInstance.MultimeshSetBuffer(Rid, float[])"/> for use with physics interpolation.</para>
    /// <para>Takes both an array of current data and an array of data for the previous physics tick.</para>
    /// </summary>
    public void MultimeshSetBufferInterpolated(Rid multimesh, ReadOnlySpan<float> buffer, ReadOnlySpan<float> bufferPrevious)
    {
        NativeCalls.godot_icall_3_1142(MethodBind88, GodotObject.GetPtr(this), multimesh, buffer, bufferPrevious);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetPhysicsInterpolated, 1265174801ul);

    /// <summary>
    /// <para>Turns on and off physics interpolation for this MultiMesh resource.</para>
    /// </summary>
    public void MultimeshSetPhysicsInterpolated(Rid multimesh, bool interpolated)
    {
        NativeCalls.godot_icall_2_434(MethodBind89, GodotObject.GetPtr(this), multimesh, interpolated.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetPhysicsInterpolationQuality, 3934808223ul);

    /// <summary>
    /// <para>Sets the physics interpolation quality for the <see cref="Godot.MultiMesh"/>.</para>
    /// <para>A value of <see cref="Godot.RenderingServer.MultimeshPhysicsInterpolationQuality.Fast"/> gives fast but low quality interpolation, a value of <see cref="Godot.RenderingServer.MultimeshPhysicsInterpolationQuality.High"/> gives slower but higher quality interpolation.</para>
    /// </summary>
    public void MultimeshSetPhysicsInterpolationQuality(Rid multimesh, RenderingServer.MultimeshPhysicsInterpolationQuality quality)
    {
        NativeCalls.godot_icall_2_426(MethodBind90, GodotObject.GetPtr(this), multimesh, (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceResetPhysicsInterpolation, 3411492887ul);

    /// <summary>
    /// <para>Prevents physics interpolation for the specified instance during the current physics tick.</para>
    /// <para>This is useful when moving an instance to a new location, to give an instantaneous change rather than interpolation from the previous location.</para>
    /// </summary>
    public void MultimeshInstanceResetPhysicsInterpolation(Rid multimesh, int index)
    {
        NativeCalls.godot_icall_2_426(MethodBind91, GodotObject.GetPtr(this), multimesh, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstancesResetPhysicsInterpolation, 2722037293ul);

    /// <summary>
    /// <para>Prevents physics interpolation for all instances during the current physics tick.</para>
    /// <para>This is useful when moving all instances to new locations, to give instantaneous changes rather than interpolation from the previous locations.</para>
    /// </summary>
    public void MultimeshInstancesResetPhysicsInterpolation(Rid multimesh)
    {
        NativeCalls.godot_icall_1_286(MethodBind92, GodotObject.GetPtr(this), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a skeleton and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>skeleton_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// </summary>
    public Rid SkeletonCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind93, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonAllocateData, 1904426712ul);

    public void SkeletonAllocateData(Rid skeleton, int bones, bool is2DSkeleton = false)
    {
        NativeCalls.godot_icall_3_439(MethodBind94, GodotObject.GetPtr(this), skeleton, bones, is2DSkeleton.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonGetBoneCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of bones allocated for this skeleton.</para>
    /// </summary>
    public int SkeletonGetBoneCount(Rid skeleton)
    {
        return NativeCalls.godot_icall_1_835(MethodBind95, GodotObject.GetPtr(this), skeleton);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonBoneSetTransform, 675327471ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform3D"/> for a specific bone of this skeleton.</para>
    /// </summary>
    public unsafe void SkeletonBoneSetTransform(Rid skeleton, int bone, Transform3D transform)
    {
        NativeCalls.godot_icall_3_1001(MethodBind96, GodotObject.GetPtr(this), skeleton, bone, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonBoneGetTransform, 1050775521ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform3D"/> set for a specific bone of this skeleton.</para>
    /// </summary>
    public Transform3D SkeletonBoneGetTransform(Rid skeleton, int bone)
    {
        return NativeCalls.godot_icall_2_1002(MethodBind97, GodotObject.GetPtr(this), skeleton, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonBoneSetTransform2D, 736082694ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform2D"/> for a specific bone of this skeleton.</para>
    /// </summary>
    public unsafe void SkeletonBoneSetTransform2D(Rid skeleton, int bone, Transform2D transform)
    {
        NativeCalls.godot_icall_3_991(MethodBind98, GodotObject.GetPtr(this), skeleton, bone, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonBoneGetTransform2D, 1324854622ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform2D"/> set for a specific bone of this skeleton.</para>
    /// </summary>
    public Transform2D SkeletonBoneGetTransform2D(Rid skeleton, int bone)
    {
        return NativeCalls.godot_icall_2_992(MethodBind99, GodotObject.GetPtr(this), skeleton, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonSetBaseTransform2D, 1246044741ul);

    public unsafe void SkeletonSetBaseTransform2D(Rid skeleton, Transform2D baseTransform)
    {
        NativeCalls.godot_icall_2_429(MethodBind100, GodotObject.GetPtr(this), skeleton, &baseTransform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DirectionalLightCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a directional light and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID can be used in most <c>light_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this directional light to an instance using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.DirectionalLight3D"/>.</para>
    /// </summary>
    public Rid DirectionalLightCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind101, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OmniLightCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new omni light and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID can be used in most <c>light_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this omni light to an instance using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.OmniLight3D"/>.</para>
    /// </summary>
    public Rid OmniLightCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind102, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpotLightCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a spot light and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID can be used in most <c>light_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this spot light to an instance using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// </summary>
    public Rid SpotLightCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind103, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetColor, 2948539648ul);

    /// <summary>
    /// <para>Sets the color of the light. Equivalent to <see cref="Godot.Light3D.LightColor"/>.</para>
    /// </summary>
    public unsafe void LightSetColor(Rid light, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind104, GodotObject.GetPtr(this), light, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetParam, 501936875ul);

    /// <summary>
    /// <para>Sets the specified 3D light parameter. Equivalent to <see cref="Godot.Light3D.SetParam(Light3D.Param, float)"/>.</para>
    /// </summary>
    public void LightSetParam(Rid light, RenderingServer.LightParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind105, GodotObject.GetPtr(this), light, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetShadow, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, light will cast shadows. Equivalent to <see cref="Godot.Light3D.ShadowEnabled"/>.</para>
    /// </summary>
    public void LightSetShadow(Rid light, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind106, GodotObject.GetPtr(this), light, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetProjector, 395945892ul);

    /// <summary>
    /// <para>Sets the projector texture to use for the specified 3D light. Equivalent to <see cref="Godot.Light3D.LightProjector"/>.</para>
    /// </summary>
    public void LightSetProjector(Rid light, Rid texture)
    {
        NativeCalls.godot_icall_2_430(MethodBind107, GodotObject.GetPtr(this), light, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetNegative, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the 3D light will subtract light instead of adding light. Equivalent to <see cref="Godot.Light3D.LightNegative"/>.</para>
    /// </summary>
    public void LightSetNegative(Rid light, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind108, GodotObject.GetPtr(this), light, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the cull mask for this 3D light. Lights only affect objects in the selected layers. Equivalent to <see cref="Godot.Light3D.LightCullMask"/>.</para>
    /// </summary>
    public void LightSetCullMask(Rid light, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind109, GodotObject.GetPtr(this), light, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetDistanceFade, 1622292572ul);

    /// <summary>
    /// <para>Sets the distance fade for this 3D light. This acts as a form of level of detail (LOD) and can be used to improve performance. Equivalent to <see cref="Godot.Light3D.DistanceFadeEnabled"/>, <see cref="Godot.Light3D.DistanceFadeBegin"/>, <see cref="Godot.Light3D.DistanceFadeShadow"/>, and <see cref="Godot.Light3D.DistanceFadeLength"/>.</para>
    /// </summary>
    public void LightSetDistanceFade(Rid decal, bool enabled, float begin, float shadow, float length)
    {
        NativeCalls.godot_icall_5_1143(MethodBind110, GodotObject.GetPtr(this), decal, enabled.ToGodotBool(), begin, shadow, length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetReverseCullFaceMode, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, reverses the backface culling of the mesh. This can be useful when you have a flat mesh that has a light behind it. If you need to cast a shadow on both sides of the mesh, set the mesh to use double-sided shadows with <see cref="Godot.RenderingServerInstance.InstanceGeometrySetCastShadowsSetting(Rid, RenderingServer.ShadowCastingSetting)"/>. Equivalent to <see cref="Godot.Light3D.ShadowReverseCullFace"/>.</para>
    /// </summary>
    public void LightSetReverseCullFaceMode(Rid light, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind111, GodotObject.GetPtr(this), light, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetShadowCasterMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the shadow caster mask for this 3D light. Shadows will only be cast using objects in the selected layers. Equivalent to <see cref="Godot.Light3D.ShadowCasterMask"/>.</para>
    /// </summary>
    public void LightSetShadowCasterMask(Rid light, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind112, GodotObject.GetPtr(this), light, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetBakeMode, 1048525260ul);

    /// <summary>
    /// <para>Sets the bake mode to use for the specified 3D light. Equivalent to <see cref="Godot.Light3D.LightBakeMode"/>.</para>
    /// </summary>
    public void LightSetBakeMode(Rid light, RenderingServer.LightBakeMode bakeMode)
    {
        NativeCalls.godot_icall_2_426(MethodBind113, GodotObject.GetPtr(this), light, (int)bakeMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetMaxSdfgiCascade, 3411492887ul);

    /// <summary>
    /// <para>Sets the maximum SDFGI cascade in which the 3D light's indirect lighting is rendered. Higher values allow the light to be rendered in SDFGI further away from the camera.</para>
    /// </summary>
    public void LightSetMaxSdfgiCascade(Rid light, uint cascade)
    {
        NativeCalls.godot_icall_2_856(MethodBind114, GodotObject.GetPtr(this), light, cascade);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightOmniSetShadowMode, 2552677200ul);

    /// <summary>
    /// <para>Sets whether to use a dual paraboloid or a cubemap for the shadow map. Dual paraboloid is faster but may suffer from artifacts. Equivalent to <see cref="Godot.OmniLight3D.OmniShadowMode"/>.</para>
    /// </summary>
    public void LightOmniSetShadowMode(Rid light, RenderingServer.LightOmniShadowMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind115, GodotObject.GetPtr(this), light, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightDirectionalSetShadowMode, 380462970ul);

    /// <summary>
    /// <para>Sets the shadow mode for this directional light. Equivalent to <see cref="Godot.DirectionalLight3D.DirectionalShadowMode"/>.</para>
    /// </summary>
    public void LightDirectionalSetShadowMode(Rid light, RenderingServer.LightDirectionalShadowMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind116, GodotObject.GetPtr(this), light, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightDirectionalSetBlendSplits, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, this directional light will blend between shadow map splits resulting in a smoother transition between them. Equivalent to <see cref="Godot.DirectionalLight3D.DirectionalShadowBlendSplits"/>.</para>
    /// </summary>
    public void LightDirectionalSetBlendSplits(Rid light, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind117, GodotObject.GetPtr(this), light, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightDirectionalSetSkyMode, 2559740754ul);

    /// <summary>
    /// <para>If <see langword="true"/>, this light will not be used for anything except sky shaders. Use this for lights that impact your sky shader that you may want to hide from affecting the rest of the scene. For example, you may want to enable this when the sun in your sky shader falls below the horizon.</para>
    /// </summary>
    public void LightDirectionalSetSkyMode(Rid light, RenderingServer.LightDirectionalSkyMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind118, GodotObject.GetPtr(this), light, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightProjectorsSetFilter, 43944325ul);

    /// <summary>
    /// <para>Sets the texture filter mode to use when rendering light projectors. This parameter is global and cannot be set on a per-light basis.</para>
    /// </summary>
    public void LightProjectorsSetFilter(RenderingServer.LightProjectorFilter filter)
    {
        NativeCalls.godot_icall_1_38(MethodBind119, GodotObject.GetPtr(this), (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapsSetBicubicFilter, 2586408642ul);

    /// <summary>
    /// <para>Toggles whether a bicubic filter should be used when lightmaps are sampled. This smoothens their appearance at a performance cost.</para>
    /// </summary>
    public void LightmapsSetBicubicFilter(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind120, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PositionalSoftShadowFilterSetQuality, 3613045266ul);

    /// <summary>
    /// <para>Sets the filter quality for omni and spot light shadows in 3D. See also <c>ProjectSettings.rendering/lights_and_shadows/positional_shadow/soft_shadow_filter_quality</c>. This parameter is global and cannot be set on a per-viewport basis.</para>
    /// </summary>
    public void PositionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind121, GodotObject.GetPtr(this), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DirectionalSoftShadowFilterSetQuality, 3613045266ul);

    /// <summary>
    /// <para>Sets the filter <paramref name="quality"/> for directional light shadows in 3D. See also <c>ProjectSettings.rendering/lights_and_shadows/directional_shadow/soft_shadow_filter_quality</c>. This parameter is global and cannot be set on a per-viewport basis.</para>
    /// </summary>
    public void DirectionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind122, GodotObject.GetPtr(this), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DirectionalShadowAtlasSetSize, 300928843ul);

    /// <summary>
    /// <para>Sets the <paramref name="size"/> of the directional light shadows in 3D. See also <c>ProjectSettings.rendering/lights_and_shadows/directional_shadow/size</c>. This parameter is global and cannot be set on a per-viewport basis.</para>
    /// </summary>
    public void DirectionalShadowAtlasSetSize(int size, bool is16Bits)
    {
        NativeCalls.godot_icall_2_61(MethodBind123, GodotObject.GetPtr(this), size, is16Bits.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a reflection probe and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>reflection_probe_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this reflection probe to an instance using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.ReflectionProbe"/>.</para>
    /// </summary>
    public Rid ReflectionProbeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind124, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetUpdateMode, 3853670147ul);

    /// <summary>
    /// <para>Sets how often the reflection probe updates. Can either be once or every frame.</para>
    /// </summary>
    public void ReflectionProbeSetUpdateMode(Rid probe, RenderingServer.ReflectionProbeUpdateMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind125, GodotObject.GetPtr(this), probe, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetIntensity, 1794382983ul);

    /// <summary>
    /// <para>Sets the intensity of the reflection probe. Intensity modulates the strength of the reflection. Equivalent to <see cref="Godot.ReflectionProbe.Intensity"/>.</para>
    /// </summary>
    public void ReflectionProbeSetIntensity(Rid probe, float intensity)
    {
        NativeCalls.godot_icall_2_816(MethodBind126, GodotObject.GetPtr(this), probe, intensity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetBlendDistance, 1794382983ul);

    /// <summary>
    /// <para>Sets the distance in meters over which a probe blends into the scene.</para>
    /// </summary>
    public void ReflectionProbeSetBlendDistance(Rid probe, float blendDistance)
    {
        NativeCalls.godot_icall_2_816(MethodBind127, GodotObject.GetPtr(this), probe, blendDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetAmbientMode, 184163074ul);

    /// <summary>
    /// <para>Sets the reflection probe's ambient light mode. Equivalent to <see cref="Godot.ReflectionProbe.AmbientMode"/>.</para>
    /// </summary>
    public void ReflectionProbeSetAmbientMode(Rid probe, RenderingServer.ReflectionProbeAmbientMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind128, GodotObject.GetPtr(this), probe, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetAmbientColor, 2948539648ul);

    /// <summary>
    /// <para>Sets the reflection probe's custom ambient light color. Equivalent to <see cref="Godot.ReflectionProbe.AmbientColor"/>.</para>
    /// </summary>
    public unsafe void ReflectionProbeSetAmbientColor(Rid probe, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind129, GodotObject.GetPtr(this), probe, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetAmbientEnergy, 1794382983ul);

    /// <summary>
    /// <para>Sets the reflection probe's custom ambient light energy. Equivalent to <see cref="Godot.ReflectionProbe.AmbientColorEnergy"/>.</para>
    /// </summary>
    public void ReflectionProbeSetAmbientEnergy(Rid probe, float energy)
    {
        NativeCalls.godot_icall_2_816(MethodBind130, GodotObject.GetPtr(this), probe, energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetMaxDistance, 1794382983ul);

    /// <summary>
    /// <para>Sets the max distance away from the probe an object can be before it is culled. Equivalent to <see cref="Godot.ReflectionProbe.MaxDistance"/>.</para>
    /// </summary>
    public void ReflectionProbeSetMaxDistance(Rid probe, float distance)
    {
        NativeCalls.godot_icall_2_816(MethodBind131, GodotObject.GetPtr(this), probe, distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetSize, 3227306858ul);

    /// <summary>
    /// <para>Sets the size of the area that the reflection probe will capture. Equivalent to <see cref="Godot.ReflectionProbe.Size"/>.</para>
    /// </summary>
    public unsafe void ReflectionProbeSetSize(Rid probe, Vector3 size)
    {
        NativeCalls.godot_icall_2_865(MethodBind132, GodotObject.GetPtr(this), probe, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetOriginOffset, 3227306858ul);

    /// <summary>
    /// <para>Sets the origin offset to be used when this reflection probe is in box project mode. Equivalent to <see cref="Godot.ReflectionProbe.OriginOffset"/>.</para>
    /// </summary>
    public unsafe void ReflectionProbeSetOriginOffset(Rid probe, Vector3 offset)
    {
        NativeCalls.godot_icall_2_865(MethodBind133, GodotObject.GetPtr(this), probe, &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetAsInterior, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, reflections will ignore sky contribution. Equivalent to <see cref="Godot.ReflectionProbe.Interior"/>.</para>
    /// </summary>
    public void ReflectionProbeSetAsInterior(Rid probe, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind134, GodotObject.GetPtr(this), probe, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetEnableBoxProjection, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, uses box projection. This can make reflections look more correct in certain situations. Equivalent to <see cref="Godot.ReflectionProbe.BoxProjection"/>.</para>
    /// </summary>
    public void ReflectionProbeSetEnableBoxProjection(Rid probe, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind135, GodotObject.GetPtr(this), probe, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetEnableShadows, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, computes shadows in the reflection probe. This makes the reflection much slower to compute. Equivalent to <see cref="Godot.ReflectionProbe.EnableShadows"/>.</para>
    /// </summary>
    public void ReflectionProbeSetEnableShadows(Rid probe, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind136, GodotObject.GetPtr(this), probe, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the render cull mask for this reflection probe. Only instances with a matching layer will be reflected by this probe. Equivalent to <see cref="Godot.ReflectionProbe.CullMask"/>.</para>
    /// </summary>
    public void ReflectionProbeSetCullMask(Rid probe, uint layers)
    {
        NativeCalls.godot_icall_2_856(MethodBind137, GodotObject.GetPtr(this), probe, layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind138 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetReflectionMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the render reflection mask for this reflection probe. Only instances with a matching layer will have reflections applied from this probe. Equivalent to <see cref="Godot.ReflectionProbe.ReflectionMask"/>.</para>
    /// </summary>
    public void ReflectionProbeSetReflectionMask(Rid probe, uint layers)
    {
        NativeCalls.godot_icall_2_856(MethodBind138, GodotObject.GetPtr(this), probe, layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind139 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetResolution, 3411492887ul);

    /// <summary>
    /// <para>Deprecated. This method does nothing.</para>
    /// </summary>
    [Obsolete("This method has not done anything since Godot 3.")]
    public void ReflectionProbeSetResolution(Rid probe, int resolution)
    {
        NativeCalls.godot_icall_2_426(MethodBind139, GodotObject.GetPtr(this), probe, resolution);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind140 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetMeshLodThreshold, 1794382983ul);

    /// <summary>
    /// <para>Sets the mesh level of detail to use in the reflection probe rendering. Higher values will use less detailed versions of meshes that have LOD variations generated, which can improve performance. Equivalent to <see cref="Godot.ReflectionProbe.MeshLodThreshold"/>.</para>
    /// </summary>
    public void ReflectionProbeSetMeshLodThreshold(Rid probe, float pixels)
    {
        NativeCalls.godot_icall_2_816(MethodBind140, GodotObject.GetPtr(this), probe, pixels);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind141 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a decal and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>decal_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this decal to an instance using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.Decal"/>.</para>
    /// </summary>
    public Rid DecalCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind141, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind142 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetSize, 3227306858ul);

    /// <summary>
    /// <para>Sets the <paramref name="size"/> of the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.Size"/>.</para>
    /// </summary>
    public unsafe void DecalSetSize(Rid decal, Vector3 size)
    {
        NativeCalls.godot_icall_2_865(MethodBind142, GodotObject.GetPtr(this), decal, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind143 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetTexture, 3953344054ul);

    /// <summary>
    /// <para>Sets the <paramref name="texture"/> in the given texture <paramref name="type"/> slot for the specified decal. Equivalent to <see cref="Godot.Decal.SetTexture(Decal.DecalTexture, Texture2D)"/>.</para>
    /// </summary>
    public void DecalSetTexture(Rid decal, RenderingServer.DecalTexture type, Rid texture)
    {
        NativeCalls.godot_icall_3_833(MethodBind143, GodotObject.GetPtr(this), decal, (int)type, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind144 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetEmissionEnergy, 1794382983ul);

    /// <summary>
    /// <para>Sets the emission <paramref name="energy"/> in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.EmissionEnergy"/>.</para>
    /// </summary>
    public void DecalSetEmissionEnergy(Rid decal, float energy)
    {
        NativeCalls.godot_icall_2_816(MethodBind144, GodotObject.GetPtr(this), decal, energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind145 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetAlbedoMix, 1794382983ul);

    /// <summary>
    /// <para>Sets the <paramref name="albedoMix"/> in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.AlbedoMix"/>.</para>
    /// </summary>
    public void DecalSetAlbedoMix(Rid decal, float albedoMix)
    {
        NativeCalls.godot_icall_2_816(MethodBind145, GodotObject.GetPtr(this), decal, albedoMix);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind146 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetModulate, 2948539648ul);

    /// <summary>
    /// <para>Sets the color multiplier in the decal specified by the <paramref name="decal"/> RID to <paramref name="color"/>. Equivalent to <see cref="Godot.Decal.Modulate"/>.</para>
    /// </summary>
    public unsafe void DecalSetModulate(Rid decal, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind146, GodotObject.GetPtr(this), decal, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind147 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the cull <paramref name="mask"/> in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.CullMask"/>.</para>
    /// </summary>
    public void DecalSetCullMask(Rid decal, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind147, GodotObject.GetPtr(this), decal, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind148 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetDistanceFade, 2972769666ul);

    /// <summary>
    /// <para>Sets the distance fade parameters in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.DistanceFadeEnabled"/>, <see cref="Godot.Decal.DistanceFadeBegin"/> and <see cref="Godot.Decal.DistanceFadeLength"/>.</para>
    /// </summary>
    public void DecalSetDistanceFade(Rid decal, bool enabled, float begin, float length)
    {
        NativeCalls.godot_icall_4_1144(MethodBind148, GodotObject.GetPtr(this), decal, enabled.ToGodotBool(), begin, length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind149 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetFade, 2513314492ul);

    /// <summary>
    /// <para>Sets the upper fade (<paramref name="above"/>) and lower fade (<paramref name="below"/>) in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.UpperFade"/> and <see cref="Godot.Decal.LowerFade"/>.</para>
    /// </summary>
    public void DecalSetFade(Rid decal, float above, float below)
    {
        NativeCalls.godot_icall_3_1145(MethodBind149, GodotObject.GetPtr(this), decal, above, below);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind150 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetNormalFade, 1794382983ul);

    /// <summary>
    /// <para>Sets the normal <paramref name="fade"/> in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.NormalFade"/>.</para>
    /// </summary>
    public void DecalSetNormalFade(Rid decal, float fade)
    {
        NativeCalls.godot_icall_2_816(MethodBind150, GodotObject.GetPtr(this), decal, fade);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind151 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalsSetFilter, 3519875702ul);

    /// <summary>
    /// <para>Sets the texture <paramref name="filter"/> mode to use when rendering decals. This parameter is global and cannot be set on a per-decal basis.</para>
    /// </summary>
    public void DecalsSetFilter(RenderingServer.DecalFilter filter)
    {
        NativeCalls.godot_icall_1_38(MethodBind151, GodotObject.GetPtr(this), (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind152 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GISetUseHalfResolution, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="halfResolution"/> is <see langword="true"/>, renders <see cref="Godot.VoxelGI"/> and SDFGI (<see cref="Godot.Environment.SdfgiEnabled"/>) buffers at halved resolution on each axis (e.g. 960×540 when the viewport size is 1920×1080). This improves performance significantly when VoxelGI or SDFGI is enabled, at the cost of artifacts that may be visible on polygon edges. The loss in quality becomes less noticeable as the viewport resolution increases. <see cref="Godot.LightmapGI"/> rendering is not affected by this setting. Equivalent to <c>ProjectSettings.rendering/global_illumination/gi/use_half_resolution</c>.</para>
    /// </summary>
    public void GISetUseHalfResolution(bool halfResolution)
    {
        NativeCalls.godot_icall_1_14(MethodBind152, GodotObject.GetPtr(this), halfResolution.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind153 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGICreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new voxel-based global illumination object and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>voxel_gi_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.VoxelGI"/>.</para>
    /// </summary>
    public Rid VoxelGICreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind153, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind154 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIAllocateData, 4108223027ul);

    public unsafe void VoxelGIAllocateData(Rid voxelGI, Transform3D toCellXform, Aabb aabb, Vector3I octreeSize, byte[] octreeCells, byte[] dataCells, byte[] distanceField, int[] levelCounts)
    {
        NativeCalls.godot_icall_8_1146(MethodBind154, GodotObject.GetPtr(this), voxelGI, &toCellXform, &aabb, &octreeSize, octreeCells, dataCells, distanceField, levelCounts);
    }

    public unsafe void VoxelGIAllocateData(Rid voxelGI, Transform3D toCellXform, Aabb aabb, Vector3I octreeSize, ReadOnlySpan<byte> octreeCells, ReadOnlySpan<byte> dataCells, ReadOnlySpan<byte> distanceField, ReadOnlySpan<int> levelCounts)
    {
        NativeCalls.godot_icall_8_1146(MethodBind154, GodotObject.GetPtr(this), voxelGI, &toCellXform, &aabb, &octreeSize, octreeCells, dataCells, distanceField, levelCounts);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind155 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetOctreeSize, 2607699645ul);

    public Vector3I VoxelGIGetOctreeSize(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_1147(MethodBind155, GodotObject.GetPtr(this), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind156 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetOctreeCells, 3348040486ul);

    public byte[] VoxelGIGetOctreeCells(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_1148(MethodBind156, GodotObject.GetPtr(this), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind157 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetDataCells, 3348040486ul);

    public byte[] VoxelGIGetDataCells(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_1148(MethodBind157, GodotObject.GetPtr(this), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind158 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetDistanceField, 3348040486ul);

    public byte[] VoxelGIGetDistanceField(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_1148(MethodBind158, GodotObject.GetPtr(this), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind159 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetLevelCounts, 788230395ul);

    public int[] VoxelGIGetLevelCounts(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_1149(MethodBind159, GodotObject.GetPtr(this), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind160 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetToCellXform, 1128465797ul);

    public Transform3D VoxelGIGetToCellXform(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_874(MethodBind160, GodotObject.GetPtr(this), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind161 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetDynamicRange, 1794382983ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.DynamicRange"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void VoxelGISetDynamicRange(Rid voxelGI, float range)
    {
        NativeCalls.godot_icall_2_816(MethodBind161, GodotObject.GetPtr(this), voxelGI, range);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind162 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetPropagation, 1794382983ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.Propagation"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void VoxelGISetPropagation(Rid voxelGI, float amount)
    {
        NativeCalls.godot_icall_2_816(MethodBind162, GodotObject.GetPtr(this), voxelGI, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind163 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetEnergy, 1794382983ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.Energy"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void VoxelGISetEnergy(Rid voxelGI, float energy)
    {
        NativeCalls.godot_icall_2_816(MethodBind163, GodotObject.GetPtr(this), voxelGI, energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind164 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetBakedExposureNormalization, 1794382983ul);

    /// <summary>
    /// <para>Used to inform the renderer what exposure normalization value was used while baking the voxel gi. This value will be used and modulated at run time to ensure that the voxel gi maintains a consistent level of exposure even if the scene-wide exposure normalization is changed at run time. For more information see <see cref="Godot.RenderingServerInstance.CameraAttributesSetExposure(Rid, float, float)"/>.</para>
    /// </summary>
    public void VoxelGISetBakedExposureNormalization(Rid voxelGI, float bakedExposure)
    {
        NativeCalls.godot_icall_2_816(MethodBind164, GodotObject.GetPtr(this), voxelGI, bakedExposure);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind165 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetBias, 1794382983ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.Bias"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void VoxelGISetBias(Rid voxelGI, float bias)
    {
        NativeCalls.godot_icall_2_816(MethodBind165, GodotObject.GetPtr(this), voxelGI, bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind166 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetNormalBias, 1794382983ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.NormalBias"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void VoxelGISetNormalBias(Rid voxelGI, float bias)
    {
        NativeCalls.godot_icall_2_816(MethodBind166, GodotObject.GetPtr(this), voxelGI, bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind167 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetInterior, 1265174801ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.Interior"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void VoxelGISetInterior(Rid voxelGI, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind167, GodotObject.GetPtr(this), voxelGI, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind168 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetUseTwoBounces, 1265174801ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.UseTwoBounces"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void VoxelGISetUseTwoBounces(Rid voxelGI, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind168, GodotObject.GetPtr(this), voxelGI, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind169 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetQuality, 1538689978ul);

    /// <summary>
    /// <para>Sets the <c>ProjectSettings.rendering/global_illumination/voxel_gi/quality</c> value to use when rendering. This parameter is global and cannot be set on a per-VoxelGI basis.</para>
    /// </summary>
    public void VoxelGISetQuality(RenderingServer.VoxelGIQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind169, GodotObject.GetPtr(this), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind170 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new lightmap global illumination instance and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>lightmap_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.LightmapGI"/>.</para>
    /// </summary>
    public Rid LightmapCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind170, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind171 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetTextures, 2646464759ul);

    /// <summary>
    /// <para>Set the textures on the given <paramref name="lightmap"/> GI instance to the texture array pointed to by the <paramref name="light"/> RID. If the lightmap texture was baked with <see cref="Godot.LightmapGI.Directional"/> set to <see langword="true"/>, then <paramref name="usesSh"/> must also be <see langword="true"/>.</para>
    /// </summary>
    public void LightmapSetTextures(Rid lightmap, Rid light, bool usesSh)
    {
        NativeCalls.godot_icall_3_1150(MethodBind171, GodotObject.GetPtr(this), lightmap, light, usesSh.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind172 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetProbeBounds, 3696536120ul);

    public unsafe void LightmapSetProbeBounds(Rid lightmap, Aabb bounds)
    {
        NativeCalls.godot_icall_2_1135(MethodBind172, GodotObject.GetPtr(this), lightmap, &bounds);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind173 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetProbeInterior, 1265174801ul);

    public void LightmapSetProbeInterior(Rid lightmap, bool interior)
    {
        NativeCalls.godot_icall_2_434(MethodBind173, GodotObject.GetPtr(this), lightmap, interior.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind174 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetProbeCaptureData, 3217845880ul);

    public void LightmapSetProbeCaptureData(Rid lightmap, Vector3[] points, Color[] pointSh, int[] tetrahedra, int[] bspTree)
    {
        NativeCalls.godot_icall_5_1151(MethodBind174, GodotObject.GetPtr(this), lightmap, points, pointSh, tetrahedra, bspTree);
    }

    public void LightmapSetProbeCaptureData(Rid lightmap, ReadOnlySpan<Vector3> points, ReadOnlySpan<Color> pointSh, ReadOnlySpan<int> tetrahedra, ReadOnlySpan<int> bspTree)
    {
        NativeCalls.godot_icall_5_1151(MethodBind174, GodotObject.GetPtr(this), lightmap, points, pointSh, tetrahedra, bspTree);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind175 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapGetProbeCapturePoints, 808965560ul);

    public Vector3[] LightmapGetProbeCapturePoints(Rid lightmap)
    {
        return NativeCalls.godot_icall_1_878(MethodBind175, GodotObject.GetPtr(this), lightmap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind176 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapGetProbeCaptureSh, 1569415609ul);

    public Color[] LightmapGetProbeCaptureSh(Rid lightmap)
    {
        return NativeCalls.godot_icall_1_1152(MethodBind176, GodotObject.GetPtr(this), lightmap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind177 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapGetProbeCaptureTetrahedra, 788230395ul);

    public int[] LightmapGetProbeCaptureTetrahedra(Rid lightmap)
    {
        return NativeCalls.godot_icall_1_1149(MethodBind177, GodotObject.GetPtr(this), lightmap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind178 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapGetProbeCaptureBspTree, 788230395ul);

    public int[] LightmapGetProbeCaptureBspTree(Rid lightmap)
    {
        return NativeCalls.godot_icall_1_1149(MethodBind178, GodotObject.GetPtr(this), lightmap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind179 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetBakedExposureNormalization, 1794382983ul);

    /// <summary>
    /// <para>Used to inform the renderer what exposure normalization value was used while baking the lightmap. This value will be used and modulated at run time to ensure that the lightmap maintains a consistent level of exposure even if the scene-wide exposure normalization is changed at run time. For more information see <see cref="Godot.RenderingServerInstance.CameraAttributesSetExposure(Rid, float, float)"/>.</para>
    /// </summary>
    public void LightmapSetBakedExposureNormalization(Rid lightmap, float bakedExposure)
    {
        NativeCalls.godot_icall_2_816(MethodBind179, GodotObject.GetPtr(this), lightmap, bakedExposure);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind180 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetProbeCaptureUpdateSpeed, 373806689ul);

    public void LightmapSetProbeCaptureUpdateSpeed(float speed)
    {
        NativeCalls.godot_icall_1_67(MethodBind180, GodotObject.GetPtr(this), speed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind181 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a GPU-based particle system and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>particles_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach these particles to an instance using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent nodes are <see cref="Godot.GpuParticles2D"/> and <see cref="Godot.GpuParticles3D"/>.</para>
    /// <para><b>Note:</b> All <c>particles_*</c> methods only apply to GPU-based particles, not CPU-based particles. <see cref="Godot.CpuParticles2D"/> and <see cref="Godot.CpuParticles3D"/> do not have equivalent RenderingServer functions available, as these use <see cref="Godot.MultiMeshInstance2D"/> and <see cref="Godot.MultiMeshInstance3D"/> under the hood (see <c>multimesh_*</c> methods).</para>
    /// </summary>
    public Rid ParticlesCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind181, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind182 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetMode, 3492270028ul);

    /// <summary>
    /// <para>Sets whether the GPU particles specified by the <paramref name="particles"/> RID should be rendered in 2D or 3D according to <paramref name="mode"/>.</para>
    /// </summary>
    public void ParticlesSetMode(Rid particles, RenderingServer.ParticlesMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind182, GodotObject.GetPtr(this), particles, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind183 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetEmitting, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, particles will emit over time. Setting to <see langword="false"/> does not reset the particles, but only stops their emission. Equivalent to <see cref="Godot.GpuParticles3D.Emitting"/>.</para>
    /// </summary>
    public void ParticlesSetEmitting(Rid particles, bool emitting)
    {
        NativeCalls.godot_icall_2_434(MethodBind183, GodotObject.GetPtr(this), particles, emitting.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind184 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesGetEmitting, 3521089500ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if particles are currently set to emitting.</para>
    /// </summary>
    public bool ParticlesGetEmitting(Rid particles)
    {
        return NativeCalls.godot_icall_1_421(MethodBind184, GodotObject.GetPtr(this), particles).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind185 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetAmount, 3411492887ul);

    /// <summary>
    /// <para>Sets the number of particles to be drawn and allocates the memory for them. Equivalent to <see cref="Godot.GpuParticles3D.Amount"/>.</para>
    /// </summary>
    public void ParticlesSetAmount(Rid particles, int amount)
    {
        NativeCalls.godot_icall_2_426(MethodBind185, GodotObject.GetPtr(this), particles, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind186 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetAmountRatio, 1794382983ul);

    /// <summary>
    /// <para>Sets the amount ratio for particles to be emitted. Equivalent to <see cref="Godot.GpuParticles3D.AmountRatio"/>.</para>
    /// </summary>
    public void ParticlesSetAmountRatio(Rid particles, float ratio)
    {
        NativeCalls.godot_icall_2_816(MethodBind186, GodotObject.GetPtr(this), particles, ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind187 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetLifetime, 1794382983ul);

    /// <summary>
    /// <para>Sets the lifetime of each particle in the system. Equivalent to <see cref="Godot.GpuParticles3D.Lifetime"/>.</para>
    /// </summary>
    public void ParticlesSetLifetime(Rid particles, double lifetime)
    {
        NativeCalls.godot_icall_2_435(MethodBind187, GodotObject.GetPtr(this), particles, lifetime);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind188 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetOneShot, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, particles will emit once and then stop. Equivalent to <see cref="Godot.GpuParticles3D.OneShot"/>.</para>
    /// </summary>
    public void ParticlesSetOneShot(Rid particles, bool oneShot)
    {
        NativeCalls.godot_icall_2_434(MethodBind188, GodotObject.GetPtr(this), particles, oneShot.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind189 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetPreProcessTime, 1794382983ul);

    /// <summary>
    /// <para>Sets the preprocess time for the particles' animation. This lets you delay starting an animation until after the particles have begun emitting. Equivalent to <see cref="Godot.GpuParticles3D.Preprocess"/>.</para>
    /// </summary>
    public void ParticlesSetPreProcessTime(Rid particles, double time)
    {
        NativeCalls.godot_icall_2_435(MethodBind189, GodotObject.GetPtr(this), particles, time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind190 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesRequestProcessTime, 1794382983ul);

    /// <summary>
    /// <para>Requests particles to process for extra process time during a single frame.</para>
    /// </summary>
    public void ParticlesRequestProcessTime(Rid particles, float time)
    {
        NativeCalls.godot_icall_2_816(MethodBind190, GodotObject.GetPtr(this), particles, time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind191 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetExplosivenessRatio, 1794382983ul);

    /// <summary>
    /// <para>Sets the explosiveness ratio. Equivalent to <see cref="Godot.GpuParticles3D.Explosiveness"/>.</para>
    /// </summary>
    public void ParticlesSetExplosivenessRatio(Rid particles, float ratio)
    {
        NativeCalls.godot_icall_2_816(MethodBind191, GodotObject.GetPtr(this), particles, ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind192 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetRandomnessRatio, 1794382983ul);

    /// <summary>
    /// <para>Sets the emission randomness ratio. This randomizes the emission of particles within their phase. Equivalent to <see cref="Godot.GpuParticles3D.Randomness"/>.</para>
    /// </summary>
    public void ParticlesSetRandomnessRatio(Rid particles, float ratio)
    {
        NativeCalls.godot_icall_2_816(MethodBind192, GodotObject.GetPtr(this), particles, ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind193 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetInterpToEnd, 1794382983ul);

    /// <summary>
    /// <para>Sets the value that informs a <see cref="Godot.ParticleProcessMaterial"/> to rush all particles towards the end of their lifetime.</para>
    /// </summary>
    public void ParticlesSetInterpToEnd(Rid particles, float factor)
    {
        NativeCalls.godot_icall_2_816(MethodBind193, GodotObject.GetPtr(this), particles, factor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind194 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetEmitterVelocity, 3227306858ul);

    /// <summary>
    /// <para>Sets the velocity of a particle node, that will be used by <see cref="Godot.ParticleProcessMaterial.InheritVelocityRatio"/>.</para>
    /// </summary>
    public unsafe void ParticlesSetEmitterVelocity(Rid particles, Vector3 velocity)
    {
        NativeCalls.godot_icall_2_865(MethodBind194, GodotObject.GetPtr(this), particles, &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind195 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetCustomAabb, 3696536120ul);

    /// <summary>
    /// <para>Sets a custom axis-aligned bounding box for the particle system. Equivalent to <see cref="Godot.GpuParticles3D.VisibilityAabb"/>.</para>
    /// </summary>
    public unsafe void ParticlesSetCustomAabb(Rid particles, Aabb aabb)
    {
        NativeCalls.godot_icall_2_1135(MethodBind195, GodotObject.GetPtr(this), particles, &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind196 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetSpeedScale, 1794382983ul);

    /// <summary>
    /// <para>Sets the speed scale of the particle system. Equivalent to <see cref="Godot.GpuParticles3D.SpeedScale"/>.</para>
    /// </summary>
    public void ParticlesSetSpeedScale(Rid particles, double scale)
    {
        NativeCalls.godot_icall_2_435(MethodBind196, GodotObject.GetPtr(this), particles, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind197 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetUseLocalCoordinates, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, particles use local coordinates. If <see langword="false"/> they use global coordinates. Equivalent to <see cref="Godot.GpuParticles3D.LocalCoords"/>.</para>
    /// </summary>
    public void ParticlesSetUseLocalCoordinates(Rid particles, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind197, GodotObject.GetPtr(this), particles, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind198 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetProcessMaterial, 395945892ul);

    /// <summary>
    /// <para>Sets the material for processing the particles.</para>
    /// <para><b>Note:</b> This is not the material used to draw the materials. Equivalent to <see cref="Godot.GpuParticles3D.ProcessMaterial"/>.</para>
    /// </summary>
    public void ParticlesSetProcessMaterial(Rid particles, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind198, GodotObject.GetPtr(this), particles, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind199 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetFixedFps, 3411492887ul);

    /// <summary>
    /// <para>Sets the frame rate that the particle system rendering will be fixed to. Equivalent to <see cref="Godot.GpuParticles3D.FixedFps"/>.</para>
    /// </summary>
    public void ParticlesSetFixedFps(Rid particles, int fps)
    {
        NativeCalls.godot_icall_2_426(MethodBind199, GodotObject.GetPtr(this), particles, fps);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind200 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetInterpolate, 1265174801ul);

    public void ParticlesSetInterpolate(Rid particles, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind200, GodotObject.GetPtr(this), particles, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind201 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetFractionalDelta, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, uses fractional delta which smooths the movement of the particles. Equivalent to <see cref="Godot.GpuParticles3D.FractDelta"/>.</para>
    /// </summary>
    public void ParticlesSetFractionalDelta(Rid particles, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind201, GodotObject.GetPtr(this), particles, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind202 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetCollisionBaseSize, 1794382983ul);

    public void ParticlesSetCollisionBaseSize(Rid particles, float size)
    {
        NativeCalls.godot_icall_2_816(MethodBind202, GodotObject.GetPtr(this), particles, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind203 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetTransformAlign, 3264971368ul);

    public void ParticlesSetTransformAlign(Rid particles, RenderingServer.ParticlesTransformAlign align)
    {
        NativeCalls.godot_icall_2_426(MethodBind203, GodotObject.GetPtr(this), particles, (int)align);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind204 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetTrails, 2010054925ul);

    /// <summary>
    /// <para>If <paramref name="enable"/> is <see langword="true"/>, enables trails for the <paramref name="particles"/> with the specified <paramref name="lengthSec"/> in seconds. Equivalent to <see cref="Godot.GpuParticles3D.TrailEnabled"/> and <see cref="Godot.GpuParticles3D.TrailLifetime"/>.</para>
    /// </summary>
    public void ParticlesSetTrails(Rid particles, bool enable, float lengthSec)
    {
        NativeCalls.godot_icall_3_1153(MethodBind204, GodotObject.GetPtr(this), particles, enable.ToGodotBool(), lengthSec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind205 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetTrailBindPoses, 684822712ul);

    public void ParticlesSetTrailBindPoses(Rid particles, Godot.Collections.Array<Transform3D> bindPoses)
    {
        NativeCalls.godot_icall_2_1122(MethodBind205, GodotObject.GetPtr(this), particles, (godot_array)(bindPoses ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind206 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesIsInactive, 3521089500ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if particles are not emitting and particles are set to inactive.</para>
    /// </summary>
    public bool ParticlesIsInactive(Rid particles)
    {
        return NativeCalls.godot_icall_1_421(MethodBind206, GodotObject.GetPtr(this), particles).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind207 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesRequestProcess, 2722037293ul);

    /// <summary>
    /// <para>Add particle system to list of particle systems that need to be updated. Update will take place on the next frame, or on the next call to <see cref="Godot.RenderingServerInstance.InstancesCullAabb(Aabb, Rid)"/>, <see cref="Godot.RenderingServerInstance.InstancesCullConvex(Godot.Collections.Array{Plane}, Rid)"/>, or <see cref="Godot.RenderingServerInstance.InstancesCullRay(Vector3, Vector3, Rid)"/>.</para>
    /// </summary>
    public void ParticlesRequestProcess(Rid particles)
    {
        NativeCalls.godot_icall_1_286(MethodBind207, GodotObject.GetPtr(this), particles);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind208 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesRestart, 2722037293ul);

    /// <summary>
    /// <para>Reset the particles on the next update. Equivalent to <see cref="Godot.GpuParticles3D.Restart(bool)"/>.</para>
    /// </summary>
    public void ParticlesRestart(Rid particles)
    {
        NativeCalls.godot_icall_1_286(MethodBind208, GodotObject.GetPtr(this), particles);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind209 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetSubemitter, 395945892ul);

    public void ParticlesSetSubemitter(Rid particles, Rid subemitterParticles)
    {
        NativeCalls.godot_icall_2_430(MethodBind209, GodotObject.GetPtr(this), particles, subemitterParticles);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind210 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesEmit, 4043136117ul);

    /// <summary>
    /// <para>Manually emits particles from the <paramref name="particles"/> instance.</para>
    /// </summary>
    public unsafe void ParticlesEmit(Rid particles, Transform3D transform, Vector3 velocity, Color color, Color custom, uint emitFlags)
    {
        NativeCalls.godot_icall_6_1154(MethodBind210, GodotObject.GetPtr(this), particles, &transform, &velocity, &color, &custom, emitFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind211 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetDrawOrder, 935028487ul);

    /// <summary>
    /// <para>Sets the draw order of the particles. Equivalent to <see cref="Godot.GpuParticles3D.DrawOrder"/>.</para>
    /// </summary>
    public void ParticlesSetDrawOrder(Rid particles, RenderingServer.ParticlesDrawOrder order)
    {
        NativeCalls.godot_icall_2_426(MethodBind211, GodotObject.GetPtr(this), particles, (int)order);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind212 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetDrawPasses, 3411492887ul);

    /// <summary>
    /// <para>Sets the number of draw passes to use. Equivalent to <see cref="Godot.GpuParticles3D.DrawPasses"/>.</para>
    /// </summary>
    public void ParticlesSetDrawPasses(Rid particles, int count)
    {
        NativeCalls.godot_icall_2_426(MethodBind212, GodotObject.GetPtr(this), particles, count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind213 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetDrawPassMesh, 2310537182ul);

    /// <summary>
    /// <para>Sets the mesh to be used for the specified draw pass. Equivalent to <see cref="Godot.GpuParticles3D.DrawPass1"/>, <see cref="Godot.GpuParticles3D.DrawPass2"/>, <see cref="Godot.GpuParticles3D.DrawPass3"/>, and <see cref="Godot.GpuParticles3D.DrawPass4"/>.</para>
    /// </summary>
    public void ParticlesSetDrawPassMesh(Rid particles, int pass, Rid mesh)
    {
        NativeCalls.godot_icall_3_833(MethodBind213, GodotObject.GetPtr(this), particles, pass, mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind214 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesGetCurrentAabb, 3952830260ul);

    /// <summary>
    /// <para>Calculates and returns the axis-aligned bounding box that contains all the particles. Equivalent to <see cref="Godot.GpuParticles3D.CaptureAabb()"/>.</para>
    /// </summary>
    public Aabb ParticlesGetCurrentAabb(Rid particles)
    {
        return NativeCalls.godot_icall_1_876(MethodBind214, GodotObject.GetPtr(this), particles);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind215 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetEmissionTransform, 3935195649ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform3D"/> that will be used by the particles when they first emit.</para>
    /// </summary>
    public unsafe void ParticlesSetEmissionTransform(Rid particles, Transform3D transform)
    {
        NativeCalls.godot_icall_2_873(MethodBind215, GodotObject.GetPtr(this), particles, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind216 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new 3D GPU particle collision or attractor and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID can be used in most <c>particles_collision_*</c> RenderingServer functions.</para>
    /// <para><b>Note:</b> The equivalent nodes are <see cref="Godot.GpuParticlesCollision3D"/> and <see cref="Godot.GpuParticlesAttractor3D"/>.</para>
    /// </summary>
    public Rid ParticlesCollisionCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind216, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind217 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetCollisionType, 1497044930ul);

    /// <summary>
    /// <para>Sets the collision or attractor shape <paramref name="type"/> for the 3D GPU particles collision or attractor specified by the <paramref name="particlesCollision"/> RID.</para>
    /// </summary>
    public void ParticlesCollisionSetCollisionType(Rid particlesCollision, RenderingServer.ParticlesCollisionType type)
    {
        NativeCalls.godot_icall_2_426(MethodBind217, GodotObject.GetPtr(this), particlesCollision, (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind218 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the cull <paramref name="mask"/> for the 3D GPU particles collision or attractor specified by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollision3D.CullMask"/> or <see cref="Godot.GpuParticlesAttractor3D.CullMask"/> depending on the <paramref name="particlesCollision"/> type.</para>
    /// </summary>
    public void ParticlesCollisionSetCullMask(Rid particlesCollision, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind218, GodotObject.GetPtr(this), particlesCollision, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind219 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetSphereRadius, 1794382983ul);

    /// <summary>
    /// <para>Sets the <paramref name="radius"/> for the 3D GPU particles sphere collision or attractor specified by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollisionSphere3D.Radius"/> or <see cref="Godot.GpuParticlesAttractorSphere3D.Radius"/> depending on the <paramref name="particlesCollision"/> type.</para>
    /// </summary>
    public void ParticlesCollisionSetSphereRadius(Rid particlesCollision, float radius)
    {
        NativeCalls.godot_icall_2_816(MethodBind219, GodotObject.GetPtr(this), particlesCollision, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind220 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetBoxExtents, 3227306858ul);

    /// <summary>
    /// <para>Sets the <paramref name="extents"/> for the 3D GPU particles collision by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollisionBox3D.Size"/>, <see cref="Godot.GpuParticlesCollisionSdf3D.Size"/>, <see cref="Godot.GpuParticlesCollisionHeightField3D.Size"/>, <see cref="Godot.GpuParticlesAttractorBox3D.Size"/> or <see cref="Godot.GpuParticlesAttractorVectorField3D.Size"/> depending on the <paramref name="particlesCollision"/> type.</para>
    /// </summary>
    public unsafe void ParticlesCollisionSetBoxExtents(Rid particlesCollision, Vector3 extents)
    {
        NativeCalls.godot_icall_2_865(MethodBind220, GodotObject.GetPtr(this), particlesCollision, &extents);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind221 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetAttractorStrength, 1794382983ul);

    /// <summary>
    /// <para>Sets the <paramref name="strength"/> for the 3D GPU particles attractor specified by the <paramref name="particlesCollision"/> RID. Only used for attractors, not colliders. Equivalent to <see cref="Godot.GpuParticlesAttractor3D.Strength"/>.</para>
    /// </summary>
    public void ParticlesCollisionSetAttractorStrength(Rid particlesCollision, float strength)
    {
        NativeCalls.godot_icall_2_816(MethodBind221, GodotObject.GetPtr(this), particlesCollision, strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind222 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetAttractorDirectionality, 1794382983ul);

    /// <summary>
    /// <para>Sets the directionality <paramref name="amount"/> for the 3D GPU particles attractor specified by the <paramref name="particlesCollision"/> RID. Only used for attractors, not colliders. Equivalent to <see cref="Godot.GpuParticlesAttractor3D.Directionality"/>.</para>
    /// </summary>
    public void ParticlesCollisionSetAttractorDirectionality(Rid particlesCollision, float amount)
    {
        NativeCalls.godot_icall_2_816(MethodBind222, GodotObject.GetPtr(this), particlesCollision, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind223 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetAttractorAttenuation, 1794382983ul);

    /// <summary>
    /// <para>Sets the attenuation <paramref name="curve"/> for the 3D GPU particles attractor specified by the <paramref name="particlesCollision"/> RID. Only used for attractors, not colliders. Equivalent to <see cref="Godot.GpuParticlesAttractor3D.Attenuation"/>.</para>
    /// </summary>
    public void ParticlesCollisionSetAttractorAttenuation(Rid particlesCollision, float curve)
    {
        NativeCalls.godot_icall_2_816(MethodBind223, GodotObject.GetPtr(this), particlesCollision, curve);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind224 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetFieldTexture, 395945892ul);

    /// <summary>
    /// <para>Sets the signed distance field <paramref name="texture"/> for the 3D GPU particles collision specified by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollisionSdf3D.Texture"/> or <see cref="Godot.GpuParticlesAttractorVectorField3D.Texture"/> depending on the <paramref name="particlesCollision"/> type.</para>
    /// </summary>
    public void ParticlesCollisionSetFieldTexture(Rid particlesCollision, Rid texture)
    {
        NativeCalls.godot_icall_2_430(MethodBind224, GodotObject.GetPtr(this), particlesCollision, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind225 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionHeightFieldUpdate, 2722037293ul);

    /// <summary>
    /// <para>Requests an update for the 3D GPU particle collision heightfield. This may be automatically called by the 3D GPU particle collision heightfield depending on its <see cref="Godot.GpuParticlesCollisionHeightField3D.UpdateMode"/>.</para>
    /// </summary>
    public void ParticlesCollisionHeightFieldUpdate(Rid particlesCollision)
    {
        NativeCalls.godot_icall_1_286(MethodBind225, GodotObject.GetPtr(this), particlesCollision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind226 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetHeightFieldResolution, 962977297ul);

    /// <summary>
    /// <para>Sets the heightmap <paramref name="resolution"/> for the 3D GPU particles heightfield collision specified by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollisionHeightField3D.Resolution"/>.</para>
    /// </summary>
    public void ParticlesCollisionSetHeightFieldResolution(Rid particlesCollision, RenderingServer.ParticlesCollisionHeightfieldResolution resolution)
    {
        NativeCalls.godot_icall_2_426(MethodBind226, GodotObject.GetPtr(this), particlesCollision, (int)resolution);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind227 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetHeightFieldMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the heightfield <paramref name="mask"/> for the 3D GPU particles heightfield collision specified by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollisionHeightField3D.HeightfieldMask"/>.</para>
    /// </summary>
    public void ParticlesCollisionSetHeightFieldMask(Rid particlesCollision, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind227, GodotObject.GetPtr(this), particlesCollision, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind228 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FogVolumeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new fog volume and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>fog_volume_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.FogVolume"/>.</para>
    /// </summary>
    public Rid FogVolumeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind228, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind229 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FogVolumeSetShape, 3818703106ul);

    /// <summary>
    /// <para>Sets the shape of the fog volume to either <see cref="Godot.RenderingServer.FogVolumeShape.Ellipsoid"/>, <see cref="Godot.RenderingServer.FogVolumeShape.Cone"/>, <see cref="Godot.RenderingServer.FogVolumeShape.Cylinder"/>, <see cref="Godot.RenderingServer.FogVolumeShape.Box"/> or <see cref="Godot.RenderingServer.FogVolumeShape.World"/>.</para>
    /// </summary>
    public void FogVolumeSetShape(Rid fogVolume, RenderingServer.FogVolumeShape shape)
    {
        NativeCalls.godot_icall_2_426(MethodBind229, GodotObject.GetPtr(this), fogVolume, (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind230 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FogVolumeSetSize, 3227306858ul);

    /// <summary>
    /// <para>Sets the size of the fog volume when shape is <see cref="Godot.RenderingServer.FogVolumeShape.Ellipsoid"/>, <see cref="Godot.RenderingServer.FogVolumeShape.Cone"/>, <see cref="Godot.RenderingServer.FogVolumeShape.Cylinder"/> or <see cref="Godot.RenderingServer.FogVolumeShape.Box"/>.</para>
    /// </summary>
    public unsafe void FogVolumeSetSize(Rid fogVolume, Vector3 size)
    {
        NativeCalls.godot_icall_2_865(MethodBind230, GodotObject.GetPtr(this), fogVolume, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind231 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FogVolumeSetMaterial, 395945892ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Material"/> of the fog volume. Can be either a <see cref="Godot.FogMaterial"/> or a custom <see cref="Godot.ShaderMaterial"/>.</para>
    /// </summary>
    public void FogVolumeSetMaterial(Rid fogVolume, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind231, GodotObject.GetPtr(this), fogVolume, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind232 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VisibilityNotifierCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new 3D visibility notifier object and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>visibility_notifier_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this notifier to an instance using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.VisibleOnScreenNotifier3D"/>.</para>
    /// </summary>
    public Rid VisibilityNotifierCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind232, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind233 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VisibilityNotifierSetAabb, 3696536120ul);

    public unsafe void VisibilityNotifierSetAabb(Rid notifier, Aabb aabb)
    {
        NativeCalls.godot_icall_2_1135(MethodBind233, GodotObject.GetPtr(this), notifier, &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind234 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VisibilityNotifierSetCallbacks, 2689735388ul);

    public void VisibilityNotifierSetCallbacks(Rid notifier, Callable enterCallable, Callable exitCallable)
    {
        NativeCalls.godot_icall_3_1155(MethodBind234, GodotObject.GetPtr(this), notifier, enterCallable, exitCallable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind235 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OccluderCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an occluder instance and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>occluder_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Occluder3D"/> (not to be confused with the <see cref="Godot.OccluderInstance3D"/> node).</para>
    /// </summary>
    public Rid OccluderCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind235, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind236 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OccluderSetMesh, 3854404263ul);

    /// <summary>
    /// <para>Sets the mesh data for the given occluder RID, which controls the shape of the occlusion culling that will be performed.</para>
    /// </summary>
    public void OccluderSetMesh(Rid occluder, Vector3[] vertices, int[] indices)
    {
        NativeCalls.godot_icall_3_1156(MethodBind236, GodotObject.GetPtr(this), occluder, vertices, indices);
    }

    /// <summary>
    /// <para>Sets the mesh data for the given occluder RID, which controls the shape of the occlusion culling that will be performed.</para>
    /// </summary>
    public void OccluderSetMesh(Rid occluder, ReadOnlySpan<Vector3> vertices, ReadOnlySpan<int> indices)
    {
        NativeCalls.godot_icall_3_1156(MethodBind236, GodotObject.GetPtr(this), occluder, vertices, indices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind237 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D camera and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>camera_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.Camera3D"/>.</para>
    /// </summary>
    public Rid CameraCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind237, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind238 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetPerspective, 157498339ul);

    /// <summary>
    /// <para>Sets camera to use perspective projection. Objects on the screen becomes smaller when they are far away.</para>
    /// </summary>
    public void CameraSetPerspective(Rid camera, float fovyDegrees, float zNear, float zFar)
    {
        NativeCalls.godot_icall_4_1157(MethodBind238, GodotObject.GetPtr(this), camera, fovyDegrees, zNear, zFar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind239 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetOrthogonal, 157498339ul);

    /// <summary>
    /// <para>Sets camera to use orthogonal projection, also known as orthographic projection. Objects remain the same size on the screen no matter how far away they are.</para>
    /// </summary>
    public void CameraSetOrthogonal(Rid camera, float size, float zNear, float zFar)
    {
        NativeCalls.godot_icall_4_1157(MethodBind239, GodotObject.GetPtr(this), camera, size, zNear, zFar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind240 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetFrustum, 1889878953ul);

    /// <summary>
    /// <para>Sets camera to use frustum projection. This mode allows adjusting the <paramref name="offset"/> argument to create "tilted frustum" effects.</para>
    /// </summary>
    public unsafe void CameraSetFrustum(Rid camera, float size, Vector2 offset, float zNear, float zFar)
    {
        NativeCalls.godot_icall_5_1158(MethodBind240, GodotObject.GetPtr(this), camera, size, &offset, zNear, zFar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind241 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetTransform, 3935195649ul);

    /// <summary>
    /// <para>Sets <see cref="Godot.Transform3D"/> of camera.</para>
    /// </summary>
    public unsafe void CameraSetTransform(Rid camera, Transform3D transform)
    {
        NativeCalls.godot_icall_2_873(MethodBind241, GodotObject.GetPtr(this), camera, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind242 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the cull mask associated with this camera. The cull mask describes which 3D layers are rendered by this camera. Equivalent to <see cref="Godot.Camera3D.CullMask"/>.</para>
    /// </summary>
    public void CameraSetCullMask(Rid camera, uint layers)
    {
        NativeCalls.godot_icall_2_856(MethodBind242, GodotObject.GetPtr(this), camera, layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind243 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetEnvironment, 395945892ul);

    /// <summary>
    /// <para>Sets the environment used by this camera. Equivalent to <see cref="Godot.Camera3D.Environment"/>.</para>
    /// </summary>
    public void CameraSetEnvironment(Rid camera, Rid env)
    {
        NativeCalls.godot_icall_2_430(MethodBind243, GodotObject.GetPtr(this), camera, env);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind244 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetCameraAttributes, 395945892ul);

    /// <summary>
    /// <para>Sets the camera_attributes created with <see cref="Godot.RenderingServerInstance.CameraAttributesCreate()"/> to the given camera.</para>
    /// </summary>
    public void CameraSetCameraAttributes(Rid camera, Rid effects)
    {
        NativeCalls.godot_icall_2_430(MethodBind244, GodotObject.GetPtr(this), camera, effects);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind245 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetCompositor, 395945892ul);

    /// <summary>
    /// <para>Sets the compositor used by this camera. Equivalent to <see cref="Godot.Camera3D.Compositor"/>.</para>
    /// </summary>
    public void CameraSetCompositor(Rid camera, Rid compositor)
    {
        NativeCalls.godot_icall_2_430(MethodBind245, GodotObject.GetPtr(this), camera, compositor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind246 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetUseVerticalAspect, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, preserves the horizontal aspect ratio which is equivalent to <see cref="Godot.Camera3D.KeepAspectEnum.Width"/>. If <see langword="false"/>, preserves the vertical aspect ratio which is equivalent to <see cref="Godot.Camera3D.KeepAspectEnum.Height"/>.</para>
    /// </summary>
    public void CameraSetUseVerticalAspect(Rid camera, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind246, GodotObject.GetPtr(this), camera, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind247 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an empty viewport and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>viewport_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.Viewport"/>.</para>
    /// </summary>
    public Rid ViewportCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind247, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind248 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUseXR, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport uses augmented or virtual reality technologies. See <see cref="Godot.XRInterface"/>.</para>
    /// </summary>
    public void ViewportSetUseXR(Rid viewport, bool useXR)
    {
        NativeCalls.godot_icall_2_434(MethodBind248, GodotObject.GetPtr(this), viewport, useXR.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind249 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetSize, 4288446313ul);

    /// <summary>
    /// <para>Sets the viewport's width and height in pixels.</para>
    /// </summary>
    public void ViewportSetSize(Rid viewport, int width, int height)
    {
        NativeCalls.godot_icall_3_433(MethodBind249, GodotObject.GetPtr(this), viewport, width, height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind250 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetActive, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, sets the viewport active, else sets it inactive.</para>
    /// </summary>
    public void ViewportSetActive(Rid viewport, bool active)
    {
        NativeCalls.godot_icall_2_434(MethodBind250, GodotObject.GetPtr(this), viewport, active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind251 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetParentViewport, 395945892ul);

    /// <summary>
    /// <para>Sets the viewport's parent to the viewport specified by the <paramref name="parentViewport"/> RID.</para>
    /// </summary>
    public void ViewportSetParentViewport(Rid viewport, Rid parentViewport)
    {
        NativeCalls.godot_icall_2_430(MethodBind251, GodotObject.GetPtr(this), viewport, parentViewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind252 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportAttachToScreen, 1062245816ul);

    /// <summary>
    /// <para>Copies the viewport to a region of the screen specified by <paramref name="rect"/>. If <see cref="Godot.RenderingServerInstance.ViewportSetRenderDirectToScreen(Rid, bool)"/> is <see langword="true"/>, then the viewport does not use a framebuffer and the contents of the viewport are rendered directly to screen. However, note that the root viewport is drawn last, therefore it will draw over the screen. Accordingly, you must set the root viewport to an area that does not cover the area that you have attached this viewport to.</para>
    /// <para>For example, you can set the root viewport to not render at all with the following code:</para>
    /// <para></para>
    /// <para>Using this can result in significant optimization, especially on lower-end devices. However, it comes at the cost of having to manage your viewports manually. For further optimization, see <see cref="Godot.RenderingServerInstance.ViewportSetRenderDirectToScreen(Rid, bool)"/>.</para>
    /// </summary>
    /// <param name="rect">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    public unsafe void ViewportAttachToScreen(Rid viewport, Nullable<Rect2> rect = null, int screen = 0)
    {
        Rect2 rectOrDefVal = rect.HasValue ? rect.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_3_1159(MethodBind252, GodotObject.GetPtr(this), viewport, &rectOrDefVal, screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind253 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetRenderDirectToScreen, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, render the contents of the viewport directly to screen. This allows a low-level optimization where you can skip drawing a viewport to the root viewport. While this optimization can result in a significant increase in speed (especially on older devices), it comes at a cost of usability. When this is enabled, you cannot read from the viewport or from the screen_texture. You also lose the benefit of certain window settings, such as the various stretch modes. Another consequence to be aware of is that in 2D the rendering happens in window coordinates, so if you have a viewport that is double the size of the window, and you set this, then only the portion that fits within the window will be drawn, no automatic scaling is possible, even if your game scene is significantly larger than the window size.</para>
    /// </summary>
    public void ViewportSetRenderDirectToScreen(Rid viewport, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind253, GodotObject.GetPtr(this), viewport, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind254 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetCanvasCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the rendering mask associated with this <see cref="Godot.Viewport"/>. Only <see cref="Godot.CanvasItem"/> nodes with a matching rendering visibility layer will be rendered by this <see cref="Godot.Viewport"/>.</para>
    /// </summary>
    public void ViewportSetCanvasCullMask(Rid viewport, uint canvasCullMask)
    {
        NativeCalls.godot_icall_2_856(MethodBind254, GodotObject.GetPtr(this), viewport, canvasCullMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind255 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetScaling3DMode, 2386524376ul);

    /// <summary>
    /// <para>Sets the 3D resolution scaling mode. Bilinear scaling renders at different resolution to either undersample or supersample the viewport. FidelityFX Super Resolution 1.0, abbreviated to FSR, is an upscaling technology that produces high quality images at fast framerates by using a spatially aware upscaling algorithm. FSR is slightly more expensive than bilinear, but it produces significantly higher image quality. FSR should be used where possible.</para>
    /// </summary>
    public void ViewportSetScaling3DMode(Rid viewport, RenderingServer.ViewportScaling3DMode scaling3DMode)
    {
        NativeCalls.godot_icall_2_426(MethodBind255, GodotObject.GetPtr(this), viewport, (int)scaling3DMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind256 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetScaling3DScale, 1794382983ul);

    /// <summary>
    /// <para>Scales the 3D render buffer based on the viewport size uses an image filter specified in <see cref="Godot.RenderingServer.ViewportScaling3DMode"/> to scale the output image to the full viewport size. Values lower than <c>1.0</c> can be used to speed up 3D rendering at the cost of quality (undersampling). Values greater than <c>1.0</c> are only valid for bilinear mode and can be used to improve 3D rendering quality at a high performance cost (supersampling). See also <see cref="Godot.RenderingServer.ViewportMsaa"/> for multi-sample antialiasing, which is significantly cheaper but only smoothens the edges of polygons.</para>
    /// <para>When using FSR upscaling, AMD recommends exposing the following values as preset options to users "Ultra Quality: 0.77", "Quality: 0.67", "Balanced: 0.59", "Performance: 0.5" instead of exposing the entire scale.</para>
    /// </summary>
    public void ViewportSetScaling3DScale(Rid viewport, float scale)
    {
        NativeCalls.godot_icall_2_816(MethodBind256, GodotObject.GetPtr(this), viewport, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind257 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetFsrSharpness, 1794382983ul);

    /// <summary>
    /// <para>Determines how sharp the upscaled image will be when using the FSR upscaling mode. Sharpness halves with every whole number. Values go from 0.0 (sharpest) to 2.0. Values above 2.0 won't make a visible difference.</para>
    /// </summary>
    public void ViewportSetFsrSharpness(Rid viewport, float sharpness)
    {
        NativeCalls.godot_icall_2_816(MethodBind257, GodotObject.GetPtr(this), viewport, sharpness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind258 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetTextureMipmapBias, 1794382983ul);

    /// <summary>
    /// <para>Affects the final texture sharpness by reading from a lower or higher mipmap (also called "texture LOD bias"). Negative values make mipmapped textures sharper but grainier when viewed at a distance, while positive values make mipmapped textures blurrier (even when up close). To get sharper textures at a distance without introducing too much graininess, set this between <c>-0.75</c> and <c>0.0</c>. Enabling temporal antialiasing (<c>ProjectSettings.rendering/anti_aliasing/quality/use_taa</c>) can help reduce the graininess visible when using negative mipmap bias.</para>
    /// <para><b>Note:</b> When the 3D scaling mode is set to FSR 1.0, this value is used to adjust the automatic mipmap bias which is calculated internally based on the scale factor. The formula for this is <c>-log2(1.0 / scale) + mipmap_bias</c>.</para>
    /// </summary>
    public void ViewportSetTextureMipmapBias(Rid viewport, float mipmapBias)
    {
        NativeCalls.godot_icall_2_816(MethodBind258, GodotObject.GetPtr(this), viewport, mipmapBias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind259 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetAnisotropicFilteringLevel, 3953214029ul);

    /// <summary>
    /// <para>Sets the maximum number of samples to take when using anisotropic filtering on textures (as a power of two). A higher sample count will result in sharper textures at oblique angles, but is more expensive to compute. A value of <c>0</c> forcibly disables anisotropic filtering, even on materials where it is enabled.</para>
    /// <para>The anisotropic filtering level also affects decals and light projectors if they are configured to use anisotropic filtering. See <c>ProjectSettings.rendering/textures/decals/filter</c> and <c>ProjectSettings.rendering/textures/light_projectors/filter</c>.</para>
    /// <para><b>Note:</b> In 3D, for this setting to have an effect, set <see cref="Godot.BaseMaterial3D.TextureFilter"/> to <see cref="Godot.BaseMaterial3D.TextureFilterEnum.LinearWithMipmapsAnisotropic"/> or <see cref="Godot.BaseMaterial3D.TextureFilterEnum.NearestWithMipmapsAnisotropic"/> on materials.</para>
    /// <para><b>Note:</b> In 2D, for this setting to have an effect, set <see cref="Godot.CanvasItem.TextureFilter"/> to <see cref="Godot.CanvasItem.TextureFilterEnum.LinearWithMipmapsAnisotropic"/> or <see cref="Godot.CanvasItem.TextureFilterEnum.NearestWithMipmapsAnisotropic"/> on the <see cref="Godot.CanvasItem"/> node displaying the texture (or in <see cref="Godot.CanvasTexture"/>). However, anisotropic filtering is rarely useful in 2D, so only enable it for textures in 2D if it makes a meaningful visual difference.</para>
    /// </summary>
    public void ViewportSetAnisotropicFilteringLevel(Rid viewport, RenderingServer.ViewportAnisotropicFiltering anisotropicFilteringLevel)
    {
        NativeCalls.godot_icall_2_426(MethodBind259, GodotObject.GetPtr(this), viewport, (int)anisotropicFilteringLevel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind260 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUpdateMode, 3161116010ul);

    /// <summary>
    /// <para>Sets when the viewport should be updated.</para>
    /// </summary>
    public void ViewportSetUpdateMode(Rid viewport, RenderingServer.ViewportUpdateMode updateMode)
    {
        NativeCalls.godot_icall_2_426(MethodBind260, GodotObject.GetPtr(this), viewport, (int)updateMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind261 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetUpdateMode, 3803901472ul);

    /// <summary>
    /// <para>Returns the viewport's update mode.</para>
    /// <para><b>Warning:</b> Calling this from any thread other than the rendering thread will be detrimental to performance.</para>
    /// </summary>
    public RenderingServer.ViewportUpdateMode ViewportGetUpdateMode(Rid viewport)
    {
        return (RenderingServer.ViewportUpdateMode)NativeCalls.godot_icall_1_835(MethodBind261, GodotObject.GetPtr(this), viewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind262 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetClearMode, 3628367896ul);

    /// <summary>
    /// <para>Sets the clear mode of a viewport.</para>
    /// </summary>
    public void ViewportSetClearMode(Rid viewport, RenderingServer.ViewportClearMode clearMode)
    {
        NativeCalls.godot_icall_2_426(MethodBind262, GodotObject.GetPtr(this), viewport, (int)clearMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind263 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetRenderTarget, 3814569979ul);

    /// <summary>
    /// <para>Returns the render target for the viewport.</para>
    /// </summary>
    public Rid ViewportGetRenderTarget(Rid viewport)
    {
        return NativeCalls.godot_icall_1_855(MethodBind263, GodotObject.GetPtr(this), viewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind264 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetTexture, 3814569979ul);

    /// <summary>
    /// <para>Returns the viewport's last rendered frame.</para>
    /// </summary>
    public Rid ViewportGetTexture(Rid viewport)
    {
        return NativeCalls.godot_icall_1_855(MethodBind264, GodotObject.GetPtr(this), viewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind265 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetDisable3D, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport's 3D elements are not rendered.</para>
    /// </summary>
    public void ViewportSetDisable3D(Rid viewport, bool disable)
    {
        NativeCalls.godot_icall_2_434(MethodBind265, GodotObject.GetPtr(this), viewport, disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind266 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetDisable2D, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport's canvas (i.e. 2D and GUI elements) is not rendered.</para>
    /// </summary>
    public void ViewportSetDisable2D(Rid viewport, bool disable)
    {
        NativeCalls.godot_icall_2_434(MethodBind266, GodotObject.GetPtr(this), viewport, disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind267 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetEnvironmentMode, 2196892182ul);

    /// <summary>
    /// <para>Sets the viewport's environment mode which allows enabling or disabling rendering of 3D environment over 2D canvas. When disabled, 2D will not be affected by the environment. When enabled, 2D will be affected by the environment if the environment background mode is <see cref="Godot.RenderingServer.EnvironmentBG.Canvas"/>. The default behavior is to inherit the setting from the viewport's parent. If the topmost parent is also set to <see cref="Godot.RenderingServer.ViewportEnvironmentMode.Inherit"/>, then the behavior will be the same as if it was set to <see cref="Godot.RenderingServer.ViewportEnvironmentMode.Enabled"/>.</para>
    /// </summary>
    public void ViewportSetEnvironmentMode(Rid viewport, RenderingServer.ViewportEnvironmentMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind267, GodotObject.GetPtr(this), viewport, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind268 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportAttachCamera, 395945892ul);

    /// <summary>
    /// <para>Sets a viewport's camera.</para>
    /// </summary>
    public void ViewportAttachCamera(Rid viewport, Rid camera)
    {
        NativeCalls.godot_icall_2_430(MethodBind268, GodotObject.GetPtr(this), viewport, camera);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind269 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetScenario, 395945892ul);

    /// <summary>
    /// <para>Sets a viewport's scenario. The scenario contains information about environment information, reflection atlas, etc.</para>
    /// </summary>
    public void ViewportSetScenario(Rid viewport, Rid scenario)
    {
        NativeCalls.godot_icall_2_430(MethodBind269, GodotObject.GetPtr(this), viewport, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind270 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportAttachCanvas, 395945892ul);

    /// <summary>
    /// <para>Sets a viewport's canvas.</para>
    /// </summary>
    public void ViewportAttachCanvas(Rid viewport, Rid canvas)
    {
        NativeCalls.godot_icall_2_430(MethodBind270, GodotObject.GetPtr(this), viewport, canvas);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind271 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportRemoveCanvas, 395945892ul);

    /// <summary>
    /// <para>Detaches a viewport from a canvas.</para>
    /// </summary>
    public void ViewportRemoveCanvas(Rid viewport, Rid canvas)
    {
        NativeCalls.godot_icall_2_430(MethodBind271, GodotObject.GetPtr(this), viewport, canvas);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind272 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetSnap2DTransformsToPixel, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, canvas item transforms (i.e. origin position) are snapped to the nearest pixel when rendering. This can lead to a crisper appearance at the cost of less smooth movement, especially when <see cref="Godot.Camera2D"/> smoothing is enabled. Equivalent to <c>ProjectSettings.rendering/2d/snap/snap_2d_transforms_to_pixel</c>.</para>
    /// </summary>
    public void ViewportSetSnap2DTransformsToPixel(Rid viewport, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind272, GodotObject.GetPtr(this), viewport, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind273 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetSnap2DVerticesToPixel, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, canvas item vertices (i.e. polygon points) are snapped to the nearest pixel when rendering. This can lead to a crisper appearance at the cost of less smooth movement, especially when <see cref="Godot.Camera2D"/> smoothing is enabled. Equivalent to <c>ProjectSettings.rendering/2d/snap/snap_2d_vertices_to_pixel</c>.</para>
    /// </summary>
    public void ViewportSetSnap2DVerticesToPixel(Rid viewport, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind273, GodotObject.GetPtr(this), viewport, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind274 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetDefaultCanvasItemTextureFilter, 1155129294ul);

    /// <summary>
    /// <para>Sets the default texture filtering mode for the specified <paramref name="viewport"/> RID.</para>
    /// </summary>
    public void ViewportSetDefaultCanvasItemTextureFilter(Rid viewport, RenderingServer.CanvasItemTextureFilter filter)
    {
        NativeCalls.godot_icall_2_426(MethodBind274, GodotObject.GetPtr(this), viewport, (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind275 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetDefaultCanvasItemTextureRepeat, 1652956681ul);

    /// <summary>
    /// <para>Sets the default texture repeat mode for the specified <paramref name="viewport"/> RID.</para>
    /// </summary>
    public void ViewportSetDefaultCanvasItemTextureRepeat(Rid viewport, RenderingServer.CanvasItemTextureRepeat repeat)
    {
        NativeCalls.godot_icall_2_426(MethodBind275, GodotObject.GetPtr(this), viewport, (int)repeat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind276 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetCanvasTransform, 3608606053ul);

    /// <summary>
    /// <para>Sets the transformation of a viewport's canvas.</para>
    /// </summary>
    public unsafe void ViewportSetCanvasTransform(Rid viewport, Rid canvas, Transform2D offset)
    {
        NativeCalls.godot_icall_3_1160(MethodBind276, GodotObject.GetPtr(this), viewport, canvas, &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind277 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetCanvasStacking, 3713930247ul);

    /// <summary>
    /// <para>Sets the stacking order for a viewport's canvas.</para>
    /// <para><paramref name="layer"/> is the actual canvas layer, while <paramref name="sublayer"/> specifies the stacking order of the canvas among those in the same layer.</para>
    /// <para><b>Note:</b> <paramref name="layer"/> should be between <see cref="Godot.RenderingServer.CanvasLayerMin"/> and <see cref="Godot.RenderingServer.CanvasLayerMax"/> (inclusive). Any other value will wrap around.</para>
    /// </summary>
    public void ViewportSetCanvasStacking(Rid viewport, Rid canvas, int layer, int sublayer)
    {
        NativeCalls.godot_icall_4_1161(MethodBind277, GodotObject.GetPtr(this), viewport, canvas, layer, sublayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind278 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetTransparentBackground, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport renders its background as transparent.</para>
    /// </summary>
    public void ViewportSetTransparentBackground(Rid viewport, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind278, GodotObject.GetPtr(this), viewport, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind279 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetGlobalCanvasTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets the viewport's global transformation matrix.</para>
    /// </summary>
    public unsafe void ViewportSetGlobalCanvasTransform(Rid viewport, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind279, GodotObject.GetPtr(this), viewport, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind280 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetSdfOversizeAndScale, 1329198632ul);

    /// <summary>
    /// <para>Sets the viewport's 2D signed distance field <c>ProjectSettings.rendering/2d/sdf/oversize</c> and <c>ProjectSettings.rendering/2d/sdf/scale</c>. This is used when sampling the signed distance field in <see cref="Godot.CanvasItem"/> shaders as well as <see cref="Godot.GpuParticles2D"/> collision. This is <i>not</i> used by SDFGI in 3D rendering.</para>
    /// </summary>
    public void ViewportSetSdfOversizeAndScale(Rid viewport, RenderingServer.ViewportSdfOversize oversize, RenderingServer.ViewportSdfScale scale)
    {
        NativeCalls.godot_icall_3_433(MethodBind280, GodotObject.GetPtr(this), viewport, (int)oversize, (int)scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind281 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetPositionalShadowAtlasSize, 1904426712ul);

    /// <summary>
    /// <para>Sets the <paramref name="size"/> of the shadow atlas's images (used for omni and spot lights) on the viewport specified by the <paramref name="viewport"/> RID. The value is rounded up to the nearest power of 2. If <paramref name="use16Bits"/> is <see langword="true"/>, use 16 bits for the omni/spot shadow depth map. Enabling this results in shadows having less precision and may result in shadow acne, but can lead to performance improvements on some devices.</para>
    /// <para><b>Note:</b> If this is set to <c>0</c>, no positional shadows will be visible at all. This can improve performance significantly on low-end systems by reducing both the CPU and GPU load (as fewer draw calls are needed to draw the scene without shadows).</para>
    /// </summary>
    public void ViewportSetPositionalShadowAtlasSize(Rid viewport, int size, bool use16Bits = false)
    {
        NativeCalls.godot_icall_3_439(MethodBind281, GodotObject.GetPtr(this), viewport, size, use16Bits.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind282 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetPositionalShadowAtlasQuadrantSubdivision, 4288446313ul);

    /// <summary>
    /// <para>Sets the number of subdivisions to use in the specified shadow atlas <paramref name="quadrant"/> for omni and spot shadows. See also <see cref="Godot.Viewport.SetPositionalShadowAtlasQuadrantSubdiv(int, Viewport.PositionalShadowAtlasQuadrantSubdiv)"/>.</para>
    /// </summary>
    public void ViewportSetPositionalShadowAtlasQuadrantSubdivision(Rid viewport, int quadrant, int subdivision)
    {
        NativeCalls.godot_icall_3_433(MethodBind282, GodotObject.GetPtr(this), viewport, quadrant, subdivision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind283 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetMsaa3D, 3764433340ul);

    /// <summary>
    /// <para>Sets the multisample antialiasing mode for 3D on the specified <paramref name="viewport"/> RID. Equivalent to <c>ProjectSettings.rendering/anti_aliasing/quality/msaa_3d</c> or <see cref="Godot.Viewport.Msaa3D"/>.</para>
    /// </summary>
    public void ViewportSetMsaa3D(Rid viewport, RenderingServer.ViewportMsaa msaa)
    {
        NativeCalls.godot_icall_2_426(MethodBind283, GodotObject.GetPtr(this), viewport, (int)msaa);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind284 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetMsaa2D, 3764433340ul);

    /// <summary>
    /// <para>Sets the multisample antialiasing mode for 2D/Canvas on the specified <paramref name="viewport"/> RID. Equivalent to <c>ProjectSettings.rendering/anti_aliasing/quality/msaa_2d</c> or <see cref="Godot.Viewport.Msaa2D"/>.</para>
    /// </summary>
    public void ViewportSetMsaa2D(Rid viewport, RenderingServer.ViewportMsaa msaa)
    {
        NativeCalls.godot_icall_2_426(MethodBind284, GodotObject.GetPtr(this), viewport, (int)msaa);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind285 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUseHdr2D, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, 2D rendering will use a high dynamic range (HDR) <c>RGBA16</c> format framebuffer. Additionally, 2D rendering will be performed on linear values and will be converted using the appropriate transfer function immediately before blitting to the screen (if the Viewport is attached to the screen).</para>
    /// <para>Practically speaking, this means that the end result of the Viewport will not be clamped to the <c>0-1</c> range and can be used in 3D rendering without color encoding adjustments. This allows 2D rendering to take advantage of effects requiring high dynamic range (e.g. 2D glow) as well as substantially improves the appearance of effects requiring highly detailed gradients. This setting has the same effect as <see cref="Godot.Viewport.UseHdr2D"/>.</para>
    /// </summary>
    public void ViewportSetUseHdr2D(Rid viewport, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind285, GodotObject.GetPtr(this), viewport, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind286 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetScreenSpaceAA, 1447279591ul);

    /// <summary>
    /// <para>Sets the viewport's screen-space antialiasing mode. Equivalent to <c>ProjectSettings.rendering/anti_aliasing/quality/screen_space_aa</c> or <see cref="Godot.Viewport.ScreenSpaceAA"/>.</para>
    /// </summary>
    public void ViewportSetScreenSpaceAA(Rid viewport, RenderingServer.ViewportScreenSpaceAA mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind286, GodotObject.GetPtr(this), viewport, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind287 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUseTaa, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, use temporal antialiasing. Equivalent to <c>ProjectSettings.rendering/anti_aliasing/quality/use_taa</c> or <see cref="Godot.Viewport.UseTaa"/>.</para>
    /// </summary>
    public void ViewportSetUseTaa(Rid viewport, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind287, GodotObject.GetPtr(this), viewport, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind288 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUseDebanding, 1265174801ul);

    /// <summary>
    /// <para>Equivalent to <see cref="Godot.Viewport.UseDebanding"/>. See also <c>ProjectSettings.rendering/anti_aliasing/quality/use_debanding</c>.</para>
    /// </summary>
    public void ViewportSetUseDebanding(Rid viewport, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind288, GodotObject.GetPtr(this), viewport, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind289 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUseOcclusionCulling, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, enables occlusion culling on the specified viewport. Equivalent to <c>ProjectSettings.rendering/occlusion_culling/use_occlusion_culling</c>.</para>
    /// </summary>
    public void ViewportSetUseOcclusionCulling(Rid viewport, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind289, GodotObject.GetPtr(this), viewport, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind290 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetOcclusionRaysPerThread, 1286410249ul);

    /// <summary>
    /// <para>Sets the <c>ProjectSettings.rendering/occlusion_culling/occlusion_rays_per_thread</c> to use for occlusion culling. This parameter is global and cannot be set on a per-viewport basis.</para>
    /// </summary>
    public void ViewportSetOcclusionRaysPerThread(int raysPerThread)
    {
        NativeCalls.godot_icall_1_38(MethodBind290, GodotObject.GetPtr(this), raysPerThread);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind291 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetOcclusionCullingBuildQuality, 2069725696ul);

    /// <summary>
    /// <para>Sets the <c>ProjectSettings.rendering/occlusion_culling/bvh_build_quality</c> to use for occlusion culling. This parameter is global and cannot be set on a per-viewport basis.</para>
    /// </summary>
    public void ViewportSetOcclusionCullingBuildQuality(RenderingServer.ViewportOcclusionCullingBuildQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind291, GodotObject.GetPtr(this), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind292 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetRenderInfo, 2041262392ul);

    /// <summary>
    /// <para>Returns a statistic about the rendering engine which can be used for performance profiling. This is separated into render pass <paramref name="type"/>s, each of them having the same <paramref name="info"/>s you can query (different passes will return different values).</para>
    /// <para>See also <see cref="Godot.RenderingServerInstance.GetRenderingInfo(RenderingServer.RenderingInfo)"/>, which returns global information across all viewports.</para>
    /// <para><b>Note:</b> Viewport rendering information is not available until at least 2 frames have been rendered by the engine. If rendering information is not available, <see cref="Godot.RenderingServerInstance.ViewportGetRenderInfo(Rid, RenderingServer.ViewportRenderInfoType, RenderingServer.ViewportRenderInfo)"/> returns <c>0</c>. To print rendering information in <c>_ready()</c> successfully, use the following:</para>
    /// <para><code>
    /// func _ready():
    /// 	for _i in 2:
    /// 		await get_tree().process_frame
    /// 
    /// 	print(
    /// 			RenderingServer.viewport_get_render_info(get_viewport().get_viewport_rid(),
    /// 			RenderingServer.VIEWPORT_RENDER_INFO_TYPE_VISIBLE,
    /// 			RenderingServer.VIEWPORT_RENDER_INFO_DRAW_CALLS_IN_FRAME)
    /// 	)
    /// </code></para>
    /// </summary>
    public int ViewportGetRenderInfo(Rid viewport, RenderingServer.ViewportRenderInfoType type, RenderingServer.ViewportRenderInfo info)
    {
        return NativeCalls.godot_icall_3_1162(MethodBind292, GodotObject.GetPtr(this), viewport, (int)type, (int)info);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind293 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetDebugDraw, 2089420930ul);

    /// <summary>
    /// <para>Sets the debug draw mode of a viewport.</para>
    /// </summary>
    public void ViewportSetDebugDraw(Rid viewport, RenderingServer.ViewportDebugDraw draw)
    {
        NativeCalls.godot_icall_2_426(MethodBind293, GodotObject.GetPtr(this), viewport, (int)draw);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind294 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetMeasureRenderTime, 1265174801ul);

    /// <summary>
    /// <para>Sets the measurement for the given <paramref name="viewport"/> RID (obtained using <see cref="Godot.Viewport.GetViewportRid()"/>). Once enabled, <see cref="Godot.RenderingServerInstance.ViewportGetMeasuredRenderTimeCpu(Rid)"/> and <see cref="Godot.RenderingServerInstance.ViewportGetMeasuredRenderTimeGpu(Rid)"/> will return values greater than <c>0.0</c> when queried with the given <paramref name="viewport"/>.</para>
    /// </summary>
    public void ViewportSetMeasureRenderTime(Rid viewport, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind294, GodotObject.GetPtr(this), viewport, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind295 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetMeasuredRenderTimeCpu, 866169185ul);

    /// <summary>
    /// <para>Returns the CPU time taken to render the last frame in milliseconds. This <i>only</i> includes time spent in rendering-related operations; scripts' <c>_process</c> functions and other engine subsystems are not included in this readout. To get a complete readout of CPU time spent to render the scene, sum the render times of all viewports that are drawn every frame plus <see cref="Godot.RenderingServerInstance.GetFrameSetupTimeCpu()"/>. Unlike <see cref="Godot.Engine.GetFramesPerSecond()"/>, this method will accurately reflect CPU utilization even if framerate is capped via V-Sync or <see cref="Godot.Engine.MaxFps"/>. See also <see cref="Godot.RenderingServerInstance.ViewportGetMeasuredRenderTimeGpu(Rid)"/>.</para>
    /// <para><b>Note:</b> Requires measurements to be enabled on the specified <paramref name="viewport"/> using <see cref="Godot.RenderingServerInstance.ViewportSetMeasureRenderTime(Rid, bool)"/>. Otherwise, this method returns <c>0.0</c>.</para>
    /// </summary>
    public double ViewportGetMeasuredRenderTimeCpu(Rid viewport)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind295, GodotObject.GetPtr(this), viewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind296 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetMeasuredRenderTimeGpu, 866169185ul);

    /// <summary>
    /// <para>Returns the GPU time taken to render the last frame in milliseconds. To get a complete readout of GPU time spent to render the scene, sum the render times of all viewports that are drawn every frame. Unlike <see cref="Godot.Engine.GetFramesPerSecond()"/>, this method accurately reflects GPU utilization even if framerate is capped via V-Sync or <see cref="Godot.Engine.MaxFps"/>. See also <see cref="Godot.RenderingServerInstance.ViewportGetMeasuredRenderTimeCpu(Rid)"/>.</para>
    /// <para><b>Note:</b> Requires measurements to be enabled on the specified <paramref name="viewport"/> using <see cref="Godot.RenderingServerInstance.ViewportSetMeasureRenderTime(Rid, bool)"/>. Otherwise, this method returns <c>0.0</c>.</para>
    /// <para><b>Note:</b> When GPU utilization is low enough during a certain period of time, GPUs will decrease their power state (which in turn decreases core and memory clock speeds). This can cause the reported GPU time to increase if GPU utilization is kept low enough by a framerate cap (compared to what it would be at the GPU's highest power state). Keep this in mind when benchmarking using <see cref="Godot.RenderingServerInstance.ViewportGetMeasuredRenderTimeGpu(Rid)"/>. This behavior can be overridden in the graphics driver settings at the cost of higher power usage.</para>
    /// </summary>
    public double ViewportGetMeasuredRenderTimeGpu(Rid viewport)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind296, GodotObject.GetPtr(this), viewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind297 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetVrsMode, 398809874ul);

    /// <summary>
    /// <para>Sets the Variable Rate Shading (VRS) mode for the viewport. If the GPU does not support VRS, this property is ignored. Equivalent to <c>ProjectSettings.rendering/vrs/mode</c>.</para>
    /// </summary>
    public void ViewportSetVrsMode(Rid viewport, RenderingServer.ViewportVrsMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind297, GodotObject.GetPtr(this), viewport, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind298 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetVrsUpdateMode, 2696154815ul);

    /// <summary>
    /// <para>Sets the update mode for Variable Rate Shading (VRS) for the viewport. VRS requires the input texture to be converted to the format usable by the VRS method supported by the hardware. The update mode defines how often this happens. If the GPU does not support VRS, or VRS is not enabled, this property is ignored.</para>
    /// <para>If set to <see cref="Godot.RenderingServer.ViewportVrsUpdateMode.Once"/>, the input texture is copied once and the mode is changed to <see cref="Godot.RenderingServer.ViewportVrsUpdateMode.Disabled"/>.</para>
    /// </summary>
    public void ViewportSetVrsUpdateMode(Rid viewport, RenderingServer.ViewportVrsUpdateMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind298, GodotObject.GetPtr(this), viewport, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind299 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetVrsTexture, 395945892ul);

    /// <summary>
    /// <para>The texture to use when the VRS mode is set to <see cref="Godot.RenderingServer.ViewportVrsMode.Texture"/>. Equivalent to <c>ProjectSettings.rendering/vrs/texture</c>.</para>
    /// </summary>
    public void ViewportSetVrsTexture(Rid viewport, Rid texture)
    {
        NativeCalls.godot_icall_2_430(MethodBind299, GodotObject.GetPtr(this), viewport, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind300 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkyCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an empty sky and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>sky_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// </summary>
    public Rid SkyCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind300, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind301 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkySetRadianceSize, 3411492887ul);

    /// <summary>
    /// <para>Sets the <paramref name="radianceSize"/> of the sky specified by the <paramref name="sky"/> RID (in pixels). Equivalent to <see cref="Godot.Sky.RadianceSize"/>.</para>
    /// </summary>
    public void SkySetRadianceSize(Rid sky, int radianceSize)
    {
        NativeCalls.godot_icall_2_426(MethodBind301, GodotObject.GetPtr(this), sky, radianceSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind302 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkySetMode, 3279019937ul);

    /// <summary>
    /// <para>Sets the process <paramref name="mode"/> of the sky specified by the <paramref name="sky"/> RID. Equivalent to <see cref="Godot.Sky.ProcessMode"/>.</para>
    /// </summary>
    public void SkySetMode(Rid sky, RenderingServer.SkyMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind302, GodotObject.GetPtr(this), sky, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind303 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkySetMaterial, 395945892ul);

    /// <summary>
    /// <para>Sets the material that the sky uses to render the background, ambient and reflection maps.</para>
    /// </summary>
    public void SkySetMaterial(Rid sky, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind303, GodotObject.GetPtr(this), sky, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind304 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkyBakePanorama, 3875285818ul);

    /// <summary>
    /// <para>Generates and returns an <see cref="Godot.Image"/> containing the radiance map for the specified <paramref name="sky"/> RID. This supports built-in sky material and custom sky shaders. If <paramref name="bakeIrradiance"/> is <see langword="true"/>, the irradiance map is saved instead of the radiance map. The radiance map is used to render reflected light, while the irradiance map is used to render ambient light. See also <see cref="Godot.RenderingServerInstance.EnvironmentBakePanorama(Rid, bool, Vector2I)"/>.</para>
    /// <para><b>Note:</b> The image is saved using linear encoding without any tonemapping performed, which means it will look too dark if viewed directly in an image editor. <paramref name="energy"/> values above <c>1.0</c> can be used to brighten the resulting image.</para>
    /// <para><b>Note:</b> <paramref name="size"/> should be a 2:1 aspect ratio for the generated panorama to have square pixels. For radiance maps, there is no point in using a height greater than <see cref="Godot.Sky.RadianceSize"/>, as it won't increase detail. Irradiance maps only contain low-frequency data, so there is usually no point in going past a size of 128×64 pixels when saving an irradiance map.</para>
    /// </summary>
    public unsafe Image SkyBakePanorama(Rid sky, float energy, bool bakeIrradiance, Vector2I size)
    {
        return (Image)NativeCalls.godot_icall_4_1164(MethodBind304, GodotObject.GetPtr(this), sky, energy, bakeIrradiance.ToGodotBool(), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind305 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorEffectCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new rendering effect and adds it to the RenderingServer. It can be accessed with the RID that is returned.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// </summary>
    public Rid CompositorEffectCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind305, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind306 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorEffectSetEnabled, 1265174801ul);

    /// <summary>
    /// <para>Enables/disables this rendering effect.</para>
    /// </summary>
    public void CompositorEffectSetEnabled(Rid effect, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind306, GodotObject.GetPtr(this), effect, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind307 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorEffectSetCallback, 487412485ul);

    /// <summary>
    /// <para>Sets the callback type (<paramref name="callbackType"/>) and callback method(<paramref name="callback"/>) for this rendering effect.</para>
    /// </summary>
    public void CompositorEffectSetCallback(Rid effect, RenderingServer.CompositorEffectCallbackType callbackType, Callable callback)
    {
        NativeCalls.godot_icall_3_431(MethodBind307, GodotObject.GetPtr(this), effect, (int)callbackType, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind308 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorEffectSetFlag, 3659527075ul);

    /// <summary>
    /// <para>Sets the flag (<paramref name="flag"/>) for this rendering effect to <see langword="true"/> or <see langword="false"/> (<paramref name="set"/>).</para>
    /// </summary>
    public void CompositorEffectSetFlag(Rid effect, RenderingServer.CompositorEffectFlags flag, bool set)
    {
        NativeCalls.godot_icall_3_439(MethodBind308, GodotObject.GetPtr(this), effect, (int)flag, set.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind309 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new compositor and adds it to the RenderingServer. It can be accessed with the RID that is returned.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// </summary>
    public Rid CompositorCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind309, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind310 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorSetCompositorEffects, 684822712ul);

    /// <summary>
    /// <para>Sets the compositor effects for the specified compositor RID. <paramref name="effects"/> should be an array containing RIDs created with <see cref="Godot.RenderingServerInstance.CompositorEffectCreate()"/>.</para>
    /// </summary>
    public void CompositorSetCompositorEffects(Rid compositor, Godot.Collections.Array<Rid> effects)
    {
        NativeCalls.godot_icall_2_1122(MethodBind310, GodotObject.GetPtr(this), compositor, (godot_array)(effects ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind311 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an environment and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>environment_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Environment"/>.</para>
    /// </summary>
    public Rid EnvironmentCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind311, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind312 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetBackground, 3937328877ul);

    /// <summary>
    /// <para>Sets the environment's background mode. Equivalent to <see cref="Godot.Environment.BackgroundMode"/>.</para>
    /// </summary>
    public void EnvironmentSetBackground(Rid env, RenderingServer.EnvironmentBG bg)
    {
        NativeCalls.godot_icall_2_426(MethodBind312, GodotObject.GetPtr(this), env, (int)bg);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind313 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetCameraId, 3411492887ul);

    /// <summary>
    /// <para>Sets the camera ID to be used as environment background.</para>
    /// </summary>
    public void EnvironmentSetCameraId(Rid env, int id)
    {
        NativeCalls.godot_icall_2_426(MethodBind313, GodotObject.GetPtr(this), env, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind314 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSky, 395945892ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Sky"/> to be used as the environment's background when using <i>BGMode</i> sky. Equivalent to <see cref="Godot.Environment.Sky"/>.</para>
    /// </summary>
    public void EnvironmentSetSky(Rid env, Rid sky)
    {
        NativeCalls.godot_icall_2_430(MethodBind314, GodotObject.GetPtr(this), env, sky);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind315 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSkyCustomFov, 1794382983ul);

    /// <summary>
    /// <para>Sets a custom field of view for the background <see cref="Godot.Sky"/>. Equivalent to <see cref="Godot.Environment.SkyCustomFov"/>.</para>
    /// </summary>
    public void EnvironmentSetSkyCustomFov(Rid env, float scale)
    {
        NativeCalls.godot_icall_2_816(MethodBind315, GodotObject.GetPtr(this), env, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind316 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSkyOrientation, 1735850857ul);

    /// <summary>
    /// <para>Sets the rotation of the background <see cref="Godot.Sky"/> expressed as a <see cref="Godot.Basis"/>. Equivalent to <see cref="Godot.Environment.SkyRotation"/>, where the rotation vector is used to construct the <see cref="Godot.Basis"/>.</para>
    /// </summary>
    public unsafe void EnvironmentSetSkyOrientation(Rid env, Basis orientation)
    {
        NativeCalls.godot_icall_2_1165(MethodBind316, GodotObject.GetPtr(this), env, &orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind317 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetBgColor, 2948539648ul);

    /// <summary>
    /// <para>Color displayed for clear areas of the scene. Only effective if using the <see cref="Godot.RenderingServer.EnvironmentBG.Color"/> background mode.</para>
    /// </summary>
    public unsafe void EnvironmentSetBgColor(Rid env, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind317, GodotObject.GetPtr(this), env, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind318 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetBgEnergy, 2513314492ul);

    /// <summary>
    /// <para>Sets the intensity of the background color.</para>
    /// </summary>
    public void EnvironmentSetBgEnergy(Rid env, float multiplier, float exposureValue)
    {
        NativeCalls.godot_icall_3_1145(MethodBind318, GodotObject.GetPtr(this), env, multiplier, exposureValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind319 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetCanvasMaxLayer, 3411492887ul);

    /// <summary>
    /// <para>Sets the maximum layer to use if using Canvas background mode.</para>
    /// </summary>
    public void EnvironmentSetCanvasMaxLayer(Rid env, int maxLayer)
    {
        NativeCalls.godot_icall_2_426(MethodBind319, GodotObject.GetPtr(this), env, maxLayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind320 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetAmbientLight, 1214961493ul);

    /// <summary>
    /// <para>Sets the values to be used for ambient light rendering. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public unsafe void EnvironmentSetAmbientLight(Rid env, Color color, RenderingServer.EnvironmentAmbientSource ambient = (RenderingServer.EnvironmentAmbientSource)(0), float energy = 1.0f, float skyContribution = 0.0f, RenderingServer.EnvironmentReflectionSource reflectionSource = (RenderingServer.EnvironmentReflectionSource)(0))
    {
        NativeCalls.godot_icall_6_1166(MethodBind320, GodotObject.GetPtr(this), env, &color, (int)ambient, energy, skyContribution, (int)reflectionSource);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind321 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetGlow, 2421724940ul);

    /// <summary>
    /// <para>Configures glow for the specified environment RID. See <c>glow_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    public void EnvironmentSetGlow(Rid env, bool enable, float[] levels, float intensity, float strength, float mix, float bloomThreshold, RenderingServer.EnvironmentGlowBlendMode blendMode, float hdrBleedThreshold, float hdrBleedScale, float hdrLuminanceCap, float glowMapStrength, Rid glowMap)
    {
        NativeCalls.godot_icall_13_1167(MethodBind321, GodotObject.GetPtr(this), env, enable.ToGodotBool(), levels, intensity, strength, mix, bloomThreshold, (int)blendMode, hdrBleedThreshold, hdrBleedScale, hdrLuminanceCap, glowMapStrength, glowMap);
    }

    /// <summary>
    /// <para>Configures glow for the specified environment RID. See <c>glow_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    public void EnvironmentSetGlow(Rid env, bool enable, ReadOnlySpan<float> levels, float intensity, float strength, float mix, float bloomThreshold, RenderingServer.EnvironmentGlowBlendMode blendMode, float hdrBleedThreshold, float hdrBleedScale, float hdrLuminanceCap, float glowMapStrength, Rid glowMap)
    {
        NativeCalls.godot_icall_13_1167(MethodBind321, GodotObject.GetPtr(this), env, enable.ToGodotBool(), levels, intensity, strength, mix, bloomThreshold, (int)blendMode, hdrBleedThreshold, hdrBleedScale, hdrLuminanceCap, glowMapStrength, glowMap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind322 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetTonemap, 2914312638ul);

    /// <summary>
    /// <para>Sets the variables to be used with the "tonemap" post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public void EnvironmentSetTonemap(Rid env, RenderingServer.EnvironmentToneMapper toneMapper, float exposure, float white)
    {
        NativeCalls.godot_icall_4_1168(MethodBind322, GodotObject.GetPtr(this), env, (int)toneMapper, exposure, white);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind323 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetTonemapAgxContrast, 1794382983ul);

    /// <summary>
    /// <para>See <see cref="Godot.Environment.TonemapAgxContrast"/> for more details.</para>
    /// </summary>
    public void EnvironmentSetTonemapAgxContrast(Rid env, float agxContrast)
    {
        NativeCalls.godot_icall_2_816(MethodBind323, GodotObject.GetPtr(this), env, agxContrast);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind324 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetAdjustment, 876799838ul);

    /// <summary>
    /// <para>Sets the values to be used with the "adjustments" post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public void EnvironmentSetAdjustment(Rid env, bool enable, float brightness, float contrast, float saturation, bool use1DColorCorrection, Rid colorCorrection)
    {
        NativeCalls.godot_icall_7_1169(MethodBind324, GodotObject.GetPtr(this), env, enable.ToGodotBool(), brightness, contrast, saturation, use1DColorCorrection.ToGodotBool(), colorCorrection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind325 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsr, 3607294374ul);

    /// <summary>
    /// <para>Sets the variables to be used with the screen-space reflections (SSR) post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public void EnvironmentSetSsr(Rid env, bool enable, int maxSteps, float fadeIn, float fadeOut, float depthTolerance)
    {
        NativeCalls.godot_icall_6_1170(MethodBind325, GodotObject.GetPtr(this), env, enable.ToGodotBool(), maxSteps, fadeIn, fadeOut, depthTolerance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind326 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsao, 3994732740ul);

    /// <summary>
    /// <para>Sets the variables to be used with the screen-space ambient occlusion (SSAO) post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public void EnvironmentSetSsao(Rid env, bool enable, float radius, float intensity, float power, float detail, float horizon, float sharpness, float lightAffect, float aOChannelAffect)
    {
        NativeCalls.godot_icall_10_1171(MethodBind326, GodotObject.GetPtr(this), env, enable.ToGodotBool(), radius, intensity, power, detail, horizon, sharpness, lightAffect, aOChannelAffect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind327 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetFog, 105051629ul);

    /// <summary>
    /// <para>Configures fog for the specified environment RID. See <c>fog_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    public unsafe void EnvironmentSetFog(Rid env, bool enable, Color lightColor, float lightEnergy, float sunScatter, float density, float height, float heightDensity, float aerialPerspective, float skyAffect, RenderingServer.EnvironmentFogMode fogMode = (RenderingServer.EnvironmentFogMode)(0))
    {
        NativeCalls.godot_icall_11_1172(MethodBind327, GodotObject.GetPtr(this), env, enable.ToGodotBool(), &lightColor, lightEnergy, sunScatter, density, height, heightDensity, aerialPerspective, skyAffect, (int)fogMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind328 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetFogDepth, 157498339ul);

    /// <summary>
    /// <para>Configures fog depth for the specified environment RID. Only has an effect when the fog mode of the environment is <see cref="Godot.RenderingServer.EnvironmentFogMode.Depth"/>. See <c>fog_depth_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    public void EnvironmentSetFogDepth(Rid env, float curve, float begin, float end)
    {
        NativeCalls.godot_icall_4_1157(MethodBind328, GodotObject.GetPtr(this), env, curve, begin, end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind329 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSdfgi, 3519144388ul);

    /// <summary>
    /// <para>Configures signed distance field global illumination for the specified environment RID. See <c>sdfgi_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    public void EnvironmentSetSdfgi(Rid env, bool enable, int cascades, float minCellSize, RenderingServer.EnvironmentSdfgiyScale yScale, bool useOcclusion, float bounceFeedback, bool readSky, float energy, float normalBias, float probeBias)
    {
        NativeCalls.godot_icall_11_1173(MethodBind329, GodotObject.GetPtr(this), env, enable.ToGodotBool(), cascades, minCellSize, (int)yScale, useOcclusion.ToGodotBool(), bounceFeedback, readSky.ToGodotBool(), energy, normalBias, probeBias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind330 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetVolumetricFog, 1553633833ul);

    /// <summary>
    /// <para>Sets the variables to be used with the volumetric fog post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public unsafe void EnvironmentSetVolumetricFog(Rid env, bool enable, float density, Color albedo, Color emission, float emissionEnergy, float anisotropy, float length, float pDetailSpread, float gIInject, bool temporalReprojection, float temporalReprojectionAmount, float ambientInject, float skyAffect)
    {
        NativeCalls.godot_icall_14_1174(MethodBind330, GodotObject.GetPtr(this), env, enable.ToGodotBool(), density, &albedo, &emission, emissionEnergy, anisotropy, length, pDetailSpread, gIInject, temporalReprojection.ToGodotBool(), temporalReprojectionAmount, ambientInject, skyAffect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind331 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentGlowSetUseBicubicUpscale, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="enable"/> is <see langword="true"/>, enables bicubic upscaling for glow which improves quality at the cost of performance. Equivalent to <c>ProjectSettings.rendering/environment/glow/upscale_mode</c>.</para>
    /// <para><b>Note:</b> This setting is only effective when using the Forward+ or Mobile rendering methods, as Compatibility uses a different glow implementation.</para>
    /// </summary>
    public void EnvironmentGlowSetUseBicubicUpscale(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind331, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind332 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsrHalfSize, 2586408642ul);

    /// <summary>
    /// <para>Sets whether screen-space reflections will be rendered at full or half size. Half size is faster, but may look pixelated or cause flickering.</para>
    /// </summary>
    public void EnvironmentSetSsrHalfSize(bool halfSize)
    {
        NativeCalls.godot_icall_1_14(MethodBind332, GodotObject.GetPtr(this), halfSize.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind333 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsrRoughnessQuality, 1190026788ul);

    [Obsolete("This option no longer does anything.")]
    public void EnvironmentSetSsrRoughnessQuality(RenderingServer.EnvironmentSsrRoughnessQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind333, GodotObject.GetPtr(this), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind334 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsaoQuality, 189753569ul);

    /// <summary>
    /// <para>Sets the quality level of the screen-space ambient occlusion (SSAO) post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public void EnvironmentSetSsaoQuality(RenderingServer.EnvironmentSsaoQuality quality, bool halfSize, float adaptiveTarget, int blurPasses, float fadeOutFrom, float fadeOutTo)
    {
        NativeCalls.godot_icall_6_1175(MethodBind334, GodotObject.GetPtr(this), (int)quality, halfSize.ToGodotBool(), adaptiveTarget, blurPasses, fadeOutFrom, fadeOutTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind335 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsilQuality, 1713836683ul);

    /// <summary>
    /// <para>Sets the quality level of the screen-space indirect lighting (SSIL) post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public void EnvironmentSetSsilQuality(RenderingServer.EnvironmentSsilQuality quality, bool halfSize, float adaptiveTarget, int blurPasses, float fadeOutFrom, float fadeOutTo)
    {
        NativeCalls.godot_icall_6_1175(MethodBind335, GodotObject.GetPtr(this), (int)quality, halfSize.ToGodotBool(), adaptiveTarget, blurPasses, fadeOutFrom, fadeOutTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind336 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSdfgiRayCount, 340137951ul);

    /// <summary>
    /// <para>Sets the number of rays to throw per frame when computing signed distance field global illumination. Equivalent to <c>ProjectSettings.rendering/global_illumination/sdfgi/probe_ray_count</c>.</para>
    /// </summary>
    public void EnvironmentSetSdfgiRayCount(RenderingServer.EnvironmentSdfgiRayCount rayCount)
    {
        NativeCalls.godot_icall_1_38(MethodBind336, GodotObject.GetPtr(this), (int)rayCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind337 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSdfgiFramesToConverge, 2182444374ul);

    /// <summary>
    /// <para>Sets the number of frames to use for converging signed distance field global illumination. Equivalent to <c>ProjectSettings.rendering/global_illumination/sdfgi/frames_to_converge</c>.</para>
    /// </summary>
    public void EnvironmentSetSdfgiFramesToConverge(RenderingServer.EnvironmentSdfgiFramesToConverge frames)
    {
        NativeCalls.godot_icall_1_38(MethodBind337, GodotObject.GetPtr(this), (int)frames);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind338 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSdfgiFramesToUpdateLight, 1251144068ul);

    /// <summary>
    /// <para>Sets the update speed for dynamic lights' indirect lighting when computing signed distance field global illumination. Equivalent to <c>ProjectSettings.rendering/global_illumination/sdfgi/frames_to_update_lights</c>.</para>
    /// </summary>
    public void EnvironmentSetSdfgiFramesToUpdateLight(RenderingServer.EnvironmentSdfgiFramesToUpdateLight frames)
    {
        NativeCalls.godot_icall_1_38(MethodBind338, GodotObject.GetPtr(this), (int)frames);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind339 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetVolumetricFogVolumeSize, 3937882851ul);

    /// <summary>
    /// <para>Sets the resolution of the volumetric fog's froxel buffer. <paramref name="size"/> is modified by the screen's aspect ratio and then used to set the width and height of the buffer. While <paramref name="depth"/> is directly used to set the depth of the buffer.</para>
    /// </summary>
    public void EnvironmentSetVolumetricFogVolumeSize(int size, int depth)
    {
        NativeCalls.godot_icall_2_59(MethodBind339, GodotObject.GetPtr(this), size, depth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind340 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetVolumetricFogFilterActive, 2586408642ul);

    /// <summary>
    /// <para>Enables filtering of the volumetric fog scattering buffer. This results in much smoother volumes with very few under-sampling artifacts.</para>
    /// </summary>
    public void EnvironmentSetVolumetricFogFilterActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind340, GodotObject.GetPtr(this), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind341 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentBakePanorama, 2452908646ul);

    /// <summary>
    /// <para>Generates and returns an <see cref="Godot.Image"/> containing the radiance map for the specified <paramref name="environment"/> RID's sky. This supports built-in sky material and custom sky shaders. If <paramref name="bakeIrradiance"/> is <see langword="true"/>, the irradiance map is saved instead of the radiance map. The radiance map is used to render reflected light, while the irradiance map is used to render ambient light. See also <see cref="Godot.RenderingServerInstance.SkyBakePanorama(Rid, float, bool, Vector2I)"/>.</para>
    /// <para><b>Note:</b> The image is saved using linear encoding without any tonemapping performed, which means it will look too dark if viewed directly in an image editor.</para>
    /// <para><b>Note:</b> <paramref name="size"/> should be a 2:1 aspect ratio for the generated panorama to have square pixels. For radiance maps, there is no point in using a height greater than <see cref="Godot.Sky.RadianceSize"/>, as it won't increase detail. Irradiance maps only contain low-frequency data, so there is usually no point in going past a size of 128×64 pixels when saving an irradiance map.</para>
    /// </summary>
    public unsafe Image EnvironmentBakePanorama(Rid environment, bool bakeIrradiance, Vector2I size)
    {
        return (Image)NativeCalls.godot_icall_3_1176(MethodBind341, GodotObject.GetPtr(this), environment, bakeIrradiance.ToGodotBool(), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind342 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenSpaceRoughnessLimiterSetActive, 916716790ul);

    /// <summary>
    /// <para>Sets the screen-space roughness limiter parameters, such as whether it should be enabled and its thresholds. Equivalent to <c>ProjectSettings.rendering/anti_aliasing/screen_space_roughness_limiter/enabled</c>, <c>ProjectSettings.rendering/anti_aliasing/screen_space_roughness_limiter/amount</c> and <c>ProjectSettings.rendering/anti_aliasing/screen_space_roughness_limiter/limit</c>.</para>
    /// </summary>
    public void ScreenSpaceRoughnessLimiterSetActive(bool enable, float amount, float limit)
    {
        NativeCalls.godot_icall_3_1177(MethodBind342, GodotObject.GetPtr(this), enable.ToGodotBool(), amount, limit);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind343 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SubSurfaceScatteringSetQuality, 64571803ul);

    /// <summary>
    /// <para>Sets <c>ProjectSettings.rendering/environment/subsurface_scattering/subsurface_scattering_quality</c> to use when rendering materials that have subsurface scattering enabled.</para>
    /// </summary>
    public void SubSurfaceScatteringSetQuality(RenderingServer.SubSurfaceScatteringQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind343, GodotObject.GetPtr(this), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind344 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SubSurfaceScatteringSetScale, 1017552074ul);

    /// <summary>
    /// <para>Sets the <c>ProjectSettings.rendering/environment/subsurface_scattering/subsurface_scattering_scale</c> and <c>ProjectSettings.rendering/environment/subsurface_scattering/subsurface_scattering_depth_scale</c> to use when rendering materials that have subsurface scattering enabled.</para>
    /// </summary>
    public void SubSurfaceScatteringSetScale(float scale, float depthScale)
    {
        NativeCalls.godot_icall_2_1178(MethodBind344, GodotObject.GetPtr(this), scale, depthScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind345 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a camera attributes object and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>camera_attributes_</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.CameraAttributes"/>.</para>
    /// </summary>
    public Rid CameraAttributesCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind345, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind346 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesSetDofBlurQuality, 2220136795ul);

    /// <summary>
    /// <para>Sets the quality level of the DOF blur effect to <paramref name="quality"/>. <paramref name="useJitter"/> can be used to jitter samples taken during the blur pass to hide artifacts at the cost of looking more fuzzy.</para>
    /// </summary>
    public void CameraAttributesSetDofBlurQuality(RenderingServer.DofBlurQuality quality, bool useJitter)
    {
        NativeCalls.godot_icall_2_61(MethodBind346, GodotObject.GetPtr(this), (int)quality, useJitter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind347 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesSetDofBlurBokehShape, 1205058394ul);

    /// <summary>
    /// <para>Sets the shape of the DOF bokeh pattern to <paramref name="shape"/>. Different shapes may be used to achieve artistic effect, or to meet performance targets.</para>
    /// </summary>
    public void CameraAttributesSetDofBlurBokehShape(RenderingServer.DofBokehShape shape)
    {
        NativeCalls.godot_icall_1_38(MethodBind347, GodotObject.GetPtr(this), (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind348 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesSetDofBlur, 316272616ul);

    /// <summary>
    /// <para>Sets the parameters to use with the DOF blur effect. These parameters take on the same meaning as their counterparts in <see cref="Godot.CameraAttributesPractical"/>.</para>
    /// </summary>
    public void CameraAttributesSetDofBlur(Rid cameraAttributes, bool farEnable, float farDistance, float farTransition, bool nearEnable, float nearDistance, float nearTransition, float amount)
    {
        NativeCalls.godot_icall_8_1179(MethodBind348, GodotObject.GetPtr(this), cameraAttributes, farEnable.ToGodotBool(), farDistance, farTransition, nearEnable.ToGodotBool(), nearDistance, nearTransition, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind349 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesSetExposure, 2513314492ul);

    /// <summary>
    /// <para>Sets the exposure values that will be used by the renderers. The normalization amount is used to bake a given Exposure Value (EV) into rendering calculations to reduce the dynamic range of the scene.</para>
    /// <para>The normalization factor can be calculated from exposure value (EV100) as follows:</para>
    /// <para><code>
    /// func get_exposure_normalization(ev100: float):
    /// 	return 1.0 / (pow(2.0, ev100) * 1.2)
    /// </code></para>
    /// <para>The exposure value can be calculated from aperture (in f-stops), shutter speed (in seconds), and sensitivity (in ISO) as follows:</para>
    /// <para><code>
    /// func get_exposure(aperture: float, shutter_speed: float, sensitivity: float):
    /// 	return log((aperture * aperture) / shutter_speed * (100.0 / sensitivity)) / log(2)
    /// </code></para>
    /// </summary>
    public void CameraAttributesSetExposure(Rid cameraAttributes, float multiplier, float normalization)
    {
        NativeCalls.godot_icall_3_1145(MethodBind349, GodotObject.GetPtr(this), cameraAttributes, multiplier, normalization);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind350 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesSetAutoExposure, 4266986332ul);

    /// <summary>
    /// <para>Sets the parameters to use with the auto-exposure effect. These parameters take on the same meaning as their counterparts in <see cref="Godot.CameraAttributes"/> and <see cref="Godot.CameraAttributesPractical"/>.</para>
    /// </summary>
    public void CameraAttributesSetAutoExposure(Rid cameraAttributes, bool enable, float minSensitivity, float maxSensitivity, float speed, float scale)
    {
        NativeCalls.godot_icall_6_1180(MethodBind350, GodotObject.GetPtr(this), cameraAttributes, enable.ToGodotBool(), minSensitivity, maxSensitivity, speed, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind351 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScenarioCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a scenario and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>scenario_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>The scenario is the 3D world that all the visual instances exist in.</para>
    /// </summary>
    public Rid ScenarioCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind351, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind352 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScenarioSetEnvironment, 395945892ul);

    /// <summary>
    /// <para>Sets the environment that will be used with this scenario. See also <see cref="Godot.Environment"/>.</para>
    /// </summary>
    public void ScenarioSetEnvironment(Rid scenario, Rid environment)
    {
        NativeCalls.godot_icall_2_430(MethodBind352, GodotObject.GetPtr(this), scenario, environment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind353 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScenarioSetFallbackEnvironment, 395945892ul);

    /// <summary>
    /// <para>Sets the fallback environment to be used by this scenario. The fallback environment is used if no environment is set. Internally, this is used by the editor to provide a default environment.</para>
    /// </summary>
    public void ScenarioSetFallbackEnvironment(Rid scenario, Rid environment)
    {
        NativeCalls.godot_icall_2_430(MethodBind353, GodotObject.GetPtr(this), scenario, environment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind354 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScenarioSetCameraAttributes, 395945892ul);

    /// <summary>
    /// <para>Sets the camera attributes (<paramref name="effects"/>) that will be used with this scenario. See also <see cref="Godot.CameraAttributes"/>.</para>
    /// </summary>
    public void ScenarioSetCameraAttributes(Rid scenario, Rid effects)
    {
        NativeCalls.godot_icall_2_430(MethodBind354, GodotObject.GetPtr(this), scenario, effects);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind355 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScenarioSetCompositor, 395945892ul);

    /// <summary>
    /// <para>Sets the compositor (<paramref name="compositor"/>) that will be used with this scenario. See also <see cref="Godot.Compositor"/>.</para>
    /// </summary>
    public void ScenarioSetCompositor(Rid scenario, Rid compositor)
    {
        NativeCalls.godot_icall_2_430(MethodBind355, GodotObject.GetPtr(this), scenario, compositor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind356 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceCreate2, 746547085ul);

    /// <summary>
    /// <para>Creates a visual instance, adds it to the RenderingServer, and sets both base and scenario. It can be accessed with the RID that is returned. This RID will be used in all <c>instance_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method. This is a shorthand for using <see cref="Godot.RenderingServerInstance.InstanceCreate()"/> and setting the base and scenario manually.</para>
    /// </summary>
    public Rid InstanceCreate2(Rid @base, Rid scenario)
    {
        return NativeCalls.godot_icall_2_1181(MethodBind356, GodotObject.GetPtr(this), @base, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind357 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a visual instance and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>instance_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>An instance is a way of placing a 3D object in the scenario. Objects like particles, meshes, reflection probes and decals need to be associated with an instance to be visible in the scenario using <see cref="Godot.RenderingServerInstance.InstanceSetBase(Rid, Rid)"/>.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.VisualInstance3D"/>.</para>
    /// </summary>
    public Rid InstanceCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind357, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind358 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetBase, 395945892ul);

    /// <summary>
    /// <para>Sets the base of the instance. A base can be any of the 3D objects that are created in the RenderingServer that can be displayed. For example, any of the light types, mesh, multimesh, particle system, reflection probe, decal, lightmap, voxel GI and visibility notifiers are all types that can be set as the base of an instance in order to be displayed in the scenario.</para>
    /// </summary>
    public void InstanceSetBase(Rid instance, Rid @base)
    {
        NativeCalls.godot_icall_2_430(MethodBind358, GodotObject.GetPtr(this), instance, @base);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind359 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetScenario, 395945892ul);

    /// <summary>
    /// <para>Sets the scenario that the instance is in. The scenario is the 3D world that the objects will be displayed in.</para>
    /// </summary>
    public void InstanceSetScenario(Rid instance, Rid scenario)
    {
        NativeCalls.godot_icall_2_430(MethodBind359, GodotObject.GetPtr(this), instance, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind360 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetLayerMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the render layers that this instance will be drawn to. Equivalent to <see cref="Godot.VisualInstance3D.Layers"/>.</para>
    /// </summary>
    public void InstanceSetLayerMask(Rid instance, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind360, GodotObject.GetPtr(this), instance, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind361 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetPivotData, 1280615259ul);

    /// <summary>
    /// <para>Sets the sorting offset and switches between using the bounding box or instance origin for depth sorting.</para>
    /// </summary>
    public void InstanceSetPivotData(Rid instance, float sortingOffset, bool useAabbCenter)
    {
        NativeCalls.godot_icall_3_1182(MethodBind361, GodotObject.GetPtr(this), instance, sortingOffset, useAabbCenter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind362 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetTransform, 3935195649ul);

    /// <summary>
    /// <para>Sets the world space transform of the instance. Equivalent to <see cref="Godot.Node3D.GlobalTransform"/>.</para>
    /// </summary>
    public unsafe void InstanceSetTransform(Rid instance, Transform3D transform)
    {
        NativeCalls.godot_icall_2_873(MethodBind362, GodotObject.GetPtr(this), instance, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind363 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceAttachObjectInstanceId, 3411492887ul);

    /// <summary>
    /// <para>Attaches a unique Object ID to instance. Object ID must be attached to instance for proper culling with <see cref="Godot.RenderingServerInstance.InstancesCullAabb(Aabb, Rid)"/>, <see cref="Godot.RenderingServerInstance.InstancesCullConvex(Godot.Collections.Array{Plane}, Rid)"/>, and <see cref="Godot.RenderingServerInstance.InstancesCullRay(Vector3, Vector3, Rid)"/>.</para>
    /// </summary>
    public void InstanceAttachObjectInstanceId(Rid instance, ulong id)
    {
        NativeCalls.godot_icall_2_852(MethodBind363, GodotObject.GetPtr(this), instance, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind364 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetBlendShapeWeight, 1892459533ul);

    /// <summary>
    /// <para>Sets the weight for a given blend shape associated with this instance.</para>
    /// </summary>
    public void InstanceSetBlendShapeWeight(Rid instance, int shape, float weight)
    {
        NativeCalls.godot_icall_3_988(MethodBind364, GodotObject.GetPtr(this), instance, shape, weight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind365 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetSurfaceOverrideMaterial, 2310537182ul);

    /// <summary>
    /// <para>Sets the override material of a specific surface. Equivalent to <see cref="Godot.MeshInstance3D.SetSurfaceOverrideMaterial(int, Material)"/>.</para>
    /// </summary>
    public void InstanceSetSurfaceOverrideMaterial(Rid instance, int surface, Rid material)
    {
        NativeCalls.godot_icall_3_833(MethodBind365, GodotObject.GetPtr(this), instance, surface, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind366 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetVisible, 1265174801ul);

    /// <summary>
    /// <para>Sets whether an instance is drawn or not. Equivalent to <see cref="Godot.Node3D.Visible"/>.</para>
    /// </summary>
    public void InstanceSetVisible(Rid instance, bool visible)
    {
        NativeCalls.godot_icall_2_434(MethodBind366, GodotObject.GetPtr(this), instance, visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind367 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetTransparency, 1794382983ul);

    /// <summary>
    /// <para>Sets the transparency for the given geometry instance. Equivalent to <see cref="Godot.GeometryInstance3D.Transparency"/>.</para>
    /// <para>A transparency of <c>0.0</c> is fully opaque, while <c>1.0</c> is fully transparent. Values greater than <c>0.0</c> (exclusive) will force the geometry's materials to go through the transparent pipeline, which is slower to render and can exhibit rendering issues due to incorrect transparency sorting. However, unlike using a transparent material, setting <paramref name="transparency"/> to a value greater than <c>0.0</c> (exclusive) will <i>not</i> disable shadow rendering.</para>
    /// <para>In spatial shaders, <c>1.0 - transparency</c> is set as the default value of the <c>ALPHA</c> built-in.</para>
    /// <para><b>Note:</b> <paramref name="transparency"/> is clamped between <c>0.0</c> and <c>1.0</c>, so this property cannot be used to make transparent materials more opaque than they originally are.</para>
    /// </summary>
    public void InstanceGeometrySetTransparency(Rid instance, float transparency)
    {
        NativeCalls.godot_icall_2_816(MethodBind367, GodotObject.GetPtr(this), instance, transparency);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind368 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceTeleport, 2722037293ul);

    /// <summary>
    /// <para>Resets motion vectors and other interpolated values. Use this <i>after</i> teleporting a mesh from one position to another to avoid ghosting artifacts.</para>
    /// </summary>
    public void InstanceTeleport(Rid instance)
    {
        NativeCalls.godot_icall_1_286(MethodBind368, GodotObject.GetPtr(this), instance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind369 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetCustomAabb, 3696536120ul);

    /// <summary>
    /// <para>Sets a custom AABB to use when culling objects from the view frustum. Equivalent to setting <see cref="Godot.GeometryInstance3D.CustomAabb"/>.</para>
    /// </summary>
    public unsafe void InstanceSetCustomAabb(Rid instance, Aabb aabb)
    {
        NativeCalls.godot_icall_2_1135(MethodBind369, GodotObject.GetPtr(this), instance, &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind370 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceAttachSkeleton, 395945892ul);

    /// <summary>
    /// <para>Attaches a skeleton to an instance. Removes the previous skeleton from the instance.</para>
    /// </summary>
    public void InstanceAttachSkeleton(Rid instance, Rid skeleton)
    {
        NativeCalls.godot_icall_2_430(MethodBind370, GodotObject.GetPtr(this), instance, skeleton);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind371 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetExtraVisibilityMargin, 1794382983ul);

    /// <summary>
    /// <para>Sets a margin to increase the size of the AABB when culling objects from the view frustum. This allows you to avoid culling objects that fall outside the view frustum. Equivalent to <see cref="Godot.GeometryInstance3D.ExtraCullMargin"/>.</para>
    /// </summary>
    public void InstanceSetExtraVisibilityMargin(Rid instance, float margin)
    {
        NativeCalls.godot_icall_2_816(MethodBind371, GodotObject.GetPtr(this), instance, margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind372 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetVisibilityParent, 395945892ul);

    /// <summary>
    /// <para>Sets the visibility parent for the given instance. Equivalent to <see cref="Godot.Node3D.VisibilityParent"/>.</para>
    /// </summary>
    public void InstanceSetVisibilityParent(Rid instance, Rid parent)
    {
        NativeCalls.godot_icall_2_430(MethodBind372, GodotObject.GetPtr(this), instance, parent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind373 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetIgnoreCulling, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, ignores both frustum and occlusion culling on the specified 3D geometry instance. This is not the same as <see cref="Godot.GeometryInstance3D.IgnoreOcclusionCulling"/>, which only ignores occlusion culling and leaves frustum culling intact.</para>
    /// </summary>
    public void InstanceSetIgnoreCulling(Rid instance, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind373, GodotObject.GetPtr(this), instance, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind374 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetFlag, 1014989537ul);

    /// <summary>
    /// <para>Sets the <paramref name="flag"/> for a given <paramref name="instance"/> to <paramref name="enabled"/>.</para>
    /// </summary>
    public void InstanceGeometrySetFlag(Rid instance, RenderingServer.InstanceFlags flag, bool enabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind374, GodotObject.GetPtr(this), instance, (int)flag, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind375 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetCastShadowsSetting, 3768836020ul);

    /// <summary>
    /// <para>Sets the shadow casting setting. Equivalent to <see cref="Godot.GeometryInstance3D.CastShadow"/>.</para>
    /// </summary>
    public void InstanceGeometrySetCastShadowsSetting(Rid instance, RenderingServer.ShadowCastingSetting shadowCastingSetting)
    {
        NativeCalls.godot_icall_2_426(MethodBind375, GodotObject.GetPtr(this), instance, (int)shadowCastingSetting);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind376 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetMaterialOverride, 395945892ul);

    /// <summary>
    /// <para>Sets a material that will override the material for all surfaces on the mesh associated with this instance. Equivalent to <see cref="Godot.GeometryInstance3D.MaterialOverride"/>.</para>
    /// </summary>
    public void InstanceGeometrySetMaterialOverride(Rid instance, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind376, GodotObject.GetPtr(this), instance, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind377 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetMaterialOverlay, 395945892ul);

    /// <summary>
    /// <para>Sets a material that will be rendered for all surfaces on top of active materials for the mesh associated with this instance. Equivalent to <see cref="Godot.GeometryInstance3D.MaterialOverlay"/>.</para>
    /// </summary>
    public void InstanceGeometrySetMaterialOverlay(Rid instance, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind377, GodotObject.GetPtr(this), instance, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind378 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetVisibilityRange, 4263925858ul);

    /// <summary>
    /// <para>Sets the visibility range values for the given geometry instance. Equivalent to <see cref="Godot.GeometryInstance3D.VisibilityRangeBegin"/> and related properties.</para>
    /// </summary>
    public void InstanceGeometrySetVisibilityRange(Rid instance, float min, float max, float minMargin, float maxMargin, RenderingServer.VisibilityRangeFadeMode fadeMode)
    {
        NativeCalls.godot_icall_6_1183(MethodBind378, GodotObject.GetPtr(this), instance, min, max, minMargin, maxMargin, (int)fadeMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind379 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetLightmap, 536974962ul);

    /// <summary>
    /// <para>Sets the lightmap GI instance to use for the specified 3D geometry instance. The lightmap UV scale for the specified instance (equivalent to <see cref="Godot.GeometryInstance3D.GILightmapScale"/>) and lightmap atlas slice must also be specified.</para>
    /// </summary>
    public unsafe void InstanceGeometrySetLightmap(Rid instance, Rid lightmap, Rect2 lightmapUVScale, int lightmapSlice)
    {
        NativeCalls.godot_icall_4_1184(MethodBind379, GodotObject.GetPtr(this), instance, lightmap, &lightmapUVScale, lightmapSlice);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind380 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetLodBias, 1794382983ul);

    /// <summary>
    /// <para>Sets the level of detail bias to use when rendering the specified 3D geometry instance. Higher values result in higher detail from further away. Equivalent to <see cref="Godot.GeometryInstance3D.LodBias"/>.</para>
    /// </summary>
    public void InstanceGeometrySetLodBias(Rid instance, float lodBias)
    {
        NativeCalls.godot_icall_2_816(MethodBind380, GodotObject.GetPtr(this), instance, lodBias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind381 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetShaderParameter, 3477296213ul);

    /// <summary>
    /// <para>Sets the per-instance shader uniform on the specified 3D geometry instance. Equivalent to <see cref="Godot.GeometryInstance3D.SetInstanceShaderParameter(StringName, Variant)"/>.</para>
    /// </summary>
    public void InstanceGeometrySetShaderParameter(Rid instance, StringName parameter, Variant value)
    {
        NativeCalls.godot_icall_3_1128(MethodBind381, GodotObject.GetPtr(this), instance, (godot_string_name)(parameter?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind382 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometryGetShaderParameter, 2621281810ul);

    /// <summary>
    /// <para>Returns the value of the per-instance shader uniform from the specified 3D geometry instance. Equivalent to <see cref="Godot.GeometryInstance3D.GetInstanceShaderParameter(StringName)"/>.</para>
    /// <para><b>Note:</b> Per-instance shader parameter names are case-sensitive.</para>
    /// </summary>
    public Variant InstanceGeometryGetShaderParameter(Rid instance, StringName parameter)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind382, GodotObject.GetPtr(this), instance, (godot_string_name)(parameter?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind383 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometryGetShaderParameterDefaultValue, 2621281810ul);

    /// <summary>
    /// <para>Returns the default value of the per-instance shader uniform from the specified 3D geometry instance. Equivalent to <see cref="Godot.GeometryInstance3D.GetInstanceShaderParameter(StringName)"/>.</para>
    /// </summary>
    public Variant InstanceGeometryGetShaderParameterDefaultValue(Rid instance, StringName parameter)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind383, GodotObject.GetPtr(this), instance, (godot_string_name)(parameter?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind384 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometryGetShaderParameterList, 2684255073ul);

    /// <summary>
    /// <para>Returns a dictionary of per-instance shader uniform names of the per-instance shader uniform from the specified 3D geometry instance. The returned dictionary is in PropertyInfo format, with the keys <c>name</c>, <c>class_name</c>, <c>type</c>, <c>hint</c>, <c>hint_string</c> and <c>usage</c>. Equivalent to <see cref="Godot.GeometryInstance3D.GetInstanceShaderParameter(StringName)"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> InstanceGeometryGetShaderParameterList(Rid instance)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_849(MethodBind384, GodotObject.GetPtr(this), instance));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind385 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstancesCullAabb, 2570105777ul);

    /// <summary>
    /// <para>Returns an array of object IDs intersecting with the provided AABB. Only 3D nodes that inherit from <see cref="Godot.VisualInstance3D"/> are considered, such as <see cref="Godot.MeshInstance3D"/> or <see cref="Godot.DirectionalLight3D"/>. Use <c>@GlobalScope.instance_from_id</c> to obtain the actual nodes. A scenario RID must be provided, which is available in the <see cref="Godot.World3D"/> you want to query. This forces an update for all resources queued to update.</para>
    /// <para><b>Warning:</b> This function is primarily intended for editor usage. For in-game use cases, prefer physics collision.</para>
    /// </summary>
    public unsafe long[] InstancesCullAabb(Aabb aabb, Rid scenario = default)
    {
        return NativeCalls.godot_icall_2_1185(MethodBind385, GodotObject.GetPtr(this), &aabb, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind386 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstancesCullRay, 2208759584ul);

    /// <summary>
    /// <para>Returns an array of object IDs intersecting with the provided 3D ray. Only 3D nodes that inherit from <see cref="Godot.VisualInstance3D"/> are considered, such as <see cref="Godot.MeshInstance3D"/> or <see cref="Godot.DirectionalLight3D"/>. Use <c>@GlobalScope.instance_from_id</c> to obtain the actual nodes. A scenario RID must be provided, which is available in the <see cref="Godot.World3D"/> you want to query. This forces an update for all resources queued to update.</para>
    /// <para><b>Warning:</b> This function is primarily intended for editor usage. For in-game use cases, prefer physics collision.</para>
    /// </summary>
    public unsafe long[] InstancesCullRay(Vector3 from, Vector3 to, Rid scenario = default)
    {
        return NativeCalls.godot_icall_3_1186(MethodBind386, GodotObject.GetPtr(this), &from, &to, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind387 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstancesCullConvex, 2488539944ul);

    /// <summary>
    /// <para>Returns an array of object IDs intersecting with the provided convex shape. Only 3D nodes that inherit from <see cref="Godot.VisualInstance3D"/> are considered, such as <see cref="Godot.MeshInstance3D"/> or <see cref="Godot.DirectionalLight3D"/>. Use <c>@GlobalScope.instance_from_id</c> to obtain the actual nodes. A scenario RID must be provided, which is available in the <see cref="Godot.World3D"/> you want to query. This forces an update for all resources queued to update.</para>
    /// <para><b>Warning:</b> This function is primarily intended for editor usage. For in-game use cases, prefer physics collision.</para>
    /// </summary>
    public long[] InstancesCullConvex(Godot.Collections.Array<Plane> convex, Rid scenario = default)
    {
        return NativeCalls.godot_icall_2_1187(MethodBind387, GodotObject.GetPtr(this), (godot_array)(convex ?? new()).NativeValue, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind388 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BakeRenderUV2, 1904608558ul);

    /// <summary>
    /// <para>Bakes the material data of the Mesh passed in the <paramref name="base"/> parameter with optional <paramref name="materialOverrides"/> to a set of <see cref="Godot.Image"/>s of size <paramref name="imageSize"/>. Returns an array of <see cref="Godot.Image"/>s containing material properties as specified in <see cref="Godot.RenderingServer.BakeChannels"/>.</para>
    /// </summary>
    public unsafe Godot.Collections.Array<Image> BakeRenderUV2(Rid @base, Godot.Collections.Array<Rid> materialOverrides, Vector2I imageSize)
    {
        return new Godot.Collections.Array<Image>(NativeCalls.godot_icall_3_1188(MethodBind388, GodotObject.GetPtr(this), @base, (godot_array)(materialOverrides ?? new()).NativeValue, &imageSize));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind389 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a canvas and returns the assigned <see cref="Godot.Rid"/>. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para>Canvas has no <see cref="Godot.Resource"/> or <see cref="Godot.Node"/> equivalent.</para>
    /// </summary>
    public Rid CanvasCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind389, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind390 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasSetItemMirroring, 2343975398ul);

    /// <summary>
    /// <para>A copy of the canvas item will be drawn with a local offset of the <paramref name="mirroring"/>.</para>
    /// <para><b>Note:</b> This is equivalent to calling <see cref="Godot.RenderingServerInstance.CanvasSetItemRepeat(Rid, Vector2, int)"/> like <c>canvas_set_item_repeat(item, mirroring, 1)</c>, with an additional check ensuring <paramref name="canvas"/> is a parent of <paramref name="item"/>.</para>
    /// </summary>
    public unsafe void CanvasSetItemMirroring(Rid canvas, Rid item, Vector2 mirroring)
    {
        NativeCalls.godot_icall_3_1189(MethodBind390, GodotObject.GetPtr(this), canvas, item, &mirroring);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind391 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasSetItemRepeat, 1739512717ul);

    /// <summary>
    /// <para>A copy of the canvas item will be drawn with a local offset of the <paramref name="repeatSize"/> by the number of times of the <paramref name="repeatTimes"/>. As the <paramref name="repeatTimes"/> increases, the copies will spread away from the origin texture.</para>
    /// </summary>
    public unsafe void CanvasSetItemRepeat(Rid item, Vector2 repeatSize, int repeatTimes)
    {
        NativeCalls.godot_icall_3_1190(MethodBind391, GodotObject.GetPtr(this), item, &repeatSize, repeatTimes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind392 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasSetModulate, 2948539648ul);

    /// <summary>
    /// <para>Modulates all colors in the given canvas.</para>
    /// </summary>
    public unsafe void CanvasSetModulate(Rid canvas, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind392, GodotObject.GetPtr(this), canvas, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind393 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasSetDisableScale, 2586408642ul);

    public void CanvasSetDisableScale(bool disable)
    {
        NativeCalls.godot_icall_1_14(MethodBind393, GodotObject.GetPtr(this), disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind394 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasTextureCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a canvas texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_texture_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method. See also <see cref="Godot.RenderingServerInstance.Texture2DCreate(Image)"/>.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.CanvasTexture"/> and is only meant to be used in 2D rendering, not 3D.</para>
    /// </summary>
    public Rid CanvasTextureCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind394, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind395 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasTextureSetChannel, 3822119138ul);

    /// <summary>
    /// <para>Sets the <paramref name="channel"/>'s <paramref name="texture"/> for the canvas texture specified by the <paramref name="canvasTexture"/> RID. Equivalent to <see cref="Godot.CanvasTexture.DiffuseTexture"/>, <see cref="Godot.CanvasTexture.NormalTexture"/> and <see cref="Godot.CanvasTexture.SpecularTexture"/>.</para>
    /// </summary>
    public void CanvasTextureSetChannel(Rid canvasTexture, RenderingServer.CanvasTextureChannel channel, Rid texture)
    {
        NativeCalls.godot_icall_3_833(MethodBind395, GodotObject.GetPtr(this), canvasTexture, (int)channel, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind396 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasTextureSetShadingParameters, 2124967469ul);

    /// <summary>
    /// <para>Sets the <paramref name="baseColor"/> and <paramref name="shininess"/> to use for the canvas texture specified by the <paramref name="canvasTexture"/> RID. Equivalent to <see cref="Godot.CanvasTexture.SpecularColor"/> and <see cref="Godot.CanvasTexture.SpecularShininess"/>.</para>
    /// </summary>
    public unsafe void CanvasTextureSetShadingParameters(Rid canvasTexture, Color baseColor, float shininess)
    {
        NativeCalls.godot_icall_3_1191(MethodBind396, GodotObject.GetPtr(this), canvasTexture, &baseColor, shininess);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind397 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasTextureSetTextureFilter, 1155129294ul);

    /// <summary>
    /// <para>Sets the texture <paramref name="filter"/> mode to use for the canvas texture specified by the <paramref name="canvasTexture"/> RID.</para>
    /// </summary>
    public void CanvasTextureSetTextureFilter(Rid canvasTexture, RenderingServer.CanvasItemTextureFilter filter)
    {
        NativeCalls.godot_icall_2_426(MethodBind397, GodotObject.GetPtr(this), canvasTexture, (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind398 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasTextureSetTextureRepeat, 1652956681ul);

    /// <summary>
    /// <para>Sets the texture <paramref name="repeat"/> mode to use for the canvas texture specified by the <paramref name="canvasTexture"/> RID.</para>
    /// </summary>
    public void CanvasTextureSetTextureRepeat(Rid canvasTexture, RenderingServer.CanvasItemTextureRepeat repeat)
    {
        NativeCalls.godot_icall_2_426(MethodBind398, GodotObject.GetPtr(this), canvasTexture, (int)repeat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind399 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new CanvasItem instance and returns its <see cref="Godot.Rid"/>. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_item_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public Rid CanvasItemCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind399, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind400 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetParent, 395945892ul);

    /// <summary>
    /// <para>Sets a parent <see cref="Godot.CanvasItem"/> to the <see cref="Godot.CanvasItem"/>. The item will inherit transform, modulation and visibility from its parent, like <see cref="Godot.CanvasItem"/> nodes in the scene tree.</para>
    /// </summary>
    public void CanvasItemSetParent(Rid item, Rid parent)
    {
        NativeCalls.godot_icall_2_430(MethodBind400, GodotObject.GetPtr(this), item, parent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind401 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetDefaultTextureFilter, 1155129294ul);

    /// <summary>
    /// <para>Sets the default texture filter mode for the canvas item specified by the <paramref name="item"/> RID. Equivalent to <see cref="Godot.CanvasItem.TextureFilter"/>.</para>
    /// </summary>
    public void CanvasItemSetDefaultTextureFilter(Rid item, RenderingServer.CanvasItemTextureFilter filter)
    {
        NativeCalls.godot_icall_2_426(MethodBind401, GodotObject.GetPtr(this), item, (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind402 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetDefaultTextureRepeat, 1652956681ul);

    /// <summary>
    /// <para>Sets the default texture repeat mode for the canvas item specified by the <paramref name="item"/> RID. Equivalent to <see cref="Godot.CanvasItem.TextureRepeat"/>.</para>
    /// </summary>
    public void CanvasItemSetDefaultTextureRepeat(Rid item, RenderingServer.CanvasItemTextureRepeat repeat)
    {
        NativeCalls.godot_icall_2_426(MethodBind402, GodotObject.GetPtr(this), item, (int)repeat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind403 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetVisible, 1265174801ul);

    /// <summary>
    /// <para>Sets the visibility of the <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public void CanvasItemSetVisible(Rid item, bool visible)
    {
        NativeCalls.godot_icall_2_434(MethodBind403, GodotObject.GetPtr(this), item, visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind404 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetLightMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the light <paramref name="mask"/> for the canvas item specified by the <paramref name="item"/> RID. Equivalent to <see cref="Godot.CanvasItem.LightMask"/>.</para>
    /// </summary>
    public void CanvasItemSetLightMask(Rid item, int mask)
    {
        NativeCalls.godot_icall_2_426(MethodBind404, GodotObject.GetPtr(this), item, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind405 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetVisibilityLayer, 3411492887ul);

    /// <summary>
    /// <para>Sets the rendering visibility layer associated with this <see cref="Godot.CanvasItem"/>. Only <see cref="Godot.Viewport"/> nodes with a matching rendering mask will render this <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public void CanvasItemSetVisibilityLayer(Rid item, uint visibilityLayer)
    {
        NativeCalls.godot_icall_2_856(MethodBind405, GodotObject.GetPtr(this), item, visibilityLayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind406 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets the <paramref name="transform"/> of the canvas item specified by the <paramref name="item"/> RID. This affects where and how the item will be drawn. Child canvas items' transforms are multiplied by their parent's transform. Equivalent to <see cref="Godot.Node2D.Transform"/>.</para>
    /// </summary>
    public unsafe void CanvasItemSetTransform(Rid item, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind406, GodotObject.GetPtr(this), item, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind407 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetClip, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="clip"/> is <see langword="true"/>, makes the canvas item specified by the <paramref name="item"/> RID not draw anything outside of its rect's coordinates. This clipping is fast, but works only with axis-aligned rectangles. This means that rotation is ignored by the clipping rectangle. For more advanced clipping shapes, use <see cref="Godot.RenderingServerInstance.CanvasItemSetCanvasGroupMode(Rid, RenderingServer.CanvasGroupMode, float, bool, float, bool)"/> instead.</para>
    /// <para><b>Note:</b> The equivalent node functionality is found in <see cref="Godot.Label.ClipText"/>, <see cref="Godot.RichTextLabel"/> (always enabled) and more.</para>
    /// </summary>
    public void CanvasItemSetClip(Rid item, bool clip)
    {
        NativeCalls.godot_icall_2_434(MethodBind407, GodotObject.GetPtr(this), item, clip.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind408 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetDistanceFieldMode, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, enables multichannel signed distance field rendering mode for the canvas item specified by the <paramref name="item"/> RID. This is meant to be used for font rendering, or with specially generated images using <a href="https://github.com/Chlumsky/msdfgen">msdfgen</a>.</para>
    /// </summary>
    public void CanvasItemSetDistanceFieldMode(Rid item, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind408, GodotObject.GetPtr(this), item, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind409 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetCustomRect, 1333997032ul);

    /// <summary>
    /// <para>If <paramref name="useCustomRect"/> is <see langword="true"/>, sets the custom visibility rectangle (used for culling) to <paramref name="rect"/> for the canvas item specified by <paramref name="item"/>. Setting a custom visibility rect can reduce CPU load when drawing lots of 2D instances. If <paramref name="useCustomRect"/> is <see langword="false"/>, automatically computes a visibility rectangle based on the canvas item's draw commands.</para>
    /// </summary>
    /// <param name="rect">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    public unsafe void CanvasItemSetCustomRect(Rid item, bool useCustomRect, Nullable<Rect2> rect = null)
    {
        Rect2 rectOrDefVal = rect.HasValue ? rect.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_3_1192(MethodBind409, GodotObject.GetPtr(this), item, useCustomRect.ToGodotBool(), &rectOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind410 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetModulate, 2948539648ul);

    /// <summary>
    /// <para>Multiplies the color of the canvas item specified by the <paramref name="item"/> RID, while affecting its children. See also <see cref="Godot.RenderingServerInstance.CanvasItemSetSelfModulate(Rid, Color)"/>. Equivalent to <see cref="Godot.CanvasItem.Modulate"/>.</para>
    /// </summary>
    public unsafe void CanvasItemSetModulate(Rid item, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind410, GodotObject.GetPtr(this), item, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind411 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetSelfModulate, 2948539648ul);

    /// <summary>
    /// <para>Multiplies the color of the canvas item specified by the <paramref name="item"/> RID, without affecting its children. See also <see cref="Godot.RenderingServerInstance.CanvasItemSetModulate(Rid, Color)"/>. Equivalent to <see cref="Godot.CanvasItem.SelfModulate"/>.</para>
    /// </summary>
    public unsafe void CanvasItemSetSelfModulate(Rid item, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind411, GodotObject.GetPtr(this), item, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind412 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetDrawBehindParent, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, draws the canvas item specified by the <paramref name="item"/> RID behind its parent. Equivalent to <see cref="Godot.CanvasItem.ShowBehindParent"/>.</para>
    /// </summary>
    public void CanvasItemSetDrawBehindParent(Rid item, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind412, GodotObject.GetPtr(this), item, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind413 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetInterpolated, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="interpolated"/> is <see langword="true"/>, turns on physics interpolation for the canvas item.</para>
    /// </summary>
    public void CanvasItemSetInterpolated(Rid item, bool interpolated)
    {
        NativeCalls.godot_icall_2_434(MethodBind413, GodotObject.GetPtr(this), item, interpolated.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind414 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemResetPhysicsInterpolation, 2722037293ul);

    /// <summary>
    /// <para>Prevents physics interpolation for the current physics tick.</para>
    /// <para>This is useful when moving a canvas item to a new location, to give an instantaneous change rather than interpolation from the previous location.</para>
    /// </summary>
    public void CanvasItemResetPhysicsInterpolation(Rid item)
    {
        NativeCalls.godot_icall_1_286(MethodBind414, GodotObject.GetPtr(this), item);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind415 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemTransformPhysicsInterpolation, 1246044741ul);

    /// <summary>
    /// <para>Transforms both the current and previous stored transform for a canvas item.</para>
    /// <para>This allows transforming a canvas item without creating a "glitch" in the interpolation, which is particularly useful for large worlds utilizing a shifting origin.</para>
    /// </summary>
    public unsafe void CanvasItemTransformPhysicsInterpolation(Rid item, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind415, GodotObject.GetPtr(this), item, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind416 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddLine, 1819681853ul);

    /// <summary>
    /// <para>Draws a line on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/>.</para>
    /// </summary>
    public unsafe void CanvasItemAddLine(Rid item, Vector2 from, Vector2 to, Color color, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_6_1193(MethodBind416, GodotObject.GetPtr(this), item, &from, &to, &color, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind417 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddPolyline, 3098767073ul);

    /// <summary>
    /// <para>Draws a 2D polyline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawPolylineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    public void CanvasItemAddPolyline(Rid item, Vector2[] points, Color[] colors, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_5_1194(MethodBind417, GodotObject.GetPtr(this), item, points, colors, width, antialiased.ToGodotBool());
    }

    /// <summary>
    /// <para>Draws a 2D polyline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawPolylineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    public void CanvasItemAddPolyline(Rid item, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, float width, bool antialiased)
    {
        NativeCalls.godot_icall_5_1194(MethodBind417, GodotObject.GetPtr(this), item, points, colors, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind418 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddMultiline, 3098767073ul);

    /// <summary>
    /// <para>Draws a 2D multiline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawMultilineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    public void CanvasItemAddMultiline(Rid item, Vector2[] points, Color[] colors, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_5_1194(MethodBind418, GodotObject.GetPtr(this), item, points, colors, width, antialiased.ToGodotBool());
    }

    /// <summary>
    /// <para>Draws a 2D multiline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawMultilineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    public void CanvasItemAddMultiline(Rid item, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, float width, bool antialiased)
    {
        NativeCalls.godot_icall_5_1194(MethodBind418, GodotObject.GetPtr(this), item, points, colors, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind419 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddRect, 3523446176ul);

    /// <summary>
    /// <para>Draws a rectangle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawRect(Rect2, Color, bool, float, bool)"/>.</para>
    /// </summary>
    public unsafe void CanvasItemAddRect(Rid item, Rect2 rect, Color color, bool antialiased = false)
    {
        NativeCalls.godot_icall_4_1195(MethodBind419, GodotObject.GetPtr(this), item, &rect, &color, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind420 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddCircle, 333077949ul);

    /// <summary>
    /// <para>Draws a circle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawCircle(Vector2, float, Color, bool, float, bool)"/>.</para>
    /// </summary>
    public unsafe void CanvasItemAddCircle(Rid item, Vector2 pos, float radius, Color color, bool antialiased = false)
    {
        NativeCalls.godot_icall_5_1196(MethodBind420, GodotObject.GetPtr(this), item, &pos, radius, &color, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind421 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddEllipse, 4188642757ul);

    /// <summary>
    /// <para>Draws an ellipse with semi-major axis <paramref name="major"/> and semi-minor axis <paramref name="minor"/> on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawEllipse(Vector2, float, float, Color, bool, float, bool)"/>.</para>
    /// </summary>
    public unsafe void CanvasItemAddEllipse(Rid item, Vector2 pos, float major, float minor, Color color, bool antialiased = false)
    {
        NativeCalls.godot_icall_6_1197(MethodBind421, GodotObject.GetPtr(this), item, &pos, major, minor, &color, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind422 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddTextureRect, 324864032ul);

    /// <summary>
    /// <para>Draws a 2D textured rectangle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawTextureRect(Texture2D, Rect2, bool, Nullable{Color}, bool)"/> and <see cref="Godot.Texture2D.DrawRect(Rid, Rect2, bool, Nullable{Color}, bool)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void CanvasItemAddTextureRect(Rid item, Rect2 rect, Rid texture, bool tile = false, Nullable<Color> modulate = null, bool transpose = false)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_6_1198(MethodBind422, GodotObject.GetPtr(this), item, &rect, texture, tile.ToGodotBool(), &modulateOrDefVal, transpose.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind423 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddMsdfTextureRectRegion, 97408773ul);

    /// <summary>
    /// <para>See also <see cref="Godot.CanvasItem.DrawMsdfTextureRectRegion(Texture2D, Rect2, Rect2, Nullable{Color}, double, double, double)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void CanvasItemAddMsdfTextureRectRegion(Rid item, Rect2 rect, Rid texture, Rect2 srcRect, Nullable<Color> modulate = null, int outlineSize = 0, float pxRange = 1.0f, float scale = 1.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_8_1199(MethodBind423, GodotObject.GetPtr(this), item, &rect, texture, &srcRect, &modulateOrDefVal, outlineSize, pxRange, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind424 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddLcdTextureRectRegion, 359793297ul);

    /// <summary>
    /// <para>See also <see cref="Godot.CanvasItem.DrawLcdTextureRectRegion(Texture2D, Rect2, Rect2, Nullable{Color})"/>.</para>
    /// </summary>
    public unsafe void CanvasItemAddLcdTextureRectRegion(Rid item, Rect2 rect, Rid texture, Rect2 srcRect, Color modulate)
    {
        NativeCalls.godot_icall_5_1200(MethodBind424, GodotObject.GetPtr(this), item, &rect, texture, &srcRect, &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind425 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddTextureRectRegion, 485157892ul);

    /// <summary>
    /// <para>Draws the specified region of a 2D textured rectangle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawTextureRectRegion(Texture2D, Rect2, Rect2, Nullable{Color}, bool, bool)"/> and <see cref="Godot.Texture2D.DrawRectRegion(Rid, Rect2, Rect2, Nullable{Color}, bool, bool)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void CanvasItemAddTextureRectRegion(Rid item, Rect2 rect, Rid texture, Rect2 srcRect, Nullable<Color> modulate = null, bool transpose = false, bool clipUV = true)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_7_1201(MethodBind425, GodotObject.GetPtr(this), item, &rect, texture, &srcRect, &modulateOrDefVal, transpose.ToGodotBool(), clipUV.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind426 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddNinePatch, 389957886ul);

    /// <summary>
    /// <para>Draws a nine-patch rectangle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void CanvasItemAddNinePatch(Rid item, Rect2 rect, Rect2 source, Rid texture, Vector2 topleft, Vector2 bottomright, RenderingServer.NinePatchAxisMode xAxisMode = (RenderingServer.NinePatchAxisMode)(0), RenderingServer.NinePatchAxisMode yAxisMode = (RenderingServer.NinePatchAxisMode)(0), bool drawCenter = true, Nullable<Color> modulate = null)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_10_1202(MethodBind426, GodotObject.GetPtr(this), item, &rect, &source, texture, &topleft, &bottomright, (int)xAxisMode, (int)yAxisMode, drawCenter.ToGodotBool(), &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind427 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddPrimitive, 3731601077ul);

    /// <summary>
    /// <para>Draws a 2D primitive on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawPrimitive(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// </summary>
    public void CanvasItemAddPrimitive(Rid item, Vector2[] points, Color[] colors, Vector2[] uvs, Rid texture)
    {
        NativeCalls.godot_icall_5_1203(MethodBind427, GodotObject.GetPtr(this), item, points, colors, uvs, texture);
    }

    /// <summary>
    /// <para>Draws a 2D primitive on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawPrimitive(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// </summary>
    public void CanvasItemAddPrimitive(Rid item, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, ReadOnlySpan<Vector2> uvs, Rid texture)
    {
        NativeCalls.godot_icall_5_1203(MethodBind427, GodotObject.GetPtr(this), item, points, colors, uvs, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind428 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddPolygon, 3580000528ul);

    /// <summary>
    /// <para>Draws a 2D polygon on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. If you need more flexibility (such as being able to use bones), use <see cref="Godot.RenderingServerInstance.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/> instead. See also <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para><b>Note:</b> If you frequently redraw the same polygon with a large number of vertices, consider pre-calculating the triangulation with <see cref="Godot.Geometry2D.TriangulatePolygon(Vector2[])"/> and using <see cref="Godot.CanvasItem.DrawMesh(Mesh, Texture2D, Nullable{Transform2D}, Nullable{Color})"/>, <see cref="Godot.CanvasItem.DrawMultimesh(MultiMesh, Texture2D)"/>, or <see cref="Godot.RenderingServerInstance.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/>.</para>
    /// </summary>
    /// <param name="uvs">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector2&gt;()</c>.</param>
    public void CanvasItemAddPolygon(Rid item, Vector2[] points, Color[] colors, Vector2[] uvs = null, Rid texture = default)
    {
        Vector2[] uvsOrDefVal = uvs != null ? uvs : Array.Empty<Vector2>();
        NativeCalls.godot_icall_5_1203(MethodBind428, GodotObject.GetPtr(this), item, points, colors, uvsOrDefVal, texture);
    }

    /// <summary>
    /// <para>Draws a 2D polygon on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. If you need more flexibility (such as being able to use bones), use <see cref="Godot.RenderingServerInstance.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/> instead. See also <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para><b>Note:</b> If you frequently redraw the same polygon with a large number of vertices, consider pre-calculating the triangulation with <see cref="Godot.Geometry2D.TriangulatePolygon(Vector2[])"/> and using <see cref="Godot.CanvasItem.DrawMesh(Mesh, Texture2D, Nullable{Transform2D}, Nullable{Color})"/>, <see cref="Godot.CanvasItem.DrawMultimesh(MultiMesh, Texture2D)"/>, or <see cref="Godot.RenderingServerInstance.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/>.</para>
    /// </summary>
    public void CanvasItemAddPolygon(Rid item, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, ReadOnlySpan<Vector2> uvs, Rid texture)
    {
        NativeCalls.godot_icall_5_1203(MethodBind428, GodotObject.GetPtr(this), item, points, colors, uvs, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind429 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddTriangleArray, 660261329ul);

    /// <summary>
    /// <para>Draws a triangle array on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. This is internally used by <see cref="Godot.Line2D"/> and <see cref="Godot.StyleBoxFlat"/> for rendering. <see cref="Godot.RenderingServerInstance.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/> is highly flexible, but more complex to use than <see cref="Godot.RenderingServerInstance.CanvasItemAddPolygon(Rid, Vector2[], Color[], Vector2[], Rid)"/>.</para>
    /// <para><b>Note:</b> If <paramref name="count"/> is set to a non-negative value, only the first <c>count * 3</c> indices (corresponding to <c>count</c> triangles) will be drawn. Otherwise, all indices are drawn.</para>
    /// </summary>
    /// <param name="uvs">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector2&gt;()</c>.</param>
    /// <param name="bones">If the parameter is null, then the default value is <c>Array.Empty&lt;int&gt;()</c>.</param>
    /// <param name="weights">If the parameter is null, then the default value is <c>Array.Empty&lt;float&gt;()</c>.</param>
    public void CanvasItemAddTriangleArray(Rid item, int[] indices, Vector2[] points, Color[] colors, Vector2[] uvs = null, int[] bones = null, float[] weights = null, Rid texture = default, int count = -1)
    {
        Vector2[] uvsOrDefVal = uvs != null ? uvs : Array.Empty<Vector2>();
        int[] bonesOrDefVal = bones != null ? bones : Array.Empty<int>();
        float[] weightsOrDefVal = weights != null ? weights : Array.Empty<float>();
        NativeCalls.godot_icall_9_1204(MethodBind429, GodotObject.GetPtr(this), item, indices, points, colors, uvsOrDefVal, bonesOrDefVal, weightsOrDefVal, texture, count);
    }

    /// <summary>
    /// <para>Draws a triangle array on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. This is internally used by <see cref="Godot.Line2D"/> and <see cref="Godot.StyleBoxFlat"/> for rendering. <see cref="Godot.RenderingServerInstance.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/> is highly flexible, but more complex to use than <see cref="Godot.RenderingServerInstance.CanvasItemAddPolygon(Rid, Vector2[], Color[], Vector2[], Rid)"/>.</para>
    /// <para><b>Note:</b> If <paramref name="count"/> is set to a non-negative value, only the first <c>count * 3</c> indices (corresponding to <c>count</c> triangles) will be drawn. Otherwise, all indices are drawn.</para>
    /// </summary>
    public void CanvasItemAddTriangleArray(Rid item, ReadOnlySpan<int> indices, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, ReadOnlySpan<Vector2> uvs, ReadOnlySpan<int> bones, ReadOnlySpan<float> weights, Rid texture, int count)
    {
        NativeCalls.godot_icall_9_1204(MethodBind429, GodotObject.GetPtr(this), item, indices, points, colors, uvs, bones, weights, texture, count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind430 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddMesh, 316450961ul);

    /// <summary>
    /// <para>Draws a mesh created with <see cref="Godot.RenderingServerInstance.MeshCreate()"/> with given <paramref name="transform"/>, <paramref name="modulate"/> color, and <paramref name="texture"/>. This is used internally by <see cref="Godot.MeshInstance2D"/>.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform2D.Identity</c>.</param>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void CanvasItemAddMesh(Rid item, Rid mesh, Nullable<Transform2D> transform = null, Nullable<Color> modulate = null, Rid texture = default)
    {
        Transform2D transformOrDefVal = transform.HasValue ? transform.Value : Transform2D.Identity;
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_5_1205(MethodBind430, GodotObject.GetPtr(this), item, mesh, &transformOrDefVal, &modulateOrDefVal, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind431 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddMultimesh, 2131855138ul);

    /// <summary>
    /// <para>Draws a 2D <see cref="Godot.MultiMesh"/> on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawMultimesh(MultiMesh, Texture2D)"/>.</para>
    /// </summary>
    public void CanvasItemAddMultimesh(Rid item, Rid mesh, Rid texture = default)
    {
        NativeCalls.godot_icall_3_1206(MethodBind431, GodotObject.GetPtr(this), item, mesh, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind432 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddParticles, 2575754278ul);

    /// <summary>
    /// <para>Draws particles on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void CanvasItemAddParticles(Rid item, Rid particles, Rid texture)
    {
        NativeCalls.godot_icall_3_1206(MethodBind432, GodotObject.GetPtr(this), item, particles, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind433 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets a <see cref="Godot.Transform2D"/> that will be used to transform subsequent canvas item commands.</para>
    /// </summary>
    public unsafe void CanvasItemAddSetTransform(Rid item, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind433, GodotObject.GetPtr(this), item, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind434 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddClipIgnore, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="ignore"/> is <see langword="true"/>, ignore clipping on items drawn with this canvas item until this is called again with <paramref name="ignore"/> set to <see langword="false"/>.</para>
    /// </summary>
    public void CanvasItemAddClipIgnore(Rid item, bool ignore)
    {
        NativeCalls.godot_icall_2_434(MethodBind434, GodotObject.GetPtr(this), item, ignore.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind435 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddAnimationSlice, 2646834499ul);

    /// <summary>
    /// <para>Subsequent drawing commands will be ignored unless they fall within the specified animation slice. This is a faster way to implement animations that loop on background rather than redrawing constantly.</para>
    /// </summary>
    public void CanvasItemAddAnimationSlice(Rid item, double animationLength, double sliceBegin, double sliceEnd, double offset = 0.0)
    {
        NativeCalls.godot_icall_5_1207(MethodBind435, GodotObject.GetPtr(this), item, animationLength, sliceBegin, sliceEnd, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind436 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetSortChildrenByY, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, child nodes with the lowest Y position are drawn before those with a higher Y position. Y-sorting only affects children that inherit from the canvas item specified by the <paramref name="item"/> RID, not the canvas item itself. Equivalent to <see cref="Godot.CanvasItem.YSortEnabled"/>.</para>
    /// </summary>
    public void CanvasItemSetSortChildrenByY(Rid item, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind436, GodotObject.GetPtr(this), item, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind437 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetZIndex, 3411492887ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.CanvasItem"/>'s Z index, i.e. its draw order (lower indexes are drawn first).</para>
    /// </summary>
    public void CanvasItemSetZIndex(Rid item, int zIndex)
    {
        NativeCalls.godot_icall_2_426(MethodBind437, GodotObject.GetPtr(this), item, zIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind438 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetZAsRelativeToParent, 1265174801ul);

    /// <summary>
    /// <para>If this is enabled, the Z index of the parent will be added to the children's Z index.</para>
    /// </summary>
    public void CanvasItemSetZAsRelativeToParent(Rid item, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind438, GodotObject.GetPtr(this), item, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind439 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetCopyToBackbuffer, 2429202503ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.CanvasItem"/> to copy a rect to the backbuffer.</para>
    /// </summary>
    public unsafe void CanvasItemSetCopyToBackbuffer(Rid item, bool enabled, Rect2 rect)
    {
        NativeCalls.godot_icall_3_1192(MethodBind439, GodotObject.GetPtr(this), item, enabled.ToGodotBool(), &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind440 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAttachSkeleton, 395945892ul);

    /// <summary>
    /// <para>Attaches a skeleton to the <see cref="Godot.CanvasItem"/>. Removes the previous skeleton.</para>
    /// </summary>
    public void CanvasItemAttachSkeleton(Rid item, Rid skeleton)
    {
        NativeCalls.godot_icall_2_430(MethodBind440, GodotObject.GetPtr(this), item, skeleton);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind441 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemClear, 2722037293ul);

    /// <summary>
    /// <para>Clears the <see cref="Godot.CanvasItem"/> and removes all commands in it.</para>
    /// </summary>
    public void CanvasItemClear(Rid item)
    {
        NativeCalls.godot_icall_1_286(MethodBind441, GodotObject.GetPtr(this), item);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind442 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetDrawIndex, 3411492887ul);

    /// <summary>
    /// <para>Sets the index for the <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public void CanvasItemSetDrawIndex(Rid item, int index)
    {
        NativeCalls.godot_icall_2_426(MethodBind442, GodotObject.GetPtr(this), item, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind443 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetMaterial, 395945892ul);

    /// <summary>
    /// <para>Sets a new <paramref name="material"/> to the canvas item specified by the <paramref name="item"/> RID. Equivalent to <see cref="Godot.CanvasItem.Material"/>.</para>
    /// </summary>
    public void CanvasItemSetMaterial(Rid item, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind443, GodotObject.GetPtr(this), item, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind444 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetUseParentMaterial, 1265174801ul);

    /// <summary>
    /// <para>Sets if the <see cref="Godot.CanvasItem"/> uses its parent's material.</para>
    /// </summary>
    public void CanvasItemSetUseParentMaterial(Rid item, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind444, GodotObject.GetPtr(this), item, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind445 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetInstanceShaderParameter, 3477296213ul);

    /// <summary>
    /// <para>Sets the per-instance shader uniform on the specified canvas item instance. Equivalent to <see cref="Godot.CanvasItem.SetInstanceShaderParameter(StringName, Variant)"/>.</para>
    /// </summary>
    public void CanvasItemSetInstanceShaderParameter(Rid instance, StringName parameter, Variant value)
    {
        NativeCalls.godot_icall_3_1128(MethodBind445, GodotObject.GetPtr(this), instance, (godot_string_name)(parameter?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind446 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemGetInstanceShaderParameter, 2621281810ul);

    /// <summary>
    /// <para>Returns the value of the per-instance shader uniform from the specified canvas item instance. Equivalent to <see cref="Godot.CanvasItem.GetInstanceShaderParameter(StringName)"/>.</para>
    /// </summary>
    public Variant CanvasItemGetInstanceShaderParameter(Rid instance, StringName parameter)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind446, GodotObject.GetPtr(this), instance, (godot_string_name)(parameter?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind447 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemGetInstanceShaderParameterDefaultValue, 2621281810ul);

    /// <summary>
    /// <para>Returns the default value of the per-instance shader uniform from the specified canvas item instance. Equivalent to <see cref="Godot.CanvasItem.GetInstanceShaderParameter(StringName)"/>.</para>
    /// </summary>
    public Variant CanvasItemGetInstanceShaderParameterDefaultValue(Rid instance, StringName parameter)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind447, GodotObject.GetPtr(this), instance, (godot_string_name)(parameter?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind448 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemGetInstanceShaderParameterList, 2684255073ul);

    /// <summary>
    /// <para>Returns a dictionary of per-instance shader uniform names of the per-instance shader uniform from the specified canvas item instance.</para>
    /// <para>The returned dictionary is in PropertyInfo format, with the keys <c>name</c>, <c>class_name</c>, <c>type</c>, <c>hint</c>, <c>hint_string</c>, and <c>usage</c>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> CanvasItemGetInstanceShaderParameterList(Rid instance)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_849(MethodBind448, GodotObject.GetPtr(this), instance));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind449 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetVisibilityNotifier, 3568945579ul);

    /// <summary>
    /// <para>Sets the given <see cref="Godot.CanvasItem"/> as visibility notifier. <paramref name="area"/> defines the area of detecting visibility. <paramref name="enterCallable"/> is called when the <see cref="Godot.CanvasItem"/> enters the screen, <paramref name="exitCallable"/> is called when the <see cref="Godot.CanvasItem"/> exits the screen. If <paramref name="enable"/> is <see langword="false"/>, the item will no longer function as notifier.</para>
    /// <para>This method can be used to manually mimic <see cref="Godot.VisibleOnScreenNotifier2D"/>.</para>
    /// </summary>
    public unsafe void CanvasItemSetVisibilityNotifier(Rid item, bool enable, Rect2 area, Callable enterCallable, Callable exitCallable)
    {
        NativeCalls.godot_icall_5_1208(MethodBind449, GodotObject.GetPtr(this), item, enable.ToGodotBool(), &area, enterCallable, exitCallable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind450 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetCanvasGroupMode, 3973586316ul);

    /// <summary>
    /// <para>Sets the canvas group mode used during 2D rendering for the canvas item specified by the <paramref name="item"/> RID. For faster but more limited clipping, use <see cref="Godot.RenderingServerInstance.CanvasItemSetClip(Rid, bool)"/> instead.</para>
    /// <para><b>Note:</b> The equivalent node functionality is found in <see cref="Godot.CanvasGroup"/> and <see cref="Godot.CanvasItem.ClipChildren"/>.</para>
    /// </summary>
    public void CanvasItemSetCanvasGroupMode(Rid item, RenderingServer.CanvasGroupMode mode, float clearMargin = 5.0f, bool fitEmpty = false, float fitMargin = 0.0f, bool blurMipmaps = false)
    {
        NativeCalls.godot_icall_6_1209(MethodBind450, GodotObject.GetPtr(this), item, (int)mode, clearMargin, fitEmpty.ToGodotBool(), fitMargin, blurMipmaps.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind451 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DebugCanvasItemGetRect, 624227424ul);

    /// <summary>
    /// <para>Returns the bounding rectangle for a canvas item in local space, as calculated by the renderer. This bound is used internally for culling.</para>
    /// <para><b>Warning:</b> This function is intended for debugging in the editor, and will pass through and return a zero <see cref="Godot.Rect2"/> in exported projects.</para>
    /// </summary>
    public Rect2 DebugCanvasItemGetRect(Rid item)
    {
        return NativeCalls.godot_icall_1_860(MethodBind451, GodotObject.GetPtr(this), item);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind452 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a canvas light and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_light_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.Light2D"/>.</para>
    /// </summary>
    public Rid CanvasLightCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind452, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind453 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightAttachToCanvas, 395945892ul);

    /// <summary>
    /// <para>Attaches the canvas light to the canvas. Removes it from its previous canvas.</para>
    /// </summary>
    public void CanvasLightAttachToCanvas(Rid light, Rid canvas)
    {
        NativeCalls.godot_icall_2_430(MethodBind453, GodotObject.GetPtr(this), light, canvas);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind454 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetEnabled, 1265174801ul);

    /// <summary>
    /// <para>Enables or disables a canvas light.</para>
    /// </summary>
    public void CanvasLightSetEnabled(Rid light, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind454, GodotObject.GetPtr(this), light, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind455 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetTextureScale, 1794382983ul);

    /// <summary>
    /// <para>Sets the scale factor of a <see cref="Godot.PointLight2D"/>'s texture. Equivalent to <see cref="Godot.PointLight2D.TextureScale"/>.</para>
    /// </summary>
    public void CanvasLightSetTextureScale(Rid light, float scale)
    {
        NativeCalls.godot_icall_2_816(MethodBind455, GodotObject.GetPtr(this), light, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind456 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets the canvas light's <see cref="Godot.Transform2D"/>.</para>
    /// </summary>
    public unsafe void CanvasLightSetTransform(Rid light, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind456, GodotObject.GetPtr(this), light, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind457 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetTexture, 395945892ul);

    /// <summary>
    /// <para>Sets the texture to be used by a <see cref="Godot.PointLight2D"/>. Equivalent to <see cref="Godot.PointLight2D.Texture"/>.</para>
    /// </summary>
    public void CanvasLightSetTexture(Rid light, Rid texture)
    {
        NativeCalls.godot_icall_2_430(MethodBind457, GodotObject.GetPtr(this), light, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind458 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetTextureOffset, 3201125042ul);

    /// <summary>
    /// <para>Sets the offset of a <see cref="Godot.PointLight2D"/>'s texture. Equivalent to <see cref="Godot.PointLight2D.Offset"/>.</para>
    /// </summary>
    public unsafe void CanvasLightSetTextureOffset(Rid light, Vector2 offset)
    {
        NativeCalls.godot_icall_2_861(MethodBind458, GodotObject.GetPtr(this), light, &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind459 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetColor, 2948539648ul);

    /// <summary>
    /// <para>Sets the color for a light.</para>
    /// </summary>
    public unsafe void CanvasLightSetColor(Rid light, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind459, GodotObject.GetPtr(this), light, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind460 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetHeight, 1794382983ul);

    /// <summary>
    /// <para>Sets a canvas light's height.</para>
    /// </summary>
    public void CanvasLightSetHeight(Rid light, float height)
    {
        NativeCalls.godot_icall_2_816(MethodBind460, GodotObject.GetPtr(this), light, height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind461 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetEnergy, 1794382983ul);

    /// <summary>
    /// <para>Sets a canvas light's energy.</para>
    /// </summary>
    public void CanvasLightSetEnergy(Rid light, float energy)
    {
        NativeCalls.godot_icall_2_816(MethodBind461, GodotObject.GetPtr(this), light, energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind462 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetZRange, 4288446313ul);

    /// <summary>
    /// <para>Sets the Z range of objects that will be affected by this light. Equivalent to <see cref="Godot.Light2D.RangeZMin"/> and <see cref="Godot.Light2D.RangeZMax"/>.</para>
    /// </summary>
    public void CanvasLightSetZRange(Rid light, int minZ, int maxZ)
    {
        NativeCalls.godot_icall_3_433(MethodBind462, GodotObject.GetPtr(this), light, minZ, maxZ);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind463 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetLayerRange, 4288446313ul);

    /// <summary>
    /// <para>The layer range that gets rendered with this light.</para>
    /// </summary>
    public void CanvasLightSetLayerRange(Rid light, int minLayer, int maxLayer)
    {
        NativeCalls.godot_icall_3_433(MethodBind463, GodotObject.GetPtr(this), light, minLayer, maxLayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind464 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetItemCullMask, 3411492887ul);

    /// <summary>
    /// <para>The light mask. See <see cref="Godot.LightOccluder2D"/> for more information on light masks.</para>
    /// </summary>
    public void CanvasLightSetItemCullMask(Rid light, int mask)
    {
        NativeCalls.godot_icall_2_426(MethodBind464, GodotObject.GetPtr(this), light, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind465 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetItemShadowCullMask, 3411492887ul);

    /// <summary>
    /// <para>The binary mask used to determine which layers this canvas light's shadows affects. See <see cref="Godot.LightOccluder2D"/> for more information on light masks.</para>
    /// </summary>
    public void CanvasLightSetItemShadowCullMask(Rid light, int mask)
    {
        NativeCalls.godot_icall_2_426(MethodBind465, GodotObject.GetPtr(this), light, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind466 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetMode, 2957564891ul);

    /// <summary>
    /// <para>Sets the mode of the canvas light.</para>
    /// </summary>
    public void CanvasLightSetMode(Rid light, RenderingServer.CanvasLightMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind466, GodotObject.GetPtr(this), light, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind467 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetShadowEnabled, 1265174801ul);

    /// <summary>
    /// <para>Enables or disables the canvas light's shadow.</para>
    /// </summary>
    public void CanvasLightSetShadowEnabled(Rid light, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind467, GodotObject.GetPtr(this), light, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind468 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetShadowFilter, 393119659ul);

    /// <summary>
    /// <para>Sets the canvas light's shadow's filter.</para>
    /// </summary>
    public void CanvasLightSetShadowFilter(Rid light, RenderingServer.CanvasLightShadowFilter filter)
    {
        NativeCalls.godot_icall_2_426(MethodBind468, GodotObject.GetPtr(this), light, (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind469 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetShadowColor, 2948539648ul);

    /// <summary>
    /// <para>Sets the color of the canvas light's shadow.</para>
    /// </summary>
    public unsafe void CanvasLightSetShadowColor(Rid light, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind469, GodotObject.GetPtr(this), light, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind470 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetShadowSmooth, 1794382983ul);

    /// <summary>
    /// <para>Smoothens the shadow. The lower, the smoother.</para>
    /// </summary>
    public void CanvasLightSetShadowSmooth(Rid light, float smooth)
    {
        NativeCalls.godot_icall_2_816(MethodBind470, GodotObject.GetPtr(this), light, smooth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind471 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetBlendMode, 804895945ul);

    /// <summary>
    /// <para>Sets the blend mode for the given canvas light to <paramref name="mode"/>. Equivalent to <see cref="Godot.Light2D.BlendMode"/>.</para>
    /// </summary>
    public void CanvasLightSetBlendMode(Rid light, RenderingServer.CanvasLightBlendMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind471, GodotObject.GetPtr(this), light, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind472 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetInterpolated, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="interpolated"/> is <see langword="true"/>, turns on physics interpolation for the canvas light.</para>
    /// </summary>
    public void CanvasLightSetInterpolated(Rid light, bool interpolated)
    {
        NativeCalls.godot_icall_2_434(MethodBind472, GodotObject.GetPtr(this), light, interpolated.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind473 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightResetPhysicsInterpolation, 2722037293ul);

    /// <summary>
    /// <para>Prevents physics interpolation for the current physics tick.</para>
    /// <para>This is useful when moving a canvas item to a new location, to give an instantaneous change rather than interpolation from the previous location.</para>
    /// </summary>
    public void CanvasLightResetPhysicsInterpolation(Rid light)
    {
        NativeCalls.godot_icall_1_286(MethodBind473, GodotObject.GetPtr(this), light);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind474 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightTransformPhysicsInterpolation, 1246044741ul);

    /// <summary>
    /// <para>Transforms both the current and previous stored transform for a canvas light.</para>
    /// <para>This allows transforming a light without creating a "glitch" in the interpolation, which is particularly useful for large worlds utilizing a shifting origin.</para>
    /// </summary>
    public unsafe void CanvasLightTransformPhysicsInterpolation(Rid light, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind474, GodotObject.GetPtr(this), light, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind475 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a light occluder and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_light_occluder_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.LightOccluder2D"/>.</para>
    /// </summary>
    public Rid CanvasLightOccluderCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind475, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind476 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderAttachToCanvas, 395945892ul);

    /// <summary>
    /// <para>Attaches a light occluder to the canvas. Removes it from its previous canvas.</para>
    /// </summary>
    public void CanvasLightOccluderAttachToCanvas(Rid occluder, Rid canvas)
    {
        NativeCalls.godot_icall_2_430(MethodBind476, GodotObject.GetPtr(this), occluder, canvas);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind477 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetEnabled, 1265174801ul);

    /// <summary>
    /// <para>Enables or disables light occluder.</para>
    /// </summary>
    public void CanvasLightOccluderSetEnabled(Rid occluder, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind477, GodotObject.GetPtr(this), occluder, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind478 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetPolygon, 395945892ul);

    /// <summary>
    /// <para>Sets a light occluder's polygon.</para>
    /// </summary>
    public void CanvasLightOccluderSetPolygon(Rid occluder, Rid polygon)
    {
        NativeCalls.godot_icall_2_430(MethodBind478, GodotObject.GetPtr(this), occluder, polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind479 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetAsSdfCollision, 1265174801ul);

    public void CanvasLightOccluderSetAsSdfCollision(Rid occluder, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind479, GodotObject.GetPtr(this), occluder, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind480 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets a light occluder's <see cref="Godot.Transform2D"/>.</para>
    /// </summary>
    public unsafe void CanvasLightOccluderSetTransform(Rid occluder, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind480, GodotObject.GetPtr(this), occluder, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind481 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetLightMask, 3411492887ul);

    /// <summary>
    /// <para>The light mask. See <see cref="Godot.LightOccluder2D"/> for more information on light masks.</para>
    /// </summary>
    public void CanvasLightOccluderSetLightMask(Rid occluder, int mask)
    {
        NativeCalls.godot_icall_2_426(MethodBind481, GodotObject.GetPtr(this), occluder, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind482 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetInterpolated, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="interpolated"/> is <see langword="true"/>, turns on physics interpolation for the light occluder.</para>
    /// </summary>
    public void CanvasLightOccluderSetInterpolated(Rid occluder, bool interpolated)
    {
        NativeCalls.godot_icall_2_434(MethodBind482, GodotObject.GetPtr(this), occluder, interpolated.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind483 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderResetPhysicsInterpolation, 2722037293ul);

    /// <summary>
    /// <para>Prevents physics interpolation for the current physics tick.</para>
    /// <para>This is useful when moving an occluder to a new location, to give an instantaneous change rather than interpolation from the previous location.</para>
    /// </summary>
    public void CanvasLightOccluderResetPhysicsInterpolation(Rid occluder)
    {
        NativeCalls.godot_icall_1_286(MethodBind483, GodotObject.GetPtr(this), occluder);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind484 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderTransformPhysicsInterpolation, 1246044741ul);

    /// <summary>
    /// <para>Transforms both the current and previous stored transform for a light occluder.</para>
    /// <para>This allows transforming an occluder without creating a "glitch" in the interpolation, which is particularly useful for large worlds utilizing a shifting origin.</para>
    /// </summary>
    public unsafe void CanvasLightOccluderTransformPhysicsInterpolation(Rid occluder, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind484, GodotObject.GetPtr(this), occluder, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind485 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasOccluderPolygonCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new light occluder polygon and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_occluder_polygon_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServerInstance.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.OccluderPolygon2D"/>.</para>
    /// </summary>
    public Rid CanvasOccluderPolygonCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind485, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind486 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasOccluderPolygonSetShape, 2103882027ul);

    /// <summary>
    /// <para>Sets the shape of the occluder polygon.</para>
    /// </summary>
    public void CanvasOccluderPolygonSetShape(Rid occluderPolygon, Vector2[] shape, bool closed)
    {
        NativeCalls.godot_icall_3_1210(MethodBind486, GodotObject.GetPtr(this), occluderPolygon, shape, closed.ToGodotBool());
    }

    /// <summary>
    /// <para>Sets the shape of the occluder polygon.</para>
    /// </summary>
    public void CanvasOccluderPolygonSetShape(Rid occluderPolygon, ReadOnlySpan<Vector2> shape, bool closed)
    {
        NativeCalls.godot_icall_3_1210(MethodBind486, GodotObject.GetPtr(this), occluderPolygon, shape, closed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind487 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasOccluderPolygonSetCullMode, 1839404663ul);

    /// <summary>
    /// <para>Sets an occluder polygon's cull mode.</para>
    /// </summary>
    public void CanvasOccluderPolygonSetCullMode(Rid occluderPolygon, RenderingServer.CanvasOccluderPolygonCullMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind487, GodotObject.GetPtr(this), occluderPolygon, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind488 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasSetShadowTextureSize, 1286410249ul);

    /// <summary>
    /// <para>Sets the <c>ProjectSettings.rendering/2d/shadow_atlas/size</c> to use for <see cref="Godot.Light2D"/> shadow rendering (in pixels). The value is rounded up to the nearest power of 2.</para>
    /// </summary>
    public void CanvasSetShadowTextureSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind488, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind489 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterAdd, 463390080ul);

    /// <summary>
    /// <para>Creates a new global shader uniform.</para>
    /// <para><b>Note:</b> Global shader parameter names are case-sensitive.</para>
    /// </summary>
    public void GlobalShaderParameterAdd(StringName name, RenderingServer.GlobalShaderParameterType type, Variant defaultValue)
    {
        NativeCalls.godot_icall_3_1211(MethodBind489, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (int)type, defaultValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind490 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterRemove, 3304788590ul);

    /// <summary>
    /// <para>Removes the global shader uniform specified by <paramref name="name"/>.</para>
    /// </summary>
    public void GlobalShaderParameterRemove(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind490, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind491 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterGetList, 3995934104ul);

    /// <summary>
    /// <para>Returns the list of global shader uniform names.</para>
    /// <para><b>Note:</b> <see cref="Godot.RenderingServerInstance.GlobalShaderParameterGet(StringName)"/> has a large performance penalty as the rendering thread needs to synchronize with the calling thread, which is slow. Do not use this method during gameplay to avoid stuttering. If you need to read values in a script after setting them, consider creating an autoload where you store the values you need to query at the same time you're setting them as global parameters.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GlobalShaderParameterGetList()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind491, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind492 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterSet, 3776071444ul);

    /// <summary>
    /// <para>Sets the global shader uniform <paramref name="name"/> to <paramref name="value"/>.</para>
    /// </summary>
    public void GlobalShaderParameterSet(StringName name, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind492, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind493 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterSetOverride, 3776071444ul);

    /// <summary>
    /// <para>Overrides the global shader uniform <paramref name="name"/> with <paramref name="value"/>. Equivalent to the <see cref="Godot.ShaderGlobalsOverride"/> node.</para>
    /// </summary>
    public void GlobalShaderParameterSetOverride(StringName name, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind493, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind494 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterGet, 2760726917ul);

    /// <summary>
    /// <para>Returns the value of the global shader uniform specified by <paramref name="name"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.RenderingServerInstance.GlobalShaderParameterGet(StringName)"/> has a large performance penalty as the rendering thread needs to synchronize with the calling thread, which is slow. Do not use this method during gameplay to avoid stuttering. If you need to read values in a script after setting them, consider creating an autoload where you store the values you need to query at the same time you're setting them as global parameters.</para>
    /// </summary>
    public Variant GlobalShaderParameterGet(StringName name)
    {
        return NativeCalls.godot_icall_1_143(MethodBind494, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind495 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterGetType, 1601414142ul);

    /// <summary>
    /// <para>Returns the type associated to the global shader uniform specified by <paramref name="name"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.RenderingServerInstance.GlobalShaderParameterGet(StringName)"/> has a large performance penalty as the rendering thread needs to synchronize with the calling thread, which is slow. Do not use this method during gameplay to avoid stuttering. If you need to read values in a script after setting them, consider creating an autoload where you store the values you need to query at the same time you're setting them as global parameters.</para>
    /// </summary>
    public RenderingServer.GlobalShaderParameterType GlobalShaderParameterGetType(StringName name)
    {
        return (RenderingServer.GlobalShaderParameterType)NativeCalls.godot_icall_1_193(MethodBind495, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind496 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeRid, 2722037293ul);

    /// <summary>
    /// <para>Tries to free an object in the RenderingServer. To avoid memory leaks, this should be called after using an object as memory management does not occur automatically when using RenderingServer directly.</para>
    /// </summary>
    public void FreeRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind496, GodotObject.GetPtr(this), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind497 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestFrameDrawnCallback, 1611583062ul);

    /// <summary>
    /// <para>Schedules a callback to the given callable after a frame has been drawn.</para>
    /// </summary>
    public void RequestFrameDrawnCallback(Callable callable)
    {
        NativeCalls.godot_icall_1_403(MethodBind497, GodotObject.GetPtr(this), callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind498 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasChanged, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if changes have been made to the RenderingServer's data. <see cref="Godot.RenderingServerInstance.ForceDraw(bool, double)"/> is usually called if this happens.</para>
    /// </summary>
    public bool HasChanged()
    {
        return NativeCalls.godot_icall_0_15(MethodBind498, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind499 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderingInfo, 3763192241ul);

    /// <summary>
    /// <para>Returns a statistic about the rendering engine which can be used for performance profiling. See also <see cref="Godot.RenderingServerInstance.ViewportGetRenderInfo(Rid, RenderingServer.ViewportRenderInfoType, RenderingServer.ViewportRenderInfo)"/>, which returns information specific to a viewport.</para>
    /// <para><b>Note:</b> Only 3D rendering is currently taken into account by some of these values, such as the number of draw calls.</para>
    /// <para><b>Note:</b> Rendering information is not available until at least 2 frames have been rendered by the engine. If rendering information is not available, <see cref="Godot.RenderingServerInstance.GetRenderingInfo(RenderingServer.RenderingInfo)"/> returns <c>0</c>. To print rendering information in <c>_ready()</c> successfully, use the following:</para>
    /// <para><code>
    /// func _ready():
    /// 	for _i in 2:
    /// 		await get_tree().process_frame
    /// 
    /// 	print(RenderingServer.get_rendering_info(RENDERING_INFO_TOTAL_DRAW_CALLS_IN_FRAME))
    /// </code></para>
    /// </summary>
    public ulong GetRenderingInfo(RenderingServer.RenderingInfo info)
    {
        return NativeCalls.godot_icall_1_240(MethodBind499, GodotObject.GetPtr(this), (int)info);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind500 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVideoAdapterName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the video adapter (e.g. "GeForce GTX 1080/PCIe/SSE2").</para>
    /// <para><b>Note:</b> When running a headless or server binary, this function returns an empty string.</para>
    /// <para><b>Note:</b> On the web platform, some browsers such as Firefox may report a different, fixed GPU name such as "GeForce GTX 980" (regardless of the user's actual GPU model). This is done to make fingerprinting more difficult.</para>
    /// </summary>
    public string GetVideoAdapterName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind500, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind501 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVideoAdapterVendor, 201670096ul);

    /// <summary>
    /// <para>Returns the vendor of the video adapter (e.g. "NVIDIA Corporation").</para>
    /// <para><b>Note:</b> When running a headless or server binary, this function returns an empty string.</para>
    /// </summary>
    public string GetVideoAdapterVendor()
    {
        return NativeCalls.godot_icall_0_58(MethodBind501, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind502 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVideoAdapterType, 3099547011ul);

    /// <summary>
    /// <para>Returns the type of the video adapter. Since dedicated graphics cards from a given generation will <i>usually</i> be significantly faster than integrated graphics made in the same generation, the device type can be used as a basis for automatic graphics settings adjustment. However, this is not always true, so make sure to provide users with a way to manually override graphics settings.</para>
    /// <para><b>Note:</b> When using the OpenGL rendering driver or when running in headless mode, this function always returns <see cref="Godot.RenderingDevice.DeviceType.Other"/>.</para>
    /// </summary>
    public RenderingDevice.DeviceType GetVideoAdapterType()
    {
        return (RenderingDevice.DeviceType)NativeCalls.godot_icall_0_39(MethodBind502, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind503 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVideoAdapterApiVersion, 201670096ul);

    /// <summary>
    /// <para>Returns the version of the graphics video adapter <i>currently in use</i> (e.g. "1.2.189" for Vulkan, "3.3.0 NVIDIA 510.60.02" for OpenGL). This version may be different from the actual latest version supported by the hardware, as Godot may not always request the latest version. See also <see cref="Godot.OS.GetVideoAdapterDriverInfo()"/>.</para>
    /// <para><b>Note:</b> When running a headless or server binary, this function returns an empty string.</para>
    /// </summary>
    public string GetVideoAdapterApiVersion()
    {
        return NativeCalls.godot_icall_0_58(MethodBind503, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind504 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentRenderingDriverName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the current rendering driver. This can be <c>vulkan</c>, <c>d3d12</c>, <c>metal</c>, <c>opengl3</c>, <c>opengl3_es</c>, or <c>opengl3_angle</c>. See also <see cref="Godot.RenderingServerInstance.GetCurrentRenderingMethod()"/>.</para>
    /// <para>When <c>ProjectSettings.rendering/renderer/rendering_method</c> is <c>forward_plus</c> or <c>mobile</c>, the rendering driver is determined by <c>ProjectSettings.rendering/rendering_device/driver</c>.</para>
    /// <para>When <c>ProjectSettings.rendering/renderer/rendering_method</c> is <c>gl_compatibility</c>, the rendering driver is determined by <c>ProjectSettings.rendering/gl_compatibility/driver</c>.</para>
    /// <para>The rendering driver is also determined by the <c>--rendering-driver</c> command line argument that overrides this project setting, or an automatic fallback that is applied depending on the hardware.</para>
    /// </summary>
    public string GetCurrentRenderingDriverName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind504, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind505 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentRenderingMethod, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the current rendering method. This can be <c>forward_plus</c>, <c>mobile</c>, or <c>gl_compatibility</c>. See also <see cref="Godot.RenderingServerInstance.GetCurrentRenderingDriverName()"/>.</para>
    /// <para>The rendering method is determined by <c>ProjectSettings.rendering/renderer/rendering_method</c>, the <c>--rendering-method</c> command line argument that overrides this project setting, or an automatic fallback that is applied depending on the hardware.</para>
    /// </summary>
    public string GetCurrentRenderingMethod()
    {
        return NativeCalls.godot_icall_0_58(MethodBind505, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind506 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeSphereMesh, 2251015897ul);

    /// <summary>
    /// <para>Returns a mesh of a sphere with the given number of horizontal subdivisions, vertical subdivisions and radius. See also <see cref="Godot.RenderingServerInstance.GetTestCube()"/>.</para>
    /// </summary>
    public Rid MakeSphereMesh(int latitudes, int longitudes, float radius)
    {
        return NativeCalls.godot_icall_3_1212(MethodBind506, GodotObject.GetPtr(this), latitudes, longitudes, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind507 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTestCube, 529393457ul);

    /// <summary>
    /// <para>Returns the RID of the test cube. This mesh will be created and returned on the first call to <see cref="Godot.RenderingServerInstance.GetTestCube()"/>, then it will be cached for subsequent calls. See also <see cref="Godot.RenderingServerInstance.MakeSphereMesh(int, int, float)"/>.</para>
    /// </summary>
    public Rid GetTestCube()
    {
        return NativeCalls.godot_icall_0_238(MethodBind507, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind508 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTestTexture, 529393457ul);

    /// <summary>
    /// <para>Returns the RID of a 256×256 texture with a testing pattern on it (in <see cref="Godot.Image.Format.Rgb8"/> format). This texture will be created and returned on the first call to <see cref="Godot.RenderingServerInstance.GetTestTexture()"/>, then it will be cached for subsequent calls. See also <see cref="Godot.RenderingServerInstance.GetWhiteTexture()"/>.</para>
    /// <para><b>Example:</b> Get the test texture and apply it to a <see cref="Godot.Sprite2D"/> node:</para>
    /// <para><code>
    /// var texture_rid = RenderingServer.get_test_texture()
    /// var texture = ImageTexture.create_from_image(RenderingServer.texture_2d_get(texture_rid))
    /// $Sprite2D.texture = texture
    /// </code></para>
    /// </summary>
    public Rid GetTestTexture()
    {
        return NativeCalls.godot_icall_0_238(MethodBind508, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind509 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWhiteTexture, 529393457ul);

    /// <summary>
    /// <para>Returns the ID of a 4×4 white texture (in <see cref="Godot.Image.Format.Rgb8"/> format). This texture will be created and returned on the first call to <see cref="Godot.RenderingServerInstance.GetWhiteTexture()"/>, then it will be cached for subsequent calls. See also <see cref="Godot.RenderingServerInstance.GetTestTexture()"/>.</para>
    /// <para><b>Example:</b> Get the white texture and apply it to a <see cref="Godot.Sprite2D"/> node:</para>
    /// <para><code>
    /// var texture_rid = RenderingServer.get_white_texture()
    /// var texture = ImageTexture.create_from_image(RenderingServer.texture_2d_get(texture_rid))
    /// $Sprite2D.texture = texture
    /// </code></para>
    /// </summary>
    public Rid GetWhiteTexture()
    {
        return NativeCalls.godot_icall_0_238(MethodBind509, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind510 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBootImageWithStretch, 1104470771ul);

    /// <summary>
    /// <para>Sets a boot image. The <paramref name="color"/> defines the background color. The value of <paramref name="stretchMode"/> indicates how the image will be stretched (see <see cref="Godot.RenderingServer.SplashStretchMode"/> for possible values). If <paramref name="useFilter"/> is <see langword="true"/>, the image will be scaled with linear interpolation. If <paramref name="useFilter"/> is <see langword="false"/>, the image will be scaled with nearest-neighbor interpolation.</para>
    /// </summary>
    public unsafe void SetBootImageWithStretch(Image image, Color color, RenderingServer.SplashStretchMode stretchMode, bool useFilter = true)
    {
        NativeCalls.godot_icall_4_1213(MethodBind510, GodotObject.GetPtr(this), GodotObject.GetPtr(image), &color, (int)stretchMode, useFilter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind511 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBootImage, 3759744527ul);

    /// <summary>
    /// <para>Sets a boot image. The <paramref name="color"/> defines the background color. The value of <paramref name="scale"/> indicates if the image will be scaled to fit the screen size. If <paramref name="useFilter"/> is <see langword="true"/>, the image will be scaled with linear interpolation. If <paramref name="useFilter"/> is <see langword="false"/>, the image will be scaled with nearest-neighbor interpolation.</para>
    /// </summary>
    [Obsolete("Use 'Godot.RenderingServerInstance.SetBootImageWithStretch(Image, Color, RenderingServer.SplashStretchMode, bool)' instead.")]
    public unsafe void SetBootImage(Image image, Color color, bool scale, bool useFilter = true)
    {
        NativeCalls.godot_icall_4_1214(MethodBind511, GodotObject.GetPtr(this), GodotObject.GetPtr(image), &color, scale.ToGodotBool(), useFilter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind512 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultClearColor, 3200896285ul);

    /// <summary>
    /// <para>Returns the default clear color which is used when a specific clear color has not been selected. See also <see cref="Godot.RenderingServerInstance.SetDefaultClearColor(Color)"/>.</para>
    /// </summary>
    public Color GetDefaultClearColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind512, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind513 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultClearColor, 2920490490ul);

    /// <summary>
    /// <para>Sets the default clear color which is used when a specific clear color has not been selected. See also <see cref="Godot.RenderingServerInstance.GetDefaultClearColor()"/>.</para>
    /// </summary>
    public unsafe void SetDefaultClearColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind513, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind514 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasOsFeature, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the OS supports a certain <paramref name="feature"/>. Features might be <c>s3tc</c>, <c>etc</c>, and <c>etc2</c>.</para>
    /// </summary>
    public bool HasOsFeature(string feature)
    {
        return NativeCalls.godot_icall_1_131(MethodBind514, GodotObject.GetPtr(this), feature).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind515 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugGenerateWireframes, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="generate"/> is <see langword="true"/>, generates debug wireframes for all meshes that are loaded when using the Compatibility renderer. By default, the engine does not generate debug wireframes at runtime, since they slow down loading of assets and take up VRAM.</para>
    /// <para><b>Note:</b> You must call this method before loading any meshes when using the Compatibility renderer, otherwise wireframes will not be used.</para>
    /// </summary>
    public void SetDebugGenerateWireframes(bool generate)
    {
        NativeCalls.godot_icall_1_14(MethodBind515, GodotObject.GetPtr(this), generate.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind516 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRenderLoopEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRenderLoopEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind516, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind517 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderLoopEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRenderLoopEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind517, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind518 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameSetupTimeCpu, 1740695150ul);

    /// <summary>
    /// <para>Returns the time taken to setup rendering on the CPU in milliseconds. This value is shared across all viewports and does <i>not</i> require <see cref="Godot.RenderingServerInstance.ViewportSetMeasureRenderTime(Rid, bool)"/> to be enabled on a viewport to be queried. See also <see cref="Godot.RenderingServerInstance.ViewportGetMeasuredRenderTimeCpu(Rid)"/>.</para>
    /// </summary>
    public double GetFrameSetupTimeCpu()
    {
        return NativeCalls.godot_icall_0_144(MethodBind518, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind519 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceSync, 3218959716ul);

    /// <summary>
    /// <para>Forces a synchronization between the CPU and GPU, which may be required in certain cases. Only call this when needed, as CPU-GPU synchronization has a performance cost.</para>
    /// </summary>
    public void ForceSync()
    {
        NativeCalls.godot_icall_0_3(MethodBind519, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind520 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceDraw, 1076185472ul);

    /// <summary>
    /// <para>Forces redrawing of all viewports at once. Must be called from the main thread.</para>
    /// </summary>
    public void ForceDraw(bool swapBuffers = true, double frameStep = 0.0)
    {
        NativeCalls.godot_icall_2_1215(MethodBind520, GodotObject.GetPtr(this), swapBuffers.ToGodotBool(), frameStep);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind521 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderingDevice, 1405107940ul);

    /// <summary>
    /// <para>Returns the global RenderingDevice.</para>
    /// <para><b>Note:</b> When using the OpenGL rendering driver or when running in headless mode, this function always returns <see langword="null"/>.</para>
    /// </summary>
    public RenderingDevice GetRenderingDevice()
    {
        return (RenderingDevice)NativeCalls.godot_icall_0_53(MethodBind521, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind522 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateLocalRenderingDevice, 1405107940ul);

    /// <summary>
    /// <para>Creates a RenderingDevice that can be used to do draw and compute operations on a separate thread. Cannot draw to the screen nor share data with the global RenderingDevice.</para>
    /// <para><b>Note:</b> When using the OpenGL rendering driver or when running in headless mode, this function always returns <see langword="null"/>.</para>
    /// </summary>
    public RenderingDevice CreateLocalRenderingDevice()
    {
        return (RenderingDevice)NativeCalls.godot_icall_0_53(MethodBind522, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind523 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOnRenderThread, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if our code is currently executing on the rendering thread.</para>
    /// </summary>
    public bool IsOnRenderThread()
    {
        return NativeCalls.godot_icall_0_15(MethodBind523, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind524 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CallOnRenderThread, 1611583062ul);

    /// <summary>
    /// <para>As the RenderingServer actual logic may run on a separate thread, accessing its internals from the main (or any other) thread will result in errors. To make it easier to run code that can safely access the rendering internals (such as <see cref="Godot.RenderingDevice"/> and similar RD classes), push a callable via this function so it will be executed on the render thread.</para>
    /// </summary>
    public void CallOnRenderThread(Callable callable)
    {
        NativeCalls.godot_icall_1_403(MethodBind524, GodotObject.GetPtr(this), callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind525 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasFeature, 598462696ul);

    /// <summary>
    /// <para>This method does nothing and always returns <see langword="false"/>.</para>
    /// </summary>
    [Obsolete("This method has not been used since Godot 3.0.")]
    public bool HasFeature(RenderingServer.Features feature)
    {
        return NativeCalls.godot_icall_1_62(MethodBind525, GodotObject.GetPtr(this), (int)feature).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind526 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceResetPhysicsInterpolation, 2722037293ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void InstanceResetPhysicsInterpolation(Rid instance)
    {
        NativeCalls.godot_icall_1_286(MethodBind526, GodotObject.GetPtr(this), instance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind527 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetInterpolated, 1265174801ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void InstanceSetInterpolated(Rid instance, bool interpolated)
    {
        NativeCalls.godot_icall_2_434(MethodBind527, GodotObject.GetPtr(this), instance, interpolated.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind528 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddCircle, 2439351960ul);

    /// <summary>
    /// <para>Draws a circle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawCircle(Vector2, float, Color, bool, float, bool)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void CanvasItemAddCircle(Rid item, Vector2 pos, float radius, Color color)
    {
        NativeCalls.godot_icall_4_1216(MethodBind528, GodotObject.GetPtr(this), item, &pos, radius, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind529 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddRect, 934531857ul);

    /// <summary>
    /// <para>Draws a rectangle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawRect(Rect2, Color, bool, float, bool)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void CanvasItemAddRect(Rid item, Rect2 rect, Color color)
    {
        NativeCalls.godot_icall_3_1217(MethodBind529, GodotObject.GetPtr(this), item, &rect, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind530 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddMultiline, 2088642721ul);

    /// <summary>
    /// <para>Draws a 2D multiline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawMultilineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void CanvasItemAddMultiline(Rid item, Vector2[] points, Color[] colors, float width)
    {
        NativeCalls.godot_icall_4_1218(MethodBind530, GodotObject.GetPtr(this), item, points, colors, width);
    }

    /// <summary>
    /// <para>Draws a 2D multiline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawMultilineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void CanvasItemAddMultiline(Rid item, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, float width)
    {
        NativeCalls.godot_icall_4_1218(MethodBind530, GodotObject.GetPtr(this), item, points, colors, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind531 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetFog, 2793577733ul);

    /// <summary>
    /// <para>Configures fog for the specified environment RID. See <c>fog_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void EnvironmentSetFog(Rid env, bool enable, Color lightColor, float lightEnergy, float sunScatter, float density, float height, float heightDensity, float aerialPerspective, float skyAffect)
    {
        NativeCalls.godot_icall_10_1219(MethodBind531, GodotObject.GetPtr(this), env, enable.ToGodotBool(), &lightColor, lightEnergy, sunScatter, density, height, heightDensity, aerialPerspective, skyAffect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind532 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshAllocateData, 283685892ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void MultimeshAllocateData(Rid multimesh, int instances, RenderingServer.MultimeshTransformFormat transformFormat, bool colorFormat, bool customDataFormat)
    {
        NativeCalls.godot_icall_5_1220(MethodBind532, GodotObject.GetPtr(this), multimesh, instances, (int)transformFormat, colorFormat.ToGodotBool(), customDataFormat.ToGodotBool());
    }

    /// <summary>
    /// <para>Emitted at the beginning of the frame, before the RenderingServer updates all the Viewports.</para>
    /// </summary>
    public event Action FramePreDraw
    {
        add => Connect(SignalName.FramePreDraw, Callable.From(value));
        remove => Disconnect(SignalName.FramePreDraw, Callable.From(value));
    }

    protected void EmitSignalFramePreDraw()
    {
        EmitSignal(SignalName.FramePreDraw);
    }

    /// <summary>
    /// <para>Emitted at the end of the frame, after the RenderingServer has finished updating all the Viewports.</para>
    /// </summary>
    public event Action FramePostDraw
    {
        add => Connect(SignalName.FramePostDraw, Callable.From(value));
        remove => Disconnect(SignalName.FramePostDraw, Callable.From(value));
    }

    protected void EmitSignalFramePostDraw()
    {
        EmitSignal(SignalName.FramePostDraw);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_frame_pre_draw = "FramePreDraw";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_frame_post_draw = "FramePostDraw";

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
        if (signal == SignalName.FramePreDraw)
        {
            if (HasGodotClassSignal(SignalProxyName_frame_pre_draw.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FramePostDraw)
        {
            if (HasGodotClassSignal(SignalProxyName_frame_post_draw.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : GodotObject.PropertyName
    {
        /// <summary>
        /// Cached name for the 'render_loop_enabled' property.
        /// </summary>
        public static readonly StringName RenderLoopEnabled = "render_loop_enabled";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'texture_2d_create' method.
        /// </summary>
        public static readonly StringName Texture2DCreate = "texture_2d_create";
        /// <summary>
        /// Cached name for the 'texture_2d_layered_create' method.
        /// </summary>
        public static readonly StringName Texture2DLayeredCreate = "texture_2d_layered_create";
        /// <summary>
        /// Cached name for the 'texture_3d_create' method.
        /// </summary>
        public static readonly StringName Texture3DCreate = "texture_3d_create";
        /// <summary>
        /// Cached name for the 'texture_proxy_create' method.
        /// </summary>
        public static readonly StringName TextureProxyCreate = "texture_proxy_create";
        /// <summary>
        /// Cached name for the 'texture_create_from_native_handle' method.
        /// </summary>
        public static readonly StringName TextureCreateFromNativeHandle = "texture_create_from_native_handle";
        /// <summary>
        /// Cached name for the 'texture_2d_update' method.
        /// </summary>
        public static readonly StringName Texture2DUpdate = "texture_2d_update";
        /// <summary>
        /// Cached name for the 'texture_3d_update' method.
        /// </summary>
        public static readonly StringName Texture3DUpdate = "texture_3d_update";
        /// <summary>
        /// Cached name for the 'texture_proxy_update' method.
        /// </summary>
        public static readonly StringName TextureProxyUpdate = "texture_proxy_update";
        /// <summary>
        /// Cached name for the 'texture_2d_placeholder_create' method.
        /// </summary>
        public static readonly StringName Texture2DPlaceholderCreate = "texture_2d_placeholder_create";
        /// <summary>
        /// Cached name for the 'texture_2d_layered_placeholder_create' method.
        /// </summary>
        public static readonly StringName Texture2DLayeredPlaceholderCreate = "texture_2d_layered_placeholder_create";
        /// <summary>
        /// Cached name for the 'texture_3d_placeholder_create' method.
        /// </summary>
        public static readonly StringName Texture3DPlaceholderCreate = "texture_3d_placeholder_create";
        /// <summary>
        /// Cached name for the 'texture_2d_get' method.
        /// </summary>
        public static readonly StringName Texture2DGet = "texture_2d_get";
        /// <summary>
        /// Cached name for the 'texture_2d_layer_get' method.
        /// </summary>
        public static readonly StringName Texture2DLayerGet = "texture_2d_layer_get";
        /// <summary>
        /// Cached name for the 'texture_3d_get' method.
        /// </summary>
        public static readonly StringName Texture3DGet = "texture_3d_get";
        /// <summary>
        /// Cached name for the 'texture_replace' method.
        /// </summary>
        public static readonly StringName TextureReplace = "texture_replace";
        /// <summary>
        /// Cached name for the 'texture_set_size_override' method.
        /// </summary>
        public static readonly StringName TextureSetSizeOverride = "texture_set_size_override";
        /// <summary>
        /// Cached name for the 'texture_set_path' method.
        /// </summary>
        public static readonly StringName TextureSetPath = "texture_set_path";
        /// <summary>
        /// Cached name for the 'texture_get_path' method.
        /// </summary>
        public static readonly StringName TextureGetPath = "texture_get_path";
        /// <summary>
        /// Cached name for the 'texture_get_format' method.
        /// </summary>
        public static readonly StringName TextureGetFormat = "texture_get_format";
        /// <summary>
        /// Cached name for the 'texture_set_force_redraw_if_visible' method.
        /// </summary>
        public static readonly StringName TextureSetForceRedrawIfVisible = "texture_set_force_redraw_if_visible";
        /// <summary>
        /// Cached name for the 'texture_rd_create' method.
        /// </summary>
        public static readonly StringName TextureRdCreate = "texture_rd_create";
        /// <summary>
        /// Cached name for the 'texture_get_rd_texture' method.
        /// </summary>
        public static readonly StringName TextureGetRdTexture = "texture_get_rd_texture";
        /// <summary>
        /// Cached name for the 'texture_get_native_handle' method.
        /// </summary>
        public static readonly StringName TextureGetNativeHandle = "texture_get_native_handle";
        /// <summary>
        /// Cached name for the 'shader_create' method.
        /// </summary>
        public static readonly StringName ShaderCreate = "shader_create";
        /// <summary>
        /// Cached name for the 'shader_set_code' method.
        /// </summary>
        public static readonly StringName ShaderSetCode = "shader_set_code";
        /// <summary>
        /// Cached name for the 'shader_set_path_hint' method.
        /// </summary>
        public static readonly StringName ShaderSetPathHint = "shader_set_path_hint";
        /// <summary>
        /// Cached name for the 'shader_get_code' method.
        /// </summary>
        public static readonly StringName ShaderGetCode = "shader_get_code";
        /// <summary>
        /// Cached name for the 'get_shader_parameter_list' method.
        /// </summary>
        public static readonly StringName GetShaderParameterList = "get_shader_parameter_list";
        /// <summary>
        /// Cached name for the 'shader_get_parameter_default' method.
        /// </summary>
        public static readonly StringName ShaderGetParameterDefault = "shader_get_parameter_default";
        /// <summary>
        /// Cached name for the 'shader_set_default_texture_parameter' method.
        /// </summary>
        public static readonly StringName ShaderSetDefaultTextureParameter = "shader_set_default_texture_parameter";
        /// <summary>
        /// Cached name for the 'shader_get_default_texture_parameter' method.
        /// </summary>
        public static readonly StringName ShaderGetDefaultTextureParameter = "shader_get_default_texture_parameter";
        /// <summary>
        /// Cached name for the 'material_create' method.
        /// </summary>
        public static readonly StringName MaterialCreate = "material_create";
        /// <summary>
        /// Cached name for the 'material_set_shader' method.
        /// </summary>
        public static readonly StringName MaterialSetShader = "material_set_shader";
        /// <summary>
        /// Cached name for the 'material_set_param' method.
        /// </summary>
        public static readonly StringName MaterialSetParam = "material_set_param";
        /// <summary>
        /// Cached name for the 'material_get_param' method.
        /// </summary>
        public static readonly StringName MaterialGetParam = "material_get_param";
        /// <summary>
        /// Cached name for the 'material_set_render_priority' method.
        /// </summary>
        public static readonly StringName MaterialSetRenderPriority = "material_set_render_priority";
        /// <summary>
        /// Cached name for the 'material_set_next_pass' method.
        /// </summary>
        public static readonly StringName MaterialSetNextPass = "material_set_next_pass";
        /// <summary>
        /// Cached name for the 'material_set_use_debanding' method.
        /// </summary>
        public static readonly StringName MaterialSetUseDebanding = "material_set_use_debanding";
        /// <summary>
        /// Cached name for the 'mesh_create_from_surfaces' method.
        /// </summary>
        public static readonly StringName MeshCreateFromSurfaces = "mesh_create_from_surfaces";
        /// <summary>
        /// Cached name for the 'mesh_create' method.
        /// </summary>
        public static readonly StringName MeshCreate = "mesh_create";
        /// <summary>
        /// Cached name for the 'mesh_surface_get_format_offset' method.
        /// </summary>
        public static readonly StringName MeshSurfaceGetFormatOffset = "mesh_surface_get_format_offset";
        /// <summary>
        /// Cached name for the 'mesh_surface_get_format_vertex_stride' method.
        /// </summary>
        public static readonly StringName MeshSurfaceGetFormatVertexStride = "mesh_surface_get_format_vertex_stride";
        /// <summary>
        /// Cached name for the 'mesh_surface_get_format_normal_tangent_stride' method.
        /// </summary>
        public static readonly StringName MeshSurfaceGetFormatNormalTangentStride = "mesh_surface_get_format_normal_tangent_stride";
        /// <summary>
        /// Cached name for the 'mesh_surface_get_format_attribute_stride' method.
        /// </summary>
        public static readonly StringName MeshSurfaceGetFormatAttributeStride = "mesh_surface_get_format_attribute_stride";
        /// <summary>
        /// Cached name for the 'mesh_surface_get_format_skin_stride' method.
        /// </summary>
        public static readonly StringName MeshSurfaceGetFormatSkinStride = "mesh_surface_get_format_skin_stride";
        /// <summary>
        /// Cached name for the 'mesh_surface_get_format_index_stride' method.
        /// </summary>
        public static readonly StringName MeshSurfaceGetFormatIndexStride = "mesh_surface_get_format_index_stride";
        /// <summary>
        /// Cached name for the 'mesh_add_surface' method.
        /// </summary>
        public static readonly StringName MeshAddSurface = "mesh_add_surface";
        /// <summary>
        /// Cached name for the 'mesh_add_surface_from_arrays' method.
        /// </summary>
        public static readonly StringName MeshAddSurfaceFromArrays = "mesh_add_surface_from_arrays";
        /// <summary>
        /// Cached name for the 'mesh_get_blend_shape_count' method.
        /// </summary>
        public static readonly StringName MeshGetBlendShapeCount = "mesh_get_blend_shape_count";
        /// <summary>
        /// Cached name for the 'mesh_set_blend_shape_mode' method.
        /// </summary>
        public static readonly StringName MeshSetBlendShapeMode = "mesh_set_blend_shape_mode";
        /// <summary>
        /// Cached name for the 'mesh_get_blend_shape_mode' method.
        /// </summary>
        public static readonly StringName MeshGetBlendShapeMode = "mesh_get_blend_shape_mode";
        /// <summary>
        /// Cached name for the 'mesh_surface_set_material' method.
        /// </summary>
        public static readonly StringName MeshSurfaceSetMaterial = "mesh_surface_set_material";
        /// <summary>
        /// Cached name for the 'mesh_surface_get_material' method.
        /// </summary>
        public static readonly StringName MeshSurfaceGetMaterial = "mesh_surface_get_material";
        /// <summary>
        /// Cached name for the 'mesh_get_surface' method.
        /// </summary>
        public static readonly StringName MeshGetSurface = "mesh_get_surface";
        /// <summary>
        /// Cached name for the 'mesh_surface_get_arrays' method.
        /// </summary>
        public static readonly StringName MeshSurfaceGetArrays = "mesh_surface_get_arrays";
        /// <summary>
        /// Cached name for the 'mesh_surface_get_blend_shape_arrays' method.
        /// </summary>
        public static readonly StringName MeshSurfaceGetBlendShapeArrays = "mesh_surface_get_blend_shape_arrays";
        /// <summary>
        /// Cached name for the 'mesh_get_surface_count' method.
        /// </summary>
        public static readonly StringName MeshGetSurfaceCount = "mesh_get_surface_count";
        /// <summary>
        /// Cached name for the 'mesh_set_custom_aabb' method.
        /// </summary>
        public static readonly StringName MeshSetCustomAabb = "mesh_set_custom_aabb";
        /// <summary>
        /// Cached name for the 'mesh_get_custom_aabb' method.
        /// </summary>
        public static readonly StringName MeshGetCustomAabb = "mesh_get_custom_aabb";
        /// <summary>
        /// Cached name for the 'mesh_surface_remove' method.
        /// </summary>
        public static readonly StringName MeshSurfaceRemove = "mesh_surface_remove";
        /// <summary>
        /// Cached name for the 'mesh_clear' method.
        /// </summary>
        public static readonly StringName MeshClear = "mesh_clear";
        /// <summary>
        /// Cached name for the 'mesh_surface_update_vertex_region' method.
        /// </summary>
        public static readonly StringName MeshSurfaceUpdateVertexRegion = "mesh_surface_update_vertex_region";
        /// <summary>
        /// Cached name for the 'mesh_surface_update_attribute_region' method.
        /// </summary>
        public static readonly StringName MeshSurfaceUpdateAttributeRegion = "mesh_surface_update_attribute_region";
        /// <summary>
        /// Cached name for the 'mesh_surface_update_skin_region' method.
        /// </summary>
        public static readonly StringName MeshSurfaceUpdateSkinRegion = "mesh_surface_update_skin_region";
        /// <summary>
        /// Cached name for the 'mesh_surface_update_index_region' method.
        /// </summary>
        public static readonly StringName MeshSurfaceUpdateIndexRegion = "mesh_surface_update_index_region";
        /// <summary>
        /// Cached name for the 'mesh_set_shadow_mesh' method.
        /// </summary>
        public static readonly StringName MeshSetShadowMesh = "mesh_set_shadow_mesh";
        /// <summary>
        /// Cached name for the 'multimesh_create' method.
        /// </summary>
        public static readonly StringName MultimeshCreate = "multimesh_create";
        /// <summary>
        /// Cached name for the 'multimesh_allocate_data' method.
        /// </summary>
        public static readonly StringName MultimeshAllocateData = "multimesh_allocate_data";
        /// <summary>
        /// Cached name for the 'multimesh_get_instance_count' method.
        /// </summary>
        public static readonly StringName MultimeshGetInstanceCount = "multimesh_get_instance_count";
        /// <summary>
        /// Cached name for the 'multimesh_set_mesh' method.
        /// </summary>
        public static readonly StringName MultimeshSetMesh = "multimesh_set_mesh";
        /// <summary>
        /// Cached name for the 'multimesh_instance_set_transform' method.
        /// </summary>
        public static readonly StringName MultimeshInstanceSetTransform = "multimesh_instance_set_transform";
        /// <summary>
        /// Cached name for the 'multimesh_instance_set_transform_2d' method.
        /// </summary>
        public static readonly StringName MultimeshInstanceSetTransform2D = "multimesh_instance_set_transform_2d";
        /// <summary>
        /// Cached name for the 'multimesh_instance_set_color' method.
        /// </summary>
        public static readonly StringName MultimeshInstanceSetColor = "multimesh_instance_set_color";
        /// <summary>
        /// Cached name for the 'multimesh_instance_set_custom_data' method.
        /// </summary>
        public static readonly StringName MultimeshInstanceSetCustomData = "multimesh_instance_set_custom_data";
        /// <summary>
        /// Cached name for the 'multimesh_get_mesh' method.
        /// </summary>
        public static readonly StringName MultimeshGetMesh = "multimesh_get_mesh";
        /// <summary>
        /// Cached name for the 'multimesh_get_aabb' method.
        /// </summary>
        public static readonly StringName MultimeshGetAabb = "multimesh_get_aabb";
        /// <summary>
        /// Cached name for the 'multimesh_set_custom_aabb' method.
        /// </summary>
        public static readonly StringName MultimeshSetCustomAabb = "multimesh_set_custom_aabb";
        /// <summary>
        /// Cached name for the 'multimesh_get_custom_aabb' method.
        /// </summary>
        public static readonly StringName MultimeshGetCustomAabb = "multimesh_get_custom_aabb";
        /// <summary>
        /// Cached name for the 'multimesh_instance_get_transform' method.
        /// </summary>
        public static readonly StringName MultimeshInstanceGetTransform = "multimesh_instance_get_transform";
        /// <summary>
        /// Cached name for the 'multimesh_instance_get_transform_2d' method.
        /// </summary>
        public static readonly StringName MultimeshInstanceGetTransform2D = "multimesh_instance_get_transform_2d";
        /// <summary>
        /// Cached name for the 'multimesh_instance_get_color' method.
        /// </summary>
        public static readonly StringName MultimeshInstanceGetColor = "multimesh_instance_get_color";
        /// <summary>
        /// Cached name for the 'multimesh_instance_get_custom_data' method.
        /// </summary>
        public static readonly StringName MultimeshInstanceGetCustomData = "multimesh_instance_get_custom_data";
        /// <summary>
        /// Cached name for the 'multimesh_set_visible_instances' method.
        /// </summary>
        public static readonly StringName MultimeshSetVisibleInstances = "multimesh_set_visible_instances";
        /// <summary>
        /// Cached name for the 'multimesh_get_visible_instances' method.
        /// </summary>
        public static readonly StringName MultimeshGetVisibleInstances = "multimesh_get_visible_instances";
        /// <summary>
        /// Cached name for the 'multimesh_set_buffer' method.
        /// </summary>
        public static readonly StringName MultimeshSetBuffer = "multimesh_set_buffer";
        /// <summary>
        /// Cached name for the 'multimesh_get_command_buffer_rd_rid' method.
        /// </summary>
        public static readonly StringName MultimeshGetCommandBufferRdRid = "multimesh_get_command_buffer_rd_rid";
        /// <summary>
        /// Cached name for the 'multimesh_get_buffer_rd_rid' method.
        /// </summary>
        public static readonly StringName MultimeshGetBufferRdRid = "multimesh_get_buffer_rd_rid";
        /// <summary>
        /// Cached name for the 'multimesh_get_buffer' method.
        /// </summary>
        public static readonly StringName MultimeshGetBuffer = "multimesh_get_buffer";
        /// <summary>
        /// Cached name for the 'multimesh_set_buffer_interpolated' method.
        /// </summary>
        public static readonly StringName MultimeshSetBufferInterpolated = "multimesh_set_buffer_interpolated";
        /// <summary>
        /// Cached name for the 'multimesh_set_physics_interpolated' method.
        /// </summary>
        public static readonly StringName MultimeshSetPhysicsInterpolated = "multimesh_set_physics_interpolated";
        /// <summary>
        /// Cached name for the 'multimesh_set_physics_interpolation_quality' method.
        /// </summary>
        public static readonly StringName MultimeshSetPhysicsInterpolationQuality = "multimesh_set_physics_interpolation_quality";
        /// <summary>
        /// Cached name for the 'multimesh_instance_reset_physics_interpolation' method.
        /// </summary>
        public static readonly StringName MultimeshInstanceResetPhysicsInterpolation = "multimesh_instance_reset_physics_interpolation";
        /// <summary>
        /// Cached name for the 'multimesh_instances_reset_physics_interpolation' method.
        /// </summary>
        public static readonly StringName MultimeshInstancesResetPhysicsInterpolation = "multimesh_instances_reset_physics_interpolation";
        /// <summary>
        /// Cached name for the 'skeleton_create' method.
        /// </summary>
        public static readonly StringName SkeletonCreate = "skeleton_create";
        /// <summary>
        /// Cached name for the 'skeleton_allocate_data' method.
        /// </summary>
        public static readonly StringName SkeletonAllocateData = "skeleton_allocate_data";
        /// <summary>
        /// Cached name for the 'skeleton_get_bone_count' method.
        /// </summary>
        public static readonly StringName SkeletonGetBoneCount = "skeleton_get_bone_count";
        /// <summary>
        /// Cached name for the 'skeleton_bone_set_transform' method.
        /// </summary>
        public static readonly StringName SkeletonBoneSetTransform = "skeleton_bone_set_transform";
        /// <summary>
        /// Cached name for the 'skeleton_bone_get_transform' method.
        /// </summary>
        public static readonly StringName SkeletonBoneGetTransform = "skeleton_bone_get_transform";
        /// <summary>
        /// Cached name for the 'skeleton_bone_set_transform_2d' method.
        /// </summary>
        public static readonly StringName SkeletonBoneSetTransform2D = "skeleton_bone_set_transform_2d";
        /// <summary>
        /// Cached name for the 'skeleton_bone_get_transform_2d' method.
        /// </summary>
        public static readonly StringName SkeletonBoneGetTransform2D = "skeleton_bone_get_transform_2d";
        /// <summary>
        /// Cached name for the 'skeleton_set_base_transform_2d' method.
        /// </summary>
        public static readonly StringName SkeletonSetBaseTransform2D = "skeleton_set_base_transform_2d";
        /// <summary>
        /// Cached name for the 'directional_light_create' method.
        /// </summary>
        public static readonly StringName DirectionalLightCreate = "directional_light_create";
        /// <summary>
        /// Cached name for the 'omni_light_create' method.
        /// </summary>
        public static readonly StringName OmniLightCreate = "omni_light_create";
        /// <summary>
        /// Cached name for the 'spot_light_create' method.
        /// </summary>
        public static readonly StringName SpotLightCreate = "spot_light_create";
        /// <summary>
        /// Cached name for the 'light_set_color' method.
        /// </summary>
        public static readonly StringName LightSetColor = "light_set_color";
        /// <summary>
        /// Cached name for the 'light_set_param' method.
        /// </summary>
        public static readonly StringName LightSetParam = "light_set_param";
        /// <summary>
        /// Cached name for the 'light_set_shadow' method.
        /// </summary>
        public static readonly StringName LightSetShadow = "light_set_shadow";
        /// <summary>
        /// Cached name for the 'light_set_projector' method.
        /// </summary>
        public static readonly StringName LightSetProjector = "light_set_projector";
        /// <summary>
        /// Cached name for the 'light_set_negative' method.
        /// </summary>
        public static readonly StringName LightSetNegative = "light_set_negative";
        /// <summary>
        /// Cached name for the 'light_set_cull_mask' method.
        /// </summary>
        public static readonly StringName LightSetCullMask = "light_set_cull_mask";
        /// <summary>
        /// Cached name for the 'light_set_distance_fade' method.
        /// </summary>
        public static readonly StringName LightSetDistanceFade = "light_set_distance_fade";
        /// <summary>
        /// Cached name for the 'light_set_reverse_cull_face_mode' method.
        /// </summary>
        public static readonly StringName LightSetReverseCullFaceMode = "light_set_reverse_cull_face_mode";
        /// <summary>
        /// Cached name for the 'light_set_shadow_caster_mask' method.
        /// </summary>
        public static readonly StringName LightSetShadowCasterMask = "light_set_shadow_caster_mask";
        /// <summary>
        /// Cached name for the 'light_set_bake_mode' method.
        /// </summary>
        public static readonly StringName LightSetBakeMode = "light_set_bake_mode";
        /// <summary>
        /// Cached name for the 'light_set_max_sdfgi_cascade' method.
        /// </summary>
        public static readonly StringName LightSetMaxSdfgiCascade = "light_set_max_sdfgi_cascade";
        /// <summary>
        /// Cached name for the 'light_omni_set_shadow_mode' method.
        /// </summary>
        public static readonly StringName LightOmniSetShadowMode = "light_omni_set_shadow_mode";
        /// <summary>
        /// Cached name for the 'light_directional_set_shadow_mode' method.
        /// </summary>
        public static readonly StringName LightDirectionalSetShadowMode = "light_directional_set_shadow_mode";
        /// <summary>
        /// Cached name for the 'light_directional_set_blend_splits' method.
        /// </summary>
        public static readonly StringName LightDirectionalSetBlendSplits = "light_directional_set_blend_splits";
        /// <summary>
        /// Cached name for the 'light_directional_set_sky_mode' method.
        /// </summary>
        public static readonly StringName LightDirectionalSetSkyMode = "light_directional_set_sky_mode";
        /// <summary>
        /// Cached name for the 'light_projectors_set_filter' method.
        /// </summary>
        public static readonly StringName LightProjectorsSetFilter = "light_projectors_set_filter";
        /// <summary>
        /// Cached name for the 'lightmaps_set_bicubic_filter' method.
        /// </summary>
        public static readonly StringName LightmapsSetBicubicFilter = "lightmaps_set_bicubic_filter";
        /// <summary>
        /// Cached name for the 'positional_soft_shadow_filter_set_quality' method.
        /// </summary>
        public static readonly StringName PositionalSoftShadowFilterSetQuality = "positional_soft_shadow_filter_set_quality";
        /// <summary>
        /// Cached name for the 'directional_soft_shadow_filter_set_quality' method.
        /// </summary>
        public static readonly StringName DirectionalSoftShadowFilterSetQuality = "directional_soft_shadow_filter_set_quality";
        /// <summary>
        /// Cached name for the 'directional_shadow_atlas_set_size' method.
        /// </summary>
        public static readonly StringName DirectionalShadowAtlasSetSize = "directional_shadow_atlas_set_size";
        /// <summary>
        /// Cached name for the 'reflection_probe_create' method.
        /// </summary>
        public static readonly StringName ReflectionProbeCreate = "reflection_probe_create";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_update_mode' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetUpdateMode = "reflection_probe_set_update_mode";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_intensity' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetIntensity = "reflection_probe_set_intensity";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_blend_distance' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetBlendDistance = "reflection_probe_set_blend_distance";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_ambient_mode' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetAmbientMode = "reflection_probe_set_ambient_mode";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_ambient_color' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetAmbientColor = "reflection_probe_set_ambient_color";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_ambient_energy' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetAmbientEnergy = "reflection_probe_set_ambient_energy";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_max_distance' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetMaxDistance = "reflection_probe_set_max_distance";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_size' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetSize = "reflection_probe_set_size";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_origin_offset' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetOriginOffset = "reflection_probe_set_origin_offset";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_as_interior' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetAsInterior = "reflection_probe_set_as_interior";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_enable_box_projection' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetEnableBoxProjection = "reflection_probe_set_enable_box_projection";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_enable_shadows' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetEnableShadows = "reflection_probe_set_enable_shadows";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_cull_mask' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetCullMask = "reflection_probe_set_cull_mask";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_reflection_mask' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetReflectionMask = "reflection_probe_set_reflection_mask";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_resolution' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetResolution = "reflection_probe_set_resolution";
        /// <summary>
        /// Cached name for the 'reflection_probe_set_mesh_lod_threshold' method.
        /// </summary>
        public static readonly StringName ReflectionProbeSetMeshLodThreshold = "reflection_probe_set_mesh_lod_threshold";
        /// <summary>
        /// Cached name for the 'decal_create' method.
        /// </summary>
        public static readonly StringName DecalCreate = "decal_create";
        /// <summary>
        /// Cached name for the 'decal_set_size' method.
        /// </summary>
        public static readonly StringName DecalSetSize = "decal_set_size";
        /// <summary>
        /// Cached name for the 'decal_set_texture' method.
        /// </summary>
        public static readonly StringName DecalSetTexture = "decal_set_texture";
        /// <summary>
        /// Cached name for the 'decal_set_emission_energy' method.
        /// </summary>
        public static readonly StringName DecalSetEmissionEnergy = "decal_set_emission_energy";
        /// <summary>
        /// Cached name for the 'decal_set_albedo_mix' method.
        /// </summary>
        public static readonly StringName DecalSetAlbedoMix = "decal_set_albedo_mix";
        /// <summary>
        /// Cached name for the 'decal_set_modulate' method.
        /// </summary>
        public static readonly StringName DecalSetModulate = "decal_set_modulate";
        /// <summary>
        /// Cached name for the 'decal_set_cull_mask' method.
        /// </summary>
        public static readonly StringName DecalSetCullMask = "decal_set_cull_mask";
        /// <summary>
        /// Cached name for the 'decal_set_distance_fade' method.
        /// </summary>
        public static readonly StringName DecalSetDistanceFade = "decal_set_distance_fade";
        /// <summary>
        /// Cached name for the 'decal_set_fade' method.
        /// </summary>
        public static readonly StringName DecalSetFade = "decal_set_fade";
        /// <summary>
        /// Cached name for the 'decal_set_normal_fade' method.
        /// </summary>
        public static readonly StringName DecalSetNormalFade = "decal_set_normal_fade";
        /// <summary>
        /// Cached name for the 'decals_set_filter' method.
        /// </summary>
        public static readonly StringName DecalsSetFilter = "decals_set_filter";
        /// <summary>
        /// Cached name for the 'gi_set_use_half_resolution' method.
        /// </summary>
        public static readonly StringName GISetUseHalfResolution = "gi_set_use_half_resolution";
        /// <summary>
        /// Cached name for the 'voxel_gi_create' method.
        /// </summary>
        public static readonly StringName VoxelGICreate = "voxel_gi_create";
        /// <summary>
        /// Cached name for the 'voxel_gi_allocate_data' method.
        /// </summary>
        public static readonly StringName VoxelGIAllocateData = "voxel_gi_allocate_data";
        /// <summary>
        /// Cached name for the 'voxel_gi_get_octree_size' method.
        /// </summary>
        public static readonly StringName VoxelGIGetOctreeSize = "voxel_gi_get_octree_size";
        /// <summary>
        /// Cached name for the 'voxel_gi_get_octree_cells' method.
        /// </summary>
        public static readonly StringName VoxelGIGetOctreeCells = "voxel_gi_get_octree_cells";
        /// <summary>
        /// Cached name for the 'voxel_gi_get_data_cells' method.
        /// </summary>
        public static readonly StringName VoxelGIGetDataCells = "voxel_gi_get_data_cells";
        /// <summary>
        /// Cached name for the 'voxel_gi_get_distance_field' method.
        /// </summary>
        public static readonly StringName VoxelGIGetDistanceField = "voxel_gi_get_distance_field";
        /// <summary>
        /// Cached name for the 'voxel_gi_get_level_counts' method.
        /// </summary>
        public static readonly StringName VoxelGIGetLevelCounts = "voxel_gi_get_level_counts";
        /// <summary>
        /// Cached name for the 'voxel_gi_get_to_cell_xform' method.
        /// </summary>
        public static readonly StringName VoxelGIGetToCellXform = "voxel_gi_get_to_cell_xform";
        /// <summary>
        /// Cached name for the 'voxel_gi_set_dynamic_range' method.
        /// </summary>
        public static readonly StringName VoxelGISetDynamicRange = "voxel_gi_set_dynamic_range";
        /// <summary>
        /// Cached name for the 'voxel_gi_set_propagation' method.
        /// </summary>
        public static readonly StringName VoxelGISetPropagation = "voxel_gi_set_propagation";
        /// <summary>
        /// Cached name for the 'voxel_gi_set_energy' method.
        /// </summary>
        public static readonly StringName VoxelGISetEnergy = "voxel_gi_set_energy";
        /// <summary>
        /// Cached name for the 'voxel_gi_set_baked_exposure_normalization' method.
        /// </summary>
        public static readonly StringName VoxelGISetBakedExposureNormalization = "voxel_gi_set_baked_exposure_normalization";
        /// <summary>
        /// Cached name for the 'voxel_gi_set_bias' method.
        /// </summary>
        public static readonly StringName VoxelGISetBias = "voxel_gi_set_bias";
        /// <summary>
        /// Cached name for the 'voxel_gi_set_normal_bias' method.
        /// </summary>
        public static readonly StringName VoxelGISetNormalBias = "voxel_gi_set_normal_bias";
        /// <summary>
        /// Cached name for the 'voxel_gi_set_interior' method.
        /// </summary>
        public static readonly StringName VoxelGISetInterior = "voxel_gi_set_interior";
        /// <summary>
        /// Cached name for the 'voxel_gi_set_use_two_bounces' method.
        /// </summary>
        public static readonly StringName VoxelGISetUseTwoBounces = "voxel_gi_set_use_two_bounces";
        /// <summary>
        /// Cached name for the 'voxel_gi_set_quality' method.
        /// </summary>
        public static readonly StringName VoxelGISetQuality = "voxel_gi_set_quality";
        /// <summary>
        /// Cached name for the 'lightmap_create' method.
        /// </summary>
        public static readonly StringName LightmapCreate = "lightmap_create";
        /// <summary>
        /// Cached name for the 'lightmap_set_textures' method.
        /// </summary>
        public static readonly StringName LightmapSetTextures = "lightmap_set_textures";
        /// <summary>
        /// Cached name for the 'lightmap_set_probe_bounds' method.
        /// </summary>
        public static readonly StringName LightmapSetProbeBounds = "lightmap_set_probe_bounds";
        /// <summary>
        /// Cached name for the 'lightmap_set_probe_interior' method.
        /// </summary>
        public static readonly StringName LightmapSetProbeInterior = "lightmap_set_probe_interior";
        /// <summary>
        /// Cached name for the 'lightmap_set_probe_capture_data' method.
        /// </summary>
        public static readonly StringName LightmapSetProbeCaptureData = "lightmap_set_probe_capture_data";
        /// <summary>
        /// Cached name for the 'lightmap_get_probe_capture_points' method.
        /// </summary>
        public static readonly StringName LightmapGetProbeCapturePoints = "lightmap_get_probe_capture_points";
        /// <summary>
        /// Cached name for the 'lightmap_get_probe_capture_sh' method.
        /// </summary>
        public static readonly StringName LightmapGetProbeCaptureSh = "lightmap_get_probe_capture_sh";
        /// <summary>
        /// Cached name for the 'lightmap_get_probe_capture_tetrahedra' method.
        /// </summary>
        public static readonly StringName LightmapGetProbeCaptureTetrahedra = "lightmap_get_probe_capture_tetrahedra";
        /// <summary>
        /// Cached name for the 'lightmap_get_probe_capture_bsp_tree' method.
        /// </summary>
        public static readonly StringName LightmapGetProbeCaptureBspTree = "lightmap_get_probe_capture_bsp_tree";
        /// <summary>
        /// Cached name for the 'lightmap_set_baked_exposure_normalization' method.
        /// </summary>
        public static readonly StringName LightmapSetBakedExposureNormalization = "lightmap_set_baked_exposure_normalization";
        /// <summary>
        /// Cached name for the 'lightmap_set_probe_capture_update_speed' method.
        /// </summary>
        public static readonly StringName LightmapSetProbeCaptureUpdateSpeed = "lightmap_set_probe_capture_update_speed";
        /// <summary>
        /// Cached name for the 'particles_create' method.
        /// </summary>
        public static readonly StringName ParticlesCreate = "particles_create";
        /// <summary>
        /// Cached name for the 'particles_set_mode' method.
        /// </summary>
        public static readonly StringName ParticlesSetMode = "particles_set_mode";
        /// <summary>
        /// Cached name for the 'particles_set_emitting' method.
        /// </summary>
        public static readonly StringName ParticlesSetEmitting = "particles_set_emitting";
        /// <summary>
        /// Cached name for the 'particles_get_emitting' method.
        /// </summary>
        public static readonly StringName ParticlesGetEmitting = "particles_get_emitting";
        /// <summary>
        /// Cached name for the 'particles_set_amount' method.
        /// </summary>
        public static readonly StringName ParticlesSetAmount = "particles_set_amount";
        /// <summary>
        /// Cached name for the 'particles_set_amount_ratio' method.
        /// </summary>
        public static readonly StringName ParticlesSetAmountRatio = "particles_set_amount_ratio";
        /// <summary>
        /// Cached name for the 'particles_set_lifetime' method.
        /// </summary>
        public static readonly StringName ParticlesSetLifetime = "particles_set_lifetime";
        /// <summary>
        /// Cached name for the 'particles_set_one_shot' method.
        /// </summary>
        public static readonly StringName ParticlesSetOneShot = "particles_set_one_shot";
        /// <summary>
        /// Cached name for the 'particles_set_pre_process_time' method.
        /// </summary>
        public static readonly StringName ParticlesSetPreProcessTime = "particles_set_pre_process_time";
        /// <summary>
        /// Cached name for the 'particles_request_process_time' method.
        /// </summary>
        public static readonly StringName ParticlesRequestProcessTime = "particles_request_process_time";
        /// <summary>
        /// Cached name for the 'particles_set_explosiveness_ratio' method.
        /// </summary>
        public static readonly StringName ParticlesSetExplosivenessRatio = "particles_set_explosiveness_ratio";
        /// <summary>
        /// Cached name for the 'particles_set_randomness_ratio' method.
        /// </summary>
        public static readonly StringName ParticlesSetRandomnessRatio = "particles_set_randomness_ratio";
        /// <summary>
        /// Cached name for the 'particles_set_interp_to_end' method.
        /// </summary>
        public static readonly StringName ParticlesSetInterpToEnd = "particles_set_interp_to_end";
        /// <summary>
        /// Cached name for the 'particles_set_emitter_velocity' method.
        /// </summary>
        public static readonly StringName ParticlesSetEmitterVelocity = "particles_set_emitter_velocity";
        /// <summary>
        /// Cached name for the 'particles_set_custom_aabb' method.
        /// </summary>
        public static readonly StringName ParticlesSetCustomAabb = "particles_set_custom_aabb";
        /// <summary>
        /// Cached name for the 'particles_set_speed_scale' method.
        /// </summary>
        public static readonly StringName ParticlesSetSpeedScale = "particles_set_speed_scale";
        /// <summary>
        /// Cached name for the 'particles_set_use_local_coordinates' method.
        /// </summary>
        public static readonly StringName ParticlesSetUseLocalCoordinates = "particles_set_use_local_coordinates";
        /// <summary>
        /// Cached name for the 'particles_set_process_material' method.
        /// </summary>
        public static readonly StringName ParticlesSetProcessMaterial = "particles_set_process_material";
        /// <summary>
        /// Cached name for the 'particles_set_fixed_fps' method.
        /// </summary>
        public static readonly StringName ParticlesSetFixedFps = "particles_set_fixed_fps";
        /// <summary>
        /// Cached name for the 'particles_set_interpolate' method.
        /// </summary>
        public static readonly StringName ParticlesSetInterpolate = "particles_set_interpolate";
        /// <summary>
        /// Cached name for the 'particles_set_fractional_delta' method.
        /// </summary>
        public static readonly StringName ParticlesSetFractionalDelta = "particles_set_fractional_delta";
        /// <summary>
        /// Cached name for the 'particles_set_collision_base_size' method.
        /// </summary>
        public static readonly StringName ParticlesSetCollisionBaseSize = "particles_set_collision_base_size";
        /// <summary>
        /// Cached name for the 'particles_set_transform_align' method.
        /// </summary>
        public static readonly StringName ParticlesSetTransformAlign = "particles_set_transform_align";
        /// <summary>
        /// Cached name for the 'particles_set_trails' method.
        /// </summary>
        public static readonly StringName ParticlesSetTrails = "particles_set_trails";
        /// <summary>
        /// Cached name for the 'particles_set_trail_bind_poses' method.
        /// </summary>
        public static readonly StringName ParticlesSetTrailBindPoses = "particles_set_trail_bind_poses";
        /// <summary>
        /// Cached name for the 'particles_is_inactive' method.
        /// </summary>
        public static readonly StringName ParticlesIsInactive = "particles_is_inactive";
        /// <summary>
        /// Cached name for the 'particles_request_process' method.
        /// </summary>
        public static readonly StringName ParticlesRequestProcess = "particles_request_process";
        /// <summary>
        /// Cached name for the 'particles_restart' method.
        /// </summary>
        public static readonly StringName ParticlesRestart = "particles_restart";
        /// <summary>
        /// Cached name for the 'particles_set_subemitter' method.
        /// </summary>
        public static readonly StringName ParticlesSetSubemitter = "particles_set_subemitter";
        /// <summary>
        /// Cached name for the 'particles_emit' method.
        /// </summary>
        public static readonly StringName ParticlesEmit = "particles_emit";
        /// <summary>
        /// Cached name for the 'particles_set_draw_order' method.
        /// </summary>
        public static readonly StringName ParticlesSetDrawOrder = "particles_set_draw_order";
        /// <summary>
        /// Cached name for the 'particles_set_draw_passes' method.
        /// </summary>
        public static readonly StringName ParticlesSetDrawPasses = "particles_set_draw_passes";
        /// <summary>
        /// Cached name for the 'particles_set_draw_pass_mesh' method.
        /// </summary>
        public static readonly StringName ParticlesSetDrawPassMesh = "particles_set_draw_pass_mesh";
        /// <summary>
        /// Cached name for the 'particles_get_current_aabb' method.
        /// </summary>
        public static readonly StringName ParticlesGetCurrentAabb = "particles_get_current_aabb";
        /// <summary>
        /// Cached name for the 'particles_set_emission_transform' method.
        /// </summary>
        public static readonly StringName ParticlesSetEmissionTransform = "particles_set_emission_transform";
        /// <summary>
        /// Cached name for the 'particles_collision_create' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionCreate = "particles_collision_create";
        /// <summary>
        /// Cached name for the 'particles_collision_set_collision_type' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionSetCollisionType = "particles_collision_set_collision_type";
        /// <summary>
        /// Cached name for the 'particles_collision_set_cull_mask' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionSetCullMask = "particles_collision_set_cull_mask";
        /// <summary>
        /// Cached name for the 'particles_collision_set_sphere_radius' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionSetSphereRadius = "particles_collision_set_sphere_radius";
        /// <summary>
        /// Cached name for the 'particles_collision_set_box_extents' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionSetBoxExtents = "particles_collision_set_box_extents";
        /// <summary>
        /// Cached name for the 'particles_collision_set_attractor_strength' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionSetAttractorStrength = "particles_collision_set_attractor_strength";
        /// <summary>
        /// Cached name for the 'particles_collision_set_attractor_directionality' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionSetAttractorDirectionality = "particles_collision_set_attractor_directionality";
        /// <summary>
        /// Cached name for the 'particles_collision_set_attractor_attenuation' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionSetAttractorAttenuation = "particles_collision_set_attractor_attenuation";
        /// <summary>
        /// Cached name for the 'particles_collision_set_field_texture' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionSetFieldTexture = "particles_collision_set_field_texture";
        /// <summary>
        /// Cached name for the 'particles_collision_height_field_update' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionHeightFieldUpdate = "particles_collision_height_field_update";
        /// <summary>
        /// Cached name for the 'particles_collision_set_height_field_resolution' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionSetHeightFieldResolution = "particles_collision_set_height_field_resolution";
        /// <summary>
        /// Cached name for the 'particles_collision_set_height_field_mask' method.
        /// </summary>
        public static readonly StringName ParticlesCollisionSetHeightFieldMask = "particles_collision_set_height_field_mask";
        /// <summary>
        /// Cached name for the 'fog_volume_create' method.
        /// </summary>
        public static readonly StringName FogVolumeCreate = "fog_volume_create";
        /// <summary>
        /// Cached name for the 'fog_volume_set_shape' method.
        /// </summary>
        public static readonly StringName FogVolumeSetShape = "fog_volume_set_shape";
        /// <summary>
        /// Cached name for the 'fog_volume_set_size' method.
        /// </summary>
        public static readonly StringName FogVolumeSetSize = "fog_volume_set_size";
        /// <summary>
        /// Cached name for the 'fog_volume_set_material' method.
        /// </summary>
        public static readonly StringName FogVolumeSetMaterial = "fog_volume_set_material";
        /// <summary>
        /// Cached name for the 'visibility_notifier_create' method.
        /// </summary>
        public static readonly StringName VisibilityNotifierCreate = "visibility_notifier_create";
        /// <summary>
        /// Cached name for the 'visibility_notifier_set_aabb' method.
        /// </summary>
        public static readonly StringName VisibilityNotifierSetAabb = "visibility_notifier_set_aabb";
        /// <summary>
        /// Cached name for the 'visibility_notifier_set_callbacks' method.
        /// </summary>
        public static readonly StringName VisibilityNotifierSetCallbacks = "visibility_notifier_set_callbacks";
        /// <summary>
        /// Cached name for the 'occluder_create' method.
        /// </summary>
        public static readonly StringName OccluderCreate = "occluder_create";
        /// <summary>
        /// Cached name for the 'occluder_set_mesh' method.
        /// </summary>
        public static readonly StringName OccluderSetMesh = "occluder_set_mesh";
        /// <summary>
        /// Cached name for the 'camera_create' method.
        /// </summary>
        public static readonly StringName CameraCreate = "camera_create";
        /// <summary>
        /// Cached name for the 'camera_set_perspective' method.
        /// </summary>
        public static readonly StringName CameraSetPerspective = "camera_set_perspective";
        /// <summary>
        /// Cached name for the 'camera_set_orthogonal' method.
        /// </summary>
        public static readonly StringName CameraSetOrthogonal = "camera_set_orthogonal";
        /// <summary>
        /// Cached name for the 'camera_set_frustum' method.
        /// </summary>
        public static readonly StringName CameraSetFrustum = "camera_set_frustum";
        /// <summary>
        /// Cached name for the 'camera_set_transform' method.
        /// </summary>
        public static readonly StringName CameraSetTransform = "camera_set_transform";
        /// <summary>
        /// Cached name for the 'camera_set_cull_mask' method.
        /// </summary>
        public static readonly StringName CameraSetCullMask = "camera_set_cull_mask";
        /// <summary>
        /// Cached name for the 'camera_set_environment' method.
        /// </summary>
        public static readonly StringName CameraSetEnvironment = "camera_set_environment";
        /// <summary>
        /// Cached name for the 'camera_set_camera_attributes' method.
        /// </summary>
        public static readonly StringName CameraSetCameraAttributes = "camera_set_camera_attributes";
        /// <summary>
        /// Cached name for the 'camera_set_compositor' method.
        /// </summary>
        public static readonly StringName CameraSetCompositor = "camera_set_compositor";
        /// <summary>
        /// Cached name for the 'camera_set_use_vertical_aspect' method.
        /// </summary>
        public static readonly StringName CameraSetUseVerticalAspect = "camera_set_use_vertical_aspect";
        /// <summary>
        /// Cached name for the 'viewport_create' method.
        /// </summary>
        public static readonly StringName ViewportCreate = "viewport_create";
        /// <summary>
        /// Cached name for the 'viewport_set_use_xr' method.
        /// </summary>
        public static readonly StringName ViewportSetUseXR = "viewport_set_use_xr";
        /// <summary>
        /// Cached name for the 'viewport_set_size' method.
        /// </summary>
        public static readonly StringName ViewportSetSize = "viewport_set_size";
        /// <summary>
        /// Cached name for the 'viewport_set_active' method.
        /// </summary>
        public static readonly StringName ViewportSetActive = "viewport_set_active";
        /// <summary>
        /// Cached name for the 'viewport_set_parent_viewport' method.
        /// </summary>
        public static readonly StringName ViewportSetParentViewport = "viewport_set_parent_viewport";
        /// <summary>
        /// Cached name for the 'viewport_attach_to_screen' method.
        /// </summary>
        public static readonly StringName ViewportAttachToScreen = "viewport_attach_to_screen";
        /// <summary>
        /// Cached name for the 'viewport_set_render_direct_to_screen' method.
        /// </summary>
        public static readonly StringName ViewportSetRenderDirectToScreen = "viewport_set_render_direct_to_screen";
        /// <summary>
        /// Cached name for the 'viewport_set_canvas_cull_mask' method.
        /// </summary>
        public static readonly StringName ViewportSetCanvasCullMask = "viewport_set_canvas_cull_mask";
        /// <summary>
        /// Cached name for the 'viewport_set_scaling_3d_mode' method.
        /// </summary>
        public static readonly StringName ViewportSetScaling3DMode = "viewport_set_scaling_3d_mode";
        /// <summary>
        /// Cached name for the 'viewport_set_scaling_3d_scale' method.
        /// </summary>
        public static readonly StringName ViewportSetScaling3DScale = "viewport_set_scaling_3d_scale";
        /// <summary>
        /// Cached name for the 'viewport_set_fsr_sharpness' method.
        /// </summary>
        public static readonly StringName ViewportSetFsrSharpness = "viewport_set_fsr_sharpness";
        /// <summary>
        /// Cached name for the 'viewport_set_texture_mipmap_bias' method.
        /// </summary>
        public static readonly StringName ViewportSetTextureMipmapBias = "viewport_set_texture_mipmap_bias";
        /// <summary>
        /// Cached name for the 'viewport_set_anisotropic_filtering_level' method.
        /// </summary>
        public static readonly StringName ViewportSetAnisotropicFilteringLevel = "viewport_set_anisotropic_filtering_level";
        /// <summary>
        /// Cached name for the 'viewport_set_update_mode' method.
        /// </summary>
        public static readonly StringName ViewportSetUpdateMode = "viewport_set_update_mode";
        /// <summary>
        /// Cached name for the 'viewport_get_update_mode' method.
        /// </summary>
        public static readonly StringName ViewportGetUpdateMode = "viewport_get_update_mode";
        /// <summary>
        /// Cached name for the 'viewport_set_clear_mode' method.
        /// </summary>
        public static readonly StringName ViewportSetClearMode = "viewport_set_clear_mode";
        /// <summary>
        /// Cached name for the 'viewport_get_render_target' method.
        /// </summary>
        public static readonly StringName ViewportGetRenderTarget = "viewport_get_render_target";
        /// <summary>
        /// Cached name for the 'viewport_get_texture' method.
        /// </summary>
        public static readonly StringName ViewportGetTexture = "viewport_get_texture";
        /// <summary>
        /// Cached name for the 'viewport_set_disable_3d' method.
        /// </summary>
        public static readonly StringName ViewportSetDisable3D = "viewport_set_disable_3d";
        /// <summary>
        /// Cached name for the 'viewport_set_disable_2d' method.
        /// </summary>
        public static readonly StringName ViewportSetDisable2D = "viewport_set_disable_2d";
        /// <summary>
        /// Cached name for the 'viewport_set_environment_mode' method.
        /// </summary>
        public static readonly StringName ViewportSetEnvironmentMode = "viewport_set_environment_mode";
        /// <summary>
        /// Cached name for the 'viewport_attach_camera' method.
        /// </summary>
        public static readonly StringName ViewportAttachCamera = "viewport_attach_camera";
        /// <summary>
        /// Cached name for the 'viewport_set_scenario' method.
        /// </summary>
        public static readonly StringName ViewportSetScenario = "viewport_set_scenario";
        /// <summary>
        /// Cached name for the 'viewport_attach_canvas' method.
        /// </summary>
        public static readonly StringName ViewportAttachCanvas = "viewport_attach_canvas";
        /// <summary>
        /// Cached name for the 'viewport_remove_canvas' method.
        /// </summary>
        public static readonly StringName ViewportRemoveCanvas = "viewport_remove_canvas";
        /// <summary>
        /// Cached name for the 'viewport_set_snap_2d_transforms_to_pixel' method.
        /// </summary>
        public static readonly StringName ViewportSetSnap2DTransformsToPixel = "viewport_set_snap_2d_transforms_to_pixel";
        /// <summary>
        /// Cached name for the 'viewport_set_snap_2d_vertices_to_pixel' method.
        /// </summary>
        public static readonly StringName ViewportSetSnap2DVerticesToPixel = "viewport_set_snap_2d_vertices_to_pixel";
        /// <summary>
        /// Cached name for the 'viewport_set_default_canvas_item_texture_filter' method.
        /// </summary>
        public static readonly StringName ViewportSetDefaultCanvasItemTextureFilter = "viewport_set_default_canvas_item_texture_filter";
        /// <summary>
        /// Cached name for the 'viewport_set_default_canvas_item_texture_repeat' method.
        /// </summary>
        public static readonly StringName ViewportSetDefaultCanvasItemTextureRepeat = "viewport_set_default_canvas_item_texture_repeat";
        /// <summary>
        /// Cached name for the 'viewport_set_canvas_transform' method.
        /// </summary>
        public static readonly StringName ViewportSetCanvasTransform = "viewport_set_canvas_transform";
        /// <summary>
        /// Cached name for the 'viewport_set_canvas_stacking' method.
        /// </summary>
        public static readonly StringName ViewportSetCanvasStacking = "viewport_set_canvas_stacking";
        /// <summary>
        /// Cached name for the 'viewport_set_transparent_background' method.
        /// </summary>
        public static readonly StringName ViewportSetTransparentBackground = "viewport_set_transparent_background";
        /// <summary>
        /// Cached name for the 'viewport_set_global_canvas_transform' method.
        /// </summary>
        public static readonly StringName ViewportSetGlobalCanvasTransform = "viewport_set_global_canvas_transform";
        /// <summary>
        /// Cached name for the 'viewport_set_sdf_oversize_and_scale' method.
        /// </summary>
        public static readonly StringName ViewportSetSdfOversizeAndScale = "viewport_set_sdf_oversize_and_scale";
        /// <summary>
        /// Cached name for the 'viewport_set_positional_shadow_atlas_size' method.
        /// </summary>
        public static readonly StringName ViewportSetPositionalShadowAtlasSize = "viewport_set_positional_shadow_atlas_size";
        /// <summary>
        /// Cached name for the 'viewport_set_positional_shadow_atlas_quadrant_subdivision' method.
        /// </summary>
        public static readonly StringName ViewportSetPositionalShadowAtlasQuadrantSubdivision = "viewport_set_positional_shadow_atlas_quadrant_subdivision";
        /// <summary>
        /// Cached name for the 'viewport_set_msaa_3d' method.
        /// </summary>
        public static readonly StringName ViewportSetMsaa3D = "viewport_set_msaa_3d";
        /// <summary>
        /// Cached name for the 'viewport_set_msaa_2d' method.
        /// </summary>
        public static readonly StringName ViewportSetMsaa2D = "viewport_set_msaa_2d";
        /// <summary>
        /// Cached name for the 'viewport_set_use_hdr_2d' method.
        /// </summary>
        public static readonly StringName ViewportSetUseHdr2D = "viewport_set_use_hdr_2d";
        /// <summary>
        /// Cached name for the 'viewport_set_screen_space_aa' method.
        /// </summary>
        public static readonly StringName ViewportSetScreenSpaceAA = "viewport_set_screen_space_aa";
        /// <summary>
        /// Cached name for the 'viewport_set_use_taa' method.
        /// </summary>
        public static readonly StringName ViewportSetUseTaa = "viewport_set_use_taa";
        /// <summary>
        /// Cached name for the 'viewport_set_use_debanding' method.
        /// </summary>
        public static readonly StringName ViewportSetUseDebanding = "viewport_set_use_debanding";
        /// <summary>
        /// Cached name for the 'viewport_set_use_occlusion_culling' method.
        /// </summary>
        public static readonly StringName ViewportSetUseOcclusionCulling = "viewport_set_use_occlusion_culling";
        /// <summary>
        /// Cached name for the 'viewport_set_occlusion_rays_per_thread' method.
        /// </summary>
        public static readonly StringName ViewportSetOcclusionRaysPerThread = "viewport_set_occlusion_rays_per_thread";
        /// <summary>
        /// Cached name for the 'viewport_set_occlusion_culling_build_quality' method.
        /// </summary>
        public static readonly StringName ViewportSetOcclusionCullingBuildQuality = "viewport_set_occlusion_culling_build_quality";
        /// <summary>
        /// Cached name for the 'viewport_get_render_info' method.
        /// </summary>
        public static readonly StringName ViewportGetRenderInfo = "viewport_get_render_info";
        /// <summary>
        /// Cached name for the 'viewport_set_debug_draw' method.
        /// </summary>
        public static readonly StringName ViewportSetDebugDraw = "viewport_set_debug_draw";
        /// <summary>
        /// Cached name for the 'viewport_set_measure_render_time' method.
        /// </summary>
        public static readonly StringName ViewportSetMeasureRenderTime = "viewport_set_measure_render_time";
        /// <summary>
        /// Cached name for the 'viewport_get_measured_render_time_cpu' method.
        /// </summary>
        public static readonly StringName ViewportGetMeasuredRenderTimeCpu = "viewport_get_measured_render_time_cpu";
        /// <summary>
        /// Cached name for the 'viewport_get_measured_render_time_gpu' method.
        /// </summary>
        public static readonly StringName ViewportGetMeasuredRenderTimeGpu = "viewport_get_measured_render_time_gpu";
        /// <summary>
        /// Cached name for the 'viewport_set_vrs_mode' method.
        /// </summary>
        public static readonly StringName ViewportSetVrsMode = "viewport_set_vrs_mode";
        /// <summary>
        /// Cached name for the 'viewport_set_vrs_update_mode' method.
        /// </summary>
        public static readonly StringName ViewportSetVrsUpdateMode = "viewport_set_vrs_update_mode";
        /// <summary>
        /// Cached name for the 'viewport_set_vrs_texture' method.
        /// </summary>
        public static readonly StringName ViewportSetVrsTexture = "viewport_set_vrs_texture";
        /// <summary>
        /// Cached name for the 'sky_create' method.
        /// </summary>
        public static readonly StringName SkyCreate = "sky_create";
        /// <summary>
        /// Cached name for the 'sky_set_radiance_size' method.
        /// </summary>
        public static readonly StringName SkySetRadianceSize = "sky_set_radiance_size";
        /// <summary>
        /// Cached name for the 'sky_set_mode' method.
        /// </summary>
        public static readonly StringName SkySetMode = "sky_set_mode";
        /// <summary>
        /// Cached name for the 'sky_set_material' method.
        /// </summary>
        public static readonly StringName SkySetMaterial = "sky_set_material";
        /// <summary>
        /// Cached name for the 'sky_bake_panorama' method.
        /// </summary>
        public static readonly StringName SkyBakePanorama = "sky_bake_panorama";
        /// <summary>
        /// Cached name for the 'compositor_effect_create' method.
        /// </summary>
        public static readonly StringName CompositorEffectCreate = "compositor_effect_create";
        /// <summary>
        /// Cached name for the 'compositor_effect_set_enabled' method.
        /// </summary>
        public static readonly StringName CompositorEffectSetEnabled = "compositor_effect_set_enabled";
        /// <summary>
        /// Cached name for the 'compositor_effect_set_callback' method.
        /// </summary>
        public static readonly StringName CompositorEffectSetCallback = "compositor_effect_set_callback";
        /// <summary>
        /// Cached name for the 'compositor_effect_set_flag' method.
        /// </summary>
        public static readonly StringName CompositorEffectSetFlag = "compositor_effect_set_flag";
        /// <summary>
        /// Cached name for the 'compositor_create' method.
        /// </summary>
        public static readonly StringName CompositorCreate = "compositor_create";
        /// <summary>
        /// Cached name for the 'compositor_set_compositor_effects' method.
        /// </summary>
        public static readonly StringName CompositorSetCompositorEffects = "compositor_set_compositor_effects";
        /// <summary>
        /// Cached name for the 'environment_create' method.
        /// </summary>
        public static readonly StringName EnvironmentCreate = "environment_create";
        /// <summary>
        /// Cached name for the 'environment_set_background' method.
        /// </summary>
        public static readonly StringName EnvironmentSetBackground = "environment_set_background";
        /// <summary>
        /// Cached name for the 'environment_set_camera_id' method.
        /// </summary>
        public static readonly StringName EnvironmentSetCameraId = "environment_set_camera_id";
        /// <summary>
        /// Cached name for the 'environment_set_sky' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSky = "environment_set_sky";
        /// <summary>
        /// Cached name for the 'environment_set_sky_custom_fov' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSkyCustomFov = "environment_set_sky_custom_fov";
        /// <summary>
        /// Cached name for the 'environment_set_sky_orientation' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSkyOrientation = "environment_set_sky_orientation";
        /// <summary>
        /// Cached name for the 'environment_set_bg_color' method.
        /// </summary>
        public static readonly StringName EnvironmentSetBgColor = "environment_set_bg_color";
        /// <summary>
        /// Cached name for the 'environment_set_bg_energy' method.
        /// </summary>
        public static readonly StringName EnvironmentSetBgEnergy = "environment_set_bg_energy";
        /// <summary>
        /// Cached name for the 'environment_set_canvas_max_layer' method.
        /// </summary>
        public static readonly StringName EnvironmentSetCanvasMaxLayer = "environment_set_canvas_max_layer";
        /// <summary>
        /// Cached name for the 'environment_set_ambient_light' method.
        /// </summary>
        public static readonly StringName EnvironmentSetAmbientLight = "environment_set_ambient_light";
        /// <summary>
        /// Cached name for the 'environment_set_glow' method.
        /// </summary>
        public static readonly StringName EnvironmentSetGlow = "environment_set_glow";
        /// <summary>
        /// Cached name for the 'environment_set_tonemap' method.
        /// </summary>
        public static readonly StringName EnvironmentSetTonemap = "environment_set_tonemap";
        /// <summary>
        /// Cached name for the 'environment_set_tonemap_agx_contrast' method.
        /// </summary>
        public static readonly StringName EnvironmentSetTonemapAgxContrast = "environment_set_tonemap_agx_contrast";
        /// <summary>
        /// Cached name for the 'environment_set_adjustment' method.
        /// </summary>
        public static readonly StringName EnvironmentSetAdjustment = "environment_set_adjustment";
        /// <summary>
        /// Cached name for the 'environment_set_ssr' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSsr = "environment_set_ssr";
        /// <summary>
        /// Cached name for the 'environment_set_ssao' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSsao = "environment_set_ssao";
        /// <summary>
        /// Cached name for the 'environment_set_fog' method.
        /// </summary>
        public static readonly StringName EnvironmentSetFog = "environment_set_fog";
        /// <summary>
        /// Cached name for the 'environment_set_fog_depth' method.
        /// </summary>
        public static readonly StringName EnvironmentSetFogDepth = "environment_set_fog_depth";
        /// <summary>
        /// Cached name for the 'environment_set_sdfgi' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSdfgi = "environment_set_sdfgi";
        /// <summary>
        /// Cached name for the 'environment_set_volumetric_fog' method.
        /// </summary>
        public static readonly StringName EnvironmentSetVolumetricFog = "environment_set_volumetric_fog";
        /// <summary>
        /// Cached name for the 'environment_glow_set_use_bicubic_upscale' method.
        /// </summary>
        public static readonly StringName EnvironmentGlowSetUseBicubicUpscale = "environment_glow_set_use_bicubic_upscale";
        /// <summary>
        /// Cached name for the 'environment_set_ssr_half_size' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSsrHalfSize = "environment_set_ssr_half_size";
        /// <summary>
        /// Cached name for the 'environment_set_ssr_roughness_quality' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSsrRoughnessQuality = "environment_set_ssr_roughness_quality";
        /// <summary>
        /// Cached name for the 'environment_set_ssao_quality' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSsaoQuality = "environment_set_ssao_quality";
        /// <summary>
        /// Cached name for the 'environment_set_ssil_quality' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSsilQuality = "environment_set_ssil_quality";
        /// <summary>
        /// Cached name for the 'environment_set_sdfgi_ray_count' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSdfgiRayCount = "environment_set_sdfgi_ray_count";
        /// <summary>
        /// Cached name for the 'environment_set_sdfgi_frames_to_converge' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSdfgiFramesToConverge = "environment_set_sdfgi_frames_to_converge";
        /// <summary>
        /// Cached name for the 'environment_set_sdfgi_frames_to_update_light' method.
        /// </summary>
        public static readonly StringName EnvironmentSetSdfgiFramesToUpdateLight = "environment_set_sdfgi_frames_to_update_light";
        /// <summary>
        /// Cached name for the 'environment_set_volumetric_fog_volume_size' method.
        /// </summary>
        public static readonly StringName EnvironmentSetVolumetricFogVolumeSize = "environment_set_volumetric_fog_volume_size";
        /// <summary>
        /// Cached name for the 'environment_set_volumetric_fog_filter_active' method.
        /// </summary>
        public static readonly StringName EnvironmentSetVolumetricFogFilterActive = "environment_set_volumetric_fog_filter_active";
        /// <summary>
        /// Cached name for the 'environment_bake_panorama' method.
        /// </summary>
        public static readonly StringName EnvironmentBakePanorama = "environment_bake_panorama";
        /// <summary>
        /// Cached name for the 'screen_space_roughness_limiter_set_active' method.
        /// </summary>
        public static readonly StringName ScreenSpaceRoughnessLimiterSetActive = "screen_space_roughness_limiter_set_active";
        /// <summary>
        /// Cached name for the 'sub_surface_scattering_set_quality' method.
        /// </summary>
        public static readonly StringName SubSurfaceScatteringSetQuality = "sub_surface_scattering_set_quality";
        /// <summary>
        /// Cached name for the 'sub_surface_scattering_set_scale' method.
        /// </summary>
        public static readonly StringName SubSurfaceScatteringSetScale = "sub_surface_scattering_set_scale";
        /// <summary>
        /// Cached name for the 'camera_attributes_create' method.
        /// </summary>
        public static readonly StringName CameraAttributesCreate = "camera_attributes_create";
        /// <summary>
        /// Cached name for the 'camera_attributes_set_dof_blur_quality' method.
        /// </summary>
        public static readonly StringName CameraAttributesSetDofBlurQuality = "camera_attributes_set_dof_blur_quality";
        /// <summary>
        /// Cached name for the 'camera_attributes_set_dof_blur_bokeh_shape' method.
        /// </summary>
        public static readonly StringName CameraAttributesSetDofBlurBokehShape = "camera_attributes_set_dof_blur_bokeh_shape";
        /// <summary>
        /// Cached name for the 'camera_attributes_set_dof_blur' method.
        /// </summary>
        public static readonly StringName CameraAttributesSetDofBlur = "camera_attributes_set_dof_blur";
        /// <summary>
        /// Cached name for the 'camera_attributes_set_exposure' method.
        /// </summary>
        public static readonly StringName CameraAttributesSetExposure = "camera_attributes_set_exposure";
        /// <summary>
        /// Cached name for the 'camera_attributes_set_auto_exposure' method.
        /// </summary>
        public static readonly StringName CameraAttributesSetAutoExposure = "camera_attributes_set_auto_exposure";
        /// <summary>
        /// Cached name for the 'scenario_create' method.
        /// </summary>
        public static readonly StringName ScenarioCreate = "scenario_create";
        /// <summary>
        /// Cached name for the 'scenario_set_environment' method.
        /// </summary>
        public static readonly StringName ScenarioSetEnvironment = "scenario_set_environment";
        /// <summary>
        /// Cached name for the 'scenario_set_fallback_environment' method.
        /// </summary>
        public static readonly StringName ScenarioSetFallbackEnvironment = "scenario_set_fallback_environment";
        /// <summary>
        /// Cached name for the 'scenario_set_camera_attributes' method.
        /// </summary>
        public static readonly StringName ScenarioSetCameraAttributes = "scenario_set_camera_attributes";
        /// <summary>
        /// Cached name for the 'scenario_set_compositor' method.
        /// </summary>
        public static readonly StringName ScenarioSetCompositor = "scenario_set_compositor";
        /// <summary>
        /// Cached name for the 'instance_create2' method.
        /// </summary>
        public static readonly StringName InstanceCreate2 = "instance_create2";
        /// <summary>
        /// Cached name for the 'instance_create' method.
        /// </summary>
        public static readonly StringName InstanceCreate = "instance_create";
        /// <summary>
        /// Cached name for the 'instance_set_base' method.
        /// </summary>
        public static readonly StringName InstanceSetBase = "instance_set_base";
        /// <summary>
        /// Cached name for the 'instance_set_scenario' method.
        /// </summary>
        public static readonly StringName InstanceSetScenario = "instance_set_scenario";
        /// <summary>
        /// Cached name for the 'instance_set_layer_mask' method.
        /// </summary>
        public static readonly StringName InstanceSetLayerMask = "instance_set_layer_mask";
        /// <summary>
        /// Cached name for the 'instance_set_pivot_data' method.
        /// </summary>
        public static readonly StringName InstanceSetPivotData = "instance_set_pivot_data";
        /// <summary>
        /// Cached name for the 'instance_set_transform' method.
        /// </summary>
        public static readonly StringName InstanceSetTransform = "instance_set_transform";
        /// <summary>
        /// Cached name for the 'instance_attach_object_instance_id' method.
        /// </summary>
        public static readonly StringName InstanceAttachObjectInstanceId = "instance_attach_object_instance_id";
        /// <summary>
        /// Cached name for the 'instance_set_blend_shape_weight' method.
        /// </summary>
        public static readonly StringName InstanceSetBlendShapeWeight = "instance_set_blend_shape_weight";
        /// <summary>
        /// Cached name for the 'instance_set_surface_override_material' method.
        /// </summary>
        public static readonly StringName InstanceSetSurfaceOverrideMaterial = "instance_set_surface_override_material";
        /// <summary>
        /// Cached name for the 'instance_set_visible' method.
        /// </summary>
        public static readonly StringName InstanceSetVisible = "instance_set_visible";
        /// <summary>
        /// Cached name for the 'instance_geometry_set_transparency' method.
        /// </summary>
        public static readonly StringName InstanceGeometrySetTransparency = "instance_geometry_set_transparency";
        /// <summary>
        /// Cached name for the 'instance_teleport' method.
        /// </summary>
        public static readonly StringName InstanceTeleport = "instance_teleport";
        /// <summary>
        /// Cached name for the 'instance_set_custom_aabb' method.
        /// </summary>
        public static readonly StringName InstanceSetCustomAabb = "instance_set_custom_aabb";
        /// <summary>
        /// Cached name for the 'instance_attach_skeleton' method.
        /// </summary>
        public static readonly StringName InstanceAttachSkeleton = "instance_attach_skeleton";
        /// <summary>
        /// Cached name for the 'instance_set_extra_visibility_margin' method.
        /// </summary>
        public static readonly StringName InstanceSetExtraVisibilityMargin = "instance_set_extra_visibility_margin";
        /// <summary>
        /// Cached name for the 'instance_set_visibility_parent' method.
        /// </summary>
        public static readonly StringName InstanceSetVisibilityParent = "instance_set_visibility_parent";
        /// <summary>
        /// Cached name for the 'instance_set_ignore_culling' method.
        /// </summary>
        public static readonly StringName InstanceSetIgnoreCulling = "instance_set_ignore_culling";
        /// <summary>
        /// Cached name for the 'instance_geometry_set_flag' method.
        /// </summary>
        public static readonly StringName InstanceGeometrySetFlag = "instance_geometry_set_flag";
        /// <summary>
        /// Cached name for the 'instance_geometry_set_cast_shadows_setting' method.
        /// </summary>
        public static readonly StringName InstanceGeometrySetCastShadowsSetting = "instance_geometry_set_cast_shadows_setting";
        /// <summary>
        /// Cached name for the 'instance_geometry_set_material_override' method.
        /// </summary>
        public static readonly StringName InstanceGeometrySetMaterialOverride = "instance_geometry_set_material_override";
        /// <summary>
        /// Cached name for the 'instance_geometry_set_material_overlay' method.
        /// </summary>
        public static readonly StringName InstanceGeometrySetMaterialOverlay = "instance_geometry_set_material_overlay";
        /// <summary>
        /// Cached name for the 'instance_geometry_set_visibility_range' method.
        /// </summary>
        public static readonly StringName InstanceGeometrySetVisibilityRange = "instance_geometry_set_visibility_range";
        /// <summary>
        /// Cached name for the 'instance_geometry_set_lightmap' method.
        /// </summary>
        public static readonly StringName InstanceGeometrySetLightmap = "instance_geometry_set_lightmap";
        /// <summary>
        /// Cached name for the 'instance_geometry_set_lod_bias' method.
        /// </summary>
        public static readonly StringName InstanceGeometrySetLodBias = "instance_geometry_set_lod_bias";
        /// <summary>
        /// Cached name for the 'instance_geometry_set_shader_parameter' method.
        /// </summary>
        public static readonly StringName InstanceGeometrySetShaderParameter = "instance_geometry_set_shader_parameter";
        /// <summary>
        /// Cached name for the 'instance_geometry_get_shader_parameter' method.
        /// </summary>
        public static readonly StringName InstanceGeometryGetShaderParameter = "instance_geometry_get_shader_parameter";
        /// <summary>
        /// Cached name for the 'instance_geometry_get_shader_parameter_default_value' method.
        /// </summary>
        public static readonly StringName InstanceGeometryGetShaderParameterDefaultValue = "instance_geometry_get_shader_parameter_default_value";
        /// <summary>
        /// Cached name for the 'instance_geometry_get_shader_parameter_list' method.
        /// </summary>
        public static readonly StringName InstanceGeometryGetShaderParameterList = "instance_geometry_get_shader_parameter_list";
        /// <summary>
        /// Cached name for the 'instances_cull_aabb' method.
        /// </summary>
        public static readonly StringName InstancesCullAabb = "instances_cull_aabb";
        /// <summary>
        /// Cached name for the 'instances_cull_ray' method.
        /// </summary>
        public static readonly StringName InstancesCullRay = "instances_cull_ray";
        /// <summary>
        /// Cached name for the 'instances_cull_convex' method.
        /// </summary>
        public static readonly StringName InstancesCullConvex = "instances_cull_convex";
        /// <summary>
        /// Cached name for the 'bake_render_uv2' method.
        /// </summary>
        public static readonly StringName BakeRenderUV2 = "bake_render_uv2";
        /// <summary>
        /// Cached name for the 'canvas_create' method.
        /// </summary>
        public static readonly StringName CanvasCreate = "canvas_create";
        /// <summary>
        /// Cached name for the 'canvas_set_item_mirroring' method.
        /// </summary>
        public static readonly StringName CanvasSetItemMirroring = "canvas_set_item_mirroring";
        /// <summary>
        /// Cached name for the 'canvas_set_item_repeat' method.
        /// </summary>
        public static readonly StringName CanvasSetItemRepeat = "canvas_set_item_repeat";
        /// <summary>
        /// Cached name for the 'canvas_set_modulate' method.
        /// </summary>
        public static readonly StringName CanvasSetModulate = "canvas_set_modulate";
        /// <summary>
        /// Cached name for the 'canvas_set_disable_scale' method.
        /// </summary>
        public static readonly StringName CanvasSetDisableScale = "canvas_set_disable_scale";
        /// <summary>
        /// Cached name for the 'canvas_texture_create' method.
        /// </summary>
        public static readonly StringName CanvasTextureCreate = "canvas_texture_create";
        /// <summary>
        /// Cached name for the 'canvas_texture_set_channel' method.
        /// </summary>
        public static readonly StringName CanvasTextureSetChannel = "canvas_texture_set_channel";
        /// <summary>
        /// Cached name for the 'canvas_texture_set_shading_parameters' method.
        /// </summary>
        public static readonly StringName CanvasTextureSetShadingParameters = "canvas_texture_set_shading_parameters";
        /// <summary>
        /// Cached name for the 'canvas_texture_set_texture_filter' method.
        /// </summary>
        public static readonly StringName CanvasTextureSetTextureFilter = "canvas_texture_set_texture_filter";
        /// <summary>
        /// Cached name for the 'canvas_texture_set_texture_repeat' method.
        /// </summary>
        public static readonly StringName CanvasTextureSetTextureRepeat = "canvas_texture_set_texture_repeat";
        /// <summary>
        /// Cached name for the 'canvas_item_create' method.
        /// </summary>
        public static readonly StringName CanvasItemCreate = "canvas_item_create";
        /// <summary>
        /// Cached name for the 'canvas_item_set_parent' method.
        /// </summary>
        public static readonly StringName CanvasItemSetParent = "canvas_item_set_parent";
        /// <summary>
        /// Cached name for the 'canvas_item_set_default_texture_filter' method.
        /// </summary>
        public static readonly StringName CanvasItemSetDefaultTextureFilter = "canvas_item_set_default_texture_filter";
        /// <summary>
        /// Cached name for the 'canvas_item_set_default_texture_repeat' method.
        /// </summary>
        public static readonly StringName CanvasItemSetDefaultTextureRepeat = "canvas_item_set_default_texture_repeat";
        /// <summary>
        /// Cached name for the 'canvas_item_set_visible' method.
        /// </summary>
        public static readonly StringName CanvasItemSetVisible = "canvas_item_set_visible";
        /// <summary>
        /// Cached name for the 'canvas_item_set_light_mask' method.
        /// </summary>
        public static readonly StringName CanvasItemSetLightMask = "canvas_item_set_light_mask";
        /// <summary>
        /// Cached name for the 'canvas_item_set_visibility_layer' method.
        /// </summary>
        public static readonly StringName CanvasItemSetVisibilityLayer = "canvas_item_set_visibility_layer";
        /// <summary>
        /// Cached name for the 'canvas_item_set_transform' method.
        /// </summary>
        public static readonly StringName CanvasItemSetTransform = "canvas_item_set_transform";
        /// <summary>
        /// Cached name for the 'canvas_item_set_clip' method.
        /// </summary>
        public static readonly StringName CanvasItemSetClip = "canvas_item_set_clip";
        /// <summary>
        /// Cached name for the 'canvas_item_set_distance_field_mode' method.
        /// </summary>
        public static readonly StringName CanvasItemSetDistanceFieldMode = "canvas_item_set_distance_field_mode";
        /// <summary>
        /// Cached name for the 'canvas_item_set_custom_rect' method.
        /// </summary>
        public static readonly StringName CanvasItemSetCustomRect = "canvas_item_set_custom_rect";
        /// <summary>
        /// Cached name for the 'canvas_item_set_modulate' method.
        /// </summary>
        public static readonly StringName CanvasItemSetModulate = "canvas_item_set_modulate";
        /// <summary>
        /// Cached name for the 'canvas_item_set_self_modulate' method.
        /// </summary>
        public static readonly StringName CanvasItemSetSelfModulate = "canvas_item_set_self_modulate";
        /// <summary>
        /// Cached name for the 'canvas_item_set_draw_behind_parent' method.
        /// </summary>
        public static readonly StringName CanvasItemSetDrawBehindParent = "canvas_item_set_draw_behind_parent";
        /// <summary>
        /// Cached name for the 'canvas_item_set_interpolated' method.
        /// </summary>
        public static readonly StringName CanvasItemSetInterpolated = "canvas_item_set_interpolated";
        /// <summary>
        /// Cached name for the 'canvas_item_reset_physics_interpolation' method.
        /// </summary>
        public static readonly StringName CanvasItemResetPhysicsInterpolation = "canvas_item_reset_physics_interpolation";
        /// <summary>
        /// Cached name for the 'canvas_item_transform_physics_interpolation' method.
        /// </summary>
        public static readonly StringName CanvasItemTransformPhysicsInterpolation = "canvas_item_transform_physics_interpolation";
        /// <summary>
        /// Cached name for the 'canvas_item_add_line' method.
        /// </summary>
        public static readonly StringName CanvasItemAddLine = "canvas_item_add_line";
        /// <summary>
        /// Cached name for the 'canvas_item_add_polyline' method.
        /// </summary>
        public static readonly StringName CanvasItemAddPolyline = "canvas_item_add_polyline";
        /// <summary>
        /// Cached name for the 'canvas_item_add_multiline' method.
        /// </summary>
        public static readonly StringName CanvasItemAddMultiline = "canvas_item_add_multiline";
        /// <summary>
        /// Cached name for the 'canvas_item_add_rect' method.
        /// </summary>
        public static readonly StringName CanvasItemAddRect = "canvas_item_add_rect";
        /// <summary>
        /// Cached name for the 'canvas_item_add_circle' method.
        /// </summary>
        public static readonly StringName CanvasItemAddCircle = "canvas_item_add_circle";
        /// <summary>
        /// Cached name for the 'canvas_item_add_ellipse' method.
        /// </summary>
        public static readonly StringName CanvasItemAddEllipse = "canvas_item_add_ellipse";
        /// <summary>
        /// Cached name for the 'canvas_item_add_texture_rect' method.
        /// </summary>
        public static readonly StringName CanvasItemAddTextureRect = "canvas_item_add_texture_rect";
        /// <summary>
        /// Cached name for the 'canvas_item_add_msdf_texture_rect_region' method.
        /// </summary>
        public static readonly StringName CanvasItemAddMsdfTextureRectRegion = "canvas_item_add_msdf_texture_rect_region";
        /// <summary>
        /// Cached name for the 'canvas_item_add_lcd_texture_rect_region' method.
        /// </summary>
        public static readonly StringName CanvasItemAddLcdTextureRectRegion = "canvas_item_add_lcd_texture_rect_region";
        /// <summary>
        /// Cached name for the 'canvas_item_add_texture_rect_region' method.
        /// </summary>
        public static readonly StringName CanvasItemAddTextureRectRegion = "canvas_item_add_texture_rect_region";
        /// <summary>
        /// Cached name for the 'canvas_item_add_nine_patch' method.
        /// </summary>
        public static readonly StringName CanvasItemAddNinePatch = "canvas_item_add_nine_patch";
        /// <summary>
        /// Cached name for the 'canvas_item_add_primitive' method.
        /// </summary>
        public static readonly StringName CanvasItemAddPrimitive = "canvas_item_add_primitive";
        /// <summary>
        /// Cached name for the 'canvas_item_add_polygon' method.
        /// </summary>
        public static readonly StringName CanvasItemAddPolygon = "canvas_item_add_polygon";
        /// <summary>
        /// Cached name for the 'canvas_item_add_triangle_array' method.
        /// </summary>
        public static readonly StringName CanvasItemAddTriangleArray = "canvas_item_add_triangle_array";
        /// <summary>
        /// Cached name for the 'canvas_item_add_mesh' method.
        /// </summary>
        public static readonly StringName CanvasItemAddMesh = "canvas_item_add_mesh";
        /// <summary>
        /// Cached name for the 'canvas_item_add_multimesh' method.
        /// </summary>
        public static readonly StringName CanvasItemAddMultimesh = "canvas_item_add_multimesh";
        /// <summary>
        /// Cached name for the 'canvas_item_add_particles' method.
        /// </summary>
        public static readonly StringName CanvasItemAddParticles = "canvas_item_add_particles";
        /// <summary>
        /// Cached name for the 'canvas_item_add_set_transform' method.
        /// </summary>
        public static readonly StringName CanvasItemAddSetTransform = "canvas_item_add_set_transform";
        /// <summary>
        /// Cached name for the 'canvas_item_add_clip_ignore' method.
        /// </summary>
        public static readonly StringName CanvasItemAddClipIgnore = "canvas_item_add_clip_ignore";
        /// <summary>
        /// Cached name for the 'canvas_item_add_animation_slice' method.
        /// </summary>
        public static readonly StringName CanvasItemAddAnimationSlice = "canvas_item_add_animation_slice";
        /// <summary>
        /// Cached name for the 'canvas_item_set_sort_children_by_y' method.
        /// </summary>
        public static readonly StringName CanvasItemSetSortChildrenByY = "canvas_item_set_sort_children_by_y";
        /// <summary>
        /// Cached name for the 'canvas_item_set_z_index' method.
        /// </summary>
        public static readonly StringName CanvasItemSetZIndex = "canvas_item_set_z_index";
        /// <summary>
        /// Cached name for the 'canvas_item_set_z_as_relative_to_parent' method.
        /// </summary>
        public static readonly StringName CanvasItemSetZAsRelativeToParent = "canvas_item_set_z_as_relative_to_parent";
        /// <summary>
        /// Cached name for the 'canvas_item_set_copy_to_backbuffer' method.
        /// </summary>
        public static readonly StringName CanvasItemSetCopyToBackbuffer = "canvas_item_set_copy_to_backbuffer";
        /// <summary>
        /// Cached name for the 'canvas_item_attach_skeleton' method.
        /// </summary>
        public static readonly StringName CanvasItemAttachSkeleton = "canvas_item_attach_skeleton";
        /// <summary>
        /// Cached name for the 'canvas_item_clear' method.
        /// </summary>
        public static readonly StringName CanvasItemClear = "canvas_item_clear";
        /// <summary>
        /// Cached name for the 'canvas_item_set_draw_index' method.
        /// </summary>
        public static readonly StringName CanvasItemSetDrawIndex = "canvas_item_set_draw_index";
        /// <summary>
        /// Cached name for the 'canvas_item_set_material' method.
        /// </summary>
        public static readonly StringName CanvasItemSetMaterial = "canvas_item_set_material";
        /// <summary>
        /// Cached name for the 'canvas_item_set_use_parent_material' method.
        /// </summary>
        public static readonly StringName CanvasItemSetUseParentMaterial = "canvas_item_set_use_parent_material";
        /// <summary>
        /// Cached name for the 'canvas_item_set_instance_shader_parameter' method.
        /// </summary>
        public static readonly StringName CanvasItemSetInstanceShaderParameter = "canvas_item_set_instance_shader_parameter";
        /// <summary>
        /// Cached name for the 'canvas_item_get_instance_shader_parameter' method.
        /// </summary>
        public static readonly StringName CanvasItemGetInstanceShaderParameter = "canvas_item_get_instance_shader_parameter";
        /// <summary>
        /// Cached name for the 'canvas_item_get_instance_shader_parameter_default_value' method.
        /// </summary>
        public static readonly StringName CanvasItemGetInstanceShaderParameterDefaultValue = "canvas_item_get_instance_shader_parameter_default_value";
        /// <summary>
        /// Cached name for the 'canvas_item_get_instance_shader_parameter_list' method.
        /// </summary>
        public static readonly StringName CanvasItemGetInstanceShaderParameterList = "canvas_item_get_instance_shader_parameter_list";
        /// <summary>
        /// Cached name for the 'canvas_item_set_visibility_notifier' method.
        /// </summary>
        public static readonly StringName CanvasItemSetVisibilityNotifier = "canvas_item_set_visibility_notifier";
        /// <summary>
        /// Cached name for the 'canvas_item_set_canvas_group_mode' method.
        /// </summary>
        public static readonly StringName CanvasItemSetCanvasGroupMode = "canvas_item_set_canvas_group_mode";
        /// <summary>
        /// Cached name for the 'debug_canvas_item_get_rect' method.
        /// </summary>
        public static readonly StringName DebugCanvasItemGetRect = "debug_canvas_item_get_rect";
        /// <summary>
        /// Cached name for the 'canvas_light_create' method.
        /// </summary>
        public static readonly StringName CanvasLightCreate = "canvas_light_create";
        /// <summary>
        /// Cached name for the 'canvas_light_attach_to_canvas' method.
        /// </summary>
        public static readonly StringName CanvasLightAttachToCanvas = "canvas_light_attach_to_canvas";
        /// <summary>
        /// Cached name for the 'canvas_light_set_enabled' method.
        /// </summary>
        public static readonly StringName CanvasLightSetEnabled = "canvas_light_set_enabled";
        /// <summary>
        /// Cached name for the 'canvas_light_set_texture_scale' method.
        /// </summary>
        public static readonly StringName CanvasLightSetTextureScale = "canvas_light_set_texture_scale";
        /// <summary>
        /// Cached name for the 'canvas_light_set_transform' method.
        /// </summary>
        public static readonly StringName CanvasLightSetTransform = "canvas_light_set_transform";
        /// <summary>
        /// Cached name for the 'canvas_light_set_texture' method.
        /// </summary>
        public static readonly StringName CanvasLightSetTexture = "canvas_light_set_texture";
        /// <summary>
        /// Cached name for the 'canvas_light_set_texture_offset' method.
        /// </summary>
        public static readonly StringName CanvasLightSetTextureOffset = "canvas_light_set_texture_offset";
        /// <summary>
        /// Cached name for the 'canvas_light_set_color' method.
        /// </summary>
        public static readonly StringName CanvasLightSetColor = "canvas_light_set_color";
        /// <summary>
        /// Cached name for the 'canvas_light_set_height' method.
        /// </summary>
        public static readonly StringName CanvasLightSetHeight = "canvas_light_set_height";
        /// <summary>
        /// Cached name for the 'canvas_light_set_energy' method.
        /// </summary>
        public static readonly StringName CanvasLightSetEnergy = "canvas_light_set_energy";
        /// <summary>
        /// Cached name for the 'canvas_light_set_z_range' method.
        /// </summary>
        public static readonly StringName CanvasLightSetZRange = "canvas_light_set_z_range";
        /// <summary>
        /// Cached name for the 'canvas_light_set_layer_range' method.
        /// </summary>
        public static readonly StringName CanvasLightSetLayerRange = "canvas_light_set_layer_range";
        /// <summary>
        /// Cached name for the 'canvas_light_set_item_cull_mask' method.
        /// </summary>
        public static readonly StringName CanvasLightSetItemCullMask = "canvas_light_set_item_cull_mask";
        /// <summary>
        /// Cached name for the 'canvas_light_set_item_shadow_cull_mask' method.
        /// </summary>
        public static readonly StringName CanvasLightSetItemShadowCullMask = "canvas_light_set_item_shadow_cull_mask";
        /// <summary>
        /// Cached name for the 'canvas_light_set_mode' method.
        /// </summary>
        public static readonly StringName CanvasLightSetMode = "canvas_light_set_mode";
        /// <summary>
        /// Cached name for the 'canvas_light_set_shadow_enabled' method.
        /// </summary>
        public static readonly StringName CanvasLightSetShadowEnabled = "canvas_light_set_shadow_enabled";
        /// <summary>
        /// Cached name for the 'canvas_light_set_shadow_filter' method.
        /// </summary>
        public static readonly StringName CanvasLightSetShadowFilter = "canvas_light_set_shadow_filter";
        /// <summary>
        /// Cached name for the 'canvas_light_set_shadow_color' method.
        /// </summary>
        public static readonly StringName CanvasLightSetShadowColor = "canvas_light_set_shadow_color";
        /// <summary>
        /// Cached name for the 'canvas_light_set_shadow_smooth' method.
        /// </summary>
        public static readonly StringName CanvasLightSetShadowSmooth = "canvas_light_set_shadow_smooth";
        /// <summary>
        /// Cached name for the 'canvas_light_set_blend_mode' method.
        /// </summary>
        public static readonly StringName CanvasLightSetBlendMode = "canvas_light_set_blend_mode";
        /// <summary>
        /// Cached name for the 'canvas_light_set_interpolated' method.
        /// </summary>
        public static readonly StringName CanvasLightSetInterpolated = "canvas_light_set_interpolated";
        /// <summary>
        /// Cached name for the 'canvas_light_reset_physics_interpolation' method.
        /// </summary>
        public static readonly StringName CanvasLightResetPhysicsInterpolation = "canvas_light_reset_physics_interpolation";
        /// <summary>
        /// Cached name for the 'canvas_light_transform_physics_interpolation' method.
        /// </summary>
        public static readonly StringName CanvasLightTransformPhysicsInterpolation = "canvas_light_transform_physics_interpolation";
        /// <summary>
        /// Cached name for the 'canvas_light_occluder_create' method.
        /// </summary>
        public static readonly StringName CanvasLightOccluderCreate = "canvas_light_occluder_create";
        /// <summary>
        /// Cached name for the 'canvas_light_occluder_attach_to_canvas' method.
        /// </summary>
        public static readonly StringName CanvasLightOccluderAttachToCanvas = "canvas_light_occluder_attach_to_canvas";
        /// <summary>
        /// Cached name for the 'canvas_light_occluder_set_enabled' method.
        /// </summary>
        public static readonly StringName CanvasLightOccluderSetEnabled = "canvas_light_occluder_set_enabled";
        /// <summary>
        /// Cached name for the 'canvas_light_occluder_set_polygon' method.
        /// </summary>
        public static readonly StringName CanvasLightOccluderSetPolygon = "canvas_light_occluder_set_polygon";
        /// <summary>
        /// Cached name for the 'canvas_light_occluder_set_as_sdf_collision' method.
        /// </summary>
        public static readonly StringName CanvasLightOccluderSetAsSdfCollision = "canvas_light_occluder_set_as_sdf_collision";
        /// <summary>
        /// Cached name for the 'canvas_light_occluder_set_transform' method.
        /// </summary>
        public static readonly StringName CanvasLightOccluderSetTransform = "canvas_light_occluder_set_transform";
        /// <summary>
        /// Cached name for the 'canvas_light_occluder_set_light_mask' method.
        /// </summary>
        public static readonly StringName CanvasLightOccluderSetLightMask = "canvas_light_occluder_set_light_mask";
        /// <summary>
        /// Cached name for the 'canvas_light_occluder_set_interpolated' method.
        /// </summary>
        public static readonly StringName CanvasLightOccluderSetInterpolated = "canvas_light_occluder_set_interpolated";
        /// <summary>
        /// Cached name for the 'canvas_light_occluder_reset_physics_interpolation' method.
        /// </summary>
        public static readonly StringName CanvasLightOccluderResetPhysicsInterpolation = "canvas_light_occluder_reset_physics_interpolation";
        /// <summary>
        /// Cached name for the 'canvas_light_occluder_transform_physics_interpolation' method.
        /// </summary>
        public static readonly StringName CanvasLightOccluderTransformPhysicsInterpolation = "canvas_light_occluder_transform_physics_interpolation";
        /// <summary>
        /// Cached name for the 'canvas_occluder_polygon_create' method.
        /// </summary>
        public static readonly StringName CanvasOccluderPolygonCreate = "canvas_occluder_polygon_create";
        /// <summary>
        /// Cached name for the 'canvas_occluder_polygon_set_shape' method.
        /// </summary>
        public static readonly StringName CanvasOccluderPolygonSetShape = "canvas_occluder_polygon_set_shape";
        /// <summary>
        /// Cached name for the 'canvas_occluder_polygon_set_cull_mode' method.
        /// </summary>
        public static readonly StringName CanvasOccluderPolygonSetCullMode = "canvas_occluder_polygon_set_cull_mode";
        /// <summary>
        /// Cached name for the 'canvas_set_shadow_texture_size' method.
        /// </summary>
        public static readonly StringName CanvasSetShadowTextureSize = "canvas_set_shadow_texture_size";
        /// <summary>
        /// Cached name for the 'global_shader_parameter_add' method.
        /// </summary>
        public static readonly StringName GlobalShaderParameterAdd = "global_shader_parameter_add";
        /// <summary>
        /// Cached name for the 'global_shader_parameter_remove' method.
        /// </summary>
        public static readonly StringName GlobalShaderParameterRemove = "global_shader_parameter_remove";
        /// <summary>
        /// Cached name for the 'global_shader_parameter_get_list' method.
        /// </summary>
        public static readonly StringName GlobalShaderParameterGetList = "global_shader_parameter_get_list";
        /// <summary>
        /// Cached name for the 'global_shader_parameter_set' method.
        /// </summary>
        public static readonly StringName GlobalShaderParameterSet = "global_shader_parameter_set";
        /// <summary>
        /// Cached name for the 'global_shader_parameter_set_override' method.
        /// </summary>
        public static readonly StringName GlobalShaderParameterSetOverride = "global_shader_parameter_set_override";
        /// <summary>
        /// Cached name for the 'global_shader_parameter_get' method.
        /// </summary>
        public static readonly StringName GlobalShaderParameterGet = "global_shader_parameter_get";
        /// <summary>
        /// Cached name for the 'global_shader_parameter_get_type' method.
        /// </summary>
        public static readonly StringName GlobalShaderParameterGetType = "global_shader_parameter_get_type";
        /// <summary>
        /// Cached name for the 'free_rid' method.
        /// </summary>
        public static readonly StringName FreeRid = "free_rid";
        /// <summary>
        /// Cached name for the 'request_frame_drawn_callback' method.
        /// </summary>
        public static readonly StringName RequestFrameDrawnCallback = "request_frame_drawn_callback";
        /// <summary>
        /// Cached name for the 'has_changed' method.
        /// </summary>
        public static readonly StringName HasChanged = "has_changed";
        /// <summary>
        /// Cached name for the 'get_rendering_info' method.
        /// </summary>
        public static readonly StringName GetRenderingInfo = "get_rendering_info";
        /// <summary>
        /// Cached name for the 'get_video_adapter_name' method.
        /// </summary>
        public static readonly StringName GetVideoAdapterName = "get_video_adapter_name";
        /// <summary>
        /// Cached name for the 'get_video_adapter_vendor' method.
        /// </summary>
        public static readonly StringName GetVideoAdapterVendor = "get_video_adapter_vendor";
        /// <summary>
        /// Cached name for the 'get_video_adapter_type' method.
        /// </summary>
        public static readonly StringName GetVideoAdapterType = "get_video_adapter_type";
        /// <summary>
        /// Cached name for the 'get_video_adapter_api_version' method.
        /// </summary>
        public static readonly StringName GetVideoAdapterApiVersion = "get_video_adapter_api_version";
        /// <summary>
        /// Cached name for the 'get_current_rendering_driver_name' method.
        /// </summary>
        public static readonly StringName GetCurrentRenderingDriverName = "get_current_rendering_driver_name";
        /// <summary>
        /// Cached name for the 'get_current_rendering_method' method.
        /// </summary>
        public static readonly StringName GetCurrentRenderingMethod = "get_current_rendering_method";
        /// <summary>
        /// Cached name for the 'make_sphere_mesh' method.
        /// </summary>
        public static readonly StringName MakeSphereMesh = "make_sphere_mesh";
        /// <summary>
        /// Cached name for the 'get_test_cube' method.
        /// </summary>
        public static readonly StringName GetTestCube = "get_test_cube";
        /// <summary>
        /// Cached name for the 'get_test_texture' method.
        /// </summary>
        public static readonly StringName GetTestTexture = "get_test_texture";
        /// <summary>
        /// Cached name for the 'get_white_texture' method.
        /// </summary>
        public static readonly StringName GetWhiteTexture = "get_white_texture";
        /// <summary>
        /// Cached name for the 'set_boot_image_with_stretch' method.
        /// </summary>
        public static readonly StringName SetBootImageWithStretch = "set_boot_image_with_stretch";
        /// <summary>
        /// Cached name for the 'set_boot_image' method.
        /// </summary>
        public static readonly StringName SetBootImage = "set_boot_image";
        /// <summary>
        /// Cached name for the 'get_default_clear_color' method.
        /// </summary>
        public static readonly StringName GetDefaultClearColor = "get_default_clear_color";
        /// <summary>
        /// Cached name for the 'set_default_clear_color' method.
        /// </summary>
        public static readonly StringName SetDefaultClearColor = "set_default_clear_color";
        /// <summary>
        /// Cached name for the 'has_os_feature' method.
        /// </summary>
        public static readonly StringName HasOsFeature = "has_os_feature";
        /// <summary>
        /// Cached name for the 'set_debug_generate_wireframes' method.
        /// </summary>
        public static readonly StringName SetDebugGenerateWireframes = "set_debug_generate_wireframes";
        /// <summary>
        /// Cached name for the 'is_render_loop_enabled' method.
        /// </summary>
        public static readonly StringName IsRenderLoopEnabled = "is_render_loop_enabled";
        /// <summary>
        /// Cached name for the 'set_render_loop_enabled' method.
        /// </summary>
        public static readonly StringName SetRenderLoopEnabled = "set_render_loop_enabled";
        /// <summary>
        /// Cached name for the 'get_frame_setup_time_cpu' method.
        /// </summary>
        public static readonly StringName GetFrameSetupTimeCpu = "get_frame_setup_time_cpu";
        /// <summary>
        /// Cached name for the 'force_sync' method.
        /// </summary>
        public static readonly StringName ForceSync = "force_sync";
        /// <summary>
        /// Cached name for the 'force_draw' method.
        /// </summary>
        public static readonly StringName ForceDraw = "force_draw";
        /// <summary>
        /// Cached name for the 'get_rendering_device' method.
        /// </summary>
        public static readonly StringName GetRenderingDevice = "get_rendering_device";
        /// <summary>
        /// Cached name for the 'create_local_rendering_device' method.
        /// </summary>
        public static readonly StringName CreateLocalRenderingDevice = "create_local_rendering_device";
        /// <summary>
        /// Cached name for the 'is_on_render_thread' method.
        /// </summary>
        public static readonly StringName IsOnRenderThread = "is_on_render_thread";
        /// <summary>
        /// Cached name for the 'call_on_render_thread' method.
        /// </summary>
        public static readonly StringName CallOnRenderThread = "call_on_render_thread";
        /// <summary>
        /// Cached name for the 'has_feature' method.
        /// </summary>
        public static readonly StringName HasFeature = "has_feature";
        /// <summary>
        /// Cached name for the 'instance_reset_physics_interpolation' method.
        /// </summary>
        public static readonly StringName InstanceResetPhysicsInterpolation = "instance_reset_physics_interpolation";
        /// <summary>
        /// Cached name for the 'instance_set_interpolated' method.
        /// </summary>
        public static readonly StringName InstanceSetInterpolated = "instance_set_interpolated";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
        /// <summary>
        /// Cached name for the 'frame_pre_draw' signal.
        /// </summary>
        public static readonly StringName FramePreDraw = "frame_pre_draw";
        /// <summary>
        /// Cached name for the 'frame_post_draw' signal.
        /// </summary>
        public static readonly StringName FramePostDraw = "frame_post_draw";
    }
}
