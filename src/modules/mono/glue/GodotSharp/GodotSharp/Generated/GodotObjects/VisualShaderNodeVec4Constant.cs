namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A constant 4D vector, which can be used as an input node.</para>
/// </summary>
public partial class VisualShaderNodeVec4Constant : VisualShaderNodeConstant
{
    /// <summary>
    /// <para>A 4D vector (represented as a <see cref="Godot.Quaternion"/>) constant which represents the state of this node.</para>
    /// </summary>
    public Quaternion Constant
    {
        get
        {
            return GetConstant();
        }
        set
        {
            SetConstant(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector4 ConstantV4
    {
        get
        {
            return _GetConstantV4();
        }
        set
        {
            _SetConstantV4(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(VisualShaderNodeVec4Constant);

    private static readonly StringName NativeName = "VisualShaderNodeVec4Constant";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeVec4Constant() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeVec4Constant(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeVec4Constant(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstant, 1727505552ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetConstant(Quaternion constant)
    {
        NativeCalls.godot_icall_1_649(MethodBind0, GodotObject.GetPtr(this), &constant);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstant, 1222331677ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quaternion GetConstant()
    {
        return NativeCalls.godot_icall_0_126(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetConstantV4, 643568085ul);

    internal unsafe void _SetConstantV4(Vector4 constant)
    {
        NativeCalls.godot_icall_1_1495(MethodBind2, GodotObject.GetPtr(this), &constant);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetConstantV4, 2435802345ul);

    internal Vector4 _GetConstantV4()
    {
        return NativeCalls.godot_icall_0_1496(MethodBind3, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNodeConstant.PropertyName
    {
        /// <summary>
        /// Cached name for the 'constant' property.
        /// </summary>
        public static readonly StringName Constant = "constant";
        /// <summary>
        /// Cached name for the 'constant_v4' property.
        /// </summary>
        public static readonly StringName ConstantV4 = "constant_v4";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeConstant.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_constant' method.
        /// </summary>
        public static readonly StringName SetConstant = "set_constant";
        /// <summary>
        /// Cached name for the 'get_constant' method.
        /// </summary>
        public static readonly StringName GetConstant = "get_constant";
        /// <summary>
        /// Cached name for the '_set_constant_v4' method.
        /// </summary>
        public static readonly StringName _SetConstantV4 = "_set_constant_v4";
        /// <summary>
        /// Cached name for the '_get_constant_v4' method.
        /// </summary>
        public static readonly StringName _GetConstantV4 = "_get_constant_v4";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNodeConstant.SignalName
    {
    }
}
