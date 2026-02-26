namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object holds information of all resources in the filesystem, their types, etc.</para>
/// <para><b>Note:</b> This class shouldn't be instantiated directly. Instead, access the singleton using <see cref="Godot.EditorInterface.GetResourceFilesystem()"/>.</para>
/// </summary>
public partial class EditorFileSystem : Node
{
    private static readonly System.Type CachedType = typeof(EditorFileSystem);

    private static readonly StringName NativeName = "EditorFileSystem";

    internal EditorFileSystem() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorFileSystem(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorFileSystem(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilesystem, 842323275ul);

    /// <summary>
    /// <para>Gets the root directory object.</para>
    /// </summary>
    public EditorFileSystemDirectory GetFilesystem()
    {
        return (EditorFileSystemDirectory)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScanning, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the filesystem is being scanned.</para>
    /// </summary>
    public bool IsScanning()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScanningProgress, 1740695150ul);

    /// <summary>
    /// <para>Returns the scan progress for 0 to 1 if the FS is being scanned.</para>
    /// </summary>
    public float GetScanningProgress()
    {
        return NativeCalls.godot_icall_0_68(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Scan, 3218959716ul);

    /// <summary>
    /// <para>Scan the filesystem for changes.</para>
    /// </summary>
    public void Scan()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScanSources, 3218959716ul);

    /// <summary>
    /// <para>Check if the source of any imported resource changed.</para>
    /// </summary>
    public void ScanSources()
    {
        NativeCalls.godot_icall_0_3(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateFile, 83702148ul);

    /// <summary>
    /// <para>Add a file in an existing directory, or schedule file information to be updated on editor restart. Can be used to update text files saved by an external program.</para>
    /// <para>This will not import the file. To reimport, call <see cref="Godot.EditorFileSystem.ReimportFiles(string[])"/> or <see cref="Godot.EditorFileSystem.Scan()"/> methods.</para>
    /// </summary>
    public void UpdateFile(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind5, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilesystemPath, 3188521125ul);

    /// <summary>
    /// <para>Returns a view into the filesystem at <paramref name="path"/>.</para>
    /// </summary>
    public EditorFileSystemDirectory GetFilesystemPath(string path)
    {
        return (EditorFileSystemDirectory)NativeCalls.godot_icall_1_55(MethodBind6, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFileType, 3135753539ul);

    /// <summary>
    /// <para>Returns the resource type of the file, given the full path. This returns a string such as <c>"Resource"</c> or <c>"GDScript"</c>, <i>not</i> a file extension such as <c>".gd"</c>.</para>
    /// </summary>
    public string GetFileType(string path)
    {
        return NativeCalls.godot_icall_1_304(MethodBind7, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReimportFiles, 4015028928ul);

    /// <summary>
    /// <para>Reimports a set of files. Call this if these files or their <c>.import</c> files were directly edited by script or an external program.</para>
    /// <para>If the file type changed or the file was newly created, use <see cref="Godot.EditorFileSystem.UpdateFile(string)"/> or <see cref="Godot.EditorFileSystem.Scan()"/>.</para>
    /// <para><b>Note:</b> This function blocks until the import is finished. However, the main loop iteration, including timers and <see cref="Godot.Node._Process(double)"/>, will occur during the import process due to progress bar updates. Avoid calls to <see cref="Godot.EditorFileSystem.ReimportFiles(string[])"/> or <see cref="Godot.EditorFileSystem.Scan()"/> while an import is in progress.</para>
    /// </summary>
    public void ReimportFiles(string[] files)
    {
        NativeCalls.godot_icall_1_185(MethodBind8, GodotObject.GetPtr(this), files);
    }

    /// <summary>
    /// <para>Reimports a set of files. Call this if these files or their <c>.import</c> files were directly edited by script or an external program.</para>
    /// <para>If the file type changed or the file was newly created, use <see cref="Godot.EditorFileSystem.UpdateFile(string)"/> or <see cref="Godot.EditorFileSystem.Scan()"/>.</para>
    /// <para><b>Note:</b> This function blocks until the import is finished. However, the main loop iteration, including timers and <see cref="Godot.Node._Process(double)"/>, will occur during the import process due to progress bar updates. Avoid calls to <see cref="Godot.EditorFileSystem.ReimportFiles(string[])"/> or <see cref="Godot.EditorFileSystem.Scan()"/> while an import is in progress.</para>
    /// </summary>
    public void ReimportFiles(ReadOnlySpan<string> files)
    {
        NativeCalls.godot_icall_1_185(MethodBind8, GodotObject.GetPtr(this), files);
    }

    /// <summary>
    /// <para>Emitted if the filesystem changed.</para>
    /// </summary>
    public event Action FilesystemChanged
    {
        add => Connect(SignalName.FilesystemChanged, Callable.From(value));
        remove => Disconnect(SignalName.FilesystemChanged, Callable.From(value));
    }

    protected void EmitSignalFilesystemChanged()
    {
        EmitSignal(SignalName.FilesystemChanged);
    }

    /// <summary>
    /// <para>Emitted when the list of global script classes gets updated.</para>
    /// </summary>
    public event Action ScriptClassesUpdated
    {
        add => Connect(SignalName.ScriptClassesUpdated, Callable.From(value));
        remove => Disconnect(SignalName.ScriptClassesUpdated, Callable.From(value));
    }

    protected void EmitSignalScriptClassesUpdated()
    {
        EmitSignal(SignalName.ScriptClassesUpdated);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorFileSystem.SourcesChanged"/> event of a <see cref="Godot.EditorFileSystem"/> class.
    /// </summary>
    public delegate void SourcesChangedEventHandler(bool exist);

    private static void SourcesChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SourcesChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<bool>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted if the source of any imported file changed.</para>
    /// </summary>
    public unsafe event SourcesChangedEventHandler SourcesChanged
    {
        add => Connect(SignalName.SourcesChanged, Callable.CreateWithUnsafeTrampoline(value, &SourcesChangedTrampoline));
        remove => Disconnect(SignalName.SourcesChanged, Callable.CreateWithUnsafeTrampoline(value, &SourcesChangedTrampoline));
    }

    protected void EmitSignalSourcesChanged(bool exist)
    {
        EmitSignal(SignalName.SourcesChanged, exist);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorFileSystem.ResourcesReimporting"/> event of a <see cref="Godot.EditorFileSystem"/> class.
    /// </summary>
    public delegate void ResourcesReimportingEventHandler(string[] resources);

    private static void ResourcesReimportingTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ResourcesReimportingEventHandler)delegateObj)(VariantUtils.ConvertTo<string[]>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted before a resource is reimported.</para>
    /// </summary>
    public unsafe event ResourcesReimportingEventHandler ResourcesReimporting
    {
        add => Connect(SignalName.ResourcesReimporting, Callable.CreateWithUnsafeTrampoline(value, &ResourcesReimportingTrampoline));
        remove => Disconnect(SignalName.ResourcesReimporting, Callable.CreateWithUnsafeTrampoline(value, &ResourcesReimportingTrampoline));
    }

    protected void EmitSignalResourcesReimporting(string[] resources)
    {
        EmitSignal(SignalName.ResourcesReimporting, resources);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorFileSystem.ResourcesReimported"/> event of a <see cref="Godot.EditorFileSystem"/> class.
    /// </summary>
    public delegate void ResourcesReimportedEventHandler(string[] resources);

    private static void ResourcesReimportedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ResourcesReimportedEventHandler)delegateObj)(VariantUtils.ConvertTo<string[]>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted if a resource is reimported.</para>
    /// </summary>
    public unsafe event ResourcesReimportedEventHandler ResourcesReimported
    {
        add => Connect(SignalName.ResourcesReimported, Callable.CreateWithUnsafeTrampoline(value, &ResourcesReimportedTrampoline));
        remove => Disconnect(SignalName.ResourcesReimported, Callable.CreateWithUnsafeTrampoline(value, &ResourcesReimportedTrampoline));
    }

    protected void EmitSignalResourcesReimported(string[] resources)
    {
        EmitSignal(SignalName.ResourcesReimported, resources);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorFileSystem.ResourcesReload"/> event of a <see cref="Godot.EditorFileSystem"/> class.
    /// </summary>
    public delegate void ResourcesReloadEventHandler(string[] resources);

    private static void ResourcesReloadTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ResourcesReloadEventHandler)delegateObj)(VariantUtils.ConvertTo<string[]>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted if at least one resource is reloaded when the filesystem is scanned.</para>
    /// </summary>
    public unsafe event ResourcesReloadEventHandler ResourcesReload
    {
        add => Connect(SignalName.ResourcesReload, Callable.CreateWithUnsafeTrampoline(value, &ResourcesReloadTrampoline));
        remove => Disconnect(SignalName.ResourcesReload, Callable.CreateWithUnsafeTrampoline(value, &ResourcesReloadTrampoline));
    }

    protected void EmitSignalResourcesReload(string[] resources)
    {
        EmitSignal(SignalName.ResourcesReload, resources);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_filesystem_changed = "FilesystemChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_script_classes_updated = "ScriptClassesUpdated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_sources_changed = "SourcesChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resources_reimporting = "ResourcesReimporting";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resources_reimported = "ResourcesReimported";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resources_reload = "ResourcesReload";

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
        if (signal == SignalName.FilesystemChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_filesystem_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ScriptClassesUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_script_classes_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SourcesChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_sources_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ResourcesReimporting)
        {
            if (HasGodotClassSignal(SignalProxyName_resources_reimporting.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ResourcesReimported)
        {
            if (HasGodotClassSignal(SignalProxyName_resources_reimported.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ResourcesReload)
        {
            if (HasGodotClassSignal(SignalProxyName_resources_reload.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_filesystem' method.
        /// </summary>
        public static readonly StringName GetFilesystem = "get_filesystem";
        /// <summary>
        /// Cached name for the 'is_scanning' method.
        /// </summary>
        public static readonly StringName IsScanning = "is_scanning";
        /// <summary>
        /// Cached name for the 'get_scanning_progress' method.
        /// </summary>
        public static readonly StringName GetScanningProgress = "get_scanning_progress";
        /// <summary>
        /// Cached name for the 'scan' method.
        /// </summary>
        public static readonly StringName Scan = "scan";
        /// <summary>
        /// Cached name for the 'scan_sources' method.
        /// </summary>
        public static readonly StringName ScanSources = "scan_sources";
        /// <summary>
        /// Cached name for the 'update_file' method.
        /// </summary>
        public static readonly StringName UpdateFile = "update_file";
        /// <summary>
        /// Cached name for the 'get_filesystem_path' method.
        /// </summary>
        public static readonly StringName GetFilesystemPath = "get_filesystem_path";
        /// <summary>
        /// Cached name for the 'get_file_type' method.
        /// </summary>
        public static readonly StringName GetFileType = "get_file_type";
        /// <summary>
        /// Cached name for the 'reimport_files' method.
        /// </summary>
        public static readonly StringName ReimportFiles = "reimport_files";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'filesystem_changed' signal.
        /// </summary>
        public static readonly StringName FilesystemChanged = "filesystem_changed";
        /// <summary>
        /// Cached name for the 'script_classes_updated' signal.
        /// </summary>
        public static readonly StringName ScriptClassesUpdated = "script_classes_updated";
        /// <summary>
        /// Cached name for the 'sources_changed' signal.
        /// </summary>
        public static readonly StringName SourcesChanged = "sources_changed";
        /// <summary>
        /// Cached name for the 'resources_reimporting' signal.
        /// </summary>
        public static readonly StringName ResourcesReimporting = "resources_reimporting";
        /// <summary>
        /// Cached name for the 'resources_reimported' signal.
        /// </summary>
        public static readonly StringName ResourcesReimported = "resources_reimported";
        /// <summary>
        /// Cached name for the 'resources_reload' signal.
        /// </summary>
        public static readonly StringName ResourcesReload = "resources_reload";
    }
}
