namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Allows the user to record the sound from an audio bus into an <see cref="Godot.AudioStreamWav"/>. When used on the "Master" audio bus, this includes all audio output by Godot.</para>
/// <para>Unlike <see cref="Godot.AudioEffectCapture"/>, this effect encodes the recording with the given format (8-bit, 16-bit, or compressed) instead of giving access to the raw audio samples.</para>
/// <para>Can be used (with an <see cref="Godot.AudioStreamMicrophone"/>) to record from a microphone.</para>
/// <para><b>Note:</b> <c>ProjectSettings.audio/driver/enable_input</c> must be <see langword="true"/> for audio input to work. See also that setting's description for caveats related to permissions and operating system privacy settings.</para>
/// </summary>
public partial class AudioEffectRecord : AudioEffect
{
    /// <summary>
    /// <para>Specifies the format in which the sample will be recorded.</para>
    /// </summary>
    public AudioStreamWav.FormatEnum Format
    {
        get
        {
            return GetFormat();
        }
        set
        {
            SetFormat(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioEffectRecord);

    private static readonly StringName NativeName = "AudioEffectRecord";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectRecord() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectRecord(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectRecord(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRecordingActive, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the sound will be recorded. Note that restarting the recording will remove the previously recorded sample.</para>
    /// </summary>
    public void SetRecordingActive(bool record)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), record.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRecordingActive, 36873697ul);

    /// <summary>
    /// <para>Returns whether the recording is active or not.</para>
    /// </summary>
    public bool IsRecordingActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFormat, 60648488ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFormat(AudioStreamWav.FormatEnum format)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)format);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFormat, 3151724922ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioStreamWav.FormatEnum GetFormat()
    {
        return (AudioStreamWav.FormatEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRecording, 2964110865ul);

    /// <summary>
    /// <para>Returns the recorded sample.</para>
    /// </summary>
    public AudioStreamWav GetRecording()
    {
        return (AudioStreamWav)NativeCalls.godot_icall_0_63(MethodBind4, GodotObject.GetPtr(this));
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
    public new class PropertyName : AudioEffect.PropertyName
    {
        /// <summary>
        /// Cached name for the 'format' property.
        /// </summary>
        public static readonly StringName Format = "format";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffect.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_recording_active' method.
        /// </summary>
        public static readonly StringName SetRecordingActive = "set_recording_active";
        /// <summary>
        /// Cached name for the 'is_recording_active' method.
        /// </summary>
        public static readonly StringName IsRecordingActive = "is_recording_active";
        /// <summary>
        /// Cached name for the 'set_format' method.
        /// </summary>
        public static readonly StringName SetFormat = "set_format";
        /// <summary>
        /// Cached name for the 'get_format' method.
        /// </summary>
        public static readonly StringName GetFormat = "get_format";
        /// <summary>
        /// Cached name for the 'get_recording' method.
        /// </summary>
        public static readonly StringName GetRecording = "get_recording";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffect.SignalName
    {
    }
}
