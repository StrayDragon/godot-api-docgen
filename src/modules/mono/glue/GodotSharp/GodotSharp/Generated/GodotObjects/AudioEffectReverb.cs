namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Simulates the sound of acoustic environments such as rooms, concert halls, caverns, or an open spaces.</para>
/// </summary>
public partial class AudioEffectReverb : AudioEffect
{
    /// <summary>
    /// <para>Time between the original signal and the early reflections of the reverb signal, in milliseconds.</para>
    /// </summary>
    public float PredelayMsec
    {
        get
        {
            return GetPredelayMsec();
        }
        set
        {
            SetPredelayMsec(value);
        }
    }

    /// <summary>
    /// <para>Output percent of predelay. Value can range from 0 to 1.</para>
    /// </summary>
    public float PredelayFeedback
    {
        get
        {
            return GetPredelayFeedback();
        }
        set
        {
            SetPredelayFeedback(value);
        }
    }

    /// <summary>
    /// <para>Dimensions of simulated room. Bigger means more echoes. Value can range from 0 to 1.</para>
    /// </summary>
    public float RoomSize
    {
        get
        {
            return GetRoomSize();
        }
        set
        {
            SetRoomSize(value);
        }
    }

    /// <summary>
    /// <para>Defines how reflective the imaginary room's walls are. Value can range from 0 to 1.</para>
    /// </summary>
    public float Damping
    {
        get
        {
            return GetDamping();
        }
        set
        {
            SetDamping(value);
        }
    }

    /// <summary>
    /// <para>Widens or narrows the stereo image of the reverb tail. 1 means fully widens. Value can range from 0 to 1.</para>
    /// </summary>
    public float Spread
    {
        get
        {
            return GetSpread();
        }
        set
        {
            SetSpread(value);
        }
    }

    /// <summary>
    /// <para>High-pass filter passes signals with a frequency higher than a certain cutoff frequency and attenuates signals with frequencies lower than the cutoff frequency. Value can range from 0 to 1.</para>
    /// </summary>
    public float Hipass
    {
        get
        {
            return GetHpf();
        }
        set
        {
            SetHpf(value);
        }
    }

    /// <summary>
    /// <para>Output percent of original sound. At 0, only modified sound is outputted. Value can range from 0 to 1.</para>
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
    /// <para>Output percent of modified sound. At 0, only original sound is outputted. Value can range from 0 to 1.</para>
    /// </summary>
    public float Wet
    {
        get
        {
            return GetWet();
        }
        set
        {
            SetWet(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioEffectReverb);

    private static readonly StringName NativeName = "AudioEffectReverb";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectReverb() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectReverb(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectReverb(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPredelayMsec, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPredelayMsec(float msec)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), msec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPredelayMsec, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPredelayMsec()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPredelayFeedback, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPredelayFeedback(float feedback)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), feedback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPredelayFeedback, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPredelayFeedback()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRoomSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRoomSize(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRoomSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRoomSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDamping, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDamping(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDamping, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDamping()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpread, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpread(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpread, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSpread()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDry, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDry(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDry, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDry()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWet, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWet(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWet, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWet()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHpf, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHpf(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHpf, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetHpf()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
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
        /// Cached name for the 'predelay_msec' property.
        /// </summary>
        public static readonly StringName PredelayMsec = "predelay_msec";
        /// <summary>
        /// Cached name for the 'predelay_feedback' property.
        /// </summary>
        public static readonly StringName PredelayFeedback = "predelay_feedback";
        /// <summary>
        /// Cached name for the 'room_size' property.
        /// </summary>
        public static readonly StringName RoomSize = "room_size";
        /// <summary>
        /// Cached name for the 'damping' property.
        /// </summary>
        public static readonly StringName Damping = "damping";
        /// <summary>
        /// Cached name for the 'spread' property.
        /// </summary>
        public static readonly StringName Spread = "spread";
        /// <summary>
        /// Cached name for the 'hipass' property.
        /// </summary>
        public static readonly StringName Hipass = "hipass";
        /// <summary>
        /// Cached name for the 'dry' property.
        /// </summary>
        public static readonly StringName Dry = "dry";
        /// <summary>
        /// Cached name for the 'wet' property.
        /// </summary>
        public static readonly StringName Wet = "wet";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffect.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_predelay_msec' method.
        /// </summary>
        public static readonly StringName SetPredelayMsec = "set_predelay_msec";
        /// <summary>
        /// Cached name for the 'get_predelay_msec' method.
        /// </summary>
        public static readonly StringName GetPredelayMsec = "get_predelay_msec";
        /// <summary>
        /// Cached name for the 'set_predelay_feedback' method.
        /// </summary>
        public static readonly StringName SetPredelayFeedback = "set_predelay_feedback";
        /// <summary>
        /// Cached name for the 'get_predelay_feedback' method.
        /// </summary>
        public static readonly StringName GetPredelayFeedback = "get_predelay_feedback";
        /// <summary>
        /// Cached name for the 'set_room_size' method.
        /// </summary>
        public static readonly StringName SetRoomSize = "set_room_size";
        /// <summary>
        /// Cached name for the 'get_room_size' method.
        /// </summary>
        public static readonly StringName GetRoomSize = "get_room_size";
        /// <summary>
        /// Cached name for the 'set_damping' method.
        /// </summary>
        public static readonly StringName SetDamping = "set_damping";
        /// <summary>
        /// Cached name for the 'get_damping' method.
        /// </summary>
        public static readonly StringName GetDamping = "get_damping";
        /// <summary>
        /// Cached name for the 'set_spread' method.
        /// </summary>
        public static readonly StringName SetSpread = "set_spread";
        /// <summary>
        /// Cached name for the 'get_spread' method.
        /// </summary>
        public static readonly StringName GetSpread = "get_spread";
        /// <summary>
        /// Cached name for the 'set_dry' method.
        /// </summary>
        public static readonly StringName SetDry = "set_dry";
        /// <summary>
        /// Cached name for the 'get_dry' method.
        /// </summary>
        public static readonly StringName GetDry = "get_dry";
        /// <summary>
        /// Cached name for the 'set_wet' method.
        /// </summary>
        public static readonly StringName SetWet = "set_wet";
        /// <summary>
        /// Cached name for the 'get_wet' method.
        /// </summary>
        public static readonly StringName GetWet = "get_wet";
        /// <summary>
        /// Cached name for the 'set_hpf' method.
        /// </summary>
        public static readonly StringName SetHpf = "set_hpf";
        /// <summary>
        /// Cached name for the 'get_hpf' method.
        /// </summary>
        public static readonly StringName GetHpf = "get_hpf";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffect.SignalName
    {
    }
}
