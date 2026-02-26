namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for <see cref="Godot.ImageTextureLayered"/> and <see cref="Godot.CompressedTextureLayered"/>. Cannot be used directly, but contains all the functions necessary for accessing the derived resource types. See also <see cref="Godot.Texture3D"/>.</para>
/// <para>Data is set on a per-layer basis. For <see cref="Godot.Texture2DArray"/>s, the layer specifies the array layer.</para>
/// <para>All images need to have the same width, height and number of mipmap levels.</para>
/// <para>A <see cref="Godot.TextureLayered"/> can be loaded with <see cref="Godot.ResourceLoader.Load(string, string, ResourceLoader.CacheMode)"/>.</para>
/// <para>Internally, Godot maps these files to their respective counterparts in the target rendering driver (Vulkan, OpenGL3).</para>
/// </summary>
public partial class TextureLayered : Texture
{
    public enum LayeredType : long
    {
        /// <summary>
        /// <para>Texture is a generic <see cref="Godot.Texture2DArray"/>.</para>
        /// </summary>
        Type2DArray = 0,
        /// <summary>
        /// <para>Texture is a <see cref="Godot.Cubemap"/>, with each side in its own layer (6 in total).</para>
        /// </summary>
        Cubemap = 1,
        /// <summary>
        /// <para>Texture is a <see cref="Godot.CubemapArray"/>, with each cubemap being made of 6 layers.</para>
        /// </summary>
        CubemapArray = 2
    }

    private static readonly System.Type CachedType = typeof(TextureLayered);

    private static readonly StringName NativeName = "TextureLayered";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TextureLayered() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextureLayered(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextureLayered(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when the <see cref="Godot.TextureLayered"/>'s format is queried.</para>
    /// </summary>
    public virtual Image.Format _GetFormat()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the <see cref="Godot.TextureLayered"/>'s height is queried.</para>
    /// </summary>
    public virtual int _GetHeight()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the data for a layer in the <see cref="Godot.TextureLayered"/> is queried.</para>
    /// </summary>
    public virtual Image _GetLayerData(int layerIndex)
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the layers' type in the <see cref="Godot.TextureLayered"/> is queried.</para>
    /// </summary>
    public virtual uint _GetLayeredType()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the number of layers in the <see cref="Godot.TextureLayered"/> is queried.</para>
    /// </summary>
    public virtual int _GetLayers()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the <see cref="Godot.TextureLayered"/>'s width queried.</para>
    /// </summary>
    public virtual int _GetWidth()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the presence of mipmaps in the <see cref="Godot.TextureLayered"/> is queried.</para>
    /// </summary>
    public virtual bool _HasMipmaps()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFormat, 3847873762ul);

    /// <summary>
    /// <para>Returns the current format being used by this texture.</para>
    /// </summary>
    public Image.Format GetFormat()
    {
        return (Image.Format)NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayeredType, 518123893ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.TextureLayered"/>'s type. The type determines how the data is accessed, with cubemaps having special types.</para>
    /// </summary>
    public TextureLayered.LayeredType GetLayeredType()
    {
        return (TextureLayered.LayeredType)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWidth, 3905245786ul);

    /// <summary>
    /// <para>Returns the width of the texture in pixels. Width is typically represented by the X axis.</para>
    /// </summary>
    public int GetWidth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeight, 3905245786ul);

    /// <summary>
    /// <para>Returns the height of the texture in pixels. Height is typically represented by the Y axis.</para>
    /// </summary>
    public int GetHeight()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayers, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of referenced <see cref="Godot.Image"/>s.</para>
    /// </summary>
    public int GetLayers()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasMipmaps, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the layers have generated mipmaps.</para>
    /// </summary>
    public bool HasMipmaps()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerData, 3655284255ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Image"/> resource with the data from specified <paramref name="layer"/>.</para>
    /// </summary>
    public Image GetLayerData(int layer)
    {
        return (Image)NativeCalls.godot_icall_1_71(MethodBind6, GodotObject.GetPtr(this), layer);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_format = "_GetFormat";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_height = "_GetHeight";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_layer_data = "_GetLayerData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_layered_type = "_GetLayeredType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_layers = "_GetLayers";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_width = "_GetWidth";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_mipmaps = "_HasMipmaps";

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
        if ((method == MethodProxyName__get_format || method == MethodName._GetFormat) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_format.NativeValue))
        {
            var callRet = _GetFormat();
            ret = VariantUtils.CreateFrom<Image.Format>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_height || method == MethodName._GetHeight) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_height.NativeValue))
        {
            var callRet = _GetHeight();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_layer_data || method == MethodName._GetLayerData) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_layer_data.NativeValue))
        {
            var callRet = _GetLayerData(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<Image>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_layered_type || method == MethodName._GetLayeredType) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_layered_type.NativeValue))
        {
            var callRet = _GetLayeredType();
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_layers || method == MethodName._GetLayers) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_layers.NativeValue))
        {
            var callRet = _GetLayers();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_width || method == MethodName._GetWidth) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_width.NativeValue))
        {
            var callRet = _GetWidth();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_mipmaps || method == MethodName._HasMipmaps) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_mipmaps.NativeValue))
        {
            var callRet = _HasMipmaps();
            ret = VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName._GetFormat)
        {
            if (HasGodotClassMethod(MethodProxyName__get_format.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetHeight)
        {
            if (HasGodotClassMethod(MethodProxyName__get_height.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetLayerData)
        {
            if (HasGodotClassMethod(MethodProxyName__get_layer_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetLayeredType)
        {
            if (HasGodotClassMethod(MethodProxyName__get_layered_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetLayers)
        {
            if (HasGodotClassMethod(MethodProxyName__get_layers.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetWidth)
        {
            if (HasGodotClassMethod(MethodProxyName__get_width.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasMipmaps)
        {
            if (HasGodotClassMethod(MethodProxyName__has_mipmaps.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : Texture.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_format' method.
        /// </summary>
        public static readonly StringName _GetFormat = "_get_format";
        /// <summary>
        /// Cached name for the '_get_height' method.
        /// </summary>
        public static readonly StringName _GetHeight = "_get_height";
        /// <summary>
        /// Cached name for the '_get_layer_data' method.
        /// </summary>
        public static readonly StringName _GetLayerData = "_get_layer_data";
        /// <summary>
        /// Cached name for the '_get_layered_type' method.
        /// </summary>
        public static readonly StringName _GetLayeredType = "_get_layered_type";
        /// <summary>
        /// Cached name for the '_get_layers' method.
        /// </summary>
        public static readonly StringName _GetLayers = "_get_layers";
        /// <summary>
        /// Cached name for the '_get_width' method.
        /// </summary>
        public static readonly StringName _GetWidth = "_get_width";
        /// <summary>
        /// Cached name for the '_has_mipmaps' method.
        /// </summary>
        public static readonly StringName _HasMipmaps = "_has_mipmaps";
        /// <summary>
        /// Cached name for the 'get_format' method.
        /// </summary>
        public static readonly StringName GetFormat = "get_format";
        /// <summary>
        /// Cached name for the 'get_layered_type' method.
        /// </summary>
        public static readonly StringName GetLayeredType = "get_layered_type";
        /// <summary>
        /// Cached name for the 'get_width' method.
        /// </summary>
        public static readonly StringName GetWidth = "get_width";
        /// <summary>
        /// Cached name for the 'get_height' method.
        /// </summary>
        public static readonly StringName GetHeight = "get_height";
        /// <summary>
        /// Cached name for the 'get_layers' method.
        /// </summary>
        public static readonly StringName GetLayers = "get_layers";
        /// <summary>
        /// Cached name for the 'has_mipmaps' method.
        /// </summary>
        public static readonly StringName HasMipmaps = "has_mipmaps";
        /// <summary>
        /// Cached name for the 'get_layer_data' method.
        /// </summary>
        public static readonly StringName GetLayerData = "get_layer_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture.SignalName
    {
    }
}
