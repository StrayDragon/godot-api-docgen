namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class implements a writer that allows storing the multiple blobs in a ZIP archive. See also <see cref="Godot.ZipReader"/> and <see cref="Godot.PckPacker"/>.</para>
/// <para><code>
/// # Create a ZIP archive with a single file at its root.
/// func write_zip_file():
/// 	var writer = ZIPPacker.new()
/// 	var err = writer.open("user://archive.zip")
/// 	if err != OK:
/// 		return err
/// 	writer.start_file("hello.txt")
/// 	writer.write_file("Hello World".to_utf8_buffer())
/// 	writer.close_file()
/// 
/// 	writer.close()
/// 	return OK
/// </code></para>
/// </summary>
[GodotClassName("ZIPPacker")]
public partial class ZipPacker : RefCounted
{
    public enum ZipAppend : long
    {
        /// <summary>
        /// <para>Create a new zip archive at the given path.</para>
        /// </summary>
        Create = 0,
        /// <summary>
        /// <para>Append a new zip archive to the end of the already existing file at the given path.</para>
        /// </summary>
        Createafter = 1,
        /// <summary>
        /// <para>Add new files to the existing zip archive at the given path.</para>
        /// </summary>
        Addinzip = 2
    }

    public enum CompressionLevelEnum : long
    {
        /// <summary>
        /// <para>Start a file with the default Deflate compression level (<c>6</c>). This is a good compromise between speed and file size.</para>
        /// </summary>
        Default = -1,
        /// <summary>
        /// <para>Start a file with no compression. This is also known as the "Store" compression mode and is the fastest method of packing files inside a ZIP archive. Consider using this mode for files that are already compressed (such as JPEG, PNG, MP3, or Ogg Vorbis files).</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Start a file with the fastest Deflate compression level (<c>1</c>). This is fast to compress, but results in larger file sizes than <see cref="Godot.ZipPacker.CompressionLevelEnum.Default"/>. Decompression speed is generally unaffected by the chosen compression level.</para>
        /// </summary>
        Fast = 1,
        /// <summary>
        /// <para>Start a file with the best Deflate compression level (<c>9</c>). This is slow to compress, but results in smaller file sizes than <see cref="Godot.ZipPacker.CompressionLevelEnum.Default"/>. Decompression speed is generally unaffected by the chosen compression level.</para>
        /// </summary>
        Best = 9
    }

    /// <summary>
    /// <para>The compression level used when <see cref="Godot.ZipPacker.StartFile(string)"/> is called. Use <see cref="Godot.ZipPacker.CompressionLevelEnum"/> as a reference.</para>
    /// </summary>
    public int CompressionLevel
    {
        get
        {
            return GetCompressionLevel();
        }
        set
        {
            SetCompressionLevel(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ZipPacker);

    private static readonly StringName NativeName = "ZIPPacker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ZipPacker() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ZipPacker(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ZipPacker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Open, 1936816515ul);

    /// <summary>
    /// <para>Opens a zip file for writing at the given path using the specified write mode.</para>
    /// <para>This must be called before everything else.</para>
    /// </summary>
    public Error Open(string path, ZipPacker.ZipAppend append = (ZipPacker.ZipAppend)(0))
    {
        return (Error)NativeCalls.godot_icall_2_387(MethodBind0, GodotObject.GetPtr(this), path, (int)append);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCompressionLevel, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCompressionLevel(int compressionLevel)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), compressionLevel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCompressionLevel, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCompressionLevel()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StartFile, 166001499ul);

    /// <summary>
    /// <para>Starts writing to a file within the archive. Only one file can be written at the same time.</para>
    /// <para>Must be called after <see cref="Godot.ZipPacker.Open(string, ZipPacker.ZipAppend)"/>.</para>
    /// </summary>
    public Error StartFile(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind3, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.WriteFile, 680677267ul);

    /// <summary>
    /// <para>Write the given <paramref name="data"/> to the file.</para>
    /// <para>Needs to be called after <see cref="Godot.ZipPacker.StartFile(string)"/>.</para>
    /// </summary>
    public Error WriteFile(byte[] data)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind4, GodotObject.GetPtr(this), data);
    }

    /// <summary>
    /// <para>Write the given <paramref name="data"/> to the file.</para>
    /// <para>Needs to be called after <see cref="Godot.ZipPacker.StartFile(string)"/>.</para>
    /// </summary>
    public Error WriteFile(ReadOnlySpan<byte> data)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind4, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CloseFile, 166280745ul);

    /// <summary>
    /// <para>Stops writing to a file within the archive.</para>
    /// <para>It will fail if there is no open file.</para>
    /// </summary>
    public Error CloseFile()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Close, 166280745ul);

    /// <summary>
    /// <para>Closes the underlying resources used by this instance.</para>
    /// </summary>
    public Error Close()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
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
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'compression_level' property.
        /// </summary>
        public static readonly StringName CompressionLevel = "compression_level";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'open' method.
        /// </summary>
        public static readonly StringName Open = "open";
        /// <summary>
        /// Cached name for the 'set_compression_level' method.
        /// </summary>
        public static readonly StringName SetCompressionLevel = "set_compression_level";
        /// <summary>
        /// Cached name for the 'get_compression_level' method.
        /// </summary>
        public static readonly StringName GetCompressionLevel = "get_compression_level";
        /// <summary>
        /// Cached name for the 'start_file' method.
        /// </summary>
        public static readonly StringName StartFile = "start_file";
        /// <summary>
        /// Cached name for the 'write_file' method.
        /// </summary>
        public static readonly StringName WriteFile = "write_file";
        /// <summary>
        /// Cached name for the 'close_file' method.
        /// </summary>
        public static readonly StringName CloseFile = "close_file";
        /// <summary>
        /// Cached name for the 'close' method.
        /// </summary>
        public static readonly StringName Close = "close";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
