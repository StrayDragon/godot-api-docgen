namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The translation server is the API backend that manages all language translations.</para>
/// <para>Translations are stored in <see cref="Godot.TranslationDomain"/>s, which can be accessed by name. The most commonly used translation domain is the main translation domain. It always exists and can be accessed using an empty <see cref="Godot.StringName"/>. The translation server provides wrapper methods for accessing the main translation domain directly, without having to fetch the translation domain first. Custom translation domains are mainly for advanced usages like editor plugins. Names starting with <c>godot.</c> are reserved for engine internals.</para>
/// </summary>
public static partial class TranslationServer
{
    /// <summary>
    /// <para>If <see langword="true"/>, enables the use of pseudolocalization on the main translation domain. See <c>ProjectSettings.internationalization/pseudolocalization/use_pseudolocalization</c> for details.</para>
    /// </summary>
    public static bool PseudolocalizationEnabled
    {
        get
        {
            return IsPseudolocalizationEnabled();
        }
        set
        {
            SetPseudolocalizationEnabled(value);
        }
    }

    private static readonly StringName NativeName = "TranslationServer";

    private static TranslationServerInstance singleton;

    public static TranslationServerInstance Singleton =>
        singleton ??= (TranslationServerInstance)InteropUtils.EngineGetSingleton("TranslationServer");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLocale, 83702148ul);

    /// <summary>
    /// <para>Sets the locale of the project. The <paramref name="locale"/> string will be standardized to match known locales (e.g. <c>en-US</c> would be matched to <c>en_US</c>).</para>
    /// <para>If translations have been loaded beforehand for the new locale, they will be applied.</para>
    /// </summary>
    public static void SetLocale(string locale)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(Singleton), locale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocale, 201670096ul);

    /// <summary>
    /// <para>Returns the current locale of the project.</para>
    /// <para>See also <see cref="Godot.OS.GetLocale()"/> and <see cref="Godot.OS.GetLocaleLanguage()"/> to query the locale of the user system.</para>
    /// </summary>
    public static string GetLocale()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetToolLocale, 2841200299ul);

    /// <summary>
    /// <para>Returns the current locale of the editor.</para>
    /// <para><b>Note:</b> When called from an exported project returns the same value as <see cref="Godot.TranslationServer.GetLocale()"/>.</para>
    /// </summary>
    public static string GetToolLocale()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CompareLocales, 2878152881ul);

    /// <summary>
    /// <para>Compares two locales and returns a similarity score between <c>0</c> (no match) and <c>10</c> (full match).</para>
    /// </summary>
    public static int CompareLocales(string localeA, string localeB)
    {
        return NativeCalls.godot_icall_2_330(MethodBind3, GodotObject.GetPtr(Singleton), localeA, localeB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.StandardizeLocale, 4216441673ul);

    /// <summary>
    /// <para>Returns a <paramref name="locale"/> string standardized to match known locales (e.g. <c>en-US</c> would be matched to <c>en_US</c>). If <paramref name="addDefaults"/> is <see langword="true"/>, the locale may have a default script or country added.</para>
    /// </summary>
    public static string StandardizeLocale(string locale, bool addDefaults = false)
    {
        return NativeCalls.godot_icall_2_1470(MethodBind4, GodotObject.GetPtr(Singleton), locale, addDefaults.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllLanguages, 1139954409ul);

    /// <summary>
    /// <para>Returns array of known language codes.</para>
    /// </summary>
    public static string[] GetAllLanguages()
    {
        return NativeCalls.godot_icall_0_108(MethodBind5, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguageName, 3135753539ul);

    /// <summary>
    /// <para>Returns a readable language name for the <paramref name="language"/> code.</para>
    /// </summary>
    public static string GetLanguageName(string language)
    {
        return NativeCalls.godot_icall_1_304(MethodBind6, GodotObject.GetPtr(Singleton), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllScripts, 1139954409ul);

    /// <summary>
    /// <para>Returns an array of known script codes.</para>
    /// </summary>
    public static string[] GetAllScripts()
    {
        return NativeCalls.godot_icall_0_108(MethodBind7, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptName, 3135753539ul);

    /// <summary>
    /// <para>Returns a readable script name for the <paramref name="script"/> code.</para>
    /// </summary>
    public static string GetScriptName(string script)
    {
        return NativeCalls.godot_icall_1_304(MethodBind8, GodotObject.GetPtr(Singleton), script);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllCountries, 1139954409ul);

    /// <summary>
    /// <para>Returns an array of known country codes.</para>
    /// </summary>
    public static string[] GetAllCountries()
    {
        return NativeCalls.godot_icall_0_108(MethodBind9, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCountryName, 3135753539ul);

    /// <summary>
    /// <para>Returns a readable country name for the <paramref name="country"/> code.</para>
    /// </summary>
    public static string GetCountryName(string country)
    {
        return NativeCalls.godot_icall_1_304(MethodBind10, GodotObject.GetPtr(Singleton), country);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocaleName, 3135753539ul);

    /// <summary>
    /// <para>Returns a locale's language and its variant (e.g. <c>"en_US"</c> would return <c>"English (United States)"</c>).</para>
    /// </summary>
    public static string GetLocaleName(string locale)
    {
        return NativeCalls.godot_icall_1_304(MethodBind11, GodotObject.GetPtr(Singleton), locale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPluralRules, 3135753539ul);

    /// <summary>
    /// <para>Returns the default plural rules for the <paramref name="locale"/>.</para>
    /// </summary>
    public static string GetPluralRules(string locale)
    {
        return NativeCalls.godot_icall_1_304(MethodBind12, GodotObject.GetPtr(Singleton), locale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Translate, 1829228469ul);

    /// <summary>
    /// <para>Returns the current locale's translation for the given message and context.</para>
    /// <para><b>Note:</b> This method always uses the main translation domain.</para>
    /// </summary>
    public static StringName Translate(StringName message, StringName context = null)
    {
        return NativeCalls.godot_icall_2_292(MethodBind13, GodotObject.GetPtr(Singleton), (godot_string_name)(message?.NativeValue ?? default), (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TranslatePlural, 229954002ul);

    /// <summary>
    /// <para>Returns the current locale's translation for the given message, plural message and context.</para>
    /// <para>The number <paramref name="n"/> is the number or quantity of the plural object. It will be used to guide the translation system to fetch the correct plural form for the selected language.</para>
    /// <para><b>Note:</b> This method always uses the main translation domain.</para>
    /// </summary>
    public static StringName TranslatePlural(StringName message, StringName pluralMessage, int n, StringName context = null)
    {
        return NativeCalls.godot_icall_4_1467(MethodBind14, GodotObject.GetPtr(Singleton), (godot_string_name)(message?.NativeValue ?? default), (godot_string_name)(pluralMessage?.NativeValue ?? default), n, (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTranslation, 1466479800ul);

    /// <summary>
    /// <para>Adds a translation to the main translation domain.</para>
    /// </summary>
    public static void AddTranslation(Translation translation)
    {
        NativeCalls.godot_icall_1_56(MethodBind15, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(translation));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTranslation, 1466479800ul);

    /// <summary>
    /// <para>Removes the given translation from the main translation domain.</para>
    /// </summary>
    public static void RemoveTranslation(Translation translation)
    {
        NativeCalls.godot_icall_1_56(MethodBind16, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(translation));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTranslationObject, 2065240175ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Translation"/> instance that best matches <paramref name="locale"/> in the main translation domain. Returns <see langword="null"/> if there are no matches.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TranslationServer.FindTranslations(string, bool)' instead.")]
    public static Translation GetTranslationObject(string locale)
    {
        return (Translation)NativeCalls.godot_icall_1_533(MethodBind17, GodotObject.GetPtr(Singleton), locale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTranslations, 3995934104ul);

    /// <summary>
    /// <para>Returns all available <see cref="Godot.Translation"/> instances in the main translation domain as added by <see cref="Godot.TranslationServer.AddTranslation(Translation)"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Translation> GetTranslations()
    {
        return new Godot.Collections.Array<Translation>(NativeCalls.godot_icall_0_120(MethodBind18, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FindTranslations, 2109650934ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Translation"/> instances in the main translation domain that match <paramref name="locale"/> (see <see cref="Godot.TranslationServer.CompareLocales(string, string)"/>). If <paramref name="exact"/> is <see langword="true"/>, only instances whose locale exactly equals <paramref name="locale"/> will be returned.</para>
    /// </summary>
    public static Godot.Collections.Array<Translation> FindTranslations(string locale, bool exact)
    {
        return new Godot.Collections.Array<Translation>(NativeCalls.godot_icall_2_1469(MethodBind19, GodotObject.GetPtr(Singleton), locale, exact.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasTranslationForLocale, 2034713381ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there are any <see cref="Godot.Translation"/> instances in the main translation domain that match <paramref name="locale"/> (see <see cref="Godot.TranslationServer.CompareLocales(string, string)"/>). If <paramref name="exact"/> is <see langword="true"/>, only instances whose locale exactly equals <paramref name="locale"/> are considered.</para>
    /// </summary>
    public static bool HasTranslationForLocale(string locale, bool exact)
    {
        return NativeCalls.godot_icall_2_1468(MethodBind20, GodotObject.GetPtr(Singleton), locale, exact.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasTranslation, 2696976312ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the main translation domain contains the given <paramref name="translation"/>.</para>
    /// </summary>
    public static bool HasTranslation(Translation translation)
    {
        return NativeCalls.godot_icall_1_176(MethodBind21, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(translation)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasDomain, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a translation domain with the specified name exists.</para>
    /// </summary>
    public static bool HasDomain(StringName domain)
    {
        return NativeCalls.godot_icall_1_105(MethodBind22, GodotObject.GetPtr(Singleton), (godot_string_name)(domain?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOrAddDomain, 397200075ul);

    /// <summary>
    /// <para>Returns the translation domain with the specified name. An empty translation domain will be created and added if it does not exist.</para>
    /// </summary>
    public static TranslationDomain GetOrAddDomain(StringName domain)
    {
        return (TranslationDomain)NativeCalls.godot_icall_1_119(MethodBind23, GodotObject.GetPtr(Singleton), (godot_string_name)(domain?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveDomain, 3304788590ul);

    /// <summary>
    /// <para>Removes the translation domain with the specified name.</para>
    /// <para><b>Note:</b> Trying to remove the main translation domain is an error.</para>
    /// </summary>
    public static void RemoveDomain(StringName domain)
    {
        NativeCalls.godot_icall_1_64(MethodBind24, GodotObject.GetPtr(Singleton), (godot_string_name)(domain?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Removes all translations from the main translation domain.</para>
    /// </summary>
    public static void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind25, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoadedLocales, 1139954409ul);

    /// <summary>
    /// <para>Returns an array of all loaded locales of the project.</para>
    /// </summary>
    public static string[] GetLoadedLocales()
    {
        return NativeCalls.godot_icall_0_108(MethodBind26, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FormatNumber, 315676799ul);

    /// <summary>
    /// <para>Converts a number from Western Arabic (0..9) to the numeral system used in the given <paramref name="locale"/>.</para>
    /// </summary>
    public static string FormatNumber(string number, string locale)
    {
        return NativeCalls.godot_icall_2_1398(MethodBind27, GodotObject.GetPtr(Singleton), number, locale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPercentSign, 3135753539ul);

    /// <summary>
    /// <para>Returns the percent sign used in the given <paramref name="locale"/>.</para>
    /// </summary>
    public static string GetPercentSign(string locale)
    {
        return NativeCalls.godot_icall_1_304(MethodBind28, GodotObject.GetPtr(Singleton), locale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParseNumber, 315676799ul);

    /// <summary>
    /// <para>Converts <paramref name="number"/> from the numeral system used in the given <paramref name="locale"/> to Western Arabic (0..9).</para>
    /// </summary>
    public static string ParseNumber(string number, string locale)
    {
        return NativeCalls.godot_icall_2_1398(MethodBind29, GodotObject.GetPtr(Singleton), number, locale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPseudolocalizationEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsPseudolocalizationEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind30, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPseudolocalizationEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetPseudolocalizationEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind31, GodotObject.GetPtr(Singleton), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ReloadPseudolocalization, 3218959716ul);

    /// <summary>
    /// <para>Reparses the pseudolocalization options and reloads the translation for the main translation domain.</para>
    /// </summary>
    public static void ReloadPseudolocalization()
    {
        NativeCalls.godot_icall_0_3(MethodBind32, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Pseudolocalize, 1965194235ul);

    /// <summary>
    /// <para>Returns the pseudolocalized string based on the <paramref name="message"/> passed in.</para>
    /// <para><b>Note:</b> This method always uses the main translation domain.</para>
    /// </summary>
    public static StringName Pseudolocalize(StringName message)
    {
        return NativeCalls.godot_icall_1_164(MethodBind33, GodotObject.GetPtr(Singleton), (godot_string_name)(message?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.StandardizeLocale, 3135753539ul);

    /// <summary>
    /// <para>Returns a <paramref name="locale"/> string standardized to match known locales (e.g. <c>en-US</c> would be matched to <c>en_US</c>). If <paramref name="addDefaults"/> is <see langword="true"/>, the locale may have a default script or country added.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string StandardizeLocale(string locale)
    {
        return NativeCalls.godot_icall_1_304(MethodBind34, GodotObject.GetPtr(Singleton), locale);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
        /// <summary>
        /// Cached name for the 'pseudolocalization_enabled' property.
        /// </summary>
        public static readonly StringName PseudolocalizationEnabled = "pseudolocalization_enabled";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'set_locale' method.
        /// </summary>
        public static readonly StringName SetLocale = "set_locale";
        /// <summary>
        /// Cached name for the 'get_locale' method.
        /// </summary>
        public static readonly StringName GetLocale = "get_locale";
        /// <summary>
        /// Cached name for the 'get_tool_locale' method.
        /// </summary>
        public static readonly StringName GetToolLocale = "get_tool_locale";
        /// <summary>
        /// Cached name for the 'compare_locales' method.
        /// </summary>
        public static readonly StringName CompareLocales = "compare_locales";
        /// <summary>
        /// Cached name for the 'standardize_locale' method.
        /// </summary>
        public static readonly StringName StandardizeLocale = "standardize_locale";
        /// <summary>
        /// Cached name for the 'get_all_languages' method.
        /// </summary>
        public static readonly StringName GetAllLanguages = "get_all_languages";
        /// <summary>
        /// Cached name for the 'get_language_name' method.
        /// </summary>
        public static readonly StringName GetLanguageName = "get_language_name";
        /// <summary>
        /// Cached name for the 'get_all_scripts' method.
        /// </summary>
        public static readonly StringName GetAllScripts = "get_all_scripts";
        /// <summary>
        /// Cached name for the 'get_script_name' method.
        /// </summary>
        public static readonly StringName GetScriptName = "get_script_name";
        /// <summary>
        /// Cached name for the 'get_all_countries' method.
        /// </summary>
        public static readonly StringName GetAllCountries = "get_all_countries";
        /// <summary>
        /// Cached name for the 'get_country_name' method.
        /// </summary>
        public static readonly StringName GetCountryName = "get_country_name";
        /// <summary>
        /// Cached name for the 'get_locale_name' method.
        /// </summary>
        public static readonly StringName GetLocaleName = "get_locale_name";
        /// <summary>
        /// Cached name for the 'get_plural_rules' method.
        /// </summary>
        public static readonly StringName GetPluralRules = "get_plural_rules";
        /// <summary>
        /// Cached name for the 'translate' method.
        /// </summary>
        public static readonly StringName Translate = "translate";
        /// <summary>
        /// Cached name for the 'translate_plural' method.
        /// </summary>
        public static readonly StringName TranslatePlural = "translate_plural";
        /// <summary>
        /// Cached name for the 'add_translation' method.
        /// </summary>
        public static readonly StringName AddTranslation = "add_translation";
        /// <summary>
        /// Cached name for the 'remove_translation' method.
        /// </summary>
        public static readonly StringName RemoveTranslation = "remove_translation";
        /// <summary>
        /// Cached name for the 'get_translation_object' method.
        /// </summary>
        public static readonly StringName GetTranslationObject = "get_translation_object";
        /// <summary>
        /// Cached name for the 'get_translations' method.
        /// </summary>
        public static readonly StringName GetTranslations = "get_translations";
        /// <summary>
        /// Cached name for the 'find_translations' method.
        /// </summary>
        public static readonly StringName FindTranslations = "find_translations";
        /// <summary>
        /// Cached name for the 'has_translation_for_locale' method.
        /// </summary>
        public static readonly StringName HasTranslationForLocale = "has_translation_for_locale";
        /// <summary>
        /// Cached name for the 'has_translation' method.
        /// </summary>
        public static readonly StringName HasTranslation = "has_translation";
        /// <summary>
        /// Cached name for the 'has_domain' method.
        /// </summary>
        public static readonly StringName HasDomain = "has_domain";
        /// <summary>
        /// Cached name for the 'get_or_add_domain' method.
        /// </summary>
        public static readonly StringName GetOrAddDomain = "get_or_add_domain";
        /// <summary>
        /// Cached name for the 'remove_domain' method.
        /// </summary>
        public static readonly StringName RemoveDomain = "remove_domain";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'get_loaded_locales' method.
        /// </summary>
        public static readonly StringName GetLoadedLocales = "get_loaded_locales";
        /// <summary>
        /// Cached name for the 'format_number' method.
        /// </summary>
        public static readonly StringName FormatNumber = "format_number";
        /// <summary>
        /// Cached name for the 'get_percent_sign' method.
        /// </summary>
        public static readonly StringName GetPercentSign = "get_percent_sign";
        /// <summary>
        /// Cached name for the 'parse_number' method.
        /// </summary>
        public static readonly StringName ParseNumber = "parse_number";
        /// <summary>
        /// Cached name for the 'is_pseudolocalization_enabled' method.
        /// </summary>
        public static readonly StringName IsPseudolocalizationEnabled = "is_pseudolocalization_enabled";
        /// <summary>
        /// Cached name for the 'set_pseudolocalization_enabled' method.
        /// </summary>
        public static readonly StringName SetPseudolocalizationEnabled = "set_pseudolocalization_enabled";
        /// <summary>
        /// Cached name for the 'reload_pseudolocalization' method.
        /// </summary>
        public static readonly StringName ReloadPseudolocalization = "reload_pseudolocalization";
        /// <summary>
        /// Cached name for the 'pseudolocalize' method.
        /// </summary>
        public static readonly StringName Pseudolocalize = "pseudolocalize";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
