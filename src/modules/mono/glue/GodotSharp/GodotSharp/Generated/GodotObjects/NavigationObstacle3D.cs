namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An obstacle needs a navigation map and outline <see cref="Godot.NavigationObstacle3D.Vertices"/> defined to work correctly. The outlines can not cross or overlap and are restricted to a plane projection. This means the y-axis of the vertices is ignored, instead the obstacle's global y-axis position is used for placement. The projected shape is extruded by the obstacles height along the y-axis.</para>
/// <para>Obstacles can be included in the navigation mesh baking process when <see cref="Godot.NavigationObstacle3D.AffectNavigationMesh"/> is enabled. They do not add walkable geometry, instead their role is to discard other source geometry inside the shape. This can be used to prevent navigation mesh from appearing in unwanted places, e.g. inside "solid" geometry or on top of it. If <see cref="Godot.NavigationObstacle3D.CarveNavigationMesh"/> is enabled the baked shape will not be affected by offsets of the navigation mesh baking, e.g. the agent radius.</para>
/// <para>With <see cref="Godot.NavigationObstacle3D.AvoidanceEnabled"/> the obstacle can constrain the avoidance velocities of avoidance using agents. If the obstacle's vertices are wound in clockwise order, avoidance agents will be pushed in by the obstacle, otherwise, avoidance agents will be pushed out. Obstacles using vertices and avoidance can warp to a new position but should not be moved every single frame as each change requires a rebuild of the avoidance map.</para>
/// </summary>
public partial class NavigationObstacle3D : Node3D
{
    /// <summary>
    /// <para>Sets the avoidance radius for the obstacle.</para>
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
    /// <para>Sets the obstacle height used in 2D avoidance. 2D avoidance using agent's ignore obstacles that are below or above them.</para>
    /// </summary>
    public float Height
    {
        get
        {
            return GetHeight();
        }
        set
        {
            SetHeight(value);
        }
    }

    /// <summary>
    /// <para>The outline vertices of the obstacle. If the vertices are winded in clockwise order agents will be pushed in by the obstacle, else they will be pushed out. Outlines can not be crossed or overlap. Should the vertices using obstacle be warped to a new position agent's can not predict this movement and may get trapped inside the obstacle.</para>
    /// </summary>
    public Vector3[] Vertices
    {
        get
        {
            return GetVertices();
        }
        set
        {
            SetVertices(value);
        }
    }

    /// <summary>
    /// <para>If enabled and parsed in a navigation mesh baking process the obstacle will discard source geometry inside its <see cref="Godot.NavigationObstacle3D.Vertices"/> and <see cref="Godot.NavigationObstacle3D.Height"/> defined shape.</para>
    /// </summary>
    public bool AffectNavigationMesh
    {
        get
        {
            return GetAffectNavigationMesh();
        }
        set
        {
            SetAffectNavigationMesh(value);
        }
    }

    /// <summary>
    /// <para>If enabled the obstacle vertices will carve into the baked navigation mesh with the shape unaffected by additional offsets (e.g. agent radius).</para>
    /// <para>It will still be affected by further postprocessing of the baking process, like edge and polygon simplification.</para>
    /// <para>Requires <see cref="Godot.NavigationObstacle3D.AffectNavigationMesh"/> to be enabled.</para>
    /// </summary>
    public bool CarveNavigationMesh
    {
        get
        {
            return GetCarveNavigationMesh();
        }
        set
        {
            SetCarveNavigationMesh(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> the obstacle affects avoidance using agents.</para>
    /// </summary>
    public bool AvoidanceEnabled
    {
        get
        {
            return GetAvoidanceEnabled();
        }
        set
        {
            SetAvoidanceEnabled(value);
        }
    }

    /// <summary>
    /// <para>Sets the wanted velocity for the obstacle so other agent's can better predict the obstacle if it is moved with a velocity regularly (every frame) instead of warped to a new position. Does only affect avoidance for the obstacles <see cref="Godot.NavigationObstacle3D.Radius"/>. Does nothing for the obstacles static vertices.</para>
    /// </summary>
    public Vector3 Velocity
    {
        get
        {
            return GetVelocity();
        }
        set
        {
            SetVelocity(value);
        }
    }

    /// <summary>
    /// <para>A bitfield determining the avoidance layers for this obstacle. Agents with a matching bit on the their avoidance mask will avoid this obstacle.</para>
    /// </summary>
    public uint AvoidanceLayers
    {
        get
        {
            return GetAvoidanceLayers();
        }
        set
        {
            SetAvoidanceLayers(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> the obstacle affects 3D avoidance using agent's with obstacle <see cref="Godot.NavigationObstacle3D.Radius"/>.</para>
    /// <para>If <see langword="false"/> the obstacle affects 2D avoidance using agent's with both obstacle <see cref="Godot.NavigationObstacle3D.Vertices"/> as well as obstacle <see cref="Godot.NavigationObstacle3D.Radius"/>.</para>
    /// </summary>
    public bool Use3DAvoidance
    {
        get
        {
            return GetUse3DAvoidance();
        }
        set
        {
            SetUse3DAvoidance(value);
        }
    }

    private static readonly System.Type CachedType = typeof(NavigationObstacle3D);

    private static readonly StringName NativeName = "NavigationObstacle3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public NavigationObstacle3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal NavigationObstacle3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal NavigationObstacle3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of this obstacle on the <see cref="Godot.NavigationServer3D"/>.</para>
    /// </summary>
    public Rid GetRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAvoidanceEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAvoidanceEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind1, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAvoidanceEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAvoidanceEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationMap, 2722037293ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Rid"/> of the navigation map this NavigationObstacle node should use and also updates the <c>obstacle</c> on the NavigationServer.</para>
    /// </summary>
    public void SetNavigationMap(Rid navigationMap)
    {
        NativeCalls.godot_icall_1_286(MethodBind3, GodotObject.GetPtr(this), navigationMap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationMap, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the navigation map for this NavigationObstacle node. This function returns always the map set on the NavigationObstacle node and not the map of the abstract obstacle on the NavigationServer. If the obstacle map is changed directly with the NavigationServer API the NavigationObstacle node will not be aware of the map change. Use <see cref="Godot.NavigationObstacle3D.SetNavigationMap(Rid)"/> to change the navigation map for the NavigationObstacle and also update the obstacle on the NavigationServer.</para>
    /// </summary>
    public Rid GetNavigationMap()
    {
        return NativeCalls.godot_icall_0_238(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind5, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeight, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHeight(float height)
    {
        NativeCalls.godot_icall_1_67(MethodBind7, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeight, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVelocity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetVelocity(Vector3 velocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind9, GodotObject.GetPtr(this), &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertices, 334873810ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertices(Vector3[] vertices)
    {
        NativeCalls.godot_icall_1_187(MethodBind11, GodotObject.GetPtr(this), vertices);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertices(ReadOnlySpan<Vector3> vertices)
    {
        NativeCalls.godot_icall_1_187(MethodBind11, GodotObject.GetPtr(this), vertices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertices, 497664490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3[] GetVertices()
    {
        return NativeCalls.godot_icall_0_228(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAvoidanceLayers, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAvoidanceLayers(uint layers)
    {
        NativeCalls.godot_icall_1_208(MethodBind13, GodotObject.GetPtr(this), layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAvoidanceLayers, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetAvoidanceLayers()
    {
        return NativeCalls.godot_icall_0_209(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAvoidanceLayerValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.NavigationObstacle3D.AvoidanceLayers"/> bitmask, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetAvoidanceLayerValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind15, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAvoidanceLayerValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.NavigationObstacle3D.AvoidanceLayers"/> bitmask is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetAvoidanceLayerValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind16, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUse3DAvoidance, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUse3DAvoidance(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUse3DAvoidance, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUse3DAvoidance()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAffectNavigationMesh, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAffectNavigationMesh(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAffectNavigationMesh, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAffectNavigationMesh()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCarveNavigationMesh, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCarveNavigationMesh(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind21, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCarveNavigationMesh, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetCarveNavigationMesh()
    {
        return NativeCalls.godot_icall_0_15(MethodBind22, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'radius' property.
        /// </summary>
        public static readonly StringName Radius = "radius";
        /// <summary>
        /// Cached name for the 'height' property.
        /// </summary>
        public static readonly StringName Height = "height";
        /// <summary>
        /// Cached name for the 'vertices' property.
        /// </summary>
        public static readonly StringName Vertices = "vertices";
        /// <summary>
        /// Cached name for the 'affect_navigation_mesh' property.
        /// </summary>
        public static readonly StringName AffectNavigationMesh = "affect_navigation_mesh";
        /// <summary>
        /// Cached name for the 'carve_navigation_mesh' property.
        /// </summary>
        public static readonly StringName CarveNavigationMesh = "carve_navigation_mesh";
        /// <summary>
        /// Cached name for the 'avoidance_enabled' property.
        /// </summary>
        public static readonly StringName AvoidanceEnabled = "avoidance_enabled";
        /// <summary>
        /// Cached name for the 'velocity' property.
        /// </summary>
        public static readonly StringName Velocity = "velocity";
        /// <summary>
        /// Cached name for the 'avoidance_layers' property.
        /// </summary>
        public static readonly StringName AvoidanceLayers = "avoidance_layers";
        /// <summary>
        /// Cached name for the 'use_3d_avoidance' property.
        /// </summary>
        public static readonly StringName Use3DAvoidance = "use_3d_avoidance";
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
        /// Cached name for the 'set_avoidance_enabled' method.
        /// </summary>
        public static readonly StringName SetAvoidanceEnabled = "set_avoidance_enabled";
        /// <summary>
        /// Cached name for the 'get_avoidance_enabled' method.
        /// </summary>
        public static readonly StringName GetAvoidanceEnabled = "get_avoidance_enabled";
        /// <summary>
        /// Cached name for the 'set_navigation_map' method.
        /// </summary>
        public static readonly StringName SetNavigationMap = "set_navigation_map";
        /// <summary>
        /// Cached name for the 'get_navigation_map' method.
        /// </summary>
        public static readonly StringName GetNavigationMap = "get_navigation_map";
        /// <summary>
        /// Cached name for the 'set_radius' method.
        /// </summary>
        public static readonly StringName SetRadius = "set_radius";
        /// <summary>
        /// Cached name for the 'get_radius' method.
        /// </summary>
        public static readonly StringName GetRadius = "get_radius";
        /// <summary>
        /// Cached name for the 'set_height' method.
        /// </summary>
        public static readonly StringName SetHeight = "set_height";
        /// <summary>
        /// Cached name for the 'get_height' method.
        /// </summary>
        public static readonly StringName GetHeight = "get_height";
        /// <summary>
        /// Cached name for the 'set_velocity' method.
        /// </summary>
        public static readonly StringName SetVelocity = "set_velocity";
        /// <summary>
        /// Cached name for the 'get_velocity' method.
        /// </summary>
        public static readonly StringName GetVelocity = "get_velocity";
        /// <summary>
        /// Cached name for the 'set_vertices' method.
        /// </summary>
        public static readonly StringName SetVertices = "set_vertices";
        /// <summary>
        /// Cached name for the 'get_vertices' method.
        /// </summary>
        public static readonly StringName GetVertices = "get_vertices";
        /// <summary>
        /// Cached name for the 'set_avoidance_layers' method.
        /// </summary>
        public static readonly StringName SetAvoidanceLayers = "set_avoidance_layers";
        /// <summary>
        /// Cached name for the 'get_avoidance_layers' method.
        /// </summary>
        public static readonly StringName GetAvoidanceLayers = "get_avoidance_layers";
        /// <summary>
        /// Cached name for the 'set_avoidance_layer_value' method.
        /// </summary>
        public static readonly StringName SetAvoidanceLayerValue = "set_avoidance_layer_value";
        /// <summary>
        /// Cached name for the 'get_avoidance_layer_value' method.
        /// </summary>
        public static readonly StringName GetAvoidanceLayerValue = "get_avoidance_layer_value";
        /// <summary>
        /// Cached name for the 'set_use_3d_avoidance' method.
        /// </summary>
        public static readonly StringName SetUse3DAvoidance = "set_use_3d_avoidance";
        /// <summary>
        /// Cached name for the 'get_use_3d_avoidance' method.
        /// </summary>
        public static readonly StringName GetUse3DAvoidance = "get_use_3d_avoidance";
        /// <summary>
        /// Cached name for the 'set_affect_navigation_mesh' method.
        /// </summary>
        public static readonly StringName SetAffectNavigationMesh = "set_affect_navigation_mesh";
        /// <summary>
        /// Cached name for the 'get_affect_navigation_mesh' method.
        /// </summary>
        public static readonly StringName GetAffectNavigationMesh = "get_affect_navigation_mesh";
        /// <summary>
        /// Cached name for the 'set_carve_navigation_mesh' method.
        /// </summary>
        public static readonly StringName SetCarveNavigationMesh = "set_carve_navigation_mesh";
        /// <summary>
        /// Cached name for the 'get_carve_navigation_mesh' method.
        /// </summary>
        public static readonly StringName GetCarveNavigationMesh = "get_carve_navigation_mesh";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
