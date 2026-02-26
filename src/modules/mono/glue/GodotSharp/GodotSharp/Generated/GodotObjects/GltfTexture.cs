namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
[GodotClassName("GLTFTexture")]
public partial class GltfTexture : Resource
{
    /// <summary>
    /// <para>The index of the image associated with this texture, see <see cref="Godot.GltfState.GetImages()"/>. If -1, then this texture does not have an image assigned.</para>
    /// </summary>
    public int SrcImage
    {
        get
        {
            return GetSrcImage();
        }
        set
        {
            SetSrcImage(value);
        }
    }

    /// <summary>
    /// <para>ID of the texture sampler to use when sampling the image. If -1, then the default texture sampler is used (linear filtering, and repeat wrapping in both axes).</para>
    /// </summary>
    public int Sampler
    {
        get
        {
            return GetSampler();
        }
        set
        {
            SetSampler(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfTexture);

    private static readonly StringName NativeName = "GLTFTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSrcImage, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSrcImage()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSrcImage, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSrcImage(int srcImage)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), srcImage);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSampler, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSampler()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSampler, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSampler(int sampler)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), sampler);
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
        /// Cached name for the 'src_image' property.
        /// </summary>
        public static readonly StringName SrcImage = "src_image";
        /// <summary>
        /// Cached name for the 'sampler' property.
        /// </summary>
        public static readonly StringName Sampler = "sampler";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_src_image' method.
        /// </summary>
        public static readonly StringName GetSrcImage = "get_src_image";
        /// <summary>
        /// Cached name for the 'set_src_image' method.
        /// </summary>
        public static readonly StringName SetSrcImage = "set_src_image";
        /// <summary>
        /// Cached name for the 'get_sampler' method.
        /// </summary>
        public static readonly StringName GetSampler = "get_sampler";
        /// <summary>
        /// Cached name for the 'set_sampler' method.
        /// </summary>
        public static readonly StringName SetSampler = "set_sampler";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
