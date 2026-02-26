namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Casts light in a 2D environment. A light is defined as a color, an energy value, a mode (see constants), and various other parameters (range and shadows-related).</para>
/// </summary>
public partial class Light2D : Node2D
{
    public enum ShadowFilterEnum : long
    {
        /// <summary>
        /// <para>No filter applies to the shadow map. This provides hard shadow edges and is the fastest to render. See <see cref="Godot.Light2D.ShadowFilter"/>.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Percentage closer filtering (5 samples) applies to the shadow map. This is slower compared to hard shadow rendering. See <see cref="Godot.Light2D.ShadowFilter"/>.</para>
        /// </summary>
        Pcf5 = 1,
        /// <summary>
        /// <para>Percentage closer filtering (13 samples) applies to the shadow map. This is the slowest shadow filtering mode, and should be used sparingly. See <see cref="Godot.Light2D.ShadowFilter"/>.</para>
        /// </summary>
        Pcf13 = 2
    }

    public enum BlendModeEnum : long
    {
        /// <summary>
        /// <para>Adds the value of pixels corresponding to the Light2D to the values of pixels under it. This is the common behavior of a light.</para>
        /// </summary>
        Add = 0,
        /// <summary>
        /// <para>Subtracts the value of pixels corresponding to the Light2D to the values of pixels under it, resulting in inversed light effect.</para>
        /// </summary>
        Sub = 1,
        /// <summary>
        /// <para>Mix the value of pixels corresponding to the Light2D to the values of pixels under it by linear interpolation.</para>
        /// </summary>
        Mix = 2
    }

    /// <summary>
    /// <para>If <see langword="true"/>, Light2D will emit light.</para>
    /// </summary>
    public bool Enabled
    {
        get
        {
            return IsEnabled();
        }
        set
        {
            SetEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, Light2D will only appear when editing the scene.</para>
    /// </summary>
    public bool EditorOnly
    {
        get
        {
            return IsEditorOnly();
        }
        set
        {
            SetEditorOnly(value);
        }
    }

    /// <summary>
    /// <para>The Light2D's <see cref="Godot.Color"/>.</para>
    /// </summary>
    public Color Color
    {
        get
        {
            return GetColor();
        }
        set
        {
            SetColor(value);
        }
    }

    /// <summary>
    /// <para>The Light2D's energy value. The larger the value, the stronger the light.</para>
    /// </summary>
    public float Energy
    {
        get
        {
            return GetEnergy();
        }
        set
        {
            SetEnergy(value);
        }
    }

    /// <summary>
    /// <para>The Light2D's blend mode.</para>
    /// </summary>
    public Light2D.BlendModeEnum BlendMode
    {
        get
        {
            return GetBlendMode();
        }
        set
        {
            SetBlendMode(value);
        }
    }

    /// <summary>
    /// <para>Minimum <c>z</c> value of objects that are affected by the Light2D.</para>
    /// </summary>
    public int RangeZMin
    {
        get
        {
            return GetZRangeMin();
        }
        set
        {
            SetZRangeMin(value);
        }
    }

    /// <summary>
    /// <para>Maximum <c>z</c> value of objects that are affected by the Light2D.</para>
    /// </summary>
    public int RangeZMax
    {
        get
        {
            return GetZRangeMax();
        }
        set
        {
            SetZRangeMax(value);
        }
    }

    /// <summary>
    /// <para>Minimum layer value of objects that are affected by the Light2D.</para>
    /// </summary>
    public int RangeLayerMin
    {
        get
        {
            return GetLayerRangeMin();
        }
        set
        {
            SetLayerRangeMin(value);
        }
    }

    /// <summary>
    /// <para>Maximum layer value of objects that are affected by the Light2D.</para>
    /// </summary>
    public int RangeLayerMax
    {
        get
        {
            return GetLayerRangeMax();
        }
        set
        {
            SetLayerRangeMax(value);
        }
    }

    /// <summary>
    /// <para>The layer mask. Only objects with a matching <see cref="Godot.CanvasItem.LightMask"/> will be affected by the Light2D. See also <see cref="Godot.Light2D.ShadowItemCullMask"/>, which affects which objects can cast shadows.</para>
    /// <para><b>Note:</b> <see cref="Godot.Light2D.RangeItemCullMask"/> is ignored by <see cref="Godot.DirectionalLight2D"/>, which will always light a 2D node regardless of the 2D node's <see cref="Godot.CanvasItem.LightMask"/>.</para>
    /// </summary>
    public int RangeItemCullMask
    {
        get
        {
            return GetItemCullMask();
        }
        set
        {
            SetItemCullMask(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the Light2D will cast shadows.</para>
    /// </summary>
    public bool ShadowEnabled
    {
        get
        {
            return IsShadowEnabled();
        }
        set
        {
            SetShadowEnabled(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Color"/> of shadows cast by the Light2D.</para>
    /// </summary>
    public Color ShadowColor
    {
        get
        {
            return GetShadowColor();
        }
        set
        {
            SetShadowColor(value);
        }
    }

    /// <summary>
    /// <para>Shadow filter type.</para>
    /// </summary>
    public Light2D.ShadowFilterEnum ShadowFilter
    {
        get
        {
            return GetShadowFilter();
        }
        set
        {
            SetShadowFilter(value);
        }
    }

    /// <summary>
    /// <para>Smoothing value for shadows. Higher values will result in softer shadows, at the cost of visible streaks that can appear in shadow rendering. <see cref="Godot.Light2D.ShadowFilterSmooth"/> only has an effect if <see cref="Godot.Light2D.ShadowFilter"/> is <see cref="Godot.Light2D.ShadowFilterEnum.Pcf5"/> or <see cref="Godot.Light2D.ShadowFilterEnum.Pcf13"/>.</para>
    /// </summary>
    public float ShadowFilterSmooth
    {
        get
        {
            return GetShadowSmooth();
        }
        set
        {
            SetShadowSmooth(value);
        }
    }

    /// <summary>
    /// <para>The shadow mask. Used with <see cref="Godot.LightOccluder2D"/> to cast shadows. Only occluders with a matching <see cref="Godot.CanvasItem.LightMask"/> will cast shadows. See also <see cref="Godot.Light2D.RangeItemCullMask"/>, which affects which objects can <i>receive</i> the light.</para>
    /// </summary>
    public int ShadowItemCullMask
    {
        get
        {
            return GetItemShadowCullMask();
        }
        set
        {
            SetItemShadowCullMask(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Light2D);

    private static readonly StringName NativeName = "Light2D";

    internal Light2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Light2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Light2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditorOnly, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditorOnly(bool editorOnly)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), editorOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditorOnly, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditorOnly()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind4, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnergy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnergy(float energy)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), energy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnergy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEnergy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZRangeMin, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetZRangeMin(int z)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), z);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetZRangeMin, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetZRangeMin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZRangeMax, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetZRangeMax(int z)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), z);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetZRangeMax, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetZRangeMax()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerRangeMin, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLayerRangeMin(int layer)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerRangeMin, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetLayerRangeMin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerRangeMax, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLayerRangeMax(int layer)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerRangeMax, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetLayerRangeMax()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemCullMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetItemCullMask(int itemCullMask)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), itemCullMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemCullMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetItemCullMask()
    {
        return NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemShadowCullMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetItemShadowCullMask(int itemShadowCullMask)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), itemShadowCullMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemShadowCullMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetItemShadowCullMask()
    {
        return NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShadowEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShadowEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowSmooth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowSmooth(float smooth)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), smooth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowSmooth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetShadowSmooth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowFilter, 3209356555ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowFilter(Light2D.ShadowFilterEnum filter)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowFilter, 1973619177ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Light2D.ShadowFilterEnum GetShadowFilter()
    {
        return (Light2D.ShadowFilterEnum)NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetShadowColor(Color shadowColor)
    {
        NativeCalls.godot_icall_1_213(MethodBind26, GodotObject.GetPtr(this), &shadowColor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetShadowColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendMode, 2916638796ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlendMode(Light2D.BlendModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendMode, 936255250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Light2D.BlendModeEnum GetBlendMode()
    {
        return (Light2D.BlendModeEnum)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeight, 373806689ul);

    /// <summary>
    /// <para>Sets the light's height, which is used in 2D normal mapping. See <see cref="Godot.PointLight2D.Height"/> and <see cref="Godot.DirectionalLight2D.Height"/>.</para>
    /// </summary>
    public void SetHeight(float height)
    {
        NativeCalls.godot_icall_1_67(MethodBind30, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeight, 1740695150ul);

    /// <summary>
    /// <para>Returns the light's height, which is used in 2D normal mapping. See <see cref="Godot.PointLight2D.Height"/> and <see cref="Godot.DirectionalLight2D.Height"/>.</para>
    /// </summary>
    public float GetHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'enabled' property.
        /// </summary>
        public static readonly StringName Enabled = "enabled";
        /// <summary>
        /// Cached name for the 'editor_only' property.
        /// </summary>
        public static readonly StringName EditorOnly = "editor_only";
        /// <summary>
        /// Cached name for the 'color' property.
        /// </summary>
        public static readonly StringName Color = "color";
        /// <summary>
        /// Cached name for the 'energy' property.
        /// </summary>
        public static readonly StringName Energy = "energy";
        /// <summary>
        /// Cached name for the 'blend_mode' property.
        /// </summary>
        public static readonly StringName BlendMode = "blend_mode";
        /// <summary>
        /// Cached name for the 'range_z_min' property.
        /// </summary>
        public static readonly StringName RangeZMin = "range_z_min";
        /// <summary>
        /// Cached name for the 'range_z_max' property.
        /// </summary>
        public static readonly StringName RangeZMax = "range_z_max";
        /// <summary>
        /// Cached name for the 'range_layer_min' property.
        /// </summary>
        public static readonly StringName RangeLayerMin = "range_layer_min";
        /// <summary>
        /// Cached name for the 'range_layer_max' property.
        /// </summary>
        public static readonly StringName RangeLayerMax = "range_layer_max";
        /// <summary>
        /// Cached name for the 'range_item_cull_mask' property.
        /// </summary>
        public static readonly StringName RangeItemCullMask = "range_item_cull_mask";
        /// <summary>
        /// Cached name for the 'shadow_enabled' property.
        /// </summary>
        public static readonly StringName ShadowEnabled = "shadow_enabled";
        /// <summary>
        /// Cached name for the 'shadow_color' property.
        /// </summary>
        public static readonly StringName ShadowColor = "shadow_color";
        /// <summary>
        /// Cached name for the 'shadow_filter' property.
        /// </summary>
        public static readonly StringName ShadowFilter = "shadow_filter";
        /// <summary>
        /// Cached name for the 'shadow_filter_smooth' property.
        /// </summary>
        public static readonly StringName ShadowFilterSmooth = "shadow_filter_smooth";
        /// <summary>
        /// Cached name for the 'shadow_item_cull_mask' property.
        /// </summary>
        public static readonly StringName ShadowItemCullMask = "shadow_item_cull_mask";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_enabled' method.
        /// </summary>
        public static readonly StringName SetEnabled = "set_enabled";
        /// <summary>
        /// Cached name for the 'is_enabled' method.
        /// </summary>
        public static readonly StringName IsEnabled = "is_enabled";
        /// <summary>
        /// Cached name for the 'set_editor_only' method.
        /// </summary>
        public static readonly StringName SetEditorOnly = "set_editor_only";
        /// <summary>
        /// Cached name for the 'is_editor_only' method.
        /// </summary>
        public static readonly StringName IsEditorOnly = "is_editor_only";
        /// <summary>
        /// Cached name for the 'set_color' method.
        /// </summary>
        public static readonly StringName SetColor = "set_color";
        /// <summary>
        /// Cached name for the 'get_color' method.
        /// </summary>
        public static readonly StringName GetColor = "get_color";
        /// <summary>
        /// Cached name for the 'set_energy' method.
        /// </summary>
        public static readonly StringName SetEnergy = "set_energy";
        /// <summary>
        /// Cached name for the 'get_energy' method.
        /// </summary>
        public static readonly StringName GetEnergy = "get_energy";
        /// <summary>
        /// Cached name for the 'set_z_range_min' method.
        /// </summary>
        public static readonly StringName SetZRangeMin = "set_z_range_min";
        /// <summary>
        /// Cached name for the 'get_z_range_min' method.
        /// </summary>
        public static readonly StringName GetZRangeMin = "get_z_range_min";
        /// <summary>
        /// Cached name for the 'set_z_range_max' method.
        /// </summary>
        public static readonly StringName SetZRangeMax = "set_z_range_max";
        /// <summary>
        /// Cached name for the 'get_z_range_max' method.
        /// </summary>
        public static readonly StringName GetZRangeMax = "get_z_range_max";
        /// <summary>
        /// Cached name for the 'set_layer_range_min' method.
        /// </summary>
        public static readonly StringName SetLayerRangeMin = "set_layer_range_min";
        /// <summary>
        /// Cached name for the 'get_layer_range_min' method.
        /// </summary>
        public static readonly StringName GetLayerRangeMin = "get_layer_range_min";
        /// <summary>
        /// Cached name for the 'set_layer_range_max' method.
        /// </summary>
        public static readonly StringName SetLayerRangeMax = "set_layer_range_max";
        /// <summary>
        /// Cached name for the 'get_layer_range_max' method.
        /// </summary>
        public static readonly StringName GetLayerRangeMax = "get_layer_range_max";
        /// <summary>
        /// Cached name for the 'set_item_cull_mask' method.
        /// </summary>
        public static readonly StringName SetItemCullMask = "set_item_cull_mask";
        /// <summary>
        /// Cached name for the 'get_item_cull_mask' method.
        /// </summary>
        public static readonly StringName GetItemCullMask = "get_item_cull_mask";
        /// <summary>
        /// Cached name for the 'set_item_shadow_cull_mask' method.
        /// </summary>
        public static readonly StringName SetItemShadowCullMask = "set_item_shadow_cull_mask";
        /// <summary>
        /// Cached name for the 'get_item_shadow_cull_mask' method.
        /// </summary>
        public static readonly StringName GetItemShadowCullMask = "get_item_shadow_cull_mask";
        /// <summary>
        /// Cached name for the 'set_shadow_enabled' method.
        /// </summary>
        public static readonly StringName SetShadowEnabled = "set_shadow_enabled";
        /// <summary>
        /// Cached name for the 'is_shadow_enabled' method.
        /// </summary>
        public static readonly StringName IsShadowEnabled = "is_shadow_enabled";
        /// <summary>
        /// Cached name for the 'set_shadow_smooth' method.
        /// </summary>
        public static readonly StringName SetShadowSmooth = "set_shadow_smooth";
        /// <summary>
        /// Cached name for the 'get_shadow_smooth' method.
        /// </summary>
        public static readonly StringName GetShadowSmooth = "get_shadow_smooth";
        /// <summary>
        /// Cached name for the 'set_shadow_filter' method.
        /// </summary>
        public static readonly StringName SetShadowFilter = "set_shadow_filter";
        /// <summary>
        /// Cached name for the 'get_shadow_filter' method.
        /// </summary>
        public static readonly StringName GetShadowFilter = "get_shadow_filter";
        /// <summary>
        /// Cached name for the 'set_shadow_color' method.
        /// </summary>
        public static readonly StringName SetShadowColor = "set_shadow_color";
        /// <summary>
        /// Cached name for the 'get_shadow_color' method.
        /// </summary>
        public static readonly StringName GetShadowColor = "get_shadow_color";
        /// <summary>
        /// Cached name for the 'set_blend_mode' method.
        /// </summary>
        public static readonly StringName SetBlendMode = "set_blend_mode";
        /// <summary>
        /// Cached name for the 'get_blend_mode' method.
        /// </summary>
        public static readonly StringName GetBlendMode = "get_blend_mode";
        /// <summary>
        /// Cached name for the 'set_height' method.
        /// </summary>
        public static readonly StringName SetHeight = "set_height";
        /// <summary>
        /// Cached name for the 'get_height' method.
        /// </summary>
        public static readonly StringName GetHeight = "get_height";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
