namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The FBXState handles the state data imported from FBX files.</para>
/// </summary>
[GodotClassName("FBXState")]
public partial class FbxState : GltfState
{
    /// <summary>
    /// <para>If <see langword="true"/>, the import process used auxiliary nodes called geometry helper nodes. These nodes help preserve the pivots and transformations of the original 3D model during import.</para>
    /// </summary>
    public bool AllowGeometryHelperNodes
    {
        get
        {
            return GetAllowGeometryHelperNodes();
        }
        set
        {
            SetAllowGeometryHelperNodes(value);
        }
    }

    private static readonly System.Type CachedType = typeof(FbxState);

    private static readonly StringName NativeName = "FBXState";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public FbxState() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal FbxState(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal FbxState(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllowGeometryHelperNodes, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAllowGeometryHelperNodes()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowGeometryHelperNodes, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowGeometryHelperNodes(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind1, GodotObject.GetPtr(this), allow.ToGodotBool());
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
    public new class PropertyName : GltfState.PropertyName
    {
        /// <summary>
        /// Cached name for the 'allow_geometry_helper_nodes' property.
        /// </summary>
        public static readonly StringName AllowGeometryHelperNodes = "allow_geometry_helper_nodes";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GltfState.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_allow_geometry_helper_nodes' method.
        /// </summary>
        public static readonly StringName GetAllowGeometryHelperNodes = "get_allow_geometry_helper_nodes";
        /// <summary>
        /// Cached name for the 'set_allow_geometry_helper_nodes' method.
        /// </summary>
        public static readonly StringName SetAllowGeometryHelperNodes = "set_allow_geometry_helper_nodes";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GltfState.SignalName
    {
    }
}
