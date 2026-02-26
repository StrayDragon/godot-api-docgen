namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Contains a generic action which can be targeted from several types of inputs. Actions and their events can be set in the <b>Input Map</b> tab in <b>Project &gt; Project Settings</b>, or with the <see cref="Godot.InputMap"/> class.</para>
/// <para><b>Note:</b> Unlike the other <see cref="Godot.InputEvent"/> subclasses which map to unique physical events, this virtual one is not emitted by the engine. This class is useful to emit actions manually with <see cref="Godot.Input.ParseInputEvent(InputEvent)"/>, which are then received in <see cref="Godot.Node._Input(InputEvent)"/>. To check if a physical event matches an action from the Input Map, use <see cref="Godot.InputEvent.IsAction(StringName, bool)"/> and <see cref="Godot.InputEvent.IsActionPressed(StringName, bool, bool)"/>.</para>
/// </summary>
public partial class InputEventAction : InputEvent
{
    /// <summary>
    /// <para>The action's name. This is usually the name of an existing action in the <see cref="Godot.InputMap"/> which you want this custom event to match.</para>
    /// </summary>
    public StringName Action
    {
        get
        {
            return GetAction();
        }
        set
        {
            SetAction(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the action's state is pressed. If <see langword="false"/>, the action's state is released.</para>
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
    /// <para>The action's strength between 0 and 1. This value is considered as equal to 0 if pressed is <see langword="false"/>. The event strength allows faking analog joypad motion events, by specifying how strongly the joypad axis is bent or pressed.</para>
    /// </summary>
    public float Strength
    {
        get
        {
            return GetStrength();
        }
        set
        {
            SetStrength(value);
        }
    }

    /// <summary>
    /// <para>The real event index in action this event corresponds to (from events defined for this action in the <see cref="Godot.InputMap"/>). If <c>-1</c>, a unique ID will be used and actions pressed with this ID will need to be released with another <see cref="Godot.InputEventAction"/>.</para>
    /// </summary>
    public int EventIndex
    {
        get
        {
            return GetEventIndex();
        }
        set
        {
            SetEventIndex(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventAction);

    private static readonly StringName NativeName = "InputEventAction";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public InputEventAction() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventAction(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventAction(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAction, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAction(StringName action)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAction, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetAction()
    {
        return NativeCalls.godot_icall_0_65(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPressed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPressed(bool pressed)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), pressed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStrength(float strength)
    {
        NativeCalls.godot_icall_1_67(MethodBind3, GodotObject.GetPtr(this), strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEventIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEventIndex(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEventIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetEventIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
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
        /// Cached name for the 'action' property.
        /// </summary>
        public static readonly StringName Action = "action";
        /// <summary>
        /// Cached name for the 'pressed' property.
        /// </summary>
        public static readonly StringName Pressed = "pressed";
        /// <summary>
        /// Cached name for the 'strength' property.
        /// </summary>
        public static readonly StringName Strength = "strength";
        /// <summary>
        /// Cached name for the 'event_index' property.
        /// </summary>
        public static readonly StringName EventIndex = "event_index";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEvent.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_action' method.
        /// </summary>
        public static readonly StringName SetAction = "set_action";
        /// <summary>
        /// Cached name for the 'get_action' method.
        /// </summary>
        public static readonly StringName GetAction = "get_action";
        /// <summary>
        /// Cached name for the 'set_pressed' method.
        /// </summary>
        public static readonly StringName SetPressed = "set_pressed";
        /// <summary>
        /// Cached name for the 'set_strength' method.
        /// </summary>
        public static readonly StringName SetStrength = "set_strength";
        /// <summary>
        /// Cached name for the 'get_strength' method.
        /// </summary>
        public static readonly StringName GetStrength = "get_strength";
        /// <summary>
        /// Cached name for the 'set_event_index' method.
        /// </summary>
        public static readonly StringName SetEventIndex = "set_event_index";
        /// <summary>
        /// Cached name for the 'get_event_index' method.
        /// </summary>
        public static readonly StringName GetEventIndex = "get_event_index";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEvent.SignalName
    {
    }
}
