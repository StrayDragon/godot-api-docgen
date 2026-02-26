namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>OpenXR extension that handles spatial entities and, when enabled, allows querying those spatial entities. This extension will also automatically manage <see cref="Godot.XRTracker"/> objects for static entities.</para>
/// </summary>
public partial class OpenXRSpatialEntityExtension : OpenXRExtensionWrapper
{
    public enum Capability : long
    {
        /// <summary>
        /// <para>Plane tracking capability.</para>
        /// </summary>
        PlaneTracking = 1000741000,
        /// <summary>
        /// <para>QR code based marker tracking capability.</para>
        /// </summary>
        MarkerTrackingQrCode = 1000743000,
        /// <summary>
        /// <para>Micro QR code based marker tracking capability.</para>
        /// </summary>
        MarkerTrackingMicroQrCode = 1000743001,
        /// <summary>
        /// <para>Aruco marker based marker tracking capability.</para>
        /// </summary>
        MarkerTrackingArucoMarker = 1000743002,
        /// <summary>
        /// <para>April tag based marker tracking capability.</para>
        /// </summary>
        MarkerTrackingAprilTag = 1000743003,
        /// <summary>
        /// <para>Anchor capability.</para>
        /// </summary>
        Anchor = 1000762000
    }

    public enum ComponentType : long
    {
        /// <summary>
        /// <para>Component that provides the 2D bounds for a spatial entity. The corresponding list structure is <c>XrSpatialComponentBounded2DListEXT</c>; the corresponding data structure is <c>XrSpatialBounded2DDataEXT</c>.</para>
        /// </summary>
        Bounded2D = 1,
        /// <summary>
        /// <para>Component that provides the 3D bounds for a spatial entity. The corresponding list structure is <c>XrSpatialComponentBounded3DListEXT</c>; the corresponding data structure is <c>XrBoxf</c>.</para>
        /// </summary>
        Bounded3D = 2,
        /// <summary>
        /// <para>Component that provides the XrSpatialEntityIdEXT of the parent for a spatial entity. The corresponding list structure is <c>XrSpatialComponentParentListEXT</c>; the corresponding data structure is <c>XrSpatialEntityIdEXT</c>.</para>
        /// </summary>
        Parent = 3,
        /// <summary>
        /// <para>Component that provides a 3D mesh for a spatial entity. The corresponding list structure is <c>XrSpatialComponentMesh3DListEXT</c>; the corresponding data structure is <c>XrSpatialMeshDataEXT</c>.</para>
        /// </summary>
        Mesh3D = 4,
        /// <summary>
        /// <para>Component that provides the plane alignment enum for a spatial entity. The corresponding list structure is <c>XrSpatialComponentPlaneAlignmentListEXT</c>; the corresponding data structure is <c>XrSpatialPlaneAlignmentEXT</c> (Added by the <c>XR_EXT_spatial_plane_tracking</c> extension).</para>
        /// </summary>
        PlaneAlignment = 1000741000,
        /// <summary>
        /// <para>Component that provides a 2D mesh for a spatial entity. The corresponding list structure is <c>XrSpatialComponentMesh2DListEXT</c>; the corresponding data structure is <c>XrSpatialMeshDataEXT</c> (Added by the <c>XR_EXT_spatial_plane_tracking</c> extension).</para>
        /// </summary>
        Mesh2D = 1000741001,
        /// <summary>
        /// <para>Component that provides a 2D boundary polygon for a spatial entity. The corresponding list structure is <c>XrSpatialComponentPolygon2DListEXT</c>; the corresponding data structure is <c>XrSpatialPolygon2DDataEXT</c> (Added by the <c>XR_EXT_spatial_plane_tracking</c> extension).</para>
        /// </summary>
        Polygon2D = 1000741002,
        /// <summary>
        /// <para>Component that provides a semantic label for a plane. The corresponding list structure is <c>XrSpatialComponentPlaneSemanticLabelListEXT</c>; the corresponding data structure is <c>XrSpatialPlaneSemanticLabelEXT</c> (Added by the <c>XR_EXT_spatial_plane_tracking</c> extension).</para>
        /// </summary>
        PlaneSemanticLabel = 1000741003,
        /// <summary>
        /// <para>A component describing the marker type, ID and location. The corresponding list structure is <c>XrSpatialComponentMarkerListEXT</c>; the corresponding data structure is <c>XrSpatialMarkerDataEXT</c> (Added by the <c>XR_EXT_spatial_marker_tracking</c> extension).</para>
        /// </summary>
        Marker = 1000743000,
        /// <summary>
        /// <para>Component that provides the location for an anchor. The corresponding list structure is <c>XrSpatialComponentAnchorListEXT</c>; the corresponding data structure is <c>XrPosef</c> (Added by the <c>XR_EXT_spatial_anchor</c> extension).</para>
        /// </summary>
        Anchor = 1000762000,
        /// <summary>
        /// <para>Component that provides the persisted UUID for a spatial entity. The corresponding list structure is <c>XrSpatialComponentPersistenceListEXT; the corresponding data structure is [code]XrSpatialPersistenceDataEXT</c> (Added by the <c>XR_EXT_spatial_persistence</c> extension).</para>
        /// </summary>
        Persistence = 1000763000
    }

    private static readonly System.Type CachedType = typeof(OpenXRSpatialEntityExtension);

    private static readonly StringName NativeName = "OpenXRSpatialEntityExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialEntityExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRSpatialEntityExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRSpatialEntityExtension(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SupportsCapability, 1940837202ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this spatial entity <paramref name="capability"/> is supported by the hardware used.</para>
    /// </summary>
    public bool SupportsCapability(OpenXRSpatialEntityExtension.Capability capability)
    {
        return NativeCalls.godot_icall_1_62(MethodBind0, GodotObject.GetPtr(this), (int)capability).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SupportsComponentType, 26842779ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this <paramref name="capability"/> supports the <paramref name="componentType"/>.</para>
    /// </summary>
    public bool SupportsComponentType(OpenXRSpatialEntityExtension.Capability capability, OpenXRSpatialEntityExtension.ComponentType componentType)
    {
        return NativeCalls.godot_icall_2_40(MethodBind1, GodotObject.GetPtr(this), (int)capability, (int)componentType).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateSpatialContext, 1874506473ul);

    /// <summary>
    /// <para>Creates a new spatial context that handles entities for the provided capability configurations. <paramref name="capabilityConfigurations"/> is an array of <see cref="Godot.OpenXRSpatialCapabilityConfigurationBaseHeader"/> with the needed capability configuration data.</para>
    /// <para><paramref name="next"/> is an optional parameter that can contain additional information for creating our spatial context.</para>
    /// <para><b>Note:</b> This is an asynchronous method and returns an <see cref="Godot.OpenXRFutureResult"/> object with which to track the status, discarding this object will not cancel the creation process. On success <paramref name="userCallback"/> will be called if specified. The result data for this function is the <see cref="Godot.Rid"/> for our spatial context.</para>
    /// </summary>
    public OpenXRFutureResult CreateSpatialContext(Godot.Collections.Array<OpenXRSpatialCapabilityConfigurationBaseHeader> capabilityConfigurations, OpenXRStructureBase next = default, Callable userCallback = default)
    {
        return (OpenXRFutureResult)NativeCalls.godot_icall_3_955(MethodBind2, GodotObject.GetPtr(this), (godot_array)(capabilityConfigurations ?? new()).NativeValue, GodotObject.GetPtr(next), userCallback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpatialContextReady, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the spatial context finished its creation and is ready to be used.</para>
    /// </summary>
    public bool GetSpatialContextReady(Rid spatialContext)
    {
        return NativeCalls.godot_icall_1_421(MethodBind3, GodotObject.GetPtr(this), spatialContext).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeSpatialContext, 2722037293ul);

    /// <summary>
    /// <para>Frees a spatial context previously created when calling <see cref="Godot.OpenXRSpatialEntityExtension.CreateSpatialContext(Godot.Collections.Array{OpenXRSpatialCapabilityConfigurationBaseHeader}, OpenXRStructureBase, Callable)"/>. If the spatial context creation is still ongoing, the asynchronous process is cancelled.</para>
    /// </summary>
    public void FreeSpatialContext(Rid spatialContext)
    {
        NativeCalls.godot_icall_1_286(MethodBind4, GodotObject.GetPtr(this), spatialContext);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpatialContextHandle, 2198884583ul);

    /// <summary>
    /// <para>Returns the OpenXR spatial context handle for this snapshot.</para>
    /// <para><b>Note:</b> This method is intended to be used from GDExtensions that implement spatial entity capability handlers.</para>
    /// </summary>
    public ulong GetSpatialContextHandle(Rid spatialContext)
    {
        return NativeCalls.godot_icall_1_853(MethodBind5, GodotObject.GetPtr(this), spatialContext);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DiscoverSpatialEntities, 2252833536ul);

    /// <summary>
    /// <para>Starts a new discovery query, this will gather all objects tracked by the <paramref name="spatialContext"/> that have at least one of the component types specified in <paramref name="componentTypes"/>.</para>
    /// <para><paramref name="next"/> is an optional parameter that can contain additional information for executing the discovery query.</para>
    /// <para><b>Note:</b> This is an asynchronous method and returns an <see cref="Godot.OpenXRFutureResult"/> object with which to track the status, discarding this object will not cancel the discovery process. On success <paramref name="userCallback"/> will be called if specified. The result data for this function is the <see cref="Godot.Rid"/> for our snapshot.</para>
    /// </summary>
    public OpenXRFutureResult DiscoverSpatialEntities(Rid spatialContext, long[] componentTypes, OpenXRStructureBase next = default, Callable userCallback = default)
    {
        return (OpenXRFutureResult)NativeCalls.godot_icall_4_956(MethodBind6, GodotObject.GetPtr(this), spatialContext, componentTypes, GodotObject.GetPtr(next), userCallback);
    }

    /// <summary>
    /// <para>Starts a new discovery query, this will gather all objects tracked by the <paramref name="spatialContext"/> that have at least one of the component types specified in <paramref name="componentTypes"/>.</para>
    /// <para><paramref name="next"/> is an optional parameter that can contain additional information for executing the discovery query.</para>
    /// <para><b>Note:</b> This is an asynchronous method and returns an <see cref="Godot.OpenXRFutureResult"/> object with which to track the status, discarding this object will not cancel the discovery process. On success <paramref name="userCallback"/> will be called if specified. The result data for this function is the <see cref="Godot.Rid"/> for our snapshot.</para>
    /// </summary>
    public OpenXRFutureResult DiscoverSpatialEntities(Rid spatialContext, ReadOnlySpan<long> componentTypes, OpenXRStructureBase next, Callable userCallback)
    {
        return (OpenXRFutureResult)NativeCalls.godot_icall_4_956(MethodBind6, GodotObject.GetPtr(this), spatialContext, componentTypes, GodotObject.GetPtr(next), userCallback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateSpatialEntities, 3446086438ul);

    /// <summary>
    /// <para>Performs a snapshot for a limited number of entities. This is NOT an asynchronous method and will return the snapshot immediately.</para>
    /// </summary>
    public Rid UpdateSpatialEntities(Rid spatialContext, Godot.Collections.Array<Rid> entities, long[] componentTypes, OpenXRStructureBase next = default)
    {
        return NativeCalls.godot_icall_4_957(MethodBind7, GodotObject.GetPtr(this), spatialContext, (godot_array)(entities ?? new()).NativeValue, componentTypes, GodotObject.GetPtr(next));
    }

    /// <summary>
    /// <para>Performs a snapshot for a limited number of entities. This is NOT an asynchronous method and will return the snapshot immediately.</para>
    /// </summary>
    public Rid UpdateSpatialEntities(Rid spatialContext, Godot.Collections.Array<Rid> entities, ReadOnlySpan<long> componentTypes, OpenXRStructureBase next)
    {
        return NativeCalls.godot_icall_4_957(MethodBind7, GodotObject.GetPtr(this), spatialContext, (godot_array)(entities ?? new()).NativeValue, componentTypes, GodotObject.GetPtr(next));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeSpatialSnapshot, 2722037293ul);

    /// <summary>
    /// <para>Frees a spatial snapshot previously created when calling <see cref="Godot.OpenXRSpatialEntityExtension.DiscoverSpatialEntities(Rid, long[], OpenXRStructureBase, Callable)"/>. If the spatial snapshot creation is still ongoing, the asynchronous process is cancelled.</para>
    /// </summary>
    public void FreeSpatialSnapshot(Rid spatialSnapshot)
    {
        NativeCalls.godot_icall_1_286(MethodBind8, GodotObject.GetPtr(this), spatialSnapshot);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpatialSnapshotHandle, 2198884583ul);

    /// <summary>
    /// <para>Returns the OpenXR spatial snapshot handle for this snapshot.</para>
    /// <para><b>Note:</b> This method is intended to be used from GDExtensions that implement spatial entity capability handlers.</para>
    /// </summary>
    public ulong GetSpatialSnapshotHandle(Rid spatialSnapshot)
    {
        return NativeCalls.godot_icall_1_853(MethodBind9, GodotObject.GetPtr(this), spatialSnapshot);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpatialSnapshotContext, 3814569979ul);

    /// <summary>
    /// <para>Returns the spatial context related to this spatial snapshot.</para>
    /// </summary>
    public Rid GetSpatialSnapshotContext(Rid spatialSnapshot)
    {
        return NativeCalls.godot_icall_1_855(MethodBind10, GodotObject.GetPtr(this), spatialSnapshot);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QuerySnapshot, 641015484ul);

    /// <summary>
    /// <para>Queries the snapshot data. This will find all entities in the snapshot that contain all requested components in <paramref name="componentData"/>. The objects held within <paramref name="componentData"/> will then be populated with the queried data. <paramref name="componentData"/> must always have an object of <see cref="Godot.OpenXRSpatialQueryResultData"/> as the first entry.</para>
    /// <para><paramref name="next"/> is an optional parameter that can contain additional information passed when setting our query conditions.</para>
    /// </summary>
    public bool QuerySnapshot(Rid spatialSnapshot, Godot.Collections.Array<OpenXRSpatialComponentData> componentData, OpenXRStructureBase next = default)
    {
        return NativeCalls.godot_icall_3_958(MethodBind11, GodotObject.GetPtr(this), spatialSnapshot, (godot_array)(componentData ?? new()).NativeValue, GodotObject.GetPtr(next)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetString, 1464764419ul);

    /// <summary>
    /// <para>Returns a string from a buffer that was retrieved when taking a snapshot.</para>
    /// </summary>
    public string GetString(Rid spatialSnapshot, ulong bufferId)
    {
        return NativeCalls.godot_icall_2_959(MethodBind12, GodotObject.GetPtr(this), spatialSnapshot, bufferId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUint8Buffer, 3570600051ul);

    /// <summary>
    /// <para>Returns a buffer with 8 bit ints from a buffer that was retrieved when taking a snapshot.</para>
    /// </summary>
    public byte[] GetUint8Buffer(Rid spatialSnapshot, ulong bufferId)
    {
        return NativeCalls.godot_icall_2_960(MethodBind13, GodotObject.GetPtr(this), spatialSnapshot, bufferId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUint16Buffer, 3393655756ul);

    /// <summary>
    /// <para>Returns a buffer with 16 bit ints from a buffer that was retrieved when taking a snapshot.</para>
    /// </summary>
    public int[] GetUint16Buffer(Rid spatialSnapshot, ulong bufferId)
    {
        return NativeCalls.godot_icall_2_961(MethodBind14, GodotObject.GetPtr(this), spatialSnapshot, bufferId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUint32Buffer, 3393655756ul);

    /// <summary>
    /// <para>Returns a buffer with 32 bit ints from a buffer that was retrieved when taking a snapshot.</para>
    /// </summary>
    public int[] GetUint32Buffer(Rid spatialSnapshot, ulong bufferId)
    {
        return NativeCalls.godot_icall_2_961(MethodBind15, GodotObject.GetPtr(this), spatialSnapshot, bufferId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFloatBuffer, 2313216651ul);

    /// <summary>
    /// <para>Returns a buffer with floats from a buffer that was retrieved when taking a snapshot.</para>
    /// </summary>
    public float[] GetFloatBuffer(Rid spatialSnapshot, ulong bufferId)
    {
        return NativeCalls.godot_icall_2_962(MethodBind16, GodotObject.GetPtr(this), spatialSnapshot, bufferId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVector2Buffer, 110850971ul);

    /// <summary>
    /// <para>Returns a buffer with <see cref="Godot.Vector2"/> entries from a buffer that was retrieved when taking a snapshot.</para>
    /// </summary>
    public Vector2[] GetVector2Buffer(Rid spatialSnapshot, ulong bufferId)
    {
        return NativeCalls.godot_icall_2_963(MethodBind17, GodotObject.GetPtr(this), spatialSnapshot, bufferId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVector3Buffer, 1166453791ul);

    /// <summary>
    /// <para>Returns a buffer with <see cref="Godot.Vector3"/> entries from a buffer that was retrieved when taking a snapshot.</para>
    /// </summary>
    public Vector3[] GetVector3Buffer(Rid spatialSnapshot, ulong bufferId)
    {
        return NativeCalls.godot_icall_2_964(MethodBind18, GodotObject.GetPtr(this), spatialSnapshot, bufferId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindSpatialEntity, 937000113ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> for the specified spatial entity ID.</para>
    /// </summary>
    public Rid FindSpatialEntity(ulong entityId)
    {
        return NativeCalls.godot_icall_1_932(MethodBind19, GodotObject.GetPtr(this), entityId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSpatialEntity, 2256026069ul);

    /// <summary>
    /// <para>Registers an entity that was created directly on the OpenXR runtime.</para>
    /// </summary>
    public Rid AddSpatialEntity(Rid spatialContext, ulong entityId, ulong entity)
    {
        return NativeCalls.godot_icall_3_965(MethodBind20, GodotObject.GetPtr(this), spatialContext, entityId, entity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeSpatialEntity, 2233757277ul);

    /// <summary>
    /// <para>Creates a new entity for this <paramref name="entityId"/>. The <paramref name="spatialContext"/> should match the context that discovered the entity.</para>
    /// </summary>
    public Rid MakeSpatialEntity(Rid spatialContext, ulong entityId)
    {
        return NativeCalls.godot_icall_2_966(MethodBind21, GodotObject.GetPtr(this), spatialContext, entityId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpatialEntityId, 2198884583ul);

    /// <summary>
    /// <para>Returns the internal <c>XrSpatialEntityIdEXT</c> associated with the entity.</para>
    /// </summary>
    public ulong GetSpatialEntityId(Rid entity)
    {
        return NativeCalls.godot_icall_1_853(MethodBind22, GodotObject.GetPtr(this), entity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpatialEntityContext, 3814569979ul);

    /// <summary>
    /// <para>Returns the spatial context for this entity.</para>
    /// </summary>
    public Rid GetSpatialEntityContext(Rid entity)
    {
        return NativeCalls.godot_icall_1_855(MethodBind23, GodotObject.GetPtr(this), entity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeSpatialEntity, 2722037293ul);

    /// <summary>
    /// <para>Frees an entity previously created when calling <see cref="Godot.OpenXRSpatialEntityExtension.AddSpatialEntity(Rid, ulong, ulong)"/> or <see cref="Godot.OpenXRSpatialEntityExtension.MakeSpatialEntity(Rid, ulong)"/>.</para>
    /// </summary>
    public void FreeSpatialEntity(Rid entity)
    {
        NativeCalls.godot_icall_1_286(MethodBind24, GodotObject.GetPtr(this), entity);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRSpatialEntityExtension.SpatialDiscoveryRecommended"/> event of a <see cref="Godot.OpenXRSpatialEntityExtension"/> class.
    /// </summary>
    public delegate void SpatialDiscoveryRecommendedEventHandler(Rid spatialContext);

    private static void SpatialDiscoveryRecommendedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SpatialDiscoveryRecommendedEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when OpenXR recommends running a discovery query because entities managed by this spatial context have (likely) changed.</para>
    /// </summary>
    public unsafe event SpatialDiscoveryRecommendedEventHandler SpatialDiscoveryRecommended
    {
        add => Connect(SignalName.SpatialDiscoveryRecommended, Callable.CreateWithUnsafeTrampoline(value, &SpatialDiscoveryRecommendedTrampoline));
        remove => Disconnect(SignalName.SpatialDiscoveryRecommended, Callable.CreateWithUnsafeTrampoline(value, &SpatialDiscoveryRecommendedTrampoline));
    }

    protected void EmitSignalSpatialDiscoveryRecommended(Rid spatialContext)
    {
        EmitSignal(SignalName.SpatialDiscoveryRecommended, spatialContext);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_spatial_discovery_recommended = "SpatialDiscoveryRecommended";

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
        if (signal == SignalName.SpatialDiscoveryRecommended)
        {
            if (HasGodotClassSignal(SignalProxyName_spatial_discovery_recommended.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the 'supports_capability' method.
        /// </summary>
        public static readonly StringName SupportsCapability = "supports_capability";
        /// <summary>
        /// Cached name for the 'supports_component_type' method.
        /// </summary>
        public static readonly StringName SupportsComponentType = "supports_component_type";
        /// <summary>
        /// Cached name for the 'create_spatial_context' method.
        /// </summary>
        public static readonly StringName CreateSpatialContext = "create_spatial_context";
        /// <summary>
        /// Cached name for the 'get_spatial_context_ready' method.
        /// </summary>
        public static readonly StringName GetSpatialContextReady = "get_spatial_context_ready";
        /// <summary>
        /// Cached name for the 'free_spatial_context' method.
        /// </summary>
        public static readonly StringName FreeSpatialContext = "free_spatial_context";
        /// <summary>
        /// Cached name for the 'get_spatial_context_handle' method.
        /// </summary>
        public static readonly StringName GetSpatialContextHandle = "get_spatial_context_handle";
        /// <summary>
        /// Cached name for the 'discover_spatial_entities' method.
        /// </summary>
        public static readonly StringName DiscoverSpatialEntities = "discover_spatial_entities";
        /// <summary>
        /// Cached name for the 'update_spatial_entities' method.
        /// </summary>
        public static readonly StringName UpdateSpatialEntities = "update_spatial_entities";
        /// <summary>
        /// Cached name for the 'free_spatial_snapshot' method.
        /// </summary>
        public static readonly StringName FreeSpatialSnapshot = "free_spatial_snapshot";
        /// <summary>
        /// Cached name for the 'get_spatial_snapshot_handle' method.
        /// </summary>
        public static readonly StringName GetSpatialSnapshotHandle = "get_spatial_snapshot_handle";
        /// <summary>
        /// Cached name for the 'get_spatial_snapshot_context' method.
        /// </summary>
        public static readonly StringName GetSpatialSnapshotContext = "get_spatial_snapshot_context";
        /// <summary>
        /// Cached name for the 'query_snapshot' method.
        /// </summary>
        public static readonly StringName QuerySnapshot = "query_snapshot";
        /// <summary>
        /// Cached name for the 'get_string' method.
        /// </summary>
        public static readonly StringName GetString = "get_string";
        /// <summary>
        /// Cached name for the 'get_uint8_buffer' method.
        /// </summary>
        public static readonly StringName GetUint8Buffer = "get_uint8_buffer";
        /// <summary>
        /// Cached name for the 'get_uint16_buffer' method.
        /// </summary>
        public static readonly StringName GetUint16Buffer = "get_uint16_buffer";
        /// <summary>
        /// Cached name for the 'get_uint32_buffer' method.
        /// </summary>
        public static readonly StringName GetUint32Buffer = "get_uint32_buffer";
        /// <summary>
        /// Cached name for the 'get_float_buffer' method.
        /// </summary>
        public static readonly StringName GetFloatBuffer = "get_float_buffer";
        /// <summary>
        /// Cached name for the 'get_vector2_buffer' method.
        /// </summary>
        public static readonly StringName GetVector2Buffer = "get_vector2_buffer";
        /// <summary>
        /// Cached name for the 'get_vector3_buffer' method.
        /// </summary>
        public static readonly StringName GetVector3Buffer = "get_vector3_buffer";
        /// <summary>
        /// Cached name for the 'find_spatial_entity' method.
        /// </summary>
        public static readonly StringName FindSpatialEntity = "find_spatial_entity";
        /// <summary>
        /// Cached name for the 'add_spatial_entity' method.
        /// </summary>
        public static readonly StringName AddSpatialEntity = "add_spatial_entity";
        /// <summary>
        /// Cached name for the 'make_spatial_entity' method.
        /// </summary>
        public static readonly StringName MakeSpatialEntity = "make_spatial_entity";
        /// <summary>
        /// Cached name for the 'get_spatial_entity_id' method.
        /// </summary>
        public static readonly StringName GetSpatialEntityId = "get_spatial_entity_id";
        /// <summary>
        /// Cached name for the 'get_spatial_entity_context' method.
        /// </summary>
        public static readonly StringName GetSpatialEntityContext = "get_spatial_entity_context";
        /// <summary>
        /// Cached name for the 'free_spatial_entity' method.
        /// </summary>
        public static readonly StringName FreeSpatialEntity = "free_spatial_entity";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRExtensionWrapper.SignalName
    {
        /// <summary>
        /// Cached name for the 'spatial_discovery_recommended' signal.
        /// </summary>
        public static readonly StringName SpatialDiscoveryRecommended = "spatial_discovery_recommended";
    }
}
