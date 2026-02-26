namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An Omnidirectional light is a type of <see cref="Godot.Light3D"/> that emits light in all directions. The light is attenuated by distance and this attenuation can be configured by changing its energy, radius, and attenuation parameters.</para>
/// <para><b>Note:</b> When using the Mobile rendering method, only 8 omni lights can be displayed on each mesh resource. Attempting to display more than 8 omni lights on a single mesh resource will result in omni lights flickering in and out as the camera moves. When using the Compatibility rendering method, only 8 omni lights can be displayed on each mesh resource by default, but this can be increased by adjusting <c>ProjectSettings.rendering/limits/opengl/max_lights_per_object</c>.</para>
/// <para><b>Note:</b> When using the Mobile or Compatibility rendering methods, omni lights will only correctly affect meshes whose visibility AABB intersects with the light's AABB. If using a shader to deform the mesh in a way that makes it go outside its AABB, <see cref="Godot.GeometryInstance3D.ExtraCullMargin"/> must be increased on the mesh. Otherwise, the light may not be visible on the mesh.</para>
/// </summary>
public partial class OmniLight3D : Light3D
{
    public enum ShadowMode : long
    {
        /// <summary>
        /// <para>Shadows are rendered to a dual-paraboloid texture. Faster than <see cref="Godot.OmniLight3D.ShadowMode.Cube"/>, but lower-quality.</para>
        /// </summary>
        DualParaboloid = 0,
        /// <summary>
        /// <para>Shadows are rendered to a cubemap. Slower than <see cref="Godot.OmniLight3D.ShadowMode.DualParaboloid"/>, but higher-quality.</para>
        /// </summary>
        Cube = 1
    }

    /// <summary>
    /// <para>The light's radius. Note that the effectively lit area may appear to be smaller depending on the <see cref="Godot.OmniLight3D.OmniAttenuation"/> in use. No matter the <see cref="Godot.OmniLight3D.OmniAttenuation"/> in use, the light will never reach anything outside this radius.</para>
    /// <para><b>Note:</b> <see cref="Godot.OmniLight3D.OmniRange"/> is not affected by <see cref="Godot.Node3D.Scale"/> (the light's scale or its parent's scale).</para>
    /// </summary>
    public float OmniRange
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
    /// <para>Controls the distance attenuation function for omnilights.</para>
    /// <para>A value of <c>0.0</c> will maintain a constant brightness through most of the range, but smoothly attenuate the light at the edge of the range. Use a value of <c>2.0</c> for physically accurate lights as it results in the proper inverse square attenutation.</para>
    /// <para><b>Note:</b> Setting attenuation to <c>2.0</c> or higher may result in distant objects receiving minimal light, even within range. For example, with a range of <c>4096</c>, an object at <c>100</c> units is attenuated by a factor of <c>0.0001</c>. With a default brightness of <c>1</c>, the light would not be visible at that distance.</para>
    /// <para><b>Note:</b> Using negative or values higher than <c>10.0</c> may lead to unexpected results.</para>
    /// </summary>
    public float OmniAttenuation
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

    public OmniLight3D.ShadowMode OmniShadowMode
    {
        get
        {
            return GetShadowMode();
        }
        set
        {
            SetShadowMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OmniLight3D);

    private static readonly StringName NativeName = "OmniLight3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OmniLight3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OmniLight3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OmniLight3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowMode, 121862228ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowMode(OmniLight3D.ShadowMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowMode, 4181586331ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OmniLight3D.ShadowMode GetShadowMode()
    {
        return (OmniLight3D.ShadowMode)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : Light3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'omni_range' property.
        /// </summary>
        public static readonly StringName OmniRange = "omni_range";
        /// <summary>
        /// Cached name for the 'omni_attenuation' property.
        /// </summary>
        public static readonly StringName OmniAttenuation = "omni_attenuation";
        /// <summary>
        /// Cached name for the 'omni_shadow_mode' property.
        /// </summary>
        public static readonly StringName OmniShadowMode = "omni_shadow_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Light3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_shadow_mode' method.
        /// </summary>
        public static readonly StringName SetShadowMode = "set_shadow_mode";
        /// <summary>
        /// Cached name for the 'get_shadow_mode' method.
        /// </summary>
        public static readonly StringName GetShadowMode = "get_shadow_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Light3D.SignalName
    {
    }
}
