namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.ScriptCreateDialog"/> creates script files according to a given template for a given scripting language. The standard use is to configure its fields prior to calling one of the <see cref="Godot.Window.Popup(Nullable{Rect2I})"/> methods.</para>
/// <para><code>
/// public override void _Ready()
/// {
/// 	var dialog = new ScriptCreateDialog();
/// 	dialog.Config("Node", "res://NewNode.cs"); // For in-engine types.
/// 	dialog.Config("\"res://BaseNode.cs\"", "res://DerivedNode.cs"); // For script types.
/// 	dialog.PopupCentered();
/// }
/// </code></para>
/// </summary>
public partial class ScriptCreateDialog : ConfirmationDialog
{
    private static readonly System.Type CachedType = typeof(ScriptCreateDialog);

    private static readonly StringName NativeName = "ScriptCreateDialog";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ScriptCreateDialog() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ScriptCreateDialog(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ScriptCreateDialog(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Config, 869314288ul);

    /// <summary>
    /// <para>Prefills required fields to configure the ScriptCreateDialog for use.</para>
    /// </summary>
    public void Config(string inherits, string path, bool builtInEnabled = true, bool loadEnabled = true)
    {
        EditorNativeCalls.godot_icall_4_1261(MethodBind0, GodotObject.GetPtr(this), inherits, path, builtInEnabled.ToGodotBool(), loadEnabled.ToGodotBool());
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ScriptCreateDialog.ScriptCreated"/> event of a <see cref="Godot.ScriptCreateDialog"/> class.
    /// </summary>
    public delegate void ScriptCreatedEventHandler(Script script);

    private static void ScriptCreatedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ScriptCreatedEventHandler)delegateObj)(VariantUtils.ConvertTo<Script>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the user clicks the OK button.</para>
    /// </summary>
    public unsafe event ScriptCreatedEventHandler ScriptCreated
    {
        add => Connect(SignalName.ScriptCreated, Callable.CreateWithUnsafeTrampoline(value, &ScriptCreatedTrampoline));
        remove => Disconnect(SignalName.ScriptCreated, Callable.CreateWithUnsafeTrampoline(value, &ScriptCreatedTrampoline));
    }

    protected void EmitSignalScriptCreated(Script script)
    {
        EmitSignal(SignalName.ScriptCreated, script);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_script_created = "ScriptCreated";

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
        if (signal == SignalName.ScriptCreated)
        {
            if (HasGodotClassSignal(SignalProxyName_script_created.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : ConfirmationDialog.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ConfirmationDialog.MethodName
    {
        /// <summary>
        /// Cached name for the 'config' method.
        /// </summary>
        public static readonly StringName Config = "config";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ConfirmationDialog.SignalName
    {
        /// <summary>
        /// Cached name for the 'script_created' signal.
        /// </summary>
        public static readonly StringName ScriptCreated = "script_created";
    }
}
