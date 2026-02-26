namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is used to query and configure a certain import format. It is used in conjunction with asset format import plugins.</para>
/// </summary>
public partial class EditorFileSystemImportFormatSupportQuery : RefCounted
{
    private static readonly System.Type CachedType = typeof(EditorFileSystemImportFormatSupportQuery);

    private static readonly StringName NativeName = "EditorFileSystemImportFormatSupportQuery";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorFileSystemImportFormatSupportQuery() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorFileSystemImportFormatSupportQuery(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorFileSystemImportFormatSupportQuery(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Return the file extensions supported.</para>
    /// </summary>
    public virtual string[] _GetFileExtensions()
    {
        return default;
    }

    /// <summary>
    /// <para>Return whether this importer is active.</para>
    /// </summary>
    public virtual bool _IsActive()
    {
        return default;
    }

    /// <summary>
    /// <para>Query support. Return <see langword="false"/> if import must not continue.</para>
    /// </summary>
    public virtual bool _Query()
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_file_extensions = "_GetFileExtensions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_active = "_IsActive";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__query = "_Query";

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
        if ((method == MethodProxyName__get_file_extensions || method == MethodName._GetFileExtensions) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_file_extensions.NativeValue))
        {
            var callRet = _GetFileExtensions();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_active || method == MethodName._IsActive) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_active.NativeValue))
        {
            var callRet = _IsActive();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__query || method == MethodName._Query) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__query.NativeValue))
        {
            var callRet = _Query();
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
        if (method == MethodName._GetFileExtensions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_file_extensions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsActive)
        {
            if (HasGodotClassMethod(MethodProxyName__is_active.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Query)
        {
            if (HasGodotClassMethod(MethodProxyName__query.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_get_file_extensions' method.
        /// </summary>
        public static readonly StringName _GetFileExtensions = "_get_file_extensions";
        /// <summary>
        /// Cached name for the '_is_active' method.
        /// </summary>
        public static readonly StringName _IsActive = "_is_active";
        /// <summary>
        /// Cached name for the '_query' method.
        /// </summary>
        public static readonly StringName _Query = "_query";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
