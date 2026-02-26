namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>By adjusting various properties of this resource, you can change the colors of strings, comments, numbers, and other text patterns inside a <see cref="Godot.TextEdit"/> control.</para>
/// </summary>
public partial class CodeHighlighter : SyntaxHighlighter
{
    /// <summary>
    /// <para>Sets the color for numbers.</para>
    /// </summary>
    public Color NumberColor
    {
        get
        {
            return GetNumberColor();
        }
        set
        {
            SetNumberColor(value);
        }
    }

    /// <summary>
    /// <para>Sets the color for symbols.</para>
    /// </summary>
    public Color SymbolColor
    {
        get
        {
            return GetSymbolColor();
        }
        set
        {
            SetSymbolColor(value);
        }
    }

    /// <summary>
    /// <para>Sets color for functions. A function is a non-keyword string followed by a '('.</para>
    /// </summary>
    public Color FunctionColor
    {
        get
        {
            return GetFunctionColor();
        }
        set
        {
            SetFunctionColor(value);
        }
    }

    /// <summary>
    /// <para>Sets color for member variables. A member variable is non-keyword, non-function string proceeded with a '.'.</para>
    /// </summary>
    public Color MemberVariableColor
    {
        get
        {
            return GetMemberVariableColor();
        }
        set
        {
            SetMemberVariableColor(value);
        }
    }

    /// <summary>
    /// <para>Sets the keyword colors. All existing keywords will be removed. The <see cref="Godot.Collections.Dictionary"/> key is the keyword. The value is the keyword color.</para>
    /// </summary>
    public Godot.Collections.Dictionary KeywordColors
    {
        get
        {
            return GetKeywordColors();
        }
        set
        {
            SetKeywordColors(value);
        }
    }

    /// <summary>
    /// <para>Sets the member keyword colors. All existing member keyword will be removed. The <see cref="Godot.Collections.Dictionary"/> key is the member keyword. The value is the member keyword color.</para>
    /// </summary>
    public Godot.Collections.Dictionary MemberKeywordColors
    {
        get
        {
            return GetMemberKeywordColors();
        }
        set
        {
            SetMemberKeywordColors(value);
        }
    }

    /// <summary>
    /// <para>Sets the color regions. All existing regions will be removed. The <see cref="Godot.Collections.Dictionary"/> key is the region start and end key, separated by a space. The value is the region color.</para>
    /// </summary>
    public Godot.Collections.Dictionary ColorRegions
    {
        get
        {
            return GetColorRegions();
        }
        set
        {
            SetColorRegions(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CodeHighlighter);

    private static readonly StringName NativeName = "CodeHighlighter";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CodeHighlighter() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CodeHighlighter(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CodeHighlighter(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddKeywordColor, 1636512886ul);

    /// <summary>
    /// <para>Sets the color for a keyword.</para>
    /// <para>The keyword cannot contain any symbols except '_'.</para>
    /// </summary>
    public unsafe void AddKeywordColor(string keyword, Color color)
    {
        NativeCalls.godot_icall_2_308(MethodBind0, GodotObject.GetPtr(this), keyword, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveKeywordColor, 83702148ul);

    /// <summary>
    /// <para>Removes the keyword.</para>
    /// </summary>
    public void RemoveKeywordColor(string keyword)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), keyword);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasKeywordColor, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the keyword exists, else <see langword="false"/>.</para>
    /// </summary>
    public bool HasKeywordColor(string keyword)
    {
        return NativeCalls.godot_icall_1_131(MethodBind2, GodotObject.GetPtr(this), keyword).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetKeywordColor, 3855908743ul);

    /// <summary>
    /// <para>Returns the color for a keyword.</para>
    /// </summary>
    public Color GetKeywordColor(string keyword)
    {
        return NativeCalls.godot_icall_1_309(MethodBind3, GodotObject.GetPtr(this), keyword);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKeywordColors, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetKeywordColors(Godot.Collections.Dictionary keywords)
    {
        NativeCalls.godot_icall_1_121(MethodBind4, GodotObject.GetPtr(this), (godot_dictionary)(keywords ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearKeywordColors, 3218959716ul);

    /// <summary>
    /// <para>Removes all keywords.</para>
    /// </summary>
    public void ClearKeywordColors()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetKeywordColors, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetKeywordColors()
    {
        return NativeCalls.godot_icall_0_122(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMemberKeywordColor, 1636512886ul);

    /// <summary>
    /// <para>Sets the color for a member keyword.</para>
    /// <para>The member keyword cannot contain any symbols except '_'.</para>
    /// <para>It will not be highlighted if preceded by a '.'.</para>
    /// </summary>
    public unsafe void AddMemberKeywordColor(string memberKeyword, Color color)
    {
        NativeCalls.godot_icall_2_308(MethodBind7, GodotObject.GetPtr(this), memberKeyword, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveMemberKeywordColor, 83702148ul);

    /// <summary>
    /// <para>Removes the member keyword.</para>
    /// </summary>
    public void RemoveMemberKeywordColor(string memberKeyword)
    {
        NativeCalls.godot_icall_1_57(MethodBind8, GodotObject.GetPtr(this), memberKeyword);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasMemberKeywordColor, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the member keyword exists, else <see langword="false"/>.</para>
    /// </summary>
    public bool HasMemberKeywordColor(string memberKeyword)
    {
        return NativeCalls.godot_icall_1_131(MethodBind9, GodotObject.GetPtr(this), memberKeyword).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMemberKeywordColor, 3855908743ul);

    /// <summary>
    /// <para>Returns the color for a member keyword.</para>
    /// </summary>
    public Color GetMemberKeywordColor(string memberKeyword)
    {
        return NativeCalls.godot_icall_1_309(MethodBind10, GodotObject.GetPtr(this), memberKeyword);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMemberKeywordColors, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMemberKeywordColors(Godot.Collections.Dictionary memberKeyword)
    {
        NativeCalls.godot_icall_1_121(MethodBind11, GodotObject.GetPtr(this), (godot_dictionary)(memberKeyword ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearMemberKeywordColors, 3218959716ul);

    /// <summary>
    /// <para>Removes all member keywords.</para>
    /// </summary>
    public void ClearMemberKeywordColors()
    {
        NativeCalls.godot_icall_0_3(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMemberKeywordColors, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetMemberKeywordColors()
    {
        return NativeCalls.godot_icall_0_122(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddColorRegion, 2924977451ul);

    /// <summary>
    /// <para>Adds a color region (such as for comments or strings) from <paramref name="startKey"/> to <paramref name="endKey"/>. Both keys should be symbols, and <paramref name="startKey"/> must not be shared with other delimiters.</para>
    /// <para>If <paramref name="lineOnly"/> is <see langword="true"/> or <paramref name="endKey"/> is an empty <see cref="string"/>, the region does not carry over to the next line.</para>
    /// </summary>
    public unsafe void AddColorRegion(string startKey, string endKey, Color color, bool lineOnly = false)
    {
        NativeCalls.godot_icall_4_310(MethodBind14, GodotObject.GetPtr(this), startKey, endKey, &color, lineOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveColorRegion, 83702148ul);

    /// <summary>
    /// <para>Removes the color region that uses that start key.</para>
    /// </summary>
    public void RemoveColorRegion(string startKey)
    {
        NativeCalls.godot_icall_1_57(MethodBind15, GodotObject.GetPtr(this), startKey);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasColorRegion, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the start key exists, else <see langword="false"/>.</para>
    /// </summary>
    public bool HasColorRegion(string startKey)
    {
        return NativeCalls.godot_icall_1_131(MethodBind16, GodotObject.GetPtr(this), startKey).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColorRegions, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorRegions(Godot.Collections.Dictionary colorRegions)
    {
        NativeCalls.godot_icall_1_121(MethodBind17, GodotObject.GetPtr(this), (godot_dictionary)(colorRegions ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearColorRegions, 3218959716ul);

    /// <summary>
    /// <para>Removes all color regions.</para>
    /// </summary>
    public void ClearColorRegions()
    {
        NativeCalls.godot_icall_0_3(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorRegions, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetColorRegions()
    {
        return NativeCalls.godot_icall_0_122(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFunctionColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFunctionColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind20, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFunctionColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetFunctionColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNumberColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetNumberColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind22, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNumberColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetNumberColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSymbolColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSymbolColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind24, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSymbolColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetSymbolColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMemberVariableColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMemberVariableColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind26, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMemberVariableColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetMemberVariableColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind27, GodotObject.GetPtr(this));
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
    public new class PropertyName : SyntaxHighlighter.PropertyName
    {
        /// <summary>
        /// Cached name for the 'number_color' property.
        /// </summary>
        public static readonly StringName NumberColor = "number_color";
        /// <summary>
        /// Cached name for the 'symbol_color' property.
        /// </summary>
        public static readonly StringName SymbolColor = "symbol_color";
        /// <summary>
        /// Cached name for the 'function_color' property.
        /// </summary>
        public static readonly StringName FunctionColor = "function_color";
        /// <summary>
        /// Cached name for the 'member_variable_color' property.
        /// </summary>
        public static readonly StringName MemberVariableColor = "member_variable_color";
        /// <summary>
        /// Cached name for the 'keyword_colors' property.
        /// </summary>
        public static readonly StringName KeywordColors = "keyword_colors";
        /// <summary>
        /// Cached name for the 'member_keyword_colors' property.
        /// </summary>
        public static readonly StringName MemberKeywordColors = "member_keyword_colors";
        /// <summary>
        /// Cached name for the 'color_regions' property.
        /// </summary>
        public static readonly StringName ColorRegions = "color_regions";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SyntaxHighlighter.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_keyword_color' method.
        /// </summary>
        public static readonly StringName AddKeywordColor = "add_keyword_color";
        /// <summary>
        /// Cached name for the 'remove_keyword_color' method.
        /// </summary>
        public static readonly StringName RemoveKeywordColor = "remove_keyword_color";
        /// <summary>
        /// Cached name for the 'has_keyword_color' method.
        /// </summary>
        public static readonly StringName HasKeywordColor = "has_keyword_color";
        /// <summary>
        /// Cached name for the 'get_keyword_color' method.
        /// </summary>
        public static readonly StringName GetKeywordColor = "get_keyword_color";
        /// <summary>
        /// Cached name for the 'set_keyword_colors' method.
        /// </summary>
        public static readonly StringName SetKeywordColors = "set_keyword_colors";
        /// <summary>
        /// Cached name for the 'clear_keyword_colors' method.
        /// </summary>
        public static readonly StringName ClearKeywordColors = "clear_keyword_colors";
        /// <summary>
        /// Cached name for the 'get_keyword_colors' method.
        /// </summary>
        public static readonly StringName GetKeywordColors = "get_keyword_colors";
        /// <summary>
        /// Cached name for the 'add_member_keyword_color' method.
        /// </summary>
        public static readonly StringName AddMemberKeywordColor = "add_member_keyword_color";
        /// <summary>
        /// Cached name for the 'remove_member_keyword_color' method.
        /// </summary>
        public static readonly StringName RemoveMemberKeywordColor = "remove_member_keyword_color";
        /// <summary>
        /// Cached name for the 'has_member_keyword_color' method.
        /// </summary>
        public static readonly StringName HasMemberKeywordColor = "has_member_keyword_color";
        /// <summary>
        /// Cached name for the 'get_member_keyword_color' method.
        /// </summary>
        public static readonly StringName GetMemberKeywordColor = "get_member_keyword_color";
        /// <summary>
        /// Cached name for the 'set_member_keyword_colors' method.
        /// </summary>
        public static readonly StringName SetMemberKeywordColors = "set_member_keyword_colors";
        /// <summary>
        /// Cached name for the 'clear_member_keyword_colors' method.
        /// </summary>
        public static readonly StringName ClearMemberKeywordColors = "clear_member_keyword_colors";
        /// <summary>
        /// Cached name for the 'get_member_keyword_colors' method.
        /// </summary>
        public static readonly StringName GetMemberKeywordColors = "get_member_keyword_colors";
        /// <summary>
        /// Cached name for the 'add_color_region' method.
        /// </summary>
        public static readonly StringName AddColorRegion = "add_color_region";
        /// <summary>
        /// Cached name for the 'remove_color_region' method.
        /// </summary>
        public static readonly StringName RemoveColorRegion = "remove_color_region";
        /// <summary>
        /// Cached name for the 'has_color_region' method.
        /// </summary>
        public static readonly StringName HasColorRegion = "has_color_region";
        /// <summary>
        /// Cached name for the 'set_color_regions' method.
        /// </summary>
        public static readonly StringName SetColorRegions = "set_color_regions";
        /// <summary>
        /// Cached name for the 'clear_color_regions' method.
        /// </summary>
        public static readonly StringName ClearColorRegions = "clear_color_regions";
        /// <summary>
        /// Cached name for the 'get_color_regions' method.
        /// </summary>
        public static readonly StringName GetColorRegions = "get_color_regions";
        /// <summary>
        /// Cached name for the 'set_function_color' method.
        /// </summary>
        public static readonly StringName SetFunctionColor = "set_function_color";
        /// <summary>
        /// Cached name for the 'get_function_color' method.
        /// </summary>
        public static readonly StringName GetFunctionColor = "get_function_color";
        /// <summary>
        /// Cached name for the 'set_number_color' method.
        /// </summary>
        public static readonly StringName SetNumberColor = "set_number_color";
        /// <summary>
        /// Cached name for the 'get_number_color' method.
        /// </summary>
        public static readonly StringName GetNumberColor = "get_number_color";
        /// <summary>
        /// Cached name for the 'set_symbol_color' method.
        /// </summary>
        public static readonly StringName SetSymbolColor = "set_symbol_color";
        /// <summary>
        /// Cached name for the 'get_symbol_color' method.
        /// </summary>
        public static readonly StringName GetSymbolColor = "get_symbol_color";
        /// <summary>
        /// Cached name for the 'set_member_variable_color' method.
        /// </summary>
        public static readonly StringName SetMemberVariableColor = "set_member_variable_color";
        /// <summary>
        /// Cached name for the 'get_member_variable_color' method.
        /// </summary>
        public static readonly StringName GetMemberVariableColor = "get_member_variable_color";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SyntaxHighlighter.SignalName
    {
    }
}
