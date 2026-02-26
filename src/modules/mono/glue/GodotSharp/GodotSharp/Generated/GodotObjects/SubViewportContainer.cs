namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A container that displays the contents of underlying <see cref="Godot.SubViewport"/> child nodes. It uses the combined size of the <see cref="Godot.SubViewport"/>s as minimum size, unless <see cref="Godot.SubViewportContainer.Stretch"/> is enabled.</para>
/// <para><b>Note:</b> Changing a <see cref="Godot.SubViewportContainer"/>'s <see cref="Godot.Control.Scale"/> will cause its contents to appear distorted. To change its visual size without causing distortion, adjust the node's margins instead (if it's not already in a container).</para>
/// <para><b>Note:</b> The <see cref="Godot.SubViewportContainer"/> forwards mouse-enter and mouse-exit notifications to its sub-viewports.</para>
/// </summary>
public partial class SubViewportContainer : Container
{
    /// <summary>
    /// <para>If <see langword="true"/>, the sub-viewport will be automatically resized to the control's size.</para>
    /// <para><b>Note:</b> If <see langword="true"/>, this will prohibit changing <see cref="Godot.SubViewport.Size"/> of its children manually.</para>
    /// </summary>
    public bool Stretch
    {
        get
        {
            return IsStretchEnabled();
        }
        set
        {
            SetStretch(value);
        }
    }

    /// <summary>
    /// <para>Divides the sub-viewport's effective resolution by this value while preserving its scale. This can be used to speed up rendering.</para>
    /// <para>For example, a 1280×720 sub-viewport with <see cref="Godot.SubViewportContainer.StretchShrink"/> set to <c>2</c> will be rendered at 640×360 while occupying the same size in the container.</para>
    /// <para><b>Note:</b> <see cref="Godot.SubViewportContainer.Stretch"/> must be <see langword="true"/> for this property to work.</para>
    /// </summary>
    public int StretchShrink
    {
        get
        {
            return GetStretchShrink();
        }
        set
        {
            SetStretchShrink(value);
        }
    }

    /// <summary>
    /// <para>Configure, if either the <see cref="Godot.SubViewportContainer"/> or alternatively the <see cref="Godot.Control"/> nodes of its <see cref="Godot.SubViewport"/> children should be available as targets of mouse-related functionalities, like identifying the drop target in drag-and-drop operations or cursor shape of hovered <see cref="Godot.Control"/> node.</para>
    /// <para>If <see langword="false"/>, the <see cref="Godot.Control"/> nodes inside its <see cref="Godot.SubViewport"/> children are considered as targets.</para>
    /// <para>If <see langword="true"/>, the <see cref="Godot.SubViewportContainer"/> itself will be considered as a target.</para>
    /// </summary>
    public bool MouseTarget
    {
        get
        {
            return IsMouseTargetEnabled();
        }
        set
        {
            SetMouseTarget(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SubViewportContainer);

    private static readonly StringName NativeName = "SubViewportContainer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SubViewportContainer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SubViewportContainer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SubViewportContainer(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Virtual method to be implemented by the user. If it returns <see langword="true"/>, the <paramref name="event"/> is propagated to <see cref="Godot.SubViewport"/> children. Propagation doesn't happen if it returns <see langword="false"/>. If the function is not implemented, all events are propagated to SubViewports.</para>
    /// </summary>
    public virtual bool _PropagateInputEvent(InputEvent @event)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStretch, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStretch(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsStretchEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsStretchEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStretchShrink, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStretchShrink(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStretchShrink, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetStretchShrink()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMouseTarget, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMouseTarget(bool amount)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), amount.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMouseTargetEnabled, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMouseTargetEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__propagate_input_event = "_PropagateInputEvent";

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
        if ((method == MethodProxyName__propagate_input_event || method == MethodName._PropagateInputEvent) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__propagate_input_event.NativeValue))
        {
            var callRet = _PropagateInputEvent(VariantUtils.ConvertTo<InputEvent>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName._PropagateInputEvent)
        {
            if (HasGodotClassMethod(MethodProxyName__propagate_input_event.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : Container.PropertyName
    {
        /// <summary>
        /// Cached name for the 'stretch' property.
        /// </summary>
        public static readonly StringName Stretch = "stretch";
        /// <summary>
        /// Cached name for the 'stretch_shrink' property.
        /// </summary>
        public static readonly StringName StretchShrink = "stretch_shrink";
        /// <summary>
        /// Cached name for the 'mouse_target' property.
        /// </summary>
        public static readonly StringName MouseTarget = "mouse_target";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Container.MethodName
    {
        /// <summary>
        /// Cached name for the '_propagate_input_event' method.
        /// </summary>
        public static readonly StringName _PropagateInputEvent = "_propagate_input_event";
        /// <summary>
        /// Cached name for the 'set_stretch' method.
        /// </summary>
        public static readonly StringName SetStretch = "set_stretch";
        /// <summary>
        /// Cached name for the 'is_stretch_enabled' method.
        /// </summary>
        public static readonly StringName IsStretchEnabled = "is_stretch_enabled";
        /// <summary>
        /// Cached name for the 'set_stretch_shrink' method.
        /// </summary>
        public static readonly StringName SetStretchShrink = "set_stretch_shrink";
        /// <summary>
        /// Cached name for the 'get_stretch_shrink' method.
        /// </summary>
        public static readonly StringName GetStretchShrink = "get_stretch_shrink";
        /// <summary>
        /// Cached name for the 'set_mouse_target' method.
        /// </summary>
        public static readonly StringName SetMouseTarget = "set_mouse_target";
        /// <summary>
        /// Cached name for the 'is_mouse_target_enabled' method.
        /// </summary>
        public static readonly StringName IsMouseTargetEnabled = "is_mouse_target_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Container.SignalName
    {
    }
}
