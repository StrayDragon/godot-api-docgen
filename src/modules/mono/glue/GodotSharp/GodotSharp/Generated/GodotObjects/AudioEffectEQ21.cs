namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Frequency bands:</para>
/// <para>Band 1: 22 Hz</para>
/// <para>Band 2: 32 Hz</para>
/// <para>Band 3: 44 Hz</para>
/// <para>Band 4: 63 Hz</para>
/// <para>Band 5: 90 Hz</para>
/// <para>Band 6: 125 Hz</para>
/// <para>Band 7: 175 Hz</para>
/// <para>Band 8: 250 Hz</para>
/// <para>Band 9: 350 Hz</para>
/// <para>Band 10: 500 Hz</para>
/// <para>Band 11: 700 Hz</para>
/// <para>Band 12: 1000 Hz</para>
/// <para>Band 13: 1400 Hz</para>
/// <para>Band 14: 2000 Hz</para>
/// <para>Band 15: 2800 Hz</para>
/// <para>Band 16: 4000 Hz</para>
/// <para>Band 17: 5600 Hz</para>
/// <para>Band 18: 8000 Hz</para>
/// <para>Band 19: 11000 Hz</para>
/// <para>Band 20: 16000 Hz</para>
/// <para>Band 21: 22000 Hz</para>
/// <para>See also <see cref="Godot.AudioEffectEQ"/>, <see cref="Godot.AudioEffectEQ6"/>, <see cref="Godot.AudioEffectEQ10"/>.</para>
/// </summary>
public partial class AudioEffectEQ21 : AudioEffectEQ
{
    private static readonly System.Type CachedType = typeof(AudioEffectEQ21);

    private static readonly StringName NativeName = "AudioEffectEQ21";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectEQ21() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectEQ21(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectEQ21(bool memoryOwn) : base(memoryOwn) { }

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
    public new class PropertyName : AudioEffectEQ.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffectEQ.MethodName
    {
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffectEQ.SignalName
    {
    }
}
