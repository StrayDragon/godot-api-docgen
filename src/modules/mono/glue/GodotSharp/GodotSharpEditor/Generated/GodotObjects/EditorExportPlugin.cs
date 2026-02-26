namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.EditorExportPlugin"/>s are automatically invoked whenever the user exports the project. Their most common use is to determine what files are being included in the exported project. For each plugin, <see cref="Godot.EditorExportPlugin._ExportBegin(string[], bool, string, uint)"/> is called at the beginning of the export process and then <see cref="Godot.EditorExportPlugin._ExportFile(string, string, string[])"/> is called for each exported file.</para>
/// <para>To use <see cref="Godot.EditorExportPlugin"/>, register it using the <see cref="Godot.EditorPlugin.AddExportPlugin(EditorExportPlugin)"/> method first.</para>
/// </summary>
public partial class EditorExportPlugin : RefCounted
{
    private static readonly System.Type CachedType = typeof(EditorExportPlugin);

    private static readonly StringName NativeName = "EditorExportPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorExportPlugin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorExportPlugin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorExportPlugin(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Return <see langword="true"/> if this plugin will customize resources based on the platform and features used.</para>
    /// <para>When enabled, <see cref="Godot.EditorExportPlugin._GetCustomizationConfigurationHash()"/> and <see cref="Godot.EditorExportPlugin._CustomizeResource(Resource, string)"/> will be called and must be implemented.</para>
    /// </summary>
    public virtual bool _BeginCustomizeResources(EditorExportPlatform platform, string[] features)
    {
        return default;
    }

    /// <summary>
    /// <para>Return <see langword="true"/> if this plugin will customize scenes based on the platform and features used.</para>
    /// <para>When enabled, <see cref="Godot.EditorExportPlugin._GetCustomizationConfigurationHash()"/> and <see cref="Godot.EditorExportPlugin._CustomizeScene(Node, string)"/> will be called and must be implemented.</para>
    /// <para><b>Note:</b> <see cref="Godot.EditorExportPlugin._CustomizeScene(Node, string)"/> will only be called for scenes that have been modified since the last export.</para>
    /// </summary>
    public virtual bool _BeginCustomizeScenes(EditorExportPlatform platform, string[] features)
    {
        return default;
    }

    /// <summary>
    /// <para>Customize a resource. If changes are made to it, return the same or a new resource. Otherwise, return <see langword="null"/>. When a new resource is returned, <paramref name="resource"/> will be replaced by a copy of the new resource.</para>
    /// <para>The <paramref name="path"/> argument is only used when customizing an actual file, otherwise this means that this resource is part of another one and it will be empty.</para>
    /// <para>Implementing this method is required if <see cref="Godot.EditorExportPlugin._BeginCustomizeResources(EditorExportPlatform, string[])"/> returns <see langword="true"/>.</para>
    /// <para><b>Note:</b> When customizing any of the following types and returning another resource, the other resource should not be skipped using <see cref="Godot.EditorExportPlugin.Skip()"/> in <see cref="Godot.EditorExportPlugin._ExportFile(string, string, string[])"/>:</para>
    /// <para>- <see cref="Godot.AtlasTexture"/></para>
    /// <para>- <see cref="Godot.CompressedCubemap"/></para>
    /// <para>- <see cref="Godot.CompressedCubemapArray"/></para>
    /// <para>- <see cref="Godot.CompressedTexture2D"/></para>
    /// <para>- <see cref="Godot.CompressedTexture2DArray"/></para>
    /// <para>- <see cref="Godot.CompressedTexture3D"/></para>
    /// </summary>
    public virtual Resource _CustomizeResource(Resource resource, string path)
    {
        return default;
    }

    /// <summary>
    /// <para>Customize a scene. If changes are made to it, return the same or a new scene. Otherwise, return <see langword="null"/>. If a new scene is returned, it is up to you to dispose of the old one.</para>
    /// <para>Implementing this method is required if <see cref="Godot.EditorExportPlugin._BeginCustomizeScenes(EditorExportPlatform, string[])"/> returns <see langword="true"/>.</para>
    /// </summary>
    public virtual Node _CustomizeScene(Node scene, string path)
    {
        return default;
    }

    /// <summary>
    /// <para>This is called when the customization process for resources ends.</para>
    /// </summary>
    public virtual void _EndCustomizeResources()
    {
    }

    /// <summary>
    /// <para>This is called when the customization process for scenes ends.</para>
    /// </summary>
    public virtual void _EndCustomizeScenes()
    {
    }

    /// <summary>
    /// <para>Virtual method to be overridden by the user. It is called when the export starts and provides all information about the export. <paramref name="features"/> is the list of features for the export, <paramref name="isDebug"/> is <see langword="true"/> for debug builds, <paramref name="path"/> is the target path for the exported project. <paramref name="flags"/> is only used when running a runnable profile, e.g. when using native run on Android.</para>
    /// </summary>
    public virtual void _ExportBegin(string[] features, bool isDebug, string path, uint flags)
    {
    }

    /// <summary>
    /// <para>Virtual method to be overridden by the user. Called when the export is finished.</para>
    /// </summary>
    public virtual void _ExportEnd()
    {
    }

    /// <summary>
    /// <para>Virtual method to be overridden by the user. Called for each exported file before <see cref="Godot.EditorExportPlugin._CustomizeResource(Resource, string)"/> and <see cref="Godot.EditorExportPlugin._CustomizeScene(Node, string)"/>. The arguments can be used to identify the file. <paramref name="path"/> is the path of the file, <paramref name="type"/> is the <see cref="Godot.Resource"/> represented by the file (e.g. <see cref="Godot.PackedScene"/>), and <paramref name="features"/> is the list of features for the export.</para>
    /// <para>Calling <see cref="Godot.EditorExportPlugin.Skip()"/> inside this callback will make the file not included in the export.</para>
    /// </summary>
    public virtual void _ExportFile(string path, string type, string[] features)
    {
    }

    /// <summary>
    /// <para>Virtual method to be overridden by the user. This is called to retrieve the set of Android dependencies provided by this plugin. Each returned Android dependency should have the format of an Android remote binary dependency: <c>org.godot.example:my-plugin:0.0.0</c></para>
    /// <para>For more information see <a href="https://developer.android.com/build/dependencies?agpversion=4.1#dependency-types">Android documentation on dependencies</a>.</para>
    /// <para><b>Note:</b> Only supported on Android and requires <c>EditorExportPlatformAndroid.gradle_build/use_gradle_build</c> to be enabled.</para>
    /// </summary>
    public virtual string[] _GetAndroidDependencies(EditorExportPlatform platform, bool debug)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to be overridden by the user. This is called to retrieve the URLs of Maven repositories for the set of Android dependencies provided by this plugin.</para>
    /// <para>For more information see <a href="https://docs.gradle.org/current/userguide/dependency_management.html#sec:maven_repo">Gradle documentation on dependency management</a>.</para>
    /// <para><b>Note:</b> Google's Maven repo and the Maven Central repo are already included by default.</para>
    /// <para><b>Note:</b> Only supported on Android and requires <c>EditorExportPlatformAndroid.gradle_build/use_gradle_build</c> to be enabled.</para>
    /// </summary>
    public virtual string[] _GetAndroidDependenciesMavenRepos(EditorExportPlatform platform, bool debug)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to be overridden by the user. This is called to retrieve the local paths of the Android libraries archive (AAR) files provided by this plugin.</para>
    /// <para><b>Note:</b> Relative paths <b>must</b> be relative to Godot's <c>res://addons/</c> directory. For example, an AAR file located under <c>res://addons/hello_world_plugin/HelloWorld.release.aar</c> can be returned as an absolute path using <c>res://addons/hello_world_plugin/HelloWorld.release.aar</c> or a relative path using <c>hello_world_plugin/HelloWorld.release.aar</c>.</para>
    /// <para><b>Note:</b> Only supported on Android and requires <c>EditorExportPlatformAndroid.gradle_build/use_gradle_build</c> to be enabled.</para>
    /// </summary>
    public virtual string[] _GetAndroidLibraries(EditorExportPlatform platform, bool debug)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to be overridden by the user. This is used at export time to update the contents of the <c>activity</c> element in the generated Android manifest.</para>
    /// <para><b>Note:</b> Only supported on Android and requires <c>EditorExportPlatformAndroid.gradle_build/use_gradle_build</c> to be enabled.</para>
    /// </summary>
    public virtual string _GetAndroidManifestActivityElementContents(EditorExportPlatform platform, bool debug)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to be overridden by the user. This is used at export time to update the contents of the <c>application</c> element in the generated Android manifest.</para>
    /// <para><b>Note:</b> Only supported on Android and requires <c>EditorExportPlatformAndroid.gradle_build/use_gradle_build</c> to be enabled.</para>
    /// </summary>
    public virtual string _GetAndroidManifestApplicationElementContents(EditorExportPlatform platform, bool debug)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to be overridden by the user. This is used at export time to update the contents of the <c>manifest</c> element in the generated Android manifest.</para>
    /// <para><b>Note:</b> Only supported on Android and requires <c>EditorExportPlatformAndroid.gradle_build/use_gradle_build</c> to be enabled.</para>
    /// </summary>
    public virtual string _GetAndroidManifestElementContents(EditorExportPlatform platform, bool debug)
    {
        return default;
    }

    /// <summary>
    /// <para>Return a hash based on the configuration passed (for both scenes and resources). This helps keep separate caches for separate export configurations.</para>
    /// <para>Implementing this method is required if <see cref="Godot.EditorExportPlugin._BeginCustomizeResources(EditorExportPlatform, string[])"/> returns <see langword="true"/>.</para>
    /// </summary>
    public virtual ulong _GetCustomizationConfigurationHash()
    {
        return default;
    }

    /// <summary>
    /// <para>Return a <see cref="string"/>[] of additional features this preset, for the given <paramref name="platform"/>, should have.</para>
    /// </summary>
    public virtual string[] _GetExportFeatures(EditorExportPlatform platform, bool debug)
    {
        return default;
    }

    /// <summary>
    /// <para>Validates <paramref name="option"/> and returns the visibility for the specified <paramref name="platform"/>. The default implementation returns <see langword="true"/> for all options.</para>
    /// </summary>
    public virtual bool _GetExportOptionVisibility(EditorExportPlatform platform, string option)
    {
        return default;
    }

    /// <summary>
    /// <para>Check the requirements for the given <paramref name="option"/> and return a non-empty warning string if they are not met.</para>
    /// <para><b>Note:</b> Use <see cref="Godot.EditorExportPlugin.GetOption(StringName)"/> to check the value of the export options.</para>
    /// </summary>
    public virtual string _GetExportOptionWarning(EditorExportPlatform platform, string option)
    {
        return default;
    }

    /// <summary>
    /// <para>Return a list of export options that can be configured for this export plugin.</para>
    /// <para>Each element in the return value is a <see cref="Godot.Collections.Dictionary"/> with the following keys:</para>
    /// <para>- <c>option</c>: A dictionary with the structure documented by <see cref="Godot.GodotObject.GetPropertyList()"/>, but all keys are optional.</para>
    /// <para>- <c>default_value</c>: The default value for this option.</para>
    /// <para>- <c>update_visibility</c>: An optional boolean value. If set to <see langword="true"/>, the preset will emit <see cref="Godot.GodotObject.PropertyListChanged"/> when the option is changed.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetExportOptions(EditorExportPlatform platform)
    {
        return default;
    }

    /// <summary>
    /// <para>Return a <see cref="Godot.Collections.Dictionary"/> of override values for export options, that will be used instead of user-provided values. Overridden options will be hidden from the user interface.</para>
    /// <para><code>
    /// class MyExportPlugin extends EditorExportPlugin:
    /// 	func _get_name() -&gt; String:
    /// 		return "MyExportPlugin"
    /// 
    /// 	func _supports_platform(platform) -&gt; bool:
    /// 		if platform is EditorExportPlatformPC:
    /// 			# Run on all desktop platforms including Windows, MacOS and Linux.
    /// 			return true
    /// 		return false
    /// 
    /// 	func _get_export_options_overrides(platform) -&gt; Dictionary:
    /// 		# Override "Embed PCK" to always be enabled.
    /// 		return {
    /// 			"binary_format/embed_pck": true,
    /// 		}
    /// </code></para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _GetExportOptionsOverrides(EditorExportPlatform platform)
    {
        return default;
    }

    /// <summary>
    /// <para>Return the name identifier of this plugin (for future identification by the exporter). The plugins are sorted by name before exporting.</para>
    /// <para>Implementing this method is required.</para>
    /// </summary>
    public virtual string _GetName()
    {
        return default;
    }

    /// <summary>
    /// <para>Return <see langword="true"/> if the result of <see cref="Godot.EditorExportPlugin._GetExportOptions(EditorExportPlatform)"/> has changed and the export options of the preset corresponding to <paramref name="platform"/> should be updated.</para>
    /// </summary>
    public virtual bool _ShouldUpdateExportOptions(EditorExportPlatform platform)
    {
        return default;
    }

    /// <summary>
    /// <para>Return <see langword="true"/> if the plugin supports the given <paramref name="platform"/>.</para>
    /// </summary>
    public virtual bool _SupportsPlatform(EditorExportPlatform platform)
    {
        return default;
    }

    /// <summary>
    /// <para>Provide access to the Android prebuilt manifest and allows the plugin to modify it if needed.</para>
    /// <para>Implementers of this virtual method should take the binary manifest data from <paramref name="manifestData"/>, copy it, modify it, and then return it with the modifications.</para>
    /// <para>If no modifications are needed, then an empty <see cref="byte"/>[] should be returned.</para>
    /// </summary>
    public virtual byte[] _UpdateAndroidPrebuiltManifest(EditorExportPlatform platform, byte[] manifestData)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSharedObject, 3098291045ul);

    /// <summary>
    /// <para>Adds a shared object or a directory containing only shared objects with the given <paramref name="tags"/> and destination <paramref name="path"/>.</para>
    /// <para><b>Note:</b> In case of macOS exports, those shared objects will be added to <c>Frameworks</c> directory of app bundle.</para>
    /// <para>In case of a directory code-sign will error if you place non code object in directory.</para>
    /// </summary>
    public void AddSharedObject(string path, string[] tags, string target)
    {
        EditorNativeCalls.godot_icall_3_485(MethodBind0, GodotObject.GetPtr(this), path, tags, target);
    }

    /// <summary>
    /// <para>Adds a shared object or a directory containing only shared objects with the given <paramref name="tags"/> and destination <paramref name="path"/>.</para>
    /// <para><b>Note:</b> In case of macOS exports, those shared objects will be added to <c>Frameworks</c> directory of app bundle.</para>
    /// <para>In case of a directory code-sign will error if you place non code object in directory.</para>
    /// </summary>
    public void AddSharedObject(string path, ReadOnlySpan<string> tags, string target)
    {
        EditorNativeCalls.godot_icall_3_485(MethodBind0, GodotObject.GetPtr(this), path, tags, target);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddFile, 527928637ul);

    /// <summary>
    /// <para>Adds a custom file to be exported. <paramref name="path"/> is the virtual path that can be used to load the file, <paramref name="file"/> is the binary data of the file.</para>
    /// <para>When called inside <see cref="Godot.EditorExportPlugin._ExportFile(string, string, string[])"/> and <paramref name="remap"/> is <see langword="true"/>, the current file will not be exported, but instead remapped to this custom file. <paramref name="remap"/> is ignored when called in other places.</para>
    /// <para><paramref name="file"/> will not be imported, so consider using <see cref="Godot.EditorExportPlugin._CustomizeResource(Resource, string)"/> to remap imported resources.</para>
    /// </summary>
    public void AddFile(string path, byte[] file, bool remap)
    {
        EditorNativeCalls.godot_icall_3_486(MethodBind1, GodotObject.GetPtr(this), path, file, remap.ToGodotBool());
    }

    /// <summary>
    /// <para>Adds a custom file to be exported. <paramref name="path"/> is the virtual path that can be used to load the file, <paramref name="file"/> is the binary data of the file.</para>
    /// <para>When called inside <see cref="Godot.EditorExportPlugin._ExportFile(string, string, string[])"/> and <paramref name="remap"/> is <see langword="true"/>, the current file will not be exported, but instead remapped to this custom file. <paramref name="remap"/> is ignored when called in other places.</para>
    /// <para><paramref name="file"/> will not be imported, so consider using <see cref="Godot.EditorExportPlugin._CustomizeResource(Resource, string)"/> to remap imported resources.</para>
    /// </summary>
    public void AddFile(string path, ReadOnlySpan<byte> file, bool remap)
    {
        EditorNativeCalls.godot_icall_3_486(MethodBind1, GodotObject.GetPtr(this), path, file, remap.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAppleEmbeddedPlatformProjectStaticLib, 83702148ul);

    /// <summary>
    /// <para>Adds a static library from the given <paramref name="path"/> to the Apple embedded platform project.</para>
    /// </summary>
    public void AddAppleEmbeddedPlatformProjectStaticLib(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind2, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAppleEmbeddedPlatformFramework, 83702148ul);

    /// <summary>
    /// <para>Adds a static library (*.a) or a dynamic library (*.dylib, *.framework) to the Linking Phase to the Apple embedded platform's Xcode project.</para>
    /// </summary>
    public void AddAppleEmbeddedPlatformFramework(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind3, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAppleEmbeddedPlatformEmbeddedFramework, 83702148ul);

    /// <summary>
    /// <para>Adds a dynamic library (*.dylib, *.framework) to the Linking Phase in the Apple embedded platform's Xcode project and embeds it into the resulting binary.</para>
    /// <para><b>Note:</b> For static libraries (*.a), this works in the same way as <see cref="Godot.EditorExportPlugin.AddAppleEmbeddedPlatformFramework(string)"/>.</para>
    /// <para><b>Note:</b> This method should not be used for System libraries as they are already present on the device.</para>
    /// </summary>
    public void AddAppleEmbeddedPlatformEmbeddedFramework(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAppleEmbeddedPlatformPlistContent, 83702148ul);

    /// <summary>
    /// <para>Adds additional fields to the Apple embedded platform's project Info.plist file.</para>
    /// </summary>
    public void AddAppleEmbeddedPlatformPlistContent(string plistContent)
    {
        NativeCalls.godot_icall_1_57(MethodBind5, GodotObject.GetPtr(this), plistContent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAppleEmbeddedPlatformLinkerFlags, 83702148ul);

    /// <summary>
    /// <para>Adds linker flags for the Apple embedded platform export.</para>
    /// </summary>
    public void AddAppleEmbeddedPlatformLinkerFlags(string flags)
    {
        NativeCalls.godot_icall_1_57(MethodBind6, GodotObject.GetPtr(this), flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAppleEmbeddedPlatformBundleFile, 83702148ul);

    /// <summary>
    /// <para>Adds an Apple embedded platform bundle file from the given <paramref name="path"/> to the exported project.</para>
    /// </summary>
    public void AddAppleEmbeddedPlatformBundleFile(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind7, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAppleEmbeddedPlatformCppCode, 83702148ul);

    /// <summary>
    /// <para>Adds C++ code to the Apple embedded platform export. The final code is created from the code appended by each active export plugin.</para>
    /// </summary>
    public void AddAppleEmbeddedPlatformCppCode(string code)
    {
        NativeCalls.godot_icall_1_57(MethodBind8, GodotObject.GetPtr(this), code);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIosProjectStaticLib, 83702148ul);

    /// <summary>
    /// <para>Adds a static library from the given <paramref name="path"/> to the iOS project.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorExportPlugin.AddAppleEmbeddedPlatformProjectStaticLib(string)' instead.")]
    public void AddIosProjectStaticLib(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind9, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIosFramework, 83702148ul);

    /// <summary>
    /// <para>Adds a static library (*.a) or a dynamic library (*.dylib, *.framework) to the Linking Phase to the iOS Xcode project.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorExportPlugin.AddAppleEmbeddedPlatformFramework(string)' instead.")]
    public void AddIosFramework(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind10, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIosEmbeddedFramework, 83702148ul);

    /// <summary>
    /// <para>Adds a dynamic library (*.dylib, *.framework) to Linking Phase in iOS's Xcode project and embeds it into resulting binary.</para>
    /// <para><b>Note:</b> For static libraries (*.a), this works the in same way as <see cref="Godot.EditorExportPlugin.AddAppleEmbeddedPlatformFramework(string)"/>.</para>
    /// <para><b>Note:</b> This method should not be used for System libraries as they are already present on the device.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorExportPlugin.AddAppleEmbeddedPlatformEmbeddedFramework(string)' instead.")]
    public void AddIosEmbeddedFramework(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind11, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIosPlistContent, 83702148ul);

    /// <summary>
    /// <para>Adds additional fields to the iOS project Info.plist file.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorExportPlugin.AddAppleEmbeddedPlatformPlistContent(string)' instead.")]
    public void AddIosPlistContent(string plistContent)
    {
        NativeCalls.godot_icall_1_57(MethodBind12, GodotObject.GetPtr(this), plistContent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIosLinkerFlags, 83702148ul);

    /// <summary>
    /// <para>Adds linker flags for the iOS export.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorExportPlugin.AddAppleEmbeddedPlatformLinkerFlags(string)' instead.")]
    public void AddIosLinkerFlags(string flags)
    {
        NativeCalls.godot_icall_1_57(MethodBind13, GodotObject.GetPtr(this), flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIosBundleFile, 83702148ul);

    /// <summary>
    /// <para>Adds an iOS bundle file from the given <paramref name="path"/> to the exported project.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorExportPlugin.AddAppleEmbeddedPlatformBundleFile(string)' instead.")]
    public void AddIosBundleFile(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind14, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIosCppCode, 83702148ul);

    /// <summary>
    /// <para>Adds C++ code to the iOS export. The final code is created from the code appended by each active export plugin.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorExportPlugin.AddAppleEmbeddedPlatformCppCode(string)' instead.")]
    public void AddIosCppCode(string code)
    {
        NativeCalls.godot_icall_1_57(MethodBind15, GodotObject.GetPtr(this), code);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMacOSPluginFile, 83702148ul);

    /// <summary>
    /// <para>Adds file or directory matching <paramref name="path"/> to <c>PlugIns</c> directory of macOS app bundle.</para>
    /// <para><b>Note:</b> This is useful only for macOS exports.</para>
    /// </summary>
    public void AddMacOSPluginFile(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind16, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Skip, 3218959716ul);

    /// <summary>
    /// <para>To be called inside <see cref="Godot.EditorExportPlugin._ExportFile(string, string, string[])"/>. Skips the current file, so it's not included in the export.</para>
    /// </summary>
    public void Skip()
    {
        NativeCalls.godot_icall_0_3(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOption, 2760726917ul);

    /// <summary>
    /// <para>Returns the current value of an export option supplied by <see cref="Godot.EditorExportPlugin._GetExportOptions(EditorExportPlatform)"/>.</para>
    /// </summary>
    public Variant GetOption(StringName name)
    {
        return NativeCalls.godot_icall_1_143(MethodBind18, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExportPreset, 1610607222ul);

    /// <summary>
    /// <para>Returns currently used export preset.</para>
    /// </summary>
    public EditorExportPreset GetExportPreset()
    {
        return (EditorExportPreset)NativeCalls.godot_icall_0_63(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExportPlatform, 282254641ul);

    /// <summary>
    /// <para>Returns currently used export platform.</para>
    /// </summary>
    public EditorExportPlatform GetExportPlatform()
    {
        return (EditorExportPlatform)NativeCalls.godot_icall_0_63(MethodBind20, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__begin_customize_resources = "_BeginCustomizeResources";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__begin_customize_scenes = "_BeginCustomizeScenes";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__customize_resource = "_CustomizeResource";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__customize_scene = "_CustomizeScene";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__end_customize_resources = "_EndCustomizeResources";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__end_customize_scenes = "_EndCustomizeScenes";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_begin = "_ExportBegin";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_end = "_ExportEnd";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__export_file = "_ExportFile";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_android_dependencies = "_GetAndroidDependencies";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_android_dependencies_maven_repos = "_GetAndroidDependenciesMavenRepos";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_android_libraries = "_GetAndroidLibraries";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_android_manifest_activity_element_contents = "_GetAndroidManifestActivityElementContents";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_android_manifest_application_element_contents = "_GetAndroidManifestApplicationElementContents";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_android_manifest_element_contents = "_GetAndroidManifestElementContents";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_customization_configuration_hash = "_GetCustomizationConfigurationHash";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_export_features = "_GetExportFeatures";

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
    private static readonly StringName MethodProxyName__get_export_options_overrides = "_GetExportOptionsOverrides";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_name = "_GetName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__should_update_export_options = "_ShouldUpdateExportOptions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__supports_platform = "_SupportsPlatform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__update_android_prebuilt_manifest = "_UpdateAndroidPrebuiltManifest";

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
        if ((method == MethodProxyName__begin_customize_resources || method == MethodName._BeginCustomizeResources) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__begin_customize_resources.NativeValue))
        {
            var callRet = _BeginCustomizeResources(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<string[]>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__begin_customize_scenes || method == MethodName._BeginCustomizeScenes) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__begin_customize_scenes.NativeValue))
        {
            var callRet = _BeginCustomizeScenes(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<string[]>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__customize_resource || method == MethodName._CustomizeResource) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__customize_resource.NativeValue))
        {
            var callRet = _CustomizeResource(VariantUtils.ConvertTo<Resource>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<Resource>(callRet);
            return true;
        }
        if ((method == MethodProxyName__customize_scene || method == MethodName._CustomizeScene) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__customize_scene.NativeValue))
        {
            var callRet = _CustomizeScene(VariantUtils.ConvertTo<Node>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<Node>(callRet);
            return true;
        }
        if ((method == MethodProxyName__end_customize_resources || method == MethodName._EndCustomizeResources) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__end_customize_resources.NativeValue))
        {
            _EndCustomizeResources();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__end_customize_scenes || method == MethodName._EndCustomizeScenes) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__end_customize_scenes.NativeValue))
        {
            _EndCustomizeScenes();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__export_begin || method == MethodName._ExportBegin) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_begin.NativeValue))
        {
            _ExportBegin(VariantUtils.ConvertTo<string[]>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<uint>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__export_end || method == MethodName._ExportEnd) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_end.NativeValue))
        {
            _ExportEnd();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__export_file || method == MethodName._ExportFile) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__export_file.NativeValue))
        {
            _ExportFile(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<string[]>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_android_dependencies || method == MethodName._GetAndroidDependencies) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_android_dependencies.NativeValue))
        {
            var callRet = _GetAndroidDependencies(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_android_dependencies_maven_repos || method == MethodName._GetAndroidDependenciesMavenRepos) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_android_dependencies_maven_repos.NativeValue))
        {
            var callRet = _GetAndroidDependenciesMavenRepos(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_android_libraries || method == MethodName._GetAndroidLibraries) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_android_libraries.NativeValue))
        {
            var callRet = _GetAndroidLibraries(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_android_manifest_activity_element_contents || method == MethodName._GetAndroidManifestActivityElementContents) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_android_manifest_activity_element_contents.NativeValue))
        {
            var callRet = _GetAndroidManifestActivityElementContents(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_android_manifest_application_element_contents || method == MethodName._GetAndroidManifestApplicationElementContents) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_android_manifest_application_element_contents.NativeValue))
        {
            var callRet = _GetAndroidManifestApplicationElementContents(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_android_manifest_element_contents || method == MethodName._GetAndroidManifestElementContents) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_android_manifest_element_contents.NativeValue))
        {
            var callRet = _GetAndroidManifestElementContents(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_customization_configuration_hash || method == MethodName._GetCustomizationConfigurationHash) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_customization_configuration_hash.NativeValue))
        {
            var callRet = _GetCustomizationConfigurationHash();
            ret = VariantUtils.CreateFrom<ulong>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_export_features || method == MethodName._GetExportFeatures) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_export_features.NativeValue))
        {
            var callRet = _GetExportFeatures(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_export_option_visibility || method == MethodName._GetExportOptionVisibility) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_export_option_visibility.NativeValue))
        {
            var callRet = _GetExportOptionVisibility(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_export_option_warning || method == MethodName._GetExportOptionWarning) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_export_option_warning.NativeValue))
        {
            var callRet = _GetExportOptionWarning(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_export_options || method == MethodName._GetExportOptions) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_export_options.NativeValue))
        {
            var callRet = _GetExportOptions(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_export_options_overrides || method == MethodName._GetExportOptionsOverrides) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_export_options_overrides.NativeValue))
        {
            var callRet = _GetExportOptionsOverrides(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_name || method == MethodName._GetName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_name.NativeValue))
        {
            var callRet = _GetName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__should_update_export_options || method == MethodName._ShouldUpdateExportOptions) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__should_update_export_options.NativeValue))
        {
            var callRet = _ShouldUpdateExportOptions(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__supports_platform || method == MethodName._SupportsPlatform) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__supports_platform.NativeValue))
        {
            var callRet = _SupportsPlatform(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__update_android_prebuilt_manifest || method == MethodName._UpdateAndroidPrebuiltManifest) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__update_android_prebuilt_manifest.NativeValue))
        {
            var callRet = _UpdateAndroidPrebuiltManifest(VariantUtils.ConvertTo<EditorExportPlatform>(args[0]), VariantUtils.ConvertTo<byte[]>(args[1]));
            ret = VariantUtils.CreateFrom<byte[]>(callRet);
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
        if (method == MethodName._BeginCustomizeResources)
        {
            if (HasGodotClassMethod(MethodProxyName__begin_customize_resources.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BeginCustomizeScenes)
        {
            if (HasGodotClassMethod(MethodProxyName__begin_customize_scenes.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CustomizeResource)
        {
            if (HasGodotClassMethod(MethodProxyName__customize_resource.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CustomizeScene)
        {
            if (HasGodotClassMethod(MethodProxyName__customize_scene.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._EndCustomizeResources)
        {
            if (HasGodotClassMethod(MethodProxyName__end_customize_resources.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._EndCustomizeScenes)
        {
            if (HasGodotClassMethod(MethodProxyName__end_customize_scenes.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportBegin)
        {
            if (HasGodotClassMethod(MethodProxyName__export_begin.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportEnd)
        {
            if (HasGodotClassMethod(MethodProxyName__export_end.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExportFile)
        {
            if (HasGodotClassMethod(MethodProxyName__export_file.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAndroidDependencies)
        {
            if (HasGodotClassMethod(MethodProxyName__get_android_dependencies.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAndroidDependenciesMavenRepos)
        {
            if (HasGodotClassMethod(MethodProxyName__get_android_dependencies_maven_repos.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAndroidLibraries)
        {
            if (HasGodotClassMethod(MethodProxyName__get_android_libraries.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAndroidManifestActivityElementContents)
        {
            if (HasGodotClassMethod(MethodProxyName__get_android_manifest_activity_element_contents.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAndroidManifestApplicationElementContents)
        {
            if (HasGodotClassMethod(MethodProxyName__get_android_manifest_application_element_contents.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAndroidManifestElementContents)
        {
            if (HasGodotClassMethod(MethodProxyName__get_android_manifest_element_contents.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetCustomizationConfigurationHash)
        {
            if (HasGodotClassMethod(MethodProxyName__get_customization_configuration_hash.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetExportFeatures)
        {
            if (HasGodotClassMethod(MethodProxyName__get_export_features.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._GetExportOptionsOverrides)
        {
            if (HasGodotClassMethod(MethodProxyName__get_export_options_overrides.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._ShouldUpdateExportOptions)
        {
            if (HasGodotClassMethod(MethodProxyName__should_update_export_options.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SupportsPlatform)
        {
            if (HasGodotClassMethod(MethodProxyName__supports_platform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._UpdateAndroidPrebuiltManifest)
        {
            if (HasGodotClassMethod(MethodProxyName__update_android_prebuilt_manifest.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the '_begin_customize_resources' method.
        /// </summary>
        public static readonly StringName _BeginCustomizeResources = "_begin_customize_resources";
        /// <summary>
        /// Cached name for the '_begin_customize_scenes' method.
        /// </summary>
        public static readonly StringName _BeginCustomizeScenes = "_begin_customize_scenes";
        /// <summary>
        /// Cached name for the '_customize_resource' method.
        /// </summary>
        public static readonly StringName _CustomizeResource = "_customize_resource";
        /// <summary>
        /// Cached name for the '_customize_scene' method.
        /// </summary>
        public static readonly StringName _CustomizeScene = "_customize_scene";
        /// <summary>
        /// Cached name for the '_end_customize_resources' method.
        /// </summary>
        public static readonly StringName _EndCustomizeResources = "_end_customize_resources";
        /// <summary>
        /// Cached name for the '_end_customize_scenes' method.
        /// </summary>
        public static readonly StringName _EndCustomizeScenes = "_end_customize_scenes";
        /// <summary>
        /// Cached name for the '_export_begin' method.
        /// </summary>
        public static readonly StringName _ExportBegin = "_export_begin";
        /// <summary>
        /// Cached name for the '_export_end' method.
        /// </summary>
        public static readonly StringName _ExportEnd = "_export_end";
        /// <summary>
        /// Cached name for the '_export_file' method.
        /// </summary>
        public static readonly StringName _ExportFile = "_export_file";
        /// <summary>
        /// Cached name for the '_get_android_dependencies' method.
        /// </summary>
        public static readonly StringName _GetAndroidDependencies = "_get_android_dependencies";
        /// <summary>
        /// Cached name for the '_get_android_dependencies_maven_repos' method.
        /// </summary>
        public static readonly StringName _GetAndroidDependenciesMavenRepos = "_get_android_dependencies_maven_repos";
        /// <summary>
        /// Cached name for the '_get_android_libraries' method.
        /// </summary>
        public static readonly StringName _GetAndroidLibraries = "_get_android_libraries";
        /// <summary>
        /// Cached name for the '_get_android_manifest_activity_element_contents' method.
        /// </summary>
        public static readonly StringName _GetAndroidManifestActivityElementContents = "_get_android_manifest_activity_element_contents";
        /// <summary>
        /// Cached name for the '_get_android_manifest_application_element_contents' method.
        /// </summary>
        public static readonly StringName _GetAndroidManifestApplicationElementContents = "_get_android_manifest_application_element_contents";
        /// <summary>
        /// Cached name for the '_get_android_manifest_element_contents' method.
        /// </summary>
        public static readonly StringName _GetAndroidManifestElementContents = "_get_android_manifest_element_contents";
        /// <summary>
        /// Cached name for the '_get_customization_configuration_hash' method.
        /// </summary>
        public static readonly StringName _GetCustomizationConfigurationHash = "_get_customization_configuration_hash";
        /// <summary>
        /// Cached name for the '_get_export_features' method.
        /// </summary>
        public static readonly StringName _GetExportFeatures = "_get_export_features";
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
        /// Cached name for the '_get_export_options_overrides' method.
        /// </summary>
        public static readonly StringName _GetExportOptionsOverrides = "_get_export_options_overrides";
        /// <summary>
        /// Cached name for the '_get_name' method.
        /// </summary>
        public static readonly StringName _GetName = "_get_name";
        /// <summary>
        /// Cached name for the '_should_update_export_options' method.
        /// </summary>
        public static readonly StringName _ShouldUpdateExportOptions = "_should_update_export_options";
        /// <summary>
        /// Cached name for the '_supports_platform' method.
        /// </summary>
        public static readonly StringName _SupportsPlatform = "_supports_platform";
        /// <summary>
        /// Cached name for the '_update_android_prebuilt_manifest' method.
        /// </summary>
        public static readonly StringName _UpdateAndroidPrebuiltManifest = "_update_android_prebuilt_manifest";
        /// <summary>
        /// Cached name for the 'add_shared_object' method.
        /// </summary>
        public static readonly StringName AddSharedObject = "add_shared_object";
        /// <summary>
        /// Cached name for the 'add_file' method.
        /// </summary>
        public static readonly StringName AddFile = "add_file";
        /// <summary>
        /// Cached name for the 'add_apple_embedded_platform_project_static_lib' method.
        /// </summary>
        public static readonly StringName AddAppleEmbeddedPlatformProjectStaticLib = "add_apple_embedded_platform_project_static_lib";
        /// <summary>
        /// Cached name for the 'add_apple_embedded_platform_framework' method.
        /// </summary>
        public static readonly StringName AddAppleEmbeddedPlatformFramework = "add_apple_embedded_platform_framework";
        /// <summary>
        /// Cached name for the 'add_apple_embedded_platform_embedded_framework' method.
        /// </summary>
        public static readonly StringName AddAppleEmbeddedPlatformEmbeddedFramework = "add_apple_embedded_platform_embedded_framework";
        /// <summary>
        /// Cached name for the 'add_apple_embedded_platform_plist_content' method.
        /// </summary>
        public static readonly StringName AddAppleEmbeddedPlatformPlistContent = "add_apple_embedded_platform_plist_content";
        /// <summary>
        /// Cached name for the 'add_apple_embedded_platform_linker_flags' method.
        /// </summary>
        public static readonly StringName AddAppleEmbeddedPlatformLinkerFlags = "add_apple_embedded_platform_linker_flags";
        /// <summary>
        /// Cached name for the 'add_apple_embedded_platform_bundle_file' method.
        /// </summary>
        public static readonly StringName AddAppleEmbeddedPlatformBundleFile = "add_apple_embedded_platform_bundle_file";
        /// <summary>
        /// Cached name for the 'add_apple_embedded_platform_cpp_code' method.
        /// </summary>
        public static readonly StringName AddAppleEmbeddedPlatformCppCode = "add_apple_embedded_platform_cpp_code";
        /// <summary>
        /// Cached name for the 'add_ios_project_static_lib' method.
        /// </summary>
        public static readonly StringName AddIosProjectStaticLib = "add_ios_project_static_lib";
        /// <summary>
        /// Cached name for the 'add_ios_framework' method.
        /// </summary>
        public static readonly StringName AddIosFramework = "add_ios_framework";
        /// <summary>
        /// Cached name for the 'add_ios_embedded_framework' method.
        /// </summary>
        public static readonly StringName AddIosEmbeddedFramework = "add_ios_embedded_framework";
        /// <summary>
        /// Cached name for the 'add_ios_plist_content' method.
        /// </summary>
        public static readonly StringName AddIosPlistContent = "add_ios_plist_content";
        /// <summary>
        /// Cached name for the 'add_ios_linker_flags' method.
        /// </summary>
        public static readonly StringName AddIosLinkerFlags = "add_ios_linker_flags";
        /// <summary>
        /// Cached name for the 'add_ios_bundle_file' method.
        /// </summary>
        public static readonly StringName AddIosBundleFile = "add_ios_bundle_file";
        /// <summary>
        /// Cached name for the 'add_ios_cpp_code' method.
        /// </summary>
        public static readonly StringName AddIosCppCode = "add_ios_cpp_code";
        /// <summary>
        /// Cached name for the 'add_macos_plugin_file' method.
        /// </summary>
        public static readonly StringName AddMacOSPluginFile = "add_macos_plugin_file";
        /// <summary>
        /// Cached name for the 'skip' method.
        /// </summary>
        public static readonly StringName Skip = "skip";
        /// <summary>
        /// Cached name for the 'get_option' method.
        /// </summary>
        public static readonly StringName GetOption = "get_option";
        /// <summary>
        /// Cached name for the 'get_export_preset' method.
        /// </summary>
        public static readonly StringName GetExportPreset = "get_export_preset";
        /// <summary>
        /// Cached name for the 'get_export_platform' method.
        /// </summary>
        public static readonly StringName GetExportPlatform = "get_export_platform";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
