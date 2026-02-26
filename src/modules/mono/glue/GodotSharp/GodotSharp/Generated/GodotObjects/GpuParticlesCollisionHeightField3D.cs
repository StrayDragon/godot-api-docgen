namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A real-time heightmap-shaped 3D particle collision shape affecting <see cref="Godot.GpuParticles3D"/> nodes.</para>
/// <para>Heightmap shapes allow for efficiently representing collisions for convex and concave objects with a single "floor" (such as terrain). This is less flexible than <see cref="Godot.GpuParticlesCollisionSdf3D"/>, but it doesn't require a baking step.</para>
/// <para><see cref="Godot.GpuParticlesCollisionHeightField3D"/> can also be regenerated in real-time when it is moved, when the camera moves, or even continuously. This makes <see cref="Godot.GpuParticlesCollisionHeightField3D"/> a good choice for weather effects such as rain and snow and games with highly dynamic geometry. However, this class is limited since heightmaps cannot represent overhangs (e.g. indoors or caves).</para>
/// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.CollisionMode"/> must be <see langword="true"/> on the <see cref="Godot.GpuParticles3D"/>'s process material for collision to work.</para>
/// <para><b>Note:</b> Particle collision only affects <see cref="Godot.GpuParticles3D"/>, not <see cref="Godot.CpuParticles3D"/>.</para>
/// </summary>
[GodotClassName("GPUParticlesCollisionHeightField3D")]
public partial class GpuParticlesCollisionHeightField3D : GpuParticlesCollision3D
{
    public enum ResolutionEnum : long
    {
        /// <summary>
        /// <para>Generate a 256×256 heightmap. Intended for small-scale scenes, or larger scenes with no distant particles.</para>
        /// </summary>
        Resolution256 = 0,
        /// <summary>
        /// <para>Generate a 512×512 heightmap. Intended for medium-scale scenes, or larger scenes with no distant particles.</para>
        /// </summary>
        Resolution512 = 1,
        /// <summary>
        /// <para>Generate a 1024×1024 heightmap. Intended for large scenes with distant particles.</para>
        /// </summary>
        Resolution1024 = 2,
        /// <summary>
        /// <para>Generate a 2048×2048 heightmap. Intended for very large scenes with distant particles.</para>
        /// </summary>
        Resolution2048 = 3,
        /// <summary>
        /// <para>Generate a 4096×4096 heightmap. Intended for huge scenes with distant particles.</para>
        /// </summary>
        Resolution4096 = 4,
        /// <summary>
        /// <para>Generate a 8192×8192 heightmap. Intended for gigantic scenes with distant particles.</para>
        /// </summary>
        Resolution8192 = 5,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.GpuParticlesCollisionHeightField3D.ResolutionEnum"/> enum.</para>
        /// </summary>
        Max = 6
    }

    public enum UpdateModeEnum : long
    {
        /// <summary>
        /// <para>Only update the heightmap when the <see cref="Godot.GpuParticlesCollisionHeightField3D"/> node is moved, or when the camera moves if <see cref="Godot.GpuParticlesCollisionHeightField3D.FollowCameraEnabled"/> is <see langword="true"/>. An update can be forced by slightly moving the <see cref="Godot.GpuParticlesCollisionHeightField3D"/> in any direction, or by calling <see cref="Godot.RenderingServer.ParticlesCollisionHeightFieldUpdate(Rid)"/>.</para>
        /// </summary>
        WhenMoved = 0,
        /// <summary>
        /// <para>Update the heightmap every frame. This has a significant performance cost. This update should only be used when geometry that particles can collide with changes significantly during gameplay.</para>
        /// </summary>
        Always = 1
    }

    /// <summary>
    /// <para>The collision heightmap's size in 3D units. To improve heightmap quality, <see cref="Godot.GpuParticlesCollisionHeightField3D.Size"/> should be set as small as possible while covering the parts of the scene you need.</para>
    /// </summary>
    public Vector3 Size
    {
        get
        {
            return GetSize();
        }
        set
        {
            SetSize(value);
        }
    }

    /// <summary>
    /// <para>Higher resolutions can represent small details more accurately in large scenes, at the cost of lower performance. If <see cref="Godot.GpuParticlesCollisionHeightField3D.UpdateMode"/> is <see cref="Godot.GpuParticlesCollisionHeightField3D.UpdateModeEnum.Always"/>, consider using the lowest resolution possible.</para>
    /// </summary>
    public GpuParticlesCollisionHeightField3D.ResolutionEnum Resolution
    {
        get
        {
            return GetResolution();
        }
        set
        {
            SetResolution(value);
        }
    }

    /// <summary>
    /// <para>The update policy to use for the generated heightmap.</para>
    /// </summary>
    public GpuParticlesCollisionHeightField3D.UpdateModeEnum UpdateMode
    {
        get
        {
            return GetUpdateMode();
        }
        set
        {
            SetUpdateMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.GpuParticlesCollisionHeightField3D"/> will follow the current camera in global space. The <see cref="Godot.GpuParticlesCollisionHeightField3D"/> does not need to be a child of the <see cref="Godot.Camera3D"/> node for this to work.</para>
    /// <para>Following the camera has a performance cost, as it will force the heightmap to update whenever the camera moves. Consider lowering <see cref="Godot.GpuParticlesCollisionHeightField3D.Resolution"/> to improve performance if <see cref="Godot.GpuParticlesCollisionHeightField3D.FollowCameraEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public bool FollowCameraEnabled
    {
        get
        {
            return IsFollowCameraEnabled();
        }
        set
        {
            SetFollowCameraEnabled(value);
        }
    }

    /// <summary>
    /// <para>The visual layers to account for when updating the heightmap. Only <see cref="Godot.MeshInstance3D"/>s whose <see cref="Godot.VisualInstance3D.Layers"/> match with this <see cref="Godot.GpuParticlesCollisionHeightField3D.HeightfieldMask"/> will be included in the heightmap collision update. By default, all 20 user-visible layers are taken into account for updating the heightmap collision.</para>
    /// <para><b>Note:</b> Since the <see cref="Godot.GpuParticlesCollisionHeightField3D.HeightfieldMask"/> allows for 32 layers to be stored in total, there are an additional 12 layers that are only used internally by the engine and aren't exposed in the editor. Setting <see cref="Godot.GpuParticlesCollisionHeightField3D.HeightfieldMask"/> using a script allows you to toggle those reserved layers, which can be useful for editor plugins.</para>
    /// <para>To adjust <see cref="Godot.GpuParticlesCollisionHeightField3D.HeightfieldMask"/> more easily using a script, use <see cref="Godot.GpuParticlesCollisionHeightField3D.GetHeightfieldMaskValue(int)"/> and <see cref="Godot.GpuParticlesCollisionHeightField3D.SetHeightfieldMaskValue(int, bool)"/>.</para>
    /// </summary>
    public uint HeightfieldMask
    {
        get
        {
            return GetHeightfieldMask();
        }
        set
        {
            SetHeightfieldMask(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GpuParticlesCollisionHeightField3D);

    private static readonly StringName NativeName = "GPUParticlesCollisionHeightField3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GpuParticlesCollisionHeightField3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticlesCollisionHeightField3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticlesCollisionHeightField3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector3 size)
    {
        NativeCalls.godot_icall_1_177(MethodBind0, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetSize()
    {
        return NativeCalls.godot_icall_0_125(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetResolution, 1009996517ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetResolution(GpuParticlesCollisionHeightField3D.ResolutionEnum resolution)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)resolution);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResolution, 1156065644ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GpuParticlesCollisionHeightField3D.ResolutionEnum GetResolution()
    {
        return (GpuParticlesCollisionHeightField3D.ResolutionEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUpdateMode, 673680859ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUpdateMode(GpuParticlesCollisionHeightField3D.UpdateModeEnum updateMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)updateMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUpdateMode, 1998141380ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GpuParticlesCollisionHeightField3D.UpdateModeEnum GetUpdateMode()
    {
        return (GpuParticlesCollisionHeightField3D.UpdateModeEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeightfieldMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHeightfieldMask(uint heightfieldMask)
    {
        NativeCalls.godot_icall_1_208(MethodBind6, GodotObject.GetPtr(this), heightfieldMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeightfieldMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetHeightfieldMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeightfieldMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.GpuParticlesCollisionHeightField3D.HeightfieldMask"/>, given a <paramref name="layerNumber"/> between <c>1</c> and <c>20</c>, inclusive.</para>
    /// </summary>
    public void SetHeightfieldMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind8, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeightfieldMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified layer of the <see cref="Godot.GpuParticlesCollisionHeightField3D.HeightfieldMask"/> is enabled, given a <paramref name="layerNumber"/> between <c>1</c> and <c>20</c>, inclusive.</para>
    /// </summary>
    public bool GetHeightfieldMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind9, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFollowCameraEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFollowCameraEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFollowCameraEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFollowCameraEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : GpuParticlesCollision3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'resolution' property.
        /// </summary>
        public static readonly StringName Resolution = "resolution";
        /// <summary>
        /// Cached name for the 'update_mode' property.
        /// </summary>
        public static readonly StringName UpdateMode = "update_mode";
        /// <summary>
        /// Cached name for the 'follow_camera_enabled' property.
        /// </summary>
        public static readonly StringName FollowCameraEnabled = "follow_camera_enabled";
        /// <summary>
        /// Cached name for the 'heightfield_mask' property.
        /// </summary>
        public static readonly StringName HeightfieldMask = "heightfield_mask";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GpuParticlesCollision3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'set_resolution' method.
        /// </summary>
        public static readonly StringName SetResolution = "set_resolution";
        /// <summary>
        /// Cached name for the 'get_resolution' method.
        /// </summary>
        public static readonly StringName GetResolution = "get_resolution";
        /// <summary>
        /// Cached name for the 'set_update_mode' method.
        /// </summary>
        public static readonly StringName SetUpdateMode = "set_update_mode";
        /// <summary>
        /// Cached name for the 'get_update_mode' method.
        /// </summary>
        public static readonly StringName GetUpdateMode = "get_update_mode";
        /// <summary>
        /// Cached name for the 'set_heightfield_mask' method.
        /// </summary>
        public static readonly StringName SetHeightfieldMask = "set_heightfield_mask";
        /// <summary>
        /// Cached name for the 'get_heightfield_mask' method.
        /// </summary>
        public static readonly StringName GetHeightfieldMask = "get_heightfield_mask";
        /// <summary>
        /// Cached name for the 'set_heightfield_mask_value' method.
        /// </summary>
        public static readonly StringName SetHeightfieldMaskValue = "set_heightfield_mask_value";
        /// <summary>
        /// Cached name for the 'get_heightfield_mask_value' method.
        /// </summary>
        public static readonly StringName GetHeightfieldMaskValue = "get_heightfield_mask_value";
        /// <summary>
        /// Cached name for the 'set_follow_camera_enabled' method.
        /// </summary>
        public static readonly StringName SetFollowCameraEnabled = "set_follow_camera_enabled";
        /// <summary>
        /// Cached name for the 'is_follow_camera_enabled' method.
        /// </summary>
        public static readonly StringName IsFollowCameraEnabled = "is_follow_camera_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GpuParticlesCollision3D.SignalName
    {
    }
}
