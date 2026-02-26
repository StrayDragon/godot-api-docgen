namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Comma-separated values are a plain text table storage format. The format's simplicity makes it easy to edit in any text editor or spreadsheet software. This makes it a common choice for game localization.</para>
/// <para>In the CSV file used for translation, the first column contains string identifiers, and the first row serves as the header. The first column's header can be any value. The remaining headers indicate the locale for that column. Columns whose headers begin with an underscore (<c>_</c>) will be ignored.</para>
/// <para><b>Example CSV file:</b></para>
/// <para><code>
/// keys,en,es,ja
/// GREET,"Hello, friend!","Hola, amigo!",こんにちは
/// ASK,How are you?,Cómo está?,元気ですか
/// BYE,Goodbye,Adiós,さようなら
/// QUOTE,"""Hello"" said the man.","""Hola"" dijo el hombre.",「こんにちは」男は言いました
/// </code></para>
/// <para>Although keys in the first column typically use uppercase string identifiers, it is not uncommon to directly use strings appearing in the game as keys. To avoid string ambiguity, you can use a special <c>?context</c> column to specify the context to use with <see cref="Godot.GodotObject.Tr(StringName, StringName)"/>.</para>
/// <para><code>
/// en,?context,fr,ja,zh
/// Letter,Alphabet,Lettre,字母,字母
/// Letter,Message,Courrier,手紙,信件
/// </code></para>
/// <para>To set the plural form of a string to use with <see cref="Godot.GodotObject.TrN(StringName, StringName, int, StringName)"/>, add a special <c>?plural</c> column. After setting the plural form of the source string in this column, you can add additional rows to provide translations for more plural forms. The first column and all special columns in these plural form rows must be empty.</para>
/// <para>Godot includes built-in plural rules for some languages. You can also customize them using a special <c>?pluralrule</c> row. See <a href="https://www.gnu.org/software/gettext/manual/html_node/Plural-forms.html">GNU gettext</a> for examples and more info.</para>
/// <para><code>
/// en,?plural,fr,ru,zh,_Comment
/// ?pluralrule,,nplurals=2; plural=(n &gt;= 2);,,,Customize the plural rule for French
/// There is %d apple,There are %d apples,Il y a %d pomme,Есть %d яблоко,那里有%d个苹果,
/// ,,Il y a %d pommes,Есть %d яблока,,
/// ,,,Есть %d яблок,,
/// </code></para>
/// </summary>
[GodotClassName("ResourceImporterCSVTranslation")]
public partial class ResourceImporterCsvTranslation : ResourceImporter
{
    private static readonly System.Type CachedType = typeof(ResourceImporterCsvTranslation);

    private static readonly StringName NativeName = "ResourceImporterCSVTranslation";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ResourceImporterCsvTranslation() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceImporterCsvTranslation(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ResourceImporterCsvTranslation(bool memoryOwn) : base(memoryOwn) { }

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
    public new class PropertyName : ResourceImporter.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ResourceImporter.MethodName
    {
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ResourceImporter.SignalName
    {
    }
}
