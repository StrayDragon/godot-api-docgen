namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
public partial class ScriptExtension : Script
{
    private static readonly System.Type CachedType = typeof(ScriptExtension);

    private static readonly StringName NativeName = "ScriptExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ScriptExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ScriptExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ScriptExtension(bool memoryOwn) : base(memoryOwn) { }

    public virtual bool _CanInstantiate()
    {
        return default;
    }

    public virtual bool _EditorCanReloadFromFile()
    {
        return default;
    }

    public virtual Script _GetBaseScript()
    {
        return default;
    }

    public virtual string _GetClassIconPath()
    {
        return default;
    }

    public virtual Godot.Collections.Dictionary _GetConstants()
    {
        return default;
    }

    public virtual StringName _GetDocClassName()
    {
        return default;
    }

    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetDocumentation()
    {
        return default;
    }

    public virtual StringName _GetGlobalName()
    {
        return default;
    }

    public virtual StringName _GetInstanceBaseType()
    {
        return default;
    }

    public virtual ScriptLanguage _GetLanguage()
    {
        return default;
    }

    public virtual int _GetMemberLine(StringName member)
    {
        return default;
    }

    public virtual Godot.Collections.Array<StringName> _GetMembers()
    {
        return default;
    }

    public virtual Godot.Collections.Dictionary _GetMethodInfo(StringName method)
    {
        return default;
    }

    public virtual Variant _GetPropertyDefaultValue(StringName property)
    {
        return default;
    }

    public virtual Variant _GetRpcConfig()
    {
        return default;
    }

    /// <summary>
    /// <para>Return the expected argument count for the given <paramref name="method"/>, or <see langword="null"/> if it can't be determined (which will then fall back to the default behavior).</para>
    /// </summary>
    public virtual Variant _GetScriptMethodArgumentCount(StringName method)
    {
        return default;
    }

    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetScriptMethodList()
    {
        return default;
    }

    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetScriptPropertyList()
    {
        return default;
    }

    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetScriptSignalList()
    {
        return default;
    }

    public virtual string _GetSourceCode()
    {
        return default;
    }

    public virtual bool _HasMethod(StringName method)
    {
        return default;
    }

    public virtual bool _HasPropertyDefaultValue(StringName property)
    {
        return default;
    }

    public virtual bool _HasScriptSignal(StringName signal)
    {
        return default;
    }

    public virtual bool _HasSourceCode()
    {
        return default;
    }

    public virtual bool _HasStaticMethod(StringName method)
    {
        return default;
    }

    public virtual bool _InheritsScript(Script script)
    {
        return default;
    }

    public virtual bool _InstanceHas(GodotObject @object)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if the script is an abstract script. Abstract scripts cannot be instantiated directly, instead other scripts should inherit them. Abstract scripts will be either unselectable or hidden in the Create New Node dialog (unselectable if there are non-abstract classes inheriting it, otherwise hidden).</para>
    /// </summary>
    public virtual bool _IsAbstract()
    {
        return default;
    }

    public virtual bool _IsPlaceholderFallbackEnabled()
    {
        return default;
    }

    public virtual bool _IsTool()
    {
        return default;
    }

    public virtual bool _IsValid()
    {
        return default;
    }

    public virtual Error _Reload(bool keepState)
    {
        return default;
    }

    public virtual void _SetSourceCode(string code)
    {
    }

    public virtual void _UpdateExports()
    {
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__can_instantiate = "_CanInstantiate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__editor_can_reload_from_file = "_EditorCanReloadFromFile";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_base_script = "_GetBaseScript";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_class_icon_path = "_GetClassIconPath";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_constants = "_GetConstants";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_doc_class_name = "_GetDocClassName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_documentation = "_GetDocumentation";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_global_name = "_GetGlobalName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_instance_base_type = "_GetInstanceBaseType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_language = "_GetLanguage";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_member_line = "_GetMemberLine";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_members = "_GetMembers";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_method_info = "_GetMethodInfo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_property_default_value = "_GetPropertyDefaultValue";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_rpc_config = "_GetRpcConfig";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_script_method_argument_count = "_GetScriptMethodArgumentCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_script_method_list = "_GetScriptMethodList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_script_property_list = "_GetScriptPropertyList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_script_signal_list = "_GetScriptSignalList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_source_code = "_GetSourceCode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_method = "_HasMethod";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_property_default_value = "_HasPropertyDefaultValue";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_script_signal = "_HasScriptSignal";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_source_code = "_HasSourceCode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_static_method = "_HasStaticMethod";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__inherits_script = "_InheritsScript";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__instance_has = "_InstanceHas";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_abstract = "_IsAbstract";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_placeholder_fallback_enabled = "_IsPlaceholderFallbackEnabled";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_tool = "_IsTool";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_valid = "_IsValid";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__reload = "_Reload";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_source_code = "_SetSourceCode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__update_exports = "_UpdateExports";

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
        if ((method == MethodProxyName__can_instantiate || method == MethodName._CanInstantiate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__can_instantiate.NativeValue))
        {
            var callRet = _CanInstantiate();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__editor_can_reload_from_file || method == MethodName._EditorCanReloadFromFile) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__editor_can_reload_from_file.NativeValue))
        {
            var callRet = _EditorCanReloadFromFile();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_base_script || method == MethodName._GetBaseScript) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_base_script.NativeValue))
        {
            var callRet = _GetBaseScript();
            ret = VariantUtils.CreateFrom<Script>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_class_icon_path || method == MethodName._GetClassIconPath) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_class_icon_path.NativeValue))
        {
            var callRet = _GetClassIconPath();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_constants || method == MethodName._GetConstants) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_constants.NativeValue))
        {
            var callRet = _GetConstants();
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_doc_class_name || method == MethodName._GetDocClassName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_doc_class_name.NativeValue))
        {
            var callRet = _GetDocClassName();
            ret = VariantUtils.CreateFrom<StringName>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_documentation || method == MethodName._GetDocumentation) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_documentation.NativeValue))
        {
            var callRet = _GetDocumentation();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_global_name || method == MethodName._GetGlobalName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_global_name.NativeValue))
        {
            var callRet = _GetGlobalName();
            ret = VariantUtils.CreateFrom<StringName>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_instance_base_type || method == MethodName._GetInstanceBaseType) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_instance_base_type.NativeValue))
        {
            var callRet = _GetInstanceBaseType();
            ret = VariantUtils.CreateFrom<StringName>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_language || method == MethodName._GetLanguage) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_language.NativeValue))
        {
            var callRet = _GetLanguage();
            ret = VariantUtils.CreateFrom<ScriptLanguage>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_member_line || method == MethodName._GetMemberLine) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_member_line.NativeValue))
        {
            var callRet = _GetMemberLine(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_members || method == MethodName._GetMembers) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_members.NativeValue))
        {
            var callRet = _GetMembers();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_method_info || method == MethodName._GetMethodInfo) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_method_info.NativeValue))
        {
            var callRet = _GetMethodInfo(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_property_default_value || method == MethodName._GetPropertyDefaultValue) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_property_default_value.NativeValue))
        {
            var callRet = _GetPropertyDefaultValue(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_rpc_config || method == MethodName._GetRpcConfig) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_rpc_config.NativeValue))
        {
            var callRet = _GetRpcConfig();
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_script_method_argument_count || method == MethodName._GetScriptMethodArgumentCount) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_script_method_argument_count.NativeValue))
        {
            var callRet = _GetScriptMethodArgumentCount(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_script_method_list || method == MethodName._GetScriptMethodList) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_script_method_list.NativeValue))
        {
            var callRet = _GetScriptMethodList();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_script_property_list || method == MethodName._GetScriptPropertyList) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_script_property_list.NativeValue))
        {
            var callRet = _GetScriptPropertyList();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_script_signal_list || method == MethodName._GetScriptSignalList) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_script_signal_list.NativeValue))
        {
            var callRet = _GetScriptSignalList();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_source_code || method == MethodName._GetSourceCode) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_source_code.NativeValue))
        {
            var callRet = _GetSourceCode();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_method || method == MethodName._HasMethod) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_method.NativeValue))
        {
            var callRet = _HasMethod(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_property_default_value || method == MethodName._HasPropertyDefaultValue) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_property_default_value.NativeValue))
        {
            var callRet = _HasPropertyDefaultValue(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_script_signal || method == MethodName._HasScriptSignal) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_script_signal.NativeValue))
        {
            var callRet = _HasScriptSignal(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_source_code || method == MethodName._HasSourceCode) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_source_code.NativeValue))
        {
            var callRet = _HasSourceCode();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_static_method || method == MethodName._HasStaticMethod) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_static_method.NativeValue))
        {
            var callRet = _HasStaticMethod(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__inherits_script || method == MethodName._InheritsScript) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__inherits_script.NativeValue))
        {
            var callRet = _InheritsScript(VariantUtils.ConvertTo<Script>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__instance_has || method == MethodName._InstanceHas) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__instance_has.NativeValue))
        {
            var callRet = _InstanceHas(VariantUtils.ConvertTo<GodotObject>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_abstract || method == MethodName._IsAbstract) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_abstract.NativeValue))
        {
            var callRet = _IsAbstract();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_placeholder_fallback_enabled || method == MethodName._IsPlaceholderFallbackEnabled) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_placeholder_fallback_enabled.NativeValue))
        {
            var callRet = _IsPlaceholderFallbackEnabled();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_tool || method == MethodName._IsTool) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_tool.NativeValue))
        {
            var callRet = _IsTool();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_valid || method == MethodName._IsValid) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_valid.NativeValue))
        {
            var callRet = _IsValid();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__reload || method == MethodName._Reload) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__reload.NativeValue))
        {
            var callRet = _Reload(VariantUtils.ConvertTo<bool>(args[0]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set_source_code || method == MethodName._SetSourceCode) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_source_code.NativeValue))
        {
            _SetSourceCode(VariantUtils.ConvertTo<string>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__update_exports || method == MethodName._UpdateExports) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__update_exports.NativeValue))
        {
            _UpdateExports();
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
        if (method == MethodName._CanInstantiate)
        {
            if (HasGodotClassMethod(MethodProxyName__can_instantiate.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._EditorCanReloadFromFile)
        {
            if (HasGodotClassMethod(MethodProxyName__editor_can_reload_from_file.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetBaseScript)
        {
            if (HasGodotClassMethod(MethodProxyName__get_base_script.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetClassIconPath)
        {
            if (HasGodotClassMethod(MethodProxyName__get_class_icon_path.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetConstants)
        {
            if (HasGodotClassMethod(MethodProxyName__get_constants.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDocClassName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_doc_class_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDocumentation)
        {
            if (HasGodotClassMethod(MethodProxyName__get_documentation.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetGlobalName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_global_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetInstanceBaseType)
        {
            if (HasGodotClassMethod(MethodProxyName__get_instance_base_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetLanguage)
        {
            if (HasGodotClassMethod(MethodProxyName__get_language.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetMemberLine)
        {
            if (HasGodotClassMethod(MethodProxyName__get_member_line.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetMembers)
        {
            if (HasGodotClassMethod(MethodProxyName__get_members.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetMethodInfo)
        {
            if (HasGodotClassMethod(MethodProxyName__get_method_info.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPropertyDefaultValue)
        {
            if (HasGodotClassMethod(MethodProxyName__get_property_default_value.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetRpcConfig)
        {
            if (HasGodotClassMethod(MethodProxyName__get_rpc_config.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetScriptMethodArgumentCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_script_method_argument_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetScriptMethodList)
        {
            if (HasGodotClassMethod(MethodProxyName__get_script_method_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetScriptPropertyList)
        {
            if (HasGodotClassMethod(MethodProxyName__get_script_property_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetScriptSignalList)
        {
            if (HasGodotClassMethod(MethodProxyName__get_script_signal_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSourceCode)
        {
            if (HasGodotClassMethod(MethodProxyName__get_source_code.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasMethod)
        {
            if (HasGodotClassMethod(MethodProxyName__has_method.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasPropertyDefaultValue)
        {
            if (HasGodotClassMethod(MethodProxyName__has_property_default_value.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasScriptSignal)
        {
            if (HasGodotClassMethod(MethodProxyName__has_script_signal.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasSourceCode)
        {
            if (HasGodotClassMethod(MethodProxyName__has_source_code.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasStaticMethod)
        {
            if (HasGodotClassMethod(MethodProxyName__has_static_method.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._InheritsScript)
        {
            if (HasGodotClassMethod(MethodProxyName__inherits_script.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._InstanceHas)
        {
            if (HasGodotClassMethod(MethodProxyName__instance_has.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsAbstract)
        {
            if (HasGodotClassMethod(MethodProxyName__is_abstract.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsPlaceholderFallbackEnabled)
        {
            if (HasGodotClassMethod(MethodProxyName__is_placeholder_fallback_enabled.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsTool)
        {
            if (HasGodotClassMethod(MethodProxyName__is_tool.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsValid)
        {
            if (HasGodotClassMethod(MethodProxyName__is_valid.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Reload)
        {
            if (HasGodotClassMethod(MethodProxyName__reload.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetSourceCode)
        {
            if (HasGodotClassMethod(MethodProxyName__set_source_code.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._UpdateExports)
        {
            if (HasGodotClassMethod(MethodProxyName__update_exports.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : Script.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Script.MethodName
    {
        /// <summary>
        /// Cached name for the '_can_instantiate' method.
        /// </summary>
        public static readonly StringName _CanInstantiate = "_can_instantiate";
        /// <summary>
        /// Cached name for the '_editor_can_reload_from_file' method.
        /// </summary>
        public static readonly StringName _EditorCanReloadFromFile = "_editor_can_reload_from_file";
        /// <summary>
        /// Cached name for the '_get_base_script' method.
        /// </summary>
        public static readonly StringName _GetBaseScript = "_get_base_script";
        /// <summary>
        /// Cached name for the '_get_class_icon_path' method.
        /// </summary>
        public static readonly StringName _GetClassIconPath = "_get_class_icon_path";
        /// <summary>
        /// Cached name for the '_get_constants' method.
        /// </summary>
        public static readonly StringName _GetConstants = "_get_constants";
        /// <summary>
        /// Cached name for the '_get_doc_class_name' method.
        /// </summary>
        public static readonly StringName _GetDocClassName = "_get_doc_class_name";
        /// <summary>
        /// Cached name for the '_get_documentation' method.
        /// </summary>
        public static readonly StringName _GetDocumentation = "_get_documentation";
        /// <summary>
        /// Cached name for the '_get_global_name' method.
        /// </summary>
        public static readonly StringName _GetGlobalName = "_get_global_name";
        /// <summary>
        /// Cached name for the '_get_instance_base_type' method.
        /// </summary>
        public static readonly StringName _GetInstanceBaseType = "_get_instance_base_type";
        /// <summary>
        /// Cached name for the '_get_language' method.
        /// </summary>
        public static readonly StringName _GetLanguage = "_get_language";
        /// <summary>
        /// Cached name for the '_get_member_line' method.
        /// </summary>
        public static readonly StringName _GetMemberLine = "_get_member_line";
        /// <summary>
        /// Cached name for the '_get_members' method.
        /// </summary>
        public static readonly StringName _GetMembers = "_get_members";
        /// <summary>
        /// Cached name for the '_get_method_info' method.
        /// </summary>
        public static readonly StringName _GetMethodInfo = "_get_method_info";
        /// <summary>
        /// Cached name for the '_get_property_default_value' method.
        /// </summary>
        public static readonly StringName _GetPropertyDefaultValue = "_get_property_default_value";
        /// <summary>
        /// Cached name for the '_get_rpc_config' method.
        /// </summary>
        public static readonly StringName _GetRpcConfig = "_get_rpc_config";
        /// <summary>
        /// Cached name for the '_get_script_method_argument_count' method.
        /// </summary>
        public static readonly StringName _GetScriptMethodArgumentCount = "_get_script_method_argument_count";
        /// <summary>
        /// Cached name for the '_get_script_method_list' method.
        /// </summary>
        public static readonly StringName _GetScriptMethodList = "_get_script_method_list";
        /// <summary>
        /// Cached name for the '_get_script_property_list' method.
        /// </summary>
        public static readonly StringName _GetScriptPropertyList = "_get_script_property_list";
        /// <summary>
        /// Cached name for the '_get_script_signal_list' method.
        /// </summary>
        public static readonly StringName _GetScriptSignalList = "_get_script_signal_list";
        /// <summary>
        /// Cached name for the '_get_source_code' method.
        /// </summary>
        public static readonly StringName _GetSourceCode = "_get_source_code";
        /// <summary>
        /// Cached name for the '_has_method' method.
        /// </summary>
        public static readonly StringName _HasMethod = "_has_method";
        /// <summary>
        /// Cached name for the '_has_property_default_value' method.
        /// </summary>
        public static readonly StringName _HasPropertyDefaultValue = "_has_property_default_value";
        /// <summary>
        /// Cached name for the '_has_script_signal' method.
        /// </summary>
        public static readonly StringName _HasScriptSignal = "_has_script_signal";
        /// <summary>
        /// Cached name for the '_has_source_code' method.
        /// </summary>
        public static readonly StringName _HasSourceCode = "_has_source_code";
        /// <summary>
        /// Cached name for the '_has_static_method' method.
        /// </summary>
        public static readonly StringName _HasStaticMethod = "_has_static_method";
        /// <summary>
        /// Cached name for the '_inherits_script' method.
        /// </summary>
        public static readonly StringName _InheritsScript = "_inherits_script";
        /// <summary>
        /// Cached name for the '_instance_has' method.
        /// </summary>
        public static readonly StringName _InstanceHas = "_instance_has";
        /// <summary>
        /// Cached name for the '_is_abstract' method.
        /// </summary>
        public static readonly StringName _IsAbstract = "_is_abstract";
        /// <summary>
        /// Cached name for the '_is_placeholder_fallback_enabled' method.
        /// </summary>
        public static readonly StringName _IsPlaceholderFallbackEnabled = "_is_placeholder_fallback_enabled";
        /// <summary>
        /// Cached name for the '_is_tool' method.
        /// </summary>
        public static readonly StringName _IsTool = "_is_tool";
        /// <summary>
        /// Cached name for the '_is_valid' method.
        /// </summary>
        public static readonly StringName _IsValid = "_is_valid";
        /// <summary>
        /// Cached name for the '_reload' method.
        /// </summary>
        public static readonly StringName _Reload = "_reload";
        /// <summary>
        /// Cached name for the '_set_source_code' method.
        /// </summary>
        public static readonly StringName _SetSourceCode = "_set_source_code";
        /// <summary>
        /// Cached name for the '_update_exports' method.
        /// </summary>
        public static readonly StringName _UpdateExports = "_update_exports";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Script.SignalName
    {
    }
}
