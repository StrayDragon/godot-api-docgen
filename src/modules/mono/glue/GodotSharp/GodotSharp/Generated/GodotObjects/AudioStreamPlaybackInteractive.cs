namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Playback component of <see cref="Godot.AudioStreamInteractive"/>. Contains functions to change the currently played clip.</para>
/// </summary>
public partial class AudioStreamPlaybackInteractive : AudioStreamPlayback
{
    private static readonly System.Type CachedType = typeof(AudioStreamPlaybackInteractive);

    private static readonly StringName NativeName = "AudioStreamPlaybackInteractive";

    internal AudioStreamPlaybackInteractive() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamPlaybackInteractive(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamPlaybackInteractive(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SwitchToClipByName, 3304788590ul);

    /// <summary>
    /// <para>Switch to a clip (by name).</para>
    /// </summary>
    public void SwitchToClipByName(StringName clipName)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(clipName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SwitchToClip, 1286410249ul);

    /// <summary>
    /// <para>Switch to a clip (by index).</para>
    /// </summary>
    public void SwitchToClip(int clipIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), clipIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentClipIndex, 3905245786ul);

    /// <summary>
    /// <para>Return the index of the currently playing clip. You can use this to get the name of the currently playing clip with <see cref="Godot.AudioStreamInteractive.GetClipName(int)"/>.</para>
    /// <para><b>Example:</b> Get the currently playing clip name from inside an <see cref="Godot.AudioStreamPlayer"/> node.</para>
    /// <para></para>
    /// </summary>
    public int GetCurrentClipIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
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
    public new class PropertyName : AudioStreamPlayback.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioStreamPlayback.MethodName
    {
        /// <summary>
        /// Cached name for the 'switch_to_clip_by_name' method.
        /// </summary>
        public static readonly StringName SwitchToClipByName = "switch_to_clip_by_name";
        /// <summary>
        /// Cached name for the 'switch_to_clip' method.
        /// </summary>
        public static readonly StringName SwitchToClip = "switch_to_clip";
        /// <summary>
        /// Cached name for the 'get_current_clip_index' method.
        /// </summary>
        public static readonly StringName GetCurrentClipIndex = "get_current_clip_index";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStreamPlayback.SignalName
    {
    }
}
