namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Manages all <see cref="Godot.InputEventAction"/> which can be created/modified from the project settings menu <b>Project &gt; Project Settings &gt; Input Map</b> or in code with <see cref="Godot.InputMapInstance.AddAction(StringName, float)"/> and <see cref="Godot.InputMapInstance.ActionAddEvent(StringName, InputEvent)"/>. See <see cref="Godot.Node._Input(InputEvent)"/>.</para>
/// </summary>
[GodotClassName("InputMap")]
public partial class InputMapInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(InputMapInstance);

    private static readonly StringName NativeName = "InputMap";

    internal InputMapInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal InputMapInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal InputMapInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAction, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <see cref="Godot.InputMap"/> has a registered action with the given name.</para>
    /// </summary>
    public bool HasAction(StringName action)
    {
        return NativeCalls.godot_icall_1_105(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActions, 2915620761ul);

    /// <summary>
    /// <para>Returns an array of all actions in the <see cref="Godot.InputMap"/>.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetActions()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind1, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAction, 1195233573ul);

    /// <summary>
    /// <para>Adds an empty action to the <see cref="Godot.InputMap"/> with a configurable <paramref name="deadzone"/>.</para>
    /// <para>An <see cref="Godot.InputEvent"/> can then be added to this action with <see cref="Godot.InputMapInstance.ActionAddEvent(StringName, InputEvent)"/>.</para>
    /// </summary>
    public void AddAction(StringName action, float deadzone = 0.20000000298023f)
    {
        NativeCalls.godot_icall_2_751(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default), deadzone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseAction, 3304788590ul);

    /// <summary>
    /// <para>Removes an action from the <see cref="Godot.InputMap"/>.</para>
    /// </summary>
    public void EraseAction(StringName action)
    {
        NativeCalls.godot_icall_1_64(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionDescription, 957595536ul);

    /// <summary>
    /// <para>Returns the human-readable description of the given action.</para>
    /// </summary>
    public string GetActionDescription(StringName action)
    {
        return NativeCalls.godot_icall_1_755(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ActionSetDeadzone, 4135858297ul);

    /// <summary>
    /// <para>Sets a deadzone value for the action.</para>
    /// </summary>
    public void ActionSetDeadzone(StringName action, float deadzone)
    {
        NativeCalls.godot_icall_2_751(MethodBind5, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default), deadzone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ActionGetDeadzone, 1391627649ul);

    /// <summary>
    /// <para>Returns a deadzone value for the action.</para>
    /// </summary>
    public float ActionGetDeadzone(StringName action)
    {
        return NativeCalls.godot_icall_1_756(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ActionAddEvent, 518302593ul);

    /// <summary>
    /// <para>Adds an <see cref="Godot.InputEvent"/> to an action. This <see cref="Godot.InputEvent"/> will trigger the action.</para>
    /// </summary>
    public void ActionAddEvent(StringName action, InputEvent @event)
    {
        NativeCalls.godot_icall_2_159(MethodBind7, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default), GodotObject.GetPtr(@event));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ActionHasEvent, 1185871985ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the action has the given <see cref="Godot.InputEvent"/> associated with it.</para>
    /// </summary>
    public bool ActionHasEvent(StringName action, InputEvent @event)
    {
        return NativeCalls.godot_icall_2_757(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default), GodotObject.GetPtr(@event)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ActionEraseEvent, 518302593ul);

    /// <summary>
    /// <para>Removes an <see cref="Godot.InputEvent"/> from an action.</para>
    /// </summary>
    public void ActionEraseEvent(StringName action, InputEvent @event)
    {
        NativeCalls.godot_icall_2_159(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default), GodotObject.GetPtr(@event));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ActionEraseEvents, 3304788590ul);

    /// <summary>
    /// <para>Removes all events from an action.</para>
    /// </summary>
    public void ActionEraseEvents(StringName action)
    {
        NativeCalls.godot_icall_1_64(MethodBind10, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ActionGetEvents, 689397652ul);

    /// <summary>
    /// <para>Returns an array of <see cref="Godot.InputEvent"/>s associated with a given action.</para>
    /// <para><b>Note:</b> When used in the editor (e.g. a tool script or <c>EditorPlugin</c>), this method will return events for the editor action. If you want to access your project's input binds from the editor, read the <c>input/*</c> settings from <see cref="Godot.ProjectSettings"/>.</para>
    /// </summary>
    public Godot.Collections.Array<InputEvent> ActionGetEvents(StringName action)
    {
        return new Godot.Collections.Array<InputEvent>(NativeCalls.godot_icall_1_696(MethodBind11, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EventIsAction, 3193353650ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given event is part of an existing action. This method ignores keyboard modifiers if the given <see cref="Godot.InputEvent"/> is not pressed (for proper release detection). See <see cref="Godot.InputMapInstance.ActionHasEvent(StringName, InputEvent)"/> if you don't want this behavior.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// </summary>
    public bool EventIsAction(InputEvent @event, StringName action, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_3_758(MethodBind12, GodotObject.GetPtr(this), GodotObject.GetPtr(@event), (godot_string_name)(action?.NativeValue ?? default), exactMatch.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromProjectSettings, 3218959716ul);

    /// <summary>
    /// <para>Clears all <see cref="Godot.InputEventAction"/> in the <see cref="Godot.InputMap"/> and load it anew from <see cref="Godot.ProjectSettings"/>.</para>
    /// </summary>
    public void LoadFromProjectSettings()
    {
        NativeCalls.godot_icall_0_3(MethodBind13, GodotObject.GetPtr(this));
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'has_action' method.
        /// </summary>
        public static readonly StringName HasAction = "has_action";
        /// <summary>
        /// Cached name for the 'get_actions' method.
        /// </summary>
        public static readonly StringName GetActions = "get_actions";
        /// <summary>
        /// Cached name for the 'add_action' method.
        /// </summary>
        public static readonly StringName AddAction = "add_action";
        /// <summary>
        /// Cached name for the 'erase_action' method.
        /// </summary>
        public static readonly StringName EraseAction = "erase_action";
        /// <summary>
        /// Cached name for the 'get_action_description' method.
        /// </summary>
        public static readonly StringName GetActionDescription = "get_action_description";
        /// <summary>
        /// Cached name for the 'action_set_deadzone' method.
        /// </summary>
        public static readonly StringName ActionSetDeadzone = "action_set_deadzone";
        /// <summary>
        /// Cached name for the 'action_get_deadzone' method.
        /// </summary>
        public static readonly StringName ActionGetDeadzone = "action_get_deadzone";
        /// <summary>
        /// Cached name for the 'action_add_event' method.
        /// </summary>
        public static readonly StringName ActionAddEvent = "action_add_event";
        /// <summary>
        /// Cached name for the 'action_has_event' method.
        /// </summary>
        public static readonly StringName ActionHasEvent = "action_has_event";
        /// <summary>
        /// Cached name for the 'action_erase_event' method.
        /// </summary>
        public static readonly StringName ActionEraseEvent = "action_erase_event";
        /// <summary>
        /// Cached name for the 'action_erase_events' method.
        /// </summary>
        public static readonly StringName ActionEraseEvents = "action_erase_events";
        /// <summary>
        /// Cached name for the 'action_get_events' method.
        /// </summary>
        public static readonly StringName ActionGetEvents = "action_get_events";
        /// <summary>
        /// Cached name for the 'event_is_action' method.
        /// </summary>
        public static readonly StringName EventIsAction = "event_is_action";
        /// <summary>
        /// Cached name for the 'load_from_project_settings' method.
        /// </summary>
        public static readonly StringName LoadFromProjectSettings = "load_from_project_settings";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
