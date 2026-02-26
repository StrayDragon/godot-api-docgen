namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node allows you to create a torus for use with the CSG system.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="Godot.MeshInstance3D"/> with a <see cref="Godot.PrimitiveMesh"/>. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
[GodotClassName("CSGTorus3D")]
public partial class CsgTorus3D : CsgPrimitive3D
{
    /// <summary>
    /// <para>The inner radius of the torus.</para>
    /// </summary>
    public float InnerRadius
    {
        get
        {
            return GetInnerRadius();
        }
        set
        {
            SetInnerRadius(value);
        }
    }

    /// <summary>
    /// <para>The outer radius of the torus.</para>
    /// </summary>
    public float OuterRadius
    {
        get
        {
            return GetOuterRadius();
        }
        set
        {
            SetOuterRadius(value);
        }
    }

    /// <summary>
    /// <para>The number of slices the torus is constructed of.</para>
    /// </summary>
    public int Sides
    {
        get
        {
            return GetSides();
        }
        set
        {
            SetSides(value);
        }
    }

    /// <summary>
    /// <para>The number of edges each ring of the torus is constructed of.</para>
    /// </summary>
    public int RingSides
    {
        get
        {
            return GetRingSides();
        }
        set
        {
            SetRingSides(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> the normals of the torus are set to give a smooth effect making the torus seem rounded. If <see langword="false"/> the torus will have a flat shaded look.</para>
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
    /// <para>The material used to render the torus.</para>
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

    private static readonly System.Type CachedType = typeof(CsgTorus3D);

    private static readonly StringName NativeName = "CSGTorus3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CsgTorus3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CsgTorus3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CsgTorus3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInnerRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInnerRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInnerRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetInnerRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOuterRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOuterRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOuterRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetOuterRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSides, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSides(int sides)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), sides);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSides, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSides()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRingSides, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRingSides(int sides)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), sides);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRingSides, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRingSides()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
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

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSmoothFaces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSmoothFaces(bool smoothFaces)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), smoothFaces.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSmoothFaces, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSmoothFaces()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'inner_radius' property.
        /// </summary>
        public static readonly StringName InnerRadius = "inner_radius";
        /// <summary>
        /// Cached name for the 'outer_radius' property.
        /// </summary>
        public static readonly StringName OuterRadius = "outer_radius";
        /// <summary>
        /// Cached name for the 'sides' property.
        /// </summary>
        public static readonly StringName Sides = "sides";
        /// <summary>
        /// Cached name for the 'ring_sides' property.
        /// </summary>
        public static readonly StringName RingSides = "ring_sides";
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
        /// Cached name for the 'set_inner_radius' method.
        /// </summary>
        public static readonly StringName SetInnerRadius = "set_inner_radius";
        /// <summary>
        /// Cached name for the 'get_inner_radius' method.
        /// </summary>
        public static readonly StringName GetInnerRadius = "get_inner_radius";
        /// <summary>
        /// Cached name for the 'set_outer_radius' method.
        /// </summary>
        public static readonly StringName SetOuterRadius = "set_outer_radius";
        /// <summary>
        /// Cached name for the 'get_outer_radius' method.
        /// </summary>
        public static readonly StringName GetOuterRadius = "get_outer_radius";
        /// <summary>
        /// Cached name for the 'set_sides' method.
        /// </summary>
        public static readonly StringName SetSides = "set_sides";
        /// <summary>
        /// Cached name for the 'get_sides' method.
        /// </summary>
        public static readonly StringName GetSides = "get_sides";
        /// <summary>
        /// Cached name for the 'set_ring_sides' method.
        /// </summary>
        public static readonly StringName SetRingSides = "set_ring_sides";
        /// <summary>
        /// Cached name for the 'get_ring_sides' method.
        /// </summary>
        public static readonly StringName GetRingSides = "get_ring_sides";
        /// <summary>
        /// Cached name for the 'set_material' method.
        /// </summary>
        public static readonly StringName SetMaterial = "set_material";
        /// <summary>
        /// Cached name for the 'get_material' method.
        /// </summary>
        public static readonly StringName GetMaterial = "get_material";
        /// <summary>
        /// Cached name for the 'set_smooth_faces' method.
        /// </summary>
        public static readonly StringName SetSmoothFaces = "set_smooth_faces";
        /// <summary>
        /// Cached name for the 'get_smooth_faces' method.
        /// </summary>
        public static readonly StringName GetSmoothFaces = "get_smooth_faces";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CsgPrimitive3D.SignalName
    {
    }
}
