namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>InputEventShortcut is a special event that can be received in <see cref="Godot.Node._Input(InputEvent)"/>, <see cref="Godot.Node._ShortcutInput(InputEvent)"/>, and <see cref="Godot.Node._UnhandledInput(InputEvent)"/>. It is typically sent by the editor's Command Palette to trigger actions, but can also be sent manually using <see cref="Godot.Viewport.PushInput(InputEvent, bool)"/>.</para>
/// </summary>
public partial class InputEventShortcut : InputEvent
{
    /// <summary>
    /// <para>The <see cref="Godot.Shortcut"/> represented by this event. Its <see cref="Godot.Shortcut.MatchesEvent(InputEvent)"/> method will always return <see langword="true"/> for this event.</para>
    /// </summary>
    public Shortcut Shortcut
    {
        get
        {
            return GetShortcut();
        }
        set
        {
            SetShortcut(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventShortcut);

    private static readonly StringName NativeName = "InputEventShortcut";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public InputEventShortcut() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventShortcut(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventShortcut(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShortcut, 857163497ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShortcut(Shortcut shortcut)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(shortcut));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShortcut, 3766804753ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Shortcut GetShortcut()
    {
        return (Shortcut)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
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
        /// Cached name for the 'shortcut' property.
        /// </summary>
        public static readonly StringName Shortcut = "shortcut";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEvent.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_shortcut' method.
        /// </summary>
        public static readonly StringName SetShortcut = "set_shortcut";
        /// <summary>
        /// Cached name for the 'get_shortcut' method.
        /// </summary>
        public static readonly StringName GetShortcut = "get_shortcut";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEvent.SignalName
    {
    }
}
