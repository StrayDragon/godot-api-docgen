namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object contains shader fragments from Godot's internal shaders. These can be used when access to internal uniform buffers and/or internal functions is required for instance when composing compositor effects or compute shaders. Only fragments for the current rendering device are loaded.</para>
/// </summary>
public partial class ShaderIncludeDB : GodotObject
{
    private static readonly System.Type CachedType = typeof(ShaderIncludeDB);

    private static readonly StringName NativeName = "ShaderIncludeDB";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ShaderIncludeDB() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ShaderIncludeDB(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ShaderIncludeDB(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ListBuiltInIncludeFiles, 2981934095ul);

    /// <summary>
    /// <para>Returns a list of built-in include files that are currently registered.</para>
    /// </summary>
    public static string[] ListBuiltInIncludeFiles()
    {
        return NativeCalls.godot_icall_0_484(MethodBind0);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasBuiltInIncludeFile, 2323990056ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if an include file with this name exists.</para>
    /// </summary>
    public static bool HasBuiltInIncludeFile(string fileName)
    {
        return NativeCalls.godot_icall_1_377(MethodBind1, fileName).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBuiltInIncludeFile, 1703090593ul);

    /// <summary>
    /// <para>Returns the code for the built-in shader fragment. You can also access this in your shader code through <c>#include "filename"</c>.</para>
    /// </summary>
    public static string GetBuiltInIncludeFile(string fileName)
    {
        return NativeCalls.godot_icall_1_561(MethodBind2, fileName);
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'list_built_in_include_files' method.
        /// </summary>
        public static readonly StringName ListBuiltInIncludeFiles = "list_built_in_include_files";
        /// <summary>
        /// Cached name for the 'has_built_in_include_file' method.
        /// </summary>
        public static readonly StringName HasBuiltInIncludeFile = "has_built_in_include_file";
        /// <summary>
        /// Cached name for the 'get_built_in_include_file' method.
        /// </summary>
        public static readonly StringName GetBuiltInIncludeFile = "get_built_in_include_file";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
