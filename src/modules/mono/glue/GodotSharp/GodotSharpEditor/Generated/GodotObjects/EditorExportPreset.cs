namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Represents the configuration of an export preset, as created by the editor's export dialog. An <see cref="Godot.EditorExportPreset"/> instance is intended to be used a read-only configuration passed to the <see cref="Godot.EditorExportPlatform"/> methods when exporting the project.</para>
/// </summary>
public partial class EditorExportPreset : RefCounted
{
    public enum ExportFilter : long
    {
        ExportAllResources = 0,
        ExportSelectedScenes = 1,
        ExportSelectedResources = 2,
        ExcludeSelectedResources = 3,
        ExportCustomized = 4
    }

    public enum FileExportMode : long
    {
        NotCustomized = 0,
        Strip = 1,
        Keep = 2,
        Remove = 3
    }

    public enum ScriptExportMode : long
    {
        Text = 0,
        BinaryTokens = 1,
        BinaryTokensCompressed = 2
    }

    private static readonly System.Type CachedType = typeof(EditorExportPreset);

    private static readonly StringName NativeName = "EditorExportPreset";

    internal EditorExportPreset() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorExportPreset(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorExportPreset(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Has, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the preset has the property named <paramref name="property"/>.</para>
    /// </summary>
    public bool Has(StringName property)
    {
        return NativeCalls.godot_icall_1_105(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(property?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilesToExport, 1139954409ul);

    /// <summary>
    /// <para>Returns array of files to export.</para>
    /// </summary>
    public string[] GetFilesToExport()
    {
        return NativeCalls.godot_icall_0_108(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomizedFiles, 3102165223ul);

    /// <summary>
    /// <para>Returns a dictionary of files selected in the "Resources" tab of the export dialog. The dictionary's keys are file paths, and its values are the corresponding export modes: <c>"strip"</c>, <c>"keep"</c>, or <c>"remove"</c>. See also <see cref="Godot.EditorExportPreset.GetFileExportMode(string, EditorExportPreset.FileExportMode)"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetCustomizedFiles()
    {
        return NativeCalls.godot_icall_0_122(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomizedFilesCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of files selected in the "Resources" tab of the export dialog.</para>
    /// </summary>
    public int GetCustomizedFilesCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasExportFile, 2323990056ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the file at the specified <paramref name="path"/> will be exported.</para>
    /// </summary>
    public bool HasExportFile(string path)
    {
        return NativeCalls.godot_icall_1_131(MethodBind4, GodotObject.GetPtr(this), path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFileExportMode, 407825436ul);

    /// <summary>
    /// <para>Returns file export mode for the specified file.</para>
    /// </summary>
    public EditorExportPreset.FileExportMode GetFileExportMode(string path, EditorExportPreset.FileExportMode @default = (EditorExportPreset.FileExportMode)(0))
    {
        return (EditorExportPreset.FileExportMode)NativeCalls.godot_icall_2_387(MethodBind5, GodotObject.GetPtr(this), path, (int)@default);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjectSetting, 2138907829ul);

    /// <summary>
    /// <para>Returns the value of the setting identified by <paramref name="name"/> using export preset feature tag overrides instead of current OS features.</para>
    /// </summary>
    public Variant GetProjectSetting(StringName name)
    {
        return NativeCalls.godot_icall_1_143(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPresetName, 201670096ul);

    /// <summary>
    /// <para>Returns this export preset's name.</para>
    /// </summary>
    public string GetPresetName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRunnable, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the "Runnable" toggle is enabled in the export dialog.</para>
    /// </summary>
    public bool IsRunnable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreAdvancedOptionsEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the "Advanced" toggle is enabled in the export dialog.</para>
    /// </summary>
    public bool AreAdvancedOptionsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDedicatedServer, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the dedicated server export mode is selected in the export dialog.</para>
    /// </summary>
    public bool IsDedicatedServer()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExportFilter, 4227045696ul);

    /// <summary>
    /// <para>Returns export file filter mode selected in the "Resources" tab of the export dialog.</para>
    /// </summary>
    public EditorExportPreset.ExportFilter GetExportFilter()
    {
        return (EditorExportPreset.ExportFilter)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIncludeFilter, 201670096ul);

    /// <summary>
    /// <para>Returns file filters to include during export.</para>
    /// </summary>
    public string GetIncludeFilter()
    {
        return NativeCalls.godot_icall_0_58(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExcludeFilter, 201670096ul);

    /// <summary>
    /// <para>Returns file filters to exclude during export.</para>
    /// </summary>
    public string GetExcludeFilter()
    {
        return NativeCalls.godot_icall_0_58(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomFeatures, 201670096ul);

    /// <summary>
    /// <para>Returns a comma-separated list of custom features added to this preset, as a string. See <a href="$DOCS_URL/tutorials/export/feature_tags.html">Feature tags</a> in the documentation for more information.</para>
    /// </summary>
    public string GetCustomFeatures()
    {
        return NativeCalls.godot_icall_0_58(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPatches, 1139954409ul);

    /// <summary>
    /// <para>Returns the list of packs on which to base a patch export on.</para>
    /// </summary>
    public string[] GetPatches()
    {
        return NativeCalls.godot_icall_0_108(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExportPath, 201670096ul);

    /// <summary>
    /// <para>Returns export target path.</para>
    /// </summary>
    public string GetExportPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEncryptionInFilter, 201670096ul);

    /// <summary>
    /// <para>Returns file filters to include during PCK encryption.</para>
    /// </summary>
    public string GetEncryptionInFilter()
    {
        return NativeCalls.godot_icall_0_58(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEncryptionExFilter, 201670096ul);

    /// <summary>
    /// <para>Returns file filters to exclude during PCK encryption.</para>
    /// </summary>
    public string GetEncryptionExFilter()
    {
        return NativeCalls.godot_icall_0_58(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEncryptPck, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if PCK encryption is enabled in the export dialog.</para>
    /// </summary>
    public bool GetEncryptPck()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEncryptDirectory, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if PCK directory encryption is enabled in the export dialog.</para>
    /// </summary>
    public bool GetEncryptDirectory()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEncryptionKey, 201670096ul);

    /// <summary>
    /// <para>Returns PCK encryption key.</para>
    /// </summary>
    public string GetEncryptionKey()
    {
        return NativeCalls.godot_icall_0_58(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptExportMode, 2835358398ul);

    /// <summary>
    /// <para>Returns the export mode used by GDScript files. <c>0</c> for "Text", <c>1</c> for "Binary tokens", and <c>2</c> for "Compressed binary tokens (smaller files)".</para>
    /// </summary>
    public EditorExportPreset.ScriptExportMode GetScriptExportMode()
    {
        return (EditorExportPreset.ScriptExportMode)NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOrEnv, 389838787ul);

    /// <summary>
    /// <para>Returns export option value or value of environment variable if it is set.</para>
    /// </summary>
    public Variant GetOrEnv(StringName name, string envVar)
    {
        return EditorNativeCalls.godot_icall_2_487(MethodBind23, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), envVar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVersion, 1132184663ul);

    /// <summary>
    /// <para>Returns the preset's version number, or fall back to the <c>ProjectSettings.application/config/version</c> project setting if set to an empty string.</para>
    /// <para>If <paramref name="windowsVersion"/> is <see langword="true"/>, formats the returned version number to be compatible with Windows executable metadata.</para>
    /// </summary>
    public string GetVersion(StringName name, bool windowsVersion)
    {
        return EditorNativeCalls.godot_icall_2_488(MethodBind24, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), windowsVersion.ToGodotBool());
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
        /// Cached name for the 'has' method.
        /// </summary>
        public static readonly StringName Has = "has";
        /// <summary>
        /// Cached name for the 'get_files_to_export' method.
        /// </summary>
        public static readonly StringName GetFilesToExport = "get_files_to_export";
        /// <summary>
        /// Cached name for the 'get_customized_files' method.
        /// </summary>
        public static readonly StringName GetCustomizedFiles = "get_customized_files";
        /// <summary>
        /// Cached name for the 'get_customized_files_count' method.
        /// </summary>
        public static readonly StringName GetCustomizedFilesCount = "get_customized_files_count";
        /// <summary>
        /// Cached name for the 'has_export_file' method.
        /// </summary>
        public static readonly StringName HasExportFile = "has_export_file";
        /// <summary>
        /// Cached name for the 'get_file_export_mode' method.
        /// </summary>
        public static readonly StringName GetFileExportMode = "get_file_export_mode";
        /// <summary>
        /// Cached name for the 'get_project_setting' method.
        /// </summary>
        public static readonly StringName GetProjectSetting = "get_project_setting";
        /// <summary>
        /// Cached name for the 'get_preset_name' method.
        /// </summary>
        public static readonly StringName GetPresetName = "get_preset_name";
        /// <summary>
        /// Cached name for the 'is_runnable' method.
        /// </summary>
        public static readonly StringName IsRunnable = "is_runnable";
        /// <summary>
        /// Cached name for the 'are_advanced_options_enabled' method.
        /// </summary>
        public static readonly StringName AreAdvancedOptionsEnabled = "are_advanced_options_enabled";
        /// <summary>
        /// Cached name for the 'is_dedicated_server' method.
        /// </summary>
        public static readonly StringName IsDedicatedServer = "is_dedicated_server";
        /// <summary>
        /// Cached name for the 'get_export_filter' method.
        /// </summary>
        public static readonly StringName GetExportFilter = "get_export_filter";
        /// <summary>
        /// Cached name for the 'get_include_filter' method.
        /// </summary>
        public static readonly StringName GetIncludeFilter = "get_include_filter";
        /// <summary>
        /// Cached name for the 'get_exclude_filter' method.
        /// </summary>
        public static readonly StringName GetExcludeFilter = "get_exclude_filter";
        /// <summary>
        /// Cached name for the 'get_custom_features' method.
        /// </summary>
        public static readonly StringName GetCustomFeatures = "get_custom_features";
        /// <summary>
        /// Cached name for the 'get_patches' method.
        /// </summary>
        public static readonly StringName GetPatches = "get_patches";
        /// <summary>
        /// Cached name for the 'get_export_path' method.
        /// </summary>
        public static readonly StringName GetExportPath = "get_export_path";
        /// <summary>
        /// Cached name for the 'get_encryption_in_filter' method.
        /// </summary>
        public static readonly StringName GetEncryptionInFilter = "get_encryption_in_filter";
        /// <summary>
        /// Cached name for the 'get_encryption_ex_filter' method.
        /// </summary>
        public static readonly StringName GetEncryptionExFilter = "get_encryption_ex_filter";
        /// <summary>
        /// Cached name for the 'get_encrypt_pck' method.
        /// </summary>
        public static readonly StringName GetEncryptPck = "get_encrypt_pck";
        /// <summary>
        /// Cached name for the 'get_encrypt_directory' method.
        /// </summary>
        public static readonly StringName GetEncryptDirectory = "get_encrypt_directory";
        /// <summary>
        /// Cached name for the 'get_encryption_key' method.
        /// </summary>
        public static readonly StringName GetEncryptionKey = "get_encryption_key";
        /// <summary>
        /// Cached name for the 'get_script_export_mode' method.
        /// </summary>
        public static readonly StringName GetScriptExportMode = "get_script_export_mode";
        /// <summary>
        /// Cached name for the 'get_or_env' method.
        /// </summary>
        public static readonly StringName GetOrEnv = "get_or_env";
        /// <summary>
        /// Cached name for the 'get_version' method.
        /// </summary>
        public static readonly StringName GetVersion = "get_version";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
