namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The engine supports multiple image formats out of the box (PNG, SVG, JPEG, WebP to name a few), but you can choose to implement support for additional image formats by extending this class.</para>
/// <para>Be sure to respect the documented return types and values. You should create an instance of it, and call <see cref="Godot.ImageFormatLoaderExtension.AddFormatLoader()"/> to register that loader during the initialization phase.</para>
/// </summary>
public partial class ImageFormatLoaderExtension : ImageFormatLoader
{
    private static readonly System.Type CachedType = typeof(ImageFormatLoaderExtension);

    private static readonly StringName NativeName = "ImageFormatLoaderExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ImageFormatLoaderExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImageFormatLoaderExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImageFormatLoaderExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Returns the list of file extensions for this image format. Files with the given extensions will be treated as image file and loaded using this class.</para>
    /// </summary>
    public virtual string[] _GetRecognizedExtensions()
    {
        return default;
    }

    /// <summary>
    /// <para>Loads the content of <paramref name="fileaccess"/> into the provided <paramref name="image"/>.</para>
    /// </summary>
    public virtual Error _LoadImage(Image image, FileAccess fileaccess, ImageFormatLoader.LoaderFlags flags, float scale)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddFormatLoader, 3218959716ul);

    /// <summary>
    /// <para>Add this format loader to the engine, allowing it to recognize the file extensions returned by <see cref="Godot.ImageFormatLoaderExtension._GetRecognizedExtensions()"/>.</para>
    /// </summary>
    public void AddFormatLoader()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveFormatLoader, 3218959716ul);

    /// <summary>
    /// <para>Remove this format loader from the engine.</para>
    /// </summary>
    public void RemoveFormatLoader()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_recognized_extensions = "_GetRecognizedExtensions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__load_image = "_LoadImage";

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
        if ((method == MethodProxyName__get_recognized_extensions || method == MethodName._GetRecognizedExtensions) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_recognized_extensions.NativeValue))
        {
            var callRet = _GetRecognizedExtensions();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__load_image || method == MethodName._LoadImage) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__load_image.NativeValue))
        {
            var callRet = _LoadImage(VariantUtils.ConvertTo<Image>(args[0]), VariantUtils.ConvertTo<FileAccess>(args[1]), VariantUtils.ConvertTo<ImageFormatLoader.LoaderFlags>(args[2]), VariantUtils.ConvertTo<float>(args[3]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
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
        if (method == MethodName._GetRecognizedExtensions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_recognized_extensions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._LoadImage)
        {
            if (HasGodotClassMethod(MethodProxyName__load_image.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : ImageFormatLoader.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ImageFormatLoader.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_recognized_extensions' method.
        /// </summary>
        public static readonly StringName _GetRecognizedExtensions = "_get_recognized_extensions";
        /// <summary>
        /// Cached name for the '_load_image' method.
        /// </summary>
        public static readonly StringName _LoadImage = "_load_image";
        /// <summary>
        /// Cached name for the 'add_format_loader' method.
        /// </summary>
        public static readonly StringName AddFormatLoader = "add_format_loader";
        /// <summary>
        /// Cached name for the 'remove_format_loader' method.
        /// </summary>
        public static readonly StringName RemoveFormatLoader = "remove_format_loader";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ImageFormatLoader.SignalName
    {
    }
}
