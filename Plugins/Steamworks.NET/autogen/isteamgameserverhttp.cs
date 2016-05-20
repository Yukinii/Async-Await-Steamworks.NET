// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2015 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

namespace Steamworks {
	public static class SteamGameServerHTTP {
		/// <summary>
		/// <para> Initializes a new HTTP request, returning a handle to use in further operations on it.  Requires</para>
		/// <para> the method (GET or POST) and the absolute URL for the request.  Both http and https are supported,</para>
		/// <para> so this string must start with http:// or https:// and should look like http://store.steampowered.com/app/250/</para>
		/// <para> or such.</para>
		/// </summary>
		public static HTTPRequestHandle CreateHTTPRequest(EhttpMethod eHTTPRequestMethod, string AbsoluteURL) {
			InteropHelp.TestIfAvailableGameServer();
			using (var AbsoluteURL2 = new InteropHelp.UTF8StringHandle(AbsoluteURL)) {
				return (HTTPRequestHandle)NativeMethods.ISteamGameServerHTTP_CreateHTTPRequest(eHTTPRequestMethod, AbsoluteURL2);
			}
		}

		/// <summary>
		/// <para> Set a context value for the request, which will be returned in the HTTPRequestCompleted callback after</para>
		/// <para> sending the request.  This is just so the caller can easily keep track of which callbacks go with which request data.</para>
		/// </summary>
		public static bool SetHTTPRequestContextValue(HTTPRequestHandle hRequest, ulong ulContextValue) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestContextValue(hRequest, ulContextValue);
		}

		/// <summary>
		/// <para> Set a timeout in seconds for the HTTP request, must be called prior to sending the request.  Default</para>
		/// <para> timeout is 60 seconds if you don't call this.  Returns false if the handle is invalid, or the request</para>
		/// <para> has already been sent.</para>
		/// </summary>
		public static bool SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle hRequest, uint unTimeoutSeconds) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestNetworkActivityTimeout(hRequest, unTimeoutSeconds);
		}

		/// <summary>
		/// <para> Set a request header value for the request, must be called prior to sending the request.  Will</para>
		/// <para> return false if the handle is invalid or the request is already sent.</para>
		/// </summary>
		public static bool SetHTTPRequestHeaderValue(HTTPRequestHandle hRequest, string HeaderName, string HeaderValue) {
			InteropHelp.TestIfAvailableGameServer();
			using (var HeaderName2 = new InteropHelp.UTF8StringHandle(HeaderName))
			using (var HeaderValue2 = new InteropHelp.UTF8StringHandle(HeaderValue)) {
				return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestHeaderValue(hRequest, HeaderName2, HeaderValue2);
			}
		}

		/// <summary>
		/// <para> Set a GET or POST parameter value on the request, which is set will depend on the EHTTPMethod specified</para>
		/// <para> when creating the request.  Must be called prior to sending the request.  Will return false if the</para>
		/// <para> handle is invalid or the request is already sent.</para>
		/// </summary>
		public static bool SetHTTPRequestGetOrPostParameter(HTTPRequestHandle hRequest, string ParamName, string ParamValue) {
			InteropHelp.TestIfAvailableGameServer();
			using (var ParamName2 = new InteropHelp.UTF8StringHandle(ParamName))
			using (var ParamValue2 = new InteropHelp.UTF8StringHandle(ParamValue)) {
				return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestGetOrPostParameter(hRequest, ParamName2, ParamValue2);
			}
		}

		/// <summary>
		/// <para> Sends the HTTP request, will return false on a bad handle, otherwise use SteamCallHandle to wait on</para>
		/// <para> asynchronous response via callback.</para>
		/// <para> Note: If the user is in offline mode in Steam, then this will add a only-if-cached cache-control</para>
		/// <para> header and only do a local cache lookup rather than sending any actual remote request.</para>
		/// </summary>
		public static bool SendHTTPRequest(HTTPRequestHandle hRequest, out SteamAPICall pCallHandle) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SendHTTPRequest(hRequest, out pCallHandle);
		}

		/// <summary>
		/// <para> Sends the HTTP request, will return false on a bad handle, otherwise use SteamCallHandle to wait on</para>
		/// <para> asynchronous response via callback for completion, and listen for HTTPRequestHeadersReceived and</para>
		/// <para> HTTPRequestDataReceived callbacks while streaming.</para>
		/// </summary>
		public static bool SendHTTPRequestAndStreamResponse(HTTPRequestHandle hRequest, out SteamAPICall pCallHandle) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SendHTTPRequestAndStreamResponse(hRequest, out pCallHandle);
		}

		/// <summary>
		/// <para> Defers a request you have sent, the actual HTTP client code may have many requests queued, and this will move</para>
		/// <para> the specified request to the tail of the queue.  Returns false on invalid handle, or if the request is not yet sent.</para>
		/// </summary>
		public static bool DeferHTTPRequest(HTTPRequestHandle hRequest) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_DeferHTTPRequest(hRequest);
		}

		/// <summary>
		/// <para> Prioritizes a request you have sent, the actual HTTP client code may have many requests queued, and this will move</para>
		/// <para> the specified request to the head of the queue.  Returns false on invalid handle, or if the request is not yet sent.</para>
		/// </summary>
		public static bool PrioritizeHTTPRequest(HTTPRequestHandle hRequest) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_PrioritizeHTTPRequest(hRequest);
		}

		/// <summary>
		/// <para> Checks if a response header is present in a HTTP response given a handle from HTTPRequestCompleted, also</para>
		/// <para> returns the size of the header value if present so the caller and allocate a correctly sized buffer for</para>
		/// <para> GetHTTPResponseHeaderValue.</para>
		/// </summary>
		public static bool GetHTTPResponseHeaderSize(HTTPRequestHandle hRequest, string HeaderName, out uint unResponseHeaderSize) {
			InteropHelp.TestIfAvailableGameServer();
			using (var HeaderName2 = new InteropHelp.UTF8StringHandle(HeaderName)) {
				return NativeMethods.ISteamGameServerHTTP_GetHTTPResponseHeaderSize(hRequest, HeaderName2, out unResponseHeaderSize);
			}
		}

		/// <summary>
		/// <para> Gets header values from a HTTP response given a handle from HTTPRequestCompleted, will return false if the</para>
		/// <para> header is not present or if your buffer is too small to contain it's value.  You should first call</para>
		/// <para> BGetHTTPResponseHeaderSize to check for the presence of the header and to find out the size buffer needed.</para>
		/// </summary>
		public static bool GetHTTPResponseHeaderValue(HTTPRequestHandle hRequest, string HeaderName, byte[] pHeaderValueBuffer, uint unBufferSize) {
			InteropHelp.TestIfAvailableGameServer();
			using (var HeaderName2 = new InteropHelp.UTF8StringHandle(HeaderName)) {
				return NativeMethods.ISteamGameServerHTTP_GetHTTPResponseHeaderValue(hRequest, HeaderName2, pHeaderValueBuffer, unBufferSize);
			}
		}

		/// <summary>
		/// <para> Gets the size of the body data from a HTTP response given a handle from HTTPRequestCompleted, will return false if the</para>
		/// <para> handle is invalid.</para>
		/// </summary>
		public static bool GetHTTPResponseBodySize(HTTPRequestHandle hRequest, out uint unBodySize) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPResponseBodySize(hRequest, out unBodySize);
		}

		/// <summary>
		/// <para> Gets the body data from a HTTP response given a handle from HTTPRequestCompleted, will return false if the</para>
		/// <para> handle is invalid or is to a streaming response, or if the provided buffer is not the correct size.  Use BGetHTTPResponseBodySize first to find out</para>
		/// <para> the correct buffer size to use.</para>
		/// </summary>
		public static bool GetHTTPResponseBodyData(HTTPRequestHandle hRequest, byte[] pBodyDataBuffer, uint unBufferSize) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPResponseBodyData(hRequest, pBodyDataBuffer, unBufferSize);
		}

		/// <summary>
		/// <para> Gets the body data from a streaming HTTP response given a handle from HTTPRequestDataReceived. Will return false if the</para>
		/// <para> handle is invalid or is to a non-streaming response (meaning it wasn't sent with SendHTTPRequestAndStreamResponse), or if the buffer size and offset</para>
		/// <para> do not match the size and offset sent in HTTPRequestDataReceived.</para>
		/// </summary>
		public static bool GetHTTPStreamingResponseBodyData(HTTPRequestHandle hRequest, uint cOffset, byte[] pBodyDataBuffer, uint unBufferSize) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPStreamingResponseBodyData(hRequest, cOffset, pBodyDataBuffer, unBufferSize);
		}

		/// <summary>
		/// <para> Releases an HTTP response handle, should always be called to free resources after receiving a HTTPRequestCompleted</para>
		/// <para> callback and finishing using the response.</para>
		/// </summary>
		public static bool ReleaseHTTPRequest(HTTPRequestHandle hRequest) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_ReleaseHTTPRequest(hRequest);
		}

		/// <summary>
		/// <para> Gets progress on downloading the body for the request.  This will be zero unless a response header has already been</para>
		/// <para> received which included a content-length field.  For responses that contain no content-length it will report</para>
		/// <para> zero for the duration of the request as the size is unknown until the connection closes.</para>
		/// </summary>
		public static bool GetHTTPDownloadProgressPct(HTTPRequestHandle hRequest, out float pflPercentOut) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPDownloadProgressPct(hRequest, out pflPercentOut);
		}

		/// <summary>
		/// <para> Sets the body for an HTTP Post request.  Will fail and return false on a GET request, and will fail if POST params</para>
		/// <para> have already been set for the request.  Setting this raw body makes it the only contents for the post, the ContentType</para>
		/// <para> parameter will set the content-type header for the request so the server may know how to interpret the body.</para>
		/// </summary>
		public static bool SetHTTPRequestRawPostBody(HTTPRequestHandle hRequest, string ContentType, byte[] pubBody, uint unBodyLen) {
			InteropHelp.TestIfAvailableGameServer();
			using (var ContentType2 = new InteropHelp.UTF8StringHandle(ContentType)) {
				return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestRawPostBody(hRequest, ContentType2, pubBody, unBodyLen);
			}
		}

		/// <summary>
		/// <para> Creates a cookie container handle which you must later free with ReleaseCookieContainer().  If bAllowResponsesToModify=true</para>
		/// <para> than any response to your requests using this cookie container may add new cookies which may be transmitted with</para>
		/// <para> future requests.  If bAllowResponsesToModify=false than only cookies you explicitly set will be sent.  This API is just for</para>
		/// <para> during process lifetime, after steam restarts no cookies are persisted and you have no way to access the cookie container across</para>
		/// <para> repeat executions of your process.</para>
		/// </summary>
		public static HTTPCookieContainerHandle CreateCookieContainer(bool bAllowResponsesToModify) {
			InteropHelp.TestIfAvailableGameServer();
			return (HTTPCookieContainerHandle)NativeMethods.ISteamGameServerHTTP_CreateCookieContainer(bAllowResponsesToModify);
		}

		/// <summary>
		/// <para> Release a cookie container you are finished using, freeing it's memory</para>
		/// </summary>
		public static bool ReleaseCookieContainer(HTTPCookieContainerHandle hCookieContainer) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_ReleaseCookieContainer(hCookieContainer);
		}

		/// <summary>
		/// <para> Adds a cookie to the specified cookie container that will be used with future requests.</para>
		/// </summary>
		public static bool SetCookie(HTTPCookieContainerHandle hCookieContainer, string Host, string Url, string Cookie) {
			InteropHelp.TestIfAvailableGameServer();
			using (var Host2 = new InteropHelp.UTF8StringHandle(Host))
			using (var Url2 = new InteropHelp.UTF8StringHandle(Url))
			using (var Cookie2 = new InteropHelp.UTF8StringHandle(Cookie)) {
				return NativeMethods.ISteamGameServerHTTP_SetCookie(hCookieContainer, Host2, Url2, Cookie2);
			}
		}

		/// <summary>
		/// <para> Set the cookie container to use for a HTTP request</para>
		/// </summary>
		public static bool SetHTTPRequestCookieContainer(HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestCookieContainer(hRequest, hCookieContainer);
		}

		/// <summary>
		/// <para> Set the extra user agent info for a request, this doesn't clobber the normal user agent, it just adds the extra info on the end</para>
		/// </summary>
		public static bool SetHTTPRequestUserAgentInfo(HTTPRequestHandle hRequest, string UserAgentInfo) {
			InteropHelp.TestIfAvailableGameServer();
			using (var UserAgentInfo2 = new InteropHelp.UTF8StringHandle(UserAgentInfo)) {
				return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestUserAgentInfo(hRequest, UserAgentInfo2);
			}
		}

		/// <summary>
		/// <para> Set that https request should require verified SSL certificate via machines certificate trust store</para>
		/// </summary>
		public static bool SetHTTPRequestRequiresVerifiedCertificate(HTTPRequestHandle hRequest, bool bRequireVerifiedCertificate) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestRequiresVerifiedCertificate(hRequest, bRequireVerifiedCertificate);
		}

		/// <summary>
		/// <para> Set an absolute timeout on the HTTP request, this is just a total time timeout different than the network activity timeout</para>
		/// <para> which can bump everytime we get more data</para>
		/// </summary>
		public static bool SetHTTPRequestAbsoluteTimeoutMS(HTTPRequestHandle hRequest, uint unMilliseconds) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_SetHTTPRequestAbsoluteTimeoutMS(hRequest, unMilliseconds);
		}

		/// <summary>
		/// <para> Check if the reason the request failed was because we timed it out (rather than some harder failure)</para>
		/// </summary>
		public static bool GetHTTPRequestWasTimedOut(HTTPRequestHandle hRequest, out bool pbWasTimedOut) {
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerHTTP_GetHTTPRequestWasTimedOut(hRequest, out pbWasTimedOut);
		}
	}
}