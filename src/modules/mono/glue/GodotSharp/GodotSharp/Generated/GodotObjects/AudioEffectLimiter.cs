namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A limiter is similar to a compressor, but it's less flexible and designed to disallow sound going over a given dB threshold. Adding one in the Master bus is always recommended to reduce the effects of clipping.</para>
/// <para>Soft clipping starts to reduce the peaks a little below the threshold level and progressively increases its effect as the input level increases such that the threshold is never exceeded.</para>
/// </summary>
[Obsolete("Use 'AudioEffectHardLimiter' instead.")]
public partial class AudioEffectLimiter : AudioEffect
{
    /// <summary>
    /// <para>The waveform's maximum allowed value, in decibels. Value can range from -20 to -0.1.</para>
    /// </summary>
    public float CeilingDb
    {
        get
        {
            return GetCeilingDb();
        }
        set
        {
            SetCeilingDb(value);
        }
    }

    /// <summary>
    /// <para>Threshold from which the limiter begins to be active, in decibels. Value can range from -30 to 0.</para>
    /// </summary>
    public float ThresholdDb
    {
        get
        {
            return GetThresholdDb();
        }
        set
        {
            SetThresholdDb(value);
        }
    }

    /// <summary>
    /// <para>Applies a gain to the limited waves, in decibels. Value can range from 0 to 6.</para>
    /// </summary>
    public float SoftClipDb
    {
        get
        {
            return GetSoftClipDb();
        }
        set
        {
            SetSoftClipDb(value);
        }
    }

    public float SoftClipRatio
    {
        get
        {
            return GetSoftClipRatio();
        }
        set
        {
            SetSoftClipRatio(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioEffectLimiter);

    private static readonly StringName NativeName = "AudioEffectLimiter";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectLimiter() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectLimiter(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectLimiter(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCeilingDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCeilingDb(float ceiling)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), ceiling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCeilingDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCeilingDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThresholdDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetThresholdDb(float threshold)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), threshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThresholdDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetThresholdDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSoftClipDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSoftClipDb(float softClip)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), softClip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSoftClipDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSoftClipDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSoftClipRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSoftClipRatio(float softClip)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), softClip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSoftClipRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSoftClipRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
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
        /// Cached name for the 'ceiling_db' property.
        /// </summary>
        public static readonly StringName CeilingDb = "ceiling_db";
        /// <summary>
        /// Cached name for the 'threshold_db' property.
        /// </summary>
        public static readonly StringName ThresholdDb = "threshold_db";
        /// <summary>
        /// Cached name for the 'soft_clip_db' property.
        /// </summary>
        public static readonly StringName SoftClipDb = "soft_clip_db";
        /// <summary>
        /// Cached name for the 'soft_clip_ratio' property.
        /// </summary>
        public static readonly StringName SoftClipRatio = "soft_clip_ratio";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffect.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_ceiling_db' method.
        /// </summary>
        public static readonly StringName SetCeilingDb = "set_ceiling_db";
        /// <summary>
        /// Cached name for the 'get_ceiling_db' method.
        /// </summary>
        public static readonly StringName GetCeilingDb = "get_ceiling_db";
        /// <summary>
        /// Cached name for the 'set_threshold_db' method.
        /// </summary>
        public static readonly StringName SetThresholdDb = "set_threshold_db";
        /// <summary>
        /// Cached name for the 'get_threshold_db' method.
        /// </summary>
        public static readonly StringName GetThresholdDb = "get_threshold_db";
        /// <summary>
        /// Cached name for the 'set_soft_clip_db' method.
        /// </summary>
        public static readonly StringName SetSoftClipDb = "set_soft_clip_db";
        /// <summary>
        /// Cached name for the 'get_soft_clip_db' method.
        /// </summary>
        public static readonly StringName GetSoftClipDb = "get_soft_clip_db";
        /// <summary>
        /// Cached name for the 'set_soft_clip_ratio' method.
        /// </summary>
        public static readonly StringName SetSoftClipRatio = "set_soft_clip_ratio";
        /// <summary>
        /// Cached name for the 'get_soft_clip_ratio' method.
        /// </summary>
        public static readonly StringName GetSoftClipRatio = "get_soft_clip_ratio";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffect.SignalName
    {
    }
}
