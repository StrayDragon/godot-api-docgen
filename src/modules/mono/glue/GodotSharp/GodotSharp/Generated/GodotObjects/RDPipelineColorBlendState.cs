namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object is used by <see cref="Godot.RenderingDevice"/>.</para>
/// </summary>
public partial class RDPipelineColorBlendState : RefCounted
{
    /// <summary>
    /// <para>If <see langword="true"/>, performs the logic operation defined in <see cref="Godot.RDPipelineColorBlendState.LogicOp"/>.</para>
    /// </summary>
    public bool EnableLogicOp
    {
        get
        {
            return GetEnableLogicOp();
        }
        set
        {
            SetEnableLogicOp(value);
        }
    }

    /// <summary>
    /// <para>The logic operation to perform for blending. Only effective if <see cref="Godot.RDPipelineColorBlendState.EnableLogicOp"/> is <see langword="true"/>.</para>
    /// </summary>
    public RenderingDevice.LogicOperation LogicOp
    {
        get
        {
            return GetLogicOp();
        }
        set
        {
            SetLogicOp(value);
        }
    }

    /// <summary>
    /// <para>The constant color to blend with. See also <see cref="Godot.RenderingDevice.DrawListSetBlendConstants(long, Color)"/>.</para>
    /// </summary>
    public Color BlendConstant
    {
        get
        {
            return GetBlendConstant();
        }
        set
        {
            SetBlendConstant(value);
        }
    }

    /// <summary>
    /// <para>The attachments that are blended together.</para>
    /// </summary>
    public Godot.Collections.Array<RDPipelineColorBlendStateAttachment> Attachments
    {
        get
        {
            return GetAttachments();
        }
        set
        {
            SetAttachments(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDPipelineColorBlendState);

    private static readonly StringName NativeName = "RDPipelineColorBlendState";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDPipelineColorBlendState() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineColorBlendState(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineColorBlendState(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableLogicOp, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableLogicOp(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableLogicOp, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableLogicOp()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLogicOp, 3610841058ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLogicOp(RenderingDevice.LogicOperation pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLogicOp, 988254690ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.LogicOperation GetLogicOp()
    {
        return (RenderingDevice.LogicOperation)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendConstant, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBlendConstant(Color pMember)
    {
        NativeCalls.godot_icall_1_213(MethodBind4, GodotObject.GetPtr(this), &pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendConstant, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetBlendConstant()
    {
        return NativeCalls.godot_icall_0_214(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAttachments, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAttachments(Godot.Collections.Array<RDPipelineColorBlendStateAttachment> attachments)
    {
        NativeCalls.godot_icall_1_138(MethodBind6, GodotObject.GetPtr(this), (godot_array)(attachments ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttachments, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<RDPipelineColorBlendStateAttachment> GetAttachments()
    {
        return new Godot.Collections.Array<RDPipelineColorBlendStateAttachment>(NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this)));
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
        /// Cached name for the 'enable_logic_op' property.
        /// </summary>
        public static readonly StringName EnableLogicOp = "enable_logic_op";
        /// <summary>
        /// Cached name for the 'logic_op' property.
        /// </summary>
        public static readonly StringName LogicOp = "logic_op";
        /// <summary>
        /// Cached name for the 'blend_constant' property.
        /// </summary>
        public static readonly StringName BlendConstant = "blend_constant";
        /// <summary>
        /// Cached name for the 'attachments' property.
        /// </summary>
        public static readonly StringName Attachments = "attachments";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_enable_logic_op' method.
        /// </summary>
        public static readonly StringName SetEnableLogicOp = "set_enable_logic_op";
        /// <summary>
        /// Cached name for the 'get_enable_logic_op' method.
        /// </summary>
        public static readonly StringName GetEnableLogicOp = "get_enable_logic_op";
        /// <summary>
        /// Cached name for the 'set_logic_op' method.
        /// </summary>
        public static readonly StringName SetLogicOp = "set_logic_op";
        /// <summary>
        /// Cached name for the 'get_logic_op' method.
        /// </summary>
        public static readonly StringName GetLogicOp = "get_logic_op";
        /// <summary>
        /// Cached name for the 'set_blend_constant' method.
        /// </summary>
        public static readonly StringName SetBlendConstant = "set_blend_constant";
        /// <summary>
        /// Cached name for the 'get_blend_constant' method.
        /// </summary>
        public static readonly StringName GetBlendConstant = "get_blend_constant";
        /// <summary>
        /// Cached name for the 'set_attachments' method.
        /// </summary>
        public static readonly StringName SetAttachments = "set_attachments";
        /// <summary>
        /// Cached name for the 'get_attachments' method.
        /// </summary>
        public static readonly StringName GetAttachments = "get_attachments";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
