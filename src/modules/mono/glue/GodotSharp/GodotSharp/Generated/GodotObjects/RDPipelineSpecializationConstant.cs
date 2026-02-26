namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A <i>specialization constant</i> is a way to create additional variants of shaders without actually increasing the number of shader versions that are compiled. This allows improving performance by reducing the number of shader versions and reducing <c>if</c> branching, while still allowing shaders to be flexible for different use cases.</para>
/// <para>This object is used by <see cref="Godot.RenderingDevice"/>.</para>
/// </summary>
public partial class RDPipelineSpecializationConstant : RefCounted
{
    /// <summary>
    /// <para>The specialization constant's value. Only <see cref="bool"/>, <see cref="int"/> and <see cref="float"/> types are valid for specialization constants.</para>
    /// </summary>
    public Variant Value
    {
        get
        {
            return GetValue();
        }
        set
        {
            SetValue(value);
        }
    }

    /// <summary>
    /// <para>The identifier of the specialization constant. This is a value starting from <c>0</c> and that increments for every different specialization constant for a given shader.</para>
    /// </summary>
    public uint ConstantId
    {
        get
        {
            return GetConstantId();
        }
        set
        {
            SetConstantId(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDPipelineSpecializationConstant);

    private static readonly StringName NativeName = "RDPipelineSpecializationConstant";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDPipelineSpecializationConstant() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineSpecializationConstant(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDPipelineSpecializationConstant(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetValue, 1114965689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetValue(Variant value)
    {
        NativeCalls.godot_icall_1_773(MethodBind0, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetValue, 1214101251ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Variant GetValue()
    {
        return NativeCalls.godot_icall_0_772(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstantId, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetConstantId(uint constantId)
    {
        NativeCalls.godot_icall_1_208(MethodBind2, GodotObject.GetPtr(this), constantId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstantId, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetConstantId()
    {
        return NativeCalls.godot_icall_0_209(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'value' property.
        /// </summary>
        public static readonly StringName Value = "value";
        /// <summary>
        /// Cached name for the 'constant_id' property.
        /// </summary>
        public static readonly StringName ConstantId = "constant_id";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_value' method.
        /// </summary>
        public static readonly StringName SetValue = "set_value";
        /// <summary>
        /// Cached name for the 'get_value' method.
        /// </summary>
        public static readonly StringName GetValue = "get_value";
        /// <summary>
        /// Cached name for the 'set_constant_id' method.
        /// </summary>
        public static readonly StringName SetConstantId = "set_constant_id";
        /// <summary>
        /// Cached name for the 'get_constant_id' method.
        /// </summary>
        public static readonly StringName GetConstantId = "get_constant_id";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
