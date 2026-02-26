namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.Json"/> class enables all data types to be converted to and from a JSON string. This is useful for serializing data, e.g. to save to a file or send over the network.</para>
/// <para><see cref="Godot.Json.Stringify(Variant, string, bool, bool)"/> is used to convert any data type into a JSON string.</para>
/// <para><see cref="Godot.Json.Parse(string, bool)"/> is used to convert any existing JSON data into a <see cref="Godot.Variant"/> that can be used within Godot. If successfully parsed, use <see cref="Godot.Json.Data"/> to retrieve the <see cref="Godot.Variant"/>, and use <c>@GlobalScope.typeof</c> to check if the Variant's type is what you expect. JSON Objects are converted into a <see cref="Godot.Collections.Dictionary"/>, but JSON data can be used to store <see cref="Godot.Collections.Array"/>s, numbers, <see cref="string"/>s and even just a boolean.</para>
/// <para><code>
/// var data_to_send = ["a", "b", "c"]
/// var json_string = JSON.stringify(data_to_send)
/// # Save data
/// # ...
/// # Retrieve data
/// var json = JSON.new()
/// var error = json.parse(json_string)
/// if error == OK:
/// 	var data_received = json.data
/// 	if typeof(data_received) == TYPE_ARRAY:
/// 		print(data_received) # Prints the array.
/// 	else:
/// 		print("Unexpected data")
/// else:
/// 	print("JSON Parse Error: ", json.get_error_message(), " in ", json_string, " at line ", json.get_error_line())
/// </code></para>
/// <para>Alternatively, you can parse strings using the static <see cref="Godot.Json.ParseString(string)"/> method, but it doesn't handle errors.</para>
/// <para><code>
/// var data = JSON.parse_string(json_string) # Returns null if parsing failed.
/// </code></para>
/// <para><b>Note:</b> Both parse methods do not fully comply with the JSON specification:</para>
/// <para>- Trailing commas in arrays or objects are ignored, instead of causing a parser error.</para>
/// <para>- New line and tab characters are accepted in string literals, and are treated like their corresponding escape sequences <c>\n</c> and <c>\t</c>.</para>
/// <para>- Numbers are parsed using <c>String.to_float</c> which is generally more lax than the JSON specification.</para>
/// <para>- Certain errors, such as invalid Unicode sequences, do not cause a parser error. Instead, the string is cleaned up and an error is logged to the console.</para>
/// </summary>
[GodotClassName("JSON")]
public partial class Json : Resource
{
    /// <summary>
    /// <para>Contains the parsed JSON data in <see cref="Godot.Variant"/> form.</para>
    /// </summary>
    public Variant Data
    {
        get
        {
            return GetData();
        }
        set
        {
            SetData(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Json);

    private static readonly StringName NativeName = "JSON";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Json() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Json(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Json(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stringify, 462733549ul);

    /// <summary>
    /// <para>Converts a <see cref="Godot.Variant"/> var to JSON text and returns the result. Useful for serializing data to store or send over the network.</para>
    /// <para><b>Note:</b> The JSON specification does not define integer or float types, but only a <i>number</i> type. Therefore, converting a Variant to JSON text will convert all numerical values to <see cref="float"/> types.</para>
    /// <para><b>Note:</b> If <paramref name="fullPrecision"/> is <see langword="true"/>, when stringifying floats, the unreliable digits are stringified in addition to the reliable digits to guarantee exact decoding.</para>
    /// <para>The <paramref name="indent"/> parameter controls if and how something is indented; its contents will be used where there should be an indent in the output. Even spaces like <c>"   "</c> will work. <c>\t</c> and <c>\n</c> can also be used for a tab indent, or to make a newline for each indent respectively.</para>
    /// <para><b>Warning:</b> Non-finite numbers are not supported in JSON. Any occurrences of <c>@GDScript.INF</c> will be replaced with <c>1e99999</c>, and negative <c>@GDScript.INF</c> will be replaced with <c>-1e99999</c>, but they will be interpreted correctly as infinity by most JSON parsers. <c>@GDScript.NAN</c> will be replaced with <see langword="null"/>, and it will not be interpreted as NaN in JSON parsers. If you expect non-finite numbers, consider passing your data through <see cref="Godot.Json.FromNative(Variant, bool)"/> first.</para>
    /// <para><b>Example output:</b></para>
    /// <para><code>
    /// ## JSON.stringify(my_dictionary)
    /// {"name":"my_dictionary","version":"1.0.0","entities":[{"name":"entity_0","value":"value_0"},{"name":"entity_1","value":"value_1"}]}
    /// 
    /// ## JSON.stringify(my_dictionary, "\t")
    /// {
    /// 	"name": "my_dictionary",
    /// 	"version": "1.0.0",
    /// 	"entities": [
    /// 		{
    /// 			"name": "entity_0",
    /// 			"value": "value_0"
    /// 		},
    /// 		{
    /// 			"name": "entity_1",
    /// 			"value": "value_1"
    /// 		}
    /// 	]
    /// }
    /// 
    /// ## JSON.stringify(my_dictionary, "...")
    /// {
    /// ..."name": "my_dictionary",
    /// ..."version": "1.0.0",
    /// ..."entities": [
    /// ......{
    /// ........."name": "entity_0",
    /// ........."value": "value_0"
    /// ......},
    /// ......{
    /// ........."name": "entity_1",
    /// ........."value": "value_1"
    /// ......}
    /// ...]
    /// }
    /// </code></para>
    /// </summary>
    public static string Stringify(Variant data, string indent = "", bool sortKeys = true, bool fullPrecision = false)
    {
        return NativeCalls.godot_icall_4_770(MethodBind0, data, indent, sortKeys.ToGodotBool(), fullPrecision.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParseString, 309047738ul);

    /// <summary>
    /// <para>Attempts to parse the <paramref name="jsonString"/> provided and returns the parsed data. Returns <see langword="null"/> if parse failed.</para>
    /// </summary>
    public static Variant ParseString(string jsonString)
    {
        return NativeCalls.godot_icall_1_771(MethodBind1, jsonString);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Parse, 885841341ul);

    /// <summary>
    /// <para>Attempts to parse the <paramref name="jsonText"/> provided.</para>
    /// <para>Returns an <see cref="Godot.Error"/>. If the parse was successful, it returns <see cref="Godot.Error.Ok"/> and the result can be retrieved using <see cref="Godot.Json.Data"/>. If unsuccessful, use <see cref="Godot.Json.GetErrorLine()"/> and <see cref="Godot.Json.GetErrorMessage()"/> to identify the source of the failure.</para>
    /// <para>Non-static variant of <see cref="Godot.Json.ParseString(string)"/>, if you want custom error handling.</para>
    /// <para>The optional <paramref name="keepText"/> argument instructs the parser to keep a copy of the original text. This text can be obtained later by using the <see cref="Godot.Json.GetParsedText()"/> function and is used when saving the resource (instead of generating new text from <see cref="Godot.Json.Data"/>).</para>
    /// </summary>
    public Error Parse(string jsonText, bool keepText = false)
    {
        return (Error)NativeCalls.godot_icall_2_350(MethodBind2, GodotObject.GetPtr(this), jsonText, keepText.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetData, 1214101251ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Variant GetData()
    {
        return NativeCalls.godot_icall_0_772(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetData, 1114965689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetData(Variant data)
    {
        NativeCalls.godot_icall_1_773(MethodBind4, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParsedText, 201670096ul);

    /// <summary>
    /// <para>Return the text parsed by <see cref="Godot.Json.Parse(string, bool)"/> (requires passing <c>keep_text</c> to <see cref="Godot.Json.Parse(string, bool)"/>).</para>
    /// </summary>
    public string GetParsedText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetErrorLine, 3905245786ul);

    /// <summary>
    /// <para>Returns <c>0</c> if the last call to <see cref="Godot.Json.Parse(string, bool)"/> was successful, or the line number where the parse failed.</para>
    /// </summary>
    public int GetErrorLine()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetErrorMessage, 201670096ul);

    /// <summary>
    /// <para>Returns an empty string if the last call to <see cref="Godot.Json.Parse(string, bool)"/> was successful, or the error message if it failed.</para>
    /// </summary>
    public string GetErrorMessage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromNative, 2963479484ul);

    /// <summary>
    /// <para>Converts a native engine type to a JSON-compliant value.</para>
    /// <para>By default, objects are ignored for security reasons, unless <paramref name="fullObjects"/> is <see langword="true"/>.</para>
    /// <para>You can convert a native value to a JSON string like this:</para>
    /// <para><code>
    /// func encode_data(value, full_objects = false):
    /// 	return JSON.stringify(JSON.from_native(value, full_objects))
    /// </code></para>
    /// </summary>
    public static Variant FromNative(Variant variant, bool fullObjects = false)
    {
        return NativeCalls.godot_icall_2_774(MethodBind8, variant, fullObjects.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToNative, 2963479484ul);

    /// <summary>
    /// <para>Converts a JSON-compliant value that was created with <see cref="Godot.Json.FromNative(Variant, bool)"/> back to native engine types.</para>
    /// <para>By default, objects are ignored for security reasons, unless <paramref name="allowObjects"/> is <see langword="true"/>.</para>
    /// <para>You can convert a JSON string back to a native value like this:</para>
    /// <para><code>
    /// func decode_data(string, allow_objects = false):
    /// 	return JSON.to_native(JSON.parse_string(string), allow_objects)
    /// </code></para>
    /// </summary>
    public static Variant ToNative(Variant json, bool allowObjects = false)
    {
        return NativeCalls.godot_icall_2_774(MethodBind9, json, allowObjects.ToGodotBool());
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
        /// Cached name for the 'data' property.
        /// </summary>
        public static readonly StringName Data = "data";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'stringify' method.
        /// </summary>
        public static readonly StringName Stringify = "stringify";
        /// <summary>
        /// Cached name for the 'parse_string' method.
        /// </summary>
        public static readonly StringName ParseString = "parse_string";
        /// <summary>
        /// Cached name for the 'parse' method.
        /// </summary>
        public static readonly StringName Parse = "parse";
        /// <summary>
        /// Cached name for the 'get_data' method.
        /// </summary>
        public static readonly StringName GetData = "get_data";
        /// <summary>
        /// Cached name for the 'set_data' method.
        /// </summary>
        public static readonly StringName SetData = "set_data";
        /// <summary>
        /// Cached name for the 'get_parsed_text' method.
        /// </summary>
        public static readonly StringName GetParsedText = "get_parsed_text";
        /// <summary>
        /// Cached name for the 'get_error_line' method.
        /// </summary>
        public static readonly StringName GetErrorLine = "get_error_line";
        /// <summary>
        /// Cached name for the 'get_error_message' method.
        /// </summary>
        public static readonly StringName GetErrorMessage = "get_error_message";
        /// <summary>
        /// Cached name for the 'from_native' method.
        /// </summary>
        public static readonly StringName FromNative = "from_native";
        /// <summary>
        /// Cached name for the 'to_native' method.
        /// </summary>
        public static readonly StringName ToNative = "to_native";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
