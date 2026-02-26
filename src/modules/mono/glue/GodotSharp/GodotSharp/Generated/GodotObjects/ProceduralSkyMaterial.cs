namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.ProceduralSkyMaterial"/> provides a way to create an effective background quickly by defining procedural parameters for the sun, the sky and the ground. The sky and ground are defined by a main color, a color at the horizon, and an easing curve to interpolate between them. Suns are described by a position in the sky, a color, and a max angle from the sun at which the easing curve ends. The max angle therefore defines the size of the sun in the sky.</para>
/// <para><see cref="Godot.ProceduralSkyMaterial"/> supports up to 4 suns, using the color, and energy, direction, and angular distance of the first four <see cref="Godot.DirectionalLight3D"/> nodes in the scene. This means that the suns are defined individually by the properties of their corresponding <see cref="Godot.DirectionalLight3D"/>s and globally by <see cref="Godot.ProceduralSkyMaterial.SunAngleMax"/> and <see cref="Godot.ProceduralSkyMaterial.SunCurve"/>.</para>
/// <para><see cref="Godot.ProceduralSkyMaterial"/> uses a lightweight shader to draw the sky and is therefore suited for real-time updates. This makes it a great option for a sky that is simple and computationally cheap, but unrealistic. If you need a more realistic procedural option, use <see cref="Godot.PhysicalSkyMaterial"/>.</para>
/// </summary>
public partial class ProceduralSkyMaterial : Material
{
    /// <summary>
    /// <para>Color of the sky at the top. Blends with <see cref="Godot.ProceduralSkyMaterial.SkyHorizonColor"/>.</para>
    /// </summary>
    public Color SkyTopColor
    {
        get
        {
            return GetSkyTopColor();
        }
        set
        {
            SetSkyTopColor(value);
        }
    }

    /// <summary>
    /// <para>Color of the sky at the horizon. Blends with <see cref="Godot.ProceduralSkyMaterial.SkyTopColor"/>.</para>
    /// </summary>
    public Color SkyHorizonColor
    {
        get
        {
            return GetSkyHorizonColor();
        }
        set
        {
            SetSkyHorizonColor(value);
        }
    }

    /// <summary>
    /// <para>How quickly the <see cref="Godot.ProceduralSkyMaterial.SkyHorizonColor"/> fades into the <see cref="Godot.ProceduralSkyMaterial.SkyTopColor"/>.</para>
    /// </summary>
    public float SkyCurve
    {
        get
        {
            return GetSkyCurve();
        }
        set
        {
            SetSkyCurve(value);
        }
    }

    /// <summary>
    /// <para>Multiplier for sky color. A higher value will make the sky brighter.</para>
    /// </summary>
    public float SkyEnergyMultiplier
    {
        get
        {
            return GetSkyEnergyMultiplier();
        }
        set
        {
            SetSkyEnergyMultiplier(value);
        }
    }

    /// <summary>
    /// <para>The sky cover texture to use. This texture must use an equirectangular projection (similar to <see cref="Godot.PanoramaSkyMaterial"/>). The texture's colors will be <i>added</i> to the existing sky color, and will be multiplied by <see cref="Godot.ProceduralSkyMaterial.SkyEnergyMultiplier"/> and <see cref="Godot.ProceduralSkyMaterial.SkyCoverModulate"/>. This is mainly suited to displaying stars at night, but it can also be used to display clouds at day or night (with a non-physically-accurate look).</para>
    /// </summary>
    public Texture2D SkyCover
    {
        get
        {
            return GetSkyCover();
        }
        set
        {
            SetSkyCover(value);
        }
    }

    /// <summary>
    /// <para>The tint to apply to the <see cref="Godot.ProceduralSkyMaterial.SkyCover"/> texture. This can be used to change the sky cover's colors or opacity independently of the sky energy, which is useful for day/night or weather transitions. Only effective if a texture is defined in <see cref="Godot.ProceduralSkyMaterial.SkyCover"/>.</para>
    /// </summary>
    public Color SkyCoverModulate
    {
        get
        {
            return GetSkyCoverModulate();
        }
        set
        {
            SetSkyCoverModulate(value);
        }
    }

    /// <summary>
    /// <para>Color of the ground at the bottom. Blends with <see cref="Godot.ProceduralSkyMaterial.GroundHorizonColor"/>.</para>
    /// </summary>
    public Color GroundBottomColor
    {
        get
        {
            return GetGroundBottomColor();
        }
        set
        {
            SetGroundBottomColor(value);
        }
    }

    /// <summary>
    /// <para>Color of the ground at the horizon. Blends with <see cref="Godot.ProceduralSkyMaterial.GroundBottomColor"/>.</para>
    /// </summary>
    public Color GroundHorizonColor
    {
        get
        {
            return GetGroundHorizonColor();
        }
        set
        {
            SetGroundHorizonColor(value);
        }
    }

    /// <summary>
    /// <para>How quickly the <see cref="Godot.ProceduralSkyMaterial.GroundHorizonColor"/> fades into the <see cref="Godot.ProceduralSkyMaterial.GroundBottomColor"/>.</para>
    /// </summary>
    public float GroundCurve
    {
        get
        {
            return GetGroundCurve();
        }
        set
        {
            SetGroundCurve(value);
        }
    }

    /// <summary>
    /// <para>Multiplier for ground color. A higher value will make the ground brighter.</para>
    /// </summary>
    public float GroundEnergyMultiplier
    {
        get
        {
            return GetGroundEnergyMultiplier();
        }
        set
        {
            SetGroundEnergyMultiplier(value);
        }
    }

    /// <summary>
    /// <para>Distance from center of sun where it fades out completely.</para>
    /// </summary>
    public float SunAngleMax
    {
        get
        {
            return GetSunAngleMax();
        }
        set
        {
            SetSunAngleMax(value);
        }
    }

    /// <summary>
    /// <para>How quickly the sun fades away between the edge of the sun disk and <see cref="Godot.ProceduralSkyMaterial.SunAngleMax"/>.</para>
    /// </summary>
    public float SunCurve
    {
        get
        {
            return GetSunCurve();
        }
        set
        {
            SetSunCurve(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables debanding. Debanding adds a small amount of noise which helps reduce banding that appears from the smooth changes in color in the sky.</para>
    /// </summary>
    public bool UseDebanding
    {
        get
        {
            return GetUseDebanding();
        }
        set
        {
            SetUseDebanding(value);
        }
    }

    /// <summary>
    /// <para>The sky's overall brightness multiplier. Higher values result in a brighter sky.</para>
    /// </summary>
    public float EnergyMultiplier
    {
        get
        {
            return GetEnergyMultiplier();
        }
        set
        {
            SetEnergyMultiplier(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ProceduralSkyMaterial);

    private static readonly StringName NativeName = "ProceduralSkyMaterial";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ProceduralSkyMaterial() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ProceduralSkyMaterial(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ProceduralSkyMaterial(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkyTopColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSkyTopColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind0, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkyTopColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetSkyTopColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkyHorizonColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSkyHorizonColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind2, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkyHorizonColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetSkyHorizonColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkyCurve, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkyCurve(float curve)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), curve);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkyCurve, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSkyCurve()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkyEnergyMultiplier, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkyEnergyMultiplier(float multiplier)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), multiplier);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkyEnergyMultiplier, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSkyEnergyMultiplier()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkyCover, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkyCover(Texture2D skyCover)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(skyCover));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkyCover, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetSkyCover()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkyCoverModulate, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSkyCoverModulate(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind10, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkyCoverModulate, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetSkyCoverModulate()
    {
        return NativeCalls.godot_icall_0_214(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGroundBottomColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGroundBottomColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind12, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroundBottomColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetGroundBottomColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGroundHorizonColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGroundHorizonColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind14, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroundHorizonColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetGroundHorizonColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGroundCurve, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGroundCurve(float curve)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), curve);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroundCurve, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGroundCurve()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGroundEnergyMultiplier, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGroundEnergyMultiplier(float energy)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroundEnergyMultiplier, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGroundEnergyMultiplier()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSunAngleMax, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSunAngleMax(float degrees)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSunAngleMax, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSunAngleMax()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSunCurve, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSunCurve(float curve)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), curve);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSunCurve, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSunCurve()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseDebanding, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseDebanding(bool useDebanding)
    {
        NativeCalls.godot_icall_1_14(MethodBind24, GodotObject.GetPtr(this), useDebanding.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseDebanding, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseDebanding()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnergyMultiplier, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnergyMultiplier(float multiplier)
    {
        NativeCalls.godot_icall_1_67(MethodBind26, GodotObject.GetPtr(this), multiplier);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnergyMultiplier, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEnergyMultiplier()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
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
    public new class PropertyName : Material.PropertyName
    {
        /// <summary>
        /// Cached name for the 'sky_top_color' property.
        /// </summary>
        public static readonly StringName SkyTopColor = "sky_top_color";
        /// <summary>
        /// Cached name for the 'sky_horizon_color' property.
        /// </summary>
        public static readonly StringName SkyHorizonColor = "sky_horizon_color";
        /// <summary>
        /// Cached name for the 'sky_curve' property.
        /// </summary>
        public static readonly StringName SkyCurve = "sky_curve";
        /// <summary>
        /// Cached name for the 'sky_energy_multiplier' property.
        /// </summary>
        public static readonly StringName SkyEnergyMultiplier = "sky_energy_multiplier";
        /// <summary>
        /// Cached name for the 'sky_cover' property.
        /// </summary>
        public static readonly StringName SkyCover = "sky_cover";
        /// <summary>
        /// Cached name for the 'sky_cover_modulate' property.
        /// </summary>
        public static readonly StringName SkyCoverModulate = "sky_cover_modulate";
        /// <summary>
        /// Cached name for the 'ground_bottom_color' property.
        /// </summary>
        public static readonly StringName GroundBottomColor = "ground_bottom_color";
        /// <summary>
        /// Cached name for the 'ground_horizon_color' property.
        /// </summary>
        public static readonly StringName GroundHorizonColor = "ground_horizon_color";
        /// <summary>
        /// Cached name for the 'ground_curve' property.
        /// </summary>
        public static readonly StringName GroundCurve = "ground_curve";
        /// <summary>
        /// Cached name for the 'ground_energy_multiplier' property.
        /// </summary>
        public static readonly StringName GroundEnergyMultiplier = "ground_energy_multiplier";
        /// <summary>
        /// Cached name for the 'sun_angle_max' property.
        /// </summary>
        public static readonly StringName SunAngleMax = "sun_angle_max";
        /// <summary>
        /// Cached name for the 'sun_curve' property.
        /// </summary>
        public static readonly StringName SunCurve = "sun_curve";
        /// <summary>
        /// Cached name for the 'use_debanding' property.
        /// </summary>
        public static readonly StringName UseDebanding = "use_debanding";
        /// <summary>
        /// Cached name for the 'energy_multiplier' property.
        /// </summary>
        public static readonly StringName EnergyMultiplier = "energy_multiplier";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Material.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_sky_top_color' method.
        /// </summary>
        public static readonly StringName SetSkyTopColor = "set_sky_top_color";
        /// <summary>
        /// Cached name for the 'get_sky_top_color' method.
        /// </summary>
        public static readonly StringName GetSkyTopColor = "get_sky_top_color";
        /// <summary>
        /// Cached name for the 'set_sky_horizon_color' method.
        /// </summary>
        public static readonly StringName SetSkyHorizonColor = "set_sky_horizon_color";
        /// <summary>
        /// Cached name for the 'get_sky_horizon_color' method.
        /// </summary>
        public static readonly StringName GetSkyHorizonColor = "get_sky_horizon_color";
        /// <summary>
        /// Cached name for the 'set_sky_curve' method.
        /// </summary>
        public static readonly StringName SetSkyCurve = "set_sky_curve";
        /// <summary>
        /// Cached name for the 'get_sky_curve' method.
        /// </summary>
        public static readonly StringName GetSkyCurve = "get_sky_curve";
        /// <summary>
        /// Cached name for the 'set_sky_energy_multiplier' method.
        /// </summary>
        public static readonly StringName SetSkyEnergyMultiplier = "set_sky_energy_multiplier";
        /// <summary>
        /// Cached name for the 'get_sky_energy_multiplier' method.
        /// </summary>
        public static readonly StringName GetSkyEnergyMultiplier = "get_sky_energy_multiplier";
        /// <summary>
        /// Cached name for the 'set_sky_cover' method.
        /// </summary>
        public static readonly StringName SetSkyCover = "set_sky_cover";
        /// <summary>
        /// Cached name for the 'get_sky_cover' method.
        /// </summary>
        public static readonly StringName GetSkyCover = "get_sky_cover";
        /// <summary>
        /// Cached name for the 'set_sky_cover_modulate' method.
        /// </summary>
        public static readonly StringName SetSkyCoverModulate = "set_sky_cover_modulate";
        /// <summary>
        /// Cached name for the 'get_sky_cover_modulate' method.
        /// </summary>
        public static readonly StringName GetSkyCoverModulate = "get_sky_cover_modulate";
        /// <summary>
        /// Cached name for the 'set_ground_bottom_color' method.
        /// </summary>
        public static readonly StringName SetGroundBottomColor = "set_ground_bottom_color";
        /// <summary>
        /// Cached name for the 'get_ground_bottom_color' method.
        /// </summary>
        public static readonly StringName GetGroundBottomColor = "get_ground_bottom_color";
        /// <summary>
        /// Cached name for the 'set_ground_horizon_color' method.
        /// </summary>
        public static readonly StringName SetGroundHorizonColor = "set_ground_horizon_color";
        /// <summary>
        /// Cached name for the 'get_ground_horizon_color' method.
        /// </summary>
        public static readonly StringName GetGroundHorizonColor = "get_ground_horizon_color";
        /// <summary>
        /// Cached name for the 'set_ground_curve' method.
        /// </summary>
        public static readonly StringName SetGroundCurve = "set_ground_curve";
        /// <summary>
        /// Cached name for the 'get_ground_curve' method.
        /// </summary>
        public static readonly StringName GetGroundCurve = "get_ground_curve";
        /// <summary>
        /// Cached name for the 'set_ground_energy_multiplier' method.
        /// </summary>
        public static readonly StringName SetGroundEnergyMultiplier = "set_ground_energy_multiplier";
        /// <summary>
        /// Cached name for the 'get_ground_energy_multiplier' method.
        /// </summary>
        public static readonly StringName GetGroundEnergyMultiplier = "get_ground_energy_multiplier";
        /// <summary>
        /// Cached name for the 'set_sun_angle_max' method.
        /// </summary>
        public static readonly StringName SetSunAngleMax = "set_sun_angle_max";
        /// <summary>
        /// Cached name for the 'get_sun_angle_max' method.
        /// </summary>
        public static readonly StringName GetSunAngleMax = "get_sun_angle_max";
        /// <summary>
        /// Cached name for the 'set_sun_curve' method.
        /// </summary>
        public static readonly StringName SetSunCurve = "set_sun_curve";
        /// <summary>
        /// Cached name for the 'get_sun_curve' method.
        /// </summary>
        public static readonly StringName GetSunCurve = "get_sun_curve";
        /// <summary>
        /// Cached name for the 'set_use_debanding' method.
        /// </summary>
        public static readonly StringName SetUseDebanding = "set_use_debanding";
        /// <summary>
        /// Cached name for the 'get_use_debanding' method.
        /// </summary>
        public static readonly StringName GetUseDebanding = "get_use_debanding";
        /// <summary>
        /// Cached name for the 'set_energy_multiplier' method.
        /// </summary>
        public static readonly StringName SetEnergyMultiplier = "set_energy_multiplier";
        /// <summary>
        /// Cached name for the 'get_energy_multiplier' method.
        /// </summary>
        public static readonly StringName GetEnergyMultiplier = "get_energy_multiplier";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Material.SignalName
    {
    }
}
