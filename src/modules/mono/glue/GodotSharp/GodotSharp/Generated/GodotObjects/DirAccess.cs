namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is used to manage directories and their content, even outside of the project folder.</para>
/// <para><see cref="Godot.DirAccess"/> can't be instantiated directly. Instead it is created with a static method that takes a path for which it will be opened.</para>
/// <para>Most of the methods have a static alternative that can be used without creating a <see cref="Godot.DirAccess"/>. Static methods only support absolute paths (including <c>res://</c> and <c>user://</c>).</para>
/// <para><code>
/// # Standard
/// var dir = DirAccess.open("user://levels")
/// dir.make_dir("world1")
/// # Static
/// DirAccess.make_dir_absolute("user://levels/world1")
/// </code></para>
/// <para><b>Note:</b> Accessing project ("res://") directories once exported may behave unexpectedly as some files are converted to engine-specific formats and their original source files may not be present in the expected PCK package. Because of this, to access resources in an exported project, it is recommended to use <see cref="Godot.ResourceLoader"/> instead of <see cref="Godot.FileAccess"/>.</para>
/// <para>Here is an example on how to iterate through the files of a directory:</para>
/// <para><code>
/// public void DirContents(string path)
/// {
/// 	using var dir = DirAccess.Open(path);
/// 	if (dir != null)
/// 	{
/// 		dir.ListDirBegin();
/// 		string fileName = dir.GetNext();
/// 		while (fileName != "")
/// 		{
/// 			if (dir.CurrentIsDir())
/// 			{
/// 				GD.Print($"Found directory: {fileName}");
/// 			}
/// 			else
/// 			{
/// 				GD.Print($"Found file: {fileName}");
/// 			}
/// 			fileName = dir.GetNext();
/// 		}
/// 	}
/// 	else
/// 	{
/// 		GD.Print("An error occurred when trying to access the path.");
/// 	}
/// }
/// </code></para>
/// <para>Keep in mind that file names may change or be remapped after export. If you want to see the actual resource file list as it appears in the editor, use <see cref="Godot.ResourceLoader.ListDirectory(string)"/> instead.</para>
/// </summary>
public partial class DirAccess : RefCounted
{
    /// <summary>
    /// <para>If <see langword="true"/>, <c>.</c> and <c>..</c> are included when navigating the directory.</para>
    /// <para>Affects <see cref="Godot.DirAccess.ListDirBegin()"/> and <see cref="Godot.DirAccess.GetDirectories()"/>.</para>
    /// </summary>
    public bool IncludeNavigational
    {
        get
        {
            return GetIncludeNavigational();
        }
        set
        {
            SetIncludeNavigational(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, hidden files are included when navigating the directory.</para>
    /// <para>Affects <see cref="Godot.DirAccess.ListDirBegin()"/>, <see cref="Godot.DirAccess.GetDirectories()"/> and <see cref="Godot.DirAccess.GetFiles()"/>.</para>
    /// </summary>
    public bool IncludeHidden
    {
        get
        {
            return GetIncludeHidden();
        }
        set
        {
            SetIncludeHidden(value);
        }
    }

    private static readonly System.Type CachedType = typeof(DirAccess);

    private static readonly StringName NativeName = "DirAccess";

    internal DirAccess() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal DirAccess(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal DirAccess(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Open, 1923528528ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.DirAccess"/> object and opens an existing directory of the filesystem. The <paramref name="path"/> argument can be within the project tree (<c>res://folder</c>), the user directory (<c>user://folder</c>) or an absolute path of the user filesystem (e.g. <c>/tmp/folder</c> or <c>C:\tmp\folder</c>).</para>
    /// <para>Returns <see langword="null"/> if opening the directory failed. You can use <see cref="Godot.DirAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    public static DirAccess Open(string path)
    {
        return (DirAccess)NativeCalls.godot_icall_1_203(MethodBind0, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpenError, 166280745ul);

    /// <summary>
    /// <para>Returns the result of the last <see cref="Godot.DirAccess.Open(string)"/> call in the current thread.</para>
    /// </summary>
    public static Error GetOpenError()
    {
        return (Error)NativeCalls.godot_icall_0_372(MethodBind1);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTemp, 812913566ul);

    /// <summary>
    /// <para>Creates a temporary directory. This directory will be freed when the returned <see cref="Godot.DirAccess"/> is freed.</para>
    /// <para>If <paramref name="prefix"/> is not empty, it will be prefixed to the directory name, separated by a <c>-</c>.</para>
    /// <para>If <paramref name="keep"/> is <see langword="true"/>, the directory is not deleted when the returned <see cref="Godot.DirAccess"/> is freed.</para>
    /// <para>Returns <see langword="null"/> if opening the directory failed. You can use <see cref="Godot.DirAccess.GetOpenError()"/> to check the error that occurred.</para>
    /// </summary>
    public static DirAccess CreateTemp(string prefix = "", bool keep = false)
    {
        return (DirAccess)NativeCalls.godot_icall_2_373(MethodBind2, prefix, keep.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ListDirBegin, 166280745ul);

    /// <summary>
    /// <para>Initializes the stream used to list all files and directories using the <see cref="Godot.DirAccess.GetNext()"/> function, closing the currently opened stream if needed. Once the stream has been processed, it should typically be closed with <see cref="Godot.DirAccess.ListDirEnd()"/>.</para>
    /// <para>Affected by <see cref="Godot.DirAccess.IncludeHidden"/> and <see cref="Godot.DirAccess.IncludeNavigational"/>.</para>
    /// <para><b>Note:</b> The order of files and directories returned by this method is not deterministic, and can vary between operating systems. If you want a list of all files or folders sorted alphabetically, use <see cref="Godot.DirAccess.GetFiles()"/> or <see cref="Godot.DirAccess.GetDirectories()"/>.</para>
    /// </summary>
    public Error ListDirBegin()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNext, 2841200299ul);

    /// <summary>
    /// <para>Returns the next element (file or directory) in the current directory.</para>
    /// <para>The name of the file or directory is returned (and not its full path). Once the stream has been fully processed, the method returns an empty <see cref="string"/> and closes the stream automatically (i.e. <see cref="Godot.DirAccess.ListDirEnd()"/> would not be mandatory in such a case).</para>
    /// </summary>
    public string GetNext()
    {
        return NativeCalls.godot_icall_0_58(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CurrentIsDir, 36873697ul);

    /// <summary>
    /// <para>Returns whether the current item processed with the last <see cref="Godot.DirAccess.GetNext()"/> call is a directory (<c>.</c> and <c>..</c> are considered directories).</para>
    /// </summary>
    public bool CurrentIsDir()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ListDirEnd, 3218959716ul);

    /// <summary>
    /// <para>Closes the current stream opened with <see cref="Godot.DirAccess.ListDirBegin()"/> (whether it has been fully processed with <see cref="Godot.DirAccess.GetNext()"/> does not matter).</para>
    /// </summary>
    public void ListDirEnd()
    {
        NativeCalls.godot_icall_0_3(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFiles, 2981934095ul);

    /// <summary>
    /// <para>Returns a <see cref="string"/>[] containing filenames of the directory contents, excluding directories. The array is sorted alphabetically.</para>
    /// <para>Affected by <see cref="Godot.DirAccess.IncludeHidden"/>.</para>
    /// <para><b>Note:</b> When used on a <c>res://</c> path in an exported project, only the files actually included in the PCK at the given folder level are returned. In practice, this means that since imported resources are stored in a top-level <c>.godot/</c> folder, only paths to <c>*.gd</c> and <c>*.import</c> files are returned (plus a few files such as <c>project.godot</c> or <c>project.binary</c> and the project icon). In an exported project, the list of returned files will also vary depending on whether <c>ProjectSettings.editor/export/convert_text_resources_to_binary</c> is <see langword="true"/>.</para>
    /// </summary>
    public string[] GetFiles()
    {
        return NativeCalls.godot_icall_0_108(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilesAt, 3538744774ul);

    /// <summary>
    /// <para>Returns a <see cref="string"/>[] containing filenames of the directory contents, excluding directories, at the given <paramref name="path"/>. The array is sorted alphabetically.</para>
    /// <para>Use <see cref="Godot.DirAccess.GetFiles()"/> if you want more control of what gets included.</para>
    /// <para><b>Note:</b> When used on a <c>res://</c> path in an exported project, only the files included in the PCK at the given folder level are returned. In practice, this means that since imported resources are stored in a top-level <c>.godot/</c> folder, only paths to <c>.gd</c> and <c>.import</c> files are returned (plus a few other files, such as <c>project.godot</c> or <c>project.binary</c> and the project icon). In an exported project, the list of returned files will also vary depending on <c>ProjectSettings.editor/export/convert_text_resources_to_binary</c>.</para>
    /// </summary>
    public static string[] GetFilesAt(string path)
    {
        return NativeCalls.godot_icall_1_374(MethodBind8, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDirectories, 2981934095ul);

    /// <summary>
    /// <para>Returns a <see cref="string"/>[] containing filenames of the directory contents, excluding files. The array is sorted alphabetically.</para>
    /// <para>Affected by <see cref="Godot.DirAccess.IncludeHidden"/> and <see cref="Godot.DirAccess.IncludeNavigational"/>.</para>
    /// <para><b>Note:</b> The returned directories in the editor and after exporting in the <c>res://</c> directory may differ as some files are converted to engine-specific formats when exported.</para>
    /// </summary>
    public string[] GetDirectories()
    {
        return NativeCalls.godot_icall_0_108(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDirectoriesAt, 3538744774ul);

    /// <summary>
    /// <para>Returns a <see cref="string"/>[] containing filenames of the directory contents, excluding files, at the given <paramref name="path"/>. The array is sorted alphabetically.</para>
    /// <para>Use <see cref="Godot.DirAccess.GetDirectories()"/> if you want more control of what gets included.</para>
    /// <para><b>Note:</b> The returned directories in the editor and after exporting in the <c>res://</c> directory may differ as some files are converted to engine-specific formats when exported.</para>
    /// </summary>
    public static string[] GetDirectoriesAt(string path)
    {
        return NativeCalls.godot_icall_1_374(MethodBind10, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDriveCount, 2455072627ul);

    /// <summary>
    /// <para>On Windows, returns the number of drives (partitions) mounted on the current filesystem.</para>
    /// <para>On macOS and Android, returns the number of mounted volumes.</para>
    /// <para>On Linux, returns the number of mounted volumes and GTK 3 bookmarks.</para>
    /// <para>On other platforms, the method returns 0.</para>
    /// </summary>
    public static int GetDriveCount()
    {
        return NativeCalls.godot_icall_0_372(MethodBind11);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDriveName, 990163283ul);

    /// <summary>
    /// <para>On Windows, returns the name of the drive (partition) passed as an argument (e.g. <c>C:</c>).</para>
    /// <para>On macOS, returns the path to the mounted volume passed as an argument.</para>
    /// <para>On Linux, returns the path to the mounted volume or GTK 3 bookmark passed as an argument.</para>
    /// <para>On Android (API level 30+), returns the path to the mounted volume as an argument.</para>
    /// <para>On other platforms, or if the requested drive does not exist, the method returns an empty String.</para>
    /// </summary>
    public static string GetDriveName(int idx)
    {
        return NativeCalls.godot_icall_1_375(MethodBind12, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentDrive, 2455072627ul);

    /// <summary>
    /// <para>Returns the currently opened directory's drive index. See <see cref="Godot.DirAccess.GetDriveName(int)"/> to convert returned index to the name of the drive.</para>
    /// </summary>
    public int GetCurrentDrive()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ChangeDir, 166001499ul);

    /// <summary>
    /// <para>Changes the currently opened directory to the one passed as an argument. The argument can be relative to the current directory (e.g. <c>newdir</c> or <c>../newdir</c>), or an absolute path (e.g. <c>/tmp/newdir</c> or <c>res://somedir/newdir</c>).</para>
    /// <para>Returns one of the <see cref="Godot.Error"/> code constants (<see cref="Godot.Error.Ok"/> on success).</para>
    /// <para><b>Note:</b> The new directory must be within the same scope, e.g. when you had opened a directory inside <c>res://</c>, you can't change it to <c>user://</c> directory. If you need to open a directory in another access scope, use <see cref="Godot.DirAccess.Open(string)"/> to create a new instance instead.</para>
    /// </summary>
    public Error ChangeDir(string toDir)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind14, GodotObject.GetPtr(this), toDir);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentDir, 1287308131ul);

    /// <summary>
    /// <para>Returns the absolute path to the currently opened directory (e.g. <c>res://folder</c> or <c>C:\tmp\folder</c>).</para>
    /// </summary>
    public string GetCurrentDir(bool includeDrive = true)
    {
        return NativeCalls.godot_icall_1_351(MethodBind15, GodotObject.GetPtr(this), includeDrive.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeDir, 166001499ul);

    /// <summary>
    /// <para>Creates a directory. The argument can be relative to the current directory, or an absolute path. The target directory should be placed in an already existing directory (to create the full path recursively, see <see cref="Godot.DirAccess.MakeDirRecursive(string)"/>).</para>
    /// <para>Returns one of the <see cref="Godot.Error"/> code constants (<see cref="Godot.Error.Ok"/> on success).</para>
    /// </summary>
    public Error MakeDir(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind16, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeDirAbsolute, 166001499ul);

    /// <summary>
    /// <para>Static version of <see cref="Godot.DirAccess.MakeDir(string)"/>. Supports only absolute paths.</para>
    /// </summary>
    public static Error MakeDirAbsolute(string path)
    {
        return (Error)NativeCalls.godot_icall_1_376(MethodBind17, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeDirRecursive, 166001499ul);

    /// <summary>
    /// <para>Creates a target directory and all necessary intermediate directories in its path, by calling <see cref="Godot.DirAccess.MakeDir(string)"/> recursively. The argument can be relative to the current directory, or an absolute path.</para>
    /// <para>Returns one of the <see cref="Godot.Error"/> code constants (<see cref="Godot.Error.Ok"/> on success).</para>
    /// </summary>
    public Error MakeDirRecursive(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind18, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeDirRecursiveAbsolute, 166001499ul);

    /// <summary>
    /// <para>Static version of <see cref="Godot.DirAccess.MakeDirRecursive(string)"/>. Supports only absolute paths.</para>
    /// </summary>
    public static Error MakeDirRecursiveAbsolute(string path)
    {
        return (Error)NativeCalls.godot_icall_1_376(MethodBind19, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FileExists, 2323990056ul);

    /// <summary>
    /// <para>Returns whether the target file exists. The argument can be relative to the current directory, or an absolute path.</para>
    /// <para>For a static equivalent, use <see cref="Godot.FileAccess.FileExists(string)"/>.</para>
    /// <para><b>Note:</b> Many resources types are imported (e.g. textures or sound files), and their source asset will not be included in the exported game, as only the imported version is used. See <see cref="Godot.ResourceLoader.Exists(string, string)"/> for an alternative approach that takes resource remapping into account.</para>
    /// </summary>
    public bool FileExists(string path)
    {
        return NativeCalls.godot_icall_1_131(MethodBind20, GodotObject.GetPtr(this), path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DirExists, 2323990056ul);

    /// <summary>
    /// <para>Returns whether the target directory exists. The argument can be relative to the current directory, or an absolute path.</para>
    /// <para><b>Note:</b> The returned <see cref="bool"/> in the editor and after exporting when used on a path in the <c>res://</c> directory may be different. Some files are converted to engine-specific formats when exported, potentially changing the directory structure.</para>
    /// </summary>
    public bool DirExists(string path)
    {
        return NativeCalls.godot_icall_1_131(MethodBind21, GodotObject.GetPtr(this), path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DirExistsAbsolute, 2323990056ul);

    /// <summary>
    /// <para>Static version of <see cref="Godot.DirAccess.DirExists(string)"/>. Supports only absolute paths.</para>
    /// <para><b>Note:</b> The returned <see cref="bool"/> in the editor and after exporting when used on a path in the <c>res://</c> directory may be different. Some files are converted to engine-specific formats when exported, potentially changing the directory structure.</para>
    /// </summary>
    public static bool DirExistsAbsolute(string path)
    {
        return NativeCalls.godot_icall_1_377(MethodBind22, path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpaceLeft, 2455072627ul);

    /// <summary>
    /// <para>Returns the available space on the current directory's disk, in bytes. Returns <c>0</c> if the platform-specific method to query the available space fails.</para>
    /// </summary>
    public ulong GetSpaceLeft()
    {
        return NativeCalls.godot_icall_0_137(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Copy, 1063198817ul);

    /// <summary>
    /// <para>Copies the <paramref name="from"/> file to the <paramref name="to"/> destination. Both arguments should be paths to files, either relative or absolute. If the destination file exists and is not access-protected, it will be overwritten.</para>
    /// <para>If <paramref name="chmodFlags"/> is different than <c>-1</c>, the Unix permissions for the destination path will be set to the provided value, if available on the current operating system.</para>
    /// <para>Returns one of the <see cref="Godot.Error"/> code constants (<see cref="Godot.Error.Ok"/> on success).</para>
    /// </summary>
    public Error Copy(string from, string to, int chmodFlags = -1)
    {
        return (Error)NativeCalls.godot_icall_3_378(MethodBind24, GodotObject.GetPtr(this), from, to, chmodFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CopyAbsolute, 1063198817ul);

    /// <summary>
    /// <para>Static version of <see cref="Godot.DirAccess.Copy(string, string, int)"/>. Supports only absolute paths.</para>
    /// </summary>
    public static Error CopyAbsolute(string from, string to, int chmodFlags = -1)
    {
        return (Error)NativeCalls.godot_icall_3_379(MethodBind25, from, to, chmodFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Rename, 852856452ul);

    /// <summary>
    /// <para>Renames (move) the <paramref name="from"/> file or directory to the <paramref name="to"/> destination. Both arguments should be paths to files or directories, either relative or absolute. If the destination file or directory exists and is not access-protected, it will be overwritten.</para>
    /// <para>Returns one of the <see cref="Godot.Error"/> code constants (<see cref="Godot.Error.Ok"/> on success).</para>
    /// </summary>
    public Error Rename(string from, string to)
    {
        return (Error)NativeCalls.godot_icall_2_330(MethodBind26, GodotObject.GetPtr(this), from, to);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenameAbsolute, 852856452ul);

    /// <summary>
    /// <para>Static version of <see cref="Godot.DirAccess.Rename(string, string)"/>. Supports only absolute paths.</para>
    /// </summary>
    public static Error RenameAbsolute(string from, string to)
    {
        return (Error)NativeCalls.godot_icall_2_380(MethodBind27, from, to);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Remove, 166001499ul);

    /// <summary>
    /// <para>Permanently deletes the target file or an empty directory. The argument can be relative to the current directory, or an absolute path. If the target directory is not empty, the operation will fail.</para>
    /// <para>If you don't want to delete the file/directory permanently, use <see cref="Godot.OS.MoveToTrash(string)"/> instead.</para>
    /// <para>Returns one of the <see cref="Godot.Error"/> code constants (<see cref="Godot.Error.Ok"/> on success).</para>
    /// </summary>
    public Error Remove(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind28, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveAbsolute, 166001499ul);

    /// <summary>
    /// <para>Static version of <see cref="Godot.DirAccess.Remove(string)"/>. Supports only absolute paths.</para>
    /// </summary>
    public static Error RemoveAbsolute(string path)
    {
        return (Error)NativeCalls.godot_icall_1_376(MethodBind29, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLink, 2323990056ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the file or directory is a symbolic link, directory junction, or other reparse point.</para>
    /// <para><b>Note:</b> This method is implemented on macOS, Linux, and Windows.</para>
    /// </summary>
    public bool IsLink(string path)
    {
        return NativeCalls.godot_icall_1_131(MethodBind30, GodotObject.GetPtr(this), path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReadLink, 1703090593ul);

    /// <summary>
    /// <para>Returns target of the symbolic link.</para>
    /// <para><b>Note:</b> This method is implemented on macOS, Linux, and Windows.</para>
    /// </summary>
    public string ReadLink(string path)
    {
        return NativeCalls.godot_icall_1_304(MethodBind31, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateLink, 852856452ul);

    /// <summary>
    /// <para>Creates symbolic link between files or folders.</para>
    /// <para><b>Note:</b> On Windows, this method works only if the application is running with elevated privileges or Developer Mode is enabled.</para>
    /// <para><b>Note:</b> This method is implemented on macOS, Linux, and Windows.</para>
    /// </summary>
    public Error CreateLink(string source, string target)
    {
        return (Error)NativeCalls.godot_icall_2_330(MethodBind32, GodotObject.GetPtr(this), source, target);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBundle, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the directory is a macOS bundle.</para>
    /// <para><b>Note:</b> This method is implemented on macOS.</para>
    /// </summary>
    public bool IsBundle(string path)
    {
        return NativeCalls.godot_icall_1_131(MethodBind33, GodotObject.GetPtr(this), path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIncludeNavigational, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIncludeNavigational(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind34, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIncludeNavigational, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetIncludeNavigational()
    {
        return NativeCalls.godot_icall_0_15(MethodBind35, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIncludeHidden, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIncludeHidden(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind36, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIncludeHidden, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetIncludeHidden()
    {
        return NativeCalls.godot_icall_0_15(MethodBind37, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilesystemType, 201670096ul);

    /// <summary>
    /// <para>Returns file system type name of the current directory's disk. Returned values are uppercase strings like <c>NTFS</c>, <c>FAT32</c>, <c>EXFAT</c>, <c>APFS</c>, <c>EXT4</c>, <c>BTRFS</c>, and so on.</para>
    /// <para><b>Note:</b> This method is implemented on macOS, Linux, Windows and for PCK virtual file system.</para>
    /// </summary>
    public string GetFilesystemType()
    {
        return NativeCalls.godot_icall_0_58(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCaseSensitive, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the file system or directory use case sensitive file names.</para>
    /// <para><b>Note:</b> This method is implemented on macOS, Linux (for EXT4 and F2FS filesystems only) and Windows. On other platforms, it always returns <see langword="true"/>.</para>
    /// </summary>
    public bool IsCaseSensitive(string path)
    {
        return NativeCalls.godot_icall_1_131(MethodBind39, GodotObject.GetPtr(this), path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEquivalent, 820780508ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if paths <paramref name="pathA"/> and <paramref name="pathB"/> resolve to the same file system object. Returns <see langword="false"/> otherwise, even if the files are bit-for-bit identical (e.g., identical copies of the file that are not symbolic links).</para>
    /// </summary>
    public bool IsEquivalent(string pathA, string pathB)
    {
        return NativeCalls.godot_icall_2_327(MethodBind40, GodotObject.GetPtr(this), pathA, pathB).ToBool();
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
        /// Cached name for the 'include_navigational' property.
        /// </summary>
        public static readonly StringName IncludeNavigational = "include_navigational";
        /// <summary>
        /// Cached name for the 'include_hidden' property.
        /// </summary>
        public static readonly StringName IncludeHidden = "include_hidden";
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
        /// Cached name for the 'get_open_error' method.
        /// </summary>
        public static readonly StringName GetOpenError = "get_open_error";
        /// <summary>
        /// Cached name for the 'create_temp' method.
        /// </summary>
        public static readonly StringName CreateTemp = "create_temp";
        /// <summary>
        /// Cached name for the 'list_dir_begin' method.
        /// </summary>
        public static readonly StringName ListDirBegin = "list_dir_begin";
        /// <summary>
        /// Cached name for the 'get_next' method.
        /// </summary>
        public static readonly StringName GetNext = "get_next";
        /// <summary>
        /// Cached name for the 'current_is_dir' method.
        /// </summary>
        public static readonly StringName CurrentIsDir = "current_is_dir";
        /// <summary>
        /// Cached name for the 'list_dir_end' method.
        /// </summary>
        public static readonly StringName ListDirEnd = "list_dir_end";
        /// <summary>
        /// Cached name for the 'get_files' method.
        /// </summary>
        public static readonly StringName GetFiles = "get_files";
        /// <summary>
        /// Cached name for the 'get_files_at' method.
        /// </summary>
        public static readonly StringName GetFilesAt = "get_files_at";
        /// <summary>
        /// Cached name for the 'get_directories' method.
        /// </summary>
        public static readonly StringName GetDirectories = "get_directories";
        /// <summary>
        /// Cached name for the 'get_directories_at' method.
        /// </summary>
        public static readonly StringName GetDirectoriesAt = "get_directories_at";
        /// <summary>
        /// Cached name for the 'get_drive_count' method.
        /// </summary>
        public static readonly StringName GetDriveCount = "get_drive_count";
        /// <summary>
        /// Cached name for the 'get_drive_name' method.
        /// </summary>
        public static readonly StringName GetDriveName = "get_drive_name";
        /// <summary>
        /// Cached name for the 'get_current_drive' method.
        /// </summary>
        public static readonly StringName GetCurrentDrive = "get_current_drive";
        /// <summary>
        /// Cached name for the 'change_dir' method.
        /// </summary>
        public static readonly StringName ChangeDir = "change_dir";
        /// <summary>
        /// Cached name for the 'get_current_dir' method.
        /// </summary>
        public static readonly StringName GetCurrentDir = "get_current_dir";
        /// <summary>
        /// Cached name for the 'make_dir' method.
        /// </summary>
        public static readonly StringName MakeDir = "make_dir";
        /// <summary>
        /// Cached name for the 'make_dir_absolute' method.
        /// </summary>
        public static readonly StringName MakeDirAbsolute = "make_dir_absolute";
        /// <summary>
        /// Cached name for the 'make_dir_recursive' method.
        /// </summary>
        public static readonly StringName MakeDirRecursive = "make_dir_recursive";
        /// <summary>
        /// Cached name for the 'make_dir_recursive_absolute' method.
        /// </summary>
        public static readonly StringName MakeDirRecursiveAbsolute = "make_dir_recursive_absolute";
        /// <summary>
        /// Cached name for the 'file_exists' method.
        /// </summary>
        public static readonly StringName FileExists = "file_exists";
        /// <summary>
        /// Cached name for the 'dir_exists' method.
        /// </summary>
        public static readonly StringName DirExists = "dir_exists";
        /// <summary>
        /// Cached name for the 'dir_exists_absolute' method.
        /// </summary>
        public static readonly StringName DirExistsAbsolute = "dir_exists_absolute";
        /// <summary>
        /// Cached name for the 'get_space_left' method.
        /// </summary>
        public static readonly StringName GetSpaceLeft = "get_space_left";
        /// <summary>
        /// Cached name for the 'copy' method.
        /// </summary>
        public static readonly StringName Copy = "copy";
        /// <summary>
        /// Cached name for the 'copy_absolute' method.
        /// </summary>
        public static readonly StringName CopyAbsolute = "copy_absolute";
        /// <summary>
        /// Cached name for the 'rename' method.
        /// </summary>
        public static readonly StringName Rename = "rename";
        /// <summary>
        /// Cached name for the 'rename_absolute' method.
        /// </summary>
        public static readonly StringName RenameAbsolute = "rename_absolute";
        /// <summary>
        /// Cached name for the 'remove' method.
        /// </summary>
        public static readonly StringName Remove = "remove";
        /// <summary>
        /// Cached name for the 'remove_absolute' method.
        /// </summary>
        public static readonly StringName RemoveAbsolute = "remove_absolute";
        /// <summary>
        /// Cached name for the 'is_link' method.
        /// </summary>
        public static readonly StringName IsLink = "is_link";
        /// <summary>
        /// Cached name for the 'read_link' method.
        /// </summary>
        public static readonly StringName ReadLink = "read_link";
        /// <summary>
        /// Cached name for the 'create_link' method.
        /// </summary>
        public static readonly StringName CreateLink = "create_link";
        /// <summary>
        /// Cached name for the 'is_bundle' method.
        /// </summary>
        public static readonly StringName IsBundle = "is_bundle";
        /// <summary>
        /// Cached name for the 'set_include_navigational' method.
        /// </summary>
        public static readonly StringName SetIncludeNavigational = "set_include_navigational";
        /// <summary>
        /// Cached name for the 'get_include_navigational' method.
        /// </summary>
        public static readonly StringName GetIncludeNavigational = "get_include_navigational";
        /// <summary>
        /// Cached name for the 'set_include_hidden' method.
        /// </summary>
        public static readonly StringName SetIncludeHidden = "set_include_hidden";
        /// <summary>
        /// Cached name for the 'get_include_hidden' method.
        /// </summary>
        public static readonly StringName GetIncludeHidden = "get_include_hidden";
        /// <summary>
        /// Cached name for the 'get_filesystem_type' method.
        /// </summary>
        public static readonly StringName GetFilesystemType = "get_filesystem_type";
        /// <summary>
        /// Cached name for the 'is_case_sensitive' method.
        /// </summary>
        public static readonly StringName IsCaseSensitive = "is_case_sensitive";
        /// <summary>
        /// Cached name for the 'is_equivalent' method.
        /// </summary>
        public static readonly StringName IsEquivalent = "is_equivalent";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
