namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Composition layers allow 2D viewports to be displayed inside of the headset by the XR compositor through special projections that retain their quality. This allows for rendering clear text while keeping the layer at a native resolution.</para>
/// <para><b>Note:</b> If the OpenXR runtime doesn't support the given composition layer type, a fallback mesh can be generated with a <see cref="Godot.ViewportTexture"/>, in order to emulate the composition layer.</para>
/// </summary>
public partial class OpenXRCompositionLayer : Node3D
{
    public enum Filter : long
    {
        /// <summary>
        /// <para>Perform nearest-neighbor filtering when sampling the texture.</para>
        /// </summary>
        Nearest = 0,
        /// <summary>
        /// <para>Perform linear filtering when sampling the texture.</para>
        /// </summary>
        Linear = 1,
        /// <summary>
        /// <para>Perform cubic filtering when sampling the texture.</para>
        /// </summary>
        Cubic = 2
    }

    public enum MipmapMode : long
    {
        /// <summary>
        /// <para>Disable mipmapping.</para>
        /// <para><b>Note:</b> Mipmapping can only be disabled in the Compatibility renderer.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Use the mipmap of the nearest resolution.</para>
        /// </summary>
        Nearest = 1,
        /// <summary>
        /// <para>Use linear interpolation of the two mipmaps of the nearest resolution.</para>
        /// </summary>
        Linear = 2
    }

    public enum Wrap : long
    {
        /// <summary>
        /// <para>Clamp the texture to its specified border color.</para>
        /// </summary>
        ClampToBorder = 0,
        /// <summary>
        /// <para>Clamp the texture to its edge color.</para>
        /// </summary>
        ClampToEdge = 1,
        /// <summary>
        /// <para>Repeat the texture infinitely.</para>
        /// </summary>
        Repeat = 2,
        /// <summary>
        /// <para>Repeat the texture infinitely, mirroring it on each repeat.</para>
        /// </summary>
        MirroredRepeat = 3,
        /// <summary>
        /// <para>Mirror the texture once and then clamp the texture to its edge color.</para>
        /// <para><b>Note:</b> This wrap mode is not available in the Compatibility renderer.</para>
        /// </summary>
        MirrorClampToEdge = 4
    }

    public enum Swizzle : long
    {
        /// <summary>
        /// <para>Maps a color channel to the value of the red channel.</para>
        /// </summary>
        Red = 0,
        /// <summary>
        /// <para>Maps a color channel to the value of the green channel.</para>
        /// </summary>
        Green = 1,
        /// <summary>
        /// <para>Maps a color channel to the value of the blue channel.</para>
        /// </summary>
        Blue = 2,
        /// <summary>
        /// <para>Maps a color channel to the value of the alpha channel.</para>
        /// </summary>
        Alpha = 3,
        /// <summary>
        /// <para>Maps a color channel to the value of zero.</para>
        /// </summary>
        Zero = 4,
        /// <summary>
        /// <para>Maps a color channel to the value of one.</para>
        /// </summary>
        One = 5
    }

    /// <summary>
    /// <para>The <see cref="Godot.SubViewport"/> to render on the composition layer.</para>
    /// </summary>
    public SubViewport LayerViewport
    {
        get
        {
            return GetLayerViewport();
        }
        set
        {
            SetLayerViewport(value);
        }
    }

    /// <summary>
    /// <para>If enabled, an Android surface will be created (with the dimensions from <see cref="Godot.OpenXRCompositionLayer.AndroidSurfaceSize"/>) which will provide the 2D content for the composition layer, rather than using <see cref="Godot.OpenXRCompositionLayer.LayerViewport"/>.</para>
    /// <para>See <see cref="Godot.OpenXRCompositionLayer.GetAndroidSurface()"/> for information about how to get the surface so that your application can draw to it.</para>
    /// <para><b>Note:</b> This will only work in Android builds.</para>
    /// </summary>
    public bool UseAndroidSurface
    {
        get
        {
            return GetUseAndroidSurface();
        }
        set
        {
            SetUseAndroidSurface(value);
        }
    }

    /// <summary>
    /// <para>If enabled, the OpenXR swapchain will be created with the <c>XR_SWAPCHAIN_CREATE_PROTECTED_CONTENT_BIT</c> flag, which will protect its contents from CPU access.</para>
    /// <para>When used with an Android Surface, this may allow DRM content to be presented, and will only take effect when the Surface is first created; later changes to this property will have no effect.</para>
    /// </summary>
    public bool ProtectedContent
    {
        get
        {
            return IsProtectedContent();
        }
        set
        {
            SetProtectedContent(value);
        }
    }

    /// <summary>
    /// <para>The size of the Android surface to create if <see cref="Godot.OpenXRCompositionLayer.UseAndroidSurface"/> is enabled.</para>
    /// </summary>
    public Vector2I AndroidSurfaceSize
    {
        get
        {
            return GetAndroidSurfaceSize();
        }
        set
        {
            SetAndroidSurfaceSize(value);
        }
    }

    /// <summary>
    /// <para>The sort order for this composition layer. Higher numbers will be shown in front of lower numbers.</para>
    /// <para><b>Note:</b> This will have no effect if a fallback mesh is being used.</para>
    /// </summary>
    public int SortOrder
    {
        get
        {
            return GetSortOrder();
        }
        set
        {
            SetSortOrder(value);
        }
    }

    /// <summary>
    /// <para>Enables the blending the layer using its alpha channel.</para>
    /// <para>Can be combined with <see cref="Godot.Viewport.TransparentBg"/> to give the layer a transparent background.</para>
    /// </summary>
    public bool AlphaBlend
    {
        get
        {
            return GetAlphaBlend();
        }
        set
        {
            SetAlphaBlend(value);
        }
    }

    /// <summary>
    /// <para>Enables a technique called "hole punching", which allows putting the composition layer behind the main projection layer (i.e. setting <see cref="Godot.OpenXRCompositionLayer.SortOrder"/> to a negative value) while "punching a hole" through everything rendered by Godot so that the layer is still visible.</para>
    /// <para>This can be used to create the illusion that the composition layer exists in the same 3D space as everything rendered by Godot, allowing objects to appear to pass both behind or in front of the composition layer.</para>
    /// </summary>
    public bool EnableHolePunch
    {
        get
        {
            return GetEnableHolePunch();
        }
        set
        {
            SetEnableHolePunch(value);
        }
    }

    /// <summary>
    /// <para>The minification filter of the swapchain state.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public OpenXRCompositionLayer.Filter SwapchainStateMinFilter
    {
        get
        {
            return GetMinFilter();
        }
        set
        {
            SetMinFilter(value);
        }
    }

    /// <summary>
    /// <para>The magnification filter of the swapchain state.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public OpenXRCompositionLayer.Filter SwapchainStateMagFilter
    {
        get
        {
            return GetMagFilter();
        }
        set
        {
            SetMagFilter(value);
        }
    }

    /// <summary>
    /// <para>The mipmap mode of the swapchain state.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public OpenXRCompositionLayer.MipmapMode SwapchainStateMipmapMode
    {
        get
        {
            return GetMipmapMode();
        }
        set
        {
            SetMipmapMode(value);
        }
    }

    /// <summary>
    /// <para>The horizontal wrap mode of the swapchain state.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public OpenXRCompositionLayer.Wrap SwapchainStateHorizontalWrap
    {
        get
        {
            return GetHorizontalWrap();
        }
        set
        {
            SetHorizontalWrap(value);
        }
    }

    /// <summary>
    /// <para>The vertical wrap mode of the swapchain state.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public OpenXRCompositionLayer.Wrap SwapchainStateVerticalWrap
    {
        get
        {
            return GetVerticalWrap();
        }
        set
        {
            SetVerticalWrap(value);
        }
    }

    /// <summary>
    /// <para>The swizzle value for the red channel of the swapchain state.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public OpenXRCompositionLayer.Swizzle SwapchainStateRedSwizzle
    {
        get
        {
            return GetRedSwizzle();
        }
        set
        {
            SetRedSwizzle(value);
        }
    }

    /// <summary>
    /// <para>The swizzle value for the green channel of the swapchain state.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public OpenXRCompositionLayer.Swizzle SwapchainStateGreenSwizzle
    {
        get
        {
            return GetGreenSwizzle();
        }
        set
        {
            SetGreenSwizzle(value);
        }
    }

    /// <summary>
    /// <para>The swizzle value for the blue channel of the swapchain state.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public OpenXRCompositionLayer.Swizzle SwapchainStateBlueSwizzle
    {
        get
        {
            return GetBlueSwizzle();
        }
        set
        {
            SetBlueSwizzle(value);
        }
    }

    /// <summary>
    /// <para>The swizzle value for the alpha channel of the swapchain state.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public OpenXRCompositionLayer.Swizzle SwapchainStateAlphaSwizzle
    {
        get
        {
            return GetAlphaSwizzle();
        }
        set
        {
            SetAlphaSwizzle(value);
        }
    }

    /// <summary>
    /// <para>The max anisotropy of the swapchain state.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public float SwapchainStateMaxAnisotropy
    {
        get
        {
            return GetMaxAnisotropy();
        }
        set
        {
            SetMaxAnisotropy(value);
        }
    }

    /// <summary>
    /// <para>The border color of the swapchain state that is used when the wrap mode clamps to the border.</para>
    /// <para><b>Note:</b> This property only has an effect on devices that support the OpenXR XR_FB_swapchain_update_state OpenGLES/Vulkan extensions.</para>
    /// </summary>
    public Color SwapchainStateBorderColor
    {
        get
        {
            return GetBorderColor();
        }
        set
        {
            SetBorderColor(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRCompositionLayer);

    private static readonly StringName NativeName = "OpenXRCompositionLayer";

    internal OpenXRCompositionLayer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRCompositionLayer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRCompositionLayer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerViewport, 3888077664ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLayerViewport(SubViewport viewport)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(viewport));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerViewport, 3750751911ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SubViewport GetLayerViewport()
    {
        return (SubViewport)NativeCalls.godot_icall_0_53(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseAndroidSurface, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseAndroidSurface(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseAndroidSurface, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseAndroidSurface()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAndroidSurfaceSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAndroidSurfaceSize(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind4, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAndroidSurfaceSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetAndroidSurfaceSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableHolePunch, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableHolePunch(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableHolePunch, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableHolePunch()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSortOrder, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSortOrder(int order)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), order);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSortOrder, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSortOrder()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaBlend, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaBlend(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaBlend, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAlphaBlend()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAndroidSurface, 3277089691ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.JavaObject"/> representing an <c>android.view.Surface</c> if <see cref="Godot.OpenXRCompositionLayer.UseAndroidSurface"/> is enabled and OpenXR has created the surface. Otherwise, this will return <see langword="null"/>.</para>
    /// <para><b>Note:</b> The surface can only be created during an active OpenXR session. So, if <see cref="Godot.OpenXRCompositionLayer.UseAndroidSurface"/> is enabled outside of an OpenXR session, it won't be created until a new session fully starts.</para>
    /// </summary>
    public JavaObject GetAndroidSurface()
    {
        return (JavaObject)NativeCalls.godot_icall_0_63(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNativelySupported, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the OpenXR runtime natively supports this composition layer type.</para>
    /// <para><b>Note:</b> This will only return an accurate result after the OpenXR session has started.</para>
    /// </summary>
    public bool IsNativelySupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsProtectedContent, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsProtectedContent()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProtectedContent, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProtectedContent(bool protectedContent)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), protectedContent.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinFilter, 3653437593ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinFilter(OpenXRCompositionLayer.Filter mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinFilter, 845677307ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRCompositionLayer.Filter GetMinFilter()
    {
        return (OpenXRCompositionLayer.Filter)NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMagFilter, 3653437593ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMagFilter(OpenXRCompositionLayer.Filter mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMagFilter, 845677307ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRCompositionLayer.Filter GetMagFilter()
    {
        return (OpenXRCompositionLayer.Filter)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMipmapMode, 3271133183ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMipmapMode(OpenXRCompositionLayer.MipmapMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMipmapMode, 3962697095ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRCompositionLayer.MipmapMode GetMipmapMode()
    {
        return (OpenXRCompositionLayer.MipmapMode)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHorizontalWrap, 15634990ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHorizontalWrap(OpenXRCompositionLayer.Wrap mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind22, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHorizontalWrap, 2798816834ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRCompositionLayer.Wrap GetHorizontalWrap()
    {
        return (OpenXRCompositionLayer.Wrap)NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVerticalWrap, 15634990ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVerticalWrap(OpenXRCompositionLayer.Wrap mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVerticalWrap, 2798816834ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRCompositionLayer.Wrap GetVerticalWrap()
    {
        return (OpenXRCompositionLayer.Wrap)NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRedSwizzle, 741598951ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRedSwizzle(OpenXRCompositionLayer.Swizzle mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRedSwizzle, 2334776767ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRCompositionLayer.Swizzle GetRedSwizzle()
    {
        return (OpenXRCompositionLayer.Swizzle)NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGreenSwizzle, 741598951ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGreenSwizzle(OpenXRCompositionLayer.Swizzle mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGreenSwizzle, 2334776767ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRCompositionLayer.Swizzle GetGreenSwizzle()
    {
        return (OpenXRCompositionLayer.Swizzle)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlueSwizzle, 741598951ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlueSwizzle(OpenXRCompositionLayer.Swizzle mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlueSwizzle, 2334776767ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRCompositionLayer.Swizzle GetBlueSwizzle()
    {
        return (OpenXRCompositionLayer.Swizzle)NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaSwizzle, 741598951ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaSwizzle(OpenXRCompositionLayer.Swizzle mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind32, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaSwizzle, 2334776767ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRCompositionLayer.Swizzle GetAlphaSwizzle()
    {
        return (OpenXRCompositionLayer.Swizzle)NativeCalls.godot_icall_0_39(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxAnisotropy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxAnisotropy(float value)
    {
        NativeCalls.godot_icall_1_67(MethodBind34, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxAnisotropy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMaxAnisotropy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBorderColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBorderColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind36, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBorderColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetBorderColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IntersectsRay, 1091262597ul);

    /// <summary>
    /// <para>Returns UV coordinates where the given ray intersects with the composition layer. <paramref name="origin"/> and <paramref name="direction"/> must be in global space.</para>
    /// <para>Returns <c>Vector2(-1.0, -1.0)</c> if the ray doesn't intersect.</para>
    /// </summary>
    public unsafe Vector2 IntersectsRay(Vector3 origin, Vector3 direction)
    {
        return NativeCalls.godot_icall_2_934(MethodBind38, GodotObject.GetPtr(this), &origin, &direction);
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
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'layer_viewport' property.
        /// </summary>
        public static readonly StringName LayerViewport = "layer_viewport";
        /// <summary>
        /// Cached name for the 'use_android_surface' property.
        /// </summary>
        public static readonly StringName UseAndroidSurface = "use_android_surface";
        /// <summary>
        /// Cached name for the 'protected_content' property.
        /// </summary>
        public static readonly StringName ProtectedContent = "protected_content";
        /// <summary>
        /// Cached name for the 'android_surface_size' property.
        /// </summary>
        public static readonly StringName AndroidSurfaceSize = "android_surface_size";
        /// <summary>
        /// Cached name for the 'sort_order' property.
        /// </summary>
        public static readonly StringName SortOrder = "sort_order";
        /// <summary>
        /// Cached name for the 'alpha_blend' property.
        /// </summary>
        public static readonly StringName AlphaBlend = "alpha_blend";
        /// <summary>
        /// Cached name for the 'enable_hole_punch' property.
        /// </summary>
        public static readonly StringName EnableHolePunch = "enable_hole_punch";
        /// <summary>
        /// Cached name for the 'swapchain_state_min_filter' property.
        /// </summary>
        public static readonly StringName SwapchainStateMinFilter = "swapchain_state_min_filter";
        /// <summary>
        /// Cached name for the 'swapchain_state_mag_filter' property.
        /// </summary>
        public static readonly StringName SwapchainStateMagFilter = "swapchain_state_mag_filter";
        /// <summary>
        /// Cached name for the 'swapchain_state_mipmap_mode' property.
        /// </summary>
        public static readonly StringName SwapchainStateMipmapMode = "swapchain_state_mipmap_mode";
        /// <summary>
        /// Cached name for the 'swapchain_state_horizontal_wrap' property.
        /// </summary>
        public static readonly StringName SwapchainStateHorizontalWrap = "swapchain_state_horizontal_wrap";
        /// <summary>
        /// Cached name for the 'swapchain_state_vertical_wrap' property.
        /// </summary>
        public static readonly StringName SwapchainStateVerticalWrap = "swapchain_state_vertical_wrap";
        /// <summary>
        /// Cached name for the 'swapchain_state_red_swizzle' property.
        /// </summary>
        public static readonly StringName SwapchainStateRedSwizzle = "swapchain_state_red_swizzle";
        /// <summary>
        /// Cached name for the 'swapchain_state_green_swizzle' property.
        /// </summary>
        public static readonly StringName SwapchainStateGreenSwizzle = "swapchain_state_green_swizzle";
        /// <summary>
        /// Cached name for the 'swapchain_state_blue_swizzle' property.
        /// </summary>
        public static readonly StringName SwapchainStateBlueSwizzle = "swapchain_state_blue_swizzle";
        /// <summary>
        /// Cached name for the 'swapchain_state_alpha_swizzle' property.
        /// </summary>
        public static readonly StringName SwapchainStateAlphaSwizzle = "swapchain_state_alpha_swizzle";
        /// <summary>
        /// Cached name for the 'swapchain_state_max_anisotropy' property.
        /// </summary>
        public static readonly StringName SwapchainStateMaxAnisotropy = "swapchain_state_max_anisotropy";
        /// <summary>
        /// Cached name for the 'swapchain_state_border_color' property.
        /// </summary>
        public static readonly StringName SwapchainStateBorderColor = "swapchain_state_border_color";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_layer_viewport' method.
        /// </summary>
        public static readonly StringName SetLayerViewport = "set_layer_viewport";
        /// <summary>
        /// Cached name for the 'get_layer_viewport' method.
        /// </summary>
        public static readonly StringName GetLayerViewport = "get_layer_viewport";
        /// <summary>
        /// Cached name for the 'set_use_android_surface' method.
        /// </summary>
        public static readonly StringName SetUseAndroidSurface = "set_use_android_surface";
        /// <summary>
        /// Cached name for the 'get_use_android_surface' method.
        /// </summary>
        public static readonly StringName GetUseAndroidSurface = "get_use_android_surface";
        /// <summary>
        /// Cached name for the 'set_android_surface_size' method.
        /// </summary>
        public static readonly StringName SetAndroidSurfaceSize = "set_android_surface_size";
        /// <summary>
        /// Cached name for the 'get_android_surface_size' method.
        /// </summary>
        public static readonly StringName GetAndroidSurfaceSize = "get_android_surface_size";
        /// <summary>
        /// Cached name for the 'set_enable_hole_punch' method.
        /// </summary>
        public static readonly StringName SetEnableHolePunch = "set_enable_hole_punch";
        /// <summary>
        /// Cached name for the 'get_enable_hole_punch' method.
        /// </summary>
        public static readonly StringName GetEnableHolePunch = "get_enable_hole_punch";
        /// <summary>
        /// Cached name for the 'set_sort_order' method.
        /// </summary>
        public static readonly StringName SetSortOrder = "set_sort_order";
        /// <summary>
        /// Cached name for the 'get_sort_order' method.
        /// </summary>
        public static readonly StringName GetSortOrder = "get_sort_order";
        /// <summary>
        /// Cached name for the 'set_alpha_blend' method.
        /// </summary>
        public static readonly StringName SetAlphaBlend = "set_alpha_blend";
        /// <summary>
        /// Cached name for the 'get_alpha_blend' method.
        /// </summary>
        public static readonly StringName GetAlphaBlend = "get_alpha_blend";
        /// <summary>
        /// Cached name for the 'get_android_surface' method.
        /// </summary>
        public static readonly StringName GetAndroidSurface = "get_android_surface";
        /// <summary>
        /// Cached name for the 'is_natively_supported' method.
        /// </summary>
        public static readonly StringName IsNativelySupported = "is_natively_supported";
        /// <summary>
        /// Cached name for the 'is_protected_content' method.
        /// </summary>
        public static readonly StringName IsProtectedContent = "is_protected_content";
        /// <summary>
        /// Cached name for the 'set_protected_content' method.
        /// </summary>
        public static readonly StringName SetProtectedContent = "set_protected_content";
        /// <summary>
        /// Cached name for the 'set_min_filter' method.
        /// </summary>
        public static readonly StringName SetMinFilter = "set_min_filter";
        /// <summary>
        /// Cached name for the 'get_min_filter' method.
        /// </summary>
        public static readonly StringName GetMinFilter = "get_min_filter";
        /// <summary>
        /// Cached name for the 'set_mag_filter' method.
        /// </summary>
        public static readonly StringName SetMagFilter = "set_mag_filter";
        /// <summary>
        /// Cached name for the 'get_mag_filter' method.
        /// </summary>
        public static readonly StringName GetMagFilter = "get_mag_filter";
        /// <summary>
        /// Cached name for the 'set_mipmap_mode' method.
        /// </summary>
        public static readonly StringName SetMipmapMode = "set_mipmap_mode";
        /// <summary>
        /// Cached name for the 'get_mipmap_mode' method.
        /// </summary>
        public static readonly StringName GetMipmapMode = "get_mipmap_mode";
        /// <summary>
        /// Cached name for the 'set_horizontal_wrap' method.
        /// </summary>
        public static readonly StringName SetHorizontalWrap = "set_horizontal_wrap";
        /// <summary>
        /// Cached name for the 'get_horizontal_wrap' method.
        /// </summary>
        public static readonly StringName GetHorizontalWrap = "get_horizontal_wrap";
        /// <summary>
        /// Cached name for the 'set_vertical_wrap' method.
        /// </summary>
        public static readonly StringName SetVerticalWrap = "set_vertical_wrap";
        /// <summary>
        /// Cached name for the 'get_vertical_wrap' method.
        /// </summary>
        public static readonly StringName GetVerticalWrap = "get_vertical_wrap";
        /// <summary>
        /// Cached name for the 'set_red_swizzle' method.
        /// </summary>
        public static readonly StringName SetRedSwizzle = "set_red_swizzle";
        /// <summary>
        /// Cached name for the 'get_red_swizzle' method.
        /// </summary>
        public static readonly StringName GetRedSwizzle = "get_red_swizzle";
        /// <summary>
        /// Cached name for the 'set_green_swizzle' method.
        /// </summary>
        public static readonly StringName SetGreenSwizzle = "set_green_swizzle";
        /// <summary>
        /// Cached name for the 'get_green_swizzle' method.
        /// </summary>
        public static readonly StringName GetGreenSwizzle = "get_green_swizzle";
        /// <summary>
        /// Cached name for the 'set_blue_swizzle' method.
        /// </summary>
        public static readonly StringName SetBlueSwizzle = "set_blue_swizzle";
        /// <summary>
        /// Cached name for the 'get_blue_swizzle' method.
        /// </summary>
        public static readonly StringName GetBlueSwizzle = "get_blue_swizzle";
        /// <summary>
        /// Cached name for the 'set_alpha_swizzle' method.
        /// </summary>
        public static readonly StringName SetAlphaSwizzle = "set_alpha_swizzle";
        /// <summary>
        /// Cached name for the 'get_alpha_swizzle' method.
        /// </summary>
        public static readonly StringName GetAlphaSwizzle = "get_alpha_swizzle";
        /// <summary>
        /// Cached name for the 'set_max_anisotropy' method.
        /// </summary>
        public static readonly StringName SetMaxAnisotropy = "set_max_anisotropy";
        /// <summary>
        /// Cached name for the 'get_max_anisotropy' method.
        /// </summary>
        public static readonly StringName GetMaxAnisotropy = "get_max_anisotropy";
        /// <summary>
        /// Cached name for the 'set_border_color' method.
        /// </summary>
        public static readonly StringName SetBorderColor = "set_border_color";
        /// <summary>
        /// Cached name for the 'get_border_color' method.
        /// </summary>
        public static readonly StringName GetBorderColor = "get_border_color";
        /// <summary>
        /// Cached name for the 'intersects_ray' method.
        /// </summary>
        public static readonly StringName IntersectsRay = "intersects_ray";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
