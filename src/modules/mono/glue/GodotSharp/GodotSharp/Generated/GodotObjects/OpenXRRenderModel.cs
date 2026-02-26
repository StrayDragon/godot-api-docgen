namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node will display an OpenXR render model by accessing the associated GLTF and processes all animation data (if supported by the XR runtime).</para>
/// <para>Render models were introduced to allow showing the correct model for the controller (or other device) the user has in hand, since the OpenXR action map does not provide information about the hardware used by the user. Note that while the controller (or device) can be somewhat inferred by the bound action map profile, this is a dangerous approach as the user may be using hardware not known at time of development and OpenXR will simply simulate an available interaction profile.</para>
/// </summary>
public partial class OpenXRRenderModel : Node3D
{
    /// <summary>
    /// <para>The render model RID for the render model to load, as returned by <see cref="Godot.OpenXRRenderModelExtension.RenderModelCreate(ulong)"/> or <see cref="Godot.OpenXRRenderModelExtension.RenderModelGetAll()"/>.</para>
    /// </summary>
    public Rid RenderModel
    {
        get
        {
            return GetRenderModel();
        }
        set
        {
            SetRenderModel(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRRenderModel);

    private static readonly StringName NativeName = "OpenXRRenderModel";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRRenderModel() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRRenderModel(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRRenderModel(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTopLevelPath, 201670096ul);

    /// <summary>
    /// <para>Returns the top level path related to this render model.</para>
    /// </summary>
    public string GetTopLevelPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderModel, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetRenderModel()
    {
        return NativeCalls.godot_icall_0_238(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderModel, 2722037293ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRenderModel(Rid renderModel)
    {
        NativeCalls.godot_icall_1_286(MethodBind2, GodotObject.GetPtr(this), renderModel);
    }

    /// <summary>
    /// <para>Emitted when the top level path of this render model has changed.</para>
    /// </summary>
    public event Action RenderModelTopLevelPathChanged
    {
        add => Connect(SignalName.RenderModelTopLevelPathChanged, Callable.From(value));
        remove => Disconnect(SignalName.RenderModelTopLevelPathChanged, Callable.From(value));
    }

    protected void EmitSignalRenderModelTopLevelPathChanged()
    {
        EmitSignal(SignalName.RenderModelTopLevelPathChanged);
    }

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
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'render_model' property.
        /// </summary>
        public static readonly StringName RenderModel = "render_model";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_top_level_path' method.
        /// </summary>
        public static readonly StringName GetTopLevelPath = "get_top_level_path";
        /// <summary>
        /// Cached name for the 'get_render_model' method.
        /// </summary>
        public static readonly StringName GetRenderModel = "get_render_model";
        /// <summary>
        /// Cached name for the 'set_render_model' method.
        /// </summary>
        public static readonly StringName SetRenderModel = "set_render_model";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'render_model_top_level_path_changed' signal.
        /// </summary>
        public static readonly StringName RenderModelTopLevelPathChanged = "render_model_top_level_path_changed";
    }
}
