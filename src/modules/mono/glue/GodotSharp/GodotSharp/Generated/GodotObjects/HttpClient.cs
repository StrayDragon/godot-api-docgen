namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Hyper-text transfer protocol client (sometimes called "User Agent"). Used to make HTTP requests to download web content, upload files and other data or to communicate with various services, among other use cases.</para>
/// <para>See the <see cref="Godot.HttpRequest"/> node for a higher-level alternative.</para>
/// <para><b>Note:</b> This client only needs to connect to a host once (see <see cref="Godot.HttpClient.ConnectToHost(string, int, TlsOptions)"/>) to send multiple requests. Because of this, methods that take URLs usually take just the part after the host instead of the full URL, as the client is already connected to a host. See <see cref="Godot.HttpClient.Request(HttpClient.Method, string, string[], string)"/> for a full example and to get started.</para>
/// <para>An <see cref="Godot.HttpClient"/> should be reused between multiple requests or to connect to different hosts instead of creating one client per request. Supports Transport Layer Security (TLS), including server certificate verification. HTTP status codes in the 2xx range indicate success, 3xx redirection (i.e. "try again, but over here"), 4xx something was wrong with the request, and 5xx something went wrong on the server's side.</para>
/// <para>For more information on HTTP, see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP">MDN's documentation on HTTP</a> (or read <a href="https://tools.ietf.org/html/rfc2616">RFC 2616</a> to get it straight from the source).</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// <para><b>Note:</b> It's recommended to use transport encryption (TLS) and to avoid sending sensitive information (such as login credentials) in HTTP GET URL parameters. Consider using HTTP POST requests or HTTP headers for such information instead.</para>
/// <para><b>Note:</b> When performing HTTP requests from a project exported to Web, keep in mind the remote server may not allow requests from foreign origins due to <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS">CORS</a>. If you host the server in question, you should modify its backend to allow requests from foreign origins by adding the <c>Access-Control-Allow-Origin: *</c> HTTP header.</para>
/// <para><b>Note:</b> TLS support is currently limited to TLSv1.2 and TLSv1.3. Attempting to connect to a server that only supports older (insecure) TLS versions will return an error.</para>
/// <para><b>Warning:</b> TLS certificate revocation and certificate pinning are currently not supported. Revoked certificates are accepted as long as they are otherwise valid. If this is a concern, you may want to use automatically managed certificates with a short validity period.</para>
/// </summary>
[GodotClassName("HTTPClient")]
public partial class HttpClient : RefCounted
{
    public enum Method : long
    {
        /// <summary>
        /// <para>HTTP GET method. The GET method requests a representation of the specified resource. Requests using GET should only retrieve data.</para>
        /// </summary>
        Get = 0,
        /// <summary>
        /// <para>HTTP HEAD method. The HEAD method asks for a response identical to that of a GET request, but without the response body. This is useful to request metadata like HTTP headers or to check if a resource exists.</para>
        /// </summary>
        Head = 1,
        /// <summary>
        /// <para>HTTP POST method. The POST method is used to submit an entity to the specified resource, often causing a change in state or side effects on the server. This is often used for forms and submitting data or uploading files.</para>
        /// </summary>
        Post = 2,
        /// <summary>
        /// <para>HTTP PUT method. The PUT method asks to replace all current representations of the target resource with the request payload. (You can think of POST as "create or update" and PUT as "update", although many services tend to not make a clear distinction or change their meaning).</para>
        /// </summary>
        Put = 3,
        /// <summary>
        /// <para>HTTP DELETE method. The DELETE method requests to delete the specified resource.</para>
        /// </summary>
        Delete = 4,
        /// <summary>
        /// <para>HTTP OPTIONS method. The OPTIONS method asks for a description of the communication options for the target resource. Rarely used.</para>
        /// </summary>
        Options = 5,
        /// <summary>
        /// <para>HTTP TRACE method. The TRACE method performs a message loop-back test along the path to the target resource. Returns the entire HTTP request received in the response body. Rarely used.</para>
        /// </summary>
        Trace = 6,
        /// <summary>
        /// <para>HTTP CONNECT method. The CONNECT method establishes a tunnel to the server identified by the target resource. Rarely used.</para>
        /// </summary>
        Connect = 7,
        /// <summary>
        /// <para>HTTP PATCH method. The PATCH method is used to apply partial modifications to a resource.</para>
        /// </summary>
        Patch = 8,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.HttpClient.Method"/> enum.</para>
        /// </summary>
        Max = 9
    }

    public enum Status : long
    {
        /// <summary>
        /// <para>Status: Disconnected from the server.</para>
        /// </summary>
        Disconnected = 0,
        /// <summary>
        /// <para>Status: Currently resolving the hostname for the given URL into an IP.</para>
        /// </summary>
        Resolving = 1,
        /// <summary>
        /// <para>Status: DNS failure: Can't resolve the hostname for the given URL.</para>
        /// </summary>
        CantResolve = 2,
        /// <summary>
        /// <para>Status: Currently connecting to server.</para>
        /// </summary>
        Connecting = 3,
        /// <summary>
        /// <para>Status: Can't connect to the server.</para>
        /// </summary>
        CantConnect = 4,
        /// <summary>
        /// <para>Status: Connection established.</para>
        /// </summary>
        Connected = 5,
        /// <summary>
        /// <para>Status: Currently sending request.</para>
        /// </summary>
        Requesting = 6,
        /// <summary>
        /// <para>Status: HTTP body received.</para>
        /// </summary>
        Body = 7,
        /// <summary>
        /// <para>Status: Error in HTTP connection.</para>
        /// </summary>
        ConnectionError = 8,
        /// <summary>
        /// <para>Status: Error in TLS handshake.</para>
        /// </summary>
        TlsHandshakeError = 9
    }

    public enum ResponseCode : long
    {
        /// <summary>
        /// <para>HTTP status code <c>100 Continue</c>. Interim response that indicates everything so far is OK and that the client should continue with the request (or ignore this status if already finished).</para>
        /// </summary>
        Continue = 100,
        /// <summary>
        /// <para>HTTP status code <c>101 Switching Protocol</c>. Sent in response to an <c>Upgrade</c> request header by the client. Indicates the protocol the server is switching to.</para>
        /// </summary>
        SwitchingProtocols = 101,
        /// <summary>
        /// <para>HTTP status code <c>102 Processing</c> (WebDAV). Indicates that the server has received and is processing the request, but no response is available yet.</para>
        /// </summary>
        Processing = 102,
        /// <summary>
        /// <para>HTTP status code <c>200 OK</c>. The request has succeeded. Default response for successful requests. Meaning varies depending on the request:</para>
        /// <para>- <see cref="Godot.HttpClient.Method.Get"/>: The resource has been fetched and is transmitted in the message body.</para>
        /// <para>- <see cref="Godot.HttpClient.Method.Head"/>: The entity headers are in the message body.</para>
        /// <para>- <see cref="Godot.HttpClient.Method.Post"/>: The resource describing the result of the action is transmitted in the message body.</para>
        /// <para>- <see cref="Godot.HttpClient.Method.Trace"/>: The message body contains the request message as received by the server.</para>
        /// </summary>
        Ok = 200,
        /// <summary>
        /// <para>HTTP status code <c>201 Created</c>. The request has succeeded and a new resource has been created as a result of it. This is typically the response sent after a PUT request.</para>
        /// </summary>
        Created = 201,
        /// <summary>
        /// <para>HTTP status code <c>202 Accepted</c>. The request has been received but not yet acted upon. It is non-committal, meaning that there is no way in HTTP to later send an asynchronous response indicating the outcome of processing the request. It is intended for cases where another process or server handles the request, or for batch processing.</para>
        /// </summary>
        Accepted = 202,
        /// <summary>
        /// <para>HTTP status code <c>203 Non-Authoritative Information</c>. This response code means returned meta-information set is not exact set as available from the origin server, but collected from a local or a third party copy. Except this condition, 200 OK response should be preferred instead of this response.</para>
        /// </summary>
        NonAuthoritativeInformation = 203,
        /// <summary>
        /// <para>HTTP status code <c>204 No Content</c>. There is no content to send for this request, but the headers may be useful. The user-agent may update its cached headers for this resource with the new ones.</para>
        /// </summary>
        NoContent = 204,
        /// <summary>
        /// <para>HTTP status code <c>205 Reset Content</c>. The server has fulfilled the request and desires that the client resets the "document view" that caused the request to be sent to its original state as received from the origin server.</para>
        /// </summary>
        ResetContent = 205,
        /// <summary>
        /// <para>HTTP status code <c>206 Partial Content</c>. This response code is used because of a range header sent by the client to separate download into multiple streams.</para>
        /// </summary>
        PartialContent = 206,
        /// <summary>
        /// <para>HTTP status code <c>207 Multi-Status</c> (WebDAV). A Multi-Status response conveys information about multiple resources in situations where multiple status codes might be appropriate.</para>
        /// </summary>
        MultiStatus = 207,
        /// <summary>
        /// <para>HTTP status code <c>208 Already Reported</c> (WebDAV). Used inside a DAV: propstat response element to avoid enumerating the internal members of multiple bindings to the same collection repeatedly.</para>
        /// </summary>
        AlreadyReported = 208,
        /// <summary>
        /// <para>HTTP status code <c>226 IM Used</c> (WebDAV). The server has fulfilled a GET request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance.</para>
        /// </summary>
        ImUsed = 226,
        /// <summary>
        /// <para>HTTP status code <c>300 Multiple Choice</c>. The request has more than one possible responses and there is no standardized way to choose one of the responses. User-agent or user should choose one of them.</para>
        /// </summary>
        MultipleChoices = 300,
        /// <summary>
        /// <para>HTTP status code <c>301 Moved Permanently</c>. Redirection. This response code means the URI of requested resource has been changed. The new URI is usually included in the response.</para>
        /// </summary>
        MovedPermanently = 301,
        /// <summary>
        /// <para>HTTP status code <c>302 Found</c>. Temporary redirection. This response code means the URI of requested resource has been changed temporarily. New changes in the URI might be made in the future. Therefore, this same URI should be used by the client in future requests.</para>
        /// </summary>
        Found = 302,
        /// <summary>
        /// <para>HTTP status code <c>303 See Other</c>. The server is redirecting the user agent to a different resource, as indicated by a URI in the Location header field, which is intended to provide an indirect response to the original request.</para>
        /// </summary>
        SeeOther = 303,
        /// <summary>
        /// <para>HTTP status code <c>304 Not Modified</c>. A conditional GET or HEAD request has been received and would have resulted in a 200 OK response if it were not for the fact that the condition evaluated to <see langword="false"/>.</para>
        /// </summary>
        NotModified = 304,
        /// <summary>
        /// <para>HTTP status code <c>305 Use Proxy</c>.</para>
        /// </summary>
        [Obsolete("Many clients ignore this response code for security reasons. It is also deprecated by the HTTP standard.")]
        UseProxy = 305,
        /// <summary>
        /// <para>HTTP status code <c>306 Switch Proxy</c>.</para>
        /// </summary>
        [Obsolete("Many clients ignore this response code for security reasons. It is also deprecated by the HTTP standard.")]
        SwitchProxy = 306,
        /// <summary>
        /// <para>HTTP status code <c>307 Temporary Redirect</c>. The target resource resides temporarily under a different URI and the user agent MUST NOT change the request method if it performs an automatic redirection to that URI.</para>
        /// </summary>
        TemporaryRedirect = 307,
        /// <summary>
        /// <para>HTTP status code <c>308 Permanent Redirect</c>. The target resource has been assigned a new permanent URI and any future references to this resource ought to use one of the enclosed URIs.</para>
        /// </summary>
        PermanentRedirect = 308,
        /// <summary>
        /// <para>HTTP status code <c>400 Bad Request</c>. The request was invalid. The server cannot or will not process the request due to something that is perceived to be a client error (e.g., malformed request syntax, invalid request message framing, invalid request contents, or deceptive request routing).</para>
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// <para>HTTP status code <c>401 Unauthorized</c>. Credentials required. The request has not been applied because it lacks valid authentication credentials for the target resource.</para>
        /// </summary>
        Unauthorized = 401,
        /// <summary>
        /// <para>HTTP status code <c>402 Payment Required</c>. This response code is reserved for future use. Initial aim for creating this code was using it for digital payment systems, however this is not currently used.</para>
        /// </summary>
        PaymentRequired = 402,
        /// <summary>
        /// <para>HTTP status code <c>403 Forbidden</c>. The client does not have access rights to the content, i.e. they are unauthorized, so server is rejecting to give proper response. Unlike <c>401</c>, the client's identity is known to the server.</para>
        /// </summary>
        Forbidden = 403,
        /// <summary>
        /// <para>HTTP status code <c>404 Not Found</c>. The server can not find requested resource. Either the URL is not recognized or the endpoint is valid but the resource itself does not exist. May also be sent instead of 403 to hide existence of a resource if the client is not authorized.</para>
        /// </summary>
        NotFound = 404,
        /// <summary>
        /// <para>HTTP status code <c>405 Method Not Allowed</c>. The request's HTTP method is known by the server but has been disabled and cannot be used. For example, an API may forbid DELETE-ing a resource. The two mandatory methods, GET and HEAD, must never be disabled and should not return this error code.</para>
        /// </summary>
        MethodNotAllowed = 405,
        /// <summary>
        /// <para>HTTP status code <c>406 Not Acceptable</c>. The target resource does not have a current representation that would be acceptable to the user agent, according to the proactive negotiation header fields received in the request. Used when negotiation content.</para>
        /// </summary>
        NotAcceptable = 406,
        /// <summary>
        /// <para>HTTP status code <c>407 Proxy Authentication Required</c>. Similar to 401 Unauthorized, but it indicates that the client needs to authenticate itself in order to use a proxy.</para>
        /// </summary>
        ProxyAuthenticationRequired = 407,
        /// <summary>
        /// <para>HTTP status code <c>408 Request Timeout</c>. The server did not receive a complete request message within the time that it was prepared to wait.</para>
        /// </summary>
        RequestTimeout = 408,
        /// <summary>
        /// <para>HTTP status code <c>409 Conflict</c>. The request could not be completed due to a conflict with the current state of the target resource. This code is used in situations where the user might be able to resolve the conflict and resubmit the request.</para>
        /// </summary>
        Conflict = 409,
        /// <summary>
        /// <para>HTTP status code <c>410 Gone</c>. The target resource is no longer available at the origin server and this condition is likely permanent.</para>
        /// </summary>
        Gone = 410,
        /// <summary>
        /// <para>HTTP status code <c>411 Length Required</c>. The server refuses to accept the request without a defined Content-Length header.</para>
        /// </summary>
        LengthRequired = 411,
        /// <summary>
        /// <para>HTTP status code <c>412 Precondition Failed</c>. One or more conditions given in the request header fields evaluated to <see langword="false"/> when tested on the server.</para>
        /// </summary>
        PreconditionFailed = 412,
        /// <summary>
        /// <para>HTTP status code <c>413 Entity Too Large</c>. The server is refusing to process a request because the request payload is larger than the server is willing or able to process.</para>
        /// </summary>
        RequestEntityTooLarge = 413,
        /// <summary>
        /// <para>HTTP status code <c>414 Request-URI Too Long</c>. The server is refusing to service the request because the request-target is longer than the server is willing to interpret.</para>
        /// </summary>
        RequestUriTooLong = 414,
        /// <summary>
        /// <para>HTTP status code <c>415 Unsupported Media Type</c>. The origin server is refusing to service the request because the payload is in a format not supported by this method on the target resource.</para>
        /// </summary>
        UnsupportedMediaType = 415,
        /// <summary>
        /// <para>HTTP status code <c>416 Requested Range Not Satisfiable</c>. None of the ranges in the request's Range header field overlap the current extent of the selected resource or the set of ranges requested has been rejected due to invalid ranges or an excessive request of small or overlapping ranges.</para>
        /// </summary>
        RequestedRangeNotSatisfiable = 416,
        /// <summary>
        /// <para>HTTP status code <c>417 Expectation Failed</c>. The expectation given in the request's Expect header field could not be met by at least one of the inbound servers.</para>
        /// </summary>
        ExpectationFailed = 417,
        /// <summary>
        /// <para>HTTP status code <c>418 I'm A Teapot</c>. Any attempt to brew coffee with a teapot should result in the error code "418 I'm a teapot". The resulting entity body MAY be short and stout.</para>
        /// </summary>
        ImATeapot = 418,
        /// <summary>
        /// <para>HTTP status code <c>421 Misdirected Request</c>. The request was directed at a server that is not able to produce a response. This can be sent by a server that is not configured to produce responses for the combination of scheme and authority that are included in the request URI.</para>
        /// </summary>
        MisdirectedRequest = 421,
        /// <summary>
        /// <para>HTTP status code <c>422 Unprocessable Entity</c> (WebDAV). The server understands the content type of the request entity (hence a 415 Unsupported Media Type status code is inappropriate), and the syntax of the request entity is correct (thus a 400 Bad Request status code is inappropriate) but was unable to process the contained instructions.</para>
        /// </summary>
        UnprocessableEntity = 422,
        /// <summary>
        /// <para>HTTP status code <c>423 Locked</c> (WebDAV). The source or destination resource of a method is locked.</para>
        /// </summary>
        Locked = 423,
        /// <summary>
        /// <para>HTTP status code <c>424 Failed Dependency</c> (WebDAV). The method could not be performed on the resource because the requested action depended on another action and that action failed.</para>
        /// </summary>
        FailedDependency = 424,
        /// <summary>
        /// <para>HTTP status code <c>426 Upgrade Required</c>. The server refuses to perform the request using the current protocol but might be willing to do so after the client upgrades to a different protocol.</para>
        /// </summary>
        UpgradeRequired = 426,
        /// <summary>
        /// <para>HTTP status code <c>428 Precondition Required</c>. The origin server requires the request to be conditional.</para>
        /// </summary>
        PreconditionRequired = 428,
        /// <summary>
        /// <para>HTTP status code <c>429 Too Many Requests</c>. The user has sent too many requests in a given amount of time (see "rate limiting"). Back off and increase time between requests or try again later.</para>
        /// </summary>
        TooManyRequests = 429,
        /// <summary>
        /// <para>HTTP status code <c>431 Request Header Fields Too Large</c>. The server is unwilling to process the request because its header fields are too large. The request MAY be resubmitted after reducing the size of the request header fields.</para>
        /// </summary>
        RequestHeaderFieldsTooLarge = 431,
        /// <summary>
        /// <para>HTTP status code <c>451 Response Unavailable For Legal Reasons</c>. The server is denying access to the resource as a consequence of a legal demand.</para>
        /// </summary>
        UnavailableForLegalReasons = 451,
        /// <summary>
        /// <para>HTTP status code <c>500 Internal Server Error</c>. The server encountered an unexpected condition that prevented it from fulfilling the request.</para>
        /// </summary>
        InternalServerError = 500,
        /// <summary>
        /// <para>HTTP status code <c>501 Not Implemented</c>. The server does not support the functionality required to fulfill the request.</para>
        /// </summary>
        NotImplemented = 501,
        /// <summary>
        /// <para>HTTP status code <c>502 Bad Gateway</c>. The server, while acting as a gateway or proxy, received an invalid response from an inbound server it accessed while attempting to fulfill the request. Usually returned by load balancers or proxies.</para>
        /// </summary>
        BadGateway = 502,
        /// <summary>
        /// <para>HTTP status code <c>503 Service Unavailable</c>. The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay. Try again later.</para>
        /// </summary>
        ServiceUnavailable = 503,
        /// <summary>
        /// <para>HTTP status code <c>504 Gateway Timeout</c>. The server, while acting as a gateway or proxy, did not receive a timely response from an upstream server it needed to access in order to complete the request. Usually returned by load balancers or proxies.</para>
        /// </summary>
        GatewayTimeout = 504,
        /// <summary>
        /// <para>HTTP status code <c>505 HTTP Version Not Supported</c>. The server does not support, or refuses to support, the major version of HTTP that was used in the request message.</para>
        /// </summary>
        HttpVersionNotSupported = 505,
        /// <summary>
        /// <para>HTTP status code <c>506 Variant Also Negotiates</c>. The server has an internal configuration error: the chosen variant resource is configured to engage in transparent content negotiation itself, and is therefore not a proper end point in the negotiation process.</para>
        /// </summary>
        VariantAlsoNegotiates = 506,
        /// <summary>
        /// <para>HTTP status code <c>507 Insufficient Storage</c>. The method could not be performed on the resource because the server is unable to store the representation needed to successfully complete the request.</para>
        /// </summary>
        InsufficientStorage = 507,
        /// <summary>
        /// <para>HTTP status code <c>508 Loop Detected</c>. The server terminated an operation because it encountered an infinite loop while processing a request with "Depth: infinity". This status indicates that the entire operation failed.</para>
        /// </summary>
        LoopDetected = 508,
        /// <summary>
        /// <para>HTTP status code <c>510 Not Extended</c>. The policy for accessing the resource has not been met in the request. The server should send back all the information necessary for the client to issue an extended request.</para>
        /// </summary>
        NotExtended = 510,
        /// <summary>
        /// <para>HTTP status code <c>511 Network Authentication Required</c>. The client needs to authenticate to gain network access.</para>
        /// </summary>
        NetworkAuthRequired = 511
    }

    /// <summary>
    /// <para>If <see langword="true"/>, execution will block until all data is read from the response.</para>
    /// </summary>
    public bool BlockingModeEnabled
    {
        get
        {
            return IsBlockingModeEnabled();
        }
        set
        {
            SetBlockingMode(value);
        }
    }

    /// <summary>
    /// <para>The connection to use for this client.</para>
    /// </summary>
    public StreamPeer Connection
    {
        get
        {
            return GetConnection();
        }
        set
        {
            SetConnection(value);
        }
    }

    /// <summary>
    /// <para>The size of the buffer used and maximum bytes to read per iteration. See <see cref="Godot.HttpClient.ReadResponseBodyChunk()"/>.</para>
    /// </summary>
    public int ReadChunkSize
    {
        get
        {
            return GetReadChunkSize();
        }
        set
        {
            SetReadChunkSize(value);
        }
    }

    private static readonly System.Type CachedType = typeof(HttpClient);

    private static readonly StringName NativeName = "HTTPClient";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public HttpClient() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal HttpClient(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal HttpClient(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectToHost, 504540374ul);

    /// <summary>
    /// <para>Connects to a host. This needs to be done before any requests are sent.</para>
    /// <para>If no <paramref name="port"/> is specified (or <c>-1</c> is used), it is automatically set to 80 for HTTP and 443 for HTTPS. You can pass the optional <paramref name="tlsOptions"/> parameter to customize the trusted certification authorities, or the common name verification when using HTTPS. See <see cref="Godot.TlsOptions.Client(X509Certificate, string)"/> and <see cref="Godot.TlsOptions.ClientUnsafe(X509Certificate)"/>.</para>
    /// </summary>
    public Error ConnectToHost(string host, int port = -1, TlsOptions tlsOptions = null)
    {
        return (Error)NativeCalls.godot_icall_3_714(MethodBind0, GodotObject.GetPtr(this), host, port, GodotObject.GetPtr(tlsOptions));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConnection, 3281897016ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetConnection(StreamPeer connection)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(connection));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnection, 2741655269ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StreamPeer GetConnection()
    {
        return (StreamPeer)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestRaw, 540161961ul);

    /// <summary>
    /// <para>Sends a raw HTTP request to the connected host with the given <paramref name="method"/>.</para>
    /// <para>The URL parameter is usually just the part after the host, so for <c>https://example.com/index.php</c>, it is <c>/index.php</c>. When sending requests to an HTTP proxy server, it should be an absolute URL. For <see cref="Godot.HttpClient.Method.Options"/> requests, <c>*</c> is also allowed. For <see cref="Godot.HttpClient.Method.Connect"/> requests, it should be the authority component (<c>host:port</c>).</para>
    /// <para><paramref name="headers"/> are HTTP request headers.</para>
    /// <para>Sends the body data raw, as a byte array and does not encode it in any way.</para>
    /// </summary>
    public Error RequestRaw(HttpClient.Method method, string url, string[] headers, byte[] body)
    {
        return (Error)NativeCalls.godot_icall_4_715(MethodBind3, GodotObject.GetPtr(this), (int)method, url, headers, body);
    }

    /// <summary>
    /// <para>Sends a raw HTTP request to the connected host with the given <paramref name="method"/>.</para>
    /// <para>The URL parameter is usually just the part after the host, so for <c>https://example.com/index.php</c>, it is <c>/index.php</c>. When sending requests to an HTTP proxy server, it should be an absolute URL. For <see cref="Godot.HttpClient.Method.Options"/> requests, <c>*</c> is also allowed. For <see cref="Godot.HttpClient.Method.Connect"/> requests, it should be the authority component (<c>host:port</c>).</para>
    /// <para><paramref name="headers"/> are HTTP request headers.</para>
    /// <para>Sends the body data raw, as a byte array and does not encode it in any way.</para>
    /// </summary>
    public Error RequestRaw(HttpClient.Method method, string url, ReadOnlySpan<string> headers, ReadOnlySpan<byte> body)
    {
        return (Error)NativeCalls.godot_icall_4_715(MethodBind3, GodotObject.GetPtr(this), (int)method, url, headers, body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Request, 3778990155ul);

    /// <summary>
    /// <para>Sends an HTTP request to the connected host with the given <paramref name="method"/>.</para>
    /// <para>The URL parameter is usually just the part after the host, so for <c>https://example.com/index.php</c>, it is <c>/index.php</c>. When sending requests to an HTTP proxy server, it should be an absolute URL. For <see cref="Godot.HttpClient.Method.Options"/> requests, <c>*</c> is also allowed. For <see cref="Godot.HttpClient.Method.Connect"/> requests, it should be the authority component (<c>host:port</c>).</para>
    /// <para><paramref name="headers"/> are HTTP request headers.</para>
    /// <para>To create a POST request with query strings to push to the server, do:</para>
    /// <para><code>
    /// var fields = new Godot.Collections.Dictionary { { "username", "user" }, { "password", "pass" } };
    /// string queryString = new HttpClient().QueryStringFromDict(fields);
    /// string[] headers = ["Content-Type: application/x-www-form-urlencoded", $"Content-Length: {queryString.Length}"];
    /// var result = new HttpClient().Request(HttpClient.Method.Post, "index.php", headers, queryString);
    /// </code></para>
    /// <para><b>Note:</b> The <paramref name="body"/> parameter is ignored if <paramref name="method"/> is <see cref="Godot.HttpClient.Method.Get"/>. This is because GET methods can't contain request data. As a workaround, you can pass request data as a query string in the URL. See <c>String.uri_encode</c> for an example.</para>
    /// </summary>
    public Error Request(HttpClient.Method method, string url, string[] headers, string body = "")
    {
        return (Error)NativeCalls.godot_icall_4_716(MethodBind4, GodotObject.GetPtr(this), (int)method, url, headers, body);
    }

    /// <summary>
    /// <para>Sends an HTTP request to the connected host with the given <paramref name="method"/>.</para>
    /// <para>The URL parameter is usually just the part after the host, so for <c>https://example.com/index.php</c>, it is <c>/index.php</c>. When sending requests to an HTTP proxy server, it should be an absolute URL. For <see cref="Godot.HttpClient.Method.Options"/> requests, <c>*</c> is also allowed. For <see cref="Godot.HttpClient.Method.Connect"/> requests, it should be the authority component (<c>host:port</c>).</para>
    /// <para><paramref name="headers"/> are HTTP request headers.</para>
    /// <para>To create a POST request with query strings to push to the server, do:</para>
    /// <para><code>
    /// var fields = new Godot.Collections.Dictionary { { "username", "user" }, { "password", "pass" } };
    /// string queryString = new HttpClient().QueryStringFromDict(fields);
    /// string[] headers = ["Content-Type: application/x-www-form-urlencoded", $"Content-Length: {queryString.Length}"];
    /// var result = new HttpClient().Request(HttpClient.Method.Post, "index.php", headers, queryString);
    /// </code></para>
    /// <para><b>Note:</b> The <paramref name="body"/> parameter is ignored if <paramref name="method"/> is <see cref="Godot.HttpClient.Method.Get"/>. This is because GET methods can't contain request data. As a workaround, you can pass request data as a query string in the URL. See <c>String.uri_encode</c> for an example.</para>
    /// </summary>
    public Error Request(HttpClient.Method method, string url, ReadOnlySpan<string> headers, string body)
    {
        return (Error)NativeCalls.godot_icall_4_716(MethodBind4, GodotObject.GetPtr(this), (int)method, url, headers, body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Close, 3218959716ul);

    /// <summary>
    /// <para>Closes the current connection, allowing reuse of this <see cref="Godot.HttpClient"/>.</para>
    /// </summary>
    public void Close()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasResponse, 36873697ul);

    /// <summary>
    /// <para>If <see langword="true"/>, this <see cref="Godot.HttpClient"/> has a response available.</para>
    /// </summary>
    public bool HasResponse()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsResponseChunked, 36873697ul);

    /// <summary>
    /// <para>If <see langword="true"/>, this <see cref="Godot.HttpClient"/> has a response that is chunked.</para>
    /// </summary>
    public bool IsResponseChunked()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResponseCode, 3905245786ul);

    /// <summary>
    /// <para>Returns the response's HTTP status code.</para>
    /// </summary>
    public int GetResponseCode()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResponseHeaders, 2981934095ul);

    /// <summary>
    /// <para>Returns the response headers.</para>
    /// </summary>
    public string[] GetResponseHeaders()
    {
        return NativeCalls.godot_icall_0_108(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResponseHeadersAsDictionary, 2382534195ul);

    /// <summary>
    /// <para>Returns all response headers as a <see cref="Godot.Collections.Dictionary"/>. Each entry is composed by the header name, and a <see cref="string"/> containing the values separated by <c>"; "</c>. The casing is kept the same as the headers were received.</para>
    /// <para><code>
    /// {
    /// 	"content-length": 12,
    /// 	"Content-Type": "application/json; charset=UTF-8",
    /// }
    /// </code></para>
    /// </summary>
    public Godot.Collections.Dictionary GetResponseHeadersAsDictionary()
    {
        return NativeCalls.godot_icall_0_122(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResponseBodyLength, 3905245786ul);

    /// <summary>
    /// <para>Returns the response's body length.</para>
    /// <para><b>Note:</b> Some Web servers may not send a body length. In this case, the value returned will be <c>-1</c>. If using chunked transfer encoding, the body length will also be <c>-1</c>.</para>
    /// <para><b>Note:</b> This function always returns <c>-1</c> on the Web platform due to browsers limitations.</para>
    /// </summary>
    public long GetResponseBodyLength()
    {
        return NativeCalls.godot_icall_0_4(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReadResponseBodyChunk, 2115431945ul);

    /// <summary>
    /// <para>Reads one chunk from the response.</para>
    /// </summary>
    public byte[] ReadResponseBodyChunk()
    {
        return NativeCalls.godot_icall_0_2(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReadChunkSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReadChunkSize(int bytes)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), bytes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReadChunkSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetReadChunkSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlockingMode, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlockingMode(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBlockingModeEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsBlockingModeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStatus, 1426656811ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.HttpClient.Status"/> constant. Need to call <see cref="Godot.HttpClient.Poll()"/> in order to get status updates.</para>
    /// </summary>
    public HttpClient.Status GetStatus()
    {
        return (HttpClient.Status)NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Poll, 166280745ul);

    /// <summary>
    /// <para>This needs to be called in order to have any request processed. Check results with <see cref="Godot.HttpClient.GetStatus()"/>.</para>
    /// </summary>
    public Error Poll()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHttpProxy, 2956805083ul);

    /// <summary>
    /// <para>Sets the proxy server for HTTP requests.</para>
    /// <para>The proxy server is unset if <paramref name="host"/> is empty or <paramref name="port"/> is -1.</para>
    /// </summary>
    public void SetHttpProxy(string host, int port)
    {
        NativeCalls.godot_icall_2_400(MethodBind19, GodotObject.GetPtr(this), host, port);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHttpsProxy, 2956805083ul);

    /// <summary>
    /// <para>Sets the proxy server for HTTPS requests.</para>
    /// <para>The proxy server is unset if <paramref name="host"/> is empty or <paramref name="port"/> is -1.</para>
    /// </summary>
    public void SetHttpsProxy(string host, int port)
    {
        NativeCalls.godot_icall_2_400(MethodBind20, GodotObject.GetPtr(this), host, port);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueryStringFromDict, 2538086567ul);

    /// <summary>
    /// <para>Generates a GET/POST application/x-www-form-urlencoded style query string from a provided dictionary, e.g.:</para>
    /// <para><code>
    /// var fields = new Godot.Collections.Dictionary { { "username", "user" }, { "password", "pass" } };
    /// string queryString = httpClient.QueryStringFromDict(fields);
    /// // Returns "username=user&amp;password=pass"
    /// </code></para>
    /// <para>Furthermore, if a key has a <see langword="null"/> value, only the key itself is added, without equal sign and value. If the value is an array, for each value in it a pair with the same key is added.</para>
    /// <para><code>
    /// var fields = new Godot.Collections.Dictionary
    /// {
    /// 	{ "single", 123 },
    /// 	{ "notValued", default },
    /// 	{ "multiple", new Godot.Collections.Array { 22, 33, 44 } },
    /// };
    /// string queryString = httpClient.QueryStringFromDict(fields);
    /// // Returns "single=123&amp;not_valued&amp;multiple=22&amp;multiple=33&amp;multiple=44"
    /// </code></para>
    /// </summary>
    public string QueryStringFromDict(Godot.Collections.Dictionary fields)
    {
        return NativeCalls.godot_icall_1_717(MethodBind21, GodotObject.GetPtr(this), (godot_dictionary)(fields ?? new()).NativeValue);
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
        /// Cached name for the 'blocking_mode_enabled' property.
        /// </summary>
        public static readonly StringName BlockingModeEnabled = "blocking_mode_enabled";
        /// <summary>
        /// Cached name for the 'connection' property.
        /// </summary>
        public static readonly StringName Connection = "connection";
        /// <summary>
        /// Cached name for the 'read_chunk_size' property.
        /// </summary>
        public static readonly StringName ReadChunkSize = "read_chunk_size";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'connect_to_host' method.
        /// </summary>
        public static readonly StringName ConnectToHost = "connect_to_host";
        /// <summary>
        /// Cached name for the 'set_connection' method.
        /// </summary>
        public static readonly StringName SetConnection = "set_connection";
        /// <summary>
        /// Cached name for the 'get_connection' method.
        /// </summary>
        public static readonly StringName GetConnection = "get_connection";
        /// <summary>
        /// Cached name for the 'request_raw' method.
        /// </summary>
        public static readonly StringName RequestRaw = "request_raw";
        /// <summary>
        /// Cached name for the 'request' method.
        /// </summary>
        public static readonly StringName Request = "request";
        /// <summary>
        /// Cached name for the 'close' method.
        /// </summary>
        public static readonly StringName Close = "close";
        /// <summary>
        /// Cached name for the 'has_response' method.
        /// </summary>
        public static readonly StringName HasResponse = "has_response";
        /// <summary>
        /// Cached name for the 'is_response_chunked' method.
        /// </summary>
        public static readonly StringName IsResponseChunked = "is_response_chunked";
        /// <summary>
        /// Cached name for the 'get_response_code' method.
        /// </summary>
        public static readonly StringName GetResponseCode = "get_response_code";
        /// <summary>
        /// Cached name for the 'get_response_headers' method.
        /// </summary>
        public static readonly StringName GetResponseHeaders = "get_response_headers";
        /// <summary>
        /// Cached name for the 'get_response_headers_as_dictionary' method.
        /// </summary>
        public static readonly StringName GetResponseHeadersAsDictionary = "get_response_headers_as_dictionary";
        /// <summary>
        /// Cached name for the 'get_response_body_length' method.
        /// </summary>
        public static readonly StringName GetResponseBodyLength = "get_response_body_length";
        /// <summary>
        /// Cached name for the 'read_response_body_chunk' method.
        /// </summary>
        public static readonly StringName ReadResponseBodyChunk = "read_response_body_chunk";
        /// <summary>
        /// Cached name for the 'set_read_chunk_size' method.
        /// </summary>
        public static readonly StringName SetReadChunkSize = "set_read_chunk_size";
        /// <summary>
        /// Cached name for the 'get_read_chunk_size' method.
        /// </summary>
        public static readonly StringName GetReadChunkSize = "get_read_chunk_size";
        /// <summary>
        /// Cached name for the 'set_blocking_mode' method.
        /// </summary>
        public static readonly StringName SetBlockingMode = "set_blocking_mode";
        /// <summary>
        /// Cached name for the 'is_blocking_mode_enabled' method.
        /// </summary>
        public static readonly StringName IsBlockingModeEnabled = "is_blocking_mode_enabled";
        /// <summary>
        /// Cached name for the 'get_status' method.
        /// </summary>
        public static readonly StringName GetStatus = "get_status";
        /// <summary>
        /// Cached name for the 'poll' method.
        /// </summary>
        public static readonly StringName Poll = "poll";
        /// <summary>
        /// Cached name for the 'set_http_proxy' method.
        /// </summary>
        public static readonly StringName SetHttpProxy = "set_http_proxy";
        /// <summary>
        /// Cached name for the 'set_https_proxy' method.
        /// </summary>
        public static readonly StringName SetHttpsProxy = "set_https_proxy";
        /// <summary>
        /// Cached name for the 'query_string_from_dict' method.
        /// </summary>
        public static readonly StringName QueryStringFromDict = "query_string_from_dict";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
