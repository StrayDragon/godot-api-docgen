namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An editor feature profile can be used to disable specific features of the Godot editor. When disabled, the features won't appear in the editor, which makes the editor less cluttered. This is useful in education settings to reduce confusion or when working in a team. For example, artists and level designers could use a feature profile that disables the script editor to avoid accidentally making changes to files they aren't supposed to edit.</para>
/// <para>To manage editor feature profiles visually, use <b>Editor &gt; Manage Feature Profiles...</b> at the top of the editor window.</para>
/// </summary>
public partial class EditorFeatureProfile : RefCounted
{
    public enum Feature : long
    {
        /// <summary>
        /// <para>The 3D editor. If this feature is disabled, the 3D editor won't display but 3D nodes will still display in the Create New Node dialog.</para>
        /// </summary>
        Feature3D = 0,
        /// <summary>
        /// <para>The Script tab, which contains the script editor and class reference browser. If this feature is disabled, the Script tab won't display.</para>
        /// </summary>
        Script = 1,
        /// <summary>
        /// <para>The AssetLib tab. If this feature is disabled, the AssetLib tab won't display.</para>
        /// </summary>
        AssetLib = 2,
        /// <summary>
        /// <para>Scene tree editing. If this feature is disabled, the Scene tree dock will still be visible but will be read-only.</para>
        /// </summary>
        SceneTree = 3,
        /// <summary>
        /// <para>The Node dock. If this feature is disabled, signals and groups won't be visible and modifiable from the editor.</para>
        /// </summary>
        [Obsolete("Replaced by the Signals and Groups docks.")]
        NodeDock = 4,
        /// <summary>
        /// <para>The FileSystem dock. If this feature is disabled, the FileSystem dock won't be visible.</para>
        /// </summary>
        FilesystemDock = 5,
        /// <summary>
        /// <para>The Import dock. If this feature is disabled, the Import dock won't be visible.</para>
        /// </summary>
        ImportDock = 6,
        /// <summary>
        /// <para>The History dock. If this feature is disabled, the History dock won't be visible.</para>
        /// </summary>
        HistoryDock = 7,
        /// <summary>
        /// <para>The Game tab, which allows embedding the game window and selecting nodes by clicking inside of it. If this feature is disabled, the Game tab won't display.</para>
        /// </summary>
        Game = 8,
        /// <summary>
        /// <para>The Signals dock. If this feature is disabled, signals won't be visible and modifiable from the editor.</para>
        /// </summary>
        SignalsDock = 9,
        /// <summary>
        /// <para>The Groups dock. If this feature is disabled, groups won't be visible and modifiable from the editor.</para>
        /// </summary>
        GroupsDock = 10,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.EditorFeatureProfile.Feature"/> enum.</para>
        /// </summary>
        Max = 11
    }

    private static readonly System.Type CachedType = typeof(EditorFeatureProfile);

    private static readonly StringName NativeName = "EditorFeatureProfile";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorFeatureProfile() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorFeatureProfile(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorFeatureProfile(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableClass, 2524380260ul);

    /// <summary>
    /// <para>If <paramref name="disable"/> is <see langword="true"/>, disables the class specified by <paramref name="className"/>. When disabled, the class won't appear in the Create New Node dialog.</para>
    /// </summary>
    public void SetDisableClass(StringName className, bool disable)
    {
        NativeCalls.godot_icall_2_163(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(className?.NativeValue ?? default), disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClassDisabled, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the class specified by <paramref name="className"/> is disabled. When disabled, the class won't appear in the Create New Node dialog.</para>
    /// </summary>
    public bool IsClassDisabled(StringName className)
    {
        return NativeCalls.godot_icall_1_105(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(className?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableClassEditor, 2524380260ul);

    /// <summary>
    /// <para>If <paramref name="disable"/> is <see langword="true"/>, disables editing for the class specified by <paramref name="className"/>. When disabled, the class will still appear in the Create New Node dialog but the Inspector will be read-only when selecting a node that extends the class.</para>
    /// </summary>
    public void SetDisableClassEditor(StringName className, bool disable)
    {
        NativeCalls.godot_icall_2_163(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(className?.NativeValue ?? default), disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClassEditorDisabled, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if editing for the class specified by <paramref name="className"/> is disabled. When disabled, the class will still appear in the Create New Node dialog but the Inspector will be read-only when selecting a node that extends the class.</para>
    /// </summary>
    public bool IsClassEditorDisabled(StringName className)
    {
        return NativeCalls.godot_icall_1_105(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(className?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableClassProperty, 865197084ul);

    /// <summary>
    /// <para>If <paramref name="disable"/> is <see langword="true"/>, disables editing for <paramref name="property"/> in the class specified by <paramref name="className"/>. When a property is disabled, it won't appear in the Inspector when selecting a node that extends the class specified by <paramref name="className"/>.</para>
    /// </summary>
    public void SetDisableClassProperty(StringName className, StringName property, bool disable)
    {
        EditorNativeCalls.godot_icall_3_489(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(className?.NativeValue ?? default), (godot_string_name)(property?.NativeValue ?? default), disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClassPropertyDisabled, 471820014ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="property"/> is disabled in the class specified by <paramref name="className"/>. When a property is disabled, it won't appear in the Inspector when selecting a node that extends the class specified by <paramref name="className"/>.</para>
    /// </summary>
    public bool IsClassPropertyDisabled(StringName className, StringName property)
    {
        return NativeCalls.godot_icall_2_160(MethodBind5, GodotObject.GetPtr(this), (godot_string_name)(className?.NativeValue ?? default), (godot_string_name)(property?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableFeature, 1884871044ul);

    /// <summary>
    /// <para>If <paramref name="disable"/> is <see langword="true"/>, disables the editor feature specified in <paramref name="feature"/>. When a feature is disabled, it will disappear from the editor entirely.</para>
    /// </summary>
    public void SetDisableFeature(EditorFeatureProfile.Feature feature, bool disable)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(this), (int)feature, disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFeatureDisabled, 2974403161ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <paramref name="feature"/> is disabled. When a feature is disabled, it will disappear from the editor entirely.</para>
    /// </summary>
    public bool IsFeatureDisabled(EditorFeatureProfile.Feature feature)
    {
        return NativeCalls.godot_icall_1_62(MethodBind7, GodotObject.GetPtr(this), (int)feature).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFeatureName, 3401335809ul);

    /// <summary>
    /// <para>Returns the specified <paramref name="feature"/>'s human-readable name.</para>
    /// </summary>
    public string GetFeatureName(EditorFeatureProfile.Feature feature)
    {
        return NativeCalls.godot_icall_1_133(MethodBind8, GodotObject.GetPtr(this), (int)feature);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveToFile, 166001499ul);

    /// <summary>
    /// <para>Saves the editor feature profile to a file in JSON format. It can then be imported using the feature profile manager's <b>Import</b> button or the <see cref="Godot.EditorFeatureProfile.LoadFromFile(string)"/> method.</para>
    /// <para><b>Note:</b> Feature profiles created via the user interface are saved in the <c>feature_profiles</c> directory, as a file with the <c>.profile</c> extension. The editor configuration folder can be found by using <see cref="Godot.EditorPaths.GetConfigDir()"/>.</para>
    /// </summary>
    public Error SaveToFile(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind9, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromFile, 166001499ul);

    /// <summary>
    /// <para>Loads an editor feature profile from a file. The file must follow the JSON format obtained by using the feature profile manager's <b>Export</b> button or the <see cref="Godot.EditorFeatureProfile.SaveToFile(string)"/> method.</para>
    /// <para><b>Note:</b> Feature profiles created via the user interface are loaded from the <c>feature_profiles</c> directory, as a file with the <c>.profile</c> extension. The editor configuration folder can be found by using <see cref="Godot.EditorPaths.GetConfigDir()"/>.</para>
    /// </summary>
    public Error LoadFromFile(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind10, GodotObject.GetPtr(this), path);
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_disable_class' method.
        /// </summary>
        public static readonly StringName SetDisableClass = "set_disable_class";
        /// <summary>
        /// Cached name for the 'is_class_disabled' method.
        /// </summary>
        public static readonly StringName IsClassDisabled = "is_class_disabled";
        /// <summary>
        /// Cached name for the 'set_disable_class_editor' method.
        /// </summary>
        public static readonly StringName SetDisableClassEditor = "set_disable_class_editor";
        /// <summary>
        /// Cached name for the 'is_class_editor_disabled' method.
        /// </summary>
        public static readonly StringName IsClassEditorDisabled = "is_class_editor_disabled";
        /// <summary>
        /// Cached name for the 'set_disable_class_property' method.
        /// </summary>
        public static readonly StringName SetDisableClassProperty = "set_disable_class_property";
        /// <summary>
        /// Cached name for the 'is_class_property_disabled' method.
        /// </summary>
        public static readonly StringName IsClassPropertyDisabled = "is_class_property_disabled";
        /// <summary>
        /// Cached name for the 'set_disable_feature' method.
        /// </summary>
        public static readonly StringName SetDisableFeature = "set_disable_feature";
        /// <summary>
        /// Cached name for the 'is_feature_disabled' method.
        /// </summary>
        public static readonly StringName IsFeatureDisabled = "is_feature_disabled";
        /// <summary>
        /// Cached name for the 'get_feature_name' method.
        /// </summary>
        public static readonly StringName GetFeatureName = "get_feature_name";
        /// <summary>
        /// Cached name for the 'save_to_file' method.
        /// </summary>
        public static readonly StringName SaveToFile = "save_to_file";
        /// <summary>
        /// Cached name for the 'load_from_file' method.
        /// </summary>
        public static readonly StringName LoadFromFile = "load_from_file";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
