namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This editor-only singleton returns OS-specific paths to various data folders and files. It can be used in editor plugins to ensure files are saved in the correct location on each operating system.</para>
/// <para><b>Note:</b> This singleton is not accessible in exported projects. Attempting to access it in an exported project will result in a script error as the singleton won't be declared. To prevent script errors in exported projects, use <see cref="Godot.Engine.HasSingleton(StringName)"/> to check whether the singleton is available before using it.</para>
/// <para><b>Note:</b> On the Linux/BSD platform, Godot complies with the <a href="https://specifications.freedesktop.org/basedir-spec/basedir-spec-latest.html">XDG Base Directory Specification</a>. You can override environment variables following the specification to change the editor and project data paths.</para>
/// </summary>
public partial class EditorPaths : GodotObject
{
    private static readonly System.Type CachedType = typeof(EditorPaths);

    private static readonly StringName NativeName = "EditorPaths";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorPaths() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorPaths(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorPaths(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDataDir, 201670096ul);

    /// <summary>
    /// <para>Returns the absolute path to the user's data folder. This folder should be used for <i>persistent</i> user data files such as installed export templates.</para>
    /// <para><b>Default paths per platform:</b></para>
    /// <para><code>
    /// - Windows: %APPDATA%\Godot\                    (same as `get_config_dir()`)
    /// - macOS: ~/Library/Application Support/Godot/  (same as `get_config_dir()`)
    /// - Linux: ~/.local/share/godot/
    /// </code></para>
    /// </summary>
    public string GetDataDir()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConfigDir, 201670096ul);

    /// <summary>
    /// <para>Returns the absolute path to the user's configuration folder. This folder should be used for <i>persistent</i> user configuration files.</para>
    /// <para><b>Default paths per platform:</b></para>
    /// <para><code>
    /// - Windows: %APPDATA%\Godot\                    (same as `get_data_dir()`)
    /// - macOS: ~/Library/Application Support/Godot/  (same as `get_data_dir()`)
    /// - Linux: ~/.config/godot/
    /// </code></para>
    /// </summary>
    public string GetConfigDir()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCacheDir, 201670096ul);

    /// <summary>
    /// <para>Returns the absolute path to the user's cache folder. This folder should be used for temporary data that can be removed safely whenever the editor is closed (such as generated resource thumbnails).</para>
    /// <para><b>Default paths per platform:</b></para>
    /// <para><code>
    /// - Windows: %LOCALAPPDATA%\Godot\
    /// - macOS: ~/Library/Caches/Godot/
    /// - Linux: ~/.cache/godot/
    /// </code></para>
    /// </summary>
    public string GetCacheDir()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSelfContained, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the editor is marked as self-contained, <see langword="false"/> otherwise. When self-contained mode is enabled, user configuration, data and cache files are saved in an <c>editor_data/</c> folder next to the editor binary. This makes portable usage easier and ensures the Godot editor minimizes file writes outside its own folder. Self-contained mode is not available for exported projects.</para>
    /// <para>Self-contained mode can be enabled by creating a file named <c>._sc_</c> or <c>_sc_</c> in the same folder as the editor binary or macOS .app bundle while the editor is not running. See also <see cref="Godot.EditorPaths.GetSelfContainedFile()"/>.</para>
    /// <para><b>Note:</b> On macOS, quarantine flag should be manually removed before using self-contained mode, see <a href="https://docs.godotengine.org/en/stable/tutorials/export/running_on_macos.html">Running on macOS</a>.</para>
    /// <para><b>Note:</b> On macOS, placing <c>_sc_</c> or any other file inside .app bundle will break digital signature and make it non-portable, consider placing it in the same folder as the .app bundle instead.</para>
    /// <para><b>Note:</b> The Steam release of Godot uses self-contained mode by default.</para>
    /// </summary>
    public bool IsSelfContained()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelfContainedFile, 201670096ul);

    /// <summary>
    /// <para>Returns the absolute path to the self-contained file that makes the current Godot editor instance be considered as self-contained. Returns an empty string if the current Godot editor instance isn't self-contained. See also <see cref="Godot.EditorPaths.IsSelfContained()"/>.</para>
    /// </summary>
    public string GetSelfContainedFile()
    {
        return NativeCalls.godot_icall_0_58(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjectSettingsDir, 201670096ul);

    /// <summary>
    /// <para>Returns the relative path to the editor settings for this project. This is usually <c>"res://.godot/editor"</c>. Projects all have a unique subdirectory inside the settings path where project-specific editor settings are saved.</para>
    /// </summary>
    public string GetProjectSettingsDir()
    {
        return NativeCalls.godot_icall_0_58(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'get_data_dir' method.
        /// </summary>
        public static readonly StringName GetDataDir = "get_data_dir";
        /// <summary>
        /// Cached name for the 'get_config_dir' method.
        /// </summary>
        public static readonly StringName GetConfigDir = "get_config_dir";
        /// <summary>
        /// Cached name for the 'get_cache_dir' method.
        /// </summary>
        public static readonly StringName GetCacheDir = "get_cache_dir";
        /// <summary>
        /// Cached name for the 'is_self_contained' method.
        /// </summary>
        public static readonly StringName IsSelfContained = "is_self_contained";
        /// <summary>
        /// Cached name for the 'get_self_contained_file' method.
        /// </summary>
        public static readonly StringName GetSelfContainedFile = "get_self_contained_file";
        /// <summary>
        /// Cached name for the 'get_project_settings_dir' method.
        /// </summary>
        public static readonly StringName GetProjectSettingsDir = "get_project_settings_dir";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
