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
[GodotClassName("ThemeDB")]
public partial class ThemeDBInstance : GodotObject
{
    /// <summary>
    /// <para>The fallback base scale factor of every <see cref="Godot.Control"/> node and <see cref="Godot.Theme"/> resource. Used when no other value is available to the control.</para>
    /// <para>See also <see cref="Godot.Theme.DefaultBaseScale"/>.</para>
    /// </summary>
    public float FallbackBaseScale
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
    public Font FallbackFont
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
    public int FallbackFontSize
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
    public Texture2D FallbackIcon
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
    public StyleBox FallbackStylebox
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

    private static readonly System.Type CachedType = typeof(ThemeDBInstance);

    private static readonly StringName NativeName = "ThemeDB";

    internal ThemeDBInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ThemeDBInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ThemeDBInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultTheme, 754276358ul);

    /// <summary>
    /// <para>Returns a reference to the default engine <see cref="Godot.Theme"/>. This theme resource is responsible for the out-of-the-box look of <see cref="Godot.Control"/> nodes and cannot be overridden.</para>
    /// </summary>
    public Theme GetDefaultTheme()
    {
        return (Theme)NativeCalls.godot_icall_0_63(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjectTheme, 754276358ul);

    /// <summary>
    /// <para>Returns a reference to the custom project <see cref="Godot.Theme"/>. This theme resources allows to override the default engine theme for every control node in the project.</para>
    /// <para>To set the project theme, see <c>ProjectSettings.gui/theme/custom</c>.</para>
    /// </summary>
    public Theme GetProjectTheme()
    {
        return (Theme)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackBaseScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbackBaseScale(float baseScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), baseScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackBaseScale, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFallbackBaseScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackFont, 1262170328ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbackFont(Font font)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(font));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackFont, 3656929885ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Font GetFallbackFont()
    {
        return (Font)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackFontSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbackFontSize(int fontSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackFontSize, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFallbackFontSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackIcon, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbackIcon(Texture2D icon)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackIcon, 255860311ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetFallbackIcon()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbackStylebox, 2797200388ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbackStylebox(StyleBox stylebox)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(stylebox));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbackStylebox, 496040854ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleBox GetFallbackStylebox()
    {
        return (StyleBox)NativeCalls.godot_icall_0_63(MethodBind11, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when one of the fallback values had been changed. Use it to refresh the look of controls that may rely on the fallback theme items.</para>
    /// </summary>
    public event Action FallbackChanged
    {
        add => Connect(SignalName.FallbackChanged, Callable.From(value));
        remove => Disconnect(SignalName.FallbackChanged, Callable.From(value));
    }

    protected void EmitSignalFallbackChanged()
    {
        EmitSignal(SignalName.FallbackChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_fallback_changed = "FallbackChanged";

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
        if (signal == SignalName.FallbackChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_fallback_changed.NativeValue.DangerousSelfRef))
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
    public new class MethodName : GodotObject.MethodName
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
    public new class SignalName : GodotObject.SignalName
    {
        /// <summary>
        /// Cached name for the 'fallback_changed' signal.
        /// </summary>
        public static readonly StringName FallbackChanged = "fallback_changed";
    }
}
