namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Represents a light as defined by the <c>KHR_lights_punctual</c> glTF extension.</para>
/// </summary>
[GodotClassName("GLTFLight")]
public partial class GltfLight : Resource
{
    /// <summary>
    /// <para>The <see cref="Godot.Color"/> of the light in linear space. Defaults to white. A black color causes the light to have no effect.</para>
    /// <para>This value is linear to match glTF, but will be converted to nonlinear sRGB when creating a Godot <see cref="Godot.Light3D"/> node upon import, or converted to linear when exporting a Godot <see cref="Godot.Light3D"/> to glTF.</para>
    /// </summary>
    public Color Color
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
    /// <para>The intensity of the light. This is expressed in candelas (lumens per steradian) for point and spot lights, and lux (lumens per m²) for directional lights. When creating a Godot light, this value is converted to a unitless multiplier.</para>
    /// </summary>
    public float Intensity
    {
        get
        {
            return GetIntensity();
        }
        set
        {
            SetIntensity(value);
        }
    }

    /// <summary>
    /// <para>The type of the light. The values accepted by Godot are "point", "spot", and "directional", which correspond to Godot's <see cref="Godot.OmniLight3D"/>, <see cref="Godot.SpotLight3D"/>, and <see cref="Godot.DirectionalLight3D"/> respectively.</para>
    /// </summary>
    public string LightType
    {
        get
        {
            return GetLightType();
        }
        set
        {
            SetLightType(value);
        }
    }

    /// <summary>
    /// <para>The range of the light, beyond which the light has no effect. glTF lights with no range defined behave like physical lights (which have infinite range). When creating a Godot light, the range is clamped to <c>4096.0</c>.</para>
    /// </summary>
    public float Range
    {
        get
        {
            return GetRange();
        }
        set
        {
            SetRange(value);
        }
    }

    /// <summary>
    /// <para>The inner angle of the cone in a spotlight. Must be less than or equal to the outer cone angle.</para>
    /// <para>Within this angle, the light is at full brightness. Between the inner and outer cone angles, there is a transition from full brightness to zero brightness. When creating a Godot <see cref="Godot.SpotLight3D"/>, the ratio between the inner and outer cone angles is used to calculate the attenuation of the light.</para>
    /// </summary>
    public float InnerConeAngle
    {
        get
        {
            return GetInnerConeAngle();
        }
        set
        {
            SetInnerConeAngle(value);
        }
    }

    /// <summary>
    /// <para>The outer angle of the cone in a spotlight. Must be greater than or equal to the inner angle.</para>
    /// <para>At this angle, the light drops off to zero brightness. Between the inner and outer cone angles, there is a transition from full brightness to zero brightness. If this angle is a half turn, then the spotlight emits in all directions. When creating a Godot <see cref="Godot.SpotLight3D"/>, the outer cone angle is used as the angle of the spotlight.</para>
    /// </summary>
    public float OuterConeAngle
    {
        get
        {
            return GetOuterConeAngle();
        }
        set
        {
            SetOuterConeAngle(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfLight);

    private static readonly StringName NativeName = "GLTFLight";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfLight() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfLight(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfLight(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromNode, 3907677874ul);

    /// <summary>
    /// <para>Create a new GLTFLight instance from the given Godot <see cref="Godot.Light3D"/> node.</para>
    /// </summary>
    public static GltfLight FromNode(Light3D lightNode)
    {
        return (GltfLight)NativeCalls.godot_icall_1_637(MethodBind0, GodotObject.GetPtr(lightNode));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToNode, 2040811672ul);

    /// <summary>
    /// <para>Converts this GLTFLight instance into a Godot <see cref="Godot.Light3D"/> node.</para>
    /// </summary>
    public Light3D ToNode()
    {
        return (Light3D)NativeCalls.godot_icall_0_53(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromDictionary, 4057087208ul);

    /// <summary>
    /// <para>Creates a new GLTFLight instance by parsing the given <see cref="Godot.Collections.Dictionary"/>.</para>
    /// </summary>
    public static GltfLight FromDictionary(Godot.Collections.Dictionary dictionary)
    {
        return (GltfLight)NativeCalls.godot_icall_1_633(MethodBind2, (godot_dictionary)(dictionary ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToDictionary, 3102165223ul);

    /// <summary>
    /// <para>Serializes this GLTFLight instance into a <see cref="Godot.Collections.Dictionary"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary ToDictionary()
    {
        return NativeCalls.godot_icall_0_122(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColor, 3200896285ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind5, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIntensity, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetIntensity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIntensity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIntensity(float intensity)
    {
        NativeCalls.godot_icall_1_67(MethodBind7, GodotObject.GetPtr(this), intensity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLightType, 2841200299ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLightType()
    {
        return NativeCalls.godot_icall_0_58(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLightType, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLightType(string lightType)
    {
        NativeCalls.godot_icall_1_57(MethodBind9, GodotObject.GetPtr(this), lightType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRange, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRange()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRange, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRange(float range)
    {
        NativeCalls.godot_icall_1_67(MethodBind11, GodotObject.GetPtr(this), range);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInnerConeAngle, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetInnerConeAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInnerConeAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInnerConeAngle(float innerConeAngle)
    {
        NativeCalls.godot_icall_1_67(MethodBind13, GodotObject.GetPtr(this), innerConeAngle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOuterConeAngle, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetOuterConeAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOuterConeAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOuterConeAngle(float outerConeAngle)
    {
        NativeCalls.godot_icall_1_67(MethodBind15, GodotObject.GetPtr(this), outerConeAngle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdditionalData, 2138907829ul);

    public Variant GetAdditionalData(StringName extensionName)
    {
        return NativeCalls.godot_icall_1_143(MethodBind16, GodotObject.GetPtr(this), (godot_string_name)(extensionName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdditionalData, 3776071444ul);

    public void SetAdditionalData(StringName extensionName, Variant additionalData)
    {
        NativeCalls.godot_icall_2_142(MethodBind17, GodotObject.GetPtr(this), (godot_string_name)(extensionName?.NativeValue ?? default), additionalData);
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
        /// Cached name for the 'color' property.
        /// </summary>
        public static readonly StringName Color = "color";
        /// <summary>
        /// Cached name for the 'intensity' property.
        /// </summary>
        public static readonly StringName Intensity = "intensity";
        /// <summary>
        /// Cached name for the 'light_type' property.
        /// </summary>
        public static readonly StringName LightType = "light_type";
        /// <summary>
        /// Cached name for the 'range' property.
        /// </summary>
        public static readonly StringName Range = "range";
        /// <summary>
        /// Cached name for the 'inner_cone_angle' property.
        /// </summary>
        public static readonly StringName InnerConeAngle = "inner_cone_angle";
        /// <summary>
        /// Cached name for the 'outer_cone_angle' property.
        /// </summary>
        public static readonly StringName OuterConeAngle = "outer_cone_angle";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'from_node' method.
        /// </summary>
        public static readonly StringName FromNode = "from_node";
        /// <summary>
        /// Cached name for the 'to_node' method.
        /// </summary>
        public static readonly StringName ToNode = "to_node";
        /// <summary>
        /// Cached name for the 'from_dictionary' method.
        /// </summary>
        public static readonly StringName FromDictionary = "from_dictionary";
        /// <summary>
        /// Cached name for the 'to_dictionary' method.
        /// </summary>
        public static readonly StringName ToDictionary = "to_dictionary";
        /// <summary>
        /// Cached name for the 'get_color' method.
        /// </summary>
        public static readonly StringName GetColor = "get_color";
        /// <summary>
        /// Cached name for the 'set_color' method.
        /// </summary>
        public static readonly StringName SetColor = "set_color";
        /// <summary>
        /// Cached name for the 'get_intensity' method.
        /// </summary>
        public static readonly StringName GetIntensity = "get_intensity";
        /// <summary>
        /// Cached name for the 'set_intensity' method.
        /// </summary>
        public static readonly StringName SetIntensity = "set_intensity";
        /// <summary>
        /// Cached name for the 'get_light_type' method.
        /// </summary>
        public static readonly StringName GetLightType = "get_light_type";
        /// <summary>
        /// Cached name for the 'set_light_type' method.
        /// </summary>
        public static readonly StringName SetLightType = "set_light_type";
        /// <summary>
        /// Cached name for the 'get_range' method.
        /// </summary>
        public static readonly StringName GetRange = "get_range";
        /// <summary>
        /// Cached name for the 'set_range' method.
        /// </summary>
        public static readonly StringName SetRange = "set_range";
        /// <summary>
        /// Cached name for the 'get_inner_cone_angle' method.
        /// </summary>
        public static readonly StringName GetInnerConeAngle = "get_inner_cone_angle";
        /// <summary>
        /// Cached name for the 'set_inner_cone_angle' method.
        /// </summary>
        public static readonly StringName SetInnerConeAngle = "set_inner_cone_angle";
        /// <summary>
        /// Cached name for the 'get_outer_cone_angle' method.
        /// </summary>
        public static readonly StringName GetOuterConeAngle = "get_outer_cone_angle";
        /// <summary>
        /// Cached name for the 'set_outer_cone_angle' method.
        /// </summary>
        public static readonly StringName SetOuterConeAngle = "set_outer_cone_angle";
        /// <summary>
        /// Cached name for the 'get_additional_data' method.
        /// </summary>
        public static readonly StringName GetAdditionalData = "get_additional_data";
        /// <summary>
        /// Cached name for the 'set_additional_data' method.
        /// </summary>
        public static readonly StringName SetAdditionalData = "set_additional_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
