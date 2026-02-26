namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object is used by <see cref="Godot.RenderingDevice"/>.</para>
/// </summary>
public partial class RDPipelineRasterizationState : RefCounted
{
    /// <summary>
    /// <para>If <see langword="true"/>, clamps depth values according to the minimum and maximum depth of the associated viewport.</para>
    /// </summary>
    public bool EnableDepthClamp
    {
        get
        {
            return GetEnableDepthClamp();
        }
        set
        {
            SetEnableDepthClamp(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, primitives are discarded immediately before the rasterization stage.</para>
    /// </summary>
    public bool DiscardPrimitives
    {
        get
        {
            return GetDiscardPrimitives();
        }
        set
        {
            SetDiscardPrimitives(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, performs wireframe rendering for triangles instead of flat or textured rendering.</para>
    /// </summary>
    public bool Wireframe
    {
        get
        {
            return GetWireframe();
        }
        set
        {
            SetWireframe(value);
        }
    }

    /// <summary>
    /// <para>The cull mode to use when drawing polygons, which determines whether front faces or backfaces are hidden.</para>
    /// </summary>
    public RenderingDevice.PolygonCullMode CullMode
    {
        get
        {
            return GetCullMode();
        }
        set
        {
            SetCullMode(value);
        }
    }

    /// <summary>
    /// <para>The winding order to use to determine which face of a triangle is considered its front face.</para>
    /// </summary>
    public RenderingDevice.PolygonFrontFace FrontFace
    {
        get
        {
            return GetFrontFace();
        }
        set
        {
            SetFrontFace(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, each generated depth value will by offset by some amount. The specific amount is generated per polygon based on the values of <see cref="Godot.RDPipelineRasterizationState.DepthBiasSlopeFactor"/> and <see cref="Godot.RDPipelineRasterizationState.DepthBiasConstantFactor"/>.</para>
    /// </summary>
    public bool DepthBiasEnabled
    {
        get
        {
            return GetDepthBiasEnabled();
        }
        set
        {
            SetDepthBiasEnabled(value);
        }
    }

    /// <summary>
    /// <para>A constant offset added to each depth value. Applied after <see cref="Godot.RDPipelineRasterizationState.DepthBiasSlopeFactor"/>.</para>
    /// </summary>
    public float DepthBiasConstantFactor
    {
        get
        {
            return GetDepthBiasConstantFactor();
        }
        set
        {
            SetDepthBiasConstantFactor(value);
        }
    }

    /// <summary>
    /// <para>A limit for how much each depth value can be offset. If negative, it serves as a minimum value, but if positive, it serves as a maximum value.</para>
    /// </summary>
    public float DepthBiasClamp
    {
        get
        {
            return GetDepthBiasClamp();
        }
        set
        {
            SetDepthBiasClamp(value);
        }
    }

    /// <summary>
    /// <para>A constant scale applied to the slope of each polygons' depth. Applied before <see cref="Godot.RDPipelineRasterizationState.DepthBiasConstantFactor"/>.</para>
    /// </summary>
    public float DepthBiasSlopeFactor
    {
        get
        {
            return GetDepthBiasSlopeFactor();
        }
        set
        {
            SetDepthBiasSlopeFactor(value);
        }
    }

    /// <summary>
    /// <para>The line width to use when drawing lines (in pixels). Thick lines may not be supported on all hardware.</para>
    /// </summary>
    public float LineWidth
    {
        get
        {
            return GetLineWidth();
        }
        set
        {
            SetLineWidth(value);
        }
    }

    /// <summary>
    /// <para>The number of control points to use when drawing a patch with tessellation enabled. Higher values result in higher quality at the cost of performance.</para>
    /// </summary>
    public uint PatchControlPoints
    {
        get
        {
            return GetPatchControlPoints();
        }
        set
        {
            SetPatchControlPoints(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDPipelineRasterizationState);

    private static readonly StringName NativeName = "RDPipelineRasterizationState";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDPipelineRasterizationState() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineRasterizationState(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineRasterizationState(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableDepthClamp, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableDepthClamp(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableDepthClamp, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableDepthClamp()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDiscardPrimitives, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDiscardPrimitives(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDiscardPrimitives, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDiscardPrimitives()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWireframe, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWireframe(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWireframe, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetWireframe()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCullMode, 2662586502ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCullMode(RenderingDevice.PolygonCullMode pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCullMode, 2192484313ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.PolygonCullMode GetCullMode()
    {
        return (RenderingDevice.PolygonCullMode)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrontFace, 2637251213ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrontFace(RenderingDevice.PolygonFrontFace pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrontFace, 708793786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.PolygonFrontFace GetFrontFace()
    {
        return (RenderingDevice.PolygonFrontFace)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepthBiasEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepthBiasEnabled(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthBiasEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDepthBiasEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepthBiasConstantFactor, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepthBiasConstantFactor(float pMember)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthBiasConstantFactor, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDepthBiasConstantFactor()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepthBiasClamp, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepthBiasClamp(float pMember)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthBiasClamp, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDepthBiasClamp()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepthBiasSlopeFactor, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepthBiasSlopeFactor(float pMember)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthBiasSlopeFactor, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDepthBiasSlopeFactor()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineWidth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLineWidth(float pMember)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineWidth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLineWidth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPatchControlPoints, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPatchControlPoints(uint pMember)
    {
        NativeCalls.godot_icall_1_208(MethodBind20, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPatchControlPoints, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetPatchControlPoints()
    {
        return NativeCalls.godot_icall_0_209(MethodBind21, GodotObject.GetPtr(this));
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
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'enable_depth_clamp' property.
        /// </summary>
        public static readonly StringName EnableDepthClamp = "enable_depth_clamp";
        /// <summary>
        /// Cached name for the 'discard_primitives' property.
        /// </summary>
        public static readonly StringName DiscardPrimitives = "discard_primitives";
        /// <summary>
        /// Cached name for the 'wireframe' property.
        /// </summary>
        public static readonly StringName Wireframe = "wireframe";
        /// <summary>
        /// Cached name for the 'cull_mode' property.
        /// </summary>
        public static readonly StringName CullMode = "cull_mode";
        /// <summary>
        /// Cached name for the 'front_face' property.
        /// </summary>
        public static readonly StringName FrontFace = "front_face";
        /// <summary>
        /// Cached name for the 'depth_bias_enabled' property.
        /// </summary>
        public static readonly StringName DepthBiasEnabled = "depth_bias_enabled";
        /// <summary>
        /// Cached name for the 'depth_bias_constant_factor' property.
        /// </summary>
        public static readonly StringName DepthBiasConstantFactor = "depth_bias_constant_factor";
        /// <summary>
        /// Cached name for the 'depth_bias_clamp' property.
        /// </summary>
        public static readonly StringName DepthBiasClamp = "depth_bias_clamp";
        /// <summary>
        /// Cached name for the 'depth_bias_slope_factor' property.
        /// </summary>
        public static readonly StringName DepthBiasSlopeFactor = "depth_bias_slope_factor";
        /// <summary>
        /// Cached name for the 'line_width' property.
        /// </summary>
        public static readonly StringName LineWidth = "line_width";
        /// <summary>
        /// Cached name for the 'patch_control_points' property.
        /// </summary>
        public static readonly StringName PatchControlPoints = "patch_control_points";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_enable_depth_clamp' method.
        /// </summary>
        public static readonly StringName SetEnableDepthClamp = "set_enable_depth_clamp";
        /// <summary>
        /// Cached name for the 'get_enable_depth_clamp' method.
        /// </summary>
        public static readonly StringName GetEnableDepthClamp = "get_enable_depth_clamp";
        /// <summary>
        /// Cached name for the 'set_discard_primitives' method.
        /// </summary>
        public static readonly StringName SetDiscardPrimitives = "set_discard_primitives";
        /// <summary>
        /// Cached name for the 'get_discard_primitives' method.
        /// </summary>
        public static readonly StringName GetDiscardPrimitives = "get_discard_primitives";
        /// <summary>
        /// Cached name for the 'set_wireframe' method.
        /// </summary>
        public static readonly StringName SetWireframe = "set_wireframe";
        /// <summary>
        /// Cached name for the 'get_wireframe' method.
        /// </summary>
        public static readonly StringName GetWireframe = "get_wireframe";
        /// <summary>
        /// Cached name for the 'set_cull_mode' method.
        /// </summary>
        public static readonly StringName SetCullMode = "set_cull_mode";
        /// <summary>
        /// Cached name for the 'get_cull_mode' method.
        /// </summary>
        public static readonly StringName GetCullMode = "get_cull_mode";
        /// <summary>
        /// Cached name for the 'set_front_face' method.
        /// </summary>
        public static readonly StringName SetFrontFace = "set_front_face";
        /// <summary>
        /// Cached name for the 'get_front_face' method.
        /// </summary>
        public static readonly StringName GetFrontFace = "get_front_face";
        /// <summary>
        /// Cached name for the 'set_depth_bias_enabled' method.
        /// </summary>
        public static readonly StringName SetDepthBiasEnabled = "set_depth_bias_enabled";
        /// <summary>
        /// Cached name for the 'get_depth_bias_enabled' method.
        /// </summary>
        public static readonly StringName GetDepthBiasEnabled = "get_depth_bias_enabled";
        /// <summary>
        /// Cached name for the 'set_depth_bias_constant_factor' method.
        /// </summary>
        public static readonly StringName SetDepthBiasConstantFactor = "set_depth_bias_constant_factor";
        /// <summary>
        /// Cached name for the 'get_depth_bias_constant_factor' method.
        /// </summary>
        public static readonly StringName GetDepthBiasConstantFactor = "get_depth_bias_constant_factor";
        /// <summary>
        /// Cached name for the 'set_depth_bias_clamp' method.
        /// </summary>
        public static readonly StringName SetDepthBiasClamp = "set_depth_bias_clamp";
        /// <summary>
        /// Cached name for the 'get_depth_bias_clamp' method.
        /// </summary>
        public static readonly StringName GetDepthBiasClamp = "get_depth_bias_clamp";
        /// <summary>
        /// Cached name for the 'set_depth_bias_slope_factor' method.
        /// </summary>
        public static readonly StringName SetDepthBiasSlopeFactor = "set_depth_bias_slope_factor";
        /// <summary>
        /// Cached name for the 'get_depth_bias_slope_factor' method.
        /// </summary>
        public static readonly StringName GetDepthBiasSlopeFactor = "get_depth_bias_slope_factor";
        /// <summary>
        /// Cached name for the 'set_line_width' method.
        /// </summary>
        public static readonly StringName SetLineWidth = "set_line_width";
        /// <summary>
        /// Cached name for the 'get_line_width' method.
        /// </summary>
        public static readonly StringName GetLineWidth = "get_line_width";
        /// <summary>
        /// Cached name for the 'set_patch_control_points' method.
        /// </summary>
        public static readonly StringName SetPatchControlPoints = "set_patch_control_points";
        /// <summary>
        /// Cached name for the 'get_patch_control_points' method.
        /// </summary>
        public static readonly StringName GetPatchControlPoints = "get_patch_control_points";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
