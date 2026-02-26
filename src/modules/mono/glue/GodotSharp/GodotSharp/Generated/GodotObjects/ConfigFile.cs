namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This helper class can be used to store <see cref="Godot.Variant"/> values on the filesystem using INI-style formatting. The stored values are identified by a section and a key:</para>
/// <para><code>
/// [section]
/// some_key=42
/// string_example="Hello World3D!"
/// a_vector=Vector3(1, 0, 2)
/// </code></para>
/// <para>The stored data can be saved to or parsed from a file, though ConfigFile objects can also be used directly without accessing the filesystem.</para>
/// <para>The following example shows how to create a simple <see cref="Godot.ConfigFile"/> and save it on disc:</para>
/// <para><code>
/// // Create new ConfigFile object.
/// var config = new ConfigFile();
/// 
/// // Store some values.
/// config.SetValue("Player1", "player_name", "Steve");
/// config.SetValue("Player1", "best_score", 10);
/// config.SetValue("Player2", "player_name", "V3geta");
/// config.SetValue("Player2", "best_score", 9001);
/// 
/// // Save it to a file (overwrite if already exists).
/// config.Save("user://scores.cfg");
/// </code></para>
/// <para>This example shows how the above file could be loaded:</para>
/// <para><code>
/// var score_data = new Godot.Collections.Dictionary();
/// var config = new ConfigFile();
/// 
/// // Load data from a file.
/// Error err = config.Load("user://scores.cfg");
/// 
/// // If the file didn't load, ignore it.
/// if (err != Error.Ok)
/// {
/// 	return;
/// }
/// 
/// // Iterate over all sections.
/// foreach (String player in config.GetSections())
/// {
/// 	// Fetch the data for each section.
/// 	var player_name = (String)config.GetValue(player, "player_name");
/// 	var player_score = (int)config.GetValue(player, "best_score");
/// 	score_data[player_name] = player_score;
/// }
/// </code></para>
/// <para>Any operation that mutates the ConfigFile such as <see cref="Godot.ConfigFile.SetValue(string, string, Variant)"/>, <see cref="Godot.ConfigFile.Clear()"/>, or <see cref="Godot.ConfigFile.EraseSection(string)"/>, only changes what is loaded in memory. If you want to write the change to a file, you have to save the changes with <see cref="Godot.ConfigFile.Save(string)"/>, <see cref="Godot.ConfigFile.SaveEncrypted(string, byte[])"/>, or <see cref="Godot.ConfigFile.SaveEncryptedPass(string, string)"/>.</para>
/// <para>Keep in mind that section and property names can't contain spaces. Anything after a space will be ignored on save and on load.</para>
/// <para>ConfigFiles can also contain manually written comment lines starting with a semicolon (<c>;</c>). Those lines will be ignored when parsing the file. Note that comments will be lost when saving the ConfigFile. This can still be useful for dedicated server configuration files, which are typically never overwritten without explicit user action.</para>
/// <para><b>Note:</b> The file extension given to a ConfigFile does not have any impact on its formatting or behavior. By convention, the <c>.cfg</c> extension is used here, but any other extension such as <c>.ini</c> is also valid. Since neither <c>.cfg</c> nor <c>.ini</c> are standardized, Godot's ConfigFile formatting may differ from files written by other programs.</para>
/// </summary>
public partial class ConfigFile : RefCounted
{
    private static readonly System.Type CachedType = typeof(ConfigFile);

    private static readonly StringName NativeName = "ConfigFile";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ConfigFile() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ConfigFile(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ConfigFile(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetValue, 2504492430ul);

    /// <summary>
    /// <para>Assigns a value to the specified key of the specified section. If either the section or the key do not exist, they are created. Passing a <see langword="null"/> value deletes the specified key if it exists, and deletes the section if it ends up empty once the key has been removed.</para>
    /// </summary>
    public void SetValue(string section, string key, Variant value)
    {
        NativeCalls.godot_icall_3_325(MethodBind0, GodotObject.GetPtr(this), section, key, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetValue, 89809366ul);

    /// <summary>
    /// <para>Returns the current value for the specified section and key. If either the section or the key do not exist, the method returns the fallback <paramref name="default"/> value. If <paramref name="default"/> is not specified or set to <see langword="null"/>, an error is also raised.</para>
    /// </summary>
    public Variant GetValue(string section, string key, Variant @default = default)
    {
        return NativeCalls.godot_icall_3_326(MethodBind1, GodotObject.GetPtr(this), section, key, @default);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSection, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified section exists.</para>
    /// </summary>
    public bool HasSection(string section)
    {
        return NativeCalls.godot_icall_1_131(MethodBind2, GodotObject.GetPtr(this), section).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSectionKey, 820780508ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified section-key pair exists.</para>
    /// </summary>
    public bool HasSectionKey(string section, string key)
    {
        return NativeCalls.godot_icall_2_327(MethodBind3, GodotObject.GetPtr(this), section, key).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSections, 1139954409ul);

    /// <summary>
    /// <para>Returns an array of all defined section identifiers.</para>
    /// </summary>
    public string[] GetSections()
    {
        return NativeCalls.godot_icall_0_108(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSectionKeys, 4291131558ul);

    /// <summary>
    /// <para>Returns an array of all defined key identifiers in the specified section. Raises an error and returns an empty array if the section does not exist.</para>
    /// </summary>
    public string[] GetSectionKeys(string section)
    {
        return NativeCalls.godot_icall_1_328(MethodBind5, GodotObject.GetPtr(this), section);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseSection, 83702148ul);

    /// <summary>
    /// <para>Deletes the specified section along with all the key-value pairs inside. Raises an error if the section does not exist.</para>
    /// </summary>
    public void EraseSection(string section)
    {
        NativeCalls.godot_icall_1_57(MethodBind6, GodotObject.GetPtr(this), section);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseSectionKey, 3186203200ul);

    /// <summary>
    /// <para>Deletes the specified key in a section. Raises an error if either the section or the key do not exist.</para>
    /// </summary>
    public void EraseSectionKey(string section, string key)
    {
        NativeCalls.godot_icall_2_303(MethodBind7, GodotObject.GetPtr(this), section, key);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Load, 166001499ul);

    /// <summary>
    /// <para>Loads the config file specified as a parameter. The file's contents are parsed and loaded in the <see cref="Godot.ConfigFile"/> object which the method was called on.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or one of the other <see cref="Godot.Error"/> values if the operation failed.</para>
    /// </summary>
    public Error Load(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind8, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Parse, 166001499ul);

    /// <summary>
    /// <para>Parses the passed string as the contents of a config file. The string is parsed and loaded in the ConfigFile object which the method was called on.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or one of the other <see cref="Godot.Error"/> values if the operation failed.</para>
    /// </summary>
    public Error Parse(string data)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind9, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Save, 166001499ul);

    /// <summary>
    /// <para>Saves the contents of the <see cref="Godot.ConfigFile"/> object to the file specified as a parameter. The output file uses an INI-style structure.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or one of the other <see cref="Godot.Error"/> values if the operation failed.</para>
    /// </summary>
    public Error Save(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind10, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EncodeToText, 201670096ul);

    /// <summary>
    /// <para>Obtain the text version of this config file (the same text that would be written to a file).</para>
    /// </summary>
    public string EncodeToText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadEncrypted, 887037711ul);

    /// <summary>
    /// <para>Loads the encrypted config file specified as a parameter, using the provided <paramref name="key"/> to decrypt it. The file's contents are parsed and loaded in the <see cref="Godot.ConfigFile"/> object which the method was called on.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or one of the other <see cref="Godot.Error"/> values if the operation failed.</para>
    /// </summary>
    public Error LoadEncrypted(string path, byte[] key)
    {
        return (Error)NativeCalls.godot_icall_2_329(MethodBind12, GodotObject.GetPtr(this), path, key);
    }

    /// <summary>
    /// <para>Loads the encrypted config file specified as a parameter, using the provided <paramref name="key"/> to decrypt it. The file's contents are parsed and loaded in the <see cref="Godot.ConfigFile"/> object which the method was called on.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or one of the other <see cref="Godot.Error"/> values if the operation failed.</para>
    /// </summary>
    public Error LoadEncrypted(string path, ReadOnlySpan<byte> key)
    {
        return (Error)NativeCalls.godot_icall_2_329(MethodBind12, GodotObject.GetPtr(this), path, key);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadEncryptedPass, 852856452ul);

    /// <summary>
    /// <para>Loads the encrypted config file specified as a parameter, using the provided <paramref name="password"/> to decrypt it. The file's contents are parsed and loaded in the <see cref="Godot.ConfigFile"/> object which the method was called on.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or one of the other <see cref="Godot.Error"/> values if the operation failed.</para>
    /// </summary>
    public Error LoadEncryptedPass(string path, string password)
    {
        return (Error)NativeCalls.godot_icall_2_330(MethodBind13, GodotObject.GetPtr(this), path, password);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveEncrypted, 887037711ul);

    /// <summary>
    /// <para>Saves the contents of the <see cref="Godot.ConfigFile"/> object to the AES-256 encrypted file specified as a parameter, using the provided <paramref name="key"/> to encrypt it. The output file uses an INI-style structure.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or one of the other <see cref="Godot.Error"/> values if the operation failed.</para>
    /// </summary>
    public Error SaveEncrypted(string path, byte[] key)
    {
        return (Error)NativeCalls.godot_icall_2_329(MethodBind14, GodotObject.GetPtr(this), path, key);
    }

    /// <summary>
    /// <para>Saves the contents of the <see cref="Godot.ConfigFile"/> object to the AES-256 encrypted file specified as a parameter, using the provided <paramref name="key"/> to encrypt it. The output file uses an INI-style structure.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or one of the other <see cref="Godot.Error"/> values if the operation failed.</para>
    /// </summary>
    public Error SaveEncrypted(string path, ReadOnlySpan<byte> key)
    {
        return (Error)NativeCalls.godot_icall_2_329(MethodBind14, GodotObject.GetPtr(this), path, key);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveEncryptedPass, 852856452ul);

    /// <summary>
    /// <para>Saves the contents of the <see cref="Godot.ConfigFile"/> object to the AES-256 encrypted file specified as a parameter, using the provided <paramref name="password"/> to encrypt it. The output file uses an INI-style structure.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or one of the other <see cref="Godot.Error"/> values if the operation failed.</para>
    /// </summary>
    public Error SaveEncryptedPass(string path, string password)
    {
        return (Error)NativeCalls.godot_icall_2_330(MethodBind15, GodotObject.GetPtr(this), path, password);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Removes the entire contents of the config.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind16, GodotObject.GetPtr(this));
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
        /// Cached name for the 'set_value' method.
        /// </summary>
        public static readonly StringName SetValue = "set_value";
        /// <summary>
        /// Cached name for the 'get_value' method.
        /// </summary>
        public static readonly StringName GetValue = "get_value";
        /// <summary>
        /// Cached name for the 'has_section' method.
        /// </summary>
        public static readonly StringName HasSection = "has_section";
        /// <summary>
        /// Cached name for the 'has_section_key' method.
        /// </summary>
        public static readonly StringName HasSectionKey = "has_section_key";
        /// <summary>
        /// Cached name for the 'get_sections' method.
        /// </summary>
        public static readonly StringName GetSections = "get_sections";
        /// <summary>
        /// Cached name for the 'get_section_keys' method.
        /// </summary>
        public static readonly StringName GetSectionKeys = "get_section_keys";
        /// <summary>
        /// Cached name for the 'erase_section' method.
        /// </summary>
        public static readonly StringName EraseSection = "erase_section";
        /// <summary>
        /// Cached name for the 'erase_section_key' method.
        /// </summary>
        public static readonly StringName EraseSectionKey = "erase_section_key";
        /// <summary>
        /// Cached name for the 'load' method.
        /// </summary>
        public static readonly StringName Load = "load";
        /// <summary>
        /// Cached name for the 'parse' method.
        /// </summary>
        public static readonly StringName Parse = "parse";
        /// <summary>
        /// Cached name for the 'save' method.
        /// </summary>
        public static readonly StringName Save = "save";
        /// <summary>
        /// Cached name for the 'encode_to_text' method.
        /// </summary>
        public static readonly StringName EncodeToText = "encode_to_text";
        /// <summary>
        /// Cached name for the 'load_encrypted' method.
        /// </summary>
        public static readonly StringName LoadEncrypted = "load_encrypted";
        /// <summary>
        /// Cached name for the 'load_encrypted_pass' method.
        /// </summary>
        public static readonly StringName LoadEncryptedPass = "load_encrypted_pass";
        /// <summary>
        /// Cached name for the 'save_encrypted' method.
        /// </summary>
        public static readonly StringName SaveEncrypted = "save_encrypted";
        /// <summary>
        /// Cached name for the 'save_encrypted_pass' method.
        /// </summary>
        public static readonly StringName SaveEncryptedPass = "save_encrypted_pass";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
