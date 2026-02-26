namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base resource that provides the functionality of exporting a release build of a project to a platform, from the editor. Stores platform-specific metadata such as the name and supported features of the platform, and performs the exporting of projects, PCK files, and ZIP files. Uses an export template for the platform provided at the time of project exporting.</para>
/// <para>Used in scripting by <see cref="Godot.EditorExportPlugin"/> to configure platform-specific customization of scenes and resources. See <see cref="Godot.EditorExportPlugin._BeginCustomizeScenes(EditorExportPlatform, string[])"/> and <see cref="Godot.EditorExportPlugin._BeginCustomizeResources(EditorExportPlatform, string[])"/> for more details.</para>
/// </summary>
public partial class EditorExportPlatform : RefCounted
{
    public enum ExportMessageType : long
    {
        /// <summary>
        /// <para>Invalid message type used as the default value when no type is specified.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Message type for informational messages that have no effect on the export.</para>
        /// </summary>
        Info = 1,
        /// <summary>
        /// <para>Message type for warning messages that should be addressed but still allow to complete the export.</para>
        /// </summary>
        Warning = 2,
        /// <summary>
        /// <para>Message type for error messages that must be addressed and fail the export.</para>
        /// </summary>
        Error = 3
    }

    [System.Flags]
    public enum DebugFlags : long
    {
        /// <summary>
        /// <para>Flag is set if the remotely debugged project is expected to use the remote file system. If set, <see cref="Godot.EditorExportPlatform.GenExportFlags(EditorExportPlatform.DebugFlags)"/> will append <c>--remote-fs</c> and <c>--remote-fs-password</c> (if <c>EditorSettings.filesystem/file_server/password</c> is defined) command line arguments to the returned list.</para>
        /// </summary>
        DumbClient = 1,
        /// <summary>
        /// <para>Flag is set if remote debug is enabled. If set, <see cref="Godot.EditorExportPlatform.GenExportFlags(EditorExportPlatform.DebugFlags)"/> will append <c>--remote-debug</c> and <c>--breakpoints</c> (if breakpoints are selected in the script editor or added by the plugin) command line arguments to the returned list.</para>
        /// </summary>
        RemoteDebug = 2,
        /// <summary>
        /// <para>Flag is set if remotely debugged project is running on the localhost. If set, <see cref="Godot.EditorExportPlatform.GenExportFlags(EditorExportPlatform.DebugFlags)"/> will use <c>localhost</c> instead of <c>EditorSettings.network/debug/remote_host</c> as remote debugger host.</para>
        /// </summary>
        RemoteDebugLocalhost = 4,
        /// <summary>
        /// <para>Flag is set if the "Visible Collision Shapes" remote debug option is enabled. If set, <see cref="Godot.EditorExportPlatform.GenExportFlags(EditorExportPlatform.DebugFlags)"/> will append the <c>--debug-collisions</c> command line argument to the returned list.</para>
        /// </summary>
        ViewCollisions = 8,
        /// <summary>
        /// <para>Flag is set if the "Visible Navigation" remote debug option is enabled. If set, <see cref="Godot.EditorExportPlatform.GenExportFlags(EditorExportPlatform.DebugFlags)"/> will append the <c>--debug-navigation</c> command line argument to the returned list.</para>
        /// </summary>
        ViewNavigation = 16
    }

    private static readonly System.Type CachedType = typeof(EditorExportPlatform);

    private static readonly StringName NativeName = "EditorExportPlatform";

    internal EditorExportPlatform() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorExportPlatform(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorExportPlatform(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOsName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the export operating system handled by this <see cref="Godot.EditorExportPlatform"/> class, as a friendly string. Possible return values are <c>Windows</c>, <c>Linux</c>, <c>macOS</c>, <c>Android</c>, <c>iOS</c>, and <c>Web</c>.</para>
    /// </summary>
    public string GetOsName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreatePreset, 2572397818ul);

    /// <summary>
    /// <para>Create a new preset for this platform.</para>
    /// </summary>
    public EditorExportPreset CreatePreset()
    {
        return (EditorExportPreset)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindExportTemplate, 2248993622ul);

    /// <summary>
    /// <para>Locates export template for the platform, and returns <see cref="Godot.Collections.Dictionary"/> with the following keys: <c>path: String</c> and <c>error: String</c>. This method is provided for convenience and custom export platforms aren't required to use it or keep export templates stored in the same way official templates are.</para>
    /// </summary>
    public Godot.Collections.Dictionary FindExportTemplate(string templateFileName)
    {
        return EditorNativeCalls.godot_icall_1_471(MethodBind2, GodotObject.GetPtr(this), templateFileName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentPresets, 3995934104ul);

    /// <summary>
    /// <para>Returns array of <see cref="Godot.EditorExportPreset"/>s for this platform.</para>
    /// </summary>
    public Godot.Collections.Array GetCurrentPresets()
    {
        return NativeCalls.godot_icall_0_120(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SavePack, 3420080977ul);

    /// <summary>
    /// <para>Saves PCK archive and returns <see cref="Godot.Collections.Dictionary"/> with the following keys: <c>result: Error</c>, <c>so_files: Array</c> (array of the shared/static objects which contains dictionaries with the following keys: <c>path: String</c>, <c>tags: PackedStringArray</c>, and <c>target_folder: String</c>).</para>
    /// <para>If <paramref name="embed"/> is <see langword="true"/>, PCK content is appended to the end of <paramref name="path"/> file and return <see cref="Godot.Collections.Dictionary"/> additionally include following keys: <c>embedded_start: int</c> (embedded PCK offset) and <c>embedded_size: int</c> (embedded PCK size).</para>
    /// </summary>
    public Godot.Collections.Dictionary SavePack(EditorExportPreset preset, bool debug, string path, bool embed = false)
    {
        return EditorNativeCalls.godot_icall_4_472(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path, embed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveZip, 1485052307ul);

    /// <summary>
    /// <para>Saves ZIP archive and returns <see cref="Godot.Collections.Dictionary"/> with the following keys: <c>result: Error</c>, <c>so_files: Array</c> (array of the shared/static objects which contains dictionaries with the following keys: <c>path: String</c>, <c>tags: PackedStringArray</c>, and <c>target_folder: String</c>).</para>
    /// </summary>
    public Godot.Collections.Dictionary SaveZip(EditorExportPreset preset, bool debug, string path)
    {
        return EditorNativeCalls.godot_icall_3_473(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SavePackPatch, 1485052307ul);

    /// <summary>
    /// <para>Saves patch PCK archive and returns <see cref="Godot.Collections.Dictionary"/> with the following keys: <c>result: Error</c>, <c>so_files: Array</c> (array of the shared/static objects which contains dictionaries with the following keys: <c>path: String</c>, <c>tags: PackedStringArray</c>, and <c>target_folder: String</c>).</para>
    /// </summary>
    public Godot.Collections.Dictionary SavePackPatch(EditorExportPreset preset, bool debug, string path)
    {
        return EditorNativeCalls.godot_icall_3_473(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveZipPatch, 1485052307ul);

    /// <summary>
    /// <para>Saves patch ZIP archive and returns <see cref="Godot.Collections.Dictionary"/> with the following keys: <c>result: Error</c>, <c>so_files: Array</c> (array of the shared/static objects which contains dictionaries with the following keys: <c>path: String</c>, <c>tags: PackedStringArray</c>, and <c>target_folder: String</c>).</para>
    /// </summary>
    public Godot.Collections.Dictionary SaveZipPatch(EditorExportPreset preset, bool debug, string path)
    {
        return EditorNativeCalls.godot_icall_3_473(MethodBind7, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenExportFlags, 2976483270ul);

    /// <summary>
    /// <para>Generates array of command line arguments for the default export templates for the debug flags and editor settings.</para>
    /// </summary>
    public string[] GenExportFlags(EditorExportPlatform.DebugFlags flags)
    {
        return NativeCalls.godot_icall_1_474(MethodBind8, GodotObject.GetPtr(this), (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ExportProjectFiles, 1063735070ul);

    /// <summary>
    /// <para>Exports project files for the specified preset. This method can be used to implement custom export format, other than PCK and ZIP. One of the callbacks is called for each exported file.</para>
    /// <para><paramref name="saveCb"/> is called for all exported files and have the following arguments: <c>file_path: String</c>, <c>file_data: PackedByteArray</c>, <c>file_index: int</c>, <c>file_count: int</c>, <c>encryption_include_filters: PackedStringArray</c>, <c>encryption_exclude_filters: PackedStringArray</c>, <c>encryption_key: PackedByteArray</c>.</para>
    /// <para><paramref name="sharedCb"/> is called for exported native shared/static libraries and have the following arguments: <c>file_path: String</c>, <c>tags: PackedStringArray</c>, <c>target_folder: String</c>.</para>
    /// <para><b>Note:</b> <c>file_index</c> and <c>file_count</c> are intended for progress tracking only and aren't necessarily unique and precise.</para>
    /// </summary>
    public Error ExportProjectFiles(EditorExportPreset preset, bool debug, Callable saveCb, Callable sharedCb = default)
    {
        return (Error)EditorNativeCalls.godot_icall_4_475(MethodBind9, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), saveCb, sharedCb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ExportProject, 3879521245ul);

    /// <summary>
    /// <para>Creates a full project at <paramref name="path"/> for the specified <paramref name="preset"/>.</para>
    /// </summary>
    public Error ExportProject(EditorExportPreset preset, bool debug, string path, EditorExportPlatform.DebugFlags flags = (EditorExportPlatform.DebugFlags)(0))
    {
        return (Error)EditorNativeCalls.godot_icall_4_476(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path, (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ExportPack, 3879521245ul);

    /// <summary>
    /// <para>Creates a PCK archive at <paramref name="path"/> for the specified <paramref name="preset"/>.</para>
    /// </summary>
    public Error ExportPack(EditorExportPreset preset, bool debug, string path, EditorExportPlatform.DebugFlags flags = (EditorExportPlatform.DebugFlags)(0))
    {
        return (Error)EditorNativeCalls.godot_icall_4_476(MethodBind11, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path, (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ExportZip, 3879521245ul);

    /// <summary>
    /// <para>Create a ZIP archive at <paramref name="path"/> for the specified <paramref name="preset"/>.</para>
    /// </summary>
    public Error ExportZip(EditorExportPreset preset, bool debug, string path, EditorExportPlatform.DebugFlags flags = (EditorExportPlatform.DebugFlags)(0))
    {
        return (Error)EditorNativeCalls.godot_icall_4_476(MethodBind12, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path, (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ExportPackPatch, 608021658ul);

    /// <summary>
    /// <para>Creates a patch PCK archive at <paramref name="path"/> for the specified <paramref name="preset"/>, containing only the files that have changed since the last patch.</para>
    /// <para><b>Note:</b> <paramref name="patches"/> is an optional override of the set of patches defined in the export preset. When empty the patches defined in the export preset will be used instead.</para>
    /// </summary>
    /// <param name="patches">If the parameter is null, then the default value is <c>Array.Empty&lt;string&gt;()</c>.</param>
    public Error ExportPackPatch(EditorExportPreset preset, bool debug, string path, string[] patches = null, EditorExportPlatform.DebugFlags flags = (EditorExportPlatform.DebugFlags)(0))
    {
        string[] patchesOrDefVal = patches != null ? patches : Array.Empty<string>();
        return (Error)EditorNativeCalls.godot_icall_5_477(MethodBind13, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path, patchesOrDefVal, (int)flags);
    }

    /// <summary>
    /// <para>Creates a patch PCK archive at <paramref name="path"/> for the specified <paramref name="preset"/>, containing only the files that have changed since the last patch.</para>
    /// <para><b>Note:</b> <paramref name="patches"/> is an optional override of the set of patches defined in the export preset. When empty the patches defined in the export preset will be used instead.</para>
    /// </summary>
    public Error ExportPackPatch(EditorExportPreset preset, bool debug, string path, ReadOnlySpan<string> patches, EditorExportPlatform.DebugFlags flags)
    {
        return (Error)EditorNativeCalls.godot_icall_5_477(MethodBind13, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path, patches, (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ExportZipPatch, 608021658ul);

    /// <summary>
    /// <para>Create a patch ZIP archive at <paramref name="path"/> for the specified <paramref name="preset"/>, containing only the files that have changed since the last patch.</para>
    /// <para><b>Note:</b> <paramref name="patches"/> is an optional override of the set of patches defined in the export preset. When empty the patches defined in the export preset will be used instead.</para>
    /// </summary>
    /// <param name="patches">If the parameter is null, then the default value is <c>Array.Empty&lt;string&gt;()</c>.</param>
    public Error ExportZipPatch(EditorExportPreset preset, bool debug, string path, string[] patches = null, EditorExportPlatform.DebugFlags flags = (EditorExportPlatform.DebugFlags)(0))
    {
        string[] patchesOrDefVal = patches != null ? patches : Array.Empty<string>();
        return (Error)EditorNativeCalls.godot_icall_5_477(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path, patchesOrDefVal, (int)flags);
    }

    /// <summary>
    /// <para>Create a patch ZIP archive at <paramref name="path"/> for the specified <paramref name="preset"/>, containing only the files that have changed since the last patch.</para>
    /// <para><b>Note:</b> <paramref name="patches"/> is an optional override of the set of patches defined in the export preset. When empty the patches defined in the export preset will be used instead.</para>
    /// </summary>
    public Error ExportZipPatch(EditorExportPreset preset, bool debug, string path, ReadOnlySpan<string> patches, EditorExportPlatform.DebugFlags flags)
    {
        return (Error)EditorNativeCalls.godot_icall_5_477(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool(), path, patches, (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearMessages, 3218959716ul);

    /// <summary>
    /// <para>Clears the export log.</para>
    /// </summary>
    public void ClearMessages()
    {
        NativeCalls.godot_icall_0_3(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMessage, 782767225ul);

    /// <summary>
    /// <para>Adds a message to the export log that will be displayed when exporting ends.</para>
    /// </summary>
    public void AddMessage(EditorExportPlatform.ExportMessageType type, string category, string message)
    {
        EditorNativeCalls.godot_icall_3_478(MethodBind16, GodotObject.GetPtr(this), (int)type, category, message);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMessageCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of messages in the export log.</para>
    /// </summary>
    public int GetMessageCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMessageType, 2667287293ul);

    /// <summary>
    /// <para>Returns the type for the message with the given <paramref name="index"/>.</para>
    /// </summary>
    public EditorExportPlatform.ExportMessageType GetMessageType(int index)
    {
        return (EditorExportPlatform.ExportMessageType)NativeCalls.godot_icall_1_60(MethodBind18, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMessageCategory, 844755477ul);

    /// <summary>
    /// <para>Returns the message category for the message with the given <paramref name="index"/>.</para>
    /// </summary>
    public string GetMessageCategory(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind19, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMessageText, 844755477ul);

    /// <summary>
    /// <para>Returns the text for the message with the given <paramref name="index"/>.</para>
    /// </summary>
    public string GetMessageText(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind20, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWorstMessageType, 2580557466ul);

    /// <summary>
    /// <para>Returns most severe message type currently present in the export log.</para>
    /// </summary>
    public EditorExportPlatform.ExportMessageType GetWorstMessageType()
    {
        return (EditorExportPlatform.ExportMessageType)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SshRunOnRemote, 3163734797ul);

    /// <summary>
    /// <para>Executes specified command on the remote host via SSH protocol and returns command output in the <paramref name="output"/>.</para>
    /// </summary>
    public Error SshRunOnRemote(string host, string port, string[] sshArg, string cmdArgs, Godot.Collections.Array output = null, int portFwd = -1)
    {
        return (Error)EditorNativeCalls.godot_icall_6_479(MethodBind22, GodotObject.GetPtr(this), host, port, sshArg, cmdArgs, (godot_array)(output ?? new()).NativeValue, portFwd);
    }

    /// <summary>
    /// <para>Executes specified command on the remote host via SSH protocol and returns command output in the <paramref name="output"/>.</para>
    /// </summary>
    public Error SshRunOnRemote(string host, string port, ReadOnlySpan<string> sshArg, string cmdArgs, Godot.Collections.Array output, int portFwd)
    {
        return (Error)EditorNativeCalls.godot_icall_6_479(MethodBind22, GodotObject.GetPtr(this), host, port, sshArg, cmdArgs, (godot_array)(output ?? new()).NativeValue, portFwd);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SshRunOnRemoteNoWait, 3606362233ul);

    /// <summary>
    /// <para>Executes specified command on the remote host via SSH protocol and returns process ID (on the remote host) without waiting for command to finish.</para>
    /// </summary>
    public long SshRunOnRemoteNoWait(string host, string port, string[] sshArgs, string cmdArgs, int portFwd = -1)
    {
        return EditorNativeCalls.godot_icall_5_480(MethodBind23, GodotObject.GetPtr(this), host, port, sshArgs, cmdArgs, portFwd);
    }

    /// <summary>
    /// <para>Executes specified command on the remote host via SSH protocol and returns process ID (on the remote host) without waiting for command to finish.</para>
    /// </summary>
    public long SshRunOnRemoteNoWait(string host, string port, ReadOnlySpan<string> sshArgs, string cmdArgs, int portFwd)
    {
        return EditorNativeCalls.godot_icall_5_480(MethodBind23, GodotObject.GetPtr(this), host, port, sshArgs, cmdArgs, portFwd);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SshPushToRemote, 218756989ul);

    /// <summary>
    /// <para>Uploads specified file over SCP protocol to the remote host.</para>
    /// </summary>
    public Error SshPushToRemote(string host, string port, string[] scpArgs, string srcFile, string dstFile)
    {
        return (Error)EditorNativeCalls.godot_icall_5_481(MethodBind24, GodotObject.GetPtr(this), host, port, scpArgs, srcFile, dstFile);
    }

    /// <summary>
    /// <para>Uploads specified file over SCP protocol to the remote host.</para>
    /// </summary>
    public Error SshPushToRemote(string host, string port, ReadOnlySpan<string> scpArgs, string srcFile, string dstFile)
    {
        return (Error)EditorNativeCalls.godot_icall_5_481(MethodBind24, GodotObject.GetPtr(this), host, port, scpArgs, srcFile, dstFile);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInternalExportFiles, 89550086ul);

    /// <summary>
    /// <para>Returns additional files that should always be exported regardless of preset configuration, and are not part of the project source. The returned <see cref="Godot.Collections.Dictionary"/> contains filename keys (<see cref="string"/>) and their corresponding raw data (<see cref="byte"/>[]).</para>
    /// </summary>
    public Godot.Collections.Dictionary GetInternalExportFiles(EditorExportPreset preset, bool debug)
    {
        return NativeCalls.godot_icall_2_482(MethodBind25, GodotObject.GetPtr(this), GodotObject.GetPtr(preset), debug.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetForcedExportFiles, 1939331020ul);

    /// <summary>
    /// <para>Returns array of core file names that always should be exported regardless of preset config.</para>
    /// </summary>
    public static string[] GetForcedExportFiles(EditorExportPreset preset = null)
    {
        return EditorNativeCalls.godot_icall_1_483(MethodBind26, GodotObject.GetPtr(preset));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetForcedExportFiles, 2981934095ul);

    /// <summary>
    /// <para>Returns array of core file names that always should be exported regardless of preset config.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string[] GetForcedExportFiles()
    {
        return NativeCalls.godot_icall_0_484(MethodBind27);
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
        /// Cached name for the 'get_os_name' method.
        /// </summary>
        public static readonly StringName GetOsName = "get_os_name";
        /// <summary>
        /// Cached name for the 'create_preset' method.
        /// </summary>
        public static readonly StringName CreatePreset = "create_preset";
        /// <summary>
        /// Cached name for the 'find_export_template' method.
        /// </summary>
        public static readonly StringName FindExportTemplate = "find_export_template";
        /// <summary>
        /// Cached name for the 'get_current_presets' method.
        /// </summary>
        public static readonly StringName GetCurrentPresets = "get_current_presets";
        /// <summary>
        /// Cached name for the 'save_pack' method.
        /// </summary>
        public static readonly StringName SavePack = "save_pack";
        /// <summary>
        /// Cached name for the 'save_zip' method.
        /// </summary>
        public static readonly StringName SaveZip = "save_zip";
        /// <summary>
        /// Cached name for the 'save_pack_patch' method.
        /// </summary>
        public static readonly StringName SavePackPatch = "save_pack_patch";
        /// <summary>
        /// Cached name for the 'save_zip_patch' method.
        /// </summary>
        public static readonly StringName SaveZipPatch = "save_zip_patch";
        /// <summary>
        /// Cached name for the 'gen_export_flags' method.
        /// </summary>
        public static readonly StringName GenExportFlags = "gen_export_flags";
        /// <summary>
        /// Cached name for the 'export_project_files' method.
        /// </summary>
        public static readonly StringName ExportProjectFiles = "export_project_files";
        /// <summary>
        /// Cached name for the 'export_project' method.
        /// </summary>
        public static readonly StringName ExportProject = "export_project";
        /// <summary>
        /// Cached name for the 'export_pack' method.
        /// </summary>
        public static readonly StringName ExportPack = "export_pack";
        /// <summary>
        /// Cached name for the 'export_zip' method.
        /// </summary>
        public static readonly StringName ExportZip = "export_zip";
        /// <summary>
        /// Cached name for the 'export_pack_patch' method.
        /// </summary>
        public static readonly StringName ExportPackPatch = "export_pack_patch";
        /// <summary>
        /// Cached name for the 'export_zip_patch' method.
        /// </summary>
        public static readonly StringName ExportZipPatch = "export_zip_patch";
        /// <summary>
        /// Cached name for the 'clear_messages' method.
        /// </summary>
        public static readonly StringName ClearMessages = "clear_messages";
        /// <summary>
        /// Cached name for the 'add_message' method.
        /// </summary>
        public static readonly StringName AddMessage = "add_message";
        /// <summary>
        /// Cached name for the 'get_message_count' method.
        /// </summary>
        public static readonly StringName GetMessageCount = "get_message_count";
        /// <summary>
        /// Cached name for the 'get_message_type' method.
        /// </summary>
        public static readonly StringName GetMessageType = "get_message_type";
        /// <summary>
        /// Cached name for the 'get_message_category' method.
        /// </summary>
        public static readonly StringName GetMessageCategory = "get_message_category";
        /// <summary>
        /// Cached name for the 'get_message_text' method.
        /// </summary>
        public static readonly StringName GetMessageText = "get_message_text";
        /// <summary>
        /// Cached name for the 'get_worst_message_type' method.
        /// </summary>
        public static readonly StringName GetWorstMessageType = "get_worst_message_type";
        /// <summary>
        /// Cached name for the 'ssh_run_on_remote' method.
        /// </summary>
        public static readonly StringName SshRunOnRemote = "ssh_run_on_remote";
        /// <summary>
        /// Cached name for the 'ssh_run_on_remote_no_wait' method.
        /// </summary>
        public static readonly StringName SshRunOnRemoteNoWait = "ssh_run_on_remote_no_wait";
        /// <summary>
        /// Cached name for the 'ssh_push_to_remote' method.
        /// </summary>
        public static readonly StringName SshPushToRemote = "ssh_push_to_remote";
        /// <summary>
        /// Cached name for the 'get_internal_export_files' method.
        /// </summary>
        public static readonly StringName GetInternalExportFiles = "get_internal_export_files";
        /// <summary>
        /// Cached name for the 'get_forced_export_files' method.
        /// </summary>
        public static readonly StringName GetForcedExportFiles = "get_forced_export_files";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
