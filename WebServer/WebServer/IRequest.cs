using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Cookies;
using WebServer.Headers;
using WebServer.Parameters;

namespace WebServer
{
    public interface IRequest : IMessage
    {
        /// <summary>
        /// Gets or sets HTTP version.
        /// </summary>
        string HttpVersion { get; set; }

        /// <summary>
        /// Gets requested URI.
        /// </summary>
        Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets HTTP method.
        /// </summary>
        RequestMethodType Method { get; set; }

        /// <summary>
        /// Gets query string.
        /// </summary>
        IParameterCollection QueryString { get; }

        /// <summary>
        /// Gets if request is an Ajax request.
        /// </summary>
        bool IsAjax { get; }

        /// <summary>
        /// Gets cookies.
        /// </summary>
        RequestCookieCollection Cookies { get; }

        /// <summary>
        /// Gets or sets connection header.
        /// </summary>
        ConnectionHeader Connection { get; }
    }
}
