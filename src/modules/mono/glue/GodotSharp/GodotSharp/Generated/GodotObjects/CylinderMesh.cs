namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Class representing a cylindrical <see cref="Godot.PrimitiveMesh"/>. This class can be used to create cones by setting either the <see cref="Godot.CylinderMesh.TopRadius"/> or <see cref="Godot.CylinderMesh.BottomRadius"/> properties to <c>0.0</c>.</para>
/// </summary>
public partial class CylinderMesh : PrimitiveMesh
{
    /// <summary>
    /// <para>Top radius of the cylinder. If set to <c>0.0</c>, the top faces will not be generated, resulting in a conic shape. See also <see cref="Godot.CylinderMesh.CapTop"/>.</para>
    /// </summary>
    public float TopRadius
    {
        get
        {
            return GetTopRadius();
        }
        set
        {
            SetTopRadius(value);
        }
    }

    /// <summary>
    /// <para>Bottom radius of the cylinder. If set to <c>0.0</c>, the bottom faces will not be generated, resulting in a conic shape. See also <see cref="Godot.CylinderMesh.CapBottom"/>.</para>
    /// </summary>
    public float BottomRadius
    {
        get
        {
            return GetBottomRadius();
        }
        set
        {
            SetBottomRadius(value);
        }
    }

    /// <summary>
    /// <para>Full height of the cylinder.</para>
    /// </summary>
    public float Height
    {
        get
        {
            return GetHeight();
        }
        set
        {
            SetHeight(value);
        }
    }

    /// <summary>
    /// <para>Number of radial segments on the cylinder. Higher values result in a more detailed cylinder/cone at the cost of performance.</para>
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
    /// <para>Number of edge rings along the height of the cylinder. Changing <see cref="Godot.CylinderMesh.Rings"/> does not have any visual impact unless a shader or procedural mesh tool is used to alter the vertex data. Higher values result in more subdivisions, which can be used to create smoother-looking effects with shaders or procedural mesh tools (at the cost of performance). When not altering the vertex data using a shader or procedural mesh tool, <see cref="Godot.CylinderMesh.Rings"/> should be kept to its default value.</para>
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
    /// <para>If <see langword="true"/>, generates a cap at the top of the cylinder. This can be set to <see langword="false"/> to speed up generation and rendering when the cap is never seen by the camera. See also <see cref="Godot.CylinderMesh.TopRadius"/>.</para>
    /// <para><b>Note:</b> If <see cref="Godot.CylinderMesh.TopRadius"/> is <c>0.0</c>, cap generation is always skipped even if <see cref="Godot.CylinderMesh.CapTop"/> is <see langword="true"/>.</para>
    /// </summary>
    public bool CapTop
    {
        get
        {
            return IsCapTop();
        }
        set
        {
            SetCapTop(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, generates a cap at the bottom of the cylinder. This can be set to <see langword="false"/> to speed up generation and rendering when the cap is never seen by the camera. See also <see cref="Godot.CylinderMesh.BottomRadius"/>.</para>
    /// <para><b>Note:</b> If <see cref="Godot.CylinderMesh.BottomRadius"/> is <c>0.0</c>, cap generation is always skipped even if <see cref="Godot.CylinderMesh.CapBottom"/> is <see langword="true"/>.</para>
    /// </summary>
    public bool CapBottom
    {
        get
        {
            return IsCapBottom();
        }
        set
        {
            SetCapBottom(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CylinderMesh);

    private static readonly StringName NativeName = "CylinderMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CylinderMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CylinderMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CylinderMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTopRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTopRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTopRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTopRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBottomRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBottomRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBottomRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBottomRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeight, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHeight(float height)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeight, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadialSegments, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadialSegments(int segments)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), segments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadialSegments, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRadialSegments()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRings, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRings(int rings)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), rings);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRings, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRings()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCapTop, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCapTop(bool capTop)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), capTop.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCapTop, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCapTop()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCapBottom, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCapBottom(bool capBottom)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), capBottom.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCapBottom, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCapBottom()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : PrimitiveMesh.PropertyName
    {
        /// <summary>
        /// Cached name for the 'top_radius' property.
        /// </summary>
        public static readonly StringName TopRadius = "top_radius";
        /// <summary>
        /// Cached name for the 'bottom_radius' property.
        /// </summary>
        public static readonly StringName BottomRadius = "bottom_radius";
        /// <summary>
        /// Cached name for the 'height' property.
        /// </summary>
        public static readonly StringName Height = "height";
        /// <summary>
        /// Cached name for the 'radial_segments' property.
        /// </summary>
        public static readonly StringName RadialSegments = "radial_segments";
        /// <summary>
        /// Cached name for the 'rings' property.
        /// </summary>
        public static readonly StringName Rings = "rings";
        /// <summary>
        /// Cached name for the 'cap_top' property.
        /// </summary>
        public static readonly StringName CapTop = "cap_top";
        /// <summary>
        /// Cached name for the 'cap_bottom' property.
        /// </summary>
        public static readonly StringName CapBottom = "cap_bottom";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PrimitiveMesh.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_top_radius' method.
        /// </summary>
        public static readonly StringName SetTopRadius = "set_top_radius";
        /// <summary>
        /// Cached name for the 'get_top_radius' method.
        /// </summary>
        public static readonly StringName GetTopRadius = "get_top_radius";
        /// <summary>
        /// Cached name for the 'set_bottom_radius' method.
        /// </summary>
        public static readonly StringName SetBottomRadius = "set_bottom_radius";
        /// <summary>
        /// Cached name for the 'get_bottom_radius' method.
        /// </summary>
        public static readonly StringName GetBottomRadius = "get_bottom_radius";
        /// <summary>
        /// Cached name for the 'set_height' method.
        /// </summary>
        public static readonly StringName SetHeight = "set_height";
        /// <summary>
        /// Cached name for the 'get_height' method.
        /// </summary>
        public static readonly StringName GetHeight = "get_height";
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
        /// Cached name for the 'set_cap_top' method.
        /// </summary>
        public static readonly StringName SetCapTop = "set_cap_top";
        /// <summary>
        /// Cached name for the 'is_cap_top' method.
        /// </summary>
        public static readonly StringName IsCapTop = "is_cap_top";
        /// <summary>
        /// Cached name for the 'set_cap_bottom' method.
        /// </summary>
        public static readonly StringName SetCapBottom = "set_cap_bottom";
        /// <summary>
        /// Cached name for the 'is_cap_bottom' method.
        /// </summary>
        public static readonly StringName IsCapBottom = "is_cap_bottom";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PrimitiveMesh.SignalName
    {
    }
}
