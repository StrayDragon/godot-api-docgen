namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Configuration header for April tag markers. Pass this to <see cref="Godot.OpenXRSpatialEntityExtension.CreateSpatialContext(Godot.Collections.Array{OpenXRSpatialCapabilityConfigurationBaseHeader}, OpenXRStructureBase, Callable)"/> to create a spatial context that can detect April tags.</para>
/// </summary>
public partial class OpenXRSpatialCapabilityConfigurationAprilTag : OpenXRSpatialCapabilityConfigurationBaseHeader
{
    public enum AprilTagDict : long
    {
        /// <summary>
        /// <para>4 by 4 bits, minimum Hamming distance between any two codes = 5, 30 codes.</para>
        /// </summary>
        Dict16H5 = 1,
        /// <summary>
        /// <para>5 by 5 bits, minimum Hamming distance between any two codes = 9, 35 codes.</para>
        /// </summary>
        Dict25H9 = 2,
        /// <summary>
        /// <para> 6 by 6 bits, minimum Hamming distance between any two codes = 10, 2320 codes.</para>
        /// </summary>
        Dict36H10 = 3,
        /// <summary>
        /// <para>6 by 6 bits, minimum Hamming distance between any two codes = 11, 587 codes.</para>
        /// </summary>
        Dict36H11 = 4
    }

    /// <summary>
    /// <para>Dictionary to use to decode April tags.</para>
    /// <para><b>Note:</b> Must be set before using this configuration to create a spatial context.</para>
    /// </summary>
    public OpenXRSpatialCapabilityConfigurationAprilTag.AprilTagDict AprilDict
    {
        get
        {
            return GetAprilDict();
        }
        set
        {
            SetAprilDict(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRSpatialCapabilityConfigurationAprilTag);

    private static readonly StringName NativeName = "OpenXRSpatialCapabilityConfigurationAprilTag";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialCapabilityConfigurationAprilTag() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialCapabilityConfigurationAprilTag(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialCapabilityConfigurationAprilTag(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAprilDict, 3902905799ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAprilDict(OpenXRSpatialCapabilityConfigurationAprilTag.AprilTagDict aprilDict)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), (int)aprilDict);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAprilDict, 440273016ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRSpatialCapabilityConfigurationAprilTag.AprilTagDict GetAprilDict()
    {
        return (OpenXRSpatialCapabilityConfigurationAprilTag.AprilTagDict)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
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
        /// Cached name for the 'april_dict' property.
        /// </summary>
        public static readonly StringName AprilDict = "april_dict";
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
        /// Cached name for the 'set_april_dict' method.
        /// </summary>
        public static readonly StringName SetAprilDict = "set_april_dict";
        /// <summary>
        /// Cached name for the 'get_april_dict' method.
        /// </summary>
        public static readonly StringName GetAprilDict = "get_april_dict";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRSpatialCapabilityConfigurationBaseHeader.SignalName
    {
    }
}
