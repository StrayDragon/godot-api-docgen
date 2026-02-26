namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A library of meshes. Contains a list of <see cref="Godot.Mesh"/> resources, each with a name and ID. Each item can also include collision and navigation shapes. This resource is used in <see cref="Godot.GridMap"/>.</para>
/// </summary>
public partial class MeshLibrary : Resource
{
    private static readonly System.Type CachedType = typeof(MeshLibrary);

    private static readonly StringName NativeName = "MeshLibrary";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MeshLibrary() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal MeshLibrary(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MeshLibrary(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateItem, 1286410249ul);

    /// <summary>
    /// <para>Creates a new item in the library with the given ID.</para>
    /// <para>You can get an unused ID from <see cref="Godot.MeshLibrary.GetLastUnusedItemId()"/>.</para>
    /// </summary>
    public void CreateItem(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemName, 501894301ul);

    /// <summary>
    /// <para>Sets the item's name.</para>
    /// <para>This name is shown in the editor. It can also be used to look up the item later using <see cref="Godot.MeshLibrary.FindItemByName(string)"/>.</para>
    /// </summary>
    public void SetItemName(int id, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind1, GodotObject.GetPtr(this), id, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemMesh, 969122797ul);

    /// <summary>
    /// <para>Sets the item's mesh.</para>
    /// </summary>
    public void SetItemMesh(int id, Mesh mesh)
    {
        NativeCalls.godot_icall_2_70(MethodBind2, GodotObject.GetPtr(this), id, GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemMeshTransform, 3616898986ul);

    /// <summary>
    /// <para>Sets the transform to apply to the item's mesh.</para>
    /// </summary>
    public unsafe void SetItemMeshTransform(int id, Transform3D meshTransform)
    {
        NativeCalls.godot_icall_2_800(MethodBind3, GodotObject.GetPtr(this), id, &meshTransform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemMeshCastShadow, 3923400443ul);

    /// <summary>
    /// <para>Sets the item's shadow casting mode to <paramref name="shadowCastingSetting"/>.</para>
    /// </summary>
    public void SetItemMeshCastShadow(int id, RenderingServer.ShadowCastingSetting shadowCastingSetting)
    {
        NativeCalls.godot_icall_2_59(MethodBind4, GodotObject.GetPtr(this), id, (int)shadowCastingSetting);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemNavigationMesh, 3483353960ul);

    /// <summary>
    /// <para>Sets the item's navigation mesh.</para>
    /// </summary>
    public void SetItemNavigationMesh(int id, NavigationMesh navigationMesh)
    {
        NativeCalls.godot_icall_2_70(MethodBind5, GodotObject.GetPtr(this), id, GodotObject.GetPtr(navigationMesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemNavigationMeshTransform, 3616898986ul);

    /// <summary>
    /// <para>Sets the transform to apply to the item's navigation mesh.</para>
    /// </summary>
    public unsafe void SetItemNavigationMeshTransform(int id, Transform3D navigationMesh)
    {
        NativeCalls.godot_icall_2_800(MethodBind6, GodotObject.GetPtr(this), id, &navigationMesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemNavigationLayers, 3937882851ul);

    /// <summary>
    /// <para>Sets the item's navigation layers bitmask.</para>
    /// </summary>
    public void SetItemNavigationLayers(int id, uint navigationLayers)
    {
        NativeCalls.godot_icall_2_801(MethodBind7, GodotObject.GetPtr(this), id, navigationLayers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemShapes, 537221740ul);

    /// <summary>
    /// <para>Sets an item's collision shapes.</para>
    /// <para>The array should consist of <see cref="Godot.Shape3D"/> objects, each followed by a <see cref="Godot.Transform3D"/> that will be applied to it. For shapes that should not have a transform, use <c>Transform3D.IDENTITY</c>.</para>
    /// </summary>
    public void SetItemShapes(int id, Godot.Collections.Array shapes)
    {
        NativeCalls.godot_icall_2_802(MethodBind8, GodotObject.GetPtr(this), id, (godot_array)(shapes ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemPreview, 666127730ul);

    /// <summary>
    /// <para>Sets a texture to use as the item's preview icon in the editor.</para>
    /// </summary>
    public void SetItemPreview(int id, Texture2D texture)
    {
        NativeCalls.godot_icall_2_70(MethodBind9, GodotObject.GetPtr(this), id, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemName, 844755477ul);

    /// <summary>
    /// <para>Returns the item's name.</para>
    /// </summary>
    public string GetItemName(int id)
    {
        return NativeCalls.godot_icall_1_133(MethodBind10, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemMesh, 1576363275ul);

    /// <summary>
    /// <para>Returns the item's mesh.</para>
    /// </summary>
    public Mesh GetItemMesh(int id)
    {
        return (Mesh)NativeCalls.godot_icall_1_71(MethodBind11, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemMeshTransform, 1965739696ul);

    /// <summary>
    /// <para>Returns the transform applied to the item's mesh.</para>
    /// </summary>
    public Transform3D GetItemMeshTransform(int id)
    {
        return NativeCalls.godot_icall_1_803(MethodBind12, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemMeshCastShadow, 1841766007ul);

    /// <summary>
    /// <para>Returns the item's shadow casting mode.</para>
    /// </summary>
    public RenderingServer.ShadowCastingSetting GetItemMeshCastShadow(int id)
    {
        return (RenderingServer.ShadowCastingSetting)NativeCalls.godot_icall_1_60(MethodBind13, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemNavigationMesh, 2729647406ul);

    /// <summary>
    /// <para>Returns the item's navigation mesh.</para>
    /// </summary>
    public NavigationMesh GetItemNavigationMesh(int id)
    {
        return (NavigationMesh)NativeCalls.godot_icall_1_71(MethodBind14, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemNavigationMeshTransform, 1965739696ul);

    /// <summary>
    /// <para>Returns the transform applied to the item's navigation mesh.</para>
    /// </summary>
    public Transform3D GetItemNavigationMeshTransform(int id)
    {
        return NativeCalls.godot_icall_1_803(MethodBind15, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemNavigationLayers, 923996154ul);

    /// <summary>
    /// <para>Returns the item's navigation layers bitmask.</para>
    /// </summary>
    public uint GetItemNavigationLayers(int id)
    {
        return NativeCalls.godot_icall_1_322(MethodBind16, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemShapes, 663333327ul);

    /// <summary>
    /// <para>Returns an item's collision shapes.</para>
    /// <para>The array consists of each <see cref="Godot.Shape3D"/> followed by its <see cref="Godot.Transform3D"/>.</para>
    /// </summary>
    public Godot.Collections.Array GetItemShapes(int id)
    {
        return NativeCalls.godot_icall_1_457(MethodBind17, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemPreview, 3536238170ul);

    /// <summary>
    /// <para>When running in the editor, returns a generated item preview (a 3D rendering in isometric perspective). When used in a running project, returns the manually-defined item preview which can be set using <see cref="Godot.MeshLibrary.SetItemPreview(int, Texture2D)"/>. Returns an empty <see cref="Godot.Texture2D"/> if no preview was manually set in a running project.</para>
    /// </summary>
    public Texture2D GetItemPreview(int id)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind18, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveItem, 1286410249ul);

    /// <summary>
    /// <para>Removes the item.</para>
    /// </summary>
    public void RemoveItem(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindItemByName, 1321353865ul);

    /// <summary>
    /// <para>Returns the first item with the given name, or <c>-1</c> if no item is found.</para>
    /// </summary>
    public int FindItemByName(string name)
    {
        return NativeCalls.godot_icall_1_134(MethodBind20, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears the library.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemList, 1930428628ul);

    /// <summary>
    /// <para>Returns the list of item IDs in use.</para>
    /// </summary>
    public int[] GetItemList()
    {
        return NativeCalls.godot_icall_0_151(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLastUnusedItemId, 3905245786ul);

    /// <summary>
    /// <para>Gets an unused ID for a new item.</para>
    /// </summary>
    public int GetLastUnusedItemId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_item' method.
        /// </summary>
        public static readonly StringName CreateItem = "create_item";
        /// <summary>
        /// Cached name for the 'set_item_name' method.
        /// </summary>
        public static readonly StringName SetItemName = "set_item_name";
        /// <summary>
        /// Cached name for the 'set_item_mesh' method.
        /// </summary>
        public static readonly StringName SetItemMesh = "set_item_mesh";
        /// <summary>
        /// Cached name for the 'set_item_mesh_transform' method.
        /// </summary>
        public static readonly StringName SetItemMeshTransform = "set_item_mesh_transform";
        /// <summary>
        /// Cached name for the 'set_item_mesh_cast_shadow' method.
        /// </summary>
        public static readonly StringName SetItemMeshCastShadow = "set_item_mesh_cast_shadow";
        /// <summary>
        /// Cached name for the 'set_item_navigation_mesh' method.
        /// </summary>
        public static readonly StringName SetItemNavigationMesh = "set_item_navigation_mesh";
        /// <summary>
        /// Cached name for the 'set_item_navigation_mesh_transform' method.
        /// </summary>
        public static readonly StringName SetItemNavigationMeshTransform = "set_item_navigation_mesh_transform";
        /// <summary>
        /// Cached name for the 'set_item_navigation_layers' method.
        /// </summary>
        public static readonly StringName SetItemNavigationLayers = "set_item_navigation_layers";
        /// <summary>
        /// Cached name for the 'set_item_shapes' method.
        /// </summary>
        public static readonly StringName SetItemShapes = "set_item_shapes";
        /// <summary>
        /// Cached name for the 'set_item_preview' method.
        /// </summary>
        public static readonly StringName SetItemPreview = "set_item_preview";
        /// <summary>
        /// Cached name for the 'get_item_name' method.
        /// </summary>
        public static readonly StringName GetItemName = "get_item_name";
        /// <summary>
        /// Cached name for the 'get_item_mesh' method.
        /// </summary>
        public static readonly StringName GetItemMesh = "get_item_mesh";
        /// <summary>
        /// Cached name for the 'get_item_mesh_transform' method.
        /// </summary>
        public static readonly StringName GetItemMeshTransform = "get_item_mesh_transform";
        /// <summary>
        /// Cached name for the 'get_item_mesh_cast_shadow' method.
        /// </summary>
        public static readonly StringName GetItemMeshCastShadow = "get_item_mesh_cast_shadow";
        /// <summary>
        /// Cached name for the 'get_item_navigation_mesh' method.
        /// </summary>
        public static readonly StringName GetItemNavigationMesh = "get_item_navigation_mesh";
        /// <summary>
        /// Cached name for the 'get_item_navigation_mesh_transform' method.
        /// </summary>
        public static readonly StringName GetItemNavigationMeshTransform = "get_item_navigation_mesh_transform";
        /// <summary>
        /// Cached name for the 'get_item_navigation_layers' method.
        /// </summary>
        public static readonly StringName GetItemNavigationLayers = "get_item_navigation_layers";
        /// <summary>
        /// Cached name for the 'get_item_shapes' method.
        /// </summary>
        public static readonly StringName GetItemShapes = "get_item_shapes";
        /// <summary>
        /// Cached name for the 'get_item_preview' method.
        /// </summary>
        public static readonly StringName GetItemPreview = "get_item_preview";
        /// <summary>
        /// Cached name for the 'remove_item' method.
        /// </summary>
        public static readonly StringName RemoveItem = "remove_item";
        /// <summary>
        /// Cached name for the 'find_item_by_name' method.
        /// </summary>
        public static readonly StringName FindItemByName = "find_item_by_name";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'get_item_list' method.
        /// </summary>
        public static readonly StringName GetItemList = "get_item_list";
        /// <summary>
        /// Cached name for the 'get_last_unused_item_id' method.
        /// </summary>
        public static readonly StringName GetLastUnusedItemId = "get_last_unused_item_id";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
