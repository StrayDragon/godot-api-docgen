namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class implements a reader that can extract the content of individual files inside a ZIP archive. See also <see cref="Godot.ZipPacker"/>.</para>
/// <para><code>
/// # Read a single file from a ZIP archive.
/// func read_zip_file():
/// 	var reader = ZIPReader.new()
/// 	var err = reader.open("user://archive.zip")
/// 	if err != OK:
/// 		return PackedByteArray()
/// 	var res = reader.read_file("hello.txt")
/// 	reader.close()
/// 	return res
/// 
/// # Extract all files from a ZIP archive, preserving the directories within.
/// # This acts like the "Extract all" functionality from most archive managers.
/// func extract_all_from_zip():
/// 	var reader = ZIPReader.new()
/// 	reader.open("res://archive.zip")
/// 
/// 	# Destination directory for the extracted files (this folder must exist before extraction).
/// 	# Not all ZIP archives put everything in a single root folder,
/// 	# which means several files/folders may be created in `root_dir` after extraction.
/// 	var root_dir = DirAccess.open("user://")
/// 
/// 	var files = reader.get_files()
/// 	for file_path in files:
/// 		# If the current entry is a directory.
/// 		if file_path.ends_with("/"):
/// 			root_dir.make_dir_recursive(file_path)
/// 			continue
/// 
/// 		# Write file contents, creating folders automatically when needed.
/// 		# Not all ZIP archives are strictly ordered, so we need to do this in case
/// 		# the file entry comes before the folder entry.
/// 		root_dir.make_dir_recursive(root_dir.get_current_dir().path_join(file_path).get_base_dir())
/// 		var file = FileAccess.open(root_dir.get_current_dir().path_join(file_path), FileAccess.WRITE)
/// 		var buffer = reader.read_file(file_path)
/// 		file.store_buffer(buffer)
/// </code></para>
/// </summary>
[GodotClassName("ZIPReader")]
public partial class ZipReader : RefCounted
{
    private static readonly System.Type CachedType = typeof(ZipReader);

    private static readonly StringName NativeName = "ZIPReader";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ZipReader() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ZipReader(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ZipReader(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Open, 166001499ul);

    /// <summary>
    /// <para>Opens the zip archive at the given <paramref name="path"/> and reads its file index.</para>
    /// </summary>
    public Error Open(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Close, 166280745ul);

    /// <summary>
    /// <para>Closes the underlying resources used by this instance.</para>
    /// </summary>
    public Error Close()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFiles, 2981934095ul);

    /// <summary>
    /// <para>Returns the list of names of all files in the loaded archive.</para>
    /// <para>Must be called after <see cref="Godot.ZipReader.Open(string)"/>.</para>
    /// </summary>
    public string[] GetFiles()
    {
        return NativeCalls.godot_icall_0_108(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReadFile, 740857591ul);

    /// <summary>
    /// <para>Loads the whole content of a file in the loaded zip archive into memory and returns it.</para>
    /// <para>Must be called after <see cref="Godot.ZipReader.Open(string)"/>.</para>
    /// </summary>
    public byte[] ReadFile(string path, bool caseSensitive = true)
    {
        return NativeCalls.godot_icall_2_1517(MethodBind3, GodotObject.GetPtr(this), path, caseSensitive.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FileExists, 35364943ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the file exists in the loaded zip archive.</para>
    /// <para>Must be called after <see cref="Godot.ZipReader.Open(string)"/>.</para>
    /// </summary>
    public bool FileExists(string path, bool caseSensitive = true)
    {
        return NativeCalls.godot_icall_2_1468(MethodBind4, GodotObject.GetPtr(this), path, caseSensitive.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCompressionLevel, 3694577386ul);

    /// <summary>
    /// <para>Returns the compression level of the file in the loaded zip archive. Returns <c>-1</c> if the file doesn't exist or any other error occurs. Must be called after <see cref="Godot.ZipReader.Open(string)"/>.</para>
    /// </summary>
    public int GetCompressionLevel(string path, bool caseSensitive = true)
    {
        return NativeCalls.godot_icall_2_350(MethodBind5, GodotObject.GetPtr(this), path, caseSensitive.ToGodotBool());
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
        /// Cached name for the 'close' method.
        /// </summary>
        public static readonly StringName Close = "close";
        /// <summary>
        /// Cached name for the 'get_files' method.
        /// </summary>
        public static readonly StringName GetFiles = "get_files";
        /// <summary>
        /// Cached name for the 'read_file' method.
        /// </summary>
        public static readonly StringName ReadFile = "read_file";
        /// <summary>
        /// Cached name for the 'file_exists' method.
        /// </summary>
        public static readonly StringName FileExists = "file_exists";
        /// <summary>
        /// Cached name for the 'get_compression_level' method.
        /// </summary>
        public static readonly StringName GetCompressionLevel = "get_compression_level";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
