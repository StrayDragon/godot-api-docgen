namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Stores information about screen drag events. See <see cref="Godot.Node._Input(InputEvent)"/>.</para>
/// </summary>
public partial class InputEventScreenDrag : InputEventFromWindow
{
    /// <summary>
    /// <para>The drag event index in the case of a multi-drag event.</para>
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
    /// <para>Represents the angles of tilt of the pen. Positive X-coordinate value indicates a tilt to the right. Positive Y-coordinate value indicates a tilt toward the user. Ranges from <c>-1.0</c> to <c>1.0</c> for both axes.</para>
    /// </summary>
    public Vector2 Tilt
    {
        get
        {
            return GetTilt();
        }
        set
        {
            SetTilt(value);
        }
    }

    /// <summary>
    /// <para>Represents the pressure the user puts on the pen. Ranges from <c>0.0</c> to <c>1.0</c>.</para>
    /// </summary>
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
    /// <para>Returns <see langword="true"/> when using the eraser end of a stylus pen.</para>
    /// </summary>
    public bool PenInverted
    {
        get
        {
            return GetPenInverted();
        }
        set
        {
            SetPenInverted(value);
        }
    }

    /// <summary>
    /// <para>The drag position in the viewport the node is in, using the coordinate system of this viewport.</para>
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
    /// <para>The drag position relative to the previous position (position at the last frame).</para>
    /// <para><b>Note:</b> <see cref="Godot.InputEventScreenDrag.Relative"/> is automatically scaled according to the content scale factor, which is defined by the project's stretch mode settings. This means touch sensitivity will appear different depending on resolution when using <see cref="Godot.InputEventScreenDrag.Relative"/> in a script that handles touch aiming. To avoid this, use <see cref="Godot.InputEventScreenDrag.ScreenRelative"/> instead.</para>
    /// </summary>
    public Vector2 Relative
    {
        get
        {
            return GetRelative();
        }
        set
        {
            SetRelative(value);
        }
    }

    /// <summary>
    /// <para>The unscaled drag position relative to the previous position in screen coordinates (position at the last frame). This position is <i>not</i> scaled according to the content scale factor or calls to <see cref="Godot.InputEvent.XformedBy(Transform2D, Nullable{Vector2})"/>. This should be preferred over <see cref="Godot.InputEventScreenDrag.Relative"/> for touch aiming regardless of the project's stretch mode.</para>
    /// </summary>
    public Vector2 ScreenRelative
    {
        get
        {
            return GetScreenRelative();
        }
        set
        {
            SetScreenRelative(value);
        }
    }

    /// <summary>
    /// <para>The drag velocity.</para>
    /// <para><b>Note:</b> <see cref="Godot.InputEventScreenDrag.Velocity"/> is automatically scaled according to the content scale factor, which is defined by the project's stretch mode settings. This means touch sensitivity will appear different depending on resolution when using <see cref="Godot.InputEventScreenDrag.Velocity"/> in a script that handles touch aiming. To avoid this, use <see cref="Godot.InputEventScreenDrag.ScreenVelocity"/> instead.</para>
    /// </summary>
    public Vector2 Velocity
    {
        get
        {
            return GetVelocity();
        }
        set
        {
            SetVelocity(value);
        }
    }

    /// <summary>
    /// <para>The unscaled drag velocity in pixels per second in screen coordinates. This velocity is <i>not</i> scaled according to the content scale factor or calls to <see cref="Godot.InputEvent.XformedBy(Transform2D, Nullable{Vector2})"/>. This should be preferred over <see cref="Godot.InputEventScreenDrag.Velocity"/> for touch aiming regardless of the project's stretch mode.</para>
    /// </summary>
    public Vector2 ScreenVelocity
    {
        get
        {
            return GetScreenVelocity();
        }
        set
        {
            SetScreenVelocity(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventScreenDrag);

    private static readonly StringName NativeName = "InputEventScreenDrag";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public InputEventScreenDrag() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventScreenDrag(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventScreenDrag(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTilt, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTilt(Vector2 tilt)
    {
        NativeCalls.godot_icall_1_36(MethodBind2, GodotObject.GetPtr(this), &tilt);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTilt, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetTilt()
    {
        return NativeCalls.godot_icall_0_37(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPressure, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPressure(float pressure)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), pressure);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPressure, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPressure()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPenInverted, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPenInverted(bool penInverted)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), penInverted.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPenInverted, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPenInverted()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPosition, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPosition(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind8, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRelative, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRelative(Vector2 relative)
    {
        NativeCalls.godot_icall_1_36(MethodBind10, GodotObject.GetPtr(this), &relative);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRelative, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetRelative()
    {
        return NativeCalls.godot_icall_0_37(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScreenRelative, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScreenRelative(Vector2 relative)
    {
        NativeCalls.godot_icall_1_36(MethodBind12, GodotObject.GetPtr(this), &relative);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenRelative, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScreenRelative()
    {
        return NativeCalls.godot_icall_0_37(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVelocity, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetVelocity(Vector2 velocity)
    {
        NativeCalls.godot_icall_1_36(MethodBind14, GodotObject.GetPtr(this), &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocity, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetVelocity()
    {
        return NativeCalls.godot_icall_0_37(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScreenVelocity, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScreenVelocity(Vector2 velocity)
    {
        NativeCalls.godot_icall_1_36(MethodBind16, GodotObject.GetPtr(this), &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenVelocity, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScreenVelocity()
    {
        return NativeCalls.godot_icall_0_37(MethodBind17, GodotObject.GetPtr(this));
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
        /// Cached name for the 'tilt' property.
        /// </summary>
        public static readonly StringName Tilt = "tilt";
        /// <summary>
        /// Cached name for the 'pressure' property.
        /// </summary>
        public static readonly StringName Pressure = "pressure";
        /// <summary>
        /// Cached name for the 'pen_inverted' property.
        /// </summary>
        public static readonly StringName PenInverted = "pen_inverted";
        /// <summary>
        /// Cached name for the 'position' property.
        /// </summary>
        public static readonly StringName Position = "position";
        /// <summary>
        /// Cached name for the 'relative' property.
        /// </summary>
        public static readonly StringName Relative = "relative";
        /// <summary>
        /// Cached name for the 'screen_relative' property.
        /// </summary>
        public static readonly StringName ScreenRelative = "screen_relative";
        /// <summary>
        /// Cached name for the 'velocity' property.
        /// </summary>
        public static readonly StringName Velocity = "velocity";
        /// <summary>
        /// Cached name for the 'screen_velocity' property.
        /// </summary>
        public static readonly StringName ScreenVelocity = "screen_velocity";
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
        /// Cached name for the 'set_tilt' method.
        /// </summary>
        public static readonly StringName SetTilt = "set_tilt";
        /// <summary>
        /// Cached name for the 'get_tilt' method.
        /// </summary>
        public static readonly StringName GetTilt = "get_tilt";
        /// <summary>
        /// Cached name for the 'set_pressure' method.
        /// </summary>
        public static readonly StringName SetPressure = "set_pressure";
        /// <summary>
        /// Cached name for the 'get_pressure' method.
        /// </summary>
        public static readonly StringName GetPressure = "get_pressure";
        /// <summary>
        /// Cached name for the 'set_pen_inverted' method.
        /// </summary>
        public static readonly StringName SetPenInverted = "set_pen_inverted";
        /// <summary>
        /// Cached name for the 'get_pen_inverted' method.
        /// </summary>
        public static readonly StringName GetPenInverted = "get_pen_inverted";
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'set_relative' method.
        /// </summary>
        public static readonly StringName SetRelative = "set_relative";
        /// <summary>
        /// Cached name for the 'get_relative' method.
        /// </summary>
        public static readonly StringName GetRelative = "get_relative";
        /// <summary>
        /// Cached name for the 'set_screen_relative' method.
        /// </summary>
        public static readonly StringName SetScreenRelative = "set_screen_relative";
        /// <summary>
        /// Cached name for the 'get_screen_relative' method.
        /// </summary>
        public static readonly StringName GetScreenRelative = "get_screen_relative";
        /// <summary>
        /// Cached name for the 'set_velocity' method.
        /// </summary>
        public static readonly StringName SetVelocity = "set_velocity";
        /// <summary>
        /// Cached name for the 'get_velocity' method.
        /// </summary>
        public static readonly StringName GetVelocity = "get_velocity";
        /// <summary>
        /// Cached name for the 'set_screen_velocity' method.
        /// </summary>
        public static readonly StringName SetScreenVelocity = "set_screen_velocity";
        /// <summary>
        /// Cached name for the 'get_screen_velocity' method.
        /// </summary>
        public static readonly StringName GetScreenVelocity = "get_screen_velocity";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEventFromWindow.SignalName
    {
    }
}
