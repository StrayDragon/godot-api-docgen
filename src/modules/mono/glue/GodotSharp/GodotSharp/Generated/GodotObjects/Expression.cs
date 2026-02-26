namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An expression can be made of any arithmetic operation, built-in math function call, method call of a passed instance, or built-in type construction call.</para>
/// <para>An example expression text using the built-in math functions could be <c>sqrt(pow(3, 2) + pow(4, 2))</c>.</para>
/// <para>In the following example we use a <see cref="Godot.LineEdit"/> node to write our expression and show the result.</para>
/// <para><code>
/// private Expression _expression = new Expression();
/// 
/// public override void _Ready()
/// {
/// 	GetNode&lt;LineEdit&gt;("LineEdit").TextSubmitted += OnTextEntered;
/// }
/// 
/// private void OnTextEntered(string command)
/// {
/// 	Error error = _expression.Parse(command);
/// 	if (error != Error.Ok)
/// 	{
/// 		GD.Print(_expression.GetErrorText());
/// 		return;
/// 	}
/// 	Variant result = _expression.Execute();
/// 	if (!_expression.HasExecuteFailed())
/// 	{
/// 		GetNode&lt;LineEdit&gt;("LineEdit").Text = result.ToString();
/// 	}
/// }
/// </code></para>
/// </summary>
public partial class Expression : RefCounted
{
    private static readonly System.Type CachedType = typeof(Expression);

    private static readonly StringName NativeName = "Expression";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Expression() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Expression(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Expression(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Parse, 3069722906ul);

    /// <summary>
    /// <para>Parses the expression and returns an <see cref="Godot.Error"/> code.</para>
    /// <para>You can optionally specify names of variables that may appear in the expression with <paramref name="inputNames"/>, so that you can bind them when it gets executed.</para>
    /// </summary>
    /// <param name="inputNames">If the parameter is null, then the default value is <c>Array.Empty&lt;string&gt;()</c>.</param>
    public Error Parse(string expression, string[] inputNames = null)
    {
        string[] inputNamesOrDefVal = inputNames != null ? inputNames : Array.Empty<string>();
        return (Error)NativeCalls.godot_icall_2_553(MethodBind0, GodotObject.GetPtr(this), expression, inputNamesOrDefVal);
    }

    /// <summary>
    /// <para>Parses the expression and returns an <see cref="Godot.Error"/> code.</para>
    /// <para>You can optionally specify names of variables that may appear in the expression with <paramref name="inputNames"/>, so that you can bind them when it gets executed.</para>
    /// </summary>
    public Error Parse(string expression, ReadOnlySpan<string> inputNames)
    {
        return (Error)NativeCalls.godot_icall_2_553(MethodBind0, GodotObject.GetPtr(this), expression, inputNames);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Execute, 3712471238ul);

    /// <summary>
    /// <para>Executes the expression that was previously parsed by <see cref="Godot.Expression.Parse(string, string[])"/> and returns the result. Before you use the returned object, you should check if the method failed by calling <see cref="Godot.Expression.HasExecuteFailed()"/>.</para>
    /// <para>If you defined input variables in <see cref="Godot.Expression.Parse(string, string[])"/>, you can specify their values in the inputs array, in the same order.</para>
    /// </summary>
    public Variant Execute(Godot.Collections.Array inputs = null, GodotObject baseInstance = default, bool showError = true, bool constCallsOnly = false)
    {
        return NativeCalls.godot_icall_4_554(MethodBind1, GodotObject.GetPtr(this), (godot_array)(inputs ?? new()).NativeValue, GodotObject.GetPtr(baseInstance), showError.ToGodotBool(), constCallsOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasExecuteFailed, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <see cref="Godot.Expression.Execute(Godot.Collections.Array, GodotObject, bool, bool)"/> has failed.</para>
    /// </summary>
    public bool HasExecuteFailed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetErrorText, 201670096ul);

    /// <summary>
    /// <para>Returns the error text if <see cref="Godot.Expression.Parse(string, string[])"/> or <see cref="Godot.Expression.Execute(Godot.Collections.Array, GodotObject, bool, bool)"/> has failed.</para>
    /// </summary>
    public string GetErrorText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'parse' method.
        /// </summary>
        public static readonly StringName Parse = "parse";
        /// <summary>
        /// Cached name for the 'execute' method.
        /// </summary>
        public static readonly StringName Execute = "execute";
        /// <summary>
        /// Cached name for the 'has_execute_failed' method.
        /// </summary>
        public static readonly StringName HasExecuteFailed = "has_execute_failed";
        /// <summary>
        /// Cached name for the 'get_error_text' method.
        /// </summary>
        public static readonly StringName GetErrorText = "get_error_text";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
