namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A resource referenced in a <see cref="Godot.Sky"/> that is used to draw a background. <see cref="Godot.PanoramaSkyMaterial"/> functions similar to skyboxes in other engines, except it uses an equirectangular sky map instead of a <see cref="Godot.Cubemap"/>.</para>
/// <para>Using an HDR panorama is strongly recommended for accurate, high-quality reflections. Godot supports the Radiance HDR (<c>.hdr</c>) and OpenEXR (<c>.exr</c>) image formats for this purpose.</para>
/// <para>You can use <a href="https://danilw.github.io/GLSL-howto/cubemap_to_panorama_js/cubemap_to_panorama.html">this tool</a> to convert a cubemap to an equirectangular sky map.</para>
/// </summary>
public partial class PanoramaSkyMaterial : Material
{
    /// <summary>
    /// <para><see cref="Godot.Texture2D"/> to be applied to the <see cref="Godot.PanoramaSkyMaterial"/>.</para>
    /// </summary>
    public Texture2D Panorama
    {
        get
        {
            return GetPanorama();
        }
        set
        {
            SetPanorama(value);
        }
    }

    /// <summary>
    /// <para>A boolean value to determine if the background texture should be filtered or not.</para>
    /// </summary>
    public bool Filter
    {
        get
        {
            return IsFilteringEnabled();
        }
        set
        {
            SetFilteringEnabled(value);
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

    private static readonly System.Type CachedType = typeof(PanoramaSkyMaterial);

    private static readonly StringName NativeName = "PanoramaSkyMaterial";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PanoramaSkyMaterial() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PanoramaSkyMaterial(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PanoramaSkyMaterial(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPanorama, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPanorama(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPanorama, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetPanorama()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFilteringEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFilteringEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFilteringEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFilteringEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnergyMultiplier, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnergyMultiplier(float multiplier)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), multiplier);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnergyMultiplier, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEnergyMultiplier()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'panorama' property.
        /// </summary>
        public static readonly StringName Panorama = "panorama";
        /// <summary>
        /// Cached name for the 'filter' property.
        /// </summary>
        public static readonly StringName Filter = "filter";
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
        /// Cached name for the 'set_panorama' method.
        /// </summary>
        public static readonly StringName SetPanorama = "set_panorama";
        /// <summary>
        /// Cached name for the 'get_panorama' method.
        /// </summary>
        public static readonly StringName GetPanorama = "get_panorama";
        /// <summary>
        /// Cached name for the 'set_filtering_enabled' method.
        /// </summary>
        public static readonly StringName SetFilteringEnabled = "set_filtering_enabled";
        /// <summary>
        /// Cached name for the 'is_filtering_enabled' method.
        /// </summary>
        public static readonly StringName IsFilteringEnabled = "is_filtering_enabled";
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
