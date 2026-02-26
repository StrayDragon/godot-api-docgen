namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The JavaScriptBridge singleton is implemented only in the Web export. It's used to access the browser's JavaScript context. This allows interaction with embedding pages or calling third-party JavaScript APIs.</para>
/// <para><b>Note:</b> This singleton can be disabled at build-time to improve security. By default, the JavaScriptBridge singleton is enabled. Official export templates also have the JavaScriptBridge singleton enabled. See <a href="$DOCS_URL/engine_details/development/compiling/compiling_for_web.html">Compiling for the Web</a> in the documentation for more information.</para>
/// </summary>
[GodotClassName("JavaScriptBridge")]
public partial class JavaScriptBridgeInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(JavaScriptBridgeInstance);

    private static readonly StringName NativeName = "JavaScriptBridge";

    internal JavaScriptBridgeInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal JavaScriptBridgeInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal JavaScriptBridgeInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Eval, 218087648ul);

    /// <summary>
    /// <para>Execute the string <paramref name="code"/> as JavaScript code within the browser window. This is a call to the actual global JavaScript function <c>eval()</c>.</para>
    /// <para>If <paramref name="useGlobalExecutionContext"/> is <see langword="true"/>, the code will be evaluated in the global execution context. Otherwise, it is evaluated in the execution context of a function within the engine's runtime environment.</para>
    /// </summary>
    public Variant Eval(string code, bool useGlobalExecutionContext = false)
    {
        return NativeCalls.godot_icall_2_780(MethodBind0, GodotObject.GetPtr(this), code, useGlobalExecutionContext.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterface, 1355533281ul);

    /// <summary>
    /// <para>Returns an interface to a JavaScript object that can be used by scripts. The <paramref name="interface"/> must be a valid property of the JavaScript <c>window</c>. The callback must accept a single <see cref="Godot.Collections.Array"/> argument, which will contain the JavaScript <c>arguments</c>. See <see cref="Godot.JavaScriptObject"/> for usage.</para>
    /// </summary>
    public JavaScriptObject GetInterface(string @interface)
    {
        return (JavaScriptObject)NativeCalls.godot_icall_1_533(MethodBind1, GodotObject.GetPtr(this), @interface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateCallback, 422818440ul);

    /// <summary>
    /// <para>Creates a reference to a <see cref="Godot.Callable"/> that can be used as a callback by JavaScript. The reference must be kept until the callback happens, or it won't be called at all. See <see cref="Godot.JavaScriptObject"/> for usage.</para>
    /// <para><b>Note:</b> The callback function must take exactly one <see cref="Godot.Collections.Array"/> argument, which is going to be the JavaScript <a href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Functions/arguments">arguments object</a> converted to an array.</para>
    /// </summary>
    public JavaScriptObject CreateCallback(Callable callable)
    {
        return (JavaScriptObject)NativeCalls.godot_icall_1_781(MethodBind2, GodotObject.GetPtr(this), callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsJsBuffer, 821968997ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="javascriptObject"/> is of type <a href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer"><c>ArrayBuffer</c></a>, <a href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/DataView"><c>DataView</c></a>, or one of the many <a href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray">typed array objects</a>.</para>
    /// </summary>
    public bool IsJsBuffer(JavaScriptObject javascriptObject)
    {
        return NativeCalls.godot_icall_1_176(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(javascriptObject)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JsBufferToPackedByteArray, 64409880ul);

    /// <summary>
    /// <para>Returns a copy of <paramref name="javascriptBuffer"/>'s contents as a <see cref="byte"/>[]. See also <see cref="Godot.JavaScriptBridgeInstance.IsJsBuffer(JavaScriptObject)"/>.</para>
    /// </summary>
    public byte[] JsBufferToPackedByteArray(JavaScriptObject javascriptBuffer)
    {
        return NativeCalls.godot_icall_1_636(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(javascriptBuffer));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateObject, 3093893586ul);

    /// <summary>
    /// <para>Creates a new JavaScript object using the <c>new</c> constructor. The <paramref name="object"/> must a valid property of the JavaScript <c>window</c>. See <see cref="Godot.JavaScriptObject"/> for usage.</para>
    /// </summary>
    public Variant CreateObject(string @object, params Variant[] @args)
    {
        return NativeCalls.godot_icall_2_782(MethodBind5, GodotObject.GetPtr(this), @object, @args, (godot_string_name)MethodName.CreateObject.NativeValue);
    }

    /// <summary>
    /// <para>Creates a new JavaScript object using the <c>new</c> constructor. The <paramref name="object"/> must a valid property of the JavaScript <c>window</c>. See <see cref="Godot.JavaScriptObject"/> for usage.</para>
    /// </summary>
    public Variant CreateObject(string @object, ReadOnlySpan<Variant> @args)
    {
        return NativeCalls.godot_icall_2_782(MethodBind5, GodotObject.GetPtr(this), @object, @args, (godot_string_name)MethodName.CreateObject.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DownloadBuffer, 3352272093ul);

    /// <summary>
    /// <para>Prompts the user to download a file containing the specified <paramref name="buffer"/>. The file will have the given <paramref name="name"/> and <paramref name="mime"/> type.</para>
    /// <para><b>Note:</b> The browser may override the <a href="https://en.wikipedia.org/wiki/Media_type">MIME type</a> provided based on the file <paramref name="name"/>'s extension.</para>
    /// <para><b>Note:</b> Browsers might block the download if <see cref="Godot.JavaScriptBridgeInstance.DownloadBuffer(byte[], string, string)"/> is not being called from a user interaction (e.g. button click).</para>
    /// <para><b>Note:</b> Browsers might ask the user for permission or block the download if multiple download requests are made in a quick succession.</para>
    /// </summary>
    public void DownloadBuffer(byte[] buffer, string name, string mime = "application/octet-stream")
    {
        NativeCalls.godot_icall_3_783(MethodBind6, GodotObject.GetPtr(this), buffer, name, mime);
    }

    /// <summary>
    /// <para>Prompts the user to download a file containing the specified <paramref name="buffer"/>. The file will have the given <paramref name="name"/> and <paramref name="mime"/> type.</para>
    /// <para><b>Note:</b> The browser may override the <a href="https://en.wikipedia.org/wiki/Media_type">MIME type</a> provided based on the file <paramref name="name"/>'s extension.</para>
    /// <para><b>Note:</b> Browsers might block the download if <see cref="Godot.JavaScriptBridgeInstance.DownloadBuffer(byte[], string, string)"/> is not being called from a user interaction (e.g. button click).</para>
    /// <para><b>Note:</b> Browsers might ask the user for permission or block the download if multiple download requests are made in a quick succession.</para>
    /// </summary>
    public void DownloadBuffer(ReadOnlySpan<byte> buffer, string name, string mime)
    {
        NativeCalls.godot_icall_3_783(MethodBind6, GodotObject.GetPtr(this), buffer, name, mime);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PwaNeedsUpdate, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a new version of the progressive web app is waiting to be activated.</para>
    /// <para><b>Note:</b> Only relevant when exported as a Progressive Web App.</para>
    /// </summary>
    public bool PwaNeedsUpdate()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PwaUpdate, 166280745ul);

    /// <summary>
    /// <para>Performs the live update of the progressive web app. Forcing the new version to be installed and the page to be reloaded.</para>
    /// <para><b>Note:</b> Your application will be <b>reloaded in all browser tabs</b>.</para>
    /// <para><b>Note:</b> Only relevant when exported as a Progressive Web App and <see cref="Godot.JavaScriptBridgeInstance.PwaNeedsUpdate()"/> returns <see langword="true"/>.</para>
    /// </summary>
    public Error PwaUpdate()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceFsSync, 3218959716ul);

    /// <summary>
    /// <para>Force synchronization of the persistent file system (when enabled).</para>
    /// <para><b>Note:</b> This is only useful for modules or extensions that can't use <see cref="Godot.FileAccess"/> to write files.</para>
    /// </summary>
    public void ForceFsSync()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when an update for this progressive web app has been detected but is waiting to be activated because a previous version is active. See <see cref="Godot.JavaScriptBridgeInstance.PwaUpdate()"/> to force the update to take place immediately.</para>
    /// </summary>
    public event Action PwaUpdateAvailable
    {
        add => Connect(SignalName.PwaUpdateAvailable, Callable.From(value));
        remove => Disconnect(SignalName.PwaUpdateAvailable, Callable.From(value));
    }

    protected void EmitSignalPwaUpdateAvailable()
    {
        EmitSignal(SignalName.PwaUpdateAvailable);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_pwa_update_available = "PwaUpdateAvailable";

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
        if (signal == SignalName.PwaUpdateAvailable)
        {
            if (HasGodotClassSignal(SignalProxyName_pwa_update_available.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the 'eval' method.
        /// </summary>
        public static readonly StringName Eval = "eval";
        /// <summary>
        /// Cached name for the 'get_interface' method.
        /// </summary>
        public static readonly StringName GetInterface = "get_interface";
        /// <summary>
        /// Cached name for the 'create_callback' method.
        /// </summary>
        public static readonly StringName CreateCallback = "create_callback";
        /// <summary>
        /// Cached name for the 'is_js_buffer' method.
        /// </summary>
        public static readonly StringName IsJsBuffer = "is_js_buffer";
        /// <summary>
        /// Cached name for the 'js_buffer_to_packed_byte_array' method.
        /// </summary>
        public static readonly StringName JsBufferToPackedByteArray = "js_buffer_to_packed_byte_array";
        /// <summary>
        /// Cached name for the 'create_object' method.
        /// </summary>
        public static readonly StringName CreateObject = "create_object";
        /// <summary>
        /// Cached name for the 'download_buffer' method.
        /// </summary>
        public static readonly StringName DownloadBuffer = "download_buffer";
        /// <summary>
        /// Cached name for the 'pwa_needs_update' method.
        /// </summary>
        public static readonly StringName PwaNeedsUpdate = "pwa_needs_update";
        /// <summary>
        /// Cached name for the 'pwa_update' method.
        /// </summary>
        public static readonly StringName PwaUpdate = "pwa_update";
        /// <summary>
        /// Cached name for the 'force_fs_sync' method.
        /// </summary>
        public static readonly StringName ForceFsSync = "force_fs_sync";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
        /// <summary>
        /// Cached name for the 'pwa_update_available' signal.
        /// </summary>
        public static readonly StringName PwaUpdateAvailable = "pwa_update_available";
    }
}
