namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>MultiMesh provides low-level mesh instancing. Drawing thousands of <see cref="Godot.MeshInstance3D"/> nodes can be slow, since each object is submitted to the GPU then drawn individually.</para>
/// <para>MultiMesh is much faster as it can draw thousands of instances with a single draw call, resulting in less API overhead.</para>
/// <para>As a drawback, if the instances are too far away from each other, performance may be reduced as every single instance will always render (they are spatially indexed as one, for the whole object).</para>
/// <para>Since instances may have any behavior, the AABB used for visibility must be provided by the user.</para>
/// <para><b>Note:</b> A MultiMesh is a single object, therefore the same maximum lights per object restriction applies. This means, that once the maximum lights are consumed by one or more instances, the rest of the MultiMesh instances will <b>not</b> receive any lighting.</para>
/// <para><b>Note:</b> Blend Shapes will be ignored if used in a MultiMesh.</para>
/// </summary>
public partial class MultiMesh : Resource
{
    public enum TransformFormatEnum : long
    {
        /// <summary>
        /// <para>Use this when using 2D transforms.</para>
        /// </summary>
        Transform2D = 0,
        /// <summary>
        /// <para>Use this when using 3D transforms.</para>
        /// </summary>
        Transform3D = 1
    }

    public enum PhysicsInterpolationQualityEnum : long
    {
        /// <summary>
        /// <para>Always interpolate using Basis lerping, which can produce warping artifacts in some situations.</para>
        /// </summary>
        Fast = 0,
        /// <summary>
        /// <para>Attempt to interpolate using Basis slerping (spherical linear interpolation) where possible, otherwise fall back to lerping.</para>
        /// </summary>
        High = 1
    }

    /// <summary>
    /// <para>Format of transform used to transform mesh, either 2D or 3D.</para>
    /// </summary>
    public MultiMesh.TransformFormatEnum TransformFormat
    {
        get
        {
            return GetTransformFormat();
        }
        set
        {
            SetTransformFormat(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.MultiMesh"/> will use color data (see <see cref="Godot.MultiMesh.SetInstanceColor(int, Color)"/>). Can only be set when <see cref="Godot.MultiMesh.InstanceCount"/> is <c>0</c> or less. This means that you need to call this method before setting the instance count, or temporarily reset it to <c>0</c>.</para>
    /// </summary>
    public bool UseColors
    {
        get
        {
            return IsUsingColors();
        }
        set
        {
            SetUseColors(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.MultiMesh"/> will use custom data (see <see cref="Godot.MultiMesh.SetInstanceCustomData(int, Color)"/>). Can only be set when <see cref="Godot.MultiMesh.InstanceCount"/> is <c>0</c> or less. This means that you need to call this method before setting the instance count, or temporarily reset it to <c>0</c>.</para>
    /// </summary>
    public bool UseCustomData
    {
        get
        {
            return IsUsingCustomData();
        }
        set
        {
            SetUseCustomData(value);
        }
    }

    /// <summary>
    /// <para>Custom AABB for this MultiMesh resource. Setting this manually prevents costly runtime AABB recalculations.</para>
    /// </summary>
    public Aabb CustomAabb
    {
        get
        {
            return GetCustomAabb();
        }
        set
        {
            SetCustomAabb(value);
        }
    }

    /// <summary>
    /// <para>Number of instances that will get drawn. This clears and (re)sizes the buffers. Setting data format or flags afterwards will have no effect.</para>
    /// <para>By default, all instances are drawn but you can limit this with <see cref="Godot.MultiMesh.VisibleInstanceCount"/>.</para>
    /// </summary>
    public int InstanceCount
    {
        get
        {
            return GetInstanceCount();
        }
        set
        {
            SetInstanceCount(value);
        }
    }

    /// <summary>
    /// <para>Limits the number of instances drawn, -1 draws all instances. Changing this does not change the sizes of the buffers.</para>
    /// </summary>
    public int VisibleInstanceCount
    {
        get
        {
            return GetVisibleInstanceCount();
        }
        set
        {
            SetVisibleInstanceCount(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Mesh"/> resource to be instanced.</para>
    /// <para>The looks of the individual instances can be modified using <see cref="Godot.MultiMesh.SetInstanceColor(int, Color)"/> and <see cref="Godot.MultiMesh.SetInstanceCustomData(int, Color)"/>.</para>
    /// </summary>
    public Mesh Mesh
    {
        get
        {
            return GetMesh();
        }
        set
        {
            SetMesh(value);
        }
    }

    public float[] Buffer
    {
        get
        {
            return GetBuffer();
        }
        set
        {
            SetBuffer(value);
        }
    }

    /// <summary>
    /// <para>Array containing each <see cref="Godot.Transform3D"/> value used by all instances of this mesh, as a <see cref="Godot.Vector3"/>[]. Each transform is divided into 4 <see cref="Godot.Vector3"/> values corresponding to the transforms' <c>x</c>, <c>y</c>, <c>z</c>, and <c>origin</c>.</para>
    /// </summary>
    [Obsolete("Accessing this property is very slow. Use 'Godot.MultiMesh.SetInstanceTransform(int, Transform3D)' and 'Godot.MultiMesh.GetInstanceTransform(int)' instead.")]
    public Vector3[] TransformArray
    {
        get
        {
            return _GetTransformArray();
        }
        set
        {
            _SetTransformArray(value);
        }
    }

    /// <summary>
    /// <para>Array containing each <see cref="Godot.Transform2D"/> value used by all instances of this mesh, as a <see cref="Godot.Vector2"/>[]. Each transform is divided into 3 <see cref="Godot.Vector2"/> values corresponding to the transforms' <c>x</c>, <c>y</c>, and <c>origin</c>.</para>
    /// </summary>
    [Obsolete("Accessing this property is very slow. Use 'Godot.MultiMesh.SetInstanceTransform2D(int, Transform2D)' and 'Godot.MultiMesh.GetInstanceTransform2D(int)' instead.")]
    public Vector2[] Transform2DArray
    {
        get
        {
            return _GetTransform2DArray();
        }
        set
        {
            _SetTransform2DArray(value);
        }
    }

    /// <summary>
    /// <para>Array containing each <see cref="Godot.Color"/> used by all instances of this mesh.</para>
    /// </summary>
    [Obsolete("Accessing this property is very slow. Use 'Godot.MultiMesh.SetInstanceColor(int, Color)' and 'Godot.MultiMesh.GetInstanceColor(int)' instead.")]
    public Color[] ColorArray
    {
        get
        {
            return _GetColorArray();
        }
        set
        {
            _SetColorArray(value);
        }
    }

    /// <summary>
    /// <para>Array containing each custom data value used by all instances of this mesh, as a <see cref="Godot.Color"/>[].</para>
    /// </summary>
    [Obsolete("Accessing this property is very slow. Use 'Godot.MultiMesh.SetInstanceCustomData(int, Color)' and 'Godot.MultiMesh.GetInstanceCustomData(int)' instead.")]
    public Color[] CustomDataArray
    {
        get
        {
            return _GetCustomDataArray();
        }
        set
        {
            _SetCustomDataArray(value);
        }
    }

    /// <summary>
    /// <para>Choose whether to use an interpolation method that favors speed or quality.</para>
    /// <para>When using low physics tick rates (typically below 20) or high rates of object rotation, you may get better results from the high quality setting.</para>
    /// <para><b>Note:</b> Fast quality does not equate to low quality. Except in the special cases mentioned above, the quality should be comparable to high quality.</para>
    /// </summary>
    public MultiMesh.PhysicsInterpolationQualityEnum PhysicsInterpolationQuality
    {
        get
        {
            return GetPhysicsInterpolationQuality();
        }
        set
        {
            SetPhysicsInterpolationQuality(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MultiMesh);

    private static readonly StringName NativeName = "MultiMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MultiMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal MultiMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MultiMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMesh, 194775623ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMesh(Mesh mesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMesh, 1808005922ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Mesh GetMesh()
    {
        return (Mesh)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseColors, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseColors(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingColors, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingColors()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseCustomData, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseCustomData(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingCustomData, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingCustomData()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransformFormat, 2404750322ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTransformFormat(MultiMesh.TransformFormatEnum format)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)format);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransformFormat, 2444156481ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MultiMesh.TransformFormatEnum GetTransformFormat()
    {
        return (MultiMesh.TransformFormatEnum)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInstanceCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInstanceCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetInstanceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibleInstanceCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibleInstanceCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleInstanceCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetVisibleInstanceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsInterpolationQuality, 1819488408ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicsInterpolationQuality(MultiMesh.PhysicsInterpolationQualityEnum quality)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)quality);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsInterpolationQuality, 1465701882ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MultiMesh.PhysicsInterpolationQualityEnum GetPhysicsInterpolationQuality()
    {
        return (MultiMesh.PhysicsInterpolationQualityEnum)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInstanceTransform, 3616898986ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform3D"/> for a specific instance.</para>
    /// </summary>
    public unsafe void SetInstanceTransform(int instance, Transform3D transform)
    {
        NativeCalls.godot_icall_2_800(MethodBind14, GodotObject.GetPtr(this), instance, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInstanceTransform2D, 30160968ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Transform2D"/> for a specific instance.</para>
    /// </summary>
    public unsafe void SetInstanceTransform2D(int instance, Transform2D transform)
    {
        NativeCalls.godot_icall_2_607(MethodBind15, GodotObject.GetPtr(this), instance, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceTransform, 1965739696ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform3D"/> of a specific instance.</para>
    /// </summary>
    public Transform3D GetInstanceTransform(int instance)
    {
        return NativeCalls.godot_icall_1_803(MethodBind16, GodotObject.GetPtr(this), instance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceTransform2D, 3836996910ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform2D"/> of a specific instance.</para>
    /// </summary>
    public Transform2D GetInstanceTransform2D(int instance)
    {
        return NativeCalls.godot_icall_1_608(MethodBind17, GodotObject.GetPtr(this), instance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInstanceColor, 2878471219ul);

    /// <summary>
    /// <para>Sets the color of a specific instance by <i>multiplying</i> the mesh's existing vertex colors. This allows for different color tinting per instance.</para>
    /// <para><b>Note:</b> Each component is stored in 32 bits in the Forward+ and Mobile rendering methods, but is packed into 16 bits in the Compatibility rendering method.</para>
    /// <para>For the color to take effect, ensure that <see cref="Godot.MultiMesh.UseColors"/> is <see langword="true"/> on the <see cref="Godot.MultiMesh"/> and <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> is <see langword="true"/> on the material. If you intend to set an absolute color instead of tinting, make sure the material's albedo color is set to pure white (<c>Color(1, 1, 1)</c>).</para>
    /// </summary>
    public unsafe void SetInstanceColor(int instance, Color color)
    {
        NativeCalls.godot_icall_2_687(MethodBind18, GodotObject.GetPtr(this), instance, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceColor, 3457211756ul);

    /// <summary>
    /// <para>Gets a specific instance's color multiplier.</para>
    /// </summary>
    public Color GetInstanceColor(int instance)
    {
        return NativeCalls.godot_icall_1_688(MethodBind19, GodotObject.GetPtr(this), instance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInstanceCustomData, 2878471219ul);

    /// <summary>
    /// <para>Sets custom data for a specific instance. <paramref name="customData"/> is a <see cref="Godot.Color"/> type only to contain 4 floating-point numbers.</para>
    /// <para><b>Note:</b> Each number is stored in 32 bits in the Forward+ and Mobile rendering methods, but is packed into 16 bits in the Compatibility rendering method.</para>
    /// <para>For the custom data to be used, ensure that <see cref="Godot.MultiMesh.UseCustomData"/> is <see langword="true"/>.</para>
    /// <para>This custom instance data has to be manually accessed in your custom shader using <c>INSTANCE_CUSTOM</c>.</para>
    /// </summary>
    public unsafe void SetInstanceCustomData(int instance, Color customData)
    {
        NativeCalls.godot_icall_2_687(MethodBind20, GodotObject.GetPtr(this), instance, &customData);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceCustomData, 3457211756ul);

    /// <summary>
    /// <para>Returns the custom data that has been set for a specific instance.</para>
    /// </summary>
    public Color GetInstanceCustomData(int instance)
    {
        return NativeCalls.godot_icall_1_688(MethodBind21, GodotObject.GetPtr(this), instance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResetInstancePhysicsInterpolation, 1286410249ul);

    /// <summary>
    /// <para>When using <i>physics interpolation</i>, this function allows you to prevent interpolation on an instance in the current physics tick.</para>
    /// <para>This allows you to move instances instantaneously, and should usually be used when initially placing an instance such as a bullet to prevent graphical glitches.</para>
    /// </summary>
    public void ResetInstancePhysicsInterpolation(int instance)
    {
        NativeCalls.godot_icall_1_38(MethodBind22, GodotObject.GetPtr(this), instance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResetInstancesPhysicsInterpolation, 3218959716ul);

    /// <summary>
    /// <para>When using <i>physics interpolation</i>, this function allows you to prevent interpolation for all instances in the current physics tick.</para>
    /// <para>This allows you to move all instances instantaneously, and should usually be used when initially placing instances to prevent graphical glitches.</para>
    /// </summary>
    public void ResetInstancesPhysicsInterpolation()
    {
        NativeCalls.godot_icall_0_3(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomAabb, 259215842ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCustomAabb(Aabb aabb)
    {
        NativeCalls.godot_icall_1_183(MethodBind24, GodotObject.GetPtr(this), &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomAabb, 1068685055ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Aabb GetCustomAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAabb, 1068685055ul);

    /// <summary>
    /// <para>Returns the visibility axis-aligned bounding box in local space.</para>
    /// </summary>
    public Aabb GetAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBuffer, 675695659ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float[] GetBuffer()
    {
        return NativeCalls.godot_icall_0_368(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBuffer, 2899603908ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBuffer(float[] buffer)
    {
        NativeCalls.godot_icall_1_647(MethodBind28, GodotObject.GetPtr(this), buffer);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBuffer(ReadOnlySpan<float> buffer)
    {
        NativeCalls.godot_icall_1_647(MethodBind28, GodotObject.GetPtr(this), buffer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBufferInterpolated, 3514430332ul);

    /// <summary>
    /// <para>An alternative to setting the <see cref="Godot.MultiMesh.Buffer"/> property, which can be used with <i>physics interpolation</i>. This method takes two arrays, and can set the data for the current and previous tick in one go. The renderer will automatically interpolate the data at each frame.</para>
    /// <para>This is useful for situations where the order of instances may change from physics tick to tick, such as particle systems.</para>
    /// <para>When the order of instances is coherent, the simpler alternative of setting <see cref="Godot.MultiMesh.Buffer"/> can still be used with interpolation.</para>
    /// </summary>
    public void SetBufferInterpolated(float[] bufferCurr, float[] bufferPrev)
    {
        NativeCalls.godot_icall_2_804(MethodBind29, GodotObject.GetPtr(this), bufferCurr, bufferPrev);
    }

    /// <summary>
    /// <para>An alternative to setting the <see cref="Godot.MultiMesh.Buffer"/> property, which can be used with <i>physics interpolation</i>. This method takes two arrays, and can set the data for the current and previous tick in one go. The renderer will automatically interpolate the data at each frame.</para>
    /// <para>This is useful for situations where the order of instances may change from physics tick to tick, such as particle systems.</para>
    /// <para>When the order of instances is coherent, the simpler alternative of setting <see cref="Godot.MultiMesh.Buffer"/> can still be used with interpolation.</para>
    /// </summary>
    public void SetBufferInterpolated(ReadOnlySpan<float> bufferCurr, ReadOnlySpan<float> bufferPrev)
    {
        NativeCalls.godot_icall_2_804(MethodBind29, GodotObject.GetPtr(this), bufferCurr, bufferPrev);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetTransformArray, 334873810ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void _SetTransformArray(Vector3[] array)
    {
        NativeCalls.godot_icall_1_187(MethodBind30, GodotObject.GetPtr(this), array);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetTransformArray, 497664490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal Vector3[] _GetTransformArray()
    {
        return NativeCalls.godot_icall_0_228(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetTransform2DArray, 1509147220ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void _SetTransform2DArray(Vector2[] array)
    {
        NativeCalls.godot_icall_1_224(MethodBind32, GodotObject.GetPtr(this), array);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetTransform2DArray, 2961356807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal Vector2[] _GetTransform2DArray()
    {
        return NativeCalls.godot_icall_0_225(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetColorArray, 3546319833ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void _SetColorArray(Color[] array)
    {
        NativeCalls.godot_icall_1_226(MethodBind34, GodotObject.GetPtr(this), array);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetColorArray, 1392750486ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal Color[] _GetColorArray()
    {
        return NativeCalls.godot_icall_0_227(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetCustomDataArray, 3546319833ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void _SetCustomDataArray(Color[] array)
    {
        NativeCalls.godot_icall_1_226(MethodBind36, GodotObject.GetPtr(this), array);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetCustomDataArray, 1392750486ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal Color[] _GetCustomDataArray()
    {
        return NativeCalls.godot_icall_0_227(MethodBind37, GodotObject.GetPtr(this));
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
        /// Cached name for the 'transform_format' property.
        /// </summary>
        public static readonly StringName TransformFormat = "transform_format";
        /// <summary>
        /// Cached name for the 'use_colors' property.
        /// </summary>
        public static readonly StringName UseColors = "use_colors";
        /// <summary>
        /// Cached name for the 'use_custom_data' property.
        /// </summary>
        public static readonly StringName UseCustomData = "use_custom_data";
        /// <summary>
        /// Cached name for the 'custom_aabb' property.
        /// </summary>
        public static readonly StringName CustomAabb = "custom_aabb";
        /// <summary>
        /// Cached name for the 'instance_count' property.
        /// </summary>
        public static readonly StringName InstanceCount = "instance_count";
        /// <summary>
        /// Cached name for the 'visible_instance_count' property.
        /// </summary>
        public static readonly StringName VisibleInstanceCount = "visible_instance_count";
        /// <summary>
        /// Cached name for the 'mesh' property.
        /// </summary>
        public static readonly StringName Mesh = "mesh";
        /// <summary>
        /// Cached name for the 'buffer' property.
        /// </summary>
        public static readonly StringName Buffer = "buffer";
        /// <summary>
        /// Cached name for the 'transform_array' property.
        /// </summary>
        public static readonly StringName TransformArray = "transform_array";
        /// <summary>
        /// Cached name for the 'transform_2d_array' property.
        /// </summary>
        public static readonly StringName Transform2DArray = "transform_2d_array";
        /// <summary>
        /// Cached name for the 'color_array' property.
        /// </summary>
        public static readonly StringName ColorArray = "color_array";
        /// <summary>
        /// Cached name for the 'custom_data_array' property.
        /// </summary>
        public static readonly StringName CustomDataArray = "custom_data_array";
        /// <summary>
        /// Cached name for the 'physics_interpolation_quality' property.
        /// </summary>
        public static readonly StringName PhysicsInterpolationQuality = "physics_interpolation_quality";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_mesh' method.
        /// </summary>
        public static readonly StringName SetMesh = "set_mesh";
        /// <summary>
        /// Cached name for the 'get_mesh' method.
        /// </summary>
        public static readonly StringName GetMesh = "get_mesh";
        /// <summary>
        /// Cached name for the 'set_use_colors' method.
        /// </summary>
        public static readonly StringName SetUseColors = "set_use_colors";
        /// <summary>
        /// Cached name for the 'is_using_colors' method.
        /// </summary>
        public static readonly StringName IsUsingColors = "is_using_colors";
        /// <summary>
        /// Cached name for the 'set_use_custom_data' method.
        /// </summary>
        public static readonly StringName SetUseCustomData = "set_use_custom_data";
        /// <summary>
        /// Cached name for the 'is_using_custom_data' method.
        /// </summary>
        public static readonly StringName IsUsingCustomData = "is_using_custom_data";
        /// <summary>
        /// Cached name for the 'set_transform_format' method.
        /// </summary>
        public static readonly StringName SetTransformFormat = "set_transform_format";
        /// <summary>
        /// Cached name for the 'get_transform_format' method.
        /// </summary>
        public static readonly StringName GetTransformFormat = "get_transform_format";
        /// <summary>
        /// Cached name for the 'set_instance_count' method.
        /// </summary>
        public static readonly StringName SetInstanceCount = "set_instance_count";
        /// <summary>
        /// Cached name for the 'get_instance_count' method.
        /// </summary>
        public static readonly StringName GetInstanceCount = "get_instance_count";
        /// <summary>
        /// Cached name for the 'set_visible_instance_count' method.
        /// </summary>
        public static readonly StringName SetVisibleInstanceCount = "set_visible_instance_count";
        /// <summary>
        /// Cached name for the 'get_visible_instance_count' method.
        /// </summary>
        public static readonly StringName GetVisibleInstanceCount = "get_visible_instance_count";
        /// <summary>
        /// Cached name for the 'set_physics_interpolation_quality' method.
        /// </summary>
        public static readonly StringName SetPhysicsInterpolationQuality = "set_physics_interpolation_quality";
        /// <summary>
        /// Cached name for the 'get_physics_interpolation_quality' method.
        /// </summary>
        public static readonly StringName GetPhysicsInterpolationQuality = "get_physics_interpolation_quality";
        /// <summary>
        /// Cached name for the 'set_instance_transform' method.
        /// </summary>
        public static readonly StringName SetInstanceTransform = "set_instance_transform";
        /// <summary>
        /// Cached name for the 'set_instance_transform_2d' method.
        /// </summary>
        public static readonly StringName SetInstanceTransform2D = "set_instance_transform_2d";
        /// <summary>
        /// Cached name for the 'get_instance_transform' method.
        /// </summary>
        public static readonly StringName GetInstanceTransform = "get_instance_transform";
        /// <summary>
        /// Cached name for the 'get_instance_transform_2d' method.
        /// </summary>
        public static readonly StringName GetInstanceTransform2D = "get_instance_transform_2d";
        /// <summary>
        /// Cached name for the 'set_instance_color' method.
        /// </summary>
        public static readonly StringName SetInstanceColor = "set_instance_color";
        /// <summary>
        /// Cached name for the 'get_instance_color' method.
        /// </summary>
        public static readonly StringName GetInstanceColor = "get_instance_color";
        /// <summary>
        /// Cached name for the 'set_instance_custom_data' method.
        /// </summary>
        public static readonly StringName SetInstanceCustomData = "set_instance_custom_data";
        /// <summary>
        /// Cached name for the 'get_instance_custom_data' method.
        /// </summary>
        public static readonly StringName GetInstanceCustomData = "get_instance_custom_data";
        /// <summary>
        /// Cached name for the 'reset_instance_physics_interpolation' method.
        /// </summary>
        public static readonly StringName ResetInstancePhysicsInterpolation = "reset_instance_physics_interpolation";
        /// <summary>
        /// Cached name for the 'reset_instances_physics_interpolation' method.
        /// </summary>
        public static readonly StringName ResetInstancesPhysicsInterpolation = "reset_instances_physics_interpolation";
        /// <summary>
        /// Cached name for the 'set_custom_aabb' method.
        /// </summary>
        public static readonly StringName SetCustomAabb = "set_custom_aabb";
        /// <summary>
        /// Cached name for the 'get_custom_aabb' method.
        /// </summary>
        public static readonly StringName GetCustomAabb = "get_custom_aabb";
        /// <summary>
        /// Cached name for the 'get_aabb' method.
        /// </summary>
        public static readonly StringName GetAabb = "get_aabb";
        /// <summary>
        /// Cached name for the 'get_buffer' method.
        /// </summary>
        public static readonly StringName GetBuffer = "get_buffer";
        /// <summary>
        /// Cached name for the 'set_buffer' method.
        /// </summary>
        public static readonly StringName SetBuffer = "set_buffer";
        /// <summary>
        /// Cached name for the 'set_buffer_interpolated' method.
        /// </summary>
        public static readonly StringName SetBufferInterpolated = "set_buffer_interpolated";
        /// <summary>
        /// Cached name for the '_set_transform_array' method.
        /// </summary>
        public static readonly StringName _SetTransformArray = "_set_transform_array";
        /// <summary>
        /// Cached name for the '_get_transform_array' method.
        /// </summary>
        public static readonly StringName _GetTransformArray = "_get_transform_array";
        /// <summary>
        /// Cached name for the '_set_transform_2d_array' method.
        /// </summary>
        public static readonly StringName _SetTransform2DArray = "_set_transform_2d_array";
        /// <summary>
        /// Cached name for the '_get_transform_2d_array' method.
        /// </summary>
        public static readonly StringName _GetTransform2DArray = "_get_transform_2d_array";
        /// <summary>
        /// Cached name for the '_set_color_array' method.
        /// </summary>
        public static readonly StringName _SetColorArray = "_set_color_array";
        /// <summary>
        /// Cached name for the '_get_color_array' method.
        /// </summary>
        public static readonly StringName _GetColorArray = "_get_color_array";
        /// <summary>
        /// Cached name for the '_set_custom_data_array' method.
        /// </summary>
        public static readonly StringName _SetCustomDataArray = "_set_custom_data_array";
        /// <summary>
        /// Cached name for the '_get_custom_data_array' method.
        /// </summary>
        public static readonly StringName _GetCustomDataArray = "_get_custom_data_array";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
