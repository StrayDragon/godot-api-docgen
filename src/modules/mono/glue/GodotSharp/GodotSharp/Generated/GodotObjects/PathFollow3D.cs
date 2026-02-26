namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node takes its parent <see cref="Godot.Path3D"/>, and returns the coordinates of a point within it, given a distance from the first vertex.</para>
/// <para>It is useful for making other nodes follow a path, without coding the movement pattern. For that, the nodes must be children of this node. The descendant nodes will then move accordingly when setting the <see cref="Godot.PathFollow3D.Progress"/> in this node.</para>
/// </summary>
public partial class PathFollow3D : Node3D
{
    public enum RotationModeEnum : long
    {
        /// <summary>
        /// <para>Forbids the PathFollow3D to rotate.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Allows the PathFollow3D to rotate in the Y axis only.</para>
        /// </summary>
        Y = 1,
        /// <summary>
        /// <para>Allows the PathFollow3D to rotate in both the X, and Y axes.</para>
        /// </summary>
        Xy = 2,
        /// <summary>
        /// <para>Allows the PathFollow3D to rotate in any axis.</para>
        /// </summary>
        Xyz = 3,
        /// <summary>
        /// <para>Uses the up vector information in a <see cref="Godot.Curve3D"/> to enforce orientation. This rotation mode requires the <see cref="Godot.Path3D"/>'s <see cref="Godot.Curve3D.UpVectorEnabled"/> property to be set to <see langword="true"/>.</para>
        /// </summary>
        Oriented = 4
    }

    /// <summary>
    /// <para>The distance from the first vertex, measured in 3D units along the path. Changing this value sets this node's position to a point within the path.</para>
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
    /// <para>The distance from the first vertex, considering 0.0 as the first vertex and 1.0 as the last. This is just another way of expressing the progress within the path, as the progress supplied is multiplied internally by the path's length.</para>
    /// <para>It can be set or get only if the <see cref="Godot.PathFollow3D"/> is the child of a <see cref="Godot.Path3D"/> which is part of the scene tree, and that this <see cref="Godot.Path3D"/> has a <see cref="Godot.Curve3D"/> with a non-zero length. Otherwise, trying to set this field will print an error, and getting this field will return <c>0.0</c>.</para>
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
    /// <para>Allows or forbids rotation on one or more axes, depending on the <see cref="Godot.PathFollow3D.RotationModeEnum"/> constants being used.</para>
    /// </summary>
    public PathFollow3D.RotationModeEnum RotationMode
    {
        get
        {
            return GetRotationMode();
        }
        set
        {
            SetRotationMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the node moves on the travel path with orienting the +Z axis as forward. See also <c>Vector3.FORWARD</c> and <c>Vector3.MODEL_FRONT</c>.</para>
    /// </summary>
    public bool UseModelFront
    {
        get
        {
            return IsUsingModelFront();
        }
        set
        {
            SetUseModelFront(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the position between two cached points is interpolated cubically, and linearly otherwise.</para>
    /// <para>The points along the <see cref="Godot.Curve3D"/> of the <see cref="Godot.Path3D"/> are precomputed before use, for faster calculations. The point at the requested offset is then calculated interpolating between two adjacent cached points. This may present a problem if the curve makes sharp turns, as the cached points may not follow the curve closely enough.</para>
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

    /// <summary>
    /// <para>If <see langword="true"/>, the tilt property of <see cref="Godot.Curve3D"/> takes effect.</para>
    /// </summary>
    public bool TiltEnabled
    {
        get
        {
            return IsTiltEnabled();
        }
        set
        {
            SetTiltEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PathFollow3D);

    private static readonly StringName NativeName = "PathFollow3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PathFollow3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PathFollow3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PathFollow3D(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationMode, 1640311967ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotationMode(PathFollow3D.RotationModeEnum rotationMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)rotationMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotationMode, 3814010545ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public PathFollow3D.RotationModeEnum GetRotationMode()
    {
        return (PathFollow3D.RotationModeEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
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
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseModelFront, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseModelFront(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingModelFront, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingModelFront()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoop, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoop(bool loop)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), loop.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasLoop, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasLoop()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTiltEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTiltEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTiltEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsTiltEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CorrectPosture, 2686588690ul);

    /// <summary>
    /// <para>Correct the <paramref name="transform"/>. <paramref name="rotationMode"/> implicitly specifies how posture (forward, up and sideway direction) is calculated.</para>
    /// </summary>
    public static unsafe Transform3D CorrectPosture(Transform3D transform, PathFollow3D.RotationModeEnum rotationMode)
    {
        return NativeCalls.godot_icall_2_974(MethodBind18, &transform, (int)rotationMode);
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
    public new class PropertyName : Node3D.PropertyName
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
        /// Cached name for the 'rotation_mode' property.
        /// </summary>
        public static readonly StringName RotationMode = "rotation_mode";
        /// <summary>
        /// Cached name for the 'use_model_front' property.
        /// </summary>
        public static readonly StringName UseModelFront = "use_model_front";
        /// <summary>
        /// Cached name for the 'cubic_interp' property.
        /// </summary>
        public static readonly StringName CubicInterp = "cubic_interp";
        /// <summary>
        /// Cached name for the 'loop' property.
        /// </summary>
        public static readonly StringName Loop = "loop";
        /// <summary>
        /// Cached name for the 'tilt_enabled' property.
        /// </summary>
        public static readonly StringName TiltEnabled = "tilt_enabled";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
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
        /// Cached name for the 'set_rotation_mode' method.
        /// </summary>
        public static readonly StringName SetRotationMode = "set_rotation_mode";
        /// <summary>
        /// Cached name for the 'get_rotation_mode' method.
        /// </summary>
        public static readonly StringName GetRotationMode = "get_rotation_mode";
        /// <summary>
        /// Cached name for the 'set_cubic_interpolation' method.
        /// </summary>
        public static readonly StringName SetCubicInterpolation = "set_cubic_interpolation";
        /// <summary>
        /// Cached name for the 'get_cubic_interpolation' method.
        /// </summary>
        public static readonly StringName GetCubicInterpolation = "get_cubic_interpolation";
        /// <summary>
        /// Cached name for the 'set_use_model_front' method.
        /// </summary>
        public static readonly StringName SetUseModelFront = "set_use_model_front";
        /// <summary>
        /// Cached name for the 'is_using_model_front' method.
        /// </summary>
        public static readonly StringName IsUsingModelFront = "is_using_model_front";
        /// <summary>
        /// Cached name for the 'set_loop' method.
        /// </summary>
        public static readonly StringName SetLoop = "set_loop";
        /// <summary>
        /// Cached name for the 'has_loop' method.
        /// </summary>
        public static readonly StringName HasLoop = "has_loop";
        /// <summary>
        /// Cached name for the 'set_tilt_enabled' method.
        /// </summary>
        public static readonly StringName SetTiltEnabled = "set_tilt_enabled";
        /// <summary>
        /// Cached name for the 'is_tilt_enabled' method.
        /// </summary>
        public static readonly StringName IsTiltEnabled = "is_tilt_enabled";
        /// <summary>
        /// Cached name for the 'correct_posture' method.
        /// </summary>
        public static readonly StringName CorrectPosture = "correct_posture";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
