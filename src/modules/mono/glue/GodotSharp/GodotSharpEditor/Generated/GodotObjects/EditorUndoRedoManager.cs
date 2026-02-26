namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.EditorUndoRedoManager"/> is a manager for <see cref="Godot.UndoRedo"/> objects associated with edited scenes. Each scene has its own undo history and <see cref="Godot.EditorUndoRedoManager"/> ensures that each action performed in the editor gets associated with a proper scene. For actions not related to scenes (<see cref="Godot.ProjectSettings"/> edits, external resources, etc.), a separate global history is used.</para>
/// <para>The usage is mostly the same as <see cref="Godot.UndoRedo"/>. You create and commit actions and the manager automatically decides under-the-hood what scenes it belongs to. The scene is deduced based on the first operation in an action, using the object from the operation. The rules are as follows:</para>
/// <para>- If the object is a <see cref="Godot.Node"/>, use the currently edited scene;</para>
/// <para>- If the object is a built-in resource, use the scene from its path;</para>
/// <para>- If the object is external resource or anything else, use global history.</para>
/// <para>This guessing can sometimes yield false results, so you can provide a custom context object when creating an action.</para>
/// <para><see cref="Godot.EditorUndoRedoManager"/> is intended to be used by Godot editor plugins. You can obtain it using <see cref="Godot.EditorPlugin.GetUndoRedo()"/>. For non-editor uses or plugins that don't need to integrate with the editor's undo history, use <see cref="Godot.UndoRedo"/> instead.</para>
/// <para>The manager's API is mostly the same as in <see cref="Godot.UndoRedo"/>, so you can refer to its documentation for more examples. The main difference is that <see cref="Godot.EditorUndoRedoManager"/> uses object + method name for actions, instead of <see cref="Godot.Callable"/>.</para>
/// </summary>
public partial class EditorUndoRedoManager : GodotObject
{
    public enum SpecialHistory : long
    {
        /// <summary>
        /// <para>Global history not associated with any scene, but with external resources etc.</para>
        /// </summary>
        GlobalHistory = 0,
        /// <summary>
        /// <para>History associated with remote inspector. Used when live editing a running project.</para>
        /// </summary>
        RemoteHistory = -9,
        /// <summary>
        /// <para>Invalid "null" history. It's a special value, not associated with any object.</para>
        /// </summary>
        InvalidHistory = -99
    }

    private static readonly System.Type CachedType = typeof(EditorUndoRedoManager);

    private static readonly StringName NativeName = "EditorUndoRedoManager";

    internal EditorUndoRedoManager() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorUndoRedoManager(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorUndoRedoManager(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateAction, 796197507ul);

    /// <summary>
    /// <para>Create a new action. After this is called, do all your calls to <see cref="Godot.EditorUndoRedoManager.AddDoMethod(GodotObject, StringName, Variant[])"/>, <see cref="Godot.EditorUndoRedoManager.AddUndoMethod(GodotObject, StringName, Variant[])"/>, <see cref="Godot.EditorUndoRedoManager.AddDoProperty(GodotObject, StringName, Variant)"/>, and <see cref="Godot.EditorUndoRedoManager.AddUndoProperty(GodotObject, StringName, Variant)"/>, then commit the action with <see cref="Godot.EditorUndoRedoManager.CommitAction(bool)"/>.</para>
    /// <para>The way actions are merged is dictated by the <paramref name="mergeMode"/> argument.</para>
    /// <para>If <paramref name="customContext"/> object is provided, it will be used for deducing target history (instead of using the first operation).</para>
    /// <para>The way undo operation are ordered in actions is dictated by <paramref name="backwardUndoOps"/>. When <paramref name="backwardUndoOps"/> is <see langword="false"/> undo option are ordered in the same order they were added. Which means the first operation to be added will be the first to be undone.</para>
    /// <para>If <paramref name="markUnsaved"/> is <see langword="false"/>, the action will not mark the history as unsaved. This is useful for example for actions that change a selection, or a setting that will be saved automatically. Otherwise, this should be left to <see langword="true"/> if the action requires saving by the user or if it can cause data loss when left unsaved.</para>
    /// </summary>
    public void CreateAction(string name, UndoRedo.MergeMode mergeMode = (UndoRedo.MergeMode)(0), GodotObject customContext = null, bool backwardUndoOps = false, bool markUnsaved = true)
    {
        EditorNativeCalls.godot_icall_5_534(MethodBind0, GodotObject.GetPtr(this), name, (int)mergeMode, GodotObject.GetPtr(customContext), backwardUndoOps.ToGodotBool(), markUnsaved.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CommitAction, 3216645846ul);

    /// <summary>
    /// <para>Commits the action. If <paramref name="execute"/> is <see langword="true"/> (default), all "do" methods/properties are called/set when this function is called.</para>
    /// </summary>
    public void CommitAction(bool execute = true)
    {
        NativeCalls.godot_icall_1_14(MethodBind1, GodotObject.GetPtr(this), execute.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCommittingAction, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <see cref="Godot.EditorUndoRedoManager"/> is currently committing the action, i.e. running its "do" method or property change (see <see cref="Godot.EditorUndoRedoManager.CommitAction(bool)"/>).</para>
    /// </summary>
    public bool IsCommittingAction()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceFixedHistory, 3218959716ul);

    /// <summary>
    /// <para>Forces the next operation (e.g. <see cref="Godot.EditorUndoRedoManager.AddDoMethod(GodotObject, StringName, Variant[])"/>) to use the action's history rather than guessing it from the object. This is sometimes needed when a history can't be correctly determined, like for a nested resource that doesn't have a path yet.</para>
    /// <para>This method should only be used when absolutely necessary, otherwise it might cause invalid history state. For most of complex cases, the <c>custom_context</c> parameter of <see cref="Godot.EditorUndoRedoManager.CreateAction(string, UndoRedo.MergeMode, GodotObject, bool, bool)"/> is sufficient.</para>
    /// </summary>
    public void ForceFixedHistory()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddDoMethod, 1517810467ul);

    /// <summary>
    /// <para>Register a method that will be called when the action is committed (i.e. the "do" action).</para>
    /// <para>If this is the first operation, the <paramref name="object"/> will be used to deduce target undo history.</para>
    /// </summary>
    public void AddDoMethod(GodotObject @object, StringName method, params Variant[] @args)
    {
        EditorNativeCalls.godot_icall_3_535(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.AddDoMethod.NativeValue);
    }

    /// <summary>
    /// <para>Register a method that will be called when the action is committed (i.e. the "do" action).</para>
    /// <para>If this is the first operation, the <paramref name="object"/> will be used to deduce target undo history.</para>
    /// </summary>
    public void AddDoMethod(GodotObject @object, StringName method, ReadOnlySpan<Variant> @args)
    {
        EditorNativeCalls.godot_icall_3_535(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.AddDoMethod.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddUndoMethod, 1517810467ul);

    /// <summary>
    /// <para>Register a method that will be called when the action is undone (i.e. the "undo" action).</para>
    /// <para>If this is the first operation, the <paramref name="object"/> will be used to deduce target undo history.</para>
    /// </summary>
    public void AddUndoMethod(GodotObject @object, StringName method, params Variant[] @args)
    {
        EditorNativeCalls.godot_icall_3_535(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.AddUndoMethod.NativeValue);
    }

    /// <summary>
    /// <para>Register a method that will be called when the action is undone (i.e. the "undo" action).</para>
    /// <para>If this is the first operation, the <paramref name="object"/> will be used to deduce target undo history.</para>
    /// </summary>
    public void AddUndoMethod(GodotObject @object, StringName method, ReadOnlySpan<Variant> @args)
    {
        EditorNativeCalls.godot_icall_3_535(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.AddUndoMethod.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddDoProperty, 1017172818ul);

    /// <summary>
    /// <para>Register a property value change for "do".</para>
    /// <para>If this is the first operation, the <paramref name="object"/> will be used to deduce target undo history.</para>
    /// </summary>
    public void AddDoProperty(GodotObject @object, StringName property, Variant value)
    {
        NativeCalls.godot_icall_3_536(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), (godot_string_name)(property?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddUndoProperty, 1017172818ul);

    /// <summary>
    /// <para>Register a property value change for "undo".</para>
    /// <para>If this is the first operation, the <paramref name="object"/> will be used to deduce target undo history.</para>
    /// </summary>
    public void AddUndoProperty(GodotObject @object, StringName property, Variant value)
    {
        NativeCalls.godot_icall_3_536(MethodBind7, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), (godot_string_name)(property?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddDoReference, 3975164845ul);

    /// <summary>
    /// <para>Register a reference for "do" that will be erased if the "do" history is lost. This is useful mostly for new nodes created for the "do" call. Do not use for resources.</para>
    /// </summary>
    public void AddDoReference(GodotObject @object)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(@object));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddUndoReference, 3975164845ul);

    /// <summary>
    /// <para>Register a reference for "undo" that will be erased if the "undo" history is lost. This is useful mostly for nodes removed with the "do" call (not the "undo" call!).</para>
    /// </summary>
    public void AddUndoReference(GodotObject @object)
    {
        NativeCalls.godot_icall_1_56(MethodBind9, GodotObject.GetPtr(this), GodotObject.GetPtr(@object));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetObjectHistoryId, 1107568780ul);

    /// <summary>
    /// <para>Returns the history ID deduced from the given <paramref name="object"/>. It can be used with <see cref="Godot.EditorUndoRedoManager.GetHistoryUndoRedo(int)"/>.</para>
    /// </summary>
    public int GetObjectHistoryId(GodotObject @object)
    {
        return NativeCalls.godot_icall_1_371(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(@object));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHistoryUndoRedo, 2417974513ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.UndoRedo"/> object associated with the given history <paramref name="id"/>.</para>
    /// <para><paramref name="id"/> above <c>0</c> are mapped to the opened scene tabs (but it doesn't match their order). <paramref name="id"/> of <c>0</c> or lower have special meaning (see <see cref="Godot.EditorUndoRedoManager.SpecialHistory"/>).</para>
    /// <para>Best used with <see cref="Godot.EditorUndoRedoManager.GetObjectHistoryId(GodotObject)"/>. This method is only provided in case you need some more advanced methods of <see cref="Godot.UndoRedo"/> (but keep in mind that directly operating on the <see cref="Godot.UndoRedo"/> object might affect editor's stability).</para>
    /// </summary>
    public UndoRedo GetHistoryUndoRedo(int id)
    {
        return (UndoRedo)NativeCalls.godot_icall_1_335(MethodBind11, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearHistory, 2020603371ul);

    /// <summary>
    /// <para>Clears the given undo history. You can clear history for a specific scene, global history, or for all histories at once (except <see cref="Godot.EditorUndoRedoManager.SpecialHistory.RemoteHistory"/>) if <paramref name="id"/> is <see cref="Godot.EditorUndoRedoManager.SpecialHistory.InvalidHistory"/>.</para>
    /// <para>If <paramref name="increaseVersion"/> is <see langword="true"/>, the undo history version will be increased, marking it as unsaved. Useful for operations that modify the scene, but don't support undo.</para>
    /// <para><code>
    /// var scene_root = EditorInterface.get_edited_scene_root()
    /// var undo_redo = EditorInterface.get_editor_undo_redo()
    /// undo_redo.clear_history(undo_redo.get_object_history_id(scene_root))
    /// </code></para>
    /// <para><b>Note:</b> If you want to mark an edited scene as unsaved without clearing its history, use <see cref="Godot.EditorInterface.MarkSceneAsUnsaved()"/> instead.</para>
    /// </summary>
    public void ClearHistory(int id = -99, bool increaseVersion = true)
    {
        NativeCalls.godot_icall_2_61(MethodBind12, GodotObject.GetPtr(this), id, increaseVersion.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateAction, 2107025470ul);

    /// <summary>
    /// <para>Create a new action. After this is called, do all your calls to <see cref="Godot.EditorUndoRedoManager.AddDoMethod(GodotObject, StringName, Variant[])"/>, <see cref="Godot.EditorUndoRedoManager.AddUndoMethod(GodotObject, StringName, Variant[])"/>, <see cref="Godot.EditorUndoRedoManager.AddDoProperty(GodotObject, StringName, Variant)"/>, and <see cref="Godot.EditorUndoRedoManager.AddUndoProperty(GodotObject, StringName, Variant)"/>, then commit the action with <see cref="Godot.EditorUndoRedoManager.CommitAction(bool)"/>.</para>
    /// <para>The way actions are merged is dictated by the <paramref name="mergeMode"/> argument.</para>
    /// <para>If <paramref name="customContext"/> object is provided, it will be used for deducing target history (instead of using the first operation).</para>
    /// <para>The way undo operation are ordered in actions is dictated by <paramref name="backwardUndoOps"/>. When <paramref name="backwardUndoOps"/> is <see langword="false"/> undo option are ordered in the same order they were added. Which means the first operation to be added will be the first to be undone.</para>
    /// <para>If <paramref name="markUnsaved"/> is <see langword="false"/>, the action will not mark the history as unsaved. This is useful for example for actions that change a selection, or a setting that will be saved automatically. Otherwise, this should be left to <see langword="true"/> if the action requires saving by the user or if it can cause data loss when left unsaved.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void CreateAction(string name, UndoRedo.MergeMode mergeMode, GodotObject customContext, bool backwardUndoOps)
    {
        EditorNativeCalls.godot_icall_4_537(MethodBind13, GodotObject.GetPtr(this), name, (int)mergeMode, GodotObject.GetPtr(customContext), backwardUndoOps.ToGodotBool());
    }

    /// <summary>
    /// <para>Emitted when the list of actions in any history has changed, either when an action is committed or a history is cleared.</para>
    /// </summary>
    public event Action HistoryChanged
    {
        add => Connect(SignalName.HistoryChanged, Callable.From(value));
        remove => Disconnect(SignalName.HistoryChanged, Callable.From(value));
    }

    protected void EmitSignalHistoryChanged()
    {
        EmitSignal(SignalName.HistoryChanged);
    }

    /// <summary>
    /// <para>Emitted when the version of any history has changed as a result of undo or redo call.</para>
    /// </summary>
    public event Action VersionChanged
    {
        add => Connect(SignalName.VersionChanged, Callable.From(value));
        remove => Disconnect(SignalName.VersionChanged, Callable.From(value));
    }

    protected void EmitSignalVersionChanged()
    {
        EmitSignal(SignalName.VersionChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_history_changed = "HistoryChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_version_changed = "VersionChanged";

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
        if (signal == SignalName.HistoryChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_history_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.VersionChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_version_changed.NativeValue.DangerousSelfRef))
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_action' method.
        /// </summary>
        public static readonly StringName CreateAction = "create_action";
        /// <summary>
        /// Cached name for the 'commit_action' method.
        /// </summary>
        public static readonly StringName CommitAction = "commit_action";
        /// <summary>
        /// Cached name for the 'is_committing_action' method.
        /// </summary>
        public static readonly StringName IsCommittingAction = "is_committing_action";
        /// <summary>
        /// Cached name for the 'force_fixed_history' method.
        /// </summary>
        public static readonly StringName ForceFixedHistory = "force_fixed_history";
        /// <summary>
        /// Cached name for the 'add_do_method' method.
        /// </summary>
        public static readonly StringName AddDoMethod = "add_do_method";
        /// <summary>
        /// Cached name for the 'add_undo_method' method.
        /// </summary>
        public static readonly StringName AddUndoMethod = "add_undo_method";
        /// <summary>
        /// Cached name for the 'add_do_property' method.
        /// </summary>
        public static readonly StringName AddDoProperty = "add_do_property";
        /// <summary>
        /// Cached name for the 'add_undo_property' method.
        /// </summary>
        public static readonly StringName AddUndoProperty = "add_undo_property";
        /// <summary>
        /// Cached name for the 'add_do_reference' method.
        /// </summary>
        public static readonly StringName AddDoReference = "add_do_reference";
        /// <summary>
        /// Cached name for the 'add_undo_reference' method.
        /// </summary>
        public static readonly StringName AddUndoReference = "add_undo_reference";
        /// <summary>
        /// Cached name for the 'get_object_history_id' method.
        /// </summary>
        public static readonly StringName GetObjectHistoryId = "get_object_history_id";
        /// <summary>
        /// Cached name for the 'get_history_undo_redo' method.
        /// </summary>
        public static readonly StringName GetHistoryUndoRedo = "get_history_undo_redo";
        /// <summary>
        /// Cached name for the 'clear_history' method.
        /// </summary>
        public static readonly StringName ClearHistory = "clear_history";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
        /// <summary>
        /// Cached name for the 'history_changed' signal.
        /// </summary>
        public static readonly StringName HistoryChanged = "history_changed";
        /// <summary>
        /// Cached name for the 'version_changed' signal.
        /// </summary>
        public static readonly StringName VersionChanged = "version_changed";
    }
}
