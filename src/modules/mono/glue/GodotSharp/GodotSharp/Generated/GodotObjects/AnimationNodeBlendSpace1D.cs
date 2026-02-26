namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A resource used by <see cref="Godot.AnimationNodeBlendTree"/>.</para>
/// <para><see cref="Godot.AnimationNodeBlendSpace1D"/> represents a virtual axis on which any type of <see cref="Godot.AnimationRootNode"/>s can be added using <see cref="Godot.AnimationNodeBlendSpace1D.AddBlendPoint(AnimationRootNode, float, int)"/>. Outputs the linear blend of the two <see cref="Godot.AnimationRootNode"/>s adjacent to the current value.</para>
/// <para>You can set the extents of the axis with <see cref="Godot.AnimationNodeBlendSpace1D.MinSpace"/> and <see cref="Godot.AnimationNodeBlendSpace1D.MaxSpace"/>.</para>
/// </summary>
public partial class AnimationNodeBlendSpace1D : AnimationRootNode
{
    public enum BlendModeEnum : long
    {
        /// <summary>
        /// <para>The interpolation between animations is linear.</para>
        /// </summary>
        Interpolated = 0,
        /// <summary>
        /// <para>The blend space plays the animation of the animation node which blending position is closest to. Useful for frame-by-frame 2D animations.</para>
        /// </summary>
        Discrete = 1,
        /// <summary>
        /// <para>Similar to <see cref="Godot.AnimationNodeBlendSpace1D.BlendModeEnum.Discrete"/>, but starts the new animation at the last animation's playback position.</para>
        /// </summary>
        DiscreteCarry = 2
    }

    /// <summary>
    /// <para>The blend space's axis's lower limit for the points' position. See <see cref="Godot.AnimationNodeBlendSpace1D.AddBlendPoint(AnimationRootNode, float, int)"/>.</para>
    /// </summary>
    public float MinSpace
    {
        get
        {
            return GetMinSpace();
        }
        set
        {
            SetMinSpace(value);
        }
    }

    /// <summary>
    /// <para>The blend space's axis's upper limit for the points' position. See <see cref="Godot.AnimationNodeBlendSpace1D.AddBlendPoint(AnimationRootNode, float, int)"/>.</para>
    /// </summary>
    public float MaxSpace
    {
        get
        {
            return GetMaxSpace();
        }
        set
        {
            SetMaxSpace(value);
        }
    }

    /// <summary>
    /// <para>Position increment to snap to when moving a point on the axis.</para>
    /// </summary>
    public float Snap
    {
        get
        {
            return GetSnap();
        }
        set
        {
            SetSnap(value);
        }
    }

    /// <summary>
    /// <para>Label of the virtual axis of the blend space.</para>
    /// </summary>
    public string ValueLabel
    {
        get
        {
            return GetValueLabel();
        }
        set
        {
            SetValueLabel(value);
        }
    }

    /// <summary>
    /// <para>Controls the interpolation between animations.</para>
    /// </summary>
    public AnimationNodeBlendSpace1D.BlendModeEnum BlendMode
    {
        get
        {
            return GetBlendMode();
        }
        set
        {
            SetBlendMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, the blended animations' frame are stopped when the blend value is <c>0</c>.</para>
    /// <para>If <see langword="true"/>, forcing the blended animations to advance frame.</para>
    /// </summary>
    public bool Sync
    {
        get
        {
            return IsUsingSync();
        }
        set
        {
            SetUseSync(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationNodeBlendSpace1D);

    private static readonly StringName NativeName = "AnimationNodeBlendSpace1D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeBlendSpace1D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeBlendSpace1D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeBlendSpace1D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddBlendPoint, 285050433ul);

    /// <summary>
    /// <para>Adds a new point that represents a <paramref name="node"/> on the virtual axis at a given position set by <paramref name="pos"/>. You can insert it at a specific index using the <paramref name="atIndex"/> argument. If you use the default value for <paramref name="atIndex"/>, the point is inserted at the end of the blend points array.</para>
    /// </summary>
    public void AddBlendPoint(AnimationRootNode node, float pos, int atIndex = -1)
    {
        NativeCalls.godot_icall_3_145(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(node), pos, atIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendPointPosition, 1602489585ul);

    /// <summary>
    /// <para>Updates the position of the point at index <paramref name="point"/> on the blend axis.</para>
    /// </summary>
    public void SetBlendPointPosition(int point, float pos)
    {
        NativeCalls.godot_icall_2_69(MethodBind1, GodotObject.GetPtr(this), point, pos);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendPointPosition, 2339986948ul);

    /// <summary>
    /// <para>Returns the position of the point at index <paramref name="point"/>.</para>
    /// </summary>
    public float GetBlendPointPosition(int point)
    {
        return NativeCalls.godot_icall_1_72(MethodBind2, GodotObject.GetPtr(this), point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendPointNode, 4240341528ul);

    /// <summary>
    /// <para>Changes the <see cref="Godot.AnimationNode"/> referenced by the point at index <paramref name="point"/>.</para>
    /// </summary>
    public void SetBlendPointNode(int point, AnimationRootNode node)
    {
        NativeCalls.godot_icall_2_70(MethodBind3, GodotObject.GetPtr(this), point, GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendPointNode, 665599029ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.AnimationNode"/> referenced by the point at index <paramref name="point"/>.</para>
    /// </summary>
    public AnimationRootNode GetBlendPointNode(int point)
    {
        return (AnimationRootNode)NativeCalls.godot_icall_1_71(MethodBind4, GodotObject.GetPtr(this), point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveBlendPoint, 1286410249ul);

    /// <summary>
    /// <para>Removes the point at index <paramref name="point"/> from the blend axis.</para>
    /// </summary>
    public void RemoveBlendPoint(int point)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendPointCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of points on the blend axis.</para>
    /// </summary>
    public int GetBlendPointCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinSpace, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinSpace(float minSpace)
    {
        NativeCalls.godot_icall_1_67(MethodBind7, GodotObject.GetPtr(this), minSpace);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinSpace, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMinSpace()
    {
        return NativeCalls.godot_icall_0_68(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxSpace, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxSpace(float maxSpace)
    {
        NativeCalls.godot_icall_1_67(MethodBind9, GodotObject.GetPtr(this), maxSpace);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxSpace, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMaxSpace()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSnap, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSnap(float snap)
    {
        NativeCalls.godot_icall_1_67(MethodBind11, GodotObject.GetPtr(this), snap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSnap, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSnap()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetValueLabel, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetValueLabel(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind13, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetValueLabel, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetValueLabel()
    {
        return NativeCalls.godot_icall_0_58(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendMode, 2600869457ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlendMode(AnimationNodeBlendSpace1D.BlendModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendMode, 1547667849ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationNodeBlendSpace1D.BlendModeEnum GetBlendMode()
    {
        return (AnimationNodeBlendSpace1D.BlendModeEnum)NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseSync, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseSync(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingSync, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingSync()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : AnimationRootNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'min_space' property.
        /// </summary>
        public static readonly StringName MinSpace = "min_space";
        /// <summary>
        /// Cached name for the 'max_space' property.
        /// </summary>
        public static readonly StringName MaxSpace = "max_space";
        /// <summary>
        /// Cached name for the 'snap' property.
        /// </summary>
        public static readonly StringName Snap = "snap";
        /// <summary>
        /// Cached name for the 'value_label' property.
        /// </summary>
        public static readonly StringName ValueLabel = "value_label";
        /// <summary>
        /// Cached name for the 'blend_mode' property.
        /// </summary>
        public static readonly StringName BlendMode = "blend_mode";
        /// <summary>
        /// Cached name for the 'sync' property.
        /// </summary>
        public static readonly StringName Sync = "sync";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AnimationRootNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_blend_point' method.
        /// </summary>
        public static readonly StringName AddBlendPoint = "add_blend_point";
        /// <summary>
        /// Cached name for the 'set_blend_point_position' method.
        /// </summary>
        public static readonly StringName SetBlendPointPosition = "set_blend_point_position";
        /// <summary>
        /// Cached name for the 'get_blend_point_position' method.
        /// </summary>
        public static readonly StringName GetBlendPointPosition = "get_blend_point_position";
        /// <summary>
        /// Cached name for the 'set_blend_point_node' method.
        /// </summary>
        public static readonly StringName SetBlendPointNode = "set_blend_point_node";
        /// <summary>
        /// Cached name for the 'get_blend_point_node' method.
        /// </summary>
        public static readonly StringName GetBlendPointNode = "get_blend_point_node";
        /// <summary>
        /// Cached name for the 'remove_blend_point' method.
        /// </summary>
        public static readonly StringName RemoveBlendPoint = "remove_blend_point";
        /// <summary>
        /// Cached name for the 'get_blend_point_count' method.
        /// </summary>
        public static readonly StringName GetBlendPointCount = "get_blend_point_count";
        /// <summary>
        /// Cached name for the 'set_min_space' method.
        /// </summary>
        public static readonly StringName SetMinSpace = "set_min_space";
        /// <summary>
        /// Cached name for the 'get_min_space' method.
        /// </summary>
        public static readonly StringName GetMinSpace = "get_min_space";
        /// <summary>
        /// Cached name for the 'set_max_space' method.
        /// </summary>
        public static readonly StringName SetMaxSpace = "set_max_space";
        /// <summary>
        /// Cached name for the 'get_max_space' method.
        /// </summary>
        public static readonly StringName GetMaxSpace = "get_max_space";
        /// <summary>
        /// Cached name for the 'set_snap' method.
        /// </summary>
        public static readonly StringName SetSnap = "set_snap";
        /// <summary>
        /// Cached name for the 'get_snap' method.
        /// </summary>
        public static readonly StringName GetSnap = "get_snap";
        /// <summary>
        /// Cached name for the 'set_value_label' method.
        /// </summary>
        public static readonly StringName SetValueLabel = "set_value_label";
        /// <summary>
        /// Cached name for the 'get_value_label' method.
        /// </summary>
        public static readonly StringName GetValueLabel = "get_value_label";
        /// <summary>
        /// Cached name for the 'set_blend_mode' method.
        /// </summary>
        public static readonly StringName SetBlendMode = "set_blend_mode";
        /// <summary>
        /// Cached name for the 'get_blend_mode' method.
        /// </summary>
        public static readonly StringName GetBlendMode = "get_blend_mode";
        /// <summary>
        /// Cached name for the 'set_use_sync' method.
        /// </summary>
        public static readonly StringName SetUseSync = "set_use_sync";
        /// <summary>
        /// Cached name for the 'is_using_sync' method.
        /// </summary>
        public static readonly StringName IsUsingSync = "is_using_sync";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationRootNode.SignalName
    {
    }
}
