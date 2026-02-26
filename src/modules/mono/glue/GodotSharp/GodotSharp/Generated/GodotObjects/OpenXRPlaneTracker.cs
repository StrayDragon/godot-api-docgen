namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Spatial entity tracker for our OpenXR spatial entity plane tracking extension. These trackers identify entities in our real space such as walls, floors, tables, etc. and map their location to our virtual space.</para>
/// </summary>
public partial class OpenXRPlaneTracker : OpenXRSpatialEntityTracker
{
    /// <summary>
    /// <para>The bounding size of the plane. This is a 2D size.</para>
    /// </summary>
    public Vector2 BoundsSize
    {
        get
        {
            return GetBoundsSize();
        }
        set
        {
            SetBoundsSize(value);
        }
    }

    /// <summary>
    /// <para>The main alignment in space of this plane.</para>
    /// </summary>
    public OpenXRSpatialComponentPlaneAlignmentList.PlaneAlignment PlaneAlignment
    {
        get
        {
            return GetPlaneAlignment();
        }
        set
        {
            SetPlaneAlignment(value);
        }
    }

    /// <summary>
    /// <para>The semantic label for this plane.</para>
    /// </summary>
    public string PlaneLabel
    {
        get
        {
            return GetPlaneLabel();
        }
        set
        {
            SetPlaneLabel(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRPlaneTracker);

    private static readonly StringName NativeName = "OpenXRPlaneTracker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRPlaneTracker() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRPlaneTracker(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRPlaneTracker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoundsSize, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBoundsSize(Vector2 boundsSize)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &boundsSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoundsSize, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetBoundsSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaneAlignment, 1214382230ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlaneAlignment(OpenXRSpatialComponentPlaneAlignmentList.PlaneAlignment planeAlignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)planeAlignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaneAlignment, 845541441ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRSpatialComponentPlaneAlignmentList.PlaneAlignment GetPlaneAlignment()
    {
        return (OpenXRSpatialComponentPlaneAlignmentList.PlaneAlignment)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaneLabel, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlaneLabel(string planeLabel)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), planeLabel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaneLabel, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetPlaneLabel()
    {
        return NativeCalls.godot_icall_0_58(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMeshData, 1877193149ul);

    /// <summary>
    /// <para>Sets the mesh data for this plane. You should only call this if you are handling your own discovery logic.</para>
    /// </summary>
    /// <param name="indices">If the parameter is null, then the default value is <c>Array.Empty&lt;int&gt;()</c>.</param>
    public unsafe void SetMeshData(Transform3D origin, Vector2[] vertices, int[] indices = null)
    {
        int[] indicesOrDefVal = indices != null ? indices : Array.Empty<int>();
        NativeCalls.godot_icall_3_937(MethodBind6, GodotObject.GetPtr(this), &origin, vertices, indicesOrDefVal);
    }

    /// <summary>
    /// <para>Sets the mesh data for this plane. You should only call this if you are handling your own discovery logic.</para>
    /// </summary>
    public unsafe void SetMeshData(Transform3D origin, ReadOnlySpan<Vector2> vertices, ReadOnlySpan<int> indices)
    {
        NativeCalls.godot_icall_3_937(MethodBind6, GodotObject.GetPtr(this), &origin, vertices, indices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearMeshData, 3218959716ul);

    /// <summary>
    /// <para>Clears the mesh data for this tracker. You should only call this if you are handling your own discovery logic.</para>
    /// </summary>
    public void ClearMeshData()
    {
        NativeCalls.godot_icall_0_3(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMeshOffset, 3229777777ul);

    /// <summary>
    /// <para>Gets the transform by which to offset the mesh and collision shape from our pose to display these correctly.</para>
    /// </summary>
    public Transform3D GetMeshOffset()
    {
        return NativeCalls.godot_icall_0_192(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMesh, 4081188045ul);

    /// <summary>
    /// <para>Gets a mesh created from either the mesh data or from our bounding size for this plane.</para>
    /// </summary>
    public Mesh GetMesh()
    {
        return (Mesh)NativeCalls.godot_icall_0_63(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShape, 3358509884ul);

    /// <summary>
    /// <para>Gets a collision shape built either from the mesh data or from our bounding size for this plane.</para>
    /// </summary>
    public Shape3D GetShape(float thickness = 0.01f)
    {
        return (Shape3D)NativeCalls.godot_icall_1_791(MethodBind10, GodotObject.GetPtr(this), thickness);
    }

    /// <summary>
    /// <para>Emitted when our mesh data has changed the mesh instance and collision needs to be updated.</para>
    /// </summary>
    public event Action MeshChanged
    {
        add => Connect(SignalName.MeshChanged, Callable.From(value));
        remove => Disconnect(SignalName.MeshChanged, Callable.From(value));
    }

    protected void EmitSignalMeshChanged()
    {
        EmitSignal(SignalName.MeshChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mesh_changed = "MeshChanged";

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
        if (signal == SignalName.MeshChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_mesh_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : OpenXRSpatialEntityTracker.PropertyName
    {
        /// <summary>
        /// Cached name for the 'bounds_size' property.
        /// </summary>
        public static readonly StringName BoundsSize = "bounds_size";
        /// <summary>
        /// Cached name for the 'plane_alignment' property.
        /// </summary>
        public static readonly StringName PlaneAlignment = "plane_alignment";
        /// <summary>
        /// Cached name for the 'plane_label' property.
        /// </summary>
        public static readonly StringName PlaneLabel = "plane_label";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRSpatialEntityTracker.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_bounds_size' method.
        /// </summary>
        public static readonly StringName SetBoundsSize = "set_bounds_size";
        /// <summary>
        /// Cached name for the 'get_bounds_size' method.
        /// </summary>
        public static readonly StringName GetBoundsSize = "get_bounds_size";
        /// <summary>
        /// Cached name for the 'set_plane_alignment' method.
        /// </summary>
        public static readonly StringName SetPlaneAlignment = "set_plane_alignment";
        /// <summary>
        /// Cached name for the 'get_plane_alignment' method.
        /// </summary>
        public static readonly StringName GetPlaneAlignment = "get_plane_alignment";
        /// <summary>
        /// Cached name for the 'set_plane_label' method.
        /// </summary>
        public static readonly StringName SetPlaneLabel = "set_plane_label";
        /// <summary>
        /// Cached name for the 'get_plane_label' method.
        /// </summary>
        public static readonly StringName GetPlaneLabel = "get_plane_label";
        /// <summary>
        /// Cached name for the 'set_mesh_data' method.
        /// </summary>
        public static readonly StringName SetMeshData = "set_mesh_data";
        /// <summary>
        /// Cached name for the 'clear_mesh_data' method.
        /// </summary>
        public static readonly StringName ClearMeshData = "clear_mesh_data";
        /// <summary>
        /// Cached name for the 'get_mesh_offset' method.
        /// </summary>
        public static readonly StringName GetMeshOffset = "get_mesh_offset";
        /// <summary>
        /// Cached name for the 'get_mesh' method.
        /// </summary>
        public static readonly StringName GetMesh = "get_mesh";
        /// <summary>
        /// Cached name for the 'get_shape' method.
        /// </summary>
        public static readonly StringName GetShape = "get_shape";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRSpatialEntityTracker.SignalName
    {
        /// <summary>
        /// Cached name for the 'mesh_changed' signal.
        /// </summary>
        public static readonly StringName MeshChanged = "mesh_changed";
    }
}
