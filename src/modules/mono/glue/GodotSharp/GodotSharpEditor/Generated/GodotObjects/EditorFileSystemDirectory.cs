namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A more generalized, low-level variation of the directory concept.</para>
/// </summary>
public partial class EditorFileSystemDirectory : GodotObject
{
    private static readonly System.Type CachedType = typeof(EditorFileSystemDirectory);

    private static readonly StringName NativeName = "EditorFileSystemDirectory";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorFileSystemDirectory() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorFileSystemDirectory(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorFileSystemDirectory(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubdirCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of subdirectories in this directory.</para>
    /// </summary>
    public int GetSubdirCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubdir, 2330964164ul);

    /// <summary>
    /// <para>Returns the subdirectory at index <paramref name="idx"/>.</para>
    /// </summary>
    public EditorFileSystemDirectory GetSubdir(int idx)
    {
        return (EditorFileSystemDirectory)NativeCalls.godot_icall_1_335(MethodBind1, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFileCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of files in this directory.</para>
    /// </summary>
    public int GetFileCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFile, 844755477ul);

    /// <summary>
    /// <para>Returns the name of the file at index <paramref name="idx"/>.</para>
    /// </summary>
    public string GetFile(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind3, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilePath, 844755477ul);

    /// <summary>
    /// <para>Returns the path to the file at index <paramref name="idx"/>.</para>
    /// </summary>
    public string GetFilePath(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind4, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFileType, 659327637ul);

    /// <summary>
    /// <para>Returns the resource type of the file at index <paramref name="idx"/>. This returns a string such as <c>"Resource"</c> or <c>"GDScript"</c>, <i>not</i> a file extension such as <c>".gd"</c>.</para>
    /// </summary>
    public StringName GetFileType(int idx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind5, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFileScriptClassName, 844755477ul);

    /// <summary>
    /// <para>Returns the name of the script class defined in the file at index <paramref name="idx"/>. If the file doesn't define a script class using the <c>class_name</c> syntax, this will return an empty string.</para>
    /// </summary>
    public string GetFileScriptClassName(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind6, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFileScriptClassExtends, 844755477ul);

    /// <summary>
    /// <para>Returns the base class of the script class defined in the file at index <paramref name="idx"/>. If the file doesn't define a script class using the <c>class_name</c> syntax, this will return an empty string.</para>
    /// </summary>
    public string GetFileScriptClassExtends(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind7, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFileImportIsValid, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the file at index <paramref name="idx"/> imported properly.</para>
    /// </summary>
    public bool GetFileImportIsValid(int idx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind8, GodotObject.GetPtr(this), idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetName, 2841200299ul);

    /// <summary>
    /// <para>Returns the name of this directory.</para>
    /// </summary>
    public string GetName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPath, 201670096ul);

    /// <summary>
    /// <para>Returns the path to this directory.</para>
    /// </summary>
    public string GetPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParent, 842323275ul);

    /// <summary>
    /// <para>Returns the parent directory for this directory or <see langword="null"/> if called on a directory at <c>res://</c> or <c>user://</c>.</para>
    /// </summary>
    public EditorFileSystemDirectory GetParent()
    {
        return (EditorFileSystemDirectory)NativeCalls.godot_icall_0_53(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindFileIndex, 1321353865ul);

    /// <summary>
    /// <para>Returns the index of the file with name <paramref name="name"/> or <c>-1</c> if not found.</para>
    /// </summary>
    public int FindFileIndex(string name)
    {
        return NativeCalls.godot_icall_1_134(MethodBind12, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindDirIndex, 1321353865ul);

    /// <summary>
    /// <para>Returns the index of the directory with name <paramref name="name"/> or <c>-1</c> if not found.</para>
    /// </summary>
    public int FindDirIndex(string name)
    {
        return NativeCalls.godot_icall_1_134(MethodBind13, GodotObject.GetPtr(this), name);
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_subdir_count' method.
        /// </summary>
        public static readonly StringName GetSubdirCount = "get_subdir_count";
        /// <summary>
        /// Cached name for the 'get_subdir' method.
        /// </summary>
        public static readonly StringName GetSubdir = "get_subdir";
        /// <summary>
        /// Cached name for the 'get_file_count' method.
        /// </summary>
        public static readonly StringName GetFileCount = "get_file_count";
        /// <summary>
        /// Cached name for the 'get_file' method.
        /// </summary>
        public static readonly StringName GetFile = "get_file";
        /// <summary>
        /// Cached name for the 'get_file_path' method.
        /// </summary>
        public static readonly StringName GetFilePath = "get_file_path";
        /// <summary>
        /// Cached name for the 'get_file_type' method.
        /// </summary>
        public static readonly StringName GetFileType = "get_file_type";
        /// <summary>
        /// Cached name for the 'get_file_script_class_name' method.
        /// </summary>
        public static readonly StringName GetFileScriptClassName = "get_file_script_class_name";
        /// <summary>
        /// Cached name for the 'get_file_script_class_extends' method.
        /// </summary>
        public static readonly StringName GetFileScriptClassExtends = "get_file_script_class_extends";
        /// <summary>
        /// Cached name for the 'get_file_import_is_valid' method.
        /// </summary>
        public static readonly StringName GetFileImportIsValid = "get_file_import_is_valid";
        /// <summary>
        /// Cached name for the 'get_name' method.
        /// </summary>
        public static readonly StringName GetName = "get_name";
        /// <summary>
        /// Cached name for the 'get_path' method.
        /// </summary>
        public static readonly StringName GetPath = "get_path";
        /// <summary>
        /// Cached name for the 'get_parent' method.
        /// </summary>
        public static readonly StringName GetParent = "get_parent";
        /// <summary>
        /// Cached name for the 'find_file_index' method.
        /// </summary>
        public static readonly StringName FindFileIndex = "find_file_index";
        /// <summary>
        /// Cached name for the 'find_dir_index' method.
        /// </summary>
        public static readonly StringName FindDirIndex = "find_dir_index";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
