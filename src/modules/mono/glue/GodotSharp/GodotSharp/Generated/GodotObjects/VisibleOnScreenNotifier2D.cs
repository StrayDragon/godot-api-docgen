namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.VisibleOnScreenNotifier2D"/> represents a rectangular region of 2D space. When any part of this region becomes visible on screen or in a viewport, it will emit a <see cref="Godot.VisibleOnScreenNotifier2D.ScreenEntered"/> signal, and likewise it will emit a <see cref="Godot.VisibleOnScreenNotifier2D.ScreenExited"/> signal when no part of it remains visible.</para>
/// <para>If you want a node to be enabled automatically when this region is visible on screen, use <see cref="Godot.VisibleOnScreenEnabler2D"/>.</para>
/// <para><b>Note:</b> <see cref="Godot.VisibleOnScreenNotifier2D"/> uses the render culling code to determine whether it's visible on screen, so it won't function unless <see cref="Godot.CanvasItem.Visible"/> is set to <see langword="true"/>.</para>
/// </summary>
public partial class VisibleOnScreenNotifier2D : Node2D
{
    /// <summary>
    /// <para>The VisibleOnScreenNotifier2D's bounding rectangle.</para>
    /// </summary>
    public Rect2 Rect
    {
        get
        {
            return GetRect();
        }
        set
        {
            SetRect(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, shows the rectangle area of <see cref="Godot.VisibleOnScreenNotifier2D.Rect"/> in the editor with a translucent magenta fill. Unlike changing the visibility of the VisibleOnScreenNotifier2D, this does not affect the screen culling detection.</para>
    /// </summary>
    public bool ShowRect
    {
        get
        {
            return IsShowingRect();
        }
        set
        {
            SetShowRect(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisibleOnScreenNotifier2D);

    private static readonly StringName NativeName = "VisibleOnScreenNotifier2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisibleOnScreenNotifier2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal VisibleOnScreenNotifier2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal VisibleOnScreenNotifier2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRect, 2046264180ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRect(Rect2 rect)
    {
        NativeCalls.godot_icall_1_188(MethodBind0, GodotObject.GetPtr(this), &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRect, 1639390495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2 GetRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowRect, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowRect(bool showRect)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), showRect.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShowingRect, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShowingRect()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOnScreen, 36873697ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the bounding rectangle is on the screen.</para>
    /// <para><b>Note:</b> It takes one frame for the <see cref="Godot.VisibleOnScreenNotifier2D"/>'s visibility to be determined once added to the scene tree, so this method will always return <see langword="false"/> right after it is instantiated, before the draw pass.</para>
    /// </summary>
    public bool IsOnScreen()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// <para>Emitted when the VisibleOnScreenNotifier2D enters the screen.</para>
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
    /// <para>Emitted when the VisibleOnScreenNotifier2D exits the screen.</para>
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
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'rect' property.
        /// </summary>
        public static readonly StringName Rect = "rect";
        /// <summary>
        /// Cached name for the 'show_rect' property.
        /// </summary>
        public static readonly StringName ShowRect = "show_rect";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_rect' method.
        /// </summary>
        public static readonly StringName SetRect = "set_rect";
        /// <summary>
        /// Cached name for the 'get_rect' method.
        /// </summary>
        public static readonly StringName GetRect = "get_rect";
        /// <summary>
        /// Cached name for the 'set_show_rect' method.
        /// </summary>
        public static readonly StringName SetShowRect = "set_show_rect";
        /// <summary>
        /// Cached name for the 'is_showing_rect' method.
        /// </summary>
        public static readonly StringName IsShowingRect = "is_showing_rect";
        /// <summary>
        /// Cached name for the 'is_on_screen' method.
        /// </summary>
        public static readonly StringName IsOnScreen = "is_on_screen";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
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
