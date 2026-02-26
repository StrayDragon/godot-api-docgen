namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Increases or decreases the volume being routed through the audio bus.</para>
/// </summary>
public partial class AudioEffectAmplify : AudioEffect
{
    /// <summary>
    /// <para>Amount of amplification in decibels. Positive values make the sound louder, negative values make it quieter. Value can range from -80 to 24.</para>
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
    /// <para>Amount of amplification as a linear value.</para>
    /// <para><b>Note:</b> This member modifies <see cref="Godot.AudioEffectAmplify.VolumeDb"/> for convenience. The returned value is equivalent to the result of <c>@GlobalScope.db_to_linear</c> on <see cref="Godot.AudioEffectAmplify.VolumeDb"/>. Setting this member is equivalent to setting <see cref="Godot.AudioEffectAmplify.VolumeDb"/> to the result of <c>@GlobalScope.linear_to_db</c> on a value.</para>
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

    private static readonly System.Type CachedType = typeof(AudioEffectAmplify);

    private static readonly StringName NativeName = "AudioEffectAmplify";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectAmplify() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectAmplify(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectAmplify(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumeDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumeDb(float volume)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), volume);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumeDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumeDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumeLinear, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumeLinear(float volume)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), volume);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumeLinear, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumeLinear()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'volume_db' property.
        /// </summary>
        public static readonly StringName VolumeDb = "volume_db";
        /// <summary>
        /// Cached name for the 'volume_linear' property.
        /// </summary>
        public static readonly StringName VolumeLinear = "volume_linear";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffect.MethodName
    {
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
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffect.SignalName
    {
    }
}
