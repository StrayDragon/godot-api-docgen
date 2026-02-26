namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class allows for a RenderSceneData implementation to be made in GDExtension.</para>
/// </summary>
public partial class RenderSceneDataExtension : RenderSceneData
{
    private static readonly System.Type CachedType = typeof(RenderSceneDataExtension);

    private static readonly StringName NativeName = "RenderSceneDataExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RenderSceneDataExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal RenderSceneDataExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RenderSceneDataExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Implement this in GDExtension to return the camera <see cref="Godot.Projection"/>.</para>
    /// </summary>
    public virtual Projection _GetCamProjection()
    {
        return default;
    }

    /// <summary>
    /// <para>Implement this in GDExtension to return the camera <see cref="Godot.Transform3D"/>.</para>
    /// </summary>
    public virtual Transform3D _GetCamTransform()
    {
        return default;
    }

    /// <summary>
    /// <para>Implement this in GDExtension to return the <see cref="Godot.Rid"/> of the uniform buffer containing the scene data as a UBO.</para>
    /// </summary>
    public virtual Rid _GetUniformBuffer()
    {
        return default;
    }

    /// <summary>
    /// <para>Implement this in GDExtension to return the view count.</para>
    /// </summary>
    public virtual uint _GetViewCount()
    {
        return default;
    }

    /// <summary>
    /// <para>Implement this in GDExtension to return the eye offset for the given <paramref name="view"/>.</para>
    /// </summary>
    public virtual Vector3 _GetViewEyeOffset(uint view)
    {
        return default;
    }

    /// <summary>
    /// <para>Implement this in GDExtension to return the view <see cref="Godot.Projection"/> for the given <paramref name="view"/>.</para>
    /// </summary>
    public virtual Projection _GetViewProjection(uint view)
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_cam_projection = "_GetCamProjection";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_cam_transform = "_GetCamTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_uniform_buffer = "_GetUniformBuffer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_view_count = "_GetViewCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_view_eye_offset = "_GetViewEyeOffset";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_view_projection = "_GetViewProjection";

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
        if ((method == MethodProxyName__get_cam_projection || method == MethodName._GetCamProjection) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_cam_projection.NativeValue))
        {
            var callRet = _GetCamProjection();
            ret = VariantUtils.CreateFrom<Projection>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_cam_transform || method == MethodName._GetCamTransform) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_cam_transform.NativeValue))
        {
            var callRet = _GetCamTransform();
            ret = VariantUtils.CreateFrom<Transform3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_uniform_buffer || method == MethodName._GetUniformBuffer) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_uniform_buffer.NativeValue))
        {
            var callRet = _GetUniformBuffer();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_view_count || method == MethodName._GetViewCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_view_count.NativeValue))
        {
            var callRet = _GetViewCount();
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_view_eye_offset || method == MethodName._GetViewEyeOffset) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_view_eye_offset.NativeValue))
        {
            var callRet = _GetViewEyeOffset(VariantUtils.ConvertTo<uint>(args[0]));
            ret = VariantUtils.CreateFrom<Vector3>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_view_projection || method == MethodName._GetViewProjection) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_view_projection.NativeValue))
        {
            var callRet = _GetViewProjection(VariantUtils.ConvertTo<uint>(args[0]));
            ret = VariantUtils.CreateFrom<Projection>(callRet);
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
        if (method == MethodName._GetCamProjection)
        {
            if (HasGodotClassMethod(MethodProxyName__get_cam_projection.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetCamTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__get_cam_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetUniformBuffer)
        {
            if (HasGodotClassMethod(MethodProxyName__get_uniform_buffer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetViewCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_view_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetViewEyeOffset)
        {
            if (HasGodotClassMethod(MethodProxyName__get_view_eye_offset.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetViewProjection)
        {
            if (HasGodotClassMethod(MethodProxyName__get_view_projection.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : RenderSceneData.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RenderSceneData.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_cam_projection' method.
        /// </summary>
        public static readonly StringName _GetCamProjection = "_get_cam_projection";
        /// <summary>
        /// Cached name for the '_get_cam_transform' method.
        /// </summary>
        public static readonly StringName _GetCamTransform = "_get_cam_transform";
        /// <summary>
        /// Cached name for the '_get_uniform_buffer' method.
        /// </summary>
        public static readonly StringName _GetUniformBuffer = "_get_uniform_buffer";
        /// <summary>
        /// Cached name for the '_get_view_count' method.
        /// </summary>
        public static readonly StringName _GetViewCount = "_get_view_count";
        /// <summary>
        /// Cached name for the '_get_view_eye_offset' method.
        /// </summary>
        public static readonly StringName _GetViewEyeOffset = "_get_view_eye_offset";
        /// <summary>
        /// Cached name for the '_get_view_projection' method.
        /// </summary>
        public static readonly StringName _GetViewProjection = "_get_view_projection";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RenderSceneData.SignalName
    {
    }
}
