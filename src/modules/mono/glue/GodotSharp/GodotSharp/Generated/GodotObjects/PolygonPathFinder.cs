namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
public partial class PolygonPathFinder : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary Data
    {
        get
        {
            return _GetData();
        }
        set
        {
            _SetData(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(PolygonPathFinder);

    private static readonly StringName NativeName = "PolygonPathFinder";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PolygonPathFinder() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PolygonPathFinder(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PolygonPathFinder(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Setup, 3251786936ul);

    /// <summary>
    /// <para>Sets up <see cref="Godot.PolygonPathFinder"/> with an array of points that define the vertices of the polygon, and an array of indices that determine the edges of the polygon.</para>
    /// <para>The length of <paramref name="connections"/> must be even, returns an error if odd.</para>
    /// <para><code>
    /// var polygonPathFinder = new PolygonPathFinder();
    /// Vector2[] points =
    /// [
    /// 	new Vector2(0.0f, 0.0f),
    /// 	new Vector2(1.0f, 0.0f),
    /// 	new Vector2(0.0f, 1.0f)
    /// ];
    /// int[] connections = [0, 1, 1, 2, 2, 0];
    /// polygonPathFinder.Setup(points, connections);
    /// </code></para>
    /// </summary>
    public void Setup(Vector2[] points, int[] connections)
    {
        NativeCalls.godot_icall_2_1014(MethodBind0, GodotObject.GetPtr(this), points, connections);
    }

    /// <summary>
    /// <para>Sets up <see cref="Godot.PolygonPathFinder"/> with an array of points that define the vertices of the polygon, and an array of indices that determine the edges of the polygon.</para>
    /// <para>The length of <paramref name="connections"/> must be even, returns an error if odd.</para>
    /// <para><code>
    /// var polygonPathFinder = new PolygonPathFinder();
    /// Vector2[] points =
    /// [
    /// 	new Vector2(0.0f, 0.0f),
    /// 	new Vector2(1.0f, 0.0f),
    /// 	new Vector2(0.0f, 1.0f)
    /// ];
    /// int[] connections = [0, 1, 1, 2, 2, 0];
    /// polygonPathFinder.Setup(points, connections);
    /// </code></para>
    /// </summary>
    public void Setup(ReadOnlySpan<Vector2> points, ReadOnlySpan<int> connections)
    {
        NativeCalls.godot_icall_2_1014(MethodBind0, GodotObject.GetPtr(this), points, connections);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindPath, 1562168077ul);

    public unsafe Vector2[] FindPath(Vector2 from, Vector2 to)
    {
        return NativeCalls.godot_icall_2_698(MethodBind1, GodotObject.GetPtr(this), &from, &to);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIntersections, 3932192302ul);

    public unsafe Vector2[] GetIntersections(Vector2 from, Vector2 to)
    {
        return NativeCalls.godot_icall_2_698(MethodBind2, GodotObject.GetPtr(this), &from, &to);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestPoint, 2656412154ul);

    public unsafe Vector2 GetClosestPoint(Vector2 point)
    {
        return NativeCalls.godot_icall_1_20(MethodBind3, GodotObject.GetPtr(this), &point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPointInside, 556197845ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="point"/> falls inside the polygon area.</para>
    /// <para><code>
    /// var polygonPathFinder = new PolygonPathFinder();
    /// Vector2[] points =
    /// [
    /// 	new Vector2(0.0f, 0.0f),
    /// 	new Vector2(1.0f, 0.0f),
    /// 	new Vector2(0.0f, 1.0f)
    /// ];
    /// int[] connections = [0, 1, 1, 2, 2, 0];
    /// polygonPathFinder.Setup(points, connections);
    /// GD.Print(polygonPathFinder.IsPointInside(new Vector2(0.2f, 0.2f))); // Prints True
    /// GD.Print(polygonPathFinder.IsPointInside(new Vector2(1.0f, 1.0f))); // Prints False
    /// </code></para>
    /// </summary>
    public unsafe bool IsPointInside(Vector2 point)
    {
        return NativeCalls.godot_icall_1_199(MethodBind4, GodotObject.GetPtr(this), &point).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointPenalty, 1602489585ul);

    public void SetPointPenalty(int idx, float penalty)
    {
        NativeCalls.godot_icall_2_69(MethodBind5, GodotObject.GetPtr(this), idx, penalty);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointPenalty, 2339986948ul);

    public float GetPointPenalty(int idx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind6, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBounds, 1639390495ul);

    public Rect2 GetBounds()
    {
        return NativeCalls.godot_icall_0_189(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetData, 4155329257ul);

    internal void _SetData(Godot.Collections.Dictionary data)
    {
        NativeCalls.godot_icall_1_121(MethodBind8, GodotObject.GetPtr(this), (godot_dictionary)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetData, 3102165223ul);

    internal Godot.Collections.Dictionary _GetData()
    {
        return NativeCalls.godot_icall_0_122(MethodBind9, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'data' property.
        /// </summary>
        public static readonly StringName Data = "data";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'setup' method.
        /// </summary>
        public static readonly StringName Setup = "setup";
        /// <summary>
        /// Cached name for the 'find_path' method.
        /// </summary>
        public static readonly StringName FindPath = "find_path";
        /// <summary>
        /// Cached name for the 'get_intersections' method.
        /// </summary>
        public static readonly StringName GetIntersections = "get_intersections";
        /// <summary>
        /// Cached name for the 'get_closest_point' method.
        /// </summary>
        public static readonly StringName GetClosestPoint = "get_closest_point";
        /// <summary>
        /// Cached name for the 'is_point_inside' method.
        /// </summary>
        public static readonly StringName IsPointInside = "is_point_inside";
        /// <summary>
        /// Cached name for the 'set_point_penalty' method.
        /// </summary>
        public static readonly StringName SetPointPenalty = "set_point_penalty";
        /// <summary>
        /// Cached name for the 'get_point_penalty' method.
        /// </summary>
        public static readonly StringName GetPointPenalty = "get_point_penalty";
        /// <summary>
        /// Cached name for the 'get_bounds' method.
        /// </summary>
        public static readonly StringName GetBounds = "get_bounds";
        /// <summary>
        /// Cached name for the '_set_data' method.
        /// </summary>
        public static readonly StringName _SetData = "_set_data";
        /// <summary>
        /// Cached name for the '_get_data' method.
        /// </summary>
        public static readonly StringName _GetData = "_get_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
