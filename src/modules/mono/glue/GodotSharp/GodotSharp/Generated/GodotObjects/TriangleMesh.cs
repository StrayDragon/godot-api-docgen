namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Creates a bounding volume hierarchy (BVH) tree structure around triangle geometry.</para>
/// <para>The triangle BVH tree can be used for efficient intersection queries without involving a physics engine.</para>
/// <para>For example, this can be used in editor tools to select objects with complex shapes based on the mouse cursor position.</para>
/// <para><b>Performance:</b> Creating the BVH tree for complex geometry is a slow process and best done in a background thread.</para>
/// </summary>
public partial class TriangleMesh : RefCounted
{
    private static readonly System.Type CachedType = typeof(TriangleMesh);

    private static readonly StringName NativeName = "TriangleMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TriangleMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TriangleMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TriangleMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromFaces, 2637816732ul);

    /// <summary>
    /// <para>Creates the BVH tree from an array of faces. Each 3 vertices of the input <paramref name="faces"/> array represent one triangle (face).</para>
    /// <para>Returns <see langword="true"/> if the tree is successfully built, <see langword="false"/> otherwise.</para>
    /// </summary>
    public bool CreateFromFaces(Vector3[] faces)
    {
        return NativeCalls.godot_icall_1_1482(MethodBind0, GodotObject.GetPtr(this), faces).ToBool();
    }

    /// <summary>
    /// <para>Creates the BVH tree from an array of faces. Each 3 vertices of the input <paramref name="faces"/> array represent one triangle (face).</para>
    /// <para>Returns <see langword="true"/> if the tree is successfully built, <see langword="false"/> otherwise.</para>
    /// </summary>
    public bool CreateFromFaces(ReadOnlySpan<Vector3> faces)
    {
        return NativeCalls.godot_icall_1_1482(MethodBind0, GodotObject.GetPtr(this), faces).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaces, 497664490ul);

    /// <summary>
    /// <para>Returns a copy of the geometry faces. Each 3 vertices of the array represent one triangle (face).</para>
    /// </summary>
    public Vector3[] GetFaces()
    {
        return NativeCalls.godot_icall_0_228(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IntersectSegment, 3648293151ul);

    /// <summary>
    /// <para>Tests for intersection with a segment going from <paramref name="begin"/> to <paramref name="end"/>.</para>
    /// <para>If an intersection with a triangle happens returns a <see cref="Godot.Collections.Dictionary"/> with the following fields:</para>
    /// <para><c>position</c>: The position on the intersected triangle.</para>
    /// <para><c>normal</c>: The normal of the intersected triangle.</para>
    /// <para><c>face_index</c>: The index of the intersected triangle.</para>
    /// <para>Returns an empty <see cref="Godot.Collections.Dictionary"/> if no intersection happens.</para>
    /// <para>See also <see cref="Godot.TriangleMesh.IntersectRay(Vector3, Vector3)"/>, which is similar but uses an infinite-length ray.</para>
    /// </summary>
    public unsafe Godot.Collections.Dictionary IntersectSegment(Vector3 begin, Vector3 end)
    {
        return NativeCalls.godot_icall_2_1483(MethodBind2, GodotObject.GetPtr(this), &begin, &end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IntersectRay, 3648293151ul);

    /// <summary>
    /// <para>Tests for intersection with a ray starting at <paramref name="begin"/> and facing <paramref name="dir"/> and extending toward infinity.</para>
    /// <para>If an intersection with a triangle happens, returns a <see cref="Godot.Collections.Dictionary"/> with the following fields:</para>
    /// <para><c>position</c>: The position on the intersected triangle.</para>
    /// <para><c>normal</c>: The normal of the intersected triangle.</para>
    /// <para><c>face_index</c>: The index of the intersected triangle.</para>
    /// <para>Returns an empty <see cref="Godot.Collections.Dictionary"/> if no intersection happens.</para>
    /// <para>See also <see cref="Godot.TriangleMesh.IntersectSegment(Vector3, Vector3)"/>, which is similar but uses a finite-length segment.</para>
    /// </summary>
    public unsafe Godot.Collections.Dictionary IntersectRay(Vector3 begin, Vector3 dir)
    {
        return NativeCalls.godot_icall_2_1483(MethodBind3, GodotObject.GetPtr(this), &begin, &dir);
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_from_faces' method.
        /// </summary>
        public static readonly StringName CreateFromFaces = "create_from_faces";
        /// <summary>
        /// Cached name for the 'get_faces' method.
        /// </summary>
        public static readonly StringName GetFaces = "get_faces";
        /// <summary>
        /// Cached name for the 'intersect_segment' method.
        /// </summary>
        public static readonly StringName IntersectSegment = "intersect_segment";
        /// <summary>
        /// Cached name for the 'intersect_ray' method.
        /// </summary>
        public static readonly StringName IntersectRay = "intersect_ray";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
