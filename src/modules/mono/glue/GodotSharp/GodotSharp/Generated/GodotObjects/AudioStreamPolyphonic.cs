namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>AudioStream that lets the user play custom streams at any time from code, simultaneously using a single player.</para>
/// <para>Playback control is done via the <see cref="Godot.AudioStreamPlaybackPolyphonic"/> instance set inside the player, which can be obtained via <see cref="Godot.AudioStreamPlayer.GetStreamPlayback()"/>, <see cref="Godot.AudioStreamPlayer2D.GetStreamPlayback()"/> or <see cref="Godot.AudioStreamPlayer3D.GetStreamPlayback()"/> methods. Obtaining the playback instance is only valid after the <c>stream</c> property is set as an <see cref="Godot.AudioStreamPolyphonic"/> in those players.</para>
/// </summary>
public partial class AudioStreamPolyphonic : AudioStream
{
    /// <summary>
    /// <para>Maximum amount of simultaneous streams that can be played.</para>
    /// </summary>
    public int Polyphony
    {
        get
        {
            return GetPolyphony();
        }
        set
        {
            SetPolyphony(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioStreamPolyphonic);

    private static readonly StringName NativeName = "AudioStreamPolyphonic";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamPolyphonic() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamPolyphonic(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamPolyphonic(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPolyphony, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPolyphony(int voices)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), voices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPolyphony, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPolyphony()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : AudioStream.PropertyName
    {
        /// <summary>
        /// Cached name for the 'polyphony' property.
        /// </summary>
        public static readonly StringName Polyphony = "polyphony";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioStream.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_polyphony' method.
        /// </summary>
        public static readonly StringName SetPolyphony = "set_polyphony";
        /// <summary>
        /// Cached name for the 'get_polyphony' method.
        /// </summary>
        public static readonly StringName GetPolyphony = "get_polyphony";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStream.SignalName
    {
    }
}
