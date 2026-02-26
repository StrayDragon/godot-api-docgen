namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Spatial entity tracker for our OpenXR spatial entity marker tracking extension. These trackers identify entities in our real space detected by a visual marker such as a QRCode or Aruco code, and map their location to our virtual space.</para>
/// </summary>
public partial class OpenXRMarkerTracker : OpenXRSpatialEntityTracker
{
    /// <summary>
    /// <para>The bounds size for this marker.</para>
    /// </summary>
    public Vector2 BoundsSize
    {
        get
        {
            return GetBoundsSize();
        }
        set
        {
            SetBoundsSize(value);
        }
    }

    /// <summary>
    /// <para>The type of marker.</para>
    /// </summary>
    public OpenXRSpatialComponentMarkerList.MarkerType MarkerType
    {
        get
        {
            return GetMarkerType();
        }
        set
        {
            SetMarkerType(value);
        }
    }

    /// <summary>
    /// <para>The marker ID for this marker, this is only returned for Aruco and April Tag markers. Call <see cref="Godot.OpenXRMarkerTracker.GetMarkerData()"/> for QRCode markers.</para>
    /// </summary>
    public uint MarkerId
    {
        get
        {
            return GetMarkerId();
        }
        set
        {
            SetMarkerId(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRMarkerTracker);

    private static readonly StringName NativeName = "OpenXRMarkerTracker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRMarkerTracker() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRMarkerTracker(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRMarkerTracker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoundsSize, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBoundsSize(Vector2 boundsSize)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &boundsSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoundsSize, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetBoundsSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMarkerType, 2156241362ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMarkerType(OpenXRSpatialComponentMarkerList.MarkerType markerType)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)markerType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMarkerType, 612702862ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRSpatialComponentMarkerList.MarkerType GetMarkerType()
    {
        return (OpenXRSpatialComponentMarkerList.MarkerType)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMarkerId, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMarkerId(uint markerId)
    {
        NativeCalls.godot_icall_1_208(MethodBind4, GodotObject.GetPtr(this), markerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMarkerId, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetMarkerId()
    {
        return NativeCalls.godot_icall_0_209(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMarkerData, 1114965689ul);

    /// <summary>
    /// <para>Sets the marker data for this marker.</para>
    /// <para><b>Note:</b> This should only be set by marker discovery logic.</para>
    /// </summary>
    public void SetMarkerData(Variant markerData)
    {
        NativeCalls.godot_icall_1_773(MethodBind6, GodotObject.GetPtr(this), markerData);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMarkerData, 1214101251ul);

    /// <summary>
    /// <para>Returns the marker data for this marker. This can return a <see cref="string"/> or <see cref="byte"/>[]. Only applicable to QR Code based markers.</para>
    /// </summary>
    public Variant GetMarkerData()
    {
        return NativeCalls.godot_icall_0_772(MethodBind7, GodotObject.GetPtr(this));
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
    public new class PropertyName : OpenXRSpatialEntityTracker.PropertyName
    {
        /// <summary>
        /// Cached name for the 'bounds_size' property.
        /// </summary>
        public static readonly StringName BoundsSize = "bounds_size";
        /// <summary>
        /// Cached name for the 'marker_type' property.
        /// </summary>
        public static readonly StringName MarkerType = "marker_type";
        /// <summary>
        /// Cached name for the 'marker_id' property.
        /// </summary>
        public static readonly StringName MarkerId = "marker_id";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRSpatialEntityTracker.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_bounds_size' method.
        /// </summary>
        public static readonly StringName SetBoundsSize = "set_bounds_size";
        /// <summary>
        /// Cached name for the 'get_bounds_size' method.
        /// </summary>
        public static readonly StringName GetBoundsSize = "get_bounds_size";
        /// <summary>
        /// Cached name for the 'set_marker_type' method.
        /// </summary>
        public static readonly StringName SetMarkerType = "set_marker_type";
        /// <summary>
        /// Cached name for the 'get_marker_type' method.
        /// </summary>
        public static readonly StringName GetMarkerType = "get_marker_type";
        /// <summary>
        /// Cached name for the 'set_marker_id' method.
        /// </summary>
        public static readonly StringName SetMarkerId = "set_marker_id";
        /// <summary>
        /// Cached name for the 'get_marker_id' method.
        /// </summary>
        public static readonly StringName GetMarkerId = "get_marker_id";
        /// <summary>
        /// Cached name for the 'set_marker_data' method.
        /// </summary>
        public static readonly StringName SetMarkerData = "set_marker_data";
        /// <summary>
        /// Cached name for the 'get_marker_data' method.
        /// </summary>
        public static readonly StringName GetMarkerData = "get_marker_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRSpatialEntityTracker.SignalName
    {
    }
}
