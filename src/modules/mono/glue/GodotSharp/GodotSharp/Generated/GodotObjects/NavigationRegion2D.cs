namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A traversable 2D region based on a <see cref="Godot.NavigationPolygon"/> that <see cref="Godot.NavigationAgent2D"/>s can use for pathfinding.</para>
/// <para>Two regions can be connected to each other if they share a similar edge. You can set the minimum distance between two vertices required to connect two edges by using <see cref="Godot.NavigationServer2D.MapSetEdgeConnectionMargin(Rid, float)"/>.</para>
/// <para><b>Note:</b> Overlapping two regions' navigation polygons is not enough for connecting two regions. They must share a similar edge.</para>
/// <para>The pathfinding cost of entering a region from another region can be controlled with the <see cref="Godot.NavigationRegion2D.EnterCost"/> value.</para>
/// <para><b>Note:</b> This value is not added to the path cost when the start position is already inside this region.</para>
/// <para>The pathfinding cost of traveling distances inside this region can be controlled with the <see cref="Godot.NavigationRegion2D.TravelCost"/> multiplier.</para>
/// <para><b>Note:</b> This node caches changes to its properties, so if you make changes to the underlying region <see cref="Godot.Rid"/> in <see cref="Godot.NavigationServer2D"/>, they will not be reflected in this node's properties.</para>
/// </summary>
public partial class NavigationRegion2D : Node2D
{
    /// <summary>
    /// <para>The <see cref="Godot.NavigationPolygon"/> resource to use.</para>
    /// </summary>
    public NavigationPolygon NavigationPolygon
    {
        get
        {
            return GetNavigationPolygon();
        }
        set
        {
            SetNavigationPolygon(value);
        }
    }

    /// <summary>
    /// <para>Determines if the <see cref="Godot.NavigationRegion2D"/> is enabled or disabled.</para>
    /// </summary>
    public bool Enabled
    {
        get
        {
            return IsEnabled();
        }
        set
        {
            SetEnabled(value);
        }
    }

    /// <summary>
    /// <para>If enabled the navigation region will use edge connections to connect with other navigation regions within proximity of the navigation map edge connection margin.</para>
    /// </summary>
    public bool UseEdgeConnections
    {
        get
        {
            return GetUseEdgeConnections();
        }
        set
        {
            SetUseEdgeConnections(value);
        }
    }

    /// <summary>
    /// <para>A bitfield determining all navigation layers the region belongs to. These navigation layers can be checked upon when requesting a path with <see cref="Godot.NavigationServer2D.MapGetPath(Rid, Vector2, Vector2, bool, uint)"/>.</para>
    /// </summary>
    public uint NavigationLayers
    {
        get
        {
            return GetNavigationLayers();
        }
        set
        {
            SetNavigationLayers(value);
        }
    }

    /// <summary>
    /// <para>When pathfinding enters this region's navigation mesh from another regions navigation mesh the <see cref="Godot.NavigationRegion2D.EnterCost"/> value is added to the path distance for determining the shortest path.</para>
    /// </summary>
    public float EnterCost
    {
        get
        {
            return GetEnterCost();
        }
        set
        {
            SetEnterCost(value);
        }
    }

    /// <summary>
    /// <para>When pathfinding moves inside this region's navigation mesh the traveled distances are multiplied with <see cref="Godot.NavigationRegion2D.TravelCost"/> for determining the shortest path.</para>
    /// </summary>
    public float TravelCost
    {
        get
        {
            return GetTravelCost();
        }
        set
        {
            SetTravelCost(value);
        }
    }

    private static readonly System.Type CachedType = typeof(NavigationRegion2D);

    private static readonly StringName NativeName = "NavigationRegion2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public NavigationRegion2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal NavigationRegion2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal NavigationRegion2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of this region on the <see cref="Godot.NavigationServer2D"/>. Combined with <see cref="Godot.NavigationServer2D.MapGetClosestPointOwner(Rid, Vector2)"/> can be used to identify the <see cref="Godot.NavigationRegion2D"/> closest to a point on the merged navigation map.</para>
    /// </summary>
    public Rid GetRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationPolygon, 1515040758ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNavigationPolygon(NavigationPolygon navigationPolygon)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(navigationPolygon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationPolygon, 1046532237ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationPolygon GetNavigationPolygon()
    {
        return (NavigationPolygon)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationMap, 2722037293ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Rid"/> of the navigation map this region should use. By default the region will automatically join the <see cref="Godot.World2D"/> default navigation map so this function is only required to override the default map.</para>
    /// </summary>
    public void SetNavigationMap(Rid navigationMap)
    {
        NativeCalls.godot_icall_1_286(MethodBind5, GodotObject.GetPtr(this), navigationMap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationMap, 2944877500ul);

    /// <summary>
    /// <para>Returns the current navigation map <see cref="Godot.Rid"/> used by this region.</para>
    /// </summary>
    public Rid GetNavigationMap()
    {
        return NativeCalls.godot_icall_0_238(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseEdgeConnections, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseEdgeConnections(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseEdgeConnections, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseEdgeConnections()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationLayers, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNavigationLayers(uint navigationLayers)
    {
        NativeCalls.godot_icall_1_208(MethodBind9, GodotObject.GetPtr(this), navigationLayers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationLayers, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetNavigationLayers()
    {
        return NativeCalls.godot_icall_0_209(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationLayerValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.NavigationRegion2D.NavigationLayers"/> bitmask, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetNavigationLayerValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind11, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationLayerValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.NavigationRegion2D.NavigationLayers"/> bitmask is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetNavigationLayerValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind12, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRegionRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of this region on the <see cref="Godot.NavigationServer2D"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.NavigationRegion2D.GetRid()' instead.")]
    public Rid GetRegionRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnterCost, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnterCost(float enterCost)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), enterCost);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnterCost, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEnterCost()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTravelCost, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTravelCost(float travelCost)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), travelCost);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTravelCost, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTravelCost()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BakeNavigationPolygon, 3216645846ul);

    /// <summary>
    /// <para>Bakes the <see cref="Godot.NavigationPolygon"/>. If <paramref name="onThread"/> is set to <see langword="true"/> (default), the baking is done on a separate thread.</para>
    /// </summary>
    public void BakeNavigationPolygon(bool onThread = true)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), onThread.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBaking, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> when the <see cref="Godot.NavigationPolygon"/> is being baked on a background thread.</para>
    /// </summary>
    public bool IsBaking()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBounds, 1639390495ul);

    /// <summary>
    /// <para>Returns the axis-aligned rectangle for the region's transformed navigation mesh.</para>
    /// </summary>
    public Rect2 GetBounds()
    {
        return NativeCalls.godot_icall_0_189(MethodBind20, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the used navigation polygon is replaced or changes to the internals of the current navigation polygon are committed.</para>
    /// </summary>
    public event Action NavigationPolygonChanged
    {
        add => Connect(SignalName.NavigationPolygonChanged, Callable.From(value));
        remove => Disconnect(SignalName.NavigationPolygonChanged, Callable.From(value));
    }

    protected void EmitSignalNavigationPolygonChanged()
    {
        EmitSignal(SignalName.NavigationPolygonChanged);
    }

    /// <summary>
    /// <para>Emitted when a navigation polygon bake operation is completed.</para>
    /// </summary>
    public event Action BakeFinished
    {
        add => Connect(SignalName.BakeFinished, Callable.From(value));
        remove => Disconnect(SignalName.BakeFinished, Callable.From(value));
    }

    protected void EmitSignalBakeFinished()
    {
        EmitSignal(SignalName.BakeFinished);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_navigation_polygon_changed = "NavigationPolygonChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_bake_finished = "BakeFinished";

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
        if (signal == SignalName.NavigationPolygonChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_navigation_polygon_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.BakeFinished)
        {
            if (HasGodotClassSignal(SignalProxyName_bake_finished.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'navigation_polygon' property.
        /// </summary>
        public static readonly StringName NavigationPolygon = "navigation_polygon";
        /// <summary>
        /// Cached name for the 'enabled' property.
        /// </summary>
        public static readonly StringName Enabled = "enabled";
        /// <summary>
        /// Cached name for the 'use_edge_connections' property.
        /// </summary>
        public static readonly StringName UseEdgeConnections = "use_edge_connections";
        /// <summary>
        /// Cached name for the 'navigation_layers' property.
        /// </summary>
        public static readonly StringName NavigationLayers = "navigation_layers";
        /// <summary>
        /// Cached name for the 'enter_cost' property.
        /// </summary>
        public static readonly StringName EnterCost = "enter_cost";
        /// <summary>
        /// Cached name for the 'travel_cost' property.
        /// </summary>
        public static readonly StringName TravelCost = "travel_cost";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_rid' method.
        /// </summary>
        public static readonly StringName GetRid = "get_rid";
        /// <summary>
        /// Cached name for the 'set_navigation_polygon' method.
        /// </summary>
        public static readonly StringName SetNavigationPolygon = "set_navigation_polygon";
        /// <summary>
        /// Cached name for the 'get_navigation_polygon' method.
        /// </summary>
        public static readonly StringName GetNavigationPolygon = "get_navigation_polygon";
        /// <summary>
        /// Cached name for the 'set_enabled' method.
        /// </summary>
        public static readonly StringName SetEnabled = "set_enabled";
        /// <summary>
        /// Cached name for the 'is_enabled' method.
        /// </summary>
        public static readonly StringName IsEnabled = "is_enabled";
        /// <summary>
        /// Cached name for the 'set_navigation_map' method.
        /// </summary>
        public static readonly StringName SetNavigationMap = "set_navigation_map";
        /// <summary>
        /// Cached name for the 'get_navigation_map' method.
        /// </summary>
        public static readonly StringName GetNavigationMap = "get_navigation_map";
        /// <summary>
        /// Cached name for the 'set_use_edge_connections' method.
        /// </summary>
        public static readonly StringName SetUseEdgeConnections = "set_use_edge_connections";
        /// <summary>
        /// Cached name for the 'get_use_edge_connections' method.
        /// </summary>
        public static readonly StringName GetUseEdgeConnections = "get_use_edge_connections";
        /// <summary>
        /// Cached name for the 'set_navigation_layers' method.
        /// </summary>
        public static readonly StringName SetNavigationLayers = "set_navigation_layers";
        /// <summary>
        /// Cached name for the 'get_navigation_layers' method.
        /// </summary>
        public static readonly StringName GetNavigationLayers = "get_navigation_layers";
        /// <summary>
        /// Cached name for the 'set_navigation_layer_value' method.
        /// </summary>
        public static readonly StringName SetNavigationLayerValue = "set_navigation_layer_value";
        /// <summary>
        /// Cached name for the 'get_navigation_layer_value' method.
        /// </summary>
        public static readonly StringName GetNavigationLayerValue = "get_navigation_layer_value";
        /// <summary>
        /// Cached name for the 'get_region_rid' method.
        /// </summary>
        public static readonly StringName GetRegionRid = "get_region_rid";
        /// <summary>
        /// Cached name for the 'set_enter_cost' method.
        /// </summary>
        public static readonly StringName SetEnterCost = "set_enter_cost";
        /// <summary>
        /// Cached name for the 'get_enter_cost' method.
        /// </summary>
        public static readonly StringName GetEnterCost = "get_enter_cost";
        /// <summary>
        /// Cached name for the 'set_travel_cost' method.
        /// </summary>
        public static readonly StringName SetTravelCost = "set_travel_cost";
        /// <summary>
        /// Cached name for the 'get_travel_cost' method.
        /// </summary>
        public static readonly StringName GetTravelCost = "get_travel_cost";
        /// <summary>
        /// Cached name for the 'bake_navigation_polygon' method.
        /// </summary>
        public static readonly StringName BakeNavigationPolygon = "bake_navigation_polygon";
        /// <summary>
        /// Cached name for the 'is_baking' method.
        /// </summary>
        public static readonly StringName IsBaking = "is_baking";
        /// <summary>
        /// Cached name for the 'get_bounds' method.
        /// </summary>
        public static readonly StringName GetBounds = "get_bounds";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
        /// <summary>
        /// Cached name for the 'navigation_polygon_changed' signal.
        /// </summary>
        public static readonly StringName NavigationPolygonChanged = "navigation_polygon_changed";
        /// <summary>
        /// Cached name for the 'bake_finished' signal.
        /// </summary>
        public static readonly StringName BakeFinished = "bake_finished";
    }
}
