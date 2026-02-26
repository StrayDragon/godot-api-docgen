namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.EditorTranslationParserPlugin"/> is invoked when a file is being parsed to extract strings that require translation. To define the parsing and string extraction logic, override the <see cref="Godot.EditorTranslationParserPlugin._ParseFile(string)"/> method in script.</para>
/// <para>The return value should be an <see cref="Godot.Collections.Array"/> of <see cref="string"/>[]s, one for each extracted translatable string. Each entry should contain <c>[msgid, msgctxt, msgid_plural, comment, source_line]</c>, where all except <c>msgid</c> are optional. Empty strings will be ignored.</para>
/// <para>The extracted strings will be written into a translation template file selected by user under "Template Generation" in "Localization" tab in "Project Settings" menu.</para>
/// <para>Below shows an example of a custom parser that extracts strings from a CSV file to write into a template.</para>
/// <para><see cref="string"/>[]<code>
/// using Godot;
/// 
/// [Tool]
/// public partial class CustomParser : EditorTranslationParserPlugin
/// {
/// 	public override Godot.Collections.Array&lt;string[]&gt; _ParseFile(string path)
/// 	{
/// 		Godot.Collections.Array&lt;string[]&gt; ret;
/// 		using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
/// 		string text = file.GetAsText();
/// 		string[] splitStrs = text.Split(",", allowEmpty: false);
/// 		foreach (string s in splitStrs)
/// 		{
/// 			ret.Add([s]);
/// 			//GD.Print($"Extracted string: {s}");
/// 		}
/// 		return ret;
/// 	}
/// 
/// 	public override string[] _GetRecognizedExtensions()
/// 	{
/// 		return ["csv"];
/// 	}
/// }
/// </code><code>
/// // This will add a message with msgid "Test 1", msgctxt "context", msgid_plural "test 1 plurals", comment "test 1 comment", and source line "7".
/// ret.Add(["Test 1", "context", "test 1 plurals", "test 1 comment", "7"]);
/// // This will add a message with msgid "A test without context" and msgid_plural "plurals".
/// ret.Add(["A test without context", "", "plurals"]);
/// // This will add a message with msgid "Only with context" and msgctxt "a friendly context".
/// ret.Add(["Only with context", "a friendly context"]);
/// </code>
/// <b>Note:</b> If you override parsing logic for standard script types (GDScript, C#, etc.), it would be better to load the <c>path</c> argument using <see cref="Godot.ResourceLoader.Load(string, string, ResourceLoader.CacheMode)"/>. This is because built-in scripts are loaded as <see cref="Godot.Resource"/> type, not <see cref="Godot.FileAccess"/> type. For example:
/// <code>
/// public override Godot.Collections.Array&lt;string[]&gt; _ParseFile(string path)
/// {
/// 	var res = ResourceLoader.Load&lt;Script&gt;(path, "Script");
/// 	string text = res.SourceCode;
/// 	// Parsing logic.
/// }
/// 
/// public override string[] _GetRecognizedExtensions()
/// {
/// 	return ["gd"];
/// }
/// </code>
/// To use <see cref="Godot.EditorTranslationParserPlugin"/>, register it using the <see cref="Godot.EditorPlugin.AddTranslationParserPlugin(EditorTranslationParserPlugin)"/> method first.</para>
/// </summary>
public partial class EditorTranslationParserPlugin : RefCounted
{
    private static readonly System.Type CachedType = typeof(EditorTranslationParserPlugin);

    private static readonly StringName NativeName = "EditorTranslationParserPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorTranslationParserPlugin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorTranslationParserPlugin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorTranslationParserPlugin(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Gets the list of file extensions to associate with this parser, e.g. <c>["csv"]</c>.</para>
    /// </summary>
    public virtual string[] _GetRecognizedExtensions()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define a custom parsing logic to extract the translatable strings.</para>
    /// </summary>
    public virtual Godot.Collections.Array<string[]> _ParseFile(string path)
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_recognized_extensions = "_GetRecognizedExtensions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_file = "_ParseFile";

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
        if ((method == MethodProxyName__get_recognized_extensions || method == MethodName._GetRecognizedExtensions) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_recognized_extensions.NativeValue))
        {
            var callRet = _GetRecognizedExtensions();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__parse_file || method == MethodName._ParseFile) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_file.NativeValue))
        {
            var callRet = _ParseFile(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFromArray(callRet);
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
        if (method == MethodName._GetRecognizedExtensions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_recognized_extensions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseFile)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_file.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_get_recognized_extensions' method.
        /// </summary>
        public static readonly StringName _GetRecognizedExtensions = "_get_recognized_extensions";
        /// <summary>
        /// Cached name for the '_parse_file' method.
        /// </summary>
        public static readonly StringName _ParseFile = "_parse_file";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
