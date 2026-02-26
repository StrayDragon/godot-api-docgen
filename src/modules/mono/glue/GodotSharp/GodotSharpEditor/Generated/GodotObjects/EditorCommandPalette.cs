namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Object that holds all the available Commands and their shortcuts text. These Commands can be accessed through <b>Editor &gt; Command Palette</b> menu.</para>
/// <para>Command key names use slash delimiters to distinguish sections, for example: <c>"example/command1"</c> then <c>example</c> will be the section name.</para>
/// <para><code>
/// EditorCommandPalette commandPalette = EditorInterface.Singleton.GetCommandPalette();
/// // ExternalCommand is a function that will be called with the command is executed.
/// Callable commandCallable = new Callable(this, MethodName.ExternalCommand);
/// commandPalette.AddCommand("command", "test/command", commandCallable)
/// </code></para>
/// <para><b>Note:</b> This class shouldn't be instantiated directly. Instead, access the singleton using <see cref="Godot.EditorInterface.GetCommandPalette()"/>.</para>
/// </summary>
public partial class EditorCommandPalette : ConfirmationDialog
{
    private static readonly System.Type CachedType = typeof(EditorCommandPalette);

    private static readonly StringName NativeName = "EditorCommandPalette";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorCommandPalette() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorCommandPalette(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorCommandPalette(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCommand, 864043298ul);

    /// <summary>
    /// <para>Adds a custom command to EditorCommandPalette.</para>
    /// <para>- <paramref name="commandName"/>: <see cref="string"/> (Name of the <b>Command</b>. This is displayed to the user.)</para>
    /// <para>- <paramref name="keyName"/>: <see cref="string"/> (Name of the key for a particular <b>Command</b>. This is used to uniquely identify the <b>Command</b>.)</para>
    /// <para>- <paramref name="bindedCallable"/>: <see cref="Godot.Callable"/> (Callable of the <b>Command</b>. This will be executed when the <b>Command</b> is selected.)</para>
    /// <para>- <paramref name="shortcutText"/>: <see cref="string"/> (Shortcut text of the <b>Command</b> if available.)</para>
    /// </summary>
    public void AddCommand(string commandName, string keyName, Callable bindedCallable, string shortcutText = "None")
    {
        EditorNativeCalls.godot_icall_4_465(MethodBind0, GodotObject.GetPtr(this), commandName, keyName, bindedCallable, shortcutText);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCommand, 83702148ul);

    /// <summary>
    /// <para>Removes the custom command from EditorCommandPalette.</para>
    /// <para>- <paramref name="keyName"/>: <see cref="string"/> (Name of the key for a particular <b>Command</b>.)</para>
    /// </summary>
    public void RemoveCommand(string keyName)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), keyName);
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
    public new class PropertyName : ConfirmationDialog.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ConfirmationDialog.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_command' method.
        /// </summary>
        public static readonly StringName AddCommand = "add_command";
        /// <summary>
        /// Cached name for the 'remove_command' method.
        /// </summary>
        public static readonly StringName RemoveCommand = "remove_command";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ConfirmationDialog.SignalName
    {
    }
}
