namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.ImageTexture3D"/> is a 3-dimensional <see cref="Godot.ImageTexture"/> that has a width, height, and depth. See also <see cref="Godot.ImageTextureLayered"/>.</para>
/// <para>3D textures are typically used to store density maps for <see cref="Godot.FogMaterial"/>, color correction LUTs for <see cref="Godot.Environment"/>, vector fields for <see cref="Godot.GpuParticlesAttractorVectorField3D"/> and collision maps for <see cref="Godot.GpuParticlesCollisionSdf3D"/>. 3D textures can also be used in custom shaders.</para>
/// </summary>
public partial class ImageTexture3D : Texture3D
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

    private static readonly System.Type CachedType = typeof(ImageTexture3D);

    private static readonly StringName NativeName = "ImageTexture3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ImageTexture3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImageTexture3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImageTexture3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Create, 1130379827ul);

    /// <summary>
    /// <para>Creates the <see cref="Godot.ImageTexture3D"/> with specified <paramref name="format"/>, <paramref name="width"/>, <paramref name="height"/>, and <paramref name="depth"/>. If <paramref name="useMipmaps"/> is <see langword="true"/>, generates mipmaps for the <see cref="Godot.ImageTexture3D"/>.</para>
    /// </summary>
    public Error Create(Image.Format format, int width, int height, int depth, bool useMipmaps, Godot.Collections.Array<Image> data)
    {
        return (Error)NativeCalls.godot_icall_6_738(MethodBind0, GodotObject.GetPtr(this), (int)format, width, height, depth, useMipmaps.ToGodotBool(), (godot_array)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Update, 381264803ul);

    /// <summary>
    /// <para>Replaces the texture's existing data with the layers specified in <paramref name="data"/>. The size of <paramref name="data"/> must match the parameters that were used for <see cref="Godot.ImageTexture3D.Create(Image.Format, int, int, int, bool, Godot.Collections.Array{Image})"/>. In other words, the texture cannot be resized or have its format changed by calling <see cref="Godot.ImageTexture3D.Update(Godot.Collections.Array{Image})"/>.</para>
    /// </summary>
    public void Update(Godot.Collections.Array<Image> data)
    {
        NativeCalls.godot_icall_1_138(MethodBind1, GodotObject.GetPtr(this), (godot_array)(data ?? new()).NativeValue);
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
    public new class PropertyName : Texture3D.PropertyName
    {
        /// <summary>
        /// Cached name for the '_images' property.
        /// </summary>
        public static readonly StringName _Images = "_images";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'create' method.
        /// </summary>
        public static readonly StringName Create = "create";
        /// <summary>
        /// Cached name for the 'update' method.
        /// </summary>
        public static readonly StringName Update = "update";
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
    public new class SignalName : Texture3D.SignalName
    {
    }
}
