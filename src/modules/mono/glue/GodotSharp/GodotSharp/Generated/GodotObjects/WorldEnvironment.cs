namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.WorldEnvironment"/> node is used to configure the default <see cref="Godot.Environment"/> for the scene.</para>
/// <para>The parameters defined in the <see cref="Godot.WorldEnvironment"/> can be overridden by an <see cref="Godot.Environment"/> node set on the current <see cref="Godot.Camera3D"/>. Additionally, only one <see cref="Godot.WorldEnvironment"/> may be instantiated in a given scene at a time.</para>
/// <para>The <see cref="Godot.WorldEnvironment"/> allows the user to specify default lighting parameters (e.g. ambient lighting), various post-processing effects (e.g. SSAO, DOF, Tonemapping), and how to draw the background (e.g. solid color, skybox). Usually, these are added in order to improve the realism/color balance of the scene.</para>
/// </summary>
public partial class WorldEnvironment : Node
{
    /// <summary>
    /// <para>The <see cref="Godot.Environment"/> resource used by this <see cref="Godot.WorldEnvironment"/>, defining the default properties.</para>
    /// </summary>
    public Environment Environment
    {
        get
        {
            return GetEnvironment();
        }
        set
        {
            SetEnvironment(value);
        }
    }

    /// <summary>
    /// <para>The default <see cref="Godot.CameraAttributes"/> resource to use if none set on the <see cref="Godot.Camera3D"/>.</para>
    /// </summary>
    public CameraAttributes CameraAttributes
    {
        get
        {
            return GetCameraAttributes();
        }
        set
        {
            SetCameraAttributes(value);
        }
    }

    /// <summary>
    /// <para>The default <see cref="Godot.Compositor"/> resource to use if none set on the <see cref="Godot.Camera3D"/>.</para>
    /// </summary>
    public Compositor Compositor
    {
        get
        {
            return GetCompositor();
        }
        set
        {
            SetCompositor(value);
        }
    }

    private static readonly System.Type CachedType = typeof(WorldEnvironment);

    private static readonly StringName NativeName = "WorldEnvironment";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public WorldEnvironment() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal WorldEnvironment(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal WorldEnvironment(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnvironment, 4143518816ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnvironment(Environment env)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(env));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironment, 3082064660ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Environment GetEnvironment()
    {
        return (Environment)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCameraAttributes, 2817810567ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCameraAttributes(CameraAttributes cameraAttributes)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(cameraAttributes));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraAttributes, 3921283215ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CameraAttributes GetCameraAttributes()
    {
        return (CameraAttributes)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCompositor, 1586754307ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCompositor(Compositor compositor)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(compositor));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCompositor, 3647707413ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Compositor GetCompositor()
    {
        return (Compositor)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node.PropertyName
    {
        /// <summary>
        /// Cached name for the 'environment' property.
        /// </summary>
        public static readonly StringName Environment = "environment";
        /// <summary>
        /// Cached name for the 'camera_attributes' property.
        /// </summary>
        public static readonly StringName CameraAttributes = "camera_attributes";
        /// <summary>
        /// Cached name for the 'compositor' property.
        /// </summary>
        public static readonly StringName Compositor = "compositor";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_environment' method.
        /// </summary>
        public static readonly StringName SetEnvironment = "set_environment";
        /// <summary>
        /// Cached name for the 'get_environment' method.
        /// </summary>
        public static readonly StringName GetEnvironment = "get_environment";
        /// <summary>
        /// Cached name for the 'set_camera_attributes' method.
        /// </summary>
        public static readonly StringName SetCameraAttributes = "set_camera_attributes";
        /// <summary>
        /// Cached name for the 'get_camera_attributes' method.
        /// </summary>
        public static readonly StringName GetCameraAttributes = "get_camera_attributes";
        /// <summary>
        /// Cached name for the 'set_compositor' method.
        /// </summary>
        public static readonly StringName SetCompositor = "set_compositor";
        /// <summary>
        /// Cached name for the 'get_compositor' method.
        /// </summary>
        public static readonly StringName GetCompositor = "get_compositor";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
    }
}
