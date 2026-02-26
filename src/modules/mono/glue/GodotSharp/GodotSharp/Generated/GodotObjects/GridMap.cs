namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>GridMap lets you place meshes on a grid interactively. It works both from the editor and from scripts, which can help you create in-game level editors.</para>
/// <para>GridMaps use a <see cref="Godot.MeshLibrary"/> which contains a list of tiles. Each tile is a mesh with materials plus optional collision and navigation shapes.</para>
/// <para>A GridMap contains a collection of cells. Each grid cell refers to a tile in the <see cref="Godot.MeshLibrary"/>. All cells in the map have the same dimensions.</para>
/// <para>Internally, a GridMap is split into a sparse collection of octants for efficient rendering and physics processing. Every octant has the same dimensions and can contain several cells.</para>
/// <para><b>Note:</b> GridMap doesn't extend <see cref="Godot.VisualInstance3D"/> and therefore can't be hidden or cull masked based on <see cref="Godot.VisualInstance3D.Layers"/>. If you make a light not affect the first layer, the whole GridMap won't be lit by the light in question.</para>
/// </summary>
public partial class GridMap : Node3D
{
    /// <summary>
    /// <para>Invalid cell item that can be used in <see cref="Godot.GridMap.SetCellItem(Vector3I, int, int)"/> to clear cells (or represent an empty cell in <see cref="Godot.GridMap.GetCellItem(Vector3I)"/>).</para>
    /// </summary>
    public const long InvalidCellItem = -1;

    /// <summary>
    /// <para>The assigned <see cref="Godot.MeshLibrary"/>.</para>
    /// </summary>
    public MeshLibrary MeshLibrary
    {
        get
        {
            return GetMeshLibrary();
        }
        set
        {
            SetMeshLibrary(value);
        }
    }

    /// <summary>
    /// <para>Overrides the default friction and bounce physics properties for the whole <see cref="Godot.GridMap"/>.</para>
    /// </summary>
    public PhysicsMaterial PhysicsMaterial
    {
        get
        {
            return GetPhysicsMaterial();
        }
        set
        {
            SetPhysicsMaterial(value);
        }
    }

    /// <summary>
    /// <para>The dimensions of the grid's cells.</para>
    /// <para>This does not affect the size of the meshes. See <see cref="Godot.GridMap.CellScale"/>.</para>
    /// </summary>
    public Vector3 CellSize
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
    /// <para>The size of each octant measured in number of cells. This applies to all three axis.</para>
    /// </summary>
    public int CellOctantSize
    {
        get
        {
            return GetOctantSize();
        }
        set
        {
            SetOctantSize(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, grid items are centered on the X axis.</para>
    /// </summary>
    public bool CellCenterX
    {
        get
        {
            return GetCenterX();
        }
        set
        {
            SetCenterX(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, grid items are centered on the Y axis.</para>
    /// </summary>
    public bool CellCenterY
    {
        get
        {
            return GetCenterY();
        }
        set
        {
            SetCenterY(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, grid items are centered on the Z axis.</para>
    /// </summary>
    public bool CellCenterZ
    {
        get
        {
            return GetCenterZ();
        }
        set
        {
            SetCenterZ(value);
        }
    }

    /// <summary>
    /// <para>The scale of the cell items.</para>
    /// <para>This does not affect the size of the grid cells themselves, only the items in them. This can be used to make cell items overlap their neighbors.</para>
    /// </summary>
    public float CellScale
    {
        get
        {
            return GetCellScale();
        }
        set
        {
            SetCellScale(value);
        }
    }

    /// <summary>
    /// <para>The physics layers this GridMap is in.</para>
    /// <para>GridMaps act as static bodies, meaning they aren't affected by gravity or other forces. They only affect other physics bodies that collide with them.</para>
    /// </summary>
    public uint CollisionLayer
    {
        get
        {
            return GetCollisionLayer();
        }
        set
        {
            SetCollisionLayer(value);
        }
    }

    /// <summary>
    /// <para>The physics layers this GridMap detects collisions in. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionMask
    {
        get
        {
            return GetCollisionMask();
        }
        set
        {
            SetCollisionMask(value);
        }
    }

    /// <summary>
    /// <para>The priority used to solve colliding when occurring penetration. The higher the priority is, the lower the penetration into the object will be. This can for example be used to prevent the player from breaking through the boundaries of a level.</para>
    /// </summary>
    public float CollisionPriority
    {
        get
        {
            return GetCollisionPriority();
        }
        set
        {
            SetCollisionPriority(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this GridMap creates a navigation region for each cell that uses a <see cref="Godot.GridMap.MeshLibrary"/> item with a navigation mesh. The created navigation region will use the navigation layers bitmask assigned to the <see cref="Godot.MeshLibrary"/>'s item.</para>
    /// </summary>
    public bool BakeNavigation
    {
        get
        {
            return IsBakingNavigation();
        }
        set
        {
            SetBakeNavigation(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GridMap);

    private static readonly StringName NativeName = "GridMap";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GridMap() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GridMap(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GridMap(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayer, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionLayer(uint layer)
    {
        NativeCalls.godot_icall_1_208(MethodBind0, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayer, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionLayer()
    {
        return NativeCalls.godot_icall_0_209(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind2, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.GridMap.CollisionMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind4, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.GridMap.CollisionMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind5, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayerValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.GridMap.CollisionLayer"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionLayerValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayerValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.GridMap.CollisionLayer"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionLayerValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind7, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionPriority, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionPriority(float priority)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionPriority, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCollisionPriority()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsMaterial, 1784508650ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicsMaterial(PhysicsMaterial material)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsMaterial, 2521850424ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public PhysicsMaterial GetPhysicsMaterial()
    {
        return (PhysicsMaterial)NativeCalls.godot_icall_0_63(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakeNavigation, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBakeNavigation(bool bakeNavigation)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), bakeNavigation.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBakingNavigation, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsBakingNavigation()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationMap, 2722037293ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Rid"/> of the navigation map this GridMap node should use for its cell baked navigation meshes.</para>
    /// </summary>
    public void SetNavigationMap(Rid navigationMap)
    {
        NativeCalls.godot_icall_1_286(MethodBind14, GodotObject.GetPtr(this), navigationMap);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationMap, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the navigation map this GridMap node uses for its cell baked navigation meshes.</para>
    /// <para>This function returns always the map set on the GridMap node and not the map on the NavigationServer. If the map is changed directly with the NavigationServer API the GridMap node will not be aware of the map change.</para>
    /// </summary>
    public Rid GetNavigationMap()
    {
        return NativeCalls.godot_icall_0_238(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMeshLibrary, 1488083439ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMeshLibrary(MeshLibrary meshLibrary)
    {
        NativeCalls.godot_icall_1_56(MethodBind16, GodotObject.GetPtr(this), GodotObject.GetPtr(meshLibrary));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMeshLibrary, 3350993772ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MeshLibrary GetMeshLibrary()
    {
        return (MeshLibrary)NativeCalls.godot_icall_0_63(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellSize, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCellSize(Vector3 size)
    {
        NativeCalls.godot_icall_1_177(MethodBind18, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellSize, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetCellSize()
    {
        return NativeCalls.godot_icall_0_125(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCellScale(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCellScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOctantSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOctantSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind22, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOctantSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOctantSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellItem, 3449088946ul);

    /// <summary>
    /// <para>Sets the mesh index for the cell referenced by its grid coordinates.</para>
    /// <para>A negative item index such as <see cref="Godot.GridMap.InvalidCellItem"/> will clear the cell.</para>
    /// <para>Optionally, the item's orientation can be passed. For valid orientation values, see <see cref="Godot.GridMap.GetOrthogonalIndexFromBasis(Basis)"/>.</para>
    /// </summary>
    public unsafe void SetCellItem(Vector3I position, int item, int orientation = 0)
    {
        NativeCalls.godot_icall_3_703(MethodBind24, GodotObject.GetPtr(this), &position, item, orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellItem, 3724960147ul);

    /// <summary>
    /// <para>The <see cref="Godot.MeshLibrary"/> item index located at the given grid coordinates. If the cell is empty, <see cref="Godot.GridMap.InvalidCellItem"/> will be returned.</para>
    /// </summary>
    public unsafe int GetCellItem(Vector3I position)
    {
        return NativeCalls.godot_icall_1_704(MethodBind25, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellItemOrientation, 3724960147ul);

    /// <summary>
    /// <para>The orientation of the cell at the given grid coordinates. <c>-1</c> is returned if the cell is empty.</para>
    /// </summary>
    public unsafe int GetCellItemOrientation(Vector3I position)
    {
        return NativeCalls.godot_icall_1_704(MethodBind26, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellItemBasis, 3493604918ul);

    /// <summary>
    /// <para>Returns the basis that gives the specified cell its orientation.</para>
    /// </summary>
    public unsafe Basis GetCellItemBasis(Vector3I position)
    {
        return NativeCalls.godot_icall_1_705(MethodBind27, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBasisWithOrthogonalIndex, 2816196998ul);

    /// <summary>
    /// <para>Returns one of 24 possible rotations that lie along the vectors (x,y,z) with each component being either -1, 0, or 1. For further details, refer to the Godot source code.</para>
    /// </summary>
    public Basis GetBasisWithOrthogonalIndex(int index)
    {
        return NativeCalls.godot_icall_1_706(MethodBind28, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOrthogonalIndexFromBasis, 4210359952ul);

    /// <summary>
    /// <para>This function considers a discretization of rotations into 24 points on unit sphere, lying along the vectors (x,y,z) with each component being either -1, 0, or 1, and returns the index (in the range from 0 to 23) of the point best representing the orientation of the object. For further details, refer to the Godot source code.</para>
    /// </summary>
    public unsafe int GetOrthogonalIndexFromBasis(Basis basis)
    {
        return NativeCalls.godot_icall_1_707(MethodBind29, GodotObject.GetPtr(this), &basis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LocalToMap, 1257687843ul);

    /// <summary>
    /// <para>Returns the map coordinates of the cell containing the given <paramref name="localPosition"/>. If <paramref name="localPosition"/> is in global coordinates, consider using <see cref="Godot.Node3D.ToLocal(Vector3)"/> before passing it to this method. See also <see cref="Godot.GridMap.MapToLocal(Vector3I)"/>.</para>
    /// </summary>
    public unsafe Vector3I LocalToMap(Vector3 localPosition)
    {
        return NativeCalls.godot_icall_1_708(MethodBind30, GodotObject.GetPtr(this), &localPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MapToLocal, 1088329196ul);

    /// <summary>
    /// <para>Returns the position of a grid cell in the GridMap's local coordinate space. To convert the returned value into global coordinates, use <see cref="Godot.Node3D.ToGlobal(Vector3)"/>. See also <see cref="Godot.GridMap.LocalToMap(Vector3)"/>.</para>
    /// </summary>
    public unsafe Vector3 MapToLocal(Vector3I mapPosition)
    {
        return NativeCalls.godot_icall_1_709(MethodBind31, GodotObject.GetPtr(this), &mapPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResourceChanged, 968641751ul);

    /// <summary>
    /// <para>This method does nothing.</para>
    /// </summary>
    [Obsolete("Use 'Godot.Resource.Changed' instead.")]
    public void ResourceChanged(Resource resource)
    {
        NativeCalls.godot_icall_1_56(MethodBind32, GodotObject.GetPtr(this), GodotObject.GetPtr(resource));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterX, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCenterX(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind33, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterX, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetCenterX()
    {
        return NativeCalls.godot_icall_0_15(MethodBind34, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterY, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCenterY(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind35, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterY, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetCenterY()
    {
        return NativeCalls.godot_icall_0_15(MethodBind36, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterZ, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCenterZ(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind37, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterZ, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetCenterZ()
    {
        return NativeCalls.godot_icall_0_15(MethodBind38, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clear all cells.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUsedCells, 3995934104ul);

    /// <summary>
    /// <para>Returns an array of <see cref="Godot.Vector3"/> with the non-empty cell coordinates in the grid map.</para>
    /// </summary>
    public Godot.Collections.Array<Vector3I> GetUsedCells()
    {
        return new Godot.Collections.Array<Vector3I>(NativeCalls.godot_icall_0_120(MethodBind40, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUsedCellsByItem, 663333327ul);

    /// <summary>
    /// <para>Returns an array of all cells with the given item index specified in <paramref name="item"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Vector3I> GetUsedCellsByItem(int item)
    {
        return new Godot.Collections.Array<Vector3I>(NativeCalls.godot_icall_1_457(MethodBind41, GodotObject.GetPtr(this), item));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMeshes, 3995934104ul);

    /// <summary>
    /// <para>Returns an array of <see cref="Godot.Transform3D"/> and <see cref="Godot.Mesh"/> references corresponding to the non-empty cells in the grid. The transforms are specified in local space. Even indices contain <see cref="Godot.Transform3D"/>s, while odd indices contain <see cref="Godot.Mesh"/>es related to the <see cref="Godot.Transform3D"/> in the index preceding it.</para>
    /// </summary>
    public Godot.Collections.Array GetMeshes()
    {
        return NativeCalls.godot_icall_0_120(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeMeshes, 2915620761ul);

    /// <summary>
    /// <para>Returns an array of <see cref="Godot.ArrayMesh"/>es and <see cref="Godot.Transform3D"/> references of all bake meshes that exist within the current GridMap. Even indices contain <see cref="Godot.ArrayMesh"/>es, while odd indices contain <see cref="Godot.Transform3D"/>s that are always equal to <c>Transform3D.IDENTITY</c>.</para>
    /// <para>This method relies on the output of <see cref="Godot.GridMap.MakeBakedMeshes(bool, float)"/>, which will be called with <c>gen_lightmap_uv</c> set to <see langword="true"/> and <c>lightmap_uv_texel_size</c> set to <c>0.1</c> if it hasn't been called yet.</para>
    /// </summary>
    public Godot.Collections.Array GetBakeMeshes()
    {
        return NativeCalls.godot_icall_0_120(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeMeshInstance, 937000113ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.Rid"/> of a baked mesh with the given <paramref name="idx"/>.</para>
    /// </summary>
    public Rid GetBakeMeshInstance(int idx)
    {
        return NativeCalls.godot_icall_1_425(MethodBind44, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearBakedMeshes, 3218959716ul);

    /// <summary>
    /// <para>Clears all baked meshes. See <see cref="Godot.GridMap.MakeBakedMeshes(bool, float)"/>.</para>
    /// </summary>
    public void ClearBakedMeshes()
    {
        NativeCalls.godot_icall_0_3(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeBakedMeshes, 3609286057ul);

    /// <summary>
    /// <para>Generates a baked mesh that represents all meshes in the assigned <see cref="Godot.MeshLibrary"/> for use with <see cref="Godot.LightmapGI"/>. If <paramref name="genLightmapUV"/> is <see langword="true"/>, UV2 data will be generated for each mesh currently used in the <see cref="Godot.GridMap"/>. Otherwise, only meshes that already have UV2 data present will be able to use baked lightmaps. When generating UV2, <paramref name="lightmapUVTexelSize"/> controls the texel density for lightmaps, with lower values resulting in more detailed lightmaps. <paramref name="lightmapUVTexelSize"/> is ignored if <paramref name="genLightmapUV"/> is <see langword="false"/>. See also <see cref="Godot.GridMap.GetBakeMeshes()"/>, which relies on the output of this method.</para>
    /// <para><b>Note:</b> Calling this method will not actually bake lightmaps, as lightmap baking is performed using the <see cref="Godot.LightmapGI"/> node.</para>
    /// </summary>
    public void MakeBakedMeshes(bool genLightmapUV = false, float lightmapUVTexelSize = 0.1f)
    {
        NativeCalls.godot_icall_2_710(MethodBind46, GodotObject.GetPtr(this), genLightmapUV.ToGodotBool(), lightmapUVTexelSize);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GridMap.CellSizeChanged"/> event of a <see cref="Godot.GridMap"/> class.
    /// </summary>
    public delegate void CellSizeChangedEventHandler(Vector3 cellSize);

    private static void CellSizeChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((CellSizeChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Vector3>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.GridMap.CellSize"/> changes.</para>
    /// </summary>
    public unsafe event CellSizeChangedEventHandler CellSizeChanged
    {
        add => Connect(SignalName.CellSizeChanged, Callable.CreateWithUnsafeTrampoline(value, &CellSizeChangedTrampoline));
        remove => Disconnect(SignalName.CellSizeChanged, Callable.CreateWithUnsafeTrampoline(value, &CellSizeChangedTrampoline));
    }

    protected void EmitSignalCellSizeChanged(Vector3 cellSize)
    {
        EmitSignal(SignalName.CellSizeChanged, cellSize);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.MeshLibrary"/> of this GridMap changes.</para>
    /// </summary>
    public event Action Changed
    {
        add => Connect(SignalName.Changed, Callable.From(value));
        remove => Disconnect(SignalName.Changed, Callable.From(value));
    }

    protected void EmitSignalChanged()
    {
        EmitSignal(SignalName.Changed);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_cell_size_changed = "CellSizeChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_changed = "Changed";

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
        if (signal == SignalName.CellSizeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_cell_size_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Changed)
        {
            if (HasGodotClassSignal(SignalProxyName_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'mesh_library' property.
        /// </summary>
        public static readonly StringName MeshLibrary = "mesh_library";
        /// <summary>
        /// Cached name for the 'physics_material' property.
        /// </summary>
        public static readonly StringName PhysicsMaterial = "physics_material";
        /// <summary>
        /// Cached name for the 'cell_size' property.
        /// </summary>
        public static readonly StringName CellSize = "cell_size";
        /// <summary>
        /// Cached name for the 'cell_octant_size' property.
        /// </summary>
        public static readonly StringName CellOctantSize = "cell_octant_size";
        /// <summary>
        /// Cached name for the 'cell_center_x' property.
        /// </summary>
        public static readonly StringName CellCenterX = "cell_center_x";
        /// <summary>
        /// Cached name for the 'cell_center_y' property.
        /// </summary>
        public static readonly StringName CellCenterY = "cell_center_y";
        /// <summary>
        /// Cached name for the 'cell_center_z' property.
        /// </summary>
        public static readonly StringName CellCenterZ = "cell_center_z";
        /// <summary>
        /// Cached name for the 'cell_scale' property.
        /// </summary>
        public static readonly StringName CellScale = "cell_scale";
        /// <summary>
        /// Cached name for the 'collision_layer' property.
        /// </summary>
        public static readonly StringName CollisionLayer = "collision_layer";
        /// <summary>
        /// Cached name for the 'collision_mask' property.
        /// </summary>
        public static readonly StringName CollisionMask = "collision_mask";
        /// <summary>
        /// Cached name for the 'collision_priority' property.
        /// </summary>
        public static readonly StringName CollisionPriority = "collision_priority";
        /// <summary>
        /// Cached name for the 'bake_navigation' property.
        /// </summary>
        public static readonly StringName BakeNavigation = "bake_navigation";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_collision_layer' method.
        /// </summary>
        public static readonly StringName SetCollisionLayer = "set_collision_layer";
        /// <summary>
        /// Cached name for the 'get_collision_layer' method.
        /// </summary>
        public static readonly StringName GetCollisionLayer = "get_collision_layer";
        /// <summary>
        /// Cached name for the 'set_collision_mask' method.
        /// </summary>
        public static readonly StringName SetCollisionMask = "set_collision_mask";
        /// <summary>
        /// Cached name for the 'get_collision_mask' method.
        /// </summary>
        public static readonly StringName GetCollisionMask = "get_collision_mask";
        /// <summary>
        /// Cached name for the 'set_collision_mask_value' method.
        /// </summary>
        public static readonly StringName SetCollisionMaskValue = "set_collision_mask_value";
        /// <summary>
        /// Cached name for the 'get_collision_mask_value' method.
        /// </summary>
        public static readonly StringName GetCollisionMaskValue = "get_collision_mask_value";
        /// <summary>
        /// Cached name for the 'set_collision_layer_value' method.
        /// </summary>
        public static readonly StringName SetCollisionLayerValue = "set_collision_layer_value";
        /// <summary>
        /// Cached name for the 'get_collision_layer_value' method.
        /// </summary>
        public static readonly StringName GetCollisionLayerValue = "get_collision_layer_value";
        /// <summary>
        /// Cached name for the 'set_collision_priority' method.
        /// </summary>
        public static readonly StringName SetCollisionPriority = "set_collision_priority";
        /// <summary>
        /// Cached name for the 'get_collision_priority' method.
        /// </summary>
        public static readonly StringName GetCollisionPriority = "get_collision_priority";
        /// <summary>
        /// Cached name for the 'set_physics_material' method.
        /// </summary>
        public static readonly StringName SetPhysicsMaterial = "set_physics_material";
        /// <summary>
        /// Cached name for the 'get_physics_material' method.
        /// </summary>
        public static readonly StringName GetPhysicsMaterial = "get_physics_material";
        /// <summary>
        /// Cached name for the 'set_bake_navigation' method.
        /// </summary>
        public static readonly StringName SetBakeNavigation = "set_bake_navigation";
        /// <summary>
        /// Cached name for the 'is_baking_navigation' method.
        /// </summary>
        public static readonly StringName IsBakingNavigation = "is_baking_navigation";
        /// <summary>
        /// Cached name for the 'set_navigation_map' method.
        /// </summary>
        public static readonly StringName SetNavigationMap = "set_navigation_map";
        /// <summary>
        /// Cached name for the 'get_navigation_map' method.
        /// </summary>
        public static readonly StringName GetNavigationMap = "get_navigation_map";
        /// <summary>
        /// Cached name for the 'set_mesh_library' method.
        /// </summary>
        public static readonly StringName SetMeshLibrary = "set_mesh_library";
        /// <summary>
        /// Cached name for the 'get_mesh_library' method.
        /// </summary>
        public static readonly StringName GetMeshLibrary = "get_mesh_library";
        /// <summary>
        /// Cached name for the 'set_cell_size' method.
        /// </summary>
        public static readonly StringName SetCellSize = "set_cell_size";
        /// <summary>
        /// Cached name for the 'get_cell_size' method.
        /// </summary>
        public static readonly StringName GetCellSize = "get_cell_size";
        /// <summary>
        /// Cached name for the 'set_cell_scale' method.
        /// </summary>
        public static readonly StringName SetCellScale = "set_cell_scale";
        /// <summary>
        /// Cached name for the 'get_cell_scale' method.
        /// </summary>
        public static readonly StringName GetCellScale = "get_cell_scale";
        /// <summary>
        /// Cached name for the 'set_octant_size' method.
        /// </summary>
        public static readonly StringName SetOctantSize = "set_octant_size";
        /// <summary>
        /// Cached name for the 'get_octant_size' method.
        /// </summary>
        public static readonly StringName GetOctantSize = "get_octant_size";
        /// <summary>
        /// Cached name for the 'set_cell_item' method.
        /// </summary>
        public static readonly StringName SetCellItem = "set_cell_item";
        /// <summary>
        /// Cached name for the 'get_cell_item' method.
        /// </summary>
        public static readonly StringName GetCellItem = "get_cell_item";
        /// <summary>
        /// Cached name for the 'get_cell_item_orientation' method.
        /// </summary>
        public static readonly StringName GetCellItemOrientation = "get_cell_item_orientation";
        /// <summary>
        /// Cached name for the 'get_cell_item_basis' method.
        /// </summary>
        public static readonly StringName GetCellItemBasis = "get_cell_item_basis";
        /// <summary>
        /// Cached name for the 'get_basis_with_orthogonal_index' method.
        /// </summary>
        public static readonly StringName GetBasisWithOrthogonalIndex = "get_basis_with_orthogonal_index";
        /// <summary>
        /// Cached name for the 'get_orthogonal_index_from_basis' method.
        /// </summary>
        public static readonly StringName GetOrthogonalIndexFromBasis = "get_orthogonal_index_from_basis";
        /// <summary>
        /// Cached name for the 'local_to_map' method.
        /// </summary>
        public static readonly StringName LocalToMap = "local_to_map";
        /// <summary>
        /// Cached name for the 'map_to_local' method.
        /// </summary>
        public static readonly StringName MapToLocal = "map_to_local";
        /// <summary>
        /// Cached name for the 'resource_changed' method.
        /// </summary>
        public static readonly StringName ResourceChanged = "resource_changed";
        /// <summary>
        /// Cached name for the 'set_center_x' method.
        /// </summary>
        public static readonly StringName SetCenterX = "set_center_x";
        /// <summary>
        /// Cached name for the 'get_center_x' method.
        /// </summary>
        public static readonly StringName GetCenterX = "get_center_x";
        /// <summary>
        /// Cached name for the 'set_center_y' method.
        /// </summary>
        public static readonly StringName SetCenterY = "set_center_y";
        /// <summary>
        /// Cached name for the 'get_center_y' method.
        /// </summary>
        public static readonly StringName GetCenterY = "get_center_y";
        /// <summary>
        /// Cached name for the 'set_center_z' method.
        /// </summary>
        public static readonly StringName SetCenterZ = "set_center_z";
        /// <summary>
        /// Cached name for the 'get_center_z' method.
        /// </summary>
        public static readonly StringName GetCenterZ = "get_center_z";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'get_used_cells' method.
        /// </summary>
        public static readonly StringName GetUsedCells = "get_used_cells";
        /// <summary>
        /// Cached name for the 'get_used_cells_by_item' method.
        /// </summary>
        public static readonly StringName GetUsedCellsByItem = "get_used_cells_by_item";
        /// <summary>
        /// Cached name for the 'get_meshes' method.
        /// </summary>
        public static readonly StringName GetMeshes = "get_meshes";
        /// <summary>
        /// Cached name for the 'get_bake_meshes' method.
        /// </summary>
        public static readonly StringName GetBakeMeshes = "get_bake_meshes";
        /// <summary>
        /// Cached name for the 'get_bake_mesh_instance' method.
        /// </summary>
        public static readonly StringName GetBakeMeshInstance = "get_bake_mesh_instance";
        /// <summary>
        /// Cached name for the 'clear_baked_meshes' method.
        /// </summary>
        public static readonly StringName ClearBakedMeshes = "clear_baked_meshes";
        /// <summary>
        /// Cached name for the 'make_baked_meshes' method.
        /// </summary>
        public static readonly StringName MakeBakedMeshes = "make_baked_meshes";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'cell_size_changed' signal.
        /// </summary>
        public static readonly StringName CellSizeChanged = "cell_size_changed";
        /// <summary>
        /// Cached name for the 'changed' signal.
        /// </summary>
        public static readonly StringName Changed = "changed";
    }
}
