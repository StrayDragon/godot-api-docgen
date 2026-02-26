namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.ScriptBacktrace"/> holds an already captured backtrace of a specific script language, such as GDScript or C#, which are captured using <see cref="Godot.Engine.CaptureScriptBacktraces(bool)"/>.</para>
/// <para>See <c>ProjectSettings.debug/settings/gdscript/always_track_call_stacks</c> and <c>ProjectSettings.debug/settings/gdscript/always_track_local_variables</c> for ways of controlling the contents of this class.</para>
/// </summary>
public partial class ScriptBacktrace : RefCounted
{
    private static readonly System.Type CachedType = typeof(ScriptBacktrace);

    private static readonly StringName NativeName = "ScriptBacktrace";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ScriptBacktrace() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ScriptBacktrace(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ScriptBacktrace(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguageName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the script language that this backtrace was captured from.</para>
    /// </summary>
    public string GetLanguageName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmpty, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the backtrace has no stack frames.</para>
    /// </summary>
    public bool IsEmpty()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of stack frames in the backtrace.</para>
    /// </summary>
    public int GetFrameCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameFunction, 844755477ul);

    /// <summary>
    /// <para>Returns the name of the function called at the stack frame at the specified index.</para>
    /// </summary>
    public string GetFrameFunction(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind3, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameFile, 844755477ul);

    /// <summary>
    /// <para>Returns the file name of the call site represented by the stack frame at the specified index.</para>
    /// </summary>
    public string GetFrameFile(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind4, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameLine, 923996154ul);

    /// <summary>
    /// <para>Returns the line number of the call site represented by the stack frame at the specified index.</para>
    /// </summary>
    public int GetFrameLine(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalVariableCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of global variables (e.g. autoload singletons) in the backtrace.</para>
    /// <para><b>Note:</b> This will be non-zero only if the <c>include_variables</c> parameter was <see langword="true"/> when capturing the backtrace with <see cref="Godot.Engine.CaptureScriptBacktraces(bool)"/>.</para>
    /// </summary>
    public int GetGlobalVariableCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalVariableName, 844755477ul);

    /// <summary>
    /// <para>Returns the name of the global variable at the specified index.</para>
    /// </summary>
    public string GetGlobalVariableName(int variableIndex)
    {
        return NativeCalls.godot_icall_1_133(MethodBind7, GodotObject.GetPtr(this), variableIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalVariableValue, 4227898402ul);

    /// <summary>
    /// <para>Returns the value of the global variable at the specified index.</para>
    /// <para><b>Warning:</b> With GDScript backtraces, the returned <see cref="Godot.Variant"/> will be the variable's actual value, including any object references. This means that storing the returned <see cref="Godot.Variant"/> will prevent any such object from being deallocated, so it's generally recommended not to do so.</para>
    /// </summary>
    public Variant GetGlobalVariableValue(int variableIndex)
    {
        return NativeCalls.godot_icall_1_702(MethodBind8, GodotObject.GetPtr(this), variableIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalVariableCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of local variables in the stack frame at the specified index.</para>
    /// <para><b>Note:</b> This will be non-zero only if the <c>include_variables</c> parameter was <see langword="true"/> when capturing the backtrace with <see cref="Godot.Engine.CaptureScriptBacktraces(bool)"/>.</para>
    /// </summary>
    public int GetLocalVariableCount(int frameIndex)
    {
        return NativeCalls.godot_icall_1_60(MethodBind9, GodotObject.GetPtr(this), frameIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalVariableName, 1391810591ul);

    /// <summary>
    /// <para>Returns the name of the local variable at the specified <paramref name="variableIndex"/> in the stack frame at the specified <paramref name="frameIndex"/>.</para>
    /// </summary>
    public string GetLocalVariableName(int frameIndex, int variableIndex)
    {
        return NativeCalls.godot_icall_2_222(MethodBind10, GodotObject.GetPtr(this), frameIndex, variableIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalVariableValue, 678354945ul);

    /// <summary>
    /// <para>Returns the value of the local variable at the specified <paramref name="variableIndex"/> in the stack frame at the specified <paramref name="frameIndex"/>.</para>
    /// <para><b>Warning:</b> With GDScript backtraces, the returned <see cref="Godot.Variant"/> will be the variable's actual value, including any object references. This means that storing the returned <see cref="Godot.Variant"/> will prevent any such object from being deallocated, so it's generally recommended not to do so.</para>
    /// </summary>
    public Variant GetLocalVariableValue(int frameIndex, int variableIndex)
    {
        return NativeCalls.godot_icall_2_89(MethodBind11, GodotObject.GetPtr(this), frameIndex, variableIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMemberVariableCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of member variables in the stack frame at the specified index.</para>
    /// <para><b>Note:</b> This will be non-zero only if the <c>include_variables</c> parameter was <see langword="true"/> when capturing the backtrace with <see cref="Godot.Engine.CaptureScriptBacktraces(bool)"/>.</para>
    /// </summary>
    public int GetMemberVariableCount(int frameIndex)
    {
        return NativeCalls.godot_icall_1_60(MethodBind12, GodotObject.GetPtr(this), frameIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMemberVariableName, 1391810591ul);

    /// <summary>
    /// <para>Returns the name of the member variable at the specified <paramref name="variableIndex"/> in the stack frame at the specified <paramref name="frameIndex"/>.</para>
    /// </summary>
    public string GetMemberVariableName(int frameIndex, int variableIndex)
    {
        return NativeCalls.godot_icall_2_222(MethodBind13, GodotObject.GetPtr(this), frameIndex, variableIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMemberVariableValue, 678354945ul);

    /// <summary>
    /// <para>Returns the value of the member variable at the specified <paramref name="variableIndex"/> in the stack frame at the specified <paramref name="frameIndex"/>.</para>
    /// <para><b>Warning:</b> With GDScript backtraces, the returned <see cref="Godot.Variant"/> will be the variable's actual value, including any object references. This means that storing the returned <see cref="Godot.Variant"/> will prevent any such object from being deallocated, so it's generally recommended not to do so.</para>
    /// </summary>
    public Variant GetMemberVariableValue(int frameIndex, int variableIndex)
    {
        return NativeCalls.godot_icall_2_89(MethodBind14, GodotObject.GetPtr(this), frameIndex, variableIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Format, 3464456933ul);

    /// <summary>
    /// <para>Converts the backtrace to a <see cref="string"/>, where the entire string will be indented by <paramref name="indentAll"/> number of spaces, and the individual stack frames will be additionally indented by <paramref name="indentFrames"/> number of spaces.</para>
    /// <para><b>Note:</b> Calling <see cref="object.ToString()"/> on a <see cref="Godot.ScriptBacktrace"/> will produce the same output as calling <see cref="Godot.ScriptBacktrace.Format(int, int)"/> with all parameters left at their default values.</para>
    /// </summary>
    public string Format(int indentAll = 0, int indentFrames = 4)
    {
        return NativeCalls.godot_icall_2_222(MethodBind15, GodotObject.GetPtr(this), indentAll, indentFrames);
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_language_name' method.
        /// </summary>
        public static readonly StringName GetLanguageName = "get_language_name";
        /// <summary>
        /// Cached name for the 'is_empty' method.
        /// </summary>
        public static readonly StringName IsEmpty = "is_empty";
        /// <summary>
        /// Cached name for the 'get_frame_count' method.
        /// </summary>
        public static readonly StringName GetFrameCount = "get_frame_count";
        /// <summary>
        /// Cached name for the 'get_frame_function' method.
        /// </summary>
        public static readonly StringName GetFrameFunction = "get_frame_function";
        /// <summary>
        /// Cached name for the 'get_frame_file' method.
        /// </summary>
        public static readonly StringName GetFrameFile = "get_frame_file";
        /// <summary>
        /// Cached name for the 'get_frame_line' method.
        /// </summary>
        public static readonly StringName GetFrameLine = "get_frame_line";
        /// <summary>
        /// Cached name for the 'get_global_variable_count' method.
        /// </summary>
        public static readonly StringName GetGlobalVariableCount = "get_global_variable_count";
        /// <summary>
        /// Cached name for the 'get_global_variable_name' method.
        /// </summary>
        public static readonly StringName GetGlobalVariableName = "get_global_variable_name";
        /// <summary>
        /// Cached name for the 'get_global_variable_value' method.
        /// </summary>
        public static readonly StringName GetGlobalVariableValue = "get_global_variable_value";
        /// <summary>
        /// Cached name for the 'get_local_variable_count' method.
        /// </summary>
        public static readonly StringName GetLocalVariableCount = "get_local_variable_count";
        /// <summary>
        /// Cached name for the 'get_local_variable_name' method.
        /// </summary>
        public static readonly StringName GetLocalVariableName = "get_local_variable_name";
        /// <summary>
        /// Cached name for the 'get_local_variable_value' method.
        /// </summary>
        public static readonly StringName GetLocalVariableValue = "get_local_variable_value";
        /// <summary>
        /// Cached name for the 'get_member_variable_count' method.
        /// </summary>
        public static readonly StringName GetMemberVariableCount = "get_member_variable_count";
        /// <summary>
        /// Cached name for the 'get_member_variable_name' method.
        /// </summary>
        public static readonly StringName GetMemberVariableName = "get_member_variable_name";
        /// <summary>
        /// Cached name for the 'get_member_variable_value' method.
        /// </summary>
        public static readonly StringName GetMemberVariableValue = "get_member_variable_value";
        /// <summary>
        /// Cached name for the 'format' method.
        /// </summary>
        public static readonly StringName Format = "format";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
