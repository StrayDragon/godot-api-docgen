namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Stores general information about mouse events.</para>
/// </summary>
public partial class InputEventMouse : InputEventWithModifiers
{
    /// <summary>
    /// <para>The mouse button mask identifier, one of or a bitwise combination of the <see cref="Godot.MouseButton"/> button masks.</para>
    /// </summary>
    public MouseButtonMask ButtonMask
    {
        get
        {
            return GetButtonMask();
        }
        set
        {
            SetButtonMask(value);
        }
    }

    /// <summary>
    /// <para>When received in <see cref="Godot.Node._Input(InputEvent)"/> or <see cref="Godot.Node._UnhandledInput(InputEvent)"/>, returns the mouse's position in the <see cref="Godot.Viewport"/> this <see cref="Godot.Node"/> is in using the coordinate system of this <see cref="Godot.Viewport"/>.</para>
    /// <para>When received in <see cref="Godot.Control._GuiInput(InputEvent)"/>, returns the mouse's position in the <see cref="Godot.Control"/> using the local coordinate system of the <see cref="Godot.Control"/>.</para>
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
    /// <para>When received in <see cref="Godot.Node._Input(InputEvent)"/> or <see cref="Godot.Node._UnhandledInput(InputEvent)"/>, returns the mouse's position in the root <see cref="Godot.Viewport"/> using the coordinate system of the root <see cref="Godot.Viewport"/>.</para>
    /// <para>When received in <see cref="Godot.Control._GuiInput(InputEvent)"/>, returns the mouse's position in the <see cref="Godot.CanvasLayer"/> that the <see cref="Godot.Control"/> is in using the coordinate system of the <see cref="Godot.CanvasLayer"/>.</para>
    /// </summary>
    public Vector2 GlobalPosition
    {
        get
        {
            return GetGlobalPosition();
        }
        set
        {
            SetGlobalPosition(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventMouse);

    private static readonly StringName NativeName = "InputEventMouse";

    internal InputEventMouse() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventMouse(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventMouse(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButtonMask, 3950145251ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetButtonMask(MouseButtonMask buttonMask)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)buttonMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonMask, 2512161324ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MouseButtonMask GetButtonMask()
    {
        return (MouseButtonMask)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalPosition, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGlobalPosition(Vector2 globalPosition)
    {
        NativeCalls.godot_icall_1_36(MethodBind4, GodotObject.GetPtr(this), &globalPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalPosition, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetGlobalPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : InputEventWithModifiers.PropertyName
    {
        /// <summary>
        /// Cached name for the 'button_mask' property.
        /// </summary>
        public static readonly StringName ButtonMask = "button_mask";
        /// <summary>
        /// Cached name for the 'position' property.
        /// </summary>
        public static readonly StringName Position = "position";
        /// <summary>
        /// Cached name for the 'global_position' property.
        /// </summary>
        public static readonly StringName GlobalPosition = "global_position";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEventWithModifiers.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_button_mask' method.
        /// </summary>
        public static readonly StringName SetButtonMask = "set_button_mask";
        /// <summary>
        /// Cached name for the 'get_button_mask' method.
        /// </summary>
        public static readonly StringName GetButtonMask = "get_button_mask";
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'set_global_position' method.
        /// </summary>
        public static readonly StringName SetGlobalPosition = "set_global_position";
        /// <summary>
        /// Cached name for the 'get_global_position' method.
        /// </summary>
        public static readonly StringName GetGlobalPosition = "get_global_position";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEventWithModifiers.SignalName
    {
    }
}
