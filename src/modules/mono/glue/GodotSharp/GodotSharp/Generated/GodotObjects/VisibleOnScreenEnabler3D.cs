namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.VisibleOnScreenEnabler3D"/> contains a box-shaped region of 3D space and a target node. The target node will be automatically enabled (via its <see cref="Godot.Node.ProcessMode"/> property) when any part of this region becomes visible on the screen, and automatically disabled otherwise. This can for example be used to activate enemies only when the player approaches them.</para>
/// <para>See <see cref="Godot.VisibleOnScreenNotifier3D"/> if you only want to be notified when the region is visible on screen.</para>
/// <para><b>Note:</b> <see cref="Godot.VisibleOnScreenEnabler3D"/> uses an approximate heuristic that doesn't take walls and other occlusion into account, unless occlusion culling is used. It also won't function unless <see cref="Godot.Node3D.Visible"/> is set to <see langword="true"/>.</para>
/// </summary>
public partial class VisibleOnScreenEnabler3D : VisibleOnScreenNotifier3D
{
    public enum EnableModeEnum : long
    {
        /// <summary>
        /// <para>Corresponds to <see cref="Godot.Node.ProcessModeEnum.Inherit"/>.</para>
        /// </summary>
        Inherit = 0,
        /// <summary>
        /// <para>Corresponds to <see cref="Godot.Node.ProcessModeEnum.Always"/>.</para>
        /// </summary>
        Always = 1,
        /// <summary>
        /// <para>Corresponds to <see cref="Godot.Node.ProcessModeEnum.WhenPaused"/>.</para>
        /// </summary>
        WhenPaused = 2
    }

    /// <summary>
    /// <para>Determines how the target node is enabled. Corresponds to <see cref="Godot.Node.ProcessModeEnum"/>. When the node is disabled, it always uses <see cref="Godot.Node.ProcessModeEnum.Disabled"/>.</para>
    /// </summary>
    public VisibleOnScreenEnabler3D.EnableModeEnum EnableMode
    {
        get
        {
            return GetEnableMode();
        }
        set
        {
            SetEnableMode(value);
        }
    }

    /// <summary>
    /// <para>The path to the target node, relative to the <see cref="Godot.VisibleOnScreenEnabler3D"/>. The target node is cached; it's only assigned when setting this property (if the <see cref="Godot.VisibleOnScreenEnabler3D"/> is inside the scene tree) and every time the <see cref="Godot.VisibleOnScreenEnabler3D"/> enters the scene tree. If the path is empty, no node will be affected. If the path is invalid, an error is also generated.</para>
    /// </summary>
    public NodePath EnableNodePath
    {
        get
        {
            return GetEnableNodePath();
        }
        set
        {
            SetEnableNodePath(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisibleOnScreenEnabler3D);

    private static readonly StringName NativeName = "VisibleOnScreenEnabler3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisibleOnScreenEnabler3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal VisibleOnScreenEnabler3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal VisibleOnScreenEnabler3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableMode, 320303646ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableMode(VisibleOnScreenEnabler3D.EnableModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableMode, 3352990031ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisibleOnScreenEnabler3D.EnableModeEnum GetEnableMode()
    {
        return (VisibleOnScreenEnabler3D.EnableModeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableNodePath, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableNodePath(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind2, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableNodePath, 277076166ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetEnableNodePath()
    {
        return NativeCalls.godot_icall_0_124(MethodBind3, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisibleOnScreenNotifier3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'enable_mode' property.
        /// </summary>
        public static readonly StringName EnableMode = "enable_mode";
        /// <summary>
        /// Cached name for the 'enable_node_path' property.
        /// </summary>
        public static readonly StringName EnableNodePath = "enable_node_path";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisibleOnScreenNotifier3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_enable_mode' method.
        /// </summary>
        public static readonly StringName SetEnableMode = "set_enable_mode";
        /// <summary>
        /// Cached name for the 'get_enable_mode' method.
        /// </summary>
        public static readonly StringName GetEnableMode = "get_enable_mode";
        /// <summary>
        /// Cached name for the 'set_enable_node_path' method.
        /// </summary>
        public static readonly StringName SetEnableNodePath = "set_enable_node_path";
        /// <summary>
        /// Cached name for the 'get_enable_node_path' method.
        /// </summary>
        public static readonly StringName GetEnableNodePath = "get_enable_node_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisibleOnScreenNotifier3D.SignalName
    {
    }
}
