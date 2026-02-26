namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A <see cref="Godot.Texture2D"/> based on an <see cref="Godot.Image"/>. For an image to be displayed, an <see cref="Godot.ImageTexture"/> has to be created from it using the <see cref="Godot.ImageTexture.CreateFromImage(Image)"/> method:</para>
/// <para><code>
/// var image = Image.load_from_file("res://icon.svg")
/// var texture = ImageTexture.create_from_image(image)
/// $Sprite2D.texture = texture
/// </code></para>
/// <para>This way, textures can be created at run-time by loading images both from within the editor and externally.</para>
/// <para><b>Warning:</b> Prefer to load imported textures with <c>@GDScript.load</c> over loading them from within the filesystem dynamically with <see cref="Godot.Image.Load(string)"/>, as it may not work in exported projects:</para>
/// <para><code>
/// var texture = load("res://icon.svg")
/// $Sprite2D.texture = texture
/// </code></para>
/// <para>This is because images have to be imported as a <see cref="Godot.CompressedTexture2D"/> first to be loaded with <c>@GDScript.load</c>. If you'd still like to load an image file just like any other <see cref="Godot.Resource"/>, import it as an <see cref="Godot.Image"/> resource instead, and then load it normally using the <c>@GDScript.load</c> method.</para>
/// <para><b>Note:</b> The image can be retrieved from an imported texture using the <see cref="Godot.Texture2D.GetImage()"/> method, which returns a copy of the image:</para>
/// <para><code>
/// var texture = load("res://icon.svg")
/// var image = texture.get_image()
/// </code></para>
/// <para>An <see cref="Godot.ImageTexture"/> is not meant to be operated from within the editor interface directly, and is mostly useful for rendering images on screen dynamically via code. If you need to generate images procedurally from within the editor, consider saving and importing images as custom texture resources implementing a new <c>EditorImportPlugin</c>.</para>
/// <para><b>Note:</b> The maximum texture size is 16384×16384 pixels due to graphics hardware limitations.</para>
/// </summary>
public partial class ImageTexture : Texture2D
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Image Image
    {
        get
        {
            return GetImage();
        }
        set
        {
            _SetImage(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(ImageTexture);

    private static readonly StringName NativeName = "ImageTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ImageTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImageTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImageTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromImage, 2775144163ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.ImageTexture"/> and initializes it by allocating and setting the data from an <see cref="Godot.Image"/>.</para>
    /// </summary>
    public static ImageTexture CreateFromImage(Image image)
    {
        return (ImageTexture)NativeCalls.godot_icall_1_637(MethodBind0, GodotObject.GetPtr(image));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFormat, 3847873762ul);

    /// <summary>
    /// <para>Returns the format of the texture.</para>
    /// </summary>
    public Image.Format GetFormat()
    {
        return (Image.Format)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetImage, 532598488ul);

    /// <summary>
    /// <para>Replaces the texture's data with a new <see cref="Godot.Image"/>. This will re-allocate new memory for the texture.</para>
    /// <para>If you want to update the image, but don't need to change its parameters (format, size), use <see cref="Godot.ImageTexture.Update(Image)"/> instead for better performance.</para>
    /// </summary>
    public void SetImage(Image image)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(image));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Update, 532598488ul);

    /// <summary>
    /// <para>Replaces the texture's data with a new <see cref="Godot.Image"/>.</para>
    /// <para><b>Note:</b> The texture has to be created using <see cref="Godot.ImageTexture.CreateFromImage(Image)"/> or initialized first with the <see cref="Godot.ImageTexture.SetImage(Image)"/> method before it can be updated. The new image dimensions, format, and mipmaps configuration should match the existing texture's image configuration.</para>
    /// <para>Use this method over <see cref="Godot.ImageTexture.SetImage(Image)"/> if you need to update the texture frequently, which is faster than allocating additional memory for a new texture each time.</para>
    /// </summary>
    public void Update(Image image)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(image));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSizeOverride, 1130785943ul);

    /// <summary>
    /// <para>Resizes the texture to the specified dimensions.</para>
    /// </summary>
    public unsafe void SetSizeOverride(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind4, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetImage, 532598488ul);

    internal void _SetImage(Image image)
    {
        NativeCalls.godot_icall_1_56(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(image));
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
    public new class PropertyName : Texture2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'image' property.
        /// </summary>
        public static readonly StringName Image = "image";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_from_image' method.
        /// </summary>
        public static readonly StringName CreateFromImage = "create_from_image";
        /// <summary>
        /// Cached name for the 'get_format' method.
        /// </summary>
        public static readonly StringName GetFormat = "get_format";
        /// <summary>
        /// Cached name for the 'set_image' method.
        /// </summary>
        public static readonly StringName SetImage = "set_image";
        /// <summary>
        /// Cached name for the 'update' method.
        /// </summary>
        public static readonly StringName Update = "update";
        /// <summary>
        /// Cached name for the 'set_size_override' method.
        /// </summary>
        public static readonly StringName SetSizeOverride = "set_size_override";
        /// <summary>
        /// Cached name for the '_set_image' method.
        /// </summary>
        public static readonly StringName _SetImage = "_set_image";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}
