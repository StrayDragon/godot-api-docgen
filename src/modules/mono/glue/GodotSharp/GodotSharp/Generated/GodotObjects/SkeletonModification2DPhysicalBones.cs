namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This modification takes the transforms of <see cref="Godot.PhysicalBone2D"/> nodes and applies them to <see cref="Godot.Bone2D"/> nodes. This allows the <see cref="Godot.Bone2D"/> nodes to react to physics thanks to the linked <see cref="Godot.PhysicalBone2D"/> nodes.</para>
/// </summary>
public partial class SkeletonModification2DPhysicalBones : SkeletonModification2D
{
    /// <summary>
    /// <para>The number of <see cref="Godot.PhysicalBone2D"/> nodes linked in this modification.</para>
    /// </summary>
    public int PhysicalBoneChainLength
    {
        get
        {
            return GetPhysicalBoneChainLength();
        }
        set
        {
            SetPhysicalBoneChainLength(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SkeletonModification2DPhysicalBones);

    private static readonly StringName NativeName = "SkeletonModification2DPhysicalBones";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonModification2DPhysicalBones() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DPhysicalBones(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DPhysicalBones(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicalBoneChainLength, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicalBoneChainLength(int length)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicalBoneChainLength, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPhysicalBoneChainLength()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicalBoneNode, 2761262315ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.PhysicalBone2D"/> node at <paramref name="jointIdx"/>.</para>
    /// <para><b>Note:</b> This is just the index used for this modification, not the bone index used in the <see cref="Godot.Skeleton2D"/>.</para>
    /// </summary>
    public void SetPhysicalBoneNode(int jointIdx, NodePath physicalbone2DNode)
    {
        NativeCalls.godot_icall_2_75(MethodBind2, GodotObject.GetPtr(this), jointIdx, (godot_node_path)(physicalbone2DNode?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicalBoneNode, 408788394ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PhysicalBone2D"/> node at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public NodePath GetPhysicalBoneNode(int jointIdx)
    {
        return NativeCalls.godot_icall_1_74(MethodBind3, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FetchPhysicalBones, 3218959716ul);

    /// <summary>
    /// <para>Empties the list of <see cref="Godot.PhysicalBone2D"/> nodes and populates it with all <see cref="Godot.PhysicalBone2D"/> nodes that are children of the <see cref="Godot.Skeleton2D"/>.</para>
    /// </summary>
    public void FetchPhysicalBones()
    {
        NativeCalls.godot_icall_0_3(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StartSimulation, 2787316981ul);

    /// <summary>
    /// <para>Tell the <see cref="Godot.PhysicalBone2D"/> nodes to start simulating and interacting with the physics world.</para>
    /// <para>Optionally, an array of bone names can be passed to this function, and that will cause only <see cref="Godot.PhysicalBone2D"/> nodes with those names to start simulating.</para>
    /// </summary>
    public void StartSimulation(Godot.Collections.Array<StringName> bones = null)
    {
        NativeCalls.godot_icall_1_138(MethodBind5, GodotObject.GetPtr(this), (godot_array)(bones ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StopSimulation, 2787316981ul);

    /// <summary>
    /// <para>Tell the <see cref="Godot.PhysicalBone2D"/> nodes to stop simulating and interacting with the physics world.</para>
    /// <para>Optionally, an array of bone names can be passed to this function, and that will cause only <see cref="Godot.PhysicalBone2D"/> nodes with those names to stop simulating.</para>
    /// </summary>
    public void StopSimulation(Godot.Collections.Array<StringName> bones = null)
    {
        NativeCalls.godot_icall_1_138(MethodBind6, GodotObject.GetPtr(this), (godot_array)(bones ?? new()).NativeValue);
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
    public new class PropertyName : SkeletonModification2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'physical_bone_chain_length' property.
        /// </summary>
        public static readonly StringName PhysicalBoneChainLength = "physical_bone_chain_length";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModification2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_physical_bone_chain_length' method.
        /// </summary>
        public static readonly StringName SetPhysicalBoneChainLength = "set_physical_bone_chain_length";
        /// <summary>
        /// Cached name for the 'get_physical_bone_chain_length' method.
        /// </summary>
        public static readonly StringName GetPhysicalBoneChainLength = "get_physical_bone_chain_length";
        /// <summary>
        /// Cached name for the 'set_physical_bone_node' method.
        /// </summary>
        public static readonly StringName SetPhysicalBoneNode = "set_physical_bone_node";
        /// <summary>
        /// Cached name for the 'get_physical_bone_node' method.
        /// </summary>
        public static readonly StringName GetPhysicalBoneNode = "get_physical_bone_node";
        /// <summary>
        /// Cached name for the 'fetch_physical_bones' method.
        /// </summary>
        public static readonly StringName FetchPhysicalBones = "fetch_physical_bones";
        /// <summary>
        /// Cached name for the 'start_simulation' method.
        /// </summary>
        public static readonly StringName StartSimulation = "start_simulation";
        /// <summary>
        /// Cached name for the 'stop_simulation' method.
        /// </summary>
        public static readonly StringName StopSimulation = "stop_simulation";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModification2D.SignalName
    {
    }
}
