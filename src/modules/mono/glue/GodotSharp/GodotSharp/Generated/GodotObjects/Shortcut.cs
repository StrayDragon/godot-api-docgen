namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Shortcuts (also known as hotkeys) are containers of <see cref="Godot.InputEvent"/> resources. They are commonly used to interact with a <see cref="Godot.Control"/> element from an <see cref="Godot.InputEvent"/>.</para>
/// <para>One shortcut can contain multiple <see cref="Godot.InputEvent"/> resources, making it possible to trigger one action with multiple different inputs.</para>
/// <para><b>Example:</b> Capture the Ctrl + S shortcut using a <see cref="Godot.Shortcut"/> resource:</para>
/// <para><code>
/// using Godot;
/// 
/// public partial class MyNode : Node
/// {
/// 	private readonly Shortcut _saveShortcut = new Shortcut();
/// 
/// 	public override void _Ready()
/// 	{
/// 		InputEventKey keyEvent = new InputEventKey
/// 		{
/// 			Keycode = Key.S,
/// 			CtrlPressed = true,
/// 			CommandOrControlAutoremap = true, // Swaps Ctrl for Command on Mac.
/// 		};
/// 
/// 		_saveShortcut.Events = [keyEvent];
/// 	}
/// 
/// 	public override void _Input(InputEvent @event)
/// 	{
/// 		if (@event is InputEventKey keyEvent &amp;&amp;
/// 			_saveShortcut.MatchesEvent(@event) &amp;&amp;
/// 			keyEvent.Pressed &amp;&amp; !keyEvent.Echo)
/// 		{
/// 			GD.Print("Save shortcut pressed!");
/// 			GetViewport().SetInputAsHandled();
/// 		}
/// 	}
/// }
/// </code></para>
/// </summary>
public partial class Shortcut : Resource
{
    /// <summary>
    /// <para>The shortcut's <see cref="Godot.InputEvent"/> array.</para>
    /// <para>Generally the <see cref="Godot.InputEvent"/> used is an <see cref="Godot.InputEventKey"/>, though it can be any <see cref="Godot.InputEvent"/>, including an <see cref="Godot.InputEventAction"/>.</para>
    /// </summary>
    public Godot.Collections.Array Events
    {
        get
        {
            return GetEvents();
        }
        set
        {
            SetEvents(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Shortcut);

    private static readonly StringName NativeName = "Shortcut";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Shortcut() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Shortcut(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Shortcut(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEvents, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEvents(Godot.Collections.Array events)
    {
        NativeCalls.godot_icall_1_138(MethodBind0, GodotObject.GetPtr(this), (godot_array)(events ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEvents, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetEvents()
    {
        return NativeCalls.godot_icall_0_120(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasValidEvent, 36873697ul);

    /// <summary>
    /// <para>Returns whether <see cref="Godot.Shortcut.Events"/> contains an <see cref="Godot.InputEvent"/> which is valid.</para>
    /// </summary>
    public bool HasValidEvent()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MatchesEvent, 3738334489ul);

    /// <summary>
    /// <para>Returns whether any <see cref="Godot.InputEvent"/> in <see cref="Godot.Shortcut.Events"/> equals <paramref name="event"/>. This uses <see cref="Godot.InputEvent.IsMatch(InputEvent, bool)"/> to compare events.</para>
    /// </summary>
    public bool MatchesEvent(InputEvent @event)
    {
        return NativeCalls.godot_icall_1_176(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(@event)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAsText, 201670096ul);

    /// <summary>
    /// <para>Returns the shortcut's first valid <see cref="Godot.InputEvent"/> as a <see cref="string"/>.</para>
    /// </summary>
    public string GetAsText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind4, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'events' property.
        /// </summary>
        public static readonly StringName Events = "events";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_events' method.
        /// </summary>
        public static readonly StringName SetEvents = "set_events";
        /// <summary>
        /// Cached name for the 'get_events' method.
        /// </summary>
        public static readonly StringName GetEvents = "get_events";
        /// <summary>
        /// Cached name for the 'has_valid_event' method.
        /// </summary>
        public static readonly StringName HasValidEvent = "has_valid_event";
        /// <summary>
        /// Cached name for the 'matches_event' method.
        /// </summary>
        public static readonly StringName MatchesEvent = "matches_event";
        /// <summary>
        /// Cached name for the 'get_as_text' method.
        /// </summary>
        public static readonly StringName GetAsText = "get_as_text";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
