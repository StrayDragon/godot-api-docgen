namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class extends <see cref="Godot.PhysicsDirectSpaceState3D"/> by providing additional virtual methods that can be overridden. When these methods are overridden, they will be called instead of the internal methods of the physics server.</para>
/// <para>Intended for use with GDExtension to create custom implementations of <see cref="Godot.PhysicsDirectSpaceState3D"/>.</para>
/// </summary>
public partial class PhysicsDirectSpaceState3DExtension : PhysicsDirectSpaceState3D
{
    private static readonly System.Type CachedType = typeof(PhysicsDirectSpaceState3DExtension);

    private static readonly StringName NativeName = "PhysicsDirectSpaceState3DExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicsDirectSpaceState3DExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsDirectSpaceState3DExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsDirectSpaceState3DExtension(bool memoryOwn) : base(memoryOwn) { }

    public virtual unsafe Vector3 _GetClosestPointToObjectVolume(Rid @object, Vector3 point)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBodyExcludedFromQuery, 4155700596ul);

    public bool IsBodyExcludedFromQuery(Rid body)
    {
        return NativeCalls.godot_icall_1_421(MethodBind0, GodotObject.GetPtr(this), body).ToBool();
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_closest_point_to_object_volume = "_GetClosestPointToObjectVolume";

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
        if ((method == MethodProxyName__get_closest_point_to_object_volume || method == MethodName._GetClosestPointToObjectVolume) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_closest_point_to_object_volume.NativeValue))
        {
            var callRet = _GetClosestPointToObjectVolume(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = VariantUtils.CreateFrom<Vector3>(callRet);
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
        if (method == MethodName._GetClosestPointToObjectVolume)
        {
            if (HasGodotClassMethod(MethodProxyName__get_closest_point_to_object_volume.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : PhysicsDirectSpaceState3D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PhysicsDirectSpaceState3D.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_closest_point_to_object_volume' method.
        /// </summary>
        public static readonly StringName _GetClosestPointToObjectVolume = "_get_closest_point_to_object_volume";
        /// <summary>
        /// Cached name for the 'is_body_excluded_from_query' method.
        /// </summary>
        public static readonly StringName IsBodyExcludedFromQuery = "is_body_excluded_from_query";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PhysicsDirectSpaceState3D.SignalName
    {
    }
}
