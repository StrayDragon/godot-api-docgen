namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node takes its parent <see cref="Godot.Path2D"/>, and returns the coordinates of a point within it, given a distance from the first vertex.</para>
/// <para>It is useful for making other nodes follow a path, without coding the movement pattern. For that, the nodes must be children of this node. The descendant nodes will then move accordingly when setting the <see cref="Godot.PathFollow2D.Progress"/> in this node.</para>
/// </summary>
public partial class PathFollow2D : Node2D
{
    /// <summary>
    /// <para>The distance along the path, in pixels. Changing this value sets this node's position to a point within the path.</para>
    /// </summary>
    public float Progress
    {
        get
        {
            return GetProgress();
        }
        set
        {
            SetProgress(value);
        }
    }

    /// <summary>
    /// <para>The distance along the path as a number in the range 0.0 (for the first vertex) to 1.0 (for the last). This is just another way of expressing the progress within the path, as the offset supplied is multiplied internally by the path's length.</para>
    /// <para>It can be set or get only if the <see cref="Godot.PathFollow2D"/> is the child of a <see cref="Godot.Path2D"/> which is part of the scene tree, and that this <see cref="Godot.Path2D"/> has a <see cref="Godot.Curve2D"/> with a non-zero length. Otherwise, trying to set this field will print an error, and getting this field will return <c>0.0</c>.</para>
    /// </summary>
    public float ProgressRatio
    {
        get
        {
            return GetProgressRatio();
        }
        set
        {
            SetProgressRatio(value);
        }
    }

    /// <summary>
    /// <para>The node's offset along the curve.</para>
    /// </summary>
    public float HOffset
    {
        get
        {
            return GetHOffset();
        }
        set
        {
            SetHOffset(value);
        }
    }

    /// <summary>
    /// <para>The node's offset perpendicular to the curve.</para>
    /// </summary>
    public float VOffset
    {
        get
        {
            return GetVOffset();
        }
        set
        {
            SetVOffset(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this node rotates to follow the path, with the +X direction facing forward on the path.</para>
    /// </summary>
    public bool Rotates
    {
        get
        {
            return IsRotating();
        }
        set
        {
            SetRotates(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the position between two cached points is interpolated cubically, and linearly otherwise.</para>
    /// <para>The points along the <see cref="Godot.Curve2D"/> of the <see cref="Godot.Path2D"/> are precomputed before use, for faster calculations. The point at the requested offset is then calculated interpolating between two adjacent cached points. This may present a problem if the curve makes sharp turns, as the cached points may not follow the curve closely enough.</para>
    /// <para>There are two answers to this problem: either increase the number of cached points and increase memory consumption, or make a cubic interpolation between two points at the cost of (slightly) slower calculations.</para>
    /// </summary>
    public bool CubicInterp
    {
        get
        {
            return GetCubicInterpolation();
        }
        set
        {
            SetCubicInterpolation(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, any offset outside the path's length will wrap around, instead of stopping at the ends. Use it for cyclic paths.</para>
    /// </summary>
    public bool Loop
    {
        get
        {
            return HasLoop();
        }
        set
        {
            SetLoop(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PathFollow2D);

    private static readonly StringName NativeName = "PathFollow2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PathFollow2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PathFollow2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PathFollow2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProgress, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProgress(float progress)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), progress);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProgress, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetProgress()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHOffset(float hOffset)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), hOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetHOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVOffset(float vOffset)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), vOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProgressRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProgressRatio(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProgressRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetProgressRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotates, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotates(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRotating, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRotating()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCubicInterpolation, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCubicInterpolation(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCubicInterpolation, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetCubicInterpolation()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoop, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoop(bool loop)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), loop.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasLoop, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasLoop()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'progress' property.
        /// </summary>
        public static readonly StringName Progress = "progress";
        /// <summary>
        /// Cached name for the 'progress_ratio' property.
        /// </summary>
        public static readonly StringName ProgressRatio = "progress_ratio";
        /// <summary>
        /// Cached name for the 'h_offset' property.
        /// </summary>
        public static readonly StringName HOffset = "h_offset";
        /// <summary>
        /// Cached name for the 'v_offset' property.
        /// </summary>
        public static readonly StringName VOffset = "v_offset";
        /// <summary>
        /// Cached name for the 'rotates' property.
        /// </summary>
        public static readonly StringName Rotates = "rotates";
        /// <summary>
        /// Cached name for the 'cubic_interp' property.
        /// </summary>
        public static readonly StringName CubicInterp = "cubic_interp";
        /// <summary>
        /// Cached name for the 'loop' property.
        /// </summary>
        public static readonly StringName Loop = "loop";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_progress' method.
        /// </summary>
        public static readonly StringName SetProgress = "set_progress";
        /// <summary>
        /// Cached name for the 'get_progress' method.
        /// </summary>
        public static readonly StringName GetProgress = "get_progress";
        /// <summary>
        /// Cached name for the 'set_h_offset' method.
        /// </summary>
        public static readonly StringName SetHOffset = "set_h_offset";
        /// <summary>
        /// Cached name for the 'get_h_offset' method.
        /// </summary>
        public static readonly StringName GetHOffset = "get_h_offset";
        /// <summary>
        /// Cached name for the 'set_v_offset' method.
        /// </summary>
        public static readonly StringName SetVOffset = "set_v_offset";
        /// <summary>
        /// Cached name for the 'get_v_offset' method.
        /// </summary>
        public static readonly StringName GetVOffset = "get_v_offset";
        /// <summary>
        /// Cached name for the 'set_progress_ratio' method.
        /// </summary>
        public static readonly StringName SetProgressRatio = "set_progress_ratio";
        /// <summary>
        /// Cached name for the 'get_progress_ratio' method.
        /// </summary>
        public static readonly StringName GetProgressRatio = "get_progress_ratio";
        /// <summary>
        /// Cached name for the 'set_rotates' method.
        /// </summary>
        public static readonly StringName SetRotates = "set_rotates";
        /// <summary>
        /// Cached name for the 'is_rotating' method.
        /// </summary>
        public static readonly StringName IsRotating = "is_rotating";
        /// <summary>
        /// Cached name for the 'set_cubic_interpolation' method.
        /// </summary>
        public static readonly StringName SetCubicInterpolation = "set_cubic_interpolation";
        /// <summary>
        /// Cached name for the 'get_cubic_interpolation' method.
        /// </summary>
        public static readonly StringName GetCubicInterpolation = "get_cubic_interpolation";
        /// <summary>
        /// Cached name for the 'set_loop' method.
        /// </summary>
        public static readonly StringName SetLoop = "set_loop";
        /// <summary>
        /// Cached name for the 'has_loop' method.
        /// </summary>
        public static readonly StringName HasLoop = "has_loop";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
