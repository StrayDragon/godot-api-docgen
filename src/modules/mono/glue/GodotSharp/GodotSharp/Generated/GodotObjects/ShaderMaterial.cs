namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A material that uses a custom <see cref="Godot.Shader"/> program to render visual items (canvas items, meshes, skies, fog), or to process particles. Compared to other materials, <see cref="Godot.ShaderMaterial"/> gives deeper control over the generated shader code. For more information, see the shaders documentation index below.</para>
/// <para>Multiple <see cref="Godot.ShaderMaterial"/>s can use the same shader and configure different values for the shader uniforms.</para>
/// <para><b>Note:</b> For performance reasons, the <see cref="Godot.Resource.Changed"/> signal is only emitted when the <see cref="Godot.Resource.ResourceName"/> changes. Only in editor, it is also emitted for <see cref="Godot.ShaderMaterial.Shader"/> changes.</para>
/// </summary>
public partial class ShaderMaterial : Material
{
    /// <summary>
    /// <para>The <see cref="Godot.Shader"/> program used to render this material.</para>
    /// </summary>
    public Shader Shader
    {
        get
        {
            return GetShader();
        }
        set
        {
            SetShader(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ShaderMaterial);

    private static readonly StringName NativeName = "ShaderMaterial";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ShaderMaterial() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ShaderMaterial(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ShaderMaterial(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShader, 3341921675ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShader(Shader shader)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(shader));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShader, 2078273437ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Shader GetShader()
    {
        return (Shader)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShaderParameter, 3776071444ul);

    /// <summary>
    /// <para>Changes the value set for this material of a uniform in the shader.</para>
    /// <para><b>Note:</b> <paramref name="param"/> is case-sensitive and must match the name of the uniform in the code exactly (not the capitalized name in the inspector).</para>
    /// <para><b>Note:</b> Changes to the shader uniform will be effective on all instances using this <see cref="Godot.ShaderMaterial"/>. To prevent this, use per-instance uniforms with <see cref="Godot.CanvasItem.SetInstanceShaderParameter(StringName, Variant)"/>, <see cref="Godot.GeometryInstance3D.SetInstanceShaderParameter(StringName, Variant)"/> or duplicate the <see cref="Godot.ShaderMaterial"/> resource using <see cref="Godot.Resource.Duplicate(bool)"/>. Per-instance uniforms allow for better shader reuse and are therefore faster, so they should be preferred over duplicating the <see cref="Godot.ShaderMaterial"/> when possible.</para>
    /// </summary>
    public void SetShaderParameter(StringName param, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(param?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShaderParameter, 2760726917ul);

    /// <summary>
    /// <para>Returns the current value set for this material of a uniform in the shader.</para>
    /// </summary>
    public Variant GetShaderParameter(StringName param)
    {
        return NativeCalls.godot_icall_1_143(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(param?.NativeValue ?? default));
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
    public new class PropertyName : Material.PropertyName
    {
        /// <summary>
        /// Cached name for the 'shader' property.
        /// </summary>
        public static readonly StringName Shader = "shader";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Material.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_shader' method.
        /// </summary>
        public static readonly StringName SetShader = "set_shader";
        /// <summary>
        /// Cached name for the 'get_shader' method.
        /// </summary>
        public static readonly StringName GetShader = "get_shader";
        /// <summary>
        /// Cached name for the 'set_shader_parameter' method.
        /// </summary>
        public static readonly StringName SetShaderParameter = "set_shader_parameter";
        /// <summary>
        /// Cached name for the 'get_shader_parameter' method.
        /// </summary>
        public static readonly StringName GetShaderParameter = "get_shader_parameter";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Material.SignalName
    {
    }
}
