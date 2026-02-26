namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.AudioServer"/> is a low-level server interface for audio access. It is in charge of creating sample data (playable audio) as well as its playback via a voice interface.</para>
/// </summary>
public static partial class AudioServer
{
    public enum SpeakerMode : long
    {
        /// <summary>
        /// <para>Two or fewer speakers were detected.</para>
        /// </summary>
        ModeStereo = 0,
        /// <summary>
        /// <para>A 3.1 channel surround setup was detected.</para>
        /// </summary>
        Surround31 = 1,
        /// <summary>
        /// <para>A 5.1 channel surround setup was detected.</para>
        /// </summary>
        Surround51 = 2,
        /// <summary>
        /// <para>A 7.1 channel surround setup was detected.</para>
        /// </summary>
        Surround71 = 3
    }

    public enum PlaybackType : long
    {
        /// <summary>
        /// <para>The playback will be considered of the type declared at <c>ProjectSettings.audio/general/default_playback_type</c>.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>Force the playback to be considered as a stream.</para>
        /// </summary>
        Stream = 1,
        /// <summary>
        /// <para>Force the playback to be considered as a sample. This can provide lower latency and more stable playback (with less risk of audio crackling), at the cost of having less flexibility.</para>
        /// <para><b>Note:</b> Only currently supported on the web platform.</para>
        /// <para><b>Note:</b> <see cref="Godot.AudioEffect"/>s are not supported when playback is considered as a sample.</para>
        /// </summary>
        Sample = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.AudioServer.PlaybackType"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>Number of available audio buses.</para>
    /// </summary>
    public static int BusCount
    {
        get
        {
            return GetBusCount();
        }
        set
        {
            SetBusCount(value);
        }
    }

    /// <summary>
    /// <para>Name of the current device for audio output (see <see cref="Godot.AudioServer.GetOutputDeviceList()"/>). On systems with multiple audio outputs (such as analog, USB and HDMI audio), this can be used to select the audio output device. The value <c>"Default"</c> will play audio on the system-wide default audio output. If an invalid device name is set, the value will be reverted back to <c>"Default"</c>.</para>
    /// </summary>
    public static string OutputDevice
    {
        get
        {
            return GetOutputDevice();
        }
        set
        {
            SetOutputDevice(value);
        }
    }

    /// <summary>
    /// <para>Name of the current device for audio input (see <see cref="Godot.AudioServer.GetInputDeviceList()"/>). On systems with multiple audio inputs (such as analog, USB and HDMI audio), this can be used to select the audio input device. The value <c>"Default"</c> will record audio on the system-wide default audio input. If an invalid device name is set, the value will be reverted back to <c>"Default"</c>.</para>
    /// <para><b>Note:</b> <c>ProjectSettings.audio/driver/enable_input</c> must be <see langword="true"/> for audio input to work. See also that setting's description for caveats related to permissions and operating system privacy settings.</para>
    /// </summary>
    public static string InputDevice
    {
        get
        {
            return GetInputDevice();
        }
        set
        {
            SetInputDevice(value);
        }
    }

    /// <summary>
    /// <para>Scales the rate at which audio is played (i.e. setting it to <c>0.5</c> will make the audio be played at half its speed). See also <see cref="Godot.Engine.TimeScale"/> to affect the general simulation speed, which is independent from <see cref="Godot.AudioServer.PlaybackSpeedScale"/>.</para>
    /// </summary>
    public static float PlaybackSpeedScale
    {
        get
        {
            return GetPlaybackSpeedScale();
        }
        set
        {
            SetPlaybackSpeedScale(value);
        }
    }

    private static readonly StringName NativeName = "AudioServer";

    private static AudioServerInstance singleton;

    public static AudioServerInstance Singleton =>
        singleton ??= (AudioServerInstance)InteropUtils.EngineGetSingleton("AudioServer");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBusCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetBusCount(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(Singleton), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static int GetBusCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveBus, 1286410249ul);

    /// <summary>
    /// <para>Removes the bus at index <paramref name="index"/>.</para>
    /// </summary>
    public static void RemoveBus(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(Singleton), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddBus, 1025054187ul);

    /// <summary>
    /// <para>Adds a bus at <paramref name="atPosition"/>.</para>
    /// </summary>
    public static void AddBus(int atPosition = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(Singleton), atPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveBus, 3937882851ul);

    /// <summary>
    /// <para>Moves the bus from index <paramref name="index"/> to index <paramref name="toIndex"/>.</para>
    /// </summary>
    public static void MoveBus(int index, int toIndex)
    {
        NativeCalls.godot_icall_2_59(MethodBind4, GodotObject.GetPtr(Singleton), index, toIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBusName, 501894301ul);

    /// <summary>
    /// <para>Sets the name of the bus at index <paramref name="busIdx"/> to <paramref name="name"/>.</para>
    /// </summary>
    public static void SetBusName(int busIdx, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind5, GodotObject.GetPtr(Singleton), busIdx, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusName, 844755477ul);

    /// <summary>
    /// <para>Returns the name of the bus with the index <paramref name="busIdx"/>.</para>
    /// </summary>
    public static string GetBusName(int busIdx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind6, GodotObject.GetPtr(Singleton), busIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusIndex, 2458036349ul);

    /// <summary>
    /// <para>Returns the index of the bus with the name <paramref name="busName"/>. Returns <c>-1</c> if no bus with the specified name exist.</para>
    /// </summary>
    public static int GetBusIndex(StringName busName)
    {
        return NativeCalls.godot_icall_1_193(MethodBind7, GodotObject.GetPtr(Singleton), (godot_string_name)(busName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusChannels, 923996154ul);

    /// <summary>
    /// <para>Returns the number of channels of the bus at index <paramref name="busIdx"/>.</para>
    /// </summary>
    public static int GetBusChannels(int busIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind8, GodotObject.GetPtr(Singleton), busIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBusVolumeDb, 1602489585ul);

    /// <summary>
    /// <para>Sets the volume in decibels of the bus at index <paramref name="busIdx"/> to <paramref name="volumeDb"/>.</para>
    /// </summary>
    public static void SetBusVolumeDb(int busIdx, float volumeDb)
    {
        NativeCalls.godot_icall_2_69(MethodBind9, GodotObject.GetPtr(Singleton), busIdx, volumeDb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusVolumeDb, 2339986948ul);

    /// <summary>
    /// <para>Returns the volume of the bus at index <paramref name="busIdx"/> in dB.</para>
    /// </summary>
    public static float GetBusVolumeDb(int busIdx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind10, GodotObject.GetPtr(Singleton), busIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBusVolumeLinear, 1602489585ul);

    /// <summary>
    /// <para>Sets the volume as a linear value of the bus at index <paramref name="busIdx"/> to <paramref name="volumeLinear"/>.</para>
    /// <para><b>Note:</b> Using this method is equivalent to calling <see cref="Godot.AudioServer.SetBusVolumeDb(int, float)"/> with the result of <c>@GlobalScope.linear_to_db</c> on a value.</para>
    /// </summary>
    public static void SetBusVolumeLinear(int busIdx, float volumeLinear)
    {
        NativeCalls.godot_icall_2_69(MethodBind11, GodotObject.GetPtr(Singleton), busIdx, volumeLinear);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusVolumeLinear, 2339986948ul);

    /// <summary>
    /// <para>Returns the volume of the bus at index <paramref name="busIdx"/> as a linear value.</para>
    /// <para><b>Note:</b> The returned value is equivalent to the result of <c>@GlobalScope.db_to_linear</c> on the result of <see cref="Godot.AudioServer.GetBusVolumeDb(int)"/>.</para>
    /// </summary>
    public static float GetBusVolumeLinear(int busIdx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind12, GodotObject.GetPtr(Singleton), busIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBusSend, 3780747571ul);

    /// <summary>
    /// <para>Connects the output of the bus at <paramref name="busIdx"/> to the bus named <paramref name="send"/>.</para>
    /// </summary>
    public static void SetBusSend(int busIdx, StringName send)
    {
        NativeCalls.godot_icall_2_178(MethodBind13, GodotObject.GetPtr(Singleton), busIdx, (godot_string_name)(send?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusSend, 659327637ul);

    /// <summary>
    /// <para>Returns the name of the bus that the bus at index <paramref name="busIdx"/> sends to.</para>
    /// </summary>
    public static StringName GetBusSend(int busIdx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind14, GodotObject.GetPtr(Singleton), busIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBusSolo, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the bus at index <paramref name="busIdx"/> is in solo mode.</para>
    /// </summary>
    public static void SetBusSolo(int busIdx, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind15, GodotObject.GetPtr(Singleton), busIdx, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBusSolo, 1116898809ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the bus at index <paramref name="busIdx"/> is in solo mode.</para>
    /// </summary>
    public static bool IsBusSolo(int busIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind16, GodotObject.GetPtr(Singleton), busIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBusMute, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the bus at index <paramref name="busIdx"/> is muted.</para>
    /// </summary>
    public static void SetBusMute(int busIdx, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind17, GodotObject.GetPtr(Singleton), busIdx, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBusMute, 1116898809ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the bus at index <paramref name="busIdx"/> is muted.</para>
    /// </summary>
    public static bool IsBusMute(int busIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind18, GodotObject.GetPtr(Singleton), busIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBusBypassEffects, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the bus at index <paramref name="busIdx"/> is bypassing effects.</para>
    /// </summary>
    public static void SetBusBypassEffects(int busIdx, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind19, GodotObject.GetPtr(Singleton), busIdx, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBusBypassingEffects, 1116898809ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the bus at index <paramref name="busIdx"/> is bypassing effects.</para>
    /// </summary>
    public static bool IsBusBypassingEffects(int busIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind20, GodotObject.GetPtr(Singleton), busIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddBusEffect, 4068819785ul);

    /// <summary>
    /// <para>Adds an <see cref="Godot.AudioEffect"/> effect to the bus <paramref name="busIdx"/> at <paramref name="atPosition"/>.</para>
    /// </summary>
    public static void AddBusEffect(int busIdx, AudioEffect effect, int atPosition = -1)
    {
        NativeCalls.godot_icall_3_194(MethodBind21, GodotObject.GetPtr(Singleton), busIdx, GodotObject.GetPtr(effect), atPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveBusEffect, 3937882851ul);

    /// <summary>
    /// <para>Removes the effect at index <paramref name="effectIdx"/> from the bus at index <paramref name="busIdx"/>.</para>
    /// </summary>
    public static void RemoveBusEffect(int busIdx, int effectIdx)
    {
        NativeCalls.godot_icall_2_59(MethodBind22, GodotObject.GetPtr(Singleton), busIdx, effectIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusEffectCount, 3744713108ul);

    /// <summary>
    /// <para>Returns the number of effects on the bus at <paramref name="busIdx"/>.</para>
    /// </summary>
    public static int GetBusEffectCount(int busIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind23, GodotObject.GetPtr(Singleton), busIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusEffect, 726064442ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.AudioEffect"/> at position <paramref name="effectIdx"/> in bus <paramref name="busIdx"/>.</para>
    /// </summary>
    public static AudioEffect GetBusEffect(int busIdx, int effectIdx)
    {
        return (AudioEffect)NativeCalls.godot_icall_2_101(MethodBind24, GodotObject.GetPtr(Singleton), busIdx, effectIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusEffectInstance, 1829771234ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.AudioEffectInstance"/> assigned to the given bus and effect indices (and optionally channel).</para>
    /// </summary>
    public static AudioEffectInstance GetBusEffectInstance(int busIdx, int effectIdx, int channel = 0)
    {
        return (AudioEffectInstance)NativeCalls.godot_icall_3_195(MethodBind25, GodotObject.GetPtr(Singleton), busIdx, effectIdx, channel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SwapBusEffects, 1649997291ul);

    /// <summary>
    /// <para>Swaps the position of two effects in bus <paramref name="busIdx"/>.</para>
    /// </summary>
    public static void SwapBusEffects(int busIdx, int effectIdx, int byEffectIdx)
    {
        NativeCalls.godot_icall_3_196(MethodBind26, GodotObject.GetPtr(Singleton), busIdx, effectIdx, byEffectIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBusEffectEnabled, 1383440665ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the effect at index <paramref name="effectIdx"/> on the bus at index <paramref name="busIdx"/> is enabled.</para>
    /// </summary>
    public static void SetBusEffectEnabled(int busIdx, int effectIdx, bool enabled)
    {
        NativeCalls.godot_icall_3_197(MethodBind27, GodotObject.GetPtr(Singleton), busIdx, effectIdx, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBusEffectEnabled, 2522259332ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the effect at index <paramref name="effectIdx"/> on the bus at index <paramref name="busIdx"/> is enabled.</para>
    /// </summary>
    public static bool IsBusEffectEnabled(int busIdx, int effectIdx)
    {
        return NativeCalls.godot_icall_2_40(MethodBind28, GodotObject.GetPtr(Singleton), busIdx, effectIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusPeakVolumeLeftDb, 3085491603ul);

    /// <summary>
    /// <para>Returns the peak volume of the left speaker at bus index <paramref name="busIdx"/> and channel index <paramref name="channel"/>.</para>
    /// </summary>
    public static float GetBusPeakVolumeLeftDb(int busIdx, int channel)
    {
        return NativeCalls.godot_icall_2_88(MethodBind29, GodotObject.GetPtr(Singleton), busIdx, channel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBusPeakVolumeRightDb, 3085491603ul);

    /// <summary>
    /// <para>Returns the peak volume of the right speaker at bus index <paramref name="busIdx"/> and channel index <paramref name="channel"/>.</para>
    /// </summary>
    public static float GetBusPeakVolumeRightDb(int busIdx, int channel)
    {
        return NativeCalls.godot_icall_2_88(MethodBind30, GodotObject.GetPtr(Singleton), busIdx, channel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaybackSpeedScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetPlaybackSpeedScale(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind31, GodotObject.GetPtr(Singleton), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaybackSpeedScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static float GetPlaybackSpeedScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind32, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Lock, 3218959716ul);

    /// <summary>
    /// <para>Locks the audio driver's main loop.</para>
    /// <para><b>Note:</b> Remember to unlock it afterwards.</para>
    /// </summary>
    public static void Lock()
    {
        NativeCalls.godot_icall_0_3(MethodBind33, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Unlock, 3218959716ul);

    /// <summary>
    /// <para>Unlocks the audio driver's main loop. (After locking it, you should always unlock it.)</para>
    /// </summary>
    public static void Unlock()
    {
        NativeCalls.godot_icall_0_3(MethodBind34, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpeakerMode, 2549190337ul);

    /// <summary>
    /// <para>Returns the speaker configuration.</para>
    /// </summary>
    public static AudioServer.SpeakerMode GetSpeakerMode()
    {
        return (AudioServer.SpeakerMode)NativeCalls.godot_icall_0_39(MethodBind35, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMixRate, 1740695150ul);

    /// <summary>
    /// <para>Returns the sample rate at the output of the <see cref="Godot.AudioServer"/>.</para>
    /// </summary>
    public static float GetMixRate()
    {
        return NativeCalls.godot_icall_0_68(MethodBind36, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputMixRate, 1740695150ul);

    /// <summary>
    /// <para>Returns the sample rate at the input of the <see cref="Godot.AudioServer"/>.</para>
    /// </summary>
    public static float GetInputMixRate()
    {
        return NativeCalls.godot_icall_0_68(MethodBind37, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDriverName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the current audio driver. The default usually depends on the operating system, but may be overridden via the <c>--audio-driver</c> <a href="$DOCS_URL/tutorials/editor/command_line_tutorial.html">command line argument</a>. <c>--headless</c> also automatically sets the audio driver to <c>Dummy</c>. See also <c>ProjectSettings.audio/driver/driver</c>.</para>
    /// </summary>
    public static string GetDriverName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind38, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputDeviceList, 2981934095ul);

    /// <summary>
    /// <para>Returns the names of all audio output devices detected on the system.</para>
    /// </summary>
    public static string[] GetOutputDeviceList()
    {
        return NativeCalls.godot_icall_0_108(MethodBind39, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputDevice, 2841200299ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string GetOutputDevice()
    {
        return NativeCalls.godot_icall_0_58(MethodBind40, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutputDevice, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetOutputDevice(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind41, GodotObject.GetPtr(Singleton), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeToNextMix, 1740695150ul);

    /// <summary>
    /// <para>Returns the relative time until the next mix occurs.</para>
    /// </summary>
    public static double GetTimeToNextMix()
    {
        return NativeCalls.godot_icall_0_144(MethodBind42, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeSinceLastMix, 1740695150ul);

    /// <summary>
    /// <para>Returns the relative time since the last mix occurred.</para>
    /// </summary>
    public static double GetTimeSinceLastMix()
    {
        return NativeCalls.godot_icall_0_144(MethodBind43, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputLatency, 1740695150ul);

    /// <summary>
    /// <para>Returns the audio driver's effective output latency. This is based on <c>ProjectSettings.audio/driver/output_latency</c>, but the exact returned value will differ depending on the operating system and audio driver.</para>
    /// <para><b>Note:</b> This can be expensive; it is not recommended to call <see cref="Godot.AudioServer.GetOutputLatency()"/> every frame.</para>
    /// </summary>
    public static double GetOutputLatency()
    {
        return NativeCalls.godot_icall_0_144(MethodBind44, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputDeviceList, 2981934095ul);

    /// <summary>
    /// <para>Returns the names of all audio input devices detected on the system.</para>
    /// <para><b>Note:</b> <c>ProjectSettings.audio/driver/enable_input</c> must be <see langword="true"/> for audio input to work. See also that setting's description for caveats related to permissions and operating system privacy settings.</para>
    /// </summary>
    public static string[] GetInputDeviceList()
    {
        return NativeCalls.godot_icall_0_108(MethodBind45, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputDevice, 2841200299ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string GetInputDevice()
    {
        return NativeCalls.godot_icall_0_58(MethodBind46, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputDevice, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetInputDevice(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind47, GodotObject.GetPtr(Singleton), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputDeviceActive, 1413768114ul);

    /// <summary>
    /// <para>If <paramref name="active"/> is <see langword="true"/>, starts the microphone input stream specified by <see cref="Godot.AudioServer.InputDevice"/> or returns an error if it failed.</para>
    /// <para>If <paramref name="active"/> is <see langword="false"/>, stops the input stream if it is running.</para>
    /// </summary>
    public static Error SetInputDeviceActive(bool active)
    {
        return (Error)NativeCalls.godot_icall_1_198(MethodBind48, GodotObject.GetPtr(Singleton), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputFramesAvailable, 2455072627ul);

    /// <summary>
    /// <para>Returns the number of frames available to read using <see cref="Godot.AudioServer.GetInputFrames(int)"/>.</para>
    /// </summary>
    public static int GetInputFramesAvailable()
    {
        return NativeCalls.godot_icall_0_39(MethodBind49, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputBufferLengthFrames, 2455072627ul);

    /// <summary>
    /// <para>Returns the absolute size of the microphone input buffer. This is set to a multiple of the audio latency and can be used to estimate the minimum rate at which the frames need to be fetched.</para>
    /// </summary>
    public static int GetInputBufferLengthFrames()
    {
        return NativeCalls.godot_icall_0_39(MethodBind50, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputFrames, 2649534757ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector2"/>[] containing exactly <paramref name="frames"/> audio samples from the internal microphone buffer if available, otherwise returns an empty <see cref="Godot.Vector2"/>[].</para>
    /// <para>The buffer is filled at the rate of <see cref="Godot.AudioServer.GetInputMixRate()"/> frames per second when <see cref="Godot.AudioServer.SetInputDeviceActive(bool)"/> has successfully been set to <see langword="true"/>.</para>
    /// <para>The samples are signed floating-point PCM values between <c>-1</c> and <c>1</c>.</para>
    /// </summary>
    public static Vector2[] GetInputFrames(int frames)
    {
        return NativeCalls.godot_icall_1_190(MethodBind51, GodotObject.GetPtr(Singleton), frames);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBusLayout, 3319058824ul);

    /// <summary>
    /// <para>Overwrites the currently used <see cref="Godot.AudioBusLayout"/>.</para>
    /// </summary>
    public static void SetBusLayout(AudioBusLayout busLayout)
    {
        NativeCalls.godot_icall_1_56(MethodBind52, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(busLayout));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateBusLayout, 3769973890ul);

    /// <summary>
    /// <para>Generates an <see cref="Godot.AudioBusLayout"/> using the available buses and effects.</para>
    /// </summary>
    public static AudioBusLayout GenerateBusLayout()
    {
        return (AudioBusLayout)NativeCalls.godot_icall_0_63(MethodBind53, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableTaggingUsedAudioStreams, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, all instances of <see cref="Godot.AudioStreamPlayback"/> will call <see cref="Godot.AudioStreamPlayback._TagUsedStreams()"/> every mix step.</para>
    /// <para><b>Note:</b> This is enabled by default in the editor, as it is used by editor plugins for the audio stream previews.</para>
    /// </summary>
    public static void SetEnableTaggingUsedAudioStreams(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind54, GodotObject.GetPtr(Singleton), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsStreamRegisteredAsSample, 500225754ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the stream is registered as a sample. The engine will not have to register it before playing the sample.</para>
    /// <para>If <see langword="false"/>, the stream will have to be registered before playing it. To prevent lag spikes, register the stream as sample with <see cref="Godot.AudioServer.RegisterStreamAsSample(AudioStream)"/>.</para>
    /// </summary>
    public static bool IsStreamRegisteredAsSample(AudioStream stream)
    {
        return NativeCalls.godot_icall_1_176(MethodBind55, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(stream)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterStreamAsSample, 2210767741ul);

    /// <summary>
    /// <para>Forces the registration of a stream as a sample.</para>
    /// <para><b>Note:</b> Lag spikes may occur when calling this method, especially on single-threaded builds. It is suggested to call this method while loading assets, where the lag spike could be masked, instead of registering the sample right before it needs to be played.</para>
    /// </summary>
    public static void RegisterStreamAsSample(AudioStream stream)
    {
        NativeCalls.godot_icall_1_56(MethodBind56, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(stream));
    }

    /// <summary>
    /// <para>Emitted when an audio bus is added, deleted, or moved.</para>
    /// </summary>
    public static event Action BusLayoutChanged
    {
        add => Singleton.Connect(SignalName.BusLayoutChanged, Callable.From(value));
        remove => Singleton.Disconnect(SignalName.BusLayoutChanged, Callable.From(value));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AudioServer.BusRenamed"/> event of a <see cref="Godot.AudioServer"/> class.
    /// </summary>
    public delegate void BusRenamedEventHandler(long busIndex, StringName oldName, StringName newName);

    private static void BusRenamedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((BusRenamedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]), VariantUtils.ConvertTo<StringName>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the audio bus at <c>busIndex</c> is renamed from <c>oldName</c> to <c>newName</c>.</para>
    /// </summary>
    public static unsafe event BusRenamedEventHandler BusRenamed
    {
        add => Singleton.Connect(SignalName.BusRenamed, Callable.CreateWithUnsafeTrampoline(value, &BusRenamedTrampoline));
        remove => Singleton.Disconnect(SignalName.BusRenamed, Callable.CreateWithUnsafeTrampoline(value, &BusRenamedTrampoline));
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
        /// <summary>
        /// Cached name for the 'bus_count' property.
        /// </summary>
        public static readonly StringName BusCount = "bus_count";
        /// <summary>
        /// Cached name for the 'output_device' property.
        /// </summary>
        public static readonly StringName OutputDevice = "output_device";
        /// <summary>
        /// Cached name for the 'input_device' property.
        /// </summary>
        public static readonly StringName InputDevice = "input_device";
        /// <summary>
        /// Cached name for the 'playback_speed_scale' property.
        /// </summary>
        public static readonly StringName PlaybackSpeedScale = "playback_speed_scale";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'set_bus_count' method.
        /// </summary>
        public static readonly StringName SetBusCount = "set_bus_count";
        /// <summary>
        /// Cached name for the 'get_bus_count' method.
        /// </summary>
        public static readonly StringName GetBusCount = "get_bus_count";
        /// <summary>
        /// Cached name for the 'remove_bus' method.
        /// </summary>
        public static readonly StringName RemoveBus = "remove_bus";
        /// <summary>
        /// Cached name for the 'add_bus' method.
        /// </summary>
        public static readonly StringName AddBus = "add_bus";
        /// <summary>
        /// Cached name for the 'move_bus' method.
        /// </summary>
        public static readonly StringName MoveBus = "move_bus";
        /// <summary>
        /// Cached name for the 'set_bus_name' method.
        /// </summary>
        public static readonly StringName SetBusName = "set_bus_name";
        /// <summary>
        /// Cached name for the 'get_bus_name' method.
        /// </summary>
        public static readonly StringName GetBusName = "get_bus_name";
        /// <summary>
        /// Cached name for the 'get_bus_index' method.
        /// </summary>
        public static readonly StringName GetBusIndex = "get_bus_index";
        /// <summary>
        /// Cached name for the 'get_bus_channels' method.
        /// </summary>
        public static readonly StringName GetBusChannels = "get_bus_channels";
        /// <summary>
        /// Cached name for the 'set_bus_volume_db' method.
        /// </summary>
        public static readonly StringName SetBusVolumeDb = "set_bus_volume_db";
        /// <summary>
        /// Cached name for the 'get_bus_volume_db' method.
        /// </summary>
        public static readonly StringName GetBusVolumeDb = "get_bus_volume_db";
        /// <summary>
        /// Cached name for the 'set_bus_volume_linear' method.
        /// </summary>
        public static readonly StringName SetBusVolumeLinear = "set_bus_volume_linear";
        /// <summary>
        /// Cached name for the 'get_bus_volume_linear' method.
        /// </summary>
        public static readonly StringName GetBusVolumeLinear = "get_bus_volume_linear";
        /// <summary>
        /// Cached name for the 'set_bus_send' method.
        /// </summary>
        public static readonly StringName SetBusSend = "set_bus_send";
        /// <summary>
        /// Cached name for the 'get_bus_send' method.
        /// </summary>
        public static readonly StringName GetBusSend = "get_bus_send";
        /// <summary>
        /// Cached name for the 'set_bus_solo' method.
        /// </summary>
        public static readonly StringName SetBusSolo = "set_bus_solo";
        /// <summary>
        /// Cached name for the 'is_bus_solo' method.
        /// </summary>
        public static readonly StringName IsBusSolo = "is_bus_solo";
        /// <summary>
        /// Cached name for the 'set_bus_mute' method.
        /// </summary>
        public static readonly StringName SetBusMute = "set_bus_mute";
        /// <summary>
        /// Cached name for the 'is_bus_mute' method.
        /// </summary>
        public static readonly StringName IsBusMute = "is_bus_mute";
        /// <summary>
        /// Cached name for the 'set_bus_bypass_effects' method.
        /// </summary>
        public static readonly StringName SetBusBypassEffects = "set_bus_bypass_effects";
        /// <summary>
        /// Cached name for the 'is_bus_bypassing_effects' method.
        /// </summary>
        public static readonly StringName IsBusBypassingEffects = "is_bus_bypassing_effects";
        /// <summary>
        /// Cached name for the 'add_bus_effect' method.
        /// </summary>
        public static readonly StringName AddBusEffect = "add_bus_effect";
        /// <summary>
        /// Cached name for the 'remove_bus_effect' method.
        /// </summary>
        public static readonly StringName RemoveBusEffect = "remove_bus_effect";
        /// <summary>
        /// Cached name for the 'get_bus_effect_count' method.
        /// </summary>
        public static readonly StringName GetBusEffectCount = "get_bus_effect_count";
        /// <summary>
        /// Cached name for the 'get_bus_effect' method.
        /// </summary>
        public static readonly StringName GetBusEffect = "get_bus_effect";
        /// <summary>
        /// Cached name for the 'get_bus_effect_instance' method.
        /// </summary>
        public static readonly StringName GetBusEffectInstance = "get_bus_effect_instance";
        /// <summary>
        /// Cached name for the 'swap_bus_effects' method.
        /// </summary>
        public static readonly StringName SwapBusEffects = "swap_bus_effects";
        /// <summary>
        /// Cached name for the 'set_bus_effect_enabled' method.
        /// </summary>
        public static readonly StringName SetBusEffectEnabled = "set_bus_effect_enabled";
        /// <summary>
        /// Cached name for the 'is_bus_effect_enabled' method.
        /// </summary>
        public static readonly StringName IsBusEffectEnabled = "is_bus_effect_enabled";
        /// <summary>
        /// Cached name for the 'get_bus_peak_volume_left_db' method.
        /// </summary>
        public static readonly StringName GetBusPeakVolumeLeftDb = "get_bus_peak_volume_left_db";
        /// <summary>
        /// Cached name for the 'get_bus_peak_volume_right_db' method.
        /// </summary>
        public static readonly StringName GetBusPeakVolumeRightDb = "get_bus_peak_volume_right_db";
        /// <summary>
        /// Cached name for the 'set_playback_speed_scale' method.
        /// </summary>
        public static readonly StringName SetPlaybackSpeedScale = "set_playback_speed_scale";
        /// <summary>
        /// Cached name for the 'get_playback_speed_scale' method.
        /// </summary>
        public static readonly StringName GetPlaybackSpeedScale = "get_playback_speed_scale";
        /// <summary>
        /// Cached name for the 'lock' method.
        /// </summary>
        public static readonly StringName Lock = "lock";
        /// <summary>
        /// Cached name for the 'unlock' method.
        /// </summary>
        public static readonly StringName Unlock = "unlock";
        /// <summary>
        /// Cached name for the 'get_speaker_mode' method.
        /// </summary>
        public static readonly StringName GetSpeakerMode = "get_speaker_mode";
        /// <summary>
        /// Cached name for the 'get_mix_rate' method.
        /// </summary>
        public static readonly StringName GetMixRate = "get_mix_rate";
        /// <summary>
        /// Cached name for the 'get_input_mix_rate' method.
        /// </summary>
        public static readonly StringName GetInputMixRate = "get_input_mix_rate";
        /// <summary>
        /// Cached name for the 'get_driver_name' method.
        /// </summary>
        public static readonly StringName GetDriverName = "get_driver_name";
        /// <summary>
        /// Cached name for the 'get_output_device_list' method.
        /// </summary>
        public static readonly StringName GetOutputDeviceList = "get_output_device_list";
        /// <summary>
        /// Cached name for the 'get_output_device' method.
        /// </summary>
        public static readonly StringName GetOutputDevice = "get_output_device";
        /// <summary>
        /// Cached name for the 'set_output_device' method.
        /// </summary>
        public static readonly StringName SetOutputDevice = "set_output_device";
        /// <summary>
        /// Cached name for the 'get_time_to_next_mix' method.
        /// </summary>
        public static readonly StringName GetTimeToNextMix = "get_time_to_next_mix";
        /// <summary>
        /// Cached name for the 'get_time_since_last_mix' method.
        /// </summary>
        public static readonly StringName GetTimeSinceLastMix = "get_time_since_last_mix";
        /// <summary>
        /// Cached name for the 'get_output_latency' method.
        /// </summary>
        public static readonly StringName GetOutputLatency = "get_output_latency";
        /// <summary>
        /// Cached name for the 'get_input_device_list' method.
        /// </summary>
        public static readonly StringName GetInputDeviceList = "get_input_device_list";
        /// <summary>
        /// Cached name for the 'get_input_device' method.
        /// </summary>
        public static readonly StringName GetInputDevice = "get_input_device";
        /// <summary>
        /// Cached name for the 'set_input_device' method.
        /// </summary>
        public static readonly StringName SetInputDevice = "set_input_device";
        /// <summary>
        /// Cached name for the 'set_input_device_active' method.
        /// </summary>
        public static readonly StringName SetInputDeviceActive = "set_input_device_active";
        /// <summary>
        /// Cached name for the 'get_input_frames_available' method.
        /// </summary>
        public static readonly StringName GetInputFramesAvailable = "get_input_frames_available";
        /// <summary>
        /// Cached name for the 'get_input_buffer_length_frames' method.
        /// </summary>
        public static readonly StringName GetInputBufferLengthFrames = "get_input_buffer_length_frames";
        /// <summary>
        /// Cached name for the 'get_input_frames' method.
        /// </summary>
        public static readonly StringName GetInputFrames = "get_input_frames";
        /// <summary>
        /// Cached name for the 'set_bus_layout' method.
        /// </summary>
        public static readonly StringName SetBusLayout = "set_bus_layout";
        /// <summary>
        /// Cached name for the 'generate_bus_layout' method.
        /// </summary>
        public static readonly StringName GenerateBusLayout = "generate_bus_layout";
        /// <summary>
        /// Cached name for the 'set_enable_tagging_used_audio_streams' method.
        /// </summary>
        public static readonly StringName SetEnableTaggingUsedAudioStreams = "set_enable_tagging_used_audio_streams";
        /// <summary>
        /// Cached name for the 'is_stream_registered_as_sample' method.
        /// </summary>
        public static readonly StringName IsStreamRegisteredAsSample = "is_stream_registered_as_sample";
        /// <summary>
        /// Cached name for the 'register_stream_as_sample' method.
        /// </summary>
        public static readonly StringName RegisterStreamAsSample = "register_stream_as_sample";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
        /// <summary>
        /// Cached name for the 'bus_layout_changed' signal.
        /// </summary>
        public static readonly StringName BusLayoutChanged = "bus_layout_changed";
        /// <summary>
        /// Cached name for the 'bus_renamed' signal.
        /// </summary>
        public static readonly StringName BusRenamed = "bus_renamed";
    }
}
