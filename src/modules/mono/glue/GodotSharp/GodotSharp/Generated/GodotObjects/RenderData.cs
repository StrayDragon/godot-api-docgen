namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstract render data object, exists for the duration of rendering a single viewport. See also <see cref="Godot.RenderDataRD"/>, <see cref="Godot.RenderSceneData"/>, and <see cref="Godot.RenderSceneDataRD"/>.</para>
/// <para><b>Note:</b> This is an internal rendering server object. Do not instantiate this class from a script.</para>
/// </summary>
public partial class RenderData : GodotObject
{
    private static readonly System.Type CachedType = typeof(RenderData);

    private static readonly StringName NativeName = "RenderData";

    internal RenderData() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RenderData(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RenderData(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderSceneBuffers, 2793216201ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.RenderSceneBuffers"/> object managing the scene buffers for rendering this viewport.</para>
    /// </summary>
    public RenderSceneBuffers GetRenderSceneBuffers()
    {
        return (RenderSceneBuffers)NativeCalls.godot_icall_0_63(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderSceneData, 1288715698ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.RenderSceneData"/> object managing this frames scene data.</para>
    /// </summary>
    public RenderSceneData GetRenderSceneData()
    {
        return (RenderSceneData)NativeCalls.godot_icall_0_53(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironment, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the environment object in the <see cref="Godot.RenderingServer"/> being used to render this viewport.</para>
    /// </summary>
    public Rid GetEnvironment()
    {
        return NativeCalls.godot_icall_0_238(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraAttributes, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the camera attributes object in the <see cref="Godot.RenderingServer"/> being used to render this viewport.</para>
    /// </summary>
    public Rid GetCameraAttributes()
    {
        return NativeCalls.godot_icall_0_238(MethodBind3, GodotObject.GetPtr(this));
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_render_scene_buffers' method.
        /// </summary>
        public static readonly StringName GetRenderSceneBuffers = "get_render_scene_buffers";
        /// <summary>
        /// Cached name for the 'get_render_scene_data' method.
        /// </summary>
        public static readonly StringName GetRenderSceneData = "get_render_scene_data";
        /// <summary>
        /// Cached name for the 'get_environment' method.
        /// </summary>
        public static readonly StringName GetEnvironment = "get_environment";
        /// <summary>
        /// Cached name for the 'get_camera_attributes' method.
        /// </summary>
        public static readonly StringName GetCameraAttributes = "get_camera_attributes";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
