namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Object for storing OpenXR spatial entity component data.</para>
/// </summary>
public partial class OpenXRSpatialComponentData : RefCounted
{
    private static readonly System.Type CachedType = typeof(OpenXRSpatialComponentData);

    private static readonly StringName NativeName = "OpenXRSpatialComponentData";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialComponentData() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialComponentData(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialComponentData(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Return the component type for the component we store data for.</para>
    /// </summary>
    public virtual ulong _GetComponentType()
    {
        return default;
    }

    /// <summary>
    /// <para>Return a pointer to the structure data that will be submitted along with the snapshot query. This pointer must remain valid as long as this object is instantiated.</para>
    /// </summary>
    public virtual ulong _GetStructureData(ulong next)
    {
        return default;
    }

    /// <summary>
    /// <para>Set the expected capacity as provided by the spatial entities query system. Buffers should be initialized with the correct storage.</para>
    /// </summary>
    public virtual void _SetCapacity(uint capacity)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCapacity, 1286410249ul);

    /// <summary>
    /// <para>Set the expected capacity as provided by the spatial entities query system. Buffers should be initialized with the correct storage.</para>
    /// </summary>
    public void SetCapacity(uint capacity)
    {
        NativeCalls.godot_icall_1_208(MethodBind0, GodotObject.GetPtr(this), capacity);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_component_type = "_GetComponentType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_structure_data = "_GetStructureData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_capacity = "_SetCapacity";

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
        if ((method == MethodProxyName__get_component_type || method == MethodName._GetComponentType) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_component_type.NativeValue))
        {
            var callRet = _GetComponentType();
            ret = VariantUtils.CreateFrom<ulong>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_structure_data || method == MethodName._GetStructureData) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_structure_data.NativeValue))
        {
            var callRet = _GetStructureData(VariantUtils.ConvertTo<ulong>(args[0]));
            ret = VariantUtils.CreateFrom<ulong>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set_capacity || method == MethodName._SetCapacity) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_capacity.NativeValue))
        {
            _SetCapacity(VariantUtils.ConvertTo<uint>(args[0]));
            ret = default;
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
        if (method == MethodName._GetComponentType)
        {
            if (HasGodotClassMethod(MethodProxyName__get_component_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetStructureData)
        {
            if (HasGodotClassMethod(MethodProxyName__get_structure_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetCapacity)
        {
            if (HasGodotClassMethod(MethodProxyName__set_capacity.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_get_component_type' method.
        /// </summary>
        public static readonly StringName _GetComponentType = "_get_component_type";
        /// <summary>
        /// Cached name for the '_get_structure_data' method.
        /// </summary>
        public static readonly StringName _GetStructureData = "_get_structure_data";
        /// <summary>
        /// Cached name for the '_set_capacity' method.
        /// </summary>
        public static readonly StringName _SetCapacity = "_set_capacity";
        /// <summary>
        /// Cached name for the 'set_capacity' method.
        /// </summary>
        public static readonly StringName SetCapacity = "set_capacity";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
