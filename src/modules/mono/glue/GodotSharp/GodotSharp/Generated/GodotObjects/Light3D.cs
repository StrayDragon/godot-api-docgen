namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Light3D is the <i>abstract</i> base class for light nodes. As it can't be instantiated, it shouldn't be used directly. Other types of light nodes inherit from it. Light3D contains the common variables and parameters used for lighting.</para>
/// </summary>
public partial class Light3D : VisualInstance3D
{
    public enum Param : long
    {
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.LightEnergy"/>.</para>
        /// </summary>
        Energy = 0,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.LightIndirectEnergy"/>.</para>
        /// </summary>
        IndirectEnergy = 1,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.LightVolumetricFogEnergy"/>.</para>
        /// </summary>
        VolumetricFogEnergy = 2,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.LightSpecular"/>.</para>
        /// </summary>
        Specular = 3,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.OmniLight3D.OmniRange"/> or <see cref="Godot.SpotLight3D.SpotRange"/>.</para>
        /// </summary>
        Range = 4,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.LightSize"/>.</para>
        /// </summary>
        Size = 5,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.OmniLight3D.OmniAttenuation"/> or <see cref="Godot.SpotLight3D.SpotAttenuation"/>.</para>
        /// </summary>
        Attenuation = 6,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.SpotLight3D.SpotAngle"/>.</para>
        /// </summary>
        SpotAngle = 7,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.SpotLight3D.SpotAngleAttenuation"/>.</para>
        /// </summary>
        SpotAttenuation = 8,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.DirectionalLight3D.DirectionalShadowMaxDistance"/>.</para>
        /// </summary>
        ShadowMaxDistance = 9,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.DirectionalLight3D.DirectionalShadowSplit1"/>.</para>
        /// </summary>
        ShadowSplit1Offset = 10,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.DirectionalLight3D.DirectionalShadowSplit2"/>.</para>
        /// </summary>
        ShadowSplit2Offset = 11,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.DirectionalLight3D.DirectionalShadowSplit3"/>.</para>
        /// </summary>
        ShadowSplit3Offset = 12,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.DirectionalLight3D.DirectionalShadowFadeStart"/>.</para>
        /// </summary>
        ShadowFadeStart = 13,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.ShadowNormalBias"/>.</para>
        /// </summary>
        ShadowNormalBias = 14,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.ShadowBias"/>.</para>
        /// </summary>
        ShadowBias = 15,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.DirectionalLight3D.DirectionalShadowPancakeSize"/>.</para>
        /// </summary>
        ShadowPancakeSize = 16,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.ShadowOpacity"/>.</para>
        /// </summary>
        ShadowOpacity = 17,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.ShadowBlur"/>.</para>
        /// </summary>
        ShadowBlur = 18,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.ShadowTransmittanceBias"/>.</para>
        /// </summary>
        TransmittanceBias = 19,
        /// <summary>
        /// <para>Constant for accessing <see cref="Godot.Light3D.LightIntensityLumens"/> and <see cref="Godot.Light3D.LightIntensityLux"/>. Only used when <c>ProjectSettings.rendering/lights_and_shadows/use_physical_light_units</c> is <see langword="true"/>.</para>
        /// </summary>
        Intensity = 20,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Light3D.Param"/> enum.</para>
        /// </summary>
        Max = 21
    }

    public enum BakeMode : long
    {
        /// <summary>
        /// <para>Light is ignored when baking. This is the fastest mode, but the light will not be taken into account when baking global illumination. This mode should generally be used for dynamic lights that change quickly, as the effect of global illumination is less noticeable on those lights.</para>
        /// <para><b>Note:</b> Hiding a light does <i>not</i> affect baking <see cref="Godot.LightmapGI"/>. Hiding a light will still affect baking <see cref="Godot.VoxelGI"/> and SDFGI (see <see cref="Godot.Environment.SdfgiEnabled"/>).</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Light is taken into account in static baking (<see cref="Godot.VoxelGI"/>, <see cref="Godot.LightmapGI"/>, SDFGI (<see cref="Godot.Environment.SdfgiEnabled"/>)). The light can be moved around or modified, but its global illumination will not update in real-time. This is suitable for subtle changes (such as flickering torches), but generally not large changes such as toggling a light on and off.</para>
        /// <para><b>Note:</b> The light is not baked in <see cref="Godot.LightmapGI"/> if <see cref="Godot.Light3D.EditorOnly"/> is <see langword="true"/>.</para>
        /// </summary>
        Static = 1,
        /// <summary>
        /// <para>Light is taken into account in dynamic baking (<see cref="Godot.VoxelGI"/> and SDFGI (<see cref="Godot.Environment.SdfgiEnabled"/>) only). The light can be moved around or modified with global illumination updating in real-time. The light's global illumination appearance will be slightly different compared to <see cref="Godot.Light3D.BakeMode.Static"/>. This has a greater performance cost compared to <see cref="Godot.Light3D.BakeMode.Static"/>. When using SDFGI, the update speed of dynamic lights is affected by <c>ProjectSettings.rendering/global_illumination/sdfgi/frames_to_update_lights</c>.</para>
        /// </summary>
        Dynamic = 2
    }

    /// <summary>
    /// <para>Used by positional lights (<see cref="Godot.OmniLight3D"/> and <see cref="Godot.SpotLight3D"/>) when <c>ProjectSettings.rendering/lights_and_shadows/use_physical_light_units</c> is <see langword="true"/>. Sets the intensity of the light source measured in Lumens. Lumens are a measure of luminous flux, which is the total amount of visible light emitted by a light source per unit of time.</para>
    /// <para>For <see cref="Godot.SpotLight3D"/>s, we assume that the area outside the visible cone is surrounded by a perfect light absorbing material. Accordingly, the apparent brightness of the cone area does not change as the cone increases and decreases in size.</para>
    /// <para>A typical household lightbulb can range from around 600 lumens to 1,200 lumens, a candle is about 13 lumens, while a streetlight can be approximately 60,000 lumens.</para>
    /// </summary>
    public float LightIntensityLumens
    {
        get
        {
            return GetParam((Light3D.Param)(20));
        }
        set
        {
            SetParam((Light3D.Param)(20), value);
        }
    }

    /// <summary>
    /// <para>Used by <see cref="Godot.DirectionalLight3D"/>s when <c>ProjectSettings.rendering/lights_and_shadows/use_physical_light_units</c> is <see langword="true"/>. Sets the intensity of the light source measured in Lux. Lux is a measure of luminous flux per unit area, it is equal to one lumen per square meter. Lux is the measure of how much light hits a surface at a given time.</para>
    /// <para>On a clear sunny day a surface in direct sunlight may be approximately 100,000 lux, a typical room in a home may be approximately 50 lux, while the moonlit ground may be approximately 0.1 lux.</para>
    /// </summary>
    public float LightIntensityLux
    {
        get
        {
            return GetParam((Light3D.Param)(20));
        }
        set
        {
            SetParam((Light3D.Param)(20), value);
        }
    }

    /// <summary>
    /// <para>Sets the color temperature of the light source, measured in Kelvin. This is used to calculate a correlated color temperature which tints the <see cref="Godot.Light3D.LightColor"/>.</para>
    /// <para>The sun on a cloudy day is approximately 6500 Kelvin, on a clear day it is between 5500 to 6000 Kelvin, and on a clear day at sunrise or sunset it ranges to around 1850 Kelvin.</para>
    /// </summary>
    public float LightTemperature
    {
        get
        {
            return GetTemperature();
        }
        set
        {
            SetTemperature(value);
        }
    }

    /// <summary>
    /// <para>The light's color in nonlinear sRGB encoding. An <i>overbright</i> color can be used to achieve a result equivalent to increasing the light's <see cref="Godot.Light3D.LightEnergy"/>.</para>
    /// </summary>
    public Color LightColor
    {
        get
        {
            return GetColor();
        }
        set
        {
            SetColor(value);
        }
    }

    /// <summary>
    /// <para>The light's strength multiplier (this is not a physical unit). For <see cref="Godot.OmniLight3D"/> and <see cref="Godot.SpotLight3D"/>, changing this value will only change the light color's intensity, not the light's radius.</para>
    /// </summary>
    public float LightEnergy
    {
        get
        {
            return GetParam((Light3D.Param)(0));
        }
        set
        {
            SetParam((Light3D.Param)(0), value);
        }
    }

    /// <summary>
    /// <para>Secondary multiplier used with indirect light (light bounces). Used with <see cref="Godot.VoxelGI"/> and SDFGI (see <see cref="Godot.Environment.SdfgiEnabled"/>).</para>
    /// <para><b>Note:</b> This property is ignored if <see cref="Godot.Light3D.LightEnergy"/> is equal to <c>0.0</c>, as the light won't be present at all in the GI shader.</para>
    /// </summary>
    public float LightIndirectEnergy
    {
        get
        {
            return GetParam((Light3D.Param)(1));
        }
        set
        {
            SetParam((Light3D.Param)(1), value);
        }
    }

    /// <summary>
    /// <para>Secondary multiplier multiplied with <see cref="Godot.Light3D.LightEnergy"/> then used with the <see cref="Godot.Environment"/>'s volumetric fog (if enabled). If set to <c>0.0</c>, computing volumetric fog will be skipped for this light, which can improve performance for large amounts of lights when volumetric fog is enabled.</para>
    /// <para><b>Note:</b> To prevent short-lived dynamic light effects from poorly interacting with volumetric fog, lights used in those effects should have <see cref="Godot.Light3D.LightVolumetricFogEnergy"/> set to <c>0.0</c> unless <see cref="Godot.Environment.VolumetricFogTemporalReprojectionEnabled"/> is disabled (or unless the reprojection amount is significantly lowered).</para>
    /// </summary>
    public float LightVolumetricFogEnergy
    {
        get
        {
            return GetParam((Light3D.Param)(2));
        }
        set
        {
            SetParam((Light3D.Param)(2), value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Texture2D"/> projected by light. <see cref="Godot.Light3D.ShadowEnabled"/> must be on for the projector to work. Light projectors make the light appear as if it is shining through a colored but transparent object, almost like light shining through stained-glass.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.BaseMaterial3D"/> whose filter mode can be adjusted on a per-material basis, the filter mode for light projector textures is set globally with <c>ProjectSettings.rendering/textures/light_projectors/filter</c>.</para>
    /// <para><b>Note:</b> Light projector textures are only supported in the Forward+ and Mobile rendering methods, not Compatibility.</para>
    /// </summary>
    public Texture2D LightProjector
    {
        get
        {
            return GetProjector();
        }
        set
        {
            SetProjector(value);
        }
    }

    /// <summary>
    /// <para>The size of the light in Godot units. Only available for <see cref="Godot.OmniLight3D"/>s and <see cref="Godot.SpotLight3D"/>s. Increasing this value will make the light fade out slower and shadows appear blurrier (also called percentage-closer soft shadows, or PCSS). This can be used to simulate area lights to an extent. Increasing this value above <c>0.0</c> for lights with shadows enabled will have a noticeable performance cost due to PCSS.</para>
    /// <para><b>Note:</b> <see cref="Godot.Light3D.LightSize"/> is not affected by <see cref="Godot.Node3D.Scale"/> (the light's scale or its parent's scale).</para>
    /// <para><b>Note:</b> PCSS for positional lights is only supported in the Forward+ and Mobile rendering methods, not Compatibility.</para>
    /// </summary>
    public float LightSize
    {
        get
        {
            return GetParam((Light3D.Param)(5));
        }
        set
        {
            SetParam((Light3D.Param)(5), value);
        }
    }

    /// <summary>
    /// <para>The light's angular size in degrees. Increasing this will make shadows softer at greater distances (also called percentage-closer soft shadows, or PCSS). Only available for <see cref="Godot.DirectionalLight3D"/>s. For reference, the Sun from the Earth is approximately <c>0.5</c>. Increasing this value above <c>0.0</c> for lights with shadows enabled will have a noticeable performance cost due to PCSS.</para>
    /// <para><b>Note:</b> <see cref="Godot.Light3D.LightAngularDistance"/> is not affected by <see cref="Godot.Node3D.Scale"/> (the light's scale or its parent's scale).</para>
    /// <para><b>Note:</b> PCSS for directional lights is only supported in the Forward+ rendering method, not Mobile or Compatibility.</para>
    /// </summary>
    public float LightAngularDistance
    {
        get
        {
            return GetParam((Light3D.Param)(5));
        }
        set
        {
            SetParam((Light3D.Param)(5), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the light's effect is reversed, darkening areas and casting bright shadows.</para>
    /// </summary>
    public bool LightNegative
    {
        get
        {
            return IsNegative();
        }
        set
        {
            SetNegative(value);
        }
    }

    /// <summary>
    /// <para>The intensity of the specular blob in objects affected by the light. At <c>0</c>, the light becomes a pure diffuse light. When not baking emission, this can be used to avoid unrealistic reflections when placing lights above an emissive surface.</para>
    /// </summary>
    public float LightSpecular
    {
        get
        {
            return GetParam((Light3D.Param)(3));
        }
        set
        {
            SetParam((Light3D.Param)(3), value);
        }
    }

    /// <summary>
    /// <para>The light's bake mode. This will affect the global illumination techniques that have an effect on the light's rendering.</para>
    /// <para><b>Note:</b> Meshes' global illumination mode will also affect the global illumination rendering. See <see cref="Godot.GeometryInstance3D.GIMode"/>.</para>
    /// </summary>
    public Light3D.BakeMode LightBakeMode
    {
        get
        {
            return GetBakeMode();
        }
        set
        {
            SetBakeMode(value);
        }
    }

    /// <summary>
    /// <para>The light will affect objects in the selected layers.</para>
    /// <para><b>Note:</b> The light cull mask is ignored by <see cref="Godot.VoxelGI"/>, SDFGI, <see cref="Godot.LightmapGI"/>, and volumetric fog. These will always render lights in a way that ignores the cull mask. See also <see cref="Godot.VisualInstance3D.Layers"/>.</para>
    /// </summary>
    public uint LightCullMask
    {
        get
        {
            return GetCullMask();
        }
        set
        {
            SetCullMask(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the light will cast real-time shadows. This has a significant performance cost. Only enable shadow rendering when it makes a noticeable difference in the scene's appearance, and consider using <see cref="Godot.Light3D.DistanceFadeEnabled"/> to hide the light when far away from the <see cref="Godot.Camera3D"/>.</para>
    /// </summary>
    public bool ShadowEnabled
    {
        get
        {
            return HasShadow();
        }
        set
        {
            SetShadow(value);
        }
    }

    /// <summary>
    /// <para>Used to adjust shadow appearance. Too small a value results in self-shadowing ("shadow acne"), while too large a value causes shadows to separate from casters ("peter-panning"). Adjust as needed.</para>
    /// </summary>
    public float ShadowBias
    {
        get
        {
            return GetParam((Light3D.Param)(15));
        }
        set
        {
            SetParam((Light3D.Param)(15), value);
        }
    }

    /// <summary>
    /// <para>Offsets the lookup into the shadow map by the object's normal. This can be used to reduce self-shadowing artifacts without using <see cref="Godot.Light3D.ShadowBias"/>. In practice, this value should be tweaked along with <see cref="Godot.Light3D.ShadowBias"/> to reduce artifacts as much as possible.</para>
    /// </summary>
    public float ShadowNormalBias
    {
        get
        {
            return GetParam((Light3D.Param)(14));
        }
        set
        {
            SetParam((Light3D.Param)(14), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, reverses the backface culling of the mesh. This can be useful when you have a flat mesh that has a light behind it. If you need to cast a shadow on both sides of the mesh, set the mesh to use double-sided shadows with <see cref="Godot.GeometryInstance3D.ShadowCastingSetting.DoubleSided"/>.</para>
    /// </summary>
    public bool ShadowReverseCullFace
    {
        get
        {
            return GetShadowReverseCullFace();
        }
        set
        {
            SetShadowReverseCullFace(value);
        }
    }

    public float ShadowTransmittanceBias
    {
        get
        {
            return GetParam((Light3D.Param)(19));
        }
        set
        {
            SetParam((Light3D.Param)(19), value);
        }
    }

    /// <summary>
    /// <para>The opacity to use when rendering the light's shadow map. Values lower than <c>1.0</c> make the light appear through shadows. This can be used to fake global illumination at a low performance cost.</para>
    /// </summary>
    public float ShadowOpacity
    {
        get
        {
            return GetParam((Light3D.Param)(17));
        }
        set
        {
            SetParam((Light3D.Param)(17), value);
        }
    }

    /// <summary>
    /// <para>Blurs the edges of the shadow. Can be used to hide pixel artifacts in low-resolution shadow maps. A high value can impact performance, make shadows appear grainy and can cause other unwanted artifacts. Try to keep as near default as possible.</para>
    /// </summary>
    public float ShadowBlur
    {
        get
        {
            return GetParam((Light3D.Param)(18));
        }
        set
        {
            SetParam((Light3D.Param)(18), value);
        }
    }

    /// <summary>
    /// <para>The light will only cast shadows using objects in the selected layers.</para>
    /// </summary>
    public uint ShadowCasterMask
    {
        get
        {
            return GetShadowCasterMask();
        }
        set
        {
            SetShadowCasterMask(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the light will smoothly fade away when far from the active <see cref="Godot.Camera3D"/> starting at <see cref="Godot.Light3D.DistanceFadeBegin"/>. This acts as a form of level of detail (LOD). The light will fade out over <see cref="Godot.Light3D.DistanceFadeBegin"/> + <see cref="Godot.Light3D.DistanceFadeLength"/>, after which it will be culled and not sent to the shader at all. Use this to reduce the number of active lights in a scene and thus improve performance.</para>
    /// <para><b>Note:</b> Only effective for <see cref="Godot.OmniLight3D"/> and <see cref="Godot.SpotLight3D"/>.</para>
    /// </summary>
    public bool DistanceFadeEnabled
    {
        get
        {
            return IsDistanceFadeEnabled();
        }
        set
        {
            SetEnableDistanceFade(value);
        }
    }

    /// <summary>
    /// <para>The distance from the camera at which the light begins to fade away (in 3D units).</para>
    /// <para><b>Note:</b> Only effective for <see cref="Godot.OmniLight3D"/> and <see cref="Godot.SpotLight3D"/>.</para>
    /// </summary>
    public float DistanceFadeBegin
    {
        get
        {
            return GetDistanceFadeBegin();
        }
        set
        {
            SetDistanceFadeBegin(value);
        }
    }

    /// <summary>
    /// <para>The distance from the camera at which the light's shadow cuts off (in 3D units). Set this to a value lower than <see cref="Godot.Light3D.DistanceFadeBegin"/> + <see cref="Godot.Light3D.DistanceFadeLength"/> to further improve performance, as shadow rendering is often more expensive than light rendering itself.</para>
    /// <para><b>Note:</b> Only effective for <see cref="Godot.OmniLight3D"/> and <see cref="Godot.SpotLight3D"/>, and only when <see cref="Godot.Light3D.ShadowEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public float DistanceFadeShadow
    {
        get
        {
            return GetDistanceFadeShadow();
        }
        set
        {
            SetDistanceFadeShadow(value);
        }
    }

    /// <summary>
    /// <para>Distance over which the light and its shadow fades. The light's energy and shadow's opacity is progressively reduced over this distance and is completely invisible at the end.</para>
    /// <para><b>Note:</b> Only effective for <see cref="Godot.OmniLight3D"/> and <see cref="Godot.SpotLight3D"/>.</para>
    /// </summary>
    public float DistanceFadeLength
    {
        get
        {
            return GetDistanceFadeLength();
        }
        set
        {
            SetDistanceFadeLength(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the light only appears in the editor and will not be visible at runtime. If <see langword="true"/>, the light will never be baked in <see cref="Godot.LightmapGI"/> regardless of its <see cref="Godot.Light3D.LightBakeMode"/>.</para>
    /// </summary>
    public bool EditorOnly
    {
        get
        {
            return IsEditorOnly();
        }
        set
        {
            SetEditorOnly(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Light3D);

    private static readonly StringName NativeName = "Light3D";

    internal Light3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Light3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Light3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditorOnly, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditorOnly(bool editorOnly)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), editorOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditorOnly, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditorOnly()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParam, 1722734213ul);

    /// <summary>
    /// <para>Sets the value of the specified <see cref="Godot.Light3D.Param"/> parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParam(Light3D.Param param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind2, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParam, 1844084987ul);

    /// <summary>
    /// <para>Returns the value of the specified <see cref="Godot.Light3D.Param"/> parameter.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetParam(Light3D.Param param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind3, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadow, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadow(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasShadow, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasShadow()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNegative, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNegative(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNegative, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsNegative()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCullMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCullMask(uint cullMask)
    {
        NativeCalls.godot_icall_1_208(MethodBind8, GodotObject.GetPtr(this), cullMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCullMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCullMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableDistanceFade, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableDistanceFade(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDistanceFadeEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDistanceFadeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDistanceFadeBegin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDistanceFadeBegin(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDistanceFadeBegin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDistanceFadeBegin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDistanceFadeShadow, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDistanceFadeShadow(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDistanceFadeShadow, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDistanceFadeShadow()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDistanceFadeLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDistanceFadeLength(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDistanceFadeLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDistanceFadeLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind18, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowReverseCullFace, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowReverseCullFace(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowReverseCullFace, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetShadowReverseCullFace()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowCasterMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowCasterMask(uint casterMask)
    {
        NativeCalls.godot_icall_1_208(MethodBind22, GodotObject.GetPtr(this), casterMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowCasterMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetShadowCasterMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakeMode, 37739303ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBakeMode(Light3D.BakeMode bakeMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), (int)bakeMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeMode, 371737608ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Light3D.BakeMode GetBakeMode()
    {
        return (Light3D.BakeMode)NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProjector, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProjector(Texture2D projector)
    {
        NativeCalls.godot_icall_1_56(MethodBind26, GodotObject.GetPtr(this), GodotObject.GetPtr(projector));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjector, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetProjector()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTemperature, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTemperature(float temperature)
    {
        NativeCalls.godot_icall_1_67(MethodBind28, GodotObject.GetPtr(this), temperature);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTemperature, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTemperature()
    {
        return NativeCalls.godot_icall_0_68(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCorrelatedColor, 3444240500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Color"/> of an idealized blackbody at the given <see cref="Godot.Light3D.LightTemperature"/>. This value is calculated internally based on the <see cref="Godot.Light3D.LightTemperature"/>. This <see cref="Godot.Color"/> is multiplied by <see cref="Godot.Light3D.LightColor"/> before being sent to the <see cref="Godot.RenderingServer"/>.</para>
    /// </summary>
    public Color GetCorrelatedColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind30, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'light_intensity_lumens' property.
        /// </summary>
        public static readonly StringName LightIntensityLumens = "light_intensity_lumens";
        /// <summary>
        /// Cached name for the 'light_intensity_lux' property.
        /// </summary>
        public static readonly StringName LightIntensityLux = "light_intensity_lux";
        /// <summary>
        /// Cached name for the 'light_temperature' property.
        /// </summary>
        public static readonly StringName LightTemperature = "light_temperature";
        /// <summary>
        /// Cached name for the 'light_color' property.
        /// </summary>
        public static readonly StringName LightColor = "light_color";
        /// <summary>
        /// Cached name for the 'light_energy' property.
        /// </summary>
        public static readonly StringName LightEnergy = "light_energy";
        /// <summary>
        /// Cached name for the 'light_indirect_energy' property.
        /// </summary>
        public static readonly StringName LightIndirectEnergy = "light_indirect_energy";
        /// <summary>
        /// Cached name for the 'light_volumetric_fog_energy' property.
        /// </summary>
        public static readonly StringName LightVolumetricFogEnergy = "light_volumetric_fog_energy";
        /// <summary>
        /// Cached name for the 'light_projector' property.
        /// </summary>
        public static readonly StringName LightProjector = "light_projector";
        /// <summary>
        /// Cached name for the 'light_size' property.
        /// </summary>
        public static readonly StringName LightSize = "light_size";
        /// <summary>
        /// Cached name for the 'light_angular_distance' property.
        /// </summary>
        public static readonly StringName LightAngularDistance = "light_angular_distance";
        /// <summary>
        /// Cached name for the 'light_negative' property.
        /// </summary>
        public static readonly StringName LightNegative = "light_negative";
        /// <summary>
        /// Cached name for the 'light_specular' property.
        /// </summary>
        public static readonly StringName LightSpecular = "light_specular";
        /// <summary>
        /// Cached name for the 'light_bake_mode' property.
        /// </summary>
        public static readonly StringName LightBakeMode = "light_bake_mode";
        /// <summary>
        /// Cached name for the 'light_cull_mask' property.
        /// </summary>
        public static readonly StringName LightCullMask = "light_cull_mask";
        /// <summary>
        /// Cached name for the 'shadow_enabled' property.
        /// </summary>
        public static readonly StringName ShadowEnabled = "shadow_enabled";
        /// <summary>
        /// Cached name for the 'shadow_bias' property.
        /// </summary>
        public static readonly StringName ShadowBias = "shadow_bias";
        /// <summary>
        /// Cached name for the 'shadow_normal_bias' property.
        /// </summary>
        public static readonly StringName ShadowNormalBias = "shadow_normal_bias";
        /// <summary>
        /// Cached name for the 'shadow_reverse_cull_face' property.
        /// </summary>
        public static readonly StringName ShadowReverseCullFace = "shadow_reverse_cull_face";
        /// <summary>
        /// Cached name for the 'shadow_transmittance_bias' property.
        /// </summary>
        public static readonly StringName ShadowTransmittanceBias = "shadow_transmittance_bias";
        /// <summary>
        /// Cached name for the 'shadow_opacity' property.
        /// </summary>
        public static readonly StringName ShadowOpacity = "shadow_opacity";
        /// <summary>
        /// Cached name for the 'shadow_blur' property.
        /// </summary>
        public static readonly StringName ShadowBlur = "shadow_blur";
        /// <summary>
        /// Cached name for the 'shadow_caster_mask' property.
        /// </summary>
        public static readonly StringName ShadowCasterMask = "shadow_caster_mask";
        /// <summary>
        /// Cached name for the 'distance_fade_enabled' property.
        /// </summary>
        public static readonly StringName DistanceFadeEnabled = "distance_fade_enabled";
        /// <summary>
        /// Cached name for the 'distance_fade_begin' property.
        /// </summary>
        public static readonly StringName DistanceFadeBegin = "distance_fade_begin";
        /// <summary>
        /// Cached name for the 'distance_fade_shadow' property.
        /// </summary>
        public static readonly StringName DistanceFadeShadow = "distance_fade_shadow";
        /// <summary>
        /// Cached name for the 'distance_fade_length' property.
        /// </summary>
        public static readonly StringName DistanceFadeLength = "distance_fade_length";
        /// <summary>
        /// Cached name for the 'editor_only' property.
        /// </summary>
        public static readonly StringName EditorOnly = "editor_only";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_editor_only' method.
        /// </summary>
        public static readonly StringName SetEditorOnly = "set_editor_only";
        /// <summary>
        /// Cached name for the 'is_editor_only' method.
        /// </summary>
        public static readonly StringName IsEditorOnly = "is_editor_only";
        /// <summary>
        /// Cached name for the 'set_param' method.
        /// </summary>
        public static readonly StringName SetParam = "set_param";
        /// <summary>
        /// Cached name for the 'get_param' method.
        /// </summary>
        public static readonly StringName GetParam = "get_param";
        /// <summary>
        /// Cached name for the 'set_shadow' method.
        /// </summary>
        public static readonly StringName SetShadow = "set_shadow";
        /// <summary>
        /// Cached name for the 'has_shadow' method.
        /// </summary>
        public static readonly StringName HasShadow = "has_shadow";
        /// <summary>
        /// Cached name for the 'set_negative' method.
        /// </summary>
        public static readonly StringName SetNegative = "set_negative";
        /// <summary>
        /// Cached name for the 'is_negative' method.
        /// </summary>
        public static readonly StringName IsNegative = "is_negative";
        /// <summary>
        /// Cached name for the 'set_cull_mask' method.
        /// </summary>
        public static readonly StringName SetCullMask = "set_cull_mask";
        /// <summary>
        /// Cached name for the 'get_cull_mask' method.
        /// </summary>
        public static readonly StringName GetCullMask = "get_cull_mask";
        /// <summary>
        /// Cached name for the 'set_enable_distance_fade' method.
        /// </summary>
        public static readonly StringName SetEnableDistanceFade = "set_enable_distance_fade";
        /// <summary>
        /// Cached name for the 'is_distance_fade_enabled' method.
        /// </summary>
        public static readonly StringName IsDistanceFadeEnabled = "is_distance_fade_enabled";
        /// <summary>
        /// Cached name for the 'set_distance_fade_begin' method.
        /// </summary>
        public static readonly StringName SetDistanceFadeBegin = "set_distance_fade_begin";
        /// <summary>
        /// Cached name for the 'get_distance_fade_begin' method.
        /// </summary>
        public static readonly StringName GetDistanceFadeBegin = "get_distance_fade_begin";
        /// <summary>
        /// Cached name for the 'set_distance_fade_shadow' method.
        /// </summary>
        public static readonly StringName SetDistanceFadeShadow = "set_distance_fade_shadow";
        /// <summary>
        /// Cached name for the 'get_distance_fade_shadow' method.
        /// </summary>
        public static readonly StringName GetDistanceFadeShadow = "get_distance_fade_shadow";
        /// <summary>
        /// Cached name for the 'set_distance_fade_length' method.
        /// </summary>
        public static readonly StringName SetDistanceFadeLength = "set_distance_fade_length";
        /// <summary>
        /// Cached name for the 'get_distance_fade_length' method.
        /// </summary>
        public static readonly StringName GetDistanceFadeLength = "get_distance_fade_length";
        /// <summary>
        /// Cached name for the 'set_color' method.
        /// </summary>
        public static readonly StringName SetColor = "set_color";
        /// <summary>
        /// Cached name for the 'get_color' method.
        /// </summary>
        public static readonly StringName GetColor = "get_color";
        /// <summary>
        /// Cached name for the 'set_shadow_reverse_cull_face' method.
        /// </summary>
        public static readonly StringName SetShadowReverseCullFace = "set_shadow_reverse_cull_face";
        /// <summary>
        /// Cached name for the 'get_shadow_reverse_cull_face' method.
        /// </summary>
        public static readonly StringName GetShadowReverseCullFace = "get_shadow_reverse_cull_face";
        /// <summary>
        /// Cached name for the 'set_shadow_caster_mask' method.
        /// </summary>
        public static readonly StringName SetShadowCasterMask = "set_shadow_caster_mask";
        /// <summary>
        /// Cached name for the 'get_shadow_caster_mask' method.
        /// </summary>
        public static readonly StringName GetShadowCasterMask = "get_shadow_caster_mask";
        /// <summary>
        /// Cached name for the 'set_bake_mode' method.
        /// </summary>
        public static readonly StringName SetBakeMode = "set_bake_mode";
        /// <summary>
        /// Cached name for the 'get_bake_mode' method.
        /// </summary>
        public static readonly StringName GetBakeMode = "get_bake_mode";
        /// <summary>
        /// Cached name for the 'set_projector' method.
        /// </summary>
        public static readonly StringName SetProjector = "set_projector";
        /// <summary>
        /// Cached name for the 'get_projector' method.
        /// </summary>
        public static readonly StringName GetProjector = "get_projector";
        /// <summary>
        /// Cached name for the 'set_temperature' method.
        /// </summary>
        public static readonly StringName SetTemperature = "set_temperature";
        /// <summary>
        /// Cached name for the 'get_temperature' method.
        /// </summary>
        public static readonly StringName GetTemperature = "get_temperature";
        /// <summary>
        /// Cached name for the 'get_correlated_color' method.
        /// </summary>
        public static readonly StringName GetCorrelatedColor = "get_correlated_color";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
    }
}
