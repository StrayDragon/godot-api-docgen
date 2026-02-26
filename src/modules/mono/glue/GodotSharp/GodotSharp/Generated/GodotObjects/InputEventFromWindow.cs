namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>InputEventFromWindow represents events specifically received by windows. This includes mouse events, keyboard events in focused windows or touch screen actions.</para>
/// </summary>
public partial class InputEventFromWindow : InputEvent
{
    /// <summary>
    /// <para>The ID of a <see cref="Godot.Window"/> that received this event.</para>
    /// </summary>
    public long WindowId
    {
        get
        {
            return GetWindowId();
        }
        set
        {
            SetWindowId(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventFromWindow);

    private static readonly StringName NativeName = "InputEventFromWindow";

    internal InputEventFromWindow() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventFromWindow(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventFromWindow(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWindowId, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWindowId(long id)
    {
        NativeCalls.godot_icall_1_10(MethodBind0, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWindowId, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long GetWindowId()
    {
        return NativeCalls.godot_icall_0_4(MethodBind1, GodotObject.GetPtr(this));
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
        /// Cached name for the 'window_id' property.
        /// </summary>
        public static readonly StringName WindowId = "window_id";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEvent.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_window_id' method.
        /// </summary>
        public static readonly StringName SetWindowId = "set_window_id";
        /// <summary>
        /// Cached name for the 'get_window_id' method.
        /// </summary>
        public static readonly StringName GetWindowId = "get_window_id";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEvent.SignalName
    {
    }
}
