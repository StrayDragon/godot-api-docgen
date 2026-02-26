namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object manages all 3D rendering buffers for the rendering device based renderers. An instance of this object is created for every viewport that has 3D rendering enabled. See also <see cref="Godot.RenderSceneBuffers"/>.</para>
/// <para>All buffers are organized in <b>contexts</b>. The default context is called <b>render_buffers</b> and can contain amongst others the color buffer, depth buffer, velocity buffers, VRS density map and MSAA variants of these buffers.</para>
/// <para>Buffers are only guaranteed to exist during rendering of the viewport.</para>
/// <para><b>Note:</b> This is an internal rendering server object. Do not instantiate this class from a script.</para>
/// </summary>
public partial class RenderSceneBuffersRD : RenderSceneBuffers
{
    private static readonly System.Type CachedType = typeof(RenderSceneBuffersRD);

    private static readonly StringName NativeName = "RenderSceneBuffersRD";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RenderSceneBuffersRD() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RenderSceneBuffersRD(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RenderSceneBuffersRD(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasTexture, 471820014ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a cached texture exists for this name.</para>
    /// </summary>
    public bool HasTexture(StringName context, StringName name)
    {
        return NativeCalls.godot_icall_2_160(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTexture, 2950875024ul);

    /// <summary>
    /// <para>Create a new texture with the given definition and cache this under the given name. Will return the existing texture if it already exists.</para>
    /// </summary>
    public unsafe Rid CreateTexture(StringName context, StringName name, RenderingDevice.DataFormat dataFormat, uint usageBits, RenderingDevice.TextureSamples textureSamples, Vector2I size, uint layers, uint mipmaps, bool unique, bool discardable)
    {
        return NativeCalls.godot_icall_10_1037(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default), (int)dataFormat, usageBits, (int)textureSamples, &size, layers, mipmaps, unique.ToGodotBool(), discardable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTextureFromFormat, 3344669382ul);

    /// <summary>
    /// <para>Create a new texture using the given format and view and cache this under the given name. Will return the existing texture if it already exists.</para>
    /// </summary>
    public Rid CreateTextureFromFormat(StringName context, StringName name, RDTextureFormat format, RDTextureView view, bool unique)
    {
        return NativeCalls.godot_icall_5_1038(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(format), GodotObject.GetPtr(view), unique.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTextureView, 283055834ul);

    /// <summary>
    /// <para>Create a new texture view for an existing texture and cache this under the given <paramref name="viewName"/>. Will return the existing texture view if it already exists. Will error if the source texture doesn't exist.</para>
    /// </summary>
    public Rid CreateTextureView(StringName context, StringName name, StringName viewName, RDTextureView view)
    {
        return NativeCalls.godot_icall_4_1039(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(viewName?.NativeValue ?? default), GodotObject.GetPtr(view));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 750006389ul);

    /// <summary>
    /// <para>Returns a cached texture with this name.</para>
    /// </summary>
    public Rid GetTexture(StringName context, StringName name)
    {
        return NativeCalls.godot_icall_2_1040(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureFormat, 371461758ul);

    /// <summary>
    /// <para>Returns the texture format information with which a cached texture was created.</para>
    /// </summary>
    public RDTextureFormat GetTextureFormat(StringName context, StringName name)
    {
        return (RDTextureFormat)NativeCalls.godot_icall_2_336(MethodBind5, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureSlice, 588440706ul);

    /// <summary>
    /// <para>Returns a specific slice (layer or mipmap) for a cached texture.</para>
    /// </summary>
    public Rid GetTextureSlice(StringName context, StringName name, uint layer, uint mipmap, uint layers, uint mipmaps)
    {
        return NativeCalls.godot_icall_6_1041(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default), layer, mipmap, layers, mipmaps);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureSliceView, 682451778ul);

    /// <summary>
    /// <para>Returns a specific view of a slice (layer or mipmap) for a cached texture.</para>
    /// </summary>
    public Rid GetTextureSliceView(StringName context, StringName name, uint layer, uint mipmap, uint layers, uint mipmaps, RDTextureView view)
    {
        return NativeCalls.godot_icall_7_1042(MethodBind7, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default), layer, mipmap, layers, mipmaps, GodotObject.GetPtr(view));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureSliceSize, 2617625368ul);

    /// <summary>
    /// <para>Returns the texture size of a given slice of a cached texture.</para>
    /// </summary>
    public Vector2I GetTextureSliceSize(StringName context, StringName name, uint mipmap)
    {
        return NativeCalls.godot_icall_3_1043(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default), mipmap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearContext, 3304788590ul);

    /// <summary>
    /// <para>Frees all buffers related to this context.</para>
    /// </summary>
    public void ClearContext(StringName context)
    {
        NativeCalls.godot_icall_1_64(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorTexture, 3050822880ul);

    /// <summary>
    /// <para>Returns the color texture we are rendering 3D content to. If multiview is used this will be a texture array with all views.</para>
    /// <para>If <paramref name="msaa"/> is <see langword="true"/> and MSAA is enabled, this returns the MSAA variant of the buffer.</para>
    /// </summary>
    public Rid GetColorTexture(bool msaa = false)
    {
        return NativeCalls.godot_icall_1_1044(MethodBind10, GodotObject.GetPtr(this), msaa.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorLayer, 3087988589ul);

    /// <summary>
    /// <para>Returns the specified layer from the color texture we are rendering 3D content to.</para>
    /// <para>If <paramref name="msaa"/> is <see langword="true"/> and MSAA is enabled, this returns the MSAA variant of the buffer.</para>
    /// </summary>
    public Rid GetColorLayer(uint layer, bool msaa = false)
    {
        return NativeCalls.godot_icall_2_1045(MethodBind11, GodotObject.GetPtr(this), layer, msaa.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthTexture, 3050822880ul);

    /// <summary>
    /// <para>Returns the depth texture we are rendering 3D content to. If multiview is used this will be a texture array with all views.</para>
    /// <para>If <paramref name="msaa"/> is <see langword="true"/> and MSAA is enabled, this returns the MSAA variant of the buffer.</para>
    /// </summary>
    public Rid GetDepthTexture(bool msaa = false)
    {
        return NativeCalls.godot_icall_1_1044(MethodBind12, GodotObject.GetPtr(this), msaa.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthLayer, 3087988589ul);

    /// <summary>
    /// <para>Returns the specified layer from the depth texture we are rendering 3D content to.</para>
    /// <para>If <paramref name="msaa"/> is <see langword="true"/> and MSAA is enabled, this returns the MSAA variant of the buffer.</para>
    /// </summary>
    public Rid GetDepthLayer(uint layer, bool msaa = false)
    {
        return NativeCalls.godot_icall_2_1045(MethodBind13, GodotObject.GetPtr(this), layer, msaa.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocityTexture, 3050822880ul);

    /// <summary>
    /// <para>Returns the velocity texture we are rendering 3D content to. If multiview is used this will be a texture array with all views.</para>
    /// <para>If <paramref name="msaa"/> is <b>true</b> and MSAA is enabled, this returns the MSAA variant of the buffer.</para>
    /// </summary>
    public Rid GetVelocityTexture(bool msaa = false)
    {
        return NativeCalls.godot_icall_1_1044(MethodBind14, GodotObject.GetPtr(this), msaa.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocityLayer, 3087988589ul);

    /// <summary>
    /// <para>Returns the specified layer from the velocity texture we are rendering 3D content to.</para>
    /// </summary>
    public Rid GetVelocityLayer(uint layer, bool msaa = false)
    {
        return NativeCalls.godot_icall_2_1045(MethodBind15, GodotObject.GetPtr(this), layer, msaa.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderTarget, 2944877500ul);

    /// <summary>
    /// <para>Returns the render target associated with this buffers object.</para>
    /// </summary>
    public Rid GetRenderTarget()
    {
        return NativeCalls.godot_icall_0_238(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the view count for the associated viewport.</para>
    /// </summary>
    public uint GetViewCount()
    {
        return NativeCalls.godot_icall_0_209(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInternalSize, 3690982128ul);

    /// <summary>
    /// <para>Returns the internal size of the render buffer (size before upscaling) with which textures are created by default.</para>
    /// </summary>
    public Vector2I GetInternalSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetSize, 3690982128ul);

    /// <summary>
    /// <para>Returns the target size of the render buffer (size after upscaling).</para>
    /// </summary>
    public Vector2I GetTargetSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScaling3DMode, 976778074ul);

    /// <summary>
    /// <para>Returns the scaling mode used for upscaling.</para>
    /// </summary>
    public RenderingServer.ViewportScaling3DMode GetScaling3DMode()
    {
        return (RenderingServer.ViewportScaling3DMode)NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFsrSharpness, 1740695150ul);

    /// <summary>
    /// <para>Returns the FSR sharpness value used while rendering the 3D content (if <see cref="Godot.RenderSceneBuffersRD.GetScaling3DMode()"/> is an FSR mode).</para>
    /// </summary>
    public float GetFsrSharpness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMsaa3D, 3109158617ul);

    /// <summary>
    /// <para>Returns the applied 3D MSAA mode for this viewport.</para>
    /// </summary>
    public RenderingServer.ViewportMsaa GetMsaa3D()
    {
        return (RenderingServer.ViewportMsaa)NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureSamples, 407791724ul);

    /// <summary>
    /// <para>Returns the number of MSAA samples used.</para>
    /// </summary>
    public RenderingDevice.TextureSamples GetTextureSamples()
    {
        return (RenderingDevice.TextureSamples)NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenSpaceAA, 641513172ul);

    /// <summary>
    /// <para>Returns the screen-space antialiasing method applied.</para>
    /// </summary>
    public RenderingServer.ViewportScreenSpaceAA GetScreenSpaceAA()
    {
        return (RenderingServer.ViewportScreenSpaceAA)NativeCalls.godot_icall_0_39(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseTaa, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if TAA is enabled.</para>
    /// </summary>
    public bool GetUseTaa()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseDebanding, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if debanding is enabled.</para>
    /// </summary>
    public bool GetUseDebanding()
    {
        return NativeCalls.godot_icall_0_15(MethodBind26, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTexture, 3559915770ul);

    /// <summary>
    /// <para>Create a new texture with the given definition and cache this under the given name. Will return the existing texture if it already exists.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe Rid CreateTexture(StringName context, StringName name, RenderingDevice.DataFormat dataFormat, uint usageBits, RenderingDevice.TextureSamples textureSamples, Vector2I size, uint layers, uint mipmaps, bool unique)
    {
        return NativeCalls.godot_icall_9_1046(MethodBind27, GodotObject.GetPtr(this), (godot_string_name)(context?.NativeValue ?? default), (godot_string_name)(name?.NativeValue ?? default), (int)dataFormat, usageBits, (int)textureSamples, &size, layers, mipmaps, unique.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocityLayer, 937000113ul);

    /// <summary>
    /// <para>Returns the specified layer from the velocity texture we are rendering 3D content to.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetVelocityLayer(uint layer)
    {
        return NativeCalls.godot_icall_1_1047(MethodBind28, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocityTexture, 529393457ul);

    /// <summary>
    /// <para>Returns the velocity texture we are rendering 3D content to. If multiview is used this will be a texture array with all views.</para>
    /// <para>If <paramref name="msaa"/> is <b>true</b> and MSAA is enabled, this returns the MSAA variant of the buffer.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetVelocityTexture()
    {
        return NativeCalls.godot_icall_0_238(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthLayer, 937000113ul);

    /// <summary>
    /// <para>Returns the specified layer from the depth texture we are rendering 3D content to.</para>
    /// <para>If <paramref name="msaa"/> is <see langword="true"/> and MSAA is enabled, this returns the MSAA variant of the buffer.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetDepthLayer(uint layer)
    {
        return NativeCalls.godot_icall_1_1047(MethodBind30, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthTexture, 529393457ul);

    /// <summary>
    /// <para>Returns the depth texture we are rendering 3D content to. If multiview is used this will be a texture array with all views.</para>
    /// <para>If <paramref name="msaa"/> is <see langword="true"/> and MSAA is enabled, this returns the MSAA variant of the buffer.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetDepthTexture()
    {
        return NativeCalls.godot_icall_0_238(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorLayer, 937000113ul);

    /// <summary>
    /// <para>Returns the specified layer from the color texture we are rendering 3D content to.</para>
    /// <para>If <paramref name="msaa"/> is <see langword="true"/> and MSAA is enabled, this returns the MSAA variant of the buffer.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetColorLayer(uint layer)
    {
        return NativeCalls.godot_icall_1_1047(MethodBind32, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorTexture, 529393457ul);

    /// <summary>
    /// <para>Returns the color texture we are rendering 3D content to. If multiview is used this will be a texture array with all views.</para>
    /// <para>If <paramref name="msaa"/> is <see langword="true"/> and MSAA is enabled, this returns the MSAA variant of the buffer.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetColorTexture()
    {
        return NativeCalls.godot_icall_0_238(MethodBind33, GodotObject.GetPtr(this));
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
    public new class PropertyName : RenderSceneBuffers.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RenderSceneBuffers.MethodName
    {
        /// <summary>
        /// Cached name for the 'has_texture' method.
        /// </summary>
        public static readonly StringName HasTexture = "has_texture";
        /// <summary>
        /// Cached name for the 'create_texture' method.
        /// </summary>
        public static readonly StringName CreateTexture = "create_texture";
        /// <summary>
        /// Cached name for the 'create_texture_from_format' method.
        /// </summary>
        public static readonly StringName CreateTextureFromFormat = "create_texture_from_format";
        /// <summary>
        /// Cached name for the 'create_texture_view' method.
        /// </summary>
        public static readonly StringName CreateTextureView = "create_texture_view";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
        /// <summary>
        /// Cached name for the 'get_texture_format' method.
        /// </summary>
        public static readonly StringName GetTextureFormat = "get_texture_format";
        /// <summary>
        /// Cached name for the 'get_texture_slice' method.
        /// </summary>
        public static readonly StringName GetTextureSlice = "get_texture_slice";
        /// <summary>
        /// Cached name for the 'get_texture_slice_view' method.
        /// </summary>
        public static readonly StringName GetTextureSliceView = "get_texture_slice_view";
        /// <summary>
        /// Cached name for the 'get_texture_slice_size' method.
        /// </summary>
        public static readonly StringName GetTextureSliceSize = "get_texture_slice_size";
        /// <summary>
        /// Cached name for the 'clear_context' method.
        /// </summary>
        public static readonly StringName ClearContext = "clear_context";
        /// <summary>
        /// Cached name for the 'get_color_texture' method.
        /// </summary>
        public static readonly StringName GetColorTexture = "get_color_texture";
        /// <summary>
        /// Cached name for the 'get_color_layer' method.
        /// </summary>
        public static readonly StringName GetColorLayer = "get_color_layer";
        /// <summary>
        /// Cached name for the 'get_depth_texture' method.
        /// </summary>
        public static readonly StringName GetDepthTexture = "get_depth_texture";
        /// <summary>
        /// Cached name for the 'get_depth_layer' method.
        /// </summary>
        public static readonly StringName GetDepthLayer = "get_depth_layer";
        /// <summary>
        /// Cached name for the 'get_velocity_texture' method.
        /// </summary>
        public static readonly StringName GetVelocityTexture = "get_velocity_texture";
        /// <summary>
        /// Cached name for the 'get_velocity_layer' method.
        /// </summary>
        public static readonly StringName GetVelocityLayer = "get_velocity_layer";
        /// <summary>
        /// Cached name for the 'get_render_target' method.
        /// </summary>
        public static readonly StringName GetRenderTarget = "get_render_target";
        /// <summary>
        /// Cached name for the 'get_view_count' method.
        /// </summary>
        public static readonly StringName GetViewCount = "get_view_count";
        /// <summary>
        /// Cached name for the 'get_internal_size' method.
        /// </summary>
        public static readonly StringName GetInternalSize = "get_internal_size";
        /// <summary>
        /// Cached name for the 'get_target_size' method.
        /// </summary>
        public static readonly StringName GetTargetSize = "get_target_size";
        /// <summary>
        /// Cached name for the 'get_scaling_3d_mode' method.
        /// </summary>
        public static readonly StringName GetScaling3DMode = "get_scaling_3d_mode";
        /// <summary>
        /// Cached name for the 'get_fsr_sharpness' method.
        /// </summary>
        public static readonly StringName GetFsrSharpness = "get_fsr_sharpness";
        /// <summary>
        /// Cached name for the 'get_msaa_3d' method.
        /// </summary>
        public static readonly StringName GetMsaa3D = "get_msaa_3d";
        /// <summary>
        /// Cached name for the 'get_texture_samples' method.
        /// </summary>
        public static readonly StringName GetTextureSamples = "get_texture_samples";
        /// <summary>
        /// Cached name for the 'get_screen_space_aa' method.
        /// </summary>
        public static readonly StringName GetScreenSpaceAA = "get_screen_space_aa";
        /// <summary>
        /// Cached name for the 'get_use_taa' method.
        /// </summary>
        public static readonly StringName GetUseTaa = "get_use_taa";
        /// <summary>
        /// Cached name for the 'get_use_debanding' method.
        /// </summary>
        public static readonly StringName GetUseDebanding = "get_use_debanding";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RenderSceneBuffers.SignalName
    {
    }
}
