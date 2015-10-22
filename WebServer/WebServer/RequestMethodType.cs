namespace WebServer
{
    /// <summary>
    /// The enum of common methods for HTTP/1.1.
    /// </summary>
    public enum RequestMethodType
    {
        /// <summary>
        /// The HEAD method is identical to GET 
        /// except that the server MUST NOT return 
        /// a message-body in the response.
        /// </summary>
        Head,

        /// <summary>
        /// The GET method means retrieve whatever 
        /// information (in the form of an entity) 
        /// is identified by the Request-URI.
        /// </summary>
        Get,

        /// <summary>
        /// The POST method is used to request 
        /// that the origin server accept the 
        /// entity enclosed in the request as 
        /// a new subordinate of the resource 
        /// identified by the Request-URI in 
        /// the Request-Line.
        /// </summary>
        Post,

        /// <summary>
        /// The PUT method requests that 
        /// the enclosed entity be stored 
        /// under the supplied Request-URI. 
        /// </summary>
        Put,

        /// <summary>
        /// The DELETE method requests that 
        /// the origin server delete the resource 
        /// identified by the Request-URI.
        /// </summary>
        Delete,

        /// <summary>
        /// The OPTIONS method represents a request 
        /// for information about the communication 
        /// options available on the request/response 
        /// chain identified by the Request-URI.
        /// </summary>
        Options
    }
}
