namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.LightmapGI"/> node is used to compute and store baked lightmaps. Lightmaps are used to provide high-quality indirect lighting with very little light leaking. <see cref="Godot.LightmapGI"/> can also provide rough reflections using spherical harmonics if <see cref="Godot.LightmapGI.Directional"/> is enabled. Dynamic objects can receive indirect lighting thanks to <i>light probes</i>, which can be automatically placed by setting <see cref="Godot.LightmapGI.GenerateProbesSubdiv"/> to a value other than <see cref="Godot.LightmapGI.GenerateProbes.Disabled"/>. Additional lightmap probes can also be added by creating <see cref="Godot.LightmapProbe"/> nodes. The downside is that lightmaps are fully static and cannot be baked in an exported project. Baking a <see cref="Godot.LightmapGI"/> node is also slower compared to <see cref="Godot.VoxelGI"/>.</para>
/// <para><b>Procedural generation:</b> Lightmap baking functionality is only available in the editor. This means <see cref="Godot.LightmapGI"/> is not suited to procedurally generated or user-built levels. For procedurally generated or user-built levels, use <see cref="Godot.VoxelGI"/> or SDFGI instead (see <see cref="Godot.Environment.SdfgiEnabled"/>).</para>
/// <para><b>Performance:</b> <see cref="Godot.LightmapGI"/> provides the best possible run-time performance for global illumination. It is suitable for low-end hardware including integrated graphics and mobile devices.</para>
/// <para><b>Note:</b> Due to how lightmaps work, most properties only have a visible effect once lightmaps are baked again.</para>
/// <para><b>Note:</b> Lightmap baking on <see cref="Godot.CsgShape3D"/>s and <see cref="Godot.PrimitiveMesh"/>es is not supported, as these cannot store UV2 data required for baking.</para>
/// <para><b>Note:</b> If no custom lightmappers are installed, <see cref="Godot.LightmapGI"/> can only be baked from devices that support the Forward+ or Mobile renderers.</para>
/// <para><b>Note:</b> The <see cref="Godot.LightmapGI"/> node only bakes light data for child nodes of its parent. Nodes further up the hierarchy of the scene will not be baked.</para>
/// </summary>
public partial class LightmapGI : VisualInstance3D
{
    public enum BakeQuality : long
    {
        /// <summary>
        /// <para>Low bake quality (fastest bake times). The quality of this preset can be adjusted by changing <c>ProjectSettings.rendering/lightmapping/bake_quality/low_quality_ray_count</c> and <c>ProjectSettings.rendering/lightmapping/bake_quality/low_quality_probe_ray_count</c>.</para>
        /// </summary>
        Low = 0,
        /// <summary>
        /// <para>Medium bake quality (fast bake times). The quality of this preset can be adjusted by changing <c>ProjectSettings.rendering/lightmapping/bake_quality/medium_quality_ray_count</c> and <c>ProjectSettings.rendering/lightmapping/bake_quality/medium_quality_probe_ray_count</c>.</para>
        /// </summary>
        Medium = 1,
        /// <summary>
        /// <para>High bake quality (slow bake times). The quality of this preset can be adjusted by changing <c>ProjectSettings.rendering/lightmapping/bake_quality/high_quality_ray_count</c> and <c>ProjectSettings.rendering/lightmapping/bake_quality/high_quality_probe_ray_count</c>.</para>
        /// </summary>
        High = 2,
        /// <summary>
        /// <para>Highest bake quality (slowest bake times). The quality of this preset can be adjusted by changing <c>ProjectSettings.rendering/lightmapping/bake_quality/ultra_quality_ray_count</c> and <c>ProjectSettings.rendering/lightmapping/bake_quality/ultra_quality_probe_ray_count</c>.</para>
        /// </summary>
        Ultra = 3
    }

    public enum GenerateProbes : long
    {
        /// <summary>
        /// <para>Don't generate lightmap probes for lighting dynamic objects.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Lowest level of subdivision (fastest bake times, smallest file sizes).</para>
        /// </summary>
        Subdiv4 = 1,
        /// <summary>
        /// <para>Low level of subdivision (fast bake times, small file sizes).</para>
        /// </summary>
        Subdiv8 = 2,
        /// <summary>
        /// <para>High level of subdivision (slow bake times, large file sizes).</para>
        /// </summary>
        Subdiv16 = 3,
        /// <summary>
        /// <para>Highest level of subdivision (slowest bake times, largest file sizes).</para>
        /// </summary>
        Subdiv32 = 4
    }

    public enum BakeError : long
    {
        /// <summary>
        /// <para>Lightmap baking was successful.</para>
        /// </summary>
        Ok = 0,
        /// <summary>
        /// <para>Lightmap baking failed because the root node for the edited scene could not be accessed.</para>
        /// </summary>
        NoSceneRoot = 1,
        /// <summary>
        /// <para>Lightmap baking failed as the lightmap data resource is embedded in a foreign resource.</para>
        /// </summary>
        ForeignData = 2,
        /// <summary>
        /// <para>Lightmap baking failed as there is no lightmapper available in this Godot build.</para>
        /// </summary>
        NoLightmapper = 3,
        /// <summary>
        /// <para>Lightmap baking failed as the <see cref="Godot.LightmapGIData"/> save path isn't configured in the resource.</para>
        /// </summary>
        NoSavePath = 4,
        /// <summary>
        /// <para>Lightmap baking failed as there are no meshes whose <see cref="Godot.GeometryInstance3D.GIMode"/> is <see cref="Godot.GeometryInstance3D.GIModeEnum.Static"/> and with valid UV2 mapping in the current scene. You may need to select 3D scenes in the Import dock and change their global illumination mode accordingly.</para>
        /// </summary>
        NoMeshes = 5,
        /// <summary>
        /// <para>Lightmap baking failed as the lightmapper failed to analyze some of the meshes marked as static for baking.</para>
        /// </summary>
        MeshesInvalid = 6,
        /// <summary>
        /// <para>Lightmap baking failed as the resulting image couldn't be saved or imported by Godot after it was saved.</para>
        /// </summary>
        CantCreateImage = 7,
        /// <summary>
        /// <para>The user aborted the lightmap baking operation (typically by clicking the <b>Cancel</b> button in the progress dialog).</para>
        /// </summary>
        UserAborted = 8,
        /// <summary>
        /// <para>Lightmap baking failed as the maximum texture size is too small to fit some of the meshes marked for baking.</para>
        /// </summary>
        TextureSizeTooSmall = 9,
        /// <summary>
        /// <para>Lightmap baking failed as the lightmap is too small.</para>
        /// </summary>
        LightmapTooSmall = 10,
        /// <summary>
        /// <para>Lightmap baking failed as the lightmap was unable to fit into an atlas.</para>
        /// </summary>
        AtlasTooSmall = 11
    }

    public enum EnvironmentModeEnum : long
    {
        /// <summary>
        /// <para>Ignore environment lighting when baking lightmaps.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Use the scene's environment lighting when baking lightmaps.</para>
        /// <para><b>Note:</b> If baking lightmaps in a scene with no <see cref="Godot.WorldEnvironment"/> node, this will act like <see cref="Godot.LightmapGI.EnvironmentModeEnum.Disabled"/>. The editor's preview sky and sun is <i>not</i> taken into account by <see cref="Godot.LightmapGI"/> when baking lightmaps.</para>
        /// </summary>
        Scene = 1,
        /// <summary>
        /// <para>Use <see cref="Godot.LightmapGI.EnvironmentCustomSky"/> as a source of environment lighting when baking lightmaps.</para>
        /// </summary>
        CustomSky = 2,
        /// <summary>
        /// <para>Use <see cref="Godot.LightmapGI.EnvironmentCustomColor"/> multiplied by <see cref="Godot.LightmapGI.EnvironmentCustomEnergy"/> as a constant source of environment lighting when baking lightmaps.</para>
        /// </summary>
        CustomColor = 3
    }

    /// <summary>
    /// <para>The quality preset to use when baking lightmaps. This affects bake times, but output file sizes remain mostly identical across quality levels.</para>
    /// <para>To further speed up bake times, decrease <see cref="Godot.LightmapGI.Bounces"/>, disable <see cref="Godot.LightmapGI.UseDenoiser"/> and/or decrease <see cref="Godot.LightmapGI.TexelScale"/>.</para>
    /// <para>To further increase quality, enable <see cref="Godot.LightmapGI.Supersampling"/> and/or increase <see cref="Godot.LightmapGI.TexelScale"/>.</para>
    /// </summary>
    public LightmapGI.BakeQuality Quality
    {
        get
        {
            return GetBakeQuality();
        }
        set
        {
            SetBakeQuality(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, lightmaps are baked with the texel scale multiplied with <see cref="Godot.LightmapGI.SupersamplingFactor"/> and downsampled before saving the lightmap (so the effective texel density is identical to having supersampling disabled).</para>
    /// <para>Supersampling provides increased lightmap quality with less noise, smoother shadows and better shadowing of small-scale features in objects. However, it may result in significantly increased bake times and memory usage while baking lightmaps. Padding is automatically adjusted to avoid increasing light leaking.</para>
    /// </summary>
    public bool Supersampling
    {
        get
        {
            return IsSupersamplingEnabled();
        }
        set
        {
            SetSupersamplingEnabled(value);
        }
    }

    /// <summary>
    /// <para>The factor by which the texel density is multiplied for supersampling. For best results, use an integer value. While fractional values are allowed, they can result in increased light leaking and a blurry lightmap.</para>
    /// <para>Higher values may result in better quality, but also increase bake times and memory usage while baking.</para>
    /// <para>See <see cref="Godot.LightmapGI.Supersampling"/> for more information.</para>
    /// </summary>
    public float SupersamplingFactor
    {
        get
        {
            return GetSupersamplingFactor();
        }
        set
        {
            SetSupersamplingFactor(value);
        }
    }

    /// <summary>
    /// <para>Number of light bounces that are taken into account during baking. Higher values result in brighter, more realistic lighting, at the cost of longer bake times. If set to <c>0</c>, only environment lighting, direct light and emissive lighting is baked.</para>
    /// </summary>
    public int Bounces
    {
        get
        {
            return GetBounces();
        }
        set
        {
            SetBounces(value);
        }
    }

    /// <summary>
    /// <para>The energy multiplier for each bounce. Higher values will make indirect lighting brighter. A value of <c>1.0</c> represents physically accurate behavior, but higher values can be used to make indirect lighting propagate more visibly when using a low number of bounces. This can be used to speed up bake times by lowering the number of <see cref="Godot.LightmapGI.Bounces"/> then increasing <see cref="Godot.LightmapGI.BounceIndirectEnergy"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.LightmapGI.BounceIndirectEnergy"/> only has an effect if <see cref="Godot.LightmapGI.Bounces"/> is set to a value greater than or equal to <c>1</c>.</para>
    /// </summary>
    public float BounceIndirectEnergy
    {
        get
        {
            return GetBounceIndirectEnergy();
        }
        set
        {
            SetBounceIndirectEnergy(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, bakes lightmaps to contain directional information as spherical harmonics. This results in more realistic lighting appearance, especially with normal mapped materials and for lights that have their direct light baked (<see cref="Godot.Light3D.LightBakeMode"/> set to <see cref="Godot.Light3D.BakeMode.Static"/> and with <see cref="Godot.Light3D.EditorOnly"/> set to <see langword="false"/>). The directional information is also used to provide rough reflections for static and dynamic objects. This has a small run-time performance cost as the shader has to perform more work to interpret the direction information from the lightmap. Directional lightmaps also take longer to bake and result in larger file sizes.</para>
    /// <para><b>Note:</b> The property's name has no relationship with <see cref="Godot.DirectionalLight3D"/>. <see cref="Godot.LightmapGI.Directional"/> works with all light types.</para>
    /// </summary>
    public bool Directional
    {
        get
        {
            return IsDirectional();
        }
        set
        {
            SetDirectional(value);
        }
    }

    /// <summary>
    /// <para>The shadowmasking policy to use for directional shadows on static objects that are baked with this <see cref="Godot.LightmapGI"/> instance.</para>
    /// <para>Shadowmasking allows <see cref="Godot.DirectionalLight3D"/> nodes to cast shadows even outside the range defined by their <see cref="Godot.DirectionalLight3D.DirectionalShadowMaxDistance"/> property. This is done by baking a texture that contains a shadowmap for the directional light, then using this texture according to the current shadowmask mode.</para>
    /// <para><b>Note:</b> The shadowmask texture is only created if <see cref="Godot.LightmapGI.ShadowmaskMode"/> is not <see cref="Godot.LightmapGIData.ShadowmaskMode.None"/>. To see a difference, you need to bake lightmaps again after switching from <see cref="Godot.LightmapGIData.ShadowmaskMode.None"/> to any other mode.</para>
    /// </summary>
    public LightmapGIData.ShadowmaskMode ShadowmaskMode
    {
        get
        {
            return GetShadowmaskMode();
        }
        set
        {
            SetShadowmaskMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, a texture with the lighting information will be generated to speed up the generation of indirect lighting at the cost of some accuracy. The geometry might exhibit extra light leak artifacts when using low resolution lightmaps or UVs that stretch the lightmap significantly across surfaces. Leave <see cref="Godot.LightmapGI.UseTextureForBounces"/> at its default value of <see langword="true"/> if unsure.</para>
    /// <para><b>Note:</b> <see cref="Godot.LightmapGI.UseTextureForBounces"/> only has an effect if <see cref="Godot.LightmapGI.Bounces"/> is set to a value greater than or equal to <c>1</c>.</para>
    /// </summary>
    public bool UseTextureForBounces
    {
        get
        {
            return IsUsingTextureForBounces();
        }
        set
        {
            SetUseTextureForBounces(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, ignore environment lighting when baking lightmaps.</para>
    /// </summary>
    public bool Interior
    {
        get
        {
            return IsInterior();
        }
        set
        {
            SetInterior(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, uses a GPU-based denoising algorithm on the generated lightmap. This eliminates most noise within the generated lightmap at the cost of longer bake times. File sizes are generally not impacted significantly by the use of a denoiser, although lossless compression may do a better job at compressing a denoised image.</para>
    /// </summary>
    public bool UseDenoiser
    {
        get
        {
            return IsUsingDenoiser();
        }
        set
        {
            SetUseDenoiser(value);
        }
    }

    /// <summary>
    /// <para>The strength of denoising step applied to the generated lightmaps. Only effective if <see cref="Godot.LightmapGI.UseDenoiser"/> is <see langword="true"/> and <c>ProjectSettings.rendering/lightmapping/denoising/denoiser</c> is set to JNLM.</para>
    /// </summary>
    public float DenoiserStrength
    {
        get
        {
            return GetDenoiserStrength();
        }
        set
        {
            SetDenoiserStrength(value);
        }
    }

    /// <summary>
    /// <para>The distance in pixels from which the denoiser samples. Lower values preserve more details, but may give blotchy results if the lightmap quality is not high enough. Only effective if <see cref="Godot.LightmapGI.UseDenoiser"/> is <see langword="true"/> and <c>ProjectSettings.rendering/lightmapping/denoising/denoiser</c> is set to JNLM.</para>
    /// </summary>
    public int DenoiserRange
    {
        get
        {
            return GetDenoiserRange();
        }
        set
        {
            SetDenoiserRange(value);
        }
    }

    /// <summary>
    /// <para>The bias to use when computing shadows. Increasing <see cref="Godot.LightmapGI.Bias"/> can fix shadow acne on the resulting baked lightmap, but can introduce peter-panning (shadows not connecting to their casters). Real-time <see cref="Godot.Light3D"/> shadows are not affected by this <see cref="Godot.LightmapGI.Bias"/> property.</para>
    /// </summary>
    public float Bias
    {
        get
        {
            return GetBias();
        }
        set
        {
            SetBias(value);
        }
    }

    /// <summary>
    /// <para>Scales the lightmap texel density of all meshes for the current bake. This is a multiplier that builds upon the existing lightmap texel size defined in each imported 3D scene, along with the per-mesh density multiplier (which is designed to be used when the same mesh is used at different scales). Lower values will result in faster bake times.</para>
    /// <para>For example, doubling <see cref="Godot.LightmapGI.TexelScale"/> doubles the lightmap texture resolution for all objects <i>on each axis</i>, so it will <i>quadruple</i> the texel count.</para>
    /// </summary>
    public float TexelScale
    {
        get
        {
            return GetTexelScale();
        }
        set
        {
            SetTexelScale(value);
        }
    }

    /// <summary>
    /// <para>The maximum texture size for the generated texture atlas. Higher values will result in fewer slices being generated, but may not work on all hardware as a result of hardware limitations on texture sizes. Leave <see cref="Godot.LightmapGI.MaxTextureSize"/> at its default value of <c>16384</c> if unsure.</para>
    /// </summary>
    public int MaxTextureSize
    {
        get
        {
            return GetMaxTextureSize();
        }
        set
        {
            SetMaxTextureSize(value);
        }
    }

    /// <summary>
    /// <para>The environment mode to use when baking lightmaps.</para>
    /// </summary>
    public LightmapGI.EnvironmentModeEnum EnvironmentMode
    {
        get
        {
            return GetEnvironmentMode();
        }
        set
        {
            SetEnvironmentMode(value);
        }
    }

    /// <summary>
    /// <para>The sky to use as a source of environment lighting. Only effective if <see cref="Godot.LightmapGI.EnvironmentMode"/> is <see cref="Godot.LightmapGI.EnvironmentModeEnum.CustomSky"/>.</para>
    /// </summary>
    public Sky EnvironmentCustomSky
    {
        get
        {
            return GetEnvironmentCustomSky();
        }
        set
        {
            SetEnvironmentCustomSky(value);
        }
    }

    /// <summary>
    /// <para>The color to use for environment lighting. Only effective if <see cref="Godot.LightmapGI.EnvironmentMode"/> is <see cref="Godot.LightmapGI.EnvironmentModeEnum.CustomColor"/>.</para>
    /// </summary>
    public Color EnvironmentCustomColor
    {
        get
        {
            return GetEnvironmentCustomColor();
        }
        set
        {
            SetEnvironmentCustomColor(value);
        }
    }

    /// <summary>
    /// <para>The color multiplier to use for environment lighting. Only effective if <see cref="Godot.LightmapGI.EnvironmentMode"/> is <see cref="Godot.LightmapGI.EnvironmentModeEnum.CustomColor"/>.</para>
    /// </summary>
    public float EnvironmentCustomEnergy
    {
        get
        {
            return GetEnvironmentCustomEnergy();
        }
        set
        {
            SetEnvironmentCustomEnergy(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.CameraAttributes"/> resource that specifies exposure levels to bake at. Auto-exposure and non exposure properties will be ignored. Exposure settings should be used to reduce the dynamic range present when baking. If exposure is too high, the <see cref="Godot.LightmapGI"/> will have banding artifacts or may have over-exposure artifacts.</para>
    /// </summary>
    public CameraAttributes CameraAttributes
    {
        get
        {
            return GetCameraAttributes();
        }
        set
        {
            SetCameraAttributes(value);
        }
    }

    /// <summary>
    /// <para>The level of subdivision to use when automatically generating <see cref="Godot.LightmapProbe"/>s for dynamic object lighting. Higher values result in more accurate indirect lighting on dynamic objects, at the cost of longer bake times and larger file sizes.</para>
    /// <para><b>Note:</b> Automatically generated <see cref="Godot.LightmapProbe"/>s are not visible as nodes in the Scene tree dock, and cannot be modified this way after they are generated.</para>
    /// <para><b>Note:</b> Regardless of <see cref="Godot.LightmapGI.GenerateProbesSubdiv"/>, direct lighting on dynamic objects is always applied using <see cref="Godot.Light3D"/> nodes in real-time.</para>
    /// </summary>
    public LightmapGI.GenerateProbes GenerateProbesSubdiv
    {
        get
        {
            return GetGenerateProbes();
        }
        set
        {
            SetGenerateProbes(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.LightmapGIData"/> associated to this <see cref="Godot.LightmapGI"/> node. This resource is automatically created after baking, and is not meant to be created manually.</para>
    /// </summary>
    public LightmapGIData LightData
    {
        get
        {
            return GetLightData();
        }
        set
        {
            SetLightData(value);
        }
    }

    private static readonly System.Type CachedType = typeof(LightmapGI);

    private static readonly StringName NativeName = "LightmapGI";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public LightmapGI() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal LightmapGI(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal LightmapGI(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLightData, 1790597277ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLightData(LightmapGIData data)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(data));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLightData, 290354153ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public LightmapGIData GetLightData()
    {
        return (LightmapGIData)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakeQuality, 1192215803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBakeQuality(LightmapGI.BakeQuality bakeQuality)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)bakeQuality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeQuality, 688832735ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public LightmapGI.BakeQuality GetBakeQuality()
    {
        return (LightmapGI.BakeQuality)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBounces, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBounces(int bounces)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), bounces);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBounces, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBounces()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBounceIndirectEnergy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBounceIndirectEnergy(float bounceIndirectEnergy)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), bounceIndirectEnergy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBounceIndirectEnergy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBounceIndirectEnergy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGenerateProbes, 549981046ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGenerateProbes(LightmapGI.GenerateProbes subdivision)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)subdivision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGenerateProbes, 3930596226ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public LightmapGI.GenerateProbes GetGenerateProbes()
    {
        return (LightmapGI.GenerateProbes)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBias(float bias)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnvironmentMode, 2282650285ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnvironmentMode(LightmapGI.EnvironmentModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironmentMode, 4128646479ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public LightmapGI.EnvironmentModeEnum GetEnvironmentMode()
    {
        return (LightmapGI.EnvironmentModeEnum)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnvironmentCustomSky, 3336722921ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnvironmentCustomSky(Sky sky)
    {
        NativeCalls.godot_icall_1_56(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(sky));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironmentCustomSky, 1177136966ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Sky GetEnvironmentCustomSky()
    {
        return (Sky)NativeCalls.godot_icall_0_63(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnvironmentCustomColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetEnvironmentCustomColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind16, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironmentCustomColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetEnvironmentCustomColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnvironmentCustomEnergy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnvironmentCustomEnergy(float energy)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironmentCustomEnergy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEnvironmentCustomEnergy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexelScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexelScale(float texelScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), texelScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexelScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTexelScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxTextureSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxTextureSize(int maxTextureSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind22, GodotObject.GetPtr(this), maxTextureSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxTextureSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxTextureSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSupersamplingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSupersamplingEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind24, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSupersamplingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSupersamplingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSupersamplingFactor, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSupersamplingFactor(float factor)
    {
        NativeCalls.godot_icall_1_67(MethodBind26, GodotObject.GetPtr(this), factor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupersamplingFactor, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSupersamplingFactor()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseDenoiser, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseDenoiser(bool useDenoiser)
    {
        NativeCalls.godot_icall_1_14(MethodBind28, GodotObject.GetPtr(this), useDenoiser.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingDenoiser, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingDenoiser()
    {
        return NativeCalls.godot_icall_0_15(MethodBind29, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDenoiserStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDenoiserStrength(float denoiserStrength)
    {
        NativeCalls.godot_icall_1_67(MethodBind30, GodotObject.GetPtr(this), denoiserStrength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDenoiserStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDenoiserStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDenoiserRange, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDenoiserRange(int denoiserRange)
    {
        NativeCalls.godot_icall_1_38(MethodBind32, GodotObject.GetPtr(this), denoiserRange);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDenoiserRange, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDenoiserRange()
    {
        return NativeCalls.godot_icall_0_39(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInterior, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInterior(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind34, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInterior, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsInterior()
    {
        return NativeCalls.godot_icall_0_15(MethodBind35, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDirectional, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDirectional(bool directional)
    {
        NativeCalls.godot_icall_1_14(MethodBind36, GodotObject.GetPtr(this), directional.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDirectional, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDirectional()
    {
        return NativeCalls.godot_icall_0_15(MethodBind37, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowmaskMode, 3451066572ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowmaskMode(LightmapGIData.ShadowmaskMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind38, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowmaskMode, 785478560ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public LightmapGIData.ShadowmaskMode GetShadowmaskMode()
    {
        return (LightmapGIData.ShadowmaskMode)NativeCalls.godot_icall_0_39(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseTextureForBounces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseTextureForBounces(bool useTextureForBounces)
    {
        NativeCalls.godot_icall_1_14(MethodBind40, GodotObject.GetPtr(this), useTextureForBounces.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingTextureForBounces, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingTextureForBounces()
    {
        return NativeCalls.godot_icall_0_15(MethodBind41, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCameraAttributes, 2817810567ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCameraAttributes(CameraAttributes cameraAttributes)
    {
        NativeCalls.godot_icall_1_56(MethodBind42, GodotObject.GetPtr(this), GodotObject.GetPtr(cameraAttributes));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraAttributes, 3921283215ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CameraAttributes GetCameraAttributes()
    {
        return (CameraAttributes)NativeCalls.godot_icall_0_63(MethodBind43, GodotObject.GetPtr(this));
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
        /// Cached name for the 'quality' property.
        /// </summary>
        public static readonly StringName Quality = "quality";
        /// <summary>
        /// Cached name for the 'supersampling' property.
        /// </summary>
        public static readonly StringName Supersampling = "supersampling";
        /// <summary>
        /// Cached name for the 'supersampling_factor' property.
        /// </summary>
        public static readonly StringName SupersamplingFactor = "supersampling_factor";
        /// <summary>
        /// Cached name for the 'bounces' property.
        /// </summary>
        public static readonly StringName Bounces = "bounces";
        /// <summary>
        /// Cached name for the 'bounce_indirect_energy' property.
        /// </summary>
        public static readonly StringName BounceIndirectEnergy = "bounce_indirect_energy";
        /// <summary>
        /// Cached name for the 'directional' property.
        /// </summary>
        public static readonly StringName Directional = "directional";
        /// <summary>
        /// Cached name for the 'shadowmask_mode' property.
        /// </summary>
        public static readonly StringName ShadowmaskMode = "shadowmask_mode";
        /// <summary>
        /// Cached name for the 'use_texture_for_bounces' property.
        /// </summary>
        public static readonly StringName UseTextureForBounces = "use_texture_for_bounces";
        /// <summary>
        /// Cached name for the 'interior' property.
        /// </summary>
        public static readonly StringName Interior = "interior";
        /// <summary>
        /// Cached name for the 'use_denoiser' property.
        /// </summary>
        public static readonly StringName UseDenoiser = "use_denoiser";
        /// <summary>
        /// Cached name for the 'denoiser_strength' property.
        /// </summary>
        public static readonly StringName DenoiserStrength = "denoiser_strength";
        /// <summary>
        /// Cached name for the 'denoiser_range' property.
        /// </summary>
        public static readonly StringName DenoiserRange = "denoiser_range";
        /// <summary>
        /// Cached name for the 'bias' property.
        /// </summary>
        public static readonly StringName Bias = "bias";
        /// <summary>
        /// Cached name for the 'texel_scale' property.
        /// </summary>
        public static readonly StringName TexelScale = "texel_scale";
        /// <summary>
        /// Cached name for the 'max_texture_size' property.
        /// </summary>
        public static readonly StringName MaxTextureSize = "max_texture_size";
        /// <summary>
        /// Cached name for the 'environment_mode' property.
        /// </summary>
        public static readonly StringName EnvironmentMode = "environment_mode";
        /// <summary>
        /// Cached name for the 'environment_custom_sky' property.
        /// </summary>
        public static readonly StringName EnvironmentCustomSky = "environment_custom_sky";
        /// <summary>
        /// Cached name for the 'environment_custom_color' property.
        /// </summary>
        public static readonly StringName EnvironmentCustomColor = "environment_custom_color";
        /// <summary>
        /// Cached name for the 'environment_custom_energy' property.
        /// </summary>
        public static readonly StringName EnvironmentCustomEnergy = "environment_custom_energy";
        /// <summary>
        /// Cached name for the 'camera_attributes' property.
        /// </summary>
        public static readonly StringName CameraAttributes = "camera_attributes";
        /// <summary>
        /// Cached name for the 'generate_probes_subdiv' property.
        /// </summary>
        public static readonly StringName GenerateProbesSubdiv = "generate_probes_subdiv";
        /// <summary>
        /// Cached name for the 'light_data' property.
        /// </summary>
        public static readonly StringName LightData = "light_data";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_light_data' method.
        /// </summary>
        public static readonly StringName SetLightData = "set_light_data";
        /// <summary>
        /// Cached name for the 'get_light_data' method.
        /// </summary>
        public static readonly StringName GetLightData = "get_light_data";
        /// <summary>
        /// Cached name for the 'set_bake_quality' method.
        /// </summary>
        public static readonly StringName SetBakeQuality = "set_bake_quality";
        /// <summary>
        /// Cached name for the 'get_bake_quality' method.
        /// </summary>
        public static readonly StringName GetBakeQuality = "get_bake_quality";
        /// <summary>
        /// Cached name for the 'set_bounces' method.
        /// </summary>
        public static readonly StringName SetBounces = "set_bounces";
        /// <summary>
        /// Cached name for the 'get_bounces' method.
        /// </summary>
        public static readonly StringName GetBounces = "get_bounces";
        /// <summary>
        /// Cached name for the 'set_bounce_indirect_energy' method.
        /// </summary>
        public static readonly StringName SetBounceIndirectEnergy = "set_bounce_indirect_energy";
        /// <summary>
        /// Cached name for the 'get_bounce_indirect_energy' method.
        /// </summary>
        public static readonly StringName GetBounceIndirectEnergy = "get_bounce_indirect_energy";
        /// <summary>
        /// Cached name for the 'set_generate_probes' method.
        /// </summary>
        public static readonly StringName SetGenerateProbes = "set_generate_probes";
        /// <summary>
        /// Cached name for the 'get_generate_probes' method.
        /// </summary>
        public static readonly StringName GetGenerateProbes = "get_generate_probes";
        /// <summary>
        /// Cached name for the 'set_bias' method.
        /// </summary>
        public static readonly StringName SetBias = "set_bias";
        /// <summary>
        /// Cached name for the 'get_bias' method.
        /// </summary>
        public static readonly StringName GetBias = "get_bias";
        /// <summary>
        /// Cached name for the 'set_environment_mode' method.
        /// </summary>
        public static readonly StringName SetEnvironmentMode = "set_environment_mode";
        /// <summary>
        /// Cached name for the 'get_environment_mode' method.
        /// </summary>
        public static readonly StringName GetEnvironmentMode = "get_environment_mode";
        /// <summary>
        /// Cached name for the 'set_environment_custom_sky' method.
        /// </summary>
        public static readonly StringName SetEnvironmentCustomSky = "set_environment_custom_sky";
        /// <summary>
        /// Cached name for the 'get_environment_custom_sky' method.
        /// </summary>
        public static readonly StringName GetEnvironmentCustomSky = "get_environment_custom_sky";
        /// <summary>
        /// Cached name for the 'set_environment_custom_color' method.
        /// </summary>
        public static readonly StringName SetEnvironmentCustomColor = "set_environment_custom_color";
        /// <summary>
        /// Cached name for the 'get_environment_custom_color' method.
        /// </summary>
        public static readonly StringName GetEnvironmentCustomColor = "get_environment_custom_color";
        /// <summary>
        /// Cached name for the 'set_environment_custom_energy' method.
        /// </summary>
        public static readonly StringName SetEnvironmentCustomEnergy = "set_environment_custom_energy";
        /// <summary>
        /// Cached name for the 'get_environment_custom_energy' method.
        /// </summary>
        public static readonly StringName GetEnvironmentCustomEnergy = "get_environment_custom_energy";
        /// <summary>
        /// Cached name for the 'set_texel_scale' method.
        /// </summary>
        public static readonly StringName SetTexelScale = "set_texel_scale";
        /// <summary>
        /// Cached name for the 'get_texel_scale' method.
        /// </summary>
        public static readonly StringName GetTexelScale = "get_texel_scale";
        /// <summary>
        /// Cached name for the 'set_max_texture_size' method.
        /// </summary>
        public static readonly StringName SetMaxTextureSize = "set_max_texture_size";
        /// <summary>
        /// Cached name for the 'get_max_texture_size' method.
        /// </summary>
        public static readonly StringName GetMaxTextureSize = "get_max_texture_size";
        /// <summary>
        /// Cached name for the 'set_supersampling_enabled' method.
        /// </summary>
        public static readonly StringName SetSupersamplingEnabled = "set_supersampling_enabled";
        /// <summary>
        /// Cached name for the 'is_supersampling_enabled' method.
        /// </summary>
        public static readonly StringName IsSupersamplingEnabled = "is_supersampling_enabled";
        /// <summary>
        /// Cached name for the 'set_supersampling_factor' method.
        /// </summary>
        public static readonly StringName SetSupersamplingFactor = "set_supersampling_factor";
        /// <summary>
        /// Cached name for the 'get_supersampling_factor' method.
        /// </summary>
        public static readonly StringName GetSupersamplingFactor = "get_supersampling_factor";
        /// <summary>
        /// Cached name for the 'set_use_denoiser' method.
        /// </summary>
        public static readonly StringName SetUseDenoiser = "set_use_denoiser";
        /// <summary>
        /// Cached name for the 'is_using_denoiser' method.
        /// </summary>
        public static readonly StringName IsUsingDenoiser = "is_using_denoiser";
        /// <summary>
        /// Cached name for the 'set_denoiser_strength' method.
        /// </summary>
        public static readonly StringName SetDenoiserStrength = "set_denoiser_strength";
        /// <summary>
        /// Cached name for the 'get_denoiser_strength' method.
        /// </summary>
        public static readonly StringName GetDenoiserStrength = "get_denoiser_strength";
        /// <summary>
        /// Cached name for the 'set_denoiser_range' method.
        /// </summary>
        public static readonly StringName SetDenoiserRange = "set_denoiser_range";
        /// <summary>
        /// Cached name for the 'get_denoiser_range' method.
        /// </summary>
        public static readonly StringName GetDenoiserRange = "get_denoiser_range";
        /// <summary>
        /// Cached name for the 'set_interior' method.
        /// </summary>
        public static readonly StringName SetInterior = "set_interior";
        /// <summary>
        /// Cached name for the 'is_interior' method.
        /// </summary>
        public static readonly StringName IsInterior = "is_interior";
        /// <summary>
        /// Cached name for the 'set_directional' method.
        /// </summary>
        public static readonly StringName SetDirectional = "set_directional";
        /// <summary>
        /// Cached name for the 'is_directional' method.
        /// </summary>
        public static readonly StringName IsDirectional = "is_directional";
        /// <summary>
        /// Cached name for the 'set_shadowmask_mode' method.
        /// </summary>
        public static readonly StringName SetShadowmaskMode = "set_shadowmask_mode";
        /// <summary>
        /// Cached name for the 'get_shadowmask_mode' method.
        /// </summary>
        public static readonly StringName GetShadowmaskMode = "get_shadowmask_mode";
        /// <summary>
        /// Cached name for the 'set_use_texture_for_bounces' method.
        /// </summary>
        public static readonly StringName SetUseTextureForBounces = "set_use_texture_for_bounces";
        /// <summary>
        /// Cached name for the 'is_using_texture_for_bounces' method.
        /// </summary>
        public static readonly StringName IsUsingTextureForBounces = "is_using_texture_for_bounces";
        /// <summary>
        /// Cached name for the 'set_camera_attributes' method.
        /// </summary>
        public static readonly StringName SetCameraAttributes = "set_camera_attributes";
        /// <summary>
        /// Cached name for the 'get_camera_attributes' method.
        /// </summary>
        public static readonly StringName GetCameraAttributes = "get_camera_attributes";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
    }
}
