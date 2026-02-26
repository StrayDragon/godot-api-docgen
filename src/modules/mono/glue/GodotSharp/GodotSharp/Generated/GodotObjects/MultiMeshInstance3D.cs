namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.MultiMeshInstance3D"/> is a specialized node to instance <see cref="Godot.GeometryInstance3D"/>s based on a <see cref="Godot.MultiMesh"/> resource.</para>
/// <para>This is useful to optimize the rendering of a high number of instances of a given mesh (for example trees in a forest or grass strands).</para>
/// </summary>
public partial class MultiMeshInstance3D : GeometryInstance3D
{
    /// <summary>
    /// <para>The <see cref="Godot.MultiMesh"/> resource that will be used and shared among all instances of the <see cref="Godot.MultiMeshInstance3D"/>.</para>
    /// </summary>
    public MultiMesh Multimesh
    {
        get
        {
            return GetMultimesh();
        }
        set
        {
            SetMultimesh(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MultiMeshInstance3D);

    private static readonly StringName NativeName = "MultiMeshInstance3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MultiMeshInstance3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal MultiMeshInstance3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MultiMeshInstance3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMultimesh, 2246127404ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMultimesh(MultiMesh multimesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(multimesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMultimesh, 1385450523ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MultiMesh GetMultimesh()
    {
        return (MultiMesh)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : GeometryInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'multimesh' property.
        /// </summary>
        public static readonly StringName Multimesh = "multimesh";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GeometryInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_multimesh' method.
        /// </summary>
        public static readonly StringName SetMultimesh = "set_multimesh";
        /// <summary>
        /// Cached name for the 'get_multimesh' method.
        /// </summary>
        public static readonly StringName GetMultimesh = "get_multimesh";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GeometryInstance3D.SignalName
    {
    }
}
