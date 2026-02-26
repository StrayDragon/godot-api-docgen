namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A mesh type optimized for creating geometry manually, similar to OpenGL 1.x immediate mode.</para>
/// <para>Here's a sample on how to generate a triangular face:</para>
/// <para><code>
/// var mesh = new ImmediateMesh();
/// mesh.SurfaceBegin(Mesh.PrimitiveType.Triangles);
/// mesh.SurfaceAddVertex(Vector3.Left);
/// mesh.SurfaceAddVertex(Vector3.Forward);
/// mesh.SurfaceAddVertex(Vector3.Zero);
/// mesh.SurfaceEnd();
/// </code></para>
/// <para><b>Note:</b> Generating complex geometries with <see cref="Godot.ImmediateMesh"/> is highly inefficient. Instead, it is designed to generate simple geometry that changes often.</para>
/// </summary>
public partial class ImmediateMesh : Mesh
{
    private static readonly System.Type CachedType = typeof(ImmediateMesh);

    private static readonly StringName NativeName = "ImmediateMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ImmediateMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImmediateMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImmediateMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceBegin, 2794442543ul);

    /// <summary>
    /// <para>Begin a new surface.</para>
    /// </summary>
    public void SurfaceBegin(Mesh.PrimitiveType primitive, Material material = null)
    {
        NativeCalls.godot_icall_2_70(MethodBind0, GodotObject.GetPtr(this), (int)primitive, GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceSetColor, 2920490490ul);

    /// <summary>
    /// <para>Set the color attribute that will be pushed with the next vertex.</para>
    /// </summary>
    public unsafe void SurfaceSetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind1, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceSetNormal, 3460891852ul);

    /// <summary>
    /// <para>Set the normal attribute that will be pushed with the next vertex.</para>
    /// </summary>
    public unsafe void SurfaceSetNormal(Vector3 normal)
    {
        NativeCalls.godot_icall_1_177(MethodBind2, GodotObject.GetPtr(this), &normal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceSetTangent, 3505987427ul);

    /// <summary>
    /// <para>Set the tangent attribute that will be pushed with the next vertex.</para>
    /// <para><b>Note:</b> Even though <paramref name="tangent"/> is a <see cref="Godot.Plane"/>, it does not directly represent the tangent plane. Its <c>Plane.x</c>, <c>Plane.y</c>, and <c>Plane.z</c> represent the tangent vector and <c>Plane.d</c> should be either <c>-1</c> or <c>1</c>. See also <see cref="Godot.Mesh.ArrayType.Tangent"/>.</para>
    /// </summary>
    public unsafe void SurfaceSetTangent(Plane tangent)
    {
        NativeCalls.godot_icall_1_741(MethodBind3, GodotObject.GetPtr(this), &tangent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceSetUV, 743155724ul);

    /// <summary>
    /// <para>Set the UV attribute that will be pushed with the next vertex.</para>
    /// </summary>
    public unsafe void SurfaceSetUV(Vector2 uV)
    {
        NativeCalls.godot_icall_1_36(MethodBind4, GodotObject.GetPtr(this), &uV);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceSetUV2, 743155724ul);

    /// <summary>
    /// <para>Set the UV2 attribute that will be pushed with the next vertex.</para>
    /// </summary>
    public unsafe void SurfaceSetUV2(Vector2 uV2)
    {
        NativeCalls.godot_icall_1_36(MethodBind5, GodotObject.GetPtr(this), &uV2);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceAddVertex, 3460891852ul);

    /// <summary>
    /// <para>Add a 3D vertex using the current attributes previously set.</para>
    /// </summary>
    public unsafe void SurfaceAddVertex(Vector3 vertex)
    {
        NativeCalls.godot_icall_1_177(MethodBind6, GodotObject.GetPtr(this), &vertex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceAddVertex2D, 743155724ul);

    /// <summary>
    /// <para>Add a 2D vertex using the current attributes previously set.</para>
    /// </summary>
    public unsafe void SurfaceAddVertex2D(Vector2 vertex)
    {
        NativeCalls.godot_icall_1_36(MethodBind7, GodotObject.GetPtr(this), &vertex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceEnd, 3218959716ul);

    /// <summary>
    /// <para>End and commit current surface. Note that surface being created will not be visible until this function is called.</para>
    /// </summary>
    public void SurfaceEnd()
    {
        NativeCalls.godot_icall_0_3(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearSurfaces, 3218959716ul);

    /// <summary>
    /// <para>Clear all surfaces.</para>
    /// </summary>
    public void ClearSurfaces()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
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
    public new class PropertyName : Mesh.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Mesh.MethodName
    {
        /// <summary>
        /// Cached name for the 'surface_begin' method.
        /// </summary>
        public static readonly StringName SurfaceBegin = "surface_begin";
        /// <summary>
        /// Cached name for the 'surface_set_color' method.
        /// </summary>
        public static readonly StringName SurfaceSetColor = "surface_set_color";
        /// <summary>
        /// Cached name for the 'surface_set_normal' method.
        /// </summary>
        public static readonly StringName SurfaceSetNormal = "surface_set_normal";
        /// <summary>
        /// Cached name for the 'surface_set_tangent' method.
        /// </summary>
        public static readonly StringName SurfaceSetTangent = "surface_set_tangent";
        /// <summary>
        /// Cached name for the 'surface_set_uv' method.
        /// </summary>
        public static readonly StringName SurfaceSetUV = "surface_set_uv";
        /// <summary>
        /// Cached name for the 'surface_set_uv2' method.
        /// </summary>
        public static readonly StringName SurfaceSetUV2 = "surface_set_uv2";
        /// <summary>
        /// Cached name for the 'surface_add_vertex' method.
        /// </summary>
        public static readonly StringName SurfaceAddVertex = "surface_add_vertex";
        /// <summary>
        /// Cached name for the 'surface_add_vertex_2d' method.
        /// </summary>
        public static readonly StringName SurfaceAddVertex2D = "surface_add_vertex_2d";
        /// <summary>
        /// Cached name for the 'surface_end' method.
        /// </summary>
        public static readonly StringName SurfaceEnd = "surface_end";
        /// <summary>
        /// Cached name for the 'clear_surfaces' method.
        /// </summary>
        public static readonly StringName ClearSurfaces = "clear_surfaces";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Mesh.SignalName
    {
    }
}
