namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is the control that implements property editing in the editor's Settings dialogs, the Inspector dock, etc. To get the <see cref="Godot.EditorInspector"/> used in the editor's Inspector dock, use <see cref="Godot.EditorInterface.GetInspector()"/>.</para>
/// <para><see cref="Godot.EditorInspector"/> will show properties in the same order as the array returned by <see cref="Godot.GodotObject.GetPropertyList()"/>.</para>
/// <para>If a property's name is path-like (i.e. if it contains forward slashes), <see cref="Godot.EditorInspector"/> will create nested sections for "directories" along the path. For example, if a property is named <c>highlighting/gdscript/node_path_color</c>, it will be shown as "Node Path Color" inside the "GDScript" section nested inside the "Highlighting" section.</para>
/// <para>If a property has <see cref="Godot.PropertyUsageFlags.Group"/> usage, it will group subsequent properties whose name starts with the property's hint string. The group ends when a property does not start with that hint string or when a new group starts. An empty group name effectively ends the current group. <see cref="Godot.EditorInspector"/> will create a top-level section for each group. For example, if a property with group usage is named <c>Collide With</c> and its hint string is <c>collide_with_</c>, a subsequent <c>collide_with_area</c> property will be shown as "Area" inside the "Collide With" section. There is also a special case: when the hint string contains the name of a property, that property is grouped too. This is mainly to help grouping properties like <c>font</c>, <c>font_color</c> and <c>font_size</c> (using the hint string <c>font_</c>).</para>
/// <para>If a property has <see cref="Godot.PropertyUsageFlags.Subgroup"/> usage, a subgroup will be created in the same way as a group, and a second-level section will be created for each subgroup.</para>
/// <para><b>Note:</b> Unlike sections created from path-like property names, <see cref="Godot.EditorInspector"/> won't capitalize the name for sections created from groups. So properties with group usage usually use capitalized names instead of snake_cased names.</para>
/// </summary>
public partial class EditorInspector : ScrollContainer
{
    private static readonly System.Type CachedType = typeof(EditorInspector);

    private static readonly StringName NativeName = "EditorInspector";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorInspector() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorInspector(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorInspector(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Edit, 3975164845ul);

    /// <summary>
    /// <para>Shows the properties of the given <paramref name="object"/> in this inspector for editing. To clear the inspector, call this method with <see langword="null"/>.</para>
    /// <para><b>Note:</b> If you want to edit an object in the editor's main inspector, use the <c>edit_*</c> methods in <see cref="Godot.EditorInterface"/> instead.</para>
    /// </summary>
    public void Edit(GodotObject @object)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(@object));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedPath, 201670096ul);

    /// <summary>
    /// <para>Gets the path of the currently selected property.</para>
    /// </summary>
    public string GetSelectedPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditedObject, 2050059866ul);

    /// <summary>
    /// <para>Returns the object currently selected in this inspector.</para>
    /// </summary>
    public GodotObject GetEditedObject()
    {
        return (GodotObject)NativeCalls.godot_icall_0_53(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstantiatePropertyEditor, 1429914152ul);

    /// <summary>
    /// <para>Creates a property editor that can be used by plugin UI to edit the specified property of an <paramref name="object"/>.</para>
    /// </summary>
    public static EditorProperty InstantiatePropertyEditor(GodotObject @object, Variant.Type type, string path, PropertyHint hint, string hintText, uint usage, bool wide = false)
    {
        return (EditorProperty)EditorNativeCalls.godot_icall_7_492(MethodBind3, GodotObject.GetPtr(@object), (int)type, path, (int)hint, hintText, usage, wide.ToGodotBool());
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorInspector.PropertySelected"/> event of a <see cref="Godot.EditorInspector"/> class.
    /// </summary>
    public delegate void PropertySelectedEventHandler(string property);

    private static void PropertySelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PropertySelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a property is selected in the inspector.</para>
    /// </summary>
    public unsafe event PropertySelectedEventHandler PropertySelected
    {
        add => Connect(SignalName.PropertySelected, Callable.CreateWithUnsafeTrampoline(value, &PropertySelectedTrampoline));
        remove => Disconnect(SignalName.PropertySelected, Callable.CreateWithUnsafeTrampoline(value, &PropertySelectedTrampoline));
    }

    protected void EmitSignalPropertySelected(string property)
    {
        EmitSignal(SignalName.PropertySelected, property);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorInspector.PropertyKeyed"/> event of a <see cref="Godot.EditorInspector"/> class.
    /// </summary>
    public delegate void PropertyKeyedEventHandler(string property, Variant value, bool advance);

    private static void PropertyKeyedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((PropertyKeyedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a property is keyed in the inspector. Properties can be keyed by clicking the "key" icon next to a property when the Animation panel is toggled.</para>
    /// </summary>
    public unsafe event PropertyKeyedEventHandler PropertyKeyed
    {
        add => Connect(SignalName.PropertyKeyed, Callable.CreateWithUnsafeTrampoline(value, &PropertyKeyedTrampoline));
        remove => Disconnect(SignalName.PropertyKeyed, Callable.CreateWithUnsafeTrampoline(value, &PropertyKeyedTrampoline));
    }

    protected void EmitSignalPropertyKeyed(string property, Variant value, bool advance)
    {
        EmitSignal(SignalName.PropertyKeyed, property, value, advance);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorInspector.PropertyDeleted"/> event of a <see cref="Godot.EditorInspector"/> class.
    /// </summary>
    public delegate void PropertyDeletedEventHandler(string property);

    private static void PropertyDeletedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PropertyDeletedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a property is removed from the inspector.</para>
    /// </summary>
    public unsafe event PropertyDeletedEventHandler PropertyDeleted
    {
        add => Connect(SignalName.PropertyDeleted, Callable.CreateWithUnsafeTrampoline(value, &PropertyDeletedTrampoline));
        remove => Disconnect(SignalName.PropertyDeleted, Callable.CreateWithUnsafeTrampoline(value, &PropertyDeletedTrampoline));
    }

    protected void EmitSignalPropertyDeleted(string property)
    {
        EmitSignal(SignalName.PropertyDeleted, property);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorInspector.ResourceSelected"/> event of a <see cref="Godot.EditorInspector"/> class.
    /// </summary>
    public delegate void ResourceSelectedEventHandler(Resource resource, string path);

    private static void ResourceSelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((ResourceSelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<Resource>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a resource is selected in the inspector.</para>
    /// </summary>
    public unsafe event ResourceSelectedEventHandler ResourceSelected
    {
        add => Connect(SignalName.ResourceSelected, Callable.CreateWithUnsafeTrampoline(value, &ResourceSelectedTrampoline));
        remove => Disconnect(SignalName.ResourceSelected, Callable.CreateWithUnsafeTrampoline(value, &ResourceSelectedTrampoline));
    }

    protected void EmitSignalResourceSelected(Resource resource, string path)
    {
        EmitSignal(SignalName.ResourceSelected, resource, path);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorInspector.ObjectIdSelected"/> event of a <see cref="Godot.EditorInspector"/> class.
    /// </summary>
    public delegate void ObjectIdSelectedEventHandler(long id);

    private static void ObjectIdSelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ObjectIdSelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the Edit button of an <see cref="Godot.GodotObject"/> has been pressed in the inspector. This is mainly used in the remote scene tree Inspector.</para>
    /// </summary>
    public unsafe event ObjectIdSelectedEventHandler ObjectIdSelected
    {
        add => Connect(SignalName.ObjectIdSelected, Callable.CreateWithUnsafeTrampoline(value, &ObjectIdSelectedTrampoline));
        remove => Disconnect(SignalName.ObjectIdSelected, Callable.CreateWithUnsafeTrampoline(value, &ObjectIdSelectedTrampoline));
    }

    protected void EmitSignalObjectIdSelected(long id)
    {
        EmitSignal(SignalName.ObjectIdSelected, id);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorInspector.PropertyEdited"/> event of a <see cref="Godot.EditorInspector"/> class.
    /// </summary>
    public delegate void PropertyEditedEventHandler(string property);

    private static void PropertyEditedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PropertyEditedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a property is edited in the inspector.</para>
    /// </summary>
    public unsafe event PropertyEditedEventHandler PropertyEdited
    {
        add => Connect(SignalName.PropertyEdited, Callable.CreateWithUnsafeTrampoline(value, &PropertyEditedTrampoline));
        remove => Disconnect(SignalName.PropertyEdited, Callable.CreateWithUnsafeTrampoline(value, &PropertyEditedTrampoline));
    }

    protected void EmitSignalPropertyEdited(string property)
    {
        EmitSignal(SignalName.PropertyEdited, property);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorInspector.PropertyToggled"/> event of a <see cref="Godot.EditorInspector"/> class.
    /// </summary>
    public delegate void PropertyToggledEventHandler(string property, bool @checked);

    private static void PropertyToggledTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((PropertyToggledEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a boolean property is toggled in the inspector.</para>
    /// <para><b>Note:</b> This signal is never emitted if the internal <c>autoclear</c> property enabled. Since this property is always enabled in the editor inspector, this signal is never emitted by the editor itself.</para>
    /// </summary>
    public unsafe event PropertyToggledEventHandler PropertyToggled
    {
        add => Connect(SignalName.PropertyToggled, Callable.CreateWithUnsafeTrampoline(value, &PropertyToggledTrampoline));
        remove => Disconnect(SignalName.PropertyToggled, Callable.CreateWithUnsafeTrampoline(value, &PropertyToggledTrampoline));
    }

    protected void EmitSignalPropertyToggled(string property, bool @checked)
    {
        EmitSignal(SignalName.PropertyToggled, property, @checked);
    }

    /// <summary>
    /// <para>Emitted when the object being edited by the inspector has changed.</para>
    /// </summary>
    public event Action EditedObjectChanged
    {
        add => Connect(SignalName.EditedObjectChanged, Callable.From(value));
        remove => Disconnect(SignalName.EditedObjectChanged, Callable.From(value));
    }

    protected void EmitSignalEditedObjectChanged()
    {
        EmitSignal(SignalName.EditedObjectChanged);
    }

    /// <summary>
    /// <para>Emitted when a property that requires a restart to be applied is edited in the inspector. This is only used in the Project Settings and Editor Settings.</para>
    /// </summary>
    public event Action RestartRequested
    {
        add => Connect(SignalName.RestartRequested, Callable.From(value));
        remove => Disconnect(SignalName.RestartRequested, Callable.From(value));
    }

    protected void EmitSignalRestartRequested()
    {
        EmitSignal(SignalName.RestartRequested);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_property_selected = "PropertySelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_property_keyed = "PropertyKeyed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_property_deleted = "PropertyDeleted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resource_selected = "ResourceSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_object_id_selected = "ObjectIdSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_property_edited = "PropertyEdited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_property_toggled = "PropertyToggled";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_edited_object_changed = "EditedObjectChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_restart_requested = "RestartRequested";

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
        if (signal == SignalName.PropertySelected)
        {
            if (HasGodotClassSignal(SignalProxyName_property_selected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PropertyKeyed)
        {
            if (HasGodotClassSignal(SignalProxyName_property_keyed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PropertyDeleted)
        {
            if (HasGodotClassSignal(SignalProxyName_property_deleted.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ResourceSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_resource_selected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ObjectIdSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_object_id_selected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PropertyEdited)
        {
            if (HasGodotClassSignal(SignalProxyName_property_edited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PropertyToggled)
        {
            if (HasGodotClassSignal(SignalProxyName_property_toggled.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.EditedObjectChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_edited_object_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.RestartRequested)
        {
            if (HasGodotClassSignal(SignalProxyName_restart_requested.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : ScrollContainer.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ScrollContainer.MethodName
    {
        /// <summary>
        /// Cached name for the 'edit' method.
        /// </summary>
        public static readonly StringName Edit = "edit";
        /// <summary>
        /// Cached name for the 'get_selected_path' method.
        /// </summary>
        public static readonly StringName GetSelectedPath = "get_selected_path";
        /// <summary>
        /// Cached name for the 'get_edited_object' method.
        /// </summary>
        public static readonly StringName GetEditedObject = "get_edited_object";
        /// <summary>
        /// Cached name for the 'instantiate_property_editor' method.
        /// </summary>
        public static readonly StringName InstantiatePropertyEditor = "instantiate_property_editor";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ScrollContainer.SignalName
    {
        /// <summary>
        /// Cached name for the 'property_selected' signal.
        /// </summary>
        public static readonly StringName PropertySelected = "property_selected";
        /// <summary>
        /// Cached name for the 'property_keyed' signal.
        /// </summary>
        public static readonly StringName PropertyKeyed = "property_keyed";
        /// <summary>
        /// Cached name for the 'property_deleted' signal.
        /// </summary>
        public static readonly StringName PropertyDeleted = "property_deleted";
        /// <summary>
        /// Cached name for the 'resource_selected' signal.
        /// </summary>
        public static readonly StringName ResourceSelected = "resource_selected";
        /// <summary>
        /// Cached name for the 'object_id_selected' signal.
        /// </summary>
        public static readonly StringName ObjectIdSelected = "object_id_selected";
        /// <summary>
        /// Cached name for the 'property_edited' signal.
        /// </summary>
        public static readonly StringName PropertyEdited = "property_edited";
        /// <summary>
        /// Cached name for the 'property_toggled' signal.
        /// </summary>
        public static readonly StringName PropertyToggled = "property_toggled";
        /// <summary>
        /// Cached name for the 'edited_object_changed' signal.
        /// </summary>
        public static readonly StringName EditedObjectChanged = "edited_object_changed";
        /// <summary>
        /// Cached name for the 'restart_requested' signal.
        /// </summary>
        public static readonly StringName RestartRequested = "restart_requested";
    }
}
