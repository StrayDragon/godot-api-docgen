namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Represents a texture sampler as defined by the base glTF spec. Texture samplers in glTF specify how to sample data from the texture's base image, when rendering the texture on an object.</para>
/// </summary>
[GodotClassName("GLTFTextureSampler")]
public partial class GltfTextureSampler : Resource
{
    /// <summary>
    /// <para>Texture's magnification filter, used when texture appears larger on screen than the source image.</para>
    /// </summary>
    public int MagFilter
    {
        get
        {
            return GetMagFilter();
        }
        set
        {
            SetMagFilter(value);
        }
    }

    /// <summary>
    /// <para>Texture's minification filter, used when the texture appears smaller on screen than the source image.</para>
    /// </summary>
    public int MinFilter
    {
        get
        {
            return GetMinFilter();
        }
        set
        {
            SetMinFilter(value);
        }
    }

    /// <summary>
    /// <para>Wrapping mode to use for S-axis (horizontal) texture coordinates.</para>
    /// </summary>
    public int WrapS
    {
        get
        {
            return GetWrapS();
        }
        set
        {
            SetWrapS(value);
        }
    }

    /// <summary>
    /// <para>Wrapping mode to use for T-axis (vertical) texture coordinates.</para>
    /// </summary>
    public int WrapT
    {
        get
        {
            return GetWrapT();
        }
        set
        {
            SetWrapT(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfTextureSampler);

    private static readonly StringName NativeName = "GLTFTextureSampler";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfTextureSampler() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfTextureSampler(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfTextureSampler(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMagFilter, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMagFilter()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMagFilter, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMagFilter(int filterMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), filterMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinFilter, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMinFilter()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinFilter, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinFilter(int filterMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), filterMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWrapS, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetWrapS()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWrapS, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWrapS(int wrapMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), wrapMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWrapT, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetWrapT()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWrapT, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWrapT(int wrapMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), wrapMode);
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
        /// Cached name for the 'mag_filter' property.
        /// </summary>
        public static readonly StringName MagFilter = "mag_filter";
        /// <summary>
        /// Cached name for the 'min_filter' property.
        /// </summary>
        public static readonly StringName MinFilter = "min_filter";
        /// <summary>
        /// Cached name for the 'wrap_s' property.
        /// </summary>
        public static readonly StringName WrapS = "wrap_s";
        /// <summary>
        /// Cached name for the 'wrap_t' property.
        /// </summary>
        public static readonly StringName WrapT = "wrap_t";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_mag_filter' method.
        /// </summary>
        public static readonly StringName GetMagFilter = "get_mag_filter";
        /// <summary>
        /// Cached name for the 'set_mag_filter' method.
        /// </summary>
        public static readonly StringName SetMagFilter = "set_mag_filter";
        /// <summary>
        /// Cached name for the 'get_min_filter' method.
        /// </summary>
        public static readonly StringName GetMinFilter = "get_min_filter";
        /// <summary>
        /// Cached name for the 'set_min_filter' method.
        /// </summary>
        public static readonly StringName SetMinFilter = "set_min_filter";
        /// <summary>
        /// Cached name for the 'get_wrap_s' method.
        /// </summary>
        public static readonly StringName GetWrapS = "get_wrap_s";
        /// <summary>
        /// Cached name for the 'set_wrap_s' method.
        /// </summary>
        public static readonly StringName SetWrapS = "set_wrap_s";
        /// <summary>
        /// Cached name for the 'get_wrap_t' method.
        /// </summary>
        public static readonly StringName GetWrapT = "get_wrap_t";
        /// <summary>
        /// Cached name for the 'set_wrap_t' method.
        /// </summary>
        public static readonly StringName SetWrapT = "set_wrap_t";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
