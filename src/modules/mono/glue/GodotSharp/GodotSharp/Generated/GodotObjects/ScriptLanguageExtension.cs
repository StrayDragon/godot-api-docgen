namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
public partial class ScriptLanguageExtension : ScriptLanguage
{
    public enum LookupResultType : long
    {
        ScriptLocation = 0,
        Class = 1,
        ClassConstant = 2,
        ClassProperty = 3,
        ClassMethod = 4,
        ClassSignal = 5,
        ClassEnum = 6,
        [Obsolete("This enum member is deprecated.")]
        ClassTbdGlobalscope = 7,
        ClassAnnotation = 8,
        LocalConstant = 9,
        LocalVariable = 10,
        Max = 11
    }

    public enum CodeCompletionLocation : long
    {
        /// <summary>
        /// <para>The option is local to the location of the code completion query - e.g. a local variable. Subsequent value of location represent options from the outer class, the exact value represent how far they are (in terms of inner classes).</para>
        /// </summary>
        Local = 0,
        /// <summary>
        /// <para>The option is from the containing class or a parent class, relative to the location of the code completion query. Perform a bitwise OR with the class depth (e.g. <c>0</c> for the local class, <c>1</c> for the parent, <c>2</c> for the grandparent, etc.) to store the depth of an option in the class or a parent class.</para>
        /// </summary>
        ParentMask = 256,
        /// <summary>
        /// <para>The option is from user code which is not local and not in a derived class (e.g. Autoload Singletons).</para>
        /// </summary>
        OtherUserCode = 512,
        /// <summary>
        /// <para>The option is from other engine code, not covered by the other enum constants - e.g. built-in classes.</para>
        /// </summary>
        Other = 1024
    }

    public enum CodeCompletionKind : long
    {
        Class = 0,
        Function = 1,
        Signal = 2,
        Variable = 3,
        Member = 4,
        Enum = 5,
        Constant = 6,
        NodePath = 7,
        FilePath = 8,
        PlainText = 9,
        Max = 10
    }

    private static readonly System.Type CachedType = typeof(ScriptLanguageExtension);

    private static readonly StringName NativeName = "ScriptLanguageExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ScriptLanguageExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ScriptLanguageExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ScriptLanguageExtension(bool memoryOwn) : base(memoryOwn) { }

    public virtual void _AddGlobalConstant(StringName name, Variant value)
    {
    }

    public virtual void _AddNamedGlobalConstant(StringName name, Variant value)
    {
    }

    public virtual string _AutoIndentCode(string code, int fromLine, int toLine)
    {
        return default;
    }

    public virtual bool _CanInheritFromFile()
    {
        return default;
    }

    public virtual bool _CanMakeFunction()
    {
        return default;
    }

    public virtual Godot.Collections.Dictionary _CompleteCode(string code, string path, GodotObject owner)
    {
        return default;
    }

    public virtual GodotObject _CreateScript()
    {
        return default;
    }

    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _DebugGetCurrentStackInfo()
    {
        return default;
    }

    public virtual string _DebugGetError()
    {
        return default;
    }

    public virtual Godot.Collections.Dictionary _DebugGetGlobals(int maxSubitems, int maxDepth)
    {
        return default;
    }

    public virtual int _DebugGetStackLevelCount()
    {
        return default;
    }

    public virtual string _DebugGetStackLevelFunction(int level)
    {
        return default;
    }

    public virtual int _DebugGetStackLevelLine(int level)
    {
        return default;
    }

    public virtual Godot.Collections.Dictionary _DebugGetStackLevelLocals(int level, int maxSubitems, int maxDepth)
    {
        return default;
    }

    public virtual Godot.Collections.Dictionary _DebugGetStackLevelMembers(int level, int maxSubitems, int maxDepth)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the source associated with a given debug stack position.</para>
    /// </summary>
    public virtual string _DebugGetStackLevelSource(int level)
    {
        return default;
    }

    public virtual string _DebugParseStackLevelExpression(int level, string expression, int maxSubitems, int maxDepth)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the line where the function is defined in the code, or <c>-1</c> if the function is not present.</para>
    /// </summary>
    public virtual int _FindFunction(string function, string code)
    {
        return default;
    }

    public virtual void _Finish()
    {
    }

    public virtual void _Frame()
    {
    }

    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetBuiltInTemplates(StringName @object)
    {
        return default;
    }

    public virtual string[] _GetCommentDelimiters()
    {
        return default;
    }

    public virtual string[] _GetDocCommentDelimiters()
    {
        return default;
    }

    public virtual string _GetExtension()
    {
        return default;
    }

    public virtual Godot.Collections.Dictionary _GetGlobalClassName(string path)
    {
        return default;
    }

    public virtual string _GetName()
    {
        return default;
    }

    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetPublicAnnotations()
    {
        return default;
    }

    public virtual Godot.Collections.Dictionary _GetPublicConstants()
    {
        return default;
    }

    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetPublicFunctions()
    {
        return default;
    }

    public virtual string[] _GetRecognizedExtensions()
    {
        return default;
    }

    public virtual string[] _GetReservedWords()
    {
        return default;
    }

    public virtual string[] _GetStringDelimiters()
    {
        return default;
    }

    public virtual string _GetType()
    {
        return default;
    }

    public virtual bool _HandlesGlobalClassType(string type)
    {
        return default;
    }

    [Obsolete("This method is not called by the engine.")]
    public virtual bool _HasNamedClasses()
    {
        return default;
    }

    public virtual void _Init()
    {
    }

    public virtual bool _IsControlFlowKeyword(string keyword)
    {
        return default;
    }

    public virtual bool _IsUsingTemplates()
    {
        return default;
    }

    public virtual Godot.Collections.Dictionary _LookupCode(string code, string symbol, string path, GodotObject owner)
    {
        return default;
    }

    public virtual string _MakeFunction(string className, string functionName, string[] functionArgs)
    {
        return default;
    }

    public virtual Script _MakeTemplate(string template, string className, string baseClassName)
    {
        return default;
    }

    public virtual Error _OpenInExternalEditor(Script script, int line, int column)
    {
        return default;
    }

    public virtual bool _OverridesExternalEditor()
    {
        return default;
    }

    public virtual ScriptLanguage.ScriptNameCasing _PreferredFileNameCasing()
    {
        return default;
    }

    public virtual void _ProfilingSetSaveNativeCalls(bool enable)
    {
    }

    public virtual void _ProfilingStart()
    {
    }

    public virtual void _ProfilingStop()
    {
    }

    public virtual void _ReloadAllScripts()
    {
    }

    public virtual void _ReloadScripts(Godot.Collections.Array scripts, bool softReload)
    {
    }

    public virtual void _ReloadToolScript(Script script, bool softReload)
    {
    }

    public virtual void _RemoveNamedGlobalConstant(StringName name)
    {
    }

    public virtual bool _SupportsBuiltinMode()
    {
        return default;
    }

    public virtual bool _SupportsDocumentation()
    {
        return default;
    }

    public virtual void _ThreadEnter()
    {
    }

    public virtual void _ThreadExit()
    {
    }

    public virtual Godot.Collections.Dictionary _Validate(string script, string path, bool validateFunctions, bool validateErrors, bool validateWarnings, bool validateSafeLines)
    {
        return default;
    }

    public virtual string _ValidatePath(string path)
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__add_global_constant = "_AddGlobalConstant";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__add_named_global_constant = "_AddNamedGlobalConstant";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__auto_indent_code = "_AutoIndentCode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__can_inherit_from_file = "_CanInheritFromFile";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__can_make_function = "_CanMakeFunction";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__complete_code = "_CompleteCode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create_script = "_CreateScript";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__debug_get_current_stack_info = "_DebugGetCurrentStackInfo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__debug_get_error = "_DebugGetError";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__debug_get_globals = "_DebugGetGlobals";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__debug_get_stack_level_count = "_DebugGetStackLevelCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__debug_get_stack_level_function = "_DebugGetStackLevelFunction";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__debug_get_stack_level_line = "_DebugGetStackLevelLine";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__debug_get_stack_level_locals = "_DebugGetStackLevelLocals";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__debug_get_stack_level_members = "_DebugGetStackLevelMembers";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__debug_get_stack_level_source = "_DebugGetStackLevelSource";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__debug_parse_stack_level_expression = "_DebugParseStackLevelExpression";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__find_function = "_FindFunction";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__finish = "_Finish";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__frame = "_Frame";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_built_in_templates = "_GetBuiltInTemplates";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_comment_delimiters = "_GetCommentDelimiters";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_doc_comment_delimiters = "_GetDocCommentDelimiters";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_extension = "_GetExtension";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_global_class_name = "_GetGlobalClassName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_name = "_GetName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_public_annotations = "_GetPublicAnnotations";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_public_constants = "_GetPublicConstants";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_public_functions = "_GetPublicFunctions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_recognized_extensions = "_GetRecognizedExtensions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_reserved_words = "_GetReservedWords";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_string_delimiters = "_GetStringDelimiters";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_type = "_GetType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__handles_global_class_type = "_HandlesGlobalClassType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_named_classes = "_HasNamedClasses";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__init = "_Init";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_control_flow_keyword = "_IsControlFlowKeyword";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_using_templates = "_IsUsingTemplates";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__lookup_code = "_LookupCode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__make_function = "_MakeFunction";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__make_template = "_MakeTemplate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__open_in_external_editor = "_OpenInExternalEditor";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__overrides_external_editor = "_OverridesExternalEditor";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__preferred_file_name_casing = "_PreferredFileNameCasing";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__profiling_set_save_native_calls = "_ProfilingSetSaveNativeCalls";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__profiling_start = "_ProfilingStart";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__profiling_stop = "_ProfilingStop";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__reload_all_scripts = "_ReloadAllScripts";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__reload_scripts = "_ReloadScripts";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__reload_tool_script = "_ReloadToolScript";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__remove_named_global_constant = "_RemoveNamedGlobalConstant";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__supports_builtin_mode = "_SupportsBuiltinMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__supports_documentation = "_SupportsDocumentation";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__thread_enter = "_ThreadEnter";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__thread_exit = "_ThreadExit";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__validate = "_Validate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__validate_path = "_ValidatePath";

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
        if ((method == MethodProxyName__add_global_constant || method == MethodName._AddGlobalConstant) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__add_global_constant.NativeValue))
        {
            _AddGlobalConstant(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__add_named_global_constant || method == MethodName._AddNamedGlobalConstant) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__add_named_global_constant.NativeValue))
        {
            _AddNamedGlobalConstant(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__auto_indent_code || method == MethodName._AutoIndentCode) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__auto_indent_code.NativeValue))
        {
            var callRet = _AutoIndentCode(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<int>(args[2]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__can_inherit_from_file || method == MethodName._CanInheritFromFile) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__can_inherit_from_file.NativeValue))
        {
            var callRet = _CanInheritFromFile();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__can_make_function || method == MethodName._CanMakeFunction) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__can_make_function.NativeValue))
        {
            var callRet = _CanMakeFunction();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__complete_code || method == MethodName._CompleteCode) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__complete_code.NativeValue))
        {
            var callRet = _CompleteCode(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<GodotObject>(args[2]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__create_script || method == MethodName._CreateScript) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__create_script.NativeValue))
        {
            var callRet = _CreateScript();
            ret = VariantUtils.CreateFrom<GodotObject>(callRet);
            return true;
        }
        if ((method == MethodProxyName__debug_get_current_stack_info || method == MethodName._DebugGetCurrentStackInfo) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__debug_get_current_stack_info.NativeValue))
        {
            var callRet = _DebugGetCurrentStackInfo();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__debug_get_error || method == MethodName._DebugGetError) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__debug_get_error.NativeValue))
        {
            var callRet = _DebugGetError();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__debug_get_globals || method == MethodName._DebugGetGlobals) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__debug_get_globals.NativeValue))
        {
            var callRet = _DebugGetGlobals(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__debug_get_stack_level_count || method == MethodName._DebugGetStackLevelCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__debug_get_stack_level_count.NativeValue))
        {
            var callRet = _DebugGetStackLevelCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__debug_get_stack_level_function || method == MethodName._DebugGetStackLevelFunction) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__debug_get_stack_level_function.NativeValue))
        {
            var callRet = _DebugGetStackLevelFunction(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__debug_get_stack_level_line || method == MethodName._DebugGetStackLevelLine) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__debug_get_stack_level_line.NativeValue))
        {
            var callRet = _DebugGetStackLevelLine(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__debug_get_stack_level_locals || method == MethodName._DebugGetStackLevelLocals) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__debug_get_stack_level_locals.NativeValue))
        {
            var callRet = _DebugGetStackLevelLocals(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<int>(args[2]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__debug_get_stack_level_members || method == MethodName._DebugGetStackLevelMembers) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__debug_get_stack_level_members.NativeValue))
        {
            var callRet = _DebugGetStackLevelMembers(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<int>(args[2]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__debug_get_stack_level_source || method == MethodName._DebugGetStackLevelSource) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__debug_get_stack_level_source.NativeValue))
        {
            var callRet = _DebugGetStackLevelSource(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__debug_parse_stack_level_expression || method == MethodName._DebugParseStackLevelExpression) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__debug_parse_stack_level_expression.NativeValue))
        {
            var callRet = _DebugParseStackLevelExpression(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<int>(args[2]), VariantUtils.ConvertTo<int>(args[3]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__find_function || method == MethodName._FindFunction) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__find_function.NativeValue))
        {
            var callRet = _FindFunction(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__finish || method == MethodName._Finish) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__finish.NativeValue))
        {
            _Finish();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__frame || method == MethodName._Frame) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__frame.NativeValue))
        {
            _Frame();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_built_in_templates || method == MethodName._GetBuiltInTemplates) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_built_in_templates.NativeValue))
        {
            var callRet = _GetBuiltInTemplates(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_comment_delimiters || method == MethodName._GetCommentDelimiters) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_comment_delimiters.NativeValue))
        {
            var callRet = _GetCommentDelimiters();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_doc_comment_delimiters || method == MethodName._GetDocCommentDelimiters) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_doc_comment_delimiters.NativeValue))
        {
            var callRet = _GetDocCommentDelimiters();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_extension || method == MethodName._GetExtension) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_extension.NativeValue))
        {
            var callRet = _GetExtension();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_global_class_name || method == MethodName._GetGlobalClassName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_global_class_name.NativeValue))
        {
            var callRet = _GetGlobalClassName(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_name || method == MethodName._GetName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_name.NativeValue))
        {
            var callRet = _GetName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_public_annotations || method == MethodName._GetPublicAnnotations) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_public_annotations.NativeValue))
        {
            var callRet = _GetPublicAnnotations();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_public_constants || method == MethodName._GetPublicConstants) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_public_constants.NativeValue))
        {
            var callRet = _GetPublicConstants();
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_public_functions || method == MethodName._GetPublicFunctions) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_public_functions.NativeValue))
        {
            var callRet = _GetPublicFunctions();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_recognized_extensions || method == MethodName._GetRecognizedExtensions) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_recognized_extensions.NativeValue))
        {
            var callRet = _GetRecognizedExtensions();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_reserved_words || method == MethodName._GetReservedWords) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_reserved_words.NativeValue))
        {
            var callRet = _GetReservedWords();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_string_delimiters || method == MethodName._GetStringDelimiters) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_string_delimiters.NativeValue))
        {
            var callRet = _GetStringDelimiters();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_type || method == MethodName._GetType) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_type.NativeValue))
        {
            var callRet = _GetType();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__handles_global_class_type || method == MethodName._HandlesGlobalClassType) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__handles_global_class_type.NativeValue))
        {
            var callRet = _HandlesGlobalClassType(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_named_classes || method == MethodName._HasNamedClasses) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_named_classes.NativeValue))
        {
            var callRet = _HasNamedClasses();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__init || method == MethodName._Init) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__init.NativeValue))
        {
            _Init();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__is_control_flow_keyword || method == MethodName._IsControlFlowKeyword) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_control_flow_keyword.NativeValue))
        {
            var callRet = _IsControlFlowKeyword(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_using_templates || method == MethodName._IsUsingTemplates) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_using_templates.NativeValue))
        {
            var callRet = _IsUsingTemplates();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__lookup_code || method == MethodName._LookupCode) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__lookup_code.NativeValue))
        {
            var callRet = _LookupCode(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<string>(args[2]), VariantUtils.ConvertTo<GodotObject>(args[3]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__make_function || method == MethodName._MakeFunction) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__make_function.NativeValue))
        {
            var callRet = _MakeFunction(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<string[]>(args[2]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__make_template || method == MethodName._MakeTemplate) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__make_template.NativeValue))
        {
            var callRet = _MakeTemplate(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<string>(args[2]));
            ret = VariantUtils.CreateFrom<Script>(callRet);
            return true;
        }
        if ((method == MethodProxyName__open_in_external_editor || method == MethodName._OpenInExternalEditor) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__open_in_external_editor.NativeValue))
        {
            var callRet = _OpenInExternalEditor(VariantUtils.ConvertTo<Script>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<int>(args[2]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__overrides_external_editor || method == MethodName._OverridesExternalEditor) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__overrides_external_editor.NativeValue))
        {
            var callRet = _OverridesExternalEditor();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__preferred_file_name_casing || method == MethodName._PreferredFileNameCasing) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__preferred_file_name_casing.NativeValue))
        {
            var callRet = _PreferredFileNameCasing();
            ret = VariantUtils.CreateFrom<ScriptLanguage.ScriptNameCasing>(callRet);
            return true;
        }
        if ((method == MethodProxyName__profiling_set_save_native_calls || method == MethodName._ProfilingSetSaveNativeCalls) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__profiling_set_save_native_calls.NativeValue))
        {
            _ProfilingSetSaveNativeCalls(VariantUtils.ConvertTo<bool>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__profiling_start || method == MethodName._ProfilingStart) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__profiling_start.NativeValue))
        {
            _ProfilingStart();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__profiling_stop || method == MethodName._ProfilingStop) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__profiling_stop.NativeValue))
        {
            _ProfilingStop();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__reload_all_scripts || method == MethodName._ReloadAllScripts) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__reload_all_scripts.NativeValue))
        {
            _ReloadAllScripts();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__reload_scripts || method == MethodName._ReloadScripts) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__reload_scripts.NativeValue))
        {
            _ReloadScripts(VariantUtils.ConvertTo<Godot.Collections.Array>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__reload_tool_script || method == MethodName._ReloadToolScript) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__reload_tool_script.NativeValue))
        {
            _ReloadToolScript(VariantUtils.ConvertTo<Script>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__remove_named_global_constant || method == MethodName._RemoveNamedGlobalConstant) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__remove_named_global_constant.NativeValue))
        {
            _RemoveNamedGlobalConstant(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__supports_builtin_mode || method == MethodName._SupportsBuiltinMode) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__supports_builtin_mode.NativeValue))
        {
            var callRet = _SupportsBuiltinMode();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__supports_documentation || method == MethodName._SupportsDocumentation) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__supports_documentation.NativeValue))
        {
            var callRet = _SupportsDocumentation();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__thread_enter || method == MethodName._ThreadEnter) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__thread_enter.NativeValue))
        {
            _ThreadEnter();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__thread_exit || method == MethodName._ThreadExit) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__thread_exit.NativeValue))
        {
            _ThreadExit();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__validate || method == MethodName._Validate) && args.Count == 6 && HasGodotClassMethod((godot_string_name)MethodProxyName__validate.NativeValue))
        {
            var callRet = _Validate(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<bool>(args[2]), VariantUtils.ConvertTo<bool>(args[3]), VariantUtils.ConvertTo<bool>(args[4]), VariantUtils.ConvertTo<bool>(args[5]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__validate_path || method == MethodName._ValidatePath) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__validate_path.NativeValue))
        {
            var callRet = _ValidatePath(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
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
        if (method == MethodName._AddGlobalConstant)
        {
            if (HasGodotClassMethod(MethodProxyName__add_global_constant.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AddNamedGlobalConstant)
        {
            if (HasGodotClassMethod(MethodProxyName__add_named_global_constant.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AutoIndentCode)
        {
            if (HasGodotClassMethod(MethodProxyName__auto_indent_code.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CanInheritFromFile)
        {
            if (HasGodotClassMethod(MethodProxyName__can_inherit_from_file.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CanMakeFunction)
        {
            if (HasGodotClassMethod(MethodProxyName__can_make_function.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CompleteCode)
        {
            if (HasGodotClassMethod(MethodProxyName__complete_code.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CreateScript)
        {
            if (HasGodotClassMethod(MethodProxyName__create_script.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DebugGetCurrentStackInfo)
        {
            if (HasGodotClassMethod(MethodProxyName__debug_get_current_stack_info.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DebugGetError)
        {
            if (HasGodotClassMethod(MethodProxyName__debug_get_error.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DebugGetGlobals)
        {
            if (HasGodotClassMethod(MethodProxyName__debug_get_globals.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DebugGetStackLevelCount)
        {
            if (HasGodotClassMethod(MethodProxyName__debug_get_stack_level_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DebugGetStackLevelFunction)
        {
            if (HasGodotClassMethod(MethodProxyName__debug_get_stack_level_function.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DebugGetStackLevelLine)
        {
            if (HasGodotClassMethod(MethodProxyName__debug_get_stack_level_line.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DebugGetStackLevelLocals)
        {
            if (HasGodotClassMethod(MethodProxyName__debug_get_stack_level_locals.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DebugGetStackLevelMembers)
        {
            if (HasGodotClassMethod(MethodProxyName__debug_get_stack_level_members.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DebugGetStackLevelSource)
        {
            if (HasGodotClassMethod(MethodProxyName__debug_get_stack_level_source.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DebugParseStackLevelExpression)
        {
            if (HasGodotClassMethod(MethodProxyName__debug_parse_stack_level_expression.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FindFunction)
        {
            if (HasGodotClassMethod(MethodProxyName__find_function.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Finish)
        {
            if (HasGodotClassMethod(MethodProxyName__finish.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Frame)
        {
            if (HasGodotClassMethod(MethodProxyName__frame.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetBuiltInTemplates)
        {
            if (HasGodotClassMethod(MethodProxyName__get_built_in_templates.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetCommentDelimiters)
        {
            if (HasGodotClassMethod(MethodProxyName__get_comment_delimiters.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDocCommentDelimiters)
        {
            if (HasGodotClassMethod(MethodProxyName__get_doc_comment_delimiters.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetExtension)
        {
            if (HasGodotClassMethod(MethodProxyName__get_extension.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetGlobalClassName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_global_class_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPublicAnnotations)
        {
            if (HasGodotClassMethod(MethodProxyName__get_public_annotations.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPublicConstants)
        {
            if (HasGodotClassMethod(MethodProxyName__get_public_constants.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPublicFunctions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_public_functions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetRecognizedExtensions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_recognized_extensions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetReservedWords)
        {
            if (HasGodotClassMethod(MethodProxyName__get_reserved_words.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetStringDelimiters)
        {
            if (HasGodotClassMethod(MethodProxyName__get_string_delimiters.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetType)
        {
            if (HasGodotClassMethod(MethodProxyName__get_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HandlesGlobalClassType)
        {
            if (HasGodotClassMethod(MethodProxyName__handles_global_class_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasNamedClasses)
        {
            if (HasGodotClassMethod(MethodProxyName__has_named_classes.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Init)
        {
            if (HasGodotClassMethod(MethodProxyName__init.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsControlFlowKeyword)
        {
            if (HasGodotClassMethod(MethodProxyName__is_control_flow_keyword.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsUsingTemplates)
        {
            if (HasGodotClassMethod(MethodProxyName__is_using_templates.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._LookupCode)
        {
            if (HasGodotClassMethod(MethodProxyName__lookup_code.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._MakeFunction)
        {
            if (HasGodotClassMethod(MethodProxyName__make_function.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._MakeTemplate)
        {
            if (HasGodotClassMethod(MethodProxyName__make_template.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._OpenInExternalEditor)
        {
            if (HasGodotClassMethod(MethodProxyName__open_in_external_editor.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._OverridesExternalEditor)
        {
            if (HasGodotClassMethod(MethodProxyName__overrides_external_editor.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PreferredFileNameCasing)
        {
            if (HasGodotClassMethod(MethodProxyName__preferred_file_name_casing.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ProfilingSetSaveNativeCalls)
        {
            if (HasGodotClassMethod(MethodProxyName__profiling_set_save_native_calls.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ProfilingStart)
        {
            if (HasGodotClassMethod(MethodProxyName__profiling_start.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ProfilingStop)
        {
            if (HasGodotClassMethod(MethodProxyName__profiling_stop.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ReloadAllScripts)
        {
            if (HasGodotClassMethod(MethodProxyName__reload_all_scripts.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ReloadScripts)
        {
            if (HasGodotClassMethod(MethodProxyName__reload_scripts.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ReloadToolScript)
        {
            if (HasGodotClassMethod(MethodProxyName__reload_tool_script.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._RemoveNamedGlobalConstant)
        {
            if (HasGodotClassMethod(MethodProxyName__remove_named_global_constant.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SupportsBuiltinMode)
        {
            if (HasGodotClassMethod(MethodProxyName__supports_builtin_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SupportsDocumentation)
        {
            if (HasGodotClassMethod(MethodProxyName__supports_documentation.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ThreadEnter)
        {
            if (HasGodotClassMethod(MethodProxyName__thread_enter.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ThreadExit)
        {
            if (HasGodotClassMethod(MethodProxyName__thread_exit.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Validate)
        {
            if (HasGodotClassMethod(MethodProxyName__validate.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ValidatePath)
        {
            if (HasGodotClassMethod(MethodProxyName__validate_path.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : ScriptLanguage.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ScriptLanguage.MethodName
    {
        /// <summary>
        /// Cached name for the '_add_global_constant' method.
        /// </summary>
        public static readonly StringName _AddGlobalConstant = "_add_global_constant";
        /// <summary>
        /// Cached name for the '_add_named_global_constant' method.
        /// </summary>
        public static readonly StringName _AddNamedGlobalConstant = "_add_named_global_constant";
        /// <summary>
        /// Cached name for the '_auto_indent_code' method.
        /// </summary>
        public static readonly StringName _AutoIndentCode = "_auto_indent_code";
        /// <summary>
        /// Cached name for the '_can_inherit_from_file' method.
        /// </summary>
        public static readonly StringName _CanInheritFromFile = "_can_inherit_from_file";
        /// <summary>
        /// Cached name for the '_can_make_function' method.
        /// </summary>
        public static readonly StringName _CanMakeFunction = "_can_make_function";
        /// <summary>
        /// Cached name for the '_complete_code' method.
        /// </summary>
        public static readonly StringName _CompleteCode = "_complete_code";
        /// <summary>
        /// Cached name for the '_create_script' method.
        /// </summary>
        public static readonly StringName _CreateScript = "_create_script";
        /// <summary>
        /// Cached name for the '_debug_get_current_stack_info' method.
        /// </summary>
        public static readonly StringName _DebugGetCurrentStackInfo = "_debug_get_current_stack_info";
        /// <summary>
        /// Cached name for the '_debug_get_error' method.
        /// </summary>
        public static readonly StringName _DebugGetError = "_debug_get_error";
        /// <summary>
        /// Cached name for the '_debug_get_globals' method.
        /// </summary>
        public static readonly StringName _DebugGetGlobals = "_debug_get_globals";
        /// <summary>
        /// Cached name for the '_debug_get_stack_level_count' method.
        /// </summary>
        public static readonly StringName _DebugGetStackLevelCount = "_debug_get_stack_level_count";
        /// <summary>
        /// Cached name for the '_debug_get_stack_level_function' method.
        /// </summary>
        public static readonly StringName _DebugGetStackLevelFunction = "_debug_get_stack_level_function";
        /// <summary>
        /// Cached name for the '_debug_get_stack_level_line' method.
        /// </summary>
        public static readonly StringName _DebugGetStackLevelLine = "_debug_get_stack_level_line";
        /// <summary>
        /// Cached name for the '_debug_get_stack_level_locals' method.
        /// </summary>
        public static readonly StringName _DebugGetStackLevelLocals = "_debug_get_stack_level_locals";
        /// <summary>
        /// Cached name for the '_debug_get_stack_level_members' method.
        /// </summary>
        public static readonly StringName _DebugGetStackLevelMembers = "_debug_get_stack_level_members";
        /// <summary>
        /// Cached name for the '_debug_get_stack_level_source' method.
        /// </summary>
        public static readonly StringName _DebugGetStackLevelSource = "_debug_get_stack_level_source";
        /// <summary>
        /// Cached name for the '_debug_parse_stack_level_expression' method.
        /// </summary>
        public static readonly StringName _DebugParseStackLevelExpression = "_debug_parse_stack_level_expression";
        /// <summary>
        /// Cached name for the '_find_function' method.
        /// </summary>
        public static readonly StringName _FindFunction = "_find_function";
        /// <summary>
        /// Cached name for the '_finish' method.
        /// </summary>
        public static readonly StringName _Finish = "_finish";
        /// <summary>
        /// Cached name for the '_frame' method.
        /// </summary>
        public static readonly StringName _Frame = "_frame";
        /// <summary>
        /// Cached name for the '_get_built_in_templates' method.
        /// </summary>
        public static readonly StringName _GetBuiltInTemplates = "_get_built_in_templates";
        /// <summary>
        /// Cached name for the '_get_comment_delimiters' method.
        /// </summary>
        public static readonly StringName _GetCommentDelimiters = "_get_comment_delimiters";
        /// <summary>
        /// Cached name for the '_get_doc_comment_delimiters' method.
        /// </summary>
        public static readonly StringName _GetDocCommentDelimiters = "_get_doc_comment_delimiters";
        /// <summary>
        /// Cached name for the '_get_extension' method.
        /// </summary>
        public static readonly StringName _GetExtension = "_get_extension";
        /// <summary>
        /// Cached name for the '_get_global_class_name' method.
        /// </summary>
        public static readonly StringName _GetGlobalClassName = "_get_global_class_name";
        /// <summary>
        /// Cached name for the '_get_name' method.
        /// </summary>
        public static readonly StringName _GetName = "_get_name";
        /// <summary>
        /// Cached name for the '_get_public_annotations' method.
        /// </summary>
        public static readonly StringName _GetPublicAnnotations = "_get_public_annotations";
        /// <summary>
        /// Cached name for the '_get_public_constants' method.
        /// </summary>
        public static readonly StringName _GetPublicConstants = "_get_public_constants";
        /// <summary>
        /// Cached name for the '_get_public_functions' method.
        /// </summary>
        public static readonly StringName _GetPublicFunctions = "_get_public_functions";
        /// <summary>
        /// Cached name for the '_get_recognized_extensions' method.
        /// </summary>
        public static readonly StringName _GetRecognizedExtensions = "_get_recognized_extensions";
        /// <summary>
        /// Cached name for the '_get_reserved_words' method.
        /// </summary>
        public static readonly StringName _GetReservedWords = "_get_reserved_words";
        /// <summary>
        /// Cached name for the '_get_string_delimiters' method.
        /// </summary>
        public static readonly StringName _GetStringDelimiters = "_get_string_delimiters";
        /// <summary>
        /// Cached name for the '_get_type' method.
        /// </summary>
        public static readonly StringName _GetType = "_get_type";
        /// <summary>
        /// Cached name for the '_handles_global_class_type' method.
        /// </summary>
        public static readonly StringName _HandlesGlobalClassType = "_handles_global_class_type";
        /// <summary>
        /// Cached name for the '_has_named_classes' method.
        /// </summary>
        public static readonly StringName _HasNamedClasses = "_has_named_classes";
        /// <summary>
        /// Cached name for the '_init' method.
        /// </summary>
        public static readonly StringName _Init = "_init";
        /// <summary>
        /// Cached name for the '_is_control_flow_keyword' method.
        /// </summary>
        public static readonly StringName _IsControlFlowKeyword = "_is_control_flow_keyword";
        /// <summary>
        /// Cached name for the '_is_using_templates' method.
        /// </summary>
        public static readonly StringName _IsUsingTemplates = "_is_using_templates";
        /// <summary>
        /// Cached name for the '_lookup_code' method.
        /// </summary>
        public static readonly StringName _LookupCode = "_lookup_code";
        /// <summary>
        /// Cached name for the '_make_function' method.
        /// </summary>
        public static readonly StringName _MakeFunction = "_make_function";
        /// <summary>
        /// Cached name for the '_make_template' method.
        /// </summary>
        public static readonly StringName _MakeTemplate = "_make_template";
        /// <summary>
        /// Cached name for the '_open_in_external_editor' method.
        /// </summary>
        public static readonly StringName _OpenInExternalEditor = "_open_in_external_editor";
        /// <summary>
        /// Cached name for the '_overrides_external_editor' method.
        /// </summary>
        public static readonly StringName _OverridesExternalEditor = "_overrides_external_editor";
        /// <summary>
        /// Cached name for the '_preferred_file_name_casing' method.
        /// </summary>
        public static readonly StringName _PreferredFileNameCasing = "_preferred_file_name_casing";
        /// <summary>
        /// Cached name for the '_profiling_set_save_native_calls' method.
        /// </summary>
        public static readonly StringName _ProfilingSetSaveNativeCalls = "_profiling_set_save_native_calls";
        /// <summary>
        /// Cached name for the '_profiling_start' method.
        /// </summary>
        public static readonly StringName _ProfilingStart = "_profiling_start";
        /// <summary>
        /// Cached name for the '_profiling_stop' method.
        /// </summary>
        public static readonly StringName _ProfilingStop = "_profiling_stop";
        /// <summary>
        /// Cached name for the '_reload_all_scripts' method.
        /// </summary>
        public static readonly StringName _ReloadAllScripts = "_reload_all_scripts";
        /// <summary>
        /// Cached name for the '_reload_scripts' method.
        /// </summary>
        public static readonly StringName _ReloadScripts = "_reload_scripts";
        /// <summary>
        /// Cached name for the '_reload_tool_script' method.
        /// </summary>
        public static readonly StringName _ReloadToolScript = "_reload_tool_script";
        /// <summary>
        /// Cached name for the '_remove_named_global_constant' method.
        /// </summary>
        public static readonly StringName _RemoveNamedGlobalConstant = "_remove_named_global_constant";
        /// <summary>
        /// Cached name for the '_supports_builtin_mode' method.
        /// </summary>
        public static readonly StringName _SupportsBuiltinMode = "_supports_builtin_mode";
        /// <summary>
        /// Cached name for the '_supports_documentation' method.
        /// </summary>
        public static readonly StringName _SupportsDocumentation = "_supports_documentation";
        /// <summary>
        /// Cached name for the '_thread_enter' method.
        /// </summary>
        public static readonly StringName _ThreadEnter = "_thread_enter";
        /// <summary>
        /// Cached name for the '_thread_exit' method.
        /// </summary>
        public static readonly StringName _ThreadExit = "_thread_exit";
        /// <summary>
        /// Cached name for the '_validate' method.
        /// </summary>
        public static readonly StringName _Validate = "_validate";
        /// <summary>
        /// Cached name for the '_validate_path' method.
        /// </summary>
        public static readonly StringName _ValidatePath = "_validate_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ScriptLanguage.SignalName
    {
    }
}
