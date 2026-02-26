namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Configuration header for plane tracking. Pass this to <see cref="Godot.OpenXRSpatialEntityExtension.CreateSpatialContext(Godot.Collections.Array{OpenXRSpatialCapabilityConfigurationBaseHeader}, OpenXRStructureBase, Callable)"/> to create a spatial context with plane tracking capabilities.</para>
/// </summary>
public partial class OpenXRSpatialCapabilityConfigurationPlaneTracking : OpenXRSpatialCapabilityConfigurationBaseHeader
{
    private static readonly System.Type CachedType = typeof(OpenXRSpatialCapabilityConfigurationPlaneTracking);

    private static readonly StringName NativeName = "OpenXRSpatialCapabilityConfigurationPlaneTracking";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialCapabilityConfigurationPlaneTracking() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialCapabilityConfigurationPlaneTracking(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialCapabilityConfigurationPlaneTracking(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SupportsMesh2D, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if we support the mesh 2D component (only valid after the OpenXR session has started). You can query these using the <see cref="Godot.OpenXRSpatialComponentMesh2DList"/> data object.</para>
    /// </summary>
    public bool SupportsMesh2D()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SupportsPolygons, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if we support the polygon 2D component (only valid after the OpenXR session has started). You can query these using the <see cref="Godot.OpenXRSpatialComponentPolygon2DList"/> data object.</para>
    /// </summary>
    public bool SupportsPolygons()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SupportsLabels, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if we support the plane semantic label component (only valid after the OpenXR session has started). You can query these using the <see cref="Godot.OpenXRSpatialComponentPlaneSemanticLabelList"/> data object.</para>
    /// </summary>
    public bool SupportsLabels()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnabledComponents, 235988956ul);

    /// <summary>
    /// <para>Returns the components enabled by this configuration.</para>
    /// <para><b>Note:</b> Only valid after this configuration was used to create a spatial context.</para>
    /// </summary>
    public long[] GetEnabledComponents()
    {
        return NativeCalls.godot_icall_0_13(MethodBind3, GodotObject.GetPtr(this));
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
    public new class PropertyName : OpenXRSpatialCapabilityConfigurationBaseHeader.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRSpatialCapabilityConfigurationBaseHeader.MethodName
    {
        /// <summary>
        /// Cached name for the 'supports_mesh_2d' method.
        /// </summary>
        public static readonly StringName SupportsMesh2D = "supports_mesh_2d";
        /// <summary>
        /// Cached name for the 'supports_polygons' method.
        /// </summary>
        public static readonly StringName SupportsPolygons = "supports_polygons";
        /// <summary>
        /// Cached name for the 'supports_labels' method.
        /// </summary>
        public static readonly StringName SupportsLabels = "supports_labels";
        /// <summary>
        /// Cached name for the 'get_enabled_components' method.
        /// </summary>
        public static readonly StringName GetEnabledComponents = "get_enabled_components";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRSpatialCapabilityConfigurationBaseHeader.SignalName
    {
    }
}
