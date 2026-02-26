namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.OpenXRApiExtension"/> makes OpenXR available for GDExtension. It provides the OpenXR API to GDExtension through the <see cref="Godot.OpenXRApiExtension.GetInstanceProcAddr(string)"/> method, and the OpenXR instance through <see cref="Godot.OpenXRApiExtension.GetInstance()"/>.</para>
/// <para>It also provides methods for querying the status of OpenXR initialization, and helper methods for ease of use of the API with GDExtension.</para>
/// </summary>
[GodotClassName("OpenXRAPIExtension")]
public partial class OpenXRApiExtension : RefCounted
{
    public enum OpenXRAlphaBlendModeSupport : long
    {
        /// <summary>
        /// <para>Means that <see cref="Godot.XRInterface.EnvironmentBlendModeEnum.AlphaBlend"/> isn't supported at all.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Means that <see cref="Godot.XRInterface.EnvironmentBlendModeEnum.AlphaBlend"/> is really supported.</para>
        /// </summary>
        Real = 1,
        /// <summary>
        /// <para>Means that <see cref="Godot.XRInterface.EnvironmentBlendModeEnum.AlphaBlend"/> is emulated.</para>
        /// </summary>
        Emulating = 2
    }

    private static readonly System.Type CachedType = typeof(OpenXRApiExtension);

    private static readonly StringName NativeName = "OpenXRAPIExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRApiExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRApiExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRApiExtension(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpenxrVersion, 2455072627ul);

    /// <summary>
    /// <para>Returns the version of OpenXR that was initialized. Only valid after the OpenXR instance has been created. See <a href="https://registry.khronos.org/OpenXR/specs/1.1/html/xrspec.html#XR_MAKE_VERSION">XR_MAKE_VERSION</a> for how the version is calculated.</para>
    /// </summary>
    public ulong GetOpenxrVersion()
    {
        return NativeCalls.godot_icall_0_137(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstance, 2455072627ul);

    /// <summary>
    /// <para>Returns the <a href="https://registry.khronos.org/OpenXR/specs/1.0/man/html/XrInstance.html">XrInstance</a> created during the initialization of the OpenXR API.</para>
    /// </summary>
    public ulong GetInstance()
    {
        return NativeCalls.godot_icall_0_137(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemId, 2455072627ul);

    /// <summary>
    /// <para>Returns the ID of the system, which is an <a href="https://registry.khronos.org/OpenXR/specs/1.0/man/html/XrSystemId.html">XrSystemId</a> cast to an integer.</para>
    /// </summary>
    public ulong GetSystemId()
    {
        return NativeCalls.godot_icall_0_137(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSession, 2455072627ul);

    /// <summary>
    /// <para>Returns the OpenXR session, which is an <a href="https://registry.khronos.org/OpenXR/specs/1.0/man/html/XrSession.html">XrSession</a> cast to an integer.</para>
    /// </summary>
    public ulong GetSession()
    {
        return NativeCalls.godot_icall_0_137(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.XRResult, 3886436197ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the provided <a href="https://registry.khronos.org/OpenXR/specs/1.0/man/html/XrResult.html">XrResult</a> (cast to an integer) is successful. Otherwise returns <see langword="false"/> and prints the <a href="https://registry.khronos.org/OpenXR/specs/1.0/man/html/XrResult.html">XrResult</a> converted to a string, with the specified additional information.</para>
    /// </summary>
    public bool XRResult(ulong result, string format, Godot.Collections.Array args)
    {
        return NativeCalls.godot_icall_3_924(MethodBind4, GodotObject.GetPtr(this), result, format, (godot_array)(args ?? new()).NativeValue).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenxrIsEnabled, 2703660260ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if OpenXR is enabled.</para>
    /// </summary>
    public static bool OpenxrIsEnabled(bool checkRunInEditor)
    {
        return NativeCalls.godot_icall_1_925(MethodBind5, checkRunInEditor.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceProcAddr, 1597066294ul);

    /// <summary>
    /// <para>Returns the function pointer of the OpenXR function with the specified name, cast to an integer. If the function with the given name does not exist, the method returns <c>0</c>.</para>
    /// <para><b>Note:</b> <c>openxr/util.h</c> contains utility macros for acquiring OpenXR functions, e.g. <c>GDEXTENSION_INIT_XR_FUNC_V(xrCreateAction)</c>.</para>
    /// </summary>
    public ulong GetInstanceProcAddr(string name)
    {
        return NativeCalls.godot_icall_1_926(MethodBind6, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetErrorString, 990163283ul);

    /// <summary>
    /// <para>Returns an error string for the given <a href="https://registry.khronos.org/OpenXR/specs/1.0/man/html/XrResult.html">XrResult</a>.</para>
    /// </summary>
    public string GetErrorString(ulong result)
    {
        return NativeCalls.godot_icall_1_927(MethodBind7, GodotObject.GetPtr(this), result);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSwapchainFormatName, 990163283ul);

    /// <summary>
    /// <para>Returns the name of the specified swapchain format.</para>
    /// </summary>
    public string GetSwapchainFormatName(long swapchainFormat)
    {
        return NativeCalls.godot_icall_1_908(MethodBind8, GodotObject.GetPtr(this), swapchainFormat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetObjectName, 2285447957ul);

    /// <summary>
    /// <para>Set the object name of an OpenXR object, used for debug output. <paramref name="objectType"/> must be a valid OpenXR <c>XrObjectType</c> enum and <paramref name="objectHandle"/> must be a valid OpenXR object handle.</para>
    /// </summary>
    public void SetObjectName(long objectType, ulong objectHandle, string objectName)
    {
        NativeCalls.godot_icall_3_928(MethodBind9, GodotObject.GetPtr(this), objectType, objectHandle, objectName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BeginDebugLabelRegion, 83702148ul);

    /// <summary>
    /// <para>Begins a new debug label region, this label will be reported in debug messages for any calls following this until <see cref="Godot.OpenXRApiExtension.EndDebugLabelRegion()"/> is called. Debug labels can be stacked.</para>
    /// </summary>
    public void BeginDebugLabelRegion(string labelName)
    {
        NativeCalls.godot_icall_1_57(MethodBind10, GodotObject.GetPtr(this), labelName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EndDebugLabelRegion, 3218959716ul);

    /// <summary>
    /// <para>Marks the end of a debug label region. Removes the latest debug label region added by calling <see cref="Godot.OpenXRApiExtension.BeginDebugLabelRegion(string)"/>.</para>
    /// </summary>
    public void EndDebugLabelRegion()
    {
        NativeCalls.godot_icall_0_3(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InsertDebugLabel, 83702148ul);

    /// <summary>
    /// <para>Inserts a debug label, this label is reported in any debug message resulting from the OpenXR calls that follows, until any of <see cref="Godot.OpenXRApiExtension.BeginDebugLabelRegion(string)"/>, <see cref="Godot.OpenXRApiExtension.EndDebugLabelRegion()"/>, or <see cref="Godot.OpenXRApiExtension.InsertDebugLabel(string)"/> is called.</para>
    /// </summary>
    public void InsertDebugLabel(string labelName)
    {
        NativeCalls.godot_icall_1_57(MethodBind12, GodotObject.GetPtr(this), labelName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInitialized, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if OpenXR is initialized.</para>
    /// </summary>
    public bool IsInitialized()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRunning, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if OpenXR is running (<a href="https://registry.khronos.org/OpenXR/specs/1.0/man/html/xrBeginSession.html">xrBeginSession</a> was successfully called and the swapchains were created).</para>
    /// </summary>
    public bool IsRunning()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaySpace, 2455072627ul);

    /// <summary>
    /// <para>Returns the play space, which is an <a href="https://registry.khronos.org/OpenXR/specs/1.0/man/html/XrSpace.html">XrSpace</a> cast to an integer.</para>
    /// </summary>
    public ulong GetPlaySpace()
    {
        return NativeCalls.godot_icall_0_137(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPredictedDisplayTime, 2455072627ul);

    /// <summary>
    /// <para>Returns the predicted display timing for the current frame.</para>
    /// </summary>
    public long GetPredictedDisplayTime()
    {
        return NativeCalls.godot_icall_0_4(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextFrameTime, 2455072627ul);

    /// <summary>
    /// <para>Returns the predicted display timing for the next frame.</para>
    /// </summary>
    public long GetNextFrameTime()
    {
        return NativeCalls.godot_icall_0_4(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanRender, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if OpenXR is initialized for rendering with an XR viewport.</para>
    /// </summary>
    public bool CanRender()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindAction, 4106179378ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> corresponding to an <c>Action</c> of a matching name, optionally limited to a specified action set.</para>
    /// </summary>
    public Rid FindAction(string name, Rid actionSet)
    {
        return NativeCalls.godot_icall_2_929(MethodBind19, GodotObject.GetPtr(this), name, actionSet);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ActionGetHandle, 3917799429ul);

    /// <summary>
    /// <para>Returns the corresponding <c>XrAction</c> OpenXR handle for the given action RID.</para>
    /// </summary>
    public ulong ActionGetHandle(Rid action)
    {
        return NativeCalls.godot_icall_1_853(MethodBind20, GodotObject.GetPtr(this), action);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandTracker, 3744713108ul);

    /// <summary>
    /// <para>Returns the corresponding <c>XRHandTrackerEXT</c> handle for the given hand index value.</para>
    /// </summary>
    public ulong GetHandTracker(int handIndex)
    {
        return NativeCalls.godot_icall_1_240(MethodBind21, GodotObject.GetPtr(this), handIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterCompositionLayerProvider, 1477360496ul);

    /// <summary>
    /// <para>Registers the given extension as a composition layer provider.</para>
    /// <para><b>Note:</b> This cannot be called after the OpenXR session has started. However, it can be called in <see cref="Godot.OpenXRExtensionWrapper._OnSessionCreated(ulong)"/>.</para>
    /// </summary>
    public void RegisterCompositionLayerProvider(OpenXRExtensionWrapper extension)
    {
        NativeCalls.godot_icall_1_56(MethodBind22, GodotObject.GetPtr(this), GodotObject.GetPtr(extension));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnregisterCompositionLayerProvider, 1477360496ul);

    /// <summary>
    /// <para>Unregisters the given extension as a composition layer provider.</para>
    /// <para><b>Note:</b> This cannot be called while the OpenXR session is still running.</para>
    /// </summary>
    public void UnregisterCompositionLayerProvider(OpenXRExtensionWrapper extension)
    {
        NativeCalls.godot_icall_1_56(MethodBind23, GodotObject.GetPtr(this), GodotObject.GetPtr(extension));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterProjectionViewsExtension, 1477360496ul);

    /// <summary>
    /// <para>Registers the given extension as a provider of additional data structures to projections views.</para>
    /// <para><b>Note:</b> This cannot be called after the OpenXR session has started. However, it can be called in <see cref="Godot.OpenXRExtensionWrapper._OnSessionCreated(ulong)"/>.</para>
    /// </summary>
    public void RegisterProjectionViewsExtension(OpenXRExtensionWrapper extension)
    {
        NativeCalls.godot_icall_1_56(MethodBind24, GodotObject.GetPtr(this), GodotObject.GetPtr(extension));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnregisterProjectionViewsExtension, 1477360496ul);

    /// <summary>
    /// <para>Unregisters the given extension as a provider of additional data structures to projections views.</para>
    /// <para><b>Note:</b> This cannot be called while the OpenXR session is still running.</para>
    /// </summary>
    public void UnregisterProjectionViewsExtension(OpenXRExtensionWrapper extension)
    {
        NativeCalls.godot_icall_1_56(MethodBind25, GodotObject.GetPtr(this), GodotObject.GetPtr(extension));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterFrameInfoExtension, 1477360496ul);

    /// <summary>
    /// <para>Registers the given extension as modifying frame info via the <c>OpenXRExtensionWrapper._set_frame_wait_info_and_get_next_pointer</c>, <c>OpenXRExtensionWrapper._set_view_locate_info_and_get_next_pointer</c>, or <c>OpenXRExtensionWrapper._set_frame_end_info_and_get_next_pointer</c> virtual methods.</para>
    /// <para><b>Note:</b> This cannot be called after the OpenXR session has started. However, it can be called in <see cref="Godot.OpenXRExtensionWrapper._OnSessionCreated(ulong)"/>.</para>
    /// </summary>
    public void RegisterFrameInfoExtension(OpenXRExtensionWrapper extension)
    {
        NativeCalls.godot_icall_1_56(MethodBind26, GodotObject.GetPtr(this), GodotObject.GetPtr(extension));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnregisterFrameInfoExtension, 1477360496ul);

    /// <summary>
    /// <para>Unregisters the given extension as modifying frame info.</para>
    /// <para><b>Note:</b> This cannot be called while the OpenXR session is still running.</para>
    /// </summary>
    public void UnregisterFrameInfoExtension(OpenXRExtensionWrapper extension)
    {
        NativeCalls.godot_icall_1_56(MethodBind27, GodotObject.GetPtr(this), GodotObject.GetPtr(extension));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderStateZNear, 191475506ul);

    /// <summary>
    /// <para>Returns the near boundary value of the camera frustum.</para>
    /// <para><b>Note:</b> This is only accessible in the render thread.</para>
    /// </summary>
    public double GetRenderStateZNear()
    {
        return NativeCalls.godot_icall_0_144(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderStateZFar, 191475506ul);

    /// <summary>
    /// <para>Returns the far boundary value of the camera frustum.</para>
    /// <para><b>Note:</b> This is only accessible in the render thread.</para>
    /// </summary>
    public double GetRenderStateZFar()
    {
        return NativeCalls.godot_icall_0_144(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVelocityTexture, 2722037293ul);

    /// <summary>
    /// <para>Sets the render target of the velocity texture.</para>
    /// </summary>
    public void SetVelocityTexture(Rid renderTarget)
    {
        NativeCalls.godot_icall_1_286(MethodBind30, GodotObject.GetPtr(this), renderTarget);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVelocityDepthTexture, 2722037293ul);

    /// <summary>
    /// <para>Sets the render target of the velocity depth texture.</para>
    /// </summary>
    public void SetVelocityDepthTexture(Rid renderTarget)
    {
        NativeCalls.godot_icall_1_286(MethodBind31, GodotObject.GetPtr(this), renderTarget);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVelocityTargetSize, 1130785943ul);

    /// <summary>
    /// <para>Sets the target size of the velocity and velocity depth textures.</para>
    /// </summary>
    public unsafe void SetVelocityTargetSize(Vector2I targetSize)
    {
        NativeCalls.godot_icall_1_34(MethodBind32, GodotObject.GetPtr(this), &targetSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportedSwapchainFormats, 3851388692ul);

    /// <summary>
    /// <para>Returns an array of supported swapchain formats.</para>
    /// </summary>
    public long[] GetSupportedSwapchainFormats()
    {
        return NativeCalls.godot_icall_0_13(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenxrSwapchainCreate, 2162228999ul);

    /// <summary>
    /// <para>Returns a pointer to a new swapchain created using the provided parameters.</para>
    /// </summary>
    public ulong OpenxrSwapchainCreate(ulong createFlags, ulong usageFlags, long swapchainFormat, uint width, uint height, uint sampleCount, uint arraySize)
    {
        return NativeCalls.godot_icall_7_930(MethodBind34, GodotObject.GetPtr(this), createFlags, usageFlags, swapchainFormat, width, height, sampleCount, arraySize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenxrSwapchainFree, 1286410249ul);

    /// <summary>
    /// <para>Destroys the provided swapchain and frees it from memory.</para>
    /// </summary>
    public void OpenxrSwapchainFree(ulong swapchain)
    {
        NativeCalls.godot_icall_1_544(MethodBind35, GodotObject.GetPtr(this), swapchain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenxrSwapchainGetSwapchain, 3744713108ul);

    /// <summary>
    /// <para>Returns the <c>XrSwapchain</c> handle of the provided swapchain.</para>
    /// </summary>
    public ulong OpenxrSwapchainGetSwapchain(ulong swapchain)
    {
        return NativeCalls.godot_icall_1_931(MethodBind36, GodotObject.GetPtr(this), swapchain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenxrSwapchainAcquire, 1286410249ul);

    /// <summary>
    /// <para>Acquires the image of the provided swapchain.</para>
    /// </summary>
    public void OpenxrSwapchainAcquire(ulong swapchain)
    {
        NativeCalls.godot_icall_1_544(MethodBind37, GodotObject.GetPtr(this), swapchain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenxrSwapchainGetImage, 937000113ul);

    /// <summary>
    /// <para>Returns the RID of the provided swapchain's image.</para>
    /// </summary>
    public Rid OpenxrSwapchainGetImage(ulong swapchain)
    {
        return NativeCalls.godot_icall_1_932(MethodBind38, GodotObject.GetPtr(this), swapchain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenxrSwapchainRelease, 1286410249ul);

    /// <summary>
    /// <para>Releases the image of the provided swapchain.</para>
    /// </summary>
    public void OpenxrSwapchainRelease(ulong swapchain)
    {
        NativeCalls.godot_icall_1_544(MethodBind39, GodotObject.GetPtr(this), swapchain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjectionLayer, 2455072627ul);

    /// <summary>
    /// <para>Returns a pointer to the render state's <c>XrCompositionLayerProjection</c> struct.</para>
    /// <para><b>Note:</b> This method should only be called from the rendering thread.</para>
    /// </summary>
    public ulong GetProjectionLayer()
    {
        return NativeCalls.godot_icall_0_137(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderRegion, 1763793166ul);

    /// <summary>
    /// <para>Sets the render region to <paramref name="renderRegion"/>, overriding the normal render target's rect.</para>
    /// </summary>
    public unsafe void SetRenderRegion(Rect2I renderRegion)
    {
        NativeCalls.godot_icall_1_32(MethodBind41, GodotObject.GetPtr(this), &renderRegion);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmulateEnvironmentBlendModeAlphaBlend, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, an OpenXR extension is loaded which is capable of emulating the <see cref="Godot.XRInterface.EnvironmentBlendModeEnum.AlphaBlend"/> blend mode.</para>
    /// </summary>
    public void SetEmulateEnvironmentBlendModeAlphaBlend(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind42, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEnvironmentBlendModeAlphaSupported, 1579290861ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.OpenXRApiExtension.OpenXRAlphaBlendModeSupport"/> denoting if <see cref="Godot.XRInterface.EnvironmentBlendModeEnum.AlphaBlend"/> is really supported, emulated or not supported at all.</para>
    /// </summary>
    public OpenXRApiExtension.OpenXRAlphaBlendModeSupport IsEnvironmentBlendModeAlphaSupported()
    {
        return (OpenXRApiExtension.OpenXRAlphaBlendModeSupport)NativeCalls.godot_icall_0_39(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateMainSwapchainSize, 3218959716ul);

    /// <summary>
    /// <para>Request the recommended resolution from the OpenXR runtime and update the main swapchain size if it has changed.</para>
    /// </summary>
    public void UpdateMainSwapchainSize()
    {
        NativeCalls.godot_icall_0_3(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnregisterProjectionViewsExtension, 1997997368ul);

    /// <summary>
    /// <para>Unregisters the given extension as a provider of additional data structures to projections views.</para>
    /// <para><b>Note:</b> This cannot be called while the OpenXR session is still running.</para>
    /// </summary>
    [Obsolete("This method overload is deprecated.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void UnregisterProjectionViewsExtension(OpenXRExtensionWrapperExtension extension)
    {
        NativeCalls.godot_icall_1_56(MethodBind45, GodotObject.GetPtr(this), GodotObject.GetPtr(extension));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterProjectionViewsExtension, 1997997368ul);

    /// <summary>
    /// <para>Registers the given extension as a provider of additional data structures to projections views.</para>
    /// <para><b>Note:</b> This cannot be called after the OpenXR session has started. However, it can be called in <see cref="Godot.OpenXRExtensionWrapper._OnSessionCreated(ulong)"/>.</para>
    /// </summary>
    [Obsolete("This method overload is deprecated.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void RegisterProjectionViewsExtension(OpenXRExtensionWrapperExtension extension)
    {
        NativeCalls.godot_icall_1_56(MethodBind46, GodotObject.GetPtr(this), GodotObject.GetPtr(extension));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnregisterCompositionLayerProvider, 1997997368ul);

    /// <summary>
    /// <para>Unregisters the given extension as a composition layer provider.</para>
    /// <para><b>Note:</b> This cannot be called while the OpenXR session is still running.</para>
    /// </summary>
    [Obsolete("This method overload is deprecated.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void UnregisterCompositionLayerProvider(OpenXRExtensionWrapperExtension extension)
    {
        NativeCalls.godot_icall_1_56(MethodBind47, GodotObject.GetPtr(this), GodotObject.GetPtr(extension));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterCompositionLayerProvider, 1997997368ul);

    /// <summary>
    /// <para>Registers the given extension as a composition layer provider.</para>
    /// <para><b>Note:</b> This cannot be called after the OpenXR session has started. However, it can be called in <see cref="Godot.OpenXRExtensionWrapper._OnSessionCreated(ulong)"/>.</para>
    /// </summary>
    [Obsolete("This method overload is deprecated.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void RegisterCompositionLayerProvider(OpenXRExtensionWrapperExtension extension)
    {
        NativeCalls.godot_icall_1_56(MethodBind48, GodotObject.GetPtr(this), GodotObject.GetPtr(extension));
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_openxr_version' method.
        /// </summary>
        public static readonly StringName GetOpenxrVersion = "get_openxr_version";
        /// <summary>
        /// Cached name for the 'get_instance' method.
        /// </summary>
        public static readonly StringName GetInstance = "get_instance";
        /// <summary>
        /// Cached name for the 'get_system_id' method.
        /// </summary>
        public static readonly StringName GetSystemId = "get_system_id";
        /// <summary>
        /// Cached name for the 'get_session' method.
        /// </summary>
        public static readonly StringName GetSession = "get_session";
        /// <summary>
        /// Cached name for the 'xr_result' method.
        /// </summary>
        public static readonly StringName XRResult = "xr_result";
        /// <summary>
        /// Cached name for the 'openxr_is_enabled' method.
        /// </summary>
        public static readonly StringName OpenxrIsEnabled = "openxr_is_enabled";
        /// <summary>
        /// Cached name for the 'get_instance_proc_addr' method.
        /// </summary>
        public static readonly StringName GetInstanceProcAddr = "get_instance_proc_addr";
        /// <summary>
        /// Cached name for the 'get_error_string' method.
        /// </summary>
        public static readonly StringName GetErrorString = "get_error_string";
        /// <summary>
        /// Cached name for the 'get_swapchain_format_name' method.
        /// </summary>
        public static readonly StringName GetSwapchainFormatName = "get_swapchain_format_name";
        /// <summary>
        /// Cached name for the 'set_object_name' method.
        /// </summary>
        public static readonly StringName SetObjectName = "set_object_name";
        /// <summary>
        /// Cached name for the 'begin_debug_label_region' method.
        /// </summary>
        public static readonly StringName BeginDebugLabelRegion = "begin_debug_label_region";
        /// <summary>
        /// Cached name for the 'end_debug_label_region' method.
        /// </summary>
        public static readonly StringName EndDebugLabelRegion = "end_debug_label_region";
        /// <summary>
        /// Cached name for the 'insert_debug_label' method.
        /// </summary>
        public static readonly StringName InsertDebugLabel = "insert_debug_label";
        /// <summary>
        /// Cached name for the 'is_initialized' method.
        /// </summary>
        public static readonly StringName IsInitialized = "is_initialized";
        /// <summary>
        /// Cached name for the 'is_running' method.
        /// </summary>
        public static readonly StringName IsRunning = "is_running";
        /// <summary>
        /// Cached name for the 'get_play_space' method.
        /// </summary>
        public static readonly StringName GetPlaySpace = "get_play_space";
        /// <summary>
        /// Cached name for the 'get_predicted_display_time' method.
        /// </summary>
        public static readonly StringName GetPredictedDisplayTime = "get_predicted_display_time";
        /// <summary>
        /// Cached name for the 'get_next_frame_time' method.
        /// </summary>
        public static readonly StringName GetNextFrameTime = "get_next_frame_time";
        /// <summary>
        /// Cached name for the 'can_render' method.
        /// </summary>
        public static readonly StringName CanRender = "can_render";
        /// <summary>
        /// Cached name for the 'find_action' method.
        /// </summary>
        public static readonly StringName FindAction = "find_action";
        /// <summary>
        /// Cached name for the 'action_get_handle' method.
        /// </summary>
        public static readonly StringName ActionGetHandle = "action_get_handle";
        /// <summary>
        /// Cached name for the 'get_hand_tracker' method.
        /// </summary>
        public static readonly StringName GetHandTracker = "get_hand_tracker";
        /// <summary>
        /// Cached name for the 'register_composition_layer_provider' method.
        /// </summary>
        public static readonly StringName RegisterCompositionLayerProvider = "register_composition_layer_provider";
        /// <summary>
        /// Cached name for the 'unregister_composition_layer_provider' method.
        /// </summary>
        public static readonly StringName UnregisterCompositionLayerProvider = "unregister_composition_layer_provider";
        /// <summary>
        /// Cached name for the 'register_projection_views_extension' method.
        /// </summary>
        public static readonly StringName RegisterProjectionViewsExtension = "register_projection_views_extension";
        /// <summary>
        /// Cached name for the 'unregister_projection_views_extension' method.
        /// </summary>
        public static readonly StringName UnregisterProjectionViewsExtension = "unregister_projection_views_extension";
        /// <summary>
        /// Cached name for the 'register_frame_info_extension' method.
        /// </summary>
        public static readonly StringName RegisterFrameInfoExtension = "register_frame_info_extension";
        /// <summary>
        /// Cached name for the 'unregister_frame_info_extension' method.
        /// </summary>
        public static readonly StringName UnregisterFrameInfoExtension = "unregister_frame_info_extension";
        /// <summary>
        /// Cached name for the 'get_render_state_z_near' method.
        /// </summary>
        public static readonly StringName GetRenderStateZNear = "get_render_state_z_near";
        /// <summary>
        /// Cached name for the 'get_render_state_z_far' method.
        /// </summary>
        public static readonly StringName GetRenderStateZFar = "get_render_state_z_far";
        /// <summary>
        /// Cached name for the 'set_velocity_texture' method.
        /// </summary>
        public static readonly StringName SetVelocityTexture = "set_velocity_texture";
        /// <summary>
        /// Cached name for the 'set_velocity_depth_texture' method.
        /// </summary>
        public static readonly StringName SetVelocityDepthTexture = "set_velocity_depth_texture";
        /// <summary>
        /// Cached name for the 'set_velocity_target_size' method.
        /// </summary>
        public static readonly StringName SetVelocityTargetSize = "set_velocity_target_size";
        /// <summary>
        /// Cached name for the 'get_supported_swapchain_formats' method.
        /// </summary>
        public static readonly StringName GetSupportedSwapchainFormats = "get_supported_swapchain_formats";
        /// <summary>
        /// Cached name for the 'openxr_swapchain_create' method.
        /// </summary>
        public static readonly StringName OpenxrSwapchainCreate = "openxr_swapchain_create";
        /// <summary>
        /// Cached name for the 'openxr_swapchain_free' method.
        /// </summary>
        public static readonly StringName OpenxrSwapchainFree = "openxr_swapchain_free";
        /// <summary>
        /// Cached name for the 'openxr_swapchain_get_swapchain' method.
        /// </summary>
        public static readonly StringName OpenxrSwapchainGetSwapchain = "openxr_swapchain_get_swapchain";
        /// <summary>
        /// Cached name for the 'openxr_swapchain_acquire' method.
        /// </summary>
        public static readonly StringName OpenxrSwapchainAcquire = "openxr_swapchain_acquire";
        /// <summary>
        /// Cached name for the 'openxr_swapchain_get_image' method.
        /// </summary>
        public static readonly StringName OpenxrSwapchainGetImage = "openxr_swapchain_get_image";
        /// <summary>
        /// Cached name for the 'openxr_swapchain_release' method.
        /// </summary>
        public static readonly StringName OpenxrSwapchainRelease = "openxr_swapchain_release";
        /// <summary>
        /// Cached name for the 'get_projection_layer' method.
        /// </summary>
        public static readonly StringName GetProjectionLayer = "get_projection_layer";
        /// <summary>
        /// Cached name for the 'set_render_region' method.
        /// </summary>
        public static readonly StringName SetRenderRegion = "set_render_region";
        /// <summary>
        /// Cached name for the 'set_emulate_environment_blend_mode_alpha_blend' method.
        /// </summary>
        public static readonly StringName SetEmulateEnvironmentBlendModeAlphaBlend = "set_emulate_environment_blend_mode_alpha_blend";
        /// <summary>
        /// Cached name for the 'is_environment_blend_mode_alpha_supported' method.
        /// </summary>
        public static readonly StringName IsEnvironmentBlendModeAlphaSupported = "is_environment_blend_mode_alpha_supported";
        /// <summary>
        /// Cached name for the 'update_main_swapchain_size' method.
        /// </summary>
        public static readonly StringName UpdateMainSwapchainSize = "update_main_swapchain_size";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
