namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class implements the OpenXR Render Model Extension, if enabled it will maintain a list of active render models and provides an interface to the render model data.</para>
/// </summary>
public partial class OpenXRRenderModelExtension : OpenXRExtensionWrapper
{
    private static readonly System.Type CachedType = typeof(OpenXRRenderModelExtension);

    private static readonly StringName NativeName = "OpenXRRenderModelExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRRenderModelExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRRenderModelExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRRenderModelExtension(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActive, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if OpenXR's render model extension is supported and enabled.</para>
    /// <para><b>Note:</b> This only returns a valid value after OpenXR has been initialized.</para>
    /// </summary>
    public bool IsActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelCreate, 937000113ul);

    /// <summary>
    /// <para>Creates a render model object within OpenXR using a render model id.</para>
    /// <para><b>Note:</b> This function is exposed for dependent OpenXR extensions that provide render model ids to be used with the render model extension.</para>
    /// </summary>
    public Rid RenderModelCreate(ulong renderModelId)
    {
        return NativeCalls.godot_icall_1_932(MethodBind1, GodotObject.GetPtr(this), renderModelId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelDestroy, 2722037293ul);

    /// <summary>
    /// <para>Destroys a render model object within OpenXR that was previously created with <see cref="Godot.OpenXRRenderModelExtension.RenderModelCreate(ulong)"/>.</para>
    /// <para><b>Note:</b> This function is exposed for dependent OpenXR extensions that provide render model ids to be used with the render model extension.</para>
    /// </summary>
    public void RenderModelDestroy(Rid renderModel)
    {
        NativeCalls.godot_icall_1_286(MethodBind2, GodotObject.GetPtr(this), renderModel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelGetAll, 2915620761ul);

    /// <summary>
    /// <para>Returns an array of all currently active render models registered with this extension.</para>
    /// </summary>
    public Godot.Collections.Array<Rid> RenderModelGetAll()
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_0_120(MethodBind3, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelNewSceneInstance, 788010739ul);

    /// <summary>
    /// <para>Returns an instance of a subscene that contains all <see cref="Godot.MeshInstance3D"/> nodes that allow you to visualize the render model.</para>
    /// </summary>
    public Node3D RenderModelNewSceneInstance(Rid renderModel)
    {
        return (Node3D)NativeCalls.godot_icall_1_938(MethodBind4, GodotObject.GetPtr(this), renderModel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelGetSubactionPaths, 2801473409ul);

    /// <summary>
    /// <para>Returns a list of active subaction paths for this <paramref name="renderModel"/>.</para>
    /// <para><b>Note:</b> If different devices are bound to your actions than available in suggested interaction bindings, this information shows paths related to the interaction bindings being mimicked by that device.</para>
    /// </summary>
    public string[] RenderModelGetSubactionPaths(Rid renderModel)
    {
        return NativeCalls.godot_icall_1_939(MethodBind5, GodotObject.GetPtr(this), renderModel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelGetTopLevelPath, 642473191ul);

    /// <summary>
    /// <para>Returns the top level path associated with this <paramref name="renderModel"/>. If provided this identifies whether the render model is associated with the player's hands or other body part.</para>
    /// </summary>
    public string RenderModelGetTopLevelPath(Rid renderModel)
    {
        return NativeCalls.godot_icall_1_940(MethodBind6, GodotObject.GetPtr(this), renderModel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelGetConfidence, 2350330949ul);

    /// <summary>
    /// <para>Returns the tracking confidence of the tracking data for the render model.</para>
    /// </summary>
    public XRPose.TrackingConfidenceEnum RenderModelGetConfidence(Rid renderModel)
    {
        return (XRPose.TrackingConfidenceEnum)NativeCalls.godot_icall_1_835(MethodBind7, GodotObject.GetPtr(this), renderModel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelGetRootTransform, 1128465797ul);

    /// <summary>
    /// <para>Returns the root transform of a render model. This is the tracked position relative to our <see cref="Godot.XROrigin3D"/> node.</para>
    /// </summary>
    public Transform3D RenderModelGetRootTransform(Rid renderModel)
    {
        return NativeCalls.godot_icall_1_874(MethodBind8, GodotObject.GetPtr(this), renderModel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelGetAnimatableNodeCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of animatable nodes this render model has.</para>
    /// </summary>
    public uint RenderModelGetAnimatableNodeCount(Rid renderModel)
    {
        return NativeCalls.godot_icall_1_850(MethodBind9, GodotObject.GetPtr(this), renderModel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelGetAnimatableNodeName, 1464764419ul);

    /// <summary>
    /// <para>Returns the name of the given animatable node.</para>
    /// </summary>
    public string RenderModelGetAnimatableNodeName(Rid renderModel, uint index)
    {
        return NativeCalls.godot_icall_2_941(MethodBind10, GodotObject.GetPtr(this), renderModel, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelIsAnimatableNodeVisible, 3120086654ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this animatable node should be visible.</para>
    /// </summary>
    public bool RenderModelIsAnimatableNodeVisible(Rid renderModel, uint index)
    {
        return NativeCalls.godot_icall_2_942(MethodBind11, GodotObject.GetPtr(this), renderModel, index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderModelGetAnimatableNodeTransform, 1050775521ul);

    /// <summary>
    /// <para>Returns the current local transform for an animatable node. This is updated every frame.</para>
    /// </summary>
    public Transform3D RenderModelGetAnimatableNodeTransform(Rid renderModel, uint index)
    {
        return NativeCalls.godot_icall_2_943(MethodBind12, GodotObject.GetPtr(this), renderModel, index);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRRenderModelExtension.RenderModelAdded"/> event of a <see cref="Godot.OpenXRRenderModelExtension"/> class.
    /// </summary>
    public delegate void RenderModelAddedEventHandler(Rid renderModel);

    private static void RenderModelAddedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((RenderModelAddedEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a new render model is added.</para>
    /// </summary>
    public unsafe event RenderModelAddedEventHandler RenderModelAdded
    {
        add => Connect(SignalName.RenderModelAdded, Callable.CreateWithUnsafeTrampoline(value, &RenderModelAddedTrampoline));
        remove => Disconnect(SignalName.RenderModelAdded, Callable.CreateWithUnsafeTrampoline(value, &RenderModelAddedTrampoline));
    }

    protected void EmitSignalRenderModelAdded(Rid renderModel)
    {
        EmitSignal(SignalName.RenderModelAdded, renderModel);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRRenderModelExtension.RenderModelRemoved"/> event of a <see cref="Godot.OpenXRRenderModelExtension"/> class.
    /// </summary>
    public delegate void RenderModelRemovedEventHandler(Rid renderModel);

    private static void RenderModelRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((RenderModelRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a render model is removed.</para>
    /// </summary>
    public unsafe event RenderModelRemovedEventHandler RenderModelRemoved
    {
        add => Connect(SignalName.RenderModelRemoved, Callable.CreateWithUnsafeTrampoline(value, &RenderModelRemovedTrampoline));
        remove => Disconnect(SignalName.RenderModelRemoved, Callable.CreateWithUnsafeTrampoline(value, &RenderModelRemovedTrampoline));
    }

    protected void EmitSignalRenderModelRemoved(Rid renderModel)
    {
        EmitSignal(SignalName.RenderModelRemoved, renderModel);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRRenderModelExtension.RenderModelTopLevelPathChanged"/> event of a <see cref="Godot.OpenXRRenderModelExtension"/> class.
    /// </summary>
    public delegate void RenderModelTopLevelPathChangedEventHandler(Rid renderModel);

    private static void RenderModelTopLevelPathChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((RenderModelTopLevelPathChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the top level path associated with a render model changed.</para>
    /// </summary>
    public unsafe event RenderModelTopLevelPathChangedEventHandler RenderModelTopLevelPathChanged
    {
        add => Connect(SignalName.RenderModelTopLevelPathChanged, Callable.CreateWithUnsafeTrampoline(value, &RenderModelTopLevelPathChangedTrampoline));
        remove => Disconnect(SignalName.RenderModelTopLevelPathChanged, Callable.CreateWithUnsafeTrampoline(value, &RenderModelTopLevelPathChangedTrampoline));
    }

    protected void EmitSignalRenderModelTopLevelPathChanged(Rid renderModel)
    {
        EmitSignal(SignalName.RenderModelTopLevelPathChanged, renderModel);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_render_model_added = "RenderModelAdded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_render_model_removed = "RenderModelRemoved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_render_model_top_level_path_changed = "RenderModelTopLevelPathChanged";

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
        if (signal == SignalName.RenderModelTopLevelPathChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_render_model_top_level_path_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : OpenXRExtensionWrapper.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRExtensionWrapper.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_active' method.
        /// </summary>
        public static readonly StringName IsActive = "is_active";
        /// <summary>
        /// Cached name for the 'render_model_create' method.
        /// </summary>
        public static readonly StringName RenderModelCreate = "render_model_create";
        /// <summary>
        /// Cached name for the 'render_model_destroy' method.
        /// </summary>
        public static readonly StringName RenderModelDestroy = "render_model_destroy";
        /// <summary>
        /// Cached name for the 'render_model_get_all' method.
        /// </summary>
        public static readonly StringName RenderModelGetAll = "render_model_get_all";
        /// <summary>
        /// Cached name for the 'render_model_new_scene_instance' method.
        /// </summary>
        public static readonly StringName RenderModelNewSceneInstance = "render_model_new_scene_instance";
        /// <summary>
        /// Cached name for the 'render_model_get_subaction_paths' method.
        /// </summary>
        public static readonly StringName RenderModelGetSubactionPaths = "render_model_get_subaction_paths";
        /// <summary>
        /// Cached name for the 'render_model_get_top_level_path' method.
        /// </summary>
        public static readonly StringName RenderModelGetTopLevelPath = "render_model_get_top_level_path";
        /// <summary>
        /// Cached name for the 'render_model_get_confidence' method.
        /// </summary>
        public static readonly StringName RenderModelGetConfidence = "render_model_get_confidence";
        /// <summary>
        /// Cached name for the 'render_model_get_root_transform' method.
        /// </summary>
        public static readonly StringName RenderModelGetRootTransform = "render_model_get_root_transform";
        /// <summary>
        /// Cached name for the 'render_model_get_animatable_node_count' method.
        /// </summary>
        public static readonly StringName RenderModelGetAnimatableNodeCount = "render_model_get_animatable_node_count";
        /// <summary>
        /// Cached name for the 'render_model_get_animatable_node_name' method.
        /// </summary>
        public static readonly StringName RenderModelGetAnimatableNodeName = "render_model_get_animatable_node_name";
        /// <summary>
        /// Cached name for the 'render_model_is_animatable_node_visible' method.
        /// </summary>
        public static readonly StringName RenderModelIsAnimatableNodeVisible = "render_model_is_animatable_node_visible";
        /// <summary>
        /// Cached name for the 'render_model_get_animatable_node_transform' method.
        /// </summary>
        public static readonly StringName RenderModelGetAnimatableNodeTransform = "render_model_get_animatable_node_transform";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRExtensionWrapper.SignalName
    {
        /// <summary>
        /// Cached name for the 'render_model_added' signal.
        /// </summary>
        public static readonly StringName RenderModelAdded = "render_model_added";
        /// <summary>
        /// Cached name for the 'render_model_removed' signal.
        /// </summary>
        public static readonly StringName RenderModelRemoved = "render_model_removed";
        /// <summary>
        /// Cached name for the 'render_model_top_level_path_changed' signal.
        /// </summary>
        public static readonly StringName RenderModelTopLevelPathChanged = "render_model_top_level_path_changed";
    }
}
