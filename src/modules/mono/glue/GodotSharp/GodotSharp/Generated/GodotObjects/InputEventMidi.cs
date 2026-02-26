namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>InputEventMIDI stores information about messages from <a href="https://en.wikipedia.org/wiki/MIDI">MIDI</a> (Musical Instrument Digital Interface) devices. These may include musical keyboards, synthesizers, and drum machines.</para>
/// <para>MIDI messages can be received over a 5-pin MIDI connector or over USB. If your device supports both be sure to check the settings in the device to see which output it is using.</para>
/// <para>By default, Godot does not detect MIDI devices. You need to call <see cref="Godot.OS.OpenMidiInputs()"/>, first. You can check which devices are detected with <see cref="Godot.OS.GetConnectedMidiInputs()"/>, and close the connection with <see cref="Godot.OS.CloseMidiInputs()"/>.</para>
/// <para><code>
/// public override void _Ready()
/// {
/// 	OS.OpenMidiInputs();
/// 	GD.Print(OS.GetConnectedMidiInputs());
/// }
/// 
/// public override void _Input(InputEvent inputEvent)
/// {
/// 	if (inputEvent is InputEventMidi midiEvent)
/// 	{
/// 		PrintMIDIInfo(midiEvent);
/// 	}
/// }
/// 
/// private void PrintMIDIInfo(InputEventMidi midiEvent)
/// {
/// 	GD.Print(midiEvent);
/// 	GD.Print($"Channel {midiEvent.Channel}");
/// 	GD.Print($"Message {midiEvent.Message}");
/// 	GD.Print($"Pitch {midiEvent.Pitch}");
/// 	GD.Print($"Velocity {midiEvent.Velocity}");
/// 	GD.Print($"Instrument {midiEvent.Instrument}");
/// 	GD.Print($"Pressure {midiEvent.Pressure}");
/// 	GD.Print($"Controller number: {midiEvent.ControllerNumber}");
/// 	GD.Print($"Controller value: {midiEvent.ControllerValue}");
/// }
/// </code></para>
/// <para><b>Note:</b> Godot does not support MIDI output, so there is no way to emit MIDI messages from Godot. Only MIDI input is supported.</para>
/// <para><b>Note:</b> On the Web platform, using MIDI input requires a browser permission to be granted first. This permission request is performed when calling <see cref="Godot.OS.OpenMidiInputs()"/>. MIDI input will not work until the user accepts the permission request.</para>
/// </summary>
[GodotClassName("InputEventMIDI")]
public partial class InputEventMidi : InputEvent
{
    /// <summary>
    /// <para>The MIDI channel of this message, ranging from <c>0</c> to <c>15</c>. MIDI channel <c>9</c> is reserved for percussion instruments.</para>
    /// </summary>
    public int Channel
    {
        get
        {
            return GetChannel();
        }
        set
        {
            SetChannel(value);
        }
    }

    /// <summary>
    /// <para>Represents the type of MIDI message (see the <see cref="Godot.MidiMessage"/> enum).</para>
    /// <para>For more information, see the <a href="https://www.midi.org/specifications-old/item/table-2-expanded-messages-list-status-bytes">MIDI message status byte list chart</a>.</para>
    /// </summary>
    public MidiMessage Message
    {
        get
        {
            return GetMessage();
        }
        set
        {
            SetMessage(value);
        }
    }

    /// <summary>
    /// <para>The pitch index number of this MIDI message. This value ranges from <c>0</c> to <c>127</c>.</para>
    /// <para>On a piano, the <b>middle C</b> is <c>60</c>, followed by a <b>C-sharp</b> (<c>61</c>), then a <b>D</b> (<c>62</c>), and so on. Each octave is split in offsets of 12. See the "MIDI note number" column of the <a href="https://en.wikipedia.org/wiki/Piano_key_frequencies">piano key frequency chart</a> a full list.</para>
    /// </summary>
    public int Pitch
    {
        get
        {
            return GetPitch();
        }
        set
        {
            SetPitch(value);
        }
    }

    /// <summary>
    /// <para>The velocity of the MIDI message. This value ranges from <c>0</c> to <c>127</c>. For a musical keyboard, this corresponds to how quickly the key was pressed, and is rarely above <c>110</c> in practice.</para>
    /// <para><b>Note:</b> Some MIDI devices may send a <see cref="Godot.MidiMessage.NoteOn"/> message with <c>0</c> velocity and expect it to be treated the same as a <see cref="Godot.MidiMessage.NoteOff"/> message. If necessary, this can be handled with a few lines of code:</para>
    /// <para><code>
    /// func _input(event):
    /// 	if event is InputEventMIDI:
    /// 		if event.message == MIDI_MESSAGE_NOTE_ON and event.velocity &gt; 0:
    /// 			print("Note pressed!")
    /// </code></para>
    /// </summary>
    public int Velocity
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
    /// <para>The instrument (also called <i>program</i> or <i>preset</i>) used on this MIDI message. This value ranges from <c>0</c> to <c>127</c>.</para>
    /// <para>To see what each value means, refer to the <a href="https://en.wikipedia.org/wiki/General_MIDI#Program_change_events">General MIDI's instrument list</a>. Keep in mind that the list is off by 1 because it does not begin from 0. A value of <c>0</c> corresponds to the acoustic grand piano.</para>
    /// </summary>
    public int Instrument
    {
        get
        {
            return GetInstrument();
        }
        set
        {
            SetInstrument(value);
        }
    }

    /// <summary>
    /// <para>The strength of the key being pressed. This value ranges from <c>0</c> to <c>127</c>.</para>
    /// <para><b>Note:</b> For many devices, this value is always <c>0</c>. Other devices such as musical keyboards may simulate pressure by changing the <see cref="Godot.InputEventMidi.Velocity"/>, instead.</para>
    /// </summary>
    public int Pressure
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
    /// <para>The unique number of the controller, if <see cref="Godot.InputEventMidi.Message"/> is <see cref="Godot.MidiMessage.ControlChange"/>, otherwise this is <c>0</c>. This value can be used to identify sliders for volume, balance, and panning, as well as switches and pedals on the MIDI device. See the <a href="https://en.wikipedia.org/wiki/General_MIDI#Controller_events">General MIDI specification</a> for a small list.</para>
    /// </summary>
    public int ControllerNumber
    {
        get
        {
            return GetControllerNumber();
        }
        set
        {
            SetControllerNumber(value);
        }
    }

    /// <summary>
    /// <para>The value applied to the controller. If <see cref="Godot.InputEventMidi.Message"/> is <see cref="Godot.MidiMessage.ControlChange"/>, this value ranges from <c>0</c> to <c>127</c>, otherwise it is <c>0</c>. See also <see cref="Godot.InputEventMidi.ControllerValue"/>.</para>
    /// </summary>
    public int ControllerValue
    {
        get
        {
            return GetControllerValue();
        }
        set
        {
            SetControllerValue(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEventMidi);

    private static readonly StringName NativeName = "InputEventMIDI";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public InputEventMidi() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventMidi(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEventMidi(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetChannel, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetChannel(int channel)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), channel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetChannel, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetChannel()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMessage, 1064271510ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMessage(MidiMessage message)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)message);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMessage, 1936512097ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MidiMessage GetMessage()
    {
        return (MidiMessage)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPitch, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPitch(int pitch)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), pitch);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPitch, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPitch()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVelocity, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVelocity(int velocity)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocity, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetVelocity()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInstrument, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInstrument(int instrument)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), instrument);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstrument, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetInstrument()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPressure, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPressure(int pressure)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), pressure);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPressure, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPressure()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetControllerNumber, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetControllerNumber(int controllerNumber)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), controllerNumber);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetControllerNumber, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetControllerNumber()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetControllerValue, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetControllerValue(int controllerValue)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), controllerValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetControllerValue, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetControllerValue()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
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
        /// Cached name for the 'channel' property.
        /// </summary>
        public static readonly StringName Channel = "channel";
        /// <summary>
        /// Cached name for the 'message' property.
        /// </summary>
        public static readonly StringName Message = "message";
        /// <summary>
        /// Cached name for the 'pitch' property.
        /// </summary>
        public static readonly StringName Pitch = "pitch";
        /// <summary>
        /// Cached name for the 'velocity' property.
        /// </summary>
        public static readonly StringName Velocity = "velocity";
        /// <summary>
        /// Cached name for the 'instrument' property.
        /// </summary>
        public static readonly StringName Instrument = "instrument";
        /// <summary>
        /// Cached name for the 'pressure' property.
        /// </summary>
        public static readonly StringName Pressure = "pressure";
        /// <summary>
        /// Cached name for the 'controller_number' property.
        /// </summary>
        public static readonly StringName ControllerNumber = "controller_number";
        /// <summary>
        /// Cached name for the 'controller_value' property.
        /// </summary>
        public static readonly StringName ControllerValue = "controller_value";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : InputEvent.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_channel' method.
        /// </summary>
        public static readonly StringName SetChannel = "set_channel";
        /// <summary>
        /// Cached name for the 'get_channel' method.
        /// </summary>
        public static readonly StringName GetChannel = "get_channel";
        /// <summary>
        /// Cached name for the 'set_message' method.
        /// </summary>
        public static readonly StringName SetMessage = "set_message";
        /// <summary>
        /// Cached name for the 'get_message' method.
        /// </summary>
        public static readonly StringName GetMessage = "get_message";
        /// <summary>
        /// Cached name for the 'set_pitch' method.
        /// </summary>
        public static readonly StringName SetPitch = "set_pitch";
        /// <summary>
        /// Cached name for the 'get_pitch' method.
        /// </summary>
        public static readonly StringName GetPitch = "get_pitch";
        /// <summary>
        /// Cached name for the 'set_velocity' method.
        /// </summary>
        public static readonly StringName SetVelocity = "set_velocity";
        /// <summary>
        /// Cached name for the 'get_velocity' method.
        /// </summary>
        public static readonly StringName GetVelocity = "get_velocity";
        /// <summary>
        /// Cached name for the 'set_instrument' method.
        /// </summary>
        public static readonly StringName SetInstrument = "set_instrument";
        /// <summary>
        /// Cached name for the 'get_instrument' method.
        /// </summary>
        public static readonly StringName GetInstrument = "get_instrument";
        /// <summary>
        /// Cached name for the 'set_pressure' method.
        /// </summary>
        public static readonly StringName SetPressure = "set_pressure";
        /// <summary>
        /// Cached name for the 'get_pressure' method.
        /// </summary>
        public static readonly StringName GetPressure = "get_pressure";
        /// <summary>
        /// Cached name for the 'set_controller_number' method.
        /// </summary>
        public static readonly StringName SetControllerNumber = "set_controller_number";
        /// <summary>
        /// Cached name for the 'get_controller_number' method.
        /// </summary>
        public static readonly StringName GetControllerNumber = "get_controller_number";
        /// <summary>
        /// Cached name for the 'set_controller_value' method.
        /// </summary>
        public static readonly StringName SetControllerValue = "set_controller_value";
        /// <summary>
        /// Cached name for the 'get_controller_value' method.
        /// </summary>
        public static readonly StringName GetControllerValue = "get_controller_value";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : InputEvent.SignalName
    {
    }
}
