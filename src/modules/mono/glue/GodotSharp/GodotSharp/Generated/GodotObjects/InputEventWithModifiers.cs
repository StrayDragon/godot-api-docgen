namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Stores information about mouse, keyboard, and touch gesture input events. This includes information about which modifier keys are pressed, such as Shift or Alt. See <see cref="Godot.Node._Input(InputEvent)"/>.</para>
/// <para><b>Note:</b> Modifier keys are considered modifiers only when used in combination with another key. As a result, their corresponding member variables, such as <see cref="Godot.InputEventWithModifiers.CtrlPressed"/>, will return <see langword="false"/> if the key is pressed on its own.</para>
/// </summary>
public partial class InputEventWithModifiers : InputEventFromWindow
{
    /// <summary>
    /// <para>Automatically use Meta (Cmd) on macOS and Ctrl on other platforms. If <see langword="true"/>, <see cref="Godot.InputEventWithModifiers.CtrlPressed"/> and <see cref="Godot.InputEventWithModifiers.MetaPressed"/> cannot be set.</para>
    /// </summary>
    public bool CommandOrControlAutoremap
    {
        get
        {
            return IsCommandOrControlAutoremap();
        }
        set
        {
            SetCommandOrControlAutoremap(value);
        }
    }

    /// <summary>
    /// <para>State of the Alt modifier.</para>
    /// </summary>
    public bool AltPressed
    {
        get
        {
            return IsAltPressed();
        }
        set
        {
            SetAltPressed(value);
        }
    }

    /// <summary>
    /// <para>State of the Shift modifier.</para>
    /// </summary>
    public bool ShiftPressed
    {
        get
        {
            return IsShiftPressed();
        }
        set
        {
            SetShiftPressed(value);
        }
    }

    /// <summary>
    /// <para>State of the Ctrl modifier.</para>
    /// </summary>
    public bool CtrlPressed
    {
        get
        {
            return IsCtrlPressed();
        }
        set
        {
            SetCtrlPressed(value);
        }
    }

    /// <summary>
    /// <para>State of the Meta modifier. On Windows and Linux, this represents the Windows key (sometimes called "meta" or "super" on Linux). On macOS, this represents the Command key.</para>
    /// </summary>
    public bool MetaPressed
    {
        get
        {
            return IsMetaPressed();
        }
        set
        {
            SetMetaPressed(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventWithModifiers);

    private static readonly StringName NativeName = "InputEventWithModifiers";

    internal InputEventWithModifiers() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventWithModifiers(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventWithModifiers(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCommandOrControlAutoremap, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCommandOrControlAutoremap(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCommandOrControlAutoremap, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCommandOrControlAutoremap()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCommandOrControlPressed, 36873697ul);

    /// <summary>
    /// <para>On macOS, returns <see langword="true"/> if Meta (Cmd) is pressed.</para>
    /// <para>On other platforms, returns <see langword="true"/> if Ctrl is pressed.</para>
    /// </summary>
    public bool IsCommandOrControlPressed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAltPressed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAltPressed(bool pressed)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), pressed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAltPressed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAltPressed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShiftPressed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShiftPressed(bool pressed)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), pressed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShiftPressed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShiftPressed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCtrlPressed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCtrlPressed(bool pressed)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), pressed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCtrlPressed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCtrlPressed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMetaPressed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMetaPressed(bool pressed)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), pressed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMetaPressed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMetaPressed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModifiersMask, 1258259499ul);

    /// <summary>
    /// <para>Returns the keycode combination of modifier keys.</para>
    /// </summary>
    public KeyModifierMask GetModifiersMask()
    {
        return (KeyModifierMask)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
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
    public new class PropertyName : InputEventFromWindow.PropertyName
    {
        /// <summary>
        /// Cached name for the 'command_or_control_autoremap' property.
        /// </summary>
        public static readonly StringName CommandOrControlAutoremap = "command_or_control_autoremap";
        /// <summary>
        /// Cached name for the 'alt_pressed' property.
        /// </summary>
        public static readonly StringName AltPressed = "alt_pressed";
        /// <summary>
        /// Cached name for the 'shift_pressed' property.
        /// </summary>
        public static readonly StringName ShiftPressed = "shift_pressed";
        /// <summary>
        /// Cached name for the 'ctrl_pressed' property.
        /// </summary>
        public static readonly StringName CtrlPressed = "ctrl_pressed";
        /// <summary>
        /// Cached name for the 'meta_pressed' property.
        /// </summary>
        public static readonly StringName MetaPressed = "meta_pressed";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEventFromWindow.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_command_or_control_autoremap' method.
        /// </summary>
        public static readonly StringName SetCommandOrControlAutoremap = "set_command_or_control_autoremap";
        /// <summary>
        /// Cached name for the 'is_command_or_control_autoremap' method.
        /// </summary>
        public static readonly StringName IsCommandOrControlAutoremap = "is_command_or_control_autoremap";
        /// <summary>
        /// Cached name for the 'is_command_or_control_pressed' method.
        /// </summary>
        public static readonly StringName IsCommandOrControlPressed = "is_command_or_control_pressed";
        /// <summary>
        /// Cached name for the 'set_alt_pressed' method.
        /// </summary>
        public static readonly StringName SetAltPressed = "set_alt_pressed";
        /// <summary>
        /// Cached name for the 'is_alt_pressed' method.
        /// </summary>
        public static readonly StringName IsAltPressed = "is_alt_pressed";
        /// <summary>
        /// Cached name for the 'set_shift_pressed' method.
        /// </summary>
        public static readonly StringName SetShiftPressed = "set_shift_pressed";
        /// <summary>
        /// Cached name for the 'is_shift_pressed' method.
        /// </summary>
        public static readonly StringName IsShiftPressed = "is_shift_pressed";
        /// <summary>
        /// Cached name for the 'set_ctrl_pressed' method.
        /// </summary>
        public static readonly StringName SetCtrlPressed = "set_ctrl_pressed";
        /// <summary>
        /// Cached name for the 'is_ctrl_pressed' method.
        /// </summary>
        public static readonly StringName IsCtrlPressed = "is_ctrl_pressed";
        /// <summary>
        /// Cached name for the 'set_meta_pressed' method.
        /// </summary>
        public static readonly StringName SetMetaPressed = "set_meta_pressed";
        /// <summary>
        /// Cached name for the 'is_meta_pressed' method.
        /// </summary>
        public static readonly StringName IsMetaPressed = "is_meta_pressed";
        /// <summary>
        /// Cached name for the 'get_modifiers_mask' method.
        /// </summary>
        public static readonly StringName GetModifiersMask = "get_modifiers_mask";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEventFromWindow.SignalName
    {
    }
}
