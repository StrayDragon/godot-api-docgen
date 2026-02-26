namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Exposes a set of tiles for a <see cref="Godot.TileSet"/> resource.</para>
/// <para>Tiles in a source are indexed with two IDs, coordinates ID (of type Vector2i) and an alternative ID (of type int), named according to their use in the <see cref="Godot.TileSetAtlasSource"/> class.</para>
/// <para>Depending on the TileSet source type, those IDs might have restrictions on their values, this is why the base <see cref="Godot.TileSetSource"/> class only exposes getters for them.</para>
/// <para>You can iterate over all tiles exposed by a TileSetSource by first iterating over coordinates IDs using <see cref="Godot.TileSetSource.GetTilesCount()"/> and <see cref="Godot.TileSetSource.GetTileId(int)"/>, then over alternative IDs using <see cref="Godot.TileSetSource.GetAlternativeTilesCount(Vector2I)"/> and <see cref="Godot.TileSetSource.GetAlternativeTileId(Vector2I, int)"/>.</para>
/// <para><b>Warning:</b> <see cref="Godot.TileSetSource"/> can only be added to one TileSet at the same time. Calling <see cref="Godot.TileSet.AddSource(TileSetSource, int)"/> on a second <see cref="Godot.TileSet"/> will remove the source from the first one.</para>
/// </summary>
public partial class TileSetSource : Resource
{
    private static readonly System.Type CachedType = typeof(TileSetSource);

    private static readonly StringName NativeName = "TileSetSource";

    internal TileSetSource() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TileSetSource(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TileSetSource(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTilesCount, 3905245786ul);

    /// <summary>
    /// <para>Returns how many tiles this atlas source defines (not including alternative tiles).</para>
    /// </summary>
    public int GetTilesCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileId, 880721226ul);

    /// <summary>
    /// <para>Returns the tile coordinates ID of the tile with index <paramref name="index"/>.</para>
    /// </summary>
    public Vector2I GetTileId(int index)
    {
        return NativeCalls.godot_icall_1_405(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasTile, 3900751641ul);

    /// <summary>
    /// <para>Returns if this atlas has a tile with coordinates ID <paramref name="atlasCoords"/>.</para>
    /// </summary>
    public unsafe bool HasTile(Vector2I atlasCoords)
    {
        return NativeCalls.godot_icall_1_41(MethodBind2, GodotObject.GetPtr(this), &atlasCoords).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlternativeTilesCount, 2485466453ul);

    /// <summary>
    /// <para>Returns the number of alternatives tiles for the coordinates ID <paramref name="atlasCoords"/>.</para>
    /// <para>For <see cref="Godot.TileSetAtlasSource"/>, this always return at least 1, as the base tile with ID 0 is always part of the alternatives list.</para>
    /// <para>Returns -1 if there is not tile at the given coords.</para>
    /// </summary>
    public unsafe int GetAlternativeTilesCount(Vector2I atlasCoords)
    {
        return NativeCalls.godot_icall_1_409(MethodBind3, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlternativeTileId, 89881719ul);

    /// <summary>
    /// <para>Returns the alternative ID for the tile with coordinates ID <paramref name="atlasCoords"/> at index <paramref name="index"/>.</para>
    /// </summary>
    public unsafe int GetAlternativeTileId(Vector2I atlasCoords, int index)
    {
        return NativeCalls.godot_icall_2_1455(MethodBind4, GodotObject.GetPtr(this), &atlasCoords, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAlternativeTile, 1073731340ul);

    /// <summary>
    /// <para>Returns if the base tile at coordinates <paramref name="atlasCoords"/> has an alternative with ID <paramref name="alternativeTile"/>.</para>
    /// </summary>
    public unsafe bool HasAlternativeTile(Vector2I atlasCoords, int alternativeTile)
    {
        return NativeCalls.godot_icall_2_1459(MethodBind5, GodotObject.GetPtr(this), &atlasCoords, alternativeTile).ToBool();
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
        /// Cached name for the 'get_tiles_count' method.
        /// </summary>
        public static readonly StringName GetTilesCount = "get_tiles_count";
        /// <summary>
        /// Cached name for the 'get_tile_id' method.
        /// </summary>
        public static readonly StringName GetTileId = "get_tile_id";
        /// <summary>
        /// Cached name for the 'has_tile' method.
        /// </summary>
        public static readonly StringName HasTile = "has_tile";
        /// <summary>
        /// Cached name for the 'get_alternative_tiles_count' method.
        /// </summary>
        public static readonly StringName GetAlternativeTilesCount = "get_alternative_tiles_count";
        /// <summary>
        /// Cached name for the 'get_alternative_tile_id' method.
        /// </summary>
        public static readonly StringName GetAlternativeTileId = "get_alternative_tile_id";
        /// <summary>
        /// Cached name for the 'has_alternative_tile' method.
        /// </summary>
        public static readonly StringName HasAlternativeTile = "has_alternative_tile";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
