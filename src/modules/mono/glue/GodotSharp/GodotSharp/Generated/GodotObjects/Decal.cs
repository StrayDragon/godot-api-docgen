namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.Decal"/>s are used to project a texture onto a <see cref="Godot.Mesh"/> in the scene. Use Decals to add detail to a scene without affecting the underlying <see cref="Godot.Mesh"/>. They are often used to add weathering to building, add dirt or mud to the ground, or add variety to props. Decals can be moved at any time, making them suitable for things like blob shadows or laser sight dots.</para>
/// <para>They are made of an <see cref="Godot.Aabb"/> and a group of <see cref="Godot.Texture2D"/>s specifying <see cref="Godot.Color"/>, normal, ORM (ambient occlusion, roughness, metallic), and emission. Decals are projected within their <see cref="Godot.Aabb"/> so altering the orientation of the Decal affects the direction in which they are projected. By default, Decals are projected down (i.e. from positive Y to negative Y).</para>
/// <para>The <see cref="Godot.Texture2D"/>s associated with the Decal are automatically stored in a texture atlas which is used for drawing the decals so all decals can be drawn at once. Godot uses clustered decals, meaning they are stored in cluster data and drawn when the mesh is drawn, they are not drawn as a post-processing effect after.</para>
/// <para><b>Note:</b> Decals cannot affect an underlying material's transparency, regardless of its transparency mode (alpha blend, alpha scissor, alpha hash, opaque pre-pass). This means translucent or transparent areas of a material will remain translucent or transparent even if an opaque decal is applied on them.</para>
/// <para><b>Note:</b> Decals are only supported in the Forward+ and Mobile rendering methods, not Compatibility. When using the Mobile rendering method, only 8 decals can be displayed on each mesh resource. Attempting to display more than 8 decals on a single mesh resource will result in decals flickering in and out as the camera moves.</para>
/// <para><b>Note:</b> When using the Mobile rendering method, decals will only correctly affect meshes whose visibility AABB intersects with the decal's AABB. If using a shader to deform the mesh in a way that makes it go outside its AABB, <see cref="Godot.GeometryInstance3D.ExtraCullMargin"/> must be increased on the mesh. Otherwise, the decal may not be visible on the mesh.</para>
/// </summary>
public partial class Decal : VisualInstance3D
{
    public enum DecalTexture : long
    {
        /// <summary>
        /// <para><see cref="Godot.Texture2D"/> corresponding to <see cref="Godot.Decal.TextureAlbedo"/>.</para>
        /// </summary>
        Albedo = 0,
        /// <summary>
        /// <para><see cref="Godot.Texture2D"/> corresponding to <see cref="Godot.Decal.TextureNormal"/>.</para>
        /// </summary>
        Normal = 1,
        /// <summary>
        /// <para><see cref="Godot.Texture2D"/> corresponding to <see cref="Godot.Decal.TextureOrm"/>.</para>
        /// </summary>
        Orm = 2,
        /// <summary>
        /// <para><see cref="Godot.Texture2D"/> corresponding to <see cref="Godot.Decal.TextureEmission"/>.</para>
        /// </summary>
        Emission = 3,
        /// <summary>
        /// <para>Max size of <see cref="Godot.Decal.DecalTexture"/> enum.</para>
        /// </summary>
        Max = 4
    }

    /// <summary>
    /// <para>Sets the size of the <see cref="Godot.Aabb"/> used by the decal. All dimensions must be set to a value greater than zero (they will be clamped to <c>0.001</c> if this is not the case). The AABB goes from <c>-size/2</c> to <c>size/2</c>.</para>
    /// <para><b>Note:</b> To improve culling efficiency of "hard surface" decals, set their <see cref="Godot.Decal.UpperFade"/> and <see cref="Godot.Decal.LowerFade"/> to <c>0.0</c> and set the Y component of the <see cref="Godot.Decal.Size"/> as low as possible. This will reduce the decals' AABB size without affecting their appearance.</para>
    /// </summary>
    public Vector3 Size
    {
        get
        {
            return GetSize();
        }
        set
        {
            SetSize(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Texture2D"/> with the base <see cref="Godot.Color"/> of the Decal. Either this or the <see cref="Godot.Decal.TextureEmission"/> must be set for the Decal to be visible. Use the alpha channel like a mask to smoothly blend the edges of the decal with the underlying object.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.BaseMaterial3D"/> whose filter mode can be adjusted on a per-material basis, the filter mode for <see cref="Godot.Decal"/> textures is set globally with <c>ProjectSettings.rendering/textures/decals/filter</c>.</para>
    /// </summary>
    public Texture2D TextureAlbedo
    {
        get
        {
            return GetTexture((Decal.DecalTexture)(0));
        }
        set
        {
            SetTexture((Decal.DecalTexture)(0), value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Texture2D"/> with the per-pixel normal map for the decal. Use this to add extra detail to decals.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.BaseMaterial3D"/> whose filter mode can be adjusted on a per-material basis, the filter mode for <see cref="Godot.Decal"/> textures is set globally with <c>ProjectSettings.rendering/textures/decals/filter</c>.</para>
    /// <para><b>Note:</b> Setting this texture alone will not result in a visible decal, as <see cref="Godot.Decal.TextureAlbedo"/> must also be set. To create a normal-only decal, load an albedo texture into <see cref="Godot.Decal.TextureAlbedo"/> and set <see cref="Godot.Decal.AlbedoMix"/> to <c>0.0</c>. The albedo texture's alpha channel will be used to determine where the underlying surface's normal map should be overridden (and its intensity).</para>
    /// </summary>
    public Texture2D TextureNormal
    {
        get
        {
            return GetTexture((Decal.DecalTexture)(1));
        }
        set
        {
            SetTexture((Decal.DecalTexture)(1), value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Texture2D"/> storing ambient occlusion, roughness, and metallic for the decal. Use this to add extra detail to decals.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.BaseMaterial3D"/> whose filter mode can be adjusted on a per-material basis, the filter mode for <see cref="Godot.Decal"/> textures is set globally with <c>ProjectSettings.rendering/textures/decals/filter</c>.</para>
    /// <para><b>Note:</b> Setting this texture alone will not result in a visible decal, as <see cref="Godot.Decal.TextureAlbedo"/> must also be set. To create an ORM-only decal, load an albedo texture into <see cref="Godot.Decal.TextureAlbedo"/> and set <see cref="Godot.Decal.AlbedoMix"/> to <c>0.0</c>. The albedo texture's alpha channel will be used to determine where the underlying surface's ORM map should be overridden (and its intensity).</para>
    /// </summary>
    public Texture2D TextureOrm
    {
        get
        {
            return GetTexture((Decal.DecalTexture)(2));
        }
        set
        {
            SetTexture((Decal.DecalTexture)(2), value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Texture2D"/> with the emission <see cref="Godot.Color"/> of the Decal. Either this or the <see cref="Godot.Decal.TextureAlbedo"/> must be set for the Decal to be visible. Use the alpha channel like a mask to smoothly blend the edges of the decal with the underlying object.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.BaseMaterial3D"/> whose filter mode can be adjusted on a per-material basis, the filter mode for <see cref="Godot.Decal"/> textures is set globally with <c>ProjectSettings.rendering/textures/decals/filter</c>.</para>
    /// </summary>
    public Texture2D TextureEmission
    {
        get
        {
            return GetTexture((Decal.DecalTexture)(3));
        }
        set
        {
            SetTexture((Decal.DecalTexture)(3), value);
        }
    }

    /// <summary>
    /// <para>Energy multiplier for the emission texture. This will make the decal emit light at a higher or lower intensity, independently of the albedo color. See also <see cref="Godot.Decal.Modulate"/>.</para>
    /// </summary>
    public float EmissionEnergy
    {
        get
        {
            return GetEmissionEnergy();
        }
        set
        {
            SetEmissionEnergy(value);
        }
    }

    /// <summary>
    /// <para>Changes the <see cref="Godot.Color"/> of the Decal by multiplying the albedo and emission colors with this value. The alpha component is only taken into account when multiplying the albedo color, not the emission color. See also <see cref="Godot.Decal.EmissionEnergy"/> and <see cref="Godot.Decal.AlbedoMix"/> to change the emission and albedo intensity independently of each other.</para>
    /// </summary>
    public Color Modulate
    {
        get
        {
            return GetModulate();
        }
        set
        {
            SetModulate(value);
        }
    }

    /// <summary>
    /// <para>Blends the albedo <see cref="Godot.Color"/> of the decal with albedo <see cref="Godot.Color"/> of the underlying mesh. This can be set to <c>0.0</c> to create a decal that only affects normal or ORM. In this case, an albedo texture is still required as its alpha channel will determine where the normal and ORM will be overridden. See also <see cref="Godot.Decal.Modulate"/>.</para>
    /// </summary>
    public float AlbedoMix
    {
        get
        {
            return GetAlbedoMix();
        }
        set
        {
            SetAlbedoMix(value);
        }
    }

    /// <summary>
    /// <para>Fades the Decal if the angle between the Decal's <see cref="Godot.Aabb"/> and the target surface becomes too large. A value of <c>0</c> projects the Decal regardless of angle, a value of <c>1</c> limits the Decal to surfaces that are nearly perpendicular.</para>
    /// <para><b>Note:</b> Setting <see cref="Godot.Decal.NormalFade"/> to a value greater than <c>0.0</c> has a small performance cost due to the added normal angle computations.</para>
    /// </summary>
    public float NormalFade
    {
        get
        {
            return GetNormalFade();
        }
        set
        {
            SetNormalFade(value);
        }
    }

    /// <summary>
    /// <para>Sets the curve over which the decal will fade as the surface gets further from the center of the <see cref="Godot.Aabb"/>. Only positive values are valid (negative values will be clamped to <c>0.0</c>). See also <see cref="Godot.Decal.LowerFade"/>.</para>
    /// </summary>
    public float UpperFade
    {
        get
        {
            return GetUpperFade();
        }
        set
        {
            SetUpperFade(value);
        }
    }

    /// <summary>
    /// <para>Sets the curve over which the decal will fade as the surface gets further from the center of the <see cref="Godot.Aabb"/>. Only positive values are valid (negative values will be clamped to <c>0.0</c>). See also <see cref="Godot.Decal.UpperFade"/>.</para>
    /// </summary>
    public float LowerFade
    {
        get
        {
            return GetLowerFade();
        }
        set
        {
            SetLowerFade(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, decals will smoothly fade away when far from the active <see cref="Godot.Camera3D"/> starting at <see cref="Godot.Decal.DistanceFadeBegin"/>. The Decal will fade out over <see cref="Godot.Decal.DistanceFadeBegin"/> + <see cref="Godot.Decal.DistanceFadeLength"/>, after which it will be culled and not sent to the shader at all. Use this to reduce the number of active Decals in a scene and thus improve performance.</para>
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
    /// <para>The distance from the camera at which the Decal begins to fade away (in 3D units).</para>
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
    /// <para>The distance over which the Decal fades (in 3D units). The Decal becomes slowly more transparent over this distance and is completely invisible at the end. Higher values result in a smoother fade-out transition, which is more suited when the camera moves fast.</para>
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
    /// <para>Specifies which <see cref="Godot.VisualInstance3D.Layers"/> this decal will project on. By default, Decals affect all layers. This is used so you can specify which types of objects receive the Decal and which do not. This is especially useful so you can ensure that dynamic objects don't accidentally receive a Decal intended for the terrain under them.</para>
    /// </summary>
    public uint CullMask
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

    private static readonly System.Type CachedType = typeof(Decal);

    private static readonly StringName NativeName = "Decal";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Decal() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Decal(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Decal(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector3 size)
    {
        NativeCalls.godot_icall_1_177(MethodBind0, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetSize()
    {
        return NativeCalls.godot_icall_0_125(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexture, 2086764391ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Texture2D"/> associated with the specified <see cref="Godot.Decal.DecalTexture"/>. This is a convenience method, in most cases you should access the texture directly.</para>
    /// <para>For example, instead of <c>$Decal.set_texture(Decal.TEXTURE_ALBEDO, albedo_tex)</c>, use <c>$Decal.texture_albedo = albedo_tex</c>.</para>
    /// <para>One case where this is better than accessing the texture directly is when you want to copy one Decal's textures to another. For example:</para>
    /// <para><code>
    /// for (int i = 0; i &lt; (int)Decal.DecalTexture.Max; i++)
    /// {
    /// 	GetNode&lt;Decal&gt;("NewDecal").SetTexture(i, GetNode&lt;Decal&gt;("OldDecal").GetTexture(i));
    /// }
    /// </code></para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexture(Decal.DecalTexture type, Texture2D texture)
    {
        NativeCalls.godot_icall_2_70(MethodBind2, GodotObject.GetPtr(this), (int)type, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 3244119503ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Texture2D"/> associated with the specified <see cref="Godot.Decal.DecalTexture"/>. This is a convenience method, in most cases you should access the texture directly.</para>
    /// <para>For example, instead of <c>albedo_tex = $Decal.get_texture(Decal.TEXTURE_ALBEDO)</c>, use <c>albedo_tex = $Decal.texture_albedo</c>.</para>
    /// <para>One case where this is better than accessing the texture directly is when you want to copy one Decal's textures to another. For example:</para>
    /// <para><code>
    /// for (int i = 0; i &lt; (int)Decal.DecalTexture.Max; i++)
    /// {
    /// 	GetNode&lt;Decal&gt;("NewDecal").SetTexture(i, GetNode&lt;Decal&gt;("OldDecal").GetTexture(i));
    /// }
    /// </code></para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTexture(Decal.DecalTexture type)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind3, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionEnergy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionEnergy(float energy)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionEnergy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionEnergy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlbedoMix, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlbedoMix(float energy)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlbedoMix, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAlbedoMix()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModulate, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetModulate(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind8, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModulate, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetModulate()
    {
        return NativeCalls.godot_icall_0_214(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUpperFade, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUpperFade(float fade)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), fade);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUpperFade, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetUpperFade()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLowerFade, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLowerFade(float fade)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), fade);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLowerFade, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLowerFade()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNormalFade, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNormalFade(float fade)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), fade);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNormalFade, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetNormalFade()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableDistanceFade, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableDistanceFade(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDistanceFadeEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDistanceFadeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDistanceFadeBegin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDistanceFadeBegin(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDistanceFadeBegin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDistanceFadeBegin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDistanceFadeLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDistanceFadeLength(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDistanceFadeLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDistanceFadeLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCullMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCullMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind22, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCullMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCullMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind23, GodotObject.GetPtr(this));
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
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'texture_albedo' property.
        /// </summary>
        public static readonly StringName TextureAlbedo = "texture_albedo";
        /// <summary>
        /// Cached name for the 'texture_normal' property.
        /// </summary>
        public static readonly StringName TextureNormal = "texture_normal";
        /// <summary>
        /// Cached name for the 'texture_orm' property.
        /// </summary>
        public static readonly StringName TextureOrm = "texture_orm";
        /// <summary>
        /// Cached name for the 'texture_emission' property.
        /// </summary>
        public static readonly StringName TextureEmission = "texture_emission";
        /// <summary>
        /// Cached name for the 'emission_energy' property.
        /// </summary>
        public static readonly StringName EmissionEnergy = "emission_energy";
        /// <summary>
        /// Cached name for the 'modulate' property.
        /// </summary>
        public static readonly StringName Modulate = "modulate";
        /// <summary>
        /// Cached name for the 'albedo_mix' property.
        /// </summary>
        public static readonly StringName AlbedoMix = "albedo_mix";
        /// <summary>
        /// Cached name for the 'normal_fade' property.
        /// </summary>
        public static readonly StringName NormalFade = "normal_fade";
        /// <summary>
        /// Cached name for the 'upper_fade' property.
        /// </summary>
        public static readonly StringName UpperFade = "upper_fade";
        /// <summary>
        /// Cached name for the 'lower_fade' property.
        /// </summary>
        public static readonly StringName LowerFade = "lower_fade";
        /// <summary>
        /// Cached name for the 'distance_fade_enabled' property.
        /// </summary>
        public static readonly StringName DistanceFadeEnabled = "distance_fade_enabled";
        /// <summary>
        /// Cached name for the 'distance_fade_begin' property.
        /// </summary>
        public static readonly StringName DistanceFadeBegin = "distance_fade_begin";
        /// <summary>
        /// Cached name for the 'distance_fade_length' property.
        /// </summary>
        public static readonly StringName DistanceFadeLength = "distance_fade_length";
        /// <summary>
        /// Cached name for the 'cull_mask' property.
        /// </summary>
        public static readonly StringName CullMask = "cull_mask";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'set_texture' method.
        /// </summary>
        public static readonly StringName SetTexture = "set_texture";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
        /// <summary>
        /// Cached name for the 'set_emission_energy' method.
        /// </summary>
        public static readonly StringName SetEmissionEnergy = "set_emission_energy";
        /// <summary>
        /// Cached name for the 'get_emission_energy' method.
        /// </summary>
        public static readonly StringName GetEmissionEnergy = "get_emission_energy";
        /// <summary>
        /// Cached name for the 'set_albedo_mix' method.
        /// </summary>
        public static readonly StringName SetAlbedoMix = "set_albedo_mix";
        /// <summary>
        /// Cached name for the 'get_albedo_mix' method.
        /// </summary>
        public static readonly StringName GetAlbedoMix = "get_albedo_mix";
        /// <summary>
        /// Cached name for the 'set_modulate' method.
        /// </summary>
        public static readonly StringName SetModulate = "set_modulate";
        /// <summary>
        /// Cached name for the 'get_modulate' method.
        /// </summary>
        public static readonly StringName GetModulate = "get_modulate";
        /// <summary>
        /// Cached name for the 'set_upper_fade' method.
        /// </summary>
        public static readonly StringName SetUpperFade = "set_upper_fade";
        /// <summary>
        /// Cached name for the 'get_upper_fade' method.
        /// </summary>
        public static readonly StringName GetUpperFade = "get_upper_fade";
        /// <summary>
        /// Cached name for the 'set_lower_fade' method.
        /// </summary>
        public static readonly StringName SetLowerFade = "set_lower_fade";
        /// <summary>
        /// Cached name for the 'get_lower_fade' method.
        /// </summary>
        public static readonly StringName GetLowerFade = "get_lower_fade";
        /// <summary>
        /// Cached name for the 'set_normal_fade' method.
        /// </summary>
        public static readonly StringName SetNormalFade = "set_normal_fade";
        /// <summary>
        /// Cached name for the 'get_normal_fade' method.
        /// </summary>
        public static readonly StringName GetNormalFade = "get_normal_fade";
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
        /// Cached name for the 'set_distance_fade_length' method.
        /// </summary>
        public static readonly StringName SetDistanceFadeLength = "set_distance_fade_length";
        /// <summary>
        /// Cached name for the 'get_distance_fade_length' method.
        /// </summary>
        public static readonly StringName GetDistanceFadeLength = "get_distance_fade_length";
        /// <summary>
        /// Cached name for the 'set_cull_mask' method.
        /// </summary>
        public static readonly StringName SetCullMask = "set_cull_mask";
        /// <summary>
        /// Cached name for the 'get_cull_mask' method.
        /// </summary>
        public static readonly StringName GetCullMask = "get_cull_mask";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
    }
}
