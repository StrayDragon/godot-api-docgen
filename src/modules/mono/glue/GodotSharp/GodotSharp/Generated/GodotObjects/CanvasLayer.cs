namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.CanvasItem"/>-derived nodes that are direct or indirect children of a <see cref="Godot.CanvasLayer"/> will be drawn in that layer. The layer is a numeric index that defines the draw order. The default 2D scene renders with index <c>0</c>, so a <see cref="Godot.CanvasLayer"/> with index <c>-1</c> will be drawn below, and a <see cref="Godot.CanvasLayer"/> with index <c>1</c> will be drawn above. This order will hold regardless of the <see cref="Godot.CanvasItem.ZIndex"/> of the nodes within each layer.</para>
/// <para><see cref="Godot.CanvasLayer"/>s can be hidden and they can also optionally follow the viewport. This makes them useful for HUDs like health bar overlays (on layers <c>1</c> and higher) or backgrounds (on layers <c>-1</c> and lower).</para>
/// <para><b>Note:</b> Embedded <see cref="Godot.Window"/>s are placed on layer <c>1024</c>. <see cref="Godot.CanvasItem"/>s on layers <c>1025</c> and higher appear in front of embedded windows.</para>
/// <para><b>Note:</b> Each <see cref="Godot.CanvasLayer"/> is drawn on one specific <see cref="Godot.Viewport"/> and cannot be shared between multiple <see cref="Godot.Viewport"/>s, see <see cref="Godot.CanvasLayer.CustomViewport"/>. When using multiple <see cref="Godot.Viewport"/>s, for example in a split-screen game, you need to create an individual <see cref="Godot.CanvasLayer"/> for each <see cref="Godot.Viewport"/> you want it to be drawn on.</para>
/// </summary>
public partial class CanvasLayer : Node
{
    /// <summary>
    /// <para>Layer index for draw order. Lower values are drawn behind higher values.</para>
    /// <para><b>Note:</b> If multiple CanvasLayers have the same layer index, <see cref="Godot.CanvasItem"/> children of one CanvasLayer are drawn behind the <see cref="Godot.CanvasItem"/> children of the other CanvasLayer. Which CanvasLayer is drawn in front is non-deterministic.</para>
    /// <para><b>Note:</b> The layer index should be between <see cref="Godot.RenderingServer.CanvasLayerMin"/> and <see cref="Godot.RenderingServer.CanvasLayerMax"/> (inclusive). Any other value will wrap around.</para>
    /// </summary>
    public int Layer
    {
        get
        {
            return GetLayer();
        }
        set
        {
            SetLayer(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, any <see cref="Godot.CanvasItem"/> under this <see cref="Godot.CanvasLayer"/> will be hidden.</para>
    /// <para>Unlike <see cref="Godot.CanvasItem.Visible"/>, visibility of a <see cref="Godot.CanvasLayer"/> isn't propagated to underlying layers.</para>
    /// </summary>
    public bool Visible
    {
        get
        {
            return IsVisible();
        }
        set
        {
            SetVisible(value);
        }
    }

    /// <summary>
    /// <para>The layer's base offset.</para>
    /// </summary>
    public Vector2 Offset
    {
        get
        {
            return GetOffset();
        }
        set
        {
            SetOffset(value);
        }
    }

    /// <summary>
    /// <para>The layer's rotation in radians.</para>
    /// </summary>
    public float Rotation
    {
        get
        {
            return GetRotation();
        }
        set
        {
            SetRotation(value);
        }
    }

    /// <summary>
    /// <para>The layer's scale.</para>
    /// </summary>
    public Vector2 Scale
    {
        get
        {
            return GetScale();
        }
        set
        {
            SetScale(value);
        }
    }

    /// <summary>
    /// <para>The layer's transform.</para>
    /// </summary>
    public Transform2D Transform
    {
        get
        {
            return GetTransform();
        }
        set
        {
            SetTransform(value);
        }
    }

    /// <summary>
    /// <para>The custom <see cref="Godot.Viewport"/> node assigned to the <see cref="Godot.CanvasLayer"/>. If <see langword="null"/>, uses the default viewport instead.</para>
    /// </summary>
    public Node CustomViewport
    {
        get
        {
            return GetCustomViewport();
        }
        set
        {
            SetCustomViewport(value);
        }
    }

    /// <summary>
    /// <para>If enabled, the <see cref="Godot.CanvasLayer"/> maintains its position in world space. If disabled, the <see cref="Godot.CanvasLayer"/> stays in a fixed position on the screen.</para>
    /// <para>Together with <see cref="Godot.CanvasLayer.FollowViewportScale"/>, this can be used for a pseudo-3D effect.</para>
    /// </summary>
    public bool FollowViewportEnabled
    {
        get
        {
            return IsFollowingViewport();
        }
        set
        {
            SetFollowViewport(value);
        }
    }

    /// <summary>
    /// <para>Scales the layer when using <see cref="Godot.CanvasLayer.FollowViewportEnabled"/>. Layers moving into the foreground should have increasing scales, while layers moving into the background should have decreasing scales.</para>
    /// </summary>
    public float FollowViewportScale
    {
        get
        {
            return GetFollowViewportScale();
        }
        set
        {
            SetFollowViewportScale(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CanvasLayer);

    private static readonly StringName NativeName = "CanvasLayer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CanvasLayer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CanvasLayer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CanvasLayer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayer, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLayer(int layer)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayer, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetLayer()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Show, 3218959716ul);

    /// <summary>
    /// <para>Shows any <see cref="Godot.CanvasItem"/> under this <see cref="Godot.CanvasLayer"/>. This is equivalent to setting <see cref="Godot.CanvasLayer.Visible"/> to <see langword="true"/>.</para>
    /// </summary>
    public void Show()
    {
        NativeCalls.godot_icall_0_3(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Hide, 3218959716ul);

    /// <summary>
    /// <para>Hides any <see cref="Godot.CanvasItem"/> under this <see cref="Godot.CanvasLayer"/>. This is equivalent to setting <see cref="Godot.CanvasLayer.Visible"/> to <see langword="false"/>.</para>
    /// </summary>
    public void Hide()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransform, 2761652528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTransform(Transform2D transform)
    {
        NativeCalls.godot_icall_1_218(MethodBind6, GodotObject.GetPtr(this), &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransform, 3814499831ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform2D GetTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFinalTransform, 3814499831ul);

    /// <summary>
    /// <para>Returns the transform from the <see cref="Godot.CanvasLayer"/>s coordinate system to the <see cref="Godot.Viewport"/>s coordinate system.</para>
    /// </summary>
    public Transform2D GetFinalTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind9, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotation(float radians)
    {
        NativeCalls.godot_icall_1_67(MethodBind11, GodotObject.GetPtr(this), radians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRotation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScale, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScale(Vector2 scale)
    {
        NativeCalls.godot_icall_1_36(MethodBind13, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScale, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScale()
    {
        return NativeCalls.godot_icall_0_37(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFollowViewport, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFollowViewport(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFollowingViewport, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFollowingViewport()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFollowViewportScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFollowViewportScale(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind17, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFollowViewportScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFollowViewportScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomViewport, 1078189570ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCustomViewport(Node viewport)
    {
        NativeCalls.godot_icall_1_56(MethodBind19, GodotObject.GetPtr(this), GodotObject.GetPtr(viewport));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomViewport, 3160264692ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node GetCustomViewport()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvas, 2944877500ul);

    /// <summary>
    /// <para>Returns the RID of the canvas used by this layer.</para>
    /// </summary>
    public Rid GetCanvas()
    {
        return NativeCalls.godot_icall_0_238(MethodBind21, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when visibility of the layer is changed. See <see cref="Godot.CanvasLayer.Visible"/>.</para>
    /// </summary>
    public event Action VisibilityChanged
    {
        add => Connect(SignalName.VisibilityChanged, Callable.From(value));
        remove => Disconnect(SignalName.VisibilityChanged, Callable.From(value));
    }

    protected void EmitSignalVisibilityChanged()
    {
        EmitSignal(SignalName.VisibilityChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_visibility_changed = "VisibilityChanged";

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
        if (signal == SignalName.VisibilityChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_visibility_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node.PropertyName
    {
        /// <summary>
        /// Cached name for the 'layer' property.
        /// </summary>
        public static readonly StringName Layer = "layer";
        /// <summary>
        /// Cached name for the 'visible' property.
        /// </summary>
        public static readonly StringName Visible = "visible";
        /// <summary>
        /// Cached name for the 'offset' property.
        /// </summary>
        public static readonly StringName Offset = "offset";
        /// <summary>
        /// Cached name for the 'rotation' property.
        /// </summary>
        public static readonly StringName Rotation = "rotation";
        /// <summary>
        /// Cached name for the 'scale' property.
        /// </summary>
        public static readonly StringName Scale = "scale";
        /// <summary>
        /// Cached name for the 'transform' property.
        /// </summary>
        public static readonly StringName Transform = "transform";
        /// <summary>
        /// Cached name for the 'custom_viewport' property.
        /// </summary>
        public static readonly StringName CustomViewport = "custom_viewport";
        /// <summary>
        /// Cached name for the 'follow_viewport_enabled' property.
        /// </summary>
        public static readonly StringName FollowViewportEnabled = "follow_viewport_enabled";
        /// <summary>
        /// Cached name for the 'follow_viewport_scale' property.
        /// </summary>
        public static readonly StringName FollowViewportScale = "follow_viewport_scale";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_layer' method.
        /// </summary>
        public static readonly StringName SetLayer = "set_layer";
        /// <summary>
        /// Cached name for the 'get_layer' method.
        /// </summary>
        public static readonly StringName GetLayer = "get_layer";
        /// <summary>
        /// Cached name for the 'set_visible' method.
        /// </summary>
        public static readonly StringName SetVisible = "set_visible";
        /// <summary>
        /// Cached name for the 'is_visible' method.
        /// </summary>
        public static readonly StringName IsVisible = "is_visible";
        /// <summary>
        /// Cached name for the 'show' method.
        /// </summary>
        public static readonly StringName Show = "show";
        /// <summary>
        /// Cached name for the 'hide' method.
        /// </summary>
        public static readonly StringName Hide = "hide";
        /// <summary>
        /// Cached name for the 'set_transform' method.
        /// </summary>
        public static readonly StringName SetTransform = "set_transform";
        /// <summary>
        /// Cached name for the 'get_transform' method.
        /// </summary>
        public static readonly StringName GetTransform = "get_transform";
        /// <summary>
        /// Cached name for the 'get_final_transform' method.
        /// </summary>
        public static readonly StringName GetFinalTransform = "get_final_transform";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'set_rotation' method.
        /// </summary>
        public static readonly StringName SetRotation = "set_rotation";
        /// <summary>
        /// Cached name for the 'get_rotation' method.
        /// </summary>
        public static readonly StringName GetRotation = "get_rotation";
        /// <summary>
        /// Cached name for the 'set_scale' method.
        /// </summary>
        public static readonly StringName SetScale = "set_scale";
        /// <summary>
        /// Cached name for the 'get_scale' method.
        /// </summary>
        public static readonly StringName GetScale = "get_scale";
        /// <summary>
        /// Cached name for the 'set_follow_viewport' method.
        /// </summary>
        public static readonly StringName SetFollowViewport = "set_follow_viewport";
        /// <summary>
        /// Cached name for the 'is_following_viewport' method.
        /// </summary>
        public static readonly StringName IsFollowingViewport = "is_following_viewport";
        /// <summary>
        /// Cached name for the 'set_follow_viewport_scale' method.
        /// </summary>
        public static readonly StringName SetFollowViewportScale = "set_follow_viewport_scale";
        /// <summary>
        /// Cached name for the 'get_follow_viewport_scale' method.
        /// </summary>
        public static readonly StringName GetFollowViewportScale = "get_follow_viewport_scale";
        /// <summary>
        /// Cached name for the 'set_custom_viewport' method.
        /// </summary>
        public static readonly StringName SetCustomViewport = "set_custom_viewport";
        /// <summary>
        /// Cached name for the 'get_custom_viewport' method.
        /// </summary>
        public static readonly StringName GetCustomViewport = "get_custom_viewport";
        /// <summary>
        /// Cached name for the 'get_canvas' method.
        /// </summary>
        public static readonly StringName GetCanvas = "get_canvas";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'visibility_changed' signal.
        /// </summary>
        public static readonly StringName VisibilityChanged = "visibility_changed";
    }
}
