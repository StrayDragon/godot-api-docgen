namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.Sky"/> class uses a <see cref="Godot.Material"/> to render a 3D environment's background and the light it emits by updating the reflection/radiance cubemaps.</para>
/// </summary>
public partial class Sky : Resource
{
    public enum RadianceSizeEnum : long
    {
        /// <summary>
        /// <para>Radiance texture size is 32×32 pixels.</para>
        /// </summary>
        Size32 = 0,
        /// <summary>
        /// <para>Radiance texture size is 64×64 pixels.</para>
        /// </summary>
        Size64 = 1,
        /// <summary>
        /// <para>Radiance texture size is 128×128 pixels.</para>
        /// </summary>
        Size128 = 2,
        /// <summary>
        /// <para>Radiance texture size is 256×256 pixels.</para>
        /// </summary>
        Size256 = 3,
        /// <summary>
        /// <para>Radiance texture size is 512×512 pixels.</para>
        /// </summary>
        Size512 = 4,
        /// <summary>
        /// <para>Radiance texture size is 1024×1024 pixels.</para>
        /// </summary>
        Size1024 = 5,
        /// <summary>
        /// <para>Radiance texture size is 2048×2048 pixels.</para>
        /// </summary>
        Size2048 = 6,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Sky.RadianceSizeEnum"/> enum.</para>
        /// </summary>
        Max = 7
    }

    public enum ProcessModeEnum : long
    {
        /// <summary>
        /// <para>Automatically selects the appropriate process mode based on your sky shader. If your shader uses <c>TIME</c> or <c>POSITION</c>, this will use <see cref="Godot.Sky.ProcessModeEnum.Realtime"/>. If your shader uses any of the <c>LIGHT_*</c> variables or any custom uniforms, this uses <see cref="Godot.Sky.ProcessModeEnum.Incremental"/>. Otherwise, this defaults to <see cref="Godot.Sky.ProcessModeEnum.Quality"/>.</para>
        /// </summary>
        Automatic = 0,
        /// <summary>
        /// <para>Uses high quality importance sampling to process the radiance map. In general, this results in much higher quality than <see cref="Godot.Sky.ProcessModeEnum.Realtime"/> but takes much longer to generate. This should not be used if you plan on changing the sky at runtime. If you are finding that the reflection is not blurry enough and is showing sparkles or fireflies, try increasing <c>ProjectSettings.rendering/reflections/sky_reflections/ggx_samples</c>.</para>
        /// </summary>
        Quality = 1,
        /// <summary>
        /// <para>Uses the same high quality importance sampling to process the radiance map as <see cref="Godot.Sky.ProcessModeEnum.Quality"/>, but updates over several frames. The number of frames is determined by <c>ProjectSettings.rendering/reflections/sky_reflections/roughness_layers</c>. Use this when you need highest quality radiance maps, but have a sky that updates slowly.</para>
        /// </summary>
        Incremental = 2,
        /// <summary>
        /// <para>Uses the fast filtering algorithm to process the radiance map. In general this results in lower quality, but substantially faster run times. If you need better quality, but still need to update the sky every frame, consider turning on <c>ProjectSettings.rendering/reflections/sky_reflections/fast_filter_high_quality</c>.</para>
        /// <para><b>Note:</b> The fast filtering algorithm is limited to 256×256 cubemaps, so <see cref="Godot.Sky.RadianceSize"/> must be set to <see cref="Godot.Sky.RadianceSizeEnum.Size256"/>. Otherwise, a warning is printed and the overridden radiance size is ignored.</para>
        /// </summary>
        Realtime = 3
    }

    /// <summary>
    /// <para><see cref="Godot.Material"/> used to draw the background. Can be <see cref="Godot.PanoramaSkyMaterial"/>, <see cref="Godot.ProceduralSkyMaterial"/>, <see cref="Godot.PhysicalSkyMaterial"/>, or even a <see cref="Godot.ShaderMaterial"/> if you want to use your own custom shader.</para>
    /// </summary>
    public Material SkyMaterial
    {
        get
        {
            return GetMaterial();
        }
        set
        {
            SetMaterial(value);
        }
    }

    /// <summary>
    /// <para>The method for generating the radiance map from the sky. The radiance map is a cubemap with increasingly blurry versions of the sky corresponding to different levels of roughness. Radiance maps can be expensive to calculate.</para>
    /// </summary>
    public Sky.ProcessModeEnum ProcessMode
    {
        get
        {
            return GetProcessMode();
        }
        set
        {
            SetProcessMode(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Sky"/>'s radiance map size. The higher the radiance map size, the more detailed the lighting from the <see cref="Godot.Sky"/> will be.</para>
    /// <para><b>Note:</b> Some hardware will have trouble with higher radiance sizes, especially <see cref="Godot.Sky.RadianceSizeEnum.Size512"/> and above. Only use such high values on high-end hardware.</para>
    /// </summary>
    public Sky.RadianceSizeEnum RadianceSize
    {
        get
        {
            return GetRadianceSize();
        }
        set
        {
            SetRadianceSize(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Sky);

    private static readonly StringName NativeName = "Sky";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Sky() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Sky(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Sky(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadianceSize, 1512957179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadianceSize(Sky.RadianceSizeEnum size)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadianceSize, 2708733976ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Sky.RadianceSizeEnum GetRadianceSize()
    {
        return (Sky.RadianceSizeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessMode, 875986769ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProcessMode(Sky.ProcessModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessMode, 731245043ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Sky.ProcessModeEnum GetProcessMode()
    {
        return (Sky.ProcessModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaterial, 2757459619ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaterial(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaterial, 5934680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Material GetMaterial()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'sky_material' property.
        /// </summary>
        public static readonly StringName SkyMaterial = "sky_material";
        /// <summary>
        /// Cached name for the 'process_mode' property.
        /// </summary>
        public static readonly StringName ProcessMode = "process_mode";
        /// <summary>
        /// Cached name for the 'radiance_size' property.
        /// </summary>
        public static readonly StringName RadianceSize = "radiance_size";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_radiance_size' method.
        /// </summary>
        public static readonly StringName SetRadianceSize = "set_radiance_size";
        /// <summary>
        /// Cached name for the 'get_radiance_size' method.
        /// </summary>
        public static readonly StringName GetRadianceSize = "get_radiance_size";
        /// <summary>
        /// Cached name for the 'set_process_mode' method.
        /// </summary>
        public static readonly StringName SetProcessMode = "set_process_mode";
        /// <summary>
        /// Cached name for the 'get_process_mode' method.
        /// </summary>
        public static readonly StringName GetProcessMode = "get_process_mode";
        /// <summary>
        /// Cached name for the 'set_material' method.
        /// </summary>
        public static readonly StringName SetMaterial = "set_material";
        /// <summary>
        /// Cached name for the 'get_material' method.
        /// </summary>
        public static readonly StringName GetMaterial = "get_material";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
