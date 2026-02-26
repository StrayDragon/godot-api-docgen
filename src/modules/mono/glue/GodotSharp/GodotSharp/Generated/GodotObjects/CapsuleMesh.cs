namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Class representing a capsule-shaped <see cref="Godot.PrimitiveMesh"/>.</para>
/// </summary>
public partial class CapsuleMesh : PrimitiveMesh
{
    /// <summary>
    /// <para>Radius of the capsule mesh.</para>
    /// <para><b>Note:</b> The <see cref="Godot.CapsuleMesh.Radius"/> of a capsule cannot be greater than half of its <see cref="Godot.CapsuleMesh.Height"/>. Otherwise, the capsule becomes a circle. If the <see cref="Godot.CapsuleMesh.Radius"/> is greater than half of the <see cref="Godot.CapsuleMesh.Height"/>, the properties adjust to a valid value.</para>
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
    /// <para>Total height of the capsule mesh (including the hemispherical ends).</para>
    /// <para><b>Note:</b> The <see cref="Godot.CapsuleMesh.Height"/> of a capsule must be at least twice its <see cref="Godot.CapsuleMesh.Radius"/>. Otherwise, the capsule becomes a circle. If the <see cref="Godot.CapsuleMesh.Height"/> is less than twice the <see cref="Godot.CapsuleMesh.Radius"/>, the properties adjust to a valid value.</para>
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
    /// <para>Number of radial segments on the capsule mesh.</para>
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
    /// <para>Number of rings along the height of the capsule.</para>
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

    private static readonly System.Type CachedType = typeof(CapsuleMesh);

    private static readonly StringName NativeName = "CapsuleMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CapsuleMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CapsuleMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CapsuleMesh(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeight, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHeight(float height)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeight, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadialSegments, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadialSegments(int segments)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), segments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadialSegments, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRadialSegments()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRings, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRings(int rings)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), rings);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRings, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRings()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
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
        /// Cached name for the 'radius' property.
        /// </summary>
        public static readonly StringName Radius = "radius";
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PrimitiveMesh.MethodName
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
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PrimitiveMesh.SignalName
    {
    }
}
