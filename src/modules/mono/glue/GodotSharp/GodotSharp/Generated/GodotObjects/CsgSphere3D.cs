namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node allows you to create a sphere for use with the CSG system.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="Godot.MeshInstance3D"/> with a <see cref="Godot.PrimitiveMesh"/>. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
[GodotClassName("CSGSphere3D")]
public partial class CsgSphere3D : CsgPrimitive3D
{
    /// <summary>
    /// <para>Radius of the sphere.</para>
    /// </summary>
    public float Radius
    {
        get
        {
            return GetRadius();
        }
        set
        {
            SetRadius(value);
        }
    }

    /// <summary>
    /// <para>Number of vertical slices for the sphere.</para>
    /// </summary>
    public int RadialSegments
    {
        get
        {
            return GetRadialSegments();
        }
        set
        {
            SetRadialSegments(value);
        }
    }

    /// <summary>
    /// <para>Number of horizontal slices for the sphere.</para>
    /// </summary>
    public int Rings
    {
        get
        {
            return GetRings();
        }
        set
        {
            SetRings(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> the normals of the sphere are set to give a smooth effect making the sphere seem rounded. If <see langword="false"/> the sphere will have a flat shaded look.</para>
    /// </summary>
    public bool SmoothFaces
    {
        get
        {
            return GetSmoothFaces();
        }
        set
        {
            SetSmoothFaces(value);
        }
    }

    /// <summary>
    /// <para>The material used to render the sphere.</para>
    /// </summary>
    public Material Material
    {
        get
        {
            return GetMaterial();
        }
        set
        {
            SetMaterial(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CsgSphere3D);

    private static readonly StringName NativeName = "CSGSphere3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CsgSphere3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CsgSphere3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CsgSphere3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadialSegments, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadialSegments(int radialSegments)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), radialSegments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadialSegments, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRadialSegments()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRings, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRings(int rings)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), rings);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRings, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRings()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSmoothFaces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSmoothFaces(bool smoothFaces)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), smoothFaces.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSmoothFaces, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSmoothFaces()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaterial, 2757459619ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaterial(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaterial, 5934680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Material GetMaterial()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind9, GodotObject.GetPtr(this));
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
    public new class PropertyName : CsgPrimitive3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'radius' property.
        /// </summary>
        public static readonly StringName Radius = "radius";
        /// <summary>
        /// Cached name for the 'radial_segments' property.
        /// </summary>
        public static readonly StringName RadialSegments = "radial_segments";
        /// <summary>
        /// Cached name for the 'rings' property.
        /// </summary>
        public static readonly StringName Rings = "rings";
        /// <summary>
        /// Cached name for the 'smooth_faces' property.
        /// </summary>
        public static readonly StringName SmoothFaces = "smooth_faces";
        /// <summary>
        /// Cached name for the 'material' property.
        /// </summary>
        public static readonly StringName Material = "material";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CsgPrimitive3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_radius' method.
        /// </summary>
        public static readonly StringName SetRadius = "set_radius";
        /// <summary>
        /// Cached name for the 'get_radius' method.
        /// </summary>
        public static readonly StringName GetRadius = "get_radius";
        /// <summary>
        /// Cached name for the 'set_radial_segments' method.
        /// </summary>
        public static readonly StringName SetRadialSegments = "set_radial_segments";
        /// <summary>
        /// Cached name for the 'get_radial_segments' method.
        /// </summary>
        public static readonly StringName GetRadialSegments = "get_radial_segments";
        /// <summary>
        /// Cached name for the 'set_rings' method.
        /// </summary>
        public static readonly StringName SetRings = "set_rings";
        /// <summary>
        /// Cached name for the 'get_rings' method.
        /// </summary>
        public static readonly StringName GetRings = "get_rings";
        /// <summary>
        /// Cached name for the 'set_smooth_faces' method.
        /// </summary>
        public static readonly StringName SetSmoothFaces = "set_smooth_faces";
        /// <summary>
        /// Cached name for the 'get_smooth_faces' method.
        /// </summary>
        public static readonly StringName GetSmoothFaces = "get_smooth_faces";
        /// <summary>
        /// Cached name for the 'set_material' method.
        /// </summary>
        public static readonly StringName SetMaterial = "set_material";
        /// <summary>
        /// Cached name for the 'get_material' method.
        /// </summary>
        public static readonly StringName GetMaterial = "get_material";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CsgPrimitive3D.SignalName
    {
    }
}
