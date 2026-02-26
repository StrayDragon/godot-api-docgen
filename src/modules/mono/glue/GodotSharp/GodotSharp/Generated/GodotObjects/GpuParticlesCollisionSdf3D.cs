namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A baked signed distance field 3D particle collision shape affecting <see cref="Godot.GpuParticles3D"/> nodes.</para>
/// <para>Signed distance fields (SDF) allow for efficiently representing approximate collision shapes for convex and concave objects of any shape. This is more flexible than <see cref="Godot.GpuParticlesCollisionHeightField3D"/>, but it requires a baking step.</para>
/// <para><b>Baking:</b> The signed distance field texture can be baked by selecting the <see cref="Godot.GpuParticlesCollisionSdf3D"/> node in the editor, then clicking <b>Bake SDF</b> at the top of the 3D viewport. Any <i>visible</i> <see cref="Godot.MeshInstance3D"/>s within the <see cref="Godot.GpuParticlesCollisionSdf3D.Size"/> will be taken into account for baking, regardless of their <see cref="Godot.GeometryInstance3D.GIMode"/>.</para>
/// <para><b>Note:</b> Baking a <see cref="Godot.GpuParticlesCollisionSdf3D"/>'s <see cref="Godot.GpuParticlesCollisionSdf3D.Texture"/> is only possible within the editor, as there is no bake method exposed for use in exported projects. However, it's still possible to load pre-baked <see cref="Godot.Texture3D"/>s into its <see cref="Godot.GpuParticlesCollisionSdf3D.Texture"/> property in an exported project.</para>
/// <para><b>Note:</b> <see cref="Godot.ParticleProcessMaterial.CollisionMode"/> must be <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.Rigid"/> or <see cref="Godot.ParticleProcessMaterial.CollisionModeEnum.HideOnContact"/> on the <see cref="Godot.GpuParticles3D"/>'s process material for collision to work.</para>
/// <para><b>Note:</b> Particle collision only affects <see cref="Godot.GpuParticles3D"/>, not <see cref="Godot.CpuParticles3D"/>.</para>
/// </summary>
[GodotClassName("GPUParticlesCollisionSDF3D")]
public partial class GpuParticlesCollisionSdf3D : GpuParticlesCollision3D
{
    public enum ResolutionEnum : long
    {
        /// <summary>
        /// <para>Bake a 16×16×16 signed distance field. This is the fastest option, but also the least precise.</para>
        /// </summary>
        Resolution16 = 0,
        /// <summary>
        /// <para>Bake a 32×32×32 signed distance field.</para>
        /// </summary>
        Resolution32 = 1,
        /// <summary>
        /// <para>Bake a 64×64×64 signed distance field.</para>
        /// </summary>
        Resolution64 = 2,
        /// <summary>
        /// <para>Bake a 128×128×128 signed distance field.</para>
        /// </summary>
        Resolution128 = 3,
        /// <summary>
        /// <para>Bake a 256×256×256 signed distance field.</para>
        /// </summary>
        Resolution256 = 4,
        /// <summary>
        /// <para>Bake a 512×512×512 signed distance field. This is the slowest option, but also the most precise.</para>
        /// </summary>
        Resolution512 = 5,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.GpuParticlesCollisionSdf3D.ResolutionEnum"/> enum.</para>
        /// </summary>
        Max = 6
    }

    /// <summary>
    /// <para>The collision SDF's size in 3D units. To improve SDF quality, the <see cref="Godot.GpuParticlesCollisionSdf3D.Size"/> should be set as small as possible while covering the parts of the scene you need.</para>
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
    /// <para>The bake resolution to use for the signed distance field <see cref="Godot.GpuParticlesCollisionSdf3D.Texture"/>. The texture must be baked again for changes to the <see cref="Godot.GpuParticlesCollisionSdf3D.Resolution"/> property to be effective. Higher resolutions have a greater performance cost and take more time to bake. Higher resolutions also result in larger baked textures, leading to increased VRAM and storage space requirements. To improve performance and reduce bake times, use the lowest resolution possible for the object you're representing the collision of.</para>
    /// </summary>
    public GpuParticlesCollisionSdf3D.ResolutionEnum Resolution
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
    /// <para>The collision shape's thickness. Unlike other particle colliders, <see cref="Godot.GpuParticlesCollisionSdf3D"/> is actually hollow on the inside. <see cref="Godot.GpuParticlesCollisionSdf3D.Thickness"/> can be increased to prevent particles from tunneling through the collision shape at high speeds, or when the <see cref="Godot.GpuParticlesCollisionSdf3D"/> is moved.</para>
    /// </summary>
    public float Thickness
    {
        get
        {
            return GetThickness();
        }
        set
        {
            SetThickness(value);
        }
    }

    /// <summary>
    /// <para>The visual layers to account for when baking the particle collision SDF. Only <see cref="Godot.MeshInstance3D"/>s whose <see cref="Godot.VisualInstance3D.Layers"/> match with this <see cref="Godot.GpuParticlesCollisionSdf3D.BakeMask"/> will be included in the generated particle collision SDF. By default, all objects are taken into account for the particle collision SDF baking.</para>
    /// </summary>
    public uint BakeMask
    {
        get
        {
            return GetBakeMask();
        }
        set
        {
            SetBakeMask(value);
        }
    }

    /// <summary>
    /// <para>The 3D texture representing the signed distance field.</para>
    /// </summary>
    public Texture3D Texture
    {
        get
        {
            return GetTexture();
        }
        set
        {
            SetTexture(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GpuParticlesCollisionSdf3D);

    private static readonly StringName NativeName = "GPUParticlesCollisionSDF3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GpuParticlesCollisionSdf3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticlesCollisionSdf3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GpuParticlesCollisionSdf3D(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetResolution, 1155629297ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetResolution(GpuParticlesCollisionSdf3D.ResolutionEnum resolution)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)resolution);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResolution, 2919555867ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GpuParticlesCollisionSdf3D.ResolutionEnum GetResolution()
    {
        return (GpuParticlesCollisionSdf3D.ResolutionEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexture, 1188404210ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexture(Texture3D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 373985333ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture3D GetTexture()
    {
        return (Texture3D)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThickness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetThickness(float thickness)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), thickness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThickness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetThickness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakeMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBakeMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind8, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetBakeMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakeMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.GpuParticlesCollisionSdf3D.BakeMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetBakeMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind10, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakeMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.GpuParticlesCollisionSdf3D.BakeMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetBakeMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind11, GodotObject.GetPtr(this), layerNumber).ToBool();
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
        /// Cached name for the 'thickness' property.
        /// </summary>
        public static readonly StringName Thickness = "thickness";
        /// <summary>
        /// Cached name for the 'bake_mask' property.
        /// </summary>
        public static readonly StringName BakeMask = "bake_mask";
        /// <summary>
        /// Cached name for the 'texture' property.
        /// </summary>
        public static readonly StringName Texture = "texture";
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
        /// Cached name for the 'set_texture' method.
        /// </summary>
        public static readonly StringName SetTexture = "set_texture";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
        /// <summary>
        /// Cached name for the 'set_thickness' method.
        /// </summary>
        public static readonly StringName SetThickness = "set_thickness";
        /// <summary>
        /// Cached name for the 'get_thickness' method.
        /// </summary>
        public static readonly StringName GetThickness = "get_thickness";
        /// <summary>
        /// Cached name for the 'set_bake_mask' method.
        /// </summary>
        public static readonly StringName SetBakeMask = "set_bake_mask";
        /// <summary>
        /// Cached name for the 'get_bake_mask' method.
        /// </summary>
        public static readonly StringName GetBakeMask = "get_bake_mask";
        /// <summary>
        /// Cached name for the 'set_bake_mask_value' method.
        /// </summary>
        public static readonly StringName SetBakeMaskValue = "set_bake_mask_value";
        /// <summary>
        /// Cached name for the 'get_bake_mask_value' method.
        /// </summary>
        public static readonly StringName GetBakeMaskValue = "get_bake_mask_value";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GpuParticlesCollision3D.SignalName
    {
    }
}
