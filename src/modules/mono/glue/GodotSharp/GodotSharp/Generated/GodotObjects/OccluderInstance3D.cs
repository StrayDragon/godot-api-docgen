namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Occlusion culling can improve rendering performance in closed/semi-open areas by hiding geometry that is occluded by other objects.</para>
/// <para>The occlusion culling system is mostly static. <see cref="Godot.OccluderInstance3D"/>s can be moved or hidden at run-time, but doing so will trigger a background recomputation that can take several frames. It is recommended to only move <see cref="Godot.OccluderInstance3D"/>s sporadically (e.g. for procedural generation purposes), rather than doing so every frame.</para>
/// <para>The occlusion culling system works by rendering the occluders on the CPU in parallel using <a href="https://www.embree.org/">Embree</a>, drawing the result to a low-resolution buffer then using this to cull 3D nodes individually. In the 3D editor, you can preview the occlusion culling buffer by choosing <b>Perspective &gt; Display Advanced... &gt; Occlusion Culling Buffer</b> in the top-left corner of the 3D viewport. The occlusion culling buffer quality can be adjusted in the Project Settings.</para>
/// <para><b>Baking:</b> Select an <see cref="Godot.OccluderInstance3D"/> node, then use the <b>Bake Occluders</b> button at the top of the 3D editor. Only opaque materials will be taken into account; transparent materials (alpha-blended or alpha-tested) will be ignored by the occluder generation.</para>
/// <para><b>Note:</b> Occlusion culling is only effective if <c>ProjectSettings.rendering/occlusion_culling/use_occlusion_culling</c> is <see langword="true"/>. Enabling occlusion culling has a cost on the CPU. Only enable occlusion culling if you actually plan to use it. Large open scenes with few or no objects blocking the view will generally not benefit much from occlusion culling. Large open scenes generally benefit more from mesh LOD and visibility ranges (<see cref="Godot.GeometryInstance3D.VisibilityRangeBegin"/> and <see cref="Godot.GeometryInstance3D.VisibilityRangeEnd"/>) compared to occlusion culling.</para>
/// <para><b>Note:</b> Due to memory constraints, occlusion culling is not supported by default in Web export templates. It can be enabled by compiling custom Web export templates with <c>module_raycast_enabled=yes</c>.</para>
/// </summary>
public partial class OccluderInstance3D : VisualInstance3D
{
    /// <summary>
    /// <para>The occluder resource for this <see cref="Godot.OccluderInstance3D"/>. You can generate an occluder resource by selecting an <see cref="Godot.OccluderInstance3D"/> node then using the <b>Bake Occluders</b> button at the top of the editor.</para>
    /// <para>You can also draw your own 2D occluder polygon by adding a new <see cref="Godot.PolygonOccluder3D"/> resource to the <see cref="Godot.OccluderInstance3D.Occluder"/> property in the Inspector.</para>
    /// <para>Alternatively, you can select a primitive occluder to use: <see cref="Godot.QuadOccluder3D"/>, <see cref="Godot.BoxOccluder3D"/> or <see cref="Godot.SphereOccluder3D"/>.</para>
    /// </summary>
    public Occluder3D Occluder
    {
        get
        {
            return GetOccluder();
        }
        set
        {
            SetOccluder(value);
        }
    }

    /// <summary>
    /// <para>The visual layers to account for when baking for occluders. Only <see cref="Godot.MeshInstance3D"/>s whose <see cref="Godot.VisualInstance3D.Layers"/> match with this <see cref="Godot.OccluderInstance3D.BakeMask"/> will be included in the generated occluder mesh. By default, all objects with <i>opaque</i> materials are taken into account for the occluder baking.</para>
    /// <para>To improve performance and avoid artifacts, it is recommended to exclude dynamic objects, small objects and fixtures from the baking process by moving them to a separate visual layer and excluding this layer in <see cref="Godot.OccluderInstance3D.BakeMask"/>.</para>
    /// </summary>
    public uint BakeMask
    {
        get
        {
            return GetBakeMask();
        }
        set
        {
            SetBakeMask(value);
        }
    }

    /// <summary>
    /// <para>The simplification distance to use for simplifying the generated occluder polygon (in 3D units). Higher values result in a less detailed occluder mesh, which improves performance but reduces culling accuracy.</para>
    /// <para>The occluder geometry is rendered on the CPU, so it is important to keep its geometry as simple as possible. Since the buffer is rendered at a low resolution, less detailed occluder meshes generally still work well. The default value is fairly aggressive, so you may have to decrease it if you run into false negatives (objects being occluded even though they are visible by the camera). A value of <c>0.01</c> will act conservatively, and will keep geometry <i>perceptually</i> unaffected in the occlusion culling buffer. Depending on the scene, a value of <c>0.01</c> may still simplify the mesh noticeably compared to disabling simplification entirely.</para>
    /// <para>Setting this to <c>0.0</c> disables simplification entirely, but vertices in the exact same position will still be merged. The mesh will also be re-indexed to reduce both the number of vertices and indices.</para>
    /// <para><b>Note:</b> This uses the <a href="https://meshoptimizer.org/">meshoptimizer</a> library under the hood, similar to LOD generation.</para>
    /// </summary>
    public float BakeSimplificationDistance
    {
        get
        {
            return GetBakeSimplificationDistance();
        }
        set
        {
            SetBakeSimplificationDistance(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OccluderInstance3D);

    private static readonly StringName NativeName = "OccluderInstance3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OccluderInstance3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OccluderInstance3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OccluderInstance3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakeMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBakeMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind0, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetBakeMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakeMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.OccluderInstance3D.BakeMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetBakeMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind2, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.OccluderInstance3D.BakeMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetBakeMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind3, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakeSimplificationDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBakeSimplificationDistance(float simplificationDistance)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), simplificationDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeSimplificationDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBakeSimplificationDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOccluder, 1664878165ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOccluder(Occluder3D occluder)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(occluder));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOccluder, 1696836198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Occluder3D GetOccluder()
    {
        return (Occluder3D)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'occluder' property.
        /// </summary>
        public static readonly StringName Occluder = "occluder";
        /// <summary>
        /// Cached name for the 'bake_mask' property.
        /// </summary>
        public static readonly StringName BakeMask = "bake_mask";
        /// <summary>
        /// Cached name for the 'bake_simplification_distance' property.
        /// </summary>
        public static readonly StringName BakeSimplificationDistance = "bake_simplification_distance";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_bake_mask' method.
        /// </summary>
        public static readonly StringName SetBakeMask = "set_bake_mask";
        /// <summary>
        /// Cached name for the 'get_bake_mask' method.
        /// </summary>
        public static readonly StringName GetBakeMask = "get_bake_mask";
        /// <summary>
        /// Cached name for the 'set_bake_mask_value' method.
        /// </summary>
        public static readonly StringName SetBakeMaskValue = "set_bake_mask_value";
        /// <summary>
        /// Cached name for the 'get_bake_mask_value' method.
        /// </summary>
        public static readonly StringName GetBakeMaskValue = "get_bake_mask_value";
        /// <summary>
        /// Cached name for the 'set_bake_simplification_distance' method.
        /// </summary>
        public static readonly StringName SetBakeSimplificationDistance = "set_bake_simplification_distance";
        /// <summary>
        /// Cached name for the 'get_bake_simplification_distance' method.
        /// </summary>
        public static readonly StringName GetBakeSimplificationDistance = "get_bake_simplification_distance";
        /// <summary>
        /// Cached name for the 'set_occluder' method.
        /// </summary>
        public static readonly StringName SetOccluder = "set_occluder";
        /// <summary>
        /// Cached name for the 'get_occluder' method.
        /// </summary>
        public static readonly StringName GetOccluder = "get_occluder";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
    }
}
