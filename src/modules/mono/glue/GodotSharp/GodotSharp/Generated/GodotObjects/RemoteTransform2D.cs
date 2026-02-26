namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>RemoteTransform2D pushes its own <see cref="Godot.Transform2D"/> to another <see cref="Godot.Node2D"/> derived node (called the remote node) in the scene.</para>
/// <para>It can be set to update another node's position, rotation and/or scale. It can use either global or local coordinates.</para>
/// </summary>
public partial class RemoteTransform2D : Node2D
{
    /// <summary>
    /// <para>The <see cref="Godot.NodePath"/> to the remote node, relative to the RemoteTransform2D's position in the scene.</para>
    /// </summary>
    public NodePath RemotePath
    {
        get
        {
            return GetRemoteNode();
        }
        set
        {
            SetRemoteNode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, global coordinates are used. If <see langword="false"/>, local coordinates are used.</para>
    /// </summary>
    public bool UseGlobalCoordinates
    {
        get
        {
            return GetUseGlobalCoordinates();
        }
        set
        {
            SetUseGlobalCoordinates(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the remote node's position is updated.</para>
    /// </summary>
    public bool UpdatePosition
    {
        get
        {
            return GetUpdatePosition();
        }
        set
        {
            SetUpdatePosition(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the remote node's rotation is updated.</para>
    /// </summary>
    public bool UpdateRotation
    {
        get
        {
            return GetUpdateRotation();
        }
        set
        {
            SetUpdateRotation(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the remote node's scale is updated.</para>
    /// </summary>
    public bool UpdateScale
    {
        get
        {
            return GetUpdateScale();
        }
        set
        {
            SetUpdateScale(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RemoteTransform2D);

    private static readonly StringName NativeName = "RemoteTransform2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RemoteTransform2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal RemoteTransform2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RemoteTransform2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRemoteNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRemoteNode(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind0, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRemoteNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetRemoteNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceUpdateCache, 3218959716ul);

    /// <summary>
    /// <para><see cref="Godot.RemoteTransform2D"/> caches the remote node. It may not notice if the remote node disappears; <see cref="Godot.RemoteTransform2D.ForceUpdateCache()"/> forces it to update the cache again.</para>
    /// </summary>
    public void ForceUpdateCache()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseGlobalCoordinates, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseGlobalCoordinates(bool useGlobalCoordinates)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), useGlobalCoordinates.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseGlobalCoordinates, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseGlobalCoordinates()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUpdatePosition, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUpdatePosition(bool updateRemotePosition)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), updateRemotePosition.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUpdatePosition, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUpdatePosition()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUpdateRotation, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUpdateRotation(bool updateRemoteRotation)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), updateRemoteRotation.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUpdateRotation, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUpdateRotation()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUpdateScale, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUpdateScale(bool updateRemoteScale)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), updateRemoteScale.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUpdateScale, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUpdateScale()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'remote_path' property.
        /// </summary>
        public static readonly StringName RemotePath = "remote_path";
        /// <summary>
        /// Cached name for the 'use_global_coordinates' property.
        /// </summary>
        public static readonly StringName UseGlobalCoordinates = "use_global_coordinates";
        /// <summary>
        /// Cached name for the 'update_position' property.
        /// </summary>
        public static readonly StringName UpdatePosition = "update_position";
        /// <summary>
        /// Cached name for the 'update_rotation' property.
        /// </summary>
        public static readonly StringName UpdateRotation = "update_rotation";
        /// <summary>
        /// Cached name for the 'update_scale' property.
        /// </summary>
        public static readonly StringName UpdateScale = "update_scale";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_remote_node' method.
        /// </summary>
        public static readonly StringName SetRemoteNode = "set_remote_node";
        /// <summary>
        /// Cached name for the 'get_remote_node' method.
        /// </summary>
        public static readonly StringName GetRemoteNode = "get_remote_node";
        /// <summary>
        /// Cached name for the 'force_update_cache' method.
        /// </summary>
        public static readonly StringName ForceUpdateCache = "force_update_cache";
        /// <summary>
        /// Cached name for the 'set_use_global_coordinates' method.
        /// </summary>
        public static readonly StringName SetUseGlobalCoordinates = "set_use_global_coordinates";
        /// <summary>
        /// Cached name for the 'get_use_global_coordinates' method.
        /// </summary>
        public static readonly StringName GetUseGlobalCoordinates = "get_use_global_coordinates";
        /// <summary>
        /// Cached name for the 'set_update_position' method.
        /// </summary>
        public static readonly StringName SetUpdatePosition = "set_update_position";
        /// <summary>
        /// Cached name for the 'get_update_position' method.
        /// </summary>
        public static readonly StringName GetUpdatePosition = "get_update_position";
        /// <summary>
        /// Cached name for the 'set_update_rotation' method.
        /// </summary>
        public static readonly StringName SetUpdateRotation = "set_update_rotation";
        /// <summary>
        /// Cached name for the 'get_update_rotation' method.
        /// </summary>
        public static readonly StringName GetUpdateRotation = "get_update_rotation";
        /// <summary>
        /// Cached name for the 'set_update_scale' method.
        /// </summary>
        public static readonly StringName SetUpdateScale = "set_update_scale";
        /// <summary>
        /// Cached name for the 'get_update_scale' method.
        /// </summary>
        public static readonly StringName GetUpdateScale = "get_update_scale";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
