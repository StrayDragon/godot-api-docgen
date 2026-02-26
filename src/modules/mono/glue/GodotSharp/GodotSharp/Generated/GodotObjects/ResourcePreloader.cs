namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node is used to preload sub-resources inside a scene, so when the scene is loaded, all the resources are ready to use and can be retrieved from the preloader. You can add the resources using the ResourcePreloader tab when the node is selected.</para>
/// <para>GDScript has a simplified <c>@GDScript.preload</c> built-in method which can be used in most situations, leaving the use of <see cref="Godot.ResourcePreloader"/> for more advanced scenarios.</para>
/// </summary>
public partial class ResourcePreloader : Node
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array Resources
    {
        get
        {
            return _GetResources();
        }
        set
        {
            _SetResources(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(ResourcePreloader);

    private static readonly StringName NativeName = "ResourcePreloader";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ResourcePreloader() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ResourcePreloader(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ResourcePreloader(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetResources, 381264803ul);

    internal void _SetResources(Godot.Collections.Array resources)
    {
        NativeCalls.godot_icall_1_138(MethodBind0, GodotObject.GetPtr(this), (godot_array)(resources ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetResources, 3995934104ul);

    internal Godot.Collections.Array _GetResources()
    {
        return NativeCalls.godot_icall_0_120(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddResource, 1168801743ul);

    /// <summary>
    /// <para>Adds a resource to the preloader with the given <paramref name="name"/>. If a resource with the given <paramref name="name"/> already exists, the new resource will be renamed to "<paramref name="name"/> N" where N is an incrementing number starting from 2.</para>
    /// </summary>
    public void AddResource(StringName name, Resource resource)
    {
        NativeCalls.godot_icall_2_159(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(resource));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveResource, 3304788590ul);

    /// <summary>
    /// <para>Removes the resource associated to <paramref name="name"/> from the preloader.</para>
    /// </summary>
    public void RemoveResource(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenameResource, 3740211285ul);

    /// <summary>
    /// <para>Renames a resource inside the preloader from <paramref name="name"/> to <paramref name="newname"/>.</para>
    /// </summary>
    public void RenameResource(StringName name, StringName newname)
    {
        NativeCalls.godot_icall_2_118(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(newname?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasResource, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the preloader contains a resource associated to <paramref name="name"/>.</para>
    /// </summary>
    public bool HasResource(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind5, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResource, 3742749261ul);

    /// <summary>
    /// <para>Returns the resource associated to <paramref name="name"/>.</para>
    /// </summary>
    public Resource GetResource(StringName name)
    {
        return (Resource)NativeCalls.godot_icall_1_119(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResourceList, 1139954409ul);

    /// <summary>
    /// <para>Returns the list of resources inside the preloader.</para>
    /// </summary>
    public string[] GetResourceList()
    {
        return NativeCalls.godot_icall_0_108(MethodBind7, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node.PropertyName
    {
        /// <summary>
        /// Cached name for the 'resources' property.
        /// </summary>
        public static readonly StringName Resources = "resources";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the '_set_resources' method.
        /// </summary>
        public static readonly StringName _SetResources = "_set_resources";
        /// <summary>
        /// Cached name for the '_get_resources' method.
        /// </summary>
        public static readonly StringName _GetResources = "_get_resources";
        /// <summary>
        /// Cached name for the 'add_resource' method.
        /// </summary>
        public static readonly StringName AddResource = "add_resource";
        /// <summary>
        /// Cached name for the 'remove_resource' method.
        /// </summary>
        public static readonly StringName RemoveResource = "remove_resource";
        /// <summary>
        /// Cached name for the 'rename_resource' method.
        /// </summary>
        public static readonly StringName RenameResource = "rename_resource";
        /// <summary>
        /// Cached name for the 'has_resource' method.
        /// </summary>
        public static readonly StringName HasResource = "has_resource";
        /// <summary>
        /// Cached name for the 'get_resource' method.
        /// </summary>
        public static readonly StringName GetResource = "get_resource";
        /// <summary>
        /// Cached name for the 'get_resource_list' method.
        /// </summary>
        public static readonly StringName GetResourceList = "get_resource_list";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
    }
}
