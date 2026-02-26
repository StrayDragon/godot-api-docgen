namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.CanvasTexture"/> is an alternative to <see cref="Godot.ImageTexture"/> for 2D rendering. It allows using normal maps and specular maps in any node that inherits from <see cref="Godot.CanvasItem"/>. <see cref="Godot.CanvasTexture"/> also allows overriding the texture's filter and repeat mode independently of the node's properties (or the project settings).</para>
/// <para><b>Note:</b> <see cref="Godot.CanvasTexture"/> cannot be used in 3D. It will not display correctly when applied to any <see cref="Godot.VisualInstance3D"/>, such as <see cref="Godot.Sprite3D"/> or <see cref="Godot.Decal"/>. For physically-based materials in 3D, use <see cref="Godot.BaseMaterial3D"/> instead.</para>
/// </summary>
public partial class CanvasTexture : Texture2D
{
    /// <summary>
    /// <para>The diffuse (color) texture to use. This is the main texture you want to set in most cases.</para>
    /// </summary>
    public Texture2D DiffuseTexture
    {
        get
        {
            return GetDiffuseTexture();
        }
        set
        {
            SetDiffuseTexture(value);
        }
    }

    /// <summary>
    /// <para>The normal map texture to use. Only has a visible effect if <see cref="Godot.Light2D"/>s are affecting this <see cref="Godot.CanvasTexture"/>.</para>
    /// <para><b>Note:</b> Godot expects the normal map to use X+, Y+, and Z+ coordinates. See <a href="http://wiki.polycount.com/wiki/Normal_Map_Technical_Details#Common_Swizzle_Coordinates">this page</a> for a comparison of normal map coordinates expected by popular engines.</para>
    /// </summary>
    public Texture2D NormalTexture
    {
        get
        {
            return GetNormalTexture();
        }
        set
        {
            SetNormalTexture(value);
        }
    }

    /// <summary>
    /// <para>The specular map to use for <see cref="Godot.Light2D"/> specular reflections. This should be a grayscale or colored texture, with brighter areas resulting in a higher <see cref="Godot.CanvasTexture.SpecularShininess"/> value. Using a colored <see cref="Godot.CanvasTexture.SpecularTexture"/> allows controlling specular shininess on a per-channel basis. Only has a visible effect if <see cref="Godot.Light2D"/>s are affecting this <see cref="Godot.CanvasTexture"/>.</para>
    /// </summary>
    public Texture2D SpecularTexture
    {
        get
        {
            return GetSpecularTexture();
        }
        set
        {
            SetSpecularTexture(value);
        }
    }

    /// <summary>
    /// <para>The multiplier for specular reflection colors. The <see cref="Godot.Light2D"/>'s color is also taken into account when determining the reflection color. Only has a visible effect if <see cref="Godot.Light2D"/>s are affecting this <see cref="Godot.CanvasTexture"/>.</para>
    /// </summary>
    public Color SpecularColor
    {
        get
        {
            return GetSpecularColor();
        }
        set
        {
            SetSpecularColor(value);
        }
    }

    /// <summary>
    /// <para>The specular exponent for <see cref="Godot.Light2D"/> specular reflections. Higher values result in a more glossy/"wet" look, with reflections becoming more localized and less visible overall. The default value of <c>1.0</c> disables specular reflections entirely. Only has a visible effect if <see cref="Godot.Light2D"/>s are affecting this <see cref="Godot.CanvasTexture"/>.</para>
    /// </summary>
    public float SpecularShininess
    {
        get
        {
            return GetSpecularShininess();
        }
        set
        {
            SetSpecularShininess(value);
        }
    }

    /// <summary>
    /// <para>The texture filtering mode to use when drawing this <see cref="Godot.CanvasTexture"/>.</para>
    /// </summary>
    public CanvasItem.TextureFilterEnum TextureFilter
    {
        get
        {
            return GetTextureFilter();
        }
        set
        {
            SetTextureFilter(value);
        }
    }

    /// <summary>
    /// <para>The texture repeat mode to use when drawing this <see cref="Godot.CanvasTexture"/>.</para>
    /// </summary>
    public CanvasItem.TextureRepeatEnum TextureRepeat
    {
        get
        {
            return GetTextureRepeat();
        }
        set
        {
            SetTextureRepeat(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CanvasTexture);

    private static readonly StringName NativeName = "CanvasTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CanvasTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CanvasTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CanvasTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDiffuseTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDiffuseTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDiffuseTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetDiffuseTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNormalTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNormalTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNormalTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetNormalTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpecularTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpecularTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpecularTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetSpecularTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpecularColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSpecularColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind6, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpecularColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetSpecularColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpecularShininess, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpecularShininess(float shininess)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), shininess);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpecularShininess, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSpecularShininess()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureFilter, 1037999706ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureFilter(CanvasItem.TextureFilterEnum filter)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureFilter, 121960042ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CanvasItem.TextureFilterEnum GetTextureFilter()
    {
        return (CanvasItem.TextureFilterEnum)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureRepeat, 1716472974ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureRepeat(CanvasItem.TextureRepeatEnum repeat)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)repeat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureRepeat, 2667158319ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CanvasItem.TextureRepeatEnum GetTextureRepeat()
    {
        return (CanvasItem.TextureRepeatEnum)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
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
        /// Cached name for the 'diffuse_texture' property.
        /// </summary>
        public static readonly StringName DiffuseTexture = "diffuse_texture";
        /// <summary>
        /// Cached name for the 'normal_texture' property.
        /// </summary>
        public static readonly StringName NormalTexture = "normal_texture";
        /// <summary>
        /// Cached name for the 'specular_texture' property.
        /// </summary>
        public static readonly StringName SpecularTexture = "specular_texture";
        /// <summary>
        /// Cached name for the 'specular_color' property.
        /// </summary>
        public static readonly StringName SpecularColor = "specular_color";
        /// <summary>
        /// Cached name for the 'specular_shininess' property.
        /// </summary>
        public static readonly StringName SpecularShininess = "specular_shininess";
        /// <summary>
        /// Cached name for the 'texture_filter' property.
        /// </summary>
        public static readonly StringName TextureFilter = "texture_filter";
        /// <summary>
        /// Cached name for the 'texture_repeat' property.
        /// </summary>
        public static readonly StringName TextureRepeat = "texture_repeat";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_diffuse_texture' method.
        /// </summary>
        public static readonly StringName SetDiffuseTexture = "set_diffuse_texture";
        /// <summary>
        /// Cached name for the 'get_diffuse_texture' method.
        /// </summary>
        public static readonly StringName GetDiffuseTexture = "get_diffuse_texture";
        /// <summary>
        /// Cached name for the 'set_normal_texture' method.
        /// </summary>
        public static readonly StringName SetNormalTexture = "set_normal_texture";
        /// <summary>
        /// Cached name for the 'get_normal_texture' method.
        /// </summary>
        public static readonly StringName GetNormalTexture = "get_normal_texture";
        /// <summary>
        /// Cached name for the 'set_specular_texture' method.
        /// </summary>
        public static readonly StringName SetSpecularTexture = "set_specular_texture";
        /// <summary>
        /// Cached name for the 'get_specular_texture' method.
        /// </summary>
        public static readonly StringName GetSpecularTexture = "get_specular_texture";
        /// <summary>
        /// Cached name for the 'set_specular_color' method.
        /// </summary>
        public static readonly StringName SetSpecularColor = "set_specular_color";
        /// <summary>
        /// Cached name for the 'get_specular_color' method.
        /// </summary>
        public static readonly StringName GetSpecularColor = "get_specular_color";
        /// <summary>
        /// Cached name for the 'set_specular_shininess' method.
        /// </summary>
        public static readonly StringName SetSpecularShininess = "set_specular_shininess";
        /// <summary>
        /// Cached name for the 'get_specular_shininess' method.
        /// </summary>
        public static readonly StringName GetSpecularShininess = "get_specular_shininess";
        /// <summary>
        /// Cached name for the 'set_texture_filter' method.
        /// </summary>
        public static readonly StringName SetTextureFilter = "set_texture_filter";
        /// <summary>
        /// Cached name for the 'get_texture_filter' method.
        /// </summary>
        public static readonly StringName GetTextureFilter = "get_texture_filter";
        /// <summary>
        /// Cached name for the 'set_texture_repeat' method.
        /// </summary>
        public static readonly StringName SetTextureRepeat = "set_texture_repeat";
        /// <summary>
        /// Cached name for the 'get_texture_repeat' method.
        /// </summary>
        public static readonly StringName GetTextureRepeat = "get_texture_repeat";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}
