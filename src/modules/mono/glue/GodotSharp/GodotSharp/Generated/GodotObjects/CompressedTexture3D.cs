namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.CompressedTexture3D"/> is the VRAM-compressed counterpart of <see cref="Godot.ImageTexture3D"/>. The file extension for <see cref="Godot.CompressedTexture3D"/> files is <c>.ctex3d</c>. This file format is internal to Godot; it is created by importing other image formats with the import system.</para>
/// <para><see cref="Godot.CompressedTexture3D"/> uses VRAM compression, which allows to reduce memory usage on the GPU when rendering the texture. This also improves loading times, as VRAM-compressed textures are faster to load compared to textures using lossless compression. VRAM compression can exhibit noticeable artifacts and is intended to be used for 3D rendering, not 2D.</para>
/// <para>See <see cref="Godot.Texture3D"/> for a general description of 3D textures.</para>
/// </summary>
public partial class CompressedTexture3D : Texture3D
{
    /// <summary>
    /// <para>The <see cref="Godot.CompressedTexture3D"/>'s file path to a <c>.ctex3d</c> file.</para>
    /// </summary>
    public string LoadPath
    {
        get
        {
            return GetLoadPath();
        }
        set
        {
            Load(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CompressedTexture3D);

    private static readonly StringName NativeName = "CompressedTexture3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CompressedTexture3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CompressedTexture3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CompressedTexture3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Load, 166001499ul);

    /// <summary>
    /// <para>Loads the texture from the specified <paramref name="path"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Error Load(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoadPath, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLoadPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
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
        /// Cached name for the 'load_path' property.
        /// </summary>
        public static readonly StringName LoadPath = "load_path";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'load' method.
        /// </summary>
        public static readonly StringName Load = "load";
        /// <summary>
        /// Cached name for the 'get_load_path' method.
        /// </summary>
        public static readonly StringName GetLoadPath = "get_load_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture3D.SignalName
    {
    }
}
