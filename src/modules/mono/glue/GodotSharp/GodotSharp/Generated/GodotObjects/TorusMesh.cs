namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Class representing a torus <see cref="Godot.PrimitiveMesh"/>.</para>
/// </summary>
public partial class TorusMesh : PrimitiveMesh
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
    /// <para>The number of edges each ring of the torus is constructed of.</para>
    /// </summary>
    public int RingSegments
    {
        get
        {
            return GetRingSegments();
        }
        set
        {
            SetRingSegments(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TorusMesh);

    private static readonly StringName NativeName = "TorusMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TorusMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TorusMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TorusMesh(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRingSegments, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRingSegments(int rings)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), rings);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRingSegments, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRingSegments()
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
        /// Cached name for the 'inner_radius' property.
        /// </summary>
        public static readonly StringName InnerRadius = "inner_radius";
        /// <summary>
        /// Cached name for the 'outer_radius' property.
        /// </summary>
        public static readonly StringName OuterRadius = "outer_radius";
        /// <summary>
        /// Cached name for the 'rings' property.
        /// </summary>
        public static readonly StringName Rings = "rings";
        /// <summary>
        /// Cached name for the 'ring_segments' property.
        /// </summary>
        public static readonly StringName RingSegments = "ring_segments";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PrimitiveMesh.MethodName
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
        /// Cached name for the 'set_rings' method.
        /// </summary>
        public static readonly StringName SetRings = "set_rings";
        /// <summary>
        /// Cached name for the 'get_rings' method.
        /// </summary>
        public static readonly StringName GetRings = "get_rings";
        /// <summary>
        /// Cached name for the 'set_ring_segments' method.
        /// </summary>
        public static readonly StringName SetRingSegments = "set_ring_segments";
        /// <summary>
        /// Cached name for the 'get_ring_segments' method.
        /// </summary>
        public static readonly StringName GetRingSegments = "get_ring_segments";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PrimitiveMesh.SignalName
    {
    }
}
