namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.StyleBox"/> is an abstract base class for drawing stylized boxes for UI elements. It is used for panels, buttons, <see cref="Godot.LineEdit"/> backgrounds, <see cref="Godot.Tree"/> backgrounds, etc. and also for testing a transparency mask for pointer signals. If mask test fails on a <see cref="Godot.StyleBox"/> assigned as mask to a control, clicks and motion signals will go through it to the one below.</para>
/// <para><b>Note:</b> For control nodes that have <i>Theme Properties</i>, the <c>focus</c> <see cref="Godot.StyleBox"/> is displayed over the <c>normal</c>, <c>hover</c> or <c>pressed</c> <see cref="Godot.StyleBox"/>. This makes the <c>focus</c> <see cref="Godot.StyleBox"/> more reusable across different nodes.</para>
/// </summary>
public partial class StyleBox : Resource
{
    /// <summary>
    /// <para>The left margin for the contents of this style box. Increasing this value reduces the space available to the contents from the left.</para>
    /// <para>Refer to <see cref="Godot.StyleBox.ContentMarginBottom"/> for extra considerations.</para>
    /// </summary>
    public float ContentMarginLeft
    {
        get
        {
            return GetContentMargin((Side)(0));
        }
        set
        {
            SetContentMargin((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>The top margin for the contents of this style box. Increasing this value reduces the space available to the contents from the top.</para>
    /// <para>Refer to <see cref="Godot.StyleBox.ContentMarginBottom"/> for extra considerations.</para>
    /// </summary>
    public float ContentMarginTop
    {
        get
        {
            return GetContentMargin((Side)(1));
        }
        set
        {
            SetContentMargin((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>The right margin for the contents of this style box. Increasing this value reduces the space available to the contents from the right.</para>
    /// <para>Refer to <see cref="Godot.StyleBox.ContentMarginBottom"/> for extra considerations.</para>
    /// </summary>
    public float ContentMarginRight
    {
        get
        {
            return GetContentMargin((Side)(2));
        }
        set
        {
            SetContentMargin((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>The bottom margin for the contents of this style box. Increasing this value reduces the space available to the contents from the bottom.</para>
    /// <para>If this value is negative, it is ignored and a child-specific margin is used instead. For example, for <see cref="Godot.StyleBoxFlat"/>, the border thickness (if any) is used instead.</para>
    /// <para>It is up to the code using this style box to decide what these contents are: for example, a <see cref="Godot.Button"/> respects this content margin for the textual contents of the button.</para>
    /// <para><see cref="Godot.StyleBox.GetMargin(Side)"/> should be used to fetch this value as consumer instead of reading these properties directly. This is because it correctly respects negative values and the fallback mentioned above.</para>
    /// </summary>
    public float ContentMarginBottom
    {
        get
        {
            return GetContentMargin((Side)(3));
        }
        set
        {
            SetContentMargin((Side)(3), value);
        }
    }

    private static readonly System.Type CachedType = typeof(StyleBox);

    private static readonly StringName NativeName = "StyleBox";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public StyleBox() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal StyleBox(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StyleBox(bool memoryOwn) : base(memoryOwn) { }

    public virtual unsafe void _Draw(Rid toCanvasItem, Rect2 rect)
    {
    }

    public virtual unsafe Rect2 _GetDrawRect(Rect2 rect)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to be implemented by the user. Returns a custom minimum size that the stylebox must respect when drawing. By default <see cref="Godot.StyleBox.GetMinimumSize()"/> only takes content margins into account. This method can be overridden to add another size restriction. A combination of the default behavior and the output of this method will be used, to account for both sizes.</para>
    /// </summary>
    public virtual Vector2 _GetMinimumSize()
    {
        return default;
    }

    public virtual unsafe bool _TestMask(Vector2 point, Rect2 rect)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinimumSize, 3341600327ul);

    /// <summary>
    /// <para>Returns the minimum size that this stylebox can be shrunk to.</para>
    /// </summary>
    public Vector2 GetMinimumSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContentMargin, 4290182280ul);

    /// <summary>
    /// <para>Sets the default value of the specified <see cref="Godot.Side"/> to <paramref name="offset"/> pixels.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetContentMargin(Side margin, float offset)
    {
        NativeCalls.godot_icall_2_69(MethodBind1, GodotObject.GetPtr(this), (int)margin, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContentMarginAll, 373806689ul);

    /// <summary>
    /// <para>Sets the default margin to <paramref name="offset"/> pixels for all sides.</para>
    /// </summary>
    public void SetContentMarginAll(float offset)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContentMargin, 2869120046ul);

    /// <summary>
    /// <para>Returns the default margin of the specified <see cref="Godot.Side"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetContentMargin(Side margin)
    {
        return NativeCalls.godot_icall_1_72(MethodBind3, GodotObject.GetPtr(this), (int)margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMargin, 2869120046ul);

    /// <summary>
    /// <para>Returns the content margin offset for the specified <see cref="Godot.Side"/>.</para>
    /// <para>Positive values reduce size inwards, unlike <see cref="Godot.Control"/>'s margin values.</para>
    /// </summary>
    public float GetMargin(Side margin)
    {
        return NativeCalls.godot_icall_1_72(MethodBind4, GodotObject.GetPtr(this), (int)margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 3341600327ul);

    /// <summary>
    /// <para>Returns the "offset" of a stylebox. This helper function returns a value equivalent to <c>Vector2(style.get_margin(MARGIN_LEFT), style.get_margin(MARGIN_TOP))</c>.</para>
    /// </summary>
    public Vector2 GetOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Draw, 2275962004ul);

    /// <summary>
    /// <para>Draws this stylebox using a canvas item identified by the given <see cref="Godot.Rid"/>.</para>
    /// <para>The <see cref="Godot.Rid"/> value can either be the result of <see cref="Godot.CanvasItem.GetCanvasItem()"/> called on an existing <see cref="Godot.CanvasItem"/>-derived node, or directly from creating a canvas item in the <see cref="Godot.RenderingServer"/> with <see cref="Godot.RenderingServer.CanvasItemCreate()"/>.</para>
    /// </summary>
    public unsafe void Draw(Rid canvasItem, Rect2 rect)
    {
        NativeCalls.godot_icall_2_428(MethodBind6, GodotObject.GetPtr(this), canvasItem, &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentItemDrawn, 3213695180ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.CanvasItem"/> that handles its <see cref="Godot.CanvasItem.NotificationDraw"/> or <see cref="Godot.CanvasItem._Draw()"/> callback at this moment.</para>
    /// </summary>
    public CanvasItem GetCurrentItemDrawn()
    {
        return (CanvasItem)NativeCalls.godot_icall_0_53(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TestMask, 3735564539ul);

    /// <summary>
    /// <para>Test a position in a rectangle, return whether it passes the mask test.</para>
    /// </summary>
    public unsafe bool TestMask(Vector2 point, Rect2 rect)
    {
        return NativeCalls.godot_icall_2_1291(MethodBind8, GodotObject.GetPtr(this), &point, &rect).ToBool();
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__draw = "_Draw";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_draw_rect = "_GetDrawRect";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_minimum_size = "_GetMinimumSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__test_mask = "_TestMask";

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
        if ((method == MethodProxyName__draw || method == MethodName._Draw) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__draw.NativeValue))
        {
            _Draw(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rect2>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_draw_rect || method == MethodName._GetDrawRect) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_draw_rect.NativeValue))
        {
            var callRet = _GetDrawRect(VariantUtils.ConvertTo<Rect2>(args[0]));
            ret = VariantUtils.CreateFrom<Rect2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_minimum_size || method == MethodName._GetMinimumSize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_minimum_size.NativeValue))
        {
            var callRet = _GetMinimumSize();
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__test_mask || method == MethodName._TestMask) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__test_mask.NativeValue))
        {
            var callRet = _TestMask(VariantUtils.ConvertTo<Vector2>(args[0]), VariantUtils.ConvertTo<Rect2>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName._GetDrawRect)
        {
            if (HasGodotClassMethod(MethodProxyName__get_draw_rect.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetMinimumSize)
        {
            if (HasGodotClassMethod(MethodProxyName__get_minimum_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._TestMask)
        {
            if (HasGodotClassMethod(MethodProxyName__test_mask.NativeValue.DangerousSelfRef))
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
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'content_margin_left' property.
        /// </summary>
        public static readonly StringName ContentMarginLeft = "content_margin_left";
        /// <summary>
        /// Cached name for the 'content_margin_top' property.
        /// </summary>
        public static readonly StringName ContentMarginTop = "content_margin_top";
        /// <summary>
        /// Cached name for the 'content_margin_right' property.
        /// </summary>
        public static readonly StringName ContentMarginRight = "content_margin_right";
        /// <summary>
        /// Cached name for the 'content_margin_bottom' property.
        /// </summary>
        public static readonly StringName ContentMarginBottom = "content_margin_bottom";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_draw' method.
        /// </summary>
        public static readonly StringName _Draw = "_draw";
        /// <summary>
        /// Cached name for the '_get_draw_rect' method.
        /// </summary>
        public static readonly StringName _GetDrawRect = "_get_draw_rect";
        /// <summary>
        /// Cached name for the '_get_minimum_size' method.
        /// </summary>
        public static readonly StringName _GetMinimumSize = "_get_minimum_size";
        /// <summary>
        /// Cached name for the '_test_mask' method.
        /// </summary>
        public static readonly StringName _TestMask = "_test_mask";
        /// <summary>
        /// Cached name for the 'get_minimum_size' method.
        /// </summary>
        public static readonly StringName GetMinimumSize = "get_minimum_size";
        /// <summary>
        /// Cached name for the 'set_content_margin' method.
        /// </summary>
        public static readonly StringName SetContentMargin = "set_content_margin";
        /// <summary>
        /// Cached name for the 'set_content_margin_all' method.
        /// </summary>
        public static readonly StringName SetContentMarginAll = "set_content_margin_all";
        /// <summary>
        /// Cached name for the 'get_content_margin' method.
        /// </summary>
        public static readonly StringName GetContentMargin = "get_content_margin";
        /// <summary>
        /// Cached name for the 'get_margin' method.
        /// </summary>
        public static readonly StringName GetMargin = "get_margin";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'draw' method.
        /// </summary>
        public static readonly StringName Draw = "draw";
        /// <summary>
        /// Cached name for the 'get_current_item_drawn' method.
        /// </summary>
        public static readonly StringName GetCurrentItemDrawn = "get_current_item_drawn";
        /// <summary>
        /// Cached name for the 'test_mask' method.
        /// </summary>
        public static readonly StringName TestMask = "test_mask";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
