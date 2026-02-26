namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Node that can be the parent of <see cref="Godot.PhysicalBone3D"/> and can apply the simulation results to <see cref="Godot.Skeleton3D"/>.</para>
/// </summary>
public partial class PhysicalBoneSimulator3D : SkeletonModifier3D
{
    private static readonly System.Type CachedType = typeof(PhysicalBoneSimulator3D);

    private static readonly StringName NativeName = "PhysicalBoneSimulator3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicalBoneSimulator3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicalBoneSimulator3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicalBoneSimulator3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSimulatingPhysics, 36873697ul);

    /// <summary>
    /// <para>Returns a boolean that indicates whether the <see cref="Godot.PhysicalBoneSimulator3D"/> is running and simulating.</para>
    /// </summary>
    public bool IsSimulatingPhysics()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PhysicalBonesStopSimulation, 3218959716ul);

    /// <summary>
    /// <para>Tells the <see cref="Godot.PhysicalBone3D"/> nodes in the Skeleton to stop simulating.</para>
    /// </summary>
    public void PhysicalBonesStopSimulation()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PhysicalBonesStartSimulation, 2787316981ul);

    /// <summary>
    /// <para>Tells the <see cref="Godot.PhysicalBone3D"/> nodes in the Skeleton to start simulating and reacting to the physics world.</para>
    /// <para>Optionally, a list of bone names can be passed-in, allowing only the passed-in bones to be simulated.</para>
    /// </summary>
    public void PhysicalBonesStartSimulation(Godot.Collections.Array<StringName> bones = null)
    {
        NativeCalls.godot_icall_1_138(MethodBind2, GodotObject.GetPtr(this), (godot_array)(bones ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PhysicalBonesAddCollisionException, 2722037293ul);

    /// <summary>
    /// <para>Adds a collision exception to the physical bone.</para>
    /// <para>Works just like the <see cref="Godot.RigidBody3D"/> node.</para>
    /// </summary>
    public void PhysicalBonesAddCollisionException(Rid exception)
    {
        NativeCalls.godot_icall_1_286(MethodBind3, GodotObject.GetPtr(this), exception);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PhysicalBonesRemoveCollisionException, 2722037293ul);

    /// <summary>
    /// <para>Removes a collision exception to the physical bone.</para>
    /// <para>Works just like the <see cref="Godot.RigidBody3D"/> node.</para>
    /// </summary>
    public void PhysicalBonesRemoveCollisionException(Rid exception)
    {
        NativeCalls.godot_icall_1_286(MethodBind4, GodotObject.GetPtr(this), exception);
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
    public new class PropertyName : SkeletonModifier3D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModifier3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_simulating_physics' method.
        /// </summary>
        public static readonly StringName IsSimulatingPhysics = "is_simulating_physics";
        /// <summary>
        /// Cached name for the 'physical_bones_stop_simulation' method.
        /// </summary>
        public static readonly StringName PhysicalBonesStopSimulation = "physical_bones_stop_simulation";
        /// <summary>
        /// Cached name for the 'physical_bones_start_simulation' method.
        /// </summary>
        public static readonly StringName PhysicalBonesStartSimulation = "physical_bones_start_simulation";
        /// <summary>
        /// Cached name for the 'physical_bones_add_collision_exception' method.
        /// </summary>
        public static readonly StringName PhysicalBonesAddCollisionException = "physical_bones_add_collision_exception";
        /// <summary>
        /// Cached name for the 'physical_bones_remove_collision_exception' method.
        /// </summary>
        public static readonly StringName PhysicalBonesRemoveCollisionException = "physical_bones_remove_collision_exception";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
