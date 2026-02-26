namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Godot editor's script editor.</para>
/// <para><b>Note:</b> This class shouldn't be instantiated directly. Instead, access the singleton using <see cref="Godot.EditorInterface.GetScriptEditor()"/>.</para>
/// </summary>
public partial class ScriptEditor : PanelContainer
{
    private static readonly System.Type CachedType = typeof(ScriptEditor);

    private static readonly StringName NativeName = "ScriptEditor";

    internal ScriptEditor() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ScriptEditor(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ScriptEditor(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentEditor, 1906266726ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.ScriptEditorBase"/> object that the user is currently editing.</para>
    /// </summary>
    public ScriptEditorBase GetCurrentEditor()
    {
        return (ScriptEditorBase)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpenScriptEditors, 3995934104ul);

    /// <summary>
    /// <para>Returns an array with all <see cref="Godot.ScriptEditorBase"/> objects which are currently open in editor.</para>
    /// </summary>
    public Godot.Collections.Array<ScriptEditorBase> GetOpenScriptEditors()
    {
        return new Godot.Collections.Array<ScriptEditorBase>(NativeCalls.godot_icall_0_120(MethodBind1, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBreakpoints, 2981934095ul);

    /// <summary>
    /// <para>Returns array of breakpoints.</para>
    /// </summary>
    public string[] GetBreakpoints()
    {
        return NativeCalls.godot_icall_0_108(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterSyntaxHighlighter, 1092774468ul);

    /// <summary>
    /// <para>Registers the <see cref="Godot.EditorSyntaxHighlighter"/> to the editor, the <see cref="Godot.EditorSyntaxHighlighter"/> will be available on all open scripts.</para>
    /// <para><b>Note:</b> Does not apply to scripts that are already opened.</para>
    /// </summary>
    public void RegisterSyntaxHighlighter(EditorSyntaxHighlighter syntaxHighlighter)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(syntaxHighlighter));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnregisterSyntaxHighlighter, 1092774468ul);

    /// <summary>
    /// <para>Unregisters the <see cref="Godot.EditorSyntaxHighlighter"/> from the editor.</para>
    /// <para><b>Note:</b> The <see cref="Godot.EditorSyntaxHighlighter"/> will still be applied to scripts that are already opened.</para>
    /// </summary>
    public void UnregisterSyntaxHighlighter(EditorSyntaxHighlighter syntaxHighlighter)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(syntaxHighlighter));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GotoLine, 1286410249ul);

    /// <summary>
    /// <para>Goes to the specified line in the current script.</para>
    /// </summary>
    public void GotoLine(int lineNumber)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), lineNumber);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentScript, 2146468882ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Script"/> that is currently active in editor.</para>
    /// </summary>
    public Script GetCurrentScript()
    {
        return (Script)NativeCalls.godot_icall_0_63(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpenScripts, 3995934104ul);

    /// <summary>
    /// <para>Returns an array with all <see cref="Godot.Script"/> objects which are currently open in editor.</para>
    /// </summary>
    public Godot.Collections.Array<Script> GetOpenScripts()
    {
        return new Godot.Collections.Array<Script>(NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OpenScriptCreateDialog, 3186203200ul);

    /// <summary>
    /// <para>Opens the script create dialog. The script will extend <paramref name="baseName"/>. The file extension can be omitted from <paramref name="basePath"/>. It will be added based on the selected scripting language.</para>
    /// </summary>
    public void OpenScriptCreateDialog(string baseName, string basePath)
    {
        NativeCalls.godot_icall_2_303(MethodBind8, GodotObject.GetPtr(this), baseName, basePath);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GotoHelp, 83702148ul);

    /// <summary>
    /// <para>Opens help for the given topic. The <paramref name="topic"/> is an encoded string that controls which class, method, constant, signal, annotation, property, or theme item should be focused.</para>
    /// <para>The supported <paramref name="topic"/> formats include <c>class_name:class</c>, <c>class_method:class:method</c>, <c>class_constant:class:constant</c>, <c>class_signal:class:signal</c>, <c>class_annotation:class:@annotation</c>, <c>class_property:class:property</c>, and <c>class_theme_item:class:item</c>, where <c>class</c> is the class name, <c>method</c> is the method name, <c>constant</c> is the constant name, <c>signal</c> is the signal name, <c>annotation</c> is the annotation name, <c>property</c> is the property name, and <c>item</c> is the theme item.</para>
    /// <para><code>
    /// # Shows help for the Node class.
    /// class_name:Node
    /// # Shows help for the global min function.
    /// # Global objects are accessible in the `@GlobalScope` namespace, shown here.
    /// class_method:@GlobalScope:min
    /// # Shows help for get_viewport in the Node class.
    /// class_method:Node:get_viewport
    /// # Shows help for the Input constant MOUSE_BUTTON_MIDDLE.
    /// class_constant:Input:MOUSE_BUTTON_MIDDLE
    /// # Shows help for the BaseButton signal pressed.
    /// class_signal:BaseButton:pressed
    /// # Shows help for the CanvasItem property visible.
    /// class_property:CanvasItem:visible
    /// # Shows help for the GDScript annotation export.
    /// # Annotations should be prefixed with the `@` symbol in the descriptor, as shown here.
    /// class_annotation:@GDScript:@export
    /// # Shows help for the GraphNode theme item named panel_selected.
    /// class_theme_item:GraphNode:panel_selected
    /// </code></para>
    /// </summary>
    public void GotoHelp(string topic)
    {
        NativeCalls.godot_icall_1_57(MethodBind9, GodotObject.GetPtr(this), topic);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateDocsFromScript, 3657522847ul);

    /// <summary>
    /// <para>Updates the documentation for the given <paramref name="script"/>.</para>
    /// <para><b>Note:</b> This should be called whenever the script is changed to keep the open documentation state up to date.</para>
    /// </summary>
    public void UpdateDocsFromScript(Script script)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(script));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearDocsFromScript, 3657522847ul);

    /// <summary>
    /// <para>Removes the documentation for the given <paramref name="script"/>.</para>
    /// <para><b>Note:</b> This should be called whenever the script is changed to keep the open documentation state up to date.</para>
    /// </summary>
    public void ClearDocsFromScript(Script script)
    {
        NativeCalls.godot_icall_1_56(MethodBind11, GodotObject.GetPtr(this), GodotObject.GetPtr(script));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ScriptEditor.EditorScriptChanged"/> event of a <see cref="Godot.ScriptEditor"/> class.
    /// </summary>
    public delegate void EditorScriptChangedEventHandler(Script script);

    private static void EditorScriptChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((EditorScriptChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Script>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when user changed active script. Argument is a freshly activated <see cref="Godot.Script"/>.</para>
    /// </summary>
    public unsafe event EditorScriptChangedEventHandler EditorScriptChanged
    {
        add => Connect(SignalName.EditorScriptChanged, Callable.CreateWithUnsafeTrampoline(value, &EditorScriptChangedTrampoline));
        remove => Disconnect(SignalName.EditorScriptChanged, Callable.CreateWithUnsafeTrampoline(value, &EditorScriptChangedTrampoline));
    }

    protected void EmitSignalEditorScriptChanged(Script script)
    {
        EmitSignal(SignalName.EditorScriptChanged, script);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ScriptEditor.ScriptClose"/> event of a <see cref="Godot.ScriptEditor"/> class.
    /// </summary>
    public delegate void ScriptCloseEventHandler(Script script);

    private static void ScriptCloseTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ScriptCloseEventHandler)delegateObj)(VariantUtils.ConvertTo<Script>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when editor is about to close the active script. Argument is a <see cref="Godot.Script"/> that is going to be closed.</para>
    /// </summary>
    public unsafe event ScriptCloseEventHandler ScriptClose
    {
        add => Connect(SignalName.ScriptClose, Callable.CreateWithUnsafeTrampoline(value, &ScriptCloseTrampoline));
        remove => Disconnect(SignalName.ScriptClose, Callable.CreateWithUnsafeTrampoline(value, &ScriptCloseTrampoline));
    }

    protected void EmitSignalScriptClose(Script script)
    {
        EmitSignal(SignalName.ScriptClose, script);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_editor_script_changed = "EditorScriptChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_script_close = "ScriptClose";

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
        if (signal == SignalName.EditorScriptChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_editor_script_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ScriptClose)
        {
            if (HasGodotClassSignal(SignalProxyName_script_close.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : PanelContainer.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PanelContainer.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_current_editor' method.
        /// </summary>
        public static readonly StringName GetCurrentEditor = "get_current_editor";
        /// <summary>
        /// Cached name for the 'get_open_script_editors' method.
        /// </summary>
        public static readonly StringName GetOpenScriptEditors = "get_open_script_editors";
        /// <summary>
        /// Cached name for the 'get_breakpoints' method.
        /// </summary>
        public static readonly StringName GetBreakpoints = "get_breakpoints";
        /// <summary>
        /// Cached name for the 'register_syntax_highlighter' method.
        /// </summary>
        public static readonly StringName RegisterSyntaxHighlighter = "register_syntax_highlighter";
        /// <summary>
        /// Cached name for the 'unregister_syntax_highlighter' method.
        /// </summary>
        public static readonly StringName UnregisterSyntaxHighlighter = "unregister_syntax_highlighter";
        /// <summary>
        /// Cached name for the 'goto_line' method.
        /// </summary>
        public static readonly StringName GotoLine = "goto_line";
        /// <summary>
        /// Cached name for the 'get_current_script' method.
        /// </summary>
        public static readonly StringName GetCurrentScript = "get_current_script";
        /// <summary>
        /// Cached name for the 'get_open_scripts' method.
        /// </summary>
        public static readonly StringName GetOpenScripts = "get_open_scripts";
        /// <summary>
        /// Cached name for the 'open_script_create_dialog' method.
        /// </summary>
        public static readonly StringName OpenScriptCreateDialog = "open_script_create_dialog";
        /// <summary>
        /// Cached name for the 'goto_help' method.
        /// </summary>
        public static readonly StringName GotoHelp = "goto_help";
        /// <summary>
        /// Cached name for the 'update_docs_from_script' method.
        /// </summary>
        public static readonly StringName UpdateDocsFromScript = "update_docs_from_script";
        /// <summary>
        /// Cached name for the 'clear_docs_from_script' method.
        /// </summary>
        public static readonly StringName ClearDocsFromScript = "clear_docs_from_script";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PanelContainer.SignalName
    {
        /// <summary>
        /// Cached name for the 'editor_script_changed' signal.
        /// </summary>
        public static readonly StringName EditorScriptChanged = "editor_script_changed";
        /// <summary>
        /// Cached name for the 'script_close' signal.
        /// </summary>
        public static readonly StringName ScriptClose = "script_close";
    }
}
