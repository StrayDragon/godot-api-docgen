namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A Spotlight is a type of <see cref="Godot.Light3D"/> node that emits lights in a specific direction, in the shape of a cone. The light is attenuated through the distance. This attenuation can be configured by changing the energy, radius and attenuation parameters of <see cref="Godot.Light3D"/>.</para>
/// <para>Light is emitted in the -Z direction of the node's global basis. For an unrotated light, this means that the light is emitted forwards, illuminating the front side of a 3D model (see <c>Vector3.FORWARD</c> and <c>Vector3.MODEL_FRONT</c>).</para>
/// <para><b>Note:</b> When using the Mobile rendering method, only 8 spot lights can be displayed on each mesh resource. Attempting to display more than 8 spot lights on a single mesh resource will result in spot lights flickering in and out as the camera moves. When using the Compatibility rendering method, only 8 spot lights can be displayed on each mesh resource by default, but this can be increased by adjusting <c>ProjectSettings.rendering/limits/opengl/max_lights_per_object</c>.</para>
/// <para><b>Note:</b> When using the Mobile or Compatibility rendering methods, spot lights will only correctly affect meshes whose visibility AABB intersects with the light's AABB. If using a shader to deform the mesh in a way that makes it go outside its AABB, <see cref="Godot.GeometryInstance3D.ExtraCullMargin"/> must be increased on the mesh. Otherwise, the light may not be visible on the mesh.</para>
/// </summary>
public partial class SpotLight3D : Light3D
{
    /// <summary>
    /// <para>The maximal range that can be reached by the spotlight. Note that the effectively lit area may appear to be smaller depending on the <see cref="Godot.SpotLight3D.SpotAttenuation"/> in use. No matter the <see cref="Godot.SpotLight3D.SpotAttenuation"/> in use, the light will never reach anything outside this range.</para>
    /// <para><b>Note:</b> <see cref="Godot.SpotLight3D.SpotRange"/> is not affected by <see cref="Godot.Node3D.Scale"/> (the light's scale or its parent's scale).</para>
    /// </summary>
    public float SpotRange
    {
        get
        {
            return GetParam((Light3D.Param)(4));
        }
        set
        {
            SetParam((Light3D.Param)(4), value);
        }
    }

    /// <summary>
    /// <para>Controls the distance attenuation function for spotlights.</para>
    /// <para>A value of <c>0.0</c> will maintain a constant brightness through most of the range, but smoothly attenuate the light at the edge of the range. Use a value of <c>2.0</c> for physically accurate lights as it results in the proper inverse square attenutation.</para>
    /// <para><b>Note:</b> Setting attenuation to <c>2.0</c> or higher may result in distant objects receiving minimal light, even within range. For example, with a range of <c>4096</c>, an object at <c>100</c> units is attenuated by a factor of <c>0.0001</c>. With a default brightness of <c>1</c>, the light would not be visible at that distance.</para>
    /// <para><b>Note:</b> Using negative or values higher than <c>10.0</c> may lead to unexpected results.</para>
    /// </summary>
    public float SpotAttenuation
    {
        get
        {
            return GetParam((Light3D.Param)(6));
        }
        set
        {
            SetParam((Light3D.Param)(6), value);
        }
    }

    /// <summary>
    /// <para>The spotlight's angle in degrees. This is the angular radius, meaning the angle from the -Z axis, the cone's center, to the edge of the cone. The default angular radius of 45 degrees corresponds to a cone with an angular diameter of 90 degrees.</para>
    /// <para><b>Note:</b> <see cref="Godot.SpotLight3D.SpotAngle"/> is not affected by <see cref="Godot.Node3D.Scale"/> (the light's scale or its parent's scale).</para>
    /// </summary>
    public float SpotAngle
    {
        get
        {
            return GetParam((Light3D.Param)(7));
        }
        set
        {
            SetParam((Light3D.Param)(7), value);
        }
    }

    /// <summary>
    /// <para>The spotlight's <i>angular</i> attenuation curve. See also <see cref="Godot.SpotLight3D.SpotAttenuation"/>.</para>
    /// </summary>
    public float SpotAngleAttenuation
    {
        get
        {
            return GetParam((Light3D.Param)(8));
        }
        set
        {
            SetParam((Light3D.Param)(8), value);
        }
    }

    private static readonly System.Type CachedType = typeof(SpotLight3D);

    private static readonly StringName NativeName = "SpotLight3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SpotLight3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SpotLight3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SpotLight3D(bool memoryOwn) : base(memoryOwn) { }

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
    public new class PropertyName : Light3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'spot_range' property.
        /// </summary>
        public static readonly StringName SpotRange = "spot_range";
        /// <summary>
        /// Cached name for the 'spot_attenuation' property.
        /// </summary>
        public static readonly StringName SpotAttenuation = "spot_attenuation";
        /// <summary>
        /// Cached name for the 'spot_angle' property.
        /// </summary>
        public static readonly StringName SpotAngle = "spot_angle";
        /// <summary>
        /// Cached name for the 'spot_angle_attenuation' property.
        /// </summary>
        public static readonly StringName SpotAngleAttenuation = "spot_angle_attenuation";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Light3D.MethodName
    {
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Light3D.SignalName
    {
    }
}
