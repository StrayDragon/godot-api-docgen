namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Gizmo that is used for providing custom visualization and editing (handles and subgizmos) for <see cref="Godot.Node3D"/> objects. Can be overridden to create custom gizmos, but for simple gizmos creating an <see cref="Godot.EditorNode3DGizmoPlugin"/> is usually recommended.</para>
/// </summary>
public partial class EditorNode3DGizmo : Node3DGizmo
{
    private static readonly System.Type CachedType = typeof(EditorNode3DGizmo);

    private static readonly StringName NativeName = "EditorNode3DGizmo";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorNode3DGizmo() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorNode3DGizmo(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorNode3DGizmo(bool memoryOwn) : base(memoryOwn) { }

    public virtual void _BeginHandleAction(int id, bool secondary)
    {
    }

    /// <summary>
    /// <para>Override this method to commit a handle being edited (handles must have been previously added by <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/>). This usually means creating an <see cref="Godot.UndoRedo"/> action for the change, using the current handle value as "do" and the <paramref name="restore"/> argument as "undo".</para>
    /// <para>If the <paramref name="cancel"/> argument is <see langword="true"/>, the <paramref name="restore"/> value should be directly set, without any <see cref="Godot.UndoRedo"/> action.</para>
    /// <para>The <paramref name="secondary"/> argument is <see langword="true"/> when the committed handle is secondary (see <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> for more information).</para>
    /// </summary>
    public virtual void _CommitHandle(int id, bool secondary, Variant restore, bool cancel)
    {
    }

    /// <summary>
    /// <para>Override this method to commit a group of subgizmos being edited (see <see cref="Godot.EditorNode3DGizmo._SubgizmosIntersectRay(Camera3D, Vector2)"/> and <see cref="Godot.EditorNode3DGizmo._SubgizmosIntersectFrustum(Camera3D, Godot.Collections.Array{Plane})"/>). This usually means creating an <see cref="Godot.UndoRedo"/> action for the change, using the current transforms as "do" and the <paramref name="restores"/> transforms as "undo".</para>
    /// <para>If the <paramref name="cancel"/> argument is <see langword="true"/>, the <paramref name="restores"/> transforms should be directly set, without any <see cref="Godot.UndoRedo"/> action.</para>
    /// </summary>
    public virtual void _CommitSubgizmos(int[] ids, Godot.Collections.Array<Transform3D> restores, bool cancel)
    {
    }

    /// <summary>
    /// <para>Override this method to return the name of an edited handle (handles must have been previously added by <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/>). Handles can be named for reference to the user when editing.</para>
    /// <para>The <paramref name="secondary"/> argument is <see langword="true"/> when the requested handle is secondary (see <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> for more information).</para>
    /// </summary>
    public virtual string _GetHandleName(int id, bool secondary)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to return the current value of a handle. This value will be requested at the start of an edit and used as the <c>restore</c> argument in <see cref="Godot.EditorNode3DGizmo._CommitHandle(int, bool, Variant, bool)"/>.</para>
    /// <para>The <paramref name="secondary"/> argument is <see langword="true"/> when the requested handle is secondary (see <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> for more information).</para>
    /// </summary>
    public virtual Variant _GetHandleValue(int id, bool secondary)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to return the current transform of a subgizmo. This transform will be requested at the start of an edit and used as the <c>restore</c> argument in <see cref="Godot.EditorNode3DGizmo._CommitSubgizmos(int[], Godot.Collections.Array{Transform3D}, bool)"/>.</para>
    /// </summary>
    public virtual Transform3D _GetSubgizmoTransform(int id)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to return <see langword="true"/> whenever the given handle should be highlighted in the editor.</para>
    /// <para>The <paramref name="secondary"/> argument is <see langword="true"/> when the requested handle is secondary (see <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> for more information).</para>
    /// </summary>
    public virtual bool _IsHandleHighlighted(int id, bool secondary)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to add all the gizmo elements whenever a gizmo update is requested. It's common to call <see cref="Godot.EditorNode3DGizmo.Clear()"/> at the beginning of this method and then add visual elements depending on the node's properties.</para>
    /// </summary>
    public virtual void _Redraw()
    {
    }

    /// <summary>
    /// <para>Override this method to update the node properties when the user drags a gizmo handle (previously added with <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/>). The provided <paramref name="point"/> is the mouse position in screen coordinates and the <paramref name="camera"/> can be used to convert it to raycasts.</para>
    /// <para>The <paramref name="secondary"/> argument is <see langword="true"/> when the edited handle is secondary (see <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> for more information).</para>
    /// </summary>
    public virtual unsafe void _SetHandle(int id, bool secondary, Camera3D camera, Vector2 point)
    {
    }

    /// <summary>
    /// <para>Override this method to update the node properties during subgizmo editing (see <see cref="Godot.EditorNode3DGizmo._SubgizmosIntersectRay(Camera3D, Vector2)"/> and <see cref="Godot.EditorNode3DGizmo._SubgizmosIntersectFrustum(Camera3D, Godot.Collections.Array{Plane})"/>). The <paramref name="transform"/> is given in the <see cref="Godot.Node3D"/>'s local coordinate system.</para>
    /// </summary>
    public virtual unsafe void _SetSubgizmoTransform(int id, Transform3D transform)
    {
    }

    /// <summary>
    /// <para>Override this method to allow selecting subgizmos using mouse drag box selection. Given a <paramref name="camera"/> and a <paramref name="frustum"/>, this method should return which subgizmos are contained within the frustum. The <paramref name="frustum"/> argument consists of an array with all the <see cref="Godot.Plane"/>s that make up the selection frustum. The returned value should contain a list of unique subgizmo identifiers, which can have any non-negative value and will be used in other virtual methods like <see cref="Godot.EditorNode3DGizmo._GetSubgizmoTransform(int)"/> or <see cref="Godot.EditorNode3DGizmo._CommitSubgizmos(int[], Godot.Collections.Array{Transform3D}, bool)"/>.</para>
    /// </summary>
    public virtual int[] _SubgizmosIntersectFrustum(Camera3D camera, Godot.Collections.Array<Plane> frustum)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to allow selecting subgizmos using mouse clicks. Given a <paramref name="camera"/> and a <paramref name="point"/> in screen coordinates, this method should return which subgizmo should be selected. The returned value should be a unique subgizmo identifier, which can have any non-negative value and will be used in other virtual methods like <see cref="Godot.EditorNode3DGizmo._GetSubgizmoTransform(int)"/> or <see cref="Godot.EditorNode3DGizmo._CommitSubgizmos(int[], Godot.Collections.Array{Transform3D}, bool)"/>.</para>
    /// </summary>
    public virtual unsafe int _SubgizmosIntersectRay(Camera3D camera, Vector2 point)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddLines, 2910971437ul);

    /// <summary>
    /// <para>Adds lines to the gizmo (as sets of 2 points), with a given material. The lines are used for visualizing the gizmo. Call this method during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void AddLines(Vector3[] lines, Material material, bool billboard = false, Nullable<Color> modulate = null)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        EditorNativeCalls.godot_icall_4_510(MethodBind0, GodotObject.GetPtr(this), lines, GodotObject.GetPtr(material), billboard.ToGodotBool(), &modulateOrDefVal);
    }

    /// <summary>
    /// <para>Adds lines to the gizmo (as sets of 2 points), with a given material. The lines are used for visualizing the gizmo. Call this method during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void AddLines(ReadOnlySpan<Vector3> lines, Material material, bool billboard, Nullable<Color> modulate)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        EditorNativeCalls.godot_icall_4_510(MethodBind0, GodotObject.GetPtr(this), lines, GodotObject.GetPtr(material), billboard.ToGodotBool(), &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMesh, 1579955111ul);

    /// <summary>
    /// <para>Adds a mesh to the gizmo with the specified <paramref name="material"/>, local <paramref name="transform"/> and <paramref name="skeleton"/>. Call this method during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform3D.Identity</c>.</param>
    public unsafe void AddMesh(Mesh mesh, Material material = default, Nullable<Transform3D> transform = null, SkinReference skeleton = null)
    {
        Transform3D transformOrDefVal = transform.HasValue ? transform.Value : Transform3D.Identity;
        EditorNativeCalls.godot_icall_4_511(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh), GodotObject.GetPtr(material), &transformOrDefVal, GodotObject.GetPtr(skeleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCollisionSegments, 334873810ul);

    /// <summary>
    /// <para>Adds the specified <paramref name="segments"/> to the gizmo's collision shape for picking. Call this method during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    public void AddCollisionSegments(Vector3[] segments)
    {
        NativeCalls.godot_icall_1_187(MethodBind2, GodotObject.GetPtr(this), segments);
    }

    /// <summary>
    /// <para>Adds the specified <paramref name="segments"/> to the gizmo's collision shape for picking. Call this method during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    public void AddCollisionSegments(ReadOnlySpan<Vector3> segments)
    {
        NativeCalls.godot_icall_1_187(MethodBind2, GodotObject.GetPtr(this), segments);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCollisionTriangles, 54901064ul);

    /// <summary>
    /// <para>Adds collision triangles to the gizmo for picking. A <see cref="Godot.TriangleMesh"/> can be generated from a regular <see cref="Godot.Mesh"/> too. Call this method during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    public void AddCollisionTriangles(TriangleMesh triangles)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(triangles));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddUnscaledBillboard, 520007164ul);

    /// <summary>
    /// <para>Adds an unscaled billboard for visualization and selection. Call this method during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void AddUnscaledBillboard(Material material, float defaultScale = (float)(1), Nullable<Color> modulate = null)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        EditorNativeCalls.godot_icall_3_512(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(material), defaultScale, &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddHandles, 2254560097ul);

    /// <summary>
    /// <para>Adds a list of handles (points) which can be used to edit the properties of the gizmo's <see cref="Godot.Node3D"/>. The <paramref name="ids"/> argument can be used to specify a custom identifier for each handle, if an empty array is passed, the ids will be assigned automatically from the <paramref name="handles"/> argument order.</para>
    /// <para>The <paramref name="secondary"/> argument marks the added handles as secondary, meaning they will normally have lower selection priority than regular handles. When the user is holding the shift key secondary handles will switch to have higher priority than regular handles. This change in priority can be used to place multiple handles at the same point while still giving the user control on their selection.</para>
    /// <para>There are virtual methods which will be called upon editing of these handles. Call this method during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    public void AddHandles(Vector3[] handles, Material material, int[] ids, bool billboard = false, bool secondary = false)
    {
        EditorNativeCalls.godot_icall_5_513(MethodBind5, GodotObject.GetPtr(this), handles, GodotObject.GetPtr(material), ids, billboard.ToGodotBool(), secondary.ToGodotBool());
    }

    /// <summary>
    /// <para>Adds a list of handles (points) which can be used to edit the properties of the gizmo's <see cref="Godot.Node3D"/>. The <paramref name="ids"/> argument can be used to specify a custom identifier for each handle, if an empty array is passed, the ids will be assigned automatically from the <paramref name="handles"/> argument order.</para>
    /// <para>The <paramref name="secondary"/> argument marks the added handles as secondary, meaning they will normally have lower selection priority than regular handles. When the user is holding the shift key secondary handles will switch to have higher priority than regular handles. This change in priority can be used to place multiple handles at the same point while still giving the user control on their selection.</para>
    /// <para>There are virtual methods which will be called upon editing of these handles. Call this method during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    public void AddHandles(ReadOnlySpan<Vector3> handles, Material material, ReadOnlySpan<int> ids, bool billboard, bool secondary)
    {
        EditorNativeCalls.godot_icall_5_513(MethodBind5, GodotObject.GetPtr(this), handles, GodotObject.GetPtr(material), ids, billboard.ToGodotBool(), secondary.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNode3D, 1078189570ul);

    /// <summary>
    /// <para>Sets the reference <see cref="Godot.Node3D"/> node for the gizmo. <paramref name="node"/> must inherit from <see cref="Godot.Node3D"/>.</para>
    /// </summary>
    public void SetNode3D(Node node)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNode3D, 151077316ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Node3D"/> node associated with this gizmo.</para>
    /// </summary>
    public Node3D GetNode3D()
    {
        return (Node3D)NativeCalls.godot_icall_0_53(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlugin, 4250544552ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.EditorNode3DGizmoPlugin"/> that owns this gizmo. It's useful to retrieve materials using <see cref="Godot.EditorNode3DGizmoPlugin.GetMaterial(string, EditorNode3DGizmo)"/>.</para>
    /// </summary>
    public EditorNode3DGizmoPlugin GetPlugin()
    {
        return (EditorNode3DGizmoPlugin)NativeCalls.godot_icall_0_63(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Removes everything in the gizmo including meshes, collisions and handles.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHidden, 2586408642ul);

    /// <summary>
    /// <para>Sets the gizmo's hidden state. If <see langword="true"/>, the gizmo will be hidden. If <see langword="false"/>, it will be shown.</para>
    /// </summary>
    public void SetHidden(bool hidden)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSubgizmoSelected, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given subgizmo is currently selected. Can be used to highlight selected elements during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    public bool IsSubgizmoSelected(int id)
    {
        return NativeCalls.godot_icall_1_62(MethodBind11, GodotObject.GetPtr(this), id).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubgizmoSelection, 1930428628ul);

    /// <summary>
    /// <para>Returns a list of the currently selected subgizmos. Can be used to highlight selected elements during <see cref="Godot.EditorNode3DGizmo._Redraw()"/>.</para>
    /// </summary>
    public int[] GetSubgizmoSelection()
    {
        return NativeCalls.godot_icall_0_151(MethodBind12, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__begin_handle_action = "_BeginHandleAction";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__commit_handle = "_CommitHandle";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__commit_subgizmos = "_CommitSubgizmos";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_handle_name = "_GetHandleName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_handle_value = "_GetHandleValue";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_subgizmo_transform = "_GetSubgizmoTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_handle_highlighted = "_IsHandleHighlighted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__redraw = "_Redraw";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_handle = "_SetHandle";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_subgizmo_transform = "_SetSubgizmoTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__subgizmos_intersect_frustum = "_SubgizmosIntersectFrustum";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__subgizmos_intersect_ray = "_SubgizmosIntersectRay";

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
        if ((method == MethodProxyName__begin_handle_action || method == MethodName._BeginHandleAction) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__begin_handle_action.NativeValue))
        {
            _BeginHandleAction(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__commit_handle || method == MethodName._CommitHandle) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__commit_handle.NativeValue))
        {
            _CommitHandle(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<Variant>(args[2]), VariantUtils.ConvertTo<bool>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__commit_subgizmos || method == MethodName._CommitSubgizmos) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__commit_subgizmos.NativeValue))
        {
            _CommitSubgizmos(VariantUtils.ConvertTo<int[]>(args[0]), new Godot.Collections.Array<Transform3D>(VariantUtils.ConvertToArray(args[1])), VariantUtils.ConvertTo<bool>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_handle_name || method == MethodName._GetHandleName) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_handle_name.NativeValue))
        {
            var callRet = _GetHandleName(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_handle_value || method == MethodName._GetHandleValue) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_handle_value.NativeValue))
        {
            var callRet = _GetHandleValue(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_subgizmo_transform || method == MethodName._GetSubgizmoTransform) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_subgizmo_transform.NativeValue))
        {
            var callRet = _GetSubgizmoTransform(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<Transform3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_handle_highlighted || method == MethodName._IsHandleHighlighted) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_handle_highlighted.NativeValue))
        {
            var callRet = _IsHandleHighlighted(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__redraw || method == MethodName._Redraw) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__redraw.NativeValue))
        {
            _Redraw();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_handle || method == MethodName._SetHandle) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_handle.NativeValue))
        {
            _SetHandle(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<bool>(args[1]), VariantUtils.ConvertTo<Camera3D>(args[2]), VariantUtils.ConvertTo<Vector2>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_subgizmo_transform || method == MethodName._SetSubgizmoTransform) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_subgizmo_transform.NativeValue))
        {
            _SetSubgizmoTransform(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<Transform3D>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__subgizmos_intersect_frustum || method == MethodName._SubgizmosIntersectFrustum) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__subgizmos_intersect_frustum.NativeValue))
        {
            var callRet = _SubgizmosIntersectFrustum(VariantUtils.ConvertTo<Camera3D>(args[0]), new Godot.Collections.Array<Plane>(VariantUtils.ConvertToArray(args[1])));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__subgizmos_intersect_ray || method == MethodName._SubgizmosIntersectRay) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__subgizmos_intersect_ray.NativeValue))
        {
            var callRet = _SubgizmosIntersectRay(VariantUtils.ConvertTo<Camera3D>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
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
        if (method == MethodName._BeginHandleAction)
        {
            if (HasGodotClassMethod(MethodProxyName__begin_handle_action.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CommitHandle)
        {
            if (HasGodotClassMethod(MethodProxyName__commit_handle.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CommitSubgizmos)
        {
            if (HasGodotClassMethod(MethodProxyName__commit_subgizmos.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetHandleName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_handle_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetHandleValue)
        {
            if (HasGodotClassMethod(MethodProxyName__get_handle_value.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSubgizmoTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__get_subgizmo_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsHandleHighlighted)
        {
            if (HasGodotClassMethod(MethodProxyName__is_handle_highlighted.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Redraw)
        {
            if (HasGodotClassMethod(MethodProxyName__redraw.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetHandle)
        {
            if (HasGodotClassMethod(MethodProxyName__set_handle.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetSubgizmoTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__set_subgizmo_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SubgizmosIntersectFrustum)
        {
            if (HasGodotClassMethod(MethodProxyName__subgizmos_intersect_frustum.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SubgizmosIntersectRay)
        {
            if (HasGodotClassMethod(MethodProxyName__subgizmos_intersect_ray.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
    public new class PropertyName : Node3DGizmo.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3DGizmo.MethodName
    {
        /// <summary>
        /// Cached name for the '_begin_handle_action' method.
        /// </summary>
        public static readonly StringName _BeginHandleAction = "_begin_handle_action";
        /// <summary>
        /// Cached name for the '_commit_handle' method.
        /// </summary>
        public static readonly StringName _CommitHandle = "_commit_handle";
        /// <summary>
        /// Cached name for the '_commit_subgizmos' method.
        /// </summary>
        public static readonly StringName _CommitSubgizmos = "_commit_subgizmos";
        /// <summary>
        /// Cached name for the '_get_handle_name' method.
        /// </summary>
        public static readonly StringName _GetHandleName = "_get_handle_name";
        /// <summary>
        /// Cached name for the '_get_handle_value' method.
        /// </summary>
        public static readonly StringName _GetHandleValue = "_get_handle_value";
        /// <summary>
        /// Cached name for the '_get_subgizmo_transform' method.
        /// </summary>
        public static readonly StringName _GetSubgizmoTransform = "_get_subgizmo_transform";
        /// <summary>
        /// Cached name for the '_is_handle_highlighted' method.
        /// </summary>
        public static readonly StringName _IsHandleHighlighted = "_is_handle_highlighted";
        /// <summary>
        /// Cached name for the '_redraw' method.
        /// </summary>
        public static readonly StringName _Redraw = "_redraw";
        /// <summary>
        /// Cached name for the '_set_handle' method.
        /// </summary>
        public static readonly StringName _SetHandle = "_set_handle";
        /// <summary>
        /// Cached name for the '_set_subgizmo_transform' method.
        /// </summary>
        public static readonly StringName _SetSubgizmoTransform = "_set_subgizmo_transform";
        /// <summary>
        /// Cached name for the '_subgizmos_intersect_frustum' method.
        /// </summary>
        public static readonly StringName _SubgizmosIntersectFrustum = "_subgizmos_intersect_frustum";
        /// <summary>
        /// Cached name for the '_subgizmos_intersect_ray' method.
        /// </summary>
        public static readonly StringName _SubgizmosIntersectRay = "_subgizmos_intersect_ray";
        /// <summary>
        /// Cached name for the 'add_lines' method.
        /// </summary>
        public static readonly StringName AddLines = "add_lines";
        /// <summary>
        /// Cached name for the 'add_mesh' method.
        /// </summary>
        public static readonly StringName AddMesh = "add_mesh";
        /// <summary>
        /// Cached name for the 'add_collision_segments' method.
        /// </summary>
        public static readonly StringName AddCollisionSegments = "add_collision_segments";
        /// <summary>
        /// Cached name for the 'add_collision_triangles' method.
        /// </summary>
        public static readonly StringName AddCollisionTriangles = "add_collision_triangles";
        /// <summary>
        /// Cached name for the 'add_unscaled_billboard' method.
        /// </summary>
        public static readonly StringName AddUnscaledBillboard = "add_unscaled_billboard";
        /// <summary>
        /// Cached name for the 'add_handles' method.
        /// </summary>
        public static readonly StringName AddHandles = "add_handles";
        /// <summary>
        /// Cached name for the 'set_node_3d' method.
        /// </summary>
        public static readonly StringName SetNode3D = "set_node_3d";
        /// <summary>
        /// Cached name for the 'get_node_3d' method.
        /// </summary>
        public static readonly StringName GetNode3D = "get_node_3d";
        /// <summary>
        /// Cached name for the 'get_plugin' method.
        /// </summary>
        public static readonly StringName GetPlugin = "get_plugin";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'set_hidden' method.
        /// </summary>
        public static readonly StringName SetHidden = "set_hidden";
        /// <summary>
        /// Cached name for the 'is_subgizmo_selected' method.
        /// </summary>
        public static readonly StringName IsSubgizmoSelected = "is_subgizmo_selected";
        /// <summary>
        /// Cached name for the 'get_subgizmo_selection' method.
        /// </summary>
        public static readonly StringName GetSubgizmoSelection = "get_subgizmo_selection";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3DGizmo.SignalName
    {
    }
}
