namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.GridContainer"/> arranges its child controls in a grid layout. The number of columns is specified by the <see cref="Godot.GridContainer.Columns"/> property, whereas the number of rows depends on how many are needed for the child controls. The number of rows and columns is preserved for every size of the container.</para>
/// <para><b>Note:</b> <see cref="Godot.GridContainer"/> only works with child nodes inheriting from <see cref="Godot.Control"/>. It won't rearrange child nodes inheriting from <see cref="Godot.Node2D"/>.</para>
/// </summary>
public partial class GridContainer : Container
{
    /// <summary>
    /// <para>The number of columns in the <see cref="Godot.GridContainer"/>. If modified, <see cref="Godot.GridContainer"/> reorders its Control-derived children to accommodate the new layout.</para>
    /// </summary>
    public int Columns
    {
        get
        {
            return GetColumns();
        }
        set
        {
            SetColumns(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GridContainer);

    private static readonly StringName NativeName = "GridContainer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GridContainer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GridContainer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GridContainer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumns, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColumns(int columns)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), columns);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColumns, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetColumns()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : Container.PropertyName
    {
        /// <summary>
        /// Cached name for the 'columns' property.
        /// </summary>
        public static readonly StringName Columns = "columns";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Container.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_columns' method.
        /// </summary>
        public static readonly StringName SetColumns = "set_columns";
        /// <summary>
        /// Cached name for the 'get_columns' method.
        /// </summary>
        public static readonly StringName GetColumns = "get_columns";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Container.SignalName
    {
    }
}
