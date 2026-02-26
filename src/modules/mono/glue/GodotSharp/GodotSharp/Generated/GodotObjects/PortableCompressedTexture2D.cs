namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class allows storing compressed textures as self contained (not imported) resources.</para>
/// <para>For 2D usage (compressed on disk, uncompressed on VRAM), the lossy and lossless modes are recommended. For 3D usage (compressed on VRAM) it depends on the target platform.</para>
/// <para>If you intend to only use desktop, S3TC or BPTC are recommended. For only mobile, ETC2 is recommended.</para>
/// <para>For portable, self contained 3D textures that work on both desktop and mobile, Basis Universal is recommended (although it has a small quality cost and longer compression time as a tradeoff).</para>
/// <para>This resource is intended to be created from code.</para>
/// </summary>
public partial class PortableCompressedTexture2D : Texture2D
{
    public enum CompressionMode : long
    {
        Lossless = 0,
        Lossy = 1,
        BasisUniversal = 2,
        S3Tc = 3,
        Etc2 = 4,
        Bptc = 5,
        Astc = 6
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public byte[] _Data
    {
        get
        {
            return _GetData();
        }
        set
        {
            _SetData(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Allows overriding the texture's size (for 2D only).</para>
    /// </summary>
    public Vector2 SizeOverride
    {
        get
        {
            return GetSizeOverride();
        }
        set
        {
            SetSizeOverride(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, when running in the editor, this texture will keep the source-compressed data in memory, allowing the data to persist after loading. Otherwise, the source-compressed data is lost after loading and the texture can't be re-saved.</para>
    /// <para><b>Note:</b> This property must be set before <see cref="Godot.PortableCompressedTexture2D.CreateFromImage(Image, PortableCompressedTexture2D.CompressionMode, bool, float)"/> for this to work.</para>
    /// </summary>
    public bool KeepCompressedBuffer
    {
        get
        {
            return IsKeepingCompressedBuffer();
        }
        set
        {
            SetKeepCompressedBuffer(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PortableCompressedTexture2D);

    private static readonly StringName NativeName = "PortableCompressedTexture2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PortableCompressedTexture2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PortableCompressedTexture2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PortableCompressedTexture2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromImage, 3679243433ul);

    /// <summary>
    /// <para>Initializes the compressed texture from a base image. The compression mode must be provided.</para>
    /// <para><paramref name="normalMap"/> is recommended to ensure optimum quality if this image will be used as a normal map.</para>
    /// <para>If lossy compression is requested, the quality setting can optionally be provided. This maps to Lossy WebP compression quality.</para>
    /// </summary>
    public void CreateFromImage(Image image, PortableCompressedTexture2D.CompressionMode compressionMode, bool normalMap = false, float lossyQuality = 0.8f)
    {
        NativeCalls.godot_icall_4_1024(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(image), (int)compressionMode, normalMap.ToGodotBool(), lossyQuality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFormat, 3847873762ul);

    /// <summary>
    /// <para>Return the image format used (valid after initialized).</para>
    /// </summary>
    public Image.Format GetFormat()
    {
        return (Image.Format)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCompressionMode, 3265612739ul);

    /// <summary>
    /// <para>Return the compression mode used (valid after initialized).</para>
    /// </summary>
    public PortableCompressedTexture2D.CompressionMode GetCompressionMode()
    {
        return (PortableCompressedTexture2D.CompressionMode)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSizeOverride, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSizeOverride(Vector2 size)
    {
        NativeCalls.godot_icall_1_36(MethodBind3, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSizeOverride, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetSizeOverride()
    {
        return NativeCalls.godot_icall_0_37(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKeepCompressedBuffer, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetKeepCompressedBuffer(bool keep)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), keep.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsKeepingCompressedBuffer, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsKeepingCompressedBuffer()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBasisuCompressorParams, 1602489585ul);

    /// <summary>
    /// <para>Sets the compressor parameters for Basis Universal compression. See also the settings in <c>ResourceImporterTexture</c>.</para>
    /// <para><b>Note:</b> This method must be called before <see cref="Godot.PortableCompressedTexture2D.CreateFromImage(Image, PortableCompressedTexture2D.CompressionMode, bool, float)"/> for this to work.</para>
    /// </summary>
    public void SetBasisuCompressorParams(int uastcLevel, float rdoQualityLoss)
    {
        NativeCalls.godot_icall_2_69(MethodBind7, GodotObject.GetPtr(this), uastcLevel, rdoQualityLoss);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetData, 2971499966ul);

    internal void _SetData(byte[] data)
    {
        NativeCalls.godot_icall_1_204(MethodBind8, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetData, 2362200018ul);

    internal byte[] _GetData()
    {
        return NativeCalls.godot_icall_0_2(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKeepAllCompressedBuffers, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="keep"/> is <see langword="true"/>, overrides the flag globally for all textures of this type. This is used primarily by the editor.</para>
    /// </summary>
    public static void SetKeepAllCompressedBuffers(bool keep)
    {
        NativeCalls.godot_icall_1_1025(MethodBind10, keep.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsKeepingAllCompressedBuffers, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the flag is overridden for all textures of this type.</para>
    /// </summary>
    public static bool IsKeepingAllCompressedBuffers()
    {
        return NativeCalls.godot_icall_0_1026(MethodBind11).ToBool();
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
    public new class PropertyName : Texture2D.PropertyName
    {
        /// <summary>
        /// Cached name for the '_data' property.
        /// </summary>
        public static readonly StringName _Data = "_data";
        /// <summary>
        /// Cached name for the 'size_override' property.
        /// </summary>
        public static readonly StringName SizeOverride = "size_override";
        /// <summary>
        /// Cached name for the 'keep_compressed_buffer' property.
        /// </summary>
        public static readonly StringName KeepCompressedBuffer = "keep_compressed_buffer";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_from_image' method.
        /// </summary>
        public static readonly StringName CreateFromImage = "create_from_image";
        /// <summary>
        /// Cached name for the 'get_format' method.
        /// </summary>
        public static readonly StringName GetFormat = "get_format";
        /// <summary>
        /// Cached name for the 'get_compression_mode' method.
        /// </summary>
        public static readonly StringName GetCompressionMode = "get_compression_mode";
        /// <summary>
        /// Cached name for the 'set_size_override' method.
        /// </summary>
        public static readonly StringName SetSizeOverride = "set_size_override";
        /// <summary>
        /// Cached name for the 'get_size_override' method.
        /// </summary>
        public static readonly StringName GetSizeOverride = "get_size_override";
        /// <summary>
        /// Cached name for the 'set_keep_compressed_buffer' method.
        /// </summary>
        public static readonly StringName SetKeepCompressedBuffer = "set_keep_compressed_buffer";
        /// <summary>
        /// Cached name for the 'is_keeping_compressed_buffer' method.
        /// </summary>
        public static readonly StringName IsKeepingCompressedBuffer = "is_keeping_compressed_buffer";
        /// <summary>
        /// Cached name for the 'set_basisu_compressor_params' method.
        /// </summary>
        public static readonly StringName SetBasisuCompressorParams = "set_basisu_compressor_params";
        /// <summary>
        /// Cached name for the '_set_data' method.
        /// </summary>
        public static readonly StringName _SetData = "_set_data";
        /// <summary>
        /// Cached name for the '_get_data' method.
        /// </summary>
        public static readonly StringName _GetData = "_get_data";
        /// <summary>
        /// Cached name for the 'set_keep_all_compressed_buffers' method.
        /// </summary>
        public static readonly StringName SetKeepAllCompressedBuffers = "set_keep_all_compressed_buffers";
        /// <summary>
        /// Cached name for the 'is_keeping_all_compressed_buffers' method.
        /// </summary>
        public static readonly StringName IsKeepingAllCompressedBuffers = "is_keeping_all_compressed_buffers";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}
