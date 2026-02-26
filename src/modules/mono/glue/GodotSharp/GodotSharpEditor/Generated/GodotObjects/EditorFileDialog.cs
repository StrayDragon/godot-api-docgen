namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.EditorFileDialog"/> is a <see cref="Godot.FileDialog"/> tweaked to work in the editor. It automatically handles favorite and recent directory lists, and synchronizes some properties with their corresponding editor settings.</para>
/// <para><see cref="Godot.EditorFileDialog"/> will automatically show a native dialog based on the <c>EditorSettings.interface/editor/use_native_file_dialogs</c> editor setting and ignores <see cref="Godot.FileDialog.UseNativeDialog"/>.</para>
/// <para><b>Note:</b> <see cref="Godot.EditorFileDialog"/> is invisible by default. To make it visible, call one of the <c>popup_*</c> methods from <see cref="Godot.Window"/> on the node, such as <see cref="Godot.Window.PopupCenteredClamped(Nullable{Vector2I}, float)"/>.</para>
/// </summary>
public partial class EditorFileDialog : FileDialog
{
    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.EditorFileDialog"/> will not warn the user before overwriting files.</para>
    /// </summary>
    [Obsolete("Use 'Godot.FileDialog.OverwriteWarningEnabled' instead.")]
    public bool DisableOverwriteWarning
    {
        get
        {
            return IsOverwriteWarningDisabled();
        }
        set
        {
            SetDisableOverwriteWarning(value);
        }
    }

    private static readonly System.Type CachedType = typeof(EditorFileDialog);

    private static readonly StringName NativeName = "EditorFileDialog";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorFileDialog() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorFileDialog(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorFileDialog(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSideMenu, 402368861ul);

    /// <summary>
    /// <para>This method is kept for compatibility and does nothing. As an alternative, you can display another dialog after showing the file dialog.</para>
    /// </summary>
    [Obsolete("This feature is no longer supported.")]
    public void AddSideMenu(Control menu, string title = "")
    {
        EditorNativeCalls.godot_icall_2_490(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(menu), title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableOverwriteWarning, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisableOverwriteWarning(bool disable)
    {
        NativeCalls.godot_icall_1_14(MethodBind1, GodotObject.GetPtr(this), disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOverwriteWarningDisabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsOverwriteWarningDisabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : FileDialog.PropertyName
    {
        /// <summary>
        /// Cached name for the 'disable_overwrite_warning' property.
        /// </summary>
        public static readonly StringName DisableOverwriteWarning = "disable_overwrite_warning";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : FileDialog.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_side_menu' method.
        /// </summary>
        public static readonly StringName AddSideMenu = "add_side_menu";
        /// <summary>
        /// Cached name for the 'set_disable_overwrite_warning' method.
        /// </summary>
        public static readonly StringName SetDisableOverwriteWarning = "set_disable_overwrite_warning";
        /// <summary>
        /// Cached name for the 'is_overwrite_warning_disabled' method.
        /// </summary>
        public static readonly StringName IsOverwriteWarningDisabled = "is_overwrite_warning_disabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : FileDialog.SignalName
    {
    }
}
