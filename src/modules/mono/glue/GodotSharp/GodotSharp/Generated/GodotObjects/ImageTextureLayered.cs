namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for <see cref="Godot.Texture2DArray"/>, <see cref="Godot.Cubemap"/> and <see cref="Godot.CubemapArray"/>. Cannot be used directly, but contains all the functions necessary for accessing the derived resource types. See also <see cref="Godot.Texture3D"/>.</para>
/// </summary>
public partial class ImageTextureLayered : TextureLayered
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array<Image> _Images
    {
        get
        {
            return _GetImages();
        }
        set
        {
            _SetImages(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(ImageTextureLayered);

    private static readonly StringName NativeName = "ImageTextureLayered";

    internal ImageTextureLayered() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImageTextureLayered(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImageTextureLayered(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromImages, 2785773503ul);

    /// <summary>
    /// <para>Creates an <see cref="Godot.ImageTextureLayered"/> from an array of <see cref="Godot.Image"/>s. See <see cref="Godot.Image.Create(int, int, bool, Image.Format)"/> for the expected data format. The first image decides the width, height, image format and mipmapping setting. The other images <i>must</i> have the same width, height, image format and mipmapping setting.</para>
    /// <para>Each <see cref="Godot.Image"/> represents one <c>layer</c>.</para>
    /// <para><code>
    /// # Fill in an array of Images with different colors.
    /// var images = []
    /// const LAYERS = 6
    /// for i in LAYERS:
    /// 	var image = Image.create_empty(128, 128, false, Image.FORMAT_RGB8)
    /// 	if i % 3 == 0:
    /// 		image.fill(Color.RED)
    /// 	elif i % 3 == 1:
    /// 		image.fill(Color.GREEN)
    /// 	else:
    /// 		image.fill(Color.BLUE)
    /// 	images.push_back(image)
    /// 
    /// # Create and save a 2D texture array. The array of images must have at least 1 Image.
    /// var texture_2d_array = Texture2DArray.new()
    /// texture_2d_array.create_from_images(images)
    /// ResourceSaver.save(texture_2d_array, "res://texture_2d_array.res", ResourceSaver.FLAG_COMPRESS)
    /// 
    /// # Create and save a cubemap. The array of images must have exactly 6 Images.
    /// # The cubemap's images are specified in this order: X+, X-, Y+, Y-, Z+, Z-
    /// # (in Godot's coordinate system, so Y+ is "up" and Z- is "forward").
    /// var cubemap = Cubemap.new()
    /// cubemap.create_from_images(images)
    /// ResourceSaver.save(cubemap, "res://cubemap.res", ResourceSaver.FLAG_COMPRESS)
    /// 
    /// # Create and save a cubemap array. The array of images must have a multiple of 6 Images.
    /// # Each cubemap's images are specified in this order: X+, X-, Y+, Y-, Z+, Z-
    /// # (in Godot's coordinate system, so Y+ is "up" and Z- is "forward").
    /// var cubemap_array = CubemapArray.new()
    /// cubemap_array.create_from_images(images)
    /// ResourceSaver.save(cubemap_array, "res://cubemap_array.res", ResourceSaver.FLAG_COMPRESS)
    /// </code></para>
    /// </summary>
    public Error CreateFromImages(Godot.Collections.Array<Image> images)
    {
        return (Error)NativeCalls.godot_icall_1_739(MethodBind0, GodotObject.GetPtr(this), (godot_array)(images ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateLayer, 3331733361ul);

    /// <summary>
    /// <para>Replaces the existing <see cref="Godot.Image"/> data at the given <paramref name="layer"/> with this new image.</para>
    /// <para>The given <see cref="Godot.Image"/> must have the same width, height, image format, and mipmapping flag as the rest of the referenced images.</para>
    /// <para>If the image format is unsupported, it will be decompressed and converted to a similar and supported <see cref="Godot.Image.Format"/>.</para>
    /// <para>The update is immediate: it's synchronized with drawing.</para>
    /// </summary>
    public void UpdateLayer(Image image, int layer)
    {
        NativeCalls.godot_icall_2_740(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(image), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetImages, 3995934104ul);

    internal Godot.Collections.Array<Image> _GetImages()
    {
        return new Godot.Collections.Array<Image>(NativeCalls.godot_icall_0_120(MethodBind2, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetImages, 381264803ul);

    internal void _SetImages(Godot.Collections.Array<Image> images)
    {
        NativeCalls.godot_icall_1_138(MethodBind3, GodotObject.GetPtr(this), (godot_array)(images ?? new()).NativeValue);
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
    public new class PropertyName : TextureLayered.PropertyName
    {
        /// <summary>
        /// Cached name for the '_images' property.
        /// </summary>
        public static readonly StringName _Images = "_images";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : TextureLayered.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_from_images' method.
        /// </summary>
        public static readonly StringName CreateFromImages = "create_from_images";
        /// <summary>
        /// Cached name for the 'update_layer' method.
        /// </summary>
        public static readonly StringName UpdateLayer = "update_layer";
        /// <summary>
        /// Cached name for the '_get_images' method.
        /// </summary>
        public static readonly StringName _GetImages = "_get_images";
        /// <summary>
        /// Cached name for the '_set_images' method.
        /// </summary>
        public static readonly StringName _SetImages = "_set_images";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : TextureLayered.SignalName
    {
    }
}
