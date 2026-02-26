namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>These are trackers created and managed by OpenXR's spatial entity extensions that give access to specific data related to OpenXR's spatial entities. They will always be of type <c>TRACKER_ANCHOR</c>.</para>
/// </summary>
public partial class OpenXRSpatialEntityTracker : XRPositionalTracker
{
    public enum EntityTrackingState : long
    {
        /// <summary>
        /// <para>This anchor has stopped tracking.</para>
        /// </summary>
        Stopped = 1,
        /// <summary>
        /// <para>Tracking is currently paused.</para>
        /// </summary>
        Paused = 2,
        /// <summary>
        /// <para>This anchor is currently being tracked.</para>
        /// </summary>
        Tracking = 3
    }

    /// <summary>
    /// <para>The spatial entity associated with this tracker.</para>
    /// </summary>
    public Rid Entity
    {
        get
        {
            return GetEntity();
        }
        set
        {
            SetEntity(value);
        }
    }

    /// <summary>
    /// <para>The spatial tracking state for this tracker.</para>
    /// </summary>
    public OpenXRSpatialEntityTracker.EntityTrackingState SpatialTrackingState
    {
        get
        {
            return GetSpatialTrackingState();
        }
        set
        {
            SetSpatialTrackingState(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRSpatialEntityTracker);

    private static readonly StringName NativeName = "OpenXRSpatialEntityTracker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialEntityTracker() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialEntityTracker(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialEntityTracker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEntity, 2722037293ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEntity(Rid entity)
    {
        NativeCalls.godot_icall_1_286(MethodBind0, GodotObject.GetPtr(this), entity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEntity, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetEntity()
    {
        return NativeCalls.godot_icall_0_238(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpatialTrackingState, 2170234447ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpatialTrackingState(OpenXRSpatialEntityTracker.EntityTrackingState spatialTrackingState)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)spatialTrackingState);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpatialTrackingState, 3351876560ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRSpatialEntityTracker.EntityTrackingState GetSpatialTrackingState()
    {
        return (OpenXRSpatialEntityTracker.EntityTrackingState)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRSpatialEntityTracker.SpatialTrackingStateChanged"/> event of a <see cref="Godot.OpenXRSpatialEntityTracker"/> class.
    /// </summary>
    public delegate void SpatialTrackingStateChangedEventHandler(long spatialTrackingState);

    private static void SpatialTrackingStateChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SpatialTrackingStateChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    public unsafe event SpatialTrackingStateChangedEventHandler SpatialTrackingStateChanged
    {
        add => Connect(SignalName.SpatialTrackingStateChanged, Callable.CreateWithUnsafeTrampoline(value, &SpatialTrackingStateChangedTrampoline));
        remove => Disconnect(SignalName.SpatialTrackingStateChanged, Callable.CreateWithUnsafeTrampoline(value, &SpatialTrackingStateChangedTrampoline));
    }

    protected void EmitSignalSpatialTrackingStateChanged(long spatialTrackingState)
    {
        EmitSignal(SignalName.SpatialTrackingStateChanged, spatialTrackingState);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_spatial_tracking_state_changed = "SpatialTrackingStateChanged";

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
        if (signal == SignalName.SpatialTrackingStateChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_spatial_tracking_state_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : XRPositionalTracker.PropertyName
    {
        /// <summary>
        /// Cached name for the 'entity' property.
        /// </summary>
        public static readonly StringName Entity = "entity";
        /// <summary>
        /// Cached name for the 'spatial_tracking_state' property.
        /// </summary>
        public static readonly StringName SpatialTrackingState = "spatial_tracking_state";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : XRPositionalTracker.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_entity' method.
        /// </summary>
        public static readonly StringName SetEntity = "set_entity";
        /// <summary>
        /// Cached name for the 'get_entity' method.
        /// </summary>
        public static readonly StringName GetEntity = "get_entity";
        /// <summary>
        /// Cached name for the 'set_spatial_tracking_state' method.
        /// </summary>
        public static readonly StringName SetSpatialTrackingState = "set_spatial_tracking_state";
        /// <summary>
        /// Cached name for the 'get_spatial_tracking_state' method.
        /// </summary>
        public static readonly StringName GetSpatialTrackingState = "get_spatial_tracking_state";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : XRPositionalTracker.SignalName
    {
        /// <summary>
        /// Cached name for the 'spatial_tracking_state_changed' signal.
        /// </summary>
        public static readonly StringName SpatialTrackingStateChanged = "spatial_tracking_state_changed";
    }
}
