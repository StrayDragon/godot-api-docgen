namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A resource used by <see cref="Godot.AnimationNodeBlendTree"/>.</para>
/// <para><see cref="Godot.AnimationNodeBlendSpace2D"/> represents a virtual 2D space on which <see cref="Godot.AnimationRootNode"/>s are placed. Outputs the linear blend of the three adjacent animations using a <see cref="Godot.Vector2"/> weight. Adjacent in this context means the three <see cref="Godot.AnimationRootNode"/>s making up the triangle that contains the current value.</para>
/// <para>You can add vertices to the blend space with <see cref="Godot.AnimationNodeBlendSpace2D.AddBlendPoint(AnimationRootNode, Vector2, int)"/> and automatically triangulate it by setting <see cref="Godot.AnimationNodeBlendSpace2D.AutoTriangles"/> to <see langword="true"/>. Otherwise, use <see cref="Godot.AnimationNodeBlendSpace2D.AddTriangle(int, int, int, int)"/> and <see cref="Godot.AnimationNodeBlendSpace2D.RemoveTriangle(int)"/> to triangulate the blend space by hand.</para>
/// </summary>
public partial class AnimationNodeBlendSpace2D : AnimationRootNode
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
        /// <para>Similar to <see cref="Godot.AnimationNodeBlendSpace2D.BlendModeEnum.Discrete"/>, but starts the new animation at the last animation's playback position.</para>
        /// </summary>
        DiscreteCarry = 2
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the blend space is triangulated automatically. The mesh updates every time you add or remove points with <see cref="Godot.AnimationNodeBlendSpace2D.AddBlendPoint(AnimationRootNode, Vector2, int)"/> and <see cref="Godot.AnimationNodeBlendSpace2D.RemoveBlendPoint(int)"/>.</para>
    /// </summary>
    public bool AutoTriangles
    {
        get
        {
            return GetAutoTriangles();
        }
        set
        {
            SetAutoTriangles(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public int[] Triangles
    {
        get
        {
            return _GetTriangles();
        }
        set
        {
            _SetTriangles(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>The blend space's X and Y axes' lower limit for the points' position. See <see cref="Godot.AnimationNodeBlendSpace2D.AddBlendPoint(AnimationRootNode, Vector2, int)"/>.</para>
    /// </summary>
    public Vector2 MinSpace
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
    /// <para>The blend space's X and Y axes' upper limit for the points' position. See <see cref="Godot.AnimationNodeBlendSpace2D.AddBlendPoint(AnimationRootNode, Vector2, int)"/>.</para>
    /// </summary>
    public Vector2 MaxSpace
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
    /// <para>Position increment to snap to when moving a point.</para>
    /// </summary>
    public Vector2 Snap
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
    /// <para>Name of the blend space's X axis.</para>
    /// </summary>
    public string XLabel
    {
        get
        {
            return GetXLabel();
        }
        set
        {
            SetXLabel(value);
        }
    }

    /// <summary>
    /// <para>Name of the blend space's Y axis.</para>
    /// </summary>
    public string YLabel
    {
        get
        {
            return GetYLabel();
        }
        set
        {
            SetYLabel(value);
        }
    }

    /// <summary>
    /// <para>Controls the interpolation between animations.</para>
    /// </summary>
    public AnimationNodeBlendSpace2D.BlendModeEnum BlendMode
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

    private static readonly System.Type CachedType = typeof(AnimationNodeBlendSpace2D);

    private static readonly StringName NativeName = "AnimationNodeBlendSpace2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeBlendSpace2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeBlendSpace2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeBlendSpace2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddBlendPoint, 402261981ul);

    /// <summary>
    /// <para>Adds a new point that represents a <paramref name="node"/> at the position set by <paramref name="pos"/>. You can insert it at a specific index using the <paramref name="atIndex"/> argument. If you use the default value for <paramref name="atIndex"/>, the point is inserted at the end of the blend points array.</para>
    /// </summary>
    public unsafe void AddBlendPoint(AnimationRootNode node, Vector2 pos, int atIndex = -1)
    {
        NativeCalls.godot_icall_3_146(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(node), &pos, atIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendPointPosition, 163021252ul);

    /// <summary>
    /// <para>Updates the position of the point at index <paramref name="point"/> in the blend space.</para>
    /// </summary>
    public unsafe void SetBlendPointPosition(int point, Vector2 pos)
    {
        NativeCalls.godot_icall_2_147(MethodBind1, GodotObject.GetPtr(this), point, &pos);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendPointPosition, 2299179447ul);

    /// <summary>
    /// <para>Returns the position of the point at index <paramref name="point"/>.</para>
    /// </summary>
    public Vector2 GetBlendPointPosition(int point)
    {
        return NativeCalls.godot_icall_1_148(MethodBind2, GodotObject.GetPtr(this), point);
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
    /// <para>Returns the <see cref="Godot.AnimationRootNode"/> referenced by the point at index <paramref name="point"/>.</para>
    /// </summary>
    public AnimationRootNode GetBlendPointNode(int point)
    {
        return (AnimationRootNode)NativeCalls.godot_icall_1_71(MethodBind4, GodotObject.GetPtr(this), point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveBlendPoint, 1286410249ul);

    /// <summary>
    /// <para>Removes the point at index <paramref name="point"/> from the blend space.</para>
    /// </summary>
    public void RemoveBlendPoint(int point)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendPointCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of points in the blend space.</para>
    /// </summary>
    public int GetBlendPointCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTriangle, 753017335ul);

    /// <summary>
    /// <para>Creates a new triangle using three points <paramref name="x"/>, <paramref name="y"/>, and <paramref name="z"/>. Triangles can overlap. You can insert the triangle at a specific index using the <paramref name="atIndex"/> argument. If you use the default value for <paramref name="atIndex"/>, the point is inserted at the end of the blend points array.</para>
    /// </summary>
    public void AddTriangle(int x, int y, int z, int atIndex = -1)
    {
        NativeCalls.godot_icall_4_149(MethodBind7, GodotObject.GetPtr(this), x, y, z, atIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrianglePoint, 50157827ul);

    /// <summary>
    /// <para>Returns the position of the point at index <paramref name="point"/> in the triangle of index <paramref name="triangle"/>.</para>
    /// </summary>
    public int GetTrianglePoint(int triangle, int point)
    {
        return NativeCalls.godot_icall_2_73(MethodBind8, GodotObject.GetPtr(this), triangle, point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTriangle, 1286410249ul);

    /// <summary>
    /// <para>Removes the triangle at index <paramref name="triangle"/> from the blend space.</para>
    /// </summary>
    public void RemoveTriangle(int triangle)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), triangle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTriangleCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of triangles in the blend space.</para>
    /// </summary>
    public int GetTriangleCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinSpace, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMinSpace(Vector2 minSpace)
    {
        NativeCalls.godot_icall_1_36(MethodBind11, GodotObject.GetPtr(this), &minSpace);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinSpace, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetMinSpace()
    {
        return NativeCalls.godot_icall_0_37(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxSpace, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMaxSpace(Vector2 maxSpace)
    {
        NativeCalls.godot_icall_1_36(MethodBind13, GodotObject.GetPtr(this), &maxSpace);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxSpace, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetMaxSpace()
    {
        return NativeCalls.godot_icall_0_37(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSnap, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSnap(Vector2 snap)
    {
        NativeCalls.godot_icall_1_36(MethodBind15, GodotObject.GetPtr(this), &snap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSnap, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetSnap()
    {
        return NativeCalls.godot_icall_0_37(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetXLabel, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetXLabel(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind17, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetXLabel, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetXLabel()
    {
        return NativeCalls.godot_icall_0_58(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetYLabel, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetYLabel(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind19, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetYLabel, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetYLabel()
    {
        return NativeCalls.godot_icall_0_58(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetTriangles, 3614634198ul);

    internal void _SetTriangles(int[] triangles)
    {
        NativeCalls.godot_icall_1_150(MethodBind21, GodotObject.GetPtr(this), triangles);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetTriangles, 1930428628ul);

    internal int[] _GetTriangles()
    {
        return NativeCalls.godot_icall_0_151(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoTriangles, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoTriangles(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind23, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoTriangles, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAutoTriangles()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendMode, 81193520ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlendMode(AnimationNodeBlendSpace2D.BlendModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind25, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendMode, 1398433632ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationNodeBlendSpace2D.BlendModeEnum GetBlendMode()
    {
        return (AnimationNodeBlendSpace2D.BlendModeEnum)NativeCalls.godot_icall_0_39(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseSync, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseSync(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind27, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingSync, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingSync()
    {
        return NativeCalls.godot_icall_0_15(MethodBind28, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// <para>Emitted every time the blend space's triangles are created, removed, or when one of their vertices changes position.</para>
    /// </summary>
    public event Action TrianglesUpdated
    {
        add => Connect(SignalName.TrianglesUpdated, Callable.From(value));
        remove => Disconnect(SignalName.TrianglesUpdated, Callable.From(value));
    }

    protected void EmitSignalTrianglesUpdated()
    {
        EmitSignal(SignalName.TrianglesUpdated);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_triangles_updated = "TrianglesUpdated";

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
        if (signal == SignalName.TrianglesUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_triangles_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : AnimationRootNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'auto_triangles' property.
        /// </summary>
        public static readonly StringName AutoTriangles = "auto_triangles";
        /// <summary>
        /// Cached name for the 'triangles' property.
        /// </summary>
        public static readonly StringName Triangles = "triangles";
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
        /// Cached name for the 'x_label' property.
        /// </summary>
        public static readonly StringName XLabel = "x_label";
        /// <summary>
        /// Cached name for the 'y_label' property.
        /// </summary>
        public static readonly StringName YLabel = "y_label";
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
        /// Cached name for the 'add_triangle' method.
        /// </summary>
        public static readonly StringName AddTriangle = "add_triangle";
        /// <summary>
        /// Cached name for the 'get_triangle_point' method.
        /// </summary>
        public static readonly StringName GetTrianglePoint = "get_triangle_point";
        /// <summary>
        /// Cached name for the 'remove_triangle' method.
        /// </summary>
        public static readonly StringName RemoveTriangle = "remove_triangle";
        /// <summary>
        /// Cached name for the 'get_triangle_count' method.
        /// </summary>
        public static readonly StringName GetTriangleCount = "get_triangle_count";
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
        /// Cached name for the 'set_x_label' method.
        /// </summary>
        public static readonly StringName SetXLabel = "set_x_label";
        /// <summary>
        /// Cached name for the 'get_x_label' method.
        /// </summary>
        public static readonly StringName GetXLabel = "get_x_label";
        /// <summary>
        /// Cached name for the 'set_y_label' method.
        /// </summary>
        public static readonly StringName SetYLabel = "set_y_label";
        /// <summary>
        /// Cached name for the 'get_y_label' method.
        /// </summary>
        public static readonly StringName GetYLabel = "get_y_label";
        /// <summary>
        /// Cached name for the '_set_triangles' method.
        /// </summary>
        public static readonly StringName _SetTriangles = "_set_triangles";
        /// <summary>
        /// Cached name for the '_get_triangles' method.
        /// </summary>
        public static readonly StringName _GetTriangles = "_get_triangles";
        /// <summary>
        /// Cached name for the 'set_auto_triangles' method.
        /// </summary>
        public static readonly StringName SetAutoTriangles = "set_auto_triangles";
        /// <summary>
        /// Cached name for the 'get_auto_triangles' method.
        /// </summary>
        public static readonly StringName GetAutoTriangles = "get_auto_triangles";
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
        /// <summary>
        /// Cached name for the 'triangles_updated' signal.
        /// </summary>
        public static readonly StringName TrianglesUpdated = "triangles_updated";
    }
}
