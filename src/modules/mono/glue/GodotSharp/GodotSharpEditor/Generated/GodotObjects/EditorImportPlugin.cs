namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.EditorImportPlugin"/>s provide a way to extend the editor's resource import functionality. Use them to import resources from custom files or to provide alternatives to the editor's existing importers.</para>
/// <para>EditorImportPlugins work by associating with specific file extensions and a resource type. See <see cref="Godot.EditorImportPlugin._GetRecognizedExtensions()"/> and <see cref="Godot.EditorImportPlugin._GetResourceType()"/>. They may optionally specify some import presets that affect the import process. EditorImportPlugins are responsible for creating the resources and saving them in the <c>.godot/imported</c> directory (see <c>ProjectSettings.application/config/use_hidden_project_data_directory</c>).</para>
/// <para>Below is an example EditorImportPlugin that imports a <see cref="Godot.Mesh"/> from a file with the extension ".special" or ".spec":</para>
/// <para><code>
/// using Godot;
/// 
/// public partial class MySpecialPlugin : EditorImportPlugin
/// {
/// 	public override string _GetImporterName()
/// 	{
/// 		return "my.special.plugin";
/// 	}
/// 
/// 	public override string _GetVisibleName()
/// 	{
/// 		return "Special Mesh";
/// 	}
/// 
/// 	public override string[] _GetRecognizedExtensions()
/// 	{
/// 		return ["special", "spec"];
/// 	}
/// 
/// 	public override string _GetSaveExtension()
/// 	{
/// 		return "mesh";
/// 	}
/// 
/// 	public override string _GetResourceType()
/// 	{
/// 		return "Mesh";
/// 	}
/// 
/// 	public override int _GetPresetCount()
/// 	{
/// 		return 1;
/// 	}
/// 
/// 	public override string _GetPresetName(int presetIndex)
/// 	{
/// 		return "Default";
/// 	}
/// 
/// 	public override Godot.Collections.Array&lt;Godot.Collections.Dictionary&gt; _GetImportOptions(string path, int presetIndex)
/// 	{
/// 		return
/// 		[
/// 			new Godot.Collections.Dictionary
/// 			{
/// 				{ "name", "myOption" },
/// 				{ "default_value", false },
/// 			},
/// 		];
/// 	}
/// 
/// 	public override Error _Import(string sourceFile, string savePath, Godot.Collections.Dictionary options, Godot.Collections.Array&lt;string&gt; platformVariants, Godot.Collections.Array&lt;string&gt; genFiles)
/// 	{
/// 		using var file = FileAccess.Open(sourceFile, FileAccess.ModeFlags.Read);
/// 		if (file.GetError() != Error.Ok)
/// 		{
/// 			return Error.Failed;
/// 		}
/// 
/// 		var mesh = new ArrayMesh();
/// 		// Fill the Mesh with data read in "file", left as an exercise to the reader.
/// 		string filename = $"{savePath}.{_GetSaveExtension()}";
/// 		return ResourceSaver.Save(mesh, filename);
/// 	}
/// }
/// </code></para>
/// <para>To use <see cref="Godot.EditorImportPlugin"/>, register it using the <see cref="Godot.EditorPlugin.AddImportPlugin(EditorImportPlugin, bool)"/> method first.</para>
/// </summary>
public partial class EditorImportPlugin : ResourceImporter
{
    private static readonly System.Type CachedType = typeof(EditorImportPlugin);

    private static readonly StringName NativeName = "EditorImportPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorImportPlugin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorImportPlugin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorImportPlugin(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Tells whether this importer can be run in parallel on threads, or, on the contrary, it's only safe for the editor to call it from the main thread, for one file at a time.</para>
    /// <para>If this importer's implementation is thread-safe and can be run in parallel, override this with <see langword="true"/> to optimize for concurrency.</para>
    /// <para>If not overridden, returns <see langword="false"/>.</para>
    /// </summary>
    public virtual bool _CanImportThreaded()
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the format version of this importer. Increment this version when making incompatible changes to the format of the imported resources.</para>
    /// <para>If not overridden, the format version is <c>0</c>.</para>
    /// </summary>
    public virtual int _GetFormatVersion()
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the options and default values for the preset at this index. Returns an Array of Dictionaries with the following keys: <c>name</c>, <c>default_value</c>, <c>property_hint</c> (optional), <c>hint_string</c> (optional), <c>usage</c> (optional).</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetImportOptions(string path, int presetIndex)
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the order of this importer to be run when importing resources. Importers with <i>lower</i> import orders will be called first, and higher values will be called later. Use this to ensure the importer runs after the dependencies are already imported. The default import order is <c>0</c> unless overridden by a specific importer. See <see cref="Godot.ResourceImporter.ImportOrder"/> for some predefined values.</para>
    /// </summary>
    public virtual int _GetImportOrder()
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the unique name of the importer.</para>
    /// </summary>
    public virtual string _GetImporterName()
    {
        return default;
    }

    /// <summary>
    /// <para>Gets whether the import option specified by <paramref name="optionName"/> should be visible in the Import dock. The default implementation always returns <see langword="true"/>, making all options visible. This is mainly useful for hiding options that depend on others if one of them is disabled.</para>
    /// <para><code>
    /// public override bool _GetOptionVisibility(string path, StringName optionName, Godot.Collections.Dictionary options)
    /// {
    /// 	// Only show the lossy quality setting if the compression mode is set to "Lossy".
    /// 	if (optionName == "compress/lossy_quality" &amp;&amp; options.ContainsKey("compress/mode"))
    /// 	{
    /// 		return (int)options["compress/mode"] == CompressLossy; // This is a constant you set
    /// 	}
    /// 
    /// 	return true;
    /// }
    /// </code></para>
    /// </summary>
    public virtual bool _GetOptionVisibility(string path, StringName optionName, Godot.Collections.Dictionary options)
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the number of initial presets defined by the plugin. Use <see cref="Godot.EditorImportPlugin._GetImportOptions(string, int)"/> to get the default options for the preset and <see cref="Godot.EditorImportPlugin._GetPresetName(int)"/> to get the name of the preset.</para>
    /// <para>By default, there are no presets.</para>
    /// </summary>
    public virtual int _GetPresetCount()
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the name of the options preset at this index.</para>
    /// </summary>
    public virtual string _GetPresetName(int presetIndex)
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the priority of this plugin for the recognized extension. Higher priority plugins will be preferred. The default priority is <c>1.0</c>.</para>
    /// </summary>
    public virtual float _GetPriority()
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the list of file extensions to associate with this loader (case-insensitive). e.g. <c>["obj"]</c>.</para>
    /// </summary>
    public virtual string[] _GetRecognizedExtensions()
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the Godot resource type associated with this loader. e.g. <c>"Mesh"</c> or <c>"Animation"</c>.</para>
    /// </summary>
    public virtual string _GetResourceType()
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the extension used to save this resource in the <c>.godot/imported</c> directory (see <c>ProjectSettings.application/config/use_hidden_project_data_directory</c>).</para>
    /// </summary>
    public virtual string _GetSaveExtension()
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the name to display in the import window. You should choose this name as a continuation to "Import as", e.g. "Import as Special Mesh".</para>
    /// </summary>
    public virtual string _GetVisibleName()
    {
        return default;
    }

    /// <summary>
    /// <para>Imports <paramref name="sourceFile"/> with the import <paramref name="options"/> specified. Should return <see cref="Godot.Error.Ok"/> if the import is successful, other values indicate failure.</para>
    /// <para>The imported resource is expected to be saved to <c>save_path + "." + _get_save_extension()</c>. If a different variant is preferred for a <a href="$DOCS_URL/tutorials/export/feature_tags.html">feature tag</a>, save the variant to <c>save_path + "." + tag + "." + _get_save_extension()</c> and add the feature tag to <paramref name="platformVariants"/>.</para>
    /// <para>If additional resource files are generated in the resource filesystem (<c>res://</c>), add their full path to <paramref name="genFiles"/> so that the editor knows they depend on <paramref name="sourceFile"/>.</para>
    /// <para>This method must be overridden to do the actual importing work. See this class' description for an example of overriding this method.</para>
    /// </summary>
    public virtual Error _Import(string sourceFile, string savePath, Godot.Collections.Dictionary options, Godot.Collections.Array<string> platformVariants, Godot.Collections.Array<string> genFiles)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendImportExternalResource, 320493106ul);

    /// <summary>
    /// <para>This function can only be called during the <see cref="Godot.EditorImportPlugin._Import(string, string, Godot.Collections.Dictionary, Godot.Collections.Array{string}, Godot.Collections.Array{string})"/> callback and it allows manually importing resources from it. This is useful when the imported file generates external resources that require importing (as example, images). Custom parameters for the ".import" file can be passed via the <paramref name="customOptions"/>. Additionally, in cases where multiple importers can handle a file, the <paramref name="customImporter"/> can be specified to force a specific one. This function performs a resource import and returns immediately with a success or error code. <paramref name="generatorParameters"/> defines optional extra metadata which will be stored as <c>generator_parameters</c> in the <c>remap</c> section of the <c>.import</c> file, for example to store a md5 hash of the source data.</para>
    /// </summary>
    public Error AppendImportExternalResource(string path, Godot.Collections.Dictionary customOptions = null, string customImporter = "", Variant generatorParameters = default)
    {
        return (Error)EditorNativeCalls.godot_icall_4_491(MethodBind0, GodotObject.GetPtr(this), path, (godot_dictionary)(customOptions ?? new()).NativeValue, customImporter, generatorParameters);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__can_import_threaded = "_CanImportThreaded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_format_version = "_GetFormatVersion";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_import_options = "_GetImportOptions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_import_order = "_GetImportOrder";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_importer_name = "_GetImporterName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_option_visibility = "_GetOptionVisibility";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_preset_count = "_GetPresetCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_preset_name = "_GetPresetName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_priority = "_GetPriority";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_recognized_extensions = "_GetRecognizedExtensions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_resource_type = "_GetResourceType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_save_extension = "_GetSaveExtension";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_visible_name = "_GetVisibleName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__import = "_Import";

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
        if ((method == MethodProxyName__can_import_threaded || method == MethodName._CanImportThreaded) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__can_import_threaded.NativeValue))
        {
            var callRet = _CanImportThreaded();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_format_version || method == MethodName._GetFormatVersion) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_format_version.NativeValue))
        {
            var callRet = _GetFormatVersion();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_import_options || method == MethodName._GetImportOptions) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_import_options.NativeValue))
        {
            var callRet = _GetImportOptions(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_import_order || method == MethodName._GetImportOrder) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_import_order.NativeValue))
        {
            var callRet = _GetImportOrder();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_importer_name || method == MethodName._GetImporterName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_importer_name.NativeValue))
        {
            var callRet = _GetImporterName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_option_visibility || method == MethodName._GetOptionVisibility) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_option_visibility.NativeValue))
        {
            var callRet = _GetOptionVisibility(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[2]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_preset_count || method == MethodName._GetPresetCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_preset_count.NativeValue))
        {
            var callRet = _GetPresetCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_preset_name || method == MethodName._GetPresetName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_preset_name.NativeValue))
        {
            var callRet = _GetPresetName(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_priority || method == MethodName._GetPriority) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_priority.NativeValue))
        {
            var callRet = _GetPriority();
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_recognized_extensions || method == MethodName._GetRecognizedExtensions) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_recognized_extensions.NativeValue))
        {
            var callRet = _GetRecognizedExtensions();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_resource_type || method == MethodName._GetResourceType) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_resource_type.NativeValue))
        {
            var callRet = _GetResourceType();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_save_extension || method == MethodName._GetSaveExtension) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_save_extension.NativeValue))
        {
            var callRet = _GetSaveExtension();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_visible_name || method == MethodName._GetVisibleName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_visible_name.NativeValue))
        {
            var callRet = _GetVisibleName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__import || method == MethodName._Import) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__import.NativeValue))
        {
            var callRet = _Import(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[2]), new Godot.Collections.Array<string>(VariantUtils.ConvertToArray(args[3])), new Godot.Collections.Array<string>(VariantUtils.ConvertToArray(args[4])));
            ret = VariantUtils.CreateFrom<Error>(callRet);
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
        if (method == MethodName._CanImportThreaded)
        {
            if (HasGodotClassMethod(MethodProxyName__can_import_threaded.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetFormatVersion)
        {
            if (HasGodotClassMethod(MethodProxyName__get_format_version.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetImportOptions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_import_options.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetImportOrder)
        {
            if (HasGodotClassMethod(MethodProxyName__get_import_order.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetImporterName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_importer_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOptionVisibility)
        {
            if (HasGodotClassMethod(MethodProxyName__get_option_visibility.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPresetCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_preset_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPresetName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_preset_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPriority)
        {
            if (HasGodotClassMethod(MethodProxyName__get_priority.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetRecognizedExtensions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_recognized_extensions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetResourceType)
        {
            if (HasGodotClassMethod(MethodProxyName__get_resource_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSaveExtension)
        {
            if (HasGodotClassMethod(MethodProxyName__get_save_extension.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetVisibleName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_visible_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Import)
        {
            if (HasGodotClassMethod(MethodProxyName__import.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : ResourceImporter.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ResourceImporter.MethodName
    {
        /// <summary>
        /// Cached name for the '_can_import_threaded' method.
        /// </summary>
        public static readonly StringName _CanImportThreaded = "_can_import_threaded";
        /// <summary>
        /// Cached name for the '_get_format_version' method.
        /// </summary>
        public static readonly StringName _GetFormatVersion = "_get_format_version";
        /// <summary>
        /// Cached name for the '_get_import_options' method.
        /// </summary>
        public static readonly StringName _GetImportOptions = "_get_import_options";
        /// <summary>
        /// Cached name for the '_get_import_order' method.
        /// </summary>
        public static readonly StringName _GetImportOrder = "_get_import_order";
        /// <summary>
        /// Cached name for the '_get_importer_name' method.
        /// </summary>
        public static readonly StringName _GetImporterName = "_get_importer_name";
        /// <summary>
        /// Cached name for the '_get_option_visibility' method.
        /// </summary>
        public static readonly StringName _GetOptionVisibility = "_get_option_visibility";
        /// <summary>
        /// Cached name for the '_get_preset_count' method.
        /// </summary>
        public static readonly StringName _GetPresetCount = "_get_preset_count";
        /// <summary>
        /// Cached name for the '_get_preset_name' method.
        /// </summary>
        public static readonly StringName _GetPresetName = "_get_preset_name";
        /// <summary>
        /// Cached name for the '_get_priority' method.
        /// </summary>
        public static readonly StringName _GetPriority = "_get_priority";
        /// <summary>
        /// Cached name for the '_get_recognized_extensions' method.
        /// </summary>
        public static readonly StringName _GetRecognizedExtensions = "_get_recognized_extensions";
        /// <summary>
        /// Cached name for the '_get_resource_type' method.
        /// </summary>
        public static readonly StringName _GetResourceType = "_get_resource_type";
        /// <summary>
        /// Cached name for the '_get_save_extension' method.
        /// </summary>
        public static readonly StringName _GetSaveExtension = "_get_save_extension";
        /// <summary>
        /// Cached name for the '_get_visible_name' method.
        /// </summary>
        public static readonly StringName _GetVisibleName = "_get_visible_name";
        /// <summary>
        /// Cached name for the '_import' method.
        /// </summary>
        public static readonly StringName _Import = "_import";
        /// <summary>
        /// Cached name for the 'append_import_external_resource' method.
        /// </summary>
        public static readonly StringName AppendImportExternalResource = "append_import_external_resource";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ResourceImporter.SignalName
    {
    }
}
