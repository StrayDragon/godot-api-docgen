namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A shader include file, saved with the <c>.gdshaderinc</c> extension. This class allows you to define a custom shader snippet that can be included in a <see cref="Godot.Shader"/> by using the preprocessor directive <c>#include</c>, followed by the file path (e.g. <c>#include "res://shader_lib.gdshaderinc"</c>). The snippet doesn't have to be a valid shader on its own.</para>
/// </summary>
public partial class ShaderInclude : Resource
{
    /// <summary>
    /// <para>Returns the code of the shader include file. The returned text is what the user has written, not the full generated code used internally.</para>
    /// </summary>
    public string Code
    {
        get
        {
            return GetCode();
        }
        set
        {
            SetCode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ShaderInclude);

    private static readonly StringName NativeName = "ShaderInclude";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ShaderInclude() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ShaderInclude(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ShaderInclude(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCode, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCode(string code)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), code);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCode, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetCode()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
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
        /// Cached name for the 'code' property.
        /// </summary>
        public static readonly StringName Code = "code";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_code' method.
        /// </summary>
        public static readonly StringName SetCode = "set_code";
        /// <summary>
        /// Cached name for the 'get_code' method.
        /// </summary>
        public static readonly StringName GetCode = "get_code";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
