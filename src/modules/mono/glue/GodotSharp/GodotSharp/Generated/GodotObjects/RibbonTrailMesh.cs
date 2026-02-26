namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.RibbonTrailMesh"/> represents a straight ribbon-shaped mesh with variable width. The ribbon is composed of a number of flat or cross-shaped sections, each with the same <see cref="Godot.RibbonTrailMesh.SectionLength"/> and number of <see cref="Godot.RibbonTrailMesh.SectionSegments"/>. A <see cref="Godot.RibbonTrailMesh.Curve"/> is sampled along the total length of the ribbon, meaning that the curve determines the size of the ribbon along its length.</para>
/// <para>This primitive mesh is usually used for particle trails.</para>
/// </summary>
public partial class RibbonTrailMesh : PrimitiveMesh
{
    public enum ShapeEnum : long
    {
        /// <summary>
        /// <para>Gives the mesh a single flat face.</para>
        /// </summary>
        Flat = 0,
        /// <summary>
        /// <para>Gives the mesh two perpendicular flat faces, making a cross shape.</para>
        /// </summary>
        Cross = 1
    }

    /// <summary>
    /// <para>Determines the shape of the ribbon.</para>
    /// </summary>
    public RibbonTrailMesh.ShapeEnum Shape
    {
        get
        {
            return GetShape();
        }
        set
        {
            SetShape(value);
        }
    }

    /// <summary>
    /// <para>The baseline size of the ribbon. The size of a particular section segment is obtained by multiplying this size by the value of the <see cref="Godot.RibbonTrailMesh.Curve"/> at the given distance.</para>
    /// </summary>
    public float Size
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
    /// <para>The total number of sections on the ribbon.</para>
    /// </summary>
    public int Sections
    {
        get
        {
            return GetSections();
        }
        set
        {
            SetSections(value);
        }
    }

    /// <summary>
    /// <para>The length of a section of the ribbon.</para>
    /// </summary>
    public float SectionLength
    {
        get
        {
            return GetSectionLength();
        }
        set
        {
            SetSectionLength(value);
        }
    }

    /// <summary>
    /// <para>The number of segments in a section. The <see cref="Godot.RibbonTrailMesh.Curve"/> is sampled on each segment to determine its size. Higher values result in a more detailed ribbon at the cost of performance.</para>
    /// </summary>
    public int SectionSegments
    {
        get
        {
            return GetSectionSegments();
        }
        set
        {
            SetSectionSegments(value);
        }
    }

    /// <summary>
    /// <para>Determines the size of the ribbon along its length. The size of a particular section segment is obtained by multiplying the baseline <see cref="Godot.RibbonTrailMesh.Size"/> by the value of this curve at the given distance. For values smaller than <c>0</c>, the faces will be inverted. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve Curve
    {
        get
        {
            return GetCurve();
        }
        set
        {
            SetCurve(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RibbonTrailMesh);

    private static readonly StringName NativeName = "RibbonTrailMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RibbonTrailMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RibbonTrailMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RibbonTrailMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSize(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSections, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSections(int sections)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), sections);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSections, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSections()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSectionLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSectionLength(float sectionLength)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), sectionLength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSectionLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSectionLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSectionSegments, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSectionSegments(int sectionSegments)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), sectionSegments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSectionSegments, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSectionSegments()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurve, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurve(Curve curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurve, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetCurve()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShape, 1684440262ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShape(RibbonTrailMesh.ShapeEnum shape)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShape, 1317484155ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RibbonTrailMesh.ShapeEnum GetShape()
    {
        return (RibbonTrailMesh.ShapeEnum)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
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
        /// Cached name for the 'shape' property.
        /// </summary>
        public static readonly StringName Shape = "shape";
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'sections' property.
        /// </summary>
        public static readonly StringName Sections = "sections";
        /// <summary>
        /// Cached name for the 'section_length' property.
        /// </summary>
        public static readonly StringName SectionLength = "section_length";
        /// <summary>
        /// Cached name for the 'section_segments' property.
        /// </summary>
        public static readonly StringName SectionSegments = "section_segments";
        /// <summary>
        /// Cached name for the 'curve' property.
        /// </summary>
        public static readonly StringName Curve = "curve";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PrimitiveMesh.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'set_sections' method.
        /// </summary>
        public static readonly StringName SetSections = "set_sections";
        /// <summary>
        /// Cached name for the 'get_sections' method.
        /// </summary>
        public static readonly StringName GetSections = "get_sections";
        /// <summary>
        /// Cached name for the 'set_section_length' method.
        /// </summary>
        public static readonly StringName SetSectionLength = "set_section_length";
        /// <summary>
        /// Cached name for the 'get_section_length' method.
        /// </summary>
        public static readonly StringName GetSectionLength = "get_section_length";
        /// <summary>
        /// Cached name for the 'set_section_segments' method.
        /// </summary>
        public static readonly StringName SetSectionSegments = "set_section_segments";
        /// <summary>
        /// Cached name for the 'get_section_segments' method.
        /// </summary>
        public static readonly StringName GetSectionSegments = "get_section_segments";
        /// <summary>
        /// Cached name for the 'set_curve' method.
        /// </summary>
        public static readonly StringName SetCurve = "set_curve";
        /// <summary>
        /// Cached name for the 'get_curve' method.
        /// </summary>
        public static readonly StringName GetCurve = "get_curve";
        /// <summary>
        /// Cached name for the 'set_shape' method.
        /// </summary>
        public static readonly StringName SetShape = "set_shape";
        /// <summary>
        /// Cached name for the 'get_shape' method.
        /// </summary>
        public static readonly StringName GetShape = "get_shape";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PrimitiveMesh.SignalName
    {
    }
}
