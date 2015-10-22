namespace WebServer
{
    using System;
    using Cookies;
    using Headers;
    using Parameters;

    /// <summary>
    /// Request sent to a HTTP server.
    /// </summary>
    /// <seealso cref="Request"/>
    public interface IRequest : IMessage
    {
        /// <summary>
        /// Gets or sets HTTP version.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        string HttpVersion { get; set; }

        /// <summary>
        /// Gets requested URI.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets HTTP method.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        RequestMethodType Method { get; set; }

        /// <summary>
        /// Gets query string and form parameters
        /// </summary>
        /// <value>
        /// 
        /// </value>
        IParameterCollection Parameters { get; }

        /// <summary>
        /// Gets query string.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        IParameterCollection QueryString { get; }

        /// <summary>
        /// Gets if request is an Ajax request.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        bool IsAjax { get; }

        /// <summary>
        /// Gets cookies.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        RequestCookieCollection Cookies { get; }

        /// <summary>
        /// Gets or sets connection header.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        ConnectionHeader Connection { get; }
    }
}
