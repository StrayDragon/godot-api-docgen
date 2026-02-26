namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.Control"/> node is used in the editor's Inspector dock to allow editing of <see cref="Godot.Resource"/> type properties. It provides options for creating, loading, saving and converting resources. Can be used with <see cref="Godot.EditorInspectorPlugin"/> to recreate the same behavior.</para>
/// <para><b>Note:</b> This <see cref="Godot.Control"/> does not include any editor for the resource, as editing is controlled by the Inspector dock itself or sub-Inspectors.</para>
/// </summary>
public partial class EditorResourcePicker : HBoxContainer
{
    /// <summary>
    /// <para>The base type of allowed resource types. Can be a comma-separated list of several options.</para>
    /// </summary>
    public string BaseType
    {
        get
        {
            return GetBaseType();
        }
        set
        {
            SetBaseType(value);
        }
    }

    /// <summary>
    /// <para>The edited resource value.</para>
    /// </summary>
    public Resource EditedResource
    {
        get
        {
            return GetEditedResource();
        }
        set
        {
            SetEditedResource(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the value can be selected and edited.</para>
    /// </summary>
    public bool Editable
    {
        get
        {
            return IsEditable();
        }
        set
        {
            SetEditable(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the main button with the resource preview works in the toggle mode. Use <see cref="Godot.EditorResourcePicker.SetTogglePressed(bool)"/> to manually set the state.</para>
    /// </summary>
    public bool ToggleMode
    {
        get
        {
            return IsToggleMode();
        }
        set
        {
            SetToggleMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(EditorResourcePicker);

    private static readonly StringName NativeName = "EditorResourcePicker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorResourcePicker() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorResourcePicker(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorResourcePicker(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>This virtual method can be implemented to handle context menu items not handled by default. See <see cref="Godot.EditorResourcePicker._SetCreateOptions(GodotObject)"/>.</para>
    /// </summary>
    public virtual bool _HandleMenuSelected(int id)
    {
        return default;
    }

    /// <summary>
    /// <para>This virtual method is called when updating the context menu of <see cref="Godot.EditorResourcePicker"/>. Implement this method to override the "New ..." items with your own options. <paramref name="menuNode"/> is a reference to the <see cref="Godot.PopupMenu"/> node.</para>
    /// <para><b>Note:</b> Implement <see cref="Godot.EditorResourcePicker._HandleMenuSelected(int)"/> to handle these custom items.</para>
    /// </summary>
    public virtual void _SetCreateOptions(GodotObject menuNode)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBaseType, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBaseType(string baseType)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), baseType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBaseType, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetBaseType()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllowedTypes, 1139954409ul);

    /// <summary>
    /// <para>Returns a list of all allowed types and subtypes corresponding to the <see cref="Godot.EditorResourcePicker.BaseType"/>. If the <see cref="Godot.EditorResourcePicker.BaseType"/> is empty, an empty list is returned.</para>
    /// </summary>
    public string[] GetAllowedTypes()
    {
        return NativeCalls.godot_icall_0_108(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditedResource, 968641751ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditedResource(Resource resource)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(resource));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditedResource, 2674603643ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Resource GetEditedResource()
    {
        return (Resource)NativeCalls.godot_icall_0_63(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetToggleMode, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetToggleMode(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsToggleMode, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsToggleMode()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTogglePressed, 2586408642ul);

    /// <summary>
    /// <para>Sets the toggle mode state for the main button. Works only if <see cref="Godot.EditorResourcePicker.ToggleMode"/> is set to <see langword="true"/>.</para>
    /// </summary>
    public void SetTogglePressed(bool pressed)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), pressed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditable(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorResourcePicker.ResourceSelected"/> event of a <see cref="Godot.EditorResourcePicker"/> class.
    /// </summary>
    public delegate void ResourceSelectedEventHandler(Resource resource, bool inspect);

    private static void ResourceSelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((ResourceSelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<Resource>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the resource value was set and user clicked to edit it. When <c>inspect</c> is <see langword="true"/>, the signal was caused by the context menu "Edit" or "Inspect" option.</para>
    /// </summary>
    public unsafe event ResourceSelectedEventHandler ResourceSelected
    {
        add => Connect(SignalName.ResourceSelected, Callable.CreateWithUnsafeTrampoline(value, &ResourceSelectedTrampoline));
        remove => Disconnect(SignalName.ResourceSelected, Callable.CreateWithUnsafeTrampoline(value, &ResourceSelectedTrampoline));
    }

    protected void EmitSignalResourceSelected(Resource resource, bool inspect)
    {
        EmitSignal(SignalName.ResourceSelected, resource, inspect);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorResourcePicker.ResourceChanged"/> event of a <see cref="Godot.EditorResourcePicker"/> class.
    /// </summary>
    public delegate void ResourceChangedEventHandler(Resource resource);

    private static void ResourceChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ResourceChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Resource>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the value of the edited resource was changed.</para>
    /// </summary>
    public unsafe event ResourceChangedEventHandler ResourceChanged
    {
        add => Connect(SignalName.ResourceChanged, Callable.CreateWithUnsafeTrampoline(value, &ResourceChangedTrampoline));
        remove => Disconnect(SignalName.ResourceChanged, Callable.CreateWithUnsafeTrampoline(value, &ResourceChangedTrampoline));
    }

    protected void EmitSignalResourceChanged(Resource resource)
    {
        EmitSignal(SignalName.ResourceChanged, resource);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__handle_menu_selected = "_HandleMenuSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_create_options = "_SetCreateOptions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resource_selected = "ResourceSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resource_changed = "ResourceChanged";

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
        if ((method == MethodProxyName__handle_menu_selected || method == MethodName._HandleMenuSelected) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__handle_menu_selected.NativeValue))
        {
            var callRet = _HandleMenuSelected(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set_create_options || method == MethodName._SetCreateOptions) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_create_options.NativeValue))
        {
            _SetCreateOptions(VariantUtils.ConvertTo<GodotObject>(args[0]));
            ret = default;
            return true;
        }
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
        if (method == MethodName._HandleMenuSelected)
        {
            if (HasGodotClassMethod(MethodProxyName__handle_menu_selected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetCreateOptions)
        {
            if (HasGodotClassMethod(MethodProxyName__set_create_options.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        if (signal == SignalName.ResourceSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_resource_selected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ResourceChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_resource_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : HBoxContainer.PropertyName
    {
        /// <summary>
        /// Cached name for the 'base_type' property.
        /// </summary>
        public static readonly StringName BaseType = "base_type";
        /// <summary>
        /// Cached name for the 'edited_resource' property.
        /// </summary>
        public static readonly StringName EditedResource = "edited_resource";
        /// <summary>
        /// Cached name for the 'editable' property.
        /// </summary>
        public static readonly StringName Editable = "editable";
        /// <summary>
        /// Cached name for the 'toggle_mode' property.
        /// </summary>
        public static readonly StringName ToggleMode = "toggle_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : HBoxContainer.MethodName
    {
        /// <summary>
        /// Cached name for the '_handle_menu_selected' method.
        /// </summary>
        public static readonly StringName _HandleMenuSelected = "_handle_menu_selected";
        /// <summary>
        /// Cached name for the '_set_create_options' method.
        /// </summary>
        public static readonly StringName _SetCreateOptions = "_set_create_options";
        /// <summary>
        /// Cached name for the 'set_base_type' method.
        /// </summary>
        public static readonly StringName SetBaseType = "set_base_type";
        /// <summary>
        /// Cached name for the 'get_base_type' method.
        /// </summary>
        public static readonly StringName GetBaseType = "get_base_type";
        /// <summary>
        /// Cached name for the 'get_allowed_types' method.
        /// </summary>
        public static readonly StringName GetAllowedTypes = "get_allowed_types";
        /// <summary>
        /// Cached name for the 'set_edited_resource' method.
        /// </summary>
        public static readonly StringName SetEditedResource = "set_edited_resource";
        /// <summary>
        /// Cached name for the 'get_edited_resource' method.
        /// </summary>
        public static readonly StringName GetEditedResource = "get_edited_resource";
        /// <summary>
        /// Cached name for the 'set_toggle_mode' method.
        /// </summary>
        public static readonly StringName SetToggleMode = "set_toggle_mode";
        /// <summary>
        /// Cached name for the 'is_toggle_mode' method.
        /// </summary>
        public static readonly StringName IsToggleMode = "is_toggle_mode";
        /// <summary>
        /// Cached name for the 'set_toggle_pressed' method.
        /// </summary>
        public static readonly StringName SetTogglePressed = "set_toggle_pressed";
        /// <summary>
        /// Cached name for the 'set_editable' method.
        /// </summary>
        public static readonly StringName SetEditable = "set_editable";
        /// <summary>
        /// Cached name for the 'is_editable' method.
        /// </summary>
        public static readonly StringName IsEditable = "is_editable";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : HBoxContainer.SignalName
    {
        /// <summary>
        /// Cached name for the 'resource_selected' signal.
        /// </summary>
        public static readonly StringName ResourceSelected = "resource_selected";
        /// <summary>
        /// Cached name for the 'resource_changed' signal.
        /// </summary>
        public static readonly StringName ResourceChanged = "resource_changed";
    }
}
