namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>InputEventGestures are sent when a user performs a supported gesture on a touch screen. Gestures can't be emulated using mouse, because they typically require multi-touch.</para>
/// </summary>
public partial class InputEventGesture : InputEventWithModifiers
{
    /// <summary>
    /// <para>The local gesture position relative to the <see cref="Godot.Viewport"/>. If used in <see cref="Godot.Control._GuiInput(InputEvent)"/>, the position is relative to the current <see cref="Godot.Control"/> that received this gesture.</para>
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

    private static readonly System.Type CachedType = typeof(InputEventGesture);

    private static readonly StringName NativeName = "InputEventGesture";

    internal InputEventGesture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventGesture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventGesture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPosition, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPosition(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
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
        /// Cached name for the 'position' property.
        /// </summary>
        public static readonly StringName Position = "position";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEventWithModifiers.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEventWithModifiers.SignalName
    {
    }
}
