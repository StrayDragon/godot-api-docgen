namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Varying values are shader variables that can be passed between shader functions, e.g. from Vertex shader to Fragment shader.</para>
/// </summary>
public partial class VisualShaderNodeVarying : VisualShaderNode
{
    /// <summary>
    /// <para>Name of the variable. Must be unique.</para>
    /// </summary>
    public string VaryingName
    {
        get
        {
            return GetVaryingName();
        }
        set
        {
            SetVaryingName(value);
        }
    }

    /// <summary>
    /// <para>Type of the variable. Determines where the variable can be accessed.</para>
    /// </summary>
    public VisualShader.VaryingType VaryingType
    {
        get
        {
            return GetVaryingType();
        }
        set
        {
            SetVaryingType(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeVarying);

    private static readonly StringName NativeName = "VisualShaderNodeVarying";

    internal VisualShaderNodeVarying() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeVarying(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeVarying(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVaryingName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVaryingName(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVaryingName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetVaryingName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVaryingType, 3565867981ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVaryingType(VisualShader.VaryingType type)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVaryingType, 523183580ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShader.VaryingType GetVaryingType()
    {
        return (VisualShader.VaryingType)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'varying_name' property.
        /// </summary>
        public static readonly StringName VaryingName = "varying_name";
        /// <summary>
        /// Cached name for the 'varying_type' property.
        /// </summary>
        public static readonly StringName VaryingType = "varying_type";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_varying_name' method.
        /// </summary>
        public static readonly StringName SetVaryingName = "set_varying_name";
        /// <summary>
        /// Cached name for the 'get_varying_name' method.
        /// </summary>
        public static readonly StringName GetVaryingName = "get_varying_name";
        /// <summary>
        /// Cached name for the 'set_varying_type' method.
        /// </summary>
        public static readonly StringName SetVaryingType = "set_varying_type";
        /// <summary>
        /// Cached name for the 'get_varying_type' method.
        /// </summary>
        public static readonly StringName GetVaryingType = "get_varying_type";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}
