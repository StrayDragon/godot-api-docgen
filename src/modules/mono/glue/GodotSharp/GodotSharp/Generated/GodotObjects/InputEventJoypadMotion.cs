namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Stores information about joystick motions. One <see cref="Godot.InputEventJoypadMotion"/> represents one axis at a time. For gamepad buttons, see <see cref="Godot.InputEventJoypadButton"/>.</para>
/// </summary>
public partial class InputEventJoypadMotion : InputEvent
{
    /// <summary>
    /// <para>Axis identifier.</para>
    /// </summary>
    public JoyAxis Axis
    {
        get
        {
            return GetAxis();
        }
        set
        {
            SetAxis(value);
        }
    }

    /// <summary>
    /// <para>Current position of the joystick on the given axis. The value ranges from <c>-1.0</c> to <c>1.0</c>. A value of <c>0</c> means the axis is in its resting position.</para>
    /// </summary>
    public float AxisValue
    {
        get
        {
            return GetAxisValue();
        }
        set
        {
            SetAxisValue(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventJoypadMotion);

    private static readonly StringName NativeName = "InputEventJoypadMotion";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public InputEventJoypadMotion() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventJoypadMotion(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventJoypadMotion(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxis, 1332685170ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAxis(JoyAxis axis)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAxis, 4019121683ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public JoyAxis GetAxis()
    {
        return (JoyAxis)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxisValue, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAxisValue(float axisValue)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), axisValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAxisValue, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAxisValue()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'axis' property.
        /// </summary>
        public static readonly StringName Axis = "axis";
        /// <summary>
        /// Cached name for the 'axis_value' property.
        /// </summary>
        public static readonly StringName AxisValue = "axis_value";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEvent.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_axis' method.
        /// </summary>
        public static readonly StringName SetAxis = "set_axis";
        /// <summary>
        /// Cached name for the 'get_axis' method.
        /// </summary>
        public static readonly StringName GetAxis = "get_axis";
        /// <summary>
        /// Cached name for the 'set_axis_value' method.
        /// </summary>
        public static readonly StringName SetAxisValue = "set_axis_value";
        /// <summary>
        /// Cached name for the 'get_axis_value' method.
        /// </summary>
        public static readonly StringName GetAxisValue = "get_axis_value";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEvent.SignalName
    {
    }
}
