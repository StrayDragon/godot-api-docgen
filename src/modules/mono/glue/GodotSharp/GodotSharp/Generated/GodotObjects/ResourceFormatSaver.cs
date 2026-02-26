namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The engine can save resources when you do it from the editor, or when you use the <see cref="Godot.ResourceSaver"/> singleton. This is accomplished thanks to multiple <see cref="Godot.ResourceFormatSaver"/>s, each handling its own format and called automatically by the engine.</para>
/// <para>By default, Godot saves resources as <c>.tres</c> (text-based), <c>.res</c> (binary) or another built-in format, but you can choose to create your own format by extending this class. Be sure to respect the documented return types and values. You should give it a global class name with <c>class_name</c> for it to be registered. Like built-in ResourceFormatSavers, it will be called automatically when saving resources of its recognized type(s). You may also implement a <see cref="Godot.ResourceFormatLoader"/>.</para>
/// </summary>
public partial class ResourceFormatSaver : RefCounted
{
    private static readonly System.Type CachedType = typeof(ResourceFormatSaver);

    private static readonly StringName NativeName = "ResourceFormatSaver";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ResourceFormatSaver() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceFormatSaver(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceFormatSaver(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Returns the list of extensions available for saving the resource object, provided it is recognized (see <see cref="Godot.ResourceFormatSaver._Recognize(Resource)"/>).</para>
    /// </summary>
    public virtual string[] _GetRecognizedExtensions(Resource resource)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns whether the given resource object can be saved by this saver.</para>
    /// </summary>
    public virtual bool _Recognize(Resource resource)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if this saver handles a given save path and <see langword="false"/> otherwise.</para>
    /// <para>If this method is not implemented, the default behavior returns whether the path's extension is within the ones provided by <see cref="Godot.ResourceFormatSaver._GetRecognizedExtensions(Resource)"/>.</para>
    /// </summary>
    public virtual bool _RecognizePath(Resource resource, string path)
    {
        return default;
    }

    /// <summary>
    /// <para>Saves the given resource object to a file at the target <paramref name="path"/>. <paramref name="flags"/> is a bitmask composed with <see cref="Godot.ResourceSaver.SaverFlags"/> constants.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or an <see cref="Godot.Error"/> constant in case of failure.</para>
    /// </summary>
    public virtual Error _Save(Resource resource, string path, uint flags)
    {
        return default;
    }

    /// <summary>
    /// <para>Sets a new UID for the resource at the given <paramref name="path"/>. Returns <see cref="Godot.Error.Ok"/> on success, or an <see cref="Godot.Error"/> constant in case of failure.</para>
    /// </summary>
    public virtual Error _SetUid(string path, long uid)
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_recognized_extensions = "_GetRecognizedExtensions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__recognize = "_Recognize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__recognize_path = "_RecognizePath";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__save = "_Save";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_uid = "_SetUid";

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
        if ((method == MethodProxyName__get_recognized_extensions || method == MethodName._GetRecognizedExtensions) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_recognized_extensions.NativeValue))
        {
            var callRet = _GetRecognizedExtensions(VariantUtils.ConvertTo<Resource>(args[0]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__recognize || method == MethodName._Recognize) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__recognize.NativeValue))
        {
            var callRet = _Recognize(VariantUtils.ConvertTo<Resource>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__recognize_path || method == MethodName._RecognizePath) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__recognize_path.NativeValue))
        {
            var callRet = _RecognizePath(VariantUtils.ConvertTo<Resource>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__save || method == MethodName._Save) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__save.NativeValue))
        {
            var callRet = _Save(VariantUtils.ConvertTo<Resource>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<uint>(args[2]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set_uid || method == MethodName._SetUid) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_uid.NativeValue))
        {
            var callRet = _SetUid(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
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
        if (method == MethodName._GetRecognizedExtensions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_recognized_extensions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Recognize)
        {
            if (HasGodotClassMethod(MethodProxyName__recognize.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._Save)
        {
            if (HasGodotClassMethod(MethodProxyName__save.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetUid)
        {
            if (HasGodotClassMethod(MethodProxyName__set_uid.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_get_recognized_extensions' method.
        /// </summary>
        public static readonly StringName _GetRecognizedExtensions = "_get_recognized_extensions";
        /// <summary>
        /// Cached name for the '_recognize' method.
        /// </summary>
        public static readonly StringName _Recognize = "_recognize";
        /// <summary>
        /// Cached name for the '_recognize_path' method.
        /// </summary>
        public static readonly StringName _RecognizePath = "_recognize_path";
        /// <summary>
        /// Cached name for the '_save' method.
        /// </summary>
        public static readonly StringName _Save = "_save";
        /// <summary>
        /// Cached name for the '_set_uid' method.
        /// </summary>
        public static readonly StringName _SetUid = "_set_uid";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
