namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.EditorInspectorPlugin"/> allows adding custom property editors to <see cref="Godot.EditorInspector"/>.</para>
/// <para>When an object is edited, the <see cref="Godot.EditorInspectorPlugin._CanHandle(GodotObject)"/> function is called and must return <see langword="true"/> if the object type is supported.</para>
/// <para>If supported, the function <see cref="Godot.EditorInspectorPlugin._ParseBegin(GodotObject)"/> will be called, allowing to place custom controls at the beginning of the class.</para>
/// <para>Subsequently, the <see cref="Godot.EditorInspectorPlugin._ParseCategory(GodotObject, string)"/> and <see cref="Godot.EditorInspectorPlugin._ParseProperty(GodotObject, Variant.Type, string, PropertyHint, string, PropertyUsageFlags, bool)"/> are called for every category and property. They offer the ability to add custom controls to the inspector too.</para>
/// <para>Finally, <see cref="Godot.EditorInspectorPlugin._ParseEnd(GodotObject)"/> will be called.</para>
/// <para>On each of these calls, the "add" functions can be called.</para>
/// <para>To use <see cref="Godot.EditorInspectorPlugin"/>, register it using the <see cref="Godot.EditorPlugin.AddInspectorPlugin(EditorInspectorPlugin)"/> method first.</para>
/// </summary>
public partial class EditorInspectorPlugin : RefCounted
{
    private static readonly System.Type CachedType = typeof(EditorInspectorPlugin);

    private static readonly StringName NativeName = "EditorInspectorPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorInspectorPlugin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorInspectorPlugin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorInspectorPlugin(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Returns <see langword="true"/> if this object can be handled by this plugin.</para>
    /// </summary>
    public virtual bool _CanHandle(GodotObject @object)
    {
        return default;
    }

    /// <summary>
    /// <para>Called to allow adding controls at the beginning of the property list for <paramref name="object"/>.</para>
    /// </summary>
    public virtual void _ParseBegin(GodotObject @object)
    {
    }

    /// <summary>
    /// <para>Called to allow adding controls at the beginning of a category in the property list for <paramref name="object"/>.</para>
    /// </summary>
    public virtual void _ParseCategory(GodotObject @object, string category)
    {
    }

    /// <summary>
    /// <para>Called to allow adding controls at the end of the property list for <paramref name="object"/>.</para>
    /// </summary>
    public virtual void _ParseEnd(GodotObject @object)
    {
    }

    /// <summary>
    /// <para>Called to allow adding controls at the beginning of a group or a sub-group in the property list for <paramref name="object"/>.</para>
    /// </summary>
    public virtual void _ParseGroup(GodotObject @object, string group)
    {
    }

    /// <summary>
    /// <para>Called to allow adding property-specific editors to the property list for <paramref name="object"/>. The added editor control must extend <see cref="Godot.EditorProperty"/>. Returning <see langword="true"/> removes the built-in editor for this property, otherwise allows to insert a custom editor before the built-in one.</para>
    /// </summary>
    public virtual bool _ParseProperty(GodotObject @object, Variant.Type type, string name, PropertyHint hintType, string hintString, PropertyUsageFlags usageFlags, bool wide)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCustomControl, 1496901182ul);

    /// <summary>
    /// <para>Adds a custom control, which is not necessarily a property editor.</para>
    /// </summary>
    public void AddCustomControl(Control control)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPropertyEditor, 2042698479ul);

    /// <summary>
    /// <para>Adds a property editor for an individual property. The <paramref name="editor"/> control must extend <see cref="Godot.EditorProperty"/>.</para>
    /// <para>There can be multiple property editors for a property. If <paramref name="addToEnd"/> is <see langword="true"/>, this newly added editor will be displayed after all the other editors of the property whose <paramref name="addToEnd"/> is <see langword="false"/>. For example, the editor uses this parameter to add an "Edit Region" button for <see cref="Godot.Sprite2D.RegionRect"/> below the regular <see cref="Godot.Rect2"/> editor.</para>
    /// <para><paramref name="label"/> can be used to choose a custom label for the property editor in the inspector. If left empty, the label is computed from the name of the property instead.</para>
    /// </summary>
    public void AddPropertyEditor(string property, Control editor, bool addToEnd = false, string label = "")
    {
        EditorNativeCalls.godot_icall_4_493(MethodBind1, GodotObject.GetPtr(this), property, GodotObject.GetPtr(editor), addToEnd.ToGodotBool(), label);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPropertyEditorForMultipleProperties, 788598683ul);

    /// <summary>
    /// <para>Adds an editor that allows modifying multiple properties. The <paramref name="editor"/> control must extend <see cref="Godot.EditorProperty"/>.</para>
    /// </summary>
    public void AddPropertyEditorForMultipleProperties(string label, string[] properties, Control editor)
    {
        EditorNativeCalls.godot_icall_3_494(MethodBind2, GodotObject.GetPtr(this), label, properties, GodotObject.GetPtr(editor));
    }

    /// <summary>
    /// <para>Adds an editor that allows modifying multiple properties. The <paramref name="editor"/> control must extend <see cref="Godot.EditorProperty"/>.</para>
    /// </summary>
    public void AddPropertyEditorForMultipleProperties(string label, ReadOnlySpan<string> properties, Control editor)
    {
        EditorNativeCalls.godot_icall_3_494(MethodBind2, GodotObject.GetPtr(this), label, properties, GodotObject.GetPtr(editor));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPropertyEditor, 3406284123ul);

    /// <summary>
    /// <para>Adds a property editor for an individual property. The <paramref name="editor"/> control must extend <see cref="Godot.EditorProperty"/>.</para>
    /// <para>There can be multiple property editors for a property. If <paramref name="addToEnd"/> is <see langword="true"/>, this newly added editor will be displayed after all the other editors of the property whose <paramref name="addToEnd"/> is <see langword="false"/>. For example, the editor uses this parameter to add an "Edit Region" button for <see cref="Godot.Sprite2D.RegionRect"/> below the regular <see cref="Godot.Rect2"/> editor.</para>
    /// <para><paramref name="label"/> can be used to choose a custom label for the property editor in the inspector. If left empty, the label is computed from the name of the property instead.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddPropertyEditor(string property, Control editor, bool addToEnd)
    {
        EditorNativeCalls.godot_icall_3_495(MethodBind3, GodotObject.GetPtr(this), property, GodotObject.GetPtr(editor), addToEnd.ToGodotBool());
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__can_handle = "_CanHandle";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_begin = "_ParseBegin";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_category = "_ParseCategory";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_end = "_ParseEnd";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_group = "_ParseGroup";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_property = "_ParseProperty";

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
        if ((method == MethodProxyName__can_handle || method == MethodName._CanHandle) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__can_handle.NativeValue))
        {
            var callRet = _CanHandle(VariantUtils.ConvertTo<GodotObject>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__parse_begin || method == MethodName._ParseBegin) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_begin.NativeValue))
        {
            _ParseBegin(VariantUtils.ConvertTo<GodotObject>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__parse_category || method == MethodName._ParseCategory) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_category.NativeValue))
        {
            _ParseCategory(VariantUtils.ConvertTo<GodotObject>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__parse_end || method == MethodName._ParseEnd) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_end.NativeValue))
        {
            _ParseEnd(VariantUtils.ConvertTo<GodotObject>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__parse_group || method == MethodName._ParseGroup) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_group.NativeValue))
        {
            _ParseGroup(VariantUtils.ConvertTo<GodotObject>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__parse_property || method == MethodName._ParseProperty) && args.Count == 7 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_property.NativeValue))
        {
            var callRet = _ParseProperty(VariantUtils.ConvertTo<GodotObject>(args[0]), VariantUtils.ConvertTo<Variant.Type>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<PropertyHint>(args[3]), VariantUtils.ConvertTo<string>(args[4]), VariantUtils.ConvertTo<PropertyUsageFlags>(args[5]), VariantUtils.ConvertTo<bool>(args[6]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName._CanHandle)
        {
            if (HasGodotClassMethod(MethodProxyName__can_handle.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseBegin)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_begin.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseCategory)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_category.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseEnd)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_end.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseGroup)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_group.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseProperty)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_property.NativeValue.DangerousSelfRef))
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
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the '_can_handle' method.
        /// </summary>
        public static readonly StringName _CanHandle = "_can_handle";
        /// <summary>
        /// Cached name for the '_parse_begin' method.
        /// </summary>
        public static readonly StringName _ParseBegin = "_parse_begin";
        /// <summary>
        /// Cached name for the '_parse_category' method.
        /// </summary>
        public static readonly StringName _ParseCategory = "_parse_category";
        /// <summary>
        /// Cached name for the '_parse_end' method.
        /// </summary>
        public static readonly StringName _ParseEnd = "_parse_end";
        /// <summary>
        /// Cached name for the '_parse_group' method.
        /// </summary>
        public static readonly StringName _ParseGroup = "_parse_group";
        /// <summary>
        /// Cached name for the '_parse_property' method.
        /// </summary>
        public static readonly StringName _ParseProperty = "_parse_property";
        /// <summary>
        /// Cached name for the 'add_custom_control' method.
        /// </summary>
        public static readonly StringName AddCustomControl = "add_custom_control";
        /// <summary>
        /// Cached name for the 'add_property_editor' method.
        /// </summary>
        public static readonly StringName AddPropertyEditor = "add_property_editor";
        /// <summary>
        /// Cached name for the 'add_property_editor_for_multiple_properties' method.
        /// </summary>
        public static readonly StringName AddPropertyEditorForMultipleProperties = "add_property_editor_for_multiple_properties";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
