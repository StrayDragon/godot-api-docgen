namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.VoxelGI"/>s are used to provide high-quality real-time indirect light and reflections to scenes. They precompute the effect of objects that emit light and the effect of static geometry to simulate the behavior of complex light in real-time. <see cref="Godot.VoxelGI"/>s need to be baked before having a visible effect. However, once baked, dynamic objects will receive light from them. Furthermore, lights can be fully dynamic or baked.</para>
/// <para><b>Note:</b> <see cref="Godot.VoxelGI"/> is only supported in the Forward+ rendering method, not Mobile or Compatibility.</para>
/// <para><b>Procedural generation:</b> <see cref="Godot.VoxelGI"/> can be baked in an exported project, which makes it suitable for procedurally generated or user-built levels as long as all the geometry is generated in advance. For games where geometry is generated at any time during gameplay, SDFGI is more suitable (see <see cref="Godot.Environment.SdfgiEnabled"/>).</para>
/// <para><b>Performance:</b> <see cref="Godot.VoxelGI"/> is relatively demanding on the GPU and is not suited to low-end hardware such as integrated graphics (consider <see cref="Godot.LightmapGI"/> instead). To improve performance, adjust <c>ProjectSettings.rendering/global_illumination/voxel_gi/quality</c> and enable <c>ProjectSettings.rendering/global_illumination/gi/use_half_resolution</c> in the Project Settings. To provide a fallback for low-end hardware, consider adding an option to disable <see cref="Godot.VoxelGI"/> in your project's options menus. A <see cref="Godot.VoxelGI"/> node can be disabled by hiding it.</para>
/// <para><b>Note:</b> Meshes should have sufficiently thick walls to avoid light leaks (avoid one-sided walls). For interior levels, enclose your level geometry in a sufficiently large box and bridge the loops to close the mesh. To further prevent light leaks, you can also strategically place temporary <see cref="Godot.MeshInstance3D"/> nodes with their <see cref="Godot.GeometryInstance3D.GIMode"/> set to <see cref="Godot.GeometryInstance3D.GIModeEnum.Static"/>. These temporary nodes can then be hidden after baking the <see cref="Godot.VoxelGI"/> node.</para>
/// </summary>
public partial class VoxelGI : VisualInstance3D
{
    public enum SubdivEnum : long
    {
        /// <summary>
        /// <para>Use 64 subdivisions. This is the lowest quality setting, but the fastest. Use it if you can, but especially use it on lower-end hardware.</para>
        /// </summary>
        Subdiv64 = 0,
        /// <summary>
        /// <para>Use 128 subdivisions. This is the default quality setting.</para>
        /// </summary>
        Subdiv128 = 1,
        /// <summary>
        /// <para>Use 256 subdivisions.</para>
        /// </summary>
        Subdiv256 = 2,
        /// <summary>
        /// <para>Use 512 subdivisions. This is the highest quality setting, but the slowest. On lower-end hardware, this could cause the GPU to stall.</para>
        /// </summary>
        Subdiv512 = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VoxelGI.SubdivEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    /// <summary>
    /// <para>Number of times to subdivide the grid that the <see cref="Godot.VoxelGI"/> operates on. A higher number results in finer detail and thus higher visual quality, while lower numbers result in better performance.</para>
    /// </summary>
    public VoxelGI.SubdivEnum Subdiv
    {
        get
        {
            return GetSubdiv();
        }
        set
        {
            SetSubdiv(value);
        }
    }

    /// <summary>
    /// <para>The size of the area covered by the <see cref="Godot.VoxelGI"/>. This must be <c>1.0</c> or greater on each axis.</para>
    /// <para><b>Note:</b> If you make the size larger without increasing the number of subdivisions with <see cref="Godot.VoxelGI.Subdiv"/>, the size of each cell will increase and result in less detailed lighting.</para>
    /// </summary>
    public Vector3 Size
    {
        get
        {
            return GetSize();
        }
        set
        {
            SetSize(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.CameraAttributes"/> resource that specifies exposure levels to bake at. Auto-exposure and non exposure properties will be ignored. Exposure settings should be used to reduce the dynamic range present when baking. If exposure is too high, the <see cref="Godot.VoxelGI"/> will have banding artifacts or may have over-exposure artifacts.</para>
    /// </summary>
    public CameraAttributes CameraAttributes
    {
        get
        {
            return GetCameraAttributes();
        }
        set
        {
            SetCameraAttributes(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.VoxelGIData"/> resource that holds the data for this <see cref="Godot.VoxelGI"/>.</para>
    /// </summary>
    public VoxelGIData Data
    {
        get
        {
            return GetProbeData();
        }
        set
        {
            SetProbeData(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VoxelGI);

    private static readonly StringName NativeName = "VoxelGI";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VoxelGI() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal VoxelGI(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal VoxelGI(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProbeData, 1637849675ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProbeData(VoxelGIData data)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(data));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProbeData, 1730645405ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VoxelGIData GetProbeData()
    {
        return (VoxelGIData)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubdiv, 2240898472ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubdiv(VoxelGI.SubdivEnum subdiv)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)subdiv);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubdiv, 4261647950ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VoxelGI.SubdivEnum GetSubdiv()
    {
        return (VoxelGI.SubdivEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector3 size)
    {
        NativeCalls.godot_icall_1_177(MethodBind4, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetSize()
    {
        return NativeCalls.godot_icall_0_125(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCameraAttributes, 2817810567ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCameraAttributes(CameraAttributes cameraAttributes)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(cameraAttributes));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraAttributes, 3921283215ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CameraAttributes GetCameraAttributes()
    {
        return (CameraAttributes)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Bake, 2781551026ul);

    /// <summary>
    /// <para>Bakes the effect from all <see cref="Godot.GeometryInstance3D"/>s marked with <see cref="Godot.GeometryInstance3D.GIModeEnum.Static"/> and <see cref="Godot.Light3D"/>s marked with either <see cref="Godot.Light3D.BakeMode.Static"/> or <see cref="Godot.Light3D.BakeMode.Dynamic"/>. If <paramref name="createVisualDebug"/> is <see langword="true"/>, after baking the light, this will generate a <see cref="Godot.MultiMesh"/> that has a cube representing each solid cell with each cube colored to the cell's albedo color. This can be used to visualize the <see cref="Godot.VoxelGI"/>'s data and debug any issues that may be occurring.</para>
    /// <para><b>Note:</b> <see cref="Godot.VoxelGI.Bake(Node, bool)"/> works from the editor and in exported projects. This makes it suitable for procedurally generated or user-built levels. Baking a <see cref="Godot.VoxelGI"/> node generally takes from 5 to 20 seconds in most scenes. Reducing <see cref="Godot.VoxelGI.Subdiv"/> can speed up baking.</para>
    /// <para><b>Note:</b> <see cref="Godot.GeometryInstance3D"/>s and <see cref="Godot.Light3D"/>s must be fully ready before <see cref="Godot.VoxelGI.Bake(Node, bool)"/> is called. If you are procedurally creating those and some meshes or lights are missing from your baked <see cref="Godot.VoxelGI"/>, use <c>call_deferred("bake")</c> instead of calling <see cref="Godot.VoxelGI.Bake(Node, bool)"/> directly.</para>
    /// </summary>
    public void Bake(Node fromNode = default, bool createVisualDebug = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(fromNode), createVisualDebug.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DebugBake, 3218959716ul);

    /// <summary>
    /// <para>Calls <see cref="Godot.VoxelGI.Bake(Node, bool)"/> with <c>create_visual_debug</c> enabled.</para>
    /// </summary>
    public void DebugBake()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
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
        /// Cached name for the 'subdiv' property.
        /// </summary>
        public static readonly StringName Subdiv = "subdiv";
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'camera_attributes' property.
        /// </summary>
        public static readonly StringName CameraAttributes = "camera_attributes";
        /// <summary>
        /// Cached name for the 'data' property.
        /// </summary>
        public static readonly StringName Data = "data";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_probe_data' method.
        /// </summary>
        public static readonly StringName SetProbeData = "set_probe_data";
        /// <summary>
        /// Cached name for the 'get_probe_data' method.
        /// </summary>
        public static readonly StringName GetProbeData = "get_probe_data";
        /// <summary>
        /// Cached name for the 'set_subdiv' method.
        /// </summary>
        public static readonly StringName SetSubdiv = "set_subdiv";
        /// <summary>
        /// Cached name for the 'get_subdiv' method.
        /// </summary>
        public static readonly StringName GetSubdiv = "get_subdiv";
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'set_camera_attributes' method.
        /// </summary>
        public static readonly StringName SetCameraAttributes = "set_camera_attributes";
        /// <summary>
        /// Cached name for the 'get_camera_attributes' method.
        /// </summary>
        public static readonly StringName GetCameraAttributes = "get_camera_attributes";
        /// <summary>
        /// Cached name for the 'bake' method.
        /// </summary>
        public static readonly StringName Bake = "bake";
        /// <summary>
        /// Cached name for the 'debug_bake' method.
        /// </summary>
        public static readonly StringName DebugBake = "debug_bake";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
    }
}
