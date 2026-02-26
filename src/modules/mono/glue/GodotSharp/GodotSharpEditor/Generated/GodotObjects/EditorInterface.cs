namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.EditorInterface"/> gives you control over Godot editor's window. It allows customizing the window, saving and (re-)loading scenes, rendering mesh previews, inspecting and editing resources and objects, and provides access to <see cref="Godot.EditorSettings"/>, <see cref="Godot.EditorFileSystem"/>, <see cref="Godot.EditorResourcePreview"/>, <see cref="Godot.ScriptEditor"/>, the editor viewport, and information about scenes.</para>
/// <para><b>Note:</b> This class shouldn't be instantiated directly. Instead, access the singleton directly by its name.</para>
/// <para><code>
/// // In C# you can access it via the static Singleton property.
/// EditorSettings settings = EditorInterface.Singleton.GetEditorSettings();
/// </code></para>
/// </summary>
public partial class EditorInterface : GodotObject
{
    /// <summary>
    /// <para>If <see langword="true"/>, enables distraction-free mode which hides side docks to increase the space available for the main view.</para>
    /// </summary>
    public bool DistractionFreeMode
    {
        get
        {
            return IsDistractionFreeModeEnabled();
        }
        set
        {
            SetDistractionFreeMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the Movie Maker mode is enabled in the editor. See <see cref="Godot.MovieWriter"/> for more information.</para>
    /// </summary>
    public bool MovieMakerEnabled
    {
        get
        {
            return IsMovieMakerEnabled();
        }
        set
        {
            SetMovieMakerEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(EditorInterface);

    private static readonly StringName NativeName = "EditorInterface";

    private static EditorInterface singleton;

    public static EditorInterface Singleton =>
        singleton ??= (EditorInterface)InteropUtils.EngineGetSingleton("EditorInterface");

    internal EditorInterface() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorInterface(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorInterface(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RestartEditor, 3216645846ul);

    /// <summary>
    /// <para>Restarts the editor. This closes the editor and then opens the same project. If <paramref name="save"/> is <see langword="true"/>, the project will be saved before restarting.</para>
    /// </summary>
    public void RestartEditor(bool save = true)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), save.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCommandPalette, 2471163807ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.EditorCommandPalette"/> instance.</para>
    /// <para><b>Warning:</b> Removing and freeing this node will render a part of the editor useless and may cause a crash.</para>
    /// </summary>
    public EditorCommandPalette GetCommandPalette()
    {
        return (EditorCommandPalette)NativeCalls.godot_icall_0_53(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResourceFilesystem, 780151678ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.EditorFileSystem"/> instance.</para>
    /// </summary>
    public EditorFileSystem GetResourceFilesystem()
    {
        return (EditorFileSystem)NativeCalls.godot_icall_0_53(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorPaths, 1595760068ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.EditorPaths"/> singleton.</para>
    /// </summary>
    public EditorPaths GetEditorPaths()
    {
        return (EditorPaths)NativeCalls.godot_icall_0_53(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResourcePreviewer, 943486957ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.EditorResourcePreview"/> instance.</para>
    /// </summary>
    public EditorResourcePreview GetResourcePreviewer()
    {
        return (EditorResourcePreview)NativeCalls.godot_icall_0_53(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelection, 2690272531ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.EditorSelection"/> instance.</para>
    /// </summary>
    public EditorSelection GetSelection()
    {
        return (EditorSelection)NativeCalls.godot_icall_0_53(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorSettings, 4086932459ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.EditorSettings"/> instance.</para>
    /// </summary>
    public EditorSettings GetEditorSettings()
    {
        return (EditorSettings)NativeCalls.godot_icall_0_63(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorToaster, 3612675797ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.EditorToaster"/>.</para>
    /// </summary>
    public EditorToaster GetEditorToaster()
    {
        return (EditorToaster)NativeCalls.godot_icall_0_53(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorUndoRedo, 3819628421ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.EditorUndoRedoManager"/>.</para>
    /// </summary>
    public EditorUndoRedoManager GetEditorUndoRedo()
    {
        return (EditorUndoRedoManager)NativeCalls.godot_icall_0_53(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeMeshPreviews, 878078554ul);

    /// <summary>
    /// <para>Returns mesh previews rendered at the given size as an <see cref="Godot.Collections.Array"/> of <see cref="Godot.Texture2D"/>s.</para>
    /// </summary>
    public Godot.Collections.Array<Texture2D> MakeMeshPreviews(Godot.Collections.Array<Mesh> meshes, int previewSize)
    {
        return new Godot.Collections.Array<Texture2D>(EditorNativeCalls.godot_icall_2_496(MethodBind9, GodotObject.GetPtr(this), (godot_array)(meshes ?? new()).NativeValue, previewSize));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPluginEnabled, 2678287736ul);

    /// <summary>
    /// <para>Sets the enabled status of a plugin. The plugin name is the same as its directory name.</para>
    /// </summary>
    public void SetPluginEnabled(string plugin, bool enabled)
    {
        NativeCalls.godot_icall_2_497(MethodBind10, GodotObject.GetPtr(this), plugin, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPluginEnabled, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified <paramref name="plugin"/> is enabled. The plugin name is the same as its directory name.</para>
    /// </summary>
    public bool IsPluginEnabled(string plugin)
    {
        return NativeCalls.godot_icall_1_131(MethodBind11, GodotObject.GetPtr(this), plugin).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorTheme, 3846893731ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.Theme"/>.</para>
    /// <para><b>Note:</b> When creating custom editor UI, prefer accessing theme items directly from your GUI nodes using the <c>get_theme_*</c> methods.</para>
    /// </summary>
    public Theme GetEditorTheme()
    {
        return (Theme)NativeCalls.godot_icall_0_63(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBaseControl, 2783021301ul);

    /// <summary>
    /// <para>Returns the main container of Godot editor's window. For example, you can use it to retrieve the size of the container and place your controls accordingly.</para>
    /// <para><b>Warning:</b> Removing and freeing this node will render the editor useless and may cause a crash.</para>
    /// </summary>
    public Control GetBaseControl()
    {
        return (Control)NativeCalls.godot_icall_0_53(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorMainScreen, 1706218421ul);

    /// <summary>
    /// <para>Returns the editor control responsible for main screen plugins and tools. Use it with plugins that implement <see cref="Godot.EditorPlugin._HasMainScreen()"/>.</para>
    /// <para><b>Note:</b> This node is a <see cref="Godot.VBoxContainer"/>, which means that if you add a <see cref="Godot.Control"/> child to it, you need to set the child's <see cref="Godot.Control.SizeFlagsVertical"/> to <see cref="Godot.Control.SizeFlags.ExpandFill"/> to make it use the full available space.</para>
    /// <para><b>Warning:</b> Removing and freeing this node will render a part of the editor useless and may cause a crash.</para>
    /// </summary>
    public VBoxContainer GetEditorMainScreen()
    {
        return (VBoxContainer)NativeCalls.godot_icall_0_53(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptEditor, 90868003ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.ScriptEditor"/> instance.</para>
    /// <para><b>Warning:</b> Removing and freeing this node will render a part of the editor useless and may cause a crash.</para>
    /// </summary>
    public ScriptEditor GetScriptEditor()
    {
        return (ScriptEditor)NativeCalls.godot_icall_0_53(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorViewport2D, 3750751911ul);

    /// <summary>
    /// <para>Returns the 2D editor <see cref="Godot.SubViewport"/>. It does not have a camera. Instead, the view transforms are done directly and can be accessed with <see cref="Godot.Viewport.GlobalCanvasTransform"/>.</para>
    /// </summary>
    public SubViewport GetEditorViewport2D()
    {
        return (SubViewport)NativeCalls.godot_icall_0_53(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorViewport3D, 1970834490ul);

    /// <summary>
    /// <para>Returns the specified 3D editor <see cref="Godot.SubViewport"/>, from <c>0</c> to <c>3</c>. The viewport can be used to access the active editor cameras with <see cref="Godot.Viewport.GetCamera3D()"/>.</para>
    /// </summary>
    public SubViewport GetEditorViewport3D(int idx = 0)
    {
        return (SubViewport)NativeCalls.godot_icall_1_335(MethodBind17, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMainScreenEditor, 83702148ul);

    /// <summary>
    /// <para>Sets the editor's current main screen to the one specified in <paramref name="name"/>. <paramref name="name"/> must match the title of the tab in question exactly (e.g. <c>2D</c>, <c>3D</c>, <c>Script</c>, <c>Game</c>, or <c>AssetLib</c> for default tabs).</para>
    /// </summary>
    public void SetMainScreenEditor(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind18, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDistractionFreeMode, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDistractionFreeMode(bool enter)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), enter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDistractionFreeModeEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDistractionFreeModeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMultiWindowEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if multiple window support is enabled in the editor. Multiple window support is enabled if <i>all</i> of these statements are true:</para>
    /// <para>- <c>EditorSettings.interface/multi_window/enable</c> is <see langword="true"/>.</para>
    /// <para>- <c>EditorSettings.interface/editor/single_window_mode</c> is <see langword="false"/>.</para>
    /// <para>- <see cref="Godot.Viewport.GuiEmbedSubwindows"/> is <see langword="false"/>. This is forced to <see langword="true"/> on platforms that don't support multiple windows such as Web, or when the <c>--single-window</c> <a href="$DOCS_URL/tutorials/editor/command_line_tutorial.html">command line argument</a> is used.</para>
    /// </summary>
    public bool IsMultiWindowEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorScale, 1740695150ul);

    /// <summary>
    /// <para>Returns the actual scale of the editor UI (<c>1.0</c> being 100% scale). This can be used to adjust position and dimensions of the UI added by plugins.</para>
    /// <para><b>Note:</b> This value is set via the <c>EditorSettings.interface/editor/display_scale</c> and <c>EditorSettings.interface/editor/custom_display_scale</c> settings. The editor must be restarted for changes to be properly applied.</para>
    /// </summary>
    public float GetEditorScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorLanguage, 201670096ul);

    /// <summary>
    /// <para>Returns the language currently used for the editor interface.</para>
    /// </summary>
    public string GetEditorLanguage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNode3DSnapEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the 3D editor currently has snapping mode enabled, and <see langword="false"/> otherwise.</para>
    /// </summary>
    public bool IsNode3DSnapEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNode3DTranslateSnap, 1740695150ul);

    /// <summary>
    /// <para>Returns the amount of units the 3D editor's translation snapping is set to.</para>
    /// </summary>
    public float GetNode3DTranslateSnap()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNode3DRotateSnap, 1740695150ul);

    /// <summary>
    /// <para>Returns the amount of degrees the 3D editor's rotational snapping is set to.</para>
    /// </summary>
    public float GetNode3DRotateSnap()
    {
        return NativeCalls.godot_icall_0_68(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNode3DScaleSnap, 1740695150ul);

    /// <summary>
    /// <para>Returns the amount of units the 3D editor's scale snapping is set to.</para>
    /// </summary>
    public float GetNode3DScaleSnap()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupDialog, 2015770942ul);

    /// <summary>
    /// <para>Pops up the <paramref name="dialog"/> in the editor UI with <see cref="Godot.Window.PopupExclusive(Node, Nullable{Rect2I})"/>. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Godot.Window.SetUnparentWhenInvisible(bool)"/>.</para>
    /// </summary>
    /// <param name="rect">If the parameter is null, then the default value is <c>new Rect2I(new Vector2I(0, 0), new Vector2I(0, 0))</c>.</param>
    public unsafe void PopupDialog(Window dialog, Nullable<Rect2I> rect = null)
    {
        Rect2I rectOrDefVal = rect.HasValue ? rect.Value : new Rect2I(new Vector2I(0, 0), new Vector2I(0, 0));
        NativeCalls.godot_icall_2_498(MethodBind28, GodotObject.GetPtr(this), GodotObject.GetPtr(dialog), &rectOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupDialogCentered, 346557367ul);

    /// <summary>
    /// <para>Pops up the <paramref name="dialog"/> in the editor UI with <see cref="Godot.Window.PopupExclusiveCentered(Node, Nullable{Vector2I})"/>. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Godot.Window.SetUnparentWhenInvisible(bool)"/>.</para>
    /// </summary>
    /// <param name="minsize">If the parameter is null, then the default value is <c>new Vector2I(0, 0)</c>.</param>
    public unsafe void PopupDialogCentered(Window dialog, Nullable<Vector2I> minsize = null)
    {
        Vector2I minsizeOrDefVal = minsize.HasValue ? minsize.Value : new Vector2I(0, 0);
        NativeCalls.godot_icall_2_499(MethodBind29, GodotObject.GetPtr(this), GodotObject.GetPtr(dialog), &minsizeOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupDialogCenteredRatio, 2093669136ul);

    /// <summary>
    /// <para>Pops up the <paramref name="dialog"/> in the editor UI with <see cref="Godot.Window.PopupExclusiveCenteredRatio(Node, float)"/>. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Godot.Window.SetUnparentWhenInvisible(bool)"/>.</para>
    /// </summary>
    public void PopupDialogCenteredRatio(Window dialog, float ratio = 0.8f)
    {
        NativeCalls.godot_icall_2_215(MethodBind30, GodotObject.GetPtr(this), GodotObject.GetPtr(dialog), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupDialogCenteredClamped, 3763385571ul);

    /// <summary>
    /// <para>Pops up the <paramref name="dialog"/> in the editor UI with <see cref="Godot.Window.PopupExclusiveCenteredClamped(Node, Nullable{Vector2I}, float)"/>. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Godot.Window.SetUnparentWhenInvisible(bool)"/>.</para>
    /// </summary>
    /// <param name="minsize">If the parameter is null, then the default value is <c>new Vector2I(0, 0)</c>.</param>
    public unsafe void PopupDialogCenteredClamped(Window dialog, Nullable<Vector2I> minsize = null, float fallbackRatio = 0.75f)
    {
        Vector2I minsizeOrDefVal = minsize.HasValue ? minsize.Value : new Vector2I(0, 0);
        NativeCalls.godot_icall_3_500(MethodBind31, GodotObject.GetPtr(this), GodotObject.GetPtr(dialog), &minsizeOrDefVal, fallbackRatio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentFeatureProfile, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the currently activated feature profile. If the default profile is currently active, an empty string is returned instead.</para>
    /// <para>In order to get a reference to the <see cref="Godot.EditorFeatureProfile"/>, you must load the feature profile using <see cref="Godot.EditorFeatureProfile.LoadFromFile(string)"/>.</para>
    /// <para><b>Note:</b> Feature profiles created via the user interface are loaded from the <c>feature_profiles</c> directory, as a file with the <c>.profile</c> extension. The editor configuration folder can be found by using <see cref="Godot.EditorPaths.GetConfigDir()"/>.</para>
    /// </summary>
    public string GetCurrentFeatureProfile()
    {
        return NativeCalls.godot_icall_0_58(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurrentFeatureProfile, 83702148ul);

    /// <summary>
    /// <para>Selects and activates the specified feature profile with the given <paramref name="profileName"/>. Set <paramref name="profileName"/> to an empty string to reset to the default feature profile.</para>
    /// <para>A feature profile can be created programmatically using the <see cref="Godot.EditorFeatureProfile"/> class.</para>
    /// <para><b>Note:</b> The feature profile that gets activated must be located in the <c>feature_profiles</c> directory, as a file with the <c>.profile</c> extension. If a profile could not be found, an error occurs. The editor configuration folder can be found by using <see cref="Godot.EditorPaths.GetConfigDir()"/>.</para>
    /// </summary>
    public void SetCurrentFeatureProfile(string profileName)
    {
        NativeCalls.godot_icall_1_57(MethodBind33, GodotObject.GetPtr(this), profileName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupNodeSelector, 2444591477ul);

    /// <summary>
    /// <para>Pops up an editor dialog for selecting a <see cref="Godot.Node"/> from the edited scene. The <paramref name="callback"/> must take a single argument of type <see cref="Godot.NodePath"/>. It is called on the selected <see cref="Godot.NodePath"/> or the empty path <c>^""</c> if the dialog is canceled. If <paramref name="validTypes"/> is provided, the dialog will only show Nodes that match one of the listed Node types. If <paramref name="currentValue"/> is provided, the Node will be automatically selected in the tree, if it exists.</para>
    /// <para><b>Example:</b> Display the node selection dialog as soon as this node is added to the tree for the first time:</para>
    /// <para><code>
    /// func _ready():
    /// 	if Engine.is_editor_hint():
    /// 		EditorInterface.popup_node_selector(_on_node_selected, ["Button"])
    /// 
    /// func _on_node_selected(node_path):
    /// 	if node_path.is_empty():
    /// 		print("node selection canceled")
    /// 	else:
    /// 		print("selected ", node_path)
    /// </code></para>
    /// </summary>
    public void PopupNodeSelector(Callable callback, Godot.Collections.Array<StringName> validTypes = null, Node currentValue = default)
    {
        EditorNativeCalls.godot_icall_3_501(MethodBind34, GodotObject.GetPtr(this), callback, (godot_array)(validTypes ?? new()).NativeValue, GodotObject.GetPtr(currentValue));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupPropertySelector, 2955609011ul);

    /// <summary>
    /// <para>Pops up an editor dialog for selecting properties from <paramref name="object"/>. The <paramref name="callback"/> must take a single argument of type <see cref="Godot.NodePath"/>. It is called on the selected property path (see <c>NodePath.get_as_property_path</c>) or the empty path <c>^""</c> if the dialog is canceled. If <paramref name="typeFilter"/> is provided, the dialog will only show properties that match one of the listed <see cref="Godot.Variant.Type"/> values. If <paramref name="currentValue"/> is provided, the property will be selected automatically in the property list, if it exists.</para>
    /// <para><code>
    /// func _ready():
    /// 	if Engine.is_editor_hint():
    /// 		EditorInterface.popup_property_selector(this, _on_property_selected, [TYPE_INT])
    /// 
    /// func _on_property_selected(property_path):
    /// 	if property_path.is_empty():
    /// 		print("property selection canceled")
    /// 	else:
    /// 		print("selected ", property_path)
    /// </code></para>
    /// </summary>
    /// <param name="typeFilter">If the parameter is null, then the default value is <c>Array.Empty&lt;int&gt;()</c>.</param>
    public void PopupPropertySelector(GodotObject @object, Callable callback, int[] typeFilter = null, string currentValue = "")
    {
        int[] typeFilterOrDefVal = typeFilter != null ? typeFilter : Array.Empty<int>();
        EditorNativeCalls.godot_icall_4_502(MethodBind35, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), callback, typeFilterOrDefVal, currentValue);
    }

    /// <summary>
    /// <para>Pops up an editor dialog for selecting properties from <paramref name="object"/>. The <paramref name="callback"/> must take a single argument of type <see cref="Godot.NodePath"/>. It is called on the selected property path (see <c>NodePath.get_as_property_path</c>) or the empty path <c>^""</c> if the dialog is canceled. If <paramref name="typeFilter"/> is provided, the dialog will only show properties that match one of the listed <see cref="Godot.Variant.Type"/> values. If <paramref name="currentValue"/> is provided, the property will be selected automatically in the property list, if it exists.</para>
    /// <para><code>
    /// func _ready():
    /// 	if Engine.is_editor_hint():
    /// 		EditorInterface.popup_property_selector(this, _on_property_selected, [TYPE_INT])
    /// 
    /// func _on_property_selected(property_path):
    /// 	if property_path.is_empty():
    /// 		print("property selection canceled")
    /// 	else:
    /// 		print("selected ", property_path)
    /// </code></para>
    /// </summary>
    public void PopupPropertySelector(GodotObject @object, Callable callback, ReadOnlySpan<int> typeFilter, string currentValue)
    {
        EditorNativeCalls.godot_icall_4_502(MethodBind35, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), callback, typeFilter, currentValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupMethodSelector, 3585505226ul);

    /// <summary>
    /// <para>Pops up an editor dialog for selecting a method from <paramref name="object"/>. The <paramref name="callback"/> must take a single argument of type <see cref="string"/> which will contain the name of the selected method or be empty if the dialog is canceled. If <paramref name="currentValue"/> is provided, the method will be selected automatically in the method list, if it exists.</para>
    /// </summary>
    public void PopupMethodSelector(GodotObject @object, Callable callback, string currentValue = "")
    {
        EditorNativeCalls.godot_icall_3_503(MethodBind36, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), callback, currentValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupQuickOpen, 2271411043ul);

    /// <summary>
    /// <para>Pops up an editor dialog for quick selecting a resource file. The <paramref name="callback"/> must take a single argument of type <see cref="string"/> which will contain the path of the selected resource or be empty if the dialog is canceled. If <paramref name="baseTypes"/> is provided, the dialog will only show resources that match these types. Only types deriving from <see cref="Godot.Resource"/> are supported.</para>
    /// </summary>
    public void PopupQuickOpen(Callable callback, Godot.Collections.Array<StringName> baseTypes = null)
    {
        EditorNativeCalls.godot_icall_2_504(MethodBind37, GodotObject.GetPtr(this), callback, (godot_array)(baseTypes ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupCreateDialog, 495277124ul);

    /// <summary>
    /// <para>Pops up an editor dialog for creating an object.</para>
    /// <para>The <paramref name="callback"/> must take a single argument of type <see cref="string"/>, which will contain the type name of the selected object (or the script path of the type, if the type is created from a script), or be an empty string if no item is selected.</para>
    /// <para>The <paramref name="baseType"/> specifies the base type of objects to display. For example, if you set this to "Resource", all types derived from <see cref="Godot.Resource"/> will display in the create dialog.</para>
    /// <para>The <paramref name="currentType"/> will be passed in the search box of the create dialog, and the specified type can be immediately selected when the dialog pops up. If the <paramref name="currentType"/> is not derived from <paramref name="baseType"/>, there will be no result of the type in the dialog.</para>
    /// <para>The <paramref name="dialogTitle"/> allows you to define a custom title for the dialog. This is useful if you want to accurately hint the usage of the dialog. If the <paramref name="dialogTitle"/> is an empty string, the dialog will use "Create New 'Base Type'" as the default title.</para>
    /// <para>The <paramref name="typeBlocklist"/> contains a list of type names, and the types in the blocklist will be hidden from the create dialog.</para>
    /// <para><b>Note:</b> Trying to list the base type in the <paramref name="typeBlocklist"/> will hide all types derived from the base type from the create dialog.</para>
    /// </summary>
    public void PopupCreateDialog(Callable callback, StringName baseType = null, string currentType = "", string dialogTitle = "", Godot.Collections.Array<StringName> typeBlocklist = null)
    {
        EditorNativeCalls.godot_icall_5_505(MethodBind38, GodotObject.GetPtr(this), callback, (godot_string_name)(baseType?.NativeValue ?? default), currentType, dialogTitle, (godot_array)(typeBlocklist ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFileSystemDock, 3751012327ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.FileSystemDock"/> instance.</para>
    /// <para><b>Warning:</b> Removing and freeing this node will render a part of the editor useless and may cause a crash.</para>
    /// </summary>
    public FileSystemDock GetFileSystemDock()
    {
        return (FileSystemDock)NativeCalls.godot_icall_0_53(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SelectFile, 83702148ul);

    /// <summary>
    /// <para>Selects the file, with the path provided by <paramref name="file"/>, in the FileSystem dock.</para>
    /// </summary>
    public void SelectFile(string file)
    {
        NativeCalls.godot_icall_1_57(MethodBind40, GodotObject.GetPtr(this), file);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedPaths, 1139954409ul);

    /// <summary>
    /// <para>Returns an array containing the paths of the currently selected files (and directories) in the <see cref="Godot.FileSystemDock"/>.</para>
    /// </summary>
    public string[] GetSelectedPaths()
    {
        return NativeCalls.godot_icall_0_108(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentPath, 201670096ul);

    /// <summary>
    /// <para>Returns the current path being viewed in the <see cref="Godot.FileSystemDock"/>.</para>
    /// </summary>
    public string GetCurrentPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentDirectory, 201670096ul);

    /// <summary>
    /// <para>Returns the current directory being viewed in the <see cref="Godot.FileSystemDock"/>. If a file is selected, its base directory will be returned using <c>String.get_base_dir</c> instead.</para>
    /// </summary>
    public string GetCurrentDirectory()
    {
        return NativeCalls.godot_icall_0_58(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInspector, 3517113938ul);

    /// <summary>
    /// <para>Returns the editor's <see cref="Godot.EditorInspector"/> instance.</para>
    /// <para><b>Warning:</b> Removing and freeing this node will render a part of the editor useless and may cause a crash.</para>
    /// </summary>
    public EditorInspector GetInspector()
    {
        return (EditorInspector)NativeCalls.godot_icall_0_53(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InspectObject, 127962172ul);

    /// <summary>
    /// <para>Shows the given property on the given <paramref name="object"/> in the editor's Inspector dock. If <paramref name="inspectorOnly"/> is <see langword="true"/>, plugins will not attempt to edit <paramref name="object"/>.</para>
    /// </summary>
    public void InspectObject(GodotObject @object, string forProperty = "", bool inspectorOnly = false)
    {
        EditorNativeCalls.godot_icall_3_506(MethodBind45, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), forProperty, inspectorOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EditResource, 968641751ul);

    /// <summary>
    /// <para>Edits the given <see cref="Godot.Resource"/>. If the resource is a <see cref="Godot.Script"/> you can also edit it with <see cref="Godot.EditorInterface.EditScript(Script, int, int, bool)"/> to specify the line and column position.</para>
    /// </summary>
    public void EditResource(Resource resource)
    {
        NativeCalls.godot_icall_1_56(MethodBind46, GodotObject.GetPtr(this), GodotObject.GetPtr(resource));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EditNode, 1078189570ul);

    /// <summary>
    /// <para>Edits the given <see cref="Godot.Node"/>. The node will be also selected if it's inside the scene tree.</para>
    /// </summary>
    public void EditNode(Node node)
    {
        NativeCalls.godot_icall_1_56(MethodBind47, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EditScript, 219829402ul);

    /// <summary>
    /// <para>Edits the given <see cref="Godot.Script"/>. The line and column on which to open the script can also be specified. The script will be open with the user-configured editor for the script's language which may be an external editor.</para>
    /// </summary>
    public void EditScript(Script script, int line = -1, int column = 0, bool grabFocus = true)
    {
        EditorNativeCalls.godot_icall_4_507(MethodBind48, GodotObject.GetPtr(this), GodotObject.GetPtr(script), line, column, grabFocus.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenSceneFromPath, 1168363258ul);

    /// <summary>
    /// <para>Opens the scene at the given path. If <paramref name="setInherited"/> is <see langword="true"/>, creates a new inherited scene.</para>
    /// </summary>
    public void OpenSceneFromPath(string sceneFilepath, bool setInherited = false)
    {
        NativeCalls.godot_icall_2_497(MethodBind49, GodotObject.GetPtr(this), sceneFilepath, setInherited.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReloadSceneFromPath, 83702148ul);

    /// <summary>
    /// <para>Reloads the scene at the given path.</para>
    /// </summary>
    public void ReloadSceneFromPath(string sceneFilepath)
    {
        NativeCalls.godot_icall_1_57(MethodBind50, GodotObject.GetPtr(this), sceneFilepath);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetObjectEdited, 1462101905ul);

    /// <summary>
    /// <para>If <paramref name="edited"/> is <see langword="true"/>, the object is marked as edited.</para>
    /// <para><b>Note:</b> This is primarily used by the editor for <see cref="Godot.Resource"/> based objects to track their modified state. For example, any changes to an open scene, a resource in the inspector, or an edited script will cause this method to be called with <see langword="true"/>. Saving the scene, script, or resource resets the edited state by calling this method with <see langword="false"/>.</para>
    /// <para><b>Note:</b> Each call to this method increments the object's edited version. This is used to track changes in the editor and to trigger when thumbnails should be regenerated for resources.</para>
    /// </summary>
    public void SetObjectEdited(GodotObject @object, bool edited)
    {
        NativeCalls.godot_icall_2_508(MethodBind51, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), edited.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsObjectEdited, 397768994ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the object has been marked as edited through <see cref="Godot.EditorInterface.SetObjectEdited(GodotObject, bool)"/>.</para>
    /// </summary>
    public bool IsObjectEdited(GodotObject @object)
    {
        return NativeCalls.godot_icall_1_176(MethodBind52, GodotObject.GetPtr(this), GodotObject.GetPtr(@object)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpenScenes, 1139954409ul);

    /// <summary>
    /// <para>Returns an array with the file paths of the currently opened scenes.</para>
    /// </summary>
    public string[] GetOpenScenes()
    {
        return NativeCalls.godot_icall_0_108(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpenSceneRoots, 3995934104ul);

    /// <summary>
    /// <para>Returns an array with references to the root nodes of the currently opened scenes.</para>
    /// </summary>
    public Godot.Collections.Array<Node> GetOpenSceneRoots()
    {
        return new Godot.Collections.Array<Node>(NativeCalls.godot_icall_0_120(MethodBind54, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditedSceneRoot, 3160264692ul);

    /// <summary>
    /// <para>Returns the edited (current) scene's root <see cref="Godot.Node"/>.</para>
    /// </summary>
    public Node GetEditedSceneRoot()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind55, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddRootNode, 1078189570ul);

    /// <summary>
    /// <para>Makes <paramref name="node"/> root of the currently opened scene. Only works if the scene is empty. If the <paramref name="node"/> is a scene instance, an inheriting scene will be created.</para>
    /// </summary>
    public void AddRootNode(Node node)
    {
        NativeCalls.godot_icall_1_56(MethodBind56, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveScene, 166280745ul);

    /// <summary>
    /// <para>Saves the currently active scene. Returns either <see cref="Godot.Error.Ok"/> or <see cref="Godot.Error.CantCreate"/>.</para>
    /// </summary>
    public Error SaveScene()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveSceneAs, 3647332257ul);

    /// <summary>
    /// <para>Saves the currently active scene as a file at <paramref name="path"/>.</para>
    /// </summary>
    public void SaveSceneAs(string path, bool withPreview = true)
    {
        NativeCalls.godot_icall_2_497(MethodBind58, GodotObject.GetPtr(this), path, withPreview.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveAllScenes, 3218959716ul);

    /// <summary>
    /// <para>Saves all opened scenes in the editor.</para>
    /// </summary>
    public void SaveAllScenes()
    {
        NativeCalls.godot_icall_0_3(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CloseScene, 166280745ul);

    /// <summary>
    /// <para>Closes the currently active scene, discarding any pending changes in the process. Returns <see cref="Godot.Error.Ok"/> on success or <see cref="Godot.Error.DoesNotExist"/> if there is no scene to close.</para>
    /// </summary>
    public Error CloseScene()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind60, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MarkSceneAsUnsaved, 3218959716ul);

    /// <summary>
    /// <para>Marks the current scene tab as unsaved.</para>
    /// </summary>
    public void MarkSceneAsUnsaved()
    {
        NativeCalls.godot_icall_0_3(MethodBind61, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlayMainScene, 3218959716ul);

    /// <summary>
    /// <para>Plays the main scene.</para>
    /// </summary>
    public void PlayMainScene()
    {
        NativeCalls.godot_icall_0_3(MethodBind62, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlayCurrentScene, 3218959716ul);

    /// <summary>
    /// <para>Plays the currently active scene.</para>
    /// </summary>
    public void PlayCurrentScene()
    {
        NativeCalls.godot_icall_0_3(MethodBind63, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlayCustomScene, 83702148ul);

    /// <summary>
    /// <para>Plays the scene specified by its filepath.</para>
    /// </summary>
    public void PlayCustomScene(string sceneFilepath)
    {
        NativeCalls.godot_icall_1_57(MethodBind64, GodotObject.GetPtr(this), sceneFilepath);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StopPlayingScene, 3218959716ul);

    /// <summary>
    /// <para>Stops the scene that is currently playing.</para>
    /// </summary>
    public void StopPlayingScene()
    {
        NativeCalls.godot_icall_0_3(MethodBind65, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPlayingScene, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a scene is currently being played, <see langword="false"/> otherwise. Paused scenes are considered as being played.</para>
    /// </summary>
    public bool IsPlayingScene()
    {
        return NativeCalls.godot_icall_0_15(MethodBind66, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlayingScene, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the scene that is being played. If no scene is currently being played, returns an empty string.</para>
    /// </summary>
    public string GetPlayingScene()
    {
        return NativeCalls.godot_icall_0_58(MethodBind67, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMovieMakerEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMovieMakerEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind68, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMovieMakerEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMovieMakerEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind69, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenSceneFromPath, 83702148ul);

    /// <summary>
    /// <para>Opens the scene at the given path. If <paramref name="setInherited"/> is <see langword="true"/>, creates a new inherited scene.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void OpenSceneFromPath(string scenePath)
    {
        NativeCalls.godot_icall_1_57(MethodBind70, GodotObject.GetPtr(this), scenePath);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupPropertySelector, 261221679ul);

    /// <summary>
    /// <para>Pops up an editor dialog for selecting properties from <paramref name="object"/>. The <paramref name="callback"/> must take a single argument of type <see cref="Godot.NodePath"/>. It is called on the selected property path (see <c>NodePath.get_as_property_path</c>) or the empty path <c>^""</c> if the dialog is canceled. If <paramref name="typeFilter"/> is provided, the dialog will only show properties that match one of the listed <see cref="Godot.Variant.Type"/> values. If <paramref name="currentValue"/> is provided, the property will be selected automatically in the property list, if it exists.</para>
    /// <para><code>
    /// func _ready():
    /// 	if Engine.is_editor_hint():
    /// 		EditorInterface.popup_property_selector(this, _on_property_selected, [TYPE_INT])
    /// 
    /// func _on_property_selected(property_path):
    /// 	if property_path.is_empty():
    /// 		print("property selection canceled")
    /// 	else:
    /// 		print("selected ", property_path)
    /// </code></para>
    /// </summary>
    /// <param name="typeFilter">If the parameter is null, then the default value is <c>Array.Empty&lt;int&gt;()</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void PopupPropertySelector(GodotObject @object, Callable callback, int[] typeFilter)
    {
        int[] typeFilterOrDefVal = typeFilter != null ? typeFilter : Array.Empty<int>();
        EditorNativeCalls.godot_icall_3_509(MethodBind71, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), callback, typeFilterOrDefVal);
    }

    /// <summary>
    /// <para>Pops up an editor dialog for selecting properties from <paramref name="object"/>. The <paramref name="callback"/> must take a single argument of type <see cref="Godot.NodePath"/>. It is called on the selected property path (see <c>NodePath.get_as_property_path</c>) or the empty path <c>^""</c> if the dialog is canceled. If <paramref name="typeFilter"/> is provided, the dialog will only show properties that match one of the listed <see cref="Godot.Variant.Type"/> values. If <paramref name="currentValue"/> is provided, the property will be selected automatically in the property list, if it exists.</para>
    /// <para><code>
    /// func _ready():
    /// 	if Engine.is_editor_hint():
    /// 		EditorInterface.popup_property_selector(this, _on_property_selected, [TYPE_INT])
    /// 
    /// func _on_property_selected(property_path):
    /// 	if property_path.is_empty():
    /// 		print("property selection canceled")
    /// 	else:
    /// 		print("selected ", property_path)
    /// </code></para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void PopupPropertySelector(GodotObject @object, Callable callback, ReadOnlySpan<int> typeFilter)
    {
        EditorNativeCalls.godot_icall_3_509(MethodBind71, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), callback, typeFilter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupNodeSelector, 2271411043ul);

    /// <summary>
    /// <para>Pops up an editor dialog for selecting a <see cref="Godot.Node"/> from the edited scene. The <paramref name="callback"/> must take a single argument of type <see cref="Godot.NodePath"/>. It is called on the selected <see cref="Godot.NodePath"/> or the empty path <c>^""</c> if the dialog is canceled. If <paramref name="validTypes"/> is provided, the dialog will only show Nodes that match one of the listed Node types. If <paramref name="currentValue"/> is provided, the Node will be automatically selected in the tree, if it exists.</para>
    /// <para><b>Example:</b> Display the node selection dialog as soon as this node is added to the tree for the first time:</para>
    /// <para><code>
    /// func _ready():
    /// 	if Engine.is_editor_hint():
    /// 		EditorInterface.popup_node_selector(_on_node_selected, ["Button"])
    /// 
    /// func _on_node_selected(node_path):
    /// 	if node_path.is_empty():
    /// 		print("node selection canceled")
    /// 	else:
    /// 		print("selected ", node_path)
    /// </code></para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void PopupNodeSelector(Callable callback, Godot.Collections.Array<StringName> validTypes)
    {
        EditorNativeCalls.godot_icall_2_504(MethodBind72, GodotObject.GetPtr(this), callback, (godot_array)(validTypes ?? new()).NativeValue);
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
        /// <summary>
        /// Cached name for the 'distraction_free_mode' property.
        /// </summary>
        public static readonly StringName DistractionFreeMode = "distraction_free_mode";
        /// <summary>
        /// Cached name for the 'movie_maker_enabled' property.
        /// </summary>
        public static readonly StringName MovieMakerEnabled = "movie_maker_enabled";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'restart_editor' method.
        /// </summary>
        public static readonly StringName RestartEditor = "restart_editor";
        /// <summary>
        /// Cached name for the 'get_command_palette' method.
        /// </summary>
        public static readonly StringName GetCommandPalette = "get_command_palette";
        /// <summary>
        /// Cached name for the 'get_resource_filesystem' method.
        /// </summary>
        public static readonly StringName GetResourceFilesystem = "get_resource_filesystem";
        /// <summary>
        /// Cached name for the 'get_editor_paths' method.
        /// </summary>
        public static readonly StringName GetEditorPaths = "get_editor_paths";
        /// <summary>
        /// Cached name for the 'get_resource_previewer' method.
        /// </summary>
        public static readonly StringName GetResourcePreviewer = "get_resource_previewer";
        /// <summary>
        /// Cached name for the 'get_selection' method.
        /// </summary>
        public static readonly StringName GetSelection = "get_selection";
        /// <summary>
        /// Cached name for the 'get_editor_settings' method.
        /// </summary>
        public static readonly StringName GetEditorSettings = "get_editor_settings";
        /// <summary>
        /// Cached name for the 'get_editor_toaster' method.
        /// </summary>
        public static readonly StringName GetEditorToaster = "get_editor_toaster";
        /// <summary>
        /// Cached name for the 'get_editor_undo_redo' method.
        /// </summary>
        public static readonly StringName GetEditorUndoRedo = "get_editor_undo_redo";
        /// <summary>
        /// Cached name for the 'make_mesh_previews' method.
        /// </summary>
        public static readonly StringName MakeMeshPreviews = "make_mesh_previews";
        /// <summary>
        /// Cached name for the 'set_plugin_enabled' method.
        /// </summary>
        public static readonly StringName SetPluginEnabled = "set_plugin_enabled";
        /// <summary>
        /// Cached name for the 'is_plugin_enabled' method.
        /// </summary>
        public static readonly StringName IsPluginEnabled = "is_plugin_enabled";
        /// <summary>
        /// Cached name for the 'get_editor_theme' method.
        /// </summary>
        public static readonly StringName GetEditorTheme = "get_editor_theme";
        /// <summary>
        /// Cached name for the 'get_base_control' method.
        /// </summary>
        public static readonly StringName GetBaseControl = "get_base_control";
        /// <summary>
        /// Cached name for the 'get_editor_main_screen' method.
        /// </summary>
        public static readonly StringName GetEditorMainScreen = "get_editor_main_screen";
        /// <summary>
        /// Cached name for the 'get_script_editor' method.
        /// </summary>
        public static readonly StringName GetScriptEditor = "get_script_editor";
        /// <summary>
        /// Cached name for the 'get_editor_viewport_2d' method.
        /// </summary>
        public static readonly StringName GetEditorViewport2D = "get_editor_viewport_2d";
        /// <summary>
        /// Cached name for the 'get_editor_viewport_3d' method.
        /// </summary>
        public static readonly StringName GetEditorViewport3D = "get_editor_viewport_3d";
        /// <summary>
        /// Cached name for the 'set_main_screen_editor' method.
        /// </summary>
        public static readonly StringName SetMainScreenEditor = "set_main_screen_editor";
        /// <summary>
        /// Cached name for the 'set_distraction_free_mode' method.
        /// </summary>
        public static readonly StringName SetDistractionFreeMode = "set_distraction_free_mode";
        /// <summary>
        /// Cached name for the 'is_distraction_free_mode_enabled' method.
        /// </summary>
        public static readonly StringName IsDistractionFreeModeEnabled = "is_distraction_free_mode_enabled";
        /// <summary>
        /// Cached name for the 'is_multi_window_enabled' method.
        /// </summary>
        public static readonly StringName IsMultiWindowEnabled = "is_multi_window_enabled";
        /// <summary>
        /// Cached name for the 'get_editor_scale' method.
        /// </summary>
        public static readonly StringName GetEditorScale = "get_editor_scale";
        /// <summary>
        /// Cached name for the 'get_editor_language' method.
        /// </summary>
        public static readonly StringName GetEditorLanguage = "get_editor_language";
        /// <summary>
        /// Cached name for the 'is_node_3d_snap_enabled' method.
        /// </summary>
        public static readonly StringName IsNode3DSnapEnabled = "is_node_3d_snap_enabled";
        /// <summary>
        /// Cached name for the 'get_node_3d_translate_snap' method.
        /// </summary>
        public static readonly StringName GetNode3DTranslateSnap = "get_node_3d_translate_snap";
        /// <summary>
        /// Cached name for the 'get_node_3d_rotate_snap' method.
        /// </summary>
        public static readonly StringName GetNode3DRotateSnap = "get_node_3d_rotate_snap";
        /// <summary>
        /// Cached name for the 'get_node_3d_scale_snap' method.
        /// </summary>
        public static readonly StringName GetNode3DScaleSnap = "get_node_3d_scale_snap";
        /// <summary>
        /// Cached name for the 'popup_dialog' method.
        /// </summary>
        public static readonly StringName PopupDialog = "popup_dialog";
        /// <summary>
        /// Cached name for the 'popup_dialog_centered' method.
        /// </summary>
        public static readonly StringName PopupDialogCentered = "popup_dialog_centered";
        /// <summary>
        /// Cached name for the 'popup_dialog_centered_ratio' method.
        /// </summary>
        public static readonly StringName PopupDialogCenteredRatio = "popup_dialog_centered_ratio";
        /// <summary>
        /// Cached name for the 'popup_dialog_centered_clamped' method.
        /// </summary>
        public static readonly StringName PopupDialogCenteredClamped = "popup_dialog_centered_clamped";
        /// <summary>
        /// Cached name for the 'get_current_feature_profile' method.
        /// </summary>
        public static readonly StringName GetCurrentFeatureProfile = "get_current_feature_profile";
        /// <summary>
        /// Cached name for the 'set_current_feature_profile' method.
        /// </summary>
        public static readonly StringName SetCurrentFeatureProfile = "set_current_feature_profile";
        /// <summary>
        /// Cached name for the 'popup_node_selector' method.
        /// </summary>
        public static readonly StringName PopupNodeSelector = "popup_node_selector";
        /// <summary>
        /// Cached name for the 'popup_property_selector' method.
        /// </summary>
        public static readonly StringName PopupPropertySelector = "popup_property_selector";
        /// <summary>
        /// Cached name for the 'popup_method_selector' method.
        /// </summary>
        public static readonly StringName PopupMethodSelector = "popup_method_selector";
        /// <summary>
        /// Cached name for the 'popup_quick_open' method.
        /// </summary>
        public static readonly StringName PopupQuickOpen = "popup_quick_open";
        /// <summary>
        /// Cached name for the 'popup_create_dialog' method.
        /// </summary>
        public static readonly StringName PopupCreateDialog = "popup_create_dialog";
        /// <summary>
        /// Cached name for the 'get_file_system_dock' method.
        /// </summary>
        public static readonly StringName GetFileSystemDock = "get_file_system_dock";
        /// <summary>
        /// Cached name for the 'select_file' method.
        /// </summary>
        public static readonly StringName SelectFile = "select_file";
        /// <summary>
        /// Cached name for the 'get_selected_paths' method.
        /// </summary>
        public static readonly StringName GetSelectedPaths = "get_selected_paths";
        /// <summary>
        /// Cached name for the 'get_current_path' method.
        /// </summary>
        public static readonly StringName GetCurrentPath = "get_current_path";
        /// <summary>
        /// Cached name for the 'get_current_directory' method.
        /// </summary>
        public static readonly StringName GetCurrentDirectory = "get_current_directory";
        /// <summary>
        /// Cached name for the 'get_inspector' method.
        /// </summary>
        public static readonly StringName GetInspector = "get_inspector";
        /// <summary>
        /// Cached name for the 'inspect_object' method.
        /// </summary>
        public static readonly StringName InspectObject = "inspect_object";
        /// <summary>
        /// Cached name for the 'edit_resource' method.
        /// </summary>
        public static readonly StringName EditResource = "edit_resource";
        /// <summary>
        /// Cached name for the 'edit_node' method.
        /// </summary>
        public static readonly StringName EditNode = "edit_node";
        /// <summary>
        /// Cached name for the 'edit_script' method.
        /// </summary>
        public static readonly StringName EditScript = "edit_script";
        /// <summary>
        /// Cached name for the 'open_scene_from_path' method.
        /// </summary>
        public static readonly StringName OpenSceneFromPath = "open_scene_from_path";
        /// <summary>
        /// Cached name for the 'reload_scene_from_path' method.
        /// </summary>
        public static readonly StringName ReloadSceneFromPath = "reload_scene_from_path";
        /// <summary>
        /// Cached name for the 'set_object_edited' method.
        /// </summary>
        public static readonly StringName SetObjectEdited = "set_object_edited";
        /// <summary>
        /// Cached name for the 'is_object_edited' method.
        /// </summary>
        public static readonly StringName IsObjectEdited = "is_object_edited";
        /// <summary>
        /// Cached name for the 'get_open_scenes' method.
        /// </summary>
        public static readonly StringName GetOpenScenes = "get_open_scenes";
        /// <summary>
        /// Cached name for the 'get_open_scene_roots' method.
        /// </summary>
        public static readonly StringName GetOpenSceneRoots = "get_open_scene_roots";
        /// <summary>
        /// Cached name for the 'get_edited_scene_root' method.
        /// </summary>
        public static readonly StringName GetEditedSceneRoot = "get_edited_scene_root";
        /// <summary>
        /// Cached name for the 'add_root_node' method.
        /// </summary>
        public static readonly StringName AddRootNode = "add_root_node";
        /// <summary>
        /// Cached name for the 'save_scene' method.
        /// </summary>
        public static readonly StringName SaveScene = "save_scene";
        /// <summary>
        /// Cached name for the 'save_scene_as' method.
        /// </summary>
        public static readonly StringName SaveSceneAs = "save_scene_as";
        /// <summary>
        /// Cached name for the 'save_all_scenes' method.
        /// </summary>
        public static readonly StringName SaveAllScenes = "save_all_scenes";
        /// <summary>
        /// Cached name for the 'close_scene' method.
        /// </summary>
        public static readonly StringName CloseScene = "close_scene";
        /// <summary>
        /// Cached name for the 'mark_scene_as_unsaved' method.
        /// </summary>
        public static readonly StringName MarkSceneAsUnsaved = "mark_scene_as_unsaved";
        /// <summary>
        /// Cached name for the 'play_main_scene' method.
        /// </summary>
        public static readonly StringName PlayMainScene = "play_main_scene";
        /// <summary>
        /// Cached name for the 'play_current_scene' method.
        /// </summary>
        public static readonly StringName PlayCurrentScene = "play_current_scene";
        /// <summary>
        /// Cached name for the 'play_custom_scene' method.
        /// </summary>
        public static readonly StringName PlayCustomScene = "play_custom_scene";
        /// <summary>
        /// Cached name for the 'stop_playing_scene' method.
        /// </summary>
        public static readonly StringName StopPlayingScene = "stop_playing_scene";
        /// <summary>
        /// Cached name for the 'is_playing_scene' method.
        /// </summary>
        public static readonly StringName IsPlayingScene = "is_playing_scene";
        /// <summary>
        /// Cached name for the 'get_playing_scene' method.
        /// </summary>
        public static readonly StringName GetPlayingScene = "get_playing_scene";
        /// <summary>
        /// Cached name for the 'set_movie_maker_enabled' method.
        /// </summary>
        public static readonly StringName SetMovieMakerEnabled = "set_movie_maker_enabled";
        /// <summary>
        /// Cached name for the 'is_movie_maker_enabled' method.
        /// </summary>
        public static readonly StringName IsMovieMakerEnabled = "is_movie_maker_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
