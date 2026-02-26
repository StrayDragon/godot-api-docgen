namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class extends <see cref="Godot.PhysicsDirectSpaceState2D"/> by providing additional virtual methods that can be overridden. When these methods are overridden, they will be called instead of the internal methods of the physics server.</para>
/// <para>Intended for use with GDExtension to create custom implementations of <see cref="Godot.PhysicsDirectSpaceState2D"/>.</para>
/// </summary>
public partial class PhysicsDirectSpaceState2DExtension : PhysicsDirectSpaceState2D
{
    private static readonly System.Type CachedType = typeof(PhysicsDirectSpaceState2DExtension);

    private static readonly StringName NativeName = "PhysicsDirectSpaceState2DExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicsDirectSpaceState2DExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsDirectSpaceState2DExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsDirectSpaceState2DExtension(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBodyExcludedFromQuery, 4155700596ul);

    public bool IsBodyExcludedFromQuery(Rid body)
    {
        return NativeCalls.godot_icall_1_421(MethodBind0, GodotObject.GetPtr(this), body).ToBool();
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
    public new class PropertyName : PhysicsDirectSpaceState2D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PhysicsDirectSpaceState2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_body_excluded_from_query' method.
        /// </summary>
        public static readonly StringName IsBodyExcludedFromQuery = "is_body_excluded_from_query";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PhysicsDirectSpaceState2D.SignalName
    {
    }
}
