namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Input event type for gamepad buttons. For gamepad analog sticks and joysticks, see <see cref="Godot.InputEventJoypadMotion"/>.</para>
/// </summary>
public partial class InputEventJoypadButton : InputEvent
{
    /// <summary>
    /// <para>Button identifier. One of the <see cref="Godot.JoyButton"/> button constants.</para>
    /// </summary>
    public JoyButton ButtonIndex
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

    [Obsolete("This property is never set by the engine and is always '0'.")]
    public float Pressure
    {
        get
        {
            return GetPressure();
        }
        set
        {
            SetPressure(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button's state is pressed. If <see langword="false"/>, the button's state is released.</para>
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

    private static readonly System.Type CachedType = typeof(InputEventJoypadButton);

    private static readonly StringName NativeName = "InputEventJoypadButton";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public InputEventJoypadButton() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventJoypadButton(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventJoypadButton(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButtonIndex, 1466368136ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetButtonIndex(JoyButton buttonIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)buttonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonIndex, 595588182ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public JoyButton GetButtonIndex()
    {
        return (JoyButton)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPressure, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPressure(float pressure)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), pressure);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPressure, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPressure()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPressed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPressed(bool pressed)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), pressed.ToGodotBool());
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
    public new class PropertyName : InputEvent.PropertyName
    {
        /// <summary>
        /// Cached name for the 'button_index' property.
        /// </summary>
        public static readonly StringName ButtonIndex = "button_index";
        /// <summary>
        /// Cached name for the 'pressure' property.
        /// </summary>
        public static readonly StringName Pressure = "pressure";
        /// <summary>
        /// Cached name for the 'pressed' property.
        /// </summary>
        public static readonly StringName Pressed = "pressed";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEvent.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_button_index' method.
        /// </summary>
        public static readonly StringName SetButtonIndex = "set_button_index";
        /// <summary>
        /// Cached name for the 'get_button_index' method.
        /// </summary>
        public static readonly StringName GetButtonIndex = "get_button_index";
        /// <summary>
        /// Cached name for the 'set_pressure' method.
        /// </summary>
        public static readonly StringName SetPressure = "set_pressure";
        /// <summary>
        /// Cached name for the 'get_pressure' method.
        /// </summary>
        public static readonly StringName GetPressure = "get_pressure";
        /// <summary>
        /// Cached name for the 'set_pressed' method.
        /// </summary>
        public static readonly StringName SetPressed = "set_pressed";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEvent.SignalName
    {
    }
}
