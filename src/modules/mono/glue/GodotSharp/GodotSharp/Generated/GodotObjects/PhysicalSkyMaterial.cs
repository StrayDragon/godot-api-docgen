namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.PhysicalSkyMaterial"/> uses the Preetham analytic daylight model to draw a sky based on physical properties. This results in a substantially more realistic sky than the <see cref="Godot.ProceduralSkyMaterial"/>, but it is slightly slower and less flexible.</para>
/// <para>The <see cref="Godot.PhysicalSkyMaterial"/> only supports one sun. The color, energy, and direction of the sun are taken from the first <see cref="Godot.DirectionalLight3D"/> in the scene tree.</para>
/// </summary>
public partial class PhysicalSkyMaterial : Material
{
    /// <summary>
    /// <para>Controls the strength of the <a href="https://en.wikipedia.org/wiki/Rayleigh_scattering">Rayleigh scattering</a>. Rayleigh scattering results from light colliding with small particles. It is responsible for the blue color of the sky.</para>
    /// </summary>
    public float RayleighCoefficient
    {
        get
        {
            return GetRayleighCoefficient();
        }
        set
        {
            SetRayleighCoefficient(value);
        }
    }

    /// <summary>
    /// <para>Controls the <see cref="Godot.Color"/> of the <a href="https://en.wikipedia.org/wiki/Rayleigh_scattering">Rayleigh scattering</a>. While not physically accurate, this allows for the creation of alien-looking planets. For example, setting this to a red <see cref="Godot.Color"/> results in a Mars-looking atmosphere with a corresponding blue sunset.</para>
    /// </summary>
    public Color RayleighColor
    {
        get
        {
            return GetRayleighColor();
        }
        set
        {
            SetRayleighColor(value);
        }
    }

    /// <summary>
    /// <para>Controls the strength of <a href="https://en.wikipedia.org/wiki/Mie_scattering">Mie scattering</a> for the sky. Mie scattering results from light colliding with larger particles (like water). On earth, Mie scattering results in a whitish color around the sun and horizon.</para>
    /// </summary>
    public float MieCoefficient
    {
        get
        {
            return GetMieCoefficient();
        }
        set
        {
            SetMieCoefficient(value);
        }
    }

    /// <summary>
    /// <para>Controls the direction of the <a href="https://en.wikipedia.org/wiki/Mie_scattering">Mie scattering</a>. A value of <c>1</c> means that when light hits a particle it's passing through straight forward. A value of <c>-1</c> means that all light is scatter backwards.</para>
    /// </summary>
    public float MieEccentricity
    {
        get
        {
            return GetMieEccentricity();
        }
        set
        {
            SetMieEccentricity(value);
        }
    }

    /// <summary>
    /// <para>Controls the <see cref="Godot.Color"/> of the <a href="https://en.wikipedia.org/wiki/Mie_scattering">Mie scattering</a> effect. While not physically accurate, this allows for the creation of alien-looking planets.</para>
    /// </summary>
    public Color MieColor
    {
        get
        {
            return GetMieColor();
        }
        set
        {
            SetMieColor(value);
        }
    }

    /// <summary>
    /// <para>Sets the thickness of the atmosphere. High turbidity creates a foggy-looking atmosphere, while a low turbidity results in a clearer atmosphere.</para>
    /// </summary>
    public float Turbidity
    {
        get
        {
            return GetTurbidity();
        }
        set
        {
            SetTurbidity(value);
        }
    }

    /// <summary>
    /// <para>Sets the size of the sun disk. Default value is based on Sol's perceived size from Earth.</para>
    /// </summary>
    public float SunDiskScale
    {
        get
        {
            return GetSunDiskScale();
        }
        set
        {
            SetSunDiskScale(value);
        }
    }

    /// <summary>
    /// <para>Modulates the <see cref="Godot.Color"/> on the bottom half of the sky to represent the ground.</para>
    /// </summary>
    public Color GroundColor
    {
        get
        {
            return GetGroundColor();
        }
        set
        {
            SetGroundColor(value);
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
    /// <para><see cref="Godot.Texture2D"/> for the night sky. This is added to the sky, so if it is bright enough, it may be visible during the day.</para>
    /// </summary>
    public Texture2D NightSky
    {
        get
        {
            return GetNightSky();
        }
        set
        {
            SetNightSky(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PhysicalSkyMaterial);

    private static readonly StringName NativeName = "PhysicalSkyMaterial";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicalSkyMaterial() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PhysicalSkyMaterial(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PhysicalSkyMaterial(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRayleighCoefficient, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRayleighCoefficient(float rayleigh)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), rayleigh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRayleighCoefficient, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRayleighCoefficient()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRayleighColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRayleighColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind2, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRayleighColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetRayleighColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMieCoefficient, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMieCoefficient(float mie)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), mie);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMieCoefficient, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMieCoefficient()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMieEccentricity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMieEccentricity(float eccentricity)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), eccentricity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMieEccentricity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMieEccentricity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMieColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMieColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind8, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMieColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetMieColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTurbidity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTurbidity(float turbidity)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), turbidity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTurbidity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTurbidity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSunDiskScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSunDiskScale(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSunDiskScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSunDiskScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGroundColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGroundColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind14, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroundColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetGroundColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnergyMultiplier, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnergyMultiplier(float multiplier)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), multiplier);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnergyMultiplier, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEnergyMultiplier()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseDebanding, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseDebanding(bool useDebanding)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), useDebanding.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseDebanding, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseDebanding()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNightSky, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNightSky(Texture2D nightSky)
    {
        NativeCalls.godot_icall_1_56(MethodBind20, GodotObject.GetPtr(this), GodotObject.GetPtr(nightSky));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNightSky, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetNightSky()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind21, GodotObject.GetPtr(this));
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
        /// Cached name for the 'rayleigh_coefficient' property.
        /// </summary>
        public static readonly StringName RayleighCoefficient = "rayleigh_coefficient";
        /// <summary>
        /// Cached name for the 'rayleigh_color' property.
        /// </summary>
        public static readonly StringName RayleighColor = "rayleigh_color";
        /// <summary>
        /// Cached name for the 'mie_coefficient' property.
        /// </summary>
        public static readonly StringName MieCoefficient = "mie_coefficient";
        /// <summary>
        /// Cached name for the 'mie_eccentricity' property.
        /// </summary>
        public static readonly StringName MieEccentricity = "mie_eccentricity";
        /// <summary>
        /// Cached name for the 'mie_color' property.
        /// </summary>
        public static readonly StringName MieColor = "mie_color";
        /// <summary>
        /// Cached name for the 'turbidity' property.
        /// </summary>
        public static readonly StringName Turbidity = "turbidity";
        /// <summary>
        /// Cached name for the 'sun_disk_scale' property.
        /// </summary>
        public static readonly StringName SunDiskScale = "sun_disk_scale";
        /// <summary>
        /// Cached name for the 'ground_color' property.
        /// </summary>
        public static readonly StringName GroundColor = "ground_color";
        /// <summary>
        /// Cached name for the 'energy_multiplier' property.
        /// </summary>
        public static readonly StringName EnergyMultiplier = "energy_multiplier";
        /// <summary>
        /// Cached name for the 'use_debanding' property.
        /// </summary>
        public static readonly StringName UseDebanding = "use_debanding";
        /// <summary>
        /// Cached name for the 'night_sky' property.
        /// </summary>
        public static readonly StringName NightSky = "night_sky";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Material.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_rayleigh_coefficient' method.
        /// </summary>
        public static readonly StringName SetRayleighCoefficient = "set_rayleigh_coefficient";
        /// <summary>
        /// Cached name for the 'get_rayleigh_coefficient' method.
        /// </summary>
        public static readonly StringName GetRayleighCoefficient = "get_rayleigh_coefficient";
        /// <summary>
        /// Cached name for the 'set_rayleigh_color' method.
        /// </summary>
        public static readonly StringName SetRayleighColor = "set_rayleigh_color";
        /// <summary>
        /// Cached name for the 'get_rayleigh_color' method.
        /// </summary>
        public static readonly StringName GetRayleighColor = "get_rayleigh_color";
        /// <summary>
        /// Cached name for the 'set_mie_coefficient' method.
        /// </summary>
        public static readonly StringName SetMieCoefficient = "set_mie_coefficient";
        /// <summary>
        /// Cached name for the 'get_mie_coefficient' method.
        /// </summary>
        public static readonly StringName GetMieCoefficient = "get_mie_coefficient";
        /// <summary>
        /// Cached name for the 'set_mie_eccentricity' method.
        /// </summary>
        public static readonly StringName SetMieEccentricity = "set_mie_eccentricity";
        /// <summary>
        /// Cached name for the 'get_mie_eccentricity' method.
        /// </summary>
        public static readonly StringName GetMieEccentricity = "get_mie_eccentricity";
        /// <summary>
        /// Cached name for the 'set_mie_color' method.
        /// </summary>
        public static readonly StringName SetMieColor = "set_mie_color";
        /// <summary>
        /// Cached name for the 'get_mie_color' method.
        /// </summary>
        public static readonly StringName GetMieColor = "get_mie_color";
        /// <summary>
        /// Cached name for the 'set_turbidity' method.
        /// </summary>
        public static readonly StringName SetTurbidity = "set_turbidity";
        /// <summary>
        /// Cached name for the 'get_turbidity' method.
        /// </summary>
        public static readonly StringName GetTurbidity = "get_turbidity";
        /// <summary>
        /// Cached name for the 'set_sun_disk_scale' method.
        /// </summary>
        public static readonly StringName SetSunDiskScale = "set_sun_disk_scale";
        /// <summary>
        /// Cached name for the 'get_sun_disk_scale' method.
        /// </summary>
        public static readonly StringName GetSunDiskScale = "get_sun_disk_scale";
        /// <summary>
        /// Cached name for the 'set_ground_color' method.
        /// </summary>
        public static readonly StringName SetGroundColor = "set_ground_color";
        /// <summary>
        /// Cached name for the 'get_ground_color' method.
        /// </summary>
        public static readonly StringName GetGroundColor = "get_ground_color";
        /// <summary>
        /// Cached name for the 'set_energy_multiplier' method.
        /// </summary>
        public static readonly StringName SetEnergyMultiplier = "set_energy_multiplier";
        /// <summary>
        /// Cached name for the 'get_energy_multiplier' method.
        /// </summary>
        public static readonly StringName GetEnergyMultiplier = "get_energy_multiplier";
        /// <summary>
        /// Cached name for the 'set_use_debanding' method.
        /// </summary>
        public static readonly StringName SetUseDebanding = "set_use_debanding";
        /// <summary>
        /// Cached name for the 'get_use_debanding' method.
        /// </summary>
        public static readonly StringName GetUseDebanding = "get_use_debanding";
        /// <summary>
        /// Cached name for the 'set_night_sky' method.
        /// </summary>
        public static readonly StringName SetNightSky = "set_night_sky";
        /// <summary>
        /// Cached name for the 'get_night_sky' method.
        /// </summary>
        public static readonly StringName GetNightSky = "get_night_sky";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Material.SignalName
    {
    }
}
