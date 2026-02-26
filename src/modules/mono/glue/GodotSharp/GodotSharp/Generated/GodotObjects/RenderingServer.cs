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
/// <para>All objects are drawn to a viewport. You can use the <see cref="Godot.Viewport"/> attached to the <see cref="Godot.SceneTree"/> or you can create one yourself with <see cref="Godot.RenderingServer.ViewportCreate()"/>. When using a custom scenario or canvas, the scenario or canvas needs to be attached to the viewport using <see cref="Godot.RenderingServer.ViewportSetScenario(Rid, Rid)"/> or <see cref="Godot.RenderingServer.ViewportAttachCanvas(Rid, Rid)"/>.</para>
/// <para><b>Scenarios:</b> In 3D, all visual objects must be associated with a scenario. The scenario is a visual representation of the world. If accessing the rendering server from a running game, the scenario can be accessed from the scene tree from any <see cref="Godot.Node3D"/> node with <see cref="Godot.Node3D.GetWorld3D()"/>. Otherwise, a scenario can be created with <see cref="Godot.RenderingServer.ScenarioCreate()"/>.</para>
/// <para>Similarly, in 2D, a canvas is needed to draw all canvas items.</para>
/// <para><b>3D:</b> In 3D, all visible objects are comprised of a resource and an instance. A resource can be a mesh, a particle system, a light, or any other 3D object. In order to be visible resources must be attached to an instance using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/>. The instance must also be attached to the scenario using <see cref="Godot.RenderingServer.InstanceSetScenario(Rid, Rid)"/> in order to be visible. RenderingServer methods that don't have a prefix are usually 3D-specific (but not always).</para>
/// <para><b>2D:</b> In 2D, all visible objects are some form of canvas item. In order to be visible, a canvas item needs to be the child of a canvas attached to a viewport, or it needs to be the child of another canvas item that is eventually attached to the canvas. 2D-specific RenderingServer methods generally start with <c>canvas_*</c>.</para>
/// <para><b>Headless mode:</b> Starting the engine with the <c>--headless</c> <a href="$DOCS_URL/tutorials/editor/command_line_tutorial.html">command line argument</a> disables all rendering and window management functions. Most functions from <see cref="Godot.RenderingServer"/> will return dummy values in this case.</para>
/// </summary>
public static partial class RenderingServer
{
    /// <summary>
    /// <para>Marks an error that shows that the index array is empty.</para>
    /// </summary>
    public const long NoIndexArray = -1;
    /// <summary>
    /// <para>Number of weights/bones per vertex.</para>
    /// </summary>
    public const long ArrayWeightsSize = 4;
    /// <summary>
    /// <para>The minimum Z-layer for canvas items.</para>
    /// </summary>
    public const long CanvasItemZMin = -4096;
    /// <summary>
    /// <para>The maximum Z-layer for canvas items.</para>
    /// </summary>
    public const long CanvasItemZMax = 4096;
    /// <summary>
    /// <para>The minimum canvas layer.</para>
    /// </summary>
    public const long CanvasLayerMin = -2147483648;
    /// <summary>
    /// <para>The maximum canvas layer.</para>
    /// </summary>
    public const long CanvasLayerMax = 2147483647;
    /// <summary>
    /// <para>The maximum number of glow levels that can be used with the glow post-processing effect.</para>
    /// </summary>
    public const long MaxGlowLevels = 7;
    [Obsolete("This constant is not used by the engine.")]
    public const long MaxCursors = 8;
    /// <summary>
    /// <para>The maximum number of directional lights that can be rendered at a given time in 2D.</para>
    /// </summary>
    public const long Max2DDirectionalLights = 8;
    /// <summary>
    /// <para>The maximum number of surfaces a mesh can have.</para>
    /// </summary>
    public const long MaxMeshSurfaces = 256;
    /// <summary>
    /// <para>The minimum renderpriority of all materials.</para>
    /// </summary>
    public const long MaterialRenderPriorityMin = -128;
    /// <summary>
    /// <para>The maximum renderpriority of all materials.</para>
    /// </summary>
    public const long MaterialRenderPriorityMax = 127;
    /// <summary>
    /// <para>The number of custom data arrays available (<see cref="Godot.RenderingServer.ArrayType.Custom0"/>, <see cref="Godot.RenderingServer.ArrayType.Custom1"/>, <see cref="Godot.RenderingServer.ArrayType.Custom2"/>, <see cref="Godot.RenderingServer.ArrayType.Custom3"/>).</para>
    /// </summary>
    public const long ArrayCustomCount = 4;
    public const long ParticlesEmitFlagPosition = 1;
    public const long ParticlesEmitFlagRotationScale = 2;
    public const long ParticlesEmitFlagVelocity = 4;
    public const long ParticlesEmitFlagColor = 8;
    public const long ParticlesEmitFlagCustom = 16;

    public enum TextureType : long
    {
        /// <summary>
        /// <para>2D texture.</para>
        /// </summary>
        Type2D = 0,
        /// <summary>
        /// <para>Layered texture.</para>
        /// </summary>
        Layered = 1,
        /// <summary>
        /// <para>3D texture.</para>
        /// </summary>
        Type3D = 2
    }

    public enum TextureLayeredType : long
    {
        /// <summary>
        /// <para>Array of 2-dimensional textures (see <see cref="Godot.Texture2DArray"/>).</para>
        /// </summary>
        Layered2DArray = 0,
        /// <summary>
        /// <para>Cubemap texture (see <see cref="Godot.Cubemap"/>).</para>
        /// </summary>
        Cubemap = 1,
        /// <summary>
        /// <para>Array of cubemap textures (see <see cref="Godot.CubemapArray"/>).</para>
        /// </summary>
        CubemapArray = 2
    }

    public enum CubeMapLayer : long
    {
        /// <summary>
        /// <para>Left face of a <see cref="Godot.Cubemap"/>.</para>
        /// </summary>
        Left = 0,
        /// <summary>
        /// <para>Right face of a <see cref="Godot.Cubemap"/>.</para>
        /// </summary>
        Right = 1,
        /// <summary>
        /// <para>Bottom face of a <see cref="Godot.Cubemap"/>.</para>
        /// </summary>
        Bottom = 2,
        /// <summary>
        /// <para>Top face of a <see cref="Godot.Cubemap"/>.</para>
        /// </summary>
        Top = 3,
        /// <summary>
        /// <para>Front face of a <see cref="Godot.Cubemap"/>.</para>
        /// </summary>
        Front = 4,
        /// <summary>
        /// <para>Back face of a <see cref="Godot.Cubemap"/>.</para>
        /// </summary>
        Back = 5
    }

    public enum ShaderMode : long
    {
        /// <summary>
        /// <para>Shader is a 3D shader.</para>
        /// </summary>
        Spatial = 0,
        /// <summary>
        /// <para>Shader is a 2D shader.</para>
        /// </summary>
        CanvasItem = 1,
        /// <summary>
        /// <para>Shader is a particle shader (can be used in both 2D and 3D).</para>
        /// </summary>
        Particles = 2,
        /// <summary>
        /// <para>Shader is a 3D sky shader.</para>
        /// </summary>
        Sky = 3,
        /// <summary>
        /// <para>Shader is a 3D fog shader.</para>
        /// </summary>
        Fog = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ShaderMode"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum ArrayType : long
    {
        /// <summary>
        /// <para>Array is a vertex position array.</para>
        /// </summary>
        Vertex = 0,
        /// <summary>
        /// <para>Array is a normal array.</para>
        /// </summary>
        Normal = 1,
        /// <summary>
        /// <para>Array is a tangent array.</para>
        /// </summary>
        Tangent = 2,
        /// <summary>
        /// <para>Array is a vertex color array.</para>
        /// </summary>
        Color = 3,
        /// <summary>
        /// <para>Array is a UV coordinates array.</para>
        /// </summary>
        TexUV = 4,
        /// <summary>
        /// <para>Array is a UV coordinates array for the second set of UV coordinates.</para>
        /// </summary>
        TexUV2 = 5,
        /// <summary>
        /// <para>Array is a custom data array for the first set of custom data.</para>
        /// </summary>
        Custom0 = 6,
        /// <summary>
        /// <para>Array is a custom data array for the second set of custom data.</para>
        /// </summary>
        Custom1 = 7,
        /// <summary>
        /// <para>Array is a custom data array for the third set of custom data.</para>
        /// </summary>
        Custom2 = 8,
        /// <summary>
        /// <para>Array is a custom data array for the fourth set of custom data.</para>
        /// </summary>
        Custom3 = 9,
        /// <summary>
        /// <para>Array contains bone information.</para>
        /// </summary>
        Bones = 10,
        /// <summary>
        /// <para>Array is weight information.</para>
        /// </summary>
        Weights = 11,
        /// <summary>
        /// <para>Array is an index array.</para>
        /// </summary>
        Index = 12,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ArrayType"/> enum.</para>
        /// </summary>
        Max = 13
    }

    public enum ArrayCustomFormat : long
    {
        /// <summary>
        /// <para>Custom data array contains 8-bit-per-channel red/green/blue/alpha color data. Values are normalized, unsigned floating-point in the <c>[0.0, 1.0]</c> range.</para>
        /// </summary>
        Rgba8Unorm = 0,
        /// <summary>
        /// <para>Custom data array contains 8-bit-per-channel red/green/blue/alpha color data. Values are normalized, signed floating-point in the <c>[-1.0, 1.0]</c> range.</para>
        /// </summary>
        Rgba8Snorm = 1,
        /// <summary>
        /// <para>Custom data array contains 16-bit-per-channel red/green color data. Values are floating-point in half precision.</para>
        /// </summary>
        RgHalf = 2,
        /// <summary>
        /// <para>Custom data array contains 16-bit-per-channel red/green/blue/alpha color data. Values are floating-point in half precision.</para>
        /// </summary>
        RgbaHalf = 3,
        /// <summary>
        /// <para>Custom data array contains 32-bit-per-channel red color data. Values are floating-point in single precision.</para>
        /// </summary>
        RFloat = 4,
        /// <summary>
        /// <para>Custom data array contains 32-bit-per-channel red/green color data. Values are floating-point in single precision.</para>
        /// </summary>
        RgFloat = 5,
        /// <summary>
        /// <para>Custom data array contains 32-bit-per-channel red/green/blue color data. Values are floating-point in single precision.</para>
        /// </summary>
        RgbFloat = 6,
        /// <summary>
        /// <para>Custom data array contains 32-bit-per-channel red/green/blue/alpha color data. Values are floating-point in single precision.</para>
        /// </summary>
        RgbaFloat = 7,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ArrayCustomFormat"/> enum.</para>
        /// </summary>
        Max = 8
    }

    [System.Flags]
    public enum ArrayFormat : long
    {
        /// <summary>
        /// <para>Flag used to mark a vertex position array.</para>
        /// </summary>
        FormatVertex = 1,
        /// <summary>
        /// <para>Flag used to mark a normal array.</para>
        /// </summary>
        FormatNormal = 2,
        /// <summary>
        /// <para>Flag used to mark a tangent array.</para>
        /// </summary>
        FormatTangent = 4,
        /// <summary>
        /// <para>Flag used to mark a vertex color array.</para>
        /// </summary>
        FormatColor = 8,
        /// <summary>
        /// <para>Flag used to mark a UV coordinates array.</para>
        /// </summary>
        FormatTexUV = 16,
        /// <summary>
        /// <para>Flag used to mark a UV coordinates array for the second UV coordinates.</para>
        /// </summary>
        FormatTexUV2 = 32,
        /// <summary>
        /// <para>Flag used to mark an array of custom per-vertex data for the first set of custom data.</para>
        /// </summary>
        FormatCustom0 = 64,
        /// <summary>
        /// <para>Flag used to mark an array of custom per-vertex data for the second set of custom data.</para>
        /// </summary>
        FormatCustom1 = 128,
        /// <summary>
        /// <para>Flag used to mark an array of custom per-vertex data for the third set of custom data.</para>
        /// </summary>
        FormatCustom2 = 256,
        /// <summary>
        /// <para>Flag used to mark an array of custom per-vertex data for the fourth set of custom data.</para>
        /// </summary>
        FormatCustom3 = 512,
        /// <summary>
        /// <para>Flag used to mark a bone information array.</para>
        /// </summary>
        FormatBones = 1024,
        /// <summary>
        /// <para>Flag used to mark a weights array.</para>
        /// </summary>
        FormatWeights = 2048,
        /// <summary>
        /// <para>Flag used to mark an index array.</para>
        /// </summary>
        FormatIndex = 4096,
        /// <summary>
        /// <para>Mask of mesh channels permitted in blend shapes.</para>
        /// </summary>
        FormatBlendShapeMask = 7,
        /// <summary>
        /// <para>Shift of first custom channel.</para>
        /// </summary>
        FormatCustomBase = 13,
        /// <summary>
        /// <para>Number of format bits per custom channel. See <see cref="Godot.RenderingServer.ArrayCustomFormat"/>.</para>
        /// </summary>
        FormatCustomBits = 3,
        /// <summary>
        /// <para>Amount to shift <see cref="Godot.RenderingServer.ArrayCustomFormat"/> for custom channel index 0.</para>
        /// </summary>
        FormatCustom0Shift = 13,
        /// <summary>
        /// <para>Amount to shift <see cref="Godot.RenderingServer.ArrayCustomFormat"/> for custom channel index 1.</para>
        /// </summary>
        FormatCustom1Shift = 16,
        /// <summary>
        /// <para>Amount to shift <see cref="Godot.RenderingServer.ArrayCustomFormat"/> for custom channel index 2.</para>
        /// </summary>
        FormatCustom2Shift = 19,
        /// <summary>
        /// <para>Amount to shift <see cref="Godot.RenderingServer.ArrayCustomFormat"/> for custom channel index 3.</para>
        /// </summary>
        FormatCustom3Shift = 22,
        /// <summary>
        /// <para>Mask of custom format bits per custom channel. Must be shifted by one of the SHIFT constants. See <see cref="Godot.RenderingServer.ArrayCustomFormat"/>.</para>
        /// </summary>
        FormatCustomMask = 7,
        /// <summary>
        /// <para>Shift of first compress flag. Compress flags should be passed to <see cref="Godot.ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Mesh.ArrayFormat)"/> and <see cref="Godot.SurfaceTool.Commit(ArrayMesh, ulong)"/>.</para>
        /// </summary>
        CompressFlagsBase = 25,
        /// <summary>
        /// <para>Flag used to mark that the array contains 2D vertices.</para>
        /// </summary>
        FlagUse2DVertices = 33554432,
        /// <summary>
        /// <para>Flag used to mark that the mesh data will use <c>GL_DYNAMIC_DRAW</c> on GLES. Unused on Vulkan.</para>
        /// </summary>
        FlagUseDynamicUpdate = 67108864,
        /// <summary>
        /// <para>Flag used to mark that the array uses 8 bone weights instead of 4.</para>
        /// </summary>
        FlagUse8BoneWeights = 134217728,
        /// <summary>
        /// <para>Flag used to mark that the mesh does not have a vertex array and instead will infer vertex positions in the shader using indices and other information.</para>
        /// </summary>
        FlagUsesEmptyVertexArray = 268435456,
        /// <summary>
        /// <para>Flag used to mark that a mesh is using compressed attributes (vertices, normals, tangents, UVs). When this form of compression is enabled, vertex positions will be packed into an RGBA16UNORM attribute and scaled in the vertex shader. The normal and tangent will be packed into an RG16UNORM representing an axis, and a 16-bit float stored in the A-channel of the vertex. UVs will use 16-bit normalized floats instead of full 32-bit signed floats. When using this compression mode you must use either vertices, normals, and tangents or only vertices. You cannot use normals without tangents. Importers will automatically enable this compression if they can.</para>
        /// </summary>
        FlagCompressAttributes = 536870912,
        /// <summary>
        /// <para>Flag used to mark the start of the bits used to store the mesh version.</para>
        /// </summary>
        FlagFormatVersionBase = 35,
        /// <summary>
        /// <para>Flag used to shift a mesh format int to bring the version into the lowest digits.</para>
        /// </summary>
        FlagFormatVersionShift = 35,
        /// <summary>
        /// <para>Flag used to record the format used by prior mesh versions before the introduction of a version.</para>
        /// </summary>
        FlagFormatVersion1 = 0,
        /// <summary>
        /// <para>Flag used to record the second iteration of the mesh version flag. The primary difference between this and <see cref="Godot.RenderingServer.ArrayFormat.FlagFormatVersion1"/> is that this version supports <see cref="Godot.RenderingServer.ArrayFormat.FlagCompressAttributes"/> and in this version vertex positions are de-interleaved from normals and tangents.</para>
        /// </summary>
        FlagFormatVersion2 = 34359738368,
        /// <summary>
        /// <para>Flag used to record the current version that the engine expects. Currently this is the same as <see cref="Godot.RenderingServer.ArrayFormat.FlagFormatVersion2"/>.</para>
        /// </summary>
        FlagFormatCurrentVersion = 34359738368,
        /// <summary>
        /// <para>Flag used to isolate the bits used for mesh version after using <see cref="Godot.RenderingServer.ArrayFormat.FlagFormatVersionShift"/> to shift them into place.</para>
        /// </summary>
        FlagFormatVersionMask = 255
    }

    public enum PrimitiveType : long
    {
        /// <summary>
        /// <para>Primitive to draw consists of points.</para>
        /// </summary>
        Points = 0,
        /// <summary>
        /// <para>Primitive to draw consists of lines.</para>
        /// </summary>
        Lines = 1,
        /// <summary>
        /// <para>Primitive to draw consists of a line strip from start to end.</para>
        /// </summary>
        LineStrip = 2,
        /// <summary>
        /// <para>Primitive to draw consists of triangles.</para>
        /// </summary>
        Triangles = 3,
        /// <summary>
        /// <para>Primitive to draw consists of a triangle strip (the last 3 vertices are always combined to make a triangle).</para>
        /// </summary>
        TriangleStrip = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.PrimitiveType"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum BlendShapeMode : long
    {
        /// <summary>
        /// <para>Blend shapes are normalized.</para>
        /// </summary>
        Normalized = 0,
        /// <summary>
        /// <para>Blend shapes are relative to base weight.</para>
        /// </summary>
        Relative = 1
    }

    public enum MultimeshTransformFormat : long
    {
        /// <summary>
        /// <para>Use <see cref="Godot.Transform2D"/> to store MultiMesh transform.</para>
        /// </summary>
        Transform2D = 0,
        /// <summary>
        /// <para>Use <see cref="Godot.Transform3D"/> to store MultiMesh transform.</para>
        /// </summary>
        Transform3D = 1
    }

    public enum MultimeshPhysicsInterpolationQuality : long
    {
        /// <summary>
        /// <para>MultiMesh physics interpolation favors speed over quality.</para>
        /// </summary>
        Fast = 0,
        /// <summary>
        /// <para>MultiMesh physics interpolation favors quality over speed.</para>
        /// </summary>
        High = 1
    }

    public enum LightProjectorFilter : long
    {
        /// <summary>
        /// <para>Nearest-neighbor filter for light projectors (use for pixel art light projectors). No mipmaps are used for rendering, which means light projectors at a distance will look sharp but grainy. This has roughly the same performance cost as using mipmaps.</para>
        /// </summary>
        Nearest = 0,
        /// <summary>
        /// <para>Linear filter for light projectors (use for non-pixel art light projectors). No mipmaps are used for rendering, which means light projectors at a distance will look smooth but blurry. This has roughly the same performance cost as using mipmaps.</para>
        /// </summary>
        Linear = 1,
        /// <summary>
        /// <para>Nearest-neighbor filter for light projectors (use for pixel art light projectors). Isotropic mipmaps are used for rendering, which means light projectors at a distance will look smooth but blurry. This has roughly the same performance cost as not using mipmaps.</para>
        /// </summary>
        NearestMipmaps = 2,
        /// <summary>
        /// <para>Linear filter for light projectors (use for non-pixel art light projectors). Isotropic mipmaps are used for rendering, which means light projectors at a distance will look smooth but blurry. This has roughly the same performance cost as not using mipmaps.</para>
        /// </summary>
        LinearMipmaps = 3,
        /// <summary>
        /// <para>Nearest-neighbor filter for light projectors (use for pixel art light projectors). Anisotropic mipmaps are used for rendering, which means light projectors at a distance will look smooth and sharp when viewed from oblique angles. This looks better compared to isotropic mipmaps, but is slower. The level of anisotropic filtering is defined by <c>ProjectSettings.rendering/textures/default_filters/anisotropic_filtering_level</c>.</para>
        /// </summary>
        NearestMipmapsAnisotropic = 4,
        /// <summary>
        /// <para>Linear filter for light projectors (use for non-pixel art light projectors). Anisotropic mipmaps are used for rendering, which means light projectors at a distance will look smooth and sharp when viewed from oblique angles. This looks better compared to isotropic mipmaps, but is slower. The level of anisotropic filtering is defined by <c>ProjectSettings.rendering/textures/default_filters/anisotropic_filtering_level</c>.</para>
        /// </summary>
        LinearMipmapsAnisotropic = 5
    }

    public enum LightType : long
    {
        /// <summary>
        /// <para>Directional (sun/moon) light (see <see cref="Godot.DirectionalLight3D"/>).</para>
        /// </summary>
        Directional = 0,
        /// <summary>
        /// <para>Omni light (see <see cref="Godot.OmniLight3D"/>).</para>
        /// </summary>
        Omni = 1,
        /// <summary>
        /// <para>Spot light (see <see cref="Godot.SpotLight3D"/>).</para>
        /// </summary>
        Spot = 2
    }

    public enum LightParam : long
    {
        /// <summary>
        /// <para>The light's energy multiplier.</para>
        /// </summary>
        Energy = 0,
        /// <summary>
        /// <para>The light's indirect energy multiplier (final indirect energy is <see cref="Godot.RenderingServer.LightParam.Energy"/> * <see cref="Godot.RenderingServer.LightParam.IndirectEnergy"/>).</para>
        /// </summary>
        IndirectEnergy = 1,
        /// <summary>
        /// <para>The light's volumetric fog energy multiplier (final volumetric fog energy is <see cref="Godot.RenderingServer.LightParam.Energy"/> * <see cref="Godot.RenderingServer.LightParam.VolumetricFogEnergy"/>).</para>
        /// </summary>
        VolumetricFogEnergy = 2,
        /// <summary>
        /// <para>The light's influence on specularity.</para>
        /// </summary>
        Specular = 3,
        /// <summary>
        /// <para>The light's range.</para>
        /// </summary>
        Range = 4,
        /// <summary>
        /// <para>The size of the light when using spot light or omni light. The angular size of the light when using directional light.</para>
        /// </summary>
        Size = 5,
        /// <summary>
        /// <para>The light's attenuation.</para>
        /// </summary>
        Attenuation = 6,
        /// <summary>
        /// <para>The spotlight's angle.</para>
        /// </summary>
        SpotAngle = 7,
        /// <summary>
        /// <para>The spotlight's attenuation.</para>
        /// </summary>
        SpotAttenuation = 8,
        /// <summary>
        /// <para>The maximum distance for shadow splits. Increasing this value will make directional shadows visible from further away, at the cost of lower overall shadow detail and performance (since more objects need to be included in the directional shadow rendering).</para>
        /// </summary>
        ShadowMaxDistance = 9,
        /// <summary>
        /// <para>Proportion of shadow atlas occupied by the first split.</para>
        /// </summary>
        ShadowSplit1Offset = 10,
        /// <summary>
        /// <para>Proportion of shadow atlas occupied by the second split.</para>
        /// </summary>
        ShadowSplit2Offset = 11,
        /// <summary>
        /// <para>Proportion of shadow atlas occupied by the third split. The fourth split occupies the rest.</para>
        /// </summary>
        ShadowSplit3Offset = 12,
        /// <summary>
        /// <para>Proportion of shadow max distance where the shadow will start to fade out.</para>
        /// </summary>
        ShadowFadeStart = 13,
        /// <summary>
        /// <para>Normal bias used to offset shadow lookup by object normal. Can be used to fix self-shadowing artifacts.</para>
        /// </summary>
        ShadowNormalBias = 14,
        /// <summary>
        /// <para>Bias for the shadow lookup to fix self-shadowing artifacts.</para>
        /// </summary>
        ShadowBias = 15,
        /// <summary>
        /// <para>Sets the size of the directional shadow pancake. The pancake offsets the start of the shadow's camera frustum to provide a higher effective depth resolution for the shadow. However, a high pancake size can cause artifacts in the shadows of large objects that are close to the edge of the frustum. Reducing the pancake size can help. Setting the size to <c>0</c> turns off the pancaking effect.</para>
        /// </summary>
        ShadowPancakeSize = 16,
        /// <summary>
        /// <para>The light's shadow opacity. Values lower than <c>1.0</c> make the light appear through shadows. This can be used to fake global illumination at a low performance cost.</para>
        /// </summary>
        ShadowOpacity = 17,
        /// <summary>
        /// <para>Blurs the edges of the shadow. Can be used to hide pixel artifacts in low resolution shadow maps. A high value can make shadows appear grainy and can cause other unwanted artifacts. Try to keep as near default as possible.</para>
        /// </summary>
        ShadowBlur = 18,
        TransmittanceBias = 19,
        /// <summary>
        /// <para>Constant representing the intensity of the light, measured in Lumens when dealing with a <see cref="Godot.SpotLight3D"/> or <see cref="Godot.OmniLight3D"/>, or measured in Lux with a <see cref="Godot.DirectionalLight3D"/>. Only used when <c>ProjectSettings.rendering/lights_and_shadows/use_physical_light_units</c> is <see langword="true"/>.</para>
        /// </summary>
        Intensity = 20,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.LightParam"/> enum.</para>
        /// </summary>
        Max = 21
    }

    public enum LightBakeMode : long
    {
        /// <summary>
        /// <para>Light is ignored when baking. This is the fastest mode, but the light will be taken into account when baking global illumination. This mode should generally be used for dynamic lights that change quickly, as the effect of global illumination is less noticeable on those lights.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Light is taken into account in static baking (<see cref="Godot.VoxelGI"/>, <see cref="Godot.LightmapGI"/>, SDFGI (<see cref="Godot.Environment.SdfgiEnabled"/>)). The light can be moved around or modified, but its global illumination will not update in real-time. This is suitable for subtle changes (such as flickering torches), but generally not large changes such as toggling a light on and off.</para>
        /// </summary>
        Static = 1,
        /// <summary>
        /// <para>Light is taken into account in dynamic baking (<see cref="Godot.VoxelGI"/> and SDFGI (<see cref="Godot.Environment.SdfgiEnabled"/>) only). The light can be moved around or modified with global illumination updating in real-time. The light's global illumination appearance will be slightly different compared to <see cref="Godot.RenderingServer.LightBakeMode.Static"/>. This has a greater performance cost compared to <see cref="Godot.RenderingServer.LightBakeMode.Static"/>. When using SDFGI, the update speed of dynamic lights is affected by <c>ProjectSettings.rendering/global_illumination/sdfgi/frames_to_update_lights</c>.</para>
        /// </summary>
        Dynamic = 2
    }

    public enum LightOmniShadowMode : long
    {
        /// <summary>
        /// <para>Use a dual paraboloid shadow map for omni lights.</para>
        /// </summary>
        DualParaboloid = 0,
        /// <summary>
        /// <para>Use a cubemap shadow map for omni lights. Slower but better quality than dual paraboloid.</para>
        /// </summary>
        Cube = 1
    }

    public enum LightDirectionalShadowMode : long
    {
        /// <summary>
        /// <para>Use orthogonal shadow projection for directional light.</para>
        /// </summary>
        Orthogonal = 0,
        /// <summary>
        /// <para>Use 2 splits for shadow projection when using directional light.</para>
        /// </summary>
        Parallel2Splits = 1,
        /// <summary>
        /// <para>Use 4 splits for shadow projection when using directional light.</para>
        /// </summary>
        Parallel4Splits = 2
    }

    public enum LightDirectionalSkyMode : long
    {
        /// <summary>
        /// <para>Use DirectionalLight3D in both sky rendering and scene lighting.</para>
        /// </summary>
        LightAndSky = 0,
        /// <summary>
        /// <para>Only use DirectionalLight3D in scene lighting.</para>
        /// </summary>
        LightOnly = 1,
        /// <summary>
        /// <para>Only use DirectionalLight3D in sky rendering.</para>
        /// </summary>
        SkyOnly = 2
    }

    public enum ShadowQuality : long
    {
        /// <summary>
        /// <para>Lowest shadow filtering quality (fastest). Soft shadows are not available with this quality setting, which means the <see cref="Godot.Light3D.ShadowBlur"/> property is ignored if <see cref="Godot.Light3D.LightSize"/> and <see cref="Godot.Light3D.LightAngularDistance"/> is <c>0.0</c>.</para>
        /// <para><b>Note:</b> The variable shadow blur performed by <see cref="Godot.Light3D.LightSize"/> and <see cref="Godot.Light3D.LightAngularDistance"/> is still effective when using hard shadow filtering. In this case, <see cref="Godot.Light3D.ShadowBlur"/> <i>is</i> taken into account. However, the results will not be blurred, instead the blur amount is treated as a maximum radius for the penumbra.</para>
        /// </summary>
        Hard = 0,
        /// <summary>
        /// <para>Very low shadow filtering quality (faster). When using this quality setting, <see cref="Godot.Light3D.ShadowBlur"/> is automatically multiplied by 0.75× to avoid introducing too much noise. This division only applies to lights whose <see cref="Godot.Light3D.LightSize"/> or <see cref="Godot.Light3D.LightAngularDistance"/> is <c>0.0</c>).</para>
        /// </summary>
        SoftVeryLow = 1,
        /// <summary>
        /// <para>Low shadow filtering quality (fast).</para>
        /// </summary>
        SoftLow = 2,
        /// <summary>
        /// <para>Medium low shadow filtering quality (average).</para>
        /// </summary>
        SoftMedium = 3,
        /// <summary>
        /// <para>High low shadow filtering quality (slow). When using this quality setting, <see cref="Godot.Light3D.ShadowBlur"/> is automatically multiplied by 1.5× to better make use of the high sample count. This increased blur also improves the stability of dynamic object shadows. This multiplier only applies to lights whose <see cref="Godot.Light3D.LightSize"/> or <see cref="Godot.Light3D.LightAngularDistance"/> is <c>0.0</c>).</para>
        /// </summary>
        SoftHigh = 4,
        /// <summary>
        /// <para>Highest low shadow filtering quality (slowest). When using this quality setting, <see cref="Godot.Light3D.ShadowBlur"/> is automatically multiplied by 2× to better make use of the high sample count. This increased blur also improves the stability of dynamic object shadows. This multiplier only applies to lights whose <see cref="Godot.Light3D.LightSize"/> or <see cref="Godot.Light3D.LightAngularDistance"/> is <c>0.0</c>).</para>
        /// </summary>
        SoftUltra = 5,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ShadowQuality"/> enum.</para>
        /// </summary>
        Max = 6
    }

    public enum ReflectionProbeUpdateMode : long
    {
        /// <summary>
        /// <para>Reflection probe will update reflections once and then stop.</para>
        /// </summary>
        Once = 0,
        /// <summary>
        /// <para>Reflection probe will update each frame. This mode is necessary to capture moving objects.</para>
        /// </summary>
        Always = 1
    }

    public enum ReflectionProbeAmbientMode : long
    {
        /// <summary>
        /// <para>Do not apply any ambient lighting inside the reflection probe's box defined by its size.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Apply automatically-sourced environment lighting inside the reflection probe's box defined by its size.</para>
        /// </summary>
        Environment = 1,
        /// <summary>
        /// <para>Apply custom ambient lighting inside the reflection probe's box defined by its size. See <see cref="Godot.RenderingServer.ReflectionProbeSetAmbientColor(Rid, Color)"/> and <see cref="Godot.RenderingServer.ReflectionProbeSetAmbientEnergy(Rid, float)"/>.</para>
        /// </summary>
        Color = 2
    }

    public enum DecalTexture : long
    {
        /// <summary>
        /// <para>Albedo texture slot in a decal (<see cref="Godot.Decal.TextureAlbedo"/>).</para>
        /// </summary>
        Albedo = 0,
        /// <summary>
        /// <para>Normal map texture slot in a decal (<see cref="Godot.Decal.TextureNormal"/>).</para>
        /// </summary>
        Normal = 1,
        /// <summary>
        /// <para>Occlusion/Roughness/Metallic texture slot in a decal (<see cref="Godot.Decal.TextureOrm"/>).</para>
        /// </summary>
        Orm = 2,
        /// <summary>
        /// <para>Emission texture slot in a decal (<see cref="Godot.Decal.TextureEmission"/>).</para>
        /// </summary>
        Emission = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.DecalTexture"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum DecalFilter : long
    {
        /// <summary>
        /// <para>Nearest-neighbor filter for decals (use for pixel art decals). No mipmaps are used for rendering, which means decals at a distance will look sharp but grainy. This has roughly the same performance cost as using mipmaps.</para>
        /// </summary>
        Nearest = 0,
        /// <summary>
        /// <para>Linear filter for decals (use for non-pixel art decals). No mipmaps are used for rendering, which means decals at a distance will look smooth but blurry. This has roughly the same performance cost as using mipmaps.</para>
        /// </summary>
        Linear = 1,
        /// <summary>
        /// <para>Nearest-neighbor filter for decals (use for pixel art decals). Isotropic mipmaps are used for rendering, which means decals at a distance will look smooth but blurry. This has roughly the same performance cost as not using mipmaps.</para>
        /// </summary>
        NearestMipmaps = 2,
        /// <summary>
        /// <para>Linear filter for decals (use for non-pixel art decals). Isotropic mipmaps are used for rendering, which means decals at a distance will look smooth but blurry. This has roughly the same performance cost as not using mipmaps.</para>
        /// </summary>
        LinearMipmaps = 3,
        /// <summary>
        /// <para>Nearest-neighbor filter for decals (use for pixel art decals). Anisotropic mipmaps are used for rendering, which means decals at a distance will look smooth and sharp when viewed from oblique angles. This looks better compared to isotropic mipmaps, but is slower. The level of anisotropic filtering is defined by <c>ProjectSettings.rendering/textures/default_filters/anisotropic_filtering_level</c>.</para>
        /// </summary>
        NearestMipmapsAnisotropic = 4,
        /// <summary>
        /// <para>Linear filter for decals (use for non-pixel art decals). Anisotropic mipmaps are used for rendering, which means decals at a distance will look smooth and sharp when viewed from oblique angles. This looks better compared to isotropic mipmaps, but is slower. The level of anisotropic filtering is defined by <c>ProjectSettings.rendering/textures/default_filters/anisotropic_filtering_level</c>.</para>
        /// </summary>
        LinearMipmapsAnisotropic = 5
    }

    public enum VoxelGIQuality : long
    {
        /// <summary>
        /// <para>Low <see cref="Godot.VoxelGI"/> rendering quality using 4 cones.</para>
        /// </summary>
        Low = 0,
        /// <summary>
        /// <para>High <see cref="Godot.VoxelGI"/> rendering quality using 6 cones.</para>
        /// </summary>
        High = 1
    }

    public enum ParticlesMode : long
    {
        /// <summary>
        /// <para>2D particles.</para>
        /// </summary>
        Mode2D = 0,
        /// <summary>
        /// <para>3D particles.</para>
        /// </summary>
        Mode3D = 1
    }

    public enum ParticlesTransformAlign : long
    {
        Disabled = 0,
        ZBillboard = 1,
        YToVelocity = 2,
        ZBillboardYToVelocity = 3
    }

    public enum ParticlesDrawOrder : long
    {
        /// <summary>
        /// <para>Draw particles in the order that they appear in the particles array.</para>
        /// </summary>
        Index = 0,
        /// <summary>
        /// <para>Sort particles based on their lifetime. In other words, the particle with the highest lifetime is drawn at the front.</para>
        /// </summary>
        Lifetime = 1,
        /// <summary>
        /// <para>Sort particles based on the inverse of their lifetime. In other words, the particle with the lowest lifetime is drawn at the front.</para>
        /// </summary>
        ReverseLifetime = 2,
        /// <summary>
        /// <para>Sort particles based on their distance to the camera.</para>
        /// </summary>
        ViewDepth = 3
    }

    public enum ParticlesCollisionType : long
    {
        SphereAttract = 0,
        BoxAttract = 1,
        VectorFieldAttract = 2,
        SphereCollide = 3,
        BoxCollide = 4,
        SdfCollide = 5,
        HeightfieldCollide = 6
    }

    public enum ParticlesCollisionHeightfieldResolution : long
    {
        Resolution256 = 0,
        Resolution512 = 1,
        Resolution1024 = 2,
        Resolution2048 = 3,
        Resolution4096 = 4,
        Resolution8192 = 5,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ParticlesCollisionHeightfieldResolution"/> enum.</para>
        /// </summary>
        Max = 6
    }

    public enum FogVolumeShape : long
    {
        /// <summary>
        /// <para><see cref="Godot.FogVolume"/> will be shaped like an ellipsoid (stretched sphere).</para>
        /// </summary>
        Ellipsoid = 0,
        /// <summary>
        /// <para><see cref="Godot.FogVolume"/> will be shaped like a cone pointing upwards (in local coordinates). The cone's angle is set automatically to fill the size. The cone will be adjusted to fit within the size. Rotate the <see cref="Godot.FogVolume"/> node to reorient the cone. Non-uniform scaling via size is not supported (scale the <see cref="Godot.FogVolume"/> node instead).</para>
        /// </summary>
        Cone = 1,
        /// <summary>
        /// <para><see cref="Godot.FogVolume"/> will be shaped like an upright cylinder (in local coordinates). Rotate the <see cref="Godot.FogVolume"/> node to reorient the cylinder. The cylinder will be adjusted to fit within the size. Non-uniform scaling via size is not supported (scale the <see cref="Godot.FogVolume"/> node instead).</para>
        /// </summary>
        Cylinder = 2,
        /// <summary>
        /// <para><see cref="Godot.FogVolume"/> will be shaped like a box.</para>
        /// </summary>
        Box = 3,
        /// <summary>
        /// <para><see cref="Godot.FogVolume"/> will have no shape, will cover the whole world and will not be culled.</para>
        /// </summary>
        World = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.FogVolumeShape"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum ViewportScaling3DMode : long
    {
        /// <summary>
        /// <para>Use bilinear scaling for the viewport's 3D buffer. The amount of scaling can be set using <see cref="Godot.Viewport.Scaling3DScale"/>. Values less than <c>1.0</c> will result in undersampling while values greater than <c>1.0</c> will result in supersampling. A value of <c>1.0</c> disables scaling.</para>
        /// </summary>
        Bilinear = 0,
        /// <summary>
        /// <para>Use AMD FidelityFX Super Resolution 1.0 upscaling for the viewport's 3D buffer. The amount of scaling can be set using <see cref="Godot.Viewport.Scaling3DScale"/>. Values less than <c>1.0</c> will result in the viewport being upscaled using FSR. Values greater than <c>1.0</c> are not supported and bilinear downsampling will be used instead. A value of <c>1.0</c> disables scaling.</para>
        /// </summary>
        Fsr = 1,
        /// <summary>
        /// <para>Use AMD FidelityFX Super Resolution 2.2 upscaling for the viewport's 3D buffer. The amount of scaling can be set using <see cref="Godot.Viewport.Scaling3DScale"/>. Values less than <c>1.0</c> will result in the viewport being upscaled using FSR2. Values greater than <c>1.0</c> are not supported and bilinear downsampling will be used instead. A value of <c>1.0</c> will use FSR2 at native resolution as a TAA solution.</para>
        /// </summary>
        Fsr2 = 2,
        /// <summary>
        /// <para>Use MetalFX spatial upscaling for the viewport's 3D buffer. The amount of scaling can be set using <see cref="Godot.Viewport.Scaling3DScale"/>. Values less than <c>1.0</c> will result in the viewport being upscaled using MetalFX. Values greater than <c>1.0</c> are not supported and bilinear downsampling will be used instead. A value of <c>1.0</c> disables scaling.</para>
        /// <para><b>Note:</b> Only supported when the Metal rendering driver is in use, which limits this scaling mode to macOS and iOS.</para>
        /// </summary>
        MetalfxSpatial = 3,
        /// <summary>
        /// <para>Use MetalFX temporal upscaling for the viewport's 3D buffer. The amount of scaling can be set using <see cref="Godot.Viewport.Scaling3DScale"/>. Values less than <c>1.0</c> will result in the viewport being upscaled using MetalFX. Values greater than <c>1.0</c> are not supported and bilinear downsampling will be used instead. A value of <c>1.0</c> will use MetalFX at native resolution as a TAA solution.</para>
        /// <para><b>Note:</b> Only supported when the Metal rendering driver is in use, which limits this scaling mode to macOS and iOS.</para>
        /// </summary>
        MetalfxTemporal = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportScaling3DMode"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum ViewportUpdateMode : long
    {
        /// <summary>
        /// <para>Do not update the viewport's render target.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Update the viewport's render target once, then switch to <see cref="Godot.RenderingServer.ViewportUpdateMode.Disabled"/>.</para>
        /// </summary>
        Once = 1,
        /// <summary>
        /// <para>Update the viewport's render target only when it is visible. This is the default value.</para>
        /// </summary>
        WhenVisible = 2,
        /// <summary>
        /// <para>Update the viewport's render target only when its parent is visible.</para>
        /// </summary>
        WhenParentVisible = 3,
        /// <summary>
        /// <para>Always update the viewport's render target.</para>
        /// </summary>
        Always = 4
    }

    public enum ViewportClearMode : long
    {
        /// <summary>
        /// <para>Always clear the viewport's render target before drawing.</para>
        /// </summary>
        Always = 0,
        /// <summary>
        /// <para>Never clear the viewport's render target.</para>
        /// </summary>
        Never = 1,
        /// <summary>
        /// <para>Clear the viewport's render target on the next frame, then switch to <see cref="Godot.RenderingServer.ViewportClearMode.Never"/>.</para>
        /// </summary>
        OnlyNextFrame = 2
    }

    public enum ViewportEnvironmentMode : long
    {
        /// <summary>
        /// <para>Disable rendering of 3D environment over 2D canvas.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Enable rendering of 3D environment over 2D canvas.</para>
        /// </summary>
        Enabled = 1,
        /// <summary>
        /// <para>Inherit enable/disable value from parent. If the topmost parent is also set to <see cref="Godot.RenderingServer.ViewportEnvironmentMode.Inherit"/>, then this has the same behavior as <see cref="Godot.RenderingServer.ViewportEnvironmentMode.Enabled"/>.</para>
        /// </summary>
        Inherit = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportEnvironmentMode"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum ViewportSdfOversize : long
    {
        /// <summary>
        /// <para>Do not oversize the 2D signed distance field. Occluders may disappear when touching the viewport's edges, and <see cref="Godot.GpuParticles3D"/> collision may stop working earlier than intended. This has the lowest GPU requirements.</para>
        /// </summary>
        Oversize100Percent = 0,
        /// <summary>
        /// <para>2D signed distance field covers 20% of the viewport's size outside the viewport on each side (top, right, bottom, left).</para>
        /// </summary>
        Oversize120Percent = 1,
        /// <summary>
        /// <para>2D signed distance field covers 50% of the viewport's size outside the viewport on each side (top, right, bottom, left).</para>
        /// </summary>
        Oversize150Percent = 2,
        /// <summary>
        /// <para>2D signed distance field covers 100% of the viewport's size outside the viewport on each side (top, right, bottom, left). This has the highest GPU requirements.</para>
        /// </summary>
        Oversize200Percent = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportSdfOversize"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum ViewportSdfScale : long
    {
        /// <summary>
        /// <para>Full resolution 2D signed distance field scale. This has the highest GPU requirements.</para>
        /// </summary>
        Scale100Percent = 0,
        /// <summary>
        /// <para>Half resolution 2D signed distance field scale on each axis (25% of the viewport pixel count).</para>
        /// </summary>
        Scale50Percent = 1,
        /// <summary>
        /// <para>Quarter resolution 2D signed distance field scale on each axis (6.25% of the viewport pixel count). This has the lowest GPU requirements.</para>
        /// </summary>
        Scale25Percent = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportSdfScale"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum ViewportMsaa : long
    {
        /// <summary>
        /// <para>Multisample antialiasing for 3D is disabled. This is the default value, and also the fastest setting.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Multisample antialiasing uses 2 samples per pixel for 3D. This has a moderate impact on performance.</para>
        /// </summary>
        Msaa2X = 1,
        /// <summary>
        /// <para>Multisample antialiasing uses 4 samples per pixel for 3D. This has a high impact on performance.</para>
        /// </summary>
        Msaa4X = 2,
        /// <summary>
        /// <para>Multisample antialiasing uses 8 samples per pixel for 3D. This has a very high impact on performance. Likely unsupported on low-end and older hardware.</para>
        /// </summary>
        Msaa8X = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportMsaa"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum ViewportAnisotropicFiltering : long
    {
        /// <summary>
        /// <para>Anisotropic filtering is disabled.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Use 2× anisotropic filtering.</para>
        /// </summary>
        Anisotropy2X = 1,
        /// <summary>
        /// <para>Use 4× anisotropic filtering. This is the default value.</para>
        /// </summary>
        Anisotropy4X = 2,
        /// <summary>
        /// <para>Use 8× anisotropic filtering.</para>
        /// </summary>
        Anisotropy8X = 3,
        /// <summary>
        /// <para>Use 16× anisotropic filtering.</para>
        /// </summary>
        Anisotropy16X = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportAnisotropicFiltering"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum ViewportScreenSpaceAA : long
    {
        /// <summary>
        /// <para>Do not perform any antialiasing in the full screen post-process.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Use fast approximate antialiasing. FXAA is a popular screen-space antialiasing method, which is fast but will make the image look blurry, especially at lower resolutions. It can still work relatively well at large resolutions such as 1440p and 4K.</para>
        /// </summary>
        Fxaa = 1,
        /// <summary>
        /// <para>Use subpixel morphological antialiasing. SMAA may produce clearer results than FXAA, but at a slightly higher performance cost.</para>
        /// </summary>
        Smaa = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportScreenSpaceAA"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum ViewportOcclusionCullingBuildQuality : long
    {
        /// <summary>
        /// <para>Low occlusion culling BVH build quality (as defined by Embree). Results in the lowest CPU usage, but least effective culling.</para>
        /// </summary>
        Low = 0,
        /// <summary>
        /// <para>Medium occlusion culling BVH build quality (as defined by Embree).</para>
        /// </summary>
        Medium = 1,
        /// <summary>
        /// <para>High occlusion culling BVH build quality (as defined by Embree). Results in the highest CPU usage, but most effective culling.</para>
        /// </summary>
        High = 2
    }

    public enum ViewportRenderInfo : long
    {
        /// <summary>
        /// <para>Number of objects drawn in a single frame.</para>
        /// </summary>
        ObjectsInFrame = 0,
        /// <summary>
        /// <para>Number of points, lines, or triangles drawn in a single frame.</para>
        /// </summary>
        PrimitivesInFrame = 1,
        /// <summary>
        /// <para>Number of draw calls during this frame.</para>
        /// </summary>
        DrawCallsInFrame = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportRenderInfo"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum ViewportRenderInfoType : long
    {
        /// <summary>
        /// <para>Visible render pass (excluding shadows).</para>
        /// </summary>
        Visible = 0,
        /// <summary>
        /// <para>Shadow render pass. Objects will be rendered several times depending on the number of amounts of lights with shadows and the number of directional shadow splits.</para>
        /// </summary>
        Shadow = 1,
        /// <summary>
        /// <para>Canvas item rendering. This includes all 2D rendering.</para>
        /// </summary>
        Canvas = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportRenderInfoType"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum ViewportDebugDraw : long
    {
        /// <summary>
        /// <para>Debug draw is disabled. Default setting.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Objects are displayed without light information.</para>
        /// </summary>
        Unshaded = 1,
        /// <summary>
        /// <para>Objects are displayed with only light information.</para>
        /// <para><b>Note:</b> When using this debug draw mode, custom shaders are ignored since all materials in the scene temporarily use a debug material. This means the result from custom shader functions (such as vertex displacement) won't be visible anymore when using this debug draw mode.</para>
        /// </summary>
        Lighting = 2,
        /// <summary>
        /// <para>Objects are displayed semi-transparent with additive blending so you can see where they are drawing over top of one another. A higher overdraw (represented by brighter colors) means you are wasting performance on drawing pixels that are being hidden behind others.</para>
        /// <para><b>Note:</b> When using this debug draw mode, custom shaders are ignored since all materials in the scene temporarily use a debug material. This means the result from custom shader functions (such as vertex displacement) won't be visible anymore when using this debug draw mode.</para>
        /// </summary>
        Overdraw = 3,
        /// <summary>
        /// <para>Debug draw draws objects in wireframe.</para>
        /// <para><b>Note:</b> <see cref="Godot.RenderingServer.SetDebugGenerateWireframes(bool)"/> must be called before loading any meshes for wireframes to be visible when using the Compatibility renderer.</para>
        /// </summary>
        Wireframe = 4,
        /// <summary>
        /// <para>Normal buffer is drawn instead of regular scene so you can see the per-pixel normals that will be used by post-processing effects.</para>
        /// </summary>
        NormalBuffer = 5,
        /// <summary>
        /// <para>Objects are displayed with only the albedo value from <see cref="Godot.VoxelGI"/>s. Requires at least one visible <see cref="Godot.VoxelGI"/> node that has been baked to have a visible effect.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        VoxelGIAlbedo = 6,
        /// <summary>
        /// <para>Objects are displayed with only the lighting value from <see cref="Godot.VoxelGI"/>s. Requires at least one visible <see cref="Godot.VoxelGI"/> node that has been baked to have a visible effect.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        VoxelGILighting = 7,
        /// <summary>
        /// <para>Objects are displayed with only the emission color from <see cref="Godot.VoxelGI"/>s. Requires at least one visible <see cref="Godot.VoxelGI"/> node that has been baked to have a visible effect.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        VoxelGIEmission = 8,
        /// <summary>
        /// <para>Draws the shadow atlas that stores shadows from <see cref="Godot.OmniLight3D"/>s and <see cref="Godot.SpotLight3D"/>s in the upper left quadrant of the <see cref="Godot.Viewport"/>.</para>
        /// </summary>
        ShadowAtlas = 9,
        /// <summary>
        /// <para>Draws the shadow atlas that stores shadows from <see cref="Godot.DirectionalLight3D"/>s in the upper left quadrant of the <see cref="Godot.Viewport"/>.</para>
        /// <para>The slice of the camera frustum related to the shadow map cascade is superimposed to visualize coverage. The color of each slice matches the colors used for <see cref="Godot.RenderingServer.ViewportDebugDraw.PssmSplits"/>. When shadow cascades are blended the overlap is taken into account when drawing the frustum slices.</para>
        /// <para>The last cascade shows all frustum slices to illustrate the coverage of all slices.</para>
        /// </summary>
        DirectionalShadowAtlas = 10,
        /// <summary>
        /// <para>Draws the estimated scene luminance. This is a 1×1 texture that is generated when autoexposure is enabled to control the scene's exposure.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ or Mobile rendering methods.</para>
        /// </summary>
        SceneLuminance = 11,
        /// <summary>
        /// <para>Draws the screen space ambient occlusion texture instead of the scene so that you can clearly see how it is affecting objects. In order for this display mode to work, you must have <see cref="Godot.Environment.SsaoEnabled"/> set in your <see cref="Godot.WorldEnvironment"/>.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        Ssao = 12,
        /// <summary>
        /// <para>Draws the screen space indirect lighting texture instead of the scene so that you can clearly see how it is affecting objects. In order for this display mode to work, you must have <see cref="Godot.Environment.SsilEnabled"/> set in your <see cref="Godot.WorldEnvironment"/>.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        Ssil = 13,
        /// <summary>
        /// <para>Colors each PSSM split for the <see cref="Godot.DirectionalLight3D"/>s in the scene a different color so you can see where the splits are. In order (from closest to furthest from the camera), they are colored red, green, blue, and yellow.</para>
        /// <para><b>Note:</b> When using this debug draw mode, custom shaders are ignored since all materials in the scene temporarily use a debug material. This means the result from custom shader functions (such as vertex displacement) won't be visible anymore when using this debug draw mode.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ or Mobile rendering methods.</para>
        /// </summary>
        PssmSplits = 14,
        /// <summary>
        /// <para>Draws the decal atlas that stores decal textures from <see cref="Godot.Decal"/>s.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ or Mobile rendering methods.</para>
        /// </summary>
        DecalAtlas = 15,
        /// <summary>
        /// <para>Draws SDFGI cascade data. This is the data structure that is used to bounce lighting against and create reflections.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        Sdfgi = 16,
        /// <summary>
        /// <para>Draws SDFGI probe data. This is the data structure that is used to give indirect lighting dynamic objects moving within the scene.</para>
        /// <para>When in the editor, left-clicking a probe will display additional bright dots that show its occlusion information. A white dot means the light is not occluded at all at the dot's position, while a red dot means the light is fully occluded. Intermediate values are possible.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        SdfgiProbes = 17,
        /// <summary>
        /// <para>Draws the global illumination buffer from <see cref="Godot.VoxelGI"/> or SDFGI. Requires <see cref="Godot.VoxelGI"/> (at least one visible baked VoxelGI node) or SDFGI (<see cref="Godot.Environment.SdfgiEnabled"/>) to be enabled to have a visible effect.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        GIBuffer = 18,
        /// <summary>
        /// <para>Disable mesh LOD. All meshes are drawn with full detail, which can be used to compare performance.</para>
        /// </summary>
        DisableLod = 19,
        /// <summary>
        /// <para>Draws the <see cref="Godot.OmniLight3D"/> cluster. Clustering determines where lights are positioned in screen-space, which allows the engine to only process these portions of the screen for lighting.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        ClusterOmniLights = 20,
        /// <summary>
        /// <para>Draws the <see cref="Godot.SpotLight3D"/> cluster. Clustering determines where lights are positioned in screen-space, which allows the engine to only process these portions of the screen for lighting.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        ClusterSpotLights = 21,
        /// <summary>
        /// <para>Draws the <see cref="Godot.Decal"/> cluster. Clustering determines where decals are positioned in screen-space, which allows the engine to only process these portions of the screen for decals.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        ClusterDecals = 22,
        /// <summary>
        /// <para>Draws the <see cref="Godot.ReflectionProbe"/> cluster. Clustering determines where reflection probes are positioned in screen-space, which allows the engine to only process these portions of the screen for reflection probes.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        ClusterReflectionProbes = 23,
        /// <summary>
        /// <para>Draws the occlusion culling buffer. This low-resolution occlusion culling buffer is rasterized on the CPU and is used to check whether instances are occluded by other objects.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ or Mobile rendering methods.</para>
        /// </summary>
        Occluders = 24,
        /// <summary>
        /// <para>Draws the motion vectors buffer. This is used by temporal antialiasing to correct for motion that occurs during gameplay.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        MotionVectors = 25,
        /// <summary>
        /// <para>Internal buffer is drawn instead of regular scene so you can see the per-pixel output that will be used by post-processing effects.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ or Mobile rendering methods.</para>
        /// </summary>
        InternalBuffer = 26
    }

    public enum ViewportVrsMode : long
    {
        /// <summary>
        /// <para>Variable rate shading is disabled.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Variable rate shading uses a texture. Note, for stereoscopic use a texture atlas with a texture for each view.</para>
        /// </summary>
        Texture = 1,
        /// <summary>
        /// <para>Variable rate shading texture is supplied by the primary <see cref="Godot.XRInterface"/>. Note that this may override the update mode.</para>
        /// </summary>
        XR = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportVrsMode"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum ViewportVrsUpdateMode : long
    {
        /// <summary>
        /// <para>The input texture for variable rate shading will not be processed.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>The input texture for variable rate shading will be processed once.</para>
        /// </summary>
        Once = 1,
        /// <summary>
        /// <para>The input texture for variable rate shading will be processed each frame.</para>
        /// </summary>
        Always = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.ViewportVrsUpdateMode"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum SkyMode : long
    {
        /// <summary>
        /// <para>Automatically selects the appropriate process mode based on your sky shader. If your shader uses <c>TIME</c> or <c>POSITION</c>, this will use <see cref="Godot.RenderingServer.SkyMode.Realtime"/>. If your shader uses any of the <c>LIGHT_*</c> variables or any custom uniforms, this uses <see cref="Godot.RenderingServer.SkyMode.Incremental"/>. Otherwise, this defaults to <see cref="Godot.RenderingServer.SkyMode.Quality"/>.</para>
        /// </summary>
        Automatic = 0,
        /// <summary>
        /// <para>Uses high quality importance sampling to process the radiance map. In general, this results in much higher quality than <see cref="Godot.RenderingServer.SkyMode.Realtime"/> but takes much longer to generate. This should not be used if you plan on changing the sky at runtime. If you are finding that the reflection is not blurry enough and is showing sparkles or fireflies, try increasing <c>ProjectSettings.rendering/reflections/sky_reflections/ggx_samples</c>.</para>
        /// </summary>
        Quality = 1,
        /// <summary>
        /// <para>Uses the same high quality importance sampling to process the radiance map as <see cref="Godot.RenderingServer.SkyMode.Quality"/>, but updates over several frames. The number of frames is determined by <c>ProjectSettings.rendering/reflections/sky_reflections/roughness_layers</c>. Use this when you need highest quality radiance maps, but have a sky that updates slowly.</para>
        /// </summary>
        Incremental = 2,
        /// <summary>
        /// <para>Uses the fast filtering algorithm to process the radiance map. In general this results in lower quality, but substantially faster run times. If you need better quality, but still need to update the sky every frame, consider turning on <c>ProjectSettings.rendering/reflections/sky_reflections/fast_filter_high_quality</c>.</para>
        /// <para><b>Note:</b> The fast filtering algorithm is limited to 256×256 cubemaps, so <see cref="Godot.RenderingServer.SkySetRadianceSize(Rid, int)"/> must be set to <c>256</c>. Otherwise, a warning is printed and the overridden radiance size is ignored.</para>
        /// </summary>
        Realtime = 3
    }

    public enum CompositorEffectFlags : long
    {
        /// <summary>
        /// <para>The rendering effect requires the color buffer to be resolved if MSAA is enabled.</para>
        /// </summary>
        AccessResolvedColor = 1,
        /// <summary>
        /// <para>The rendering effect requires the depth buffer to be resolved if MSAA is enabled.</para>
        /// </summary>
        AccessResolvedDepth = 2,
        /// <summary>
        /// <para>The rendering effect requires motion vectors to be produced.</para>
        /// </summary>
        NeedsMotionVectors = 4,
        /// <summary>
        /// <para>The rendering effect requires normals and roughness g-buffer to be produced (Forward+ only).</para>
        /// </summary>
        NeedsRoughness = 8,
        /// <summary>
        /// <para>The rendering effect requires specular data to be separated out (Forward+ only).</para>
        /// </summary>
        NeedsSeparateSpecular = 16
    }

    public enum CompositorEffectCallbackType : long
    {
        /// <summary>
        /// <para>The callback is called before our opaque rendering pass, but after depth prepass (if applicable).</para>
        /// </summary>
        PreOpaque = 0,
        /// <summary>
        /// <para>The callback is called after our opaque rendering pass, but before our sky is rendered.</para>
        /// </summary>
        PostOpaque = 1,
        /// <summary>
        /// <para>The callback is called after our sky is rendered, but before our back buffers are created (and if enabled, before subsurface scattering and/or screen space reflections).</para>
        /// </summary>
        PostSky = 2,
        /// <summary>
        /// <para>The callback is called before our transparent rendering pass, but after our sky is rendered and we've created our back buffers.</para>
        /// </summary>
        PreTransparent = 3,
        /// <summary>
        /// <para>The callback is called after our transparent rendering pass, but before any built-in post-processing effects and output to our render target.</para>
        /// </summary>
        PostTransparent = 4,
        Any = -1
    }

    public enum EnvironmentBG : long
    {
        /// <summary>
        /// <para>Use the clear color as background.</para>
        /// </summary>
        ClearColor = 0,
        /// <summary>
        /// <para>Use a specified color as the background.</para>
        /// </summary>
        Color = 1,
        /// <summary>
        /// <para>Use a sky resource for the background.</para>
        /// </summary>
        Sky = 2,
        /// <summary>
        /// <para>Use a specified canvas layer as the background. This can be useful for instantiating a 2D scene in a 3D world.</para>
        /// </summary>
        Canvas = 3,
        /// <summary>
        /// <para>Do not clear the background, use whatever was rendered last frame as the background.</para>
        /// </summary>
        Keep = 4,
        /// <summary>
        /// <para>Displays a camera feed in the background.</para>
        /// </summary>
        CameraFeed = 5,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.EnvironmentBG"/> enum.</para>
        /// </summary>
        Max = 6
    }

    public enum EnvironmentAmbientSource : long
    {
        /// <summary>
        /// <para>Gather ambient light from whichever source is specified as the background.</para>
        /// </summary>
        Bg = 0,
        /// <summary>
        /// <para>Disable ambient light.</para>
        /// </summary>
        Disabled = 1,
        /// <summary>
        /// <para>Specify a specific <see cref="Godot.Color"/> for ambient light.</para>
        /// </summary>
        Color = 2,
        /// <summary>
        /// <para>Gather ambient light from the <see cref="Godot.Sky"/> regardless of what the background is.</para>
        /// </summary>
        Sky = 3
    }

    public enum EnvironmentReflectionSource : long
    {
        /// <summary>
        /// <para>Use the background for reflections.</para>
        /// </summary>
        Bg = 0,
        /// <summary>
        /// <para>Disable reflections.</para>
        /// </summary>
        Disabled = 1,
        /// <summary>
        /// <para>Use the <see cref="Godot.Sky"/> for reflections regardless of what the background is.</para>
        /// </summary>
        Sky = 2
    }

    public enum EnvironmentGlowBlendMode : long
    {
        /// <summary>
        /// <para>Additive glow blending mode. Mostly used for particles, glows (bloom), lens flare, bright sources.</para>
        /// </summary>
        Additive = 0,
        /// <summary>
        /// <para>Screen glow blending mode. Increases brightness, used frequently with bloom.</para>
        /// </summary>
        Screen = 1,
        /// <summary>
        /// <para>Soft light glow blending mode. Modifies contrast, exposes shadows and highlights (vivid bloom).</para>
        /// </summary>
        Softlight = 2,
        /// <summary>
        /// <para>Replace glow blending mode. Replaces all pixels' color by the glow value. This can be used to simulate a full-screen blur effect by tweaking the glow parameters to match the original image's brightness.</para>
        /// </summary>
        Replace = 3,
        /// <summary>
        /// <para>Mixes the glow with the underlying color to avoid increasing brightness as much while still maintaining a glow effect.</para>
        /// </summary>
        Mix = 4
    }

    public enum EnvironmentFogMode : long
    {
        /// <summary>
        /// <para>Use a physically-based fog model defined primarily by fog density.</para>
        /// </summary>
        Exponential = 0,
        /// <summary>
        /// <para>Use a simple fog model defined by start and end positions and a custom curve. While not physically accurate, this model can be useful when you need more artistic control.</para>
        /// </summary>
        Depth = 1
    }

    public enum EnvironmentToneMapper : long
    {
        /// <summary>
        /// <para>Does not modify color data, resulting in a linear tonemapping curve which unnaturally clips bright values, causing bright lighting to look blown out. The simplest and fastest tonemapper.</para>
        /// </summary>
        Linear = 0,
        /// <summary>
        /// <para>A simple tonemapping curve that rolls off bright values to prevent clipping. This results in an image that can appear dull and low contrast. Slower than <see cref="Godot.RenderingServer.EnvironmentToneMapper.Linear"/>.</para>
        /// <para><b>Note:</b> When <see cref="Godot.Environment.TonemapWhite"/> is left at the default value of <c>1.0</c>, <see cref="Godot.RenderingServer.EnvironmentToneMapper.Reinhard"/> produces an identical image to <see cref="Godot.RenderingServer.EnvironmentToneMapper.Linear"/>.</para>
        /// </summary>
        Reinhard = 1,
        /// <summary>
        /// <para>Uses a film-like tonemapping curve to prevent clipping of bright values and provide better contrast than <see cref="Godot.RenderingServer.EnvironmentToneMapper.Reinhard"/>. Slightly slower than <see cref="Godot.RenderingServer.EnvironmentToneMapper.Reinhard"/>.</para>
        /// </summary>
        Filmic = 2,
        /// <summary>
        /// <para>Uses a high-contrast film-like tonemapping curve and desaturates bright values for a more realistic appearance. Slightly slower than <see cref="Godot.RenderingServer.EnvironmentToneMapper.Filmic"/>.</para>
        /// <para><b>Note:</b> This tonemapping operator is called "ACES Fitted" in Godot 3.x.</para>
        /// </summary>
        Aces = 3,
        /// <summary>
        /// <para>Uses an adjustable film-like tonemapping curve and desaturates bright values for a more realistic appearance. Better than other tonemappers at maintaining the hue of colors as they become brighter. The slowest tonemapping option.</para>
        /// </summary>
        Agx = 4
    }

    public enum EnvironmentSsrRoughnessQuality : long
    {
        /// <summary>
        /// <para>Lowest quality of roughness filter for screen-space reflections. Rough materials will not have blurrier screen-space reflections compared to smooth (non-rough) materials. This is the fastest option.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Low quality of roughness filter for screen-space reflections.</para>
        /// </summary>
        Low = 1,
        /// <summary>
        /// <para>Medium quality of roughness filter for screen-space reflections.</para>
        /// </summary>
        Medium = 2,
        /// <summary>
        /// <para>High quality of roughness filter for screen-space reflections. This is the slowest option.</para>
        /// </summary>
        High = 3
    }

    public enum EnvironmentSsaoQuality : long
    {
        /// <summary>
        /// <para>Lowest quality of screen-space ambient occlusion.</para>
        /// </summary>
        VeryLow = 0,
        /// <summary>
        /// <para>Low quality screen-space ambient occlusion.</para>
        /// </summary>
        Low = 1,
        /// <summary>
        /// <para>Medium quality screen-space ambient occlusion.</para>
        /// </summary>
        Medium = 2,
        /// <summary>
        /// <para>High quality screen-space ambient occlusion.</para>
        /// </summary>
        High = 3,
        /// <summary>
        /// <para>Highest quality screen-space ambient occlusion. Uses the adaptive target setting which can be dynamically adjusted to smoothly balance performance and visual quality.</para>
        /// </summary>
        Ultra = 4
    }

    public enum EnvironmentSsilQuality : long
    {
        /// <summary>
        /// <para>Lowest quality of screen-space indirect lighting.</para>
        /// </summary>
        VeryLow = 0,
        /// <summary>
        /// <para>Low quality screen-space indirect lighting.</para>
        /// </summary>
        Low = 1,
        /// <summary>
        /// <para>High quality screen-space indirect lighting.</para>
        /// </summary>
        Medium = 2,
        /// <summary>
        /// <para>High quality screen-space indirect lighting.</para>
        /// </summary>
        High = 3,
        /// <summary>
        /// <para>Highest quality screen-space indirect lighting. Uses the adaptive target setting which can be dynamically adjusted to smoothly balance performance and visual quality.</para>
        /// </summary>
        Ultra = 4
    }

    public enum EnvironmentSdfgiyScale : long
    {
        /// <summary>
        /// <para>Use 50% scale for SDFGI on the Y (vertical) axis. SDFGI cells will be twice as short as they are wide. This allows providing increased GI detail and reduced light leaking with thin floors and ceilings. This is usually the best choice for scenes that don't feature much verticality.</para>
        /// </summary>
        Scale50Percent = 0,
        /// <summary>
        /// <para>Use 75% scale for SDFGI on the Y (vertical) axis. This is a balance between the 50% and 100% SDFGI Y scales.</para>
        /// </summary>
        Scale75Percent = 1,
        /// <summary>
        /// <para>Use 100% scale for SDFGI on the Y (vertical) axis. SDFGI cells will be as tall as they are wide. This is usually the best choice for highly vertical scenes. The downside is that light leaking may become more noticeable with thin floors and ceilings.</para>
        /// </summary>
        Scale100Percent = 2
    }

    public enum EnvironmentSdfgiRayCount : long
    {
        /// <summary>
        /// <para>Throw 4 rays per frame when converging SDFGI. This has the lowest GPU requirements, but creates the most noisy result.</para>
        /// </summary>
        Count4 = 0,
        /// <summary>
        /// <para>Throw 8 rays per frame when converging SDFGI.</para>
        /// </summary>
        Count8 = 1,
        /// <summary>
        /// <para>Throw 16 rays per frame when converging SDFGI.</para>
        /// </summary>
        Count16 = 2,
        /// <summary>
        /// <para>Throw 32 rays per frame when converging SDFGI.</para>
        /// </summary>
        Count32 = 3,
        /// <summary>
        /// <para>Throw 64 rays per frame when converging SDFGI.</para>
        /// </summary>
        Count64 = 4,
        /// <summary>
        /// <para>Throw 96 rays per frame when converging SDFGI. This has high GPU requirements.</para>
        /// </summary>
        Count96 = 5,
        /// <summary>
        /// <para>Throw 128 rays per frame when converging SDFGI. This has very high GPU requirements, but creates the least noisy result.</para>
        /// </summary>
        Count128 = 6,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.EnvironmentSdfgiRayCount"/> enum.</para>
        /// </summary>
        Max = 7
    }

    public enum EnvironmentSdfgiFramesToConverge : long
    {
        /// <summary>
        /// <para>Converge SDFGI over 5 frames. This is the most responsive, but creates the most noisy result with a given ray count.</para>
        /// </summary>
        In5Frames = 0,
        /// <summary>
        /// <para>Configure SDFGI to fully converge over 10 frames.</para>
        /// </summary>
        In10Frames = 1,
        /// <summary>
        /// <para>Configure SDFGI to fully converge over 15 frames.</para>
        /// </summary>
        In15Frames = 2,
        /// <summary>
        /// <para>Configure SDFGI to fully converge over 20 frames.</para>
        /// </summary>
        In20Frames = 3,
        /// <summary>
        /// <para>Configure SDFGI to fully converge over 25 frames.</para>
        /// </summary>
        In25Frames = 4,
        /// <summary>
        /// <para>Configure SDFGI to fully converge over 30 frames. This is the least responsive, but creates the least noisy result with a given ray count.</para>
        /// </summary>
        In30Frames = 5,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.EnvironmentSdfgiFramesToConverge"/> enum.</para>
        /// </summary>
        Max = 6
    }

    public enum EnvironmentSdfgiFramesToUpdateLight : long
    {
        /// <summary>
        /// <para>Update indirect light from dynamic lights in SDFGI over 1 frame. This is the most responsive, but has the highest GPU requirements.</para>
        /// </summary>
        In1Frame = 0,
        /// <summary>
        /// <para>Update indirect light from dynamic lights in SDFGI over 2 frames.</para>
        /// </summary>
        In2Frames = 1,
        /// <summary>
        /// <para>Update indirect light from dynamic lights in SDFGI over 4 frames.</para>
        /// </summary>
        In4Frames = 2,
        /// <summary>
        /// <para>Update indirect light from dynamic lights in SDFGI over 8 frames.</para>
        /// </summary>
        In8Frames = 3,
        /// <summary>
        /// <para>Update indirect light from dynamic lights in SDFGI over 16 frames. This is the least responsive, but has the lowest GPU requirements.</para>
        /// </summary>
        In16Frames = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.EnvironmentSdfgiFramesToUpdateLight"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum SubSurfaceScatteringQuality : long
    {
        /// <summary>
        /// <para>Disables subsurface scattering entirely, even on materials that have <see cref="Godot.BaseMaterial3D.SubsurfScatterEnabled"/> set to <see langword="true"/>. This has the lowest GPU requirements.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Low subsurface scattering quality.</para>
        /// </summary>
        Low = 1,
        /// <summary>
        /// <para>Medium subsurface scattering quality.</para>
        /// </summary>
        Medium = 2,
        /// <summary>
        /// <para>High subsurface scattering quality. This has the highest GPU requirements.</para>
        /// </summary>
        High = 3
    }

    public enum DofBokehShape : long
    {
        /// <summary>
        /// <para>Calculate the DOF blur using a box filter. The fastest option, but results in obvious lines in blur pattern.</para>
        /// </summary>
        Box = 0,
        /// <summary>
        /// <para>Calculates DOF blur using a hexagon shaped filter.</para>
        /// </summary>
        Hexagon = 1,
        /// <summary>
        /// <para>Calculates DOF blur using a circle shaped filter. Best quality and most realistic, but slowest. Use only for areas where a lot of performance can be dedicated to post-processing (e.g. cutscenes).</para>
        /// </summary>
        Circle = 2
    }

    public enum DofBlurQuality : long
    {
        /// <summary>
        /// <para>Lowest quality DOF blur. This is the fastest setting, but you may be able to see filtering artifacts.</para>
        /// </summary>
        VeryLow = 0,
        /// <summary>
        /// <para>Low quality DOF blur.</para>
        /// </summary>
        Low = 1,
        /// <summary>
        /// <para>Medium quality DOF blur.</para>
        /// </summary>
        Medium = 2,
        /// <summary>
        /// <para>Highest quality DOF blur. Results in the smoothest looking blur by taking the most samples, but is also significantly slower.</para>
        /// </summary>
        High = 3
    }

    public enum InstanceType : long
    {
        /// <summary>
        /// <para>The instance does not have a type.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>The instance is a mesh.</para>
        /// </summary>
        Mesh = 1,
        /// <summary>
        /// <para>The instance is a multimesh.</para>
        /// </summary>
        Multimesh = 2,
        /// <summary>
        /// <para>The instance is a particle emitter.</para>
        /// </summary>
        Particles = 3,
        /// <summary>
        /// <para>The instance is a GPUParticles collision shape.</para>
        /// </summary>
        ParticlesCollision = 4,
        /// <summary>
        /// <para>The instance is a light.</para>
        /// </summary>
        Light = 5,
        /// <summary>
        /// <para>The instance is a reflection probe.</para>
        /// </summary>
        ReflectionProbe = 6,
        /// <summary>
        /// <para>The instance is a decal.</para>
        /// </summary>
        Decal = 7,
        /// <summary>
        /// <para>The instance is a VoxelGI.</para>
        /// </summary>
        VoxelGI = 8,
        /// <summary>
        /// <para>The instance is a lightmap.</para>
        /// </summary>
        Lightmap = 9,
        /// <summary>
        /// <para>The instance is an occlusion culling occluder.</para>
        /// </summary>
        Occluder = 10,
        /// <summary>
        /// <para>The instance is a visible on-screen notifier.</para>
        /// </summary>
        VisiblityNotifier = 11,
        /// <summary>
        /// <para>The instance is a fog volume.</para>
        /// </summary>
        FogVolume = 12,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.InstanceType"/> enum.</para>
        /// </summary>
        Max = 13,
        /// <summary>
        /// <para>A combination of the flags of geometry instances (mesh, multimesh, immediate and particles).</para>
        /// </summary>
        GeometryMask = 14
    }

    public enum InstanceFlags : long
    {
        /// <summary>
        /// <para>Allows the instance to be used in baked lighting.</para>
        /// </summary>
        UseBakedLight = 0,
        /// <summary>
        /// <para>Allows the instance to be used with dynamic global illumination.</para>
        /// </summary>
        UseDynamicGI = 1,
        /// <summary>
        /// <para>When set, manually requests to draw geometry on next frame.</para>
        /// </summary>
        DrawNextFrameIfVisible = 2,
        /// <summary>
        /// <para>Always draw, even if the instance would be culled by occlusion culling. Does not affect view frustum culling.</para>
        /// </summary>
        IgnoreOcclusionCulling = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.InstanceFlags"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum ShadowCastingSetting : long
    {
        /// <summary>
        /// <para>Disable shadows from this instance.</para>
        /// </summary>
        Off = 0,
        /// <summary>
        /// <para>Cast shadows from this instance.</para>
        /// </summary>
        On = 1,
        /// <summary>
        /// <para>Disable backface culling when rendering the shadow of the object. This is slightly slower but may result in more correct shadows.</para>
        /// </summary>
        DoubleSided = 2,
        /// <summary>
        /// <para>Only render the shadows from the object. The object itself will not be drawn.</para>
        /// </summary>
        ShadowsOnly = 3
    }

    public enum VisibilityRangeFadeMode : long
    {
        /// <summary>
        /// <para>Disable visibility range fading for the given instance.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Fade-out the given instance when it approaches its visibility range limits.</para>
        /// </summary>
        Self = 1,
        /// <summary>
        /// <para>Fade-in the given instance's dependencies when reaching its visibility range limits.</para>
        /// </summary>
        Dependencies = 2
    }

    public enum BakeChannels : long
    {
        /// <summary>
        /// <para>Index of <see cref="Godot.Image"/> in array of <see cref="Godot.Image"/>s returned by <see cref="Godot.RenderingServer.BakeRenderUV2(Rid, Godot.Collections.Array{Rid}, Vector2I)"/>. Image uses <see cref="Godot.Image.Format.Rgba8"/> and contains albedo color in the <c>.rgb</c> channels and alpha in the <c>.a</c> channel.</para>
        /// </summary>
        AlbedoAlpha = 0,
        /// <summary>
        /// <para>Index of <see cref="Godot.Image"/> in array of <see cref="Godot.Image"/>s returned by <see cref="Godot.RenderingServer.BakeRenderUV2(Rid, Godot.Collections.Array{Rid}, Vector2I)"/>. Image uses <see cref="Godot.Image.Format.Rgba8"/> and contains the per-pixel normal of the object in the <c>.rgb</c> channels and nothing in the <c>.a</c> channel. The per-pixel normal is encoded as <c>normal * 0.5 + 0.5</c>.</para>
        /// </summary>
        Normal = 1,
        /// <summary>
        /// <para>Index of <see cref="Godot.Image"/> in array of <see cref="Godot.Image"/>s returned by <see cref="Godot.RenderingServer.BakeRenderUV2(Rid, Godot.Collections.Array{Rid}, Vector2I)"/>. Image uses <see cref="Godot.Image.Format.Rgba8"/> and contains ambient occlusion (from material and decals only) in the <c>.r</c> channel, roughness in the <c>.g</c> channel, metallic in the <c>.b</c> channel and sub surface scattering amount in the <c>.a</c> channel.</para>
        /// </summary>
        Orm = 2,
        /// <summary>
        /// <para>Index of <see cref="Godot.Image"/> in array of <see cref="Godot.Image"/>s returned by <see cref="Godot.RenderingServer.BakeRenderUV2(Rid, Godot.Collections.Array{Rid}, Vector2I)"/>. Image uses <see cref="Godot.Image.Format.Rgbah"/> and contains emission color in the <c>.rgb</c> channels and nothing in the <c>.a</c> channel.</para>
        /// </summary>
        Emission = 3
    }

    public enum CanvasTextureChannel : long
    {
        /// <summary>
        /// <para>Diffuse canvas texture (<see cref="Godot.CanvasTexture.DiffuseTexture"/>).</para>
        /// </summary>
        Diffuse = 0,
        /// <summary>
        /// <para>Normal map canvas texture (<see cref="Godot.CanvasTexture.NormalTexture"/>).</para>
        /// </summary>
        Normal = 1,
        /// <summary>
        /// <para>Specular map canvas texture (<see cref="Godot.CanvasTexture.SpecularTexture"/>).</para>
        /// </summary>
        Specular = 2
    }

    public enum NinePatchAxisMode : long
    {
        /// <summary>
        /// <para>The nine patch gets stretched where needed.</para>
        /// </summary>
        Stretch = 0,
        /// <summary>
        /// <para>The nine patch gets filled with tiles where needed.</para>
        /// </summary>
        Tile = 1,
        /// <summary>
        /// <para>The nine patch gets filled with tiles where needed and stretches them a bit if needed.</para>
        /// </summary>
        TileFit = 2
    }

    public enum CanvasItemTextureFilter : long
    {
        /// <summary>
        /// <para>Uses the default filter mode for this <see cref="Godot.Viewport"/>.</para>
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
        NearestWithMipmaps = 3,
        /// <summary>
        /// <para>The texture filter blends between the nearest 4 pixels and between the nearest 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>). This makes the texture look smooth from up close, and smooth from a distance.</para>
        /// <para>Use this for non-pixel art textures that may be viewed at a low scale (e.g. due to <see cref="Godot.Camera2D"/> zoom or sprite scaling), as mipmaps are important to smooth out pixels that are smaller than on-screen pixels.</para>
        /// </summary>
        LinearWithMipmaps = 4,
        /// <summary>
        /// <para>The texture filter reads from the nearest pixel and blends between 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>) based on the angle between the surface and the camera view. This makes the texture look pixelated from up close, and smooth from a distance. Anisotropic filtering improves texture quality on surfaces that are almost in line with the camera, but is slightly slower. The anisotropic filtering level can be changed by adjusting <c>ProjectSettings.rendering/textures/default_filters/anisotropic_filtering_level</c>.</para>
        /// <para><b>Note:</b> This texture filter is rarely useful in 2D projects. <see cref="Godot.RenderingServer.CanvasItemTextureFilter.NearestWithMipmaps"/> is usually more appropriate in this case.</para>
        /// </summary>
        NearestWithMipmapsAnisotropic = 5,
        /// <summary>
        /// <para>The texture filter blends between the nearest 4 pixels and blends between 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>) based on the angle between the surface and the camera view. This makes the texture look smooth from up close, and smooth from a distance. Anisotropic filtering improves texture quality on surfaces that are almost in line with the camera, but is slightly slower. The anisotropic filtering level can be changed by adjusting <c>ProjectSettings.rendering/textures/default_filters/anisotropic_filtering_level</c>.</para>
        /// <para><b>Note:</b> This texture filter is rarely useful in 2D projects. <see cref="Godot.RenderingServer.CanvasItemTextureFilter.LinearWithMipmaps"/> is usually more appropriate in this case.</para>
        /// </summary>
        LinearWithMipmapsAnisotropic = 6,
        /// <summary>
        /// <para>Max value for <see cref="Godot.RenderingServer.CanvasItemTextureFilter"/> enum.</para>
        /// </summary>
        Max = 7
    }

    public enum CanvasItemTextureRepeat : long
    {
        /// <summary>
        /// <para>Uses the default repeat mode for this <see cref="Godot.Viewport"/>.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>Disables textures repeating. Instead, when reading UVs outside the 0-1 range, the value will be clamped to the edge of the texture, resulting in a stretched out look at the borders of the texture.</para>
        /// </summary>
        Disabled = 1,
        /// <summary>
        /// <para>Enables the texture to repeat when UV coordinates are outside the 0-1 range. If using one of the linear filtering modes, this can result in artifacts at the edges of a texture when the sampler filters across the edges of the texture.</para>
        /// </summary>
        Enabled = 2,
        /// <summary>
        /// <para>Flip the texture when repeating so that the edge lines up instead of abruptly changing.</para>
        /// </summary>
        Mirror = 3,
        /// <summary>
        /// <para>Max value for <see cref="Godot.RenderingServer.CanvasItemTextureRepeat"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum CanvasGroupMode : long
    {
        /// <summary>
        /// <para>Child draws over parent and is not clipped.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Parent is used for the purposes of clipping only. Child is clipped to the parent's visible area, parent is not drawn.</para>
        /// </summary>
        ClipOnly = 1,
        /// <summary>
        /// <para>Parent is used for clipping child, but parent is also drawn underneath child as normal before clipping child to its visible area.</para>
        /// </summary>
        ClipAndDraw = 2,
        Transparent = 3
    }

    public enum CanvasLightMode : long
    {
        /// <summary>
        /// <para>2D point light (see <see cref="Godot.PointLight2D"/>).</para>
        /// </summary>
        Point = 0,
        /// <summary>
        /// <para>2D directional (sun/moon) light (see <see cref="Godot.DirectionalLight2D"/>).</para>
        /// </summary>
        Directional = 1
    }

    public enum CanvasLightBlendMode : long
    {
        /// <summary>
        /// <para>Adds light color additive to the canvas.</para>
        /// </summary>
        Add = 0,
        /// <summary>
        /// <para>Adds light color subtractive to the canvas.</para>
        /// </summary>
        Sub = 1,
        /// <summary>
        /// <para>The light adds color depending on transparency.</para>
        /// </summary>
        Mix = 2
    }

    public enum CanvasLightShadowFilter : long
    {
        /// <summary>
        /// <para>Do not apply a filter to canvas light shadows.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Use PCF5 filtering to filter canvas light shadows.</para>
        /// </summary>
        Pcf5 = 1,
        /// <summary>
        /// <para>Use PCF13 filtering to filter canvas light shadows.</para>
        /// </summary>
        Pcf13 = 2,
        /// <summary>
        /// <para>Max value of the <see cref="Godot.RenderingServer.CanvasLightShadowFilter"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum CanvasOccluderPolygonCullMode : long
    {
        /// <summary>
        /// <para>Culling of the canvas occluder is disabled.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Culling of the canvas occluder is clockwise.</para>
        /// </summary>
        Clockwise = 1,
        /// <summary>
        /// <para>Culling of the canvas occluder is counterclockwise.</para>
        /// </summary>
        CounterClockwise = 2
    }

    public enum GlobalShaderParameterType : long
    {
        /// <summary>
        /// <para>Boolean global shader parameter (<c>global uniform bool ...</c>).</para>
        /// </summary>
        Bool = 0,
        /// <summary>
        /// <para>2-dimensional boolean vector global shader parameter (<c>global uniform bvec2 ...</c>).</para>
        /// </summary>
        Bvec2 = 1,
        /// <summary>
        /// <para>3-dimensional boolean vector global shader parameter (<c>global uniform bvec3 ...</c>).</para>
        /// </summary>
        Bvec3 = 2,
        /// <summary>
        /// <para>4-dimensional boolean vector global shader parameter (<c>global uniform bvec4 ...</c>).</para>
        /// </summary>
        Bvec4 = 3,
        /// <summary>
        /// <para>Integer global shader parameter (<c>global uniform int ...</c>).</para>
        /// </summary>
        Int = 4,
        /// <summary>
        /// <para>2-dimensional integer vector global shader parameter (<c>global uniform ivec2 ...</c>).</para>
        /// </summary>
        Ivec2 = 5,
        /// <summary>
        /// <para>3-dimensional integer vector global shader parameter (<c>global uniform ivec3 ...</c>).</para>
        /// </summary>
        Ivec3 = 6,
        /// <summary>
        /// <para>4-dimensional integer vector global shader parameter (<c>global uniform ivec4 ...</c>).</para>
        /// </summary>
        Ivec4 = 7,
        /// <summary>
        /// <para>2-dimensional integer rectangle global shader parameter (<c>global uniform ivec4 ...</c>). Equivalent to <see cref="Godot.RenderingServer.GlobalShaderParameterType.Ivec4"/> in shader code, but exposed as a <see cref="Godot.Rect2I"/> in the editor UI.</para>
        /// </summary>
        Rect2I = 8,
        /// <summary>
        /// <para>Unsigned integer global shader parameter (<c>global uniform uint ...</c>).</para>
        /// </summary>
        Uint = 9,
        /// <summary>
        /// <para>2-dimensional unsigned integer vector global shader parameter (<c>global uniform uvec2 ...</c>).</para>
        /// </summary>
        Uvec2 = 10,
        /// <summary>
        /// <para>3-dimensional unsigned integer vector global shader parameter (<c>global uniform uvec3 ...</c>).</para>
        /// </summary>
        Uvec3 = 11,
        /// <summary>
        /// <para>4-dimensional unsigned integer vector global shader parameter (<c>global uniform uvec4 ...</c>).</para>
        /// </summary>
        Uvec4 = 12,
        /// <summary>
        /// <para>Single-precision floating-point global shader parameter (<c>global uniform float ...</c>).</para>
        /// </summary>
        Float = 13,
        /// <summary>
        /// <para>2-dimensional floating-point vector global shader parameter (<c>global uniform vec2 ...</c>).</para>
        /// </summary>
        Vec2 = 14,
        /// <summary>
        /// <para>3-dimensional floating-point vector global shader parameter (<c>global uniform vec3 ...</c>).</para>
        /// </summary>
        Vec3 = 15,
        /// <summary>
        /// <para>4-dimensional floating-point vector global shader parameter (<c>global uniform vec4 ...</c>).</para>
        /// </summary>
        Vec4 = 16,
        /// <summary>
        /// <para>Color global shader parameter (<c>global uniform vec4 ...</c>). Equivalent to <see cref="Godot.RenderingServer.GlobalShaderParameterType.Vec4"/> in shader code, but exposed as a <see cref="Godot.Color"/> in the editor UI.</para>
        /// </summary>
        Color = 17,
        /// <summary>
        /// <para>2-dimensional floating-point rectangle global shader parameter (<c>global uniform vec4 ...</c>). Equivalent to <see cref="Godot.RenderingServer.GlobalShaderParameterType.Vec4"/> in shader code, but exposed as a <see cref="Godot.Rect2"/> in the editor UI.</para>
        /// </summary>
        Rect2 = 18,
        /// <summary>
        /// <para>2×2 matrix global shader parameter (<c>global uniform mat2 ...</c>). Exposed as a <see cref="int"/>[] in the editor UI.</para>
        /// </summary>
        Mat2 = 19,
        /// <summary>
        /// <para>3×3 matrix global shader parameter (<c>global uniform mat3 ...</c>). Exposed as a <see cref="Godot.Basis"/> in the editor UI.</para>
        /// </summary>
        Mat3 = 20,
        /// <summary>
        /// <para>4×4 matrix global shader parameter (<c>global uniform mat4 ...</c>). Exposed as a <see cref="Godot.Projection"/> in the editor UI.</para>
        /// </summary>
        Mat4 = 21,
        /// <summary>
        /// <para>2-dimensional transform global shader parameter (<c>global uniform mat2x3 ...</c>). Exposed as a <see cref="Godot.Transform2D"/> in the editor UI.</para>
        /// </summary>
        Transform2D = 22,
        /// <summary>
        /// <para>3-dimensional transform global shader parameter (<c>global uniform mat3x4 ...</c>). Exposed as a <see cref="Godot.Transform3D"/> in the editor UI.</para>
        /// </summary>
        Transform = 23,
        /// <summary>
        /// <para>2D sampler global shader parameter (<c>global uniform sampler2D ...</c>). Exposed as a <see cref="Godot.Texture2D"/> in the editor UI.</para>
        /// </summary>
        Sampler2D = 24,
        /// <summary>
        /// <para>2D sampler array global shader parameter (<c>global uniform sampler2DArray ...</c>). Exposed as a <see cref="Godot.Texture2DArray"/> in the editor UI.</para>
        /// </summary>
        Sampler2Darray = 25,
        /// <summary>
        /// <para>3D sampler global shader parameter (<c>global uniform sampler3D ...</c>). Exposed as a <see cref="Godot.Texture3D"/> in the editor UI.</para>
        /// </summary>
        Sampler3D = 26,
        /// <summary>
        /// <para>Cubemap sampler global shader parameter (<c>global uniform samplerCube ...</c>). Exposed as a <see cref="Godot.Cubemap"/> in the editor UI.</para>
        /// </summary>
        Samplercube = 27,
        /// <summary>
        /// <para>External sampler global shader parameter (<c>global uniform samplerExternalOES ...</c>). Exposed as an <see cref="Godot.ExternalTexture"/> in the editor UI.</para>
        /// </summary>
        Samplerext = 28,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.GlobalShaderParameterType"/> enum.</para>
        /// </summary>
        Max = 29
    }

    public enum RenderingInfo : long
    {
        /// <summary>
        /// <para>Number of objects rendered in the current 3D scene. This varies depending on camera position and rotation.</para>
        /// </summary>
        TotalObjectsInFrame = 0,
        /// <summary>
        /// <para>Number of points, lines, or triangles rendered in the current 3D scene. This varies depending on camera position and rotation.</para>
        /// </summary>
        TotalPrimitivesInFrame = 1,
        /// <summary>
        /// <para>Number of draw calls performed to render in the current 3D scene. This varies depending on camera position and rotation.</para>
        /// </summary>
        TotalDrawCallsInFrame = 2,
        /// <summary>
        /// <para>Texture memory used (in bytes).</para>
        /// </summary>
        TextureMemUsed = 3,
        /// <summary>
        /// <para>Buffer memory used (in bytes). This includes vertex data, uniform buffers, and many miscellaneous buffer types used internally.</para>
        /// </summary>
        BufferMemUsed = 4,
        /// <summary>
        /// <para>Video memory used (in bytes). When using the Forward+ or Mobile renderers, this is always greater than the sum of <see cref="Godot.RenderingServer.RenderingInfo.TextureMemUsed"/> and <see cref="Godot.RenderingServer.RenderingInfo.BufferMemUsed"/>, since there is miscellaneous data not accounted for by those two metrics. When using the Compatibility renderer, this is equal to the sum of <see cref="Godot.RenderingServer.RenderingInfo.TextureMemUsed"/> and <see cref="Godot.RenderingServer.RenderingInfo.BufferMemUsed"/>.</para>
        /// </summary>
        VideoMemUsed = 5,
        /// <summary>
        /// <para>Number of pipeline compilations that were triggered by the 2D canvas renderer.</para>
        /// </summary>
        PipelineCompilationsCanvas = 6,
        /// <summary>
        /// <para>Number of pipeline compilations that were triggered by loading meshes. These compilations will show up as longer loading times the first time a user runs the game and the pipeline is required.</para>
        /// </summary>
        PipelineCompilationsMesh = 7,
        /// <summary>
        /// <para>Number of pipeline compilations that were triggered by building the surface cache before rendering the scene. These compilations will show up as a stutter when loading a scene the first time a user runs the game and the pipeline is required.</para>
        /// </summary>
        PipelineCompilationsSurface = 8,
        /// <summary>
        /// <para>Number of pipeline compilations that were triggered while drawing the scene. These compilations will show up as stutters during gameplay the first time a user runs the game and the pipeline is required.</para>
        /// </summary>
        PipelineCompilationsDraw = 9,
        /// <summary>
        /// <para>Number of pipeline compilations that were triggered to optimize the current scene. These compilations are done in the background and should not cause any stutters whatsoever.</para>
        /// </summary>
        PipelineCompilationsSpecialization = 10
    }

    public enum PipelineSource : long
    {
        /// <summary>
        /// <para>Pipeline compilation that was triggered by the 2D canvas renderer.</para>
        /// </summary>
        Canvas = 0,
        /// <summary>
        /// <para>Pipeline compilation that was triggered by loading a mesh.</para>
        /// </summary>
        Mesh = 1,
        /// <summary>
        /// <para>Pipeline compilation that was triggered by building the surface cache before rendering the scene.</para>
        /// </summary>
        Surface = 2,
        /// <summary>
        /// <para>Pipeline compilation that was triggered while drawing the scene.</para>
        /// </summary>
        Draw = 3,
        /// <summary>
        /// <para>Pipeline compilation that was triggered to optimize the current scene.</para>
        /// </summary>
        Specialization = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RenderingServer.PipelineSource"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum SplashStretchMode : long
    {
        /// <summary>
        /// <para>No stretching is applied.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Stretches image to fullscreen while preserving aspect ratio.</para>
        /// </summary>
        Keep = 1,
        /// <summary>
        /// <para>Stretches the height of the image based on the width of the screen.</para>
        /// </summary>
        KeepWidth = 2,
        /// <summary>
        /// <para>Stretches the width of the image based on the height of the screen.</para>
        /// </summary>
        KeepHeight = 3,
        /// <summary>
        /// <para>Stretches the image to cover the entire screen while preserving aspect ratio.</para>
        /// </summary>
        Cover = 4,
        /// <summary>
        /// <para>Stretches the image to cover the entire screen but doesn't preserve aspect ratio.</para>
        /// </summary>
        Ignore = 5
    }

    public enum Features : long
    {
        [Obsolete("This constant has not been used since Godot 3.0.")]
        Shaders = 0,
        [Obsolete("This constant has not been used since Godot 3.0.")]
        Multithreaded = 1
    }

    /// <summary>
    /// <para>If <see langword="false"/>, disables rendering completely, but the engine logic is still being processed. You can call <see cref="Godot.RenderingServer.ForceDraw(bool, double)"/> to draw a frame even with rendering disabled.</para>
    /// </summary>
    public static bool RenderLoopEnabled
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

    private static readonly StringName NativeName = "RenderingServer";

    private static RenderingServerInstance singleton;

    public static RenderingServerInstance Singleton =>
        singleton ??= (RenderingServerInstance)InteropUtils.EngineGetSingleton("RenderingServer");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DCreate, 2010018390ul);

    /// <summary>
    /// <para>Creates a 2-dimensional texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>texture_2d_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Texture2D"/>.</para>
    /// <para><b>Note:</b> Not to be confused with <see cref="Godot.RenderingDevice.TextureCreate(RDTextureFormat, RDTextureView, Godot.Collections.Array{byte[]})"/>, which creates the graphics API's own texture type as opposed to the Godot-specific <see cref="Godot.Texture2D"/> resource.</para>
    /// </summary>
    public static Rid Texture2DCreate(Image image)
    {
        return NativeCalls.godot_icall_1_1067(MethodBind0, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(image));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DLayeredCreate, 913689023ul);

    /// <summary>
    /// <para>Creates a 2-dimensional layered texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>texture_2d_layered_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.TextureLayered"/>.</para>
    /// </summary>
    public static Rid Texture2DLayeredCreate(Godot.Collections.Array<Image> layers, RenderingServer.TextureLayeredType layeredType)
    {
        return NativeCalls.godot_icall_2_1118(MethodBind1, GodotObject.GetPtr(Singleton), (godot_array)(layers ?? new()).NativeValue, (int)layeredType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture3DCreate, 4036838706ul);

    /// <summary>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Texture3D"/>.</para>
    /// </summary>
    public static Rid Texture3DCreate(Image.Format format, int width, int height, int depth, bool mipmaps, Godot.Collections.Array<Image> data)
    {
        return NativeCalls.godot_icall_6_1119(MethodBind2, GodotObject.GetPtr(Singleton), (int)format, width, height, depth, mipmaps.ToGodotBool(), (godot_array)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureProxyCreate, 41030802ul);

    /// <summary>
    /// <para>This method does nothing and always returns an invalid <see cref="Godot.Rid"/>.</para>
    /// </summary>
    [Obsolete("ProxyTexture was removed in Godot 4.")]
    public static Rid TextureProxyCreate(Rid @base)
    {
        return NativeCalls.godot_icall_1_855(MethodBind3, GodotObject.GetPtr(Singleton), @base);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureCreateFromNativeHandle, 1682977582ul);

    /// <summary>
    /// <para>Creates a texture based on a native handle that was created outside of Godot's renderer.</para>
    /// <para><b>Note:</b> If using only the rendering device renderer, it's recommend to use <see cref="Godot.RenderingDevice.TextureCreateFromExtension(RenderingDevice.TextureType, RenderingDevice.DataFormat, RenderingDevice.TextureSamples, RenderingDevice.TextureUsageBits, ulong, ulong, ulong, ulong, ulong, ulong)"/> together with <see cref="Godot.RenderingServer.TextureRdCreate(Rid, RenderingServer.TextureLayeredType)"/>, rather than this method. This way, the texture's format and usage can be controlled more effectively.</para>
    /// </summary>
    public static Rid TextureCreateFromNativeHandle(RenderingServer.TextureType type, Image.Format format, ulong nativeHandle, int width, int height, int depth, int layers = 1, RenderingServer.TextureLayeredType layeredType = (RenderingServer.TextureLayeredType)(0))
    {
        return NativeCalls.godot_icall_8_1120(MethodBind4, GodotObject.GetPtr(Singleton), (int)type, (int)format, nativeHandle, width, height, depth, layers, (int)layeredType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DUpdate, 999539803ul);

    /// <summary>
    /// <para>Updates the texture specified by the <paramref name="texture"/> <see cref="Godot.Rid"/> with the data in <paramref name="image"/>. A <paramref name="layer"/> must also be specified, which should be <c>0</c> when updating a single-layer texture (<see cref="Godot.Texture2D"/>).</para>
    /// <para><b>Note:</b> The <paramref name="image"/> must have the same width, height and format as the current <paramref name="texture"/> data. Otherwise, an error will be printed and the original texture won't be modified. If you need to use different width, height or format, use <see cref="Godot.RenderingServer.TextureReplace(Rid, Rid)"/> instead.</para>
    /// </summary>
    public static void Texture2DUpdate(Rid texture, Image image, int layer)
    {
        NativeCalls.godot_icall_3_1121(MethodBind5, GodotObject.GetPtr(Singleton), texture, GodotObject.GetPtr(image), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture3DUpdate, 684822712ul);

    /// <summary>
    /// <para>Updates the texture specified by the <paramref name="texture"/> <see cref="Godot.Rid"/>'s data with the data in <paramref name="data"/>. All the texture's layers must be replaced at once.</para>
    /// <para><b>Note:</b> The <paramref name="texture"/> must have the same width, height, depth and format as the current texture data. Otherwise, an error will be printed and the original texture won't be modified. If you need to use different width, height, depth or format, use <see cref="Godot.RenderingServer.TextureReplace(Rid, Rid)"/> instead.</para>
    /// </summary>
    public static void Texture3DUpdate(Rid texture, Godot.Collections.Array<Image> data)
    {
        NativeCalls.godot_icall_2_1122(MethodBind6, GodotObject.GetPtr(Singleton), texture, (godot_array)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureProxyUpdate, 395945892ul);

    /// <summary>
    /// <para>This method does nothing.</para>
    /// </summary>
    [Obsolete("ProxyTexture was removed in Godot 4.")]
    public static void TextureProxyUpdate(Rid texture, Rid proxyTo)
    {
        NativeCalls.godot_icall_2_430(MethodBind7, GodotObject.GetPtr(Singleton), texture, proxyTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DPlaceholderCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a placeholder for a 2-dimensional layered texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>texture_2d_layered_*</c> RenderingServer functions, although it does nothing when used. See also <see cref="Godot.RenderingServer.Texture2DLayeredPlaceholderCreate(RenderingServer.TextureLayeredType)"/>.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.PlaceholderTexture2D"/>.</para>
    /// </summary>
    public static Rid Texture2DPlaceholderCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind8, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DLayeredPlaceholderCreate, 1394585590ul);

    /// <summary>
    /// <para>Creates a placeholder for a 2-dimensional layered texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>texture_2d_layered_*</c> RenderingServer functions, although it does nothing when used. See also <see cref="Godot.RenderingServer.Texture2DPlaceholderCreate()"/>.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.PlaceholderTextureLayered"/>.</para>
    /// </summary>
    public static Rid Texture2DLayeredPlaceholderCreate(RenderingServer.TextureLayeredType layeredType)
    {
        return NativeCalls.godot_icall_1_425(MethodBind9, GodotObject.GetPtr(Singleton), (int)layeredType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture3DPlaceholderCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a placeholder for a 3-dimensional texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>texture_3d_*</c> RenderingServer functions, although it does nothing when used.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.PlaceholderTexture3D"/>.</para>
    /// </summary>
    public static Rid Texture3DPlaceholderCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind10, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DGet, 4206205781ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Image"/> instance from the given <paramref name="texture"/> <see cref="Godot.Rid"/>.</para>
    /// <para><b>Example:</b> Get the test texture from <see cref="Godot.RenderingServer.GetTestTexture()"/> and apply it to a <see cref="Godot.Sprite2D"/> node:</para>
    /// <para><code>
    /// var texture_rid = RenderingServer.get_test_texture()
    /// var texture = ImageTexture.create_from_image(RenderingServer.texture_2d_get(texture_rid))
    /// $Sprite2D.texture = texture
    /// </code></para>
    /// </summary>
    public static Image Texture2DGet(Rid texture)
    {
        return (Image)NativeCalls.godot_icall_1_1059(MethodBind11, GodotObject.GetPtr(Singleton), texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture2DLayerGet, 2705440895ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Image"/> instance from the given <paramref name="texture"/> <see cref="Godot.Rid"/> and <paramref name="layer"/>.</para>
    /// </summary>
    public static Image Texture2DLayerGet(Rid texture, int layer)
    {
        return (Image)NativeCalls.godot_icall_2_831(MethodBind12, GodotObject.GetPtr(Singleton), texture, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Texture3DGet, 2684255073ul);

    /// <summary>
    /// <para>Returns 3D texture data as an array of <see cref="Godot.Image"/>s for the specified texture <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Image> Texture3DGet(Rid texture)
    {
        return new Godot.Collections.Array<Image>(NativeCalls.godot_icall_1_849(MethodBind13, GodotObject.GetPtr(Singleton), texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureReplace, 395945892ul);

    /// <summary>
    /// <para>Replaces <paramref name="texture"/>'s texture data by the texture specified by the <paramref name="byTexture"/> RID, without changing <paramref name="texture"/>'s RID.</para>
    /// </summary>
    public static void TextureReplace(Rid texture, Rid byTexture)
    {
        NativeCalls.godot_icall_2_430(MethodBind14, GodotObject.GetPtr(Singleton), texture, byTexture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureSetSizeOverride, 4288446313ul);

    public static void TextureSetSizeOverride(Rid texture, int width, int height)
    {
        NativeCalls.godot_icall_3_433(MethodBind15, GodotObject.GetPtr(Singleton), texture, width, height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureSetPath, 2726140452ul);

    public static void TextureSetPath(Rid texture, string path)
    {
        NativeCalls.godot_icall_2_427(MethodBind16, GodotObject.GetPtr(Singleton), texture, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureGetPath, 642473191ul);

    public static string TextureGetPath(Rid texture)
    {
        return NativeCalls.godot_icall_1_940(MethodBind17, GodotObject.GetPtr(Singleton), texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureGetFormat, 1932918979ul);

    /// <summary>
    /// <para>Returns the format for the texture.</para>
    /// </summary>
    public static Image.Format TextureGetFormat(Rid texture)
    {
        return (Image.Format)NativeCalls.godot_icall_1_835(MethodBind18, GodotObject.GetPtr(Singleton), texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureSetForceRedrawIfVisible, 1265174801ul);

    public static void TextureSetForceRedrawIfVisible(Rid texture, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind19, GodotObject.GetPtr(Singleton), texture, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureRdCreate, 1434128712ul);

    /// <summary>
    /// <para>Creates a new texture object based on a texture created directly on the <see cref="Godot.RenderingDevice"/>. If the texture contains layers, <paramref name="layerType"/> is used to define the layer type.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> won't free the underlying <paramref name="rdTexture"/>, you will want to free the <paramref name="rdTexture"/> using <see cref="Godot.RenderingDevice.FreeRid(Rid)"/>.</para>
    /// </summary>
    public static Rid TextureRdCreate(Rid rdTexture, RenderingServer.TextureLayeredType layerType = (RenderingServer.TextureLayeredType)(0))
    {
        return NativeCalls.godot_icall_2_830(MethodBind20, GodotObject.GetPtr(Singleton), rdTexture, (int)layerType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureGetRdTexture, 2790148051ul);

    /// <summary>
    /// <para>Returns a texture <see cref="Godot.Rid"/> that can be used with <see cref="Godot.RenderingDevice"/>.</para>
    /// <para><paramref name="srgb"/> should be <see langword="true"/> when the texture uses nonlinear sRGB encoding and <see langword="false"/> when the texture uses linear encoding.</para>
    /// </summary>
    public static Rid TextureGetRdTexture(Rid texture, bool srgb = false)
    {
        return NativeCalls.godot_icall_2_1123(MethodBind21, GodotObject.GetPtr(Singleton), texture, srgb.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TextureGetNativeHandle, 1834114100ul);

    /// <summary>
    /// <para>Returns the internal graphics handle for this texture object. For use when communicating with third-party APIs mostly with GDExtension.</para>
    /// <para><paramref name="srgb"/> should be <see langword="true"/> when the texture uses nonlinear sRGB encoding and <see langword="false"/> when the texture uses linear encoding.</para>
    /// <para><b>Note:</b> This function returns a <c>uint64_t</c> which internally maps to a <c>GLuint</c> (OpenGL) or <c>VkImage</c> (Vulkan).</para>
    /// </summary>
    public static ulong TextureGetNativeHandle(Rid texture, bool srgb = false)
    {
        return NativeCalls.godot_icall_2_1124(MethodBind22, GodotObject.GetPtr(Singleton), texture, srgb.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an empty shader and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>shader_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Shader"/>.</para>
    /// </summary>
    public static Rid ShaderCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind23, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderSetCode, 2726140452ul);

    /// <summary>
    /// <para>Sets the shader's source code (which triggers recompilation after being changed).</para>
    /// </summary>
    public static void ShaderSetCode(Rid shader, string code)
    {
        NativeCalls.godot_icall_2_427(MethodBind24, GodotObject.GetPtr(Singleton), shader, code);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderSetPathHint, 2726140452ul);

    /// <summary>
    /// <para>Sets the path hint for the specified shader. This should generally match the <see cref="Godot.Shader"/> resource's <see cref="Godot.Resource.ResourcePath"/>.</para>
    /// </summary>
    public static void ShaderSetPathHint(Rid shader, string path)
    {
        NativeCalls.godot_icall_2_427(MethodBind25, GodotObject.GetPtr(Singleton), shader, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderGetCode, 642473191ul);

    /// <summary>
    /// <para>Returns a shader's source code as a string.</para>
    /// </summary>
    public static string ShaderGetCode(Rid shader)
    {
        return NativeCalls.godot_icall_1_940(MethodBind26, GodotObject.GetPtr(Singleton), shader);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShaderParameterList, 2684255073ul);

    /// <summary>
    /// <para>Returns the parameters of a shader.</para>
    /// </summary>
    public static Godot.Collections.Array<Godot.Collections.Dictionary> GetShaderParameterList(Rid shader)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_849(MethodBind27, GodotObject.GetPtr(Singleton), shader));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderGetParameterDefault, 2621281810ul);

    /// <summary>
    /// <para>Returns the default value for the specified shader uniform. This is usually the value written in the shader source code.</para>
    /// </summary>
    public static Variant ShaderGetParameterDefault(Rid shader, StringName name)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind28, GodotObject.GetPtr(Singleton), shader, (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderSetDefaultTextureParameter, 4094001817ul);

    /// <summary>
    /// <para>Sets a shader's default texture. Overwrites the texture given by name.</para>
    /// <para><b>Note:</b> If the sampler array is used use <paramref name="index"/> to access the specified texture.</para>
    /// </summary>
    public static void ShaderSetDefaultTextureParameter(Rid shader, StringName name, Rid texture, int index = 0)
    {
        NativeCalls.godot_icall_4_1126(MethodBind29, GodotObject.GetPtr(Singleton), shader, (godot_string_name)(name?.NativeValue ?? default), texture, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShaderGetDefaultTextureParameter, 1464608890ul);

    /// <summary>
    /// <para>Returns a default texture from a shader searched by name.</para>
    /// <para><b>Note:</b> If the sampler array is used use <paramref name="index"/> to access the specified texture.</para>
    /// </summary>
    public static Rid ShaderGetDefaultTextureParameter(Rid shader, StringName name, int index = 0)
    {
        return NativeCalls.godot_icall_3_1127(MethodBind30, GodotObject.GetPtr(Singleton), shader, (godot_string_name)(name?.NativeValue ?? default), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an empty material and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>material_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Material"/>.</para>
    /// </summary>
    public static Rid MaterialCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind31, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialSetShader, 395945892ul);

    /// <summary>
    /// <para>Sets a shader material's shader.</para>
    /// </summary>
    public static void MaterialSetShader(Rid shaderMaterial, Rid shader)
    {
        NativeCalls.godot_icall_2_430(MethodBind32, GodotObject.GetPtr(Singleton), shaderMaterial, shader);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialSetParam, 3477296213ul);

    /// <summary>
    /// <para>Sets a material's parameter.</para>
    /// </summary>
    public static void MaterialSetParam(Rid material, StringName parameter, Variant value)
    {
        NativeCalls.godot_icall_3_1128(MethodBind33, GodotObject.GetPtr(Singleton), material, (godot_string_name)(parameter?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialGetParam, 2621281810ul);

    /// <summary>
    /// <para>Returns the value of a certain material's parameter.</para>
    /// </summary>
    public static Variant MaterialGetParam(Rid material, StringName parameter)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind34, GodotObject.GetPtr(Singleton), material, (godot_string_name)(parameter?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialSetRenderPriority, 3411492887ul);

    /// <summary>
    /// <para>Sets a material's render priority.</para>
    /// </summary>
    public static void MaterialSetRenderPriority(Rid material, int priority)
    {
        NativeCalls.godot_icall_2_426(MethodBind35, GodotObject.GetPtr(Singleton), material, priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialSetNextPass, 395945892ul);

    /// <summary>
    /// <para>Sets an object's next material.</para>
    /// </summary>
    public static void MaterialSetNextPass(Rid material, Rid nextMaterial)
    {
        NativeCalls.godot_icall_2_430(MethodBind36, GodotObject.GetPtr(Singleton), material, nextMaterial);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MaterialSetUseDebanding, 2586408642ul);

    /// <summary>
    /// <para>When using the Mobile renderer, <see cref="Godot.RenderingServer.MaterialSetUseDebanding(bool)"/> can be used to enable or disable the debanding feature of 3D materials (<see cref="Godot.BaseMaterial3D"/> and <see cref="Godot.ShaderMaterial"/>).</para>
    /// <para><see cref="Godot.RenderingServer.MaterialSetUseDebanding(bool)"/> has no effect when using the Compatibility or Forward+ renderer. In Forward+, <see cref="Godot.Viewport"/> debanding can be used instead.</para>
    /// <para>See also <c>ProjectSettings.rendering/anti_aliasing/quality/use_debanding</c> and <see cref="Godot.RenderingServer.ViewportSetUseDebanding(Rid, bool)"/>.</para>
    /// </summary>
    public static void MaterialSetUseDebanding(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind37, GodotObject.GetPtr(Singleton), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshCreateFromSurfaces, 4291747531ul);

    public static Rid MeshCreateFromSurfaces(Godot.Collections.Array<Godot.Collections.Dictionary> surfaces, int blendShapeCount = 0)
    {
        return NativeCalls.godot_icall_2_1118(MethodBind38, GodotObject.GetPtr(Singleton), (godot_array)(surfaces ?? new()).NativeValue, blendShapeCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new mesh and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>mesh_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this mesh to an instance using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public static Rid MeshCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind39, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatOffset, 2981368685ul);

    /// <summary>
    /// <para>Returns the offset of a given attribute by <paramref name="arrayIndex"/> in the start of its respective buffer.</para>
    /// </summary>
    public static uint MeshSurfaceGetFormatOffset(RenderingServer.ArrayFormat format, int vertexCount, int arrayIndex)
    {
        return NativeCalls.godot_icall_3_1129(MethodBind40, GodotObject.GetPtr(Singleton), (int)format, vertexCount, arrayIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatVertexStride, 3188363337ul);

    /// <summary>
    /// <para>Returns the stride of the vertex positions for a mesh with given <paramref name="format"/>. Note importantly that vertex positions are stored consecutively and are not interleaved with the other attributes in the vertex buffer (normals and tangents).</para>
    /// </summary>
    public static uint MeshSurfaceGetFormatVertexStride(RenderingServer.ArrayFormat format, int vertexCount)
    {
        return NativeCalls.godot_icall_2_1130(MethodBind41, GodotObject.GetPtr(Singleton), (int)format, vertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatNormalTangentStride, 3188363337ul);

    /// <summary>
    /// <para>Returns the stride of the combined normals and tangents for a mesh with given <paramref name="format"/>. Note importantly that, while normals and tangents are in the vertex buffer with vertices, they are only interleaved with each other and so have a different stride than vertex positions.</para>
    /// </summary>
    public static uint MeshSurfaceGetFormatNormalTangentStride(RenderingServer.ArrayFormat format, int vertexCount)
    {
        return NativeCalls.godot_icall_2_1130(MethodBind42, GodotObject.GetPtr(Singleton), (int)format, vertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatAttributeStride, 3188363337ul);

    /// <summary>
    /// <para>Returns the stride of the attribute buffer for a mesh with given <paramref name="format"/>.</para>
    /// </summary>
    public static uint MeshSurfaceGetFormatAttributeStride(RenderingServer.ArrayFormat format, int vertexCount)
    {
        return NativeCalls.godot_icall_2_1130(MethodBind43, GodotObject.GetPtr(Singleton), (int)format, vertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatSkinStride, 3188363337ul);

    /// <summary>
    /// <para>Returns the stride of the skin buffer for a mesh with given <paramref name="format"/>.</para>
    /// </summary>
    public static uint MeshSurfaceGetFormatSkinStride(RenderingServer.ArrayFormat format, int vertexCount)
    {
        return NativeCalls.godot_icall_2_1130(MethodBind44, GodotObject.GetPtr(Singleton), (int)format, vertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetFormatIndexStride, 3188363337ul);

    /// <summary>
    /// <para>Returns the stride of the index buffer for a mesh with the given <paramref name="format"/>.</para>
    /// </summary>
    public static uint MeshSurfaceGetFormatIndexStride(RenderingServer.ArrayFormat format, int vertexCount)
    {
        return NativeCalls.godot_icall_2_1130(MethodBind45, GodotObject.GetPtr(Singleton), (int)format, vertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshAddSurface, 1217542888ul);

    public static void MeshAddSurface(Rid mesh, Godot.Collections.Dictionary surface)
    {
        NativeCalls.godot_icall_2_1131(MethodBind46, GodotObject.GetPtr(Singleton), mesh, (godot_dictionary)(surface ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshAddSurfaceFromArrays, 2342446560ul);

    public static void MeshAddSurfaceFromArrays(Rid mesh, RenderingServer.PrimitiveType primitive, Godot.Collections.Array arrays, Godot.Collections.Array blendShapes = null, Godot.Collections.Dictionary lods = null, RenderingServer.ArrayFormat compressFormat = (RenderingServer.ArrayFormat)(0))
    {
        NativeCalls.godot_icall_6_1132(MethodBind47, GodotObject.GetPtr(Singleton), mesh, (int)primitive, (godot_array)(arrays ?? new()).NativeValue, (godot_array)(blendShapes ?? new()).NativeValue, (godot_dictionary)(lods ?? new()).NativeValue, (int)compressFormat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshGetBlendShapeCount, 2198884583ul);

    /// <summary>
    /// <para>Returns a mesh's blend shape count.</para>
    /// </summary>
    public static int MeshGetBlendShapeCount(Rid mesh)
    {
        return NativeCalls.godot_icall_1_835(MethodBind48, GodotObject.GetPtr(Singleton), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSetBlendShapeMode, 1294662092ul);

    /// <summary>
    /// <para>Sets a mesh's blend shape mode.</para>
    /// </summary>
    public static void MeshSetBlendShapeMode(Rid mesh, RenderingServer.BlendShapeMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind49, GodotObject.GetPtr(Singleton), mesh, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshGetBlendShapeMode, 4282291819ul);

    /// <summary>
    /// <para>Returns a mesh's blend shape mode.</para>
    /// </summary>
    public static RenderingServer.BlendShapeMode MeshGetBlendShapeMode(Rid mesh)
    {
        return (RenderingServer.BlendShapeMode)NativeCalls.godot_icall_1_835(MethodBind50, GodotObject.GetPtr(Singleton), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceSetMaterial, 2310537182ul);

    /// <summary>
    /// <para>Sets a mesh's surface's material.</para>
    /// </summary>
    public static void MeshSurfaceSetMaterial(Rid mesh, int surface, Rid material)
    {
        NativeCalls.godot_icall_3_833(MethodBind51, GodotObject.GetPtr(Singleton), mesh, surface, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetMaterial, 1066463050ul);

    /// <summary>
    /// <para>Returns a mesh's surface's material.</para>
    /// </summary>
    public static Rid MeshSurfaceGetMaterial(Rid mesh, int surface)
    {
        return NativeCalls.godot_icall_2_830(MethodBind52, GodotObject.GetPtr(Singleton), mesh, surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshGetSurface, 186674697ul);

    public static Godot.Collections.Dictionary MeshGetSurface(Rid mesh, int surface)
    {
        return NativeCalls.godot_icall_2_1133(MethodBind53, GodotObject.GetPtr(Singleton), mesh, surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetArrays, 1778388067ul);

    /// <summary>
    /// <para>Returns a mesh's surface's buffer arrays.</para>
    /// </summary>
    public static Godot.Collections.Array MeshSurfaceGetArrays(Rid mesh, int surface)
    {
        return NativeCalls.godot_icall_2_1134(MethodBind54, GodotObject.GetPtr(Singleton), mesh, surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceGetBlendShapeArrays, 1778388067ul);

    /// <summary>
    /// <para>Returns a mesh's surface's arrays for blend shapes.</para>
    /// </summary>
    public static Godot.Collections.Array<Godot.Collections.Array> MeshSurfaceGetBlendShapeArrays(Rid mesh, int surface)
    {
        return new Godot.Collections.Array<Godot.Collections.Array>(NativeCalls.godot_icall_2_1134(MethodBind55, GodotObject.GetPtr(Singleton), mesh, surface));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshGetSurfaceCount, 2198884583ul);

    /// <summary>
    /// <para>Returns a mesh's number of surfaces.</para>
    /// </summary>
    public static int MeshGetSurfaceCount(Rid mesh)
    {
        return NativeCalls.godot_icall_1_835(MethodBind56, GodotObject.GetPtr(Singleton), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSetCustomAabb, 3696536120ul);

    /// <summary>
    /// <para>Sets a mesh's custom aabb.</para>
    /// </summary>
    public static unsafe void MeshSetCustomAabb(Rid mesh, Aabb aabb)
    {
        NativeCalls.godot_icall_2_1135(MethodBind57, GodotObject.GetPtr(Singleton), mesh, &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshGetCustomAabb, 974181306ul);

    /// <summary>
    /// <para>Returns a mesh's custom aabb.</para>
    /// </summary>
    public static Aabb MeshGetCustomAabb(Rid mesh)
    {
        return NativeCalls.godot_icall_1_876(MethodBind58, GodotObject.GetPtr(Singleton), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceRemove, 3411492887ul);

    /// <summary>
    /// <para>Removes the surface at the given index from the Mesh, shifting surfaces with higher index down by one.</para>
    /// </summary>
    public static void MeshSurfaceRemove(Rid mesh, int surface)
    {
        NativeCalls.godot_icall_2_426(MethodBind59, GodotObject.GetPtr(Singleton), mesh, surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshClear, 2722037293ul);

    /// <summary>
    /// <para>Removes all surfaces from a mesh.</para>
    /// </summary>
    public static void MeshClear(Rid mesh)
    {
        NativeCalls.godot_icall_1_286(MethodBind60, GodotObject.GetPtr(Singleton), mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceUpdateVertexRegion, 2900195149ul);

    public static void MeshSurfaceUpdateVertexRegion(Rid mesh, int surface, int offset, byte[] data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind61, GodotObject.GetPtr(Singleton), mesh, surface, offset, data);
    }

    public static void MeshSurfaceUpdateVertexRegion(Rid mesh, int surface, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind61, GodotObject.GetPtr(Singleton), mesh, surface, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceUpdateAttributeRegion, 2900195149ul);

    public static void MeshSurfaceUpdateAttributeRegion(Rid mesh, int surface, int offset, byte[] data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind62, GodotObject.GetPtr(Singleton), mesh, surface, offset, data);
    }

    public static void MeshSurfaceUpdateAttributeRegion(Rid mesh, int surface, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind62, GodotObject.GetPtr(Singleton), mesh, surface, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceUpdateSkinRegion, 2900195149ul);

    public static void MeshSurfaceUpdateSkinRegion(Rid mesh, int surface, int offset, byte[] data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind63, GodotObject.GetPtr(Singleton), mesh, surface, offset, data);
    }

    public static void MeshSurfaceUpdateSkinRegion(Rid mesh, int surface, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind63, GodotObject.GetPtr(Singleton), mesh, surface, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSurfaceUpdateIndexRegion, 2900195149ul);

    /// <summary>
    /// <para>Updates the index buffer of the mesh surface with the given <paramref name="data"/>. The expected data are 16 or 32-bit unsigned integers, which can be determined with <see cref="Godot.RenderingServer.MeshSurfaceGetFormatIndexStride(RenderingServer.ArrayFormat, int)"/>.</para>
    /// </summary>
    public static void MeshSurfaceUpdateIndexRegion(Rid mesh, int surface, int offset, byte[] data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind64, GodotObject.GetPtr(Singleton), mesh, surface, offset, data);
    }

    /// <summary>
    /// <para>Updates the index buffer of the mesh surface with the given <paramref name="data"/>. The expected data are 16 or 32-bit unsigned integers, which can be determined with <see cref="Godot.RenderingServer.MeshSurfaceGetFormatIndexStride(RenderingServer.ArrayFormat, int)"/>.</para>
    /// </summary>
    public static void MeshSurfaceUpdateIndexRegion(Rid mesh, int surface, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_4_1136(MethodBind64, GodotObject.GetPtr(Singleton), mesh, surface, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MeshSetShadowMesh, 395945892ul);

    public static void MeshSetShadowMesh(Rid mesh, Rid shadowMesh)
    {
        NativeCalls.godot_icall_2_430(MethodBind65, GodotObject.GetPtr(Singleton), mesh, shadowMesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new multimesh on the RenderingServer and returns an <see cref="Godot.Rid"/> handle. This RID will be used in all <c>multimesh_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this multimesh to an instance using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.MultiMesh"/>.</para>
    /// </summary>
    public static Rid MultimeshCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind66, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshAllocateData, 557240154ul);

    public static void MultimeshAllocateData(Rid multimesh, int instances, RenderingServer.MultimeshTransformFormat transformFormat, bool colorFormat = false, bool customDataFormat = false, bool useIndirect = false)
    {
        NativeCalls.godot_icall_6_1137(MethodBind67, GodotObject.GetPtr(Singleton), multimesh, instances, (int)transformFormat, colorFormat.ToGodotBool(), customDataFormat.ToGodotBool(), useIndirect.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetInstanceCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of instances allocated for this multimesh.</para>
    /// </summary>
    public static int MultimeshGetInstanceCount(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_835(MethodBind68, GodotObject.GetPtr(Singleton), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetMesh, 395945892ul);

    /// <summary>
    /// <para>Sets the mesh to be drawn by the multimesh. Equivalent to <see cref="Godot.MultiMesh.Mesh"/>.</para>
    /// </summary>
    public static void MultimeshSetMesh(Rid multimesh, Rid mesh)
    {
        NativeCalls.godot_icall_2_430(MethodBind69, GodotObject.GetPtr(Singleton), multimesh, mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceSetTransform, 675327471ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform3D"/> for this instance. Equivalent to <see cref="Godot.MultiMesh.SetInstanceTransform(int, Transform3D)"/>.</para>
    /// </summary>
    public static unsafe void MultimeshInstanceSetTransform(Rid multimesh, int index, Transform3D transform)
    {
        NativeCalls.godot_icall_3_1001(MethodBind70, GodotObject.GetPtr(Singleton), multimesh, index, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceSetTransform2D, 736082694ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform2D"/> for this instance. For use when multimesh is used in 2D. Equivalent to <see cref="Godot.MultiMesh.SetInstanceTransform2D(int, Transform2D)"/>.</para>
    /// </summary>
    public static unsafe void MultimeshInstanceSetTransform2D(Rid multimesh, int index, Transform2D transform)
    {
        NativeCalls.godot_icall_3_991(MethodBind71, GodotObject.GetPtr(Singleton), multimesh, index, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceSetColor, 176975443ul);

    /// <summary>
    /// <para>Sets the color by which this instance will be modulated. Equivalent to <see cref="Godot.MultiMesh.SetInstanceColor(int, Color)"/>.</para>
    /// </summary>
    public static unsafe void MultimeshInstanceSetColor(Rid multimesh, int index, Color color)
    {
        NativeCalls.godot_icall_3_1138(MethodBind72, GodotObject.GetPtr(Singleton), multimesh, index, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceSetCustomData, 176975443ul);

    /// <summary>
    /// <para>Sets the custom data for this instance. Custom data is passed as a <see cref="Godot.Color"/>, but is interpreted as a <c>vec4</c> in the shader. Equivalent to <see cref="Godot.MultiMesh.SetInstanceCustomData(int, Color)"/>.</para>
    /// </summary>
    public static unsafe void MultimeshInstanceSetCustomData(Rid multimesh, int index, Color customData)
    {
        NativeCalls.godot_icall_3_1138(MethodBind73, GodotObject.GetPtr(Singleton), multimesh, index, &customData);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetMesh, 3814569979ul);

    /// <summary>
    /// <para>Returns the RID of the mesh that will be used in drawing this multimesh.</para>
    /// </summary>
    public static Rid MultimeshGetMesh(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_855(MethodBind74, GodotObject.GetPtr(Singleton), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetAabb, 974181306ul);

    /// <summary>
    /// <para>Calculates and returns the axis-aligned bounding box that encloses all instances within the multimesh.</para>
    /// </summary>
    public static Aabb MultimeshGetAabb(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_876(MethodBind75, GodotObject.GetPtr(Singleton), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetCustomAabb, 3696536120ul);

    /// <summary>
    /// <para>Sets the custom AABB for this MultiMesh resource.</para>
    /// </summary>
    public static unsafe void MultimeshSetCustomAabb(Rid multimesh, Aabb aabb)
    {
        NativeCalls.godot_icall_2_1135(MethodBind76, GodotObject.GetPtr(Singleton), multimesh, &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetCustomAabb, 974181306ul);

    /// <summary>
    /// <para>Returns the custom AABB defined for this MultiMesh resource.</para>
    /// </summary>
    public static Aabb MultimeshGetCustomAabb(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_876(MethodBind77, GodotObject.GetPtr(Singleton), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceGetTransform, 1050775521ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform3D"/> of the specified instance.</para>
    /// </summary>
    public static Transform3D MultimeshInstanceGetTransform(Rid multimesh, int index)
    {
        return NativeCalls.godot_icall_2_1002(MethodBind78, GodotObject.GetPtr(Singleton), multimesh, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceGetTransform2D, 1324854622ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform2D"/> of the specified instance. For use when the multimesh is set to use 2D transforms.</para>
    /// </summary>
    public static Transform2D MultimeshInstanceGetTransform2D(Rid multimesh, int index)
    {
        return NativeCalls.godot_icall_2_992(MethodBind79, GodotObject.GetPtr(Singleton), multimesh, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceGetColor, 2946315076ul);

    /// <summary>
    /// <para>Returns the color by which the specified instance will be modulated.</para>
    /// </summary>
    public static Color MultimeshInstanceGetColor(Rid multimesh, int index)
    {
        return NativeCalls.godot_icall_2_1139(MethodBind80, GodotObject.GetPtr(Singleton), multimesh, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceGetCustomData, 2946315076ul);

    /// <summary>
    /// <para>Returns the custom data associated with the specified instance.</para>
    /// </summary>
    public static Color MultimeshInstanceGetCustomData(Rid multimesh, int index)
    {
        return NativeCalls.godot_icall_2_1139(MethodBind81, GodotObject.GetPtr(Singleton), multimesh, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetVisibleInstances, 3411492887ul);

    /// <summary>
    /// <para>Sets the number of instances visible at a given time. If -1, all instances that have been allocated are drawn. Equivalent to <see cref="Godot.MultiMesh.VisibleInstanceCount"/>.</para>
    /// </summary>
    public static void MultimeshSetVisibleInstances(Rid multimesh, int visible)
    {
        NativeCalls.godot_icall_2_426(MethodBind82, GodotObject.GetPtr(Singleton), multimesh, visible);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetVisibleInstances, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of visible instances for this multimesh.</para>
    /// </summary>
    public static int MultimeshGetVisibleInstances(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_835(MethodBind83, GodotObject.GetPtr(Singleton), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetBuffer, 2960552364ul);

    /// <summary>
    /// <para>Set the entire data to use for drawing the <paramref name="multimesh"/> at once to <paramref name="buffer"/> (such as instance transforms and colors). <paramref name="buffer"/>'s size must match the number of instances multiplied by the per-instance data size (which depends on the enabled MultiMesh fields). Otherwise, an error message is printed and nothing is rendered. See also <see cref="Godot.RenderingServer.MultimeshGetBuffer(Rid)"/>.</para>
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
    public static void MultimeshSetBuffer(Rid multimesh, float[] buffer)
    {
        NativeCalls.godot_icall_2_1140(MethodBind84, GodotObject.GetPtr(Singleton), multimesh, buffer);
    }

    /// <summary>
    /// <para>Set the entire data to use for drawing the <paramref name="multimesh"/> at once to <paramref name="buffer"/> (such as instance transforms and colors). <paramref name="buffer"/>'s size must match the number of instances multiplied by the per-instance data size (which depends on the enabled MultiMesh fields). Otherwise, an error message is printed and nothing is rendered. See also <see cref="Godot.RenderingServer.MultimeshGetBuffer(Rid)"/>.</para>
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
    public static void MultimeshSetBuffer(Rid multimesh, ReadOnlySpan<float> buffer)
    {
        NativeCalls.godot_icall_2_1140(MethodBind84, GodotObject.GetPtr(Singleton), multimesh, buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetCommandBufferRdRid, 3814569979ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.RenderingDevice"/> <see cref="Godot.Rid"/> handle of the <see cref="Godot.MultiMesh"/> command buffer. This <see cref="Godot.Rid"/> is only valid if <c>use_indirect</c> is set to <see langword="true"/> when allocating data through <see cref="Godot.RenderingServer.MultimeshAllocateData(Rid, int, RenderingServer.MultimeshTransformFormat, bool, bool, bool)"/>. It can be used to directly modify the instance count via buffer.</para>
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
    public static Rid MultimeshGetCommandBufferRdRid(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_855(MethodBind85, GodotObject.GetPtr(Singleton), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetBufferRdRid, 3814569979ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.RenderingDevice"/> <see cref="Godot.Rid"/> handle of the <see cref="Godot.MultiMesh"/>, which can be used as any other buffer on the Rendering Device.</para>
    /// </summary>
    public static Rid MultimeshGetBufferRdRid(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_855(MethodBind86, GodotObject.GetPtr(Singleton), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshGetBuffer, 3964669176ul);

    /// <summary>
    /// <para>Returns the MultiMesh data (such as instance transforms, colors, etc.). See <see cref="Godot.RenderingServer.MultimeshSetBuffer(Rid, float[])"/> for details on the returned data.</para>
    /// <para><b>Note:</b> If the buffer is in the engine's internal cache, it will have to be fetched from GPU memory and possibly decompressed. This means <see cref="Godot.RenderingServer.MultimeshGetBuffer(Rid)"/> is potentially a slow operation and should be avoided whenever possible.</para>
    /// </summary>
    public static float[] MultimeshGetBuffer(Rid multimesh)
    {
        return NativeCalls.godot_icall_1_1141(MethodBind87, GodotObject.GetPtr(Singleton), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetBufferInterpolated, 659844711ul);

    /// <summary>
    /// <para>Alternative version of <see cref="Godot.RenderingServer.MultimeshSetBuffer(Rid, float[])"/> for use with physics interpolation.</para>
    /// <para>Takes both an array of current data and an array of data for the previous physics tick.</para>
    /// </summary>
    public static void MultimeshSetBufferInterpolated(Rid multimesh, float[] buffer, float[] bufferPrevious)
    {
        NativeCalls.godot_icall_3_1142(MethodBind88, GodotObject.GetPtr(Singleton), multimesh, buffer, bufferPrevious);
    }

    /// <summary>
    /// <para>Alternative version of <see cref="Godot.RenderingServer.MultimeshSetBuffer(Rid, float[])"/> for use with physics interpolation.</para>
    /// <para>Takes both an array of current data and an array of data for the previous physics tick.</para>
    /// </summary>
    public static void MultimeshSetBufferInterpolated(Rid multimesh, ReadOnlySpan<float> buffer, ReadOnlySpan<float> bufferPrevious)
    {
        NativeCalls.godot_icall_3_1142(MethodBind88, GodotObject.GetPtr(Singleton), multimesh, buffer, bufferPrevious);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetPhysicsInterpolated, 1265174801ul);

    /// <summary>
    /// <para>Turns on and off physics interpolation for this MultiMesh resource.</para>
    /// </summary>
    public static void MultimeshSetPhysicsInterpolated(Rid multimesh, bool interpolated)
    {
        NativeCalls.godot_icall_2_434(MethodBind89, GodotObject.GetPtr(Singleton), multimesh, interpolated.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshSetPhysicsInterpolationQuality, 3934808223ul);

    /// <summary>
    /// <para>Sets the physics interpolation quality for the <see cref="Godot.MultiMesh"/>.</para>
    /// <para>A value of <see cref="Godot.RenderingServer.MultimeshPhysicsInterpolationQuality.Fast"/> gives fast but low quality interpolation, a value of <see cref="Godot.RenderingServer.MultimeshPhysicsInterpolationQuality.High"/> gives slower but higher quality interpolation.</para>
    /// </summary>
    public static void MultimeshSetPhysicsInterpolationQuality(Rid multimesh, RenderingServer.MultimeshPhysicsInterpolationQuality quality)
    {
        NativeCalls.godot_icall_2_426(MethodBind90, GodotObject.GetPtr(Singleton), multimesh, (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstanceResetPhysicsInterpolation, 3411492887ul);

    /// <summary>
    /// <para>Prevents physics interpolation for the specified instance during the current physics tick.</para>
    /// <para>This is useful when moving an instance to a new location, to give an instantaneous change rather than interpolation from the previous location.</para>
    /// </summary>
    public static void MultimeshInstanceResetPhysicsInterpolation(Rid multimesh, int index)
    {
        NativeCalls.godot_icall_2_426(MethodBind91, GodotObject.GetPtr(Singleton), multimesh, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshInstancesResetPhysicsInterpolation, 2722037293ul);

    /// <summary>
    /// <para>Prevents physics interpolation for all instances during the current physics tick.</para>
    /// <para>This is useful when moving all instances to new locations, to give instantaneous changes rather than interpolation from the previous locations.</para>
    /// </summary>
    public static void MultimeshInstancesResetPhysicsInterpolation(Rid multimesh)
    {
        NativeCalls.godot_icall_1_286(MethodBind92, GodotObject.GetPtr(Singleton), multimesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a skeleton and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>skeleton_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// </summary>
    public static Rid SkeletonCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind93, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonAllocateData, 1904426712ul);

    public static void SkeletonAllocateData(Rid skeleton, int bones, bool is2DSkeleton = false)
    {
        NativeCalls.godot_icall_3_439(MethodBind94, GodotObject.GetPtr(Singleton), skeleton, bones, is2DSkeleton.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonGetBoneCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of bones allocated for this skeleton.</para>
    /// </summary>
    public static int SkeletonGetBoneCount(Rid skeleton)
    {
        return NativeCalls.godot_icall_1_835(MethodBind95, GodotObject.GetPtr(Singleton), skeleton);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonBoneSetTransform, 675327471ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform3D"/> for a specific bone of this skeleton.</para>
    /// </summary>
    public static unsafe void SkeletonBoneSetTransform(Rid skeleton, int bone, Transform3D transform)
    {
        NativeCalls.godot_icall_3_1001(MethodBind96, GodotObject.GetPtr(Singleton), skeleton, bone, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonBoneGetTransform, 1050775521ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform3D"/> set for a specific bone of this skeleton.</para>
    /// </summary>
    public static Transform3D SkeletonBoneGetTransform(Rid skeleton, int bone)
    {
        return NativeCalls.godot_icall_2_1002(MethodBind97, GodotObject.GetPtr(Singleton), skeleton, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonBoneSetTransform2D, 736082694ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform2D"/> for a specific bone of this skeleton.</para>
    /// </summary>
    public static unsafe void SkeletonBoneSetTransform2D(Rid skeleton, int bone, Transform2D transform)
    {
        NativeCalls.godot_icall_3_991(MethodBind98, GodotObject.GetPtr(Singleton), skeleton, bone, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonBoneGetTransform2D, 1324854622ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform2D"/> set for a specific bone of this skeleton.</para>
    /// </summary>
    public static Transform2D SkeletonBoneGetTransform2D(Rid skeleton, int bone)
    {
        return NativeCalls.godot_icall_2_992(MethodBind99, GodotObject.GetPtr(Singleton), skeleton, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkeletonSetBaseTransform2D, 1246044741ul);

    public static unsafe void SkeletonSetBaseTransform2D(Rid skeleton, Transform2D baseTransform)
    {
        NativeCalls.godot_icall_2_429(MethodBind100, GodotObject.GetPtr(Singleton), skeleton, &baseTransform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DirectionalLightCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a directional light and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID can be used in most <c>light_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this directional light to an instance using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.DirectionalLight3D"/>.</para>
    /// </summary>
    public static Rid DirectionalLightCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind101, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.OmniLightCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new omni light and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID can be used in most <c>light_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this omni light to an instance using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.OmniLight3D"/>.</para>
    /// </summary>
    public static Rid OmniLightCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind102, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SpotLightCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a spot light and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID can be used in most <c>light_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this spot light to an instance using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// </summary>
    public static Rid SpotLightCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind103, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetColor, 2948539648ul);

    /// <summary>
    /// <para>Sets the color of the light. Equivalent to <see cref="Godot.Light3D.LightColor"/>.</para>
    /// </summary>
    public static unsafe void LightSetColor(Rid light, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind104, GodotObject.GetPtr(Singleton), light, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetParam, 501936875ul);

    /// <summary>
    /// <para>Sets the specified 3D light parameter. Equivalent to <see cref="Godot.Light3D.SetParam(Light3D.Param, float)"/>.</para>
    /// </summary>
    public static void LightSetParam(Rid light, RenderingServer.LightParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind105, GodotObject.GetPtr(Singleton), light, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetShadow, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, light will cast shadows. Equivalent to <see cref="Godot.Light3D.ShadowEnabled"/>.</para>
    /// </summary>
    public static void LightSetShadow(Rid light, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind106, GodotObject.GetPtr(Singleton), light, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetProjector, 395945892ul);

    /// <summary>
    /// <para>Sets the projector texture to use for the specified 3D light. Equivalent to <see cref="Godot.Light3D.LightProjector"/>.</para>
    /// </summary>
    public static void LightSetProjector(Rid light, Rid texture)
    {
        NativeCalls.godot_icall_2_430(MethodBind107, GodotObject.GetPtr(Singleton), light, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetNegative, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the 3D light will subtract light instead of adding light. Equivalent to <see cref="Godot.Light3D.LightNegative"/>.</para>
    /// </summary>
    public static void LightSetNegative(Rid light, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind108, GodotObject.GetPtr(Singleton), light, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the cull mask for this 3D light. Lights only affect objects in the selected layers. Equivalent to <see cref="Godot.Light3D.LightCullMask"/>.</para>
    /// </summary>
    public static void LightSetCullMask(Rid light, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind109, GodotObject.GetPtr(Singleton), light, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetDistanceFade, 1622292572ul);

    /// <summary>
    /// <para>Sets the distance fade for this 3D light. This acts as a form of level of detail (LOD) and can be used to improve performance. Equivalent to <see cref="Godot.Light3D.DistanceFadeEnabled"/>, <see cref="Godot.Light3D.DistanceFadeBegin"/>, <see cref="Godot.Light3D.DistanceFadeShadow"/>, and <see cref="Godot.Light3D.DistanceFadeLength"/>.</para>
    /// </summary>
    public static void LightSetDistanceFade(Rid decal, bool enabled, float begin, float shadow, float length)
    {
        NativeCalls.godot_icall_5_1143(MethodBind110, GodotObject.GetPtr(Singleton), decal, enabled.ToGodotBool(), begin, shadow, length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetReverseCullFaceMode, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, reverses the backface culling of the mesh. This can be useful when you have a flat mesh that has a light behind it. If you need to cast a shadow on both sides of the mesh, set the mesh to use double-sided shadows with <see cref="Godot.RenderingServer.InstanceGeometrySetCastShadowsSetting(Rid, RenderingServer.ShadowCastingSetting)"/>. Equivalent to <see cref="Godot.Light3D.ShadowReverseCullFace"/>.</para>
    /// </summary>
    public static void LightSetReverseCullFaceMode(Rid light, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind111, GodotObject.GetPtr(Singleton), light, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetShadowCasterMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the shadow caster mask for this 3D light. Shadows will only be cast using objects in the selected layers. Equivalent to <see cref="Godot.Light3D.ShadowCasterMask"/>.</para>
    /// </summary>
    public static void LightSetShadowCasterMask(Rid light, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind112, GodotObject.GetPtr(Singleton), light, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetBakeMode, 1048525260ul);

    /// <summary>
    /// <para>Sets the bake mode to use for the specified 3D light. Equivalent to <see cref="Godot.Light3D.LightBakeMode"/>.</para>
    /// </summary>
    public static void LightSetBakeMode(Rid light, RenderingServer.LightBakeMode bakeMode)
    {
        NativeCalls.godot_icall_2_426(MethodBind113, GodotObject.GetPtr(Singleton), light, (int)bakeMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightSetMaxSdfgiCascade, 3411492887ul);

    /// <summary>
    /// <para>Sets the maximum SDFGI cascade in which the 3D light's indirect lighting is rendered. Higher values allow the light to be rendered in SDFGI further away from the camera.</para>
    /// </summary>
    public static void LightSetMaxSdfgiCascade(Rid light, uint cascade)
    {
        NativeCalls.godot_icall_2_856(MethodBind114, GodotObject.GetPtr(Singleton), light, cascade);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightOmniSetShadowMode, 2552677200ul);

    /// <summary>
    /// <para>Sets whether to use a dual paraboloid or a cubemap for the shadow map. Dual paraboloid is faster but may suffer from artifacts. Equivalent to <see cref="Godot.OmniLight3D.OmniShadowMode"/>.</para>
    /// </summary>
    public static void LightOmniSetShadowMode(Rid light, RenderingServer.LightOmniShadowMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind115, GodotObject.GetPtr(Singleton), light, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightDirectionalSetShadowMode, 380462970ul);

    /// <summary>
    /// <para>Sets the shadow mode for this directional light. Equivalent to <see cref="Godot.DirectionalLight3D.DirectionalShadowMode"/>.</para>
    /// </summary>
    public static void LightDirectionalSetShadowMode(Rid light, RenderingServer.LightDirectionalShadowMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind116, GodotObject.GetPtr(Singleton), light, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightDirectionalSetBlendSplits, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, this directional light will blend between shadow map splits resulting in a smoother transition between them. Equivalent to <see cref="Godot.DirectionalLight3D.DirectionalShadowBlendSplits"/>.</para>
    /// </summary>
    public static void LightDirectionalSetBlendSplits(Rid light, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind117, GodotObject.GetPtr(Singleton), light, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightDirectionalSetSkyMode, 2559740754ul);

    /// <summary>
    /// <para>If <see langword="true"/>, this light will not be used for anything except sky shaders. Use this for lights that impact your sky shader that you may want to hide from affecting the rest of the scene. For example, you may want to enable this when the sun in your sky shader falls below the horizon.</para>
    /// </summary>
    public static void LightDirectionalSetSkyMode(Rid light, RenderingServer.LightDirectionalSkyMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind118, GodotObject.GetPtr(Singleton), light, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightProjectorsSetFilter, 43944325ul);

    /// <summary>
    /// <para>Sets the texture filter mode to use when rendering light projectors. This parameter is global and cannot be set on a per-light basis.</para>
    /// </summary>
    public static void LightProjectorsSetFilter(RenderingServer.LightProjectorFilter filter)
    {
        NativeCalls.godot_icall_1_38(MethodBind119, GodotObject.GetPtr(Singleton), (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapsSetBicubicFilter, 2586408642ul);

    /// <summary>
    /// <para>Toggles whether a bicubic filter should be used when lightmaps are sampled. This smoothens their appearance at a performance cost.</para>
    /// </summary>
    public static void LightmapsSetBicubicFilter(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind120, GodotObject.GetPtr(Singleton), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.PositionalSoftShadowFilterSetQuality, 3613045266ul);

    /// <summary>
    /// <para>Sets the filter quality for omni and spot light shadows in 3D. See also <c>ProjectSettings.rendering/lights_and_shadows/positional_shadow/soft_shadow_filter_quality</c>. This parameter is global and cannot be set on a per-viewport basis.</para>
    /// </summary>
    public static void PositionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind121, GodotObject.GetPtr(Singleton), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DirectionalSoftShadowFilterSetQuality, 3613045266ul);

    /// <summary>
    /// <para>Sets the filter <paramref name="quality"/> for directional light shadows in 3D. See also <c>ProjectSettings.rendering/lights_and_shadows/directional_shadow/soft_shadow_filter_quality</c>. This parameter is global and cannot be set on a per-viewport basis.</para>
    /// </summary>
    public static void DirectionalSoftShadowFilterSetQuality(RenderingServer.ShadowQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind122, GodotObject.GetPtr(Singleton), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DirectionalShadowAtlasSetSize, 300928843ul);

    /// <summary>
    /// <para>Sets the <paramref name="size"/> of the directional light shadows in 3D. See also <c>ProjectSettings.rendering/lights_and_shadows/directional_shadow/size</c>. This parameter is global and cannot be set on a per-viewport basis.</para>
    /// </summary>
    public static void DirectionalShadowAtlasSetSize(int size, bool is16Bits)
    {
        NativeCalls.godot_icall_2_61(MethodBind123, GodotObject.GetPtr(Singleton), size, is16Bits.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a reflection probe and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>reflection_probe_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this reflection probe to an instance using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.ReflectionProbe"/>.</para>
    /// </summary>
    public static Rid ReflectionProbeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind124, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetUpdateMode, 3853670147ul);

    /// <summary>
    /// <para>Sets how often the reflection probe updates. Can either be once or every frame.</para>
    /// </summary>
    public static void ReflectionProbeSetUpdateMode(Rid probe, RenderingServer.ReflectionProbeUpdateMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind125, GodotObject.GetPtr(Singleton), probe, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetIntensity, 1794382983ul);

    /// <summary>
    /// <para>Sets the intensity of the reflection probe. Intensity modulates the strength of the reflection. Equivalent to <see cref="Godot.ReflectionProbe.Intensity"/>.</para>
    /// </summary>
    public static void ReflectionProbeSetIntensity(Rid probe, float intensity)
    {
        NativeCalls.godot_icall_2_816(MethodBind126, GodotObject.GetPtr(Singleton), probe, intensity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetBlendDistance, 1794382983ul);

    /// <summary>
    /// <para>Sets the distance in meters over which a probe blends into the scene.</para>
    /// </summary>
    public static void ReflectionProbeSetBlendDistance(Rid probe, float blendDistance)
    {
        NativeCalls.godot_icall_2_816(MethodBind127, GodotObject.GetPtr(Singleton), probe, blendDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetAmbientMode, 184163074ul);

    /// <summary>
    /// <para>Sets the reflection probe's ambient light mode. Equivalent to <see cref="Godot.ReflectionProbe.AmbientMode"/>.</para>
    /// </summary>
    public static void ReflectionProbeSetAmbientMode(Rid probe, RenderingServer.ReflectionProbeAmbientMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind128, GodotObject.GetPtr(Singleton), probe, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetAmbientColor, 2948539648ul);

    /// <summary>
    /// <para>Sets the reflection probe's custom ambient light color. Equivalent to <see cref="Godot.ReflectionProbe.AmbientColor"/>.</para>
    /// </summary>
    public static unsafe void ReflectionProbeSetAmbientColor(Rid probe, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind129, GodotObject.GetPtr(Singleton), probe, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetAmbientEnergy, 1794382983ul);

    /// <summary>
    /// <para>Sets the reflection probe's custom ambient light energy. Equivalent to <see cref="Godot.ReflectionProbe.AmbientColorEnergy"/>.</para>
    /// </summary>
    public static void ReflectionProbeSetAmbientEnergy(Rid probe, float energy)
    {
        NativeCalls.godot_icall_2_816(MethodBind130, GodotObject.GetPtr(Singleton), probe, energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetMaxDistance, 1794382983ul);

    /// <summary>
    /// <para>Sets the max distance away from the probe an object can be before it is culled. Equivalent to <see cref="Godot.ReflectionProbe.MaxDistance"/>.</para>
    /// </summary>
    public static void ReflectionProbeSetMaxDistance(Rid probe, float distance)
    {
        NativeCalls.godot_icall_2_816(MethodBind131, GodotObject.GetPtr(Singleton), probe, distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetSize, 3227306858ul);

    /// <summary>
    /// <para>Sets the size of the area that the reflection probe will capture. Equivalent to <see cref="Godot.ReflectionProbe.Size"/>.</para>
    /// </summary>
    public static unsafe void ReflectionProbeSetSize(Rid probe, Vector3 size)
    {
        NativeCalls.godot_icall_2_865(MethodBind132, GodotObject.GetPtr(Singleton), probe, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetOriginOffset, 3227306858ul);

    /// <summary>
    /// <para>Sets the origin offset to be used when this reflection probe is in box project mode. Equivalent to <see cref="Godot.ReflectionProbe.OriginOffset"/>.</para>
    /// </summary>
    public static unsafe void ReflectionProbeSetOriginOffset(Rid probe, Vector3 offset)
    {
        NativeCalls.godot_icall_2_865(MethodBind133, GodotObject.GetPtr(Singleton), probe, &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetAsInterior, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, reflections will ignore sky contribution. Equivalent to <see cref="Godot.ReflectionProbe.Interior"/>.</para>
    /// </summary>
    public static void ReflectionProbeSetAsInterior(Rid probe, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind134, GodotObject.GetPtr(Singleton), probe, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetEnableBoxProjection, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, uses box projection. This can make reflections look more correct in certain situations. Equivalent to <see cref="Godot.ReflectionProbe.BoxProjection"/>.</para>
    /// </summary>
    public static void ReflectionProbeSetEnableBoxProjection(Rid probe, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind135, GodotObject.GetPtr(Singleton), probe, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetEnableShadows, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, computes shadows in the reflection probe. This makes the reflection much slower to compute. Equivalent to <see cref="Godot.ReflectionProbe.EnableShadows"/>.</para>
    /// </summary>
    public static void ReflectionProbeSetEnableShadows(Rid probe, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind136, GodotObject.GetPtr(Singleton), probe, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the render cull mask for this reflection probe. Only instances with a matching layer will be reflected by this probe. Equivalent to <see cref="Godot.ReflectionProbe.CullMask"/>.</para>
    /// </summary>
    public static void ReflectionProbeSetCullMask(Rid probe, uint layers)
    {
        NativeCalls.godot_icall_2_856(MethodBind137, GodotObject.GetPtr(Singleton), probe, layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind138 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetReflectionMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the render reflection mask for this reflection probe. Only instances with a matching layer will have reflections applied from this probe. Equivalent to <see cref="Godot.ReflectionProbe.ReflectionMask"/>.</para>
    /// </summary>
    public static void ReflectionProbeSetReflectionMask(Rid probe, uint layers)
    {
        NativeCalls.godot_icall_2_856(MethodBind138, GodotObject.GetPtr(Singleton), probe, layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind139 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetResolution, 3411492887ul);

    /// <summary>
    /// <para>Deprecated. This method does nothing.</para>
    /// </summary>
    [Obsolete("This method has not done anything since Godot 3.")]
    public static void ReflectionProbeSetResolution(Rid probe, int resolution)
    {
        NativeCalls.godot_icall_2_426(MethodBind139, GodotObject.GetPtr(Singleton), probe, resolution);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind140 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReflectionProbeSetMeshLodThreshold, 1794382983ul);

    /// <summary>
    /// <para>Sets the mesh level of detail to use in the reflection probe rendering. Higher values will use less detailed versions of meshes that have LOD variations generated, which can improve performance. Equivalent to <see cref="Godot.ReflectionProbe.MeshLodThreshold"/>.</para>
    /// </summary>
    public static void ReflectionProbeSetMeshLodThreshold(Rid probe, float pixels)
    {
        NativeCalls.godot_icall_2_816(MethodBind140, GodotObject.GetPtr(Singleton), probe, pixels);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind141 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a decal and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>decal_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this decal to an instance using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.Decal"/>.</para>
    /// </summary>
    public static Rid DecalCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind141, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind142 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetSize, 3227306858ul);

    /// <summary>
    /// <para>Sets the <paramref name="size"/> of the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.Size"/>.</para>
    /// </summary>
    public static unsafe void DecalSetSize(Rid decal, Vector3 size)
    {
        NativeCalls.godot_icall_2_865(MethodBind142, GodotObject.GetPtr(Singleton), decal, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind143 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetTexture, 3953344054ul);

    /// <summary>
    /// <para>Sets the <paramref name="texture"/> in the given texture <paramref name="type"/> slot for the specified decal. Equivalent to <see cref="Godot.Decal.SetTexture(Decal.DecalTexture, Texture2D)"/>.</para>
    /// </summary>
    public static void DecalSetTexture(Rid decal, RenderingServer.DecalTexture type, Rid texture)
    {
        NativeCalls.godot_icall_3_833(MethodBind143, GodotObject.GetPtr(Singleton), decal, (int)type, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind144 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetEmissionEnergy, 1794382983ul);

    /// <summary>
    /// <para>Sets the emission <paramref name="energy"/> in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.EmissionEnergy"/>.</para>
    /// </summary>
    public static void DecalSetEmissionEnergy(Rid decal, float energy)
    {
        NativeCalls.godot_icall_2_816(MethodBind144, GodotObject.GetPtr(Singleton), decal, energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind145 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetAlbedoMix, 1794382983ul);

    /// <summary>
    /// <para>Sets the <paramref name="albedoMix"/> in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.AlbedoMix"/>.</para>
    /// </summary>
    public static void DecalSetAlbedoMix(Rid decal, float albedoMix)
    {
        NativeCalls.godot_icall_2_816(MethodBind145, GodotObject.GetPtr(Singleton), decal, albedoMix);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind146 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetModulate, 2948539648ul);

    /// <summary>
    /// <para>Sets the color multiplier in the decal specified by the <paramref name="decal"/> RID to <paramref name="color"/>. Equivalent to <see cref="Godot.Decal.Modulate"/>.</para>
    /// </summary>
    public static unsafe void DecalSetModulate(Rid decal, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind146, GodotObject.GetPtr(Singleton), decal, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind147 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the cull <paramref name="mask"/> in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.CullMask"/>.</para>
    /// </summary>
    public static void DecalSetCullMask(Rid decal, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind147, GodotObject.GetPtr(Singleton), decal, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind148 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetDistanceFade, 2972769666ul);

    /// <summary>
    /// <para>Sets the distance fade parameters in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.DistanceFadeEnabled"/>, <see cref="Godot.Decal.DistanceFadeBegin"/> and <see cref="Godot.Decal.DistanceFadeLength"/>.</para>
    /// </summary>
    public static void DecalSetDistanceFade(Rid decal, bool enabled, float begin, float length)
    {
        NativeCalls.godot_icall_4_1144(MethodBind148, GodotObject.GetPtr(Singleton), decal, enabled.ToGodotBool(), begin, length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind149 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetFade, 2513314492ul);

    /// <summary>
    /// <para>Sets the upper fade (<paramref name="above"/>) and lower fade (<paramref name="below"/>) in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.UpperFade"/> and <see cref="Godot.Decal.LowerFade"/>.</para>
    /// </summary>
    public static void DecalSetFade(Rid decal, float above, float below)
    {
        NativeCalls.godot_icall_3_1145(MethodBind149, GodotObject.GetPtr(Singleton), decal, above, below);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind150 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalSetNormalFade, 1794382983ul);

    /// <summary>
    /// <para>Sets the normal <paramref name="fade"/> in the decal specified by the <paramref name="decal"/> RID. Equivalent to <see cref="Godot.Decal.NormalFade"/>.</para>
    /// </summary>
    public static void DecalSetNormalFade(Rid decal, float fade)
    {
        NativeCalls.godot_icall_2_816(MethodBind150, GodotObject.GetPtr(Singleton), decal, fade);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind151 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecalsSetFilter, 3519875702ul);

    /// <summary>
    /// <para>Sets the texture <paramref name="filter"/> mode to use when rendering decals. This parameter is global and cannot be set on a per-decal basis.</para>
    /// </summary>
    public static void DecalsSetFilter(RenderingServer.DecalFilter filter)
    {
        NativeCalls.godot_icall_1_38(MethodBind151, GodotObject.GetPtr(Singleton), (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind152 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GISetUseHalfResolution, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="halfResolution"/> is <see langword="true"/>, renders <see cref="Godot.VoxelGI"/> and SDFGI (<see cref="Godot.Environment.SdfgiEnabled"/>) buffers at halved resolution on each axis (e.g. 960×540 when the viewport size is 1920×1080). This improves performance significantly when VoxelGI or SDFGI is enabled, at the cost of artifacts that may be visible on polygon edges. The loss in quality becomes less noticeable as the viewport resolution increases. <see cref="Godot.LightmapGI"/> rendering is not affected by this setting. Equivalent to <c>ProjectSettings.rendering/global_illumination/gi/use_half_resolution</c>.</para>
    /// </summary>
    public static void GISetUseHalfResolution(bool halfResolution)
    {
        NativeCalls.godot_icall_1_14(MethodBind152, GodotObject.GetPtr(Singleton), halfResolution.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind153 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGICreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new voxel-based global illumination object and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>voxel_gi_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.VoxelGI"/>.</para>
    /// </summary>
    public static Rid VoxelGICreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind153, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind154 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIAllocateData, 4108223027ul);

    public static unsafe void VoxelGIAllocateData(Rid voxelGI, Transform3D toCellXform, Aabb aabb, Vector3I octreeSize, byte[] octreeCells, byte[] dataCells, byte[] distanceField, int[] levelCounts)
    {
        NativeCalls.godot_icall_8_1146(MethodBind154, GodotObject.GetPtr(Singleton), voxelGI, &toCellXform, &aabb, &octreeSize, octreeCells, dataCells, distanceField, levelCounts);
    }

    public static unsafe void VoxelGIAllocateData(Rid voxelGI, Transform3D toCellXform, Aabb aabb, Vector3I octreeSize, ReadOnlySpan<byte> octreeCells, ReadOnlySpan<byte> dataCells, ReadOnlySpan<byte> distanceField, ReadOnlySpan<int> levelCounts)
    {
        NativeCalls.godot_icall_8_1146(MethodBind154, GodotObject.GetPtr(Singleton), voxelGI, &toCellXform, &aabb, &octreeSize, octreeCells, dataCells, distanceField, levelCounts);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind155 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetOctreeSize, 2607699645ul);

    public static Vector3I VoxelGIGetOctreeSize(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_1147(MethodBind155, GodotObject.GetPtr(Singleton), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind156 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetOctreeCells, 3348040486ul);

    public static byte[] VoxelGIGetOctreeCells(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_1148(MethodBind156, GodotObject.GetPtr(Singleton), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind157 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetDataCells, 3348040486ul);

    public static byte[] VoxelGIGetDataCells(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_1148(MethodBind157, GodotObject.GetPtr(Singleton), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind158 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetDistanceField, 3348040486ul);

    public static byte[] VoxelGIGetDistanceField(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_1148(MethodBind158, GodotObject.GetPtr(Singleton), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind159 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetLevelCounts, 788230395ul);

    public static int[] VoxelGIGetLevelCounts(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_1149(MethodBind159, GodotObject.GetPtr(Singleton), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind160 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGIGetToCellXform, 1128465797ul);

    public static Transform3D VoxelGIGetToCellXform(Rid voxelGI)
    {
        return NativeCalls.godot_icall_1_874(MethodBind160, GodotObject.GetPtr(Singleton), voxelGI);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind161 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetDynamicRange, 1794382983ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.DynamicRange"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static void VoxelGISetDynamicRange(Rid voxelGI, float range)
    {
        NativeCalls.godot_icall_2_816(MethodBind161, GodotObject.GetPtr(Singleton), voxelGI, range);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind162 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetPropagation, 1794382983ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.Propagation"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static void VoxelGISetPropagation(Rid voxelGI, float amount)
    {
        NativeCalls.godot_icall_2_816(MethodBind162, GodotObject.GetPtr(Singleton), voxelGI, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind163 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetEnergy, 1794382983ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.Energy"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static void VoxelGISetEnergy(Rid voxelGI, float energy)
    {
        NativeCalls.godot_icall_2_816(MethodBind163, GodotObject.GetPtr(Singleton), voxelGI, energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind164 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetBakedExposureNormalization, 1794382983ul);

    /// <summary>
    /// <para>Used to inform the renderer what exposure normalization value was used while baking the voxel gi. This value will be used and modulated at run time to ensure that the voxel gi maintains a consistent level of exposure even if the scene-wide exposure normalization is changed at run time. For more information see <see cref="Godot.RenderingServer.CameraAttributesSetExposure(Rid, float, float)"/>.</para>
    /// </summary>
    public static void VoxelGISetBakedExposureNormalization(Rid voxelGI, float bakedExposure)
    {
        NativeCalls.godot_icall_2_816(MethodBind164, GodotObject.GetPtr(Singleton), voxelGI, bakedExposure);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind165 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetBias, 1794382983ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.Bias"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static void VoxelGISetBias(Rid voxelGI, float bias)
    {
        NativeCalls.godot_icall_2_816(MethodBind165, GodotObject.GetPtr(Singleton), voxelGI, bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind166 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetNormalBias, 1794382983ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.NormalBias"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static void VoxelGISetNormalBias(Rid voxelGI, float bias)
    {
        NativeCalls.godot_icall_2_816(MethodBind166, GodotObject.GetPtr(Singleton), voxelGI, bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind167 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetInterior, 1265174801ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.Interior"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static void VoxelGISetInterior(Rid voxelGI, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind167, GodotObject.GetPtr(Singleton), voxelGI, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind168 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetUseTwoBounces, 1265174801ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.VoxelGIData.UseTwoBounces"/> value to use on the specified <paramref name="voxelGI"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static void VoxelGISetUseTwoBounces(Rid voxelGI, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind168, GodotObject.GetPtr(Singleton), voxelGI, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind169 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VoxelGISetQuality, 1538689978ul);

    /// <summary>
    /// <para>Sets the <c>ProjectSettings.rendering/global_illumination/voxel_gi/quality</c> value to use when rendering. This parameter is global and cannot be set on a per-VoxelGI basis.</para>
    /// </summary>
    public static void VoxelGISetQuality(RenderingServer.VoxelGIQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind169, GodotObject.GetPtr(Singleton), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind170 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new lightmap global illumination instance and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>lightmap_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.LightmapGI"/>.</para>
    /// </summary>
    public static Rid LightmapCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind170, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind171 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetTextures, 2646464759ul);

    /// <summary>
    /// <para>Set the textures on the given <paramref name="lightmap"/> GI instance to the texture array pointed to by the <paramref name="light"/> RID. If the lightmap texture was baked with <see cref="Godot.LightmapGI.Directional"/> set to <see langword="true"/>, then <paramref name="usesSh"/> must also be <see langword="true"/>.</para>
    /// </summary>
    public static void LightmapSetTextures(Rid lightmap, Rid light, bool usesSh)
    {
        NativeCalls.godot_icall_3_1150(MethodBind171, GodotObject.GetPtr(Singleton), lightmap, light, usesSh.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind172 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetProbeBounds, 3696536120ul);

    public static unsafe void LightmapSetProbeBounds(Rid lightmap, Aabb bounds)
    {
        NativeCalls.godot_icall_2_1135(MethodBind172, GodotObject.GetPtr(Singleton), lightmap, &bounds);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind173 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetProbeInterior, 1265174801ul);

    public static void LightmapSetProbeInterior(Rid lightmap, bool interior)
    {
        NativeCalls.godot_icall_2_434(MethodBind173, GodotObject.GetPtr(Singleton), lightmap, interior.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind174 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetProbeCaptureData, 3217845880ul);

    public static void LightmapSetProbeCaptureData(Rid lightmap, Vector3[] points, Color[] pointSh, int[] tetrahedra, int[] bspTree)
    {
        NativeCalls.godot_icall_5_1151(MethodBind174, GodotObject.GetPtr(Singleton), lightmap, points, pointSh, tetrahedra, bspTree);
    }

    public static void LightmapSetProbeCaptureData(Rid lightmap, ReadOnlySpan<Vector3> points, ReadOnlySpan<Color> pointSh, ReadOnlySpan<int> tetrahedra, ReadOnlySpan<int> bspTree)
    {
        NativeCalls.godot_icall_5_1151(MethodBind174, GodotObject.GetPtr(Singleton), lightmap, points, pointSh, tetrahedra, bspTree);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind175 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapGetProbeCapturePoints, 808965560ul);

    public static Vector3[] LightmapGetProbeCapturePoints(Rid lightmap)
    {
        return NativeCalls.godot_icall_1_878(MethodBind175, GodotObject.GetPtr(Singleton), lightmap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind176 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapGetProbeCaptureSh, 1569415609ul);

    public static Color[] LightmapGetProbeCaptureSh(Rid lightmap)
    {
        return NativeCalls.godot_icall_1_1152(MethodBind176, GodotObject.GetPtr(Singleton), lightmap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind177 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapGetProbeCaptureTetrahedra, 788230395ul);

    public static int[] LightmapGetProbeCaptureTetrahedra(Rid lightmap)
    {
        return NativeCalls.godot_icall_1_1149(MethodBind177, GodotObject.GetPtr(Singleton), lightmap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind178 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapGetProbeCaptureBspTree, 788230395ul);

    public static int[] LightmapGetProbeCaptureBspTree(Rid lightmap)
    {
        return NativeCalls.godot_icall_1_1149(MethodBind178, GodotObject.GetPtr(Singleton), lightmap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind179 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetBakedExposureNormalization, 1794382983ul);

    /// <summary>
    /// <para>Used to inform the renderer what exposure normalization value was used while baking the lightmap. This value will be used and modulated at run time to ensure that the lightmap maintains a consistent level of exposure even if the scene-wide exposure normalization is changed at run time. For more information see <see cref="Godot.RenderingServer.CameraAttributesSetExposure(Rid, float, float)"/>.</para>
    /// </summary>
    public static void LightmapSetBakedExposureNormalization(Rid lightmap, float bakedExposure)
    {
        NativeCalls.godot_icall_2_816(MethodBind179, GodotObject.GetPtr(Singleton), lightmap, bakedExposure);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind180 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapSetProbeCaptureUpdateSpeed, 373806689ul);

    public static void LightmapSetProbeCaptureUpdateSpeed(float speed)
    {
        NativeCalls.godot_icall_1_67(MethodBind180, GodotObject.GetPtr(Singleton), speed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind181 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a GPU-based particle system and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>particles_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach these particles to an instance using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent nodes are <see cref="Godot.GpuParticles2D"/> and <see cref="Godot.GpuParticles3D"/>.</para>
    /// <para><b>Note:</b> All <c>particles_*</c> methods only apply to GPU-based particles, not CPU-based particles. <see cref="Godot.CpuParticles2D"/> and <see cref="Godot.CpuParticles3D"/> do not have equivalent RenderingServer functions available, as these use <see cref="Godot.MultiMeshInstance2D"/> and <see cref="Godot.MultiMeshInstance3D"/> under the hood (see <c>multimesh_*</c> methods).</para>
    /// </summary>
    public static Rid ParticlesCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind181, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind182 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetMode, 3492270028ul);

    /// <summary>
    /// <para>Sets whether the GPU particles specified by the <paramref name="particles"/> RID should be rendered in 2D or 3D according to <paramref name="mode"/>.</para>
    /// </summary>
    public static void ParticlesSetMode(Rid particles, RenderingServer.ParticlesMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind182, GodotObject.GetPtr(Singleton), particles, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind183 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetEmitting, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, particles will emit over time. Setting to <see langword="false"/> does not reset the particles, but only stops their emission. Equivalent to <see cref="Godot.GpuParticles3D.Emitting"/>.</para>
    /// </summary>
    public static void ParticlesSetEmitting(Rid particles, bool emitting)
    {
        NativeCalls.godot_icall_2_434(MethodBind183, GodotObject.GetPtr(Singleton), particles, emitting.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind184 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesGetEmitting, 3521089500ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if particles are currently set to emitting.</para>
    /// </summary>
    public static bool ParticlesGetEmitting(Rid particles)
    {
        return NativeCalls.godot_icall_1_421(MethodBind184, GodotObject.GetPtr(Singleton), particles).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind185 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetAmount, 3411492887ul);

    /// <summary>
    /// <para>Sets the number of particles to be drawn and allocates the memory for them. Equivalent to <see cref="Godot.GpuParticles3D.Amount"/>.</para>
    /// </summary>
    public static void ParticlesSetAmount(Rid particles, int amount)
    {
        NativeCalls.godot_icall_2_426(MethodBind185, GodotObject.GetPtr(Singleton), particles, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind186 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetAmountRatio, 1794382983ul);

    /// <summary>
    /// <para>Sets the amount ratio for particles to be emitted. Equivalent to <see cref="Godot.GpuParticles3D.AmountRatio"/>.</para>
    /// </summary>
    public static void ParticlesSetAmountRatio(Rid particles, float ratio)
    {
        NativeCalls.godot_icall_2_816(MethodBind186, GodotObject.GetPtr(Singleton), particles, ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind187 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetLifetime, 1794382983ul);

    /// <summary>
    /// <para>Sets the lifetime of each particle in the system. Equivalent to <see cref="Godot.GpuParticles3D.Lifetime"/>.</para>
    /// </summary>
    public static void ParticlesSetLifetime(Rid particles, double lifetime)
    {
        NativeCalls.godot_icall_2_435(MethodBind187, GodotObject.GetPtr(Singleton), particles, lifetime);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind188 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetOneShot, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, particles will emit once and then stop. Equivalent to <see cref="Godot.GpuParticles3D.OneShot"/>.</para>
    /// </summary>
    public static void ParticlesSetOneShot(Rid particles, bool oneShot)
    {
        NativeCalls.godot_icall_2_434(MethodBind188, GodotObject.GetPtr(Singleton), particles, oneShot.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind189 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetPreProcessTime, 1794382983ul);

    /// <summary>
    /// <para>Sets the preprocess time for the particles' animation. This lets you delay starting an animation until after the particles have begun emitting. Equivalent to <see cref="Godot.GpuParticles3D.Preprocess"/>.</para>
    /// </summary>
    public static void ParticlesSetPreProcessTime(Rid particles, double time)
    {
        NativeCalls.godot_icall_2_435(MethodBind189, GodotObject.GetPtr(Singleton), particles, time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind190 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesRequestProcessTime, 1794382983ul);

    /// <summary>
    /// <para>Requests particles to process for extra process time during a single frame.</para>
    /// </summary>
    public static void ParticlesRequestProcessTime(Rid particles, float time)
    {
        NativeCalls.godot_icall_2_816(MethodBind190, GodotObject.GetPtr(Singleton), particles, time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind191 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetExplosivenessRatio, 1794382983ul);

    /// <summary>
    /// <para>Sets the explosiveness ratio. Equivalent to <see cref="Godot.GpuParticles3D.Explosiveness"/>.</para>
    /// </summary>
    public static void ParticlesSetExplosivenessRatio(Rid particles, float ratio)
    {
        NativeCalls.godot_icall_2_816(MethodBind191, GodotObject.GetPtr(Singleton), particles, ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind192 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetRandomnessRatio, 1794382983ul);

    /// <summary>
    /// <para>Sets the emission randomness ratio. This randomizes the emission of particles within their phase. Equivalent to <see cref="Godot.GpuParticles3D.Randomness"/>.</para>
    /// </summary>
    public static void ParticlesSetRandomnessRatio(Rid particles, float ratio)
    {
        NativeCalls.godot_icall_2_816(MethodBind192, GodotObject.GetPtr(Singleton), particles, ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind193 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetInterpToEnd, 1794382983ul);

    /// <summary>
    /// <para>Sets the value that informs a <see cref="Godot.ParticleProcessMaterial"/> to rush all particles towards the end of their lifetime.</para>
    /// </summary>
    public static void ParticlesSetInterpToEnd(Rid particles, float factor)
    {
        NativeCalls.godot_icall_2_816(MethodBind193, GodotObject.GetPtr(Singleton), particles, factor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind194 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetEmitterVelocity, 3227306858ul);

    /// <summary>
    /// <para>Sets the velocity of a particle node, that will be used by <see cref="Godot.ParticleProcessMaterial.InheritVelocityRatio"/>.</para>
    /// </summary>
    public static unsafe void ParticlesSetEmitterVelocity(Rid particles, Vector3 velocity)
    {
        NativeCalls.godot_icall_2_865(MethodBind194, GodotObject.GetPtr(Singleton), particles, &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind195 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetCustomAabb, 3696536120ul);

    /// <summary>
    /// <para>Sets a custom axis-aligned bounding box for the particle system. Equivalent to <see cref="Godot.GpuParticles3D.VisibilityAabb"/>.</para>
    /// </summary>
    public static unsafe void ParticlesSetCustomAabb(Rid particles, Aabb aabb)
    {
        NativeCalls.godot_icall_2_1135(MethodBind195, GodotObject.GetPtr(Singleton), particles, &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind196 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetSpeedScale, 1794382983ul);

    /// <summary>
    /// <para>Sets the speed scale of the particle system. Equivalent to <see cref="Godot.GpuParticles3D.SpeedScale"/>.</para>
    /// </summary>
    public static void ParticlesSetSpeedScale(Rid particles, double scale)
    {
        NativeCalls.godot_icall_2_435(MethodBind196, GodotObject.GetPtr(Singleton), particles, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind197 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetUseLocalCoordinates, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, particles use local coordinates. If <see langword="false"/> they use global coordinates. Equivalent to <see cref="Godot.GpuParticles3D.LocalCoords"/>.</para>
    /// </summary>
    public static void ParticlesSetUseLocalCoordinates(Rid particles, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind197, GodotObject.GetPtr(Singleton), particles, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind198 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetProcessMaterial, 395945892ul);

    /// <summary>
    /// <para>Sets the material for processing the particles.</para>
    /// <para><b>Note:</b> This is not the material used to draw the materials. Equivalent to <see cref="Godot.GpuParticles3D.ProcessMaterial"/>.</para>
    /// </summary>
    public static void ParticlesSetProcessMaterial(Rid particles, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind198, GodotObject.GetPtr(Singleton), particles, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind199 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetFixedFps, 3411492887ul);

    /// <summary>
    /// <para>Sets the frame rate that the particle system rendering will be fixed to. Equivalent to <see cref="Godot.GpuParticles3D.FixedFps"/>.</para>
    /// </summary>
    public static void ParticlesSetFixedFps(Rid particles, int fps)
    {
        NativeCalls.godot_icall_2_426(MethodBind199, GodotObject.GetPtr(Singleton), particles, fps);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind200 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetInterpolate, 1265174801ul);

    public static void ParticlesSetInterpolate(Rid particles, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind200, GodotObject.GetPtr(Singleton), particles, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind201 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetFractionalDelta, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, uses fractional delta which smooths the movement of the particles. Equivalent to <see cref="Godot.GpuParticles3D.FractDelta"/>.</para>
    /// </summary>
    public static void ParticlesSetFractionalDelta(Rid particles, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind201, GodotObject.GetPtr(Singleton), particles, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind202 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetCollisionBaseSize, 1794382983ul);

    public static void ParticlesSetCollisionBaseSize(Rid particles, float size)
    {
        NativeCalls.godot_icall_2_816(MethodBind202, GodotObject.GetPtr(Singleton), particles, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind203 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetTransformAlign, 3264971368ul);

    public static void ParticlesSetTransformAlign(Rid particles, RenderingServer.ParticlesTransformAlign align)
    {
        NativeCalls.godot_icall_2_426(MethodBind203, GodotObject.GetPtr(Singleton), particles, (int)align);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind204 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetTrails, 2010054925ul);

    /// <summary>
    /// <para>If <paramref name="enable"/> is <see langword="true"/>, enables trails for the <paramref name="particles"/> with the specified <paramref name="lengthSec"/> in seconds. Equivalent to <see cref="Godot.GpuParticles3D.TrailEnabled"/> and <see cref="Godot.GpuParticles3D.TrailLifetime"/>.</para>
    /// </summary>
    public static void ParticlesSetTrails(Rid particles, bool enable, float lengthSec)
    {
        NativeCalls.godot_icall_3_1153(MethodBind204, GodotObject.GetPtr(Singleton), particles, enable.ToGodotBool(), lengthSec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind205 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetTrailBindPoses, 684822712ul);

    public static void ParticlesSetTrailBindPoses(Rid particles, Godot.Collections.Array<Transform3D> bindPoses)
    {
        NativeCalls.godot_icall_2_1122(MethodBind205, GodotObject.GetPtr(Singleton), particles, (godot_array)(bindPoses ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind206 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesIsInactive, 3521089500ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if particles are not emitting and particles are set to inactive.</para>
    /// </summary>
    public static bool ParticlesIsInactive(Rid particles)
    {
        return NativeCalls.godot_icall_1_421(MethodBind206, GodotObject.GetPtr(Singleton), particles).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind207 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesRequestProcess, 2722037293ul);

    /// <summary>
    /// <para>Add particle system to list of particle systems that need to be updated. Update will take place on the next frame, or on the next call to <see cref="Godot.RenderingServer.InstancesCullAabb(Aabb, Rid)"/>, <see cref="Godot.RenderingServer.InstancesCullConvex(Godot.Collections.Array{Plane}, Rid)"/>, or <see cref="Godot.RenderingServer.InstancesCullRay(Vector3, Vector3, Rid)"/>.</para>
    /// </summary>
    public static void ParticlesRequestProcess(Rid particles)
    {
        NativeCalls.godot_icall_1_286(MethodBind207, GodotObject.GetPtr(Singleton), particles);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind208 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesRestart, 2722037293ul);

    /// <summary>
    /// <para>Reset the particles on the next update. Equivalent to <see cref="Godot.GpuParticles3D.Restart(bool)"/>.</para>
    /// </summary>
    public static void ParticlesRestart(Rid particles)
    {
        NativeCalls.godot_icall_1_286(MethodBind208, GodotObject.GetPtr(Singleton), particles);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind209 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetSubemitter, 395945892ul);

    public static void ParticlesSetSubemitter(Rid particles, Rid subemitterParticles)
    {
        NativeCalls.godot_icall_2_430(MethodBind209, GodotObject.GetPtr(Singleton), particles, subemitterParticles);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind210 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesEmit, 4043136117ul);

    /// <summary>
    /// <para>Manually emits particles from the <paramref name="particles"/> instance.</para>
    /// </summary>
    public static unsafe void ParticlesEmit(Rid particles, Transform3D transform, Vector3 velocity, Color color, Color custom, uint emitFlags)
    {
        NativeCalls.godot_icall_6_1154(MethodBind210, GodotObject.GetPtr(Singleton), particles, &transform, &velocity, &color, &custom, emitFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind211 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetDrawOrder, 935028487ul);

    /// <summary>
    /// <para>Sets the draw order of the particles. Equivalent to <see cref="Godot.GpuParticles3D.DrawOrder"/>.</para>
    /// </summary>
    public static void ParticlesSetDrawOrder(Rid particles, RenderingServer.ParticlesDrawOrder order)
    {
        NativeCalls.godot_icall_2_426(MethodBind211, GodotObject.GetPtr(Singleton), particles, (int)order);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind212 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetDrawPasses, 3411492887ul);

    /// <summary>
    /// <para>Sets the number of draw passes to use. Equivalent to <see cref="Godot.GpuParticles3D.DrawPasses"/>.</para>
    /// </summary>
    public static void ParticlesSetDrawPasses(Rid particles, int count)
    {
        NativeCalls.godot_icall_2_426(MethodBind212, GodotObject.GetPtr(Singleton), particles, count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind213 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetDrawPassMesh, 2310537182ul);

    /// <summary>
    /// <para>Sets the mesh to be used for the specified draw pass. Equivalent to <see cref="Godot.GpuParticles3D.DrawPass1"/>, <see cref="Godot.GpuParticles3D.DrawPass2"/>, <see cref="Godot.GpuParticles3D.DrawPass3"/>, and <see cref="Godot.GpuParticles3D.DrawPass4"/>.</para>
    /// </summary>
    public static void ParticlesSetDrawPassMesh(Rid particles, int pass, Rid mesh)
    {
        NativeCalls.godot_icall_3_833(MethodBind213, GodotObject.GetPtr(Singleton), particles, pass, mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind214 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesGetCurrentAabb, 3952830260ul);

    /// <summary>
    /// <para>Calculates and returns the axis-aligned bounding box that contains all the particles. Equivalent to <see cref="Godot.GpuParticles3D.CaptureAabb()"/>.</para>
    /// </summary>
    public static Aabb ParticlesGetCurrentAabb(Rid particles)
    {
        return NativeCalls.godot_icall_1_876(MethodBind214, GodotObject.GetPtr(Singleton), particles);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind215 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesSetEmissionTransform, 3935195649ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform3D"/> that will be used by the particles when they first emit.</para>
    /// </summary>
    public static unsafe void ParticlesSetEmissionTransform(Rid particles, Transform3D transform)
    {
        NativeCalls.godot_icall_2_873(MethodBind215, GodotObject.GetPtr(Singleton), particles, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind216 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new 3D GPU particle collision or attractor and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID can be used in most <c>particles_collision_*</c> RenderingServer functions.</para>
    /// <para><b>Note:</b> The equivalent nodes are <see cref="Godot.GpuParticlesCollision3D"/> and <see cref="Godot.GpuParticlesAttractor3D"/>.</para>
    /// </summary>
    public static Rid ParticlesCollisionCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind216, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind217 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetCollisionType, 1497044930ul);

    /// <summary>
    /// <para>Sets the collision or attractor shape <paramref name="type"/> for the 3D GPU particles collision or attractor specified by the <paramref name="particlesCollision"/> RID.</para>
    /// </summary>
    public static void ParticlesCollisionSetCollisionType(Rid particlesCollision, RenderingServer.ParticlesCollisionType type)
    {
        NativeCalls.godot_icall_2_426(MethodBind217, GodotObject.GetPtr(Singleton), particlesCollision, (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind218 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the cull <paramref name="mask"/> for the 3D GPU particles collision or attractor specified by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollision3D.CullMask"/> or <see cref="Godot.GpuParticlesAttractor3D.CullMask"/> depending on the <paramref name="particlesCollision"/> type.</para>
    /// </summary>
    public static void ParticlesCollisionSetCullMask(Rid particlesCollision, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind218, GodotObject.GetPtr(Singleton), particlesCollision, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind219 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetSphereRadius, 1794382983ul);

    /// <summary>
    /// <para>Sets the <paramref name="radius"/> for the 3D GPU particles sphere collision or attractor specified by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollisionSphere3D.Radius"/> or <see cref="Godot.GpuParticlesAttractorSphere3D.Radius"/> depending on the <paramref name="particlesCollision"/> type.</para>
    /// </summary>
    public static void ParticlesCollisionSetSphereRadius(Rid particlesCollision, float radius)
    {
        NativeCalls.godot_icall_2_816(MethodBind219, GodotObject.GetPtr(Singleton), particlesCollision, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind220 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetBoxExtents, 3227306858ul);

    /// <summary>
    /// <para>Sets the <paramref name="extents"/> for the 3D GPU particles collision by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollisionBox3D.Size"/>, <see cref="Godot.GpuParticlesCollisionSdf3D.Size"/>, <see cref="Godot.GpuParticlesCollisionHeightField3D.Size"/>, <see cref="Godot.GpuParticlesAttractorBox3D.Size"/> or <see cref="Godot.GpuParticlesAttractorVectorField3D.Size"/> depending on the <paramref name="particlesCollision"/> type.</para>
    /// </summary>
    public static unsafe void ParticlesCollisionSetBoxExtents(Rid particlesCollision, Vector3 extents)
    {
        NativeCalls.godot_icall_2_865(MethodBind220, GodotObject.GetPtr(Singleton), particlesCollision, &extents);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind221 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetAttractorStrength, 1794382983ul);

    /// <summary>
    /// <para>Sets the <paramref name="strength"/> for the 3D GPU particles attractor specified by the <paramref name="particlesCollision"/> RID. Only used for attractors, not colliders. Equivalent to <see cref="Godot.GpuParticlesAttractor3D.Strength"/>.</para>
    /// </summary>
    public static void ParticlesCollisionSetAttractorStrength(Rid particlesCollision, float strength)
    {
        NativeCalls.godot_icall_2_816(MethodBind221, GodotObject.GetPtr(Singleton), particlesCollision, strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind222 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetAttractorDirectionality, 1794382983ul);

    /// <summary>
    /// <para>Sets the directionality <paramref name="amount"/> for the 3D GPU particles attractor specified by the <paramref name="particlesCollision"/> RID. Only used for attractors, not colliders. Equivalent to <see cref="Godot.GpuParticlesAttractor3D.Directionality"/>.</para>
    /// </summary>
    public static void ParticlesCollisionSetAttractorDirectionality(Rid particlesCollision, float amount)
    {
        NativeCalls.godot_icall_2_816(MethodBind222, GodotObject.GetPtr(Singleton), particlesCollision, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind223 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetAttractorAttenuation, 1794382983ul);

    /// <summary>
    /// <para>Sets the attenuation <paramref name="curve"/> for the 3D GPU particles attractor specified by the <paramref name="particlesCollision"/> RID. Only used for attractors, not colliders. Equivalent to <see cref="Godot.GpuParticlesAttractor3D.Attenuation"/>.</para>
    /// </summary>
    public static void ParticlesCollisionSetAttractorAttenuation(Rid particlesCollision, float curve)
    {
        NativeCalls.godot_icall_2_816(MethodBind223, GodotObject.GetPtr(Singleton), particlesCollision, curve);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind224 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetFieldTexture, 395945892ul);

    /// <summary>
    /// <para>Sets the signed distance field <paramref name="texture"/> for the 3D GPU particles collision specified by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollisionSdf3D.Texture"/> or <see cref="Godot.GpuParticlesAttractorVectorField3D.Texture"/> depending on the <paramref name="particlesCollision"/> type.</para>
    /// </summary>
    public static void ParticlesCollisionSetFieldTexture(Rid particlesCollision, Rid texture)
    {
        NativeCalls.godot_icall_2_430(MethodBind224, GodotObject.GetPtr(Singleton), particlesCollision, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind225 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionHeightFieldUpdate, 2722037293ul);

    /// <summary>
    /// <para>Requests an update for the 3D GPU particle collision heightfield. This may be automatically called by the 3D GPU particle collision heightfield depending on its <see cref="Godot.GpuParticlesCollisionHeightField3D.UpdateMode"/>.</para>
    /// </summary>
    public static void ParticlesCollisionHeightFieldUpdate(Rid particlesCollision)
    {
        NativeCalls.godot_icall_1_286(MethodBind225, GodotObject.GetPtr(Singleton), particlesCollision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind226 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetHeightFieldResolution, 962977297ul);

    /// <summary>
    /// <para>Sets the heightmap <paramref name="resolution"/> for the 3D GPU particles heightfield collision specified by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollisionHeightField3D.Resolution"/>.</para>
    /// </summary>
    public static void ParticlesCollisionSetHeightFieldResolution(Rid particlesCollision, RenderingServer.ParticlesCollisionHeightfieldResolution resolution)
    {
        NativeCalls.godot_icall_2_426(MethodBind226, GodotObject.GetPtr(Singleton), particlesCollision, (int)resolution);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind227 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParticlesCollisionSetHeightFieldMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the heightfield <paramref name="mask"/> for the 3D GPU particles heightfield collision specified by the <paramref name="particlesCollision"/> RID. Equivalent to <see cref="Godot.GpuParticlesCollisionHeightField3D.HeightfieldMask"/>.</para>
    /// </summary>
    public static void ParticlesCollisionSetHeightFieldMask(Rid particlesCollision, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind227, GodotObject.GetPtr(Singleton), particlesCollision, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind228 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FogVolumeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new fog volume and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>fog_volume_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.FogVolume"/>.</para>
    /// </summary>
    public static Rid FogVolumeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind228, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind229 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FogVolumeSetShape, 3818703106ul);

    /// <summary>
    /// <para>Sets the shape of the fog volume to either <see cref="Godot.RenderingServer.FogVolumeShape.Ellipsoid"/>, <see cref="Godot.RenderingServer.FogVolumeShape.Cone"/>, <see cref="Godot.RenderingServer.FogVolumeShape.Cylinder"/>, <see cref="Godot.RenderingServer.FogVolumeShape.Box"/> or <see cref="Godot.RenderingServer.FogVolumeShape.World"/>.</para>
    /// </summary>
    public static void FogVolumeSetShape(Rid fogVolume, RenderingServer.FogVolumeShape shape)
    {
        NativeCalls.godot_icall_2_426(MethodBind229, GodotObject.GetPtr(Singleton), fogVolume, (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind230 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FogVolumeSetSize, 3227306858ul);

    /// <summary>
    /// <para>Sets the size of the fog volume when shape is <see cref="Godot.RenderingServer.FogVolumeShape.Ellipsoid"/>, <see cref="Godot.RenderingServer.FogVolumeShape.Cone"/>, <see cref="Godot.RenderingServer.FogVolumeShape.Cylinder"/> or <see cref="Godot.RenderingServer.FogVolumeShape.Box"/>.</para>
    /// </summary>
    public static unsafe void FogVolumeSetSize(Rid fogVolume, Vector3 size)
    {
        NativeCalls.godot_icall_2_865(MethodBind230, GodotObject.GetPtr(Singleton), fogVolume, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind231 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FogVolumeSetMaterial, 395945892ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Material"/> of the fog volume. Can be either a <see cref="Godot.FogMaterial"/> or a custom <see cref="Godot.ShaderMaterial"/>.</para>
    /// </summary>
    public static void FogVolumeSetMaterial(Rid fogVolume, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind231, GodotObject.GetPtr(Singleton), fogVolume, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind232 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VisibilityNotifierCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new 3D visibility notifier object and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>visibility_notifier_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>To place in a scene, attach this notifier to an instance using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/> using the returned RID.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.VisibleOnScreenNotifier3D"/>.</para>
    /// </summary>
    public static Rid VisibilityNotifierCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind232, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind233 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VisibilityNotifierSetAabb, 3696536120ul);

    public static unsafe void VisibilityNotifierSetAabb(Rid notifier, Aabb aabb)
    {
        NativeCalls.godot_icall_2_1135(MethodBind233, GodotObject.GetPtr(Singleton), notifier, &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind234 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VisibilityNotifierSetCallbacks, 2689735388ul);

    public static void VisibilityNotifierSetCallbacks(Rid notifier, Callable enterCallable, Callable exitCallable)
    {
        NativeCalls.godot_icall_3_1155(MethodBind234, GodotObject.GetPtr(Singleton), notifier, enterCallable, exitCallable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind235 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.OccluderCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an occluder instance and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>occluder_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Occluder3D"/> (not to be confused with the <see cref="Godot.OccluderInstance3D"/> node).</para>
    /// </summary>
    public static Rid OccluderCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind235, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind236 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.OccluderSetMesh, 3854404263ul);

    /// <summary>
    /// <para>Sets the mesh data for the given occluder RID, which controls the shape of the occlusion culling that will be performed.</para>
    /// </summary>
    public static void OccluderSetMesh(Rid occluder, Vector3[] vertices, int[] indices)
    {
        NativeCalls.godot_icall_3_1156(MethodBind236, GodotObject.GetPtr(Singleton), occluder, vertices, indices);
    }

    /// <summary>
    /// <para>Sets the mesh data for the given occluder RID, which controls the shape of the occlusion culling that will be performed.</para>
    /// </summary>
    public static void OccluderSetMesh(Rid occluder, ReadOnlySpan<Vector3> vertices, ReadOnlySpan<int> indices)
    {
        NativeCalls.godot_icall_3_1156(MethodBind236, GodotObject.GetPtr(Singleton), occluder, vertices, indices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind237 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D camera and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>camera_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.Camera3D"/>.</para>
    /// </summary>
    public static Rid CameraCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind237, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind238 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetPerspective, 157498339ul);

    /// <summary>
    /// <para>Sets camera to use perspective projection. Objects on the screen becomes smaller when they are far away.</para>
    /// </summary>
    public static void CameraSetPerspective(Rid camera, float fovyDegrees, float zNear, float zFar)
    {
        NativeCalls.godot_icall_4_1157(MethodBind238, GodotObject.GetPtr(Singleton), camera, fovyDegrees, zNear, zFar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind239 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetOrthogonal, 157498339ul);

    /// <summary>
    /// <para>Sets camera to use orthogonal projection, also known as orthographic projection. Objects remain the same size on the screen no matter how far away they are.</para>
    /// </summary>
    public static void CameraSetOrthogonal(Rid camera, float size, float zNear, float zFar)
    {
        NativeCalls.godot_icall_4_1157(MethodBind239, GodotObject.GetPtr(Singleton), camera, size, zNear, zFar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind240 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetFrustum, 1889878953ul);

    /// <summary>
    /// <para>Sets camera to use frustum projection. This mode allows adjusting the <paramref name="offset"/> argument to create "tilted frustum" effects.</para>
    /// </summary>
    public static unsafe void CameraSetFrustum(Rid camera, float size, Vector2 offset, float zNear, float zFar)
    {
        NativeCalls.godot_icall_5_1158(MethodBind240, GodotObject.GetPtr(Singleton), camera, size, &offset, zNear, zFar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind241 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetTransform, 3935195649ul);

    /// <summary>
    /// <para>Sets <see cref="Godot.Transform3D"/> of camera.</para>
    /// </summary>
    public static unsafe void CameraSetTransform(Rid camera, Transform3D transform)
    {
        NativeCalls.godot_icall_2_873(MethodBind241, GodotObject.GetPtr(Singleton), camera, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind242 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the cull mask associated with this camera. The cull mask describes which 3D layers are rendered by this camera. Equivalent to <see cref="Godot.Camera3D.CullMask"/>.</para>
    /// </summary>
    public static void CameraSetCullMask(Rid camera, uint layers)
    {
        NativeCalls.godot_icall_2_856(MethodBind242, GodotObject.GetPtr(Singleton), camera, layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind243 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetEnvironment, 395945892ul);

    /// <summary>
    /// <para>Sets the environment used by this camera. Equivalent to <see cref="Godot.Camera3D.Environment"/>.</para>
    /// </summary>
    public static void CameraSetEnvironment(Rid camera, Rid env)
    {
        NativeCalls.godot_icall_2_430(MethodBind243, GodotObject.GetPtr(Singleton), camera, env);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind244 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetCameraAttributes, 395945892ul);

    /// <summary>
    /// <para>Sets the camera_attributes created with <see cref="Godot.RenderingServer.CameraAttributesCreate()"/> to the given camera.</para>
    /// </summary>
    public static void CameraSetCameraAttributes(Rid camera, Rid effects)
    {
        NativeCalls.godot_icall_2_430(MethodBind244, GodotObject.GetPtr(Singleton), camera, effects);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind245 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetCompositor, 395945892ul);

    /// <summary>
    /// <para>Sets the compositor used by this camera. Equivalent to <see cref="Godot.Camera3D.Compositor"/>.</para>
    /// </summary>
    public static void CameraSetCompositor(Rid camera, Rid compositor)
    {
        NativeCalls.godot_icall_2_430(MethodBind245, GodotObject.GetPtr(Singleton), camera, compositor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind246 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraSetUseVerticalAspect, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, preserves the horizontal aspect ratio which is equivalent to <see cref="Godot.Camera3D.KeepAspectEnum.Width"/>. If <see langword="false"/>, preserves the vertical aspect ratio which is equivalent to <see cref="Godot.Camera3D.KeepAspectEnum.Height"/>.</para>
    /// </summary>
    public static void CameraSetUseVerticalAspect(Rid camera, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind246, GodotObject.GetPtr(Singleton), camera, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind247 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an empty viewport and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>viewport_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.Viewport"/>.</para>
    /// </summary>
    public static Rid ViewportCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind247, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind248 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUseXR, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport uses augmented or virtual reality technologies. See <see cref="Godot.XRInterface"/>.</para>
    /// </summary>
    public static void ViewportSetUseXR(Rid viewport, bool useXR)
    {
        NativeCalls.godot_icall_2_434(MethodBind248, GodotObject.GetPtr(Singleton), viewport, useXR.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind249 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetSize, 4288446313ul);

    /// <summary>
    /// <para>Sets the viewport's width and height in pixels.</para>
    /// </summary>
    public static void ViewportSetSize(Rid viewport, int width, int height)
    {
        NativeCalls.godot_icall_3_433(MethodBind249, GodotObject.GetPtr(Singleton), viewport, width, height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind250 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetActive, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, sets the viewport active, else sets it inactive.</para>
    /// </summary>
    public static void ViewportSetActive(Rid viewport, bool active)
    {
        NativeCalls.godot_icall_2_434(MethodBind250, GodotObject.GetPtr(Singleton), viewport, active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind251 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetParentViewport, 395945892ul);

    /// <summary>
    /// <para>Sets the viewport's parent to the viewport specified by the <paramref name="parentViewport"/> RID.</para>
    /// </summary>
    public static void ViewportSetParentViewport(Rid viewport, Rid parentViewport)
    {
        NativeCalls.godot_icall_2_430(MethodBind251, GodotObject.GetPtr(Singleton), viewport, parentViewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind252 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportAttachToScreen, 1062245816ul);

    /// <summary>
    /// <para>Copies the viewport to a region of the screen specified by <paramref name="rect"/>. If <see cref="Godot.RenderingServer.ViewportSetRenderDirectToScreen(Rid, bool)"/> is <see langword="true"/>, then the viewport does not use a framebuffer and the contents of the viewport are rendered directly to screen. However, note that the root viewport is drawn last, therefore it will draw over the screen. Accordingly, you must set the root viewport to an area that does not cover the area that you have attached this viewport to.</para>
    /// <para>For example, you can set the root viewport to not render at all with the following code:</para>
    /// <para></para>
    /// <para>Using this can result in significant optimization, especially on lower-end devices. However, it comes at the cost of having to manage your viewports manually. For further optimization, see <see cref="Godot.RenderingServer.ViewportSetRenderDirectToScreen(Rid, bool)"/>.</para>
    /// </summary>
    /// <param name="rect">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    public static unsafe void ViewportAttachToScreen(Rid viewport, Nullable<Rect2> rect = null, int screen = 0)
    {
        Rect2 rectOrDefVal = rect.HasValue ? rect.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_3_1159(MethodBind252, GodotObject.GetPtr(Singleton), viewport, &rectOrDefVal, screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind253 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetRenderDirectToScreen, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, render the contents of the viewport directly to screen. This allows a low-level optimization where you can skip drawing a viewport to the root viewport. While this optimization can result in a significant increase in speed (especially on older devices), it comes at a cost of usability. When this is enabled, you cannot read from the viewport or from the screen_texture. You also lose the benefit of certain window settings, such as the various stretch modes. Another consequence to be aware of is that in 2D the rendering happens in window coordinates, so if you have a viewport that is double the size of the window, and you set this, then only the portion that fits within the window will be drawn, no automatic scaling is possible, even if your game scene is significantly larger than the window size.</para>
    /// </summary>
    public static void ViewportSetRenderDirectToScreen(Rid viewport, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind253, GodotObject.GetPtr(Singleton), viewport, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind254 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetCanvasCullMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the rendering mask associated with this <see cref="Godot.Viewport"/>. Only <see cref="Godot.CanvasItem"/> nodes with a matching rendering visibility layer will be rendered by this <see cref="Godot.Viewport"/>.</para>
    /// </summary>
    public static void ViewportSetCanvasCullMask(Rid viewport, uint canvasCullMask)
    {
        NativeCalls.godot_icall_2_856(MethodBind254, GodotObject.GetPtr(Singleton), viewport, canvasCullMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind255 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetScaling3DMode, 2386524376ul);

    /// <summary>
    /// <para>Sets the 3D resolution scaling mode. Bilinear scaling renders at different resolution to either undersample or supersample the viewport. FidelityFX Super Resolution 1.0, abbreviated to FSR, is an upscaling technology that produces high quality images at fast framerates by using a spatially aware upscaling algorithm. FSR is slightly more expensive than bilinear, but it produces significantly higher image quality. FSR should be used where possible.</para>
    /// </summary>
    public static void ViewportSetScaling3DMode(Rid viewport, RenderingServer.ViewportScaling3DMode scaling3DMode)
    {
        NativeCalls.godot_icall_2_426(MethodBind255, GodotObject.GetPtr(Singleton), viewport, (int)scaling3DMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind256 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetScaling3DScale, 1794382983ul);

    /// <summary>
    /// <para>Scales the 3D render buffer based on the viewport size uses an image filter specified in <see cref="Godot.RenderingServer.ViewportScaling3DMode"/> to scale the output image to the full viewport size. Values lower than <c>1.0</c> can be used to speed up 3D rendering at the cost of quality (undersampling). Values greater than <c>1.0</c> are only valid for bilinear mode and can be used to improve 3D rendering quality at a high performance cost (supersampling). See also <see cref="Godot.RenderingServer.ViewportMsaa"/> for multi-sample antialiasing, which is significantly cheaper but only smoothens the edges of polygons.</para>
    /// <para>When using FSR upscaling, AMD recommends exposing the following values as preset options to users "Ultra Quality: 0.77", "Quality: 0.67", "Balanced: 0.59", "Performance: 0.5" instead of exposing the entire scale.</para>
    /// </summary>
    public static void ViewportSetScaling3DScale(Rid viewport, float scale)
    {
        NativeCalls.godot_icall_2_816(MethodBind256, GodotObject.GetPtr(Singleton), viewport, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind257 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetFsrSharpness, 1794382983ul);

    /// <summary>
    /// <para>Determines how sharp the upscaled image will be when using the FSR upscaling mode. Sharpness halves with every whole number. Values go from 0.0 (sharpest) to 2.0. Values above 2.0 won't make a visible difference.</para>
    /// </summary>
    public static void ViewportSetFsrSharpness(Rid viewport, float sharpness)
    {
        NativeCalls.godot_icall_2_816(MethodBind257, GodotObject.GetPtr(Singleton), viewport, sharpness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind258 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetTextureMipmapBias, 1794382983ul);

    /// <summary>
    /// <para>Affects the final texture sharpness by reading from a lower or higher mipmap (also called "texture LOD bias"). Negative values make mipmapped textures sharper but grainier when viewed at a distance, while positive values make mipmapped textures blurrier (even when up close). To get sharper textures at a distance without introducing too much graininess, set this between <c>-0.75</c> and <c>0.0</c>. Enabling temporal antialiasing (<c>ProjectSettings.rendering/anti_aliasing/quality/use_taa</c>) can help reduce the graininess visible when using negative mipmap bias.</para>
    /// <para><b>Note:</b> When the 3D scaling mode is set to FSR 1.0, this value is used to adjust the automatic mipmap bias which is calculated internally based on the scale factor. The formula for this is <c>-log2(1.0 / scale) + mipmap_bias</c>.</para>
    /// </summary>
    public static void ViewportSetTextureMipmapBias(Rid viewport, float mipmapBias)
    {
        NativeCalls.godot_icall_2_816(MethodBind258, GodotObject.GetPtr(Singleton), viewport, mipmapBias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind259 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetAnisotropicFilteringLevel, 3953214029ul);

    /// <summary>
    /// <para>Sets the maximum number of samples to take when using anisotropic filtering on textures (as a power of two). A higher sample count will result in sharper textures at oblique angles, but is more expensive to compute. A value of <c>0</c> forcibly disables anisotropic filtering, even on materials where it is enabled.</para>
    /// <para>The anisotropic filtering level also affects decals and light projectors if they are configured to use anisotropic filtering. See <c>ProjectSettings.rendering/textures/decals/filter</c> and <c>ProjectSettings.rendering/textures/light_projectors/filter</c>.</para>
    /// <para><b>Note:</b> In 3D, for this setting to have an effect, set <see cref="Godot.BaseMaterial3D.TextureFilter"/> to <see cref="Godot.BaseMaterial3D.TextureFilterEnum.LinearWithMipmapsAnisotropic"/> or <see cref="Godot.BaseMaterial3D.TextureFilterEnum.NearestWithMipmapsAnisotropic"/> on materials.</para>
    /// <para><b>Note:</b> In 2D, for this setting to have an effect, set <see cref="Godot.CanvasItem.TextureFilter"/> to <see cref="Godot.CanvasItem.TextureFilterEnum.LinearWithMipmapsAnisotropic"/> or <see cref="Godot.CanvasItem.TextureFilterEnum.NearestWithMipmapsAnisotropic"/> on the <see cref="Godot.CanvasItem"/> node displaying the texture (or in <see cref="Godot.CanvasTexture"/>). However, anisotropic filtering is rarely useful in 2D, so only enable it for textures in 2D if it makes a meaningful visual difference.</para>
    /// </summary>
    public static void ViewportSetAnisotropicFilteringLevel(Rid viewport, RenderingServer.ViewportAnisotropicFiltering anisotropicFilteringLevel)
    {
        NativeCalls.godot_icall_2_426(MethodBind259, GodotObject.GetPtr(Singleton), viewport, (int)anisotropicFilteringLevel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind260 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUpdateMode, 3161116010ul);

    /// <summary>
    /// <para>Sets when the viewport should be updated.</para>
    /// </summary>
    public static void ViewportSetUpdateMode(Rid viewport, RenderingServer.ViewportUpdateMode updateMode)
    {
        NativeCalls.godot_icall_2_426(MethodBind260, GodotObject.GetPtr(Singleton), viewport, (int)updateMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind261 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetUpdateMode, 3803901472ul);

    /// <summary>
    /// <para>Returns the viewport's update mode.</para>
    /// <para><b>Warning:</b> Calling this from any thread other than the rendering thread will be detrimental to performance.</para>
    /// </summary>
    public static RenderingServer.ViewportUpdateMode ViewportGetUpdateMode(Rid viewport)
    {
        return (RenderingServer.ViewportUpdateMode)NativeCalls.godot_icall_1_835(MethodBind261, GodotObject.GetPtr(Singleton), viewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind262 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetClearMode, 3628367896ul);

    /// <summary>
    /// <para>Sets the clear mode of a viewport.</para>
    /// </summary>
    public static void ViewportSetClearMode(Rid viewport, RenderingServer.ViewportClearMode clearMode)
    {
        NativeCalls.godot_icall_2_426(MethodBind262, GodotObject.GetPtr(Singleton), viewport, (int)clearMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind263 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetRenderTarget, 3814569979ul);

    /// <summary>
    /// <para>Returns the render target for the viewport.</para>
    /// </summary>
    public static Rid ViewportGetRenderTarget(Rid viewport)
    {
        return NativeCalls.godot_icall_1_855(MethodBind263, GodotObject.GetPtr(Singleton), viewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind264 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetTexture, 3814569979ul);

    /// <summary>
    /// <para>Returns the viewport's last rendered frame.</para>
    /// </summary>
    public static Rid ViewportGetTexture(Rid viewport)
    {
        return NativeCalls.godot_icall_1_855(MethodBind264, GodotObject.GetPtr(Singleton), viewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind265 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetDisable3D, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport's 3D elements are not rendered.</para>
    /// </summary>
    public static void ViewportSetDisable3D(Rid viewport, bool disable)
    {
        NativeCalls.godot_icall_2_434(MethodBind265, GodotObject.GetPtr(Singleton), viewport, disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind266 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetDisable2D, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport's canvas (i.e. 2D and GUI elements) is not rendered.</para>
    /// </summary>
    public static void ViewportSetDisable2D(Rid viewport, bool disable)
    {
        NativeCalls.godot_icall_2_434(MethodBind266, GodotObject.GetPtr(Singleton), viewport, disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind267 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetEnvironmentMode, 2196892182ul);

    /// <summary>
    /// <para>Sets the viewport's environment mode which allows enabling or disabling rendering of 3D environment over 2D canvas. When disabled, 2D will not be affected by the environment. When enabled, 2D will be affected by the environment if the environment background mode is <see cref="Godot.RenderingServer.EnvironmentBG.Canvas"/>. The default behavior is to inherit the setting from the viewport's parent. If the topmost parent is also set to <see cref="Godot.RenderingServer.ViewportEnvironmentMode.Inherit"/>, then the behavior will be the same as if it was set to <see cref="Godot.RenderingServer.ViewportEnvironmentMode.Enabled"/>.</para>
    /// </summary>
    public static void ViewportSetEnvironmentMode(Rid viewport, RenderingServer.ViewportEnvironmentMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind267, GodotObject.GetPtr(Singleton), viewport, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind268 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportAttachCamera, 395945892ul);

    /// <summary>
    /// <para>Sets a viewport's camera.</para>
    /// </summary>
    public static void ViewportAttachCamera(Rid viewport, Rid camera)
    {
        NativeCalls.godot_icall_2_430(MethodBind268, GodotObject.GetPtr(Singleton), viewport, camera);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind269 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetScenario, 395945892ul);

    /// <summary>
    /// <para>Sets a viewport's scenario. The scenario contains information about environment information, reflection atlas, etc.</para>
    /// </summary>
    public static void ViewportSetScenario(Rid viewport, Rid scenario)
    {
        NativeCalls.godot_icall_2_430(MethodBind269, GodotObject.GetPtr(Singleton), viewport, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind270 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportAttachCanvas, 395945892ul);

    /// <summary>
    /// <para>Sets a viewport's canvas.</para>
    /// </summary>
    public static void ViewportAttachCanvas(Rid viewport, Rid canvas)
    {
        NativeCalls.godot_icall_2_430(MethodBind270, GodotObject.GetPtr(Singleton), viewport, canvas);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind271 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportRemoveCanvas, 395945892ul);

    /// <summary>
    /// <para>Detaches a viewport from a canvas.</para>
    /// </summary>
    public static void ViewportRemoveCanvas(Rid viewport, Rid canvas)
    {
        NativeCalls.godot_icall_2_430(MethodBind271, GodotObject.GetPtr(Singleton), viewport, canvas);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind272 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetSnap2DTransformsToPixel, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, canvas item transforms (i.e. origin position) are snapped to the nearest pixel when rendering. This can lead to a crisper appearance at the cost of less smooth movement, especially when <see cref="Godot.Camera2D"/> smoothing is enabled. Equivalent to <c>ProjectSettings.rendering/2d/snap/snap_2d_transforms_to_pixel</c>.</para>
    /// </summary>
    public static void ViewportSetSnap2DTransformsToPixel(Rid viewport, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind272, GodotObject.GetPtr(Singleton), viewport, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind273 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetSnap2DVerticesToPixel, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, canvas item vertices (i.e. polygon points) are snapped to the nearest pixel when rendering. This can lead to a crisper appearance at the cost of less smooth movement, especially when <see cref="Godot.Camera2D"/> smoothing is enabled. Equivalent to <c>ProjectSettings.rendering/2d/snap/snap_2d_vertices_to_pixel</c>.</para>
    /// </summary>
    public static void ViewportSetSnap2DVerticesToPixel(Rid viewport, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind273, GodotObject.GetPtr(Singleton), viewport, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind274 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetDefaultCanvasItemTextureFilter, 1155129294ul);

    /// <summary>
    /// <para>Sets the default texture filtering mode for the specified <paramref name="viewport"/> RID.</para>
    /// </summary>
    public static void ViewportSetDefaultCanvasItemTextureFilter(Rid viewport, RenderingServer.CanvasItemTextureFilter filter)
    {
        NativeCalls.godot_icall_2_426(MethodBind274, GodotObject.GetPtr(Singleton), viewport, (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind275 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetDefaultCanvasItemTextureRepeat, 1652956681ul);

    /// <summary>
    /// <para>Sets the default texture repeat mode for the specified <paramref name="viewport"/> RID.</para>
    /// </summary>
    public static void ViewportSetDefaultCanvasItemTextureRepeat(Rid viewport, RenderingServer.CanvasItemTextureRepeat repeat)
    {
        NativeCalls.godot_icall_2_426(MethodBind275, GodotObject.GetPtr(Singleton), viewport, (int)repeat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind276 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetCanvasTransform, 3608606053ul);

    /// <summary>
    /// <para>Sets the transformation of a viewport's canvas.</para>
    /// </summary>
    public static unsafe void ViewportSetCanvasTransform(Rid viewport, Rid canvas, Transform2D offset)
    {
        NativeCalls.godot_icall_3_1160(MethodBind276, GodotObject.GetPtr(Singleton), viewport, canvas, &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind277 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetCanvasStacking, 3713930247ul);

    /// <summary>
    /// <para>Sets the stacking order for a viewport's canvas.</para>
    /// <para><paramref name="layer"/> is the actual canvas layer, while <paramref name="sublayer"/> specifies the stacking order of the canvas among those in the same layer.</para>
    /// <para><b>Note:</b> <paramref name="layer"/> should be between <see cref="Godot.RenderingServer.CanvasLayerMin"/> and <see cref="Godot.RenderingServer.CanvasLayerMax"/> (inclusive). Any other value will wrap around.</para>
    /// </summary>
    public static void ViewportSetCanvasStacking(Rid viewport, Rid canvas, int layer, int sublayer)
    {
        NativeCalls.godot_icall_4_1161(MethodBind277, GodotObject.GetPtr(Singleton), viewport, canvas, layer, sublayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind278 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetTransparentBackground, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport renders its background as transparent.</para>
    /// </summary>
    public static void ViewportSetTransparentBackground(Rid viewport, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind278, GodotObject.GetPtr(Singleton), viewport, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind279 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetGlobalCanvasTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets the viewport's global transformation matrix.</para>
    /// </summary>
    public static unsafe void ViewportSetGlobalCanvasTransform(Rid viewport, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind279, GodotObject.GetPtr(Singleton), viewport, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind280 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetSdfOversizeAndScale, 1329198632ul);

    /// <summary>
    /// <para>Sets the viewport's 2D signed distance field <c>ProjectSettings.rendering/2d/sdf/oversize</c> and <c>ProjectSettings.rendering/2d/sdf/scale</c>. This is used when sampling the signed distance field in <see cref="Godot.CanvasItem"/> shaders as well as <see cref="Godot.GpuParticles2D"/> collision. This is <i>not</i> used by SDFGI in 3D rendering.</para>
    /// </summary>
    public static void ViewportSetSdfOversizeAndScale(Rid viewport, RenderingServer.ViewportSdfOversize oversize, RenderingServer.ViewportSdfScale scale)
    {
        NativeCalls.godot_icall_3_433(MethodBind280, GodotObject.GetPtr(Singleton), viewport, (int)oversize, (int)scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind281 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetPositionalShadowAtlasSize, 1904426712ul);

    /// <summary>
    /// <para>Sets the <paramref name="size"/> of the shadow atlas's images (used for omni and spot lights) on the viewport specified by the <paramref name="viewport"/> RID. The value is rounded up to the nearest power of 2. If <paramref name="use16Bits"/> is <see langword="true"/>, use 16 bits for the omni/spot shadow depth map. Enabling this results in shadows having less precision and may result in shadow acne, but can lead to performance improvements on some devices.</para>
    /// <para><b>Note:</b> If this is set to <c>0</c>, no positional shadows will be visible at all. This can improve performance significantly on low-end systems by reducing both the CPU and GPU load (as fewer draw calls are needed to draw the scene without shadows).</para>
    /// </summary>
    public static void ViewportSetPositionalShadowAtlasSize(Rid viewport, int size, bool use16Bits = false)
    {
        NativeCalls.godot_icall_3_439(MethodBind281, GodotObject.GetPtr(Singleton), viewport, size, use16Bits.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind282 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetPositionalShadowAtlasQuadrantSubdivision, 4288446313ul);

    /// <summary>
    /// <para>Sets the number of subdivisions to use in the specified shadow atlas <paramref name="quadrant"/> for omni and spot shadows. See also <see cref="Godot.Viewport.SetPositionalShadowAtlasQuadrantSubdiv(int, Viewport.PositionalShadowAtlasQuadrantSubdiv)"/>.</para>
    /// </summary>
    public static void ViewportSetPositionalShadowAtlasQuadrantSubdivision(Rid viewport, int quadrant, int subdivision)
    {
        NativeCalls.godot_icall_3_433(MethodBind282, GodotObject.GetPtr(Singleton), viewport, quadrant, subdivision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind283 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetMsaa3D, 3764433340ul);

    /// <summary>
    /// <para>Sets the multisample antialiasing mode for 3D on the specified <paramref name="viewport"/> RID. Equivalent to <c>ProjectSettings.rendering/anti_aliasing/quality/msaa_3d</c> or <see cref="Godot.Viewport.Msaa3D"/>.</para>
    /// </summary>
    public static void ViewportSetMsaa3D(Rid viewport, RenderingServer.ViewportMsaa msaa)
    {
        NativeCalls.godot_icall_2_426(MethodBind283, GodotObject.GetPtr(Singleton), viewport, (int)msaa);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind284 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetMsaa2D, 3764433340ul);

    /// <summary>
    /// <para>Sets the multisample antialiasing mode for 2D/Canvas on the specified <paramref name="viewport"/> RID. Equivalent to <c>ProjectSettings.rendering/anti_aliasing/quality/msaa_2d</c> or <see cref="Godot.Viewport.Msaa2D"/>.</para>
    /// </summary>
    public static void ViewportSetMsaa2D(Rid viewport, RenderingServer.ViewportMsaa msaa)
    {
        NativeCalls.godot_icall_2_426(MethodBind284, GodotObject.GetPtr(Singleton), viewport, (int)msaa);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind285 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUseHdr2D, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, 2D rendering will use a high dynamic range (HDR) <c>RGBA16</c> format framebuffer. Additionally, 2D rendering will be performed on linear values and will be converted using the appropriate transfer function immediately before blitting to the screen (if the Viewport is attached to the screen).</para>
    /// <para>Practically speaking, this means that the end result of the Viewport will not be clamped to the <c>0-1</c> range and can be used in 3D rendering without color encoding adjustments. This allows 2D rendering to take advantage of effects requiring high dynamic range (e.g. 2D glow) as well as substantially improves the appearance of effects requiring highly detailed gradients. This setting has the same effect as <see cref="Godot.Viewport.UseHdr2D"/>.</para>
    /// </summary>
    public static void ViewportSetUseHdr2D(Rid viewport, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind285, GodotObject.GetPtr(Singleton), viewport, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind286 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetScreenSpaceAA, 1447279591ul);

    /// <summary>
    /// <para>Sets the viewport's screen-space antialiasing mode. Equivalent to <c>ProjectSettings.rendering/anti_aliasing/quality/screen_space_aa</c> or <see cref="Godot.Viewport.ScreenSpaceAA"/>.</para>
    /// </summary>
    public static void ViewportSetScreenSpaceAA(Rid viewport, RenderingServer.ViewportScreenSpaceAA mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind286, GodotObject.GetPtr(Singleton), viewport, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind287 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUseTaa, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, use temporal antialiasing. Equivalent to <c>ProjectSettings.rendering/anti_aliasing/quality/use_taa</c> or <see cref="Godot.Viewport.UseTaa"/>.</para>
    /// </summary>
    public static void ViewportSetUseTaa(Rid viewport, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind287, GodotObject.GetPtr(Singleton), viewport, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind288 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUseDebanding, 1265174801ul);

    /// <summary>
    /// <para>Equivalent to <see cref="Godot.Viewport.UseDebanding"/>. See also <c>ProjectSettings.rendering/anti_aliasing/quality/use_debanding</c>.</para>
    /// </summary>
    public static void ViewportSetUseDebanding(Rid viewport, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind288, GodotObject.GetPtr(Singleton), viewport, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind289 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetUseOcclusionCulling, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, enables occlusion culling on the specified viewport. Equivalent to <c>ProjectSettings.rendering/occlusion_culling/use_occlusion_culling</c>.</para>
    /// </summary>
    public static void ViewportSetUseOcclusionCulling(Rid viewport, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind289, GodotObject.GetPtr(Singleton), viewport, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind290 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetOcclusionRaysPerThread, 1286410249ul);

    /// <summary>
    /// <para>Sets the <c>ProjectSettings.rendering/occlusion_culling/occlusion_rays_per_thread</c> to use for occlusion culling. This parameter is global and cannot be set on a per-viewport basis.</para>
    /// </summary>
    public static void ViewportSetOcclusionRaysPerThread(int raysPerThread)
    {
        NativeCalls.godot_icall_1_38(MethodBind290, GodotObject.GetPtr(Singleton), raysPerThread);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind291 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetOcclusionCullingBuildQuality, 2069725696ul);

    /// <summary>
    /// <para>Sets the <c>ProjectSettings.rendering/occlusion_culling/bvh_build_quality</c> to use for occlusion culling. This parameter is global and cannot be set on a per-viewport basis.</para>
    /// </summary>
    public static void ViewportSetOcclusionCullingBuildQuality(RenderingServer.ViewportOcclusionCullingBuildQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind291, GodotObject.GetPtr(Singleton), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind292 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetRenderInfo, 2041262392ul);

    /// <summary>
    /// <para>Returns a statistic about the rendering engine which can be used for performance profiling. This is separated into render pass <paramref name="type"/>s, each of them having the same <paramref name="info"/>s you can query (different passes will return different values).</para>
    /// <para>See also <see cref="Godot.RenderingServer.GetRenderingInfo(RenderingServer.RenderingInfo)"/>, which returns global information across all viewports.</para>
    /// <para><b>Note:</b> Viewport rendering information is not available until at least 2 frames have been rendered by the engine. If rendering information is not available, <see cref="Godot.RenderingServer.ViewportGetRenderInfo(Rid, RenderingServer.ViewportRenderInfoType, RenderingServer.ViewportRenderInfo)"/> returns <c>0</c>. To print rendering information in <c>_ready()</c> successfully, use the following:</para>
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
    public static int ViewportGetRenderInfo(Rid viewport, RenderingServer.ViewportRenderInfoType type, RenderingServer.ViewportRenderInfo info)
    {
        return NativeCalls.godot_icall_3_1162(MethodBind292, GodotObject.GetPtr(Singleton), viewport, (int)type, (int)info);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind293 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetDebugDraw, 2089420930ul);

    /// <summary>
    /// <para>Sets the debug draw mode of a viewport.</para>
    /// </summary>
    public static void ViewportSetDebugDraw(Rid viewport, RenderingServer.ViewportDebugDraw draw)
    {
        NativeCalls.godot_icall_2_426(MethodBind293, GodotObject.GetPtr(Singleton), viewport, (int)draw);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind294 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetMeasureRenderTime, 1265174801ul);

    /// <summary>
    /// <para>Sets the measurement for the given <paramref name="viewport"/> RID (obtained using <see cref="Godot.Viewport.GetViewportRid()"/>). Once enabled, <see cref="Godot.RenderingServer.ViewportGetMeasuredRenderTimeCpu(Rid)"/> and <see cref="Godot.RenderingServer.ViewportGetMeasuredRenderTimeGpu(Rid)"/> will return values greater than <c>0.0</c> when queried with the given <paramref name="viewport"/>.</para>
    /// </summary>
    public static void ViewportSetMeasureRenderTime(Rid viewport, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind294, GodotObject.GetPtr(Singleton), viewport, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind295 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetMeasuredRenderTimeCpu, 866169185ul);

    /// <summary>
    /// <para>Returns the CPU time taken to render the last frame in milliseconds. This <i>only</i> includes time spent in rendering-related operations; scripts' <c>_process</c> functions and other engine subsystems are not included in this readout. To get a complete readout of CPU time spent to render the scene, sum the render times of all viewports that are drawn every frame plus <see cref="Godot.RenderingServer.GetFrameSetupTimeCpu()"/>. Unlike <see cref="Godot.Engine.GetFramesPerSecond()"/>, this method will accurately reflect CPU utilization even if framerate is capped via V-Sync or <see cref="Godot.Engine.MaxFps"/>. See also <see cref="Godot.RenderingServer.ViewportGetMeasuredRenderTimeGpu(Rid)"/>.</para>
    /// <para><b>Note:</b> Requires measurements to be enabled on the specified <paramref name="viewport"/> using <see cref="Godot.RenderingServer.ViewportSetMeasureRenderTime(Rid, bool)"/>. Otherwise, this method returns <c>0.0</c>.</para>
    /// </summary>
    public static double ViewportGetMeasuredRenderTimeCpu(Rid viewport)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind295, GodotObject.GetPtr(Singleton), viewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind296 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportGetMeasuredRenderTimeGpu, 866169185ul);

    /// <summary>
    /// <para>Returns the GPU time taken to render the last frame in milliseconds. To get a complete readout of GPU time spent to render the scene, sum the render times of all viewports that are drawn every frame. Unlike <see cref="Godot.Engine.GetFramesPerSecond()"/>, this method accurately reflects GPU utilization even if framerate is capped via V-Sync or <see cref="Godot.Engine.MaxFps"/>. See also <see cref="Godot.RenderingServer.ViewportGetMeasuredRenderTimeCpu(Rid)"/>.</para>
    /// <para><b>Note:</b> Requires measurements to be enabled on the specified <paramref name="viewport"/> using <see cref="Godot.RenderingServer.ViewportSetMeasureRenderTime(Rid, bool)"/>. Otherwise, this method returns <c>0.0</c>.</para>
    /// <para><b>Note:</b> When GPU utilization is low enough during a certain period of time, GPUs will decrease their power state (which in turn decreases core and memory clock speeds). This can cause the reported GPU time to increase if GPU utilization is kept low enough by a framerate cap (compared to what it would be at the GPU's highest power state). Keep this in mind when benchmarking using <see cref="Godot.RenderingServer.ViewportGetMeasuredRenderTimeGpu(Rid)"/>. This behavior can be overridden in the graphics driver settings at the cost of higher power usage.</para>
    /// </summary>
    public static double ViewportGetMeasuredRenderTimeGpu(Rid viewport)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind296, GodotObject.GetPtr(Singleton), viewport);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind297 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetVrsMode, 398809874ul);

    /// <summary>
    /// <para>Sets the Variable Rate Shading (VRS) mode for the viewport. If the GPU does not support VRS, this property is ignored. Equivalent to <c>ProjectSettings.rendering/vrs/mode</c>.</para>
    /// </summary>
    public static void ViewportSetVrsMode(Rid viewport, RenderingServer.ViewportVrsMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind297, GodotObject.GetPtr(Singleton), viewport, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind298 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetVrsUpdateMode, 2696154815ul);

    /// <summary>
    /// <para>Sets the update mode for Variable Rate Shading (VRS) for the viewport. VRS requires the input texture to be converted to the format usable by the VRS method supported by the hardware. The update mode defines how often this happens. If the GPU does not support VRS, or VRS is not enabled, this property is ignored.</para>
    /// <para>If set to <see cref="Godot.RenderingServer.ViewportVrsUpdateMode.Once"/>, the input texture is copied once and the mode is changed to <see cref="Godot.RenderingServer.ViewportVrsUpdateMode.Disabled"/>.</para>
    /// </summary>
    public static void ViewportSetVrsUpdateMode(Rid viewport, RenderingServer.ViewportVrsUpdateMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind298, GodotObject.GetPtr(Singleton), viewport, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind299 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ViewportSetVrsTexture, 395945892ul);

    /// <summary>
    /// <para>The texture to use when the VRS mode is set to <see cref="Godot.RenderingServer.ViewportVrsMode.Texture"/>. Equivalent to <c>ProjectSettings.rendering/vrs/texture</c>.</para>
    /// </summary>
    public static void ViewportSetVrsTexture(Rid viewport, Rid texture)
    {
        NativeCalls.godot_icall_2_430(MethodBind299, GodotObject.GetPtr(Singleton), viewport, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind300 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkyCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an empty sky and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>sky_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// </summary>
    public static Rid SkyCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind300, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind301 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkySetRadianceSize, 3411492887ul);

    /// <summary>
    /// <para>Sets the <paramref name="radianceSize"/> of the sky specified by the <paramref name="sky"/> RID (in pixels). Equivalent to <see cref="Godot.Sky.RadianceSize"/>.</para>
    /// </summary>
    public static void SkySetRadianceSize(Rid sky, int radianceSize)
    {
        NativeCalls.godot_icall_2_426(MethodBind301, GodotObject.GetPtr(Singleton), sky, radianceSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind302 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkySetMode, 3279019937ul);

    /// <summary>
    /// <para>Sets the process <paramref name="mode"/> of the sky specified by the <paramref name="sky"/> RID. Equivalent to <see cref="Godot.Sky.ProcessMode"/>.</para>
    /// </summary>
    public static void SkySetMode(Rid sky, RenderingServer.SkyMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind302, GodotObject.GetPtr(Singleton), sky, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind303 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkySetMaterial, 395945892ul);

    /// <summary>
    /// <para>Sets the material that the sky uses to render the background, ambient and reflection maps.</para>
    /// </summary>
    public static void SkySetMaterial(Rid sky, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind303, GodotObject.GetPtr(Singleton), sky, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind304 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SkyBakePanorama, 3875285818ul);

    /// <summary>
    /// <para>Generates and returns an <see cref="Godot.Image"/> containing the radiance map for the specified <paramref name="sky"/> RID. This supports built-in sky material and custom sky shaders. If <paramref name="bakeIrradiance"/> is <see langword="true"/>, the irradiance map is saved instead of the radiance map. The radiance map is used to render reflected light, while the irradiance map is used to render ambient light. See also <see cref="Godot.RenderingServer.EnvironmentBakePanorama(Rid, bool, Vector2I)"/>.</para>
    /// <para><b>Note:</b> The image is saved using linear encoding without any tonemapping performed, which means it will look too dark if viewed directly in an image editor. <paramref name="energy"/> values above <c>1.0</c> can be used to brighten the resulting image.</para>
    /// <para><b>Note:</b> <paramref name="size"/> should be a 2:1 aspect ratio for the generated panorama to have square pixels. For radiance maps, there is no point in using a height greater than <see cref="Godot.Sky.RadianceSize"/>, as it won't increase detail. Irradiance maps only contain low-frequency data, so there is usually no point in going past a size of 128×64 pixels when saving an irradiance map.</para>
    /// </summary>
    public static unsafe Image SkyBakePanorama(Rid sky, float energy, bool bakeIrradiance, Vector2I size)
    {
        return (Image)NativeCalls.godot_icall_4_1164(MethodBind304, GodotObject.GetPtr(Singleton), sky, energy, bakeIrradiance.ToGodotBool(), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind305 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorEffectCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new rendering effect and adds it to the RenderingServer. It can be accessed with the RID that is returned.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// </summary>
    public static Rid CompositorEffectCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind305, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind306 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorEffectSetEnabled, 1265174801ul);

    /// <summary>
    /// <para>Enables/disables this rendering effect.</para>
    /// </summary>
    public static void CompositorEffectSetEnabled(Rid effect, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind306, GodotObject.GetPtr(Singleton), effect, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind307 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorEffectSetCallback, 487412485ul);

    /// <summary>
    /// <para>Sets the callback type (<paramref name="callbackType"/>) and callback method(<paramref name="callback"/>) for this rendering effect.</para>
    /// </summary>
    public static void CompositorEffectSetCallback(Rid effect, RenderingServer.CompositorEffectCallbackType callbackType, Callable callback)
    {
        NativeCalls.godot_icall_3_431(MethodBind307, GodotObject.GetPtr(Singleton), effect, (int)callbackType, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind308 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorEffectSetFlag, 3659527075ul);

    /// <summary>
    /// <para>Sets the flag (<paramref name="flag"/>) for this rendering effect to <see langword="true"/> or <see langword="false"/> (<paramref name="set"/>).</para>
    /// </summary>
    public static void CompositorEffectSetFlag(Rid effect, RenderingServer.CompositorEffectFlags flag, bool set)
    {
        NativeCalls.godot_icall_3_439(MethodBind308, GodotObject.GetPtr(Singleton), effect, (int)flag, set.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind309 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new compositor and adds it to the RenderingServer. It can be accessed with the RID that is returned.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// </summary>
    public static Rid CompositorCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind309, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind310 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CompositorSetCompositorEffects, 684822712ul);

    /// <summary>
    /// <para>Sets the compositor effects for the specified compositor RID. <paramref name="effects"/> should be an array containing RIDs created with <see cref="Godot.RenderingServer.CompositorEffectCreate()"/>.</para>
    /// </summary>
    public static void CompositorSetCompositorEffects(Rid compositor, Godot.Collections.Array<Rid> effects)
    {
        NativeCalls.godot_icall_2_1122(MethodBind310, GodotObject.GetPtr(Singleton), compositor, (godot_array)(effects ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind311 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentCreate, 529393457ul);

    /// <summary>
    /// <para>Creates an environment and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>environment_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.Environment"/>.</para>
    /// </summary>
    public static Rid EnvironmentCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind311, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind312 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetBackground, 3937328877ul);

    /// <summary>
    /// <para>Sets the environment's background mode. Equivalent to <see cref="Godot.Environment.BackgroundMode"/>.</para>
    /// </summary>
    public static void EnvironmentSetBackground(Rid env, RenderingServer.EnvironmentBG bg)
    {
        NativeCalls.godot_icall_2_426(MethodBind312, GodotObject.GetPtr(Singleton), env, (int)bg);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind313 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetCameraId, 3411492887ul);

    /// <summary>
    /// <para>Sets the camera ID to be used as environment background.</para>
    /// </summary>
    public static void EnvironmentSetCameraId(Rid env, int id)
    {
        NativeCalls.godot_icall_2_426(MethodBind313, GodotObject.GetPtr(Singleton), env, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind314 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSky, 395945892ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Sky"/> to be used as the environment's background when using <i>BGMode</i> sky. Equivalent to <see cref="Godot.Environment.Sky"/>.</para>
    /// </summary>
    public static void EnvironmentSetSky(Rid env, Rid sky)
    {
        NativeCalls.godot_icall_2_430(MethodBind314, GodotObject.GetPtr(Singleton), env, sky);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind315 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSkyCustomFov, 1794382983ul);

    /// <summary>
    /// <para>Sets a custom field of view for the background <see cref="Godot.Sky"/>. Equivalent to <see cref="Godot.Environment.SkyCustomFov"/>.</para>
    /// </summary>
    public static void EnvironmentSetSkyCustomFov(Rid env, float scale)
    {
        NativeCalls.godot_icall_2_816(MethodBind315, GodotObject.GetPtr(Singleton), env, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind316 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSkyOrientation, 1735850857ul);

    /// <summary>
    /// <para>Sets the rotation of the background <see cref="Godot.Sky"/> expressed as a <see cref="Godot.Basis"/>. Equivalent to <see cref="Godot.Environment.SkyRotation"/>, where the rotation vector is used to construct the <see cref="Godot.Basis"/>.</para>
    /// </summary>
    public static unsafe void EnvironmentSetSkyOrientation(Rid env, Basis orientation)
    {
        NativeCalls.godot_icall_2_1165(MethodBind316, GodotObject.GetPtr(Singleton), env, &orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind317 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetBgColor, 2948539648ul);

    /// <summary>
    /// <para>Color displayed for clear areas of the scene. Only effective if using the <see cref="Godot.RenderingServer.EnvironmentBG.Color"/> background mode.</para>
    /// </summary>
    public static unsafe void EnvironmentSetBgColor(Rid env, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind317, GodotObject.GetPtr(Singleton), env, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind318 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetBgEnergy, 2513314492ul);

    /// <summary>
    /// <para>Sets the intensity of the background color.</para>
    /// </summary>
    public static void EnvironmentSetBgEnergy(Rid env, float multiplier, float exposureValue)
    {
        NativeCalls.godot_icall_3_1145(MethodBind318, GodotObject.GetPtr(Singleton), env, multiplier, exposureValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind319 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetCanvasMaxLayer, 3411492887ul);

    /// <summary>
    /// <para>Sets the maximum layer to use if using Canvas background mode.</para>
    /// </summary>
    public static void EnvironmentSetCanvasMaxLayer(Rid env, int maxLayer)
    {
        NativeCalls.godot_icall_2_426(MethodBind319, GodotObject.GetPtr(Singleton), env, maxLayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind320 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetAmbientLight, 1214961493ul);

    /// <summary>
    /// <para>Sets the values to be used for ambient light rendering. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public static unsafe void EnvironmentSetAmbientLight(Rid env, Color color, RenderingServer.EnvironmentAmbientSource ambient = (RenderingServer.EnvironmentAmbientSource)(0), float energy = 1.0f, float skyContribution = 0.0f, RenderingServer.EnvironmentReflectionSource reflectionSource = (RenderingServer.EnvironmentReflectionSource)(0))
    {
        NativeCalls.godot_icall_6_1166(MethodBind320, GodotObject.GetPtr(Singleton), env, &color, (int)ambient, energy, skyContribution, (int)reflectionSource);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind321 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetGlow, 2421724940ul);

    /// <summary>
    /// <para>Configures glow for the specified environment RID. See <c>glow_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    public static void EnvironmentSetGlow(Rid env, bool enable, float[] levels, float intensity, float strength, float mix, float bloomThreshold, RenderingServer.EnvironmentGlowBlendMode blendMode, float hdrBleedThreshold, float hdrBleedScale, float hdrLuminanceCap, float glowMapStrength, Rid glowMap)
    {
        NativeCalls.godot_icall_13_1167(MethodBind321, GodotObject.GetPtr(Singleton), env, enable.ToGodotBool(), levels, intensity, strength, mix, bloomThreshold, (int)blendMode, hdrBleedThreshold, hdrBleedScale, hdrLuminanceCap, glowMapStrength, glowMap);
    }

    /// <summary>
    /// <para>Configures glow for the specified environment RID. See <c>glow_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    public static void EnvironmentSetGlow(Rid env, bool enable, ReadOnlySpan<float> levels, float intensity, float strength, float mix, float bloomThreshold, RenderingServer.EnvironmentGlowBlendMode blendMode, float hdrBleedThreshold, float hdrBleedScale, float hdrLuminanceCap, float glowMapStrength, Rid glowMap)
    {
        NativeCalls.godot_icall_13_1167(MethodBind321, GodotObject.GetPtr(Singleton), env, enable.ToGodotBool(), levels, intensity, strength, mix, bloomThreshold, (int)blendMode, hdrBleedThreshold, hdrBleedScale, hdrLuminanceCap, glowMapStrength, glowMap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind322 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetTonemap, 2914312638ul);

    /// <summary>
    /// <para>Sets the variables to be used with the "tonemap" post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public static void EnvironmentSetTonemap(Rid env, RenderingServer.EnvironmentToneMapper toneMapper, float exposure, float white)
    {
        NativeCalls.godot_icall_4_1168(MethodBind322, GodotObject.GetPtr(Singleton), env, (int)toneMapper, exposure, white);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind323 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetTonemapAgxContrast, 1794382983ul);

    /// <summary>
    /// <para>See <see cref="Godot.Environment.TonemapAgxContrast"/> for more details.</para>
    /// </summary>
    public static void EnvironmentSetTonemapAgxContrast(Rid env, float agxContrast)
    {
        NativeCalls.godot_icall_2_816(MethodBind323, GodotObject.GetPtr(Singleton), env, agxContrast);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind324 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetAdjustment, 876799838ul);

    /// <summary>
    /// <para>Sets the values to be used with the "adjustments" post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public static void EnvironmentSetAdjustment(Rid env, bool enable, float brightness, float contrast, float saturation, bool use1DColorCorrection, Rid colorCorrection)
    {
        NativeCalls.godot_icall_7_1169(MethodBind324, GodotObject.GetPtr(Singleton), env, enable.ToGodotBool(), brightness, contrast, saturation, use1DColorCorrection.ToGodotBool(), colorCorrection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind325 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsr, 3607294374ul);

    /// <summary>
    /// <para>Sets the variables to be used with the screen-space reflections (SSR) post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public static void EnvironmentSetSsr(Rid env, bool enable, int maxSteps, float fadeIn, float fadeOut, float depthTolerance)
    {
        NativeCalls.godot_icall_6_1170(MethodBind325, GodotObject.GetPtr(Singleton), env, enable.ToGodotBool(), maxSteps, fadeIn, fadeOut, depthTolerance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind326 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsao, 3994732740ul);

    /// <summary>
    /// <para>Sets the variables to be used with the screen-space ambient occlusion (SSAO) post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public static void EnvironmentSetSsao(Rid env, bool enable, float radius, float intensity, float power, float detail, float horizon, float sharpness, float lightAffect, float aOChannelAffect)
    {
        NativeCalls.godot_icall_10_1171(MethodBind326, GodotObject.GetPtr(Singleton), env, enable.ToGodotBool(), radius, intensity, power, detail, horizon, sharpness, lightAffect, aOChannelAffect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind327 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetFog, 105051629ul);

    /// <summary>
    /// <para>Configures fog for the specified environment RID. See <c>fog_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    public static unsafe void EnvironmentSetFog(Rid env, bool enable, Color lightColor, float lightEnergy, float sunScatter, float density, float height, float heightDensity, float aerialPerspective, float skyAffect, RenderingServer.EnvironmentFogMode fogMode = (RenderingServer.EnvironmentFogMode)(0))
    {
        NativeCalls.godot_icall_11_1172(MethodBind327, GodotObject.GetPtr(Singleton), env, enable.ToGodotBool(), &lightColor, lightEnergy, sunScatter, density, height, heightDensity, aerialPerspective, skyAffect, (int)fogMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind328 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetFogDepth, 157498339ul);

    /// <summary>
    /// <para>Configures fog depth for the specified environment RID. Only has an effect when the fog mode of the environment is <see cref="Godot.RenderingServer.EnvironmentFogMode.Depth"/>. See <c>fog_depth_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    public static void EnvironmentSetFogDepth(Rid env, float curve, float begin, float end)
    {
        NativeCalls.godot_icall_4_1157(MethodBind328, GodotObject.GetPtr(Singleton), env, curve, begin, end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind329 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSdfgi, 3519144388ul);

    /// <summary>
    /// <para>Configures signed distance field global illumination for the specified environment RID. See <c>sdfgi_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    public static void EnvironmentSetSdfgi(Rid env, bool enable, int cascades, float minCellSize, RenderingServer.EnvironmentSdfgiyScale yScale, bool useOcclusion, float bounceFeedback, bool readSky, float energy, float normalBias, float probeBias)
    {
        NativeCalls.godot_icall_11_1173(MethodBind329, GodotObject.GetPtr(Singleton), env, enable.ToGodotBool(), cascades, minCellSize, (int)yScale, useOcclusion.ToGodotBool(), bounceFeedback, readSky.ToGodotBool(), energy, normalBias, probeBias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind330 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetVolumetricFog, 1553633833ul);

    /// <summary>
    /// <para>Sets the variables to be used with the volumetric fog post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public static unsafe void EnvironmentSetVolumetricFog(Rid env, bool enable, float density, Color albedo, Color emission, float emissionEnergy, float anisotropy, float length, float pDetailSpread, float gIInject, bool temporalReprojection, float temporalReprojectionAmount, float ambientInject, float skyAffect)
    {
        NativeCalls.godot_icall_14_1174(MethodBind330, GodotObject.GetPtr(Singleton), env, enable.ToGodotBool(), density, &albedo, &emission, emissionEnergy, anisotropy, length, pDetailSpread, gIInject, temporalReprojection.ToGodotBool(), temporalReprojectionAmount, ambientInject, skyAffect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind331 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentGlowSetUseBicubicUpscale, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="enable"/> is <see langword="true"/>, enables bicubic upscaling for glow which improves quality at the cost of performance. Equivalent to <c>ProjectSettings.rendering/environment/glow/upscale_mode</c>.</para>
    /// <para><b>Note:</b> This setting is only effective when using the Forward+ or Mobile rendering methods, as Compatibility uses a different glow implementation.</para>
    /// </summary>
    public static void EnvironmentGlowSetUseBicubicUpscale(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind331, GodotObject.GetPtr(Singleton), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind332 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsrHalfSize, 2586408642ul);

    /// <summary>
    /// <para>Sets whether screen-space reflections will be rendered at full or half size. Half size is faster, but may look pixelated or cause flickering.</para>
    /// </summary>
    public static void EnvironmentSetSsrHalfSize(bool halfSize)
    {
        NativeCalls.godot_icall_1_14(MethodBind332, GodotObject.GetPtr(Singleton), halfSize.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind333 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsrRoughnessQuality, 1190026788ul);

    [Obsolete("This option no longer does anything.")]
    public static void EnvironmentSetSsrRoughnessQuality(RenderingServer.EnvironmentSsrRoughnessQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind333, GodotObject.GetPtr(Singleton), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind334 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsaoQuality, 189753569ul);

    /// <summary>
    /// <para>Sets the quality level of the screen-space ambient occlusion (SSAO) post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public static void EnvironmentSetSsaoQuality(RenderingServer.EnvironmentSsaoQuality quality, bool halfSize, float adaptiveTarget, int blurPasses, float fadeOutFrom, float fadeOutTo)
    {
        NativeCalls.godot_icall_6_1175(MethodBind334, GodotObject.GetPtr(Singleton), (int)quality, halfSize.ToGodotBool(), adaptiveTarget, blurPasses, fadeOutFrom, fadeOutTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind335 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSsilQuality, 1713836683ul);

    /// <summary>
    /// <para>Sets the quality level of the screen-space indirect lighting (SSIL) post-process effect. See <see cref="Godot.Environment"/> for more details.</para>
    /// </summary>
    public static void EnvironmentSetSsilQuality(RenderingServer.EnvironmentSsilQuality quality, bool halfSize, float adaptiveTarget, int blurPasses, float fadeOutFrom, float fadeOutTo)
    {
        NativeCalls.godot_icall_6_1175(MethodBind335, GodotObject.GetPtr(Singleton), (int)quality, halfSize.ToGodotBool(), adaptiveTarget, blurPasses, fadeOutFrom, fadeOutTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind336 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSdfgiRayCount, 340137951ul);

    /// <summary>
    /// <para>Sets the number of rays to throw per frame when computing signed distance field global illumination. Equivalent to <c>ProjectSettings.rendering/global_illumination/sdfgi/probe_ray_count</c>.</para>
    /// </summary>
    public static void EnvironmentSetSdfgiRayCount(RenderingServer.EnvironmentSdfgiRayCount rayCount)
    {
        NativeCalls.godot_icall_1_38(MethodBind336, GodotObject.GetPtr(Singleton), (int)rayCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind337 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSdfgiFramesToConverge, 2182444374ul);

    /// <summary>
    /// <para>Sets the number of frames to use for converging signed distance field global illumination. Equivalent to <c>ProjectSettings.rendering/global_illumination/sdfgi/frames_to_converge</c>.</para>
    /// </summary>
    public static void EnvironmentSetSdfgiFramesToConverge(RenderingServer.EnvironmentSdfgiFramesToConverge frames)
    {
        NativeCalls.godot_icall_1_38(MethodBind337, GodotObject.GetPtr(Singleton), (int)frames);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind338 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetSdfgiFramesToUpdateLight, 1251144068ul);

    /// <summary>
    /// <para>Sets the update speed for dynamic lights' indirect lighting when computing signed distance field global illumination. Equivalent to <c>ProjectSettings.rendering/global_illumination/sdfgi/frames_to_update_lights</c>.</para>
    /// </summary>
    public static void EnvironmentSetSdfgiFramesToUpdateLight(RenderingServer.EnvironmentSdfgiFramesToUpdateLight frames)
    {
        NativeCalls.godot_icall_1_38(MethodBind338, GodotObject.GetPtr(Singleton), (int)frames);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind339 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetVolumetricFogVolumeSize, 3937882851ul);

    /// <summary>
    /// <para>Sets the resolution of the volumetric fog's froxel buffer. <paramref name="size"/> is modified by the screen's aspect ratio and then used to set the width and height of the buffer. While <paramref name="depth"/> is directly used to set the depth of the buffer.</para>
    /// </summary>
    public static void EnvironmentSetVolumetricFogVolumeSize(int size, int depth)
    {
        NativeCalls.godot_icall_2_59(MethodBind339, GodotObject.GetPtr(Singleton), size, depth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind340 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetVolumetricFogFilterActive, 2586408642ul);

    /// <summary>
    /// <para>Enables filtering of the volumetric fog scattering buffer. This results in much smoother volumes with very few under-sampling artifacts.</para>
    /// </summary>
    public static void EnvironmentSetVolumetricFogFilterActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind340, GodotObject.GetPtr(Singleton), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind341 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentBakePanorama, 2452908646ul);

    /// <summary>
    /// <para>Generates and returns an <see cref="Godot.Image"/> containing the radiance map for the specified <paramref name="environment"/> RID's sky. This supports built-in sky material and custom sky shaders. If <paramref name="bakeIrradiance"/> is <see langword="true"/>, the irradiance map is saved instead of the radiance map. The radiance map is used to render reflected light, while the irradiance map is used to render ambient light. See also <see cref="Godot.RenderingServer.SkyBakePanorama(Rid, float, bool, Vector2I)"/>.</para>
    /// <para><b>Note:</b> The image is saved using linear encoding without any tonemapping performed, which means it will look too dark if viewed directly in an image editor.</para>
    /// <para><b>Note:</b> <paramref name="size"/> should be a 2:1 aspect ratio for the generated panorama to have square pixels. For radiance maps, there is no point in using a height greater than <see cref="Godot.Sky.RadianceSize"/>, as it won't increase detail. Irradiance maps only contain low-frequency data, so there is usually no point in going past a size of 128×64 pixels when saving an irradiance map.</para>
    /// </summary>
    public static unsafe Image EnvironmentBakePanorama(Rid environment, bool bakeIrradiance, Vector2I size)
    {
        return (Image)NativeCalls.godot_icall_3_1176(MethodBind341, GodotObject.GetPtr(Singleton), environment, bakeIrradiance.ToGodotBool(), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind342 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenSpaceRoughnessLimiterSetActive, 916716790ul);

    /// <summary>
    /// <para>Sets the screen-space roughness limiter parameters, such as whether it should be enabled and its thresholds. Equivalent to <c>ProjectSettings.rendering/anti_aliasing/screen_space_roughness_limiter/enabled</c>, <c>ProjectSettings.rendering/anti_aliasing/screen_space_roughness_limiter/amount</c> and <c>ProjectSettings.rendering/anti_aliasing/screen_space_roughness_limiter/limit</c>.</para>
    /// </summary>
    public static void ScreenSpaceRoughnessLimiterSetActive(bool enable, float amount, float limit)
    {
        NativeCalls.godot_icall_3_1177(MethodBind342, GodotObject.GetPtr(Singleton), enable.ToGodotBool(), amount, limit);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind343 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SubSurfaceScatteringSetQuality, 64571803ul);

    /// <summary>
    /// <para>Sets <c>ProjectSettings.rendering/environment/subsurface_scattering/subsurface_scattering_quality</c> to use when rendering materials that have subsurface scattering enabled.</para>
    /// </summary>
    public static void SubSurfaceScatteringSetQuality(RenderingServer.SubSurfaceScatteringQuality quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind343, GodotObject.GetPtr(Singleton), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind344 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SubSurfaceScatteringSetScale, 1017552074ul);

    /// <summary>
    /// <para>Sets the <c>ProjectSettings.rendering/environment/subsurface_scattering/subsurface_scattering_scale</c> and <c>ProjectSettings.rendering/environment/subsurface_scattering/subsurface_scattering_depth_scale</c> to use when rendering materials that have subsurface scattering enabled.</para>
    /// </summary>
    public static void SubSurfaceScatteringSetScale(float scale, float depthScale)
    {
        NativeCalls.godot_icall_2_1178(MethodBind344, GodotObject.GetPtr(Singleton), scale, depthScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind345 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a camera attributes object and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>camera_attributes_</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.CameraAttributes"/>.</para>
    /// </summary>
    public static Rid CameraAttributesCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind345, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind346 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesSetDofBlurQuality, 2220136795ul);

    /// <summary>
    /// <para>Sets the quality level of the DOF blur effect to <paramref name="quality"/>. <paramref name="useJitter"/> can be used to jitter samples taken during the blur pass to hide artifacts at the cost of looking more fuzzy.</para>
    /// </summary>
    public static void CameraAttributesSetDofBlurQuality(RenderingServer.DofBlurQuality quality, bool useJitter)
    {
        NativeCalls.godot_icall_2_61(MethodBind346, GodotObject.GetPtr(Singleton), (int)quality, useJitter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind347 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesSetDofBlurBokehShape, 1205058394ul);

    /// <summary>
    /// <para>Sets the shape of the DOF bokeh pattern to <paramref name="shape"/>. Different shapes may be used to achieve artistic effect, or to meet performance targets.</para>
    /// </summary>
    public static void CameraAttributesSetDofBlurBokehShape(RenderingServer.DofBokehShape shape)
    {
        NativeCalls.godot_icall_1_38(MethodBind347, GodotObject.GetPtr(Singleton), (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind348 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesSetDofBlur, 316272616ul);

    /// <summary>
    /// <para>Sets the parameters to use with the DOF blur effect. These parameters take on the same meaning as their counterparts in <see cref="Godot.CameraAttributesPractical"/>.</para>
    /// </summary>
    public static void CameraAttributesSetDofBlur(Rid cameraAttributes, bool farEnable, float farDistance, float farTransition, bool nearEnable, float nearDistance, float nearTransition, float amount)
    {
        NativeCalls.godot_icall_8_1179(MethodBind348, GodotObject.GetPtr(Singleton), cameraAttributes, farEnable.ToGodotBool(), farDistance, farTransition, nearEnable.ToGodotBool(), nearDistance, nearTransition, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind349 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesSetExposure, 2513314492ul);

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
    public static void CameraAttributesSetExposure(Rid cameraAttributes, float multiplier, float normalization)
    {
        NativeCalls.godot_icall_3_1145(MethodBind349, GodotObject.GetPtr(Singleton), cameraAttributes, multiplier, normalization);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind350 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CameraAttributesSetAutoExposure, 4266986332ul);

    /// <summary>
    /// <para>Sets the parameters to use with the auto-exposure effect. These parameters take on the same meaning as their counterparts in <see cref="Godot.CameraAttributes"/> and <see cref="Godot.CameraAttributesPractical"/>.</para>
    /// </summary>
    public static void CameraAttributesSetAutoExposure(Rid cameraAttributes, bool enable, float minSensitivity, float maxSensitivity, float speed, float scale)
    {
        NativeCalls.godot_icall_6_1180(MethodBind350, GodotObject.GetPtr(Singleton), cameraAttributes, enable.ToGodotBool(), minSensitivity, maxSensitivity, speed, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind351 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScenarioCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a scenario and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>scenario_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>The scenario is the 3D world that all the visual instances exist in.</para>
    /// </summary>
    public static Rid ScenarioCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind351, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind352 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScenarioSetEnvironment, 395945892ul);

    /// <summary>
    /// <para>Sets the environment that will be used with this scenario. See also <see cref="Godot.Environment"/>.</para>
    /// </summary>
    public static void ScenarioSetEnvironment(Rid scenario, Rid environment)
    {
        NativeCalls.godot_icall_2_430(MethodBind352, GodotObject.GetPtr(Singleton), scenario, environment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind353 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScenarioSetFallbackEnvironment, 395945892ul);

    /// <summary>
    /// <para>Sets the fallback environment to be used by this scenario. The fallback environment is used if no environment is set. Internally, this is used by the editor to provide a default environment.</para>
    /// </summary>
    public static void ScenarioSetFallbackEnvironment(Rid scenario, Rid environment)
    {
        NativeCalls.godot_icall_2_430(MethodBind353, GodotObject.GetPtr(Singleton), scenario, environment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind354 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScenarioSetCameraAttributes, 395945892ul);

    /// <summary>
    /// <para>Sets the camera attributes (<paramref name="effects"/>) that will be used with this scenario. See also <see cref="Godot.CameraAttributes"/>.</para>
    /// </summary>
    public static void ScenarioSetCameraAttributes(Rid scenario, Rid effects)
    {
        NativeCalls.godot_icall_2_430(MethodBind354, GodotObject.GetPtr(Singleton), scenario, effects);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind355 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScenarioSetCompositor, 395945892ul);

    /// <summary>
    /// <para>Sets the compositor (<paramref name="compositor"/>) that will be used with this scenario. See also <see cref="Godot.Compositor"/>.</para>
    /// </summary>
    public static void ScenarioSetCompositor(Rid scenario, Rid compositor)
    {
        NativeCalls.godot_icall_2_430(MethodBind355, GodotObject.GetPtr(Singleton), scenario, compositor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind356 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceCreate2, 746547085ul);

    /// <summary>
    /// <para>Creates a visual instance, adds it to the RenderingServer, and sets both base and scenario. It can be accessed with the RID that is returned. This RID will be used in all <c>instance_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method. This is a shorthand for using <see cref="Godot.RenderingServer.InstanceCreate()"/> and setting the base and scenario manually.</para>
    /// </summary>
    public static Rid InstanceCreate2(Rid @base, Rid scenario)
    {
        return NativeCalls.godot_icall_2_1181(MethodBind356, GodotObject.GetPtr(Singleton), @base, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind357 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a visual instance and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>instance_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>An instance is a way of placing a 3D object in the scenario. Objects like particles, meshes, reflection probes and decals need to be associated with an instance to be visible in the scenario using <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/>.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.VisualInstance3D"/>.</para>
    /// </summary>
    public static Rid InstanceCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind357, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind358 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetBase, 395945892ul);

    /// <summary>
    /// <para>Sets the base of the instance. A base can be any of the 3D objects that are created in the RenderingServer that can be displayed. For example, any of the light types, mesh, multimesh, particle system, reflection probe, decal, lightmap, voxel GI and visibility notifiers are all types that can be set as the base of an instance in order to be displayed in the scenario.</para>
    /// </summary>
    public static void InstanceSetBase(Rid instance, Rid @base)
    {
        NativeCalls.godot_icall_2_430(MethodBind358, GodotObject.GetPtr(Singleton), instance, @base);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind359 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetScenario, 395945892ul);

    /// <summary>
    /// <para>Sets the scenario that the instance is in. The scenario is the 3D world that the objects will be displayed in.</para>
    /// </summary>
    public static void InstanceSetScenario(Rid instance, Rid scenario)
    {
        NativeCalls.godot_icall_2_430(MethodBind359, GodotObject.GetPtr(Singleton), instance, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind360 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetLayerMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the render layers that this instance will be drawn to. Equivalent to <see cref="Godot.VisualInstance3D.Layers"/>.</para>
    /// </summary>
    public static void InstanceSetLayerMask(Rid instance, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind360, GodotObject.GetPtr(Singleton), instance, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind361 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetPivotData, 1280615259ul);

    /// <summary>
    /// <para>Sets the sorting offset and switches between using the bounding box or instance origin for depth sorting.</para>
    /// </summary>
    public static void InstanceSetPivotData(Rid instance, float sortingOffset, bool useAabbCenter)
    {
        NativeCalls.godot_icall_3_1182(MethodBind361, GodotObject.GetPtr(Singleton), instance, sortingOffset, useAabbCenter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind362 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetTransform, 3935195649ul);

    /// <summary>
    /// <para>Sets the world space transform of the instance. Equivalent to <see cref="Godot.Node3D.GlobalTransform"/>.</para>
    /// </summary>
    public static unsafe void InstanceSetTransform(Rid instance, Transform3D transform)
    {
        NativeCalls.godot_icall_2_873(MethodBind362, GodotObject.GetPtr(Singleton), instance, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind363 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceAttachObjectInstanceId, 3411492887ul);

    /// <summary>
    /// <para>Attaches a unique Object ID to instance. Object ID must be attached to instance for proper culling with <see cref="Godot.RenderingServer.InstancesCullAabb(Aabb, Rid)"/>, <see cref="Godot.RenderingServer.InstancesCullConvex(Godot.Collections.Array{Plane}, Rid)"/>, and <see cref="Godot.RenderingServer.InstancesCullRay(Vector3, Vector3, Rid)"/>.</para>
    /// </summary>
    public static void InstanceAttachObjectInstanceId(Rid instance, ulong id)
    {
        NativeCalls.godot_icall_2_852(MethodBind363, GodotObject.GetPtr(Singleton), instance, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind364 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetBlendShapeWeight, 1892459533ul);

    /// <summary>
    /// <para>Sets the weight for a given blend shape associated with this instance.</para>
    /// </summary>
    public static void InstanceSetBlendShapeWeight(Rid instance, int shape, float weight)
    {
        NativeCalls.godot_icall_3_988(MethodBind364, GodotObject.GetPtr(Singleton), instance, shape, weight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind365 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetSurfaceOverrideMaterial, 2310537182ul);

    /// <summary>
    /// <para>Sets the override material of a specific surface. Equivalent to <see cref="Godot.MeshInstance3D.SetSurfaceOverrideMaterial(int, Material)"/>.</para>
    /// </summary>
    public static void InstanceSetSurfaceOverrideMaterial(Rid instance, int surface, Rid material)
    {
        NativeCalls.godot_icall_3_833(MethodBind365, GodotObject.GetPtr(Singleton), instance, surface, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind366 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetVisible, 1265174801ul);

    /// <summary>
    /// <para>Sets whether an instance is drawn or not. Equivalent to <see cref="Godot.Node3D.Visible"/>.</para>
    /// </summary>
    public static void InstanceSetVisible(Rid instance, bool visible)
    {
        NativeCalls.godot_icall_2_434(MethodBind366, GodotObject.GetPtr(Singleton), instance, visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind367 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetTransparency, 1794382983ul);

    /// <summary>
    /// <para>Sets the transparency for the given geometry instance. Equivalent to <see cref="Godot.GeometryInstance3D.Transparency"/>.</para>
    /// <para>A transparency of <c>0.0</c> is fully opaque, while <c>1.0</c> is fully transparent. Values greater than <c>0.0</c> (exclusive) will force the geometry's materials to go through the transparent pipeline, which is slower to render and can exhibit rendering issues due to incorrect transparency sorting. However, unlike using a transparent material, setting <paramref name="transparency"/> to a value greater than <c>0.0</c> (exclusive) will <i>not</i> disable shadow rendering.</para>
    /// <para>In spatial shaders, <c>1.0 - transparency</c> is set as the default value of the <c>ALPHA</c> built-in.</para>
    /// <para><b>Note:</b> <paramref name="transparency"/> is clamped between <c>0.0</c> and <c>1.0</c>, so this property cannot be used to make transparent materials more opaque than they originally are.</para>
    /// </summary>
    public static void InstanceGeometrySetTransparency(Rid instance, float transparency)
    {
        NativeCalls.godot_icall_2_816(MethodBind367, GodotObject.GetPtr(Singleton), instance, transparency);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind368 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceTeleport, 2722037293ul);

    /// <summary>
    /// <para>Resets motion vectors and other interpolated values. Use this <i>after</i> teleporting a mesh from one position to another to avoid ghosting artifacts.</para>
    /// </summary>
    public static void InstanceTeleport(Rid instance)
    {
        NativeCalls.godot_icall_1_286(MethodBind368, GodotObject.GetPtr(Singleton), instance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind369 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetCustomAabb, 3696536120ul);

    /// <summary>
    /// <para>Sets a custom AABB to use when culling objects from the view frustum. Equivalent to setting <see cref="Godot.GeometryInstance3D.CustomAabb"/>.</para>
    /// </summary>
    public static unsafe void InstanceSetCustomAabb(Rid instance, Aabb aabb)
    {
        NativeCalls.godot_icall_2_1135(MethodBind369, GodotObject.GetPtr(Singleton), instance, &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind370 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceAttachSkeleton, 395945892ul);

    /// <summary>
    /// <para>Attaches a skeleton to an instance. Removes the previous skeleton from the instance.</para>
    /// </summary>
    public static void InstanceAttachSkeleton(Rid instance, Rid skeleton)
    {
        NativeCalls.godot_icall_2_430(MethodBind370, GodotObject.GetPtr(Singleton), instance, skeleton);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind371 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetExtraVisibilityMargin, 1794382983ul);

    /// <summary>
    /// <para>Sets a margin to increase the size of the AABB when culling objects from the view frustum. This allows you to avoid culling objects that fall outside the view frustum. Equivalent to <see cref="Godot.GeometryInstance3D.ExtraCullMargin"/>.</para>
    /// </summary>
    public static void InstanceSetExtraVisibilityMargin(Rid instance, float margin)
    {
        NativeCalls.godot_icall_2_816(MethodBind371, GodotObject.GetPtr(Singleton), instance, margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind372 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetVisibilityParent, 395945892ul);

    /// <summary>
    /// <para>Sets the visibility parent for the given instance. Equivalent to <see cref="Godot.Node3D.VisibilityParent"/>.</para>
    /// </summary>
    public static void InstanceSetVisibilityParent(Rid instance, Rid parent)
    {
        NativeCalls.godot_icall_2_430(MethodBind372, GodotObject.GetPtr(Singleton), instance, parent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind373 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetIgnoreCulling, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, ignores both frustum and occlusion culling on the specified 3D geometry instance. This is not the same as <see cref="Godot.GeometryInstance3D.IgnoreOcclusionCulling"/>, which only ignores occlusion culling and leaves frustum culling intact.</para>
    /// </summary>
    public static void InstanceSetIgnoreCulling(Rid instance, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind373, GodotObject.GetPtr(Singleton), instance, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind374 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetFlag, 1014989537ul);

    /// <summary>
    /// <para>Sets the <paramref name="flag"/> for a given <paramref name="instance"/> to <paramref name="enabled"/>.</para>
    /// </summary>
    public static void InstanceGeometrySetFlag(Rid instance, RenderingServer.InstanceFlags flag, bool enabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind374, GodotObject.GetPtr(Singleton), instance, (int)flag, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind375 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetCastShadowsSetting, 3768836020ul);

    /// <summary>
    /// <para>Sets the shadow casting setting. Equivalent to <see cref="Godot.GeometryInstance3D.CastShadow"/>.</para>
    /// </summary>
    public static void InstanceGeometrySetCastShadowsSetting(Rid instance, RenderingServer.ShadowCastingSetting shadowCastingSetting)
    {
        NativeCalls.godot_icall_2_426(MethodBind375, GodotObject.GetPtr(Singleton), instance, (int)shadowCastingSetting);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind376 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetMaterialOverride, 395945892ul);

    /// <summary>
    /// <para>Sets a material that will override the material for all surfaces on the mesh associated with this instance. Equivalent to <see cref="Godot.GeometryInstance3D.MaterialOverride"/>.</para>
    /// </summary>
    public static void InstanceGeometrySetMaterialOverride(Rid instance, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind376, GodotObject.GetPtr(Singleton), instance, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind377 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetMaterialOverlay, 395945892ul);

    /// <summary>
    /// <para>Sets a material that will be rendered for all surfaces on top of active materials for the mesh associated with this instance. Equivalent to <see cref="Godot.GeometryInstance3D.MaterialOverlay"/>.</para>
    /// </summary>
    public static void InstanceGeometrySetMaterialOverlay(Rid instance, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind377, GodotObject.GetPtr(Singleton), instance, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind378 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetVisibilityRange, 4263925858ul);

    /// <summary>
    /// <para>Sets the visibility range values for the given geometry instance. Equivalent to <see cref="Godot.GeometryInstance3D.VisibilityRangeBegin"/> and related properties.</para>
    /// </summary>
    public static void InstanceGeometrySetVisibilityRange(Rid instance, float min, float max, float minMargin, float maxMargin, RenderingServer.VisibilityRangeFadeMode fadeMode)
    {
        NativeCalls.godot_icall_6_1183(MethodBind378, GodotObject.GetPtr(Singleton), instance, min, max, minMargin, maxMargin, (int)fadeMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind379 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetLightmap, 536974962ul);

    /// <summary>
    /// <para>Sets the lightmap GI instance to use for the specified 3D geometry instance. The lightmap UV scale for the specified instance (equivalent to <see cref="Godot.GeometryInstance3D.GILightmapScale"/>) and lightmap atlas slice must also be specified.</para>
    /// </summary>
    public static unsafe void InstanceGeometrySetLightmap(Rid instance, Rid lightmap, Rect2 lightmapUVScale, int lightmapSlice)
    {
        NativeCalls.godot_icall_4_1184(MethodBind379, GodotObject.GetPtr(Singleton), instance, lightmap, &lightmapUVScale, lightmapSlice);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind380 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetLodBias, 1794382983ul);

    /// <summary>
    /// <para>Sets the level of detail bias to use when rendering the specified 3D geometry instance. Higher values result in higher detail from further away. Equivalent to <see cref="Godot.GeometryInstance3D.LodBias"/>.</para>
    /// </summary>
    public static void InstanceGeometrySetLodBias(Rid instance, float lodBias)
    {
        NativeCalls.godot_icall_2_816(MethodBind380, GodotObject.GetPtr(Singleton), instance, lodBias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind381 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometrySetShaderParameter, 3477296213ul);

    /// <summary>
    /// <para>Sets the per-instance shader uniform on the specified 3D geometry instance. Equivalent to <see cref="Godot.GeometryInstance3D.SetInstanceShaderParameter(StringName, Variant)"/>.</para>
    /// </summary>
    public static void InstanceGeometrySetShaderParameter(Rid instance, StringName parameter, Variant value)
    {
        NativeCalls.godot_icall_3_1128(MethodBind381, GodotObject.GetPtr(Singleton), instance, (godot_string_name)(parameter?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind382 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometryGetShaderParameter, 2621281810ul);

    /// <summary>
    /// <para>Returns the value of the per-instance shader uniform from the specified 3D geometry instance. Equivalent to <see cref="Godot.GeometryInstance3D.GetInstanceShaderParameter(StringName)"/>.</para>
    /// <para><b>Note:</b> Per-instance shader parameter names are case-sensitive.</para>
    /// </summary>
    public static Variant InstanceGeometryGetShaderParameter(Rid instance, StringName parameter)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind382, GodotObject.GetPtr(Singleton), instance, (godot_string_name)(parameter?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind383 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometryGetShaderParameterDefaultValue, 2621281810ul);

    /// <summary>
    /// <para>Returns the default value of the per-instance shader uniform from the specified 3D geometry instance. Equivalent to <see cref="Godot.GeometryInstance3D.GetInstanceShaderParameter(StringName)"/>.</para>
    /// </summary>
    public static Variant InstanceGeometryGetShaderParameterDefaultValue(Rid instance, StringName parameter)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind383, GodotObject.GetPtr(Singleton), instance, (godot_string_name)(parameter?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind384 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceGeometryGetShaderParameterList, 2684255073ul);

    /// <summary>
    /// <para>Returns a dictionary of per-instance shader uniform names of the per-instance shader uniform from the specified 3D geometry instance. The returned dictionary is in PropertyInfo format, with the keys <c>name</c>, <c>class_name</c>, <c>type</c>, <c>hint</c>, <c>hint_string</c> and <c>usage</c>. Equivalent to <see cref="Godot.GeometryInstance3D.GetInstanceShaderParameter(StringName)"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Godot.Collections.Dictionary> InstanceGeometryGetShaderParameterList(Rid instance)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_849(MethodBind384, GodotObject.GetPtr(Singleton), instance));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind385 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstancesCullAabb, 2570105777ul);

    /// <summary>
    /// <para>Returns an array of object IDs intersecting with the provided AABB. Only 3D nodes that inherit from <see cref="Godot.VisualInstance3D"/> are considered, such as <see cref="Godot.MeshInstance3D"/> or <see cref="Godot.DirectionalLight3D"/>. Use <c>@GlobalScope.instance_from_id</c> to obtain the actual nodes. A scenario RID must be provided, which is available in the <see cref="Godot.World3D"/> you want to query. This forces an update for all resources queued to update.</para>
    /// <para><b>Warning:</b> This function is primarily intended for editor usage. For in-game use cases, prefer physics collision.</para>
    /// </summary>
    public static unsafe long[] InstancesCullAabb(Aabb aabb, Rid scenario = default)
    {
        return NativeCalls.godot_icall_2_1185(MethodBind385, GodotObject.GetPtr(Singleton), &aabb, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind386 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstancesCullRay, 2208759584ul);

    /// <summary>
    /// <para>Returns an array of object IDs intersecting with the provided 3D ray. Only 3D nodes that inherit from <see cref="Godot.VisualInstance3D"/> are considered, such as <see cref="Godot.MeshInstance3D"/> or <see cref="Godot.DirectionalLight3D"/>. Use <c>@GlobalScope.instance_from_id</c> to obtain the actual nodes. A scenario RID must be provided, which is available in the <see cref="Godot.World3D"/> you want to query. This forces an update for all resources queued to update.</para>
    /// <para><b>Warning:</b> This function is primarily intended for editor usage. For in-game use cases, prefer physics collision.</para>
    /// </summary>
    public static unsafe long[] InstancesCullRay(Vector3 from, Vector3 to, Rid scenario = default)
    {
        return NativeCalls.godot_icall_3_1186(MethodBind386, GodotObject.GetPtr(Singleton), &from, &to, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind387 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstancesCullConvex, 2488539944ul);

    /// <summary>
    /// <para>Returns an array of object IDs intersecting with the provided convex shape. Only 3D nodes that inherit from <see cref="Godot.VisualInstance3D"/> are considered, such as <see cref="Godot.MeshInstance3D"/> or <see cref="Godot.DirectionalLight3D"/>. Use <c>@GlobalScope.instance_from_id</c> to obtain the actual nodes. A scenario RID must be provided, which is available in the <see cref="Godot.World3D"/> you want to query. This forces an update for all resources queued to update.</para>
    /// <para><b>Warning:</b> This function is primarily intended for editor usage. For in-game use cases, prefer physics collision.</para>
    /// </summary>
    public static long[] InstancesCullConvex(Godot.Collections.Array<Plane> convex, Rid scenario = default)
    {
        return NativeCalls.godot_icall_2_1187(MethodBind387, GodotObject.GetPtr(Singleton), (godot_array)(convex ?? new()).NativeValue, scenario);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind388 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BakeRenderUV2, 1904608558ul);

    /// <summary>
    /// <para>Bakes the material data of the Mesh passed in the <paramref name="base"/> parameter with optional <paramref name="materialOverrides"/> to a set of <see cref="Godot.Image"/>s of size <paramref name="imageSize"/>. Returns an array of <see cref="Godot.Image"/>s containing material properties as specified in <see cref="Godot.RenderingServer.BakeChannels"/>.</para>
    /// </summary>
    public static unsafe Godot.Collections.Array<Image> BakeRenderUV2(Rid @base, Godot.Collections.Array<Rid> materialOverrides, Vector2I imageSize)
    {
        return new Godot.Collections.Array<Image>(NativeCalls.godot_icall_3_1188(MethodBind388, GodotObject.GetPtr(Singleton), @base, (godot_array)(materialOverrides ?? new()).NativeValue, &imageSize));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind389 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a canvas and returns the assigned <see cref="Godot.Rid"/>. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para>Canvas has no <see cref="Godot.Resource"/> or <see cref="Godot.Node"/> equivalent.</para>
    /// </summary>
    public static Rid CanvasCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind389, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind390 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasSetItemMirroring, 2343975398ul);

    /// <summary>
    /// <para>A copy of the canvas item will be drawn with a local offset of the <paramref name="mirroring"/>.</para>
    /// <para><b>Note:</b> This is equivalent to calling <see cref="Godot.RenderingServer.CanvasSetItemRepeat(Rid, Vector2, int)"/> like <c>canvas_set_item_repeat(item, mirroring, 1)</c>, with an additional check ensuring <paramref name="canvas"/> is a parent of <paramref name="item"/>.</para>
    /// </summary>
    public static unsafe void CanvasSetItemMirroring(Rid canvas, Rid item, Vector2 mirroring)
    {
        NativeCalls.godot_icall_3_1189(MethodBind390, GodotObject.GetPtr(Singleton), canvas, item, &mirroring);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind391 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasSetItemRepeat, 1739512717ul);

    /// <summary>
    /// <para>A copy of the canvas item will be drawn with a local offset of the <paramref name="repeatSize"/> by the number of times of the <paramref name="repeatTimes"/>. As the <paramref name="repeatTimes"/> increases, the copies will spread away from the origin texture.</para>
    /// </summary>
    public static unsafe void CanvasSetItemRepeat(Rid item, Vector2 repeatSize, int repeatTimes)
    {
        NativeCalls.godot_icall_3_1190(MethodBind391, GodotObject.GetPtr(Singleton), item, &repeatSize, repeatTimes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind392 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasSetModulate, 2948539648ul);

    /// <summary>
    /// <para>Modulates all colors in the given canvas.</para>
    /// </summary>
    public static unsafe void CanvasSetModulate(Rid canvas, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind392, GodotObject.GetPtr(Singleton), canvas, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind393 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasSetDisableScale, 2586408642ul);

    public static void CanvasSetDisableScale(bool disable)
    {
        NativeCalls.godot_icall_1_14(MethodBind393, GodotObject.GetPtr(Singleton), disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind394 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasTextureCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a canvas texture and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_texture_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method. See also <see cref="Godot.RenderingServer.Texture2DCreate(Image)"/>.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.CanvasTexture"/> and is only meant to be used in 2D rendering, not 3D.</para>
    /// </summary>
    public static Rid CanvasTextureCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind394, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind395 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasTextureSetChannel, 3822119138ul);

    /// <summary>
    /// <para>Sets the <paramref name="channel"/>'s <paramref name="texture"/> for the canvas texture specified by the <paramref name="canvasTexture"/> RID. Equivalent to <see cref="Godot.CanvasTexture.DiffuseTexture"/>, <see cref="Godot.CanvasTexture.NormalTexture"/> and <see cref="Godot.CanvasTexture.SpecularTexture"/>.</para>
    /// </summary>
    public static void CanvasTextureSetChannel(Rid canvasTexture, RenderingServer.CanvasTextureChannel channel, Rid texture)
    {
        NativeCalls.godot_icall_3_833(MethodBind395, GodotObject.GetPtr(Singleton), canvasTexture, (int)channel, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind396 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasTextureSetShadingParameters, 2124967469ul);

    /// <summary>
    /// <para>Sets the <paramref name="baseColor"/> and <paramref name="shininess"/> to use for the canvas texture specified by the <paramref name="canvasTexture"/> RID. Equivalent to <see cref="Godot.CanvasTexture.SpecularColor"/> and <see cref="Godot.CanvasTexture.SpecularShininess"/>.</para>
    /// </summary>
    public static unsafe void CanvasTextureSetShadingParameters(Rid canvasTexture, Color baseColor, float shininess)
    {
        NativeCalls.godot_icall_3_1191(MethodBind396, GodotObject.GetPtr(Singleton), canvasTexture, &baseColor, shininess);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind397 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasTextureSetTextureFilter, 1155129294ul);

    /// <summary>
    /// <para>Sets the texture <paramref name="filter"/> mode to use for the canvas texture specified by the <paramref name="canvasTexture"/> RID.</para>
    /// </summary>
    public static void CanvasTextureSetTextureFilter(Rid canvasTexture, RenderingServer.CanvasItemTextureFilter filter)
    {
        NativeCalls.godot_icall_2_426(MethodBind397, GodotObject.GetPtr(Singleton), canvasTexture, (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind398 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasTextureSetTextureRepeat, 1652956681ul);

    /// <summary>
    /// <para>Sets the texture <paramref name="repeat"/> mode to use for the canvas texture specified by the <paramref name="canvasTexture"/> RID.</para>
    /// </summary>
    public static void CanvasTextureSetTextureRepeat(Rid canvasTexture, RenderingServer.CanvasItemTextureRepeat repeat)
    {
        NativeCalls.godot_icall_2_426(MethodBind398, GodotObject.GetPtr(Singleton), canvasTexture, (int)repeat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind399 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new CanvasItem instance and returns its <see cref="Godot.Rid"/>. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_item_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public static Rid CanvasItemCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind399, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind400 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetParent, 395945892ul);

    /// <summary>
    /// <para>Sets a parent <see cref="Godot.CanvasItem"/> to the <see cref="Godot.CanvasItem"/>. The item will inherit transform, modulation and visibility from its parent, like <see cref="Godot.CanvasItem"/> nodes in the scene tree.</para>
    /// </summary>
    public static void CanvasItemSetParent(Rid item, Rid parent)
    {
        NativeCalls.godot_icall_2_430(MethodBind400, GodotObject.GetPtr(Singleton), item, parent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind401 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetDefaultTextureFilter, 1155129294ul);

    /// <summary>
    /// <para>Sets the default texture filter mode for the canvas item specified by the <paramref name="item"/> RID. Equivalent to <see cref="Godot.CanvasItem.TextureFilter"/>.</para>
    /// </summary>
    public static void CanvasItemSetDefaultTextureFilter(Rid item, RenderingServer.CanvasItemTextureFilter filter)
    {
        NativeCalls.godot_icall_2_426(MethodBind401, GodotObject.GetPtr(Singleton), item, (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind402 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetDefaultTextureRepeat, 1652956681ul);

    /// <summary>
    /// <para>Sets the default texture repeat mode for the canvas item specified by the <paramref name="item"/> RID. Equivalent to <see cref="Godot.CanvasItem.TextureRepeat"/>.</para>
    /// </summary>
    public static void CanvasItemSetDefaultTextureRepeat(Rid item, RenderingServer.CanvasItemTextureRepeat repeat)
    {
        NativeCalls.godot_icall_2_426(MethodBind402, GodotObject.GetPtr(Singleton), item, (int)repeat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind403 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetVisible, 1265174801ul);

    /// <summary>
    /// <para>Sets the visibility of the <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public static void CanvasItemSetVisible(Rid item, bool visible)
    {
        NativeCalls.godot_icall_2_434(MethodBind403, GodotObject.GetPtr(Singleton), item, visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind404 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetLightMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the light <paramref name="mask"/> for the canvas item specified by the <paramref name="item"/> RID. Equivalent to <see cref="Godot.CanvasItem.LightMask"/>.</para>
    /// </summary>
    public static void CanvasItemSetLightMask(Rid item, int mask)
    {
        NativeCalls.godot_icall_2_426(MethodBind404, GodotObject.GetPtr(Singleton), item, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind405 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetVisibilityLayer, 3411492887ul);

    /// <summary>
    /// <para>Sets the rendering visibility layer associated with this <see cref="Godot.CanvasItem"/>. Only <see cref="Godot.Viewport"/> nodes with a matching rendering mask will render this <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public static void CanvasItemSetVisibilityLayer(Rid item, uint visibilityLayer)
    {
        NativeCalls.godot_icall_2_856(MethodBind405, GodotObject.GetPtr(Singleton), item, visibilityLayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind406 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets the <paramref name="transform"/> of the canvas item specified by the <paramref name="item"/> RID. This affects where and how the item will be drawn. Child canvas items' transforms are multiplied by their parent's transform. Equivalent to <see cref="Godot.Node2D.Transform"/>.</para>
    /// </summary>
    public static unsafe void CanvasItemSetTransform(Rid item, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind406, GodotObject.GetPtr(Singleton), item, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind407 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetClip, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="clip"/> is <see langword="true"/>, makes the canvas item specified by the <paramref name="item"/> RID not draw anything outside of its rect's coordinates. This clipping is fast, but works only with axis-aligned rectangles. This means that rotation is ignored by the clipping rectangle. For more advanced clipping shapes, use <see cref="Godot.RenderingServer.CanvasItemSetCanvasGroupMode(Rid, RenderingServer.CanvasGroupMode, float, bool, float, bool)"/> instead.</para>
    /// <para><b>Note:</b> The equivalent node functionality is found in <see cref="Godot.Label.ClipText"/>, <see cref="Godot.RichTextLabel"/> (always enabled) and more.</para>
    /// </summary>
    public static void CanvasItemSetClip(Rid item, bool clip)
    {
        NativeCalls.godot_icall_2_434(MethodBind407, GodotObject.GetPtr(Singleton), item, clip.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind408 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetDistanceFieldMode, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, enables multichannel signed distance field rendering mode for the canvas item specified by the <paramref name="item"/> RID. This is meant to be used for font rendering, or with specially generated images using <a href="https://github.com/Chlumsky/msdfgen">msdfgen</a>.</para>
    /// </summary>
    public static void CanvasItemSetDistanceFieldMode(Rid item, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind408, GodotObject.GetPtr(Singleton), item, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind409 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetCustomRect, 1333997032ul);

    /// <summary>
    /// <para>If <paramref name="useCustomRect"/> is <see langword="true"/>, sets the custom visibility rectangle (used for culling) to <paramref name="rect"/> for the canvas item specified by <paramref name="item"/>. Setting a custom visibility rect can reduce CPU load when drawing lots of 2D instances. If <paramref name="useCustomRect"/> is <see langword="false"/>, automatically computes a visibility rectangle based on the canvas item's draw commands.</para>
    /// </summary>
    /// <param name="rect">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    public static unsafe void CanvasItemSetCustomRect(Rid item, bool useCustomRect, Nullable<Rect2> rect = null)
    {
        Rect2 rectOrDefVal = rect.HasValue ? rect.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_3_1192(MethodBind409, GodotObject.GetPtr(Singleton), item, useCustomRect.ToGodotBool(), &rectOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind410 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetModulate, 2948539648ul);

    /// <summary>
    /// <para>Multiplies the color of the canvas item specified by the <paramref name="item"/> RID, while affecting its children. See also <see cref="Godot.RenderingServer.CanvasItemSetSelfModulate(Rid, Color)"/>. Equivalent to <see cref="Godot.CanvasItem.Modulate"/>.</para>
    /// </summary>
    public static unsafe void CanvasItemSetModulate(Rid item, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind410, GodotObject.GetPtr(Singleton), item, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind411 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetSelfModulate, 2948539648ul);

    /// <summary>
    /// <para>Multiplies the color of the canvas item specified by the <paramref name="item"/> RID, without affecting its children. See also <see cref="Godot.RenderingServer.CanvasItemSetModulate(Rid, Color)"/>. Equivalent to <see cref="Godot.CanvasItem.SelfModulate"/>.</para>
    /// </summary>
    public static unsafe void CanvasItemSetSelfModulate(Rid item, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind411, GodotObject.GetPtr(Singleton), item, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind412 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetDrawBehindParent, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, draws the canvas item specified by the <paramref name="item"/> RID behind its parent. Equivalent to <see cref="Godot.CanvasItem.ShowBehindParent"/>.</para>
    /// </summary>
    public static void CanvasItemSetDrawBehindParent(Rid item, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind412, GodotObject.GetPtr(Singleton), item, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind413 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetInterpolated, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="interpolated"/> is <see langword="true"/>, turns on physics interpolation for the canvas item.</para>
    /// </summary>
    public static void CanvasItemSetInterpolated(Rid item, bool interpolated)
    {
        NativeCalls.godot_icall_2_434(MethodBind413, GodotObject.GetPtr(Singleton), item, interpolated.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind414 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemResetPhysicsInterpolation, 2722037293ul);

    /// <summary>
    /// <para>Prevents physics interpolation for the current physics tick.</para>
    /// <para>This is useful when moving a canvas item to a new location, to give an instantaneous change rather than interpolation from the previous location.</para>
    /// </summary>
    public static void CanvasItemResetPhysicsInterpolation(Rid item)
    {
        NativeCalls.godot_icall_1_286(MethodBind414, GodotObject.GetPtr(Singleton), item);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind415 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemTransformPhysicsInterpolation, 1246044741ul);

    /// <summary>
    /// <para>Transforms both the current and previous stored transform for a canvas item.</para>
    /// <para>This allows transforming a canvas item without creating a "glitch" in the interpolation, which is particularly useful for large worlds utilizing a shifting origin.</para>
    /// </summary>
    public static unsafe void CanvasItemTransformPhysicsInterpolation(Rid item, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind415, GodotObject.GetPtr(Singleton), item, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind416 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddLine, 1819681853ul);

    /// <summary>
    /// <para>Draws a line on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/>.</para>
    /// </summary>
    public static unsafe void CanvasItemAddLine(Rid item, Vector2 from, Vector2 to, Color color, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_6_1193(MethodBind416, GodotObject.GetPtr(Singleton), item, &from, &to, &color, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind417 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddPolyline, 3098767073ul);

    /// <summary>
    /// <para>Draws a 2D polyline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawPolylineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    public static void CanvasItemAddPolyline(Rid item, Vector2[] points, Color[] colors, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_5_1194(MethodBind417, GodotObject.GetPtr(Singleton), item, points, colors, width, antialiased.ToGodotBool());
    }

    /// <summary>
    /// <para>Draws a 2D polyline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawPolylineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    public static void CanvasItemAddPolyline(Rid item, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, float width, bool antialiased)
    {
        NativeCalls.godot_icall_5_1194(MethodBind417, GodotObject.GetPtr(Singleton), item, points, colors, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind418 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddMultiline, 3098767073ul);

    /// <summary>
    /// <para>Draws a 2D multiline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawMultilineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    public static void CanvasItemAddMultiline(Rid item, Vector2[] points, Color[] colors, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_5_1194(MethodBind418, GodotObject.GetPtr(Singleton), item, points, colors, width, antialiased.ToGodotBool());
    }

    /// <summary>
    /// <para>Draws a 2D multiline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawMultilineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    public static void CanvasItemAddMultiline(Rid item, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, float width, bool antialiased)
    {
        NativeCalls.godot_icall_5_1194(MethodBind418, GodotObject.GetPtr(Singleton), item, points, colors, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind419 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddRect, 3523446176ul);

    /// <summary>
    /// <para>Draws a rectangle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawRect(Rect2, Color, bool, float, bool)"/>.</para>
    /// </summary>
    public static unsafe void CanvasItemAddRect(Rid item, Rect2 rect, Color color, bool antialiased = false)
    {
        NativeCalls.godot_icall_4_1195(MethodBind419, GodotObject.GetPtr(Singleton), item, &rect, &color, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind420 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddCircle, 333077949ul);

    /// <summary>
    /// <para>Draws a circle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawCircle(Vector2, float, Color, bool, float, bool)"/>.</para>
    /// </summary>
    public static unsafe void CanvasItemAddCircle(Rid item, Vector2 pos, float radius, Color color, bool antialiased = false)
    {
        NativeCalls.godot_icall_5_1196(MethodBind420, GodotObject.GetPtr(Singleton), item, &pos, radius, &color, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind421 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddEllipse, 4188642757ul);

    /// <summary>
    /// <para>Draws an ellipse with semi-major axis <paramref name="major"/> and semi-minor axis <paramref name="minor"/> on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawEllipse(Vector2, float, float, Color, bool, float, bool)"/>.</para>
    /// </summary>
    public static unsafe void CanvasItemAddEllipse(Rid item, Vector2 pos, float major, float minor, Color color, bool antialiased = false)
    {
        NativeCalls.godot_icall_6_1197(MethodBind421, GodotObject.GetPtr(Singleton), item, &pos, major, minor, &color, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind422 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddTextureRect, 324864032ul);

    /// <summary>
    /// <para>Draws a 2D textured rectangle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawTextureRect(Texture2D, Rect2, bool, Nullable{Color}, bool)"/> and <see cref="Godot.Texture2D.DrawRect(Rid, Rect2, bool, Nullable{Color}, bool)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public static unsafe void CanvasItemAddTextureRect(Rid item, Rect2 rect, Rid texture, bool tile = false, Nullable<Color> modulate = null, bool transpose = false)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_6_1198(MethodBind422, GodotObject.GetPtr(Singleton), item, &rect, texture, tile.ToGodotBool(), &modulateOrDefVal, transpose.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind423 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddMsdfTextureRectRegion, 97408773ul);

    /// <summary>
    /// <para>See also <see cref="Godot.CanvasItem.DrawMsdfTextureRectRegion(Texture2D, Rect2, Rect2, Nullable{Color}, double, double, double)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public static unsafe void CanvasItemAddMsdfTextureRectRegion(Rid item, Rect2 rect, Rid texture, Rect2 srcRect, Nullable<Color> modulate = null, int outlineSize = 0, float pxRange = 1.0f, float scale = 1.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_8_1199(MethodBind423, GodotObject.GetPtr(Singleton), item, &rect, texture, &srcRect, &modulateOrDefVal, outlineSize, pxRange, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind424 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddLcdTextureRectRegion, 359793297ul);

    /// <summary>
    /// <para>See also <see cref="Godot.CanvasItem.DrawLcdTextureRectRegion(Texture2D, Rect2, Rect2, Nullable{Color})"/>.</para>
    /// </summary>
    public static unsafe void CanvasItemAddLcdTextureRectRegion(Rid item, Rect2 rect, Rid texture, Rect2 srcRect, Color modulate)
    {
        NativeCalls.godot_icall_5_1200(MethodBind424, GodotObject.GetPtr(Singleton), item, &rect, texture, &srcRect, &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind425 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddTextureRectRegion, 485157892ul);

    /// <summary>
    /// <para>Draws the specified region of a 2D textured rectangle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawTextureRectRegion(Texture2D, Rect2, Rect2, Nullable{Color}, bool, bool)"/> and <see cref="Godot.Texture2D.DrawRectRegion(Rid, Rect2, Rect2, Nullable{Color}, bool, bool)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public static unsafe void CanvasItemAddTextureRectRegion(Rid item, Rect2 rect, Rid texture, Rect2 srcRect, Nullable<Color> modulate = null, bool transpose = false, bool clipUV = true)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_7_1201(MethodBind425, GodotObject.GetPtr(Singleton), item, &rect, texture, &srcRect, &modulateOrDefVal, transpose.ToGodotBool(), clipUV.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind426 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddNinePatch, 389957886ul);

    /// <summary>
    /// <para>Draws a nine-patch rectangle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public static unsafe void CanvasItemAddNinePatch(Rid item, Rect2 rect, Rect2 source, Rid texture, Vector2 topleft, Vector2 bottomright, RenderingServer.NinePatchAxisMode xAxisMode = (RenderingServer.NinePatchAxisMode)(0), RenderingServer.NinePatchAxisMode yAxisMode = (RenderingServer.NinePatchAxisMode)(0), bool drawCenter = true, Nullable<Color> modulate = null)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_10_1202(MethodBind426, GodotObject.GetPtr(Singleton), item, &rect, &source, texture, &topleft, &bottomright, (int)xAxisMode, (int)yAxisMode, drawCenter.ToGodotBool(), &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind427 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddPrimitive, 3731601077ul);

    /// <summary>
    /// <para>Draws a 2D primitive on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawPrimitive(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// </summary>
    public static void CanvasItemAddPrimitive(Rid item, Vector2[] points, Color[] colors, Vector2[] uvs, Rid texture)
    {
        NativeCalls.godot_icall_5_1203(MethodBind427, GodotObject.GetPtr(Singleton), item, points, colors, uvs, texture);
    }

    /// <summary>
    /// <para>Draws a 2D primitive on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawPrimitive(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// </summary>
    public static void CanvasItemAddPrimitive(Rid item, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, ReadOnlySpan<Vector2> uvs, Rid texture)
    {
        NativeCalls.godot_icall_5_1203(MethodBind427, GodotObject.GetPtr(Singleton), item, points, colors, uvs, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind428 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddPolygon, 3580000528ul);

    /// <summary>
    /// <para>Draws a 2D polygon on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. If you need more flexibility (such as being able to use bones), use <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/> instead. See also <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para><b>Note:</b> If you frequently redraw the same polygon with a large number of vertices, consider pre-calculating the triangulation with <see cref="Godot.Geometry2D.TriangulatePolygon(Vector2[])"/> and using <see cref="Godot.CanvasItem.DrawMesh(Mesh, Texture2D, Nullable{Transform2D}, Nullable{Color})"/>, <see cref="Godot.CanvasItem.DrawMultimesh(MultiMesh, Texture2D)"/>, or <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/>.</para>
    /// </summary>
    /// <param name="uvs">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector2&gt;()</c>.</param>
    public static void CanvasItemAddPolygon(Rid item, Vector2[] points, Color[] colors, Vector2[] uvs = null, Rid texture = default)
    {
        Vector2[] uvsOrDefVal = uvs != null ? uvs : Array.Empty<Vector2>();
        NativeCalls.godot_icall_5_1203(MethodBind428, GodotObject.GetPtr(Singleton), item, points, colors, uvsOrDefVal, texture);
    }

    /// <summary>
    /// <para>Draws a 2D polygon on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. If you need more flexibility (such as being able to use bones), use <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/> instead. See also <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para><b>Note:</b> If you frequently redraw the same polygon with a large number of vertices, consider pre-calculating the triangulation with <see cref="Godot.Geometry2D.TriangulatePolygon(Vector2[])"/> and using <see cref="Godot.CanvasItem.DrawMesh(Mesh, Texture2D, Nullable{Transform2D}, Nullable{Color})"/>, <see cref="Godot.CanvasItem.DrawMultimesh(MultiMesh, Texture2D)"/>, or <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/>.</para>
    /// </summary>
    public static void CanvasItemAddPolygon(Rid item, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, ReadOnlySpan<Vector2> uvs, Rid texture)
    {
        NativeCalls.godot_icall_5_1203(MethodBind428, GodotObject.GetPtr(Singleton), item, points, colors, uvs, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind429 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddTriangleArray, 660261329ul);

    /// <summary>
    /// <para>Draws a triangle array on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. This is internally used by <see cref="Godot.Line2D"/> and <see cref="Godot.StyleBoxFlat"/> for rendering. <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/> is highly flexible, but more complex to use than <see cref="Godot.RenderingServer.CanvasItemAddPolygon(Rid, Vector2[], Color[], Vector2[], Rid)"/>.</para>
    /// <para><b>Note:</b> If <paramref name="count"/> is set to a non-negative value, only the first <c>count * 3</c> indices (corresponding to <c>count</c> triangles) will be drawn. Otherwise, all indices are drawn.</para>
    /// </summary>
    /// <param name="uvs">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector2&gt;()</c>.</param>
    /// <param name="bones">If the parameter is null, then the default value is <c>Array.Empty&lt;int&gt;()</c>.</param>
    /// <param name="weights">If the parameter is null, then the default value is <c>Array.Empty&lt;float&gt;()</c>.</param>
    public static void CanvasItemAddTriangleArray(Rid item, int[] indices, Vector2[] points, Color[] colors, Vector2[] uvs = null, int[] bones = null, float[] weights = null, Rid texture = default, int count = -1)
    {
        Vector2[] uvsOrDefVal = uvs != null ? uvs : Array.Empty<Vector2>();
        int[] bonesOrDefVal = bones != null ? bones : Array.Empty<int>();
        float[] weightsOrDefVal = weights != null ? weights : Array.Empty<float>();
        NativeCalls.godot_icall_9_1204(MethodBind429, GodotObject.GetPtr(Singleton), item, indices, points, colors, uvsOrDefVal, bonesOrDefVal, weightsOrDefVal, texture, count);
    }

    /// <summary>
    /// <para>Draws a triangle array on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. This is internally used by <see cref="Godot.Line2D"/> and <see cref="Godot.StyleBoxFlat"/> for rendering. <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/> is highly flexible, but more complex to use than <see cref="Godot.RenderingServer.CanvasItemAddPolygon(Rid, Vector2[], Color[], Vector2[], Rid)"/>.</para>
    /// <para><b>Note:</b> If <paramref name="count"/> is set to a non-negative value, only the first <c>count * 3</c> indices (corresponding to <c>count</c> triangles) will be drawn. Otherwise, all indices are drawn.</para>
    /// </summary>
    public static void CanvasItemAddTriangleArray(Rid item, ReadOnlySpan<int> indices, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, ReadOnlySpan<Vector2> uvs, ReadOnlySpan<int> bones, ReadOnlySpan<float> weights, Rid texture, int count)
    {
        NativeCalls.godot_icall_9_1204(MethodBind429, GodotObject.GetPtr(Singleton), item, indices, points, colors, uvs, bones, weights, texture, count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind430 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddMesh, 316450961ul);

    /// <summary>
    /// <para>Draws a mesh created with <see cref="Godot.RenderingServer.MeshCreate()"/> with given <paramref name="transform"/>, <paramref name="modulate"/> color, and <paramref name="texture"/>. This is used internally by <see cref="Godot.MeshInstance2D"/>.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform2D.Identity</c>.</param>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public static unsafe void CanvasItemAddMesh(Rid item, Rid mesh, Nullable<Transform2D> transform = null, Nullable<Color> modulate = null, Rid texture = default)
    {
        Transform2D transformOrDefVal = transform.HasValue ? transform.Value : Transform2D.Identity;
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_5_1205(MethodBind430, GodotObject.GetPtr(Singleton), item, mesh, &transformOrDefVal, &modulateOrDefVal, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind431 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddMultimesh, 2131855138ul);

    /// <summary>
    /// <para>Draws a 2D <see cref="Godot.MultiMesh"/> on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawMultimesh(MultiMesh, Texture2D)"/>.</para>
    /// </summary>
    public static void CanvasItemAddMultimesh(Rid item, Rid mesh, Rid texture = default)
    {
        NativeCalls.godot_icall_3_1206(MethodBind431, GodotObject.GetPtr(Singleton), item, mesh, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind432 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddParticles, 2575754278ul);

    /// <summary>
    /// <para>Draws particles on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public static void CanvasItemAddParticles(Rid item, Rid particles, Rid texture)
    {
        NativeCalls.godot_icall_3_1206(MethodBind432, GodotObject.GetPtr(Singleton), item, particles, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind433 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets a <see cref="Godot.Transform2D"/> that will be used to transform subsequent canvas item commands.</para>
    /// </summary>
    public static unsafe void CanvasItemAddSetTransform(Rid item, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind433, GodotObject.GetPtr(Singleton), item, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind434 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddClipIgnore, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="ignore"/> is <see langword="true"/>, ignore clipping on items drawn with this canvas item until this is called again with <paramref name="ignore"/> set to <see langword="false"/>.</para>
    /// </summary>
    public static void CanvasItemAddClipIgnore(Rid item, bool ignore)
    {
        NativeCalls.godot_icall_2_434(MethodBind434, GodotObject.GetPtr(Singleton), item, ignore.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind435 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddAnimationSlice, 2646834499ul);

    /// <summary>
    /// <para>Subsequent drawing commands will be ignored unless they fall within the specified animation slice. This is a faster way to implement animations that loop on background rather than redrawing constantly.</para>
    /// </summary>
    public static void CanvasItemAddAnimationSlice(Rid item, double animationLength, double sliceBegin, double sliceEnd, double offset = 0.0)
    {
        NativeCalls.godot_icall_5_1207(MethodBind435, GodotObject.GetPtr(Singleton), item, animationLength, sliceBegin, sliceEnd, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind436 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetSortChildrenByY, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, child nodes with the lowest Y position are drawn before those with a higher Y position. Y-sorting only affects children that inherit from the canvas item specified by the <paramref name="item"/> RID, not the canvas item itself. Equivalent to <see cref="Godot.CanvasItem.YSortEnabled"/>.</para>
    /// </summary>
    public static void CanvasItemSetSortChildrenByY(Rid item, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind436, GodotObject.GetPtr(Singleton), item, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind437 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetZIndex, 3411492887ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.CanvasItem"/>'s Z index, i.e. its draw order (lower indexes are drawn first).</para>
    /// </summary>
    public static void CanvasItemSetZIndex(Rid item, int zIndex)
    {
        NativeCalls.godot_icall_2_426(MethodBind437, GodotObject.GetPtr(Singleton), item, zIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind438 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetZAsRelativeToParent, 1265174801ul);

    /// <summary>
    /// <para>If this is enabled, the Z index of the parent will be added to the children's Z index.</para>
    /// </summary>
    public static void CanvasItemSetZAsRelativeToParent(Rid item, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind438, GodotObject.GetPtr(Singleton), item, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind439 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetCopyToBackbuffer, 2429202503ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.CanvasItem"/> to copy a rect to the backbuffer.</para>
    /// </summary>
    public static unsafe void CanvasItemSetCopyToBackbuffer(Rid item, bool enabled, Rect2 rect)
    {
        NativeCalls.godot_icall_3_1192(MethodBind439, GodotObject.GetPtr(Singleton), item, enabled.ToGodotBool(), &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind440 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAttachSkeleton, 395945892ul);

    /// <summary>
    /// <para>Attaches a skeleton to the <see cref="Godot.CanvasItem"/>. Removes the previous skeleton.</para>
    /// </summary>
    public static void CanvasItemAttachSkeleton(Rid item, Rid skeleton)
    {
        NativeCalls.godot_icall_2_430(MethodBind440, GodotObject.GetPtr(Singleton), item, skeleton);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind441 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemClear, 2722037293ul);

    /// <summary>
    /// <para>Clears the <see cref="Godot.CanvasItem"/> and removes all commands in it.</para>
    /// </summary>
    public static void CanvasItemClear(Rid item)
    {
        NativeCalls.godot_icall_1_286(MethodBind441, GodotObject.GetPtr(Singleton), item);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind442 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetDrawIndex, 3411492887ul);

    /// <summary>
    /// <para>Sets the index for the <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public static void CanvasItemSetDrawIndex(Rid item, int index)
    {
        NativeCalls.godot_icall_2_426(MethodBind442, GodotObject.GetPtr(Singleton), item, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind443 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetMaterial, 395945892ul);

    /// <summary>
    /// <para>Sets a new <paramref name="material"/> to the canvas item specified by the <paramref name="item"/> RID. Equivalent to <see cref="Godot.CanvasItem.Material"/>.</para>
    /// </summary>
    public static void CanvasItemSetMaterial(Rid item, Rid material)
    {
        NativeCalls.godot_icall_2_430(MethodBind443, GodotObject.GetPtr(Singleton), item, material);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind444 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetUseParentMaterial, 1265174801ul);

    /// <summary>
    /// <para>Sets if the <see cref="Godot.CanvasItem"/> uses its parent's material.</para>
    /// </summary>
    public static void CanvasItemSetUseParentMaterial(Rid item, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind444, GodotObject.GetPtr(Singleton), item, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind445 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetInstanceShaderParameter, 3477296213ul);

    /// <summary>
    /// <para>Sets the per-instance shader uniform on the specified canvas item instance. Equivalent to <see cref="Godot.CanvasItem.SetInstanceShaderParameter(StringName, Variant)"/>.</para>
    /// </summary>
    public static void CanvasItemSetInstanceShaderParameter(Rid instance, StringName parameter, Variant value)
    {
        NativeCalls.godot_icall_3_1128(MethodBind445, GodotObject.GetPtr(Singleton), instance, (godot_string_name)(parameter?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind446 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemGetInstanceShaderParameter, 2621281810ul);

    /// <summary>
    /// <para>Returns the value of the per-instance shader uniform from the specified canvas item instance. Equivalent to <see cref="Godot.CanvasItem.GetInstanceShaderParameter(StringName)"/>.</para>
    /// </summary>
    public static Variant CanvasItemGetInstanceShaderParameter(Rid instance, StringName parameter)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind446, GodotObject.GetPtr(Singleton), instance, (godot_string_name)(parameter?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind447 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemGetInstanceShaderParameterDefaultValue, 2621281810ul);

    /// <summary>
    /// <para>Returns the default value of the per-instance shader uniform from the specified canvas item instance. Equivalent to <see cref="Godot.CanvasItem.GetInstanceShaderParameter(StringName)"/>.</para>
    /// </summary>
    public static Variant CanvasItemGetInstanceShaderParameterDefaultValue(Rid instance, StringName parameter)
    {
        return NativeCalls.godot_icall_2_1125(MethodBind447, GodotObject.GetPtr(Singleton), instance, (godot_string_name)(parameter?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind448 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemGetInstanceShaderParameterList, 2684255073ul);

    /// <summary>
    /// <para>Returns a dictionary of per-instance shader uniform names of the per-instance shader uniform from the specified canvas item instance.</para>
    /// <para>The returned dictionary is in PropertyInfo format, with the keys <c>name</c>, <c>class_name</c>, <c>type</c>, <c>hint</c>, <c>hint_string</c>, and <c>usage</c>.</para>
    /// </summary>
    public static Godot.Collections.Array<Godot.Collections.Dictionary> CanvasItemGetInstanceShaderParameterList(Rid instance)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_849(MethodBind448, GodotObject.GetPtr(Singleton), instance));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind449 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetVisibilityNotifier, 3568945579ul);

    /// <summary>
    /// <para>Sets the given <see cref="Godot.CanvasItem"/> as visibility notifier. <paramref name="area"/> defines the area of detecting visibility. <paramref name="enterCallable"/> is called when the <see cref="Godot.CanvasItem"/> enters the screen, <paramref name="exitCallable"/> is called when the <see cref="Godot.CanvasItem"/> exits the screen. If <paramref name="enable"/> is <see langword="false"/>, the item will no longer function as notifier.</para>
    /// <para>This method can be used to manually mimic <see cref="Godot.VisibleOnScreenNotifier2D"/>.</para>
    /// </summary>
    public static unsafe void CanvasItemSetVisibilityNotifier(Rid item, bool enable, Rect2 area, Callable enterCallable, Callable exitCallable)
    {
        NativeCalls.godot_icall_5_1208(MethodBind449, GodotObject.GetPtr(Singleton), item, enable.ToGodotBool(), &area, enterCallable, exitCallable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind450 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemSetCanvasGroupMode, 3973586316ul);

    /// <summary>
    /// <para>Sets the canvas group mode used during 2D rendering for the canvas item specified by the <paramref name="item"/> RID. For faster but more limited clipping, use <see cref="Godot.RenderingServer.CanvasItemSetClip(Rid, bool)"/> instead.</para>
    /// <para><b>Note:</b> The equivalent node functionality is found in <see cref="Godot.CanvasGroup"/> and <see cref="Godot.CanvasItem.ClipChildren"/>.</para>
    /// </summary>
    public static void CanvasItemSetCanvasGroupMode(Rid item, RenderingServer.CanvasGroupMode mode, float clearMargin = 5.0f, bool fitEmpty = false, float fitMargin = 0.0f, bool blurMipmaps = false)
    {
        NativeCalls.godot_icall_6_1209(MethodBind450, GodotObject.GetPtr(Singleton), item, (int)mode, clearMargin, fitEmpty.ToGodotBool(), fitMargin, blurMipmaps.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind451 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DebugCanvasItemGetRect, 624227424ul);

    /// <summary>
    /// <para>Returns the bounding rectangle for a canvas item in local space, as calculated by the renderer. This bound is used internally for culling.</para>
    /// <para><b>Warning:</b> This function is intended for debugging in the editor, and will pass through and return a zero <see cref="Godot.Rect2"/> in exported projects.</para>
    /// </summary>
    public static Rect2 DebugCanvasItemGetRect(Rid item)
    {
        return NativeCalls.godot_icall_1_860(MethodBind451, GodotObject.GetPtr(Singleton), item);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind452 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a canvas light and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_light_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.Light2D"/>.</para>
    /// </summary>
    public static Rid CanvasLightCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind452, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind453 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightAttachToCanvas, 395945892ul);

    /// <summary>
    /// <para>Attaches the canvas light to the canvas. Removes it from its previous canvas.</para>
    /// </summary>
    public static void CanvasLightAttachToCanvas(Rid light, Rid canvas)
    {
        NativeCalls.godot_icall_2_430(MethodBind453, GodotObject.GetPtr(Singleton), light, canvas);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind454 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetEnabled, 1265174801ul);

    /// <summary>
    /// <para>Enables or disables a canvas light.</para>
    /// </summary>
    public static void CanvasLightSetEnabled(Rid light, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind454, GodotObject.GetPtr(Singleton), light, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind455 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetTextureScale, 1794382983ul);

    /// <summary>
    /// <para>Sets the scale factor of a <see cref="Godot.PointLight2D"/>'s texture. Equivalent to <see cref="Godot.PointLight2D.TextureScale"/>.</para>
    /// </summary>
    public static void CanvasLightSetTextureScale(Rid light, float scale)
    {
        NativeCalls.godot_icall_2_816(MethodBind455, GodotObject.GetPtr(Singleton), light, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind456 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets the canvas light's <see cref="Godot.Transform2D"/>.</para>
    /// </summary>
    public static unsafe void CanvasLightSetTransform(Rid light, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind456, GodotObject.GetPtr(Singleton), light, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind457 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetTexture, 395945892ul);

    /// <summary>
    /// <para>Sets the texture to be used by a <see cref="Godot.PointLight2D"/>. Equivalent to <see cref="Godot.PointLight2D.Texture"/>.</para>
    /// </summary>
    public static void CanvasLightSetTexture(Rid light, Rid texture)
    {
        NativeCalls.godot_icall_2_430(MethodBind457, GodotObject.GetPtr(Singleton), light, texture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind458 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetTextureOffset, 3201125042ul);

    /// <summary>
    /// <para>Sets the offset of a <see cref="Godot.PointLight2D"/>'s texture. Equivalent to <see cref="Godot.PointLight2D.Offset"/>.</para>
    /// </summary>
    public static unsafe void CanvasLightSetTextureOffset(Rid light, Vector2 offset)
    {
        NativeCalls.godot_icall_2_861(MethodBind458, GodotObject.GetPtr(Singleton), light, &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind459 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetColor, 2948539648ul);

    /// <summary>
    /// <para>Sets the color for a light.</para>
    /// </summary>
    public static unsafe void CanvasLightSetColor(Rid light, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind459, GodotObject.GetPtr(Singleton), light, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind460 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetHeight, 1794382983ul);

    /// <summary>
    /// <para>Sets a canvas light's height.</para>
    /// </summary>
    public static void CanvasLightSetHeight(Rid light, float height)
    {
        NativeCalls.godot_icall_2_816(MethodBind460, GodotObject.GetPtr(Singleton), light, height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind461 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetEnergy, 1794382983ul);

    /// <summary>
    /// <para>Sets a canvas light's energy.</para>
    /// </summary>
    public static void CanvasLightSetEnergy(Rid light, float energy)
    {
        NativeCalls.godot_icall_2_816(MethodBind461, GodotObject.GetPtr(Singleton), light, energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind462 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetZRange, 4288446313ul);

    /// <summary>
    /// <para>Sets the Z range of objects that will be affected by this light. Equivalent to <see cref="Godot.Light2D.RangeZMin"/> and <see cref="Godot.Light2D.RangeZMax"/>.</para>
    /// </summary>
    public static void CanvasLightSetZRange(Rid light, int minZ, int maxZ)
    {
        NativeCalls.godot_icall_3_433(MethodBind462, GodotObject.GetPtr(Singleton), light, minZ, maxZ);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind463 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetLayerRange, 4288446313ul);

    /// <summary>
    /// <para>The layer range that gets rendered with this light.</para>
    /// </summary>
    public static void CanvasLightSetLayerRange(Rid light, int minLayer, int maxLayer)
    {
        NativeCalls.godot_icall_3_433(MethodBind463, GodotObject.GetPtr(Singleton), light, minLayer, maxLayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind464 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetItemCullMask, 3411492887ul);

    /// <summary>
    /// <para>The light mask. See <see cref="Godot.LightOccluder2D"/> for more information on light masks.</para>
    /// </summary>
    public static void CanvasLightSetItemCullMask(Rid light, int mask)
    {
        NativeCalls.godot_icall_2_426(MethodBind464, GodotObject.GetPtr(Singleton), light, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind465 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetItemShadowCullMask, 3411492887ul);

    /// <summary>
    /// <para>The binary mask used to determine which layers this canvas light's shadows affects. See <see cref="Godot.LightOccluder2D"/> for more information on light masks.</para>
    /// </summary>
    public static void CanvasLightSetItemShadowCullMask(Rid light, int mask)
    {
        NativeCalls.godot_icall_2_426(MethodBind465, GodotObject.GetPtr(Singleton), light, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind466 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetMode, 2957564891ul);

    /// <summary>
    /// <para>Sets the mode of the canvas light.</para>
    /// </summary>
    public static void CanvasLightSetMode(Rid light, RenderingServer.CanvasLightMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind466, GodotObject.GetPtr(Singleton), light, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind467 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetShadowEnabled, 1265174801ul);

    /// <summary>
    /// <para>Enables or disables the canvas light's shadow.</para>
    /// </summary>
    public static void CanvasLightSetShadowEnabled(Rid light, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind467, GodotObject.GetPtr(Singleton), light, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind468 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetShadowFilter, 393119659ul);

    /// <summary>
    /// <para>Sets the canvas light's shadow's filter.</para>
    /// </summary>
    public static void CanvasLightSetShadowFilter(Rid light, RenderingServer.CanvasLightShadowFilter filter)
    {
        NativeCalls.godot_icall_2_426(MethodBind468, GodotObject.GetPtr(Singleton), light, (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind469 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetShadowColor, 2948539648ul);

    /// <summary>
    /// <para>Sets the color of the canvas light's shadow.</para>
    /// </summary>
    public static unsafe void CanvasLightSetShadowColor(Rid light, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind469, GodotObject.GetPtr(Singleton), light, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind470 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetShadowSmooth, 1794382983ul);

    /// <summary>
    /// <para>Smoothens the shadow. The lower, the smoother.</para>
    /// </summary>
    public static void CanvasLightSetShadowSmooth(Rid light, float smooth)
    {
        NativeCalls.godot_icall_2_816(MethodBind470, GodotObject.GetPtr(Singleton), light, smooth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind471 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetBlendMode, 804895945ul);

    /// <summary>
    /// <para>Sets the blend mode for the given canvas light to <paramref name="mode"/>. Equivalent to <see cref="Godot.Light2D.BlendMode"/>.</para>
    /// </summary>
    public static void CanvasLightSetBlendMode(Rid light, RenderingServer.CanvasLightBlendMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind471, GodotObject.GetPtr(Singleton), light, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind472 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightSetInterpolated, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="interpolated"/> is <see langword="true"/>, turns on physics interpolation for the canvas light.</para>
    /// </summary>
    public static void CanvasLightSetInterpolated(Rid light, bool interpolated)
    {
        NativeCalls.godot_icall_2_434(MethodBind472, GodotObject.GetPtr(Singleton), light, interpolated.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind473 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightResetPhysicsInterpolation, 2722037293ul);

    /// <summary>
    /// <para>Prevents physics interpolation for the current physics tick.</para>
    /// <para>This is useful when moving a canvas item to a new location, to give an instantaneous change rather than interpolation from the previous location.</para>
    /// </summary>
    public static void CanvasLightResetPhysicsInterpolation(Rid light)
    {
        NativeCalls.godot_icall_1_286(MethodBind473, GodotObject.GetPtr(Singleton), light);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind474 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightTransformPhysicsInterpolation, 1246044741ul);

    /// <summary>
    /// <para>Transforms both the current and previous stored transform for a canvas light.</para>
    /// <para>This allows transforming a light without creating a "glitch" in the interpolation, which is particularly useful for large worlds utilizing a shifting origin.</para>
    /// </summary>
    public static unsafe void CanvasLightTransformPhysicsInterpolation(Rid light, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind474, GodotObject.GetPtr(Singleton), light, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind475 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a light occluder and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_light_occluder_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent node is <see cref="Godot.LightOccluder2D"/>.</para>
    /// </summary>
    public static Rid CanvasLightOccluderCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind475, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind476 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderAttachToCanvas, 395945892ul);

    /// <summary>
    /// <para>Attaches a light occluder to the canvas. Removes it from its previous canvas.</para>
    /// </summary>
    public static void CanvasLightOccluderAttachToCanvas(Rid occluder, Rid canvas)
    {
        NativeCalls.godot_icall_2_430(MethodBind476, GodotObject.GetPtr(Singleton), occluder, canvas);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind477 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetEnabled, 1265174801ul);

    /// <summary>
    /// <para>Enables or disables light occluder.</para>
    /// </summary>
    public static void CanvasLightOccluderSetEnabled(Rid occluder, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind477, GodotObject.GetPtr(Singleton), occluder, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind478 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetPolygon, 395945892ul);

    /// <summary>
    /// <para>Sets a light occluder's polygon.</para>
    /// </summary>
    public static void CanvasLightOccluderSetPolygon(Rid occluder, Rid polygon)
    {
        NativeCalls.godot_icall_2_430(MethodBind478, GodotObject.GetPtr(Singleton), occluder, polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind479 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetAsSdfCollision, 1265174801ul);

    public static void CanvasLightOccluderSetAsSdfCollision(Rid occluder, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind479, GodotObject.GetPtr(Singleton), occluder, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind480 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets a light occluder's <see cref="Godot.Transform2D"/>.</para>
    /// </summary>
    public static unsafe void CanvasLightOccluderSetTransform(Rid occluder, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind480, GodotObject.GetPtr(Singleton), occluder, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind481 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetLightMask, 3411492887ul);

    /// <summary>
    /// <para>The light mask. See <see cref="Godot.LightOccluder2D"/> for more information on light masks.</para>
    /// </summary>
    public static void CanvasLightOccluderSetLightMask(Rid occluder, int mask)
    {
        NativeCalls.godot_icall_2_426(MethodBind481, GodotObject.GetPtr(Singleton), occluder, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind482 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderSetInterpolated, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="interpolated"/> is <see langword="true"/>, turns on physics interpolation for the light occluder.</para>
    /// </summary>
    public static void CanvasLightOccluderSetInterpolated(Rid occluder, bool interpolated)
    {
        NativeCalls.godot_icall_2_434(MethodBind482, GodotObject.GetPtr(Singleton), occluder, interpolated.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind483 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderResetPhysicsInterpolation, 2722037293ul);

    /// <summary>
    /// <para>Prevents physics interpolation for the current physics tick.</para>
    /// <para>This is useful when moving an occluder to a new location, to give an instantaneous change rather than interpolation from the previous location.</para>
    /// </summary>
    public static void CanvasLightOccluderResetPhysicsInterpolation(Rid occluder)
    {
        NativeCalls.godot_icall_1_286(MethodBind483, GodotObject.GetPtr(Singleton), occluder);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind484 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasLightOccluderTransformPhysicsInterpolation, 1246044741ul);

    /// <summary>
    /// <para>Transforms both the current and previous stored transform for a light occluder.</para>
    /// <para>This allows transforming an occluder without creating a "glitch" in the interpolation, which is particularly useful for large worlds utilizing a shifting origin.</para>
    /// </summary>
    public static unsafe void CanvasLightOccluderTransformPhysicsInterpolation(Rid occluder, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind484, GodotObject.GetPtr(Singleton), occluder, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind485 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasOccluderPolygonCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new light occluder polygon and adds it to the RenderingServer. It can be accessed with the RID that is returned. This RID will be used in all <c>canvas_occluder_polygon_*</c> RenderingServer functions.</para>
    /// <para>Once finished with your RID, you will want to free the RID using the RenderingServer's <see cref="Godot.RenderingServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> The equivalent resource is <see cref="Godot.OccluderPolygon2D"/>.</para>
    /// </summary>
    public static Rid CanvasOccluderPolygonCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind485, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind486 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasOccluderPolygonSetShape, 2103882027ul);

    /// <summary>
    /// <para>Sets the shape of the occluder polygon.</para>
    /// </summary>
    public static void CanvasOccluderPolygonSetShape(Rid occluderPolygon, Vector2[] shape, bool closed)
    {
        NativeCalls.godot_icall_3_1210(MethodBind486, GodotObject.GetPtr(Singleton), occluderPolygon, shape, closed.ToGodotBool());
    }

    /// <summary>
    /// <para>Sets the shape of the occluder polygon.</para>
    /// </summary>
    public static void CanvasOccluderPolygonSetShape(Rid occluderPolygon, ReadOnlySpan<Vector2> shape, bool closed)
    {
        NativeCalls.godot_icall_3_1210(MethodBind486, GodotObject.GetPtr(Singleton), occluderPolygon, shape, closed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind487 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasOccluderPolygonSetCullMode, 1839404663ul);

    /// <summary>
    /// <para>Sets an occluder polygon's cull mode.</para>
    /// </summary>
    public static void CanvasOccluderPolygonSetCullMode(Rid occluderPolygon, RenderingServer.CanvasOccluderPolygonCullMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind487, GodotObject.GetPtr(Singleton), occluderPolygon, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind488 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasSetShadowTextureSize, 1286410249ul);

    /// <summary>
    /// <para>Sets the <c>ProjectSettings.rendering/2d/shadow_atlas/size</c> to use for <see cref="Godot.Light2D"/> shadow rendering (in pixels). The value is rounded up to the nearest power of 2.</para>
    /// </summary>
    public static void CanvasSetShadowTextureSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind488, GodotObject.GetPtr(Singleton), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind489 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterAdd, 463390080ul);

    /// <summary>
    /// <para>Creates a new global shader uniform.</para>
    /// <para><b>Note:</b> Global shader parameter names are case-sensitive.</para>
    /// </summary>
    public static void GlobalShaderParameterAdd(StringName name, RenderingServer.GlobalShaderParameterType type, Variant defaultValue)
    {
        NativeCalls.godot_icall_3_1211(MethodBind489, GodotObject.GetPtr(Singleton), (godot_string_name)(name?.NativeValue ?? default), (int)type, defaultValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind490 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterRemove, 3304788590ul);

    /// <summary>
    /// <para>Removes the global shader uniform specified by <paramref name="name"/>.</para>
    /// </summary>
    public static void GlobalShaderParameterRemove(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind490, GodotObject.GetPtr(Singleton), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind491 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterGetList, 3995934104ul);

    /// <summary>
    /// <para>Returns the list of global shader uniform names.</para>
    /// <para><b>Note:</b> <see cref="Godot.RenderingServer.GlobalShaderParameterGet(StringName)"/> has a large performance penalty as the rendering thread needs to synchronize with the calling thread, which is slow. Do not use this method during gameplay to avoid stuttering. If you need to read values in a script after setting them, consider creating an autoload where you store the values you need to query at the same time you're setting them as global parameters.</para>
    /// </summary>
    public static Godot.Collections.Array<StringName> GlobalShaderParameterGetList()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind491, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind492 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterSet, 3776071444ul);

    /// <summary>
    /// <para>Sets the global shader uniform <paramref name="name"/> to <paramref name="value"/>.</para>
    /// </summary>
    public static void GlobalShaderParameterSet(StringName name, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind492, GodotObject.GetPtr(Singleton), (godot_string_name)(name?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind493 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterSetOverride, 3776071444ul);

    /// <summary>
    /// <para>Overrides the global shader uniform <paramref name="name"/> with <paramref name="value"/>. Equivalent to the <see cref="Godot.ShaderGlobalsOverride"/> node.</para>
    /// </summary>
    public static void GlobalShaderParameterSetOverride(StringName name, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind493, GodotObject.GetPtr(Singleton), (godot_string_name)(name?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind494 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterGet, 2760726917ul);

    /// <summary>
    /// <para>Returns the value of the global shader uniform specified by <paramref name="name"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.RenderingServer.GlobalShaderParameterGet(StringName)"/> has a large performance penalty as the rendering thread needs to synchronize with the calling thread, which is slow. Do not use this method during gameplay to avoid stuttering. If you need to read values in a script after setting them, consider creating an autoload where you store the values you need to query at the same time you're setting them as global parameters.</para>
    /// </summary>
    public static Variant GlobalShaderParameterGet(StringName name)
    {
        return NativeCalls.godot_icall_1_143(MethodBind494, GodotObject.GetPtr(Singleton), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind495 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalShaderParameterGetType, 1601414142ul);

    /// <summary>
    /// <para>Returns the type associated to the global shader uniform specified by <paramref name="name"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.RenderingServer.GlobalShaderParameterGet(StringName)"/> has a large performance penalty as the rendering thread needs to synchronize with the calling thread, which is slow. Do not use this method during gameplay to avoid stuttering. If you need to read values in a script after setting them, consider creating an autoload where you store the values you need to query at the same time you're setting them as global parameters.</para>
    /// </summary>
    public static RenderingServer.GlobalShaderParameterType GlobalShaderParameterGetType(StringName name)
    {
        return (RenderingServer.GlobalShaderParameterType)NativeCalls.godot_icall_1_193(MethodBind495, GodotObject.GetPtr(Singleton), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind496 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeRid, 2722037293ul);

    /// <summary>
    /// <para>Tries to free an object in the RenderingServer. To avoid memory leaks, this should be called after using an object as memory management does not occur automatically when using RenderingServer directly.</para>
    /// </summary>
    public static void FreeRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind496, GodotObject.GetPtr(Singleton), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind497 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestFrameDrawnCallback, 1611583062ul);

    /// <summary>
    /// <para>Schedules a callback to the given callable after a frame has been drawn.</para>
    /// </summary>
    public static void RequestFrameDrawnCallback(Callable callable)
    {
        NativeCalls.godot_icall_1_403(MethodBind497, GodotObject.GetPtr(Singleton), callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind498 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasChanged, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if changes have been made to the RenderingServer's data. <see cref="Godot.RenderingServer.ForceDraw(bool, double)"/> is usually called if this happens.</para>
    /// </summary>
    public static bool HasChanged()
    {
        return NativeCalls.godot_icall_0_15(MethodBind498, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind499 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderingInfo, 3763192241ul);

    /// <summary>
    /// <para>Returns a statistic about the rendering engine which can be used for performance profiling. See also <see cref="Godot.RenderingServer.ViewportGetRenderInfo(Rid, RenderingServer.ViewportRenderInfoType, RenderingServer.ViewportRenderInfo)"/>, which returns information specific to a viewport.</para>
    /// <para><b>Note:</b> Only 3D rendering is currently taken into account by some of these values, such as the number of draw calls.</para>
    /// <para><b>Note:</b> Rendering information is not available until at least 2 frames have been rendered by the engine. If rendering information is not available, <see cref="Godot.RenderingServer.GetRenderingInfo(RenderingServer.RenderingInfo)"/> returns <c>0</c>. To print rendering information in <c>_ready()</c> successfully, use the following:</para>
    /// <para><code>
    /// func _ready():
    /// 	for _i in 2:
    /// 		await get_tree().process_frame
    /// 
    /// 	print(RenderingServer.get_rendering_info(RENDERING_INFO_TOTAL_DRAW_CALLS_IN_FRAME))
    /// </code></para>
    /// </summary>
    public static ulong GetRenderingInfo(RenderingServer.RenderingInfo info)
    {
        return NativeCalls.godot_icall_1_240(MethodBind499, GodotObject.GetPtr(Singleton), (int)info);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind500 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVideoAdapterName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the video adapter (e.g. "GeForce GTX 1080/PCIe/SSE2").</para>
    /// <para><b>Note:</b> When running a headless or server binary, this function returns an empty string.</para>
    /// <para><b>Note:</b> On the web platform, some browsers such as Firefox may report a different, fixed GPU name such as "GeForce GTX 980" (regardless of the user's actual GPU model). This is done to make fingerprinting more difficult.</para>
    /// </summary>
    public static string GetVideoAdapterName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind500, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind501 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVideoAdapterVendor, 201670096ul);

    /// <summary>
    /// <para>Returns the vendor of the video adapter (e.g. "NVIDIA Corporation").</para>
    /// <para><b>Note:</b> When running a headless or server binary, this function returns an empty string.</para>
    /// </summary>
    public static string GetVideoAdapterVendor()
    {
        return NativeCalls.godot_icall_0_58(MethodBind501, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind502 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVideoAdapterType, 3099547011ul);

    /// <summary>
    /// <para>Returns the type of the video adapter. Since dedicated graphics cards from a given generation will <i>usually</i> be significantly faster than integrated graphics made in the same generation, the device type can be used as a basis for automatic graphics settings adjustment. However, this is not always true, so make sure to provide users with a way to manually override graphics settings.</para>
    /// <para><b>Note:</b> When using the OpenGL rendering driver or when running in headless mode, this function always returns <see cref="Godot.RenderingDevice.DeviceType.Other"/>.</para>
    /// </summary>
    public static RenderingDevice.DeviceType GetVideoAdapterType()
    {
        return (RenderingDevice.DeviceType)NativeCalls.godot_icall_0_39(MethodBind502, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind503 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVideoAdapterApiVersion, 201670096ul);

    /// <summary>
    /// <para>Returns the version of the graphics video adapter <i>currently in use</i> (e.g. "1.2.189" for Vulkan, "3.3.0 NVIDIA 510.60.02" for OpenGL). This version may be different from the actual latest version supported by the hardware, as Godot may not always request the latest version. See also <see cref="Godot.OS.GetVideoAdapterDriverInfo()"/>.</para>
    /// <para><b>Note:</b> When running a headless or server binary, this function returns an empty string.</para>
    /// </summary>
    public static string GetVideoAdapterApiVersion()
    {
        return NativeCalls.godot_icall_0_58(MethodBind503, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind504 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentRenderingDriverName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the current rendering driver. This can be <c>vulkan</c>, <c>d3d12</c>, <c>metal</c>, <c>opengl3</c>, <c>opengl3_es</c>, or <c>opengl3_angle</c>. See also <see cref="Godot.RenderingServer.GetCurrentRenderingMethod()"/>.</para>
    /// <para>When <c>ProjectSettings.rendering/renderer/rendering_method</c> is <c>forward_plus</c> or <c>mobile</c>, the rendering driver is determined by <c>ProjectSettings.rendering/rendering_device/driver</c>.</para>
    /// <para>When <c>ProjectSettings.rendering/renderer/rendering_method</c> is <c>gl_compatibility</c>, the rendering driver is determined by <c>ProjectSettings.rendering/gl_compatibility/driver</c>.</para>
    /// <para>The rendering driver is also determined by the <c>--rendering-driver</c> command line argument that overrides this project setting, or an automatic fallback that is applied depending on the hardware.</para>
    /// </summary>
    public static string GetCurrentRenderingDriverName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind504, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind505 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentRenderingMethod, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the current rendering method. This can be <c>forward_plus</c>, <c>mobile</c>, or <c>gl_compatibility</c>. See also <see cref="Godot.RenderingServer.GetCurrentRenderingDriverName()"/>.</para>
    /// <para>The rendering method is determined by <c>ProjectSettings.rendering/renderer/rendering_method</c>, the <c>--rendering-method</c> command line argument that overrides this project setting, or an automatic fallback that is applied depending on the hardware.</para>
    /// </summary>
    public static string GetCurrentRenderingMethod()
    {
        return NativeCalls.godot_icall_0_58(MethodBind505, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind506 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeSphereMesh, 2251015897ul);

    /// <summary>
    /// <para>Returns a mesh of a sphere with the given number of horizontal subdivisions, vertical subdivisions and radius. See also <see cref="Godot.RenderingServer.GetTestCube()"/>.</para>
    /// </summary>
    public static Rid MakeSphereMesh(int latitudes, int longitudes, float radius)
    {
        return NativeCalls.godot_icall_3_1212(MethodBind506, GodotObject.GetPtr(Singleton), latitudes, longitudes, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind507 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTestCube, 529393457ul);

    /// <summary>
    /// <para>Returns the RID of the test cube. This mesh will be created and returned on the first call to <see cref="Godot.RenderingServer.GetTestCube()"/>, then it will be cached for subsequent calls. See also <see cref="Godot.RenderingServer.MakeSphereMesh(int, int, float)"/>.</para>
    /// </summary>
    public static Rid GetTestCube()
    {
        return NativeCalls.godot_icall_0_238(MethodBind507, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind508 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTestTexture, 529393457ul);

    /// <summary>
    /// <para>Returns the RID of a 256×256 texture with a testing pattern on it (in <see cref="Godot.Image.Format.Rgb8"/> format). This texture will be created and returned on the first call to <see cref="Godot.RenderingServer.GetTestTexture()"/>, then it will be cached for subsequent calls. See also <see cref="Godot.RenderingServer.GetWhiteTexture()"/>.</para>
    /// <para><b>Example:</b> Get the test texture and apply it to a <see cref="Godot.Sprite2D"/> node:</para>
    /// <para><code>
    /// var texture_rid = RenderingServer.get_test_texture()
    /// var texture = ImageTexture.create_from_image(RenderingServer.texture_2d_get(texture_rid))
    /// $Sprite2D.texture = texture
    /// </code></para>
    /// </summary>
    public static Rid GetTestTexture()
    {
        return NativeCalls.godot_icall_0_238(MethodBind508, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind509 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWhiteTexture, 529393457ul);

    /// <summary>
    /// <para>Returns the ID of a 4×4 white texture (in <see cref="Godot.Image.Format.Rgb8"/> format). This texture will be created and returned on the first call to <see cref="Godot.RenderingServer.GetWhiteTexture()"/>, then it will be cached for subsequent calls. See also <see cref="Godot.RenderingServer.GetTestTexture()"/>.</para>
    /// <para><b>Example:</b> Get the white texture and apply it to a <see cref="Godot.Sprite2D"/> node:</para>
    /// <para><code>
    /// var texture_rid = RenderingServer.get_white_texture()
    /// var texture = ImageTexture.create_from_image(RenderingServer.texture_2d_get(texture_rid))
    /// $Sprite2D.texture = texture
    /// </code></para>
    /// </summary>
    public static Rid GetWhiteTexture()
    {
        return NativeCalls.godot_icall_0_238(MethodBind509, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind510 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBootImageWithStretch, 1104470771ul);

    /// <summary>
    /// <para>Sets a boot image. The <paramref name="color"/> defines the background color. The value of <paramref name="stretchMode"/> indicates how the image will be stretched (see <see cref="Godot.RenderingServer.SplashStretchMode"/> for possible values). If <paramref name="useFilter"/> is <see langword="true"/>, the image will be scaled with linear interpolation. If <paramref name="useFilter"/> is <see langword="false"/>, the image will be scaled with nearest-neighbor interpolation.</para>
    /// </summary>
    public static unsafe void SetBootImageWithStretch(Image image, Color color, RenderingServer.SplashStretchMode stretchMode, bool useFilter = true)
    {
        NativeCalls.godot_icall_4_1213(MethodBind510, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(image), &color, (int)stretchMode, useFilter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind511 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBootImage, 3759744527ul);

    /// <summary>
    /// <para>Sets a boot image. The <paramref name="color"/> defines the background color. The value of <paramref name="scale"/> indicates if the image will be scaled to fit the screen size. If <paramref name="useFilter"/> is <see langword="true"/>, the image will be scaled with linear interpolation. If <paramref name="useFilter"/> is <see langword="false"/>, the image will be scaled with nearest-neighbor interpolation.</para>
    /// </summary>
    [Obsolete("Use 'Godot.RenderingServer.SetBootImageWithStretch(Image, Color, RenderingServer.SplashStretchMode, bool)' instead.")]
    public static unsafe void SetBootImage(Image image, Color color, bool scale, bool useFilter = true)
    {
        NativeCalls.godot_icall_4_1214(MethodBind511, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(image), &color, scale.ToGodotBool(), useFilter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind512 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultClearColor, 3200896285ul);

    /// <summary>
    /// <para>Returns the default clear color which is used when a specific clear color has not been selected. See also <see cref="Godot.RenderingServer.SetDefaultClearColor(Color)"/>.</para>
    /// </summary>
    public static Color GetDefaultClearColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind512, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind513 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultClearColor, 2920490490ul);

    /// <summary>
    /// <para>Sets the default clear color which is used when a specific clear color has not been selected. See also <see cref="Godot.RenderingServer.GetDefaultClearColor()"/>.</para>
    /// </summary>
    public static unsafe void SetDefaultClearColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind513, GodotObject.GetPtr(Singleton), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind514 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasOsFeature, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the OS supports a certain <paramref name="feature"/>. Features might be <c>s3tc</c>, <c>etc</c>, and <c>etc2</c>.</para>
    /// </summary>
    public static bool HasOsFeature(string feature)
    {
        return NativeCalls.godot_icall_1_131(MethodBind514, GodotObject.GetPtr(Singleton), feature).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind515 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugGenerateWireframes, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="generate"/> is <see langword="true"/>, generates debug wireframes for all meshes that are loaded when using the Compatibility renderer. By default, the engine does not generate debug wireframes at runtime, since they slow down loading of assets and take up VRAM.</para>
    /// <para><b>Note:</b> You must call this method before loading any meshes when using the Compatibility renderer, otherwise wireframes will not be used.</para>
    /// </summary>
    public static void SetDebugGenerateWireframes(bool generate)
    {
        NativeCalls.godot_icall_1_14(MethodBind515, GodotObject.GetPtr(Singleton), generate.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind516 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRenderLoopEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsRenderLoopEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind516, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind517 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderLoopEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetRenderLoopEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind517, GodotObject.GetPtr(Singleton), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind518 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameSetupTimeCpu, 1740695150ul);

    /// <summary>
    /// <para>Returns the time taken to setup rendering on the CPU in milliseconds. This value is shared across all viewports and does <i>not</i> require <see cref="Godot.RenderingServer.ViewportSetMeasureRenderTime(Rid, bool)"/> to be enabled on a viewport to be queried. See also <see cref="Godot.RenderingServer.ViewportGetMeasuredRenderTimeCpu(Rid)"/>.</para>
    /// </summary>
    public static double GetFrameSetupTimeCpu()
    {
        return NativeCalls.godot_icall_0_144(MethodBind518, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind519 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceSync, 3218959716ul);

    /// <summary>
    /// <para>Forces a synchronization between the CPU and GPU, which may be required in certain cases. Only call this when needed, as CPU-GPU synchronization has a performance cost.</para>
    /// </summary>
    public static void ForceSync()
    {
        NativeCalls.godot_icall_0_3(MethodBind519, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind520 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceDraw, 1076185472ul);

    /// <summary>
    /// <para>Forces redrawing of all viewports at once. Must be called from the main thread.</para>
    /// </summary>
    public static void ForceDraw(bool swapBuffers = true, double frameStep = 0.0)
    {
        NativeCalls.godot_icall_2_1215(MethodBind520, GodotObject.GetPtr(Singleton), swapBuffers.ToGodotBool(), frameStep);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind521 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderingDevice, 1405107940ul);

    /// <summary>
    /// <para>Returns the global RenderingDevice.</para>
    /// <para><b>Note:</b> When using the OpenGL rendering driver or when running in headless mode, this function always returns <see langword="null"/>.</para>
    /// </summary>
    public static RenderingDevice GetRenderingDevice()
    {
        return (RenderingDevice)NativeCalls.godot_icall_0_53(MethodBind521, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind522 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateLocalRenderingDevice, 1405107940ul);

    /// <summary>
    /// <para>Creates a RenderingDevice that can be used to do draw and compute operations on a separate thread. Cannot draw to the screen nor share data with the global RenderingDevice.</para>
    /// <para><b>Note:</b> When using the OpenGL rendering driver or when running in headless mode, this function always returns <see langword="null"/>.</para>
    /// </summary>
    public static RenderingDevice CreateLocalRenderingDevice()
    {
        return (RenderingDevice)NativeCalls.godot_icall_0_53(MethodBind522, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind523 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOnRenderThread, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if our code is currently executing on the rendering thread.</para>
    /// </summary>
    public static bool IsOnRenderThread()
    {
        return NativeCalls.godot_icall_0_15(MethodBind523, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind524 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CallOnRenderThread, 1611583062ul);

    /// <summary>
    /// <para>As the RenderingServer actual logic may run on a separate thread, accessing its internals from the main (or any other) thread will result in errors. To make it easier to run code that can safely access the rendering internals (such as <see cref="Godot.RenderingDevice"/> and similar RD classes), push a callable via this function so it will be executed on the render thread.</para>
    /// </summary>
    public static void CallOnRenderThread(Callable callable)
    {
        NativeCalls.godot_icall_1_403(MethodBind524, GodotObject.GetPtr(Singleton), callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind525 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasFeature, 598462696ul);

    /// <summary>
    /// <para>This method does nothing and always returns <see langword="false"/>.</para>
    /// </summary>
    [Obsolete("This method has not been used since Godot 3.0.")]
    public static bool HasFeature(RenderingServer.Features feature)
    {
        return NativeCalls.godot_icall_1_62(MethodBind525, GodotObject.GetPtr(Singleton), (int)feature).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind526 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceResetPhysicsInterpolation, 2722037293ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void InstanceResetPhysicsInterpolation(Rid instance)
    {
        NativeCalls.godot_icall_1_286(MethodBind526, GodotObject.GetPtr(Singleton), instance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind527 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceSetInterpolated, 1265174801ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void InstanceSetInterpolated(Rid instance, bool interpolated)
    {
        NativeCalls.godot_icall_2_434(MethodBind527, GodotObject.GetPtr(Singleton), instance, interpolated.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind528 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddCircle, 2439351960ul);

    /// <summary>
    /// <para>Draws a circle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawCircle(Vector2, float, Color, bool, float, bool)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static unsafe void CanvasItemAddCircle(Rid item, Vector2 pos, float radius, Color color)
    {
        NativeCalls.godot_icall_4_1216(MethodBind528, GodotObject.GetPtr(Singleton), item, &pos, radius, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind529 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddRect, 934531857ul);

    /// <summary>
    /// <para>Draws a rectangle on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawRect(Rect2, Color, bool, float, bool)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static unsafe void CanvasItemAddRect(Rid item, Rect2 rect, Color color)
    {
        NativeCalls.godot_icall_3_1217(MethodBind529, GodotObject.GetPtr(Singleton), item, &rect, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind530 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CanvasItemAddMultiline, 2088642721ul);

    /// <summary>
    /// <para>Draws a 2D multiline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawMultilineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void CanvasItemAddMultiline(Rid item, Vector2[] points, Color[] colors, float width)
    {
        NativeCalls.godot_icall_4_1218(MethodBind530, GodotObject.GetPtr(Singleton), item, points, colors, width);
    }

    /// <summary>
    /// <para>Draws a 2D multiline on the <see cref="Godot.CanvasItem"/> pointed to by the <paramref name="item"/> <see cref="Godot.Rid"/>. See also <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawMultilineColors(Vector2[], Color[], float, bool)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void CanvasItemAddMultiline(Rid item, ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, float width)
    {
        NativeCalls.godot_icall_4_1218(MethodBind530, GodotObject.GetPtr(Singleton), item, points, colors, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind531 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnvironmentSetFog, 2793577733ul);

    /// <summary>
    /// <para>Configures fog for the specified environment RID. See <c>fog_*</c> properties in <see cref="Godot.Environment"/> for more information.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static unsafe void EnvironmentSetFog(Rid env, bool enable, Color lightColor, float lightEnergy, float sunScatter, float density, float height, float heightDensity, float aerialPerspective, float skyAffect)
    {
        NativeCalls.godot_icall_10_1219(MethodBind531, GodotObject.GetPtr(Singleton), env, enable.ToGodotBool(), &lightColor, lightEnergy, sunScatter, density, height, heightDensity, aerialPerspective, skyAffect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind532 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MultimeshAllocateData, 283685892ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void MultimeshAllocateData(Rid multimesh, int instances, RenderingServer.MultimeshTransformFormat transformFormat, bool colorFormat, bool customDataFormat)
    {
        NativeCalls.godot_icall_5_1220(MethodBind532, GodotObject.GetPtr(Singleton), multimesh, instances, (int)transformFormat, colorFormat.ToGodotBool(), customDataFormat.ToGodotBool());
    }

    /// <summary>
    /// <para>Emitted at the beginning of the frame, before the RenderingServer updates all the Viewports.</para>
    /// </summary>
    public static event Action FramePreDraw
    {
        add => Singleton.Connect(SignalName.FramePreDraw, Callable.From(value));
        remove => Singleton.Disconnect(SignalName.FramePreDraw, Callable.From(value));
    }

    /// <summary>
    /// <para>Emitted at the end of the frame, after the RenderingServer has finished updating all the Viewports.</para>
    /// </summary>
    public static event Action FramePostDraw
    {
        add => Singleton.Connect(SignalName.FramePostDraw, Callable.From(value));
        remove => Singleton.Disconnect(SignalName.FramePostDraw, Callable.From(value));
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
        /// <summary>
        /// Cached name for the 'render_loop_enabled' property.
        /// </summary>
        public static readonly StringName RenderLoopEnabled = "render_loop_enabled";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
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
    public class SignalName
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
