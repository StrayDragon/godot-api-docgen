namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.VisibleOnScreenNotifier3D"/> represents a box-shaped region of 3D space. When any part of this region becomes visible on screen or in a <see cref="Godot.Camera3D"/>'s view, it will emit a <see cref="Godot.VisibleOnScreenNotifier3D.ScreenEntered"/> signal, and likewise it will emit a <see cref="Godot.VisibleOnScreenNotifier3D.ScreenExited"/> signal when no part of it remains visible.</para>
/// <para>If you want a node to be enabled automatically when this region is visible on screen, use <see cref="Godot.VisibleOnScreenEnabler3D"/>.</para>
/// <para><b>Note:</b> <see cref="Godot.VisibleOnScreenNotifier3D"/> uses an approximate heuristic that doesn't take walls and other occlusion into account, unless occlusion culling is used. It also won't function unless <see cref="Godot.Node3D.Visible"/> is set to <see langword="true"/>.</para>
/// </summary>
public partial class VisibleOnScreenNotifier3D : VisualInstance3D
{
    /// <summary>
    /// <para>The <see cref="Godot.VisibleOnScreenNotifier3D"/>'s bounding box.</para>
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

    private static readonly System.Type CachedType = typeof(VisibleOnScreenNotifier3D);

    private static readonly StringName NativeName = "VisibleOnScreenNotifier3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisibleOnScreenNotifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal VisibleOnScreenNotifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal VisibleOnScreenNotifier3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAabb, 259215842ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAabb(Aabb rect)
    {
        NativeCalls.godot_icall_1_183(MethodBind0, GodotObject.GetPtr(this), &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOnScreen, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the bounding box is on the screen.</para>
    /// <para><b>Note:</b> It takes one frame for the <see cref="Godot.VisibleOnScreenNotifier3D"/>'s visibility to be assessed once added to the scene tree, so this method will always return <see langword="false"/> right after it is instantiated.</para>
    /// </summary>
    public bool IsOnScreen()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.VisibleOnScreenNotifier3D"/> enters the screen.</para>
    /// </summary>
    public event Action ScreenEntered
    {
        add => Connect(SignalName.ScreenEntered, Callable.From(value));
        remove => Disconnect(SignalName.ScreenEntered, Callable.From(value));
    }

    protected void EmitSignalScreenEntered()
    {
        EmitSignal(SignalName.ScreenEntered);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.VisibleOnScreenNotifier3D"/> exits the screen.</para>
    /// </summary>
    public event Action ScreenExited
    {
        add => Connect(SignalName.ScreenExited, Callable.From(value));
        remove => Disconnect(SignalName.ScreenExited, Callable.From(value));
    }

    protected void EmitSignalScreenExited()
    {
        EmitSignal(SignalName.ScreenExited);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_screen_entered = "ScreenEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_screen_exited = "ScreenExited";

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
        if (signal == SignalName.ScreenEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_screen_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ScreenExited)
        {
            if (HasGodotClassSignal(SignalProxyName_screen_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : VisualInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'aabb' property.
        /// </summary>
        public static readonly StringName Aabb = "aabb";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_aabb' method.
        /// </summary>
        public static readonly StringName SetAabb = "set_aabb";
        /// <summary>
        /// Cached name for the 'is_on_screen' method.
        /// </summary>
        public static readonly StringName IsOnScreen = "is_on_screen";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'screen_entered' signal.
        /// </summary>
        public static readonly StringName ScreenEntered = "screen_entered";
        /// <summary>
        /// Cached name for the 'screen_exited' signal.
        /// </summary>
        public static readonly StringName ScreenExited = "screen_exited";
    }
}
