namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>GridMapEditorPlugin provides access to the <see cref="Godot.GridMap"/> editor functionality.</para>
/// </summary>
public partial class GridMapEditorPlugin : EditorPlugin
{
    private static readonly System.Type CachedType = typeof(GridMapEditorPlugin);

    private static readonly StringName NativeName = "GridMapEditorPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GridMapEditorPlugin() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GridMapEditorPlugin(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GridMapEditorPlugin(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentGridMap, 1184264483ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.GridMap"/> node currently edited by the grid map editor.</para>
    /// </summary>
    public GridMap GetCurrentGridMap()
    {
        return (GridMap)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelection, 3659408297ul);

    /// <summary>
    /// <para>Selects the cells inside the given bounds from <paramref name="begin"/> to <paramref name="end"/>.</para>
    /// </summary>
    public unsafe void SetSelection(Vector3I begin, Vector3I end)
    {
        EditorNativeCalls.godot_icall_2_711(MethodBind1, GodotObject.GetPtr(this), &begin, &end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearSelection, 3218959716ul);

    /// <summary>
    /// <para>Deselects any currently selected cells.</para>
    /// </summary>
    public void ClearSelection()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelection, 1068685055ul);

    /// <summary>
    /// <para>Returns the cell coordinate bounds of the current selection. Use <see cref="Godot.GridMapEditorPlugin.HasSelection()"/> to check if there is an active selection.</para>
    /// </summary>
    public Aabb GetSelection()
    {
        return NativeCalls.godot_icall_0_184(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSelection, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there are selected cells.</para>
    /// </summary>
    public bool HasSelection()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedCells, 3995934104ul);

    /// <summary>
    /// <para>Returns an array of <see cref="Godot.Vector3I"/>s with the selected cells' coordinates.</para>
    /// </summary>
    public Godot.Collections.Array GetSelectedCells()
    {
        return NativeCalls.godot_icall_0_120(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectedPaletteItem, 998575451ul);

    /// <summary>
    /// <para>Selects the <see cref="Godot.MeshLibrary"/> item with the given index in the grid map editor's palette. If a negative index is given, no item will be selected. If a value greater than the last index is given, the last item will be selected.</para>
    /// <para><b>Note:</b> The indices might not be in the same order as they appear in the editor's interface.</para>
    /// </summary>
    public void SetSelectedPaletteItem(int item)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), item);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedPaletteItem, 3905245786ul);

    /// <summary>
    /// <para>Returns the index of the selected <see cref="Godot.MeshLibrary"/> item in the grid map editor's palette or <c>-1</c> if no item is selected.</para>
    /// <para><b>Note:</b> The indices might not be in the same order as they appear in the editor's interface.</para>
    /// </summary>
    public int GetSelectedPaletteItem()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
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
    public new class PropertyName : EditorPlugin.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : EditorPlugin.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_current_grid_map' method.
        /// </summary>
        public static readonly StringName GetCurrentGridMap = "get_current_grid_map";
        /// <summary>
        /// Cached name for the 'set_selection' method.
        /// </summary>
        public static readonly StringName SetSelection = "set_selection";
        /// <summary>
        /// Cached name for the 'clear_selection' method.
        /// </summary>
        public static readonly StringName ClearSelection = "clear_selection";
        /// <summary>
        /// Cached name for the 'get_selection' method.
        /// </summary>
        public static readonly StringName GetSelection = "get_selection";
        /// <summary>
        /// Cached name for the 'has_selection' method.
        /// </summary>
        public static readonly StringName HasSelection = "has_selection";
        /// <summary>
        /// Cached name for the 'get_selected_cells' method.
        /// </summary>
        public static readonly StringName GetSelectedCells = "get_selected_cells";
        /// <summary>
        /// Cached name for the 'set_selected_palette_item' method.
        /// </summary>
        public static readonly StringName SetSelectedPaletteItem = "set_selected_palette_item";
        /// <summary>
        /// Cached name for the 'get_selected_palette_item' method.
        /// </summary>
        public static readonly StringName GetSelectedPaletteItem = "get_selected_palette_item";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : EditorPlugin.SignalName
    {
    }
}
