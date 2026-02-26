namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.RDShaderSpirV"/> represents an <see cref="Godot.RDShaderFile"/>'s <a href="https://www.khronos.org/spir/">SPIR-V</a> code for various shader stages, as well as possible compilation error messages. SPIR-V is a low-level intermediate shader representation. This intermediate representation is not used directly by GPUs for rendering, but it can be compiled into binary shaders that GPUs can understand. Unlike compiled shaders, SPIR-V is portable across GPU models and driver versions.</para>
/// <para>This object is used by <see cref="Godot.RenderingDevice"/>.</para>
/// </summary>
[GodotClassName("RDShaderSPIRV")]
public partial class RDShaderSpirV : Resource
{
    /// <summary>
    /// <para>The SPIR-V bytecode for the vertex shader stage.</para>
    /// </summary>
    public byte[] BytecodeVertex
    {
        get
        {
            return GetStageBytecode((RenderingDevice.ShaderStage)(0));
        }
        set
        {
            SetStageBytecode((RenderingDevice.ShaderStage)(0), value);
        }
    }

    /// <summary>
    /// <para>The SPIR-V bytecode for the fragment shader stage.</para>
    /// </summary>
    public byte[] BytecodeFragment
    {
        get
        {
            return GetStageBytecode((RenderingDevice.ShaderStage)(1));
        }
        set
        {
            SetStageBytecode((RenderingDevice.ShaderStage)(1), value);
        }
    }

    /// <summary>
    /// <para>The SPIR-V bytecode for the tessellation control shader stage.</para>
    /// </summary>
    public byte[] BytecodeTesselationControl
    {
        get
        {
            return GetStageBytecode((RenderingDevice.ShaderStage)(2));
        }
        set
        {
            SetStageBytecode((RenderingDevice.ShaderStage)(2), value);
        }
    }

    /// <summary>
    /// <para>The SPIR-V bytecode for the tessellation evaluation shader stage.</para>
    /// </summary>
    public byte[] BytecodeTesselationEvaluation
    {
        get
        {
            return GetStageBytecode((RenderingDevice.ShaderStage)(3));
        }
        set
        {
            SetStageBytecode((RenderingDevice.ShaderStage)(3), value);
        }
    }

    /// <summary>
    /// <para>The SPIR-V bytecode for the compute shader stage.</para>
    /// </summary>
    public byte[] BytecodeCompute
    {
        get
        {
            return GetStageBytecode((RenderingDevice.ShaderStage)(4));
        }
        set
        {
            SetStageBytecode((RenderingDevice.ShaderStage)(4), value);
        }
    }

    /// <summary>
    /// <para>The compilation error message for the vertex shader stage (set by the SPIR-V compiler and Godot). If empty, shader compilation was successful.</para>
    /// </summary>
    public string CompileErrorVertex
    {
        get
        {
            return GetStageCompileError((RenderingDevice.ShaderStage)(0));
        }
        set
        {
            SetStageCompileError((RenderingDevice.ShaderStage)(0), value);
        }
    }

    /// <summary>
    /// <para>The compilation error message for the fragment shader stage (set by the SPIR-V compiler and Godot). If empty, shader compilation was successful.</para>
    /// </summary>
    public string CompileErrorFragment
    {
        get
        {
            return GetStageCompileError((RenderingDevice.ShaderStage)(1));
        }
        set
        {
            SetStageCompileError((RenderingDevice.ShaderStage)(1), value);
        }
    }

    /// <summary>
    /// <para>The compilation error message for the tessellation control shader stage (set by the SPIR-V compiler and Godot). If empty, shader compilation was successful.</para>
    /// </summary>
    public string CompileErrorTesselationControl
    {
        get
        {
            return GetStageCompileError((RenderingDevice.ShaderStage)(2));
        }
        set
        {
            SetStageCompileError((RenderingDevice.ShaderStage)(2), value);
        }
    }

    /// <summary>
    /// <para>The compilation error message for the tessellation evaluation shader stage (set by the SPIR-V compiler and Godot). If empty, shader compilation was successful.</para>
    /// </summary>
    public string CompileErrorTesselationEvaluation
    {
        get
        {
            return GetStageCompileError((RenderingDevice.ShaderStage)(3));
        }
        set
        {
            SetStageCompileError((RenderingDevice.ShaderStage)(3), value);
        }
    }

    /// <summary>
    /// <para>The compilation error message for the compute shader stage (set by the SPIR-V compiler and Godot). If empty, shader compilation was successful.</para>
    /// </summary>
    public string CompileErrorCompute
    {
        get
        {
            return GetStageCompileError((RenderingDevice.ShaderStage)(4));
        }
        set
        {
            SetStageCompileError((RenderingDevice.ShaderStage)(4), value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDShaderSpirV);

    private static readonly StringName NativeName = "RDShaderSPIRV";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDShaderSpirV() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDShaderSpirV(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDShaderSpirV(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStageBytecode, 3514097977ul);

    /// <summary>
    /// <para>Sets the SPIR-V <paramref name="bytecode"/> for the given shader <paramref name="stage"/>. Equivalent to setting one of <see cref="Godot.RDShaderSpirV.BytecodeCompute"/>, <see cref="Godot.RDShaderSpirV.BytecodeFragment"/>, <see cref="Godot.RDShaderSpirV.BytecodeTesselationControl"/>, <see cref="Godot.RDShaderSpirV.BytecodeTesselationEvaluation"/>, <see cref="Godot.RDShaderSpirV.BytecodeVertex"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStageBytecode(RenderingDevice.ShaderStage stage, byte[] bytecode)
    {
        NativeCalls.godot_icall_2_1031(MethodBind0, GodotObject.GetPtr(this), (int)stage, bytecode);
    }

    /// <summary>
    /// <para>Sets the SPIR-V <paramref name="bytecode"/> for the given shader <paramref name="stage"/>. Equivalent to setting one of <see cref="Godot.RDShaderSpirV.BytecodeCompute"/>, <see cref="Godot.RDShaderSpirV.BytecodeFragment"/>, <see cref="Godot.RDShaderSpirV.BytecodeTesselationControl"/>, <see cref="Godot.RDShaderSpirV.BytecodeTesselationEvaluation"/>, <see cref="Godot.RDShaderSpirV.BytecodeVertex"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStageBytecode(RenderingDevice.ShaderStage stage, ReadOnlySpan<byte> bytecode)
    {
        NativeCalls.godot_icall_2_1031(MethodBind0, GodotObject.GetPtr(this), (int)stage, bytecode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStageBytecode, 3816765404ul);

    /// <summary>
    /// <para>Equivalent to getting one of <see cref="Godot.RDShaderSpirV.BytecodeCompute"/>, <see cref="Godot.RDShaderSpirV.BytecodeFragment"/>, <see cref="Godot.RDShaderSpirV.BytecodeTesselationControl"/>, <see cref="Godot.RDShaderSpirV.BytecodeTesselationEvaluation"/>, <see cref="Godot.RDShaderSpirV.BytecodeVertex"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public byte[] GetStageBytecode(RenderingDevice.ShaderStage stage)
    {
        return NativeCalls.godot_icall_1_343(MethodBind1, GodotObject.GetPtr(this), (int)stage);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStageCompileError, 620821314ul);

    /// <summary>
    /// <para>Sets the compilation error message for the given shader <paramref name="stage"/> to <paramref name="compileError"/>. Equivalent to setting one of <see cref="Godot.RDShaderSpirV.CompileErrorCompute"/>, <see cref="Godot.RDShaderSpirV.CompileErrorFragment"/>, <see cref="Godot.RDShaderSpirV.CompileErrorTesselationControl"/>, <see cref="Godot.RDShaderSpirV.CompileErrorTesselationEvaluation"/>, <see cref="Godot.RDShaderSpirV.CompileErrorVertex"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStageCompileError(RenderingDevice.ShaderStage stage, string compileError)
    {
        NativeCalls.godot_icall_2_181(MethodBind2, GodotObject.GetPtr(this), (int)stage, compileError);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStageCompileError, 3354920045ul);

    /// <summary>
    /// <para>Returns the compilation error message for the given shader <paramref name="stage"/>. Equivalent to getting one of <see cref="Godot.RDShaderSpirV.CompileErrorCompute"/>, <see cref="Godot.RDShaderSpirV.CompileErrorFragment"/>, <see cref="Godot.RDShaderSpirV.CompileErrorTesselationControl"/>, <see cref="Godot.RDShaderSpirV.CompileErrorTesselationEvaluation"/>, <see cref="Godot.RDShaderSpirV.CompileErrorVertex"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetStageCompileError(RenderingDevice.ShaderStage stage)
    {
        return NativeCalls.godot_icall_1_133(MethodBind3, GodotObject.GetPtr(this), (int)stage);
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
        /// Cached name for the 'bytecode_vertex' property.
        /// </summary>
        public static readonly StringName BytecodeVertex = "bytecode_vertex";
        /// <summary>
        /// Cached name for the 'bytecode_fragment' property.
        /// </summary>
        public static readonly StringName BytecodeFragment = "bytecode_fragment";
        /// <summary>
        /// Cached name for the 'bytecode_tesselation_control' property.
        /// </summary>
        public static readonly StringName BytecodeTesselationControl = "bytecode_tesselation_control";
        /// <summary>
        /// Cached name for the 'bytecode_tesselation_evaluation' property.
        /// </summary>
        public static readonly StringName BytecodeTesselationEvaluation = "bytecode_tesselation_evaluation";
        /// <summary>
        /// Cached name for the 'bytecode_compute' property.
        /// </summary>
        public static readonly StringName BytecodeCompute = "bytecode_compute";
        /// <summary>
        /// Cached name for the 'compile_error_vertex' property.
        /// </summary>
        public static readonly StringName CompileErrorVertex = "compile_error_vertex";
        /// <summary>
        /// Cached name for the 'compile_error_fragment' property.
        /// </summary>
        public static readonly StringName CompileErrorFragment = "compile_error_fragment";
        /// <summary>
        /// Cached name for the 'compile_error_tesselation_control' property.
        /// </summary>
        public static readonly StringName CompileErrorTesselationControl = "compile_error_tesselation_control";
        /// <summary>
        /// Cached name for the 'compile_error_tesselation_evaluation' property.
        /// </summary>
        public static readonly StringName CompileErrorTesselationEvaluation = "compile_error_tesselation_evaluation";
        /// <summary>
        /// Cached name for the 'compile_error_compute' property.
        /// </summary>
        public static readonly StringName CompileErrorCompute = "compile_error_compute";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_stage_bytecode' method.
        /// </summary>
        public static readonly StringName SetStageBytecode = "set_stage_bytecode";
        /// <summary>
        /// Cached name for the 'get_stage_bytecode' method.
        /// </summary>
        public static readonly StringName GetStageBytecode = "get_stage_bytecode";
        /// <summary>
        /// Cached name for the 'set_stage_compile_error' method.
        /// </summary>
        public static readonly StringName SetStageCompileError = "set_stage_compile_error";
        /// <summary>
        /// Cached name for the 'get_stage_compile_error' method.
        /// </summary>
        public static readonly StringName GetStageCompileError = "get_stage_compile_error";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
