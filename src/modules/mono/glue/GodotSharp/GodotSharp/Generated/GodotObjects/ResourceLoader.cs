namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A singleton used to load resource files from the filesystem.</para>
/// <para>It uses the many <see cref="Godot.ResourceFormatLoader"/> classes registered in the engine (either built-in or from a plugin) to load files into memory and convert them to a format that can be used by the engine.</para>
/// <para><b>Note:</b> You have to import the files into the engine first to load them using <see cref="Godot.ResourceLoader.Load(string, string, ResourceLoader.CacheMode)"/>. If you want to load <see cref="Godot.Image"/>s at run-time, you may use <see cref="Godot.Image.Load(string)"/>. If you want to import audio files, you can use the snippet described in <see cref="Godot.AudioStreamMP3.Data"/>.</para>
/// <para><b>Note:</b> Non-resource files such as plain text files cannot be read using <see cref="Godot.ResourceLoader"/>. Use <see cref="Godot.FileAccess"/> for those files instead, and be aware that non-resource files are not exported by default (see notes in the <see cref="Godot.FileAccess"/> class description for instructions on exporting them).</para>
/// </summary>
public static partial class ResourceLoader
{
    public enum ThreadLoadStatus : long
    {
        /// <summary>
        /// <para>The resource is invalid, or has not been loaded with <see cref="Godot.ResourceLoader.LoadThreadedRequest(string, string, bool, ResourceLoader.CacheMode)"/>.</para>
        /// </summary>
        InvalidResource = 0,
        /// <summary>
        /// <para>The resource is still being loaded.</para>
        /// </summary>
        InProgress = 1,
        /// <summary>
        /// <para>Some error occurred during loading and it failed.</para>
        /// </summary>
        Failed = 2,
        /// <summary>
        /// <para>The resource was loaded successfully and can be accessed via <see cref="Godot.ResourceLoader.LoadThreadedGet(string)"/>.</para>
        /// </summary>
        Loaded = 3
    }

    public enum CacheMode : long
    {
        /// <summary>
        /// <para>Neither the main resource (the one requested to be loaded) nor any of its subresources are retrieved from cache nor stored into it. Dependencies (external resources) are loaded with <see cref="Godot.ResourceLoader.CacheMode.Reuse"/>.</para>
        /// </summary>
        Ignore = 0,
        /// <summary>
        /// <para>The main resource (the one requested to be loaded), its subresources, and its dependencies (external resources) are retrieved from cache if present, instead of loaded. Those not cached are loaded and then stored into the cache. The same rules are propagated recursively down the tree of dependencies (external resources).</para>
        /// </summary>
        Reuse = 1,
        /// <summary>
        /// <para>Like <see cref="Godot.ResourceLoader.CacheMode.Reuse"/>, but the cache is checked for the main resource (the one requested to be loaded) as well as for each of its subresources. Those already in the cache, as long as the loaded and cached types match, have their data refreshed from storage into the already existing instances. Otherwise, they are recreated as completely new objects.</para>
        /// </summary>
        Replace = 2,
        /// <summary>
        /// <para>Like <see cref="Godot.ResourceLoader.CacheMode.Ignore"/>, but propagated recursively down the tree of dependencies (external resources).</para>
        /// </summary>
        IgnoreDeep = 3,
        /// <summary>
        /// <para>Like <see cref="Godot.ResourceLoader.CacheMode.Replace"/>, but propagated recursively down the tree of dependencies (external resources).</para>
        /// </summary>
        ReplaceDeep = 4
    }

    private static readonly StringName NativeName = "ResourceLoader";

    private static ResourceLoaderInstance singleton;

    public static ResourceLoaderInstance Singleton =>
        singleton ??= (ResourceLoaderInstance)InteropUtils.EngineGetSingleton("ResourceLoader");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadThreadedRequest, 3614384323ul);

    /// <summary>
    /// <para>Loads the resource using threads. If <paramref name="useSubThreads"/> is <see langword="true"/>, multiple threads will be used to load the resource, which makes loading faster, but may affect the main thread (and thus cause game slowdowns).</para>
    /// <para>The <paramref name="cacheMode"/> parameter defines whether and how the cache should be used or updated when loading the resource.</para>
    /// </summary>
    public static Error LoadThreadedRequest(string path, string typeHint = "", bool useSubThreads = false, ResourceLoader.CacheMode cacheMode = (ResourceLoader.CacheMode)(1))
    {
        return (Error)NativeCalls.godot_icall_4_1222(MethodBind0, GodotObject.GetPtr(Singleton), path, typeHint, useSubThreads.ToGodotBool(), (int)cacheMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadThreadedGetStatus, 4137685479ul);

    /// <summary>
    /// <para>Returns the status of a threaded loading operation started with <see cref="Godot.ResourceLoader.LoadThreadedRequest(string, string, bool, ResourceLoader.CacheMode)"/> for the resource at <paramref name="path"/>.</para>
    /// <para>An array variable can optionally be passed via <paramref name="progress"/>, and will return a one-element array containing the ratio of completion of the threaded loading (between <c>0.0</c> and <c>1.0</c>).</para>
    /// <para><b>Note:</b> The recommended way of using this method is to call it during different frames (e.g., in <see cref="Godot.Node._Process(double)"/>, instead of a loop).</para>
    /// </summary>
    public static ResourceLoader.ThreadLoadStatus LoadThreadedGetStatus(string path, Godot.Collections.Array progress = null)
    {
        return (ResourceLoader.ThreadLoadStatus)NativeCalls.godot_icall_2_1223(MethodBind1, GodotObject.GetPtr(Singleton), path, (godot_array)(progress ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadThreadedGet, 1748875256ul);

    /// <summary>
    /// <para>Returns the resource loaded by <see cref="Godot.ResourceLoader.LoadThreadedRequest(string, string, bool, ResourceLoader.CacheMode)"/>.</para>
    /// <para>If this is called before the loading thread is done (i.e. <see cref="Godot.ResourceLoader.LoadThreadedGetStatus(string, Godot.Collections.Array)"/> is not <see cref="Godot.ResourceLoader.ThreadLoadStatus.Loaded"/>), the calling thread will be blocked until the resource has finished loading. However, it's recommended to use <see cref="Godot.ResourceLoader.LoadThreadedGetStatus(string, Godot.Collections.Array)"/> to known when the load has actually completed.</para>
    /// </summary>
    public static Resource LoadThreadedGet(string path)
    {
        return (Resource)NativeCalls.godot_icall_1_533(MethodBind2, GodotObject.GetPtr(Singleton), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Load, 3358495409ul);

    /// <summary>
    /// <para>Loads a resource at the given <paramref name="path"/>, caching the result for further access.</para>
    /// <para>The registered <see cref="Godot.ResourceFormatLoader"/>s are queried sequentially to find the first one which can handle the file's extension, and then attempt loading. If loading fails, the remaining ResourceFormatLoaders are also attempted.</para>
    /// <para>An optional <paramref name="typeHint"/> can be used to further specify the <see cref="Godot.Resource"/> type that should be handled by the <see cref="Godot.ResourceFormatLoader"/>. Anything that inherits from <see cref="Godot.Resource"/> can be used as a type hint, for example <see cref="Godot.Image"/>.</para>
    /// <para>The <paramref name="cacheMode"/> property defines whether and how the cache should be used or updated when loading the resource.</para>
    /// <para>Returns an empty resource if no <see cref="Godot.ResourceFormatLoader"/> could handle the file, and prints an error if no file is found at the specified path.</para>
    /// <para>GDScript has a simplified <c>@GDScript.load</c> built-in method which can be used in most situations, leaving the use of <see cref="Godot.ResourceLoader"/> for more advanced scenarios.</para>
    /// <para><b>Note:</b> If <c>ProjectSettings.editor/export/convert_text_resources_to_binary</c> is <see langword="true"/>, <c>@GDScript.load</c> will not be able to read converted files in an exported project. If you rely on run-time loading of files present within the PCK, set <c>ProjectSettings.editor/export/convert_text_resources_to_binary</c> to <see langword="false"/>.</para>
    /// <para><b>Note:</b> Relative paths will be prefixed with <c>"res://"</c> before loading, to avoid unexpected results make sure your paths are absolute.</para>
    /// </summary>
    public static Resource Load(string path, string typeHint = "", ResourceLoader.CacheMode cacheMode = (ResourceLoader.CacheMode)(1))
    {
        return (Resource)NativeCalls.godot_icall_3_1224(MethodBind3, GodotObject.GetPtr(Singleton), path, typeHint, (int)cacheMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRecognizedExtensionsForType, 3538744774ul);

    /// <summary>
    /// <para>Returns the list of recognized extensions for a resource type.</para>
    /// </summary>
    public static string[] GetRecognizedExtensionsForType(string type)
    {
        return NativeCalls.godot_icall_1_328(MethodBind4, GodotObject.GetPtr(Singleton), type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddResourceFormatLoader, 2896595483ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.ResourceFormatLoader"/>. The ResourceLoader will use the ResourceFormatLoader as described in <see cref="Godot.ResourceLoader.Load(string, string, ResourceLoader.CacheMode)"/>.</para>
    /// <para>This method is performed implicitly for ResourceFormatLoaders written in GDScript (see <see cref="Godot.ResourceFormatLoader"/> for more information).</para>
    /// </summary>
    public static void AddResourceFormatLoader(ResourceFormatLoader formatLoader, bool atFront = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind5, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(formatLoader), atFront.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveResourceFormatLoader, 405397102ul);

    /// <summary>
    /// <para>Unregisters the given <see cref="Godot.ResourceFormatLoader"/>.</para>
    /// </summary>
    public static void RemoveResourceFormatLoader(ResourceFormatLoader formatLoader)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(formatLoader));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAbortOnMissingResources, 2586408642ul);

    /// <summary>
    /// <para>Changes the behavior on missing sub-resources. The default behavior is to abort loading.</para>
    /// </summary>
    public static void SetAbortOnMissingResources(bool abort)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(Singleton), abort.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDependencies, 3538744774ul);

    /// <summary>
    /// <para>Returns the dependencies for the resource at the given <paramref name="path"/>.</para>
    /// <para>Each dependency is a string that can be divided into sections by <c>::</c>. There can be either one section or three sections, with the second section always being empty. When there is one section, it contains the file path. When there are three sections, the first section contains the UID and the third section contains the fallback path.</para>
    /// <para><code>
    /// for dependency in ResourceLoader.get_dependencies(path):
    /// 	if dependency.contains("::"):
    /// 		print(dependency.get_slice("::", 0)) # Prints the UID.
    /// 		print(dependency.get_slice("::", 2)) # Prints the fallback path.
    /// 	else:
    /// 		print(dependency) # Prints the path.
    /// </code></para>
    /// </summary>
    public static string[] GetDependencies(string path)
    {
        return NativeCalls.godot_icall_1_328(MethodBind8, GodotObject.GetPtr(Singleton), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasCached, 2323990056ul);

    /// <summary>
    /// <para>Returns whether a cached resource is available for the given <paramref name="path"/>.</para>
    /// <para>Once a resource has been loaded by the engine, it is cached in memory for faster access, and future calls to the <see cref="Godot.ResourceLoader.Load(string, string, ResourceLoader.CacheMode)"/> method will use the cached version. The cached resource can be overridden by using <see cref="Godot.Resource.TakeOverPath(string)"/> on a new resource for that same path.</para>
    /// </summary>
    public static bool HasCached(string path)
    {
        return NativeCalls.godot_icall_1_131(MethodBind9, GodotObject.GetPtr(Singleton), path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCachedRef, 1748875256ul);

    /// <summary>
    /// <para>Returns the cached resource reference for the given <paramref name="path"/>.</para>
    /// <para><b>Note:</b> If the resource is not cached, the returned <see cref="Godot.Resource"/> will be invalid.</para>
    /// </summary>
    public static Resource GetCachedRef(string path)
    {
        return (Resource)NativeCalls.godot_icall_1_533(MethodBind10, GodotObject.GetPtr(Singleton), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Exists, 4185558881ul);

    /// <summary>
    /// <para>Returns whether a recognized resource exists for the given <paramref name="path"/>.</para>
    /// <para>An optional <paramref name="typeHint"/> can be used to further specify the <see cref="Godot.Resource"/> type that should be handled by the <see cref="Godot.ResourceFormatLoader"/>. Anything that inherits from <see cref="Godot.Resource"/> can be used as a type hint, for example <see cref="Godot.Image"/>.</para>
    /// <para><b>Note:</b> If you use <see cref="Godot.Resource.TakeOverPath(string)"/>, this method will return <see langword="true"/> for the taken path even if the resource wasn't saved (i.e. exists only in resource cache).</para>
    /// </summary>
    public static bool Exists(string path, string typeHint = "")
    {
        return NativeCalls.godot_icall_2_327(MethodBind11, GodotObject.GetPtr(Singleton), path, typeHint).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResourceUid, 1597066294ul);

    /// <summary>
    /// <para>Returns the ID associated with a given resource path, or <c>-1</c> when no such ID exists.</para>
    /// </summary>
    public static long GetResourceUid(string path)
    {
        return NativeCalls.godot_icall_1_1225(MethodBind12, GodotObject.GetPtr(Singleton), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ListDirectory, 3538744774ul);

    /// <summary>
    /// <para>Lists a directory, returning all resources and subdirectories contained within. The resource files have the original file names as visible in the editor before exporting. The directories have <c>"/"</c> appended.</para>
    /// <para><code>
    /// # Prints ["extra_data/", "model.gltf", "model.tscn", "model_slime.png"]
    /// print(ResourceLoader.list_directory("res://assets/enemies/slime"))
    /// </code></para>
    /// <para><b>Note:</b> The order of files and directories returned by this method is not deterministic, and can vary between operating systems.</para>
    /// <para><b>Note:</b> To normally traverse the filesystem, see <see cref="Godot.DirAccess"/>.</para>
    /// </summary>
    public static string[] ListDirectory(string directoryPath)
    {
        return NativeCalls.godot_icall_1_328(MethodBind13, GodotObject.GetPtr(Singleton), directoryPath);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'load_threaded_request' method.
        /// </summary>
        public static readonly StringName LoadThreadedRequest = "load_threaded_request";
        /// <summary>
        /// Cached name for the 'load_threaded_get_status' method.
        /// </summary>
        public static readonly StringName LoadThreadedGetStatus = "load_threaded_get_status";
        /// <summary>
        /// Cached name for the 'load_threaded_get' method.
        /// </summary>
        public static readonly StringName LoadThreadedGet = "load_threaded_get";
        /// <summary>
        /// Cached name for the 'load' method.
        /// </summary>
        public static readonly StringName Load = "load";
        /// <summary>
        /// Cached name for the 'get_recognized_extensions_for_type' method.
        /// </summary>
        public static readonly StringName GetRecognizedExtensionsForType = "get_recognized_extensions_for_type";
        /// <summary>
        /// Cached name for the 'add_resource_format_loader' method.
        /// </summary>
        public static readonly StringName AddResourceFormatLoader = "add_resource_format_loader";
        /// <summary>
        /// Cached name for the 'remove_resource_format_loader' method.
        /// </summary>
        public static readonly StringName RemoveResourceFormatLoader = "remove_resource_format_loader";
        /// <summary>
        /// Cached name for the 'set_abort_on_missing_resources' method.
        /// </summary>
        public static readonly StringName SetAbortOnMissingResources = "set_abort_on_missing_resources";
        /// <summary>
        /// Cached name for the 'get_dependencies' method.
        /// </summary>
        public static readonly StringName GetDependencies = "get_dependencies";
        /// <summary>
        /// Cached name for the 'has_cached' method.
        /// </summary>
        public static readonly StringName HasCached = "has_cached";
        /// <summary>
        /// Cached name for the 'get_cached_ref' method.
        /// </summary>
        public static readonly StringName GetCachedRef = "get_cached_ref";
        /// <summary>
        /// Cached name for the 'exists' method.
        /// </summary>
        public static readonly StringName Exists = "exists";
        /// <summary>
        /// Cached name for the 'get_resource_uid' method.
        /// </summary>
        public static readonly StringName GetResourceUid = "get_resource_uid";
        /// <summary>
        /// Cached name for the 'list_directory' method.
        /// </summary>
        public static readonly StringName ListDirectory = "list_directory";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
