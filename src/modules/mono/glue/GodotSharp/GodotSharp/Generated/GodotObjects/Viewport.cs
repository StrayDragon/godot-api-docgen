namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A <see cref="Godot.Viewport"/> creates a different view into the screen, or a sub-view inside another viewport. Child 2D nodes will display on it, and child Camera3D 3D nodes will render on it too.</para>
/// <para>Optionally, a viewport can have its own 2D or 3D world, so it doesn't share what it draws with other viewports.</para>
/// <para>Viewports can also choose to be audio listeners, so they generate positional audio depending on a 2D or 3D camera child of it.</para>
/// <para>Also, viewports can be assigned to different screens in case the devices have multiple screens.</para>
/// <para>Finally, viewports can also behave as render targets, in which case they will not be visible unless the associated texture is used to draw.</para>
/// </summary>
public partial class Viewport : Node
{
    public enum PositionalShadowAtlasQuadrantSubdiv : long
    {
        /// <summary>
        /// <para>This quadrant will not be used.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>This quadrant will only be used by one shadow map.</para>
        /// </summary>
        Subdiv1 = 1,
        /// <summary>
        /// <para>This quadrant will be split in 4 and used by up to 4 shadow maps.</para>
        /// </summary>
        Subdiv4 = 2,
        /// <summary>
        /// <para>This quadrant will be split 16 ways and used by up to 16 shadow maps.</para>
        /// </summary>
        Subdiv16 = 3,
        /// <summary>
        /// <para>This quadrant will be split 64 ways and used by up to 64 shadow maps.</para>
        /// </summary>
        Subdiv64 = 4,
        /// <summary>
        /// <para>This quadrant will be split 256 ways and used by up to 256 shadow maps. Unless the <see cref="Godot.Viewport.PositionalShadowAtlasSize"/> is very high, the shadows in this quadrant will be very low resolution.</para>
        /// </summary>
        Subdiv256 = 5,
        /// <summary>
        /// <para>This quadrant will be split 1024 ways and used by up to 1024 shadow maps. Unless the <see cref="Godot.Viewport.PositionalShadowAtlasSize"/> is very high, the shadows in this quadrant will be very low resolution.</para>
        /// </summary>
        Subdiv1024 = 6,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Viewport.PositionalShadowAtlasQuadrantSubdiv"/> enum.</para>
        /// </summary>
        Max = 7
    }

    public enum Scaling3DModeEnum : long
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
        /// <para>Use the <a href="https://developer.apple.com/documentation/metalfx/mtlfxspatialscaler#overview">MetalFX spatial upscaler</a> for the viewport's 3D buffer.</para>
        /// <para>The amount of scaling can be set using <see cref="Godot.Viewport.Scaling3DScale"/>.</para>
        /// <para>Values less than <c>1.0</c> will result in the viewport being upscaled using MetalFX. Values greater than <c>1.0</c> are not supported and bilinear downsampling will be used instead. A value of <c>1.0</c> disables scaling.</para>
        /// <para>More information: <a href="https://developer.apple.com/documentation/metalfx">MetalFX</a>.</para>
        /// <para><b>Note:</b> Only supported when the Metal rendering driver is in use, which limits this scaling mode to macOS and iOS.</para>
        /// </summary>
        MetalfxSpatial = 3,
        /// <summary>
        /// <para>Use the <a href="https://developer.apple.com/documentation/metalfx/mtlfxtemporalscaler#overview">MetalFX temporal upscaler</a> for the viewport's 3D buffer.</para>
        /// <para>The amount of scaling can be set using <see cref="Godot.Viewport.Scaling3DScale"/>. To determine the minimum input scale, use the <see cref="Godot.RenderingDevice.LimitGet(RenderingDevice.Limit)"/> method with <see cref="Godot.RenderingDevice.Limit.MetalfxTemporalScalerMinScale"/>.</para>
        /// <para>Values less than <c>1.0</c> will result in the viewport being upscaled using MetalFX. Values greater than <c>1.0</c> are not supported and bilinear downsampling will be used instead. A value of <c>1.0</c> will use MetalFX at native resolution as a TAA solution.</para>
        /// <para>More information: <a href="https://developer.apple.com/documentation/metalfx">MetalFX</a>.</para>
        /// <para><b>Note:</b> Only supported when the Metal rendering driver is in use, which limits this scaling mode to macOS and iOS.</para>
        /// </summary>
        MetalfxTemporal = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Viewport.Scaling3DModeEnum"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum Msaa : long
    {
        /// <summary>
        /// <para>Multisample antialiasing mode disabled. This is the default value, and is also the fastest setting.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Use 2× Multisample Antialiasing. This has a moderate performance cost. It helps reduce aliasing noticeably, but 4× MSAA still looks substantially better.</para>
        /// </summary>
        Msaa2X = 1,
        /// <summary>
        /// <para>Use 4× Multisample Antialiasing. This has a significant performance cost, and is generally a good compromise between performance and quality.</para>
        /// </summary>
        Msaa4X = 2,
        /// <summary>
        /// <para>Use 8× Multisample Antialiasing. This has a very high performance cost. The difference between 4× and 8× MSAA may not always be visible in real gameplay conditions. Likely unsupported on low-end and older hardware.</para>
        /// </summary>
        Msaa8X = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Viewport.Msaa"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum AnisotropicFiltering : long
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
        /// <para>Represents the size of the <see cref="Godot.Viewport.AnisotropicFiltering"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum ScreenSpaceAAEnum : long
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
        /// <para>Represents the size of the <see cref="Godot.Viewport.ScreenSpaceAAEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum RenderInfo : long
    {
        /// <summary>
        /// <para>Amount of objects in frame.</para>
        /// </summary>
        ObjectsInFrame = 0,
        /// <summary>
        /// <para>Amount of vertices in frame.</para>
        /// </summary>
        PrimitivesInFrame = 1,
        /// <summary>
        /// <para>Amount of draw calls in frame.</para>
        /// </summary>
        DrawCallsInFrame = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Viewport.RenderInfo"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum RenderInfoType : long
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
        /// <para>Represents the size of the <see cref="Godot.Viewport.RenderInfoType"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum DebugDrawEnum : long
    {
        /// <summary>
        /// <para>Objects are displayed normally.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Objects are displayed without light information.</para>
        /// </summary>
        Unshaded = 1,
        /// <summary>
        /// <para>Objects are displayed without textures and only with lighting information.</para>
        /// <para><b>Note:</b> When using this debug draw mode, custom shaders are ignored since all materials in the scene temporarily use a debug material. This means the result from custom shader functions (such as vertex displacement) won't be visible anymore when using this debug draw mode.</para>
        /// </summary>
        Lighting = 2,
        /// <summary>
        /// <para>Objects are displayed semi-transparent with additive blending so you can see where they are drawing over top of one another. A higher overdraw means you are wasting performance on drawing pixels that are being hidden behind others.</para>
        /// <para><b>Note:</b> When using this debug draw mode, custom shaders are ignored since all materials in the scene temporarily use a debug material. This means the result from custom shader functions (such as vertex displacement) won't be visible anymore when using this debug draw mode.</para>
        /// </summary>
        Overdraw = 3,
        /// <summary>
        /// <para>Objects are displayed as wireframe models.</para>
        /// <para><b>Note:</b> <see cref="Godot.RenderingServer.SetDebugGenerateWireframes(bool)"/> must be called before loading any meshes for wireframes to be visible when using the Compatibility renderer.</para>
        /// </summary>
        Wireframe = 4,
        /// <summary>
        /// <para>Objects are displayed without lighting information and their textures replaced by normal mapping.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
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
        /// </summary>
        DirectionalShadowAtlas = 10,
        /// <summary>
        /// <para>Draws the scene luminance buffer (if available) in the upper left quadrant of the <see cref="Godot.Viewport"/>.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ or Mobile rendering methods.</para>
        /// </summary>
        SceneLuminance = 11,
        /// <summary>
        /// <para>Draws the screen-space ambient occlusion texture instead of the scene so that you can clearly see how it is affecting objects. In order for this display mode to work, you must have <see cref="Godot.Environment.SsaoEnabled"/> set in your <see cref="Godot.WorldEnvironment"/>.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        Ssao = 12,
        /// <summary>
        /// <para>Draws the screen-space indirect lighting texture instead of the scene so that you can clearly see how it is affecting objects. In order for this display mode to work, you must have <see cref="Godot.Environment.SsilEnabled"/> set in your <see cref="Godot.WorldEnvironment"/>.</para>
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
        /// <para>Draws the decal atlas used by <see cref="Godot.Decal"/>s and light projector textures in the upper left quadrant of the <see cref="Godot.Viewport"/>.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ or Mobile rendering methods.</para>
        /// </summary>
        DecalAtlas = 15,
        /// <summary>
        /// <para>Draws the cascades used to render signed distance field global illumination (SDFGI).</para>
        /// <para>Does nothing if the current environment's <see cref="Godot.Environment.SdfgiEnabled"/> is <see langword="false"/>.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        Sdfgi = 16,
        /// <summary>
        /// <para>Draws the probes used for signed distance field global illumination (SDFGI).</para>
        /// <para>When in the editor, left-clicking a probe will display additional bright dots that show its occlusion information. A white dot means the light is not occluded at all at the dot's position, while a red dot means the light is fully occluded. Intermediate values are possible.</para>
        /// <para>Does nothing if the current environment's <see cref="Godot.Environment.SdfgiEnabled"/> is <see langword="false"/>.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        SdfgiProbes = 17,
        /// <summary>
        /// <para>Draws the buffer used for global illumination from <see cref="Godot.VoxelGI"/> or SDFGI. Requires <see cref="Godot.VoxelGI"/> (at least one visible baked VoxelGI node) or SDFGI (<see cref="Godot.Environment.SdfgiEnabled"/>) to be enabled to have a visible effect.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        GIBuffer = 18,
        /// <summary>
        /// <para>Draws all of the objects at their highest polycount regardless of their distance from the camera. No low level of detail (LOD) is applied.</para>
        /// </summary>
        DisableLod = 19,
        /// <summary>
        /// <para>Draws the cluster used by <see cref="Godot.OmniLight3D"/> nodes to optimize light rendering.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        ClusterOmniLights = 20,
        /// <summary>
        /// <para>Draws the cluster used by <see cref="Godot.SpotLight3D"/> nodes to optimize light rendering.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        ClusterSpotLights = 21,
        /// <summary>
        /// <para>Draws the cluster used by <see cref="Godot.Decal"/> nodes to optimize decal rendering.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        ClusterDecals = 22,
        /// <summary>
        /// <para>Draws the cluster used by <see cref="Godot.ReflectionProbe"/> nodes to optimize reflection probes.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        ClusterReflectionProbes = 23,
        /// <summary>
        /// <para>Draws the buffer used for occlusion culling.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ or Mobile rendering methods.</para>
        /// </summary>
        Occluders = 24,
        /// <summary>
        /// <para>Draws vector lines over the viewport to indicate the movement of pixels between frames.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method.</para>
        /// </summary>
        MotionVectors = 25,
        /// <summary>
        /// <para>Draws the internal resolution buffer of the scene in linear colorspace before tonemapping or post-processing is applied.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ or Mobile rendering methods.</para>
        /// </summary>
        InternalBuffer = 26
    }

    public enum DefaultCanvasItemTextureFilter : long
    {
        /// <summary>
        /// <para>The texture filter reads from the nearest pixel only. This makes the texture look pixelated from up close, and grainy from a distance (due to mipmaps not being sampled).</para>
        /// </summary>
        Nearest = 0,
        /// <summary>
        /// <para>The texture filter blends between the nearest 4 pixels. This makes the texture look smooth from up close, and grainy from a distance (due to mipmaps not being sampled).</para>
        /// </summary>
        Linear = 1,
        /// <summary>
        /// <para>The texture filter blends between the nearest 4 pixels and between the nearest 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>). This makes the texture look smooth from up close, and smooth from a distance.</para>
        /// <para>Use this for non-pixel art textures that may be viewed at a low scale (e.g. due to <see cref="Godot.Camera2D"/> zoom or sprite scaling), as mipmaps are important to smooth out pixels that are smaller than on-screen pixels.</para>
        /// </summary>
        LinearWithMipmaps = 2,
        /// <summary>
        /// <para>The texture filter reads from the nearest pixel and blends between the nearest 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>). This makes the texture look pixelated from up close, and smooth from a distance.</para>
        /// <para>Use this for non-pixel art textures that may be viewed at a low scale (e.g. due to <see cref="Godot.Camera2D"/> zoom or sprite scaling), as mipmaps are important to smooth out pixels that are smaller than on-screen pixels.</para>
        /// </summary>
        NearestWithMipmaps = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Viewport.DefaultCanvasItemTextureFilter"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum DefaultCanvasItemTextureRepeat : long
    {
        /// <summary>
        /// <para>Disables textures repeating. Instead, when reading UVs outside the 0-1 range, the value will be clamped to the edge of the texture, resulting in a stretched out look at the borders of the texture.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Enables the texture to repeat when UV coordinates are outside the 0-1 range. If using one of the linear filtering modes, this can result in artifacts at the edges of a texture when the sampler filters across the edges of the texture.</para>
        /// </summary>
        Enabled = 1,
        /// <summary>
        /// <para>Flip the texture when repeating so that the edge lines up instead of abruptly changing.</para>
        /// </summary>
        Mirror = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Viewport.DefaultCanvasItemTextureRepeat"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum SdfOversizeEnum : long
    {
        /// <summary>
        /// <para>The signed distance field only covers the viewport's own rectangle.</para>
        /// </summary>
        Oversize100Percent = 0,
        /// <summary>
        /// <para>The signed distance field is expanded to cover 20% of the viewport's size around the borders.</para>
        /// </summary>
        Oversize120Percent = 1,
        /// <summary>
        /// <para>The signed distance field is expanded to cover 50% of the viewport's size around the borders.</para>
        /// </summary>
        Oversize150Percent = 2,
        /// <summary>
        /// <para>The signed distance field is expanded to cover 100% (double) of the viewport's size around the borders.</para>
        /// </summary>
        Oversize200Percent = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Viewport.SdfOversizeEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum SdfScaleEnum : long
    {
        /// <summary>
        /// <para>The signed distance field is rendered at full resolution.</para>
        /// </summary>
        Scale100Percent = 0,
        /// <summary>
        /// <para>The signed distance field is rendered at half the resolution of this viewport.</para>
        /// </summary>
        Scale50Percent = 1,
        /// <summary>
        /// <para>The signed distance field is rendered at a quarter the resolution of this viewport.</para>
        /// </summary>
        Scale25Percent = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Viewport.SdfScaleEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum VrsModeEnum : long
    {
        /// <summary>
        /// <para>Variable Rate Shading is disabled.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Variable Rate Shading uses a texture. Note, for stereoscopic use a texture atlas with a texture for each view.</para>
        /// </summary>
        Texture = 1,
        /// <summary>
        /// <para>Variable Rate Shading's texture is supplied by the primary <see cref="Godot.XRInterface"/>.</para>
        /// </summary>
        XR = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Viewport.VrsModeEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum VrsUpdateModeEnum : long
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
        /// <para>Represents the size of the <see cref="Godot.Viewport.VrsUpdateModeEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>Disable 3D rendering (but keep 2D rendering).</para>
    /// </summary>
    public bool Disable3D
    {
        get
        {
            return Is3DDisabled();
        }
        set
        {
            SetDisable3D(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport will use the primary XR interface to render XR output. When applicable this can result in a stereoscopic image and the resulting render being output to a headset.</para>
    /// </summary>
    public bool UseXR
    {
        get
        {
            return IsUsingXR();
        }
        set
        {
            SetUseXR(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport will use a unique copy of the <see cref="Godot.World3D"/> defined in <see cref="Godot.Viewport.World3D"/>.</para>
    /// </summary>
    public bool OwnWorld3D
    {
        get
        {
            return IsUsingOwnWorld3D();
        }
        set
        {
            SetUseOwnWorld3D(value);
        }
    }

    /// <summary>
    /// <para>The custom <see cref="Godot.World3D"/> which can be used as 3D environment source.</para>
    /// </summary>
    public World3D World3D
    {
        get
        {
            return GetWorld3D();
        }
        set
        {
            SetWorld3D(value);
        }
    }

    /// <summary>
    /// <para>The custom <see cref="Godot.World2D"/> which can be used as 2D environment source.</para>
    /// </summary>
    public World2D World2D
    {
        get
        {
            return GetWorld2D();
        }
        set
        {
            SetWorld2D(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport should render its background as transparent.</para>
    /// <para><b>Note:</b> Due to technical limitations, certain rendering features are disabled when a viewport has a transparent background. This currently applies to screen-space reflections, subsurface scattering, and depth of field.</para>
    /// </summary>
    public bool TransparentBg
    {
        get
        {
            return HasTransparentBackground();
        }
        set
        {
            SetTransparentBackground(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this viewport will mark incoming input events as handled by itself. If <see langword="false"/>, this is instead done by the first parent viewport that is set to handle input locally.</para>
    /// <para>A <see cref="Godot.SubViewportContainer"/> will automatically set this property to <see langword="false"/> for the <see cref="Godot.Viewport"/> contained inside of it.</para>
    /// <para>See also <see cref="Godot.Viewport.SetInputAsHandled()"/> and <see cref="Godot.Viewport.IsInputHandled()"/>.</para>
    /// </summary>
    public bool HandleInputLocally
    {
        get
        {
            return IsHandlingInputLocally();
        }
        set
        {
            SetHandleInputLocally(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.CanvasItem"/> nodes will internally snap to full pixels. Their position can still be sub-pixel, but the decimals will not have effect. This can lead to a crisper appearance at the cost of less smooth movement, especially when <see cref="Godot.Camera2D"/> smoothing is enabled.</para>
    /// </summary>
    public bool Snap2DTransformsToPixel
    {
        get
        {
            return IsSnap2DTransformsToPixelEnabled();
        }
        set
        {
            SetSnap2DTransformsToPixel(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, vertices of <see cref="Godot.CanvasItem"/> nodes will snap to full pixels. Only affects the final vertex positions, not the transforms. This can lead to a crisper appearance at the cost of less smooth movement, especially when <see cref="Godot.Camera2D"/> smoothing is enabled.</para>
    /// </summary>
    public bool Snap2DVerticesToPixel
    {
        get
        {
            return IsSnap2DVerticesToPixelEnabled();
        }
        set
        {
            SetSnap2DVerticesToPixel(value);
        }
    }

    /// <summary>
    /// <para>The multisample antialiasing mode for 2D/Canvas rendering. A higher number results in smoother edges at the cost of significantly worse performance. A value of <see cref="Godot.Viewport.Msaa.Msaa2X"/> or <see cref="Godot.Viewport.Msaa.Msaa4X"/> is best unless targeting very high-end systems. This has no effect on shader-induced aliasing or texture aliasing.</para>
    /// <para>See also <c>ProjectSettings.rendering/anti_aliasing/quality/msaa_2d</c> and <see cref="Godot.RenderingServer.ViewportSetMsaa2D(Rid, RenderingServer.ViewportMsaa)"/>.</para>
    /// </summary>
    public Viewport.Msaa Msaa2D
    {
        get
        {
            return GetMsaa2D();
        }
        set
        {
            SetMsaa2D(value);
        }
    }

    /// <summary>
    /// <para>The multisample antialiasing mode for 3D rendering. A higher number results in smoother edges at the cost of significantly worse performance. A value of <see cref="Godot.Viewport.Msaa.Msaa2X"/> or <see cref="Godot.Viewport.Msaa.Msaa4X"/> is best unless targeting very high-end systems. See also bilinear scaling 3D <see cref="Godot.Viewport.Scaling3DMode"/> for supersampling, which provides higher quality but is much more expensive. This has no effect on shader-induced aliasing or texture aliasing.</para>
    /// <para>See also <c>ProjectSettings.rendering/anti_aliasing/quality/msaa_3d</c> and <see cref="Godot.RenderingServer.ViewportSetMsaa3D(Rid, RenderingServer.ViewportMsaa)"/>.</para>
    /// </summary>
    public Viewport.Msaa Msaa3D
    {
        get
        {
            return GetMsaa3D();
        }
        set
        {
            SetMsaa3D(value);
        }
    }

    /// <summary>
    /// <para>Sets the screen-space antialiasing method used. Screen-space antialiasing works by selectively blurring edges in a post-process shader. It differs from MSAA which takes multiple coverage samples while rendering objects. Screen-space AA methods are typically faster than MSAA and will smooth out specular aliasing, but tend to make scenes appear blurry.</para>
    /// <para>See also <c>ProjectSettings.rendering/anti_aliasing/quality/screen_space_aa</c> and <see cref="Godot.RenderingServer.ViewportSetScreenSpaceAA(Rid, RenderingServer.ViewportScreenSpaceAA)"/>.</para>
    /// </summary>
    public Viewport.ScreenSpaceAAEnum ScreenSpaceAA
    {
        get
        {
            return GetScreenSpaceAA();
        }
        set
        {
            SetScreenSpaceAA(value);
        }
    }

    /// <summary>
    /// <para>Enables temporal antialiasing for this viewport. TAA works by jittering the camera and accumulating the images of the last rendered frames, motion vector rendering is used to account for camera and object motion.</para>
    /// <para><b>Note:</b> The implementation is not complete yet, some visual instances such as particles and skinned meshes may show artifacts.</para>
    /// <para>See also <c>ProjectSettings.rendering/anti_aliasing/quality/use_taa</c> and <see cref="Godot.RenderingServer.ViewportSetUseTaa(Rid, bool)"/>.</para>
    /// </summary>
    public bool UseTaa
    {
        get
        {
            return IsUsingTaa();
        }
        set
        {
            SetUseTaa(value);
        }
    }

    /// <summary>
    /// <para>When using the Mobile or Forward+ renderers, set <see cref="Godot.Viewport.UseDebanding"/> to enable or disable the debanding feature of this <see cref="Godot.Viewport"/>. If <see cref="Godot.Viewport.UseHdr2D"/> is <see langword="false"/>, 2D rendering is <i>not</i> affected by debanding unless the <see cref="Godot.Environment.BackgroundMode"/> is <see cref="Godot.Environment.BGMode.Canvas"/>. If <see cref="Godot.Viewport.UseHdr2D"/> is <see langword="true"/>, debanding will only be applied if this is the root <see cref="Godot.Viewport"/> and will affect all 2D and 3D rendering, including canvas items.</para>
    /// <para><see cref="Godot.Viewport.UseDebanding"/> has no effect when using the Compatibility rendering method. The Mobile renderer can also use material debanding, which can be set with <see cref="Godot.RenderingServer.MaterialSetUseDebanding(bool)"/> or configured with <c>ProjectSettings.rendering/anti_aliasing/quality/use_debanding</c>.</para>
    /// <para>See also <c>ProjectSettings.rendering/anti_aliasing/quality/use_debanding</c>, <see cref="Godot.RenderingServer.MaterialSetUseDebanding(bool)"/>, and <see cref="Godot.RenderingServer.ViewportSetUseDebanding(Rid, bool)"/>.</para>
    /// </summary>
    public bool UseDebanding
    {
        get
        {
            return IsUsingDebanding();
        }
        set
        {
            SetUseDebanding(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.OccluderInstance3D"/> nodes will be usable for occlusion culling in 3D for this viewport. For the root viewport, <c>ProjectSettings.rendering/occlusion_culling/use_occlusion_culling</c> must be set to <see langword="true"/> instead.</para>
    /// <para><b>Note:</b> Enabling occlusion culling has a cost on the CPU. Only enable occlusion culling if you actually plan to use it, and think whether your scene can actually benefit from occlusion culling. Large, open scenes with few or no objects blocking the view will generally not benefit much from occlusion culling. Large open scenes generally benefit more from mesh LOD and visibility ranges (<see cref="Godot.GeometryInstance3D.VisibilityRangeBegin"/> and <see cref="Godot.GeometryInstance3D.VisibilityRangeEnd"/>) compared to occlusion culling.</para>
    /// <para><b>Note:</b> Due to memory constraints, occlusion culling is not supported by default in Web export templates. It can be enabled by compiling custom Web export templates with <c>module_raycast_enabled=yes</c>.</para>
    /// </summary>
    public bool UseOcclusionCulling
    {
        get
        {
            return IsUsingOcclusionCulling();
        }
        set
        {
            SetUseOcclusionCulling(value);
        }
    }

    /// <summary>
    /// <para>The automatic LOD bias to use for meshes rendered within the <see cref="Godot.Viewport"/> (this is analogous to <see cref="Godot.ReflectionProbe.MeshLodThreshold"/>). Higher values will use less detailed versions of meshes that have LOD variations generated. If set to <c>0.0</c>, automatic LOD is disabled. Increase <see cref="Godot.Viewport.MeshLodThreshold"/> to improve performance at the cost of geometry detail.</para>
    /// <para>To control this property on the root viewport, set the <c>ProjectSettings.rendering/mesh_lod/lod_change/threshold_pixels</c> project setting.</para>
    /// <para><b>Note:</b> <see cref="Godot.Viewport.MeshLodThreshold"/> does not affect <see cref="Godot.GeometryInstance3D"/> visibility ranges (also known as "manual" LOD or hierarchical LOD).</para>
    /// </summary>
    public float MeshLodThreshold
    {
        get
        {
            return GetMeshLodThreshold();
        }
        set
        {
            SetMeshLodThreshold(value);
        }
    }

    /// <summary>
    /// <para>The overlay mode for test rendered geometry in debug purposes.</para>
    /// </summary>
    public Viewport.DebugDrawEnum DebugDraw
    {
        get
        {
            return GetDebugDraw();
        }
        set
        {
            SetDebugDraw(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, 2D rendering will use a high dynamic range (HDR) <c>RGBA16</c> format framebuffer. Additionally, 2D rendering will be performed on linear values and will be converted using the appropriate transfer function immediately before blitting to the screen (if the Viewport is attached to the screen).</para>
    /// <para>Practically speaking, this means that the end result of the Viewport will not be clamped to the <c>0-1</c> range and can be used in 3D rendering without color encoding adjustments. This allows 2D rendering to take advantage of effects requiring high dynamic range (e.g. 2D glow) as well as substantially improves the appearance of effects requiring highly detailed gradients.</para>
    /// </summary>
    public bool UseHdr2D
    {
        get
        {
            return IsUsingHdr2D();
        }
        set
        {
            SetUseHdr2D(value);
        }
    }

    /// <summary>
    /// <para>Sets scaling 3D mode. Bilinear scaling renders at different resolution to either undersample or supersample the viewport. FidelityFX Super Resolution 1.0, abbreviated to FSR, is an upscaling technology that produces high quality images at fast framerates by using a spatially aware upscaling algorithm. FSR is slightly more expensive than bilinear, but it produces significantly higher image quality. FSR should be used where possible.</para>
    /// <para>To control this property on the root viewport, set the <c>ProjectSettings.rendering/scaling_3d/mode</c> project setting.</para>
    /// </summary>
    public Viewport.Scaling3DModeEnum Scaling3DMode
    {
        get
        {
            return GetScaling3DMode();
        }
        set
        {
            SetScaling3DMode(value);
        }
    }

    /// <summary>
    /// <para>Scales the 3D render buffer based on the viewport size uses an image filter specified in <c>ProjectSettings.rendering/scaling_3d/mode</c> to scale the output image to the full viewport size. Values lower than <c>1.0</c> can be used to speed up 3D rendering at the cost of quality (undersampling). Values greater than <c>1.0</c> are only valid for bilinear mode and can be used to improve 3D rendering quality at a high performance cost (supersampling). See also <c>ProjectSettings.rendering/anti_aliasing/quality/msaa_3d</c> for multi-sample antialiasing, which is significantly cheaper but only smooths the edges of polygons.</para>
    /// <para>When using FSR upscaling, AMD recommends exposing the following values as preset options to users "Ultra Quality: 0.77", "Quality: 0.67", "Balanced: 0.59", "Performance: 0.5" instead of exposing the entire scale.</para>
    /// <para>To control this property on the root viewport, set the <c>ProjectSettings.rendering/scaling_3d/scale</c> project setting.</para>
    /// </summary>
    public float Scaling3DScale
    {
        get
        {
            return GetScaling3DScale();
        }
        set
        {
            SetScaling3DScale(value);
        }
    }

    /// <summary>
    /// <para>Affects the final texture sharpness by reading from a lower or higher mipmap (also called "texture LOD bias"). Negative values make mipmapped textures sharper but grainier when viewed at a distance, while positive values make mipmapped textures blurrier (even when up close).</para>
    /// <para>Enabling temporal antialiasing (<see cref="Godot.Viewport.UseTaa"/>) will automatically apply a <c>-0.5</c> offset to this value, while enabling FXAA (<see cref="Godot.Viewport.ScreenSpaceAA"/>) will automatically apply a <c>-0.25</c> offset to this value. If both TAA and FXAA are enabled at the same time, an offset of <c>-0.75</c> is applied to this value.</para>
    /// <para><b>Note:</b> If <see cref="Godot.Viewport.Scaling3DScale"/> is lower than <c>1.0</c> (exclusive), <see cref="Godot.Viewport.TextureMipmapBias"/> is used to adjust the automatic mipmap bias which is calculated internally based on the scale factor. The formula for this is <c>log2(scaling_3d_scale) + mipmap_bias</c>.</para>
    /// <para>To control this property on the root viewport, set the <c>ProjectSettings.rendering/textures/default_filters/texture_mipmap_bias</c> project setting.</para>
    /// </summary>
    public float TextureMipmapBias
    {
        get
        {
            return GetTextureMipmapBias();
        }
        set
        {
            SetTextureMipmapBias(value);
        }
    }

    /// <summary>
    /// <para>Sets the maximum number of samples to take when using anisotropic filtering on textures (as a power of two). A higher sample count will result in sharper textures at oblique angles, but is more expensive to compute. A value of <c>0</c> forcibly disables anisotropic filtering, even on materials where it is enabled.</para>
    /// <para>The anisotropic filtering level also affects decals and light projectors if they are configured to use anisotropic filtering. See <c>ProjectSettings.rendering/textures/decals/filter</c> and <c>ProjectSettings.rendering/textures/light_projectors/filter</c>.</para>
    /// <para><b>Note:</b> In 3D, for this setting to have an effect, set <see cref="Godot.BaseMaterial3D.TextureFilter"/> to <see cref="Godot.BaseMaterial3D.TextureFilterEnum.LinearWithMipmapsAnisotropic"/> or <see cref="Godot.BaseMaterial3D.TextureFilterEnum.NearestWithMipmapsAnisotropic"/> on materials.</para>
    /// <para><b>Note:</b> In 2D, for this setting to have an effect, set <see cref="Godot.CanvasItem.TextureFilter"/> to <see cref="Godot.CanvasItem.TextureFilterEnum.LinearWithMipmapsAnisotropic"/> or <see cref="Godot.CanvasItem.TextureFilterEnum.NearestWithMipmapsAnisotropic"/> on the <see cref="Godot.CanvasItem"/> node displaying the texture (or in <see cref="Godot.CanvasTexture"/>). However, anisotropic filtering is rarely useful in 2D, so only enable it for textures in 2D if it makes a meaningful visual difference.</para>
    /// </summary>
    public Viewport.AnisotropicFiltering AnisotropicFilteringLevel
    {
        get
        {
            return GetAnisotropicFilteringLevel();
        }
        set
        {
            SetAnisotropicFilteringLevel(value);
        }
    }

    /// <summary>
    /// <para>Determines how sharp the upscaled image will be when using the FSR upscaling mode. Sharpness halves with every whole number. Values go from 0.0 (sharpest) to 2.0. Values above 2.0 won't make a visible difference.</para>
    /// <para>To control this property on the root viewport, set the <c>ProjectSettings.rendering/scaling_3d/fsr_sharpness</c> project setting.</para>
    /// </summary>
    public float FsrSharpness
    {
        get
        {
            return GetFsrSharpness();
        }
        set
        {
            SetFsrSharpness(value);
        }
    }

    /// <summary>
    /// <para>The Variable Rate Shading (VRS) mode that is used for this viewport. Note, if hardware does not support VRS this property is ignored.</para>
    /// </summary>
    public Viewport.VrsModeEnum VrsMode
    {
        get
        {
            return GetVrsMode();
        }
        set
        {
            SetVrsMode(value);
        }
    }

    /// <summary>
    /// <para>Sets the update mode for Variable Rate Shading (VRS) for the viewport. VRS requires the input texture to be converted to the format usable by the VRS method supported by the hardware. The update mode defines how often this happens. If the GPU does not support VRS, or VRS is not enabled, this property is ignored.</para>
    /// </summary>
    public Viewport.VrsUpdateModeEnum VrsUpdateMode
    {
        get
        {
            return GetVrsUpdateMode();
        }
        set
        {
            SetVrsUpdateMode(value);
        }
    }

    /// <summary>
    /// <para>Texture to use when <see cref="Godot.Viewport.VrsMode"/> is set to <see cref="Godot.Viewport.VrsModeEnum.Texture"/>.</para>
    /// <para>The texture <i>must</i> use a lossless compression format so that colors can be matched precisely. The following VRS densities are mapped to various colors, with brighter colors representing a lower level of shading precision:</para>
    /// <para><code>
    /// - 1×1 = rgb(0, 0, 0)     - #000000
    /// - 1×2 = rgb(0, 85, 0)    - #005500
    /// - 2×1 = rgb(85, 0, 0)    - #550000
    /// - 2×2 = rgb(85, 85, 0)   - #555500
    /// - 2×4 = rgb(85, 170, 0)  - #55aa00
    /// - 4×2 = rgb(170, 85, 0)  - #aa5500
    /// - 4×4 = rgb(170, 170, 0) - #aaaa00
    /// - 4×8 = rgb(170, 255, 0) - #aaff00 - Not supported on most hardware
    /// - 8×4 = rgb(255, 170, 0) - #ffaa00 - Not supported on most hardware
    /// - 8×8 = rgb(255, 255, 0) - #ffff00 - Not supported on most hardware
    /// </code></para>
    /// </summary>
    public Texture2D VrsTexture
    {
        get
        {
            return GetVrsTexture();
        }
        set
        {
            SetVrsTexture(value);
        }
    }

    /// <summary>
    /// <para>The default filter mode used by <see cref="Godot.CanvasItem"/> nodes in this viewport.</para>
    /// </summary>
    public Viewport.DefaultCanvasItemTextureFilter CanvasItemDefaultTextureFilter
    {
        get
        {
            return GetDefaultCanvasItemTextureFilter();
        }
        set
        {
            SetDefaultCanvasItemTextureFilter(value);
        }
    }

    /// <summary>
    /// <para>The default repeat mode used by <see cref="Godot.CanvasItem"/> nodes in this viewport.</para>
    /// </summary>
    public Viewport.DefaultCanvasItemTextureRepeat CanvasItemDefaultTextureRepeat
    {
        get
        {
            return GetDefaultCanvasItemTextureRepeat();
        }
        set
        {
            SetDefaultCanvasItemTextureRepeat(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport will process 2D audio streams.</para>
    /// </summary>
    public bool AudioListenerEnable2D
    {
        get
        {
            return IsAudioListener2D();
        }
        set
        {
            SetAsAudioListener2D(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport will process 3D audio streams.</para>
    /// </summary>
    public bool AudioListenerEnable3D
    {
        get
        {
            return IsAudioListener3D();
        }
        set
        {
            SetAsAudioListener3D(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the objects rendered by viewport become subjects of mouse picking process.</para>
    /// <para><b>Note:</b> The number of simultaneously pickable objects is limited to 64 and they are selected in a non-deterministic order, which can be different in each picking process.</para>
    /// </summary>
    public bool PhysicsObjectPicking
    {
        get
        {
            return GetPhysicsObjectPicking();
        }
        set
        {
            SetPhysicsObjectPicking(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, objects receive mouse picking events sorted primarily by their <see cref="Godot.CanvasItem.ZIndex"/> and secondarily by their position in the scene tree. If <see langword="false"/>, the order is undetermined.</para>
    /// <para><b>Note:</b> This setting is disabled by default because of its potential expensive computational cost.</para>
    /// <para><b>Note:</b> Sorting happens after selecting the pickable objects. Because of the limitation of 64 simultaneously pickable objects, it is not guaranteed that the object with the highest <see cref="Godot.CanvasItem.ZIndex"/> receives the picking event.</para>
    /// </summary>
    public bool PhysicsObjectPickingSort
    {
        get
        {
            return GetPhysicsObjectPickingSort();
        }
        set
        {
            SetPhysicsObjectPickingSort(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the input_event signal will only be sent to one physics object in the mouse picking process. If you want to get the top object only, you must also enable <see cref="Godot.Viewport.PhysicsObjectPickingSort"/>.</para>
    /// <para>If <see langword="false"/>, an input_event signal will be sent to all physics objects in the mouse picking process.</para>
    /// <para>This applies to 2D CanvasItem object picking only.</para>
    /// </summary>
    public bool PhysicsObjectPickingFirstOnly
    {
        get
        {
            return GetPhysicsObjectPickingFirstOnly();
        }
        set
        {
            SetPhysicsObjectPickingFirstOnly(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the viewport will not receive input events.</para>
    /// </summary>
    public bool GuiDisableInput
    {
        get
        {
            return IsInputDisabled();
        }
        set
        {
            SetDisableInput(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the GUI controls on the viewport will lay pixel perfectly.</para>
    /// </summary>
    public bool GuiSnapControlsToPixels
    {
        get
        {
            return IsSnapControlsToPixelsEnabled();
        }
        set
        {
            SetSnapControlsToPixels(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, sub-windows (popups and dialogs) will be embedded inside application window as control-like nodes. If <see langword="false"/>, they will appear as separate windows handled by the operating system.</para>
    /// </summary>
    public bool GuiEmbedSubwindows
    {
        get
        {
            return IsEmbeddingSubwindows();
        }
        set
        {
            SetEmbeddingSubwindows(value);
        }
    }

    /// <summary>
    /// <para>The minimum distance the mouse cursor must move while pressed before a drag operation begins.</para>
    /// </summary>
    public int GuiDragThreshold
    {
        get
        {
            return GetDragThreshold();
        }
        set
        {
            SetDragThreshold(value);
        }
    }

    /// <summary>
    /// <para>Controls how much of the original viewport's size should be covered by the 2D signed distance field. This SDF can be sampled in <see cref="Godot.CanvasItem"/> shaders and is also used for <see cref="Godot.GpuParticles2D"/> collision. Higher values allow portions of occluders located outside the viewport to still be taken into account in the generated signed distance field, at the cost of performance. If you notice particles falling through <see cref="Godot.LightOccluder2D"/>s as the occluders leave the viewport, increase this setting.</para>
    /// <para>The percentage is added on each axis and on both sides. For example, with the default <see cref="Godot.Viewport.SdfOversizeEnum.Oversize120Percent"/>, the signed distance field will cover 20% of the viewport's size outside the viewport on each side (top, right, bottom, left).</para>
    /// </summary>
    public Viewport.SdfOversizeEnum SdfOversize
    {
        get
        {
            return GetSdfOversize();
        }
        set
        {
            SetSdfOversize(value);
        }
    }

    /// <summary>
    /// <para>The resolution scale to use for the 2D signed distance field. Higher values lead to a more precise and more stable signed distance field as the camera moves, at the cost of performance.</para>
    /// </summary>
    public Viewport.SdfScaleEnum SdfScale
    {
        get
        {
            return GetSdfScale();
        }
        set
        {
            SetSdfScale(value);
        }
    }

    /// <summary>
    /// <para>The shadow atlas' resolution (used for omni and spot lights). The value is rounded up to the nearest power of 2.</para>
    /// <para><b>Note:</b> If this is set to <c>0</c>, no positional shadows will be visible at all. This can improve performance significantly on low-end systems by reducing both the CPU and GPU load (as fewer draw calls are needed to draw the scene without shadows).</para>
    /// </summary>
    public int PositionalShadowAtlasSize
    {
        get
        {
            return GetPositionalShadowAtlasSize();
        }
        set
        {
            SetPositionalShadowAtlasSize(value);
        }
    }

    /// <summary>
    /// <para>Use 16 bits for the omni/spot shadow depth map. Enabling this results in shadows having less precision and may result in shadow acne, but can lead to performance improvements on some devices.</para>
    /// </summary>
    public bool PositionalShadowAtlas16Bits
    {
        get
        {
            return GetPositionalShadowAtlas16Bits();
        }
        set
        {
            SetPositionalShadowAtlas16Bits(value);
        }
    }

    /// <summary>
    /// <para>The subdivision amount of the first quadrant on the shadow atlas.</para>
    /// </summary>
    public Viewport.PositionalShadowAtlasQuadrantSubdiv PositionalShadowAtlasQuad0
    {
        get
        {
            return GetPositionalShadowAtlasQuadrantSubdiv(0);
        }
        set
        {
            SetPositionalShadowAtlasQuadrantSubdiv(0, value);
        }
    }

    /// <summary>
    /// <para>The subdivision amount of the second quadrant on the shadow atlas.</para>
    /// </summary>
    public Viewport.PositionalShadowAtlasQuadrantSubdiv PositionalShadowAtlasQuad1
    {
        get
        {
            return GetPositionalShadowAtlasQuadrantSubdiv(1);
        }
        set
        {
            SetPositionalShadowAtlasQuadrantSubdiv(1, value);
        }
    }

    /// <summary>
    /// <para>The subdivision amount of the third quadrant on the shadow atlas.</para>
    /// </summary>
    public Viewport.PositionalShadowAtlasQuadrantSubdiv PositionalShadowAtlasQuad2
    {
        get
        {
            return GetPositionalShadowAtlasQuadrantSubdiv(2);
        }
        set
        {
            SetPositionalShadowAtlasQuadrantSubdiv(2, value);
        }
    }

    /// <summary>
    /// <para>The subdivision amount of the fourth quadrant on the shadow atlas.</para>
    /// </summary>
    public Viewport.PositionalShadowAtlasQuadrantSubdiv PositionalShadowAtlasQuad3
    {
        get
        {
            return GetPositionalShadowAtlasQuadrantSubdiv(3);
        }
        set
        {
            SetPositionalShadowAtlasQuadrantSubdiv(3, value);
        }
    }

    /// <summary>
    /// <para>The canvas transform of the viewport, useful for changing the on-screen positions of all child <see cref="Godot.CanvasItem"/>s. This is relative to the global canvas transform of the viewport.</para>
    /// </summary>
    public Transform2D CanvasTransform
    {
        get
        {
            return GetCanvasTransform();
        }
        set
        {
            SetCanvasTransform(value);
        }
    }

    /// <summary>
    /// <para>The global canvas transform of the viewport. The canvas transform is relative to this.</para>
    /// </summary>
    public Transform2D GlobalCanvasTransform
    {
        get
        {
            return GetGlobalCanvasTransform();
        }
        set
        {
            SetGlobalCanvasTransform(value);
        }
    }

    /// <summary>
    /// <para>The rendering layers in which this <see cref="Godot.Viewport"/> renders <see cref="Godot.CanvasItem"/> nodes.</para>
    /// <para><b>Note:</b> A <see cref="Godot.CanvasItem"/> does not inherit its parents' visibility layers. See <see cref="Godot.CanvasItem.VisibilityLayer"/>'s description for details.</para>
    /// </summary>
    public uint CanvasCullMask
    {
        get
        {
            return GetCanvasCullMask();
        }
        set
        {
            SetCanvasCullMask(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> and one of the following conditions are true: <see cref="Godot.SubViewport.Size2DOverrideStretch"/> and <see cref="Godot.SubViewport.Size2DOverride"/> are set, <see cref="Godot.Window.ContentScaleFactor"/> is set and scaling is enabled, <see cref="Godot.Viewport.OversamplingOverride"/> is set, font and <see cref="Godot.DpiTexture"/> oversampling are enabled.</para>
    /// </summary>
    public bool Oversampling
    {
        get
        {
            return IsUsingOversampling();
        }
        set
        {
            SetUseOversampling(value);
        }
    }

    /// <summary>
    /// <para>If greater than zero, this value is used as the font oversampling factor, otherwise oversampling is equal to viewport scale.</para>
    /// </summary>
    public float OversamplingOverride
    {
        get
        {
            return GetOversamplingOverride();
        }
        set
        {
            SetOversamplingOverride(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Viewport);

    private static readonly StringName NativeName = "Viewport";

    internal Viewport() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Viewport(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Viewport(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWorld2D, 2736080068ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWorld2D(World2D world2D)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(world2D));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWorld2D, 2339128592ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public World2D GetWorld2D()
    {
        return (World2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindWorld2D, 2339128592ul);

    /// <summary>
    /// <para>Returns the first valid <see cref="Godot.World2D"/> for this viewport, searching the <see cref="Godot.Viewport.World2D"/> property of itself and any Viewport ancestor.</para>
    /// </summary>
    public World2D FindWorld2D()
    {
        return (World2D)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCanvasTransform, 2761652528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCanvasTransform(Transform2D xform)
    {
        NativeCalls.godot_icall_1_218(MethodBind3, GodotObject.GetPtr(this), &xform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvasTransform, 3814499831ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform2D GetCanvasTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalCanvasTransform, 2761652528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGlobalCanvasTransform(Transform2D xform)
    {
        NativeCalls.godot_icall_1_218(MethodBind5, GodotObject.GetPtr(this), &xform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalCanvasTransform, 3814499831ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform2D GetGlobalCanvasTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStretchTransform, 3814499831ul);

    /// <summary>
    /// <para>Returns the automatically computed 2D stretch transform, taking the <see cref="Godot.Viewport"/>'s stretch settings into account. The final value is multiplied by <see cref="Godot.Window.ContentScaleFactor"/>, but only for the root viewport. If this method is called on a <see cref="Godot.SubViewport"/> (e.g., in a scene tree with <see cref="Godot.SubViewportContainer"/> and <see cref="Godot.SubViewport"/>), the scale factor of the root window will not be applied. Using <c>Transform2D.get_scale</c> on the returned value, this can be used to compensate for scaling when zooming a <see cref="Godot.Camera2D"/> node, or to scale down a <see cref="Godot.TextureRect"/> to be pixel-perfect regardless of the automatically computed scale factor.</para>
    /// <para><b>Note:</b> Due to how pixel scaling works, the returned transform's X and Y scale may differ slightly, even when <see cref="Godot.Window.ContentScaleAspect"/> is set to a mode that preserves the pixels' aspect ratio. If <see cref="Godot.Window.ContentScaleAspect"/> is <see cref="Godot.Window.ContentScaleAspectEnum.Ignore"/>, the X and Y scale may differ <i>significantly</i>.</para>
    /// </summary>
    public Transform2D GetStretchTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFinalTransform, 3814499831ul);

    /// <summary>
    /// <para>Returns the transform from the viewport's coordinate system to the embedder's coordinate system.</para>
    /// </summary>
    public Transform2D GetFinalTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenTransform, 3814499831ul);

    /// <summary>
    /// <para>Returns the transform from the Viewport's coordinates to the screen coordinates of the containing window manager window.</para>
    /// </summary>
    public Transform2D GetScreenTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleRect, 1639390495ul);

    /// <summary>
    /// <para>Returns the visible rectangle in global screen coordinates.</para>
    /// </summary>
    public Rect2 GetVisibleRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransparentBackground, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTransparentBackground(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasTransparentBackground, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasTransparentBackground()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseHdr2D, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseHdr2D(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind13, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingHdr2D, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingHdr2D()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMsaa2D, 3330258708ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMsaa2D(Viewport.Msaa msaa)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), (int)msaa);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMsaa2D, 2542055527ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.Msaa GetMsaa2D()
    {
        return (Viewport.Msaa)NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMsaa3D, 3330258708ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMsaa3D(Viewport.Msaa msaa)
    {
        NativeCalls.godot_icall_1_38(MethodBind17, GodotObject.GetPtr(this), (int)msaa);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMsaa3D, 2542055527ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.Msaa GetMsaa3D()
    {
        return (Viewport.Msaa)NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScreenSpaceAA, 3544169389ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScreenSpaceAA(Viewport.ScreenSpaceAAEnum screenSpaceAA)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), (int)screenSpaceAA);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenSpaceAA, 1390814124ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.ScreenSpaceAAEnum GetScreenSpaceAA()
    {
        return (Viewport.ScreenSpaceAAEnum)NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseTaa, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseTaa(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind21, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingTaa, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingTaa()
    {
        return NativeCalls.godot_icall_0_15(MethodBind22, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseDebanding, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseDebanding(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind23, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingDebanding, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingDebanding()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseOcclusionCulling, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseOcclusionCulling(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind25, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingOcclusionCulling, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingOcclusionCulling()
    {
        return NativeCalls.godot_icall_0_15(MethodBind26, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugDraw, 1970246205ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDebugDraw(Viewport.DebugDrawEnum debugDraw)
    {
        NativeCalls.godot_icall_1_38(MethodBind27, GodotObject.GetPtr(this), (int)debugDraw);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDebugDraw, 579191299ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.DebugDrawEnum GetDebugDraw()
    {
        return (Viewport.DebugDrawEnum)NativeCalls.godot_icall_0_39(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseOversampling, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseOversampling(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind29, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingOversampling, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingOversampling()
    {
        return NativeCalls.godot_icall_0_15(MethodBind30, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOversamplingOverride, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOversamplingOverride(float oversampling)
    {
        NativeCalls.godot_icall_1_67(MethodBind31, GodotObject.GetPtr(this), oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOversamplingOverride, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetOversamplingOverride()
    {
        return NativeCalls.godot_icall_0_68(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOversampling, 1740695150ul);

    /// <summary>
    /// <para>Returns viewport oversampling factor.</para>
    /// </summary>
    public float GetOversampling()
    {
        return NativeCalls.godot_icall_0_68(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderInfo, 481977019ul);

    /// <summary>
    /// <para>Returns rendering statistics of the given type.</para>
    /// </summary>
    public int GetRenderInfo(Viewport.RenderInfoType type, Viewport.RenderInfo info)
    {
        return NativeCalls.godot_icall_2_73(MethodBind34, GodotObject.GetPtr(this), (int)type, (int)info);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 1746695840ul);

    /// <summary>
    /// <para>Returns the viewport's texture.</para>
    /// <para><b>Note:</b> When trying to store the current texture (e.g. in a file), it might be completely black or outdated if used too early, especially when used in e.g. <see cref="Godot.Node._Ready()"/>. To make sure the texture you get is correct, you can await <see cref="Godot.RenderingServer.FramePostDraw"/> signal.</para>
    /// <para><code>
    /// public async override void _Ready()
    /// {
    ///     await ToSignal(RenderingServer.Singleton, RenderingServer.SignalName.FramePostDraw);
    ///     var viewport = GetNode&lt;Viewport&gt;("Viewport");
    ///     viewport.GetTexture().GetImage().SavePng("user://Screenshot.png");
    /// }
    /// </code></para>
    /// <para><b>Note:</b> When <see cref="Godot.Viewport.UseHdr2D"/> is <see langword="true"/> the returned texture will be an HDR image using linear encoding.</para>
    /// </summary>
    public ViewportTexture GetTexture()
    {
        return (ViewportTexture)NativeCalls.godot_icall_0_63(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsObjectPicking, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicsObjectPicking(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind36, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsObjectPicking, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPhysicsObjectPicking()
    {
        return NativeCalls.godot_icall_0_15(MethodBind37, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsObjectPickingSort, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicsObjectPickingSort(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind38, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsObjectPickingSort, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPhysicsObjectPickingSort()
    {
        return NativeCalls.godot_icall_0_15(MethodBind39, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsObjectPickingFirstOnly, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicsObjectPickingFirstOnly(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind40, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsObjectPickingFirstOnly, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPhysicsObjectPickingFirstOnly()
    {
        return NativeCalls.godot_icall_0_15(MethodBind41, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewportRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the viewport's RID from the <see cref="Godot.RenderingServer"/>.</para>
    /// </summary>
    public Rid GetViewportRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushTextInput, 83702148ul);

    /// <summary>
    /// <para>Helper method which calls the <c>set_text()</c> method on the currently focused <see cref="Godot.Control"/>, provided that it is defined (e.g. if the focused Control is <see cref="Godot.Button"/> or <see cref="Godot.LineEdit"/>).</para>
    /// </summary>
    public void PushTextInput(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind43, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushInput, 3644664830ul);

    /// <summary>
    /// <para>Triggers the given <paramref name="event"/> in this <see cref="Godot.Viewport"/>. This can be used to pass an <see cref="Godot.InputEvent"/> between viewports, or to locally apply inputs that were sent over the network or saved to a file.</para>
    /// <para>If <paramref name="inLocalCoords"/> is <see langword="false"/>, the event's position is in the embedder's coordinates and will be converted to viewport coordinates. If <paramref name="inLocalCoords"/> is <see langword="true"/>, the event's position is in viewport coordinates.</para>
    /// <para>While this method serves a similar purpose as <see cref="Godot.Input.ParseInputEvent(InputEvent)"/>, it does not remap the specified <paramref name="event"/> based on project settings like <c>ProjectSettings.input_devices/pointing/emulate_touch_from_mouse</c>.</para>
    /// <para>Calling this method will propagate calls to child nodes for following methods in the given order:</para>
    /// <para>- <see cref="Godot.Node._Input(InputEvent)"/></para>
    /// <para>- <see cref="Godot.Control._GuiInput(InputEvent)"/> for <see cref="Godot.Control"/> nodes</para>
    /// <para>- <see cref="Godot.Node._ShortcutInput(InputEvent)"/></para>
    /// <para>- <see cref="Godot.Node._UnhandledKeyInput(InputEvent)"/></para>
    /// <para>- <see cref="Godot.Node._UnhandledInput(InputEvent)"/></para>
    /// <para>If an earlier method marks the input as handled via <see cref="Godot.Viewport.SetInputAsHandled()"/>, any later method in this list will not be called.</para>
    /// <para>If none of the methods handle the event and <see cref="Godot.Viewport.PhysicsObjectPicking"/> is <see langword="true"/>, the event is used for physics object picking.</para>
    /// </summary>
    public void PushInput(InputEvent @event, bool inLocalCoords = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind44, GodotObject.GetPtr(this), GodotObject.GetPtr(@event), inLocalCoords.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushUnhandledInput, 3644664830ul);

    /// <summary>
    /// <para>Triggers the given <paramref name="event"/> in this <see cref="Godot.Viewport"/>. This can be used to pass an <see cref="Godot.InputEvent"/> between viewports, or to locally apply inputs that were sent over the network or saved to a file.</para>
    /// <para>If <paramref name="inLocalCoords"/> is <see langword="false"/>, the event's position is in the embedder's coordinates and will be converted to viewport coordinates. If <paramref name="inLocalCoords"/> is <see langword="true"/>, the event's position is in viewport coordinates.</para>
    /// <para>Calling this method will propagate calls to child nodes for following methods in the given order:</para>
    /// <para>- <see cref="Godot.Node._ShortcutInput(InputEvent)"/></para>
    /// <para>- <see cref="Godot.Node._UnhandledKeyInput(InputEvent)"/></para>
    /// <para>- <see cref="Godot.Node._UnhandledInput(InputEvent)"/></para>
    /// <para>If an earlier method marks the input as handled via <see cref="Godot.Viewport.SetInputAsHandled()"/>, any later method in this list will not be called.</para>
    /// <para>If none of the methods handle the event and <see cref="Godot.Viewport.PhysicsObjectPicking"/> is <see langword="true"/>, the event is used for physics object picking.</para>
    /// <para><b>Note:</b> This method doesn't propagate input events to embedded <see cref="Godot.Window"/>s or <see cref="Godot.SubViewport"/>s.</para>
    /// </summary>
    [Obsolete("Use 'Godot.Viewport.PushInput(InputEvent, bool)' instead.")]
    public void PushUnhandledInput(InputEvent @event, bool inLocalCoords = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind45, GodotObject.GetPtr(this), GodotObject.GetPtr(@event), inLocalCoords.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NotifyMouseEntered, 3218959716ul);

    /// <summary>
    /// <para>Inform the Viewport that the mouse has entered its area. Use this function before sending an <see cref="Godot.InputEventMouseButton"/> or <see cref="Godot.InputEventMouseMotion"/> to the <see cref="Godot.Viewport"/> with <see cref="Godot.Viewport.PushInput(InputEvent, bool)"/>. See also <see cref="Godot.Viewport.NotifyMouseExited()"/>.</para>
    /// <para><b>Note:</b> In most cases, it is not necessary to call this function because <see cref="Godot.SubViewport"/> nodes that are children of <see cref="Godot.SubViewportContainer"/> are notified automatically. This is only necessary when interacting with viewports in non-default ways, for example as textures in <see cref="Godot.TextureRect"/> or with an <see cref="Godot.Area3D"/> that forwards input events.</para>
    /// </summary>
    public void NotifyMouseEntered()
    {
        NativeCalls.godot_icall_0_3(MethodBind46, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NotifyMouseExited, 3218959716ul);

    /// <summary>
    /// <para>Inform the Viewport that the mouse has left its area. Use this function when the node that displays the viewport notices the mouse has left the area of the displayed viewport. See also <see cref="Godot.Viewport.NotifyMouseEntered()"/>.</para>
    /// <para><b>Note:</b> In most cases, it is not necessary to call this function because <see cref="Godot.SubViewport"/> nodes that are children of <see cref="Godot.SubViewportContainer"/> are notified automatically. This is only necessary when interacting with viewports in non-default ways, for example as textures in <see cref="Godot.TextureRect"/> or with an <see cref="Godot.Area3D"/> that forwards input events.</para>
    /// </summary>
    public void NotifyMouseExited()
    {
        NativeCalls.godot_icall_0_3(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMousePosition, 3341600327ul);

    /// <summary>
    /// <para>Returns the mouse's position in this <see cref="Godot.Viewport"/> using the coordinate system of this <see cref="Godot.Viewport"/>.</para>
    /// </summary>
    public Vector2 GetMousePosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind48, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.WarpMouse, 743155724ul);

    /// <summary>
    /// <para>Moves the mouse pointer to the specified position in this <see cref="Godot.Viewport"/> using the coordinate system of this <see cref="Godot.Viewport"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.Viewport.WarpMouse(Vector2)"/> is only supported on Windows, macOS and Linux. It has no effect on Android, iOS and Web.</para>
    /// </summary>
    public unsafe void WarpMouse(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind49, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateMouseCursorState, 3218959716ul);

    /// <summary>
    /// <para>Force instantly updating the display based on the current mouse cursor position. This includes updating the mouse cursor shape and sending necessary <see cref="Godot.Control.MouseEntered"/>, <see cref="Godot.CollisionObject2D.MouseEntered"/>, <see cref="Godot.CollisionObject3D.MouseEntered"/> and <see cref="Godot.Window.MouseEntered"/> signals and their respective <c>mouse_exited</c> counterparts.</para>
    /// </summary>
    public void UpdateMouseCursorState()
    {
        NativeCalls.godot_icall_0_3(MethodBind50, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GuiCancelDrag, 3218959716ul);

    /// <summary>
    /// <para>Cancels the drag operation that was previously started through <see cref="Godot.Control._GetDragData(Vector2)"/> or forced with <see cref="Godot.Control.ForceDrag(Variant, Control)"/>.</para>
    /// </summary>
    public void GuiCancelDrag()
    {
        NativeCalls.godot_icall_0_3(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GuiGetDragData, 1214101251ul);

    /// <summary>
    /// <para>Returns the drag data from the GUI, that was previously returned by <see cref="Godot.Control._GetDragData(Vector2)"/>.</para>
    /// </summary>
    public Variant GuiGetDragData()
    {
        return NativeCalls.godot_icall_0_772(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GuiGetDragDescription, 201670096ul);

    /// <summary>
    /// <para>Returns the human-readable description of the drag data, used for assistive apps.</para>
    /// </summary>
    public string GuiGetDragDescription()
    {
        return NativeCalls.godot_icall_0_58(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GuiSetDragDescription, 83702148ul);

    /// <summary>
    /// <para>Sets the human-readable description of the drag data to <paramref name="description"/>, used for assistive apps.</para>
    /// </summary>
    public void GuiSetDragDescription(string description)
    {
        NativeCalls.godot_icall_1_57(MethodBind54, GodotObject.GetPtr(this), description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GuiIsDragging, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a drag operation is currently ongoing and where the drop action could happen in this viewport.</para>
    /// <para>Alternative to <see cref="Godot.Node.NotificationDragBegin"/> and <see cref="Godot.Node.NotificationDragEnd"/> when you prefer polling the value.</para>
    /// </summary>
    public bool GuiIsDragging()
    {
        return NativeCalls.godot_icall_0_15(MethodBind55, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GuiIsDragSuccessful, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the drag operation is successful.</para>
    /// </summary>
    public bool GuiIsDragSuccessful()
    {
        return NativeCalls.godot_icall_0_15(MethodBind56, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GuiReleaseFocus, 3218959716ul);

    /// <summary>
    /// <para>Removes the focus from the currently focused <see cref="Godot.Control"/> within this viewport. If no <see cref="Godot.Control"/> has the focus, does nothing.</para>
    /// </summary>
    public void GuiReleaseFocus()
    {
        NativeCalls.godot_icall_0_3(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GuiGetFocusOwner, 2783021301ul);

    /// <summary>
    /// <para>Returns the currently focused <see cref="Godot.Control"/> within this viewport. If no <see cref="Godot.Control"/> is focused, returns <see langword="null"/>.</para>
    /// </summary>
    public Control GuiGetFocusOwner()
    {
        return (Control)NativeCalls.godot_icall_0_53(MethodBind58, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GuiGetHoveredControl, 2783021301ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Control"/> that the mouse is currently hovering over in this viewport. If no <see cref="Godot.Control"/> has the cursor, returns <see langword="null"/>.</para>
    /// <para>Typically the leaf <see cref="Godot.Control"/> node or deepest level of the subtree which claims hover. This is very useful when used together with <see cref="Godot.Node.IsAncestorOf(Node)"/> to find if the mouse is within a control tree.</para>
    /// </summary>
    public Control GuiGetHoveredControl()
    {
        return (Control)NativeCalls.godot_icall_0_53(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableInput, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisableInput(bool disable)
    {
        NativeCalls.godot_icall_1_14(MethodBind60, GodotObject.GetPtr(this), disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInputDisabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsInputDisabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind61, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPositionalShadowAtlasSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPositionalShadowAtlasSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind62, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPositionalShadowAtlasSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPositionalShadowAtlasSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind63, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPositionalShadowAtlas16Bits, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPositionalShadowAtlas16Bits(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind64, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPositionalShadowAtlas16Bits, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPositionalShadowAtlas16Bits()
    {
        return NativeCalls.godot_icall_0_15(MethodBind65, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSnapControlsToPixels, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSnapControlsToPixels(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind66, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSnapControlsToPixelsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSnapControlsToPixelsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind67, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSnap2DTransformsToPixel, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSnap2DTransformsToPixel(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind68, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSnap2DTransformsToPixelEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSnap2DTransformsToPixelEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind69, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSnap2DVerticesToPixel, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSnap2DVerticesToPixel(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind70, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSnap2DVerticesToPixelEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSnap2DVerticesToPixelEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind71, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPositionalShadowAtlasQuadrantSubdiv, 2596956071ul);

    /// <summary>
    /// <para>Sets the number of subdivisions to use in the specified quadrant. A higher number of subdivisions allows you to have more shadows in the scene at once, but reduces the quality of the shadows. A good practice is to have quadrants with a varying number of subdivisions and to have as few subdivisions as possible.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPositionalShadowAtlasQuadrantSubdiv(int quadrant, Viewport.PositionalShadowAtlasQuadrantSubdiv subdiv)
    {
        NativeCalls.godot_icall_2_59(MethodBind72, GodotObject.GetPtr(this), quadrant, (int)subdiv);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPositionalShadowAtlasQuadrantSubdiv, 2676778355ul);

    /// <summary>
    /// <para>Returns the positional shadow atlas quadrant subdivision of the specified quadrant.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.PositionalShadowAtlasQuadrantSubdiv GetPositionalShadowAtlasQuadrantSubdiv(int quadrant)
    {
        return (Viewport.PositionalShadowAtlasQuadrantSubdiv)NativeCalls.godot_icall_1_60(MethodBind73, GodotObject.GetPtr(this), quadrant);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputAsHandled, 3218959716ul);

    /// <summary>
    /// <para>Stops the input from propagating further up the <see cref="Godot.SceneTree"/>.</para>
    /// <para><b>Note:</b> This does not affect the methods in <see cref="Godot.Input"/>, only the way events are propagated.</para>
    /// </summary>
    public void SetInputAsHandled()
    {
        NativeCalls.godot_icall_0_3(MethodBind74, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInputHandled, 36873697ul);

    /// <summary>
    /// <para>Returns whether the current <see cref="Godot.InputEvent"/> has been handled. Input events are not handled until <see cref="Godot.Viewport.SetInputAsHandled()"/> has been called during the lifetime of an <see cref="Godot.InputEvent"/>.</para>
    /// <para>This is usually done as part of input handling methods like <see cref="Godot.Node._Input(InputEvent)"/>, <see cref="Godot.Control._GuiInput(InputEvent)"/> or others, as well as in corresponding signal handlers.</para>
    /// <para>If <see cref="Godot.Viewport.HandleInputLocally"/> is set to <see langword="false"/>, this method will try finding the first parent viewport that is set to handle input locally, and return its value for <see cref="Godot.Viewport.IsInputHandled()"/> instead.</para>
    /// </summary>
    public bool IsInputHandled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind75, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandleInputLocally, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHandleInputLocally(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind76, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHandlingInputLocally, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHandlingInputLocally()
    {
        return NativeCalls.godot_icall_0_15(MethodBind77, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultCanvasItemTextureFilter, 2815160100ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultCanvasItemTextureFilter(Viewport.DefaultCanvasItemTextureFilter mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind78, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultCanvasItemTextureFilter, 896601198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.DefaultCanvasItemTextureFilter GetDefaultCanvasItemTextureFilter()
    {
        return (Viewport.DefaultCanvasItemTextureFilter)NativeCalls.godot_icall_0_39(MethodBind79, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmbeddingSubwindows, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmbeddingSubwindows(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind80, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmbeddingSubwindows, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEmbeddingSubwindows()
    {
        return NativeCalls.godot_icall_0_15(MethodBind81, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmbeddedSubwindows, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of the visible embedded <see cref="Godot.Window"/>s inside the viewport.</para>
    /// <para><b>Note:</b> <see cref="Godot.Window"/>s inside other viewports will not be listed.</para>
    /// </summary>
    public Godot.Collections.Array<Window> GetEmbeddedSubwindows()
    {
        return new Godot.Collections.Array<Window>(NativeCalls.godot_icall_0_120(MethodBind82, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragThreshold, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragThreshold(int threshold)
    {
        NativeCalls.godot_icall_1_38(MethodBind83, GodotObject.GetPtr(this), threshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragThreshold, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDragThreshold()
    {
        return NativeCalls.godot_icall_0_39(MethodBind84, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCanvasCullMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCanvasCullMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind85, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvasCullMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCanvasCullMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind86, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCanvasCullMaskBit, 300928843ul);

    /// <summary>
    /// <para>Set/clear individual bits on the rendering layer mask. This simplifies editing this <see cref="Godot.Viewport"/>'s layers.</para>
    /// </summary>
    public void SetCanvasCullMaskBit(uint layer, bool enable)
    {
        NativeCalls.godot_icall_2_269(MethodBind87, GodotObject.GetPtr(this), layer, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvasCullMaskBit, 1116898809ul);

    /// <summary>
    /// <para>Returns an individual bit on the rendering layer mask.</para>
    /// </summary>
    public bool GetCanvasCullMaskBit(uint layer)
    {
        return NativeCalls.godot_icall_1_270(MethodBind88, GodotObject.GetPtr(this), layer).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultCanvasItemTextureRepeat, 1658513413ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultCanvasItemTextureRepeat(Viewport.DefaultCanvasItemTextureRepeat mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind89, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultCanvasItemTextureRepeat, 4049774160ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.DefaultCanvasItemTextureRepeat GetDefaultCanvasItemTextureRepeat()
    {
        return (Viewport.DefaultCanvasItemTextureRepeat)NativeCalls.godot_icall_0_39(MethodBind90, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfOversize, 2574159017ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfOversize(Viewport.SdfOversizeEnum oversize)
    {
        NativeCalls.godot_icall_1_38(MethodBind91, GodotObject.GetPtr(this), (int)oversize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfOversize, 2631427510ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.SdfOversizeEnum GetSdfOversize()
    {
        return (Viewport.SdfOversizeEnum)NativeCalls.godot_icall_0_39(MethodBind92, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfScale, 1402773951ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfScale(Viewport.SdfScaleEnum scale)
    {
        NativeCalls.godot_icall_1_38(MethodBind93, GodotObject.GetPtr(this), (int)scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfScale, 3162688184ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.SdfScaleEnum GetSdfScale()
    {
        return (Viewport.SdfScaleEnum)NativeCalls.godot_icall_0_39(MethodBind94, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMeshLodThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMeshLodThreshold(float pixels)
    {
        NativeCalls.godot_icall_1_67(MethodBind95, GodotObject.GetPtr(this), pixels);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMeshLodThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMeshLodThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind96, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAsAudioListener2D, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAsAudioListener2D(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind97, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAudioListener2D, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAudioListener2D()
    {
        return NativeCalls.godot_icall_0_15(MethodBind98, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAudioListener2D, 1840977180ul);

    /// <summary>
    /// <para>Returns the currently active 2D audio listener. Returns <see langword="null"/> if there are no active 2D audio listeners, in which case the active 2D camera will be treated as listener.</para>
    /// </summary>
    public AudioListener2D GetAudioListener2D()
    {
        return (AudioListener2D)NativeCalls.godot_icall_0_53(MethodBind99, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCamera2D, 3551466917ul);

    /// <summary>
    /// <para>Returns the currently active 2D camera. Returns <see langword="null"/> if there are no active cameras.</para>
    /// <para><b>Note:</b> If called while the <i>Camera Override</i> system is active in editor, this will return the internally managed override camera. It is therefore advised to avoid caching the return value, or to check that the cached value is still a valid instance and is the current camera before use. See <c>@GlobalScope.is_instance_valid</c> and <see cref="Godot.Camera2D.IsCurrent()"/>.</para>
    /// </summary>
    public Camera2D GetCamera2D()
    {
        return (Camera2D)NativeCalls.godot_icall_0_53(MethodBind100, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWorld3D, 1400875337ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWorld3D(World3D world3D)
    {
        NativeCalls.godot_icall_1_56(MethodBind101, GodotObject.GetPtr(this), GodotObject.GetPtr(world3D));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWorld3D, 317588385ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public World3D GetWorld3D()
    {
        return (World3D)NativeCalls.godot_icall_0_63(MethodBind102, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindWorld3D, 317588385ul);

    /// <summary>
    /// <para>Returns the first valid <see cref="Godot.World3D"/> for this viewport, searching the <see cref="Godot.Viewport.World3D"/> property of itself and any Viewport ancestor.</para>
    /// </summary>
    public World3D FindWorld3D()
    {
        return (World3D)NativeCalls.godot_icall_0_63(MethodBind103, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseOwnWorld3D, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseOwnWorld3D(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind104, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingOwnWorld3D, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingOwnWorld3D()
    {
        return NativeCalls.godot_icall_0_15(MethodBind105, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAudioListener3D, 3472246991ul);

    /// <summary>
    /// <para>Returns the currently active 3D audio listener. Returns <see langword="null"/> if there are no active 3D audio listeners, in which case the active 3D camera will be treated as listener.</para>
    /// </summary>
    public AudioListener3D GetAudioListener3D()
    {
        return (AudioListener3D)NativeCalls.godot_icall_0_53(MethodBind106, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCamera3D, 2285090890ul);

    /// <summary>
    /// <para>Returns the currently active 3D camera. Returns <see langword="null"/> if there are no active cameras.</para>
    /// <para><b>Note:</b> If called while the <i>Camera Override</i> system is active in editor, this will return the internally managed override camera. It is therefore advised to avoid caching the return value, or to check that the cached value is a valid instance and is the current camera before use. See <c>@GlobalScope.is_instance_valid</c> and <see cref="Godot.Camera3D.Current"/>.</para>
    /// </summary>
    public Camera3D GetCamera3D()
    {
        return (Camera3D)NativeCalls.godot_icall_0_53(MethodBind107, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAsAudioListener3D, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAsAudioListener3D(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind108, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAudioListener3D, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAudioListener3D()
    {
        return NativeCalls.godot_icall_0_15(MethodBind109, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisable3D, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisable3D(bool disable)
    {
        NativeCalls.godot_icall_1_14(MethodBind110, GodotObject.GetPtr(this), disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Is3DDisabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Is3DDisabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind111, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseXR, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseXR(bool use)
    {
        NativeCalls.godot_icall_1_14(MethodBind112, GodotObject.GetPtr(this), use.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingXR, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingXR()
    {
        return NativeCalls.godot_icall_0_15(MethodBind113, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScaling3DMode, 1531597597ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScaling3DMode(Viewport.Scaling3DModeEnum scaling3DMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind114, GodotObject.GetPtr(this), (int)scaling3DMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScaling3DMode, 2597660574ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.Scaling3DModeEnum GetScaling3DMode()
    {
        return (Viewport.Scaling3DModeEnum)NativeCalls.godot_icall_0_39(MethodBind115, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScaling3DScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScaling3DScale(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind116, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScaling3DScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetScaling3DScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind117, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFsrSharpness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFsrSharpness(float fsrSharpness)
    {
        NativeCalls.godot_icall_1_67(MethodBind118, GodotObject.GetPtr(this), fsrSharpness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFsrSharpness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFsrSharpness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind119, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureMipmapBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureMipmapBias(float textureMipmapBias)
    {
        NativeCalls.godot_icall_1_67(MethodBind120, GodotObject.GetPtr(this), textureMipmapBias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureMipmapBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTextureMipmapBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind121, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnisotropicFilteringLevel, 3445583046ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAnisotropicFilteringLevel(Viewport.AnisotropicFiltering anisotropicFilteringLevel)
    {
        NativeCalls.godot_icall_1_38(MethodBind122, GodotObject.GetPtr(this), (int)anisotropicFilteringLevel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnisotropicFilteringLevel, 3991528932ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.AnisotropicFiltering GetAnisotropicFilteringLevel()
    {
        return (Viewport.AnisotropicFiltering)NativeCalls.godot_icall_0_39(MethodBind123, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVrsMode, 2749867817ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVrsMode(Viewport.VrsModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind124, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVrsMode, 349660525ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.VrsModeEnum GetVrsMode()
    {
        return (Viewport.VrsModeEnum)NativeCalls.godot_icall_0_39(MethodBind125, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVrsUpdateMode, 3182412319ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVrsUpdateMode(Viewport.VrsUpdateModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind126, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVrsUpdateMode, 2255951583ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Viewport.VrsUpdateModeEnum GetVrsUpdateMode()
    {
        return (Viewport.VrsUpdateModeEnum)NativeCalls.godot_icall_0_39(MethodBind127, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVrsTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVrsTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind128, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVrsTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetVrsTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind129, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the size of the viewport is changed, whether by resizing of window, or some other means.</para>
    /// </summary>
    public event Action SizeChanged
    {
        add => Connect(SignalName.SizeChanged, Callable.From(value));
        remove => Disconnect(SignalName.SizeChanged, Callable.From(value));
    }

    protected void EmitSignalSizeChanged()
    {
        EmitSignal(SignalName.SizeChanged);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Viewport.GuiFocusChanged"/> event of a <see cref="Godot.Viewport"/> class.
    /// </summary>
    public delegate void GuiFocusChangedEventHandler(Control node);

    private static void GuiFocusChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((GuiFocusChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Control>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a Control node grabs keyboard focus.</para>
    /// <para><b>Note:</b> A Control node losing focus doesn't cause this signal to be emitted.</para>
    /// </summary>
    public unsafe event GuiFocusChangedEventHandler GuiFocusChanged
    {
        add => Connect(SignalName.GuiFocusChanged, Callable.CreateWithUnsafeTrampoline(value, &GuiFocusChangedTrampoline));
        remove => Disconnect(SignalName.GuiFocusChanged, Callable.CreateWithUnsafeTrampoline(value, &GuiFocusChangedTrampoline));
    }

    protected void EmitSignalGuiFocusChanged(Control node)
    {
        EmitSignal(SignalName.GuiFocusChanged, node);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_size_changed = "SizeChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_gui_focus_changed = "GuiFocusChanged";

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
        if (signal == SignalName.SizeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_size_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.GuiFocusChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_gui_focus_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node.PropertyName
    {
        /// <summary>
        /// Cached name for the 'disable_3d' property.
        /// </summary>
        public static readonly StringName Disable3D = "disable_3d";
        /// <summary>
        /// Cached name for the 'use_xr' property.
        /// </summary>
        public static readonly StringName UseXR = "use_xr";
        /// <summary>
        /// Cached name for the 'own_world_3d' property.
        /// </summary>
        public static readonly StringName OwnWorld3D = "own_world_3d";
        /// <summary>
        /// Cached name for the 'world_3d' property.
        /// </summary>
        public static readonly StringName World3D = "world_3d";
        /// <summary>
        /// Cached name for the 'world_2d' property.
        /// </summary>
        public static readonly StringName World2D = "world_2d";
        /// <summary>
        /// Cached name for the 'transparent_bg' property.
        /// </summary>
        public static readonly StringName TransparentBg = "transparent_bg";
        /// <summary>
        /// Cached name for the 'handle_input_locally' property.
        /// </summary>
        public static readonly StringName HandleInputLocally = "handle_input_locally";
        /// <summary>
        /// Cached name for the 'snap_2d_transforms_to_pixel' property.
        /// </summary>
        public static readonly StringName Snap2DTransformsToPixel = "snap_2d_transforms_to_pixel";
        /// <summary>
        /// Cached name for the 'snap_2d_vertices_to_pixel' property.
        /// </summary>
        public static readonly StringName Snap2DVerticesToPixel = "snap_2d_vertices_to_pixel";
        /// <summary>
        /// Cached name for the 'msaa_2d' property.
        /// </summary>
        public static readonly StringName Msaa2D = "msaa_2d";
        /// <summary>
        /// Cached name for the 'msaa_3d' property.
        /// </summary>
        public static readonly StringName Msaa3D = "msaa_3d";
        /// <summary>
        /// Cached name for the 'screen_space_aa' property.
        /// </summary>
        public static readonly StringName ScreenSpaceAA = "screen_space_aa";
        /// <summary>
        /// Cached name for the 'use_taa' property.
        /// </summary>
        public static readonly StringName UseTaa = "use_taa";
        /// <summary>
        /// Cached name for the 'use_debanding' property.
        /// </summary>
        public static readonly StringName UseDebanding = "use_debanding";
        /// <summary>
        /// Cached name for the 'use_occlusion_culling' property.
        /// </summary>
        public static readonly StringName UseOcclusionCulling = "use_occlusion_culling";
        /// <summary>
        /// Cached name for the 'mesh_lod_threshold' property.
        /// </summary>
        public static readonly StringName MeshLodThreshold = "mesh_lod_threshold";
        /// <summary>
        /// Cached name for the 'debug_draw' property.
        /// </summary>
        public static readonly StringName DebugDraw = "debug_draw";
        /// <summary>
        /// Cached name for the 'use_hdr_2d' property.
        /// </summary>
        public static readonly StringName UseHdr2D = "use_hdr_2d";
        /// <summary>
        /// Cached name for the 'scaling_3d_mode' property.
        /// </summary>
        public static readonly StringName Scaling3DMode = "scaling_3d_mode";
        /// <summary>
        /// Cached name for the 'scaling_3d_scale' property.
        /// </summary>
        public static readonly StringName Scaling3DScale = "scaling_3d_scale";
        /// <summary>
        /// Cached name for the 'texture_mipmap_bias' property.
        /// </summary>
        public static readonly StringName TextureMipmapBias = "texture_mipmap_bias";
        /// <summary>
        /// Cached name for the 'anisotropic_filtering_level' property.
        /// </summary>
        public static readonly StringName AnisotropicFilteringLevel = "anisotropic_filtering_level";
        /// <summary>
        /// Cached name for the 'fsr_sharpness' property.
        /// </summary>
        public static readonly StringName FsrSharpness = "fsr_sharpness";
        /// <summary>
        /// Cached name for the 'vrs_mode' property.
        /// </summary>
        public static readonly StringName VrsMode = "vrs_mode";
        /// <summary>
        /// Cached name for the 'vrs_update_mode' property.
        /// </summary>
        public static readonly StringName VrsUpdateMode = "vrs_update_mode";
        /// <summary>
        /// Cached name for the 'vrs_texture' property.
        /// </summary>
        public static readonly StringName VrsTexture = "vrs_texture";
        /// <summary>
        /// Cached name for the 'canvas_item_default_texture_filter' property.
        /// </summary>
        public static readonly StringName CanvasItemDefaultTextureFilter = "canvas_item_default_texture_filter";
        /// <summary>
        /// Cached name for the 'canvas_item_default_texture_repeat' property.
        /// </summary>
        public static readonly StringName CanvasItemDefaultTextureRepeat = "canvas_item_default_texture_repeat";
        /// <summary>
        /// Cached name for the 'audio_listener_enable_2d' property.
        /// </summary>
        public static readonly StringName AudioListenerEnable2D = "audio_listener_enable_2d";
        /// <summary>
        /// Cached name for the 'audio_listener_enable_3d' property.
        /// </summary>
        public static readonly StringName AudioListenerEnable3D = "audio_listener_enable_3d";
        /// <summary>
        /// Cached name for the 'physics_object_picking' property.
        /// </summary>
        public static readonly StringName PhysicsObjectPicking = "physics_object_picking";
        /// <summary>
        /// Cached name for the 'physics_object_picking_sort' property.
        /// </summary>
        public static readonly StringName PhysicsObjectPickingSort = "physics_object_picking_sort";
        /// <summary>
        /// Cached name for the 'physics_object_picking_first_only' property.
        /// </summary>
        public static readonly StringName PhysicsObjectPickingFirstOnly = "physics_object_picking_first_only";
        /// <summary>
        /// Cached name for the 'gui_disable_input' property.
        /// </summary>
        public static readonly StringName GuiDisableInput = "gui_disable_input";
        /// <summary>
        /// Cached name for the 'gui_snap_controls_to_pixels' property.
        /// </summary>
        public static readonly StringName GuiSnapControlsToPixels = "gui_snap_controls_to_pixels";
        /// <summary>
        /// Cached name for the 'gui_embed_subwindows' property.
        /// </summary>
        public static readonly StringName GuiEmbedSubwindows = "gui_embed_subwindows";
        /// <summary>
        /// Cached name for the 'gui_drag_threshold' property.
        /// </summary>
        public static readonly StringName GuiDragThreshold = "gui_drag_threshold";
        /// <summary>
        /// Cached name for the 'sdf_oversize' property.
        /// </summary>
        public static readonly StringName SdfOversize = "sdf_oversize";
        /// <summary>
        /// Cached name for the 'sdf_scale' property.
        /// </summary>
        public static readonly StringName SdfScale = "sdf_scale";
        /// <summary>
        /// Cached name for the 'positional_shadow_atlas_size' property.
        /// </summary>
        public static readonly StringName PositionalShadowAtlasSize = "positional_shadow_atlas_size";
        /// <summary>
        /// Cached name for the 'positional_shadow_atlas_16_bits' property.
        /// </summary>
        public static readonly StringName PositionalShadowAtlas16Bits = "positional_shadow_atlas_16_bits";
        /// <summary>
        /// Cached name for the 'positional_shadow_atlas_quad_0' property.
        /// </summary>
        public static readonly StringName PositionalShadowAtlasQuad0 = "positional_shadow_atlas_quad_0";
        /// <summary>
        /// Cached name for the 'positional_shadow_atlas_quad_1' property.
        /// </summary>
        public static readonly StringName PositionalShadowAtlasQuad1 = "positional_shadow_atlas_quad_1";
        /// <summary>
        /// Cached name for the 'positional_shadow_atlas_quad_2' property.
        /// </summary>
        public static readonly StringName PositionalShadowAtlasQuad2 = "positional_shadow_atlas_quad_2";
        /// <summary>
        /// Cached name for the 'positional_shadow_atlas_quad_3' property.
        /// </summary>
        public static readonly StringName PositionalShadowAtlasQuad3 = "positional_shadow_atlas_quad_3";
        /// <summary>
        /// Cached name for the 'canvas_transform' property.
        /// </summary>
        public static readonly StringName CanvasTransform = "canvas_transform";
        /// <summary>
        /// Cached name for the 'global_canvas_transform' property.
        /// </summary>
        public static readonly StringName GlobalCanvasTransform = "global_canvas_transform";
        /// <summary>
        /// Cached name for the 'canvas_cull_mask' property.
        /// </summary>
        public static readonly StringName CanvasCullMask = "canvas_cull_mask";
        /// <summary>
        /// Cached name for the 'oversampling' property.
        /// </summary>
        public static readonly StringName Oversampling = "oversampling";
        /// <summary>
        /// Cached name for the 'oversampling_override' property.
        /// </summary>
        public static readonly StringName OversamplingOverride = "oversampling_override";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_world_2d' method.
        /// </summary>
        public static readonly StringName SetWorld2D = "set_world_2d";
        /// <summary>
        /// Cached name for the 'get_world_2d' method.
        /// </summary>
        public static readonly StringName GetWorld2D = "get_world_2d";
        /// <summary>
        /// Cached name for the 'find_world_2d' method.
        /// </summary>
        public static readonly StringName FindWorld2D = "find_world_2d";
        /// <summary>
        /// Cached name for the 'set_canvas_transform' method.
        /// </summary>
        public static readonly StringName SetCanvasTransform = "set_canvas_transform";
        /// <summary>
        /// Cached name for the 'get_canvas_transform' method.
        /// </summary>
        public static readonly StringName GetCanvasTransform = "get_canvas_transform";
        /// <summary>
        /// Cached name for the 'set_global_canvas_transform' method.
        /// </summary>
        public static readonly StringName SetGlobalCanvasTransform = "set_global_canvas_transform";
        /// <summary>
        /// Cached name for the 'get_global_canvas_transform' method.
        /// </summary>
        public static readonly StringName GetGlobalCanvasTransform = "get_global_canvas_transform";
        /// <summary>
        /// Cached name for the 'get_stretch_transform' method.
        /// </summary>
        public static readonly StringName GetStretchTransform = "get_stretch_transform";
        /// <summary>
        /// Cached name for the 'get_final_transform' method.
        /// </summary>
        public static readonly StringName GetFinalTransform = "get_final_transform";
        /// <summary>
        /// Cached name for the 'get_screen_transform' method.
        /// </summary>
        public static readonly StringName GetScreenTransform = "get_screen_transform";
        /// <summary>
        /// Cached name for the 'get_visible_rect' method.
        /// </summary>
        public static readonly StringName GetVisibleRect = "get_visible_rect";
        /// <summary>
        /// Cached name for the 'set_transparent_background' method.
        /// </summary>
        public static readonly StringName SetTransparentBackground = "set_transparent_background";
        /// <summary>
        /// Cached name for the 'has_transparent_background' method.
        /// </summary>
        public static readonly StringName HasTransparentBackground = "has_transparent_background";
        /// <summary>
        /// Cached name for the 'set_use_hdr_2d' method.
        /// </summary>
        public static readonly StringName SetUseHdr2D = "set_use_hdr_2d";
        /// <summary>
        /// Cached name for the 'is_using_hdr_2d' method.
        /// </summary>
        public static readonly StringName IsUsingHdr2D = "is_using_hdr_2d";
        /// <summary>
        /// Cached name for the 'set_msaa_2d' method.
        /// </summary>
        public static readonly StringName SetMsaa2D = "set_msaa_2d";
        /// <summary>
        /// Cached name for the 'get_msaa_2d' method.
        /// </summary>
        public static readonly StringName GetMsaa2D = "get_msaa_2d";
        /// <summary>
        /// Cached name for the 'set_msaa_3d' method.
        /// </summary>
        public static readonly StringName SetMsaa3D = "set_msaa_3d";
        /// <summary>
        /// Cached name for the 'get_msaa_3d' method.
        /// </summary>
        public static readonly StringName GetMsaa3D = "get_msaa_3d";
        /// <summary>
        /// Cached name for the 'set_screen_space_aa' method.
        /// </summary>
        public static readonly StringName SetScreenSpaceAA = "set_screen_space_aa";
        /// <summary>
        /// Cached name for the 'get_screen_space_aa' method.
        /// </summary>
        public static readonly StringName GetScreenSpaceAA = "get_screen_space_aa";
        /// <summary>
        /// Cached name for the 'set_use_taa' method.
        /// </summary>
        public static readonly StringName SetUseTaa = "set_use_taa";
        /// <summary>
        /// Cached name for the 'is_using_taa' method.
        /// </summary>
        public static readonly StringName IsUsingTaa = "is_using_taa";
        /// <summary>
        /// Cached name for the 'set_use_debanding' method.
        /// </summary>
        public static readonly StringName SetUseDebanding = "set_use_debanding";
        /// <summary>
        /// Cached name for the 'is_using_debanding' method.
        /// </summary>
        public static readonly StringName IsUsingDebanding = "is_using_debanding";
        /// <summary>
        /// Cached name for the 'set_use_occlusion_culling' method.
        /// </summary>
        public static readonly StringName SetUseOcclusionCulling = "set_use_occlusion_culling";
        /// <summary>
        /// Cached name for the 'is_using_occlusion_culling' method.
        /// </summary>
        public static readonly StringName IsUsingOcclusionCulling = "is_using_occlusion_culling";
        /// <summary>
        /// Cached name for the 'set_debug_draw' method.
        /// </summary>
        public static readonly StringName SetDebugDraw = "set_debug_draw";
        /// <summary>
        /// Cached name for the 'get_debug_draw' method.
        /// </summary>
        public static readonly StringName GetDebugDraw = "get_debug_draw";
        /// <summary>
        /// Cached name for the 'set_use_oversampling' method.
        /// </summary>
        public static readonly StringName SetUseOversampling = "set_use_oversampling";
        /// <summary>
        /// Cached name for the 'is_using_oversampling' method.
        /// </summary>
        public static readonly StringName IsUsingOversampling = "is_using_oversampling";
        /// <summary>
        /// Cached name for the 'set_oversampling_override' method.
        /// </summary>
        public static readonly StringName SetOversamplingOverride = "set_oversampling_override";
        /// <summary>
        /// Cached name for the 'get_oversampling_override' method.
        /// </summary>
        public static readonly StringName GetOversamplingOverride = "get_oversampling_override";
        /// <summary>
        /// Cached name for the 'get_oversampling' method.
        /// </summary>
        public static readonly StringName GetOversampling = "get_oversampling";
        /// <summary>
        /// Cached name for the 'get_render_info' method.
        /// </summary>
        public static readonly StringName GetRenderInfo = "get_render_info";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
        /// <summary>
        /// Cached name for the 'set_physics_object_picking' method.
        /// </summary>
        public static readonly StringName SetPhysicsObjectPicking = "set_physics_object_picking";
        /// <summary>
        /// Cached name for the 'get_physics_object_picking' method.
        /// </summary>
        public static readonly StringName GetPhysicsObjectPicking = "get_physics_object_picking";
        /// <summary>
        /// Cached name for the 'set_physics_object_picking_sort' method.
        /// </summary>
        public static readonly StringName SetPhysicsObjectPickingSort = "set_physics_object_picking_sort";
        /// <summary>
        /// Cached name for the 'get_physics_object_picking_sort' method.
        /// </summary>
        public static readonly StringName GetPhysicsObjectPickingSort = "get_physics_object_picking_sort";
        /// <summary>
        /// Cached name for the 'set_physics_object_picking_first_only' method.
        /// </summary>
        public static readonly StringName SetPhysicsObjectPickingFirstOnly = "set_physics_object_picking_first_only";
        /// <summary>
        /// Cached name for the 'get_physics_object_picking_first_only' method.
        /// </summary>
        public static readonly StringName GetPhysicsObjectPickingFirstOnly = "get_physics_object_picking_first_only";
        /// <summary>
        /// Cached name for the 'get_viewport_rid' method.
        /// </summary>
        public static readonly StringName GetViewportRid = "get_viewport_rid";
        /// <summary>
        /// Cached name for the 'push_text_input' method.
        /// </summary>
        public static readonly StringName PushTextInput = "push_text_input";
        /// <summary>
        /// Cached name for the 'push_input' method.
        /// </summary>
        public static readonly StringName PushInput = "push_input";
        /// <summary>
        /// Cached name for the 'push_unhandled_input' method.
        /// </summary>
        public static readonly StringName PushUnhandledInput = "push_unhandled_input";
        /// <summary>
        /// Cached name for the 'notify_mouse_entered' method.
        /// </summary>
        public static readonly StringName NotifyMouseEntered = "notify_mouse_entered";
        /// <summary>
        /// Cached name for the 'notify_mouse_exited' method.
        /// </summary>
        public static readonly StringName NotifyMouseExited = "notify_mouse_exited";
        /// <summary>
        /// Cached name for the 'get_mouse_position' method.
        /// </summary>
        public static readonly StringName GetMousePosition = "get_mouse_position";
        /// <summary>
        /// Cached name for the 'warp_mouse' method.
        /// </summary>
        public static readonly StringName WarpMouse = "warp_mouse";
        /// <summary>
        /// Cached name for the 'update_mouse_cursor_state' method.
        /// </summary>
        public static readonly StringName UpdateMouseCursorState = "update_mouse_cursor_state";
        /// <summary>
        /// Cached name for the 'gui_cancel_drag' method.
        /// </summary>
        public static readonly StringName GuiCancelDrag = "gui_cancel_drag";
        /// <summary>
        /// Cached name for the 'gui_get_drag_data' method.
        /// </summary>
        public static readonly StringName GuiGetDragData = "gui_get_drag_data";
        /// <summary>
        /// Cached name for the 'gui_get_drag_description' method.
        /// </summary>
        public static readonly StringName GuiGetDragDescription = "gui_get_drag_description";
        /// <summary>
        /// Cached name for the 'gui_set_drag_description' method.
        /// </summary>
        public static readonly StringName GuiSetDragDescription = "gui_set_drag_description";
        /// <summary>
        /// Cached name for the 'gui_is_dragging' method.
        /// </summary>
        public static readonly StringName GuiIsDragging = "gui_is_dragging";
        /// <summary>
        /// Cached name for the 'gui_is_drag_successful' method.
        /// </summary>
        public static readonly StringName GuiIsDragSuccessful = "gui_is_drag_successful";
        /// <summary>
        /// Cached name for the 'gui_release_focus' method.
        /// </summary>
        public static readonly StringName GuiReleaseFocus = "gui_release_focus";
        /// <summary>
        /// Cached name for the 'gui_get_focus_owner' method.
        /// </summary>
        public static readonly StringName GuiGetFocusOwner = "gui_get_focus_owner";
        /// <summary>
        /// Cached name for the 'gui_get_hovered_control' method.
        /// </summary>
        public static readonly StringName GuiGetHoveredControl = "gui_get_hovered_control";
        /// <summary>
        /// Cached name for the 'set_disable_input' method.
        /// </summary>
        public static readonly StringName SetDisableInput = "set_disable_input";
        /// <summary>
        /// Cached name for the 'is_input_disabled' method.
        /// </summary>
        public static readonly StringName IsInputDisabled = "is_input_disabled";
        /// <summary>
        /// Cached name for the 'set_positional_shadow_atlas_size' method.
        /// </summary>
        public static readonly StringName SetPositionalShadowAtlasSize = "set_positional_shadow_atlas_size";
        /// <summary>
        /// Cached name for the 'get_positional_shadow_atlas_size' method.
        /// </summary>
        public static readonly StringName GetPositionalShadowAtlasSize = "get_positional_shadow_atlas_size";
        /// <summary>
        /// Cached name for the 'set_positional_shadow_atlas_16_bits' method.
        /// </summary>
        public static readonly StringName SetPositionalShadowAtlas16Bits = "set_positional_shadow_atlas_16_bits";
        /// <summary>
        /// Cached name for the 'get_positional_shadow_atlas_16_bits' method.
        /// </summary>
        public static readonly StringName GetPositionalShadowAtlas16Bits = "get_positional_shadow_atlas_16_bits";
        /// <summary>
        /// Cached name for the 'set_snap_controls_to_pixels' method.
        /// </summary>
        public static readonly StringName SetSnapControlsToPixels = "set_snap_controls_to_pixels";
        /// <summary>
        /// Cached name for the 'is_snap_controls_to_pixels_enabled' method.
        /// </summary>
        public static readonly StringName IsSnapControlsToPixelsEnabled = "is_snap_controls_to_pixels_enabled";
        /// <summary>
        /// Cached name for the 'set_snap_2d_transforms_to_pixel' method.
        /// </summary>
        public static readonly StringName SetSnap2DTransformsToPixel = "set_snap_2d_transforms_to_pixel";
        /// <summary>
        /// Cached name for the 'is_snap_2d_transforms_to_pixel_enabled' method.
        /// </summary>
        public static readonly StringName IsSnap2DTransformsToPixelEnabled = "is_snap_2d_transforms_to_pixel_enabled";
        /// <summary>
        /// Cached name for the 'set_snap_2d_vertices_to_pixel' method.
        /// </summary>
        public static readonly StringName SetSnap2DVerticesToPixel = "set_snap_2d_vertices_to_pixel";
        /// <summary>
        /// Cached name for the 'is_snap_2d_vertices_to_pixel_enabled' method.
        /// </summary>
        public static readonly StringName IsSnap2DVerticesToPixelEnabled = "is_snap_2d_vertices_to_pixel_enabled";
        /// <summary>
        /// Cached name for the 'set_positional_shadow_atlas_quadrant_subdiv' method.
        /// </summary>
        public static readonly StringName SetPositionalShadowAtlasQuadrantSubdiv = "set_positional_shadow_atlas_quadrant_subdiv";
        /// <summary>
        /// Cached name for the 'get_positional_shadow_atlas_quadrant_subdiv' method.
        /// </summary>
        public static readonly StringName GetPositionalShadowAtlasQuadrantSubdiv = "get_positional_shadow_atlas_quadrant_subdiv";
        /// <summary>
        /// Cached name for the 'set_input_as_handled' method.
        /// </summary>
        public static readonly StringName SetInputAsHandled = "set_input_as_handled";
        /// <summary>
        /// Cached name for the 'is_input_handled' method.
        /// </summary>
        public static readonly StringName IsInputHandled = "is_input_handled";
        /// <summary>
        /// Cached name for the 'set_handle_input_locally' method.
        /// </summary>
        public static readonly StringName SetHandleInputLocally = "set_handle_input_locally";
        /// <summary>
        /// Cached name for the 'is_handling_input_locally' method.
        /// </summary>
        public static readonly StringName IsHandlingInputLocally = "is_handling_input_locally";
        /// <summary>
        /// Cached name for the 'set_default_canvas_item_texture_filter' method.
        /// </summary>
        public static readonly StringName SetDefaultCanvasItemTextureFilter = "set_default_canvas_item_texture_filter";
        /// <summary>
        /// Cached name for the 'get_default_canvas_item_texture_filter' method.
        /// </summary>
        public static readonly StringName GetDefaultCanvasItemTextureFilter = "get_default_canvas_item_texture_filter";
        /// <summary>
        /// Cached name for the 'set_embedding_subwindows' method.
        /// </summary>
        public static readonly StringName SetEmbeddingSubwindows = "set_embedding_subwindows";
        /// <summary>
        /// Cached name for the 'is_embedding_subwindows' method.
        /// </summary>
        public static readonly StringName IsEmbeddingSubwindows = "is_embedding_subwindows";
        /// <summary>
        /// Cached name for the 'get_embedded_subwindows' method.
        /// </summary>
        public static readonly StringName GetEmbeddedSubwindows = "get_embedded_subwindows";
        /// <summary>
        /// Cached name for the 'set_drag_threshold' method.
        /// </summary>
        public static readonly StringName SetDragThreshold = "set_drag_threshold";
        /// <summary>
        /// Cached name for the 'get_drag_threshold' method.
        /// </summary>
        public static readonly StringName GetDragThreshold = "get_drag_threshold";
        /// <summary>
        /// Cached name for the 'set_canvas_cull_mask' method.
        /// </summary>
        public static readonly StringName SetCanvasCullMask = "set_canvas_cull_mask";
        /// <summary>
        /// Cached name for the 'get_canvas_cull_mask' method.
        /// </summary>
        public static readonly StringName GetCanvasCullMask = "get_canvas_cull_mask";
        /// <summary>
        /// Cached name for the 'set_canvas_cull_mask_bit' method.
        /// </summary>
        public static readonly StringName SetCanvasCullMaskBit = "set_canvas_cull_mask_bit";
        /// <summary>
        /// Cached name for the 'get_canvas_cull_mask_bit' method.
        /// </summary>
        public static readonly StringName GetCanvasCullMaskBit = "get_canvas_cull_mask_bit";
        /// <summary>
        /// Cached name for the 'set_default_canvas_item_texture_repeat' method.
        /// </summary>
        public static readonly StringName SetDefaultCanvasItemTextureRepeat = "set_default_canvas_item_texture_repeat";
        /// <summary>
        /// Cached name for the 'get_default_canvas_item_texture_repeat' method.
        /// </summary>
        public static readonly StringName GetDefaultCanvasItemTextureRepeat = "get_default_canvas_item_texture_repeat";
        /// <summary>
        /// Cached name for the 'set_sdf_oversize' method.
        /// </summary>
        public static readonly StringName SetSdfOversize = "set_sdf_oversize";
        /// <summary>
        /// Cached name for the 'get_sdf_oversize' method.
        /// </summary>
        public static readonly StringName GetSdfOversize = "get_sdf_oversize";
        /// <summary>
        /// Cached name for the 'set_sdf_scale' method.
        /// </summary>
        public static readonly StringName SetSdfScale = "set_sdf_scale";
        /// <summary>
        /// Cached name for the 'get_sdf_scale' method.
        /// </summary>
        public static readonly StringName GetSdfScale = "get_sdf_scale";
        /// <summary>
        /// Cached name for the 'set_mesh_lod_threshold' method.
        /// </summary>
        public static readonly StringName SetMeshLodThreshold = "set_mesh_lod_threshold";
        /// <summary>
        /// Cached name for the 'get_mesh_lod_threshold' method.
        /// </summary>
        public static readonly StringName GetMeshLodThreshold = "get_mesh_lod_threshold";
        /// <summary>
        /// Cached name for the 'set_as_audio_listener_2d' method.
        /// </summary>
        public static readonly StringName SetAsAudioListener2D = "set_as_audio_listener_2d";
        /// <summary>
        /// Cached name for the 'is_audio_listener_2d' method.
        /// </summary>
        public static readonly StringName IsAudioListener2D = "is_audio_listener_2d";
        /// <summary>
        /// Cached name for the 'get_audio_listener_2d' method.
        /// </summary>
        public static readonly StringName GetAudioListener2D = "get_audio_listener_2d";
        /// <summary>
        /// Cached name for the 'get_camera_2d' method.
        /// </summary>
        public static readonly StringName GetCamera2D = "get_camera_2d";
        /// <summary>
        /// Cached name for the 'set_world_3d' method.
        /// </summary>
        public static readonly StringName SetWorld3D = "set_world_3d";
        /// <summary>
        /// Cached name for the 'get_world_3d' method.
        /// </summary>
        public static readonly StringName GetWorld3D = "get_world_3d";
        /// <summary>
        /// Cached name for the 'find_world_3d' method.
        /// </summary>
        public static readonly StringName FindWorld3D = "find_world_3d";
        /// <summary>
        /// Cached name for the 'set_use_own_world_3d' method.
        /// </summary>
        public static readonly StringName SetUseOwnWorld3D = "set_use_own_world_3d";
        /// <summary>
        /// Cached name for the 'is_using_own_world_3d' method.
        /// </summary>
        public static readonly StringName IsUsingOwnWorld3D = "is_using_own_world_3d";
        /// <summary>
        /// Cached name for the 'get_audio_listener_3d' method.
        /// </summary>
        public static readonly StringName GetAudioListener3D = "get_audio_listener_3d";
        /// <summary>
        /// Cached name for the 'get_camera_3d' method.
        /// </summary>
        public static readonly StringName GetCamera3D = "get_camera_3d";
        /// <summary>
        /// Cached name for the 'set_as_audio_listener_3d' method.
        /// </summary>
        public static readonly StringName SetAsAudioListener3D = "set_as_audio_listener_3d";
        /// <summary>
        /// Cached name for the 'is_audio_listener_3d' method.
        /// </summary>
        public static readonly StringName IsAudioListener3D = "is_audio_listener_3d";
        /// <summary>
        /// Cached name for the 'set_disable_3d' method.
        /// </summary>
        public static readonly StringName SetDisable3D = "set_disable_3d";
        /// <summary>
        /// Cached name for the 'is_3d_disabled' method.
        /// </summary>
        public static readonly StringName Is3DDisabled = "is_3d_disabled";
        /// <summary>
        /// Cached name for the 'set_use_xr' method.
        /// </summary>
        public static readonly StringName SetUseXR = "set_use_xr";
        /// <summary>
        /// Cached name for the 'is_using_xr' method.
        /// </summary>
        public static readonly StringName IsUsingXR = "is_using_xr";
        /// <summary>
        /// Cached name for the 'set_scaling_3d_mode' method.
        /// </summary>
        public static readonly StringName SetScaling3DMode = "set_scaling_3d_mode";
        /// <summary>
        /// Cached name for the 'get_scaling_3d_mode' method.
        /// </summary>
        public static readonly StringName GetScaling3DMode = "get_scaling_3d_mode";
        /// <summary>
        /// Cached name for the 'set_scaling_3d_scale' method.
        /// </summary>
        public static readonly StringName SetScaling3DScale = "set_scaling_3d_scale";
        /// <summary>
        /// Cached name for the 'get_scaling_3d_scale' method.
        /// </summary>
        public static readonly StringName GetScaling3DScale = "get_scaling_3d_scale";
        /// <summary>
        /// Cached name for the 'set_fsr_sharpness' method.
        /// </summary>
        public static readonly StringName SetFsrSharpness = "set_fsr_sharpness";
        /// <summary>
        /// Cached name for the 'get_fsr_sharpness' method.
        /// </summary>
        public static readonly StringName GetFsrSharpness = "get_fsr_sharpness";
        /// <summary>
        /// Cached name for the 'set_texture_mipmap_bias' method.
        /// </summary>
        public static readonly StringName SetTextureMipmapBias = "set_texture_mipmap_bias";
        /// <summary>
        /// Cached name for the 'get_texture_mipmap_bias' method.
        /// </summary>
        public static readonly StringName GetTextureMipmapBias = "get_texture_mipmap_bias";
        /// <summary>
        /// Cached name for the 'set_anisotropic_filtering_level' method.
        /// </summary>
        public static readonly StringName SetAnisotropicFilteringLevel = "set_anisotropic_filtering_level";
        /// <summary>
        /// Cached name for the 'get_anisotropic_filtering_level' method.
        /// </summary>
        public static readonly StringName GetAnisotropicFilteringLevel = "get_anisotropic_filtering_level";
        /// <summary>
        /// Cached name for the 'set_vrs_mode' method.
        /// </summary>
        public static readonly StringName SetVrsMode = "set_vrs_mode";
        /// <summary>
        /// Cached name for the 'get_vrs_mode' method.
        /// </summary>
        public static readonly StringName GetVrsMode = "get_vrs_mode";
        /// <summary>
        /// Cached name for the 'set_vrs_update_mode' method.
        /// </summary>
        public static readonly StringName SetVrsUpdateMode = "set_vrs_update_mode";
        /// <summary>
        /// Cached name for the 'get_vrs_update_mode' method.
        /// </summary>
        public static readonly StringName GetVrsUpdateMode = "get_vrs_update_mode";
        /// <summary>
        /// Cached name for the 'set_vrs_texture' method.
        /// </summary>
        public static readonly StringName SetVrsTexture = "set_vrs_texture";
        /// <summary>
        /// Cached name for the 'get_vrs_texture' method.
        /// </summary>
        public static readonly StringName GetVrsTexture = "get_vrs_texture";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'size_changed' signal.
        /// </summary>
        public static readonly StringName SizeChanged = "size_changed";
        /// <summary>
        /// Cached name for the 'gui_focus_changed' signal.
        /// </summary>
        public static readonly StringName GuiFocusChanged = "gui_focus_changed";
    }
}
