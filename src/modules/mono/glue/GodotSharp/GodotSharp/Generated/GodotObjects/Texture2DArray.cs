namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A Texture2DArray is different from a Texture3D: The Texture2DArray does not support trilinear interpolation between the <see cref="Godot.Image"/>s, i.e. no blending. See also <see cref="Godot.Cubemap"/> and <see cref="Godot.CubemapArray"/>, which are texture arrays with specialized cubemap functions.</para>
/// <para>A Texture2DArray is also different from an <see cref="Godot.AtlasTexture"/>: In a Texture2DArray, all images are treated separately. In an atlas, the regions (i.e. the single images) can be of different sizes. Furthermore, you usually need to add a padding around the regions, to prevent accidental UV mapping to more than one region. The same goes for mipmapping: Mipmap chains are handled separately for each layer. In an atlas, the slicing has to be done manually in the fragment shader.</para>
/// <para>To create such a texture file yourself, reimport your image files using the Godot Editor import presets. To create a Texture2DArray from code, use <see cref="Godot.ImageTextureLayered.CreateFromImages(Godot.Collections.Array{Image})"/> on an instance of the Texture2DArray class.</para>
/// </summary>
public partial class Texture2DArray : ImageTextureLayered
{
    private static readonly System.Type CachedType = typeof(Texture2DArray);

    private static readonly StringName NativeName = "Texture2DArray";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Texture2DArray() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Texture2DArray(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Texture2DArray(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreatePlaceholder, 121922552ul);

    /// <summary>
    /// <para>Creates a placeholder version of this resource (<see cref="Godot.PlaceholderTexture2DArray"/>).</para>
    /// </summary>
    public Resource CreatePlaceholder()
    {
        return (Resource)NativeCalls.godot_icall_0_63(MethodBind0, GodotObject.GetPtr(this));
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
    public new class PropertyName : ImageTextureLayered.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ImageTextureLayered.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_placeholder' method.
        /// </summary>
        public static readonly StringName CreatePlaceholder = "create_placeholder";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ImageTextureLayered.SignalName
    {
    }
}
