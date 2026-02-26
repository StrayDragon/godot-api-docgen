namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A class stored as a resource. A script extends the functionality of all objects that instantiate it.</para>
/// <para>This is the base class for all scripts and should not be used directly. Trying to create a new script with this class will result in an error.</para>
/// <para>The <c>new</c> method of a script subclass creates a new instance. <see cref="Godot.GodotObject.SetScript(Variant)"/> extends an existing object, if that object's class matches one of the script's base classes.</para>
/// </summary>
public partial class Script : Resource
{
    /// <summary>
    /// <para>The script source code or an empty string if source code is not available. When set, does not reload the class implementation automatically.</para>
    /// </summary>
    public string SourceCode
    {
        get
        {
            return GetSourceCode();
        }
        set
        {
            SetSourceCode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Script);

    private static readonly StringName NativeName = "Script";

    internal Script() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Script(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Script(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanInstantiate, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the script can be instantiated.</para>
    /// </summary>
    public bool CanInstantiate()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstanceHas, 397768994ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="baseObject"/> is an instance of this script.</para>
    /// </summary>
    public bool InstanceHas(GodotObject baseObject)
    {
        return NativeCalls.godot_icall_1_176(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(baseObject)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSourceCode, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the script contains non-empty source code.</para>
    /// <para><b>Note:</b> If a script does not have source code, this does not mean that it is invalid or unusable. For example, a <see cref="Godot.GDScript"/> that was exported with binary tokenization has no source code, but still behaves as expected and could be instantiated. This can be checked with <see cref="Godot.Script.CanInstantiate()"/>.</para>
    /// </summary>
    public bool HasSourceCode()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSourceCode, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetSourceCode()
    {
        return NativeCalls.godot_icall_0_58(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSourceCode, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSourceCode(string source)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), source);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Reload, 1633102583ul);

    /// <summary>
    /// <para>Reloads the script's class implementation. Returns an error code.</para>
    /// </summary>
    public Error Reload(bool keepState = false)
    {
        return (Error)NativeCalls.godot_icall_1_198(MethodBind5, GodotObject.GetPtr(this), keepState.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBaseScript, 278624046ul);

    /// <summary>
    /// <para>Returns the script directly inherited by this script.</para>
    /// </summary>
    public Script GetBaseScript()
    {
        return (Script)NativeCalls.godot_icall_0_63(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceBaseType, 2002593661ul);

    /// <summary>
    /// <para>Returns the script's base type.</para>
    /// </summary>
    public StringName GetInstanceBaseType()
    {
        return NativeCalls.godot_icall_0_65(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalName, 2002593661ul);

    /// <summary>
    /// <para>Returns the class name associated with the script, if there is one. Returns an empty string otherwise.</para>
    /// <para>To give the script a global name, you can use the <c>class_name</c> keyword in GDScript and the <c>[GlobalClass]</c> attribute in C#.</para>
    /// <para><code>
    /// using Godot;
    /// 
    /// [GlobalClass]
    /// public partial class MyNode : Node
    /// {
    /// }
    /// </code></para>
    /// </summary>
    public StringName GetGlobalName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasScriptSignal, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the script, or a base class, defines a signal with the given name.</para>
    /// </summary>
    public bool HasScriptSignal(StringName signalName)
    {
        return NativeCalls.godot_icall_1_105(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(signalName?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptPropertyList, 2915620761ul);

    /// <summary>
    /// <para>Returns the list of properties in this <see cref="Godot.Script"/>.</para>
    /// <para><b>Note:</b> The dictionaries returned by this method are formatted identically to those returned by <see cref="Godot.GodotObject.GetPropertyList()"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetScriptPropertyList()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind10, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptMethodList, 2915620761ul);

    /// <summary>
    /// <para>Returns the list of methods in this <see cref="Godot.Script"/>.</para>
    /// <para><b>Note:</b> The dictionaries returned by this method are formatted identically to those returned by <see cref="Godot.GodotObject.GetMethodList()"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetScriptMethodList()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind11, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptSignalList, 2915620761ul);

    /// <summary>
    /// <para>Returns the list of signals defined in this <see cref="Godot.Script"/>.</para>
    /// <para><b>Note:</b> The dictionaries returned by this method are formatted identically to those returned by <see cref="Godot.GodotObject.GetSignalList()"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetScriptSignalList()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind12, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptConstantMap, 2382534195ul);

    /// <summary>
    /// <para>Returns a dictionary containing constant names and their values.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetScriptConstantMap()
    {
        return NativeCalls.godot_icall_0_122(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPropertyDefaultValue, 2138907829ul);

    /// <summary>
    /// <para>Returns the default value of the specified property.</para>
    /// </summary>
    public Variant GetPropertyDefaultValue(StringName property)
    {
        return NativeCalls.godot_icall_1_143(MethodBind14, GodotObject.GetPtr(this), (godot_string_name)(property?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTool, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the script is a tool script. A tool script can run in the editor.</para>
    /// </summary>
    public bool IsTool()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAbstract, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the script is an abstract script. An abstract script does not have a constructor and cannot be instantiated.</para>
    /// </summary>
    public bool IsAbstract()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRpcConfig, 1214101251ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Collections.Dictionary"/> mapping method names to their RPC configuration defined by this script.</para>
    /// </summary>
    public Variant GetRpcConfig()
    {
        return NativeCalls.godot_icall_0_772(MethodBind17, GodotObject.GetPtr(this));
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
        /// Cached name for the 'source_code' property.
        /// </summary>
        public static readonly StringName SourceCode = "source_code";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'can_instantiate' method.
        /// </summary>
        public static readonly StringName CanInstantiate = "can_instantiate";
        /// <summary>
        /// Cached name for the 'instance_has' method.
        /// </summary>
        public static readonly StringName InstanceHas = "instance_has";
        /// <summary>
        /// Cached name for the 'has_source_code' method.
        /// </summary>
        public static readonly StringName HasSourceCode = "has_source_code";
        /// <summary>
        /// Cached name for the 'get_source_code' method.
        /// </summary>
        public static readonly StringName GetSourceCode = "get_source_code";
        /// <summary>
        /// Cached name for the 'set_source_code' method.
        /// </summary>
        public static readonly StringName SetSourceCode = "set_source_code";
        /// <summary>
        /// Cached name for the 'reload' method.
        /// </summary>
        public static readonly StringName Reload = "reload";
        /// <summary>
        /// Cached name for the 'get_base_script' method.
        /// </summary>
        public static readonly StringName GetBaseScript = "get_base_script";
        /// <summary>
        /// Cached name for the 'get_instance_base_type' method.
        /// </summary>
        public static readonly StringName GetInstanceBaseType = "get_instance_base_type";
        /// <summary>
        /// Cached name for the 'get_global_name' method.
        /// </summary>
        public static readonly StringName GetGlobalName = "get_global_name";
        /// <summary>
        /// Cached name for the 'has_script_signal' method.
        /// </summary>
        public static readonly StringName HasScriptSignal = "has_script_signal";
        /// <summary>
        /// Cached name for the 'get_script_property_list' method.
        /// </summary>
        public static readonly StringName GetScriptPropertyList = "get_script_property_list";
        /// <summary>
        /// Cached name for the 'get_script_method_list' method.
        /// </summary>
        public static readonly StringName GetScriptMethodList = "get_script_method_list";
        /// <summary>
        /// Cached name for the 'get_script_signal_list' method.
        /// </summary>
        public static readonly StringName GetScriptSignalList = "get_script_signal_list";
        /// <summary>
        /// Cached name for the 'get_script_constant_map' method.
        /// </summary>
        public static readonly StringName GetScriptConstantMap = "get_script_constant_map";
        /// <summary>
        /// Cached name for the 'get_property_default_value' method.
        /// </summary>
        public static readonly StringName GetPropertyDefaultValue = "get_property_default_value";
        /// <summary>
        /// Cached name for the 'is_tool' method.
        /// </summary>
        public static readonly StringName IsTool = "is_tool";
        /// <summary>
        /// Cached name for the 'is_abstract' method.
        /// </summary>
        public static readonly StringName IsAbstract = "is_abstract";
        /// <summary>
        /// Cached name for the 'get_rpc_config' method.
        /// </summary>
        public static readonly StringName GetRpcConfig = "get_rpc_config";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
