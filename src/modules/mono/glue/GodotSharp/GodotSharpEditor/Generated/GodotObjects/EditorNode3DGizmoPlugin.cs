namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.EditorNode3DGizmoPlugin"/> allows you to define a new type of Gizmo. There are two main ways to do so: extending <see cref="Godot.EditorNode3DGizmoPlugin"/> for the simpler gizmos, or creating a new <see cref="Godot.EditorNode3DGizmo"/> type. See the tutorial in the documentation for more info.</para>
/// <para>To use <see cref="Godot.EditorNode3DGizmoPlugin"/>, register it using the <see cref="Godot.EditorPlugin.AddNode3DGizmoPlugin(EditorNode3DGizmoPlugin)"/> method first.</para>
/// </summary>
public partial class EditorNode3DGizmoPlugin : Resource
{
    private static readonly System.Type CachedType = typeof(EditorNode3DGizmoPlugin);

    private static readonly StringName NativeName = "EditorNode3DGizmoPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorNode3DGizmoPlugin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorNode3DGizmoPlugin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorNode3DGizmoPlugin(bool memoryOwn) : base(memoryOwn) { }

    public virtual void _BeginHandleAction(EditorNode3DGizmo gizmo, int handleId, bool secondary)
    {
    }

    /// <summary>
    /// <para>Override this method to define whether the gizmos handled by this plugin can be hidden or not. Returns <see langword="true"/> if not overridden.</para>
    /// </summary>
    public virtual bool _CanBeHidden()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to commit a handle being edited (handles must have been previously added by <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> during <see cref="Godot.EditorNode3DGizmoPlugin._Redraw(EditorNode3DGizmo)"/>). This usually means creating an <see cref="Godot.UndoRedo"/> action for the change, using the current handle value as "do" and the <paramref name="restore"/> argument as "undo".</para>
    /// <para>If the <paramref name="cancel"/> argument is <see langword="true"/>, the <paramref name="restore"/> value should be directly set, without any <see cref="Godot.UndoRedo"/> action.</para>
    /// <para>The <paramref name="secondary"/> argument is <see langword="true"/> when the committed handle is secondary (see <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> for more information).</para>
    /// <para>Called for this plugin's active gizmos.</para>
    /// </summary>
    public virtual void _CommitHandle(EditorNode3DGizmo gizmo, int handleId, bool secondary, Variant restore, bool cancel)
    {
    }

    /// <summary>
    /// <para>Override this method to commit a group of subgizmos being edited (see <see cref="Godot.EditorNode3DGizmoPlugin._SubgizmosIntersectRay(EditorNode3DGizmo, Camera3D, Vector2)"/> and <see cref="Godot.EditorNode3DGizmoPlugin._SubgizmosIntersectFrustum(EditorNode3DGizmo, Camera3D, Godot.Collections.Array{Plane})"/>). This usually means creating an <see cref="Godot.UndoRedo"/> action for the change, using the current transforms as "do" and the <paramref name="restores"/> transforms as "undo".</para>
    /// <para>If the <paramref name="cancel"/> argument is <see langword="true"/>, the <paramref name="restores"/> transforms should be directly set, without any <see cref="Godot.UndoRedo"/> action. As with all subgizmo methods, transforms are given in local space respect to the gizmo's Node3D. Called for this plugin's active gizmos.</para>
    /// </summary>
    public virtual void _CommitSubgizmos(EditorNode3DGizmo gizmo, int[] ids, Godot.Collections.Array<Transform3D> restores, bool cancel)
    {
    }

    /// <summary>
    /// <para>Override this method to return a custom <see cref="Godot.EditorNode3DGizmo"/> for the 3D nodes of your choice, return <see langword="null"/> for the rest of nodes. See also <see cref="Godot.EditorNode3DGizmoPlugin._HasGizmo(Node3D)"/>.</para>
    /// </summary>
    public virtual EditorNode3DGizmo _CreateGizmo(Node3D forNode3D)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to provide the name that will appear in the gizmo visibility menu.</para>
    /// </summary>
    public virtual string _GetGizmoName()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to provide gizmo's handle names. The <paramref name="secondary"/> argument is <see langword="true"/> when the requested handle is secondary (see <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> for more information). Called for this plugin's active gizmos.</para>
    /// </summary>
    public virtual string _GetHandleName(EditorNode3DGizmo gizmo, int handleId, bool secondary)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to return the current value of a handle. This value will be requested at the start of an edit and used as the <c>restore</c> argument in <see cref="Godot.EditorNode3DGizmoPlugin._CommitHandle(EditorNode3DGizmo, int, bool, Variant, bool)"/>.</para>
    /// <para>The <paramref name="secondary"/> argument is <see langword="true"/> when the requested handle is secondary (see <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> for more information).</para>
    /// <para>Called for this plugin's active gizmos.</para>
    /// </summary>
    public virtual Variant _GetHandleValue(EditorNode3DGizmo gizmo, int handleId, bool secondary)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to set the gizmo's priority. Gizmos with higher priority will have precedence when processing inputs like handles or subgizmos selection.</para>
    /// <para>All built-in editor gizmos return a priority of <c>-1</c>. If not overridden, this method will return <c>0</c>, which means custom gizmos will automatically get higher priority than built-in gizmos.</para>
    /// </summary>
    public virtual int _GetPriority()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to return the current transform of a subgizmo. As with all subgizmo methods, the transform should be in local space respect to the gizmo's Node3D. This transform will be requested at the start of an edit and used in the <c>restore</c> argument in <see cref="Godot.EditorNode3DGizmoPlugin._CommitSubgizmos(EditorNode3DGizmo, int[], Godot.Collections.Array{Transform3D}, bool)"/>. Called for this plugin's active gizmos.</para>
    /// </summary>
    public virtual Transform3D _GetSubgizmoTransform(EditorNode3DGizmo gizmo, int subgizmoId)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define which Node3D nodes have a gizmo from this plugin. Whenever a <see cref="Godot.Node3D"/> node is added to a scene this method is called, if it returns <see langword="true"/> the node gets a generic <see cref="Godot.EditorNode3DGizmo"/> assigned and is added to this plugin's list of active gizmos.</para>
    /// </summary>
    public virtual bool _HasGizmo(Node3D forNode3D)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to return <see langword="true"/> whenever to given handle should be highlighted in the editor. The <paramref name="secondary"/> argument is <see langword="true"/> when the requested handle is secondary (see <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> for more information). Called for this plugin's active gizmos.</para>
    /// </summary>
    public virtual bool _IsHandleHighlighted(EditorNode3DGizmo gizmo, int handleId, bool secondary)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define whether Node3D with this gizmo should be selectable even when the gizmo is hidden.</para>
    /// </summary>
    public virtual bool _IsSelectableWhenHidden()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to add all the gizmo elements whenever a gizmo update is requested. It's common to call <see cref="Godot.EditorNode3DGizmo.Clear()"/> at the beginning of this method and then add visual elements depending on the node's properties.</para>
    /// </summary>
    public virtual void _Redraw(EditorNode3DGizmo gizmo)
    {
    }

    /// <summary>
    /// <para>Override this method to update the node's properties when the user drags a gizmo handle (previously added with <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/>). The provided <paramref name="screenPos"/> is the mouse position in screen coordinates and the <paramref name="camera"/> can be used to convert it to raycasts.</para>
    /// <para>The <paramref name="secondary"/> argument is <see langword="true"/> when the edited handle is secondary (see <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/> for more information).</para>
    /// <para>Called for this plugin's active gizmos.</para>
    /// </summary>
    public virtual unsafe void _SetHandle(EditorNode3DGizmo gizmo, int handleId, bool secondary, Camera3D camera, Vector2 screenPos)
    {
    }

    /// <summary>
    /// <para>Override this method to update the node properties during subgizmo editing (see <see cref="Godot.EditorNode3DGizmoPlugin._SubgizmosIntersectRay(EditorNode3DGizmo, Camera3D, Vector2)"/> and <see cref="Godot.EditorNode3DGizmoPlugin._SubgizmosIntersectFrustum(EditorNode3DGizmo, Camera3D, Godot.Collections.Array{Plane})"/>). The <paramref name="transform"/> is given in the Node3D's local coordinate system. Called for this plugin's active gizmos.</para>
    /// </summary>
    public virtual unsafe void _SetSubgizmoTransform(EditorNode3DGizmo gizmo, int subgizmoId, Transform3D transform)
    {
    }

    /// <summary>
    /// <para>Override this method to allow selecting subgizmos using mouse drag box selection. Given a <paramref name="camera"/> and <paramref name="frustumPlanes"/>, this method should return which subgizmos are contained within the frustums. The <paramref name="frustumPlanes"/> argument consists of an array with all the <see cref="Godot.Plane"/>s that make up the selection frustum. The returned value should contain a list of unique subgizmo identifiers, these identifiers can have any non-negative value and will be used in other virtual methods like <see cref="Godot.EditorNode3DGizmoPlugin._GetSubgizmoTransform(EditorNode3DGizmo, int)"/> or <see cref="Godot.EditorNode3DGizmoPlugin._CommitSubgizmos(EditorNode3DGizmo, int[], Godot.Collections.Array{Transform3D}, bool)"/>. Called for this plugin's active gizmos.</para>
    /// </summary>
    public virtual int[] _SubgizmosIntersectFrustum(EditorNode3DGizmo gizmo, Camera3D camera, Godot.Collections.Array<Plane> frustumPlanes)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to allow selecting subgizmos using mouse clicks. Given a <paramref name="camera"/> and a <paramref name="screenPos"/> in screen coordinates, this method should return which subgizmo should be selected. The returned value should be a unique subgizmo identifier, which can have any non-negative value and will be used in other virtual methods like <see cref="Godot.EditorNode3DGizmoPlugin._GetSubgizmoTransform(EditorNode3DGizmo, int)"/> or <see cref="Godot.EditorNode3DGizmoPlugin._CommitSubgizmos(EditorNode3DGizmo, int[], Godot.Collections.Array{Transform3D}, bool)"/>. Called for this plugin's active gizmos.</para>
    /// </summary>
    public virtual unsafe int _SubgizmosIntersectRay(EditorNode3DGizmo gizmo, Camera3D camera, Vector2 screenPos)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateMaterial, 3486012546ul);

    /// <summary>
    /// <para>Creates an unshaded material with its variants (selected and/or editable) and adds them to the internal material list. They can then be accessed with <see cref="Godot.EditorNode3DGizmoPlugin.GetMaterial(string, EditorNode3DGizmo)"/> and used in <see cref="Godot.EditorNode3DGizmo.AddMesh(Mesh, Material, Nullable{Transform3D}, SkinReference)"/> and <see cref="Godot.EditorNode3DGizmo.AddLines(Vector3[], Material, bool, Nullable{Color})"/>. Should not be overridden.</para>
    /// </summary>
    public unsafe void CreateMaterial(string name, Color color, bool billboard = false, bool onTop = false, bool useVertexColor = false)
    {
        EditorNativeCalls.godot_icall_5_514(MethodBind0, GodotObject.GetPtr(this), name, &color, billboard.ToGodotBool(), onTop.ToGodotBool(), useVertexColor.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateIconMaterial, 3804976916ul);

    /// <summary>
    /// <para>Creates an icon material with its variants (selected and/or editable) and adds them to the internal material list. They can then be accessed with <see cref="Godot.EditorNode3DGizmoPlugin.GetMaterial(string, EditorNode3DGizmo)"/> and used in <see cref="Godot.EditorNode3DGizmo.AddUnscaledBillboard(Material, float, Nullable{Color})"/>. Should not be overridden.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void CreateIconMaterial(string name, Texture2D texture, bool onTop = false, Nullable<Color> color = null)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        EditorNativeCalls.godot_icall_4_515(MethodBind1, GodotObject.GetPtr(this), name, GodotObject.GetPtr(texture), onTop.ToGodotBool(), &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateHandleMaterial, 2486475223ul);

    /// <summary>
    /// <para>Creates a handle material with its variants (selected and/or editable) and adds them to the internal material list. They can then be accessed with <see cref="Godot.EditorNode3DGizmoPlugin.GetMaterial(string, EditorNode3DGizmo)"/> and used in <see cref="Godot.EditorNode3DGizmo.AddHandles(Vector3[], Material, int[], bool, bool)"/>. Should not be overridden.</para>
    /// <para>You can optionally provide a texture to use instead of the default icon.</para>
    /// </summary>
    public void CreateHandleMaterial(string name, bool billboard = false, Texture2D texture = default)
    {
        EditorNativeCalls.godot_icall_3_516(MethodBind2, GodotObject.GetPtr(this), name, billboard.ToGodotBool(), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMaterial, 1374068695ul);

    /// <summary>
    /// <para>Adds a new material to the internal material list for the plugin. It can then be accessed with <see cref="Godot.EditorNode3DGizmoPlugin.GetMaterial(string, EditorNode3DGizmo)"/>. Should not be overridden.</para>
    /// </summary>
    public void AddMaterial(string name, StandardMaterial3D material)
    {
        NativeCalls.godot_icall_2_517(MethodBind3, GodotObject.GetPtr(this), name, GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaterial, 974464017ul);

    /// <summary>
    /// <para>Gets material from the internal list of materials. If an <see cref="Godot.EditorNode3DGizmo"/> is provided, it will try to get the corresponding variant (selected and/or editable).</para>
    /// </summary>
    public StandardMaterial3D GetMaterial(string name, EditorNode3DGizmo gizmo = null)
    {
        return (StandardMaterial3D)EditorNativeCalls.godot_icall_2_518(MethodBind4, GodotObject.GetPtr(this), name, GodotObject.GetPtr(gizmo));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__begin_handle_action = "_BeginHandleAction";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__can_be_hidden = "_CanBeHidden";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__commit_handle = "_CommitHandle";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__commit_subgizmos = "_CommitSubgizmos";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create_gizmo = "_CreateGizmo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_gizmo_name = "_GetGizmoName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_handle_name = "_GetHandleName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_handle_value = "_GetHandleValue";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_priority = "_GetPriority";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_subgizmo_transform = "_GetSubgizmoTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_gizmo = "_HasGizmo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_handle_highlighted = "_IsHandleHighlighted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_selectable_when_hidden = "_IsSelectableWhenHidden";

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
        if ((method == MethodProxyName__begin_handle_action || method == MethodName._BeginHandleAction) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__begin_handle_action.NativeValue))
        {
            _BeginHandleAction(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__can_be_hidden || method == MethodName._CanBeHidden) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__can_be_hidden.NativeValue))
        {
            var callRet = _CanBeHidden();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__commit_handle || method == MethodName._CommitHandle) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__commit_handle.NativeValue))
        {
            _CommitHandle(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<bool>(args[2]), VariantUtils.ConvertTo<Variant>(args[3]), VariantUtils.ConvertTo<bool>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__commit_subgizmos || method == MethodName._CommitSubgizmos) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__commit_subgizmos.NativeValue))
        {
            _CommitSubgizmos(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<int[]>(args[1]), new Godot.Collections.Array<Transform3D>(VariantUtils.ConvertToArray(args[2])), VariantUtils.ConvertTo<bool>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__create_gizmo || method == MethodName._CreateGizmo) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__create_gizmo.NativeValue))
        {
            var callRet = _CreateGizmo(VariantUtils.ConvertTo<Node3D>(args[0]));
            ret = VariantUtils.CreateFrom<EditorNode3DGizmo>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_gizmo_name || method == MethodName._GetGizmoName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_gizmo_name.NativeValue))
        {
            var callRet = _GetGizmoName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_handle_name || method == MethodName._GetHandleName) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_handle_name.NativeValue))
        {
            var callRet = _GetHandleName(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_handle_value || method == MethodName._GetHandleValue) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_handle_value.NativeValue))
        {
            var callRet = _GetHandleValue(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_priority || method == MethodName._GetPriority) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_priority.NativeValue))
        {
            var callRet = _GetPriority();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_subgizmo_transform || method == MethodName._GetSubgizmoTransform) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_subgizmo_transform.NativeValue))
        {
            var callRet = _GetSubgizmoTransform(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = VariantUtils.CreateFrom<Transform3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_gizmo || method == MethodName._HasGizmo) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_gizmo.NativeValue))
        {
            var callRet = _HasGizmo(VariantUtils.ConvertTo<Node3D>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_handle_highlighted || method == MethodName._IsHandleHighlighted) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_handle_highlighted.NativeValue))
        {
            var callRet = _IsHandleHighlighted(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_selectable_when_hidden || method == MethodName._IsSelectableWhenHidden) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_selectable_when_hidden.NativeValue))
        {
            var callRet = _IsSelectableWhenHidden();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__redraw || method == MethodName._Redraw) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__redraw.NativeValue))
        {
            _Redraw(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_handle || method == MethodName._SetHandle) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_handle.NativeValue))
        {
            _SetHandle(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<bool>(args[2]), VariantUtils.ConvertTo<Camera3D>(args[3]), VariantUtils.ConvertTo<Vector2>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_subgizmo_transform || method == MethodName._SetSubgizmoTransform) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_subgizmo_transform.NativeValue))
        {
            _SetSubgizmoTransform(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Transform3D>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__subgizmos_intersect_frustum || method == MethodName._SubgizmosIntersectFrustum) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__subgizmos_intersect_frustum.NativeValue))
        {
            var callRet = _SubgizmosIntersectFrustum(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<Camera3D>(args[1]), new Godot.Collections.Array<Plane>(VariantUtils.ConvertToArray(args[2])));
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__subgizmos_intersect_ray || method == MethodName._SubgizmosIntersectRay) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__subgizmos_intersect_ray.NativeValue))
        {
            var callRet = _SubgizmosIntersectRay(VariantUtils.ConvertTo<EditorNode3DGizmo>(args[0]), VariantUtils.ConvertTo<Camera3D>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]));
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
        if (method == MethodName._CanBeHidden)
        {
            if (HasGodotClassMethod(MethodProxyName__can_be_hidden.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._CreateGizmo)
        {
            if (HasGodotClassMethod(MethodProxyName__create_gizmo.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetGizmoName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_gizmo_name.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._GetPriority)
        {
            if (HasGodotClassMethod(MethodProxyName__get_priority.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._HasGizmo)
        {
            if (HasGodotClassMethod(MethodProxyName__has_gizmo.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._IsSelectableWhenHidden)
        {
            if (HasGodotClassMethod(MethodProxyName__is_selectable_when_hidden.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : Resource.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_begin_handle_action' method.
        /// </summary>
        public static readonly StringName _BeginHandleAction = "_begin_handle_action";
        /// <summary>
        /// Cached name for the '_can_be_hidden' method.
        /// </summary>
        public static readonly StringName _CanBeHidden = "_can_be_hidden";
        /// <summary>
        /// Cached name for the '_commit_handle' method.
        /// </summary>
        public static readonly StringName _CommitHandle = "_commit_handle";
        /// <summary>
        /// Cached name for the '_commit_subgizmos' method.
        /// </summary>
        public static readonly StringName _CommitSubgizmos = "_commit_subgizmos";
        /// <summary>
        /// Cached name for the '_create_gizmo' method.
        /// </summary>
        public static readonly StringName _CreateGizmo = "_create_gizmo";
        /// <summary>
        /// Cached name for the '_get_gizmo_name' method.
        /// </summary>
        public static readonly StringName _GetGizmoName = "_get_gizmo_name";
        /// <summary>
        /// Cached name for the '_get_handle_name' method.
        /// </summary>
        public static readonly StringName _GetHandleName = "_get_handle_name";
        /// <summary>
        /// Cached name for the '_get_handle_value' method.
        /// </summary>
        public static readonly StringName _GetHandleValue = "_get_handle_value";
        /// <summary>
        /// Cached name for the '_get_priority' method.
        /// </summary>
        public static readonly StringName _GetPriority = "_get_priority";
        /// <summary>
        /// Cached name for the '_get_subgizmo_transform' method.
        /// </summary>
        public static readonly StringName _GetSubgizmoTransform = "_get_subgizmo_transform";
        /// <summary>
        /// Cached name for the '_has_gizmo' method.
        /// </summary>
        public static readonly StringName _HasGizmo = "_has_gizmo";
        /// <summary>
        /// Cached name for the '_is_handle_highlighted' method.
        /// </summary>
        public static readonly StringName _IsHandleHighlighted = "_is_handle_highlighted";
        /// <summary>
        /// Cached name for the '_is_selectable_when_hidden' method.
        /// </summary>
        public static readonly StringName _IsSelectableWhenHidden = "_is_selectable_when_hidden";
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
        /// Cached name for the 'create_material' method.
        /// </summary>
        public static readonly StringName CreateMaterial = "create_material";
        /// <summary>
        /// Cached name for the 'create_icon_material' method.
        /// </summary>
        public static readonly StringName CreateIconMaterial = "create_icon_material";
        /// <summary>
        /// Cached name for the 'create_handle_material' method.
        /// </summary>
        public static readonly StringName CreateHandleMaterial = "create_handle_material";
        /// <summary>
        /// Cached name for the 'add_material' method.
        /// </summary>
        public static readonly StringName AddMaterial = "add_material";
        /// <summary>
        /// Cached name for the 'get_material' method.
        /// </summary>
        public static readonly StringName GetMaterial = "get_material";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
