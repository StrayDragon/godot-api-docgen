namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A directional light is a type of <see cref="Godot.Light3D"/> node that models an infinite number of parallel rays covering the entire scene. It is used for lights with strong intensity that are located far away from the scene to model sunlight or moonlight.</para>
/// <para>Light is emitted in the -Z direction of the node's global basis. For an unrotated light, this means that the light is emitted forwards, illuminating the front side of a 3D model (see <c>Vector3.FORWARD</c> and <c>Vector3.MODEL_FRONT</c>). The position of the node is ignored; only the basis is used to determine light direction.</para>
/// </summary>
public partial class DirectionalLight3D : Light3D
{
    public enum ShadowMode : long
    {
        /// <summary>
        /// <para>Renders the entire scene's shadow map from an orthogonal point of view. This is the fastest directional shadow mode. May result in blurrier shadows on close objects.</para>
        /// </summary>
        Orthogonal = 0,
        /// <summary>
        /// <para>Splits the view frustum in 2 areas, each with its own shadow map. This shadow mode is a compromise between <see cref="Godot.DirectionalLight3D.ShadowMode.Orthogonal"/> and <see cref="Godot.DirectionalLight3D.ShadowMode.Parallel4Splits"/> in terms of performance.</para>
        /// </summary>
        Parallel2Splits = 1,
        /// <summary>
        /// <para>Splits the view frustum in 4 areas, each with its own shadow map. This is the slowest directional shadow mode.</para>
        /// </summary>
        Parallel4Splits = 2
    }

    public enum SkyModeEnum : long
    {
        /// <summary>
        /// <para>Makes the light visible in both scene lighting and sky rendering.</para>
        /// </summary>
        LightAndSky = 0,
        /// <summary>
        /// <para>Makes the light visible in scene lighting only (including direct lighting and global illumination). When using this mode, the light will not be visible from sky shaders.</para>
        /// </summary>
        LightOnly = 1,
        /// <summary>
        /// <para>Makes the light visible to sky shaders only. When using this mode the light will not cast light into the scene (either through direct lighting or through global illumination), but can be accessed through sky shaders. This can be useful, for example, when you want to control sky effects without illuminating the scene (during a night cycle, for example).</para>
        /// </summary>
        SkyOnly = 2
    }

    /// <summary>
    /// <para>The light's shadow rendering algorithm.</para>
    /// </summary>
    public DirectionalLight3D.ShadowMode DirectionalShadowMode
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

    /// <summary>
    /// <para>The distance from camera to shadow split 1. Relative to <see cref="Godot.DirectionalLight3D.DirectionalShadowMaxDistance"/>. Only used when <see cref="Godot.DirectionalLight3D.DirectionalShadowMode"/> is <see cref="Godot.DirectionalLight3D.ShadowMode.Parallel2Splits"/> or <see cref="Godot.DirectionalLight3D.ShadowMode.Parallel4Splits"/>.</para>
    /// </summary>
    public float DirectionalShadowSplit1
    {
        get
        {
            return GetParam((Light3D.Param)(10));
        }
        set
        {
            SetParam((Light3D.Param)(10), value);
        }
    }

    /// <summary>
    /// <para>The distance from shadow split 1 to split 2. Relative to <see cref="Godot.DirectionalLight3D.DirectionalShadowMaxDistance"/>. Only used when <see cref="Godot.DirectionalLight3D.DirectionalShadowMode"/> is <see cref="Godot.DirectionalLight3D.ShadowMode.Parallel4Splits"/>.</para>
    /// </summary>
    public float DirectionalShadowSplit2
    {
        get
        {
            return GetParam((Light3D.Param)(11));
        }
        set
        {
            SetParam((Light3D.Param)(11), value);
        }
    }

    /// <summary>
    /// <para>The distance from shadow split 2 to split 3. Relative to <see cref="Godot.DirectionalLight3D.DirectionalShadowMaxDistance"/>. Only used when <see cref="Godot.DirectionalLight3D.DirectionalShadowMode"/> is <see cref="Godot.DirectionalLight3D.ShadowMode.Parallel4Splits"/>.</para>
    /// </summary>
    public float DirectionalShadowSplit3
    {
        get
        {
            return GetParam((Light3D.Param)(12));
        }
        set
        {
            SetParam((Light3D.Param)(12), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, shadow detail is sacrificed in exchange for smoother transitions between splits. Enabling shadow blend splitting also has a moderate performance cost. This is ignored when <see cref="Godot.DirectionalLight3D.DirectionalShadowMode"/> is <see cref="Godot.DirectionalLight3D.ShadowMode.Orthogonal"/>.</para>
    /// </summary>
    public bool DirectionalShadowBlendSplits
    {
        get
        {
            return IsBlendSplitsEnabled();
        }
        set
        {
            SetBlendSplits(value);
        }
    }

    /// <summary>
    /// <para>Proportion of <see cref="Godot.DirectionalLight3D.DirectionalShadowMaxDistance"/> at which point the shadow starts to fade. At <see cref="Godot.DirectionalLight3D.DirectionalShadowMaxDistance"/>, the shadow will disappear. The default value is a balance between smooth fading and distant shadow visibility. If the camera moves fast and the <see cref="Godot.DirectionalLight3D.DirectionalShadowMaxDistance"/> is low, consider lowering <see cref="Godot.DirectionalLight3D.DirectionalShadowFadeStart"/> below <c>0.8</c> to make shadow transitions less noticeable. On the other hand, if you tuned <see cref="Godot.DirectionalLight3D.DirectionalShadowMaxDistance"/> to cover the entire scene, you can set <see cref="Godot.DirectionalLight3D.DirectionalShadowFadeStart"/> to <c>1.0</c> to prevent the shadow from fading in the distance (it will suddenly cut off instead).</para>
    /// </summary>
    public float DirectionalShadowFadeStart
    {
        get
        {
            return GetParam((Light3D.Param)(13));
        }
        set
        {
            SetParam((Light3D.Param)(13), value);
        }
    }

    /// <summary>
    /// <para>The maximum distance for shadow splits. Increasing this value will make directional shadows visible from further away, at the cost of lower overall shadow detail and performance (since more objects need to be included in the directional shadow rendering).</para>
    /// </summary>
    public float DirectionalShadowMaxDistance
    {
        get
        {
            return GetParam((Light3D.Param)(9));
        }
        set
        {
            SetParam((Light3D.Param)(9), value);
        }
    }

    /// <summary>
    /// <para>Sets the size of the directional shadow pancake. The pancake offsets the start of the shadow's camera frustum to provide a higher effective depth resolution for the shadow. However, a high pancake size can cause artifacts in the shadows of large objects that are close to the edge of the frustum. Reducing the pancake size can help. Setting the size to <c>0</c> turns off the pancaking effect.</para>
    /// </summary>
    public float DirectionalShadowPancakeSize
    {
        get
        {
            return GetParam((Light3D.Param)(16));
        }
        set
        {
            SetParam((Light3D.Param)(16), value);
        }
    }

    /// <summary>
    /// <para>Whether this <see cref="Godot.DirectionalLight3D"/> is visible in the sky, in the scene, or both in the sky and in the scene.</para>
    /// </summary>
    public DirectionalLight3D.SkyModeEnum SkyMode
    {
        get
        {
            return GetSkyMode();
        }
        set
        {
            SetSkyMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(DirectionalLight3D);

    private static readonly StringName NativeName = "DirectionalLight3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public DirectionalLight3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal DirectionalLight3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal DirectionalLight3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowMode, 1261211726ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowMode(DirectionalLight3D.ShadowMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowMode, 2765228544ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public DirectionalLight3D.ShadowMode GetShadowMode()
    {
        return (DirectionalLight3D.ShadowMode)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendSplits, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlendSplits(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBlendSplitsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsBlendSplitsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkyMode, 2691194817ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkyMode(DirectionalLight3D.SkyModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkyMode, 3819982774ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public DirectionalLight3D.SkyModeEnum GetSkyMode()
    {
        return (DirectionalLight3D.SkyModeEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'directional_shadow_mode' property.
        /// </summary>
        public static readonly StringName DirectionalShadowMode = "directional_shadow_mode";
        /// <summary>
        /// Cached name for the 'directional_shadow_split_1' property.
        /// </summary>
        public static readonly StringName DirectionalShadowSplit1 = "directional_shadow_split_1";
        /// <summary>
        /// Cached name for the 'directional_shadow_split_2' property.
        /// </summary>
        public static readonly StringName DirectionalShadowSplit2 = "directional_shadow_split_2";
        /// <summary>
        /// Cached name for the 'directional_shadow_split_3' property.
        /// </summary>
        public static readonly StringName DirectionalShadowSplit3 = "directional_shadow_split_3";
        /// <summary>
        /// Cached name for the 'directional_shadow_blend_splits' property.
        /// </summary>
        public static readonly StringName DirectionalShadowBlendSplits = "directional_shadow_blend_splits";
        /// <summary>
        /// Cached name for the 'directional_shadow_fade_start' property.
        /// </summary>
        public static readonly StringName DirectionalShadowFadeStart = "directional_shadow_fade_start";
        /// <summary>
        /// Cached name for the 'directional_shadow_max_distance' property.
        /// </summary>
        public static readonly StringName DirectionalShadowMaxDistance = "directional_shadow_max_distance";
        /// <summary>
        /// Cached name for the 'directional_shadow_pancake_size' property.
        /// </summary>
        public static readonly StringName DirectionalShadowPancakeSize = "directional_shadow_pancake_size";
        /// <summary>
        /// Cached name for the 'sky_mode' property.
        /// </summary>
        public static readonly StringName SkyMode = "sky_mode";
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
        /// <summary>
        /// Cached name for the 'set_blend_splits' method.
        /// </summary>
        public static readonly StringName SetBlendSplits = "set_blend_splits";
        /// <summary>
        /// Cached name for the 'is_blend_splits_enabled' method.
        /// </summary>
        public static readonly StringName IsBlendSplitsEnabled = "is_blend_splits_enabled";
        /// <summary>
        /// Cached name for the 'set_sky_mode' method.
        /// </summary>
        public static readonly StringName SetSkyMode = "set_sky_mode";
        /// <summary>
        /// Cached name for the 'get_sky_mode' method.
        /// </summary>
        public static readonly StringName GetSkyMode = "get_sky_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Light3D.SignalName
    {
    }
}
