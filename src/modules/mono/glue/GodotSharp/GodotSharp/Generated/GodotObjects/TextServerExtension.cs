namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>External <see cref="Godot.TextServer"/> implementations should inherit from this class.</para>
/// </summary>
public partial class TextServerExtension : TextServer
{
    private static readonly System.Type CachedType = typeof(TextServerExtension);

    private static readonly StringName NativeName = "TextServerExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TextServerExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextServerExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextServerExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>This method is called before text server is unregistered.</para>
    /// </summary>
    public virtual void _Cleanup()
    {
    }

    /// <summary>
    /// <para>Creates a new, empty font cache entry resource.</para>
    /// </summary>
    public virtual Rid _CreateFont()
    {
        return default;
    }

    /// <summary>
    /// <para>Optional, implement if font supports extra spacing or baseline offset.</para>
    /// <para>Creates a new variation existing font which is reusing the same glyph cache and font data.</para>
    /// </summary>
    public virtual Rid _CreateFontLinkedVariation(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Creates a new buffer for complex text layout, with the given <paramref name="direction"/> and <paramref name="orientation"/>.</para>
    /// </summary>
    public virtual Rid _CreateShapedText(TextServer.Direction direction, TextServer.Orientation orientation)
    {
        return default;
    }

    /// <summary>
    /// <para>Draws box displaying character hexadecimal code.</para>
    /// </summary>
    public virtual unsafe void _DrawHexCodeBox(Rid canvas, long size, Vector2 pos, long index, Color color)
    {
    }

    /// <summary>
    /// <para>Removes all rendered glyph information from the cache entry.</para>
    /// </summary>
    public virtual unsafe void _FontClearGlyphs(Rid fontRid, Vector2I size)
    {
    }

    /// <summary>
    /// <para>Removes all kerning overrides.</para>
    /// </summary>
    public virtual void _FontClearKerningMap(Rid fontRid, long size)
    {
    }

    /// <summary>
    /// <para>Removes all font sizes from the cache entry.</para>
    /// </summary>
    public virtual void _FontClearSizeCache(Rid fontRid)
    {
    }

    /// <summary>
    /// <para>Frees all automatically loaded system fonts.</para>
    /// </summary>
    public virtual void _FontClearSystemFallbackCache()
    {
    }

    /// <summary>
    /// <para>Removes all textures from font cache entry.</para>
    /// </summary>
    public virtual unsafe void _FontClearTextures(Rid fontRid, Vector2I size)
    {
    }

    /// <summary>
    /// <para>Draws single glyph into a canvas item at the position, using <paramref name="fontRid"/> at the size <paramref name="size"/>. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    public virtual unsafe void _FontDrawGlyph(Rid fontRid, Rid canvas, long size, Vector2 pos, long index, Color color, float oversampling)
    {
    }

    /// <summary>
    /// <para>Draws single glyph outline of size <paramref name="outlineSize"/> into a canvas item at the position, using <paramref name="fontRid"/> at the size <paramref name="size"/>. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    public virtual unsafe void _FontDrawGlyphOutline(Rid fontRid, Rid canvas, long size, long outlineSize, Vector2 pos, long index, Color color, float oversampling)
    {
    }

    /// <summary>
    /// <para>Returns font anti-aliasing mode.</para>
    /// </summary>
    public virtual TextServer.FontAntialiasing _FontGetAntialiasing(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the font ascent (number of pixels above the baseline).</para>
    /// </summary>
    public virtual double _FontGetAscent(Rid fontRid, long size)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns extra baseline offset (as a fraction of font height).</para>
    /// </summary>
    public virtual double _FontGetBaselineOffset(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns character code associated with <paramref name="glyphIndex"/>, or <c>0</c> if <paramref name="glyphIndex"/> is invalid.</para>
    /// </summary>
    public virtual long _FontGetCharFromGlyphIndex(Rid fontRid, long size, long glyphIndex)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the font descent (number of pixels below the baseline).</para>
    /// </summary>
    public virtual double _FontGetDescent(Rid fontRid, long size)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns whether the font's embedded bitmap loading is disabled.</para>
    /// </summary>
    public virtual bool _FontGetDisableEmbeddedBitmaps(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns font embolden strength.</para>
    /// </summary>
    public virtual double _FontGetEmbolden(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns number of faces in the TrueType / OpenType collection.</para>
    /// </summary>
    public virtual long _FontGetFaceCount(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns an active face index in the TrueType / OpenType collection.</para>
    /// </summary>
    public virtual long _FontGetFaceIndex(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns bitmap font fixed size.</para>
    /// </summary>
    public virtual long _FontGetFixedSize(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns bitmap font scaling mode.</para>
    /// </summary>
    public virtual TextServer.FixedSizeScaleMode _FontGetFixedSizeScaleMode(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if font texture mipmap generation is enabled.</para>
    /// </summary>
    public virtual bool _FontGetGenerateMipmaps(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the font oversampling factor, shared by all fonts in the TextServer.</para>
    /// </summary>
    public virtual double _FontGetGlobalOversampling()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns glyph advance (offset of the next glyph).</para>
    /// </summary>
    public virtual Vector2 _FontGetGlyphAdvance(Rid fontRid, long size, long glyph)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns outline contours of the glyph.</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _FontGetGlyphContours(Rid fontRid, long size, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the glyph index of a <paramref name="char"/>, optionally modified by the <paramref name="variationSelector"/>.</para>
    /// </summary>
    public virtual long _FontGetGlyphIndex(Rid fontRid, long size, long @char, long variationSelector)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns list of rendered glyphs in the cache entry.</para>
    /// </summary>
    public virtual unsafe int[] _FontGetGlyphList(Rid fontRid, Vector2I size)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns glyph offset from the baseline.</para>
    /// </summary>
    public virtual unsafe Vector2 _FontGetGlyphOffset(Rid fontRid, Vector2I size, long glyph)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns size of the glyph.</para>
    /// </summary>
    public virtual unsafe Vector2 _FontGetGlyphSize(Rid fontRid, Vector2I size, long glyph)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns index of the cache texture containing the glyph.</para>
    /// </summary>
    public virtual unsafe long _FontGetGlyphTextureIdx(Rid fontRid, Vector2I size, long glyph)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns resource ID of the cache texture containing the glyph.</para>
    /// </summary>
    public virtual unsafe Rid _FontGetGlyphTextureRid(Rid fontRid, Vector2I size, long glyph)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns size of the cache texture containing the glyph.</para>
    /// </summary>
    public virtual unsafe Vector2 _FontGetGlyphTextureSize(Rid fontRid, Vector2I size, long glyph)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns rectangle in the cache texture containing the glyph.</para>
    /// </summary>
    public virtual unsafe Rect2 _FontGetGlyphUVRect(Rid fontRid, Vector2I size, long glyph)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the font hinting mode. Used by dynamic fonts only.</para>
    /// </summary>
    public virtual TextServer.Hinting _FontGetHinting(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns glyph position rounding behavior. If set to <see langword="true"/>, when aligning glyphs to the pixel boundaries rounding remainders are accumulated to ensure more uniform glyph distribution. This setting has no effect if subpixel positioning is enabled.</para>
    /// </summary>
    public virtual bool _FontGetKeepRoundingRemainders(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns kerning for the pair of glyphs.</para>
    /// </summary>
    public virtual unsafe Vector2 _FontGetKerning(Rid fontRid, long size, Vector2I glyphPair)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns list of the kerning overrides.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Vector2I> _FontGetKerningList(Rid fontRid, long size)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if support override is enabled for the <paramref name="language"/>.</para>
    /// </summary>
    public virtual bool _FontGetLanguageSupportOverride(Rid fontRid, string language)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns list of language support overrides.</para>
    /// </summary>
    public virtual string[] _FontGetLanguageSupportOverrides(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the width of the range around the shape between the minimum and maximum representable signed distance.</para>
    /// </summary>
    public virtual long _FontGetMsdfPixelRange(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns source font size used to generate MSDF textures.</para>
    /// </summary>
    public virtual long _FontGetMsdfSize(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns font family name.</para>
    /// </summary>
    public virtual string _FontGetName(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns font OpenType feature set override.</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _FontGetOpentypeFeatureOverrides(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see cref="Godot.Collections.Dictionary"/> with OpenType font name strings (localized font names, version, description, license information, sample text, etc.).</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _FontGetOtNameStrings(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns oversampling factor override. If set to a positive value, overrides the oversampling factor of the viewport this font is used in. See <see cref="Godot.Viewport.Oversampling"/>. This value doesn't override the <c>oversampling</c> parameter of <c>draw_*</c> methods. Used by dynamic fonts only.</para>
    /// </summary>
    public virtual double _FontGetOversampling(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns scaling factor of the color bitmap font.</para>
    /// </summary>
    public virtual double _FontGetScale(Rid fontRid, long size)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if support override is enabled for the <paramref name="script"/>.</para>
    /// </summary>
    public virtual bool _FontGetScriptSupportOverride(Rid fontRid, string script)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns list of script support overrides.</para>
    /// </summary>
    public virtual string[] _FontGetScriptSupportOverrides(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns font cache information, each entry contains the following fields: <c>Vector2i size_px</c> - font size in pixels, <c>float viewport_oversampling</c> - viewport oversampling factor, <c>int glyphs</c> - number of rendered glyphs, <c>int textures</c> - number of used textures, <c>int textures_size</c> - size of texture data in bytes.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _FontGetSizeCacheInfo(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns list of the font sizes in the cache. Each size is <see cref="Godot.Vector2I"/> with font size and outline size.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Vector2I> _FontGetSizeCacheList(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the spacing for <paramref name="spacing"/> in pixels (not relative to the font size).</para>
    /// </summary>
    public virtual long _FontGetSpacing(Rid fontRid, TextServer.SpacingType spacing)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns font stretch amount, compared to a normal width. A percentage value between <c>50%</c> and <c>200%</c>.</para>
    /// </summary>
    public virtual long _FontGetStretch(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns font style flags.</para>
    /// </summary>
    public virtual TextServer.FontStyle _FontGetStyle(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns font style name.</para>
    /// </summary>
    public virtual string _FontGetStyleName(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns font subpixel glyph positioning mode.</para>
    /// </summary>
    public virtual TextServer.SubpixelPositioning _FontGetSubpixelPositioning(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns a string containing all the characters available in the font.</para>
    /// </summary>
    public virtual string _FontGetSupportedChars(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns an array containing all glyph indices in the font.</para>
    /// </summary>
    public virtual int[] _FontGetSupportedGlyphs(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns number of textures used by font cache entry.</para>
    /// </summary>
    public virtual unsafe long _FontGetTextureCount(Rid fontRid, Vector2I size)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns font cache texture image data.</para>
    /// </summary>
    public virtual unsafe Image _FontGetTextureImage(Rid fontRid, Vector2I size, long textureIndex)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns array containing glyph packing data.</para>
    /// </summary>
    public virtual unsafe int[] _FontGetTextureOffsets(Rid fontRid, Vector2I size, long textureIndex)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns 2D transform applied to the font outlines.</para>
    /// </summary>
    public virtual Transform2D _FontGetTransform(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns pixel offset of the underline below the baseline.</para>
    /// </summary>
    public virtual double _FontGetUnderlinePosition(Rid fontRid, long size)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns thickness of the underline in pixels.</para>
    /// </summary>
    public virtual double _FontGetUnderlineThickness(Rid fontRid, long size)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns variation coordinates for the specified font cache entry.</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _FontGetVariationCoordinates(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns weight (boldness) of the font. A value in the <c>100...999</c> range, normal font weight is <c>400</c>, bold font weight is <c>700</c>.</para>
    /// </summary>
    public virtual long _FontGetWeight(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if a Unicode <paramref name="char"/> is available in the font.</para>
    /// </summary>
    public virtual bool _FontHasChar(Rid fontRid, long @char)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if system fonts can be automatically used as fallbacks.</para>
    /// </summary>
    public virtual bool _FontIsAllowSystemFallback(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if auto-hinting is supported and preferred over font built-in hinting.</para>
    /// </summary>
    public virtual bool _FontIsForceAutohinter(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if the font supports the given language (as a <a href="https://en.wikipedia.org/wiki/ISO_639-1">ISO 639</a> code).</para>
    /// </summary>
    public virtual bool _FontIsLanguageSupported(Rid fontRid, string language)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if color modulation is applied when drawing the font's colored glyphs.</para>
    /// </summary>
    public virtual bool _FontIsModulateColorGlyphs(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if glyphs of all sizes are rendered using single multichannel signed distance field generated from the dynamic font vector data.</para>
    /// </summary>
    public virtual bool _FontIsMultichannelSignedDistanceField(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if the font supports the given script (as a <a href="https://en.wikipedia.org/wiki/ISO_15924">ISO 15924</a> code).</para>
    /// </summary>
    public virtual bool _FontIsScriptSupported(Rid fontRid, string script)
    {
        return default;
    }

    /// <summary>
    /// <para>Removes specified rendered glyph information from the cache entry.</para>
    /// </summary>
    public virtual unsafe void _FontRemoveGlyph(Rid fontRid, Vector2I size, long glyph)
    {
    }

    /// <summary>
    /// <para>Removes kerning override for the pair of glyphs.</para>
    /// </summary>
    public virtual unsafe void _FontRemoveKerning(Rid fontRid, long size, Vector2I glyphPair)
    {
    }

    /// <summary>
    /// <para>Remove language support override.</para>
    /// </summary>
    public virtual void _FontRemoveLanguageSupportOverride(Rid fontRid, string language)
    {
    }

    /// <summary>
    /// <para>Removes script support override.</para>
    /// </summary>
    public virtual void _FontRemoveScriptSupportOverride(Rid fontRid, string script)
    {
    }

    /// <summary>
    /// <para>Removes specified font size from the cache entry.</para>
    /// </summary>
    public virtual unsafe void _FontRemoveSizeCache(Rid fontRid, Vector2I size)
    {
    }

    /// <summary>
    /// <para>Removes specified texture from the cache entry.</para>
    /// </summary>
    public virtual unsafe void _FontRemoveTexture(Rid fontRid, Vector2I size, long textureIndex)
    {
    }

    /// <summary>
    /// <para>Renders specified glyph to the font cache texture.</para>
    /// </summary>
    public virtual unsafe void _FontRenderGlyph(Rid fontRid, Vector2I size, long index)
    {
    }

    /// <summary>
    /// <para>Renders the range of characters to the font cache texture.</para>
    /// </summary>
    public virtual unsafe void _FontRenderRange(Rid fontRid, Vector2I size, long start, long end)
    {
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, system fonts can be automatically used as fallbacks.</para>
    /// </summary>
    public virtual void _FontSetAllowSystemFallback(Rid fontRid, bool allowSystemFallback)
    {
    }

    /// <summary>
    /// <para>Sets font anti-aliasing mode.</para>
    /// </summary>
    public virtual void _FontSetAntialiasing(Rid fontRid, TextServer.FontAntialiasing antialiasing)
    {
    }

    /// <summary>
    /// <para>Sets the font ascent (number of pixels above the baseline).</para>
    /// </summary>
    public virtual void _FontSetAscent(Rid fontRid, long size, double ascent)
    {
    }

    /// <summary>
    /// <para>Sets extra baseline offset (as a fraction of font height).</para>
    /// </summary>
    public virtual void _FontSetBaselineOffset(Rid fontRid, double baselineOffset)
    {
    }

    /// <summary>
    /// <para>Sets font source data, e.g contents of the dynamic font source file.</para>
    /// </summary>
    public virtual void _FontSetData(Rid fontRid, byte[] data)
    {
    }

    /// <summary>
    /// <para>Sets the font descent (number of pixels below the baseline).</para>
    /// </summary>
    public virtual void _FontSetDescent(Rid fontRid, long size, double descent)
    {
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, embedded font bitmap loading is disabled.</para>
    /// </summary>
    public virtual void _FontSetDisableEmbeddedBitmaps(Rid fontRid, bool disableEmbeddedBitmaps)
    {
    }

    /// <summary>
    /// <para>Sets font embolden strength. If <paramref name="strength"/> is not equal to zero, emboldens the font outlines. Negative values reduce the outline thickness.</para>
    /// </summary>
    public virtual void _FontSetEmbolden(Rid fontRid, double strength)
    {
    }

    /// <summary>
    /// <para>Sets an active face index in the TrueType / OpenType collection.</para>
    /// </summary>
    public virtual void _FontSetFaceIndex(Rid fontRid, long faceIndex)
    {
    }

    /// <summary>
    /// <para>Sets bitmap font fixed size. If set to value greater than zero, same cache entry will be used for all font sizes.</para>
    /// </summary>
    public virtual void _FontSetFixedSize(Rid fontRid, long fixedSize)
    {
    }

    /// <summary>
    /// <para>Sets bitmap font scaling mode. This property is used only if <c>fixed_size</c> is greater than zero.</para>
    /// </summary>
    public virtual void _FontSetFixedSizeScaleMode(Rid fontRid, TextServer.FixedSizeScaleMode fixedSizeScaleMode)
    {
    }

    /// <summary>
    /// <para>If set to <see langword="true"/> auto-hinting is preferred over font built-in hinting.</para>
    /// </summary>
    public virtual void _FontSetForceAutohinter(Rid fontRid, bool forceAutohinter)
    {
    }

    /// <summary>
    /// <para>If set to <see langword="true"/> font texture mipmap generation is enabled.</para>
    /// </summary>
    public virtual void _FontSetGenerateMipmaps(Rid fontRid, bool generateMipmaps)
    {
    }

    /// <summary>
    /// <para>Sets oversampling factor, shared by all font in the TextServer.</para>
    /// </summary>
    public virtual void _FontSetGlobalOversampling(double oversampling)
    {
    }

    /// <summary>
    /// <para>Sets glyph advance (offset of the next glyph).</para>
    /// </summary>
    public virtual unsafe void _FontSetGlyphAdvance(Rid fontRid, long size, long glyph, Vector2 advance)
    {
    }

    /// <summary>
    /// <para>Sets glyph offset from the baseline.</para>
    /// </summary>
    public virtual unsafe void _FontSetGlyphOffset(Rid fontRid, Vector2I size, long glyph, Vector2 offset)
    {
    }

    /// <summary>
    /// <para>Sets size of the glyph.</para>
    /// </summary>
    public virtual unsafe void _FontSetGlyphSize(Rid fontRid, Vector2I size, long glyph, Vector2 glSize)
    {
    }

    /// <summary>
    /// <para>Sets index of the cache texture containing the glyph.</para>
    /// </summary>
    public virtual unsafe void _FontSetGlyphTextureIdx(Rid fontRid, Vector2I size, long glyph, long textureIdx)
    {
    }

    /// <summary>
    /// <para>Sets rectangle in the cache texture containing the glyph.</para>
    /// </summary>
    public virtual unsafe void _FontSetGlyphUVRect(Rid fontRid, Vector2I size, long glyph, Rect2 uVRect)
    {
    }

    /// <summary>
    /// <para>Sets font hinting mode. Used by dynamic fonts only.</para>
    /// </summary>
    public virtual void _FontSetHinting(Rid fontRid, TextServer.Hinting hinting)
    {
    }

    /// <summary>
    /// <para>Sets glyph position rounding behavior. If set to <see langword="true"/>, when aligning glyphs to the pixel boundaries rounding remainders are accumulated to ensure more uniform glyph distribution. This setting has no effect if subpixel positioning is enabled.</para>
    /// </summary>
    public virtual void _FontSetKeepRoundingRemainders(Rid fontRid, bool keepRoundingRemainders)
    {
    }

    /// <summary>
    /// <para>Sets kerning for the pair of glyphs.</para>
    /// </summary>
    public virtual unsafe void _FontSetKerning(Rid fontRid, long size, Vector2I glyphPair, Vector2 kerning)
    {
    }

    /// <summary>
    /// <para>Adds override for <see cref="Godot.TextServerExtension._FontIsLanguageSupported(Rid, string)"/>.</para>
    /// </summary>
    public virtual void _FontSetLanguageSupportOverride(Rid fontRid, string language, bool supported)
    {
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, color modulation is applied when drawing colored glyphs, otherwise it's applied to the monochrome glyphs only.</para>
    /// </summary>
    public virtual void _FontSetModulateColorGlyphs(Rid fontRid, bool modulate)
    {
    }

    /// <summary>
    /// <para>Sets the width of the range around the shape between the minimum and maximum representable signed distance.</para>
    /// </summary>
    public virtual void _FontSetMsdfPixelRange(Rid fontRid, long msdfPixelRange)
    {
    }

    /// <summary>
    /// <para>Sets source font size used to generate MSDF textures.</para>
    /// </summary>
    public virtual void _FontSetMsdfSize(Rid fontRid, long msdfSize)
    {
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, glyphs of all sizes are rendered using single multichannel signed distance field generated from the dynamic font vector data. MSDF rendering allows displaying the font at any scaling factor without blurriness, and without incurring a CPU cost when the font size changes (since the font no longer needs to be rasterized on the CPU). As a downside, font hinting is not available with MSDF. The lack of font hinting may result in less crisp and less readable fonts at small sizes.</para>
    /// </summary>
    public virtual void _FontSetMultichannelSignedDistanceField(Rid fontRid, bool msdf)
    {
    }

    /// <summary>
    /// <para>Sets the font family name.</para>
    /// </summary>
    public virtual void _FontSetName(Rid fontRid, string name)
    {
    }

    /// <summary>
    /// <para>Sets font OpenType feature set override.</para>
    /// </summary>
    public virtual void _FontSetOpentypeFeatureOverrides(Rid fontRid, Godot.Collections.Dictionary overrides)
    {
    }

    /// <summary>
    /// <para>If set to a positive value, overrides the oversampling factor of the viewport this font is used in. See <see cref="Godot.Viewport.Oversampling"/>. This value doesn't override the <c>oversampling</c> parameter of <c>draw_*</c> methods. Used by dynamic fonts only.</para>
    /// </summary>
    public virtual void _FontSetOversampling(Rid fontRid, double oversampling)
    {
    }

    /// <summary>
    /// <para>Sets scaling factor of the color bitmap font.</para>
    /// </summary>
    public virtual void _FontSetScale(Rid fontRid, long size, double scale)
    {
    }

    /// <summary>
    /// <para>Adds override for <see cref="Godot.TextServerExtension._FontIsScriptSupported(Rid, string)"/>.</para>
    /// </summary>
    public virtual void _FontSetScriptSupportOverride(Rid fontRid, string script, bool supported)
    {
    }

    /// <summary>
    /// <para>Sets the spacing for <paramref name="spacing"/> to <paramref name="value"/> in pixels (not relative to the font size).</para>
    /// </summary>
    public virtual void _FontSetSpacing(Rid fontRid, TextServer.SpacingType spacing, long value)
    {
    }

    /// <summary>
    /// <para>Sets font stretch amount, compared to a normal width. A percentage value between <c>50%</c> and <c>200%</c>.</para>
    /// </summary>
    public virtual void _FontSetStretch(Rid fontRid, long stretch)
    {
    }

    /// <summary>
    /// <para>Sets the font style flags.</para>
    /// </summary>
    public virtual void _FontSetStyle(Rid fontRid, TextServer.FontStyle style)
    {
    }

    /// <summary>
    /// <para>Sets the font style name.</para>
    /// </summary>
    public virtual void _FontSetStyleName(Rid fontRid, string nameStyle)
    {
    }

    /// <summary>
    /// <para>Sets font subpixel glyph positioning mode.</para>
    /// </summary>
    public virtual void _FontSetSubpixelPositioning(Rid fontRid, TextServer.SubpixelPositioning subpixelPositioning)
    {
    }

    /// <summary>
    /// <para>Sets font cache texture image data.</para>
    /// </summary>
    public virtual unsafe void _FontSetTextureImage(Rid fontRid, Vector2I size, long textureIndex, Image image)
    {
    }

    /// <summary>
    /// <para>Sets array containing glyph packing data.</para>
    /// </summary>
    public virtual unsafe void _FontSetTextureOffsets(Rid fontRid, Vector2I size, long textureIndex, int[] offset)
    {
    }

    /// <summary>
    /// <para>Sets 2D transform, applied to the font outlines, can be used for slanting, flipping, and rotating glyphs.</para>
    /// </summary>
    public virtual unsafe void _FontSetTransform(Rid fontRid, Transform2D transform)
    {
    }

    /// <summary>
    /// <para>Sets pixel offset of the underline below the baseline.</para>
    /// </summary>
    public virtual void _FontSetUnderlinePosition(Rid fontRid, long size, double underlinePosition)
    {
    }

    /// <summary>
    /// <para>Sets thickness of the underline in pixels.</para>
    /// </summary>
    public virtual void _FontSetUnderlineThickness(Rid fontRid, long size, double underlineThickness)
    {
    }

    /// <summary>
    /// <para>Sets variation coordinates for the specified font cache entry.</para>
    /// </summary>
    public virtual void _FontSetVariationCoordinates(Rid fontRid, Godot.Collections.Dictionary variationCoordinates)
    {
    }

    /// <summary>
    /// <para>Sets weight (boldness) of the font. A value in the <c>100...999</c> range, normal font weight is <c>400</c>, bold font weight is <c>700</c>.</para>
    /// </summary>
    public virtual void _FontSetWeight(Rid fontRid, long weight)
    {
    }

    /// <summary>
    /// <para>Returns the dictionary of the supported OpenType features.</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _FontSupportedFeatureList(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the dictionary of the supported OpenType variation coordinates.</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _FontSupportedVariationList(Rid fontRid)
    {
        return default;
    }

    /// <summary>
    /// <para>Converts a number from Western Arabic (0..9) to the numeral system used in the given <paramref name="language"/>.</para>
    /// <para>If <paramref name="language"/> is an empty string, the active locale will be used.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TranslationServer.FormatNumber(string, string)' instead.")]
    public virtual string _FormatNumber(string number, string language)
    {
        return default;
    }

    /// <summary>
    /// <para>Frees an object created by this <see cref="Godot.TextServer"/>.</para>
    /// </summary>
    public virtual void _FreeRid(Rid rid)
    {
    }

    /// <summary>
    /// <para>Returns text server features, see <see cref="Godot.TextServer.Feature"/>.</para>
    /// </summary>
    public virtual long _GetFeatures()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns size of the replacement character (box with character hexadecimal code that is drawn in place of invalid characters).</para>
    /// </summary>
    public virtual Vector2 _GetHexCodeBoxSize(long size, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the name of the server interface.</para>
    /// </summary>
    public virtual string _GetName()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns default TextServer database (e.g. ICU break iterators and dictionaries).</para>
    /// </summary>
    public virtual byte[] _GetSupportData()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns default TextServer database (e.g. ICU break iterators and dictionaries) filename.</para>
    /// </summary>
    public virtual string _GetSupportDataFileName()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns TextServer database (e.g. ICU break iterators and dictionaries) description.</para>
    /// </summary>
    public virtual string _GetSupportDataInfo()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="rid"/> is valid resource owned by this text server.</para>
    /// </summary>
    public virtual bool _Has(Rid rid)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if the server supports a feature.</para>
    /// </summary>
    public virtual bool _HasFeature(TextServer.Feature feature)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns index of the first string in <paramref name="dict"/> which is visually confusable with the <paramref name="string"/>, or <c>-1</c> if none is found.</para>
    /// </summary>
    public virtual long _IsConfusable(string @string, string[] dict)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if locale is right-to-left.</para>
    /// </summary>
    public virtual bool _IsLocaleRightToLeft(string locale)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if the locale requires text server support data for line/word breaking.</para>
    /// </summary>
    public virtual bool _IsLocaleUsingSupportData(string locale)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="string"/> is a valid identifier.</para>
    /// </summary>
    public virtual bool _IsValidIdentifier(string @string)
    {
        return default;
    }

    public virtual bool _IsValidLetter(ulong unicode)
    {
        return default;
    }

    /// <summary>
    /// <para>Loads optional TextServer database (e.g. ICU break iterators and dictionaries).</para>
    /// </summary>
    public virtual bool _LoadSupportData(string fileName)
    {
        return default;
    }

    /// <summary>
    /// <para>Converts the given readable name of a feature, variation, script, or language to an OpenType tag.</para>
    /// </summary>
    public virtual long _NameToTag(string name)
    {
        return default;
    }

    /// <summary>
    /// <para>Converts <paramref name="number"/> from the numeral system used in the given <paramref name="language"/> to Western Arabic (0..9).</para>
    /// <para>If <paramref name="language"/> is an empty string, the active locale will be used.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TranslationServer.ParseNumber(string, string)' instead.")]
    public virtual string _ParseNumber(string number, string language)
    {
        return default;
    }

    /// <summary>
    /// <para>Default implementation of the BiDi algorithm override function.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Vector3I> _ParseStructuredText(TextServer.StructuredTextParser parserType, Godot.Collections.Array args, string text)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns percent sign used in the given <paramref name="language"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TranslationServer.GetPercentSign(string)' instead.")]
    public virtual string _PercentSign(string language)
    {
        return default;
    }

    /// <summary>
    /// <para>Increases the reference count of the specified oversampling level. This method is called by <see cref="Godot.Viewport"/>, and should not be used directly.</para>
    /// </summary>
    public virtual void _ReferenceOversamplingLevel(double oversampling)
    {
    }

    /// <summary>
    /// <para>Saves optional TextServer database (e.g. ICU break iterators and dictionaries) to the file.</para>
    /// </summary>
    public virtual bool _SaveSupportData(string fileName)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the number of uniform text runs in the buffer.</para>
    /// </summary>
    public virtual long _ShapedGetRunCount(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the direction of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public virtual TextServer.Direction _ShapedGetRunDirection(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the font RID of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public virtual Rid _ShapedGetRunFontRid(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the font size of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public virtual int _ShapedGetRunFontSize(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the language of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public virtual string _ShapedGetRunLanguage(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the embedded object of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public virtual Variant _ShapedGetRunObject(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the source text range of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public virtual Vector2I _ShapedGetRunRange(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the source text of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public virtual string _ShapedGetRunText(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns number of text spans added using <see cref="Godot.TextServerExtension._ShapedTextAddString(Rid, string, Godot.Collections.Array{Rid}, long, Godot.Collections.Dictionary, string, Variant)"/> or <see cref="Godot.TextServerExtension._ShapedTextAddObject(Rid, Variant, Vector2, InlineAlignment, long, double)"/>.</para>
    /// </summary>
    public virtual long _ShapedGetSpanCount(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns text embedded object key.</para>
    /// </summary>
    public virtual Variant _ShapedGetSpanEmbeddedObject(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns text span metadata.</para>
    /// </summary>
    public virtual Variant _ShapedGetSpanMeta(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the text span embedded object key.</para>
    /// </summary>
    public virtual Variant _ShapedGetSpanObject(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the text span source text.</para>
    /// </summary>
    public virtual string _ShapedGetSpanText(Rid shaped, long index)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the text buffer source text, including object replacement characters.</para>
    /// </summary>
    public virtual string _ShapedGetText(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Changes text span font, font size, and OpenType features, without changing the text.</para>
    /// </summary>
    public virtual void _ShapedSetSpanUpdateFont(Rid shaped, long index, Godot.Collections.Array<Rid> fonts, long size, Godot.Collections.Dictionary opentypeFeatures)
    {
    }

    /// <summary>
    /// <para>Adds inline object to the text buffer, <paramref name="key"/> must be unique. In the text, object is represented as <paramref name="length"/> object replacement characters.</para>
    /// </summary>
    public virtual unsafe bool _ShapedTextAddObject(Rid shaped, Variant key, Vector2 size, InlineAlignment inlineAlign, long length, double baseline)
    {
        return default;
    }

    /// <summary>
    /// <para>Adds text span and font to draw it to the text buffer.</para>
    /// </summary>
    public virtual bool _ShapedTextAddString(Rid shaped, string text, Godot.Collections.Array<Rid> fonts, long size, Godot.Collections.Dictionary opentypeFeatures, string language, Variant meta)
    {
        return default;
    }

    /// <summary>
    /// <para>Clears text buffer (removes text and inline objects).</para>
    /// </summary>
    public virtual void _ShapedTextClear(Rid shaped)
    {
    }

    /// <summary>
    /// <para>Returns composite character position closest to the <paramref name="pos"/>.</para>
    /// </summary>
    public virtual long _ShapedTextClosestCharacterPos(Rid shaped, long pos)
    {
        return default;
    }

    /// <summary>
    /// <para>Draw shaped text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the leftmost point of the baseline (for horizontal layout) or topmost point of the baseline (for vertical layout). If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    public virtual unsafe void _ShapedTextDraw(Rid shaped, Rid canvas, Vector2 pos, double clipL, double clipR, Color color, float oversampling)
    {
    }

    /// <summary>
    /// <para>Draw the outline of the shaped text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the leftmost point of the baseline (for horizontal layout) or topmost point of the baseline (for vertical layout). If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    public virtual unsafe void _ShapedTextDrawOutline(Rid shaped, Rid canvas, Vector2 pos, double clipL, double clipR, long outlineSize, Color color, float oversampling)
    {
    }

    /// <summary>
    /// <para>Duplicates shaped text buffer.</para>
    /// </summary>
    public virtual Rid _ShapedTextDuplicate(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Adjusts text width to fit to specified width, returns new text width.</para>
    /// </summary>
    public virtual double _ShapedTextFitToWidth(Rid shaped, double width, TextServer.JustificationFlag justificationFlags)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the text ascent (number of pixels above the baseline for horizontal layout or to the left of baseline for vertical).</para>
    /// </summary>
    public virtual double _ShapedTextGetAscent(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns array of the composite character boundaries.</para>
    /// </summary>
    public virtual int[] _ShapedTextGetCharacterBreaks(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns ellipsis character used for text clipping.</para>
    /// </summary>
    public virtual long _ShapedTextGetCustomEllipsis(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns custom punctuation character list, used for word breaking. If set to empty string, server defaults are used.</para>
    /// </summary>
    public virtual string _ShapedTextGetCustomPunctuation(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the text descent (number of pixels below the baseline for horizontal layout or to the right of baseline for vertical).</para>
    /// </summary>
    public virtual double _ShapedTextGetDescent(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns direction of the text.</para>
    /// </summary>
    public virtual TextServer.Direction _ShapedTextGetDirection(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns dominant direction of in the range of text.</para>
    /// </summary>
    public virtual long _ShapedTextGetDominantDirectionInRange(Rid shaped, long start, long end)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns number of glyphs in the ellipsis.</para>
    /// </summary>
    public virtual long _ShapedTextGetEllipsisGlyphCount(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns position of the ellipsis.</para>
    /// </summary>
    public virtual long _ShapedTextGetEllipsisPos(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns number of glyphs in the buffer.</para>
    /// </summary>
    public virtual long _ShapedTextGetGlyphCount(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns composite character's bounds as offsets from the start of the line.</para>
    /// </summary>
    public virtual Vector2 _ShapedTextGetGraphemeBounds(Rid shaped, long pos)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns direction of the text, inferred by the BiDi algorithm.</para>
    /// </summary>
    public virtual TextServer.Direction _ShapedTextGetInferredDirection(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Breaks text to the lines and returns character ranges for each line.</para>
    /// </summary>
    public virtual int[] _ShapedTextGetLineBreaks(Rid shaped, double width, long start, TextServer.LineBreakFlag breakFlags)
    {
        return default;
    }

    /// <summary>
    /// <para>Breaks text to the lines and columns. Returns character ranges for each segment.</para>
    /// </summary>
    public virtual int[] _ShapedTextGetLineBreaksAdv(Rid shaped, float[] width, long start, bool once, TextServer.LineBreakFlag breakFlags)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the glyph index of the inline object.</para>
    /// </summary>
    public virtual long _ShapedTextGetObjectGlyph(Rid shaped, Variant key)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the character range of the inline object.</para>
    /// </summary>
    public virtual Vector2I _ShapedTextGetObjectRange(Rid shaped, Variant key)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns bounding rectangle of the inline object.</para>
    /// </summary>
    public virtual Rect2 _ShapedTextGetObjectRect(Rid shaped, Variant key)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns array of inline objects.</para>
    /// </summary>
    public virtual Godot.Collections.Array _ShapedTextGetObjects(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns text orientation.</para>
    /// </summary>
    public virtual TextServer.Orientation _ShapedTextGetOrientation(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the parent buffer from which the substring originates.</para>
    /// </summary>
    public virtual Rid _ShapedTextGetParent(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if text buffer is configured to display control characters.</para>
    /// </summary>
    public virtual bool _ShapedTextGetPreserveControl(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if text buffer is configured to display hexadecimal codes in place of invalid characters.</para>
    /// </summary>
    public virtual bool _ShapedTextGetPreserveInvalid(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns substring buffer character range in the parent buffer.</para>
    /// </summary>
    public virtual Vector2I _ShapedTextGetRange(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns selection rectangles for the specified character range.</para>
    /// </summary>
    public virtual Vector2[] _ShapedTextGetSelection(Rid shaped, long start, long end)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns size of the text.</para>
    /// </summary>
    public virtual Vector2 _ShapedTextGetSize(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns extra spacing added between glyphs or lines in pixels.</para>
    /// </summary>
    public virtual long _ShapedTextGetSpacing(Rid shaped, TextServer.SpacingType spacing)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the position of the overrun trim.</para>
    /// </summary>
    public virtual long _ShapedTextGetTrimPos(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns pixel offset of the underline below the baseline.</para>
    /// </summary>
    public virtual double _ShapedTextGetUnderlinePosition(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns thickness of the underline.</para>
    /// </summary>
    public virtual double _ShapedTextGetUnderlineThickness(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns width (for horizontal layout) or height (for vertical) of the text.</para>
    /// </summary>
    public virtual double _ShapedTextGetWidth(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Breaks text into words and returns array of character ranges. Use <paramref name="graphemeFlags"/> to set what characters are used for breaking.</para>
    /// </summary>
    public virtual int[] _ShapedTextGetWordBreaks(Rid shaped, TextServer.GraphemeFlag graphemeFlags, TextServer.GraphemeFlag skipGraphemeFlags)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if an object with <paramref name="key"/> is embedded in this shaped text buffer.</para>
    /// </summary>
    public virtual bool _ShapedTextHasObject(Rid shaped, Variant key)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns grapheme index at the specified pixel offset at the baseline, or <c>-1</c> if none is found.</para>
    /// </summary>
    public virtual long _ShapedTextHitTestGrapheme(Rid shaped, double coord)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns caret character offset at the specified pixel offset at the baseline. This function always returns a valid position.</para>
    /// </summary>
    public virtual long _ShapedTextHitTestPosition(Rid shaped, double coord)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if buffer is successfully shaped.</para>
    /// </summary>
    public virtual bool _ShapedTextIsReady(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns composite character end position closest to the <paramref name="pos"/>.</para>
    /// </summary>
    public virtual long _ShapedTextNextCharacterPos(Rid shaped, long pos)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns grapheme end position closest to the <paramref name="pos"/>.</para>
    /// </summary>
    public virtual long _ShapedTextNextGraphemePos(Rid shaped, long pos)
    {
        return default;
    }

    /// <summary>
    /// <para>Trims text if it exceeds the given width.</para>
    /// </summary>
    public virtual void _ShapedTextOverrunTrimToWidth(Rid shaped, double width, TextServer.TextOverrunFlag trimFlags)
    {
    }

    /// <summary>
    /// <para>Returns composite character start position closest to the <paramref name="pos"/>.</para>
    /// </summary>
    public virtual long _ShapedTextPrevCharacterPos(Rid shaped, long pos)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns grapheme start position closest to the <paramref name="pos"/>.</para>
    /// </summary>
    public virtual long _ShapedTextPrevGraphemePos(Rid shaped, long pos)
    {
        return default;
    }

    /// <summary>
    /// <para>Sets new size and alignment of embedded object.</para>
    /// </summary>
    public virtual unsafe bool _ShapedTextResizeObject(Rid shaped, Variant key, Vector2 size, InlineAlignment inlineAlign, double baseline)
    {
        return default;
    }

    /// <summary>
    /// <para>Overrides BiDi for the structured text.</para>
    /// </summary>
    public virtual void _ShapedTextSetBidiOverride(Rid shaped, Godot.Collections.Array @override)
    {
    }

    /// <summary>
    /// <para>Sets ellipsis character used for text clipping.</para>
    /// </summary>
    public virtual void _ShapedTextSetCustomEllipsis(Rid shaped, long @char)
    {
    }

    /// <summary>
    /// <para>Sets custom punctuation character list, used for word breaking. If set to empty string, server defaults are used.</para>
    /// </summary>
    public virtual void _ShapedTextSetCustomPunctuation(Rid shaped, string punct)
    {
    }

    /// <summary>
    /// <para>Sets desired text direction. If set to <see cref="Godot.TextServer.Direction.Auto"/>, direction will be detected based on the buffer contents and current locale.</para>
    /// </summary>
    public virtual void _ShapedTextSetDirection(Rid shaped, TextServer.Direction direction)
    {
    }

    /// <summary>
    /// <para>Sets desired text orientation.</para>
    /// </summary>
    public virtual void _ShapedTextSetOrientation(Rid shaped, TextServer.Orientation orientation)
    {
    }

    /// <summary>
    /// <para>If set to <see langword="true"/> text buffer will display control characters.</para>
    /// </summary>
    public virtual void _ShapedTextSetPreserveControl(Rid shaped, bool enabled)
    {
    }

    /// <summary>
    /// <para>If set to <see langword="true"/> text buffer will display invalid characters as hexadecimal codes, otherwise nothing is displayed.</para>
    /// </summary>
    public virtual void _ShapedTextSetPreserveInvalid(Rid shaped, bool enabled)
    {
    }

    /// <summary>
    /// <para>Sets extra spacing added between glyphs or lines in pixels.</para>
    /// </summary>
    public virtual void _ShapedTextSetSpacing(Rid shaped, TextServer.SpacingType spacing, long value)
    {
    }

    /// <summary>
    /// <para>Shapes buffer if it's not shaped. Returns <see langword="true"/> if the string is shaped successfully.</para>
    /// </summary>
    public virtual bool _ShapedTextShape(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns text buffer for the substring of the text in the <paramref name="shaped"/> text buffer (including inline objects).</para>
    /// </summary>
    public virtual Rid _ShapedTextSubstr(Rid shaped, long start, long length)
    {
        return default;
    }

    /// <summary>
    /// <para>Aligns shaped text to the given tab-stops.</para>
    /// </summary>
    public virtual double _ShapedTextTabAlign(Rid shaped, float[] tabStops)
    {
        return default;
    }

    /// <summary>
    /// <para>Updates break points in the shaped text. This method is called by default implementation of text breaking functions.</para>
    /// </summary>
    public virtual bool _ShapedTextUpdateBreaks(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Updates justification points in the shaped text. This method is called by default implementation of text justification functions.</para>
    /// </summary>
    public virtual bool _ShapedTextUpdateJustificationOps(Rid shaped)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="string"/> is likely to be an attempt at confusing the reader.</para>
    /// </summary>
    public virtual bool _SpoofCheck(string @string)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns array of the composite character boundaries.</para>
    /// </summary>
    public virtual int[] _StringGetCharacterBreaks(string @string, string language)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns an array of the word break boundaries. Elements in the returned array are the offsets of the start and end of words. Therefore the length of the array is always even.</para>
    /// </summary>
    public virtual int[] _StringGetWordBreaks(string @string, string language, long charsPerLine)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the string converted to <c>lowercase</c>.</para>
    /// </summary>
    public virtual string _StringToLower(string @string, string language)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the string converted to <c>Title Case</c>.</para>
    /// </summary>
    public virtual string _StringToTitle(string @string, string language)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the string converted to <c>UPPERCASE</c>.</para>
    /// </summary>
    public virtual string _StringToUpper(string @string, string language)
    {
        return default;
    }

    /// <summary>
    /// <para>Strips diacritics from the string.</para>
    /// </summary>
    public virtual string _StripDiacritics(string @string)
    {
        return default;
    }

    /// <summary>
    /// <para>Converts the given OpenType tag to the readable name of a feature, variation, script, or language.</para>
    /// </summary>
    public virtual string _TagToName(long tag)
    {
        return default;
    }

    /// <summary>
    /// <para>Decreases the reference count of the specified oversampling level, and frees the font cache for oversampling level when the reference count reaches zero. This method is called by <see cref="Godot.Viewport"/>, and should not be used directly.</para>
    /// </summary>
    public virtual void _UnreferenceOversamplingLevel(double oversampling)
    {
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__cleanup = "_Cleanup";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create_font = "_CreateFont";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create_font_linked_variation = "_CreateFontLinkedVariation";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create_shaped_text = "_CreateShapedText";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__draw_hex_code_box = "_DrawHexCodeBox";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_clear_glyphs = "_FontClearGlyphs";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_clear_kerning_map = "_FontClearKerningMap";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_clear_size_cache = "_FontClearSizeCache";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_clear_system_fallback_cache = "_FontClearSystemFallbackCache";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_clear_textures = "_FontClearTextures";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_draw_glyph = "_FontDrawGlyph";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_draw_glyph_outline = "_FontDrawGlyphOutline";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_antialiasing = "_FontGetAntialiasing";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_ascent = "_FontGetAscent";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_baseline_offset = "_FontGetBaselineOffset";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_char_from_glyph_index = "_FontGetCharFromGlyphIndex";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_descent = "_FontGetDescent";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_disable_embedded_bitmaps = "_FontGetDisableEmbeddedBitmaps";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_embolden = "_FontGetEmbolden";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_face_count = "_FontGetFaceCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_face_index = "_FontGetFaceIndex";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_fixed_size = "_FontGetFixedSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_fixed_size_scale_mode = "_FontGetFixedSizeScaleMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_generate_mipmaps = "_FontGetGenerateMipmaps";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_global_oversampling = "_FontGetGlobalOversampling";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_glyph_advance = "_FontGetGlyphAdvance";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_glyph_contours = "_FontGetGlyphContours";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_glyph_index = "_FontGetGlyphIndex";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_glyph_list = "_FontGetGlyphList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_glyph_offset = "_FontGetGlyphOffset";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_glyph_size = "_FontGetGlyphSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_glyph_texture_idx = "_FontGetGlyphTextureIdx";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_glyph_texture_rid = "_FontGetGlyphTextureRid";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_glyph_texture_size = "_FontGetGlyphTextureSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_glyph_uv_rect = "_FontGetGlyphUVRect";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_hinting = "_FontGetHinting";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_keep_rounding_remainders = "_FontGetKeepRoundingRemainders";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_kerning = "_FontGetKerning";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_kerning_list = "_FontGetKerningList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_language_support_override = "_FontGetLanguageSupportOverride";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_language_support_overrides = "_FontGetLanguageSupportOverrides";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_msdf_pixel_range = "_FontGetMsdfPixelRange";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_msdf_size = "_FontGetMsdfSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_name = "_FontGetName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_opentype_feature_overrides = "_FontGetOpentypeFeatureOverrides";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_ot_name_strings = "_FontGetOtNameStrings";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_oversampling = "_FontGetOversampling";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_scale = "_FontGetScale";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_script_support_override = "_FontGetScriptSupportOverride";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_script_support_overrides = "_FontGetScriptSupportOverrides";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_size_cache_info = "_FontGetSizeCacheInfo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_size_cache_list = "_FontGetSizeCacheList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_spacing = "_FontGetSpacing";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_stretch = "_FontGetStretch";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_style = "_FontGetStyle";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_style_name = "_FontGetStyleName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_subpixel_positioning = "_FontGetSubpixelPositioning";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_supported_chars = "_FontGetSupportedChars";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_supported_glyphs = "_FontGetSupportedGlyphs";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_texture_count = "_FontGetTextureCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_texture_image = "_FontGetTextureImage";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_texture_offsets = "_FontGetTextureOffsets";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_transform = "_FontGetTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_underline_position = "_FontGetUnderlinePosition";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_underline_thickness = "_FontGetUnderlineThickness";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_variation_coordinates = "_FontGetVariationCoordinates";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_get_weight = "_FontGetWeight";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_has_char = "_FontHasChar";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_is_allow_system_fallback = "_FontIsAllowSystemFallback";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_is_force_autohinter = "_FontIsForceAutohinter";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_is_language_supported = "_FontIsLanguageSupported";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_is_modulate_color_glyphs = "_FontIsModulateColorGlyphs";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_is_multichannel_signed_distance_field = "_FontIsMultichannelSignedDistanceField";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_is_script_supported = "_FontIsScriptSupported";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_remove_glyph = "_FontRemoveGlyph";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_remove_kerning = "_FontRemoveKerning";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_remove_language_support_override = "_FontRemoveLanguageSupportOverride";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_remove_script_support_override = "_FontRemoveScriptSupportOverride";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_remove_size_cache = "_FontRemoveSizeCache";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_remove_texture = "_FontRemoveTexture";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_render_glyph = "_FontRenderGlyph";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_render_range = "_FontRenderRange";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_allow_system_fallback = "_FontSetAllowSystemFallback";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_antialiasing = "_FontSetAntialiasing";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_ascent = "_FontSetAscent";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_baseline_offset = "_FontSetBaselineOffset";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_data = "_FontSetData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_descent = "_FontSetDescent";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_disable_embedded_bitmaps = "_FontSetDisableEmbeddedBitmaps";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_embolden = "_FontSetEmbolden";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_face_index = "_FontSetFaceIndex";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_fixed_size = "_FontSetFixedSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_fixed_size_scale_mode = "_FontSetFixedSizeScaleMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_force_autohinter = "_FontSetForceAutohinter";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_generate_mipmaps = "_FontSetGenerateMipmaps";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_global_oversampling = "_FontSetGlobalOversampling";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_glyph_advance = "_FontSetGlyphAdvance";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_glyph_offset = "_FontSetGlyphOffset";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_glyph_size = "_FontSetGlyphSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_glyph_texture_idx = "_FontSetGlyphTextureIdx";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_glyph_uv_rect = "_FontSetGlyphUVRect";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_hinting = "_FontSetHinting";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_keep_rounding_remainders = "_FontSetKeepRoundingRemainders";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_kerning = "_FontSetKerning";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_language_support_override = "_FontSetLanguageSupportOverride";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_modulate_color_glyphs = "_FontSetModulateColorGlyphs";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_msdf_pixel_range = "_FontSetMsdfPixelRange";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_msdf_size = "_FontSetMsdfSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_multichannel_signed_distance_field = "_FontSetMultichannelSignedDistanceField";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_name = "_FontSetName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_opentype_feature_overrides = "_FontSetOpentypeFeatureOverrides";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_oversampling = "_FontSetOversampling";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_scale = "_FontSetScale";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_script_support_override = "_FontSetScriptSupportOverride";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_spacing = "_FontSetSpacing";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_stretch = "_FontSetStretch";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_style = "_FontSetStyle";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_style_name = "_FontSetStyleName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_subpixel_positioning = "_FontSetSubpixelPositioning";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_texture_image = "_FontSetTextureImage";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_texture_offsets = "_FontSetTextureOffsets";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_transform = "_FontSetTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_underline_position = "_FontSetUnderlinePosition";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_underline_thickness = "_FontSetUnderlineThickness";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_variation_coordinates = "_FontSetVariationCoordinates";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_set_weight = "_FontSetWeight";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_supported_feature_list = "_FontSupportedFeatureList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__font_supported_variation_list = "_FontSupportedVariationList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__format_number = "_FormatNumber";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__free_rid = "_FreeRid";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_features = "_GetFeatures";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_hex_code_box_size = "_GetHexCodeBoxSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_name = "_GetName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_support_data = "_GetSupportData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_support_data_filename = "_GetSupportDataFileName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_support_data_info = "_GetSupportDataInfo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has = "_Has";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_feature = "_HasFeature";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_confusable = "_IsConfusable";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_locale_right_to_left = "_IsLocaleRightToLeft";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_locale_using_support_data = "_IsLocaleUsingSupportData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_valid_identifier = "_IsValidIdentifier";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_valid_letter = "_IsValidLetter";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__load_support_data = "_LoadSupportData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__name_to_tag = "_NameToTag";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_number = "_ParseNumber";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__parse_structured_text = "_ParseStructuredText";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__percent_sign = "_PercentSign";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__reference_oversampling_level = "_ReferenceOversamplingLevel";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__save_support_data = "_SaveSupportData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_run_count = "_ShapedGetRunCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_run_direction = "_ShapedGetRunDirection";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_run_font_rid = "_ShapedGetRunFontRid";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_run_font_size = "_ShapedGetRunFontSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_run_language = "_ShapedGetRunLanguage";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_run_object = "_ShapedGetRunObject";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_run_range = "_ShapedGetRunRange";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_run_text = "_ShapedGetRunText";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_span_count = "_ShapedGetSpanCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_span_embedded_object = "_ShapedGetSpanEmbeddedObject";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_span_meta = "_ShapedGetSpanMeta";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_span_object = "_ShapedGetSpanObject";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_span_text = "_ShapedGetSpanText";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_get_text = "_ShapedGetText";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_set_span_update_font = "_ShapedSetSpanUpdateFont";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_add_object = "_ShapedTextAddObject";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_add_string = "_ShapedTextAddString";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_clear = "_ShapedTextClear";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_closest_character_pos = "_ShapedTextClosestCharacterPos";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_draw = "_ShapedTextDraw";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_draw_outline = "_ShapedTextDrawOutline";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_duplicate = "_ShapedTextDuplicate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_fit_to_width = "_ShapedTextFitToWidth";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_ascent = "_ShapedTextGetAscent";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_character_breaks = "_ShapedTextGetCharacterBreaks";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_custom_ellipsis = "_ShapedTextGetCustomEllipsis";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_custom_punctuation = "_ShapedTextGetCustomPunctuation";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_descent = "_ShapedTextGetDescent";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_direction = "_ShapedTextGetDirection";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_dominant_direction_in_range = "_ShapedTextGetDominantDirectionInRange";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_ellipsis_glyph_count = "_ShapedTextGetEllipsisGlyphCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_ellipsis_pos = "_ShapedTextGetEllipsisPos";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_glyph_count = "_ShapedTextGetGlyphCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_grapheme_bounds = "_ShapedTextGetGraphemeBounds";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_inferred_direction = "_ShapedTextGetInferredDirection";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_line_breaks = "_ShapedTextGetLineBreaks";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_line_breaks_adv = "_ShapedTextGetLineBreaksAdv";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_object_glyph = "_ShapedTextGetObjectGlyph";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_object_range = "_ShapedTextGetObjectRange";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_object_rect = "_ShapedTextGetObjectRect";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_objects = "_ShapedTextGetObjects";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_orientation = "_ShapedTextGetOrientation";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_parent = "_ShapedTextGetParent";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_preserve_control = "_ShapedTextGetPreserveControl";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_preserve_invalid = "_ShapedTextGetPreserveInvalid";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_range = "_ShapedTextGetRange";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_selection = "_ShapedTextGetSelection";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_size = "_ShapedTextGetSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_spacing = "_ShapedTextGetSpacing";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_trim_pos = "_ShapedTextGetTrimPos";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_underline_position = "_ShapedTextGetUnderlinePosition";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_underline_thickness = "_ShapedTextGetUnderlineThickness";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_width = "_ShapedTextGetWidth";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_get_word_breaks = "_ShapedTextGetWordBreaks";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_has_object = "_ShapedTextHasObject";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_hit_test_grapheme = "_ShapedTextHitTestGrapheme";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_hit_test_position = "_ShapedTextHitTestPosition";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_is_ready = "_ShapedTextIsReady";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_next_character_pos = "_ShapedTextNextCharacterPos";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_next_grapheme_pos = "_ShapedTextNextGraphemePos";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_overrun_trim_to_width = "_ShapedTextOverrunTrimToWidth";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_prev_character_pos = "_ShapedTextPrevCharacterPos";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_prev_grapheme_pos = "_ShapedTextPrevGraphemePos";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_resize_object = "_ShapedTextResizeObject";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_set_bidi_override = "_ShapedTextSetBidiOverride";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_set_custom_ellipsis = "_ShapedTextSetCustomEllipsis";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_set_custom_punctuation = "_ShapedTextSetCustomPunctuation";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_set_direction = "_ShapedTextSetDirection";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_set_orientation = "_ShapedTextSetOrientation";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_set_preserve_control = "_ShapedTextSetPreserveControl";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_set_preserve_invalid = "_ShapedTextSetPreserveInvalid";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_set_spacing = "_ShapedTextSetSpacing";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_shape = "_ShapedTextShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_substr = "_ShapedTextSubstr";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_tab_align = "_ShapedTextTabAlign";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_update_breaks = "_ShapedTextUpdateBreaks";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shaped_text_update_justification_ops = "_ShapedTextUpdateJustificationOps";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__spoof_check = "_SpoofCheck";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__string_get_character_breaks = "_StringGetCharacterBreaks";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__string_get_word_breaks = "_StringGetWordBreaks";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__string_to_lower = "_StringToLower";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__string_to_title = "_StringToTitle";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__string_to_upper = "_StringToUpper";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__strip_diacritics = "_StripDiacritics";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__tag_to_name = "_TagToName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__unreference_oversampling_level = "_UnreferenceOversamplingLevel";

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
        if ((method == MethodProxyName__cleanup || method == MethodName._Cleanup) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__cleanup.NativeValue))
        {
            _Cleanup();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__create_font || method == MethodName._CreateFont) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__create_font.NativeValue))
        {
            var callRet = _CreateFont();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__create_font_linked_variation || method == MethodName._CreateFontLinkedVariation) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__create_font_linked_variation.NativeValue))
        {
            var callRet = _CreateFontLinkedVariation(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__create_shaped_text || method == MethodName._CreateShapedText) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__create_shaped_text.NativeValue))
        {
            var callRet = _CreateShapedText(VariantUtils.ConvertTo<TextServer.Direction>(args[0]), VariantUtils.ConvertTo<TextServer.Orientation>(args[1]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__draw_hex_code_box || method == MethodName._DrawHexCodeBox) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__draw_hex_code_box.NativeValue))
        {
            _DrawHexCodeBox(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]), VariantUtils.ConvertTo<long>(args[3]), VariantUtils.ConvertTo<Color>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_clear_glyphs || method == MethodName._FontClearGlyphs) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_clear_glyphs.NativeValue))
        {
            _FontClearGlyphs(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_clear_kerning_map || method == MethodName._FontClearKerningMap) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_clear_kerning_map.NativeValue))
        {
            _FontClearKerningMap(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_clear_size_cache || method == MethodName._FontClearSizeCache) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_clear_size_cache.NativeValue))
        {
            _FontClearSizeCache(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_clear_system_fallback_cache || method == MethodName._FontClearSystemFallbackCache) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_clear_system_fallback_cache.NativeValue))
        {
            _FontClearSystemFallbackCache();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_clear_textures || method == MethodName._FontClearTextures) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_clear_textures.NativeValue))
        {
            _FontClearTextures(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_draw_glyph || method == MethodName._FontDrawGlyph) && args.Count == 7 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_draw_glyph.NativeValue))
        {
            _FontDrawGlyph(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<Vector2>(args[3]), VariantUtils.ConvertTo<long>(args[4]), VariantUtils.ConvertTo<Color>(args[5]), VariantUtils.ConvertTo<float>(args[6]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_draw_glyph_outline || method == MethodName._FontDrawGlyphOutline) && args.Count == 8 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_draw_glyph_outline.NativeValue))
        {
            _FontDrawGlyphOutline(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]), VariantUtils.ConvertTo<Vector2>(args[4]), VariantUtils.ConvertTo<long>(args[5]), VariantUtils.ConvertTo<Color>(args[6]), VariantUtils.ConvertTo<float>(args[7]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_get_antialiasing || method == MethodName._FontGetAntialiasing) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_antialiasing.NativeValue))
        {
            var callRet = _FontGetAntialiasing(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<TextServer.FontAntialiasing>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_ascent || method == MethodName._FontGetAscent) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_ascent.NativeValue))
        {
            var callRet = _FontGetAscent(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_baseline_offset || method == MethodName._FontGetBaselineOffset) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_baseline_offset.NativeValue))
        {
            var callRet = _FontGetBaselineOffset(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_char_from_glyph_index || method == MethodName._FontGetCharFromGlyphIndex) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_char_from_glyph_index.NativeValue))
        {
            var callRet = _FontGetCharFromGlyphIndex(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_descent || method == MethodName._FontGetDescent) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_descent.NativeValue))
        {
            var callRet = _FontGetDescent(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_disable_embedded_bitmaps || method == MethodName._FontGetDisableEmbeddedBitmaps) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_disable_embedded_bitmaps.NativeValue))
        {
            var callRet = _FontGetDisableEmbeddedBitmaps(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_embolden || method == MethodName._FontGetEmbolden) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_embolden.NativeValue))
        {
            var callRet = _FontGetEmbolden(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_face_count || method == MethodName._FontGetFaceCount) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_face_count.NativeValue))
        {
            var callRet = _FontGetFaceCount(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_face_index || method == MethodName._FontGetFaceIndex) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_face_index.NativeValue))
        {
            var callRet = _FontGetFaceIndex(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_fixed_size || method == MethodName._FontGetFixedSize) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_fixed_size.NativeValue))
        {
            var callRet = _FontGetFixedSize(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_fixed_size_scale_mode || method == MethodName._FontGetFixedSizeScaleMode) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_fixed_size_scale_mode.NativeValue))
        {
            var callRet = _FontGetFixedSizeScaleMode(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<TextServer.FixedSizeScaleMode>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_generate_mipmaps || method == MethodName._FontGetGenerateMipmaps) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_generate_mipmaps.NativeValue))
        {
            var callRet = _FontGetGenerateMipmaps(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_global_oversampling || method == MethodName._FontGetGlobalOversampling) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_global_oversampling.NativeValue))
        {
            var callRet = _FontGetGlobalOversampling();
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_glyph_advance || method == MethodName._FontGetGlyphAdvance) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_glyph_advance.NativeValue))
        {
            var callRet = _FontGetGlyphAdvance(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_glyph_contours || method == MethodName._FontGetGlyphContours) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_glyph_contours.NativeValue))
        {
            var callRet = _FontGetGlyphContours(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_glyph_index || method == MethodName._FontGetGlyphIndex) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_glyph_index.NativeValue))
        {
            var callRet = _FontGetGlyphIndex(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_glyph_list || method == MethodName._FontGetGlyphList) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_glyph_list.NativeValue))
        {
            var callRet = _FontGetGlyphList(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_glyph_offset || method == MethodName._FontGetGlyphOffset) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_glyph_offset.NativeValue))
        {
            var callRet = _FontGetGlyphOffset(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_glyph_size || method == MethodName._FontGetGlyphSize) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_glyph_size.NativeValue))
        {
            var callRet = _FontGetGlyphSize(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_glyph_texture_idx || method == MethodName._FontGetGlyphTextureIdx) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_glyph_texture_idx.NativeValue))
        {
            var callRet = _FontGetGlyphTextureIdx(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_glyph_texture_rid || method == MethodName._FontGetGlyphTextureRid) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_glyph_texture_rid.NativeValue))
        {
            var callRet = _FontGetGlyphTextureRid(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_glyph_texture_size || method == MethodName._FontGetGlyphTextureSize) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_glyph_texture_size.NativeValue))
        {
            var callRet = _FontGetGlyphTextureSize(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_glyph_uv_rect || method == MethodName._FontGetGlyphUVRect) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_glyph_uv_rect.NativeValue))
        {
            var callRet = _FontGetGlyphUVRect(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<Rect2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_hinting || method == MethodName._FontGetHinting) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_hinting.NativeValue))
        {
            var callRet = _FontGetHinting(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<TextServer.Hinting>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_keep_rounding_remainders || method == MethodName._FontGetKeepRoundingRemainders) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_keep_rounding_remainders.NativeValue))
        {
            var callRet = _FontGetKeepRoundingRemainders(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_kerning || method == MethodName._FontGetKerning) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_kerning.NativeValue))
        {
            var callRet = _FontGetKerning(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<Vector2I>(args[2]));
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_kerning_list || method == MethodName._FontGetKerningList) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_kerning_list.NativeValue))
        {
            var callRet = _FontGetKerningList(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_language_support_override || method == MethodName._FontGetLanguageSupportOverride) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_language_support_override.NativeValue))
        {
            var callRet = _FontGetLanguageSupportOverride(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_language_support_overrides || method == MethodName._FontGetLanguageSupportOverrides) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_language_support_overrides.NativeValue))
        {
            var callRet = _FontGetLanguageSupportOverrides(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_msdf_pixel_range || method == MethodName._FontGetMsdfPixelRange) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_msdf_pixel_range.NativeValue))
        {
            var callRet = _FontGetMsdfPixelRange(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_msdf_size || method == MethodName._FontGetMsdfSize) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_msdf_size.NativeValue))
        {
            var callRet = _FontGetMsdfSize(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_name || method == MethodName._FontGetName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_name.NativeValue))
        {
            var callRet = _FontGetName(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_opentype_feature_overrides || method == MethodName._FontGetOpentypeFeatureOverrides) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_opentype_feature_overrides.NativeValue))
        {
            var callRet = _FontGetOpentypeFeatureOverrides(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_ot_name_strings || method == MethodName._FontGetOtNameStrings) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_ot_name_strings.NativeValue))
        {
            var callRet = _FontGetOtNameStrings(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_oversampling || method == MethodName._FontGetOversampling) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_oversampling.NativeValue))
        {
            var callRet = _FontGetOversampling(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_scale || method == MethodName._FontGetScale) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_scale.NativeValue))
        {
            var callRet = _FontGetScale(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_script_support_override || method == MethodName._FontGetScriptSupportOverride) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_script_support_override.NativeValue))
        {
            var callRet = _FontGetScriptSupportOverride(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_script_support_overrides || method == MethodName._FontGetScriptSupportOverrides) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_script_support_overrides.NativeValue))
        {
            var callRet = _FontGetScriptSupportOverrides(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_size_cache_info || method == MethodName._FontGetSizeCacheInfo) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_size_cache_info.NativeValue))
        {
            var callRet = _FontGetSizeCacheInfo(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_size_cache_list || method == MethodName._FontGetSizeCacheList) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_size_cache_list.NativeValue))
        {
            var callRet = _FontGetSizeCacheList(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_spacing || method == MethodName._FontGetSpacing) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_spacing.NativeValue))
        {
            var callRet = _FontGetSpacing(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.SpacingType>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_stretch || method == MethodName._FontGetStretch) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_stretch.NativeValue))
        {
            var callRet = _FontGetStretch(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_style || method == MethodName._FontGetStyle) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_style.NativeValue))
        {
            var callRet = _FontGetStyle(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<TextServer.FontStyle>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_style_name || method == MethodName._FontGetStyleName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_style_name.NativeValue))
        {
            var callRet = _FontGetStyleName(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_subpixel_positioning || method == MethodName._FontGetSubpixelPositioning) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_subpixel_positioning.NativeValue))
        {
            var callRet = _FontGetSubpixelPositioning(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<TextServer.SubpixelPositioning>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_supported_chars || method == MethodName._FontGetSupportedChars) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_supported_chars.NativeValue))
        {
            var callRet = _FontGetSupportedChars(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_supported_glyphs || method == MethodName._FontGetSupportedGlyphs) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_supported_glyphs.NativeValue))
        {
            var callRet = _FontGetSupportedGlyphs(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_texture_count || method == MethodName._FontGetTextureCount) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_texture_count.NativeValue))
        {
            var callRet = _FontGetTextureCount(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_texture_image || method == MethodName._FontGetTextureImage) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_texture_image.NativeValue))
        {
            var callRet = _FontGetTextureImage(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<Image>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_texture_offsets || method == MethodName._FontGetTextureOffsets) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_texture_offsets.NativeValue))
        {
            var callRet = _FontGetTextureOffsets(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_transform || method == MethodName._FontGetTransform) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_transform.NativeValue))
        {
            var callRet = _FontGetTransform(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Transform2D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_underline_position || method == MethodName._FontGetUnderlinePosition) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_underline_position.NativeValue))
        {
            var callRet = _FontGetUnderlinePosition(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_underline_thickness || method == MethodName._FontGetUnderlineThickness) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_underline_thickness.NativeValue))
        {
            var callRet = _FontGetUnderlineThickness(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_variation_coordinates || method == MethodName._FontGetVariationCoordinates) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_variation_coordinates.NativeValue))
        {
            var callRet = _FontGetVariationCoordinates(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_get_weight || method == MethodName._FontGetWeight) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_get_weight.NativeValue))
        {
            var callRet = _FontGetWeight(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_has_char || method == MethodName._FontHasChar) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_has_char.NativeValue))
        {
            var callRet = _FontHasChar(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_is_allow_system_fallback || method == MethodName._FontIsAllowSystemFallback) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_is_allow_system_fallback.NativeValue))
        {
            var callRet = _FontIsAllowSystemFallback(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_is_force_autohinter || method == MethodName._FontIsForceAutohinter) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_is_force_autohinter.NativeValue))
        {
            var callRet = _FontIsForceAutohinter(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_is_language_supported || method == MethodName._FontIsLanguageSupported) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_is_language_supported.NativeValue))
        {
            var callRet = _FontIsLanguageSupported(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_is_modulate_color_glyphs || method == MethodName._FontIsModulateColorGlyphs) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_is_modulate_color_glyphs.NativeValue))
        {
            var callRet = _FontIsModulateColorGlyphs(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_is_multichannel_signed_distance_field || method == MethodName._FontIsMultichannelSignedDistanceField) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_is_multichannel_signed_distance_field.NativeValue))
        {
            var callRet = _FontIsMultichannelSignedDistanceField(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_is_script_supported || method == MethodName._FontIsScriptSupported) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_is_script_supported.NativeValue))
        {
            var callRet = _FontIsScriptSupported(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_remove_glyph || method == MethodName._FontRemoveGlyph) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_remove_glyph.NativeValue))
        {
            _FontRemoveGlyph(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_remove_kerning || method == MethodName._FontRemoveKerning) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_remove_kerning.NativeValue))
        {
            _FontRemoveKerning(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<Vector2I>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_remove_language_support_override || method == MethodName._FontRemoveLanguageSupportOverride) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_remove_language_support_override.NativeValue))
        {
            _FontRemoveLanguageSupportOverride(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_remove_script_support_override || method == MethodName._FontRemoveScriptSupportOverride) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_remove_script_support_override.NativeValue))
        {
            _FontRemoveScriptSupportOverride(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_remove_size_cache || method == MethodName._FontRemoveSizeCache) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_remove_size_cache.NativeValue))
        {
            _FontRemoveSizeCache(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_remove_texture || method == MethodName._FontRemoveTexture) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_remove_texture.NativeValue))
        {
            _FontRemoveTexture(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_render_glyph || method == MethodName._FontRenderGlyph) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_render_glyph.NativeValue))
        {
            _FontRenderGlyph(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_render_range || method == MethodName._FontRenderRange) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_render_range.NativeValue))
        {
            _FontRenderRange(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_allow_system_fallback || method == MethodName._FontSetAllowSystemFallback) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_allow_system_fallback.NativeValue))
        {
            _FontSetAllowSystemFallback(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_antialiasing || method == MethodName._FontSetAntialiasing) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_antialiasing.NativeValue))
        {
            _FontSetAntialiasing(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.FontAntialiasing>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_ascent || method == MethodName._FontSetAscent) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_ascent.NativeValue))
        {
            _FontSetAscent(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<double>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_baseline_offset || method == MethodName._FontSetBaselineOffset) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_baseline_offset.NativeValue))
        {
            _FontSetBaselineOffset(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<double>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_data || method == MethodName._FontSetData) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_data.NativeValue))
        {
            _FontSetData(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<byte[]>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_descent || method == MethodName._FontSetDescent) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_descent.NativeValue))
        {
            _FontSetDescent(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<double>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_disable_embedded_bitmaps || method == MethodName._FontSetDisableEmbeddedBitmaps) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_disable_embedded_bitmaps.NativeValue))
        {
            _FontSetDisableEmbeddedBitmaps(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_embolden || method == MethodName._FontSetEmbolden) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_embolden.NativeValue))
        {
            _FontSetEmbolden(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<double>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_face_index || method == MethodName._FontSetFaceIndex) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_face_index.NativeValue))
        {
            _FontSetFaceIndex(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_fixed_size || method == MethodName._FontSetFixedSize) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_fixed_size.NativeValue))
        {
            _FontSetFixedSize(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_fixed_size_scale_mode || method == MethodName._FontSetFixedSizeScaleMode) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_fixed_size_scale_mode.NativeValue))
        {
            _FontSetFixedSizeScaleMode(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.FixedSizeScaleMode>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_force_autohinter || method == MethodName._FontSetForceAutohinter) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_force_autohinter.NativeValue))
        {
            _FontSetForceAutohinter(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_generate_mipmaps || method == MethodName._FontSetGenerateMipmaps) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_generate_mipmaps.NativeValue))
        {
            _FontSetGenerateMipmaps(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_global_oversampling || method == MethodName._FontSetGlobalOversampling) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_global_oversampling.NativeValue))
        {
            _FontSetGlobalOversampling(VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_glyph_advance || method == MethodName._FontSetGlyphAdvance) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_glyph_advance.NativeValue))
        {
            _FontSetGlyphAdvance(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<Vector2>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_glyph_offset || method == MethodName._FontSetGlyphOffset) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_glyph_offset.NativeValue))
        {
            _FontSetGlyphOffset(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<Vector2>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_glyph_size || method == MethodName._FontSetGlyphSize) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_glyph_size.NativeValue))
        {
            _FontSetGlyphSize(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<Vector2>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_glyph_texture_idx || method == MethodName._FontSetGlyphTextureIdx) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_glyph_texture_idx.NativeValue))
        {
            _FontSetGlyphTextureIdx(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_glyph_uv_rect || method == MethodName._FontSetGlyphUVRect) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_glyph_uv_rect.NativeValue))
        {
            _FontSetGlyphUVRect(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<Rect2>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_hinting || method == MethodName._FontSetHinting) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_hinting.NativeValue))
        {
            _FontSetHinting(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.Hinting>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_keep_rounding_remainders || method == MethodName._FontSetKeepRoundingRemainders) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_keep_rounding_remainders.NativeValue))
        {
            _FontSetKeepRoundingRemainders(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_kerning || method == MethodName._FontSetKerning) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_kerning.NativeValue))
        {
            _FontSetKerning(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<Vector2I>(args[2]), VariantUtils.ConvertTo<Vector2>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_language_support_override || method == MethodName._FontSetLanguageSupportOverride) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_language_support_override.NativeValue))
        {
            _FontSetLanguageSupportOverride(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_modulate_color_glyphs || method == MethodName._FontSetModulateColorGlyphs) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_modulate_color_glyphs.NativeValue))
        {
            _FontSetModulateColorGlyphs(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_msdf_pixel_range || method == MethodName._FontSetMsdfPixelRange) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_msdf_pixel_range.NativeValue))
        {
            _FontSetMsdfPixelRange(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_msdf_size || method == MethodName._FontSetMsdfSize) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_msdf_size.NativeValue))
        {
            _FontSetMsdfSize(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_multichannel_signed_distance_field || method == MethodName._FontSetMultichannelSignedDistanceField) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_multichannel_signed_distance_field.NativeValue))
        {
            _FontSetMultichannelSignedDistanceField(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_name || method == MethodName._FontSetName) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_name.NativeValue))
        {
            _FontSetName(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_opentype_feature_overrides || method == MethodName._FontSetOpentypeFeatureOverrides) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_opentype_feature_overrides.NativeValue))
        {
            _FontSetOpentypeFeatureOverrides(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_oversampling || method == MethodName._FontSetOversampling) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_oversampling.NativeValue))
        {
            _FontSetOversampling(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<double>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_scale || method == MethodName._FontSetScale) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_scale.NativeValue))
        {
            _FontSetScale(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<double>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_script_support_override || method == MethodName._FontSetScriptSupportOverride) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_script_support_override.NativeValue))
        {
            _FontSetScriptSupportOverride(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_spacing || method == MethodName._FontSetSpacing) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_spacing.NativeValue))
        {
            _FontSetSpacing(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.SpacingType>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_stretch || method == MethodName._FontSetStretch) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_stretch.NativeValue))
        {
            _FontSetStretch(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_style || method == MethodName._FontSetStyle) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_style.NativeValue))
        {
            _FontSetStyle(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.FontStyle>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_style_name || method == MethodName._FontSetStyleName) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_style_name.NativeValue))
        {
            _FontSetStyleName(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_subpixel_positioning || method == MethodName._FontSetSubpixelPositioning) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_subpixel_positioning.NativeValue))
        {
            _FontSetSubpixelPositioning(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.SubpixelPositioning>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_texture_image || method == MethodName._FontSetTextureImage) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_texture_image.NativeValue))
        {
            _FontSetTextureImage(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<Image>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_texture_offsets || method == MethodName._FontSetTextureOffsets) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_texture_offsets.NativeValue))
        {
            _FontSetTextureOffsets(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<int[]>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_transform || method == MethodName._FontSetTransform) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_transform.NativeValue))
        {
            _FontSetTransform(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Transform2D>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_underline_position || method == MethodName._FontSetUnderlinePosition) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_underline_position.NativeValue))
        {
            _FontSetUnderlinePosition(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<double>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_underline_thickness || method == MethodName._FontSetUnderlineThickness) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_underline_thickness.NativeValue))
        {
            _FontSetUnderlineThickness(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<double>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_variation_coordinates || method == MethodName._FontSetVariationCoordinates) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_variation_coordinates.NativeValue))
        {
            _FontSetVariationCoordinates(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_set_weight || method == MethodName._FontSetWeight) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_set_weight.NativeValue))
        {
            _FontSetWeight(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__font_supported_feature_list || method == MethodName._FontSupportedFeatureList) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_supported_feature_list.NativeValue))
        {
            var callRet = _FontSupportedFeatureList(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__font_supported_variation_list || method == MethodName._FontSupportedVariationList) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__font_supported_variation_list.NativeValue))
        {
            var callRet = _FontSupportedVariationList(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__format_number || method == MethodName._FormatNumber) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__format_number.NativeValue))
        {
            var callRet = _FormatNumber(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__free_rid || method == MethodName._FreeRid) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__free_rid.NativeValue))
        {
            _FreeRid(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_features || method == MethodName._GetFeatures) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_features.NativeValue))
        {
            var callRet = _GetFeatures();
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_hex_code_box_size || method == MethodName._GetHexCodeBoxSize) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_hex_code_box_size.NativeValue))
        {
            var callRet = _GetHexCodeBoxSize(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_name || method == MethodName._GetName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_name.NativeValue))
        {
            var callRet = _GetName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_support_data || method == MethodName._GetSupportData) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_support_data.NativeValue))
        {
            var callRet = _GetSupportData();
            ret = VariantUtils.CreateFrom<byte[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_support_data_filename || method == MethodName._GetSupportDataFileName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_support_data_filename.NativeValue))
        {
            var callRet = _GetSupportDataFileName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_support_data_info || method == MethodName._GetSupportDataInfo) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_support_data_info.NativeValue))
        {
            var callRet = _GetSupportDataInfo();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has || method == MethodName._Has) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__has.NativeValue))
        {
            var callRet = _Has(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_feature || method == MethodName._HasFeature) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_feature.NativeValue))
        {
            var callRet = _HasFeature(VariantUtils.ConvertTo<TextServer.Feature>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_confusable || method == MethodName._IsConfusable) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_confusable.NativeValue))
        {
            var callRet = _IsConfusable(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string[]>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_locale_right_to_left || method == MethodName._IsLocaleRightToLeft) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_locale_right_to_left.NativeValue))
        {
            var callRet = _IsLocaleRightToLeft(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_locale_using_support_data || method == MethodName._IsLocaleUsingSupportData) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_locale_using_support_data.NativeValue))
        {
            var callRet = _IsLocaleUsingSupportData(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_valid_identifier || method == MethodName._IsValidIdentifier) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_valid_identifier.NativeValue))
        {
            var callRet = _IsValidIdentifier(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_valid_letter || method == MethodName._IsValidLetter) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_valid_letter.NativeValue))
        {
            var callRet = _IsValidLetter(VariantUtils.ConvertTo<ulong>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__load_support_data || method == MethodName._LoadSupportData) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__load_support_data.NativeValue))
        {
            var callRet = _LoadSupportData(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__name_to_tag || method == MethodName._NameToTag) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__name_to_tag.NativeValue))
        {
            var callRet = _NameToTag(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__parse_number || method == MethodName._ParseNumber) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_number.NativeValue))
        {
            var callRet = _ParseNumber(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__parse_structured_text || method == MethodName._ParseStructuredText) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__parse_structured_text.NativeValue))
        {
            var callRet = _ParseStructuredText(VariantUtils.ConvertTo<TextServer.StructuredTextParser>(args[0]), VariantUtils.ConvertTo<Godot.Collections.Array>(args[1]), VariantUtils.ConvertTo<string>(args[2]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__percent_sign || method == MethodName._PercentSign) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__percent_sign.NativeValue))
        {
            var callRet = _PercentSign(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__reference_oversampling_level || method == MethodName._ReferenceOversamplingLevel) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__reference_oversampling_level.NativeValue))
        {
            _ReferenceOversamplingLevel(VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__save_support_data || method == MethodName._SaveSupportData) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__save_support_data.NativeValue))
        {
            var callRet = _SaveSupportData(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_run_count || method == MethodName._ShapedGetRunCount) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_run_count.NativeValue))
        {
            var callRet = _ShapedGetRunCount(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_run_direction || method == MethodName._ShapedGetRunDirection) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_run_direction.NativeValue))
        {
            var callRet = _ShapedGetRunDirection(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<TextServer.Direction>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_run_font_rid || method == MethodName._ShapedGetRunFontRid) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_run_font_rid.NativeValue))
        {
            var callRet = _ShapedGetRunFontRid(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_run_font_size || method == MethodName._ShapedGetRunFontSize) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_run_font_size.NativeValue))
        {
            var callRet = _ShapedGetRunFontSize(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_run_language || method == MethodName._ShapedGetRunLanguage) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_run_language.NativeValue))
        {
            var callRet = _ShapedGetRunLanguage(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_run_object || method == MethodName._ShapedGetRunObject) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_run_object.NativeValue))
        {
            var callRet = _ShapedGetRunObject(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_run_range || method == MethodName._ShapedGetRunRange) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_run_range.NativeValue))
        {
            var callRet = _ShapedGetRunRange(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<Vector2I>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_run_text || method == MethodName._ShapedGetRunText) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_run_text.NativeValue))
        {
            var callRet = _ShapedGetRunText(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_span_count || method == MethodName._ShapedGetSpanCount) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_span_count.NativeValue))
        {
            var callRet = _ShapedGetSpanCount(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_span_embedded_object || method == MethodName._ShapedGetSpanEmbeddedObject) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_span_embedded_object.NativeValue))
        {
            var callRet = _ShapedGetSpanEmbeddedObject(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_span_meta || method == MethodName._ShapedGetSpanMeta) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_span_meta.NativeValue))
        {
            var callRet = _ShapedGetSpanMeta(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_span_object || method == MethodName._ShapedGetSpanObject) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_span_object.NativeValue))
        {
            var callRet = _ShapedGetSpanObject(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_span_text || method == MethodName._ShapedGetSpanText) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_span_text.NativeValue))
        {
            var callRet = _ShapedGetSpanText(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_get_text || method == MethodName._ShapedGetText) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_get_text.NativeValue))
        {
            var callRet = _ShapedGetText(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_set_span_update_font || method == MethodName._ShapedSetSpanUpdateFont) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_set_span_update_font.NativeValue))
        {
            _ShapedSetSpanUpdateFont(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), new Godot.Collections.Array<Rid>(VariantUtils.ConvertToArray(args[2])), VariantUtils.ConvertTo<long>(args[3]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_add_object || method == MethodName._ShapedTextAddObject) && args.Count == 6 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_add_object.NativeValue))
        {
            var callRet = _ShapedTextAddObject(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]), VariantUtils.ConvertTo<InlineAlignment>(args[3]), VariantUtils.ConvertTo<long>(args[4]), VariantUtils.ConvertTo<double>(args[5]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_add_string || method == MethodName._ShapedTextAddString) && args.Count == 7 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_add_string.NativeValue))
        {
            var callRet = _ShapedTextAddString(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]), new Godot.Collections.Array<Rid>(VariantUtils.ConvertToArray(args[2])), VariantUtils.ConvertTo<long>(args[3]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[4]), VariantUtils.ConvertTo<string>(args[5]), VariantUtils.ConvertTo<Variant>(args[6]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_clear || method == MethodName._ShapedTextClear) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_clear.NativeValue))
        {
            _ShapedTextClear(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_closest_character_pos || method == MethodName._ShapedTextClosestCharacterPos) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_closest_character_pos.NativeValue))
        {
            var callRet = _ShapedTextClosestCharacterPos(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_draw || method == MethodName._ShapedTextDraw) && args.Count == 7 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_draw.NativeValue))
        {
            _ShapedTextDraw(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]), VariantUtils.ConvertTo<double>(args[3]), VariantUtils.ConvertTo<double>(args[4]), VariantUtils.ConvertTo<Color>(args[5]), VariantUtils.ConvertTo<float>(args[6]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_draw_outline || method == MethodName._ShapedTextDrawOutline) && args.Count == 8 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_draw_outline.NativeValue))
        {
            _ShapedTextDrawOutline(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]), VariantUtils.ConvertTo<double>(args[3]), VariantUtils.ConvertTo<double>(args[4]), VariantUtils.ConvertTo<long>(args[5]), VariantUtils.ConvertTo<Color>(args[6]), VariantUtils.ConvertTo<float>(args[7]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_duplicate || method == MethodName._ShapedTextDuplicate) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_duplicate.NativeValue))
        {
            var callRet = _ShapedTextDuplicate(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_fit_to_width || method == MethodName._ShapedTextFitToWidth) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_fit_to_width.NativeValue))
        {
            var callRet = _ShapedTextFitToWidth(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<double>(args[1]), VariantUtils.ConvertTo<TextServer.JustificationFlag>(args[2]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_ascent || method == MethodName._ShapedTextGetAscent) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_ascent.NativeValue))
        {
            var callRet = _ShapedTextGetAscent(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_character_breaks || method == MethodName._ShapedTextGetCharacterBreaks) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_character_breaks.NativeValue))
        {
            var callRet = _ShapedTextGetCharacterBreaks(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_custom_ellipsis || method == MethodName._ShapedTextGetCustomEllipsis) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_custom_ellipsis.NativeValue))
        {
            var callRet = _ShapedTextGetCustomEllipsis(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_custom_punctuation || method == MethodName._ShapedTextGetCustomPunctuation) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_custom_punctuation.NativeValue))
        {
            var callRet = _ShapedTextGetCustomPunctuation(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_descent || method == MethodName._ShapedTextGetDescent) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_descent.NativeValue))
        {
            var callRet = _ShapedTextGetDescent(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_direction || method == MethodName._ShapedTextGetDirection) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_direction.NativeValue))
        {
            var callRet = _ShapedTextGetDirection(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<TextServer.Direction>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_dominant_direction_in_range || method == MethodName._ShapedTextGetDominantDirectionInRange) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_dominant_direction_in_range.NativeValue))
        {
            var callRet = _ShapedTextGetDominantDirectionInRange(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_ellipsis_glyph_count || method == MethodName._ShapedTextGetEllipsisGlyphCount) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_ellipsis_glyph_count.NativeValue))
        {
            var callRet = _ShapedTextGetEllipsisGlyphCount(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_ellipsis_pos || method == MethodName._ShapedTextGetEllipsisPos) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_ellipsis_pos.NativeValue))
        {
            var callRet = _ShapedTextGetEllipsisPos(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_glyph_count || method == MethodName._ShapedTextGetGlyphCount) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_glyph_count.NativeValue))
        {
            var callRet = _ShapedTextGetGlyphCount(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_grapheme_bounds || method == MethodName._ShapedTextGetGraphemeBounds) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_grapheme_bounds.NativeValue))
        {
            var callRet = _ShapedTextGetGraphemeBounds(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_inferred_direction || method == MethodName._ShapedTextGetInferredDirection) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_inferred_direction.NativeValue))
        {
            var callRet = _ShapedTextGetInferredDirection(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<TextServer.Direction>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_line_breaks || method == MethodName._ShapedTextGetLineBreaks) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_line_breaks.NativeValue))
        {
            var callRet = _ShapedTextGetLineBreaks(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<double>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<TextServer.LineBreakFlag>(args[3]));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_line_breaks_adv || method == MethodName._ShapedTextGetLineBreaksAdv) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_line_breaks_adv.NativeValue))
        {
            var callRet = _ShapedTextGetLineBreaksAdv(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float[]>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<bool>(args[3]), VariantUtils.ConvertTo<TextServer.LineBreakFlag>(args[4]));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_object_glyph || method == MethodName._ShapedTextGetObjectGlyph) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_object_glyph.NativeValue))
        {
            var callRet = _ShapedTextGetObjectGlyph(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_object_range || method == MethodName._ShapedTextGetObjectRange) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_object_range.NativeValue))
        {
            var callRet = _ShapedTextGetObjectRange(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]));
            ret = VariantUtils.CreateFrom<Vector2I>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_object_rect || method == MethodName._ShapedTextGetObjectRect) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_object_rect.NativeValue))
        {
            var callRet = _ShapedTextGetObjectRect(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]));
            ret = VariantUtils.CreateFrom<Rect2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_objects || method == MethodName._ShapedTextGetObjects) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_objects.NativeValue))
        {
            var callRet = _ShapedTextGetObjects(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Array>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_orientation || method == MethodName._ShapedTextGetOrientation) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_orientation.NativeValue))
        {
            var callRet = _ShapedTextGetOrientation(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<TextServer.Orientation>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_parent || method == MethodName._ShapedTextGetParent) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_parent.NativeValue))
        {
            var callRet = _ShapedTextGetParent(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_preserve_control || method == MethodName._ShapedTextGetPreserveControl) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_preserve_control.NativeValue))
        {
            var callRet = _ShapedTextGetPreserveControl(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_preserve_invalid || method == MethodName._ShapedTextGetPreserveInvalid) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_preserve_invalid.NativeValue))
        {
            var callRet = _ShapedTextGetPreserveInvalid(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_range || method == MethodName._ShapedTextGetRange) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_range.NativeValue))
        {
            var callRet = _ShapedTextGetRange(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Vector2I>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_selection || method == MethodName._ShapedTextGetSelection) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_selection.NativeValue))
        {
            var callRet = _ShapedTextGetSelection(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<Vector2[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_size || method == MethodName._ShapedTextGetSize) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_size.NativeValue))
        {
            var callRet = _ShapedTextGetSize(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_spacing || method == MethodName._ShapedTextGetSpacing) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_spacing.NativeValue))
        {
            var callRet = _ShapedTextGetSpacing(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.SpacingType>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_trim_pos || method == MethodName._ShapedTextGetTrimPos) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_trim_pos.NativeValue))
        {
            var callRet = _ShapedTextGetTrimPos(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_underline_position || method == MethodName._ShapedTextGetUnderlinePosition) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_underline_position.NativeValue))
        {
            var callRet = _ShapedTextGetUnderlinePosition(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_underline_thickness || method == MethodName._ShapedTextGetUnderlineThickness) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_underline_thickness.NativeValue))
        {
            var callRet = _ShapedTextGetUnderlineThickness(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_width || method == MethodName._ShapedTextGetWidth) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_width.NativeValue))
        {
            var callRet = _ShapedTextGetWidth(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_get_word_breaks || method == MethodName._ShapedTextGetWordBreaks) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_get_word_breaks.NativeValue))
        {
            var callRet = _ShapedTextGetWordBreaks(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.GraphemeFlag>(args[1]), VariantUtils.ConvertTo<TextServer.GraphemeFlag>(args[2]));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_has_object || method == MethodName._ShapedTextHasObject) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_has_object.NativeValue))
        {
            var callRet = _ShapedTextHasObject(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_hit_test_grapheme || method == MethodName._ShapedTextHitTestGrapheme) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_hit_test_grapheme.NativeValue))
        {
            var callRet = _ShapedTextHitTestGrapheme(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<double>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_hit_test_position || method == MethodName._ShapedTextHitTestPosition) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_hit_test_position.NativeValue))
        {
            var callRet = _ShapedTextHitTestPosition(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<double>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_is_ready || method == MethodName._ShapedTextIsReady) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_is_ready.NativeValue))
        {
            var callRet = _ShapedTextIsReady(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_next_character_pos || method == MethodName._ShapedTextNextCharacterPos) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_next_character_pos.NativeValue))
        {
            var callRet = _ShapedTextNextCharacterPos(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_next_grapheme_pos || method == MethodName._ShapedTextNextGraphemePos) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_next_grapheme_pos.NativeValue))
        {
            var callRet = _ShapedTextNextGraphemePos(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_overrun_trim_to_width || method == MethodName._ShapedTextOverrunTrimToWidth) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_overrun_trim_to_width.NativeValue))
        {
            _ShapedTextOverrunTrimToWidth(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<double>(args[1]), VariantUtils.ConvertTo<TextServer.TextOverrunFlag>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_prev_character_pos || method == MethodName._ShapedTextPrevCharacterPos) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_prev_character_pos.NativeValue))
        {
            var callRet = _ShapedTextPrevCharacterPos(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_prev_grapheme_pos || method == MethodName._ShapedTextPrevGraphemePos) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_prev_grapheme_pos.NativeValue))
        {
            var callRet = _ShapedTextPrevGraphemePos(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<long>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_resize_object || method == MethodName._ShapedTextResizeObject) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_resize_object.NativeValue))
        {
            var callRet = _ShapedTextResizeObject(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]), VariantUtils.ConvertTo<InlineAlignment>(args[3]), VariantUtils.ConvertTo<double>(args[4]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_set_bidi_override || method == MethodName._ShapedTextSetBidiOverride) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_set_bidi_override.NativeValue))
        {
            _ShapedTextSetBidiOverride(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Godot.Collections.Array>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_set_custom_ellipsis || method == MethodName._ShapedTextSetCustomEllipsis) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_set_custom_ellipsis.NativeValue))
        {
            _ShapedTextSetCustomEllipsis(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_set_custom_punctuation || method == MethodName._ShapedTextSetCustomPunctuation) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_set_custom_punctuation.NativeValue))
        {
            _ShapedTextSetCustomPunctuation(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_set_direction || method == MethodName._ShapedTextSetDirection) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_set_direction.NativeValue))
        {
            _ShapedTextSetDirection(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.Direction>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_set_orientation || method == MethodName._ShapedTextSetOrientation) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_set_orientation.NativeValue))
        {
            _ShapedTextSetOrientation(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.Orientation>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_set_preserve_control || method == MethodName._ShapedTextSetPreserveControl) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_set_preserve_control.NativeValue))
        {
            _ShapedTextSetPreserveControl(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_set_preserve_invalid || method == MethodName._ShapedTextSetPreserveInvalid) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_set_preserve_invalid.NativeValue))
        {
            _ShapedTextSetPreserveInvalid(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_set_spacing || method == MethodName._ShapedTextSetSpacing) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_set_spacing.NativeValue))
        {
            _ShapedTextSetSpacing(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<TextServer.SpacingType>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shaped_text_shape || method == MethodName._ShapedTextShape) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_shape.NativeValue))
        {
            var callRet = _ShapedTextShape(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_substr || method == MethodName._ShapedTextSubstr) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_substr.NativeValue))
        {
            var callRet = _ShapedTextSubstr(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_tab_align || method == MethodName._ShapedTextTabAlign) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_tab_align.NativeValue))
        {
            var callRet = _ShapedTextTabAlign(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float[]>(args[1]));
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_update_breaks || method == MethodName._ShapedTextUpdateBreaks) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_update_breaks.NativeValue))
        {
            var callRet = _ShapedTextUpdateBreaks(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shaped_text_update_justification_ops || method == MethodName._ShapedTextUpdateJustificationOps) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shaped_text_update_justification_ops.NativeValue))
        {
            var callRet = _ShapedTextUpdateJustificationOps(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__spoof_check || method == MethodName._SpoofCheck) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__spoof_check.NativeValue))
        {
            var callRet = _SpoofCheck(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__string_get_character_breaks || method == MethodName._StringGetCharacterBreaks) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__string_get_character_breaks.NativeValue))
        {
            var callRet = _StringGetCharacterBreaks(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__string_get_word_breaks || method == MethodName._StringGetWordBreaks) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__string_get_word_breaks.NativeValue))
        {
            var callRet = _StringGetWordBreaks(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__string_to_lower || method == MethodName._StringToLower) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__string_to_lower.NativeValue))
        {
            var callRet = _StringToLower(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__string_to_title || method == MethodName._StringToTitle) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__string_to_title.NativeValue))
        {
            var callRet = _StringToTitle(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__string_to_upper || method == MethodName._StringToUpper) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__string_to_upper.NativeValue))
        {
            var callRet = _StringToUpper(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__strip_diacritics || method == MethodName._StripDiacritics) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__strip_diacritics.NativeValue))
        {
            var callRet = _StripDiacritics(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__tag_to_name || method == MethodName._TagToName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__tag_to_name.NativeValue))
        {
            var callRet = _TagToName(VariantUtils.ConvertTo<long>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__unreference_oversampling_level || method == MethodName._UnreferenceOversamplingLevel) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__unreference_oversampling_level.NativeValue))
        {
            _UnreferenceOversamplingLevel(VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
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
        if (method == MethodName._Cleanup)
        {
            if (HasGodotClassMethod(MethodProxyName__cleanup.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CreateFont)
        {
            if (HasGodotClassMethod(MethodProxyName__create_font.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CreateFontLinkedVariation)
        {
            if (HasGodotClassMethod(MethodProxyName__create_font_linked_variation.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CreateShapedText)
        {
            if (HasGodotClassMethod(MethodProxyName__create_shaped_text.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DrawHexCodeBox)
        {
            if (HasGodotClassMethod(MethodProxyName__draw_hex_code_box.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontClearGlyphs)
        {
            if (HasGodotClassMethod(MethodProxyName__font_clear_glyphs.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontClearKerningMap)
        {
            if (HasGodotClassMethod(MethodProxyName__font_clear_kerning_map.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontClearSizeCache)
        {
            if (HasGodotClassMethod(MethodProxyName__font_clear_size_cache.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontClearSystemFallbackCache)
        {
            if (HasGodotClassMethod(MethodProxyName__font_clear_system_fallback_cache.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontClearTextures)
        {
            if (HasGodotClassMethod(MethodProxyName__font_clear_textures.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontDrawGlyph)
        {
            if (HasGodotClassMethod(MethodProxyName__font_draw_glyph.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontDrawGlyphOutline)
        {
            if (HasGodotClassMethod(MethodProxyName__font_draw_glyph_outline.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetAntialiasing)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_antialiasing.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetAscent)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_ascent.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetBaselineOffset)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_baseline_offset.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetCharFromGlyphIndex)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_char_from_glyph_index.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetDescent)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_descent.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetDisableEmbeddedBitmaps)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_disable_embedded_bitmaps.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetEmbolden)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_embolden.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetFaceCount)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_face_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetFaceIndex)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_face_index.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetFixedSize)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_fixed_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetFixedSizeScaleMode)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_fixed_size_scale_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGenerateMipmaps)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_generate_mipmaps.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlobalOversampling)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_global_oversampling.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlyphAdvance)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_glyph_advance.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlyphContours)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_glyph_contours.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlyphIndex)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_glyph_index.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlyphList)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_glyph_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlyphOffset)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_glyph_offset.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlyphSize)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_glyph_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlyphTextureIdx)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_glyph_texture_idx.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlyphTextureRid)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_glyph_texture_rid.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlyphTextureSize)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_glyph_texture_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetGlyphUVRect)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_glyph_uv_rect.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetHinting)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_hinting.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetKeepRoundingRemainders)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_keep_rounding_remainders.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetKerning)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_kerning.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetKerningList)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_kerning_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetLanguageSupportOverride)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_language_support_override.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetLanguageSupportOverrides)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_language_support_overrides.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetMsdfPixelRange)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_msdf_pixel_range.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetMsdfSize)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_msdf_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetName)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetOpentypeFeatureOverrides)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_opentype_feature_overrides.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetOtNameStrings)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_ot_name_strings.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetOversampling)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_oversampling.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetScale)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_scale.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetScriptSupportOverride)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_script_support_override.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetScriptSupportOverrides)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_script_support_overrides.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetSizeCacheInfo)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_size_cache_info.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetSizeCacheList)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_size_cache_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetSpacing)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_spacing.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetStretch)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_stretch.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetStyle)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_style.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetStyleName)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_style_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetSubpixelPositioning)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_subpixel_positioning.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetSupportedChars)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_supported_chars.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetSupportedGlyphs)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_supported_glyphs.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetTextureCount)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_texture_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetTextureImage)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_texture_image.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetTextureOffsets)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_texture_offsets.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetUnderlinePosition)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_underline_position.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetUnderlineThickness)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_underline_thickness.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetVariationCoordinates)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_variation_coordinates.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontGetWeight)
        {
            if (HasGodotClassMethod(MethodProxyName__font_get_weight.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontHasChar)
        {
            if (HasGodotClassMethod(MethodProxyName__font_has_char.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontIsAllowSystemFallback)
        {
            if (HasGodotClassMethod(MethodProxyName__font_is_allow_system_fallback.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontIsForceAutohinter)
        {
            if (HasGodotClassMethod(MethodProxyName__font_is_force_autohinter.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontIsLanguageSupported)
        {
            if (HasGodotClassMethod(MethodProxyName__font_is_language_supported.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontIsModulateColorGlyphs)
        {
            if (HasGodotClassMethod(MethodProxyName__font_is_modulate_color_glyphs.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontIsMultichannelSignedDistanceField)
        {
            if (HasGodotClassMethod(MethodProxyName__font_is_multichannel_signed_distance_field.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontIsScriptSupported)
        {
            if (HasGodotClassMethod(MethodProxyName__font_is_script_supported.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontRemoveGlyph)
        {
            if (HasGodotClassMethod(MethodProxyName__font_remove_glyph.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontRemoveKerning)
        {
            if (HasGodotClassMethod(MethodProxyName__font_remove_kerning.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontRemoveLanguageSupportOverride)
        {
            if (HasGodotClassMethod(MethodProxyName__font_remove_language_support_override.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontRemoveScriptSupportOverride)
        {
            if (HasGodotClassMethod(MethodProxyName__font_remove_script_support_override.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontRemoveSizeCache)
        {
            if (HasGodotClassMethod(MethodProxyName__font_remove_size_cache.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontRemoveTexture)
        {
            if (HasGodotClassMethod(MethodProxyName__font_remove_texture.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontRenderGlyph)
        {
            if (HasGodotClassMethod(MethodProxyName__font_render_glyph.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontRenderRange)
        {
            if (HasGodotClassMethod(MethodProxyName__font_render_range.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetAllowSystemFallback)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_allow_system_fallback.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetAntialiasing)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_antialiasing.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetAscent)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_ascent.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetBaselineOffset)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_baseline_offset.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetData)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetDescent)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_descent.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetDisableEmbeddedBitmaps)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_disable_embedded_bitmaps.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetEmbolden)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_embolden.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetFaceIndex)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_face_index.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetFixedSize)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_fixed_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetFixedSizeScaleMode)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_fixed_size_scale_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetForceAutohinter)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_force_autohinter.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetGenerateMipmaps)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_generate_mipmaps.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetGlobalOversampling)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_global_oversampling.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetGlyphAdvance)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_glyph_advance.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetGlyphOffset)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_glyph_offset.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetGlyphSize)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_glyph_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetGlyphTextureIdx)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_glyph_texture_idx.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetGlyphUVRect)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_glyph_uv_rect.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetHinting)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_hinting.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetKeepRoundingRemainders)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_keep_rounding_remainders.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetKerning)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_kerning.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetLanguageSupportOverride)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_language_support_override.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetModulateColorGlyphs)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_modulate_color_glyphs.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetMsdfPixelRange)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_msdf_pixel_range.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetMsdfSize)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_msdf_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetMultichannelSignedDistanceField)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_multichannel_signed_distance_field.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetName)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetOpentypeFeatureOverrides)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_opentype_feature_overrides.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetOversampling)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_oversampling.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetScale)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_scale.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetScriptSupportOverride)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_script_support_override.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetSpacing)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_spacing.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetStretch)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_stretch.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetStyle)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_style.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetStyleName)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_style_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetSubpixelPositioning)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_subpixel_positioning.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetTextureImage)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_texture_image.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetTextureOffsets)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_texture_offsets.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetUnderlinePosition)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_underline_position.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetUnderlineThickness)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_underline_thickness.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetVariationCoordinates)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_variation_coordinates.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSetWeight)
        {
            if (HasGodotClassMethod(MethodProxyName__font_set_weight.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSupportedFeatureList)
        {
            if (HasGodotClassMethod(MethodProxyName__font_supported_feature_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FontSupportedVariationList)
        {
            if (HasGodotClassMethod(MethodProxyName__font_supported_variation_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FormatNumber)
        {
            if (HasGodotClassMethod(MethodProxyName__format_number.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FreeRid)
        {
            if (HasGodotClassMethod(MethodProxyName__free_rid.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetFeatures)
        {
            if (HasGodotClassMethod(MethodProxyName__get_features.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetHexCodeBoxSize)
        {
            if (HasGodotClassMethod(MethodProxyName__get_hex_code_box_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSupportData)
        {
            if (HasGodotClassMethod(MethodProxyName__get_support_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSupportDataFileName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_support_data_filename.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSupportDataInfo)
        {
            if (HasGodotClassMethod(MethodProxyName__get_support_data_info.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Has)
        {
            if (HasGodotClassMethod(MethodProxyName__has.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasFeature)
        {
            if (HasGodotClassMethod(MethodProxyName__has_feature.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsConfusable)
        {
            if (HasGodotClassMethod(MethodProxyName__is_confusable.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsLocaleRightToLeft)
        {
            if (HasGodotClassMethod(MethodProxyName__is_locale_right_to_left.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsLocaleUsingSupportData)
        {
            if (HasGodotClassMethod(MethodProxyName__is_locale_using_support_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsValidIdentifier)
        {
            if (HasGodotClassMethod(MethodProxyName__is_valid_identifier.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsValidLetter)
        {
            if (HasGodotClassMethod(MethodProxyName__is_valid_letter.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._LoadSupportData)
        {
            if (HasGodotClassMethod(MethodProxyName__load_support_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._NameToTag)
        {
            if (HasGodotClassMethod(MethodProxyName__name_to_tag.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseNumber)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_number.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ParseStructuredText)
        {
            if (HasGodotClassMethod(MethodProxyName__parse_structured_text.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PercentSign)
        {
            if (HasGodotClassMethod(MethodProxyName__percent_sign.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ReferenceOversamplingLevel)
        {
            if (HasGodotClassMethod(MethodProxyName__reference_oversampling_level.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SaveSupportData)
        {
            if (HasGodotClassMethod(MethodProxyName__save_support_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetRunCount)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_run_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetRunDirection)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_run_direction.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetRunFontRid)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_run_font_rid.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetRunFontSize)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_run_font_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetRunLanguage)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_run_language.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetRunObject)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_run_object.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetRunRange)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_run_range.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetRunText)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_run_text.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetSpanCount)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_span_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetSpanEmbeddedObject)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_span_embedded_object.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetSpanMeta)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_span_meta.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetSpanObject)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_span_object.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetSpanText)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_span_text.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedGetText)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_get_text.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedSetSpanUpdateFont)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_set_span_update_font.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextAddObject)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_add_object.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextAddString)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_add_string.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextClear)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_clear.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextClosestCharacterPos)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_closest_character_pos.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextDraw)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_draw.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextDrawOutline)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_draw_outline.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextDuplicate)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_duplicate.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextFitToWidth)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_fit_to_width.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetAscent)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_ascent.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetCharacterBreaks)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_character_breaks.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetCustomEllipsis)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_custom_ellipsis.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetCustomPunctuation)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_custom_punctuation.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetDescent)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_descent.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetDirection)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_direction.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetDominantDirectionInRange)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_dominant_direction_in_range.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetEllipsisGlyphCount)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_ellipsis_glyph_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetEllipsisPos)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_ellipsis_pos.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetGlyphCount)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_glyph_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetGraphemeBounds)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_grapheme_bounds.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetInferredDirection)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_inferred_direction.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetLineBreaks)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_line_breaks.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetLineBreaksAdv)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_line_breaks_adv.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetObjectGlyph)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_object_glyph.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetObjectRange)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_object_range.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetObjectRect)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_object_rect.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetObjects)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_objects.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetOrientation)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_orientation.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetParent)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_parent.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetPreserveControl)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_preserve_control.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetPreserveInvalid)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_preserve_invalid.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetRange)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_range.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetSelection)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_selection.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetSize)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetSpacing)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_spacing.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetTrimPos)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_trim_pos.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetUnderlinePosition)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_underline_position.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetUnderlineThickness)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_underline_thickness.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetWidth)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_width.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextGetWordBreaks)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_get_word_breaks.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextHasObject)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_has_object.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextHitTestGrapheme)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_hit_test_grapheme.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextHitTestPosition)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_hit_test_position.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextIsReady)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_is_ready.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextNextCharacterPos)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_next_character_pos.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextNextGraphemePos)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_next_grapheme_pos.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextOverrunTrimToWidth)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_overrun_trim_to_width.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextPrevCharacterPos)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_prev_character_pos.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextPrevGraphemePos)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_prev_grapheme_pos.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextResizeObject)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_resize_object.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextSetBidiOverride)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_set_bidi_override.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextSetCustomEllipsis)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_set_custom_ellipsis.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextSetCustomPunctuation)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_set_custom_punctuation.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextSetDirection)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_set_direction.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextSetOrientation)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_set_orientation.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextSetPreserveControl)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_set_preserve_control.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextSetPreserveInvalid)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_set_preserve_invalid.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextSetSpacing)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_set_spacing.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextShape)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_shape.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextSubstr)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_substr.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextTabAlign)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_tab_align.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextUpdateBreaks)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_update_breaks.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapedTextUpdateJustificationOps)
        {
            if (HasGodotClassMethod(MethodProxyName__shaped_text_update_justification_ops.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SpoofCheck)
        {
            if (HasGodotClassMethod(MethodProxyName__spoof_check.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._StringGetCharacterBreaks)
        {
            if (HasGodotClassMethod(MethodProxyName__string_get_character_breaks.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._StringGetWordBreaks)
        {
            if (HasGodotClassMethod(MethodProxyName__string_get_word_breaks.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._StringToLower)
        {
            if (HasGodotClassMethod(MethodProxyName__string_to_lower.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._StringToTitle)
        {
            if (HasGodotClassMethod(MethodProxyName__string_to_title.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._StringToUpper)
        {
            if (HasGodotClassMethod(MethodProxyName__string_to_upper.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._StripDiacritics)
        {
            if (HasGodotClassMethod(MethodProxyName__strip_diacritics.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._TagToName)
        {
            if (HasGodotClassMethod(MethodProxyName__tag_to_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._UnreferenceOversamplingLevel)
        {
            if (HasGodotClassMethod(MethodProxyName__unreference_oversampling_level.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : TextServer.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : TextServer.MethodName
    {
        /// <summary>
        /// Cached name for the '_cleanup' method.
        /// </summary>
        public static readonly StringName _Cleanup = "_cleanup";
        /// <summary>
        /// Cached name for the '_create_font' method.
        /// </summary>
        public static readonly StringName _CreateFont = "_create_font";
        /// <summary>
        /// Cached name for the '_create_font_linked_variation' method.
        /// </summary>
        public static readonly StringName _CreateFontLinkedVariation = "_create_font_linked_variation";
        /// <summary>
        /// Cached name for the '_create_shaped_text' method.
        /// </summary>
        public static readonly StringName _CreateShapedText = "_create_shaped_text";
        /// <summary>
        /// Cached name for the '_draw_hex_code_box' method.
        /// </summary>
        public static readonly StringName _DrawHexCodeBox = "_draw_hex_code_box";
        /// <summary>
        /// Cached name for the '_font_clear_glyphs' method.
        /// </summary>
        public static readonly StringName _FontClearGlyphs = "_font_clear_glyphs";
        /// <summary>
        /// Cached name for the '_font_clear_kerning_map' method.
        /// </summary>
        public static readonly StringName _FontClearKerningMap = "_font_clear_kerning_map";
        /// <summary>
        /// Cached name for the '_font_clear_size_cache' method.
        /// </summary>
        public static readonly StringName _FontClearSizeCache = "_font_clear_size_cache";
        /// <summary>
        /// Cached name for the '_font_clear_system_fallback_cache' method.
        /// </summary>
        public static readonly StringName _FontClearSystemFallbackCache = "_font_clear_system_fallback_cache";
        /// <summary>
        /// Cached name for the '_font_clear_textures' method.
        /// </summary>
        public static readonly StringName _FontClearTextures = "_font_clear_textures";
        /// <summary>
        /// Cached name for the '_font_draw_glyph' method.
        /// </summary>
        public static readonly StringName _FontDrawGlyph = "_font_draw_glyph";
        /// <summary>
        /// Cached name for the '_font_draw_glyph_outline' method.
        /// </summary>
        public static readonly StringName _FontDrawGlyphOutline = "_font_draw_glyph_outline";
        /// <summary>
        /// Cached name for the '_font_get_antialiasing' method.
        /// </summary>
        public static readonly StringName _FontGetAntialiasing = "_font_get_antialiasing";
        /// <summary>
        /// Cached name for the '_font_get_ascent' method.
        /// </summary>
        public static readonly StringName _FontGetAscent = "_font_get_ascent";
        /// <summary>
        /// Cached name for the '_font_get_baseline_offset' method.
        /// </summary>
        public static readonly StringName _FontGetBaselineOffset = "_font_get_baseline_offset";
        /// <summary>
        /// Cached name for the '_font_get_char_from_glyph_index' method.
        /// </summary>
        public static readonly StringName _FontGetCharFromGlyphIndex = "_font_get_char_from_glyph_index";
        /// <summary>
        /// Cached name for the '_font_get_descent' method.
        /// </summary>
        public static readonly StringName _FontGetDescent = "_font_get_descent";
        /// <summary>
        /// Cached name for the '_font_get_disable_embedded_bitmaps' method.
        /// </summary>
        public static readonly StringName _FontGetDisableEmbeddedBitmaps = "_font_get_disable_embedded_bitmaps";
        /// <summary>
        /// Cached name for the '_font_get_embolden' method.
        /// </summary>
        public static readonly StringName _FontGetEmbolden = "_font_get_embolden";
        /// <summary>
        /// Cached name for the '_font_get_face_count' method.
        /// </summary>
        public static readonly StringName _FontGetFaceCount = "_font_get_face_count";
        /// <summary>
        /// Cached name for the '_font_get_face_index' method.
        /// </summary>
        public static readonly StringName _FontGetFaceIndex = "_font_get_face_index";
        /// <summary>
        /// Cached name for the '_font_get_fixed_size' method.
        /// </summary>
        public static readonly StringName _FontGetFixedSize = "_font_get_fixed_size";
        /// <summary>
        /// Cached name for the '_font_get_fixed_size_scale_mode' method.
        /// </summary>
        public static readonly StringName _FontGetFixedSizeScaleMode = "_font_get_fixed_size_scale_mode";
        /// <summary>
        /// Cached name for the '_font_get_generate_mipmaps' method.
        /// </summary>
        public static readonly StringName _FontGetGenerateMipmaps = "_font_get_generate_mipmaps";
        /// <summary>
        /// Cached name for the '_font_get_global_oversampling' method.
        /// </summary>
        public static readonly StringName _FontGetGlobalOversampling = "_font_get_global_oversampling";
        /// <summary>
        /// Cached name for the '_font_get_glyph_advance' method.
        /// </summary>
        public static readonly StringName _FontGetGlyphAdvance = "_font_get_glyph_advance";
        /// <summary>
        /// Cached name for the '_font_get_glyph_contours' method.
        /// </summary>
        public static readonly StringName _FontGetGlyphContours = "_font_get_glyph_contours";
        /// <summary>
        /// Cached name for the '_font_get_glyph_index' method.
        /// </summary>
        public static readonly StringName _FontGetGlyphIndex = "_font_get_glyph_index";
        /// <summary>
        /// Cached name for the '_font_get_glyph_list' method.
        /// </summary>
        public static readonly StringName _FontGetGlyphList = "_font_get_glyph_list";
        /// <summary>
        /// Cached name for the '_font_get_glyph_offset' method.
        /// </summary>
        public static readonly StringName _FontGetGlyphOffset = "_font_get_glyph_offset";
        /// <summary>
        /// Cached name for the '_font_get_glyph_size' method.
        /// </summary>
        public static readonly StringName _FontGetGlyphSize = "_font_get_glyph_size";
        /// <summary>
        /// Cached name for the '_font_get_glyph_texture_idx' method.
        /// </summary>
        public static readonly StringName _FontGetGlyphTextureIdx = "_font_get_glyph_texture_idx";
        /// <summary>
        /// Cached name for the '_font_get_glyph_texture_rid' method.
        /// </summary>
        public static readonly StringName _FontGetGlyphTextureRid = "_font_get_glyph_texture_rid";
        /// <summary>
        /// Cached name for the '_font_get_glyph_texture_size' method.
        /// </summary>
        public static readonly StringName _FontGetGlyphTextureSize = "_font_get_glyph_texture_size";
        /// <summary>
        /// Cached name for the '_font_get_glyph_uv_rect' method.
        /// </summary>
        public static readonly StringName _FontGetGlyphUVRect = "_font_get_glyph_uv_rect";
        /// <summary>
        /// Cached name for the '_font_get_hinting' method.
        /// </summary>
        public static readonly StringName _FontGetHinting = "_font_get_hinting";
        /// <summary>
        /// Cached name for the '_font_get_keep_rounding_remainders' method.
        /// </summary>
        public static readonly StringName _FontGetKeepRoundingRemainders = "_font_get_keep_rounding_remainders";
        /// <summary>
        /// Cached name for the '_font_get_kerning' method.
        /// </summary>
        public static readonly StringName _FontGetKerning = "_font_get_kerning";
        /// <summary>
        /// Cached name for the '_font_get_kerning_list' method.
        /// </summary>
        public static readonly StringName _FontGetKerningList = "_font_get_kerning_list";
        /// <summary>
        /// Cached name for the '_font_get_language_support_override' method.
        /// </summary>
        public static readonly StringName _FontGetLanguageSupportOverride = "_font_get_language_support_override";
        /// <summary>
        /// Cached name for the '_font_get_language_support_overrides' method.
        /// </summary>
        public static readonly StringName _FontGetLanguageSupportOverrides = "_font_get_language_support_overrides";
        /// <summary>
        /// Cached name for the '_font_get_msdf_pixel_range' method.
        /// </summary>
        public static readonly StringName _FontGetMsdfPixelRange = "_font_get_msdf_pixel_range";
        /// <summary>
        /// Cached name for the '_font_get_msdf_size' method.
        /// </summary>
        public static readonly StringName _FontGetMsdfSize = "_font_get_msdf_size";
        /// <summary>
        /// Cached name for the '_font_get_name' method.
        /// </summary>
        public static readonly StringName _FontGetName = "_font_get_name";
        /// <summary>
        /// Cached name for the '_font_get_opentype_feature_overrides' method.
        /// </summary>
        public static readonly StringName _FontGetOpentypeFeatureOverrides = "_font_get_opentype_feature_overrides";
        /// <summary>
        /// Cached name for the '_font_get_ot_name_strings' method.
        /// </summary>
        public static readonly StringName _FontGetOtNameStrings = "_font_get_ot_name_strings";
        /// <summary>
        /// Cached name for the '_font_get_oversampling' method.
        /// </summary>
        public static readonly StringName _FontGetOversampling = "_font_get_oversampling";
        /// <summary>
        /// Cached name for the '_font_get_scale' method.
        /// </summary>
        public static readonly StringName _FontGetScale = "_font_get_scale";
        /// <summary>
        /// Cached name for the '_font_get_script_support_override' method.
        /// </summary>
        public static readonly StringName _FontGetScriptSupportOverride = "_font_get_script_support_override";
        /// <summary>
        /// Cached name for the '_font_get_script_support_overrides' method.
        /// </summary>
        public static readonly StringName _FontGetScriptSupportOverrides = "_font_get_script_support_overrides";
        /// <summary>
        /// Cached name for the '_font_get_size_cache_info' method.
        /// </summary>
        public static readonly StringName _FontGetSizeCacheInfo = "_font_get_size_cache_info";
        /// <summary>
        /// Cached name for the '_font_get_size_cache_list' method.
        /// </summary>
        public static readonly StringName _FontGetSizeCacheList = "_font_get_size_cache_list";
        /// <summary>
        /// Cached name for the '_font_get_spacing' method.
        /// </summary>
        public static readonly StringName _FontGetSpacing = "_font_get_spacing";
        /// <summary>
        /// Cached name for the '_font_get_stretch' method.
        /// </summary>
        public static readonly StringName _FontGetStretch = "_font_get_stretch";
        /// <summary>
        /// Cached name for the '_font_get_style' method.
        /// </summary>
        public static readonly StringName _FontGetStyle = "_font_get_style";
        /// <summary>
        /// Cached name for the '_font_get_style_name' method.
        /// </summary>
        public static readonly StringName _FontGetStyleName = "_font_get_style_name";
        /// <summary>
        /// Cached name for the '_font_get_subpixel_positioning' method.
        /// </summary>
        public static readonly StringName _FontGetSubpixelPositioning = "_font_get_subpixel_positioning";
        /// <summary>
        /// Cached name for the '_font_get_supported_chars' method.
        /// </summary>
        public static readonly StringName _FontGetSupportedChars = "_font_get_supported_chars";
        /// <summary>
        /// Cached name for the '_font_get_supported_glyphs' method.
        /// </summary>
        public static readonly StringName _FontGetSupportedGlyphs = "_font_get_supported_glyphs";
        /// <summary>
        /// Cached name for the '_font_get_texture_count' method.
        /// </summary>
        public static readonly StringName _FontGetTextureCount = "_font_get_texture_count";
        /// <summary>
        /// Cached name for the '_font_get_texture_image' method.
        /// </summary>
        public static readonly StringName _FontGetTextureImage = "_font_get_texture_image";
        /// <summary>
        /// Cached name for the '_font_get_texture_offsets' method.
        /// </summary>
        public static readonly StringName _FontGetTextureOffsets = "_font_get_texture_offsets";
        /// <summary>
        /// Cached name for the '_font_get_transform' method.
        /// </summary>
        public static readonly StringName _FontGetTransform = "_font_get_transform";
        /// <summary>
        /// Cached name for the '_font_get_underline_position' method.
        /// </summary>
        public static readonly StringName _FontGetUnderlinePosition = "_font_get_underline_position";
        /// <summary>
        /// Cached name for the '_font_get_underline_thickness' method.
        /// </summary>
        public static readonly StringName _FontGetUnderlineThickness = "_font_get_underline_thickness";
        /// <summary>
        /// Cached name for the '_font_get_variation_coordinates' method.
        /// </summary>
        public static readonly StringName _FontGetVariationCoordinates = "_font_get_variation_coordinates";
        /// <summary>
        /// Cached name for the '_font_get_weight' method.
        /// </summary>
        public static readonly StringName _FontGetWeight = "_font_get_weight";
        /// <summary>
        /// Cached name for the '_font_has_char' method.
        /// </summary>
        public static readonly StringName _FontHasChar = "_font_has_char";
        /// <summary>
        /// Cached name for the '_font_is_allow_system_fallback' method.
        /// </summary>
        public static readonly StringName _FontIsAllowSystemFallback = "_font_is_allow_system_fallback";
        /// <summary>
        /// Cached name for the '_font_is_force_autohinter' method.
        /// </summary>
        public static readonly StringName _FontIsForceAutohinter = "_font_is_force_autohinter";
        /// <summary>
        /// Cached name for the '_font_is_language_supported' method.
        /// </summary>
        public static readonly StringName _FontIsLanguageSupported = "_font_is_language_supported";
        /// <summary>
        /// Cached name for the '_font_is_modulate_color_glyphs' method.
        /// </summary>
        public static readonly StringName _FontIsModulateColorGlyphs = "_font_is_modulate_color_glyphs";
        /// <summary>
        /// Cached name for the '_font_is_multichannel_signed_distance_field' method.
        /// </summary>
        public static readonly StringName _FontIsMultichannelSignedDistanceField = "_font_is_multichannel_signed_distance_field";
        /// <summary>
        /// Cached name for the '_font_is_script_supported' method.
        /// </summary>
        public static readonly StringName _FontIsScriptSupported = "_font_is_script_supported";
        /// <summary>
        /// Cached name for the '_font_remove_glyph' method.
        /// </summary>
        public static readonly StringName _FontRemoveGlyph = "_font_remove_glyph";
        /// <summary>
        /// Cached name for the '_font_remove_kerning' method.
        /// </summary>
        public static readonly StringName _FontRemoveKerning = "_font_remove_kerning";
        /// <summary>
        /// Cached name for the '_font_remove_language_support_override' method.
        /// </summary>
        public static readonly StringName _FontRemoveLanguageSupportOverride = "_font_remove_language_support_override";
        /// <summary>
        /// Cached name for the '_font_remove_script_support_override' method.
        /// </summary>
        public static readonly StringName _FontRemoveScriptSupportOverride = "_font_remove_script_support_override";
        /// <summary>
        /// Cached name for the '_font_remove_size_cache' method.
        /// </summary>
        public static readonly StringName _FontRemoveSizeCache = "_font_remove_size_cache";
        /// <summary>
        /// Cached name for the '_font_remove_texture' method.
        /// </summary>
        public static readonly StringName _FontRemoveTexture = "_font_remove_texture";
        /// <summary>
        /// Cached name for the '_font_render_glyph' method.
        /// </summary>
        public static readonly StringName _FontRenderGlyph = "_font_render_glyph";
        /// <summary>
        /// Cached name for the '_font_render_range' method.
        /// </summary>
        public static readonly StringName _FontRenderRange = "_font_render_range";
        /// <summary>
        /// Cached name for the '_font_set_allow_system_fallback' method.
        /// </summary>
        public static readonly StringName _FontSetAllowSystemFallback = "_font_set_allow_system_fallback";
        /// <summary>
        /// Cached name for the '_font_set_antialiasing' method.
        /// </summary>
        public static readonly StringName _FontSetAntialiasing = "_font_set_antialiasing";
        /// <summary>
        /// Cached name for the '_font_set_ascent' method.
        /// </summary>
        public static readonly StringName _FontSetAscent = "_font_set_ascent";
        /// <summary>
        /// Cached name for the '_font_set_baseline_offset' method.
        /// </summary>
        public static readonly StringName _FontSetBaselineOffset = "_font_set_baseline_offset";
        /// <summary>
        /// Cached name for the '_font_set_data' method.
        /// </summary>
        public static readonly StringName _FontSetData = "_font_set_data";
        /// <summary>
        /// Cached name for the '_font_set_descent' method.
        /// </summary>
        public static readonly StringName _FontSetDescent = "_font_set_descent";
        /// <summary>
        /// Cached name for the '_font_set_disable_embedded_bitmaps' method.
        /// </summary>
        public static readonly StringName _FontSetDisableEmbeddedBitmaps = "_font_set_disable_embedded_bitmaps";
        /// <summary>
        /// Cached name for the '_font_set_embolden' method.
        /// </summary>
        public static readonly StringName _FontSetEmbolden = "_font_set_embolden";
        /// <summary>
        /// Cached name for the '_font_set_face_index' method.
        /// </summary>
        public static readonly StringName _FontSetFaceIndex = "_font_set_face_index";
        /// <summary>
        /// Cached name for the '_font_set_fixed_size' method.
        /// </summary>
        public static readonly StringName _FontSetFixedSize = "_font_set_fixed_size";
        /// <summary>
        /// Cached name for the '_font_set_fixed_size_scale_mode' method.
        /// </summary>
        public static readonly StringName _FontSetFixedSizeScaleMode = "_font_set_fixed_size_scale_mode";
        /// <summary>
        /// Cached name for the '_font_set_force_autohinter' method.
        /// </summary>
        public static readonly StringName _FontSetForceAutohinter = "_font_set_force_autohinter";
        /// <summary>
        /// Cached name for the '_font_set_generate_mipmaps' method.
        /// </summary>
        public static readonly StringName _FontSetGenerateMipmaps = "_font_set_generate_mipmaps";
        /// <summary>
        /// Cached name for the '_font_set_global_oversampling' method.
        /// </summary>
        public static readonly StringName _FontSetGlobalOversampling = "_font_set_global_oversampling";
        /// <summary>
        /// Cached name for the '_font_set_glyph_advance' method.
        /// </summary>
        public static readonly StringName _FontSetGlyphAdvance = "_font_set_glyph_advance";
        /// <summary>
        /// Cached name for the '_font_set_glyph_offset' method.
        /// </summary>
        public static readonly StringName _FontSetGlyphOffset = "_font_set_glyph_offset";
        /// <summary>
        /// Cached name for the '_font_set_glyph_size' method.
        /// </summary>
        public static readonly StringName _FontSetGlyphSize = "_font_set_glyph_size";
        /// <summary>
        /// Cached name for the '_font_set_glyph_texture_idx' method.
        /// </summary>
        public static readonly StringName _FontSetGlyphTextureIdx = "_font_set_glyph_texture_idx";
        /// <summary>
        /// Cached name for the '_font_set_glyph_uv_rect' method.
        /// </summary>
        public static readonly StringName _FontSetGlyphUVRect = "_font_set_glyph_uv_rect";
        /// <summary>
        /// Cached name for the '_font_set_hinting' method.
        /// </summary>
        public static readonly StringName _FontSetHinting = "_font_set_hinting";
        /// <summary>
        /// Cached name for the '_font_set_keep_rounding_remainders' method.
        /// </summary>
        public static readonly StringName _FontSetKeepRoundingRemainders = "_font_set_keep_rounding_remainders";
        /// <summary>
        /// Cached name for the '_font_set_kerning' method.
        /// </summary>
        public static readonly StringName _FontSetKerning = "_font_set_kerning";
        /// <summary>
        /// Cached name for the '_font_set_language_support_override' method.
        /// </summary>
        public static readonly StringName _FontSetLanguageSupportOverride = "_font_set_language_support_override";
        /// <summary>
        /// Cached name for the '_font_set_modulate_color_glyphs' method.
        /// </summary>
        public static readonly StringName _FontSetModulateColorGlyphs = "_font_set_modulate_color_glyphs";
        /// <summary>
        /// Cached name for the '_font_set_msdf_pixel_range' method.
        /// </summary>
        public static readonly StringName _FontSetMsdfPixelRange = "_font_set_msdf_pixel_range";
        /// <summary>
        /// Cached name for the '_font_set_msdf_size' method.
        /// </summary>
        public static readonly StringName _FontSetMsdfSize = "_font_set_msdf_size";
        /// <summary>
        /// Cached name for the '_font_set_multichannel_signed_distance_field' method.
        /// </summary>
        public static readonly StringName _FontSetMultichannelSignedDistanceField = "_font_set_multichannel_signed_distance_field";
        /// <summary>
        /// Cached name for the '_font_set_name' method.
        /// </summary>
        public static readonly StringName _FontSetName = "_font_set_name";
        /// <summary>
        /// Cached name for the '_font_set_opentype_feature_overrides' method.
        /// </summary>
        public static readonly StringName _FontSetOpentypeFeatureOverrides = "_font_set_opentype_feature_overrides";
        /// <summary>
        /// Cached name for the '_font_set_oversampling' method.
        /// </summary>
        public static readonly StringName _FontSetOversampling = "_font_set_oversampling";
        /// <summary>
        /// Cached name for the '_font_set_scale' method.
        /// </summary>
        public static readonly StringName _FontSetScale = "_font_set_scale";
        /// <summary>
        /// Cached name for the '_font_set_script_support_override' method.
        /// </summary>
        public static readonly StringName _FontSetScriptSupportOverride = "_font_set_script_support_override";
        /// <summary>
        /// Cached name for the '_font_set_spacing' method.
        /// </summary>
        public static readonly StringName _FontSetSpacing = "_font_set_spacing";
        /// <summary>
        /// Cached name for the '_font_set_stretch' method.
        /// </summary>
        public static readonly StringName _FontSetStretch = "_font_set_stretch";
        /// <summary>
        /// Cached name for the '_font_set_style' method.
        /// </summary>
        public static readonly StringName _FontSetStyle = "_font_set_style";
        /// <summary>
        /// Cached name for the '_font_set_style_name' method.
        /// </summary>
        public static readonly StringName _FontSetStyleName = "_font_set_style_name";
        /// <summary>
        /// Cached name for the '_font_set_subpixel_positioning' method.
        /// </summary>
        public static readonly StringName _FontSetSubpixelPositioning = "_font_set_subpixel_positioning";
        /// <summary>
        /// Cached name for the '_font_set_texture_image' method.
        /// </summary>
        public static readonly StringName _FontSetTextureImage = "_font_set_texture_image";
        /// <summary>
        /// Cached name for the '_font_set_texture_offsets' method.
        /// </summary>
        public static readonly StringName _FontSetTextureOffsets = "_font_set_texture_offsets";
        /// <summary>
        /// Cached name for the '_font_set_transform' method.
        /// </summary>
        public static readonly StringName _FontSetTransform = "_font_set_transform";
        /// <summary>
        /// Cached name for the '_font_set_underline_position' method.
        /// </summary>
        public static readonly StringName _FontSetUnderlinePosition = "_font_set_underline_position";
        /// <summary>
        /// Cached name for the '_font_set_underline_thickness' method.
        /// </summary>
        public static readonly StringName _FontSetUnderlineThickness = "_font_set_underline_thickness";
        /// <summary>
        /// Cached name for the '_font_set_variation_coordinates' method.
        /// </summary>
        public static readonly StringName _FontSetVariationCoordinates = "_font_set_variation_coordinates";
        /// <summary>
        /// Cached name for the '_font_set_weight' method.
        /// </summary>
        public static readonly StringName _FontSetWeight = "_font_set_weight";
        /// <summary>
        /// Cached name for the '_font_supported_feature_list' method.
        /// </summary>
        public static readonly StringName _FontSupportedFeatureList = "_font_supported_feature_list";
        /// <summary>
        /// Cached name for the '_font_supported_variation_list' method.
        /// </summary>
        public static readonly StringName _FontSupportedVariationList = "_font_supported_variation_list";
        /// <summary>
        /// Cached name for the '_format_number' method.
        /// </summary>
        public static readonly StringName _FormatNumber = "_format_number";
        /// <summary>
        /// Cached name for the '_free_rid' method.
        /// </summary>
        public static readonly StringName _FreeRid = "_free_rid";
        /// <summary>
        /// Cached name for the '_get_features' method.
        /// </summary>
        public static readonly StringName _GetFeatures = "_get_features";
        /// <summary>
        /// Cached name for the '_get_hex_code_box_size' method.
        /// </summary>
        public static readonly StringName _GetHexCodeBoxSize = "_get_hex_code_box_size";
        /// <summary>
        /// Cached name for the '_get_name' method.
        /// </summary>
        public static readonly StringName _GetName = "_get_name";
        /// <summary>
        /// Cached name for the '_get_support_data' method.
        /// </summary>
        public static readonly StringName _GetSupportData = "_get_support_data";
        /// <summary>
        /// Cached name for the '_get_support_data_filename' method.
        /// </summary>
        public static readonly StringName _GetSupportDataFileName = "_get_support_data_filename";
        /// <summary>
        /// Cached name for the '_get_support_data_info' method.
        /// </summary>
        public static readonly StringName _GetSupportDataInfo = "_get_support_data_info";
        /// <summary>
        /// Cached name for the '_has' method.
        /// </summary>
        public static readonly StringName _Has = "_has";
        /// <summary>
        /// Cached name for the '_has_feature' method.
        /// </summary>
        public static readonly StringName _HasFeature = "_has_feature";
        /// <summary>
        /// Cached name for the '_is_confusable' method.
        /// </summary>
        public static readonly StringName _IsConfusable = "_is_confusable";
        /// <summary>
        /// Cached name for the '_is_locale_right_to_left' method.
        /// </summary>
        public static readonly StringName _IsLocaleRightToLeft = "_is_locale_right_to_left";
        /// <summary>
        /// Cached name for the '_is_locale_using_support_data' method.
        /// </summary>
        public static readonly StringName _IsLocaleUsingSupportData = "_is_locale_using_support_data";
        /// <summary>
        /// Cached name for the '_is_valid_identifier' method.
        /// </summary>
        public static readonly StringName _IsValidIdentifier = "_is_valid_identifier";
        /// <summary>
        /// Cached name for the '_is_valid_letter' method.
        /// </summary>
        public static readonly StringName _IsValidLetter = "_is_valid_letter";
        /// <summary>
        /// Cached name for the '_load_support_data' method.
        /// </summary>
        public static readonly StringName _LoadSupportData = "_load_support_data";
        /// <summary>
        /// Cached name for the '_name_to_tag' method.
        /// </summary>
        public static readonly StringName _NameToTag = "_name_to_tag";
        /// <summary>
        /// Cached name for the '_parse_number' method.
        /// </summary>
        public static readonly StringName _ParseNumber = "_parse_number";
        /// <summary>
        /// Cached name for the '_parse_structured_text' method.
        /// </summary>
        public static readonly StringName _ParseStructuredText = "_parse_structured_text";
        /// <summary>
        /// Cached name for the '_percent_sign' method.
        /// </summary>
        public static readonly StringName _PercentSign = "_percent_sign";
        /// <summary>
        /// Cached name for the '_reference_oversampling_level' method.
        /// </summary>
        public static readonly StringName _ReferenceOversamplingLevel = "_reference_oversampling_level";
        /// <summary>
        /// Cached name for the '_save_support_data' method.
        /// </summary>
        public static readonly StringName _SaveSupportData = "_save_support_data";
        /// <summary>
        /// Cached name for the '_shaped_get_run_count' method.
        /// </summary>
        public static readonly StringName _ShapedGetRunCount = "_shaped_get_run_count";
        /// <summary>
        /// Cached name for the '_shaped_get_run_direction' method.
        /// </summary>
        public static readonly StringName _ShapedGetRunDirection = "_shaped_get_run_direction";
        /// <summary>
        /// Cached name for the '_shaped_get_run_font_rid' method.
        /// </summary>
        public static readonly StringName _ShapedGetRunFontRid = "_shaped_get_run_font_rid";
        /// <summary>
        /// Cached name for the '_shaped_get_run_font_size' method.
        /// </summary>
        public static readonly StringName _ShapedGetRunFontSize = "_shaped_get_run_font_size";
        /// <summary>
        /// Cached name for the '_shaped_get_run_language' method.
        /// </summary>
        public static readonly StringName _ShapedGetRunLanguage = "_shaped_get_run_language";
        /// <summary>
        /// Cached name for the '_shaped_get_run_object' method.
        /// </summary>
        public static readonly StringName _ShapedGetRunObject = "_shaped_get_run_object";
        /// <summary>
        /// Cached name for the '_shaped_get_run_range' method.
        /// </summary>
        public static readonly StringName _ShapedGetRunRange = "_shaped_get_run_range";
        /// <summary>
        /// Cached name for the '_shaped_get_run_text' method.
        /// </summary>
        public static readonly StringName _ShapedGetRunText = "_shaped_get_run_text";
        /// <summary>
        /// Cached name for the '_shaped_get_span_count' method.
        /// </summary>
        public static readonly StringName _ShapedGetSpanCount = "_shaped_get_span_count";
        /// <summary>
        /// Cached name for the '_shaped_get_span_embedded_object' method.
        /// </summary>
        public static readonly StringName _ShapedGetSpanEmbeddedObject = "_shaped_get_span_embedded_object";
        /// <summary>
        /// Cached name for the '_shaped_get_span_meta' method.
        /// </summary>
        public static readonly StringName _ShapedGetSpanMeta = "_shaped_get_span_meta";
        /// <summary>
        /// Cached name for the '_shaped_get_span_object' method.
        /// </summary>
        public static readonly StringName _ShapedGetSpanObject = "_shaped_get_span_object";
        /// <summary>
        /// Cached name for the '_shaped_get_span_text' method.
        /// </summary>
        public static readonly StringName _ShapedGetSpanText = "_shaped_get_span_text";
        /// <summary>
        /// Cached name for the '_shaped_get_text' method.
        /// </summary>
        public static readonly StringName _ShapedGetText = "_shaped_get_text";
        /// <summary>
        /// Cached name for the '_shaped_set_span_update_font' method.
        /// </summary>
        public static readonly StringName _ShapedSetSpanUpdateFont = "_shaped_set_span_update_font";
        /// <summary>
        /// Cached name for the '_shaped_text_add_object' method.
        /// </summary>
        public static readonly StringName _ShapedTextAddObject = "_shaped_text_add_object";
        /// <summary>
        /// Cached name for the '_shaped_text_add_string' method.
        /// </summary>
        public static readonly StringName _ShapedTextAddString = "_shaped_text_add_string";
        /// <summary>
        /// Cached name for the '_shaped_text_clear' method.
        /// </summary>
        public static readonly StringName _ShapedTextClear = "_shaped_text_clear";
        /// <summary>
        /// Cached name for the '_shaped_text_closest_character_pos' method.
        /// </summary>
        public static readonly StringName _ShapedTextClosestCharacterPos = "_shaped_text_closest_character_pos";
        /// <summary>
        /// Cached name for the '_shaped_text_draw' method.
        /// </summary>
        public static readonly StringName _ShapedTextDraw = "_shaped_text_draw";
        /// <summary>
        /// Cached name for the '_shaped_text_draw_outline' method.
        /// </summary>
        public static readonly StringName _ShapedTextDrawOutline = "_shaped_text_draw_outline";
        /// <summary>
        /// Cached name for the '_shaped_text_duplicate' method.
        /// </summary>
        public static readonly StringName _ShapedTextDuplicate = "_shaped_text_duplicate";
        /// <summary>
        /// Cached name for the '_shaped_text_fit_to_width' method.
        /// </summary>
        public static readonly StringName _ShapedTextFitToWidth = "_shaped_text_fit_to_width";
        /// <summary>
        /// Cached name for the '_shaped_text_get_ascent' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetAscent = "_shaped_text_get_ascent";
        /// <summary>
        /// Cached name for the '_shaped_text_get_character_breaks' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetCharacterBreaks = "_shaped_text_get_character_breaks";
        /// <summary>
        /// Cached name for the '_shaped_text_get_custom_ellipsis' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetCustomEllipsis = "_shaped_text_get_custom_ellipsis";
        /// <summary>
        /// Cached name for the '_shaped_text_get_custom_punctuation' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetCustomPunctuation = "_shaped_text_get_custom_punctuation";
        /// <summary>
        /// Cached name for the '_shaped_text_get_descent' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetDescent = "_shaped_text_get_descent";
        /// <summary>
        /// Cached name for the '_shaped_text_get_direction' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetDirection = "_shaped_text_get_direction";
        /// <summary>
        /// Cached name for the '_shaped_text_get_dominant_direction_in_range' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetDominantDirectionInRange = "_shaped_text_get_dominant_direction_in_range";
        /// <summary>
        /// Cached name for the '_shaped_text_get_ellipsis_glyph_count' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetEllipsisGlyphCount = "_shaped_text_get_ellipsis_glyph_count";
        /// <summary>
        /// Cached name for the '_shaped_text_get_ellipsis_pos' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetEllipsisPos = "_shaped_text_get_ellipsis_pos";
        /// <summary>
        /// Cached name for the '_shaped_text_get_glyph_count' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetGlyphCount = "_shaped_text_get_glyph_count";
        /// <summary>
        /// Cached name for the '_shaped_text_get_grapheme_bounds' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetGraphemeBounds = "_shaped_text_get_grapheme_bounds";
        /// <summary>
        /// Cached name for the '_shaped_text_get_inferred_direction' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetInferredDirection = "_shaped_text_get_inferred_direction";
        /// <summary>
        /// Cached name for the '_shaped_text_get_line_breaks' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetLineBreaks = "_shaped_text_get_line_breaks";
        /// <summary>
        /// Cached name for the '_shaped_text_get_line_breaks_adv' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetLineBreaksAdv = "_shaped_text_get_line_breaks_adv";
        /// <summary>
        /// Cached name for the '_shaped_text_get_object_glyph' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetObjectGlyph = "_shaped_text_get_object_glyph";
        /// <summary>
        /// Cached name for the '_shaped_text_get_object_range' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetObjectRange = "_shaped_text_get_object_range";
        /// <summary>
        /// Cached name for the '_shaped_text_get_object_rect' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetObjectRect = "_shaped_text_get_object_rect";
        /// <summary>
        /// Cached name for the '_shaped_text_get_objects' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetObjects = "_shaped_text_get_objects";
        /// <summary>
        /// Cached name for the '_shaped_text_get_orientation' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetOrientation = "_shaped_text_get_orientation";
        /// <summary>
        /// Cached name for the '_shaped_text_get_parent' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetParent = "_shaped_text_get_parent";
        /// <summary>
        /// Cached name for the '_shaped_text_get_preserve_control' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetPreserveControl = "_shaped_text_get_preserve_control";
        /// <summary>
        /// Cached name for the '_shaped_text_get_preserve_invalid' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetPreserveInvalid = "_shaped_text_get_preserve_invalid";
        /// <summary>
        /// Cached name for the '_shaped_text_get_range' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetRange = "_shaped_text_get_range";
        /// <summary>
        /// Cached name for the '_shaped_text_get_selection' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetSelection = "_shaped_text_get_selection";
        /// <summary>
        /// Cached name for the '_shaped_text_get_size' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetSize = "_shaped_text_get_size";
        /// <summary>
        /// Cached name for the '_shaped_text_get_spacing' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetSpacing = "_shaped_text_get_spacing";
        /// <summary>
        /// Cached name for the '_shaped_text_get_trim_pos' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetTrimPos = "_shaped_text_get_trim_pos";
        /// <summary>
        /// Cached name for the '_shaped_text_get_underline_position' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetUnderlinePosition = "_shaped_text_get_underline_position";
        /// <summary>
        /// Cached name for the '_shaped_text_get_underline_thickness' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetUnderlineThickness = "_shaped_text_get_underline_thickness";
        /// <summary>
        /// Cached name for the '_shaped_text_get_width' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetWidth = "_shaped_text_get_width";
        /// <summary>
        /// Cached name for the '_shaped_text_get_word_breaks' method.
        /// </summary>
        public static readonly StringName _ShapedTextGetWordBreaks = "_shaped_text_get_word_breaks";
        /// <summary>
        /// Cached name for the '_shaped_text_has_object' method.
        /// </summary>
        public static readonly StringName _ShapedTextHasObject = "_shaped_text_has_object";
        /// <summary>
        /// Cached name for the '_shaped_text_hit_test_grapheme' method.
        /// </summary>
        public static readonly StringName _ShapedTextHitTestGrapheme = "_shaped_text_hit_test_grapheme";
        /// <summary>
        /// Cached name for the '_shaped_text_hit_test_position' method.
        /// </summary>
        public static readonly StringName _ShapedTextHitTestPosition = "_shaped_text_hit_test_position";
        /// <summary>
        /// Cached name for the '_shaped_text_is_ready' method.
        /// </summary>
        public static readonly StringName _ShapedTextIsReady = "_shaped_text_is_ready";
        /// <summary>
        /// Cached name for the '_shaped_text_next_character_pos' method.
        /// </summary>
        public static readonly StringName _ShapedTextNextCharacterPos = "_shaped_text_next_character_pos";
        /// <summary>
        /// Cached name for the '_shaped_text_next_grapheme_pos' method.
        /// </summary>
        public static readonly StringName _ShapedTextNextGraphemePos = "_shaped_text_next_grapheme_pos";
        /// <summary>
        /// Cached name for the '_shaped_text_overrun_trim_to_width' method.
        /// </summary>
        public static readonly StringName _ShapedTextOverrunTrimToWidth = "_shaped_text_overrun_trim_to_width";
        /// <summary>
        /// Cached name for the '_shaped_text_prev_character_pos' method.
        /// </summary>
        public static readonly StringName _ShapedTextPrevCharacterPos = "_shaped_text_prev_character_pos";
        /// <summary>
        /// Cached name for the '_shaped_text_prev_grapheme_pos' method.
        /// </summary>
        public static readonly StringName _ShapedTextPrevGraphemePos = "_shaped_text_prev_grapheme_pos";
        /// <summary>
        /// Cached name for the '_shaped_text_resize_object' method.
        /// </summary>
        public static readonly StringName _ShapedTextResizeObject = "_shaped_text_resize_object";
        /// <summary>
        /// Cached name for the '_shaped_text_set_bidi_override' method.
        /// </summary>
        public static readonly StringName _ShapedTextSetBidiOverride = "_shaped_text_set_bidi_override";
        /// <summary>
        /// Cached name for the '_shaped_text_set_custom_ellipsis' method.
        /// </summary>
        public static readonly StringName _ShapedTextSetCustomEllipsis = "_shaped_text_set_custom_ellipsis";
        /// <summary>
        /// Cached name for the '_shaped_text_set_custom_punctuation' method.
        /// </summary>
        public static readonly StringName _ShapedTextSetCustomPunctuation = "_shaped_text_set_custom_punctuation";
        /// <summary>
        /// Cached name for the '_shaped_text_set_direction' method.
        /// </summary>
        public static readonly StringName _ShapedTextSetDirection = "_shaped_text_set_direction";
        /// <summary>
        /// Cached name for the '_shaped_text_set_orientation' method.
        /// </summary>
        public static readonly StringName _ShapedTextSetOrientation = "_shaped_text_set_orientation";
        /// <summary>
        /// Cached name for the '_shaped_text_set_preserve_control' method.
        /// </summary>
        public static readonly StringName _ShapedTextSetPreserveControl = "_shaped_text_set_preserve_control";
        /// <summary>
        /// Cached name for the '_shaped_text_set_preserve_invalid' method.
        /// </summary>
        public static readonly StringName _ShapedTextSetPreserveInvalid = "_shaped_text_set_preserve_invalid";
        /// <summary>
        /// Cached name for the '_shaped_text_set_spacing' method.
        /// </summary>
        public static readonly StringName _ShapedTextSetSpacing = "_shaped_text_set_spacing";
        /// <summary>
        /// Cached name for the '_shaped_text_shape' method.
        /// </summary>
        public static readonly StringName _ShapedTextShape = "_shaped_text_shape";
        /// <summary>
        /// Cached name for the '_shaped_text_substr' method.
        /// </summary>
        public static readonly StringName _ShapedTextSubstr = "_shaped_text_substr";
        /// <summary>
        /// Cached name for the '_shaped_text_tab_align' method.
        /// </summary>
        public static readonly StringName _ShapedTextTabAlign = "_shaped_text_tab_align";
        /// <summary>
        /// Cached name for the '_shaped_text_update_breaks' method.
        /// </summary>
        public static readonly StringName _ShapedTextUpdateBreaks = "_shaped_text_update_breaks";
        /// <summary>
        /// Cached name for the '_shaped_text_update_justification_ops' method.
        /// </summary>
        public static readonly StringName _ShapedTextUpdateJustificationOps = "_shaped_text_update_justification_ops";
        /// <summary>
        /// Cached name for the '_spoof_check' method.
        /// </summary>
        public static readonly StringName _SpoofCheck = "_spoof_check";
        /// <summary>
        /// Cached name for the '_string_get_character_breaks' method.
        /// </summary>
        public static readonly StringName _StringGetCharacterBreaks = "_string_get_character_breaks";
        /// <summary>
        /// Cached name for the '_string_get_word_breaks' method.
        /// </summary>
        public static readonly StringName _StringGetWordBreaks = "_string_get_word_breaks";
        /// <summary>
        /// Cached name for the '_string_to_lower' method.
        /// </summary>
        public static readonly StringName _StringToLower = "_string_to_lower";
        /// <summary>
        /// Cached name for the '_string_to_title' method.
        /// </summary>
        public static readonly StringName _StringToTitle = "_string_to_title";
        /// <summary>
        /// Cached name for the '_string_to_upper' method.
        /// </summary>
        public static readonly StringName _StringToUpper = "_string_to_upper";
        /// <summary>
        /// Cached name for the '_strip_diacritics' method.
        /// </summary>
        public static readonly StringName _StripDiacritics = "_strip_diacritics";
        /// <summary>
        /// Cached name for the '_tag_to_name' method.
        /// </summary>
        public static readonly StringName _TagToName = "_tag_to_name";
        /// <summary>
        /// Cached name for the '_unreference_oversampling_level' method.
        /// </summary>
        public static readonly StringName _UnreferenceOversamplingLevel = "_unreference_oversampling_level";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : TextServer.SignalName
    {
    }
}
