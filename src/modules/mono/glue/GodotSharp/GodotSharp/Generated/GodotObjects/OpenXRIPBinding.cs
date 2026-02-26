namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This binding resource binds an <see cref="Godot.OpenXRAction"/> to an input or output. As most controllers have left hand and right versions that are handled by the same interaction profile we can specify multiple bindings. For instance an action "Fire" could be bound to both "/user/hand/left/input/trigger" and "/user/hand/right/input/trigger". This would require two binding entries.</para>
/// </summary>
public partial class OpenXRIPBinding : Resource
{
    /// <summary>
    /// <para><see cref="Godot.OpenXRAction"/> that is bound to <see cref="Godot.OpenXRIPBinding.BindingPath"/>.</para>
    /// </summary>
    public OpenXRAction Action
    {
        get
        {
            return GetAction();
        }
        set
        {
            SetAction(value);
        }
    }

    /// <summary>
    /// <para>Binding path that defines the input or output bound to <see cref="Godot.OpenXRIPBinding.Action"/>.</para>
    /// <para><b>Note:</b> Binding paths are suggestions, an XR runtime may choose to bind the action to a different input or output emulating this input or output.</para>
    /// </summary>
    public string BindingPath
    {
        get
        {
            return GetBindingPath();
        }
        set
        {
            SetBindingPath(value);
        }
    }

    /// <summary>
    /// <para>Binding modifiers for this binding.</para>
    /// </summary>
    public Godot.Collections.Array BindingModifiers
    {
        get
        {
            return GetBindingModifiers();
        }
        set
        {
            SetBindingModifiers(value);
        }
    }

    /// <summary>
    /// <para>Paths that define the inputs or outputs bound on the device.</para>
    /// </summary>
    [Obsolete("Use 'Godot.OpenXRIPBinding.BindingPath' instead.")]
    public string[] Paths
    {
        get
        {
            return GetPaths();
        }
        set
        {
            SetPaths(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRIPBinding);

    private static readonly StringName NativeName = "OpenXRIPBinding";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRIPBinding() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRIPBinding(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRIPBinding(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAction, 349361333ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAction(OpenXRAction action)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(action));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAction, 4072409085ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRAction GetAction()
    {
        return (OpenXRAction)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBindingPath, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBindingPath(string bindingPath)
    {
        NativeCalls.godot_icall_1_57(MethodBind2, GodotObject.GetPtr(this), bindingPath);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBindingPath, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetBindingPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBindingModifierCount, 3905245786ul);

    /// <summary>
    /// <para>Get the number of binding modifiers for this binding.</para>
    /// </summary>
    public int GetBindingModifierCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBindingModifier, 3538296211ul);

    /// <summary>
    /// <para>Get the <see cref="Godot.OpenXRBindingModifier"/> at this index.</para>
    /// </summary>
    public OpenXRActionBindingModifier GetBindingModifier(int index)
    {
        return (OpenXRActionBindingModifier)NativeCalls.godot_icall_1_71(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBindingModifiers, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBindingModifiers(Godot.Collections.Array bindingModifiers)
    {
        NativeCalls.godot_icall_1_138(MethodBind6, GodotObject.GetPtr(this), (godot_array)(bindingModifiers ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBindingModifiers, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetBindingModifiers()
    {
        return NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPaths, 4015028928ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPaths(string[] paths)
    {
        NativeCalls.godot_icall_1_185(MethodBind8, GodotObject.GetPtr(this), paths);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPaths(ReadOnlySpan<string> paths)
    {
        NativeCalls.godot_icall_1_185(MethodBind8, GodotObject.GetPtr(this), paths);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPaths, 1139954409ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string[] GetPaths()
    {
        return NativeCalls.godot_icall_0_108(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathCount, 3905245786ul);

    /// <summary>
    /// <para>Get the number of input/output paths in this binding.</para>
    /// </summary>
    [Obsolete("Binding is for a single path.")]
    public int GetPathCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasPath, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this input/output path is part of this binding.</para>
    /// </summary>
    [Obsolete("Binding is for a single path.")]
    public bool HasPath(string path)
    {
        return NativeCalls.godot_icall_1_131(MethodBind11, GodotObject.GetPtr(this), path).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPath, 83702148ul);

    /// <summary>
    /// <para>Add an input/output path to this binding.</para>
    /// </summary>
    [Obsolete("Binding is for a single path.")]
    public void AddPath(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind12, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePath, 83702148ul);

    /// <summary>
    /// <para>Removes this input/output path from this binding.</para>
    /// </summary>
    [Obsolete("Binding is for a single path.")]
    public void RemovePath(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind13, GodotObject.GetPtr(this), path);
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
        /// Cached name for the 'action' property.
        /// </summary>
        public static readonly StringName Action = "action";
        /// <summary>
        /// Cached name for the 'binding_path' property.
        /// </summary>
        public static readonly StringName BindingPath = "binding_path";
        /// <summary>
        /// Cached name for the 'binding_modifiers' property.
        /// </summary>
        public static readonly StringName BindingModifiers = "binding_modifiers";
        /// <summary>
        /// Cached name for the 'paths' property.
        /// </summary>
        public static readonly StringName Paths = "paths";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_action' method.
        /// </summary>
        public static readonly StringName SetAction = "set_action";
        /// <summary>
        /// Cached name for the 'get_action' method.
        /// </summary>
        public static readonly StringName GetAction = "get_action";
        /// <summary>
        /// Cached name for the 'set_binding_path' method.
        /// </summary>
        public static readonly StringName SetBindingPath = "set_binding_path";
        /// <summary>
        /// Cached name for the 'get_binding_path' method.
        /// </summary>
        public static readonly StringName GetBindingPath = "get_binding_path";
        /// <summary>
        /// Cached name for the 'get_binding_modifier_count' method.
        /// </summary>
        public static readonly StringName GetBindingModifierCount = "get_binding_modifier_count";
        /// <summary>
        /// Cached name for the 'get_binding_modifier' method.
        /// </summary>
        public static readonly StringName GetBindingModifier = "get_binding_modifier";
        /// <summary>
        /// Cached name for the 'set_binding_modifiers' method.
        /// </summary>
        public static readonly StringName SetBindingModifiers = "set_binding_modifiers";
        /// <summary>
        /// Cached name for the 'get_binding_modifiers' method.
        /// </summary>
        public static readonly StringName GetBindingModifiers = "get_binding_modifiers";
        /// <summary>
        /// Cached name for the 'set_paths' method.
        /// </summary>
        public static readonly StringName SetPaths = "set_paths";
        /// <summary>
        /// Cached name for the 'get_paths' method.
        /// </summary>
        public static readonly StringName GetPaths = "get_paths";
        /// <summary>
        /// Cached name for the 'get_path_count' method.
        /// </summary>
        public static readonly StringName GetPathCount = "get_path_count";
        /// <summary>
        /// Cached name for the 'has_path' method.
        /// </summary>
        public static readonly StringName HasPath = "has_path";
        /// <summary>
        /// Cached name for the 'add_path' method.
        /// </summary>
        public static readonly StringName AddPath = "add_path";
        /// <summary>
        /// Cached name for the 'remove_path' method.
        /// </summary>
        public static readonly StringName RemovePath = "remove_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
