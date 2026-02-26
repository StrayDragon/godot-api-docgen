namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Configuration header for spatial persistence. Pass this to <see cref="Godot.OpenXRSpatialEntityExtension.CreateSpatialContext(Godot.Collections.Array{OpenXRSpatialCapabilityConfigurationBaseHeader}, OpenXRStructureBase, Callable)"/> as the next parameter to create a spatial context with spatial persistence capabilities.</para>
/// </summary>
public partial class OpenXRSpatialContextPersistenceConfig : OpenXRStructureBase
{
    private static readonly System.Type CachedType = typeof(OpenXRSpatialContextPersistenceConfig);

    private static readonly StringName NativeName = "OpenXRSpatialContextPersistenceConfig";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialContextPersistenceConfig() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialContextPersistenceConfig(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialContextPersistenceConfig(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPersistenceContext, 2722037293ul);

    /// <summary>
    /// <para>Adds a persistence context to this configuration. You must add at least one persistence context to create a valid configuration. You can create a persistence context by calling <see cref="Godot.OpenXRSpatialAnchorCapability.CreatePersistenceContext(OpenXRSpatialAnchorCapability.PersistenceScope, Callable)"/>.</para>
    /// </summary>
    public void AddPersistenceContext(Rid persistenceContext)
    {
        NativeCalls.godot_icall_1_286(MethodBind0, GodotObject.GetPtr(this), persistenceContext);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePersistenceContext, 2722037293ul);

    /// <summary>
    /// <para>Removes a persistence context.</para>
    /// </summary>
    public void RemovePersistenceContext(Rid persistenceContext)
    {
        NativeCalls.godot_icall_1_286(MethodBind1, GodotObject.GetPtr(this), persistenceContext);
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
    public new class PropertyName : OpenXRStructureBase.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRStructureBase.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_persistence_context' method.
        /// </summary>
        public static readonly StringName AddPersistenceContext = "add_persistence_context";
        /// <summary>
        /// Cached name for the 'remove_persistence_context' method.
        /// </summary>
        public static readonly StringName RemovePersistenceContext = "remove_persistence_context";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRStructureBase.SignalName
    {
    }
}
