namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is used when loading a project that uses a <see cref="Godot.Mesh"/> subclass in 2 conditions:</para>
/// <para>- When running the project exported in dedicated server mode, only the texture's dimensions are kept (as they may be relied upon for gameplay purposes or positioning of other elements). This allows reducing the exported PCK's size significantly.</para>
/// <para>- When this subclass is missing due to using a different engine version or build (e.g. modules disabled).</para>
/// </summary>
public partial class PlaceholderMesh : Mesh
{
    /// <summary>
    /// <para>The smallest <see cref="Godot.Aabb"/> enclosing this mesh in local space.</para>
    /// </summary>
    public Aabb Aabb
    {
        get
        {
            return GetAabb();
        }
        set
        {
            SetAabb(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PlaceholderMesh);

    private static readonly StringName NativeName = "PlaceholderMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PlaceholderMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PlaceholderMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PlaceholderMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAabb, 259215842ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAabb(Aabb aabb)
    {
        NativeCalls.godot_icall_1_183(MethodBind0, GodotObject.GetPtr(this), &aabb);
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
        /// <summary>
        /// Cached name for the 'aabb' property.
        /// </summary>
        public static readonly StringName Aabb = "aabb";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Mesh.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_aabb' method.
        /// </summary>
        public static readonly StringName SetAabb = "set_aabb";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Mesh.SignalName
    {
    }
}
