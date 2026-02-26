namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Action sets in OpenXR define a collection of actions that can be activated in unison. This allows games to easily change between different states that require different inputs or need to reinterpret inputs. For instance we could have an action set that is active when a menu is open, an action set that is active when the player is freely walking around and an action set that is active when the player is controlling a vehicle.</para>
/// <para>Action sets can contain the same action with the same name, if such action sets are active at the same time the action set with the highest priority defines which binding is active.</para>
/// </summary>
public partial class OpenXRActionSet : Resource
{
    /// <summary>
    /// <para>The localized name of this action set.</para>
    /// </summary>
    public string LocalizedName
    {
        get
        {
            return GetLocalizedName();
        }
        set
        {
            SetLocalizedName(value);
        }
    }

    /// <summary>
    /// <para>The priority for this action set.</para>
    /// </summary>
    public int Priority
    {
        get
        {
            return GetPriority();
        }
        set
        {
            SetPriority(value);
        }
    }

    /// <summary>
    /// <para>Collection of actions for this action set.</para>
    /// </summary>
    public Godot.Collections.Array Actions
    {
        get
        {
            return GetActions();
        }
        set
        {
            SetActions(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRActionSet);

    private static readonly StringName NativeName = "OpenXRActionSet";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRActionSet() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRActionSet(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRActionSet(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLocalizedName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLocalizedName(string localizedName)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), localizedName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalizedName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLocalizedName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPriority, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPriority(int priority)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPriority, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPriority()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionCount, 3905245786ul);

    /// <summary>
    /// <para>Retrieve the number of actions in our action set.</para>
    /// </summary>
    public int GetActionCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActions, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetActions(Godot.Collections.Array actions)
    {
        NativeCalls.godot_icall_1_138(MethodBind5, GodotObject.GetPtr(this), (godot_array)(actions ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActions, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetActions()
    {
        return NativeCalls.godot_icall_0_120(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAction, 349361333ul);

    /// <summary>
    /// <para>Add an action to this action set.</para>
    /// </summary>
    public void AddAction(OpenXRAction action)
    {
        NativeCalls.godot_icall_1_56(MethodBind7, GodotObject.GetPtr(this), GodotObject.GetPtr(action));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveAction, 349361333ul);

    /// <summary>
    /// <para>Remove an action from this action set.</para>
    /// </summary>
    public void RemoveAction(OpenXRAction action)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(action));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'localized_name' property.
        /// </summary>
        public static readonly StringName LocalizedName = "localized_name";
        /// <summary>
        /// Cached name for the 'priority' property.
        /// </summary>
        public static readonly StringName Priority = "priority";
        /// <summary>
        /// Cached name for the 'actions' property.
        /// </summary>
        public static readonly StringName Actions = "actions";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_localized_name' method.
        /// </summary>
        public static readonly StringName SetLocalizedName = "set_localized_name";
        /// <summary>
        /// Cached name for the 'get_localized_name' method.
        /// </summary>
        public static readonly StringName GetLocalizedName = "get_localized_name";
        /// <summary>
        /// Cached name for the 'set_priority' method.
        /// </summary>
        public static readonly StringName SetPriority = "set_priority";
        /// <summary>
        /// Cached name for the 'get_priority' method.
        /// </summary>
        public static readonly StringName GetPriority = "get_priority";
        /// <summary>
        /// Cached name for the 'get_action_count' method.
        /// </summary>
        public static readonly StringName GetActionCount = "get_action_count";
        /// <summary>
        /// Cached name for the 'set_actions' method.
        /// </summary>
        public static readonly StringName SetActions = "set_actions";
        /// <summary>
        /// Cached name for the 'get_actions' method.
        /// </summary>
        public static readonly StringName GetActions = "get_actions";
        /// <summary>
        /// Cached name for the 'add_action' method.
        /// </summary>
        public static readonly StringName AddAction = "add_action";
        /// <summary>
        /// Cached name for the 'remove_action' method.
        /// </summary>
        public static readonly StringName RemoveAction = "remove_action";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
