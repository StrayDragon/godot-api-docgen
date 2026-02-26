namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Container for parsed source geometry data used in navigation mesh baking.</para>
/// </summary>
public partial class NavigationMeshSourceGeometryData2D : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array<Vector2[]> TraversableOutlines
    {
        get
        {
            return GetTraversableOutlines();
        }
        set
        {
            SetTraversableOutlines(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array<Vector2[]> ObstructionOutlines
    {
        get
        {
            return GetObstructionOutlines();
        }
        set
        {
            SetObstructionOutlines(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array ProjectedObstructions
    {
        get
        {
            return GetProjectedObstructions();
        }
        set
        {
            SetProjectedObstructions(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(NavigationMeshSourceGeometryData2D);

    private static readonly StringName NativeName = "NavigationMeshSourceGeometryData2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public NavigationMeshSourceGeometryData2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationMeshSourceGeometryData2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationMeshSourceGeometryData2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears the internal data.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasData, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> when parsed source geometry data exists.</para>
    /// </summary>
    public bool HasData()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTraversableOutlines, 381264803ul);

    /// <summary>
    /// <para>Sets all the traversable area outlines arrays.</para>
    /// </summary>
    public void SetTraversableOutlines(Godot.Collections.Array<Vector2[]> traversableOutlines)
    {
        NativeCalls.godot_icall_1_138(MethodBind2, GodotObject.GetPtr(this), (godot_array)(traversableOutlines ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTraversableOutlines, 3995934104ul);

    /// <summary>
    /// <para>Returns all the traversable area outlines arrays.</para>
    /// </summary>
    public Godot.Collections.Array<Vector2[]> GetTraversableOutlines()
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_0_120(MethodBind3, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetObstructionOutlines, 381264803ul);

    /// <summary>
    /// <para>Sets all the obstructed area outlines arrays.</para>
    /// </summary>
    public void SetObstructionOutlines(Godot.Collections.Array<Vector2[]> obstructionOutlines)
    {
        NativeCalls.godot_icall_1_138(MethodBind4, GodotObject.GetPtr(this), (godot_array)(obstructionOutlines ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetObstructionOutlines, 3995934104ul);

    /// <summary>
    /// <para>Returns all the obstructed area outlines arrays.</para>
    /// </summary>
    public Godot.Collections.Array<Vector2[]> GetObstructionOutlines()
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_0_120(MethodBind5, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendTraversableOutlines, 381264803ul);

    /// <summary>
    /// <para>Appends another array of <paramref name="traversableOutlines"/> at the end of the existing traversable outlines array.</para>
    /// </summary>
    public void AppendTraversableOutlines(Godot.Collections.Array<Vector2[]> traversableOutlines)
    {
        NativeCalls.godot_icall_1_138(MethodBind6, GodotObject.GetPtr(this), (godot_array)(traversableOutlines ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendObstructionOutlines, 381264803ul);

    /// <summary>
    /// <para>Appends another array of <paramref name="obstructionOutlines"/> at the end of the existing obstruction outlines array.</para>
    /// </summary>
    public void AppendObstructionOutlines(Godot.Collections.Array<Vector2[]> obstructionOutlines)
    {
        NativeCalls.godot_icall_1_138(MethodBind7, GodotObject.GetPtr(this), (godot_array)(obstructionOutlines ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTraversableOutline, 1509147220ul);

    /// <summary>
    /// <para>Adds the outline points of a shape as traversable area.</para>
    /// </summary>
    public void AddTraversableOutline(Vector2[] shapeOutline)
    {
        NativeCalls.godot_icall_1_224(MethodBind8, GodotObject.GetPtr(this), shapeOutline);
    }

    /// <summary>
    /// <para>Adds the outline points of a shape as traversable area.</para>
    /// </summary>
    public void AddTraversableOutline(ReadOnlySpan<Vector2> shapeOutline)
    {
        NativeCalls.godot_icall_1_224(MethodBind8, GodotObject.GetPtr(this), shapeOutline);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddObstructionOutline, 1509147220ul);

    /// <summary>
    /// <para>Adds the outline points of a shape as obstructed area.</para>
    /// </summary>
    public void AddObstructionOutline(Vector2[] shapeOutline)
    {
        NativeCalls.godot_icall_1_224(MethodBind9, GodotObject.GetPtr(this), shapeOutline);
    }

    /// <summary>
    /// <para>Adds the outline points of a shape as obstructed area.</para>
    /// </summary>
    public void AddObstructionOutline(ReadOnlySpan<Vector2> shapeOutline)
    {
        NativeCalls.godot_icall_1_224(MethodBind9, GodotObject.GetPtr(this), shapeOutline);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Merge, 742424872ul);

    /// <summary>
    /// <para>Adds the geometry data of another <see cref="Godot.NavigationMeshSourceGeometryData2D"/> to the navigation mesh baking data.</para>
    /// </summary>
    public void Merge(NavigationMeshSourceGeometryData2D otherGeometry)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(otherGeometry));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddProjectedObstruction, 3882407395ul);

    /// <summary>
    /// <para>Adds a projected obstruction shape to the source geometry. If <paramref name="carve"/> is <see langword="true"/> the carved shape will not be affected by additional offsets (e.g. agent radius) of the navigation mesh baking process.</para>
    /// </summary>
    public void AddProjectedObstruction(Vector2[] vertices, bool carve)
    {
        NativeCalls.godot_icall_2_838(MethodBind11, GodotObject.GetPtr(this), vertices, carve.ToGodotBool());
    }

    /// <summary>
    /// <para>Adds a projected obstruction shape to the source geometry. If <paramref name="carve"/> is <see langword="true"/> the carved shape will not be affected by additional offsets (e.g. agent radius) of the navigation mesh baking process.</para>
    /// </summary>
    public void AddProjectedObstruction(ReadOnlySpan<Vector2> vertices, bool carve)
    {
        NativeCalls.godot_icall_2_838(MethodBind11, GodotObject.GetPtr(this), vertices, carve.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearProjectedObstructions, 3218959716ul);

    /// <summary>
    /// <para>Clears all projected obstructions.</para>
    /// </summary>
    public void ClearProjectedObstructions()
    {
        NativeCalls.godot_icall_0_3(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProjectedObstructions, 381264803ul);

    /// <summary>
    /// <para>Sets the projected obstructions with an Array of Dictionaries with the following key value pairs:</para>
    /// <para></para>
    /// </summary>
    public void SetProjectedObstructions(Godot.Collections.Array projectedObstructions)
    {
        NativeCalls.godot_icall_1_138(MethodBind13, GodotObject.GetPtr(this), (godot_array)(projectedObstructions ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjectedObstructions, 3995934104ul);

    /// <summary>
    /// <para>Returns the projected obstructions as an <see cref="Godot.Collections.Array"/> of dictionaries. Each <see cref="Godot.Collections.Dictionary"/> contains the following entries:</para>
    /// <para>- <c>vertices</c> - A <see cref="float"/>[] that defines the outline points of the projected shape.</para>
    /// <para>- <c>carve</c> - A <see cref="bool"/> that defines how the projected shape affects the navigation mesh baking. If <see langword="true"/> the projected shape will not be affected by addition offsets, e.g. agent radius.</para>
    /// </summary>
    public Godot.Collections.Array GetProjectedObstructions()
    {
        return NativeCalls.godot_icall_0_120(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBounds, 3248174ul);

    /// <summary>
    /// <para>Returns an axis-aligned bounding box that covers all the stored geometry data. The bounds are calculated when calling this function with the result cached until further geometry changes are made.</para>
    /// </summary>
    public Rect2 GetBounds()
    {
        return NativeCalls.godot_icall_0_189(MethodBind15, GodotObject.GetPtr(this));
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
        /// Cached name for the 'traversable_outlines' property.
        /// </summary>
        public static readonly StringName TraversableOutlines = "traversable_outlines";
        /// <summary>
        /// Cached name for the 'obstruction_outlines' property.
        /// </summary>
        public static readonly StringName ObstructionOutlines = "obstruction_outlines";
        /// <summary>
        /// Cached name for the 'projected_obstructions' property.
        /// </summary>
        public static readonly StringName ProjectedObstructions = "projected_obstructions";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'has_data' method.
        /// </summary>
        public static readonly StringName HasData = "has_data";
        /// <summary>
        /// Cached name for the 'set_traversable_outlines' method.
        /// </summary>
        public static readonly StringName SetTraversableOutlines = "set_traversable_outlines";
        /// <summary>
        /// Cached name for the 'get_traversable_outlines' method.
        /// </summary>
        public static readonly StringName GetTraversableOutlines = "get_traversable_outlines";
        /// <summary>
        /// Cached name for the 'set_obstruction_outlines' method.
        /// </summary>
        public static readonly StringName SetObstructionOutlines = "set_obstruction_outlines";
        /// <summary>
        /// Cached name for the 'get_obstruction_outlines' method.
        /// </summary>
        public static readonly StringName GetObstructionOutlines = "get_obstruction_outlines";
        /// <summary>
        /// Cached name for the 'append_traversable_outlines' method.
        /// </summary>
        public static readonly StringName AppendTraversableOutlines = "append_traversable_outlines";
        /// <summary>
        /// Cached name for the 'append_obstruction_outlines' method.
        /// </summary>
        public static readonly StringName AppendObstructionOutlines = "append_obstruction_outlines";
        /// <summary>
        /// Cached name for the 'add_traversable_outline' method.
        /// </summary>
        public static readonly StringName AddTraversableOutline = "add_traversable_outline";
        /// <summary>
        /// Cached name for the 'add_obstruction_outline' method.
        /// </summary>
        public static readonly StringName AddObstructionOutline = "add_obstruction_outline";
        /// <summary>
        /// Cached name for the 'merge' method.
        /// </summary>
        public static readonly StringName Merge = "merge";
        /// <summary>
        /// Cached name for the 'add_projected_obstruction' method.
        /// </summary>
        public static readonly StringName AddProjectedObstruction = "add_projected_obstruction";
        /// <summary>
        /// Cached name for the 'clear_projected_obstructions' method.
        /// </summary>
        public static readonly StringName ClearProjectedObstructions = "clear_projected_obstructions";
        /// <summary>
        /// Cached name for the 'set_projected_obstructions' method.
        /// </summary>
        public static readonly StringName SetProjectedObstructions = "set_projected_obstructions";
        /// <summary>
        /// Cached name for the 'get_projected_obstructions' method.
        /// </summary>
        public static readonly StringName GetProjectedObstructions = "get_projected_obstructions";
        /// <summary>
        /// Cached name for the 'get_bounds' method.
        /// </summary>
        public static readonly StringName GetBounds = "get_bounds";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
