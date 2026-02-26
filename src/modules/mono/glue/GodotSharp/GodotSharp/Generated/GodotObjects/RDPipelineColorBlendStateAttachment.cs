namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Controls how blending between source and destination fragments is performed when using <see cref="Godot.RenderingDevice"/>.</para>
/// <para>For reference, this is how common user-facing blend modes are implemented in Godot's 2D renderer:</para>
/// <para><b>Mix:</b></para>
/// <para><code>
/// var attachment = RDPipelineColorBlendStateAttachment.new()
/// attachment.enable_blend = true
/// attachment.color_blend_op = RenderingDevice.BLEND_OP_ADD
/// attachment.src_color_blend_factor = RenderingDevice.BLEND_FACTOR_SRC_ALPHA
/// attachment.dst_color_blend_factor = RenderingDevice.BLEND_FACTOR_ONE_MINUS_SRC_ALPHA
/// attachment.alpha_blend_op = RenderingDevice.BLEND_OP_ADD
/// attachment.src_alpha_blend_factor = RenderingDevice.BLEND_FACTOR_ONE
/// attachment.dst_alpha_blend_factor = RenderingDevice.BLEND_FACTOR_ONE_MINUS_SRC_ALPHA
/// </code></para>
/// <para><b>Add:</b></para>
/// <para><code>
/// var attachment = RDPipelineColorBlendStateAttachment.new()
/// attachment.enable_blend = true
/// attachment.alpha_blend_op = RenderingDevice.BLEND_OP_ADD
/// attachment.color_blend_op = RenderingDevice.BLEND_OP_ADD
/// attachment.src_color_blend_factor = RenderingDevice.BLEND_FACTOR_SRC_ALPHA
/// attachment.dst_color_blend_factor = RenderingDevice.BLEND_FACTOR_ONE
/// attachment.src_alpha_blend_factor = RenderingDevice.BLEND_FACTOR_SRC_ALPHA
/// attachment.dst_alpha_blend_factor = RenderingDevice.BLEND_FACTOR_ONE
/// </code></para>
/// <para><b>Subtract:</b></para>
/// <para><code>
/// var attachment = RDPipelineColorBlendStateAttachment.new()
/// attachment.enable_blend = true
/// attachment.alpha_blend_op = RenderingDevice.BLEND_OP_REVERSE_SUBTRACT
/// attachment.color_blend_op = RenderingDevice.BLEND_OP_REVERSE_SUBTRACT
/// attachment.src_color_blend_factor = RenderingDevice.BLEND_FACTOR_SRC_ALPHA
/// attachment.dst_color_blend_factor = RenderingDevice.BLEND_FACTOR_ONE
/// attachment.src_alpha_blend_factor = RenderingDevice.BLEND_FACTOR_SRC_ALPHA
/// attachment.dst_alpha_blend_factor = RenderingDevice.BLEND_FACTOR_ONE
/// </code></para>
/// <para><b>Multiply:</b></para>
/// <para><code>
/// var attachment = RDPipelineColorBlendStateAttachment.new()
/// attachment.enable_blend = true
/// attachment.alpha_blend_op = RenderingDevice.BLEND_OP_ADD
/// attachment.color_blend_op = RenderingDevice.BLEND_OP_ADD
/// attachment.src_color_blend_factor = RenderingDevice.BLEND_FACTOR_DST_COLOR
/// attachment.dst_color_blend_factor = RenderingDevice.BLEND_FACTOR_ZERO
/// attachment.src_alpha_blend_factor = RenderingDevice.BLEND_FACTOR_DST_ALPHA
/// attachment.dst_alpha_blend_factor = RenderingDevice.BLEND_FACTOR_ZERO
/// </code></para>
/// <para><b>Pre-multiplied alpha:</b></para>
/// <para><code>
/// var attachment = RDPipelineColorBlendStateAttachment.new()
/// attachment.enable_blend = true
/// attachment.alpha_blend_op = RenderingDevice.BLEND_OP_ADD
/// attachment.color_blend_op = RenderingDevice.BLEND_OP_ADD
/// attachment.src_color_blend_factor = RenderingDevice.BLEND_FACTOR_ONE
/// attachment.dst_color_blend_factor = RenderingDevice.BLEND_FACTOR_ONE_MINUS_SRC_ALPHA
/// attachment.src_alpha_blend_factor = RenderingDevice.BLEND_FACTOR_ONE
/// attachment.dst_alpha_blend_factor = RenderingDevice.BLEND_FACTOR_ONE_MINUS_SRC_ALPHA
/// </code></para>
/// </summary>
public partial class RDPipelineColorBlendStateAttachment : RefCounted
{
    /// <summary>
    /// <para>If <see langword="true"/>, performs blending between the source and destination according to the factors defined in <see cref="Godot.RDPipelineColorBlendStateAttachment.SrcColorBlendFactor"/>, <see cref="Godot.RDPipelineColorBlendStateAttachment.DstColorBlendFactor"/>, <see cref="Godot.RDPipelineColorBlendStateAttachment.SrcAlphaBlendFactor"/> and <see cref="Godot.RDPipelineColorBlendStateAttachment.DstAlphaBlendFactor"/>. The blend modes <see cref="Godot.RDPipelineColorBlendStateAttachment.ColorBlendOp"/> and <see cref="Godot.RDPipelineColorBlendStateAttachment.AlphaBlendOp"/> are also taken into account, with <see cref="Godot.RDPipelineColorBlendStateAttachment.WriteR"/>, <see cref="Godot.RDPipelineColorBlendStateAttachment.WriteG"/>, <see cref="Godot.RDPipelineColorBlendStateAttachment.WriteB"/> and <see cref="Godot.RDPipelineColorBlendStateAttachment.WriteA"/> controlling the output.</para>
    /// </summary>
    public bool EnableBlend
    {
        get
        {
            return GetEnableBlend();
        }
        set
        {
            SetEnableBlend(value);
        }
    }

    /// <summary>
    /// <para>Controls how the blend factor for the color channels is determined based on the source's fragments.</para>
    /// </summary>
    public RenderingDevice.BlendFactor SrcColorBlendFactor
    {
        get
        {
            return GetSrcColorBlendFactor();
        }
        set
        {
            SetSrcColorBlendFactor(value);
        }
    }

    /// <summary>
    /// <para>Controls how the blend factor for the color channels is determined based on the destination's fragments.</para>
    /// </summary>
    public RenderingDevice.BlendFactor DstColorBlendFactor
    {
        get
        {
            return GetDstColorBlendFactor();
        }
        set
        {
            SetDstColorBlendFactor(value);
        }
    }

    /// <summary>
    /// <para>The blend mode to use for the red/green/blue color channels.</para>
    /// </summary>
    public RenderingDevice.BlendOperation ColorBlendOp
    {
        get
        {
            return GetColorBlendOp();
        }
        set
        {
            SetColorBlendOp(value);
        }
    }

    /// <summary>
    /// <para>Controls how the blend factor for the alpha channel is determined based on the source's fragments.</para>
    /// </summary>
    public RenderingDevice.BlendFactor SrcAlphaBlendFactor
    {
        get
        {
            return GetSrcAlphaBlendFactor();
        }
        set
        {
            SetSrcAlphaBlendFactor(value);
        }
    }

    /// <summary>
    /// <para>Controls how the blend factor for the alpha channel is determined based on the destination's fragments.</para>
    /// </summary>
    public RenderingDevice.BlendFactor DstAlphaBlendFactor
    {
        get
        {
            return GetDstAlphaBlendFactor();
        }
        set
        {
            SetDstAlphaBlendFactor(value);
        }
    }

    /// <summary>
    /// <para>The blend mode to use for the alpha channel.</para>
    /// </summary>
    public RenderingDevice.BlendOperation AlphaBlendOp
    {
        get
        {
            return GetAlphaBlendOp();
        }
        set
        {
            SetAlphaBlendOp(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, writes the new red color channel to the final result.</para>
    /// </summary>
    public bool WriteR
    {
        get
        {
            return GetWriteR();
        }
        set
        {
            SetWriteR(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, writes the new green color channel to the final result.</para>
    /// </summary>
    public bool WriteG
    {
        get
        {
            return GetWriteG();
        }
        set
        {
            SetWriteG(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, writes the new blue color channel to the final result.</para>
    /// </summary>
    public bool WriteB
    {
        get
        {
            return GetWriteB();
        }
        set
        {
            SetWriteB(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, writes the new alpha channel to the final result.</para>
    /// </summary>
    public bool WriteA
    {
        get
        {
            return GetWriteA();
        }
        set
        {
            SetWriteA(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDPipelineColorBlendStateAttachment);

    private static readonly StringName NativeName = "RDPipelineColorBlendStateAttachment";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDPipelineColorBlendStateAttachment() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineColorBlendStateAttachment(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineColorBlendStateAttachment(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAsMix, 3218959716ul);

    /// <summary>
    /// <para>Convenience method to perform standard mix blending with straight (non-premultiplied) alpha. This sets <see cref="Godot.RDPipelineColorBlendStateAttachment.EnableBlend"/> to <see langword="true"/>, <see cref="Godot.RDPipelineColorBlendStateAttachment.SrcColorBlendFactor"/> to <see cref="Godot.RenderingDevice.BlendFactor.SrcAlpha"/>, <see cref="Godot.RDPipelineColorBlendStateAttachment.DstColorBlendFactor"/> to <see cref="Godot.RenderingDevice.BlendFactor.OneMinusSrcAlpha"/>, <see cref="Godot.RDPipelineColorBlendStateAttachment.SrcAlphaBlendFactor"/> to <see cref="Godot.RenderingDevice.BlendFactor.SrcAlpha"/> and <see cref="Godot.RDPipelineColorBlendStateAttachment.DstAlphaBlendFactor"/> to <see cref="Godot.RenderingDevice.BlendFactor.OneMinusSrcAlpha"/>.</para>
    /// </summary>
    public void SetAsMix()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableBlend, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableBlend(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind1, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableBlend, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableBlend()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSrcColorBlendFactor, 2251019273ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSrcColorBlendFactor(RenderingDevice.BlendFactor pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSrcColorBlendFactor, 3691288359ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.BlendFactor GetSrcColorBlendFactor()
    {
        return (RenderingDevice.BlendFactor)NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDstColorBlendFactor, 2251019273ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDstColorBlendFactor(RenderingDevice.BlendFactor pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDstColorBlendFactor, 3691288359ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.BlendFactor GetDstColorBlendFactor()
    {
        return (RenderingDevice.BlendFactor)NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColorBlendOp, 3073022720ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColorBlendOp(RenderingDevice.BlendOperation pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorBlendOp, 1385093561ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.BlendOperation GetColorBlendOp()
    {
        return (RenderingDevice.BlendOperation)NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSrcAlphaBlendFactor, 2251019273ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSrcAlphaBlendFactor(RenderingDevice.BlendFactor pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSrcAlphaBlendFactor, 3691288359ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.BlendFactor GetSrcAlphaBlendFactor()
    {
        return (RenderingDevice.BlendFactor)NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDstAlphaBlendFactor, 2251019273ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDstAlphaBlendFactor(RenderingDevice.BlendFactor pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDstAlphaBlendFactor, 3691288359ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.BlendFactor GetDstAlphaBlendFactor()
    {
        return (RenderingDevice.BlendFactor)NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaBlendOp, 3073022720ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaBlendOp(RenderingDevice.BlendOperation pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaBlendOp, 1385093561ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.BlendOperation GetAlphaBlendOp()
    {
        return (RenderingDevice.BlendOperation)NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWriteR, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWriteR(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWriteR, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetWriteR()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWriteG, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWriteG(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWriteG, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetWriteG()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWriteB, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWriteB(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWriteB, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetWriteB()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWriteA, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWriteA(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind21, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWriteA, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetWriteA()
    {
        return NativeCalls.godot_icall_0_15(MethodBind22, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'enable_blend' property.
        /// </summary>
        public static readonly StringName EnableBlend = "enable_blend";
        /// <summary>
        /// Cached name for the 'src_color_blend_factor' property.
        /// </summary>
        public static readonly StringName SrcColorBlendFactor = "src_color_blend_factor";
        /// <summary>
        /// Cached name for the 'dst_color_blend_factor' property.
        /// </summary>
        public static readonly StringName DstColorBlendFactor = "dst_color_blend_factor";
        /// <summary>
        /// Cached name for the 'color_blend_op' property.
        /// </summary>
        public static readonly StringName ColorBlendOp = "color_blend_op";
        /// <summary>
        /// Cached name for the 'src_alpha_blend_factor' property.
        /// </summary>
        public static readonly StringName SrcAlphaBlendFactor = "src_alpha_blend_factor";
        /// <summary>
        /// Cached name for the 'dst_alpha_blend_factor' property.
        /// </summary>
        public static readonly StringName DstAlphaBlendFactor = "dst_alpha_blend_factor";
        /// <summary>
        /// Cached name for the 'alpha_blend_op' property.
        /// </summary>
        public static readonly StringName AlphaBlendOp = "alpha_blend_op";
        /// <summary>
        /// Cached name for the 'write_r' property.
        /// </summary>
        public static readonly StringName WriteR = "write_r";
        /// <summary>
        /// Cached name for the 'write_g' property.
        /// </summary>
        public static readonly StringName WriteG = "write_g";
        /// <summary>
        /// Cached name for the 'write_b' property.
        /// </summary>
        public static readonly StringName WriteB = "write_b";
        /// <summary>
        /// Cached name for the 'write_a' property.
        /// </summary>
        public static readonly StringName WriteA = "write_a";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_as_mix' method.
        /// </summary>
        public static readonly StringName SetAsMix = "set_as_mix";
        /// <summary>
        /// Cached name for the 'set_enable_blend' method.
        /// </summary>
        public static readonly StringName SetEnableBlend = "set_enable_blend";
        /// <summary>
        /// Cached name for the 'get_enable_blend' method.
        /// </summary>
        public static readonly StringName GetEnableBlend = "get_enable_blend";
        /// <summary>
        /// Cached name for the 'set_src_color_blend_factor' method.
        /// </summary>
        public static readonly StringName SetSrcColorBlendFactor = "set_src_color_blend_factor";
        /// <summary>
        /// Cached name for the 'get_src_color_blend_factor' method.
        /// </summary>
        public static readonly StringName GetSrcColorBlendFactor = "get_src_color_blend_factor";
        /// <summary>
        /// Cached name for the 'set_dst_color_blend_factor' method.
        /// </summary>
        public static readonly StringName SetDstColorBlendFactor = "set_dst_color_blend_factor";
        /// <summary>
        /// Cached name for the 'get_dst_color_blend_factor' method.
        /// </summary>
        public static readonly StringName GetDstColorBlendFactor = "get_dst_color_blend_factor";
        /// <summary>
        /// Cached name for the 'set_color_blend_op' method.
        /// </summary>
        public static readonly StringName SetColorBlendOp = "set_color_blend_op";
        /// <summary>
        /// Cached name for the 'get_color_blend_op' method.
        /// </summary>
        public static readonly StringName GetColorBlendOp = "get_color_blend_op";
        /// <summary>
        /// Cached name for the 'set_src_alpha_blend_factor' method.
        /// </summary>
        public static readonly StringName SetSrcAlphaBlendFactor = "set_src_alpha_blend_factor";
        /// <summary>
        /// Cached name for the 'get_src_alpha_blend_factor' method.
        /// </summary>
        public static readonly StringName GetSrcAlphaBlendFactor = "get_src_alpha_blend_factor";
        /// <summary>
        /// Cached name for the 'set_dst_alpha_blend_factor' method.
        /// </summary>
        public static readonly StringName SetDstAlphaBlendFactor = "set_dst_alpha_blend_factor";
        /// <summary>
        /// Cached name for the 'get_dst_alpha_blend_factor' method.
        /// </summary>
        public static readonly StringName GetDstAlphaBlendFactor = "get_dst_alpha_blend_factor";
        /// <summary>
        /// Cached name for the 'set_alpha_blend_op' method.
        /// </summary>
        public static readonly StringName SetAlphaBlendOp = "set_alpha_blend_op";
        /// <summary>
        /// Cached name for the 'get_alpha_blend_op' method.
        /// </summary>
        public static readonly StringName GetAlphaBlendOp = "get_alpha_blend_op";
        /// <summary>
        /// Cached name for the 'set_write_r' method.
        /// </summary>
        public static readonly StringName SetWriteR = "set_write_r";
        /// <summary>
        /// Cached name for the 'get_write_r' method.
        /// </summary>
        public static readonly StringName GetWriteR = "get_write_r";
        /// <summary>
        /// Cached name for the 'set_write_g' method.
        /// </summary>
        public static readonly StringName SetWriteG = "set_write_g";
        /// <summary>
        /// Cached name for the 'get_write_g' method.
        /// </summary>
        public static readonly StringName GetWriteG = "get_write_g";
        /// <summary>
        /// Cached name for the 'set_write_b' method.
        /// </summary>
        public static readonly StringName SetWriteB = "set_write_b";
        /// <summary>
        /// Cached name for the 'get_write_b' method.
        /// </summary>
        public static readonly StringName GetWriteB = "get_write_b";
        /// <summary>
        /// Cached name for the 'set_write_a' method.
        /// </summary>
        public static readonly StringName SetWriteA = "set_write_a";
        /// <summary>
        /// Cached name for the 'get_write_a' method.
        /// </summary>
        public static readonly StringName GetWriteA = "get_write_a";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
