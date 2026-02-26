namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class allows for a RenderData implementation to be made in GDExtension.</para>
/// </summary>
public partial class RenderDataExtension : RenderData
{
    private static readonly System.Type CachedType = typeof(RenderDataExtension);

    private static readonly StringName NativeName = "RenderDataExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RenderDataExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal RenderDataExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RenderDataExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Implement this in GDExtension to return the <see cref="Godot.Rid"/> for the implementation's camera attributes object.</para>
    /// </summary>
    public virtual Rid _GetCameraAttributes()
    {
        return default;
    }

    /// <summary>
    /// <para>Implement this in GDExtension to return the <see cref="Godot.Rid"/> of the implementation's environment object.</para>
    /// </summary>
    public virtual Rid _GetEnvironment()
    {
        return default;
    }

    /// <summary>
    /// <para>Implement this in GDExtension to return the implementation's <see cref="Godot.RenderSceneBuffers"/> object.</para>
    /// </summary>
    public virtual RenderSceneBuffers _GetRenderSceneBuffers()
    {
        return default;
    }

    /// <summary>
    /// <para>Implement this in GDExtension to return the implementation's <see cref="Godot.RenderSceneDataExtension"/> object.</para>
    /// </summary>
    public virtual RenderSceneData _GetRenderSceneData()
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_camera_attributes = "_GetCameraAttributes";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_environment = "_GetEnvironment";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_render_scene_buffers = "_GetRenderSceneBuffers";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_render_scene_data = "_GetRenderSceneData";

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
        if ((method == MethodProxyName__get_camera_attributes || method == MethodName._GetCameraAttributes) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_camera_attributes.NativeValue))
        {
            var callRet = _GetCameraAttributes();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_environment || method == MethodName._GetEnvironment) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_environment.NativeValue))
        {
            var callRet = _GetEnvironment();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_render_scene_buffers || method == MethodName._GetRenderSceneBuffers) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_render_scene_buffers.NativeValue))
        {
            var callRet = _GetRenderSceneBuffers();
            ret = VariantUtils.CreateFrom<RenderSceneBuffers>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_render_scene_data || method == MethodName._GetRenderSceneData) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_render_scene_data.NativeValue))
        {
            var callRet = _GetRenderSceneData();
            ret = VariantUtils.CreateFrom<RenderSceneData>(callRet);
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
        if (method == MethodName._GetCameraAttributes)
        {
            if (HasGodotClassMethod(MethodProxyName__get_camera_attributes.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetEnvironment)
        {
            if (HasGodotClassMethod(MethodProxyName__get_environment.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetRenderSceneBuffers)
        {
            if (HasGodotClassMethod(MethodProxyName__get_render_scene_buffers.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetRenderSceneData)
        {
            if (HasGodotClassMethod(MethodProxyName__get_render_scene_data.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : RenderData.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RenderData.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_camera_attributes' method.
        /// </summary>
        public static readonly StringName _GetCameraAttributes = "_get_camera_attributes";
        /// <summary>
        /// Cached name for the '_get_environment' method.
        /// </summary>
        public static readonly StringName _GetEnvironment = "_get_environment";
        /// <summary>
        /// Cached name for the '_get_render_scene_buffers' method.
        /// </summary>
        public static readonly StringName _GetRenderSceneBuffers = "_get_render_scene_buffers";
        /// <summary>
        /// Cached name for the '_get_render_scene_data' method.
        /// </summary>
        public static readonly StringName _GetRenderSceneData = "_get_render_scene_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RenderData.SignalName
    {
    }
}
