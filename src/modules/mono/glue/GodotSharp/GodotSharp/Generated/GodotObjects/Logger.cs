namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Custom logger to receive messages from the internal error/warning stream. Loggers are registered via <see cref="Godot.OS.AddLogger(Logger)"/>.</para>
/// </summary>
public partial class Logger : RefCounted
{
    public enum ErrorType : long
    {
        /// <summary>
        /// <para>The message received is an error.</para>
        /// </summary>
        Error = 0,
        /// <summary>
        /// <para>The message received is a warning.</para>
        /// </summary>
        Warning = 1,
        /// <summary>
        /// <para>The message received is a script error.</para>
        /// </summary>
        Script = 2,
        /// <summary>
        /// <para>The message received is a shader error.</para>
        /// </summary>
        Shader = 3
    }

    private static readonly System.Type CachedType = typeof(Logger);

    private static readonly StringName NativeName = "Logger";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Logger() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Logger(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Logger(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when an error is logged. The error provides the <paramref name="function"/>, <paramref name="file"/>, and <paramref name="line"/> that it originated from, as well as either the <paramref name="code"/> that generated the error or a <paramref name="rationale"/>.</para>
    /// <para>The type of error provided by <paramref name="errorType"/> is described in the <see cref="Godot.Logger.ErrorType"/> enumeration.</para>
    /// <para>Additionally, <paramref name="scriptBacktraces"/> provides backtraces for each of the script languages. These will only contain stack frames in editor builds and debug builds by default. To enable them for release builds as well, you need to enable <c>ProjectSettings.debug/settings/gdscript/always_track_call_stacks</c>.</para>
    /// <para><b>Warning:</b> This method will be called from threads other than the main thread, possibly at the same time, so you will need to have some kind of thread-safety in your implementation of it, like a <see cref="Godot.Mutex"/>.</para>
    /// <para><b>Note:</b> <paramref name="scriptBacktraces"/> will not contain any captured variables, due to its prohibitively high cost. To get those you will need to capture the backtraces yourself, from within the <see cref="Godot.Logger"/> virtual methods, using <see cref="Godot.Engine.CaptureScriptBacktraces(bool)"/>.</para>
    /// <para><b>Note:</b> Logging errors from this method using functions like <c>@GlobalScope.push_error</c> or <c>@GlobalScope.push_warning</c> is not supported, as it could cause infinite recursion. These errors will only show up in the console output.</para>
    /// </summary>
    public virtual void _LogError(string function, string file, int line, string code, string rationale, bool editorNotify, int errorType, Godot.Collections.Array<ScriptBacktrace> scriptBacktraces)
    {
    }

    /// <summary>
    /// <para>Called when a message is logged. If <paramref name="error"/> is <see langword="true"/>, then this message was meant to be sent to <c>stderr</c>.</para>
    /// <para><b>Warning:</b> This method will be called from threads other than the main thread, possibly at the same time, so you will need to have some kind of thread-safety in your implementation of it, like a <see cref="Godot.Mutex"/>.</para>
    /// <para><b>Note:</b> Logging another message from this method using functions like <c>@GlobalScope.print</c> is not supported, as it could cause infinite recursion. These messages will only show up in the console output.</para>
    /// </summary>
    public virtual void _LogMessage(string message, bool error)
    {
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__log_error = "_LogError";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__log_message = "_LogMessage";

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
        if ((method == MethodProxyName__log_error || method == MethodName._LogError) && args.Count == 8 && HasGodotClassMethod((godot_string_name)MethodProxyName__log_error.NativeValue))
        {
            _LogError(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]), VariantUtils.ConvertTo<int>(args[2]), VariantUtils.ConvertTo<string>(args[3]), VariantUtils.ConvertTo<string>(args[4]), VariantUtils.ConvertTo<bool>(args[5]), VariantUtils.ConvertTo<int>(args[6]), new Godot.Collections.Array<ScriptBacktrace>(VariantUtils.ConvertToArray(args[7])));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__log_message || method == MethodName._LogMessage) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__log_message.NativeValue))
        {
            _LogMessage(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
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
        if (method == MethodName._LogError)
        {
            if (HasGodotClassMethod(MethodProxyName__log_error.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._LogMessage)
        {
            if (HasGodotClassMethod(MethodProxyName__log_message.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the '_log_error' method.
        /// </summary>
        public static readonly StringName _LogError = "_log_error";
        /// <summary>
        /// Cached name for the '_log_message' method.
        /// </summary>
        public static readonly StringName _LogMessage = "_log_message";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
