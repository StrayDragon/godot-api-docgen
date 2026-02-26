namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A ParallaxBackground uses one or more <see cref="Godot.ParallaxLayer"/> child nodes to create a parallax effect. Each <see cref="Godot.ParallaxLayer"/> can move at a different speed using <see cref="Godot.ParallaxLayer.MotionOffset"/>. This creates an illusion of depth in a 2D game. If not used with a <see cref="Godot.Camera2D"/>, you must manually calculate the <see cref="Godot.ParallaxBackground.ScrollOffset"/>.</para>
/// <para><b>Note:</b> Each <see cref="Godot.ParallaxBackground"/> is drawn on one specific <see cref="Godot.Viewport"/> and cannot be shared between multiple <see cref="Godot.Viewport"/>s, see <see cref="Godot.CanvasLayer.CustomViewport"/>. When using multiple <see cref="Godot.Viewport"/>s, for example in a split-screen game, you need create an individual <see cref="Godot.ParallaxBackground"/> for each <see cref="Godot.Viewport"/> you want it to be drawn on.</para>
/// </summary>
[Obsolete("Use the 'Parallax2D' node instead.")]
public partial class ParallaxBackground : CanvasLayer
{
    /// <summary>
    /// <para>The ParallaxBackground's scroll value. Calculated automatically when using a <see cref="Godot.Camera2D"/>, but can be used to manually manage scrolling when no camera is present.</para>
    /// </summary>
    public Vector2 ScrollOffset
    {
        get
        {
            return GetScrollOffset();
        }
        set
        {
            SetScrollOffset(value);
        }
    }

    /// <summary>
    /// <para>The base position offset for all <see cref="Godot.ParallaxLayer"/> children.</para>
    /// </summary>
    public Vector2 ScrollBaseOffset
    {
        get
        {
            return GetScrollBaseOffset();
        }
        set
        {
            SetScrollBaseOffset(value);
        }
    }

    /// <summary>
    /// <para>The base motion scale for all <see cref="Godot.ParallaxLayer"/> children.</para>
    /// </summary>
    public Vector2 ScrollBaseScale
    {
        get
        {
            return GetScrollBaseScale();
        }
        set
        {
            SetScrollBaseScale(value);
        }
    }

    /// <summary>
    /// <para>Top-left limits for scrolling to begin. If the camera is outside of this limit, the background will stop scrolling. Must be lower than <see cref="Godot.ParallaxBackground.ScrollLimitEnd"/> to work.</para>
    /// </summary>
    public Vector2 ScrollLimitBegin
    {
        get
        {
            return GetLimitBegin();
        }
        set
        {
            SetLimitBegin(value);
        }
    }

    /// <summary>
    /// <para>Bottom-right limits for scrolling to end. If the camera is outside of this limit, the background will stop scrolling. Must be higher than <see cref="Godot.ParallaxBackground.ScrollLimitBegin"/> to work.</para>
    /// </summary>
    public Vector2 ScrollLimitEnd
    {
        get
        {
            return GetLimitEnd();
        }
        set
        {
            SetLimitEnd(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, elements in <see cref="Godot.ParallaxLayer"/> child aren't affected by the zoom level of the camera.</para>
    /// </summary>
    public bool ScrollIgnoreCameraZoom
    {
        get
        {
            return IsIgnoreCameraZoom();
        }
        set
        {
            SetIgnoreCameraZoom(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ParallaxBackground);

    private static readonly StringName NativeName = "ParallaxBackground";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ParallaxBackground() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ParallaxBackground(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ParallaxBackground(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScrollOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScrollOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollBaseOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScrollBaseOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind2, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollBaseOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScrollBaseOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollBaseScale, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScrollBaseScale(Vector2 scale)
    {
        NativeCalls.godot_icall_1_36(MethodBind4, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollBaseScale, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScrollBaseScale()
    {
        return NativeCalls.godot_icall_0_37(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLimitBegin, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetLimitBegin(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind6, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLimitBegin, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetLimitBegin()
    {
        return NativeCalls.godot_icall_0_37(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLimitEnd, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetLimitEnd(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind8, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLimitEnd, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetLimitEnd()
    {
        return NativeCalls.godot_icall_0_37(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgnoreCameraZoom, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgnoreCameraZoom(bool ignore)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), ignore.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsIgnoreCameraZoom, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsIgnoreCameraZoom()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : CanvasLayer.PropertyName
    {
        /// <summary>
        /// Cached name for the 'scroll_offset' property.
        /// </summary>
        public static readonly StringName ScrollOffset = "scroll_offset";
        /// <summary>
        /// Cached name for the 'scroll_base_offset' property.
        /// </summary>
        public static readonly StringName ScrollBaseOffset = "scroll_base_offset";
        /// <summary>
        /// Cached name for the 'scroll_base_scale' property.
        /// </summary>
        public static readonly StringName ScrollBaseScale = "scroll_base_scale";
        /// <summary>
        /// Cached name for the 'scroll_limit_begin' property.
        /// </summary>
        public static readonly StringName ScrollLimitBegin = "scroll_limit_begin";
        /// <summary>
        /// Cached name for the 'scroll_limit_end' property.
        /// </summary>
        public static readonly StringName ScrollLimitEnd = "scroll_limit_end";
        /// <summary>
        /// Cached name for the 'scroll_ignore_camera_zoom' property.
        /// </summary>
        public static readonly StringName ScrollIgnoreCameraZoom = "scroll_ignore_camera_zoom";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CanvasLayer.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_scroll_offset' method.
        /// </summary>
        public static readonly StringName SetScrollOffset = "set_scroll_offset";
        /// <summary>
        /// Cached name for the 'get_scroll_offset' method.
        /// </summary>
        public static readonly StringName GetScrollOffset = "get_scroll_offset";
        /// <summary>
        /// Cached name for the 'set_scroll_base_offset' method.
        /// </summary>
        public static readonly StringName SetScrollBaseOffset = "set_scroll_base_offset";
        /// <summary>
        /// Cached name for the 'get_scroll_base_offset' method.
        /// </summary>
        public static readonly StringName GetScrollBaseOffset = "get_scroll_base_offset";
        /// <summary>
        /// Cached name for the 'set_scroll_base_scale' method.
        /// </summary>
        public static readonly StringName SetScrollBaseScale = "set_scroll_base_scale";
        /// <summary>
        /// Cached name for the 'get_scroll_base_scale' method.
        /// </summary>
        public static readonly StringName GetScrollBaseScale = "get_scroll_base_scale";
        /// <summary>
        /// Cached name for the 'set_limit_begin' method.
        /// </summary>
        public static readonly StringName SetLimitBegin = "set_limit_begin";
        /// <summary>
        /// Cached name for the 'get_limit_begin' method.
        /// </summary>
        public static readonly StringName GetLimitBegin = "get_limit_begin";
        /// <summary>
        /// Cached name for the 'set_limit_end' method.
        /// </summary>
        public static readonly StringName SetLimitEnd = "set_limit_end";
        /// <summary>
        /// Cached name for the 'get_limit_end' method.
        /// </summary>
        public static readonly StringName GetLimitEnd = "get_limit_end";
        /// <summary>
        /// Cached name for the 'set_ignore_camera_zoom' method.
        /// </summary>
        public static readonly StringName SetIgnoreCameraZoom = "set_ignore_camera_zoom";
        /// <summary>
        /// Cached name for the 'is_ignore_camera_zoom' method.
        /// </summary>
        public static readonly StringName IsIgnoreCameraZoom = "is_ignore_camera_zoom";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CanvasLayer.SignalName
    {
    }
}
