namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstract scene data object, exists for the duration of rendering a single viewport. See also <see cref="Godot.RenderSceneDataRD"/>, <see cref="Godot.RenderData"/>, and <see cref="Godot.RenderDataRD"/>.</para>
/// <para><b>Note:</b> This is an internal rendering server object. Do not instantiate this class from a script.</para>
/// </summary>
public partial class RenderSceneData : GodotObject
{
    private static readonly System.Type CachedType = typeof(RenderSceneData);

    private static readonly StringName NativeName = "RenderSceneData";

    internal RenderSceneData() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RenderSceneData(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RenderSceneData(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCamTransform, 3229777777ul);

    /// <summary>
    /// <para>Returns the camera transform used to render this frame.</para>
    /// <para><b>Note:</b> If more than one view is rendered, this will return a centered transform.</para>
    /// </summary>
    public Transform3D GetCamTransform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCamProjection, 2910717950ul);

    /// <summary>
    /// <para>Returns the camera projection used to render this frame.</para>
    /// <para><b>Note:</b> If more than one view is rendered, this will return a combined projection.</para>
    /// </summary>
    public Projection GetCamProjection()
    {
        return NativeCalls.godot_icall_0_237(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of views being rendered.</para>
    /// </summary>
    public uint GetViewCount()
    {
        return NativeCalls.godot_icall_0_209(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewEyeOffset, 711720468ul);

    /// <summary>
    /// <para>Returns the eye offset per view used to render this frame. This is the offset between our camera transform and the eye transform.</para>
    /// </summary>
    public Vector3 GetViewEyeOffset(uint view)
    {
        return NativeCalls.godot_icall_1_1048(MethodBind3, GodotObject.GetPtr(this), view);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewProjection, 3179846605ul);

    /// <summary>
    /// <para>Returns the view projection per view used to render this frame.</para>
    /// <para><b>Note:</b> If a single view is rendered, this returns the camera projection. If more than one view is rendered, this will return a projection for the given view including the eye offset.</para>
    /// </summary>
    public Projection GetViewProjection(uint view)
    {
        return NativeCalls.godot_icall_1_1049(MethodBind4, GodotObject.GetPtr(this), view);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUniformBuffer, 2944877500ul);

    /// <summary>
    /// <para>Return the <see cref="Godot.Rid"/> of the uniform buffer containing the scene data as a UBO.</para>
    /// </summary>
    public Rid GetUniformBuffer()
    {
        return NativeCalls.godot_icall_0_238(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'get_cam_transform' method.
        /// </summary>
        public static readonly StringName GetCamTransform = "get_cam_transform";
        /// <summary>
        /// Cached name for the 'get_cam_projection' method.
        /// </summary>
        public static readonly StringName GetCamProjection = "get_cam_projection";
        /// <summary>
        /// Cached name for the 'get_view_count' method.
        /// </summary>
        public static readonly StringName GetViewCount = "get_view_count";
        /// <summary>
        /// Cached name for the 'get_view_eye_offset' method.
        /// </summary>
        public static readonly StringName GetViewEyeOffset = "get_view_eye_offset";
        /// <summary>
        /// Cached name for the 'get_view_projection' method.
        /// </summary>
        public static readonly StringName GetViewProjection = "get_view_projection";
        /// <summary>
        /// Cached name for the 'get_uniform_buffer' method.
        /// </summary>
        public static readonly StringName GetUniformBuffer = "get_uniform_buffer";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
