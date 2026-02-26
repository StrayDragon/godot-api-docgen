namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.TranslationDomain"/> is a self-contained collection of <see cref="Godot.Translation"/> resources. Translations can be added to or removed from it.</para>
/// <para>If you're working with the main translation domain, it is more convenient to use the wrap methods on <see cref="Godot.TranslationServer"/>.</para>
/// </summary>
public partial class TranslationDomain : RefCounted
{
    /// <summary>
    /// <para>If <see langword="true"/>, translation is enabled. Otherwise, <see cref="Godot.TranslationDomain.Translate(StringName, StringName)"/> and <see cref="Godot.TranslationDomain.TranslatePlural(StringName, StringName, int, StringName)"/> will return the input message unchanged regardless of the current locale.</para>
    /// </summary>
    public bool Enabled
    {
        get
        {
            return IsEnabled();
        }
        set
        {
            SetEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables pseudolocalization for the project. This can be used to spot untranslatable strings or layout issues that may occur once the project is localized to languages that have longer strings than the source language.</para>
    /// <para><b>Note:</b> Updating this property does not automatically update texts in the scene tree. Please propagate the <see cref="Godot.MainLoop.NotificationTranslationChanged"/> notification manually after you have finished modifying pseudolocalization related options.</para>
    /// </summary>
    public bool PseudolocalizationEnabled
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

    /// <summary>
    /// <para>Replace all characters with their accented variants during pseudolocalization.</para>
    /// <para><b>Note:</b> Updating this property does not automatically update texts in the scene tree. Please propagate the <see cref="Godot.MainLoop.NotificationTranslationChanged"/> notification manually after you have finished modifying pseudolocalization related options.</para>
    /// </summary>
    public bool PseudolocalizationAccentsEnabled
    {
        get
        {
            return IsPseudolocalizationAccentsEnabled();
        }
        set
        {
            SetPseudolocalizationAccentsEnabled(value);
        }
    }

    /// <summary>
    /// <para>Double vowels in strings during pseudolocalization to simulate the lengthening of text due to localization.</para>
    /// <para><b>Note:</b> Updating this property does not automatically update texts in the scene tree. Please propagate the <see cref="Godot.MainLoop.NotificationTranslationChanged"/> notification manually after you have finished modifying pseudolocalization related options.</para>
    /// </summary>
    public bool PseudolocalizationDoubleVowelsEnabled
    {
        get
        {
            return IsPseudolocalizationDoubleVowelsEnabled();
        }
        set
        {
            SetPseudolocalizationDoubleVowelsEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, emulate bidirectional (right-to-left) text when pseudolocalization is enabled. This can be used to spot issues with RTL layout and UI mirroring that will crop up if the project is localized to RTL languages such as Arabic or Hebrew.</para>
    /// <para><b>Note:</b> Updating this property does not automatically update texts in the scene tree. Please propagate the <see cref="Godot.MainLoop.NotificationTranslationChanged"/> notification manually after you have finished modifying pseudolocalization related options.</para>
    /// </summary>
    public bool PseudolocalizationFakeBidiEnabled
    {
        get
        {
            return IsPseudolocalizationFakeBidiEnabled();
        }
        set
        {
            SetPseudolocalizationFakeBidiEnabled(value);
        }
    }

    /// <summary>
    /// <para>Replace all characters in the string with <c>*</c>. Useful for finding non-localizable strings.</para>
    /// <para><b>Note:</b> Updating this property does not automatically update texts in the scene tree. Please propagate the <see cref="Godot.MainLoop.NotificationTranslationChanged"/> notification manually after you have finished modifying pseudolocalization related options.</para>
    /// </summary>
    public bool PseudolocalizationOverrideEnabled
    {
        get
        {
            return IsPseudolocalizationOverrideEnabled();
        }
        set
        {
            SetPseudolocalizationOverrideEnabled(value);
        }
    }

    /// <summary>
    /// <para>Skip placeholders for string formatting like <c>%s</c> or <c>%f</c> during pseudolocalization. Useful to identify strings which need additional control characters to display correctly.</para>
    /// <para><b>Note:</b> Updating this property does not automatically update texts in the scene tree. Please propagate the <see cref="Godot.MainLoop.NotificationTranslationChanged"/> notification manually after you have finished modifying pseudolocalization related options.</para>
    /// </summary>
    public bool PseudolocalizationSkipPlaceholdersEnabled
    {
        get
        {
            return IsPseudolocalizationSkipPlaceholdersEnabled();
        }
        set
        {
            SetPseudolocalizationSkipPlaceholdersEnabled(value);
        }
    }

    /// <summary>
    /// <para>The expansion ratio to use during pseudolocalization. A value of <c>0.3</c> is sufficient for most practical purposes, and will increase the length of each string by 30%.</para>
    /// <para><b>Note:</b> Updating this property does not automatically update texts in the scene tree. Please propagate the <see cref="Godot.MainLoop.NotificationTranslationChanged"/> notification manually after you have finished modifying pseudolocalization related options.</para>
    /// </summary>
    public float PseudolocalizationExpansionRatio
    {
        get
        {
            return GetPseudolocalizationExpansionRatio();
        }
        set
        {
            SetPseudolocalizationExpansionRatio(value);
        }
    }

    /// <summary>
    /// <para>Prefix that will be prepended to the pseudolocalized string.</para>
    /// <para><b>Note:</b> Updating this property does not automatically update texts in the scene tree. Please propagate the <see cref="Godot.MainLoop.NotificationTranslationChanged"/> notification manually after you have finished modifying pseudolocalization related options.</para>
    /// </summary>
    public string PseudolocalizationPrefix
    {
        get
        {
            return GetPseudolocalizationPrefix();
        }
        set
        {
            SetPseudolocalizationPrefix(value);
        }
    }

    /// <summary>
    /// <para>Suffix that will be appended to the pseudolocalized string.</para>
    /// <para><b>Note:</b> Updating this property does not automatically update texts in the scene tree. Please propagate the <see cref="Godot.MainLoop.NotificationTranslationChanged"/> notification manually after you have finished modifying pseudolocalization related options.</para>
    /// </summary>
    public string PseudolocalizationSuffix
    {
        get
        {
            return GetPseudolocalizationSuffix();
        }
        set
        {
            SetPseudolocalizationSuffix(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TranslationDomain);

    private static readonly StringName NativeName = "TranslationDomain";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TranslationDomain() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TranslationDomain(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TranslationDomain(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTranslationObject, 606768082ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Translation"/> instance that best matches <paramref name="locale"/>. Returns <see langword="null"/> if there are no matches.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TranslationDomain.FindTranslations(string, bool)' instead.")]
    public Translation GetTranslationObject(string locale)
    {
        return (Translation)NativeCalls.godot_icall_1_533(MethodBind0, GodotObject.GetPtr(this), locale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTranslation, 1466479800ul);

    /// <summary>
    /// <para>Adds a translation.</para>
    /// </summary>
    public void AddTranslation(Translation translation)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(translation));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTranslation, 1466479800ul);

    /// <summary>
    /// <para>Removes the given translation.</para>
    /// </summary>
    public void RemoveTranslation(Translation translation)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(translation));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Removes all translations.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTranslations, 3995934104ul);

    /// <summary>
    /// <para>Returns all available <see cref="Godot.Translation"/> instances as added by <see cref="Godot.TranslationDomain.AddTranslation(Translation)"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Translation> GetTranslations()
    {
        return new Godot.Collections.Array<Translation>(NativeCalls.godot_icall_0_120(MethodBind4, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasTranslationForLocale, 2034713381ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there are any <see cref="Godot.Translation"/> instances that match <paramref name="locale"/> (see <see cref="Godot.TranslationServer.CompareLocales(string, string)"/>). If <paramref name="exact"/> is <see langword="true"/>, only instances whose locale exactly equals <paramref name="locale"/> are considered.</para>
    /// </summary>
    public bool HasTranslationForLocale(string locale, bool exact)
    {
        return NativeCalls.godot_icall_2_1468(MethodBind5, GodotObject.GetPtr(this), locale, exact.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasTranslation, 2696976312ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this translation domain contains the given <paramref name="translation"/>.</para>
    /// </summary>
    public bool HasTranslation(Translation translation)
    {
        return NativeCalls.godot_icall_1_176(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(translation)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindTranslations, 2109650934ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Translation"/> instances that match <paramref name="locale"/> (see <see cref="Godot.TranslationServer.CompareLocales(string, string)"/>). If <paramref name="exact"/> is <see langword="true"/>, only instances whose locale exactly equals <paramref name="locale"/> will be returned.</para>
    /// </summary>
    public Godot.Collections.Array<Translation> FindTranslations(string locale, bool exact)
    {
        return new Godot.Collections.Array<Translation>(NativeCalls.godot_icall_2_1469(MethodBind7, GodotObject.GetPtr(this), locale, exact.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Translate, 1829228469ul);

    /// <summary>
    /// <para>Returns the current locale's translation for the given message and context.</para>
    /// </summary>
    public StringName Translate(StringName message, StringName context = null)
    {
        return NativeCalls.godot_icall_2_292(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(message?.NativeValue ?? default), (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TranslatePlural, 229954002ul);

    /// <summary>
    /// <para>Returns the current locale's translation for the given message, plural message and context.</para>
    /// <para>The number <paramref name="n"/> is the number or quantity of the plural object. It will be used to guide the translation system to fetch the correct plural form for the selected language.</para>
    /// </summary>
    public StringName TranslatePlural(StringName message, StringName messagePlural, int n, StringName context = null)
    {
        return NativeCalls.godot_icall_4_1467(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(message?.NativeValue ?? default), (godot_string_name)(messagePlural?.NativeValue ?? default), n, (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocaleOverride, 201670096ul);

    /// <summary>
    /// <para>Returns the locale override of the domain. Returns an empty string if locale override is disabled.</para>
    /// </summary>
    public string GetLocaleOverride()
    {
        return NativeCalls.godot_icall_0_58(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLocaleOverride, 83702148ul);

    /// <summary>
    /// <para>Sets the locale override of the domain.</para>
    /// <para>If <paramref name="locale"/> is an empty string, locale override is disabled. Otherwise, <paramref name="locale"/> will be standardized to match known locales (e.g. <c>en-US</c> would be matched to <c>en_US</c>).</para>
    /// <para><b>Note:</b> Calling this method does not automatically update texts in the scene tree. Please propagate the <see cref="Godot.MainLoop.NotificationTranslationChanged"/> signal manually.</para>
    /// </summary>
    public void SetLocaleOverride(string locale)
    {
        NativeCalls.godot_icall_1_57(MethodBind11, GodotObject.GetPtr(this), locale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind13, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPseudolocalizationEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPseudolocalizationEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPseudolocalizationEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPseudolocalizationEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPseudolocalizationAccentsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPseudolocalizationAccentsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPseudolocalizationAccentsEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPseudolocalizationAccentsEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPseudolocalizationDoubleVowelsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPseudolocalizationDoubleVowelsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPseudolocalizationDoubleVowelsEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPseudolocalizationDoubleVowelsEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPseudolocalizationFakeBidiEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPseudolocalizationFakeBidiEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPseudolocalizationFakeBidiEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPseudolocalizationFakeBidiEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind21, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPseudolocalizationOverrideEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPseudolocalizationOverrideEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind22, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPseudolocalizationOverrideEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPseudolocalizationOverrideEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind23, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPseudolocalizationSkipPlaceholdersEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPseudolocalizationSkipPlaceholdersEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPseudolocalizationSkipPlaceholdersEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPseudolocalizationSkipPlaceholdersEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind25, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPseudolocalizationExpansionRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPseudolocalizationExpansionRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPseudolocalizationExpansionRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPseudolocalizationExpansionRatio(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind27, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPseudolocalizationPrefix, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetPseudolocalizationPrefix()
    {
        return NativeCalls.godot_icall_0_58(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPseudolocalizationPrefix, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPseudolocalizationPrefix(string prefix)
    {
        NativeCalls.godot_icall_1_57(MethodBind29, GodotObject.GetPtr(this), prefix);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPseudolocalizationSuffix, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetPseudolocalizationSuffix()
    {
        return NativeCalls.godot_icall_0_58(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPseudolocalizationSuffix, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPseudolocalizationSuffix(string suffix)
    {
        NativeCalls.godot_icall_1_57(MethodBind31, GodotObject.GetPtr(this), suffix);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Pseudolocalize, 1965194235ul);

    /// <summary>
    /// <para>Returns the pseudolocalized string based on the <paramref name="message"/> passed in.</para>
    /// </summary>
    public StringName Pseudolocalize(StringName message)
    {
        return NativeCalls.godot_icall_1_164(MethodBind32, GodotObject.GetPtr(this), (godot_string_name)(message?.NativeValue ?? default));
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
        /// <summary>
        /// Cached name for the 'enabled' property.
        /// </summary>
        public static readonly StringName Enabled = "enabled";
        /// <summary>
        /// Cached name for the 'pseudolocalization_enabled' property.
        /// </summary>
        public static readonly StringName PseudolocalizationEnabled = "pseudolocalization_enabled";
        /// <summary>
        /// Cached name for the 'pseudolocalization_accents_enabled' property.
        /// </summary>
        public static readonly StringName PseudolocalizationAccentsEnabled = "pseudolocalization_accents_enabled";
        /// <summary>
        /// Cached name for the 'pseudolocalization_double_vowels_enabled' property.
        /// </summary>
        public static readonly StringName PseudolocalizationDoubleVowelsEnabled = "pseudolocalization_double_vowels_enabled";
        /// <summary>
        /// Cached name for the 'pseudolocalization_fake_bidi_enabled' property.
        /// </summary>
        public static readonly StringName PseudolocalizationFakeBidiEnabled = "pseudolocalization_fake_bidi_enabled";
        /// <summary>
        /// Cached name for the 'pseudolocalization_override_enabled' property.
        /// </summary>
        public static readonly StringName PseudolocalizationOverrideEnabled = "pseudolocalization_override_enabled";
        /// <summary>
        /// Cached name for the 'pseudolocalization_skip_placeholders_enabled' property.
        /// </summary>
        public static readonly StringName PseudolocalizationSkipPlaceholdersEnabled = "pseudolocalization_skip_placeholders_enabled";
        /// <summary>
        /// Cached name for the 'pseudolocalization_expansion_ratio' property.
        /// </summary>
        public static readonly StringName PseudolocalizationExpansionRatio = "pseudolocalization_expansion_ratio";
        /// <summary>
        /// Cached name for the 'pseudolocalization_prefix' property.
        /// </summary>
        public static readonly StringName PseudolocalizationPrefix = "pseudolocalization_prefix";
        /// <summary>
        /// Cached name for the 'pseudolocalization_suffix' property.
        /// </summary>
        public static readonly StringName PseudolocalizationSuffix = "pseudolocalization_suffix";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_translation_object' method.
        /// </summary>
        public static readonly StringName GetTranslationObject = "get_translation_object";
        /// <summary>
        /// Cached name for the 'add_translation' method.
        /// </summary>
        public static readonly StringName AddTranslation = "add_translation";
        /// <summary>
        /// Cached name for the 'remove_translation' method.
        /// </summary>
        public static readonly StringName RemoveTranslation = "remove_translation";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'get_translations' method.
        /// </summary>
        public static readonly StringName GetTranslations = "get_translations";
        /// <summary>
        /// Cached name for the 'has_translation_for_locale' method.
        /// </summary>
        public static readonly StringName HasTranslationForLocale = "has_translation_for_locale";
        /// <summary>
        /// Cached name for the 'has_translation' method.
        /// </summary>
        public static readonly StringName HasTranslation = "has_translation";
        /// <summary>
        /// Cached name for the 'find_translations' method.
        /// </summary>
        public static readonly StringName FindTranslations = "find_translations";
        /// <summary>
        /// Cached name for the 'translate' method.
        /// </summary>
        public static readonly StringName Translate = "translate";
        /// <summary>
        /// Cached name for the 'translate_plural' method.
        /// </summary>
        public static readonly StringName TranslatePlural = "translate_plural";
        /// <summary>
        /// Cached name for the 'get_locale_override' method.
        /// </summary>
        public static readonly StringName GetLocaleOverride = "get_locale_override";
        /// <summary>
        /// Cached name for the 'set_locale_override' method.
        /// </summary>
        public static readonly StringName SetLocaleOverride = "set_locale_override";
        /// <summary>
        /// Cached name for the 'is_enabled' method.
        /// </summary>
        public static readonly StringName IsEnabled = "is_enabled";
        /// <summary>
        /// Cached name for the 'set_enabled' method.
        /// </summary>
        public static readonly StringName SetEnabled = "set_enabled";
        /// <summary>
        /// Cached name for the 'is_pseudolocalization_enabled' method.
        /// </summary>
        public static readonly StringName IsPseudolocalizationEnabled = "is_pseudolocalization_enabled";
        /// <summary>
        /// Cached name for the 'set_pseudolocalization_enabled' method.
        /// </summary>
        public static readonly StringName SetPseudolocalizationEnabled = "set_pseudolocalization_enabled";
        /// <summary>
        /// Cached name for the 'is_pseudolocalization_accents_enabled' method.
        /// </summary>
        public static readonly StringName IsPseudolocalizationAccentsEnabled = "is_pseudolocalization_accents_enabled";
        /// <summary>
        /// Cached name for the 'set_pseudolocalization_accents_enabled' method.
        /// </summary>
        public static readonly StringName SetPseudolocalizationAccentsEnabled = "set_pseudolocalization_accents_enabled";
        /// <summary>
        /// Cached name for the 'is_pseudolocalization_double_vowels_enabled' method.
        /// </summary>
        public static readonly StringName IsPseudolocalizationDoubleVowelsEnabled = "is_pseudolocalization_double_vowels_enabled";
        /// <summary>
        /// Cached name for the 'set_pseudolocalization_double_vowels_enabled' method.
        /// </summary>
        public static readonly StringName SetPseudolocalizationDoubleVowelsEnabled = "set_pseudolocalization_double_vowels_enabled";
        /// <summary>
        /// Cached name for the 'is_pseudolocalization_fake_bidi_enabled' method.
        /// </summary>
        public static readonly StringName IsPseudolocalizationFakeBidiEnabled = "is_pseudolocalization_fake_bidi_enabled";
        /// <summary>
        /// Cached name for the 'set_pseudolocalization_fake_bidi_enabled' method.
        /// </summary>
        public static readonly StringName SetPseudolocalizationFakeBidiEnabled = "set_pseudolocalization_fake_bidi_enabled";
        /// <summary>
        /// Cached name for the 'is_pseudolocalization_override_enabled' method.
        /// </summary>
        public static readonly StringName IsPseudolocalizationOverrideEnabled = "is_pseudolocalization_override_enabled";
        /// <summary>
        /// Cached name for the 'set_pseudolocalization_override_enabled' method.
        /// </summary>
        public static readonly StringName SetPseudolocalizationOverrideEnabled = "set_pseudolocalization_override_enabled";
        /// <summary>
        /// Cached name for the 'is_pseudolocalization_skip_placeholders_enabled' method.
        /// </summary>
        public static readonly StringName IsPseudolocalizationSkipPlaceholdersEnabled = "is_pseudolocalization_skip_placeholders_enabled";
        /// <summary>
        /// Cached name for the 'set_pseudolocalization_skip_placeholders_enabled' method.
        /// </summary>
        public static readonly StringName SetPseudolocalizationSkipPlaceholdersEnabled = "set_pseudolocalization_skip_placeholders_enabled";
        /// <summary>
        /// Cached name for the 'get_pseudolocalization_expansion_ratio' method.
        /// </summary>
        public static readonly StringName GetPseudolocalizationExpansionRatio = "get_pseudolocalization_expansion_ratio";
        /// <summary>
        /// Cached name for the 'set_pseudolocalization_expansion_ratio' method.
        /// </summary>
        public static readonly StringName SetPseudolocalizationExpansionRatio = "set_pseudolocalization_expansion_ratio";
        /// <summary>
        /// Cached name for the 'get_pseudolocalization_prefix' method.
        /// </summary>
        public static readonly StringName GetPseudolocalizationPrefix = "get_pseudolocalization_prefix";
        /// <summary>
        /// Cached name for the 'set_pseudolocalization_prefix' method.
        /// </summary>
        public static readonly StringName SetPseudolocalizationPrefix = "set_pseudolocalization_prefix";
        /// <summary>
        /// Cached name for the 'get_pseudolocalization_suffix' method.
        /// </summary>
        public static readonly StringName GetPseudolocalizationSuffix = "get_pseudolocalization_suffix";
        /// <summary>
        /// Cached name for the 'set_pseudolocalization_suffix' method.
        /// </summary>
        public static readonly StringName SetPseudolocalizationSuffix = "set_pseudolocalization_suffix";
        /// <summary>
        /// Cached name for the 'pseudolocalize' method.
        /// </summary>
        public static readonly StringName Pseudolocalize = "pseudolocalize";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
