namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.RDPipelineMultisampleState"/> is used to control how multisample or supersample antialiasing is being performed when rendering using <see cref="Godot.RenderingDevice"/>.</para>
/// </summary>
public partial class RDPipelineMultisampleState : RefCounted
{
    /// <summary>
    /// <para>The number of MSAA samples (or SSAA samples if <see cref="Godot.RDPipelineMultisampleState.EnableSampleShading"/> is <see langword="true"/>) to perform. Higher values result in better antialiasing, at the cost of performance.</para>
    /// </summary>
    public RenderingDevice.TextureSamples SampleCount
    {
        get
        {
            return GetSampleCount();
        }
        set
        {
            SetSampleCount(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables per-sample shading which replaces MSAA by SSAA. This provides higher quality antialiasing that works with transparent (alpha scissor) edges. This has a very high performance cost. See also <see cref="Godot.RDPipelineMultisampleState.MinSampleShading"/>. See the <a href="https://registry.khronos.org/vulkan/specs/1.3-extensions/html/vkspec.html#primsrast-sampleshading">per-sample shading Vulkan documentation</a> for more details.</para>
    /// </summary>
    public bool EnableSampleShading
    {
        get
        {
            return GetEnableSampleShading();
        }
        set
        {
            SetEnableSampleShading(value);
        }
    }

    /// <summary>
    /// <para>The multiplier of <see cref="Godot.RDPipelineMultisampleState.SampleCount"/> that determines how many samples are performed for each fragment. Must be between <c>0.0</c> and <c>1.0</c> (inclusive). Only effective if <see cref="Godot.RDPipelineMultisampleState.EnableSampleShading"/> is <see langword="true"/>. If <see cref="Godot.RDPipelineMultisampleState.MinSampleShading"/> is <c>1.0</c>, fragment invocation must only read from the coverage index sample. Tile image access must not be used if <see cref="Godot.RDPipelineMultisampleState.EnableSampleShading"/> is <i>not</i> <c>1.0</c>.</para>
    /// </summary>
    public float MinSampleShading
    {
        get
        {
            return GetMinSampleShading();
        }
        set
        {
            SetMinSampleShading(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, alpha to coverage is enabled. This generates a temporary coverage value based on the alpha component of the fragment's first color output. This allows alpha transparency to make use of multisample antialiasing.</para>
    /// </summary>
    public bool EnableAlphaToCoverage
    {
        get
        {
            return GetEnableAlphaToCoverage();
        }
        set
        {
            SetEnableAlphaToCoverage(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, alpha is forced to either <c>0.0</c> or <c>1.0</c>. This allows hardening the edges of antialiased alpha transparencies. Only relevant if <see cref="Godot.RDPipelineMultisampleState.EnableAlphaToCoverage"/> is <see langword="true"/>.</para>
    /// </summary>
    public bool EnableAlphaToOne
    {
        get
        {
            return GetEnableAlphaToOne();
        }
        set
        {
            SetEnableAlphaToOne(value);
        }
    }

    /// <summary>
    /// <para>The sample mask array. See the <a href="https://registry.khronos.org/vulkan/specs/1.3-extensions/html/vkspec.html#fragops-samplemask">sample mask Vulkan documentation</a> for more details.</para>
    /// </summary>
    public Godot.Collections.Array<int> SampleMasks
    {
        get
        {
            return GetSampleMasks();
        }
        set
        {
            SetSampleMasks(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDPipelineMultisampleState);

    private static readonly StringName NativeName = "RDPipelineMultisampleState";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDPipelineMultisampleState() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineMultisampleState(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineMultisampleState(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSampleCount, 3774171498ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSampleCount(RenderingDevice.TextureSamples pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSampleCount, 407791724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.TextureSamples GetSampleCount()
    {
        return (RenderingDevice.TextureSamples)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableSampleShading, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableSampleShading(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableSampleShading, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableSampleShading()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinSampleShading, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinSampleShading(float pMember)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinSampleShading, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMinSampleShading()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableAlphaToCoverage, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableAlphaToCoverage(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableAlphaToCoverage, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableAlphaToCoverage()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableAlphaToOne, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableAlphaToOne(bool pMember)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), pMember.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableAlphaToOne, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEnableAlphaToOne()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSampleMasks, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSampleMasks(Godot.Collections.Array<int> masks)
    {
        NativeCalls.godot_icall_1_138(MethodBind10, GodotObject.GetPtr(this), (godot_array)(masks ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSampleMasks, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<int> GetSampleMasks()
    {
        return new Godot.Collections.Array<int>(NativeCalls.godot_icall_0_120(MethodBind11, GodotObject.GetPtr(this)));
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
        /// Cached name for the 'sample_count' property.
        /// </summary>
        public static readonly StringName SampleCount = "sample_count";
        /// <summary>
        /// Cached name for the 'enable_sample_shading' property.
        /// </summary>
        public static readonly StringName EnableSampleShading = "enable_sample_shading";
        /// <summary>
        /// Cached name for the 'min_sample_shading' property.
        /// </summary>
        public static readonly StringName MinSampleShading = "min_sample_shading";
        /// <summary>
        /// Cached name for the 'enable_alpha_to_coverage' property.
        /// </summary>
        public static readonly StringName EnableAlphaToCoverage = "enable_alpha_to_coverage";
        /// <summary>
        /// Cached name for the 'enable_alpha_to_one' property.
        /// </summary>
        public static readonly StringName EnableAlphaToOne = "enable_alpha_to_one";
        /// <summary>
        /// Cached name for the 'sample_masks' property.
        /// </summary>
        public static readonly StringName SampleMasks = "sample_masks";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_sample_count' method.
        /// </summary>
        public static readonly StringName SetSampleCount = "set_sample_count";
        /// <summary>
        /// Cached name for the 'get_sample_count' method.
        /// </summary>
        public static readonly StringName GetSampleCount = "get_sample_count";
        /// <summary>
        /// Cached name for the 'set_enable_sample_shading' method.
        /// </summary>
        public static readonly StringName SetEnableSampleShading = "set_enable_sample_shading";
        /// <summary>
        /// Cached name for the 'get_enable_sample_shading' method.
        /// </summary>
        public static readonly StringName GetEnableSampleShading = "get_enable_sample_shading";
        /// <summary>
        /// Cached name for the 'set_min_sample_shading' method.
        /// </summary>
        public static readonly StringName SetMinSampleShading = "set_min_sample_shading";
        /// <summary>
        /// Cached name for the 'get_min_sample_shading' method.
        /// </summary>
        public static readonly StringName GetMinSampleShading = "get_min_sample_shading";
        /// <summary>
        /// Cached name for the 'set_enable_alpha_to_coverage' method.
        /// </summary>
        public static readonly StringName SetEnableAlphaToCoverage = "set_enable_alpha_to_coverage";
        /// <summary>
        /// Cached name for the 'get_enable_alpha_to_coverage' method.
        /// </summary>
        public static readonly StringName GetEnableAlphaToCoverage = "get_enable_alpha_to_coverage";
        /// <summary>
        /// Cached name for the 'set_enable_alpha_to_one' method.
        /// </summary>
        public static readonly StringName SetEnableAlphaToOne = "set_enable_alpha_to_one";
        /// <summary>
        /// Cached name for the 'get_enable_alpha_to_one' method.
        /// </summary>
        public static readonly StringName GetEnableAlphaToOne = "get_enable_alpha_to_one";
        /// <summary>
        /// Cached name for the 'set_sample_masks' method.
        /// </summary>
        public static readonly StringName SetSampleMasks = "set_sample_masks";
        /// <summary>
        /// Cached name for the 'get_sample_masks' method.
        /// </summary>
        public static readonly StringName GetSampleMasks = "get_sample_masks";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
