namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This plugin type exists to modify the process of importing scenes, allowing to change the content as well as add importer options at every stage of the process.</para>
/// </summary>
public partial class EditorScenePostImportPlugin : RefCounted
{
    public enum InternalImportCategory : long
    {
        Node = 0,
        Mesh3DNode = 1,
        Mesh = 2,
        Material = 3,
        Animation = 4,
        AnimationNode = 5,
        Skeleton3DNode = 6,
        Max = 7
    }

    private static readonly System.Type CachedType = typeof(EditorScenePostImportPlugin);

    private static readonly StringName NativeName = "EditorScenePostImportPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorScenePostImportPlugin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorScenePostImportPlugin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorScenePostImportPlugin(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Override to add general import options. These will appear in the main import dock on the editor. Add options via <see cref="Godot.EditorScenePostImportPlugin.AddImportOption(string, Variant)"/> and <see cref="Godot.EditorScenePostImportPlugin.AddImportOptionAdvanced(Variant.Type, string, Variant, PropertyHint, string, int)"/>.</para>
    /// </summary>
    public virtual void _GetImportOptions(string path)
    {
    }

    /// <summary>
    /// <para>Override to add internal import options. These will appear in the 3D scene import dialog. Add options via <see cref="Godot.EditorScenePostImportPlugin.AddImportOption(string, Variant)"/> and <see cref="Godot.EditorScenePostImportPlugin.AddImportOptionAdvanced(Variant.Type, string, Variant, PropertyHint, string, int)"/>.</para>
    /// </summary>
    public virtual void _GetInternalImportOptions(int category)
    {
    }

    /// <summary>
    /// <para>Should return <see langword="true"/> if the 3D view of the import dialog needs to update when changing the given option.</para>
    /// </summary>
    public virtual Variant _GetInternalOptionUpdateViewRequired(int category, string option)
    {
        return default;
    }

    /// <summary>
    /// <para>Should return <see langword="true"/> to show the given option, <see langword="false"/> to hide the given option, or <see langword="null"/> to ignore.</para>
    /// </summary>
    public virtual Variant _GetInternalOptionVisibility(int category, bool forAnimation, string option)
    {
        return default;
    }

    /// <summary>
    /// <para>Should return <see langword="true"/> to show the given option, <see langword="false"/> to hide the given option, or <see langword="null"/> to ignore.</para>
    /// </summary>
    public virtual Variant _GetOptionVisibility(string path, bool forAnimation, string option)
    {
        return default;
    }

    /// <summary>
    /// <para>Process a specific node or resource for a given category.</para>
    /// </summary>
    public virtual void _InternalProcess(int category, Node baseNode, Node node, Resource resource)
    {
    }

    /// <summary>
    /// <para>Post-process the scene. This function is called after the final scene has been configured.</para>
    /// </summary>
    public virtual void _PostProcess(Node scene)
    {
    }

    /// <summary>
    /// <para>Pre-process the scene. This function is called right after the scene format loader loaded the scene and no changes have been made.</para>
    /// <para>Pre-process may be used to adjust internal import options in the <c>"nodes"</c>, <c>"meshes"</c>, <c>"animations"</c> or <c>"materials"</c> keys inside <c>get_option_value("_subresources")</c>.</para>
    /// </summary>
    public virtual void _PreProcess(Node scene)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOptionValue, 2760726917ul);

    /// <summary>
    /// <para>Query the value of an option. This function can only be called from those querying visibility, or processing.</para>
    /// </summary>
    public Variant GetOptionValue(StringName name)
    {
        return NativeCalls.godot_icall_1_143(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddImportOption, 402577236ul);

    /// <summary>
    /// <para>Add a specific import option (name and default value only). This function can only be called from <see cref="Godot.EditorScenePostImportPlugin._GetImportOptions(string)"/> and <see cref="Godot.EditorScenePostImportPlugin._GetInternalImportOptions(int)"/>.</para>
    /// </summary>
    public void AddImportOption(string name, Variant value)
    {
        NativeCalls.godot_icall_2_528(MethodBind1, GodotObject.GetPtr(this), name, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddImportOptionAdvanced, 3674075649ul);

    /// <summary>
    /// <para>Add a specific import option. This function can only be called from <see cref="Godot.EditorScenePostImportPlugin._GetImportOptions(string)"/> and <see cref="Godot.EditorScenePostImportPlugin._GetInternalImportOptions(int)"/>.</para>
    /// </summary>
    public void AddImportOptionAdvanced(Variant.Type type, string name, Variant defaultValue, PropertyHint hint = (PropertyHint)(0), string hintString = "", int usageFlags = 6)
    {
        EditorNativeCalls.godot_icall_6_529(MethodBind2, GodotObject.GetPtr(this), (int)type, name, defaultValue, (int)hint, hintString, usageFlags);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_import_options = "_GetImportOptions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_internal_import_options = "_GetInternalImportOptions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_internal_option_update_view_required = "_GetInternalOptionUpdateViewRequired";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_internal_option_visibility = "_GetInternalOptionVisibility";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_option_visibility = "_GetOptionVisibility";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__internal_process = "_InternalProcess";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__post_process = "_PostProcess";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pre_process = "_PreProcess";

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
        if ((method == MethodProxyName__get_import_options || method == MethodName._GetImportOptions) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_import_options.NativeValue))
        {
            _GetImportOptions(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_internal_import_options || method == MethodName._GetInternalImportOptions) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_internal_import_options.NativeValue))
        {
            _GetInternalImportOptions(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_internal_option_update_view_required || method == MethodName._GetInternalOptionUpdateViewRequired) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_internal_option_update_view_required.NativeValue))
        {
            var callRet = _GetInternalOptionUpdateViewRequired(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_internal_option_visibility || method == MethodName._GetInternalOptionVisibility) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_internal_option_visibility.NativeValue))
        {
            var callRet = _GetInternalOptionVisibility(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<string>(args[2]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_option_visibility || method == MethodName._GetOptionVisibility) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_option_visibility.NativeValue))
        {
            var callRet = _GetOptionVisibility(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<string>(args[2]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__internal_process || method == MethodName._InternalProcess) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__internal_process.NativeValue))
        {
            _InternalProcess(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<Node>(args[1]), VariantUtils.ConvertTo<Node>(args[2]), VariantUtils.ConvertTo<Resource>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__post_process || method == MethodName._PostProcess) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__post_process.NativeValue))
        {
            _PostProcess(VariantUtils.ConvertTo<Node>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__pre_process || method == MethodName._PreProcess) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__pre_process.NativeValue))
        {
            _PreProcess(VariantUtils.ConvertTo<Node>(args[0]));
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
        if (method == MethodName._GetImportOptions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_import_options.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetInternalImportOptions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_internal_import_options.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetInternalOptionUpdateViewRequired)
        {
            if (HasGodotClassMethod(MethodProxyName__get_internal_option_update_view_required.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetInternalOptionVisibility)
        {
            if (HasGodotClassMethod(MethodProxyName__get_internal_option_visibility.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOptionVisibility)
        {
            if (HasGodotClassMethod(MethodProxyName__get_option_visibility.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._InternalProcess)
        {
            if (HasGodotClassMethod(MethodProxyName__internal_process.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PostProcess)
        {
            if (HasGodotClassMethod(MethodProxyName__post_process.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PreProcess)
        {
            if (HasGodotClassMethod(MethodProxyName__pre_process.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_get_import_options' method.
        /// </summary>
        public static readonly StringName _GetImportOptions = "_get_import_options";
        /// <summary>
        /// Cached name for the '_get_internal_import_options' method.
        /// </summary>
        public static readonly StringName _GetInternalImportOptions = "_get_internal_import_options";
        /// <summary>
        /// Cached name for the '_get_internal_option_update_view_required' method.
        /// </summary>
        public static readonly StringName _GetInternalOptionUpdateViewRequired = "_get_internal_option_update_view_required";
        /// <summary>
        /// Cached name for the '_get_internal_option_visibility' method.
        /// </summary>
        public static readonly StringName _GetInternalOptionVisibility = "_get_internal_option_visibility";
        /// <summary>
        /// Cached name for the '_get_option_visibility' method.
        /// </summary>
        public static readonly StringName _GetOptionVisibility = "_get_option_visibility";
        /// <summary>
        /// Cached name for the '_internal_process' method.
        /// </summary>
        public static readonly StringName _InternalProcess = "_internal_process";
        /// <summary>
        /// Cached name for the '_post_process' method.
        /// </summary>
        public static readonly StringName _PostProcess = "_post_process";
        /// <summary>
        /// Cached name for the '_pre_process' method.
        /// </summary>
        public static readonly StringName _PreProcess = "_pre_process";
        /// <summary>
        /// Cached name for the 'get_option_value' method.
        /// </summary>
        public static readonly StringName GetOptionValue = "get_option_value";
        /// <summary>
        /// Cached name for the 'add_import_option' method.
        /// </summary>
        public static readonly StringName AddImportOption = "add_import_option";
        /// <summary>
        /// Cached name for the 'add_import_option_advanced' method.
        /// </summary>
        public static readonly StringName AddImportOptionAdvanced = "add_import_option_advanced";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
