namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.VoxelGIData"/> contains baked voxel global illumination for use in a <see cref="Godot.VoxelGI"/> node. <see cref="Godot.VoxelGIData"/> also offers several properties to adjust the final appearance of the global illumination. These properties can be adjusted at run-time without having to bake the <see cref="Godot.VoxelGI"/> node again.</para>
/// <para><b>Note:</b> To prevent text-based scene files (<c>.tscn</c>) from growing too much and becoming slow to load and save, always save <see cref="Godot.VoxelGIData"/> to an external binary resource file (<c>.res</c>) instead of embedding it within the scene. This can be done by clicking the dropdown arrow next to the <see cref="Godot.VoxelGIData"/> resource, choosing <b>Edit</b>, clicking the floppy disk icon at the top of the Inspector then choosing <b>Save As...</b>.</para>
/// </summary>
public partial class VoxelGIData : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary _Data
    {
        get
        {
            return _GetData();
        }
        set
        {
            _SetData(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>The dynamic range to use (<c>1.0</c> represents a low dynamic range scene brightness). Higher values can be used to provide brighter indirect lighting, at the cost of more visible color banding in dark areas (both in indirect lighting and reflections). To avoid color banding, it's recommended to use the lowest value that does not result in visible light clipping.</para>
    /// </summary>
    public float DynamicRange
    {
        get
        {
            return GetDynamicRange();
        }
        set
        {
            SetDynamicRange(value);
        }
    }

    /// <summary>
    /// <para>The energy of the indirect lighting and reflections produced by the <see cref="Godot.VoxelGI"/> node. Higher values result in brighter indirect lighting. If indirect lighting looks too flat, try decreasing <see cref="Godot.VoxelGIData.Propagation"/> while increasing <see cref="Godot.VoxelGIData.Energy"/> at the same time. See also <see cref="Godot.VoxelGIData.UseTwoBounces"/> which influences the indirect lighting's effective brightness.</para>
    /// </summary>
    public float Energy
    {
        get
        {
            return GetEnergy();
        }
        set
        {
            SetEnergy(value);
        }
    }

    /// <summary>
    /// <para>The normal bias to use for indirect lighting and reflections. Higher values reduce self-reflections visible in non-rough materials, at the cost of more visible light leaking and flatter-looking indirect lighting. To prioritize hiding self-reflections over lighting quality, set <see cref="Godot.VoxelGIData.Bias"/> to <c>0.0</c> and <see cref="Godot.VoxelGIData.NormalBias"/> to a value between <c>1.0</c> and <c>2.0</c>.</para>
    /// </summary>
    public float Bias
    {
        get
        {
            return GetBias();
        }
        set
        {
            SetBias(value);
        }
    }

    /// <summary>
    /// <para>The normal bias to use for indirect lighting and reflections. Higher values reduce self-reflections visible in non-rough materials, at the cost of more visible light leaking and flatter-looking indirect lighting. See also <see cref="Godot.VoxelGIData.Bias"/>. To prioritize hiding self-reflections over lighting quality, set <see cref="Godot.VoxelGIData.Bias"/> to <c>0.0</c> and <see cref="Godot.VoxelGIData.NormalBias"/> to a value between <c>1.0</c> and <c>2.0</c>.</para>
    /// </summary>
    public float NormalBias
    {
        get
        {
            return GetNormalBias();
        }
        set
        {
            SetNormalBias(value);
        }
    }

    /// <summary>
    /// <para>The multiplier to use when light bounces off a surface. Higher values result in brighter indirect lighting. If indirect lighting looks too flat, try decreasing <see cref="Godot.VoxelGIData.Propagation"/> while increasing <see cref="Godot.VoxelGIData.Energy"/> at the same time. See also <see cref="Godot.VoxelGIData.UseTwoBounces"/> which influences the indirect lighting's effective brightness.</para>
    /// </summary>
    public float Propagation
    {
        get
        {
            return GetPropagation();
        }
        set
        {
            SetPropagation(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, performs two bounces of indirect lighting instead of one. This makes indirect lighting look more natural and brighter at a small performance cost. The second bounce is also visible in reflections. If the scene appears too bright after enabling <see cref="Godot.VoxelGIData.UseTwoBounces"/>, adjust <see cref="Godot.VoxelGIData.Propagation"/> and <see cref="Godot.VoxelGIData.Energy"/>.</para>
    /// </summary>
    public bool UseTwoBounces
    {
        get
        {
            return IsUsingTwoBounces();
        }
        set
        {
            SetUseTwoBounces(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.Environment"/> lighting is ignored by the <see cref="Godot.VoxelGI"/> node. If <see langword="false"/>, <see cref="Godot.Environment"/> lighting is taken into account by the <see cref="Godot.VoxelGI"/> node. <see cref="Godot.Environment"/> lighting updates in real-time, which means it can be changed without having to bake the <see cref="Godot.VoxelGI"/> node again.</para>
    /// </summary>
    public bool Interior
    {
        get
        {
            return IsInterior();
        }
        set
        {
            SetInterior(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VoxelGIData);

    private static readonly StringName NativeName = "VoxelGIData";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VoxelGIData() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VoxelGIData(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VoxelGIData(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Allocate, 4041601946ul);

    public unsafe void Allocate(Transform3D toCellXform, Aabb aabb, Vector3 octreeSize, byte[] octreeCells, byte[] dataCells, byte[] distanceField, int[] levelCounts)
    {
        NativeCalls.godot_icall_7_1497(MethodBind0, GodotObject.GetPtr(this), &toCellXform, &aabb, &octreeSize, octreeCells, dataCells, distanceField, levelCounts);
    }

    public unsafe void Allocate(Transform3D toCellXform, Aabb aabb, Vector3 octreeSize, ReadOnlySpan<byte> octreeCells, ReadOnlySpan<byte> dataCells, ReadOnlySpan<byte> distanceField, ReadOnlySpan<int> levelCounts)
    {
        NativeCalls.godot_icall_7_1497(MethodBind0, GodotObject.GetPtr(this), &toCellXform, &aabb, &octreeSize, octreeCells, dataCells, distanceField, levelCounts);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBounds, 1068685055ul);

    /// <summary>
    /// <para>Returns the bounds of the baked voxel data as an <see cref="Godot.Aabb"/>, which should match <see cref="Godot.VoxelGI.Size"/> after being baked (which only contains the size as a <see cref="Godot.Vector3"/>).</para>
    /// <para><b>Note:</b> If the size was modified without baking the VoxelGI data, then the value of <see cref="Godot.VoxelGIData.GetBounds()"/> and <see cref="Godot.VoxelGI.Size"/> will not match.</para>
    /// </summary>
    public Aabb GetBounds()
    {
        return NativeCalls.godot_icall_0_184(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOctreeSize, 3360562783ul);

    public Vector3 GetOctreeSize()
    {
        return NativeCalls.godot_icall_0_125(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetToCellXform, 3229777777ul);

    public Transform3D GetToCellXform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOctreeCells, 2362200018ul);

    public byte[] GetOctreeCells()
    {
        return NativeCalls.godot_icall_0_2(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDataCells, 2362200018ul);

    public byte[] GetDataCells()
    {
        return NativeCalls.godot_icall_0_2(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLevelCounts, 1930428628ul);

    public int[] GetLevelCounts()
    {
        return NativeCalls.godot_icall_0_151(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDynamicRange, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDynamicRange(float dynamicRange)
    {
        NativeCalls.godot_icall_1_67(MethodBind7, GodotObject.GetPtr(this), dynamicRange);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDynamicRange, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDynamicRange()
    {
        return NativeCalls.godot_icall_0_68(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnergy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnergy(float energy)
    {
        NativeCalls.godot_icall_1_67(MethodBind9, GodotObject.GetPtr(this), energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnergy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEnergy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBias(float bias)
    {
        NativeCalls.godot_icall_1_67(MethodBind11, GodotObject.GetPtr(this), bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNormalBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNormalBias(float bias)
    {
        NativeCalls.godot_icall_1_67(MethodBind13, GodotObject.GetPtr(this), bias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNormalBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetNormalBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPropagation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPropagation(float propagation)
    {
        NativeCalls.godot_icall_1_67(MethodBind15, GodotObject.GetPtr(this), propagation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPropagation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPropagation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInterior, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInterior(bool interior)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), interior.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInterior, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsInterior()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseTwoBounces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseTwoBounces(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingTwoBounces, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingTwoBounces()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetData, 4155329257ul);

    internal void _SetData(Godot.Collections.Dictionary data)
    {
        NativeCalls.godot_icall_1_121(MethodBind21, GodotObject.GetPtr(this), (godot_dictionary)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetData, 3102165223ul);

    internal Godot.Collections.Dictionary _GetData()
    {
        return NativeCalls.godot_icall_0_122(MethodBind22, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the '_data' property.
        /// </summary>
        public static readonly StringName _Data = "_data";
        /// <summary>
        /// Cached name for the 'dynamic_range' property.
        /// </summary>
        public static readonly StringName DynamicRange = "dynamic_range";
        /// <summary>
        /// Cached name for the 'energy' property.
        /// </summary>
        public static readonly StringName Energy = "energy";
        /// <summary>
        /// Cached name for the 'bias' property.
        /// </summary>
        public static readonly StringName Bias = "bias";
        /// <summary>
        /// Cached name for the 'normal_bias' property.
        /// </summary>
        public static readonly StringName NormalBias = "normal_bias";
        /// <summary>
        /// Cached name for the 'propagation' property.
        /// </summary>
        public static readonly StringName Propagation = "propagation";
        /// <summary>
        /// Cached name for the 'use_two_bounces' property.
        /// </summary>
        public static readonly StringName UseTwoBounces = "use_two_bounces";
        /// <summary>
        /// Cached name for the 'interior' property.
        /// </summary>
        public static readonly StringName Interior = "interior";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'allocate' method.
        /// </summary>
        public static readonly StringName Allocate = "allocate";
        /// <summary>
        /// Cached name for the 'get_bounds' method.
        /// </summary>
        public static readonly StringName GetBounds = "get_bounds";
        /// <summary>
        /// Cached name for the 'get_octree_size' method.
        /// </summary>
        public static readonly StringName GetOctreeSize = "get_octree_size";
        /// <summary>
        /// Cached name for the 'get_to_cell_xform' method.
        /// </summary>
        public static readonly StringName GetToCellXform = "get_to_cell_xform";
        /// <summary>
        /// Cached name for the 'get_octree_cells' method.
        /// </summary>
        public static readonly StringName GetOctreeCells = "get_octree_cells";
        /// <summary>
        /// Cached name for the 'get_data_cells' method.
        /// </summary>
        public static readonly StringName GetDataCells = "get_data_cells";
        /// <summary>
        /// Cached name for the 'get_level_counts' method.
        /// </summary>
        public static readonly StringName GetLevelCounts = "get_level_counts";
        /// <summary>
        /// Cached name for the 'set_dynamic_range' method.
        /// </summary>
        public static readonly StringName SetDynamicRange = "set_dynamic_range";
        /// <summary>
        /// Cached name for the 'get_dynamic_range' method.
        /// </summary>
        public static readonly StringName GetDynamicRange = "get_dynamic_range";
        /// <summary>
        /// Cached name for the 'set_energy' method.
        /// </summary>
        public static readonly StringName SetEnergy = "set_energy";
        /// <summary>
        /// Cached name for the 'get_energy' method.
        /// </summary>
        public static readonly StringName GetEnergy = "get_energy";
        /// <summary>
        /// Cached name for the 'set_bias' method.
        /// </summary>
        public static readonly StringName SetBias = "set_bias";
        /// <summary>
        /// Cached name for the 'get_bias' method.
        /// </summary>
        public static readonly StringName GetBias = "get_bias";
        /// <summary>
        /// Cached name for the 'set_normal_bias' method.
        /// </summary>
        public static readonly StringName SetNormalBias = "set_normal_bias";
        /// <summary>
        /// Cached name for the 'get_normal_bias' method.
        /// </summary>
        public static readonly StringName GetNormalBias = "get_normal_bias";
        /// <summary>
        /// Cached name for the 'set_propagation' method.
        /// </summary>
        public static readonly StringName SetPropagation = "set_propagation";
        /// <summary>
        /// Cached name for the 'get_propagation' method.
        /// </summary>
        public static readonly StringName GetPropagation = "get_propagation";
        /// <summary>
        /// Cached name for the 'set_interior' method.
        /// </summary>
        public static readonly StringName SetInterior = "set_interior";
        /// <summary>
        /// Cached name for the 'is_interior' method.
        /// </summary>
        public static readonly StringName IsInterior = "is_interior";
        /// <summary>
        /// Cached name for the 'set_use_two_bounces' method.
        /// </summary>
        public static readonly StringName SetUseTwoBounces = "set_use_two_bounces";
        /// <summary>
        /// Cached name for the 'is_using_two_bounces' method.
        /// </summary>
        public static readonly StringName IsUsingTwoBounces = "is_using_two_bounces";
        /// <summary>
        /// Cached name for the '_set_data' method.
        /// </summary>
        public static readonly StringName _SetData = "_set_data";
        /// <summary>
        /// Cached name for the '_get_data' method.
        /// </summary>
        public static readonly StringName _GetData = "_get_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
