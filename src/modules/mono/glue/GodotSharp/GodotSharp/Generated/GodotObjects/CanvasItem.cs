namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstract base class for everything in 2D space. Canvas items are laid out in a tree; children inherit and extend their parent's transform. <see cref="Godot.CanvasItem"/> is extended by <see cref="Godot.Control"/> for GUI-related nodes, and by <see cref="Godot.Node2D"/> for 2D game objects.</para>
/// <para>Any <see cref="Godot.CanvasItem"/> can draw. For this, <see cref="Godot.CanvasItem.QueueRedraw()"/> is called by the engine, then <see cref="Godot.CanvasItem.NotificationDraw"/> will be received on idle time to request a redraw. Because of this, canvas items don't need to be redrawn on every frame, improving the performance significantly. Several functions for drawing on the <see cref="Godot.CanvasItem"/> are provided (see <c>draw_*</c> functions). However, they can only be used inside <see cref="Godot.CanvasItem._Draw()"/>, its corresponding <see cref="Godot.GodotObject._Notification(int)"/> or methods connected to the <see cref="Godot.CanvasItem.Draw"/> signal.</para>
/// <para>Canvas items are drawn in tree order on their canvas layer. By default, children are on top of their parents, so a root <see cref="Godot.CanvasItem"/> will be drawn behind everything. This behavior can be changed on a per-item basis.</para>
/// <para>A <see cref="Godot.CanvasItem"/> can be hidden, which will also hide its children. By adjusting various other properties of a <see cref="Godot.CanvasItem"/>, you can also modulate its color (via <see cref="Godot.CanvasItem.Modulate"/> or <see cref="Godot.CanvasItem.SelfModulate"/>), change its Z-index, blend mode, and more.</para>
/// <para>Note that properties like transform, modulation, and visibility are only propagated to <i>direct</i> <see cref="Godot.CanvasItem"/> child nodes. If there is a non-<see cref="Godot.CanvasItem"/> node in between, like <see cref="Godot.Node"/> or <see cref="Godot.AnimationPlayer"/>, the <see cref="Godot.CanvasItem"/> nodes below will have an independent position and <see cref="Godot.CanvasItem.Modulate"/> chain. See also <see cref="Godot.CanvasItem.TopLevel"/>.</para>
/// </summary>
public partial class CanvasItem : Node
{
    /// <summary>
    /// <para>Notification received when this node's global transform changes, if <see cref="Godot.CanvasItem.IsTransformNotificationEnabled()"/> is <see langword="true"/>. See also <see cref="Godot.CanvasItem.SetNotifyTransform(bool)"/> and <see cref="Godot.CanvasItem.GetTransform()"/>.</para>
    /// <para><b>Note:</b> Many canvas items such as <see cref="Godot.Camera2D"/> or <see cref="Godot.CollisionObject2D"/> automatically enable this in order to function correctly.</para>
    /// </summary>
    public const long NotificationTransformChanged = 2000;
    /// <summary>
    /// <para>Notification received when this node's transform changes, if <see cref="Godot.CanvasItem.IsLocalTransformNotificationEnabled()"/> is <see langword="true"/>. This is not received when a parent <see cref="Godot.Node2D"/>'s transform changes. See also <see cref="Godot.CanvasItem.SetNotifyLocalTransform(bool)"/>.</para>
    /// <para><b>Note:</b> Many canvas items such as <see cref="Godot.Camera2D"/> or <see cref="Godot.CollisionShape2D"/> automatically enable this in order to function correctly.</para>
    /// </summary>
    public const long NotificationLocalTransformChanged = 35;
    /// <summary>
    /// <para>The <see cref="Godot.CanvasItem"/> is requested to draw (see <see cref="Godot.CanvasItem._Draw()"/>).</para>
    /// </summary>
    public const long NotificationDraw = 30;
    /// <summary>
    /// <para>Notification received when this node's visibility changes (see <see cref="Godot.CanvasItem.Visible"/> and <see cref="Godot.CanvasItem.IsVisibleInTree()"/>).</para>
    /// <para>This notification is received <i>before</i> the related <see cref="Godot.CanvasItem.VisibilityChanged"/> signal.</para>
    /// </summary>
    public const long NotificationVisibilityChanged = 31;
    /// <summary>
    /// <para>The <see cref="Godot.CanvasItem"/> has entered the canvas.</para>
    /// </summary>
    public const long NotificationEnterCanvas = 32;
    /// <summary>
    /// <para>The <see cref="Godot.CanvasItem"/> has exited the canvas.</para>
    /// <para>This notification is sent in reversed order.</para>
    /// </summary>
    public const long NotificationExitCanvas = 33;
    /// <summary>
    /// <para>Notification received when this <see cref="Godot.CanvasItem"/> is registered to a new <see cref="Godot.World2D"/> (see <see cref="Godot.CanvasItem.GetWorld2D()"/>).</para>
    /// </summary>
    public const long NotificationWorld2DChanged = 36;

    public enum TextureFilterEnum : long
    {
        /// <summary>
        /// <para>The <see cref="Godot.CanvasItem"/> will inherit the filter from its parent.</para>
        /// </summary>
        ParentNode = 0,
        /// <summary>
        /// <para>The texture filter reads from the nearest pixel only. This makes the texture look pixelated from up close, and grainy from a distance (due to mipmaps not being sampled).</para>
        /// </summary>
        Nearest = 1,
        /// <summary>
        /// <para>The texture filter blends between the nearest 4 pixels. This makes the texture look smooth from up close, and grainy from a distance (due to mipmaps not being sampled).</para>
        /// </summary>
        Linear = 2,
        /// <summary>
        /// <para>The texture filter reads from the nearest pixel and blends between the nearest 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>). This makes the texture look pixelated from up close, and smooth from a distance.</para>
        /// <para>Use this for non-pixel art textures that may be viewed at a low scale (e.g. due to <see cref="Godot.Camera2D"/> zoom or sprite scaling), as mipmaps are important to smooth out pixels that are smaller than on-screen pixels.</para>
        /// </summary>
        NearestWithMipmaps = 3,
        /// <summary>
        /// <para>The texture filter blends between the nearest 4 pixels and between the nearest 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>). This makes the texture look smooth from up close, and smooth from a distance.</para>
        /// <para>Use this for non-pixel art textures that may be viewed at a low scale (e.g. due to <see cref="Godot.Camera2D"/> zoom or sprite scaling), as mipmaps are important to smooth out pixels that are smaller than on-screen pixels.</para>
        /// </summary>
        LinearWithMipmaps = 4,
        /// <summary>
        /// <para>The texture filter reads from the nearest pixel and blends between 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>) based on the angle between the surface and the camera view. This makes the texture look pixelated from up close, and smooth from a distance. Anisotropic filtering improves texture quality on surfaces that are almost in line with the camera, but is slightly slower. The anisotropic filtering level can be changed by adjusting <c>ProjectSettings.rendering/textures/default_filters/anisotropic_filtering_level</c>.</para>
        /// <para><b>Note:</b> This texture filter is rarely useful in 2D projects. <see cref="Godot.CanvasItem.TextureFilterEnum.NearestWithMipmaps"/> is usually more appropriate in this case.</para>
        /// </summary>
        NearestWithMipmapsAnisotropic = 5,
        /// <summary>
        /// <para>The texture filter blends between the nearest 4 pixels and blends between 2 mipmaps (or uses the nearest mipmap if <c>ProjectSettings.rendering/textures/default_filters/use_nearest_mipmap_filter</c> is <see langword="true"/>) based on the angle between the surface and the camera view. This makes the texture look smooth from up close, and smooth from a distance. Anisotropic filtering improves texture quality on surfaces that are almost in line with the camera, but is slightly slower. The anisotropic filtering level can be changed by adjusting <c>ProjectSettings.rendering/textures/default_filters/anisotropic_filtering_level</c>.</para>
        /// <para><b>Note:</b> This texture filter is rarely useful in 2D projects. <see cref="Godot.CanvasItem.TextureFilterEnum.LinearWithMipmaps"/> is usually more appropriate in this case.</para>
        /// </summary>
        LinearWithMipmapsAnisotropic = 6,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.CanvasItem.TextureFilterEnum"/> enum.</para>
        /// </summary>
        Max = 7
    }

    public enum TextureRepeatEnum : long
    {
        /// <summary>
        /// <para>The <see cref="Godot.CanvasItem"/> will inherit the filter from its parent.</para>
        /// </summary>
        ParentNode = 0,
        /// <summary>
        /// <para>The texture does not repeat. Sampling the texture outside its extents will result in "stretching" of the edge pixels. You can avoid this by ensuring a 1-pixel fully transparent border on each side of the texture.</para>
        /// </summary>
        Disabled = 1,
        /// <summary>
        /// <para>The texture repeats when exceeding the texture's size.</para>
        /// </summary>
        Enabled = 2,
        /// <summary>
        /// <para>The texture repeats when the exceeding the texture's size in a "2×2 tiled mode". Repeated textures at even positions are mirrored.</para>
        /// </summary>
        Mirror = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.CanvasItem.TextureRepeatEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum ClipChildrenMode : long
    {
        /// <summary>
        /// <para>Children are drawn over this node and are not clipped.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>This node is used as a mask and is <b>not</b> drawn. The mask is based on this node's alpha channel: Opaque pixels are kept, transparent pixels are discarded, and semi-transparent pixels are blended in according to their opacity. Children are clipped to this node's drawn area.</para>
        /// </summary>
        Only = 1,
        /// <summary>
        /// <para>This node is used as a mask and is also drawn. The mask is based on this node's alpha channel: Opaque pixels are kept, transparent pixels are discarded, and semi-transparent pixels are blended in according to their opacity. Children are clipped to the parent's drawn area.</para>
        /// </summary>
        AndDraw = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.CanvasItem.ClipChildrenMode"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this <see cref="Godot.CanvasItem"/> may be drawn. Whether this <see cref="Godot.CanvasItem"/> is actually drawn depends on the visibility of all of its <see cref="Godot.CanvasItem"/> ancestors. In other words: this <see cref="Godot.CanvasItem"/> will be drawn when <see cref="Godot.CanvasItem.IsVisibleInTree()"/> returns <see langword="true"/> and all <see cref="Godot.CanvasItem"/> ancestors share at least one <see cref="Godot.CanvasItem.VisibilityLayer"/> with this <see cref="Godot.CanvasItem"/>.</para>
    /// <para><b>Note:</b> For controls that inherit <see cref="Godot.Popup"/>, the correct way to make them visible is to call one of the multiple <c>popup*()</c> functions instead.</para>
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
    /// <para>The color applied to this <see cref="Godot.CanvasItem"/>. This property does affect child <see cref="Godot.CanvasItem"/>s, unlike <see cref="Godot.CanvasItem.SelfModulate"/> which only affects the node itself.</para>
    /// </summary>
    public Color Modulate
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
    /// <para>The color applied to this <see cref="Godot.CanvasItem"/>. This property does <b>not</b> affect child <see cref="Godot.CanvasItem"/>s, unlike <see cref="Godot.CanvasItem.Modulate"/> which affects both the node itself and its children.</para>
    /// <para><b>Note:</b> Internal children are also not affected by this property (see the <c>include_internal</c> parameter in <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>). For built-in nodes this includes sliders in <see cref="Godot.ColorPicker"/>, and the tab bar in <see cref="Godot.TabContainer"/>.</para>
    /// </summary>
    public Color SelfModulate
    {
        get
        {
            return GetSelfModulate();
        }
        set
        {
            SetSelfModulate(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this node draws behind its parent.</para>
    /// </summary>
    public bool ShowBehindParent
    {
        get
        {
            return IsDrawBehindParentEnabled();
        }
        set
        {
            SetDrawBehindParent(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this <see cref="Godot.CanvasItem"/> will <i>not</i> inherit its transform from parent <see cref="Godot.CanvasItem"/>s. Its draw order will also be changed to make it draw on top of other <see cref="Godot.CanvasItem"/>s that do not have <see cref="Godot.CanvasItem.TopLevel"/> set to <see langword="true"/>. The <see cref="Godot.CanvasItem"/> will effectively act as if it was placed as a child of a bare <see cref="Godot.Node"/>.</para>
    /// </summary>
    public bool TopLevel
    {
        get
        {
            return IsSetAsTopLevel();
        }
        set
        {
            SetAsTopLevel(value);
        }
    }

    /// <summary>
    /// <para>The mode in which this node clips its children, acting as a mask.</para>
    /// <para><b>Note:</b> Clipping nodes cannot be nested or placed within a <see cref="Godot.CanvasGroup"/>. If an ancestor of this node clips its children or is a <see cref="Godot.CanvasGroup"/>, then this node's clip mode should be set to <see cref="Godot.CanvasItem.ClipChildrenMode.Disabled"/> to avoid unexpected behavior.</para>
    /// </summary>
    public CanvasItem.ClipChildrenMode ClipChildren
    {
        get
        {
            return GetClipChildrenMode();
        }
        set
        {
            SetClipChildrenMode(value);
        }
    }

    /// <summary>
    /// <para>The rendering layers in which this <see cref="Godot.CanvasItem"/> responds to <see cref="Godot.Light2D"/> nodes.</para>
    /// </summary>
    public int LightMask
    {
        get
        {
            return GetLightMask();
        }
        set
        {
            SetLightMask(value);
        }
    }

    /// <summary>
    /// <para>The rendering layer in which this <see cref="Godot.CanvasItem"/> is rendered by <see cref="Godot.Viewport"/> nodes. A <see cref="Godot.Viewport"/> will render a <see cref="Godot.CanvasItem"/> if it and all its parents share a layer with the <see cref="Godot.Viewport"/>'s canvas cull mask.</para>
    /// <para><b>Note:</b> A <see cref="Godot.CanvasItem"/> does not inherit its parents' visibility layers. This means that if a parent <see cref="Godot.CanvasItem"/> does not have all the same layers as its child, the child may not be visible even if both the parent and child have <see cref="Godot.CanvasItem.Visible"/> set to <see langword="true"/>. For example, if a parent has layer 1 and a child has layer 2, the child will not be visible in a <see cref="Godot.Viewport"/> with the canvas cull mask set to layer 1 or 2 (see <see cref="Godot.Viewport.CanvasCullMask"/>). To ensure that both the parent and child are visible, the parent must have both layers 1 and 2, or the child must have <see cref="Godot.CanvasItem.TopLevel"/> set to <see langword="true"/>.</para>
    /// </summary>
    public uint VisibilityLayer
    {
        get
        {
            return GetVisibilityLayer();
        }
        set
        {
            SetVisibilityLayer(value);
        }
    }

    /// <summary>
    /// <para>The order in which this node is drawn. A node with a higher Z index will display in front of others. Must be between <see cref="Godot.RenderingServer.CanvasItemZMin"/> and <see cref="Godot.RenderingServer.CanvasItemZMax"/> (inclusive).</para>
    /// <para><b>Note:</b> The Z index does <b>not</b> affect the order in which <see cref="Godot.CanvasItem"/> nodes are processed or the way input events are handled. This is especially important to keep in mind for <see cref="Godot.Control"/> nodes.</para>
    /// </summary>
    public int ZIndex
    {
        get
        {
            return GetZIndex();
        }
        set
        {
            SetZIndex(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this node's final Z index is relative to its parent's Z index.</para>
    /// <para>For example, if <see cref="Godot.CanvasItem.ZIndex"/> is <c>2</c> and its parent's final Z index is <c>3</c>, then this node's final Z index will be <c>5</c> (<c>2 + 3</c>).</para>
    /// </summary>
    public bool ZAsRelative
    {
        get
        {
            return IsZRelative();
        }
        set
        {
            SetZAsRelative(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this and child <see cref="Godot.CanvasItem"/> nodes with a higher Y position are rendered in front of nodes with a lower Y position. If <see langword="false"/>, this and child <see cref="Godot.CanvasItem"/> nodes are rendered normally in scene tree order.</para>
    /// <para>With Y-sorting enabled on a parent node ('A') but disabled on a child node ('B'), the child node ('B') is sorted but its children ('C1', 'C2', etc.) render together on the same Y position as the child node ('B'). This allows you to organize the render order of a scene without changing the scene tree.</para>
    /// <para>Nodes sort relative to each other only if they are on the same <see cref="Godot.CanvasItem.ZIndex"/>.</para>
    /// </summary>
    public bool YSortEnabled
    {
        get
        {
            return IsYSortEnabled();
        }
        set
        {
            SetYSortEnabled(value);
        }
    }

    /// <summary>
    /// <para>The filtering mode used to render this <see cref="Godot.CanvasItem"/>'s texture(s).</para>
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
    /// <para>The repeating mode used to render this <see cref="Godot.CanvasItem"/>'s texture(s). It affects what happens when the texture is sampled outside its extents, for example by setting a <see cref="Godot.Sprite2D.RegionRect"/> that is larger than the texture or assigning <see cref="Godot.Polygon2D"/> UV points outside the texture.</para>
    /// <para><b>Note:</b> <see cref="Godot.TextureRect"/> is not affected by <see cref="Godot.CanvasItem.TextureRepeat"/>, as it uses its own texture repeating implementation.</para>
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

    /// <summary>
    /// <para>The material applied to this <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public Material Material
    {
        get
        {
            return GetMaterial();
        }
        set
        {
            SetMaterial(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the parent <see cref="Godot.CanvasItem"/>'s <see cref="Godot.CanvasItem.Material"/> is used as this node's material.</para>
    /// </summary>
    public bool UseParentMaterial
    {
        get
        {
            return GetUseParentMaterial();
        }
        set
        {
            SetUseParentMaterial(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CanvasItem);

    private static readonly StringName NativeName = "CanvasItem";

    internal CanvasItem() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CanvasItem(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CanvasItem(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when <see cref="Godot.CanvasItem"/> has been requested to redraw (after <see cref="Godot.CanvasItem.QueueRedraw()"/> is called, either manually or by the engine).</para>
    /// <para>Corresponds to the <see cref="Godot.CanvasItem.NotificationDraw"/> notification in <see cref="Godot.GodotObject._Notification(int)"/>.</para>
    /// </summary>
    public virtual void _Draw()
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvasItem, 2944877500ul);

    /// <summary>
    /// <para>Returns the internal canvas item <see cref="Godot.Rid"/> used by the <see cref="Godot.RenderingServer"/> for this node.</para>
    /// </summary>
    public Rid GetCanvasItem()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind1, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisibleInTree, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node is present in the <see cref="Godot.SceneTree"/>, its <see cref="Godot.CanvasItem.Visible"/> property is <see langword="true"/> and all its ancestors are also visible. If any ancestor is hidden, this node will not be visible in the scene tree, and is therefore not drawn (see <see cref="Godot.CanvasItem._Draw()"/>).</para>
    /// <para>Visibility is checked only in parent nodes that inherit from <see cref="Godot.CanvasItem"/>, <see cref="Godot.CanvasLayer"/>, and <see cref="Godot.Window"/>. If the parent is of any other type (such as <see cref="Godot.Node"/>, <see cref="Godot.AnimationPlayer"/>, or <see cref="Godot.Node3D"/>), it is assumed to be visible.</para>
    /// <para><b>Note:</b> This method does not take <see cref="Godot.CanvasItem.VisibilityLayer"/> into account, so even if this method returns <see langword="true"/>, the node might end up not being rendered.</para>
    /// </summary>
    public bool IsVisibleInTree()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Show, 3218959716ul);

    /// <summary>
    /// <para>Show the <see cref="Godot.CanvasItem"/> if it's currently hidden. This is equivalent to setting <see cref="Godot.CanvasItem.Visible"/> to <see langword="true"/>.</para>
    /// <para><b>Note:</b> For controls that inherit <see cref="Godot.Popup"/>, the correct way to make them visible is to call one of the multiple <c>popup*()</c> functions instead.</para>
    /// </summary>
    public void Show()
    {
        NativeCalls.godot_icall_0_3(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Hide, 3218959716ul);

    /// <summary>
    /// <para>Hide the <see cref="Godot.CanvasItem"/> if it's currently visible. This is equivalent to setting <see cref="Godot.CanvasItem.Visible"/> to <see langword="false"/>.</para>
    /// </summary>
    public void Hide()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueueRedraw, 3218959716ul);

    /// <summary>
    /// <para>Queues the <see cref="Godot.CanvasItem"/> to redraw. During idle time, if <see cref="Godot.CanvasItem"/> is visible, <see cref="Godot.CanvasItem.NotificationDraw"/> is sent and <see cref="Godot.CanvasItem._Draw()"/> is called. This only occurs <b>once</b> per frame, even if this method has been called multiple times.</para>
    /// </summary>
    public void QueueRedraw()
    {
        NativeCalls.godot_icall_0_3(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveToFront, 3218959716ul);

    /// <summary>
    /// <para>Moves this node below its siblings, usually causing the node to draw on top of its siblings. Does nothing if this node does not have a parent. See also <see cref="Godot.Node.MoveChild(Node, int)"/>.</para>
    /// </summary>
    public void MoveToFront()
    {
        NativeCalls.godot_icall_0_3(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAsTopLevel, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAsTopLevel(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSetAsTopLevel, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSetAsTopLevel()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLightMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLightMask(int lightMask)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), lightMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLightMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetLightMask()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModulate, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetModulate(Color modulate)
    {
        NativeCalls.godot_icall_1_213(MethodBind12, GodotObject.GetPtr(this), &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModulate, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetModulate()
    {
        return NativeCalls.godot_icall_0_214(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelfModulate, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSelfModulate(Color selfModulate)
    {
        NativeCalls.godot_icall_1_213(MethodBind14, GodotObject.GetPtr(this), &selfModulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelfModulate, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetSelfModulate()
    {
        return NativeCalls.godot_icall_0_214(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetZIndex(int zIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), zIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetZIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetZIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZAsRelative, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetZAsRelative(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsZRelative, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsZRelative()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetYSortEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetYSortEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsYSortEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsYSortEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawBehindParent, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawBehindParent(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind22, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawBehindParentEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawBehindParentEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind23, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawLine, 1562330099ul);

    /// <summary>
    /// <para>Draws a line from a 2D point to another, with a given color and width. It can be optionally antialiased. The <paramref name="from"/> and <paramref name="to"/> positions are defined in local space. See also <see cref="Godot.CanvasItem.DrawDashedLine(Vector2, Vector2, Color, float, float, bool, bool)"/>, <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/>, and <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, then a two-point primitive will be drawn instead of a four-point one. This means that when the CanvasItem is scaled, the line will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// </summary>
    public unsafe void DrawLine(Vector2 from, Vector2 to, Color color, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_5_242(MethodBind24, GodotObject.GetPtr(this), &from, &to, &color, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawDashedLine, 3653831622ul);

    /// <summary>
    /// <para>Draws a dashed line from a 2D point to another, with a given color and width. The <paramref name="from"/> and <paramref name="to"/> positions are defined in local space. See also <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/>, <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/>, and <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, then a two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the line parts will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para><paramref name="dash"/> is the length of each dash in pixels, with the gap between each dash being the same length. If <paramref name="aligned"/> is <see langword="true"/>, the length of the first and last dashes may be shortened or lengthened to allow the line to begin and end at the precise points defined by <paramref name="from"/> and <paramref name="to"/>. Both ends are always symmetrical when <paramref name="aligned"/> is <see langword="true"/>. If <paramref name="aligned"/> is <see langword="false"/>, all dashes will have the same length, but the line may appear incomplete at the end due to the dash length not dividing evenly into the line length. Only full dashes are drawn when <paramref name="aligned"/> is <see langword="false"/>.</para>
    /// <para>If <paramref name="antialiased"/> is <see langword="true"/>, half transparent "feathers" will be attached to the boundary, making outlines smooth.</para>
    /// <para><b>Note:</b> <paramref name="antialiased"/> is only effective if <paramref name="width"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    public unsafe void DrawDashedLine(Vector2 from, Vector2 to, Color color, float width = -1.0f, float dash = 2.0f, bool aligned = true, bool antialiased = false)
    {
        NativeCalls.godot_icall_7_243(MethodBind25, GodotObject.GetPtr(this), &from, &to, &color, width, dash, aligned.ToGodotBool(), antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawPolyline, 3797364428ul);

    /// <summary>
    /// <para>Draws interconnected line segments with a uniform <paramref name="color"/> and <paramref name="width"/> and optional antialiasing (supported only for positive <paramref name="width"/>). The <paramref name="points"/> array is defined in local space. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw disconnected lines, use <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/> instead. See also <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, it will be ignored and the polyline will be drawn using <see cref="Godot.RenderingServer.PrimitiveType.LineStrip"/>. This means that when the CanvasItem is scaled, the polyline will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// </summary>
    public unsafe void DrawPolyline(Vector2[] points, Color color, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_4_244(MethodBind26, GodotObject.GetPtr(this), points, &color, width, antialiased.ToGodotBool());
    }

    /// <summary>
    /// <para>Draws interconnected line segments with a uniform <paramref name="color"/> and <paramref name="width"/> and optional antialiasing (supported only for positive <paramref name="width"/>). The <paramref name="points"/> array is defined in local space. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw disconnected lines, use <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/> instead. See also <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, it will be ignored and the polyline will be drawn using <see cref="Godot.RenderingServer.PrimitiveType.LineStrip"/>. This means that when the CanvasItem is scaled, the polyline will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// </summary>
    public unsafe void DrawPolyline(ReadOnlySpan<Vector2> points, Color color, float width, bool antialiased)
    {
        NativeCalls.godot_icall_4_244(MethodBind26, GodotObject.GetPtr(this), points, &color, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawPolylineColors, 2311979562ul);

    /// <summary>
    /// <para>Draws interconnected line segments with a uniform <paramref name="width"/>, point-by-point coloring, and optional antialiasing (supported only for positive <paramref name="width"/>). Colors assigned to line points match by index between <paramref name="points"/> and <paramref name="colors"/>, i.e. each line segment is filled with a gradient between the colors of the endpoints. The <paramref name="points"/> array is defined in local space. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw disconnected lines, use <see cref="Godot.CanvasItem.DrawMultilineColors(Vector2[], Color[], float, bool)"/> instead. See also <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, it will be ignored and the polyline will be drawn using <see cref="Godot.RenderingServer.PrimitiveType.LineStrip"/>. This means that when the CanvasItem is scaled, the polyline will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// </summary>
    public void DrawPolylineColors(Vector2[] points, Color[] colors, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_4_245(MethodBind27, GodotObject.GetPtr(this), points, colors, width, antialiased.ToGodotBool());
    }

    /// <summary>
    /// <para>Draws interconnected line segments with a uniform <paramref name="width"/>, point-by-point coloring, and optional antialiasing (supported only for positive <paramref name="width"/>). Colors assigned to line points match by index between <paramref name="points"/> and <paramref name="colors"/>, i.e. each line segment is filled with a gradient between the colors of the endpoints. The <paramref name="points"/> array is defined in local space. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw disconnected lines, use <see cref="Godot.CanvasItem.DrawMultilineColors(Vector2[], Color[], float, bool)"/> instead. See also <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, it will be ignored and the polyline will be drawn using <see cref="Godot.RenderingServer.PrimitiveType.LineStrip"/>. This means that when the CanvasItem is scaled, the polyline will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// </summary>
    public void DrawPolylineColors(ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, float width, bool antialiased)
    {
        NativeCalls.godot_icall_4_245(MethodBind27, GodotObject.GetPtr(this), points, colors, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawEllipseArc, 936174114ul);

    /// <summary>
    /// <para>Draws an unfilled elliptical arc between the given angles with a uniform <paramref name="color"/> and <paramref name="width"/> and optional antialiasing (supported only for positive <paramref name="width"/>). The larger the value of <paramref name="pointCount"/>, the smoother the curve. For circular arcs, see <see cref="Godot.CanvasItem.DrawArc(Vector2, float, float, float, int, Color, float, bool)"/>. See also <see cref="Godot.CanvasItem.DrawEllipse(Vector2, float, float, Color, bool, float, bool)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, it will be ignored and the arc will be drawn using <see cref="Godot.RenderingServer.PrimitiveType.LineStrip"/>. This means that when the CanvasItem is scaled, the arc will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para>The arc is drawn from <paramref name="startAngle"/> towards the value of <paramref name="endAngle"/> so in clockwise direction if <c>start_angle &lt; end_angle</c> and counter-clockwise otherwise. Passing the same angles but in reversed order will produce the same arc. If absolute difference of <paramref name="startAngle"/> and <paramref name="endAngle"/> is greater than <c>@GDScript.TAU</c> radians, then a full ellipse is drawn (i.e. arc will not overlap itself).</para>
    /// </summary>
    public unsafe void DrawEllipseArc(Vector2 center, float major, float minor, float startAngle, float endAngle, int pointCount, Color color, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_9_246(MethodBind28, GodotObject.GetPtr(this), &center, major, minor, startAngle, endAngle, pointCount, &color, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawArc, 4140652635ul);

    /// <summary>
    /// <para>Draws an unfilled arc between the given angles with a uniform <paramref name="color"/> and <paramref name="width"/> and optional antialiasing (supported only for positive <paramref name="width"/>). The larger the value of <paramref name="pointCount"/>, the smoother the curve. <paramref name="center"/> is defined in local space. For elliptical arcs, see <see cref="Godot.CanvasItem.DrawEllipseArc(Vector2, float, float, float, float, int, Color, float, bool)"/>. See also <see cref="Godot.CanvasItem.DrawCircle(Vector2, float, Color, bool, float, bool)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, it will be ignored and the arc will be drawn using <see cref="Godot.RenderingServer.PrimitiveType.LineStrip"/>. This means that when the CanvasItem is scaled, the arc will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para>The arc is drawn from <paramref name="startAngle"/> towards the value of <paramref name="endAngle"/> so in clockwise direction if <c>start_angle &lt; end_angle</c> and counter-clockwise otherwise. Passing the same angles but in reversed order will produce the same arc. If absolute difference of <paramref name="startAngle"/> and <paramref name="endAngle"/> is greater than <c>@GDScript.TAU</c> radians, then a full circle arc is drawn (i.e. arc will not overlap itself).</para>
    /// </summary>
    public unsafe void DrawArc(Vector2 center, float radius, float startAngle, float endAngle, int pointCount, Color color, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_8_247(MethodBind29, GodotObject.GetPtr(this), &center, radius, startAngle, endAngle, pointCount, &color, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultiline, 3797364428ul);

    /// <summary>
    /// <para>Draws multiple disconnected lines with a uniform <paramref name="width"/> and <paramref name="color"/>. Each line is defined by two consecutive points from <paramref name="points"/> array in local space, i.e. i-th segment consists of <c>points[2 * i]</c>, <c>points[2 * i + 1]</c> endpoints. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw interconnected lines, use <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/> instead.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para><b>Note:</b> <paramref name="antialiased"/> is only effective if <paramref name="width"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    public unsafe void DrawMultiline(Vector2[] points, Color color, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_4_244(MethodBind30, GodotObject.GetPtr(this), points, &color, width, antialiased.ToGodotBool());
    }

    /// <summary>
    /// <para>Draws multiple disconnected lines with a uniform <paramref name="width"/> and <paramref name="color"/>. Each line is defined by two consecutive points from <paramref name="points"/> array in local space, i.e. i-th segment consists of <c>points[2 * i]</c>, <c>points[2 * i + 1]</c> endpoints. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw interconnected lines, use <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/> instead.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para><b>Note:</b> <paramref name="antialiased"/> is only effective if <paramref name="width"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    public unsafe void DrawMultiline(ReadOnlySpan<Vector2> points, Color color, float width, bool antialiased)
    {
        NativeCalls.godot_icall_4_244(MethodBind30, GodotObject.GetPtr(this), points, &color, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultilineColors, 2311979562ul);

    /// <summary>
    /// <para>Draws multiple disconnected lines with a uniform <paramref name="width"/> and segment-by-segment coloring. Each segment is defined by two consecutive points from <paramref name="points"/> array in local space and a corresponding color from <paramref name="colors"/> array, i.e. i-th segment consists of <c>points[2 * i]</c>, <c>points[2 * i + 1]</c> endpoints and has <c>colors[i]</c> color. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw interconnected lines, use <see cref="Godot.CanvasItem.DrawPolylineColors(Vector2[], Color[], float, bool)"/> instead.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para><b>Note:</b> <paramref name="antialiased"/> is only effective if <paramref name="width"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    public void DrawMultilineColors(Vector2[] points, Color[] colors, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_4_245(MethodBind31, GodotObject.GetPtr(this), points, colors, width, antialiased.ToGodotBool());
    }

    /// <summary>
    /// <para>Draws multiple disconnected lines with a uniform <paramref name="width"/> and segment-by-segment coloring. Each segment is defined by two consecutive points from <paramref name="points"/> array in local space and a corresponding color from <paramref name="colors"/> array, i.e. i-th segment consists of <c>points[2 * i]</c>, <c>points[2 * i + 1]</c> endpoints and has <c>colors[i]</c> color. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw interconnected lines, use <see cref="Godot.CanvasItem.DrawPolylineColors(Vector2[], Color[], float, bool)"/> instead.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para><b>Note:</b> <paramref name="antialiased"/> is only effective if <paramref name="width"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    public void DrawMultilineColors(ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, float width, bool antialiased)
    {
        NativeCalls.godot_icall_4_245(MethodBind31, GodotObject.GetPtr(this), points, colors, width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawRect, 2773573813ul);

    /// <summary>
    /// <para>Draws a rectangle. If <paramref name="filled"/> is <see langword="true"/>, the rectangle will be filled with the <paramref name="color"/> specified. If <paramref name="filled"/> is <see langword="false"/>, the rectangle will be drawn as a stroke with the <paramref name="color"/> and <paramref name="width"/> specified. The <paramref name="rect"/> is specified in local space. See also <see cref="Godot.CanvasItem.DrawTextureRect(Texture2D, Rect2, bool, Nullable{Color}, bool)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para>If <paramref name="antialiased"/> is <see langword="true"/>, half transparent "feathers" will be attached to the boundary, making outlines smooth.</para>
    /// <para><b>Note:</b> <paramref name="width"/> is only effective if <paramref name="filled"/> is <see langword="false"/>.</para>
    /// <para><b>Note:</b> Unfilled rectangles drawn with a negative <paramref name="width"/> may not display perfectly. For example, corners may be missing or brighter due to overlapping lines (for a translucent <paramref name="color"/>).</para>
    /// </summary>
    public unsafe void DrawRect(Rect2 rect, Color color, bool filled = true, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_5_248(MethodBind32, GodotObject.GetPtr(this), &rect, &color, filled.ToGodotBool(), width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawCircle, 3153026596ul);

    /// <summary>
    /// <para>Draws a circle, with <paramref name="position"/> defined in local space. See also <see cref="Godot.CanvasItem.DrawEllipse(Vector2, float, float, Color, bool, float, bool)"/>, <see cref="Godot.CanvasItem.DrawArc(Vector2, float, float, float, int, Color, float, bool)"/>, <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/>, and <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para>If <paramref name="filled"/> is <see langword="true"/>, the circle will be filled with the <paramref name="color"/> specified. If <paramref name="filled"/> is <see langword="false"/>, the circle will be drawn as a stroke with the <paramref name="color"/> and <paramref name="width"/> specified.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para>If <paramref name="antialiased"/> is <see langword="true"/>, half transparent "feathers" will be attached to the boundary, making outlines smooth.</para>
    /// <para><b>Note:</b> <paramref name="width"/> is only effective if <paramref name="filled"/> is <see langword="false"/>.</para>
    /// </summary>
    public unsafe void DrawCircle(Vector2 position, float radius, Color color, bool filled = true, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_6_249(MethodBind33, GodotObject.GetPtr(this), &position, radius, &color, filled.ToGodotBool(), width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawEllipse, 3790774806ul);

    /// <summary>
    /// <para>Draws an ellipse with semi-major axis <paramref name="major"/> and semi-minor axis <paramref name="minor"/>. See also <see cref="Godot.CanvasItem.DrawCircle(Vector2, float, Color, bool, float, bool)"/>, <see cref="Godot.CanvasItem.DrawEllipseArc(Vector2, float, float, float, float, int, Color, float, bool)"/>, <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/>, and <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para>If <paramref name="filled"/> is <see langword="true"/>, the ellipse will be filled with the <paramref name="color"/> specified. If <paramref name="filled"/> is <see langword="false"/>, the ellipse will be drawn as a stroke with the <paramref name="color"/> and <paramref name="width"/> specified.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para>If <paramref name="antialiased"/> is <see langword="true"/>, half transparent "feathers" will be attached to the boundary, making outlines smooth.</para>
    /// <para><b>Note:</b> <paramref name="width"/> is only effective if <paramref name="filled"/> is <see langword="false"/>.</para>
    /// </summary>
    public unsafe void DrawEllipse(Vector2 position, float major, float minor, Color color, bool filled = true, float width = -1.0f, bool antialiased = false)
    {
        NativeCalls.godot_icall_7_250(MethodBind34, GodotObject.GetPtr(this), &position, major, minor, &color, filled.ToGodotBool(), width, antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawTexture, 520200117ul);

    /// <summary>
    /// <para>Draws a texture at a given position. The <paramref name="position"/> is defined in local space.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawTexture(Texture2D texture, Vector2 position, Nullable<Color> modulate = null)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_3_251(MethodBind35, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), &position, &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawTextureRect, 3832805018ul);

    /// <summary>
    /// <para>Draws a textured rectangle at a given position, optionally modulated by a color. The <paramref name="rect"/> is defined in local space. If <paramref name="transpose"/> is <see langword="true"/>, the texture will have its X and Y coordinates swapped. See also <see cref="Godot.CanvasItem.DrawRect(Rect2, Color, bool, float, bool)"/> and <see cref="Godot.CanvasItem.DrawTextureRectRegion(Texture2D, Rect2, Rect2, Nullable{Color}, bool, bool)"/>.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawTextureRect(Texture2D texture, Rect2 rect, bool tile, Nullable<Color> modulate = null, bool transpose = false)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_5_252(MethodBind36, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), &rect, tile.ToGodotBool(), &modulateOrDefVal, transpose.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawTextureRectRegion, 3883821411ul);

    /// <summary>
    /// <para>Draws a textured rectangle from a texture's region (specified by <paramref name="srcRect"/>) at a given position in local space, optionally modulated by a color. If <paramref name="transpose"/> is <see langword="true"/>, the texture will have its X and Y coordinates swapped. See also <see cref="Godot.CanvasItem.DrawTextureRect(Texture2D, Rect2, bool, Nullable{Color}, bool)"/>.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawTextureRectRegion(Texture2D texture, Rect2 rect, Rect2 srcRect, Nullable<Color> modulate = null, bool transpose = false, bool clipUV = true)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_6_253(MethodBind37, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), &rect, &srcRect, &modulateOrDefVal, transpose.ToGodotBool(), clipUV.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMsdfTextureRectRegion, 4219163252ul);

    /// <summary>
    /// <para>Draws a textured rectangle region of the multichannel signed distance field texture at a given position, optionally modulated by a color. The <paramref name="rect"/> is defined in local space. See <see cref="Godot.FontFile.MultichannelSignedDistanceField"/> for more information and caveats about MSDF font rendering.</para>
    /// <para>If <paramref name="outline"/> is positive, each alpha channel value of pixel in region is set to maximum value of true distance in the <paramref name="outline"/> radius.</para>
    /// <para>Value of the <paramref name="pixelRange"/> should the same that was used during distance field texture generation.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawMsdfTextureRectRegion(Texture2D texture, Rect2 rect, Rect2 srcRect, Nullable<Color> modulate = null, double outline = 0.0, double pixelRange = 4.0, double scale = 1.0)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_7_254(MethodBind38, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), &rect, &srcRect, &modulateOrDefVal, outline, pixelRange, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawLcdTextureRectRegion, 3212350954ul);

    /// <summary>
    /// <para>Draws a textured rectangle region of the font texture with LCD subpixel anti-aliasing at a given position, optionally modulated by a color. The <paramref name="rect"/> is defined in local space.</para>
    /// <para>Texture is drawn using the following blend operation, blend mode of the <see cref="Godot.CanvasItemMaterial"/> is ignored:</para>
    /// <para><code>
    /// dst.r = texture.r * modulate.r * modulate.a + dst.r * (1.0 - texture.r * modulate.a);
    /// dst.g = texture.g * modulate.g * modulate.a + dst.g * (1.0 - texture.g * modulate.a);
    /// dst.b = texture.b * modulate.b * modulate.a + dst.b * (1.0 - texture.b * modulate.a);
    /// dst.a = modulate.a + dst.a * (1.0 - modulate.a);
    /// </code></para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawLcdTextureRectRegion(Texture2D texture, Rect2 rect, Rect2 srcRect, Nullable<Color> modulate = null)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_4_255(MethodBind39, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), &rect, &srcRect, &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawStyleBox, 388176283ul);

    /// <summary>
    /// <para>Draws a styled rectangle. The <paramref name="rect"/> is defined in local space.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    public unsafe void DrawStyleBox(StyleBox styleBox, Rect2 rect)
    {
        NativeCalls.godot_icall_2_256(MethodBind40, GodotObject.GetPtr(this), GodotObject.GetPtr(styleBox), &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawPrimitive, 3288481815ul);

    /// <summary>
    /// <para>Draws a custom primitive. 1 point for a point, 2 points for a line, 3 points for a triangle, and 4 points for a quad. If 0 points or more than 4 points are specified, nothing will be drawn and an error message will be printed. The <paramref name="points"/> array is defined in local space. See also <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/>, <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/>, <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>, and <see cref="Godot.CanvasItem.DrawRect(Rect2, Color, bool, float, bool)"/>.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    public void DrawPrimitive(Vector2[] points, Color[] colors, Vector2[] uvs, Texture2D texture = null)
    {
        NativeCalls.godot_icall_4_257(MethodBind41, GodotObject.GetPtr(this), points, colors, uvs, GodotObject.GetPtr(texture));
    }

    /// <summary>
    /// <para>Draws a custom primitive. 1 point for a point, 2 points for a line, 3 points for a triangle, and 4 points for a quad. If 0 points or more than 4 points are specified, nothing will be drawn and an error message will be printed. The <paramref name="points"/> array is defined in local space. See also <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/>, <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/>, <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>, and <see cref="Godot.CanvasItem.DrawRect(Rect2, Color, bool, float, bool)"/>.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    public void DrawPrimitive(ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, ReadOnlySpan<Vector2> uvs, Texture2D texture)
    {
        NativeCalls.godot_icall_4_257(MethodBind41, GodotObject.GetPtr(this), points, colors, uvs, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawPolygon, 974537912ul);

    /// <summary>
    /// <para>Draws a solid polygon of any number of points, convex or concave. Unlike <see cref="Godot.CanvasItem.DrawColoredPolygon(Vector2[], Color, Vector2[], Texture2D)"/>, each point's color can be changed individually. The <paramref name="points"/> array is defined in local space. See also <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawPolylineColors(Vector2[], Color[], float, bool)"/>. If you need more flexibility (such as being able to use bones), use <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/> instead.</para>
    /// <para><b>Note:</b> If you frequently redraw the same polygon with a large number of vertices, consider pre-calculating the triangulation with <see cref="Godot.Geometry2D.TriangulatePolygon(Vector2[])"/> and using <see cref="Godot.CanvasItem.DrawMesh(Mesh, Texture2D, Nullable{Transform2D}, Nullable{Color})"/>, <see cref="Godot.CanvasItem.DrawMultimesh(MultiMesh, Texture2D)"/>, or <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/>.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    /// <param name="uvs">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector2&gt;()</c>.</param>
    public void DrawPolygon(Vector2[] points, Color[] colors, Vector2[] uvs = null, Texture2D texture = null)
    {
        Vector2[] uvsOrDefVal = uvs != null ? uvs : Array.Empty<Vector2>();
        NativeCalls.godot_icall_4_257(MethodBind42, GodotObject.GetPtr(this), points, colors, uvsOrDefVal, GodotObject.GetPtr(texture));
    }

    /// <summary>
    /// <para>Draws a solid polygon of any number of points, convex or concave. Unlike <see cref="Godot.CanvasItem.DrawColoredPolygon(Vector2[], Color, Vector2[], Texture2D)"/>, each point's color can be changed individually. The <paramref name="points"/> array is defined in local space. See also <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/> and <see cref="Godot.CanvasItem.DrawPolylineColors(Vector2[], Color[], float, bool)"/>. If you need more flexibility (such as being able to use bones), use <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/> instead.</para>
    /// <para><b>Note:</b> If you frequently redraw the same polygon with a large number of vertices, consider pre-calculating the triangulation with <see cref="Godot.Geometry2D.TriangulatePolygon(Vector2[])"/> and using <see cref="Godot.CanvasItem.DrawMesh(Mesh, Texture2D, Nullable{Transform2D}, Nullable{Color})"/>, <see cref="Godot.CanvasItem.DrawMultimesh(MultiMesh, Texture2D)"/>, or <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/>.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    public void DrawPolygon(ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, ReadOnlySpan<Vector2> uvs, Texture2D texture)
    {
        NativeCalls.godot_icall_4_257(MethodBind42, GodotObject.GetPtr(this), points, colors, uvs, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawColoredPolygon, 15245644ul);

    /// <summary>
    /// <para>Draws a colored polygon of any number of points, convex or concave. The points in the <paramref name="points"/> array are defined in local space. Unlike <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>, a single color must be specified for the whole polygon.</para>
    /// <para><b>Note:</b> If you frequently redraw the same polygon with a large number of vertices, consider pre-calculating the triangulation with <see cref="Godot.Geometry2D.TriangulatePolygon(Vector2[])"/> and using <see cref="Godot.CanvasItem.DrawMesh(Mesh, Texture2D, Nullable{Transform2D}, Nullable{Color})"/>, <see cref="Godot.CanvasItem.DrawMultimesh(MultiMesh, Texture2D)"/>, or <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/>.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    /// <param name="uvs">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector2&gt;()</c>.</param>
    public unsafe void DrawColoredPolygon(Vector2[] points, Color color, Vector2[] uvs = null, Texture2D texture = null)
    {
        Vector2[] uvsOrDefVal = uvs != null ? uvs : Array.Empty<Vector2>();
        NativeCalls.godot_icall_4_258(MethodBind43, GodotObject.GetPtr(this), points, &color, uvsOrDefVal, GodotObject.GetPtr(texture));
    }

    /// <summary>
    /// <para>Draws a colored polygon of any number of points, convex or concave. The points in the <paramref name="points"/> array are defined in local space. Unlike <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>, a single color must be specified for the whole polygon.</para>
    /// <para><b>Note:</b> If you frequently redraw the same polygon with a large number of vertices, consider pre-calculating the triangulation with <see cref="Godot.Geometry2D.TriangulatePolygon(Vector2[])"/> and using <see cref="Godot.CanvasItem.DrawMesh(Mesh, Texture2D, Nullable{Transform2D}, Nullable{Color})"/>, <see cref="Godot.CanvasItem.DrawMultimesh(MultiMesh, Texture2D)"/>, or <see cref="Godot.RenderingServer.CanvasItemAddTriangleArray(Rid, int[], Vector2[], Color[], Vector2[], int[], float[], Rid, int)"/>.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    public unsafe void DrawColoredPolygon(ReadOnlySpan<Vector2> points, Color color, ReadOnlySpan<Vector2> uvs, Texture2D texture)
    {
        NativeCalls.godot_icall_4_258(MethodBind43, GodotObject.GetPtr(this), points, &color, uvs, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawString, 719605945ul);

    /// <summary>
    /// <para>Draws <paramref name="text"/> using the specified <paramref name="font"/> at the <paramref name="pos"/> in local space (bottom-left corner using the baseline of the font). The text will have its color multiplied by <paramref name="modulate"/>. If <paramref name="width"/> is greater than or equal to 0, the text will be clipped if it exceeds the specified width. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><b>Example:</b> Draw "Hello world", using the project's default font:</para>
    /// <para><code>
    /// DrawString(ThemeDB.FallbackFont, new Vector2(64, 64), "Hello world", HorizontalAlignment.Left, -1, ThemeDB.FallbackFontSize);
    /// </code></para>
    /// <para>See also <see cref="Godot.Font.DrawString(Rid, Vector2, string, HorizontalAlignment, float, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawString(Font font, Vector2 pos, string text, HorizontalAlignment alignment = (HorizontalAlignment)(0), float width = (float)(-1), int fontSize = 16, Nullable<Color> modulate = null, TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3), TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0), float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_11_259(MethodBind44, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, text, (int)alignment, width, fontSize, &modulateOrDefVal, (int)justificationFlags, (int)direction, (int)orientation, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultilineString, 2341488182ul);

    /// <summary>
    /// <para>Breaks <paramref name="text"/> into lines and draws it using the specified <paramref name="font"/> at the <paramref name="pos"/> in local space (top-left corner). The text will have its color multiplied by <paramref name="modulate"/>. If <paramref name="width"/> is greater than or equal to 0, the text will be clipped if it exceeds the specified width. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawMultilineString(Font font, Vector2 pos, string text, HorizontalAlignment alignment = (HorizontalAlignment)(0), float width = (float)(-1), int fontSize = 16, int maxLines = -1, Nullable<Color> modulate = null, TextServer.LineBreakFlag brkFlags = (TextServer.LineBreakFlag)(3), TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3), TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0), float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_13_260(MethodBind45, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, text, (int)alignment, width, fontSize, maxLines, &modulateOrDefVal, (int)brkFlags, (int)justificationFlags, (int)direction, (int)orientation, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawStringOutline, 707403449ul);

    /// <summary>
    /// <para>Draws <paramref name="text"/> outline using the specified <paramref name="font"/> at the <paramref name="pos"/> in local space (bottom-left corner using the baseline of the font). The text will have its color multiplied by <paramref name="modulate"/>. If <paramref name="width"/> is greater than or equal to 0, the text will be clipped if it exceeds the specified width. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawStringOutline(Font font, Vector2 pos, string text, HorizontalAlignment alignment = (HorizontalAlignment)(0), float width = (float)(-1), int fontSize = 16, int size = 1, Nullable<Color> modulate = null, TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3), TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0), float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_12_261(MethodBind46, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, text, (int)alignment, width, fontSize, size, &modulateOrDefVal, (int)justificationFlags, (int)direction, (int)orientation, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultilineStringOutline, 3050414441ul);

    /// <summary>
    /// <para>Breaks <paramref name="text"/> to the lines and draws text outline using the specified <paramref name="font"/> at the <paramref name="pos"/> in local space (top-left corner). The text will have its color multiplied by <paramref name="modulate"/>. If <paramref name="width"/> is greater than or equal to 0, the text will be clipped if it exceeds the specified width. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawMultilineStringOutline(Font font, Vector2 pos, string text, HorizontalAlignment alignment = (HorizontalAlignment)(0), float width = (float)(-1), int fontSize = 16, int maxLines = -1, int size = 1, Nullable<Color> modulate = null, TextServer.LineBreakFlag brkFlags = (TextServer.LineBreakFlag)(3), TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3), TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0), float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_14_262(MethodBind47, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, text, (int)alignment, width, fontSize, maxLines, size, &modulateOrDefVal, (int)brkFlags, (int)justificationFlags, (int)direction, (int)orientation, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawChar, 1336210142ul);

    /// <summary>
    /// <para>Draws a string first character using a custom font. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used. <paramref name="pos"/> is defined in local space.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawChar(Font font, Vector2 pos, string @char, int fontSize = 16, Nullable<Color> modulate = null, float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_6_263(MethodBind48, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, @char, fontSize, &modulateOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawCharOutline, 1846384149ul);

    /// <summary>
    /// <para>Draws a string first character outline using a custom font. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used. <paramref name="pos"/> is defined in local space.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawCharOutline(Font font, Vector2 pos, string @char, int fontSize = 16, int size = -1, Nullable<Color> modulate = null, float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_7_264(MethodBind49, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, @char, fontSize, size, &modulateOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMesh, 153818295ul);

    /// <summary>
    /// <para>Draws a <see cref="Godot.Mesh"/> in 2D, using the provided texture. See <see cref="Godot.MeshInstance2D"/> for related documentation. The <paramref name="transform"/> is defined in local space.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform2D.Identity</c>.</param>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawMesh(Mesh mesh, Texture2D texture, Nullable<Transform2D> transform = null, Nullable<Color> modulate = null)
    {
        Transform2D transformOrDefVal = transform.HasValue ? transform.Value : Transform2D.Identity;
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_4_265(MethodBind50, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh), GodotObject.GetPtr(texture), &transformOrDefVal, &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultimesh, 937992368ul);

    /// <summary>
    /// <para>Draws a <see cref="Godot.MultiMesh"/> in 2D with the provided texture. See <see cref="Godot.MultiMeshInstance2D"/> for related documentation.</para>
    /// <para><b>Note:</b> Styleboxes, textures, and meshes stored only inside local variables should <b>not</b> be used with this method in GDScript, because the drawing operation doesn't begin immediately once this method is called. In GDScript, when the function with the local variables ends, the local variables get destroyed before the rendering takes place.</para>
    /// </summary>
    public void DrawMultimesh(MultiMesh multimesh, Texture2D texture)
    {
        NativeCalls.godot_icall_2_239(MethodBind51, GodotObject.GetPtr(this), GodotObject.GetPtr(multimesh), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawSetTransform, 288975085ul);

    /// <summary>
    /// <para>Sets a custom local transform for drawing via components. Anything drawn afterwards will be transformed by this.</para>
    /// <para><b>Note:</b> <see cref="Godot.FontFile.Oversampling"/> does <i>not</i> take <paramref name="scale"/> into account. This means that scaling up/down will cause bitmap fonts and rasterized (non-MSDF) dynamic fonts to appear blurry or pixelated. To ensure text remains crisp regardless of scale, you can enable MSDF font rendering by enabling <c>ProjectSettings.gui/theme/default_font_multichannel_signed_distance_field</c> (applies to the default project font only), or enabling <b>Multichannel Signed Distance Field</b> in the import options of a DynamicFont for custom fonts. On system fonts, <see cref="Godot.SystemFont.MultichannelSignedDistanceField"/> can be enabled in the inspector.</para>
    /// </summary>
    /// <param name="scale">If the parameter is null, then the default value is <c>new Vector2(1.0f, 1.0f)</c>.</param>
    public unsafe void DrawSetTransform(Vector2 position, float rotation = 0.0f, Nullable<Vector2> scale = null)
    {
        Vector2 scaleOrDefVal = scale.HasValue ? scale.Value : new Vector2(1.0f, 1.0f);
        NativeCalls.godot_icall_3_266(MethodBind52, GodotObject.GetPtr(this), &position, rotation, &scaleOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawSetTransformMatrix, 2761652528ul);

    /// <summary>
    /// <para>Sets a custom local transform for drawing via matrix. Anything drawn afterwards will be transformed by this.</para>
    /// </summary>
    public unsafe void DrawSetTransformMatrix(Transform2D xform)
    {
        NativeCalls.godot_icall_1_218(MethodBind53, GodotObject.GetPtr(this), &xform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawAnimationSlice, 3112831842ul);

    /// <summary>
    /// <para>Subsequent drawing commands will be ignored unless they fall within the specified animation slice. This is a faster way to implement animations that loop on background rather than redrawing constantly.</para>
    /// </summary>
    public void DrawAnimationSlice(double animationLength, double sliceBegin, double sliceEnd, double offset = 0.0)
    {
        NativeCalls.godot_icall_4_267(MethodBind54, GodotObject.GetPtr(this), animationLength, sliceBegin, sliceEnd, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawEndAnimation, 3218959716ul);

    /// <summary>
    /// <para>After submitting all animations slices via <see cref="Godot.CanvasItem.DrawAnimationSlice(double, double, double, double)"/>, this function can be used to revert drawing to its default state (all subsequent drawing commands will be visible). If you don't care about this particular use case, usage of this function after submitting the slices is not required.</para>
    /// </summary>
    public void DrawEndAnimation()
    {
        NativeCalls.godot_icall_0_3(MethodBind55, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransform, 3814499831ul);

    /// <summary>
    /// <para>Returns the transform matrix of this <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public Transform2D GetTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind56, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalTransform, 3814499831ul);

    /// <summary>
    /// <para>Returns the global transform matrix of this item, i.e. the combined transform up to the topmost <see cref="Godot.CanvasItem"/> node. The topmost item is a <see cref="Godot.CanvasItem"/> that either has no parent, has non-<see cref="Godot.CanvasItem"/> parent or it has <see cref="Godot.CanvasItem.TopLevel"/> enabled.</para>
    /// </summary>
    public Transform2D GetGlobalTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalTransformWithCanvas, 3814499831ul);

    /// <summary>
    /// <para>Returns the transform from the local coordinate system of this <see cref="Godot.CanvasItem"/> to the <see cref="Godot.Viewport"/>s coordinate system.</para>
    /// </summary>
    public Transform2D GetGlobalTransformWithCanvas()
    {
        return NativeCalls.godot_icall_0_219(MethodBind58, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewportTransform, 3814499831ul);

    /// <summary>
    /// <para>Returns the transform of this node, converted from its registered canvas's coordinate system to its viewport embedder's coordinate system. See also <see cref="Godot.Viewport.GetFinalTransform()"/> and <see cref="Godot.Node.GetViewport()"/>.</para>
    /// </summary>
    public Transform2D GetViewportTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewportRect, 1639390495ul);

    /// <summary>
    /// <para>Returns this node's viewport boundaries as a <see cref="Godot.Rect2"/>. See also <see cref="Godot.Node.GetViewport()"/>.</para>
    /// </summary>
    public Rect2 GetViewportRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind60, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvasTransform, 3814499831ul);

    /// <summary>
    /// <para>Returns the transform of this node, converted from its registered canvas's coordinate system to its viewport's coordinate system. See also <see cref="Godot.Node.GetViewport()"/>.</para>
    /// </summary>
    public Transform2D GetCanvasTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind61, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenTransform, 3814499831ul);

    /// <summary>
    /// <para>Returns the transform of this <see cref="Godot.CanvasItem"/> in global screen coordinates (i.e. taking window position into account). Mostly useful for editor plugins.</para>
    /// <para>Equivalent to <see cref="Godot.CanvasItem.GetGlobalTransformWithCanvas()"/> if the window is embedded (see <see cref="Godot.Viewport.GuiEmbedSubwindows"/>).</para>
    /// </summary>
    public Transform2D GetScreenTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind62, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalMousePosition, 3341600327ul);

    /// <summary>
    /// <para>Returns the mouse's position in this <see cref="Godot.CanvasItem"/> using the local coordinate system of this <see cref="Godot.CanvasItem"/>.</para>
    /// </summary>
    public Vector2 GetLocalMousePosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind63, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalMousePosition, 3341600327ul);

    /// <summary>
    /// <para>Returns mouse cursor's global position relative to the <see cref="Godot.CanvasLayer"/> that contains this node.</para>
    /// <para><b>Note:</b> For screen-space coordinates (e.g. when using a non-embedded <see cref="Godot.Popup"/>), you can use <see cref="Godot.DisplayServer.MouseGetPosition()"/>.</para>
    /// </summary>
    public Vector2 GetGlobalMousePosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind64, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvas, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the <see cref="Godot.World2D"/> canvas where this node is registered to, used by the <see cref="Godot.RenderingServer"/>.</para>
    /// </summary>
    public Rid GetCanvas()
    {
        return NativeCalls.godot_icall_0_238(MethodBind65, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvasLayerNode, 2602762519ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.CanvasLayer"/> that contains this node, or <see langword="null"/> if the node is not in any <see cref="Godot.CanvasLayer"/>.</para>
    /// </summary>
    public CanvasLayer GetCanvasLayerNode()
    {
        return (CanvasLayer)NativeCalls.godot_icall_0_53(MethodBind66, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWorld2D, 2339128592ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.World2D"/> this node is registered to.</para>
    /// <para>Usually, this is the same as this node's viewport (see <see cref="Godot.Node.GetViewport()"/> and <see cref="Godot.Viewport.FindWorld2D()"/>).</para>
    /// </summary>
    public World2D GetWorld2D()
    {
        return (World2D)NativeCalls.godot_icall_0_63(MethodBind67, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaterial, 2757459619ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaterial(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind68, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaterial, 5934680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Material GetMaterial()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind69, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInstanceShaderParameter, 3776071444ul);

    /// <summary>
    /// <para>Set the value of a shader uniform for this instance only (<a href="$DOCS_URL/tutorials/shaders/shader_reference/shading_language.html#per-instance-uniforms">per-instance uniform</a>). See also <see cref="Godot.ShaderMaterial.SetShaderParameter(StringName, Variant)"/> to assign a uniform on all instances using the same <see cref="Godot.ShaderMaterial"/>.</para>
    /// <para><b>Note:</b> For a shader uniform to be assignable on a per-instance basis, it <i>must</i> be defined with <c>instance uniform ...</c> rather than <c>uniform ...</c> in the shader code.</para>
    /// <para><b>Note:</b> <paramref name="name"/> is case-sensitive and must match the name of the uniform in the code exactly (not the capitalized name in the inspector).</para>
    /// </summary>
    public void SetInstanceShaderParameter(StringName name, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind70, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceShaderParameter, 2760726917ul);

    /// <summary>
    /// <para>Get the value of a shader parameter as set on this instance.</para>
    /// </summary>
    public Variant GetInstanceShaderParameter(StringName name)
    {
        return NativeCalls.godot_icall_1_143(MethodBind71, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseParentMaterial, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseParentMaterial(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind72, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseParentMaterial, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseParentMaterial()
    {
        return NativeCalls.godot_icall_0_15(MethodBind73, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNotifyLocalTransform, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the node will receive <see cref="Godot.CanvasItem.NotificationLocalTransformChanged"/> whenever its local transform changes.</para>
    /// <para><b>Note:</b> Many canvas items such as <see cref="Godot.Bone2D"/> or <see cref="Godot.CollisionShape2D"/> automatically enable this in order to function correctly.</para>
    /// </summary>
    public void SetNotifyLocalTransform(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind74, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLocalTransformNotificationEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node receives <see cref="Godot.CanvasItem.NotificationLocalTransformChanged"/> whenever its local transform changes. This is enabled with <see cref="Godot.CanvasItem.SetNotifyLocalTransform(bool)"/>.</para>
    /// </summary>
    public bool IsLocalTransformNotificationEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind75, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNotifyTransform, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the node will receive <see cref="Godot.CanvasItem.NotificationTransformChanged"/> whenever its global transform changes.</para>
    /// <para><b>Note:</b> Many canvas items such as <see cref="Godot.Camera2D"/> or <see cref="Godot.Light2D"/> automatically enable this in order to function correctly.</para>
    /// </summary>
    public void SetNotifyTransform(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind76, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTransformNotificationEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node receives <see cref="Godot.CanvasItem.NotificationTransformChanged"/> whenever its global transform changes. This is enabled with <see cref="Godot.CanvasItem.SetNotifyTransform(bool)"/>.</para>
    /// </summary>
    public bool IsTransformNotificationEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind77, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceUpdateTransform, 3218959716ul);

    /// <summary>
    /// <para>Forces the node's transform to update. Fails if the node is not inside the tree. See also <see cref="Godot.CanvasItem.GetTransform()"/>.</para>
    /// <para><b>Note:</b> For performance reasons, transform changes are usually accumulated and applied <i>once</i> at the end of the frame. The update propagates through <see cref="Godot.CanvasItem"/> children, as well. Therefore, use this method only when you need an up-to-date transform (such as during physics operations).</para>
    /// </summary>
    public void ForceUpdateTransform()
    {
        NativeCalls.godot_icall_0_3(MethodBind78, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeCanvasPositionLocal, 2656412154ul);

    /// <summary>
    /// <para>Transforms <paramref name="viewportPoint"/> from the viewport's coordinates to this node's local coordinates.</para>
    /// <para>For the opposite operation, use <see cref="Godot.CanvasItem.GetGlobalTransformWithCanvas()"/>.</para>
    /// <para><code>
    /// var viewport_point = get_global_transform_with_canvas() * local_point
    /// </code></para>
    /// </summary>
    public unsafe Vector2 MakeCanvasPositionLocal(Vector2 viewportPoint)
    {
        return NativeCalls.godot_icall_1_20(MethodBind79, GodotObject.GetPtr(this), &viewportPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeInputLocal, 811130057ul);

    /// <summary>
    /// <para>Returns a copy of the given <paramref name="event"/> with its coordinates converted from global space to this <see cref="Godot.CanvasItem"/>'s local space. If not possible, returns the same <see cref="Godot.InputEvent"/> unchanged.</para>
    /// </summary>
    public InputEvent MakeInputLocal(InputEvent @event)
    {
        return (InputEvent)NativeCalls.godot_icall_1_268(MethodBind80, GodotObject.GetPtr(this), GodotObject.GetPtr(@event));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityLayer, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityLayer(uint layer)
    {
        NativeCalls.godot_icall_1_208(MethodBind81, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityLayer, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetVisibilityLayer()
    {
        return NativeCalls.godot_icall_0_209(MethodBind82, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityLayerBit, 300928843ul);

    /// <summary>
    /// <para>Set/clear individual bits on the rendering visibility layer. This simplifies editing this <see cref="Godot.CanvasItem"/>'s visibility layer.</para>
    /// </summary>
    public void SetVisibilityLayerBit(uint layer, bool enabled)
    {
        NativeCalls.godot_icall_2_269(MethodBind83, GodotObject.GetPtr(this), layer, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityLayerBit, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the layer at the given index is set in <see cref="Godot.CanvasItem.VisibilityLayer"/>.</para>
    /// </summary>
    public bool GetVisibilityLayerBit(uint layer)
    {
        return NativeCalls.godot_icall_1_270(MethodBind84, GodotObject.GetPtr(this), layer).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureFilter, 1037999706ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureFilter(CanvasItem.TextureFilterEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind85, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureFilter, 121960042ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CanvasItem.TextureFilterEnum GetTextureFilter()
    {
        return (CanvasItem.TextureFilterEnum)NativeCalls.godot_icall_0_39(MethodBind86, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureRepeat, 1716472974ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureRepeat(CanvasItem.TextureRepeatEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind87, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureRepeat, 2667158319ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CanvasItem.TextureRepeatEnum GetTextureRepeat()
    {
        return (CanvasItem.TextureRepeatEnum)NativeCalls.godot_icall_0_39(MethodBind88, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipChildrenMode, 1319393776ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClipChildrenMode(CanvasItem.ClipChildrenMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind89, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClipChildrenMode, 3581808349ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CanvasItem.ClipChildrenMode GetClipChildrenMode()
    {
        return (CanvasItem.ClipChildrenMode)NativeCalls.godot_icall_0_39(MethodBind90, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultilineColors, 4072951537ul);

    /// <summary>
    /// <para>Draws multiple disconnected lines with a uniform <paramref name="width"/> and segment-by-segment coloring. Each segment is defined by two consecutive points from <paramref name="points"/> array in local space and a corresponding color from <paramref name="colors"/> array, i.e. i-th segment consists of <c>points[2 * i]</c>, <c>points[2 * i + 1]</c> endpoints and has <c>colors[i]</c> color. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw interconnected lines, use <see cref="Godot.CanvasItem.DrawPolylineColors(Vector2[], Color[], float, bool)"/> instead.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para><b>Note:</b> <paramref name="antialiased"/> is only effective if <paramref name="width"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void DrawMultilineColors(Vector2[] points, Color[] colors, float width)
    {
        NativeCalls.godot_icall_3_271(MethodBind91, GodotObject.GetPtr(this), points, colors, width);
    }

    /// <summary>
    /// <para>Draws multiple disconnected lines with a uniform <paramref name="width"/> and segment-by-segment coloring. Each segment is defined by two consecutive points from <paramref name="points"/> array in local space and a corresponding color from <paramref name="colors"/> array, i.e. i-th segment consists of <c>points[2 * i]</c>, <c>points[2 * i + 1]</c> endpoints and has <c>colors[i]</c> color. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw interconnected lines, use <see cref="Godot.CanvasItem.DrawPolylineColors(Vector2[], Color[], float, bool)"/> instead.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para><b>Note:</b> <paramref name="antialiased"/> is only effective if <paramref name="width"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void DrawMultilineColors(ReadOnlySpan<Vector2> points, ReadOnlySpan<Color> colors, float width)
    {
        NativeCalls.godot_icall_3_271(MethodBind91, GodotObject.GetPtr(this), points, colors, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultiline, 2239075205ul);

    /// <summary>
    /// <para>Draws multiple disconnected lines with a uniform <paramref name="width"/> and <paramref name="color"/>. Each line is defined by two consecutive points from <paramref name="points"/> array in local space, i.e. i-th segment consists of <c>points[2 * i]</c>, <c>points[2 * i + 1]</c> endpoints. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw interconnected lines, use <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/> instead.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para><b>Note:</b> <paramref name="antialiased"/> is only effective if <paramref name="width"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawMultiline(Vector2[] points, Color color, float width)
    {
        NativeCalls.godot_icall_3_272(MethodBind92, GodotObject.GetPtr(this), points, &color, width);
    }

    /// <summary>
    /// <para>Draws multiple disconnected lines with a uniform <paramref name="width"/> and <paramref name="color"/>. Each line is defined by two consecutive points from <paramref name="points"/> array in local space, i.e. i-th segment consists of <c>points[2 * i]</c>, <c>points[2 * i + 1]</c> endpoints. When drawing large amounts of lines, this is faster than using individual <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/> calls. To draw interconnected lines, use <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/> instead.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para><b>Note:</b> <paramref name="antialiased"/> is only effective if <paramref name="width"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawMultiline(ReadOnlySpan<Vector2> points, Color color, float width)
    {
        NativeCalls.godot_icall_3_272(MethodBind92, GodotObject.GetPtr(this), points, &color, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawDashedLine, 684651049ul);

    /// <summary>
    /// <para>Draws a dashed line from a 2D point to another, with a given color and width. The <paramref name="from"/> and <paramref name="to"/> positions are defined in local space. See also <see cref="Godot.CanvasItem.DrawLine(Vector2, Vector2, Color, float, bool)"/>, <see cref="Godot.CanvasItem.DrawMultiline(Vector2[], Color, float, bool)"/>, and <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, then a two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the line parts will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para><paramref name="dash"/> is the length of each dash in pixels, with the gap between each dash being the same length. If <paramref name="aligned"/> is <see langword="true"/>, the length of the first and last dashes may be shortened or lengthened to allow the line to begin and end at the precise points defined by <paramref name="from"/> and <paramref name="to"/>. Both ends are always symmetrical when <paramref name="aligned"/> is <see langword="true"/>. If <paramref name="aligned"/> is <see langword="false"/>, all dashes will have the same length, but the line may appear incomplete at the end due to the dash length not dividing evenly into the line length. Only full dashes are drawn when <paramref name="aligned"/> is <see langword="false"/>.</para>
    /// <para>If <paramref name="antialiased"/> is <see langword="true"/>, half transparent "feathers" will be attached to the boundary, making outlines smooth.</para>
    /// <para><b>Note:</b> <paramref name="antialiased"/> is only effective if <paramref name="width"/> is greater than <c>0.0</c>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawDashedLine(Vector2 from, Vector2 to, Color color, float width, float dash, bool aligned)
    {
        NativeCalls.godot_icall_6_273(MethodBind93, GodotObject.GetPtr(this), &from, &to, &color, width, dash, aligned.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawRect, 2417231121ul);

    /// <summary>
    /// <para>Draws a rectangle. If <paramref name="filled"/> is <see langword="true"/>, the rectangle will be filled with the <paramref name="color"/> specified. If <paramref name="filled"/> is <see langword="false"/>, the rectangle will be drawn as a stroke with the <paramref name="color"/> and <paramref name="width"/> specified. The <paramref name="rect"/> is specified in local space. See also <see cref="Godot.CanvasItem.DrawTextureRect(Texture2D, Rect2, bool, Nullable{Color}, bool)"/>.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para>If <paramref name="antialiased"/> is <see langword="true"/>, half transparent "feathers" will be attached to the boundary, making outlines smooth.</para>
    /// <para><b>Note:</b> <paramref name="width"/> is only effective if <paramref name="filled"/> is <see langword="false"/>.</para>
    /// <para><b>Note:</b> Unfilled rectangles drawn with a negative <paramref name="width"/> may not display perfectly. For example, corners may be missing or brighter due to overlapping lines (for a translucent <paramref name="color"/>).</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawRect(Rect2 rect, Color color, bool filled, float width)
    {
        NativeCalls.godot_icall_4_274(MethodBind94, GodotObject.GetPtr(this), &rect, &color, filled.ToGodotBool(), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawCircle, 3063020269ul);

    /// <summary>
    /// <para>Draws a circle, with <paramref name="position"/> defined in local space. See also <see cref="Godot.CanvasItem.DrawEllipse(Vector2, float, float, Color, bool, float, bool)"/>, <see cref="Godot.CanvasItem.DrawArc(Vector2, float, float, float, int, Color, float, bool)"/>, <see cref="Godot.CanvasItem.DrawPolyline(Vector2[], Color, float, bool)"/>, and <see cref="Godot.CanvasItem.DrawPolygon(Vector2[], Color[], Vector2[], Texture2D)"/>.</para>
    /// <para>If <paramref name="filled"/> is <see langword="true"/>, the circle will be filled with the <paramref name="color"/> specified. If <paramref name="filled"/> is <see langword="false"/>, the circle will be drawn as a stroke with the <paramref name="color"/> and <paramref name="width"/> specified.</para>
    /// <para>If <paramref name="width"/> is negative, then two-point primitives will be drawn instead of a four-point ones. This means that when the CanvasItem is scaled, the lines will remain thin. If this behavior is not desired, then pass a positive <paramref name="width"/> like <c>1.0</c>.</para>
    /// <para>If <paramref name="antialiased"/> is <see langword="true"/>, half transparent "feathers" will be attached to the boundary, making outlines smooth.</para>
    /// <para><b>Note:</b> <paramref name="width"/> is only effective if <paramref name="filled"/> is <see langword="false"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawCircle(Vector2 position, float radius, Color color)
    {
        NativeCalls.godot_icall_3_275(MethodBind95, GodotObject.GetPtr(this), &position, radius, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawCharOutline, 3302344391ul);

    /// <summary>
    /// <para>Draws a string first character outline using a custom font. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used. <paramref name="pos"/> is defined in local space.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawCharOutline(Font font, Vector2 pos, string @char, int fontSize, int size, Nullable<Color> modulate)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_6_276(MethodBind96, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, @char, fontSize, size, &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawChar, 3339793283ul);

    /// <summary>
    /// <para>Draws a string first character using a custom font. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used. <paramref name="pos"/> is defined in local space.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawChar(Font font, Vector2 pos, string @char, int fontSize, Nullable<Color> modulate)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_5_277(MethodBind97, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, @char, fontSize, &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultilineStringOutline, 1912318525ul);

    /// <summary>
    /// <para>Breaks <paramref name="text"/> to the lines and draws text outline using the specified <paramref name="font"/> at the <paramref name="pos"/> in local space (top-left corner). The text will have its color multiplied by <paramref name="modulate"/>. If <paramref name="width"/> is greater than or equal to 0, the text will be clipped if it exceeds the specified width. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawMultilineStringOutline(Font font, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, int maxLines, int size, Nullable<Color> modulate, TextServer.LineBreakFlag brkFlags, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_13_278(MethodBind98, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, text, (int)alignment, width, fontSize, maxLines, size, &modulateOrDefVal, (int)brkFlags, (int)justificationFlags, (int)direction, (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawStringOutline, 340562381ul);

    /// <summary>
    /// <para>Draws <paramref name="text"/> outline using the specified <paramref name="font"/> at the <paramref name="pos"/> in local space (bottom-left corner using the baseline of the font). The text will have its color multiplied by <paramref name="modulate"/>. If <paramref name="width"/> is greater than or equal to 0, the text will be clipped if it exceeds the specified width. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawStringOutline(Font font, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, int size, Nullable<Color> modulate, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_11_279(MethodBind99, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, text, (int)alignment, width, fontSize, size, &modulateOrDefVal, (int)justificationFlags, (int)direction, (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultilineString, 1927038192ul);

    /// <summary>
    /// <para>Breaks <paramref name="text"/> into lines and draws it using the specified <paramref name="font"/> at the <paramref name="pos"/> in local space (top-left corner). The text will have its color multiplied by <paramref name="modulate"/>. If <paramref name="width"/> is greater than or equal to 0, the text will be clipped if it exceeds the specified width. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawMultilineString(Font font, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, int maxLines, Nullable<Color> modulate, TextServer.LineBreakFlag brkFlags, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_12_280(MethodBind100, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, text, (int)alignment, width, fontSize, maxLines, &modulateOrDefVal, (int)brkFlags, (int)justificationFlags, (int)direction, (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawString, 728290553ul);

    /// <summary>
    /// <para>Draws <paramref name="text"/> using the specified <paramref name="font"/> at the <paramref name="pos"/> in local space (bottom-left corner using the baseline of the font). The text will have its color multiplied by <paramref name="modulate"/>. If <paramref name="width"/> is greater than or equal to 0, the text will be clipped if it exceeds the specified width. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><b>Example:</b> Draw "Hello world", using the project's default font:</para>
    /// <para><code>
    /// DrawString(ThemeDB.FallbackFont, new Vector2(64, 64), "Hello world", HorizontalAlignment.Left, -1, ThemeDB.FallbackFontSize);
    /// </code></para>
    /// <para>See also <see cref="Godot.Font.DrawString(Rid, Vector2, string, HorizontalAlignment, float, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawString(Font font, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, Nullable<Color> modulate, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_10_281(MethodBind101, GodotObject.GetPtr(this), GodotObject.GetPtr(font), &pos, text, (int)alignment, width, fontSize, &modulateOrDefVal, (int)justificationFlags, (int)direction, (int)orientation);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.CanvasItem"/> must redraw, <i>after</i> the related <see cref="Godot.CanvasItem.NotificationDraw"/> notification, and <i>before</i> <see cref="Godot.CanvasItem._Draw()"/> is called.</para>
    /// <para><b>Note:</b> Deferred connections do not allow drawing through the <c>draw_*</c> methods.</para>
    /// </summary>
    public event Action Draw
    {
        add => Connect(SignalName.Draw, Callable.From(value));
        remove => Disconnect(SignalName.Draw, Callable.From(value));
    }

    protected void EmitSignalDraw()
    {
        EmitSignal(SignalName.Draw);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.CanvasItem"/>'s visibility changes, either because its own <see cref="Godot.CanvasItem.Visible"/> property changed or because its visibility in the tree changed (see <see cref="Godot.CanvasItem.IsVisibleInTree()"/>).</para>
    /// <para>This signal is emitted <i>after</i> the related <see cref="Godot.CanvasItem.NotificationVisibilityChanged"/> notification.</para>
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

    /// <summary>
    /// <para>Emitted when this node becomes hidden, i.e. it's no longer visible in the tree (see <see cref="Godot.CanvasItem.IsVisibleInTree()"/>).</para>
    /// </summary>
    public event Action Hidden
    {
        add => Connect(SignalName.Hidden, Callable.From(value));
        remove => Disconnect(SignalName.Hidden, Callable.From(value));
    }

    protected void EmitSignalHidden()
    {
        EmitSignal(SignalName.Hidden);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.CanvasItem"/>'s boundaries (position or size) change, or when an action took place that may have affected these boundaries (e.g. changing <see cref="Godot.Sprite2D.Texture"/>).</para>
    /// </summary>
    public event Action ItemRectChanged
    {
        add => Connect(SignalName.ItemRectChanged, Callable.From(value));
        remove => Disconnect(SignalName.ItemRectChanged, Callable.From(value));
    }

    protected void EmitSignalItemRectChanged()
    {
        EmitSignal(SignalName.ItemRectChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__draw = "_Draw";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_draw = "Draw";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_visibility_changed = "VisibilityChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_hidden = "Hidden";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_rect_changed = "ItemRectChanged";

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
        if ((method == MethodProxyName__draw || method == MethodName._Draw) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__draw.NativeValue))
        {
            _Draw();
            ret = default;
            return true;
        }
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
        if (method == MethodName._Draw)
        {
            if (HasGodotClassMethod(MethodProxyName__draw.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        if (signal == SignalName.Draw)
        {
            if (HasGodotClassSignal(SignalProxyName_draw.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.VisibilityChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_visibility_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Hidden)
        {
            if (HasGodotClassSignal(SignalProxyName_hidden.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ItemRectChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_item_rect_changed.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'visible' property.
        /// </summary>
        public static readonly StringName Visible = "visible";
        /// <summary>
        /// Cached name for the 'modulate' property.
        /// </summary>
        public static readonly StringName Modulate = "modulate";
        /// <summary>
        /// Cached name for the 'self_modulate' property.
        /// </summary>
        public static readonly StringName SelfModulate = "self_modulate";
        /// <summary>
        /// Cached name for the 'show_behind_parent' property.
        /// </summary>
        public static readonly StringName ShowBehindParent = "show_behind_parent";
        /// <summary>
        /// Cached name for the 'top_level' property.
        /// </summary>
        public static readonly StringName TopLevel = "top_level";
        /// <summary>
        /// Cached name for the 'clip_children' property.
        /// </summary>
        public static readonly StringName ClipChildren = "clip_children";
        /// <summary>
        /// Cached name for the 'light_mask' property.
        /// </summary>
        public static readonly StringName LightMask = "light_mask";
        /// <summary>
        /// Cached name for the 'visibility_layer' property.
        /// </summary>
        public static readonly StringName VisibilityLayer = "visibility_layer";
        /// <summary>
        /// Cached name for the 'z_index' property.
        /// </summary>
        public static readonly StringName ZIndex = "z_index";
        /// <summary>
        /// Cached name for the 'z_as_relative' property.
        /// </summary>
        public static readonly StringName ZAsRelative = "z_as_relative";
        /// <summary>
        /// Cached name for the 'y_sort_enabled' property.
        /// </summary>
        public static readonly StringName YSortEnabled = "y_sort_enabled";
        /// <summary>
        /// Cached name for the 'texture_filter' property.
        /// </summary>
        public static readonly StringName TextureFilter = "texture_filter";
        /// <summary>
        /// Cached name for the 'texture_repeat' property.
        /// </summary>
        public static readonly StringName TextureRepeat = "texture_repeat";
        /// <summary>
        /// Cached name for the 'material' property.
        /// </summary>
        public static readonly StringName Material = "material";
        /// <summary>
        /// Cached name for the 'use_parent_material' property.
        /// </summary>
        public static readonly StringName UseParentMaterial = "use_parent_material";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the '_draw' method.
        /// </summary>
        public static readonly StringName _Draw = "_draw";
        /// <summary>
        /// Cached name for the 'get_canvas_item' method.
        /// </summary>
        public static readonly StringName GetCanvasItem = "get_canvas_item";
        /// <summary>
        /// Cached name for the 'set_visible' method.
        /// </summary>
        public static readonly StringName SetVisible = "set_visible";
        /// <summary>
        /// Cached name for the 'is_visible' method.
        /// </summary>
        public static readonly StringName IsVisible = "is_visible";
        /// <summary>
        /// Cached name for the 'is_visible_in_tree' method.
        /// </summary>
        public static readonly StringName IsVisibleInTree = "is_visible_in_tree";
        /// <summary>
        /// Cached name for the 'show' method.
        /// </summary>
        public static readonly StringName Show = "show";
        /// <summary>
        /// Cached name for the 'hide' method.
        /// </summary>
        public static readonly StringName Hide = "hide";
        /// <summary>
        /// Cached name for the 'queue_redraw' method.
        /// </summary>
        public static readonly StringName QueueRedraw = "queue_redraw";
        /// <summary>
        /// Cached name for the 'move_to_front' method.
        /// </summary>
        public static readonly StringName MoveToFront = "move_to_front";
        /// <summary>
        /// Cached name for the 'set_as_top_level' method.
        /// </summary>
        public static readonly StringName SetAsTopLevel = "set_as_top_level";
        /// <summary>
        /// Cached name for the 'is_set_as_top_level' method.
        /// </summary>
        public static readonly StringName IsSetAsTopLevel = "is_set_as_top_level";
        /// <summary>
        /// Cached name for the 'set_light_mask' method.
        /// </summary>
        public static readonly StringName SetLightMask = "set_light_mask";
        /// <summary>
        /// Cached name for the 'get_light_mask' method.
        /// </summary>
        public static readonly StringName GetLightMask = "get_light_mask";
        /// <summary>
        /// Cached name for the 'set_modulate' method.
        /// </summary>
        public static readonly StringName SetModulate = "set_modulate";
        /// <summary>
        /// Cached name for the 'get_modulate' method.
        /// </summary>
        public static readonly StringName GetModulate = "get_modulate";
        /// <summary>
        /// Cached name for the 'set_self_modulate' method.
        /// </summary>
        public static readonly StringName SetSelfModulate = "set_self_modulate";
        /// <summary>
        /// Cached name for the 'get_self_modulate' method.
        /// </summary>
        public static readonly StringName GetSelfModulate = "get_self_modulate";
        /// <summary>
        /// Cached name for the 'set_z_index' method.
        /// </summary>
        public static readonly StringName SetZIndex = "set_z_index";
        /// <summary>
        /// Cached name for the 'get_z_index' method.
        /// </summary>
        public static readonly StringName GetZIndex = "get_z_index";
        /// <summary>
        /// Cached name for the 'set_z_as_relative' method.
        /// </summary>
        public static readonly StringName SetZAsRelative = "set_z_as_relative";
        /// <summary>
        /// Cached name for the 'is_z_relative' method.
        /// </summary>
        public static readonly StringName IsZRelative = "is_z_relative";
        /// <summary>
        /// Cached name for the 'set_y_sort_enabled' method.
        /// </summary>
        public static readonly StringName SetYSortEnabled = "set_y_sort_enabled";
        /// <summary>
        /// Cached name for the 'is_y_sort_enabled' method.
        /// </summary>
        public static readonly StringName IsYSortEnabled = "is_y_sort_enabled";
        /// <summary>
        /// Cached name for the 'set_draw_behind_parent' method.
        /// </summary>
        public static readonly StringName SetDrawBehindParent = "set_draw_behind_parent";
        /// <summary>
        /// Cached name for the 'is_draw_behind_parent_enabled' method.
        /// </summary>
        public static readonly StringName IsDrawBehindParentEnabled = "is_draw_behind_parent_enabled";
        /// <summary>
        /// Cached name for the 'draw_line' method.
        /// </summary>
        public static readonly StringName DrawLine = "draw_line";
        /// <summary>
        /// Cached name for the 'draw_dashed_line' method.
        /// </summary>
        public static readonly StringName DrawDashedLine = "draw_dashed_line";
        /// <summary>
        /// Cached name for the 'draw_polyline' method.
        /// </summary>
        public static readonly StringName DrawPolyline = "draw_polyline";
        /// <summary>
        /// Cached name for the 'draw_polyline_colors' method.
        /// </summary>
        public static readonly StringName DrawPolylineColors = "draw_polyline_colors";
        /// <summary>
        /// Cached name for the 'draw_ellipse_arc' method.
        /// </summary>
        public static readonly StringName DrawEllipseArc = "draw_ellipse_arc";
        /// <summary>
        /// Cached name for the 'draw_arc' method.
        /// </summary>
        public static readonly StringName DrawArc = "draw_arc";
        /// <summary>
        /// Cached name for the 'draw_multiline' method.
        /// </summary>
        public static readonly StringName DrawMultiline = "draw_multiline";
        /// <summary>
        /// Cached name for the 'draw_multiline_colors' method.
        /// </summary>
        public static readonly StringName DrawMultilineColors = "draw_multiline_colors";
        /// <summary>
        /// Cached name for the 'draw_rect' method.
        /// </summary>
        public static readonly StringName DrawRect = "draw_rect";
        /// <summary>
        /// Cached name for the 'draw_circle' method.
        /// </summary>
        public static readonly StringName DrawCircle = "draw_circle";
        /// <summary>
        /// Cached name for the 'draw_ellipse' method.
        /// </summary>
        public static readonly StringName DrawEllipse = "draw_ellipse";
        /// <summary>
        /// Cached name for the 'draw_texture' method.
        /// </summary>
        public static readonly StringName DrawTexture = "draw_texture";
        /// <summary>
        /// Cached name for the 'draw_texture_rect' method.
        /// </summary>
        public static readonly StringName DrawTextureRect = "draw_texture_rect";
        /// <summary>
        /// Cached name for the 'draw_texture_rect_region' method.
        /// </summary>
        public static readonly StringName DrawTextureRectRegion = "draw_texture_rect_region";
        /// <summary>
        /// Cached name for the 'draw_msdf_texture_rect_region' method.
        /// </summary>
        public static readonly StringName DrawMsdfTextureRectRegion = "draw_msdf_texture_rect_region";
        /// <summary>
        /// Cached name for the 'draw_lcd_texture_rect_region' method.
        /// </summary>
        public static readonly StringName DrawLcdTextureRectRegion = "draw_lcd_texture_rect_region";
        /// <summary>
        /// Cached name for the 'draw_style_box' method.
        /// </summary>
        public static readonly StringName DrawStyleBox = "draw_style_box";
        /// <summary>
        /// Cached name for the 'draw_primitive' method.
        /// </summary>
        public static readonly StringName DrawPrimitive = "draw_primitive";
        /// <summary>
        /// Cached name for the 'draw_polygon' method.
        /// </summary>
        public static readonly StringName DrawPolygon = "draw_polygon";
        /// <summary>
        /// Cached name for the 'draw_colored_polygon' method.
        /// </summary>
        public static readonly StringName DrawColoredPolygon = "draw_colored_polygon";
        /// <summary>
        /// Cached name for the 'draw_string' method.
        /// </summary>
        public static readonly StringName DrawString = "draw_string";
        /// <summary>
        /// Cached name for the 'draw_multiline_string' method.
        /// </summary>
        public static readonly StringName DrawMultilineString = "draw_multiline_string";
        /// <summary>
        /// Cached name for the 'draw_string_outline' method.
        /// </summary>
        public static readonly StringName DrawStringOutline = "draw_string_outline";
        /// <summary>
        /// Cached name for the 'draw_multiline_string_outline' method.
        /// </summary>
        public static readonly StringName DrawMultilineStringOutline = "draw_multiline_string_outline";
        /// <summary>
        /// Cached name for the 'draw_char' method.
        /// </summary>
        public static readonly StringName DrawChar = "draw_char";
        /// <summary>
        /// Cached name for the 'draw_char_outline' method.
        /// </summary>
        public static readonly StringName DrawCharOutline = "draw_char_outline";
        /// <summary>
        /// Cached name for the 'draw_mesh' method.
        /// </summary>
        public static readonly StringName DrawMesh = "draw_mesh";
        /// <summary>
        /// Cached name for the 'draw_multimesh' method.
        /// </summary>
        public static readonly StringName DrawMultimesh = "draw_multimesh";
        /// <summary>
        /// Cached name for the 'draw_set_transform' method.
        /// </summary>
        public static readonly StringName DrawSetTransform = "draw_set_transform";
        /// <summary>
        /// Cached name for the 'draw_set_transform_matrix' method.
        /// </summary>
        public static readonly StringName DrawSetTransformMatrix = "draw_set_transform_matrix";
        /// <summary>
        /// Cached name for the 'draw_animation_slice' method.
        /// </summary>
        public static readonly StringName DrawAnimationSlice = "draw_animation_slice";
        /// <summary>
        /// Cached name for the 'draw_end_animation' method.
        /// </summary>
        public static readonly StringName DrawEndAnimation = "draw_end_animation";
        /// <summary>
        /// Cached name for the 'get_transform' method.
        /// </summary>
        public static readonly StringName GetTransform = "get_transform";
        /// <summary>
        /// Cached name for the 'get_global_transform' method.
        /// </summary>
        public static readonly StringName GetGlobalTransform = "get_global_transform";
        /// <summary>
        /// Cached name for the 'get_global_transform_with_canvas' method.
        /// </summary>
        public static readonly StringName GetGlobalTransformWithCanvas = "get_global_transform_with_canvas";
        /// <summary>
        /// Cached name for the 'get_viewport_transform' method.
        /// </summary>
        public static readonly StringName GetViewportTransform = "get_viewport_transform";
        /// <summary>
        /// Cached name for the 'get_viewport_rect' method.
        /// </summary>
        public static readonly StringName GetViewportRect = "get_viewport_rect";
        /// <summary>
        /// Cached name for the 'get_canvas_transform' method.
        /// </summary>
        public static readonly StringName GetCanvasTransform = "get_canvas_transform";
        /// <summary>
        /// Cached name for the 'get_screen_transform' method.
        /// </summary>
        public static readonly StringName GetScreenTransform = "get_screen_transform";
        /// <summary>
        /// Cached name for the 'get_local_mouse_position' method.
        /// </summary>
        public static readonly StringName GetLocalMousePosition = "get_local_mouse_position";
        /// <summary>
        /// Cached name for the 'get_global_mouse_position' method.
        /// </summary>
        public static readonly StringName GetGlobalMousePosition = "get_global_mouse_position";
        /// <summary>
        /// Cached name for the 'get_canvas' method.
        /// </summary>
        public static readonly StringName GetCanvas = "get_canvas";
        /// <summary>
        /// Cached name for the 'get_canvas_layer_node' method.
        /// </summary>
        public static readonly StringName GetCanvasLayerNode = "get_canvas_layer_node";
        /// <summary>
        /// Cached name for the 'get_world_2d' method.
        /// </summary>
        public static readonly StringName GetWorld2D = "get_world_2d";
        /// <summary>
        /// Cached name for the 'set_material' method.
        /// </summary>
        public static readonly StringName SetMaterial = "set_material";
        /// <summary>
        /// Cached name for the 'get_material' method.
        /// </summary>
        public static readonly StringName GetMaterial = "get_material";
        /// <summary>
        /// Cached name for the 'set_instance_shader_parameter' method.
        /// </summary>
        public static readonly StringName SetInstanceShaderParameter = "set_instance_shader_parameter";
        /// <summary>
        /// Cached name for the 'get_instance_shader_parameter' method.
        /// </summary>
        public static readonly StringName GetInstanceShaderParameter = "get_instance_shader_parameter";
        /// <summary>
        /// Cached name for the 'set_use_parent_material' method.
        /// </summary>
        public static readonly StringName SetUseParentMaterial = "set_use_parent_material";
        /// <summary>
        /// Cached name for the 'get_use_parent_material' method.
        /// </summary>
        public static readonly StringName GetUseParentMaterial = "get_use_parent_material";
        /// <summary>
        /// Cached name for the 'set_notify_local_transform' method.
        /// </summary>
        public static readonly StringName SetNotifyLocalTransform = "set_notify_local_transform";
        /// <summary>
        /// Cached name for the 'is_local_transform_notification_enabled' method.
        /// </summary>
        public static readonly StringName IsLocalTransformNotificationEnabled = "is_local_transform_notification_enabled";
        /// <summary>
        /// Cached name for the 'set_notify_transform' method.
        /// </summary>
        public static readonly StringName SetNotifyTransform = "set_notify_transform";
        /// <summary>
        /// Cached name for the 'is_transform_notification_enabled' method.
        /// </summary>
        public static readonly StringName IsTransformNotificationEnabled = "is_transform_notification_enabled";
        /// <summary>
        /// Cached name for the 'force_update_transform' method.
        /// </summary>
        public static readonly StringName ForceUpdateTransform = "force_update_transform";
        /// <summary>
        /// Cached name for the 'make_canvas_position_local' method.
        /// </summary>
        public static readonly StringName MakeCanvasPositionLocal = "make_canvas_position_local";
        /// <summary>
        /// Cached name for the 'make_input_local' method.
        /// </summary>
        public static readonly StringName MakeInputLocal = "make_input_local";
        /// <summary>
        /// Cached name for the 'set_visibility_layer' method.
        /// </summary>
        public static readonly StringName SetVisibilityLayer = "set_visibility_layer";
        /// <summary>
        /// Cached name for the 'get_visibility_layer' method.
        /// </summary>
        public static readonly StringName GetVisibilityLayer = "get_visibility_layer";
        /// <summary>
        /// Cached name for the 'set_visibility_layer_bit' method.
        /// </summary>
        public static readonly StringName SetVisibilityLayerBit = "set_visibility_layer_bit";
        /// <summary>
        /// Cached name for the 'get_visibility_layer_bit' method.
        /// </summary>
        public static readonly StringName GetVisibilityLayerBit = "get_visibility_layer_bit";
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
        /// <summary>
        /// Cached name for the 'set_clip_children_mode' method.
        /// </summary>
        public static readonly StringName SetClipChildrenMode = "set_clip_children_mode";
        /// <summary>
        /// Cached name for the 'get_clip_children_mode' method.
        /// </summary>
        public static readonly StringName GetClipChildrenMode = "get_clip_children_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'draw' signal.
        /// </summary>
        public static readonly StringName Draw = "draw";
        /// <summary>
        /// Cached name for the 'visibility_changed' signal.
        /// </summary>
        public static readonly StringName VisibilityChanged = "visibility_changed";
        /// <summary>
        /// Cached name for the 'hidden' signal.
        /// </summary>
        public static readonly StringName Hidden = "hidden";
        /// <summary>
        /// Cached name for the 'item_rect_changed' signal.
        /// </summary>
        public static readonly StringName ItemRectChanged = "item_rect_changed";
    }
}
