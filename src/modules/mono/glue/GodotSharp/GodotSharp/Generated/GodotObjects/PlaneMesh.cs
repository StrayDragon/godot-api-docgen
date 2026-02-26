namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Class representing a planar <see cref="Godot.PrimitiveMesh"/>. This flat mesh does not have a thickness. By default, this mesh is aligned on the X and Z axes; this default rotation isn't suited for use with billboarded materials. For billboarded materials, change <see cref="Godot.PlaneMesh.Orientation"/> to <see cref="Godot.PlaneMesh.OrientationEnum.Z"/>.</para>
/// <para><b>Note:</b> When using a large textured <see cref="Godot.PlaneMesh"/> (e.g. as a floor), you may stumble upon UV jittering issues depending on the camera angle. To solve this, increase <see cref="Godot.PlaneMesh.SubdivideDepth"/> and <see cref="Godot.PlaneMesh.SubdivideWidth"/> until you no longer notice UV jittering.</para>
/// </summary>
public partial class PlaneMesh : PrimitiveMesh
{
    public enum OrientationEnum : long
    {
        /// <summary>
        /// <para><see cref="Godot.PlaneMesh"/> will face the positive X-axis.</para>
        /// </summary>
        X = 0,
        /// <summary>
        /// <para><see cref="Godot.PlaneMesh"/> will face the positive Y-axis. This matches the behavior of the <see cref="Godot.PlaneMesh"/> in Godot 3.x.</para>
        /// </summary>
        Y = 1,
        /// <summary>
        /// <para><see cref="Godot.PlaneMesh"/> will face the positive Z-axis. This matches the behavior of the QuadMesh in Godot 3.x.</para>
        /// </summary>
        Z = 2
    }

    /// <summary>
    /// <para>Size of the generated plane.</para>
    /// </summary>
    public Vector2 Size
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
    /// <para>Number of subdivision along the X axis.</para>
    /// </summary>
    public int SubdivideWidth
    {
        get
        {
            return GetSubdivideWidth();
        }
        set
        {
            SetSubdivideWidth(value);
        }
    }

    /// <summary>
    /// <para>Number of subdivision along the Z axis.</para>
    /// </summary>
    public int SubdivideDepth
    {
        get
        {
            return GetSubdivideDepth();
        }
        set
        {
            SetSubdivideDepth(value);
        }
    }

    /// <summary>
    /// <para>Offset of the generated plane. Useful for particles.</para>
    /// </summary>
    public Vector3 CenterOffset
    {
        get
        {
            return GetCenterOffset();
        }
        set
        {
            SetCenterOffset(value);
        }
    }

    /// <summary>
    /// <para>Direction that the <see cref="Godot.PlaneMesh"/> is facing.</para>
    /// </summary>
    public PlaneMesh.OrientationEnum Orientation
    {
        get
        {
            return GetOrientation();
        }
        set
        {
            SetOrientation(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PlaneMesh);

    private static readonly StringName NativeName = "PlaneMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PlaneMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PlaneMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PlaneMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector2 size)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubdivideWidth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubdivideWidth(int subdivide)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), subdivide);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubdivideWidth, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSubdivideWidth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubdivideDepth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubdivideDepth(int subdivide)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), subdivide);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubdivideDepth, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSubdivideDepth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterOffset, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCenterOffset(Vector3 offset)
    {
        NativeCalls.godot_icall_1_177(MethodBind6, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterOffset, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetCenterOffset()
    {
        return NativeCalls.godot_icall_0_125(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOrientation, 2751399687ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOrientation(PlaneMesh.OrientationEnum orientation)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOrientation, 3227599250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public PlaneMesh.OrientationEnum GetOrientation()
    {
        return (PlaneMesh.OrientationEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
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
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'subdivide_width' property.
        /// </summary>
        public static readonly StringName SubdivideWidth = "subdivide_width";
        /// <summary>
        /// Cached name for the 'subdivide_depth' property.
        /// </summary>
        public static readonly StringName SubdivideDepth = "subdivide_depth";
        /// <summary>
        /// Cached name for the 'center_offset' property.
        /// </summary>
        public static readonly StringName CenterOffset = "center_offset";
        /// <summary>
        /// Cached name for the 'orientation' property.
        /// </summary>
        public static readonly StringName Orientation = "orientation";
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
        /// Cached name for the 'set_subdivide_width' method.
        /// </summary>
        public static readonly StringName SetSubdivideWidth = "set_subdivide_width";
        /// <summary>
        /// Cached name for the 'get_subdivide_width' method.
        /// </summary>
        public static readonly StringName GetSubdivideWidth = "get_subdivide_width";
        /// <summary>
        /// Cached name for the 'set_subdivide_depth' method.
        /// </summary>
        public static readonly StringName SetSubdivideDepth = "set_subdivide_depth";
        /// <summary>
        /// Cached name for the 'get_subdivide_depth' method.
        /// </summary>
        public static readonly StringName GetSubdivideDepth = "get_subdivide_depth";
        /// <summary>
        /// Cached name for the 'set_center_offset' method.
        /// </summary>
        public static readonly StringName SetCenterOffset = "set_center_offset";
        /// <summary>
        /// Cached name for the 'get_center_offset' method.
        /// </summary>
        public static readonly StringName GetCenterOffset = "get_center_offset";
        /// <summary>
        /// Cached name for the 'set_orientation' method.
        /// </summary>
        public static readonly StringName SetOrientation = "set_orientation";
        /// <summary>
        /// Cached name for the 'get_orientation' method.
        /// </summary>
        public static readonly StringName GetOrientation = "get_orientation";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PrimitiveMesh.SignalName
    {
    }
}
