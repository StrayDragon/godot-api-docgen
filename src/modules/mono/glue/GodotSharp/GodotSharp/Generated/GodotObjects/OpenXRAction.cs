namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This resource defines an OpenXR action. Actions can be used both for inputs (buttons, joysticks, triggers, etc.) and outputs (haptics).</para>
/// <para>OpenXR performs automatic conversion between action type and input type whenever possible. An analog trigger bound to a boolean action will thus return <see langword="false"/> if the trigger is depressed and <see langword="true"/> if pressed fully.</para>
/// <para>Actions are not directly bound to specific devices, instead OpenXR recognizes a limited number of top level paths that identify devices by usage. We can restrict which devices an action can be bound to by these top level paths. For instance an action that should only be used for hand held controllers can have the top level paths "/user/hand/left" and "/user/hand/right" associated with them. See the <a href="https://www.khronos.org/registry/OpenXR/specs/1.0/html/xrspec.html#semantic-path-reserved">reserved path section in the OpenXR specification</a> for more info on the top level paths.</para>
/// <para>Note that the name of the resource is used to register the action with.</para>
/// </summary>
public partial class OpenXRAction : Resource
{
    public enum ActionTypeEnum : long
    {
        /// <summary>
        /// <para>This action provides a boolean value.</para>
        /// </summary>
        Bool = 0,
        /// <summary>
        /// <para>This action provides a float value between <c>0.0</c> and <c>1.0</c> for any analog input such as triggers.</para>
        /// </summary>
        Float = 1,
        /// <summary>
        /// <para>This action provides a <see cref="Godot.Vector2"/> value and can be bound to embedded trackpads and joysticks.</para>
        /// </summary>
        Vector2 = 2,
        Pose = 3
    }

    /// <summary>
    /// <para>The localized description of this action.</para>
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
    /// <para>The type of action.</para>
    /// </summary>
    public OpenXRAction.ActionTypeEnum ActionType
    {
        get
        {
            return GetActionType();
        }
        set
        {
            SetActionType(value);
        }
    }

    /// <summary>
    /// <para>A collections of toplevel paths to which this action can be bound.</para>
    /// </summary>
    public string[] ToplevelPaths
    {
        get
        {
            return GetToplevelPaths();
        }
        set
        {
            SetToplevelPaths(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRAction);

    private static readonly StringName NativeName = "OpenXRAction";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRAction() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRAction(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRAction(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActionType, 1675238366ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetActionType(OpenXRAction.ActionTypeEnum actionType)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)actionType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionType, 3536542431ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRAction.ActionTypeEnum GetActionType()
    {
        return (OpenXRAction.ActionTypeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetToplevelPaths, 4015028928ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetToplevelPaths(string[] toplevelPaths)
    {
        NativeCalls.godot_icall_1_185(MethodBind4, GodotObject.GetPtr(this), toplevelPaths);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetToplevelPaths(ReadOnlySpan<string> toplevelPaths)
    {
        NativeCalls.godot_icall_1_185(MethodBind4, GodotObject.GetPtr(this), toplevelPaths);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetToplevelPaths, 1139954409ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string[] GetToplevelPaths()
    {
        return NativeCalls.godot_icall_0_108(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'action_type' property.
        /// </summary>
        public static readonly StringName ActionType = "action_type";
        /// <summary>
        /// Cached name for the 'toplevel_paths' property.
        /// </summary>
        public static readonly StringName ToplevelPaths = "toplevel_paths";
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
        /// Cached name for the 'set_action_type' method.
        /// </summary>
        public static readonly StringName SetActionType = "set_action_type";
        /// <summary>
        /// Cached name for the 'get_action_type' method.
        /// </summary>
        public static readonly StringName GetActionType = "get_action_type";
        /// <summary>
        /// Cached name for the 'set_toplevel_paths' method.
        /// </summary>
        public static readonly StringName SetToplevelPaths = "set_toplevel_paths";
        /// <summary>
        /// Cached name for the 'get_toplevel_paths' method.
        /// </summary>
        public static readonly StringName GetToplevelPaths = "get_toplevel_paths";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
