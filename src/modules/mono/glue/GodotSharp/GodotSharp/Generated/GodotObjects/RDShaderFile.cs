namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Compiled shader file in SPIR-V form.</para>
/// <para>See also <see cref="Godot.RDShaderSource"/>. <see cref="Godot.RDShaderFile"/> is only meant to be used with the <see cref="Godot.RenderingDevice"/> API. It should not be confused with Godot's own <see cref="Godot.Shader"/> resource, which is what Godot's various nodes use for high-level shader programming.</para>
/// </summary>
public partial class RDShaderFile : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary _Versions
    {
        get
        {
            return _GetVersions();
        }
        set
        {
            _SetVersions(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>The base compilation error message, which indicates errors not related to a specific shader stage if non-empty. If empty, shader compilation is not necessarily successful (check <see cref="Godot.RDShaderSpirV"/>'s error message members).</para>
    /// </summary>
    public string BaseError
    {
        get
        {
            return GetBaseError();
        }
        set
        {
            SetBaseError(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RDShaderFile);

    private static readonly StringName NativeName = "RDShaderFile";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RDShaderFile() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDShaderFile(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal RDShaderFile(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBytecode, 1526857008ul);

    /// <summary>
    /// <para>Sets the SPIR-V <paramref name="bytecode"/> that will be compiled for the specified <paramref name="version"/>.</para>
    /// </summary>
    public void SetBytecode(RDShaderSpirV bytecode, StringName version = null)
    {
        NativeCalls.godot_icall_2_524(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(bytecode), (godot_string_name)(version?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpirV, 2689310080ul);

    /// <summary>
    /// <para>Returns the SPIR-V intermediate representation for the specified shader <paramref name="version"/>.</para>
    /// </summary>
    public RDShaderSpirV GetSpirV(StringName version = null)
    {
        return (RDShaderSpirV)NativeCalls.godot_icall_1_119(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(version?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVersionList, 3995934104ul);

    /// <summary>
    /// <para>Returns the list of compiled versions for this shader.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetVersionList()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind2, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBaseError, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBaseError(string error)
    {
        NativeCalls.godot_icall_1_57(MethodBind3, GodotObject.GetPtr(this), error);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBaseError, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetBaseError()
    {
        return NativeCalls.godot_icall_0_58(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetVersions, 4155329257ul);

    internal void _SetVersions(Godot.Collections.Dictionary versions)
    {
        NativeCalls.godot_icall_1_121(MethodBind5, GodotObject.GetPtr(this), (godot_dictionary)(versions ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetVersions, 3102165223ul);

    internal Godot.Collections.Dictionary _GetVersions()
    {
        return NativeCalls.godot_icall_0_122(MethodBind6, GodotObject.GetPtr(this));
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
        /// Cached name for the '_versions' property.
        /// </summary>
        public static readonly StringName _Versions = "_versions";
        /// <summary>
        /// Cached name for the 'base_error' property.
        /// </summary>
        public static readonly StringName BaseError = "base_error";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_bytecode' method.
        /// </summary>
        public static readonly StringName SetBytecode = "set_bytecode";
        /// <summary>
        /// Cached name for the 'get_spirv' method.
        /// </summary>
        public static readonly StringName GetSpirV = "get_spirv";
        /// <summary>
        /// Cached name for the 'get_version_list' method.
        /// </summary>
        public static readonly StringName GetVersionList = "get_version_list";
        /// <summary>
        /// Cached name for the 'set_base_error' method.
        /// </summary>
        public static readonly StringName SetBaseError = "set_base_error";
        /// <summary>
        /// Cached name for the 'get_base_error' method.
        /// </summary>
        public static readonly StringName GetBaseError = "get_base_error";
        /// <summary>
        /// Cached name for the '_set_versions' method.
        /// </summary>
        public static readonly StringName _SetVersions = "_set_versions";
        /// <summary>
        /// Cached name for the '_get_versions' method.
        /// </summary>
        public static readonly StringName _GetVersions = "_get_versions";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
