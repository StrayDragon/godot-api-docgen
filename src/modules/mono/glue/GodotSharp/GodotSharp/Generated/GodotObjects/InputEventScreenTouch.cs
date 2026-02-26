namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Stores information about multi-touch press/release input events. Supports touch press, touch release and <see cref="Godot.InputEventScreenTouch.Index"/> for multi-touch count and order.</para>
/// </summary>
public partial class InputEventScreenTouch : InputEventFromWindow
{
    /// <summary>
    /// <para>The touch index in the case of a multi-touch event. One index = one finger.</para>
    /// </summary>
    public int Index
    {
        get
        {
            return GetIndex();
        }
        set
        {
            SetIndex(value);
        }
    }

    /// <summary>
    /// <para>The touch position in the viewport the node is in, using the coordinate system of this viewport.</para>
    /// </summary>
    public Vector2 Position
    {
        get
        {
            return GetPosition();
        }
        set
        {
            SetPosition(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the touch event has been canceled.</para>
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
    /// <para>If <see langword="true"/>, the touch's state is pressed. If <see langword="false"/>, the touch's state is released.</para>
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
    /// <para>If <see langword="true"/>, the touch's state is a double tap.</para>
    /// </summary>
    public bool DoubleTap
    {
        get
        {
            return IsDoubleTap();
        }
        set
        {
            SetDoubleTap(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventScreenTouch);

    private static readonly StringName NativeName = "InputEventScreenTouch";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public InputEventScreenTouch() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventScreenTouch(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventScreenTouch(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIndex(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPosition, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPosition(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind2, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind3, GodotObject.GetPtr(this));
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
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDoubleTap, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDoubleTap(bool doubleTap)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), doubleTap.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDoubleTap, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDoubleTap()
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
    public new class PropertyName : InputEventFromWindow.PropertyName
    {
        /// <summary>
        /// Cached name for the 'index' property.
        /// </summary>
        public static readonly StringName Index = "index";
        /// <summary>
        /// Cached name for the 'position' property.
        /// </summary>
        public static readonly StringName Position = "position";
        /// <summary>
        /// Cached name for the 'canceled' property.
        /// </summary>
        public static readonly StringName Canceled = "canceled";
        /// <summary>
        /// Cached name for the 'pressed' property.
        /// </summary>
        public static readonly StringName Pressed = "pressed";
        /// <summary>
        /// Cached name for the 'double_tap' property.
        /// </summary>
        public static readonly StringName DoubleTap = "double_tap";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEventFromWindow.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_index' method.
        /// </summary>
        public static readonly StringName SetIndex = "set_index";
        /// <summary>
        /// Cached name for the 'get_index' method.
        /// </summary>
        public static readonly StringName GetIndex = "get_index";
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'set_pressed' method.
        /// </summary>
        public static readonly StringName SetPressed = "set_pressed";
        /// <summary>
        /// Cached name for the 'set_canceled' method.
        /// </summary>
        public static readonly StringName SetCanceled = "set_canceled";
        /// <summary>
        /// Cached name for the 'set_double_tap' method.
        /// </summary>
        public static readonly StringName SetDoubleTap = "set_double_tap";
        /// <summary>
        /// Cached name for the 'is_double_tap' method.
        /// </summary>
        public static readonly StringName IsDoubleTap = "is_double_tap";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEventFromWindow.SignalName
    {
    }
}
