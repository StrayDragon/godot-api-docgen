namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object is used by <see cref="Godot.RenderingDevice"/>.</para>
/// </summary>
public partial class RDUniform : RefCounted
{
    /// <summary>
    /// <para>The uniform's data type.</para>
    /// </summary>
    public RenderingDevice.UniformType UniformType
    {
        get
        {
            return GetUniformType();
        }
        set
        {
            SetUniformType(value);
        }
    }

    /// <summary>
    /// <para>The uniform's binding.</para>
    /// </summary>
    public int Binding
    {
        get
        {
            return GetBinding();
        }
        set
        {
            SetBinding(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array<Rid> _Ids
    {
        get
        {
            return GetIds();
        }
        set
        {
            _SetIds(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(RDUniform);

    private static readonly StringName NativeName = "RDUniform";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDUniform() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDUniform(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDUniform(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUniformType, 1664894931ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUniformType(RenderingDevice.UniformType pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUniformType, 475470040ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RenderingDevice.UniformType GetUniformType()
    {
        return (RenderingDevice.UniformType)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBinding, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBinding(int pMember)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), pMember);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBinding, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBinding()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddId, 2722037293ul);

    /// <summary>
    /// <para>Binds the given id to the uniform. The data associated with the id is then used when the uniform is passed to a shader.</para>
    /// </summary>
    public void AddId(Rid id)
    {
        NativeCalls.godot_icall_1_286(MethodBind4, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearIds, 3218959716ul);

    /// <summary>
    /// <para>Unbinds all ids currently bound to the uniform.</para>
    /// </summary>
    public void ClearIds()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetIds, 381264803ul);

    internal void _SetIds(Godot.Collections.Array<Rid> ids)
    {
        NativeCalls.godot_icall_1_138(MethodBind6, GodotObject.GetPtr(this), (godot_array)(ids ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIds, 3995934104ul);

    /// <summary>
    /// <para>Returns an array of all ids currently bound to the uniform.</para>
    /// </summary>
    public Godot.Collections.Array<Rid> GetIds()
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this)));
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
        /// Cached name for the 'uniform_type' property.
        /// </summary>
        public static readonly StringName UniformType = "uniform_type";
        /// <summary>
        /// Cached name for the 'binding' property.
        /// </summary>
        public static readonly StringName Binding = "binding";
        /// <summary>
        /// Cached name for the '_ids' property.
        /// </summary>
        public static readonly StringName _Ids = "_ids";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_uniform_type' method.
        /// </summary>
        public static readonly StringName SetUniformType = "set_uniform_type";
        /// <summary>
        /// Cached name for the 'get_uniform_type' method.
        /// </summary>
        public static readonly StringName GetUniformType = "get_uniform_type";
        /// <summary>
        /// Cached name for the 'set_binding' method.
        /// </summary>
        public static readonly StringName SetBinding = "set_binding";
        /// <summary>
        /// Cached name for the 'get_binding' method.
        /// </summary>
        public static readonly StringName GetBinding = "get_binding";
        /// <summary>
        /// Cached name for the 'add_id' method.
        /// </summary>
        public static readonly StringName AddId = "add_id";
        /// <summary>
        /// Cached name for the 'clear_ids' method.
        /// </summary>
        public static readonly StringName ClearIds = "clear_ids";
        /// <summary>
        /// Cached name for the '_set_ids' method.
        /// </summary>
        public static readonly StringName _SetIds = "_set_ids";
        /// <summary>
        /// Cached name for the 'get_ids' method.
        /// </summary>
        public static readonly StringName GetIds = "get_ids";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
