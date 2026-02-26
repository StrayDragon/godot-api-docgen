namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Godot loads resources in the editor or in exported games using ResourceFormatLoaders. They are queried automatically via the <see cref="Godot.ResourceLoader"/> singleton, or when a resource with internal dependencies is loaded. Each file type may load as a different resource type, so multiple ResourceFormatLoaders are registered in the engine.</para>
/// <para>Extending this class allows you to define your own loader. Be sure to respect the documented return types and values. You should give it a global class name with <c>class_name</c> for it to be registered. Like built-in ResourceFormatLoaders, it will be called automatically when loading resources of its handled type(s). You may also implement a <see cref="Godot.ResourceFormatSaver"/>.</para>
/// <para><b>Note:</b> You can also extend <c>EditorImportPlugin</c> if the resource type you need exists but Godot is unable to load its format. Choosing one way over another depends on if the format is suitable or not for the final exported game. For example, it's better to import <c>.png</c> textures as <c>.ctex</c> (<see cref="Godot.CompressedTexture2D"/>) first, so they can be loaded with better efficiency on the graphics card.</para>
/// </summary>
public partial class ResourceFormatLoader : RefCounted
{
    public enum CacheMode : long
    {
        /// <summary>
        /// <para>Neither the main resource (the one requested to be loaded) nor any of its subresources are retrieved from cache nor stored into it. Dependencies (external resources) are loaded with <see cref="Godot.ResourceFormatLoader.CacheMode.Reuse"/>.</para>
        /// </summary>
        Ignore = 0,
        /// <summary>
        /// <para>The main resource (the one requested to be loaded), its subresources, and its dependencies (external resources) are retrieved from cache if present, instead of loaded. Those not cached are loaded and then stored into the cache. The same rules are propagated recursively down the tree of dependencies (external resources).</para>
        /// </summary>
        Reuse = 1,
        /// <summary>
        /// <para>Like <see cref="Godot.ResourceFormatLoader.CacheMode.Reuse"/>, but the cache is checked for the main resource (the one requested to be loaded) as well as for each of its subresources. Those already in the cache, as long as the loaded and cached types match, have their data refreshed from storage into the already existing instances. Otherwise, they are recreated as completely new objects.</para>
        /// </summary>
        Replace = 2,
        /// <summary>
        /// <para>Like <see cref="Godot.ResourceFormatLoader.CacheMode.Ignore"/>, but propagated recursively down the tree of dependencies (external resources).</para>
        /// </summary>
        IgnoreDeep = 3,
        /// <summary>
        /// <para>Like <see cref="Godot.ResourceFormatLoader.CacheMode.Replace"/>, but propagated recursively down the tree of dependencies (external resources).</para>
        /// </summary>
        ReplaceDeep = 4
    }

    private static readonly System.Type CachedType = typeof(ResourceFormatLoader);

    private static readonly StringName NativeName = "ResourceFormatLoader";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ResourceFormatLoader() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceFormatLoader(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceFormatLoader(bool memoryOwn) : base(memoryOwn) { }

    public virtual bool _Exists(string path)
    {
        return default;
    }

    public virtual string[] _GetClassesUsed(string path)
    {
        return default;
    }

    /// <summary>
    /// <para>Should return the dependencies for the resource at the given <paramref name="path"/>. Each dependency is a string composed of one to three sections separated by <c>::</c>, with trailing empty sections omitted:</para>
    /// <para>- The first section should contain the UID if the resource has one. Otherwise, it should contain the file path.</para>
    /// <para>- The second section should contain the class name of the dependency if <paramref name="addTypes"/> is <see langword="true"/>. Otherwise, it should be empty.</para>
    /// <para>- The third section should contain the fallback path if the resource has a UID. Otherwise, it should be empty.</para>
    /// <para><code>
    /// func _get_dependencies(path, add_types):
    /// 	return [
    /// 		"uid://fqgvuwrkuixh::Script::res://script.gd",
    /// 		"uid://fqgvuwrkuixh::::res://script.gd",
    /// 		"res://script.gd::Script",
    /// 		"res://script.gd",
    /// 	]
    /// </code></para>
    /// <para><b>Note:</b> Custom resource types defined by scripts aren't known by the <see cref="Godot.ClassDB"/>, so <c>"Resource"</c> can be used for the class name.</para>
    /// </summary>
    public virtual string[] _GetDependencies(string path, bool addTypes)
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the list of extensions for files this loader is able to read.</para>
    /// </summary>
    public virtual string[] _GetRecognizedExtensions()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the script class name associated with the <see cref="Godot.Resource"/> under the given <paramref name="path"/>. If the resource has no script or the script isn't a named class, it should return <c>""</c>.</para>
    /// </summary>
    public virtual string _GetResourceScriptClass(string path)
    {
        return default;
    }

    /// <summary>
    /// <para>Gets the class name of the resource associated with the given path. If the loader cannot handle it, it should return <c>""</c>.</para>
    /// <para><b>Note:</b> Custom resource types defined by scripts aren't known by the <see cref="Godot.ClassDB"/>, so you might just return <c>"Resource"</c> for them.</para>
    /// </summary>
    public virtual string _GetResourceType(string path)
    {
        return default;
    }

    /// <summary>
    /// <para>Should return the unique ID for the resource associated with the given path. If this method is not overridden, a <c>.uid</c> file is generated along with the resource file, containing the unique ID.</para>
    /// </summary>
    public virtual long _GetResourceUid(string path)
    {
        return default;
    }

    /// <summary>
    /// <para>Tells which resource class this loader can load.</para>
    /// <para><b>Note:</b> Custom resource types defined by scripts aren't known by the <see cref="Godot.ClassDB"/>, so you might just handle <c>"Resource"</c> for them.</para>
    /// </summary>
    public virtual bool _HandlesType(StringName type)
    {
        return default;
    }

    /// <summary>
    /// <para>Loads a resource when the engine finds this loader to be compatible. If the loaded resource is the result of an import, <paramref name="originalPath"/> will target the source file. Returns a <see cref="Godot.Resource"/> object on success, or an <see cref="Godot.Error"/> constant in case of failure.</para>
    /// <para>The <paramref name="cacheMode"/> property defines whether and how the cache should be used or updated when loading the resource. See <see cref="Godot.ResourceFormatLoader.CacheMode"/> for details.</para>
    /// </summary>
    public virtual Variant _Load(string path, string originalPath, bool useSubThreads, int cacheMode)
    {
        return default;
    }

    /// <summary>
    /// <para>Tells whether or not this loader should load a resource from its resource path for a given type.</para>
    /// <para>If it is not implemented, the default behavior returns whether the path's extension is within the ones provided by <see cref="Godot.ResourceFormatLoader._GetRecognizedExtensions()"/>, and if the type is within the ones provided by <see cref="Godot.ResourceFormatLoader._GetResourceType(string)"/>.</para>
    /// </summary>
    public virtual bool _RecognizePath(string path, StringName type)
    {
        return default;
    }

    /// <summary>
    /// <para>If implemented, renames dependencies within the given resource and saves it. <paramref name="renames"/> is a dictionary <c>{ String =&gt; String }</c> mapping old dependency paths to new paths.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or an <see cref="Godot.Error"/> constant in case of failure.</para>
    /// </summary>
    public virtual Error _RenameDependencies(string path, Godot.Collections.Dictionary renames)
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__exists = "_Exists";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_classes_used = "_GetClassesUsed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_dependencies = "_GetDependencies";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_recognized_extensions = "_GetRecognizedExtensions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_resource_script_class = "_GetResourceScriptClass";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_resource_type = "_GetResourceType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_resource_uid = "_GetResourceUid";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__handles_type = "_HandlesType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__load = "_Load";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__recognize_path = "_RecognizePath";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__rename_dependencies = "_RenameDependencies";

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
        if ((method == MethodProxyName__exists || method == MethodName._Exists) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__exists.NativeValue))
        {
            var callRet = _Exists(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_classes_used || method == MethodName._GetClassesUsed) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_classes_used.NativeValue))
        {
            var callRet = _GetClassesUsed(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_dependencies || method == MethodName._GetDependencies) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_dependencies.NativeValue))
        {
            var callRet = _GetDependencies(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_recognized_extensions || method == MethodName._GetRecognizedExtensions) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_recognized_extensions.NativeValue))
        {
            var callRet = _GetRecognizedExtensions();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_resource_script_class || method == MethodName._GetResourceScriptClass) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_resource_script_class.NativeValue))
        {
            var callRet = _GetResourceScriptClass(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_resource_type || method == MethodName._GetResourceType) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_resource_type.NativeValue))
        {
            var callRet = _GetResourceType(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_resource_uid || method == MethodName._GetResourceUid) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_resource_uid.NativeValue))
        {
            var callRet = _GetResourceUid(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__handles_type || method == MethodName._HandlesType) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__handles_type.NativeValue))
        {
            var callRet = _HandlesType(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__load || method == MethodName._Load) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__load.NativeValue))
        {
            var callRet = _Load(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<bool>(args[2]), VariantUtils.ConvertTo<int>(args[3]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__recognize_path || method == MethodName._RecognizePath) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__recognize_path.NativeValue))
        {
            var callRet = _RecognizePath(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__rename_dependencies || method == MethodName._RenameDependencies) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__rename_dependencies.NativeValue))
        {
            var callRet = _RenameDependencies(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[1]));
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
        if (method == MethodName._Exists)
        {
            if (HasGodotClassMethod(MethodProxyName__exists.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetClassesUsed)
        {
            if (HasGodotClassMethod(MethodProxyName__get_classes_used.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDependencies)
        {
            if (HasGodotClassMethod(MethodProxyName__get_dependencies.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._GetResourceScriptClass)
        {
            if (HasGodotClassMethod(MethodProxyName__get_resource_script_class.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._GetResourceUid)
        {
            if (HasGodotClassMethod(MethodProxyName__get_resource_uid.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HandlesType)
        {
            if (HasGodotClassMethod(MethodProxyName__handles_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Load)
        {
            if (HasGodotClassMethod(MethodProxyName__load.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._RecognizePath)
        {
            if (HasGodotClassMethod(MethodProxyName__recognize_path.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._RenameDependencies)
        {
            if (HasGodotClassMethod(MethodProxyName__rename_dependencies.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_exists' method.
        /// </summary>
        public static readonly StringName _Exists = "_exists";
        /// <summary>
        /// Cached name for the '_get_classes_used' method.
        /// </summary>
        public static readonly StringName _GetClassesUsed = "_get_classes_used";
        /// <summary>
        /// Cached name for the '_get_dependencies' method.
        /// </summary>
        public static readonly StringName _GetDependencies = "_get_dependencies";
        /// <summary>
        /// Cached name for the '_get_recognized_extensions' method.
        /// </summary>
        public static readonly StringName _GetRecognizedExtensions = "_get_recognized_extensions";
        /// <summary>
        /// Cached name for the '_get_resource_script_class' method.
        /// </summary>
        public static readonly StringName _GetResourceScriptClass = "_get_resource_script_class";
        /// <summary>
        /// Cached name for the '_get_resource_type' method.
        /// </summary>
        public static readonly StringName _GetResourceType = "_get_resource_type";
        /// <summary>
        /// Cached name for the '_get_resource_uid' method.
        /// </summary>
        public static readonly StringName _GetResourceUid = "_get_resource_uid";
        /// <summary>
        /// Cached name for the '_handles_type' method.
        /// </summary>
        public static readonly StringName _HandlesType = "_handles_type";
        /// <summary>
        /// Cached name for the '_load' method.
        /// </summary>
        public static readonly StringName _Load = "_load";
        /// <summary>
        /// Cached name for the '_recognize_path' method.
        /// </summary>
        public static readonly StringName _RecognizePath = "_recognize_path";
        /// <summary>
        /// Cached name for the '_rename_dependencies' method.
        /// </summary>
        public static readonly StringName _RenameDependencies = "_rename_dependencies";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
