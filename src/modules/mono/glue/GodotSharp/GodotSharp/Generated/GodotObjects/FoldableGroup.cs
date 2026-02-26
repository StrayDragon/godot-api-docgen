namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A group of <see cref="Godot.FoldableContainer"/>-derived nodes. Only one container can be expanded at a time.</para>
/// </summary>
public partial class FoldableGroup : Resource
{
    /// <summary>
    /// <para>If <see langword="true"/>, it is possible to fold all containers in this FoldableGroup.</para>
    /// </summary>
    public bool AllowFoldingAll
    {
        get
        {
            return IsAllowFoldingAll();
        }
        set
        {
            SetAllowFoldingAll(value);
        }
    }

    private static readonly System.Type CachedType = typeof(FoldableGroup);

    private static readonly StringName NativeName = "FoldableGroup";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public FoldableGroup() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal FoldableGroup(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal FoldableGroup(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExpandedContainer, 1427441056ul);

    /// <summary>
    /// <para>Returns the current expanded container.</para>
    /// </summary>
    public FoldableContainer GetExpandedContainer()
    {
        return (FoldableContainer)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContainers, 3995934104ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <see cref="Godot.FoldableContainer"/>s that have this as their FoldableGroup (see <see cref="Godot.FoldableContainer.FoldableGroup"/>). This is equivalent to <see cref="Godot.ButtonGroup"/> but for FoldableContainers.</para>
    /// </summary>
    public Godot.Collections.Array<FoldableContainer> GetContainers()
    {
        return new Godot.Collections.Array<FoldableContainer>(NativeCalls.godot_icall_0_120(MethodBind1, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowFoldingAll, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowFoldingAll(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAllowFoldingAll, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAllowFoldingAll()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.FoldableGroup.Expanded"/> event of a <see cref="Godot.FoldableGroup"/> class.
    /// </summary>
    public delegate void ExpandedEventHandler(FoldableContainer container);

    private static void ExpandedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ExpandedEventHandler)delegateObj)(VariantUtils.ConvertTo<FoldableContainer>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when one of the containers of the group is expanded.</para>
    /// </summary>
    public unsafe event ExpandedEventHandler Expanded
    {
        add => Connect(SignalName.Expanded, Callable.CreateWithUnsafeTrampoline(value, &ExpandedTrampoline));
        remove => Disconnect(SignalName.Expanded, Callable.CreateWithUnsafeTrampoline(value, &ExpandedTrampoline));
    }

    protected void EmitSignalExpanded(FoldableContainer container)
    {
        EmitSignal(SignalName.Expanded, container);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_expanded = "Expanded";

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
        if (signal == SignalName.Expanded)
        {
            if (HasGodotClassSignal(SignalProxyName_expanded.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'allow_folding_all' property.
        /// </summary>
        public static readonly StringName AllowFoldingAll = "allow_folding_all";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_expanded_container' method.
        /// </summary>
        public static readonly StringName GetExpandedContainer = "get_expanded_container";
        /// <summary>
        /// Cached name for the 'get_containers' method.
        /// </summary>
        public static readonly StringName GetContainers = "get_containers";
        /// <summary>
        /// Cached name for the 'set_allow_folding_all' method.
        /// </summary>
        public static readonly StringName SetAllowFoldingAll = "set_allow_folding_all";
        /// <summary>
        /// Cached name for the 'is_allow_folding_all' method.
        /// </summary>
        public static readonly StringName IsAllowFoldingAll = "is_allow_folding_all";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
        /// <summary>
        /// Cached name for the 'expanded' signal.
        /// </summary>
        public static readonly StringName Expanded = "expanded";
    }
}
