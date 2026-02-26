namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><i>Root motion</i> refers to an animation technique where a mesh's skeleton is used to give impulse to a character. When working with 3D animations, a popular technique is for animators to use the root skeleton bone to give motion to the rest of the skeleton. This allows animating characters in a way where steps actually match the floor below. It also allows precise interaction with objects during cinematics. See also <see cref="Godot.AnimationMixer"/>.</para>
/// <para><b>Note:</b> <see cref="Godot.RootMotionView"/> is only visible in the editor. It will be hidden automatically in the running project.</para>
/// </summary>
public partial class RootMotionView : VisualInstance3D
{
    /// <summary>
    /// <para>Path to an <see cref="Godot.AnimationMixer"/> node to use as a basis for root motion.</para>
    /// </summary>
    public NodePath AnimationPath
    {
        get
        {
            return GetAnimationPath();
        }
        set
        {
            SetAnimationPath(value);
        }
    }

    /// <summary>
    /// <para>The grid's color.</para>
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
    /// <para>The grid's cell size in 3D units.</para>
    /// </summary>
    public float CellSize
    {
        get
        {
            return GetCellSize();
        }
        set
        {
            SetCellSize(value);
        }
    }

    /// <summary>
    /// <para>The grid's radius in 3D units. The grid's opacity will fade gradually as the distance from the origin increases until this <see cref="Godot.RootMotionView.Radius"/> is reached.</para>
    /// </summary>
    public float Radius
    {
        get
        {
            return GetRadius();
        }
        set
        {
            SetRadius(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the grid's points will all be on the same Y coordinate (<i>local</i> Y = 0). If <see langword="false"/>, the points' original Y coordinate is preserved.</para>
    /// </summary>
    public bool ZeroY
    {
        get
        {
            return GetZeroY();
        }
        set
        {
            SetZeroY(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RootMotionView);

    private static readonly StringName NativeName = "RootMotionView";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RootMotionView() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal RootMotionView(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RootMotionView(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnimationPath, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAnimationPath(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind0, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimationPath, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetAnimationPath()
    {
        return NativeCalls.godot_icall_0_124(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind2, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCellSize(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCellSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadius(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZeroY, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetZeroY(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetZeroY, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetZeroY()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : VisualInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'animation_path' property.
        /// </summary>
        public static readonly StringName AnimationPath = "animation_path";
        /// <summary>
        /// Cached name for the 'color' property.
        /// </summary>
        public static readonly StringName Color = "color";
        /// <summary>
        /// Cached name for the 'cell_size' property.
        /// </summary>
        public static readonly StringName CellSize = "cell_size";
        /// <summary>
        /// Cached name for the 'radius' property.
        /// </summary>
        public static readonly StringName Radius = "radius";
        /// <summary>
        /// Cached name for the 'zero_y' property.
        /// </summary>
        public static readonly StringName ZeroY = "zero_y";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_animation_path' method.
        /// </summary>
        public static readonly StringName SetAnimationPath = "set_animation_path";
        /// <summary>
        /// Cached name for the 'get_animation_path' method.
        /// </summary>
        public static readonly StringName GetAnimationPath = "get_animation_path";
        /// <summary>
        /// Cached name for the 'set_color' method.
        /// </summary>
        public static readonly StringName SetColor = "set_color";
        /// <summary>
        /// Cached name for the 'get_color' method.
        /// </summary>
        public static readonly StringName GetColor = "get_color";
        /// <summary>
        /// Cached name for the 'set_cell_size' method.
        /// </summary>
        public static readonly StringName SetCellSize = "set_cell_size";
        /// <summary>
        /// Cached name for the 'get_cell_size' method.
        /// </summary>
        public static readonly StringName GetCellSize = "get_cell_size";
        /// <summary>
        /// Cached name for the 'set_radius' method.
        /// </summary>
        public static readonly StringName SetRadius = "set_radius";
        /// <summary>
        /// Cached name for the 'get_radius' method.
        /// </summary>
        public static readonly StringName GetRadius = "get_radius";
        /// <summary>
        /// Cached name for the 'set_zero_y' method.
        /// </summary>
        public static readonly StringName SetZeroY = "set_zero_y";
        /// <summary>
        /// Cached name for the 'get_zero_y' method.
        /// </summary>
        public static readonly StringName GetZeroY = "get_zero_y";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
    }
}
