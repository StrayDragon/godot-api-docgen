namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Ogg Vorbis is a lossy audio format, with better audio quality compared to <see cref="Godot.ResourceImporterMP3"/> at a given bitrate.</para>
/// <para>In most cases, it's recommended to use Ogg Vorbis over MP3. However, if you're using an MP3 sound source with no higher quality source available, then it's recommended to use the MP3 file directly to avoid double lossy compression.</para>
/// <para>Ogg Vorbis requires more CPU to decode than <see cref="Godot.ResourceImporterWav"/>. If you need to play a lot of simultaneous sounds, it's recommended to use WAV for those sounds instead, especially if targeting low-end devices.</para>
/// </summary>
public partial class ResourceImporterOggVorbis : ResourceImporter
{
    private static readonly System.Type CachedType = typeof(ResourceImporterOggVorbis);

    private static readonly StringName NativeName = "ResourceImporterOggVorbis";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ResourceImporterOggVorbis() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceImporterOggVorbis(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceImporterOggVorbis(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromBuffer, 354904730ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.AudioStreamOggVorbis"/> instance from the given buffer. The buffer must contain Ogg Vorbis data.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AudioStreamOggVorbis.LoadFromBuffer(byte[])' instead.")]
    public static AudioStreamOggVorbis LoadFromBuffer(byte[] streamData)
    {
        return (AudioStreamOggVorbis)NativeCalls.godot_icall_1_202(MethodBind0, streamData);
    }

    /// <summary>
    /// <para>Creates a new <see cref="Godot.AudioStreamOggVorbis"/> instance from the given buffer. The buffer must contain Ogg Vorbis data.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AudioStreamOggVorbis.LoadFromBuffer(byte[])' instead.")]
    public static AudioStreamOggVorbis LoadFromBuffer(ReadOnlySpan<byte> streamData)
    {
        return (AudioStreamOggVorbis)NativeCalls.godot_icall_1_202(MethodBind0, streamData);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromFile, 797568536ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.AudioStreamOggVorbis"/> instance from the given file path. The file must be in Ogg Vorbis format.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AudioStreamOggVorbis.LoadFromFile(string)' instead.")]
    public static AudioStreamOggVorbis LoadFromFile(string path)
    {
        return (AudioStreamOggVorbis)NativeCalls.godot_icall_1_203(MethodBind1, path);
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
    public new class PropertyName : ResourceImporter.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ResourceImporter.MethodName
    {
        /// <summary>
        /// Cached name for the 'load_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadFromBuffer = "load_from_buffer";
        /// <summary>
        /// Cached name for the 'load_from_file' method.
        /// </summary>
        public static readonly StringName LoadFromFile = "load_from_file";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ResourceImporter.SignalName
    {
    }
}
