namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 3D trimesh shape, intended for use in physics. Usually used to provide a shape for a <see cref="Godot.CollisionShape3D"/>.</para>
/// <para>Being just a collection of interconnected triangles, <see cref="Godot.ConcavePolygonShape3D"/> is the most freely configurable single 3D shape. It can be used to form polyhedra of any nature, or even shapes that don't enclose a volume. However, <see cref="Godot.ConcavePolygonShape3D"/> is <i>hollow</i> even if the interconnected triangles do enclose a volume, which often makes it unsuitable for physics or detection.</para>
/// <para><b>Note:</b> When used for collision, <see cref="Godot.ConcavePolygonShape3D"/> is intended to work with static <see cref="Godot.CollisionShape3D"/> nodes like <see cref="Godot.StaticBody3D"/> and will likely not behave well for <see cref="Godot.CharacterBody3D"/>s or <see cref="Godot.RigidBody3D"/>s in a mode other than Static.</para>
/// <para><b>Warning:</b> Physics bodies that are small have a chance to clip through this shape when moving fast. This happens because on one frame, the physics body may be on the "outside" of the shape, and on the next frame it may be "inside" it. <see cref="Godot.ConcavePolygonShape3D"/> is hollow, so it won't detect a collision.</para>
/// <para><b>Performance:</b> Due to its complexity, <see cref="Godot.ConcavePolygonShape3D"/> is the slowest 3D collision shape to check collisions against. Its use should generally be limited to level geometry. For convex geometry, <see cref="Godot.ConvexPolygonShape3D"/> should be used. For dynamic physics bodies that need concave collision, several <see cref="Godot.ConvexPolygonShape3D"/>s can be used to represent its collision by using convex decomposition; see <see cref="Godot.ConvexPolygonShape3D"/>'s documentation for instructions.</para>
/// </summary>
public partial class ConcavePolygonShape3D : Shape3D
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector3[] Data
    {
        get
        {
            return GetFaces();
        }
        set
        {
            SetFaces(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>If set to <see langword="true"/>, collisions occur on both sides of the concave shape faces. Otherwise they occur only along the face normals.</para>
    /// </summary>
    public bool BackfaceCollision
    {
        get
        {
            return IsBackfaceCollisionEnabled();
        }
        set
        {
            SetBackfaceCollisionEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ConcavePolygonShape3D);

    private static readonly StringName NativeName = "ConcavePolygonShape3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ConcavePolygonShape3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ConcavePolygonShape3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ConcavePolygonShape3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFaces, 334873810ul);

    /// <summary>
    /// <para>Sets the faces of the trimesh shape from an array of vertices. The <paramref name="faces"/> array should be composed of triples such that each triple of vertices defines a triangle.</para>
    /// </summary>
    public void SetFaces(Vector3[] faces)
    {
        NativeCalls.godot_icall_1_187(MethodBind0, GodotObject.GetPtr(this), faces);
    }

    /// <summary>
    /// <para>Sets the faces of the trimesh shape from an array of vertices. The <paramref name="faces"/> array should be composed of triples such that each triple of vertices defines a triangle.</para>
    /// </summary>
    public void SetFaces(ReadOnlySpan<Vector3> faces)
    {
        NativeCalls.godot_icall_1_187(MethodBind0, GodotObject.GetPtr(this), faces);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaces, 497664490ul);

    /// <summary>
    /// <para>Returns the faces of the trimesh shape as an array of vertices. The array (of length divisible by three) is naturally divided into triples; each triple of vertices defines a triangle.</para>
    /// </summary>
    public Vector3[] GetFaces()
    {
        return NativeCalls.godot_icall_0_228(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackfaceCollisionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackfaceCollisionEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBackfaceCollisionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsBackfaceCollisionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'data' property.
        /// </summary>
        public static readonly StringName Data = "data";
        /// <summary>
        /// Cached name for the 'backface_collision' property.
        /// </summary>
        public static readonly StringName BackfaceCollision = "backface_collision";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Shape3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_faces' method.
        /// </summary>
        public static readonly StringName SetFaces = "set_faces";
        /// <summary>
        /// Cached name for the 'get_faces' method.
        /// </summary>
        public static readonly StringName GetFaces = "get_faces";
        /// <summary>
        /// Cached name for the 'set_backface_collision_enabled' method.
        /// </summary>
        public static readonly StringName SetBackfaceCollisionEnabled = "set_backface_collision_enabled";
        /// <summary>
        /// Cached name for the 'is_backface_collision_enabled' method.
        /// </summary>
        public static readonly StringName IsBackfaceCollisionEnabled = "is_backface_collision_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Shape3D.SignalName
    {
    }
}
