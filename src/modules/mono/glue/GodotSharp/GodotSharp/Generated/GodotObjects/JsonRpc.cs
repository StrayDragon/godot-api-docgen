namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><a href="https://www.jsonrpc.org/">JSON-RPC</a> is a standard which wraps a method call in a <see cref="Godot.Json"/> object. The object has a particular structure and identifies which method is called, the parameters to that function, and carries an ID to keep track of responses. This class implements that standard on top of <see cref="Godot.Collections.Dictionary"/>; you will have to convert between a <see cref="Godot.Collections.Dictionary"/> and <see cref="Godot.Json"/> with other functions.</para>
/// </summary>
[GodotClassName("JSONRPC")]
public partial class JsonRpc : GodotObject
{
    public enum ErrorCode : long
    {
        /// <summary>
        /// <para>The request could not be parsed as it was not valid by JSON standard (<see cref="Godot.Json.Parse(string, bool)"/> failed).</para>
        /// </summary>
        ParseError = -32700,
        /// <summary>
        /// <para>A method call was requested but the request's format is not valid.</para>
        /// </summary>
        InvalidRequest = -32600,
        /// <summary>
        /// <para>A method call was requested but no function of that name existed in the JSONRPC subclass.</para>
        /// </summary>
        MethodNotFound = -32601,
        /// <summary>
        /// <para>A method call was requested but the given method parameters are not valid. Not used by the built-in JSONRPC.</para>
        /// </summary>
        InvalidParams = -32602,
        /// <summary>
        /// <para>An internal error occurred while processing the request. Not used by the built-in JSONRPC.</para>
        /// </summary>
        InternalError = -32603
    }

    private static readonly System.Type CachedType = typeof(JsonRpc);

    private static readonly StringName NativeName = "JSONRPC";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public JsonRpc() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal JsonRpc(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal JsonRpc(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMethod, 2137474292ul);

    /// <summary>
    /// <para>Registers a callback for the given method name.</para>
    /// <para>- <paramref name="name"/>: The name that clients can use to access the callback.</para>
    /// <para>- <paramref name="callback"/>: The callback which will handle the specified method.</para>
    /// </summary>
    public void SetMethod(string name, Callable callback)
    {
        NativeCalls.godot_icall_2_519(MethodBind0, GodotObject.GetPtr(this), name, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ProcessAction, 2963479484ul);

    /// <summary>
    /// <para>Given a Dictionary which takes the form of a JSON-RPC request: unpack the request and run it. Methods are resolved by looking at the field called "method" and looking for an equivalently named function in the JSONRPC object. If one is found that method is called.</para>
    /// <para>To add new supported methods extend the JSONRPC class and call <see cref="Godot.JsonRpc.ProcessAction(Variant, bool)"/> on your subclass.</para>
    /// <para><paramref name="action"/>: The action to be run, as a Dictionary in the form of a JSON-RPC request or notification.</para>
    /// </summary>
    public Variant ProcessAction(Variant action, bool recurse = false)
    {
        return NativeCalls.godot_icall_2_775(MethodBind1, GodotObject.GetPtr(this), action, recurse.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ProcessString, 1703090593ul);

    public string ProcessString(string action)
    {
        return NativeCalls.godot_icall_1_304(MethodBind2, GodotObject.GetPtr(this), action);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeRequest, 3423508980ul);

    /// <summary>
    /// <para>Returns a dictionary in the form of a JSON-RPC request. Requests are sent to a server with the expectation of a response. The ID field is used for the server to specify which exact request it is responding to.</para>
    /// <para>- <paramref name="method"/>: Name of the method being called.</para>
    /// <para>- <paramref name="params"/>: An array or dictionary of parameters being passed to the method.</para>
    /// <para>- <paramref name="id"/>: Uniquely identifies this request. The server is expected to send a response with the same ID.</para>
    /// </summary>
    public Godot.Collections.Dictionary MakeRequest(string method, Variant @params, Variant id)
    {
        return NativeCalls.godot_icall_3_776(MethodBind3, GodotObject.GetPtr(this), method, @params, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeResponse, 5053918ul);

    /// <summary>
    /// <para>When a server has received and processed a request, it is expected to send a response. If you did not want a response then you need to have sent a Notification instead.</para>
    /// <para>- <paramref name="result"/>: The return value of the function which was called.</para>
    /// <para>- <paramref name="id"/>: The ID of the request this response is targeted to.</para>
    /// </summary>
    public Godot.Collections.Dictionary MakeResponse(Variant result, Variant id)
    {
        return NativeCalls.godot_icall_2_777(MethodBind4, GodotObject.GetPtr(this), result, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeNotification, 2949127017ul);

    /// <summary>
    /// <para>Returns a dictionary in the form of a JSON-RPC notification. Notifications are one-shot messages which do not expect a response.</para>
    /// <para>- <paramref name="method"/>: Name of the method being called.</para>
    /// <para>- <paramref name="params"/>: An array or dictionary of parameters being passed to the method.</para>
    /// </summary>
    public Godot.Collections.Dictionary MakeNotification(string method, Variant @params)
    {
        return NativeCalls.godot_icall_2_778(MethodBind5, GodotObject.GetPtr(this), method, @params);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeResponseError, 928596297ul);

    /// <summary>
    /// <para>Creates a response which indicates a previous reply has failed in some way.</para>
    /// <para>- <paramref name="code"/>: The error code corresponding to what kind of error this is. See the <see cref="Godot.JsonRpc.ErrorCode"/> constants.</para>
    /// <para>- <paramref name="message"/>: A custom message about this error.</para>
    /// <para>- <paramref name="id"/>: The request this error is a response to.</para>
    /// </summary>
    public Godot.Collections.Dictionary MakeResponseError(int code, string message, Variant id = default)
    {
        return NativeCalls.godot_icall_3_779(MethodBind6, GodotObject.GetPtr(this), code, message, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScope, 2572618360ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScope(string scope, GodotObject target)
    {
        NativeCalls.godot_icall_2_517(MethodBind7, GodotObject.GetPtr(this), scope, GodotObject.GetPtr(target));
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
        /// Cached name for the 'set_method' method.
        /// </summary>
        public static readonly StringName SetMethod = "set_method";
        /// <summary>
        /// Cached name for the 'process_action' method.
        /// </summary>
        public static readonly StringName ProcessAction = "process_action";
        /// <summary>
        /// Cached name for the 'process_string' method.
        /// </summary>
        public static readonly StringName ProcessString = "process_string";
        /// <summary>
        /// Cached name for the 'make_request' method.
        /// </summary>
        public static readonly StringName MakeRequest = "make_request";
        /// <summary>
        /// Cached name for the 'make_response' method.
        /// </summary>
        public static readonly StringName MakeResponse = "make_response";
        /// <summary>
        /// Cached name for the 'make_notification' method.
        /// </summary>
        public static readonly StringName MakeNotification = "make_notification";
        /// <summary>
        /// Cached name for the 'make_response_error' method.
        /// </summary>
        public static readonly StringName MakeResponseError = "make_response_error";
        /// <summary>
        /// Cached name for the 'set_scope' method.
        /// </summary>
        public static readonly StringName SetScope = "set_scope";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
