namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A singleton for saving resource types to the filesystem.</para>
/// <para>It uses the many <see cref="Godot.ResourceFormatSaver"/> classes registered in the engine (either built-in or from a plugin) to save resource data to text-based (e.g. <c>.tres</c> or <c>.tscn</c>) or binary files (e.g. <c>.res</c> or <c>.scn</c>).</para>
/// </summary>
[GodotClassName("ResourceSaver")]
public partial class ResourceSaverInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(ResourceSaverInstance);

    private static readonly StringName NativeName = "ResourceSaver";

    internal ResourceSaverInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ResourceSaverInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ResourceSaverInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Save, 2983274697ul);

    /// <summary>
    /// <para>Saves a resource to disk to the given path, using a <see cref="Godot.ResourceFormatSaver"/> that recognizes the resource object. If <paramref name="path"/> is empty, <see cref="Godot.ResourceSaver"/> will try to use <see cref="Godot.Resource.ResourcePath"/>.</para>
    /// <para>The <paramref name="flags"/> bitmask can be specified to customize the save behavior.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success.</para>
    /// <para><b>Note:</b> When the project is running, any generated UID associated with the resource will not be saved as the required code is only executed in editor mode.</para>
    /// </summary>
    public Error Save(Resource resource, string path = "", ResourceSaver.SaverFlags flags = (ResourceSaver.SaverFlags)(0))
    {
        return (Error)NativeCalls.godot_icall_3_1226(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(resource), path, (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUid, 993915709ul);

    /// <summary>
    /// <para>Sets the UID of the given <paramref name="resource"/> path to <paramref name="uid"/>. You can generate a new UID using <see cref="Godot.ResourceUid.CreateId()"/>.</para>
    /// <para>Since resources will normally get a UID automatically, this method is only useful in very specific cases.</para>
    /// </summary>
    public Error SetUid(string resource, long uid)
    {
        return (Error)NativeCalls.godot_icall_2_1227(MethodBind1, GodotObject.GetPtr(this), resource, uid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRecognizedExtensions, 4223597960ul);

    /// <summary>
    /// <para>Returns the list of extensions available for saving a resource of a given type.</para>
    /// </summary>
    public string[] GetRecognizedExtensions(Resource type)
    {
        return NativeCalls.godot_icall_1_1228(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(type));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddResourceFormatSaver, 362894272ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.ResourceFormatSaver"/>. The ResourceSaver will use the ResourceFormatSaver as described in <see cref="Godot.ResourceSaverInstance.Save(Resource, string, ResourceSaver.SaverFlags)"/>.</para>
    /// <para>This method is performed implicitly for ResourceFormatSavers written in GDScript (see <see cref="Godot.ResourceFormatSaver"/> for more information).</para>
    /// </summary>
    public void AddResourceFormatSaver(ResourceFormatSaver formatSaver, bool atFront = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(formatSaver), atFront.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveResourceFormatSaver, 3373026878ul);

    /// <summary>
    /// <para>Unregisters the given <see cref="Godot.ResourceFormatSaver"/>.</para>
    /// </summary>
    public void RemoveResourceFormatSaver(ResourceFormatSaver formatSaver)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(formatSaver));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResourceIdForPath, 150756522ul);

    /// <summary>
    /// <para>Returns the resource ID for the given path. If <paramref name="generate"/> is <see langword="true"/>, a new resource ID will be generated if one for the path is not found. If <paramref name="generate"/> is <see langword="false"/> and the path is not found, <see cref="Godot.ResourceUid.InvalidId"/> is returned.</para>
    /// </summary>
    public long GetResourceIdForPath(string path, bool generate = false)
    {
        return NativeCalls.godot_icall_2_1229(MethodBind5, GodotObject.GetPtr(this), path, generate.ToGodotBool());
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
        /// Cached name for the 'save' method.
        /// </summary>
        public static readonly StringName Save = "save";
        /// <summary>
        /// Cached name for the 'set_uid' method.
        /// </summary>
        public static readonly StringName SetUid = "set_uid";
        /// <summary>
        /// Cached name for the 'get_recognized_extensions' method.
        /// </summary>
        public static readonly StringName GetRecognizedExtensions = "get_recognized_extensions";
        /// <summary>
        /// Cached name for the 'add_resource_format_saver' method.
        /// </summary>
        public static readonly StringName AddResourceFormatSaver = "add_resource_format_saver";
        /// <summary>
        /// Cached name for the 'remove_resource_format_saver' method.
        /// </summary>
        public static readonly StringName RemoveResourceFormatSaver = "remove_resource_format_saver";
        /// <summary>
        /// Cached name for the 'get_resource_id_for_path' method.
        /// </summary>
        public static readonly StringName GetResourceIdForPath = "get_resource_id_for_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
