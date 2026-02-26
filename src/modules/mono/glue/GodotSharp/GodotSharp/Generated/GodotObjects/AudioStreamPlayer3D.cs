namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Plays audio with positional sound effects, based on the relative position of the audio listener. Positional effects include distance attenuation, directionality, and the Doppler effect. For greater realism, a low-pass filter is applied to distant sounds. This can be disabled by setting <see cref="Godot.AudioStreamPlayer3D.AttenuationFilterCutoffHz"/> to <c>20500</c>.</para>
/// <para>By default, audio is heard from the camera position. This can be changed by adding an <see cref="Godot.AudioListener3D"/> node to the scene and enabling it by calling <see cref="Godot.AudioListener3D.MakeCurrent()"/> on it.</para>
/// <para>See also <see cref="Godot.AudioStreamPlayer"/> to play a sound non-positionally.</para>
/// <para><b>Note:</b> Hiding an <see cref="Godot.AudioStreamPlayer3D"/> node does not disable its audio output. To temporarily disable an <see cref="Godot.AudioStreamPlayer3D"/>'s audio output, set <see cref="Godot.AudioStreamPlayer3D.VolumeDb"/> to a very low value like <c>-100</c> (which isn't audible to human hearing).</para>
/// </summary>
public partial class AudioStreamPlayer3D : Node3D
{
    public enum AttenuationModelEnum : long
    {
        /// <summary>
        /// <para>Attenuation of loudness according to linear distance.</para>
        /// </summary>
        InverseDistance = 0,
        /// <summary>
        /// <para>Attenuation of loudness according to squared distance.</para>
        /// </summary>
        InverseSquareDistance = 1,
        /// <summary>
        /// <para>Attenuation of loudness according to logarithmic distance.</para>
        /// </summary>
        Logarithmic = 2,
        /// <summary>
        /// <para>No attenuation of loudness according to distance. The sound will still be heard positionally, unlike an <see cref="Godot.AudioStreamPlayer"/>. <see cref="Godot.AudioStreamPlayer3D.AttenuationModelEnum.Disabled"/> can be combined with a <see cref="Godot.AudioStreamPlayer3D.MaxDistance"/> value greater than <c>0.0</c> to achieve linear attenuation clamped to a sphere of a defined size.</para>
        /// </summary>
        Disabled = 3
    }

    public enum DopplerTrackingEnum : long
    {
        /// <summary>
        /// <para>Disables doppler tracking.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Executes doppler tracking during process frames (see <see cref="Godot.Node.NotificationInternalProcess"/>).</para>
        /// </summary>
        IdleStep = 1,
        /// <summary>
        /// <para>Executes doppler tracking during physics frames (see <see cref="Godot.Node.NotificationInternalPhysicsProcess"/>).</para>
        /// </summary>
        PhysicsStep = 2
    }

    /// <summary>
    /// <para>The <see cref="Godot.AudioStream"/> resource to be played.</para>
    /// </summary>
    public AudioStream Stream
    {
        get
        {
            return GetStream();
        }
        set
        {
            SetStream(value);
        }
    }

    /// <summary>
    /// <para>Decides if audio should get quieter with distance linearly, quadratically, logarithmically, or not be affected by distance, effectively disabling attenuation.</para>
    /// </summary>
    public AudioStreamPlayer3D.AttenuationModelEnum AttenuationModel
    {
        get
        {
            return GetAttenuationModel();
        }
        set
        {
            SetAttenuationModel(value);
        }
    }

    /// <summary>
    /// <para>The base sound level before attenuation, in decibels.</para>
    /// </summary>
    public float VolumeDb
    {
        get
        {
            return GetVolumeDb();
        }
        set
        {
            SetVolumeDb(value);
        }
    }

    /// <summary>
    /// <para>The base sound level before attenuation, as a linear value.</para>
    /// <para><b>Note:</b> This member modifies <see cref="Godot.AudioStreamPlayer3D.VolumeDb"/> for convenience. The returned value is equivalent to the result of <c>@GlobalScope.db_to_linear</c> on <see cref="Godot.AudioStreamPlayer3D.VolumeDb"/>. Setting this member is equivalent to setting <see cref="Godot.AudioStreamPlayer3D.VolumeDb"/> to the result of <c>@GlobalScope.linear_to_db</c> on a value.</para>
    /// </summary>
    public float VolumeLinear
    {
        get
        {
            return GetVolumeLinear();
        }
        set
        {
            SetVolumeLinear(value);
        }
    }

    /// <summary>
    /// <para>The factor for the attenuation effect. Higher values make the sound audible over a larger distance.</para>
    /// </summary>
    public float UnitSize
    {
        get
        {
            return GetUnitSize();
        }
        set
        {
            SetUnitSize(value);
        }
    }

    /// <summary>
    /// <para>Sets the absolute maximum of the sound level, in decibels.</para>
    /// </summary>
    public float MaxDb
    {
        get
        {
            return GetMaxDb();
        }
        set
        {
            SetMaxDb(value);
        }
    }

    /// <summary>
    /// <para>The pitch and the tempo of the audio, as a multiplier of the audio sample's sample rate.</para>
    /// </summary>
    public float PitchScale
    {
        get
        {
            return GetPitchScale();
        }
        set
        {
            SetPitchScale(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, audio is playing or is queued to be played (see <see cref="Godot.AudioStreamPlayer3D.Play(float)"/>).</para>
    /// </summary>
    public bool Playing
    {
        get
        {
            return IsPlaying();
        }
        set
        {
            SetPlaying(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, audio plays when the AudioStreamPlayer3D node is added to scene tree.</para>
    /// </summary>
    public bool Autoplay
    {
        get
        {
            return IsAutoplayEnabled();
        }
        set
        {
            SetAutoplay(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the playback is paused. You can resume it by setting <see cref="Godot.AudioStreamPlayer3D.StreamPaused"/> to <see langword="false"/>.</para>
    /// </summary>
    public bool StreamPaused
    {
        get
        {
            return GetStreamPaused();
        }
        set
        {
            SetStreamPaused(value);
        }
    }

    /// <summary>
    /// <para>The distance past which the sound can no longer be heard at all. Only has an effect if set to a value greater than <c>0.0</c>. <see cref="Godot.AudioStreamPlayer3D.MaxDistance"/> works in tandem with <see cref="Godot.AudioStreamPlayer3D.UnitSize"/>. However, unlike <see cref="Godot.AudioStreamPlayer3D.UnitSize"/> whose behavior depends on the <see cref="Godot.AudioStreamPlayer3D.AttenuationModel"/>, <see cref="Godot.AudioStreamPlayer3D.MaxDistance"/> always works in a linear fashion. This can be used to prevent the <see cref="Godot.AudioStreamPlayer3D"/> from requiring audio mixing when the listener is far away, which saves CPU resources.</para>
    /// </summary>
    public float MaxDistance
    {
        get
        {
            return GetMaxDistance();
        }
        set
        {
            SetMaxDistance(value);
        }
    }

    /// <summary>
    /// <para>The maximum number of sounds this node can play at the same time. Playing additional sounds after this value is reached will cut off the oldest sounds.</para>
    /// </summary>
    public int MaxPolyphony
    {
        get
        {
            return GetMaxPolyphony();
        }
        set
        {
            SetMaxPolyphony(value);
        }
    }

    /// <summary>
    /// <para>Scales the panning strength for this node by multiplying the base <c>ProjectSettings.audio/general/3d_panning_strength</c> by this factor. If the product is <c>0.0</c> then stereo panning is disabled and the volume is the same for all channels. If the product is <c>1.0</c> then one of the channels will be muted when the sound is located exactly to the left (or right) of the listener.</para>
    /// <para>Two speaker stereo arrangements implement the <a href="https://webaudio.github.io/web-audio-api/#stereopanner-algorithm">WebAudio standard for StereoPannerNode Panning</a> where the volume is cosine of half the azimuth angle to the ear.</para>
    /// <para>For other speaker arrangements such as the 5.1 and 7.1 the SPCAP (Speaker-Placement Correction Amplitude) algorithm is implemented.</para>
    /// </summary>
    public float PanningStrength
    {
        get
        {
            return GetPanningStrength();
        }
        set
        {
            SetPanningStrength(value);
        }
    }

    /// <summary>
    /// <para>The bus on which this audio is playing.</para>
    /// <para><b>Note:</b> When setting this property, keep in mind that no validation is performed to see if the given name matches an existing bus. This is because audio bus layouts might be loaded after this property is set. If this given name can't be resolved at runtime, it will fall back to <c>"Master"</c>.</para>
    /// </summary>
    public StringName Bus
    {
        get
        {
            return GetBus();
        }
        set
        {
            SetBus(value);
        }
    }

    /// <summary>
    /// <para>Determines which <see cref="Godot.Area3D"/> layers affect the sound for reverb and audio bus effects. Areas can be used to redirect <see cref="Godot.AudioStream"/>s so that they play in a certain audio bus. An example of how you might use this is making a "water" area so that sounds played in the water are redirected through an audio bus to make them sound like they are being played underwater.</para>
    /// </summary>
    public uint AreaMask
    {
        get
        {
            return GetAreaMask();
        }
        set
        {
            SetAreaMask(value);
        }
    }

    /// <summary>
    /// <para>The playback type of the stream player. If set other than to the default value, it will force that playback type.</para>
    /// </summary>
    public AudioServer.PlaybackType PlaybackType
    {
        get
        {
            return GetPlaybackType();
        }
        set
        {
            SetPlaybackType(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the audio should be attenuated according to the direction of the sound.</para>
    /// </summary>
    public bool EmissionAngleEnabled
    {
        get
        {
            return IsEmissionAngleEnabled();
        }
        set
        {
            SetEmissionAngleEnabled(value);
        }
    }

    /// <summary>
    /// <para>The angle in which the audio reaches a listener unattenuated.</para>
    /// </summary>
    public float EmissionAngleDegrees
    {
        get
        {
            return GetEmissionAngle();
        }
        set
        {
            SetEmissionAngle(value);
        }
    }

    /// <summary>
    /// <para>Attenuation factor used if listener is outside of <see cref="Godot.AudioStreamPlayer3D.EmissionAngleDegrees"/> and <see cref="Godot.AudioStreamPlayer3D.EmissionAngleEnabled"/> is set, in decibels.</para>
    /// </summary>
    public float EmissionAngleFilterAttenuationDb
    {
        get
        {
            return GetEmissionAngleFilterAttenuationDb();
        }
        set
        {
            SetEmissionAngleFilterAttenuationDb(value);
        }
    }

    /// <summary>
    /// <para>The cutoff frequency of the attenuation low-pass filter, in Hz. A sound above this frequency is attenuated more than a sound below this frequency. To disable this effect, set this to <c>20500</c> as this frequency is above the human hearing limit.</para>
    /// </summary>
    public float AttenuationFilterCutoffHz
    {
        get
        {
            return GetAttenuationFilterCutoffHz();
        }
        set
        {
            SetAttenuationFilterCutoffHz(value);
        }
    }

    /// <summary>
    /// <para>Amount how much the filter affects the loudness, in decibels.</para>
    /// </summary>
    public float AttenuationFilterDb
    {
        get
        {
            return GetAttenuationFilterDb();
        }
        set
        {
            SetAttenuationFilterDb(value);
        }
    }

    /// <summary>
    /// <para>Decides in which step the Doppler effect should be calculated.</para>
    /// <para><b>Note:</b> If <see cref="Godot.AudioStreamPlayer3D.DopplerTracking"/> is not <see cref="Godot.AudioStreamPlayer3D.DopplerTrackingEnum.Disabled"/> but the current <see cref="Godot.Camera3D"/>/<see cref="Godot.AudioListener3D"/> has doppler tracking disabled, the Doppler effect will be heard but will not take the movement of the current listener into account. If accurate Doppler effect is desired, doppler tracking should be enabled on both the <see cref="Godot.AudioStreamPlayer3D"/> and the current <see cref="Godot.Camera3D"/>/<see cref="Godot.AudioListener3D"/>.</para>
    /// </summary>
    public AudioStreamPlayer3D.DopplerTrackingEnum DopplerTracking
    {
        get
        {
            return GetDopplerTracking();
        }
        set
        {
            SetDopplerTracking(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioStreamPlayer3D);

    private static readonly StringName NativeName = "AudioStreamPlayer3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamPlayer3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal AudioStreamPlayer3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AudioStreamPlayer3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStream, 2210767741ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStream(AudioStream stream)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(stream));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStream, 160907539ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioStream GetStream()
    {
        return (AudioStream)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumeDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumeDb(float volumeDb)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), volumeDb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumeDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumeDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumeLinear, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumeLinear(float volumeLinear)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), volumeLinear);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumeLinear, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumeLinear()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUnitSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUnitSize(float unitSize)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), unitSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUnitSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetUnitSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxDb(float maxDb)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), maxDb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMaxDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPitchScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPitchScale(float pitchScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), pitchScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPitchScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPitchScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Play, 1958160172ul);

    /// <summary>
    /// <para>Queues the audio to play on the next physics frame, from the given position <paramref name="fromPosition"/>, in seconds.</para>
    /// </summary>
    public void Play(float fromPosition = 0.0f)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), fromPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Seek, 373806689ul);

    /// <summary>
    /// <para>Sets the position from which audio will be played, in seconds.</para>
    /// </summary>
    public void Seek(float toPosition)
    {
        NativeCalls.godot_icall_1_67(MethodBind13, GodotObject.GetPtr(this), toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 3218959716ul);

    /// <summary>
    /// <para>Stops the audio.</para>
    /// </summary>
    public void Stop()
    {
        NativeCalls.godot_icall_0_3(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPlaying, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPlaying()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaybackPosition, 191475506ul);

    /// <summary>
    /// <para>Returns the position in the <see cref="Godot.AudioStream"/>.</para>
    /// </summary>
    public float GetPlaybackPosition()
    {
        return NativeCalls.godot_icall_0_68(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBus, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBus(StringName bus)
    {
        NativeCalls.godot_icall_1_64(MethodBind17, GodotObject.GetPtr(this), (godot_string_name)(bus?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBus, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetBus()
    {
        return NativeCalls.godot_icall_0_65(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoplay, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoplay(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoplayEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoplayEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaying, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlaying(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind21, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxDistance(float meters)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), meters);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMaxDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAreaMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAreaMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind24, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAreaMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetAreaMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionAngle(float degrees)
    {
        NativeCalls.godot_icall_1_67(MethodBind26, GodotObject.GetPtr(this), degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionAngleEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionAngleEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind28, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmissionAngleEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEmissionAngleEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind29, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmissionAngleFilterAttenuationDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmissionAngleFilterAttenuationDb(float db)
    {
        NativeCalls.godot_icall_1_67(MethodBind30, GodotObject.GetPtr(this), db);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmissionAngleFilterAttenuationDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEmissionAngleFilterAttenuationDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAttenuationFilterCutoffHz, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAttenuationFilterCutoffHz(float degrees)
    {
        NativeCalls.godot_icall_1_67(MethodBind32, GodotObject.GetPtr(this), degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttenuationFilterCutoffHz, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAttenuationFilterCutoffHz()
    {
        return NativeCalls.godot_icall_0_68(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAttenuationFilterDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAttenuationFilterDb(float db)
    {
        NativeCalls.godot_icall_1_67(MethodBind34, GodotObject.GetPtr(this), db);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttenuationFilterDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAttenuationFilterDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAttenuationModel, 2988086229ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAttenuationModel(AudioStreamPlayer3D.AttenuationModelEnum model)
    {
        NativeCalls.godot_icall_1_38(MethodBind36, GodotObject.GetPtr(this), (int)model);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttenuationModel, 3035106060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioStreamPlayer3D.AttenuationModelEnum GetAttenuationModel()
    {
        return (AudioStreamPlayer3D.AttenuationModelEnum)NativeCalls.godot_icall_0_39(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDopplerTracking, 3968161450ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDopplerTracking(AudioStreamPlayer3D.DopplerTrackingEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind38, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDopplerTracking, 1702418664ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioStreamPlayer3D.DopplerTrackingEnum GetDopplerTracking()
    {
        return (AudioStreamPlayer3D.DopplerTrackingEnum)NativeCalls.godot_icall_0_39(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStreamPaused, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStreamPaused(bool pause)
    {
        NativeCalls.godot_icall_1_14(MethodBind40, GodotObject.GetPtr(this), pause.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamPaused, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetStreamPaused()
    {
        return NativeCalls.godot_icall_0_15(MethodBind41, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxPolyphony, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxPolyphony(int maxPolyphony)
    {
        NativeCalls.godot_icall_1_38(MethodBind42, GodotObject.GetPtr(this), maxPolyphony);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxPolyphony, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxPolyphony()
    {
        return NativeCalls.godot_icall_0_39(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPanningStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPanningStrength(float panningStrength)
    {
        NativeCalls.godot_icall_1_67(MethodBind44, GodotObject.GetPtr(this), panningStrength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPanningStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPanningStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasStreamPlayback, 2240911060ul);

    /// <summary>
    /// <para>Returns whether the <see cref="Godot.AudioStreamPlayer"/> can return the <see cref="Godot.AudioStreamPlayback"/> object or not.</para>
    /// </summary>
    public bool HasStreamPlayback()
    {
        return NativeCalls.godot_icall_0_15(MethodBind46, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamPlayback, 210135309ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.AudioStreamPlayback"/> object associated with this <see cref="Godot.AudioStreamPlayer3D"/>.</para>
    /// </summary>
    public AudioStreamPlayback GetStreamPlayback()
    {
        return (AudioStreamPlayback)NativeCalls.godot_icall_0_63(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaybackType, 725473817ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlaybackType(AudioServer.PlaybackType playbackType)
    {
        NativeCalls.godot_icall_1_38(MethodBind48, GodotObject.GetPtr(this), (int)playbackType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaybackType, 4011264623ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioServer.PlaybackType GetPlaybackType()
    {
        return (AudioServer.PlaybackType)NativeCalls.godot_icall_0_39(MethodBind49, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the audio stops playing.</para>
    /// </summary>
    public event Action Finished
    {
        add => Connect(SignalName.Finished, Callable.From(value));
        remove => Disconnect(SignalName.Finished, Callable.From(value));
    }

    protected void EmitSignalFinished()
    {
        EmitSignal(SignalName.Finished);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_finished = "Finished";

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
        if (signal == SignalName.Finished)
        {
            if (HasGodotClassSignal(SignalProxyName_finished.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'stream' property.
        /// </summary>
        public static readonly StringName Stream = "stream";
        /// <summary>
        /// Cached name for the 'attenuation_model' property.
        /// </summary>
        public static readonly StringName AttenuationModel = "attenuation_model";
        /// <summary>
        /// Cached name for the 'volume_db' property.
        /// </summary>
        public static readonly StringName VolumeDb = "volume_db";
        /// <summary>
        /// Cached name for the 'volume_linear' property.
        /// </summary>
        public static readonly StringName VolumeLinear = "volume_linear";
        /// <summary>
        /// Cached name for the 'unit_size' property.
        /// </summary>
        public static readonly StringName UnitSize = "unit_size";
        /// <summary>
        /// Cached name for the 'max_db' property.
        /// </summary>
        public static readonly StringName MaxDb = "max_db";
        /// <summary>
        /// Cached name for the 'pitch_scale' property.
        /// </summary>
        public static readonly StringName PitchScale = "pitch_scale";
        /// <summary>
        /// Cached name for the 'playing' property.
        /// </summary>
        public static readonly StringName Playing = "playing";
        /// <summary>
        /// Cached name for the 'autoplay' property.
        /// </summary>
        public static readonly StringName Autoplay = "autoplay";
        /// <summary>
        /// Cached name for the 'stream_paused' property.
        /// </summary>
        public static readonly StringName StreamPaused = "stream_paused";
        /// <summary>
        /// Cached name for the 'max_distance' property.
        /// </summary>
        public static readonly StringName MaxDistance = "max_distance";
        /// <summary>
        /// Cached name for the 'max_polyphony' property.
        /// </summary>
        public static readonly StringName MaxPolyphony = "max_polyphony";
        /// <summary>
        /// Cached name for the 'panning_strength' property.
        /// </summary>
        public static readonly StringName PanningStrength = "panning_strength";
        /// <summary>
        /// Cached name for the 'bus' property.
        /// </summary>
        public static readonly StringName Bus = "bus";
        /// <summary>
        /// Cached name for the 'area_mask' property.
        /// </summary>
        public static readonly StringName AreaMask = "area_mask";
        /// <summary>
        /// Cached name for the 'playback_type' property.
        /// </summary>
        public static readonly StringName PlaybackType = "playback_type";
        /// <summary>
        /// Cached name for the 'emission_angle_enabled' property.
        /// </summary>
        public static readonly StringName EmissionAngleEnabled = "emission_angle_enabled";
        /// <summary>
        /// Cached name for the 'emission_angle_degrees' property.
        /// </summary>
        public static readonly StringName EmissionAngleDegrees = "emission_angle_degrees";
        /// <summary>
        /// Cached name for the 'emission_angle_filter_attenuation_db' property.
        /// </summary>
        public static readonly StringName EmissionAngleFilterAttenuationDb = "emission_angle_filter_attenuation_db";
        /// <summary>
        /// Cached name for the 'attenuation_filter_cutoff_hz' property.
        /// </summary>
        public static readonly StringName AttenuationFilterCutoffHz = "attenuation_filter_cutoff_hz";
        /// <summary>
        /// Cached name for the 'attenuation_filter_db' property.
        /// </summary>
        public static readonly StringName AttenuationFilterDb = "attenuation_filter_db";
        /// <summary>
        /// Cached name for the 'doppler_tracking' property.
        /// </summary>
        public static readonly StringName DopplerTracking = "doppler_tracking";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_stream' method.
        /// </summary>
        public static readonly StringName SetStream = "set_stream";
        /// <summary>
        /// Cached name for the 'get_stream' method.
        /// </summary>
        public static readonly StringName GetStream = "get_stream";
        /// <summary>
        /// Cached name for the 'set_volume_db' method.
        /// </summary>
        public static readonly StringName SetVolumeDb = "set_volume_db";
        /// <summary>
        /// Cached name for the 'get_volume_db' method.
        /// </summary>
        public static readonly StringName GetVolumeDb = "get_volume_db";
        /// <summary>
        /// Cached name for the 'set_volume_linear' method.
        /// </summary>
        public static readonly StringName SetVolumeLinear = "set_volume_linear";
        /// <summary>
        /// Cached name for the 'get_volume_linear' method.
        /// </summary>
        public static readonly StringName GetVolumeLinear = "get_volume_linear";
        /// <summary>
        /// Cached name for the 'set_unit_size' method.
        /// </summary>
        public static readonly StringName SetUnitSize = "set_unit_size";
        /// <summary>
        /// Cached name for the 'get_unit_size' method.
        /// </summary>
        public static readonly StringName GetUnitSize = "get_unit_size";
        /// <summary>
        /// Cached name for the 'set_max_db' method.
        /// </summary>
        public static readonly StringName SetMaxDb = "set_max_db";
        /// <summary>
        /// Cached name for the 'get_max_db' method.
        /// </summary>
        public static readonly StringName GetMaxDb = "get_max_db";
        /// <summary>
        /// Cached name for the 'set_pitch_scale' method.
        /// </summary>
        public static readonly StringName SetPitchScale = "set_pitch_scale";
        /// <summary>
        /// Cached name for the 'get_pitch_scale' method.
        /// </summary>
        public static readonly StringName GetPitchScale = "get_pitch_scale";
        /// <summary>
        /// Cached name for the 'play' method.
        /// </summary>
        public static readonly StringName Play = "play";
        /// <summary>
        /// Cached name for the 'seek' method.
        /// </summary>
        public static readonly StringName Seek = "seek";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'is_playing' method.
        /// </summary>
        public static readonly StringName IsPlaying = "is_playing";
        /// <summary>
        /// Cached name for the 'get_playback_position' method.
        /// </summary>
        public static readonly StringName GetPlaybackPosition = "get_playback_position";
        /// <summary>
        /// Cached name for the 'set_bus' method.
        /// </summary>
        public static readonly StringName SetBus = "set_bus";
        /// <summary>
        /// Cached name for the 'get_bus' method.
        /// </summary>
        public static readonly StringName GetBus = "get_bus";
        /// <summary>
        /// Cached name for the 'set_autoplay' method.
        /// </summary>
        public static readonly StringName SetAutoplay = "set_autoplay";
        /// <summary>
        /// Cached name for the 'is_autoplay_enabled' method.
        /// </summary>
        public static readonly StringName IsAutoplayEnabled = "is_autoplay_enabled";
        /// <summary>
        /// Cached name for the 'set_playing' method.
        /// </summary>
        public static readonly StringName SetPlaying = "set_playing";
        /// <summary>
        /// Cached name for the 'set_max_distance' method.
        /// </summary>
        public static readonly StringName SetMaxDistance = "set_max_distance";
        /// <summary>
        /// Cached name for the 'get_max_distance' method.
        /// </summary>
        public static readonly StringName GetMaxDistance = "get_max_distance";
        /// <summary>
        /// Cached name for the 'set_area_mask' method.
        /// </summary>
        public static readonly StringName SetAreaMask = "set_area_mask";
        /// <summary>
        /// Cached name for the 'get_area_mask' method.
        /// </summary>
        public static readonly StringName GetAreaMask = "get_area_mask";
        /// <summary>
        /// Cached name for the 'set_emission_angle' method.
        /// </summary>
        public static readonly StringName SetEmissionAngle = "set_emission_angle";
        /// <summary>
        /// Cached name for the 'get_emission_angle' method.
        /// </summary>
        public static readonly StringName GetEmissionAngle = "get_emission_angle";
        /// <summary>
        /// Cached name for the 'set_emission_angle_enabled' method.
        /// </summary>
        public static readonly StringName SetEmissionAngleEnabled = "set_emission_angle_enabled";
        /// <summary>
        /// Cached name for the 'is_emission_angle_enabled' method.
        /// </summary>
        public static readonly StringName IsEmissionAngleEnabled = "is_emission_angle_enabled";
        /// <summary>
        /// Cached name for the 'set_emission_angle_filter_attenuation_db' method.
        /// </summary>
        public static readonly StringName SetEmissionAngleFilterAttenuationDb = "set_emission_angle_filter_attenuation_db";
        /// <summary>
        /// Cached name for the 'get_emission_angle_filter_attenuation_db' method.
        /// </summary>
        public static readonly StringName GetEmissionAngleFilterAttenuationDb = "get_emission_angle_filter_attenuation_db";
        /// <summary>
        /// Cached name for the 'set_attenuation_filter_cutoff_hz' method.
        /// </summary>
        public static readonly StringName SetAttenuationFilterCutoffHz = "set_attenuation_filter_cutoff_hz";
        /// <summary>
        /// Cached name for the 'get_attenuation_filter_cutoff_hz' method.
        /// </summary>
        public static readonly StringName GetAttenuationFilterCutoffHz = "get_attenuation_filter_cutoff_hz";
        /// <summary>
        /// Cached name for the 'set_attenuation_filter_db' method.
        /// </summary>
        public static readonly StringName SetAttenuationFilterDb = "set_attenuation_filter_db";
        /// <summary>
        /// Cached name for the 'get_attenuation_filter_db' method.
        /// </summary>
        public static readonly StringName GetAttenuationFilterDb = "get_attenuation_filter_db";
        /// <summary>
        /// Cached name for the 'set_attenuation_model' method.
        /// </summary>
        public static readonly StringName SetAttenuationModel = "set_attenuation_model";
        /// <summary>
        /// Cached name for the 'get_attenuation_model' method.
        /// </summary>
        public static readonly StringName GetAttenuationModel = "get_attenuation_model";
        /// <summary>
        /// Cached name for the 'set_doppler_tracking' method.
        /// </summary>
        public static readonly StringName SetDopplerTracking = "set_doppler_tracking";
        /// <summary>
        /// Cached name for the 'get_doppler_tracking' method.
        /// </summary>
        public static readonly StringName GetDopplerTracking = "get_doppler_tracking";
        /// <summary>
        /// Cached name for the 'set_stream_paused' method.
        /// </summary>
        public static readonly StringName SetStreamPaused = "set_stream_paused";
        /// <summary>
        /// Cached name for the 'get_stream_paused' method.
        /// </summary>
        public static readonly StringName GetStreamPaused = "get_stream_paused";
        /// <summary>
        /// Cached name for the 'set_max_polyphony' method.
        /// </summary>
        public static readonly StringName SetMaxPolyphony = "set_max_polyphony";
        /// <summary>
        /// Cached name for the 'get_max_polyphony' method.
        /// </summary>
        public static readonly StringName GetMaxPolyphony = "get_max_polyphony";
        /// <summary>
        /// Cached name for the 'set_panning_strength' method.
        /// </summary>
        public static readonly StringName SetPanningStrength = "set_panning_strength";
        /// <summary>
        /// Cached name for the 'get_panning_strength' method.
        /// </summary>
        public static readonly StringName GetPanningStrength = "get_panning_strength";
        /// <summary>
        /// Cached name for the 'has_stream_playback' method.
        /// </summary>
        public static readonly StringName HasStreamPlayback = "has_stream_playback";
        /// <summary>
        /// Cached name for the 'get_stream_playback' method.
        /// </summary>
        public static readonly StringName GetStreamPlayback = "get_stream_playback";
        /// <summary>
        /// Cached name for the 'set_playback_type' method.
        /// </summary>
        public static readonly StringName SetPlaybackType = "set_playback_type";
        /// <summary>
        /// Cached name for the 'get_playback_type' method.
        /// </summary>
        public static readonly StringName GetPlaybackType = "get_playback_type";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'finished' signal.
        /// </summary>
        public static readonly StringName Finished = "finished";
    }
}
