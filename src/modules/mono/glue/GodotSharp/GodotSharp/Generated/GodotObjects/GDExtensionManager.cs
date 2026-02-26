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
public static partial class GDExtensionManager
{
    public enum LoadStatus : long
    {
        /// <summary>
        /// <para>The extension has loaded successfully.</para>
        /// </summary>
        Ok = 0,
        /// <summary>
        /// <para>The extension has failed to load, possibly because it does not exist or has missing dependencies.</para>
        /// </summary>
        Failed = 1,
        /// <summary>
        /// <para>The extension has already been loaded.</para>
        /// </summary>
        AlreadyLoaded = 2,
        /// <summary>
        /// <para>The extension has not been loaded.</para>
        /// </summary>
        NotLoaded = 3,
        /// <summary>
        /// <para>The extension requires the application to restart to fully load.</para>
        /// </summary>
        NeedsRestart = 4
    }

    private static readonly StringName NativeName = "GDExtensionManager";

    private static GDExtensionManagerInstance singleton;

    public static GDExtensionManagerInstance Singleton =>
        singleton ??= (GDExtensionManagerInstance)InteropUtils.EngineGetSingleton("GDExtensionManager");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadExtension, 4024158731ul);

    /// <summary>
    /// <para>Loads an extension by absolute file path. The <paramref name="path"/> needs to point to a valid <see cref="Godot.GDExtension"/>. Returns <see cref="Godot.GDExtensionManager.LoadStatus.Ok"/> if successful.</para>
    /// </summary>
    public static GDExtensionManager.LoadStatus LoadExtension(string path)
    {
        return (GDExtensionManager.LoadStatus)NativeCalls.godot_icall_1_134(MethodBind0, GodotObject.GetPtr(Singleton), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReloadExtension, 4024158731ul);

    /// <summary>
    /// <para>Reloads the extension at the given file path. The <paramref name="path"/> needs to point to a valid <see cref="Godot.GDExtension"/>, otherwise this method may return either <see cref="Godot.GDExtensionManager.LoadStatus.NotLoaded"/> or <see cref="Godot.GDExtensionManager.LoadStatus.Failed"/>.</para>
    /// <para><b>Note:</b> You can only reload extensions in the editor. In release builds, this method always fails and returns <see cref="Godot.GDExtensionManager.LoadStatus.Failed"/>.</para>
    /// </summary>
    public static GDExtensionManager.LoadStatus ReloadExtension(string path)
    {
        return (GDExtensionManager.LoadStatus)NativeCalls.godot_icall_1_134(MethodBind1, GodotObject.GetPtr(Singleton), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.UnloadExtension, 4024158731ul);

    /// <summary>
    /// <para>Unloads an extension by file path. The <paramref name="path"/> needs to point to an already loaded <see cref="Godot.GDExtension"/>, otherwise this method returns <see cref="Godot.GDExtensionManager.LoadStatus.NotLoaded"/>.</para>
    /// </summary>
    public static GDExtensionManager.LoadStatus UnloadExtension(string path)
    {
        return (GDExtensionManager.LoadStatus)NativeCalls.godot_icall_1_134(MethodBind2, GodotObject.GetPtr(Singleton), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsExtensionLoaded, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the extension at the given file <paramref name="path"/> has already been loaded successfully. See also <see cref="Godot.GDExtensionManager.GetLoadedExtensions()"/>.</para>
    /// </summary>
    public static bool IsExtensionLoaded(string path)
    {
        return NativeCalls.godot_icall_1_131(MethodBind3, GodotObject.GetPtr(Singleton), path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoadedExtensions, 1139954409ul);

    /// <summary>
    /// <para>Returns the file paths of all currently loaded extensions.</para>
    /// </summary>
    public static string[] GetLoadedExtensions()
    {
        return NativeCalls.godot_icall_0_108(MethodBind4, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExtension, 49743343ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.GDExtension"/> at the given file <paramref name="path"/>, or <see langword="null"/> if it has not been loaded or does not exist.</para>
    /// </summary>
    public static GDExtension GetExtension(string path)
    {
        return (GDExtension)NativeCalls.godot_icall_1_533(MethodBind5, GodotObject.GetPtr(Singleton), path);
    }

    /// <summary>
    /// <para>Emitted after the editor has finished reloading one or more extensions.</para>
    /// </summary>
    public static event Action ExtensionsReloaded
    {
        add => Singleton.Connect(SignalName.ExtensionsReloaded, Callable.From(value));
        remove => Singleton.Disconnect(SignalName.ExtensionsReloaded, Callable.From(value));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GDExtensionManager.ExtensionLoaded"/> event of a <see cref="Godot.GDExtensionManager"/> class.
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
    public static unsafe event ExtensionLoadedEventHandler ExtensionLoaded
    {
        add => Singleton.Connect(SignalName.ExtensionLoaded, Callable.CreateWithUnsafeTrampoline(value, &ExtensionLoadedTrampoline));
        remove => Singleton.Disconnect(SignalName.ExtensionLoaded, Callable.CreateWithUnsafeTrampoline(value, &ExtensionLoadedTrampoline));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GDExtensionManager.ExtensionUnloading"/> event of a <see cref="Godot.GDExtensionManager"/> class.
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
    public static unsafe event ExtensionUnloadingEventHandler ExtensionUnloading
    {
        add => Singleton.Connect(SignalName.ExtensionUnloading, Callable.CreateWithUnsafeTrampoline(value, &ExtensionUnloadingTrampoline));
        remove => Singleton.Disconnect(SignalName.ExtensionUnloading, Callable.CreateWithUnsafeTrampoline(value, &ExtensionUnloadingTrampoline));
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
    public class SignalName
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
