namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Object for storing the queries 2D polygon result data when calling <see cref="Godot.OpenXRSpatialEntityExtension.QuerySnapshot(Rid, Godot.Collections.Array{OpenXRSpatialComponentData}, OpenXRStructureBase)"/>.</para>
/// </summary>
public partial class OpenXRSpatialComponentPolygon2DList : OpenXRSpatialComponentData
{
    private static readonly System.Type CachedType = typeof(OpenXRSpatialComponentPolygon2DList);

    private static readonly StringName NativeName = "OpenXRSpatialComponentPolygon2DList";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRSpatialComponentPolygon2DList() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialComponentPolygon2DList(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRSpatialComponentPolygon2DList(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransform, 1965739696ul);

    /// <summary>
    /// <para>Returns the transform for positioning our polygon for the entity at this <paramref name="index"/>.</para>
    /// </summary>
    public Transform3D GetTransform(long index)
    {
        return NativeCalls.godot_icall_1_947(MethodBind0, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertices, 110850971ul);

    /// <summary>
    /// <para>Returns the polygon vertices for the entity at this <paramref name="index"/>.</para>
    /// </summary>
    public Vector2[] GetVertices(Rid snapshot, long index)
    {
        return NativeCalls.godot_icall_2_950(MethodBind1, GodotObject.GetPtr(this), snapshot, index);
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
    public new class PropertyName : OpenXRSpatialComponentData.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRSpatialComponentData.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_transform' method.
        /// </summary>
        public static readonly StringName GetTransform = "get_transform";
        /// <summary>
        /// Cached name for the 'get_vertices' method.
        /// </summary>
        public static readonly StringName GetVertices = "get_vertices";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRSpatialComponentData.SignalName
    {
    }
}
