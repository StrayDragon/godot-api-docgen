namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
public partial class StatusIndicator : Node
{
    /// <summary>
    /// <para>Status indicator tooltip.</para>
    /// </summary>
    public string Tooltip
    {
        get
        {
            return GetTooltip();
        }
        set
        {
            SetTooltip(value);
        }
    }

    /// <summary>
    /// <para>Status indicator icon.</para>
    /// </summary>
    public Texture2D Icon
    {
        get
        {
            return GetIcon();
        }
        set
        {
            SetIcon(value);
        }
    }

    /// <summary>
    /// <para>Status indicator native popup menu. If this is set, the <see cref="Godot.StatusIndicator.Pressed"/> signal is not emitted.</para>
    /// <para><b>Note:</b> Native popup is only supported if <see cref="Godot.NativeMenu"/> supports <see cref="Godot.NativeMenu.Feature.PopupMenu"/> feature.</para>
    /// </summary>
    public NodePath Menu
    {
        get
        {
            return GetMenu();
        }
        set
        {
            SetMenu(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the status indicator is visible.</para>
    /// </summary>
    public bool Visible
    {
        get
        {
            return IsVisible();
        }
        set
        {
            SetVisible(value);
        }
    }

    private static readonly System.Type CachedType = typeof(StatusIndicator);

    private static readonly StringName NativeName = "StatusIndicator";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public StatusIndicator() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal StatusIndicator(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal StatusIndicator(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTooltip, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTooltip(string tooltip)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTooltip, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetTooltip()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIcon, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIcon(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIcon, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetIcon()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMenu, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMenu(NodePath menu)
    {
        NativeCalls.godot_icall_1_123(MethodBind6, GodotObject.GetPtr(this), (godot_node_path)(menu?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMenu, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetMenu()
    {
        return NativeCalls.godot_icall_0_124(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRect, 1639390495ul);

    /// <summary>
    /// <para>Returns the status indicator rectangle in screen coordinates. If this status indicator is not visible, returns an empty <see cref="Godot.Rect2"/>.</para>
    /// </summary>
    public Rect2 GetRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind8, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.StatusIndicator.Pressed"/> event of a <see cref="Godot.StatusIndicator"/> class.
    /// </summary>
    public delegate void PressedEventHandler(long mouseButton, Vector2I mousePosition);

    private static void PressedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((PressedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the status indicator is pressed.</para>
    /// </summary>
    public unsafe event PressedEventHandler Pressed
    {
        add => Connect(SignalName.Pressed, Callable.CreateWithUnsafeTrampoline(value, &PressedTrampoline));
        remove => Disconnect(SignalName.Pressed, Callable.CreateWithUnsafeTrampoline(value, &PressedTrampoline));
    }

    protected void EmitSignalPressed(long mouseButton, Vector2I mousePosition)
    {
        EmitSignal(SignalName.Pressed, mouseButton, mousePosition);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_pressed = "Pressed";

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
        if (signal == SignalName.Pressed)
        {
            if (HasGodotClassSignal(SignalProxyName_pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node.PropertyName
    {
        /// <summary>
        /// Cached name for the 'tooltip' property.
        /// </summary>
        public static readonly StringName Tooltip = "tooltip";
        /// <summary>
        /// Cached name for the 'icon' property.
        /// </summary>
        public static readonly StringName Icon = "icon";
        /// <summary>
        /// Cached name for the 'menu' property.
        /// </summary>
        public static readonly StringName Menu = "menu";
        /// <summary>
        /// Cached name for the 'visible' property.
        /// </summary>
        public static readonly StringName Visible = "visible";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_tooltip' method.
        /// </summary>
        public static readonly StringName SetTooltip = "set_tooltip";
        /// <summary>
        /// Cached name for the 'get_tooltip' method.
        /// </summary>
        public static readonly StringName GetTooltip = "get_tooltip";
        /// <summary>
        /// Cached name for the 'set_icon' method.
        /// </summary>
        public static readonly StringName SetIcon = "set_icon";
        /// <summary>
        /// Cached name for the 'get_icon' method.
        /// </summary>
        public static readonly StringName GetIcon = "get_icon";
        /// <summary>
        /// Cached name for the 'set_visible' method.
        /// </summary>
        public static readonly StringName SetVisible = "set_visible";
        /// <summary>
        /// Cached name for the 'is_visible' method.
        /// </summary>
        public static readonly StringName IsVisible = "is_visible";
        /// <summary>
        /// Cached name for the 'set_menu' method.
        /// </summary>
        public static readonly StringName SetMenu = "set_menu";
        /// <summary>
        /// Cached name for the 'get_menu' method.
        /// </summary>
        public static readonly StringName GetMenu = "get_menu";
        /// <summary>
        /// Cached name for the 'get_rect' method.
        /// </summary>
        public static readonly StringName GetRect = "get_rect";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'pressed' signal.
        /// </summary>
        public static readonly StringName Pressed = "pressed";
    }
}
