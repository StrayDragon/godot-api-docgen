namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Represents a camera as defined by the base glTF spec.</para>
/// </summary>
[GodotClassName("GLTFCamera")]
public partial class GltfCamera : Resource
{
    /// <summary>
    /// <para>If <see langword="true"/>, the camera is in perspective mode. Otherwise, the camera is in orthographic/orthogonal mode. This maps to glTF's camera <c>type</c> property. See <see cref="Godot.Camera3D.Projection"/> and the glTF spec for more information.</para>
    /// </summary>
    public bool Perspective
    {
        get
        {
            return GetPerspective();
        }
        set
        {
            SetPerspective(value);
        }
    }

    /// <summary>
    /// <para>The FOV of the camera. This class and glTF define the camera FOV in radians, while Godot uses degrees. This maps to glTF's <c>yfov</c> property. This value is only used for perspective cameras, when <see cref="Godot.GltfCamera.Perspective"/> is <see langword="true"/>.</para>
    /// </summary>
    public float Fov
    {
        get
        {
            return GetFov();
        }
        set
        {
            SetFov(value);
        }
    }

    /// <summary>
    /// <para>The size of the camera. This class and glTF define the camera size magnitude as a radius in meters, while Godot defines it as a diameter in meters. This maps to glTF's <c>ymag</c> property. This value is only used for orthographic/orthogonal cameras, when <see cref="Godot.GltfCamera.Perspective"/> is <see langword="false"/>.</para>
    /// </summary>
    public float SizeMag
    {
        get
        {
            return GetSizeMag();
        }
        set
        {
            SetSizeMag(value);
        }
    }

    /// <summary>
    /// <para>The distance to the far culling boundary for this camera relative to its local Z axis, in meters. This maps to glTF's <c>zfar</c> property.</para>
    /// </summary>
    public float DepthFar
    {
        get
        {
            return GetDepthFar();
        }
        set
        {
            SetDepthFar(value);
        }
    }

    /// <summary>
    /// <para>The distance to the near culling boundary for this camera relative to its local Z axis, in meters. This maps to glTF's <c>znear</c> property.</para>
    /// </summary>
    public float DepthNear
    {
        get
        {
            return GetDepthNear();
        }
        set
        {
            SetDepthNear(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfCamera);

    private static readonly StringName NativeName = "GLTFCamera";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfCamera() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfCamera(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfCamera(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromNode, 237784ul);

    /// <summary>
    /// <para>Create a new GLTFCamera instance from the given Godot <see cref="Godot.Camera3D"/> node.</para>
    /// </summary>
    public static GltfCamera FromNode(Camera3D cameraNode)
    {
        return (GltfCamera)NativeCalls.godot_icall_1_637(MethodBind0, GodotObject.GetPtr(cameraNode));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToNode, 2285090890ul);

    /// <summary>
    /// <para>Converts this GLTFCamera instance into a Godot <see cref="Godot.Camera3D"/> node.</para>
    /// </summary>
    public Camera3D ToNode()
    {
        return (Camera3D)NativeCalls.godot_icall_0_53(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromDictionary, 2495512509ul);

    /// <summary>
    /// <para>Creates a new GLTFCamera instance by parsing the given <see cref="Godot.Collections.Dictionary"/>.</para>
    /// </summary>
    public static GltfCamera FromDictionary(Godot.Collections.Dictionary dictionary)
    {
        return (GltfCamera)NativeCalls.godot_icall_1_633(MethodBind2, (godot_dictionary)(dictionary ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToDictionary, 3102165223ul);

    /// <summary>
    /// <para>Serializes this GLTFCamera instance into a <see cref="Godot.Collections.Dictionary"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary ToDictionary()
    {
        return NativeCalls.godot_icall_0_122(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPerspective, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPerspective()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPerspective, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPerspective(bool perspective)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), perspective.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFov, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFov()
    {
        return NativeCalls.godot_icall_0_68(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFov, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFov(float fov)
    {
        NativeCalls.godot_icall_1_67(MethodBind7, GodotObject.GetPtr(this), fov);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSizeMag, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSizeMag()
    {
        return NativeCalls.godot_icall_0_68(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSizeMag, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSizeMag(float sizeMag)
    {
        NativeCalls.godot_icall_1_67(MethodBind9, GodotObject.GetPtr(this), sizeMag);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthFar, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDepthFar()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepthFar, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepthFar(float zdepthFar)
    {
        NativeCalls.godot_icall_1_67(MethodBind11, GodotObject.GetPtr(this), zdepthFar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthNear, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDepthNear()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepthNear, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepthNear(float zdepthNear)
    {
        NativeCalls.godot_icall_1_67(MethodBind13, GodotObject.GetPtr(this), zdepthNear);
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'perspective' property.
        /// </summary>
        public static readonly StringName Perspective = "perspective";
        /// <summary>
        /// Cached name for the 'fov' property.
        /// </summary>
        public static readonly StringName Fov = "fov";
        /// <summary>
        /// Cached name for the 'size_mag' property.
        /// </summary>
        public static readonly StringName SizeMag = "size_mag";
        /// <summary>
        /// Cached name for the 'depth_far' property.
        /// </summary>
        public static readonly StringName DepthFar = "depth_far";
        /// <summary>
        /// Cached name for the 'depth_near' property.
        /// </summary>
        public static readonly StringName DepthNear = "depth_near";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'from_node' method.
        /// </summary>
        public static readonly StringName FromNode = "from_node";
        /// <summary>
        /// Cached name for the 'to_node' method.
        /// </summary>
        public static readonly StringName ToNode = "to_node";
        /// <summary>
        /// Cached name for the 'from_dictionary' method.
        /// </summary>
        public static readonly StringName FromDictionary = "from_dictionary";
        /// <summary>
        /// Cached name for the 'to_dictionary' method.
        /// </summary>
        public static readonly StringName ToDictionary = "to_dictionary";
        /// <summary>
        /// Cached name for the 'get_perspective' method.
        /// </summary>
        public static readonly StringName GetPerspective = "get_perspective";
        /// <summary>
        /// Cached name for the 'set_perspective' method.
        /// </summary>
        public static readonly StringName SetPerspective = "set_perspective";
        /// <summary>
        /// Cached name for the 'get_fov' method.
        /// </summary>
        public static readonly StringName GetFov = "get_fov";
        /// <summary>
        /// Cached name for the 'set_fov' method.
        /// </summary>
        public static readonly StringName SetFov = "set_fov";
        /// <summary>
        /// Cached name for the 'get_size_mag' method.
        /// </summary>
        public static readonly StringName GetSizeMag = "get_size_mag";
        /// <summary>
        /// Cached name for the 'set_size_mag' method.
        /// </summary>
        public static readonly StringName SetSizeMag = "set_size_mag";
        /// <summary>
        /// Cached name for the 'get_depth_far' method.
        /// </summary>
        public static readonly StringName GetDepthFar = "get_depth_far";
        /// <summary>
        /// Cached name for the 'set_depth_far' method.
        /// </summary>
        public static readonly StringName SetDepthFar = "set_depth_far";
        /// <summary>
        /// Cached name for the 'get_depth_near' method.
        /// </summary>
        public static readonly StringName GetDepthNear = "get_depth_near";
        /// <summary>
        /// Cached name for the 'set_depth_near' method.
        /// </summary>
        public static readonly StringName SetDepthNear = "set_depth_near";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
