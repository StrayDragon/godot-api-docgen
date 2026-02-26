namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The GDExtensionManager loads, initializes, and keeps track of all available <see cref="Godot.GDExtension"/> libraries in the project.</para>
/// <para><b>Note:</b> Do not worry about GDExtension unless you know what you are doing.</para>
/// </summary>
[GodotClassName("GDExtensionManager")]
public partial class GDExtensionManagerInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(GDExtensionManagerInstance);

    private static readonly StringName NativeName = "GDExtensionManager";

    internal GDExtensionManagerInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GDExtensionManagerInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GDExtensionManagerInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadExtension, 4024158731ul);

    /// <summary>
    /// <para>Loads an extension by absolute file path. The <paramref name="path"/> needs to point to a valid <see cref="Godot.GDExtension"/>. Returns <see cref="Godot.GDExtensionManager.LoadStatus.Ok"/> if successful.</para>
    /// </summary>
    public GDExtensionManager.LoadStatus LoadExtension(string path)
    {
        return (GDExtensionManager.LoadStatus)NativeCalls.godot_icall_1_134(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReloadExtension, 4024158731ul);

    /// <summary>
    /// <para>Reloads the extension at the given file path. The <paramref name="path"/> needs to point to a valid <see cref="Godot.GDExtension"/>, otherwise this method may return either <see cref="Godot.GDExtensionManager.LoadStatus.NotLoaded"/> or <see cref="Godot.GDExtensionManager.LoadStatus.Failed"/>.</para>
    /// <para><b>Note:</b> You can only reload extensions in the editor. In release builds, this method always fails and returns <see cref="Godot.GDExtensionManager.LoadStatus.Failed"/>.</para>
    /// </summary>
    public GDExtensionManager.LoadStatus ReloadExtension(string path)
    {
        return (GDExtensionManager.LoadStatus)NativeCalls.godot_icall_1_134(MethodBind1, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnloadExtension, 4024158731ul);

    /// <summary>
    /// <para>Unloads an extension by file path. The <paramref name="path"/> needs to point to an already loaded <see cref="Godot.GDExtension"/>, otherwise this method returns <see cref="Godot.GDExtensionManager.LoadStatus.NotLoaded"/>.</para>
    /// </summary>
    public GDExtensionManager.LoadStatus UnloadExtension(string path)
    {
        return (GDExtensionManager.LoadStatus)NativeCalls.godot_icall_1_134(MethodBind2, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsExtensionLoaded, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the extension at the given file <paramref name="path"/> has already been loaded successfully. See also <see cref="Godot.GDExtensionManagerInstance.GetLoadedExtensions()"/>.</para>
    /// </summary>
    public bool IsExtensionLoaded(string path)
    {
        return NativeCalls.godot_icall_1_131(MethodBind3, GodotObject.GetPtr(this), path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoadedExtensions, 1139954409ul);

    /// <summary>
    /// <para>Returns the file paths of all currently loaded extensions.</para>
    /// </summary>
    public string[] GetLoadedExtensions()
    {
        return NativeCalls.godot_icall_0_108(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExtension, 49743343ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.GDExtension"/> at the given file <paramref name="path"/>, or <see langword="null"/> if it has not been loaded or does not exist.</para>
    /// </summary>
    public GDExtension GetExtension(string path)
    {
        return (GDExtension)NativeCalls.godot_icall_1_533(MethodBind5, GodotObject.GetPtr(this), path);
    }

    /// <summary>
    /// <para>Emitted after the editor has finished reloading one or more extensions.</para>
    /// </summary>
    public event Action ExtensionsReloaded
    {
        add => Connect(SignalName.ExtensionsReloaded, Callable.From(value));
        remove => Disconnect(SignalName.ExtensionsReloaded, Callable.From(value));
    }

    protected void EmitSignalExtensionsReloaded()
    {
        EmitSignal(SignalName.ExtensionsReloaded);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GDExtensionManagerInstance.ExtensionLoaded"/> event of a <see cref="Godot.GDExtensionManagerInstance"/> class.
    /// </summary>
    public delegate void ExtensionLoadedEventHandler(GDExtension extension);

    private static void ExtensionLoadedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ExtensionLoadedEventHandler)delegateObj)(VariantUtils.ConvertTo<GDExtension>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted after the editor has finished loading a new extension.</para>
    /// <para><b>Note:</b> This signal is only emitted in editor builds.</para>
    /// </summary>
    public unsafe event ExtensionLoadedEventHandler ExtensionLoaded
    {
        add => Connect(SignalName.ExtensionLoaded, Callable.CreateWithUnsafeTrampoline(value, &ExtensionLoadedTrampoline));
        remove => Disconnect(SignalName.ExtensionLoaded, Callable.CreateWithUnsafeTrampoline(value, &ExtensionLoadedTrampoline));
    }

    protected void EmitSignalExtensionLoaded(GDExtension extension)
    {
        EmitSignal(SignalName.ExtensionLoaded, extension);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GDExtensionManagerInstance.ExtensionUnloading"/> event of a <see cref="Godot.GDExtensionManagerInstance"/> class.
    /// </summary>
    public delegate void ExtensionUnloadingEventHandler(GDExtension extension);

    private static void ExtensionUnloadingTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ExtensionUnloadingEventHandler)delegateObj)(VariantUtils.ConvertTo<GDExtension>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted before the editor starts unloading an extension.</para>
    /// <para><b>Note:</b> This signal is only emitted in editor builds.</para>
    /// </summary>
    public unsafe event ExtensionUnloadingEventHandler ExtensionUnloading
    {
        add => Connect(SignalName.ExtensionUnloading, Callable.CreateWithUnsafeTrampoline(value, &ExtensionUnloadingTrampoline));
        remove => Disconnect(SignalName.ExtensionUnloading, Callable.CreateWithUnsafeTrampoline(value, &ExtensionUnloadingTrampoline));
    }

    protected void EmitSignalExtensionUnloading(GDExtension extension)
    {
        EmitSignal(SignalName.ExtensionUnloading, extension);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_extensions_reloaded = "ExtensionsReloaded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_extension_loaded = "ExtensionLoaded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_extension_unloading = "ExtensionUnloading";

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
        if (signal == SignalName.ExtensionsReloaded)
        {
            if (HasGodotClassSignal(SignalProxyName_extensions_reloaded.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ExtensionLoaded)
        {
            if (HasGodotClassSignal(SignalProxyName_extension_loaded.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ExtensionUnloading)
        {
            if (HasGodotClassSignal(SignalProxyName_extension_unloading.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the 'load_extension' method.
        /// </summary>
        public static readonly StringName LoadExtension = "load_extension";
        /// <summary>
        /// Cached name for the 'reload_extension' method.
        /// </summary>
        public static readonly StringName ReloadExtension = "reload_extension";
        /// <summary>
        /// Cached name for the 'unload_extension' method.
        /// </summary>
        public static readonly StringName UnloadExtension = "unload_extension";
        /// <summary>
        /// Cached name for the 'is_extension_loaded' method.
        /// </summary>
        public static readonly StringName IsExtensionLoaded = "is_extension_loaded";
        /// <summary>
        /// Cached name for the 'get_loaded_extensions' method.
        /// </summary>
        public static readonly StringName GetLoadedExtensions = "get_loaded_extensions";
        /// <summary>
        /// Cached name for the 'get_extension' method.
        /// </summary>
        public static readonly StringName GetExtension = "get_extension";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
        /// <summary>
        /// Cached name for the 'extensions_reloaded' signal.
        /// </summary>
        public static readonly StringName ExtensionsReloaded = "extensions_reloaded";
        /// <summary>
        /// Cached name for the 'extension_loaded' signal.
        /// </summary>
        public static readonly StringName ExtensionLoaded = "extension_loaded";
        /// <summary>
        /// Cached name for the 'extension_unloading' signal.
        /// </summary>
        public static readonly StringName ExtensionUnloading = "extension_unloading";
    }
}
