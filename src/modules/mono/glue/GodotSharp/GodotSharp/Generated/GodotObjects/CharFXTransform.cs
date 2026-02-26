namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>By setting various properties on this object, you can control how individual characters will be displayed in a <see cref="Godot.RichTextEffect"/>.</para>
/// </summary>
public partial class CharFXTransform : RefCounted
{
    /// <summary>
    /// <para>The current transform of the current glyph. It can be overridden (for example, by driving the position and rotation from a curve). You can also alter the existing value to apply transforms on top of other effects.</para>
    /// </summary>
    public Transform2D Transform
    {
        get
        {
            return GetTransform();
        }
        set
        {
            SetTransform(value);
        }
    }

    /// <summary>
    /// <para>Absolute character range in the string, corresponding to the glyph.</para>
    /// <para><b>Note:</b> Read-only. Setting this property won't affect drawing.</para>
    /// </summary>
    public Vector2I Range
    {
        get
        {
            return GetRange();
        }
        set
        {
            SetRange(value);
        }
    }

    /// <summary>
    /// <para>The time elapsed since the <see cref="Godot.RichTextLabel"/> was added to the scene tree (in seconds). Time stops when the <see cref="Godot.RichTextLabel"/> is paused (see <see cref="Godot.Node.ProcessMode"/>). Resets when the text in the <see cref="Godot.RichTextLabel"/> is changed.</para>
    /// <para><b>Note:</b> Time still passes while the <see cref="Godot.RichTextLabel"/> is hidden.</para>
    /// </summary>
    public double ElapsedTime
    {
        get
        {
            return GetElapsedTime();
        }
        set
        {
            SetElapsedTime(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the character will be drawn. If <see langword="false"/>, the character will be hidden. Characters around hidden characters will reflow to take the space of hidden characters. If this is not desired, set their <see cref="Godot.CharFXTransform.Color"/> to <c>Color(1, 1, 1, 0)</c> instead.</para>
    /// </summary>
    public bool Visible
    {
        get
        {
            return IsVisible();
        }
        set
        {
            SetVisibility(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, FX transform is called for outline drawing.</para>
    /// <para><b>Note:</b> Read-only. Setting this property won't affect drawing.</para>
    /// </summary>
    public bool Outline
    {
        get
        {
            return IsOutline();
        }
        set
        {
            SetOutline(value);
        }
    }

    /// <summary>
    /// <para>The position offset the character will be drawn with (in pixels).</para>
    /// </summary>
    public Vector2 Offset
    {
        get
        {
            return GetOffset();
        }
        set
        {
            SetOffset(value);
        }
    }

    /// <summary>
    /// <para>The color the character will be drawn with.</para>
    /// </summary>
    public Color Color
    {
        get
        {
            return GetColor();
        }
        set
        {
            SetColor(value);
        }
    }

    /// <summary>
    /// <para>Contains the arguments passed in the opening BBCode tag. By default, arguments are strings; if their contents match a type such as <see cref="bool"/>, <see cref="int"/> or <see cref="float"/>, they will be converted automatically. Color codes in the form <c>#rrggbb</c> or <c>#rgb</c> will be converted to an opaque <see cref="Godot.Color"/>. String arguments may not contain spaces, even if they're quoted. If present, quotes will also be present in the final string.</para>
    /// <para>For example, the opening BBCode tag <c>[example foo=hello bar=true baz=42 color=#ffffff]</c> will map to the following <see cref="Godot.Collections.Dictionary"/>:</para>
    /// <para><code>
    /// {"foo": "hello", "bar": true, "baz": 42, "color": Color(1, 1, 1, 1)}
    /// </code></para>
    /// </summary>
    public Godot.Collections.Dictionary Env
    {
        get
        {
            return GetEnvironment();
        }
        set
        {
            SetEnvironment(value);
        }
    }

    /// <summary>
    /// <para>Glyph index specific to the <see cref="Godot.CharFXTransform.Font"/>. If you want to replace this glyph, use <see cref="Godot.TextServer.FontGetGlyphIndex(Rid, long, long, long)"/> with <see cref="Godot.CharFXTransform.Font"/> to get a new glyph index for a single character.</para>
    /// </summary>
    public uint GlyphIndex
    {
        get
        {
            return GetGlyphIndex();
        }
        set
        {
            SetGlyphIndex(value);
        }
    }

    /// <summary>
    /// <para>Number of glyphs in the grapheme cluster. This value is set in the first glyph of a cluster.</para>
    /// <para><b>Note:</b> Read-only. Setting this property won't affect drawing.</para>
    /// </summary>
    public byte GlyphCount
    {
        get
        {
            return GetGlyphCount();
        }
        set
        {
            SetGlyphCount(value);
        }
    }

    /// <summary>
    /// <para>Glyph flags. See <see cref="Godot.TextServer.GraphemeFlag"/> for more info.</para>
    /// <para><b>Note:</b> Read-only. Setting this property won't affect drawing.</para>
    /// </summary>
    public ushort GlyphFlags
    {
        get
        {
            return GetGlyphFlags();
        }
        set
        {
            SetGlyphFlags(value);
        }
    }

    /// <summary>
    /// <para>The character offset of the glyph, relative to the current <see cref="Godot.RichTextEffect"/> custom block.</para>
    /// <para><b>Note:</b> Read-only. Setting this property won't affect drawing.</para>
    /// </summary>
    public int RelativeIndex
    {
        get
        {
            return GetRelativeIndex();
        }
        set
        {
            SetRelativeIndex(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.TextServer"/> RID of the font used to render glyph, this value can be used with <c>TextServer.font_*</c> methods to retrieve font information.</para>
    /// <para><b>Note:</b> Read-only. Setting this property won't affect drawing.</para>
    /// </summary>
    public Rid Font
    {
        get
        {
            return GetFont();
        }
        set
        {
            SetFont(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CharFXTransform);

    private static readonly StringName NativeName = "CharFXTransform";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CharFXTransform() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CharFXTransform(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CharFXTransform(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransform, 3761352769ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform2D GetTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransform, 2761652528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTransform(Transform2D transform)
    {
        NativeCalls.godot_icall_1_218(MethodBind1, GodotObject.GetPtr(this), &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRange, 2741790807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetRange()
    {
        return NativeCalls.godot_icall_0_35(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRange, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRange(Vector2I range)
    {
        NativeCalls.godot_icall_1_34(MethodBind3, GodotObject.GetPtr(this), &range);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetElapsedTime, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetElapsedTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetElapsedTime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetElapsedTime(double time)
    {
        NativeCalls.godot_icall_1_127(MethodBind5, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisible, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibility, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibility(bool visibility)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), visibility.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOutline, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsOutline()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutline, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOutline(bool outline)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), outline.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 1497962370ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind11, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColor, 3200896285ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind13, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironment, 2382534195ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetEnvironment()
    {
        return NativeCalls.godot_icall_0_122(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnvironment, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnvironment(Godot.Collections.Dictionary environment)
    {
        NativeCalls.godot_icall_1_121(MethodBind15, GodotObject.GetPtr(this), (godot_dictionary)(environment ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlyphIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetGlyphIndex()
    {
        return NativeCalls.godot_icall_0_209(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlyphIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlyphIndex(uint glyphIndex)
    {
        NativeCalls.godot_icall_1_208(MethodBind17, GodotObject.GetPtr(this), glyphIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRelativeIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRelativeIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRelativeIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRelativeIndex(int relativeIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), relativeIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlyphCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public byte GetGlyphCount()
    {
        return NativeCalls.godot_icall_0_282(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlyphCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlyphCount(byte glyphCount)
    {
        NativeCalls.godot_icall_1_283(MethodBind21, GodotObject.GetPtr(this), glyphCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlyphFlags, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ushort GetGlyphFlags()
    {
        return NativeCalls.godot_icall_0_284(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlyphFlags, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlyphFlags(ushort glyphFlags)
    {
        NativeCalls.godot_icall_1_285(MethodBind23, GodotObject.GetPtr(this), glyphFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFont, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetFont()
    {
        return NativeCalls.godot_icall_0_238(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFont, 2722037293ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFont(Rid font)
    {
        NativeCalls.godot_icall_1_286(MethodBind25, GodotObject.GetPtr(this), font);
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
        /// Cached name for the 'transform' property.
        /// </summary>
        public static readonly StringName Transform = "transform";
        /// <summary>
        /// Cached name for the 'range' property.
        /// </summary>
        public static readonly StringName Range = "range";
        /// <summary>
        /// Cached name for the 'elapsed_time' property.
        /// </summary>
        public static readonly StringName ElapsedTime = "elapsed_time";
        /// <summary>
        /// Cached name for the 'visible' property.
        /// </summary>
        public static readonly StringName Visible = "visible";
        /// <summary>
        /// Cached name for the 'outline' property.
        /// </summary>
        public static readonly StringName Outline = "outline";
        /// <summary>
        /// Cached name for the 'offset' property.
        /// </summary>
        public static readonly StringName Offset = "offset";
        /// <summary>
        /// Cached name for the 'color' property.
        /// </summary>
        public static readonly StringName Color = "color";
        /// <summary>
        /// Cached name for the 'env' property.
        /// </summary>
        public static readonly StringName Env = "env";
        /// <summary>
        /// Cached name for the 'glyph_index' property.
        /// </summary>
        public static readonly StringName GlyphIndex = "glyph_index";
        /// <summary>
        /// Cached name for the 'glyph_count' property.
        /// </summary>
        public static readonly StringName GlyphCount = "glyph_count";
        /// <summary>
        /// Cached name for the 'glyph_flags' property.
        /// </summary>
        public static readonly StringName GlyphFlags = "glyph_flags";
        /// <summary>
        /// Cached name for the 'relative_index' property.
        /// </summary>
        public static readonly StringName RelativeIndex = "relative_index";
        /// <summary>
        /// Cached name for the 'font' property.
        /// </summary>
        public static readonly StringName Font = "font";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_transform' method.
        /// </summary>
        public static readonly StringName GetTransform = "get_transform";
        /// <summary>
        /// Cached name for the 'set_transform' method.
        /// </summary>
        public static readonly StringName SetTransform = "set_transform";
        /// <summary>
        /// Cached name for the 'get_range' method.
        /// </summary>
        public static readonly StringName GetRange = "get_range";
        /// <summary>
        /// Cached name for the 'set_range' method.
        /// </summary>
        public static readonly StringName SetRange = "set_range";
        /// <summary>
        /// Cached name for the 'get_elapsed_time' method.
        /// </summary>
        public static readonly StringName GetElapsedTime = "get_elapsed_time";
        /// <summary>
        /// Cached name for the 'set_elapsed_time' method.
        /// </summary>
        public static readonly StringName SetElapsedTime = "set_elapsed_time";
        /// <summary>
        /// Cached name for the 'is_visible' method.
        /// </summary>
        public static readonly StringName IsVisible = "is_visible";
        /// <summary>
        /// Cached name for the 'set_visibility' method.
        /// </summary>
        public static readonly StringName SetVisibility = "set_visibility";
        /// <summary>
        /// Cached name for the 'is_outline' method.
        /// </summary>
        public static readonly StringName IsOutline = "is_outline";
        /// <summary>
        /// Cached name for the 'set_outline' method.
        /// </summary>
        public static readonly StringName SetOutline = "set_outline";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_color' method.
        /// </summary>
        public static readonly StringName GetColor = "get_color";
        /// <summary>
        /// Cached name for the 'set_color' method.
        /// </summary>
        public static readonly StringName SetColor = "set_color";
        /// <summary>
        /// Cached name for the 'get_environment' method.
        /// </summary>
        public static readonly StringName GetEnvironment = "get_environment";
        /// <summary>
        /// Cached name for the 'set_environment' method.
        /// </summary>
        public static readonly StringName SetEnvironment = "set_environment";
        /// <summary>
        /// Cached name for the 'get_glyph_index' method.
        /// </summary>
        public static readonly StringName GetGlyphIndex = "get_glyph_index";
        /// <summary>
        /// Cached name for the 'set_glyph_index' method.
        /// </summary>
        public static readonly StringName SetGlyphIndex = "set_glyph_index";
        /// <summary>
        /// Cached name for the 'get_relative_index' method.
        /// </summary>
        public static readonly StringName GetRelativeIndex = "get_relative_index";
        /// <summary>
        /// Cached name for the 'set_relative_index' method.
        /// </summary>
        public static readonly StringName SetRelativeIndex = "set_relative_index";
        /// <summary>
        /// Cached name for the 'get_glyph_count' method.
        /// </summary>
        public static readonly StringName GetGlyphCount = "get_glyph_count";
        /// <summary>
        /// Cached name for the 'set_glyph_count' method.
        /// </summary>
        public static readonly StringName SetGlyphCount = "set_glyph_count";
        /// <summary>
        /// Cached name for the 'get_glyph_flags' method.
        /// </summary>
        public static readonly StringName GetGlyphFlags = "get_glyph_flags";
        /// <summary>
        /// Cached name for the 'set_glyph_flags' method.
        /// </summary>
        public static readonly StringName SetGlyphFlags = "set_glyph_flags";
        /// <summary>
        /// Cached name for the 'get_font' method.
        /// </summary>
        public static readonly StringName GetFont = "get_font";
        /// <summary>
        /// Cached name for the 'set_font' method.
        /// </summary>
        public static readonly StringName SetFont = "set_font";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
