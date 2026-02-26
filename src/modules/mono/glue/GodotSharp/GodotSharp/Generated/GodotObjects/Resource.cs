namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Resource is the base class for all Godot-specific resource types, serving primarily as data containers. Since they inherit from <see cref="Godot.RefCounted"/>, resources are reference-counted and freed when no longer in use. They can also be nested within other resources, and saved on disk. <see cref="Godot.PackedScene"/>, one of the most common <see cref="Godot.GodotObject"/>s in a Godot project, is also a resource, uniquely capable of storing and instantiating the <see cref="Godot.Node"/>s it contains as many times as desired.</para>
/// <para>In GDScript, resources can loaded from disk by their <see cref="Godot.Resource.ResourcePath"/> using <c>@GDScript.load</c> or <c>@GDScript.preload</c>.</para>
/// <para>The engine keeps a global cache of all loaded resources, referenced by paths (see <see cref="Godot.ResourceLoader.HasCached(string)"/>). A resource will be cached when loaded for the first time and removed from cache once all references are released. When a resource is cached, subsequent loads using its path will return the cached reference.</para>
/// <para><b>Note:</b> In C#, resources will not be freed instantly after they are no longer in use. Instead, garbage collection will run periodically and will free resources that are no longer in use. This means that unused resources will remain in memory for a while before being removed.</para>
/// </summary>
public partial class Resource : RefCounted
{
    public enum DeepDuplicateMode : long
    {
        /// <summary>
        /// <para>No subresorces at all are duplicated. This is useful even in a deep duplication to have all the arrays and dictionaries duplicated but still pointing to the original resources.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Only subresources without a path or with a scene-local path will be duplicated.</para>
        /// </summary>
        Internal = 1,
        /// <summary>
        /// <para>Every subresource found will be duplicated, even if it has a non-local path. In other words, even potentially big resources stored separately will be duplicated.</para>
        /// </summary>
        All = 2
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the resource is duplicated for each instance of all scenes using it. At run-time, the resource can be modified in one scene without affecting other instances (see <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/>).</para>
    /// <para><b>Note:</b> Changing this property at run-time has no effect on already created duplicate resources.</para>
    /// </summary>
    public bool ResourceLocalToScene
    {
        get
        {
            return IsLocalToScene();
        }
        set
        {
            SetLocalToScene(value);
        }
    }

    /// <summary>
    /// <para>The unique path to this resource. If it has been saved to disk, the value will be its filepath. If the resource is exclusively contained within a scene, the value will be the <see cref="Godot.PackedScene"/>'s filepath, followed by a unique identifier.</para>
    /// <para><b>Note:</b> Setting this property manually may fail if a resource with the same path has already been previously loaded. If necessary, use <see cref="Godot.Resource.TakeOverPath(string)"/>.</para>
    /// </summary>
    public string ResourcePath
    {
        get
        {
            return GetPath();
        }
        set
        {
            SetPath(value);
        }
    }

    /// <summary>
    /// <para>An optional name for this resource. When defined, its value is displayed to represent the resource in the Inspector dock. For built-in scripts, the name is displayed as part of the tab name in the script editor.</para>
    /// <para><b>Note:</b> Some resource formats do not support resource names. You can still set the name in the editor or via code, but it will be lost when the resource is reloaded. For example, only built-in scripts can have a resource name, while scripts stored in separate files cannot.</para>
    /// </summary>
    public string ResourceName
    {
        get
        {
            return GetName();
        }
        set
        {
            SetName(value);
        }
    }

    /// <summary>
    /// <para>A unique identifier relative to the this resource's scene. If left empty, the ID is automatically generated when this resource is saved inside a <see cref="Godot.PackedScene"/>. If the resource is not inside a scene, this property is empty by default.</para>
    /// <para><b>Note:</b> When the <see cref="Godot.PackedScene"/> is saved, if multiple resources in the same scene use the same ID, only the earliest resource in the scene hierarchy keeps the original ID. The other resources are assigned new IDs from <see cref="Godot.Resource.GenerateSceneUniqueId()"/>.</para>
    /// <para><b>Note:</b> Setting this property does not emit the <see cref="Godot.Resource.Changed"/> signal.</para>
    /// <para><b>Warning:</b> When setting, the ID must only consist of letters, numbers, and underscores. Otherwise, it will fail and default to a randomly generated ID.</para>
    /// </summary>
    public string ResourceSceneUniqueId
    {
        get
        {
            return GetSceneUniqueId();
        }
        set
        {
            SetSceneUniqueId(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Resource);

    private static readonly StringName NativeName = "Resource";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Resource() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Resource(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Resource(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Override this method to return a custom <see cref="Godot.Rid"/> when <see cref="Godot.Resource.GetRid()"/> is called.</para>
    /// </summary>
    public virtual Rid _GetRid()
    {
        return default;
    }

    /// <summary>
    /// <para>For resources that store state in non-exported properties, such as via <see cref="Godot.GodotObject._ValidateProperty(Godot.Collections.Dictionary)"/> or <see cref="Godot.GodotObject._GetPropertyList()"/>, this method must be implemented to clear them.</para>
    /// </summary>
    public virtual void _ResetState()
    {
    }

    /// <summary>
    /// <para>Override this method to execute additional logic after <see cref="Godot.Resource.SetPathCache(string)"/> is called on this object.</para>
    /// </summary>
    public virtual void _SetPathCache(string path)
    {
    }

    /// <summary>
    /// <para>Override this method to customize the newly duplicated resource created from <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/>, if the original's <see cref="Godot.Resource.ResourceLocalToScene"/> is set to <see langword="true"/>.</para>
    /// <para><b>Example:</b> Set a random <c>damage</c> value to every local resource from an instantiated scene:</para>
    /// <para><code>
    /// extends Resource
    /// 
    /// var damage = 0
    /// 
    /// func _setup_local_to_scene():
    /// 	damage = randi_range(10, 40)
    /// </code></para>
    /// </summary>
    public virtual void _SetupLocalToScene()
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPath, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPath(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TakeOverPath, 83702148ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Resource.ResourcePath"/> to <paramref name="path"/>, potentially overriding an existing cache entry for this path. Further attempts to load an overridden resource by path will instead return this resource.</para>
    /// </summary>
    public void TakeOverPath(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPath, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathCache, 83702148ul);

    /// <summary>
    /// <para>Sets the resource's path to <paramref name="path"/> without involving the resource cache. Useful for handling <see cref="Godot.ResourceFormatLoader.CacheMode"/> values when implementing a custom resource format by extending <see cref="Godot.ResourceFormatLoader"/> and <see cref="Godot.ResourceFormatSaver"/>.</para>
    /// </summary>
    public void SetPathCache(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind3, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetName(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of this resource (or an empty RID). Many resources (such as <see cref="Godot.Texture2D"/>, <see cref="Godot.Mesh"/>, and so on) are high-level abstractions of resources stored in a specialized server (<see cref="Godot.DisplayServer"/>, <see cref="Godot.RenderingServer"/>, etc.), so this function will return the original <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public Rid GetRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLocalToScene, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLocalToScene(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLocalToScene, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLocalToScene()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalScene, 3160264692ul);

    /// <summary>
    /// <para>If <see cref="Godot.Resource.ResourceLocalToScene"/> is set to <see langword="true"/> and the resource has been loaded from a <see cref="Godot.PackedScene"/> instantiation, returns the root <see cref="Godot.Node"/> of the scene where this resource is used. Otherwise, returns <see langword="null"/>.</para>
    /// </summary>
    public Node GetLocalScene()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetupLocalToScene, 3218959716ul);

    /// <summary>
    /// <para>Calls <see cref="Godot.Resource._SetupLocalToScene()"/>. If <see cref="Godot.Resource.ResourceLocalToScene"/> is set to <see langword="true"/>, this method is automatically called from <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/> by the newly duplicated resource within the scene instance.</para>
    /// </summary>
    [Obsolete("This method should only be called internally.")]
    public void SetupLocalToScene()
    {
        NativeCalls.godot_icall_0_3(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResetState, 3218959716ul);

    /// <summary>
    /// <para>Makes the resource clear its non-exported properties. See also <see cref="Godot.Resource._ResetState()"/>. Useful when implementing a custom resource format by extending <see cref="Godot.ResourceFormatLoader"/> and <see cref="Godot.ResourceFormatSaver"/>.</para>
    /// </summary>
    public void ResetState()
    {
        NativeCalls.godot_icall_0_3(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIdForPath, 3186203200ul);

    /// <summary>
    /// <para>In the internal cache for scene-unique IDs, sets the ID of this resource to <paramref name="id"/> for the scene at <paramref name="path"/>. If <paramref name="id"/> is empty, the cache entry for <paramref name="path"/> is cleared. Useful to keep scene-unique IDs the same when implementing a VCS-friendly custom resource format by extending <see cref="Godot.ResourceFormatLoader"/> and <see cref="Godot.ResourceFormatSaver"/>.</para>
    /// <para><b>Note:</b> This method is only implemented when running in an editor context.</para>
    /// </summary>
    public void SetIdForPath(string path, string id)
    {
        NativeCalls.godot_icall_2_303(MethodBind12, GodotObject.GetPtr(this), path, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIdForPath, 3135753539ul);

    /// <summary>
    /// <para>From the internal cache for scene-unique IDs, returns the ID of this resource for the scene at <paramref name="path"/>. If there is no entry, an empty string is returned. Useful to keep scene-unique IDs the same when implementing a VCS-friendly custom resource format by extending <see cref="Godot.ResourceFormatLoader"/> and <see cref="Godot.ResourceFormatSaver"/>.</para>
    /// <para><b>Note:</b> This method is only implemented when running in an editor context. At runtime, it returns an empty string.</para>
    /// </summary>
    public string GetIdForPath(string path)
    {
        return NativeCalls.godot_icall_1_304(MethodBind13, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBuiltIn, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the resource is saved on disk as a part of another resource's file.</para>
    /// </summary>
    public bool IsBuiltIn()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateSceneUniqueId, 2841200299ul);

    /// <summary>
    /// <para>Generates a unique identifier for a resource to be contained inside a <see cref="Godot.PackedScene"/>, based on the current date, time, and a random value. The returned string is only composed of letters (<c>a</c> to <c>y</c>) and numbers (<c>0</c> to <c>8</c>). See also <see cref="Godot.Resource.ResourceSceneUniqueId"/>.</para>
    /// </summary>
    public static string GenerateSceneUniqueId()
    {
        return NativeCalls.godot_icall_0_1221(MethodBind15);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSceneUniqueId, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSceneUniqueId(string id)
    {
        NativeCalls.godot_icall_1_57(MethodBind16, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSceneUniqueId, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetSceneUniqueId()
    {
        return NativeCalls.godot_icall_0_58(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EmitChanged, 3218959716ul);

    /// <summary>
    /// <para>Emits the <see cref="Godot.Resource.Changed"/> signal. This method is called automatically for some built-in resources.</para>
    /// <para><b>Note:</b> For custom resources, it's recommended to call this method whenever a meaningful change occurs, such as a modified property. This ensures that custom <see cref="Godot.GodotObject"/>s depending on the resource are properly updated.</para>
    /// <para><code>
    /// var damage:
    /// 	set(new_value):
    /// 		if damage != new_value:
    /// 			damage = new_value
    /// 			emit_changed()
    /// </code></para>
    /// </summary>
    public void EmitChanged()
    {
        NativeCalls.godot_icall_0_3(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Duplicate, 482882304ul);

    /// <summary>
    /// <para>Duplicates this resource, returning a new resource with its <c>export</c>ed or <see cref="Godot.PropertyUsageFlags.Storage"/> properties copied from the original.</para>
    /// <para>If <paramref name="deep"/> is <see langword="false"/>, a <b>shallow</b> copy is returned: nested <see cref="Godot.Collections.Array"/>, <see cref="Godot.Collections.Dictionary"/>, and <see cref="Godot.Resource"/> properties are not duplicated and are shared with the original resource.</para>
    /// <para>If <paramref name="deep"/> is <see langword="true"/>, a <b>deep</b> copy is returned: all nested arrays, dictionaries, and packed arrays are also duplicated (recursively). Any <see cref="Godot.Resource"/> found inside will only be duplicated if it's local, like <see cref="Godot.Resource.DeepDuplicateMode.Internal"/> used with <see cref="Godot.Resource.DuplicateDeep(Resource.DeepDuplicateMode)"/>.</para>
    /// <para>The following exceptions apply:</para>
    /// <para>- Subresource properties with the <see cref="Godot.PropertyUsageFlags.AlwaysDuplicate"/> flag are always duplicated (recursively or not, depending on <paramref name="deep"/>).</para>
    /// <para>- Subresource properties with the <see cref="Godot.PropertyUsageFlags.NeverDuplicate"/> flag are never duplicated.</para>
    /// <para><b>Note:</b> For custom resources, this method will fail if <see cref="Godot.GodotObject.GodotObject()"/> has been defined with required parameters.</para>
    /// <para><b>Note:</b> When duplicating with <paramref name="deep"/> set to <see langword="true"/>, each resource found, including the one on which this method is called, will be only duplicated once and referenced as many times as needed in the duplicate. For instance, if you are duplicating resource A that happens to have resource B referenced twice, you'll get a new resource A' referencing a new resource B' twice.</para>
    /// </summary>
    public Resource Duplicate(bool deep = false)
    {
        return (Resource)NativeCalls.godot_icall_1_654(MethodBind19, GodotObject.GetPtr(this), deep.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DuplicateDeep, 905779109ul);

    /// <summary>
    /// <para>Duplicates this resource, deeply, like <see cref="Godot.Resource.Duplicate(bool)"/> when passing <see langword="true"/>, with extra control over how subresources are handled.</para>
    /// </summary>
    public Resource DuplicateDeep(Resource.DeepDuplicateMode deepSubresourcesMode = (Resource.DeepDuplicateMode)(1))
    {
        return (Resource)NativeCalls.godot_icall_1_71(MethodBind20, GodotObject.GetPtr(this), (int)deepSubresourcesMode);
    }

    /// <summary>
    /// <para>Emitted when the resource changes, usually when one of its properties is modified. See also <see cref="Godot.Resource.EmitChanged()"/>.</para>
    /// <para><b>Note:</b> This signal is not emitted automatically for properties of custom resources. If necessary, a setter needs to be created to emit the signal.</para>
    /// </summary>
    public event Action Changed
    {
        add => Connect(SignalName.Changed, Callable.From(value));
        remove => Disconnect(SignalName.Changed, Callable.From(value));
    }

    protected void EmitSignalChanged()
    {
        EmitSignal(SignalName.Changed);
    }

    /// <summary>
    /// <para>Emitted by a newly duplicated resource with <see cref="Godot.Resource.ResourceLocalToScene"/> set to <see langword="true"/>.</para>
    /// </summary>
    [Obsolete("This signal is only emitted when the resource is created. Override 'Godot.Resource._SetupLocalToScene()' instead.")]
    public event Action SetupLocalToSceneRequested
    {
        add => Connect(SignalName.SetupLocalToSceneRequested, Callable.From(value));
        remove => Disconnect(SignalName.SetupLocalToSceneRequested, Callable.From(value));
    }

    [Obsolete("This signal is only emitted when the resource is created. Override 'Godot.Resource._SetupLocalToScene()' instead.")]
    protected void EmitSignalSetupLocalToSceneRequested()
    {
        EmitSignal(SignalName.SetupLocalToSceneRequested);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_rid = "_GetRid";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__reset_state = "_ResetState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_path_cache = "_SetPathCache";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__setup_local_to_scene = "_SetupLocalToScene";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_changed = "Changed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_setup_local_to_scene_requested = "SetupLocalToSceneRequested";

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
        if ((method == MethodProxyName__get_rid || method == MethodName._GetRid) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_rid.NativeValue))
        {
            var callRet = _GetRid();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__reset_state || method == MethodName._ResetState) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__reset_state.NativeValue))
        {
            _ResetState();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_path_cache || method == MethodName._SetPathCache) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_path_cache.NativeValue))
        {
            _SetPathCache(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__setup_local_to_scene || method == MethodName._SetupLocalToScene) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__setup_local_to_scene.NativeValue))
        {
            _SetupLocalToScene();
            ret = default;
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
        if (method == MethodName._GetRid)
        {
            if (HasGodotClassMethod(MethodProxyName__get_rid.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ResetState)
        {
            if (HasGodotClassMethod(MethodProxyName__reset_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetPathCache)
        {
            if (HasGodotClassMethod(MethodProxyName__set_path_cache.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetupLocalToScene)
        {
            if (HasGodotClassMethod(MethodProxyName__setup_local_to_scene.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.Changed)
        {
            if (HasGodotClassSignal(SignalProxyName_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SetupLocalToSceneRequested)
        {
            if (HasGodotClassSignal(SignalProxyName_setup_local_to_scene_requested.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'resource_local_to_scene' property.
        /// </summary>
        public static readonly StringName ResourceLocalToScene = "resource_local_to_scene";
        /// <summary>
        /// Cached name for the 'resource_path' property.
        /// </summary>
        public static readonly StringName ResourcePath = "resource_path";
        /// <summary>
        /// Cached name for the 'resource_name' property.
        /// </summary>
        public static readonly StringName ResourceName = "resource_name";
        /// <summary>
        /// Cached name for the 'resource_scene_unique_id' property.
        /// </summary>
        public static readonly StringName ResourceSceneUniqueId = "resource_scene_unique_id";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_rid' method.
        /// </summary>
        public static readonly StringName _GetRid = "_get_rid";
        /// <summary>
        /// Cached name for the '_reset_state' method.
        /// </summary>
        public static readonly StringName _ResetState = "_reset_state";
        /// <summary>
        /// Cached name for the '_set_path_cache' method.
        /// </summary>
        public static readonly StringName _SetPathCache = "_set_path_cache";
        /// <summary>
        /// Cached name for the '_setup_local_to_scene' method.
        /// </summary>
        public static readonly StringName _SetupLocalToScene = "_setup_local_to_scene";
        /// <summary>
        /// Cached name for the 'set_path' method.
        /// </summary>
        public static readonly StringName SetPath = "set_path";
        /// <summary>
        /// Cached name for the 'take_over_path' method.
        /// </summary>
        public static readonly StringName TakeOverPath = "take_over_path";
        /// <summary>
        /// Cached name for the 'get_path' method.
        /// </summary>
        public static readonly StringName GetPath = "get_path";
        /// <summary>
        /// Cached name for the 'set_path_cache' method.
        /// </summary>
        public static readonly StringName SetPathCache = "set_path_cache";
        /// <summary>
        /// Cached name for the 'set_name' method.
        /// </summary>
        public static readonly StringName SetName = "set_name";
        /// <summary>
        /// Cached name for the 'get_name' method.
        /// </summary>
        public static readonly StringName GetName = "get_name";
        /// <summary>
        /// Cached name for the 'get_rid' method.
        /// </summary>
        public static readonly StringName GetRid = "get_rid";
        /// <summary>
        /// Cached name for the 'set_local_to_scene' method.
        /// </summary>
        public static readonly StringName SetLocalToScene = "set_local_to_scene";
        /// <summary>
        /// Cached name for the 'is_local_to_scene' method.
        /// </summary>
        public static readonly StringName IsLocalToScene = "is_local_to_scene";
        /// <summary>
        /// Cached name for the 'get_local_scene' method.
        /// </summary>
        public static readonly StringName GetLocalScene = "get_local_scene";
        /// <summary>
        /// Cached name for the 'setup_local_to_scene' method.
        /// </summary>
        public static readonly StringName SetupLocalToScene = "setup_local_to_scene";
        /// <summary>
        /// Cached name for the 'reset_state' method.
        /// </summary>
        public static readonly StringName ResetState = "reset_state";
        /// <summary>
        /// Cached name for the 'set_id_for_path' method.
        /// </summary>
        public static readonly StringName SetIdForPath = "set_id_for_path";
        /// <summary>
        /// Cached name for the 'get_id_for_path' method.
        /// </summary>
        public static readonly StringName GetIdForPath = "get_id_for_path";
        /// <summary>
        /// Cached name for the 'is_built_in' method.
        /// </summary>
        public static readonly StringName IsBuiltIn = "is_built_in";
        /// <summary>
        /// Cached name for the 'generate_scene_unique_id' method.
        /// </summary>
        public static readonly StringName GenerateSceneUniqueId = "generate_scene_unique_id";
        /// <summary>
        /// Cached name for the 'set_scene_unique_id' method.
        /// </summary>
        public static readonly StringName SetSceneUniqueId = "set_scene_unique_id";
        /// <summary>
        /// Cached name for the 'get_scene_unique_id' method.
        /// </summary>
        public static readonly StringName GetSceneUniqueId = "get_scene_unique_id";
        /// <summary>
        /// Cached name for the 'emit_changed' method.
        /// </summary>
        public static readonly StringName EmitChanged = "emit_changed";
        /// <summary>
        /// Cached name for the 'duplicate' method.
        /// </summary>
        public static readonly StringName Duplicate = "duplicate";
        /// <summary>
        /// Cached name for the 'duplicate_deep' method.
        /// </summary>
        public static readonly StringName DuplicateDeep = "duplicate_deep";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
        /// <summary>
        /// Cached name for the 'changed' signal.
        /// </summary>
        public static readonly StringName Changed = "changed";
        /// <summary>
        /// Cached name for the 'setup_local_to_scene_requested' signal.
        /// </summary>
        public static readonly StringName SetupLocalToSceneRequested = "setup_local_to_scene_requested";
    }
}
