namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Object for storing the queries marker result data when calling <see cref="Godot.OpenXRSpatialEntityExtension.QuerySnapshot(Rid, Godot.Collections.Array{OpenXRSpatialComponentData}, OpenXRStructureBase)"/>.</para>
/// </summary>
public partial class OpenXRSpatialComponentMarkerList : OpenXRSpatialComponentData
{
    public enum MarkerType : long
    {
        /// <summary>
        /// <para>Unknown or unset marker type.</para>
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// <para>Marker based on a QR code.</para>
        /// </summary>
        Qrcode = 1,
        /// <summary>
        /// <para>Marker based on a micro QR code.</para>
        /// </summary>
        MicroQrcode = 2,
        /// <summary>
        /// <para>Marker based on an Aruco code.</para>
        /// </summary>
        Aruco = 3,
        /// <summary>
        /// <para>Marker based on an April Tag.</para>
        /// </summary>
        AprilTag = 4,
        /// <summary>
        /// <para>Maximum value for this enum.</para>
        /// </summary>
        Max = 5
    }

    private static readonly System.Type CachedType = typeof(OpenXRSpatialComponentMarkerList);

    private static readonly StringName NativeName = "OpenXRSpatialComponentMarkerList";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialComponentMarkerList() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialComponentMarkerList(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialComponentMarkerList(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMarkerType, 2627847866ul);

    /// <summary>
    /// <para>Returns the marker type for the marker at this <paramref name="index"/>.</para>
    /// </summary>
    public OpenXRSpatialComponentMarkerList.MarkerType GetMarkerType(long index)
    {
        return (OpenXRSpatialComponentMarkerList.MarkerType)NativeCalls.godot_icall_1_562(MethodBind0, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMarkerId, 923996154ul);

    /// <summary>
    /// <para>Returns the marker ID for the marker at this <paramref name="index"/>. Only applicable for Aruco or April Tag markers.</para>
    /// </summary>
    public uint GetMarkerId(long index)
    {
        return NativeCalls.godot_icall_1_948(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMarkerData, 4069510997ul);

    /// <summary>
    /// <para>Returns either a <see cref="string"/> or a <see cref="byte"/>[] buffer with data for the marker at this <paramref name="index"/>. Only applicable for QR code markers.</para>
    /// </summary>
    public Variant GetMarkerData(Rid snapshot, long index)
    {
        return NativeCalls.godot_icall_2_949(MethodBind2, GodotObject.GetPtr(this), snapshot, index);
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
    public new class PropertyName : OpenXRSpatialComponentData.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRSpatialComponentData.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_marker_type' method.
        /// </summary>
        public static readonly StringName GetMarkerType = "get_marker_type";
        /// <summary>
        /// Cached name for the 'get_marker_id' method.
        /// </summary>
        public static readonly StringName GetMarkerId = "get_marker_id";
        /// <summary>
        /// Cached name for the 'get_marker_data' method.
        /// </summary>
        public static readonly StringName GetMarkerData = "get_marker_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRSpatialComponentData.SignalName
    {
    }
}
