namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base node for geometry-based visual instances. Shares some common functionality like visibility and custom materials.</para>
/// </summary>
public partial class GeometryInstance3D : VisualInstance3D
{
    public enum ShadowCastingSetting : long
    {
        /// <summary>
        /// <para>Will not cast any shadows. Use this to improve performance for small geometry that is unlikely to cast noticeable shadows (such as debris).</para>
        /// </summary>
        Off = 0,
        /// <summary>
        /// <para>Will cast shadows from all visible faces in the GeometryInstance3D.</para>
        /// <para>Will take culling into account, so faces not being rendered will not be taken into account when shadow casting.</para>
        /// </summary>
        On = 1,
        /// <summary>
        /// <para>Will cast shadows from all visible faces in the GeometryInstance3D.</para>
        /// <para>Will not take culling into account, so all faces will be taken into account when shadow casting.</para>
        /// </summary>
        DoubleSided = 2,
        /// <summary>
        /// <para>Will only show the shadows casted from this object.</para>
        /// <para>In other words, the actual mesh will not be visible, only the shadows casted from the mesh will be.</para>
        /// </summary>
        ShadowsOnly = 3
    }

    public enum GIModeEnum : long
    {
        /// <summary>
        /// <para>Disabled global illumination mode. Use for dynamic objects that do not contribute to global illumination (such as characters). When using <see cref="Godot.VoxelGI"/> and SDFGI, the geometry will <i>receive</i> indirect lighting and reflections but the geometry will not be considered in GI baking.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Baked global illumination mode. Use for static objects that contribute to global illumination (such as level geometry). This GI mode is effective when using <see cref="Godot.VoxelGI"/>, SDFGI and <see cref="Godot.LightmapGI"/>.</para>
        /// </summary>
        Static = 1,
        /// <summary>
        /// <para>Dynamic global illumination mode. Use for dynamic objects that contribute to global illumination. This GI mode is only effective when using <see cref="Godot.VoxelGI"/>, but it has a higher performance impact than <see cref="Godot.GeometryInstance3D.GIModeEnum.Static"/>. When using other GI methods, this will act the same as <see cref="Godot.GeometryInstance3D.GIModeEnum.Disabled"/>. When using <see cref="Godot.LightmapGI"/>, the object will receive indirect lighting using lightmap probes instead of using the baked lightmap texture.</para>
        /// </summary>
        Dynamic = 2
    }

    public enum LightmapScale : long
    {
        /// <summary>
        /// <para>The standard texel density for lightmapping with <see cref="Godot.LightmapGI"/>.</para>
        /// </summary>
        [Obsolete("Use 'Godot.GeometryInstance3D.GILightmapTexelScale' instead.")]
        Scale1X = 0,
        /// <summary>
        /// <para>Multiplies texel density by 2× for lightmapping with <see cref="Godot.LightmapGI"/>. To ensure consistency in texel density, use this when scaling a mesh by a factor between 1.5 and 3.0.</para>
        /// </summary>
        [Obsolete("Use 'Godot.GeometryInstance3D.GILightmapTexelScale' instead.")]
        Scale2X = 1,
        /// <summary>
        /// <para>Multiplies texel density by 4× for lightmapping with <see cref="Godot.LightmapGI"/>. To ensure consistency in texel density, use this when scaling a mesh by a factor between 3.0 and 6.0.</para>
        /// </summary>
        [Obsolete("Use 'Godot.GeometryInstance3D.GILightmapTexelScale' instead.")]
        Scale4X = 2,
        /// <summary>
        /// <para>Multiplies texel density by 8× for lightmapping with <see cref="Godot.LightmapGI"/>. To ensure consistency in texel density, use this when scaling a mesh by a factor greater than 6.0.</para>
        /// </summary>
        [Obsolete("Use 'Godot.GeometryInstance3D.GILightmapTexelScale' instead.")]
        Scale8X = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.GeometryInstance3D.LightmapScale"/> enum.</para>
        /// </summary>
        [Obsolete("Use 'Godot.GeometryInstance3D.GILightmapTexelScale' instead.")]
        Max = 4
    }

    public enum VisibilityRangeFadeModeEnum : long
    {
        /// <summary>
        /// <para>Will not fade itself nor its visibility dependencies, hysteresis will be used instead. This is the fastest approach to manual LOD, but it can result in noticeable LOD transitions depending on how the LOD meshes are authored. See <see cref="Godot.GeometryInstance3D.VisibilityRangeBegin"/> and <see cref="Godot.Node3D.VisibilityParent"/> for more information.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Will fade-out itself when reaching the limits of its own visibility range. This is slower than <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeModeEnum.Disabled"/>, but it can provide smoother transitions. The fading range is determined by <see cref="Godot.GeometryInstance3D.VisibilityRangeBeginMargin"/> and <see cref="Godot.GeometryInstance3D.VisibilityRangeEndMargin"/>.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method. When using the Mobile or Compatibility rendering method, this mode acts like <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeModeEnum.Disabled"/> but with hysteresis disabled.</para>
        /// </summary>
        Self = 1,
        /// <summary>
        /// <para>Will fade-in its visibility dependencies (see <see cref="Godot.Node3D.VisibilityParent"/>) when reaching the limits of its own visibility range. This is slower than <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeModeEnum.Disabled"/>, but it can provide smoother transitions. The fading range is determined by <see cref="Godot.GeometryInstance3D.VisibilityRangeBeginMargin"/> and <see cref="Godot.GeometryInstance3D.VisibilityRangeEndMargin"/>.</para>
        /// <para><b>Note:</b> Only supported when using the Forward+ rendering method. When using the Mobile or Compatibility rendering method, this mode acts like <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeModeEnum.Disabled"/> but with hysteresis disabled.</para>
        /// </summary>
        Dependencies = 2
    }

    /// <summary>
    /// <para>The material override for the whole geometry.</para>
    /// <para>If a material is assigned to this property, it will be used instead of any material set in any material slot of the mesh.</para>
    /// </summary>
    public Material MaterialOverride
    {
        get
        {
            return GetMaterialOverride();
        }
        set
        {
            SetMaterialOverride(value);
        }
    }

    /// <summary>
    /// <para>The material overlay for the whole geometry.</para>
    /// <para>If a material is assigned to this property, it will be rendered on top of any other active material for all the surfaces.</para>
    /// </summary>
    public Material MaterialOverlay
    {
        get
        {
            return GetMaterialOverlay();
        }
        set
        {
            SetMaterialOverlay(value);
        }
    }

    /// <summary>
    /// <para>The transparency applied to the whole geometry (as a multiplier of the materials' existing transparency). <c>0.0</c> is fully opaque, while <c>1.0</c> is fully transparent. Values greater than <c>0.0</c> (exclusive) will force the geometry's materials to go through the transparent pipeline, which is slower to render and can exhibit rendering issues due to incorrect transparency sorting. However, unlike using a transparent material, setting <see cref="Godot.GeometryInstance3D.Transparency"/> to a value greater than <c>0.0</c> (exclusive) will <i>not</i> disable shadow rendering.</para>
    /// <para>In spatial shaders, <c>1.0 - transparency</c> is set as the default value of the <c>ALPHA</c> built-in.</para>
    /// <para><b>Note:</b> <see cref="Godot.GeometryInstance3D.Transparency"/> is clamped between <c>0.0</c> and <c>1.0</c>, so this property cannot be used to make transparent materials more opaque than they originally are.</para>
    /// <para><b>Note:</b> Only supported when using the Forward+ rendering method. When using the Mobile or Compatibility rendering method, <see cref="Godot.GeometryInstance3D.Transparency"/> is ignored and is considered as always being <c>0.0</c>.</para>
    /// </summary>
    public float Transparency
    {
        get
        {
            return GetTransparency();
        }
        set
        {
            SetTransparency(value);
        }
    }

    /// <summary>
    /// <para>The mode used to cast shadows from this instance.</para>
    /// </summary>
    public GeometryInstance3D.ShadowCastingSetting CastShadow
    {
        get
        {
            return GetCastShadowsSetting();
        }
        set
        {
            SetCastShadowsSetting(value);
        }
    }

    /// <summary>
    /// <para>The extra distance added to the GeometryInstance3D's bounding box (<see cref="Godot.Aabb"/>) to increase its cull box.</para>
    /// </summary>
    public float ExtraCullMargin
    {
        get
        {
            return GetExtraCullMargin();
        }
        set
        {
            SetExtraCullMargin(value);
        }
    }

    /// <summary>
    /// <para>Overrides the bounding box of this node with a custom one. This can be used to avoid the expensive <see cref="Godot.Aabb"/> recalculation that happens when a skeleton is used with a <see cref="Godot.MeshInstance3D"/> or to have precise control over the <see cref="Godot.MeshInstance3D"/>'s bounding box. To use the default AABB, set value to an <see cref="Godot.Aabb"/> with all fields set to <c>0.0</c>. To avoid frustum culling, set <see cref="Godot.GeometryInstance3D.CustomAabb"/> to a very large AABB that covers your entire game world such as <c>AABB(-10000, -10000, -10000, 20000, 20000, 20000)</c>. To disable all forms of culling (including occlusion culling), call <see cref="Godot.RenderingServer.InstanceSetIgnoreCulling(Rid, bool)"/> on the <see cref="Godot.GeometryInstance3D"/>'s <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public Aabb CustomAabb
    {
        get
        {
            return GetCustomAabb();
        }
        set
        {
            SetCustomAabb(value);
        }
    }

    /// <summary>
    /// <para>Changes how quickly the mesh transitions to a lower level of detail. A value of 0 will force the mesh to its lowest level of detail, a value of 1 will use the default settings, and larger values will keep the mesh in a higher level of detail at farther distances.</para>
    /// <para>Useful for testing level of detail transitions in the editor.</para>
    /// </summary>
    public float LodBias
    {
        get
        {
            return GetLodBias();
        }
        set
        {
            SetLodBias(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, disables occlusion culling for this instance. Useful for gizmos that must be rendered even when occlusion culling is in use.</para>
    /// <para><b>Note:</b> <see cref="Godot.GeometryInstance3D.IgnoreOcclusionCulling"/> does not affect frustum culling (which is what happens when an object is not visible given the camera's angle). To avoid frustum culling, set <see cref="Godot.GeometryInstance3D.CustomAabb"/> to a very large AABB that covers your entire game world such as <c>AABB(-10000, -10000, -10000, 20000, 20000, 20000)</c>.</para>
    /// </summary>
    public bool IgnoreOcclusionCulling
    {
        get
        {
            return IsIgnoringOcclusionCulling();
        }
        set
        {
            SetIgnoreOcclusionCulling(value);
        }
    }

    /// <summary>
    /// <para>The global illumination mode to use for the whole geometry. To avoid inconsistent results, use a mode that matches the purpose of the mesh during gameplay (static/dynamic).</para>
    /// <para><b>Note:</b> Lights' bake mode will also affect the global illumination rendering. See <see cref="Godot.Light3D.LightBakeMode"/>.</para>
    /// </summary>
    public GeometryInstance3D.GIModeEnum GIMode
    {
        get
        {
            return GetGIMode();
        }
        set
        {
            SetGIMode(value);
        }
    }

    /// <summary>
    /// <para>The texel density to use for lightmapping in <see cref="Godot.LightmapGI"/>. Greater scale values provide higher resolution in the lightmap, which can result in sharper shadows for lights that have both direct and indirect light baked. However, greater scale values will also increase the space taken by the mesh in the lightmap texture, which increases the memory, storage, and bake time requirements. When using a single mesh at different scales, consider adjusting this value to keep the lightmap texel density consistent across meshes.</para>
    /// <para>For example, doubling <see cref="Godot.GeometryInstance3D.GILightmapTexelScale"/> doubles the lightmap texture resolution for this object <i>on each axis</i>, so it will <i>quadruple</i> the texel count.</para>
    /// </summary>
    public float GILightmapTexelScale
    {
        get
        {
            return GetLightmapTexelScale();
        }
        set
        {
            SetLightmapTexelScale(value);
        }
    }

    /// <summary>
    /// <para>The texel density to use for lightmapping in <see cref="Godot.LightmapGI"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.GeometryInstance3D.GILightmapTexelScale' instead.")]
    public GeometryInstance3D.LightmapScale GILightmapScale
    {
        get
        {
            return GetLightmapScale();
        }
        set
        {
            SetLightmapScale(value);
        }
    }

    /// <summary>
    /// <para>Starting distance from which the GeometryInstance3D will be visible, taking <see cref="Godot.GeometryInstance3D.VisibilityRangeBeginMargin"/> into account as well. The default value of 0 is used to disable the range check.</para>
    /// </summary>
    public float VisibilityRangeBegin
    {
        get
        {
            return GetVisibilityRangeBegin();
        }
        set
        {
            SetVisibilityRangeBegin(value);
        }
    }

    /// <summary>
    /// <para>Margin for the <see cref="Godot.GeometryInstance3D.VisibilityRangeBegin"/> threshold. The GeometryInstance3D will only change its visibility state when it goes over or under the <see cref="Godot.GeometryInstance3D.VisibilityRangeBegin"/> threshold by this amount.</para>
    /// <para>If <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeMode"/> is <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeModeEnum.Disabled"/>, this acts as a hysteresis distance. If <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeMode"/> is <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeModeEnum.Self"/> or <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeModeEnum.Dependencies"/>, this acts as a fade transition distance and must be set to a value greater than <c>0.0</c> for the effect to be noticeable.</para>
    /// </summary>
    public float VisibilityRangeBeginMargin
    {
        get
        {
            return GetVisibilityRangeBeginMargin();
        }
        set
        {
            SetVisibilityRangeBeginMargin(value);
        }
    }

    /// <summary>
    /// <para>Distance from which the GeometryInstance3D will be hidden, taking <see cref="Godot.GeometryInstance3D.VisibilityRangeEndMargin"/> into account as well. The default value of 0 is used to disable the range check.</para>
    /// </summary>
    public float VisibilityRangeEnd
    {
        get
        {
            return GetVisibilityRangeEnd();
        }
        set
        {
            SetVisibilityRangeEnd(value);
        }
    }

    /// <summary>
    /// <para>Margin for the <see cref="Godot.GeometryInstance3D.VisibilityRangeEnd"/> threshold. The GeometryInstance3D will only change its visibility state when it goes over or under the <see cref="Godot.GeometryInstance3D.VisibilityRangeEnd"/> threshold by this amount.</para>
    /// <para>If <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeMode"/> is <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeModeEnum.Disabled"/>, this acts as a hysteresis distance. If <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeMode"/> is <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeModeEnum.Self"/> or <see cref="Godot.GeometryInstance3D.VisibilityRangeFadeModeEnum.Dependencies"/>, this acts as a fade transition distance and must be set to a value greater than <c>0.0</c> for the effect to be noticeable.</para>
    /// </summary>
    public float VisibilityRangeEndMargin
    {
        get
        {
            return GetVisibilityRangeEndMargin();
        }
        set
        {
            SetVisibilityRangeEndMargin(value);
        }
    }

    /// <summary>
    /// <para>Controls which instances will be faded when approaching the limits of the visibility range.</para>
    /// </summary>
    public GeometryInstance3D.VisibilityRangeFadeModeEnum VisibilityRangeFadeMode
    {
        get
        {
            return GetVisibilityRangeFadeMode();
        }
        set
        {
            SetVisibilityRangeFadeMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GeometryInstance3D);

    private static readonly StringName NativeName = "GeometryInstance3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GeometryInstance3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GeometryInstance3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GeometryInstance3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaterialOverride, 2757459619ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaterialOverride(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaterialOverride, 5934680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Material GetMaterialOverride()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaterialOverlay, 2757459619ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaterialOverlay(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaterialOverlay, 5934680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Material GetMaterialOverlay()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCastShadowsSetting, 856677339ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCastShadowsSetting(GeometryInstance3D.ShadowCastingSetting shadowCastingSetting)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)shadowCastingSetting);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCastShadowsSetting, 3383019359ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GeometryInstance3D.ShadowCastingSetting GetCastShadowsSetting()
    {
        return (GeometryInstance3D.ShadowCastingSetting)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLodBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLodBias(float bias)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLodBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLodBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransparency, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTransparency(float transparency)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), transparency);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransparency, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTransparency()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRangeEndMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityRangeEndMargin(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRangeEndMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVisibilityRangeEndMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRangeEnd, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityRangeEnd(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRangeEnd, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVisibilityRangeEnd()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRangeBeginMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityRangeBeginMargin(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRangeBeginMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVisibilityRangeBeginMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRangeBegin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityRangeBegin(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRangeBegin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVisibilityRangeBegin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityRangeFadeMode, 1440117808ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityRangeFadeMode(GeometryInstance3D.VisibilityRangeFadeModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityRangeFadeMode, 2067221882ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GeometryInstance3D.VisibilityRangeFadeModeEnum GetVisibilityRangeFadeMode()
    {
        return (GeometryInstance3D.VisibilityRangeFadeModeEnum)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInstanceShaderParameter, 3776071444ul);

    /// <summary>
    /// <para>Set the value of a shader uniform for this instance only (<a href="$DOCS_URL/tutorials/shaders/shader_reference/shading_language.html#per-instance-uniforms">per-instance uniform</a>). See also <see cref="Godot.ShaderMaterial.SetShaderParameter(StringName, Variant)"/> to assign a uniform on all instances using the same <see cref="Godot.ShaderMaterial"/>.</para>
    /// <para><b>Note:</b> For a shader uniform to be assignable on a per-instance basis, it <i>must</i> be defined with <c>instance uniform ...</c> rather than <c>uniform ...</c> in the shader code.</para>
    /// <para><b>Note:</b> <paramref name="name"/> is case-sensitive and must match the name of the uniform in the code exactly (not the capitalized name in the inspector).</para>
    /// <para><b>Note:</b> Per-instance shader uniforms are only available in Spatial and CanvasItem shaders, but not for Fog, Sky, or Particles shaders.</para>
    /// </summary>
    public void SetInstanceShaderParameter(StringName name, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind20, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceShaderParameter, 2760726917ul);

    /// <summary>
    /// <para>Get the value of a shader parameter as set on this instance.</para>
    /// </summary>
    public Variant GetInstanceShaderParameter(StringName name)
    {
        return NativeCalls.godot_icall_1_143(MethodBind21, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExtraCullMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExtraCullMargin(float margin)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExtraCullMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetExtraCullMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLightmapTexelScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLightmapTexelScale(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLightmapTexelScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLightmapTexelScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLightmapScale, 2462696582ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLightmapScale(GeometryInstance3D.LightmapScale scale)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), (int)scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLightmapScale, 798767852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GeometryInstance3D.LightmapScale GetLightmapScale()
    {
        return (GeometryInstance3D.LightmapScale)NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGIMode, 2548557163ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGIMode(GeometryInstance3D.GIModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGIMode, 2188566509ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GeometryInstance3D.GIModeEnum GetGIMode()
    {
        return (GeometryInstance3D.GIModeEnum)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgnoreOcclusionCulling, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgnoreOcclusionCulling(bool ignoreCulling)
    {
        NativeCalls.godot_icall_1_14(MethodBind30, GodotObject.GetPtr(this), ignoreCulling.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsIgnoringOcclusionCulling, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsIgnoringOcclusionCulling()
    {
        return NativeCalls.godot_icall_0_15(MethodBind31, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomAabb, 259215842ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCustomAabb(Aabb aabb)
    {
        NativeCalls.godot_icall_1_183(MethodBind32, GodotObject.GetPtr(this), &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomAabb, 1068685055ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Aabb GetCustomAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind33, GodotObject.GetPtr(this));
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
        /// Cached name for the 'material_override' property.
        /// </summary>
        public static readonly StringName MaterialOverride = "material_override";
        /// <summary>
        /// Cached name for the 'material_overlay' property.
        /// </summary>
        public static readonly StringName MaterialOverlay = "material_overlay";
        /// <summary>
        /// Cached name for the 'transparency' property.
        /// </summary>
        public static readonly StringName Transparency = "transparency";
        /// <summary>
        /// Cached name for the 'cast_shadow' property.
        /// </summary>
        public static readonly StringName CastShadow = "cast_shadow";
        /// <summary>
        /// Cached name for the 'extra_cull_margin' property.
        /// </summary>
        public static readonly StringName ExtraCullMargin = "extra_cull_margin";
        /// <summary>
        /// Cached name for the 'custom_aabb' property.
        /// </summary>
        public static readonly StringName CustomAabb = "custom_aabb";
        /// <summary>
        /// Cached name for the 'lod_bias' property.
        /// </summary>
        public static readonly StringName LodBias = "lod_bias";
        /// <summary>
        /// Cached name for the 'ignore_occlusion_culling' property.
        /// </summary>
        public static readonly StringName IgnoreOcclusionCulling = "ignore_occlusion_culling";
        /// <summary>
        /// Cached name for the 'gi_mode' property.
        /// </summary>
        public static readonly StringName GIMode = "gi_mode";
        /// <summary>
        /// Cached name for the 'gi_lightmap_texel_scale' property.
        /// </summary>
        public static readonly StringName GILightmapTexelScale = "gi_lightmap_texel_scale";
        /// <summary>
        /// Cached name for the 'gi_lightmap_scale' property.
        /// </summary>
        public static readonly StringName GILightmapScale = "gi_lightmap_scale";
        /// <summary>
        /// Cached name for the 'visibility_range_begin' property.
        /// </summary>
        public static readonly StringName VisibilityRangeBegin = "visibility_range_begin";
        /// <summary>
        /// Cached name for the 'visibility_range_begin_margin' property.
        /// </summary>
        public static readonly StringName VisibilityRangeBeginMargin = "visibility_range_begin_margin";
        /// <summary>
        /// Cached name for the 'visibility_range_end' property.
        /// </summary>
        public static readonly StringName VisibilityRangeEnd = "visibility_range_end";
        /// <summary>
        /// Cached name for the 'visibility_range_end_margin' property.
        /// </summary>
        public static readonly StringName VisibilityRangeEndMargin = "visibility_range_end_margin";
        /// <summary>
        /// Cached name for the 'visibility_range_fade_mode' property.
        /// </summary>
        public static readonly StringName VisibilityRangeFadeMode = "visibility_range_fade_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_material_override' method.
        /// </summary>
        public static readonly StringName SetMaterialOverride = "set_material_override";
        /// <summary>
        /// Cached name for the 'get_material_override' method.
        /// </summary>
        public static readonly StringName GetMaterialOverride = "get_material_override";
        /// <summary>
        /// Cached name for the 'set_material_overlay' method.
        /// </summary>
        public static readonly StringName SetMaterialOverlay = "set_material_overlay";
        /// <summary>
        /// Cached name for the 'get_material_overlay' method.
        /// </summary>
        public static readonly StringName GetMaterialOverlay = "get_material_overlay";
        /// <summary>
        /// Cached name for the 'set_cast_shadows_setting' method.
        /// </summary>
        public static readonly StringName SetCastShadowsSetting = "set_cast_shadows_setting";
        /// <summary>
        /// Cached name for the 'get_cast_shadows_setting' method.
        /// </summary>
        public static readonly StringName GetCastShadowsSetting = "get_cast_shadows_setting";
        /// <summary>
        /// Cached name for the 'set_lod_bias' method.
        /// </summary>
        public static readonly StringName SetLodBias = "set_lod_bias";
        /// <summary>
        /// Cached name for the 'get_lod_bias' method.
        /// </summary>
        public static readonly StringName GetLodBias = "get_lod_bias";
        /// <summary>
        /// Cached name for the 'set_transparency' method.
        /// </summary>
        public static readonly StringName SetTransparency = "set_transparency";
        /// <summary>
        /// Cached name for the 'get_transparency' method.
        /// </summary>
        public static readonly StringName GetTransparency = "get_transparency";
        /// <summary>
        /// Cached name for the 'set_visibility_range_end_margin' method.
        /// </summary>
        public static readonly StringName SetVisibilityRangeEndMargin = "set_visibility_range_end_margin";
        /// <summary>
        /// Cached name for the 'get_visibility_range_end_margin' method.
        /// </summary>
        public static readonly StringName GetVisibilityRangeEndMargin = "get_visibility_range_end_margin";
        /// <summary>
        /// Cached name for the 'set_visibility_range_end' method.
        /// </summary>
        public static readonly StringName SetVisibilityRangeEnd = "set_visibility_range_end";
        /// <summary>
        /// Cached name for the 'get_visibility_range_end' method.
        /// </summary>
        public static readonly StringName GetVisibilityRangeEnd = "get_visibility_range_end";
        /// <summary>
        /// Cached name for the 'set_visibility_range_begin_margin' method.
        /// </summary>
        public static readonly StringName SetVisibilityRangeBeginMargin = "set_visibility_range_begin_margin";
        /// <summary>
        /// Cached name for the 'get_visibility_range_begin_margin' method.
        /// </summary>
        public static readonly StringName GetVisibilityRangeBeginMargin = "get_visibility_range_begin_margin";
        /// <summary>
        /// Cached name for the 'set_visibility_range_begin' method.
        /// </summary>
        public static readonly StringName SetVisibilityRangeBegin = "set_visibility_range_begin";
        /// <summary>
        /// Cached name for the 'get_visibility_range_begin' method.
        /// </summary>
        public static readonly StringName GetVisibilityRangeBegin = "get_visibility_range_begin";
        /// <summary>
        /// Cached name for the 'set_visibility_range_fade_mode' method.
        /// </summary>
        public static readonly StringName SetVisibilityRangeFadeMode = "set_visibility_range_fade_mode";
        /// <summary>
        /// Cached name for the 'get_visibility_range_fade_mode' method.
        /// </summary>
        public static readonly StringName GetVisibilityRangeFadeMode = "get_visibility_range_fade_mode";
        /// <summary>
        /// Cached name for the 'set_instance_shader_parameter' method.
        /// </summary>
        public static readonly StringName SetInstanceShaderParameter = "set_instance_shader_parameter";
        /// <summary>
        /// Cached name for the 'get_instance_shader_parameter' method.
        /// </summary>
        public static readonly StringName GetInstanceShaderParameter = "get_instance_shader_parameter";
        /// <summary>
        /// Cached name for the 'set_extra_cull_margin' method.
        /// </summary>
        public static readonly StringName SetExtraCullMargin = "set_extra_cull_margin";
        /// <summary>
        /// Cached name for the 'get_extra_cull_margin' method.
        /// </summary>
        public static readonly StringName GetExtraCullMargin = "get_extra_cull_margin";
        /// <summary>
        /// Cached name for the 'set_lightmap_texel_scale' method.
        /// </summary>
        public static readonly StringName SetLightmapTexelScale = "set_lightmap_texel_scale";
        /// <summary>
        /// Cached name for the 'get_lightmap_texel_scale' method.
        /// </summary>
        public static readonly StringName GetLightmapTexelScale = "get_lightmap_texel_scale";
        /// <summary>
        /// Cached name for the 'set_lightmap_scale' method.
        /// </summary>
        public static readonly StringName SetLightmapScale = "set_lightmap_scale";
        /// <summary>
        /// Cached name for the 'get_lightmap_scale' method.
        /// </summary>
        public static readonly StringName GetLightmapScale = "get_lightmap_scale";
        /// <summary>
        /// Cached name for the 'set_gi_mode' method.
        /// </summary>
        public static readonly StringName SetGIMode = "set_gi_mode";
        /// <summary>
        /// Cached name for the 'get_gi_mode' method.
        /// </summary>
        public static readonly StringName GetGIMode = "get_gi_mode";
        /// <summary>
        /// Cached name for the 'set_ignore_occlusion_culling' method.
        /// </summary>
        public static readonly StringName SetIgnoreOcclusionCulling = "set_ignore_occlusion_culling";
        /// <summary>
        /// Cached name for the 'is_ignoring_occlusion_culling' method.
        /// </summary>
        public static readonly StringName IsIgnoringOcclusionCulling = "is_ignoring_occlusion_culling";
        /// <summary>
        /// Cached name for the 'set_custom_aabb' method.
        /// </summary>
        public static readonly StringName SetCustomAabb = "set_custom_aabb";
        /// <summary>
        /// Cached name for the 'get_custom_aabb' method.
        /// </summary>
        public static readonly StringName GetCustomAabb = "get_custom_aabb";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
    }
}
