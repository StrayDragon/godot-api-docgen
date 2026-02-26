namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>When placed on a <see cref="Godot.TileMapLayer"/>, tiles from <see cref="Godot.TileSetScenesCollectionSource"/> will automatically instantiate an associated scene at the cell's position in the TileMapLayer.</para>
/// <para>Scenes are instantiated as children of the <see cref="Godot.TileMapLayer"/> after it enters the tree, at the end of the frame (their creation is deferred). If you add/remove a scene tile in the <see cref="Godot.TileMapLayer"/> that is already inside the tree, the <see cref="Godot.TileMapLayer"/> will automatically instantiate/free the scene accordingly.</para>
/// <para><b>Note:</b> Scene tiles all occupy one tile slot and instead use alternate tile ID to identify scene index. <see cref="Godot.TileSetSource.GetTilesCount()"/> will always return <c>1</c>. Use <see cref="Godot.TileSetScenesCollectionSource.GetSceneTilesCount()"/> to get a number of scenes in a <see cref="Godot.TileSetScenesCollectionSource"/>.</para>
/// <para>Use this code if you want to find the scene path at a given tile in <see cref="Godot.TileMapLayer"/>:</para>
/// <para><code>
/// int sourceId = tileMapLayer.GetCellSourceId(new Vector2I(x, y));
/// if (sourceId &gt; -1)
/// {
/// 	TileSetSource source = tileMapLayer.TileSet.GetSource(sourceId);
/// 	if (source is TileSetScenesCollectionSource sceneSource)
/// 	{
/// 		int altId = tileMapLayer.GetCellAlternativeTile(new Vector2I(x, y));
/// 		// The assigned PackedScene.
/// 		PackedScene scene = sceneSource.GetSceneTileScene(altId);
/// 	}
/// }
/// </code></para>
/// </summary>
public partial class TileSetScenesCollectionSource : TileSetSource
{
    private static readonly System.Type CachedType = typeof(TileSetScenesCollectionSource);

    private static readonly StringName NativeName = "TileSetScenesCollectionSource";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TileSetScenesCollectionSource() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TileSetScenesCollectionSource(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TileSetScenesCollectionSource(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSceneTilesCount, 2455072627ul);

    /// <summary>
    /// <para>Returns the number or scene tiles this TileSet source has.</para>
    /// </summary>
    public int GetSceneTilesCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSceneTileId, 3744713108ul);

    /// <summary>
    /// <para>Returns the scene tile ID of the scene tile at <paramref name="index"/>.</para>
    /// </summary>
    public int GetSceneTileId(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSceneTileId, 3067735520ul);

    /// <summary>
    /// <para>Returns whether this TileSet source has a scene tile with <paramref name="id"/>.</para>
    /// </summary>
    public bool HasSceneTileId(int id)
    {
        return NativeCalls.godot_icall_1_62(MethodBind2, GodotObject.GetPtr(this), id).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateSceneTile, 1117465415ul);

    /// <summary>
    /// <para>Creates a scene-based tile out of the given scene.</para>
    /// <para>Returns a newly generated unique ID.</para>
    /// </summary>
    public int CreateSceneTile(PackedScene packedScene, int idOverride = -1)
    {
        return NativeCalls.godot_icall_2_792(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(packedScene), idOverride);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSceneTileId, 3937882851ul);

    /// <summary>
    /// <para>Changes a scene tile's ID from <paramref name="id"/> to <paramref name="newId"/>. This will fail if there is already a tile with an ID equal to <paramref name="newId"/>.</para>
    /// </summary>
    public void SetSceneTileId(int id, int newId)
    {
        NativeCalls.godot_icall_2_59(MethodBind4, GodotObject.GetPtr(this), id, newId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSceneTileScene, 3435852839ul);

    /// <summary>
    /// <para>Assigns a <see cref="Godot.PackedScene"/> resource to the scene tile with <paramref name="id"/>. This will fail if the scene does not extend <see cref="Godot.CanvasItem"/>, as positioning properties are needed to place the scene on the <see cref="Godot.TileMapLayer"/>.</para>
    /// </summary>
    public void SetSceneTileScene(int id, PackedScene packedScene)
    {
        NativeCalls.godot_icall_2_70(MethodBind5, GodotObject.GetPtr(this), id, GodotObject.GetPtr(packedScene));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSceneTileScene, 511017218ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PackedScene"/> resource of scene tile with <paramref name="id"/>.</para>
    /// </summary>
    public PackedScene GetSceneTileScene(int id)
    {
        return (PackedScene)NativeCalls.godot_icall_1_71(MethodBind6, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSceneTileDisplayPlaceholder, 300928843ul);

    /// <summary>
    /// <para>Sets whether or not the scene tile with <paramref name="id"/> should display a placeholder in the editor. This might be useful for scenes that are not visible.</para>
    /// </summary>
    public void SetSceneTileDisplayPlaceholder(int id, bool displayPlaceholder)
    {
        NativeCalls.godot_icall_2_61(MethodBind7, GodotObject.GetPtr(this), id, displayPlaceholder.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSceneTileDisplayPlaceholder, 1116898809ul);

    /// <summary>
    /// <para>Returns whether the scene tile with <paramref name="id"/> displays a placeholder in the editor.</para>
    /// </summary>
    public bool GetSceneTileDisplayPlaceholder(int id)
    {
        return NativeCalls.godot_icall_1_62(MethodBind8, GodotObject.GetPtr(this), id).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveSceneTile, 1286410249ul);

    /// <summary>
    /// <para>Remove the scene tile with <paramref name="id"/>.</para>
    /// </summary>
    public void RemoveSceneTile(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextSceneTileId, 3905245786ul);

    /// <summary>
    /// <para>Returns the scene ID a following call to <see cref="Godot.TileSetScenesCollectionSource.CreateSceneTile(PackedScene, int)"/> would return.</para>
    /// </summary>
    public int GetNextSceneTileId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
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
    public new class PropertyName : TileSetSource.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : TileSetSource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_scene_tiles_count' method.
        /// </summary>
        public static readonly StringName GetSceneTilesCount = "get_scene_tiles_count";
        /// <summary>
        /// Cached name for the 'get_scene_tile_id' method.
        /// </summary>
        public static readonly StringName GetSceneTileId = "get_scene_tile_id";
        /// <summary>
        /// Cached name for the 'has_scene_tile_id' method.
        /// </summary>
        public static readonly StringName HasSceneTileId = "has_scene_tile_id";
        /// <summary>
        /// Cached name for the 'create_scene_tile' method.
        /// </summary>
        public static readonly StringName CreateSceneTile = "create_scene_tile";
        /// <summary>
        /// Cached name for the 'set_scene_tile_id' method.
        /// </summary>
        public static readonly StringName SetSceneTileId = "set_scene_tile_id";
        /// <summary>
        /// Cached name for the 'set_scene_tile_scene' method.
        /// </summary>
        public static readonly StringName SetSceneTileScene = "set_scene_tile_scene";
        /// <summary>
        /// Cached name for the 'get_scene_tile_scene' method.
        /// </summary>
        public static readonly StringName GetSceneTileScene = "get_scene_tile_scene";
        /// <summary>
        /// Cached name for the 'set_scene_tile_display_placeholder' method.
        /// </summary>
        public static readonly StringName SetSceneTileDisplayPlaceholder = "set_scene_tile_display_placeholder";
        /// <summary>
        /// Cached name for the 'get_scene_tile_display_placeholder' method.
        /// </summary>
        public static readonly StringName GetSceneTileDisplayPlaceholder = "get_scene_tile_display_placeholder";
        /// <summary>
        /// Cached name for the 'remove_scene_tile' method.
        /// </summary>
        public static readonly StringName RemoveSceneTile = "remove_scene_tile";
        /// <summary>
        /// Cached name for the 'get_next_scene_tile_id' method.
        /// </summary>
        public static readonly StringName GetNextSceneTileId = "get_next_scene_tile_id";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : TileSetSource.SignalName
    {
    }
}
