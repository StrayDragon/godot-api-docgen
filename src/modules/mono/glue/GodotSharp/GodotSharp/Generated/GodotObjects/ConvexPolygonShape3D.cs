namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 3D convex polyhedron shape, intended for use in physics. Usually used to provide a shape for a <see cref="Godot.CollisionShape3D"/>.</para>
/// <para><see cref="Godot.ConvexPolygonShape3D"/> is <i>solid</i>, which means it detects collisions from objects that are fully inside it, unlike <see cref="Godot.ConcavePolygonShape3D"/> which is hollow. This makes it more suitable for both detection and physics.</para>
/// <para><b>Convex decomposition:</b> A concave polyhedron can be split up into several convex polyhedra. This allows dynamic physics bodies to have complex concave collisions (at a performance cost) and can be achieved by using several <see cref="Godot.ConvexPolygonShape3D"/> nodes. To generate a convex decomposition from a mesh, select the <see cref="Godot.MeshInstance3D"/> node, go to the <b>Mesh</b> menu that appears above the viewport, and choose <b>Create Multiple Convex Collision Siblings</b>. Alternatively, <see cref="Godot.MeshInstance3D.CreateMultipleConvexCollisions(MeshConvexDecompositionSettings)"/> can be called in a script to perform this decomposition at run-time.</para>
/// <para><b>Performance:</b> <see cref="Godot.ConvexPolygonShape3D"/> is faster to check collisions against compared to <see cref="Godot.ConcavePolygonShape3D"/>, but it is slower than primitive collision shapes such as <see cref="Godot.SphereShape3D"/> and <see cref="Godot.BoxShape3D"/>. Its use should generally be limited to medium-sized objects that cannot have their collision accurately represented by primitive shapes.</para>
/// </summary>
public partial class ConvexPolygonShape3D : Shape3D
{
    /// <summary>
    /// <para>The list of 3D points forming the convex polygon shape.</para>
    /// </summary>
    public Vector3[] Points
    {
        get
        {
            return GetPoints();
        }
        set
        {
            SetPoints(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ConvexPolygonShape3D);

    private static readonly StringName NativeName = "ConvexPolygonShape3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ConvexPolygonShape3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ConvexPolygonShape3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ConvexPolygonShape3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPoints, 334873810ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPoints(Vector3[] points)
    {
        NativeCalls.godot_icall_1_187(MethodBind0, GodotObject.GetPtr(this), points);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPoints(ReadOnlySpan<Vector3> points)
    {
        NativeCalls.godot_icall_1_187(MethodBind0, GodotObject.GetPtr(this), points);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPoints, 497664490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3[] GetPoints()
    {
        return NativeCalls.godot_icall_0_228(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : Shape3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'points' property.
        /// </summary>
        public static readonly StringName Points = "points";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Shape3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_points' method.
        /// </summary>
        public static readonly StringName SetPoints = "set_points";
        /// <summary>
        /// Cached name for the 'get_points' method.
        /// </summary>
        public static readonly StringName GetPoints = "get_points";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Shape3D.SignalName
    {
    }
}
