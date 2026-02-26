namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Provides OpenType variations, simulated bold / slant, and additional font settings like OpenType features and extra spacing.</para>
/// <para>To use simulated bold font variant:</para>
/// <para><code>
/// var fv = new FontVariation();
/// fv.SetBaseFont(ResourceLoader.Load&lt;FontFile&gt;("res://BarlowCondensed-Regular.ttf"));
/// fv.SetVariationEmbolden(1.2);
/// GetNode("Label").AddThemeFontOverride("font", fv);
/// GetNode("Label").AddThemeFontSizeOverride("font_size", 64);
/// </code></para>
/// <para>To set the coordinate of multiple variation axes:</para>
/// <para><code>
/// var fv = FontVariation.new();
/// var ts = TextServerManager.get_primary_interface()
/// fv.base_font = load("res://BarlowCondensed-Regular.ttf")
/// fv.variation_opentype = { ts.name_to_tag("wght"): 900, ts.name_to_tag("custom_hght"): 900 }
/// </code></para>
/// </summary>
public partial class FontVariation : Font
{
    /// <summary>
    /// <para>Base font used to create a variation. If not set, default <see cref="Godot.Theme"/> font is used.</para>
    /// </summary>
    public Font BaseFont
    {
        get
        {
            return GetBaseFont();
        }
        set
        {
            SetBaseFont(value);
        }
    }

    /// <summary>
    /// <para>Font OpenType variation coordinates. More info: <a href="https://docs.microsoft.com/en-us/typography/opentype/spec/dvaraxisreg">OpenType variation tags</a>.</para>
    /// <para><b>Note:</b> This <see cref="Godot.Collections.Dictionary"/> uses OpenType tags as keys. Variation axes can be identified both by tags (<see cref="int"/>, e.g. <c>0x77678674</c>) and names (<see cref="string"/>, e.g. <c>wght</c>). Some axes might be accessible by multiple names. For example, <c>wght</c> refers to the same axis as <c>weight</c>. Tags on the other hand are unique. To convert between names and tags, use <see cref="Godot.TextServer.NameToTag(string)"/> and <see cref="Godot.TextServer.TagToName(long)"/>.</para>
    /// <para><b>Note:</b> To get available variation axes of a font, use <see cref="Godot.Font.GetSupportedVariationList()"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary VariationOpentype
    {
        get
        {
            return GetVariationOpentype();
        }
        set
        {
            SetVariationOpentype(value);
        }
    }

    /// <summary>
    /// <para>Active face index in the TrueType / OpenType collection file.</para>
    /// </summary>
    public int VariationFaceIndex
    {
        get
        {
            return GetVariationFaceIndex();
        }
        set
        {
            SetVariationFaceIndex(value);
        }
    }

    /// <summary>
    /// <para>If is not equal to zero, emboldens the font outlines. Negative values reduce the outline thickness.</para>
    /// <para><b>Note:</b> Emboldened fonts might have self-intersecting outlines, which will prevent MSDF fonts and <see cref="Godot.TextMesh"/> from working correctly.</para>
    /// </summary>
    public float VariationEmbolden
    {
        get
        {
            return GetVariationEmbolden();
        }
        set
        {
            SetVariationEmbolden(value);
        }
    }

    /// <summary>
    /// <para>2D transform, applied to the font outlines, can be used for slanting, flipping and rotating glyphs.</para>
    /// <para>For example, to simulate italic typeface by slanting, apply the following transform <c>Transform2D(1.0, slant, 0.0, 1.0, 0.0, 0.0)</c>.</para>
    /// </summary>
    public Transform2D VariationTransform
    {
        get
        {
            return GetVariationTransform();
        }
        set
        {
            SetVariationTransform(value);
        }
    }

    /// <summary>
    /// <para>A set of OpenType feature tags. More info: <a href="https://docs.microsoft.com/en-us/typography/opentype/spec/featuretags">OpenType feature tags</a>.</para>
    /// </summary>
    public Godot.Collections.Dictionary OpentypeFeatures
    {
        get
        {
            return GetOpentypeFeatures();
        }
        set
        {
            SetOpentypeFeatures(value);
        }
    }

    /// <summary>
    /// <para>Extra spacing between graphical glyphs.</para>
    /// </summary>
    public int SpacingGlyph
    {
        get
        {
            return GetSpacing((TextServer.SpacingType)(0));
        }
        set
        {
            SetSpacing((TextServer.SpacingType)(0), value);
        }
    }

    /// <summary>
    /// <para>Extra width of the space glyphs.</para>
    /// </summary>
    public int SpacingSpace
    {
        get
        {
            return GetSpacing((TextServer.SpacingType)(1));
        }
        set
        {
            SetSpacing((TextServer.SpacingType)(1), value);
        }
    }

    /// <summary>
    /// <para>Extra spacing at the top of the line in pixels.</para>
    /// </summary>
    public int SpacingTop
    {
        get
        {
            return GetSpacing((TextServer.SpacingType)(2));
        }
        set
        {
            SetSpacing((TextServer.SpacingType)(2), value);
        }
    }

    /// <summary>
    /// <para>Extra spacing at the bottom of the line in pixels.</para>
    /// </summary>
    public int SpacingBottom
    {
        get
        {
            return GetSpacing((TextServer.SpacingType)(3));
        }
        set
        {
            SetSpacing((TextServer.SpacingType)(3), value);
        }
    }

    /// <summary>
    /// <para>Extra baseline offset (as a fraction of font height).</para>
    /// </summary>
    public float BaselineOffset
    {
        get
        {
            return GetBaselineOffset();
        }
        set
        {
            SetBaselineOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(FontVariation);

    private static readonly StringName NativeName = "FontVariation";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public FontVariation() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal FontVariation(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal FontVariation(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBaseFont, 1262170328ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBaseFont(Font font)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(font));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBaseFont, 3229501585ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Font GetBaseFont()
    {
        return (Font)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVariationOpentype, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVariationOpentype(Godot.Collections.Dictionary coords)
    {
        NativeCalls.godot_icall_1_121(MethodBind2, GodotObject.GetPtr(this), (godot_dictionary)(coords ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVariationOpentype, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetVariationOpentype()
    {
        return NativeCalls.godot_icall_0_122(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVariationEmbolden, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVariationEmbolden(float strength)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVariationEmbolden, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVariationEmbolden()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVariationFaceIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVariationFaceIndex(int faceIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), faceIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVariationFaceIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetVariationFaceIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVariationTransform, 2761652528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetVariationTransform(Transform2D transform)
    {
        NativeCalls.godot_icall_1_218(MethodBind8, GodotObject.GetPtr(this), &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVariationTransform, 3814499831ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform2D GetVariationTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOpentypeFeatures, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOpentypeFeatures(Godot.Collections.Dictionary features)
    {
        NativeCalls.godot_icall_1_121(MethodBind10, GodotObject.GetPtr(this), (godot_dictionary)(features ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpacing, 3122339690ul);

    /// <summary>
    /// <para>Sets the spacing for <paramref name="spacing"/> to <paramref name="value"/> in pixels (not relative to the font size).</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpacing(TextServer.SpacingType spacing, int value)
    {
        NativeCalls.godot_icall_2_59(MethodBind11, GodotObject.GetPtr(this), (int)spacing, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBaselineOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBaselineOffset(float baselineOffset)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), baselineOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBaselineOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBaselineOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
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
    public new class PropertyName : Font.PropertyName
    {
        /// <summary>
        /// Cached name for the 'base_font' property.
        /// </summary>
        public static readonly StringName BaseFont = "base_font";
        /// <summary>
        /// Cached name for the 'variation_opentype' property.
        /// </summary>
        public static readonly StringName VariationOpentype = "variation_opentype";
        /// <summary>
        /// Cached name for the 'variation_face_index' property.
        /// </summary>
        public static readonly StringName VariationFaceIndex = "variation_face_index";
        /// <summary>
        /// Cached name for the 'variation_embolden' property.
        /// </summary>
        public static readonly StringName VariationEmbolden = "variation_embolden";
        /// <summary>
        /// Cached name for the 'variation_transform' property.
        /// </summary>
        public static readonly StringName VariationTransform = "variation_transform";
        /// <summary>
        /// Cached name for the 'opentype_features' property.
        /// </summary>
        public static readonly StringName OpentypeFeatures = "opentype_features";
        /// <summary>
        /// Cached name for the 'spacing_glyph' property.
        /// </summary>
        public static readonly StringName SpacingGlyph = "spacing_glyph";
        /// <summary>
        /// Cached name for the 'spacing_space' property.
        /// </summary>
        public static readonly StringName SpacingSpace = "spacing_space";
        /// <summary>
        /// Cached name for the 'spacing_top' property.
        /// </summary>
        public static readonly StringName SpacingTop = "spacing_top";
        /// <summary>
        /// Cached name for the 'spacing_bottom' property.
        /// </summary>
        public static readonly StringName SpacingBottom = "spacing_bottom";
        /// <summary>
        /// Cached name for the 'baseline_offset' property.
        /// </summary>
        public static readonly StringName BaselineOffset = "baseline_offset";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Font.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_base_font' method.
        /// </summary>
        public static readonly StringName SetBaseFont = "set_base_font";
        /// <summary>
        /// Cached name for the 'get_base_font' method.
        /// </summary>
        public static readonly StringName GetBaseFont = "get_base_font";
        /// <summary>
        /// Cached name for the 'set_variation_opentype' method.
        /// </summary>
        public static readonly StringName SetVariationOpentype = "set_variation_opentype";
        /// <summary>
        /// Cached name for the 'get_variation_opentype' method.
        /// </summary>
        public static readonly StringName GetVariationOpentype = "get_variation_opentype";
        /// <summary>
        /// Cached name for the 'set_variation_embolden' method.
        /// </summary>
        public static readonly StringName SetVariationEmbolden = "set_variation_embolden";
        /// <summary>
        /// Cached name for the 'get_variation_embolden' method.
        /// </summary>
        public static readonly StringName GetVariationEmbolden = "get_variation_embolden";
        /// <summary>
        /// Cached name for the 'set_variation_face_index' method.
        /// </summary>
        public static readonly StringName SetVariationFaceIndex = "set_variation_face_index";
        /// <summary>
        /// Cached name for the 'get_variation_face_index' method.
        /// </summary>
        public static readonly StringName GetVariationFaceIndex = "get_variation_face_index";
        /// <summary>
        /// Cached name for the 'set_variation_transform' method.
        /// </summary>
        public static readonly StringName SetVariationTransform = "set_variation_transform";
        /// <summary>
        /// Cached name for the 'get_variation_transform' method.
        /// </summary>
        public static readonly StringName GetVariationTransform = "get_variation_transform";
        /// <summary>
        /// Cached name for the 'set_opentype_features' method.
        /// </summary>
        public static readonly StringName SetOpentypeFeatures = "set_opentype_features";
        /// <summary>
        /// Cached name for the 'set_spacing' method.
        /// </summary>
        public static readonly StringName SetSpacing = "set_spacing";
        /// <summary>
        /// Cached name for the 'set_baseline_offset' method.
        /// </summary>
        public static readonly StringName SetBaselineOffset = "set_baseline_offset";
        /// <summary>
        /// Cached name for the 'get_baseline_offset' method.
        /// </summary>
        public static readonly StringName GetBaselineOffset = "get_baseline_offset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Font.SignalName
    {
    }
}
