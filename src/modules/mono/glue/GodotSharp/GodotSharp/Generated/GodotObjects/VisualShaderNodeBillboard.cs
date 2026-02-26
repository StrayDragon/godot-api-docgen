namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The output port of this node needs to be connected to <c>Model View Matrix</c> port of <see cref="Godot.VisualShaderNodeOutput"/>.</para>
/// </summary>
public partial class VisualShaderNodeBillboard : VisualShaderNode
{
    public enum BillboardTypeEnum : long
    {
        /// <summary>
        /// <para>Billboarding is disabled and the node does nothing.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>A standard billboarding algorithm is enabled.</para>
        /// </summary>
        Enabled = 1,
        /// <summary>
        /// <para>A billboarding algorithm to rotate around Y-axis is enabled.</para>
        /// </summary>
        FixedY = 2,
        /// <summary>
        /// <para>A billboarding algorithm designed to use on particles is enabled.</para>
        /// </summary>
        Particles = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeBillboard.BillboardTypeEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    /// <summary>
    /// <para>Controls how the object faces the camera.</para>
    /// </summary>
    public VisualShaderNodeBillboard.BillboardTypeEnum BillboardType
    {
        get
        {
            return GetBillboardType();
        }
        set
        {
            SetBillboardType(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the shader will keep the scale set for the mesh. Otherwise, the scale is lost when billboarding.</para>
    /// </summary>
    public bool KeepScale
    {
        get
        {
            return IsKeepScaleEnabled();
        }
        set
        {
            SetKeepScaleEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeBillboard);

    private static readonly StringName NativeName = "VisualShaderNodeBillboard";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeBillboard() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeBillboard(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeBillboard(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBillboardType, 1227463289ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBillboardType(VisualShaderNodeBillboard.BillboardTypeEnum billboardType)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)billboardType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBillboardType, 3724188517ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeBillboard.BillboardTypeEnum GetBillboardType()
    {
        return (VisualShaderNodeBillboard.BillboardTypeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKeepScaleEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetKeepScaleEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsKeepScaleEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsKeepScaleEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : VisualShaderNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'billboard_type' property.
        /// </summary>
        public static readonly StringName BillboardType = "billboard_type";
        /// <summary>
        /// Cached name for the 'keep_scale' property.
        /// </summary>
        public static readonly StringName KeepScale = "keep_scale";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_billboard_type' method.
        /// </summary>
        public static readonly StringName SetBillboardType = "set_billboard_type";
        /// <summary>
        /// Cached name for the 'get_billboard_type' method.
        /// </summary>
        public static readonly StringName GetBillboardType = "get_billboard_type";
        /// <summary>
        /// Cached name for the 'set_keep_scale_enabled' method.
        /// </summary>
        public static readonly StringName SetKeepScaleEnabled = "set_keep_scale_enabled";
        /// <summary>
        /// Cached name for the 'is_keep_scale_enabled' method.
        /// </summary>
        public static readonly StringName IsKeepScaleEnabled = "is_keep_scale_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}
