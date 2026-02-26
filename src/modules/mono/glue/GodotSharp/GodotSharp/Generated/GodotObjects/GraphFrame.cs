namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>GraphFrame is a special <see cref="Godot.GraphElement"/> to which other <see cref="Godot.GraphElement"/>s can be attached. It can be configured to automatically resize to enclose all attached <see cref="Godot.GraphElement"/>s. If the frame is moved, all the attached <see cref="Godot.GraphElement"/>s inside it will be moved as well.</para>
/// <para>A GraphFrame is always kept behind the connection layer and other <see cref="Godot.GraphElement"/>s inside a <see cref="Godot.GraphEdit"/>.</para>
/// </summary>
public partial class GraphFrame : GraphElement
{
    /// <summary>
    /// <para>Title of the frame.</para>
    /// </summary>
    public string Title
    {
        get
        {
            return GetTitle();
        }
        set
        {
            SetTitle(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the frame's rect will be adjusted automatically to enclose all attached <see cref="Godot.GraphElement"/>s.</para>
    /// </summary>
    public bool AutoshrinkEnabled
    {
        get
        {
            return IsAutoshrinkEnabled();
        }
        set
        {
            SetAutoshrinkEnabled(value);
        }
    }

    /// <summary>
    /// <para>The margin around the attached nodes that is used to calculate the size of the frame when <see cref="Godot.GraphFrame.AutoshrinkEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public int AutoshrinkMargin
    {
        get
        {
            return GetAutoshrinkMargin();
        }
        set
        {
            SetAutoshrinkMargin(value);
        }
    }

    /// <summary>
    /// <para>The margin inside the frame that can be used to drag the frame.</para>
    /// </summary>
    public int DragMargin
    {
        get
        {
            return GetDragMargin();
        }
        set
        {
            SetDragMargin(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the tint color will be used to tint the frame.</para>
    /// </summary>
    public bool TintColorEnabled
    {
        get
        {
            return IsTintColorEnabled();
        }
        set
        {
            SetTintColorEnabled(value);
        }
    }

    /// <summary>
    /// <para>The color of the frame when <see cref="Godot.GraphFrame.TintColorEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public Color TintColor
    {
        get
        {
            return GetTintColor();
        }
        set
        {
            SetTintColor(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GraphFrame);

    private static readonly StringName NativeName = "GraphFrame";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GraphFrame() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GraphFrame(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GraphFrame(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitle, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTitle(string title)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitle, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetTitle()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitlebarHBox, 3590609951ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.HBoxContainer"/> used for the title bar, only containing a <see cref="Godot.Label"/> for displaying the title by default.</para>
    /// <para>This can be used to add custom controls to the title bar such as option or close buttons.</para>
    /// </summary>
    public HBoxContainer GetTitlebarHBox()
    {
        return (HBoxContainer)NativeCalls.godot_icall_0_53(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoshrinkEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoshrinkEnabled(bool shrink)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), shrink.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoshrinkEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoshrinkEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoshrinkMargin, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoshrinkMargin(int autoshrinkMargin)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), autoshrinkMargin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoshrinkMargin, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetAutoshrinkMargin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragMargin, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragMargin(int dragMargin)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), dragMargin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragMargin, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDragMargin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTintColorEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTintColorEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTintColorEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsTintColorEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTintColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTintColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind11, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTintColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetTintColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind12, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.GraphFrame.AutoshrinkEnabled"/> or <see cref="Godot.GraphFrame.AutoshrinkMargin"/> changes.</para>
    /// </summary>
    public event Action AutoshrinkChanged
    {
        add => Connect(SignalName.AutoshrinkChanged, Callable.From(value));
        remove => Disconnect(SignalName.AutoshrinkChanged, Callable.From(value));
    }

    protected void EmitSignalAutoshrinkChanged()
    {
        EmitSignal(SignalName.AutoshrinkChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_autoshrink_changed = "AutoshrinkChanged";

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
        if (signal == SignalName.AutoshrinkChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_autoshrink_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : GraphElement.PropertyName
    {
        /// <summary>
        /// Cached name for the 'title' property.
        /// </summary>
        public static readonly StringName Title = "title";
        /// <summary>
        /// Cached name for the 'autoshrink_enabled' property.
        /// </summary>
        public static readonly StringName AutoshrinkEnabled = "autoshrink_enabled";
        /// <summary>
        /// Cached name for the 'autoshrink_margin' property.
        /// </summary>
        public static readonly StringName AutoshrinkMargin = "autoshrink_margin";
        /// <summary>
        /// Cached name for the 'drag_margin' property.
        /// </summary>
        public static readonly StringName DragMargin = "drag_margin";
        /// <summary>
        /// Cached name for the 'tint_color_enabled' property.
        /// </summary>
        public static readonly StringName TintColorEnabled = "tint_color_enabled";
        /// <summary>
        /// Cached name for the 'tint_color' property.
        /// </summary>
        public static readonly StringName TintColor = "tint_color";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GraphElement.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_title' method.
        /// </summary>
        public static readonly StringName SetTitle = "set_title";
        /// <summary>
        /// Cached name for the 'get_title' method.
        /// </summary>
        public static readonly StringName GetTitle = "get_title";
        /// <summary>
        /// Cached name for the 'get_titlebar_hbox' method.
        /// </summary>
        public static readonly StringName GetTitlebarHBox = "get_titlebar_hbox";
        /// <summary>
        /// Cached name for the 'set_autoshrink_enabled' method.
        /// </summary>
        public static readonly StringName SetAutoshrinkEnabled = "set_autoshrink_enabled";
        /// <summary>
        /// Cached name for the 'is_autoshrink_enabled' method.
        /// </summary>
        public static readonly StringName IsAutoshrinkEnabled = "is_autoshrink_enabled";
        /// <summary>
        /// Cached name for the 'set_autoshrink_margin' method.
        /// </summary>
        public static readonly StringName SetAutoshrinkMargin = "set_autoshrink_margin";
        /// <summary>
        /// Cached name for the 'get_autoshrink_margin' method.
        /// </summary>
        public static readonly StringName GetAutoshrinkMargin = "get_autoshrink_margin";
        /// <summary>
        /// Cached name for the 'set_drag_margin' method.
        /// </summary>
        public static readonly StringName SetDragMargin = "set_drag_margin";
        /// <summary>
        /// Cached name for the 'get_drag_margin' method.
        /// </summary>
        public static readonly StringName GetDragMargin = "get_drag_margin";
        /// <summary>
        /// Cached name for the 'set_tint_color_enabled' method.
        /// </summary>
        public static readonly StringName SetTintColorEnabled = "set_tint_color_enabled";
        /// <summary>
        /// Cached name for the 'is_tint_color_enabled' method.
        /// </summary>
        public static readonly StringName IsTintColorEnabled = "is_tint_color_enabled";
        /// <summary>
        /// Cached name for the 'set_tint_color' method.
        /// </summary>
        public static readonly StringName SetTintColor = "set_tint_color";
        /// <summary>
        /// Cached name for the 'get_tint_color' method.
        /// </summary>
        public static readonly StringName GetTintColor = "get_tint_color";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GraphElement.SignalName
    {
        /// <summary>
        /// Cached name for the 'autoshrink_changed' signal.
        /// </summary>
        public static readonly StringName AutoshrinkChanged = "autoshrink_changed";
    }
}
