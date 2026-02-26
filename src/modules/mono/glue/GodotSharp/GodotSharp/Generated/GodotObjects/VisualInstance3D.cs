namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.VisualInstance3D"/> is used to connect a resource to a visual representation. All visual 3D nodes inherit from the <see cref="Godot.VisualInstance3D"/>. In general, you should not access the <see cref="Godot.VisualInstance3D"/> properties directly as they are accessed and managed by the nodes that inherit from <see cref="Godot.VisualInstance3D"/>. <see cref="Godot.VisualInstance3D"/> is the node representation of the <see cref="Godot.RenderingServer"/> instance.</para>
/// </summary>
public partial class VisualInstance3D : Node3D
{
    /// <summary>
    /// <para>The render layer(s) this <see cref="Godot.VisualInstance3D"/> is drawn on.</para>
    /// <para>This object will only be visible for <see cref="Godot.Camera3D"/>s whose cull mask includes any of the render layers this <see cref="Godot.VisualInstance3D"/> is set to.</para>
    /// <para>For <see cref="Godot.Light3D"/>s, this can be used to control which <see cref="Godot.VisualInstance3D"/>s are affected by a specific light. For <see cref="Godot.GpuParticles3D"/>, this can be used to control which particles are effected by a specific attractor. For <see cref="Godot.Decal"/>s, this can be used to control which <see cref="Godot.VisualInstance3D"/>s are affected by a specific decal.</para>
    /// <para>To adjust <see cref="Godot.VisualInstance3D.Layers"/> more easily using a script, use <see cref="Godot.VisualInstance3D.GetLayerMaskValue(int)"/> and <see cref="Godot.VisualInstance3D.SetLayerMaskValue(int, bool)"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.VoxelGI"/>, SDFGI and <see cref="Godot.LightmapGI"/> will always take all layers into account to determine what contributes to global illumination. If this is an issue, set <see cref="Godot.GeometryInstance3D.GIMode"/> to <see cref="Godot.GeometryInstance3D.GIModeEnum.Disabled"/> for meshes and <see cref="Godot.Light3D.LightBakeMode"/> to <see cref="Godot.Light3D.BakeMode.Disabled"/> for lights to exclude them from global illumination.</para>
    /// </summary>
    public uint Layers
    {
        get
        {
            return GetLayerMask();
        }
        set
        {
            SetLayerMask(value);
        }
    }

    /// <summary>
    /// <para>The amount by which the depth of this <see cref="Godot.VisualInstance3D"/> will be adjusted when sorting by depth. Uses the same units as the engine (which are typically meters). Adjusting it to a higher value will make the <see cref="Godot.VisualInstance3D"/> reliably draw on top of other <see cref="Godot.VisualInstance3D"/>s that are otherwise positioned at the same spot. To ensure it always draws on top of other objects around it (not positioned at the same spot), set the value to be greater than the distance between this <see cref="Godot.VisualInstance3D"/> and the other nearby <see cref="Godot.VisualInstance3D"/>s.</para>
    /// </summary>
    public float SortingOffset
    {
        get
        {
            return GetSortingOffset();
        }
        set
        {
            SetSortingOffset(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the object is sorted based on the <see cref="Godot.Aabb"/> center. The object will be sorted based on the global position otherwise.</para>
    /// <para>The <see cref="Godot.Aabb"/> center based sorting is generally more accurate for 3D models. The position based sorting instead allows to better control the drawing order when working with <see cref="Godot.GpuParticles3D"/> and <see cref="Godot.CpuParticles3D"/>.</para>
    /// </summary>
    public bool SortingUseAabbCenter
    {
        get
        {
            return IsSortingUseAabbCenter();
        }
        set
        {
            SetSortingUseAabbCenter(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualInstance3D);

    private static readonly StringName NativeName = "VisualInstance3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualInstance3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal VisualInstance3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal VisualInstance3D(bool memoryOwn) : base(memoryOwn) { }

    public virtual Aabb _GetAabb()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBase, 2722037293ul);

    /// <summary>
    /// <para>Sets the resource that is instantiated by this <see cref="Godot.VisualInstance3D"/>, which changes how the engine handles the <see cref="Godot.VisualInstance3D"/> under the hood. Equivalent to <see cref="Godot.RenderingServer.InstanceSetBase(Rid, Rid)"/>.</para>
    /// </summary>
    public void SetBase(Rid @base)
    {
        NativeCalls.godot_icall_1_286(MethodBind0, GodotObject.GetPtr(this), @base);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBase, 2944877500ul);

    /// <summary>
    /// <para>Returns the RID of the resource associated with this <see cref="Godot.VisualInstance3D"/>. For example, if the Node is a <see cref="Godot.MeshInstance3D"/>, this will return the RID of the associated <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public Rid GetBase()
    {
        return NativeCalls.godot_icall_0_238(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstance, 2944877500ul);

    /// <summary>
    /// <para>Returns the RID of this instance. This RID is the same as the RID returned by <see cref="Godot.RenderingServer.InstanceCreate()"/>. This RID is needed if you want to call <see cref="Godot.RenderingServer"/> functions directly on this <see cref="Godot.VisualInstance3D"/>.</para>
    /// </summary>
    public Rid GetInstance()
    {
        return NativeCalls.godot_icall_0_238(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLayerMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind3, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetLayerMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.VisualInstance3D.Layers"/>, given a <paramref name="layerNumber"/> between 1 and 20.</para>
    /// </summary>
    public void SetLayerMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind5, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.VisualInstance3D.Layers"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 20.</para>
    /// </summary>
    public bool GetLayerMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind6, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSortingOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSortingOffset(float offset)
    {
        NativeCalls.godot_icall_1_67(MethodBind7, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSortingOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSortingOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSortingUseAabbCenter, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSortingUseAabbCenter(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSortingUseAabbCenter, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSortingUseAabbCenter()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAabb, 1068685055ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Aabb"/> (also known as the bounding box) for this <see cref="Godot.VisualInstance3D"/>.</para>
    /// </summary>
    public Aabb GetAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind11, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_aabb = "_GetAabb";

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
        if ((method == MethodProxyName__get_aabb || method == MethodName._GetAabb) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_aabb.NativeValue))
        {
            var callRet = _GetAabb();
            ret = VariantUtils.CreateFrom<Aabb>(callRet);
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
        if (method == MethodName._GetAabb)
        {
            if (HasGodotClassMethod(MethodProxyName__get_aabb.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'layers' property.
        /// </summary>
        public static readonly StringName Layers = "layers";
        /// <summary>
        /// Cached name for the 'sorting_offset' property.
        /// </summary>
        public static readonly StringName SortingOffset = "sorting_offset";
        /// <summary>
        /// Cached name for the 'sorting_use_aabb_center' property.
        /// </summary>
        public static readonly StringName SortingUseAabbCenter = "sorting_use_aabb_center";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_aabb' method.
        /// </summary>
        public static readonly StringName _GetAabb = "_get_aabb";
        /// <summary>
        /// Cached name for the 'set_base' method.
        /// </summary>
        public static readonly StringName SetBase = "set_base";
        /// <summary>
        /// Cached name for the 'get_base' method.
        /// </summary>
        public static readonly StringName GetBase = "get_base";
        /// <summary>
        /// Cached name for the 'get_instance' method.
        /// </summary>
        public static readonly StringName GetInstance = "get_instance";
        /// <summary>
        /// Cached name for the 'set_layer_mask' method.
        /// </summary>
        public static readonly StringName SetLayerMask = "set_layer_mask";
        /// <summary>
        /// Cached name for the 'get_layer_mask' method.
        /// </summary>
        public static readonly StringName GetLayerMask = "get_layer_mask";
        /// <summary>
        /// Cached name for the 'set_layer_mask_value' method.
        /// </summary>
        public static readonly StringName SetLayerMaskValue = "set_layer_mask_value";
        /// <summary>
        /// Cached name for the 'get_layer_mask_value' method.
        /// </summary>
        public static readonly StringName GetLayerMaskValue = "get_layer_mask_value";
        /// <summary>
        /// Cached name for the 'set_sorting_offset' method.
        /// </summary>
        public static readonly StringName SetSortingOffset = "set_sorting_offset";
        /// <summary>
        /// Cached name for the 'get_sorting_offset' method.
        /// </summary>
        public static readonly StringName GetSortingOffset = "get_sorting_offset";
        /// <summary>
        /// Cached name for the 'set_sorting_use_aabb_center' method.
        /// </summary>
        public static readonly StringName SetSortingUseAabbCenter = "set_sorting_use_aabb_center";
        /// <summary>
        /// Cached name for the 'is_sorting_use_aabb_center' method.
        /// </summary>
        public static readonly StringName IsSortingUseAabbCenter = "is_sorting_use_aabb_center";
        /// <summary>
        /// Cached name for the 'get_aabb' method.
        /// </summary>
        public static readonly StringName GetAabb = "get_aabb";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
