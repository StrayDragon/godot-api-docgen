namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is available only in <see cref="Godot.EditorPlugin"/>s and can't be instantiated. You can access it using <see cref="Godot.EditorInterface.GetFileSystemDock()"/>.</para>
/// <para>While <see cref="Godot.FileSystemDock"/> doesn't expose any methods for file manipulation, it can listen for various file-related signals.</para>
/// </summary>
public partial class FileSystemDock : EditorDock
{
    private static readonly System.Type CachedType = typeof(FileSystemDock);

    private static readonly StringName NativeName = "FileSystemDock";

    internal FileSystemDock() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal FileSystemDock(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal FileSystemDock(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NavigateToPath, 83702148ul);

    /// <summary>
    /// <para>Sets the given <paramref name="path"/> as currently selected, ensuring that the selected file/directory is visible.</para>
    /// </summary>
    public void NavigateToPath(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddResourceTooltipPlugin, 2258356838ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.EditorResourceTooltipPlugin"/>.</para>
    /// </summary>
    public void AddResourceTooltipPlugin(EditorResourceTooltipPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveResourceTooltipPlugin, 2258356838ul);

    /// <summary>
    /// <para>Removes an <see cref="Godot.EditorResourceTooltipPlugin"/>. Fails if the plugin wasn't previously added.</para>
    /// </summary>
    public void RemoveResourceTooltipPlugin(EditorResourceTooltipPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.FileSystemDock.Inherit"/> event of a <see cref="Godot.FileSystemDock"/> class.
    /// </summary>
    public delegate void InheritEventHandler(string file);

    private static void InheritTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((InheritEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a new scene is created that inherits the scene at <c>file</c> path.</para>
    /// </summary>
    public unsafe event InheritEventHandler Inherit
    {
        add => Connect(SignalName.Inherit, Callable.CreateWithUnsafeTrampoline(value, &InheritTrampoline));
        remove => Disconnect(SignalName.Inherit, Callable.CreateWithUnsafeTrampoline(value, &InheritTrampoline));
    }

    protected void EmitSignalInherit(string file)
    {
        EmitSignal(SignalName.Inherit, file);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.FileSystemDock.Instantiate"/> event of a <see cref="Godot.FileSystemDock"/> class.
    /// </summary>
    public delegate void InstantiateEventHandler(string[] files);

    private static void InstantiateTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((InstantiateEventHandler)delegateObj)(VariantUtils.ConvertTo<string[]>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the given scenes are being instantiated in the editor.</para>
    /// </summary>
    public unsafe event InstantiateEventHandler Instantiate
    {
        add => Connect(SignalName.Instantiate, Callable.CreateWithUnsafeTrampoline(value, &InstantiateTrampoline));
        remove => Disconnect(SignalName.Instantiate, Callable.CreateWithUnsafeTrampoline(value, &InstantiateTrampoline));
    }

    protected void EmitSignalInstantiate(string[] files)
    {
        EmitSignal(SignalName.Instantiate, files);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.FileSystemDock.ResourceRemoved"/> event of a <see cref="Godot.FileSystemDock"/> class.
    /// </summary>
    public delegate void ResourceRemovedEventHandler(Resource resource);

    private static void ResourceRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ResourceRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<Resource>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an external <c>resource</c> had its file removed.</para>
    /// </summary>
    public unsafe event ResourceRemovedEventHandler ResourceRemoved
    {
        add => Connect(SignalName.ResourceRemoved, Callable.CreateWithUnsafeTrampoline(value, &ResourceRemovedTrampoline));
        remove => Disconnect(SignalName.ResourceRemoved, Callable.CreateWithUnsafeTrampoline(value, &ResourceRemovedTrampoline));
    }

    protected void EmitSignalResourceRemoved(Resource resource)
    {
        EmitSignal(SignalName.ResourceRemoved, resource);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.FileSystemDock.FileRemoved"/> event of a <see cref="Godot.FileSystemDock"/> class.
    /// </summary>
    public delegate void FileRemovedEventHandler(string file);

    private static void FileRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((FileRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the given <c>file</c> was removed.</para>
    /// </summary>
    public unsafe event FileRemovedEventHandler FileRemoved
    {
        add => Connect(SignalName.FileRemoved, Callable.CreateWithUnsafeTrampoline(value, &FileRemovedTrampoline));
        remove => Disconnect(SignalName.FileRemoved, Callable.CreateWithUnsafeTrampoline(value, &FileRemovedTrampoline));
    }

    protected void EmitSignalFileRemoved(string file)
    {
        EmitSignal(SignalName.FileRemoved, file);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.FileSystemDock.FolderRemoved"/> event of a <see cref="Godot.FileSystemDock"/> class.
    /// </summary>
    public delegate void FolderRemovedEventHandler(string folder);

    private static void FolderRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((FolderRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the given <c>folder</c> was removed.</para>
    /// </summary>
    public unsafe event FolderRemovedEventHandler FolderRemoved
    {
        add => Connect(SignalName.FolderRemoved, Callable.CreateWithUnsafeTrampoline(value, &FolderRemovedTrampoline));
        remove => Disconnect(SignalName.FolderRemoved, Callable.CreateWithUnsafeTrampoline(value, &FolderRemovedTrampoline));
    }

    protected void EmitSignalFolderRemoved(string folder)
    {
        EmitSignal(SignalName.FolderRemoved, folder);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.FileSystemDock.FilesMoved"/> event of a <see cref="Godot.FileSystemDock"/> class.
    /// </summary>
    public delegate void FilesMovedEventHandler(string oldFile, string newFile);

    private static void FilesMovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((FilesMovedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a file is moved from <c>oldFile</c> path to <c>newFile</c> path.</para>
    /// </summary>
    public unsafe event FilesMovedEventHandler FilesMoved
    {
        add => Connect(SignalName.FilesMoved, Callable.CreateWithUnsafeTrampoline(value, &FilesMovedTrampoline));
        remove => Disconnect(SignalName.FilesMoved, Callable.CreateWithUnsafeTrampoline(value, &FilesMovedTrampoline));
    }

    protected void EmitSignalFilesMoved(string oldFile, string newFile)
    {
        EmitSignal(SignalName.FilesMoved, oldFile, newFile);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.FileSystemDock.FolderMoved"/> event of a <see cref="Godot.FileSystemDock"/> class.
    /// </summary>
    public delegate void FolderMovedEventHandler(string oldFolder, string newFolder);

    private static void FolderMovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((FolderMovedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a folder is moved from <c>oldFolder</c> path to <c>newFolder</c> path.</para>
    /// </summary>
    public unsafe event FolderMovedEventHandler FolderMoved
    {
        add => Connect(SignalName.FolderMoved, Callable.CreateWithUnsafeTrampoline(value, &FolderMovedTrampoline));
        remove => Disconnect(SignalName.FolderMoved, Callable.CreateWithUnsafeTrampoline(value, &FolderMovedTrampoline));
    }

    protected void EmitSignalFolderMoved(string oldFolder, string newFolder)
    {
        EmitSignal(SignalName.FolderMoved, oldFolder, newFolder);
    }

    /// <summary>
    /// <para>Emitted when folders change color.</para>
    /// </summary>
    public event Action FolderColorChanged
    {
        add => Connect(SignalName.FolderColorChanged, Callable.From(value));
        remove => Disconnect(SignalName.FolderColorChanged, Callable.From(value));
    }

    protected void EmitSignalFolderColorChanged()
    {
        EmitSignal(SignalName.FolderColorChanged);
    }

    /// <summary>
    /// <para>Emitted when the selection changes. Use <see cref="Godot.EditorInterface.GetSelectedPaths()"/> in the connected method to get the selected paths.</para>
    /// </summary>
    public event Action SelectionChanged
    {
        add => Connect(SignalName.SelectionChanged, Callable.From(value));
        remove => Disconnect(SignalName.SelectionChanged, Callable.From(value));
    }

    protected void EmitSignalSelectionChanged()
    {
        EmitSignal(SignalName.SelectionChanged);
    }

    /// <summary>
    /// <para>Emitted when the user switches file display mode or split mode.</para>
    /// </summary>
    public event Action DisplayModeChanged
    {
        add => Connect(SignalName.DisplayModeChanged, Callable.From(value));
        remove => Disconnect(SignalName.DisplayModeChanged, Callable.From(value));
    }

    protected void EmitSignalDisplayModeChanged()
    {
        EmitSignal(SignalName.DisplayModeChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_inherit = "Inherit";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_instantiate = "Instantiate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resource_removed = "ResourceRemoved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_file_removed = "FileRemoved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_folder_removed = "FolderRemoved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_files_moved = "FilesMoved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_folder_moved = "FolderMoved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_folder_color_changed = "FolderColorChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_selection_changed = "SelectionChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_display_mode_changed = "DisplayModeChanged";

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
        if (signal == SignalName.Inherit)
        {
            if (HasGodotClassSignal(SignalProxyName_inherit.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Instantiate)
        {
            if (HasGodotClassSignal(SignalProxyName_instantiate.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ResourceRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_resource_removed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FileRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_file_removed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FolderRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_folder_removed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FilesMoved)
        {
            if (HasGodotClassSignal(SignalProxyName_files_moved.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FolderMoved)
        {
            if (HasGodotClassSignal(SignalProxyName_folder_moved.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FolderColorChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_folder_color_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SelectionChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_selection_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DisplayModeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_display_mode_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : EditorDock.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : EditorDock.MethodName
    {
        /// <summary>
        /// Cached name for the 'navigate_to_path' method.
        /// </summary>
        public static readonly StringName NavigateToPath = "navigate_to_path";
        /// <summary>
        /// Cached name for the 'add_resource_tooltip_plugin' method.
        /// </summary>
        public static readonly StringName AddResourceTooltipPlugin = "add_resource_tooltip_plugin";
        /// <summary>
        /// Cached name for the 'remove_resource_tooltip_plugin' method.
        /// </summary>
        public static readonly StringName RemoveResourceTooltipPlugin = "remove_resource_tooltip_plugin";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : EditorDock.SignalName
    {
        /// <summary>
        /// Cached name for the 'inherit' signal.
        /// </summary>
        public static readonly StringName Inherit = "inherit";
        /// <summary>
        /// Cached name for the 'instantiate' signal.
        /// </summary>
        public static readonly StringName Instantiate = "instantiate";
        /// <summary>
        /// Cached name for the 'resource_removed' signal.
        /// </summary>
        public static readonly StringName ResourceRemoved = "resource_removed";
        /// <summary>
        /// Cached name for the 'file_removed' signal.
        /// </summary>
        public static readonly StringName FileRemoved = "file_removed";
        /// <summary>
        /// Cached name for the 'folder_removed' signal.
        /// </summary>
        public static readonly StringName FolderRemoved = "folder_removed";
        /// <summary>
        /// Cached name for the 'files_moved' signal.
        /// </summary>
        public static readonly StringName FilesMoved = "files_moved";
        /// <summary>
        /// Cached name for the 'folder_moved' signal.
        /// </summary>
        public static readonly StringName FolderMoved = "folder_moved";
        /// <summary>
        /// Cached name for the 'folder_color_changed' signal.
        /// </summary>
        public static readonly StringName FolderColorChanged = "folder_color_changed";
        /// <summary>
        /// Cached name for the 'selection_changed' signal.
        /// </summary>
        public static readonly StringName SelectionChanged = "selection_changed";
        /// <summary>
        /// Cached name for the 'display_mode_changed' signal.
        /// </summary>
        public static readonly StringName DisplayModeChanged = "display_mode_changed";
    }
}
