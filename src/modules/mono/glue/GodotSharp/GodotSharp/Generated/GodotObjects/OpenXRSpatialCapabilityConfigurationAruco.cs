namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Configuration header for Aruco markers. Pass this to <see cref="Godot.OpenXRSpatialEntityExtension.CreateSpatialContext(Godot.Collections.Array{OpenXRSpatialCapabilityConfigurationBaseHeader}, OpenXRStructureBase, Callable)"/> to create a spatial context that can detect Aruco markers.</para>
/// </summary>
public partial class OpenXRSpatialCapabilityConfigurationAruco : OpenXRSpatialCapabilityConfigurationBaseHeader
{
    public enum ArucoDictEnum : long
    {
        /// <summary>
        /// <para>4 by 4 pixel Aruco marker dictionary with 50 IDs.</para>
        /// </summary>
        Dict4X450 = 1,
        /// <summary>
        /// <para>4 by 4 pixel Aruco marker dictionary with 100 IDs.</para>
        /// </summary>
        Dict4X4100 = 2,
        /// <summary>
        /// <para>4 by 4 pixel Aruco marker dictionary with 250 IDs.</para>
        /// </summary>
        Dict4X4250 = 3,
        /// <summary>
        /// <para>4 by 4 pixel Aruco marker dictionary with 1000 IDs.</para>
        /// </summary>
        Dict4X41000 = 4,
        /// <summary>
        /// <para>5 by 5 pixel Aruco marker dictionary with 50 IDs.</para>
        /// </summary>
        Dict5X550 = 5,
        /// <summary>
        /// <para>5 by 5 pixel Aruco marker dictionary with 100 IDs.</para>
        /// </summary>
        Dict5X5100 = 6,
        /// <summary>
        /// <para>5 by 5 pixel Aruco marker dictionary with 250 IDs.</para>
        /// </summary>
        Dict5X5250 = 7,
        /// <summary>
        /// <para>5 by 5 pixel Aruco marker dictionary with 1000 IDs.</para>
        /// </summary>
        Dict5X51000 = 8,
        /// <summary>
        /// <para>6 by 6 pixel Aruco marker dictionary with 50 IDs.</para>
        /// </summary>
        Dict6X650 = 9,
        /// <summary>
        /// <para>6 by 6 pixel Aruco marker dictionary with 100 IDs.</para>
        /// </summary>
        Dict6X6100 = 10,
        /// <summary>
        /// <para>6 by 6 pixel Aruco marker dictionary with 250 IDs.</para>
        /// </summary>
        Dict6X6250 = 11,
        /// <summary>
        /// <para>6 by 6 pixel Aruco marker dictionary with 1000 IDs.</para>
        /// </summary>
        Dict6X61000 = 12,
        /// <summary>
        /// <para>7 by 7 pixel Aruco marker dictionary with 50 IDs.</para>
        /// </summary>
        Dict7X750 = 13,
        /// <summary>
        /// <para>7 by 7 pixel Aruco marker dictionary with 100 IDs.</para>
        /// </summary>
        Dict7X7100 = 14,
        /// <summary>
        /// <para>7 by 7 pixel Aruco marker dictionary with 250 IDs.</para>
        /// </summary>
        Dict7X7250 = 15,
        /// <summary>
        /// <para>7 by 7 pixel Aruco marker dictionary with 1000 IDs.</para>
        /// </summary>
        Dict7X71000 = 16
    }

    /// <summary>
    /// <para>Dictionary to use to decode Aruco markers.</para>
    /// <para><b>Note:</b> Must be set before using this configuration to create a spatial context.</para>
    /// </summary>
    public OpenXRSpatialCapabilityConfigurationAruco.ArucoDictEnum ArucoDict
    {
        get
        {
            return GetArucoDict();
        }
        set
        {
            SetArucoDict(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRSpatialCapabilityConfigurationAruco);

    private static readonly StringName NativeName = "OpenXRSpatialCapabilityConfigurationAruco";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialCapabilityConfigurationAruco() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialCapabilityConfigurationAruco(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialCapabilityConfigurationAruco(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnabledComponents, 235988956ul);

    /// <summary>
    /// <para>Returns the components enabled by this configuration.</para>
    /// <para><b>Note:</b> Only valid after this configuration was used to create a spatial context.</para>
    /// </summary>
    public long[] GetEnabledComponents()
    {
        return NativeCalls.godot_icall_0_13(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetArucoDict, 2268055963ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetArucoDict(OpenXRSpatialCapabilityConfigurationAruco.ArucoDictEnum arucoDict)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), (int)arucoDict);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetArucoDict, 1080386209ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRSpatialCapabilityConfigurationAruco.ArucoDictEnum GetArucoDict()
    {
        return (OpenXRSpatialCapabilityConfigurationAruco.ArucoDictEnum)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
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
        /// <summary>
        /// Cached name for the 'aruco_dict' property.
        /// </summary>
        public static readonly StringName ArucoDict = "aruco_dict";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRSpatialCapabilityConfigurationBaseHeader.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_enabled_components' method.
        /// </summary>
        public static readonly StringName GetEnabledComponents = "get_enabled_components";
        /// <summary>
        /// Cached name for the 'set_aruco_dict' method.
        /// </summary>
        public static readonly StringName SetArucoDict = "set_aruco_dict";
        /// <summary>
        /// Cached name for the 'get_aruco_dict' method.
        /// </summary>
        public static readonly StringName GetArucoDict = "get_aruco_dict";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRSpatialCapabilityConfigurationBaseHeader.SignalName
    {
    }
}
