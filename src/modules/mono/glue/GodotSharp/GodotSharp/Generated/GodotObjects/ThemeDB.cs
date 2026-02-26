namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This singleton provides access to static information about <see cref="Godot.Theme"/> resources used by the engine and by your projects. You can fetch the default engine theme, as well as your project configured theme.</para>
/// <para><see cref="Godot.ThemeDB"/> also contains fallback values for theme properties.</para>
/// </summary>
public static partial class ThemeDB
{
    /// <summary>
    /// <para>The fallback base scale factor of every <see cref="Godot.Control"/> node and <see cref="Godot.Theme"/> resource. Used when no other value is available to the control.</para>
    /// <para>See also <see cref="Godot.Theme.DefaultBaseScale"/>.</para>
    /// </summary>
    public static float FallbackBaseScale
    {
        get
        {
            return GetFallbackBaseScale();
        }
        set
        {
            SetFallbackBaseScale(value);
        }
    }

    /// <summary>
    /// <para>The fallback font of every <see cref="Godot.Control"/> node and <see cref="Godot.Theme"/> resource. Used when no other value is available to the control.</para>
    /// <para>See also <see cref="Godot.Theme.DefaultFont"/>.</para>
    /// </summary>
    public static Font FallbackFont
    {
        get
        {
            return GetFallbackFont();
        }
        set
        {
            SetFallbackFont(value);
        }
    }

    /// <summary>
    /// <para>The fallback font size of every <see cref="Godot.Control"/> node and <see cref="Godot.Theme"/> resource. Used when no other value is available to the control.</para>
    /// <para>See also <see cref="Godot.Theme.DefaultFontSize"/>.</para>
    /// </summary>
    public static int FallbackFontSize
    {
        get
        {
            return GetFallbackFontSize();
        }
        set
        {
            SetFallbackFontSize(value);
        }
    }

    /// <summary>
    /// <para>The fallback icon of every <see cref="Godot.Control"/> node and <see cref="Godot.Theme"/> resource. Used when no other value is available to the control.</para>
    /// </summary>
    public static Texture2D FallbackIcon
    {
        get
        {
            return GetFallbackIcon();
        }
        set
        {
            SetFallbackIcon(value);
        }
    }

    /// <summary>
    /// <para>The fallback stylebox of every <see cref="Godot.Control"/> node and <see cref="Godot.Theme"/> resource. Used when no other value is available to the control.</para>
    /// </summary>
    public static StyleBox FallbackStylebox
    {
        get
        {
            return GetFallbackStylebox();
        }
        set
        {
            SetFallbackStylebox(value);
        }
    }

    private static readonly StringName NativeName = "ThemeDB";

    private static ThemeDBInstance singleton;

    public static ThemeDBInstance Singleton =>
        singleton ??= (ThemeDBInstance)InteropUtils.EngineGetSingleton("ThemeDB");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultTheme, 754276358ul);

    /// <summary>
    /// <para>Returns a reference to the default engine <see cref="Godot.Theme"/>. This theme resource is responsible for the out-of-the-box look of <see cref="Godot.Control"/> nodes and cannot be overridden.</para>
    /// </summary>
    public static Theme GetDefaultTheme()
    {
        return (Theme)NativeCalls.godot_icall_0_63(MethodBind0, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjectTheme, 754276358ul);

    /// <summary>
    /// <para>Returns a reference to the custom project <see cref="Godot.Theme"/>. This theme resources allows to override the default engine theme for every control node in the project.</para>
    /// <para>To set the project theme, see <c>ProjectSettings.gui/theme/custom</c>.</para>
    /// </summary>
    public static Theme GetProjectTheme()
    {
        return (Theme)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackBaseScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetFallbackBaseScale(float baseScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(Singleton), baseScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackBaseScale, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static float GetFallbackBaseScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackFont, 1262170328ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetFallbackFont(Font font)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(font));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackFont, 3656929885ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Font GetFallbackFont()
    {
        return (Font)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackFontSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetFallbackFontSize(int fontSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(Singleton), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackFontSize, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static int GetFallbackFontSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackIcon, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetFallbackIcon(Texture2D icon)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackIcon, 255860311ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Texture2D GetFallbackIcon()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind9, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackStylebox, 2797200388ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetFallbackStylebox(StyleBox stylebox)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(stylebox));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackStylebox, 496040854ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static StyleBox GetFallbackStylebox()
    {
        return (StyleBox)NativeCalls.godot_icall_0_63(MethodBind11, GodotObject.GetPtr(Singleton));
    }

    /// <summary>
    /// <para>Emitted when one of the fallback values had been changed. Use it to refresh the look of controls that may rely on the fallback theme items.</para>
    /// </summary>
    public static event Action FallbackChanged
    {
        add => Singleton.Connect(SignalName.FallbackChanged, Callable.From(value));
        remove => Singleton.Disconnect(SignalName.FallbackChanged, Callable.From(value));
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
        /// <summary>
        /// Cached name for the 'fallback_base_scale' property.
        /// </summary>
        public static readonly StringName FallbackBaseScale = "fallback_base_scale";
        /// <summary>
        /// Cached name for the 'fallback_font' property.
        /// </summary>
        public static readonly StringName FallbackFont = "fallback_font";
        /// <summary>
        /// Cached name for the 'fallback_font_size' property.
        /// </summary>
        public static readonly StringName FallbackFontSize = "fallback_font_size";
        /// <summary>
        /// Cached name for the 'fallback_icon' property.
        /// </summary>
        public static readonly StringName FallbackIcon = "fallback_icon";
        /// <summary>
        /// Cached name for the 'fallback_stylebox' property.
        /// </summary>
        public static readonly StringName FallbackStylebox = "fallback_stylebox";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'get_default_theme' method.
        /// </summary>
        public static readonly StringName GetDefaultTheme = "get_default_theme";
        /// <summary>
        /// Cached name for the 'get_project_theme' method.
        /// </summary>
        public static readonly StringName GetProjectTheme = "get_project_theme";
        /// <summary>
        /// Cached name for the 'set_fallback_base_scale' method.
        /// </summary>
        public static readonly StringName SetFallbackBaseScale = "set_fallback_base_scale";
        /// <summary>
        /// Cached name for the 'get_fallback_base_scale' method.
        /// </summary>
        public static readonly StringName GetFallbackBaseScale = "get_fallback_base_scale";
        /// <summary>
        /// Cached name for the 'set_fallback_font' method.
        /// </summary>
        public static readonly StringName SetFallbackFont = "set_fallback_font";
        /// <summary>
        /// Cached name for the 'get_fallback_font' method.
        /// </summary>
        public static readonly StringName GetFallbackFont = "get_fallback_font";
        /// <summary>
        /// Cached name for the 'set_fallback_font_size' method.
        /// </summary>
        public static readonly StringName SetFallbackFontSize = "set_fallback_font_size";
        /// <summary>
        /// Cached name for the 'get_fallback_font_size' method.
        /// </summary>
        public static readonly StringName GetFallbackFontSize = "get_fallback_font_size";
        /// <summary>
        /// Cached name for the 'set_fallback_icon' method.
        /// </summary>
        public static readonly StringName SetFallbackIcon = "set_fallback_icon";
        /// <summary>
        /// Cached name for the 'get_fallback_icon' method.
        /// </summary>
        public static readonly StringName GetFallbackIcon = "get_fallback_icon";
        /// <summary>
        /// Cached name for the 'set_fallback_stylebox' method.
        /// </summary>
        public static readonly StringName SetFallbackStylebox = "set_fallback_stylebox";
        /// <summary>
        /// Cached name for the 'get_fallback_stylebox' method.
        /// </summary>
        public static readonly StringName GetFallbackStylebox = "get_fallback_stylebox";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
        /// <summary>
        /// Cached name for the 'fallback_changed' signal.
        /// </summary>
        public static readonly StringName FallbackChanged = "fallback_changed";
    }
}
