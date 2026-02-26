namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.ArrayOccluder3D"/> stores an arbitrary 3D polygon shape that can be used by the engine's occlusion culling system. This is analogous to <see cref="Godot.ArrayMesh"/>, but for occluders.</para>
/// <para>See <see cref="Godot.OccluderInstance3D"/>'s documentation for instructions on setting up occlusion culling.</para>
/// </summary>
public partial class ArrayOccluder3D : Occluder3D
{
    /// <summary>
    /// <para>The occluder's vertex positions in local 3D coordinates.</para>
    /// <para><b>Note:</b> The occluder is always updated after setting this value. If creating occluders procedurally, consider using <see cref="Godot.ArrayOccluder3D.SetArrays(Vector3[], int[])"/> instead to avoid updating the occluder twice when it's created.</para>
    /// </summary>
    public Vector3[] Vertices
    {
        get
        {
            return GetVertices();
        }
        set
        {
            SetVertices(value);
        }
    }

    /// <summary>
    /// <para>The occluder's index position. Indices determine which points from the <see cref="Godot.ArrayOccluder3D.Vertices"/> array should be drawn, and in which order.</para>
    /// <para><b>Note:</b> The occluder is always updated after setting this value. If creating occluders procedurally, consider using <see cref="Godot.ArrayOccluder3D.SetArrays(Vector3[], int[])"/> instead to avoid updating the occluder twice when it's created.</para>
    /// </summary>
    public int[] Indices
    {
        get
        {
            return GetIndices();
        }
        set
        {
            SetIndices(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ArrayOccluder3D);

    private static readonly StringName NativeName = "ArrayOccluder3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ArrayOccluder3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ArrayOccluder3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ArrayOccluder3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetArrays, 3233972621ul);

    /// <summary>
    /// <para>Sets <see cref="Godot.ArrayOccluder3D.Indices"/> and <see cref="Godot.ArrayOccluder3D.Vertices"/>, while updating the final occluder only once after both values are set.</para>
    /// </summary>
    public void SetArrays(Vector3[] vertices, int[] indices)
    {
        NativeCalls.godot_icall_2_186(MethodBind0, GodotObject.GetPtr(this), vertices, indices);
    }

    /// <summary>
    /// <para>Sets <see cref="Godot.ArrayOccluder3D.Indices"/> and <see cref="Godot.ArrayOccluder3D.Vertices"/>, while updating the final occluder only once after both values are set.</para>
    /// </summary>
    public void SetArrays(ReadOnlySpan<Vector3> vertices, ReadOnlySpan<int> indices)
    {
        NativeCalls.godot_icall_2_186(MethodBind0, GodotObject.GetPtr(this), vertices, indices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertices, 334873810ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertices(Vector3[] vertices)
    {
        NativeCalls.godot_icall_1_187(MethodBind1, GodotObject.GetPtr(this), vertices);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertices(ReadOnlySpan<Vector3> vertices)
    {
        NativeCalls.godot_icall_1_187(MethodBind1, GodotObject.GetPtr(this), vertices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndices, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIndices(int[] indices)
    {
        NativeCalls.godot_icall_1_150(MethodBind2, GodotObject.GetPtr(this), indices);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIndices(ReadOnlySpan<int> indices)
    {
        NativeCalls.godot_icall_1_150(MethodBind2, GodotObject.GetPtr(this), indices);
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
    public new class PropertyName : Occluder3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'vertices' property.
        /// </summary>
        public static readonly StringName Vertices = "vertices";
        /// <summary>
        /// Cached name for the 'indices' property.
        /// </summary>
        public static readonly StringName Indices = "indices";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Occluder3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_arrays' method.
        /// </summary>
        public static readonly StringName SetArrays = "set_arrays";
        /// <summary>
        /// Cached name for the 'set_vertices' method.
        /// </summary>
        public static readonly StringName SetVertices = "set_vertices";
        /// <summary>
        /// Cached name for the 'set_indices' method.
        /// </summary>
        public static readonly StringName SetIndices = "set_indices";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Occluder3D.SignalName
    {
    }
}
