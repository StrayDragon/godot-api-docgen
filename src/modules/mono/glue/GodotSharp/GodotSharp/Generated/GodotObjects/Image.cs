namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Native image datatype. Contains image data which can be converted to an <see cref="Godot.ImageTexture"/> and provides commonly used <i>image processing</i> methods. The maximum width and height for an <see cref="Godot.Image"/> are <see cref="Godot.Image.MaxWidth"/> and <see cref="Godot.Image.MaxHeight"/>.</para>
/// <para>An <see cref="Godot.Image"/> cannot be assigned to a texture property of an object directly (such as <see cref="Godot.Sprite2D.Texture"/>), and has to be converted manually to an <see cref="Godot.ImageTexture"/> first.</para>
/// <para><b>Note:</b> Methods that modify the image data cannot be used on VRAM-compressed images. Use <see cref="Godot.Image.Decompress()"/> to convert the image to an uncompressed format first.</para>
/// <para><b>Note:</b> The maximum image size is 16384×16384 pixels due to graphics hardware limitations. Larger images may fail to import.</para>
/// </summary>
public partial class Image : Resource
{
    /// <summary>
    /// <para>The maximal width allowed for <see cref="Godot.Image"/> resources.</para>
    /// </summary>
    public const long MaxWidth = 16777216;
    /// <summary>
    /// <para>The maximal height allowed for <see cref="Godot.Image"/> resources.</para>
    /// </summary>
    public const long MaxHeight = 16777216;

    public enum Format : long
    {
        /// <summary>
        /// <para>Texture format with a single 8-bit depth representing luminance.</para>
        /// </summary>
        L8 = 0,
        /// <summary>
        /// <para>OpenGL texture format with two values, luminance and alpha each stored with 8 bits.</para>
        /// </summary>
        La8 = 1,
        /// <summary>
        /// <para>OpenGL texture format <c>RED</c> with a single component and a bitdepth of 8.</para>
        /// </summary>
        R8 = 2,
        /// <summary>
        /// <para>OpenGL texture format <c>RG</c> with two components and a bitdepth of 8 for each.</para>
        /// </summary>
        Rg8 = 3,
        /// <summary>
        /// <para>OpenGL texture format <c>RGB</c> with three components, each with a bitdepth of 8.</para>
        /// <para><b>Note:</b> When creating an <see cref="Godot.ImageTexture"/>, a nonlinear sRGB to linear encoding conversion is performed.</para>
        /// </summary>
        Rgb8 = 4,
        /// <summary>
        /// <para>OpenGL texture format <c>RGBA</c> with four components, each with a bitdepth of 8.</para>
        /// <para><b>Note:</b> When creating an <see cref="Godot.ImageTexture"/>, a nonlinear sRGB to linear encoding conversion is performed.</para>
        /// </summary>
        Rgba8 = 5,
        /// <summary>
        /// <para>OpenGL texture format <c>RGBA</c> with four components, each with a bitdepth of 4.</para>
        /// </summary>
        Rgba4444 = 6,
        /// <summary>
        /// <para>OpenGL texture format <c>RGB</c> with three components. Red and blue have a bitdepth of 5, and green has a bitdepth of 6.</para>
        /// </summary>
        Rgb565 = 7,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_R32F</c> where there's one component, a 32-bit floating-point value.</para>
        /// </summary>
        Rf = 8,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RG32F</c> where there are two components, each a 32-bit floating-point values.</para>
        /// </summary>
        Rgf = 9,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RGB32F</c> where there are three components, each a 32-bit floating-point values.</para>
        /// </summary>
        Rgbf = 10,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RGBA32F</c> where there are four components, each a 32-bit floating-point values.</para>
        /// </summary>
        Rgbaf = 11,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_R16F</c> where there's one component, a 16-bit "half-precision" floating-point value.</para>
        /// </summary>
        Rh = 12,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RG16F</c> where there are two components, each a 16-bit "half-precision" floating-point value.</para>
        /// </summary>
        Rgh = 13,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RGB16F</c> where there are three components, each a 16-bit "half-precision" floating-point value.</para>
        /// </summary>
        Rgbh = 14,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RGBA16F</c> where there are four components, each a 16-bit "half-precision" floating-point value.</para>
        /// </summary>
        Rgbah = 15,
        /// <summary>
        /// <para>A special OpenGL texture format where the three color components have 9 bits of precision and all three share a single 5-bit exponent.</para>
        /// </summary>
        Rgbe9995 = 16,
        /// <summary>
        /// <para>The <a href="https://en.wikipedia.org/wiki/S3_Texture_Compression">S3TC</a> texture format that uses Block Compression 1, and is the smallest variation of S3TC, only providing 1 bit of alpha and color data being premultiplied with alpha.</para>
        /// <para><b>Note:</b> When creating an <see cref="Godot.ImageTexture"/>, a nonlinear sRGB to linear encoding conversion is performed.</para>
        /// </summary>
        Dxt1 = 17,
        /// <summary>
        /// <para>The <a href="https://en.wikipedia.org/wiki/S3_Texture_Compression">S3TC</a> texture format that uses Block Compression 2, and color data is interpreted as not having been premultiplied by alpha. Well suited for images with sharp alpha transitions between translucent and opaque areas.</para>
        /// <para><b>Note:</b> When creating an <see cref="Godot.ImageTexture"/>, a nonlinear sRGB to linear encoding conversion is performed.</para>
        /// </summary>
        Dxt3 = 18,
        /// <summary>
        /// <para>The <a href="https://en.wikipedia.org/wiki/S3_Texture_Compression">S3TC</a> texture format also known as Block Compression 3 or BC3 that contains 64 bits of alpha channel data followed by 64 bits of DXT1-encoded color data. Color data is not premultiplied by alpha, same as DXT3. DXT5 generally produces superior results for transparent gradients compared to DXT3.</para>
        /// <para><b>Note:</b> When creating an <see cref="Godot.ImageTexture"/>, a nonlinear sRGB to linear encoding conversion is performed.</para>
        /// </summary>
        Dxt5 = 19,
        /// <summary>
        /// <para>Texture format that uses <a href="https://www.khronos.org/opengl/wiki/Red_Green_Texture_Compression">Red Green Texture Compression</a>, normalizing the red channel data using the same compression algorithm that DXT5 uses for the alpha channel.</para>
        /// </summary>
        RgtcR = 20,
        /// <summary>
        /// <para>Texture format that uses <a href="https://www.khronos.org/opengl/wiki/Red_Green_Texture_Compression">Red Green Texture Compression</a>, normalizing the red and green channel data using the same compression algorithm that DXT5 uses for the alpha channel.</para>
        /// </summary>
        RgtcRg = 21,
        /// <summary>
        /// <para>Texture format that uses <a href="https://www.khronos.org/opengl/wiki/BPTC_Texture_Compression">BPTC</a> compression with unsigned normalized RGBA components.</para>
        /// <para><b>Note:</b> When creating an <see cref="Godot.ImageTexture"/>, a nonlinear sRGB to linear encoding conversion is performed.</para>
        /// </summary>
        BptcRgba = 22,
        /// <summary>
        /// <para>Texture format that uses <a href="https://www.khronos.org/opengl/wiki/BPTC_Texture_Compression">BPTC</a> compression with signed floating-point RGB components.</para>
        /// </summary>
        BptcRgbf = 23,
        /// <summary>
        /// <para>Texture format that uses <a href="https://www.khronos.org/opengl/wiki/BPTC_Texture_Compression">BPTC</a> compression with unsigned floating-point RGB components.</para>
        /// </summary>
        BptcRgbfu = 24,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Ericsson_Texture_Compression#ETC1">Ericsson Texture Compression format 1</a>, also referred to as "ETC1", and is part of the OpenGL ES graphics standard. This format cannot store an alpha channel.</para>
        /// </summary>
        Etc = 25,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Ericsson_Texture_Compression#ETC2_and_EAC">Ericsson Texture Compression format 2</a> (<c>R11_EAC</c> variant), which provides one channel of unsigned data.</para>
        /// </summary>
        Etc2R11 = 26,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Ericsson_Texture_Compression#ETC2_and_EAC">Ericsson Texture Compression format 2</a> (<c>SIGNED_R11_EAC</c> variant), which provides one channel of signed data.</para>
        /// </summary>
        Etc2R11S = 27,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Ericsson_Texture_Compression#ETC2_and_EAC">Ericsson Texture Compression format 2</a> (<c>RG11_EAC</c> variant), which provides two channels of unsigned data.</para>
        /// </summary>
        Etc2Rg11 = 28,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Ericsson_Texture_Compression#ETC2_and_EAC">Ericsson Texture Compression format 2</a> (<c>SIGNED_RG11_EAC</c> variant), which provides two channels of signed data.</para>
        /// </summary>
        Etc2Rg11S = 29,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Ericsson_Texture_Compression#ETC2_and_EAC">Ericsson Texture Compression format 2</a> (<c>RGB8</c> variant), which is a follow-up of ETC1 and compresses RGB888 data.</para>
        /// <para><b>Note:</b> When creating an <see cref="Godot.ImageTexture"/>, a nonlinear sRGB to linear encoding conversion is performed.</para>
        /// </summary>
        Etc2Rgb8 = 30,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Ericsson_Texture_Compression#ETC2_and_EAC">Ericsson Texture Compression format 2</a> (<c>RGBA8</c>variant), which compresses RGBA8888 data with full alpha support.</para>
        /// <para><b>Note:</b> When creating an <see cref="Godot.ImageTexture"/>, a nonlinear sRGB to linear encoding conversion is performed.</para>
        /// </summary>
        Etc2Rgba8 = 31,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Ericsson_Texture_Compression#ETC2_and_EAC">Ericsson Texture Compression format 2</a> (<c>RGB8_PUNCHTHROUGH_ALPHA1</c> variant), which compresses RGBA data to make alpha either fully transparent or fully opaque.</para>
        /// <para><b>Note:</b> When creating an <see cref="Godot.ImageTexture"/>, a nonlinear sRGB to linear encoding conversion is performed.</para>
        /// </summary>
        Etc2Rgb8A1 = 32,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Ericsson_Texture_Compression#ETC2_and_EAC">Ericsson Texture Compression format 2</a> (<c>RGBA8</c> variant), which compresses RA data and interprets it as two channels (red and green). See also <see cref="Godot.Image.Format.Etc2Rgba8"/>.</para>
        /// </summary>
        Etc2RaAsRg = 33,
        /// <summary>
        /// <para>The <a href="https://en.wikipedia.org/wiki/S3_Texture_Compression">S3TC</a> texture format also known as Block Compression 3 or BC3, which compresses RA data and interprets it as two channels (red and green). See also <see cref="Godot.Image.Format.Dxt5"/>.</para>
        /// </summary>
        Dxt5RaAsRg = 34,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Adaptive_scalable_texture_compression">Adaptive Scalable Texture Compression</a>. This implements the 4×4 (high quality) mode.</para>
        /// </summary>
        Astc4X4 = 35,
        /// <summary>
        /// <para>Same format as <see cref="Godot.Image.Format.Astc4X4"/>, but with the hint to let the GPU know it is used for HDR.</para>
        /// </summary>
        Astc4X4Hdr = 36,
        /// <summary>
        /// <para><a href="https://en.wikipedia.org/wiki/Adaptive_scalable_texture_compression">Adaptive Scalable Texture Compression</a>. This implements the 8×8 (low quality) mode.</para>
        /// </summary>
        Astc8X8 = 37,
        /// <summary>
        /// <para>Same format as <see cref="Godot.Image.Format.Astc8X8"/>, but with the hint to let the GPU know it is used for HDR.</para>
        /// </summary>
        Astc8X8Hdr = 38,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_R16</c> where there's one component, a 16-bit unsigned normalized integer value. Since the value is normalized, each component is clamped between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
        /// <para><b>Note:</b> Due to limited hardware support, it is mainly recommended to be used on desktop or console devices. It may be unsupported on mobile or web, and will consequently be converted to <see cref="Godot.Image.Format.Rf"/>.</para>
        /// </summary>
        R16 = 39,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RG16</c> where there are two components, each a 16-bit unsigned normalized integer value. Since the value is normalized, each component is clamped between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
        /// <para><b>Note:</b> Due to limited hardware support, it is mainly recommended to be used on desktop or console devices. It may be unsupported on mobile or web, and will consequently be converted to <see cref="Godot.Image.Format.Rgf"/>.</para>
        /// </summary>
        Rg16 = 40,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RGB16</c> where there are three components, each a 16-bit unsigned normalized integer value. Since the value is normalized, each component is clamped between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
        /// <para><b>Note:</b> Due to limited hardware support, it is mainly recommended to be used on desktop or console devices. It may be unsupported on mobile or web, and will consequently be converted to <see cref="Godot.Image.Format.Rgbf"/>.</para>
        /// </summary>
        Rgb16 = 41,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RGBA16</c> where there are four components, each a 16-bit unsigned normalized integer value. Since the value is normalized, each component is clamped between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
        /// <para><b>Note:</b> Due to limited hardware support, it is mainly recommended to be used on desktop or console devices. It may be unsupported on mobile or web, and will consequently be converted to <see cref="Godot.Image.Format.Rgbaf"/>.</para>
        /// </summary>
        Rgba16 = 42,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_R16UI</c> where there's one component, a 16-bit unsigned integer value. Each component is clamped between <c>0</c> and <c>65535</c> (inclusive).</para>
        /// <para><b>Note:</b> When used in a shader, the texture requires usage of <c>usampler</c> samplers. Additionally, it only supports nearest-neighbor filtering under the Compatibility renderer.</para>
        /// <para><b>Note:</b> When sampling using <see cref="Godot.Image.GetPixel(int, int)"/>, returned <see cref="Godot.Color"/>s have to be divided by <c>65535</c> to get the correct color value.</para>
        /// </summary>
        R16I = 43,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RG16UI</c> where there are two components, each a 16-bit unsigned integer value. Each component is clamped between <c>0</c> and <c>65535</c> (inclusive).</para>
        /// <para><b>Note:</b> When used in a shader, the texture requires usage of <c>usampler</c> samplers. Additionally, it only supports nearest-neighbor filtering under the Compatibility renderer.</para>
        /// <para><b>Note:</b> When sampling using <see cref="Godot.Image.GetPixel(int, int)"/>, returned <see cref="Godot.Color"/>s have to be divided by <c>65535</c> to get the correct color value.</para>
        /// </summary>
        Rg16I = 44,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RGB16UI</c> where there are three components, each a 16-bit unsigned integer value. Each component is clamped between <c>0</c> and <c>65535</c> (inclusive).</para>
        /// <para><b>Note:</b> When used in a shader, the texture requires usage of <c>usampler</c> samplers. Additionally, it only supports nearest-neighbor filtering under the Compatibility renderer.</para>
        /// <para><b>Note:</b> When sampling using <see cref="Godot.Image.GetPixel(int, int)"/>, returned <see cref="Godot.Color"/>s have to be divided by <c>65535</c> to get the correct color value.</para>
        /// </summary>
        Rgb16I = 45,
        /// <summary>
        /// <para>OpenGL texture format <c>GL_RGBA16UI</c> where there are four components, each a 16-bit unsigned integer value. Each component is clamped between <c>0</c> and <c>65535</c> (inclusive).</para>
        /// <para><b>Note:</b> When used in a shader, the texture requires usage of <c>usampler</c> samplers. Additionally, it only supports nearest-neighbor filtering under the Compatibility renderer.</para>
        /// <para><b>Note:</b> When sampling using <see cref="Godot.Image.GetPixel(int, int)"/>, returned <see cref="Godot.Color"/>s have to be divided by <c>65535</c> to get the correct color value.</para>
        /// </summary>
        Rgba16I = 46,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Image.Format"/> enum.</para>
        /// </summary>
        Max = 47
    }

    public enum Interpolation : long
    {
        /// <summary>
        /// <para>Performs nearest-neighbor interpolation. If the image is resized, it will be pixelated.</para>
        /// </summary>
        Nearest = 0,
        /// <summary>
        /// <para>Performs bilinear interpolation. If the image is resized, it will be blurry. This mode is faster than <see cref="Godot.Image.Interpolation.Cubic"/>, but it results in lower quality.</para>
        /// </summary>
        Bilinear = 1,
        /// <summary>
        /// <para>Performs cubic interpolation. If the image is resized, it will be blurry. This mode often gives better results compared to <see cref="Godot.Image.Interpolation.Bilinear"/>, at the cost of being slower.</para>
        /// </summary>
        Cubic = 2,
        /// <summary>
        /// <para>Performs bilinear separately on the two most-suited mipmap levels, then linearly interpolates between them.</para>
        /// <para>It's slower than <see cref="Godot.Image.Interpolation.Bilinear"/>, but produces higher-quality results with far fewer aliasing artifacts.</para>
        /// <para>If the image does not have mipmaps, they will be generated and used internally, but no mipmaps will be generated on the resulting image.</para>
        /// <para><b>Note:</b> If you intend to scale multiple copies of the original image, it's better to call <see cref="Godot.Image.GenerateMipmaps(bool)"/>] on it in advance, to avoid wasting processing power in generating them again and again.</para>
        /// <para>On the other hand, if the image already has mipmaps, they will be used, and a new set will be generated for the resulting image.</para>
        /// </summary>
        Trilinear = 3,
        /// <summary>
        /// <para>Performs Lanczos interpolation. This is the slowest image resizing mode, but it typically gives the best results, especially when downscaling images.</para>
        /// </summary>
        Lanczos = 4
    }

    public enum AlphaMode : long
    {
        /// <summary>
        /// <para>Image is fully opaque. It does not store alpha data.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Image stores either fully opaque or fully transparent pixels. Also known as punchthrough alpha.</para>
        /// </summary>
        Bit = 1,
        /// <summary>
        /// <para>Image stores alpha data with values varying between <c>0.0</c> and <c>1.0</c>.</para>
        /// </summary>
        Blend = 2
    }

    public enum CompressMode : long
    {
        /// <summary>
        /// <para>Use S3TC compression.</para>
        /// </summary>
        S3Tc = 0,
        /// <summary>
        /// <para>Use ETC compression.</para>
        /// </summary>
        Etc = 1,
        /// <summary>
        /// <para>Use ETC2 compression.</para>
        /// </summary>
        Etc2 = 2,
        /// <summary>
        /// <para>Use BPTC compression.</para>
        /// </summary>
        Bptc = 3,
        /// <summary>
        /// <para>Use ASTC compression.</para>
        /// </summary>
        Astc = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Image.CompressMode"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum UsedChannels : long
    {
        /// <summary>
        /// <para>The image only uses one channel for luminance (grayscale).</para>
        /// </summary>
        L = 0,
        /// <summary>
        /// <para>The image uses two channels for luminance and alpha, respectively.</para>
        /// </summary>
        La = 1,
        /// <summary>
        /// <para>The image only uses the red channel.</para>
        /// </summary>
        R = 2,
        /// <summary>
        /// <para>The image uses two channels for red and green.</para>
        /// </summary>
        Rg = 3,
        /// <summary>
        /// <para>The image uses three channels for red, green, and blue.</para>
        /// </summary>
        Rgb = 4,
        /// <summary>
        /// <para>The image uses four channels for red, green, blue, and alpha.</para>
        /// </summary>
        Rgba = 5
    }

    public enum CompressSource : long
    {
        /// <summary>
        /// <para>Source texture (before compression) is a regular texture. Default for all textures.</para>
        /// </summary>
        Generic = 0,
        /// <summary>
        /// <para>Source texture (before compression) uses nonlinear sRGB encoding.</para>
        /// </summary>
        Srgb = 1,
        /// <summary>
        /// <para>Source texture (before compression) is a normal texture (e.g. it can be compressed into two channels).</para>
        /// </summary>
        Normal = 2
    }

    public enum AstcFormat : long
    {
        /// <summary>
        /// <para>Hint to indicate that the high quality 4×4 ASTC compression format should be used.</para>
        /// </summary>
        Format4X4 = 0,
        /// <summary>
        /// <para>Hint to indicate that the low quality 8×8 ASTC compression format should be used.</para>
        /// </summary>
        Format8X8 = 1
    }

    /// <summary>
    /// <para>Holds all the image's color data in a given format. See <see cref="Godot.Image.Format"/> constants.</para>
    /// </summary>
    public Godot.Collections.Dictionary Data
    {
        get
        {
            return _GetData();
        }
        set
        {
            _SetData(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Image);

    private static readonly StringName NativeName = "Image";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Image() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Image(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Image(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWidth, 3905245786ul);

    /// <summary>
    /// <para>Returns the image's width.</para>
    /// </summary>
    public int GetWidth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeight, 3905245786ul);

    /// <summary>
    /// <para>Returns the image's height.</para>
    /// </summary>
    public int GetHeight()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3690982128ul);

    /// <summary>
    /// <para>Returns the image's size (width and height).</para>
    /// </summary>
    public Vector2I GetSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasMipmaps, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the image has generated mipmaps.</para>
    /// </summary>
    public bool HasMipmaps()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFormat, 3847873762ul);

    /// <summary>
    /// <para>Returns this image's format.</para>
    /// </summary>
    public Image.Format GetFormat()
    {
        return (Image.Format)NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetData, 2362200018ul);

    /// <summary>
    /// <para>Returns a copy of the image's raw data.</para>
    /// </summary>
    public byte[] GetData()
    {
        return NativeCalls.godot_icall_0_2(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDataSize, 3905245786ul);

    /// <summary>
    /// <para>Returns size (in bytes) of the image's raw data.</para>
    /// </summary>
    public long GetDataSize()
    {
        return NativeCalls.godot_icall_0_4(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Convert, 2120693146ul);

    /// <summary>
    /// <para>Converts this image's format to the given <paramref name="format"/>.</para>
    /// </summary>
    public void Convert(Image.Format format)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), (int)format);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMipmapCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of mipmap levels or 0 if the image has no mipmaps. The largest main level image is not counted as a mipmap level by this method, so if you want to include it you can add 1 to this count.</para>
    /// </summary>
    public int GetMipmapCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMipmapOffset, 923996154ul);

    /// <summary>
    /// <para>Returns the offset where the image's mipmap with index <paramref name="mipmap"/> is stored in the <see cref="Godot.Image.Data"/> dictionary.</para>
    /// </summary>
    public long GetMipmapOffset(int mipmap)
    {
        return NativeCalls.godot_icall_1_611(MethodBind9, GodotObject.GetPtr(this), mipmap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResizeToPo2, 4189212329ul);

    /// <summary>
    /// <para>Resizes the image to the nearest power of 2 for the width and height. If <paramref name="square"/> is <see langword="true"/>, sets width and height to be the same. New pixels are calculated using the <paramref name="interpolation"/> mode defined via <see cref="Godot.Image.Interpolation"/> constants.</para>
    /// </summary>
    public void ResizeToPo2(bool square = false, Image.Interpolation interpolation = (Image.Interpolation)(1))
    {
        NativeCalls.godot_icall_2_417(MethodBind10, GodotObject.GetPtr(this), square.ToGodotBool(), (int)interpolation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Resize, 994498151ul);

    /// <summary>
    /// <para>Resizes the image to the given <paramref name="width"/> and <paramref name="height"/>. New pixels are calculated using the <paramref name="interpolation"/> mode defined via <see cref="Godot.Image.Interpolation"/> constants.</para>
    /// </summary>
    public void Resize(int width, int height, Image.Interpolation interpolation = (Image.Interpolation)(1))
    {
        NativeCalls.godot_icall_3_196(MethodBind11, GodotObject.GetPtr(this), width, height, (int)interpolation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShrinkX2, 3218959716ul);

    /// <summary>
    /// <para>Shrinks the image by a factor of 2 on each axis (this divides the pixel count by 4).</para>
    /// </summary>
    public void ShrinkX2()
    {
        NativeCalls.godot_icall_0_3(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Crop, 3937882851ul);

    /// <summary>
    /// <para>Crops the image to the given <paramref name="width"/> and <paramref name="height"/>. If the specified size is larger than the current size, the extra area is filled with black pixels.</para>
    /// </summary>
    public void Crop(int width, int height)
    {
        NativeCalls.godot_icall_2_59(MethodBind13, GodotObject.GetPtr(this), width, height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FlipX, 3218959716ul);

    /// <summary>
    /// <para>Flips the image horizontally.</para>
    /// </summary>
    public void FlipX()
    {
        NativeCalls.godot_icall_0_3(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FlipY, 3218959716ul);

    /// <summary>
    /// <para>Flips the image vertically.</para>
    /// </summary>
    public void FlipY()
    {
        NativeCalls.godot_icall_0_3(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateMipmaps, 1633102583ul);

    /// <summary>
    /// <para>Generates mipmaps for the image. Mipmaps are precalculated lower-resolution copies of the image that are automatically used if the image needs to be scaled down when rendered. They help improve image quality and performance when rendering. This method returns an error if the image is compressed, in a custom format, or if the image's width/height is <c>0</c>. Enabling <paramref name="renormalize"/> when generating mipmaps for normal map textures will make sure all resulting vector values are normalized.</para>
    /// <para>It is possible to check if the image has mipmaps by calling <see cref="Godot.Image.HasMipmaps()"/> or <see cref="Godot.Image.GetMipmapCount()"/>. Calling <see cref="Godot.Image.GenerateMipmaps(bool)"/> on an image that already has mipmaps will replace existing mipmaps in the image.</para>
    /// </summary>
    public Error GenerateMipmaps(bool renormalize = false)
    {
        return (Error)NativeCalls.godot_icall_1_198(MethodBind16, GodotObject.GetPtr(this), renormalize.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearMipmaps, 3218959716ul);

    /// <summary>
    /// <para>Removes the image's mipmaps.</para>
    /// </summary>
    public void ClearMipmaps()
    {
        NativeCalls.godot_icall_0_3(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Create, 986942177ul);

    /// <summary>
    /// <para>Creates an empty image of the given size and format. If <paramref name="useMipmaps"/> is <see langword="true"/>, generates mipmaps for this image (see <see cref="Godot.Image.GenerateMipmaps(bool)"/>).</para>
    /// </summary>
    [Obsolete("Use 'Godot.Image.CreateEmpty(int, int, bool, Image.Format)'.")]
    public static Image Create(int width, int height, bool useMipmaps, Image.Format format)
    {
        return (Image)NativeCalls.godot_icall_4_722(MethodBind18, width, height, useMipmaps.ToGodotBool(), (int)format);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateEmpty, 986942177ul);

    /// <summary>
    /// <para>Creates an empty image of the given size and format. If <paramref name="useMipmaps"/> is <see langword="true"/>, generates mipmaps for this image (see <see cref="Godot.Image.GenerateMipmaps(bool)"/>).</para>
    /// </summary>
    public static Image CreateEmpty(int width, int height, bool useMipmaps, Image.Format format)
    {
        return (Image)NativeCalls.godot_icall_4_722(MethodBind19, width, height, useMipmaps.ToGodotBool(), (int)format);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromData, 299398494ul);

    /// <summary>
    /// <para>Creates a new image of the given size and format. Fills the image with the given raw data. If <paramref name="useMipmaps"/> is <see langword="true"/>, loads the mipmaps for this image from <paramref name="data"/>. See <see cref="Godot.Image.GenerateMipmaps(bool)"/>.</para>
    /// </summary>
    public static Image CreateFromData(int width, int height, bool useMipmaps, Image.Format format, byte[] data)
    {
        return (Image)NativeCalls.godot_icall_5_723(MethodBind20, width, height, useMipmaps.ToGodotBool(), (int)format, data);
    }

    /// <summary>
    /// <para>Creates a new image of the given size and format. Fills the image with the given raw data. If <paramref name="useMipmaps"/> is <see langword="true"/>, loads the mipmaps for this image from <paramref name="data"/>. See <see cref="Godot.Image.GenerateMipmaps(bool)"/>.</para>
    /// </summary>
    public static Image CreateFromData(int width, int height, bool useMipmaps, Image.Format format, ReadOnlySpan<byte> data)
    {
        return (Image)NativeCalls.godot_icall_5_723(MethodBind20, width, height, useMipmaps.ToGodotBool(), (int)format, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetData, 2740482212ul);

    /// <summary>
    /// <para>Overwrites data of an existing <see cref="Godot.Image"/>. Non-static equivalent of <see cref="Godot.Image.CreateFromData(int, int, bool, Image.Format, byte[])"/>.</para>
    /// </summary>
    public void SetData(int width, int height, bool useMipmaps, Image.Format format, byte[] data)
    {
        NativeCalls.godot_icall_5_724(MethodBind21, GodotObject.GetPtr(this), width, height, useMipmaps.ToGodotBool(), (int)format, data);
    }

    /// <summary>
    /// <para>Overwrites data of an existing <see cref="Godot.Image"/>. Non-static equivalent of <see cref="Godot.Image.CreateFromData(int, int, bool, Image.Format, byte[])"/>.</para>
    /// </summary>
    public void SetData(int width, int height, bool useMipmaps, Image.Format format, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_5_724(MethodBind21, GodotObject.GetPtr(this), width, height, useMipmaps.ToGodotBool(), (int)format, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmpty, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the image has no data.</para>
    /// </summary>
    public bool IsEmpty()
    {
        return NativeCalls.godot_icall_0_15(MethodBind22, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Load, 166001499ul);

    /// <summary>
    /// <para>Loads an image from file <paramref name="path"/>. See <a href="$DOCS_URL/tutorials/assets_pipeline/importing_images.html#supported-image-formats">Supported image formats</a> for a list of supported image formats and limitations.</para>
    /// <para><b>Warning:</b> This method should only be used in the editor or in cases when you need to load external images at run-time, such as images located at the <c>user://</c> directory, and may not work in exported projects.</para>
    /// <para>See also <see cref="Godot.ImageTexture"/> description for usage examples.</para>
    /// </summary>
    public Error Load(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind23, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromFile, 736337515ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.Image"/> and loads data from the specified file.</para>
    /// </summary>
    public static Image LoadFromFile(string path)
    {
        return (Image)NativeCalls.godot_icall_1_203(MethodBind24, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SavePng, 2113323047ul);

    /// <summary>
    /// <para>Saves the image as a PNG file to the file at <paramref name="path"/>.</para>
    /// </summary>
    public Error SavePng(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind25, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SavePngToBuffer, 2362200018ul);

    /// <summary>
    /// <para>Saves the image as a PNG file to a byte array.</para>
    /// </summary>
    public byte[] SavePngToBuffer()
    {
        return NativeCalls.godot_icall_0_2(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveJpg, 2800019068ul);

    /// <summary>
    /// <para>Saves the image as a JPEG file to <paramref name="path"/> with the specified <paramref name="quality"/> between <c>0.01</c> and <c>1.0</c> (inclusive). Higher <paramref name="quality"/> values result in better-looking output at the cost of larger file sizes. Recommended <paramref name="quality"/> values are between <c>0.75</c> and <c>0.90</c>. Even at quality <c>1.00</c>, JPEG compression remains lossy.</para>
    /// <para><b>Note:</b> JPEG does not save an alpha channel. If the <see cref="Godot.Image"/> contains an alpha channel, the image will still be saved, but the resulting JPEG file won't contain the alpha channel.</para>
    /// </summary>
    public Error SaveJpg(string path, float quality = 0.75f)
    {
        return (Error)NativeCalls.godot_icall_2_725(MethodBind27, GodotObject.GetPtr(this), path, quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveJpgToBuffer, 592235273ul);

    /// <summary>
    /// <para>Saves the image as a JPEG file to a byte array with the specified <paramref name="quality"/> between <c>0.01</c> and <c>1.0</c> (inclusive). Higher <paramref name="quality"/> values result in better-looking output at the cost of larger byte array sizes (and therefore memory usage). Recommended <paramref name="quality"/> values are between <c>0.75</c> and <c>0.90</c>. Even at quality <c>1.00</c>, JPEG compression remains lossy.</para>
    /// <para><b>Note:</b> JPEG does not save an alpha channel. If the <see cref="Godot.Image"/> contains an alpha channel, the image will still be saved, but the resulting byte array won't contain the alpha channel.</para>
    /// </summary>
    public byte[] SaveJpgToBuffer(float quality = 0.75f)
    {
        return NativeCalls.godot_icall_1_726(MethodBind28, GodotObject.GetPtr(this), quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveExr, 3108122999ul);

    /// <summary>
    /// <para>Saves the image as an EXR file to <paramref name="path"/>. If <paramref name="grayscale"/> is <see langword="true"/> and the image has only one channel, it will be saved explicitly as monochrome rather than one red channel. This function will return <see cref="Godot.Error.Unavailable"/> if Godot was compiled without the TinyEXR module.</para>
    /// </summary>
    public Error SaveExr(string path, bool grayscale = false)
    {
        return (Error)NativeCalls.godot_icall_2_350(MethodBind29, GodotObject.GetPtr(this), path, grayscale.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveExrToBuffer, 3178917920ul);

    /// <summary>
    /// <para>Saves the image as an EXR file to a byte array. If <paramref name="grayscale"/> is <see langword="true"/> and the image has only one channel, it will be saved explicitly as monochrome rather than one red channel. This function will return an empty byte array if Godot was compiled without the TinyEXR module.</para>
    /// </summary>
    public byte[] SaveExrToBuffer(bool grayscale = false)
    {
        return NativeCalls.godot_icall_1_727(MethodBind30, GodotObject.GetPtr(this), grayscale.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveDds, 2113323047ul);

    /// <summary>
    /// <para>Saves the image as a DDS (DirectDraw Surface) file to <paramref name="path"/>. DDS is a container format that can store textures in various compression formats, such as DXT1, DXT5, or BC7. This function will return <see cref="Godot.Error.Unavailable"/> if Godot was compiled without the DDS module.</para>
    /// <para><b>Note:</b> The DDS module may be disabled in certain builds, which means <see cref="Godot.Image.SaveDds(string)"/> will return <see cref="Godot.Error.Unavailable"/> when it is called from an exported project.</para>
    /// </summary>
    public Error SaveDds(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind31, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveDdsToBuffer, 2362200018ul);

    /// <summary>
    /// <para>Saves the image as a DDS (DirectDraw Surface) file to a byte array. DDS is a container format that can store textures in various compression formats, such as DXT1, DXT5, or BC7. This function will return an empty byte array if Godot was compiled without the DDS module.</para>
    /// <para><b>Note:</b> The DDS module may be disabled in certain builds, which means <see cref="Godot.Image.SaveDdsToBuffer()"/> will return an empty byte array when it is called from an exported project.</para>
    /// </summary>
    public byte[] SaveDdsToBuffer()
    {
        return NativeCalls.godot_icall_0_2(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveWebp, 2781156876ul);

    /// <summary>
    /// <para>Saves the image as a WebP (Web Picture) file to the file at <paramref name="path"/>. By default it will save lossless. If <paramref name="lossy"/> is <see langword="true"/>, the image will be saved lossy, using the <paramref name="quality"/> setting between <c>0.0</c> and <c>1.0</c> (inclusive). Lossless WebP offers more efficient compression than PNG.</para>
    /// <para><b>Note:</b> The WebP format is limited to a size of 16383×16383 pixels, while PNG can save larger images.</para>
    /// </summary>
    public Error SaveWebp(string path, bool lossy = false, float quality = 0.75f)
    {
        return (Error)NativeCalls.godot_icall_3_728(MethodBind33, GodotObject.GetPtr(this), path, lossy.ToGodotBool(), quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveWebpToBuffer, 1214628238ul);

    /// <summary>
    /// <para>Saves the image as a WebP (Web Picture) file to a byte array. By default it will save lossless. If <paramref name="lossy"/> is <see langword="true"/>, the image will be saved lossy, using the <paramref name="quality"/> setting between <c>0.0</c> and <c>1.0</c> (inclusive). Lossless WebP offers more efficient compression than PNG.</para>
    /// <para><b>Note:</b> The WebP format is limited to a size of 16383×16383 pixels, while PNG can save larger images.</para>
    /// </summary>
    public byte[] SaveWebpToBuffer(bool lossy = false, float quality = 0.75f)
    {
        return NativeCalls.godot_icall_2_729(MethodBind34, GodotObject.GetPtr(this), lossy.ToGodotBool(), quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DetectAlpha, 2030116505ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.Image.AlphaMode.Blend"/> if the image has data for alpha values. Returns <see cref="Godot.Image.AlphaMode.Bit"/> if all the alpha values are stored in a single bit. Returns <see cref="Godot.Image.AlphaMode.None"/> if no data for alpha values is found.</para>
    /// </summary>
    public Image.AlphaMode DetectAlpha()
    {
        return (Image.AlphaMode)NativeCalls.godot_icall_0_39(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInvisible, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if all the image's pixels have an alpha value of 0. Returns <see langword="false"/> if any pixel has an alpha value higher than 0.</para>
    /// </summary>
    public bool IsInvisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind36, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DetectUsedChannels, 2703139984ul);

    /// <summary>
    /// <para>Returns the color channels used by this image. If the image is compressed, the original <paramref name="source"/> must be specified.</para>
    /// </summary>
    public Image.UsedChannels DetectUsedChannels(Image.CompressSource source = (Image.CompressSource)(0))
    {
        return (Image.UsedChannels)NativeCalls.godot_icall_1_60(MethodBind37, GodotObject.GetPtr(this), (int)source);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Compress, 2975424957ul);

    /// <summary>
    /// <para>Compresses the image with a VRAM-compressed format to use less memory. Can not directly access pixel data while the image is compressed. Returns error if the chosen compression mode is not available.</para>
    /// <para>The <paramref name="source"/> parameter helps to pick the best compression method for DXT and ETC2 formats. It is ignored for ASTC compression.</para>
    /// <para>The <paramref name="astcFormat"/> parameter is only taken into account when using ASTC compression; it is ignored for all other formats.</para>
    /// <para><b>Note:</b> <see cref="Godot.Image.Compress(Image.CompressMode, Image.CompressSource, Image.AstcFormat)"/> is only supported in editor builds. When run in an exported project, this method always returns <see cref="Godot.Error.Unavailable"/>.</para>
    /// </summary>
    public Error Compress(Image.CompressMode mode, Image.CompressSource source = (Image.CompressSource)(0), Image.AstcFormat astcFormat = (Image.AstcFormat)(0))
    {
        return (Error)NativeCalls.godot_icall_3_730(MethodBind38, GodotObject.GetPtr(this), (int)mode, (int)source, (int)astcFormat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CompressFromChannels, 4212890953ul);

    /// <summary>
    /// <para>Compresses the image with a VRAM-compressed format to use less memory. Can not directly access pixel data while the image is compressed. Returns error if the chosen compression mode is not available.</para>
    /// <para>This is an alternative to <see cref="Godot.Image.Compress(Image.CompressMode, Image.CompressSource, Image.AstcFormat)"/> that lets the user supply the channels used in order for the compressor to pick the best DXT and ETC2 formats. For other formats (non DXT or ETC2), this argument is ignored.</para>
    /// <para>The <paramref name="astcFormat"/> parameter is only taken into account when using ASTC compression; it is ignored for all other formats.</para>
    /// <para><b>Note:</b> <see cref="Godot.Image.CompressFromChannels(Image.CompressMode, Image.UsedChannels, Image.AstcFormat)"/> is only supported in editor builds. When run in an exported project, this method always returns <see cref="Godot.Error.Unavailable"/>.</para>
    /// </summary>
    public Error CompressFromChannels(Image.CompressMode mode, Image.UsedChannels channels, Image.AstcFormat astcFormat = (Image.AstcFormat)(0))
    {
        return (Error)NativeCalls.godot_icall_3_730(MethodBind39, GodotObject.GetPtr(this), (int)mode, (int)channels, (int)astcFormat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Decompress, 166280745ul);

    /// <summary>
    /// <para>Decompresses the image if it is VRAM-compressed in a supported format. This increases memory utilization, but allows modifying the image. Returns <see cref="Godot.Error.Ok"/> if the format is supported, otherwise <see cref="Godot.Error.Unavailable"/>. All VRAM-compressed formats supported by Godot can be decompressed with this method, except <see cref="Godot.Image.Format.Etc2R11S"/>, <see cref="Godot.Image.Format.Etc2Rg11S"/>, and <see cref="Godot.Image.Format.Etc2Rgb8A1"/>.</para>
    /// </summary>
    public Error Decompress()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCompressed, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the image is compressed.</para>
    /// </summary>
    public bool IsCompressed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind41, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Rotate90, 1901204267ul);

    /// <summary>
    /// <para>Rotates the image in the specified <paramref name="direction"/> by <c>90</c> degrees. The width and height of the image must be greater than <c>1</c>. If the width and height are not equal, the image will be resized.</para>
    /// </summary>
    public void Rotate90(ClockDirection direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind42, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Rotate180, 3218959716ul);

    /// <summary>
    /// <para>Rotates the image by <c>180</c> degrees. The width and height of the image must be greater than <c>1</c>.</para>
    /// </summary>
    public void Rotate180()
    {
        NativeCalls.godot_icall_0_3(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FixAlphaEdges, 3218959716ul);

    /// <summary>
    /// <para>Blends low-alpha pixels with nearby pixels.</para>
    /// </summary>
    public void FixAlphaEdges()
    {
        NativeCalls.godot_icall_0_3(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PremultiplyAlpha, 3218959716ul);

    /// <summary>
    /// <para>Multiplies color values with alpha values. Resulting color values for a pixel are <c>(color * alpha)/256</c>. See also <see cref="Godot.CanvasItemMaterial.BlendMode"/>.</para>
    /// </summary>
    public void PremultiplyAlpha()
    {
        NativeCalls.godot_icall_0_3(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SrgbToLinear, 3218959716ul);

    /// <summary>
    /// <para>Converts the raw data from nonlinear sRGB encoding to linear encoding using a lookup table. Only works on images with <see cref="Godot.Image.Format.Rgb8"/> or <see cref="Godot.Image.Format.Rgba8"/> formats.</para>
    /// <para><b>Note:</b> The 8-bit formats required by this method are not suitable for storing linearly encoded values; a significant amount of color information will be lost in darker values. To maintain image quality, this method should not be used.</para>
    /// </summary>
    public void SrgbToLinear()
    {
        NativeCalls.godot_icall_0_3(MethodBind46, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LinearToSrgb, 3218959716ul);

    /// <summary>
    /// <para>Converts the entire image from linear encoding to nonlinear sRGB encoding by using a lookup table. Only works on images with <see cref="Godot.Image.Format.Rgb8"/> or <see cref="Godot.Image.Format.Rgba8"/> formats.</para>
    /// </summary>
    public void LinearToSrgb()
    {
        NativeCalls.godot_icall_0_3(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NormalMapToXy, 3218959716ul);

    /// <summary>
    /// <para>Converts the image's data to represent coordinates on a 3D plane. This is used when the image represents a normal map. A normal map can add lots of detail to a 3D surface without increasing the polygon count.</para>
    /// </summary>
    public void NormalMapToXy()
    {
        NativeCalls.godot_icall_0_3(MethodBind48, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RgbeToSrgb, 564927088ul);

    /// <summary>
    /// <para>Converts a standard linear RGBE (Red Green Blue Exponent) image to an image that uses nonlinear sRGB encoding.</para>
    /// </summary>
    public Image RgbeToSrgb()
    {
        return (Image)NativeCalls.godot_icall_0_63(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BumpMapToNormalMap, 3423495036ul);

    /// <summary>
    /// <para>Converts a bump map to a normal map. A bump map provides a height offset per-pixel, while a normal map provides a normal direction per pixel.</para>
    /// </summary>
    public void BumpMapToNormalMap(float bumpScale = 1.0f)
    {
        NativeCalls.godot_icall_1_67(MethodBind50, GodotObject.GetPtr(this), bumpScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ComputeImageMetrics, 3080961247ul);

    /// <summary>
    /// <para>Compute image metrics on the current image and the compared image. This can be used to calculate the similarity between two images.</para>
    /// <para>The dictionary contains <c>max</c>, <c>mean</c>, <c>mean_squared</c>, <c>root_mean_squared</c> and <c>peak_snr</c>.</para>
    /// </summary>
    public Godot.Collections.Dictionary ComputeImageMetrics(Image comparedImage, bool useLuma)
    {
        return NativeCalls.godot_icall_2_482(MethodBind51, GodotObject.GetPtr(this), GodotObject.GetPtr(comparedImage), useLuma.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BlitRect, 2903928755ul);

    /// <summary>
    /// <para>Copies <paramref name="srcRect"/> from <paramref name="src"/> image to this image at coordinates <paramref name="dst"/>, clipped accordingly to both image bounds. This image and <paramref name="src"/> image <b>must</b> have the same format. <paramref name="srcRect"/> with non-positive size is treated as empty.</para>
    /// <para><b>Note:</b> The alpha channel data in <paramref name="src"/> will overwrite the corresponding data in this image at the target position. To blend alpha channels, use <see cref="Godot.Image.BlendRect(Image, Rect2I, Vector2I)"/> instead.</para>
    /// </summary>
    public unsafe void BlitRect(Image src, Rect2I srcRect, Vector2I dst)
    {
        NativeCalls.godot_icall_3_731(MethodBind52, GodotObject.GetPtr(this), GodotObject.GetPtr(src), &srcRect, &dst);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BlitRectMask, 3383581145ul);

    /// <summary>
    /// <para>Blits <paramref name="srcRect"/> area from <paramref name="src"/> image to this image at the coordinates given by <paramref name="dst"/>, clipped accordingly to both image bounds. <paramref name="src"/> pixel is copied onto <paramref name="dst"/> if the corresponding <paramref name="mask"/> pixel's alpha value is not 0. This image and <paramref name="src"/> image <b>must</b> have the same format. <paramref name="src"/> image and <paramref name="mask"/> image <b>must</b> have the same size (width and height) but they can have different formats. <paramref name="srcRect"/> with non-positive size is treated as empty.</para>
    /// </summary>
    public unsafe void BlitRectMask(Image src, Image mask, Rect2I srcRect, Vector2I dst)
    {
        NativeCalls.godot_icall_4_732(MethodBind53, GodotObject.GetPtr(this), GodotObject.GetPtr(src), GodotObject.GetPtr(mask), &srcRect, &dst);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BlendRect, 2903928755ul);

    /// <summary>
    /// <para>Alpha-blends <paramref name="srcRect"/> from <paramref name="src"/> image to this image at coordinates <paramref name="dst"/>, clipped accordingly to both image bounds. This image and <paramref name="src"/> image <b>must</b> have the same format. <paramref name="srcRect"/> with non-positive size is treated as empty.</para>
    /// </summary>
    public unsafe void BlendRect(Image src, Rect2I srcRect, Vector2I dst)
    {
        NativeCalls.godot_icall_3_731(MethodBind54, GodotObject.GetPtr(this), GodotObject.GetPtr(src), &srcRect, &dst);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BlendRectMask, 3383581145ul);

    /// <summary>
    /// <para>Alpha-blends <paramref name="srcRect"/> from <paramref name="src"/> image to this image using <paramref name="mask"/> image at coordinates <paramref name="dst"/>, clipped accordingly to both image bounds. Alpha channels are required for both <paramref name="src"/> and <paramref name="mask"/>. <paramref name="dst"/> pixels and <paramref name="src"/> pixels will blend if the corresponding mask pixel's alpha value is not 0. This image and <paramref name="src"/> image <b>must</b> have the same format. <paramref name="src"/> image and <paramref name="mask"/> image <b>must</b> have the same size (width and height) but they can have different formats. <paramref name="srcRect"/> with non-positive size is treated as empty.</para>
    /// </summary>
    public unsafe void BlendRectMask(Image src, Image mask, Rect2I srcRect, Vector2I dst)
    {
        NativeCalls.godot_icall_4_732(MethodBind55, GodotObject.GetPtr(this), GodotObject.GetPtr(src), GodotObject.GetPtr(mask), &srcRect, &dst);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Fill, 2920490490ul);

    /// <summary>
    /// <para>Fills the image with <paramref name="color"/>.</para>
    /// </summary>
    public unsafe void Fill(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind56, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FillRect, 514693913ul);

    /// <summary>
    /// <para>Fills <paramref name="rect"/> with <paramref name="color"/>.</para>
    /// </summary>
    public unsafe void FillRect(Rect2I rect, Color color)
    {
        NativeCalls.godot_icall_2_733(MethodBind57, GodotObject.GetPtr(this), &rect, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUsedRect, 410525958ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Rect2I"/> enclosing the visible portion of the image, considering each pixel with a non-zero alpha channel as visible.</para>
    /// </summary>
    public Rect2I GetUsedRect()
    {
        return NativeCalls.godot_icall_0_33(MethodBind58, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRegion, 2601441065ul);

    /// <summary>
    /// <para>Returns a new <see cref="Godot.Image"/> that is a copy of this <see cref="Godot.Image"/>'s area specified with <paramref name="region"/>.</para>
    /// </summary>
    public unsafe Image GetRegion(Rect2I region)
    {
        return (Image)NativeCalls.godot_icall_1_408(MethodBind59, GodotObject.GetPtr(this), &region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CopyFrom, 532598488ul);

    /// <summary>
    /// <para>Copies <paramref name="src"/> image to this image.</para>
    /// </summary>
    public void CopyFrom(Image src)
    {
        NativeCalls.godot_icall_1_56(MethodBind60, GodotObject.GetPtr(this), GodotObject.GetPtr(src));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetData, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void _SetData(Godot.Collections.Dictionary data)
    {
        NativeCalls.godot_icall_1_121(MethodBind61, GodotObject.GetPtr(this), (godot_dictionary)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetData, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal Godot.Collections.Dictionary _GetData()
    {
        return NativeCalls.godot_icall_0_122(MethodBind62, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPixelv, 1532707496ul);

    /// <summary>
    /// <para>Returns the color of the pixel at <paramref name="point"/>.</para>
    /// <para>This is the same as <see cref="Godot.Image.GetPixel(int, int)"/>, but with a <see cref="Godot.Vector2I"/> argument instead of two integer arguments.</para>
    /// </summary>
    public unsafe Color GetPixelv(Vector2I point)
    {
        return NativeCalls.godot_icall_1_407(MethodBind63, GodotObject.GetPtr(this), &point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPixel, 2165839948ul);

    /// <summary>
    /// <para>Returns the color of the pixel at <c>(x, y)</c>.</para>
    /// <para>This is the same as <see cref="Godot.Image.GetPixelv(Vector2I)"/>, but with two integer arguments instead of a <see cref="Godot.Vector2I"/> argument.</para>
    /// </summary>
    public Color GetPixel(int x, int y)
    {
        return NativeCalls.godot_icall_2_734(MethodBind64, GodotObject.GetPtr(this), x, y);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPixelv, 287851464ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Color"/> of the pixel at <paramref name="point"/> to <paramref name="color"/>.</para>
    /// <para><code>
    /// int imgWidth = 10;
    /// int imgHeight = 5;
    /// var img = Image.Create(imgWidth, imgHeight, false, Image.Format.Rgba8);
    /// 
    /// img.SetPixelv(new Vector2I(1, 2), Colors.Red); // Sets the color at (1, 2) to red.
    /// </code></para>
    /// <para>This is the same as <see cref="Godot.Image.SetPixel(int, int, Color)"/>, but with a <see cref="Godot.Vector2I"/> argument instead of two integer arguments.</para>
    /// <para><b>Note:</b> Depending on the image's format, the color set here may be clamped or lose precision. Do not assume the color returned by <see cref="Godot.Image.GetPixelv(Vector2I)"/> to be identical to the one set here; any comparisons will likely need to use an approximation like <c>Color.is_equal_approx</c>.</para>
    /// <para><b>Note:</b> On grayscale image formats, only the red channel of <paramref name="color"/> is used (and alpha if relevant). The green and blue channels are ignored.</para>
    /// </summary>
    public unsafe void SetPixelv(Vector2I point, Color color)
    {
        NativeCalls.godot_icall_2_735(MethodBind65, GodotObject.GetPtr(this), &point, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPixel, 3733378741ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Color"/> of the pixel at <c>(x, y)</c> to <paramref name="color"/>.</para>
    /// <para><code>
    /// int imgWidth = 10;
    /// int imgHeight = 5;
    /// var img = Image.Create(imgWidth, imgHeight, false, Image.Format.Rgba8);
    /// 
    /// img.SetPixel(1, 2, Colors.Red); // Sets the color at (1, 2) to red.
    /// </code></para>
    /// <para>This is the same as <see cref="Godot.Image.SetPixelv(Vector2I, Color)"/>, but with a two integer arguments instead of a <see cref="Godot.Vector2I"/> argument.</para>
    /// <para><b>Note:</b> Depending on the image's format, the color set here may be clamped or lose precision. Do not assume the color returned by <see cref="Godot.Image.GetPixel(int, int)"/> to be identical to the one set here; any comparisons will likely need to use an approximation like <c>Color.is_equal_approx</c>.</para>
    /// <para><b>Note:</b> On grayscale image formats, only the red channel of <paramref name="color"/> is used (and alpha if relevant). The green and blue channels are ignored.</para>
    /// </summary>
    public unsafe void SetPixel(int x, int y, Color color)
    {
        NativeCalls.godot_icall_3_736(MethodBind66, GodotObject.GetPtr(this), x, y, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AdjustBcs, 2385087082ul);

    /// <summary>
    /// <para>Adjusts this image's <paramref name="brightness"/>, <paramref name="contrast"/>, and <paramref name="saturation"/> by the given values. Does not work if the image is compressed (see <see cref="Godot.Image.IsCompressed()"/>).</para>
    /// </summary>
    public void AdjustBcs(float brightness, float contrast, float saturation)
    {
        NativeCalls.godot_icall_3_235(MethodBind67, GodotObject.GetPtr(this), brightness, contrast, saturation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadPngFromBuffer, 680677267ul);

    /// <summary>
    /// <para>Loads an image from the binary contents of a PNG file.</para>
    /// </summary>
    public Error LoadPngFromBuffer(byte[] buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind68, GodotObject.GetPtr(this), buffer);
    }

    /// <summary>
    /// <para>Loads an image from the binary contents of a PNG file.</para>
    /// </summary>
    public Error LoadPngFromBuffer(ReadOnlySpan<byte> buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind68, GodotObject.GetPtr(this), buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadJpgFromBuffer, 680677267ul);

    /// <summary>
    /// <para>Loads an image from the binary contents of a JPEG file.</para>
    /// </summary>
    public Error LoadJpgFromBuffer(byte[] buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind69, GodotObject.GetPtr(this), buffer);
    }

    /// <summary>
    /// <para>Loads an image from the binary contents of a JPEG file.</para>
    /// </summary>
    public Error LoadJpgFromBuffer(ReadOnlySpan<byte> buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind69, GodotObject.GetPtr(this), buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadWebpFromBuffer, 680677267ul);

    /// <summary>
    /// <para>Loads an image from the binary contents of a WebP file.</para>
    /// </summary>
    public Error LoadWebpFromBuffer(byte[] buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind70, GodotObject.GetPtr(this), buffer);
    }

    /// <summary>
    /// <para>Loads an image from the binary contents of a WebP file.</para>
    /// </summary>
    public Error LoadWebpFromBuffer(ReadOnlySpan<byte> buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind70, GodotObject.GetPtr(this), buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadTgaFromBuffer, 680677267ul);

    /// <summary>
    /// <para>Loads an image from the binary contents of a TGA file.</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the TGA module enabled. By default, the TGA module is enabled, but it can be disabled at build-time using the <c>module_tga_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadTgaFromBuffer(byte[] buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind71, GodotObject.GetPtr(this), buffer);
    }

    /// <summary>
    /// <para>Loads an image from the binary contents of a TGA file.</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the TGA module enabled. By default, the TGA module is enabled, but it can be disabled at build-time using the <c>module_tga_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadTgaFromBuffer(ReadOnlySpan<byte> buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind71, GodotObject.GetPtr(this), buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadBmpFromBuffer, 680677267ul);

    /// <summary>
    /// <para>Loads an image from the binary contents of a BMP file.</para>
    /// <para><b>Note:</b> Godot's BMP module doesn't support 16-bit per pixel images. Only 1-bit, 4-bit, 8-bit, 24-bit, and 32-bit per pixel images are supported.</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the BMP module enabled. By default, the BMP module is enabled, but it can be disabled at build-time using the <c>module_bmp_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadBmpFromBuffer(byte[] buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind72, GodotObject.GetPtr(this), buffer);
    }

    /// <summary>
    /// <para>Loads an image from the binary contents of a BMP file.</para>
    /// <para><b>Note:</b> Godot's BMP module doesn't support 16-bit per pixel images. Only 1-bit, 4-bit, 8-bit, 24-bit, and 32-bit per pixel images are supported.</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the BMP module enabled. By default, the BMP module is enabled, but it can be disabled at build-time using the <c>module_bmp_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadBmpFromBuffer(ReadOnlySpan<byte> buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind72, GodotObject.GetPtr(this), buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadKtxFromBuffer, 680677267ul);

    /// <summary>
    /// <para>Loads an image from the binary contents of a <a href="https://github.com/KhronosGroup/KTX-Software">KTX</a> file. Unlike most image formats, KTX can store VRAM-compressed data and embed mipmaps.</para>
    /// <para><b>Note:</b> Godot's libktx implementation only supports 2D images. Cubemaps, texture arrays, and de-padding are not supported.</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the KTX module enabled. By default, the KTX module is enabled, but it can be disabled at build-time using the <c>module_ktx_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadKtxFromBuffer(byte[] buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind73, GodotObject.GetPtr(this), buffer);
    }

    /// <summary>
    /// <para>Loads an image from the binary contents of a <a href="https://github.com/KhronosGroup/KTX-Software">KTX</a> file. Unlike most image formats, KTX can store VRAM-compressed data and embed mipmaps.</para>
    /// <para><b>Note:</b> Godot's libktx implementation only supports 2D images. Cubemaps, texture arrays, and de-padding are not supported.</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the KTX module enabled. By default, the KTX module is enabled, but it can be disabled at build-time using the <c>module_ktx_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadKtxFromBuffer(ReadOnlySpan<byte> buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind73, GodotObject.GetPtr(this), buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadDdsFromBuffer, 680677267ul);

    /// <summary>
    /// <para>Loads an image from the binary contents of a DDS file.</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the DDS module enabled. By default, the DDS module is enabled, but it can be disabled at build-time using the <c>module_dds_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadDdsFromBuffer(byte[] buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind74, GodotObject.GetPtr(this), buffer);
    }

    /// <summary>
    /// <para>Loads an image from the binary contents of a DDS file.</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the DDS module enabled. By default, the DDS module is enabled, but it can be disabled at build-time using the <c>module_dds_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadDdsFromBuffer(ReadOnlySpan<byte> buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind74, GodotObject.GetPtr(this), buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadExrFromBuffer, 680677267ul);

    /// <summary>
    /// <para>Loads an image from the binary contents of an OpenEXR file.</para>
    /// </summary>
    public Error LoadExrFromBuffer(byte[] buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind75, GodotObject.GetPtr(this), buffer);
    }

    /// <summary>
    /// <para>Loads an image from the binary contents of an OpenEXR file.</para>
    /// </summary>
    public Error LoadExrFromBuffer(ReadOnlySpan<byte> buffer)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind75, GodotObject.GetPtr(this), buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadSvgFromBuffer, 311853421ul);

    /// <summary>
    /// <para>Loads an image from the UTF-8 binary contents of an <b>uncompressed</b> SVG file (<b>.svg</b>).</para>
    /// <para><b>Note:</b> Beware when using compressed SVG files (like <b>.svgz</b>), they need to be <c>decompressed</c> before loading.</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the SVG module enabled. By default, the SVG module is enabled, but it can be disabled at build-time using the <c>module_svg_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadSvgFromBuffer(byte[] buffer, float scale = 1.0f)
    {
        return (Error)NativeCalls.godot_icall_2_737(MethodBind76, GodotObject.GetPtr(this), buffer, scale);
    }

    /// <summary>
    /// <para>Loads an image from the UTF-8 binary contents of an <b>uncompressed</b> SVG file (<b>.svg</b>).</para>
    /// <para><b>Note:</b> Beware when using compressed SVG files (like <b>.svgz</b>), they need to be <c>decompressed</c> before loading.</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the SVG module enabled. By default, the SVG module is enabled, but it can be disabled at build-time using the <c>module_svg_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadSvgFromBuffer(ReadOnlySpan<byte> buffer, float scale)
    {
        return (Error)NativeCalls.godot_icall_2_737(MethodBind76, GodotObject.GetPtr(this), buffer, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadSvgFromString, 3254053600ul);

    /// <summary>
    /// <para>Loads an image from the string contents of an SVG file (<b>.svg</b>).</para>
    /// <para><b>Note:</b> This method is only available in engine builds with the SVG module enabled. By default, the SVG module is enabled, but it can be disabled at build-time using the <c>module_svg_enabled=no</c> SCons option.</para>
    /// </summary>
    public Error LoadSvgFromString(string svgStr, float scale = 1.0f)
    {
        return (Error)NativeCalls.godot_icall_2_725(MethodBind77, GodotObject.GetPtr(this), svgStr, scale);
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
        /// Cached name for the 'get_width' method.
        /// </summary>
        public static readonly StringName GetWidth = "get_width";
        /// <summary>
        /// Cached name for the 'get_height' method.
        /// </summary>
        public static readonly StringName GetHeight = "get_height";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'has_mipmaps' method.
        /// </summary>
        public static readonly StringName HasMipmaps = "has_mipmaps";
        /// <summary>
        /// Cached name for the 'get_format' method.
        /// </summary>
        public static readonly StringName GetFormat = "get_format";
        /// <summary>
        /// Cached name for the 'get_data' method.
        /// </summary>
        public static readonly StringName GetData = "get_data";
        /// <summary>
        /// Cached name for the 'get_data_size' method.
        /// </summary>
        public static readonly StringName GetDataSize = "get_data_size";
        /// <summary>
        /// Cached name for the 'convert' method.
        /// </summary>
        public static readonly StringName Convert = "convert";
        /// <summary>
        /// Cached name for the 'get_mipmap_count' method.
        /// </summary>
        public static readonly StringName GetMipmapCount = "get_mipmap_count";
        /// <summary>
        /// Cached name for the 'get_mipmap_offset' method.
        /// </summary>
        public static readonly StringName GetMipmapOffset = "get_mipmap_offset";
        /// <summary>
        /// Cached name for the 'resize_to_po2' method.
        /// </summary>
        public static readonly StringName ResizeToPo2 = "resize_to_po2";
        /// <summary>
        /// Cached name for the 'resize' method.
        /// </summary>
        public static readonly StringName Resize = "resize";
        /// <summary>
        /// Cached name for the 'shrink_x2' method.
        /// </summary>
        public static readonly StringName ShrinkX2 = "shrink_x2";
        /// <summary>
        /// Cached name for the 'crop' method.
        /// </summary>
        public static readonly StringName Crop = "crop";
        /// <summary>
        /// Cached name for the 'flip_x' method.
        /// </summary>
        public static readonly StringName FlipX = "flip_x";
        /// <summary>
        /// Cached name for the 'flip_y' method.
        /// </summary>
        public static readonly StringName FlipY = "flip_y";
        /// <summary>
        /// Cached name for the 'generate_mipmaps' method.
        /// </summary>
        public static readonly StringName GenerateMipmaps = "generate_mipmaps";
        /// <summary>
        /// Cached name for the 'clear_mipmaps' method.
        /// </summary>
        public static readonly StringName ClearMipmaps = "clear_mipmaps";
        /// <summary>
        /// Cached name for the 'create' method.
        /// </summary>
        public static readonly StringName Create = "create";
        /// <summary>
        /// Cached name for the 'create_empty' method.
        /// </summary>
        public static readonly StringName CreateEmpty = "create_empty";
        /// <summary>
        /// Cached name for the 'create_from_data' method.
        /// </summary>
        public static readonly StringName CreateFromData = "create_from_data";
        /// <summary>
        /// Cached name for the 'set_data' method.
        /// </summary>
        public static readonly StringName SetData = "set_data";
        /// <summary>
        /// Cached name for the 'is_empty' method.
        /// </summary>
        public static readonly StringName IsEmpty = "is_empty";
        /// <summary>
        /// Cached name for the 'load' method.
        /// </summary>
        public static readonly StringName Load = "load";
        /// <summary>
        /// Cached name for the 'load_from_file' method.
        /// </summary>
        public static readonly StringName LoadFromFile = "load_from_file";
        /// <summary>
        /// Cached name for the 'save_png' method.
        /// </summary>
        public static readonly StringName SavePng = "save_png";
        /// <summary>
        /// Cached name for the 'save_png_to_buffer' method.
        /// </summary>
        public static readonly StringName SavePngToBuffer = "save_png_to_buffer";
        /// <summary>
        /// Cached name for the 'save_jpg' method.
        /// </summary>
        public static readonly StringName SaveJpg = "save_jpg";
        /// <summary>
        /// Cached name for the 'save_jpg_to_buffer' method.
        /// </summary>
        public static readonly StringName SaveJpgToBuffer = "save_jpg_to_buffer";
        /// <summary>
        /// Cached name for the 'save_exr' method.
        /// </summary>
        public static readonly StringName SaveExr = "save_exr";
        /// <summary>
        /// Cached name for the 'save_exr_to_buffer' method.
        /// </summary>
        public static readonly StringName SaveExrToBuffer = "save_exr_to_buffer";
        /// <summary>
        /// Cached name for the 'save_dds' method.
        /// </summary>
        public static readonly StringName SaveDds = "save_dds";
        /// <summary>
        /// Cached name for the 'save_dds_to_buffer' method.
        /// </summary>
        public static readonly StringName SaveDdsToBuffer = "save_dds_to_buffer";
        /// <summary>
        /// Cached name for the 'save_webp' method.
        /// </summary>
        public static readonly StringName SaveWebp = "save_webp";
        /// <summary>
        /// Cached name for the 'save_webp_to_buffer' method.
        /// </summary>
        public static readonly StringName SaveWebpToBuffer = "save_webp_to_buffer";
        /// <summary>
        /// Cached name for the 'detect_alpha' method.
        /// </summary>
        public static readonly StringName DetectAlpha = "detect_alpha";
        /// <summary>
        /// Cached name for the 'is_invisible' method.
        /// </summary>
        public static readonly StringName IsInvisible = "is_invisible";
        /// <summary>
        /// Cached name for the 'detect_used_channels' method.
        /// </summary>
        public static readonly StringName DetectUsedChannels = "detect_used_channels";
        /// <summary>
        /// Cached name for the 'compress' method.
        /// </summary>
        public static readonly StringName Compress = "compress";
        /// <summary>
        /// Cached name for the 'compress_from_channels' method.
        /// </summary>
        public static readonly StringName CompressFromChannels = "compress_from_channels";
        /// <summary>
        /// Cached name for the 'decompress' method.
        /// </summary>
        public static readonly StringName Decompress = "decompress";
        /// <summary>
        /// Cached name for the 'is_compressed' method.
        /// </summary>
        public static readonly StringName IsCompressed = "is_compressed";
        /// <summary>
        /// Cached name for the 'rotate_90' method.
        /// </summary>
        public static readonly StringName Rotate90 = "rotate_90";
        /// <summary>
        /// Cached name for the 'rotate_180' method.
        /// </summary>
        public static readonly StringName Rotate180 = "rotate_180";
        /// <summary>
        /// Cached name for the 'fix_alpha_edges' method.
        /// </summary>
        public static readonly StringName FixAlphaEdges = "fix_alpha_edges";
        /// <summary>
        /// Cached name for the 'premultiply_alpha' method.
        /// </summary>
        public static readonly StringName PremultiplyAlpha = "premultiply_alpha";
        /// <summary>
        /// Cached name for the 'srgb_to_linear' method.
        /// </summary>
        public static readonly StringName SrgbToLinear = "srgb_to_linear";
        /// <summary>
        /// Cached name for the 'linear_to_srgb' method.
        /// </summary>
        public static readonly StringName LinearToSrgb = "linear_to_srgb";
        /// <summary>
        /// Cached name for the 'normal_map_to_xy' method.
        /// </summary>
        public static readonly StringName NormalMapToXy = "normal_map_to_xy";
        /// <summary>
        /// Cached name for the 'rgbe_to_srgb' method.
        /// </summary>
        public static readonly StringName RgbeToSrgb = "rgbe_to_srgb";
        /// <summary>
        /// Cached name for the 'bump_map_to_normal_map' method.
        /// </summary>
        public static readonly StringName BumpMapToNormalMap = "bump_map_to_normal_map";
        /// <summary>
        /// Cached name for the 'compute_image_metrics' method.
        /// </summary>
        public static readonly StringName ComputeImageMetrics = "compute_image_metrics";
        /// <summary>
        /// Cached name for the 'blit_rect' method.
        /// </summary>
        public static readonly StringName BlitRect = "blit_rect";
        /// <summary>
        /// Cached name for the 'blit_rect_mask' method.
        /// </summary>
        public static readonly StringName BlitRectMask = "blit_rect_mask";
        /// <summary>
        /// Cached name for the 'blend_rect' method.
        /// </summary>
        public static readonly StringName BlendRect = "blend_rect";
        /// <summary>
        /// Cached name for the 'blend_rect_mask' method.
        /// </summary>
        public static readonly StringName BlendRectMask = "blend_rect_mask";
        /// <summary>
        /// Cached name for the 'fill' method.
        /// </summary>
        public static readonly StringName Fill = "fill";
        /// <summary>
        /// Cached name for the 'fill_rect' method.
        /// </summary>
        public static readonly StringName FillRect = "fill_rect";
        /// <summary>
        /// Cached name for the 'get_used_rect' method.
        /// </summary>
        public static readonly StringName GetUsedRect = "get_used_rect";
        /// <summary>
        /// Cached name for the 'get_region' method.
        /// </summary>
        public static readonly StringName GetRegion = "get_region";
        /// <summary>
        /// Cached name for the 'copy_from' method.
        /// </summary>
        public static readonly StringName CopyFrom = "copy_from";
        /// <summary>
        /// Cached name for the '_set_data' method.
        /// </summary>
        public static readonly StringName _SetData = "_set_data";
        /// <summary>
        /// Cached name for the '_get_data' method.
        /// </summary>
        public static readonly StringName _GetData = "_get_data";
        /// <summary>
        /// Cached name for the 'get_pixelv' method.
        /// </summary>
        public static readonly StringName GetPixelv = "get_pixelv";
        /// <summary>
        /// Cached name for the 'get_pixel' method.
        /// </summary>
        public static readonly StringName GetPixel = "get_pixel";
        /// <summary>
        /// Cached name for the 'set_pixelv' method.
        /// </summary>
        public static readonly StringName SetPixelv = "set_pixelv";
        /// <summary>
        /// Cached name for the 'set_pixel' method.
        /// </summary>
        public static readonly StringName SetPixel = "set_pixel";
        /// <summary>
        /// Cached name for the 'adjust_bcs' method.
        /// </summary>
        public static readonly StringName AdjustBcs = "adjust_bcs";
        /// <summary>
        /// Cached name for the 'load_png_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadPngFromBuffer = "load_png_from_buffer";
        /// <summary>
        /// Cached name for the 'load_jpg_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadJpgFromBuffer = "load_jpg_from_buffer";
        /// <summary>
        /// Cached name for the 'load_webp_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadWebpFromBuffer = "load_webp_from_buffer";
        /// <summary>
        /// Cached name for the 'load_tga_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadTgaFromBuffer = "load_tga_from_buffer";
        /// <summary>
        /// Cached name for the 'load_bmp_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadBmpFromBuffer = "load_bmp_from_buffer";
        /// <summary>
        /// Cached name for the 'load_ktx_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadKtxFromBuffer = "load_ktx_from_buffer";
        /// <summary>
        /// Cached name for the 'load_dds_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadDdsFromBuffer = "load_dds_from_buffer";
        /// <summary>
        /// Cached name for the 'load_exr_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadExrFromBuffer = "load_exr_from_buffer";
        /// <summary>
        /// Cached name for the 'load_svg_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadSvgFromBuffer = "load_svg_from_buffer";
        /// <summary>
        /// Cached name for the 'load_svg_from_string' method.
        /// </summary>
        public static readonly StringName LoadSvgFromString = "load_svg_from_string";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
