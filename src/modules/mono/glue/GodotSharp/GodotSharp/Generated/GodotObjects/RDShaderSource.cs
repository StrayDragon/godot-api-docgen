namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Shader source code in text form.</para>
/// <para>See also <see cref="Godot.RDShaderFile"/>. <see cref="Godot.RDShaderSource"/> is only meant to be used with the <see cref="Godot.RenderingDevice"/> API. It should not be confused with Godot's own <see cref="Godot.Shader"/> resource, which is what Godot's various nodes use for high-level shader programming.</para>
/// </summary>
public partial class RDShaderSource : RefCounted
{
    /// <summary>
    /// <para>Source code for the shader's vertex stage.</para>
    /// </summary>
    public string SourceVertex
    {
        get
        {
            return GetStageSource((RenderingDevice.ShaderStage)(0));
        }
        set
        {
            SetStageSource((RenderingDevice.ShaderStage)(0), value);
        }
    }

    /// <summary>
    /// <para>Source code for the shader's fragment stage.</para>
    /// </summary>
    public string SourceFragment
    {
        get
        {
            return GetStageSource((RenderingDevice.ShaderStage)(1));
        }
        set
        {
            SetStageSource((RenderingDevice.ShaderStage)(1), value);
        }
    }

    /// <summary>
    /// <para>Source code for the shader's tessellation control stage.</para>
    /// </summary>
    public string SourceTesselationControl
    {
        get
        {
            return GetStageSource((RenderingDevice.ShaderStage)(2));
        }
        set
        {
            SetStageSource((RenderingDevice.ShaderStage)(2), value);
        }
    }

    /// <summary>
    /// <para>Source code for the shader's tessellation evaluation stage.</para>
    /// </summary>
    public string SourceTesselationEvaluation
    {
        get
        {
            return GetStageSource((RenderingDevice.ShaderStage)(3));
        }
        set
        {
            SetStageSource((RenderingDevice.ShaderStage)(3), value);
        }
    }

    /// <summary>
    /// <para>Source code for the shader's compute stage.</para>
    /// </summary>
    public string SourceCompute
    {
        get
        {
            return GetStageSource((RenderingDevice.ShaderStage)(4));
        }
        set
        {
            SetStageSource((RenderingDevice.ShaderStage)(4), value);
        }
    }

    /// <summary>
    /// <para>The language the shader is written in.</para>
    /// </summary>
    public RenderingDevice.ShaderLanguage Language
    {
        get
        {
            return GetLanguage();
        }
        set
        {
            SetLanguage(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDShaderSource);

    private static readonly StringName NativeName = "RDShaderSource";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDShaderSource() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDShaderSource(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDShaderSource(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStageSource, 620821314ul);

    /// <summary>
    /// <para>Sets <paramref name="source"/> code for the specified shader <paramref name="stage"/>. Equivalent to setting one of <see cref="Godot.RDShaderSource.SourceCompute"/>, <see cref="Godot.RDShaderSource.SourceFragment"/>, <see cref="Godot.RDShaderSource.SourceTesselationControl"/>, <see cref="Godot.RDShaderSource.SourceTesselationEvaluation"/> or <see cref="Godot.RDShaderSource.SourceVertex"/>.</para>
    /// <para><b>Note:</b> If you set the compute shader source code using this method directly, remember to remove the Godot-specific hint <c>#[compute]</c>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStageSource(RenderingDevice.ShaderStage stage, string source)
    {
        NativeCalls.godot_icall_2_181(MethodBind0, GodotObject.GetPtr(this), (int)stage, source);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStageSource, 3354920045ul);

    /// <summary>
    /// <para>Returns source code for the specified shader <paramref name="stage"/>. Equivalent to getting one of <see cref="Godot.RDShaderSource.SourceCompute"/>, <see cref="Godot.RDShaderSource.SourceFragment"/>, <see cref="Godot.RDShaderSource.SourceTesselationControl"/>, <see cref="Godot.RDShaderSource.SourceTesselationEvaluation"/> or <see cref="Godot.RDShaderSource.SourceVertex"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetStageSource(RenderingDevice.ShaderStage stage)
    {
        return NativeCalls.godot_icall_1_133(MethodBind1, GodotObject.GetPtr(this), (int)stage);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguage, 3422186742ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLanguage(RenderingDevice.ShaderLanguage language)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguage, 1063538261ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.ShaderLanguage GetLanguage()
    {
        return (RenderingDevice.ShaderLanguage)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'source_vertex' property.
        /// </summary>
        public static readonly StringName SourceVertex = "source_vertex";
        /// <summary>
        /// Cached name for the 'source_fragment' property.
        /// </summary>
        public static readonly StringName SourceFragment = "source_fragment";
        /// <summary>
        /// Cached name for the 'source_tesselation_control' property.
        /// </summary>
        public static readonly StringName SourceTesselationControl = "source_tesselation_control";
        /// <summary>
        /// Cached name for the 'source_tesselation_evaluation' property.
        /// </summary>
        public static readonly StringName SourceTesselationEvaluation = "source_tesselation_evaluation";
        /// <summary>
        /// Cached name for the 'source_compute' property.
        /// </summary>
        public static readonly StringName SourceCompute = "source_compute";
        /// <summary>
        /// Cached name for the 'language' property.
        /// </summary>
        public static readonly StringName Language = "language";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_stage_source' method.
        /// </summary>
        public static readonly StringName SetStageSource = "set_stage_source";
        /// <summary>
        /// Cached name for the 'get_stage_source' method.
        /// </summary>
        public static readonly StringName GetStageSource = "get_stage_source";
        /// <summary>
        /// Cached name for the 'set_language' method.
        /// </summary>
        public static readonly StringName SetLanguage = "set_language";
        /// <summary>
        /// Cached name for the 'get_language' method.
        /// </summary>
        public static readonly StringName GetLanguage = "get_language";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
