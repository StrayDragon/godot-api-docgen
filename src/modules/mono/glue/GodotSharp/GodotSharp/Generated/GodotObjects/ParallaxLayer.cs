namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A ParallaxLayer must be the child of a <see cref="Godot.ParallaxBackground"/> node. Each ParallaxLayer can be set to move at different speeds relative to the camera movement or the <see cref="Godot.ParallaxBackground.ScrollOffset"/> value.</para>
/// <para>This node's children will be affected by its scroll offset.</para>
/// <para><b>Note:</b> Any changes to this node's position and scale made after it enters the scene will be ignored.</para>
/// </summary>
[Obsolete("Use the 'Parallax2D' node instead.")]
public partial class ParallaxLayer : Node2D
{
    /// <summary>
    /// <para>Multiplies the ParallaxLayer's motion. If an axis is set to <c>0</c>, it will not scroll.</para>
    /// </summary>
    public Vector2 MotionScale
    {
        get
        {
            return GetMotionScale();
        }
        set
        {
            SetMotionScale(value);
        }
    }

    /// <summary>
    /// <para>The ParallaxLayer's offset relative to the parent ParallaxBackground's <see cref="Godot.ParallaxBackground.ScrollOffset"/>.</para>
    /// </summary>
    public Vector2 MotionOffset
    {
        get
        {
            return GetMotionOffset();
        }
        set
        {
            SetMotionOffset(value);
        }
    }

    /// <summary>
    /// <para>The interval, in pixels, at which the <see cref="Godot.ParallaxLayer"/> is drawn repeatedly. Useful for creating an infinitely scrolling background. If an axis is set to <c>0</c>, the <see cref="Godot.ParallaxLayer"/> will be drawn only once along that direction.</para>
    /// <para><b>Note:</b> If you want the repetition to pixel-perfect match a <see cref="Godot.Texture2D"/> displayed by a child node, you should account for any scale applied to the texture when defining this interval. For example, if you use a child <see cref="Godot.Sprite2D"/> scaled to <c>0.5</c> to display a 600x600 texture, and want this sprite to be repeated continuously horizontally, you should set the mirroring to <c>Vector2(300, 0)</c>.</para>
    /// <para><b>Note:</b> If the length of the viewport axis is bigger than twice the repeated axis size, it will not repeat infinitely, as the parallax layer only draws 2 instances of the layer at any given time. The visibility window is calculated from the parent <see cref="Godot.ParallaxBackground"/>'s position, not the layer's own position. So, if you use mirroring, <b>do not</b> change the <see cref="Godot.ParallaxLayer"/> position relative to its parent. Instead, if you need to adjust the background's position, set the <see cref="Godot.CanvasLayer.Offset"/> property in the parent <see cref="Godot.ParallaxBackground"/>.</para>
    /// <para><b>Note:</b> Despite the name, the layer will not be mirrored, it will only be repeated.</para>
    /// </summary>
    public Vector2 MotionMirroring
    {
        get
        {
            return GetMirroring();
        }
        set
        {
            SetMirroring(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ParallaxLayer);

    private static readonly StringName NativeName = "ParallaxLayer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ParallaxLayer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ParallaxLayer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ParallaxLayer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMotionScale, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMotionScale(Vector2 scale)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMotionScale, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetMotionScale()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMotionOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMotionOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind2, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMotionOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetMotionOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMirroring, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMirroring(Vector2 mirror)
    {
        NativeCalls.godot_icall_1_36(MethodBind4, GodotObject.GetPtr(this), &mirror);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMirroring, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetMirroring()
    {
        return NativeCalls.godot_icall_0_37(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'motion_scale' property.
        /// </summary>
        public static readonly StringName MotionScale = "motion_scale";
        /// <summary>
        /// Cached name for the 'motion_offset' property.
        /// </summary>
        public static readonly StringName MotionOffset = "motion_offset";
        /// <summary>
        /// Cached name for the 'motion_mirroring' property.
        /// </summary>
        public static readonly StringName MotionMirroring = "motion_mirroring";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_motion_scale' method.
        /// </summary>
        public static readonly StringName SetMotionScale = "set_motion_scale";
        /// <summary>
        /// Cached name for the 'get_motion_scale' method.
        /// </summary>
        public static readonly StringName GetMotionScale = "get_motion_scale";
        /// <summary>
        /// Cached name for the 'set_motion_offset' method.
        /// </summary>
        public static readonly StringName SetMotionOffset = "set_motion_offset";
        /// <summary>
        /// Cached name for the 'get_motion_offset' method.
        /// </summary>
        public static readonly StringName GetMotionOffset = "get_motion_offset";
        /// <summary>
        /// Cached name for the 'set_mirroring' method.
        /// </summary>
        public static readonly StringName SetMirroring = "set_mirroring";
        /// <summary>
        /// Cached name for the 'get_mirroring' method.
        /// </summary>
        public static readonly StringName GetMirroring = "get_mirroring";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
