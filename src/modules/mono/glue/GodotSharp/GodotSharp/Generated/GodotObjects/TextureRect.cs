namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A control that displays a texture, for example an icon inside a GUI. The texture's placement can be controlled with the <see cref="Godot.TextureRect.StretchMode"/> property. It can scale, tile, or stay centered inside its bounding rectangle.</para>
/// </summary>
public partial class TextureRect : Control
{
    public enum ExpandModeEnum : long
    {
        /// <summary>
        /// <para>The minimum size will be equal to texture size, i.e. <see cref="Godot.TextureRect"/> can't be smaller than the texture.</para>
        /// </summary>
        KeepSize = 0,
        /// <summary>
        /// <para>The size of the texture won't be considered for minimum size calculation, so the <see cref="Godot.TextureRect"/> can be shrunk down past the texture size.</para>
        /// </summary>
        IgnoreSize = 1,
        /// <summary>
        /// <para>The height of the texture will be ignored. Minimum width will be equal to the current height. Useful for horizontal layouts, e.g. inside <see cref="Godot.HBoxContainer"/>.</para>
        /// </summary>
        FitWidth = 2,
        /// <summary>
        /// <para>Same as <see cref="Godot.TextureRect.ExpandModeEnum.FitWidth"/>, but keeps texture's aspect ratio.</para>
        /// </summary>
        FitWidthProportional = 3,
        /// <summary>
        /// <para>The width of the texture will be ignored. Minimum height will be equal to the current width. Useful for vertical layouts, e.g. inside <see cref="Godot.VBoxContainer"/>.</para>
        /// </summary>
        FitHeight = 4,
        /// <summary>
        /// <para>Same as <see cref="Godot.TextureRect.ExpandModeEnum.FitHeight"/>, but keeps texture's aspect ratio.</para>
        /// </summary>
        FitHeightProportional = 5
    }

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
        /// <para>Scale the texture to fit the node's bounding rectangle, center it and maintain its aspect ratio.</para>
        /// </summary>
        KeepAspectCentered = 5,
        /// <summary>
        /// <para>Scale the texture so that the shorter side fits the bounding rectangle. The other side clips to the node's limits.</para>
        /// </summary>
        KeepAspectCovered = 6
    }

    /// <summary>
    /// <para>The node's <see cref="Godot.Texture2D"/> resource.</para>
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
    /// <para>Defines how minimum size is determined based on the texture's size.</para>
    /// </summary>
    public TextureRect.ExpandModeEnum ExpandMode
    {
        get
        {
            return GetExpandMode();
        }
        set
        {
            SetExpandMode(value);
        }
    }

    /// <summary>
    /// <para>Controls the texture's behavior when resizing the node's bounding rectangle.</para>
    /// </summary>
    public TextureRect.StretchModeEnum StretchMode
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

    private static readonly System.Type CachedType = typeof(TextureRect);

    private static readonly StringName NativeName = "TextureRect";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TextureRect() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TextureRect(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TextureRect(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExpandMode, 1870766882ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExpandMode(TextureRect.ExpandModeEnum expandMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)expandMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExpandMode, 3863824733ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextureRect.ExpandModeEnum GetExpandMode()
    {
        return (TextureRect.ExpandModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipH, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipH(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlippedH, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlippedH()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipV, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipV(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlippedV, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlippedV()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStretchMode, 58788729ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStretchMode(TextureRect.StretchModeEnum stretchMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)stretchMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStretchMode, 346396079ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextureRect.StretchModeEnum GetStretchMode()
    {
        return (TextureRect.StretchModeEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
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
    public new class PropertyName : Control.PropertyName
    {
        /// <summary>
        /// Cached name for the 'texture' property.
        /// </summary>
        public static readonly StringName Texture = "texture";
        /// <summary>
        /// Cached name for the 'expand_mode' property.
        /// </summary>
        public static readonly StringName ExpandMode = "expand_mode";
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
        /// Cached name for the 'set_expand_mode' method.
        /// </summary>
        public static readonly StringName SetExpandMode = "set_expand_mode";
        /// <summary>
        /// Cached name for the 'get_expand_mode' method.
        /// </summary>
        public static readonly StringName GetExpandMode = "get_expand_mode";
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
        /// Cached name for the 'set_stretch_mode' method.
        /// </summary>
        public static readonly StringName SetStretchMode = "set_stretch_mode";
        /// <summary>
        /// Cached name for the 'get_stretch_mode' method.
        /// </summary>
        public static readonly StringName GetStretchMode = "get_stretch_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
    }
}
