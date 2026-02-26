namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for all GUI containers. A <see cref="Godot.Container"/> automatically arranges its child controls in a certain way. This class can be inherited to make custom container types.</para>
/// </summary>
public partial class Container : Control
{
    /// <summary>
    /// <para>Notification just before children are going to be sorted, in case there's something to process beforehand.</para>
    /// </summary>
    public const long NotificationPreSortChildren = 50;
    /// <summary>
    /// <para>Notification for when sorting the children, it must be obeyed immediately.</para>
    /// </summary>
    public const long NotificationSortChildren = 51;

    private static readonly System.Type CachedType = typeof(Container);

    private static readonly StringName NativeName = "Container";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Container() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Container(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Container(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Implement to return a list of allowed horizontal <see cref="Godot.Control.SizeFlags"/> for child nodes. This doesn't technically prevent the usages of any other size flags, if your implementation requires that. This only limits the options available to the user in the Inspector dock.</para>
    /// <para><b>Note:</b> Having no size flags is equal to having <see cref="Godot.Control.SizeFlags.ShrinkBegin"/>. As such, this value is always implicitly allowed.</para>
    /// </summary>
    public virtual int[] _GetAllowedSizeFlagsHorizontal()
    {
        return default;
    }

    /// <summary>
    /// <para>Implement to return a list of allowed vertical <see cref="Godot.Control.SizeFlags"/> for child nodes. This doesn't technically prevent the usages of any other size flags, if your implementation requires that. This only limits the options available to the user in the Inspector dock.</para>
    /// <para><b>Note:</b> Having no size flags is equal to having <see cref="Godot.Control.SizeFlags.ShrinkBegin"/>. As such, this value is always implicitly allowed.</para>
    /// </summary>
    public virtual int[] _GetAllowedSizeFlagsVertical()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueueSort, 3218959716ul);

    /// <summary>
    /// <para>Queue resort of the contained children. This is called automatically anyway, but can be called upon request.</para>
    /// </summary>
    public void QueueSort()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FitChildInRect, 1993438598ul);

    /// <summary>
    /// <para>Fit a child control in a given rect. This is mainly a helper for creating custom container classes.</para>
    /// </summary>
    public unsafe void FitChildInRect(Control child, Rect2 rect)
    {
        NativeCalls.godot_icall_2_256(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(child), &rect);
    }

    /// <summary>
    /// <para>Emitted when children are going to be sorted.</para>
    /// </summary>
    public event Action PreSortChildren
    {
        add => Connect(SignalName.PreSortChildren, Callable.From(value));
        remove => Disconnect(SignalName.PreSortChildren, Callable.From(value));
    }

    protected void EmitSignalPreSortChildren()
    {
        EmitSignal(SignalName.PreSortChildren);
    }

    /// <summary>
    /// <para>Emitted when sorting the children is needed.</para>
    /// </summary>
    public event Action SortChildren
    {
        add => Connect(SignalName.SortChildren, Callable.From(value));
        remove => Disconnect(SignalName.SortChildren, Callable.From(value));
    }

    protected void EmitSignalSortChildren()
    {
        EmitSignal(SignalName.SortChildren);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_allowed_size_flags_horizontal = "_GetAllowedSizeFlagsHorizontal";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_allowed_size_flags_vertical = "_GetAllowedSizeFlagsVertical";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_pre_sort_children = "PreSortChildren";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_sort_children = "SortChildren";

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
        if ((method == MethodProxyName__get_allowed_size_flags_horizontal || method == MethodName._GetAllowedSizeFlagsHorizontal) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_allowed_size_flags_horizontal.NativeValue))
        {
            var callRet = _GetAllowedSizeFlagsHorizontal();
            ret = VariantUtils.CreateFrom<int[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_allowed_size_flags_vertical || method == MethodName._GetAllowedSizeFlagsVertical) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_allowed_size_flags_vertical.NativeValue))
        {
            var callRet = _GetAllowedSizeFlagsVertical();
            ret = VariantUtils.CreateFrom<int[]>(callRet);
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
        if (method == MethodName._GetAllowedSizeFlagsHorizontal)
        {
            if (HasGodotClassMethod(MethodProxyName__get_allowed_size_flags_horizontal.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAllowedSizeFlagsVertical)
        {
            if (HasGodotClassMethod(MethodProxyName__get_allowed_size_flags_vertical.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.PreSortChildren)
        {
            if (HasGodotClassSignal(SignalProxyName_pre_sort_children.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SortChildren)
        {
            if (HasGodotClassSignal(SignalProxyName_sort_children.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Control.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_allowed_size_flags_horizontal' method.
        /// </summary>
        public static readonly StringName _GetAllowedSizeFlagsHorizontal = "_get_allowed_size_flags_horizontal";
        /// <summary>
        /// Cached name for the '_get_allowed_size_flags_vertical' method.
        /// </summary>
        public static readonly StringName _GetAllowedSizeFlagsVertical = "_get_allowed_size_flags_vertical";
        /// <summary>
        /// Cached name for the 'queue_sort' method.
        /// </summary>
        public static readonly StringName QueueSort = "queue_sort";
        /// <summary>
        /// Cached name for the 'fit_child_in_rect' method.
        /// </summary>
        public static readonly StringName FitChildInRect = "fit_child_in_rect";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'pre_sort_children' signal.
        /// </summary>
        public static readonly StringName PreSortChildren = "pre_sort_children";
        /// <summary>
        /// Cached name for the 'sort_children' signal.
        /// </summary>
        public static readonly StringName SortChildren = "sort_children";
    }
}
