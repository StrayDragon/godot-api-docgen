namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object manages the functionality and display of toast notifications within the editor, ensuring immediate and informative alerts are presented to the user.</para>
/// <para><b>Note:</b> This class shouldn't be instantiated directly. Instead, access the singleton using <see cref="Godot.EditorInterface.GetEditorToaster()"/>.</para>
/// </summary>
public partial class EditorToaster : HBoxContainer
{
    public enum Severity : long
    {
        /// <summary>
        /// <para>Toast will display with an INFO severity.</para>
        /// </summary>
        Info = 0,
        /// <summary>
        /// <para>Toast will display with a WARNING severity and have a corresponding color.</para>
        /// </summary>
        Warning = 1,
        /// <summary>
        /// <para>Toast will display with an ERROR severity and have a corresponding color.</para>
        /// </summary>
        Error = 2
    }

    private static readonly System.Type CachedType = typeof(EditorToaster);

    private static readonly StringName NativeName = "EditorToaster";

    internal EditorToaster() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorToaster(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorToaster(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushToast, 1813923476ul);

    /// <summary>
    /// <para>Pushes a toast notification to the editor for display.</para>
    /// </summary>
    public void PushToast(string message, EditorToaster.Severity severity = (EditorToaster.Severity)(0), string tooltip = "")
    {
        NativeCalls.godot_icall_3_397(MethodBind0, GodotObject.GetPtr(this), message, (int)severity, tooltip);
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
    public new class PropertyName : HBoxContainer.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : HBoxContainer.MethodName
    {
        /// <summary>
        /// Cached name for the 'push_toast' method.
        /// </summary>
        public static readonly StringName PushToast = "push_toast";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : HBoxContainer.SignalName
    {
    }
}
