namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>External <see cref="Godot.EditorExportPlatform"/> implementations should inherit from this class.</para>
/// <para>To use <see cref="Godot.EditorExportPlatform"/>, register it using the <see cref="Godot.EditorPlugin.AddExportPlatform(EditorExportPlatform)"/> method first.</para>
/// </summary>
public partial class EditorExportPlatformExtension : EditorExportPlatform
{
    private static readonly System.Type CachedType = typeof(EditorExportPlatformExtension);

    private static readonly StringName NativeName = "EditorExportPlatformExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorExportPlatformExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorExportPlatformExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorExportPlatformExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified <paramref name="preset"/> is valid and can be exported. Use <see cref="Godot.EditorExportPlatformExtension.SetConfigError(string)"/> and <see cref="Godot.EditorExportPlatformExtension.SetConfigMissingTemplates(bool)"/> to set error details.</para>
    /// <para>Usual implementations call <see cref="Godot.EditorExportPlatformExtension._HasValidExportConfiguration(EditorExportPreset, bool)"/> and <see cref="Godot.EditorExportPlatformExtension._HasValidProjectConfiguration(EditorExportPreset)"/> to determine if exporting is possible.</para>
    /// </summary>
    public virtual bool _CanExport(EditorExportPreset preset, bool debug)
    {
        return default;
    }

    /// <summary>
    /// <para>Called by the editor before platform is unregistered.</para>
    /// </summary>
    public virtual void _Cleanup()
    {
    }

    /// <summary>
    /// <para>Creates a PCK archive at <paramref name="path"/> for the specified <paramref name="preset"/>.</para>
    /// <para>This method is called when "Export PCK/ZIP" button is pressed in the export dialog, with "Export as Patch" disabled, and PCK is selected as a file type.</para>
    /// </summary>
    public virtual Error _ExportPack(EditorExportPreset preset, bool debug, string path, EditorExportPlatform.DebugFlags flags)
    {
        return default;
    }

    /// <summary>
    /// <para>Creates a patch PCK archive at <paramref name="path"/> for the specified <paramref name="preset"/>, containing only the files that have changed since the last patch.</para>
    /// <para>This method is called when "Export PCK/ZIP" button is pressed in the export dialog, with "Export as Patch" enabled, and PCK is selected as a file type.</para>
    /// <para><b>Note:</b> The patches provided in <paramref name="patches"/> have already been loaded when this method is called and are merely provided as context. When empty the patches defined in the export preset have been loaded instead.</para>
    /// </summary>
    public virtual Error _ExportPackPatch(EditorExportPreset preset, bool debug, string path, string[] patches, EditorExportPlatform.DebugFlags flags)
    {
        return default;
    }

    /// <summary>
    /// <para>Creates a full project at <paramref name="path"/> for the specified <paramref name="preset"/>.</para>
    /// <para>This method is called when "Export" button is pressed in the export dialog.</para>
    /// <para>This method implementation can call <see cref="Godot.EditorExportPlatform.SavePack(EditorExportPreset, bool, string, bool)"/> or <see cref="Godot.EditorExportPlatform.SaveZip(EditorExportPreset, bool, string)"/> to use default PCK/ZIP export process, or calls <see cref="Godot.EditorExportPlatform.ExportProjectFiles(EditorExportPreset, bool, Callable, Callable)"/> and implement custom callback for processing each exported file.</para>
    /// </summary>
    public virtual Error _ExportProject(EditorExportPreset preset, bool debug, string path, EditorExportPlatform.DebugFlags flags)
    {
        return default;
    }

    /// <summary>
    /// <para>Create a ZIP archive at <paramref name="path"/> for the specified <paramref name="preset"/>.</para>
    /// <para>This method is called when "Export PCK/ZIP" button is pressed in the export dialog, with "Export as Patch" disabled, and ZIP is selected as a file type.</para>
    /// </summary>
    public virtual Error _ExportZip(EditorExportPreset preset, bool debug, string path, EditorExportPlatform.DebugFlags flags)
    {
        return default;
    }

    /// <summary>
    /// <para>Create a ZIP archive at <paramref name="path"/> for the specified <paramref name="preset"/>, containing only the files that have changed since the last patch.</para>
    /// <para>This method is called when "Export PCK/ZIP" button is pressed in the export dialog, with "Export as Patch" enabled, and ZIP is selected as a file type.</para>
    /// <para><b>Note:</b> The patches provided in <paramref name="patches"/> have already been loaded when this method is called and are merely provided as context. When empty the patches defined in the export preset have been loaded instead.</para>
    /// </summary>
    public virtual Error _ExportZipPatch(EditorExportPreset preset, bool debug, string path, string[] patches, EditorExportPlatform.DebugFlags flags)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns array of supported binary extensions for the full project export.</para>
    /// </summary>
    public virtual string[] _GetBinaryExtensions(EditorExportPreset preset)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns protocol used for remote debugging. Default implementation return <c>tcp://</c>.</para>
    /// </summary>
    public virtual string _GetDebugProtocol()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns device architecture for one-click deploy.</para>
    /// </summary>
    public virtual string _GetDeviceArchitecture(int device)
    {
        return default;
    }

    /// <summary>
    /// <para>Validates <paramref name="option"/> and returns visibility for the specified <paramref name="preset"/>. Default implementation return <see langword="true"/> for all options.</para>
    /// </summary>
    public virtual bool _GetExportOptionVisibility(EditorExportPreset preset, string option)
    {
        return default;
    }

    /// <summary>
    /// <para>Validates <paramref name="option"/> and returns warning message for the specified <paramref name="preset"/>. Default implementation return empty string for all options.</para>
    /// </summary>
    public virtual string _GetExportOptionWarning(EditorExportPreset preset, StringName option)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns a property list, as an <see cref="Godot.Collections.Array"/> of dictionaries. Each <see cref="Godot.Collections.Dictionary"/> must at least contain the <c>name: StringName</c> and <c>type: Variant.Type</c> entries.</para>
    /// <para>Additionally, the following keys are supported:</para>
    /// <para>- <c>hint: PropertyHint</c></para>
    /// <para>- <c>hint_string: String</c></para>
    /// <para>- <c>usage: PropertyUsageFlags</c></para>
    /// <para>- <c>class_name: StringName</c></para>
    /// <para>- <c>default_value: Variant</c>, default value of the property.</para>
    /// <para>- <c>update_visibility: bool</c>, if set to <see langword="true"/>, <see cref="Godot.EditorExportPlatformExtension._GetExportOptionVisibility(EditorExportPreset, string)"/> is called for each property when this property is changed.</para>
    /// <para>- <c>required: bool</c>, if set to <see langword="true"/>, this property warnings are critical, and should be resolved to make export possible. This value is a hint for the <see cref="Godot.EditorExportPlatformExtension._HasValidExportConfiguration(EditorExportPreset, bool)"/> implementation, and not used by the engine directly.</para>
    /// <para>See also <see cref="Godot.GodotObject._GetPropertyList()"/>.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetExportOptions()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the platform logo displayed in the export dialog. The logo should be 32×32 pixels, adjusted for the current editor scale (see <see cref="Godot.EditorInterface.GetEditorScale()"/>).</para>
    /// </summary>
    public virtual Texture2D _GetLogo()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns export platform name.</para>
    /// </summary>
    public virtual string _GetName()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the item icon for the specified <paramref name="device"/> in the one-click deploy menu. The icon should be 16×16 pixels, adjusted for the current editor scale (see <see cref="Godot.EditorInterface.GetEditorScale()"/>).</para>
    /// </summary>
    public virtual Texture2D _GetOptionIcon(int device)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns one-click deploy menu item label for the specified <paramref name="device"/>.</para>
    /// </summary>
    public virtual string _GetOptionLabel(int device)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns one-click deploy menu item tooltip for the specified <paramref name="device"/>.</para>
    /// </summary>
    public virtual string _GetOptionTooltip(int device)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the number of devices (or other options) available in the one-click deploy menu.</para>
    /// </summary>
    public virtual int _GetOptionsCount()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns tooltip of the one-click deploy menu button.</para>
    /// </summary>
    public virtual string _GetOptionsTooltip()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns target OS name.</para>
    /// </summary>
    public virtual string _GetOsName()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns array of platform specific features.</para>
    /// </summary>
    public virtual string[] _GetPlatformFeatures()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns array of platform specific features for the specified <paramref name="preset"/>.</para>
    /// </summary>
    public virtual string[] _GetPresetFeatures(EditorExportPreset preset)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the icon of the one-click deploy menu button. The icon should be 16×16 pixels, adjusted for the current editor scale (see <see cref="Godot.EditorInterface.GetEditorScale()"/>).</para>
    /// </summary>
    public virtual Texture2D _GetRunIcon()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if export configuration is valid.</para>
    /// </summary>
    public virtual bool _HasValidExportConfiguration(EditorExportPreset preset, bool debug)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if project configuration is valid.</para>
    /// </summary>
    public virtual bool _HasValidProjectConfiguration(EditorExportPreset preset)
    {
        return default;
    }

    /// <summary>
    /// <para>Initializes the plugin. Called by the editor when platform is registered.</para>
    /// </summary>
    public virtual void _Initialize()
    {
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if specified file is a valid executable (native executable or script) for the target platform.</para>
    /// </summary>
    public virtual bool _IsExecutable(string path)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if one-click deploy options are changed and editor interface should be updated.</para>
    /// </summary>
    public virtual bool _PollExport()
    {
        return default;
    }

    /// <summary>
    /// <para>This method is called when <paramref name="device"/> one-click deploy menu option is selected.</para>
    /// <para>Implementation should export project to a temporary location, upload and run it on the specific <paramref name="device"/>, or perform another action associated with the menu item.</para>
    /// </summary>
    public virtual Error _Run(EditorExportPreset preset, int device, EditorExportPlatform.DebugFlags debugFlags)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if export options list is changed and presets should be updated.</para>
    /// </summary>
    public virtual bool _ShouldUpdateExportOptions()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConfigError, 3089850668ul);

    /// <summary>
    /// <para>Sets current configuration error message text. This method should be called only from the <see cref="Godot.EditorExportPlatformExtension._CanExport(EditorExportPreset, bool)"/>, <see cref="Godot.EditorExportPlatformExtension._HasValidExportConfiguration(EditorExportPreset, bool)"/>, or <see cref="Godot.EditorExportPlatformExtension._HasValidProjectConfiguration(EditorExportPreset)"/> implementations.</para>
    /// </summary>
    public void SetConfigError(string errorText)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), errorText);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConfigError, 201670096ul);

    /// <summary>
    /// <para>Returns current configuration error message text. This method should be called only from the <see cref="Godot.EditorExportPlatformExtension._CanExport(EditorExportPreset, bool)"/>, <see cref="Godot.EditorExportPlatformExtension._HasValidExportConfiguration(EditorExportPreset, bool)"/>, or <see cref="Godot.EditorExportPlatformExtension._HasValidProjectConfiguration(EditorExportPreset)"/> implementations.</para>
    /// </summary>
    public string GetConfigError()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConfigMissingTemplates, 1695273946ul);

    /// <summary>
    /// <para>Set to <see langword="true"/> is export templates are missing from the current configuration. This method should be called only from the <see cref="Godot.EditorExportPlatformExtension._CanExport(EditorExportPreset, bool)"/>, <see cref="Godot.EditorExportPlatformExtension._HasValidExportConfiguration(EditorExportPreset, bool)"/>, or <see cref="Godot.EditorExportPlatformExtension._HasValidProjectConfiguration(EditorExportPreset)"/> implementations.</para>
    /// </summary>
    public void SetConfigMissingTemplates(bool missingTemplates)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), missingTemplates.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConfigMissingTemplates, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> is export templates are missing from the current configuration. This method should be called only from the <see cref="Godot.EditorExportPlatformExtension._CanExport(EditorExportPreset, bool)"/>, <see cref="Godot.EditorExportPlatformExtension._HasValidExportConfiguration(EditorExportPreset, bool)"/>, or <see cref="Godot.EditorExportPlatformExtension._HasValidProjectConfiguration(EditorExportPreset)"/> implementations.</para>
    /// </summary>
    public bool GetConfigMissingTemplates()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__can_export = "_CanExport";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__cleanup = "_Cleanup";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_pack = "_ExportPack";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_pack_patch = "_ExportPackPatch";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_project = "_ExportProject";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_zip = "_ExportZip";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_zip_patch = "_ExportZipPatch";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_binary_extensions = "_GetBinaryExtensions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_debug_protocol = "_GetDebugProtocol";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_device_architecture = "_GetDeviceArchitecture";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_export_option_visibility = "_GetExportOptionVisibility";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_export_option_warning = "_GetExportOptionWarning";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_export_options = "_GetExportOptions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_logo = "_GetLogo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_name = "_GetName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_option_icon = "_GetOptionIcon";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_option_label = "_GetOptionLabel";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_option_tooltip = "_GetOptionTooltip";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_options_count = "_GetOptionsCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_options_tooltip = "_GetOptionsTooltip";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_os_name = "_GetOsName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_platform_features = "_GetPlatformFeatures";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_preset_features = "_GetPresetFeatures";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_run_icon = "_GetRunIcon";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_valid_export_configuration = "_HasValidExportConfiguration";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_valid_project_configuration = "_HasValidProjectConfiguration";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__initialize = "_Initialize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_executable = "_IsExecutable";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__poll_export = "_PollExport";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__run = "_Run";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__should_update_export_options = "_ShouldUpdateExportOptions";

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
        if ((method == MethodProxyName__can_export || method == MethodName._CanExport) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__can_export.NativeValue))
        {
            var callRet = _CanExport(VariantUtils.ConvertTo<EditorExportPreset>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__cleanup || method == MethodName._Cleanup) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__cleanup.NativeValue))
        {
            _Cleanup();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__export_pack || method == MethodName._ExportPack) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_pack.NativeValue))
        {
            var callRet = _ExportPack(VariantUtils.ConvertTo<EditorExportPreset>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<EditorExportPlatform.DebugFlags>(args[3]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__export_pack_patch || method == MethodName._ExportPackPatch) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_pack_patch.NativeValue))
        {
            var callRet = _ExportPackPatch(VariantUtils.ConvertTo<EditorExportPreset>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<string[]>(args[3]), VariantUtils.ConvertTo<EditorExportPlatform.DebugFlags>(args[4]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__export_project || method == MethodName._ExportProject) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_project.NativeValue))
        {
            var callRet = _ExportProject(VariantUtils.ConvertTo<EditorExportPreset>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<EditorExportPlatform.DebugFlags>(args[3]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__export_zip || method == MethodName._ExportZip) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_zip.NativeValue))
        {
            var callRet = _ExportZip(VariantUtils.ConvertTo<EditorExportPreset>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<EditorExportPlatform.DebugFlags>(args[3]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__export_zip_patch || method == MethodName._ExportZipPatch) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_zip_patch.NativeValue))
        {
            var callRet = _ExportZipPatch(VariantUtils.ConvertTo<EditorExportPreset>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<string[]>(args[3]), VariantUtils.ConvertTo<EditorExportPlatform.DebugFlags>(args[4]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_binary_extensions || method == MethodName._GetBinaryExtensions) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_binary_extensions.NativeValue))
        {
            var callRet = _GetBinaryExtensions(VariantUtils.ConvertTo<EditorExportPreset>(args[0]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_debug_protocol || method == MethodName._GetDebugProtocol) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_debug_protocol.NativeValue))
        {
            var callRet = _GetDebugProtocol();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_device_architecture || method == MethodName._GetDeviceArchitecture) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_device_architecture.NativeValue))
        {
            var callRet = _GetDeviceArchitecture(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_export_option_visibility || method == MethodName._GetExportOptionVisibility) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_export_option_visibility.NativeValue))
        {
            var callRet = _GetExportOptionVisibility(VariantUtils.ConvertTo<EditorExportPreset>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_export_option_warning || method == MethodName._GetExportOptionWarning) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_export_option_warning.NativeValue))
        {
            var callRet = _GetExportOptionWarning(VariantUtils.ConvertTo<EditorExportPreset>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_export_options || method == MethodName._GetExportOptions) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_export_options.NativeValue))
        {
            var callRet = _GetExportOptions();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_logo || method == MethodName._GetLogo) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_logo.NativeValue))
        {
            var callRet = _GetLogo();
            ret = VariantUtils.CreateFrom<Texture2D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_name || method == MethodName._GetName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_name.NativeValue))
        {
            var callRet = _GetName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_option_icon || method == MethodName._GetOptionIcon) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_option_icon.NativeValue))
        {
            var callRet = _GetOptionIcon(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<Texture2D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_option_label || method == MethodName._GetOptionLabel) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_option_label.NativeValue))
        {
            var callRet = _GetOptionLabel(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_option_tooltip || method == MethodName._GetOptionTooltip) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_option_tooltip.NativeValue))
        {
            var callRet = _GetOptionTooltip(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_options_count || method == MethodName._GetOptionsCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_options_count.NativeValue))
        {
            var callRet = _GetOptionsCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_options_tooltip || method == MethodName._GetOptionsTooltip) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_options_tooltip.NativeValue))
        {
            var callRet = _GetOptionsTooltip();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_os_name || method == MethodName._GetOsName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_os_name.NativeValue))
        {
            var callRet = _GetOsName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_platform_features || method == MethodName._GetPlatformFeatures) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_platform_features.NativeValue))
        {
            var callRet = _GetPlatformFeatures();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_preset_features || method == MethodName._GetPresetFeatures) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_preset_features.NativeValue))
        {
            var callRet = _GetPresetFeatures(VariantUtils.ConvertTo<EditorExportPreset>(args[0]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_run_icon || method == MethodName._GetRunIcon) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_run_icon.NativeValue))
        {
            var callRet = _GetRunIcon();
            ret = VariantUtils.CreateFrom<Texture2D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_valid_export_configuration || method == MethodName._HasValidExportConfiguration) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_valid_export_configuration.NativeValue))
        {
            var callRet = _HasValidExportConfiguration(VariantUtils.ConvertTo<EditorExportPreset>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_valid_project_configuration || method == MethodName._HasValidProjectConfiguration) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_valid_project_configuration.NativeValue))
        {
            var callRet = _HasValidProjectConfiguration(VariantUtils.ConvertTo<EditorExportPreset>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__initialize || method == MethodName._Initialize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__initialize.NativeValue))
        {
            _Initialize();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__is_executable || method == MethodName._IsExecutable) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_executable.NativeValue))
        {
            var callRet = _IsExecutable(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__poll_export || method == MethodName._PollExport) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__poll_export.NativeValue))
        {
            var callRet = _PollExport();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__run || method == MethodName._Run) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__run.NativeValue))
        {
            var callRet = _Run(VariantUtils.ConvertTo<EditorExportPreset>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<EditorExportPlatform.DebugFlags>(args[2]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__should_update_export_options || method == MethodName._ShouldUpdateExportOptions) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__should_update_export_options.NativeValue))
        {
            var callRet = _ShouldUpdateExportOptions();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
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
        if (method == MethodName._CanExport)
        {
            if (HasGodotClassMethod(MethodProxyName__can_export.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Cleanup)
        {
            if (HasGodotClassMethod(MethodProxyName__cleanup.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportPack)
        {
            if (HasGodotClassMethod(MethodProxyName__export_pack.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportPackPatch)
        {
            if (HasGodotClassMethod(MethodProxyName__export_pack_patch.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportProject)
        {
            if (HasGodotClassMethod(MethodProxyName__export_project.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportZip)
        {
            if (HasGodotClassMethod(MethodProxyName__export_zip.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportZipPatch)
        {
            if (HasGodotClassMethod(MethodProxyName__export_zip_patch.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetBinaryExtensions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_binary_extensions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDebugProtocol)
        {
            if (HasGodotClassMethod(MethodProxyName__get_debug_protocol.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDeviceArchitecture)
        {
            if (HasGodotClassMethod(MethodProxyName__get_device_architecture.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetExportOptionVisibility)
        {
            if (HasGodotClassMethod(MethodProxyName__get_export_option_visibility.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetExportOptionWarning)
        {
            if (HasGodotClassMethod(MethodProxyName__get_export_option_warning.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetExportOptions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_export_options.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetLogo)
        {
            if (HasGodotClassMethod(MethodProxyName__get_logo.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOptionIcon)
        {
            if (HasGodotClassMethod(MethodProxyName__get_option_icon.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOptionLabel)
        {
            if (HasGodotClassMethod(MethodProxyName__get_option_label.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOptionTooltip)
        {
            if (HasGodotClassMethod(MethodProxyName__get_option_tooltip.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOptionsCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_options_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOptionsTooltip)
        {
            if (HasGodotClassMethod(MethodProxyName__get_options_tooltip.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOsName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_os_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPlatformFeatures)
        {
            if (HasGodotClassMethod(MethodProxyName__get_platform_features.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPresetFeatures)
        {
            if (HasGodotClassMethod(MethodProxyName__get_preset_features.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetRunIcon)
        {
            if (HasGodotClassMethod(MethodProxyName__get_run_icon.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasValidExportConfiguration)
        {
            if (HasGodotClassMethod(MethodProxyName__has_valid_export_configuration.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasValidProjectConfiguration)
        {
            if (HasGodotClassMethod(MethodProxyName__has_valid_project_configuration.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Initialize)
        {
            if (HasGodotClassMethod(MethodProxyName__initialize.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsExecutable)
        {
            if (HasGodotClassMethod(MethodProxyName__is_executable.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PollExport)
        {
            if (HasGodotClassMethod(MethodProxyName__poll_export.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Run)
        {
            if (HasGodotClassMethod(MethodProxyName__run.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShouldUpdateExportOptions)
        {
            if (HasGodotClassMethod(MethodProxyName__should_update_export_options.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
    public new class PropertyName : EditorExportPlatform.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : EditorExportPlatform.MethodName
    {
        /// <summary>
        /// Cached name for the '_can_export' method.
        /// </summary>
        public static readonly StringName _CanExport = "_can_export";
        /// <summary>
        /// Cached name for the '_cleanup' method.
        /// </summary>
        public static readonly StringName _Cleanup = "_cleanup";
        /// <summary>
        /// Cached name for the '_export_pack' method.
        /// </summary>
        public static readonly StringName _ExportPack = "_export_pack";
        /// <summary>
        /// Cached name for the '_export_pack_patch' method.
        /// </summary>
        public static readonly StringName _ExportPackPatch = "_export_pack_patch";
        /// <summary>
        /// Cached name for the '_export_project' method.
        /// </summary>
        public static readonly StringName _ExportProject = "_export_project";
        /// <summary>
        /// Cached name for the '_export_zip' method.
        /// </summary>
        public static readonly StringName _ExportZip = "_export_zip";
        /// <summary>
        /// Cached name for the '_export_zip_patch' method.
        /// </summary>
        public static readonly StringName _ExportZipPatch = "_export_zip_patch";
        /// <summary>
        /// Cached name for the '_get_binary_extensions' method.
        /// </summary>
        public static readonly StringName _GetBinaryExtensions = "_get_binary_extensions";
        /// <summary>
        /// Cached name for the '_get_debug_protocol' method.
        /// </summary>
        public static readonly StringName _GetDebugProtocol = "_get_debug_protocol";
        /// <summary>
        /// Cached name for the '_get_device_architecture' method.
        /// </summary>
        public static readonly StringName _GetDeviceArchitecture = "_get_device_architecture";
        /// <summary>
        /// Cached name for the '_get_export_option_visibility' method.
        /// </summary>
        public static readonly StringName _GetExportOptionVisibility = "_get_export_option_visibility";
        /// <summary>
        /// Cached name for the '_get_export_option_warning' method.
        /// </summary>
        public static readonly StringName _GetExportOptionWarning = "_get_export_option_warning";
        /// <summary>
        /// Cached name for the '_get_export_options' method.
        /// </summary>
        public static readonly StringName _GetExportOptions = "_get_export_options";
        /// <summary>
        /// Cached name for the '_get_logo' method.
        /// </summary>
        public static readonly StringName _GetLogo = "_get_logo";
        /// <summary>
        /// Cached name for the '_get_name' method.
        /// </summary>
        public static readonly StringName _GetName = "_get_name";
        /// <summary>
        /// Cached name for the '_get_option_icon' method.
        /// </summary>
        public static readonly StringName _GetOptionIcon = "_get_option_icon";
        /// <summary>
        /// Cached name for the '_get_option_label' method.
        /// </summary>
        public static readonly StringName _GetOptionLabel = "_get_option_label";
        /// <summary>
        /// Cached name for the '_get_option_tooltip' method.
        /// </summary>
        public static readonly StringName _GetOptionTooltip = "_get_option_tooltip";
        /// <summary>
        /// Cached name for the '_get_options_count' method.
        /// </summary>
        public static readonly StringName _GetOptionsCount = "_get_options_count";
        /// <summary>
        /// Cached name for the '_get_options_tooltip' method.
        /// </summary>
        public static readonly StringName _GetOptionsTooltip = "_get_options_tooltip";
        /// <summary>
        /// Cached name for the '_get_os_name' method.
        /// </summary>
        public static readonly StringName _GetOsName = "_get_os_name";
        /// <summary>
        /// Cached name for the '_get_platform_features' method.
        /// </summary>
        public static readonly StringName _GetPlatformFeatures = "_get_platform_features";
        /// <summary>
        /// Cached name for the '_get_preset_features' method.
        /// </summary>
        public static readonly StringName _GetPresetFeatures = "_get_preset_features";
        /// <summary>
        /// Cached name for the '_get_run_icon' method.
        /// </summary>
        public static readonly StringName _GetRunIcon = "_get_run_icon";
        /// <summary>
        /// Cached name for the '_has_valid_export_configuration' method.
        /// </summary>
        public static readonly StringName _HasValidExportConfiguration = "_has_valid_export_configuration";
        /// <summary>
        /// Cached name for the '_has_valid_project_configuration' method.
        /// </summary>
        public static readonly StringName _HasValidProjectConfiguration = "_has_valid_project_configuration";
        /// <summary>
        /// Cached name for the '_initialize' method.
        /// </summary>
        public static readonly StringName _Initialize = "_initialize";
        /// <summary>
        /// Cached name for the '_is_executable' method.
        /// </summary>
        public static readonly StringName _IsExecutable = "_is_executable";
        /// <summary>
        /// Cached name for the '_poll_export' method.
        /// </summary>
        public static readonly StringName _PollExport = "_poll_export";
        /// <summary>
        /// Cached name for the '_run' method.
        /// </summary>
        public static readonly StringName _Run = "_run";
        /// <summary>
        /// Cached name for the '_should_update_export_options' method.
        /// </summary>
        public static readonly StringName _ShouldUpdateExportOptions = "_should_update_export_options";
        /// <summary>
        /// Cached name for the 'set_config_error' method.
        /// </summary>
        public static readonly StringName SetConfigError = "set_config_error";
        /// <summary>
        /// Cached name for the 'get_config_error' method.
        /// </summary>
        public static readonly StringName GetConfigError = "get_config_error";
        /// <summary>
        /// Cached name for the 'set_config_missing_templates' method.
        /// </summary>
        public static readonly StringName SetConfigMissingTemplates = "set_config_missing_templates";
        /// <summary>
        /// Cached name for the 'get_config_missing_templates' method.
        /// </summary>
        public static readonly StringName GetConfigMissingTemplates = "get_config_missing_templates";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : EditorExportPlatform.SignalName
    {
    }
}
