namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class handles the OpenXR marker tracking spatial entity extension.</para>
/// </summary>
public partial class OpenXRSpatialMarkerTrackingCapability : OpenXRExtensionWrapper
{
    private static readonly System.Type CachedType = typeof(OpenXRSpatialMarkerTrackingCapability);

    private static readonly StringName NativeName = "OpenXRSpatialMarkerTrackingCapability";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialMarkerTrackingCapability() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRSpatialMarkerTrackingCapability(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRSpatialMarkerTrackingCapability(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsQrcodeSupported, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if QR code marker tracking is supported by the current device.</para>
    /// </summary>
    public bool IsQrcodeSupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMicroQrcodeSupported, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if micro QR code marker tracking is supported by the current device.</para>
    /// </summary>
    public bool IsMicroQrcodeSupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsArucoSupported, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if Aruco marker tracking is supported by the current device.</para>
    /// </summary>
    public bool IsArucoSupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAprilTagSupported, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if April tag marker tracking is supported by the current device.</para>
    /// </summary>
    public bool IsAprilTagSupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : OpenXRExtensionWrapper.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRExtensionWrapper.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_qrcode_supported' method.
        /// </summary>
        public static readonly StringName IsQrcodeSupported = "is_qrcode_supported";
        /// <summary>
        /// Cached name for the 'is_micro_qrcode_supported' method.
        /// </summary>
        public static readonly StringName IsMicroQrcodeSupported = "is_micro_qrcode_supported";
        /// <summary>
        /// Cached name for the 'is_aruco_supported' method.
        /// </summary>
        public static readonly StringName IsArucoSupported = "is_aruco_supported";
        /// <summary>
        /// Cached name for the 'is_april_tag_supported' method.
        /// </summary>
        public static readonly StringName IsAprilTagSupported = "is_april_tag_supported";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRExtensionWrapper.SignalName
    {
    }
}
