namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Different types are available: clip, tan, lo-fi (bit crushing), overdrive, or waveshape.</para>
/// <para>By distorting the waveform the frequency content changes, which will often make the sound "crunchy" or "abrasive". For games, it can simulate sound coming from some saturated device or speaker very efficiently.</para>
/// </summary>
public partial class AudioEffectDistortion : AudioEffect
{
    public enum ModeEnum : long
    {
        /// <summary>
        /// <para>Digital distortion effect which cuts off peaks at the top and bottom of the waveform.</para>
        /// </summary>
        Clip = 0,
        Atan = 1,
        /// <summary>
        /// <para>Low-resolution digital distortion effect (bit depth reduction). You can use it to emulate the sound of early digital audio devices.</para>
        /// </summary>
        Lofi = 2,
        /// <summary>
        /// <para>Emulates the warm distortion produced by a field effect transistor, which is commonly used in solid-state musical instrument amplifiers. The <see cref="Godot.AudioEffectDistortion.Drive"/> property has no effect in this mode.</para>
        /// </summary>
        Overdrive = 3,
        /// <summary>
        /// <para>Waveshaper distortions are used mainly by electronic musicians to achieve an extra-abrasive sound.</para>
        /// </summary>
        Waveshape = 4
    }

    /// <summary>
    /// <para>Distortion type.</para>
    /// </summary>
    public AudioEffectDistortion.ModeEnum Mode
    {
        get
        {
            return GetMode();
        }
        set
        {
            SetMode(value);
        }
    }

    /// <summary>
    /// <para>Increases or decreases the volume before the effect, in decibels. Value can range from -60 to 60.</para>
    /// </summary>
    public float PreGain
    {
        get
        {
            return GetPreGain();
        }
        set
        {
            SetPreGain(value);
        }
    }

    /// <summary>
    /// <para>High-pass filter, in Hz. Frequencies higher than this value will not be affected by the distortion. Value can range from 1 to 20000.</para>
    /// </summary>
    public float KeepHfHz
    {
        get
        {
            return GetKeepHfHz();
        }
        set
        {
            SetKeepHfHz(value);
        }
    }

    /// <summary>
    /// <para>Distortion power. Value can range from 0 to 1.</para>
    /// </summary>
    public float Drive
    {
        get
        {
            return GetDrive();
        }
        set
        {
            SetDrive(value);
        }
    }

    /// <summary>
    /// <para>Increases or decreases the volume after the effect, in decibels. Value can range from -80 to 24.</para>
    /// </summary>
    public float PostGain
    {
        get
        {
            return GetPostGain();
        }
        set
        {
            SetPostGain(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioEffectDistortion);

    private static readonly StringName NativeName = "AudioEffectDistortion";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectDistortion() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectDistortion(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectDistortion(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMode, 1314744793ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMode(AudioEffectDistortion.ModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMode, 809118343ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioEffectDistortion.ModeEnum GetMode()
    {
        return (AudioEffectDistortion.ModeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPreGain, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPreGain(float preGain)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), preGain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreGain, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPreGain()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKeepHfHz, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetKeepHfHz(float keepHfHz)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), keepHfHz);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetKeepHfHz, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetKeepHfHz()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrive, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrive(float drive)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), drive);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDrive, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDrive()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPostGain, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPostGain(float postGain)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), postGain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPostGain, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPostGain()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
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
        /// Cached name for the 'mode' property.
        /// </summary>
        public static readonly StringName Mode = "mode";
        /// <summary>
        /// Cached name for the 'pre_gain' property.
        /// </summary>
        public static readonly StringName PreGain = "pre_gain";
        /// <summary>
        /// Cached name for the 'keep_hf_hz' property.
        /// </summary>
        public static readonly StringName KeepHfHz = "keep_hf_hz";
        /// <summary>
        /// Cached name for the 'drive' property.
        /// </summary>
        public static readonly StringName Drive = "drive";
        /// <summary>
        /// Cached name for the 'post_gain' property.
        /// </summary>
        public static readonly StringName PostGain = "post_gain";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffect.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_mode' method.
        /// </summary>
        public static readonly StringName SetMode = "set_mode";
        /// <summary>
        /// Cached name for the 'get_mode' method.
        /// </summary>
        public static readonly StringName GetMode = "get_mode";
        /// <summary>
        /// Cached name for the 'set_pre_gain' method.
        /// </summary>
        public static readonly StringName SetPreGain = "set_pre_gain";
        /// <summary>
        /// Cached name for the 'get_pre_gain' method.
        /// </summary>
        public static readonly StringName GetPreGain = "get_pre_gain";
        /// <summary>
        /// Cached name for the 'set_keep_hf_hz' method.
        /// </summary>
        public static readonly StringName SetKeepHfHz = "set_keep_hf_hz";
        /// <summary>
        /// Cached name for the 'get_keep_hf_hz' method.
        /// </summary>
        public static readonly StringName GetKeepHfHz = "get_keep_hf_hz";
        /// <summary>
        /// Cached name for the 'set_drive' method.
        /// </summary>
        public static readonly StringName SetDrive = "set_drive";
        /// <summary>
        /// Cached name for the 'get_drive' method.
        /// </summary>
        public static readonly StringName GetDrive = "get_drive";
        /// <summary>
        /// Cached name for the 'set_post_gain' method.
        /// </summary>
        public static readonly StringName SetPostGain = "set_post_gain";
        /// <summary>
        /// Cached name for the 'get_post_gain' method.
        /// </summary>
        public static readonly StringName GetPostGain = "get_post_gain";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffect.SignalName
    {
    }
}
