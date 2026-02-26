namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A group of <see cref="Godot.BaseButton"/>-derived buttons. The buttons in a <see cref="Godot.ButtonGroup"/> are treated like radio buttons: No more than one button can be pressed at a time. Some types of buttons (such as <see cref="Godot.CheckBox"/>) may have a special appearance in this state.</para>
/// <para>Every member of a <see cref="Godot.ButtonGroup"/> should have <see cref="Godot.BaseButton.ToggleMode"/> set to <see langword="true"/>.</para>
/// </summary>
public partial class ButtonGroup : Resource
{
    /// <summary>
    /// <para>If <see langword="true"/>, it is possible to unpress all buttons in this <see cref="Godot.ButtonGroup"/>.</para>
    /// </summary>
    public bool AllowUnpress
    {
        get
        {
            return IsAllowUnpress();
        }
        set
        {
            SetAllowUnpress(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ButtonGroup);

    private static readonly StringName NativeName = "ButtonGroup";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ButtonGroup() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ButtonGroup(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ButtonGroup(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPressedButton, 3886434893ul);

    /// <summary>
    /// <para>Returns the current pressed button.</para>
    /// </summary>
    public BaseButton GetPressedButton()
    {
        return (BaseButton)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtons, 2915620761ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <see cref="Godot.Button"/>s who have this as their <see cref="Godot.ButtonGroup"/> (see <see cref="Godot.BaseButton.ButtonGroup"/>).</para>
    /// </summary>
    public Godot.Collections.Array<BaseButton> GetButtons()
    {
        return new Godot.Collections.Array<BaseButton>(NativeCalls.godot_icall_0_120(MethodBind1, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowUnpress, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowUnpress(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAllowUnpress, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAllowUnpress()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ButtonGroup.Pressed"/> event of a <see cref="Godot.ButtonGroup"/> class.
    /// </summary>
    public delegate void PressedEventHandler(BaseButton button);

    private static void PressedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PressedEventHandler)delegateObj)(VariantUtils.ConvertTo<BaseButton>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when one of the buttons of the group is pressed.</para>
    /// </summary>
    public unsafe event PressedEventHandler Pressed
    {
        add => Connect(SignalName.Pressed, Callable.CreateWithUnsafeTrampoline(value, &PressedTrampoline));
        remove => Disconnect(SignalName.Pressed, Callable.CreateWithUnsafeTrampoline(value, &PressedTrampoline));
    }

    protected void EmitSignalPressed(BaseButton button)
    {
        EmitSignal(SignalName.Pressed, button);
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'allow_unpress' property.
        /// </summary>
        public static readonly StringName AllowUnpress = "allow_unpress";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_pressed_button' method.
        /// </summary>
        public static readonly StringName GetPressedButton = "get_pressed_button";
        /// <summary>
        /// Cached name for the 'get_buttons' method.
        /// </summary>
        public static readonly StringName GetButtons = "get_buttons";
        /// <summary>
        /// Cached name for the 'set_allow_unpress' method.
        /// </summary>
        public static readonly StringName SetAllowUnpress = "set_allow_unpress";
        /// <summary>
        /// Cached name for the 'is_allow_unpress' method.
        /// </summary>
        public static readonly StringName IsAllowUnpress = "is_allow_unpress";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
        /// <summary>
        /// Cached name for the 'pressed' signal.
        /// </summary>
        public static readonly StringName Pressed = "pressed";
    }
}
