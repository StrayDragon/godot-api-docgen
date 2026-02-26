namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Also known as 9-slice panels, <see cref="Godot.NinePatchRect"/> produces clean panels of any size based on a small texture. To do so, it splits the texture in a 3×3 grid. When you scale the node, it tiles the texture's edges horizontally or vertically, tiles the center on both axes, and leaves the corners unchanged.</para>
/// </summary>
public partial class NinePatchRect : Control
{
    public enum AxisStretchMode : long
    {
        /// <summary>
        /// <para>Stretches the center texture across the NinePatchRect. This may cause the texture to be distorted.</para>
        /// </summary>
        Stretch = 0,
        /// <summary>
        /// <para>Repeats the center texture across the NinePatchRect. This won't cause any visible distortion. The texture must be seamless for this to work without displaying artifacts between edges.</para>
        /// </summary>
        Tile = 1,
        /// <summary>
        /// <para>Repeats the center texture across the NinePatchRect, but will also stretch the texture to make sure each tile is visible in full. This may cause the texture to be distorted, but less than <see cref="Godot.NinePatchRect.AxisStretchMode.Stretch"/>. The texture must be seamless for this to work without displaying artifacts between edges.</para>
        /// </summary>
        TileFit = 2
    }

    /// <summary>
    /// <para>The node's texture resource.</para>
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
    /// <para>If <see langword="true"/>, draw the panel's center. Else, only draw the 9-slice's borders.</para>
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

    /// <summary>
    /// <para>Rectangular region of the texture to sample from. If you're working with an atlas, use this property to define the area the 9-slice should use. All other properties are relative to this one. If the rect is empty, NinePatchRect will use the whole texture.</para>
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
    /// <para>The width of the 9-slice's left column. A margin of 16 means the 9-slice's left corners and side will have a width of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    public int PatchMarginLeft
    {
        get
        {
            return GetPatchMargin((Side)(0));
        }
        set
        {
            SetPatchMargin((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>The height of the 9-slice's top row. A margin of 16 means the 9-slice's top corners and side will have a height of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    public int PatchMarginTop
    {
        get
        {
            return GetPatchMargin((Side)(1));
        }
        set
        {
            SetPatchMargin((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>The width of the 9-slice's right column. A margin of 16 means the 9-slice's right corners and side will have a width of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    public int PatchMarginRight
    {
        get
        {
            return GetPatchMargin((Side)(2));
        }
        set
        {
            SetPatchMargin((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>The height of the 9-slice's bottom row. A margin of 16 means the 9-slice's bottom corners and side will have a height of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders.</para>
    /// </summary>
    public int PatchMarginBottom
    {
        get
        {
            return GetPatchMargin((Side)(3));
        }
        set
        {
            SetPatchMargin((Side)(3), value);
        }
    }

    /// <summary>
    /// <para>The stretch mode to use for horizontal stretching/tiling.</para>
    /// </summary>
    public NinePatchRect.AxisStretchMode AxisStretchHorizontal
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
    /// <para>The stretch mode to use for vertical stretching/tiling.</para>
    /// </summary>
    public NinePatchRect.AxisStretchMode AxisStretchVertical
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

    private static readonly System.Type CachedType = typeof(NinePatchRect);

    private static readonly StringName NativeName = "NinePatchRect";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public NinePatchRect() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal NinePatchRect(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal NinePatchRect(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPatchMargin, 437707142ul);

    /// <summary>
    /// <para>Sets the size of the margin on the specified <see cref="Godot.Side"/> to <paramref name="value"/> pixels.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPatchMargin(Side margin, int value)
    {
        NativeCalls.godot_icall_2_59(MethodBind2, GodotObject.GetPtr(this), (int)margin, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPatchMargin, 1983885014ul);

    /// <summary>
    /// <para>Returns the size of the margin on the specified <see cref="Godot.Side"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPatchMargin(Side margin)
    {
        return NativeCalls.godot_icall_1_60(MethodBind3, GodotObject.GetPtr(this), (int)margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRegionRect, 2046264180ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRegionRect(Rect2 rect)
    {
        NativeCalls.godot_icall_1_188(MethodBind4, GodotObject.GetPtr(this), &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRegionRect, 1639390495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2 GetRegionRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawCenter, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawCenter(bool drawCenter)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), drawCenter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawCenterEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawCenterEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHAxisStretchMode, 3219608417ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHAxisStretchMode(NinePatchRect.AxisStretchMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHAxisStretchMode, 3317113799ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NinePatchRect.AxisStretchMode GetHAxisStretchMode()
    {
        return (NinePatchRect.AxisStretchMode)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVAxisStretchMode, 3219608417ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVAxisStretchMode(NinePatchRect.AxisStretchMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVAxisStretchMode, 3317113799ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NinePatchRect.AxisStretchMode GetVAxisStretchMode()
    {
        return (NinePatchRect.AxisStretchMode)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the node's texture changes.</para>
    /// </summary>
    public event Action TextureChanged
    {
        add => Connect(SignalName.TextureChanged, Callable.From(value));
        remove => Disconnect(SignalName.TextureChanged, Callable.From(value));
    }

    protected void EmitSignalTextureChanged()
    {
        EmitSignal(SignalName.TextureChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_texture_changed = "TextureChanged";

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
        if (signal == SignalName.TextureChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_texture_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Control.PropertyName
    {
        /// <summary>
        /// Cached name for the 'texture' property.
        /// </summary>
        public static readonly StringName Texture = "texture";
        /// <summary>
        /// Cached name for the 'draw_center' property.
        /// </summary>
        public static readonly StringName DrawCenter = "draw_center";
        /// <summary>
        /// Cached name for the 'region_rect' property.
        /// </summary>
        public static readonly StringName RegionRect = "region_rect";
        /// <summary>
        /// Cached name for the 'patch_margin_left' property.
        /// </summary>
        public static readonly StringName PatchMarginLeft = "patch_margin_left";
        /// <summary>
        /// Cached name for the 'patch_margin_top' property.
        /// </summary>
        public static readonly StringName PatchMarginTop = "patch_margin_top";
        /// <summary>
        /// Cached name for the 'patch_margin_right' property.
        /// </summary>
        public static readonly StringName PatchMarginRight = "patch_margin_right";
        /// <summary>
        /// Cached name for the 'patch_margin_bottom' property.
        /// </summary>
        public static readonly StringName PatchMarginBottom = "patch_margin_bottom";
        /// <summary>
        /// Cached name for the 'axis_stretch_horizontal' property.
        /// </summary>
        public static readonly StringName AxisStretchHorizontal = "axis_stretch_horizontal";
        /// <summary>
        /// Cached name for the 'axis_stretch_vertical' property.
        /// </summary>
        public static readonly StringName AxisStretchVertical = "axis_stretch_vertical";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
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
        /// Cached name for the 'set_patch_margin' method.
        /// </summary>
        public static readonly StringName SetPatchMargin = "set_patch_margin";
        /// <summary>
        /// Cached name for the 'get_patch_margin' method.
        /// </summary>
        public static readonly StringName GetPatchMargin = "get_patch_margin";
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
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'texture_changed' signal.
        /// </summary>
        public static readonly StringName TextureChanged = "texture_changed";
    }
}
