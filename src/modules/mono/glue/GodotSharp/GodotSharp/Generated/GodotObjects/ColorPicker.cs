namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A widget that provides an interface for selecting or modifying a color. It can optionally provide functionalities like a color sampler (eyedropper), color modes, and presets.</para>
/// <para><b>Note:</b> This control is the color picker widget itself. You can use a <see cref="Godot.ColorPickerButton"/> instead if you need a button that brings up a <see cref="Godot.ColorPicker"/> in a popup.</para>
/// </summary>
public partial class ColorPicker : VBoxContainer
{
    public enum ColorModeType : long
    {
        /// <summary>
        /// <para>Allows editing the color with Red/Green/Blue sliders in sRGB color space.</para>
        /// </summary>
        Rgb = 0,
        /// <summary>
        /// <para>Allows editing the color with Hue/Saturation/Value sliders.</para>
        /// </summary>
        Hsv = 1,
        [Obsolete("This is replaced by 'Godot.ColorPicker.ColorModeType.Linear'.")]
        Raw = 2,
        /// <summary>
        /// <para>Allows editing the color with Red/Green/Blue sliders in linear color space.</para>
        /// </summary>
        Linear = 2,
        /// <summary>
        /// <para>Allows editing the color with Hue/Saturation/Lightness sliders.</para>
        /// <para>OKHSL is a new color space similar to HSL but that better match perception by leveraging the Oklab color space which is designed to be simple to use, while doing a good job at predicting perceived lightness, chroma and hue.</para>
        /// <para><a href="https://bottosson.github.io/posts/colorpicker/">Okhsv and Okhsl color spaces</a></para>
        /// </summary>
        Okhsl = 3
    }

    public enum PickerShapeType : long
    {
        /// <summary>
        /// <para>HSV Color Model rectangle color space.</para>
        /// </summary>
        HsvRectangle = 0,
        /// <summary>
        /// <para>HSV Color Model rectangle color space with a wheel.</para>
        /// </summary>
        HsvWheel = 1,
        /// <summary>
        /// <para>HSV Color Model circle color space. Use Saturation as a radius.</para>
        /// </summary>
        VhsCircle = 2,
        /// <summary>
        /// <para>HSL OK Color Model circle color space.</para>
        /// </summary>
        OkhslCircle = 3,
        /// <summary>
        /// <para>The color space shape and the shape select button are hidden. Can't be selected from the shapes popup.</para>
        /// </summary>
        None = 4,
        /// <summary>
        /// <para>OKHSL Color Model rectangle with constant lightness.</para>
        /// </summary>
        OkHsRectangle = 5,
        /// <summary>
        /// <para>OKHSL Color Model rectangle with constant saturation.</para>
        /// </summary>
        OkHlRectangle = 6
    }

    /// <summary>
    /// <para>The currently selected color.</para>
    /// </summary>
    public Color Color
    {
        get
        {
            return GetPickColor();
        }
        set
        {
            SetPickColor(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, shows an alpha channel slider (opacity).</para>
    /// </summary>
    public bool EditAlpha
    {
        get
        {
            return IsEditingAlpha();
        }
        set
        {
            SetEditAlpha(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, shows an intensity slider. The intensity is applied as follows: convert the color to linear encoding, multiply it by <c>2 ** intensity</c>, and then convert it back to nonlinear sRGB encoding.</para>
    /// </summary>
    public bool EditIntensity
    {
        get
        {
            return IsEditingIntensity();
        }
        set
        {
            SetEditIntensity(value);
        }
    }

    /// <summary>
    /// <para>The currently selected color mode.</para>
    /// </summary>
    public ColorPicker.ColorModeType ColorMode
    {
        get
        {
            return GetColorMode();
        }
        set
        {
            SetColorMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the color will apply only after the user releases the mouse button, otherwise it will apply immediately even in mouse motion event (which can cause performance issues).</para>
    /// </summary>
    public bool DeferredMode
    {
        get
        {
            return IsDeferredMode();
        }
        set
        {
            SetDeferredMode(value);
        }
    }

    /// <summary>
    /// <para>The shape of the color space view.</para>
    /// </summary>
    public ColorPicker.PickerShapeType PickerShape
    {
        get
        {
            return GetPickerShape();
        }
        set
        {
            SetPickerShape(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, it's possible to add presets under Swatches. If <see langword="false"/>, the button to add presets is disabled.</para>
    /// </summary>
    public bool CanAddSwatches
    {
        get
        {
            return AreSwatchesEnabled();
        }
        set
        {
            SetCanAddSwatches(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the color sampler and color preview are visible.</para>
    /// </summary>
    public bool SamplerVisible
    {
        get
        {
            return IsSamplerVisible();
        }
        set
        {
            SetSamplerVisible(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the color mode buttons are visible.</para>
    /// </summary>
    public bool ColorModesVisible
    {
        get
        {
            return AreModesVisible();
        }
        set
        {
            SetModesVisible(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the color sliders are visible.</para>
    /// </summary>
    public bool SlidersVisible
    {
        get
        {
            return AreSlidersVisible();
        }
        set
        {
            SetSlidersVisible(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the hex color code input field is visible.</para>
    /// </summary>
    public bool HexVisible
    {
        get
        {
            return IsHexVisible();
        }
        set
        {
            SetHexVisible(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the Swatches and Recent Colors presets are visible.</para>
    /// </summary>
    public bool PresetsVisible
    {
        get
        {
            return ArePresetsVisible();
        }
        set
        {
            SetPresetsVisible(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ColorPicker);

    private static readonly StringName NativeName = "ColorPicker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ColorPicker() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ColorPicker(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ColorPicker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPickColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPickColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind0, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPickColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetPickColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeferredMode, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDeferredMode(bool mode)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), mode.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDeferredMode, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDeferredMode()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColorMode, 1579114136ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorMode(ColorPicker.ColorModeType colorMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)colorMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorMode, 392907674ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ColorPicker.ColorModeType GetColorMode()
    {
        return (ColorPicker.ColorModeType)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditAlpha, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditAlpha(bool show)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), show.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditingAlpha, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditingAlpha()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditIntensity, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditIntensity(bool show)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), show.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditingIntensity, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditingIntensity()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCanAddSwatches, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCanAddSwatches(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreSwatchesEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreSwatchesEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPresetsVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPresetsVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ArePresetsVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ArePresetsVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModesVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetModesVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreModesVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreModesVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSamplerVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSamplerVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSamplerVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSamplerVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSlidersVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSlidersVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreSlidersVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreSlidersVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHexVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHexVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHexVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHexVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPreset, 2920490490ul);

    /// <summary>
    /// <para>Adds the given color to a list of color presets. The presets are displayed in the color picker and the user will be able to select them.</para>
    /// <para><b>Note:</b> The presets list is only for <i>this</i> color picker.</para>
    /// </summary>
    public unsafe void AddPreset(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind22, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ErasePreset, 2920490490ul);

    /// <summary>
    /// <para>Removes the given color from the list of color presets of this color picker.</para>
    /// </summary>
    public unsafe void ErasePreset(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind23, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPresets, 1392750486ul);

    /// <summary>
    /// <para>Returns the list of colors in the presets of the color picker.</para>
    /// </summary>
    public Color[] GetPresets()
    {
        return NativeCalls.godot_icall_0_227(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddRecentPreset, 2920490490ul);

    /// <summary>
    /// <para>Adds the given color to a list of color recent presets so that it can be picked later. Recent presets are the colors that were picked recently, a new preset is automatically created and added to recent presets when you pick a new color.</para>
    /// <para><b>Note:</b> The recent presets list is only for <i>this</i> color picker.</para>
    /// </summary>
    public unsafe void AddRecentPreset(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind25, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseRecentPreset, 2920490490ul);

    /// <summary>
    /// <para>Removes the given color from the list of color recent presets of this color picker.</para>
    /// </summary>
    public unsafe void EraseRecentPreset(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind26, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRecentPresets, 1392750486ul);

    /// <summary>
    /// <para>Returns the list of colors in the recent presets of the color picker.</para>
    /// </summary>
    public Color[] GetRecentPresets()
    {
        return NativeCalls.godot_icall_0_227(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPickerShape, 3981373861ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPickerShape(ColorPicker.PickerShapeType shape)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPickerShape, 1143229889ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ColorPicker.PickerShapeType GetPickerShape()
    {
        return (ColorPicker.PickerShapeType)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ColorPicker.ColorChanged"/> event of a <see cref="Godot.ColorPicker"/> class.
    /// </summary>
    public delegate void ColorChangedEventHandler(Color color);

    private static void ColorChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ColorChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Color>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the color is changed.</para>
    /// </summary>
    public unsafe event ColorChangedEventHandler ColorChanged
    {
        add => Connect(SignalName.ColorChanged, Callable.CreateWithUnsafeTrampoline(value, &ColorChangedTrampoline));
        remove => Disconnect(SignalName.ColorChanged, Callable.CreateWithUnsafeTrampoline(value, &ColorChangedTrampoline));
    }

    protected void EmitSignalColorChanged(Color color)
    {
        EmitSignal(SignalName.ColorChanged, color);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ColorPicker.PresetAdded"/> event of a <see cref="Godot.ColorPicker"/> class.
    /// </summary>
    public delegate void PresetAddedEventHandler(Color color);

    private static void PresetAddedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PresetAddedEventHandler)delegateObj)(VariantUtils.ConvertTo<Color>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a preset is added.</para>
    /// </summary>
    public unsafe event PresetAddedEventHandler PresetAdded
    {
        add => Connect(SignalName.PresetAdded, Callable.CreateWithUnsafeTrampoline(value, &PresetAddedTrampoline));
        remove => Disconnect(SignalName.PresetAdded, Callable.CreateWithUnsafeTrampoline(value, &PresetAddedTrampoline));
    }

    protected void EmitSignalPresetAdded(Color color)
    {
        EmitSignal(SignalName.PresetAdded, color);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ColorPicker.PresetRemoved"/> event of a <see cref="Godot.ColorPicker"/> class.
    /// </summary>
    public delegate void PresetRemovedEventHandler(Color color);

    private static void PresetRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PresetRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<Color>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a preset is removed.</para>
    /// </summary>
    public unsafe event PresetRemovedEventHandler PresetRemoved
    {
        add => Connect(SignalName.PresetRemoved, Callable.CreateWithUnsafeTrampoline(value, &PresetRemovedTrampoline));
        remove => Disconnect(SignalName.PresetRemoved, Callable.CreateWithUnsafeTrampoline(value, &PresetRemovedTrampoline));
    }

    protected void EmitSignalPresetRemoved(Color color)
    {
        EmitSignal(SignalName.PresetRemoved, color);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_color_changed = "ColorChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_preset_added = "PresetAdded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_preset_removed = "PresetRemoved";

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
        if (signal == SignalName.ColorChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_color_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PresetAdded)
        {
            if (HasGodotClassSignal(SignalProxyName_preset_added.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PresetRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_preset_removed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : VBoxContainer.PropertyName
    {
        /// <summary>
        /// Cached name for the 'color' property.
        /// </summary>
        public static readonly StringName Color = "color";
        /// <summary>
        /// Cached name for the 'edit_alpha' property.
        /// </summary>
        public static readonly StringName EditAlpha = "edit_alpha";
        /// <summary>
        /// Cached name for the 'edit_intensity' property.
        /// </summary>
        public static readonly StringName EditIntensity = "edit_intensity";
        /// <summary>
        /// Cached name for the 'color_mode' property.
        /// </summary>
        public static readonly StringName ColorMode = "color_mode";
        /// <summary>
        /// Cached name for the 'deferred_mode' property.
        /// </summary>
        public static readonly StringName DeferredMode = "deferred_mode";
        /// <summary>
        /// Cached name for the 'picker_shape' property.
        /// </summary>
        public static readonly StringName PickerShape = "picker_shape";
        /// <summary>
        /// Cached name for the 'can_add_swatches' property.
        /// </summary>
        public static readonly StringName CanAddSwatches = "can_add_swatches";
        /// <summary>
        /// Cached name for the 'sampler_visible' property.
        /// </summary>
        public static readonly StringName SamplerVisible = "sampler_visible";
        /// <summary>
        /// Cached name for the 'color_modes_visible' property.
        /// </summary>
        public static readonly StringName ColorModesVisible = "color_modes_visible";
        /// <summary>
        /// Cached name for the 'sliders_visible' property.
        /// </summary>
        public static readonly StringName SlidersVisible = "sliders_visible";
        /// <summary>
        /// Cached name for the 'hex_visible' property.
        /// </summary>
        public static readonly StringName HexVisible = "hex_visible";
        /// <summary>
        /// Cached name for the 'presets_visible' property.
        /// </summary>
        public static readonly StringName PresetsVisible = "presets_visible";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VBoxContainer.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_pick_color' method.
        /// </summary>
        public static readonly StringName SetPickColor = "set_pick_color";
        /// <summary>
        /// Cached name for the 'get_pick_color' method.
        /// </summary>
        public static readonly StringName GetPickColor = "get_pick_color";
        /// <summary>
        /// Cached name for the 'set_deferred_mode' method.
        /// </summary>
        public static readonly StringName SetDeferredMode = "set_deferred_mode";
        /// <summary>
        /// Cached name for the 'is_deferred_mode' method.
        /// </summary>
        public static readonly StringName IsDeferredMode = "is_deferred_mode";
        /// <summary>
        /// Cached name for the 'set_color_mode' method.
        /// </summary>
        public static readonly StringName SetColorMode = "set_color_mode";
        /// <summary>
        /// Cached name for the 'get_color_mode' method.
        /// </summary>
        public static readonly StringName GetColorMode = "get_color_mode";
        /// <summary>
        /// Cached name for the 'set_edit_alpha' method.
        /// </summary>
        public static readonly StringName SetEditAlpha = "set_edit_alpha";
        /// <summary>
        /// Cached name for the 'is_editing_alpha' method.
        /// </summary>
        public static readonly StringName IsEditingAlpha = "is_editing_alpha";
        /// <summary>
        /// Cached name for the 'set_edit_intensity' method.
        /// </summary>
        public static readonly StringName SetEditIntensity = "set_edit_intensity";
        /// <summary>
        /// Cached name for the 'is_editing_intensity' method.
        /// </summary>
        public static readonly StringName IsEditingIntensity = "is_editing_intensity";
        /// <summary>
        /// Cached name for the 'set_can_add_swatches' method.
        /// </summary>
        public static readonly StringName SetCanAddSwatches = "set_can_add_swatches";
        /// <summary>
        /// Cached name for the 'are_swatches_enabled' method.
        /// </summary>
        public static readonly StringName AreSwatchesEnabled = "are_swatches_enabled";
        /// <summary>
        /// Cached name for the 'set_presets_visible' method.
        /// </summary>
        public static readonly StringName SetPresetsVisible = "set_presets_visible";
        /// <summary>
        /// Cached name for the 'are_presets_visible' method.
        /// </summary>
        public static readonly StringName ArePresetsVisible = "are_presets_visible";
        /// <summary>
        /// Cached name for the 'set_modes_visible' method.
        /// </summary>
        public static readonly StringName SetModesVisible = "set_modes_visible";
        /// <summary>
        /// Cached name for the 'are_modes_visible' method.
        /// </summary>
        public static readonly StringName AreModesVisible = "are_modes_visible";
        /// <summary>
        /// Cached name for the 'set_sampler_visible' method.
        /// </summary>
        public static readonly StringName SetSamplerVisible = "set_sampler_visible";
        /// <summary>
        /// Cached name for the 'is_sampler_visible' method.
        /// </summary>
        public static readonly StringName IsSamplerVisible = "is_sampler_visible";
        /// <summary>
        /// Cached name for the 'set_sliders_visible' method.
        /// </summary>
        public static readonly StringName SetSlidersVisible = "set_sliders_visible";
        /// <summary>
        /// Cached name for the 'are_sliders_visible' method.
        /// </summary>
        public static readonly StringName AreSlidersVisible = "are_sliders_visible";
        /// <summary>
        /// Cached name for the 'set_hex_visible' method.
        /// </summary>
        public static readonly StringName SetHexVisible = "set_hex_visible";
        /// <summary>
        /// Cached name for the 'is_hex_visible' method.
        /// </summary>
        public static readonly StringName IsHexVisible = "is_hex_visible";
        /// <summary>
        /// Cached name for the 'add_preset' method.
        /// </summary>
        public static readonly StringName AddPreset = "add_preset";
        /// <summary>
        /// Cached name for the 'erase_preset' method.
        /// </summary>
        public static readonly StringName ErasePreset = "erase_preset";
        /// <summary>
        /// Cached name for the 'get_presets' method.
        /// </summary>
        public static readonly StringName GetPresets = "get_presets";
        /// <summary>
        /// Cached name for the 'add_recent_preset' method.
        /// </summary>
        public static readonly StringName AddRecentPreset = "add_recent_preset";
        /// <summary>
        /// Cached name for the 'erase_recent_preset' method.
        /// </summary>
        public static readonly StringName EraseRecentPreset = "erase_recent_preset";
        /// <summary>
        /// Cached name for the 'get_recent_presets' method.
        /// </summary>
        public static readonly StringName GetRecentPresets = "get_recent_presets";
        /// <summary>
        /// Cached name for the 'set_picker_shape' method.
        /// </summary>
        public static readonly StringName SetPickerShape = "set_picker_shape";
        /// <summary>
        /// Cached name for the 'get_picker_shape' method.
        /// </summary>
        public static readonly StringName GetPickerShape = "get_picker_shape";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VBoxContainer.SignalName
    {
        /// <summary>
        /// Cached name for the 'color_changed' signal.
        /// </summary>
        public static readonly StringName ColorChanged = "color_changed";
        /// <summary>
        /// Cached name for the 'preset_added' signal.
        /// </summary>
        public static readonly StringName PresetAdded = "preset_added";
        /// <summary>
        /// Cached name for the 'preset_removed' signal.
        /// </summary>
        public static readonly StringName PresetRemoved = "preset_removed";
    }
}
