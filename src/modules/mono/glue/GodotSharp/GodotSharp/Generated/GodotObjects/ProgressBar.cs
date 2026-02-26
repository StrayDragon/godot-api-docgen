namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A control used for visual representation of a percentage. Shows the fill percentage in the center. Can also be used to show indeterminate progress. For more fill modes, use <see cref="Godot.TextureProgressBar"/> instead.</para>
/// </summary>
public partial class ProgressBar : Range
{
    public enum FillModeEnum : long
    {
        /// <summary>
        /// <para>The progress bar fills from begin to end horizontally, according to the language direction. If <see cref="Godot.Control.IsLayoutRtl()"/> returns <see langword="false"/>, it fills from left to right, and if it returns <see langword="true"/>, it fills from right to left.</para>
        /// </summary>
        BeginToEnd = 0,
        /// <summary>
        /// <para>The progress bar fills from end to begin horizontally, according to the language direction. If <see cref="Godot.Control.IsLayoutRtl()"/> returns <see langword="false"/>, it fills from right to left, and if it returns <see langword="true"/>, it fills from left to right.</para>
        /// </summary>
        EndToBegin = 1,
        /// <summary>
        /// <para>The progress fills from top to bottom.</para>
        /// </summary>
        TopToBottom = 2,
        /// <summary>
        /// <para>The progress fills from bottom to top.</para>
        /// </summary>
        BottomToTop = 3
    }

    /// <summary>
    /// <para>The fill direction. See <see cref="Godot.ProgressBar.FillModeEnum"/> for possible values.</para>
    /// </summary>
    public int FillMode
    {
        get
        {
            return GetFillMode();
        }
        set
        {
            SetFillMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the fill percentage is displayed on the bar.</para>
    /// </summary>
    public bool ShowPercentage
    {
        get
        {
            return IsPercentageShown();
        }
        set
        {
            SetShowPercentage(value);
        }
    }

    /// <summary>
    /// <para>When set to <see langword="true"/>, the progress bar indicates that something is happening with an animation, but does not show the fill percentage or value.</para>
    /// </summary>
    public bool Indeterminate
    {
        get
        {
            return IsIndeterminate();
        }
        set
        {
            SetIndeterminate(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, the <see cref="Godot.ProgressBar.Indeterminate"/> animation will be paused in the editor.</para>
    /// </summary>
    public bool EditorPreviewIndeterminate
    {
        get
        {
            return IsEditorPreviewIndeterminateEnabled();
        }
        set
        {
            SetEditorPreviewIndeterminate(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ProgressBar);

    private static readonly StringName NativeName = "ProgressBar";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ProgressBar() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ProgressBar(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ProgressBar(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFillMode, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFillMode(int mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFillMode, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFillMode()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowPercentage, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowPercentage(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPercentageShown, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPercentageShown()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndeterminate, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIndeterminate(bool indeterminate)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), indeterminate.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsIndeterminate, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsIndeterminate()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditorPreviewIndeterminate, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditorPreviewIndeterminate(bool previewIndeterminate)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), previewIndeterminate.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditorPreviewIndeterminateEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditorPreviewIndeterminateEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : Range.PropertyName
    {
        /// <summary>
        /// Cached name for the 'fill_mode' property.
        /// </summary>
        public static readonly StringName FillMode = "fill_mode";
        /// <summary>
        /// Cached name for the 'show_percentage' property.
        /// </summary>
        public static readonly StringName ShowPercentage = "show_percentage";
        /// <summary>
        /// Cached name for the 'indeterminate' property.
        /// </summary>
        public static readonly StringName Indeterminate = "indeterminate";
        /// <summary>
        /// Cached name for the 'editor_preview_indeterminate' property.
        /// </summary>
        public static readonly StringName EditorPreviewIndeterminate = "editor_preview_indeterminate";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Range.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_fill_mode' method.
        /// </summary>
        public static readonly StringName SetFillMode = "set_fill_mode";
        /// <summary>
        /// Cached name for the 'get_fill_mode' method.
        /// </summary>
        public static readonly StringName GetFillMode = "get_fill_mode";
        /// <summary>
        /// Cached name for the 'set_show_percentage' method.
        /// </summary>
        public static readonly StringName SetShowPercentage = "set_show_percentage";
        /// <summary>
        /// Cached name for the 'is_percentage_shown' method.
        /// </summary>
        public static readonly StringName IsPercentageShown = "is_percentage_shown";
        /// <summary>
        /// Cached name for the 'set_indeterminate' method.
        /// </summary>
        public static readonly StringName SetIndeterminate = "set_indeterminate";
        /// <summary>
        /// Cached name for the 'is_indeterminate' method.
        /// </summary>
        public static readonly StringName IsIndeterminate = "is_indeterminate";
        /// <summary>
        /// Cached name for the 'set_editor_preview_indeterminate' method.
        /// </summary>
        public static readonly StringName SetEditorPreviewIndeterminate = "set_editor_preview_indeterminate";
        /// <summary>
        /// Cached name for the 'is_editor_preview_indeterminate_enabled' method.
        /// </summary>
        public static readonly StringName IsEditorPreviewIndeterminateEnabled = "is_editor_preview_indeterminate_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Range.SignalName
    {
    }
}
