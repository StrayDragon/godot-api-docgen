namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A link between two positions on <see cref="Godot.NavigationRegion3D"/>s that agents can be routed through. These positions can be on the same <see cref="Godot.NavigationRegion3D"/> or on two different ones. Links are useful to express navigation methods other than traveling along the surface of the navigation mesh, such as ziplines, teleporters, or gaps that can be jumped across.</para>
/// </summary>
public partial class NavigationLink3D : Node3D
{
    /// <summary>
    /// <para>Whether this link is currently active. If <see langword="false"/>, <see cref="Godot.NavigationServer3D.MapGetPath(Rid, Vector3, Vector3, bool, uint)"/> will ignore this link.</para>
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
    /// <para>Whether this link can be traveled in both directions or only from <see cref="Godot.NavigationLink3D.StartPosition"/> to <see cref="Godot.NavigationLink3D.EndPosition"/>.</para>
    /// </summary>
    public bool Bidirectional
    {
        get
        {
            return IsBidirectional();
        }
        set
        {
            SetBidirectional(value);
        }
    }

    /// <summary>
    /// <para>A bitfield determining all navigation layers the link belongs to. These navigation layers will be checked when requesting a path with <see cref="Godot.NavigationServer3D.MapGetPath(Rid, Vector3, Vector3, bool, uint)"/>.</para>
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
    /// <para>Starting position of the link.</para>
    /// <para>This position will search out the nearest polygon in the navigation mesh to attach to.</para>
    /// <para>The distance the link will search is controlled by <see cref="Godot.NavigationServer3D.MapSetLinkConnectionRadius(Rid, float)"/>.</para>
    /// </summary>
    public Vector3 StartPosition
    {
        get
        {
            return GetStartPosition();
        }
        set
        {
            SetStartPosition(value);
        }
    }

    /// <summary>
    /// <para>Ending position of the link.</para>
    /// <para>This position will search out the nearest polygon in the navigation mesh to attach to.</para>
    /// <para>The distance the link will search is controlled by <see cref="Godot.NavigationServer3D.MapSetLinkConnectionRadius(Rid, float)"/>.</para>
    /// </summary>
    public Vector3 EndPosition
    {
        get
        {
            return GetEndPosition();
        }
        set
        {
            SetEndPosition(value);
        }
    }

    /// <summary>
    /// <para>When pathfinding enters this link from another regions navigation mesh the <see cref="Godot.NavigationLink3D.EnterCost"/> value is added to the path distance for determining the shortest path.</para>
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
    /// <para>When pathfinding moves along the link the traveled distance is multiplied with <see cref="Godot.NavigationLink3D.TravelCost"/> for determining the shortest path.</para>
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

    private static readonly System.Type CachedType = typeof(NavigationLink3D);

    private static readonly StringName NativeName = "NavigationLink3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public NavigationLink3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal NavigationLink3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal NavigationLink3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of this link on the <see cref="Godot.NavigationServer3D"/>.</para>
    /// </summary>
    public Rid GetRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind1, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationMap, 2722037293ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Rid"/> of the navigation map this link should use. By default the link will automatically join the <see cref="Godot.World3D"/> default navigation map so this function is only required to override the default map.</para>
    /// </summary>
    public void SetNavigationMap(Rid navigationMap)
    {
        NativeCalls.godot_icall_1_286(MethodBind3, GodotObject.GetPtr(this), navigationMap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationMap, 2944877500ul);

    /// <summary>
    /// <para>Returns the current navigation map <see cref="Godot.Rid"/> used by this link.</para>
    /// </summary>
    public Rid GetNavigationMap()
    {
        return NativeCalls.godot_icall_0_238(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBidirectional, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBidirectional(bool bidirectional)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), bidirectional.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBidirectional, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsBidirectional()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationLayers, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNavigationLayers(uint navigationLayers)
    {
        NativeCalls.godot_icall_1_208(MethodBind7, GodotObject.GetPtr(this), navigationLayers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationLayers, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetNavigationLayers()
    {
        return NativeCalls.godot_icall_0_209(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationLayerValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.NavigationLink3D.NavigationLayers"/> bitmask, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetNavigationLayerValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind9, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationLayerValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.NavigationLink3D.NavigationLayers"/> bitmask is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetNavigationLayerValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind10, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStartPosition, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetStartPosition(Vector3 position)
    {
        NativeCalls.godot_icall_1_177(MethodBind11, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStartPosition, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetStartPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndPosition, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetEndPosition(Vector3 position)
    {
        NativeCalls.godot_icall_1_177(MethodBind13, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndPosition, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetEndPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalStartPosition, 3460891852ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.NavigationLink3D.StartPosition"/> that is relative to the link from a global <paramref name="position"/>.</para>
    /// </summary>
    public unsafe void SetGlobalStartPosition(Vector3 position)
    {
        NativeCalls.godot_icall_1_177(MethodBind15, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalStartPosition, 3360562783ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.NavigationLink3D.StartPosition"/> that is relative to the link as a global position.</para>
    /// </summary>
    public Vector3 GetGlobalStartPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalEndPosition, 3460891852ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.NavigationLink3D.EndPosition"/> that is relative to the link from a global <paramref name="position"/>.</para>
    /// </summary>
    public unsafe void SetGlobalEndPosition(Vector3 position)
    {
        NativeCalls.godot_icall_1_177(MethodBind17, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalEndPosition, 3360562783ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.NavigationLink3D.EndPosition"/> that is relative to the link as a global position.</para>
    /// </summary>
    public Vector3 GetGlobalEndPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnterCost, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnterCost(float enterCost)
    {
        NativeCalls.godot_icall_1_67(MethodBind19, GodotObject.GetPtr(this), enterCost);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnterCost, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEnterCost()
    {
        return NativeCalls.godot_icall_0_68(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTravelCost, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTravelCost(float travelCost)
    {
        NativeCalls.godot_icall_1_67(MethodBind21, GodotObject.GetPtr(this), travelCost);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTravelCost, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTravelCost()
    {
        return NativeCalls.godot_icall_0_68(MethodBind22, GodotObject.GetPtr(this));
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
        /// Cached name for the 'enabled' property.
        /// </summary>
        public static readonly StringName Enabled = "enabled";
        /// <summary>
        /// Cached name for the 'bidirectional' property.
        /// </summary>
        public static readonly StringName Bidirectional = "bidirectional";
        /// <summary>
        /// Cached name for the 'navigation_layers' property.
        /// </summary>
        public static readonly StringName NavigationLayers = "navigation_layers";
        /// <summary>
        /// Cached name for the 'start_position' property.
        /// </summary>
        public static readonly StringName StartPosition = "start_position";
        /// <summary>
        /// Cached name for the 'end_position' property.
        /// </summary>
        public static readonly StringName EndPosition = "end_position";
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
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_rid' method.
        /// </summary>
        public static readonly StringName GetRid = "get_rid";
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
        /// Cached name for the 'set_bidirectional' method.
        /// </summary>
        public static readonly StringName SetBidirectional = "set_bidirectional";
        /// <summary>
        /// Cached name for the 'is_bidirectional' method.
        /// </summary>
        public static readonly StringName IsBidirectional = "is_bidirectional";
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
        /// Cached name for the 'set_start_position' method.
        /// </summary>
        public static readonly StringName SetStartPosition = "set_start_position";
        /// <summary>
        /// Cached name for the 'get_start_position' method.
        /// </summary>
        public static readonly StringName GetStartPosition = "get_start_position";
        /// <summary>
        /// Cached name for the 'set_end_position' method.
        /// </summary>
        public static readonly StringName SetEndPosition = "set_end_position";
        /// <summary>
        /// Cached name for the 'get_end_position' method.
        /// </summary>
        public static readonly StringName GetEndPosition = "get_end_position";
        /// <summary>
        /// Cached name for the 'set_global_start_position' method.
        /// </summary>
        public static readonly StringName SetGlobalStartPosition = "set_global_start_position";
        /// <summary>
        /// Cached name for the 'get_global_start_position' method.
        /// </summary>
        public static readonly StringName GetGlobalStartPosition = "get_global_start_position";
        /// <summary>
        /// Cached name for the 'set_global_end_position' method.
        /// </summary>
        public static readonly StringName SetGlobalEndPosition = "set_global_end_position";
        /// <summary>
        /// Cached name for the 'get_global_end_position' method.
        /// </summary>
        public static readonly StringName GetGlobalEndPosition = "get_global_end_position";
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
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
