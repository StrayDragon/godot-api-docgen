namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Wrapper base class for OpenXR Spatial Capability Configuration headers. This class needs to be implemented for each capability configuration structure usable within OpenXR's spatial entities system.</para>
/// </summary>
public partial class OpenXRSpatialCapabilityConfigurationBaseHeader : RefCounted
{
    private static readonly System.Type CachedType = typeof(OpenXRSpatialCapabilityConfigurationBaseHeader);

    private static readonly StringName NativeName = "OpenXRSpatialCapabilityConfigurationBaseHeader";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialCapabilityConfigurationBaseHeader() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialCapabilityConfigurationBaseHeader(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialCapabilityConfigurationBaseHeader(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Return a pointer (encoded as an <c>int64_t</c>) to a struct holding the spatial capability configuration data. The memory for this struct should remain accessible as long as this object remains instantiated.</para>
    /// </summary>
    public virtual ulong _GetConfiguration()
    {
        return default;
    }

    /// <summary>
    /// <para>Return <see langword="true"/> if this object contains a valid configuration that can be retrieved when calling <see cref="Godot.OpenXRSpatialCapabilityConfigurationBaseHeader._GetConfiguration()"/>.</para>
    /// </summary>
    public virtual bool _HasValidConfiguration()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasValidConfiguration, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this object contains a valid configuration that can be used when calling <see cref="Godot.OpenXRSpatialEntityExtension.CreateSpatialContext(Godot.Collections.Array{OpenXRSpatialCapabilityConfigurationBaseHeader}, OpenXRStructureBase, Callable)"/>.</para>
    /// </summary>
    public bool HasValidConfiguration()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_configuration = "_GetConfiguration";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_valid_configuration = "_HasValidConfiguration";

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
        if ((method == MethodProxyName__get_configuration || method == MethodName._GetConfiguration) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_configuration.NativeValue))
        {
            var callRet = _GetConfiguration();
            ret = VariantUtils.CreateFrom<ulong>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_valid_configuration || method == MethodName._HasValidConfiguration) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_valid_configuration.NativeValue))
        {
            var callRet = _HasValidConfiguration();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
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
        if (method == MethodName._GetConfiguration)
        {
            if (HasGodotClassMethod(MethodProxyName__get_configuration.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasValidConfiguration)
        {
            if (HasGodotClassMethod(MethodProxyName__has_valid_configuration.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the '_get_configuration' method.
        /// </summary>
        public static readonly StringName _GetConfiguration = "_get_configuration";
        /// <summary>
        /// Cached name for the '_has_valid_configuration' method.
        /// </summary>
        public static readonly StringName _HasValidConfiguration = "_has_valid_configuration";
        /// <summary>
        /// Cached name for the 'has_valid_configuration' method.
        /// </summary>
        public static readonly StringName HasValidConfiguration = "has_valid_configuration";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
