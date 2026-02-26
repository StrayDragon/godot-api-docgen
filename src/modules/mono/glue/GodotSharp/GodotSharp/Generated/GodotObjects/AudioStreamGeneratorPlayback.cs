namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is meant to be used with <see cref="Godot.AudioStreamGenerator"/> to play back the generated audio in real-time.</para>
/// </summary>
public partial class AudioStreamGeneratorPlayback : AudioStreamPlaybackResampled
{
    private static readonly System.Type CachedType = typeof(AudioStreamGeneratorPlayback);

    private static readonly StringName NativeName = "AudioStreamGeneratorPlayback";

    internal AudioStreamGeneratorPlayback() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamGeneratorPlayback(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamGeneratorPlayback(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushFrame, 3975407249ul);

    /// <summary>
    /// <para>Pushes a single audio data frame to the buffer. This is usually less efficient than <see cref="Godot.AudioStreamGeneratorPlayback.PushBuffer(Vector2[])"/> in C# and compiled languages via GDExtension, but <see cref="Godot.AudioStreamGeneratorPlayback.PushFrame(Vector2)"/> may be <i>more</i> efficient in GDScript.</para>
    /// </summary>
    public unsafe bool PushFrame(Vector2 frame)
    {
        return NativeCalls.godot_icall_1_199(MethodBind0, GodotObject.GetPtr(this), &frame).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanPushBuffer, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a buffer of the size <paramref name="amount"/> can be pushed to the audio sample data buffer without overflowing it, <see langword="false"/> otherwise.</para>
    /// </summary>
    public bool CanPushBuffer(int amount)
    {
        return NativeCalls.godot_icall_1_62(MethodBind1, GodotObject.GetPtr(this), amount).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushBuffer, 1361156557ul);

    /// <summary>
    /// <para>Pushes several audio data frames to the buffer. This is usually more efficient than <see cref="Godot.AudioStreamGeneratorPlayback.PushFrame(Vector2)"/> in C# and compiled languages via GDExtension, but <see cref="Godot.AudioStreamGeneratorPlayback.PushBuffer(Vector2[])"/> may be <i>less</i> efficient in GDScript.</para>
    /// </summary>
    public bool PushBuffer(Vector2[] frames)
    {
        return NativeCalls.godot_icall_1_200(MethodBind2, GodotObject.GetPtr(this), frames).ToBool();
    }

    /// <summary>
    /// <para>Pushes several audio data frames to the buffer. This is usually more efficient than <see cref="Godot.AudioStreamGeneratorPlayback.PushFrame(Vector2)"/> in C# and compiled languages via GDExtension, but <see cref="Godot.AudioStreamGeneratorPlayback.PushBuffer(Vector2[])"/> may be <i>less</i> efficient in GDScript.</para>
    /// </summary>
    public bool PushBuffer(ReadOnlySpan<Vector2> frames)
    {
        return NativeCalls.godot_icall_1_200(MethodBind2, GodotObject.GetPtr(this), frames).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFramesAvailable, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of frames that can be pushed to the audio sample data buffer without overflowing it. If the result is <c>0</c>, the buffer is full.</para>
    /// </summary>
    public int GetFramesAvailable()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkips, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of times the playback skipped due to a buffer underrun in the audio sample data. This value is reset at the start of the playback.</para>
    /// </summary>
    public int GetSkips()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearBuffer, 3218959716ul);

    /// <summary>
    /// <para>Clears the audio sample data buffer.</para>
    /// </summary>
    public void ClearBuffer()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : AudioStreamPlaybackResampled.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioStreamPlaybackResampled.MethodName
    {
        /// <summary>
        /// Cached name for the 'push_frame' method.
        /// </summary>
        public static readonly StringName PushFrame = "push_frame";
        /// <summary>
        /// Cached name for the 'can_push_buffer' method.
        /// </summary>
        public static readonly StringName CanPushBuffer = "can_push_buffer";
        /// <summary>
        /// Cached name for the 'push_buffer' method.
        /// </summary>
        public static readonly StringName PushBuffer = "push_buffer";
        /// <summary>
        /// Cached name for the 'get_frames_available' method.
        /// </summary>
        public static readonly StringName GetFramesAvailable = "get_frames_available";
        /// <summary>
        /// Cached name for the 'get_skips' method.
        /// </summary>
        public static readonly StringName GetSkips = "get_skips";
        /// <summary>
        /// Cached name for the 'clear_buffer' method.
        /// </summary>
        public static readonly StringName ClearBuffer = "clear_buffer";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStreamPlaybackResampled.SignalName
    {
    }
}
