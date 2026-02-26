namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.Translation"/> maps a collection of strings to their individual translations, and also provides convenience methods for pluralization.</para>
/// <para>A <see cref="Godot.Translation"/> consists of messages. A message is identified by its context and untranslated string. Unlike <a href="https://www.gnu.org/software/gettext/">gettext</a>, using an empty context string in Godot means not using any context.</para>
/// </summary>
public partial class Translation : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary Messages
    {
        get
        {
            return _GetMessages();
        }
        set
        {
            _SetMessages(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>The locale of the translation.</para>
    /// </summary>
    public string Locale
    {
        get
        {
            return GetLocale();
        }
        set
        {
            SetLocale(value);
        }
    }

    /// <summary>
    /// <para>The plural rules string to enforce. See <a href="https://www.gnu.org/software/gettext/manual/html_node/Plural-forms.html">GNU gettext</a> for examples and more info.</para>
    /// <para>If empty or invalid, default plural rules from <see cref="Godot.TranslationServer.GetPluralRules(string)"/> are used. The English plural rules are used as a fallback.</para>
    /// </summary>
    public string PluralRulesOverride
    {
        get
        {
            return GetPluralRulesOverride();
        }
        set
        {
            SetPluralRulesOverride(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Translation);

    private static readonly StringName NativeName = "Translation";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Translation() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Translation(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Translation(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Virtual method to override <see cref="Godot.Translation.GetMessage(StringName, StringName)"/>.</para>
    /// </summary>
    public virtual StringName _GetMessage(StringName srcMessage, StringName context)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override <see cref="Godot.Translation.GetPluralMessage(StringName, StringName, int, StringName)"/>.</para>
    /// </summary>
    public virtual StringName _GetPluralMessage(StringName srcMessage, StringName srcPluralMessage, int n, StringName context)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLocale, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLocale(string locale)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), locale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocale, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLocale()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMessage, 3898530326ul);

    /// <summary>
    /// <para>Adds a message if nonexistent, followed by its translation.</para>
    /// <para>An additional context could be used to specify the translation context or differentiate polysemic words.</para>
    /// </summary>
    public void AddMessage(StringName srcMessage, StringName xlatedMessage, StringName context = null)
    {
        NativeCalls.godot_icall_3_1411(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(srcMessage?.NativeValue ?? default), (godot_string_name)(xlatedMessage?.NativeValue ?? default), (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPluralMessage, 2356982266ul);

    /// <summary>
    /// <para>Adds a message involving plural translation if nonexistent, followed by its translation.</para>
    /// <para>An additional context could be used to specify the translation context or differentiate polysemic words.</para>
    /// </summary>
    public void AddPluralMessage(StringName srcMessage, string[] xlatedMessages, StringName context = null)
    {
        NativeCalls.godot_icall_3_1466(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(srcMessage?.NativeValue ?? default), xlatedMessages, (godot_string_name)(context?.NativeValue ?? default));
    }

    /// <summary>
    /// <para>Adds a message involving plural translation if nonexistent, followed by its translation.</para>
    /// <para>An additional context could be used to specify the translation context or differentiate polysemic words.</para>
    /// </summary>
    public void AddPluralMessage(StringName srcMessage, ReadOnlySpan<string> xlatedMessages, StringName context)
    {
        NativeCalls.godot_icall_3_1466(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(srcMessage?.NativeValue ?? default), xlatedMessages, (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMessage, 1829228469ul);

    /// <summary>
    /// <para>Returns a message's translation.</para>
    /// </summary>
    public StringName GetMessage(StringName srcMessage, StringName context = null)
    {
        return NativeCalls.godot_icall_2_292(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(srcMessage?.NativeValue ?? default), (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPluralMessage, 229954002ul);

    /// <summary>
    /// <para>Returns a message's translation involving plurals.</para>
    /// <para>The number <paramref name="n"/> is the number or quantity of the plural object. It will be used to guide the translation system to fetch the correct plural form for the selected language.</para>
    /// <para><b>Note:</b> Plurals are only supported in <a href="$DOCS_URL/tutorials/i18n/localization_using_gettext.html">gettext-based translations (PO)</a>, not CSV.</para>
    /// </summary>
    public StringName GetPluralMessage(StringName srcMessage, StringName srcPluralMessage, int n, StringName context = null)
    {
        return NativeCalls.godot_icall_4_1467(MethodBind5, GodotObject.GetPtr(this), (godot_string_name)(srcMessage?.NativeValue ?? default), (godot_string_name)(srcPluralMessage?.NativeValue ?? default), n, (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseMessage, 3959009644ul);

    /// <summary>
    /// <para>Erases a message.</para>
    /// </summary>
    public void EraseMessage(StringName srcMessage, StringName context = null)
    {
        NativeCalls.godot_icall_2_118(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(srcMessage?.NativeValue ?? default), (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMessageList, 1139954409ul);

    /// <summary>
    /// <para>Returns the keys of all messages, that is, the context and untranslated strings of each message.</para>
    /// <para><b>Note:</b> If a message does not use a context, the corresponding element is the untranslated string. Otherwise, the corresponding element is the context and untranslated string separated by the EOT character (<c>U+0004</c>). This is done for compatibility purposes.</para>
    /// <para><code>
    /// for key in translation.get_message_list():
    /// 	var p = key.find("\u0004")
    /// 	if p == -1:
    /// 		var untranslated = key
    /// 		print("Message %s" % untranslated)
    /// 	else:
    /// 		var context = key.substr(0, p)
    /// 		var untranslated = key.substr(p + 1)
    /// 		print("Message %s with context %s" % [untranslated, context])
    /// </code></para>
    /// </summary>
    public string[] GetMessageList()
    {
        return NativeCalls.godot_icall_0_108(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTranslatedMessageList, 1139954409ul);

    /// <summary>
    /// <para>Returns all the translated strings.</para>
    /// </summary>
    public string[] GetTranslatedMessageList()
    {
        return NativeCalls.godot_icall_0_108(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMessageCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of existing messages.</para>
    /// </summary>
    public int GetMessageCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetMessages, 4155329257ul);

    internal void _SetMessages(Godot.Collections.Dictionary messages)
    {
        NativeCalls.godot_icall_1_121(MethodBind10, GodotObject.GetPtr(this), (godot_dictionary)(messages ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetMessages, 3102165223ul);

    internal Godot.Collections.Dictionary _GetMessages()
    {
        return NativeCalls.godot_icall_0_122(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPluralRulesOverride, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPluralRulesOverride(string rules)
    {
        NativeCalls.godot_icall_1_57(MethodBind12, GodotObject.GetPtr(this), rules);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPluralRulesOverride, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetPluralRulesOverride()
    {
        return NativeCalls.godot_icall_0_58(MethodBind13, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_message = "_GetMessage";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_plural_message = "_GetPluralMessage";

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
        if ((method == MethodProxyName__get_message || method == MethodName._GetMessage) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_message.NativeValue))
        {
            var callRet = _GetMessage(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]));
            ret = VariantUtils.CreateFrom<StringName>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_plural_message || method == MethodName._GetPluralMessage) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_plural_message.NativeValue))
        {
            var callRet = _GetPluralMessage(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]), VariantUtils.ConvertTo<int>(args[2]), VariantUtils.ConvertTo<StringName>(args[3]));
            ret = VariantUtils.CreateFrom<StringName>(callRet);
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
        if (method == MethodName._GetMessage)
        {
            if (HasGodotClassMethod(MethodProxyName__get_message.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPluralMessage)
        {
            if (HasGodotClassMethod(MethodProxyName__get_plural_message.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'messages' property.
        /// </summary>
        public static readonly StringName Messages = "messages";
        /// <summary>
        /// Cached name for the 'locale' property.
        /// </summary>
        public static readonly StringName Locale = "locale";
        /// <summary>
        /// Cached name for the 'plural_rules_override' property.
        /// </summary>
        public static readonly StringName PluralRulesOverride = "plural_rules_override";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_message' method.
        /// </summary>
        public static readonly StringName _GetMessage = "_get_message";
        /// <summary>
        /// Cached name for the '_get_plural_message' method.
        /// </summary>
        public static readonly StringName _GetPluralMessage = "_get_plural_message";
        /// <summary>
        /// Cached name for the 'set_locale' method.
        /// </summary>
        public static readonly StringName SetLocale = "set_locale";
        /// <summary>
        /// Cached name for the 'get_locale' method.
        /// </summary>
        public static readonly StringName GetLocale = "get_locale";
        /// <summary>
        /// Cached name for the 'add_message' method.
        /// </summary>
        public static readonly StringName AddMessage = "add_message";
        /// <summary>
        /// Cached name for the 'add_plural_message' method.
        /// </summary>
        public static readonly StringName AddPluralMessage = "add_plural_message";
        /// <summary>
        /// Cached name for the 'get_message' method.
        /// </summary>
        public static readonly StringName GetMessage = "get_message";
        /// <summary>
        /// Cached name for the 'get_plural_message' method.
        /// </summary>
        public static readonly StringName GetPluralMessage = "get_plural_message";
        /// <summary>
        /// Cached name for the 'erase_message' method.
        /// </summary>
        public static readonly StringName EraseMessage = "erase_message";
        /// <summary>
        /// Cached name for the 'get_message_list' method.
        /// </summary>
        public static readonly StringName GetMessageList = "get_message_list";
        /// <summary>
        /// Cached name for the 'get_translated_message_list' method.
        /// </summary>
        public static readonly StringName GetTranslatedMessageList = "get_translated_message_list";
        /// <summary>
        /// Cached name for the 'get_message_count' method.
        /// </summary>
        public static readonly StringName GetMessageCount = "get_message_count";
        /// <summary>
        /// Cached name for the '_set_messages' method.
        /// </summary>
        public static readonly StringName _SetMessages = "_set_messages";
        /// <summary>
        /// Cached name for the '_get_messages' method.
        /// </summary>
        public static readonly StringName _GetMessages = "_get_messages";
        /// <summary>
        /// Cached name for the 'set_plural_rules_override' method.
        /// </summary>
        public static readonly StringName SetPluralRulesOverride = "set_plural_rules_override";
        /// <summary>
        /// Cached name for the 'get_plural_rules_override' method.
        /// </summary>
        public static readonly StringName GetPluralRulesOverride = "get_plural_rules_override";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
