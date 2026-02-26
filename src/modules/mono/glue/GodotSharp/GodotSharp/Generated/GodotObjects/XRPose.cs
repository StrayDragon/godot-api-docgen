namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>XR runtimes often identify multiple locations on devices such as controllers that are spatially tracked.</para>
/// <para>Orientation, location, linear velocity and angular velocity are all provided for each pose by the XR runtime. This object contains this state of a pose.</para>
/// </summary>
public partial class XRPose : RefCounted
{
    public enum TrackingConfidenceEnum : long
    {
        /// <summary>
        /// <para>No tracking information is available for this pose.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Tracking information may be inaccurate or estimated. For example, with inside out tracking this would indicate a controller may be (partially) obscured.</para>
        /// </summary>
        Low = 1,
        /// <summary>
        /// <para>Tracking information is considered accurate and up to date.</para>
        /// </summary>
        High = 2
    }

    /// <summary>
    /// <para>If <see langword="true"/> our tracking data is up to date. If <see langword="false"/> we're no longer receiving new tracking data and our state is whatever that last valid state was.</para>
    /// </summary>
    public bool HasTrackingData
    {
        get
        {
            return GetHasTrackingData();
        }
        set
        {
            SetHasTrackingData(value);
        }
    }

    /// <summary>
    /// <para>The name of this pose. Usually, this name is derived from an action map set up by the user. Godot also suggests some pose names that <see cref="Godot.XRInterface"/> objects are expected to implement:</para>
    /// <para>- <c>root</c> is the root location, often used for tracked objects that do not have further nodes.</para>
    /// <para>- <c>aim</c> is the tip of a controller with its orientation pointing outwards, often used for raycasts.</para>
    /// <para>- <c>grip</c> is the location where the user grips the controller.</para>
    /// <para>- <c>skeleton</c> is the root location for a hand mesh, when using hand tracking and an animated skeleton is supplied by the XR runtime.</para>
    /// </summary>
    public StringName Name
    {
        get
        {
            return GetName();
        }
        set
        {
            SetName(value);
        }
    }

    /// <summary>
    /// <para>The transform containing the original and transform as reported by the XR runtime.</para>
    /// </summary>
    public Transform3D Transform
    {
        get
        {
            return GetTransform();
        }
        set
        {
            SetTransform(value);
        }
    }

    /// <summary>
    /// <para>The linear velocity of this pose.</para>
    /// </summary>
    public Vector3 LinearVelocity
    {
        get
        {
            return GetLinearVelocity();
        }
        set
        {
            SetLinearVelocity(value);
        }
    }

    /// <summary>
    /// <para>The angular velocity for this pose.</para>
    /// </summary>
    public Vector3 AngularVelocity
    {
        get
        {
            return GetAngularVelocity();
        }
        set
        {
            SetAngularVelocity(value);
        }
    }

    /// <summary>
    /// <para>The tracking confidence for this pose, provides insight on how accurate the spatial positioning of this record is.</para>
    /// </summary>
    public XRPose.TrackingConfidenceEnum TrackingConfidence
    {
        get
        {
            return GetTrackingConfidence();
        }
        set
        {
            SetTrackingConfidence(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XRPose);

    private static readonly StringName NativeName = "XRPose";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRPose() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRPose(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRPose(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHasTrackingData, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHasTrackingData(bool hasTrackingData)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), hasTrackingData.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHasTrackingData, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetHasTrackingData()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetName, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetName(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetName, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransform, 2952846383ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTransform(Transform3D transform)
    {
        NativeCalls.godot_icall_1_648(MethodBind4, GodotObject.GetPtr(this), &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransform, 3229777777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform3D GetTransform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdjustedTransform, 3229777777ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.XRPose.Transform"/> with world scale and our reference frame applied. This is the transform used to position <see cref="Godot.XRNode3D"/> objects.</para>
    /// </summary>
    public Transform3D GetAdjustedTransform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearVelocity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetLinearVelocity(Vector3 velocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind7, GodotObject.GetPtr(this), &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearVelocity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetLinearVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularVelocity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAngularVelocity(Vector3 velocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind9, GodotObject.GetPtr(this), &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularVelocity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetAngularVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrackingConfidence, 4171656666ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTrackingConfidence(XRPose.TrackingConfidenceEnum trackingConfidence)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), (int)trackingConfidence);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackingConfidence, 2064923680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRPose.TrackingConfidenceEnum GetTrackingConfidence()
    {
        return (XRPose.TrackingConfidenceEnum)NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
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
        /// Cached name for the 'has_tracking_data' property.
        /// </summary>
        public static readonly StringName HasTrackingData = "has_tracking_data";
        /// <summary>
        /// Cached name for the 'name' property.
        /// </summary>
        public static readonly StringName Name = "name";
        /// <summary>
        /// Cached name for the 'transform' property.
        /// </summary>
        public static readonly StringName Transform = "transform";
        /// <summary>
        /// Cached name for the 'linear_velocity' property.
        /// </summary>
        public static readonly StringName LinearVelocity = "linear_velocity";
        /// <summary>
        /// Cached name for the 'angular_velocity' property.
        /// </summary>
        public static readonly StringName AngularVelocity = "angular_velocity";
        /// <summary>
        /// Cached name for the 'tracking_confidence' property.
        /// </summary>
        public static readonly StringName TrackingConfidence = "tracking_confidence";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_has_tracking_data' method.
        /// </summary>
        public static readonly StringName SetHasTrackingData = "set_has_tracking_data";
        /// <summary>
        /// Cached name for the 'get_has_tracking_data' method.
        /// </summary>
        public static readonly StringName GetHasTrackingData = "get_has_tracking_data";
        /// <summary>
        /// Cached name for the 'set_name' method.
        /// </summary>
        public static readonly StringName SetName = "set_name";
        /// <summary>
        /// Cached name for the 'get_name' method.
        /// </summary>
        public static readonly StringName GetName = "get_name";
        /// <summary>
        /// Cached name for the 'set_transform' method.
        /// </summary>
        public static readonly StringName SetTransform = "set_transform";
        /// <summary>
        /// Cached name for the 'get_transform' method.
        /// </summary>
        public static readonly StringName GetTransform = "get_transform";
        /// <summary>
        /// Cached name for the 'get_adjusted_transform' method.
        /// </summary>
        public static readonly StringName GetAdjustedTransform = "get_adjusted_transform";
        /// <summary>
        /// Cached name for the 'set_linear_velocity' method.
        /// </summary>
        public static readonly StringName SetLinearVelocity = "set_linear_velocity";
        /// <summary>
        /// Cached name for the 'get_linear_velocity' method.
        /// </summary>
        public static readonly StringName GetLinearVelocity = "get_linear_velocity";
        /// <summary>
        /// Cached name for the 'set_angular_velocity' method.
        /// </summary>
        public static readonly StringName SetAngularVelocity = "set_angular_velocity";
        /// <summary>
        /// Cached name for the 'get_angular_velocity' method.
        /// </summary>
        public static readonly StringName GetAngularVelocity = "get_angular_velocity";
        /// <summary>
        /// Cached name for the 'set_tracking_confidence' method.
        /// </summary>
        public static readonly StringName SetTrackingConfidence = "set_tracking_confidence";
        /// <summary>
        /// Cached name for the 'get_tracking_confidence' method.
        /// </summary>
        public static readonly StringName GetTrackingConfidence = "get_tracking_confidence";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
