namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A regular expression (or regex) is a compact language that can be used to recognize strings that follow a specific pattern, such as URLs, email addresses, complete sentences, etc. For example, a regex of <c>ab[0-9]</c> would find any string that is <c>ab</c> followed by any number from <c>0</c> to <c>9</c>. For a more in-depth look, you can easily find various tutorials and detailed explanations on the Internet.</para>
/// <para>To begin, the RegEx object needs to be compiled with the search pattern using <see cref="Godot.RegEx.Compile(string, bool)"/> before it can be used. Alternatively, the static method <see cref="Godot.RegEx.CreateFromString(string, bool)"/> can be used to create and compile a RegEx object in a single method call.</para>
/// <para><code>
/// var regex = RegEx.new()
/// regex.compile("\\w-(\\d+)")
/// # Shorthand to create and compile a regex (used in the examples below):
/// var regex2 = RegEx.create_from_string("\\w-(\\d+)")
/// </code></para>
/// <para>The search pattern must be escaped first for GDScript before it is escaped for the expression. For example, <c>compile("\\d+")</c> would be read by RegEx as <c>\d+</c>. Similarly, <c>compile("\"(?:\\\\.|[^\"])*\"")</c> would be read as <c>"(?:\\.|[^"])*"</c>. In GDScript, you can also use raw string literals (r-strings). For example, <c>compile(r'"(?:\\.|[^"])*"')</c> would be read the same.</para>
/// <para>Using <see cref="Godot.RegEx.Search(string, int, int)"/>, you can find the pattern within the given text. If a pattern is found, <see cref="Godot.RegExMatch"/> is returned and you can retrieve details of the results using methods such as <see cref="Godot.RegExMatch.GetString(Nullable{Variant})"/> and <see cref="Godot.RegExMatch.GetStart(Nullable{Variant})"/>.</para>
/// <para><code>
/// var regex = RegEx.create_from_string("\\w-(\\d+)")
/// var result = regex.search("abc n-0123")
/// if result:
/// 	print(result.get_string()) # Prints "n-0123"
/// </code></para>
/// <para>The results of capturing groups <c>()</c> can be retrieved by passing the group number to the various methods in <see cref="Godot.RegExMatch"/>. Group 0 is the default and will always refer to the entire pattern. In the above example, calling <c>result.get_string(1)</c> would give you <c>0123</c>.</para>
/// <para>This version of RegEx also supports named capturing groups, and the names can be used to retrieve the results. If two or more groups have the same name, the name would only refer to the first one with a match.</para>
/// <para><code>
/// var regex = RegEx.create_from_string("d(?&lt;digit&gt;[0-9]+)|x(?&lt;digit&gt;[0-9a-f]+)")
/// var result = regex.search("the number is x2f")
/// if result:
/// 	print(result.get_string("digit")) # Prints "2f"
/// </code></para>
/// <para>If you need to process multiple results, <see cref="Godot.RegEx.SearchAll(string, int, int)"/> generates a list of all non-overlapping results. This can be combined with a <c>for</c> loop for convenience.</para>
/// <para><code>
/// # Prints "01 03 0 3f 42"
/// for result in regex.search_all("d01, d03, d0c, x3f and x42"):
/// 	print(result.get_string("digit"))
/// </code></para>
/// <para><b>Example:</b> Split a string using a RegEx:</para>
/// <para><code>
/// var regex = RegEx.create_from_string("\\S+") # Negated whitespace character class.
/// var results = []
/// for result in regex.search_all("One  Two \n\tThree"):
/// 	results.push_back(result.get_string())
/// print(results) # Prints ["One", "Two", "Three"]
/// </code></para>
/// <para><b>Note:</b> Godot's regex implementation is based on the <a href="https://www.pcre.org/">PCRE2</a> library. You can view the full pattern reference <a href="https://www.pcre.org/current/doc/html/pcre2pattern.html">here</a>.</para>
/// <para><b>Tip:</b> You can use <a href="https://regexr.com/">Regexr</a> to test regular expressions online.</para>
/// </summary>
public partial class RegEx : RefCounted
{
    private static readonly System.Type CachedType = typeof(RegEx);

    private static readonly StringName NativeName = "RegEx";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RegEx() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RegEx(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RegEx(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromString, 4249111514ul);

    /// <summary>
    /// <para>Creates and compiles a new <see cref="Godot.RegEx"/> object. See also <see cref="Godot.RegEx.Compile(string, bool)"/>.</para>
    /// </summary>
    public static RegEx CreateFromString(string pattern, bool showError = true)
    {
        return (RegEx)NativeCalls.godot_icall_2_373(MethodBind0, pattern, showError.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>This method resets the state of the object, as if it was freshly created. Namely, it unassigns the regular expression of this object.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Compile, 3565188097ul);

    /// <summary>
    /// <para>Compiles and assign the search pattern to use. Returns <see cref="Godot.Error.Ok"/> if the compilation is successful. If compilation fails, returns <see cref="Godot.Error.Failed"/> and when <paramref name="showError"/> is <see langword="true"/>, details are printed to standard output.</para>
    /// </summary>
    public Error Compile(string pattern, bool showError = true)
    {
        return (Error)NativeCalls.godot_icall_2_350(MethodBind2, GodotObject.GetPtr(this), pattern, showError.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Search, 3365977994ul);

    /// <summary>
    /// <para>Searches the text for the compiled pattern. Returns a <see cref="Godot.RegExMatch"/> container of the first matching result if found, otherwise <see langword="null"/>.</para>
    /// <para>The region to search within can be specified with <paramref name="offset"/> and <paramref name="end"/>. This is useful when searching for another match in the same <paramref name="subject"/> by calling this method again after a previous success. Note that setting these parameters differs from passing over a shortened string. For example, the start anchor <c>^</c> is not affected by <paramref name="offset"/>, and the character before <paramref name="offset"/> will be checked for the word boundary <c>\b</c>.</para>
    /// </summary>
    public RegExMatch Search(string subject, int offset = 0, int end = -1)
    {
        return (RegExMatch)NativeCalls.godot_icall_3_1033(MethodBind3, GodotObject.GetPtr(this), subject, offset, end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SearchAll, 849021363ul);

    /// <summary>
    /// <para>Searches the text for the compiled pattern. Returns an array of <see cref="Godot.RegExMatch"/> containers for each non-overlapping result. If no results were found, an empty array is returned instead.</para>
    /// <para>The region to search within can be specified with <paramref name="offset"/> and <paramref name="end"/>. This is useful when searching for another match in the same <paramref name="subject"/> by calling this method again after a previous success. Note that setting these parameters differs from passing over a shortened string. For example, the start anchor <c>^</c> is not affected by <paramref name="offset"/>, and the character before <paramref name="offset"/> will be checked for the word boundary <c>\b</c>.</para>
    /// </summary>
    public Godot.Collections.Array<RegExMatch> SearchAll(string subject, int offset = 0, int end = -1)
    {
        return new Godot.Collections.Array<RegExMatch>(NativeCalls.godot_icall_3_1034(MethodBind4, GodotObject.GetPtr(this), subject, offset, end));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Sub, 54019702ul);

    /// <summary>
    /// <para>Searches the text for the compiled pattern and replaces it with the specified string. Escapes and backreferences such as <c>$1</c> and <c>$name</c> are expanded and resolved. By default, only the first instance is replaced, but it can be changed for all instances (global replacement).</para>
    /// <para>The region to search within can be specified with <paramref name="offset"/> and <paramref name="end"/>. This is useful when searching for another match in the same <paramref name="subject"/> by calling this method again after a previous success. Note that setting these parameters differs from passing over a shortened string. For example, the start anchor <c>^</c> is not affected by <paramref name="offset"/>, and the character before <paramref name="offset"/> will be checked for the word boundary <c>\b</c>.</para>
    /// </summary>
    public string Sub(string subject, string replacement, bool all = false, int offset = 0, int end = -1)
    {
        return NativeCalls.godot_icall_5_1035(MethodBind5, GodotObject.GetPtr(this), subject, replacement, all.ToGodotBool(), offset, end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsValid, 36873697ul);

    /// <summary>
    /// <para>Returns whether this object has a valid search pattern assigned.</para>
    /// </summary>
    public bool IsValid()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPattern, 201670096ul);

    /// <summary>
    /// <para>Returns the original search pattern that was compiled.</para>
    /// </summary>
    public string GetPattern()
    {
        return NativeCalls.godot_icall_0_58(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroupCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of capturing groups in compiled pattern.</para>
    /// </summary>
    public int GetGroupCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNames, 1139954409ul);

    /// <summary>
    /// <para>Returns an array of names of named capturing groups in the compiled pattern. They are ordered by appearance.</para>
    /// </summary>
    public string[] GetNames()
    {
        return NativeCalls.godot_icall_0_108(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Compile, 166001499ul);

    /// <summary>
    /// <para>Compiles and assign the search pattern to use. Returns <see cref="Godot.Error.Ok"/> if the compilation is successful. If compilation fails, returns <see cref="Godot.Error.Failed"/> and when <paramref name="showError"/> is <see langword="true"/>, details are printed to standard output.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Error Compile(string pattern)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind10, GodotObject.GetPtr(this), pattern);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromString, 2150300909ul);

    /// <summary>
    /// <para>Creates and compiles a new <see cref="Godot.RegEx"/> object. See also <see cref="Godot.RegEx.Compile(string, bool)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static RegEx CreateFromString(string pattern)
    {
        return (RegEx)NativeCalls.godot_icall_1_203(MethodBind11, pattern);
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_from_string' method.
        /// </summary>
        public static readonly StringName CreateFromString = "create_from_string";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'compile' method.
        /// </summary>
        public static readonly StringName Compile = "compile";
        /// <summary>
        /// Cached name for the 'search' method.
        /// </summary>
        public static readonly StringName Search = "search";
        /// <summary>
        /// Cached name for the 'search_all' method.
        /// </summary>
        public static readonly StringName SearchAll = "search_all";
        /// <summary>
        /// Cached name for the 'sub' method.
        /// </summary>
        public static readonly StringName Sub = "sub";
        /// <summary>
        /// Cached name for the 'is_valid' method.
        /// </summary>
        public static readonly StringName IsValid = "is_valid";
        /// <summary>
        /// Cached name for the 'get_pattern' method.
        /// </summary>
        public static readonly StringName GetPattern = "get_pattern";
        /// <summary>
        /// Cached name for the 'get_group_count' method.
        /// </summary>
        public static readonly StringName GetGroupCount = "get_group_count";
        /// <summary>
        /// Cached name for the 'get_names' method.
        /// </summary>
        public static readonly StringName GetNames = "get_names";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
