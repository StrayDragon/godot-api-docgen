namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A node with the ability to send HTTP requests. Uses <see cref="Godot.HttpClient"/> internally.</para>
/// <para>Can be used to make HTTP requests, i.e. download or upload files or web content via HTTP.</para>
/// <para><b>Warning:</b> See the notes and warnings on <see cref="Godot.HttpClient"/> for limitations, especially regarding TLS security.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// <para><b>Example:</b> Contact a REST API and print one of its returned fields:</para>
/// <para><code>
/// public override void _Ready()
/// {
/// 	// Create an HTTP request node and connect its completion signal.
/// 	var httpRequest = new HttpRequest();
/// 	AddChild(httpRequest);
/// 	httpRequest.RequestCompleted += HttpRequestCompleted;
/// 
/// 	// Perform a GET request. The URL below returns JSON as of writing.
/// 	Error error = httpRequest.Request("https://httpbin.org/get");
/// 	if (error != Error.Ok)
/// 	{
/// 		GD.PushError("An error occurred in the HTTP request.");
/// 	}
/// 
/// 	// Perform a POST request. The URL below returns JSON as of writing.
/// 	// Note: Don't make simultaneous requests using a single HTTPRequest node.
/// 	// The snippet below is provided for reference only.
/// 	string body = new Json().Stringify(new Godot.Collections.Dictionary
/// 	{
/// 		{ "name", "Godette" }
/// 	});
/// 	error = httpRequest.Request("https://httpbin.org/post", null, HttpClient.Method.Post, body);
/// 	if (error != Error.Ok)
/// 	{
/// 		GD.PushError("An error occurred in the HTTP request.");
/// 	}
/// }
/// 
/// // Called when the HTTP request is completed.
/// private void HttpRequestCompleted(long result, long responseCode, string[] headers, byte[] body)
/// {
/// 	var json = new Json();
/// 	json.Parse(body.GetStringFromUtf8());
/// 	var response = json.GetData().AsGodotDictionary();
/// 
/// 	// Will print the user agent string used by the HTTPRequest node (as recognized by httpbin.org).
/// 	GD.Print((response["headers"].AsGodotDictionary())["User-Agent"]);
/// }
/// </code></para>
/// <para><b>Example:</b> Load an image using <see cref="Godot.HttpRequest"/> and display it:</para>
/// <para><code>
/// public override void _Ready()
/// {
/// 	// Create an HTTP request node and connect its completion signal.
/// 	var httpRequest = new HttpRequest();
/// 	AddChild(httpRequest);
/// 	httpRequest.RequestCompleted += HttpRequestCompleted;
/// 
/// 	// Perform the HTTP request. The URL below returns a PNG image as of writing.
/// 	Error error = httpRequest.Request("https://placehold.co/512.png");
/// 	if (error != Error.Ok)
/// 	{
/// 		GD.PushError("An error occurred in the HTTP request.");
/// 	}
/// }
/// 
/// // Called when the HTTP request is completed.
/// private void HttpRequestCompleted(long result, long responseCode, string[] headers, byte[] body)
/// {
/// 	if (result != (long)HttpRequest.Result.Success)
/// 	{
/// 		GD.PushError("Image couldn't be downloaded. Try a different image.");
/// 	}
/// 	var image = new Image();
/// 	Error error = image.LoadPngFromBuffer(body);
/// 	if (error != Error.Ok)
/// 	{
/// 		GD.PushError("Couldn't load the image.");
/// 	}
/// 
/// 	var texture = ImageTexture.CreateFromImage(image);
/// 
/// 	// Display the image in a TextureRect node.
/// 	var textureRect = new TextureRect();
/// 	AddChild(textureRect);
/// 	textureRect.Texture = texture;
/// }
/// </code></para>
/// <para><b>Note:</b> <see cref="Godot.HttpRequest"/> nodes will automatically handle decompression of response bodies. An <c>Accept-Encoding</c> header will be automatically added to each of your requests, unless one is already specified. Any response with a <c>Content-Encoding: gzip</c> header will automatically be decompressed and delivered to you as uncompressed bytes.</para>
/// </summary>
[GodotClassName("HTTPRequest")]
public partial class HttpRequest : Node
{
    public enum Result : long
    {
        /// <summary>
        /// <para>Request successful.</para>
        /// </summary>
        Success = 0,
        /// <summary>
        /// <para>Request failed due to a mismatch between the expected and actual chunked body size during transfer. Possible causes include network errors, server misconfiguration, or issues with chunked encoding.</para>
        /// </summary>
        ChunkedBodySizeMismatch = 1,
        /// <summary>
        /// <para>Request failed while connecting.</para>
        /// </summary>
        CantConnect = 2,
        /// <summary>
        /// <para>Request failed while resolving.</para>
        /// </summary>
        CantResolve = 3,
        /// <summary>
        /// <para>Request failed due to connection (read/write) error.</para>
        /// </summary>
        ConnectionError = 4,
        /// <summary>
        /// <para>Request failed on TLS handshake.</para>
        /// </summary>
        TlsHandshakeError = 5,
        /// <summary>
        /// <para>Request does not have a response (yet).</para>
        /// </summary>
        NoResponse = 6,
        /// <summary>
        /// <para>Request exceeded its maximum size limit, see <see cref="Godot.HttpRequest.BodySizeLimit"/>.</para>
        /// </summary>
        BodySizeLimitExceeded = 7,
        /// <summary>
        /// <para>Request failed due to an error while decompressing the response body. Possible causes include unsupported or incorrect compression format, corrupted data, or incomplete transfer.</para>
        /// </summary>
        BodyDecompressFailed = 8,
        /// <summary>
        /// <para>Request failed (currently unused).</para>
        /// </summary>
        RequestFailed = 9,
        /// <summary>
        /// <para>HTTPRequest couldn't open the download file.</para>
        /// </summary>
        DownloadFileCantOpen = 10,
        /// <summary>
        /// <para>HTTPRequest couldn't write to the download file.</para>
        /// </summary>
        DownloadFileWriteError = 11,
        /// <summary>
        /// <para>Request reached its maximum redirect limit, see <see cref="Godot.HttpRequest.MaxRedirects"/>.</para>
        /// </summary>
        RedirectLimitReached = 12,
        /// <summary>
        /// <para>Request failed due to a timeout. If you expect requests to take a long time, try increasing the value of <see cref="Godot.HttpRequest.Timeout"/> or setting it to <c>0.0</c> to remove the timeout completely.</para>
        /// </summary>
        Timeout = 13
    }

    /// <summary>
    /// <para>The file to download into. Will output any received file into it.</para>
    /// </summary>
    public string DownloadFile
    {
        get
        {
            return GetDownloadFile();
        }
        set
        {
            SetDownloadFile(value);
        }
    }

    /// <summary>
    /// <para>The size of the buffer used and maximum bytes to read per iteration. See <see cref="Godot.HttpClient.ReadChunkSize"/>.</para>
    /// <para>Set this to a lower value (e.g. 4096 for 4 KiB) when downloading small files to decrease memory usage at the cost of download speeds.</para>
    /// </summary>
    public int DownloadChunkSize
    {
        get
        {
            return GetDownloadChunkSize();
        }
        set
        {
            SetDownloadChunkSize(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, multithreading is used to improve performance.</para>
    /// </summary>
    public bool UseThreads
    {
        get
        {
            return IsUsingThreads();
        }
        set
        {
            SetUseThreads(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this header will be added to each request: <c>Accept-Encoding: gzip, deflate</c> telling servers that it's okay to compress response bodies.</para>
    /// <para>Any Response body declaring a <c>Content-Encoding</c> of either <c>gzip</c> or <c>deflate</c> will then be automatically decompressed, and the uncompressed bytes will be delivered via <see cref="Godot.HttpRequest.RequestCompleted"/>.</para>
    /// <para>If the user has specified their own <c>Accept-Encoding</c> header, then no header will be added regardless of <see cref="Godot.HttpRequest.AcceptGZip"/>.</para>
    /// <para>If <see langword="false"/> no header will be added, and no decompression will be performed on response bodies. The raw bytes of the response body will be returned via <see cref="Godot.HttpRequest.RequestCompleted"/>.</para>
    /// </summary>
    public bool AcceptGZip
    {
        get
        {
            return IsAcceptingGZip();
        }
        set
        {
            SetAcceptGZip(value);
        }
    }

    /// <summary>
    /// <para>Maximum allowed size for response bodies. If the response body is compressed, this will be used as the maximum allowed size for the decompressed body.</para>
    /// </summary>
    public int BodySizeLimit
    {
        get
        {
            return GetBodySizeLimit();
        }
        set
        {
            SetBodySizeLimit(value);
        }
    }

    /// <summary>
    /// <para>Maximum number of allowed redirects.</para>
    /// </summary>
    public int MaxRedirects
    {
        get
        {
            return GetMaxRedirects();
        }
        set
        {
            SetMaxRedirects(value);
        }
    }

    /// <summary>
    /// <para>The duration to wait before a request times out, in seconds (independent of <see cref="Godot.Engine.TimeScale"/>). If <see cref="Godot.HttpRequest.Timeout"/> is set to <c>0.0</c>, the request will never time out.</para>
    /// <para>For simple requests, such as communication with a REST API, it is recommended to set <see cref="Godot.HttpRequest.Timeout"/> to a value suitable for the server response time (commonly between <c>1.0</c> and <c>10.0</c>). This will help prevent unwanted timeouts caused by variation in response times while still allowing the application to detect when a request has timed out. For larger requests such as file downloads, it is recommended to set <see cref="Godot.HttpRequest.Timeout"/> to <c>0.0</c>, disabling the timeout functionality. This will help prevent large transfers from failing due to exceeding the timeout value.</para>
    /// </summary>
    public double Timeout
    {
        get
        {
            return GetTimeout();
        }
        set
        {
            SetTimeout(value);
        }
    }

    private static readonly System.Type CachedType = typeof(HttpRequest);

    private static readonly StringName NativeName = "HTTPRequest";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public HttpRequest() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal HttpRequest(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal HttpRequest(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Request, 3215244323ul);

    /// <summary>
    /// <para>Creates request on the underlying <see cref="Godot.HttpClient"/>. If there is no configuration errors, it tries to connect using <see cref="Godot.HttpClient.ConnectToHost(string, int, TlsOptions)"/> and passes parameters onto <see cref="Godot.HttpClient.Request(HttpClient.Method, string, string[], string)"/>.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> if request is successfully created. (Does not imply that the server has responded), <see cref="Godot.Error.Unconfigured"/> if not in the tree, <see cref="Godot.Error.Busy"/> if still processing previous request, <see cref="Godot.Error.InvalidParameter"/> if given string is not a valid URL format, or <see cref="Godot.Error.CantConnect"/> if not using thread and the <see cref="Godot.HttpClient"/> cannot connect to host.</para>
    /// <para><b>Note:</b> When <paramref name="method"/> is <see cref="Godot.HttpClient.Method.Get"/>, the payload sent via <paramref name="requestData"/> might be ignored by the server or even cause the server to reject the request (check <a href="https://datatracker.ietf.org/doc/html/rfc7231#section-4.3.1">RFC 7231 section 4.3.1</a> for more details). As a workaround, you can send data as a query string in the URL (see <c>String.uri_encode</c> for an example).</para>
    /// <para><b>Note:</b> It's recommended to use transport encryption (TLS) and to avoid sending sensitive information (such as login credentials) in HTTP GET URL parameters. Consider using HTTP POST requests or HTTP headers for such information instead.</para>
    /// </summary>
    /// <param name="customHeaders">If the parameter is null, then the default value is <c>Array.Empty&lt;string&gt;()</c>.</param>
    public Error Request(string url, string[] customHeaders = null, HttpClient.Method method = (HttpClient.Method)(0), string requestData = "")
    {
        string[] customHeadersOrDefVal = customHeaders != null ? customHeaders : Array.Empty<string>();
        return (Error)NativeCalls.godot_icall_4_718(MethodBind0, GodotObject.GetPtr(this), url, customHeadersOrDefVal, (int)method, requestData);
    }

    /// <summary>
    /// <para>Creates request on the underlying <see cref="Godot.HttpClient"/>. If there is no configuration errors, it tries to connect using <see cref="Godot.HttpClient.ConnectToHost(string, int, TlsOptions)"/> and passes parameters onto <see cref="Godot.HttpClient.Request(HttpClient.Method, string, string[], string)"/>.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> if request is successfully created. (Does not imply that the server has responded), <see cref="Godot.Error.Unconfigured"/> if not in the tree, <see cref="Godot.Error.Busy"/> if still processing previous request, <see cref="Godot.Error.InvalidParameter"/> if given string is not a valid URL format, or <see cref="Godot.Error.CantConnect"/> if not using thread and the <see cref="Godot.HttpClient"/> cannot connect to host.</para>
    /// <para><b>Note:</b> When <paramref name="method"/> is <see cref="Godot.HttpClient.Method.Get"/>, the payload sent via <paramref name="requestData"/> might be ignored by the server or even cause the server to reject the request (check <a href="https://datatracker.ietf.org/doc/html/rfc7231#section-4.3.1">RFC 7231 section 4.3.1</a> for more details). As a workaround, you can send data as a query string in the URL (see <c>String.uri_encode</c> for an example).</para>
    /// <para><b>Note:</b> It's recommended to use transport encryption (TLS) and to avoid sending sensitive information (such as login credentials) in HTTP GET URL parameters. Consider using HTTP POST requests or HTTP headers for such information instead.</para>
    /// </summary>
    public Error Request(string url, ReadOnlySpan<string> customHeaders, HttpClient.Method method, string requestData)
    {
        return (Error)NativeCalls.godot_icall_4_718(MethodBind0, GodotObject.GetPtr(this), url, customHeaders, (int)method, requestData);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestRaw, 2714829993ul);

    /// <summary>
    /// <para>Creates request on the underlying <see cref="Godot.HttpClient"/> using a raw array of bytes for the request body. If there is no configuration errors, it tries to connect using <see cref="Godot.HttpClient.ConnectToHost(string, int, TlsOptions)"/> and passes parameters onto <see cref="Godot.HttpClient.Request(HttpClient.Method, string, string[], string)"/>.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> if request is successfully created. (Does not imply that the server has responded), <see cref="Godot.Error.Unconfigured"/> if not in the tree, <see cref="Godot.Error.Busy"/> if still processing previous request, <see cref="Godot.Error.InvalidParameter"/> if given string is not a valid URL format, or <see cref="Godot.Error.CantConnect"/> if not using thread and the <see cref="Godot.HttpClient"/> cannot connect to host.</para>
    /// </summary>
    /// <param name="customHeaders">If the parameter is null, then the default value is <c>Array.Empty&lt;string&gt;()</c>.</param>
    /// <param name="requestDataRaw">If the parameter is null, then the default value is <c>Array.Empty&lt;byte&gt;()</c>.</param>
    public Error RequestRaw(string url, string[] customHeaders = null, HttpClient.Method method = (HttpClient.Method)(0), byte[] requestDataRaw = null)
    {
        string[] customHeadersOrDefVal = customHeaders != null ? customHeaders : Array.Empty<string>();
        byte[] requestDataRawOrDefVal = requestDataRaw != null ? requestDataRaw : Array.Empty<byte>();
        return (Error)NativeCalls.godot_icall_4_719(MethodBind1, GodotObject.GetPtr(this), url, customHeadersOrDefVal, (int)method, requestDataRawOrDefVal);
    }

    /// <summary>
    /// <para>Creates request on the underlying <see cref="Godot.HttpClient"/> using a raw array of bytes for the request body. If there is no configuration errors, it tries to connect using <see cref="Godot.HttpClient.ConnectToHost(string, int, TlsOptions)"/> and passes parameters onto <see cref="Godot.HttpClient.Request(HttpClient.Method, string, string[], string)"/>.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> if request is successfully created. (Does not imply that the server has responded), <see cref="Godot.Error.Unconfigured"/> if not in the tree, <see cref="Godot.Error.Busy"/> if still processing previous request, <see cref="Godot.Error.InvalidParameter"/> if given string is not a valid URL format, or <see cref="Godot.Error.CantConnect"/> if not using thread and the <see cref="Godot.HttpClient"/> cannot connect to host.</para>
    /// </summary>
    public Error RequestRaw(string url, ReadOnlySpan<string> customHeaders, HttpClient.Method method, ReadOnlySpan<byte> requestDataRaw)
    {
        return (Error)NativeCalls.godot_icall_4_719(MethodBind1, GodotObject.GetPtr(this), url, customHeaders, (int)method, requestDataRaw);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CancelRequest, 3218959716ul);

    /// <summary>
    /// <para>Cancels the current request.</para>
    /// </summary>
    public void CancelRequest()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTlsOptions, 2210231844ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.TlsOptions"/> to be used when connecting to an HTTPS server. See <see cref="Godot.TlsOptions.Client(X509Certificate, string)"/>.</para>
    /// </summary>
    public void SetTlsOptions(TlsOptions clientOptions)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(clientOptions));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHttpClientStatus, 1426656811ul);

    /// <summary>
    /// <para>Returns the current status of the underlying <see cref="Godot.HttpClient"/>.</para>
    /// </summary>
    public HttpClient.Status GetHttpClientStatus()
    {
        return (HttpClient.Status)NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseThreads, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseThreads(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingThreads, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingThreads()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAcceptGZip, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAcceptGZip(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAcceptingGZip, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAcceptingGZip()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBodySizeLimit, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBodySizeLimit(int bytes)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), bytes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBodySizeLimit, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBodySizeLimit()
    {
        return NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxRedirects, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxRedirects(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxRedirects, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxRedirects()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDownloadFile, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDownloadFile(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind13, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDownloadFile, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetDownloadFile()
    {
        return NativeCalls.godot_icall_0_58(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDownloadedBytes, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of bytes this HTTPRequest downloaded.</para>
    /// </summary>
    public int GetDownloadedBytes()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBodySize, 3905245786ul);

    /// <summary>
    /// <para>Returns the response body length.</para>
    /// <para><b>Note:</b> Some Web servers may not send a body length. In this case, the value returned will be <c>-1</c>. If using chunked transfer encoding, the body length will also be <c>-1</c>.</para>
    /// </summary>
    public int GetBodySize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTimeout, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTimeout(double timeout)
    {
        NativeCalls.godot_icall_1_127(MethodBind17, GodotObject.GetPtr(this), timeout);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeout, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetTimeout()
    {
        return NativeCalls.godot_icall_0_144(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDownloadChunkSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDownloadChunkSize(int chunkSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), chunkSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDownloadChunkSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDownloadChunkSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHttpProxy, 2956805083ul);

    /// <summary>
    /// <para>Sets the proxy server for HTTP requests.</para>
    /// <para>The proxy server is unset if <paramref name="host"/> is empty or <paramref name="port"/> is -1.</para>
    /// </summary>
    public void SetHttpProxy(string host, int port)
    {
        NativeCalls.godot_icall_2_400(MethodBind21, GodotObject.GetPtr(this), host, port);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHttpsProxy, 2956805083ul);

    /// <summary>
    /// <para>Sets the proxy server for HTTPS requests.</para>
    /// <para>The proxy server is unset if <paramref name="host"/> is empty or <paramref name="port"/> is -1.</para>
    /// </summary>
    public void SetHttpsProxy(string host, int port)
    {
        NativeCalls.godot_icall_2_400(MethodBind22, GodotObject.GetPtr(this), host, port);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.HttpRequest.RequestCompleted"/> event of a <see cref="Godot.HttpRequest"/> class.
    /// </summary>
    public delegate void RequestCompletedEventHandler(long result, long responseCode, string[] headers, byte[] body);

    private static void RequestCompletedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 4);
        ((RequestCompletedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<string[]>(args[2]), VariantUtils.ConvertTo<byte[]>(args[3]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a request is completed.</para>
    /// </summary>
    public unsafe event RequestCompletedEventHandler RequestCompleted
    {
        add => Connect(SignalName.RequestCompleted, Callable.CreateWithUnsafeTrampoline(value, &RequestCompletedTrampoline));
        remove => Disconnect(SignalName.RequestCompleted, Callable.CreateWithUnsafeTrampoline(value, &RequestCompletedTrampoline));
    }

    protected void EmitSignalRequestCompleted(long result, long responseCode, string[] headers, byte[] body)
    {
        EmitSignal(SignalName.RequestCompleted, result, responseCode, headers, body);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_request_completed = "RequestCompleted";

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
        if (signal == SignalName.RequestCompleted)
        {
            if (HasGodotClassSignal(SignalProxyName_request_completed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node.PropertyName
    {
        /// <summary>
        /// Cached name for the 'download_file' property.
        /// </summary>
        public static readonly StringName DownloadFile = "download_file";
        /// <summary>
        /// Cached name for the 'download_chunk_size' property.
        /// </summary>
        public static readonly StringName DownloadChunkSize = "download_chunk_size";
        /// <summary>
        /// Cached name for the 'use_threads' property.
        /// </summary>
        public static readonly StringName UseThreads = "use_threads";
        /// <summary>
        /// Cached name for the 'accept_gzip' property.
        /// </summary>
        public static readonly StringName AcceptGZip = "accept_gzip";
        /// <summary>
        /// Cached name for the 'body_size_limit' property.
        /// </summary>
        public static readonly StringName BodySizeLimit = "body_size_limit";
        /// <summary>
        /// Cached name for the 'max_redirects' property.
        /// </summary>
        public static readonly StringName MaxRedirects = "max_redirects";
        /// <summary>
        /// Cached name for the 'timeout' property.
        /// </summary>
        public static readonly StringName Timeout = "timeout";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'request' method.
        /// </summary>
        public static readonly StringName Request = "request";
        /// <summary>
        /// Cached name for the 'request_raw' method.
        /// </summary>
        public static readonly StringName RequestRaw = "request_raw";
        /// <summary>
        /// Cached name for the 'cancel_request' method.
        /// </summary>
        public static readonly StringName CancelRequest = "cancel_request";
        /// <summary>
        /// Cached name for the 'set_tls_options' method.
        /// </summary>
        public static readonly StringName SetTlsOptions = "set_tls_options";
        /// <summary>
        /// Cached name for the 'get_http_client_status' method.
        /// </summary>
        public static readonly StringName GetHttpClientStatus = "get_http_client_status";
        /// <summary>
        /// Cached name for the 'set_use_threads' method.
        /// </summary>
        public static readonly StringName SetUseThreads = "set_use_threads";
        /// <summary>
        /// Cached name for the 'is_using_threads' method.
        /// </summary>
        public static readonly StringName IsUsingThreads = "is_using_threads";
        /// <summary>
        /// Cached name for the 'set_accept_gzip' method.
        /// </summary>
        public static readonly StringName SetAcceptGZip = "set_accept_gzip";
        /// <summary>
        /// Cached name for the 'is_accepting_gzip' method.
        /// </summary>
        public static readonly StringName IsAcceptingGZip = "is_accepting_gzip";
        /// <summary>
        /// Cached name for the 'set_body_size_limit' method.
        /// </summary>
        public static readonly StringName SetBodySizeLimit = "set_body_size_limit";
        /// <summary>
        /// Cached name for the 'get_body_size_limit' method.
        /// </summary>
        public static readonly StringName GetBodySizeLimit = "get_body_size_limit";
        /// <summary>
        /// Cached name for the 'set_max_redirects' method.
        /// </summary>
        public static readonly StringName SetMaxRedirects = "set_max_redirects";
        /// <summary>
        /// Cached name for the 'get_max_redirects' method.
        /// </summary>
        public static readonly StringName GetMaxRedirects = "get_max_redirects";
        /// <summary>
        /// Cached name for the 'set_download_file' method.
        /// </summary>
        public static readonly StringName SetDownloadFile = "set_download_file";
        /// <summary>
        /// Cached name for the 'get_download_file' method.
        /// </summary>
        public static readonly StringName GetDownloadFile = "get_download_file";
        /// <summary>
        /// Cached name for the 'get_downloaded_bytes' method.
        /// </summary>
        public static readonly StringName GetDownloadedBytes = "get_downloaded_bytes";
        /// <summary>
        /// Cached name for the 'get_body_size' method.
        /// </summary>
        public static readonly StringName GetBodySize = "get_body_size";
        /// <summary>
        /// Cached name for the 'set_timeout' method.
        /// </summary>
        public static readonly StringName SetTimeout = "set_timeout";
        /// <summary>
        /// Cached name for the 'get_timeout' method.
        /// </summary>
        public static readonly StringName GetTimeout = "get_timeout";
        /// <summary>
        /// Cached name for the 'set_download_chunk_size' method.
        /// </summary>
        public static readonly StringName SetDownloadChunkSize = "set_download_chunk_size";
        /// <summary>
        /// Cached name for the 'get_download_chunk_size' method.
        /// </summary>
        public static readonly StringName GetDownloadChunkSize = "get_download_chunk_size";
        /// <summary>
        /// Cached name for the 'set_http_proxy' method.
        /// </summary>
        public static readonly StringName SetHttpProxy = "set_http_proxy";
        /// <summary>
        /// Cached name for the 'set_https_proxy' method.
        /// </summary>
        public static readonly StringName SetHttpsProxy = "set_https_proxy";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'request_completed' signal.
        /// </summary>
        public static readonly StringName RequestCompleted = "request_completed";
    }
}
