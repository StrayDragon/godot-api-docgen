namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An audio effect that can be used to adjust the intensity of stereo panning.</para>
/// </summary>
public partial class AudioEffectStereoEnhance : AudioEffect
{
    /// <summary>
    /// <para>Amplifies the difference between stereo channels, increasing or decreasing existing panning. A value of 0.0 will downmix stereo to mono. Does not affect a mono signal.</para>
    /// </summary>
    public float PanPullout
    {
        get
        {
            return GetPanPullout();
        }
        set
        {
            SetPanPullout(value);
        }
    }

    /// <summary>
    /// <para>Widens sound stage through phase shifting in conjunction with <see cref="Godot.AudioEffectStereoEnhance.Surround"/>. Just delays the right channel if <see cref="Godot.AudioEffectStereoEnhance.Surround"/> is 0.</para>
    /// </summary>
    public float TimePulloutMs
    {
        get
        {
            return GetTimePullout();
        }
        set
        {
            SetTimePullout(value);
        }
    }

    /// <summary>
    /// <para>Widens sound stage through phase shifting in conjunction with <see cref="Godot.AudioEffectStereoEnhance.TimePulloutMs"/>. Just pans sound to the left channel if <see cref="Godot.AudioEffectStereoEnhance.TimePulloutMs"/> is 0.</para>
    /// </summary>
    public float Surround
    {
        get
        {
            return GetSurround();
        }
        set
        {
            SetSurround(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioEffectStereoEnhance);

    private static readonly StringName NativeName = "AudioEffectStereoEnhance";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectStereoEnhance() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectStereoEnhance(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectStereoEnhance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPanPullout, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPanPullout(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPanPullout, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPanPullout()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTimePullout, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTimePullout(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimePullout, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTimePullout()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSurround, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSurround(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurround, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSurround()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'pan_pullout' property.
        /// </summary>
        public static readonly StringName PanPullout = "pan_pullout";
        /// <summary>
        /// Cached name for the 'time_pullout_ms' property.
        /// </summary>
        public static readonly StringName TimePulloutMs = "time_pullout_ms";
        /// <summary>
        /// Cached name for the 'surround' property.
        /// </summary>
        public static readonly StringName Surround = "surround";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffect.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_pan_pullout' method.
        /// </summary>
        public static readonly StringName SetPanPullout = "set_pan_pullout";
        /// <summary>
        /// Cached name for the 'get_pan_pullout' method.
        /// </summary>
        public static readonly StringName GetPanPullout = "get_pan_pullout";
        /// <summary>
        /// Cached name for the 'set_time_pullout' method.
        /// </summary>
        public static readonly StringName SetTimePullout = "set_time_pullout";
        /// <summary>
        /// Cached name for the 'get_time_pullout' method.
        /// </summary>
        public static readonly StringName GetTimePullout = "get_time_pullout";
        /// <summary>
        /// Cached name for the 'set_surround' method.
        /// </summary>
        public static readonly StringName SetSurround = "set_surround";
        /// <summary>
        /// Cached name for the 'get_surround' method.
        /// </summary>
        public static readonly StringName GetSurround = "get_surround";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffect.SignalName
    {
    }
}
