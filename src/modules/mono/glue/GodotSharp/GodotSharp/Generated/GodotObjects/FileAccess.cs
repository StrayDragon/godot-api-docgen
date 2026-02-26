namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class can be used to permanently store data in the user device's file system and to read from it. This is useful for storing game save data or player configuration files.</para>
/// <para><b>Example:</b> How to write and read from a file. The file named <c>"save_game.dat"</c> will be stored in the user data folder, as specified in the <a href="$DOCS_URL/tutorials/io/data_paths.html">Data paths</a> documentation:</para>
/// <para><code>
/// public void SaveToFile(string content)
/// {
/// 	using var file = FileAccess.Open("user://save_game.dat", FileAccess.ModeFlags.Write);
/// 	file.StoreString(content);
/// }
/// 
/// public string LoadFromFile()
/// {
/// 	using var file = FileAccess.Open("user://save_game.dat", FileAccess.ModeFlags.Read);
/// 	string content = file.GetAsText();
/// 	return content;
/// }
/// </code></para>
/// <para>A <see cref="Godot.FileAccess"/> instance has its own file cursor, which is the position in bytes in the file where the next read/write operation will occur. Functions such as <see cref="Godot.FileAccess.Get8()"/>, <see cref="Godot.FileAccess.Get16()"/>, <see cref="Godot.FileAccess.Store8(byte)"/>, and <see cref="Godot.FileAccess.Store16(ushort)"/> will move the file cursor forward by the number of bytes read/written. The file cursor can be moved to a specific position using <see cref="Godot.FileAccess.Seek(ulong)"/> or <see cref="Godot.FileAccess.SeekEnd(long)"/>, and its position can be retrieved using <see cref="Godot.FileAccess.GetPosition()"/>.</para>
/// <para>A <see cref="Godot.FileAccess"/> instance will close its file when the instance is freed. Since it inherits <see cref="Godot.RefCounted"/>, this happens automatically when it is no longer in use. <see cref="Godot.FileAccess.Close()"/> can be called to close it earlier. In C#, the reference must be disposed manually, which can be done with the <c>using</c> statement or by calling the <c>Dispose</c> method directly.</para>
/// <para><b>Note:</b> To access project resources once exported, it is recommended to use <see cref="Godot.ResourceLoader"/> instead of <see cref="Godot.FileAccess"/>, as some files are converted to engine-specific formats and their original source files might not be present in the exported PCK package. If using <see cref="Godot.FileAccess"/>, make sure the file is included in the export by changing its import mode to <b>Keep File (exported as is)</b> in the Import dock, or, for files where this option is not available, change the non-resource export filter in the Export dialog to include the file's extension (e.g. <c>*.txt</c>).</para>
/// <para><b>Note:</b> Files are automatically closed only if the process exits "normally" (such as by clicking the window manager's close button or pressing Alt + F4). If you stop the project execution by pressing F8 while the project is running, the file won't be closed as the game process will be killed. You can work around this by calling <see cref="Godot.FileAccess.Flush()"/> at regular intervals.</para>
/// </summary>
public partial class FileAccess : RefCounted
{
    public enum ModeFlags : long
    {
        /// <summary>
        /// <para>Opens the file for read operations. The file cursor is positioned at the beginning of the file.</para>
        /// </summary>
        Read = 1,
        /// <summary>
        /// <para>Opens the file for write operations. If the file exists, it is truncated to zero length and its contents are cleared. Otherwise, it is created.</para>
        /// <para><b>Note:</b> When creating a file it must be in an already existing directory. To recursively create directories for a file path, see <see cref="Godot.DirAccess.MakeDirRecursive(string)"/>.</para>
        /// </summary>
        Write = 2,
        /// <summary>
        /// <para>Opens the file for read and write operations. Does not truncate the file. The file cursor is positioned at the beginning of the file.</para>
        /// </summary>
        ReadWrite = 3,
        /// <summary>
        /// <para>Opens the file for read and write operations. If the file exists, it is truncated to zero length and its contents are cleared. Otherwise, it is created. The file cursor is positioned at the beginning of the file.</para>
        /// <para><b>Note:</b> When creating a file it must be in an already existing directory. To recursively create directories for a file path, see <see cref="Godot.DirAccess.MakeDirRecursive(string)"/>.</para>
        /// </summary>
        WriteRead = 7
    }

    public enum CompressionMode : long
    {
        /// <summary>
        /// <para>Uses the <a href="https://fastlz.org/">FastLZ</a> compression method.</para>
        /// </summary>
        Fastlz = 0,
        /// <summary>
        /// <para>Uses the <a href="https://en.wikipedia.org/wiki/DEFLATE">DEFLATE</a> compression method.</para>
        /// </summary>
        Deflate = 1,
        /// <summary>
        /// <para>Uses the <a href="https://facebook.github.io/zstd/">Zstandard</a> compression method.</para>
        /// </summary>
        Zstd = 2,
        /// <summary>
        /// <para>Uses the <a href="https://www.gzip.org/">gzip</a> compression method.</para>
        /// </summary>
        GZip = 3,
        /// <summary>
        /// <para>Uses the <a href="https://github.com/google/brotli">brotli</a> compression method (only decompression is supported).</para>
        /// </summary>
        Brotli = 4
    }

    [System.Flags]
    public enum UnixPermissionFlags : long
    {
        /// <summary>
        /// <para>Read for owner bit.</para>
        /// </summary>
        ReadOwner = 256,
        /// <summary>
        /// <para>Write for owner bit.</para>
        /// </summary>
        WriteOwner = 128,
        /// <summary>
        /// <para>Execute for owner bit.</para>
        /// </summary>
        ExecuteOwner = 64,
        /// <summary>
        /// <para>Read for group bit.</para>
        /// </summary>
        ReadGroup = 32,
        /// <summary>
        /// <para>Write for group bit.</para>
        /// </summary>
        WriteGroup = 16,
        /// <summary>
        /// <para>Execute for group bit.</para>
        /// </summary>
        ExecuteGroup = 8,
        /// <summary>
        /// <para>Read for other bit.</para>
        /// </summary>
        ReadOther = 4,
        /// <summary>
        /// <para>Write for other bit.</para>
        /// </summary>
        WriteOther = 2,
        /// <summary>
        /// <para>Execute for other bit.</para>
        /// </summary>
        ExecuteOther = 1,
        /// <summary>
        /// <para>Set user id on execution bit.</para>
        /// </summary>
        SetUserId = 2048,
        /// <summary>
        /// <para>Set group id on execution bit.</para>
        /// </summary>
        SetGroupId = 1024,
        /// <summary>
        /// <para>Restricted deletion (sticky) bit.</para>
        /// </summary>
        RestrictedDelete = 512
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the file is read with big-endian <a href="https://en.wikipedia.org/wiki/Endianness">endianness</a>. If <see langword="false"/>, the file is read with little-endian endianness. If in doubt, leave this to <see langword="false"/> as most files are written with little-endian endianness.</para>
    /// <para><b>Note:</b> This is always reset to system endianness, which is little-endian on all supported platforms, whenever you open the file. Therefore, you must set <see cref="Godot.FileAccess.BigEndian"/> <i>after</i> opening the file, not before.</para>
    /// </summary>
    public bool BigEndian
    {
        get
        {
            return IsBigEndian();
        }
        set
        {
            SetBigEndian(value);
        }
    }

    private static readonly System.Type CachedType = typeof(FileAccess);

    private static readonly StringName NativeName = "FileAccess";

    internal FileAccess() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal FileAccess(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal FileAccess(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Open, 1247358404ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.FileAccess"/> object and opens the file for writing or reading, depending on the flags.</para>
    /// <para>Returns <see langword="null"/> if opening the file failed. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    public static FileAccess Open(string path, FileAccess.ModeFlags flags)
    {
        return (FileAccess)NativeCalls.godot_icall_2_555(MethodBind0, path, (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenEncrypted, 788003459ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.FileAccess"/> object and opens an encrypted file in write or read mode. You need to pass a binary key to encrypt/decrypt it.</para>
    /// <para><b>Note:</b> The provided key must be 32 bytes long.</para>
    /// <para>Returns <see langword="null"/> if opening the file failed. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    /// <param name="iV">If the parameter is null, then the default value is <c>Array.Empty&lt;byte&gt;()</c>.</param>
    public static FileAccess OpenEncrypted(string path, FileAccess.ModeFlags modeFlags, byte[] key, byte[] iV = null)
    {
        byte[] iVOrDefVal = iV != null ? iV : Array.Empty<byte>();
        return (FileAccess)NativeCalls.godot_icall_4_556(MethodBind1, path, (int)modeFlags, key, iVOrDefVal);
    }

    /// <summary>
    /// <para>Creates a new <see cref="Godot.FileAccess"/> object and opens an encrypted file in write or read mode. You need to pass a binary key to encrypt/decrypt it.</para>
    /// <para><b>Note:</b> The provided key must be 32 bytes long.</para>
    /// <para>Returns <see langword="null"/> if opening the file failed. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    public static FileAccess OpenEncrypted(string path, FileAccess.ModeFlags modeFlags, ReadOnlySpan<byte> key, ReadOnlySpan<byte> iV)
    {
        return (FileAccess)NativeCalls.godot_icall_4_556(MethodBind1, path, (int)modeFlags, key, iV);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenEncryptedWithPass, 790283377ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.FileAccess"/> object and opens an encrypted file in write or read mode. You need to pass a password to encrypt/decrypt it.</para>
    /// <para>Returns <see langword="null"/> if opening the file failed. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    public static FileAccess OpenEncryptedWithPass(string path, FileAccess.ModeFlags modeFlags, string pass)
    {
        return (FileAccess)NativeCalls.godot_icall_3_557(MethodBind2, path, (int)modeFlags, pass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenCompressed, 3686439335ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.FileAccess"/> object and opens a compressed file for reading or writing.</para>
    /// <para><b>Note:</b> <see cref="Godot.FileAccess.OpenCompressed(string, FileAccess.ModeFlags, FileAccess.CompressionMode)"/> can only read files that were saved by Godot, not third-party compression formats. See <a href="https://github.com/godotengine/godot/issues/28999">GitHub issue #28999</a> for a workaround.</para>
    /// <para>Returns <see langword="null"/> if opening the file failed. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    public static FileAccess OpenCompressed(string path, FileAccess.ModeFlags modeFlags, FileAccess.CompressionMode compressionMode = (FileAccess.CompressionMode)(0))
    {
        return (FileAccess)NativeCalls.godot_icall_3_558(MethodBind3, path, (int)modeFlags, (int)compressionMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpenError, 166280745ul);

    /// <summary>
    /// <para>Returns the result of the last <see cref="Godot.FileAccess.Open(string, FileAccess.ModeFlags)"/> call in the current thread.</para>
    /// </summary>
    public static Error GetOpenError()
    {
        return (Error)NativeCalls.godot_icall_0_372(MethodBind4);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTemp, 171914364ul);

    /// <summary>
    /// <para>Creates a temporary file. This file will be freed when the returned <see cref="Godot.FileAccess"/> is freed.</para>
    /// <para>If <paramref name="prefix"/> is not empty, it will be prefixed to the file name, separated by a <c>-</c>.</para>
    /// <para>If <paramref name="extension"/> is not empty, it will be appended to the temporary file name.</para>
    /// <para>If <paramref name="keep"/> is <see langword="true"/>, the file is not deleted when the returned <see cref="Godot.FileAccess"/> is freed.</para>
    /// <para>Returns <see langword="null"/> if opening the file failed. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    public static FileAccess CreateTemp(FileAccess.ModeFlags modeFlags, string prefix = "", string extension = "", bool keep = false)
    {
        return (FileAccess)NativeCalls.godot_icall_4_559(MethodBind5, (int)modeFlags, prefix, extension, keep.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFileAsBytes, 659035735ul);

    /// <summary>
    /// <para>Returns the whole <paramref name="path"/> file contents as a <see cref="byte"/>[] without any decoding.</para>
    /// <para>Returns an empty <see cref="byte"/>[] if an error occurred while opening the file. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    public static byte[] GetFileAsBytes(string path)
    {
        return NativeCalls.godot_icall_1_560(MethodBind6, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFileAsString, 1703090593ul);

    /// <summary>
    /// <para>Returns the whole <paramref name="path"/> file contents as a <see cref="string"/>. Text is interpreted as being UTF-8 encoded.</para>
    /// <para>Returns an empty <see cref="string"/> if an error occurred while opening the file. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    public static string GetFileAsString(string path)
    {
        return NativeCalls.godot_icall_1_561(MethodBind7, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Resize, 844576869ul);

    /// <summary>
    /// <para>Resizes the file to a specified length. The file must be open in a mode that permits writing. If the file is extended, NUL characters are appended. If the file is truncated, all data from the end file to the original length of the file is lost.</para>
    /// </summary>
    public Error Resize(long length)
    {
        return (Error)NativeCalls.godot_icall_1_562(MethodBind8, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Flush, 3218959716ul);

    /// <summary>
    /// <para>Writes the file's buffer to disk. Flushing is automatically performed when the file is closed. This means you don't need to call <see cref="Godot.FileAccess.Flush()"/> manually before closing a file. Still, calling <see cref="Godot.FileAccess.Flush()"/> can be used to ensure the data is safe even if the project crashes instead of being closed gracefully.</para>
    /// <para><b>Note:</b> Only call <see cref="Godot.FileAccess.Flush()"/> when you actually need it. Otherwise, it will decrease performance due to constant disk writes.</para>
    /// </summary>
    public void Flush()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPath, 201670096ul);

    /// <summary>
    /// <para>Returns the path as a <see cref="string"/> for the current open file.</para>
    /// </summary>
    public string GetPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathAbsolute, 201670096ul);

    /// <summary>
    /// <para>Returns the absolute path as a <see cref="string"/> for the current open file.</para>
    /// </summary>
    public string GetPathAbsolute()
    {
        return NativeCalls.godot_icall_0_58(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOpen, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the file is currently opened.</para>
    /// </summary>
    public bool IsOpen()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Seek, 1286410249ul);

    /// <summary>
    /// <para>Sets the file cursor to the specified position in bytes, from the beginning of the file. This changes the value returned by <see cref="Godot.FileAccess.GetPosition()"/>.</para>
    /// </summary>
    public void Seek(ulong position)
    {
        NativeCalls.godot_icall_1_544(MethodBind13, GodotObject.GetPtr(this), position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SeekEnd, 1995695955ul);

    /// <summary>
    /// <para>Sets the file cursor to the specified position in bytes, from the end of the file. This changes the value returned by <see cref="Godot.FileAccess.GetPosition()"/>.</para>
    /// <para><b>Note:</b> This is an offset, so you should use negative numbers otherwise the file cursor will be at the end of the file.</para>
    /// </summary>
    public void SeekEnd(long position = (long)(0))
    {
        NativeCalls.godot_icall_1_10(MethodBind14, GodotObject.GetPtr(this), position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3905245786ul);

    /// <summary>
    /// <para>Returns the file cursor's position in bytes from the beginning of the file. This is the file reading/writing cursor set by <see cref="Godot.FileAccess.Seek(ulong)"/> or <see cref="Godot.FileAccess.SeekEnd(long)"/> and advanced by read/write operations.</para>
    /// </summary>
    public ulong GetPosition()
    {
        return NativeCalls.godot_icall_0_137(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLength, 3905245786ul);

    /// <summary>
    /// <para>Returns the size of the file in bytes. For a pipe, returns the number of bytes available for reading from the pipe.</para>
    /// </summary>
    public ulong GetLength()
    {
        return NativeCalls.godot_icall_0_137(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EofReached, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the file cursor has already read past the end of the file.</para>
    /// <para><b>Note:</b> <c>eof_reached() == false</c> cannot be used to check whether there is more data available. To loop while there is more data available, use:</para>
    /// <para><code>
    /// while (file.GetPosition() &lt; file.GetLength())
    /// {
    /// 	// Read data
    /// }
    /// </code></para>
    /// </summary>
    public bool EofReached()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Get8, 3905245786ul);

    /// <summary>
    /// <para>Returns the next 8 bits from the file as an integer. This advances the file cursor by 1 byte. See <see cref="Godot.FileAccess.Store8(byte)"/> for details on what values can be stored and retrieved this way.</para>
    /// </summary>
    public byte Get8()
    {
        return NativeCalls.godot_icall_0_282(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Get16, 3905245786ul);

    /// <summary>
    /// <para>Returns the next 16 bits from the file as an integer. This advances the file cursor by 2 bytes. See <see cref="Godot.FileAccess.Store16(ushort)"/> for details on what values can be stored and retrieved this way.</para>
    /// </summary>
    public ushort Get16()
    {
        return NativeCalls.godot_icall_0_284(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Get32, 3905245786ul);

    /// <summary>
    /// <para>Returns the next 32 bits from the file as an integer. This advances the file cursor by 4 bytes. See <see cref="Godot.FileAccess.Store32(uint)"/> for details on what values can be stored and retrieved this way.</para>
    /// </summary>
    public uint Get32()
    {
        return NativeCalls.godot_icall_0_209(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Get64, 3905245786ul);

    /// <summary>
    /// <para>Returns the next 64 bits from the file as an integer. This advances the file cursor by 8 bytes. See <see cref="Godot.FileAccess.Store64(ulong)"/> for details on what values can be stored and retrieved this way.</para>
    /// </summary>
    public ulong Get64()
    {
        return NativeCalls.godot_icall_0_137(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHalf, 1740695150ul);

    /// <summary>
    /// <para>Returns the next 16 bits from the file as a half-precision floating-point number. This advances the file cursor by 2 bytes.</para>
    /// </summary>
    public float GetHalf()
    {
        return NativeCalls.godot_icall_0_68(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFloat, 1740695150ul);

    /// <summary>
    /// <para>Returns the next 32 bits from the file as a floating-point number. This advances the file cursor by 4 bytes.</para>
    /// </summary>
    public float GetFloat()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDouble, 1740695150ul);

    /// <summary>
    /// <para>Returns the next 64 bits from the file as a floating-point number. This advances the file cursor by 8 bytes.</para>
    /// </summary>
    public double GetDouble()
    {
        return NativeCalls.godot_icall_0_144(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReal, 1740695150ul);

    /// <summary>
    /// <para>Returns the next bits from the file as a floating-point number. This advances the file cursor by either 4 or 8 bytes, depending on the precision used by the Godot build that saved the file.</para>
    /// <para>If the file was saved by a Godot build compiled with the <c>precision=single</c> option (the default), the number of read bits for that file is 32. Otherwise, if compiled with the <c>precision=double</c> option, the number of read bits is 64.</para>
    /// </summary>
    public float GetReal()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBuffer, 4131300905ul);

    /// <summary>
    /// <para>Returns next <paramref name="length"/> bytes of the file as a <see cref="byte"/>[]. This advances the file cursor by <paramref name="length"/> bytes.</para>
    /// </summary>
    public byte[] GetBuffer(long length)
    {
        return NativeCalls.godot_icall_1_563(MethodBind26, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLine, 201670096ul);

    /// <summary>
    /// <para>Returns the next line of the file as a <see cref="string"/>. The returned string doesn't include newline (<c>\n</c>) or carriage return (<c>\r</c>) characters, but does include any other leading or trailing whitespace. This advances the file cursor to after the newline character at the end of the line.</para>
    /// <para>Text is interpreted as being UTF-8 encoded.</para>
    /// </summary>
    public string GetLine()
    {
        return NativeCalls.godot_icall_0_58(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCsvLine, 2358116058ul);

    /// <summary>
    /// <para>Returns the next value of the file in CSV (Comma-Separated Values) format. You can pass a different delimiter <paramref name="delim"/> to use other than the default <c>","</c> (comma). This delimiter must be one-character long, and cannot be a double quotation mark.</para>
    /// <para>Text is interpreted as being UTF-8 encoded. Text values must be enclosed in double quotes if they include the delimiter character. Double quotes within a text value can be escaped by doubling their occurrence. This advances the file cursor to after the newline character at the end of the line.</para>
    /// <para>For example, the following CSV lines are valid and will be properly parsed as two strings each:</para>
    /// <para><code>
    /// Alice,"Hello, Bob!"
    /// Bob,Alice! What a surprise!
    /// Alice,"I thought you'd reply with ""Hello, world""."
    /// </code></para>
    /// <para>Note how the second line can omit the enclosing quotes as it does not include the delimiter. However it <i>could</i> very well use quotes, it was only written without for demonstration purposes. The third line must use <c>""</c> for each quotation mark that needs to be interpreted as such instead of the end of a text value.</para>
    /// </summary>
    public string[] GetCsvLine(string delim = ",")
    {
        return NativeCalls.godot_icall_1_328(MethodBind28, GodotObject.GetPtr(this), delim);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAsText, 201670096ul);

    /// <summary>
    /// <para>Returns the whole file as a <see cref="string"/>. Text is interpreted as being UTF-8 encoded. This ignores the file cursor and does not affect it.</para>
    /// </summary>
    public string GetAsText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMd5, 1703090593ul);

    /// <summary>
    /// <para>Returns an MD5 String representing the file at the given path or an empty <see cref="string"/> on failure.</para>
    /// </summary>
    public static string GetMd5(string path)
    {
        return NativeCalls.godot_icall_1_561(MethodBind30, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSha256, 1703090593ul);

    /// <summary>
    /// <para>Returns an SHA-256 <see cref="string"/> representing the file at the given path or an empty <see cref="string"/> on failure.</para>
    /// </summary>
    public static string GetSha256(string path)
    {
        return NativeCalls.godot_icall_1_561(MethodBind31, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBigEndian, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsBigEndian()
    {
        return NativeCalls.godot_icall_0_15(MethodBind32, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBigEndian, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBigEndian(bool bigEndian)
    {
        NativeCalls.godot_icall_1_14(MethodBind33, GodotObject.GetPtr(this), bigEndian.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetError, 3185525595ul);

    /// <summary>
    /// <para>Returns the last error that happened when trying to perform operations. Compare with the <c>ERR_FILE_*</c> constants from <see cref="Godot.Error"/>.</para>
    /// </summary>
    public Error GetError()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVar, 189129690ul);

    /// <summary>
    /// <para>Returns the next <see cref="Godot.Variant"/> value from the file. If <paramref name="allowObjects"/> is <see langword="true"/>, decoding objects is allowed. This advances the file cursor by the number of bytes read.</para>
    /// <para>Internally, this uses the same decoding mechanism as the <c>@GlobalScope.bytes_to_var</c> method, as described in the <a href="$DOCS_URL/tutorials/io/binary_serialization_api.html">Binary serialization API</a> documentation.</para>
    /// <para><b>Warning:</b> Deserialized objects can contain code which gets executed. Do not use this option if the serialized object comes from untrusted sources to avoid potential security threats such as remote code execution.</para>
    /// </summary>
    public Variant GetVar(bool allowObjects = false)
    {
        return NativeCalls.godot_icall_1_564(MethodBind35, GodotObject.GetPtr(this), allowObjects.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Store8, 3067735520ul);

    /// <summary>
    /// <para>Stores an integer as 8 bits in the file. This advances the file cursor by 1 byte. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> The <paramref name="value"/> should lie in the interval <c>[0, 255]</c>. Any other value will overflow and wrap around.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// <para>To store a signed integer, use <see cref="Godot.FileAccess.Store64(ulong)"/>, or convert it manually (see <see cref="Godot.FileAccess.Store16(ushort)"/> for an example).</para>
    /// </summary>
    public bool Store8(byte value)
    {
        return NativeCalls.godot_icall_1_565(MethodBind36, GodotObject.GetPtr(this), value).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Store16, 3067735520ul);

    /// <summary>
    /// <para>Stores an integer as 16 bits in the file. This advances the file cursor by 2 bytes. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> The <paramref name="value"/> should lie in the interval <c>[0, 2^16 - 1]</c>. Any other value will overflow and wrap around.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// <para>To store a signed integer, use <see cref="Godot.FileAccess.Store64(ulong)"/> or store a signed integer from the interval <c>[-2^15, 2^15 - 1]</c> (i.e. keeping one bit for the signedness) and compute its sign manually when reading. For example:</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	using var f = FileAccess.Open("user://file.dat", FileAccess.ModeFlags.WriteRead);
    /// 	f.Store16(unchecked((ushort)-42)); // This wraps around and stores 65494 (2^16 - 42).
    /// 	f.Store16(121); // In bounds, will store 121.
    /// 	f.Seek(0); // Go back to start to read the stored value.
    /// 	ushort read1 = f.Get16(); // 65494
    /// 	ushort read2 = f.Get16(); // 121
    /// 	short converted1 = (short)read1; // -42
    /// 	short converted2 = (short)read2; // 121
    /// }
    /// </code></para>
    /// </summary>
    public bool Store16(ushort value)
    {
        return NativeCalls.godot_icall_1_566(MethodBind37, GodotObject.GetPtr(this), value).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Store32, 3067735520ul);

    /// <summary>
    /// <para>Stores an integer as 32 bits in the file. This advances the file cursor by 4 bytes. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> The <paramref name="value"/> should lie in the interval <c>[0, 2^32 - 1]</c>. Any other value will overflow and wrap around.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// <para>To store a signed integer, use <see cref="Godot.FileAccess.Store64(ulong)"/>, or convert it manually (see <see cref="Godot.FileAccess.Store16(ushort)"/> for an example).</para>
    /// </summary>
    public bool Store32(uint value)
    {
        return NativeCalls.godot_icall_1_270(MethodBind38, GodotObject.GetPtr(this), value).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Store64, 3067735520ul);

    /// <summary>
    /// <para>Stores an integer as 64 bits in the file. This advances the file cursor by 8 bytes. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> The <paramref name="value"/> must lie in the interval <c>[-2^63, 2^63 - 1]</c> (i.e. be a valid <see cref="int"/> value).</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool Store64(ulong value)
    {
        return NativeCalls.godot_icall_1_567(MethodBind39, GodotObject.GetPtr(this), value).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StoreHalf, 330693286ul);

    /// <summary>
    /// <para>Stores a half-precision floating-point number as 16 bits in the file. This advances the file cursor by 2 bytes. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreHalf(float value)
    {
        return NativeCalls.godot_icall_1_568(MethodBind40, GodotObject.GetPtr(this), value).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StoreFloat, 330693286ul);

    /// <summary>
    /// <para>Stores a floating-point number as 32 bits in the file. This advances the file cursor by 4 bytes. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreFloat(float value)
    {
        return NativeCalls.godot_icall_1_568(MethodBind41, GodotObject.GetPtr(this), value).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StoreDouble, 330693286ul);

    /// <summary>
    /// <para>Stores a floating-point number as 64 bits in the file. This advances the file cursor by 8 bytes. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreDouble(double value)
    {
        return NativeCalls.godot_icall_1_569(MethodBind42, GodotObject.GetPtr(this), value).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StoreReal, 330693286ul);

    /// <summary>
    /// <para>Stores a floating-point number in the file. This advances the file cursor by either 4 or 8 bytes, depending on the precision used by the current Godot build.</para>
    /// <para>If using a Godot build compiled with the <c>precision=single</c> option (the default), this method will save a 32-bit float. Otherwise, if compiled with the <c>precision=double</c> option, this will save a 64-bit float. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreReal(float value)
    {
        return NativeCalls.godot_icall_1_568(MethodBind43, GodotObject.GetPtr(this), value).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StoreBuffer, 114037665ul);

    /// <summary>
    /// <para>Stores the given array of bytes in the file. This advances the file cursor by the number of bytes written. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreBuffer(byte[] buffer)
    {
        return NativeCalls.godot_icall_1_570(MethodBind44, GodotObject.GetPtr(this), buffer).ToBool();
    }

    /// <summary>
    /// <para>Stores the given array of bytes in the file. This advances the file cursor by the number of bytes written. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreBuffer(ReadOnlySpan<byte> buffer)
    {
        return NativeCalls.godot_icall_1_570(MethodBind44, GodotObject.GetPtr(this), buffer).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StoreLine, 2323990056ul);

    /// <summary>
    /// <para>Stores <paramref name="line"/> in the file followed by a newline character (<c>\n</c>), encoding the text as UTF-8. This advances the file cursor by the length of the line, after the newline character. The amount of bytes written depends on the UTF-8 encoded bytes, which may be different from <c>String.length</c> which counts the number of UTF-32 codepoints. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreLine(string line)
    {
        return NativeCalls.godot_icall_1_131(MethodBind45, GodotObject.GetPtr(this), line).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StoreCsvLine, 1611473434ul);

    /// <summary>
    /// <para>Stores the given <see cref="string"/>[] in the file as a line formatted in the CSV (Comma-Separated Values) format. You can pass a different delimiter <paramref name="delim"/> to use other than the default <c>","</c> (comma). This delimiter must be one-character long.</para>
    /// <para>Text will be encoded as UTF-8. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreCsvLine(string[] values, string delim = ",")
    {
        return NativeCalls.godot_icall_2_571(MethodBind46, GodotObject.GetPtr(this), values, delim).ToBool();
    }

    /// <summary>
    /// <para>Stores the given <see cref="string"/>[] in the file as a line formatted in the CSV (Comma-Separated Values) format. You can pass a different delimiter <paramref name="delim"/> to use other than the default <c>","</c> (comma). This delimiter must be one-character long.</para>
    /// <para>Text will be encoded as UTF-8. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreCsvLine(ReadOnlySpan<string> values, string delim)
    {
        return NativeCalls.godot_icall_2_571(MethodBind46, GodotObject.GetPtr(this), values, delim).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StoreString, 2323990056ul);

    /// <summary>
    /// <para>Stores <paramref name="string"/> in the file without a newline character (<c>\n</c>), encoding the text as UTF-8. This advances the file cursor by the length of the string in UTF-8 encoded bytes, which may be different from <c>String.length</c> which counts the number of UTF-32 codepoints. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> This method is intended to be used to write text files. The string is stored as a UTF-8 encoded buffer without string length or terminating zero, which means that it can't be loaded back easily. If you want to store a retrievable string in a binary file, consider using <see cref="Godot.FileAccess.StorePascalString(string)"/> instead. For retrieving strings from a text file, you can use <c>get_buffer(length).get_string_from_utf8()</c> (if you know the length) or <see cref="Godot.FileAccess.GetAsText()"/>.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreString(string @string)
    {
        return NativeCalls.godot_icall_1_131(MethodBind47, GodotObject.GetPtr(this), @string).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StoreVar, 117357437ul);

    /// <summary>
    /// <para>Stores any Variant value in the file. If <paramref name="fullObjects"/> is <see langword="true"/>, encoding objects is allowed (and can potentially include code). This advances the file cursor by the number of bytes written. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para>Internally, this uses the same encoding mechanism as the <c>@GlobalScope.var_to_bytes</c> method, as described in the <a href="$DOCS_URL/tutorials/io/binary_serialization_api.html">Binary serialization API</a> documentation.</para>
    /// <para><b>Note:</b> Not all properties are included. Only properties that are configured with the <see cref="Godot.PropertyUsageFlags.Storage"/> flag set will be serialized. You can add a new usage flag to a property by overriding the <see cref="Godot.GodotObject._GetPropertyList()"/> method in your class. You can also check how property usage is configured by calling <see cref="Godot.GodotObject._GetPropertyList()"/>. See <see cref="Godot.PropertyUsageFlags"/> for the possible usage flags.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StoreVar(Variant value, bool fullObjects = false)
    {
        return NativeCalls.godot_icall_2_572(MethodBind48, GodotObject.GetPtr(this), value, fullObjects.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StorePascalString, 2323990056ul);

    /// <summary>
    /// <para>Stores the given <see cref="string"/> as a line in the file in Pascal format (i.e. also store the length of the string). Text will be encoded as UTF-8. This advances the file cursor by the number of bytes written depending on the UTF-8 encoded bytes, which may be different from <c>String.length</c> which counts the number of UTF-32 codepoints. Returns <see langword="true"/> if the operation is successful.</para>
    /// <para><b>Note:</b> If an error occurs, the resulting value of the file position indicator is indeterminate.</para>
    /// </summary>
    public bool StorePascalString(string @string)
    {
        return NativeCalls.godot_icall_1_131(MethodBind49, GodotObject.GetPtr(this), @string).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPascalString, 2841200299ul);

    /// <summary>
    /// <para>Returns a <see cref="string"/> saved in Pascal format from the file, meaning that the length of the string is explicitly stored at the start. See <see cref="Godot.FileAccess.StorePascalString(string)"/>. This may include newline characters. The file cursor is advanced after the bytes read.</para>
    /// <para>Text is interpreted as being UTF-8 encoded.</para>
    /// </summary>
    public string GetPascalString()
    {
        return NativeCalls.godot_icall_0_58(MethodBind50, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Close, 3218959716ul);

    /// <summary>
    /// <para>Closes the currently opened file and prevents subsequent read/write operations. Use <see cref="Godot.FileAccess.Flush()"/> to persist the data to disk without closing the file.</para>
    /// <para><b>Note:</b> <see cref="Godot.FileAccess"/> will automatically close when it's freed, which happens when it goes out of scope or when it gets assigned with <see langword="null"/>. In C# the reference must be disposed after we are done using it, this can be done with the <c>using</c> statement or calling the <c>Dispose</c> method directly.</para>
    /// </summary>
    public void Close()
    {
        NativeCalls.godot_icall_0_3(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FileExists, 2323990056ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the file exists in the given path.</para>
    /// <para><b>Note:</b> Many resources types are imported (e.g. textures or sound files), and their source asset will not be included in the exported game, as only the imported version is used. See <see cref="Godot.ResourceLoader.Exists(string, string)"/> for an alternative approach that takes resource remapping into account.</para>
    /// <para>For a non-static, relative equivalent, use <see cref="Godot.DirAccess.FileExists(string)"/>.</para>
    /// </summary>
    public static bool FileExists(string path)
    {
        return NativeCalls.godot_icall_1_377(MethodBind52, path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModifiedTime, 1597066294ul);

    /// <summary>
    /// <para>Returns the last time the <paramref name="file"/> was modified in Unix timestamp format, or <c>0</c> on error. This Unix timestamp can be converted to another format using the <see cref="Godot.Time"/> singleton.</para>
    /// </summary>
    public static ulong GetModifiedTime(string file)
    {
        return NativeCalls.godot_icall_1_573(MethodBind53, file);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessTime, 1597066294ul);

    /// <summary>
    /// <para>Returns the last time the <paramref name="file"/> was accessed in Unix timestamp format, or <c>0</c> on error. This Unix timestamp can be converted to another format using the <see cref="Godot.Time"/> singleton.</para>
    /// </summary>
    public static ulong GetAccessTime(string file)
    {
        return NativeCalls.godot_icall_1_573(MethodBind54, file);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 1597066294ul);

    /// <summary>
    /// <para>Returns the size of the file at the given path, in bytes, or <c>-1</c> on error.</para>
    /// </summary>
    public static long GetSize(string file)
    {
        return NativeCalls.godot_icall_1_574(MethodBind55, file);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUnixPermissions, 524341837ul);

    /// <summary>
    /// <para>Returns the UNIX permissions of the file at the given path.</para>
    /// <para><b>Note:</b> This method is implemented on iOS, Linux/BSD, and macOS.</para>
    /// </summary>
    public static FileAccess.UnixPermissionFlags GetUnixPermissions(string file)
    {
        return (FileAccess.UnixPermissionFlags)NativeCalls.godot_icall_1_376(MethodBind56, file);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUnixPermissions, 846038644ul);

    /// <summary>
    /// <para>Sets file UNIX permissions.</para>
    /// <para><b>Note:</b> This method is implemented on iOS, Linux/BSD, and macOS.</para>
    /// </summary>
    public static Error SetUnixPermissions(string file, FileAccess.UnixPermissionFlags permissions)
    {
        return (Error)NativeCalls.godot_icall_2_575(MethodBind57, file, (int)permissions);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHiddenAttribute, 2323990056ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <b>hidden</b> attribute is set on the file at the given path.</para>
    /// <para><b>Note:</b> This method is implemented on iOS, BSD, macOS, and Windows.</para>
    /// </summary>
    public static bool GetHiddenAttribute(string file)
    {
        return NativeCalls.godot_icall_1_377(MethodBind58, file).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHiddenAttribute, 2892558115ul);

    /// <summary>
    /// <para>Sets file <b>hidden</b> attribute.</para>
    /// <para><b>Note:</b> This method is implemented on iOS, BSD, macOS, and Windows.</para>
    /// </summary>
    public static Error SetHiddenAttribute(string file, bool hidden)
    {
        return (Error)NativeCalls.godot_icall_2_576(MethodBind59, file, hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReadOnlyAttribute, 2892558115ul);

    /// <summary>
    /// <para>Sets file <b>read only</b> attribute.</para>
    /// <para><b>Note:</b> This method is implemented on iOS, BSD, macOS, and Windows.</para>
    /// </summary>
    public static Error SetReadOnlyAttribute(string file, bool ro)
    {
        return (Error)NativeCalls.godot_icall_2_576(MethodBind60, file, ro.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReadOnlyAttribute, 2323990056ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <b>read only</b> attribute is set on the file at the given path.</para>
    /// <para><b>Note:</b> This method is implemented on iOS, BSD, macOS, and Windows.</para>
    /// </summary>
    public static bool GetReadOnlyAttribute(string file)
    {
        return NativeCalls.godot_icall_1_377(MethodBind61, file).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExtendedAttribute, 955893464ul);

    /// <summary>
    /// <para>Reads the file extended attribute with name <paramref name="attributeName"/> as a byte array.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> Extended attributes support depends on the file system. Attributes will be lost when the file is moved between incompatible file systems.</para>
    /// <para><b>Note:</b> On Linux, only "user" namespace attributes are accessible, namespace prefix should not be included.</para>
    /// <para><b>Note:</b> On Windows, alternate data streams are used to store extended attributes.</para>
    /// </summary>
    public static byte[] GetExtendedAttribute(string file, string attributeName)
    {
        return NativeCalls.godot_icall_2_577(MethodBind62, file, attributeName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExtendedAttributeString, 1218461987ul);

    /// <summary>
    /// <para>Reads the file extended attribute with name <paramref name="attributeName"/> as a UTF-8 encoded string.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> Extended attributes support depends on the file system. Attributes will be lost when the file is moved between incompatible file systems.</para>
    /// <para><b>Note:</b> On Linux, only "user" namespace attributes are accessible, namespace prefix should not be included.</para>
    /// <para><b>Note:</b> On Windows, alternate data streams are used to store extended attributes.</para>
    /// </summary>
    public static string GetExtendedAttributeString(string file, string attributeName)
    {
        return NativeCalls.godot_icall_2_578(MethodBind63, file, attributeName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExtendedAttribute, 2643421469ul);

    /// <summary>
    /// <para>Writes file extended attribute with name <paramref name="attributeName"/> as a byte array.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> Extended attributes support depends on the file system. Attributes will be lost when the file is moved between incompatible file systems.</para>
    /// <para><b>Note:</b> On Linux, only "user" namespace attributes are accessible, namespace prefix should not be included.</para>
    /// <para><b>Note:</b> On Windows, alternate data streams are used to store extended attributes.</para>
    /// </summary>
    public static Error SetExtendedAttribute(string file, string attributeName, byte[] data)
    {
        return (Error)NativeCalls.godot_icall_3_579(MethodBind64, file, attributeName, data);
    }

    /// <summary>
    /// <para>Writes file extended attribute with name <paramref name="attributeName"/> as a byte array.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> Extended attributes support depends on the file system. Attributes will be lost when the file is moved between incompatible file systems.</para>
    /// <para><b>Note:</b> On Linux, only "user" namespace attributes are accessible, namespace prefix should not be included.</para>
    /// <para><b>Note:</b> On Windows, alternate data streams are used to store extended attributes.</para>
    /// </summary>
    public static Error SetExtendedAttribute(string file, string attributeName, ReadOnlySpan<byte> data)
    {
        return (Error)NativeCalls.godot_icall_3_579(MethodBind64, file, attributeName, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExtendedAttributeString, 699024349ul);

    /// <summary>
    /// <para>Writes file extended attribute with name <paramref name="attributeName"/> as a UTF-8 encoded string.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> Extended attributes support depends on the file system. Attributes will be lost when the file is moved between incompatible file systems.</para>
    /// <para><b>Note:</b> On Linux, only "user" namespace attributes are accessible, namespace prefix should not be included.</para>
    /// <para><b>Note:</b> On Windows, alternate data streams are used to store extended attributes.</para>
    /// </summary>
    public static Error SetExtendedAttributeString(string file, string attributeName, string data)
    {
        return (Error)NativeCalls.godot_icall_3_580(MethodBind65, file, attributeName, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveExtendedAttribute, 852856452ul);

    /// <summary>
    /// <para>Removes file extended attribute with name <paramref name="attributeName"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> Extended attributes support depends on the file system. Attributes will be lost when the file is moved between incompatible file systems.</para>
    /// <para><b>Note:</b> On Linux, only "user" namespace attributes are accessible, namespace prefix should not be included.</para>
    /// <para><b>Note:</b> On Windows, alternate data streams are used to store extended attributes.</para>
    /// </summary>
    public static Error RemoveExtendedAttribute(string file, string attributeName)
    {
        return (Error)NativeCalls.godot_icall_2_380(MethodBind66, file, attributeName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExtendedAttributesList, 3538744774ul);

    /// <summary>
    /// <para>Returns a list of file extended attributes.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> Extended attributes support depends on the file system. Attributes will be lost when the file is moved between incompatible file systems.</para>
    /// <para><b>Note:</b> On Linux, only "user" namespace attributes are accessible, namespace prefix should not be included.</para>
    /// <para><b>Note:</b> On Windows, alternate data streams are used to store extended attributes.</para>
    /// </summary>
    public static string[] GetExtendedAttributesList(string file)
    {
        return NativeCalls.godot_icall_1_374(MethodBind67, file);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAsText, 1162154673ul);

    /// <summary>
    /// <para>Returns the whole file as a <see cref="string"/>. Text is interpreted as being UTF-8 encoded. This ignores the file cursor and does not affect it.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetAsText(bool skipCr)
    {
        return NativeCalls.godot_icall_1_351(MethodBind68, GodotObject.GetPtr(this), skipCr.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTemp, 3075606245ul);

    /// <summary>
    /// <para>Creates a temporary file. This file will be freed when the returned <see cref="Godot.FileAccess"/> is freed.</para>
    /// <para>If <paramref name="prefix"/> is not empty, it will be prefixed to the file name, separated by a <c>-</c>.</para>
    /// <para>If <paramref name="extension"/> is not empty, it will be appended to the temporary file name.</para>
    /// <para>If <paramref name="keep"/> is <see langword="true"/>, the file is not deleted when the returned <see cref="Godot.FileAccess"/> is freed.</para>
    /// <para>Returns <see langword="null"/> if opening the file failed. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static FileAccess CreateTemp(int modeFlags, string prefix, string extension, bool keep)
    {
        return (FileAccess)NativeCalls.godot_icall_4_559(MethodBind69, modeFlags, prefix, extension, keep.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenEncrypted, 1482131466ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.FileAccess"/> object and opens an encrypted file in write or read mode. You need to pass a binary key to encrypt/decrypt it.</para>
    /// <para><b>Note:</b> The provided key must be 32 bytes long.</para>
    /// <para>Returns <see langword="null"/> if opening the file failed. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static FileAccess OpenEncrypted(string path, FileAccess.ModeFlags modeFlags, byte[] key)
    {
        return (FileAccess)NativeCalls.godot_icall_3_581(MethodBind70, path, (int)modeFlags, key);
    }

    /// <summary>
    /// <para>Creates a new <see cref="Godot.FileAccess"/> object and opens an encrypted file in write or read mode. You need to pass a binary key to encrypt/decrypt it.</para>
    /// <para><b>Note:</b> The provided key must be 32 bytes long.</para>
    /// <para>Returns <see langword="null"/> if opening the file failed. You can use <see cref="Godot.FileAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static FileAccess OpenEncrypted(string path, FileAccess.ModeFlags modeFlags, ReadOnlySpan<byte> key)
    {
        return (FileAccess)NativeCalls.godot_icall_3_581(MethodBind70, path, (int)modeFlags, key);
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
        /// Cached name for the 'big_endian' property.
        /// </summary>
        public static readonly StringName BigEndian = "big_endian";
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
        /// Cached name for the 'open_encrypted' method.
        /// </summary>
        public static readonly StringName OpenEncrypted = "open_encrypted";
        /// <summary>
        /// Cached name for the 'open_encrypted_with_pass' method.
        /// </summary>
        public static readonly StringName OpenEncryptedWithPass = "open_encrypted_with_pass";
        /// <summary>
        /// Cached name for the 'open_compressed' method.
        /// </summary>
        public static readonly StringName OpenCompressed = "open_compressed";
        /// <summary>
        /// Cached name for the 'get_open_error' method.
        /// </summary>
        public static readonly StringName GetOpenError = "get_open_error";
        /// <summary>
        /// Cached name for the 'create_temp' method.
        /// </summary>
        public static readonly StringName CreateTemp = "create_temp";
        /// <summary>
        /// Cached name for the 'get_file_as_bytes' method.
        /// </summary>
        public static readonly StringName GetFileAsBytes = "get_file_as_bytes";
        /// <summary>
        /// Cached name for the 'get_file_as_string' method.
        /// </summary>
        public static readonly StringName GetFileAsString = "get_file_as_string";
        /// <summary>
        /// Cached name for the 'resize' method.
        /// </summary>
        public static readonly StringName Resize = "resize";
        /// <summary>
        /// Cached name for the 'flush' method.
        /// </summary>
        public static readonly StringName Flush = "flush";
        /// <summary>
        /// Cached name for the 'get_path' method.
        /// </summary>
        public static readonly StringName GetPath = "get_path";
        /// <summary>
        /// Cached name for the 'get_path_absolute' method.
        /// </summary>
        public static readonly StringName GetPathAbsolute = "get_path_absolute";
        /// <summary>
        /// Cached name for the 'is_open' method.
        /// </summary>
        public static readonly StringName IsOpen = "is_open";
        /// <summary>
        /// Cached name for the 'seek' method.
        /// </summary>
        public static readonly StringName Seek = "seek";
        /// <summary>
        /// Cached name for the 'seek_end' method.
        /// </summary>
        public static readonly StringName SeekEnd = "seek_end";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'get_length' method.
        /// </summary>
        public static readonly StringName GetLength = "get_length";
        /// <summary>
        /// Cached name for the 'eof_reached' method.
        /// </summary>
        public static readonly StringName EofReached = "eof_reached";
        /// <summary>
        /// Cached name for the 'get_8' method.
        /// </summary>
        public static readonly StringName Get8 = "get_8";
        /// <summary>
        /// Cached name for the 'get_16' method.
        /// </summary>
        public static readonly StringName Get16 = "get_16";
        /// <summary>
        /// Cached name for the 'get_32' method.
        /// </summary>
        public static readonly StringName Get32 = "get_32";
        /// <summary>
        /// Cached name for the 'get_64' method.
        /// </summary>
        public static readonly StringName Get64 = "get_64";
        /// <summary>
        /// Cached name for the 'get_half' method.
        /// </summary>
        public static readonly StringName GetHalf = "get_half";
        /// <summary>
        /// Cached name for the 'get_float' method.
        /// </summary>
        public static readonly StringName GetFloat = "get_float";
        /// <summary>
        /// Cached name for the 'get_double' method.
        /// </summary>
        public static readonly StringName GetDouble = "get_double";
        /// <summary>
        /// Cached name for the 'get_real' method.
        /// </summary>
        public static readonly StringName GetReal = "get_real";
        /// <summary>
        /// Cached name for the 'get_buffer' method.
        /// </summary>
        public static readonly StringName GetBuffer = "get_buffer";
        /// <summary>
        /// Cached name for the 'get_line' method.
        /// </summary>
        public static readonly StringName GetLine = "get_line";
        /// <summary>
        /// Cached name for the 'get_csv_line' method.
        /// </summary>
        public static readonly StringName GetCsvLine = "get_csv_line";
        /// <summary>
        /// Cached name for the 'get_as_text' method.
        /// </summary>
        public static readonly StringName GetAsText = "get_as_text";
        /// <summary>
        /// Cached name for the 'get_md5' method.
        /// </summary>
        public static readonly StringName GetMd5 = "get_md5";
        /// <summary>
        /// Cached name for the 'get_sha256' method.
        /// </summary>
        public static readonly StringName GetSha256 = "get_sha256";
        /// <summary>
        /// Cached name for the 'is_big_endian' method.
        /// </summary>
        public static readonly StringName IsBigEndian = "is_big_endian";
        /// <summary>
        /// Cached name for the 'set_big_endian' method.
        /// </summary>
        public static readonly StringName SetBigEndian = "set_big_endian";
        /// <summary>
        /// Cached name for the 'get_error' method.
        /// </summary>
        public static readonly StringName GetError = "get_error";
        /// <summary>
        /// Cached name for the 'get_var' method.
        /// </summary>
        public static readonly StringName GetVar = "get_var";
        /// <summary>
        /// Cached name for the 'store_8' method.
        /// </summary>
        public static readonly StringName Store8 = "store_8";
        /// <summary>
        /// Cached name for the 'store_16' method.
        /// </summary>
        public static readonly StringName Store16 = "store_16";
        /// <summary>
        /// Cached name for the 'store_32' method.
        /// </summary>
        public static readonly StringName Store32 = "store_32";
        /// <summary>
        /// Cached name for the 'store_64' method.
        /// </summary>
        public static readonly StringName Store64 = "store_64";
        /// <summary>
        /// Cached name for the 'store_half' method.
        /// </summary>
        public static readonly StringName StoreHalf = "store_half";
        /// <summary>
        /// Cached name for the 'store_float' method.
        /// </summary>
        public static readonly StringName StoreFloat = "store_float";
        /// <summary>
        /// Cached name for the 'store_double' method.
        /// </summary>
        public static readonly StringName StoreDouble = "store_double";
        /// <summary>
        /// Cached name for the 'store_real' method.
        /// </summary>
        public static readonly StringName StoreReal = "store_real";
        /// <summary>
        /// Cached name for the 'store_buffer' method.
        /// </summary>
        public static readonly StringName StoreBuffer = "store_buffer";
        /// <summary>
        /// Cached name for the 'store_line' method.
        /// </summary>
        public static readonly StringName StoreLine = "store_line";
        /// <summary>
        /// Cached name for the 'store_csv_line' method.
        /// </summary>
        public static readonly StringName StoreCsvLine = "store_csv_line";
        /// <summary>
        /// Cached name for the 'store_string' method.
        /// </summary>
        public static readonly StringName StoreString = "store_string";
        /// <summary>
        /// Cached name for the 'store_var' method.
        /// </summary>
        public static readonly StringName StoreVar = "store_var";
        /// <summary>
        /// Cached name for the 'store_pascal_string' method.
        /// </summary>
        public static readonly StringName StorePascalString = "store_pascal_string";
        /// <summary>
        /// Cached name for the 'get_pascal_string' method.
        /// </summary>
        public static readonly StringName GetPascalString = "get_pascal_string";
        /// <summary>
        /// Cached name for the 'close' method.
        /// </summary>
        public static readonly StringName Close = "close";
        /// <summary>
        /// Cached name for the 'file_exists' method.
        /// </summary>
        public static readonly StringName FileExists = "file_exists";
        /// <summary>
        /// Cached name for the 'get_modified_time' method.
        /// </summary>
        public static readonly StringName GetModifiedTime = "get_modified_time";
        /// <summary>
        /// Cached name for the 'get_access_time' method.
        /// </summary>
        public static readonly StringName GetAccessTime = "get_access_time";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'get_unix_permissions' method.
        /// </summary>
        public static readonly StringName GetUnixPermissions = "get_unix_permissions";
        /// <summary>
        /// Cached name for the 'set_unix_permissions' method.
        /// </summary>
        public static readonly StringName SetUnixPermissions = "set_unix_permissions";
        /// <summary>
        /// Cached name for the 'get_hidden_attribute' method.
        /// </summary>
        public static readonly StringName GetHiddenAttribute = "get_hidden_attribute";
        /// <summary>
        /// Cached name for the 'set_hidden_attribute' method.
        /// </summary>
        public static readonly StringName SetHiddenAttribute = "set_hidden_attribute";
        /// <summary>
        /// Cached name for the 'set_read_only_attribute' method.
        /// </summary>
        public static readonly StringName SetReadOnlyAttribute = "set_read_only_attribute";
        /// <summary>
        /// Cached name for the 'get_read_only_attribute' method.
        /// </summary>
        public static readonly StringName GetReadOnlyAttribute = "get_read_only_attribute";
        /// <summary>
        /// Cached name for the 'get_extended_attribute' method.
        /// </summary>
        public static readonly StringName GetExtendedAttribute = "get_extended_attribute";
        /// <summary>
        /// Cached name for the 'get_extended_attribute_string' method.
        /// </summary>
        public static readonly StringName GetExtendedAttributeString = "get_extended_attribute_string";
        /// <summary>
        /// Cached name for the 'set_extended_attribute' method.
        /// </summary>
        public static readonly StringName SetExtendedAttribute = "set_extended_attribute";
        /// <summary>
        /// Cached name for the 'set_extended_attribute_string' method.
        /// </summary>
        public static readonly StringName SetExtendedAttributeString = "set_extended_attribute_string";
        /// <summary>
        /// Cached name for the 'remove_extended_attribute' method.
        /// </summary>
        public static readonly StringName RemoveExtendedAttribute = "remove_extended_attribute";
        /// <summary>
        /// Cached name for the 'get_extended_attributes_list' method.
        /// </summary>
        public static readonly StringName GetExtendedAttributesList = "get_extended_attributes_list";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
