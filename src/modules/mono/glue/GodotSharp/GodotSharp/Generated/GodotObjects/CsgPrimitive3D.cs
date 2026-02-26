namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Parent class for various CSG primitives. It contains code and functionality that is common between them. It cannot be used directly. Instead use one of the various classes that inherit from it.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="Godot.MeshInstance3D"/> with a <see cref="Godot.PrimitiveMesh"/>. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
[GodotClassName("CSGPrimitive3D")]
public partial class CsgPrimitive3D : CsgShape3D
{
    /// <summary>
    /// <para>If set, the order of the vertices in each triangle are reversed resulting in the backside of the mesh being drawn.</para>
    /// </summary>
    public bool FlipFaces
    {
        get
        {
            return GetFlipFaces();
        }
        set
        {
            SetFlipFaces(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CsgPrimitive3D);

    private static readonly StringName NativeName = "CSGPrimitive3D";

    internal CsgPrimitive3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CsgPrimitive3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CsgPrimitive3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipFaces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipFaces(bool flipFaces)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), flipFaces.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlipFaces, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFlipFaces()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : CsgShape3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'flip_faces' property.
        /// </summary>
        public static readonly StringName FlipFaces = "flip_faces";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CsgShape3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_flip_faces' method.
        /// </summary>
        public static readonly StringName SetFlipFaces = "set_flip_faces";
        /// <summary>
        /// Cached name for the 'get_flip_faces' method.
        /// </summary>
        public static readonly StringName GetFlipFaces = "get_flip_faces";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CsgShape3D.SignalName
    {
    }
}
