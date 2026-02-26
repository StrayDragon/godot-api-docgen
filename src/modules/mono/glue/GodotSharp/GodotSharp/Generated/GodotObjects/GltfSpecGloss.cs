namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>KHR_materials_pbrSpecularGlossiness is an archived glTF extension. This means that it is deprecated and not recommended for new files. However, it is still supported for loading old files.</para>
/// </summary>
[GodotClassName("GLTFSpecGloss")]
public partial class GltfSpecGloss : Resource
{
    /// <summary>
    /// <para>The diffuse texture.</para>
    /// </summary>
    public Image DiffuseImg
    {
        get
        {
            return GetDiffuseImg();
        }
        set
        {
            SetDiffuseImg(value);
        }
    }

    /// <summary>
    /// <para>The reflected diffuse factor of the material.</para>
    /// </summary>
    public Color DiffuseFactor
    {
        get
        {
            return GetDiffuseFactor();
        }
        set
        {
            SetDiffuseFactor(value);
        }
    }

    /// <summary>
    /// <para>The glossiness or smoothness of the material.</para>
    /// </summary>
    public float GlossFactor
    {
        get
        {
            return GetGlossFactor();
        }
        set
        {
            SetGlossFactor(value);
        }
    }

    /// <summary>
    /// <para>The specular RGB color of the material. The alpha channel is unused.</para>
    /// </summary>
    public Color SpecularFactor
    {
        get
        {
            return GetSpecularFactor();
        }
        set
        {
            SetSpecularFactor(value);
        }
    }

    /// <summary>
    /// <para>The specular-glossiness texture.</para>
    /// </summary>
    public Image SpecGlossImg
    {
        get
        {
            return GetSpecGlossImg();
        }
        set
        {
            SetSpecGlossImg(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfSpecGloss);

    private static readonly StringName NativeName = "GLTFSpecGloss";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfSpecGloss() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfSpecGloss(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfSpecGloss(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDiffuseImg, 564927088ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Image GetDiffuseImg()
    {
        return (Image)NativeCalls.godot_icall_0_63(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDiffuseImg, 532598488ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDiffuseImg(Image diffuseImg)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(diffuseImg));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDiffuseFactor, 3200896285ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetDiffuseFactor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDiffuseFactor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetDiffuseFactor(Color diffuseFactor)
    {
        NativeCalls.godot_icall_1_213(MethodBind3, GodotObject.GetPtr(this), &diffuseFactor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlossFactor, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGlossFactor()
    {
        return NativeCalls.godot_icall_0_68(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlossFactor, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlossFactor(float glossFactor)
    {
        NativeCalls.godot_icall_1_67(MethodBind5, GodotObject.GetPtr(this), glossFactor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpecularFactor, 3200896285ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetSpecularFactor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpecularFactor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSpecularFactor(Color specularFactor)
    {
        NativeCalls.godot_icall_1_213(MethodBind7, GodotObject.GetPtr(this), &specularFactor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpecGlossImg, 564927088ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Image GetSpecGlossImg()
    {
        return (Image)NativeCalls.godot_icall_0_63(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpecGlossImg, 532598488ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpecGlossImg(Image specGlossImg)
    {
        NativeCalls.godot_icall_1_56(MethodBind9, GodotObject.GetPtr(this), GodotObject.GetPtr(specGlossImg));
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
        /// Cached name for the 'diffuse_img' property.
        /// </summary>
        public static readonly StringName DiffuseImg = "diffuse_img";
        /// <summary>
        /// Cached name for the 'diffuse_factor' property.
        /// </summary>
        public static readonly StringName DiffuseFactor = "diffuse_factor";
        /// <summary>
        /// Cached name for the 'gloss_factor' property.
        /// </summary>
        public static readonly StringName GlossFactor = "gloss_factor";
        /// <summary>
        /// Cached name for the 'specular_factor' property.
        /// </summary>
        public static readonly StringName SpecularFactor = "specular_factor";
        /// <summary>
        /// Cached name for the 'spec_gloss_img' property.
        /// </summary>
        public static readonly StringName SpecGlossImg = "spec_gloss_img";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_diffuse_img' method.
        /// </summary>
        public static readonly StringName GetDiffuseImg = "get_diffuse_img";
        /// <summary>
        /// Cached name for the 'set_diffuse_img' method.
        /// </summary>
        public static readonly StringName SetDiffuseImg = "set_diffuse_img";
        /// <summary>
        /// Cached name for the 'get_diffuse_factor' method.
        /// </summary>
        public static readonly StringName GetDiffuseFactor = "get_diffuse_factor";
        /// <summary>
        /// Cached name for the 'set_diffuse_factor' method.
        /// </summary>
        public static readonly StringName SetDiffuseFactor = "set_diffuse_factor";
        /// <summary>
        /// Cached name for the 'get_gloss_factor' method.
        /// </summary>
        public static readonly StringName GetGlossFactor = "get_gloss_factor";
        /// <summary>
        /// Cached name for the 'set_gloss_factor' method.
        /// </summary>
        public static readonly StringName SetGlossFactor = "set_gloss_factor";
        /// <summary>
        /// Cached name for the 'get_specular_factor' method.
        /// </summary>
        public static readonly StringName GetSpecularFactor = "get_specular_factor";
        /// <summary>
        /// Cached name for the 'set_specular_factor' method.
        /// </summary>
        public static readonly StringName SetSpecularFactor = "set_specular_factor";
        /// <summary>
        /// Cached name for the 'get_spec_gloss_img' method.
        /// </summary>
        public static readonly StringName GetSpecGlossImg = "get_spec_gloss_img";
        /// <summary>
        /// Cached name for the 'set_spec_gloss_img' method.
        /// </summary>
        public static readonly StringName SetSpecGlossImg = "set_spec_gloss_img";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
