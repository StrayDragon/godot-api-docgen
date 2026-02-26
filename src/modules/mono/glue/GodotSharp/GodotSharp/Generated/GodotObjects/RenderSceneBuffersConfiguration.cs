namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This configuration object is created and populated by the render engine on a viewport change and used to (re)configure a <see cref="Godot.RenderSceneBuffers"/> object.</para>
/// </summary>
public partial class RenderSceneBuffersConfiguration : RefCounted
{
    /// <summary>
    /// <para>The render target associated with these buffer.</para>
    /// </summary>
    public Rid RenderTarget
    {
        get
        {
            return GetRenderTarget();
        }
        set
        {
            SetRenderTarget(value);
        }
    }

    /// <summary>
    /// <para>The size of the 3D render buffer used for rendering.</para>
    /// </summary>
    public Vector2I InternalSize
    {
        get
        {
            return GetInternalSize();
        }
        set
        {
            SetInternalSize(value);
        }
    }

    /// <summary>
    /// <para>The target (upscale) size if scaling is used.</para>
    /// </summary>
    public Vector2I TargetSize
    {
        get
        {
            return GetTargetSize();
        }
        set
        {
            SetTargetSize(value);
        }
    }

    /// <summary>
    /// <para>The number of views we're rendering.</para>
    /// </summary>
    public uint ViewCount
    {
        get
        {
            return GetViewCount();
        }
        set
        {
            SetViewCount(value);
        }
    }

    /// <summary>
    /// <para>The requested scaling mode with which we upscale/downscale if <see cref="Godot.RenderSceneBuffersConfiguration.InternalSize"/> and <see cref="Godot.RenderSceneBuffersConfiguration.TargetSize"/> are not equal.</para>
    /// </summary>
    public RenderingServer.ViewportScaling3DMode Scaling3DMode
    {
        get
        {
            return GetScaling3DMode();
        }
        set
        {
            SetScaling3DMode(value);
        }
    }

    /// <summary>
    /// <para>The MSAA mode we're using for 3D rendering.</para>
    /// </summary>
    public RenderingServer.ViewportMsaa Msaa3D
    {
        get
        {
            return GetMsaa3D();
        }
        set
        {
            SetMsaa3D(value);
        }
    }

    /// <summary>
    /// <para>The requested screen space AA applied in post processing.</para>
    /// </summary>
    public RenderingServer.ViewportScreenSpaceAA ScreenSpaceAA
    {
        get
        {
            return GetScreenSpaceAA();
        }
        set
        {
            SetScreenSpaceAA(value);
        }
    }

    /// <summary>
    /// <para>FSR Sharpness applicable if FSR upscaling is used.</para>
    /// </summary>
    public float FsrSharpness
    {
        get
        {
            return GetFsrSharpness();
        }
        set
        {
            SetFsrSharpness(value);
        }
    }

    /// <summary>
    /// <para>Bias applied to mipmaps.</para>
    /// </summary>
    public float TextureMipmapBias
    {
        get
        {
            return GetTextureMipmapBias();
        }
        set
        {
            SetTextureMipmapBias(value);
        }
    }

    /// <summary>
    /// <para>Level of the anisotropic filter.</para>
    /// </summary>
    public RenderingServer.ViewportAnisotropicFiltering AnisotropicFilteringLevel
    {
        get
        {
            return GetAnisotropicFilteringLevel();
        }
        set
        {
            SetAnisotropicFilteringLevel(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RenderSceneBuffersConfiguration);

    private static readonly StringName NativeName = "RenderSceneBuffersConfiguration";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RenderSceneBuffersConfiguration() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RenderSceneBuffersConfiguration(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RenderSceneBuffersConfiguration(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderTarget, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetRenderTarget()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderTarget, 2722037293ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRenderTarget(Rid renderTarget)
    {
        NativeCalls.godot_icall_1_286(MethodBind1, GodotObject.GetPtr(this), renderTarget);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInternalSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetInternalSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInternalSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetInternalSize(Vector2I internalSize)
    {
        NativeCalls.godot_icall_1_34(MethodBind3, GodotObject.GetPtr(this), &internalSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetTargetSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTargetSize(Vector2I targetSize)
    {
        NativeCalls.godot_icall_1_34(MethodBind5, GodotObject.GetPtr(this), &targetSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetViewCount()
    {
        return NativeCalls.godot_icall_0_209(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetViewCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetViewCount(uint viewCount)
    {
        NativeCalls.godot_icall_1_208(MethodBind7, GodotObject.GetPtr(this), viewCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScaling3DMode, 976778074ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingServer.ViewportScaling3DMode GetScaling3DMode()
    {
        return (RenderingServer.ViewportScaling3DMode)NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScaling3DMode, 447477857ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScaling3DMode(RenderingServer.ViewportScaling3DMode scaling3DMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), (int)scaling3DMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMsaa3D, 3109158617ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingServer.ViewportMsaa GetMsaa3D()
    {
        return (RenderingServer.ViewportMsaa)NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMsaa3D, 3952630748ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMsaa3D(RenderingServer.ViewportMsaa msaa3D)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), (int)msaa3D);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenSpaceAA, 641513172ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingServer.ViewportScreenSpaceAA GetScreenSpaceAA()
    {
        return (RenderingServer.ViewportScreenSpaceAA)NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScreenSpaceAA, 139543108ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScreenSpaceAA(RenderingServer.ViewportScreenSpaceAA screenSpaceAA)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), (int)screenSpaceAA);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFsrSharpness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFsrSharpness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFsrSharpness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFsrSharpness(float fsrSharpness)
    {
        NativeCalls.godot_icall_1_67(MethodBind15, GodotObject.GetPtr(this), fsrSharpness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureMipmapBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTextureMipmapBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureMipmapBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureMipmapBias(float textureMipmapBias)
    {
        NativeCalls.godot_icall_1_67(MethodBind17, GodotObject.GetPtr(this), textureMipmapBias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnisotropicFilteringLevel, 1617414954ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingServer.ViewportAnisotropicFiltering GetAnisotropicFilteringLevel()
    {
        return (RenderingServer.ViewportAnisotropicFiltering)NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnisotropicFilteringLevel, 2559658741ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAnisotropicFilteringLevel(RenderingServer.ViewportAnisotropicFiltering anisotropicFilteringLevel)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), (int)anisotropicFilteringLevel);
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
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'render_target' property.
        /// </summary>
        public static readonly StringName RenderTarget = "render_target";
        /// <summary>
        /// Cached name for the 'internal_size' property.
        /// </summary>
        public static readonly StringName InternalSize = "internal_size";
        /// <summary>
        /// Cached name for the 'target_size' property.
        /// </summary>
        public static readonly StringName TargetSize = "target_size";
        /// <summary>
        /// Cached name for the 'view_count' property.
        /// </summary>
        public static readonly StringName ViewCount = "view_count";
        /// <summary>
        /// Cached name for the 'scaling_3d_mode' property.
        /// </summary>
        public static readonly StringName Scaling3DMode = "scaling_3d_mode";
        /// <summary>
        /// Cached name for the 'msaa_3d' property.
        /// </summary>
        public static readonly StringName Msaa3D = "msaa_3d";
        /// <summary>
        /// Cached name for the 'screen_space_aa' property.
        /// </summary>
        public static readonly StringName ScreenSpaceAA = "screen_space_aa";
        /// <summary>
        /// Cached name for the 'fsr_sharpness' property.
        /// </summary>
        public static readonly StringName FsrSharpness = "fsr_sharpness";
        /// <summary>
        /// Cached name for the 'texture_mipmap_bias' property.
        /// </summary>
        public static readonly StringName TextureMipmapBias = "texture_mipmap_bias";
        /// <summary>
        /// Cached name for the 'anisotropic_filtering_level' property.
        /// </summary>
        public static readonly StringName AnisotropicFilteringLevel = "anisotropic_filtering_level";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_render_target' method.
        /// </summary>
        public static readonly StringName GetRenderTarget = "get_render_target";
        /// <summary>
        /// Cached name for the 'set_render_target' method.
        /// </summary>
        public static readonly StringName SetRenderTarget = "set_render_target";
        /// <summary>
        /// Cached name for the 'get_internal_size' method.
        /// </summary>
        public static readonly StringName GetInternalSize = "get_internal_size";
        /// <summary>
        /// Cached name for the 'set_internal_size' method.
        /// </summary>
        public static readonly StringName SetInternalSize = "set_internal_size";
        /// <summary>
        /// Cached name for the 'get_target_size' method.
        /// </summary>
        public static readonly StringName GetTargetSize = "get_target_size";
        /// <summary>
        /// Cached name for the 'set_target_size' method.
        /// </summary>
        public static readonly StringName SetTargetSize = "set_target_size";
        /// <summary>
        /// Cached name for the 'get_view_count' method.
        /// </summary>
        public static readonly StringName GetViewCount = "get_view_count";
        /// <summary>
        /// Cached name for the 'set_view_count' method.
        /// </summary>
        public static readonly StringName SetViewCount = "set_view_count";
        /// <summary>
        /// Cached name for the 'get_scaling_3d_mode' method.
        /// </summary>
        public static readonly StringName GetScaling3DMode = "get_scaling_3d_mode";
        /// <summary>
        /// Cached name for the 'set_scaling_3d_mode' method.
        /// </summary>
        public static readonly StringName SetScaling3DMode = "set_scaling_3d_mode";
        /// <summary>
        /// Cached name for the 'get_msaa_3d' method.
        /// </summary>
        public static readonly StringName GetMsaa3D = "get_msaa_3d";
        /// <summary>
        /// Cached name for the 'set_msaa_3d' method.
        /// </summary>
        public static readonly StringName SetMsaa3D = "set_msaa_3d";
        /// <summary>
        /// Cached name for the 'get_screen_space_aa' method.
        /// </summary>
        public static readonly StringName GetScreenSpaceAA = "get_screen_space_aa";
        /// <summary>
        /// Cached name for the 'set_screen_space_aa' method.
        /// </summary>
        public static readonly StringName SetScreenSpaceAA = "set_screen_space_aa";
        /// <summary>
        /// Cached name for the 'get_fsr_sharpness' method.
        /// </summary>
        public static readonly StringName GetFsrSharpness = "get_fsr_sharpness";
        /// <summary>
        /// Cached name for the 'set_fsr_sharpness' method.
        /// </summary>
        public static readonly StringName SetFsrSharpness = "set_fsr_sharpness";
        /// <summary>
        /// Cached name for the 'get_texture_mipmap_bias' method.
        /// </summary>
        public static readonly StringName GetTextureMipmapBias = "get_texture_mipmap_bias";
        /// <summary>
        /// Cached name for the 'set_texture_mipmap_bias' method.
        /// </summary>
        public static readonly StringName SetTextureMipmapBias = "set_texture_mipmap_bias";
        /// <summary>
        /// Cached name for the 'get_anisotropic_filtering_level' method.
        /// </summary>
        public static readonly StringName GetAnisotropicFilteringLevel = "get_anisotropic_filtering_level";
        /// <summary>
        /// Cached name for the 'set_anisotropic_filtering_level' method.
        /// </summary>
        public static readonly StringName SetAnisotropicFilteringLevel = "set_anisotropic_filtering_level";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
