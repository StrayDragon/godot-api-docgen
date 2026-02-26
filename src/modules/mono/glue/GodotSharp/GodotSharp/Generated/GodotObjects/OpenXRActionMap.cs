namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>OpenXR uses an action system similar to Godots Input map system to bind inputs and outputs on various types of XR controllers to named actions. OpenXR specifies more detail on these inputs and outputs than Godot supports.</para>
/// <para>Another important distinction is that OpenXR offers no control over these bindings. The bindings we register are suggestions, it is up to the XR runtime to offer users the ability to change these bindings. This allows the XR runtime to fill in the gaps if new hardware becomes available.</para>
/// <para>The action map therefore needs to be loaded at startup and can't be changed afterwards. This resource is a container for the entire action map.</para>
/// </summary>
public partial class OpenXRActionMap : Resource
{
    /// <summary>
    /// <para>Collection of <see cref="Godot.OpenXRActionSet"/>s that are part of this action map.</para>
    /// </summary>
    public Godot.Collections.Array ActionSets
    {
        get
        {
            return GetActionSets();
        }
        set
        {
            SetActionSets(value);
        }
    }

    /// <summary>
    /// <para>Collection of <see cref="Godot.OpenXRInteractionProfile"/>s that are part of this action map.</para>
    /// </summary>
    public Godot.Collections.Array InteractionProfiles
    {
        get
        {
            return GetInteractionProfiles();
        }
        set
        {
            SetInteractionProfiles(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRActionMap);

    private static readonly StringName NativeName = "OpenXRActionMap";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRActionMap() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRActionMap(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRActionMap(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActionSets, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetActionSets(Godot.Collections.Array actionSets)
    {
        NativeCalls.godot_icall_1_138(MethodBind0, GodotObject.GetPtr(this), (godot_array)(actionSets ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionSets, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetActionSets()
    {
        return NativeCalls.godot_icall_0_120(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionSetCount, 3905245786ul);

    /// <summary>
    /// <para>Retrieve the number of actions sets in our action map.</para>
    /// </summary>
    public int GetActionSetCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindActionSet, 1888809267ul);

    /// <summary>
    /// <para>Retrieve an action set by name.</para>
    /// </summary>
    public OpenXRActionSet FindActionSet(string name)
    {
        return (OpenXRActionSet)NativeCalls.godot_icall_1_533(MethodBind3, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionSet, 1789580336ul);

    /// <summary>
    /// <para>Retrieve the action set at this index.</para>
    /// </summary>
    public OpenXRActionSet GetActionSet(int idx)
    {
        return (OpenXRActionSet)NativeCalls.godot_icall_1_71(MethodBind4, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddActionSet, 2093310581ul);

    /// <summary>
    /// <para>Add an action set.</para>
    /// </summary>
    public void AddActionSet(OpenXRActionSet actionSet)
    {
        NativeCalls.godot_icall_1_56(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(actionSet));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveActionSet, 2093310581ul);

    /// <summary>
    /// <para>Remove an action set.</para>
    /// </summary>
    public void RemoveActionSet(OpenXRActionSet actionSet)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(actionSet));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInteractionProfiles, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInteractionProfiles(Godot.Collections.Array interactionProfiles)
    {
        NativeCalls.godot_icall_1_138(MethodBind7, GodotObject.GetPtr(this), (godot_array)(interactionProfiles ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInteractionProfiles, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetInteractionProfiles()
    {
        return NativeCalls.godot_icall_0_120(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInteractionProfileCount, 3905245786ul);

    /// <summary>
    /// <para>Retrieve the number of interaction profiles in our action map.</para>
    /// </summary>
    public int GetInteractionProfileCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindInteractionProfile, 3095875538ul);

    /// <summary>
    /// <para>Find an interaction profile by its name (path).</para>
    /// </summary>
    public OpenXRInteractionProfile FindInteractionProfile(string name)
    {
        return (OpenXRInteractionProfile)NativeCalls.godot_icall_1_533(MethodBind10, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInteractionProfile, 2546151210ul);

    /// <summary>
    /// <para>Get the interaction profile at this index.</para>
    /// </summary>
    public OpenXRInteractionProfile GetInteractionProfile(int idx)
    {
        return (OpenXRInteractionProfile)NativeCalls.godot_icall_1_71(MethodBind11, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddInteractionProfile, 2697953512ul);

    /// <summary>
    /// <para>Add an interaction profile.</para>
    /// </summary>
    public void AddInteractionProfile(OpenXRInteractionProfile interactionProfile)
    {
        NativeCalls.godot_icall_1_56(MethodBind12, GodotObject.GetPtr(this), GodotObject.GetPtr(interactionProfile));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveInteractionProfile, 2697953512ul);

    /// <summary>
    /// <para>Remove an interaction profile.</para>
    /// </summary>
    public void RemoveInteractionProfile(OpenXRInteractionProfile interactionProfile)
    {
        NativeCalls.godot_icall_1_56(MethodBind13, GodotObject.GetPtr(this), GodotObject.GetPtr(interactionProfile));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateDefaultActionSets, 3218959716ul);

    /// <summary>
    /// <para>Setup this action set with our default actions.</para>
    /// </summary>
    public void CreateDefaultActionSets()
    {
        NativeCalls.godot_icall_0_3(MethodBind14, GodotObject.GetPtr(this));
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
        /// Cached name for the 'action_sets' property.
        /// </summary>
        public static readonly StringName ActionSets = "action_sets";
        /// <summary>
        /// Cached name for the 'interaction_profiles' property.
        /// </summary>
        public static readonly StringName InteractionProfiles = "interaction_profiles";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_action_sets' method.
        /// </summary>
        public static readonly StringName SetActionSets = "set_action_sets";
        /// <summary>
        /// Cached name for the 'get_action_sets' method.
        /// </summary>
        public static readonly StringName GetActionSets = "get_action_sets";
        /// <summary>
        /// Cached name for the 'get_action_set_count' method.
        /// </summary>
        public static readonly StringName GetActionSetCount = "get_action_set_count";
        /// <summary>
        /// Cached name for the 'find_action_set' method.
        /// </summary>
        public static readonly StringName FindActionSet = "find_action_set";
        /// <summary>
        /// Cached name for the 'get_action_set' method.
        /// </summary>
        public static readonly StringName GetActionSet = "get_action_set";
        /// <summary>
        /// Cached name for the 'add_action_set' method.
        /// </summary>
        public static readonly StringName AddActionSet = "add_action_set";
        /// <summary>
        /// Cached name for the 'remove_action_set' method.
        /// </summary>
        public static readonly StringName RemoveActionSet = "remove_action_set";
        /// <summary>
        /// Cached name for the 'set_interaction_profiles' method.
        /// </summary>
        public static readonly StringName SetInteractionProfiles = "set_interaction_profiles";
        /// <summary>
        /// Cached name for the 'get_interaction_profiles' method.
        /// </summary>
        public static readonly StringName GetInteractionProfiles = "get_interaction_profiles";
        /// <summary>
        /// Cached name for the 'get_interaction_profile_count' method.
        /// </summary>
        public static readonly StringName GetInteractionProfileCount = "get_interaction_profile_count";
        /// <summary>
        /// Cached name for the 'find_interaction_profile' method.
        /// </summary>
        public static readonly StringName FindInteractionProfile = "find_interaction_profile";
        /// <summary>
        /// Cached name for the 'get_interaction_profile' method.
        /// </summary>
        public static readonly StringName GetInteractionProfile = "get_interaction_profile";
        /// <summary>
        /// Cached name for the 'add_interaction_profile' method.
        /// </summary>
        public static readonly StringName AddInteractionProfile = "add_interaction_profile";
        /// <summary>
        /// Cached name for the 'remove_interaction_profile' method.
        /// </summary>
        public static readonly StringName RemoveInteractionProfile = "remove_interaction_profile";
        /// <summary>
        /// Cached name for the 'create_default_action_sets' method.
        /// </summary>
        public static readonly StringName CreateDefaultActionSets = "create_default_action_sets";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
