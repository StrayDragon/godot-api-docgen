namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This helper node will automatically manage displaying render models. It will create new <see cref="Godot.OpenXRRenderModel"/> nodes as controllers and other hand held devices are detected, and remove those nodes when they are deactivated.</para>
/// <para><b>Note:</b> If you want more control over this logic you can alternatively call <see cref="Godot.OpenXRRenderModelExtension.RenderModelGetAll()"/> to obtain a list of active render model ids and create <see cref="Godot.OpenXRRenderModel"/> instances for each render model id provided.</para>
/// </summary>
public partial class OpenXRRenderModelManager : Node3D
{
    public enum RenderModelTracker : long
    {
        /// <summary>
        /// <para>All active render models are shown regardless of what tracker they relate to.</para>
        /// </summary>
        Any = 0,
        /// <summary>
        /// <para>Only active render models are shown that are not related to any tracker we manage.</para>
        /// </summary>
        NoneSet = 1,
        /// <summary>
        /// <para>Only active render models are shown that are related to the left hand tracker.</para>
        /// </summary>
        LeftHand = 2,
        /// <summary>
        /// <para>Only active render models are shown that are related to the right hand tracker.</para>
        /// </summary>
        RightHand = 3
    }

    /// <summary>
    /// <para>Limits render models to the specified tracker. Include: 0 = All render models, 1 = Render models not related to a tracker, 2 = Render models related to the left hand tracker, 3 = Render models related to the right hand tracker.</para>
    /// </summary>
    public OpenXRRenderModelManager.RenderModelTracker Tracker
    {
        get
        {
            return GetTracker();
        }
        set
        {
            SetTracker(value);
        }
    }

    /// <summary>
    /// <para>Position render models local to this pose (this will adjust the position of the render models container node).</para>
    /// </summary>
    public string MakeLocalToPose
    {
        get
        {
            return GetMakeLocalToPose();
        }
        set
        {
            SetMakeLocalToPose(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRRenderModelManager);

    private static readonly StringName NativeName = "OpenXRRenderModelManager";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRRenderModelManager() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRRenderModelManager(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRRenderModelManager(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTracker, 2456466356ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRRenderModelManager.RenderModelTracker GetTracker()
    {
        return (OpenXRRenderModelManager.RenderModelTracker)NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTracker, 2814627380ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTracker(OpenXRRenderModelManager.RenderModelTracker tracker)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), (int)tracker);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMakeLocalToPose, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetMakeLocalToPose()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMakeLocalToPose, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMakeLocalToPose(string makeLocalToPose)
    {
        NativeCalls.godot_icall_1_57(MethodBind3, GodotObject.GetPtr(this), makeLocalToPose);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRRenderModelManager.RenderModelAdded"/> event of a <see cref="Godot.OpenXRRenderModelManager"/> class.
    /// </summary>
    public delegate void RenderModelAddedEventHandler(OpenXRRenderModel renderModel);

    private static void RenderModelAddedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((RenderModelAddedEventHandler)delegateObj)(VariantUtils.ConvertTo<OpenXRRenderModel>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a render model node is added as a child to this node.</para>
    /// </summary>
    public unsafe event RenderModelAddedEventHandler RenderModelAdded
    {
        add => Connect(SignalName.RenderModelAdded, Callable.CreateWithUnsafeTrampoline(value, &RenderModelAddedTrampoline));
        remove => Disconnect(SignalName.RenderModelAdded, Callable.CreateWithUnsafeTrampoline(value, &RenderModelAddedTrampoline));
    }

    protected void EmitSignalRenderModelAdded(OpenXRRenderModel renderModel)
    {
        EmitSignal(SignalName.RenderModelAdded, renderModel);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRRenderModelManager.RenderModelRemoved"/> event of a <see cref="Godot.OpenXRRenderModelManager"/> class.
    /// </summary>
    public delegate void RenderModelRemovedEventHandler(OpenXRRenderModel renderModel);

    private static void RenderModelRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((RenderModelRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<OpenXRRenderModel>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a render model child node is about to be removed from this node.</para>
    /// </summary>
    public unsafe event RenderModelRemovedEventHandler RenderModelRemoved
    {
        add => Connect(SignalName.RenderModelRemoved, Callable.CreateWithUnsafeTrampoline(value, &RenderModelRemovedTrampoline));
        remove => Disconnect(SignalName.RenderModelRemoved, Callable.CreateWithUnsafeTrampoline(value, &RenderModelRemovedTrampoline));
    }

    protected void EmitSignalRenderModelRemoved(OpenXRRenderModel renderModel)
    {
        EmitSignal(SignalName.RenderModelRemoved, renderModel);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_render_model_added = "RenderModelAdded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_render_model_removed = "RenderModelRemoved";

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
        if (signal == SignalName.RenderModelAdded)
        {
            if (HasGodotClassSignal(SignalProxyName_render_model_added.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.RenderModelRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_render_model_removed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'tracker' property.
        /// </summary>
        public static readonly StringName Tracker = "tracker";
        /// <summary>
        /// Cached name for the 'make_local_to_pose' property.
        /// </summary>
        public static readonly StringName MakeLocalToPose = "make_local_to_pose";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_tracker' method.
        /// </summary>
        public static readonly StringName GetTracker = "get_tracker";
        /// <summary>
        /// Cached name for the 'set_tracker' method.
        /// </summary>
        public static readonly StringName SetTracker = "set_tracker";
        /// <summary>
        /// Cached name for the 'get_make_local_to_pose' method.
        /// </summary>
        public static readonly StringName GetMakeLocalToPose = "get_make_local_to_pose";
        /// <summary>
        /// Cached name for the 'set_make_local_to_pose' method.
        /// </summary>
        public static readonly StringName SetMakeLocalToPose = "set_make_local_to_pose";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'render_model_added' signal.
        /// </summary>
        public static readonly StringName RenderModelAdded = "render_model_added";
        /// <summary>
        /// Cached name for the 'render_model_removed' signal.
        /// </summary>
        public static readonly StringName RenderModelRemoved = "render_model_removed";
    }
}
