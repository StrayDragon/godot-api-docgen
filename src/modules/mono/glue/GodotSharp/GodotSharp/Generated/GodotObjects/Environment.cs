namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Resource for environment nodes (like <see cref="Godot.WorldEnvironment"/>) that define multiple environment operations (such as background <see cref="Godot.Sky"/> or <see cref="Godot.Color"/>, ambient light, fog, depth-of-field...). These parameters affect the final render of the scene. The order of these operations is:</para>
/// <para>- Depth of Field Blur</para>
/// <para>- Auto Exposure</para>
/// <para>- Glow</para>
/// <para>- Tonemap</para>
/// <para>- Adjustments</para>
/// </summary>
public partial class Environment : Resource
{
    public enum BGMode : long
    {
        /// <summary>
        /// <para>Clears the background using the clear color defined in <c>ProjectSettings.rendering/environment/defaults/default_clear_color</c>.</para>
        /// </summary>
        ClearColor = 0,
        /// <summary>
        /// <para>Clears the background using a custom clear color.</para>
        /// </summary>
        Color = 1,
        /// <summary>
        /// <para>Displays a user-defined sky in the background.</para>
        /// </summary>
        Sky = 2,
        /// <summary>
        /// <para>Displays a <see cref="Godot.CanvasLayer"/> in the background.</para>
        /// </summary>
        Canvas = 3,
        /// <summary>
        /// <para>Keeps on screen every pixel drawn in the background. This is the fastest background mode, but it can only be safely used in fully-interior scenes (no visible sky or sky reflections). If enabled in a scene where the background is visible, "ghost trail" artifacts will be visible when moving the camera.</para>
        /// </summary>
        Keep = 4,
        /// <summary>
        /// <para>Displays a camera feed in the background.</para>
        /// </summary>
        CameraFeed = 5,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Environment.BGMode"/> enum.</para>
        /// </summary>
        Max = 6
    }

    public enum AmbientSource : long
    {
        /// <summary>
        /// <para>Gather ambient light from whichever source is specified as the background.</para>
        /// </summary>
        Bg = 0,
        /// <summary>
        /// <para>Disable ambient light. This provides a slight performance boost over <see cref="Godot.Environment.AmbientSource.Sky"/>.</para>
        /// </summary>
        Disabled = 1,
        /// <summary>
        /// <para>Specify a specific <see cref="Godot.Color"/> for ambient light. This provides a slight performance boost over <see cref="Godot.Environment.AmbientSource.Sky"/>.</para>
        /// </summary>
        Color = 2,
        /// <summary>
        /// <para>Gather ambient light from the <see cref="Godot.Sky"/> regardless of what the background is.</para>
        /// </summary>
        Sky = 3
    }

    public enum ReflectionSource : long
    {
        /// <summary>
        /// <para>Use the background for reflections.</para>
        /// </summary>
        Bg = 0,
        /// <summary>
        /// <para>Disable reflections. This provides a slight performance boost over other options.</para>
        /// </summary>
        Disabled = 1,
        /// <summary>
        /// <para>Use the <see cref="Godot.Sky"/> for reflections regardless of what the background is.</para>
        /// </summary>
        Sky = 2
    }

    public enum ToneMapper : long
    {
        /// <summary>
        /// <para>Does not modify color data, resulting in a linear tonemapping curve which unnaturally clips bright values, causing bright lighting to look blown out. The simplest and fastest tonemapper.</para>
        /// </summary>
        Linear = 0,
        /// <summary>
        /// <para>A simple tonemapping curve that rolls off bright values to prevent clipping. This results in an image that can appear dull and low contrast. Slower than <see cref="Godot.Environment.ToneMapper.Linear"/>.</para>
        /// <para><b>Note:</b> When <see cref="Godot.Environment.TonemapWhite"/> is left at the default value of <c>1.0</c>, <see cref="Godot.Environment.ToneMapper.Reinhardt"/> produces an identical image to <see cref="Godot.Environment.ToneMapper.Linear"/>.</para>
        /// </summary>
        Reinhardt = 1,
        /// <summary>
        /// <para>Uses a film-like tonemapping curve to prevent clipping of bright values and provide better contrast than <see cref="Godot.Environment.ToneMapper.Reinhardt"/>. Slightly slower than <see cref="Godot.Environment.ToneMapper.Reinhardt"/>.</para>
        /// </summary>
        Filmic = 2,
        /// <summary>
        /// <para>Uses a high-contrast film-like tonemapping curve and desaturates bright values for a more realistic appearance. Slightly slower than <see cref="Godot.Environment.ToneMapper.Filmic"/>.</para>
        /// <para><b>Note:</b> This tonemapping operator is called "ACES Fitted" in Godot 3.x.</para>
        /// </summary>
        Aces = 3,
        /// <summary>
        /// <para>Uses an adjustable film-like tonemapping curve and desaturates bright values for a more realistic appearance. Better than other tonemappers at maintaining the hue of colors as they become brighter. The slowest tonemapping option.</para>
        /// </summary>
        Agx = 4
    }

    public enum GlowBlendModeEnum : long
    {
        /// <summary>
        /// <para>Adds the glow effect to the scene.</para>
        /// </summary>
        Additive = 0,
        /// <summary>
        /// <para>Adds the glow effect to the scene after modifying the glow influence based on the scene value; dark values will be highly influenced by glow and bright values will not be influenced by glow. This approach avoids bright values becoming overly bright from the glow effect. <see cref="Godot.Environment.TonemapWhite"/> is used to determine the maximum scene value where the glow should have no influence. When <see cref="Godot.Environment.TonemapMode"/> is set to <see cref="Godot.Environment.ToneMapper.Linear"/>, a value of <c>1.0</c> will be used as the maximum scene value.</para>
        /// </summary>
        Screen = 1,
        /// <summary>
        /// <para>Adds the glow effect to the tonemapped image after modifying the glow influence based on the image value; dark values and bright values will not be influenced by glow and mid-range values will be highly influenced by glow. This approach avoids bright values becoming overly bright from the glow effect. The glow will have the largest influence on image values of <c>0.25</c> and will have no influence when applied to image values greater than <c>1.0</c>.</para>
        /// </summary>
        Softlight = 2,
        /// <summary>
        /// <para>Replaces all pixels' color by the glow effect. This can be used to simulate a full-screen blur effect by tweaking the glow parameters to match the original image's brightness or to preview glow configuration in the editor.</para>
        /// </summary>
        Replace = 3,
        /// <summary>
        /// <para>Mixes the glow image with the scene image. Best used with <see cref="Godot.Environment.GlowBloom"/> to avoid darkening the scene.</para>
        /// </summary>
        Mix = 4
    }

    public enum FogModeEnum : long
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

    public enum SdfgiyScale : long
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

    /// <summary>
    /// <para>The background mode.</para>
    /// </summary>
    public Environment.BGMode BackgroundMode
    {
        get
        {
            return GetBackground();
        }
        set
        {
            SetBackground(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Color"/> displayed for clear areas of the scene. Only effective when using the <see cref="Godot.Environment.BGMode.Color"/> background mode.</para>
    /// </summary>
    public Color BackgroundColor
    {
        get
        {
            return GetBgColor();
        }
        set
        {
            SetBgColor(value);
        }
    }

    /// <summary>
    /// <para>Multiplier for background energy. Increase to make background brighter, decrease to make background dimmer.</para>
    /// </summary>
    public float BackgroundEnergyMultiplier
    {
        get
        {
            return GetBgEnergyMultiplier();
        }
        set
        {
            SetBgEnergyMultiplier(value);
        }
    }

    /// <summary>
    /// <para>Luminance of background measured in nits (candela per square meter). Only used when <c>ProjectSettings.rendering/lights_and_shadows/use_physical_light_units</c> is enabled. The default value is roughly equivalent to the sky at midday.</para>
    /// </summary>
    public float BackgroundIntensity
    {
        get
        {
            return GetBgIntensity();
        }
        set
        {
            SetBgIntensity(value);
        }
    }

    /// <summary>
    /// <para>The maximum layer ID to display. Only effective when using the <see cref="Godot.Environment.BGMode.Canvas"/> background mode.</para>
    /// </summary>
    public int BackgroundCanvasMaxLayer
    {
        get
        {
            return GetCanvasMaxLayer();
        }
        set
        {
            SetCanvasMaxLayer(value);
        }
    }

    /// <summary>
    /// <para>The ID of the camera feed to show in the background.</para>
    /// </summary>
    public int BackgroundCameraFeedId
    {
        get
        {
            return GetCameraFeedId();
        }
        set
        {
            SetCameraFeedId(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Sky"/> resource used for this <see cref="Godot.Environment"/>.</para>
    /// </summary>
    public Sky Sky
    {
        get
        {
            return GetSky();
        }
        set
        {
            SetSky(value);
        }
    }

    /// <summary>
    /// <para>If set to a value greater than <c>0.0</c>, overrides the field of view to use for sky rendering. If set to <c>0.0</c>, the same FOV as the current <see cref="Godot.Camera3D"/> is used for sky rendering.</para>
    /// </summary>
    public float SkyCustomFov
    {
        get
        {
            return GetSkyCustomFov();
        }
        set
        {
            SetSkyCustomFov(value);
        }
    }

    /// <summary>
    /// <para>The rotation to use for sky rendering.</para>
    /// </summary>
    public Vector3 SkyRotation
    {
        get
        {
            return GetSkyRotation();
        }
        set
        {
            SetSkyRotation(value);
        }
    }

    /// <summary>
    /// <para>The ambient light source to use for rendering materials and global illumination.</para>
    /// </summary>
    public Environment.AmbientSource AmbientLightSource
    {
        get
        {
            return GetAmbientSource();
        }
        set
        {
            SetAmbientSource(value);
        }
    }

    /// <summary>
    /// <para>The ambient light's <see cref="Godot.Color"/>. Only effective if <see cref="Godot.Environment.AmbientLightSkyContribution"/> is lower than <c>1.0</c> (exclusive).</para>
    /// </summary>
    public Color AmbientLightColor
    {
        get
        {
            return GetAmbientLightColor();
        }
        set
        {
            SetAmbientLightColor(value);
        }
    }

    /// <summary>
    /// <para>Defines the amount of light that the sky brings on the scene. A value of <c>0.0</c> means that the sky's light emission has no effect on the scene illumination, thus all ambient illumination is provided by the ambient light. On the contrary, a value of <c>1.0</c> means that <i>all</i> the light that affects the scene is provided by the sky, thus the ambient light parameter has no effect on the scene.</para>
    /// <para><b>Note:</b> <see cref="Godot.Environment.AmbientLightSkyContribution"/> is internally clamped between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
    /// </summary>
    public float AmbientLightSkyContribution
    {
        get
        {
            return GetAmbientLightSkyContribution();
        }
        set
        {
            SetAmbientLightSkyContribution(value);
        }
    }

    /// <summary>
    /// <para>The ambient light's energy. The higher the value, the stronger the light. Only effective if <see cref="Godot.Environment.AmbientLightSkyContribution"/> is lower than <c>1.0</c> (exclusive).</para>
    /// </summary>
    public float AmbientLightEnergy
    {
        get
        {
            return GetAmbientLightEnergy();
        }
        set
        {
            SetAmbientLightEnergy(value);
        }
    }

    /// <summary>
    /// <para>The reflected (specular) light source.</para>
    /// </summary>
    public Environment.ReflectionSource ReflectedLightSource
    {
        get
        {
            return GetReflectionSource();
        }
        set
        {
            SetReflectionSource(value);
        }
    }

    /// <summary>
    /// <para>The tonemapping mode to use. Tonemapping is the process that "converts" HDR values to be suitable for rendering on an LDR display. (Godot doesn't support rendering on HDR displays yet.)</para>
    /// </summary>
    public Environment.ToneMapper TonemapMode
    {
        get
        {
            return GetTonemapper();
        }
        set
        {
            SetTonemapper(value);
        }
    }

    /// <summary>
    /// <para>Adjusts the brightness of values before they are provided to the tonemapper. Higher <see cref="Godot.Environment.TonemapExposure"/> values result in a brighter image. See also <see cref="Godot.Environment.TonemapWhite"/>.</para>
    /// <para><b>Note:</b> Values provided to the tonemapper will also be multiplied by <c>2.0</c> and <c>1.8</c> for <see cref="Godot.Environment.ToneMapper.Filmic"/> and <see cref="Godot.Environment.ToneMapper.Aces"/> respectively to produce a similar apparent brightness as <see cref="Godot.Environment.ToneMapper.Linear"/>.</para>
    /// </summary>
    public float TonemapExposure
    {
        get
        {
            return GetTonemapExposure();
        }
        set
        {
            SetTonemapExposure(value);
        }
    }

    /// <summary>
    /// <para>The white reference value for tonemapping, which indicates where bright white is located in the scale of values provided to the tonemapper. For photorealistic lighting, it is recommended to set <see cref="Godot.Environment.TonemapWhite"/> to at least <c>6.0</c>. Higher values result in less blown out highlights, but may make the scene appear lower contrast. <see cref="Godot.Environment.TonemapAgxWhite"/> will be used instead when using the <see cref="Godot.Environment.ToneMapper.Agx"/> tonemapper. See also <see cref="Godot.Environment.TonemapExposure"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.Environment.TonemapWhite"/> must be set to <c>2.0</c> or lower on the Mobile renderer to produce bright images.</para>
    /// </summary>
    public float TonemapWhite
    {
        get
        {
            return GetTonemapWhite();
        }
        set
        {
            SetTonemapWhite(value);
        }
    }

    /// <summary>
    /// <para>The white reference value for tonemapping, which indicates where bright white is located in the scale of values provided to the tonemapper. For photorealistic lighting, it is recommended to set <see cref="Godot.Environment.TonemapAgxWhite"/> to at least <c>6.0</c>. Higher values result in less blown out highlights, but may make the scene appear lower contrast. <see cref="Godot.Environment.TonemapAgxWhite"/> is the same as <see cref="Godot.Environment.TonemapWhite"/>, but is only effective with the <see cref="Godot.Environment.ToneMapper.Agx"/> tonemapper. See also <see cref="Godot.Environment.TonemapExposure"/>.</para>
    /// <para><b>Note:</b> When using the Mobile renderer with <see cref="Godot.Viewport.UseHdr2D"/> disabled, <see cref="Godot.Environment.TonemapAgxWhite"/> is ignored and a white value of <c>2.0</c> will always be used instead.</para>
    /// </summary>
    public float TonemapAgxWhite
    {
        get
        {
            return GetTonemapAgxWhite();
        }
        set
        {
            SetTonemapAgxWhite(value);
        }
    }

    /// <summary>
    /// <para>Increasing <see cref="Godot.Environment.TonemapAgxContrast"/> will make dark values darker and bright values brighter. Produces a higher quality result than <see cref="Godot.Environment.AdjustmentContrast"/> without any additional performance cost, but is only available when using the <see cref="Godot.Environment.ToneMapper.Agx"/> tonemapper.</para>
    /// </summary>
    public float TonemapAgxContrast
    {
        get
        {
            return GetTonemapAgxContrast();
        }
        set
        {
            SetTonemapAgxContrast(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, screen-space reflections are enabled. Screen-space reflections are more accurate than reflections from <see cref="Godot.VoxelGI"/>s or <see cref="Godot.ReflectionProbe"/>s, but are slower and can't reflect surfaces occluded by others.</para>
    /// <para><b>Note:</b> SSR is only supported in the Forward+ rendering method, not Mobile or Compatibility.</para>
    /// <para><b>Note:</b> SSR is not supported on viewports that have a transparent background (where <see cref="Godot.Viewport.TransparentBg"/> is <see langword="true"/>).</para>
    /// </summary>
    public bool SsrEnabled
    {
        get
        {
            return IsSsrEnabled();
        }
        set
        {
            SetSsrEnabled(value);
        }
    }

    /// <summary>
    /// <para>The maximum number of steps for screen-space reflections. Higher values are slower.</para>
    /// </summary>
    public int SsrMaxSteps
    {
        get
        {
            return GetSsrMaxSteps();
        }
        set
        {
            SetSsrMaxSteps(value);
        }
    }

    /// <summary>
    /// <para>The fade-in distance for screen-space reflections. Affects the area from the reflected material to the screen-space reflection. Only positive values are valid (negative values will be clamped to <c>0.0</c>).</para>
    /// </summary>
    public float SsrFadeIn
    {
        get
        {
            return GetSsrFadeIn();
        }
        set
        {
            SetSsrFadeIn(value);
        }
    }

    /// <summary>
    /// <para>The fade-out distance for screen-space reflections. Affects the area from the screen-space reflection to the "global" reflection. Only positive values are valid (negative values will be clamped to <c>0.0</c>).</para>
    /// </summary>
    public float SsrFadeOut
    {
        get
        {
            return GetSsrFadeOut();
        }
        set
        {
            SetSsrFadeOut(value);
        }
    }

    /// <summary>
    /// <para>The depth tolerance for screen-space reflections.</para>
    /// </summary>
    public float SsrDepthTolerance
    {
        get
        {
            return GetSsrDepthTolerance();
        }
        set
        {
            SetSsrDepthTolerance(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the screen-space ambient occlusion effect is enabled. This darkens objects' corners and cavities to simulate ambient light not reaching the entire object as in real life. This works well for small, dynamic objects, but baked lighting or ambient occlusion textures will do a better job at displaying ambient occlusion on large static objects. Godot uses a form of SSAO called Adaptive Screen Space Ambient Occlusion which is itself a form of Horizon Based Ambient Occlusion.</para>
    /// <para><b>Note:</b> SSAO is only supported in the Forward+ and Compatibility rendering methods, not Mobile.</para>
    /// </summary>
    public bool SsaoEnabled
    {
        get
        {
            return IsSsaoEnabled();
        }
        set
        {
            SetSsaoEnabled(value);
        }
    }

    /// <summary>
    /// <para>The distance at which objects can occlude each other when calculating screen-space ambient occlusion. Higher values will result in occlusion over a greater distance at the cost of performance and quality.</para>
    /// </summary>
    public float SsaoRadius
    {
        get
        {
            return GetSsaoRadius();
        }
        set
        {
            SetSsaoRadius(value);
        }
    }

    /// <summary>
    /// <para>The primary screen-space ambient occlusion intensity. Acts as a multiplier for the screen-space ambient occlusion effect. A higher value results in darker occlusion.</para>
    /// </summary>
    public float SsaoIntensity
    {
        get
        {
            return GetSsaoIntensity();
        }
        set
        {
            SetSsaoIntensity(value);
        }
    }

    /// <summary>
    /// <para>The distribution of occlusion. A higher value results in darker occlusion, similar to <see cref="Godot.Environment.SsaoIntensity"/>, but with a sharper falloff.</para>
    /// </summary>
    public float SsaoPower
    {
        get
        {
            return GetSsaoPower();
        }
        set
        {
            SetSsaoPower(value);
        }
    }

    /// <summary>
    /// <para>Sets the strength of the additional level of detail for the screen-space ambient occlusion effect. A high value makes the detail pass more prominent, but it may contribute to aliasing in your final image.</para>
    /// </summary>
    public float SsaoDetail
    {
        get
        {
            return GetSsaoDetail();
        }
        set
        {
            SetSsaoDetail(value);
        }
    }

    /// <summary>
    /// <para>The threshold for considering whether a given point on a surface is occluded or not represented as an angle from the horizon mapped into the <c>0.0-1.0</c> range. A value of <c>1.0</c> results in no occlusion.</para>
    /// </summary>
    public float SsaoHorizon
    {
        get
        {
            return GetSsaoHorizon();
        }
        set
        {
            SetSsaoHorizon(value);
        }
    }

    /// <summary>
    /// <para>The amount that the screen-space ambient occlusion effect is allowed to blur over the edges of objects. Setting too high will result in aliasing around the edges of objects. Setting too low will make object edges appear blurry.</para>
    /// </summary>
    public float SsaoSharpness
    {
        get
        {
            return GetSsaoSharpness();
        }
        set
        {
            SetSsaoSharpness(value);
        }
    }

    /// <summary>
    /// <para>The screen-space ambient occlusion intensity in direct light. In real life, ambient occlusion only applies to indirect light, which means its effects can't be seen in direct light. Values higher than <c>0</c> will make the SSAO effect visible in direct light.</para>
    /// </summary>
    public float SsaoLightAffect
    {
        get
        {
            return GetSsaoDirectLightAffect();
        }
        set
        {
            SetSsaoDirectLightAffect(value);
        }
    }

    /// <summary>
    /// <para>The screen-space ambient occlusion intensity on materials that have an AO texture defined. Values higher than <c>0</c> will make the SSAO effect visible in areas darkened by AO textures.</para>
    /// </summary>
    public float SsaoAOChannelAffect
    {
        get
        {
            return GetSsaoAOChannelAffect();
        }
        set
        {
            SetSsaoAOChannelAffect(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the screen-space indirect lighting effect is enabled. Screen space indirect lighting is a form of indirect lighting that allows diffuse light to bounce between nearby objects. Screen-space indirect lighting works very similarly to screen-space ambient occlusion, in that it only affects a limited range. It is intended to be used along with a form of proper global illumination like SDFGI or <see cref="Godot.VoxelGI"/>. Screen-space indirect lighting is not affected by individual light's <see cref="Godot.Light3D.LightIndirectEnergy"/>.</para>
    /// <para><b>Note:</b> SSIL is only supported in the Forward+ rendering method, not Mobile or Compatibility.</para>
    /// </summary>
    public bool SsilEnabled
    {
        get
        {
            return IsSsilEnabled();
        }
        set
        {
            SetSsilEnabled(value);
        }
    }

    /// <summary>
    /// <para>The distance that bounced lighting can travel when using the screen space indirect lighting effect. A larger value will result in light bouncing further in a scene, but may result in under-sampling artifacts which look like long spikes surrounding light sources.</para>
    /// </summary>
    public float SsilRadius
    {
        get
        {
            return GetSsilRadius();
        }
        set
        {
            SetSsilRadius(value);
        }
    }

    /// <summary>
    /// <para>The brightness multiplier for the screen-space indirect lighting effect. A higher value will result in brighter light.</para>
    /// </summary>
    public float SsilIntensity
    {
        get
        {
            return GetSsilIntensity();
        }
        set
        {
            SetSsilIntensity(value);
        }
    }

    /// <summary>
    /// <para>The amount that the screen-space indirect lighting effect is allowed to blur over the edges of objects. Setting too high will result in aliasing around the edges of objects. Setting too low will make object edges appear blurry.</para>
    /// </summary>
    public float SsilSharpness
    {
        get
        {
            return GetSsilSharpness();
        }
        set
        {
            SetSsilSharpness(value);
        }
    }

    /// <summary>
    /// <para>Amount of normal rejection used when calculating screen-space indirect lighting. Normal rejection uses the normal of a given sample point to reject samples that are facing away from the current pixel. Normal rejection is necessary to avoid light leaking when only one side of an object is illuminated. However, normal rejection can be disabled if light leaking is desirable, such as when the scene mostly contains emissive objects that emit light from faces that cannot be seen from the camera.</para>
    /// </summary>
    public float SsilNormalRejection
    {
        get
        {
            return GetSsilNormalRejection();
        }
        set
        {
            SetSsilNormalRejection(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables signed distance field global illumination for meshes that have their <see cref="Godot.GeometryInstance3D.GIMode"/> set to <see cref="Godot.GeometryInstance3D.GIModeEnum.Static"/>. SDFGI is a real-time global illumination technique that works well with procedurally generated and user-built levels, including in situations where geometry is created during gameplay. The signed distance field is automatically generated around the camera as it moves. Dynamic lights are supported, but dynamic occluders and emissive surfaces are not.</para>
    /// <para><b>Note:</b> SDFGI is only supported in the Forward+ rendering method, not Mobile or Compatibility.</para>
    /// <para><b>Performance:</b> SDFGI is relatively demanding on the GPU and is not suited to low-end hardware such as integrated graphics (consider <see cref="Godot.LightmapGI"/> instead). To improve SDFGI performance, enable <c>ProjectSettings.rendering/global_illumination/gi/use_half_resolution</c> in the Project Settings.</para>
    /// <para><b>Note:</b> Meshes should have sufficiently thick walls to avoid light leaks (avoid one-sided walls). For interior levels, enclose your level geometry in a sufficiently large box and bridge the loops to close the mesh.</para>
    /// </summary>
    public bool SdfgiEnabled
    {
        get
        {
            return IsSdfgiEnabled();
        }
        set
        {
            SetSdfgiEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, SDFGI uses an occlusion detection approach to reduce light leaking. Occlusion may however introduce dark blotches in certain spots, which may be undesired in mostly outdoor scenes. <see cref="Godot.Environment.SdfgiUseOcclusion"/> has a performance impact and should only be enabled when needed.</para>
    /// </summary>
    public bool SdfgiUseOcclusion
    {
        get
        {
            return IsSdfgiUsingOcclusion();
        }
        set
        {
            SetSdfgiUseOcclusion(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, SDFGI takes the environment lighting into account. This should be set to <see langword="false"/> for interior scenes.</para>
    /// </summary>
    public bool SdfgiReadSkyLight
    {
        get
        {
            return IsSdfgiReadingSkyLight();
        }
        set
        {
            SetSdfgiReadSkyLight(value);
        }
    }

    /// <summary>
    /// <para>The energy multiplier applied to light every time it bounces from a surface when using SDFGI. Values greater than <c>0.0</c> will simulate multiple bounces, resulting in a more realistic appearance. Increasing <see cref="Godot.Environment.SdfgiBounceFeedback"/> generally has no performance impact. See also <see cref="Godot.Environment.SdfgiEnergy"/>.</para>
    /// <para><b>Note:</b> Values greater than <c>0.5</c> can cause infinite feedback loops and should be avoided in scenes with bright materials.</para>
    /// <para><b>Note:</b> If <see cref="Godot.Environment.SdfgiBounceFeedback"/> is <c>0.0</c>, indirect lighting will not be represented in reflections as light will only bounce one time.</para>
    /// </summary>
    public float SdfgiBounceFeedback
    {
        get
        {
            return GetSdfgiBounceFeedback();
        }
        set
        {
            SetSdfgiBounceFeedback(value);
        }
    }

    /// <summary>
    /// <para>The number of cascades to use for SDFGI (between 1 and 8). A higher number of cascades allows displaying SDFGI further away while preserving detail up close, at the cost of performance. When using SDFGI on small-scale levels, <see cref="Godot.Environment.SdfgiCascades"/> can often be decreased between <c>1</c> and <c>4</c> to improve performance.</para>
    /// </summary>
    public int SdfgiCascades
    {
        get
        {
            return GetSdfgiCascades();
        }
        set
        {
            SetSdfgiCascades(value);
        }
    }

    /// <summary>
    /// <para>The cell size to use for the closest SDFGI cascade (in 3D units). Lower values allow SDFGI to be more precise up close, at the cost of making SDFGI updates more demanding. This can cause stuttering when the camera moves fast. Higher values allow SDFGI to cover more ground, while also reducing the performance impact of SDFGI updates.</para>
    /// <para><b>Note:</b> This property is linked to <see cref="Godot.Environment.SdfgiMaxDistance"/> and <see cref="Godot.Environment.SdfgiCascade0Distance"/>. Changing its value will automatically change those properties as well.</para>
    /// </summary>
    public float SdfgiMinCellSize
    {
        get
        {
            return GetSdfgiMinCellSize();
        }
        set
        {
            SetSdfgiMinCellSize(value);
        }
    }

    /// <summary>
    /// <para><b>Note:</b> This property is linked to <see cref="Godot.Environment.SdfgiMinCellSize"/> and <see cref="Godot.Environment.SdfgiMaxDistance"/>. Changing its value will automatically change those properties as well.</para>
    /// </summary>
    public float SdfgiCascade0Distance
    {
        get
        {
            return GetSdfgiCascade0Distance();
        }
        set
        {
            SetSdfgiCascade0Distance(value);
        }
    }

    /// <summary>
    /// <para>The maximum distance at which SDFGI is visible. Beyond this distance, environment lighting or other sources of GI such as <see cref="Godot.ReflectionProbe"/> will be used as a fallback.</para>
    /// <para><b>Note:</b> This property is linked to <see cref="Godot.Environment.SdfgiMinCellSize"/> and <see cref="Godot.Environment.SdfgiCascade0Distance"/>. Changing its value will automatically change those properties as well.</para>
    /// </summary>
    public float SdfgiMaxDistance
    {
        get
        {
            return GetSdfgiMaxDistance();
        }
        set
        {
            SetSdfgiMaxDistance(value);
        }
    }

    /// <summary>
    /// <para>The Y scale to use for SDFGI cells. Lower values will result in SDFGI cells being packed together more closely on the Y axis. This is used to balance between quality and covering a lot of vertical ground. <see cref="Godot.Environment.SdfgiYScale"/> should be set depending on how vertical your scene is (and how fast your camera may move on the Y axis).</para>
    /// </summary>
    public Environment.SdfgiyScale SdfgiYScale
    {
        get
        {
            return GetSdfgiYScale();
        }
        set
        {
            SetSdfgiYScale(value);
        }
    }

    /// <summary>
    /// <para>The energy multiplier to use for SDFGI. Higher values will result in brighter indirect lighting and reflections. See also <see cref="Godot.Environment.SdfgiBounceFeedback"/>.</para>
    /// </summary>
    public float SdfgiEnergy
    {
        get
        {
            return GetSdfgiEnergy();
        }
        set
        {
            SetSdfgiEnergy(value);
        }
    }

    /// <summary>
    /// <para>The normal bias to use for SDFGI probes. Increasing this value can reduce visible streaking artifacts on sloped surfaces, at the cost of increased light leaking.</para>
    /// </summary>
    public float SdfgiNormalBias
    {
        get
        {
            return GetSdfgiNormalBias();
        }
        set
        {
            SetSdfgiNormalBias(value);
        }
    }

    /// <summary>
    /// <para>The constant bias to use for SDFGI probes. Increasing this value can reduce visible streaking artifacts on sloped surfaces, at the cost of increased light leaking.</para>
    /// </summary>
    public float SdfgiProbeBias
    {
        get
        {
            return GetSdfgiProbeBias();
        }
        set
        {
            SetSdfgiProbeBias(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the glow effect is enabled. This simulates real world atmosphere and eye/camera behavior by causing bright pixels to bleed onto surrounding pixels.</para>
    /// <para><b>Note:</b> When using the Mobile rendering method, glow looks different due to the lower dynamic range available in the Mobile rendering method.</para>
    /// <para><b>Note:</b> When using the Compatibility rendering method, glow uses a different implementation with some properties being unavailable and hidden from the inspector: <c>glow_levels/*</c>, <see cref="Godot.Environment.GlowNormalized"/>, <see cref="Godot.Environment.GlowStrength"/>, <see cref="Godot.Environment.GlowBlendMode"/>, <see cref="Godot.Environment.GlowMix"/>, <see cref="Godot.Environment.GlowMap"/>, and <see cref="Godot.Environment.GlowMapStrength"/>. This implementation is optimized to run on low-end devices and is less flexible as a result.</para>
    /// </summary>
    public bool GlowEnabled
    {
        get
        {
            return IsGlowEnabled();
        }
        set
        {
            SetGlowEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, glow levels will be normalized so that summed together their intensities equal <c>1.0</c>.</para>
    /// <para><b>Note:</b> <see cref="Godot.Environment.GlowNormalized"/> has no effect when using the Compatibility rendering method, due to this rendering method using a simpler glow implementation optimized for low-end devices.</para>
    /// </summary>
    public bool GlowNormalized
    {
        get
        {
            return IsGlowNormalized();
        }
        set
        {
            SetGlowNormalized(value);
        }
    }

    /// <summary>
    /// <para>The overall brightness multiplier that is applied to the glow effect just before it is blended with the scene. When using the Mobile rendering method (which only supports a lower dynamic range up to <c>2.0</c>), this should be increased to <c>1.5</c> to compensate.</para>
    /// </summary>
    public float GlowIntensity
    {
        get
        {
            return GetGlowIntensity();
        }
        set
        {
            SetGlowIntensity(value);
        }
    }

    /// <summary>
    /// <para>The strength that is used when blurring across the screen to generate the glow effect. This affects the distance and intensity of the blur. When using the Mobile rendering method, this should be increased to compensate for the lower dynamic range.</para>
    /// <para><b>Note:</b> <see cref="Godot.Environment.GlowStrength"/> has no effect when using the Compatibility rendering method, due to this rendering method using a simpler glow implementation optimized for low-end devices.</para>
    /// </summary>
    public float GlowStrength
    {
        get
        {
            return GetGlowStrength();
        }
        set
        {
            SetGlowStrength(value);
        }
    }

    /// <summary>
    /// <para>When using the <see cref="Godot.Environment.GlowBlendModeEnum.Mix"/> <see cref="Godot.Environment.GlowBlendMode"/>, this controls how much the source image is blended with the glow layer. A value of <c>0.0</c> makes the glow rendering invisible, while a value of <c>1.0</c> is equivalent to <see cref="Godot.Environment.GlowBlendModeEnum.Replace"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.Environment.GlowMix"/> has no effect when using the Compatibility rendering method, due to this rendering method using a simpler glow implementation optimized for low-end devices.</para>
    /// </summary>
    public float GlowMix
    {
        get
        {
            return GetGlowMix();
        }
        set
        {
            SetGlowMix(value);
        }
    }

    /// <summary>
    /// <para>The bloom's intensity. If set to a value higher than <c>0</c>, this will make glow visible in areas darker than the <see cref="Godot.Environment.GlowHdrThreshold"/>.</para>
    /// </summary>
    public float GlowBloom
    {
        get
        {
            return GetGlowBloom();
        }
        set
        {
            SetGlowBloom(value);
        }
    }

    /// <summary>
    /// <para>The glow blending mode.</para>
    /// <para><b>Note:</b> The Compatibility renderer always uses <see cref="Godot.Environment.GlowBlendModeEnum.Screen"/> and <see cref="Godot.Environment.GlowBlendMode"/> will have no effect.</para>
    /// </summary>
    public Environment.GlowBlendModeEnum GlowBlendMode
    {
        get
        {
            return GetGlowBlendMode();
        }
        set
        {
            SetGlowBlendMode(value);
        }
    }

    /// <summary>
    /// <para>The lower threshold of the HDR glow. When using the Mobile rendering method (which only supports a lower dynamic range up to <c>2.0</c>), this may need to be below <c>1.0</c> for glow to be visible. A value of <c>0.9</c> works well in this case. This value also needs to be decreased below <c>1.0</c> when using glow in 2D, as 2D rendering is performed in SDR.</para>
    /// </summary>
    public float GlowHdrThreshold
    {
        get
        {
            return GetGlowHdrBleedThreshold();
        }
        set
        {
            SetGlowHdrBleedThreshold(value);
        }
    }

    /// <summary>
    /// <para>Smooths the transition between values that are below and above <see cref="Godot.Environment.GlowHdrThreshold"/> by reducing the amount of glow generated by values that are close to <see cref="Godot.Environment.GlowHdrThreshold"/>. Values above <c>glow_hdr_threshold + glow_hdr_scale</c> will not have glow reduced in this way.</para>
    /// </summary>
    public float GlowHdrScale
    {
        get
        {
            return GetGlowHdrBleedScale();
        }
        set
        {
            SetGlowHdrBleedScale(value);
        }
    }

    /// <summary>
    /// <para>The higher threshold of the HDR glow. Areas brighter than this threshold will be clamped for the purposes of the glow effect.</para>
    /// </summary>
    public float GlowHdrLuminanceCap
    {
        get
        {
            return GetGlowHdrLuminanceCap();
        }
        set
        {
            SetGlowHdrLuminanceCap(value);
        }
    }

    /// <summary>
    /// <para>How strong of an influence the <see cref="Godot.Environment.GlowMap"/> should have on the overall glow effect. A strength of <c>0.0</c> means the glow map has no influence, while a strength of <c>1.0</c> means the glow map has full influence.</para>
    /// <para><b>Note:</b> If the glow map has black areas, a value of <c>1.0</c> can also turn off the glow effect entirely in specific areas of the screen.</para>
    /// <para><b>Note:</b> <see cref="Godot.Environment.GlowMapStrength"/> has no effect when using the Compatibility rendering method, due to this rendering method using a simpler glow implementation optimized for low-end devices.</para>
    /// </summary>
    public float GlowMapStrength
    {
        get
        {
            return GetGlowMapStrength();
        }
        set
        {
            SetGlowMapStrength(value);
        }
    }

    /// <summary>
    /// <para>The texture that should be used as a glow map to <i>multiply</i> the resulting glow color according to <see cref="Godot.Environment.GlowMapStrength"/>. This can be used to create a "lens dirt" effect. The texture's RGB color channels are used for modulation, but the alpha channel is ignored.</para>
    /// <para><b>Note:</b> The texture will be stretched to fit the screen. Therefore, it's recommended to use a texture with an aspect ratio that matches your project's base aspect ratio (typically 16:9).</para>
    /// <para><b>Note:</b> <see cref="Godot.Environment.GlowMap"/> has no effect when using the Compatibility rendering method, due to this rendering method using a simpler glow implementation optimized for low-end devices.</para>
    /// </summary>
    public Texture GlowMap
    {
        get
        {
            return GetGlowMap();
        }
        set
        {
            SetGlowMap(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, fog effects are enabled.</para>
    /// </summary>
    public bool FogEnabled
    {
        get
        {
            return IsFogEnabled();
        }
        set
        {
            SetFogEnabled(value);
        }
    }

    /// <summary>
    /// <para>The fog mode.</para>
    /// </summary>
    public Environment.FogModeEnum FogMode
    {
        get
        {
            return GetFogMode();
        }
        set
        {
            SetFogMode(value);
        }
    }

    /// <summary>
    /// <para>The fog's color.</para>
    /// </summary>
    public Color FogLightColor
    {
        get
        {
            return GetFogLightColor();
        }
        set
        {
            SetFogLightColor(value);
        }
    }

    /// <summary>
    /// <para>The fog's brightness. Higher values result in brighter fog.</para>
    /// </summary>
    public float FogLightEnergy
    {
        get
        {
            return GetFogLightEnergy();
        }
        set
        {
            SetFogLightEnergy(value);
        }
    }

    /// <summary>
    /// <para>If set above <c>0.0</c>, renders the scene's directional light(s) in the fog color depending on the view angle. This can be used to give the impression that the sun is "piercing" through the fog.</para>
    /// </summary>
    public float FogSunScatter
    {
        get
        {
            return GetFogSunScatter();
        }
        set
        {
            SetFogSunScatter(value);
        }
    }

    /// <summary>
    /// <para>The fog density to be used. This is demonstrated in different ways depending on the <see cref="Godot.Environment.FogMode"/> mode chosen:</para>
    /// <para><b>Exponential Fog Mode:</b> Higher values result in denser fog. The fog rendering is exponential like in real life.</para>
    /// <para><b>Depth Fog mode:</b> The maximum intensity of the deep fog, effect will appear in the distance (relative to the camera). At <c>1.0</c> the fog will fully obscure the scene, at <c>0.0</c> the fog will not be visible.</para>
    /// </summary>
    public float FogDensity
    {
        get
        {
            return GetFogDensity();
        }
        set
        {
            SetFogDensity(value);
        }
    }

    /// <summary>
    /// <para>If set above <c>0.0</c> (exclusive), blends between the fog's color and the color of the background <see cref="Godot.Sky"/>, as read from the radiance cubemap. This has a small performance cost when set above <c>0.0</c>. Must have <see cref="Godot.Environment.BackgroundMode"/> set to <see cref="Godot.Environment.BGMode.Sky"/>.</para>
    /// <para>This is useful to simulate <a href="https://en.wikipedia.org/wiki/Aerial_perspective">aerial perspective</a> in large scenes with low density fog. However, it is not very useful for high-density fog, as the sky will shine through. When set to <c>1.0</c>, the fog color comes completely from the <see cref="Godot.Sky"/>. If set to <c>0.0</c>, aerial perspective is disabled.</para>
    /// <para>Notice that this does not sample the <see cref="Godot.Sky"/> directly, but rather the radiance cubemap. The cubemap is sampled at a mipmap level depending on the depth of the rendered pixel; the farther away, the higher the resolution of the sampled mipmap. This results in the actual color being a blurred version of the sky, with more blur closer to the camera. The highest mipmap resolution is used at a depth of <see cref="Godot.Camera3D.Far"/>.</para>
    /// </summary>
    public float FogAerialPerspective
    {
        get
        {
            return GetFogAerialPerspective();
        }
        set
        {
            SetFogAerialPerspective(value);
        }
    }

    /// <summary>
    /// <para>The factor to use when affecting the sky with non-volumetric fog. <c>1.0</c> means that fog can fully obscure the sky. Lower values reduce the impact of fog on sky rendering, with <c>0.0</c> not affecting sky rendering at all.</para>
    /// <para><b>Note:</b> <see cref="Godot.Environment.FogSkyAffect"/> has no visual effect if <see cref="Godot.Environment.FogAerialPerspective"/> is <c>1.0</c>.</para>
    /// </summary>
    public float FogSkyAffect
    {
        get
        {
            return GetFogSkyAffect();
        }
        set
        {
            SetFogSkyAffect(value);
        }
    }

    /// <summary>
    /// <para>The height at which the height fog effect begins.</para>
    /// </summary>
    public float FogHeight
    {
        get
        {
            return GetFogHeight();
        }
        set
        {
            SetFogHeight(value);
        }
    }

    /// <summary>
    /// <para>The density used to increase fog as height decreases. To make fog increase as height increases, use a negative value.</para>
    /// </summary>
    public float FogHeightDensity
    {
        get
        {
            return GetFogHeightDensity();
        }
        set
        {
            SetFogHeightDensity(value);
        }
    }

    /// <summary>
    /// <para>The fog depth's intensity curve. A number of presets are available in the Inspector by right-clicking the curve. Only available when <see cref="Godot.Environment.FogMode"/> is set to <see cref="Godot.Environment.FogModeEnum.Depth"/>.</para>
    /// </summary>
    public float FogDepthCurve
    {
        get
        {
            return GetFogDepthCurve();
        }
        set
        {
            SetFogDepthCurve(value);
        }
    }

    /// <summary>
    /// <para>The fog's depth starting distance from the camera. Only available when <see cref="Godot.Environment.FogMode"/> is set to <see cref="Godot.Environment.FogModeEnum.Depth"/>.</para>
    /// </summary>
    public float FogDepthBegin
    {
        get
        {
            return GetFogDepthBegin();
        }
        set
        {
            SetFogDepthBegin(value);
        }
    }

    /// <summary>
    /// <para>The fog's depth end distance from the camera. If this value is set to <c>0</c>, it will be equal to the current camera's <see cref="Godot.Camera3D.Far"/> value. Only available when <see cref="Godot.Environment.FogMode"/> is set to <see cref="Godot.Environment.FogModeEnum.Depth"/>.</para>
    /// </summary>
    public float FogDepthEnd
    {
        get
        {
            return GetFogDepthEnd();
        }
        set
        {
            SetFogDepthEnd(value);
        }
    }

    /// <summary>
    /// <para>Enables the volumetric fog effect. Volumetric fog uses a screen-aligned froxel buffer to calculate accurate volumetric scattering in the short to medium range. Volumetric fog interacts with <see cref="Godot.FogVolume"/>s and lights to calculate localized and global fog. Volumetric fog uses a PBR single-scattering model based on extinction, scattering, and emission which it exposes to users as density, albedo, and emission.</para>
    /// <para><b>Note:</b> Volumetric fog is only supported in the Forward+ rendering method, not Mobile or Compatibility.</para>
    /// </summary>
    public bool VolumetricFogEnabled
    {
        get
        {
            return IsVolumetricFogEnabled();
        }
        set
        {
            SetVolumetricFogEnabled(value);
        }
    }

    /// <summary>
    /// <para>The base <i>exponential</i> density of the volumetric fog. Set this to the lowest density you want to have globally. <see cref="Godot.FogVolume"/>s can be used to add to or subtract from this density in specific areas. Fog rendering is exponential as in real life.</para>
    /// <para>A value of <c>0.0</c> disables global volumetric fog while allowing <see cref="Godot.FogVolume"/>s to display volumetric fog in specific areas.</para>
    /// <para>To make volumetric fog work as a volumetric <i>lighting</i> solution, set <see cref="Godot.Environment.VolumetricFogDensity"/> to the lowest non-zero value (<c>0.0001</c>) then increase lights' <see cref="Godot.Light3D.LightVolumetricFogEnergy"/> to values between <c>10000</c> and <c>100000</c> to compensate for the very low density.</para>
    /// </summary>
    public float VolumetricFogDensity
    {
        get
        {
            return GetVolumetricFogDensity();
        }
        set
        {
            SetVolumetricFogDensity(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Color"/> of the volumetric fog when interacting with lights. Mist and fog have an albedo close to <c>Color(1, 1, 1, 1)</c> while smoke has a darker albedo.</para>
    /// </summary>
    public Color VolumetricFogAlbedo
    {
        get
        {
            return GetVolumetricFogAlbedo();
        }
        set
        {
            SetVolumetricFogAlbedo(value);
        }
    }

    /// <summary>
    /// <para>The emitted light from the volumetric fog. Even with emission, volumetric fog will not cast light onto other surfaces. Emission is useful to establish an ambient color. As the volumetric fog effect uses single-scattering only, fog tends to need a little bit of emission to soften the harsh shadows.</para>
    /// </summary>
    public Color VolumetricFogEmission
    {
        get
        {
            return GetVolumetricFogEmission();
        }
        set
        {
            SetVolumetricFogEmission(value);
        }
    }

    /// <summary>
    /// <para>The brightness of the emitted light from the volumetric fog.</para>
    /// </summary>
    public float VolumetricFogEmissionEnergy
    {
        get
        {
            return GetVolumetricFogEmissionEnergy();
        }
        set
        {
            SetVolumetricFogEmissionEnergy(value);
        }
    }

    /// <summary>
    /// <para>Scales the strength of Global Illumination used in the volumetric fog's albedo color. A value of <c>0.0</c> means that Global Illumination will not impact the volumetric fog. <see cref="Godot.Environment.VolumetricFogGIInject"/> has a small performance cost when set above <c>0.0</c>.</para>
    /// <para><b>Note:</b> This has no visible effect if <see cref="Godot.Environment.VolumetricFogDensity"/> is <c>0.0</c> or if <see cref="Godot.Environment.VolumetricFogAlbedo"/> is a fully black color.</para>
    /// <para><b>Note:</b> Only <see cref="Godot.VoxelGI"/> and SDFGI (<see cref="Godot.Environment.SdfgiEnabled"/>) are taken into account when using <see cref="Godot.Environment.VolumetricFogGIInject"/>. Global illumination from <see cref="Godot.LightmapGI"/>, <see cref="Godot.ReflectionProbe"/> and SSIL (see <see cref="Godot.Environment.SsilEnabled"/>) will be ignored by volumetric fog.</para>
    /// </summary>
    public float VolumetricFogGIInject
    {
        get
        {
            return GetVolumetricFogGIInject();
        }
        set
        {
            SetVolumetricFogGIInject(value);
        }
    }

    /// <summary>
    /// <para>The direction of scattered light as it goes through the volumetric fog. A value close to <c>1.0</c> means almost all light is scattered forward. A value close to <c>0.0</c> means light is scattered equally in all directions. A value close to <c>-1.0</c> means light is scattered mostly backward. Fog and mist scatter light slightly forward, while smoke scatters light equally in all directions.</para>
    /// </summary>
    public float VolumetricFogAnisotropy
    {
        get
        {
            return GetVolumetricFogAnisotropy();
        }
        set
        {
            SetVolumetricFogAnisotropy(value);
        }
    }

    /// <summary>
    /// <para>The distance over which the volumetric fog is computed. Increase to compute fog over a greater range, decrease to add more detail when a long range is not needed. For best quality fog, keep this as low as possible. See also <c>ProjectSettings.rendering/environment/volumetric_fog/volume_depth</c>.</para>
    /// </summary>
    public float VolumetricFogLength
    {
        get
        {
            return GetVolumetricFogLength();
        }
        set
        {
            SetVolumetricFogLength(value);
        }
    }

    /// <summary>
    /// <para>The distribution of size down the length of the froxel buffer. A higher value compresses the froxels closer to the camera and places more detail closer to the camera.</para>
    /// </summary>
    public float VolumetricFogDetailSpread
    {
        get
        {
            return GetVolumetricFogDetailSpread();
        }
        set
        {
            SetVolumetricFogDetailSpread(value);
        }
    }

    /// <summary>
    /// <para>Scales the strength of ambient light used in the volumetric fog. A value of <c>0.0</c> means that ambient light will not impact the volumetric fog. <see cref="Godot.Environment.VolumetricFogAmbientInject"/> has a small performance cost when set above <c>0.0</c>.</para>
    /// <para><b>Note:</b> This has no visible effect if <see cref="Godot.Environment.VolumetricFogDensity"/> is <c>0.0</c> or if <see cref="Godot.Environment.VolumetricFogAlbedo"/> is a fully black color.</para>
    /// </summary>
    public float VolumetricFogAmbientInject
    {
        get
        {
            return GetVolumetricFogAmbientInject();
        }
        set
        {
            SetVolumetricFogAmbientInject(value);
        }
    }

    /// <summary>
    /// <para>The factor to use when affecting the sky with volumetric fog. <c>1.0</c> means that volumetric fog can fully obscure the sky. Lower values reduce the impact of volumetric fog on sky rendering, with <c>0.0</c> not affecting sky rendering at all.</para>
    /// <para><b>Note:</b> <see cref="Godot.Environment.VolumetricFogSkyAffect"/> also affects <see cref="Godot.FogVolume"/>s, even if <see cref="Godot.Environment.VolumetricFogDensity"/> is <c>0.0</c>. If you notice <see cref="Godot.FogVolume"/>s are disappearing when looking towards the sky, set <see cref="Godot.Environment.VolumetricFogSkyAffect"/> to <c>1.0</c>.</para>
    /// </summary>
    public float VolumetricFogSkyAffect
    {
        get
        {
            return GetVolumetricFogSkyAffect();
        }
        set
        {
            SetVolumetricFogSkyAffect(value);
        }
    }

    /// <summary>
    /// <para>Enables temporal reprojection in the volumetric fog. Temporal reprojection blends the current frame's volumetric fog with the last frame's volumetric fog to smooth out jagged edges. The performance cost is minimal; however, it leads to moving <see cref="Godot.FogVolume"/>s and <see cref="Godot.Light3D"/>s "ghosting" and leaving a trail behind them. When temporal reprojection is enabled, try to avoid moving <see cref="Godot.FogVolume"/>s or <see cref="Godot.Light3D"/>s too fast. Short-lived dynamic lighting effects should have <see cref="Godot.Light3D.LightVolumetricFogEnergy"/> set to <c>0.0</c> to avoid ghosting.</para>
    /// </summary>
    public bool VolumetricFogTemporalReprojectionEnabled
    {
        get
        {
            return IsVolumetricFogTemporalReprojectionEnabled();
        }
        set
        {
            SetVolumetricFogTemporalReprojectionEnabled(value);
        }
    }

    /// <summary>
    /// <para>The amount by which to blend the last frame with the current frame. A higher number results in smoother volumetric fog, but makes "ghosting" much worse. A lower value reduces ghosting but can result in the per-frame temporal jitter becoming visible.</para>
    /// </summary>
    public float VolumetricFogTemporalReprojectionAmount
    {
        get
        {
            return GetVolumetricFogTemporalReprojectionAmount();
        }
        set
        {
            SetVolumetricFogTemporalReprojectionAmount(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables the <c>adjustment_*</c> properties provided by this resource. If <see langword="false"/>, modifications to the <c>adjustment_*</c> properties will have no effect on the rendered scene.</para>
    /// </summary>
    public bool AdjustmentEnabled
    {
        get
        {
            return IsAdjustmentEnabled();
        }
        set
        {
            SetAdjustmentEnabled(value);
        }
    }

    /// <summary>
    /// <para>Applies a simple brightness adjustment to the rendered image after tonemaping. To adjust scene brightness use <see cref="Godot.Environment.TonemapExposure"/> instead, which is applied before tonemapping and thus less prone to issues with bright colors. Effective only if <see cref="Godot.Environment.AdjustmentEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public float AdjustmentBrightness
    {
        get
        {
            return GetAdjustmentBrightness();
        }
        set
        {
            SetAdjustmentBrightness(value);
        }
    }

    /// <summary>
    /// <para>Increasing <see cref="Godot.Environment.AdjustmentContrast"/> will make dark values darker and bright values brighter. This simple adjustment is applied to the rendered image after tonemaping. When set to a value greater than <c>1.0</c>, <see cref="Godot.Environment.AdjustmentContrast"/> is prone to clipping colors that become too bright or too dark. Effective only if <see cref="Godot.Environment.AdjustmentEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public float AdjustmentContrast
    {
        get
        {
            return GetAdjustmentContrast();
        }
        set
        {
            SetAdjustmentContrast(value);
        }
    }

    /// <summary>
    /// <para>Applies a simple saturation adjustment to the rendered image after tonemaping. When <see cref="Godot.Environment.AdjustmentSaturation"/> is set to <c>0.0</c>, the rendered image will be fully converted to a grayscale image. Effective only if <see cref="Godot.Environment.AdjustmentEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public float AdjustmentSaturation
    {
        get
        {
            return GetAdjustmentSaturation();
        }
        set
        {
            SetAdjustmentSaturation(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Texture2D"/> or <see cref="Godot.Texture3D"/> lookup table (LUT) to use for the built-in post-process color grading. Can use a <see cref="Godot.GradientTexture1D"/> for a 1-dimensional LUT, or a <see cref="Godot.Texture3D"/> for a more complex LUT. Effective only if <see cref="Godot.Environment.AdjustmentEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public Texture AdjustmentColorCorrection
    {
        get
        {
            return GetAdjustmentColorCorrection();
        }
        set
        {
            SetAdjustmentColorCorrection(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Environment);

    private static readonly StringName NativeName = "Environment";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Environment() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Environment(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Environment(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackground, 4071623990ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackground(Environment.BGMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBackground, 1843210413ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment.BGMode GetBackground()
    {
        return (Environment.BGMode)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSky, 3336722921ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSky(Sky sky)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(sky));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSky, 1177136966ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Sky GetSky()
    {
        return (Sky)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkyCustomFov, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkyCustomFov(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkyCustomFov, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSkyCustomFov()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkyRotation, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSkyRotation(Vector3 eulerRadians)
    {
        NativeCalls.godot_icall_1_177(MethodBind6, GodotObject.GetPtr(this), &eulerRadians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkyRotation, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetSkyRotation()
    {
        return NativeCalls.godot_icall_0_125(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBgColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBgColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind8, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBgColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetBgColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBgEnergyMultiplier, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBgEnergyMultiplier(float energy)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBgEnergyMultiplier, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBgEnergyMultiplier()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBgIntensity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBgIntensity(float energy)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBgIntensity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBgIntensity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCanvasMaxLayer, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCanvasMaxLayer(int layer)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvasMaxLayer, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCanvasMaxLayer()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCameraFeedId, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCameraFeedId(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraFeedId, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCameraFeedId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmbientLightColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAmbientLightColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind18, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmbientLightColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetAmbientLightColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmbientSource, 2607780160ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAmbientSource(Environment.AmbientSource source)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), (int)source);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmbientSource, 67453933ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment.AmbientSource GetAmbientSource()
    {
        return (Environment.AmbientSource)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmbientLightEnergy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAmbientLightEnergy(float energy)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmbientLightEnergy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAmbientLightEnergy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmbientLightSkyContribution, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAmbientLightSkyContribution(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmbientLightSkyContribution, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAmbientLightSkyContribution()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReflectionSource, 299673197ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReflectionSource(Environment.ReflectionSource source)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), (int)source);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReflectionSource, 777700713ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment.ReflectionSource GetReflectionSource()
    {
        return (Environment.ReflectionSource)NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTonemapper, 1509116664ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTonemapper(Environment.ToneMapper mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTonemapper, 2908408137ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment.ToneMapper GetTonemapper()
    {
        return (Environment.ToneMapper)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTonemapExposure, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTonemapExposure(float exposure)
    {
        NativeCalls.godot_icall_1_67(MethodBind30, GodotObject.GetPtr(this), exposure);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTonemapExposure, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTonemapExposure()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTonemapWhite, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTonemapWhite(float white)
    {
        NativeCalls.godot_icall_1_67(MethodBind32, GodotObject.GetPtr(this), white);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTonemapWhite, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTonemapWhite()
    {
        return NativeCalls.godot_icall_0_68(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTonemapAgxWhite, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTonemapAgxWhite(float white)
    {
        NativeCalls.godot_icall_1_67(MethodBind34, GodotObject.GetPtr(this), white);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTonemapAgxWhite, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTonemapAgxWhite()
    {
        return NativeCalls.godot_icall_0_68(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTonemapAgxContrast, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTonemapAgxContrast(float contrast)
    {
        NativeCalls.godot_icall_1_67(MethodBind36, GodotObject.GetPtr(this), contrast);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTonemapAgxContrast, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTonemapAgxContrast()
    {
        return NativeCalls.godot_icall_0_68(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsrEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsrEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind38, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSsrEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSsrEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind39, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsrMaxSteps, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsrMaxSteps(int maxSteps)
    {
        NativeCalls.godot_icall_1_38(MethodBind40, GodotObject.GetPtr(this), maxSteps);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsrMaxSteps, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSsrMaxSteps()
    {
        return NativeCalls.godot_icall_0_39(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsrFadeIn, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsrFadeIn(float fadeIn)
    {
        NativeCalls.godot_icall_1_67(MethodBind42, GodotObject.GetPtr(this), fadeIn);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsrFadeIn, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsrFadeIn()
    {
        return NativeCalls.godot_icall_0_68(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsrFadeOut, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsrFadeOut(float fadeOut)
    {
        NativeCalls.godot_icall_1_67(MethodBind44, GodotObject.GetPtr(this), fadeOut);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsrFadeOut, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsrFadeOut()
    {
        return NativeCalls.godot_icall_0_68(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsrDepthTolerance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsrDepthTolerance(float depthTolerance)
    {
        NativeCalls.godot_icall_1_67(MethodBind46, GodotObject.GetPtr(this), depthTolerance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsrDepthTolerance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsrDepthTolerance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsaoEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsaoEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind48, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSsaoEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSsaoEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind49, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsaoRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsaoRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind50, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsaoRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsaoRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsaoIntensity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsaoIntensity(float intensity)
    {
        NativeCalls.godot_icall_1_67(MethodBind52, GodotObject.GetPtr(this), intensity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsaoIntensity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsaoIntensity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsaoPower, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsaoPower(float power)
    {
        NativeCalls.godot_icall_1_67(MethodBind54, GodotObject.GetPtr(this), power);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsaoPower, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsaoPower()
    {
        return NativeCalls.godot_icall_0_68(MethodBind55, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsaoDetail, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsaoDetail(float detail)
    {
        NativeCalls.godot_icall_1_67(MethodBind56, GodotObject.GetPtr(this), detail);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsaoDetail, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsaoDetail()
    {
        return NativeCalls.godot_icall_0_68(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsaoHorizon, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsaoHorizon(float horizon)
    {
        NativeCalls.godot_icall_1_67(MethodBind58, GodotObject.GetPtr(this), horizon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsaoHorizon, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsaoHorizon()
    {
        return NativeCalls.godot_icall_0_68(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsaoSharpness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsaoSharpness(float sharpness)
    {
        NativeCalls.godot_icall_1_67(MethodBind60, GodotObject.GetPtr(this), sharpness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsaoSharpness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsaoSharpness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind61, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsaoDirectLightAffect, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsaoDirectLightAffect(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind62, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsaoDirectLightAffect, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsaoDirectLightAffect()
    {
        return NativeCalls.godot_icall_0_68(MethodBind63, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsaoAOChannelAffect, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsaoAOChannelAffect(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind64, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsaoAOChannelAffect, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsaoAOChannelAffect()
    {
        return NativeCalls.godot_icall_0_68(MethodBind65, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsilEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsilEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind66, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSsilEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSsilEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind67, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsilRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsilRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind68, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsilRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsilRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind69, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsilIntensity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsilIntensity(float intensity)
    {
        NativeCalls.godot_icall_1_67(MethodBind70, GodotObject.GetPtr(this), intensity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsilIntensity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsilIntensity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind71, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsilSharpness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsilSharpness(float sharpness)
    {
        NativeCalls.godot_icall_1_67(MethodBind72, GodotObject.GetPtr(this), sharpness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsilSharpness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsilSharpness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind73, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSsilNormalRejection, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSsilNormalRejection(float normalRejection)
    {
        NativeCalls.godot_icall_1_67(MethodBind74, GodotObject.GetPtr(this), normalRejection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSsilNormalRejection, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSsilNormalRejection()
    {
        return NativeCalls.godot_icall_0_68(MethodBind75, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind76, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSdfgiEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSdfgiEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind77, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiCascades, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiCascades(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind78, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfgiCascades, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSdfgiCascades()
    {
        return NativeCalls.godot_icall_0_39(MethodBind79, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiMinCellSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiMinCellSize(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind80, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfgiMinCellSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSdfgiMinCellSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind81, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiMaxDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiMaxDistance(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind82, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfgiMaxDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSdfgiMaxDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind83, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiCascade0Distance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiCascade0Distance(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind84, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfgiCascade0Distance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSdfgiCascade0Distance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind85, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiYScale, 3608608372ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiYScale(Environment.SdfgiyScale scale)
    {
        NativeCalls.godot_icall_1_38(MethodBind86, GodotObject.GetPtr(this), (int)scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfgiYScale, 2568002245ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment.SdfgiyScale GetSdfgiYScale()
    {
        return (Environment.SdfgiyScale)NativeCalls.godot_icall_0_39(MethodBind87, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiUseOcclusion, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiUseOcclusion(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind88, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSdfgiUsingOcclusion, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSdfgiUsingOcclusion()
    {
        return NativeCalls.godot_icall_0_15(MethodBind89, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiBounceFeedback, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiBounceFeedback(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind90, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfgiBounceFeedback, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSdfgiBounceFeedback()
    {
        return NativeCalls.godot_icall_0_68(MethodBind91, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiReadSkyLight, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiReadSkyLight(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind92, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSdfgiReadingSkyLight, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSdfgiReadingSkyLight()
    {
        return NativeCalls.godot_icall_0_15(MethodBind93, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiEnergy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiEnergy(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind94, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfgiEnergy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSdfgiEnergy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind95, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiNormalBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiNormalBias(float bias)
    {
        NativeCalls.godot_icall_1_67(MethodBind96, GodotObject.GetPtr(this), bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfgiNormalBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSdfgiNormalBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind97, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSdfgiProbeBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSdfgiProbeBias(float bias)
    {
        NativeCalls.godot_icall_1_67(MethodBind98, GodotObject.GetPtr(this), bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSdfgiProbeBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSdfgiProbeBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind99, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind100, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsGlowEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsGlowEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind101, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowLevel, 1602489585ul);

    /// <summary>
    /// <para>Sets the intensity of the glow level <paramref name="idx"/>. A value above <c>0.0</c> enables the level. Each level relies on the previous level. This means that enabling higher glow levels will slow down the glow effect rendering, even if previous levels aren't enabled.</para>
    /// </summary>
    public void SetGlowLevel(int idx, float intensity)
    {
        NativeCalls.godot_icall_2_69(MethodBind102, GodotObject.GetPtr(this), idx, intensity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowLevel, 2339986948ul);

    /// <summary>
    /// <para>Returns the intensity of the glow level <paramref name="idx"/>.</para>
    /// </summary>
    public float GetGlowLevel(int idx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind103, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowNormalized, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowNormalized(bool normalize)
    {
        NativeCalls.godot_icall_1_14(MethodBind104, GodotObject.GetPtr(this), normalize.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsGlowNormalized, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsGlowNormalized()
    {
        return NativeCalls.godot_icall_0_15(MethodBind105, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowIntensity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowIntensity(float intensity)
    {
        NativeCalls.godot_icall_1_67(MethodBind106, GodotObject.GetPtr(this), intensity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowIntensity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlowIntensity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind107, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowStrength(float strength)
    {
        NativeCalls.godot_icall_1_67(MethodBind108, GodotObject.GetPtr(this), strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlowStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind109, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowMix, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowMix(float mix)
    {
        NativeCalls.godot_icall_1_67(MethodBind110, GodotObject.GetPtr(this), mix);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowMix, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlowMix()
    {
        return NativeCalls.godot_icall_0_68(MethodBind111, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowBloom, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowBloom(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind112, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowBloom, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlowBloom()
    {
        return NativeCalls.godot_icall_0_68(MethodBind113, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowBlendMode, 2561587761ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowBlendMode(Environment.GlowBlendModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind114, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowBlendMode, 1529667332ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment.GlowBlendModeEnum GetGlowBlendMode()
    {
        return (Environment.GlowBlendModeEnum)NativeCalls.godot_icall_0_39(MethodBind115, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowHdrBleedThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowHdrBleedThreshold(float threshold)
    {
        NativeCalls.godot_icall_1_67(MethodBind116, GodotObject.GetPtr(this), threshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowHdrBleedThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlowHdrBleedThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind117, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowHdrBleedScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowHdrBleedScale(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind118, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowHdrBleedScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlowHdrBleedScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind119, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowHdrLuminanceCap, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowHdrLuminanceCap(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind120, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowHdrLuminanceCap, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlowHdrLuminanceCap()
    {
        return NativeCalls.godot_icall_0_68(MethodBind121, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowMapStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowMapStrength(float strength)
    {
        NativeCalls.godot_icall_1_67(MethodBind122, GodotObject.GetPtr(this), strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowMapStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlowMapStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind123, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlowMap, 1790811099ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlowMap(Texture mode)
    {
        NativeCalls.godot_icall_1_56(MethodBind124, GodotObject.GetPtr(this), GodotObject.GetPtr(mode));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlowMap, 4037048985ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture GetGlowMap()
    {
        return (Texture)NativeCalls.godot_icall_0_63(MethodBind125, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind126, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFogEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFogEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind127, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogMode, 3059806579ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogMode(Environment.FogModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind128, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogMode, 2456062483ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment.FogModeEnum GetFogMode()
    {
        return (Environment.FogModeEnum)NativeCalls.godot_icall_0_39(MethodBind129, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogLightColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFogLightColor(Color lightColor)
    {
        NativeCalls.godot_icall_1_213(MethodBind130, GodotObject.GetPtr(this), &lightColor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogLightColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetFogLightColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind131, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogLightEnergy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogLightEnergy(float lightEnergy)
    {
        NativeCalls.godot_icall_1_67(MethodBind132, GodotObject.GetPtr(this), lightEnergy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogLightEnergy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFogLightEnergy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind133, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogSunScatter, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogSunScatter(float sunScatter)
    {
        NativeCalls.godot_icall_1_67(MethodBind134, GodotObject.GetPtr(this), sunScatter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogSunScatter, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFogSunScatter()
    {
        return NativeCalls.godot_icall_0_68(MethodBind135, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogDensity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogDensity(float density)
    {
        NativeCalls.godot_icall_1_67(MethodBind136, GodotObject.GetPtr(this), density);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogDensity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFogDensity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind137, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind138 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogHeight, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogHeight(float height)
    {
        NativeCalls.godot_icall_1_67(MethodBind138, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind139 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogHeight, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFogHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind139, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind140 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogHeightDensity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogHeightDensity(float heightDensity)
    {
        NativeCalls.godot_icall_1_67(MethodBind140, GodotObject.GetPtr(this), heightDensity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind141 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogHeightDensity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFogHeightDensity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind141, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind142 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogAerialPerspective, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogAerialPerspective(float aerialPerspective)
    {
        NativeCalls.godot_icall_1_67(MethodBind142, GodotObject.GetPtr(this), aerialPerspective);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind143 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogAerialPerspective, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFogAerialPerspective()
    {
        return NativeCalls.godot_icall_0_68(MethodBind143, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind144 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogSkyAffect, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogSkyAffect(float skyAffect)
    {
        NativeCalls.godot_icall_1_67(MethodBind144, GodotObject.GetPtr(this), skyAffect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind145 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogSkyAffect, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFogSkyAffect()
    {
        return NativeCalls.godot_icall_0_68(MethodBind145, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind146 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogDepthCurve, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogDepthCurve(float curve)
    {
        NativeCalls.godot_icall_1_67(MethodBind146, GodotObject.GetPtr(this), curve);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind147 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogDepthCurve, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFogDepthCurve()
    {
        return NativeCalls.godot_icall_0_68(MethodBind147, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind148 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogDepthBegin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogDepthBegin(float begin)
    {
        NativeCalls.godot_icall_1_67(MethodBind148, GodotObject.GetPtr(this), begin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind149 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogDepthBegin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFogDepthBegin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind149, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind150 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFogDepthEnd, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFogDepthEnd(float end)
    {
        NativeCalls.godot_icall_1_67(MethodBind150, GodotObject.GetPtr(this), end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind151 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFogDepthEnd, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFogDepthEnd()
    {
        return NativeCalls.godot_icall_0_68(MethodBind151, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind152 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind152, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind153 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVolumetricFogEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVolumetricFogEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind153, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind154 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogEmission, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetVolumetricFogEmission(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind154, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind155 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogEmission, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetVolumetricFogEmission()
    {
        return NativeCalls.godot_icall_0_214(MethodBind155, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind156 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogAlbedo, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetVolumetricFogAlbedo(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind156, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind157 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogAlbedo, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetVolumetricFogAlbedo()
    {
        return NativeCalls.godot_icall_0_214(MethodBind157, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind158 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogDensity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogDensity(float density)
    {
        NativeCalls.godot_icall_1_67(MethodBind158, GodotObject.GetPtr(this), density);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind159 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogDensity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumetricFogDensity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind159, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind160 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogEmissionEnergy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogEmissionEnergy(float begin)
    {
        NativeCalls.godot_icall_1_67(MethodBind160, GodotObject.GetPtr(this), begin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind161 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogEmissionEnergy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumetricFogEmissionEnergy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind161, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind162 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogAnisotropy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogAnisotropy(float anisotropy)
    {
        NativeCalls.godot_icall_1_67(MethodBind162, GodotObject.GetPtr(this), anisotropy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind163 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogAnisotropy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumetricFogAnisotropy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind163, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind164 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogLength(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind164, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind165 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumetricFogLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind165, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind166 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogDetailSpread, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogDetailSpread(float detailSpread)
    {
        NativeCalls.godot_icall_1_67(MethodBind166, GodotObject.GetPtr(this), detailSpread);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind167 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogDetailSpread, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumetricFogDetailSpread()
    {
        return NativeCalls.godot_icall_0_68(MethodBind167, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind168 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogGIInject, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogGIInject(float gIInject)
    {
        NativeCalls.godot_icall_1_67(MethodBind168, GodotObject.GetPtr(this), gIInject);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind169 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogGIInject, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumetricFogGIInject()
    {
        return NativeCalls.godot_icall_0_68(MethodBind169, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind170 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogAmbientInject, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogAmbientInject(float enabled)
    {
        NativeCalls.godot_icall_1_67(MethodBind170, GodotObject.GetPtr(this), enabled);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind171 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogAmbientInject, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumetricFogAmbientInject()
    {
        return NativeCalls.godot_icall_0_68(MethodBind171, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind172 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogSkyAffect, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogSkyAffect(float skyAffect)
    {
        NativeCalls.godot_icall_1_67(MethodBind172, GodotObject.GetPtr(this), skyAffect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind173 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogSkyAffect, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumetricFogSkyAffect()
    {
        return NativeCalls.godot_icall_0_68(MethodBind173, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind174 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogTemporalReprojectionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogTemporalReprojectionEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind174, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind175 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVolumetricFogTemporalReprojectionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVolumetricFogTemporalReprojectionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind175, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind176 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumetricFogTemporalReprojectionAmount, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumetricFogTemporalReprojectionAmount(float temporalReprojectionAmount)
    {
        NativeCalls.godot_icall_1_67(MethodBind176, GodotObject.GetPtr(this), temporalReprojectionAmount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind177 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumetricFogTemporalReprojectionAmount, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumetricFogTemporalReprojectionAmount()
    {
        return NativeCalls.godot_icall_0_68(MethodBind177, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind178 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdjustmentEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAdjustmentEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind178, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind179 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAdjustmentEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAdjustmentEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind179, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind180 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdjustmentBrightness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAdjustmentBrightness(float brightness)
    {
        NativeCalls.godot_icall_1_67(MethodBind180, GodotObject.GetPtr(this), brightness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind181 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdjustmentBrightness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAdjustmentBrightness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind181, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind182 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdjustmentContrast, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAdjustmentContrast(float contrast)
    {
        NativeCalls.godot_icall_1_67(MethodBind182, GodotObject.GetPtr(this), contrast);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind183 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdjustmentContrast, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAdjustmentContrast()
    {
        return NativeCalls.godot_icall_0_68(MethodBind183, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind184 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdjustmentSaturation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAdjustmentSaturation(float saturation)
    {
        NativeCalls.godot_icall_1_67(MethodBind184, GodotObject.GetPtr(this), saturation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind185 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdjustmentSaturation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAdjustmentSaturation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind185, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind186 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdjustmentColorCorrection, 1790811099ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAdjustmentColorCorrection(Texture colorCorrection)
    {
        NativeCalls.godot_icall_1_56(MethodBind186, GodotObject.GetPtr(this), GodotObject.GetPtr(colorCorrection));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind187 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdjustmentColorCorrection, 4037048985ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture GetAdjustmentColorCorrection()
    {
        return (Texture)NativeCalls.godot_icall_0_63(MethodBind187, GodotObject.GetPtr(this));
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
        /// Cached name for the 'background_mode' property.
        /// </summary>
        public static readonly StringName BackgroundMode = "background_mode";
        /// <summary>
        /// Cached name for the 'background_color' property.
        /// </summary>
        public static readonly StringName BackgroundColor = "background_color";
        /// <summary>
        /// Cached name for the 'background_energy_multiplier' property.
        /// </summary>
        public static readonly StringName BackgroundEnergyMultiplier = "background_energy_multiplier";
        /// <summary>
        /// Cached name for the 'background_intensity' property.
        /// </summary>
        public static readonly StringName BackgroundIntensity = "background_intensity";
        /// <summary>
        /// Cached name for the 'background_canvas_max_layer' property.
        /// </summary>
        public static readonly StringName BackgroundCanvasMaxLayer = "background_canvas_max_layer";
        /// <summary>
        /// Cached name for the 'background_camera_feed_id' property.
        /// </summary>
        public static readonly StringName BackgroundCameraFeedId = "background_camera_feed_id";
        /// <summary>
        /// Cached name for the 'sky' property.
        /// </summary>
        public static readonly StringName Sky = "sky";
        /// <summary>
        /// Cached name for the 'sky_custom_fov' property.
        /// </summary>
        public static readonly StringName SkyCustomFov = "sky_custom_fov";
        /// <summary>
        /// Cached name for the 'sky_rotation' property.
        /// </summary>
        public static readonly StringName SkyRotation = "sky_rotation";
        /// <summary>
        /// Cached name for the 'ambient_light_source' property.
        /// </summary>
        public static readonly StringName AmbientLightSource = "ambient_light_source";
        /// <summary>
        /// Cached name for the 'ambient_light_color' property.
        /// </summary>
        public static readonly StringName AmbientLightColor = "ambient_light_color";
        /// <summary>
        /// Cached name for the 'ambient_light_sky_contribution' property.
        /// </summary>
        public static readonly StringName AmbientLightSkyContribution = "ambient_light_sky_contribution";
        /// <summary>
        /// Cached name for the 'ambient_light_energy' property.
        /// </summary>
        public static readonly StringName AmbientLightEnergy = "ambient_light_energy";
        /// <summary>
        /// Cached name for the 'reflected_light_source' property.
        /// </summary>
        public static readonly StringName ReflectedLightSource = "reflected_light_source";
        /// <summary>
        /// Cached name for the 'tonemap_mode' property.
        /// </summary>
        public static readonly StringName TonemapMode = "tonemap_mode";
        /// <summary>
        /// Cached name for the 'tonemap_exposure' property.
        /// </summary>
        public static readonly StringName TonemapExposure = "tonemap_exposure";
        /// <summary>
        /// Cached name for the 'tonemap_white' property.
        /// </summary>
        public static readonly StringName TonemapWhite = "tonemap_white";
        /// <summary>
        /// Cached name for the 'tonemap_agx_white' property.
        /// </summary>
        public static readonly StringName TonemapAgxWhite = "tonemap_agx_white";
        /// <summary>
        /// Cached name for the 'tonemap_agx_contrast' property.
        /// </summary>
        public static readonly StringName TonemapAgxContrast = "tonemap_agx_contrast";
        /// <summary>
        /// Cached name for the 'ssr_enabled' property.
        /// </summary>
        public static readonly StringName SsrEnabled = "ssr_enabled";
        /// <summary>
        /// Cached name for the 'ssr_max_steps' property.
        /// </summary>
        public static readonly StringName SsrMaxSteps = "ssr_max_steps";
        /// <summary>
        /// Cached name for the 'ssr_fade_in' property.
        /// </summary>
        public static readonly StringName SsrFadeIn = "ssr_fade_in";
        /// <summary>
        /// Cached name for the 'ssr_fade_out' property.
        /// </summary>
        public static readonly StringName SsrFadeOut = "ssr_fade_out";
        /// <summary>
        /// Cached name for the 'ssr_depth_tolerance' property.
        /// </summary>
        public static readonly StringName SsrDepthTolerance = "ssr_depth_tolerance";
        /// <summary>
        /// Cached name for the 'ssao_enabled' property.
        /// </summary>
        public static readonly StringName SsaoEnabled = "ssao_enabled";
        /// <summary>
        /// Cached name for the 'ssao_radius' property.
        /// </summary>
        public static readonly StringName SsaoRadius = "ssao_radius";
        /// <summary>
        /// Cached name for the 'ssao_intensity' property.
        /// </summary>
        public static readonly StringName SsaoIntensity = "ssao_intensity";
        /// <summary>
        /// Cached name for the 'ssao_power' property.
        /// </summary>
        public static readonly StringName SsaoPower = "ssao_power";
        /// <summary>
        /// Cached name for the 'ssao_detail' property.
        /// </summary>
        public static readonly StringName SsaoDetail = "ssao_detail";
        /// <summary>
        /// Cached name for the 'ssao_horizon' property.
        /// </summary>
        public static readonly StringName SsaoHorizon = "ssao_horizon";
        /// <summary>
        /// Cached name for the 'ssao_sharpness' property.
        /// </summary>
        public static readonly StringName SsaoSharpness = "ssao_sharpness";
        /// <summary>
        /// Cached name for the 'ssao_light_affect' property.
        /// </summary>
        public static readonly StringName SsaoLightAffect = "ssao_light_affect";
        /// <summary>
        /// Cached name for the 'ssao_ao_channel_affect' property.
        /// </summary>
        public static readonly StringName SsaoAOChannelAffect = "ssao_ao_channel_affect";
        /// <summary>
        /// Cached name for the 'ssil_enabled' property.
        /// </summary>
        public static readonly StringName SsilEnabled = "ssil_enabled";
        /// <summary>
        /// Cached name for the 'ssil_radius' property.
        /// </summary>
        public static readonly StringName SsilRadius = "ssil_radius";
        /// <summary>
        /// Cached name for the 'ssil_intensity' property.
        /// </summary>
        public static readonly StringName SsilIntensity = "ssil_intensity";
        /// <summary>
        /// Cached name for the 'ssil_sharpness' property.
        /// </summary>
        public static readonly StringName SsilSharpness = "ssil_sharpness";
        /// <summary>
        /// Cached name for the 'ssil_normal_rejection' property.
        /// </summary>
        public static readonly StringName SsilNormalRejection = "ssil_normal_rejection";
        /// <summary>
        /// Cached name for the 'sdfgi_enabled' property.
        /// </summary>
        public static readonly StringName SdfgiEnabled = "sdfgi_enabled";
        /// <summary>
        /// Cached name for the 'sdfgi_use_occlusion' property.
        /// </summary>
        public static readonly StringName SdfgiUseOcclusion = "sdfgi_use_occlusion";
        /// <summary>
        /// Cached name for the 'sdfgi_read_sky_light' property.
        /// </summary>
        public static readonly StringName SdfgiReadSkyLight = "sdfgi_read_sky_light";
        /// <summary>
        /// Cached name for the 'sdfgi_bounce_feedback' property.
        /// </summary>
        public static readonly StringName SdfgiBounceFeedback = "sdfgi_bounce_feedback";
        /// <summary>
        /// Cached name for the 'sdfgi_cascades' property.
        /// </summary>
        public static readonly StringName SdfgiCascades = "sdfgi_cascades";
        /// <summary>
        /// Cached name for the 'sdfgi_min_cell_size' property.
        /// </summary>
        public static readonly StringName SdfgiMinCellSize = "sdfgi_min_cell_size";
        /// <summary>
        /// Cached name for the 'sdfgi_cascade0_distance' property.
        /// </summary>
        public static readonly StringName SdfgiCascade0Distance = "sdfgi_cascade0_distance";
        /// <summary>
        /// Cached name for the 'sdfgi_max_distance' property.
        /// </summary>
        public static readonly StringName SdfgiMaxDistance = "sdfgi_max_distance";
        /// <summary>
        /// Cached name for the 'sdfgi_y_scale' property.
        /// </summary>
        public static readonly StringName SdfgiYScale = "sdfgi_y_scale";
        /// <summary>
        /// Cached name for the 'sdfgi_energy' property.
        /// </summary>
        public static readonly StringName SdfgiEnergy = "sdfgi_energy";
        /// <summary>
        /// Cached name for the 'sdfgi_normal_bias' property.
        /// </summary>
        public static readonly StringName SdfgiNormalBias = "sdfgi_normal_bias";
        /// <summary>
        /// Cached name for the 'sdfgi_probe_bias' property.
        /// </summary>
        public static readonly StringName SdfgiProbeBias = "sdfgi_probe_bias";
        /// <summary>
        /// Cached name for the 'glow_enabled' property.
        /// </summary>
        public static readonly StringName GlowEnabled = "glow_enabled";
        /// <summary>
        /// Cached name for the 'glow_normalized' property.
        /// </summary>
        public static readonly StringName GlowNormalized = "glow_normalized";
        /// <summary>
        /// Cached name for the 'glow_intensity' property.
        /// </summary>
        public static readonly StringName GlowIntensity = "glow_intensity";
        /// <summary>
        /// Cached name for the 'glow_strength' property.
        /// </summary>
        public static readonly StringName GlowStrength = "glow_strength";
        /// <summary>
        /// Cached name for the 'glow_mix' property.
        /// </summary>
        public static readonly StringName GlowMix = "glow_mix";
        /// <summary>
        /// Cached name for the 'glow_bloom' property.
        /// </summary>
        public static readonly StringName GlowBloom = "glow_bloom";
        /// <summary>
        /// Cached name for the 'glow_blend_mode' property.
        /// </summary>
        public static readonly StringName GlowBlendMode = "glow_blend_mode";
        /// <summary>
        /// Cached name for the 'glow_hdr_threshold' property.
        /// </summary>
        public static readonly StringName GlowHdrThreshold = "glow_hdr_threshold";
        /// <summary>
        /// Cached name for the 'glow_hdr_scale' property.
        /// </summary>
        public static readonly StringName GlowHdrScale = "glow_hdr_scale";
        /// <summary>
        /// Cached name for the 'glow_hdr_luminance_cap' property.
        /// </summary>
        public static readonly StringName GlowHdrLuminanceCap = "glow_hdr_luminance_cap";
        /// <summary>
        /// Cached name for the 'glow_map_strength' property.
        /// </summary>
        public static readonly StringName GlowMapStrength = "glow_map_strength";
        /// <summary>
        /// Cached name for the 'glow_map' property.
        /// </summary>
        public static readonly StringName GlowMap = "glow_map";
        /// <summary>
        /// Cached name for the 'fog_enabled' property.
        /// </summary>
        public static readonly StringName FogEnabled = "fog_enabled";
        /// <summary>
        /// Cached name for the 'fog_mode' property.
        /// </summary>
        public static readonly StringName FogMode = "fog_mode";
        /// <summary>
        /// Cached name for the 'fog_light_color' property.
        /// </summary>
        public static readonly StringName FogLightColor = "fog_light_color";
        /// <summary>
        /// Cached name for the 'fog_light_energy' property.
        /// </summary>
        public static readonly StringName FogLightEnergy = "fog_light_energy";
        /// <summary>
        /// Cached name for the 'fog_sun_scatter' property.
        /// </summary>
        public static readonly StringName FogSunScatter = "fog_sun_scatter";
        /// <summary>
        /// Cached name for the 'fog_density' property.
        /// </summary>
        public static readonly StringName FogDensity = "fog_density";
        /// <summary>
        /// Cached name for the 'fog_aerial_perspective' property.
        /// </summary>
        public static readonly StringName FogAerialPerspective = "fog_aerial_perspective";
        /// <summary>
        /// Cached name for the 'fog_sky_affect' property.
        /// </summary>
        public static readonly StringName FogSkyAffect = "fog_sky_affect";
        /// <summary>
        /// Cached name for the 'fog_height' property.
        /// </summary>
        public static readonly StringName FogHeight = "fog_height";
        /// <summary>
        /// Cached name for the 'fog_height_density' property.
        /// </summary>
        public static readonly StringName FogHeightDensity = "fog_height_density";
        /// <summary>
        /// Cached name for the 'fog_depth_curve' property.
        /// </summary>
        public static readonly StringName FogDepthCurve = "fog_depth_curve";
        /// <summary>
        /// Cached name for the 'fog_depth_begin' property.
        /// </summary>
        public static readonly StringName FogDepthBegin = "fog_depth_begin";
        /// <summary>
        /// Cached name for the 'fog_depth_end' property.
        /// </summary>
        public static readonly StringName FogDepthEnd = "fog_depth_end";
        /// <summary>
        /// Cached name for the 'volumetric_fog_enabled' property.
        /// </summary>
        public static readonly StringName VolumetricFogEnabled = "volumetric_fog_enabled";
        /// <summary>
        /// Cached name for the 'volumetric_fog_density' property.
        /// </summary>
        public static readonly StringName VolumetricFogDensity = "volumetric_fog_density";
        /// <summary>
        /// Cached name for the 'volumetric_fog_albedo' property.
        /// </summary>
        public static readonly StringName VolumetricFogAlbedo = "volumetric_fog_albedo";
        /// <summary>
        /// Cached name for the 'volumetric_fog_emission' property.
        /// </summary>
        public static readonly StringName VolumetricFogEmission = "volumetric_fog_emission";
        /// <summary>
        /// Cached name for the 'volumetric_fog_emission_energy' property.
        /// </summary>
        public static readonly StringName VolumetricFogEmissionEnergy = "volumetric_fog_emission_energy";
        /// <summary>
        /// Cached name for the 'volumetric_fog_gi_inject' property.
        /// </summary>
        public static readonly StringName VolumetricFogGIInject = "volumetric_fog_gi_inject";
        /// <summary>
        /// Cached name for the 'volumetric_fog_anisotropy' property.
        /// </summary>
        public static readonly StringName VolumetricFogAnisotropy = "volumetric_fog_anisotropy";
        /// <summary>
        /// Cached name for the 'volumetric_fog_length' property.
        /// </summary>
        public static readonly StringName VolumetricFogLength = "volumetric_fog_length";
        /// <summary>
        /// Cached name for the 'volumetric_fog_detail_spread' property.
        /// </summary>
        public static readonly StringName VolumetricFogDetailSpread = "volumetric_fog_detail_spread";
        /// <summary>
        /// Cached name for the 'volumetric_fog_ambient_inject' property.
        /// </summary>
        public static readonly StringName VolumetricFogAmbientInject = "volumetric_fog_ambient_inject";
        /// <summary>
        /// Cached name for the 'volumetric_fog_sky_affect' property.
        /// </summary>
        public static readonly StringName VolumetricFogSkyAffect = "volumetric_fog_sky_affect";
        /// <summary>
        /// Cached name for the 'volumetric_fog_temporal_reprojection_enabled' property.
        /// </summary>
        public static readonly StringName VolumetricFogTemporalReprojectionEnabled = "volumetric_fog_temporal_reprojection_enabled";
        /// <summary>
        /// Cached name for the 'volumetric_fog_temporal_reprojection_amount' property.
        /// </summary>
        public static readonly StringName VolumetricFogTemporalReprojectionAmount = "volumetric_fog_temporal_reprojection_amount";
        /// <summary>
        /// Cached name for the 'adjustment_enabled' property.
        /// </summary>
        public static readonly StringName AdjustmentEnabled = "adjustment_enabled";
        /// <summary>
        /// Cached name for the 'adjustment_brightness' property.
        /// </summary>
        public static readonly StringName AdjustmentBrightness = "adjustment_brightness";
        /// <summary>
        /// Cached name for the 'adjustment_contrast' property.
        /// </summary>
        public static readonly StringName AdjustmentContrast = "adjustment_contrast";
        /// <summary>
        /// Cached name for the 'adjustment_saturation' property.
        /// </summary>
        public static readonly StringName AdjustmentSaturation = "adjustment_saturation";
        /// <summary>
        /// Cached name for the 'adjustment_color_correction' property.
        /// </summary>
        public static readonly StringName AdjustmentColorCorrection = "adjustment_color_correction";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_background' method.
        /// </summary>
        public static readonly StringName SetBackground = "set_background";
        /// <summary>
        /// Cached name for the 'get_background' method.
        /// </summary>
        public static readonly StringName GetBackground = "get_background";
        /// <summary>
        /// Cached name for the 'set_sky' method.
        /// </summary>
        public static readonly StringName SetSky = "set_sky";
        /// <summary>
        /// Cached name for the 'get_sky' method.
        /// </summary>
        public static readonly StringName GetSky = "get_sky";
        /// <summary>
        /// Cached name for the 'set_sky_custom_fov' method.
        /// </summary>
        public static readonly StringName SetSkyCustomFov = "set_sky_custom_fov";
        /// <summary>
        /// Cached name for the 'get_sky_custom_fov' method.
        /// </summary>
        public static readonly StringName GetSkyCustomFov = "get_sky_custom_fov";
        /// <summary>
        /// Cached name for the 'set_sky_rotation' method.
        /// </summary>
        public static readonly StringName SetSkyRotation = "set_sky_rotation";
        /// <summary>
        /// Cached name for the 'get_sky_rotation' method.
        /// </summary>
        public static readonly StringName GetSkyRotation = "get_sky_rotation";
        /// <summary>
        /// Cached name for the 'set_bg_color' method.
        /// </summary>
        public static readonly StringName SetBgColor = "set_bg_color";
        /// <summary>
        /// Cached name for the 'get_bg_color' method.
        /// </summary>
        public static readonly StringName GetBgColor = "get_bg_color";
        /// <summary>
        /// Cached name for the 'set_bg_energy_multiplier' method.
        /// </summary>
        public static readonly StringName SetBgEnergyMultiplier = "set_bg_energy_multiplier";
        /// <summary>
        /// Cached name for the 'get_bg_energy_multiplier' method.
        /// </summary>
        public static readonly StringName GetBgEnergyMultiplier = "get_bg_energy_multiplier";
        /// <summary>
        /// Cached name for the 'set_bg_intensity' method.
        /// </summary>
        public static readonly StringName SetBgIntensity = "set_bg_intensity";
        /// <summary>
        /// Cached name for the 'get_bg_intensity' method.
        /// </summary>
        public static readonly StringName GetBgIntensity = "get_bg_intensity";
        /// <summary>
        /// Cached name for the 'set_canvas_max_layer' method.
        /// </summary>
        public static readonly StringName SetCanvasMaxLayer = "set_canvas_max_layer";
        /// <summary>
        /// Cached name for the 'get_canvas_max_layer' method.
        /// </summary>
        public static readonly StringName GetCanvasMaxLayer = "get_canvas_max_layer";
        /// <summary>
        /// Cached name for the 'set_camera_feed_id' method.
        /// </summary>
        public static readonly StringName SetCameraFeedId = "set_camera_feed_id";
        /// <summary>
        /// Cached name for the 'get_camera_feed_id' method.
        /// </summary>
        public static readonly StringName GetCameraFeedId = "get_camera_feed_id";
        /// <summary>
        /// Cached name for the 'set_ambient_light_color' method.
        /// </summary>
        public static readonly StringName SetAmbientLightColor = "set_ambient_light_color";
        /// <summary>
        /// Cached name for the 'get_ambient_light_color' method.
        /// </summary>
        public static readonly StringName GetAmbientLightColor = "get_ambient_light_color";
        /// <summary>
        /// Cached name for the 'set_ambient_source' method.
        /// </summary>
        public static readonly StringName SetAmbientSource = "set_ambient_source";
        /// <summary>
        /// Cached name for the 'get_ambient_source' method.
        /// </summary>
        public static readonly StringName GetAmbientSource = "get_ambient_source";
        /// <summary>
        /// Cached name for the 'set_ambient_light_energy' method.
        /// </summary>
        public static readonly StringName SetAmbientLightEnergy = "set_ambient_light_energy";
        /// <summary>
        /// Cached name for the 'get_ambient_light_energy' method.
        /// </summary>
        public static readonly StringName GetAmbientLightEnergy = "get_ambient_light_energy";
        /// <summary>
        /// Cached name for the 'set_ambient_light_sky_contribution' method.
        /// </summary>
        public static readonly StringName SetAmbientLightSkyContribution = "set_ambient_light_sky_contribution";
        /// <summary>
        /// Cached name for the 'get_ambient_light_sky_contribution' method.
        /// </summary>
        public static readonly StringName GetAmbientLightSkyContribution = "get_ambient_light_sky_contribution";
        /// <summary>
        /// Cached name for the 'set_reflection_source' method.
        /// </summary>
        public static readonly StringName SetReflectionSource = "set_reflection_source";
        /// <summary>
        /// Cached name for the 'get_reflection_source' method.
        /// </summary>
        public static readonly StringName GetReflectionSource = "get_reflection_source";
        /// <summary>
        /// Cached name for the 'set_tonemapper' method.
        /// </summary>
        public static readonly StringName SetTonemapper = "set_tonemapper";
        /// <summary>
        /// Cached name for the 'get_tonemapper' method.
        /// </summary>
        public static readonly StringName GetTonemapper = "get_tonemapper";
        /// <summary>
        /// Cached name for the 'set_tonemap_exposure' method.
        /// </summary>
        public static readonly StringName SetTonemapExposure = "set_tonemap_exposure";
        /// <summary>
        /// Cached name for the 'get_tonemap_exposure' method.
        /// </summary>
        public static readonly StringName GetTonemapExposure = "get_tonemap_exposure";
        /// <summary>
        /// Cached name for the 'set_tonemap_white' method.
        /// </summary>
        public static readonly StringName SetTonemapWhite = "set_tonemap_white";
        /// <summary>
        /// Cached name for the 'get_tonemap_white' method.
        /// </summary>
        public static readonly StringName GetTonemapWhite = "get_tonemap_white";
        /// <summary>
        /// Cached name for the 'set_tonemap_agx_white' method.
        /// </summary>
        public static readonly StringName SetTonemapAgxWhite = "set_tonemap_agx_white";
        /// <summary>
        /// Cached name for the 'get_tonemap_agx_white' method.
        /// </summary>
        public static readonly StringName GetTonemapAgxWhite = "get_tonemap_agx_white";
        /// <summary>
        /// Cached name for the 'set_tonemap_agx_contrast' method.
        /// </summary>
        public static readonly StringName SetTonemapAgxContrast = "set_tonemap_agx_contrast";
        /// <summary>
        /// Cached name for the 'get_tonemap_agx_contrast' method.
        /// </summary>
        public static readonly StringName GetTonemapAgxContrast = "get_tonemap_agx_contrast";
        /// <summary>
        /// Cached name for the 'set_ssr_enabled' method.
        /// </summary>
        public static readonly StringName SetSsrEnabled = "set_ssr_enabled";
        /// <summary>
        /// Cached name for the 'is_ssr_enabled' method.
        /// </summary>
        public static readonly StringName IsSsrEnabled = "is_ssr_enabled";
        /// <summary>
        /// Cached name for the 'set_ssr_max_steps' method.
        /// </summary>
        public static readonly StringName SetSsrMaxSteps = "set_ssr_max_steps";
        /// <summary>
        /// Cached name for the 'get_ssr_max_steps' method.
        /// </summary>
        public static readonly StringName GetSsrMaxSteps = "get_ssr_max_steps";
        /// <summary>
        /// Cached name for the 'set_ssr_fade_in' method.
        /// </summary>
        public static readonly StringName SetSsrFadeIn = "set_ssr_fade_in";
        /// <summary>
        /// Cached name for the 'get_ssr_fade_in' method.
        /// </summary>
        public static readonly StringName GetSsrFadeIn = "get_ssr_fade_in";
        /// <summary>
        /// Cached name for the 'set_ssr_fade_out' method.
        /// </summary>
        public static readonly StringName SetSsrFadeOut = "set_ssr_fade_out";
        /// <summary>
        /// Cached name for the 'get_ssr_fade_out' method.
        /// </summary>
        public static readonly StringName GetSsrFadeOut = "get_ssr_fade_out";
        /// <summary>
        /// Cached name for the 'set_ssr_depth_tolerance' method.
        /// </summary>
        public static readonly StringName SetSsrDepthTolerance = "set_ssr_depth_tolerance";
        /// <summary>
        /// Cached name for the 'get_ssr_depth_tolerance' method.
        /// </summary>
        public static readonly StringName GetSsrDepthTolerance = "get_ssr_depth_tolerance";
        /// <summary>
        /// Cached name for the 'set_ssao_enabled' method.
        /// </summary>
        public static readonly StringName SetSsaoEnabled = "set_ssao_enabled";
        /// <summary>
        /// Cached name for the 'is_ssao_enabled' method.
        /// </summary>
        public static readonly StringName IsSsaoEnabled = "is_ssao_enabled";
        /// <summary>
        /// Cached name for the 'set_ssao_radius' method.
        /// </summary>
        public static readonly StringName SetSsaoRadius = "set_ssao_radius";
        /// <summary>
        /// Cached name for the 'get_ssao_radius' method.
        /// </summary>
        public static readonly StringName GetSsaoRadius = "get_ssao_radius";
        /// <summary>
        /// Cached name for the 'set_ssao_intensity' method.
        /// </summary>
        public static readonly StringName SetSsaoIntensity = "set_ssao_intensity";
        /// <summary>
        /// Cached name for the 'get_ssao_intensity' method.
        /// </summary>
        public static readonly StringName GetSsaoIntensity = "get_ssao_intensity";
        /// <summary>
        /// Cached name for the 'set_ssao_power' method.
        /// </summary>
        public static readonly StringName SetSsaoPower = "set_ssao_power";
        /// <summary>
        /// Cached name for the 'get_ssao_power' method.
        /// </summary>
        public static readonly StringName GetSsaoPower = "get_ssao_power";
        /// <summary>
        /// Cached name for the 'set_ssao_detail' method.
        /// </summary>
        public static readonly StringName SetSsaoDetail = "set_ssao_detail";
        /// <summary>
        /// Cached name for the 'get_ssao_detail' method.
        /// </summary>
        public static readonly StringName GetSsaoDetail = "get_ssao_detail";
        /// <summary>
        /// Cached name for the 'set_ssao_horizon' method.
        /// </summary>
        public static readonly StringName SetSsaoHorizon = "set_ssao_horizon";
        /// <summary>
        /// Cached name for the 'get_ssao_horizon' method.
        /// </summary>
        public static readonly StringName GetSsaoHorizon = "get_ssao_horizon";
        /// <summary>
        /// Cached name for the 'set_ssao_sharpness' method.
        /// </summary>
        public static readonly StringName SetSsaoSharpness = "set_ssao_sharpness";
        /// <summary>
        /// Cached name for the 'get_ssao_sharpness' method.
        /// </summary>
        public static readonly StringName GetSsaoSharpness = "get_ssao_sharpness";
        /// <summary>
        /// Cached name for the 'set_ssao_direct_light_affect' method.
        /// </summary>
        public static readonly StringName SetSsaoDirectLightAffect = "set_ssao_direct_light_affect";
        /// <summary>
        /// Cached name for the 'get_ssao_direct_light_affect' method.
        /// </summary>
        public static readonly StringName GetSsaoDirectLightAffect = "get_ssao_direct_light_affect";
        /// <summary>
        /// Cached name for the 'set_ssao_ao_channel_affect' method.
        /// </summary>
        public static readonly StringName SetSsaoAOChannelAffect = "set_ssao_ao_channel_affect";
        /// <summary>
        /// Cached name for the 'get_ssao_ao_channel_affect' method.
        /// </summary>
        public static readonly StringName GetSsaoAOChannelAffect = "get_ssao_ao_channel_affect";
        /// <summary>
        /// Cached name for the 'set_ssil_enabled' method.
        /// </summary>
        public static readonly StringName SetSsilEnabled = "set_ssil_enabled";
        /// <summary>
        /// Cached name for the 'is_ssil_enabled' method.
        /// </summary>
        public static readonly StringName IsSsilEnabled = "is_ssil_enabled";
        /// <summary>
        /// Cached name for the 'set_ssil_radius' method.
        /// </summary>
        public static readonly StringName SetSsilRadius = "set_ssil_radius";
        /// <summary>
        /// Cached name for the 'get_ssil_radius' method.
        /// </summary>
        public static readonly StringName GetSsilRadius = "get_ssil_radius";
        /// <summary>
        /// Cached name for the 'set_ssil_intensity' method.
        /// </summary>
        public static readonly StringName SetSsilIntensity = "set_ssil_intensity";
        /// <summary>
        /// Cached name for the 'get_ssil_intensity' method.
        /// </summary>
        public static readonly StringName GetSsilIntensity = "get_ssil_intensity";
        /// <summary>
        /// Cached name for the 'set_ssil_sharpness' method.
        /// </summary>
        public static readonly StringName SetSsilSharpness = "set_ssil_sharpness";
        /// <summary>
        /// Cached name for the 'get_ssil_sharpness' method.
        /// </summary>
        public static readonly StringName GetSsilSharpness = "get_ssil_sharpness";
        /// <summary>
        /// Cached name for the 'set_ssil_normal_rejection' method.
        /// </summary>
        public static readonly StringName SetSsilNormalRejection = "set_ssil_normal_rejection";
        /// <summary>
        /// Cached name for the 'get_ssil_normal_rejection' method.
        /// </summary>
        public static readonly StringName GetSsilNormalRejection = "get_ssil_normal_rejection";
        /// <summary>
        /// Cached name for the 'set_sdfgi_enabled' method.
        /// </summary>
        public static readonly StringName SetSdfgiEnabled = "set_sdfgi_enabled";
        /// <summary>
        /// Cached name for the 'is_sdfgi_enabled' method.
        /// </summary>
        public static readonly StringName IsSdfgiEnabled = "is_sdfgi_enabled";
        /// <summary>
        /// Cached name for the 'set_sdfgi_cascades' method.
        /// </summary>
        public static readonly StringName SetSdfgiCascades = "set_sdfgi_cascades";
        /// <summary>
        /// Cached name for the 'get_sdfgi_cascades' method.
        /// </summary>
        public static readonly StringName GetSdfgiCascades = "get_sdfgi_cascades";
        /// <summary>
        /// Cached name for the 'set_sdfgi_min_cell_size' method.
        /// </summary>
        public static readonly StringName SetSdfgiMinCellSize = "set_sdfgi_min_cell_size";
        /// <summary>
        /// Cached name for the 'get_sdfgi_min_cell_size' method.
        /// </summary>
        public static readonly StringName GetSdfgiMinCellSize = "get_sdfgi_min_cell_size";
        /// <summary>
        /// Cached name for the 'set_sdfgi_max_distance' method.
        /// </summary>
        public static readonly StringName SetSdfgiMaxDistance = "set_sdfgi_max_distance";
        /// <summary>
        /// Cached name for the 'get_sdfgi_max_distance' method.
        /// </summary>
        public static readonly StringName GetSdfgiMaxDistance = "get_sdfgi_max_distance";
        /// <summary>
        /// Cached name for the 'set_sdfgi_cascade0_distance' method.
        /// </summary>
        public static readonly StringName SetSdfgiCascade0Distance = "set_sdfgi_cascade0_distance";
        /// <summary>
        /// Cached name for the 'get_sdfgi_cascade0_distance' method.
        /// </summary>
        public static readonly StringName GetSdfgiCascade0Distance = "get_sdfgi_cascade0_distance";
        /// <summary>
        /// Cached name for the 'set_sdfgi_y_scale' method.
        /// </summary>
        public static readonly StringName SetSdfgiYScale = "set_sdfgi_y_scale";
        /// <summary>
        /// Cached name for the 'get_sdfgi_y_scale' method.
        /// </summary>
        public static readonly StringName GetSdfgiYScale = "get_sdfgi_y_scale";
        /// <summary>
        /// Cached name for the 'set_sdfgi_use_occlusion' method.
        /// </summary>
        public static readonly StringName SetSdfgiUseOcclusion = "set_sdfgi_use_occlusion";
        /// <summary>
        /// Cached name for the 'is_sdfgi_using_occlusion' method.
        /// </summary>
        public static readonly StringName IsSdfgiUsingOcclusion = "is_sdfgi_using_occlusion";
        /// <summary>
        /// Cached name for the 'set_sdfgi_bounce_feedback' method.
        /// </summary>
        public static readonly StringName SetSdfgiBounceFeedback = "set_sdfgi_bounce_feedback";
        /// <summary>
        /// Cached name for the 'get_sdfgi_bounce_feedback' method.
        /// </summary>
        public static readonly StringName GetSdfgiBounceFeedback = "get_sdfgi_bounce_feedback";
        /// <summary>
        /// Cached name for the 'set_sdfgi_read_sky_light' method.
        /// </summary>
        public static readonly StringName SetSdfgiReadSkyLight = "set_sdfgi_read_sky_light";
        /// <summary>
        /// Cached name for the 'is_sdfgi_reading_sky_light' method.
        /// </summary>
        public static readonly StringName IsSdfgiReadingSkyLight = "is_sdfgi_reading_sky_light";
        /// <summary>
        /// Cached name for the 'set_sdfgi_energy' method.
        /// </summary>
        public static readonly StringName SetSdfgiEnergy = "set_sdfgi_energy";
        /// <summary>
        /// Cached name for the 'get_sdfgi_energy' method.
        /// </summary>
        public static readonly StringName GetSdfgiEnergy = "get_sdfgi_energy";
        /// <summary>
        /// Cached name for the 'set_sdfgi_normal_bias' method.
        /// </summary>
        public static readonly StringName SetSdfgiNormalBias = "set_sdfgi_normal_bias";
        /// <summary>
        /// Cached name for the 'get_sdfgi_normal_bias' method.
        /// </summary>
        public static readonly StringName GetSdfgiNormalBias = "get_sdfgi_normal_bias";
        /// <summary>
        /// Cached name for the 'set_sdfgi_probe_bias' method.
        /// </summary>
        public static readonly StringName SetSdfgiProbeBias = "set_sdfgi_probe_bias";
        /// <summary>
        /// Cached name for the 'get_sdfgi_probe_bias' method.
        /// </summary>
        public static readonly StringName GetSdfgiProbeBias = "get_sdfgi_probe_bias";
        /// <summary>
        /// Cached name for the 'set_glow_enabled' method.
        /// </summary>
        public static readonly StringName SetGlowEnabled = "set_glow_enabled";
        /// <summary>
        /// Cached name for the 'is_glow_enabled' method.
        /// </summary>
        public static readonly StringName IsGlowEnabled = "is_glow_enabled";
        /// <summary>
        /// Cached name for the 'set_glow_level' method.
        /// </summary>
        public static readonly StringName SetGlowLevel = "set_glow_level";
        /// <summary>
        /// Cached name for the 'get_glow_level' method.
        /// </summary>
        public static readonly StringName GetGlowLevel = "get_glow_level";
        /// <summary>
        /// Cached name for the 'set_glow_normalized' method.
        /// </summary>
        public static readonly StringName SetGlowNormalized = "set_glow_normalized";
        /// <summary>
        /// Cached name for the 'is_glow_normalized' method.
        /// </summary>
        public static readonly StringName IsGlowNormalized = "is_glow_normalized";
        /// <summary>
        /// Cached name for the 'set_glow_intensity' method.
        /// </summary>
        public static readonly StringName SetGlowIntensity = "set_glow_intensity";
        /// <summary>
        /// Cached name for the 'get_glow_intensity' method.
        /// </summary>
        public static readonly StringName GetGlowIntensity = "get_glow_intensity";
        /// <summary>
        /// Cached name for the 'set_glow_strength' method.
        /// </summary>
        public static readonly StringName SetGlowStrength = "set_glow_strength";
        /// <summary>
        /// Cached name for the 'get_glow_strength' method.
        /// </summary>
        public static readonly StringName GetGlowStrength = "get_glow_strength";
        /// <summary>
        /// Cached name for the 'set_glow_mix' method.
        /// </summary>
        public static readonly StringName SetGlowMix = "set_glow_mix";
        /// <summary>
        /// Cached name for the 'get_glow_mix' method.
        /// </summary>
        public static readonly StringName GetGlowMix = "get_glow_mix";
        /// <summary>
        /// Cached name for the 'set_glow_bloom' method.
        /// </summary>
        public static readonly StringName SetGlowBloom = "set_glow_bloom";
        /// <summary>
        /// Cached name for the 'get_glow_bloom' method.
        /// </summary>
        public static readonly StringName GetGlowBloom = "get_glow_bloom";
        /// <summary>
        /// Cached name for the 'set_glow_blend_mode' method.
        /// </summary>
        public static readonly StringName SetGlowBlendMode = "set_glow_blend_mode";
        /// <summary>
        /// Cached name for the 'get_glow_blend_mode' method.
        /// </summary>
        public static readonly StringName GetGlowBlendMode = "get_glow_blend_mode";
        /// <summary>
        /// Cached name for the 'set_glow_hdr_bleed_threshold' method.
        /// </summary>
        public static readonly StringName SetGlowHdrBleedThreshold = "set_glow_hdr_bleed_threshold";
        /// <summary>
        /// Cached name for the 'get_glow_hdr_bleed_threshold' method.
        /// </summary>
        public static readonly StringName GetGlowHdrBleedThreshold = "get_glow_hdr_bleed_threshold";
        /// <summary>
        /// Cached name for the 'set_glow_hdr_bleed_scale' method.
        /// </summary>
        public static readonly StringName SetGlowHdrBleedScale = "set_glow_hdr_bleed_scale";
        /// <summary>
        /// Cached name for the 'get_glow_hdr_bleed_scale' method.
        /// </summary>
        public static readonly StringName GetGlowHdrBleedScale = "get_glow_hdr_bleed_scale";
        /// <summary>
        /// Cached name for the 'set_glow_hdr_luminance_cap' method.
        /// </summary>
        public static readonly StringName SetGlowHdrLuminanceCap = "set_glow_hdr_luminance_cap";
        /// <summary>
        /// Cached name for the 'get_glow_hdr_luminance_cap' method.
        /// </summary>
        public static readonly StringName GetGlowHdrLuminanceCap = "get_glow_hdr_luminance_cap";
        /// <summary>
        /// Cached name for the 'set_glow_map_strength' method.
        /// </summary>
        public static readonly StringName SetGlowMapStrength = "set_glow_map_strength";
        /// <summary>
        /// Cached name for the 'get_glow_map_strength' method.
        /// </summary>
        public static readonly StringName GetGlowMapStrength = "get_glow_map_strength";
        /// <summary>
        /// Cached name for the 'set_glow_map' method.
        /// </summary>
        public static readonly StringName SetGlowMap = "set_glow_map";
        /// <summary>
        /// Cached name for the 'get_glow_map' method.
        /// </summary>
        public static readonly StringName GetGlowMap = "get_glow_map";
        /// <summary>
        /// Cached name for the 'set_fog_enabled' method.
        /// </summary>
        public static readonly StringName SetFogEnabled = "set_fog_enabled";
        /// <summary>
        /// Cached name for the 'is_fog_enabled' method.
        /// </summary>
        public static readonly StringName IsFogEnabled = "is_fog_enabled";
        /// <summary>
        /// Cached name for the 'set_fog_mode' method.
        /// </summary>
        public static readonly StringName SetFogMode = "set_fog_mode";
        /// <summary>
        /// Cached name for the 'get_fog_mode' method.
        /// </summary>
        public static readonly StringName GetFogMode = "get_fog_mode";
        /// <summary>
        /// Cached name for the 'set_fog_light_color' method.
        /// </summary>
        public static readonly StringName SetFogLightColor = "set_fog_light_color";
        /// <summary>
        /// Cached name for the 'get_fog_light_color' method.
        /// </summary>
        public static readonly StringName GetFogLightColor = "get_fog_light_color";
        /// <summary>
        /// Cached name for the 'set_fog_light_energy' method.
        /// </summary>
        public static readonly StringName SetFogLightEnergy = "set_fog_light_energy";
        /// <summary>
        /// Cached name for the 'get_fog_light_energy' method.
        /// </summary>
        public static readonly StringName GetFogLightEnergy = "get_fog_light_energy";
        /// <summary>
        /// Cached name for the 'set_fog_sun_scatter' method.
        /// </summary>
        public static readonly StringName SetFogSunScatter = "set_fog_sun_scatter";
        /// <summary>
        /// Cached name for the 'get_fog_sun_scatter' method.
        /// </summary>
        public static readonly StringName GetFogSunScatter = "get_fog_sun_scatter";
        /// <summary>
        /// Cached name for the 'set_fog_density' method.
        /// </summary>
        public static readonly StringName SetFogDensity = "set_fog_density";
        /// <summary>
        /// Cached name for the 'get_fog_density' method.
        /// </summary>
        public static readonly StringName GetFogDensity = "get_fog_density";
        /// <summary>
        /// Cached name for the 'set_fog_height' method.
        /// </summary>
        public static readonly StringName SetFogHeight = "set_fog_height";
        /// <summary>
        /// Cached name for the 'get_fog_height' method.
        /// </summary>
        public static readonly StringName GetFogHeight = "get_fog_height";
        /// <summary>
        /// Cached name for the 'set_fog_height_density' method.
        /// </summary>
        public static readonly StringName SetFogHeightDensity = "set_fog_height_density";
        /// <summary>
        /// Cached name for the 'get_fog_height_density' method.
        /// </summary>
        public static readonly StringName GetFogHeightDensity = "get_fog_height_density";
        /// <summary>
        /// Cached name for the 'set_fog_aerial_perspective' method.
        /// </summary>
        public static readonly StringName SetFogAerialPerspective = "set_fog_aerial_perspective";
        /// <summary>
        /// Cached name for the 'get_fog_aerial_perspective' method.
        /// </summary>
        public static readonly StringName GetFogAerialPerspective = "get_fog_aerial_perspective";
        /// <summary>
        /// Cached name for the 'set_fog_sky_affect' method.
        /// </summary>
        public static readonly StringName SetFogSkyAffect = "set_fog_sky_affect";
        /// <summary>
        /// Cached name for the 'get_fog_sky_affect' method.
        /// </summary>
        public static readonly StringName GetFogSkyAffect = "get_fog_sky_affect";
        /// <summary>
        /// Cached name for the 'set_fog_depth_curve' method.
        /// </summary>
        public static readonly StringName SetFogDepthCurve = "set_fog_depth_curve";
        /// <summary>
        /// Cached name for the 'get_fog_depth_curve' method.
        /// </summary>
        public static readonly StringName GetFogDepthCurve = "get_fog_depth_curve";
        /// <summary>
        /// Cached name for the 'set_fog_depth_begin' method.
        /// </summary>
        public static readonly StringName SetFogDepthBegin = "set_fog_depth_begin";
        /// <summary>
        /// Cached name for the 'get_fog_depth_begin' method.
        /// </summary>
        public static readonly StringName GetFogDepthBegin = "get_fog_depth_begin";
        /// <summary>
        /// Cached name for the 'set_fog_depth_end' method.
        /// </summary>
        public static readonly StringName SetFogDepthEnd = "set_fog_depth_end";
        /// <summary>
        /// Cached name for the 'get_fog_depth_end' method.
        /// </summary>
        public static readonly StringName GetFogDepthEnd = "get_fog_depth_end";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_enabled' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogEnabled = "set_volumetric_fog_enabled";
        /// <summary>
        /// Cached name for the 'is_volumetric_fog_enabled' method.
        /// </summary>
        public static readonly StringName IsVolumetricFogEnabled = "is_volumetric_fog_enabled";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_emission' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogEmission = "set_volumetric_fog_emission";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_emission' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogEmission = "get_volumetric_fog_emission";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_albedo' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogAlbedo = "set_volumetric_fog_albedo";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_albedo' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogAlbedo = "get_volumetric_fog_albedo";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_density' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogDensity = "set_volumetric_fog_density";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_density' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogDensity = "get_volumetric_fog_density";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_emission_energy' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogEmissionEnergy = "set_volumetric_fog_emission_energy";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_emission_energy' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogEmissionEnergy = "get_volumetric_fog_emission_energy";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_anisotropy' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogAnisotropy = "set_volumetric_fog_anisotropy";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_anisotropy' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogAnisotropy = "get_volumetric_fog_anisotropy";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_length' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogLength = "set_volumetric_fog_length";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_length' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogLength = "get_volumetric_fog_length";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_detail_spread' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogDetailSpread = "set_volumetric_fog_detail_spread";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_detail_spread' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogDetailSpread = "get_volumetric_fog_detail_spread";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_gi_inject' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogGIInject = "set_volumetric_fog_gi_inject";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_gi_inject' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogGIInject = "get_volumetric_fog_gi_inject";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_ambient_inject' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogAmbientInject = "set_volumetric_fog_ambient_inject";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_ambient_inject' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogAmbientInject = "get_volumetric_fog_ambient_inject";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_sky_affect' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogSkyAffect = "set_volumetric_fog_sky_affect";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_sky_affect' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogSkyAffect = "get_volumetric_fog_sky_affect";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_temporal_reprojection_enabled' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogTemporalReprojectionEnabled = "set_volumetric_fog_temporal_reprojection_enabled";
        /// <summary>
        /// Cached name for the 'is_volumetric_fog_temporal_reprojection_enabled' method.
        /// </summary>
        public static readonly StringName IsVolumetricFogTemporalReprojectionEnabled = "is_volumetric_fog_temporal_reprojection_enabled";
        /// <summary>
        /// Cached name for the 'set_volumetric_fog_temporal_reprojection_amount' method.
        /// </summary>
        public static readonly StringName SetVolumetricFogTemporalReprojectionAmount = "set_volumetric_fog_temporal_reprojection_amount";
        /// <summary>
        /// Cached name for the 'get_volumetric_fog_temporal_reprojection_amount' method.
        /// </summary>
        public static readonly StringName GetVolumetricFogTemporalReprojectionAmount = "get_volumetric_fog_temporal_reprojection_amount";
        /// <summary>
        /// Cached name for the 'set_adjustment_enabled' method.
        /// </summary>
        public static readonly StringName SetAdjustmentEnabled = "set_adjustment_enabled";
        /// <summary>
        /// Cached name for the 'is_adjustment_enabled' method.
        /// </summary>
        public static readonly StringName IsAdjustmentEnabled = "is_adjustment_enabled";
        /// <summary>
        /// Cached name for the 'set_adjustment_brightness' method.
        /// </summary>
        public static readonly StringName SetAdjustmentBrightness = "set_adjustment_brightness";
        /// <summary>
        /// Cached name for the 'get_adjustment_brightness' method.
        /// </summary>
        public static readonly StringName GetAdjustmentBrightness = "get_adjustment_brightness";
        /// <summary>
        /// Cached name for the 'set_adjustment_contrast' method.
        /// </summary>
        public static readonly StringName SetAdjustmentContrast = "set_adjustment_contrast";
        /// <summary>
        /// Cached name for the 'get_adjustment_contrast' method.
        /// </summary>
        public static readonly StringName GetAdjustmentContrast = "get_adjustment_contrast";
        /// <summary>
        /// Cached name for the 'set_adjustment_saturation' method.
        /// </summary>
        public static readonly StringName SetAdjustmentSaturation = "set_adjustment_saturation";
        /// <summary>
        /// Cached name for the 'get_adjustment_saturation' method.
        /// </summary>
        public static readonly StringName GetAdjustmentSaturation = "get_adjustment_saturation";
        /// <summary>
        /// Cached name for the 'set_adjustment_color_correction' method.
        /// </summary>
        public static readonly StringName SetAdjustmentColorCorrection = "set_adjustment_color_correction";
        /// <summary>
        /// Cached name for the 'get_adjustment_color_correction' method.
        /// </summary>
        public static readonly StringName GetAdjustmentColorCorrection = "get_adjustment_color_correction";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
