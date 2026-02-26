namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.TextureButton"/> has the same functionality as <see cref="Godot.Button"/>, except it uses sprites instead of Godot's <see cref="Godot.Theme"/> resource. It is faster to create, but it doesn't support localization like more complex <see cref="Godot.Control"/>s.</para>
/// <para>See also <see cref="Godot.BaseButton"/> which contains common properties and methods associated with this node.</para>
/// <para><b>Note:</b> Setting a texture for the "normal" state (<see cref="Godot.TextureButton.TextureNormal"/>) is recommended. If <see cref="Godot.TextureButton.TextureNormal"/> is not set, the <see cref="Godot.TextureButton"/> will still receive input events and be clickable, but the user will not be able to see it unless they activate another one of its states with a texture assigned (e.g., hover over it to show <see cref="Godot.TextureButton.TextureHover"/>).</para>
/// </summary>
public partial class TextureButton : BaseButton
{
    public enum StretchModeEnum : long
    {
        /// <summary>
        /// <para>Scale to fit the node's bounding rectangle.</para>
        /// </summary>
        Scale = 0,
        /// <summary>
        /// <para>Tile inside the node's bounding rectangle.</para>
        /// </summary>
        Tile = 1,
        /// <summary>
        /// <para>The texture keeps its original size and stays in the bounding rectangle's top-left corner.</para>
        /// </summary>
        Keep = 2,
        /// <summary>
        /// <para>The texture keeps its original size and stays centered in the node's bounding rectangle.</para>
        /// </summary>
        KeepCentered = 3,
        /// <summary>
        /// <para>Scale the texture to fit the node's bounding rectangle, but maintain the texture's aspect ratio.</para>
        /// </summary>
        KeepAspect = 4,
        /// <summary>
        /// <para>Scale the texture to fit the node's bounding rectangle, center it, and maintain its aspect ratio.</para>
        /// </summary>
        KeepAspectCentered = 5,
        /// <summary>
        /// <para>Scale the texture so that the shorter side fits the bounding rectangle. The other side clips to the node's limits.</para>
        /// </summary>
        KeepAspectCovered = 6
    }

    /// <summary>
    /// <para>Texture to display by default, when the node is <b>not</b> in the disabled, hover or pressed state. This texture is still displayed in the focused state, with <see cref="Godot.TextureButton.TextureFocused"/> drawn on top.</para>
    /// </summary>
    public Texture2D TextureNormal
    {
        get
        {
            return GetTextureNormal();
        }
        set
        {
            SetTextureNormal(value);
        }
    }

    /// <summary>
    /// <para>Texture to display on mouse down over the node, if the node has keyboard focus and the player presses the Enter key or if the player presses the <see cref="Godot.BaseButton.Shortcut"/> key. If not assigned, the <see cref="Godot.TextureButton"/> displays <see cref="Godot.TextureButton.TextureHover"/> instead when pressed.</para>
    /// </summary>
    public Texture2D TexturePressed
    {
        get
        {
            return GetTexturePressed();
        }
        set
        {
            SetTexturePressed(value);
        }
    }

    /// <summary>
    /// <para>Texture to display when the mouse hovers over the node. If not assigned, the <see cref="Godot.TextureButton"/> displays <see cref="Godot.TextureButton.TextureNormal"/> instead when hovered over.</para>
    /// </summary>
    public Texture2D TextureHover
    {
        get
        {
            return GetTextureHover();
        }
        set
        {
            SetTextureHover(value);
        }
    }

    /// <summary>
    /// <para>Texture to display when the node is disabled. See <see cref="Godot.BaseButton.Disabled"/>. If not assigned, the <see cref="Godot.TextureButton"/> displays <see cref="Godot.TextureButton.TextureNormal"/> instead.</para>
    /// </summary>
    public Texture2D TextureDisabled
    {
        get
        {
            return GetTextureDisabled();
        }
        set
        {
            SetTextureDisabled(value);
        }
    }

    /// <summary>
    /// <para>Texture to <i>overlay on the base texture</i> when the node has mouse or keyboard focus. Because <see cref="Godot.TextureButton.TextureFocused"/> is displayed on top of the base texture, a partially transparent texture should be used to ensure the base texture remains visible. A texture that represents an outline or an underline works well for this purpose. To disable the focus visual effect, assign a fully transparent texture of any size. Note that disabling the focus visual effect will harm keyboard/controller navigation usability, so this is not recommended for accessibility reasons.</para>
    /// </summary>
    public Texture2D TextureFocused
    {
        get
        {
            return GetTextureFocused();
        }
        set
        {
            SetTextureFocused(value);
        }
    }

    /// <summary>
    /// <para>Pure black and white <see cref="Godot.Bitmap"/> image to use for click detection. On the mask, white pixels represent the button's clickable area. Use it to create buttons with curved shapes.</para>
    /// </summary>
    public Bitmap TextureClickMask
    {
        get
        {
            return GetClickMask();
        }
        set
        {
            SetClickMask(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the size of the texture won't be considered for minimum size calculation, so the <see cref="Godot.TextureButton"/> can be shrunk down past the texture size.</para>
    /// </summary>
    public bool IgnoreTextureSize
    {
        get
        {
            return GetIgnoreTextureSize();
        }
        set
        {
            SetIgnoreTextureSize(value);
        }
    }

    /// <summary>
    /// <para>Controls the texture's behavior when you resize the node's bounding rectangle. See the <see cref="Godot.TextureButton.StretchModeEnum"/> constants for available options.</para>
    /// </summary>
    public TextureButton.StretchModeEnum StretchMode
    {
        get
        {
            return GetStretchMode();
        }
        set
        {
            SetStretchMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, texture is flipped horizontally.</para>
    /// </summary>
    public bool FlipH
    {
        get
        {
            return IsFlippedH();
        }
        set
        {
            SetFlipH(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, texture is flipped vertically.</para>
    /// </summary>
    public bool FlipV
    {
        get
        {
            return IsFlippedV();
        }
        set
        {
            SetFlipV(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TextureButton);

    private static readonly StringName NativeName = "TextureButton";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TextureButton() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TextureButton(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TextureButton(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureNormal, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureNormal(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexturePressed, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexturePressed(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureHover, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureHover(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureDisabled, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureDisabled(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureFocused, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureFocused(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClickMask, 698588216ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClickMask(Bitmap mask)
    {
        NativeCalls.godot_icall_1_56(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(mask));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgnoreTextureSize, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgnoreTextureSize(bool ignore)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), ignore.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStretchMode, 252530840ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStretchMode(TextureButton.StretchModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipH, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipH(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlippedH, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlippedH()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipV, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipV(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlippedV, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlippedV()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureNormal, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTextureNormal()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexturePressed, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTexturePressed()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureHover, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTextureHover()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureDisabled, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTextureDisabled()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureFocused, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTextureFocused()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClickMask, 2459671998ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Bitmap GetClickMask()
    {
        return (Bitmap)NativeCalls.godot_icall_0_63(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIgnoreTextureSize, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetIgnoreTextureSize()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStretchMode, 33815122ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextureButton.StretchModeEnum GetStretchMode()
    {
        return (TextureButton.StretchModeEnum)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
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
    public new class PropertyName : BaseButton.PropertyName
    {
        /// <summary>
        /// Cached name for the 'texture_normal' property.
        /// </summary>
        public static readonly StringName TextureNormal = "texture_normal";
        /// <summary>
        /// Cached name for the 'texture_pressed' property.
        /// </summary>
        public static readonly StringName TexturePressed = "texture_pressed";
        /// <summary>
        /// Cached name for the 'texture_hover' property.
        /// </summary>
        public static readonly StringName TextureHover = "texture_hover";
        /// <summary>
        /// Cached name for the 'texture_disabled' property.
        /// </summary>
        public static readonly StringName TextureDisabled = "texture_disabled";
        /// <summary>
        /// Cached name for the 'texture_focused' property.
        /// </summary>
        public static readonly StringName TextureFocused = "texture_focused";
        /// <summary>
        /// Cached name for the 'texture_click_mask' property.
        /// </summary>
        public static readonly StringName TextureClickMask = "texture_click_mask";
        /// <summary>
        /// Cached name for the 'ignore_texture_size' property.
        /// </summary>
        public static readonly StringName IgnoreTextureSize = "ignore_texture_size";
        /// <summary>
        /// Cached name for the 'stretch_mode' property.
        /// </summary>
        public static readonly StringName StretchMode = "stretch_mode";
        /// <summary>
        /// Cached name for the 'flip_h' property.
        /// </summary>
        public static readonly StringName FlipH = "flip_h";
        /// <summary>
        /// Cached name for the 'flip_v' property.
        /// </summary>
        public static readonly StringName FlipV = "flip_v";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : BaseButton.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_texture_normal' method.
        /// </summary>
        public static readonly StringName SetTextureNormal = "set_texture_normal";
        /// <summary>
        /// Cached name for the 'set_texture_pressed' method.
        /// </summary>
        public static readonly StringName SetTexturePressed = "set_texture_pressed";
        /// <summary>
        /// Cached name for the 'set_texture_hover' method.
        /// </summary>
        public static readonly StringName SetTextureHover = "set_texture_hover";
        /// <summary>
        /// Cached name for the 'set_texture_disabled' method.
        /// </summary>
        public static readonly StringName SetTextureDisabled = "set_texture_disabled";
        /// <summary>
        /// Cached name for the 'set_texture_focused' method.
        /// </summary>
        public static readonly StringName SetTextureFocused = "set_texture_focused";
        /// <summary>
        /// Cached name for the 'set_click_mask' method.
        /// </summary>
        public static readonly StringName SetClickMask = "set_click_mask";
        /// <summary>
        /// Cached name for the 'set_ignore_texture_size' method.
        /// </summary>
        public static readonly StringName SetIgnoreTextureSize = "set_ignore_texture_size";
        /// <summary>
        /// Cached name for the 'set_stretch_mode' method.
        /// </summary>
        public static readonly StringName SetStretchMode = "set_stretch_mode";
        /// <summary>
        /// Cached name for the 'set_flip_h' method.
        /// </summary>
        public static readonly StringName SetFlipH = "set_flip_h";
        /// <summary>
        /// Cached name for the 'is_flipped_h' method.
        /// </summary>
        public static readonly StringName IsFlippedH = "is_flipped_h";
        /// <summary>
        /// Cached name for the 'set_flip_v' method.
        /// </summary>
        public static readonly StringName SetFlipV = "set_flip_v";
        /// <summary>
        /// Cached name for the 'is_flipped_v' method.
        /// </summary>
        public static readonly StringName IsFlippedV = "is_flipped_v";
        /// <summary>
        /// Cached name for the 'get_texture_normal' method.
        /// </summary>
        public static readonly StringName GetTextureNormal = "get_texture_normal";
        /// <summary>
        /// Cached name for the 'get_texture_pressed' method.
        /// </summary>
        public static readonly StringName GetTexturePressed = "get_texture_pressed";
        /// <summary>
        /// Cached name for the 'get_texture_hover' method.
        /// </summary>
        public static readonly StringName GetTextureHover = "get_texture_hover";
        /// <summary>
        /// Cached name for the 'get_texture_disabled' method.
        /// </summary>
        public static readonly StringName GetTextureDisabled = "get_texture_disabled";
        /// <summary>
        /// Cached name for the 'get_texture_focused' method.
        /// </summary>
        public static readonly StringName GetTextureFocused = "get_texture_focused";
        /// <summary>
        /// Cached name for the 'get_click_mask' method.
        /// </summary>
        public static readonly StringName GetClickMask = "get_click_mask";
        /// <summary>
        /// Cached name for the 'get_ignore_texture_size' method.
        /// </summary>
        public static readonly StringName GetIgnoreTextureSize = "get_ignore_texture_size";
        /// <summary>
        /// Cached name for the 'get_stretch_mode' method.
        /// </summary>
        public static readonly StringName GetStretchMode = "get_stretch_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : BaseButton.SignalName
    {
    }
}
