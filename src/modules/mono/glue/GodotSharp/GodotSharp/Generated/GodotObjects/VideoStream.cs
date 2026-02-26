namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base resource type for all video streams. Classes that derive from <see cref="Godot.VideoStream"/> can all be used as resource types to play back videos in <see cref="Godot.VideoStreamPlayer"/>.</para>
/// </summary>
public partial class VideoStream : Resource
{
    /// <summary>
    /// <para>The video file path or URI that this <see cref="Godot.VideoStream"/> resource handles.</para>
    /// <para>For <see cref="Godot.VideoStreamTheora"/>, this filename should be an Ogg Theora video file with the <c>.ogv</c> extension.</para>
    /// </summary>
    public string File
    {
        get
        {
            return GetFile();
        }
        set
        {
            SetFile(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VideoStream);

    private static readonly StringName NativeName = "VideoStream";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VideoStream() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VideoStream(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VideoStream(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when the video starts playing, to initialize and return a subclass of <see cref="Godot.VideoStreamPlayback"/>.</para>
    /// </summary>
    public virtual VideoStreamPlayback _InstantiatePlayback()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFile, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFile(string file)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), file);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFile, 2841200299ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetFile()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__instantiate_playback = "_InstantiatePlayback";

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
        if ((method == MethodProxyName__instantiate_playback || method == MethodName._InstantiatePlayback) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__instantiate_playback.NativeValue))
        {
            var callRet = _InstantiatePlayback();
            ret = VariantUtils.CreateFrom<VideoStreamPlayback>(callRet);
            return true;
        }
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
        if (method == MethodName._InstantiatePlayback)
        {
            if (HasGodotClassMethod(MethodProxyName__instantiate_playback.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'file' property.
        /// </summary>
        public static readonly StringName File = "file";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_instantiate_playback' method.
        /// </summary>
        public static readonly StringName _InstantiatePlayback = "_instantiate_playback";
        /// <summary>
        /// Cached name for the 'set_file' method.
        /// </summary>
        public static readonly StringName SetFile = "set_file";
        /// <summary>
        /// Cached name for the 'get_file' method.
        /// </summary>
        public static readonly StringName GetFile = "get_file";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
