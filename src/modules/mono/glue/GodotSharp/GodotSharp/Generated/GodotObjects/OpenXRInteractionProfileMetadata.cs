namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class allows OpenXR core and extensions to register metadata relating to supported interaction devices such as controllers, trackers, haptic devices, etc. It is primarily used by the action map editor and to sanitize any action map by removing extension-dependent entries when applicable.</para>
/// </summary>
public partial class OpenXRInteractionProfileMetadata : GodotObject
{
    private static readonly System.Type CachedType = typeof(OpenXRInteractionProfileMetadata);

    private static readonly StringName NativeName = "OpenXRInteractionProfileMetadata";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRInteractionProfileMetadata() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRInteractionProfileMetadata(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRInteractionProfileMetadata(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterProfileRename, 3186203200ul);

    /// <summary>
    /// <para>Allows for renaming old interaction profile paths to new paths in order to load and process older action maps.</para>
    /// </summary>
    public void RegisterProfileRename(string oldName, string newName)
    {
        NativeCalls.godot_icall_2_303(MethodBind0, GodotObject.GetPtr(this), oldName, newName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterPathRename, 3186203200ul);

    /// <summary>
    /// <para>Allows for renaming old input/output paths to new paths in order to load and process older action maps.</para>
    /// </summary>
    public void RegisterPathRename(string oldName, string newName)
    {
        NativeCalls.godot_icall_2_303(MethodBind1, GodotObject.GetPtr(this), oldName, newName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterTopLevelPath, 254767734ul);

    /// <summary>
    /// <para>Registers a top level path to which profiles can be bound. For instance <c>/user/hand/left</c> refers to the bind point for the player's left hand. Extensions can register additional top level paths, for instance a haptic vest extension might register <c>/user/body/vest</c>.</para>
    /// <para><paramref name="displayName"/> is the name shown to the user. <paramref name="openxrPath"/> is the top level path being registered. <paramref name="openxrExtensionNames"/> is optional and ensures the top level path is only used if the specified extension is available/enabled.</para>
    /// <para>When a top level path ends up being bound by OpenXR, an <see cref="Godot.XRPositionalTracker"/> is instantiated to manage the state of the device.</para>
    /// </summary>
    public void RegisterTopLevelPath(string displayName, string openxrPath, string openxrExtensionNames)
    {
        NativeCalls.godot_icall_3_582(MethodBind2, GodotObject.GetPtr(this), displayName, openxrPath, openxrExtensionNames);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterInteractionProfile, 254767734ul);

    /// <summary>
    /// <para>Registers an interaction profile using its OpenXR designation (e.g. <c>/interaction_profiles/khr/simple_controller</c> is the profile for OpenXR's simple controller profile).</para>
    /// <para><paramref name="displayName"/> is the description shown to the user. <paramref name="openxrPath"/> is the interaction profile path being registered. <paramref name="openxrExtensionNames"/> optionally restricts this profile to the given extension being enabled/available. If the extension is not available, the profile and all related entries used in an action map are filtered out.</para>
    /// </summary>
    public void RegisterInteractionProfile(string displayName, string openxrPath, string openxrExtensionNames)
    {
        NativeCalls.godot_icall_3_582(MethodBind3, GodotObject.GetPtr(this), displayName, openxrPath, openxrExtensionNames);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterIOPath, 3443511926ul);

    /// <summary>
    /// <para>Registers an input/output path for the given <paramref name="interactionProfile"/>. The profile should previously have been registered using <see cref="Godot.OpenXRInteractionProfileMetadata.RegisterInteractionProfile(string, string, string)"/>. <paramref name="displayName"/> is the description shown to the user. <paramref name="toplevelPath"/> specifies the bind path this input/output can be bound to (e.g. <c>/user/hand/left</c> or <c>/user/hand/right</c>). <paramref name="openxrPath"/> is the action input/output being registered (e.g. <c>/user/hand/left/input/aim/pose</c>). <paramref name="openxrExtensionNames"/> restricts this input/output to an enabled/available extension, this doesn't need to repeat the extension on the profile but relates to overlapping extension (e.g. <c>XR_EXT_palm_pose</c> that introduces <c>…/input/palm_ext/pose</c> input paths). <paramref name="actionType"/> defines the type of input or output provided by OpenXR.</para>
    /// </summary>
    public void RegisterIOPath(string interactionProfile, string displayName, string toplevelPath, string openxrPath, string openxrExtensionNames, OpenXRAction.ActionTypeEnum actionType)
    {
        NativeCalls.godot_icall_6_936(MethodBind4, GodotObject.GetPtr(this), interactionProfile, displayName, toplevelPath, openxrPath, openxrExtensionNames, (int)actionType);
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'register_profile_rename' method.
        /// </summary>
        public static readonly StringName RegisterProfileRename = "register_profile_rename";
        /// <summary>
        /// Cached name for the 'register_path_rename' method.
        /// </summary>
        public static readonly StringName RegisterPathRename = "register_path_rename";
        /// <summary>
        /// Cached name for the 'register_top_level_path' method.
        /// </summary>
        public static readonly StringName RegisterTopLevelPath = "register_top_level_path";
        /// <summary>
        /// Cached name for the 'register_interaction_profile' method.
        /// </summary>
        public static readonly StringName RegisterInteractionProfile = "register_interaction_profile";
        /// <summary>
        /// Cached name for the 'register_io_path' method.
        /// </summary>
        public static readonly StringName RegisterIOPath = "register_io_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
