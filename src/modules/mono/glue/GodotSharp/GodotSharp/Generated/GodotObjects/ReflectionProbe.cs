namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Captures its surroundings as a cubemap, and stores versions of it with increasing levels of blur to simulate different material roughnesses.</para>
/// <para>The <see cref="Godot.ReflectionProbe"/> is used to create high-quality reflections at a low performance cost (when <see cref="Godot.ReflectionProbe.UpdateMode"/> is <see cref="Godot.ReflectionProbe.UpdateModeEnum.Once"/>). <see cref="Godot.ReflectionProbe"/>s can be blended together and with the rest of the scene smoothly. <see cref="Godot.ReflectionProbe"/>s can also be combined with <see cref="Godot.VoxelGI"/>, SDFGI (<see cref="Godot.Environment.SdfgiEnabled"/>) and screen-space reflections (<see cref="Godot.Environment.SsrEnabled"/>) to get more accurate reflections in specific areas. <see cref="Godot.ReflectionProbe"/>s render all objects within their <see cref="Godot.ReflectionProbe.CullMask"/>, so updating them can be quite expensive. It is best to update them once with the important static objects and then leave them as-is.</para>
/// <para><b>Note:</b> Unlike <see cref="Godot.VoxelGI"/> and SDFGI, <see cref="Godot.ReflectionProbe"/>s only source their environment from a <see cref="Godot.WorldEnvironment"/> node. If you specify an <see cref="Godot.Environment"/> resource within a <see cref="Godot.Camera3D"/> node, it will be ignored by the <see cref="Godot.ReflectionProbe"/>. This can lead to incorrect lighting within the <see cref="Godot.ReflectionProbe"/>.</para>
/// <para><b>Note:</b> When using the Mobile rendering method, only <c>8</c> reflection probes can be displayed on each mesh resource, while the Compatibility rendering method only supports up to <c>2</c> reflection probes on each mesh. Attempting to display more than <c>8</c> reflection probes on a single mesh resource using the Mobile renderer will result in reflection probes flickering in and out as the camera moves, while the Compatibility renderer will not render any additional probes if more than <c>2</c> reflection probes are being used.</para>
/// <para><b>Note:</b> When using the Mobile rendering method, reflection probes will only correctly affect meshes whose visibility AABB intersects with the reflection probe's AABB. If using a shader to deform the mesh in a way that makes it go outside its AABB, <see cref="Godot.GeometryInstance3D.ExtraCullMargin"/> must be increased on the mesh. Otherwise, the reflection probe may not be visible on the mesh.</para>
/// </summary>
public partial class ReflectionProbe : VisualInstance3D
{
    public enum UpdateModeEnum : long
    {
        /// <summary>
        /// <para>Update the probe once on the next frame (recommended for most objects). The corresponding radiance map will be generated over the following six frames. This takes more time to update than <see cref="Godot.ReflectionProbe.UpdateModeEnum.Always"/>, but it has a lower performance cost and can result in higher-quality reflections. The ReflectionProbe is updated when its transform changes, but not when nearby geometry changes. You can force a <see cref="Godot.ReflectionProbe"/> update by moving the <see cref="Godot.ReflectionProbe"/> slightly in any direction.</para>
        /// </summary>
        Once = 0,
        /// <summary>
        /// <para>Update the probe every frame. This provides better results for fast-moving dynamic objects (such as cars). However, it has a significant performance cost. Due to the cost, it's recommended to only use one ReflectionProbe with <see cref="Godot.ReflectionProbe.UpdateModeEnum.Always"/> at most per scene. For all other use cases, use <see cref="Godot.ReflectionProbe.UpdateModeEnum.Once"/>.</para>
        /// </summary>
        Always = 1
    }

    public enum AmbientModeEnum : long
    {
        /// <summary>
        /// <para>Do not apply any ambient lighting inside the <see cref="Godot.ReflectionProbe"/>'s box defined by its <see cref="Godot.ReflectionProbe.Size"/>.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Apply automatically-sourced environment lighting inside the <see cref="Godot.ReflectionProbe"/>'s box defined by its <see cref="Godot.ReflectionProbe.Size"/>.</para>
        /// </summary>
        Environment = 1,
        /// <summary>
        /// <para>Apply custom ambient lighting inside the <see cref="Godot.ReflectionProbe"/>'s box defined by its <see cref="Godot.ReflectionProbe.Size"/>. See <see cref="Godot.ReflectionProbe.AmbientColor"/> and <see cref="Godot.ReflectionProbe.AmbientColorEnergy"/>.</para>
        /// </summary>
        Color = 2
    }

    /// <summary>
    /// <para>Sets how frequently the <see cref="Godot.ReflectionProbe"/> is updated. Can be <see cref="Godot.ReflectionProbe.UpdateModeEnum.Once"/> or <see cref="Godot.ReflectionProbe.UpdateModeEnum.Always"/>.</para>
    /// </summary>
    public ReflectionProbe.UpdateModeEnum UpdateMode
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
    /// <para>Defines the reflection intensity. Intensity modulates the strength of the reflection.</para>
    /// </summary>
    public float Intensity
    {
        get
        {
            return GetIntensity();
        }
        set
        {
            SetIntensity(value);
        }
    }

    /// <summary>
    /// <para>Defines the distance in meters over which a probe blends into the scene.</para>
    /// </summary>
    public float BlendDistance
    {
        get
        {
            return GetBlendDistance();
        }
        set
        {
            SetBlendDistance(value);
        }
    }

    /// <summary>
    /// <para>The maximum distance away from the <see cref="Godot.ReflectionProbe"/> an object can be before it is culled. Decrease this to improve performance, especially when using the <see cref="Godot.ReflectionProbe.UpdateModeEnum.Always"/> <see cref="Godot.ReflectionProbe.UpdateMode"/>.</para>
    /// <para><b>Note:</b> The maximum reflection distance is always at least equal to the probe's extents. This means that decreasing <see cref="Godot.ReflectionProbe.MaxDistance"/> will not always cull objects from reflections, especially if the reflection probe's box defined by its <see cref="Godot.ReflectionProbe.Size"/> is already large.</para>
    /// </summary>
    public float MaxDistance
    {
        get
        {
            return GetMaxDistance();
        }
        set
        {
            SetMaxDistance(value);
        }
    }

    /// <summary>
    /// <para>The size of the reflection probe. The larger the size, the more space covered by the probe, which will lower the perceived resolution. It is best to keep the size only as large as you need it.</para>
    /// <para><b>Note:</b> To better fit areas that are not aligned to the grid, you can rotate the <see cref="Godot.ReflectionProbe"/> node.</para>
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
    /// <para>Sets the origin offset to be used when this <see cref="Godot.ReflectionProbe"/> is in <see cref="Godot.ReflectionProbe.BoxProjection"/> mode. This can be set to a non-zero value to ensure a reflection fits a rectangle-shaped room, while reducing the number of objects that "get in the way" of the reflection.</para>
    /// </summary>
    public Vector3 OriginOffset
    {
        get
        {
            return GetOriginOffset();
        }
        set
        {
            SetOriginOffset(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables box projection. This makes reflections look more correct in rectangle-shaped rooms by offsetting the reflection center depending on the camera's location.</para>
    /// <para><b>Note:</b> To better fit rectangle-shaped rooms that are not aligned to the grid, you can rotate the <see cref="Godot.ReflectionProbe"/> node.</para>
    /// </summary>
    public bool BoxProjection
    {
        get
        {
            return IsBoxProjectionEnabled();
        }
        set
        {
            SetEnableBoxProjection(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, reflections will ignore sky contribution.</para>
    /// </summary>
    public bool Interior
    {
        get
        {
            return IsSetAsInterior();
        }
        set
        {
            SetAsInterior(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, computes shadows in the reflection probe. This makes the reflection probe slower to render; you may want to disable this if using the <see cref="Godot.ReflectionProbe.UpdateModeEnum.Always"/> <see cref="Godot.ReflectionProbe.UpdateMode"/>.</para>
    /// </summary>
    public bool EnableShadows
    {
        get
        {
            return AreShadowsEnabled();
        }
        set
        {
            SetEnableShadows(value);
        }
    }

    /// <summary>
    /// <para>Sets the cull mask which determines what objects are drawn by this probe. Every <see cref="Godot.VisualInstance3D"/> with a layer included in this cull mask will be rendered by the probe. It is best to only include large objects which are likely to take up a lot of space in the reflection in order to save on rendering cost.</para>
    /// <para>This can also be used to prevent an object from reflecting upon itself (for instance, a <see cref="Godot.ReflectionProbe"/> centered on a vehicle).</para>
    /// </summary>
    public uint CullMask
    {
        get
        {
            return GetCullMask();
        }
        set
        {
            SetCullMask(value);
        }
    }

    /// <summary>
    /// <para>Sets the reflection mask which determines what objects have reflections applied from this probe. Every <see cref="Godot.VisualInstance3D"/> with a layer included in this reflection mask will have reflections applied from this probe. See also <see cref="Godot.ReflectionProbe.CullMask"/>, which can be used to exclude objects from appearing in the reflection while still making them affected by the <see cref="Godot.ReflectionProbe"/>.</para>
    /// </summary>
    public uint ReflectionMask
    {
        get
        {
            return GetReflectionMask();
        }
        set
        {
            SetReflectionMask(value);
        }
    }

    /// <summary>
    /// <para>The automatic LOD bias to use for meshes rendered within the <see cref="Godot.ReflectionProbe"/> (this is analog to <see cref="Godot.Viewport.MeshLodThreshold"/>). Higher values will use less detailed versions of meshes that have LOD variations generated. If set to <c>0.0</c>, automatic LOD is disabled. Increase <see cref="Godot.ReflectionProbe.MeshLodThreshold"/> to improve performance at the cost of geometry detail, especially when using the <see cref="Godot.ReflectionProbe.UpdateModeEnum.Always"/> <see cref="Godot.ReflectionProbe.UpdateMode"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.ReflectionProbe.MeshLodThreshold"/> does not affect <see cref="Godot.GeometryInstance3D"/> visibility ranges (also known as "manual" LOD or hierarchical LOD).</para>
    /// </summary>
    public float MeshLodThreshold
    {
        get
        {
            return GetMeshLodThreshold();
        }
        set
        {
            SetMeshLodThreshold(value);
        }
    }

    /// <summary>
    /// <para>The ambient color to use within the <see cref="Godot.ReflectionProbe"/>'s box defined by its <see cref="Godot.ReflectionProbe.Size"/>. The ambient color will smoothly blend with other <see cref="Godot.ReflectionProbe"/>s and the rest of the scene (outside the <see cref="Godot.ReflectionProbe"/>'s box defined by its <see cref="Godot.ReflectionProbe.Size"/>).</para>
    /// </summary>
    public ReflectionProbe.AmbientModeEnum AmbientMode
    {
        get
        {
            return GetAmbientMode();
        }
        set
        {
            SetAmbientMode(value);
        }
    }

    /// <summary>
    /// <para>The custom ambient color to use within the <see cref="Godot.ReflectionProbe"/>'s box defined by its <see cref="Godot.ReflectionProbe.Size"/>. Only effective if <see cref="Godot.ReflectionProbe.AmbientMode"/> is <see cref="Godot.ReflectionProbe.AmbientModeEnum.Color"/>.</para>
    /// </summary>
    public Color AmbientColor
    {
        get
        {
            return GetAmbientColor();
        }
        set
        {
            SetAmbientColor(value);
        }
    }

    /// <summary>
    /// <para>The custom ambient color energy to use within the <see cref="Godot.ReflectionProbe"/>'s box defined by its <see cref="Godot.ReflectionProbe.Size"/>. Only effective if <see cref="Godot.ReflectionProbe.AmbientMode"/> is <see cref="Godot.ReflectionProbe.AmbientModeEnum.Color"/>.</para>
    /// </summary>
    public float AmbientColorEnergy
    {
        get
        {
            return GetAmbientColorEnergy();
        }
        set
        {
            SetAmbientColorEnergy(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ReflectionProbe);

    private static readonly StringName NativeName = "ReflectionProbe";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ReflectionProbe() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ReflectionProbe(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ReflectionProbe(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIntensity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIntensity(float intensity)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), intensity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIntensity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetIntensity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlendDistance(float blendDistance)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), blendDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBlendDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmbientMode, 1748981278ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAmbientMode(ReflectionProbe.AmbientModeEnum ambient)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)ambient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmbientMode, 1014607621ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ReflectionProbe.AmbientModeEnum GetAmbientMode()
    {
        return (ReflectionProbe.AmbientModeEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmbientColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAmbientColor(Color ambient)
    {
        NativeCalls.godot_icall_1_213(MethodBind6, GodotObject.GetPtr(this), &ambient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmbientColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetAmbientColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmbientColorEnergy, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAmbientColorEnergy(float ambientEnergy)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), ambientEnergy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmbientColorEnergy, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAmbientColorEnergy()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxDistance(float maxDistance)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), maxDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMaxDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMeshLodThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMeshLodThreshold(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMeshLodThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMeshLodThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector3 size)
    {
        NativeCalls.godot_icall_1_177(MethodBind14, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetSize()
    {
        return NativeCalls.godot_icall_0_125(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOriginOffset, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOriginOffset(Vector3 originOffset)
    {
        NativeCalls.godot_icall_1_177(MethodBind16, GodotObject.GetPtr(this), &originOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOriginOffset, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetOriginOffset()
    {
        return NativeCalls.godot_icall_0_125(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAsInterior, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAsInterior(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSetAsInterior, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSetAsInterior()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableBoxProjection, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableBoxProjection(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBoxProjectionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsBoxProjectionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableShadows, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableShadows(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind22, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreShadowsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreShadowsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind23, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCullMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCullMask(uint layers)
    {
        NativeCalls.godot_icall_1_208(MethodBind24, GodotObject.GetPtr(this), layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCullMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCullMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReflectionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReflectionMask(uint layers)
    {
        NativeCalls.godot_icall_1_208(MethodBind26, GodotObject.GetPtr(this), layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReflectionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetReflectionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUpdateMode, 4090221187ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUpdateMode(ReflectionProbe.UpdateModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUpdateMode, 2367550552ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ReflectionProbe.UpdateModeEnum GetUpdateMode()
    {
        return (ReflectionProbe.UpdateModeEnum)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'update_mode' property.
        /// </summary>
        public static readonly StringName UpdateMode = "update_mode";
        /// <summary>
        /// Cached name for the 'intensity' property.
        /// </summary>
        public static readonly StringName Intensity = "intensity";
        /// <summary>
        /// Cached name for the 'blend_distance' property.
        /// </summary>
        public static readonly StringName BlendDistance = "blend_distance";
        /// <summary>
        /// Cached name for the 'max_distance' property.
        /// </summary>
        public static readonly StringName MaxDistance = "max_distance";
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'origin_offset' property.
        /// </summary>
        public static readonly StringName OriginOffset = "origin_offset";
        /// <summary>
        /// Cached name for the 'box_projection' property.
        /// </summary>
        public static readonly StringName BoxProjection = "box_projection";
        /// <summary>
        /// Cached name for the 'interior' property.
        /// </summary>
        public static readonly StringName Interior = "interior";
        /// <summary>
        /// Cached name for the 'enable_shadows' property.
        /// </summary>
        public static readonly StringName EnableShadows = "enable_shadows";
        /// <summary>
        /// Cached name for the 'cull_mask' property.
        /// </summary>
        public static readonly StringName CullMask = "cull_mask";
        /// <summary>
        /// Cached name for the 'reflection_mask' property.
        /// </summary>
        public static readonly StringName ReflectionMask = "reflection_mask";
        /// <summary>
        /// Cached name for the 'mesh_lod_threshold' property.
        /// </summary>
        public static readonly StringName MeshLodThreshold = "mesh_lod_threshold";
        /// <summary>
        /// Cached name for the 'ambient_mode' property.
        /// </summary>
        public static readonly StringName AmbientMode = "ambient_mode";
        /// <summary>
        /// Cached name for the 'ambient_color' property.
        /// </summary>
        public static readonly StringName AmbientColor = "ambient_color";
        /// <summary>
        /// Cached name for the 'ambient_color_energy' property.
        /// </summary>
        public static readonly StringName AmbientColorEnergy = "ambient_color_energy";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_intensity' method.
        /// </summary>
        public static readonly StringName SetIntensity = "set_intensity";
        /// <summary>
        /// Cached name for the 'get_intensity' method.
        /// </summary>
        public static readonly StringName GetIntensity = "get_intensity";
        /// <summary>
        /// Cached name for the 'set_blend_distance' method.
        /// </summary>
        public static readonly StringName SetBlendDistance = "set_blend_distance";
        /// <summary>
        /// Cached name for the 'get_blend_distance' method.
        /// </summary>
        public static readonly StringName GetBlendDistance = "get_blend_distance";
        /// <summary>
        /// Cached name for the 'set_ambient_mode' method.
        /// </summary>
        public static readonly StringName SetAmbientMode = "set_ambient_mode";
        /// <summary>
        /// Cached name for the 'get_ambient_mode' method.
        /// </summary>
        public static readonly StringName GetAmbientMode = "get_ambient_mode";
        /// <summary>
        /// Cached name for the 'set_ambient_color' method.
        /// </summary>
        public static readonly StringName SetAmbientColor = "set_ambient_color";
        /// <summary>
        /// Cached name for the 'get_ambient_color' method.
        /// </summary>
        public static readonly StringName GetAmbientColor = "get_ambient_color";
        /// <summary>
        /// Cached name for the 'set_ambient_color_energy' method.
        /// </summary>
        public static readonly StringName SetAmbientColorEnergy = "set_ambient_color_energy";
        /// <summary>
        /// Cached name for the 'get_ambient_color_energy' method.
        /// </summary>
        public static readonly StringName GetAmbientColorEnergy = "get_ambient_color_energy";
        /// <summary>
        /// Cached name for the 'set_max_distance' method.
        /// </summary>
        public static readonly StringName SetMaxDistance = "set_max_distance";
        /// <summary>
        /// Cached name for the 'get_max_distance' method.
        /// </summary>
        public static readonly StringName GetMaxDistance = "get_max_distance";
        /// <summary>
        /// Cached name for the 'set_mesh_lod_threshold' method.
        /// </summary>
        public static readonly StringName SetMeshLodThreshold = "set_mesh_lod_threshold";
        /// <summary>
        /// Cached name for the 'get_mesh_lod_threshold' method.
        /// </summary>
        public static readonly StringName GetMeshLodThreshold = "get_mesh_lod_threshold";
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'set_origin_offset' method.
        /// </summary>
        public static readonly StringName SetOriginOffset = "set_origin_offset";
        /// <summary>
        /// Cached name for the 'get_origin_offset' method.
        /// </summary>
        public static readonly StringName GetOriginOffset = "get_origin_offset";
        /// <summary>
        /// Cached name for the 'set_as_interior' method.
        /// </summary>
        public static readonly StringName SetAsInterior = "set_as_interior";
        /// <summary>
        /// Cached name for the 'is_set_as_interior' method.
        /// </summary>
        public static readonly StringName IsSetAsInterior = "is_set_as_interior";
        /// <summary>
        /// Cached name for the 'set_enable_box_projection' method.
        /// </summary>
        public static readonly StringName SetEnableBoxProjection = "set_enable_box_projection";
        /// <summary>
        /// Cached name for the 'is_box_projection_enabled' method.
        /// </summary>
        public static readonly StringName IsBoxProjectionEnabled = "is_box_projection_enabled";
        /// <summary>
        /// Cached name for the 'set_enable_shadows' method.
        /// </summary>
        public static readonly StringName SetEnableShadows = "set_enable_shadows";
        /// <summary>
        /// Cached name for the 'are_shadows_enabled' method.
        /// </summary>
        public static readonly StringName AreShadowsEnabled = "are_shadows_enabled";
        /// <summary>
        /// Cached name for the 'set_cull_mask' method.
        /// </summary>
        public static readonly StringName SetCullMask = "set_cull_mask";
        /// <summary>
        /// Cached name for the 'get_cull_mask' method.
        /// </summary>
        public static readonly StringName GetCullMask = "get_cull_mask";
        /// <summary>
        /// Cached name for the 'set_reflection_mask' method.
        /// </summary>
        public static readonly StringName SetReflectionMask = "set_reflection_mask";
        /// <summary>
        /// Cached name for the 'get_reflection_mask' method.
        /// </summary>
        public static readonly StringName GetReflectionMask = "get_reflection_mask";
        /// <summary>
        /// Cached name for the 'set_update_mode' method.
        /// </summary>
        public static readonly StringName SetUpdateMode = "set_update_mode";
        /// <summary>
        /// Cached name for the 'get_update_mode' method.
        /// </summary>
        public static readonly StringName GetUpdateMode = "get_update_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualInstance3D.SignalName
    {
    }
}
