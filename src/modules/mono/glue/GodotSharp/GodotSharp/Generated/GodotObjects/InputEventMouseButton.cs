namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Stores information about mouse click events. See <see cref="Godot.Node._Input(InputEvent)"/>.</para>
/// <para><b>Note:</b> On Wear OS devices, rotary input is mapped to <see cref="Godot.MouseButton.WheelUp"/> and <see cref="Godot.MouseButton.WheelDown"/>. This can be changed to <see cref="Godot.MouseButton.WheelLeft"/> and <see cref="Godot.MouseButton.WheelRight"/> with the <c>ProjectSettings.input_devices/pointing/android/rotary_input_scroll_axis</c> setting.</para>
/// </summary>
public partial class InputEventMouseButton : InputEventMouse
{
    /// <summary>
    /// <para>The amount (or delta) of the event. When used for high-precision scroll events, this indicates the scroll amount (vertical or horizontal). This is only supported on some platforms; the reported sensitivity varies depending on the platform. May be <c>0</c> if not supported.</para>
    /// </summary>
    public float Factor
    {
        get
        {
            return GetFactor();
        }
        set
        {
            SetFactor(value);
        }
    }

    /// <summary>
    /// <para>The mouse button identifier, one of the <see cref="Godot.MouseButton"/> button or button wheel constants.</para>
    /// </summary>
    public MouseButton ButtonIndex
    {
        get
        {
            return GetButtonIndex();
        }
        set
        {
            SetButtonIndex(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the mouse button event has been canceled.</para>
    /// </summary>
    public bool Canceled
    {
        get
        {
            return IsCanceled();
        }
        set
        {
            SetCanceled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the mouse button's state is pressed. If <see langword="false"/>, the mouse button's state is released.</para>
    /// </summary>
    public bool Pressed
    {
        get
        {
            return IsPressed();
        }
        set
        {
            SetPressed(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the mouse button's state is a double-click.</para>
    /// </summary>
    public bool DoubleClick
    {
        get
        {
            return IsDoubleClick();
        }
        set
        {
            SetDoubleClick(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventMouseButton);

    private static readonly StringName NativeName = "InputEventMouseButton";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public InputEventMouseButton() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventMouseButton(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventMouseButton(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFactor, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFactor(float factor)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), factor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFactor, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFactor()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButtonIndex, 3624991109ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetButtonIndex(MouseButton buttonIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)buttonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonIndex, 1132662608ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MouseButton GetButtonIndex()
    {
        return (MouseButton)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPressed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPressed(bool pressed)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), pressed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCanceled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCanceled(bool canceled)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), canceled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDoubleClick, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDoubleClick(bool doubleClick)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), doubleClick.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDoubleClick, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDoubleClick()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : InputEventMouse.PropertyName
    {
        /// <summary>
        /// Cached name for the 'factor' property.
        /// </summary>
        public static readonly StringName Factor = "factor";
        /// <summary>
        /// Cached name for the 'button_index' property.
        /// </summary>
        public static readonly StringName ButtonIndex = "button_index";
        /// <summary>
        /// Cached name for the 'canceled' property.
        /// </summary>
        public static readonly StringName Canceled = "canceled";
        /// <summary>
        /// Cached name for the 'pressed' property.
        /// </summary>
        public static readonly StringName Pressed = "pressed";
        /// <summary>
        /// Cached name for the 'double_click' property.
        /// </summary>
        public static readonly StringName DoubleClick = "double_click";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEventMouse.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_factor' method.
        /// </summary>
        public static readonly StringName SetFactor = "set_factor";
        /// <summary>
        /// Cached name for the 'get_factor' method.
        /// </summary>
        public static readonly StringName GetFactor = "get_factor";
        /// <summary>
        /// Cached name for the 'set_button_index' method.
        /// </summary>
        public static readonly StringName SetButtonIndex = "set_button_index";
        /// <summary>
        /// Cached name for the 'get_button_index' method.
        /// </summary>
        public static readonly StringName GetButtonIndex = "get_button_index";
        /// <summary>
        /// Cached name for the 'set_pressed' method.
        /// </summary>
        public static readonly StringName SetPressed = "set_pressed";
        /// <summary>
        /// Cached name for the 'set_canceled' method.
        /// </summary>
        public static readonly StringName SetCanceled = "set_canceled";
        /// <summary>
        /// Cached name for the 'set_double_click' method.
        /// </summary>
        public static readonly StringName SetDoubleClick = "set_double_click";
        /// <summary>
        /// Cached name for the 'is_double_click' method.
        /// </summary>
        public static readonly StringName IsDoubleClick = "is_double_click";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEventMouse.SignalName
    {
    }
}
