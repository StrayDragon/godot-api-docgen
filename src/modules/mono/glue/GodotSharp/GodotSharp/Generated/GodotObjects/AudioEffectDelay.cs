namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Plays input signal back after a period of time. The delayed signal may be played back multiple times to create the sound of a repeating, decaying echo. Delay effects range from a subtle echo effect to a pronounced blending of previous sounds with new sounds.</para>
/// </summary>
public partial class AudioEffectDelay : AudioEffect
{
    /// <summary>
    /// <para>Output percent of original sound. At 0, only delayed sounds are output. Value can range from 0 to 1.</para>
    /// </summary>
    public float Dry
    {
        get
        {
            return GetDry();
        }
        set
        {
            SetDry(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the first tap will be enabled.</para>
    /// </summary>
    public bool Tap1Active
    {
        get
        {
            return IsTap1Active();
        }
        set
        {
            SetTap1Active(value);
        }
    }

    /// <summary>
    /// <para>First tap delay time in milliseconds.</para>
    /// </summary>
    public float Tap1DelayMs
    {
        get
        {
            return GetTap1DelayMs();
        }
        set
        {
            SetTap1DelayMs(value);
        }
    }

    /// <summary>
    /// <para>Sound level for the first tap.</para>
    /// </summary>
    public float Tap1LevelDb
    {
        get
        {
            return GetTap1LevelDb();
        }
        set
        {
            SetTap1LevelDb(value);
        }
    }

    /// <summary>
    /// <para>Pan position for the first tap. Value can range from -1 (fully left) to 1 (fully right).</para>
    /// </summary>
    public float Tap1Pan
    {
        get
        {
            return GetTap1Pan();
        }
        set
        {
            SetTap1Pan(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the second tap will be enabled.</para>
    /// </summary>
    public bool Tap2Active
    {
        get
        {
            return IsTap2Active();
        }
        set
        {
            SetTap2Active(value);
        }
    }

    /// <summary>
    /// <para>Second tap delay time in milliseconds.</para>
    /// </summary>
    public float Tap2DelayMs
    {
        get
        {
            return GetTap2DelayMs();
        }
        set
        {
            SetTap2DelayMs(value);
        }
    }

    /// <summary>
    /// <para>Sound level for the second tap.</para>
    /// </summary>
    public float Tap2LevelDb
    {
        get
        {
            return GetTap2LevelDb();
        }
        set
        {
            SetTap2LevelDb(value);
        }
    }

    /// <summary>
    /// <para>Pan position for the second tap. Value can range from -1 (fully left) to 1 (fully right).</para>
    /// </summary>
    public float Tap2Pan
    {
        get
        {
            return GetTap2Pan();
        }
        set
        {
            SetTap2Pan(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, feedback is enabled.</para>
    /// </summary>
    public bool FeedbackActive
    {
        get
        {
            return IsFeedbackActive();
        }
        set
        {
            SetFeedbackActive(value);
        }
    }

    /// <summary>
    /// <para>Feedback delay time in milliseconds.</para>
    /// </summary>
    public float FeedbackDelayMs
    {
        get
        {
            return GetFeedbackDelayMs();
        }
        set
        {
            SetFeedbackDelayMs(value);
        }
    }

    /// <summary>
    /// <para>Sound level for feedback.</para>
    /// </summary>
    public float FeedbackLevelDb
    {
        get
        {
            return GetFeedbackLevelDb();
        }
        set
        {
            SetFeedbackLevelDb(value);
        }
    }

    /// <summary>
    /// <para>Low-pass filter for feedback, in Hz. Frequencies below this value are filtered out of the source signal.</para>
    /// </summary>
    public float FeedbackLowpass
    {
        get
        {
            return GetFeedbackLowpass();
        }
        set
        {
            SetFeedbackLowpass(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioEffectDelay);

    private static readonly StringName NativeName = "AudioEffectDelay";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectDelay() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectDelay(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectDelay(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDry, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDry(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDry, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDry()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTap1Active, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTap1Active(bool amount)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), amount.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTap1Active, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsTap1Active()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTap1DelayMs, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTap1DelayMs(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTap1DelayMs, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTap1DelayMs()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTap1LevelDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTap1LevelDb(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTap1LevelDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTap1LevelDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTap1Pan, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTap1Pan(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTap1Pan, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTap1Pan()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTap2Active, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTap2Active(bool amount)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), amount.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTap2Active, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsTap2Active()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTap2DelayMs, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTap2DelayMs(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTap2DelayMs, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTap2DelayMs()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTap2LevelDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTap2LevelDb(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTap2LevelDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTap2LevelDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTap2Pan, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTap2Pan(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTap2Pan, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTap2Pan()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFeedbackActive, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFeedbackActive(bool amount)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), amount.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFeedbackActive, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFeedbackActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFeedbackDelayMs, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFeedbackDelayMs(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFeedbackDelayMs, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFeedbackDelayMs()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFeedbackLevelDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFeedbackLevelDb(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFeedbackLevelDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFeedbackLevelDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFeedbackLowpass, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFeedbackLowpass(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFeedbackLowpass, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFeedbackLowpass()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
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
        /// Cached name for the 'dry' property.
        /// </summary>
        public static readonly StringName Dry = "dry";
        /// <summary>
        /// Cached name for the 'tap1_active' property.
        /// </summary>
        public static readonly StringName Tap1Active = "tap1_active";
        /// <summary>
        /// Cached name for the 'tap1_delay_ms' property.
        /// </summary>
        public static readonly StringName Tap1DelayMs = "tap1_delay_ms";
        /// <summary>
        /// Cached name for the 'tap1_level_db' property.
        /// </summary>
        public static readonly StringName Tap1LevelDb = "tap1_level_db";
        /// <summary>
        /// Cached name for the 'tap1_pan' property.
        /// </summary>
        public static readonly StringName Tap1Pan = "tap1_pan";
        /// <summary>
        /// Cached name for the 'tap2_active' property.
        /// </summary>
        public static readonly StringName Tap2Active = "tap2_active";
        /// <summary>
        /// Cached name for the 'tap2_delay_ms' property.
        /// </summary>
        public static readonly StringName Tap2DelayMs = "tap2_delay_ms";
        /// <summary>
        /// Cached name for the 'tap2_level_db' property.
        /// </summary>
        public static readonly StringName Tap2LevelDb = "tap2_level_db";
        /// <summary>
        /// Cached name for the 'tap2_pan' property.
        /// </summary>
        public static readonly StringName Tap2Pan = "tap2_pan";
        /// <summary>
        /// Cached name for the 'feedback_active' property.
        /// </summary>
        public static readonly StringName FeedbackActive = "feedback_active";
        /// <summary>
        /// Cached name for the 'feedback_delay_ms' property.
        /// </summary>
        public static readonly StringName FeedbackDelayMs = "feedback_delay_ms";
        /// <summary>
        /// Cached name for the 'feedback_level_db' property.
        /// </summary>
        public static readonly StringName FeedbackLevelDb = "feedback_level_db";
        /// <summary>
        /// Cached name for the 'feedback_lowpass' property.
        /// </summary>
        public static readonly StringName FeedbackLowpass = "feedback_lowpass";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffect.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_dry' method.
        /// </summary>
        public static readonly StringName SetDry = "set_dry";
        /// <summary>
        /// Cached name for the 'get_dry' method.
        /// </summary>
        public static readonly StringName GetDry = "get_dry";
        /// <summary>
        /// Cached name for the 'set_tap1_active' method.
        /// </summary>
        public static readonly StringName SetTap1Active = "set_tap1_active";
        /// <summary>
        /// Cached name for the 'is_tap1_active' method.
        /// </summary>
        public static readonly StringName IsTap1Active = "is_tap1_active";
        /// <summary>
        /// Cached name for the 'set_tap1_delay_ms' method.
        /// </summary>
        public static readonly StringName SetTap1DelayMs = "set_tap1_delay_ms";
        /// <summary>
        /// Cached name for the 'get_tap1_delay_ms' method.
        /// </summary>
        public static readonly StringName GetTap1DelayMs = "get_tap1_delay_ms";
        /// <summary>
        /// Cached name for the 'set_tap1_level_db' method.
        /// </summary>
        public static readonly StringName SetTap1LevelDb = "set_tap1_level_db";
        /// <summary>
        /// Cached name for the 'get_tap1_level_db' method.
        /// </summary>
        public static readonly StringName GetTap1LevelDb = "get_tap1_level_db";
        /// <summary>
        /// Cached name for the 'set_tap1_pan' method.
        /// </summary>
        public static readonly StringName SetTap1Pan = "set_tap1_pan";
        /// <summary>
        /// Cached name for the 'get_tap1_pan' method.
        /// </summary>
        public static readonly StringName GetTap1Pan = "get_tap1_pan";
        /// <summary>
        /// Cached name for the 'set_tap2_active' method.
        /// </summary>
        public static readonly StringName SetTap2Active = "set_tap2_active";
        /// <summary>
        /// Cached name for the 'is_tap2_active' method.
        /// </summary>
        public static readonly StringName IsTap2Active = "is_tap2_active";
        /// <summary>
        /// Cached name for the 'set_tap2_delay_ms' method.
        /// </summary>
        public static readonly StringName SetTap2DelayMs = "set_tap2_delay_ms";
        /// <summary>
        /// Cached name for the 'get_tap2_delay_ms' method.
        /// </summary>
        public static readonly StringName GetTap2DelayMs = "get_tap2_delay_ms";
        /// <summary>
        /// Cached name for the 'set_tap2_level_db' method.
        /// </summary>
        public static readonly StringName SetTap2LevelDb = "set_tap2_level_db";
        /// <summary>
        /// Cached name for the 'get_tap2_level_db' method.
        /// </summary>
        public static readonly StringName GetTap2LevelDb = "get_tap2_level_db";
        /// <summary>
        /// Cached name for the 'set_tap2_pan' method.
        /// </summary>
        public static readonly StringName SetTap2Pan = "set_tap2_pan";
        /// <summary>
        /// Cached name for the 'get_tap2_pan' method.
        /// </summary>
        public static readonly StringName GetTap2Pan = "get_tap2_pan";
        /// <summary>
        /// Cached name for the 'set_feedback_active' method.
        /// </summary>
        public static readonly StringName SetFeedbackActive = "set_feedback_active";
        /// <summary>
        /// Cached name for the 'is_feedback_active' method.
        /// </summary>
        public static readonly StringName IsFeedbackActive = "is_feedback_active";
        /// <summary>
        /// Cached name for the 'set_feedback_delay_ms' method.
        /// </summary>
        public static readonly StringName SetFeedbackDelayMs = "set_feedback_delay_ms";
        /// <summary>
        /// Cached name for the 'get_feedback_delay_ms' method.
        /// </summary>
        public static readonly StringName GetFeedbackDelayMs = "get_feedback_delay_ms";
        /// <summary>
        /// Cached name for the 'set_feedback_level_db' method.
        /// </summary>
        public static readonly StringName SetFeedbackLevelDb = "set_feedback_level_db";
        /// <summary>
        /// Cached name for the 'get_feedback_level_db' method.
        /// </summary>
        public static readonly StringName GetFeedbackLevelDb = "get_feedback_level_db";
        /// <summary>
        /// Cached name for the 'set_feedback_lowpass' method.
        /// </summary>
        public static readonly StringName SetFeedbackLowpass = "set_feedback_lowpass";
        /// <summary>
        /// Cached name for the 'get_feedback_lowpass' method.
        /// </summary>
        public static readonly StringName GetFeedbackLowpass = "get_feedback_lowpass";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffect.SignalName
    {
    }
}
