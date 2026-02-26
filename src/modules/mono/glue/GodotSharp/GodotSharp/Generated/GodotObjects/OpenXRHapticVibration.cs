namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This haptic feedback resource makes it possible to define a vibration based haptic feedback pulse that can be triggered through actions in the OpenXR action map.</para>
/// </summary>
public partial class OpenXRHapticVibration : OpenXRHapticBase
{
    /// <summary>
    /// <para>The duration of the pulse in nanoseconds. Use <c>-1</c> for a minimum duration pulse for the current XR runtime.</para>
    /// </summary>
    public long Duration
    {
        get
        {
            return GetDuration();
        }
        set
        {
            SetDuration(value);
        }
    }

    /// <summary>
    /// <para>The frequency of the pulse in Hz. <c>0.0</c> will let the XR runtime chose an optimal frequency for the device used.</para>
    /// </summary>
    public float Frequency
    {
        get
        {
            return GetFrequency();
        }
        set
        {
            SetFrequency(value);
        }
    }

    /// <summary>
    /// <para>The amplitude of the pulse between <c>0.0</c> and <c>1.0</c>.</para>
    /// </summary>
    public float Amplitude
    {
        get
        {
            return GetAmplitude();
        }
        set
        {
            SetAmplitude(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRHapticVibration);

    private static readonly StringName NativeName = "OpenXRHapticVibration";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRHapticVibration() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRHapticVibration(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRHapticVibration(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDuration, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDuration(long duration)
    {
        NativeCalls.godot_icall_1_10(MethodBind0, GodotObject.GetPtr(this), duration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDuration, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long GetDuration()
    {
        return NativeCalls.godot_icall_0_4(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrequency, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrequency(float frequency)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), frequency);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrequency, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFrequency()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmplitude, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAmplitude(float amplitude)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), amplitude);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmplitude, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAmplitude()
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
    public new class PropertyName : OpenXRHapticBase.PropertyName
    {
        /// <summary>
        /// Cached name for the 'duration' property.
        /// </summary>
        public static readonly StringName Duration = "duration";
        /// <summary>
        /// Cached name for the 'frequency' property.
        /// </summary>
        public static readonly StringName Frequency = "frequency";
        /// <summary>
        /// Cached name for the 'amplitude' property.
        /// </summary>
        public static readonly StringName Amplitude = "amplitude";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRHapticBase.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_duration' method.
        /// </summary>
        public static readonly StringName SetDuration = "set_duration";
        /// <summary>
        /// Cached name for the 'get_duration' method.
        /// </summary>
        public static readonly StringName GetDuration = "get_duration";
        /// <summary>
        /// Cached name for the 'set_frequency' method.
        /// </summary>
        public static readonly StringName SetFrequency = "set_frequency";
        /// <summary>
        /// Cached name for the 'get_frequency' method.
        /// </summary>
        public static readonly StringName GetFrequency = "get_frequency";
        /// <summary>
        /// Cached name for the 'set_amplitude' method.
        /// </summary>
        public static readonly StringName SetAmplitude = "set_amplitude";
        /// <summary>
        /// Cached name for the 'get_amplitude' method.
        /// </summary>
        public static readonly StringName GetAmplitude = "get_amplitude";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRHapticBase.SignalName
    {
    }
}
