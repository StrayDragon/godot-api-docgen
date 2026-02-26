namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A texture-based nine-patch <see cref="Godot.StyleBox"/>, in a way similar to <see cref="Godot.NinePatchRect"/>. This stylebox performs a 3×3 scaling of a texture, where only the center cell is fully stretched. This makes it possible to design bordered styles regardless of the stylebox's size.</para>
/// </summary>
public partial class StyleBoxTexture : StyleBox
{
    public enum AxisStretchMode : long
    {
        /// <summary>
        /// <para>Stretch the stylebox's texture. This results in visible distortion unless the texture size matches the stylebox's size perfectly.</para>
        /// </summary>
        Stretch = 0,
        /// <summary>
        /// <para>Repeats the stylebox's texture to match the stylebox's size according to the nine-patch system.</para>
        /// </summary>
        Tile = 1,
        /// <summary>
        /// <para>Repeats the stylebox's texture to match the stylebox's size according to the nine-patch system. Unlike <see cref="Godot.StyleBoxTexture.AxisStretchMode.Tile"/>, the texture may be slightly stretched to make the nine-patch texture tile seamlessly.</para>
        /// </summary>
        TileFit = 2
    }

    /// <summary>
    /// <para>The texture to use when drawing this style box.</para>
    /// </summary>
    public Texture2D Texture
    {
        get
        {
            return GetTexture();
        }
        set
        {
            SetTexture(value);
        }
    }

    /// <summary>
    /// <para>Increases the left margin of the 3×3 texture box.</para>
    /// <para>A higher value means more of the source texture is considered to be part of the left border of the 3×3 box.</para>
    /// <para>This is also the value used as fallback for <see cref="Godot.StyleBox.ContentMarginLeft"/> if it is negative.</para>
    /// </summary>
    public float TextureMarginLeft
    {
        get
        {
            return GetTextureMargin((Side)(0));
        }
        set
        {
            SetTextureMargin((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>Increases the top margin of the 3×3 texture box.</para>
    /// <para>A higher value means more of the source texture is considered to be part of the top border of the 3×3 box.</para>
    /// <para>This is also the value used as fallback for <see cref="Godot.StyleBox.ContentMarginTop"/> if it is negative.</para>
    /// </summary>
    public float TextureMarginTop
    {
        get
        {
            return GetTextureMargin((Side)(1));
        }
        set
        {
            SetTextureMargin((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>Increases the right margin of the 3×3 texture box.</para>
    /// <para>A higher value means more of the source texture is considered to be part of the right border of the 3×3 box.</para>
    /// <para>This is also the value used as fallback for <see cref="Godot.StyleBox.ContentMarginRight"/> if it is negative.</para>
    /// </summary>
    public float TextureMarginRight
    {
        get
        {
            return GetTextureMargin((Side)(2));
        }
        set
        {
            SetTextureMargin((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>Increases the bottom margin of the 3×3 texture box.</para>
    /// <para>A higher value means more of the source texture is considered to be part of the bottom border of the 3×3 box.</para>
    /// <para>This is also the value used as fallback for <see cref="Godot.StyleBox.ContentMarginBottom"/> if it is negative.</para>
    /// </summary>
    public float TextureMarginBottom
    {
        get
        {
            return GetTextureMargin((Side)(3));
        }
        set
        {
            SetTextureMargin((Side)(3), value);
        }
    }

    /// <summary>
    /// <para>Expands the left margin of this style box when drawing, causing it to be drawn larger than requested.</para>
    /// </summary>
    public float ExpandMarginLeft
    {
        get
        {
            return GetExpandMargin((Side)(0));
        }
        set
        {
            SetExpandMargin((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>Expands the top margin of this style box when drawing, causing it to be drawn larger than requested.</para>
    /// </summary>
    public float ExpandMarginTop
    {
        get
        {
            return GetExpandMargin((Side)(1));
        }
        set
        {
            SetExpandMargin((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>Expands the right margin of this style box when drawing, causing it to be drawn larger than requested.</para>
    /// </summary>
    public float ExpandMarginRight
    {
        get
        {
            return GetExpandMargin((Side)(2));
        }
        set
        {
            SetExpandMargin((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>Expands the bottom margin of this style box when drawing, causing it to be drawn larger than requested.</para>
    /// </summary>
    public float ExpandMarginBottom
    {
        get
        {
            return GetExpandMargin((Side)(3));
        }
        set
        {
            SetExpandMargin((Side)(3), value);
        }
    }

    /// <summary>
    /// <para>Controls how the stylebox's texture will be stretched or tiled horizontally.</para>
    /// </summary>
    public StyleBoxTexture.AxisStretchMode AxisStretchHorizontal
    {
        get
        {
            return GetHAxisStretchMode();
        }
        set
        {
            SetHAxisStretchMode(value);
        }
    }

    /// <summary>
    /// <para>Controls how the stylebox's texture will be stretched or tiled vertically.</para>
    /// </summary>
    public StyleBoxTexture.AxisStretchMode AxisStretchVertical
    {
        get
        {
            return GetVAxisStretchMode();
        }
        set
        {
            SetVAxisStretchMode(value);
        }
    }

    /// <summary>
    /// <para>The region to use from the <see cref="Godot.StyleBoxTexture.Texture"/>.</para>
    /// <para>This is equivalent to first wrapping the <see cref="Godot.StyleBoxTexture.Texture"/> in an <see cref="Godot.AtlasTexture"/> with the same region.</para>
    /// <para>If empty (<c>Rect2(0, 0, 0, 0)</c>), the whole <see cref="Godot.StyleBoxTexture.Texture"/> is used.</para>
    /// </summary>
    public Rect2 RegionRect
    {
        get
        {
            return GetRegionRect();
        }
        set
        {
            SetRegionRect(value);
        }
    }

    /// <summary>
    /// <para>Modulates the color of the texture when this style box is drawn.</para>
    /// </summary>
    public Color ModulateColor
    {
        get
        {
            return GetModulate();
        }
        set
        {
            SetModulate(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the nine-patch texture's center tile will be drawn.</para>
    /// </summary>
    public bool DrawCenter
    {
        get
        {
            return IsDrawCenterEnabled();
        }
        set
        {
            SetDrawCenter(value);
        }
    }

    private static readonly System.Type CachedType = typeof(StyleBoxTexture);

    private static readonly StringName NativeName = "StyleBoxTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public StyleBoxTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal StyleBoxTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StyleBoxTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureMargin, 4290182280ul);

    /// <summary>
    /// <para>Sets the margin to <paramref name="size"/> pixels for the specified <see cref="Godot.Side"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureMargin(Side margin, float size)
    {
        NativeCalls.godot_icall_2_69(MethodBind2, GodotObject.GetPtr(this), (int)margin, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureMarginAll, 373806689ul);

    /// <summary>
    /// <para>Sets the margin to <paramref name="size"/> pixels for all sides.</para>
    /// </summary>
    public void SetTextureMarginAll(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind3, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureMargin, 2869120046ul);

    /// <summary>
    /// <para>Returns the margin size of the specified <see cref="Godot.Side"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTextureMargin(Side margin)
    {
        return NativeCalls.godot_icall_1_72(MethodBind4, GodotObject.GetPtr(this), (int)margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExpandMargin, 4290182280ul);

    /// <summary>
    /// <para>Sets the expand margin to <paramref name="size"/> pixels for the specified <see cref="Godot.Side"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExpandMargin(Side margin, float size)
    {
        NativeCalls.godot_icall_2_69(MethodBind5, GodotObject.GetPtr(this), (int)margin, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExpandMarginAll, 373806689ul);

    /// <summary>
    /// <para>Sets the expand margin to <paramref name="size"/> pixels for all sides.</para>
    /// </summary>
    public void SetExpandMarginAll(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExpandMargin, 2869120046ul);

    /// <summary>
    /// <para>Returns the expand margin size of the specified <see cref="Godot.Side"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetExpandMargin(Side margin)
    {
        return NativeCalls.godot_icall_1_72(MethodBind7, GodotObject.GetPtr(this), (int)margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRegionRect, 2046264180ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRegionRect(Rect2 region)
    {
        NativeCalls.godot_icall_1_188(MethodBind8, GodotObject.GetPtr(this), &region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRegionRect, 1639390495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2 GetRegionRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawCenter, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawCenter(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawCenterEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawCenterEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModulate, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetModulate(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind12, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModulate, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetModulate()
    {
        return NativeCalls.godot_icall_0_214(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHAxisStretchMode, 2965538783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHAxisStretchMode(StyleBoxTexture.AxisStretchMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHAxisStretchMode, 3807744063ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleBoxTexture.AxisStretchMode GetHAxisStretchMode()
    {
        return (StyleBoxTexture.AxisStretchMode)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVAxisStretchMode, 2965538783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVAxisStretchMode(StyleBoxTexture.AxisStretchMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVAxisStretchMode, 3807744063ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StyleBoxTexture.AxisStretchMode GetVAxisStretchMode()
    {
        return (StyleBoxTexture.AxisStretchMode)NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
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
    public new class PropertyName : StyleBox.PropertyName
    {
        /// <summary>
        /// Cached name for the 'texture' property.
        /// </summary>
        public static readonly StringName Texture = "texture";
        /// <summary>
        /// Cached name for the 'texture_margin_left' property.
        /// </summary>
        public static readonly StringName TextureMarginLeft = "texture_margin_left";
        /// <summary>
        /// Cached name for the 'texture_margin_top' property.
        /// </summary>
        public static readonly StringName TextureMarginTop = "texture_margin_top";
        /// <summary>
        /// Cached name for the 'texture_margin_right' property.
        /// </summary>
        public static readonly StringName TextureMarginRight = "texture_margin_right";
        /// <summary>
        /// Cached name for the 'texture_margin_bottom' property.
        /// </summary>
        public static readonly StringName TextureMarginBottom = "texture_margin_bottom";
        /// <summary>
        /// Cached name for the 'expand_margin_left' property.
        /// </summary>
        public static readonly StringName ExpandMarginLeft = "expand_margin_left";
        /// <summary>
        /// Cached name for the 'expand_margin_top' property.
        /// </summary>
        public static readonly StringName ExpandMarginTop = "expand_margin_top";
        /// <summary>
        /// Cached name for the 'expand_margin_right' property.
        /// </summary>
        public static readonly StringName ExpandMarginRight = "expand_margin_right";
        /// <summary>
        /// Cached name for the 'expand_margin_bottom' property.
        /// </summary>
        public static readonly StringName ExpandMarginBottom = "expand_margin_bottom";
        /// <summary>
        /// Cached name for the 'axis_stretch_horizontal' property.
        /// </summary>
        public static readonly StringName AxisStretchHorizontal = "axis_stretch_horizontal";
        /// <summary>
        /// Cached name for the 'axis_stretch_vertical' property.
        /// </summary>
        public static readonly StringName AxisStretchVertical = "axis_stretch_vertical";
        /// <summary>
        /// Cached name for the 'region_rect' property.
        /// </summary>
        public static readonly StringName RegionRect = "region_rect";
        /// <summary>
        /// Cached name for the 'modulate_color' property.
        /// </summary>
        public static readonly StringName ModulateColor = "modulate_color";
        /// <summary>
        /// Cached name for the 'draw_center' property.
        /// </summary>
        public static readonly StringName DrawCenter = "draw_center";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : StyleBox.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_texture' method.
        /// </summary>
        public static readonly StringName SetTexture = "set_texture";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
        /// <summary>
        /// Cached name for the 'set_texture_margin' method.
        /// </summary>
        public static readonly StringName SetTextureMargin = "set_texture_margin";
        /// <summary>
        /// Cached name for the 'set_texture_margin_all' method.
        /// </summary>
        public static readonly StringName SetTextureMarginAll = "set_texture_margin_all";
        /// <summary>
        /// Cached name for the 'get_texture_margin' method.
        /// </summary>
        public static readonly StringName GetTextureMargin = "get_texture_margin";
        /// <summary>
        /// Cached name for the 'set_expand_margin' method.
        /// </summary>
        public static readonly StringName SetExpandMargin = "set_expand_margin";
        /// <summary>
        /// Cached name for the 'set_expand_margin_all' method.
        /// </summary>
        public static readonly StringName SetExpandMarginAll = "set_expand_margin_all";
        /// <summary>
        /// Cached name for the 'get_expand_margin' method.
        /// </summary>
        public static readonly StringName GetExpandMargin = "get_expand_margin";
        /// <summary>
        /// Cached name for the 'set_region_rect' method.
        /// </summary>
        public static readonly StringName SetRegionRect = "set_region_rect";
        /// <summary>
        /// Cached name for the 'get_region_rect' method.
        /// </summary>
        public static readonly StringName GetRegionRect = "get_region_rect";
        /// <summary>
        /// Cached name for the 'set_draw_center' method.
        /// </summary>
        public static readonly StringName SetDrawCenter = "set_draw_center";
        /// <summary>
        /// Cached name for the 'is_draw_center_enabled' method.
        /// </summary>
        public static readonly StringName IsDrawCenterEnabled = "is_draw_center_enabled";
        /// <summary>
        /// Cached name for the 'set_modulate' method.
        /// </summary>
        public static readonly StringName SetModulate = "set_modulate";
        /// <summary>
        /// Cached name for the 'get_modulate' method.
        /// </summary>
        public static readonly StringName GetModulate = "get_modulate";
        /// <summary>
        /// Cached name for the 'set_h_axis_stretch_mode' method.
        /// </summary>
        public static readonly StringName SetHAxisStretchMode = "set_h_axis_stretch_mode";
        /// <summary>
        /// Cached name for the 'get_h_axis_stretch_mode' method.
        /// </summary>
        public static readonly StringName GetHAxisStretchMode = "get_h_axis_stretch_mode";
        /// <summary>
        /// Cached name for the 'set_v_axis_stretch_mode' method.
        /// </summary>
        public static readonly StringName SetVAxisStretchMode = "set_v_axis_stretch_mode";
        /// <summary>
        /// Cached name for the 'get_v_axis_stretch_mode' method.
        /// </summary>
        public static readonly StringName GetVAxisStretchMode = "get_v_axis_stretch_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : StyleBox.SignalName
    {
    }
}
