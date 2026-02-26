namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This resource defines a custom rendering effect that can be applied to <see cref="Godot.Viewport"/>s through the viewports' <see cref="Godot.Environment"/>. You can implement a callback that is called during rendering at a given stage of the rendering pipeline and allows you to insert additional passes. Note that this callback happens on the rendering thread. CompositorEffect is an abstract base class and must be extended to implement specific rendering logic.</para>
/// </summary>
public partial class CompositorEffect : Resource
{
    public enum EffectCallbackTypeEnum : long
    {
        /// <summary>
        /// <para>The callback is called before our opaque rendering pass, but after depth prepass (if applicable).</para>
        /// </summary>
        PreOpaque = 0,
        /// <summary>
        /// <para>The callback is called after our opaque rendering pass, but before our sky is rendered.</para>
        /// </summary>
        PostOpaque = 1,
        /// <summary>
        /// <para>The callback is called after our sky is rendered, but before our back buffers are created (and if enabled, before subsurface scattering and/or screen space reflections).</para>
        /// </summary>
        PostSky = 2,
        /// <summary>
        /// <para>The callback is called before our transparent rendering pass, but after our sky is rendered and we've created our back buffers.</para>
        /// </summary>
        PreTransparent = 3,
        /// <summary>
        /// <para>The callback is called after our transparent rendering pass, but before any built-in post-processing effects and output to our render target.</para>
        /// </summary>
        PostTransparent = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.CompositorEffect.EffectCallbackTypeEnum"/> enum.</para>
        /// </summary>
        Max = 5
    }

    /// <summary>
    /// <para>If <see langword="true"/> this rendering effect is applied to any viewport it is added to.</para>
    /// </summary>
    public bool Enabled
    {
        get
        {
            return GetEnabled();
        }
        set
        {
            SetEnabled(value);
        }
    }

    /// <summary>
    /// <para>The type of effect that is implemented, determines at what stage of rendering the callback is called.</para>
    /// </summary>
    public CompositorEffect.EffectCallbackTypeEnum EffectCallbackType
    {
        get
        {
            return GetEffectCallbackType();
        }
        set
        {
            SetEffectCallbackType(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> and MSAA is enabled, this will trigger a color buffer resolve before the effect is run.</para>
    /// <para><b>Note:</b> In <see cref="Godot.CompositorEffect._RenderCallback(int, RenderData)"/>, to access the resolved buffer use:</para>
    /// <para><code>
    /// var render_scene_buffers = render_data.get_render_scene_buffers()
    /// var color_buffer = render_scene_buffers.get_texture("render_buffers", "color")
    /// </code></para>
    /// </summary>
    public bool AccessResolvedColor
    {
        get
        {
            return GetAccessResolvedColor();
        }
        set
        {
            SetAccessResolvedColor(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> and MSAA is enabled, this will trigger a depth buffer resolve before the effect is run.</para>
    /// <para><b>Note:</b> In <see cref="Godot.CompositorEffect._RenderCallback(int, RenderData)"/>, to access the resolved buffer use:</para>
    /// <para><code>
    /// var render_scene_buffers = render_data.get_render_scene_buffers()
    /// var depth_buffer = render_scene_buffers.get_texture("render_buffers", "depth")
    /// </code></para>
    /// </summary>
    public bool AccessResolvedDepth
    {
        get
        {
            return GetAccessResolvedDepth();
        }
        set
        {
            SetAccessResolvedDepth(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> this triggers motion vectors being calculated during the opaque render state.</para>
    /// <para><b>Note:</b> In <see cref="Godot.CompositorEffect._RenderCallback(int, RenderData)"/>, to access the motion vector buffer use:</para>
    /// <para><code>
    /// var render_scene_buffers = render_data.get_render_scene_buffers()
    /// var motion_buffer = render_scene_buffers.get_velocity_texture()
    /// </code></para>
    /// </summary>
    public bool NeedsMotionVectors
    {
        get
        {
            return GetNeedsMotionVectors();
        }
        set
        {
            SetNeedsMotionVectors(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> this triggers normal and roughness data to be output during our depth pre-pass, only applicable for the Forward+ renderer.</para>
    /// <para><b>Note:</b> In <see cref="Godot.CompositorEffect._RenderCallback(int, RenderData)"/>, to access the roughness buffer use:</para>
    /// <para><code>
    /// var render_scene_buffers = render_data.get_render_scene_buffers()
    /// var roughness_buffer = render_scene_buffers.get_texture("forward_clustered", "normal_roughness")
    /// </code></para>
    /// <para>The raw normal and roughness buffer is stored in an optimized format, different than the one available in Spatial shaders. When sampling the buffer, a conversion function must be applied. Use this function, copied from <a href="https://github.com/godotengine/godot/blob/da5f39889f155658cef7f7ec3cc1abb94e17d815/servers/rendering/renderer_rd/shaders/forward_clustered/scene_forward_clustered_inc.glsl#L334-L341">here</a>:</para>
    /// <para><code>
    /// vec4 normal_roughness_compatibility(vec4 p_normal_roughness) {
    /// 	float roughness = p_normal_roughness.w;
    /// 	if (roughness &gt; 0.5) {
    /// 		roughness = 1.0 - roughness;
    /// 	}
    /// 	roughness /= (127.0 / 255.0);
    /// 	return vec4(normalize(p_normal_roughness.xyz * 2.0 - 1.0) * 0.5 + 0.5, roughness);
    /// }
    /// </code></para>
    /// </summary>
    public bool NeedsNormalRoughness
    {
        get
        {
            return GetNeedsNormalRoughness();
        }
        set
        {
            SetNeedsNormalRoughness(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> this triggers specular data being rendered to a separate buffer and combined after effects have been applied, only applicable for the Forward+ renderer.</para>
    /// </summary>
    public bool NeedsSeparateSpecular
    {
        get
        {
            return GetNeedsSeparateSpecular();
        }
        set
        {
            SetNeedsSeparateSpecular(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CompositorEffect);

    private static readonly StringName NativeName = "CompositorEffect";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CompositorEffect() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CompositorEffect(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CompositorEffect(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Implement this function with your custom rendering code. <paramref name="effectCallbackType"/> should always match the effect callback type you've specified in <see cref="Godot.CompositorEffect.EffectCallbackType"/>. <paramref name="renderData"/> provides access to the rendering state, it is only valid during rendering and should not be stored.</para>
    /// </summary>
    public virtual void _RenderCallback(int effectCallbackType, RenderData renderData)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEffectCallbackType, 1390728419ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEffectCallbackType(CompositorEffect.EffectCallbackTypeEnum effectCallbackType)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)effectCallbackType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEffectCallbackType, 1221912590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CompositorEffect.EffectCallbackTypeEnum GetEffectCallbackType()
    {
        return (CompositorEffect.EffectCallbackTypeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessResolvedColor, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessResolvedColor(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessResolvedColor, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAccessResolvedColor()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessResolvedDepth, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessResolvedDepth(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessResolvedDepth, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAccessResolvedDepth()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNeedsMotionVectors, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNeedsMotionVectors(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNeedsMotionVectors, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetNeedsMotionVectors()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNeedsNormalRoughness, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNeedsNormalRoughness(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNeedsNormalRoughness, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetNeedsNormalRoughness()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNeedsSeparateSpecular, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNeedsSeparateSpecular(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNeedsSeparateSpecular, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetNeedsSeparateSpecular()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__render_callback = "_RenderCallback";

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
        if ((method == MethodProxyName__render_callback || method == MethodName._RenderCallback) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__render_callback.NativeValue))
        {
            _RenderCallback(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<RenderData>(args[1]));
            ret = default;
            return true;
        }
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
        if (method == MethodName._RenderCallback)
        {
            if (HasGodotClassMethod(MethodProxyName__render_callback.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the 'enabled' property.
        /// </summary>
        public static readonly StringName Enabled = "enabled";
        /// <summary>
        /// Cached name for the 'effect_callback_type' property.
        /// </summary>
        public static readonly StringName EffectCallbackType = "effect_callback_type";
        /// <summary>
        /// Cached name for the 'access_resolved_color' property.
        /// </summary>
        public static readonly StringName AccessResolvedColor = "access_resolved_color";
        /// <summary>
        /// Cached name for the 'access_resolved_depth' property.
        /// </summary>
        public static readonly StringName AccessResolvedDepth = "access_resolved_depth";
        /// <summary>
        /// Cached name for the 'needs_motion_vectors' property.
        /// </summary>
        public static readonly StringName NeedsMotionVectors = "needs_motion_vectors";
        /// <summary>
        /// Cached name for the 'needs_normal_roughness' property.
        /// </summary>
        public static readonly StringName NeedsNormalRoughness = "needs_normal_roughness";
        /// <summary>
        /// Cached name for the 'needs_separate_specular' property.
        /// </summary>
        public static readonly StringName NeedsSeparateSpecular = "needs_separate_specular";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_render_callback' method.
        /// </summary>
        public static readonly StringName _RenderCallback = "_render_callback";
        /// <summary>
        /// Cached name for the 'set_enabled' method.
        /// </summary>
        public static readonly StringName SetEnabled = "set_enabled";
        /// <summary>
        /// Cached name for the 'get_enabled' method.
        /// </summary>
        public static readonly StringName GetEnabled = "get_enabled";
        /// <summary>
        /// Cached name for the 'set_effect_callback_type' method.
        /// </summary>
        public static readonly StringName SetEffectCallbackType = "set_effect_callback_type";
        /// <summary>
        /// Cached name for the 'get_effect_callback_type' method.
        /// </summary>
        public static readonly StringName GetEffectCallbackType = "get_effect_callback_type";
        /// <summary>
        /// Cached name for the 'set_access_resolved_color' method.
        /// </summary>
        public static readonly StringName SetAccessResolvedColor = "set_access_resolved_color";
        /// <summary>
        /// Cached name for the 'get_access_resolved_color' method.
        /// </summary>
        public static readonly StringName GetAccessResolvedColor = "get_access_resolved_color";
        /// <summary>
        /// Cached name for the 'set_access_resolved_depth' method.
        /// </summary>
        public static readonly StringName SetAccessResolvedDepth = "set_access_resolved_depth";
        /// <summary>
        /// Cached name for the 'get_access_resolved_depth' method.
        /// </summary>
        public static readonly StringName GetAccessResolvedDepth = "get_access_resolved_depth";
        /// <summary>
        /// Cached name for the 'set_needs_motion_vectors' method.
        /// </summary>
        public static readonly StringName SetNeedsMotionVectors = "set_needs_motion_vectors";
        /// <summary>
        /// Cached name for the 'get_needs_motion_vectors' method.
        /// </summary>
        public static readonly StringName GetNeedsMotionVectors = "get_needs_motion_vectors";
        /// <summary>
        /// Cached name for the 'set_needs_normal_roughness' method.
        /// </summary>
        public static readonly StringName SetNeedsNormalRoughness = "set_needs_normal_roughness";
        /// <summary>
        /// Cached name for the 'get_needs_normal_roughness' method.
        /// </summary>
        public static readonly StringName GetNeedsNormalRoughness = "get_needs_normal_roughness";
        /// <summary>
        /// Cached name for the 'set_needs_separate_specular' method.
        /// </summary>
        public static readonly StringName SetNeedsSeparateSpecular = "set_needs_separate_specular";
        /// <summary>
        /// Cached name for the 'get_needs_separate_specular' method.
        /// </summary>
        public static readonly StringName GetNeedsSeparateSpecular = "get_needs_separate_specular";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
