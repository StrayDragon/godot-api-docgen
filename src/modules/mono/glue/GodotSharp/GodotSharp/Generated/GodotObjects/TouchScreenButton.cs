namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>TouchScreenButton allows you to create on-screen buttons for touch devices. It's intended for gameplay use, such as a unit you have to touch to move. Unlike <see cref="Godot.Button"/>, TouchScreenButton supports multitouch out of the box. Several TouchScreenButtons can be pressed at the same time with touch input.</para>
/// <para>This node inherits from <see cref="Godot.Node2D"/>. Unlike with <see cref="Godot.Control"/> nodes, you cannot set anchors on it. If you want to create menus or user interfaces, you may want to use <see cref="Godot.Button"/> nodes instead. To make button nodes react to touch events, you can enable <c>ProjectSettings.input_devices/pointing/emulate_mouse_from_touch</c> in the Project Settings.</para>
/// <para>You can configure TouchScreenButton to be visible only on touch devices, helping you develop your game both for desktop and mobile devices.</para>
/// </summary>
public partial class TouchScreenButton : Node2D
{
    public enum VisibilityModeEnum : long
    {
        /// <summary>
        /// <para>Always visible.</para>
        /// </summary>
        Always = 0,
        /// <summary>
        /// <para>Visible on touch screens only.</para>
        /// </summary>
        TouchscreenOnly = 1
    }

    /// <summary>
    /// <para>The button's texture for the normal state.</para>
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
    /// <para>The button's texture for the pressed state.</para>
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
    /// <para>The button's bitmask.</para>
    /// </summary>
    public Bitmap Bitmask
    {
        get
        {
            return GetBitmask();
        }
        set
        {
            SetBitmask(value);
        }
    }

    /// <summary>
    /// <para>The button's shape.</para>
    /// </summary>
    public Shape2D Shape
    {
        get
        {
            return GetShape();
        }
        set
        {
            SetShape(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button's shape is centered in the provided texture. If no texture is used, this property has no effect.</para>
    /// </summary>
    public bool ShapeCentered
    {
        get
        {
            return IsShapeCentered();
        }
        set
        {
            SetShapeCentered(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button's shape is visible in the editor.</para>
    /// </summary>
    public bool ShapeVisible
    {
        get
        {
            return IsShapeVisible();
        }
        set
        {
            SetShapeVisible(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.TouchScreenButton.Pressed"/> and <see cref="Godot.TouchScreenButton.Released"/> signals are emitted whenever a pressed finger goes in and out of the button, even if the pressure started outside the active area of the button.</para>
    /// <para><b>Note:</b> This is a "pass-by" (not "bypass") press mode.</para>
    /// </summary>
    public bool PassbyPress
    {
        get
        {
            return IsPassbyPressEnabled();
        }
        set
        {
            SetPassbyPress(value);
        }
    }

    /// <summary>
    /// <para>The button's action. Actions can be handled with <see cref="Godot.InputEventAction"/>.</para>
    /// </summary>
    public string Action
    {
        get
        {
            return GetAction();
        }
        set
        {
            SetAction(value);
        }
    }

    /// <summary>
    /// <para>The button's visibility mode.</para>
    /// </summary>
    public TouchScreenButton.VisibilityModeEnum VisibilityMode
    {
        get
        {
            return GetVisibilityMode();
        }
        set
        {
            SetVisibilityMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TouchScreenButton);

    private static readonly StringName NativeName = "TouchScreenButton";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TouchScreenButton() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TouchScreenButton(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TouchScreenButton(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureNormal, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureNormal(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureNormal, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTextureNormal()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexturePressed, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexturePressed(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexturePressed, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTexturePressed()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBitmask, 698588216ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBitmask(Bitmap bitmask)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(bitmask));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBitmask, 2459671998ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Bitmap GetBitmask()
    {
        return (Bitmap)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShape, 771364740ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShape(Shape2D shape)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(shape));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShape, 522005891ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Shape2D GetShape()
    {
        return (Shape2D)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShapeCentered, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShapeCentered(bool @bool)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), @bool.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShapeCentered, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShapeCentered()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShapeVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShapeVisible(bool @bool)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), @bool.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShapeVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShapeVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAction, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAction(string action)
    {
        NativeCalls.godot_icall_1_57(MethodBind12, GodotObject.GetPtr(this), action);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAction, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetAction()
    {
        return NativeCalls.godot_icall_0_58(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityMode, 3031128463ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityMode(TouchScreenButton.VisibilityModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityMode, 2558996468ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TouchScreenButton.VisibilityModeEnum GetVisibilityMode()
    {
        return (TouchScreenButton.VisibilityModeEnum)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPassbyPress, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPassbyPress(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPassbyPressEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPassbyPressEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPressed, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this button is currently pressed.</para>
    /// </summary>
    public bool IsPressed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// <para>Emitted when the button is pressed (down).</para>
    /// </summary>
    public event Action Pressed
    {
        add => Connect(SignalName.Pressed, Callable.From(value));
        remove => Disconnect(SignalName.Pressed, Callable.From(value));
    }

    protected void EmitSignalPressed()
    {
        EmitSignal(SignalName.Pressed);
    }

    /// <summary>
    /// <para>Emitted when the button is released (up).</para>
    /// </summary>
    public event Action Released
    {
        add => Connect(SignalName.Released, Callable.From(value));
        remove => Disconnect(SignalName.Released, Callable.From(value));
    }

    protected void EmitSignalReleased()
    {
        EmitSignal(SignalName.Released);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_pressed = "Pressed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_released = "Released";

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
        if (signal == SignalName.Pressed)
        {
            if (HasGodotClassSignal(SignalProxyName_pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Released)
        {
            if (HasGodotClassSignal(SignalProxyName_released.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node2D.PropertyName
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
        /// Cached name for the 'bitmask' property.
        /// </summary>
        public static readonly StringName Bitmask = "bitmask";
        /// <summary>
        /// Cached name for the 'shape' property.
        /// </summary>
        public static readonly StringName Shape = "shape";
        /// <summary>
        /// Cached name for the 'shape_centered' property.
        /// </summary>
        public static readonly StringName ShapeCentered = "shape_centered";
        /// <summary>
        /// Cached name for the 'shape_visible' property.
        /// </summary>
        public static readonly StringName ShapeVisible = "shape_visible";
        /// <summary>
        /// Cached name for the 'passby_press' property.
        /// </summary>
        public static readonly StringName PassbyPress = "passby_press";
        /// <summary>
        /// Cached name for the 'action' property.
        /// </summary>
        public static readonly StringName Action = "action";
        /// <summary>
        /// Cached name for the 'visibility_mode' property.
        /// </summary>
        public static readonly StringName VisibilityMode = "visibility_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_texture_normal' method.
        /// </summary>
        public static readonly StringName SetTextureNormal = "set_texture_normal";
        /// <summary>
        /// Cached name for the 'get_texture_normal' method.
        /// </summary>
        public static readonly StringName GetTextureNormal = "get_texture_normal";
        /// <summary>
        /// Cached name for the 'set_texture_pressed' method.
        /// </summary>
        public static readonly StringName SetTexturePressed = "set_texture_pressed";
        /// <summary>
        /// Cached name for the 'get_texture_pressed' method.
        /// </summary>
        public static readonly StringName GetTexturePressed = "get_texture_pressed";
        /// <summary>
        /// Cached name for the 'set_bitmask' method.
        /// </summary>
        public static readonly StringName SetBitmask = "set_bitmask";
        /// <summary>
        /// Cached name for the 'get_bitmask' method.
        /// </summary>
        public static readonly StringName GetBitmask = "get_bitmask";
        /// <summary>
        /// Cached name for the 'set_shape' method.
        /// </summary>
        public static readonly StringName SetShape = "set_shape";
        /// <summary>
        /// Cached name for the 'get_shape' method.
        /// </summary>
        public static readonly StringName GetShape = "get_shape";
        /// <summary>
        /// Cached name for the 'set_shape_centered' method.
        /// </summary>
        public static readonly StringName SetShapeCentered = "set_shape_centered";
        /// <summary>
        /// Cached name for the 'is_shape_centered' method.
        /// </summary>
        public static readonly StringName IsShapeCentered = "is_shape_centered";
        /// <summary>
        /// Cached name for the 'set_shape_visible' method.
        /// </summary>
        public static readonly StringName SetShapeVisible = "set_shape_visible";
        /// <summary>
        /// Cached name for the 'is_shape_visible' method.
        /// </summary>
        public static readonly StringName IsShapeVisible = "is_shape_visible";
        /// <summary>
        /// Cached name for the 'set_action' method.
        /// </summary>
        public static readonly StringName SetAction = "set_action";
        /// <summary>
        /// Cached name for the 'get_action' method.
        /// </summary>
        public static readonly StringName GetAction = "get_action";
        /// <summary>
        /// Cached name for the 'set_visibility_mode' method.
        /// </summary>
        public static readonly StringName SetVisibilityMode = "set_visibility_mode";
        /// <summary>
        /// Cached name for the 'get_visibility_mode' method.
        /// </summary>
        public static readonly StringName GetVisibilityMode = "get_visibility_mode";
        /// <summary>
        /// Cached name for the 'set_passby_press' method.
        /// </summary>
        public static readonly StringName SetPassbyPress = "set_passby_press";
        /// <summary>
        /// Cached name for the 'is_passby_press_enabled' method.
        /// </summary>
        public static readonly StringName IsPassbyPressEnabled = "is_passby_press_enabled";
        /// <summary>
        /// Cached name for the 'is_pressed' method.
        /// </summary>
        public static readonly StringName IsPressed = "is_pressed";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
        /// <summary>
        /// Cached name for the 'pressed' signal.
        /// </summary>
        public static readonly StringName Pressed = "pressed";
        /// <summary>
        /// Cached name for the 'released' signal.
        /// </summary>
        public static readonly StringName Released = "released";
    }
}
