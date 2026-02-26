namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A <see cref="Godot.Material"/> resource that can be used by <see cref="Godot.FogVolume"/>s to draw volumetric effects.</para>
/// <para>If you need more advanced effects, use a custom <a href="$DOCS_URL/tutorials/shaders/shader_reference/fog_shader.html">fog shader</a>.</para>
/// </summary>
public partial class FogMaterial : Material
{
    /// <summary>
    /// <para>The density of the <see cref="Godot.FogVolume"/>. Denser objects are more opaque, but may suffer from under-sampling artifacts that look like stripes. Negative values can be used to subtract fog from other <see cref="Godot.FogVolume"/>s or global volumetric fog.</para>
    /// <para><b>Note:</b> Due to limited precision, <see cref="Godot.FogMaterial.Density"/> values between <c>-0.001</c> and <c>0.001</c> (exclusive) act like <c>0.0</c>. This does not apply to <see cref="Godot.Environment.VolumetricFogDensity"/>.</para>
    /// </summary>
    public float Density
    {
        get
        {
            return GetDensity();
        }
        set
        {
            SetDensity(value);
        }
    }

    /// <summary>
    /// <para>The single-scattering <see cref="Godot.Color"/> of the <see cref="Godot.FogVolume"/>. Internally, <see cref="Godot.FogMaterial.Albedo"/> is converted into single-scattering, which is additively blended with other <see cref="Godot.FogVolume"/>s and the <see cref="Godot.Environment.VolumetricFogAlbedo"/>.</para>
    /// </summary>
    public Color Albedo
    {
        get
        {
            return GetAlbedo();
        }
        set
        {
            SetAlbedo(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Color"/> of the light emitted by the <see cref="Godot.FogVolume"/>. Emitted light will not cast light or shadows on other objects, but can be useful for modulating the <see cref="Godot.Color"/> of the <see cref="Godot.FogVolume"/> independently from light sources.</para>
    /// </summary>
    public Color Emission
    {
        get
        {
            return GetEmission();
        }
        set
        {
            SetEmission(value);
        }
    }

    /// <summary>
    /// <para>The rate by which the height-based fog decreases in density as height increases in world space. A high falloff will result in a sharp transition, while a low falloff will result in a smoother transition. A value of <c>0.0</c> results in uniform-density fog. The height threshold is determined by the height of the associated <see cref="Godot.FogVolume"/>.</para>
    /// </summary>
    public float HeightFalloff
    {
        get
        {
            return GetHeightFalloff();
        }
        set
        {
            SetHeightFalloff(value);
        }
    }

    /// <summary>
    /// <para>The hardness of the edges of the <see cref="Godot.FogVolume"/>. A higher value will result in softer edges, while a lower value will result in harder edges.</para>
    /// </summary>
    public float EdgeFade
    {
        get
        {
            return GetEdgeFade();
        }
        set
        {
            SetEdgeFade(value);
        }
    }

    /// <summary>
    /// <para>The 3D texture that is used to scale the <see cref="Godot.FogMaterial.Density"/> of the <see cref="Godot.FogVolume"/>. This can be used to vary fog density within the <see cref="Godot.FogVolume"/> with any kind of static pattern. For animated effects, consider using a custom <a href="$DOCS_URL/tutorials/shaders/shader_reference/fog_shader.html">fog shader</a>.</para>
    /// </summary>
    public Texture3D DensityTexture
    {
        get
        {
            return GetDensityTexture();
        }
        set
        {
            SetDensityTexture(value);
        }
    }

    private static readonly System.Type CachedType = typeof(FogMaterial);

    private static readonly StringName NativeName = "FogMaterial";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public FogMaterial() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal FogMaterial(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal FogMaterial(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDensity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDensity(float density)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), density);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDensity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDensity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlbedo, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAlbedo(Color albedo)
    {
        NativeCalls.godot_icall_1_213(MethodBind2, GodotObject.GetPtr(this), &albedo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlbedo, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetAlbedo()
    {
        return NativeCalls.godot_icall_0_214(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmission, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetEmission(Color emission)
    {
        NativeCalls.godot_icall_1_213(MethodBind4, GodotObject.GetPtr(this), &emission);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmission, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetEmission()
    {
        return NativeCalls.godot_icall_0_214(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeightFalloff, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHeightFalloff(float heightFalloff)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), heightFalloff);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeightFalloff, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetHeightFalloff()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEdgeFade, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEdgeFade(float edgeFade)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), edgeFade);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEdgeFade, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEdgeFade()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDensityTexture, 1188404210ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDensityTexture(Texture3D densityTexture)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(densityTexture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDensityTexture, 373985333ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture3D GetDensityTexture()
    {
        return (Texture3D)NativeCalls.godot_icall_0_63(MethodBind11, GodotObject.GetPtr(this));
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
        /// Cached name for the 'density' property.
        /// </summary>
        public static readonly StringName Density = "density";
        /// <summary>
        /// Cached name for the 'albedo' property.
        /// </summary>
        public static readonly StringName Albedo = "albedo";
        /// <summary>
        /// Cached name for the 'emission' property.
        /// </summary>
        public static readonly StringName Emission = "emission";
        /// <summary>
        /// Cached name for the 'height_falloff' property.
        /// </summary>
        public static readonly StringName HeightFalloff = "height_falloff";
        /// <summary>
        /// Cached name for the 'edge_fade' property.
        /// </summary>
        public static readonly StringName EdgeFade = "edge_fade";
        /// <summary>
        /// Cached name for the 'density_texture' property.
        /// </summary>
        public static readonly StringName DensityTexture = "density_texture";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Material.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_density' method.
        /// </summary>
        public static readonly StringName SetDensity = "set_density";
        /// <summary>
        /// Cached name for the 'get_density' method.
        /// </summary>
        public static readonly StringName GetDensity = "get_density";
        /// <summary>
        /// Cached name for the 'set_albedo' method.
        /// </summary>
        public static readonly StringName SetAlbedo = "set_albedo";
        /// <summary>
        /// Cached name for the 'get_albedo' method.
        /// </summary>
        public static readonly StringName GetAlbedo = "get_albedo";
        /// <summary>
        /// Cached name for the 'set_emission' method.
        /// </summary>
        public static readonly StringName SetEmission = "set_emission";
        /// <summary>
        /// Cached name for the 'get_emission' method.
        /// </summary>
        public static readonly StringName GetEmission = "get_emission";
        /// <summary>
        /// Cached name for the 'set_height_falloff' method.
        /// </summary>
        public static readonly StringName SetHeightFalloff = "set_height_falloff";
        /// <summary>
        /// Cached name for the 'get_height_falloff' method.
        /// </summary>
        public static readonly StringName GetHeightFalloff = "get_height_falloff";
        /// <summary>
        /// Cached name for the 'set_edge_fade' method.
        /// </summary>
        public static readonly StringName SetEdgeFade = "set_edge_fade";
        /// <summary>
        /// Cached name for the 'get_edge_fade' method.
        /// </summary>
        public static readonly StringName GetEdgeFade = "get_edge_fade";
        /// <summary>
        /// Cached name for the 'set_density_texture' method.
        /// </summary>
        public static readonly StringName SetDensityTexture = "set_density_texture";
        /// <summary>
        /// Cached name for the 'get_density_texture' method.
        /// </summary>
        public static readonly StringName GetDensityTexture = "get_density_texture";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Material.SignalName
    {
    }
}
